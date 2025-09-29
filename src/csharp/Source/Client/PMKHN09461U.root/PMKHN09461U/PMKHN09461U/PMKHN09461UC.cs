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
// 修 正 日  2010/08/31  修正内容 : #14019の１の対応
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
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 単品売価　得意先引用登録UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 単品売価　得意先引用登録UIフォームクラス</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>Update Note : 2010/08/31 楊明俊 #14019の１の対応。</br>
    /// <br>Update Note : 2010/09/06 曹文傑 #14238対応</br>
    /// </remarks>
    public partial class PMKHN09461UC : Form
    {
        #region ■ Private Members
        private string _enterpriseCode;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private SecInfoAcs _secInfoAcs = null;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;                           // 拠点情報設定アクセスクラス
        private CustomerSearchAcs _customerSearchAcs = null;   

        // 抽出条件前回入力値(更新有無チェック用)
        private string _OrigintmpSectionCode;
        private int _tmpCustomerCode;
        private string _tmpSectionCode;
        private int _tmpCustomerCode1;
        private int _tmpCustomerCode2;
        private int _tmpCustomerCode3;
        private int _tmpCustomerCode4;
        private int _tmpCustomerCode5;
        private object _preComboEditorValue;

        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

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
        public PMKHN09461UC(GoodsRateSetSearchParam extrInfo)
        {
            InitializeComponent();


            _extrInfo = extrInfo;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._goodsRateSetUpdateAcs = new CustomerCodeRateSetUpdateAcs();

            // 各種マスタ読込
            LoadSecInfoSet();
            LoadCustomerSearchRet();

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

            this._guideEnableControlDictionary.Add(this.tEdit_OriginSectionCodeAllowZero.Name, ctGUIDE_NAME_OriginSectionGuide);        // 引用元設定.拠点
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);                          // 引用元設定.得意先コード
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);                    // 引用先設定.拠点
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode1.Name, ctGUIDE_NAME_Customer1Guide);                        // 引用先設定.得意先コード1
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode2.Name, ctGUIDE_NAME_Customer2Guide);                        // 引用先設定.得意先コード2
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode3.Name, ctGUIDE_NAME_Customer3Guide);                        // 引用先設定.得意先コード3
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode4.Name, ctGUIDE_NAME_Customer4Guide);                        // 引用先設定.得意先コード4
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode5.Name, ctGUIDE_NAME_Customer5Guide);                        // 引用先設定.得意先コード5

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.OriginSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide1.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide2.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide3.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide4.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerGuide5.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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

            this._OrigintmpSectionCode = "00";
            this.tEdit_OriginSectionCodeAllowZero.DataText = "00";
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
                            this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
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
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報チェック
            bool bStatus = CheckSaveCondition();
            if (!bStatus)
            {
                return -1;
            }
            // 画面情報取得
            SetExtrInfo(ref this._extrInfo);

            // 更新処理
            status = this._goodsRateSetUpdateAcs.CustomerUpdate(this._extrInfo);

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
        /// <br>Update Note : 2010/08/31 楊明俊 #14019の１の対応。</br>
        /// </remarks>
        private bool CheckSaveCondition()
        {
            string errMsg = "";
            Control nextCtrl = null;

            try
            {
                // 引用元　得意先コード
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "引用元情報が設定されてません。";
                    this.tNedit_CustomerCode.Focus();
                    nextCtrl = this.tNedit_CustomerCode;
                    return (false);
                }

                // 引用先　得意先コード
                //-----ADD 2010/08/31---------->>>>>
                if (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().Equals(this.tEdit_SectionCodeAllowZero.DataText.Trim()))
                {
                //-----ADD 2010/08/31----------<<<<<
                    if (this.tNedit_CustomerCode1.GetInt() == 0 && this.tNedit_CustomerCode2.GetInt() == 0
                        && this.tNedit_CustomerCode3.GetInt() == 0 && this.tNedit_CustomerCode4.GetInt() == 0
                        && this.tNedit_CustomerCode5.GetInt() == 0)
                    {
                        errMsg = "引用先情報が設定されてません。";
                        this.tNedit_CustomerCode1.Focus();
                        nextCtrl = this.tNedit_CustomerCode1;
                        return (false);
                    }

                    if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode1.GetInt())
                    {
                        errMsg = "引用元、引用先の得意先設定が不正です。";
                        this.tNedit_CustomerCode1.Focus();
                        nextCtrl = this.tNedit_CustomerCode1;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode2.GetInt())
                    {
                        errMsg = "引用元、引用先の得意先設定が不正です。";
                        this.tNedit_CustomerCode2.Focus();
                        nextCtrl = this.tNedit_CustomerCode2;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode3.GetInt())
                    {
                        errMsg = "引用元、引用先の得意先設定が不正です。";
                        this.tNedit_CustomerCode3.Focus();
                        nextCtrl = this.tNedit_CustomerCode3;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode4.GetInt())
                    {
                        errMsg = "引用元、引用先の得意先設定が不正です。";
                        this.tNedit_CustomerCode4.Focus();
                        nextCtrl = this.tNedit_CustomerCode4;
                        return (false);
                    }
                    else if (this.tNedit_CustomerCode.GetInt() == this.tNedit_CustomerCode5.GetInt())
                    {
                        errMsg = "引用元、引用先の得意先設定が不正です。";
                        this.tNedit_CustomerCode5.Focus();
                        nextCtrl = this.tNedit_CustomerCode5;
                        return (false);
                    }
                //-----ADD 2010/08/31---------->>>>>
                }
                //-----ADD 2010/08/31----------<<<<<
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
            if ((this.tEdit_OriginSectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                para.SectionCode = null;
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
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

            //引用元.得意先
            para.CustomerCode = new int[6];

            para.CustomerCode[0] = tNedit_CustomerCode.GetInt();

            //引用先.得意先コード1～5
            para.CustomerCode[1] = tNedit_CustomerCode1.GetInt();
            para.CustomerCode[2] = tNedit_CustomerCode2.GetInt();
            para.CustomerCode[3] = tNedit_CustomerCode3.GetInt();
            para.CustomerCode[4] = tNedit_CustomerCode4.GetInt();
            para.CustomerCode[5] = tNedit_CustomerCode5.GetInt();

            //更新区分
            para.ObjectDiv = this.tComboEditor_UpdateDiv.Value.ToString();

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
                case "tEdit_OriginSectionCodeAllowZero":
                    {

                        if (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim() == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._OrigintmpSectionCode = string.Empty;
                            this.tEdit_OriginSectionName.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_OriginSectionCodeAllowZero.DataText.Trim().Equals(this._OrigintmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCode;
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
                            string sectionCode = this.tEdit_OriginSectionCodeAllowZero.DataText.Trim();

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
                                this.tEdit_OriginSectionCodeAllowZero.DataText = _OrigintmpSectionCode;

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
                                    e.NextCtrl = this.tNedit_CustomerCode;
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
                        }

                        break;
                    }

                #endregion

                // 引用元設定.得意先コード
                #region 引用元設定.得意先コード
                case "tNedit_CustomerCode":
                    {
                        if (tNedit_CustomerCode.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode = 0;
                            this.tEdit_CustomerName.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCode.GetInt() == this._tmpCustomerCode)
                        {
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
                        else
                        {
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCode.GetInt();

                            string customerName = GetCustomerName(customerCode).Trim();

                            if (!CUSTOMERNOFOUND.Equals(customerName))
                            {
                                // 結果を画面に設定
                                this.tEdit_CustomerName.DataText = customerName;

                                // 設定値を保存
                                this._tmpCustomerCode = customerCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_CustomerCode.SetInt(_tmpCustomerCode);

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
                                    e.NextCtrl = this.tNedit_CustomerCode1;
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
                                    e.NextCtrl = this.tNedit_CustomerCode1;
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
                case "tNedit_CustomerCode1":
                    {
                        if (tNedit_CustomerCode1.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode1 = 0;
                            this.tEdit_CustomerName1.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCode1.GetInt() == this._tmpCustomerCode1)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCode2;
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
                            int customerCode = this.tNedit_CustomerCode1.GetInt();

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
                                this.tNedit_CustomerCode1.SetInt(_tmpCustomerCode1);

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
                                    e.NextCtrl = this.tNedit_CustomerCode2;
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
                case "tNedit_CustomerCode2":
                    {
                        if (tNedit_CustomerCode2.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode2 = 0;
                            this.tEdit_CustomerName2.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCode2.GetInt() == this._tmpCustomerCode2)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCode3;
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
                            int customerCode = this.tNedit_CustomerCode2.GetInt();

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
                                this.tNedit_CustomerCode2.SetInt(_tmpCustomerCode2);

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
                                    e.NextCtrl = this.tNedit_CustomerCode3;
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
                case "tNedit_CustomerCode3":
                    {
                        if (tNedit_CustomerCode3.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode3 = 0;
                            this.tEdit_CustomerName3.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCode3.GetInt() == this._tmpCustomerCode3)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCode4;
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
                            int customerCode = this.tNedit_CustomerCode3.GetInt();

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
                                this.tNedit_CustomerCode3.SetInt(_tmpCustomerCode3);

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
                                    e.NextCtrl = this.tNedit_CustomerCode4;
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
                case "tNedit_CustomerCode4":
                    {
                        if (tNedit_CustomerCode4.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode4 = 0;
                            this.tEdit_CustomerName4.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCode4.GetInt() == this._tmpCustomerCode4)
                        {
                            if (e.ShiftKey == false)
                            {
                                //-----UPD 2010/09/06---------->>>>>
                                //if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                //-----UPD 2010/09/06----------<<<<<
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustomerCode5;
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
                            int customerCode = this.tNedit_CustomerCode4.GetInt();

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
                                this.tNedit_CustomerCode4.SetInt(_tmpCustomerCode4);

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
                                    e.NextCtrl = this.tNedit_CustomerCode5;
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
                case "tNedit_CustomerCode5":
                    {
                        if (tNedit_CustomerCode5.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpCustomerCode5 = 0;
                            this.tEdit_CustomerName5.DataText = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_CustomerCode5.GetInt() == this._tmpCustomerCode5)
                        {
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
                        else
                        {
                            // 得意先コード取得
                            int customerCode = this.tNedit_CustomerCode5.GetInt();

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
                                this.tNedit_CustomerCode5.SetInt(_tmpCustomerCode5);

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
                        }
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
                                //-----UPD 2010/09/06---------->>>>>
                                //e.NextCtrl = this.tEdit_OriginSectionCodeAllowZero;
                                e.NextCtrl = null;
                                //-----UPD 2010/09/06----------<<<<<
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
                        this.tEdit_OriginSectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_OriginSectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // 設定値を保存
                        this._OrigintmpSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                        this.tNedit_CustomerCode.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode);

                    }
                    //引用先設定.拠点コード
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());
                        // 設定値を保存
                        this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                        // フォーカス設定
                        this.tNedit_CustomerCode1.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode1);
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
                        this.tNedit_CustomerCode2.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode2);
                    }
                    else if (_customerTag.CompareTo("2") == 0)
                    {
                        this.tNedit_CustomerCode3.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode3);
                    }
                    else if (_customerTag.CompareTo("3") == 0)
                    {
                        this.tNedit_CustomerCode4.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode4);
                    }
                    else if (_customerTag.CompareTo("4") == 0)
                    {
                        this.tNedit_CustomerCode5.Focus();
                        this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode5);
                    }
                    else if (_customerTag.CompareTo("5") == 0)
                    {
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
            //引用元設定.得意先
            if (_customerTag.CompareTo("0") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode ||
                    this.tEdit_CustomerName.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();
                }
            }
            //引用先設定.得意先1
            else if (_customerTag.CompareTo("1") == 0)
            {
                if (customerSearchRet.CustomerCode != this._tmpCustomerCode1 ||
                    this.tEdit_CustomerName1.DataText.Trim() == string.Empty)
                {
                    this._tmpCustomerCode1 = customerSearchRet.CustomerCode;

                    // 得意先コード
                    this.tNedit_CustomerCode1.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode2.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode3.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode4.SetInt(customerSearchRet.CustomerCode);

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
                    this.tNedit_CustomerCode5.SetInt(customerSearchRet.CustomerCode);

                    // 得意先名称
                    this.tEdit_CustomerName5.DataText = customerSearchRet.Snm.Trim();
                }
            }

            this._cusotmerGuideSelected = true;
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
        private void PMKHN09461UC_FormClosing(object sender, FormClosingEventArgs e)
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
            this.tEdit_OriginSectionCodeAllowZero.Focus();

            this.SettingGuideButtonToolEnabled(this.tEdit_OriginSectionCodeAllowZero);

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
        private void PMKHN09461UC_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
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
}