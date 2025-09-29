//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタデータ入力
// プログラム概要   : 発注点設定の登録・変更・削除・復活を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/10  修正内容 : 障害報告Redmine#537の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/22  修正内容 : 障害報告Redmine#831の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/28  修正内容 : 障害報告Redmine#978の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 修 正 日  2009/12/24  修正内容 : MANTIS[14822] 車輌管理マスタ キー追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 施ヘイ中
// 修 正 日  2010/12/22  修正内容 : PM1015B  車輌管理マスタの修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/09/05  修正内容 : マスタに存在しないトリム、カラーコードを
//                                  入力しても登録できるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2012/09/27  修正内容 : カラー/トリムに提供以外の値を登録後、
//                                  編集で呼出し保存を行うと設定範囲外のメッセージが
//                                  表示される件の修正
//----------------------------------------------------------------------------//
// Update Note      :   2013/03/22 FSI高橋 文彰
// 管理番号         :   10900269-00 
//                      SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2013/05/02  修正内容 : 以下の障害を修正
//                                  ①車輌管理マスタの更新モードにて、年式から
//                                  　フォーカス移動すると編集実績ありの状態になる
//                                  ②検索切替を行うと、型式必須に戻しても
//                                  　グレード等が表示されなくなる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2013/05/08  修正内容 : 全体初期表示設定の元号表示区分（年式）対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 修 正 日  2013/05/09  修正内容 : 2013/05/02修正内容①の修正による障害を修正
//----------------------------------------------------------------------------//
// 管理番号  11070091-00 作成担当 : 譚洪
// 修 正 日  2014/08/01  修正内容 : 全体初期値設定マスタデータ取得障害を修正
//----------------------------------------------------------------------------//
// 管理番号 11070184-00  作成担当 : 鹿庭 一郎
// 修 正 日  2014/11/17  修正内容 : SCM仕掛一覧No.10598 文字列車台番号での発注・問合せ対応
//                                  システム障害No.22 桁数17桁表示
//----------------------------------------------------------------------------//
// 管理番号 11070184-00  作成担当 : 鹿庭 一郎
// 修 正 日  2014/11/19  修正内容 : SCM仕掛一覧No.10598 文字列車台番号での発注・問合せ対応
//                                  システム障害No.22 桁数17桁表示 車台番号9桁以上入力可能になっている
//----------------------------------------------------------------------------//
// 管理番号  11270098-00 作成担当 : 呉軍
// 作 成 日  2016/12/13  修正内容 : Redmine#48934 PMNSナンバープレート英文字対応
//----------------------------------------------------------------------------//
// 管理番号  11470076-00 作成担当 : 譚洪
// 作 成 日  2019/01/08  修正内容 : 新元号の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using Broadleaf.Library.Globarization;  // ADD 2013/05/08 Y.Wakita

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 車輌管理マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌管理マスタのフォームクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note: 張莉莉 2009/10/10</br>
    /// <br>           : 障害報告Redmine#537の修正</br>
    /// <br>Update Note: 張莉莉 2009/10/22</br>
    /// <br>           : 障害報告Redmine#831の修正</br>
    /// <br>Update Note: 張莉莉 2009/10/28</br>
    /// <br>           : 障害報告Redmine#978の修正</br>
    /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>UpdateNote  : 2016/12/13 呉軍</br>
    /// <br>管理番号    : 11270098-00</br>
    /// <br>            : Redmine#48934 PMNSナンバープレート英文字対応</br>
    /// </remarks>
    public partial class PMSYA09021UC : Form
    {
        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Consts
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string ctSearchCarMode_FullModel = "型式";
        private const string ctSearchCarMode_ModelPlate = "ﾓﾃﾞﾙﾌﾟﾚｰﾄ";
        private const string ctSearchCarNoDataMsg = "該当する車輌情報がありません。";
        /// <summary>ユーザーガイド区分コード</summary>
        public const int ctDIVCODE_UserGuideDivCd = 80;
        /// <summary>備考ガイド区分コード１</summary>
        public const int ctDIVCODE_NoteGuideDivCd = 201;
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private string _mode;
        private ControlScreenSkin _controlScreenSkin;
        private CarMngInputDataSet.CarSpecDataTable _carSpecDataTable;
        private CarMangInputExtraInfo _extraInfo;
        private CarMangInputExtraInfo _extraInfoForChangeCheck;
        private Thread _initialReadThread;
        private CarMngInputAcs _carMngInputAcs;
        private CarMngListInputAcs _listAcs;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private bool _isHandType;
        private bool _isSearchCar;
        private CarMngInputAcs.SearchCarMode _searchCarMode;
        private DateGetAcs _dateGetAcs;
        private PMKEN01010E _carInfo;
        private UserGuideAcs _userGuideAcs;
        private NoteGuidAcs _noteGuidAcs;
        private CustomerSearchAcs _customerSearchAcs = null;
        private Guid _guid;
        private PMSYA09021UD _carOtherInfoInput;
        private BeforeCarSearchBuffer _beforeCarSearchBuffer;// ADD 2009/10/10
        // 更新前項目値
        private string _tmpEngineModelNm = string.Empty; // ADD 2009/10/28
        private string _tmpFullModel = string.Empty; // ADD 2009/10/28
        private int _tmpModelDesignationNo = 0; // ADD 2009/10/28
        private int _tmpCategoryNo = 0; // ADD 2009/10/28
        
        // --- ADD 2013/03/22 ---------->>>>>
        // ハンドル位置情報チェックNG状態で画面クローズを行った場合のみ
        // 画面クローズを行わないようにフラグ制御
        private bool _closeflg = true;
        // --- ADD 2013/03/22 ----------<<<<<
        private bool _isSearchCar_FullModel = false;   // ADD 2013/05/02 Y.Wakita
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region イベント
        /// <summary>画面の状態を更新イベント</summary>
        internal event RefreshParentHandler RefreshParent;
        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region デリゲート
        /// <summary>
        /// 画面の状態更新デリゲート
        /// </summary>
        /// <param name="isRefresh">更新Flag</param>
        internal delegate void RefreshParentHandler(bool isRefresh);
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region コンストラクタ
        /// <summary>
        /// 車輌管理マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタのコンストラクタです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMSYA09021UC()
        {
            this.Init();
            // 新規モード
            this._mode = INSERT_MODE;
            this._guid = Guid.Empty;
        }

        /// <summary>
        /// 車輌管理マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌管理マスタのコンストラクタです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMSYA09021UC(Guid guid)
        {
            this.Init();
            this._guid = guid;
        }

        /// <summary>
        /// クラスの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスの初期化処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void Init()
        {
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
            this._listAcs = CarMngListInputAcs.GetInstance();
            this._initialReadThread = new Thread(this.InitialReadThread);
            this._initialReadThread.Start();

            InitializeComponent();

            this._carSpecDataTable = new CarMngInputDataSet.CarSpecDataTable();
            CarMngInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable.NewCarSpecRow();
            this._carSpecDataTable.AddCarSpecRow(carSpecRow);
            this._extraInfo = new CarMangInputExtraInfo();
            this._extraInfo.CarRelationGuid = Guid.Empty;

            this._dateGetAcs = DateGetAcs.GetInstance();
            this._carInfo = new PMKEN01010E();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._noteGuidAcs = new NoteGuidAcs();
            this._carOtherInfoInput = new PMSYA09021UD(this._extraInfo);
            this._carOtherInfoInput.SettingColorInfo += new PMSYA09021UD.SettingColorEventHandler(this.SettingColorInfo);
            this._carOtherInfoInput.SettingTrimInfo += new PMSYA09021UD.SettingTrimEventHandler(this.SettingTrimInfo);
            this.ClearExtraInfo(false);

        }
        # endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void PMSYA09020UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // イメージリスト設定
            this.uButton_SearchChange.ImageList = imageList16;
            this.uButton_Delete.ImageList = imageList24;
            this.uButton_Renewal.ImageList = imageList16;
            this.uButton_Ok.ImageList = imageList24;
            this.uButton_Revive.ImageList = imageList24;
            this.uButton_Cancel.ImageList = imageList24;
            this.uButton_CustomerGuide.ImageList = imageList16;
            this.uButton_CarMngNoGuide.ImageList = imageList16;
            this.uButton_ModelFullGuide.ImageList = imageList16;
            this.uButton_NumberPlate1Guide.ImageList = imageList16;
            this.uButton_SlipNoteGuide.ImageList = imageList16;

            // ボタンのアイコン設定
            this.uButton_SearchChange.Appearance.Image = Size16_Index.CARCHANGE;
            this.uButton_Delete.Appearance.Image = Size24_Index.DELETE;
            this.uButton_Renewal.Appearance.Image = Size16_Index.RENEWAL;
            this.uButton_Ok.Appearance.Image = Size24_Index.SAVE;
            this.uButton_Revive.Appearance.Image = Size24_Index.REVIVAL;
            this.uButton_Cancel.Appearance.Image = Size24_Index.CLOSE;

            // ガイドのイメージリスト設定
            this.uButton_CustomerGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_CarMngNoGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_ModelFullGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_NumberPlate1Guide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SlipNoteGuide.Appearance.Image = Size16_Index.STAR1;

            // 設定種別の設定
            this.uLabel_InputModeTitle.Text = this._mode;
            // 車輌検索ありの設定
            //this.uButton_ChangeSearchCarMode.Enabled = false;
            //型式必須が表示され「車輌検索あり」は切替え可能
            this.uButton_ChangeSearchCarMode.Enabled = true;   // ADD 2009/10/10
            this._isSearchCar = true;
            // 車輌検索種別の表示設定
            this.uLabel_SearchTypeTitle.Visible = true;
            // 管理番号入力種別の表示設定
            this.uLabel_InputTypeTitle.Visible = false;

            // カラー・トリム・装備(&1)
            this.uExpandableGroupBox_CarInfo.Enabled = false;
            this.uExpandableGroupBox_CarInfo.Expanded = false;

            // カラー・トリム・装備情報画面追加
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this._carOtherInfoInput);
            this._carOtherInfoInput.Dock = DockStyle.Fill;

            // スキーの設定
            this._controlScreenSkin = new ControlScreenSkin();
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // 車輌情報のデータソースの設定
            this.ultraGrid_CarSpec.DataSource = this._carSpecDataTable;

            // 初期データ取得スレッドが終了するまで待機
            // --- DEL 2009/10/10 ------>>>>>
            //while (this._initialReadThread.ThreadState == ThreadState.Running)
            //{
            //    Thread.Sleep(100);
            //}
            // --- DEL 2009/10/10 ------<<<<<

            this._carMngInputAcs.ReadAllDefSetData(this._enterpriseCode); // ADD 2014/07/30 譚洪 Redmine#43125

            // 型式／モデルプレート検索モード
            this._searchCarMode = CarMngInputAcs.SearchCarMode.FullModelSearch;

            // 画面初期化データの設定
            this.InitScreenDataInfo();
        }

        /// <summary>
        /// FormClosingイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がFormClosing時に発生します。</br>      
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void PMSYA09021UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            // --- ADD 2013/03/22 ---------->>>>>
            // ハンドル位置情報チェックNG状態で画面クローズを行った場合のみ
            // 画面クローズを行わないよう制御
            if (this._closeflg == false)
            {
                this._closeflg = true;
                e.Cancel = true;
                return;
            }
            // --- ADD 2013/03/22 ---------->>>>>

            // カラー情報をクリア
            this._carMngInputAcs.ClearColorInfo();
            // 装備情報をクリア
            this._carMngInputAcs.ClearEquipInfo();
            // トリム情報をクリア
            this._carMngInputAcs.ClearTrimInfo();
        }

        /// <summary>
        /// F4とF8のキーイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : F4キーとF8キーを押す時に発生します。</br>      
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009/09/07</br>
        /// </remarks>
        private void PMSYA09021UC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    // 検索切替
                    if (this.uButton_SearchChange.Visible == true)
                    {
                        this.uButton_SearchChange_Click(sender, e);
                    }
                    break;
                case Keys.F8:
                    // 手入力
                    if (this.uButton_HandInput.Visible == true)
                    {
                        this.uButton_HandInput_Click(sender, e);
                    }
                    break;
            }
        }

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Note	　　: PM1015B  車輌管理マスタの修正</br>
        /// <br>　　　　　　　施ヘイ中</br>
        /// <br>Date       : 2010/12/22</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴うハンドル位置チェック処理の追加</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // --- ADD 2009/10/10 ----->>>>>
            _beforeCarSearchBuffer = new BeforeCarSearchBuffer();
            _beforeCarSearchBuffer.Clear();
            // --- ADD 2009/10/10 -----<<<<<

            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control) prevCtrl = (Control)e.PrevCtrl;

            bool changeCarInfo = false;
            Control nextCtrl = null;
           
            bool returnFlg = false;  // ADD 2009/10/10

            // Coopyチェック処理
            this.WordCoopyCheck(e.PrevCtrl.Name);

            switch (e.PrevCtrl.Name)
            {
                #region 得意先コード
                //---------------------------------------------------------------
                // 得意先コード
                //---------------------------------------------------------------
                case "tNedit_CustomerCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_CustomerCode.GetInt();

                        if (code == 0)
                        {
                            this._extraInfo.CustomerCode = 0;
                            this.tEdit_CustomerName.Clear();
                            this.tNedit_CustomerCode.Clear();

                        }
                        else
                        {
                            if (this._extraInfo.CustomerCode != code)
                            {
                                string customerSnm = this.GetCustomerSnm(code);
                                if (this._listAcs.CustomerSearchRetDic.ContainsKey(code))
                                {
                                    this._extraInfo.CustomerCode = code;
                                    this.tEdit_CustomerName.Text = customerSnm;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "得意先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.tNedit_CustomerCode.SetInt(this._extraInfo.CustomerCode);
                                    canChangeFocus = false;
                                }
                            }
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:

                                        if (this.tNedit_CustomerCode.GetInt() == 0)
                                        {
                                            nextCtrl = this.uButton_CustomerGuide;
                                        }
                                        else
                                        {
                                            nextCtrl = this.tEdit_CarMngCode;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        nextCtrl = this.uButton_Cancel;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                # endregion

                #region 得意先ガイド
                //---------------------------------------------------------------
                // 得意先ガイド
                //---------------------------------------------------------------
                case "uButton_CustomerGuide":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if ((this.tEdit_CustomerName.Visible) && (this.tEdit_CustomerName.Enabled))
                                    {
                                        nextCtrl = this.tEdit_CustomerName;
                                    }
                                    else
                                    {
                                        nextCtrl = this.tNedit_CustomerCode;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    nextCtrl = this.tEdit_CarMngCode;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                # endregion

                #region 管理番号
                //---------------------------------------------------------------
                // 管理番号
                //---------------------------------------------------------------
                case "tEdit_CarMngCode":
                    {
                        string carMngCode = this.tEdit_CarMngCode.Text;

                        this._extraInfo.CarMngCode = carMngCode;

                        if (this._isHandType == true)
                        {
                            // 管理番号入力が「手入力モード」の場合、管理番号ガイドの起動は行わない
                        }
                        else
                        {
                            // 管理番号が入力されている状態で、以下の内容でガイドを表示する。
                            if (!string.IsNullOrEmpty(carMngCode))
                            {
                                // 管理番号入力が「通常モード」の場合、管理番号ガイドの自動起動を行う
                                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                                paramInfo.EnterpriseCode = this._enterpriseCode;
                                // 「新規登録」行表示あり
                                paramInfo.IsDispNewRow = true;
                                if (this.tNedit_CustomerCode.GetInt() != 0)
                                {
                                    // 得意先コード
                                    paramInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
                                    //// 得意先表示あり
                                    //paramInfo.IsDispCustomerInfo = true;
                                    // 得意先表示なし
                                    paramInfo.IsDispCustomerInfo = false;  // ADD 2009/10/10
                                    // 得意先コード絞り込み有り
                                    paramInfo.IsCheckCustomerCode = true;
                                }
                                else
                                {
                                    //// 得意先表示なし
                                    //paramInfo.IsDispCustomerInfo = false;
                                    // 得意先表示あり
                                    paramInfo.IsDispCustomerInfo = true;  // ADD 2009/10/10
                                    // 得意先コード絞り込み無し
                                    paramInfo.IsCheckCustomerCode = false;
                                }
                                // 管理番号絞り込み無し
                                paramInfo.IsCheckCarMngCode = true;
                                // 管理コード
                                paramInfo.CarMngCode = carMngCode;
                                // 管理コードの前方
                                paramInfo.CheckCarMngCodeType = 1;
                                // 車輌管理区分チェック無し
                                paramInfo.IsCheckCarMngDivCd = false;
                                // ガイドイベントフラグ
                                paramInfo.IsGuideClick = false;
                                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                                // --- ADD 2009/10/10 --------->>>>>
                                // 管理番号入力後、ENTER押下し、ガイドから×か、戻る実行時、元のフォーカスへ戻る
                                if (status == -1)
                                {
                                    returnFlg = true;
                                }
                                else 
                                {
                                    returnFlg = false;
                                }
                                // --- ADD 2009/10/10 ---------<<<<<
                                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    if (selectedInfo.CarMngCode != "新規登録")
                                    {
                                        this._extraInfo = selectedInfo.Clone();
                                        //this.ShowUpdateOrDeleteModeScreen(selectedInfo.CustomerCode, selectedInfo.CarMngNo, false); // 2009/12/24
                                        this.ShowUpdateOrDeleteModeScreen(selectedInfo.CustomerCode, selectedInfo.CarMngNo, selectedInfo.CarMngCode, false); // 2009/12/24
                                    }
                                    else
                                    {
                                        CarMangInputExtraInfo newExtra = this._extraInfo.Clone();
                                        this._extraInfo = new CarMangInputExtraInfo();
                                        this._extraInfo.CustomerCode = newExtra.CustomerCode;
                                        this._extraInfo.CarMngCode = newExtra.CarMngCode;
                                        //編集状態を破棄
                                        ShowInsertModeScreen();
                                    }
                                }
                                else
                                {
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                    {
                                        CarMangInputExtraInfo newExtra = this._extraInfo.Clone();
                                        this._extraInfo = new CarMangInputExtraInfo();
                                        this._extraInfo.CustomerCode = newExtra.CustomerCode;
                                        this._extraInfo.CarMngCode = newExtra.CarMngCode;
                                        //編集状態を破棄
                                        ShowInsertModeScreen();
                                    }
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(carMngCode))
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        e.NextCtrl = this.uButton_CarMngNoGuide;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        // --- UPD 2009/10/10 --------->>>>>
                                        // // 管理番号入力後、ENTER押下し、ガイドから×か、戻る実行時、元のフォーカスへ戻る
                                        //e.NextCtrl = this.tNedit_CustomerCode;
                                        if (!this._isHandType)
                                        {
                                            if (!returnFlg)
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_CarMngCode;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        // --- UPD 2009/10/10 ---------<<<<<
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        // --- UPD 2009/10/10 --------->>>>>
                                        // 管理番号入力後、ENTER押下し、ガイドから×か、戻る実行時、元のフォーカスへ戻る
                                        //e.NextCtrl = this.tNedit_ModelDesignationNo;
                                        if (!this._isHandType)
                                        {
                                            if (!returnFlg)
                                            {
                                                e.NextCtrl = this.tNedit_ModelDesignationNo;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_CarMngCode;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_ModelDesignationNo;
                                        }
                                        // --- UPD 2009/10/10 ---------<<<<<
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    }
                # endregion

                #region 管理番号ガイド
                //---------------------------------------------------------------
                // 管理番号ガイド
                //---------------------------------------------------------------
                case "uButton_CarMngNoGuide":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    e.NextCtrl = this.tEdit_CarMngCode;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    e.NextCtrl = this.tNedit_ModelDesignationNo;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                # endregion

                #region 型式指定番号
                //---------------------------------------------------------------
                // 型式指定番号
                //---------------------------------------------------------------
                case "tNedit_ModelDesignationNo":
                    {
                        this.SettingCarInfoRowFromCategoryNoAndDesignationNo(this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    e.NextCtrl = tNedit_CategoryNo;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (this.tEdit_CarMngCode.Enabled == true)
                                    {
                                        e.NextCtrl = this.tEdit_CarMngCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_Cancel; ;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                # endregion

                #region 類別区分番号
                //---------------------------------------------------------------
                // 類別区分番号
                //---------------------------------------------------------------
                case "tNedit_CategoryNo":
                    {
                        // --- UPD 2013/05/02 Y.Wakita ---------->>>>>
                        //if ((this.tNedit_ModelDesignationNo.GetInt() != 0 &&
                        //    this.tNedit_CategoryNo.GetInt() != 0) &&
                        //    (((this._extraInfo != null) &&
                        //    ((this.tNedit_ModelDesignationNo.GetInt() != this._extraInfo.ModelDesignationNo) ||
                        //     (this.tNedit_CategoryNo.GetInt() != this._extraInfo.CategoryNo)) &&
                        //     (this._isSearchCar == true)) || (this.CheckCarInfoAryByUpdateMod()&& (this.uExpandableGroupBox_CarInfo.Enabled == false))))
                        if (((this.tNedit_ModelDesignationNo.GetInt() != 0 &&
                            this.tNedit_CategoryNo.GetInt() != 0) &&
                            (((this._extraInfo != null) &&
                            ((this.tNedit_ModelDesignationNo.GetInt() != this._extraInfo.ModelDesignationNo) ||
                             (this.tNedit_CategoryNo.GetInt() != this._extraInfo.CategoryNo)) &&
                             (this._isSearchCar == true)) || (this.CheckCarInfoAryByUpdateMod()&& (this.uExpandableGroupBox_CarInfo.Enabled == false)))) ||
                           ((this.tNedit_ModelDesignationNo.GetInt() != 0 &&
                             this.tNedit_CategoryNo.GetInt() != 0) && 
                            (this._isSearchCar == true) && 
                            (this._isSearchCar_FullModel == true)))    
                        // --- UPD 2013/05/02 Y.Wakita ----------<<<<<
                        {
                            this._isSearchCar_FullModel = false;    // ADD 2013/05/02 Y.Wakita
                            CarSearchCondition con = new CarSearchCondition();
                            con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
                            con.CategoryNo = this.tNedit_CategoryNo.GetInt();
                            con.Type = CarSearchType.csCategory;

                            int result = this.CarSearch(con);

                            switch ((ConstantManagement.MethodResult)result)
                            {
                                case ConstantManagement.MethodResult.ctFNC_CANCEL:
                                    e.NextCtrl = this.tNedit_ModelDesignationNo;
                                    this.tNedit_ModelDesignationNo.Clear();
                                    this.tNedit_CategoryNo.Clear();
                                    break;
                                case ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    changeCarInfo = true;
                                    nextCtrl = this.tEdit_EngineModelNm;
                                    break;
                                case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
                                        "型式任意モードに変更しますか？",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);

                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        this.SettingCarInfoRowFromCategoryNoAndDesignationNo(this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                                        this.ChangeSearchCar();
                                        e.NextCtrl = tEdit_EngineModelNm;
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                        //this.tNedit_ModelDesignationNo.Clear();
                                        //this.tNedit_CategoryNo.Clear();
                                        //e.NextCtrl = this.tNedit_ModelDesignationNo;
                                        this.tNedit_ModelDesignationNo.SetInt(this._tmpModelDesignationNo);  // ADD 2009/10/28
                                        this.tNedit_CategoryNo.SetInt(this._tmpCategoryNo);  // ADD 2009/10/28
                                        e.NextCtrl = this.tNedit_CategoryNo;  // ADD 2009/10/28
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            this.SettingCarInfoRowFromCategoryNoAndDesignationNo(this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                        }
                        break;
                    }
                # endregion

                #region エンジン型式
                //---------------------------------------------------------------
                // エンジン型式
                //---------------------------------------------------------------
                case "tEdit_EngineModelNm":
                    {
                        // --- UPD 2013/05/02 Y.Wakita ---------->>>>>
                        //if ((!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text.Trim())) &&
                        //    (((this._extraInfo == null) ||
                        //     (this._extraInfo.EngineModelNm != this.tEdit_EngineModelNm.Text.Trim()) &&
                        //     (this._isSearchCar == true)) || (this.CheckCarInfoAryByUpdateMod() && ((this.uExpandableGroupBox_CarInfo.Enabled == false)))))
                        if (((!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text.Trim())) &&
                            (((this._extraInfo == null) ||
                             (this._extraInfo.EngineModelNm != this.tEdit_EngineModelNm.Text.Trim()) &&
                             (this._isSearchCar == true)) || (this.CheckCarInfoAryByUpdateMod() && ((this.uExpandableGroupBox_CarInfo.Enabled == false))))) ||
                            ((!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text.Trim())) && 
                             (this._isSearchCar == true) && 
                             (this._isSearchCar_FullModel == true))) 
                        // --- UPD 2013/05/02 Y.Wakita ----------<<<<<
                        {
                            this._isSearchCar_FullModel = false;    // ADD 2013/05/02 Y.Wakita
                            CarSearchCondition con = new CarSearchCondition();
                            con.EngineModel.FullModel = this.tEdit_EngineModelNm.Text;
                            con.Type = CarSearchType.csEngineModel;

                            int result = this.CarSearch(con);

                            switch ((ConstantManagement.MethodResult)result)
                            {
                                case ConstantManagement.MethodResult.ctFNC_CANCEL:
                                    e.NextCtrl = e.PrevCtrl;
                                    this.tEdit_EngineModelNm.Clear();
                                    break;
                                case ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    changeCarInfo = true;
                                    e.NextCtrl = this.tEdit_FullModel;
                                    break;
                                case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
                                        "型式任意モードに変更しますか？",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);

                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        this.SettingCarInfoRowFromEngineModelNm(this.tEdit_EngineModelNm.Text);
                                        this.ChangeSearchCar();
                                        e.NextCtrl = tEdit_FullModel;
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                        // ---UPD 2009/10/28 ----->>>>>
                                        //this.tEdit_EngineModelNm.Clear();
                                        this.tEdit_EngineModelNm.Text = this._tmpEngineModelNm;
                                        // ---UPD 2009/10/28 -----<<<<<
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            this.SettingCarInfoRowFromEngineModelNm(this.tEdit_EngineModelNm.Text);
                        }
                        break;
                    }
                #endregion

                #region 型式／モデルプレート
                //---------------------------------------------------------------
                // 型式／モデルプレート
                //---------------------------------------------------------------
                case "tEdit_FullModel":
                    {
                        if (this._searchCarMode == CarMngInputAcs.SearchCarMode.FullModelSearch)
                        {
                            //---------------------------------------------------------------
                            // 型式検索
                            //---------------------------------------------------------------
                            // --- UPD 2013/05/02 Y.Wakita ---------->>>>>
                            //if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) &&
                            //    (((this._extraInfo == null) ||
                            //     (this._extraInfo.FullModel != this.tEdit_FullModel.Text.Trim())) &&
                            //     (this._isSearchCar == true) || (this.CheckCarInfoAryByUpdateMod() && ((this.uExpandableGroupBox_CarInfo.Enabled == false)))))
                            if (((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) &&
                                (((this._extraInfo == null) ||
                                 (this._extraInfo.FullModel != this.tEdit_FullModel.Text.Trim())) &&
                                 (this._isSearchCar == true) || (this.CheckCarInfoAryByUpdateMod() && ((this.uExpandableGroupBox_CarInfo.Enabled == false))))) ||
                               ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) && 
                                (this._isSearchCar == true) && 
                                (this._isSearchCar_FullModel == true))) 
                            // --- UPD 2013/05/02 Y.Wakita ----------<<<<<
                            {
                                this._isSearchCar_FullModel = false;    // ADD 2013/05/02 Y.Wakita
                                CarSearchCondition con = new CarSearchCondition();
                                con.CarModel.FullModel = this.tEdit_FullModel.Text;
                                con.Type = CarSearchType.csModel;

                                int result = this.CarSearch(con);

                                switch ((ConstantManagement.MethodResult)result)
                                {
                                    case ConstantManagement.MethodResult.ctFNC_CANCEL:
                                        e.NextCtrl = e.PrevCtrl;
                                        this.tEdit_FullModel.Clear();
                                        break;
                                    case ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        changeCarInfo = true;
                                        e.NextCtrl = this.tNedit_MakerCode;
                                        break;
                                    case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "該当する車輌情報が存在しません。" + "\r\n" + "\r\n" +
                                            "型式任意モードに変更しますか？",
                                            0,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            this.SettingCarInfoRowFromFullModel(this.tEdit_FullModel.Text);
                                            this.ChangeSearchCar();
                                            e.NextCtrl = tNedit_MakerCode;
                                        }
                                        else if (dialogResult == DialogResult.No)
                                        {
                                            //this.tEdit_FullModel.Clear();
                                            this.tEdit_FullModel.Text = this._tmpFullModel; // ADD 2009/10/28
                                            this.tEdit_EngineModelNm.Text = this._tmpEngineModelNm; // ADD 2009/10/28
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                this.SettingCarInfoRowFromFullModel(this.tEdit_FullModel.Text);
                            }

                            // --- ADD 2013/03/22 ---------->>>>>
                            bool ret = this.CheckHandlePositionForChangeFocus(sender, e);
                            // --- ADD 2013/03/22 ----------<<<<<
                        }
                        else if (this._searchCarMode == CarMngInputAcs.SearchCarMode.ModelPlateSearch)
                        {
                            //---------------------------------------------------------------
                            // モデルプレート検索
                            //---------------------------------------------------------------
                            if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) &&
                                ((this._extraInfo == null) ||
                                 (this._extraInfo.FullModel != this.tEdit_FullModel.Text.Trim())) &&
                                 (this._isSearchCar == true))
                            {
                                CarSearchCondition con = new CarSearchCondition();
                                con.ModelPlate = this.tEdit_FullModel.Text;
                                con.Type = CarSearchType.csPlate;

                                int result = this.CarSearch(con);

                                switch ((ConstantManagement.MethodResult)result)
                                {
                                    case ConstantManagement.MethodResult.ctFNC_CANCEL:
                                        e.NextCtrl = e.PrevCtrl;
                                        this.tEdit_FullModel.Clear();
                                        break;
                                    case ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        changeCarInfo = true;
                                        nextCtrl = this.tNedit_MakerCode;
                                        break;
                                    case ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            ctSearchCarNoDataMsg,
                                            -1,
                                            MessageBoxButtons.OK);
                                        e.NextCtrl = e.PrevCtrl;
                                        this.tEdit_FullModel.Clear();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                this.SettingCarInfoRowFromFullModel(this.tEdit_FullModel.Text);
                            }
                        }
                        break;
                    }
                # endregion

                #region メーカーコード
                //---------------------------------------------------------------
                // メーカーコード
                //---------------------------------------------------------------
                case "tNedit_MakerCode":
                    {
                        changeCarInfo = false;

                        if ((this._extraInfo != null) &&
                            (this._extraInfo.MakerCode != this.tNedit_MakerCode.GetInt()))
                        {
                            // ADD 2014/08/01 譚洪 Redmine#43125 --- >>>
                            // 初期データ取得スレッドが終了するまで待機
                            while (this._initialReadThread.ThreadState == ThreadState.Running)
                            {
                                Thread.Sleep(100);
                            }
                            // ADD 2014/08/01 譚洪 Redmine#43125 --- <<<

                            if (this.tNedit_MakerCode.GetInt() != 0)
                            {
                                int makerCode = this.tNedit_MakerCode.GetInt();
                                string name = this._carMngInputAcs.GetName_FromMaker(makerCode);
                                string hName = this._carMngInputAcs.GetKanaName_FromMaker(makerCode);
                                this.tEdit_ModelFullName.Text = name;
                                if (string.IsNullOrEmpty(name))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入力したメーカーコードは存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = e.PrevCtrl;
                                    this.tNedit_MakerCode.SetInt(this._extraInfo.MakerCode);
                                    this.tEdit_ModelFullName.Text = this._extraInfo.MakerFullName;
                                    this.SettingCarInfoRowFromModelInfo(this._extraInfo.MakerCode, this._extraInfo.MakerFullName, this._extraInfo.MakerHalfName, this._extraInfo.ModelCode, this._extraInfo.ModelSubCode, this._extraInfo.ModelFullName, this._extraInfo.ModelHalfName);
                                    break;
                                }
                                this._carMngInputAcs.ClearColorInfo();
                                this._carMngInputAcs.ClearTrimInfo();
                                this._carMngInputAcs.ClearEquipInfo();
                                this.ClearExtraInfo(true);
                                this.SettingCarInfoRowFromModelInfo(0, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
                                this.SettingCarInfoRowFromModelInfo(makerCode, name, hName, 0, 0, string.Empty, string.Empty);

                                // 車種コード
                                this.tNedit_ModelCode.Enabled = true;
                                nextCtrl = this.tNedit_ModelCode;
                                changeCarInfo = true;
                            }
                            else
                            {
                                this._carMngInputAcs.ClearColorInfo();
                                this._carMngInputAcs.ClearTrimInfo();
                                this._carMngInputAcs.ClearEquipInfo();
                                this.ClearExtraInfo(true);
                                this.SettingCarInfoRowFromModelInfo(0, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
                                changeCarInfo = true;
                            }
                        }

                        #region NextCtrl制御
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (this.tNedit_MakerCode.GetInt() == 0)
                                    {
                                        nextCtrl = this.uButton_ModelFullGuide;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        }
                        #endregion
                        break;
                    }
                #endregion

                #region 車種コード
                //---------------------------------------------------------------
                // 車種コード
                //---------------------------------------------------------------
                case "tNedit_ModelCode":
                    {
                        changeCarInfo = false;
                        if ((this._extraInfo != null) &&
                            ((this._extraInfo.ModelCode != this.tNedit_ModelCode.GetInt()) ||
                             (this._extraInfo.ModelSubCode != this.tNedit_ModelSubCode.GetInt())))
                        {
                            // ADD 2014/08/01 譚洪 Redmine#43125 --- >>>
                            // 初期データ取得スレッドが終了するまで待機
                            while (this._initialReadThread.ThreadState == ThreadState.Running)
                            {
                                Thread.Sleep(100);
                            }
                            // ADD 2014/08/01 譚洪 Redmine#43125 --- <<<

                            if (this.tNedit_ModelCode.GetInt() != 0)
                            {
                                int makerCode = this.tNedit_MakerCode.GetInt();
                                string makerName = this._carMngInputAcs.GetName_FromMaker(makerCode);
                                string makerHName = this._carMngInputAcs.GetKanaName_FromMaker(makerCode);
                                int modelCode = this.tNedit_ModelCode.GetInt();
                                int modelSubCode = this.tNedit_ModelSubCode.GetInt();
                                string name = this._carMngInputAcs.GetModelFullName(makerCode, modelCode, modelSubCode);
                                string hName = this._carMngInputAcs.GetModelHalfName(makerCode, modelCode, modelSubCode);
                                this.tEdit_ModelFullName.Text = name;
                                if (string.IsNullOrEmpty(name) )
                                {
                                    // ----ADD 2010/12/22 ------>>>>>
                                    if (!string.IsNullOrEmpty(makerName) && (this.tNedit_ModelSubCode.Text == ""))
                                    {                                    
                                    e.NextCtrl = e.PrevCtrl;
                                    this.tNedit_ModelCode.SetInt(this._extraInfo.ModelCode);
                                    this.tEdit_ModelFullName.Text = makerName;
                                    this.tNedit_ModelCode.Text = modelCode.ToString();
                                    this.SettingCarInfoRowFromModelInfo(makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
                                    this.tNedit_ModelSubCode.Enabled = true;
                                    e.NextCtrl = this.tNedit_ModelSubCode;
                                    changeCarInfo = false;
                                    break;
                                    }
                                    else
                                    // ----ADD 2010/12/22 ------<<<<<
                                    {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入力した車種コードは存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = e.PrevCtrl;
                                    this.tNedit_ModelCode.SetInt(this._extraInfo.ModelCode);
                                    this.tEdit_ModelFullName.Text = this._extraInfo.ModelFullName;
                                    this.SettingCarInfoRowFromModelInfo(this._extraInfo.MakerCode, this._extraInfo.MakerFullName, this._extraInfo.MakerHalfName, this._extraInfo.ModelCode, this._extraInfo.ModelSubCode, this._extraInfo.ModelFullName, this._extraInfo.ModelHalfName);
                                    break;
                                    }
                                }
                               
                                this._carMngInputAcs.ClearColorInfo();
                                this._carMngInputAcs.ClearTrimInfo();
                                this._carMngInputAcs.ClearEquipInfo();
                                this.ClearExtraInfo(true);
                                this.SettingCarInfoRowFromModelInfo(makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
                                this.tNedit_ModelSubCode.Enabled = true;
                                e.NextCtrl = this.tNedit_ModelSubCode;
                                changeCarInfo = true;
                            }
                            else
                            {
                                int makerCode = this._extraInfo.MakerCode;
                                string makerName = this._carMngInputAcs.GetName_FromMaker(makerCode);
                                string makerHName = this._carMngInputAcs.GetKanaName_FromMaker(makerCode);
                                int modelCode = 0;
                                int modelSubCode = 0;
                                string name = string.Empty;
                                string hName = string.Empty;
                                this._carMngInputAcs.ClearColorInfo();
                                this._carMngInputAcs.ClearTrimInfo();
                                this._carMngInputAcs.ClearEquipInfo();
                                this.ClearExtraInfo(true);
                                this.SettingCarInfoRowFromModelInfo(makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
                                changeCarInfo = true;
                            }
                        }
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (this.tNedit_ModelSubCode.Enabled == true)
                                    {
                                        nextCtrl = this.tNedit_ModelSubCode;
                                    }
                                    else
                                    {
                                        if (this.tEdit_ModelFullName.Enabled == true)
                                        {
                                            nextCtrl = this.tEdit_ModelFullName;
                                        }
                                        else
                                        {
                                            nextCtrl = this.tDateEdit_FirstEntryDate;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 車種呼称コード
                //---------------------------------------------------------------
                // 車種呼称コード
                //---------------------------------------------------------------
                case "tNedit_ModelSubCode":
                    {
                        changeCarInfo = false;
                        if ((this._extraInfo != null) &&
                            ((this._extraInfo.ModelCode != this.tNedit_ModelCode.GetInt()) ||
                             (this._extraInfo.ModelSubCode != this.tNedit_ModelSubCode.GetInt())))
                        {
                            // ADD 2014/08/01 譚洪 Redmine#43125 --- >>>
                            // 初期データ取得スレッドが終了するまで待機
                            while (this._initialReadThread.ThreadState == ThreadState.Running)
                            {
                                Thread.Sleep(100);
                            }
                            // ADD 2014/08/01 譚洪 Redmine#43125 --- <<<

                            if (this.tNedit_ModelSubCode.GetInt() != 0)
                            {
                                int makerCode = this.tNedit_MakerCode.GetInt();
                                string makerName = this._carMngInputAcs.GetName_FromMaker(makerCode);
                                string makerHName = this._carMngInputAcs.GetKanaName_FromMaker(makerCode);
                                int modelCode = this.tNedit_ModelCode.GetInt();
                                int modelSubCode = this.tNedit_ModelSubCode.GetInt();
                                string name = this._carMngInputAcs.GetModelFullName(makerCode, modelCode, modelSubCode);
                                string hName = this._carMngInputAcs.GetModelHalfName(makerCode, modelCode, modelSubCode);
                                this.tEdit_ModelFullName.Text = name;
                                if (string.IsNullOrEmpty(name))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入力した車種呼称コードは存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = e.PrevCtrl;
                                    this.tNedit_ModelCode.SetInt(this._extraInfo.ModelCode);
                                    this.tNedit_ModelSubCode.SetInt(this._extraInfo.ModelSubCode);
                                    // ----UPD 2010/12/22 ------>>>>>
                                    //this.tEdit_ModelFullName.Text = this._extraInfo.ModelFullName;
                                    if (!string.IsNullOrEmpty(this._extraInfo.ModelFullName))
                                    {
                                        this.tEdit_ModelFullName.Text = this._extraInfo.ModelFullName;
                                    }
                                    if (string.IsNullOrEmpty(this._extraInfo.ModelFullName) && (!string.IsNullOrEmpty(this._extraInfo.MakerFullName)))
                                    {
                                        this.tEdit_ModelFullName.Text = this._extraInfo.MakerFullName;
                                    }
                                    // ----UPD 2010/12/22 ------<<<<<<
                                    this.SettingCarInfoRowFromModelInfo(this._extraInfo.MakerCode, this._extraInfo.MakerFullName, this._extraInfo.MakerHalfName, this._extraInfo.ModelCode, this._extraInfo.ModelSubCode, this._extraInfo.ModelFullName, this._extraInfo.ModelHalfName);
                                    break;
                                }
                                this._carMngInputAcs.ClearColorInfo();
                                this._carMngInputAcs.ClearTrimInfo();
                                this._carMngInputAcs.ClearEquipInfo();
                                this.ClearExtraInfo(true);
                                this.SettingCarInfoRowFromModelInfo(makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
                                changeCarInfo = true;
                            }
                            else
                            {
                                int makerCode = this._extraInfo.MakerCode;
                                string makerName = this._carMngInputAcs.GetName_FromMaker(makerCode);
                                string makerHName = this._carMngInputAcs.GetKanaName_FromMaker(makerCode);
                                int modelCode = this._extraInfo.ModelCode;
                                int modelSubCode = 0;
                                string name = this._carMngInputAcs.GetModelFullName(makerCode, modelCode, modelSubCode);
                                string hName = this._carMngInputAcs.GetModelHalfName(makerCode, modelCode, modelSubCode);
                                this._carMngInputAcs.ClearColorInfo();
                                this._carMngInputAcs.ClearTrimInfo();
                                this._carMngInputAcs.ClearEquipInfo();
                                this.ClearExtraInfo(true);
                                this.SettingCarInfoRowFromModelInfo(makerCode, makerName, makerHName, modelCode, modelSubCode, name, hName);
                                changeCarInfo = true;
                            }
                        }

                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (this.tEdit_ModelFullName.Enabled == true)
                                    {
                                        nextCtrl = this.tEdit_ModelFullName;
                                    }
                                    else
                                    {
                                        nextCtrl = this.tDateEdit_FirstEntryDate;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 車種名称
                case "tEdit_ModelFullName":
                    {
                        // ADD 2014/08/01 譚洪 Redmine#43125 --- >>>
                        // 初期データ取得スレッドが終了するまで待機
                        while (this._initialReadThread.ThreadState == ThreadState.Running)
                        {
                            Thread.Sleep(100);
                        }
                        // ADD 2014/08/01 譚洪 Redmine#43125 --- <<<

                        int makerCode = this.tNedit_MakerCode.GetInt();
                        string makerName = this._carMngInputAcs.GetName_FromMaker(makerCode);
                        string makerHName = this._carMngInputAcs.GetKanaName_FromMaker(makerCode);
                        int modelCode = this.tNedit_ModelCode.GetInt();
                        int modelSubCode = this.tNedit_ModelSubCode.GetInt();
                        string name = this.tEdit_ModelFullName.Text.Trim();

                        if ((modelCode == 0) && (modelSubCode == 0))
                        {
                            this.SettingCarInfoRowFromModelInfo(makerCode, name, string.Empty, modelCode, modelSubCode, string.Empty, string.Empty);
                        }
                        else
                        {
                            this.SettingCarInfoRowFromModelInfo(makerCode, makerName, makerHName, modelCode, modelSubCode, name, string.Empty);
                        }

                        changeCarInfo = true;

                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (this.tEdit_ModelFullName.Text.Trim() == string.Empty)
                                    {
                                        nextCtrl = this.uButton_ModelFullGuide;
                                    }
                                    else
                                    {
                                        nextCtrl = this.tDateEdit_FirstEntryDate;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 車種ガイドボタン
                //---------------------------------------------------------------
                // 車種ガイドボタン
                //---------------------------------------------------------------
                case "uButton_ModelFullGuide":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if ((this.tEdit_ModelFullName.Enabled) && (this.tEdit_ModelFullName.Visible))
                                    {
                                        nextCtrl = this.tEdit_ModelFullName;
                                    }
                                    else
                                    {
                                        nextCtrl = this.tNedit_MakerCode;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    nextCtrl = this.tDateEdit_FirstEntryDate;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;

                    }
                #endregion

                #region 年式
                //---------------------------------------------------------------
                // 年式
                //---------------------------------------------------------------
                case "tDateEdit_FirstEntryDate":
                    {
                        TDateEdit tempFirstEntryDate = (this.tDateEdit_FirstEntryDate as TDateEdit);
                        DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDateForFirstEntryDate(ref tempFirstEntryDate, true);
                        if (res == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                            // ---DEL 2009/10/10 ---------->>>>>
                            // 年式の月のみ未入力可能なように修正
                            //|| (this.tDateEdit_FirstEntryDate.GetDateYear() != 0 && this.tDateEdit_FirstEntryDate.GetDateMonth() == 0))
                            // ---DEL 2009/10/10 ----------<<<<<
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "日付が不正です。",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = prevCtrl;
                            changeCarInfo = true;
                        }
                        else
                        {

                            int newValue = this.tDateEdit_FirstEntryDate.GetLongDate();
                            if (this._extraInfo.ProduceTypeOfYearInput != (newValue / 100))
                            {
                                if (this.CheckProduceTypeOfYearRange(tDateEdit_FirstEntryDate.GetLongDate()))
                                {
                                    // 年式設定処理
                                    this.SettingCarInfoRowFromFirstEntryDate(tDateEdit_FirstEntryDate.GetLongDate());
                                    if (this._carInfo.CarModelUIData.Count > 0)
                                    {
                                        this._carInfo.CarModelUIData[0].ProduceTypeOfYearInput = tDateEdit_FirstEntryDate.GetLongDate() / 100;
                                    }
                                    changeCarInfo = true;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "生産年式が設定範囲外です。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = prevCtrl;
                                    changeCarInfo = false;

                                    this.tDateEdit_FirstEntryDate.SetLongDate(this._extraInfo.ProduceTypeOfYearInput * 100);
                                }
                            }

                            switch (e.Key)
                            {
                                case Keys.Down:
                                    e.NextCtrl = this.tEdit_ProduceFrameNo;
                                    break;
                                default:
                                    break;
                            }

                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.tEdit_ModelFullName.Enabled == true)
                                        {
                                            e.NextCtrl = this.tEdit_ModelFullName;
                                        }
                                        else if (this.tNedit_ModelSubCode.Enabled == true)
                                        {
                                            e.NextCtrl = this.tNedit_ModelSubCode;
                                        }
                                        else if (this.tNedit_ModelCode.Enabled == true)
                                        {
                                            e.NextCtrl = this.tNedit_ModelCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_MakerCode;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 車台番号
                //---------------------------------------------------------------
                // 車台番号
                //---------------------------------------------------------------
                case "tEdit_ProduceFrameNo":
                    {
                        bool canChangeFocus = true;

                        string newValue = this.tEdit_ProduceFrameNo.Text;
                        int newIntValue = TStrConv.StrToIntDef(newValue.Trim(), 0);
                        if (this._extraInfo.FrameNo != newValue)
                        {
                            if (this.CheckProduceFrameNo(newValue, newIntValue))
                            {
                                // 車台番号設定処理
                                this.SettingCarInfoRowFromFrameNo(newValue);

                                // 年式取得処理
                                int firstEntryDate = this.GetProduceTypeOfYear(newIntValue);

                                // 年式設定処理
                                if (firstEntryDate != 0) this.SettingCarInfoRowFromFirstEntryDate(firstEntryDate);

                                this.SetDisplayCarInfo(this._extraInfo, false);

                                changeCarInfo = true;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "車台番号が設定範囲外です。",
                                        -1,
                                        MessageBoxButtons.OK);
                                e.NextCtrl = prevCtrl;
                                changeCarInfo = false;
                                canChangeFocus = false;

                                this.tEdit_ProduceFrameNo.Text = this._extraInfo.FrameNo;
                                this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
                            }
                        }

                        // --- ADD 2013/03/22 ---------->>>>>
                        if (!this.CheckHandlePositionForChangeFocus(sender, e))
                            canChangeFocus = false;
                        // --- ADD 2013/03/22 ----------<<<<<

                        if (canChangeFocus)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    e.NextCtrl = this.tEdit_EngineModel;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region カラー
                //---------------------------------------------------------------
                // カラー
                //---------------------------------------------------------------
                case "tEdit_ColorNo":
                    {
                        string currentColorCode = this._extraInfo.ColorCode;
                        if (!string.IsNullOrEmpty(this.tEdit_ColorNo.Text.Trim()))
                        {
                            // ---UPD 2012/09/05 T.Nishi ---------->>>>>
                            //if (!this._carMngInputAcs.SelectColorInfo(this._extraInfo.CarRelationGuid, this.tEdit_ColorNo.Text.Trim(), this._extraInfo))
                            //{
                            //    this.tEdit_ColorNo.Text = string.Empty;
                            //    TMsgDisp.Show(
                            //        this,
                            //        emErrorLevel.ERR_LEVEL_INFO,
                            //        this.Name,
                            //        "カラーコードが設定範囲外です。",
                            //        -1,
                            //        MessageBoxButtons.OK);
                            //    this.tEdit_ColorNo.Text = currentColorCode;
                            //    this._carMngInputAcs.SelectColorInfo(this._extraInfo.CarRelationGuid, this.tEdit_ColorNo.Text.Trim(), this._extraInfo);
                            //    e.NextCtrl = prevCtrl;
                            //    changeCarInfo = false;
                            //    break;
                            //}
                            if (!this._carMngInputAcs.SelectColorInfo(this._extraInfo.CarRelationGuid, this.tEdit_ColorNo.Text.Trim(), this._extraInfo))
                            {
                                this._extraInfo.ColorCode = this.tEdit_ColorNo.Text.Trim();
                                this._extraInfo.ColorName1 = "";
                            }
                            // ---UPD 2012/09/05 T.Nishi ----------<<<<<
                        }
                        else
                        {
                            this._carMngInputAcs.SelectColorInfo(this._extraInfo.CarRelationGuid, this.tEdit_ColorNo.Text.Trim(), this._extraInfo);
                        }
                        break;
                    }
                #endregion

                #region トリム
                //---------------------------------------------------------------
                // トリム
                //---------------------------------------------------------------
                case "tEdit_TrimNo":
                    {
                        string currentTrimCode = this._extraInfo.TrimCode;
                        if (!string.IsNullOrEmpty(this.tEdit_TrimNo.Text.Trim()))
                        {
                            // ---UPD 2012/09/05 T.Nishi ---------->>>>>
                            //if (!this._carMngInputAcs.SelectTrimInfo(this._extraInfo.CarRelationGuid, this.tEdit_TrimNo.Text.Trim(), this._extraInfo))
                            //{
                            //    this.tEdit_TrimNo.Text = string.Empty;
                            //    TMsgDisp.Show(
                            //        this,
                            //        emErrorLevel.ERR_LEVEL_INFO,
                            //        this.Name,
                            //        "トリムコードが設定範囲外です。",
                            //        -1,
                            //        MessageBoxButtons.OK);
                            //    this.tEdit_TrimNo.Text = currentTrimCode;
                            //    this._carMngInputAcs.SelectTrimInfo(this._extraInfo.CarRelationGuid, this.tEdit_TrimNo.Text.Trim(), this._extraInfo);
                            //    e.NextCtrl = prevCtrl;
                            //    changeCarInfo = false;
                            //    break;
                            //}
                            if (!this._carMngInputAcs.SelectTrimInfo(this._extraInfo.CarRelationGuid, this.tEdit_TrimNo.Text.Trim(), this._extraInfo))
                            {
                                this._extraInfo.TrimCode = this.tEdit_TrimNo.Text.Trim();
                                this._extraInfo.TrimName = "";
                            }
                            // ---UPD 2012/09/05 T.Nishi ----------<<<<<
                        }
                        else
                        {
                            this._carMngInputAcs.SelectTrimInfo(this._extraInfo.CarRelationGuid, this.tEdit_TrimNo.Text.Trim(), this._extraInfo);
                        }

                        switch (e.Key)
                        {
                            case Keys.Down:
                                e.NextCtrl = this.tEdit_EngineModel;
                                break;
                            default:
                                break;
                        }

                        break;
                    }
                #endregion

                #region カラー情報
                //---------------------------------------------------------------
                // カラー情報
                //---------------------------------------------------------------
                case "uGrid_ColorInfo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    this._carOtherInfoInput.ReturnKeyDown(prevCtrl);
                                    e.NextCtrl = null;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion

                #region トリム情報
                //---------------------------------------------------------------
                // トリム情報
                //---------------------------------------------------------------
                case "uGrid_TrimInfo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    this._carOtherInfoInput.ReturnKeyDown(prevCtrl);
                                    e.NextCtrl = null;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion

                #region 装備情報
                //---------------------------------------------------------------
                // 装情報
                //---------------------------------------------------------------
                case "uGrid_EquipInfo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    this._carOtherInfoInput.ReturnKeyDown(prevCtrl);
                                    e.NextCtrl = null;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion

                #region 原動機型式
                //---------------------------------------------------------------
                // 原動機型式
                //---------------------------------------------------------------
                case "tEdit_EngineModel":
                    {
                        this._extraInfo.EngineModel = this.tEdit_EngineModel.Text;
                        break;
                    }
                #endregion

                #region 追加情報１
                //---------------------------------------------------------------
                // 追加情報１
                //---------------------------------------------------------------
                case "tEdit_CarAddInfo1":
                    {
                        this._extraInfo.CarAddInfo1 = this.tEdit_CarAddInfo1.Text;
                        break;
                    }
                #endregion

                #region 追加情報２
                //---------------------------------------------------------------
                // 追加情報２
                //---------------------------------------------------------------
                case "tEdit_CarAddInfo2":
                    {
                        this._extraInfo.CarAddInfo2 = this.tEdit_CarAddInfo2.Text;
                        break;
                    }
                #endregion

                #region 陸運事務所番号
                //---------------------------------------------------------------
                // 陸運事務所番号
                //---------------------------------------------------------------
                case "tNedit_NumberPlate1Code":
                    {
                        Int32 code = this.tNedit_NumberPlate1Code.GetInt();
                        if (code != 0)
                        {
                            if (this._extraInfo.NumberPlate1Code != code)
                            {
                                string guideName = this.GetNumberPlate1Name(code);
                                if (!string.IsNullOrEmpty(guideName))
                                {
                                    this._extraInfo.NumberPlate1Code = code;
                                    // this._extraInfo.NumberPlate1Name = guideName;
                                    if (guideName.Length>4)
                                    {
                                        this._extraInfo.NumberPlate1Name = guideName.Substring(0, 4); // ADD 2009/10/10
                                    }
                                    else
                                    {
                                        this._extraInfo.NumberPlate1Name = guideName;
                                    }
                                        this.tEdit_NumberPlate1Name.Text = guideName;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "陸運事務所コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = e.PrevCtrl;
                                    this.tNedit_NumberPlate1Code.SetInt(this._extraInfo.NumberPlate1Code);
                                    this.tEdit_NumberPlate1Name.Text = this._extraInfo.NumberPlate1Name;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this._extraInfo.NumberPlate1Code = 0;
                            this._extraInfo.NumberPlate1Name = string.Empty;
                        }
                        this.tNedit_NumberPlate1Code.SetInt(this._extraInfo.NumberPlate1Code);
                        this.tEdit_NumberPlate1Name.Text = this._extraInfo.NumberPlate1Name;

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (this.tNedit_NumberPlate1Code.GetInt() != 0)
                                    {
                                        e.NextCtrl = this.tEdit_NumberPlate2;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_NumberPlate1Guide;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 陸運事務所番号ガイド
                //---------------------------------------------------------------
                // 陸運事務所番号ガイド
                //---------------------------------------------------------------
                case "uButton_NumberPlate1Guide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    nextCtrl = this.tEdit_NumberPlate2;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 登録番号(種別)
                //---------------------------------------------------------------
                // 登録番号(種別)
                //---------------------------------------------------------------
                case "tEdit_NumberPlate2":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    nextCtrl = this.tNedit_NumberPlate1Code;
                                    break;
                                default:
                                    break;
                            }
                        }
                        this._extraInfo.NumberPlate2 = this.tEdit_NumberPlate2.Text;
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 登録番号(カナ)
                //---------------------------------------------------------------
                // 登録番号(カナ)
                //---------------------------------------------------------------
                case "tEdit_NumberPlate3":
                    {
                        this._extraInfo.NumberPlate3 = this.tEdit_NumberPlate3.Text;
                        break;
                    }
                #endregion

                #region 登録番号(プレート番号)
                //---------------------------------------------------------------
                // 登録番号(プレート番号)
                //---------------------------------------------------------------
                case "tNedit_NumberPlate4":
                    {
                        this._extraInfo.NumberPlate4 = this.tNedit_NumberPlate4.GetInt();
                        break;
                    }
                #endregion

                #region 走行距離
                //---------------------------------------------------------------
                // 走行距離
                //---------------------------------------------------------------
                case "tNedit_Mileage":
                    {
                        this._extraInfo.Mileage = this.tNedit_Mileage.GetInt();
                        this.tNedit_Mileage.Text = this._extraInfo.Mileage.ToString("#,###");
                        break;
                    }
                #endregion

                #region 登録年月日
                //---------------------------------------------------------------
                // 登録年月日
                //---------------------------------------------------------------
                case "tDateEdit_EntryDate":
                    {
                        this._extraInfo.EntryDate = this.tDateEdit_EntryDate.GetDateTime();
                        break;
                    }
                #endregion

                #region 車検期間
                //---------------------------------------------------------------
                // 車検期間
                //---------------------------------------------------------------
                case "tNedit_CarInspectYear":
                    {
                        this._extraInfo.CarInspectYear = this.tNedit_CarInspectYear.GetInt();
                        break;
                    }
                #endregion

                #region 前回車検日
                //---------------------------------------------------------------
                // 前回車検日
                //---------------------------------------------------------------
                case "tDateEdit_LTimeCiMatDate":
                    {
                        // ---- ADD 2009/10/10 ------>>>>> 
                        // 前回車検日を入力後、次回車検日が空白の場合は、次回車検日へ前回車検日＋期間で初期表示する
                        if (this.tDateEdit_InspectMaturityDate.GetDateTime() == DateTime.MinValue
                                         && this.tDateEdit_LTimeCiMatDate.GetDateTime() != DateTime.MinValue)
                        {
                            DateTime newTime2 = this.tDateEdit_LTimeCiMatDate.GetDateTime();
                            this.tDateEdit_InspectMaturityDate.SetDateTime(newTime2.AddYears(this.tNedit_CarInspectYear.GetInt()));
                            this._extraInfo.InspectMaturityDate = this.tDateEdit_InspectMaturityDate.GetDateTime();
                        }
                        // ---- ADD 2009/10/10 ------<<<<<
                        this._extraInfo.LTimeCiMatDate = this.tDateEdit_LTimeCiMatDate.GetDateTime();
                        break;
                    }
                #endregion

                #region 次回車検日
                //---------------------------------------------------------------
                // 次回車検日
                //---------------------------------------------------------------
                case "tDateEdit_InspectMaturityDate":
                    {
                        this._extraInfo.InspectMaturityDate = this.tDateEdit_InspectMaturityDate.GetDateTime();
                        break;
                    }
                #endregion

                #region 備考
                //---------------------------------------------------------------
                // 備考
                //---------------------------------------------------------------
                case "tEdit_SlipNote":
                    {
                        this._extraInfo.CarNote = this.tEdit_SlipNote.Text;
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    if (string.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim()))
                                    {
                                        nextCtrl = this.uButton_SlipNoteGuide;
                                    }
                                    else
                                    {
                                        nextCtrl = this.uButton_SearchChange;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 備考ガイド
                //---------------------------------------------------------------
                // 備考ガイド
                //---------------------------------------------------------------
                case "uButton_SlipNoteGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    nextCtrl = this.uButton_SearchChange;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion

                #region 検索切替
                //---------------------------------------------------------------
                // 検索切替
                //---------------------------------------------------------------
                case "uButton_SearchChange":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    nextCtrl = this.tEdit_SlipNote;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (nextCtrl != null) e.NextCtrl = nextCtrl;
                        break;
                    }
                #endregion
            }

            if (changeCarInfo == true)
            {
                this.SetDisplayCarInfo(this._extraInfo, false);
            }
        }

        // --- ADD 2013/03/22 ---------->>>>>
        /// <summary>
        /// フォーカス移動時のハンドルチェック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーカス移動時のハンドルチェック処理</br>      
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       : 2013/03/22</br>
        /// </remarks>
        private bool CheckHandlePositionForChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            bool ret = true;

            // 入力チェック
            if (!string.IsNullOrEmpty(this._beforeCarSearchBuffer.ProduceFrameNo) ||
                (!string.IsNullOrEmpty(this.tEdit_ProduceFrameNo.Text)))
            {
                // 型式が入力済みかつ、メーカーコードがBENZ、
                // VINコードが入力済みの場合(外車の場合)
                // ハンドル位置をチェックする
                if (!string.IsNullOrEmpty(this._extraInfo.FullModel) &&
                this._extraInfo.DomesticForeignCode == 2 &&
                this.tNedit_MakerCode.GetInt() == 80 &&
                !this._carMngInputAcs.CompareHandlePosition(this._extraInfo.FrameNo))
                {
                    ret = false;

                    // フォーカスを車台番号に移動する
                    // ※更新モード用
                    this.tEdit_ProduceFrameNo.Focus();

                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "ハンドル位置が異なります。",
                    -1,
                    MessageBoxButtons.OK);
                    e.NextCtrl = this.tEdit_ProduceFrameNo;
                    this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
                }
            }

            return ret;

        }
        // --- ADD 2013/03/22 ----------<<<<<

        /// <summary>
        /// グリッド初期設定イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グリッド初期設定イベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ultraGrid_CarSpec_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列初期設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_CarSpec.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                if ((col.Key == this._carSpecDataTable.AddiCarSpec1Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec2Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec3Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec4Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec5Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec6Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.BodyNameColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.DoorCountColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.EDivNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.EngineModelNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.ModelGradeNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.ShiftNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.TransmissionNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName))
                {
                    col.Hidden = false;
                }
            }

            //---------------------------------------------------------------------
            // 入力許可設定
            //---------------------------------------------------------------------
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            //---------------------------------------------------------------------
            // フォーマット設定
            //---------------------------------------------------------------------
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].Format = "#0;'';''";

        }

        /// <summary>
        /// ultraGrid_CarSpec_KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ultraGrid_CarSpec_KeyDownイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ultraGrid_CarSpec_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.ultraGrid_CarSpec.BeginUpdate();

                //-----------------------------------------------------------------------------
                // ActivCell判定
                //-----------------------------------------------------------------------------
                if (this.ultraGrid_CarSpec.ActiveCell != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.ultraGrid_CarSpec.ActiveCell;

                    switch (e.KeyCode)
                    {
                        //-----------------------------------------------------------------------------
                        // UP
                        //-----------------------------------------------------------------------------
                        case Keys.Up:
                            this.tEdit_FullModel.Focus(); // 型式へ移動
                            e.Handled = true;
                            break;
                        //-----------------------------------------------------------------------------
                        // DOWN
                        //-----------------------------------------------------------------------------
                        case Keys.Down:
                            this.tEdit_EngineModel.Focus(); // 原動機型式へ移動
                            e.Handled = true;
                            break;
                    }
                }
            }
            finally
            {
                this.ultraGrid_CarSpec.EndUpdate();
            }
        }

        /// <summary>
        /// 諸元グリッド　Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 諸元グリッド　Leaveイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ultraGrid_CarSpec_Leave(object sender, EventArgs e)
        {
            if (this.ultraGrid_CarSpec.ActiveRow != null)
            {
                this.ultraGrid_CarSpec.ActiveRow.Selected = false;
                this.ultraGrid_CarSpec.ActiveRow = null;
            }
            if (this.ultraGrid_CarSpec.ActiveCell != null)
            {
                this.ultraGrid_CarSpec.ActiveCell.Selected = false;
                this.ultraGrid_CarSpec.ActiveCell = null;
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA();

            customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            if (customerSearchForm.ShowDialog(this) == DialogResult.OK)
            {
                if (sender == this.uButton_CustomerGuide)
                {
                    // 次の項目へフォーカス移動
                    ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, (Control)sender, (Control)sender);
                    this.tRetKeyControl1_ChangeFocus(this, changeFocusEventArgs);
                    if (changeFocusEventArgs.NextCtrl != null)
                    {
                        changeFocusEventArgs.NextCtrl.Focus();
                    }
                }
                this._extraInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
            }

            this.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// 管理番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 管理番号ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
            CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
            paramInfo.EnterpriseCode = this._enterpriseCode;
            // 「新規登録」行表示なし
            paramInfo.IsDispNewRow = false;
            // ----ADD 2009/10/10 ------>>>>>
            if (this.tNedit_CustomerCode.GetInt() == 0)
            {
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
            }
            else
            {
                // 得意先表示なし
                paramInfo.IsDispCustomerInfo = false;
                paramInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
                paramInfo.IsCheckCustomerCode = true;
            }
            // ----ADD 2009/10/10 ------<<<<<
           
            // 管理番号絞り込み無し
            paramInfo.IsCheckCarMngCode = false;
            // 車輌管理区分チェック無し
            paramInfo.IsCheckCarMngDivCd = false;
            // ガイドイベントフラグ
            paramInfo.IsGuideClick = true;
            
            int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
            
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (selectedInfo.CarMngCode != "新規登録")
                {
                    this._extraInfo = selectedInfo.Clone();
                    //this.ShowUpdateOrDeleteModeScreen(selectedInfo.CustomerCode, selectedInfo.CarMngNo, false); // 2009/12/24
                    this.ShowUpdateOrDeleteModeScreen(selectedInfo.CustomerCode, selectedInfo.CarMngNo, selectedInfo.CarMngCode, false); // 2009/12/24
                }
            }
            

        }

        /// <summary>
        /// 型式指定番号の入力変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 型式指定番号の入力変更イベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void tNedit_ModelDesignationNo_ValueChanged(object sender, EventArgs e)
        {
            string modelDesignationNo = this.tNedit_ModelDesignationNo.Text;


            if (this.tNedit_ModelDesignationNo.Focused)
            {
                if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
                {
                    this.tNedit_CategoryNo.Focus();
                }
            }
        }

        /// <summary>
        /// 型式ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 型式ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_ChangeSearchCarMode_Click(object sender, EventArgs e)
        {
            this.ChangeSearchCarMode();
        }

        /// <summary>
        /// 車種ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 車種ガイドボタンクリックイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode = this.tNedit_MakerCode.GetInt();
            int status = modelNameUAcs.ExecuteGuid(makerCode, this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SettingCarInfoRowFromModelInfo(modelNameU);
                this.SetDisplayCarInfo(this._extraInfo, false);

                // 次の項目へフォーカス移動
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_ModelFullGuide, this.uButton_ModelFullGuide);
                this.tRetKeyControl1_ChangeFocus(this, changeFocusEventArgs);
                if (changeFocusEventArgs.NextCtrl != null)
                {
                    changeFocusEventArgs.NextCtrl.Focus();
                }
            }
        }

        /// <summary>
        /// 陸運事務所番号イドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 陸運事務所番号イドボタンクリックイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_NumberPlate1Guide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();
                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, ctDIVCODE_UserGuideDivCd);
                
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    string numberPlate1Name = this.GetNumberPlate1Name(userGdBd.GuideCode);

                    if (!string.IsNullOrEmpty(numberPlate1Name))
                    {
                        this.tNedit_NumberPlate1Code.SetInt(userGdBd.GuideCode);
                        this._extraInfo.NumberPlate1Code = userGdBd.GuideCode;
                        // this.tEdit_NumberPlate1Name.Text = numberPlate1Name;
                        if (numberPlate1Name.Length>4)
                        {
                            this.tEdit_NumberPlate1Name.Text = numberPlate1Name.Substring(0, 4);  // ADD 2009/10/10
                        }
                        else
                        {
                            this.tEdit_NumberPlate1Name.Text = numberPlate1Name;
                        }
                        
                        this._extraInfo.NumberPlate1Name = numberPlate1Name;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "陸運事務所コードが存在しません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                }
                // 次の項目へフォーカス移動
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_NumberPlate1Guide, this.uButton_NumberPlate1Guide);
                this.tRetKeyControl1_ChangeFocus(this, changeFocusEventArgs);
                if (changeFocusEventArgs.NextCtrl != null)
                {
                    changeFocusEventArgs.NextCtrl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 備考イドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 備考イドボタンクリックイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_SlipNoteGuide_Click(object sender, EventArgs e)
        {
            NoteGuidBd noteGuidBd;

            int status = this._noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, ctDIVCODE_NoteGuideDivCd);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.tEdit_SlipNote.Text = noteGuidBd.NoteGuideName;
                this._extraInfo.CarNote = noteGuidBd.NoteGuideName;
            }

            // 次の項目へフォーカス移動
            ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.uButton_SlipNoteGuide, this.uButton_SlipNoteGuide);
            this.tRetKeyControl1_ChangeFocus(this, changeFocusEventArgs);
            if (changeFocusEventArgs.NextCtrl != null)
            {
                changeFocusEventArgs.NextCtrl.Focus();
            }
        }

        /// <summary>
        /// 検索切替ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 検索切替ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_SearchChange_Click(object sender, EventArgs e)
        {
            this.ChangeSearchCar();
        }

        /// <summary>
        /// 手入力ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 手入力ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_HandInput_Click(object sender, EventArgs e)
        {
            if (this._isHandType == true)
            {
                // 通常モードへ変更
                this._isHandType = false;
                this.uLabel_InputTypeTitle.Visible = false;
                this.uButton_CarMngNoGuide.Visible = true;
                this.uButton_CarMngNoGuide.Enabled = true;
            }
            else
            {
                // 手入力モードへ変更
                this._isHandType = true;
                this.uLabel_InputTypeTitle.Visible = true;
                this.uButton_CarMngNoGuide.Visible = false;
                // 更新モードから新規モードへ変更する
                if (this._mode == UPDATE_MODE)
                {
                    this._mode = INSERT_MODE;
                    this.uLabel_InputModeTitle.Text = this._mode;
                    this.tNedit_CustomerCode.Enabled = true;
                    this.uButton_CustomerGuide.Enabled = true;
                    this.tEdit_CarMngCode.Enabled = true;
                    this._extraInfo.UpdateDateTime = DateTime.MinValue;
                }
            }
        }

        /// <summary>
        /// 最新情報ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 最新情報ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_Renewal_Click(object sender, EventArgs e)
        {
            // -----UPD 2009/10/10 ------>>>>> 
            // 最新情報取得時に、変更データがある場合は、確認メッセージを出さないように修正。
            //if (this.IsHaveDataChanged() == true)
            //{
            //    DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
            //        "登録してもよろしいですか？",
            //        0,
            //        MessageBoxButtons.YesNoCancel,
            //        MessageBoxDefaultButton.Button1);

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        this.SaveData();
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        // マスタデータの読込
            //        this.LoadMasterData();
            //    }
            //    else
            //    {
            //        this.DialogResult = DialogResult.None;
            //        return;
            //    }
            //}
            //else
            //{
                // マスタデータの読込
                this.LoadMasterData();
            //}
            // -----UPD 2009/10/10 ------<<<<<
        }

        /// <summary>
        /// 保存ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 保存ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_Ok_Click(object sender, EventArgs e)
        {
            // データ保存処理
            this.SaveData();
        }

        /// <summary>
        /// 復活ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 復活ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_Revive_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;

            // 復活処理
            status = this._carMngInputAcs.RevivalLogicalDelete(ref this._extraInfo, out errMsg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 登録完了
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // 一括入力画面のグリッドへ変更する
                        this.UpdRowToList(true);

                        this.RefreshParent(true);

                        // 画面を閉じる
                        this.Close();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        this.ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            "復活処理に失敗しました。",
                            status,
                            MessageBoxButtons.OK);
                        break;
                    }
            }

            return;
        }

        /// <summary>
        /// 完全削除ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンイベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_Delete_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "データを削除します。" + "\r\n" + "\r\n" +
                "よろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // 完全削除処理
            status = this._carMngInputAcs.Delete(this._extraInfo, out errMsg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 一括入力画面のグリッドから削除する
                        this.DelRowFromList();

                        this.RefreshParent(true);
                        // 画面を閉じる
                        this.Close();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        this.ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        // 完全削除失敗
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            "完全削除処理に失敗しました。",
                            status,
                            MessageBoxButtons.OK);
                        break;
                    }
            }

            return;
        }

        /// <summary>
        /// 閉じるボタンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            if (this.IsHaveDataChanged() == true)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
                    "登録してもよいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    this.SaveData();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Method
        /// <summary>
        /// 初期データ取得スレッド
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期データ取得スレッドです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void InitialReadThread()
        {
            this._carMngInputAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化の設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void InitScreenDataInfo()
        {
            // 新規モード
            if (this._mode == INSERT_MODE)
            {
                this.ShowInsertModeScreen();
            }
            // 修正、削除モード
            else
            {
                CarMngInputDataSet.CarInfoRow carInfoRow = this._listAcs.CarInfoDataTable.FindByCarRelationGuid(this._guid);
                //this.ShowUpdateOrDeleteModeScreen(Convert.ToInt32(carInfoRow.CustomerCode), Convert.ToInt32(carInfoRow.CarMngNo), true); // 2009/12/24
                this.ShowUpdateOrDeleteModeScreen(Convert.ToInt32(carInfoRow.CustomerCode), Convert.ToInt32(carInfoRow.CarMngNo), carInfoRow.CarMngCode, true); // 2009/12/24
            }
        }

        /// <summary>
        /// 新規モードの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規モードの初期化処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ShowInsertModeScreen()
        {
            this.uButton_SearchChange.Visible = true;       // 検索切替
            this.uButton_HandInput.Visible = true;          // 手入力
            this.uButton_Renewal.Visible = true;            // 最新情報
            this.uButton_Ok.Visible = true;                 // 保存
            this.uButton_Delete.Visible = false;            // 完全削除
            this.uButton_Revive.Visible = false;            // 復活

            // システム年月日
            DateTime sysDate = DateTime.Now;
            // 登録年月日
            this.tDateEdit_EntryDate.SetDateTime(sysDate);
            this._extraInfo.EntryDate = this.tDateEdit_EntryDate.GetDateTime();
            // 車検期間
            this.tNedit_CarInspectYear.SetInt(2);
            this._extraInfo.CarInspectYear = this.tNedit_CarInspectYear.GetInt();
            // 前回車検日
            this.tDateEdit_LTimeCiMatDate.SetDateTime(sysDate);
            this._extraInfo.LTimeCiMatDate = this.tDateEdit_LTimeCiMatDate.GetDateTime();
            // 次回車検日
            this.tDateEdit_InspectMaturityDate.SetDateTime(sysDate.AddYears(2));
            this._extraInfo.InspectMaturityDate = this.tDateEdit_InspectMaturityDate.GetDateTime();

            // 原動機型式
            this.tEdit_EngineModel.Text = string.Empty;
            // 追加情報１
            this.tEdit_CarAddInfo1.Text = string.Empty;
            // 追加情報２
            this.tEdit_CarAddInfo2.Text = string.Empty;
            // 登録番号（陸運事務所番号）
            this.tNedit_NumberPlate1Code.SetInt(0);
            // 登録番号(陸運事務所名称)
            this.tEdit_NumberPlate1Name.Text = string.Empty;
            // 登録番号(種別)
            this.tEdit_NumberPlate2.Text = string.Empty;
            // 登録番号(カナ)
            this.tEdit_NumberPlate3.Text = string.Empty;
            // 登録番号(プレート番号)
            this.tNedit_NumberPlate4.SetInt(0);
            // 走行距離
            // this.tNedit_Mileage.SetInt(0);
            this.tNedit_Mileage.Text = string.Empty;
            // 車輌備考
            this.tEdit_SlipNote.Text = string.Empty;

            this._carMngInputAcs.ClearColorInfo();
            this._carMngInputAcs.ClearTrimInfo();
            this._carMngInputAcs.ClearEquipInfo();

            // 車輌情報データ→画面
            this.SetDisplayCarInfo(this._extraInfo, false);
        }

        /// <summary>
        /// 更新モードの初期化処理
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="carMngNo"></param>
        /// <param name="carMngCode"></param>
        /// <param name="isSearch">検索かどうか</param>
        /// <remarks>
        /// <br>Note       : 更新モードの初期化処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        //private void ShowUpdateOrDeleteModeScreen(Int32 customerCode, Int32 carMngNo, bool isSearch) //
        private void ShowUpdateOrDeleteModeScreen(Int32 customerCode, Int32 carMngNo, string carMngCode, bool isSearch)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;

            // 得意先コード
            this._extraInfo.CustomerCode = customerCode;
            this.tNedit_CustomerCode.SetInt(this._extraInfo.CustomerCode);
            this.tNedit_CustomerCode.Enabled = false;
            // 得意先略称
            this.tEdit_CustomerName.Text = this.GetCustomerSnm(this._extraInfo.CustomerCode);
            // 得意先ガイド
            this.uButton_CustomerGuide.Enabled = false;
            // 車輌管理番号
            this._extraInfo.CarMngNo = carMngNo;

            this._extraInfo.CarMngCode = carMngCode; //2009/12/24

            this.Cursor = Cursors.WaitCursor;
            if (isSearch == true)
            {
                // データ検索
                status = this._carMngInputAcs.ReadDB(ref this._extraInfo, 0, out errMsg);
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            // 車輌再検索
            this._carMngInputAcs.CacheCarOtherInfo(ref this._extraInfo);

            this._extraInfoForChangeCheck = this._extraInfo.Clone();
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._extraInfo.LogicalDeleteCode == 0)
                {
                    // 有効データの場合
                    this._mode = UPDATE_MODE;
                }
                else
                {
                    // 無効データの場合
                    this._mode = DELETE_MODE;
                }

                // 車輌情報データ→画面
                this.SetDisplayCarInfo(this._extraInfo, true);

                // 管理番号
                this.tEdit_CarMngCode.Text = this._extraInfo.CarMngCode;
                this.tEdit_CarMngCode.Enabled = false;
                // 管理番号ガイド
                this.uButton_CarMngNoGuide.Enabled = false;

                // 原動機型式
                this.tEdit_EngineModel.Text = this._extraInfo.EngineModel;
                // 追加情報１
                this.tEdit_CarAddInfo1.Text = this._extraInfo.CarAddInfo1;
                // 追加情報２
                this.tEdit_CarAddInfo2.Text = this._extraInfo.CarAddInfo2;
                // 登録番号（陸運事務所番号）
                this.tNedit_NumberPlate1Code.SetInt(this._extraInfo.NumberPlate1Code);
                // 登録番号(陸運事務所名称)
                this.tEdit_NumberPlate1Name.Text = this._extraInfo.NumberPlate1Name;
                // 登録番号(種別)
                this.tEdit_NumberPlate2.Text = this._extraInfo.NumberPlate2;
                // 登録番号(カナ)
                this.tEdit_NumberPlate3.Text = this._extraInfo.NumberPlate3;
                // 登録番号(プレート番号)
                this.tNedit_NumberPlate4.SetInt(this._extraInfo.NumberPlate4);
                // 走行距離
                //this.tNedit_Mileage.SetInt(this._extraInfo.Mileage);
                this.tNedit_Mileage.Text = this._extraInfo.Mileage.ToString("#,###");
                // 登録年月日
                this.tDateEdit_EntryDate.SetDateTime(this._extraInfo.EntryDate);
                // 車検期間
                this.tNedit_CarInspectYear.SetInt(this._extraInfo.CarInspectYear);
                // 前回車検日
                this.tDateEdit_LTimeCiMatDate.SetDateTime(this._extraInfo.LTimeCiMatDate);
                // 次回車検日
                this.tDateEdit_InspectMaturityDate.SetDateTime(this._extraInfo.InspectMaturityDate);
                // 車輌備考
                this.tEdit_SlipNote.Text = this._extraInfo.CarNote;
                // カラー情報の選択設定
                // --- ADD 2012/09/27 Y.Wakita ---------->>>>>
                string colorCode = this._extraInfo.ColorCode.Trim();
                // --- ADD 2012/09/27 Y.Wakita ----------<<<<<
                this._carMngInputAcs.SelectColorInfo(this._extraInfo.CarRelationGuid, this._extraInfo.ColorCode, this._extraInfo);
                // --- ADD 2012/09/27 Y.Wakita ---------->>>>>
                if ((this._extraInfo.ColorCode.Trim() == "") && (colorCode != ""))
                {
                    this._extraInfo.ColorCode = colorCode;
                }
                // --- ADD 2012/09/27 Y.Wakita ----------<<<<<
                // トリム情報の選択設定
                // --- ADD 2012/09/27 Y.Wakita ---------->>>>>
                string trimCode = this._extraInfo.TrimCode.Trim();
                // --- ADD 2012/09/27 Y.Wakita ----------<<<<<
                this._carMngInputAcs.SelectTrimInfo(this._extraInfo.CarRelationGuid, this._extraInfo.TrimCode, this._extraInfo);
                // --- ADD 2012/09/27 Y.Wakita ---------->>>>>
                if ((this._extraInfo.TrimCode.Trim() == "") && (trimCode != ""))
                {
                    this._extraInfo.TrimCode = trimCode;
                }
                // --- ADD 2012/09/27 Y.Wakita ----------<<<<<
                // 装備情報の選択設定
                this._carMngInputAcs.SelectEquipInfo(this._extraInfo.CarRelationGuid, this._extraInfo.CategoryObjAry);
                this._carOtherInfoInput.SettingEquipGridLayout();

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                // 既に削除の場合
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    "既に他端末より削除されています。",
                    status,
                    MessageBoxButtons.OK);
                this.Close();
                return;
            }
            else
            {
                // 検索エラーの場合
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMsg,
                    status,
                    MessageBoxButtons.OK);
                this.Close();
                return;
            }

            // 設定種別
            this.uLabel_InputModeTitle.Text = this._mode;
            if (this._mode == UPDATE_MODE)
            {
                // 更新モード
                this.uButton_SearchChange.Visible = true;       // 検索切替
                this.uButton_HandInput.Visible = true;          // 手入力
                this.uButton_Renewal.Visible = true;            // 最新情報
                this.uButton_Ok.Visible = true;                 // 保存
                this.uButton_Delete.Visible = false;            // 完全削除
                this.uButton_Revive.Visible = false;            // 復活

                // --- ADD 2013/03/22 ---------->>>>>
                // PMNS:フォーカス発生イベント
                // 更新モードで読み込んだ場合に、ハンドル位置チェックを行うため
                // フォーカス移動イベントを発生させる
                ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tNedit_CustomerCode, this.tNedit_CustomerCode);
                this.tRetKeyControl1_ChangeFocus(this, changeFocusEventArgs);
                // --- ADD 2013/03/22 ----------<<<<<
            }
            else
            {
                // 削除モード
                this.uButton_SearchChange.Visible = false;      // 検索切替
                this.uButton_HandInput.Visible = false;         // 手入力
                this.uButton_Renewal.Visible = false;           // 最新情報
                this.uButton_Ok.Visible = false;                // 保存
                this.uButton_Delete.Visible = true;             // 完全削除
                this.uButton_Revive.Visible = true;             // 復活

                // カラー・トリム・装備(&1)
                this.uExpandableGroupBox_CarInfo.Enabled = false;
                this.uExpandableGroupBox_CarInfo.Expanded = false;

                // 型式指定番号
                this.tNedit_ModelDesignationNo.Enabled = false;
                // 類別区分番号
                this.tNedit_CategoryNo.Enabled = false;
                // 型式ボタン
                this.uButton_ChangeSearchCarMode.Enabled = false;
                // 型式
                this.tEdit_FullModel.Enabled = false;
                // エンジン型式
                this.tEdit_EngineModelNm.Enabled = false;
                // カーメーカーコード
                this.tNedit_MakerCode.Enabled = false;
                // 車種コード
                this.tNedit_ModelCode.Enabled = false;
                // 車種呼称コード
                this.tNedit_ModelSubCode.Enabled = false;
                // 車種名称
                this.tEdit_ModelFullName.Enabled = false;
                // 車種ガイド
                this.uButton_ModelFullGuide.Enabled = false;
                // 年式
                this.tDateEdit_FirstEntryDate.Enabled = false;
                // 車台番号
                this.tEdit_ProduceFrameNo.Enabled = false;
                // カラー
                this.tEdit_ColorNo.Enabled = false;
                // トリム
                this.tEdit_TrimNo.Enabled = false;
                // 原動機型式
                this.tEdit_EngineModel.Enabled = false;
                // 追加情報１
                this.tEdit_CarAddInfo1.Enabled = false;
                // 追加情報２
                this.tEdit_CarAddInfo2.Enabled = false;
                // 登録番号（陸運事務所番号）
                this.tNedit_NumberPlate1Code.Enabled = false;
                // 陸運事務所番号ガイド
                this.uButton_NumberPlate1Guide.Enabled = false;
                // 登録番号(陸運事務所名称)
                this.tEdit_NumberPlate1Name.Enabled = false;
                // 登録番号(種別)
                this.tEdit_NumberPlate2.Enabled = false;
                // 登録番号(カナ)
                this.tEdit_NumberPlate3.Enabled = false;
                // 登録番号(プレート番号)
                this.tNedit_NumberPlate4.Enabled = false;
                // 走行距離
                this.tNedit_Mileage.Enabled = false;
                // 登録年月日
                this.tDateEdit_EntryDate.Enabled = false;
                // 車検期間
                this.tNedit_CarInspectYear.Enabled = false;
                // 前回車検日
                this.tDateEdit_LTimeCiMatDate.Enabled = false;
                // 次回車検日
                this.tDateEdit_InspectMaturityDate.Enabled = false;
                // 車輌備考
                this.tEdit_SlipNote.Enabled = false;
                // 車輌備考ガイド
                this.uButton_SlipNoteGuide.Enabled = false;
            }
        }

        /// <summary>
        /// 画面表示処理（車輌情報）
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="isFromGuide">ガイドからかどうか</param>
        /// <remarks>
        /// <br>Note       : 画面表示処理（車輌情報）です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う車台番号・VINコード表示切替</br>
        /// </remarks>
        private void SetDisplayCarInfo(CarMangInputExtraInfo extraInfo, bool isFromGuide)
        {
            if (extraInfo == null) return;

            try
            {
                this._carOtherInfoInput.uGrid_EquipInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_TrimInfo.BeginUpdate();

                this.tNedit_ModelDesignationNo.BeginUpdate();
                this.tNedit_CategoryNo.BeginUpdate();
                this.tEdit_EngineModelNm.BeginUpdate();
                this.tEdit_FullModel.BeginUpdate();
                this.tNedit_MakerCode.BeginUpdate();
                this.tNedit_ModelCode.BeginUpdate();
                this.tNedit_ModelSubCode.BeginUpdate();
                this.tEdit_ModelFullName.BeginUpdate();
                this.tEdit_ProduceFrameNo.BeginUpdate();
                this.tEdit_ColorNo.BeginUpdate();
                this.tEdit_TrimNo.BeginUpdate();

                this.tNedit_ModelDesignationNo.SetInt(extraInfo.ModelDesignationNo);      // 型式指定番号
                this._tmpModelDesignationNo = extraInfo.ModelDesignationNo;
                this.tNedit_CategoryNo.SetInt(extraInfo.CategoryNo);                      // 類別区分番号
                this._tmpCategoryNo = extraInfo.CategoryNo;
                this.tEdit_FullModel.Text = extraInfo.FullModel;                          // 型式
                this._tmpFullModel = extraInfo.FullModel;  // ADD 2009/10/28
                this.tEdit_EngineModelNm.Text = extraInfo.EngineModelNm;                  // エンジン型式
                this._tmpEngineModelNm = extraInfo.EngineModelNm;  // ADD 2009/10/28
                this.tNedit_MakerCode.SetInt(extraInfo.MakerCode);                        // カーメーカーコード
                this.tNedit_ModelCode.SetInt(extraInfo.ModelCode);                        // 車種コード
                this.tNedit_ModelSubCode.SetInt(extraInfo.ModelSubCode);                  // 車種呼称コード
                this.tEdit_ModelFullName.Text = extraInfo.ModelFullName;                  // 車種名称
                
                // ADD 2013/03/22 -------------------->>>>>
                // 車台番号・VINコード表示切替
                if (extraInfo.DomesticForeignCode == 2)
                {
                    this.uLabel_ProduceFrameNo.Text = "VINｺｰﾄﾞ";
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.uLabel_ProduceFrameNo.Size = new Size(80, 24);
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(150, 24);
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    this.tEdit_ProduceFrameNo.ExtEdit.Column = 17;
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.tEdit_ProduceFrameNo.ExtEdit.EnableChars.Alpha = true;
                }
                else
                {
                    this.uLabel_ProduceFrameNo.Text = "車台番号";
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.uLabel_ProduceFrameNo.Size = new Size(67, 24);
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    this.tEdit_ProduceFrameNo.ExtEdit.Column = 8;
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.tEdit_ProduceFrameNo.ExtEdit.EnableChars.Alpha = false;
                }
                // ADD 2013/03/22 --------------------<<<<<   

                this.tDateEdit_FirstEntryDate.Clear();
                // 0:西暦
                if (this._carMngInputAcs.GetAllDefSet().EraNameDispCd1 == 0)
                {
                    this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.df4Y2M;
                }
                // 1:和歴
                else
                {
                    this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.dfG2Y2M;
                }

                if (extraInfo.ProduceTypeOfYearInput != 0) this.tDateEdit_FirstEntryDate.SetLongDate(extraInfo.ProduceTypeOfYearInput * 100 + 1); // 年式

                string stProduceTypeOfYear = this.GetProduceTypeOfYear(extraInfo.StProduceTypeOfYear);
                string edProduceTypeOfYear = this.GetProduceTypeOfYear(extraInfo.EdProduceTypeOfYear);
                this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);

                this.tEdit_ProduceFrameNo.Text = extraInfo.FrameNo;                        // 車台番号
                string stProduceFrameNo = (extraInfo.StProduceFrameNo != 0) ? string.Format("{0,8:########}", extraInfo.StProduceFrameNo) : string.Empty;
                string edProduceFrameNo = (extraInfo.EdProduceFrameNo != 0) ? string.Format("{0,8:########}", extraInfo.EdProduceFrameNo) : string.Empty;
                this.SettingProduceFrameNoRange(stProduceFrameNo, edProduceFrameNo);

                // --- ADD 2009/10/10 ----->>>>>
                //----------------------------------------------------------------
                // 車輌検索前に退避しておいた内容の再セット
                //----------------------------------------------------------------
                // 退避しておいた値のセット（※UI表示の都合により先にセットだけしておき、まとめて入力チェックする）


                if (!string.IsNullOrEmpty(this._beforeCarSearchBuffer.ProduceFrameNo))
                {
                    tEdit_ProduceFrameNo.Text = this._beforeCarSearchBuffer.ProduceFrameNo;
                    this._extraInfo.FrameNo = this._beforeCarSearchBuffer.ProduceFrameNo;
                }
                if (this._beforeCarSearchBuffer.FirstEntryDate != 0)
                {
                    tDateEdit_FirstEntryDate.SetLongDate(this._beforeCarSearchBuffer.FirstEntryDate);
                    this._extraInfo.FirstEntryDate = this._beforeCarSearchBuffer.FirstEntryDate;
                    this.SettingCarInfoRowFromFirstEntryDate(tDateEdit_FirstEntryDate.GetLongDate());
                }
                // --- ADD 2009/10/10 -----<<<<<

                // カラー情報
                this._carOtherInfoInput.ColorCdInfoDataTable = this._carMngInputAcs.GetColorInfo(extraInfo.CarRelationGuid);

                // カラー
                if (isFromGuide)
                {
                    // カラー
                    this.tEdit_ColorNo.Text = extraInfo.ColorCode;
                }
                else
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = this._carMngInputAcs.GetSelectColorInfo(extraInfo.CarRelationGuid);
                    if (colorInfoRow != null)
                    {
                        // カラー
                        this.tEdit_ColorNo.Text = colorInfoRow.ColorCode;
                    }
                    else
                    {
                        this.tEdit_ColorNo.Text = string.Empty;
                    }
                }

                // トリム情報
                this._carOtherInfoInput.TrimCdInfoDataTable = this._carMngInputAcs.GetTrimInfo(extraInfo.CarRelationGuid);

                // トリム
                if (isFromGuide)
                {
                    this.tEdit_TrimNo.Text = extraInfo.TrimCode;
                }
                else
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = this._carMngInputAcs.GetSelectTrimInfo(extraInfo.CarRelationGuid);
                    if (trimInfoRow != null)
                    {
                        this.tEdit_TrimNo.Text = trimInfoRow.TrimCode;
                    }
                    else
                    {
                        this.tEdit_TrimNo.Text = string.Empty;
                    }
                }

                // 諸元情報
                CarMngInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable[0];
                this._carMngInputAcs.SetCarSpecFromCarInfoRow(ref carSpecRow, this._extraInfo);
                this.SettingCarSpecGridCol(extraInfo);

                // 装備情報
                this._carOtherInfoInput.CEqpDefDspInfoDataTable = this._carMngInputAcs.GetEquipInfo(this._extraInfo.CarRelationGuid);
                this._carOtherInfoInput.SettingEquipGridLayout();

                // 車両情報共通キー
                this._carOtherInfoInput.CarRelationGuid = this._extraInfo.CarRelationGuid;

                #region Enabled設定
                this.tNedit_ModelCode.Enabled = true;
                this.tNedit_ModelSubCode.Enabled = true;

                // 車種コード、車種サブコード
                if (this.tNedit_MakerCode.GetInt() == 0)
                {
                    this.tNedit_ModelCode.Enabled = false;
                    this.tNedit_ModelSubCode.Enabled = false;
                }
                else if (this.tNedit_ModelCode.GetInt() == 0)
                {
                    this.tNedit_ModelSubCode.Enabled = false;
                }

                // カラー・トリム・装備情報
                if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
                     (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
                     (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
                     (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
                {
                    this.uExpandableGroupBox_CarInfo.Enabled = true;
                }
                else
                {
                    this.uExpandableGroupBox_CarInfo.Enabled = false;
                    this.uExpandableGroupBox_CarInfo.Expanded = false;
                }
                #endregion
            }
            finally
            {
                this.tNedit_ModelDesignationNo.EndUpdate();
                this.tNedit_CategoryNo.EndUpdate();
                this.tEdit_EngineModelNm.EndUpdate();
                this.tEdit_FullModel.EndUpdate();
                this.tNedit_MakerCode.EndUpdate();
                this.tNedit_ModelCode.EndUpdate();
                this.tNedit_ModelSubCode.EndUpdate();
                this.tEdit_ModelFullName.EndUpdate();
                this.tEdit_ProduceFrameNo.EndUpdate();
                this.tEdit_ColorNo.EndUpdate();
                this.tEdit_TrimNo.EndUpdate();
                this._carOtherInfoInput.uGrid_TrimInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_EquipInfo.EndUpdate();
            }
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列初期設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCarSpecGridCol(CarMangInputExtraInfo extraInfo)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_CarSpec.DisplayLayout.Bands[0];
            if (editBand == null) return;

            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].Hidden = (string.IsNullOrEmpty(extraInfo.AddiCarSpecTitle1)) ? true : false;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].Hidden = (string.IsNullOrEmpty(extraInfo.AddiCarSpecTitle2)) ? true : false;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].Hidden = (string.IsNullOrEmpty(extraInfo.AddiCarSpecTitle3)) ? true : false;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].Hidden = (string.IsNullOrEmpty(extraInfo.AddiCarSpecTitle4)) ? true : false;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].Hidden = (string.IsNullOrEmpty(extraInfo.AddiCarSpecTitle5)) ? true : false;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].Hidden = (string.IsNullOrEmpty(extraInfo.AddiCarSpecTitle6)) ? true : false;

            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ModelGradeNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].MaxLength = this._carSpecDataTable.BodyNameColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineModelNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineDisplaceNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EDivNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].MaxLength = this._carSpecDataTable.TransmissionNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].MaxLength = this._carSpecDataTable.WheelDriveMethodNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ShiftNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec1Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec2Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec3Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec4Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec5Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec6Column.MaxLength;

            this._carSpecDataTable.AddiCarSpec1Column.Caption = extraInfo.AddiCarSpecTitle1;
            this._carSpecDataTable.AddiCarSpec2Column.Caption = extraInfo.AddiCarSpecTitle2;
            this._carSpecDataTable.AddiCarSpec3Column.Caption = extraInfo.AddiCarSpecTitle3;
            this._carSpecDataTable.AddiCarSpec4Column.Caption = extraInfo.AddiCarSpecTitle4;
            this._carSpecDataTable.AddiCarSpec5Column.Caption = extraInfo.AddiCarSpecTitle5;
            this._carSpecDataTable.AddiCarSpec6Column.Caption = extraInfo.AddiCarSpecTitle6;
        }

        /// <summary>
        /// 生産年式取得処理(和歴／西暦)
        /// </summary>
        /// <param name="produceTypeOfYear">生産年式</param>
        /// <remarks>
        /// <br>Note       : 生産年式取得処理(和歴／西暦)です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>UpdateNote   2019/01/08  譚洪</br>
        /// <br>修正内容     新元号の対応</br>
        /// </remarks>
        private string GetProduceTypeOfYear(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            if (produceTypeOfYear != DateTime.MinValue)
            {
                if (this._carMngInputAcs.GetAllDefSet().EraNameDispCd1 == 0)
                {
                    // 0:西暦
                    int iyy = produceTypeOfYear.Year;
                    int imm = produceTypeOfYear.Month;
                    retYear = (produceTypeOfYear != DateTime.MinValue) ? string.Format(@"{0:0000}{1:\.00}", iyy, imm) : string.Empty;
                }
                else
                {
                    // 1:和歴
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                    //System.Globalization.DateTimeFormatInfo FormatInfo = null;
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
                    //System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
                    //culture.DateTimeFormat.Calendar = calendar;
                    //FormatInfo = culture.DateTimeFormat;
                    //FormatInfo.Calendar = calendar;

                    //retYear = produceTypeOfYear.ToString("gyy/MM/dd", culture);

                    //int Era = FormatInfo.Calendar.GetEra(produceTypeOfYear);
                    //string eraString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    //string eraName = string.Empty;
                    //string tempRetYear = string.Empty;
                    //tempRetYear = retYear.Substring(2, retYear.Length - 2);
                    //for (int eraCounter = 0; eraCounter < eraString.Length; eraCounter++)
                    //{
                    //    if (FormatInfo.GetEra(eraString[eraCounter].ToString()) == Era)
                    //    {
                    //        eraName = eraString[eraCounter].ToString();
                    //        break;
                    //    }
                    //}
                    //tempRetYear = eraName + tempRetYear;
                    //retYear = tempRetYear.Remove(tempRetYear.Length - 3);
                    //retYear = retYear.Replace('/', '.');

                    retYear = TDateTime.DateTimeToString("ggYY.MM", produceTypeOfYear);
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                }
            }
            return retYear;
        }

        /// <summary>
        /// 生産年式範囲設定処理
        /// </summary>
        /// <param name="stProduceTypeOfYear"></param>
        /// <param name="edProduceTypeOfYear"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 生産年式範囲設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingProduceTypeOfYearRange(string stProduceTypeOfYear, string edProduceTypeOfYear)
        {
            string retString = string.Empty;
            int maxLength = 7;

            stProduceTypeOfYear = stProduceTypeOfYear.PadRight(maxLength, ' ');
            edProduceTypeOfYear = edProduceTypeOfYear.PadRight(maxLength, ' ');
            if ((string.IsNullOrEmpty(stProduceTypeOfYear.Trim())) && (string.IsNullOrEmpty(edProduceTypeOfYear.Trim())))
            {
                this.uLabel_FirstEntryDateRange.Text = string.Empty;
            }
            else
            {
                this.uLabel_FirstEntryDateRange.Text = stProduceTypeOfYear + "-" + edProduceTypeOfYear;
            }
        }

        /// <summary>
        /// 車台番号範囲設定処理
        /// </summary>
        /// <param name="stProduceFrameNo"></param>
        /// <param name="edProduceFrameNo"></param>
        /// <remarks>
        /// <br>Note       : 車台番号範囲設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingProduceFrameNoRange(string stProduceFrameNo, string edProduceFrameNo)
        {
            string retString = string.Empty;
            int maxLength = 8;

            stProduceFrameNo = stProduceFrameNo.PadLeft(maxLength, ' ');
            edProduceFrameNo = edProduceFrameNo.PadLeft(maxLength, ' ');
            if ((string.IsNullOrEmpty(stProduceFrameNo.Trim())) && (string.IsNullOrEmpty(edProduceFrameNo.Trim())))
            {
                this.uLabel_ProduceFrameNoRange.Text = string.Empty;
            }
            else
            {
                this.uLabel_ProduceFrameNoRange.Text = stProduceFrameNo + "-" + edProduceFrameNo;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車輌検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時発生イベントです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // 得意先設定処理
            this.SettingCustomer(customerSearchRet);

        }

        /// <summary>
        /// 得意先設定処理
        /// </summary>
        /// <param name="seldata">得意先検索結果クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCustomer(CustomerSearchRet seldata)
        {
            string customerSnm = this.GetCustomerSnm(seldata.CustomerCode);

            if (!string.IsNullOrEmpty(customerSnm))
            {
                this.tNedit_CustomerCode.SetInt(seldata.CustomerCode);
                this.tEdit_CustomerName.Text = customerSnm;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "得意先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 車両情報テーブル行の型式指定番号および類別区分番号セット
        /// </summary>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別区分番号</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行の型式指定番号および類別区分番号セットです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCarInfoRowFromCategoryNoAndDesignationNo(int modelDesignationNo, int categoryNo)
        {
            if (this._extraInfo != null)
            {
                this._extraInfo.ModelDesignationNo = modelDesignationNo; // 型式指定番号
                this._extraInfo.CategoryNo = categoryNo; // 類別区分番号
            }
        }

        /// <summary>
        /// 車両情報テーブル行のエンジン型式セット
        /// </summary>
        /// <param name="engineModelNm">エンジン型式</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行のエンジン型式セットです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCarInfoRowFromEngineModelNm(string engineModelNm)
        {
            if (this._extraInfo != null)
            {
                this._extraInfo.EngineModelNm = engineModelNm;
            }
        }

        /// <summary>
        /// 車両情報テーブル行の型式セット
        /// </summary>
        /// <param name="fullModel">型式</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行の型式セットです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCarInfoRowFromFullModel(string fullModel)
        {
            if (this._extraInfo != null)
            {
                this._extraInfo.FullModel = fullModel;
            }
        }

        /// <summary>
        /// 車両情報テーブル行の車種情報セット(カーメーカー、車種コード、車種サブコード)
        /// </summary>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="makerFullName">メーカー全角名称</param>
        /// <param name="makerHalfName">メーカー半角名称</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <param name="modelFullName">車種全角名称</param>
        /// <param name="modelHalfName">車種半角名称</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行の車種情報セット(カーメーカー、車種コード、車種サブコード)です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCarInfoRowFromModelInfo(int makerCode, string makerFullName, string makerHalfName, int modelCode, int modelSubCode, string modelFullName, string modelHalfName)
        {
            if (this._extraInfo != null)
            {
                if ((modelCode == 0) && (modelSubCode == 0))
                {
                    this._extraInfo.ModelFullName = makerFullName;
                    this._extraInfo.ModelHalfName = makerHalfName;
                }
                else
                {
                    this._extraInfo.ModelFullName = modelFullName;
                    this._extraInfo.ModelHalfName = modelHalfName;
                }
                this._extraInfo.MakerCode = makerCode;
                this._extraInfo.MakerFullName = makerFullName;
                this._extraInfo.MakerHalfName = makerHalfName;
                this._extraInfo.ModelCode = modelCode;
                this._extraInfo.ModelSubCode = modelSubCode;
            }
        }

        /// <summary>
        /// 車両情報テーブル行の年式セット
        /// </summary>
        /// <param name="firstEntryDate">年式</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行の年式セットです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingCarInfoRowFromFirstEntryDate(int firstEntryDate)
        {
            if (this._extraInfo != null)
            {
                if (firstEntryDate != 0)
                {
                    this._extraInfo.ProduceTypeOfYearInput = firstEntryDate / 100;
                }
                else
                {
                    this._extraInfo.ProduceTypeOfYearInput = 0;
                }
            }
        }

        /// <summary>
        /// 車両情報テーブル行の車台番号セット
        /// </summary>
        /// <param name="frameNo">車台番号</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行の車台番号セットです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SettingCarInfoRowFromFrameNo(string frameNo)
        {
            if (this._extraInfo != null)
            {
                this._extraInfo.FrameNo = frameNo;
                this._extraInfo.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
            }
        }

        /// <summary>
        /// 車両情報テーブル行の車種情報セット(車種マスタ)
        /// </summary>
        /// <param name="modelNameU">車種マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブル行の車種情報セット(車種マスタ)です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SettingCarInfoRowFromModelInfo(ModelNameU modelNameU)
        {
            if (this._extraInfo != null)
            {
                // ADD 2014/08/01 譚洪 Redmine#43125 --- >>>
                // 初期データ取得スレッドが終了するまで待機
                while (this._initialReadThread.ThreadState == ThreadState.Running)
                {
                    Thread.Sleep(100);
                }
                // ADD 2014/08/01 譚洪 Redmine#43125 --- <<<

                this._extraInfo.MakerCode = modelNameU.MakerCode;
                string makerFullName = this._carMngInputAcs.GetName_FromMaker(modelNameU.MakerCode);
                this._extraInfo.MakerFullName = makerFullName;
                string makerHalfName = this._carMngInputAcs.GetKanaName_FromMaker(modelNameU.MakerCode);
                this._extraInfo.MakerHalfName = makerHalfName;
                this._extraInfo.ModelCode = modelNameU.ModelCode;
                this._extraInfo.ModelSubCode = modelNameU.ModelSubCode;
                if ((modelNameU.ModelCode == 0) && (modelNameU.ModelSubCode == 0))
                {
                    this._extraInfo.ModelFullName = makerFullName;
                    this._extraInfo.ModelHalfName = makerHalfName;
                }
                else
                {
                    this._extraInfo.ModelFullName = modelNameU.ModelFullName;
                    this._extraInfo.ModelHalfName = modelNameU.ModelHalfName;
                }
            }
        }

        /// <summary>
        /// 車両情報テーブルのクリア
        /// </summary>
        /// <param name="isOnlyClearCarInfo">クリアFlag</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブルのクリアです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note: 2013/03/22 FSI高橋 文彰</br>
        /// <br>管理番号   : 10900269-00</br>
        /// <br>             SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// </remarks>
        private void ClearExtraInfo(bool isOnlyClearCarInfo)
        {
            if (this._extraInfo == null) return;

            this._extraInfo.FullModel = string.Empty;                // 型式（フル型）
            this._extraInfo.ModelDesignationNo = 0;                  // 型式指定番号
            this._extraInfo.CategoryNo = 0;                          // 類別番号
            this._extraInfo.FrameModel = string.Empty;               // 車台型式
            this._extraInfo.FrameNo = string.Empty;                  // 車台番号
            this._extraInfo.SearchFrameNo = 0;                       // 車台番号（検索用）
            this._extraInfo.StProduceFrameNo = 0;                    // 生産車台番号開始
            this._extraInfo.EdProduceFrameNo = 0;                    // 生産車台番号終了
            this._extraInfo.ModelGradeNm = string.Empty;             // 型式グレード名称
            this._extraInfo.EngineModelNm = string.Empty;            // エンジン型式名称
            this._extraInfo.EngineDisplaceNm = string.Empty;         // 排気量名称
            this._extraInfo.EDivNm = string.Empty;                   // E区分名称
            this._extraInfo.TransmissionNm = string.Empty;           // ミッション名称
            this._extraInfo.ShiftNm = string.Empty;                  // シフト名称
            this._extraInfo.WheelDriveMethodNm = string.Empty;       // 駆動方式名称
            this._extraInfo.AddiCarSpec1 = string.Empty;             // 追加諸元1
            this._extraInfo.AddiCarSpec2 = string.Empty;             // 追加諸元2
            this._extraInfo.AddiCarSpec3 = string.Empty;             // 追加諸元3
            this._extraInfo.AddiCarSpec4 = string.Empty;             // 追加諸元4
            this._extraInfo.AddiCarSpec5 = string.Empty;             // 追加諸元5
            this._extraInfo.AddiCarSpec6 = string.Empty;             // 追加諸元6
            this._extraInfo.RelevanceModel = string.Empty;           // 関連型式
            this._extraInfo.SubCarNmCd = 0;                          // サブ車名コード
            this._extraInfo.ModelGradeSname = string.Empty;          // 型式グレード略称
            this._extraInfo.BlockIllustrationCd = 0;                 // ブロックイラストコード
            this._extraInfo.ThreeDIllustNo = 0;                      // 3DイラストNo
            this._extraInfo.PartsDataOfferFlag = 0;                  // 部品データ提供フラグ
            this._extraInfo.ProduceTypeOfYearInput = 0;              // 年式
            this._extraInfo.ColorCode = string.Empty;                // カラーコード
            this._extraInfo.ColorName1 = string.Empty;               // カラー名称
            this._extraInfo.TrimCode = string.Empty;                 // トリムコード
            this._extraInfo.TrimName = string.Empty;                 // トリム名称

            if (isOnlyClearCarInfo == true)
            {
                this._extraInfo.StProduceTypeOfYear = DateTime.MinValue; // 開始生産年式
                this._extraInfo.EdProduceTypeOfYear = DateTime.MinValue; // 終了生産年式
                this._extraInfo.SystematicCode = 0;                      // 系統コード
                this._extraInfo.SystematicName = string.Empty;           // 系統名称
                this._extraInfo.BodyNameCode = 0;                        // ボディー名コード
                this._extraInfo.BodyName = string.Empty;                 // ボディー名称
                this._extraInfo.ExhaustGasSign = string.Empty;           // 排ガス記号
                this._extraInfo.SeriesModel = string.Empty;              // シリーズ型式
                this._extraInfo.CategorySignModel = string.Empty;        // 型式（類別記号）
                this._extraInfo.DoorCount = 0;                           // ドア数
                this._extraInfo.FullModelFixedNoAry = new Int32[0];      // フル型式固定番号配列
                this._extraInfo.CategoryObjAry = new byte[0];            // 装備オブジェクト配列
                // ADD 2013/03/22 -------------------->>>>>
                this._extraInfo.DomesticForeignCode = 0;                 // 国産/外車区分
                // ADD 2013/03/22 --------------------<<<<<
            }
            else
            {
                this._extraInfo.CarRelationGuid = Guid.Empty;            // 車両情報共通キー
                this._extraInfo.CustomerCode = 0;                        // 得意先コード
                this._extraInfo.CarMngNo = 0;                            // 車両管理番号
                this._extraInfo.CarMngCode = string.Empty;               // 車輌管理コード
                this._extraInfo.NumberPlate1Code = 0;                    // 陸運事務所番号
                this._extraInfo.NumberPlate1Name = string.Empty;         // 陸運事務局名称
                this._extraInfo.NumberPlate2 = string.Empty;             // 車両登録番号（種別）
                this._extraInfo.NumberPlate3 = string.Empty;             // 車両登録番号（カナ）
                this._extraInfo.NumberPlate4 = 0;                        // 車両登録番号（プレート番号）
                this._extraInfo.EntryDate = DateTime.MinValue;           // 登録年月日
                //this._extraInfo.FirstEntryDate = DateTime.MinValue;      // 初年度
                this._extraInfo.FirstEntryDate = 0;      // 初年度
                this._extraInfo.MakerCode = 0;                           // メーカーコード
                this._extraInfo.MakerFullName = string.Empty;            // メーカー全角名称
                this._extraInfo.MakerHalfName = string.Empty;            // メーカー半角名称
                this._extraInfo.ModelCode = 0;                           // 車種コード
                this._extraInfo.ModelSubCode = 0;                        // 車種サブコード
                this._extraInfo.ModelFullName = string.Empty;            // 車種全角名称
                this._extraInfo.ModelHalfName = string.Empty;            // 車種半角名称
                this._extraInfo.SystematicCode = 0;                      // 系統コード
                this._extraInfo.SystematicName = string.Empty;           // 系統名称
                this._extraInfo.ProduceTypeOfYearCd = 0;                 // 生産年式コード
                this._extraInfo.ProduceTypeOfYearNm = string.Empty;      // 生産年式名称
                this._extraInfo.StProduceTypeOfYear = DateTime.MinValue; // 開始生産年式
                this._extraInfo.EdProduceTypeOfYear = DateTime.MinValue; // 終了生産年式
                this._extraInfo.DoorCount = 0;                           // ドア数
                this._extraInfo.BodyNameCode = 0;                        // ボディー名コード
                this._extraInfo.BodyName = string.Empty;                 // ボディー名称
                this._extraInfo.ExhaustGasSign = string.Empty;           // 排ガス記号
                this._extraInfo.SeriesModel = string.Empty;              // シリーズ型式
                this._extraInfo.CategorySignModel = string.Empty;        // 型式（類別記号）
                this._extraInfo.InspectMaturityDate = DateTime.MinValue; // 車検満期日
                this._extraInfo.LTimeCiMatDate = DateTime.MinValue;      // 前回車検満期日
                this._extraInfo.CarInspectYear = 0;                      // 車検期間
                this._extraInfo.Mileage = 0;                             // 車両走行距離
                this._extraInfo.CarNo = string.Empty;                    // 号車
                this._extraInfo.FullModelFixedNoAry = new Int32[0];      // フル型式固定番号配列
                this._extraInfo.CategoryObjAry = new byte[0];            // 装備オブジェクト配列
                this._extraInfo.CarAddInfo1 = string.Empty;              // 追加情報１
                this._extraInfo.CarAddInfo2 = string.Empty;              // 追加情報２
                this._extraInfo.CarNote = string.Empty;                  // 車輌備考
            }
        }

        /// <summary>
        /// 車両検索処理
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車両検索処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private int CarSearch(CarSearchCondition condition)
        {
            //------------------------------------------------------
            // 初期処理
            //------------------------------------------------------
            int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // --- ADD 2009/10/10 ----->>>>>
            this._beforeCarSearchBuffer.ProduceFrameNo = tEdit_ProduceFrameNo.Text.Trim();
            this._beforeCarSearchBuffer.FirstEntryDate = tDateEdit_FirstEntryDate.GetLongDate();
            // --- ADD 2009/10/10 -----<<<<<

            //------------------------------------------------------
            // 西暦／和歴区分（年式）
            //------------------------------------------------------
            condition.EraNameDispCd1 = this._carMngInputAcs.GetAllDefSet().EraNameDispCd1;

            //------------------------------------------------------
            // カーメーカーコード、車種コード、車種呼称コード設定
            //------------------------------------------------------
            if (condition.Type != CarSearchType.csCategory)
            {
                int makerCd, modelCd, modelSubCd;
                if (int.TryParse(this.tNedit_MakerCode.Text, out makerCd))
                {
                    condition.MakerCode = makerCd;
                }
                if (int.TryParse(this.tNedit_ModelCode.Text, out modelCd))
                {
                    condition.ModelCode = modelCd;
                }
                if (int.TryParse(this.tNedit_ModelSubCode.Text, out modelSubCd))
                {
                    condition.ModelSubCode = modelSubCd;
                }
            }
            //------------------------------------------------------
            // 各種検索処理
            //------------------------------------------------------
            //  CarSearchCondition の検索タイプにより指定
            //------------------------------------------------------
            CarSearchResultReport ret;
            PMKEN01010E dat = new PMKEN01010E();
            ret = this._carMngInputAcs.SearchCar(condition, ref dat);
            if (ret == CarSearchResultReport.retFailed)
            {
                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else if (ret == CarSearchResultReport.retError)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "検索中にエラーが発生しました。",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            this._carInfo = dat;
            if (ret == CarSearchResultReport.retMultipleCarKind)
            {
                //------------------------------------------------------
                // 車種選択画面起動
                //------------------------------------------------------
                if (SelectionCarKind.ShowDialog(dat.CarKindInfo, condition) == DialogResult.OK)
                {
                    ret = this._carMngInputAcs.SearchCar(condition, ref dat);
                }
                else
                {
                    return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }
            if (ret == CarSearchResultReport.retMultipleCarModel)
            {
                //------------------------------------------------------
                // 型式選択画面起動
                //------------------------------------------------------
                if (SelectionCarModel.ShowDialog(dat) == DialogResult.OK)
                {
                    ret = this._carMngInputAcs.SearchCar(condition, ref dat);
                }
                else
                {
                    return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }

            if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
            {
                //------------------------------------------------------
                // 検索結果キャッシュ
                //------------------------------------------------------
                this._carMngInputAcs.CacheCarInfo(ref this._extraInfo, dat);

                //------------------------------------------------------
                // 車両情報画面表示処理
                //------------------------------------------------------
                this.SetDisplayCarInfo(this._extraInfo, false);

                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return retStatus;
        }

        /// <summary>
        /// 車両検索切替処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車両検索切替処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ChangeSearchCarMode()
        {
            if (this._searchCarMode == CarMngInputAcs.SearchCarMode.FullModelSearch)
            {
                this._searchCarMode = CarMngInputAcs.SearchCarMode.ModelPlateSearch;
                this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_ModelPlate;
            }
            else if (this._searchCarMode == CarMngInputAcs.SearchCarMode.ModelPlateSearch)
            {
                this._searchCarMode = CarMngInputAcs.SearchCarMode.FullModelSearch;
                this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_FullModel;
            }
        }

        /// <summary>
        /// 車輌検索あり／なしの切替処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌検索あり／なしの切替処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ChangeSearchCar()
        {
            if (this._isSearchCar == true)
            {
                // 車輌検索種別
                this.uLabel_SearchTypeTitle.Text = "型式任意";
                // 車種名称
                this.tEdit_ModelFullName.Enabled = true;
                // 型式ボタン
                // this.uButton_ChangeSearchCarMode.Enabled = true;
                //型式任意が表示され「車輌検索なし」は切替え不可
                this.uButton_ChangeSearchCarMode.Enabled = false;  // ADD 2009/10/10
                this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_FullModel;  // ADD 2009/10/10
                this._isSearchCar = false;
                // --- ADD 2009/10/22 ---->>>>>
                // 年式範囲クリア
                this._extraInfo.StProduceTypeOfYear = DateTime.MinValue;
                this._extraInfo.EdProduceTypeOfYear = DateTime.MinValue;
                // 車台番号範囲クリア
                this._extraInfo.StProduceFrameNo = 0;
                this._extraInfo.EdProduceFrameNo = 0;
                // フル型式固定番号配列クリア
                this._extraInfo.FullModelFixedNoAry = new Int32[0];

                // グレードなど諸元情報クリア
                CarMngInputDataSet.CarSpecDataTable carSpecDataTb = new CarMngInputDataSet.CarSpecDataTable();
                CarMngInputDataSet.CarSpecRow carSpecRow = carSpecDataTb.NewCarSpecRow();
                carSpecDataTb.AddCarSpecRow(carSpecRow);
                this.ultraGrid_CarSpec.DataSource = carSpecDataTb;
                this._extraInfo.AddiCarSpec1 = string.Empty;
                this._extraInfo.AddiCarSpec2 = string.Empty;
                this._extraInfo.AddiCarSpec3 = string.Empty;
                this._extraInfo.AddiCarSpec4 = string.Empty;
                this._extraInfo.AddiCarSpec5 = string.Empty;
                this._extraInfo.AddiCarSpec6 = string.Empty;
                this._extraInfo.BodyName = string.Empty;
                this._extraInfo.DoorCount = 0;
                this._extraInfo.EDivNm =string.Empty;
                this._extraInfo.EngineDisplaceNm = string.Empty;
                // --- UPD 2013/05/02 Y.Wakita ---------->>>>>
                //this._extraInfo.EngineModel = string.Empty;
                this._extraInfo.EngineModelNm = string.Empty;
                // --- UPD 2013/05/02 Y.Wakita ----------<<<<<
                this._extraInfo.ModelGradeNm = string.Empty;
                this._extraInfo.ShiftNm = string.Empty;
                this._extraInfo.TransmissionNm = string.Empty;
                this._extraInfo.WheelDriveMethodNm = string.Empty;
                if (this._carOtherInfoInput.ColorCdInfoDataTable != null)
                {
                    this._carOtherInfoInput.ColorCdInfoDataTable.Clear();
                }
                if (this._carOtherInfoInput.TrimCdInfoDataTable != null)
                {
                    this._carOtherInfoInput.TrimCdInfoDataTable.Clear();
                }
                if (this._carOtherInfoInput.CEqpDefDspInfoDataTable != null)
                {
                    this._carOtherInfoInput.CEqpDefDspInfoDataTable.Clear();
                }
                // --- ADD 2009/10/22 ----<<<<<
                this._isSearchCar_FullModel = true;  // ADD 2013/05/02 Y.Wakita
            }
            else
            {
                // 車輌検索種別
                this.uLabel_SearchTypeTitle.Text = "型式必須";
                // 車種名称
                this.tEdit_ModelFullName.Enabled = false;
                // 型式ボタン
                //this.uButton_ChangeSearchCarMode.Enabled = false;
                //型式必須が表示され「車輌検索あり」は切替え可能
                this.uButton_ChangeSearchCarMode.Enabled = true;  // ADD 2009/10/10

                this._searchCarMode = CarMngInputAcs.SearchCarMode.FullModelSearch;
                this.uButton_ChangeSearchCarMode.Text = ctSearchCarMode_FullModel;

                this._isSearchCar = true;

                // --- ADD 2013/05/02 Y.Wakita ---------->>>>>
                // 車輌情報のデータソースの設定
                this.ultraGrid_CarSpec.DataSource = this._carSpecDataTable;

                if (this.tNedit_CategoryNo.GetInt() != 0)
                    this.tNedit_CategoryNo.Focus();
                else if (this.tNedit_ModelDesignationNo.GetInt() != 0)
                    this.tNedit_ModelDesignationNo.Focus();
                else if (this.tEdit_FullModel.Text.Trim() != "")
                    this.tEdit_FullModel.Focus();
                else if (this.tEdit_EngineModelNm.Text.Trim() != "")
                    this.tEdit_EngineModelNm.Focus();
                else
                    this._isSearchCar_FullModel = false;
                // --- ADD 2013/05/02 Y.Wakita ----------<<<<<
            }

            // カラー・トリム・装備ガイドをクリアする 
            this.tEdit_ColorNo.Text = string.Empty;
            this.tEdit_TrimNo.Text = string.Empty;

            this._carMngInputAcs.SelectColorInfo(this._extraInfo.CarRelationGuid, this.tEdit_ColorNo.Text.Trim(), this._extraInfo);
            this._carMngInputAcs.SelectTrimInfo(this._extraInfo.CarRelationGuid, this.tEdit_TrimNo.Text.Trim(), this._extraInfo);
            this._carMngInputAcs.SelectEquipInfo(this._extraInfo.CarRelationGuid, new byte[0]);

            // 画面表示処理（車輌情報）
            this.SetDisplayCarInfo(this._extraInfo, false);
        }

        /// <summary>
        /// 生産年式範囲チェック
        /// </summary>
        /// <param name="firstEntryDate">年式</param>
        /// <returns>true:範囲内 false:範囲外</returns>
        /// <remarks>
        /// <br>Note       : 生産年式範囲チェックです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool CheckProduceTypeOfYearRange(int firstEntryDate)
        {
            bool ret = true;

            if (firstEntryDate != 0)
            {
                firstEntryDate = firstEntryDate / 100 * 100;
                int fyy = firstEntryDate / 10000;
                int fmm = firstEntryDate / 100 % 100;

                int styy = this._extraInfo.StProduceTypeOfYear.Year;
                int stmm = this._extraInfo.StProduceTypeOfYear.Month;
                int edyy = this._extraInfo.EdProduceTypeOfYear.Year;
                int edmm = this._extraInfo.EdProduceTypeOfYear.Month;
                int st = 0;
                int ed = 0;
                if (fmm != 0)
                {
                    // 年月でチェック
                    st = styy * 10000 + stmm * 100;
                    ed = edyy * 10000 + edmm * 100;
                }
                else
                {
                    // 年のみでチェック
                    st = styy * 10000;
                    ed = edyy * 10000;
                }

                if (this._extraInfo.StProduceTypeOfYear != DateTime.MinValue) if (firstEntryDate < st) ret = false;

                if (this._extraInfo.EdProduceTypeOfYear != DateTime.MinValue) if (firstEntryDate > ed) ret = false;
            }
            return ret;
        }

        /// <summary>
        /// 車台番号範囲チェック
        /// </summary>
        /// <param name="inputFrameNo">車台番号入力文字列</param>
        /// <param name="searchFrameNo">車台番号</param>
        /// <returns>True:範囲内、False:範囲外</returns>
        /// <remarks>
        /// <br>Note       : 車台番号範囲チェックです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool CheckProduceFrameNo(string inputFrameNo, int searchFrameNo)
        {
            bool ret = true;

            if (this._extraInfo != null)
            {
                if (searchFrameNo != 0 || !string.IsNullOrEmpty(inputFrameNo))
                {
                    if ((this._extraInfo.StProduceFrameNo != 0 && this._extraInfo.StProduceFrameNo > searchFrameNo) ||
                        (this._extraInfo.EdProduceFrameNo != 0 && this._extraInfo.EdProduceFrameNo < searchFrameNo)) ret = false;
                }
            }

            return ret;
        }

        /// <summary>
        /// 対象年式取得処理(車台番号より取得)
        /// </summary>
        /// <param name="frameNo">車台番号</param>
        /// <returns>年式(int)</returns>
        /// <remarks>
        /// <br>Note       : 対象年式取得処理(車台番号より取得)です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private int GetProduceTypeOfYear(int frameNo)
        {
            int retDateTime = 0;
            if (this._carInfo != null)
            {
                string filter = string.Format("{0}<={1} AND {2}>={3}",
                    this._carInfo.PrdTypYearInfo.StProduceFrameNoColumn.ColumnName, frameNo,
                    this._carInfo.PrdTypYearInfo.EdProduceFrameNoColumn.ColumnName, frameNo);
                PMKEN01010E.PrdTypYearInfoRow[] row = (PMKEN01010E.PrdTypYearInfoRow[])this._carInfo.PrdTypYearInfo.Select(filter);
                if (row.Length > 0) retDateTime = row[0].ProduceTypeOfYear;
            }
            return retDateTime * 100;
        }

        /// <summary>
        /// マスタデータの読込
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタデータの読込です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void LoadMasterData()
        {
            // 得意先検索マスタ
            this._listAcs.LoadCustomerSearchRet();
            // 陸運事務所番号読込処理
            this._listAcs.LoadNumberPlate1Code();

            string msg = "最新情報を取得しました。";
            // メッセージを表示
            TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                msg,
                0,
                MessageBoxButtons.OK);
        }

        /// <summary>
        /// 得意先略称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先略称</returns>
        /// <remarks>
        /// <br>Note       : 得意先略称取得処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string GetCustomerSnm(int customerCode)
        {
            string customerSnm = "";

            try
            {
                if (this._listAcs.CustomerSearchRetDic.ContainsKey(customerCode))
                {
                    customerSnm = this._listAcs.CustomerSearchRetDic[customerCode].Snm.Trim();
                }
            }
            catch
            {
                customerSnm = "";
            }

            return customerSnm;
        }

        /// <summary>
        /// 陸運事務局名称取得処理
        /// </summary>
        /// <param name="code">陸運事務局コード</param>
        /// <returns>陸運事務局名称</returns>
        /// <remarks>
        /// <br>Note       : 陸運事務局名称取得処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string GetNumberPlate1Name(int code)
        {
            string numberPlate1Nm = "";

            try
            {
                if (this._listAcs.NumberPlate1CodeDic.ContainsKey(code))
                {
                    numberPlate1Nm = this._listAcs.NumberPlate1CodeDic[code].GuideName;
                }
            }
            catch
            {
                numberPlate1Nm = "";
            }

            return numberPlate1Nm;
        }

        /// <summary>
        /// データの保存処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : データの保存処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private int SaveData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;
            Control errComponent = null;
            bool isMasterExist = false;
            // 登録前のチェック処理
            if (!this.CheckData(ref errComponent, out errMsg, out isMasterExist))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                errComponent.Focus();

                // --- ADD 2013/03/22 ---------->>>>>
                if (errComponent == this.tEdit_ProduceFrameNo &&
                    this._extraInfo.DomesticForeignCode == 2 &&
                    this.tNedit_MakerCode.GetInt() == 80)
                {
                    // ハンドル位置チェックNGの場合は全選択状態に
                    this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
                    // 画面Closeしないようにフラグを立てておく
                    this._closeflg = false;
                }
                // --- ADD 2013/03/22 ----------<<<<<

                // マスタに存在しない場合、元に値を戻る
                if (isMasterExist == false)
                {
                    switch (errComponent.Name)
                    {
                        case "tNedit_CustomerCode":
                            // 得意先コード
                            this.tNedit_CustomerCode.SetInt(this._extraInfo.CustomerCode);
                            break;
                        case "tNedit_MakerCode":
                            // 車種メーカーコード
                            this.tNedit_MakerCode.SetInt(this._extraInfo.MakerCode);
                            break;
                        case "tNedit_ModelCode":
                            // 車種コード
                            this.tNedit_ModelCode.SetInt(this._extraInfo.ModelCode);
                            break;
                        case "tNedit_ModelSubCode":
                            // 車種呼称コード
                            this.tNedit_ModelSubCode.SetInt(this._extraInfo.ModelSubCode);
                            break;
                        case "tEdit_ColorNo":
                            // カラー
                            this.tEdit_ColorNo.Text = this._extraInfo.ColorCode;
                            break;
                        case "tEdit_TrimNo":
                            // トリム
                            this.tEdit_TrimNo.Text = this._extraInfo.TrimCode;
                            break;
                        case "tNedit_NumberPlate1Code":
                            // 陸運事務所コード
                            this.tNedit_NumberPlate1Code.SetInt(this._extraInfo.NumberPlate1Code);
                            break;
                    }
                }
                return status;
            }

            // 新規モードの場合、車輌管理番号無条件で採番する
            if (this._mode == INSERT_MODE)
            {
                this._extraInfo.CarMngNo = 0;
            }

            // 登録更新処理
            status = this._carMngInputAcs.WriteDB(ref this._extraInfo, out errMsg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 登録完了
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        if (this._mode == INSERT_MODE)
                        {
                            // 一括入力画面のグリッドへ追加する
                            this.AddRowToList();
                        }
                        else
                        {
                            // 一括入力画面のグリッドへ変更する
                            this.UpdRowToList(false);
                        }
                        this.RefreshParent(true);
                        this.Close();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        this.ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        // 保存失敗
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            "保存処理に失敗しました。",
                            status,
                            MessageBoxButtons.OK);
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 登録前のチェック処理
        /// </summary>
        /// <param name="errComponent">エラーコントロール</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="isMasterExist">マスタに存在かどうか</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 登録前のチェック処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool CheckData(ref Control errComponent, out string errMsg, out bool isMasterExist)
        {
            errComponent = null;
            errMsg = string.Empty;
            isMasterExist = true;

            // 得意先
            if (this.tNedit_CustomerCode.GetInt() == 0)
            {
                errComponent = this.tNedit_CustomerCode;
                errMsg = "得意先を入力して下さい。";
                return false;
            }

            // 得意先存在チェック
            if (this.tNedit_CustomerCode.GetInt() != this._extraInfo.CustomerCode)
            {
                errComponent = this.tNedit_CustomerCode;
                errMsg = "得意先が存在しません。";
                isMasterExist = false;
                return false;
            }

            // 管理番号
            if (string.IsNullOrEmpty(this.tEdit_CarMngCode.Text.Trim()))
            {
                errComponent = this.tEdit_CarMngCode;
                errMsg = "管理番号を入力して下さい。";
                return false;
            }

            // 車種メーカーコード
            if (this.tNedit_MakerCode.GetInt() != this._extraInfo.MakerCode)
            {
                errComponent = this.tNedit_MakerCode;
                errMsg = "入力したメーカーコードは存在しません。";
                isMasterExist = false;
                return false;
            }

            // 車種コード
            if (this.tNedit_ModelCode.GetInt() != this._extraInfo.ModelCode)
            {
                errComponent = this.tNedit_ModelCode;
                errMsg = "入力した車種コードは存在しません。";
                isMasterExist = false;
                return false;
            }

            // 車種呼称コード
            if (this.tNedit_ModelSubCode.GetInt() != this._extraInfo.ModelSubCode)
            {
                errComponent = this.tNedit_ModelSubCode;
                errMsg = "入力した車種呼称コードは存在しません。";
                isMasterExist = false;
                return false;
            }

            // 年式の無効日付チェック
            TDateEdit tempFirstEntryDate = (this.tDateEdit_FirstEntryDate as TDateEdit);
            DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDateForFirstEntryDate(ref tempFirstEntryDate, true);
            if (res == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                errComponent = this.tDateEdit_FirstEntryDate;
                errMsg = "日付が不正です。";
                return false;
            }

            // 年式の範囲チェック
            if (!this.CheckProduceTypeOfYearRange(tDateEdit_FirstEntryDate.GetLongDate()))
            {
                errComponent = this.tDateEdit_FirstEntryDate;
                errMsg = "生産年式が設定範囲外です。";
                return false;
            }

            // 車台番号の範囲チェック
            string newValue = this.tEdit_ProduceFrameNo.Text;
            int newIntValue = TStrConv.StrToIntDef(newValue.Trim(), 0);
            if (!this.CheckProduceFrameNo(newValue, newIntValue))
            {
                errComponent = this.tEdit_ProduceFrameNo;
                errMsg = "車台番号が設定範囲外です。";
                return false;
            }

            // カラー
            if (!this.tEdit_ColorNo.Text.Equals(this._extraInfo.ColorCode))
            {
                errComponent = this.tEdit_ColorNo;
                errMsg = "カラーコードが設定範囲外です。";
                isMasterExist = false;
                return false;
            }

            // トリム
            if (!this.tEdit_TrimNo.Text.Equals(this._extraInfo.TrimCode))
            {
                errComponent = this.tEdit_TrimNo;
                errMsg = "トリムコードが設定範囲外です。";
                isMasterExist = false;
                return false;
            }

            // 陸運事務所コード
            if (this.tNedit_NumberPlate1Code.GetInt() != this._extraInfo.NumberPlate1Code)
            {
                errComponent = this.tNedit_NumberPlate1Code;
                errMsg = "陸運事務所コードが存在しません。";
                isMasterExist = false;
                return false;
            }

            // 前回車検日の大小チェック(前回車検日≧登録年月日か)
            DateGetAcs.CheckDateRangeResult cdrResult;
            // 登録年月日
            TDateEdit entryDate = this.tDateEdit_EntryDate;
            // 前回車検日
            TDateEdit lTimeCiMatDate = this.tDateEdit_LTimeCiMatDate;
            // ----ADD 2009/10/10 ------>>>>>
            // 前回車検日入力ありの場合、期間の未入力チェックを行う
            if (this.tDateEdit_LTimeCiMatDate.GetDateTime() != DateTime.MinValue && this.tNedit_CarInspectYear.GetInt() == 0)
            {
                errComponent = this.tNedit_CarInspectYear;
                errMsg = "車検期間を入力して下さい。";
                isMasterExist = false;
                return false;
            }
            // ----ADD 2009/10/10 ------<<<<<
            cdrResult = this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 1, ref entryDate, ref lTimeCiMatDate, true, false, false);
            // ---UPD 2009/10/10 ----->>>>>
            switch (cdrResult)
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                    errComponent = this.tDateEdit_EntryDate;
                    errMsg = "日付が不正です。";
                    return false;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                    errComponent = this.tDateEdit_LTimeCiMatDate;
                    errMsg = "日付が不正です。";
                    return false;
                //case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                //    errComponent = this.tDateEdit_LTimeCiMatDate;
                //    errMsg = "登録年月日以降の日付を入力して下さい。";
                //    return false;
            }
            if (this.tDateEdit_EntryDate.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_EntryDate.GetDateTime() > this.tDateEdit_LTimeCiMatDate.GetDateTime())
                {
                    errComponent = this.tDateEdit_LTimeCiMatDate;
                    errMsg = "登録年月日以降の日付を入力して下さい。";
                    return false;
                }
            }

            // 次回車検日の大小チェック(次回車検日≧登録年月日か)
            TDateEdit inspectMaturityDate = this.tDateEdit_InspectMaturityDate;
            cdrResult = this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 1, ref entryDate, ref inspectMaturityDate, true, false, false);
            switch (cdrResult)
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                    errComponent = this.tDateEdit_EntryDate;
                    errMsg = "日付が不正です。";
                    return false;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                    errComponent = this.tDateEdit_InspectMaturityDate;
                    errMsg = "日付が不正です。";
                    return false;
                //case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                //    errComponent = this.tDateEdit_InspectMaturityDate;
                //    errMsg = "登録年月日以降の日付を入力して下さい。";
                //    return false;
            }
            if (this.tDateEdit_EntryDate.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_EntryDate.GetDateTime() > this.tDateEdit_InspectMaturityDate.GetDateTime())
                {
                    errComponent = this.tDateEdit_InspectMaturityDate;
                    errMsg = "登録年月日以降の日付を入力して下さい。";
                    return false;
                }
            }

            // 次回車検日の大小チェック(次回車検日≧前回車検日か)
            cdrResult = this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 1, ref lTimeCiMatDate, ref inspectMaturityDate, true, false, false);
            switch (cdrResult)
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                    errComponent = this.tDateEdit_LTimeCiMatDate;
                    errMsg = "日付が不正です。";
                    return false;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                    errComponent = this.tDateEdit_InspectMaturityDate;
                    errMsg = "日付が不正です。";
                    return false;
                //case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                //    errComponent = this.tDateEdit_InspectMaturityDate;
                //    errMsg = "前回車検日以降の日付を入力して下さい。";
                //    return false;
            }
            if (this.tDateEdit_LTimeCiMatDate.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_LTimeCiMatDate.GetDateTime() > this.tDateEdit_InspectMaturityDate.GetDateTime())
                {
                    errComponent = this.tDateEdit_InspectMaturityDate;
                    errMsg = "前回車検日以降の日付を入力して下さい。";
                    return false;
                }
            }
            // ---UPD 2009/10/10 -----<<<<<

            // --- ADD 2013/03/22 ---------->>>>>
            // ハンドル位置情報チェック
            // VINコード・車台番号が入力済・型式入力済・メーカコードがBENZ・国産/外車区分が「外車」
            // の場合にハンドル位置チェック
            if (!string.IsNullOrEmpty(this.tEdit_ProduceFrameNo.Text) &&
                !string.IsNullOrEmpty(this._extraInfo.FullModel) &&
                this._extraInfo.DomesticForeignCode == 2 &&
                this.tNedit_MakerCode.GetInt() == 80 &&
                !this._carMngInputAcs.CompareHandlePosition(this._extraInfo.FrameNo))
            {
                errComponent = this.tEdit_ProduceFrameNo;
                errMsg = "ハンドル位置が異なります。";
                return false;
            }
            // --- ADD 2013/03/22 ----------<<<<<

            return true;
        }

        /// <summary>
        /// 排他処理メッセージ設定
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他処理メッセージ設定です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
            }

            TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                errMsg,
                status,
                MessageBoxButtons.OK);
        }

        /// <summary>
        /// 車両管理ワークオブジェクトを車両情報行オブジェクトから取得
        /// </summary>
        /// <param name="extroInfo">車両情報行オブジェクト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 車両管理ワークオブジェクトを車両情報行オブジェクトから取得です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>update Note  : PM1015B　車輌管理マスタの自由検索型式固定番号配列もコピーするように修正</br>
        /// <br>             　施ヘイ中</br>
        /// <br>Date       　: 2010.12.22</br>
        /// </remarks>
        private CarMngInputDataSet.CarInfoRow CopyExtraInfoToCarInfoRow(CarMangInputExtraInfo extroInfo)
        {
            CarMngInputDataSet.CarInfoDataTable dt = new CarMngInputDataSet.CarInfoDataTable();
            CarMngInputDataSet.CarInfoRow carInfoRow = dt.NewCarInfoRow();
            carInfoRow.FileHeaderGuid = extroInfo.FileHeaderGuid;                       // GUID
            carInfoRow.CreateDateTime = extroInfo.CreateDateTime;                       // 作成日時
            carInfoRow.UpdateDateTime = extroInfo.UpdateDateTime;                       // 更新日付
            carInfoRow.CustomerCode = extroInfo.CustomerCode.ToString();                // 得意先コード
            carInfoRow.CarMngNo = extroInfo.CarMngNo.ToString();                        // 車両管理番号
            carInfoRow.CarMngCode = extroInfo.CarMngCode;                               // 車輌管理コード
            carInfoRow.NumberPlate1Code = extroInfo.NumberPlate1Code.ToString();        // 陸運事務所番号
            carInfoRow.NumberPlate1Name = extroInfo.NumberPlate1Name;                   // 陸運事務局名称
            carInfoRow.NumberPlate2 = extroInfo.NumberPlate2;                           // 車両登録番号（種別）
            carInfoRow.NumberPlate3 = extroInfo.NumberPlate3;                           // 車両登録番号（カナ）
            // -----ADD 2009/10/10 ----->>>>>
            if (extroInfo.NumberPlate4 == 0)
            {
                carInfoRow.NumberPlate4 = string.Empty;
            }
            else
            {
                carInfoRow.NumberPlate4 = extroInfo.NumberPlate4.ToString();                // 車両登録番号（プレート番号）
            }
            
            //carInfoRow.EntryDate = extroInfo.EntryDate;                                 // 登録年月日
            if (extroInfo.EntryDate != DateTime.MinValue)
            {
                carInfoRow.EntryDate = extroInfo.EntryDate.ToString();                                 // 登録年月日
            }
            else
            {
                carInfoRow.EntryDate = "　";                                 // 登録年月日
            }
           
            //if (extroInfo.ProduceTypeOfYearInput != 0)
            //{
            //    carInfoRow.FirstEntryDate = DateTime.ParseExact(extroInfo.ProduceTypeOfYearInput.ToString(), "yyyyMM", null); // 初年度
            //}

            // --- DEL 2013/05/08 Y.Wakita ---------->>>>>
            //DateTime tempFirstEntryDate = DateTime.MinValue;
            //try
            //{
            //    if (extroInfo.ProduceTypeOfYearInput != 0)
            //    {
            //        tempFirstEntryDate = DateTime.ParseExact(extroInfo.ProduceTypeOfYearInput.ToString(), "yyyyMM", null); // 初年度
            //    }
            //}
            //catch
            //{
            //    tempFirstEntryDate = DateTime.MinValue;
            //}

            //if (extroInfo.ProduceTypeOfYearInput != 0)
            //{
            //    if (tempFirstEntryDate != DateTime.MinValue)
            //    {
            //        carInfoRow.FirstEntryDate = tempFirstEntryDate.ToString("yyyy年MM月"); // 初年度
            //    }
            //    else
            //    {
            //        carInfoRow.FirstEntryDate = extroInfo.ProduceTypeOfYearInput.ToString().Substring(0, 4) + "年";
            //    }
               
            //}
            //else
            //{
            //    carInfoRow.FirstEntryDate = "　"; // 初年度
            //}
            // --- DEL 2013/05/08 Y.Wakita ----------<<<<<

            // --- ADD 2013/05/08 Y.Wakita ---------->>>>>
            // 年式[NULLのときは空白]
            if (extroInfo.ProduceTypeOfYearInput == 0)
            {
                carInfoRow.FirstEntryDate = string.Empty;
            }
            else
            {
                string firstEntryDate = "";

                if (extroInfo.ProduceTypeOfYearInput.ToString().Length < 6)
                {
                    firstEntryDate = "0000" + "/" + extroInfo.ProduceTypeOfYearInput.ToString("D2");
                }
                else
                {
                    firstEntryDate = extroInfo.ProduceTypeOfYearInput.ToString().Substring(0, 4) + "/" +
                                     extroInfo.ProduceTypeOfYearInput.ToString().Substring(4, 2);
                }

                firstEntryDate = firstEntryDate.Replace(@"/00", "");

                if (this._carMngInputAcs.GetAllDefSet().EraNameDispCd1 == 1)
                {
                    string date, stTarget;
                    int StartTotalUnitYm;

                    if (extroInfo.ProduceTypeOfYearInput.ToString().Substring(4, 2) == "00")
                    {
                        date = extroInfo.ProduceTypeOfYearInput.ToString().Substring(0, 4) + "0101";
                        StartTotalUnitYm = Convert.ToInt32(date);
                        stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);
                    }
                    else
                    {
                        date = extroInfo.ProduceTypeOfYearInput.ToString() + "01";
                        StartTotalUnitYm = Convert.ToInt32(date);
                        stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                    }

                    carInfoRow.FirstEntryDate = stTarget;
                }
                else
                {
                    carInfoRow.FirstEntryDate = firstEntryDate;
                }
            }
            // --- ADD 2013/05/08 Y.Wakita ----------<<<<<

            // -----ADD 2009/10/10 -----<<<<<
            carInfoRow.MakerCode = extroInfo.MakerCode;                                 // メーカーコード
            carInfoRow.MakerFullName = extroInfo.MakerFullName;                         // メーカー全角名称
            carInfoRow.MakerHalfName = extroInfo.MakerHalfName;                         // メーカー半角名称
            carInfoRow.ModelCode = extroInfo.ModelCode.ToString();                      // 車種コード
            carInfoRow.ModelSubCode = extroInfo.ModelSubCode.ToString();                // 車種サブコード
            carInfoRow.ModelFullName = extroInfo.ModelFullName;                         // 車種全角名称
            carInfoRow.ModelHalfName = extroInfo.ModelHalfName;                         // 車種半角名称
            carInfoRow.SystematicCode = extroInfo.SystematicCode;                       // 系統コード
            carInfoRow.SystematicName = extroInfo.SystematicName;                       // 系統名称
            carInfoRow.ProduceTypeOfYearCd = extroInfo.ProduceTypeOfYearCd;             // 生産年式コード
            carInfoRow.ProduceTypeOfYearNm = extroInfo.ProduceTypeOfYearNm;             // 生産年式名称
            carInfoRow.StProduceTypeOfYear = extroInfo.StProduceTypeOfYear;             // 開始生産年式
            carInfoRow.EdProduceTypeOfYear = extroInfo.EdProduceTypeOfYear;             // 終了生産年式
            carInfoRow.DoorCount = extroInfo.DoorCount;                                 // ドア数
            carInfoRow.BodyNameCode = extroInfo.BodyNameCode;                           // ボディー名コード
            carInfoRow.BodyName = extroInfo.BodyName;                                   // ボディー名称
            carInfoRow.ExhaustGasSign = extroInfo.ExhaustGasSign;                       // 排ガス記号
            carInfoRow.SeriesModel = extroInfo.SeriesModel;                             // シリーズ型式
            carInfoRow.CategorySignModel = extroInfo.CategorySignModel;                 // 型式（類別記号）
            carInfoRow.FullModel = extroInfo.FullModel;                                 // 型式（フル型）
            carInfoRow.ModelDesignationNo = extroInfo.ModelDesignationNo.ToString();    // 型式指定番号
            carInfoRow.CategoryNo = extroInfo.CategoryNo.ToString();                    // 類別番号
            carInfoRow.FrameModel = extroInfo.FrameModel;                               // 車台型式
            carInfoRow.FrameNo = extroInfo.FrameNo;                                     // 車台番号
            carInfoRow.SearchFrameNo = extroInfo.SearchFrameNo;                         // 車台番号（検索用）
            carInfoRow.StProduceFrameNo = extroInfo.StProduceFrameNo;                   // 生産車台番号開始
            carInfoRow.EdProduceFrameNo = extroInfo.EdProduceFrameNo;                   // 生産車台番号終了
            carInfoRow.ModelGradeNm = extroInfo.ModelGradeNm;                           // 型式グレード名称
            carInfoRow.EngineModelNm = extroInfo.EngineModelNm;                         // エンジン型式名称
            carInfoRow.EngineDisplaceNm = extroInfo.EngineDisplaceNm;                   // 排気量名称
            carInfoRow.EDivNm = extroInfo.EDivNm;                                       // E区分名称
            carInfoRow.TransmissionNm = extroInfo.TransmissionNm;                       // ミッション名称
            carInfoRow.ShiftNm = extroInfo.ShiftNm;                                     // シフト名称
            carInfoRow.WheelDriveMethodNm = extroInfo.WheelDriveMethodNm;               // 駆動方式名称
            carInfoRow.AddiCarSpec1 = extroInfo.AddiCarSpec1;                           // 追加諸元1
            carInfoRow.AddiCarSpec2 = extroInfo.AddiCarSpec2;                           // 追加諸元2
            carInfoRow.AddiCarSpec3 = extroInfo.AddiCarSpec3;                           // 追加諸元3
            carInfoRow.AddiCarSpec4 = extroInfo.AddiCarSpec4;                           // 追加諸元4
            carInfoRow.AddiCarSpec5 = extroInfo.AddiCarSpec5;                           // 追加諸元5
            carInfoRow.AddiCarSpec6 = extroInfo.AddiCarSpec6;                           // 追加諸元6
            carInfoRow.AddiCarSpecTitle1 = extroInfo.AddiCarSpecTitle1;                 // 追加諸元タイトル1
            carInfoRow.AddiCarSpecTitle2 = extroInfo.AddiCarSpecTitle2;                 // 追加諸元タイトル2
            carInfoRow.AddiCarSpecTitle3 = extroInfo.AddiCarSpecTitle3;                 // 追加諸元タイトル3
            carInfoRow.AddiCarSpecTitle4 = extroInfo.AddiCarSpecTitle4;                 // 追加諸元タイトル4
            carInfoRow.AddiCarSpecTitle5 = extroInfo.AddiCarSpecTitle5;                 // 追加諸元タイトル5
            carInfoRow.AddiCarSpecTitle6 = extroInfo.AddiCarSpecTitle6;                 // 追加諸元タイトル6
            carInfoRow.RelevanceModel = extroInfo.RelevanceModel;                       // 関連型式
            carInfoRow.SubCarNmCd = extroInfo.SubCarNmCd;                               // サブ車名コード
            carInfoRow.ModelGradeSname = extroInfo.ModelGradeSname;                     // 型式グレード略称
            carInfoRow.BlockIllustrationCd = extroInfo.BlockIllustrationCd;             // ブロックイラストコード
            carInfoRow.ThreeDIllustNo = extroInfo.ThreeDIllustNo;                       // 3DイラストNo
            carInfoRow.PartsDataOfferFlag = extroInfo.PartsDataOfferFlag;               // 部品データ提供フラグ
            // ----ADD 2009/10/10 ------>>>>>
            if (extroInfo.InspectMaturityDate != DateTime.MinValue)
            {
                carInfoRow.InspectMaturityDate = extroInfo.InspectMaturityDate.ToString();             // 車検満期日
            }
            else
            {
                carInfoRow.InspectMaturityDate = "　";
            }
            if (extroInfo.LTimeCiMatDate != DateTime.MinValue)
            {
                carInfoRow.LTimeCiMatDate = extroInfo.LTimeCiMatDate.ToString();                       // 前回車検満期日
            }
            else
            {
                carInfoRow.LTimeCiMatDate = "　";                      // 前回車検満期日
            }
            // ----ADD 2009/10/10 ------<<<<<
           
            carInfoRow.CarInspectYear = extroInfo.CarInspectYear;                       // 車検期間
            carInfoRow.Mileage = extroInfo.Mileage;                                     // 車両走行距離
            carInfoRow.CarNo = extroInfo.CarNo;                                         // 号車
            carInfoRow.FullModelFixedNoAry = extroInfo.FullModelFixedNoAry;             // フル型式固定番号配列
            //carInfoRow.CategoryObjAry = Encoding.Default.GetString(extroInfo.CategoryObjAry);// 装備オブジェクト配列
            carInfoRow.CategoryObjAry = extroInfo.CategoryObjAry;// 装備オブジェクト配列
            carInfoRow.ColorCode = extroInfo.ColorCode;                                 // カラーコード
            carInfoRow.ColorName1 = extroInfo.ColorName1;                               // カラー名称
            carInfoRow.TrimCode = extroInfo.TrimCode;                                   // トリムコード
            carInfoRow.TrimName = extroInfo.TrimName;                                   // トリム名称
            carInfoRow.CarAddInfo1 = extroInfo.CarAddInfo1;                             // 追加情報１
            carInfoRow.CarAddInfo2 = extroInfo.CarAddInfo2;                             // 追加情報２
            carInfoRow.CarNote = extroInfo.CarNote;                                     // 備考
            carInfoRow.EngineModel = extroInfo.EngineModel;                             // 原動機型式
            // ----ADD 2010/12/22 ------ >>>>> 
            if (null == extroInfo.FreeSrchMdlFxdNoAry || extroInfo.FreeSrchMdlFxdNoAry.Length == 0)
            {
                carInfoRow.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                carInfoRow.FreeSrchMdlFxdNoAry = extroInfo.FreeSrchMdlFxdNoAry;
            }
            // ----ADD 2010/12/22 ------ <<<<< 

            // ADD 2013/03/22 -------------------->>>>>
            carInfoRow.DomesticForeignCode = extroInfo.DomesticForeignCode;             //国産/外車区分
            carInfoRow.HandleInfoCode = extroInfo.HandleInfoCode;                       //ハンドル位置情報
            // ADD 2013/03/22 --------------------<<<<<
            return carInfoRow;
        }

        /// <summary>
        /// 一括入力画面のグリッドへ追加する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括入力画面のグリッドへ追加する。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void AddRowToList()
        {
            CarMngInputDataSet.CarInfoRow addRow = this._listAcs.CarInfoDataTable.NewCarInfoRow();
            CarMngInputDataSet.CarInfoRow carInfoRow = this.CopyExtraInfoToCarInfoRow(this._extraInfo);
            this._listAcs.InsertCarInfoRow(carInfoRow);
        }

        /// <summary>
        /// 一括入力画面のグリッドへ変更する
        /// <param name="isRevive">復活かどうか</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括入力画面のグリッドへ変更する。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void UpdRowToList(bool isRevive)
        {
            CarMngInputDataSet.CarInfoRow updRow = this._listAcs.CarInfoDataTable.FindByCarRelationGuid(this._guid);
            if (updRow != null)
            {
                if (isRevive == true)
                {
                    updRow["DeleteDate"] = DBNull.Value;
                }
                CarMngInputDataSet.CarInfoRow carInfoRow = this.CopyExtraInfoToCarInfoRow(this._extraInfo);
                this._listAcs.CopyCarInfoRow(carInfoRow, updRow);
                this._listAcs.UpdateOriginalRow(updRow);
            }
        }

        /// <summary>
        /// 一括入力画面のグリッドから削除する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括入力画面のグリッドから削除する。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void DelRowFromList()
        {
            CarMngInputDataSet.CarInfoRow delRow = this._listAcs.CarInfoDataTable.FindByCarRelationGuid(this._guid);
            if (delRow != null)
            {
                this._listAcs.DeleteOriginalTableRow(delRow);
                this._listAcs.CarInfoDataTable.RemoveCarInfoRow(delRow);
            }
        }

        /// <summary>
        /// 編集中データのチェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 編集中データのチェックです。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool IsHaveDataChanged()
        {
            // 新規モードの場合
            if (this._mode == INSERT_MODE)
            {
                // 得意先コード
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return true;
                }
                // 管理番号
                if (!string.IsNullOrEmpty(this.tEdit_CarMngCode.Text))
                {
                    return true;
                }
                // 型式指定番号
                if (this.tNedit_ModelDesignationNo.GetInt() != 0)
                {
                    return true;
                }
                // 類別区分番号
                if (this.tNedit_CategoryNo.GetInt() != 0)
                {
                    return true;
                }
                // 型式
                if (!string.IsNullOrEmpty(this.tEdit_FullModel.Text))
                {
                    return true;
                }
                // エンジン型式
                if (!string.IsNullOrEmpty(this.tEdit_EngineModelNm.Text))
                {
                    return true;
                }
                // カーメーカーコード
                if (this.tNedit_MakerCode.GetInt() != 0)
                {
                    return true;
                }
                // 車種コード
                if (this.tNedit_ModelCode.GetInt() != 0)
                {
                    return true;
                }
                // 車種呼称コード
                if (this.tNedit_ModelSubCode.GetInt() != 0)
                {
                    return true;
                }
                // 車種名称
                if (!string.IsNullOrEmpty(this.tEdit_ModelFullName.Text))
                {
                    return true;
                }
                
                // 年式
                if (string.Compare(this.tDateEdit_FirstEntryDate.GetDateTime().ToString("yyyy/MM/dd"), DateTime.MinValue.ToString("yyyy/MM/dd")) != 0)
                {
                    return true;
                }
                
                // 車台番号
                if (!string.IsNullOrEmpty(this.tEdit_ProduceFrameNo.Text))
                {
                    return true;
                }
                // カラー
                if (!string.IsNullOrEmpty(this.tEdit_ColorNo.Text))
                {
                    return true;
                }
                // トリム
                if (!string.IsNullOrEmpty(this.tEdit_TrimNo.Text))
                {
                    return true;
                }
                // 原動機型式
                if (!string.IsNullOrEmpty(this.tEdit_EngineModel.Text))
                {
                    return true;
                }
                // 追加情報１
                if (!string.IsNullOrEmpty(this.tEdit_CarAddInfo1.Text))
                {
                    return true;
                }
                // 追加情報２
                if (!string.IsNullOrEmpty(this.tEdit_CarAddInfo2.Text))
                {
                    return true;
                }
                // 登録番号（陸運事務所番号）
                if (this.tNedit_NumberPlate1Code.GetInt() != 0)
                {
                    return true;
                }
                // 登録番号(陸運事務所名称)
                if (!string.IsNullOrEmpty(this.tEdit_NumberPlate1Name.Text))
                {
                    return true;
                }
                // 登録番号(種別)
                if (!string.IsNullOrEmpty(this.tEdit_NumberPlate2.Text))
                {
                    return true;
                }
                // 登録番号(カナ)
                if (!string.IsNullOrEmpty(this.tEdit_NumberPlate3.Text))
                {
                    return true;
                }
                // 登録番号(プレート番号)
                if (this.tNedit_NumberPlate4.GetInt() != 0)
                {
                    return true;
                }
                // 走行距離
                if (this.tNedit_Mileage.GetInt() != 0)
                {
                    return true;
                }
                // 登録年月日
                if (string.Compare(this.tDateEdit_EntryDate.GetDateTime().ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd")) != 0)
                {
                    return true;
                }
                // 車検期間
                if (this.tNedit_CarInspectYear.GetInt() != 2)
                {
                    return true;
                }
                // 前回車検日
                if (string.Compare(this.tDateEdit_LTimeCiMatDate.GetDateTime().ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd")) != 0)
                {
                    return true;
                }
                // 次回車検日
                if (string.Compare(this.tDateEdit_InspectMaturityDate.GetDateTime().ToString("yyyy/MM/dd"), DateTime.Now.AddYears(2).ToString("yyyy/MM/dd")) != 0)
                {
                    return true;
                }
                // 車輌備考
                if (!string.IsNullOrEmpty(this.tEdit_SlipNote.Text))
                {
                    return true;
                }
            }
            else
            {
                // 得意先コード
                if (this.tNedit_CustomerCode.GetInt() != this._extraInfoForChangeCheck.CustomerCode)
                {
                    return true;
                }
                // 管理番号
                if (this.tEdit_CarMngCode.Text != this._extraInfoForChangeCheck.CarMngCode)
                {
                    return true;
                }
                // 型式指定番号
                if (this.tNedit_ModelDesignationNo.GetInt() != this._extraInfoForChangeCheck.ModelDesignationNo)
                {
                    return true;
                }
                // 類別区分番号
                if (this.tNedit_CategoryNo.GetInt() != this._extraInfoForChangeCheck.CategoryNo)
                {
                    return true;
                }
                // 型式
                if (this.tEdit_FullModel.Text != this._extraInfoForChangeCheck.FullModel)
                {
                    return true;
                }
                // エンジン型式
                if (this.tEdit_EngineModelNm.Text != this._extraInfoForChangeCheck.EngineModelNm)
                {
                    return true;
                }
                // カーメーカーコード
                if (this.tNedit_MakerCode.GetInt() != this._extraInfoForChangeCheck.MakerCode)
                {
                    return true;
                }
                // 車種コード
                if (this.tNedit_ModelCode.GetInt() != this._extraInfoForChangeCheck.ModelCode)
                {
                    return true;
                }
                // 車種呼称コード
                if (this.tNedit_ModelSubCode.GetInt() != this._extraInfoForChangeCheck.ModelSubCode)
                {
                    return true;
                }
                // 車種名称
                if (this.tEdit_ModelFullName.Text != this._extraInfoForChangeCheck.ModelFullName)
                {
                    return true;
                }
               
                // ----ADD 2009/10/10 ------>>>>>
                // 年式
                //if (DateTime.Compare(this.tDateEdit_FirstEntryDate.GetDateTime(), this._extraInfoForChangeCheck.FirstEntryDate) != 0)
                //{
                //    return true;
                //}
                DateTime tempFirstEntryDate = DateTime.MinValue;

                try
                {
                    if (_extraInfoForChangeCheck.FirstEntryDate != 0)
                    {
                        tempFirstEntryDate = DateTime.ParseExact(_extraInfoForChangeCheck.FirstEntryDate.ToString(), "yyyyMM", null); // 初年度
                    }
                }
                catch
                {
                    tempFirstEntryDate = DateTime.MinValue;
                }

                // --- ADD 2013/05/02 Y.Wakita ---------->>>>>
                // --- UPD 2013/05/09 Y.Wakita ---------->>>>>
                //if (this.tDateEdit_FirstEntryDate.GetLongDate() != 0)
                if ((this.tDateEdit_FirstEntryDate.GetLongDate() != 0) &&
                    (this.tDateEdit_FirstEntryDate.GetLongDate().ToString().Substring(4, 2) != "00"))
                // --- UPD 2013/05/09 Y.Wakita ---------->>>>>
                {
                    string _firstEntryDate = this.tDateEdit_FirstEntryDate.GetLongDate().ToString();
                    _firstEntryDate = _firstEntryDate.Substring(0, 4) + "/" +
                                      _firstEntryDate.Substring(4, 2) + "/" + "01";
                    this.tDateEdit_FirstEntryDate.SetDateTime(DateTime.Parse(_firstEntryDate));
                }
                // --- ADD 2013/05/02 Y.Wakita ----------<<<<<

                // 年式
                if (DateTime.Compare(this.tDateEdit_FirstEntryDate.GetDateTime(), tempFirstEntryDate) != 0)
                {
                    return true;
                }

                // ----ADD 2009/10/10 ------<<<<<
                // 車台番号
                if (this.tEdit_ProduceFrameNo.Text != this._extraInfoForChangeCheck.FrameNo)
                {
                    return true;
                }
                // カラー
                if (this.tEdit_ColorNo.Text != this._extraInfoForChangeCheck.ColorCode)
                {
                    return true;
                }
                // トリム
                if (this.tEdit_TrimNo.Text != this._extraInfoForChangeCheck.TrimCode)
                {
                    return true;
                }
                // 原動機型式
                if (this.tEdit_EngineModel.Text != this._extraInfoForChangeCheck.EngineModel)
                {
                    return true;
                }
                // 追加情報１
                if (this.tEdit_CarAddInfo1.Text != this._extraInfoForChangeCheck.CarAddInfo1)
                {
                    return true;
                }
                // 追加情報２
                if (this.tEdit_CarAddInfo2.Text != this._extraInfoForChangeCheck.CarAddInfo2)
                {
                    return true;
                }
                // 登録番号（陸運事務所番号）
                if (this.tNedit_NumberPlate1Code.GetInt() != this._extraInfoForChangeCheck.NumberPlate1Code)
                {
                    return true;
                }
                // 登録番号(陸運事務所名称)
                if (this.tEdit_NumberPlate1Name.Text != this._extraInfoForChangeCheck.NumberPlate1Name)
                {
                    return true;
                }
                // 登録番号(種別)
                if (this.tEdit_NumberPlate2.Text != this._extraInfoForChangeCheck.NumberPlate2)
                {
                    return true;
                }
                // 登録番号(カナ)
                if (this.tEdit_NumberPlate3.Text != this._extraInfoForChangeCheck.NumberPlate3)
                {
                    return true;
                }
                // 登録番号(プレート番号)
                if (this.tNedit_NumberPlate4.GetInt() != this._extraInfoForChangeCheck.NumberPlate4)
                {
                    return true;
                }
                // 走行距離
                if (this.tNedit_Mileage.GetInt() != this._extraInfoForChangeCheck.Mileage)
                {
                    return true;
                }
                // 登録年月日
                if (DateTime.Compare(this.tDateEdit_EntryDate.GetDateTime(), this._extraInfoForChangeCheck.EntryDate) != 0)
                {
                    return true;
                }
                // 車検期間
                if (this.tNedit_CarInspectYear.GetInt() != this._extraInfoForChangeCheck.CarInspectYear)
                {
                    return true;
                }
                // 前回車検日
                if (DateTime.Compare(this.tDateEdit_LTimeCiMatDate.GetDateTime(), this._extraInfoForChangeCheck.LTimeCiMatDate) != 0)
                {
                    return true;
                }
                // 次回車検日
                if (DateTime.Compare(this.tDateEdit_InspectMaturityDate.GetDateTime(), this._extraInfoForChangeCheck.InspectMaturityDate) != 0)
                {
                    return true;
                }
                // 車輌備考
                if (this.tEdit_SlipNote.Text != this._extraInfoForChangeCheck.CarNote)
                {
                    return true;
                }
                // 装備オブジェクト配列
                if (this.byteEquals(this._carMngInputAcs.GetEquipInfoRows(this._extraInfoForChangeCheck.CarRelationGuid), this._extraInfoForChangeCheck.CategoryObjAry) == false)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 修正モードの場合で、「フル型式固定番号配列」と「装備オブジェクト配列」の未設定のチェック処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 修正モードの場合で、「フル型式固定番号配列」と「装備オブジェクト配列」の未設定のチェック処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool CheckCarInfoAryByUpdateMod()
        {
            // 修正モードの場合
            if (this._mode == UPDATE_MODE
                && this.uLabel_SearchTypeTitle.Text.Equals("型式必須"))
            {
                // 車輌管理マスタの「フル型式固定番号配列」又は「装備オブジェクト配列」が未設定の場合
                if (this._extraInfo.FullModelFixedNoAry == null || this._extraInfo.FullModelFixedNoAry.Length == 0 &&
                    this._extraInfo.CategoryObjAry == null || this._extraInfo.CategoryObjAry.Length == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// カラー情報設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="colorCode"></param>
        /// <remarks>
        /// <br>Note       : カラー情報設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingColorInfo(object sender, string colorCode)
        {
            this.tEdit_ColorNo.Text = colorCode;
            this._extraInfo.ColorCode = colorCode;
            this._extraInfo.ColorName1 = this._carOtherInfoInput.ExtraInfo.ColorName1;
        }

        /// <summary>
        /// トリム情報設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="trimCode"></param>
        /// <remarks>
        /// <br>Note       : トリム情報設定処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingTrimInfo(object sender, string trimCode)
        {
            this.tEdit_TrimNo.Text = trimCode;
            this._extraInfo.TrimCode = trimCode;
            this._extraInfo.TrimName = this._carOtherInfoInput.ExtraInfo.TrimName;
        }

        /// <summary>
        /// byte配列の比較処理
        /// </summary>
        /// <param name="b1">byte配列1</param>
        /// <param name="b2">byte配列2</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : byte配列の比較処理です。</br>      
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool byteEquals(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) return false;
            if (b1 == null || b2 == null) return false;
            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }

        /// <summary>
        /// Coopyチェック処理                                              
        /// </summary>
        /// <param name="inputName">項目名称</param>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 李占川</br>                                    
        /// <br>Date        : 2009/09/07</br>                                        
        /// <br>UpdateNote  : 2016/12/13 呉軍</br>
        /// <br>管理番号    : 11270098-00</br>
        /// <br>            : Redmine#48934 PMNSナンバープレート英文字対応</br>
        /// </remarks>
        private void WordCoopyCheck(string inputName)
        {
            switch (inputName)
            {
                // 管理番号
                case "tEdit_CarMngCode":
                    {
                        this.IsHalfCheck(this.tEdit_CarMngCode);
                        break;
                    }
                // 型式指定番号
                case "tNedit_ModelDesignationNo":
                    {
                        // 半角数字のみ入力可能
                        int value = this.tNedit_ModelDesignationNo.GetInt();

                        if (value == 0)
                        {
                            this.tNedit_ModelDesignationNo.Text = string.Empty;
                        }

                        break;
                    }
                // 類別番号
                case "tNedit_CategoryNo":
                    {
                        // 半角数字のみ入力可能
                        int value = this.tNedit_CategoryNo.GetInt();

                        if (value == 0)
                        {
                            this.tNedit_CategoryNo.Text = string.Empty;
                        }

                        break;
                    }
                // 型式ボタン
                case "tEdit_EngineModelNm":
                    {
                        this.IsHalfCheck(this.tEdit_EngineModelNm);
                        break;
                    }
                // エンジン型式
                case "tEdit_FullModel":
                    {
                        this.IsHalfCheck(this.tEdit_FullModel);
                        break;
                    }
                // 車種
                case "tNedit_MakerCode":
                    {
                        // 半角数字のみ入力可能
                        int value = this.tNedit_MakerCode.GetInt();

                        if (value == 0)
                        {
                            this.tNedit_MakerCode.Text = string.Empty;
                        }

                        break;
                    }
                // 車台番号
                case "tEdit_ProduceFrameNo":
                    {
                        // DEL 2013/03/22 -------------------->>>>>
                    	// 半角数字のみ入力可能
                        //string value = this.tEdit_ProduceFrameNo.Text;
                        //
                        //Regex r = new Regex(@"^\d+(\.)?\d*$");

                        //if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
                        //{
                        //    this.tEdit_ProduceFrameNo.Text = string.Empty;
                        //}
                    	// DEL 2013/03/22 --------------------<<<<<
                        // ADD 2013/03/22 -------------------->>>>>
                        this.IsHalfCheck(this.tEdit_ProduceFrameNo);
                        // ADD 2013/03/22 --------------------<<<<<
                        break;
                    }

                // 原動機型式
                case "tEdit_EngineModel":
                    {
                        this.IsHalfCheck(this.tEdit_EngineModel);
                        break;
                    }

                // 登録番号(種別)
                case "tEdit_NumberPlate2":
                    {
                        // 半角数字のみ入力可能
                        string value = this.tEdit_NumberPlate2.Text;

                        //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 ----->>>>>
                        //Regex r = new Regex(@"^\d+(\.)?\d*$");
                        Regex r = new Regex(@"^[a-zａ-ｚA-ZＡ-Ｚ0-9０-９]+(\.)?[a-zａ-ｚA-ZＡ-Ｚ0-9０-９]*$");
                        //----- UPD 2016/12/13 呉軍 Redmine#48934 PMNSナンバープレート英文字対応 -----<<<<<

                        if ((!String.IsNullOrEmpty(value)) && !r.IsMatch(value))
                        {
                            this.tEdit_NumberPlate2.Text = string.Empty;
                        }

                        break;
                    }
                // 登録番号(プレート番号)
                case "tNedit_NumberPlate4":
                    {
                        // 半角数字のみ入力可能
                        int value = this.tNedit_NumberPlate4.GetInt();

                        if (value == 0)
                        {
                            this.tNedit_NumberPlate4.Text = string.Empty;
                        }

                        break;
                    }
                // 走行距離
                case "tNedit_Mileage":
                    {
                        // 半角数字のみ入力可能
                        int value = this.tNedit_Mileage.GetInt();

                        if (value == 0)
                        {
                            this.tNedit_Mileage.Text = string.Empty;
                        }

                        break;
                    }
                // 車検期間
                case "tNedit_CarInspectYear":
                    {
                        // 半角数字のみ入力可能
                        int value = this.tNedit_CarInspectYear.GetInt();

                        if (value == 0)
                        {
                            this.tNedit_CarInspectYear.Text = string.Empty;
                        }

                        break;
                    }

            }

        }

        /// <summary>
        /// Coopy半角チェック処理                                              
        /// </summary>
        /// <param name="tEdit">項目</param>
        /// <remarks>
        /// <br>Note　　　  : Copy文字時に発生します</br>                  
        /// <br>Programmer  : 李占川</br>                                    
        /// <br>Date        : 2009/09/07</br>                                        
        /// </remarks>
        private void IsHalfCheck(TEdit tEdit)
        {
            // 半角のみ入力可能
            string value = tEdit.Text;

            // 半角を判断する
            bool isHalf = true;
            for (int i = 0; i < value.Length; i++)
            {
                String cutStr = value.Substring(i, 1);
                if (ASCIIEncoding.Default.GetByteCount(cutStr) == 2)
                {
                    isHalf = false;
                    break;
                }
            }

            // 半角がありの場合、クリアする
            if (!isHalf)
            {
                tEdit.Text = string.Empty;
            }
        }
        # endregion


        // --- ADD 2009/10/10 ----->>>>>
        # region [車輌情報保持用]
        /// <summary>
        /// 車輌情報保持用
        /// </summary>
        private struct BeforeCarSearchBuffer
        {
            /// <summary>車台番号</summary>
            private string _produceFrameNo;
            /// <summary>生産年式</summary>
            private int _firstEntryDate;
            /// <summary>カラーコード</summary>
            private string _colorNo;
            /// <summary>トリムコード</summary>
            private string _trimNo;
            /// <summary>
            /// 車台番号
            /// </summary>
            public string ProduceFrameNo
            {
                get { return _produceFrameNo; }
                set { _produceFrameNo = value; }
            }
            /// <summary>
            /// 生産年式
            /// </summary>
            public int FirstEntryDate
            {
                get { return _firstEntryDate; }
                set { _firstEntryDate = value; }
            }
            /// <summary>
            /// カラーコード
            /// </summary>
            public string ColorNo
            {
                get { return _colorNo; }
                set { _colorNo = value; }
            }
            /// <summary>
            /// トリムコード
            /// </summary>
            public string TrimNo
            {
                get { return _trimNo; }
                set { _trimNo = value; }
            }
            /// <summary>
            /// 初期化
            /// </summary>
            public void Clear()
            {
                _produceFrameNo = string.Empty;
                _firstEntryDate = 0;
                _colorNo = string.Empty;
                _trimNo = string.Empty;
            }
        }
        # endregion
        // --- ADD 2009/10/10 -----<<<<<
    }
}