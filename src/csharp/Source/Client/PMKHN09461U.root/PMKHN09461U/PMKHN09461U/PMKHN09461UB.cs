//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/08/31  修正内容 : #13972①②の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/09/03  修正内容 : #13972の6の対応
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
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 単品売価　得意先引用登録UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 単品売価　得意先引用登録UIフォームクラス</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2010/08/04</br>
    /// <br>Update Note : 2010/08/31 楊明俊 #13972②の対応。</br>
    /// <br>Update Note : 2010/09/03 楊明俊 #13972の６の対応</br>
    /// <br>Update Note : 2010/09/06 曹文傑 #14238対応</br>
    /// </remarks>
    public partial class PMKHN09461UB : Form
    {
        #region ■ Private Members
        private string _enterpriseCode;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, string> _custRateGrpDic;
        private SecInfoAcs _secInfoAcs = null;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;                           // 拠点情報設定アクセスクラス
        private CustomerSearchAcs _customerSearchAcs = null;
        private UserGuideAcs _userGuideAcs = null;			                   // ユーザーガイドアクセスクラス

        // 抽出条件前回入力値(更新有無チェック用)
        private string _OrigintmpSectionCode;
        private string _tmpSectionCode;
        private int _tmpCustomerCode1;
        private int _tmpCustomerCode2;
        private int _tmpCustomerCode3;
        private int _tmpCustomerCode4;
        private int _tmpCustomerCode5;
        private int _tmpCustomerGrpCode1 = -1;
        private int _tmpCustomerGrpCode2 = -1;
        private int _tmpCustomerGrpCode3 = -1;
        private int _tmpCustomerGrpCode4 = -1;
        private int _tmpCustomerGrpCode5 = -1;
        private object _preComboDeleteDivValue;
        private object _preComboSettingDivValue;

        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

        private GoodsRateSetSearchParam _extrInfo;

        private string _customerTag;

        private const string CUSTOMERNOFOUND = "未登録";
        /// <summary>確認用メッセージ</summary>
        private const string MSG_CONFIRM_SAVEDISP = "一括削除処理を開始してもよろしいですか？\r\n一括削除処理を実行しますと確定前の売価設定は反映されません。";

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
        private const string ctGUIDE_NAME_OriginSectionGuide = "OriginSectionGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_Customer1Guide = "Customer1Guide";
        private const string ctGUIDE_NAME_Customer2Guide = "Customer2Guide";
        private const string ctGUIDE_NAME_Customer3Guide = "Customer3Guide";
        private const string ctGUIDE_NAME_Customer4Guide = "Customer4Guide";
        private const string ctGUIDE_NAME_Customer5Guide = "Customer5Guide";

        private const string ctGUIDE_NAME_CustomerGrp1Guide = "CustomerGrp1Guide";
        private const string ctGUIDE_NAME_CustomerGrp2Guide = "CustomerGrp2Guide";
        private const string ctGUIDE_NAME_CustomerGrp3Guide = "CustomerGrp3Guide";
        private const string ctGUIDE_NAME_CustomerGrp4Guide = "CustomerGrp4Guide";
        private const string ctGUIDE_NAME_CustomerGrp5Guide = "CustomerGrp5Guide";

        private CustomerCodeRateSetUpdateAcs _goodsRateSetUpdateAcs;           // 単品売価設定一括登録・修正アクセスクラス

        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// 単品売価　得意先引用登録UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 単品売価　得意先引用登録UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public PMKHN09461UB(GoodsRateSetSearchParam extrInfo)
        {
            InitializeComponent();


            _extrInfo = extrInfo;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsRateSetUpdateAcs = new CustomerCodeRateSetUpdateAcs();

            // 各種マスタ読込
            LoadSecInfoSet();
            LoadCustomerSearchRet();
            GetCustRateGrp();

            // 画面初期設定
            SetInitialSetting();

            // 画面クリア
            ClearScreen();
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

            this._guideEnableControlDictionary.Add(this.tEdit_OriginSectionCodeAllowZeroD.Name, ctGUIDE_NAME_OriginSectionGuide);        // 引用元設定.拠点
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);                    // 引用先設定.拠点
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD1.Name, ctGUIDE_NAME_Customer1Guide);                        // 引用先設定.得意先コード1
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD2.Name, ctGUIDE_NAME_Customer2Guide);                        // 引用先設定.得意先コード2
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD3.Name, ctGUIDE_NAME_Customer3Guide);                        // 引用先設定.得意先コード3
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD4.Name, ctGUIDE_NAME_Customer4Guide);                        // 引用先設定.得意先コード4
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCodeD5.Name, ctGUIDE_NAME_Customer5Guide);                        // 引用先設定.得意先コード5

            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero1.Name, ctGUIDE_NAME_CustomerGrp1Guide);                 // 引用先設定.得意先コード1
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero2.Name, ctGUIDE_NAME_CustomerGrp2Guide);                 // 引用先設定.得意先コード2
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero3.Name, ctGUIDE_NAME_CustomerGrp3Guide);                 // 引用先設定.得意先コード3
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero4.Name, ctGUIDE_NAME_CustomerGrp4Guide);                 // 引用先設定.得意先コード4
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero5.Name, ctGUIDE_NAME_CustomerGrp5Guide);                 // 引用先設定.得意先コード5

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.OriginSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this.uButton_CustomerGrpGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGrpGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "全社";
            this._tmpSectionCode = "00";


            this._OrigintmpSectionCode = "00";
            this.tEdit_OriginSectionCodeAllowZeroD.DataText = "00";
            this.tEdit_OriginSectionName.DataText = "全社";

            // 区分
            this.tComboEditor_DeleteDiv.Value = 2;
            this.tComboEditor_SettingDiv.Value = 0;
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

        /// <summary>
        /// 得意先検索マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先検索情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void LoadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retList;

                int status = this._customerSearchAcs.Serch(out retList, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retList)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
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



        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       :  2010/08/10</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
                }
                else
                {
                    customerName = CUSTOMERNOFOUND;
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
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
                    case ctGUIDE_NAME_SectionGuide:
                        {
                            this.OriginSectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer1Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide1, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer2Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide2, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer3Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide3, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer4Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide4, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_Customer5Guide:
                        {
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide5, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp1Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide1, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp2Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide2, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp3Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide3, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp4Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide4, new EventArgs());
                            break;
                        }
                    case ctGUIDE_NAME_CustomerGrp5Guide:
                        {
                            this.uButton_CustomerGrpGuide_Click(this.uButton_CustomerGrpGuide5, new EventArgs());
                            break;
                        }
                }
            }
        }

        /// <summary>
        ///未設定ツール有効無効設定処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        private void SettingUnSettingToolEnabled()
        {
            if (tComboEditor_DeleteDiv.Value == null || tComboEditor_SettingDiv.Value == null)
            {
                return;
            }
            if ((tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[0].DataValue || tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[2].DataValue)
                && tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
            {
                uCheckEditor_unSetting.Enabled = true;
            }
            else
            {
                uCheckEditor_unSetting.Checked = false;
                uCheckEditor_unSetting.Enabled = false;
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
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 確認ダイアログ
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                MSG_CONFIRM_SAVEDISP,
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return -1;
            }

            // 画面情報チェック
            bool bStatus = CheckSaveCondition();
            if (!bStatus)
            {
                return -1;
            }
            // 画面情報取得
            SetExtrInfo(ref this._extrInfo);

            // 更新処理
            status = this._goodsRateSetUpdateAcs.CustomerAllDelete(this._extrInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                   "検索条件に該当するデータが存在しません。",
                   status,
                   MessageBoxButtons.OK,
                   MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;

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
        /// <br>Update Note : 2010/08/31 楊明俊 #13972②の対応。</br>
        /// <br>Update Note : 2010/09/01 楊明俊 #13972②の対応。</br>
        /// </remarks>
        private bool CheckSaveCondition()
        {
            string errMsg = "";
            Control nextCtrl = null;

            try
            {
                if ((int)this.tComboEditor_SettingDiv.Value == 0)
                {
                    // 引用先　得意先コード
                    if (this.tNedit_CustomerCodeD1.GetInt() == 0 && this.tNedit_CustomerCodeD2.GetInt() == 0
                        && this.tNedit_CustomerCodeD3.GetInt() == 0 && this.tNedit_CustomerCodeD4.GetInt() == 0
                        && this.tNedit_CustomerCodeD5.GetInt() == 0)
                    {
                        errMsg = "得意先を入力して下さい。";
                        this.tNedit_CustomerCodeD1.Focus();
                        nextCtrl = this.tNedit_CustomerCodeD1;
                        return (false);
                    }
                }
                else if ((int)this.tComboEditor_SettingDiv.Value == 1)
                {
                    // 引用先　得意先掛率Ｇコード
                    //-----ADD 2010/08/31---------->>>>>
                    //-----UPD 2010/09/01---------->>>>>
                    if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                        && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                        && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim())
                        && (((int)tComboEditor_DeleteDiv.Value == 2 && uCheckEditor_unSetting.Checked == false) 
                        || ((int)tComboEditor_DeleteDiv.Value == 0 && uCheckEditor_unSetting.Checked == false) 
                        || (int)tComboEditor_DeleteDiv.Value == 1))
                    //if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim()) 
                    //    && (((int)tComboEditor_DeleteDiv.Value == 2 && uCheckEditor_unSetting.Checked == false) || ((int)tComboEditor_DeleteDiv.Value == 0 || (int)tComboEditor_DeleteDiv.Value == 1)))
                    //-----UPD 2010/09/01----------<<<<<
                    //if (string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero1.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero2.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero3.Text.Trim()) && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero4.Text.Trim())
                    //    && string.IsNullOrEmpty(this.tNedit_CustRateGrpCodeZero5.Text.Trim()))
                    //-----ADD 2010/08/31----------<<<<<
                    {
                        errMsg = "得意先掛率Ｇを入力して下さい。";
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        nextCtrl = this.tNedit_CustRateGrpCodeZero1;
                        return (false);
                    }
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
            //削除区分
            if ((int)tComboEditor_DeleteDiv.Value == 0)
            {
                para.RateMngGoodsCd = "0";
            }
            else if ((int)tComboEditor_DeleteDiv.Value == 1)
            {
                para.RateMngGoodsCd = "1";
            }
            else if ((int)tComboEditor_DeleteDiv.Value == 2)
            {
                para.RateMngGoodsCd = "2";
            }
            else
            {
                para.RateMngGoodsCd = "0";
            }
            
            //指定区分
            if ((int)tComboEditor_SettingDiv.Value == 0)
            {
                para.RateMngCustCd = "0";
            }
            else if ((int)tComboEditor_SettingDiv.Value == 1)
            {
                para.RateMngCustCd = "1";
            }
            else
            {
                para.RateMngCustCd = "2";
            }

            if ((int)this.tComboEditor_SettingDiv.Value == 0)
            {
                //得意先コード

                //引用先.拠点コード
                if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                    (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
                {
                    // 全社指定
                    para.SectionCode = null;
                }
                else
                {
                    para.SectionCode = new string[1];
                    para.SectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
                }

                //引用元.得意先
                para.CustomerCode = new int[6];

                //引用先.得意先コード1～5
                para.CustomerCode[1] = tNedit_CustomerCodeD1.GetInt();
                para.CustomerCode[2] = tNedit_CustomerCodeD2.GetInt();
                para.CustomerCode[3] = tNedit_CustomerCodeD3.GetInt();
                para.CustomerCode[4] = tNedit_CustomerCodeD4.GetInt();
                para.CustomerCode[5] = tNedit_CustomerCodeD5.GetInt();
            }
            else if ((int)this.tComboEditor_SettingDiv.Value == 1)
            {
                //得意先掛率Ｇコード

                // 引用元.拠点
                if ((this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim() == "") ||
                    (this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim().PadLeft(2, '0') == "00"))
                {
                    // 全社指定
                    para.SectionCode = null;
                }
                else
                {
                    para.SectionCode = new string[1];
                    para.SectionCode[0] = this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim().PadLeft(2, '0');
                }


                //引用元.得意先掛率Ｇ
                para.CustRateGrpCode = new int[6];

                //引用先.得意先掛率Ｇコード1～5
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
            }

            //未設定
            //削除区分「単品設定」で且つ、指定区分「得意先掛率Ｇ」で且つ、「未設定」チェック有りの場合
            if (((int)tComboEditor_DeleteDiv.Value == 2 || (int)tComboEditor_DeleteDiv.Value == 0) && (int)tComboEditor_SettingDiv.Value == 1 && uCheckEditor_unSetting.Checked == true)
            {
                para.UnSettingFlg = true;
            }
            else
            {
                para.UnSettingFlg = false;
            }

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
        /// <br>Update Note: 2010/09/03 楊明俊 #13972の６の対応</br>
        /// <br>Update Note: 2010/09/06 曹文傑 #14238対応</br>
        /// <br>Update Note: 2010/09/08 朱 猛 #14384対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 削除区分
                #region 削除区分
                case "tComboEditor_DeleteDiv":
                    {
                        if (tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[0].DataValue
                            || tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[1].DataValue
                            || tComboEditor_DeleteDiv.Value == tComboEditor_DeleteDiv.Items[2].DataValue)
                        {
                            _preComboDeleteDivValue = tComboEditor_DeleteDiv.Value;

                            SettingUnSettingToolEnabled();
                        }
                        else
                        {
                            tComboEditor_DeleteDiv.Value = _preComboDeleteDivValue;
                        }

                        //-----ADD 2010/09/06---------->>>>>
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        //-----ADD 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                // 指定区分
                #region 指定区分
                case "tComboEditor_SettingDiv":
                    {
                        if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[0].DataValue
                            || tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
                        {
                            _preComboSettingDivValue = tComboEditor_SettingDiv.Value;

                            if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[0].DataValue)
                            {
                                // 得意先
                                this.panel_Customer.Visible = true;
                                this.panel_CustRateGrp.Visible = false;
                                //---UPD 2010/09/08------------------>>>>>
                                //this.tEdit_SectionCodeAllowZero.Focus();
                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    }
                                }
                                //---UPD 2010/09/08------------------<<<<<
                            }
                            else if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
                            {
                                // 得意先掛率Ｇ
                                this.panel_Customer.Visible = false;
                                this.panel_CustRateGrp.Visible = true;
                                //-----UPD 2010/09/03---------->>>>>
                                //this.tEdit_OriginSectionCodeAllowZeroD.Focus();
                                //e.NextCtrl = this.tEdit_OriginSectionCodeAllowZeroD;    // DEL 2010/09/06
                                //-----UPD 2010/09/03----------<<<<<

                                //-----ADD 2010/09/06---------->>>>>
                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                                    {
                                        e.NextCtrl = this.tEdit_OriginSectionCodeAllowZeroD;
                                    }
                                }
                                else
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    }
                                }
                                //-----ADD 2010/09/06----------<<<<<

                                SettingUnSettingToolEnabled();
                            }
                        }
                        else
                        {
                            tComboEditor_SettingDiv.Value = _preComboSettingDivValue;
                        }

                        //-----ADD 2010/09/06---------->>>>>
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                this.tComboEditor_SettingDiv.Focus();
                            }
                        }
                        //-----ADD 2010/09/06----------<<<<<

                        break;
                    }
                #endregion

                // 引用元設定.拠点コード
                #region 引用元設定.拠点コード
                case "tEdit_OriginSectionCodeAllowZeroD":
                    {

                        if (this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim() == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._OrigintmpSectionCode = string.Empty;
                            this.tEdit_OriginSectionName.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim().Equals(this._OrigintmpSectionCode))
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
                            string sectionCode = this.tEdit_OriginSectionCodeAllowZeroD.DataText.Trim();

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
                                this.tEdit_OriginSectionCodeAllowZeroD.DataText = _OrigintmpSectionCode;

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
                                    e.NextCtrl = this.tNedit_CustomerCodeD1;
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
                                    e.NextCtrl = this.tNedit_CustomerCodeD1;
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

                //引用先設定.得意先コード1
                #region 引用先設定.得意先コード1
                case "tNedit_CustomerCodeD1":
                    {
                        if (tNedit_CustomerCodeD1.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode1 = 0;
                            this.tEdit_CustomerName1.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCodeD1.GetInt() == this._tmpCustomerCode1)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCodeD2;
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
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCodeD1.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // 結果を画面に設定
                                this.tEdit_CustomerName1.DataText = customerName;

                                // 設定値を保存
                                this._tmpCustomerCode1 = customerCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_CustomerCodeD1.SetInt(_tmpCustomerCode1);

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "得意先が存在しません。",                           // 表示するメッセージ
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
                                    e.NextCtrl = this.tNedit_CustomerCodeD2;
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

                //引用先設定.得意先コード2
                #region 引用先設定.得意先コード2
                case "tNedit_CustomerCodeD2":
                    {
                        if (tNedit_CustomerCodeD2.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode2 = 0;
                            this.tEdit_CustomerName2.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCodeD2.GetInt() == this._tmpCustomerCode2)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCodeD3;
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
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCodeD2.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // 結果を画面に設定
                                this.tEdit_CustomerName2.DataText = customerName;

                                // 設定値を保存
                                this._tmpCustomerCode2 = customerCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_CustomerCodeD2.SetInt(_tmpCustomerCode2);

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "得意先が存在しません。",                           // 表示するメッセージ
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
                                    e.NextCtrl = this.tNedit_CustomerCodeD3;
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

                //引用先設定.得意先コード3
                #region 引用先設定.得意先コード3
                case "tNedit_CustomerCodeD3":
                    {
                        if (tNedit_CustomerCodeD3.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode3 = 0;
                            this.tEdit_CustomerName3.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCodeD3.GetInt() == this._tmpCustomerCode3)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCodeD4;
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
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCodeD3.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // 結果を画面に設定
                                this.tEdit_CustomerName3.DataText = customerName;

                                // 設定値を保存
                                this._tmpCustomerCode3 = customerCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_CustomerCodeD3.SetInt(_tmpCustomerCode3);

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "得意先が存在しません。",                           // 表示するメッセージ
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
                                    e.NextCtrl = this.tNedit_CustomerCodeD4;
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

                //引用先設定.得意先コード4
                #region 引用先設定.得意先コード4
                case "tNedit_CustomerCodeD4":
                    {
                        if (tNedit_CustomerCodeD4.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode4 = 0;
                            this.tEdit_CustomerName4.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCodeD4.GetInt() == this._tmpCustomerCode4)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCodeD5;
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
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCodeD4.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // 結果を画面に設定
                                this.tEdit_CustomerName4.DataText = customerName;

                                // 設定値を保存
                                this._tmpCustomerCode4 = customerCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_CustomerCodeD4.SetInt(_tmpCustomerCode4);

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "得意先が存在しません。",                           // 表示するメッセージ
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
                                    e.NextCtrl = this.tNedit_CustomerCodeD5;
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

                //引用先設定.得意先コード5
                #region 引用先設定.得意先コード5
                case "tNedit_CustomerCodeD5":
                    {
                        if (tNedit_CustomerCodeD5.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode5 = 0;
                            this.tEdit_CustomerName5.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCodeD5.GetInt() == this._tmpCustomerCode5)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    //-----UPD 2010/09/06---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    e.NextCtrl = null;
                                    //-----UPD 2010/09/06----------<<<<<
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
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCodeD5.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // 結果を画面に設定
                                this.tEdit_CustomerName5.DataText = customerName;

                                // 設定値を保存
                                this._tmpCustomerCode5 = customerCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_CustomerCodeD5.SetInt(_tmpCustomerCode5);

                                // 該当なし
                                TMsgDisp.Show(this, 									// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                    this.Name,											// アセンブリID
                                    "得意先が存在しません。",                           // 表示するメッセージ
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
                                    //-----UPD 2010/09/06---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    e.NextCtrl = null;
                                    //-----UPD 2010/09/06----------<<<<<
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
                            this._tmpCustomerGrpCode1 = -1;
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
                            this._tmpCustomerGrpCode1 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerGrpCode1 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero1.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero1.SetInt(_tmpCustomerGrpCode1);
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
                            this._tmpCustomerGrpCode2 = -1;
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
                            this._tmpCustomerGrpCode2 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerGrpCode2 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero2.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero2.SetInt(_tmpCustomerGrpCode2);   
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
                            this._tmpCustomerGrpCode3 = -1;
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
                            this._tmpCustomerGrpCode3 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerGrpCode3 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero3.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero3.SetInt(_tmpCustomerGrpCode3);
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
                            this._tmpCustomerGrpCode4 = -1;
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
                            this._tmpCustomerGrpCode4 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (_tmpCustomerGrpCode4 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero4.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero4.SetInt(_tmpCustomerGrpCode4);
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
                            this._tmpCustomerGrpCode5 = -1;
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
                            this._tmpCustomerGrpCode5 = customerCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            if (this._tmpCustomerGrpCode5 == -1)
                            {
                                this.tNedit_CustRateGrpCodeZero5.Text = string.Empty;
                            }
                            else
                            {
                                this.tNedit_CustRateGrpCodeZero5.SetInt(_tmpCustomerGrpCode5);
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
                                if (uCheckEditor_unSetting.Enabled)
                                {
                                    e.NextCtrl = this.uCheckEditor_unSetting;
                                }
                                else
                                {
                                    //-----UPD 2010/09/06---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_DeleteDiv;
                                    e.NextCtrl = null;
                                    //-----UPD 2010/09/06----------<<<<<
                                }
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

                //-----ADD 2010/09/06---------->>>>>
                //引用先設定.得意先ガイド5
                #region 引用先設定.得意先ガイド5
                case "uButton_CustomerGuide5":
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

                //引用先設定.未設定
                #region 引用先設定.未設定
                case "uCheckEditor_unSetting":
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

                //引用先設定.得意先掛率グループガイド5
                #region 引用先設定.得意先掛率グループガイド5
                case "uButton_CustomerGrpGuide5":
                    {
                        if (!this.uCheckEditor_unSetting.Enabled)
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Return)
                                {
                                    e.NextCtrl = this.uCheckEditor_unSetting;
                                }
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
                        this.tEdit_OriginSectionCodeAllowZeroD.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_OriginSectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // 設定値を保存
                        this._OrigintmpSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                        this.tNedit_CustRateGrpCodeZero1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustRateGrpCodeZero1);

                    }
                    //引用先設定.拠点コード
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // 設定値を保存
                        this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                        this.tNedit_CustomerCodeD1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD1);
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
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _customerTag = ((UltraButton)sender).Tag.ToString();

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

                customerSearchForm.ShowDialog(this);

                if (customerSearchForm.DialogResult == DialogResult.OK || customerSearchForm.DialogResult == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.Retry;
                }

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    if (_customerTag.CompareTo("0") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.Focus();
                        this.SettingGuideButtonToolEnabled(this.tEdit_SectionCodeAllowZero);
                    }
                    else if (_customerTag.CompareTo("1") == 0)
                    {
                        this.tNedit_CustomerCodeD2.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD2);
                    }
                    else if (_customerTag.CompareTo("2") == 0)
                    {
                        this.tNedit_CustomerCodeD3.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD3);
                    }
                    else if (_customerTag.CompareTo("3") == 0)
                    {
                        this.tNedit_CustomerCodeD4.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD4);
                    }
                    else if (_customerTag.CompareTo("4") == 0)
                    {
                        this.tNedit_CustomerCodeD5.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCodeD5);
                    }
                    else if (_customerTag.CompareTo("5") == 0)
                    {
                        this.tComboEditor_DeleteDiv.Focus();
                        this.SettingGuideButtonToolEnabled(this.tComboEditor_DeleteDiv);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            //引用先設定.得意先1
            if (_customerTag.CompareTo("1") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode1 ||
                    this.tEdit_CustomerName1.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode1 = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCodeD1.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName1.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //引用先設定.得意先2
            else if (_customerTag.CompareTo("2") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode2 ||
                    this.tEdit_CustomerName2.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode2 = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCodeD2.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName2.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //引用先設定.得意先3
            else if (_customerTag.CompareTo("3") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode3 ||
                    this.tEdit_CustomerName3.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode3 = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCodeD3.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName3.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //引用先設定.得意先4
            else if (_customerTag.CompareTo("4") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode4 ||
                    this.tEdit_CustomerName4.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode4 = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCodeD4.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName4.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //引用先設定.得意先5
            else if (_customerTag.CompareTo("5") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode5 ||
                    this.tEdit_CustomerName5.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode5 = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCodeD5.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName5.DataText = customerSearchRet.Snm.Trim();
                }
            }

            this._cusotmerGuideSelected = true;
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
        /// <br>Update Note: 2010/09/03 楊明俊 #13972の６の対応</br>
        /// </remarks>
        private void uButton_CustomerGrpGuide_Click(object sender, EventArgs e)
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
                    //引用先設定.得意先掛率グループ1
                    if (_customerTag.CompareTo("1") == 0)
                    {
                        if (userGdBd.GuideCode != this._tmpCustomerCode1 ||
                            this.tNedit_CustRateGrpCodeZero1.DataText.Trim() == string.Empty)
                        {
                            this._tmpCustomerGrpCode1 = userGdBd.GuideCode;
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
                            this._tmpCustomerGrpCode2 = userGdBd.GuideCode;
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
                            this._tmpCustomerGrpCode3 = userGdBd.GuideCode;
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
                            this._tmpCustomerGrpCode4 = userGdBd.GuideCode;
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
                            this._tmpCustomerGrpCode5 = userGdBd.GuideCode;
                        }

                        this.tNedit_CustRateGrpCodeZero5.DataText = userGdBd.GuideCode.ToString("0000");
                        this.tEdit_CustomerGrpName5.DataText = userGdBd.GuideName.Trim();
                        // フォーカス設定
                        this.tComboEditor_DeleteDiv.Focus();
                        //-----UPD 2010/09/03---------->>>>>
                        this.SettingGuideButtonToolEnabled(this.tComboEditor_DeleteDiv);
                        //-----UPD 2010/09/03----------<<<<<
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
        /// </remarks>
        private void PMKHN09461UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

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
            this.tComboEditor_DeleteDiv.Focus();
            this.SettingGuideButtonToolEnabled(this.tComboEditor_DeleteDiv);

            this.panel_Customer.Visible = true;
            this.panel_CustRateGrp.Visible = false;

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
        private void PMKHN09461UB_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
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
        private void tComboEditor_DeleteDiv_SelectionChanged(object sender, EventArgs e)
        {
            //---UPD 2010/09/08------------------>>>>> 
            //_preComboDeleteDivValue = tComboEditor_DeleteDiv.Value;
            if (this.tComboEditor_DeleteDiv.Value != null)
            {
                _preComboDeleteDivValue = tComboEditor_DeleteDiv.Value;
            }
            //---UPD 2010/09/08------------------<<<<<
            SettingUnSettingToolEnabled();
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
        private void tComboEditor_SettingDiv_SelectionChanged(object sender, EventArgs e)
        {
            //---UPD 2010/09/08------------------>>>>> 
            //_preComboSettingDivValue = tComboEditor_SettingDiv.Value;
            if (this.tComboEditor_SettingDiv.Value != null)
            {
                _preComboSettingDivValue = tComboEditor_SettingDiv.Value;
            }
            //---UPD 2010/09/08------------------<<<<<

            if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[0].DataValue)
            {
                // 得意先
                this.panel_Customer.Visible = true;
                this.panel_CustRateGrp.Visible = false;
            }
            else if (tComboEditor_SettingDiv.Value == tComboEditor_SettingDiv.Items[1].DataValue)
            {
                // 得意先掛率Ｇ
                this.panel_Customer.Visible = false;
                this.panel_CustRateGrp.Visible = true;
                SettingUnSettingToolEnabled();
            }
        }

        #endregion ■ Control Events

    }
}