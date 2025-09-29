//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動回答品目設定マスタメンテナンス
// プログラム概要   : 自動回答品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/10/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/11/07  修正内容 : 12/12配信 システムテスト障害№2対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/13  修正内容 : 12/12配信 システムテスト障害№1,2,3,4,10,12,13,15,16,17,18,19,23,24,26,27対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/16  修正内容 : 12/12配信 システムテスト障害№26,35,53対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/21  修正内容 : 12/12配信 システムテスト障害№57対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 三戸 伸悟
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№63対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№77対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/26  修正内容 : 2012/12/12配信予定システムテスト障害№80,81,82対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/11/22  修正内容 : VSS[019] Redmine#677対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自動回答品目設定マスタメンテナンスUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 自動回答品目設定マスタメンテナンスUIフォームクラス</br>
    /// </remarks>
    public partial class PMKHN09701UA : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09701U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09701U.dat";

        // グリッド列
        public const string COLUMN_NO = "No";

        private const string ERRORMSG_RANGE = "{0}の範囲に誤まりがあります";

        private const string AUTOANSWER_DIV_NO_AUTOANSWER = "しない";
        private const string AUTOANSWER_DIV_AUTOANSWER = "する(自動回答)";
        private const string AUTOANSWER_DIV_AUTOANSWER_PRIORITY = "する(優先順位)";

        /// <summary>
        /// 次の項目の"設定無し"を表す
        /// 優良設定詳細コード２（種別コード）
        /// 優先順位
        /// </summary>
        public const int NO_SETTING = 0;

        #endregion ■ Constants

        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private AutoAnsItemStAcs _autoAnsItemStAcs; // 自動回答品目設定マスタメンテナンスアクセスクラス
        private AutoAnsItemStGuideControl _guideControl; // 自動回答品目設定マスメンガイド制御クラス

        private PMKHN09701UB _editForm; // 編集UI

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        // 抽出条件
        private AutoAnsItemStOrder _extrInfo;

        private bool _closeFlg;

        // 新規追加行変更前情報
        private string _sectionCode = "";               // 拠点コード
        private int _customerCode = 0;                  // 得意先コード
        private string _goodsMGroup = "";               // 商品中分類コード
        private string _blGoodsCode = "";               // BLコード
        private string _goodsMakerCode = "";            // ﾒｰｶｰｺｰﾄﾞ
        private string _prmSetDtlNo2 = "";              // 種別コード
        private string _priorityOrder = "";             // 優先順位
        private int _autoAnswerDiv = 0;                 // 自動回答区分


        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>
        // 検索時列幅保存用
        private int widthDelete = 0;            // 削除日
        private int widthNo = 0;                // №
        private int widthSection = 0;           // 拠点
        private int widthCustomer = 0;          // 得意先
        private int widthGoodsMGroup = 0;       // 商品中分類
        private int widthGoodsMGroupName = 0;   // 商品中分類名称
        private int widthBlCode = 0;            // BLコード
        private int widthBlCodeName = 0;        // BLコード名称
        private int widthMaker = 0;             // メーカー
        private int widthMakerName = 0;         // メーカー名称
        private int widthType = 0;              // 種 別
        private int widthTypeName = 0;          // 種別名称
        private int widthAutoAnsDiv = 0;        // 自動回答区分
        private int widthPriority = 0;          // 優先順位
        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 画面情報比較の要否フラグ 
        /// true：比較要　false：比較不要　
        /// </summary>
        private bool _needCompare = true;
        #endregion 

        #region ■ Public Members

        public static DataView OfferPrimeSettingDataView;

        #endregion

        #region ■ Constructor

        /// <summary>
        /// 自動回答品目設定マスタメンテナンスUIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 自動回答品目設定マスタメンテナンスUIフォームクラスのインスタンスを生成します。</br>
        /// </remarks>
        public PMKHN09701UA()
		{
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ガイド制御
            _guideControl = new AutoAnsItemStGuideControl( _enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim() );
            _guideControl.AfterRenewal += new EventHandler( GuideControl_AfterRenewal );

            this._autoAnsItemStAcs = new AutoAnsItemStAcs();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№1 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._autoAnsItemStAcs.EnterpriseCode = this._enterpriseCode;
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№1 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            this._autoAnsItemStAcs.AfterTableUpdate += new EventHandler(AutoAnsItemStAcs_AfterTableUpdate);

            this._gridStateController = new GridStateController();

            // 画面初期設定
            SetInitialSetting();

            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№26 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 初回起動時のみ　グリッド列幅の設定
            if (this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details) != 0)
            {
               GridWidthSet();
            }
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№26 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 画面クリア
            ClearScreen();

            // 優良設定マスタの取得
            int status = this._autoAnsItemStAcs.GetOfferPrimesettingList(ref OfferPrimeSettingDataView);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                status != (int)ConstantManagement.DB_Status.ctDB_EOF &&
                status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {

                // サーチ
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                    ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    this.Name, 			                // プログラム名称
                    "PMKHN09701UA", 			        // 処理名称
                    TMsgDisp.OPE_GET, 					// オペレーション
                    "読み込みに失敗しました。", 		// 表示するメッセージ
                    status, 							// ステータス値
                    this._autoAnsItemStAcs, 	        // エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
        }
        #endregion ■ Constructor

        #region ■ Private Methods

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Details);
                if (gridStateInfo != null)
                {
                    // フォントサイズ
                    this.tComboEditor_GridFontSize.Value = (int)gridStateInfo.FontSize;
                    // 列の自動調整
                    this.uCheckEditor_AutoFillToColumn.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // フォントサイズ
                this.tComboEditor_GridFontSize.Value = 11;
                // 列の自動調整
                this.uCheckEditor_AutoFillToColumn.Checked = false;
            }
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion XML操作

        #region 名称取得
        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">拠点名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 拠点コードに該当する拠点略称を取得します。</br>
        /// </remarks>
        private bool GetSectionName( string sectionCode, out string sectionName )
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                sectionName = "全社";
                return true;
            }

            if ( this._guideControl.SecInfoSetDic.ContainsKey( sectionCode ) )
            {
                sectionName = this._guideControl.SecInfoSetDic[sectionCode].SectionGuideNm.Trim();
                return true;
            }
            else
            {
                sectionName = string.Empty;
                return false;
            }
        }
        /// <summary>
        /// 得意先名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadCustomer(ref int code, out string name)
        {
            // 検索条件セット
            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = _enterpriseCode;
            para.CustomerCode = code;

            // 検索実行
            CustomerSearchRet[] retList;
            int status = _guideControl.CustomerSearchAcs.Serch(out retList, para);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null && retList.Length > 0)
            {
                name = retList[0].Name;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// メーカー名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadMaker(ref int code, out string name)
        {
            bool rtn = false;
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.Read(out maker, this._enterpriseCode, code);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null)
            {
                name = maker.MakerName;
                rtn = true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                rtn = false;
            }

            return rtn;
        }

        /// <summary>
        /// 商品中分類名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMGroup(ref int code, out string name)
        {
            GoodsGroupU goodsGroupU;
            int status = _guideControl.GoodsAcs.GetGoodsMGroup(_enterpriseCode, code, out goodsGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsGroupU != null)
            {
                name = goodsGroupU.GoodsMGroupName;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// ＢＬコード名取得
        /// ＢＬコードに紐づく商品中分類を取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="goodsMGroup"></param>
        /// <returns></returns>
        private bool ReadBLCode(ref int code, out string name,out int goodsMGroup)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = _guideControl.BLGoodsCdAcs.Read(out blGoodsCdUMnt, _enterpriseCode, code);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null)
            {
                name = blGoodsCdUMnt.BLGoodsFullName;
                goodsMGroup = blGoodsCdUMnt.GoodsRateGrpCode;    // 商品中分類
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                goodsMGroup = 0;
                return false;
            }
        }
        #endregion 名称取得

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);


            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            LabelTool labelTool;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Edit"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EDITING;
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 拠点名
            ToolBase sectionName = tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"];
            if (sectionName != null && LoginInfoAcquisition.Employee != null)
            {
                string name;
                GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode, out name );
                sectionName.SharedProps.Caption = name;
            }

            // ログイン名
            ToolBase loginName = tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeAllowZero.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCode_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCode_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCode_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCode_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(ref this.uGrid_Details);
        }
        #endregion 初期設定

        #region クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// </remarks>
        private void ClearScreen()
        {
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№12 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            tComboEditor_TargetDivide.Focus();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№12 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 対象区分
            this.tComboEditor_TargetDivide.Value = 0;

            // 拠点
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            // 得意先コード
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            // メーカーコード
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // 商品中分類コード
            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
            // ＢＬコード
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();

            // スクロールポジション初期化
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // グリッドクリア
            ClearGrid();

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドを初期化を行います。</br>
        /// </remarks>
        private void ClearGrid()
        {
            // グリッド作成処理
            CreateGrid(ref this.uGrid_Details);
            // キーマッピング設定
            MakeKeyMappingForGrid( this.uGrid_Details );

            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // 新規追加行　追加処理
            this._autoAnsItemStAcs.RowAdd();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 ---------<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// グリッド新規追加行初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドの新規追加行の初期化を行います。</br>
        /// </remarks>
        private void ClearGridNewAddRow()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value = (int)AutoAnsItemStAcs.AutoAnswerDiv.None;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV_BACKUP].Value = (int)AutoAnsItemStAcs.AutoAnswerDiv.None;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = string.Empty;

            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value = (int)AutoAnsItemStAcs.NewAddRowDiv.New;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = (int)AutoAnsItemStAcs.NewAddRowAllowSave.No;

            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE_SORT].Value = int.MaxValue; // 一覧最下行に表示するため最大値とする
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE_SORT].Value = string.Empty;
        }

        #endregion クリア処理

        #region 保存
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// </remarks>
        private int Save()
        {
            tComboEditor_TargetDivide.Focus();

            # region [更新レコード有無チェック]
            if (_autoAnsItemStAcs.GetUpdateCountFromTable() == 0)
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    "更新対象のデータが存在しません",// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            # endregion
            
            #region [保存前各種チェック]
            string msg = string.Empty;
            if (!CheckBeforeSave(out msg))
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               msg,
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            #endregion

            // 更新処理
            string errMsg;
            int status = _autoAnsItemStAcs.WriteAll( out errMsg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 登録完了ダイアログ表示
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog( 2 );

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE )
                        {
                            errMsg = "既に他端末より更新されています。";
                        }
                        else
                        {
                            errMsg = "既に他端末より削除されています。";
                        }

                        ShowMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "Save",
                                       errMsg,
                                       status,
                                       MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (status);
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№1 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            "入力された品目設定は既に登録されています。", 	                    // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);			// 表示するボタン
                        break;
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№1 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                default:
                    {
                        ShowMessageBox( emErrorLevel.ERR_LEVEL_STOP,
                                   "Save",
                                   "保存処理に失敗しました。",
                                   status,
                                   MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (status);
                    }
            }

            return status;
        }
        #endregion 保存

        #region 検索
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// </remarks>
        private int Search()
        {
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№53 --------->>>>>>>>>>>>>>>>>>>>>>>>
            GridWidthSave();
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№53 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 画面情報比較
            if ( !CompareScreen() )
            {
                return status;
            }

            // 検索条件入力チェック
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return -1;
            }

            // 検索条件格納
            if ( _extrInfo == null )
            {
                _extrInfo = new AutoAnsItemStOrder();
            }
            AutoAnsItemStOrder extrInfoClone = _extrInfo.Clone();
            SetExtrInfo(out this._extrInfo);
            ArrayList compareList = _extrInfo.Compare( extrInfoClone );
            if ( compareList == null || compareList.Count == 0 )
            {
                // 条件が変わらないので終了
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "自動回答品目設定マスタの抽出中です。";

            string msg;

            try
            {
                msgForm.Show();

                // 検索処理
                status = this._autoAnsItemStAcs.Search( _extrInfo, out msg );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // グリッドデータ設定
                    CreateGrid(ref this.uGrid_Details);

                    // グリッド行カラー設定
                    SettingGridRows(ref this.uGrid_Details);

                    return (status);
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "検索条件に該当するデータが存在しません。",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // グリッドクリア
                        ClearGrid();

                        // フォーカス移動
                        tComboEditor_TargetDivide.Focus();

                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "検索処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッドクリア
                        ClearGrid();

                        // フォーカス移動
                        tComboEditor_TargetDivide.Focus();

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 検索条件設定処理
        /// </summary>
        /// <param name="para">検索条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報から検索条件を設定します。</br>
        /// </remarks>
        private void SetExtrInfo(out AutoAnsItemStOrder para)
        {
            para = new AutoAnsItemStOrder();

            // 企業コード
            para.EnterpriseCode = this._enterpriseCode;

            // 拠点・得意先
            switch ( (int)this.tComboEditor_TargetDivide.Value )
            {
                // 全て
                default:
                case 0:
                    {
                        para.SectionCode = null;
                        para.St_CustomerCode = 0;
                        para.Ed_CustomerCode = 0;
                    }
                    break;
                // 拠点
                case 1:
                    {
                        para.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft( 2, '0' );
                        para.St_CustomerCode = 0;
                        para.Ed_CustomerCode = 0;
                    }
                    break;
                // 得意先
                case 2:
                    {
                        para.SectionCode = null;
                        para.St_CustomerCode = tNedit_CustomerCode_St.GetInt();
                        para.Ed_CustomerCode = tNedit_CustomerCode_Ed.GetInt();

                        // 得意先設定分を取得するため、1以上にする
                        if ( para.St_CustomerCode == 0 )
                        {
                            para.St_CustomerCode = 1;
                        }
                    }
                    break;
            }

            // メーカー
            para.St_GoodsMakerCd = tNedit_GoodsMakerCd_St.GetInt();
            para.Ed_GoodsMakerCd = tNedit_GoodsMakerCd_Ed.GetInt();
            // 商品中分類
            para.St_GoodsMGroup = tNedit_GoodsMGroup_St.GetInt();
            para.Ed_GoodsMGroup = tNedit_GoodsMGroup_Ed.GetInt();
            // ＢＬコード
            para.St_BLGoodsCode = tNedit_BLGoodsCode_St.GetInt();
            para.Ed_BLGoodsCode = tNedit_BLGoodsCode_Ed.GetInt();
        }

        #endregion 検索

        #region 最新情報取得
        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 最新情報取得処理を行います。</br>
        /// </remarks>
        private void Renewal()
        {
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№11 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            tComboEditor_TargetDivide.Focus();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№11 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // メッセージ表示
            DialogResult dialogResult = TMsgDisp.Show(
            this,
            emErrorLevel.ERR_LEVEL_INFO,
            this.Name,
            "画面情報はクリアされます。" + "\r\n" + "\r\n" +
            "よろしいですか？",
            0,
            MessageBoxButtons.YesNo,
            MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No) return;


            // 最新情報取得
            _guideControl.Renewal();

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                       "最新情報を取得しました。",
                       0,
                       MessageBoxButtons.OK,
                       MessageBoxDefaultButton.Button1);

            return;
        }

        #endregion

        #region チェック処理
        /// <summary>
        /// 検索条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索条件をチェックします。</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            try
            {
                // 1:拠点の場合のみ
                if ( (int)tComboEditor_TargetDivide.Value == 1 )
                {
                    // 拠点
                    if ( this.tEdit_SectionCodeAllowZero.DataText.Trim() == "" )
                    {
                        errMsg = "拠点を入力してください。";
                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (false);
                    }

                    string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                }

                //--------------------------------------------------
                // 大小比較
                //--------------------------------------------------

                // 得意先
                if ( CheckInputRange( tNedit_CustomerCode_St, tNedit_CustomerCode_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "得意先" );
                    this.tNedit_CustomerCode_St.Focus();
                    return (false);
                }
                // メーカー
                if ( CheckInputRange( tNedit_GoodsMakerCd_St, tNedit_GoodsMakerCd_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "メーカー" );
                    this.tNedit_GoodsMakerCd_St.Focus();
                    return (false);
                }
                // 商品中分類
                if ( CheckInputRange( tNedit_GoodsMGroup_St, tNedit_GoodsMGroup_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "商品中分類" );
                    this.tNedit_GoodsMGroup_St.Focus();
                    return (false);
                }
                // ＢＬコード
                if ( CheckInputRange( tNedit_BLGoodsCode_St, tNedit_BLGoodsCode_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "ＢＬコード" );
                    this.tNedit_BLGoodsCode_St.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 大小比較チェック処理
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <returns></returns>
        private bool CheckInputRange( TNedit stEdit, TNedit edEdit )
        {
            int stCode = stEdit.GetInt();
            int edCode = edEdit.GetInt();

            if ( stCode != 0 && 
                 edCode != 0 &&
                 stCode > edCode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// </remarks>
        public static bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:処理続行　False:処理中断)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return true;
            }

            // 画面情報比較　要否判定
            if (!this._needCompare)
            {
                return true;
            }

            // 画面情報比較
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            int status = Save();
                            if (status != 0)
                            {
                                return (false);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            return (_autoAnsItemStAcs.GetUpdateCountFromTable() == 0);
        }


        /// <summary>
        /// 新規追加行 編集済みチェック
        /// </summary>
        /// <returns>ステータス(-1:未入力項目あり　0:必須項目入力済み  1:全項目未入力)</returns>
        /// <remarks>
        /// <br>Note        : 新規追加行に編集が行われているか判定する</br>
        /// </remarks>
        private int CheckRowNewAdd(UltraGridRow row)
        {
            int ret = 1;

            string sectionCode = row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Text;
            int customerCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Text, out customerCode);
            int goodsMGroupCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text, out goodsMGroupCode);
            int blGoodsCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Text, out blGoodsCode);
            int goodsMakerCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Text, out goodsMakerCode);
            int priorityOrder = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Text, out priorityOrder);

            // 全て未入力の時はチェック対象外
            if (sectionCode.Length == 0
                && customerCode == 0
                && row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim().Length == 0
                && blGoodsCode == 0
                && goodsMakerCode == 0
                && priorityOrder == 0
               )
            {
                return ret;
            }

            // 入力必須項目に入力されているか
            // 拠点コード・得意先コードが未入力はエラー
            if (sectionCode.Length == 0 && customerCode == 0)
            {
                ret = -1;
            }
            // 商品中分類未入力はエラー
            else if (row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim().Equals(string.Empty))
            {
                ret = -1;
            }
            // メーカーコード未入力はエラー
            else if (goodsMakerCode == 0)
            {
                ret = -1;
            }
            // 自動回答区分が「する（優先順位）」の時、優先順位が未入力はエラー
            else if ((int)row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority
                     && priorityOrder == 0)
            {
                ret = -1;
            }
            else
            {
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// 保存前の各種チェックを行う
        /// ・新規追加行 重複チェック
        /// ・新規追加行　拠点、得意先の入力状態チェック
        /// </summary>
        /// <returns>ステータス(true:エラー無し  false:エラー有り)</returns>
        /// <remarks>
        /// </remarks>
        private bool CheckBeforeSave(out string msg)
        {
            bool ret = true;
            msg = string.Empty;

            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                string filter = string.Empty;

                #region 新規追加行
                // 新規追加行
                if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value).Equals((int)AutoAnsItemStAcs.NewAddRowDiv.New)
                    && IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value).Equals((int)AutoAnsItemStAcs.NewAddRowAllowSave.Yes))
                {
                    #region 新規追加行　拠点、得意先の入力状態チェック
                    // 拠点コード、得意先コード未入力はエラー
                    if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim())
                        && IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value).Equals(0))
                    {
                        msg = "拠点コードか得意先コードを入力してください。\n";
                        msg += "行№：" + row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString();
                        ret = false;
                        break;
                    }
                    // 拠点コード、得意先コードの同時入力はエラー
                    else if (!string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim())
                        && !IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value).Equals(0))
                    {
                        msg = "拠点コードと得意先コードの同時入力はできません。\n";
                        msg += "行№：" + row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString();
                        ret = false;
                        break;
                    }
                    #endregion

                    #region 新規追加行　必須入力チェック
                    if (!CheckRowNewAdd(row).Equals(0))
                    {
                        msg = string.Format("必須項目が入力されていません。\n行№{0}",
                                            row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString().Trim());
                        ret = false;
                        break;
                    }
                    #endregion

                    #region 新規追加行重複チェック
                    filter = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11} AND {12}<{13}",
                                          AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_GOODSMGROUP,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_BLGOODSCODE,
                                          IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value).ToString(),
                                          AutoAnsItemStAcs.ct_COL_GOODSMAKERCD,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString());
                    int rowCount = _autoAnsItemStAcs.GetRowForMaintenance(filter);

                    // 重複している時エラー
                    if (rowCount > 0)
                    {
                        msg = string.Format("行№{0}が重複しています。",
                                            row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString().Trim());
                        ret = false;
                        break;
                    }
                    #endregion

                }
                #endregion

                #region 優先順位の入力チェック
                if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value).Equals((int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                     && IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value).Equals(0))
                {
                    msg = string.Format("優先順位が入力されていません。\n行№{0}",
                                        row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString().Trim());
                    ret = false;
                    break;
                }
                #endregion

                #region 優先順位重複チェック
                // 自動回答区分：優先順位　以外は対象外
                if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value).Equals((int)AutoAnsItemStAcs.AutoAnswerDiv.Priority))
                {
                    // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    filter = string.Empty;

                    if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                    {
                        filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                               AutoAnsItemStAcs.ct_COL_CUSTOMERCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    }
                    else
                    {
                        filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                               AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    }

                    int retCount = 0;
                    List<AutoAnsItemSt> retList = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);

                    if (retList != null && retList.Count > 1)
                    {
                        msg = "優先順位が重複しています。\n";
                        if (!string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                        {
                            msg += "拠点：" + row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
                        }
                        else
                        {
                            msg += "得意先：" + row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString().Trim();
                        }
                        msg += "，商品中分類：" + row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString().Trim();
                        msg += "，BLコード：" + row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString().Trim();
                        ret = false;
                        break;
                    }
                    // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    // --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№63 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region 削除
                    //bool isSection = false;
                    //filter = string.Empty;

                    //if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                    //{
                    //    filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                    //                           AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    //}
                    //else
                    //{
                    //    isSection = true;
                    //    filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                    //                           AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    //}

                    //int retCount = 0;
                    //List<AutoAnsItemSt> retList = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);

                    //if (retList != null && retList.Count > 1)
                    //{
                    //    msg = "優先順位が重複しています。\n";
                    //    if (isSection)
                    //    {
                    //        msg += "拠点：" + row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
                    //    }
                    //    else
                    //    {
                    //        msg += "，得意先：" + row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString().Trim();
                    //    }
                    //    msg += "，商品中分類：" + row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString().Trim();
                    //    msg += "，BLコード：" + row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString().Trim();
                    //    ret = false;
                    //    break;
                    //}
                    #endregion
                    AutoAnsItemSt autoAnsItemSt = new AutoAnsItemSt();                                          // レコード取得
                    autoAnsItemSt.EnterpriseCode = this._enterpriseCode;                                        // 企業コード
                    autoAnsItemSt.SectionCode = row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();// 拠点コード
                    autoAnsItemSt.CustomerCode = (int)row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value;    // 得意先コード
                    autoAnsItemSt.GoodsMGroup = (int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value;      // 商品中分類コード
                    autoAnsItemSt.BLGoodsCode = (int)row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value;      // ＢＬコード
                    autoAnsItemSt.GoodsMakerCd = (int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value;    // メーカーコード
                    autoAnsItemSt.PrmSetDtlNo2 = (int)row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value;    // 種別コード
                    autoAnsItemSt.PriorityOrder = (int)row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value;  // 優先順位
                    List<AutoAnsItemSt> _autoAnsItemStList = new List<AutoAnsItemSt>();
                    int retStatus = _autoAnsItemStAcs.Read2(autoAnsItemSt, ref _autoAnsItemStList, true);
                    if (retStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        msg = string.Empty;
                        // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        foreach (AutoAnsItemSt autoAnsItem in _autoAnsItemStList)
                        {
                            // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            filter = string.Empty;

                            if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                            {
                                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                                       AutoAnsItemStAcs.ct_COL_CUSTOMERCODE.ToString(),
                                                       autoAnsItem.CustomerCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                                       autoAnsItem.GoodsMGroup,
                                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                                       autoAnsItem.BLGoodsCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                                       autoAnsItem.GoodsMakerCd);
                            }
                            else
                            {
                                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                                       AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                                                       autoAnsItem.SectionCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                                       autoAnsItem.GoodsMGroup,
                                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                                       autoAnsItem.BLGoodsCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                                       autoAnsItem.GoodsMakerCd);
                            }

                            // 画面に表示されていれば飛ばす
                            List<AutoAnsItemSt> retList2 = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);
                            if (retList2.Count > 0)
                            {
                                continue;
                            }
                            // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                            if ((autoAnsItem.GoodsMakerCd != autoAnsItemSt.GoodsMakerCd) || (autoAnsItem.PrmSetDtlNo2 != autoAnsItemSt.PrmSetDtlNo2))
                            {
                                // メーカー又は種別が違う（自レコード以外）
                                if (autoAnsItem.PriorityOrder == autoAnsItemSt.PriorityOrder)
                                {
                                    msg = "優先順位が重複しています。\n";
                                    if (!string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                                    {
                                        msg += "拠点：" + row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
                                    }
                                    else
                                    {
                                        msg += "得意先：" + row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString().Trim();
                                    }
                                    msg += "，商品中分類：" + row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString().Trim();
                                    msg += "，BLコード：" + row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString().Trim();
                                    ret = false;
                                    break;
                                }
                            }
                        }
                        // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        if (msg != string.Empty)
                        {
                            break;
                        }
                        // ADD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№80 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    // --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№63 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            #endregion

            return ret;
        }

        /// <summary>
        /// 新規追加行 拠点コード入力チェック
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ステータス(True:エラーなし　False:エラーあり)</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードの入力チェックを行います</br>
        /// </remarks>
        private bool CheckRowSectionCode(ref string sectionCode, out string sectionName)
        {
            bool ret = true;
            sectionName = string.Empty;

            // 拠点コード存在チェック
            if (!string.IsNullOrEmpty(sectionCode))
            {
                if (!GetSectionName(sectionCode, out sectionName))
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "拠点コードが存在しません。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }

                sectionCode = sectionCode.Trim().PadLeft(2, '0');
            }
            return ret;
        }

        /// <summary>
        /// 新規追加行 得意先コード入力チェック
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>ステータス(True:エラーなし　False:エラーあり)</returns>
        /// <remarks>
        /// <br>Note        : 得意先コードの入力チェックを行います</br>
        /// </remarks>
        private bool CheckRowCustomerCode(int customerCode, out string customerName)
        {
            bool ret = true;
            customerName = string.Empty;

            // 得意先コード存在チェック
            if (customerCode != 0)
            {
                if (!ReadCustomer(ref customerCode, out customerName))
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "得意先コードが存在しません。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// 新規追加行 商品中分類コード入力チェック
        /// </summary>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <returns>ステータス(True:エラーなし　False:エラーあり)</returns>
        /// <remarks>
        /// <br>Note        : 商品中分類コードの入力チェックを行います</br>
        /// </remarks>
        private bool CheckRowGoodsMGroup(ref string goodsMGroup, out string goodsMGroupName, out int goodsMGroupCode)
        {
            bool ret = true;
            goodsMGroupCode = 0;
            goodsMGroupName = string.Empty;

            // 商品中分類コード存在チェック
            if (!string.IsNullOrEmpty(goodsMGroup))
            {
                int.TryParse(goodsMGroup, out goodsMGroupCode);

                if (goodsMGroupCode == 0)
                {
                    goodsMGroup = "0000";
                    goodsMGroupName = "共通";
                }
                else
                {
                    if (!ReadGoodsMGroup(ref goodsMGroupCode, out goodsMGroupName))
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "商品中分類コードが存在しません。",
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        ret = false;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 新規追加行 ＢＬコード入力チェック
        /// </summary>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>ステータス(True:エラーなし　False:エラーあり)</returns>
        /// <remarks>
        /// <br>Note        : BLコードの入力チェックを行います</br>
        /// </remarks>
        private bool CheckRowBLCode(out int goodsMGroup, ref string blGoodsCode, out string blGoodsName, out int blGoodsCodeNum)
        {
            bool ret = true;
            blGoodsCodeNum = 0;
            blGoodsName = string.Empty;
            goodsMGroup = 0;

            int.TryParse(blGoodsCode, out blGoodsCodeNum);

            // BLコード存在チェック
            if (!string.IsNullOrEmpty(blGoodsCode))
            {
                if (blGoodsCodeNum == 0)
                {
                    blGoodsCode = "00000";
                    blGoodsName = "共通";
                }
                else
                {
                    if (!ReadBLCode(ref blGoodsCodeNum, out blGoodsName,out goodsMGroup))
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "ＢＬコードが存在しません。",
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        ret = false;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 新規追加行 メーカーコード入力チェック
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <returns>ステータス(True:エラーなし　False:エラーあり)</returns>
        /// <remarks>
        /// <br>Note        : メーカーコードの入力チェックを行います</br>
        /// </remarks>
        private bool CheckRowMakerCode(string goodsMakerCode, out string goodsMakerName)
        {
            bool ret = true;
            goodsMakerName = string.Empty;
            int makerCode = 0;
            int.TryParse(goodsMakerCode, out makerCode);

            // メーカーコード未入力時は何もしない
            if (string.IsNullOrEmpty(goodsMakerCode) || makerCode == 0)
            {
                return true;
            }

            // メーカーコード存在チェック
            if (!ReadMaker(ref makerCode, out goodsMakerName))
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "メーカーコードが存在しません。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// 新規追加行 種別コード入力チェック
        /// </summary>
        /// <param name="prmSetDtlNo2">種別コード</param>
        /// <returns>ステータス(True:エラーなし　False:エラーあり)</returns>
        /// <remarks>
        /// <br>Note        : 種別コードの入力チェックを行います</br>
        /// </remarks>
        private bool CheckRowPrmSetDtlNo2(string prmSetDtlNo2, string goodsMGroupCode, string goodsMakerCode, string blGoodsCode, out string prmSetDtlNo2Name, out int prmSetDtlNo2Num)
        {

            bool ret = true;
            prmSetDtlNo2Name = string.Empty;
            int goodsMGroup = 0;
            int makerCode = 0;
            int blCode = 0;
            prmSetDtlNo2Num = 0;

            int.TryParse(goodsMGroupCode, out goodsMGroup);
            int.TryParse(goodsMakerCode, out makerCode);
            int.TryParse(blGoodsCode, out blCode);
            int.TryParse(prmSetDtlNo2, out prmSetDtlNo2Num);

            // 商品中分類コード、メーカーコード、BLコードの指定がない場合、種別コードの入力はエラー
            if ((goodsMGroup == 0 || makerCode == 0 || blCode == 0) && prmSetDtlNo2Num != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "商品中分類、ＢＬコード、メーカーコードを入力してください。",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                ret = false;
            }

            // 種別コード存在チェック
            if (!string.IsNullOrEmpty(prmSetDtlNo2))
            {
                // 画面起動時に取得してある優良設定マスタを取得
                DataView dv = OfferPrimeSettingDataView;
                // 検索条件を設定
                string filter = PrimeSettingInfo.COL_PARTSMAKERCD + " = " + makerCode.ToString() + " AND " +
                                PrimeSettingInfo.COL_TBSPARTSCODE + " = " + blCode.ToString() + " AND " +
                                PrimeSettingInfo.COL_MIDDLEGENRECODE + " = " + goodsMGroup.ToString() + " AND " +
                                PrimeSettingInfo.COL_PRIMEKINDCODE + " = "  + prmSetDtlNo2Num.ToString() ;
                dv.RowFilter = filter;

                if (dv.Count == 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "種別コードが存在しません。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }
                else
                {
                    prmSetDtlNo2Name = dv[0][PrimeSettingInfo.COL_PRIMEKINDNAME].ToString();
                }

                // 同一メーカー内で種別コードが重複している時、エラー
                if (IsPrmSetDtlNo2Duplicate())
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "種別コードが重複しています。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }
            }
            return ret;
        }

        #endregion チェック処理

        #region グリッド設定
        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <param name="displayList">表示データリスト</param>
        /// <remarks>
        /// <br>Note        : グリッドの列を作成します。</br>
        /// </remarks>
        private void CreateGrid(ref UltraGrid uGrid)
        {
            uGrid.DataSource = null;

            // データソースとなるDataViewをアクセスクラスから取得
            DataView view = _autoAnsItemStAcs.DataViewForMstList;
            
            uGrid.DataSource = view;
           
            // 論理削除有無
            _autoAnsItemStAcs.ExcludeLogicalDeleteFromView = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

            // グリッドスタイル設定
            SetGridLayout( ref uGrid );

            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№3 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this.UpdateButtonToolEnabled();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№3 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// グリッドスタイル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドのスタイルを設定します。</br>
        /// </remarks>
        private void SetGridLayout(ref UltraGrid uGrid)
        {
            try
            {
                uGrid.BeginUpdate();
                ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

                // セルスタイル
                for (int index = 0; index < columns.Count; index++)
                {
                    columns[index].CellAppearance.BackColorDisabled = Color.White;
                    columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                    columns[index].Hidden = true;
                }

                int visiblePosition = 0;

                int selectValue;
                if ( this.tComboEditor_TargetDivide.Value != null )
                {
                    selectValue = (int)this.tComboEditor_TargetDivide.Value;
                }
                else
                {
                    selectValue = 0;
                }

                # region [各カラムの設定]

                // 行№
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Hidden = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№16 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Caption = "行№";
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Caption = "№";
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№16 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Appearance.TextHAlign = HAlign.Right;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.TextHAlign = HAlign.Right;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№15 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                //columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                //columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№15 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellActivation = Activation.Disabled;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellActivation = Activation.NoEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Width = widthNo;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.VisiblePosition = visiblePosition++;

                // 削除日
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Hidden = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Caption = "削除日";
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.ForeColor = Color.Red;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].CellActivation = Activation.NoEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Width = 100;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Width = widthDelete;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = visiblePosition++;

                // 拠点コード
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Hidden = (selectValue == 2);
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Caption = "拠点";
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Width = widthSection;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.VisiblePosition = visiblePosition++;

                // 得意先コード
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Hidden = (selectValue == 1);
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Caption = "得意先";
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Width = 80;
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Width = widthCustomer;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Format = GetCustomerFormat();
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.VisiblePosition = visiblePosition++;

                // 商品中分類コード
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Caption = "商品中分類";
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Width = 100;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Width = widthGoodsMGroup;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.VisiblePosition = visiblePosition++;

                // 商品中分類名称
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Caption = "名称";
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Width = 150;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Width = widthGoodsMGroupName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.VisiblePosition = visiblePosition++;

                // BLコード
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Caption = "BLｺｰﾄﾞ";
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Width = 60;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Width = widthBlCode;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.VisiblePosition = visiblePosition++;

                // BLコード名称
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Caption = "名称";
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Width = 150;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Width = widthBlCodeName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.VisiblePosition = visiblePosition++;

                // 商品メーカーコード
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Caption = "ﾒｰｶｰ";
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Width = widthMaker;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Format = GetMakerFormat();
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.VisiblePosition = visiblePosition++;

                // 商品メーカー名称
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Caption = "名称";
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Width = 150;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Width = widthMakerName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.VisiblePosition = visiblePosition++;

                // 種別
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Caption = "種別";
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Width = widthType;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.VisiblePosition = visiblePosition++;

                // 種別名称
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Caption = "名称";
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width = 100;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width = widthTypeName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.VisiblePosition = visiblePosition++;

                // 自動回答区分
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Caption = "自動回答区分";
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.ForeColorDisabled = Color.Black;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width = 130;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width = widthAutoAnsDiv;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(0);
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.VisiblePosition = visiblePosition++;

                uGrid_Details.CellListSelect += null;
                uGrid_Details.CellListSelect += new CellEventHandler(this.uGrid_Details_CellListSelect);


                // 優先順位
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Caption = "優先順位";
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Width = 80;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Width = widthPriority;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.VisiblePosition = visiblePosition++;

                # endregion

                # region [セル結合設定]
                List<string> colNameList = new List<string>( new string[] 
                                            { 
                                                AutoAnsItemStAcs.ct_COL_SECTIONCODE, 
                                                AutoAnsItemStAcs.ct_COL_CUSTOMERCODE, 
                                                AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME,
                                                AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                AutoAnsItemStAcs.ct_COL_BLGOODSNAME,
                                                AutoAnsItemStAcs.ct_COL_GOODSMAKERCD,
                                                AutoAnsItemStAcs.ct_COL_MAKERNAME,
                                            });
                
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();
                margedCellAppearance.BackColor = Color.Lavender;
                margedCellAppearance.BackColor2 = Color.Lavender;

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearanceを強制的に統一する（行№は除く）
                    if (!columns[colName].Key.Trim().Equals(AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY.Trim()))
                    {
                        columns[colName].MergedCellAppearance = margedCellAppearance;
                        columns[colName].CellAppearance.BackColor = margedCellAppearance.BackColor;
                        columns[colName].CellAppearance.BackColor2 = margedCellAppearance.BackColor2;
                        columns[colName].CellAppearance.TextVAlign = VAlign.Top;
                    }

                    // セル結合設定
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }
                
                // 拠点セル結合 
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE );

                // 得意先セル結合 
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE, 
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE );

                // 商品中分類セル結合
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY);

                // 商品中分類名称セル結合
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME);

                // BLコードセル結合
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY);

                // BLコード名称セル結合
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSNAME);

                // メーカーセル結合
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMAKERCD);

                // メーカー名称セル結合
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMAKERCD,
                                                    AutoAnsItemStAcs.ct_COL_MAKERNAME);
                # endregion

                // --- ADD 2012/11/22 吉岡 2012/12/12配信分 システムテスト障害№77 --------->>>>>>>>>>>>>>>>>>>>>>>>
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Hidden = true;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Hidden = true;
                // --- ADD 2012/11/22 吉岡 2012/12/12配信分 システムテスト障害№77 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        # region [グリッドセル結合判定クラス]
        /// <summary>
        /// グリッドセル結合判定クラス(カスタマイズ)
        /// </summary>
        public class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>結合条件セルリスト</summary>
            private List<string> _joinColList;
            /// <summary>
            /// 結合条件セルリスト
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator( params string[] joinCols )
            {
                _joinColList = new List<string>( joinCols );
            }

            /// <summary>
            /// セル結合判定処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged( Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column )
            {
                foreach ( string joinColName in JoinColList )
                {
                    if ( !EqualCellValue( row1, row2, joinColName ) ) return false;
                }
                return true;
            }
            /// <summary>
            /// セルValue比較処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue( Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName )
            {
                if (columnName == AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV)
                {
                    if ((int)row1.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                    {
                        return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
                }
            }
        }
        # endregion

        # region [コードフォーマット取得処理]
        /// <summary>
        /// 得意先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCustomerFormat()
        {
            return GetFormat( "tNedit_CustomerCode" );
        }
        /// <summary>
        /// メーカーコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetMakerFormat()
        {
            return GetFormat( "tNedit_GoodsMakerCd" );
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLCodeFormat()
        {
            return GetFormat( "tNedit_BLGoodsCode" );
        }
        /// <summary>
        /// 中分類コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetGoodsMGroupFormat()
        {
            return GetFormat("tNedit_GoodsMGroup");
        }
        /// <summary>
        /// 汎用フォーマット取得処理
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetFormat( string editName )
        {
            string format = string.Empty;

            UiSet uiset;
            this.uiSetControl1.ReadUISet( out uiset, editName );
            if ( uiset != null )
            {
                format = string.Format( "{0};-{0};''", new string( '0', uiset.Column ) );
            }

            return format;
        }
        # endregion

        /// <summary>
        /// グリッド行設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッド行に対して各種設定をします。</br>
        /// </remarks>
        public void SettingGridRows(ref UltraGrid uGrid)
        {
            uGrid.BeginUpdate();

            try
            {
                foreach ( UltraGridRow row in uGrid.Rows)
                {
                    // 行№（表示順）の設定
                    row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value = row.Index + 1;
                    // 優先順位は自動回答区分が「する（優先順位）」の時のみ編集可能
                    if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value) == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.AllowEdit; // 優先順位
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                    }
                    else
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.NoEdit; // 優先順位
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                    }

                    // 新規追加行の時は結合状態を解除・編集可能状態にする
                    if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value) == (int)AutoAnsItemStAcs.NewAddRowDiv.New)
                    {
                        for (int index = 0; index < row.Cells.Count; index++)
                        {
                            // CellAppearanceをもとに戻す（行№は除く）
                            if (!row.Cells[index].Column.Key.Trim().Equals(AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY.Trim()))
                            {
                                row.Cells[index].Appearance.BackColor = Color.White;
                                row.Cells[index].Appearance.BackColor2 = Color.White;
                            }
                        }
                        // 自動回答区分リスト設定
                        row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value));
                    }
                    else
                    {
                        if (row.Cells[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Value.ToString().Trim() == string.Empty)
                        {
                            // 編集不可
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Activation = Activation.NoEdit;  // 拠点コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Activation = Activation.NoEdit; // 得意先コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Activation = Activation.NoEdit; // 商品中分類コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Activation = Activation.NoEdit; // BLコード
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Activation = Activation.NoEdit; // ﾒｰｶｰｺｰﾄﾞ
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Activation = Activation.NoEdit; // 種別コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Appearance = null;
                            // 通常：編集可
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Activation = Activation.AllowEdit; // 自動回答区分
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                        }
                        else
                        {
                            // 編集不可
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Activation = Activation.NoEdit;  // 拠点コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Activation = Activation.NoEdit; // 得意先コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Activation = Activation.NoEdit; // 商品中分類コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Activation = Activation.NoEdit; // BLコード
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Activation = Activation.NoEdit; // ﾒｰｶｰｺｰﾄﾞ
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Activation = Activation.NoEdit; // 種別コード
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Appearance = null;
                            // 削除済み：編集不可
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Activation = Activation.NoEdit; // 自動回答区分
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Appearance.BackColor = Color.LightGray;
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Appearance.BackColor = Color.LightGray;
                        }
                    }
                }
                uGrid.Refresh();
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// グリッド行設定処理（行№のみ）
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッド行に対して行№のみ設定</br>
        /// </remarks>
        public void SettingGridRowsRowNumber(ref UltraGrid uGrid)
        {
            uGrid.BeginUpdate();

            try
            {
                for (int rowIndex = 0; rowIndex < uGrid.Rows.Count; rowIndex++)
                {
                    CellsCollection cells = uGrid.Rows[rowIndex].Cells;

                    // 行№（表示順）の設定
                    cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value = rowIndex + 1;
                }
                uGrid.Refresh();
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// 種別行設定処理
        /// </summary>
        /// <param name="cell">アクティブセル情報</param>
        /// <remarks>
        /// <br>Note        : 種別コードの設定をします。</br>
        /// </remarks>
        private int SetPrmSetDtlNo2(UltraGridCell cell)
        {
            string sectionCode = string.Empty;
            int customerCode = 0;
            int goodsMGroup = 0;
            int makerCode = 0;
            int blCode = 0;
            int prmSetDtlNo2Num = 0;
            string filter = string.Empty;
            string filterBefore = string.Empty;
            string message = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(), out customerCode);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(), out goodsMGroup);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(), out makerCode);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(), out blCode);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value.ToString(), out prmSetDtlNo2Num);

            // 商品中分類、BLコード、メーカーコードが変更されていない時、以降の処理を行わない
            if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString() == this._goodsMGroup &&
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString() == this._blGoodsCode &&
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString() == this._goodsMakerCode)
            {
                return status;
            }
            // 商品中分類、BLコード、メーカーコードに未入力の項目がある場合、以降の処理を行わない
            if ((goodsMGroup == 0 || cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim() == "0000") ||
                (blCode == 0 || cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim() == "00000") ||
                 makerCode == 0
               )
            {
                return status;
            }

            // 優良設定マスタの検索条件を設定
            filter = PrimeSettingInfo.COL_PARTSMAKERCD + " = " + makerCode.ToString() + " AND " +
                            PrimeSettingInfo.COL_TBSPARTSCODE + " = " + blCode.ToString() + " AND " +
                            PrimeSettingInfo.COL_MIDDLEGENRECODE + " = " + goodsMGroup.ToString();

            // 変更前入力行削除条件
            filterBefore = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11}",
                                         AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(), this._sectionCode.Trim(),
                                         AutoAnsItemStAcs.ct_COL_CUSTOMERCODE.ToString(),GetIntNullZero(this._customerCode),
                                         AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(), GetIntNullZero(this._goodsMGroup),
                                         AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(), GetIntNullZero(this._blGoodsCode),
                                         AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(), GetIntNullZero(this._goodsMakerCode),
                                         AutoAnsItemStAcs.ct_COL_NEWADDROWDIV.ToString(), (int)AutoAnsItemStAcs.NewAddRowDiv.New
                                        );

            // 行追加処理            
            status = this._autoAnsItemStAcs.RowInsert(filter, filterBefore, sectionCode, customerCode, makerCode, goodsMGroup, blCode);

            // 種別コードが存在しない時、種別コード・名称をクリアする
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value = 0;
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2_SORT].Value = 0;
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value = string.Empty;
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Value = string.Empty;
            }

            return status;
        }

        #endregion グリッド設定

        #region セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Int型</returns>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// </remarks>
        public int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (int)cellValue;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>String型</returns>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return int.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Double型</returns>
        /// <remarks>
        /// <br>Note        : セル値をDouble型に変換します。</br>
        /// </remarks>
        public double DoubleObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (double)cellValue;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Bool型</returns>
        /// <remarks>
        /// <br>Note        : セル値をBool型に変換します。</br>
        /// </remarks>
        public bool BoolObjToBool(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return (false);
            }
            else
            {
                return (bool)cellValue;
            }
        }
        #endregion セル値変換

        #region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._autoAnsItemStAcs,	    // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        #endregion ■ Private Methods

        #region ■ Control Events

        #region ● Form イベント
        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// </remarks>
        private void PMKHN09701UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№27 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // this.Initial_Timer.Enabled = true;

            // 起動時のグリッドのチラつき防止の為、
            // Initial_Timer_Tickの処理をこちらへ移動しました。

            this.Initial_Timer.Enabled = false;

            // フォーカス設定
            this.tComboEditor_TargetDivide.Focus();

            // XMLデータ読込
            LoadStateXmlData();

            // グリッドのアクティブ行をクリア
            this.uGrid_Details.ActiveRow = null;

            // ボタン表示更新
            this.UpdateButtonToolEnabled();
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№27 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion

        #region ● ToolBar イベント
        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>
            GridWidthSave();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        this._closeFlg = true;

                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        int status = Save();

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 再検索
                            _needCompare = false;
                            this._extrInfo = null;
                            this.Search();
                            _needCompare = true;

                            // フォーカス設定
                            this.tEdit_SectionCodeAllowZero.Focus();
                        }
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        _extrInfo = null;
                        Search();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }
                        // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        #region
                        //// クリア処理
                        //ClearScreen();

                        //// アクセスクラス内のテーブルクリア
                        //_autoAnsItemStAcs.Clear();
                        #endregion
                        // アクセスクラス内のテーブルクリア
                        _autoAnsItemStAcs.Clear();
                        // クリア処理
                        ClearScreen();
                        // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        break;
                    }
                case "ButtonTool_Insert":
                    {
                        // （新規）編集ＵＩ表示
                        _editForm = new PMKHN09701UB( _autoAnsItemStAcs, _guideControl );
                        _editForm.RecordGuid = Guid.Empty;
                        _editForm.ShowDialog( this );

                        // 再検索
                        if (_editForm.IsSave)
                        {
                            this._extrInfo = null;
                            Search();
                        }

                        _editForm.Dispose();
                        _editForm = null;

                        break;
                    }
                case "ButtonTool_Edit":
                    {
                        // （編集）編集ＵＩ表示
                        _editForm = new PMKHN09701UB( _autoAnsItemStAcs, _guideControl );
                        _editForm.RecordGuid = this.GetRecordGuidFromGrid();
                        _editForm.ShowDialog( this );

                        // 再検索
                        if (_editForm.IsSave)
                        {
                            this._extrInfo = null;
                            Search();
                        }
                        _editForm.Dispose();
                        _editForm = null;
                        
                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        int displayMode = 0; 
                        // 論理削除
                        int status = this.LogicalDelete(out displayMode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (displayMode == 0)
                            {
                                // 再検索
                                this._extrInfo = null;
                                Search();
                            }
                            else
                            {
                                // グリッドデータ設定
                                CreateGrid(ref this.uGrid_Details);
                                // グリッド行カラー設定
                                SettingGridRows(ref this.uGrid_Details);
                                // 最終行の拠点コードをアクティブセルに設定
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                            }
                        }
                        break;
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                case "ButtonTool_Guide":
                    {
                        if (this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE]))
                        {
                            // 拠点
                            GuideSection();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE]))
                        {
                            // 得意先
                            GuideCustomer();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY]))
                        {
                            // 商品中分類
                            GuideGoodsMGroup();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY]))
                        {
                            // BLコード
                            GuideBLCode();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD]))
                        {
                            // メーカー
                            GuideMaker();
                        }
                        break;
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                case "ButtonTool_Renewal":
                    {
                        // 最新情報取得処理
                        Renewal();

                        break;
                    }
            }
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 行選択されたツールバーがクリックされた時に発生します。</br>
        /// </remarks>
        private int LogicalDelete(out int displayMode)
        {
            int status = 0;
            int deleteMode = 0;    // 削除モード 0:論理削除 1:データテーブルより削除
            int rowIndex = 0;
            AutoAnsItemSt autoAnsItemSt = null;
            // 選択中のレコードのGuidを取得
            Guid guid = this.GetRecordGuidFromGrid();
            displayMode = 0;  // 削除表示モード 0:再検索で表示 1:再検索しない

            // 取得できない時、新規追加行（データテーブルより削除）の行№を取得
            if (guid == Guid.Empty)
            {
                deleteMode = 1;
                rowIndex =this.GetRecordRowIndex();
            }

            if (deleteMode == 0)
            {
                // 削除対象レコードを取得(Guidより)
                autoAnsItemSt = _autoAnsItemStAcs.GetRecordForMaintenance(guid);
            }

            # region [削除済みチェック]
            if (deleteMode == 0 && autoAnsItemSt.LogicalDeleteCode != 0)
            {
                // 論理削除済み行ならメッセージ表示して終了

                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    "選択中のデータは既に削除されています",// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                return status;
            }
            # endregion

            # region [確認ダイアログ]
            // 削除確認ダイアログ
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "選択した行を削除しますか？",		// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result != DialogResult.OK)
            {
                return status;
            }
            # endregion

            string errMsg;

            if (deleteMode == 0)
            {
                ArrayList deleteList = new ArrayList();
                deleteList.Add(autoAnsItemSt);
                // 論理削除
                status = _autoAnsItemStAcs.LogicalDelete(ref deleteList, out errMsg);
            }
            else
            {
                // データテーブルより削除
                status = _autoAnsItemStAcs.LogicalDeleteRowIndex(ref rowIndex, out errMsg);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        displayMode = deleteMode;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            errMsg = "既に他端末より更新されています。";
                        }
                        else
                        {
                            errMsg = "既に他端末より削除されています。";
                        }

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "Save",
                                       errMsg,
                                       status,
                                       MessageBoxButtons.OK);

                        this.tEdit_SectionCodeAllowZero.Focus();
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                   "Save",
                                   "保存処理に失敗しました。",
                                   status,
                                   MessageBoxButtons.OK);

                        this.tEdit_SectionCodeAllowZero.Focus();
                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// グリッド選択中レコードからのGUID取得
        /// </summary>
        /// <returns></returns>
        private Guid GetRecordGuidFromGrid()
        {
            Guid guid = Guid.Empty;

            if ( uGrid_Details.ActiveCell != null )
            {
                guid = (Guid)uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_FILEHEADERGUID].Value;
            }

            return guid;
        }

        /// <summary>
        /// グリッド選択中レコードからの表示行№を取得
        /// </summary>
        /// <returns></returns>
        private int GetRecordRowIndex()
        {
            int rowIndex = 0;

            if (uGrid_Details.ActiveCell != null)
            {
                rowIndex = (int)uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value;
            }

            return rowIndex;
        }

        /// <summary>
        /// ガイド制御クラス最新情報取得後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideControl_AfterRenewal( object sender, EventArgs e )
        {
            // 拠点名称の更新（既にガイド制御クラスは最新情報取得しているので、最新名称になる）
            string sectionName;
            if (this.GetSectionName( this.tEdit_SectionCodeAllowZero.Text.Trim(), out sectionName ))
            {
                this.tEdit_SectionName.Text = string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()) ?
                    string.Empty : sectionName;
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = "00";
                this.tEdit_SectionName.Text = "全社";
            }

            // アクセスクラス最新情報取得
            this._autoAnsItemStAcs.Renewal();
        }
        /// <summary>
        /// データ更新後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoAnsItemStAcs_AfterTableUpdate( object sender, EventArgs e )
        {
            if ( _autoAnsItemStAcs.DataViewForMstList.Count > 0 )
            {
                // １件以上
                SetButtonToolEnabled( "ButtonTool_Save", true );
            }
            else
            {
                // 0件
                SetButtonToolEnabled( "ButtonTool_Save", false );
                SetButtonToolEnabled( "ButtonTool_Edit", false );
                SetButtonToolEnabled( "ButtonTool_Delete", false );
            }
        }
        /// <summary>
        /// ファンクションボタン有効・無効設定
        /// </summary>
        /// <param name="key"></param>
        /// <param name="enabled"></param>
        private void SetButtonToolEnabled( string key, bool enabled )
        {
            (this.tToolbarsManager_MainMenu.Tools[key] as ButtonTool).SharedProps.Enabled = enabled;
        }

        /// <summary>
        /// 次の"入力項目"を取得(ガイドボタン除く)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetNextEdit( Control currControl )
        {
            Control nextControl;

            // 次項目取得
            # region [次項目取得]
            switch ( currControl.Name )
            {
                case "tComboEditor_TargetDivide":
                    nextControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_CustomerCode_St;
                    break;
                case "tNedit_CustomerCode_St":
                    nextControl = tNedit_CustomerCode_Ed;
                    break;
                case "tNedit_CustomerCode_Ed":
                    nextControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
                    nextControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    nextControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    nextControl = tNedit_BLGoodsCode_Ed;
                    break;
                case "tNedit_BLGoodsCode_Ed":
                    nextControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    nextControl = tNedit_GoodsMakerCd_Ed;
                    break;
                case "tNedit_GoodsMakerCd_Ed":
                    nextControl = uGrid_Details;
                    break;
                default:
                    nextControl = null;
                    break;
            }
            # endregion

            if ( nextControl != null )
            {
                // 入力不可なら再帰的に取得
                if ( !nextControl.Enabled || !nextControl.Visible )
                {
                    nextControl = GetNextEdit( nextControl );
                }
            }

            // 返却
            return nextControl;
        }

        /// <summary>
        /// 前の"入力項目"を取得(ガイドボタン除く)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetPrevEdit( Control currControl )
        {
            Control prevControl;

            // 前項目取得
            # region [前項目取得]
            switch ( currControl.Name )
            {
                case "tNedit_GoodsMakerCd_Ed":
                    prevControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    prevControl = tNedit_BLGoodsCode_Ed;
                    break;
                case "tNedit_BLGoodsCode_Ed":
                    prevControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    prevControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    prevControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
                    prevControl = tNedit_CustomerCode_Ed;
                    break;
                case "tNedit_CustomerCode_Ed":
                    prevControl = tNedit_CustomerCode_St;
                    break;
                case "tNedit_CustomerCode_St":
                    prevControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    prevControl = tComboEditor_TargetDivide;
                    break;
                case "tComboEditor_TargetDivide":
                    prevControl = tNedit_BLGoodsCode_St;
                    break;
                default:
                    prevControl = null;
                    break;
            }
            # endregion

            if ( prevControl != null )
            {
                // 入力不可なら再帰的に取得
                if ( !prevControl.Enabled || !prevControl.Visible )
                {
                    prevControl = GetPrevEdit( prevControl );
                }
            }

            // 返却
            return prevControl;
        }

        #endregion ToolBar イベント

        #region ● Button イベント
        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._guideControl.SecInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();
                    
                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// </remarks>
        private void uButton_CustomerCode_St_Click( object sender, EventArgs e )
        {
            // ガイド表示
            DialogResult result = _guideControl.CustomerSearchForm.ShowDialog();
            if ( result == DialogResult.OK && _guideControl.CustomerGuideRet != null )
            {
                // 結果セット
                if ( sender == this.uButton_CustomerCode_St )
                {
                    // 開始
                    tNedit_CustomerCode_St.SetInt( _guideControl.CustomerGuideRet.CustomerCode );
                }
                else if ( sender == this.uButton_CustomerCode_Ed )
                {
                    // 終了
                    tNedit_CustomerCode_Ed.SetInt( _guideControl.CustomerGuideRet.CustomerCode );
                }

                // 次フォーカス
                this.SelectNextControl( (Control)sender, true, true, true, true );
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// </remarks>
        private void uButton_GoodsMGroup_St_Click( object sender, EventArgs e )
        {
            GoodsGroupU goodsMGroup;

            // ガイド起動
            int status = this._guideControl.GoodsAcs.ExecuteGoodsMGroupGuid( this._enterpriseCode, out goodsMGroup );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if (sender == uButton_GoodsMGroup_St)
                {
                    // 開始
                    tNedit_GoodsMGroup_St.SetInt( goodsMGroup.GoodsMGroup );
                }
                else if ( sender == uButton_GoodsMGroup_Ed )
                {
                    // 終了
                    tNedit_GoodsMGroup_Ed.SetInt( goodsMGroup.GoodsMGroup );
                }

                // 次フォーカス
                this.SelectNextControl( (Control)sender, true, true, true, true );
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// </remarks>
        private void uButton_BLGoodsCode_St_Click( object sender, EventArgs e )
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            // ガイド起動
            int status = _guideControl.BLGoodsCdAcs.ExecuteGuid( this._enterpriseCode, out bLGoodsCdUMnt );
            if ( status == 0 )
            {
                if ( sender == uButton_BLGoodsCode_St )
                {
                    // 開始
                    tNedit_BLGoodsCode_St.SetInt( bLGoodsCdUMnt.BLGoodsCode );

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
                else if ( sender == uButton_BLGoodsCode_Ed )
                {
                    // 終了
                    tNedit_BLGoodsCode_Ed.SetInt( bLGoodsCdUMnt.BLGoodsCode );

                    // 検索実行
                    if ( this.Search() == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        // 次フォーカス
                        this.SelectNextControl( (Control)sender, true, true, true, true );
                    }
                    else
                    {
                        this.tComboEditor_TargetDivide.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._guideControl.MakerAcs.ExecuteGuid( this._enterpriseCode, out makerUMnt );
                if (status == 0)
                {
                    if ( sender == uButton_GoodsMakerCd_St )
                    {
                        // 開始
                        this.tNedit_GoodsMakerCd_St.SetInt( makerUMnt.GoodsMakerCd );
                    }
                    else if ( sender == uButton_GoodsMakerCd_Ed )
                    {
                        // 終了
                        this.tNedit_GoodsMakerCd_Ed.SetInt( makerUMnt.GoodsMakerCd );
                    }

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion Button イベント

        #region ● uGrid_Details関連 イベント
        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            #region ■セルが選択されている場合
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
                
                // 編集中であった場合
                if (cell.IsInEditMode)
                {
                    // セルのスタイルにて判定
                    switch (this.uGrid_Details.ActiveCell.StyleResolved)
                    {
                        #region < テキストボックス・テキストボックス(ボタン付) >
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            {
                                switch (e.KeyData)
                                {
                                    // ←キー
                                    case Keys.Left:
                                        if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // →キー
                                    case Keys.Right:
                                        if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                }
                                break;
                            }
                        #endregion

                        #region < 上記以外のスタイル >
                        default:
                            {
                                switch (e.KeyData)
                                {
                                    // ←キー
                                    case Keys.Left:
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // →キー
                                    case Keys.Right:
                                        {
                                            // 入力チェックがＯＫか、自動回答区分が「する（優先順位）」の時、優先順位を入力可能にする
                                            if ((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].EditorResolved.Value == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                                            {
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.AllowEdit; // 優先順位
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                                            }
                                            else
                                            {
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.NoEdit; // 優先順位
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = string.Empty;
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = 0;
                                            }
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;

                                }
                                break;
                            }
                        #endregion
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 新規追加行が保存可能な状態かをチェックし、
        /// 可能な状態であれば新規追加行を追加する
        /// </summary>
        /// <param name="cell">対象セル</param>
        private void CheckNewAddRowAllowSave(Infragistics.Win.UltraWinGrid.UltraGridCell cell)
        {
            // 存在しない行インデックスの場合は何もしない
            if (cell.Row.Index < 0)
            {
                return;
            }

            // 新規追加行の時
            if (IntObjToInt(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value).Equals((int)AutoAnsItemStAcs.NewAddRowDiv.New))
            {
                if (CheckRowNewAdd(cell.Row).Equals(1))
                {
                    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = (int)AutoAnsItemStAcs.NewAddRowAllowSave.No;
                }
                else
                {
                    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = (int)AutoAnsItemStAcs.NewAddRowAllowSave.Yes;
                }
            }
            
            // ↓↓↓↓↓以下、最下行の場合のみ処理
            if (!cell.Row.Index.Equals(uGrid_Details.Rows.Count - 1))
            {
                return;
            }

            // 新規追加行の時
            if (IntObjToInt(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value).Equals((int)AutoAnsItemStAcs.NewAddRowDiv.New))
            {
                // 入力が行われていた場合は入力チェックを行う
                int ret = CheckRowNewAdd(cell.Row);
                if(ret.Equals(0))
                {
                    // 入力ありで未入力項目なし

                    // 行追加処理
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region
                    //int status = this._autoAnsItemStAcs.RowAdd();
                    //if (status == 0)
                    //{
                    //    // グリッドデータ設定
                    //    CreateGrid(ref this.uGrid_Details);
                    //    // グリッド行カラー設定
                    //    SettingGridRows(ref this.uGrid_Details);
                    //    // 最終行の拠点コードをアクティブセルに設定
                    //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                    //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                    //    return;
                    //}
                    #endregion
                    this._autoAnsItemStAcs.RowAdd();

                    // UPD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№81 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    //// グリッドデータ設定
                    //CreateGrid(ref this.uGrid_Details);
                    //// グリッド行カラー設定
                    //SettingGridRows(ref this.uGrid_Details);
                    //// 最終行の拠点コードをアクティブセルに設定
                    //this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                    #endregion
                    // グリッド行カラー設定
                    SettingGridRows(ref this.uGrid_Details);
                    // UPD 2012/11/26 吉岡 2012/12/12配信分 システムテスト障害№81 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            #region ●ActiveCellが拠点コードの場合
            if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_SECTIONCODE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ●ActiveCellが得意先コードの場合
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_CUSTOMERCODE)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ●ActiveCellが商品中分類コードの場合
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ●ActiveCellがBLコードの場合
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ●ActiveCellがメーカーコードの場合
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_GOODSMAKERCD)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ●ActiveCellが種別コードの場合
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ●ActiveCellが優先順位の場合
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№13 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // if (!KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№13 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルがアクティブ化した時に発生します。</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            UpdateButtonToolEnabled();
        }
        /// <summary>
        /// ボタンの有効・無効設定
        /// </summary>
        private void UpdateButtonToolEnabled()
        {
            if ( uGrid_Details.ActiveCell != null )
            {
                if (IntObjToInt(uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value) == (int)AutoAnsItemStAcs.NewAddRowDiv.New)
                {
                    // 新規追加行
                    SetButtonToolEnabled("ButtonTool_Edit", false);
                    SetButtonToolEnabled( "ButtonTool_Delete", false );
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    if (this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD]))
                    {
                        SetButtonToolEnabled("ButtonTool_Guide", true);
                    }
                    else
                    {
                        SetButtonToolEnabled("ButtonTool_Guide", false);
                    }
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                else
                {
                    SetButtonToolEnabled( "ButtonTool_Edit", true );
                    SetButtonToolEnabled( "ButtonTool_Delete", true );
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    SetButtonToolEnabled("ButtonTool_Guide", false);
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            else
            {
                // 行が選択されていない
                SetButtonToolEnabled( "ButtonTool_Edit", false );
                SetButtonToolEnabled( "ButtonTool_Delete", false );
                // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                SetButtonToolEnabled("ButtonTool_Guide", false);
                // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        // ADD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private bool uGridErrChk()
        {
            if (uGrid_Details.ActiveCell == null) return false;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            switch (cell.Column.Key)
            {
                #region ActiveCellが拠点コードの時
                case AutoAnsItemStAcs.ct_COL_SECTIONCODE:
                    {
                        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Text;
                        string sectionName = string.Empty;
                        // 編集が行われた時のみ処理を行う
                        if (this._sectionCode != sectionCode)
                        {
                            // 拠点コード入力チェック
                            if (!CheckRowSectionCode(ref sectionCode, out sectionName))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = this._sectionCode.Trim();
                                this.uGrid_Details.ActiveCell = cell;
                                return true;
                            }
                            // 拠点コード
                            if (!string.IsNullOrEmpty(sectionCode))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = sectionCode.Trim();
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONNM].Value = sectionName.Trim();
                            }
                        }

                        break;
                    }
                #endregion

                #region ActiveCellが得意先コードの時
                case AutoAnsItemStAcs.ct_COL_CUSTOMERCODE:
                    {
                        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Text;
                        int customerCode = 0;
                        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Text, out customerCode);
                        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = customerCode;
                        string customerName = string.Empty;

                        // 編集が行われた時のみ処理を行う
                        if (this._customerCode != customerCode)
                        {
                            // 得意先コードチェック
                            if (!CheckRowCustomerCode(customerCode, out customerName))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = this._customerCode;
                                return true;
                            }
                            if (!string.IsNullOrEmpty(customerName))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERNAME].Value = customerName;
                            }
                        }
                        break;
                    }
                #endregion

                #region ActiveCellが商品中分類コードの時
                case AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY:
                    {
                        string goodsMGroup = string.Empty;
                        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim().Length > 0)
                        {
                            goodsMGroup = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim()).ToString();
                        }
                        string goodsMGroupName = string.Empty;

                        // 商品中分類名称の取得
                        if (GoodsMGroupReadAndSet(goodsMGroup, this._goodsMGroup, cell))
                        {
                            return true;
                        }
                        break;
                    }
                #endregion

                #region ActiveCellがＢＬコードの時
                case AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY:
                    {
                        int goodsMGroup = 0;
                        int goodsMGroupOld = 0;
                        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text, out goodsMGroup);
                        goodsMGroupOld = goodsMGroup;

                        string blGoodsCode = string.Empty;
                        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Text.Trim().Length > 0)
                        {
                            blGoodsCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Text.Trim()).ToString();
                        }
                        string blGoodsName = string.Empty;
                        int blGoodsCodeNum = 0;

                        // 編集が行われた時のみ処理を行う
                        if (this._blGoodsCode != blGoodsCode)
                        {
                            // BLコード入力チェック
                            if (!CheckRowBLCode(out goodsMGroup, ref blGoodsCode, out blGoodsName, out blGoodsCodeNum))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = this._blGoodsCode;
                                return true;
                            }

                            // BLコード名称
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = blGoodsName.Trim();
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = blGoodsCodeNum;
                            if (blGoodsCode.Length > 0)
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = GetIntNullZero(blGoodsCode.Trim()).ToString("00000");
                            }
                        }

                        // 商品中分類コードが設定されたら、グリッドの商品中分類を更新
                        if (!goodsMGroup.Equals(0))
                        {
                            // 商品中分類 
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsMGroup;
                            // 商品中分類名称の取得
                            GoodsMGroupReadAndSet(goodsMGroup.ToString(), goodsMGroupOld.ToString(), cell);
                        }
                        break;
                    }
                #endregion

                #region ActiveCellがメーカーコードの時
                case AutoAnsItemStAcs.ct_COL_GOODSMAKERCD:
                    {
                        string goodsMakerCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Text;
                        string goodsMakerName = string.Empty;

                        // メーカーコード入力チェック
                        if (!CheckRowMakerCode(goodsMakerCode, out goodsMakerName))
                        {
                            int MakerCodeNum = 0;
                            int.TryParse(this._goodsMakerCode, out MakerCodeNum);
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = MakerCodeNum;
                            return true;
                        }

                        // メーカーコード名称
                        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = goodsMakerName.Trim();
                        if (!string.IsNullOrEmpty(goodsMakerName))
                        {
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                        }
                        else
                        {
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(0);
                        }
                        break;
                    }
                #endregion
            }
            return false;
        }
        // ADD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 ---------<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (uGrid_Details.ActiveCell == null) return;
            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (uGrid_Details.ActiveCell.Row.Index < 0) return;
            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            switch (cell.Column.Key)
            {
                // DEL 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //#region ActiveCellが拠点コードの時
                //case AutoAnsItemStAcs.ct_COL_SECTIONCODE:          
                //    {
                //        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();
                //        string sectionName = string.Empty;
                //        // 編集が行われた時のみ処理を行う
                //        if (this._sectionCode != sectionCode)
                //        {
                //            // 拠点コード入力チェック
                //            if (!CheckRowSectionCode(ref sectionCode, out sectionName))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = this._sectionCode.Trim();
                //                this.uGrid_Details.ActiveCell = cell;
                //                return;
                //            }
                //            // 拠点コード
                //            if (!string.IsNullOrEmpty(sectionCode))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = sectionCode.Trim();
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONNM].Value = sectionName.Trim();
                //            }
                //        }

                //        break;
                //    }
                //#endregion

                //#region ActiveCellが得意先コードの時
                //case AutoAnsItemStAcs.ct_COL_CUSTOMERCODE:         
                //    {
                //        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();
                //        int customerCode = 0;
                //        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(), out customerCode);
                //        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№23 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = customerCode;
                //        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№23 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //        string customerName = string.Empty;

                //        // 編集が行われた時のみ処理を行う
                //        if (this._customerCode != customerCode)
                //        {
                //            // 得意先コードチェック
                //            if (!CheckRowCustomerCode(customerCode, out customerName))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = this._customerCode;
                //                return;
                //            }
                //            if (!string.IsNullOrEmpty(customerName))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERNAME].Value = customerName;
                //            }
                //        }
                //        break;
                //    }
                //#endregion

                //#region ActiveCellが商品中分類コードの時
                //case AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY:   
                //    {
                //        string goodsMGroup = string.Empty;
                //        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim().Length > 0)
                //        {
                //            goodsMGroup = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim()).ToString();
                //        }
                //        string goodsMGroupName = string.Empty;

                //        // 商品中分類名称の取得
                //        GoodsMGroupReadAndSet(goodsMGroup, this._goodsMGroup, cell);
                //        break;
                //    }
                //#endregion

                //#region ActiveCellがＢＬコードの時
                //case AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY:   
                //    {
                //        int goodsMGroup = 0;
                //        int goodsMGroupOld = 0;
                //        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString(), out goodsMGroup);
                //        goodsMGroupOld = goodsMGroup;

                //        string blGoodsCode = string.Empty;
                //        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim().Length > 0)
                //        {
                //            blGoodsCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim()).ToString();
                //        }
                //        string blGoodsName = string.Empty;
                //        int blGoodsCodeNum = 0;

                //        // 編集が行われた時のみ処理を行う
                //        if (this._blGoodsCode != blGoodsCode)
                //        {
                //            // BLコード入力チェック
                //            if (!CheckRowBLCode(out goodsMGroup, ref blGoodsCode, out blGoodsName, out blGoodsCodeNum))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = this._blGoodsCode;
                //                return;
                //            } 

                //            // BLコード名称
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = blGoodsName.Trim();
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = blGoodsCodeNum;
                //            if (blGoodsCode.Length > 0)
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = GetIntNullZero(blGoodsCode.Trim()).ToString("00000");
                //            }
                //        }

                //        // 商品中分類コードが設定されたら、グリッドの商品中分類を更新
                //        if (!goodsMGroup.Equals(0))
                //        {
                //            // 商品中分類 
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsMGroup;
                //            // 商品中分類名称の取得
                //            GoodsMGroupReadAndSet(goodsMGroup.ToString(), goodsMGroupOld.ToString(), cell);
                //        }
                //        break;
                //    }
                //#endregion

                //#region ActiveCellがメーカーコードの時
                //case AutoAnsItemStAcs.ct_COL_GOODSMAKERCD:          
                //    {
                //        string goodsMakerCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString();
                //        string goodsMakerName = string.Empty;
                        
                //        // メーカーコード入力チェック
                //        if (!CheckRowMakerCode(goodsMakerCode, out goodsMakerName))
                //        {
                //            int MakerCodeNum = 0;
                //            int.TryParse(this._goodsMakerCode, out MakerCodeNum);
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = MakerCodeNum;
                //            return;
                //        }

                //        // メーカーコード名称
                //        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = goodsMakerName.Trim();
                //        if (!string.IsNullOrEmpty(goodsMakerName))
                //        {
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                //        }
                //        else
                //        {
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(0);
                //        }
                //        break;
                //    }
                //#endregion
                #endregion 旧ソース
                // DEL 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 ---------<<<<<<<<<<<<<<<<<<<<<

                #region ActiveCellが優先順位の時
                case AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY: 
                    {
                        int autoAnswerDiv = (int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value;
                        string priorityOrder = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value.ToString();
                        int priorityOrderNum = 0;

                        // 編集が行われた時のみ処理を行う
                        if (this._priorityOrder != priorityOrder)
                        {
                            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№4 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (int.TryParse(priorityOrder, out priorityOrderNum))
                            //{
                            //    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = priorityOrderNum;
                            //}
                            int.TryParse(priorityOrder, out priorityOrderNum);
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = priorityOrderNum;
                            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№4 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        break;
                    }
                #endregion
            }

            // 種別コード設定
            if (SetPrmSetDtlNo2(cell) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // グリッドデータ設定
                CreateGrid(ref this.uGrid_Details);
                // グリッド行カラー設定
                SettingGridRows(ref this.uGrid_Details);

                this.uGrid_Details.Rows[rowIndex].Activate();
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
            }
            else
            {
                SettingGridRowsRowNumber(ref this.uGrid_Details);
            }

            // 新規追加行処理
            CheckNewAddRowAllowSave(cell);
        }

        /// <summary>
        /// 商品中分類名称の取得とグリッドへの設定
        /// </summary>
        /// <param name="goodsMGroup">変更後商品中分類</param>
        /// <param name="goodsMGroupOld">変更前商品中分類</param>
        /// <param name="cell">対象セル</param>
        // UPD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private void GoodsMGroupReadAndSet(string goodsMGroup, string goodsMGroupOld, UltraGridCell cell)
        private bool GoodsMGroupReadAndSet(string goodsMGroup, string goodsMGroupOld, UltraGridCell cell)
        // UPD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            string goodsMGroupName = string.Empty;
            int goodsMGroupNum = 0;

            // 編集が行われた時のみ処理を行う
            if (goodsMGroup != goodsMGroupOld)
            {
                // 商品中分類コードチェック
                if (!CheckRowGoodsMGroup(ref goodsMGroup, out goodsMGroupName, out goodsMGroupNum))
                {
                    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = goodsMGroupOld;
                    // UPD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //return;
                    return true;
                    // UPD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                // 商品中分類名称
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Value = goodsMGroupName.Trim();
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsMGroupNum;
            }

            if (goodsMGroup.Length > 0)
            {
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = GetIntNullZero(goodsMGroup.Trim()).ToString("0000");
            }
            // ADD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            return false;
            // ADD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// グリッドセル更新イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            uGrid_Details.UpdateData();
        }

        /// <summary>
        /// グリッド脱出イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // ActiveCell解除
            if (uGrid_Details.ActiveCell != null)
            {
                uGrid_Details.ActiveCell.Selected = false;
                uGrid_Details.ActiveCell = null;
            }

            // ActiveRow解除
            if (uGrid_Details.ActiveRow != null)
            {
                uGrid_Details.ActiveRow.Selected = false;
                uGrid_Details.ActiveRow = null;
            }

            // ボタン表示更新
            this.UpdateButtonToolEnabled();
        }

        /// <summary>
        /// グリッドセルダブルクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 新規追加編集中は処理を行わない
            if ((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value == (int)AutoAnsItemStAcs.NewAddRowDiv.New)
            {
                return;
            }

            // （編集）編集ＵＩ表示
            _editForm = new PMKHN09701UB(_autoAnsItemStAcs, _guideControl);
            _editForm.RecordGuid = this.GetRecordGuidFromGrid();
            _editForm.ShowDialog(this);

            // 再検索
            if (_editForm.IsSave)
            {
                this._extrInfo = null;
                // ADD 2012/11/21 T.Yoshioka 2012/12/12配信 システムテスト障害№57 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                ClearGrid();
                // ADD 2012/11/21 T.Yoshioka 2012/12/12配信 システムテスト障害№57 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                Search();
            }
            _editForm.Dispose();
            _editForm = null;
        }

        /// <summary>
        /// グリッドキーマッピング
        /// </summary>
        /// <param name="grid"></param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// AfterPerformAction イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : Gridアクション処理後イベント</br>
        /// </remarks>
        private void uGrid_Details_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.uGrid_Details.ActiveCell != null) && 
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                        {
                                            // 全選択状態にする。
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// BeforePerformAction イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : Gridアクション処理前イベント</br>
        /// </remarks>
        private void uGrid_Details_BeforePerformAction(object sender, BeforeUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:
                    {
                        if (this.uGrid_Details.ActiveCell != null) 
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                            // 処理前のセルは新規追加行か？
                            if ((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value == (int)AutoAnsItemStAcs.NewAddRowDiv.New &&
                                (int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value == (int)AutoAnsItemStAcs.NewAddRowAllowSave.No)
                            {
                                // 入力が行われていた場合は入力チェックを行う
                                int ret = CheckRowNewAdd(cell.Row);
                                switch(ret)
                                {
                                    case -1:  // 入力ありで未入力項目あり
                                        {
                                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                                              "追加行が編集されていますが破棄しますか？",
                                                                              0,
                                                                              MessageBoxButtons.YesNo,
                                                                              MessageBoxDefaultButton.Button1);
                                            if (res == DialogResult.Yes)
                                            {
                                                // 追加行クリア
                                                ClearGridNewAddRow();
                                            }
                                            e.Cancel = true;
                                            break;
                                        }
                                    case 0:   // 入力ありで未入力項目なし
                                        {
                                            // 新規追加行更新
                                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = AutoAnsItemStAcs.NewAddRowAllowSave.Yes;
                                            this.uGrid_Details.Refresh();
                                            break;
                                        }
                                    case 1:   // 全項目未入力
                                        break;
                                }
                            }

                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// BeforeExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セル編集モード終了前イベント</br>
        /// </remarks>
        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {

            if (this.uGrid_Details.ActiveCell == null) return;

            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.uGrid_Details.ActiveCell.Row.Index < 0) return;
            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 変更前情報退避
            this._sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();               // 拠点コード
            this._customerCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value);        // 得意先コード
            if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim().Length > 0)
            {
                this._goodsMGroup = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim()).ToString();        // 商品中分類
            }
            else
            {
                this._goodsMGroup = string.Empty;
            }
            if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim().Length > 0)
            {
                this._blGoodsCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim()).ToString();        // BLコード
            }
            else
            {
                this._blGoodsCode = string.Empty;
            }
            this._goodsMakerCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString();           // ﾒｰｶｰｺｰﾄﾞ
            this._prmSetDtlNo2 = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value.ToString();      // 種別コード
            this._autoAnswerDiv = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value);      // 自動回答区分
            this._priorityOrder = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value.ToString();    // 優先順位
            // ADD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            e.Cancel = uGridErrChk();
            // ADD 2012/11/26 T.Yoshioka 2012/12/12配信 システムテスト障害№82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// CellDataError イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルデータエラー時イベント</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        /// <summary>
        /// グリッド　ドロップダウンリスト変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellListSelect(object sender, CellEventArgs e)
        {
            if (IsPriority(e.Cell.Text))
            {
                // 使用可に
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.AllowEdit;
            }
            else
            {
                // 使用不可に
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.Disabled;
            }

        }
        #endregion uGrid_Details関連 イベント

        #region ● Tick イベント
        /// <summary>
        /// ※未使用です。（12/12配信システムテスト障害№27により）
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる時に発生します。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tComboEditor_TargetDivide.Focus();

            // XMLデータ読込
            LoadStateXmlData();

            // グリッドのアクティブ行をクリア
            this.uGrid_Details.ActiveRow = null;

            // ボタン表示更新
            this.UpdateButtonToolEnabled();

            this.Initial_Timer.Enabled = false;
        }
        #endregion

        #region ● ValueChanged イベント
        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
            }
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 対象区分コンボボックスの値が変更された時に発生します。</br>
        /// </remarks>
        private void tComboEditor_TargetDivide_ValueChanged(object sender, EventArgs e)
        {
            // 入力補正
            if (this.tComboEditor_TargetDivide.Value == null)
            {
                this.tComboEditor_TargetDivide.Value = 0;
            }

            // パネル有効・無効
            bool sectionEnable = false;
            bool customerEnable = false;

            // コンボボックス選択
            int selectValue = (int)this.tComboEditor_TargetDivide.Value;
            switch ( selectValue )
            {
                // 0:全て
                default:
                case 0:
                    break;
                // 1:拠点
                case 1:
                    sectionEnable = true;
                    break;
                // 2:得意先
                case 2:
                    customerEnable = true;
                    break;
            }

            // 拠点の表示更新
            panel_Section.Enabled = sectionEnable;
            if ( !sectionEnable )
            {
                tEdit_SectionCodeAllowZero.Clear();
                tEdit_SectionName.Clear();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.DataText = "00";
                this.tEdit_SectionName.DataText = "全社";
            }

            // 得意先の表示更新
            panel_Customer.Enabled = customerEnable;
            if ( !customerEnable )
            {
                tNedit_CustomerCode_St.Clear();
                tNedit_CustomerCode_Ed.Clear();
            }
        }
        #endregion ValueChanged イベント

        #region ● ChangeFocus イベント
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : Enterキーによるコントロールのフォーカスが変更された時に発生します。</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            # region [一般処理]
            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                        string name;
                        if ( GetSectionName( sectionCode, out name ) )
                        {
                            this.tEdit_SectionName.Text = name;

                            if ( e.ShiftKey == false )
                            {
                                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    if ( this.tEdit_SectionCodeAllowZero.Text.Trim() != string.Empty )
                                    {
                                        // フォーカス移動
                                        e.NextCtrl = this.GetNextEdit( e.PrevCtrl );
                                    }
                                }
                            }
                            else
                            {
                                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    // フォーカス移動
                                    e.NextCtrl = this.GetPrevEdit( e.PrevCtrl );
                                }
                            }
                        }
                        else
                        {
                            // エラーメッセージ
                            TMsgDisp.Show( this, 					// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                              "拠点が存在しません。", 			// 表示するメッセージ
                              0, 									// ステータス値
                              MessageBoxButtons.OK );				// 表示するボタン

                            this.tEdit_SectionCodeAllowZero.Text = string.Empty;
                            this.tEdit_SectionName.Text = string.Empty;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_CustomerCode_St":
                case "tNedit_CustomerCode_Ed":
                case "tNedit_GoodsMGroup_St":
                case "tNedit_GoodsMGroup_Ed":
                case "tNedit_BLGoodsCode_St":
                case "tNedit_BLGoodsCode_Ed":
                case "tNedit_GoodsMakerCd_St":
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        if ( !e.ShiftKey )
                        {
                            if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                            {
                                if ( e.PrevCtrl is TNedit )
                                {
                                    if ( (e.PrevCtrl as TNedit).GetInt() != 0 )
                                    {
                                        e.NextCtrl = this.GetNextEdit( e.PrevCtrl );
                                    }
                                }
                                else if ( e.PrevCtrl is TEdit )
                                {
                                    if ( (e.PrevCtrl as TEdit).Text != string.Empty )
                                    {
                                        e.NextCtrl = this.GetNextEdit( e.PrevCtrl );
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                            {
                                // フォーカス移動
                                e.NextCtrl = this.GetPrevEdit( e.PrevCtrl );
                            }
                        }
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (!e.ShiftKey)
                        {
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                // UPD 2012/11/07 三戸 2012/12/12配信 システムテスト障害№2 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                //this.uGrid_Details.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

                                //e.NextCtrl = e.PrevCtrl;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                e.NextCtrl = null;
                                // UPD 2012/11/07 三戸 2012/12/12配信 システムテスト障害№2 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            // ADD 2012/11/07 三戸 2012/12/12配信 システムテスト障害№2 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                e.NextCtrl = null;
                            }
                            // ADD 2012/11/07 三戸 2012/12/12配信 システムテスト障害№2 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        break;
                    }
            }
            # endregion

            # region [フォーカス移動の微調整]
            if ( e.PrevCtrl == tComboEditor_TargetDivide )
            {
                if ( !e.ShiftKey )
                {
                    if ( e.Key == Keys.Down )
                    {
                        if ( tEdit_SectionCodeAllowZero.Enabled && tEdit_SectionCodeAllowZero.Visible )
                        {
                            // 拠点
                            e.NextCtrl = tEdit_SectionCodeAllowZero;
                        }
                        else if ( tNedit_CustomerCode_St.Enabled && tNedit_CustomerCode_St.Visible )
                        {
                            // 得意先(開始)
                            e.NextCtrl = tNedit_CustomerCode_St;
                        }
                        else
                        {
                            // 商品中分類(開始)
                            e.NextCtrl = tNedit_GoodsMGroup_St;
                        }
                    }
                }
            }
            # endregion

            // ファンクションボタン表示更新
            this.UpdateButtonToolEnabled();

            // 移動先なければここで迂回
            if (e.NextCtrl == null)
            {
                return;
            }

            # region [移動先別の処理]
            switch (e.NextCtrl.Name)
            {
                // グリッド
                case "uGrid_Details":
                    {
                        if (!e.ShiftKey && e.PrevCtrl != uGrid_Details)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                // 検索実行
                                if ( this.Search() == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_TargetDivide;
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    if ( Standard_UGroupBox.Expanded == false )
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else if ( Standard_UGroupBox.Expanded == true )
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        break;
                    }
            }
            # endregion
        }
        #endregion

        #region ● CheckedChanged イベント
        /// <summary>
        /// 削除済み表示有無チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_ShowLogicalDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.uGrid_Details.BeginUpdate();
            try
            {
                bool excludeLogicalDelete = !uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

                // グリッド表示切り替え
                this.ExcludeLogicalDeleteFromGrid(excludeLogicalDelete);
                // 論理削除有無切り替え
                this._autoAnsItemStAcs.ExcludeLogicalDeleteFromView = excludeLogicalDelete;
                // スクロールポジション初期化
                this.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
                this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

                // グリッド行再設定
                SettingGridRows(ref this.uGrid_Details);
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }
        /// <summary>
        /// 削除済みデータの表示チェック変更
        /// </summary>
        /// <param name="excludeLogicalDelete"></param>
        private void ExcludeLogicalDeleteFromGrid(bool excludeLogicalDelete)
        {
            // 削除日
            uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Hidden = excludeLogicalDelete;
            uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = 1;
        }

        /// <summary>
        /// 列サイズの自動調整チェック変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (uCheckEditor_StatusBar_AutoFillToGridColumn.Checked)
            {
                // 列サイズ自動調整
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                // 列サイズ自動調整解除
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // 幅を最適化する
                for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                }
                this.uGrid_Details.Refresh();
            }
        }
        #endregion

        #endregion ■ Control Events

        #region ■ その他

        /// <summary>
        /// 種別コードが重複していないか
        /// </summary>
        /// <returns>true:重複している　false:重複していない</returns>
        private bool IsPrmSetDtlNo2Duplicate()
        {
            bool ret = false;
            string filter = string.Empty;
            int retCount = 0;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (string.IsNullOrEmpty(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
            {
                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}'",
                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value.ToString());
            }
            else
            {
                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}='{9}'",
                                       AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value.ToString());
            }

            List<AutoAnsItemSt> retList = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);

            if (retList != null && retList.Count > 1)
            {
                ret = true;
            }
            return ret;
        }

        #endregion

        #region ■ Public Methods
        /// <summary>
        /// 汎用　コード、名称構造体
        /// </summary>
        public struct CodeAndName
        {
            public CodeAndName(int _code, string _name)
            {
                Code = _code;
                Name = _name;
            }

            /// <summary>
            /// コード
            /// </summary>
            public int Code;
            /// <summary>
            /// 名称
            /// </summary>
            public string Name;
        }
        /// <summary>
        /// グリッド用　自動回答区分 ValueList取得
        /// </summary>
        /// <returns></returns>
        public static IValueList GetAutoAnswerDivValueList(int code)
        {
            List<CodeAndName> aList = GetAutoAnswerDivList(code);

            ValueList vList = new ValueList();
            foreach (CodeAndName div in aList)
            {
                vList.ValueListItems.Add(new ValueListItem(div.Code, div.Name));
            }
            return vList;
        }
        /// <summary>
        /// グリッド用　自動回答区分 ValueListItem配列取得
        /// </summary>
        /// <returns></returns>
        public static ValueListItem[] GetAutoAnswerDivValueArray(int code)
        {
            List<CodeAndName> aList = GetAutoAnswerDivList(code);

            ValueListItem[] vList = new ValueListItem[aList.Count];
            
            for(int i = 0; i < aList.Count ;i++)
            {
                vList[i] = new ValueListItem(aList[i].Code, aList[i].Name);
            }
            return vList;
        }
        /// <summary>
        /// グリッド用　自動回答区分 ValueList取得
        /// </summary>
        /// <returns></returns>
        public static IValueList GetAutoAnswerDivValueList()
        {
            List<CodeAndName> aList = GetAutoAnswerDivList();

            ValueList vList = new ValueList();
            foreach (CodeAndName div in aList)
            {
                vList.ValueListItems.Add(new ValueListItem(div.Code, div.Name));
            }
            return vList;
        }

        /// <summary>
        /// 自動回答区分　取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<CodeAndName> GetAutoAnswerDivList(int code)
        {
            List<CodeAndName> list = new List<CodeAndName>();
            list.Add(new CodeAndName(0, AUTOANSWER_DIV_NO_AUTOANSWER));
            list.Add(new CodeAndName(1, AUTOANSWER_DIV_AUTOANSWER));

            // 優良のみ
            if (!IsPureMaker(code))
            {
                list.Add(new CodeAndName(2, AUTOANSWER_DIV_AUTOANSWER_PRIORITY));
            }
            return list;
        }

        /// <summary>
        /// 自動回答区分　取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<CodeAndName> GetAutoAnswerDivList()
        {
            List<CodeAndName> list = new List<CodeAndName>();
            list.Add(new CodeAndName(0, AUTOANSWER_DIV_NO_AUTOANSWER));
            list.Add(new CodeAndName(1, AUTOANSWER_DIV_AUTOANSWER));
            list.Add(new CodeAndName(2, AUTOANSWER_DIV_AUTOANSWER_PRIORITY));
            return list;
        }

        /// <summary>
        /// 純正メーカーか否か
        /// </summary>
        /// <param name="code">メーカーコード</param>
        /// <returns>true：純正　false：優良</returns>
        public static bool IsPureMaker(int code)
        {
            return code <= 999;
        }

        /// <summary>
        /// 選択されている自動回答区分が"する(優先順位)"か否か
        /// </summary>
        /// <param name="text">対象となる区分のテキスト</param>
        /// <returns>true:する(優先順位)　false:する(優先順位)以外</returns>
        public static bool IsPriority(string text)
        {
            return text == AUTOANSWER_DIV_AUTOANSWER_PRIORITY;
        }

        /// <summary>
        /// 特定の値を数値(int)に変換。
        /// 変換できない場合は0を設定。
        /// </summary>
        /// <param name="target">対象項目</param>
        /// <returns>変換したint値</returns>
        public static int GetIntNullZero(object target)
        {
            int rtn = 0;
            if (target != null)
            {
                int.TryParse(target.ToString(), out rtn);
            }
            return rtn;
        }

        /// <summary>
        /// 特定の値を文字列(string)に変換。
        /// 変換できない場合は空文字を設定。
        /// </summary>
        /// <param name="target">対象項目</param>
        /// <returns>変換したstring値</returns>
        public static string GetString(object target)
        {
            if (target != null)
            {
                return target.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion


        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region  ■ガイド（ツールバー）
        /// <summary>
        /// ツールバー　ガイド　拠点
        /// </summary>
        private void GuideSection()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._guideControl.SecInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = secInfoSet.SectionCode.Trim();
                    this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONNM].Value = secInfoSet.SectionGuideNm.Trim();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ツールバー　ガイド　得意先
        /// </summary>
        private void GuideCustomer()
        {
            // ガイド表示
            DialogResult result = _guideControl.CustomerSearchForm.ShowDialog();
            if (result == DialogResult.OK && _guideControl.CustomerGuideRet != null)
            {
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = _guideControl.CustomerGuideRet.CustomerCode;
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERNAME].Value = _guideControl.CustomerGuideRet.Name.Trim();
            }
        }
        /// <summary>
        /// ツールバー　ガイド　商品中分類
        /// </summary>
        private void GuideGoodsMGroup()
        {
            GoodsGroupU goodsGroupU;
            int status = _guideControl.GoodsAcs.ExecuteGoodsMGroupGuid(_enterpriseCode, out goodsGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsGroupU != null)
            {
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = goodsGroupU.GoodsMGroup.ToString();
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsGroupU.GoodsMGroup;
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Value = goodsGroupU.GoodsMGroupName.Trim();
            }
        }
        /// <summary>
        /// ツールバー　ガイド　BLコード
        /// </summary>
        private void GuideBLCode()
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = _guideControl.BLGoodsCdAcs.ExecuteGuid(_enterpriseCode, out blGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null)
            {
                // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№35 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = blGoodsCdUMnt.BLGoodsCode.ToString();
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№35 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = blGoodsCdUMnt.BLGoodsCode;
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = blGoodsCdUMnt.BLGoodsFullName.Trim();

                // 商品中分類を取得するため、再度検索
                _guideControl.BLGoodsCdAcs.Read(out blGoodsCdUMnt, _enterpriseCode, blGoodsCdUMnt.BLGoodsCode);
                
                if (!blGoodsCdUMnt.GoodsRateGrpCode.Equals(0))
                {
                    int goodsMGroupOld = 0;
                    int.TryParse(this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString(), out goodsMGroupOld);
                    // 商品中分類 
                    this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = blGoodsCdUMnt.GoodsRateGrpCode;
                    // 商品中分類名称の取得
                    GoodsMGroupReadAndSet(blGoodsCdUMnt.GoodsRateGrpCode.ToString(), goodsMGroupOld.ToString(), this.uGrid_Details.ActiveCell);
                }
            }
        }
        /// <summary>
        /// ツールバー　ガイド　メーカー
        /// </summary>
        private void GuideMaker()
        {
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.ExecuteGuid(_enterpriseCode, out maker);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null)
            {
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = maker.GoodsMakerCd.ToString();
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = maker.MakerName.Trim();
            }
        }
        #endregion
        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// グリッドの各列の幅を保管
        /// </summary>
        private void GridWidthSave()
        {
            if (uGrid_Details.Rows.Count > 0)
            {
                CellsCollection cell = uGrid_Details.Rows[0].Cells;
                widthDelete = cell[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Width;        // 削除日
                widthNo = cell[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Width;             // №
                widthSection = cell[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Width;             // 拠点
                widthCustomer = cell[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Width;           // 得意先
                widthGoodsMGroup = cell[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Width;  // 商品中分類
                widthGoodsMGroupName = cell[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Width; // 商品中分類名称
                widthBlCode = cell[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Width;       // BLコード
                widthBlCodeName = cell[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Width;          // BLコード名称
                widthMaker = cell[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Width;              // メーカー
                widthMakerName = cell[AutoAnsItemStAcs.ct_COL_MAKERNAME].Width;             // メーカー名称
                widthType = cell[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Width;        // 種 別
                widthTypeName = cell[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width;         // 種別名称
                widthAutoAnsDiv = cell[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width;        // 自動回答区分
                widthPriority = cell[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Width;   // 優先順位
            }
        }
        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№26 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// グリッド列幅初期値セット
        /// </summary>
        private void GridWidthSet()
        {
            // --- UPD 2012/11/22 吉岡 2012/12/12配信分 システムテスト障害№77 --------->>>>>>>>>>>>>>>>>>>>>>>>
            widthDelete = 80;            // 削除日
            widthNo = 49;                // №
            widthSection = 54;           // 拠点
            widthCustomer = 94;          // 得意先
            widthGoodsMGroup = 74;       // 商品中分類
            widthGoodsMGroupName = 133;  // 商品中分類名称
            widthBlCode = 74;            // BLコード
            widthBlCodeName = 134;       // BLコード名称
            widthMaker = 64;             // メーカー
            widthMakerName = 132;        // メーカー名称
            widthAutoAnsDiv = 139;       // 自動回答区分
            widthPriority = 50;          // 優先順位

            #region 旧ソース
            //widthDelete = 80;            // 削除日
            //widthNo = 35;                // №
            //widthSection = 40;           // 拠点
            //widthCustomer = 80;          // 得意先
            //widthGoodsMGroup = 60;       // 商品中分類
            //widthGoodsMGroupName = 119;  // 商品中分類名称
            //widthBlCode = 60;            // BLコード
            //widthBlCodeName = 120;       // BLコード名称
            //widthMaker = 50;             // メーカー
            //widthMakerName = 118;        // メーカー名称
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№35 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// widthType = 40;              // 種 別
            //widthType = 36;              // 種 別
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№35 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //widthTypeName = 118;         // 種別名称
            //widthAutoAnsDiv = 125;       // 自動回答区分
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№35 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// widthPriority = 40;          // 優先順位
            //widthPriority = 36;          // 優先順位
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№35 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion
            // --- UPD 2012/11/22 吉岡 2012/12/12配信分 システムテスト障害№77 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№26 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}