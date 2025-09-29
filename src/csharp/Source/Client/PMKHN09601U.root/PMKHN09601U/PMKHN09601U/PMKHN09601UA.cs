//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン管理マスタ
// プログラム概要   : キャンペーン管理の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009.08.19  修正内容 : MANTIS:13900 拠点コードチェック方法修正
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
    /// キャンペーン管理マスタメンテナンスUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : キャンペーン管理マスタメンテナンスUIフォームクラス</br>
    /// <br>Programmer  : 30413 犬飼</br>
    /// <br>Date        : 2009/05/28</br>
    /// </remarks>
    public partial class PMKHN09601UA : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09601U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09601U.dat";

        // グリッド列
        public const string COLUMN_NO = "No";

        private const string FORMAT = "N";

        private const string ERRORMSG_RANGE = "{0}の範囲に誤まりがあります";

        #endregion ■ Constants


        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private CampaignMngAcs _campaignMngAcs; // キャンペーン管理マスタメンテナンスアクセスクラス
        private CampaignMngGuideControl _guideControl; // キャンペーン管理マスメンガイド制御クラス

        private PMKHN09601UB _editForm; // 編集UI

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        // 抽出条件
        private CampaignMngOrder _extrInfo;

        private bool _closeFlg;

        #region キャンペーン設定情報

        /// <summary>キャンペーン設定のマップ</summary>
        /// <remarks>キー：キャンペーンコード</remarks>
        private IDictionary<int, List<CampaignSt>> _campaignSettingMap;
        /// <summary>キャンペーン設定のマップを取得します。</summary>
        /// <remarks>キー：キャンペーンコード</remarks>
        private IDictionary<int, List<CampaignSt>> CampaignSettingMap
        {
            get
            {
                if (_campaignSettingMap == null)
                {
                    _campaignSettingMap = CreateCampaignSettingMap();
                }
                return _campaignSettingMap;
            }
        }

        /// <summary>
        /// キャンペーン設定のマップを生成します。
        /// </summary>
        /// <returns>キャンペーン設定のマップ</returns>
        private IDictionary<int, List<CampaignSt>> CreateCampaignSettingMap()
        {
            IDictionary<int, List<CampaignSt>> campaignSettingMap = new Dictionary<int, List<CampaignSt>>();
            {
                ArrayList searchedCampaignStList = null;
                int status = _guideControl.CampaignStAcs.SearchAll(out searchedCampaignStList, _enterpriseCode);
                if (searchedCampaignStList == null || searchedCampaignStList.Count.Equals(0))
                {
                    return campaignSettingMap;
                }

                foreach (CampaignSt campaignSt in searchedCampaignStList)
                {
                    if (!campaignSettingMap.ContainsKey(campaignSt.CampaignCode))
                    {
                        campaignSettingMap.Add(campaignSt.CampaignCode, new List<CampaignSt>());
                    }
                    campaignSettingMap[campaignSt.CampaignCode].Add(campaignSt);
                }
            }
            return campaignSettingMap;
        }

        /// <summary>
        /// 拠点コードを含むか判断します。
        /// </summary>
        /// <param name="campainCode">キャンペーンコード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>
        /// <c>true</c> :拠点を含みます。<br/>
        /// <c>false</c>:拠点を含みません。
        /// </returns>
        private bool ContainsSectionCode(
            int campainCode,
            string sectionCode
        )
        {
            if (!CampaignSettingMap.ContainsKey(campainCode)) return false;

            IList<CampaignSt> foundList = CampaignSettingMap[campainCode].FindAll(
                delegate(CampaignSt campaignSt)
                {
                    // 2009.08.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //return campaignSt.SectionCode.Trim().Equals(sectionCode.Trim());
                    if ((campaignSt.CampaignCode == campainCode) &&
                        ((campaignSt.SectionCode.Trim().Equals(sectionCode.Trim())) ||
                         (campaignSt.SectionCode.Trim().Equals("00"))))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    // 2009.08.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            );
            return foundList != null && foundList.Count > 0;
        }

        #endregion // キャンペーン設定情報

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// キャンペーン管理マスタメンテナンスUIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : キャンペーン管理マスタメンテナンスUIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        public PMKHN09601UA()
		{
			InitializeComponent();
            
            this._controlScreenSkin = new ControlScreenSkin();
            
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ガイド制御
            _guideControl = new CampaignMngGuideControl( _enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim() );
            _guideControl.AfterRenewal += new EventHandler( GuideControl_AfterRenewal );

            this._campaignMngAcs = new CampaignMngAcs();
            this._campaignMngAcs.AfterTableUpdate += new EventHandler( CampaignMngAcs_AfterTableUpdate );

            this._gridStateController = new GridStateController();

            // 画面初期設定
            SetInitialSetting();

            // 画面クリア
            ClearScreen();
        }
        #endregion ■ Constructor


        #region ■ Private Methods

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/28</br>
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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/28</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        #endregion 名称取得

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
            this.uButton_GoodsMakerCd_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGloupCode_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGloupCode_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            // メーカーコード
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // 商品中分類コード
            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
            // グループコード
            this.tNedit_BLGloupCode_St.Clear();
            this.tNedit_BLGloupCode_Ed.Clear();
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void ClearGrid()
        {
            // グリッド作成処理
            CreateGrid(ref this.uGrid_Details);
            // キーマッピング設定
            MakeKeyMappingForGrid( this.uGrid_Details );
        }
        #endregion クリア処理

        #region 保存データチェック処理
        /// <summary>
        /// 保存データチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存データのチェックを行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private bool ScreenDataCheck(ref string message)
        {
            int maxRow = this.uGrid_Details.Rows.Count;

            for (int i = 0; i < maxRow; i++)
            {
                UltraGridRow row = this.uGrid_Details.Rows[i];

                // ガイドコード
                if ((row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Value == DBNull.Value) &&
                    ((string)row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Value == string.Empty))
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[i].Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    message = "ガイドコードを入力して下さい。";
                    return false;
                }
                // 売価率／売価額
                if ((row.Cells[CampaignMngAcs.ct_COL_RATEVAL].Value == DBNull.Value) &&
                    ((string)row.Cells[CampaignMngAcs.ct_COL_GOODSNO].Value == string.Empty))
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[i].Cells[CampaignMngAcs.ct_COL_RATEVAL].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    message = "売価率を入力して下さい。";
                    return false;
                }
                else if ((row.Cells[CampaignMngAcs.ct_COL_RATEVAL].Value == DBNull.Value) &&
                    (row.Cells[CampaignMngAcs.ct_COL_PRICEFL].Value == DBNull.Value) &&
                    ((string)row.Cells[CampaignMngAcs.ct_COL_GOODSNO].Value != string.Empty))
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[i].Cells[CampaignMngAcs.ct_COL_RATEVAL].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    message = "売価率または売価額を入力して下さい。";
                    return false;
                }
                else if ((row.Cells[CampaignMngAcs.ct_COL_RATEVAL].Value != DBNull.Value) &&
                         (row.Cells[CampaignMngAcs.ct_COL_PRICEFL].Value != DBNull.Value) &&
                         ((string)row.Cells[CampaignMngAcs.ct_COL_GOODSNO].Value != string.Empty))
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[i].Cells[CampaignMngAcs.ct_COL_RATEVAL].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    message = "売価率と売価額は両方設定できません。";
                    return false;
                }
            }

            return true;
        }
        #endregion 保存データチェック処理

        #region 保存
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private int Save()
        {
            tEdit_SectionCodeAllowZero.Focus();

            # region [保存データチェック]
            string message = string.Empty;
            if (!ScreenDataCheck(ref message))
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message,                            // 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            # endregion

            # region [更新レコード有無チェック]
            if ( _campaignMngAcs.GetUpdateCountFromTable() == 0 )
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    "更新対象のデータが存在しません",   // 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK );				// 表示するボタン
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            # endregion

            // 更新処理
            string errMsg;
            int status = _campaignMngAcs.WriteAll( out errMsg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //// 再検索
                        //this.Search();

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

            return (status);
        }
        #endregion 保存

        #region 検索
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private int Search()
        {
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
                _extrInfo = new CampaignMngOrder();
            }
            CampaignMngOrder extrInfoClone = _extrInfo.Clone();
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
            msgForm.Message = "キャンペーン管理マスタの抽出中です。";

            string msg;

            try
            {
                msgForm.Show();

                // 検索処理
                status = this._campaignMngAcs.Search( _extrInfo, out msg );
                if (status == 0)
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
                        tEdit_SectionCodeAllowZero.Focus();

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
                        tEdit_SectionCodeAllowZero.Focus();

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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void SetExtrInfo(out CampaignMngOrder para)
        {
            para = new CampaignMngOrder();

            // 企業コード
            para.EnterpriseCode = this._enterpriseCode;

            // 拠点
            para.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            if (para.SectionCode == "00")
            {
                para.SectionCode = null;
            }

            // メーカー
            para.St_GoodsMakerCd = tNedit_GoodsMakerCd_St.GetInt();
            para.Ed_GoodsMakerCd = tNedit_GoodsMakerCd_Ed.GetInt();
            //if ( para.Ed_GoodsMakerCd != 0 ) para.St_GoodsMakerCd = 1;
            // 商品中分類
            para.St_GoodsMGroup = tNedit_GoodsMGroup_St.GetInt();
            para.Ed_GoodsMGroup = tNedit_GoodsMGroup_Ed.GetInt();
            //if ( para.Ed_GoodsMGroup != 0 ) para.St_GoodsMGroup = 1;
            // グループ
            para.St_BLGroupCode = tNedit_BLGloupCode_St.GetInt();
            para.Ed_BLGroupCode = tNedit_BLGloupCode_Ed.GetInt();
            //if ( para.Ed_BLGroupCode != 0 ) para.St_BLGroupCode = 1;
            // ＢＬコード
            para.St_BLGoodsCode = tNedit_BLGoodsCode_St.GetInt();
            para.Ed_BLGoodsCode = tNedit_BLGoodsCode_Ed.GetInt();
            //if ( para.Ed_BLGoodsCode != 0 ) para.St_BLGoodsCode = 1;
        }
        #endregion 検索

        #region チェック処理
        /// <summary>
        /// 検索条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索条件をチェックします。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            try
            {
                //--------------------------------------------------
                // 大小比較
                //--------------------------------------------------
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
                // グループ
                if ( CheckInputRange( tNedit_BLGloupCode_St, tNedit_BLGloupCode_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "グループ" );
                    this.tNedit_BLGloupCode_St.Focus();
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
        /// 
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
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return (true);
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
                                //this.uGrid_Details.ActiveCell = this._activeCell;
                                //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
                            //this.uGrid_Details.ActiveCell = this._activeCell;
                            //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            return (_campaignMngAcs.GetUpdateCountFromTable() == 0);
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            uGrid.DataSource = null;

            // データソースとなるDataViewをアクセスクラスから取得
            DataView view = _campaignMngAcs.DataViewForMstList;
            uGrid.DataSource = view;

            // 論理削除有無
            _campaignMngAcs.ExcludeLogicalDeleteFromView = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

            // グリッドスタイル設定
            SetGridLayout( ref uGrid );
        }

        /// <summary>
        /// グリッドスタイル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドのスタイルを設定します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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

                # region [各カラムの設定]

                // 削除日
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Hidden = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Header.Caption = "削除日";
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.TextHAlign = HAlign.Left;
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.ForeColor = Color.Red;
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Width = 100;
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = visiblePosition++;

                // 拠点コード
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].Hidden = false;
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].Header.Caption = "拠点";
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].Width = 80;
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].Header.VisiblePosition = visiblePosition++;

                // 商品メーカーコード
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].Hidden = false;
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].Header.Caption = "メーカー";
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].Width = 100;
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].Format = GetMakerFormat();
                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].Header.VisiblePosition = visiblePosition++;

                // 商品中分類コード
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].Hidden = false;
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].Header.Caption = "商品中分類";
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].Width = 100;
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].Format = GetGoodsMGroupFormat();
                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].Header.VisiblePosition = visiblePosition++;

                // グループコード
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].Hidden = false;
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].Header.Caption = "グループ";
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].Width = 100;
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].Format = GetBLGroupFormat();
                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].Header.VisiblePosition = visiblePosition++;

                // BLコード
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].Hidden = false;
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].Header.Caption = "ＢＬコード";
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].Width = 100;
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].Format = GetBLCodeFormat();
                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].Header.VisiblePosition = visiblePosition++;

                // 品番
                columns[CampaignMngAcs.ct_COL_GOODSNO].Hidden = false;
                columns[CampaignMngAcs.ct_COL_GOODSNO].Header.Caption = "品番";
                columns[CampaignMngAcs.ct_COL_GOODSNO].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
                columns[CampaignMngAcs.ct_COL_GOODSNO].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_GOODSNO].Width = 200;
                columns[CampaignMngAcs.ct_COL_GOODSNO].Header.VisiblePosition = visiblePosition++;

                // キャンペーンコード
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Hidden = false;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Header.Caption = "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ";
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].CellAppearance.ForeColorDisabled = Color.Black;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].CellActivation = Activation.NoEdit; // HACK:キャンペーンコードのセル…Activation.AllowEdit;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Width = 100;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Format = GetCampaignCodeFormat();
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Header.VisiblePosition = visiblePosition++;

                // キャンペーンコードガイド
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Hidden = false;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Header.Caption = "";
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].CellAppearance.ForeColorDisabled = Color.Black;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Width = 20;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                columns[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Header.VisiblePosition = visiblePosition++;

                // キャンペーン名称
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Hidden = false;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Header.Caption = "ｷｬﾝﾍﾟｰﾝ名称";
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].CellAppearance.ForeColorDisabled = Color.Black;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].CellActivation = Activation.NoEdit;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Width = 150;
                columns[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Header.VisiblePosition = visiblePosition++;

                // 売価率
                columns[CampaignMngAcs.ct_COL_RATEVAL].Hidden = false;
                columns[CampaignMngAcs.ct_COL_RATEVAL].Header.Caption = "売価率";
                columns[CampaignMngAcs.ct_COL_RATEVAL].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_RATEVAL].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_RATEVAL].CellAppearance.ForeColorDisabled = Color.Black;
                columns[CampaignMngAcs.ct_COL_RATEVAL].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[CampaignMngAcs.ct_COL_RATEVAL].CellActivation = Activation.NoEdit; // HACK:売価率のセル…Activation.AllowEdit;
                columns[CampaignMngAcs.ct_COL_RATEVAL].Width = 80;
                columns[CampaignMngAcs.ct_COL_RATEVAL].Format = GetRateValFormat();
                columns[CampaignMngAcs.ct_COL_RATEVAL].Header.VisiblePosition = visiblePosition++;

                // 売価額
                columns[CampaignMngAcs.ct_COL_PRICEFL].Hidden = false;
                columns[CampaignMngAcs.ct_COL_PRICEFL].Header.Caption = "売価額";
                columns[CampaignMngAcs.ct_COL_PRICEFL].Header.Fixed = false;
                columns[CampaignMngAcs.ct_COL_PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[CampaignMngAcs.ct_COL_PRICEFL].CellAppearance.ForeColorDisabled = Color.Black;
                columns[CampaignMngAcs.ct_COL_PRICEFL].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[CampaignMngAcs.ct_COL_PRICEFL].CellActivation = Activation.NoEdit; // HACK:売価額のセル…Activation.AllowEdit;
                columns[CampaignMngAcs.ct_COL_PRICEFL].Width = 150;
                columns[CampaignMngAcs.ct_COL_PRICEFL].Format = GetPriceFlFormat();
                columns[CampaignMngAcs.ct_COL_PRICEFL].Header.VisiblePosition = visiblePosition++;

                // 補正
                columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = 0;

                # endregion

                # region [セル結合設定]
                List<string> colNameList = new List<string>( new string[] 
                                            { 
                                                CampaignMngAcs.ct_COL_SECTIONCODE, 
                                                CampaignMngAcs.ct_COL_GOODSMAKERCD, 
                                                CampaignMngAcs.ct_COL_GOODSMGROUP,
                                                CampaignMngAcs.ct_COL_BLGROUPCODE,
                                                CampaignMngAcs.ct_COL_BLGOODSCODE 
                                            } );
                
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();
                margedCellAppearance.BackColor = Color.Lavender;
                margedCellAppearance.BackColor2 = Color.Lavender;

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearanceを強制的に統一する
                    columns[colName].MergedCellAppearance = margedCellAppearance;
                    columns[colName].CellAppearance.BackColor = margedCellAppearance.BackColor;
                    columns[colName].CellAppearance.BackColor2 = margedCellAppearance.BackColor2;
                    columns[colName].CellAppearance.TextVAlign = VAlign.Top;

                    // セル結合設定
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }
                columns[CampaignMngAcs.ct_COL_SECTIONCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( CampaignMngAcs.ct_COL_SECTIONCODE );

                columns[CampaignMngAcs.ct_COL_GOODSMAKERCD].MergedCellEvaluator = new CustomMergedCellEvaluator( CampaignMngAcs.ct_COL_SECTIONCODE, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMAKERCD );

                columns[CampaignMngAcs.ct_COL_GOODSMGROUP].MergedCellEvaluator = new CustomMergedCellEvaluator( CampaignMngAcs.ct_COL_SECTIONCODE, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMAKERCD, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMGROUP );

                columns[CampaignMngAcs.ct_COL_BLGROUPCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( CampaignMngAcs.ct_COL_SECTIONCODE, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMAKERCD, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMGROUP,
                                                                                                                    CampaignMngAcs.ct_COL_BLGROUPCODE );

                columns[CampaignMngAcs.ct_COL_BLGOODSCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( CampaignMngAcs.ct_COL_SECTIONCODE, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMAKERCD, 
                                                                                                                    CampaignMngAcs.ct_COL_GOODSMGROUP, 
                                                                                                                    CampaignMngAcs.ct_COL_BLGROUPCODE,
                                                                                                                    CampaignMngAcs.ct_COL_BLGOODSCODE );
                # endregion
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
        private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
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
                return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
            }
        }
        # endregion

        # region [コードフォーマット取得処理]
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
        /// グループコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLGroupFormat()
        {
            return GetFormat( "tNedit_BLGloupCode" );
        }
        /// <summary>
        /// 中分類コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetGoodsMGroupFormat()
        {
            return GetFormat( "tNedit_GoodsMGroup" );
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

        /// <summary>
        /// キャンペーンコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCampaignCodeFormat()
        {
            string format = string.Empty;

            format = string.Format("{0};-{0};''", new string('0', 6));

            return format;
        }
        /// <summary>
        /// 売価率フォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetRateValFormat()
        {
            string format = string.Empty;

            format = "##0.00";

            return format;
        }
        /// <summary>
        /// 売価額フォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetPriceFlFormat()
        {
            string format = string.Empty;

            format = "#,##0.00";

            return format;
        }
        # endregion

        /// <summary>
        /// グリッド行設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッド行に対して各種設定をします。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        public void SettingGridRows(ref UltraGrid uGrid)
        {
            uGrid.BeginUpdate();

            try
            {
                for ( int rowIndex = 0; rowIndex < uGrid.Rows.Count; rowIndex++ )
                {
                    CellsCollection cells = uGrid.Rows[rowIndex].Cells;

                    if ( cells[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Value.ToString().Trim() == string.Empty )
                    {
                        // 通常：編集可
                        cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Activation = Activation.AllowEdit;
                        cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Appearance = null;

                        cells[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Hidden = false;

                        cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Appearance = null;

                        cells[CampaignMngAcs.ct_COL_RATEVAL].Activation = Activation.AllowEdit;
                        cells[CampaignMngAcs.ct_COL_RATEVAL].Appearance = null;

                        if (cells[CampaignMngAcs.ct_COL_GOODSNO].Value.ToString().Trim() != string.Empty)
                        {
                            cells[CampaignMngAcs.ct_COL_PRICEFL].Activation = Activation.AllowEdit;
                            cells[CampaignMngAcs.ct_COL_PRICEFL].Appearance = null;
                        }
                        else
                        {
                            cells[CampaignMngAcs.ct_COL_PRICEFL].Activation = Activation.NoEdit;
                            cells[CampaignMngAcs.ct_COL_PRICEFL].Appearance.BackColor = Color.LightGray;
                        }
                    }
                    else
                    {
                        // 削除済み：編集不可
                        cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Activation = Activation.NoEdit;
                        cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Appearance.BackColor = Color.LightGray;

                        cells[CampaignMngAcs.ct_COL_CAMPAIGNCODEGUIDE].Hidden = true;

                        cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Appearance.BackColor = Color.LightGray;

                        cells[CampaignMngAcs.ct_COL_RATEVAL].Activation = Activation.NoEdit;
                        cells[CampaignMngAcs.ct_COL_RATEVAL].Appearance.BackColor = Color.LightGray;

                        cells[CampaignMngAcs.ct_COL_PRICEFL].Activation = Activation.NoEdit;
                        cells[CampaignMngAcs.ct_COL_PRICEFL].Appearance.BackColor = Color.LightGray;
                    }
                }
                uGrid.Refresh();
            }
            finally
            {
                uGrid.EndUpdate();
            }
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
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
                                         this._campaignMngAcs,	            // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void PMKHN09601UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
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
                        if (Save() == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            // 保存チェックエラー
                            break;
                        }

                        // グリッドクリア
                        _campaignMngAcs.Clear();

                        // フォーカス設定
                        this.tEdit_SectionCodeAllowZero.Focus();

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

                        // クリア処理
                        ClearScreen();

                        // アクセスクラス内のテーブルクリア
                        _campaignMngAcs.Clear();

                        break;
                    }
                case "ButtonTool_Insert":
                    {
                        // （新規）編集ＵＩ表示
                        _editForm = new PMKHN09601UB( this, _campaignMngAcs, _guideControl );
                        _editForm.RecordGuid = Guid.Empty;
                        _editForm.ShowDialog( this );

                        _editForm.Dispose();
                        _editForm = null;

                        // グリッドデータ設定
                        CreateGrid( ref this.uGrid_Details );
                        SettingGridRows( ref this.uGrid_Details );
                        this.uGrid_Details.Refresh();

                        break;
                    }
                case "ButtonTool_Edit":
                    {
                        // （編集）編集ＵＩ表示
                        _editForm = new PMKHN09601UB( this, _campaignMngAcs, _guideControl );
                        _editForm.RecordGuid = this.GetRecordGuidFromGrid();
                        _editForm.ShowDialog( this );

                        _editForm.Dispose();
                        _editForm = null;

                        // グリッドデータ設定
                        CreateGrid( ref this.uGrid_Details );
                        SettingGridRows( ref this.uGrid_Details );
                        this.uGrid_Details.Refresh();

                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        // 論理削除
                        this.LogicalDelete();

                        // グリッドデータ設定
                        CreateGrid(ref this.uGrid_Details);
                        SettingGridRows(ref this.uGrid_Details);
                        this.uGrid_Details.Refresh();

                        break;
                    }
                case "ButtonTool_Renewal":
                    {
                        // 最新情報取得
                        _guideControl.Renewal();

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "最新情報を取得しました。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                        _campaignSettingMap = null;
                        break;
                    }
            }
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        private void LogicalDelete()
        {
            // 選択中のレコードのGuidを取得
            Guid guid = this.GetRecordGuidFromGrid();
            // 削除対象レコードを取得
            CampaignMng campaignMng = _campaignMngAcs.GetRecordForMaintenance( guid );

            # region [削除済みチェック]
            if ( campaignMng.LogicalDeleteCode != 0 )
            {
                // 論理削除済み行ならメッセージ表示して終了

                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    "選択中のデータは既に削除されています",// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK );				// 表示するボタン

                return;
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
                MessageBoxDefaultButton.Button2 );	// 表示するボタン

            if ( result != DialogResult.OK )
            {
                return;
            }
            # endregion


            int status;
            string errMsg;
            ArrayList deleteList = new ArrayList();
            deleteList.Add( campaignMng );

            status = _campaignMngAcs.LogicalDelete( ref deleteList, out errMsg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //// 再検索
                        //this.Search();

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
                        //return (status);
                        break;
                    }
                default:
                    {
                        ShowMessageBox( emErrorLevel.ERR_LEVEL_STOP,
                                   "Save",
                                   "保存処理に失敗しました。",
                                   status,
                                   MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        //return (status);
                        break;
                    }
            }
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
                guid = (Guid)uGrid_Details.ActiveCell.Row.Cells[CampaignMngAcs.ct_COL_FILEHEADERGUID].Value;
            }

            return guid;
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
                if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                {
                    sectionName = string.Empty;
                }
                this.tEdit_SectionName.Text = sectionName;
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = "00";
                this.tEdit_SectionName.Text = "全社";
            }

            // アクセスクラス最新情報取得
            this._campaignMngAcs.Renewal();
        }
        /// <summary>
        /// データ更新後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CampaignMngAcs_AfterTableUpdate( object sender, EventArgs e )
        {
            if ( _campaignMngAcs.DataViewForMstList.Count > 0 )
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
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    nextControl = tNedit_GoodsMakerCd_Ed;
                    break;
                case "tNedit_GoodsMakerCd_Ed":
                    nextControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
                    nextControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    nextControl = tNedit_BLGloupCode_St;
                    break;
                case "tNedit_BLGloupCode_St":
                    nextControl = tNedit_BLGloupCode_Ed;
                    break;
                case "tNedit_BLGloupCode_Ed":
                    nextControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    nextControl = tNedit_BLGoodsCode_Ed;
                    break;
                case "tNedit_BLGoodsCode_Ed":
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
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Note        : </br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void uButton_BLGloupCode_St_Click( object sender, EventArgs e )
        {
            // ガイド表示
            BLGroupU blGroupUInfo;
            int status = this._guideControl.GoodsAcs.ExecuteBLGroupGuid( this._enterpriseCode, out blGroupUInfo );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( sender == uButton_BLGloupCode_St )
                {
                    // 開始
                    tNedit_BLGloupCode_St.SetInt( blGroupUInfo.BLGroupCode );
                }
                else if ( sender == uButton_BLGloupCode_Ed )
                {
                    // 終了
                    tNedit_BLGloupCode_Ed.SetInt( blGroupUInfo.BLGroupCode );
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
                        this.tEdit_SectionCodeAllowZero.Focus();
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            // アクティブセルがnullの時は処理を行わず終了
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            if ( e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab )
            {
                this.uGrid_Details.PerformAction( UltraGridAction.ExitEditMode );
                //e.Handled = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (this.uGrid_Details.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                {
                    UltraGridCell ultraGridCell = this.uGrid_Details.ActiveCell;
                    CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                    uGrid_Details_ClickCellButton(sender, cellEventArgs);
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                     e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // キャンペーンコードの入力桁数チェック
            if (cell.Column.Key == CampaignMngAcs.ct_COL_CAMPAIGNCODE)
            {
                // 編集モード中？
                    if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // 売価率
            else if (cell.Column.Key == CampaignMngAcs.ct_COL_RATEVAL)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // 売価額
            else if (cell.Column.Key == CampaignMngAcs.ct_COL_PRICEFL)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルがアクティブ化した時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            UpdateButtonToolEnabled();

            uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
        }
        /// <summary>
        /// ボタンの有効・無効設定
        /// </summary>
        private void UpdateButtonToolEnabled()
        {
            if ( uGrid_Details.ActiveCell != null )
            {
                if ( string.IsNullOrEmpty( (string)uGrid_Details.ActiveCell.Row.Cells[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Value ) )
                {
                    // 通常
                    SetButtonToolEnabled( "ButtonTool_Edit", true );
                    SetButtonToolEnabled( "ButtonTool_Delete", true );
                }
                else
                {
                    // 論理削除
                    SetButtonToolEnabled( "ButtonTool_Edit", true );
                    //SetButtonToolEnabled( "ButtonTool_Delete", false );
                    SetButtonToolEnabled( "ButtonTool_Delete", true );
                }
            }
            else
            {
                // 行が選択されていない
                SetButtonToolEnabled( "ButtonTool_Edit", false );
                SetButtonToolEnabled( "ButtonTool_Delete", false );
            }
        }

        /// <summary>
        /// AfterRowActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 行がアクティブ化した時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            int status = -1;

            if (uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = uGrid_Details.ActiveCell;

            // キャンペーンコード
            if (cell.Column.Key == CampaignMngAcs.ct_COL_CAMPAIGNCODE)
            {
                if (cell.Value != DBNull.Value)
                {
                    // 入力有
                    int code = (int)cell.Value;
                    string sectionCode = cell.Row.Cells[CampaignMngAcs.ct_COL_SECTIONCODE].Value.ToString();

                    // TODO:キャンペーンと拠点の組合せチェック
                    if (!ValidatesCampaignCode(code.ToString(), sectionCode))
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ [" + code.ToString("d06") + "] は拠点[" + sectionCode.Trim() + "]では対象となっていません。",
                            -1,
                            MessageBoxButtons.OK
                        );

                        // キャンペーンコード、キャンペーン名をクリア
                        cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Value = DBNull.Value;    // キャンペーンコード
                        cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Value = "";              // キャンペーン名

                        

                        return;
                    }

                    CampaignSt campaignSt;
                    status = this._guideControl.CampaignStAcs.Read(out campaignSt, this._enterpriseCode, code);

                    if ((status == 0) && (campaignSt.LogicalDeleteCode == 0))
                    {
                        // 選択した情報をCellに設定
                        cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Value = campaignSt.CampaignCode; // キャンペーンコード
                        cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Value = campaignSt.CampaignName; // キャンペーン名
                    }
                    else
                    {
                        // 論理削除データは設定不可
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "ｷｬﾝﾍﾟｰﾝｺｰﾄﾞ [" + code.ToString("d06") + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // キャンペーンコード、キャンペーン名をクリア
                        cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Value = DBNull.Value;    // キャンペーンコード
                        cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Value = "";              // キャンペーン名
                    }
                }
                else
                {
                    // 未入力
                    // キャンペーンコード、キャンペーン名をクリア
                    cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Value = DBNull.Value;    // キャンペーンコード
                    cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Value = "";              // キャンペーン名
                }
            }
            // 売価率
            else if (cell.Column.Key == CampaignMngAcs.ct_COL_RATEVAL)
            {
                if (cell.Value != DBNull.Value)
                {
                    if ((double)cell.Value == 0.00)
                    {
                        cell.Value = DBNull.Value;
                    }
                }
            }
            // 売価額
            else if (cell.Column.Key == CampaignMngAcs.ct_COL_PRICEFL)
            {
                if (cell.Value != DBNull.Value)
                {
                    if ((double)cell.Value == 0.00)
                    {
                        cell.Value = DBNull.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();

            // XMLデータ読込
            LoadStateXmlData();

            // グリッドのアクティブ行をクリア
            this.uGrid_Details.ActiveRow = null;

            // ボタン表示更新
            this.UpdateButtonToolEnabled();

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void tComboEditor_TargetDivide_ValueChanged(object sender, EventArgs e)
        {
            // パネル有効・無効
            bool sectionEnable = true;
            
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
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
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
                            // 現在の設計では、拠点コードが""の場合、必ず"全社"と表示されるので、
                            // 拠点コードが""のままでツールバーを操作した場合、強制的に名称を""とする
                            if (string.IsNullOrEmpty(sectionCode) && e.NextCtrl.Name.Equals("_Form1_Toolbars_Dock_Area_Top"))
                            {
                                name = string.Empty;
                            }
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
                        }
                        else
                        {
                            // エラーメッセージ
                            TMsgDisp.Show( this, 					// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                              ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                              "拠点が存在しません。", 			    // 表示するメッセージ
                              0, 									// ステータス値
                              MessageBoxButtons.OK );				// 表示するボタン

                            this.tEdit_SectionCodeAllowZero.Text = string.Empty;
                            this.tEdit_SectionName.Text = string.Empty;
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "tNedit_GoodsMakerCd_St":
                case "tNedit_GoodsMakerCd_Ed":
                case "tNedit_GoodsMGroup_St":
                case "tNedit_GoodsMGroup_Ed":
                case "tNedit_BLGloupCode_St":
                case "tNedit_BLGloupCode_Ed":
                case "tNedit_BLGoodsCode_St":
                case "tNedit_BLGoodsCode_Ed":
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
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (!e.ShiftKey)
                        {
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                UltraGridCell cell = uGrid_Details.ActiveCell;

                                // 編集モード終了
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);

                                if (cell.Column.Key == CampaignMngAcs.ct_COL_CAMPAIGNCODE)
                                {
                                    // キャンペーンコード
                                    for (int i = 0; i < 2; i++)
                                    {
                                        uGrid_Details.PerformAction(UltraGridAction.NextCell);
                                    }
                                }
                                // 次のセルへ移動
                                this.uGrid_Details.PerformAction(UltraGridAction.NextCell);
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                //e.NextCtrl = e.PrevCtrl;
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                        }
                        break;
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
                                    e.NextCtrl = tEdit_SectionCodeAllowZero;
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

        /// <summary>
        /// キャンペーンコードを検証します。
        /// </summary>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>
        /// <c>true</c> :適切なキャンペーンコードです。<br/>
        /// <c>false</c>:不適切なキャンペーンコードです。
        /// </returns>
        public bool ValidatesCampaignCode(
            string campaignCode,
            string sectionCode
        )
        {
            int campaignCodeNo = 0;
            if (!int.TryParse(campaignCode.Trim(), out campaignCodeNo)) return false;

            return ContainsSectionCode(campaignCodeNo, sectionCode);
        }

        #endregion ■ Control Events

        /// <summary>
        /// 削除済み表示有無チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_ShowLogicalDelete_CheckedChanged( object sender, EventArgs e )
        {
            this.uGrid_Details.BeginUpdate();
            try
            {
                bool excludeLogicalDelete = !uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

                // グリッド表示切り替え
                this.ExcludeLogicalDeleteFromGrid( excludeLogicalDelete );
                // 論理削除有無切り替え
                this._campaignMngAcs.ExcludeLogicalDeleteFromView = excludeLogicalDelete; 
                // スクロールポジション初期化
                this.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
                this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

                // グリッド行再設定
                SettingGridRows( ref this.uGrid_Details );
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
        private void ExcludeLogicalDeleteFromGrid( bool excludeLogicalDelete )
        {
            // 削除日
            uGrid_Details.DisplayLayout.Bands[0].Columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Hidden = excludeLogicalDelete;
            uGrid_Details.DisplayLayout.Bands[0].Columns[CampaignMngAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = 0;
        }

        /// <summary>
        /// 列サイズの自動調整チェック変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged( object sender, EventArgs e )
        {
            if ( uCheckEditor_StatusBar_AutoFillToGridColumn.Checked )
            {
                // 列サイズ自動調整
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                // 列サイズ自動調整解除
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // 幅を最適化する
                for ( int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++ )
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                }
                this.uGrid_Details.Refresh();
            }
        }

        /// <summary>
        /// グリッドセル更新イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_AfterCellUpdate( object sender, CellEventArgs e )
        {
            uGrid_Details.UpdateData();
        }

        /// <summary>
        /// グリッド脱出イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave( object sender, EventArgs e )
        {
            // ActiveCell解除
            if ( uGrid_Details.ActiveCell != null )
            {
                uGrid_Details.ActiveCell.Selected = false;
                uGrid_Details.ActiveCell = null;
            }

            // ActiveRow解除
            if ( uGrid_Details.ActiveRow != null )
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
        private void uGrid_Details_DoubleClickCell( object sender, DoubleClickCellEventArgs e )
        {
            // （編集）編集ＵＩ表示
            _editForm = new PMKHN09601UB( this, _campaignMngAcs, _guideControl );
            _editForm.RecordGuid = this.GetRecordGuidFromGrid();
            _editForm.ShowDialog( this );

            _editForm.Dispose();
            _editForm = null;

            // グリッドデータ設定
            CreateGrid( ref this.uGrid_Details );
            SettingGridRows( ref this.uGrid_Details );
            this.uGrid_Details.Refresh();            
        }

        /// <summary>
        /// グリッドキーマッピング
        /// </summary>
        /// <param name="grid"></param>
        private void MakeKeyMappingForGrid( Infragistics.Win.UltraWinGrid.UltraGrid grid )
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
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );
        }

        /// <summary>
        /// グリッドセルボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_ClickCellButton(object sender, CellEventArgs e)
        {
            string sectionCode = e.Cell.Row.Cells[CampaignMngAcs.ct_COL_SECTIONCODE].Value.ToString();

            CampaignSt campaignSt;

            // ガイド起動
            int status = _guideControl.CampaignStAcs.ExecuteGuid(this._enterpriseCode, sectionCode, out campaignSt);
            if (status == 0)
            {
                // 選択した情報をCellに設定
                e.Cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNCODE].Value = campaignSt.CampaignCode;   // キャンペーンコード
                e.Cell.Row.Cells[CampaignMngAcs.ct_COL_CAMPAIGNNAME].Value = campaignSt.CampaignName;   // キャンペーン名称

                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }
    }
}