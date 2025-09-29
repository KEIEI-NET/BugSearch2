//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価　得意先引用登録
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/09/01  修正内容 : #14019の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/09/06  修正内容 : #14238対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/09/08  修正内容 : #14384対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//-----ADD 2010/09/01---------->>>>>
using System.IO;
using Broadleaf.Application.Resources;
//-----ADD 2010/09/01----------<<<<<
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 単品売価　得意先引用登録UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 単品売価　得意先引用登録UIフォームクラス</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>Update Note : 2010/09/01 楊明俊 #14019の対応。</br>
    /// <br>Update Note : 2010/09/06 曹文傑 #14238対応</br>
    /// </remarks>
    public partial class PMKHN09461UD : Form
    {
        #region ■ Private Members
        private string _enterpriseCode;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, string> _custRateGrpDic;
        private SecInfoAcs _secInfoAcs = null;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;                           // 拠点情報設定アクセスクラス
        private UserGuideAcs _userGuideAcs = null;			                   // ユーザーガイドアクセスクラス
        private CustomerSearchAcs _customerSearchAcs = null;
        private MakerAcs _makerAcs;                                            // メーカーアクセスクラス
        private Dictionary<int, MakerUMnt> _makerDic;

        //-----ADD 2010/09/01---------->>>>>
        private GoodsRateSetUpdateFileConst _fileSetting;
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKHN09461U_Construction.XML";

        //-----ADD 2010/09/01----------<<<<<

        // 抽出条件前回入力値(更新有無チェック用)
        private string _OrigintmpSectionCode;
        private int _tmpCustomerCode = -1;
        private string _tmpSectionCode;
        private int _tmpCustomerCode1 = -1;
        private int _tmpCustomerCode2 = -1;
        private int _tmpCustomerCode3 = -1;
        private int _tmpCustomerCode4 = -1;
        private int _tmpCustomerCode5 = -1;
        private object _preComboEditorValue;

        // グリッド列
        public const string COLUMN_UPDATEDATETIME = "UpdateDateTime"; //処理日付
        public const string COLUMN_SECTIONCODE = "SectionCode"; //拠点
        public const string COLUMN_RATESETTINGDIVIDE = "RateSettingDivide";//掛率設定区分
        public const string COLUMN_CUSTRATEGRPCODE = "CustRateGrpCode"; //得意先掛率Ｇ
        public const string COLUMN_SUPPLIERCD = "SupplierCd";//仕入先
        public const string COLUMN_GOODSMAKERCD = "GoodsMakerCd";//メーカー
        public const string COLUMN_GOODSMAKERNAME = "GoodsMakerName";//メーカー名
        public const string COLUMN_BLGOODSCODE = "BLGoodsCode";   // ＢＬコード
        public const string COLUMN_GOODSNO = "GoodsNo";   // 品番
        public const string COLUMN_CONTENT = "Content";   // 内容

        /// <summary>チェック時メッセージ「ファイルへの出力に失敗しました。」</summary>
        private const string MSG_OUTPUTFILE_FAILED = "ファイルへの出力に失敗しました。";
        //-----UPD 2010/09/01---------->>>>>
        ///// <summary>テキストエクスポート成功時メッセージ「 行のデータをファイルへ出力しました。」</summary>
        //private const string MSG_OUTPUTFILE_SUCCEEDED = "行のデータをファイルへ出力しました。";
        /// <summary>テキストエクスポート成功時メッセージ「 行のデータをチェックリストへ出力しました。」</summary>
        private const string MSG_OUTPUTFILE_SUCCEEDED = "行のデータをチェックリストへ出力しました。";
        //-----UPD 2010/09/01---------->>>>>

        private GoodsRateSetSearchParam _extrInfo;

        private string _customerTag;

        private const string CUSTOMERNOFOUND = "未登録";

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
        private const string ctGUIDE_NAME_OriginSectionGuide = "OriginSectionGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_Customer1Guide = "Customer1Guide";
        private const string ctGUIDE_NAME_Customer2Guide = "Customer2Guide";
        private const string ctGUIDE_NAME_Customer3Guide = "Customer3Guide";
        private const string ctGUIDE_NAME_Customer4Guide = "Customer4Guide";
        private const string ctGUIDE_NAME_Customer5Guide = "Customer5Guide";

        private CustomerCodeRateSetUpdateAcs _goodsRateSetUpdateAcs;           // 単品売価設定一括登録・修正アクセスクラス

        DataTable _dataTable;

        //-----ADD 2010/09/01---------->>>>>
        #region プロパティ
        public GoodsRateSetUpdateFileConst FileSetting
        {
            get { return this._fileSetting; }
        }
        #endregion プロパティ
        //-----ADD 2010/09/01----------<<<<<
        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// 単品売価　得意先引用登録UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 単品売価　得意先引用登録UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/01 楊明俊 #14019の３の対応。</br>
        /// </remarks>
        public PMKHN09461UD(GoodsRateSetSearchParam extrInfo)
        {
            InitializeComponent();


            _extrInfo = extrInfo;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            _goodsRateSetUpdateAcs = new CustomerCodeRateSetUpdateAcs();
            this._makerAcs = new MakerAcs();
            //-----ADD 2010/09/01---------->>>>>
            this._fileSetting = new GoodsRateSetUpdateFileConst();
            //-----ADD 2010/09/01----------<<<<<
            // 各種マスタ読込
            LoadSecInfoSet();
            GetCustRateGrp();
            ReadMakerUMnt();

            // 画面初期設定
            SetInitialSetting();

            // 画面クリア
            ClearScreen();
            //-----ADD 2010/08/31---------->>>>>
            //-----UPD 2010/09/01---------->>>>>
            this._fileSetting = new GoodsRateSetUpdateFileConst();
            Deserialize();
            if (_fileSetting != null)
            {
                this.tEdit_SettingFileName.Text = _fileSetting.OutputFileName;
            }
            //if (!string.IsNullOrEmpty(_extrInfo.FileName))
            //{
            //    this.tEdit_SettingFileName.Text = _extrInfo.FileName;

            //}

            //-----UPD 2010/09/01----------<<<<<

            //-----ADD 2010/08/31----------<<<<<
        }

        #endregion ■ Constructor

        #region ■ Private Methods

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            _closeButton = (ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            _closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            _saveButton = (ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            _saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            _guideButton = (ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Guide"];
            _guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            this._guideEnableControlDictionary.Add(this.tEdit_OriginSectionCodeAllowZeroG.Name, ctGUIDE_NAME_OriginSectionGuide);        // 引用元設定.拠点
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero.Name, ctGUIDE_NAME_CustomerGuide);                          // 引用元設定.得意先コード
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);                    // 引用先設定.拠点
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero1.Name, ctGUIDE_NAME_Customer1Guide);                        // 引用先設定.得意先コード1
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero2.Name, ctGUIDE_NAME_Customer2Guide);                        // 引用先設定.得意先コード2
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero3.Name, ctGUIDE_NAME_Customer3Guide);                        // 引用先設定.得意先コード3
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero4.Name, ctGUIDE_NAME_Customer4Guide);                        // 引用先設定.得意先コード4
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero5.Name, ctGUIDE_NAME_Customer5Guide);                        // 引用先設定.得意先コード5

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.OriginSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_FileSelect.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }
        #endregion 初期設定

        #region クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点コード
            this._tmpSectionCode = "00";
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "全社";

            this._OrigintmpSectionCode = "00";
            this.tEdit_OriginSectionCodeAllowZeroG.DataText = "00";
            this.tEdit_OriginSectionName.DataText = "全社";

            // 区分
            this.tComboEditor_UpdateDiv.SelectedIndex = 0;
        }

        #endregion クリア処理

        #region マスタ読込
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void LoadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList">ユーザーガイドボディデータリスト</param>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報を取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            int status;
            ArrayList retList = new ArrayList();

            // ユーザーガイドデータ取得(得意先掛率グループ)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerDic = new Dictionary<int, MakerUMnt>();
            }
        }

        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードに該当する拠点略称を取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "全社";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }



        /// 得意先掛率グループ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <returns>得意先掛率グループ名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ名称を取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            string custRateGrpName = "";

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                custRateGrpName = (string)this._custRateGrpDic[custRateGrpCode];
            }

            return custRateGrpName;
        }

        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note        : メーカーコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            if (this._makerDic.ContainsKey(makerCode))
            {
                return this._makerDic[makerCode].MakerName.Trim();
            }

            return "";
        }
        #endregion 名称取得

        # region ガイド起動処理
        /// <summary>
        /// ガイドボタンツール有効無効設定処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                        (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            // 明細部にフォーカスがある時は明細画面に従って設定する
            if (this._guideEnableControlDictionary.ContainsKey(targetControl.Name))
            {
                this._guideButton.SharedProps.Enabled = true;
                this._guideButton.SharedProps.Tag = this._guideEnableControlDictionary[targetControl.Name];
            }
            else
            {
                this._guideButton.SharedProps.Enabled = false;
                this._guideButton.SharedProps.Tag = string.Empty;
            }
        }

        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイド起動処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void ExecuteGuide()
        {
            if (_guideButton.SharedProps.Tag != null)
            {
                switch (_guideButton.SharedProps.Tag.ToString())
                {
                    case ctGUIDE_NAME_OriginSectionGuide:
                        {
                            this.OriginSectionGuide_Button_Click(this.OriginSectionGuide_Button, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGuide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_SectionGuide:
                        {
                            this.OriginSectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer1Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide1, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer2Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide2, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer3Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide3, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer4Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide4, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer5Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGrpGuide5, new EventArgs());
                            break;
                        }
                }
            }
        }
        # endregion　ガイド起動処理

        #region 保存
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        /// <br>Update Note : 2010/09/01 楊明俊 #14019の対応。</br>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            List<GoodsRateSetSearchResult> rateSearchResultList;

            // 画面情報チェック
            bool bStatus = CheckSaveCondition();
            if (!bStatus)
            {
                return -1;
            }
            // 画面情報取得
            SetExtrInfo(ref this._extrInfo);

            // 更新処理
            status = this._goodsRateSetUpdateAcs.CustomerUpdateGrp(out rateSearchResultList,this._extrInfo);

            if (status == 0 && rateSearchResultList.Count != 0)
            {
                status = ExportIntoTextFile(rateSearchResultList);
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                   "検索条件に該当するデータが存在しません。",
                   status,
                   MessageBoxButtons.OK,
                   MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.DialogResult = DialogResult.OK;
                //-----ADD 2010/09/01---------->>>>>
                _fileSetting.OutputFileName = this.tEdit_SettingFileName.Text.ToUpper();
                //-----ADD 2010/09/01----------<<<<<
                this.Close();
            }

            return (status);
        }

        /// <summary>
        /// 保存処理チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 保存処理をチェックします。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/08/31 楊明俊 #14019の２の対応。</br>
        /// </remarks>
        private bool CheckSaveCondition()
        {
            string errMsg = "";
            Control nextCtrl = null;

            try
            {
                // 引用元　得意先コード
                if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero.Text.Trim()))
                {
                    errMsg = "引用元情報が設定されてません。";
                    this.tNedit_CustRateGrpCodeZero.Focus();
                    nextCtrl = this.tNedit_CustRateGrpCodeZero;
                    return (false);
                }

                // 引用先　得意先コード
                if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim()))
                {
                    errMsg = "引用先情報が設定されてません。";
                    this.tNedit_CustRateGrpCodeZero1.Focus();
                    nextCtrl = this.tNedit_CustRateGrpCodeZero1;
                    return (false);
                }
                //-----ADD 2010/08/31---------->>>>>
                if (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().Equals(this.tEdit_SectionCodeAllowZero.DataText.Trim()))
                {
                //-----ADD 2010/08/31----------<<<<<
                    if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero1.Text.Trim())
                    {
                        errMsg = "引用元、引用先の得意先掛率グループ設定が不正です。";
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero1;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    {
                        errMsg = "引用元、引用先の得意先掛率グループ設定が不正です。";
                        this.tNedit_CustRateGrpCodeZero2.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero2;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero3.Text.Trim())
                    {
                        errMsg = "引用元、引用先の得意先掛率グループ設定が不正です。";
                        this.tNedit_CustRateGrpCodeZero3.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero3;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    {
                        errMsg = "引用元、引用先の得意先掛率グループ設定が不正です。";
                        this.tNedit_CustRateGrpCodeZero4.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero4;
                        return (false);
                    }
                    else if (this.tNedit_CustRateGrpCodeZero.Text.Trim() == this.tNedit_CustRateGrpCodeZero5.Text.Trim())
                    {
                        errMsg = "引用元、引用先の得意先掛率グループ設定が不正です。";
                        this.tNedit_CustRateGrpCodeZero5.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero5;
                        return (false);
                    }
                //-----ADD 2010/08/31---------->>>>>
                }
                //-----ADD 2010/08/31----------<<<<<

                // 引用先　ファイル名
                if (this.tEdit_SettingFileName.DataText.Trim() == "")
                {
                    errMsg = "ファイル名が設定されていません。";
                    this.tEdit_SettingFileName.Focus();
                    nextCtrl = this.tEdit_SettingFileName;
                    return (false);
                }
            }
            finally
            {
                this.SettingGuideButtonToolEnabled(nextCtrl);
                if (errMsg.Length > 0)
                {
                    DialogResult dResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        errMsg,
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }
            }

            return (true);

        }

        /// <summary>
        /// 保存処理条件設定処理
        /// </summary>
        /// <param name="para">保存処理条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報から保存処理条件を設定します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void SetExtrInfo(ref GoodsRateSetSearchParam para)
        {
            // 引用元.拠点
            if ((this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim() == "") ||
                (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                para.SectionCode = null;
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().PadLeft(2, '0');
            }

            //引用先.拠点コード
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                para.PrmSectionCode = null;
            }
            else
            {
                para.PrmSectionCode = new string[1];
                para.PrmSectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            //引用元.得意先掛率
            para.CustRateGrpCode = new int[6];

            para.CustRateGrpCode[0] = tNedit_CustRateGrpCodeZero.GetInt();

            //引用先.得意先コード1～5
            if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero1.Text))
            {
                para.CustRateGrpCode[1] = tNedit_CustRateGrpCodeZero1.GetInt();
            }
            else
            {
                para.CustRateGrpCode[1] = -1;
            }

            if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero2.Text))
            {
                para.CustRateGrpCode[2] = tNedit_CustRateGrpCodeZero2.GetInt();
            }
            else
            {
                para.CustRateGrpCode[2] = -1;
            }

            if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero3.Text))
            {
                para.CustRateGrpCode[3] = tNedit_CustRateGrpCodeZero3.GetInt();
            }
            else
            {
                para.CustRateGrpCode[3] = -1;
            }

            if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero4.Text))
            {
                para.CustRateGrpCode[4] = tNedit_CustRateGrpCodeZero4.GetInt();
            }
            else
            {
                para.CustRateGrpCode[4] = -1;
            }

            if (!string.IsNullOrEmpty(tNedit_CustRateGrpCodeZero5.Text))
            {
                para.CustRateGrpCode[5] = tNedit_CustRateGrpCodeZero5.GetInt();
            }
            else
            {
                para.CustRateGrpCode[5] = -1;
            }

            //更新区分
            para.ObjectDiv = this.tComboEditor_UpdateDiv.Value.ToString();

        }

        /// <summary>
        /// テキスト出力します。
        /// </summary>
        /// <br>Update Note : 2010/08/31 楊明俊 #14019の２の対応。</br>
        private int ExportIntoTextFile(List<GoodsRateSetSearchResult> rateSearchResultList)
        {
            String typeStr = string.Empty;
            Char typeChar = new char();
            Byte typeByte = new byte();
            DateTime typeDate = new DateTime();
            Int16 typeInt16 = new short();
            Int32 typeInt32 = new int();
            Int64 typeInt64 = new long();
            Single typeSingle = new float();
            Double typeDouble = new double();
            Decimal typeDecimal = new decimal();

            FormattedTextWriter tw = new FormattedTextWriter();
            List<String> schemeList = new List<string>();
            schemeList.Add(COLUMN_UPDATEDATETIME);
            schemeList.Add(COLUMN_SECTIONCODE);
            schemeList.Add(COLUMN_RATESETTINGDIVIDE);
            schemeList.Add(COLUMN_CUSTRATEGRPCODE);
            schemeList.Add(COLUMN_SUPPLIERCD);
            schemeList.Add(COLUMN_GOODSMAKERCD);
            schemeList.Add(COLUMN_GOODSMAKERNAME);
            schemeList.Add(COLUMN_BLGOODSCODE);
            schemeList.Add(COLUMN_GOODSNO);
            schemeList.Add(COLUMN_CONTENT);

            // 出力項目名
            tw.SchemeList = schemeList;
            string content = string.Empty;
            _dataTable.Rows.Clear();

            foreach(GoodsRateSetSearchResult result in rateSearchResultList)
            {
                content = string.Empty;
                DataRow dataRow = _dataTable.NewRow();

                dataRow[COLUMN_UPDATEDATETIME] = TDateTime.DateTimeToString("YYYY/MM/DD",DateTime.Now) ;
                dataRow[COLUMN_SECTIONCODE] = result.SectionCode;
                dataRow[COLUMN_RATESETTINGDIVIDE] = result.RateSettingDivide;
                dataRow[COLUMN_CUSTRATEGRPCODE] = result.CustRateGrpCode.ToString("0000");

                dataRow[COLUMN_SUPPLIERCD] = result.SupplierCd.ToString("000000");
                dataRow[COLUMN_GOODSMAKERCD] = result.GoodsMakerCd.ToString("0000");
                dataRow[COLUMN_GOODSMAKERNAME] = GetMakerName(result.GoodsMakerCd);
                dataRow[COLUMN_BLGOODSCODE] = result.BLGoodsCode.ToString("00000");
                dataRow[COLUMN_GOODSNO] = result.GoodsNo;

                if (result.UpdateDiv == 1)
                {
                    content = "売価ﾚｺｰﾄﾞは引用元と同値で存在します";
                }
                else
                {
                    //売価額が変更時
                    if (result.BfPriceFl != result.PriceFl)
                    {
                        content += "売価額は" + result.BfPriceFl.ToString("########0.00") + "→" + result.PriceFl.ToString("########0.00") ;
                    }
                    //売価率が変更時
                    if (result.BfRateVal != result.RateVal)
                    {
                        if (!string .IsNullOrEmpty(content))
                        {
                            content += "、";
                        }

                        content += "売価率は" + result.BfRateVal.ToString("##0.00") + "→" + result.RateVal.ToString("##0.00");
                    }
                    //原価UP率が変更時
                    if (result.BfUpRate != result.UpRate)
                    {
                        if (!string.IsNullOrEmpty(content))
                        {
                            content += "、";
                        }
                        content += "原価UP率は" + result.BfUpRate.ToString("##0.00") + "→" + result.UpRate.ToString("##0.00");
                    }
                    //粗利確保率が変更時
                    if (result.BfGrsProfitSecureRate != result.GrsProfitSecureRate)
                    {
                        if (!string.IsNullOrEmpty(content))
                        {
                            content += "、";
                        }
                        content += "粗利確保率は" + result.BfGrsProfitSecureRate.ToString("#0.00") + "→" + result.GrsProfitSecureRate.ToString("#0.00");
                    }

                    if (!string.IsNullOrEmpty(content))
                    {
                        content += "へ更新されました";
                    }
                }
                dataRow[COLUMN_CONTENT] = content;

                if (!string.IsNullOrEmpty(content))
                {
                    _dataTable.Rows.Add(dataRow);
                }
            }

            if (_dataTable.Rows.Count == 0) return 0;

            // データソース
            tw.DataSource = _dataTable.DefaultView;

            // グリッドのソート情報を適用する
            if (tw.DataSource is DataView)
            {
                (tw.DataSource as DataView).Sort = COLUMN_SECTIONCODE + "," + COLUMN_RATESETTINGDIVIDE + "," + COLUMN_CUSTRATEGRPCODE + "," + COLUMN_GOODSNO + "," + COLUMN_GOODSMAKERCD + " ASC";
            }

            #region オプションセット
            // ファイル名
            tw.OutputFileName = tEdit_SettingFileName.Text;
            // 区切り文字
            tw.Splitter = ",";
            // 項目括り文字
            tw.Encloser = "\"";
            // 固定幅
            tw.FixedLength = false;
            // タイトル行出力
            //-----UPD 2010/08/31---------->>>>>
            if (System.IO.File.Exists(tEdit_SettingFileName.Text))
            {
                tw.CaptionOutput = false;
            }
            else
            {
                tw.CaptionOutput = true;
            }
            //tw.CaptionOutput = true;
            //-----UPD 2010/08/31----------<<<<<
            // 終点行へ追加する
            tw.OutputMode = true;
            // 項目括り適用
            List<Type> enclosingList = new List<Type>();
            enclosingList.Add(typeInt16.GetType());
            enclosingList.Add(typeInt32.GetType());
            enclosingList.Add(typeInt64.GetType());
            enclosingList.Add(typeDouble.GetType());
            enclosingList.Add(typeDecimal.GetType());
            enclosingList.Add(typeSingle.GetType());
            enclosingList.Add(typeStr.GetType());
            enclosingList.Add(typeChar.GetType());
            enclosingList.Add(typeByte.GetType());
            enclosingList.Add(typeDate.GetType());
            tw.EnclosingTypeList = enclosingList;

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            if (status == 9)// 異常終了
            {
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILE_FAILED, -1, MessageBoxButtons.OK);
            }
            else
            {
                // 出力成功
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + MSG_OUTPUTFILE_SUCCEEDED, -1, MessageBoxButtons.OK);
            }

            return status;

            #endregion // オプション
        }


        #endregion 保存


        #endregion ■ Private Methods

        #region ■ Control Events
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/08/10</br>
        /// <br>Update Note: 2010/09/06 曹文傑 #14238対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 引用元設定.拠点コード
                #region 引用元設定.拠点コード
                case "tEdit_OriginSectionCodeAllowZeroG":
                    {

                        if (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim() == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._OrigintmpSectionCode = string.Empty;
                            this.tEdit_OriginSectionName.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim().Equals(this._OrigintmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero;
                                }
                            }
                            else
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Tab)
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // フォーカス移動
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }

                            break;
                        }
                        else
                        {
                            // 拠点コード取得
                            string sectionCode = this.tEdit_OriginSectionCodeAllowZeroG.DataText.Trim();

                            string sectionName = GetSectionName(sectionCode).Trim();

                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                // 結果を画面に設定
                                this.tEdit_OriginSectionName.DataText = sectionName;

                                // 設定値を保存
                                this._OrigintmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tEdit_OriginSectionCodeAllowZeroG.DataText = _OrigintmpSectionCode;

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "拠点が存在しません。",                             // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);								// 表示するボタン

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // フォーカス移動
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }

                        break;
                    }

                #endregion

                // 引用元設定.得意先掛率グループコード
                #region 引用元設定.得意先掛率グループコード
                case "tNedit_CustRateGrpCodeZero":
                    {
                        if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode = -1;
                            this.tEdit_CustomerGrpName.DataText = string.Empty;
                            this.tNedit_CustRateGrpCodeZero.Clear();

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustRateGrpCodeZero.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_CustomerGrpName.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero.DataText = customerCode.ToString("0000");

                            // 設定値を保存
                            this._tmpCustomerCode = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (_tmpCustomerCode == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero.SetInt(_tmpCustomerCode);
                            }

                            // 該当なし
                            TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "得意先掛率グループが存在しません。",               // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //引用先設定.拠点コード
                #region 引用先設定.拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpSectionCode = string.Empty;
                            this.tEdit_SectionName.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim().Equals(this._tmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero1;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // フォーカス移動
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<

                            break;
                        }
                        else
                        {
                            // 拠点コード取得
                            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                            string sectionName = GetSectionName(sectionCode).Trim();

                            if (!string.IsNullOrEmpty(sectionName))
                            {
                                // 結果を画面に設定
                                this.tEdit_SectionName.DataText = sectionName;

                                // 設定値を保存
                                this._tmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tEdit_SectionCodeAllowZero.DataText = _tmpSectionCode;

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "拠点が存在しません。",                             // 表示するメッセージ
                                    -1,													// ステータス値
                                    MessageBoxButtons.OK);								// 表示するボタン

                                e.NextCtrl = e.PrevCtrl;

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustRateGrpCodeZero1;
                                }
                            }
                            //-----DEL 2010/09/06---------->>>>>
                            //else
                            //{
                            //    if (e.Key == Keys.Tab)
                            //    {
                            //        // フォーカス移動
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            //-----DEL 2010/09/06----------<<<<<
                        }

                        break;
                    }

                #endregion

                //引用先設定.得意先掛率グループコード1
                #region 引用先設定.得意先掛率グループコード1
                case "tNedit_CustRateGrpCodeZero1":
                    {
                        if (this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == "")
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode1 = -1;
                            this.tEdit_CustomerGrpName1.DataText = string.Empty;

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustRateGrpCodeZero1.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_CustomerGrpName1.DataText = customerName;


                            this.tNedit_CustRateGrpCodeZero1.DataText = customerCode.ToString("0000");

                            // 設定値を保存
                            this._tmpCustomerCode1 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerCode1 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero1.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero1.SetInt(_tmpCustomerCode1);
                            }

                            // 該当なし
                            TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "得意先掛率グループが存在しません。",               // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero2;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                //引用先設定.得意先掛率グループコード2
                #region 引用先設定.得意先掛率グループコード2
                case "tNedit_CustRateGrpCodeZero2":
                    {
                        if (this.tNedit_CustRateGrpCodeZero2.DataText.Trim() == "")
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode2 = -1;
                            this.tEdit_CustomerGrpName2.DataText = string.Empty;

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustRateGrpCodeZero2.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_CustomerGrpName2.DataText = customerName;


                            this.tNedit_CustRateGrpCodeZero2.DataText = customerCode.ToString("0000");

                            // 設定値を保存
                            this._tmpCustomerCode2 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerCode2 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero2.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero2.SetInt(_tmpCustomerCode2);
                            }

                            // 該当なし
                            TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "得意先掛率グループが存在しません。",               // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero3;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //引用先設定.得意先掛率グループコード3
                #region 引用先設定.得意先掛率グループコード3
                case "tNedit_CustRateGrpCodeZero3":
                    {
                        if (this.tNedit_CustRateGrpCodeZero3.DataText.Trim() == "")
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode3 = -1;
                            this.tEdit_CustomerGrpName3.DataText = string.Empty;

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustRateGrpCodeZero3.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_CustomerGrpName3.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero3.DataText = customerCode.ToString("0000");

                            // 設定値を保存
                            this._tmpCustomerCode3 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerCode3 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero3.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero3.SetInt(_tmpCustomerCode3);
                            }

                            // 該当なし
                            TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "得意先掛率グループが存在しません。",               // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero4;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                //引用先設定.得意先掛率グループコード4
                #region 引用先設定.得意先掛率グループコード4
                case "tNedit_CustRateGrpCodeZero4":
                    {
                        if (this.tNedit_CustRateGrpCodeZero4.DataText.Trim() == "")
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode4 = -1;
                            this.tEdit_CustomerGrpName4.DataText = string.Empty;

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustRateGrpCodeZero4.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_CustomerGrpName4.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero4.DataText = customerCode.ToString("0000");

                            // 設定値を保存
                            this._tmpCustomerCode4 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerCode4 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero4.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero4.SetInt(_tmpCustomerCode4);
                            }

                            // 該当なし
                            TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "得意先掛率グループが存在しません。",               // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_CustRateGrpCodeZero5;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //引用先設定.得意先掛率グループコード5
                #region 引用先設定.得意先掛率グループコード5
                case "tNedit_CustRateGrpCodeZero5":
                    {
                        if (this.tNedit_CustRateGrpCodeZero5.DataText.Trim() == "")
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode5 = -1;
                            this.tEdit_CustomerGrpName5.DataText = string.Empty;

                            break;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustRateGrpCodeZero5.GetInt();

                        string customerName = GetCustRateGrpName(customerCode).Trim();

                        if (!string.IsNullOrEmpty(customerName))
                        {
                            // 結果を画面に設定
                            this.tEdit_CustomerGrpName5.DataText = customerName;

                            this.tNedit_CustRateGrpCodeZero5.DataText = customerCode.ToString("0000");

                            // 設定値を保存
                            this._tmpCustomerCode5 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerCode5 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero5.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero5.SetInt(_tmpCustomerCode5);
                            }

                            // 該当なし
                            TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                "得意先掛率グループが存在しません。",               // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);								// 表示するボタン

                            e.NextCtrl = e.PrevCtrl;

                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tComboEditor_UpdateDiv;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //引用先設定.更新区分
                #region 引用先設定.更新区分
                case "tComboEditor_UpdateDiv":
                    {
                        if (tComboEditor_UpdateDiv.Value == tComboEditor_UpdateDiv.Items[0].DataValue
                            || tComboEditor_UpdateDiv.Value == tComboEditor_UpdateDiv.Items[1].DataValue)
                        {
                            _preComboEditorValue = tComboEditor_UpdateDiv.Value;
                        }
                        else
                        {
                            tComboEditor_UpdateDiv.Value = _preComboEditorValue;
                        }

                        if (e.ShiftKey == false)
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tEdit_SettingFileName;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        e.NextCtrl = e.PrevCtrl;
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                #endregion

                //-----ADD 2010/09/06---------->>>>>
                //チェックリスト.ファイル名
                #region チェックリスト.ファイル名
                case "uButton_FileSelect":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion

                //ガイドボタンから→で、移動しない
                #region ガイドボタ
                case "OriginSectionGuide_Button":
                case "uButton_CustomerGrpGuide":
                case "SectionGuide_Button":
                case "uButton_CustomerGrpGuide1":
                case "uButton_CustomerGrpGuide2":
                case "uButton_CustomerGrpGuide3":
                case "uButton_CustomerGrpGuide4":
                case "uButton_CustomerGrpGuide5":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    }
                #endregion
                //-----ADD 2010/09/06----------<<<<<
            }

            //---------------------------------------------------------------
            // ボタンツール有効無効設定処理
            //---------------------------------------------------------------
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void OriginSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    //引用元設定.拠点コード
                    if (((UltraButton)sender).Tag.ToString().CompareTo("0") == 0)
                    {
                        this.tEdit_OriginSectionCodeAllowZeroG.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_OriginSectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // 設定値を保存
                        this._OrigintmpSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero);

                    }
                    //引用先設定.拠点コード
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // 設定値を保存
                        this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero1);
                    }
                    else
                    {
                        return;
                    }

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(CustRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 得意先掛率グループガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _customerTag = ((UltraButton)sender).Tag.ToString();
                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                // 得意先掛率グループガイド
                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);

                this.DialogResult = DialogResult.Retry;

                if (status == 0)
                {
                    //引用元設定.得意先掛率グループ
                    if (_customerTag.CompareTo("0") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode ||
                            this.tNedit_CustRateGrpCodeZero.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SettingGuideButtonToolEnabled(this.tEdit_SectionCodeAllowZero);
                    }
                    //引用先設定.得意先掛率グループ1
                    else if (_customerTag.CompareTo("1") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode1 ||
                            this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode1 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero1.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName1.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero2.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero2);
                    }
                    //引用先設定.得意先掛率グループ2
                    else if (_customerTag.CompareTo("2") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode2 ||
                            this.tNedit_CustRateGrpCodeZero2.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode2 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero2.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName2.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero3.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero3);
                    }
                    //引用先設定.得意先掛率グループ3
                    else if (_customerTag.CompareTo("3") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode3 ||
                            this.tNedit_CustRateGrpCodeZero3.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode3 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero3.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName3.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero4.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero4);
                    }
                    //引用先設定.得意先掛率グループ4
                    else if (_customerTag.CompareTo("4") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode4 ||
                            this.tNedit_CustRateGrpCodeZero4.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode4 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero4.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName4.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero5.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero5);
                    }
                    //引用先設定.得意先掛率グループ5
                    else if (_customerTag.CompareTo("5") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode5 ||
                            this.tNedit_CustRateGrpCodeZero5.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerCode5 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero5.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName5.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tComboEditor_UpdateDiv.Focus();
                        this.SettingGuideButtonToolEnabled(this.tComboEditor_UpdateDiv);
                    }

                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームクロージングイベントに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/01 楊明俊 #14019の３の対応。</br>
        /// </remarks>
        private void PMKHN09461UD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
            //-----ADD 2010/09/01---------->>>>>
            else 
            {
                Serialize();
            }
            //-----ADD 2010/09/01----------<<<<<
        }

        //-----ADD 2010/09/01---------->>>>>
        /// <summary>
        ///  単品売価設定一括登録・修正のシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       :  単品売価設定一括登録・修正のシリアライズを行います。</br>
        /// <br>Programmer :  楊明俊</br>
        /// <br>Date       :  2010/09/01</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_fileSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// 単品売価設定一括登録・修正のデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 単品売価設定一括登録・修正クラスをデシリアライズします。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/09/01</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._fileSetting = UserSettingController.DeserializeUserSetting<GoodsRateSetUpdateFileConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                catch
                {
                    this._fileSetting = new GoodsRateSetUpdateFileConst();
                }
            }
        }
        //-----ADD 2010/09/01----------<<<<<

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();

                        break;
                    }
                case "ButtonTool_Save":
                    {
                        Control nextControl = null;
                        Control preControl = null;

                        ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GetActiveControl(), nextControl);
                        preControl = ex.PrevCtrl;
                        this.tRetKeyControl1_ChangeFocus(this, ex);

                        // 保存処理
                        if (preControl != ex.NextCtrl)
                        {
                            Save();
                        }
                        break;
                    }
                case "ButtonTool_Guide":
                    {
                        // ガイド起動処理
                        this.ExecuteGuide();

                        break;
                    }
            }
        }

        /// <summary>
        /// アクティブコントロール取得処理
        /// </summary>
        /// <returns></returns>
        private Control GetActiveControl()
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                ctrl = this.GetParentControl(ctrl);
            }

            return ctrl;
        }

        /// <summary>
        /// 親コントロール取得処理
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private Control GetParentControl(Control ctrl)
        {
            Control retCtrl = ctrl;
            if (ctrl.Parent != null)
            {
                if ((ctrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    //retCtrl = ctrl.Parent;
                    retCtrl = GetParentControl(ctrl.Parent);
                }
            }

            return retCtrl;
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_OriginSectionCodeAllowZeroG.Focus();

            this.SettingGuideButtonToolEnabled(this.tEdit_OriginSectionCodeAllowZeroG);

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09461UD_Load(object sender, EventArgs e)
        {
            // グリッドデータ設定
            CreateGrid();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <param name="displayList">表示データリスト</param>
        /// <remarks>
        /// <br>Note        : グリッドの列を作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public void CreateGrid()
        {
            _dataTable = new DataTable();
            // 処理日付
            _dataTable.Columns.Add(COLUMN_UPDATEDATETIME, typeof(string));
            // 拠点
            _dataTable.Columns.Add(COLUMN_SECTIONCODE, typeof(string));
            // 掛率設定区分
            _dataTable.Columns.Add(COLUMN_RATESETTINGDIVIDE, typeof(string));
            // 得意先掛率Ｇ
            _dataTable.Columns.Add(COLUMN_CUSTRATEGRPCODE, typeof(string));
            // 仕入先
            _dataTable.Columns.Add(COLUMN_SUPPLIERCD, typeof(string));
            // メーカー
            _dataTable.Columns.Add(COLUMN_GOODSMAKERCD, typeof(string));
            // メーカー名
            _dataTable.Columns.Add(COLUMN_GOODSMAKERNAME, typeof(string));
            // ＢＬコード
            _dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
            // 品番
            _dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // 内容
            _dataTable.Columns.Add(COLUMN_CONTENT, typeof(string));

            _dataTable.Columns[COLUMN_UPDATEDATETIME].Caption = "処理日付";
            _dataTable.Columns[COLUMN_SECTIONCODE].Caption = "拠点";
            _dataTable.Columns[COLUMN_RATESETTINGDIVIDE].Caption = "掛率設定区分";
            _dataTable.Columns[COLUMN_CUSTRATEGRPCODE].Caption = "得意先掛率Ｇ";
            _dataTable.Columns[COLUMN_SUPPLIERCD].Caption = "仕入先";
            _dataTable.Columns[COLUMN_GOODSMAKERCD].Caption = "メーカー";
            _dataTable.Columns[COLUMN_GOODSMAKERNAME].Caption = "メーカー名";
            _dataTable.Columns[COLUMN_BLGOODSCODE].Caption = "ＢＬコード";
            _dataTable.Columns[COLUMN_GOODSNO].Caption = "品番";
            _dataTable.Columns[COLUMN_CONTENT].Caption = "内容";
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/08/31 楊明俊 #14019の２の対応。</br>
        /// <br>Update Note : 2010/09/01 楊明俊 #14019の３の対応。</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            //-----UPD 2010/09/01---------->>>>>
            //if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text) && System.IO.File.Exists(tEdit_SettingFileName.Text))
            //-----UPD 2010/09/01----------<<<<<
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            //-----ADD 2010/08/31---------->>>>>
            //-----UPD 2010/09/01---------->>>>>
            string strPath = Environment.GetEnvironmentVariable("USERPROFILE");
            strPath += "\\My Documents";
            this.openFileDialog.InitialDirectory = strPath;
            //this.openFileDialog.Filter = string.Format("CSV(.CSV) | *.CSV; | 全てのファイル(.*) | *.*");
            //this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.Filter = string.Format("CSVファイル(*.CSV) | *.CSV; |すべてのファイル(*.*) | *.*");
            string fileNameWithExt = Path.GetFileName(this.tEdit_SettingFileName.Text.ToUpper());
            this.openFileDialog.FilterIndex = GoodsRateSetUpdateFileConst.getExt(fileNameWithExt);
            //-----UPD 2010/09/01----------<<<<<
            //-----ADD 2010/08/31----------<<<<<

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
                //-----DEL 2010/09/01---------->>>>>
                ////-----ADD 2010/08/31---------->>>>>
                //_extrInfo.FileName = openFileDialog.FileName.ToUpper();
                ////-----ADD 2010/08/31----------<<<<<
                //-----DEL 2010/09/01----------<<<<<
            }
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

            this.tNedit_CustRateGrpCodeZero.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero.SelectAll();
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero1_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero1.GetInt();

            this.tNedit_CustRateGrpCodeZero1.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero1.SelectAll();
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero2_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero2.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero2.GetInt();

            this.tNedit_CustRateGrpCodeZero2.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero2.SelectAll();
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero3_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero3.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero3.GetInt();

            this.tNedit_CustRateGrpCodeZero3.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero3.SelectAll();
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero4_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero4.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero4.GetInt();

            this.tNedit_CustRateGrpCodeZero4.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero4.SelectAll();
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero5_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero5.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero5.GetInt();

            this.tNedit_CustRateGrpCodeZero5.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero5.SelectAll();
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 対象区分コンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/08 朱 猛 #14384対応</br>
        /// </remarks>
        private void tComboEditor_UpdateDiv_SelectionChanged(object sender, EventArgs e)
        {
            //---UPD 2010/09/08------------------>>>>> 
            //_preComboEditorValue = tComboEditor_UpdateDiv.Value;
            if (this.tComboEditor_UpdateDiv.Value != null)
            {
                _preComboEditorValue = tComboEditor_UpdateDiv.Value;
            }
            //---UPD 2010/09/08------------------<<<<<
        }

        #endregion ■ Control Events

    }
    //-----ADD 2010/09/01---------->>>>>
    /// <summary>
    /// ファイル名設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ファイル名設定情報を管理するクラス</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2010/09/01</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsRateSetUpdateFileConst
    {

        # region プライベート変数

        // 出力ファイル名
        private string _outputFileName;

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// ファイル名設定情報クラス
        /// </summary>
        public GoodsRateSetUpdateFileConst()
        {

        }

        # endregion // コンストラクタ

        # region プロパティ

        /// <summary>出力ファイル名</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        # endregion

        /// <summary>
        /// 得意先電子元帳ユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>得意先電子元帳ユーザー設定情報クラス</returns>
        public GoodsRateSetUpdateFileConst Clone()
        {
            GoodsRateSetUpdateFileConst constObj = new GoodsRateSetUpdateFileConst();
            return constObj;
        }

        /// <summary>
        /// ファイル拡張子取得処理
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int getExt(string fileName)
        {
            int newExt = -1;
            if (string.IsNullOrEmpty(fileName))
            {
                newExt = 1;
            }
            else if (fileName.Contains("."))
            {
                string[] fileNameArr = fileName.Split(new Char[] { '.' });
                if ("CSV".Equals(fileNameArr[fileNameArr.Length - 1]))
                {
                    newExt = 1;
                }
                else
                {
                    newExt = 2;
                }
            }
            else
            {
                newExt = 2;
            }
            return newExt;
        }
    }
    //-----ADD 2010/09/01---------->>>>>
}