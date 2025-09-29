//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン） 
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  2010/08/26  作成担当 : 呉元嘯
// 修 正 日              修正内容 : Redmine#13690対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李永平
// 修 正 日  2010/09/09  修正内容 : Redmine#14492対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率設定マスタメン（掛率優先管理パターン）
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率設定マスタメン（掛率優先管理パターン）設定処理です。</br>
    /// <br>Programmer  : 呉元嘯</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>Update Note : 2010/08/26 呉元嘯</br>
    /// <br>              Redmine#13690対応</br>
    /// <br>Update Note : 2010/09/09 李永平</br>
    /// <br>              Redmine#14492対応</br>
    /// </remarks>
    public partial class PMKHN09471UA : Form
    {
        #region ■ Private member ■
        private ImageList _imageList16;
        private ControlScreenSkin _controlScreenSkin;
        private RateProtyMngDataSet.RateProtyMngDataTable _rateProtyMngDataTable;// 掛率優先管理マスタデータテーブル
        // 掛率設定マスタメン（掛率優先管理パターン）アクセス
        private RateProtyMngPatternAcs _rateProtyMngPatternAcs;
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;
        private SecInfoSetAcs _secInfoSetAcs;//拠点アクセス
        private SecInfoAcs _secInfoAcs;
        private string _preSectionCd = string.Empty;//前回拠点コード
        private string _preSectionNm = string.Empty;//前回拠点略称
        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        private bool _initMode = false;

        #endregion ■ Private member ■

        #region ■ Const ■
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        //private const string TOOLBAR_NEWBUTTON_KEY = "ButtonTool_New";						// 新規          // DEL 2010/09/09
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// クリア        // ADD 2010/09/09
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";						// ガイド        // ADD 2010/09/09
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";				// ログイン担当者タイトル
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";				// ログイン担当者名称
        private const string TOOLBAR_SECTIONTITLELABEL_KEY = "LabelTool_SectionTitle";			// ログイン拠点
        private const string TOOLBAR_SECTIONNAMELABEL_KEY = "LabelTool_SectionName";			// ログイン拠点名称
        private const string ct_PGID = "PMKHN09471UA";
        private const string ct_PGName = "掛率設定マスタメンテナンス";
        // --------UPD 2010/09/09-------->>>>>
        //private const string UNITPRICEKIND_1 = "売価設定";
        //private const string UNITPRICEKIND_2 = "原価設定";
        //private const string UNITPRICEKIND_3 = "価格設定";
        private const string UNITPRICEKIND_1 = "1:売価設定";
        private const string UNITPRICEKIND_2 = "2:原価設定";
        private const string UNITPRICEKIND_3 = "3:価格設定";
        // --------UPD 2010/09/09--------<<<<<
        private const string SECTION_CD = "00";
        private const string SECTION_NM = "全社";
        #endregion ■ Const ■

        #region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN09471UA()
        {
            InitializeComponent();
            this._controlScreenSkin = new ControlScreenSkin();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._rateProtyMngPatternAcs = RateProtyMngPatternAcs.GetInstance();
            this._rateProtyMngDataTable = _rateProtyMngPatternAcs.RateProtyMngDataSet.RateProtyMng;
            this.uGrid_Detail.DataSource = this._rateProtyMngDataTable;
            GridKeyDownTopRow += new EventHandler(this.uGrid_Detail_GridKeyDownTopRow);
        }
        #endregion ■ コンストラクタ ■

        #region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09471UA_Load(object sender, EventArgs e)
        {
            ButtonInitialSetting();

            // 単価種類
            this.tComboEditor_UnitPriceKind.Items.Clear();
            this.tComboEditor_UnitPriceKind.Items.Add("1", UNITPRICEKIND_1);
            this.tComboEditor_UnitPriceKind.Items.Add("2", UNITPRICEKIND_2);
            this.tComboEditor_UnitPriceKind.Items.Add("3", UNITPRICEKIND_3);

            this._initMode = true;
            this.ClearScreen();
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._initMode = false;

        }
        #endregion ■ フォームロード ■

        #region ■ Private Method ■
        /// <summary>
        /// 画面ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面ボタン初期設定を行います。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks> 
        private void ButtonInitialSetting()
        {
            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // ----------UPD 2010/09/09------------>>>>>
            // 新規
            //this.tToolsManager_MainMenu.Tools[TOOLBAR_NEWBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // クリア
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ガイド
            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ----------UPD 2010/09/09------------<<<<<
            // ログイン拠点
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SECTIONTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // ログイン拠点名
            ToolBase loginName = this.tToolsManager_MainMenu.Tools[TOOLBAR_SECTIONNAMELABEL_KEY];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    loginName.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // アイコン設定
            this._imageList16 = IconResourceManagement.ImageList16;

            this.uButton_SectionGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionCodeAllowZero.Text = SECTION_CD;
            this.tEdit_SectionName.Text = SECTION_NM;
            this._preSectionCd = SECTION_CD;
            this._preSectionNm = SECTION_NM;
            // 単価種類
            this.tComboEditor_UnitPriceKind.SelectedIndex = 0;

            if (!this._initMode)
            {
                this.InitialDataGrid();
            }

            // フォーカスの設定
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// グリッドの初期化処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッドの初期化処理を行う。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void InitialDataGrid()
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }
            int status = 0;
            string errMess = string.Empty;
            this._rateProtyMngDataTable.Rows.Clear();

            // 掛率優先管理マスタ読み込み
            RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();
            rateProtyMngWork.EnterpriseCode = this._enterpriseCode;
            // 拠点
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                rateProtyMngWork.SectionCode = SECTION_CD;
            }
            else
            {
                rateProtyMngWork.SectionCode = tEdit_SectionCodeAllowZero.Text.Trim();
            }
            //単価種類
            rateProtyMngWork.UnitPriceKind = tComboEditor_UnitPriceKind.SelectedIndex + 1;

            status = this._rateProtyMngPatternAcs.Search(rateProtyMngWork, out errMess);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                this.uGrid_Detail.Focus();
                this.uGrid_Detail.ActiveRow = this.uGrid_Detail.Rows[0];
                this.uGrid_Detail.ActiveRow.Selected = true;
            }
            else if(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "該当データが存在しません。",
                            0,
                            MessageBoxButtons.OK);
            }
            else
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMess,
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <br>Update Note : 2010/09/09 曹文傑</br>
        /// <br>            : Redmine#14490対応</br>
        private bool ReadSectionCodeAllowZeroName(out string code, out string name)
        {
            // 入力値を取得
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = tEdit_SectionName.Text;

            if (_preSectionCd == sectionCode)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionCode;
                return true;
            }

            // 00:全社
            if (sectionCode == SECTION_CD)
            {
                code = sectionCode;
                name = SECTION_NM;
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --------UPD 2010/09/09-------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    //name = sectionInfo.SectionGuideSnm.TrimEnd();
                    //return true;

                    if (sectionInfo.LogicalDeleteCode != 0)
                    {
                        code = _preSectionCd;
                        name = _preSectionNm;
                        return false;
                    }
                    else
                    {
                        code = sectionInfo.SectionCode.TrimEnd();
                        name = sectionInfo.SectionGuideSnm.TrimEnd();
                        return true;
                    }
                    // --------UPD 2010/09/09--------<<<<<
                }
                else
                {
                    code = _preSectionCd;
                    name = _preSectionNm;
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                return true;
            }
        }

        /// <summary>
        /// 選択明細データ取得
        /// </summary>
        /// <param name="gridRow">選択した明細データ</param>
        /// <param name="rateProtyMng">掛率優先管理マスタ</param>
        /// <br>Note       : 選択明細データ取得を行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private void GridDetailToRateProtyMng(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow, ref RateProtyMng rateProtyMng)
        {
            rateProtyMng.RateSettingDivide = (string)gridRow.Cells[this._rateProtyMngDataTable.RateSettingDivideColumn.ColumnName].Value;
            rateProtyMng.RatePriorityOrder = (int)gridRow.Cells[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Value;
            rateProtyMng.RateMngGoodsNm = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Value;
            rateProtyMng.RateMngCustNm = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Value;
            rateProtyMng.UnitPriceKind = (int)gridRow.Cells[this._rateProtyMngDataTable.UnitPriceKindColumn.ColumnName].Value;
            rateProtyMng.SectionCode = (string)gridRow.Cells[this._rateProtyMngDataTable.SectionCodeColumn.ColumnName].Value;
            rateProtyMng.RateMngCustCd = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngCustCdColumn.ColumnName].Value;
            rateProtyMng.RateMngGoodsCd = (string)gridRow.Cells[this._rateProtyMngDataTable.RateMngGoodsCdColumn.ColumnName].Value;
        }

        /// <summary>
        /// 選択明細データによって、各パターン画面の起動。
        /// </summary>
        /// <param name="rateProtyMng">掛率優先管理マスタ</param>
        /// <br>Note       : 選択明細データによって、各パターン画面を起動する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private void ShowChildForm(RateProtyMng rateProtyMng)
        {
            switch (rateProtyMng.RatePriorityOrder)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(品番指定)
                        PMKHN09472UA _pMKHN09472UA = new PMKHN09472UA(rateProtyMng);
                        _pMKHN09472UA.ShowDialog();
                        break;
                    }
                case 7:
                case 9:
                case 13:
                case 18:
                case 20:
                case 24:
                case 29:
                case 31:
                case 35:
                case 40:
                case 42:
                case 46:
                case 51:
                case 53:
                case 57:
                case 62:
                case 64:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(BLｺｰﾄﾞ指定)
                        PMKHN09477UA _pMKHN09477UA = new PMKHN09477UA(rateProtyMng);
                        _pMKHN09477UA.ShowDialog();
                        break;
                    }
                case 8:
                case 10:
                case 14:
                case 19:
                case 21:
                case 25:
                case 30:
                case 32:
                case 36:
                case 41:
                case 43:
                case 47:
                case 52:
                case 54:
                case 58:
                case 63:
                case 65:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(ｸﾞﾙｰﾌﾟｺｰﾄﾞ指定)
                        PMKHN09476UA _pMKHN09476UA = new PMKHN09476UA(rateProtyMng);
                        _pMKHN09476UA.ShowDialog();
                        break;
                    }
                case 11:
                case 15:
                case 22:
                case 26:
                case 33:
                case 37:
                case 44:
                case 48:
                case 55:
                case 59:
                case 66:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(商品掛率ｸﾞﾙｰﾌﾟ指定)
                        PMKHN09475UA _pMKHN09475UA = new PMKHN09475UA(rateProtyMng);
                        _pMKHN09475UA.ShowDialog();
                        break;
                    }
                case 12:
                case 23:
                case 34:
                case 45:
                case 56:
                case 67:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(層別指定)
                        PMKHN09474UA _pMKHN09474UA = new PMKHN09474UA(rateProtyMng);
                        _pMKHN09474UA.ShowDialog();
                        break;
                    }
                case 16:
                case 27:
                case 38:
                case 49:
                case 60:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(メーカー指定)
                        PMKHN09478UA _pMKHN09478UA = new PMKHN09478UA(rateProtyMng);
                        _pMKHN09478UA.ShowDialog();
                        break;
                    }
                case 17:
                case 28:
                case 39:
                case 50:
                case 61:
                case 68:
                case 69:
                case 70:
                case 71:
                    {
                        // 掛率設定マスタ（掛率優先管理ﾊﾟﾀｰﾝ）(単独指定)
                        PMKHN09473UA _pMKHN09473UA = new PMKHN09473UA(rateProtyMng);
                        _pMKHN09473UA.ShowDialog();
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
        }

        #region ■ uGrid_Detailの関連処理 ■

        #endregion ■ uGrid_Detailの関連処理 ■

        /// <summary>
        /// グリッド最上位行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面ヘッダクリア処理を行う。 </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void uGrid_Detail_GridKeyDownTopRow(object sender, EventArgs e)
        {
            this.tComboEditor_UnitPriceKind.Focus();
        }

        #region ◎ オフライン状態チェック処理
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : リモート接続可能判定を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #endregion ■ Private Method ■

        #region ■ イベント ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/09 李永平</br>
        /// <br>              Redmine#14492対応</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                //case "ButtonTool_New":// DEL 2010/09/09
                case "ButtonTool_Clear":// ADD 2010/09/09
                    {
                        // クリア処理
                        ClearScreen();
                        break;
                    }
                 // -------ADD 2010/09/09------->>>>>
                case "ButtonTool_Guide":
                    {
                        // ガイド処理
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            uButton_SectionGuide_Click(sender, e);
                        }
                        
                        break;
                    }
                // --------ADD 2010/09/09-------<<<<<
            }
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/08/26 呉元嘯</br>
        /// <br>              Redmine#13690対応</br>
        /// </remarks>
        private void uGrid_Detail_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Detail.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            }

            // ----------UPD 2010/08/26--------->>>>>

            // 表示順位
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // Fix設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.Fixed = true;

            // タイトル設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.Caption = "掛率優先順位";
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.Caption = "掛率設定名称(得意先)";
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.Caption = "掛率設定名称(商品)";

            // タイトルの詰め方
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // 入力許可設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 表示幅設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Width = 100;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Width = 180;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Width = 180;

            // 固定列設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // 詰め方設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // Style設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // 非表示設定
            band.Columns[this._rateProtyMngDataTable.RatePriorityOrderColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngDataTable.RateMngCustNmColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngDataTable.RateMngGoodsNmColumn.ColumnName].Hidden = false;
            // ----------UPD 2010/08/26---------<<<<<

        }

        /// <summary>
        /// Button_Click イベント(SectionGuide_Click)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // -----------ADD 2010/09/09 -------------->>>>>
            #region ■ガイド有効無効の設定
                this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
            #endregion
            // -----------ADD 2010/09/09 --------------<<<<<
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.Trim();
                // 拠点が変更して場合
                if (_preSectionCd != sectionInfo.SectionCode.Trim())
                {
                    this.InitialDataGrid();
                }
                this._preSectionCd = sectionInfo.SectionCode.Trim();
                this._preSectionNm = sectionInfo.SectionGuideSnm.Trim();
                // 次フォーカス
                this.tComboEditor_UnitPriceKind.Focus();
            }

        }

        /// <summary>
        /// ChangeFocus イベント(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // 拠点
                //-----------------------------------------------------
                case "tEdit_SectionCodeAllowZero":
                    {
                        # region [拠点]
                        string inputValue = this.tEdit_SectionCodeAllowZero.Text;

                        string code;
                        string name;
                        bool status = ReadSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.tEdit_SectionName.Text = name;

                            // 拠点が変更して場合
                            if (_preSectionCd != code)
                            {
                                this.InitialDataGrid();
                            }
                            _preSectionCd = code;
                            _preSectionNm = name;


                            #region [フォーカス制御]
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_UnitPriceKind;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                            #endregion [フォーカス制御]
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点コードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.tEdit_SectionName.Text = name;
                            this.tEdit_SectionCodeAllowZero.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        # endregion
                        break;
                    }
                //-----------------------------------------------------
                // 拠点ボタン
                //-----------------------------------------------------
                case "uButton_SectionGuide":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tComboEditor_UnitPriceKind;
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // 単価種類
                //-----------------------------------------------------
                case "tComboEditor_UnitPriceKind":
                    {
                        # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // 移動しない
                                        e.NextCtrl = this.uGrid_Detail;
                                        if ((this.uGrid_Detail.ActiveRow == null) && (this.uGrid_Detail.Rows.Count != 0))
                                        {
                                            this.uGrid_Detail.ActiveRow = this.uGrid_Detail.Rows[0];
                                            this.uGrid_Detail.ActiveRow.Selected = true;
                                        }
                                        else if (this.uGrid_Detail.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else
                                        {
                                            this.uGrid_Detail.ActiveRow.Selected = true;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // 明細
                //-----------------------------------------------------
                case "uGrid_Detail":
                    {
                       # region [フォーカス制御]
                        // フォーカス制御
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this.uGrid_Detail.ActiveRow != null)
                                        {
                                            int rowIndex = this.uGrid_Detail.ActiveRow.Index;

                                            #region [選択明細データ取得]
                                            RateProtyMng rateProtyMng = new RateProtyMng();
                                            GridDetailToRateProtyMng(this.uGrid_Detail.Rows[rowIndex], ref rateProtyMng);
                                            #endregion [選択明細データ取得]

                                            // 選択明細データによって、各パターン画面を起動する
                                            ShowChildForm(rateProtyMng);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                       break;
                    }
            }

            // ---ADD 2010/09/09---------------------->>>>>
            #region ■ガイド有効無効の設定
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
            }
            else
            {
                this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<<<

        }

        /// <summary>
        /// uGrid_Detail_DoubleClickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : uGrid_Detail_DoubleClickイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private void uGrid_Detail_DoubleClick(object sender, EventArgs e)
        {
            if (this.uGrid_Detail.ActiveRow == null) return;

            int rowIndex = this.uGrid_Detail.ActiveRow.Index;

            #region [選択明細データ取得]
            RateProtyMng rateProtyMng = new RateProtyMng();
            GridDetailToRateProtyMng(this.uGrid_Detail.Rows[rowIndex], ref rateProtyMng);
            #endregion [選択明細データ取得]

            // 選択明細データによって、各パターン画面を起動する
            ShowChildForm(rateProtyMng);
        }

        /// <summary>
        /// uGrid_Detail_KeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : uGrid_Detail_KeyDownイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        private void uGrid_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Detail.ActiveRow == null) return;

            // 最上行での↑キー
            if (this.uGrid_Detail.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (this.GridKeyDownTopRow != null)
                    {
                        this.GridKeyDownTopRow(this, new EventArgs());
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                    }

                }
            }
            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Homeキー
            if (e.KeyCode == Keys.Home)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // 先頭行に移動
                    this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // Endキー
            if (e.KeyCode == Keys.End)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // 最終行に移動
                    this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }

        /// <summary>
        /// tComboEditor_UnitPriceKind_ValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : tComboEditor_UnitPriceKind_ValueChangedイベントを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note : 2010/09/09 李永平</br>
        /// <br>              Redmine#14492対応</br>
        private void tComboEditor_UnitPriceKind_ValueChanged(object sender, EventArgs e)
        {
            // ---------ADD 2010/09/09-------------->>>>>
            if (this.tComboEditor_UnitPriceKind.Value!= null)
            {
                string str =this.tComboEditor_UnitPriceKind.Value.ToString();
                if (!Regex.IsMatch(str,"^[1-3]$"))
                {
                    this.tComboEditor_UnitPriceKind.Value = 1;
                }
                this.InitialDataGrid();
            }
            // ---------ADD 2010/09/09--------------<<<<<

            
        }

        // ---------ADD 2010/09/09-------------->>>>>
        /// <summary>
        /// Enterイベント
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : 李永平</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Enter(object sender, EventArgs e)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : 李永平</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : 李永平</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void tComboEditor_UnitPriceKind_Leave(object sender, EventArgs e)
        {
            if (this.tComboEditor_UnitPriceKind.Value == null)
            {
                    this.tComboEditor_UnitPriceKind.Value = 1;
                this.InitialDataGrid();
            }
        }
        // ---------ADD 2010/09/09-------------->>>>>
        #endregion ■ イベント ■

    }
}