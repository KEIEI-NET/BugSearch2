//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先マスタ
// プログラム概要   ：得意先の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/04/30     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008.11.27     修正内容：入力された請求コードが納入先の場合、エラーとする
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤仁美
// 修正日    2008/12/05     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/02/05     修正内容：障害ID:9388,9391対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2009/02/16     修正内容：親得意先更新時、属する子得意先も同時更新するよう変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/03/02     修正内容：障害ID:11999対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【12493】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/03     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/18     修正内容：Mantis【13400、13455】対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/26     修正内容：Mantis【13295】得意先名称と略称の必須チェックから除外
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009/07/30     修正内容：LoginInfoAcquisition.OnlineFlagを参照して処理を行わない。
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30531 大矢 睦美
// 修正日    2010/01/04     修正内容：Mantis【14873】請求書出力区分を削除し、
//　　　　　　　　　　　　　　　　　：合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤 恵優
// 修正日    2010/06/26     修正内容：SCM：簡単問合せアカウントグループIDを追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/06/29     修正内容：Mantis.15675　OnlineFlagを参照して処理を行わない。
//                                    デザイン変更『簡単問合せアカウントグループID』⇒『CMTアカウントグループID』
//                                    CMTアカウントグループＩＤの入力文字を全角以外全て許可する様に変更。
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/07/06     修正内容：QRコード携帯メール対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：caowj
// 修正日    2010/08/10     修正内容：得意先マスタ障害改良対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：朱 猛
// 修正日    2010/12/06     修正内容：障害改良対応12月
// ---------------------------------------------------------------------//
// 管理番号  10704766-00    作成担当：caohh
// 修正日    2011/08/04     修正内容：NSユーザー改良要望一覧連番265の対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：yangmj
// 修正日    2011/12/05     修正内容：redmine#8413の対応
// ---------------------------------------------------------------------//
// 管理番号  10970681-00    作成担当：陳健
// 修正日    K2014/02/06    修正内容：前橋京和商会個別 得意先マスタ改良対応
// -------------------------------------------------------------------------//
// 管理番号  10970681-00    作成担当：陳健
// 修正日    2014/03/10     修正内容：Redmine#42174論理削除モードでコントロールの制御
// -------------------------------------------------------------------------//
// 管理番号  10970681-00    作成担当：陳健
// 修正日    2014/03/12     修正内容：Redmine#42174 得意先メモ情報の右メニュー作成
// -------------------------------------------------------------------------//
// 管理番号  11770021-00    作成担当：梶谷貴士
// 修正日    2021/05/10     修正内容：得意先情報ガイド表示PKG対応
// -------------------------------------------------------------------------//
// 管理番号  11570183-00 作成担当 ：田村顕成
// 修正日    2022/03/04  修正内容 ：電子帳簿連携対応 ラベル項目の変更（DM出力→電子帳簿出力）
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Resources;

using System.Collections.Generic;
using Infragistics.Win.Misc;   // m.suzuki
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先選択イベント用デリゲート
    /// </summary>
    public delegate void CustomerSelectedEventHandler( object sender, string enterpriseCode, int customerCode );

    /// <summary>
    /// 管理コード転送デリゲート
    /// </summary>
    public delegate void CustomerCarSectionCodeTransmitEventHandler( object sender, string sectionCode );

    // --- ADD 2010/08/10 ------------------------------------>>>>>
    /// <summary>
    /// 保存用デリゲート
    /// </summary>
    public delegate int DataSaveEventHandler(bool saveCompletionDialogDisp);
    /// <summary>
    /// ガイド（F5）表示用デリゲート
    /// </summary>
    public delegate void SetGuideEnableEventHandler(bool enabled);
    // --- ADD 2010/08/10 ------------------------------------<<<<<


    /// <summary>
    /// 得意先情報入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先情報の入力を行うフォームクラスです。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2008.04.30</br>
    /// <br>Update Note: 2008.11.27 30452 上野 俊治</br>
    /// <br>             入力された請求コードが納入先の場合、エラーとする</br>
    /// <br>UpdateNote  : 2008/12/05 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2009/02/05 30414 忍幸史　障害ID:9388,9391対応</br>
    /// <br>UpdateNote  : 2009/02/16 22018 鈴木正臣 親得意先更新時、属する子得意先も同時更新するよう変更</br>
    /// <br>UpdateNote  : 2009/03/02 30414 忍幸史 障害ID:11999対応</br>
    /// <br>Update Note: 2010/08/10 caowj</br>
    /// <br>             得意先マスタ障害改良対応</br>
    /// <br>Update Note: 2011/08/04 caohh</br>
    /// <br>             NSユーザー改良要望一覧連番265の対応</br>
    /// <br>Update Note: 2021/05/10 梶谷貴士</br>
    /// <br>             得意先情報ガイド表示PKG対応</br>
    /// </remarks>
    public partial class PMKHN09010UA : System.Windows.Forms.Form
    {
        // ===================================================================================== //
        // 内部で使用する定数群
        // ===================================================================================== //
        # region Const
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2208.04.30 m.suzuki
        private const string SUBINFO_KEY0 = "SubInfo0";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2208.04.30 m.suzuki
        //private const string SUBINFO_KEY1 = "SubInfo1";
        private const string SUBINFO_KEY2 = "SubInfo2";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2208.04.30 m.suzuki
        //private const string SUBINFO_KEY3 = "SubInfo3";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2208.04.30 m.suzuki
        private const string SUBINFO_KEY4 = "SubInfo4";
        private const string SUBINFO_KEY5 = "SubInfo5";
        private const string SUBINFO_KEY6 = "SubInfo6";
        private const string SUBINFO_KEY7 = "SubInfo7";     // ADD 2009/06/03
        private const string NEW_INPUT_TITLE = "新規";
        private const string UPDATE_INPUT_TITLE = "更新";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
        private const string DELETE_INPUT_TITLE = "削除";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
        private const int STYLE_TAB = 1;
        private const int STYLE_SCROLL = 2;
        private const int MANUAL_NUMBERING_OK = 0;

        // Format定義
        private const string MONEY_FORMAT = "###,###,##0 円";

        private const int EXIST_CODE_CHECKED = 1;
        private const int EXIST_CODE_UNCHECKED = 0;
        # endregion

        // ===================================================================================== //
        // プライベート変数＆インターナル変数
        // ===================================================================================== //
        # region Private Members
        private Form _parentTopForm = null;									// 最上位親コントロール（Form）
        internal CustomerInfo _customerInfo = null;
        private CustomerInputConstructionAcs _customerInputConstructionAcs;	// 得意先画面用設定情報アクセスクラス
        private AlItmDspNmAcs _alItmDspNmAcs;
        private ImageList _imageList16 = null;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2208.04.30 m.suzuki
        //private PMKHN09010UB _subInfo3_Form = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2208.04.30 m.suzuki
        internal CustomerInputAcs _customerInputAcs = null;
        private KingetCustDmdPrcWork _kingetCustDmdPrcWork = null;
        private CustomerSectionInfoControl _sectionInfoControl;				// 拠点情報制御クラス
        private string _loginSectionCode = string.Empty;
        private string _enterpriseCode = string.Empty;
        //private string _balanceDispSecCd = string.Empty;
        private int _custCdAutoNumbering = 0;
        internal int _style = 0;
        private bool _customerCodeChangeFlg = false;						// 得意先コード手動修正フラグ
        private string _ownSectionCode = string.Empty;								// 自拠点コード
        private string _mngSectionCode = string.Empty;								// 管理拠点コード
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/04/28 ADD
        private string _claimSectionCode = string.Empty;                              // 請求拠点コード
        private string _custWarehouseCode = string.Empty;                                 // 優先倉庫コード 
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/04/28 ADD
        private ArrayList _offLineControlEnabledList;						// コントロールEnabled変更リスト（オフラインモード用）
        private string _key = Guid.NewGuid().ToString();					// ユニークキー文字列
        private ControlScreenSkin _controlScreenSkin;
        //private bool _canDisplayClaimTab = false;
        private Control _prevControl = null;									// 現在のコントロール
        private string _beforeName = string.Empty;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private int _commonConsTaxLayMethod;      // 消費税転嫁方式　退避用
        //private int _commonTotalAmountDispWayCd;  // 総額表示区分　　退避用
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
        private bool _customerSelected; // 得意先(請求先)ガイド選択済みフラグ
        private bool _enterYearOfCustAgentChgDate; // 担当者変更日フォーカス制御フラグ
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

        // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
        private DepositStAcs _depositStAcs;
        private MoneyKindAcs _moneyKindAcs;

        private DepositSt _depositSt;
        private Dictionary<int, MoneyKind> _moneyKindDic;
        // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        private object _preComboEditorValue = null;
        private bool comboInputFlg;
        // ユーザマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;
        private int _businessTypeCd;
        private int _saleAreaCd;
        private int _jobTypeCode;
        // --- ADD 2010/08/10 ------------------------------------<<<<<
        // ADD 陳健 K2014/02/06 -------------------------->>>>>
        //private int _opt_Maehashi;
        // ADD 陳健 K2014/02/06 --------------------------<<<<<
        // ADD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
        // 保存処理フラグ
        private bool saveFlg = false;
        // ADD 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// 得意先情報フォームクラスデフォルトコンストラクタ
        /// </summary>
        /// <param name="key">キー文字列</param>
        /// <param name="customerInfo">得意先情報</param>
        public PMKHN09010UA( string key, CustomerInfo customerInfo )
        {
            InitializeComponent();

            // 変数初期化
            this._key = key;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._customerInputAcs = new CustomerInputAcs( this._key );
            this._customerInfo = customerInfo.Clone();
            this._customerInputConstructionAcs = new CustomerInputConstructionAcs();
            this._alItmDspNmAcs = new AlItmDspNmAcs();
            this._kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2208.04.30 m.suzuki
            //this._subInfo3_Form = new PMKHN09010UB(this);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2208.04.30 m.suzuki
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._sectionInfoControl = new CustomerSectionInfoControl();
            this._controlScreenSkin = new ControlScreenSkin();

            // デリゲート用メソッド登録
            CustomerInputConstructionAcs.DataChanged += new EventHandler( this.ParentTopForm_SizeChanged );

            // コントロールEnabled変更リスト（オフラインモード用）生成処理
            this.ControlEnabledListCreate();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2208.04.30 m.suzuki
            //// 家族情報入力フォームをコントロールにＡＤＤ
            //this._subInfo3_Form.TopLevel = false;
            //this.SubInfo3_UTabPageControl.Controls.Add(this._subInfo3_Form);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2208.04.30 m.suzuki

            // タブインデックスの設定処理
            this.SetControlTabIndex();

            // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
            this._depositStAcs = new DepositStAcs();
            this._moneyKindAcs = new MoneyKindAcs();
            this._userGuideAcs = new UserGuideAcs();
            ReadDepositSt(out this._depositSt);
            ReadMoneyKind(out this._moneyKindDic);
            // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<
        }
        # endregion

        /// <summary>
        /// 得意先情報画面描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public Int32 ShowCustomerBuffer( object sender, string enterpriseCode, CustomerInfo customerInfo )
        {
            this._customerInfo = customerInfo.Clone();

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            return 0;
        }
        # region [staticメモリ制御]
        /// <summary>
        /// Staticメモリ画面情報表示処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns></returns>
        public Int32 ShowStaticMemoryData( object sender, string enterpriseCode, int customerCode )
        {
            //DateTime updateDatetime = this._customerInfo.UpdateDateTime;

            CustomerInfo customerInfo;
            int status = this._customerInputAcs.ReadStaticMemoryData( out customerInfo, enterpriseCode, customerCode );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                this._customerInfo = customerInfo.Clone();

                // 得意先クラス→画面格納処理
                this.SetDisplayFormCustomerInfo( this._customerInfo );
            }

            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            //if (this._customerInfo.CustomerCode == 0)
            //{
            //    // 請求情報をクリアする
            //    this._kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
            //}
            //else
            //{
            //    if ( updateDatetime == this._customerInfo.UpdateDateTime )
            //    {
            //        string sectionCode = this._loginSectionCode;
            //        if ( this.Section_tComboEditor.Value != null )
            //        {
            //            sectionCode = this.Section_tComboEditor.Value.ToString();
            //        }
            //        status = this._customerInputAcs.ReadKingetCustDmdPrc( this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, sectionCode, out this._kingetCustDmdPrcWork, true );
            //    }
            //    else
            //    {
            //        string sectionCode = this._loginSectionCode;
            //        if ( this.Section_tComboEditor.Value != null )
            //        {
            //            sectionCode = this.Section_tComboEditor.Value.ToString();
            //        }
            //        status = this._customerInputAcs.ReadKingetCustDmdPrc( this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, sectionCode, out this._kingetCustDmdPrcWork, false );
            //    }

            //    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //    {
            //        // 請求情報をクリアする
            //        this._kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
            //    }
            //}

            //// KINGET用得意先請求金額ワーククラス→画面格納処理
            //this.SetDisplayFormKingetCustDmdPrcWork(this._kingetCustDmdPrcWork);

            //return status;

            return 0;
        }

        /// <summary>
        /// 画面情報キャッシュデータ格納処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <returns>STATUS</returns>
        public Int32 SaveStaticMemoryData( object sender )
        {
            // ADD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
            // 保存処理フラグ
            saveFlg = true;
            // ADD 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<
            if ( this._prevControl != null )
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tArrowKeyControl1_ChangeFocus(this, e);
            }
            // ADD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
            // 保存処理フラグ
            saveFlg = false;
            // ADD 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<

            // 得意先コード手入力値が確定していない場合は得意先クラスから画面に情報を反映させる
            if ( this._customerCodeChangeFlg )
            {
                // 得意先クラス→画面格納処理
                this.SetDisplayFormCustomerInfo( this._customerInfo );
            }

            // 画面→得意先クラス格納処理
            this.GetDisplayDataToCustomerInfo( ref this._customerInfo );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2208.04.30 m.suzuki
            //// 画面→得意先クラス格納処理（家族情報Ｔａｂ）
            //if (this.SubInfo_UTabControl.ActiveTab.Key == "SubInfo3")
            //{
            //    this._subInfo3_Form.GetDisplayDataToCustomerInfo(ref this._customerInfo);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2208.04.30 m.suzuki

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 更新後の表示変更（内容を引き継いで新規作成モードにする）

            CustomerInfo customerInfoBuff = _customerInfo.Clone();
            customerInfoBuff.UpdateDateTime = DateTime.MinValue;
            customerInfoBuff.CustomerCode = 0;

            // StaticMemory初期化情報保存処理
            //this._customerInputAcs.InitialStaticMemory(
            //this._customerInfoAcs.WriteInitStaticMemory( mode, customerInfoBuff );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            return 0;
        }
        # endregion

        # region [共通処理]
        /// <summary>
        /// コントロールフォーカス設定処理
        /// </summary>
        /// <param name="ddID">ＤＤ名称</param>
        /// <returns>true:設定完了 false:設定不要</returns>
        /// <br>UpdateNote : 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        public bool SetFocus( string ddID )
        {
            bool setting = false;

            switch ( ddID )
            {
                // 得意先コード
                case "CustomerCode":
                    {
                        if ( this.tNedit_CustomerCode.Enabled )
                        {
                            this.tNedit_CustomerCode.Focus();
                            this.ActiveControl = this.tNedit_CustomerCode;
                            setting = true;
                        }
                        else
                        {
                            this.tEdit_CustomerSubCode.Focus();
                            this.ActiveControl = this.tEdit_CustomerSubCode;
                            setting = true;
                        }

                        break;
                    }
                // 得意先名称
                case "Name":
                    {
                        this.tEdit_Name.Focus();
                        setting = true;

                        break;
                    }
                // カナ
                case "Kana":
                    {
                        this.tEdit_Kana.Focus();
                        setting = true;

                        break;
                    }
                // 請求先
                case "ClaimCode":
                    {
                        this.tNedit_ClaimCode.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                // 請求先
                case "ClaimName":
                    {
                        //this.ClaimName1_TEdit.Focus();
                        this.tNedit_ClaimCode.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                // 締日
                case "TotalDay":
                    {
                        this.tNedit_TotalDay.Focus();
                        setting = true;

                        break;
                    }
                // 集金日
                case "CollectMoneyDay":
                    {
                        this.tNedit_CollectMoneyDay.Focus();
                        setting = true;

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                // 次回勘定開始日
                case "NTimeCalcStDate":
                    {
                        this.tNedit_NTimeCalcStDate.Focus();
                        setting = true;

                        break;
                    }
                // 単価端数処理
                case "SalesUnPrcFrcProcCd":
                    {
                        this.tNedit_SalesUnPrcFrcProcCd.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                // 金額端数処理
                case "SalesMoneyFrcProcCd":
                    {
                        this.tNedit_SalesMoneyFrcProcCd.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                // 消費税端数処理
                case "SalesCnsTaxFrcProcCd":
                    {
                        this.tNedit_SalesCnsTaxFrcProcCd.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }

                // ADD 2008/12/05 不具合対応[8740] ---------->>>>>
                case "CustomerSnm":
                    {
                        this.tEdit_CustomerSnm.Focus();
                        setting = true;

                        break;
                    }
                case "ClaimSectionCode":
                    {
                        this.tEdit_MngSectionNm.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                case "MngSectionCode":
                    {
                        this.tEdit_ClaimSectionCode.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                case "CustWarehouseCd":
                    {
                        this.tEdit_CustWarehouseCd.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                // ADD 2008/12/05 不具合対応[8740] ----------<<<<<
                // ADD 2008/12/26 不具合対応[9531] ---------->>>>>
                case "AccRecDivCd":
                    {
                        this.tComboEditor_AccRecDivCd.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        this._preComboEditorValue = this.tComboEditor_AccRecDivCd.Value;
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;

                        break;
                    }
                // ADD 2008/12/26 不具合対応[9531] ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                case "CustomerAgentCd":
                    {
                        this.tEdit_CustomerAgentNm.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;
                        break;
                    }
                case "OldCustomerAgentCd":
                    {
                        this.tEdit_OldCustomerAgentNm.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;
                        break;
                    }
                case "BillCollecterCd":
                    {
                        this.tEdit_BillCollecterNm.Focus();
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        if (this.SetGuideEnabled != null)
                        {
                            this.SetGuideEnabled(true);
                        }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        setting = true;
                        break;
                    }
                // ADD 2009/06/03 ------>>>
                case "CustomerEpCode":
                    {
                        this.tEdit_CustomerEpCode.Focus();
                        setting = true;
                        break;
                    }
                case "CustomerSecCode":
                    {
                        this.tEdit_CustomerSecCode.Focus();
                        setting = true;
                        break;
                    }
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                case "SimplInqAcntAcntGrId":
                    {
                        this.tEdit_SimplInqAcntAcntGrId.Focus();
                        setting = true;
                        break;
                    }
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
                // ADD 2009/06/03 ------<<<
                // 初期フォーカス位置
                case "":
                    {
                        if ( this.tNedit_CustomerCode.Enabled )
                        {
                            this.tNedit_CustomerCode.Focus();
                            this.ActiveControl = this.tNedit_CustomerCode;
                            setting = true;
                        }
                        else
                        {
                            this.tEdit_CustomerSubCode.Focus();
                            this.ActiveControl = this.tEdit_CustomerSubCode;
                            setting = true;
                        }

                        break;
                    }
            }

            this._prevControl = this.ActiveControl;
            return setting;
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultValue"></param>
        private int StrToIntDef( string text, int defaultValue )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return defaultValue;
            }
        }

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// コードからの選択を可能へ変更する
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Note	   : コードからの選択を可能へ変更する</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (control.Value != null)
                {
                    if (item.Tag.ToString().Equals(control.Value.ToString()))
                    {
                        inputErrorFlg = false;
                        break;
                    }
                }
            }

            switch (name)
            {
                case "tComboEditor_CustomerAttributeDiv":
                case "tComboEditor_OnlineKindDiv":
                case "tComboEditor_MailAddrKindCode1":
                case "tComboEditor_MailAddrKindCode2":
                    {
                        if (!this.comboInputFlg)
                        {
                            foreach (Infragistics.Win.ValueListItem item in control.Items)
                            {
                                if (control.Value != null)
                                {
                                    if (item.DataValue == control.Value)
                                    {
                                        inputErrorFlg = false;
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                default:
                    break;
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                switch (name)
                {
                    case "tComboEditor_CustomerAttributeDiv":
                        {
                            if ("1".Equals(control.Value.ToString()))
                            {
                                control.Value = 8;
                            }
                            else if ("2".Equals(control.Value.ToString()))
                            {
                                control.Value = 9;
                            }
                            break;
                        }
                    case "tComboEditor_OnlineKindDiv":
                        {
                            if ("1".Equals(control.Value.ToString()))
                            {
                                control.Value = 10;
                            }
                            break;
                        }
                    case "tComboEditor_MailAddrKindCode1":
                    case "tComboEditor_MailAddrKindCode2":
                        {
                            if ("4".Equals(control.Value.ToString()))
                            {
                                control.Value = 99;
                            }
                            break;
                        }
                }
                this._preComboEditorValue = control.Value;
            }
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
        /// <summary>
        /// 得意先コード再設定処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <remarks>
        /// <br>NSユーザー改良要望一覧連番265の対応</br>
        /// <br>Note	   : 得意先コード再設定を行う</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/04</br>
        /// <br>UpdateNote : 2011/12/05 yangmj</br>
        /// <br>             redmine#8413の対応</br>
        /// </remarks>
        public void SetCustomerCode(int customerCode)
        {
            if (customerCode != 0)
            {
                this.tNedit_CustomerCode.Focus();
                this.tNedit_CustomerCode.DataText =  customerCode.ToString().PadLeft(8,'0');
                //this.tNedit_CustomerCode.SelectionStart = this.tNedit_CustomerCode.Text.Length;//DEL 2011/12/05 YANGMJ REDMINE#8413
            }
        }
        // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
        # endregion

        // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <br>UpdateNote : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        public void Renewal()
        {
            int prevComboIndex;

            CustomerInputAcs._userGdBdListStc = null;

            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //ArrayList retList = null;
            // --- DEL 2010/08/10 ------------------------------------<<<<<

            // ユーザーガイドマスタボディ部リスト取得処理
            int status = this._customerInputAcs.GetUserGdBdListToStatic();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2010/08/10 ------------------------------------>>>>>
                //// 職種（ユーザーガイドマスタより取得）
                //status = this._customerInputAcs.GetDivCodeBodyList(34, out retList);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    retList.Sort();

                //    prevComboIndex = (int)this.tComboEditor_JobTypeCode.Value;

                //    this.tComboEditor_JobTypeCode.Items.Clear();

                //    ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_JobTypeCode, 0, " ", 0);
                //    int count = 1;
                //    foreach (ComboEditorItemCustomer ci in retList)
                //    {
                //        count++;
                //        // --- DEL 2010/08/10 ------------------------------------>>>>>
                //        //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_JobTypeCode, ci.Code, ci.Name, count );
                //        // --- DEL 2010/08/10 ------------------------------------<<<<<
                //        // --- ADD 2010/08/10 ------------------------------------>>>>>
                //        ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_JobTypeCode, ci.Code, "000" + ci.Code + ":" + ci.Name, count - 1);
                //        // --- ADD 2010/08/10 ------------------------------------<<<<<
                //    }

                //    this.tComboEditor_JobTypeCode.Value = prevComboIndex;
                //}

                //// 業種（ユーザーガイドマスタより取得）
                //status = this._customerInputAcs.GetDivCodeBodyList(33, out retList);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    retList.Sort();

                //    prevComboIndex = (int)this.tComboEditor_BusinessTypeCode.Value;

                //    this.tComboEditor_BusinessTypeCode.Items.Clear();

                //    ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_BusinessTypeCode, 0, " ", 0);
                //    int count = 1;
                //    foreach (ComboEditorItemCustomer ci in retList)
                //    {
                //        count++;
                //        // --- DEL 2010/08/10 ------------------------------------>>>>>
                //        //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_BusinessTypeCode, ci.Code, ci.Name, count );
                //        // --- DEL 2010/08/10 ------------------------------------<<<<<
                //        // --- ADD 2010/08/10 ------------------------------------>>>>>
                //        ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_BusinessTypeCode, ci.Code, "000" + ci.Code + ":" + ci.Name, count - 1);
                //        // --- ADD 2010/08/10 ------------------------------------<<<<<
                //    }

                //    this.tComboEditor_BusinessTypeCode.Value = prevComboIndex;
                //}

                //// 販売エリア（ユーザーガイドマスタより取得）
                //status = this._customerInputAcs.GetDivCodeBodyList(21, out retList);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    retList.Sort();

                //    prevComboIndex = (int)this.tComboEditor_SalesAreaCode.Value;

                //    this.tComboEditor_SalesAreaCode.Items.Clear();

                //    ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesAreaCode, 0, " ", 0);
                //    int count = 1;
                //    foreach (ComboEditorItemCustomer ci in retList)
                //    {
                //        count++;
                //        // --- DEL 2010/08/10 ------------------------------------>>>>>
                //        //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_SalesAreaCode, ci.Code, ci.Name, count );
                //        // --- DEL 2010/08/10 ------------------------------------<<<<<
                //        // --- ADD 2010/08/10 ------------------------------------>>>>>
                //        ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesAreaCode, ci.Code, "000" + ci.Code + ":" + ci.Name, count - 1);
                //        // --- ADD 2010/08/10 ------------------------------------<<<<<
                //    }

                //    this.tComboEditor_SalesAreaCode.Value = prevComboIndex;
                //}
                // --- DEL 2010/08/10 ------------------------------------<<<<<

                // 回収条件
                this._depositStAcs = new DepositStAcs();
                this._moneyKindAcs = new MoneyKindAcs();

                ReadDepositSt(out this._depositSt);
                ReadMoneyKind(out this._moneyKindDic);

                if (this.tComboEditor_CollectCond.Value != null)
                {
                    prevComboIndex = (int)this.tComboEditor_CollectCond.Value;
                }
                else
                {
                    prevComboIndex = -1;
                }

                this.tComboEditor_CollectCond.Items.Clear();
                // --- DEL 2010/08/10 ------------------------------------>>>>>
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd1))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd1, this._moneyKindDic[this._depositSt.DepositStKindCd1].MoneyKindName, 1);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd2))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd2, this._moneyKindDic[this._depositSt.DepositStKindCd2].MoneyKindName, 2);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd3))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd3, this._moneyKindDic[this._depositSt.DepositStKindCd3].MoneyKindName, 3);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd4))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd4, this._moneyKindDic[this._depositSt.DepositStKindCd4].MoneyKindName, 4);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd5))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd5, this._moneyKindDic[this._depositSt.DepositStKindCd5].MoneyKindName, 5);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd6))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd6, this._moneyKindDic[this._depositSt.DepositStKindCd6].MoneyKindName, 6);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd7))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd7, this._moneyKindDic[this._depositSt.DepositStKindCd7].MoneyKindName, 7);
                //}
                //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd8))
                //{
                //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd8, this._moneyKindDic[this._depositSt.DepositStKindCd8].MoneyKindName, 8);
                //}
                // --- DEL 2010/08/10 ------------------------------------<<<<<
                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd1))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd1, this._depositSt.DepositStKindCd1 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd1].MoneyKindName, 1);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd2))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd2, this._depositSt.DepositStKindCd2 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd2].MoneyKindName, 2);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd3))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd3, this._depositSt.DepositStKindCd3 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd3].MoneyKindName, 3);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd4))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd4, this._depositSt.DepositStKindCd4 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd4].MoneyKindName, 4);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd5))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd5, this._depositSt.DepositStKindCd5 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd5].MoneyKindName, 5);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd6))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd6, this._depositSt.DepositStKindCd6 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd6].MoneyKindName, 6);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd7))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd7, this._depositSt.DepositStKindCd7 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd7].MoneyKindName, 7);
                }
                if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd8))
                {
                    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd8, this._depositSt.DepositStKindCd8 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd8].MoneyKindName, 8);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
                this.tComboEditor_CollectCond.Value = prevComboIndex;
            }

            this._customerInputAcs._salesProcMoneyCdList = null;

            this.uLabel_HomeTelNoDspName.Text = this._alItmDspNmAcs.GetMainContactDspName(0);
            this.uLabel_OfficeTelNoDspName.Text = this._alItmDspNmAcs.GetMainContactDspName(1);
            this.uLabel_MobileTelNoDspName.Text = this._alItmDspNmAcs.GetMainContactDspName(2);
            this.uLabel_HomeFaxNoDspName.Text = this._alItmDspNmAcs.GetMainContactDspName(3);
            this.uLabel_OfficeFaxNoDspName.Text = this._alItmDspNmAcs.GetMainContactDspName(4);
            this.uLabel_OtherTelNoDspName.Text = this._alItmDspNmAcs.GetMainContactDspName(5);

            // 主連絡先
            if (this.tComboEditor_MainContactCode.Value != null)
            {
                prevComboIndex = (int)this.tComboEditor_MainContactCode.Value;
            }
            else
            {
                prevComboIndex = -1;
            }

            this.tComboEditor_MainContactCode.Items.Clear();
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 0, this._alItmDspNmAcs.GetMainContactDspName(0), 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 1, this._alItmDspNmAcs.GetMainContactDspName(1), 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 2, this._alItmDspNmAcs.GetMainContactDspName(2), 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 3, this._alItmDspNmAcs.GetMainContactDspName(3), 4);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 4, this._alItmDspNmAcs.GetMainContactDspName(4), 5);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 5, this._alItmDspNmAcs.GetMainContactDspName(5), 6);
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 0, "0:" + this._alItmDspNmAcs.GetMainContactDspName(0), 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 1, "1:" + this._alItmDspNmAcs.GetMainContactDspName(1), 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 2, "2:" + this._alItmDspNmAcs.GetMainContactDspName(2), 3);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 3, "3:" + this._alItmDspNmAcs.GetMainContactDspName(3), 4);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 4, "4:" + this._alItmDspNmAcs.GetMainContactDspName(4), 5);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 5, "5:" + this._alItmDspNmAcs.GetMainContactDspName(5), 6);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            this.tComboEditor_MainContactCode.Value = prevComboIndex;

            TMsgDisp.Show(this,
                          emErrorLevel.ERR_LEVEL_INFO,
                          "PMKHN09010U",
                          "最新情報を取得しました。",
                          0,
                          MessageBoxButtons.OK);
        }
        // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<

        /// <summary>
        /// 選択コード変更後発生イベント
        /// </summary>
        public event EventHandler SelectCodeChanged;

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        // --- DEL 梶谷貴士 2010/08/10 ------------------------------->>>>>
        /// <summary>
        /// データ登録時発生イベント
        /// </summary>
        //public event DataSaveEventHandler DataSave;
        // --- DEL 梶谷貴士 2010/08/10 -------------------------------<<<<<

        /// <summary>
        /// ガイド（F5）表示用イベント
        /// </summary>
        public event SetGuideEnableEventHandler SetGuideEnabled;
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        // ===================================================================================== //
        // デリゲート用メソッド
        // ===================================================================================== //
        # region Delegate Method
        /// <summary>
        /// 最上位親フォームサイズ変更イベント用メソッド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ParentTopForm_SizeChanged( object sender, System.EventArgs e )
        {
            if ( this._parentTopForm == null )
            {
                return;
            }

            this._style = Convert.ToInt32( this.uButton_StyleChange.Tag );

            switch ( _customerInputConstructionAcs.InputType )
            {
                case CustomerInputConstructionAcs.INPUT_TYPE_SCROLL:
                    {
                        if ( this._style == STYLE_SCROLL )
                        {
                            this.Container_Panel.Height = this._parentTopForm.Height - 130;
                            return;
                        }
                        else
                        {
                            this.Container_Panel.Height = this._parentTopForm.Height - 130;
                            this._style = STYLE_SCROLL;
                            this.uButton_StyleChange.Tag = this._style;
                        }

                        break;
                    }
                case CustomerInputConstructionAcs.INPUT_TYPE_TAB:
                    {
                        if ( this._style == STYLE_TAB )
                        {
                            return;
                        }
                        else
                        {
                            this.Container_Panel.Height = this._parentTopForm.Height - 130;
                            this._style = STYLE_TAB;
                            this.uButton_StyleChange.Tag = this._style;
                        }

                        break;
                    }
                case CustomerInputConstructionAcs.INPUT_TYPE_AUTO:
                    {
                        this.Container_Panel.Height = this._parentTopForm.Height - 130;

                        if ( this.Container_Panel.Height > 650 )
                        {
                            if ( this._style != STYLE_SCROLL )
                            {
                                this._style = STYLE_SCROLL;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if ( this._style != STYLE_TAB )
                            {
                                this._style = STYLE_TAB;
                            }
                            else
                            {
                                return;
                            }
                        }

                        this.uButton_StyleChange.Tag = this._style;

                        break;
                    }
            }

            // 入力スタイル変更処理
            this.InputStyleChange( this._style );
        }
        # endregion

        /// <summary>
        /// 拠点コード転送イベント
        /// </summary>
        public event CustomerCarSectionCodeTransmitEventHandler TransmitMngSectionCode;

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>キープロパティ</summary>
        public string Key
        {
            get
            {
                return this._key;
            }
        }
        /// <summary>
        /// 自拠点コードプロパティ
        /// </summary>
        public string OwnSectionCode
        {
            get
            {
                return this._ownSectionCode;
            }
            set
            {
                this._ownSectionCode = value;
            }
        }

        /// <summary>
        /// 管理拠点コードプロパティ
        /// </summary>
        public string MngSectionCode
        {
            get
            {
                return this._mngSectionCode;
            }
            set
            {
                this._mngSectionCode = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Method
        /// <summary>
        /// Static情報保存処理
        /// </summary>
        internal void SaveStaticMemoryData()
        {
            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        private int ReadDepositSt(out DepositSt depositSt)
        {
            depositSt = new DepositSt();
            int status = this._depositStAcs.Read(out depositSt, this._enterpriseCode, 0);

            return (status);
        }

        /// <summary>
        /// 金額種別設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 金額種別設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        private int ReadMoneyKind(out Dictionary<int, MoneyKind> moneyKindDic)
        {
            moneyKindDic = new Dictionary<int, MoneyKind>();

            int status;
            ArrayList retList = new ArrayList();

            status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (MoneyKind moneyKind in retList)
                {
                    // 金額設定区分が「0:入金」を使用
                    if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                    {
                        moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }
            }

            return (status);
        }
        // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 画面初期処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面起動時の初期処理を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
        private void InitialDisplay()
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin( this );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
            //# region 桁数設定
            //this.tEdit_CustomerSubCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, true, false, true, true, true ) );
            //this.tEdit_Name.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, false, true, true, true ) );
            //this.tEdit_Name2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, false, true, true, true ) );
            //this.tEdit_Kana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, false, true, true, true ) );
            //this.tEdit_PostNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_Address1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, false, true, true, true ) );
            //this.tNedit_Address2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_Address2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tEdit_Address3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, false, true, true, true ) );
            //this.tEdit_Address4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, false, true, true, true ) );
            //this.tEdit_HomeTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_OfficeTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_PortableTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_OthersTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_HomeFaxNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_OfficeFaxNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tEdit_SearchTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_TotalDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_TotalDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CollectMoneyDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CollectMoneyDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CustAnalysCode1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CustAnalysCode1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CustAnalysCode2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CustAnalysCode2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CustAnalysCode3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CustAnalysCode3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CustAnalysCode4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CustAnalysCode4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CustAnalysCode5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CustAnalysCode5.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //this.tNedit_CustAnalysCode6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars( false, false, false, false, false, true, true ) );
            //this.tNedit_CustAnalysCode6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit( false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF );
            //# endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL

            # region イメージの取り込み
            //----------------------------------------------------
            // イメージの取り込み
            //----------------------------------------------------
            // ガイドボタン用イメージindex
            int index = (int)Size16_Index.STAR1;

            // ガイドボタン
            UltraButton[] guideButtons = new UltraButton[]
                {
                    uButton_MngSectionNmGuide,          // 管理拠点
                    uButton_CustomerAgentNmGuide,       // 得意先担当者
                    uButton_OldCustomerAgentNmGuide,    // 旧得意先担当者
                    uButton_BillCollecterNmGuide,       // 集金担当者
                    uButton_CustWarehouseGuide,         // 得意先優先倉庫
                    uButton_ClaimSectionGuide,          // 請求拠点
                    uButton_ClaimNameGuide,             // 請求先
                    uButton_SalesUnPrcFrcProcCdGuide,   // 単価端数処理
                    uButton_SalesMoneyFrcProcCdGuide,   // 金額端数処理
                    uButton_SalesCnsTaxFrcProcCdGuide,  // 消費税端数処理
                    uButton_AddressGuide,               // 住所
                    uButton_Note1Guide,                 // 備考１
                    uButton_Note2Guide,                 // 備考２
                    uButton_Note3Guide,                 // 備考３
                    uButton_Note4Guide,                 // 備考４
                    uButton_Note5Guide,                 // 備考５
                    uButton_Note6Guide,                 // 備考６
                    uButton_Note7Guide,                 // 備考７
                    uButton_Note8Guide,                 // 備考８
                    uButton_Note9Guide,                 // 備考９
                    uButton_Note10Guide,                // 備考１０
                    uButton_BusinessTypeCdGuide,        // 業種
                    uButton_JobTypeCodeGuide,           // 職種
                    uButton_SalesAreaCdGuide            // 地区
                };
            foreach ( UltraButton guideButton in guideButtons )
            {
                guideButton.ImageList = this._imageList16;
                guideButton.Appearance.Image = IconResourceManagement.ImageList16.Images[index];
            }

            // 分類タイトル
            this.uLabel_CustomerNameTitle.ImageList = this._imageList16;
            this.uLabel_CustomerClaimTitle.ImageList = this._imageList16;
            this.uLabel_CustomerDetailsTitle.ImageList = this._imageList16;

            this.uLabel_CustomerNameTitle.Appearance.Image = (int)Size16_Index.CUSTOMER;
            this.uLabel_CustomerClaimTitle.Appearance.Image = (int)Size16_Index.CLAIM;
            this.uLabel_CustomerDetailsTitle.Appearance.Image = (int)Size16_Index.DETAILS;

            // タブ
            this.SubInfo_UTabControl.ImageList = this._imageList16;
            this.SubInfo_UTabControl.Tabs[SUBINFO_KEY0].Appearance.Image = (int)Size16_Index.MAIN;
            this.SubInfo_UTabControl.Tabs[SUBINFO_KEY2].Appearance.Image = (int)Size16_Index.CUSTOMERNOTE;
            this.SubInfo_UTabControl.Tabs[SUBINFO_KEY4].Appearance.Image = (int)Size16_Index.MAIL;
            this.SubInfo_UTabControl.Tabs[SUBINFO_KEY5].Appearance.Image = (int)Size16_Index.REGISTRATIONNOMINEE;
            this.SubInfo_UTabControl.Tabs[SUBINFO_KEY6].Appearance.Image = (int)Size16_Index.PRINT;
            this.SubInfo_UTabControl.Tabs[SUBINFO_KEY7].Appearance.Image = (int)Size16_Index.BLOUZER;   // ADD 2009/06/03

            // タブ展開用ラベルタイトル
            this.uLabel_SubInfo0Title.ImageList = this._imageList16;
            this.uLabel_SubInfo2Title.ImageList = this._imageList16;
            this.uLabel_SubInfo4Title.ImageList = this._imageList16;
            this.uLabel_SubInfo5Title.ImageList = this._imageList16;
            this.uLabel_SubInfo6Title.ImageList = this._imageList16;
            this.uLabel_SubInfo7Title.ImageList = this._imageList16;    // ADD 2009/06/03

            this.uLabel_SubInfo0Title.Appearance.Image = (int)Size16_Index.MAIN;
            this.uLabel_SubInfo2Title.Appearance.Image = (int)Size16_Index.CUSTOMERNOTE;
            this.uLabel_SubInfo4Title.Appearance.Image = (int)Size16_Index.MAIL;
            this.uLabel_SubInfo5Title.Appearance.Image = (int)Size16_Index.REGISTRATIONNOMINEE;
            this.uLabel_SubInfo6Title.Appearance.Image = (int)Size16_Index.PRINT;
            this.uLabel_SubInfo7Title.Appearance.Image = (int)Size16_Index.BLOUZER; // ADD 2009/06/03

            # endregion

            # region タイトル用ラベルカラー設定
            CustomUltraGridAppearance gridAppearance = this._controlScreenSkin.GetGridAppearance();
            if ( gridAppearance != null )
            {
                UltraLabel[] uLabels = new UltraLabel[]
                    {
                        uLabel_CustomerNameTitle,
                        uLabel_CustomerClaimTitle,
                        uLabel_CustomerDetailsTitle,
                        uLabel_SubInfo0Title, 
                        uLabel_SubInfo2Title, 
                        uLabel_SubInfo4Title, 
                        uLabel_SubInfo5Title, 
                        uLabel_SubInfo6Title 
                    };
                foreach ( UltraLabel uLabel in uLabels )
                {
                    uLabel.Appearance.BackColor = gridAppearance.GridHeaderAppearance.BackColor;
                    uLabel.Appearance.BackColor2 = gridAppearance.GridHeaderAppearance.BackColor2;
                    uLabel.Appearance.BackGradientStyle = gridAppearance.GridHeaderAppearance.BackGradientStyle;
                    uLabel.Appearance.ForeColor = gridAppearance.GridHeaderAppearance.ForeColor;
                }
            }
            # endregion

            # region 備考ガイドTag設定
            this.uButton_Note1Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE1;
            this.uButton_Note2Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE2;
            this.uButton_Note3Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE3;
            this.uButton_Note4Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE4;
            this.uButton_Note5Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE5;
            this.uButton_Note6Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE6;
            this.uButton_Note7Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE7;
            this.uButton_Note8Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE8;
            this.uButton_Note9Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE9;
            this.uButton_Note10Guide.Tag = CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE10;
            # endregion

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 備考ガイドマスタヘッダ部リスト取得処理
            status = this._customerInputAcs.GetNoteGuideHdListToStatic();

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                this.uLabel_Note1Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE1 );
                this.uLabel_Note2Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE2 );
                this.uLabel_Note3Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE3 );
                this.uLabel_Note4Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE4 );
                this.uLabel_Note5Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE5 );
                this.uLabel_Note6Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE6 );
                this.uLabel_Note7Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE7 );
                this.uLabel_Note8Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE8 );
                this.uLabel_Note9Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE9 );
                this.uLabel_Note10Title.Text = this._customerInputAcs.GetNoteGuideHd( (int)CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE10 );

                this.toolTip1.SetToolTip( this.uButton_Note1Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note2Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note3Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note4Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note5Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note6Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note7Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note8Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note9Guide, "備考ガイド" );
                this.toolTip1.SetToolTip( this.uButton_Note10Guide, "備考ガイド" );
            }
            else if ( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            {
                //
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "ユーザーガイド（ヘッダ）情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK );
            }

            // コンボエディタアイテム設定処理
            this.SetComboEditorItem();

            // 全体初期値設定マスタ取得処理
            this._custCdAutoNumbering = this._customerInputAcs.GetCustCdAutoNumbering( this._enterpriseCode, this._loginSectionCode );


            // 入力スタイル変更処理
            this.ParentTopForm_SizeChanged( this, new EventArgs() );

            // 入力スタイル変更処理
            this.InputStyleChange( Convert.ToInt32( this.uButton_StyleChange.Tag ) );

            // TabControl初期設定
            if ( this.SubInfo_UTabControl.Visible )
            {
                this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY0];
                this.SubInfo_UTabControl.SelectedTab = this.SubInfo_UTabControl.ActiveTab;
            }
        }

        /// <summary>
        /// コントロールEnabled変更リスト（オフラインモード用）生成処理
        /// </summary>
        private void ControlEnabledListCreate()
        {
            this._offLineControlEnabledList = new ArrayList();
            this._offLineControlEnabledList.Add( this.uButton_AddressGuide );
            this._offLineControlEnabledList.Add( this.uButton_ClaimNameGuide );
            this._offLineControlEnabledList.Add( this.uButton_CustomerAgentNmGuide );
            this._offLineControlEnabledList.Add( this.uButton_OldCustomerAgentNmGuide );
            this._offLineControlEnabledList.Add( this.uButton_BillCollecterNmGuide );
            this._offLineControlEnabledList.Add( this.uButton_Note1Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note2Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note3Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note4Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note5Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note6Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note7Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note8Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note9Guide );
            this._offLineControlEnabledList.Add( this.uButton_Note10Guide );
        }

        /// <summary>
        /// オフラインモード時コントロールEnabled変更処理
        /// </summary>
        private void OfflineModeControlEnableChange()
        {
            if ( this._offLineControlEnabledList == null ) return;
            //if ( LoginInfoAcquisition.OnlineFlag ) return; // 2009/07/30

            for ( int i = 0; i < this._offLineControlEnabledList.Count; i++ )
            {
                if ( this._offLineControlEnabledList[i] is Infragistics.Win.Misc.UltraButton )
                {
                    ((Infragistics.Win.Misc.UltraButton)this._offLineControlEnabledList[i]).Enabled = false;
                }
            }
        }

        /// <summary>
        /// コンボエディタアイテム設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 各コンボエディタにアイテムを設定します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>UpdateNote : 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        /// </remarks>
        private void SetComboEditorItem()
        {
            int status;
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //ArrayList retList = null;

            //# region [コンボアイテム（固定値）]
            // 敬称
            //this.tComboEditor_HonorificTitle.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_HonorificTitle, 0, CustomerInfo.CST_HonorificTitle_0, 1 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_HonorificTitle, 1, CustomerInfo.CST_HonorificTitle_1, 2 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_HonorificTitle, 2, CustomerInfo.CST_HonorificTitle_2, 3 );

            // 諸口
            //this.tComboEditor_OutputNameCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 0, CustomerInfo.CST_OutputName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 1, CustomerInfo.CST_OutputName_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 2, CustomerInfo.CST_OutputName_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 3, CustomerInfo.CST_OutputName_3, 4);

            // 集金月
            //this.tComboEditor_CollectMoneyCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 0, CustomerInfo.CST_CollectMoneyName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 1, CustomerInfo.CST_CollectMoneyName_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 2, CustomerInfo.CST_CollectMoneyName_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 3, CustomerInfo.CST_CollectMoneyName_3, 4);

            // 回収条件
            //this.tComboEditor_CollectCond.Items.Clear();
            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 10, CustomerInfo.CST_CollectCond_10, 1 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 20, CustomerInfo.CST_CollectCond_20, 2 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 30, CustomerInfo.CST_CollectCond_30, 3 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 40, CustomerInfo.CST_CollectCond_40, 4 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 50, CustomerInfo.CST_CollectCond_50, 5 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 60, CustomerInfo.CST_CollectCond_60, 6 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 70, CustomerInfo.CST_CollectCond_70, 7 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_CollectCond, 80, CustomerInfo.CST_CollectCond_80, 8 );

            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd1))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd1, this._moneyKindDic[this._depositSt.DepositStKindCd1].MoneyKindName, 1);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd2))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd2, this._moneyKindDic[this._depositSt.DepositStKindCd2].MoneyKindName, 2);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd3))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd3, this._moneyKindDic[this._depositSt.DepositStKindCd3].MoneyKindName, 3);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd4))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd4, this._moneyKindDic[this._depositSt.DepositStKindCd4].MoneyKindName, 4);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd5))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd5, this._moneyKindDic[this._depositSt.DepositStKindCd5].MoneyKindName, 5);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd6))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd6, this._moneyKindDic[this._depositSt.DepositStKindCd6].MoneyKindName, 6);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd7))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd7, this._moneyKindDic[this._depositSt.DepositStKindCd7].MoneyKindName, 7);
            //}
            //if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd8))
            //{
            //    ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd8, this._moneyKindDic[this._depositSt.DepositStKindCd8].MoneyKindName, 8);
            //}
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<

            // 与信管理区分
            //this.tComboEditor_CreditMngCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CreditMngCode, 0, CustomerInfo.CST_CreditMngCode_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CreditMngCode, 1, CustomerInfo.CST_CreditMngCode_1, 2);

            // 入金消込区分
            //this.tComboEditor_DepoDelCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DepoDelCode, 0, CustomerInfo.CST_DepoDelCode_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DepoDelCode, 1, CustomerInfo.CST_DepoDelCode_1, 2);

            // 売掛区分
            //this.tComboEditor_AccRecDivCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AccRecDivCd, 0, CustomerInfo.CST_AccRecDivCd_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AccRecDivCd, 1, CustomerInfo.CST_AccRecDivCd_1, 2);

            // 相手伝票番号管理区分
            //this.tComboEditor_CustSlipNoMngCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustSlipNoMngCd, 0, CustomerInfo.CST_CustSlipNoMngCd_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustSlipNoMngCd, 1, CustomerInfo.CST_CustSlipNoMngCd_1, 2);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustSlipNoMngCd, 2, CustomerInfo.CST_CustSlipNoMngCd_2, 3);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
            // 純正区分
            //this.tComboEditor_PureCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_PureCode, 0, CustomerInfo.CST_PureCode_0, 1 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_PureCode, 1, CustomerInfo.CST_PureCode_1, 2 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL

            // 得意先属性区分
            //this.tComboEditor_CustomerAttributeDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerAttributeDiv, 0, CustomerInfo.CST_CustomerAttributeDiv_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerAttributeDiv, 8, CustomerInfo.CST_CustomerAttributeDiv_8, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerAttributeDiv, 9, CustomerInfo.CST_CustomerAttributeDiv_9, 3);

            // 得意先種別区分
            //this.tComboEditor_CustomerDivCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerDivCd, 0, CustomerInfo.CST_CustomerDivCd_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerDivCd, 1, CustomerInfo.CST_CustomerDivCd_1, 1);

            // 得意先伝票番号区分
            //this.tComboEditor_CustomerSlipNoDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 0, CustomerInfo.CST_CustomerSlipNoDiv_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 1, CustomerInfo.CST_CustomerSlipNoDiv_1, 2);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 2, CustomerInfo.CST_CustomerSlipNoDiv_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 3, CustomerInfo.CST_CustomerSlipNoDiv_3, 4);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD

            // 消費税転嫁方式
            //this.tComboEditor_ConsTaxLayMethod.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 0, CustomerInfo.CST_ConsTaxLayMethod_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 1, CustomerInfo.CST_ConsTaxLayMethod_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 2, CustomerInfo.CST_ConsTaxLayMethod_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 3, CustomerInfo.CST_ConsTaxLayMethod_3, 4);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 9, CustomerInfo.CST_ConsTaxLayMethod_9, 5);

            // 消費税転嫁方式参照区分
            //this.tComboEditor_CustCTaXLayRefCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustCTaXLayRefCd, 0, CustomerInfo.CST_CustCTaXLayRefCd_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustCTaXLayRefCd, 1, CustomerInfo.CST_CustCTaXLayRefCd_1, 2);

            ///* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            // 総額表示方法区分
            //this.tComboEditor_TotalAmountDispWayCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_TotalAmountDispWayCd, 0, CustomerInfo.CST_TotalAmountDispWayCd_0, 1 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_TotalAmountDispWayCd, 1, CustomerInfo.CST_TotalAmountDispWayCd_1, 2 );

            // 総額表示方法参照区分
            //this.tComboEditor_TotalAmntDspWayRef.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_TotalAmntDspWayRef, 0, CustomerInfo.CST_TotalAmntDspWayRef_0, 1 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_TotalAmntDspWayRef, 1, CustomerInfo.CST_TotalAmntDspWayRef_1, 2 );
            //   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

            // 個人・法人
            //this.tComboEditor_CorporateDivCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 0, CustomerInfo.CST_CorporateDivName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 1, CustomerInfo.CST_CorporateDivName_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 2, CustomerInfo.CST_CorporateDivName_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 3, CustomerInfo.CST_CorporateDivName_3, 4);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 4, CustomerInfo.CST_CorporateDivName_4, 5);

            // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
            // 請求書出力
            //this.tComboEditor_BillOutputCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_BillOutputCode, 0, CustomerInfo.CST_BillOutputName_0, 1 );
            //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_BillOutputCode, 1, CustomerInfo.CST_BillOutputName_1, 2 );
            // --- DEL  大矢睦美  2010/01/04 ----------<<<<<

            // ＤＭ出力
            //this.tComboEditor_DmOutCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DmOutCode, 0, CustomerInfo.CST_BillOutputName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DmOutCode, 1, CustomerInfo.CST_BillOutputName_1, 2);

            // 主連絡先
            //this.tComboEditor_MainContactCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 0, this._alItmDspNmAcs.GetMainContactDspName(0), 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 1, this._alItmDspNmAcs.GetMainContactDspName(1), 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 2, this._alItmDspNmAcs.GetMainContactDspName(2), 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 3, this._alItmDspNmAcs.GetMainContactDspName(3), 4);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 4, this._alItmDspNmAcs.GetMainContactDspName(4), 5);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 5, this._alItmDspNmAcs.GetMainContactDspName(5), 6);

            // メール送信区分
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode1, 0, CustomerInfo.CST_MailSendName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode1, 1, CustomerInfo.CST_MailSendName_1, 2);

            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode2, 0, CustomerInfo.CST_MailSendName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode2, 1, CustomerInfo.CST_MailSendName_1, 2);

            // メールアドレス種別
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 0, CustomerInfo.CST_MailAddrKindName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 1, CustomerInfo.CST_MailAddrKindName_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 2, CustomerInfo.CST_MailAddrKindName_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 3, CustomerInfo.CST_MailAddrKindName_3, 4);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 99, CustomerInfo.CST_MailAddrKindName_99, 5);

            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 0, CustomerInfo.CST_MailAddrKindName_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 1, CustomerInfo.CST_MailAddrKindName_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 2, CustomerInfo.CST_MailAddrKindName_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 3, CustomerInfo.CST_MailAddrKindName_3, 4);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 99, CustomerInfo.CST_MailAddrKindName_99, 5);

            // 車輌管理区分
            //this.tComboEditor_CarMngDivCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 0, CustomerInfo.CST_CarMngDivCd_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 1, CustomerInfo.CST_CarMngDivCd_1, 2);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 2, CustomerInfo.CST_CarMngDivCd_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 3, CustomerInfo.CST_CarMngDivCd_3, 4);

            // ＱＲコード印字区分
            //this.tComboEditor_QrcodePrtCd.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 0, CustomerInfo.CST_QrcodePrtCd_0, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 1, CustomerInfo.CST_QrcodePrtCd_1, 2);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 2, CustomerInfo.CST_QrcodePrtCd_2, 3);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 3, CustomerInfo.CST_QrcodePrtCd_3, 4);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
            // 2010/07/06 Add 携帯メールオプションが有効なら追加 >>>
            //if (CustomerSectionInfoControl.IsQRMailOptionIntroduce)
            //{
            //    ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 4, CustomerInfo.CST_QrcodePrtCd_4, 5);
            //    ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 5, CustomerInfo.CST_QrcodePrtCd_5, 6);
            //}
            // 2010/07/06 Add <<<

            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
            // 納品書出力区分
            //this.tComboEditor_SalesSlipPrtDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesSlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesSlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesSlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);
            // 受注伝票出力区分
            //this.tComboEditor_AcpOdrrSlipPrtDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AcpOdrrSlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AcpOdrrSlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AcpOdrrSlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);
            // 貸出伝票出力区分
            //this.tComboEditor_ShipmSlipPrtDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ShipmSlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ShipmSlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ShipmSlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);
            // 見積伝票出力区分
            //this.tComboEditor_EstimatePrtDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_EstimatePrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_EstimatePrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_EstimatePrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);
            // UOE伝票出力区分
            //this.tComboEditor_UOESlipPrtDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_UOESlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_UOESlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_UOESlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);
            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

            // ADD 2009/04/07 ------>>>
            // 領収書出力区分
            //this.tComboEditor_ReceiptOutputCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ReceiptOutputCode, 0, CustomerInfo.CST_ReceiptOutputCode_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ReceiptOutputCode, 1, CustomerInfo.CST_ReceiptOutputCode_1, 1);
            // ADD 2009/04/07 ------<<<

            // ADD 2009/06/03 ------>>>
            // オンライン接続方法
            //this.tComboEditor_OnlineKindDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 0, CustomerInfo.CST_OnlineKindDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 10, CustomerInfo.CST_OnlineKindDiv_10, 10);
            // 現時点では、TSPは表示しない
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 20, CustomerInfo.CST_OnlineKindDiv_20, 20);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 30, CustomerInfo.CST_OnlineKindDiv_30, 30);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 40, CustomerInfo.CST_OnlineKindDiv_40, 40);
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            //合計請求書出力区分
            //this.tComboEditor_TotalBillOutputDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_TotalBillOutputDiv, 0, CustomerInfo.CST_TotalBillOutputDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_TotalBillOutputDiv, 1, CustomerInfo.CST_TotalBillOutputDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_TotalBillOutputDiv, 2, CustomerInfo.CST_TotalBillOutputDiv_2, 2);
            //明細請求書出力区分
            //this.tComboEditor_DetailBillOutputCode.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DetailBillOutputCode, 0, CustomerInfo.CST_DetailBillOutputCode_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DetailBillOutputCode, 1, CustomerInfo.CST_DetailBillOutputCode_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DetailBillOutputCode, 2, CustomerInfo.CST_DetailBillOutputCode_2, 2);
            //伝票合計請求書出力区分
            //this.tComboEditor_SlipTtlBillOutputDiv.Items.Clear();
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SlipTtlBillOutputDiv, 0, CustomerInfo.CST_SlipTtlBillOutputDiv_0, 0);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SlipTtlBillOutputDiv, 1, CustomerInfo.CST_SlipTtlBillOutputDiv_1, 1);
            //ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SlipTtlBillOutputDiv, 2, CustomerInfo.CST_SlipTtlBillOutputDiv_2, 2);
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<

            //# endregion
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            # region [コンボアイテム（固定値）]
            // 諸口
            this.tComboEditor_OutputNameCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 0, CustomerInfo.CST_OutputName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 1, CustomerInfo.CST_OutputName_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 2, CustomerInfo.CST_OutputName_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OutputNameCode, 3, CustomerInfo.CST_OutputName_3, 3);

            // 集金月
            this.tComboEditor_CollectMoneyCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 0, CustomerInfo.CST_CollectMoneyName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 1, CustomerInfo.CST_CollectMoneyName_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 2, CustomerInfo.CST_CollectMoneyName_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CollectMoneyCode, 3, CustomerInfo.CST_CollectMoneyName_3, 3);

            // 回収条件
            this.tComboEditor_CollectCond.Items.Clear();
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd1))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd1, this._depositSt.DepositStKindCd1 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd1].MoneyKindName, this._depositSt.DepositStKindCd1);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd2))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd2, this._depositSt.DepositStKindCd2 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd2].MoneyKindName, this._depositSt.DepositStKindCd2);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd3))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd3, this._depositSt.DepositStKindCd3 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd3].MoneyKindName, this._depositSt.DepositStKindCd3);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd4))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd4, this._depositSt.DepositStKindCd4 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd4].MoneyKindName, this._depositSt.DepositStKindCd4);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd5))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd5, this._depositSt.DepositStKindCd5 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd5].MoneyKindName, this._depositSt.DepositStKindCd5);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd6))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd6, this._depositSt.DepositStKindCd6 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd6].MoneyKindName, this._depositSt.DepositStKindCd6);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd7))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd7, this._depositSt.DepositStKindCd7 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd7].MoneyKindName, this._depositSt.DepositStKindCd7);
            }
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd8))
            {
                ComboEditorItemControl.AddComboEditorItem(tComboEditor_CollectCond, this._depositSt.DepositStKindCd8, this._depositSt.DepositStKindCd8 + ":" + this._moneyKindDic[this._depositSt.DepositStKindCd8].MoneyKindName, this._depositSt.DepositStKindCd8);
            }

            // 与信管理区分
            this.tComboEditor_CreditMngCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CreditMngCode, 0, CustomerInfo.CST_CreditMngCode_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CreditMngCode, 1, CustomerInfo.CST_CreditMngCode_1, 1);

            // 入金消込区分
            this.tComboEditor_DepoDelCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DepoDelCode, 0, CustomerInfo.CST_DepoDelCode_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DepoDelCode, 1, CustomerInfo.CST_DepoDelCode_1, 1);

            // 売掛区分
            this.tComboEditor_AccRecDivCd.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AccRecDivCd, 0, CustomerInfo.CST_AccRecDivCd_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AccRecDivCd, 1, CustomerInfo.CST_AccRecDivCd_1, 1);

            // 相手伝票番号管理区分
            this.tComboEditor_CustSlipNoMngCd.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustSlipNoMngCd, 0, CustomerInfo.CST_CustSlipNoMngCd_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustSlipNoMngCd, 1, CustomerInfo.CST_CustSlipNoMngCd_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustSlipNoMngCd, 2, CustomerInfo.CST_CustSlipNoMngCd_2, 2);

            // 得意先属性区分
            this.tComboEditor_CustomerAttributeDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerAttributeDiv, 0, CustomerInfo.CST_CustomerAttributeDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerAttributeDiv, 8, CustomerInfo.CST_CustomerAttributeDiv_8, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerAttributeDiv, 9, CustomerInfo.CST_CustomerAttributeDiv_9, 2);

            // 得意先種別区分
            this.tComboEditor_CustomerDivCd.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerDivCd, 0, CustomerInfo.CST_CustomerDivCd_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerDivCd, 1, CustomerInfo.CST_CustomerDivCd_1, 1);

            // 得意先伝票番号区分
            this.tComboEditor_CustomerSlipNoDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 0, CustomerInfo.CST_CustomerSlipNoDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 1, CustomerInfo.CST_CustomerSlipNoDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 2, CustomerInfo.CST_CustomerSlipNoDiv_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustomerSlipNoDiv, 3, CustomerInfo.CST_CustomerSlipNoDiv_3, 3);

            // 消費税転嫁方式
            this.tComboEditor_ConsTaxLayMethod.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 0, CustomerInfo.CST_ConsTaxLayMethod_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 1, CustomerInfo.CST_ConsTaxLayMethod_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 2, CustomerInfo.CST_ConsTaxLayMethod_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 3, CustomerInfo.CST_ConsTaxLayMethod_3, 3);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ConsTaxLayMethod, 9, CustomerInfo.CST_ConsTaxLayMethod_9, 9);

            // 消費税転嫁方式参照区分
            this.tComboEditor_CustCTaXLayRefCd.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustCTaXLayRefCd, 0, CustomerInfo.CST_CustCTaXLayRefCd_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CustCTaXLayRefCd, 1, CustomerInfo.CST_CustCTaXLayRefCd_1, 1);

            // 個人・法人
            this.tComboEditor_CorporateDivCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 0, CustomerInfo.CST_CorporateDivName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 1, CustomerInfo.CST_CorporateDivName_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 2, CustomerInfo.CST_CorporateDivName_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 3, CustomerInfo.CST_CorporateDivName_3, 3);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CorporateDivCode, 4, CustomerInfo.CST_CorporateDivName_4, 4);

            // ＤＭ出力
            this.tComboEditor_DmOutCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DmOutCode, 0, CustomerInfo.CST_BillOutputName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DmOutCode, 1, CustomerInfo.CST_BillOutputName_1, 1);

            // 主連絡先
            this.tComboEditor_MainContactCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 0, "0:" + this._alItmDspNmAcs.GetMainContactDspName(0), 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 1, "1:" + this._alItmDspNmAcs.GetMainContactDspName(1), 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 2, "2:" + this._alItmDspNmAcs.GetMainContactDspName(2), 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 3, "3:" + this._alItmDspNmAcs.GetMainContactDspName(3), 3);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 4, "4:" + this._alItmDspNmAcs.GetMainContactDspName(4), 4);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MainContactCode, 5, "5:" + this._alItmDspNmAcs.GetMainContactDspName(5), 5);

            // メール送信区分
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode1, 0, CustomerInfo.CST_MailSendName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode1, 1, CustomerInfo.CST_MailSendName_1, 1);

            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode2, 0, CustomerInfo.CST_MailSendName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailSendCode2, 1, CustomerInfo.CST_MailSendName_1, 1);

            // メールアドレス種別
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 0, CustomerInfo.CST_MailAddrKindName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 1, CustomerInfo.CST_MailAddrKindName_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 2, CustomerInfo.CST_MailAddrKindName_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 3, CustomerInfo.CST_MailAddrKindName_3, 3);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode1, 99, CustomerInfo.CST_MailAddrKindName_99, 4);

            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 0, CustomerInfo.CST_MailAddrKindName_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 1, CustomerInfo.CST_MailAddrKindName_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 2, CustomerInfo.CST_MailAddrKindName_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 3, CustomerInfo.CST_MailAddrKindName_3, 3);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_MailAddrKindCode2, 99, CustomerInfo.CST_MailAddrKindName_99, 4);

            // 車輌管理区分
            this.tComboEditor_CarMngDivCd.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 0, CustomerInfo.CST_CarMngDivCd_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 1, CustomerInfo.CST_CarMngDivCd_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 2, CustomerInfo.CST_CarMngDivCd_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_CarMngDivCd, 3, CustomerInfo.CST_CarMngDivCd_3, 3);

            // ＱＲコード印字区分
            this.tComboEditor_QrcodePrtCd.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 0, CustomerInfo.CST_QrcodePrtCd_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 1, CustomerInfo.CST_QrcodePrtCd_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 2, CustomerInfo.CST_QrcodePrtCd_2, 2);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 3, CustomerInfo.CST_QrcodePrtCd_3, 3);
            if (CustomerSectionInfoControl.IsQRMailOptionIntroduce)
            {
                ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 4, CustomerInfo.CST_QrcodePrtCd_4, 4);
                ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_QrcodePrtCd, 5, CustomerInfo.CST_QrcodePrtCd_5, 5);
            }

            // 納品書出力区分
            this.tComboEditor_SalesSlipPrtDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesSlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesSlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesSlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);

            // 受注伝票出力区分
            this.tComboEditor_AcpOdrrSlipPrtDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AcpOdrrSlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AcpOdrrSlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_AcpOdrrSlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);

            // 貸出伝票出力区分
            this.tComboEditor_ShipmSlipPrtDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ShipmSlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ShipmSlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ShipmSlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);

            // 見積伝票出力区分
            this.tComboEditor_EstimatePrtDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_EstimatePrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_EstimatePrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_EstimatePrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);

            // UOE伝票出力区分
            this.tComboEditor_UOESlipPrtDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_UOESlipPrtDiv, 0, CustomerInfo.CST_PrtDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_UOESlipPrtDiv, 1, CustomerInfo.CST_PrtDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_UOESlipPrtDiv, 2, CustomerInfo.CST_PrtDiv_2, 2);

            // 領収書出力区分
            this.tComboEditor_ReceiptOutputCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ReceiptOutputCode, 0, CustomerInfo.CST_ReceiptOutputCode_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_ReceiptOutputCode, 1, CustomerInfo.CST_ReceiptOutputCode_1, 1);

            // オンライン接続方法
            this.tComboEditor_OnlineKindDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 0, CustomerInfo.CST_OnlineKindDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_OnlineKindDiv, 10, CustomerInfo.CST_OnlineKindDiv_10, 1);

            //合計請求書出力区分
            this.tComboEditor_TotalBillOutputDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_TotalBillOutputDiv, 0, CustomerInfo.CST_TotalBillOutputDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_TotalBillOutputDiv, 1, CustomerInfo.CST_TotalBillOutputDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_TotalBillOutputDiv, 2, CustomerInfo.CST_TotalBillOutputDiv_2, 2);
            
            //明細請求書出力区分
            this.tComboEditor_DetailBillOutputCode.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DetailBillOutputCode, 0, CustomerInfo.CST_DetailBillOutputCode_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DetailBillOutputCode, 1, CustomerInfo.CST_DetailBillOutputCode_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_DetailBillOutputCode, 2, CustomerInfo.CST_DetailBillOutputCode_2, 2);
            
            //伝票合計請求書出力区分
            this.tComboEditor_SlipTtlBillOutputDiv.Items.Clear();
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SlipTtlBillOutputDiv, 0, CustomerInfo.CST_SlipTtlBillOutputDiv_0, 0);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SlipTtlBillOutputDiv, 1, CustomerInfo.CST_SlipTtlBillOutputDiv_1, 1);
            ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SlipTtlBillOutputDiv, 2, CustomerInfo.CST_SlipTtlBillOutputDiv_2, 2);

            # endregion
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            # region [コンボアイテム（ユーザーガイド）]
            // ユーザーガイドマスタボディ部リスト取得処理
            status = this._customerInputAcs.GetUserGdBdListToStatic();

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                // --- DEL 2010/08/10 ------------------------------------>>>>>
                //// 職種（ユーザーガイドマスタより取得）
                //status = this._customerInputAcs.GetDivCodeBodyList( 34, out retList );

                //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    retList.Sort();

                //    ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_JobTypeCode, 0, " ", 0 );
                //    int count = 1;
                //    foreach ( ComboEditorItemCustomer ci in retList )
                //    {
                //        count++;
                //        // --- DEL 2010/08/10 ------------------------------------>>>>>
                //        //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_JobTypeCode, ci.Code, ci.Name, count );
                //        // --- DEL 2010/08/10 ------------------------------------<<<<<
                //        // --- ADD 2010/08/10 ------------------------------------>>>>>
                //        ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_JobTypeCode, ci.Code, "000" + ci.Code+":"+ci.Name, count-1);
                //        // --- ADD 2010/08/10 ------------------------------------<<<<<
                //    }
                //}

                //// 業種（ユーザーガイドマスタより取得）
                //status = this._customerInputAcs.GetDivCodeBodyList( 33, out retList );

                //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    retList.Sort();

                //    ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_BusinessTypeCode, 0, " ", 0 );
                //    int count = 1;
                //    foreach ( ComboEditorItemCustomer ci in retList )
                //    {
                //        count++;
                //        // --- DEL 2010/08/10 ------------------------------------>>>>>
                //        //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_BusinessTypeCode, ci.Code, ci.Name, count );
                //        // --- DEL 2010/08/10 ------------------------------------<<<<<
                //        // --- ADD 2010/08/10 ------------------------------------>>>>>
                //        ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_BusinessTypeCode, ci.Code, "000" + ci.Code+":"+ci.Name, count-1);
                //        // --- ADD 2010/08/10 ------------------------------------<<<<<
                //    }
                //}

                //// 販売エリア（ユーザーガイドマスタより取得）
                //status = this._customerInputAcs.GetDivCodeBodyList( 21, out retList );

                //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    retList.Sort();

                //    ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_SalesAreaCode, 0, " ", 0 );
                //    int count = 1;
                //    foreach ( ComboEditorItemCustomer ci in retList )
                //    {
                //        count++;
                //        // --- DEL 2010/08/10 ------------------------------------>>>>>
                //        //ComboEditorItemControl.AddComboEditorItem( this.tComboEditor_SalesAreaCode, ci.Code, ci.Name, count );
                //        // --- DEL 2010/08/10 ------------------------------------<<<<<
                //        // --- ADD 2010/08/10 ------------------------------------>>>>>
                //        ComboEditorItemControl.AddComboEditorItem(this.tComboEditor_SalesAreaCode, ci.Code, "000" + ci.Code + ":" + ci.Name, count-1);
                //        // --- ADD 2010/08/10 ------------------------------------<<<<<
                //    }
                //}
                // --- DEL 2010/08/10 ------------------------------------<<<<<
            }
            else if ( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "ユーザーガイド（ボディ）情報が有りません。",
                    status,
                    MessageBoxButtons.OK );
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "ユーザーガイド（ボディ）情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK );
            }
            # endregion
        }

        /// <summary>
        /// タブインデックスの設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : パターンごとのタブインデックスを設定します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>UpdateNote : 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        /// </remarks>
        private void SetControlTabIndex()
        {
            # region [TAB順（メイン）]
            int baseTabIndex = 1000;

            this.tNedit_CustomerCode.TabIndex = ++baseTabIndex;		// 得意先コード
            this.tEdit_CustomerSubCode.TabIndex = ++baseTabIndex;		// サブコード
            this.tEdit_Name.TabIndex = ++baseTabIndex;		// 得意先名称１
            this.tEdit_Name2.TabIndex = ++baseTabIndex;		// 得意先名称２
            this.tEdit_CustomerSnm.TabIndex = ++baseTabIndex;       // 得意先略称
            this.tEdit_Kana.TabIndex = ++baseTabIndex;		// 得意先カナ
            //this.tComboEditor_HonorificTitle.TabIndex = ++baseTabIndex;		// 敬称
            this.tEdit_HonorificTitle.TabIndex = ++baseTabIndex;    // 敬称
            this.tComboEditor_OutputNameCode.TabIndex = ++baseTabIndex;		// 諸口

            // 詳細情報
            this.tEdit_MngSectionNm.TabIndex = ++baseTabIndex;       // 管理拠点名称
            this.uButton_MngSectionNmGuide.TabIndex = ++baseTabIndex;       // 管理拠点ガイド
            this.tEdit_CustomerAgentNm.TabIndex = ++baseTabIndex;		// 得意先担当
            this.uButton_CustomerAgentNmGuide.TabIndex = ++baseTabIndex;		// 得意先担当ガイドボタン
            this.tEdit_OldCustomerAgentNm.TabIndex = ++baseTabIndex;		// 旧得意先担当
            this.uButton_OldCustomerAgentNmGuide.TabIndex = ++baseTabIndex;		// 旧得意先担当ガイドボタン
            this.tDateEdit_CustAgentChgDate.TabIndex = ++baseTabIndex;       // 得意先担当者変更日            
            this.tDateEdit_TransStopDate.TabIndex = ++baseTabIndex;       // 取引中止日
            this.tComboEditor_CorporateDivCode.TabIndex = ++baseTabIndex;		// 個人・法人
            this.tComboEditor_CustomerAttributeDiv.TabIndex = ++baseTabIndex;       // 得意先属性
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //this.tComboEditor_BusinessTypeCode.TabIndex = ++baseTabIndex;		// 業種コード
            //this.tComboEditor_JobTypeCode.TabIndex = ++baseTabIndex;		    // 職種コード
            //this.tComboEditor_SalesAreaCode.TabIndex = ++baseTabIndex;		// 販売エリアコード 
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this.tEdit_BusinessTypeNm.TabIndex = ++baseTabIndex;
            this.uButton_BusinessTypeCdGuide.TabIndex = ++baseTabIndex;
            this.tEdit_JobTypeName.TabIndex = ++baseTabIndex;
            this.uButton_JobTypeCodeGuide.TabIndex = ++baseTabIndex;
            this.tEdit_SalesAreaNm.TabIndex = ++baseTabIndex;
            this.uButton_SalesAreaCdGuide.TabIndex = ++baseTabIndex;
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            this.tComboEditor_CarMngDivCd.TabIndex = ++baseTabIndex;        // 車輌管理区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
            //this.tComboEditor_PureCode.TabIndex = ++baseTabIndex;       // 純正区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
            this.tComboEditor_CustomerDivCd.TabIndex = ++baseTabIndex;       // 得意先種別
            this.tEdit_CustWarehouseCd.TabIndex = ++baseTabIndex;       // 得意先優先倉庫
            this.tNedit_CustAnalysCode1.TabIndex = ++baseTabIndex;		// 分析コード１
            this.tNedit_CustAnalysCode2.TabIndex = ++baseTabIndex;		// 分析コード２
            this.tNedit_CustAnalysCode3.TabIndex = ++baseTabIndex;		// 分析コード３
            this.tNedit_CustAnalysCode4.TabIndex = ++baseTabIndex;		// 分析コード４
            this.tNedit_CustAnalysCode5.TabIndex = ++baseTabIndex;		// 分析コード５
            this.tNedit_CustAnalysCode6.TabIndex = ++baseTabIndex;		// 分析コード６

            // 請求情報
            this.tEdit_ClaimSectionCode.TabIndex = ++baseTabIndex;  // 請求拠点コード
            this.uButton_ClaimSectionGuide.TabIndex = ++baseTabIndex;  // 請求拠点ガイドボタン
            this.tNedit_ClaimCode.TabIndex = ++baseTabIndex;            // 請求先コード
            this.uButton_ClaimNameGuide.TabIndex = ++baseTabIndex;		// 請求先ガイドボタン
            this.tNedit_TotalDay.TabIndex = ++baseTabIndex;		// 締日
            this.tComboEditor_CollectMoneyCode.TabIndex = ++baseTabIndex;		// 集金月
            this.tNedit_CollectMoneyDay.TabIndex = ++baseTabIndex;		// 集金日
            this.tComboEditor_CollectCond.TabIndex = ++baseTabIndex;       // 回収条件
            this.tNedit_CollectSight.TabIndex = ++baseTabIndex;       // 回収サイト
            this.tNedit_NTimeCalcStDate.TabIndex = ++baseTabIndex;                  // 次回勘定開始日
            this.tEdit_BillCollecterNm.TabIndex = ++baseTabIndex;		// 集金担当
            this.uButton_BillCollecterNmGuide.TabIndex = ++baseTabIndex;		// 集金担当ガイドボタン
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            this.tComboEditor_TotalAmntDspWayRef.TabIndex = ++baseTabIndex;		// 総額表示方法参照区分
            this.tComboEditor_TotalAmountDispWayCd.TabIndex = ++baseTabIndex;		// 総額表示方法区分
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            this.tComboEditor_CustCTaXLayRefCd.TabIndex = ++baseTabIndex;		// 消費税転嫁方式参照区分
            this.tComboEditor_ConsTaxLayMethod.TabIndex = ++baseTabIndex;		// 消費税転嫁方式
            this.tComboEditor_CreditMngCode.TabIndex = ++baseTabIndex;       // 与信管理区分
            this.tComboEditor_DepoDelCode.TabIndex = ++baseTabIndex;       // 入金消込区分
            this.tComboEditor_AccRecDivCd.TabIndex = ++baseTabIndex;       // 売掛区分
            this.tNedit_SalesUnPrcFrcProcCd.TabIndex = ++baseTabIndex;      // 売上単価端数処理コード
            this.uButton_SalesUnPrcFrcProcCdGuide.TabIndex = ++baseTabIndex;      // 売上単価端数処理コードガイド
            this.tNedit_SalesMoneyFrcProcCd.TabIndex = ++baseTabIndex;      // 売上金額端数処理コード
            this.uButton_SalesMoneyFrcProcCdGuide.TabIndex = ++baseTabIndex;      // 売上金額端数処理コードガイド
            this.tNedit_SalesCnsTaxFrcProcCd.TabIndex = ++baseTabIndex;		// 売上消費税端数処理コード
            this.uButton_SalesCnsTaxFrcProcCdGuide.TabIndex = ++baseTabIndex;		// 売上消費税端数処理コードガイド
            # endregion

            # region [TAB順（連絡先タブ）]
            // 連絡先
            int tab0TabIndex = 1900;

            this.tEdit_PostNo.TabIndex = ++tab0TabIndex;		// 郵便番号
            this.uButton_AddressGuide.TabIndex = ++tab0TabIndex;		// 住所ガイドボタン
            this.tEdit_Address1.TabIndex = ++tab0TabIndex;		// 住所１
            this.tNedit_Address2.TabIndex = ++tab0TabIndex;		// 住所２
            this.tEdit_Address3.TabIndex = ++tab0TabIndex;		// 住所３
            this.tEdit_Address4.TabIndex = ++tab0TabIndex;		// 住所４
            this.tEdit_CustomerAgent.TabIndex = ++tab0TabIndex;                     // 得意先担当者（相手側）
            this.tEdit_HomeTelNo.TabIndex = ++tab0TabIndex;		// 電話番号（自宅）
            this.tEdit_OfficeTelNo.TabIndex = ++tab0TabIndex;		// 電話番号（勤務先）
            this.tEdit_PortableTelNo.TabIndex = ++tab0TabIndex;		// 電話番号（携帯）
            this.tEdit_OthersTelNo.TabIndex = ++tab0TabIndex;		// 電話番号（他）
            this.tEdit_HomeFaxNo.TabIndex = ++tab0TabIndex;		// FAX（自宅）
            this.tEdit_OfficeFaxNo.TabIndex = ++tab0TabIndex;		// FAX（勤務先）
            this.tEdit_SearchTelNo.TabIndex = ++tab0TabIndex;		// 検索番号
            this.tComboEditor_MainContactCode.TabIndex = ++tab0TabIndex;		// 主連絡先
            # endregion

            # region [TAB順（備考タブ）]
            // 備考情報
            int tab2TabIndex = 2100;

            this.panel_SubInfo2.TabIndex = ++tab2TabIndex;					// 備考情報表示用パネル
            this.tEdit_Note1.TabIndex = ++tab2TabIndex;					// 備考１
            this.uButton_Note1Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド１
            this.tEdit_Note2.TabIndex = ++tab2TabIndex;					// 備考２
            this.uButton_Note2Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド２
            this.tEdit_Note3.TabIndex = ++tab2TabIndex;					// 備考３
            this.uButton_Note3Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド３
            this.tEdit_Note4.TabIndex = ++tab2TabIndex;					// 備考４
            this.uButton_Note4Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド４
            this.tEdit_Note5.TabIndex = ++tab2TabIndex;					// 備考５
            this.uButton_Note5Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド５
            this.tEdit_Note6.TabIndex = ++tab2TabIndex;					// 備考６
            this.uButton_Note6Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド６
            this.tEdit_Note7.TabIndex = ++tab2TabIndex;					// 備考７
            this.uButton_Note7Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド７
            this.tEdit_Note8.TabIndex = ++tab2TabIndex;					// 備考８
            this.uButton_Note8Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド８
            this.tEdit_Note9.TabIndex = ++tab2TabIndex;					// 備考９
            this.uButton_Note9Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド９
            this.tEdit_Note10.TabIndex = ++tab2TabIndex;					// 備考１０
            this.uButton_Note10Guide.TabIndex = ++tab2TabIndex;					// 備考ガイド１０
            # endregion

            # region [TAB順（Ｅメールタブ）]
            // Ｅメール情報
            int tab5TabIndex = 2400;

            this.panel_SubInfo4.TabIndex = ++tab5TabIndex;		// Ｅメール情報表示用パネル
            this.tEdit_MailAddress1.TabIndex = ++tab5TabIndex;		// メールアドレス１
            this.tComboEditor_MailSendCode1.TabIndex = ++tab5TabIndex;		// メール送信区分１
            this.tComboEditor_MailAddrKindCode1.TabIndex = ++tab5TabIndex;		// メールアドレス種別１
            this.tEdit_MailAddress2.TabIndex = ++tab5TabIndex;		// メールアドレス２
            this.tComboEditor_MailSendCode2.TabIndex = ++tab5TabIndex;		// メール送信区分２
            this.tComboEditor_MailAddrKindCode2.TabIndex = ++tab5TabIndex;		// メールアドレス種別２
            # endregion

            # region [TAB順（口座タブ）]
            // 口座情報
            int tab6TabIndex = 2500;

            this.panel_SubInfo5.TabIndex = ++tab6TabIndex;							// 口座情報表示用パネル
            this.tEdit_AccountNoInfo1.TabIndex = ++tab6TabIndex;					// 銀行口座１
            this.tEdit_AccountNoInfo2.TabIndex = ++tab6TabIndex;					// 銀行口座２
            this.tEdit_AccountNoInfo3.TabIndex = ++tab6TabIndex;					// 銀行口座３
            # endregion

            # region [TAB順（伝票・請求書タブ）]
            // 伝票・請求書情報
            int tab7TabIndex = 2600;

            // ADD 2009/04/07 ------>>>
            this.tComboEditor_ReceiptOutputCode.TabIndex = ++tab7TabIndex;  // 領収書出力区分
            // ADD 2009/04/07 ------<<<

            // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
            //this.tComboEditor_BillOutputCode.TabIndex = ++tab7TabIndex;		// 請求書出力
            // --- DEL  大矢睦美  2010/01/04 ----------<<<<<

            this.tComboEditor_DmOutCode.TabIndex = ++tab7TabIndex;		// DM出力区分
            this.tComboEditor_CustSlipNoMngCd.TabIndex = ++tab7TabIndex;       // 相手伝票番号管理
            this.tComboEditor_CustomerSlipNoDiv.TabIndex = ++tab7TabIndex;       // 得意先伝票番号区分
            this.tComboEditor_QrcodePrtCd.TabIndex = ++tab7TabIndex;    // ＱＲコード印刷区分

            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
            this.tComboEditor_SalesSlipPrtDiv.TabIndex = ++tab7TabIndex;    // 納品書出力
            this.tComboEditor_AcpOdrrSlipPrtDiv.TabIndex = ++tab7TabIndex;  // 受注伝票出力
            this.tComboEditor_ShipmSlipPrtDiv.TabIndex = ++tab7TabIndex;    // 貸出伝票出力
            this.tComboEditor_EstimatePrtDiv.TabIndex = ++tab7TabIndex;     // 見積伝票出力
            this.tComboEditor_UOESlipPrtDiv.TabIndex = ++tab7TabIndex;      // UOE伝票出力
            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<
 　　　　　 // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            this.tComboEditor_TotalBillOutputDiv.TabIndex = ++tab7TabIndex;    //合計請求書出力
            this.tComboEditor_DetailBillOutputCode.TabIndex = ++tab7TabIndex;  //明細請求書出力
            this.tComboEditor_SlipTtlBillOutputDiv.TabIndex = ++tab7TabIndex;    //伝票合計請求書出力
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            # endregion

            // ADD 2009/06/03 ------>>>
            # region [TAB順（オンラインタブ）]
            // オンライン情報
            int tab8TabIndex = 2700;

            this.tComboEditor_OnlineKindDiv.TabIndex = ++tab8TabIndex;  // オンライン接続方法
            this.tEdit_CustomerEpCode.TabIndex = ++tab8TabIndex;        // 得意先企業コード
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            this.tEdit_SimplInqAcntAcntGrId.TabIndex = ++tab8TabIndex;  // 簡単問合せアカウントグループID
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            this.tEdit_CustomerSecCode.TabIndex = ++tab8TabIndex;       // 得意先拠点
            # endregion
            // ADD 2009/06/03 ------<<<
            
            // オフラインモード時コントロールEnabled変更処理
            //this.OfflineModeControlEnableChange();  // 2010/06/29 Del
            // ADD 陳健 K2014/02/06 ------------------------------>>>>>>
            # region [TAB順（メモタブ）]
            // メモ
            int tab9TabIndex = 2800;

            this.panel_SubInfo7.TabIndex = ++tab9TabIndex;							// メモタブ
            // ADD 梶谷貴士 2021/05/10 ------------------------------>>>>>>
            this.check_CustomerInfoGuideDisp.TabIndex = ++tab9TabIndex;         //得意先情報ガイド表示
            // ADD 梶谷貴士 2021/05/10 ------------------------------<<<<<<
            this.memo_richTextBox.TabIndex = ++tab9TabIndex;					// メモ
            # endregion
            // ADD 陳健 K2014/02/06 ------------------------------<<<<<<
        }

        /// <summary>
        /// 画面→得意先クラス格納処理
        /// </summary>
        /// <param name="customerInfo">得意先クラス</param>
        /// <remarks>
        /// <br>Note       : 画面の入力情報を取得し、得意先オブジェクトに値をセットします。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>UpdateNote : 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        /// <br>UpdateNote : 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        /// </remarks>
        private void GetDisplayDataToCustomerInfo( ref Broadleaf.Application.UIData.CustomerInfo customerInfo )
        {
            if ( customerInfo == null )
            {
                return;
            }

            # region [画面→得意先クラス]
            customerInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
            customerInfo.CustomerSubCode = this.tEdit_CustomerSubCode.DataText;
            customerInfo.Name = this.tEdit_Name.DataText;
            customerInfo.Name2 = this.tEdit_Name2.DataText;
            //customerInfo.HonorificTitle = this.tComboEditor_HonorificTitle.Text;
            customerInfo.HonorificTitle = this.tEdit_HonorificTitle.Text;
            customerInfo.Kana = this.tEdit_Kana.DataText;
            customerInfo.OutputNameCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_OutputNameCode );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.OutputName = this.GetComboEditorText( this.tComboEditor_OutputNameCode, customerInfo.OutputNameCode );
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string OutputNameStr = this.GetComboEditorText(this.tComboEditor_OutputNameCode, customerInfo.OutputNameCode);
            customerInfo.OutputName = OutputNameStr.Substring(OutputNameStr.IndexOf(":") + 1);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.CorporateDivCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CorporateDivCode );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.JobTypeCode = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_JobTypeCode);
            //customerInfo.JobTypeName = this.GetComboEditorText( this.tComboEditor_JobTypeCode, customerInfo.JobTypeCode );
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerInfo.JobTypeCode = this._jobTypeCode;
            customerInfo.JobTypeName = this.tEdit_JobTypeName.DataText.Trim();
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.BusinessTypeCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_BusinessTypeCode );
            //customerInfo.BusinessTypeName = this.GetComboEditorText( this.tComboEditor_BusinessTypeCode, customerInfo.BusinessTypeCode );
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerInfo.BusinessTypeCode = this._businessTypeCd;
            customerInfo.BusinessTypeName = this.tEdit_BusinessTypeNm.DataText.Trim();
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.SalesAreaCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_SalesAreaCode );
            //customerInfo.SalesAreaName = this.GetComboEditorText(this.tComboEditor_SalesAreaCode, customerInfo.SalesAreaCode);
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerInfo.SalesAreaCode = this._saleAreaCd;
            customerInfo.SalesAreaName = this.tEdit_SalesAreaNm.DataText.Trim();
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.MngSectionCode = this._mngSectionCode;
            customerInfo.InpSectionCode = this._ownSectionCode;
            customerInfo.CustAnalysCode1 = this.tNedit_CustAnalysCode1.GetInt();
            customerInfo.CustAnalysCode2 = this.tNedit_CustAnalysCode2.GetInt();
            customerInfo.CustAnalysCode3 = this.tNedit_CustAnalysCode3.GetInt();
            customerInfo.CustAnalysCode4 = this.tNedit_CustAnalysCode4.GetInt();
            customerInfo.CustAnalysCode5 = this.tNedit_CustAnalysCode5.GetInt();
            customerInfo.CustAnalysCode6 = this.tNedit_CustAnalysCode6.GetInt();
            // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
            //customerInfo.BillOutputCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_BillOutputCode );
            //customerInfo.BillOutputName = tComboEditor_BillOutputCode.Text;
            // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
            customerInfo.TotalDay = this.tNedit_TotalDay.GetInt();
            customerInfo.CollectMoneyCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CollectMoneyCode );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.CollectMoneyName = tComboEditor_CollectMoneyCode.Text;
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string CollectMoneyNameStr = this.GetComboEditorText(this.tComboEditor_CollectMoneyCode, customerInfo.CollectMoneyCode);
            customerInfo.CollectMoneyName = CollectMoneyNameStr.Substring(CollectMoneyNameStr.IndexOf(":") + 1);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.CollectMoneyDay = this.tNedit_CollectMoneyDay.GetInt();
            //customerInfo.ClaimCode		// 請求先用に取得したCustomerクラスより設定
            customerInfo.ClaimName = this.uLabel_ClaimName1.Text;
            customerInfo.ClaimName2 = this.uLabel_ClaimName2.Text;
            customerInfo.ClaimSnm = this.uLabel_ClaimSnm.Text;
            customerInfo.CustCTaXLayRefCd = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CustCTaXLayRefCd );
            customerInfo.ConsTaxLayMethod = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_ConsTaxLayMethod );
            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //customerInfo.TotalAmountDispWayCd = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_TotalAmountDispWayCd );
            //customerInfo.TotalAmntDspWayRef = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_TotalAmntDspWayRef );
            customerInfo.TotalAmountDispWayCd = 0;
            customerInfo.TotalAmntDspWayRef = 0;
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
            customerInfo.CustomerAttributeDiv = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CustomerAttributeDiv );// 得意先属性区分 
            customerInfo.CollectCond = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CollectCond );                  // 回収条件
            customerInfo.CreditMngCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CreditMngCode );              // 与信管理区分
            customerInfo.DepoDelCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_DepoDelCode );                  // 入金消込区分
            customerInfo.AccRecDivCd = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_AccRecDivCd );                  // 売掛区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
            //customerInfo.PureCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_PureCode );                        // 純正区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
            customerInfo.SalesUnPrcFrcProcCd = this.tNedit_SalesUnPrcFrcProcCd.GetInt();        // 売上単価端数処理コード
            customerInfo.SalesMoneyFrcProcCd = this.tNedit_SalesMoneyFrcProcCd.GetInt();        // 売上金額端数処理コード
            customerInfo.SalesCnsTaxFrcProcCd = this.tNedit_SalesCnsTaxFrcProcCd.GetInt();      // 売上消費税端数処理コード
            customerInfo.CustomerSnm = this.tEdit_CustomerSnm.Text;                                                 // 得意先略称
            customerInfo.CollectSight = this.tNedit_CollectSight.GetInt();                                          // 回収サイト
            customerInfo.TransStopDate = this.tDateEdit_TransStopDate.GetDateTime();                                // 取引中止日
            customerInfo.CustAgentChgDate = this.tDateEdit_CustAgentChgDate.GetDateTime();                          // 顧客担当変更日
            customerInfo.OldCustomerAgentNm = this.tEdit_OldCustomerAgentNm.DataText;                               // 得意先担当
            customerInfo.NTimeCalcStDate = this.tNedit_NTimeCalcStDate.GetInt();    // 次回勘定開始日
            customerInfo.CustomerAgent = this.tEdit_CustomerAgent.Text;             // 得意先担当者（相手側）
            customerInfo.CustWarehouseCd = this._custWarehouseCode;             // 得意先優先倉庫コード
            if ((this._custWarehouseCode != null) && (this._custWarehouseCode.Trim() != ""))
            {
                customerInfo.CustWarehouseName = this.tEdit_CustWarehouseCd.Text;   // 得意先優先倉庫名称
            }
            else
            {
                customerInfo.CustWarehouseCd = "";
                customerInfo.CustWarehouseName = "";   // 得意先優先倉庫名称
            }
            customerInfo.ClaimSectionCode = this._claimSectionCode;             // 請求拠点コード
            customerInfo.ClaimSectionName = this.tEdit_ClaimSectionCode.Text;   // 請求拠点名称
            customerInfo.CarMngDivCd = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CarMngDivCd ); // 車輌管理区分

            // 連絡先情報
            customerInfo.PostNo = this.tEdit_PostNo.DataText;
            customerInfo.Address1 = this.tEdit_Address1.DataText;
            customerInfo.Address3 = this.tEdit_Address3.DataText;
            customerInfo.Address4 = this.tEdit_Address4.DataText;
            customerInfo.HomeTelNo = this.tEdit_HomeTelNo.DataText;
            customerInfo.OfficeTelNo = this.tEdit_OfficeTelNo.DataText;
            customerInfo.PortableTelNo = this.tEdit_PortableTelNo.DataText;
            customerInfo.HomeFaxNo = this.tEdit_HomeFaxNo.DataText;
            customerInfo.OfficeFaxNo = this.tEdit_OfficeFaxNo.DataText;
            customerInfo.OthersTelNo = this.tEdit_OthersTelNo.DataText;
            customerInfo.MainContactCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_MainContactCode );
            customerInfo.SearchTelNo = this.tEdit_SearchTelNo.DataText;

            // 備考情報
            customerInfo.Note1 = this.tEdit_Note1.DataText;
            customerInfo.Note2 = this.tEdit_Note2.DataText;
            customerInfo.Note3 = this.tEdit_Note3.DataText;
            customerInfo.Note4 = this.tEdit_Note4.DataText;
            customerInfo.Note5 = this.tEdit_Note5.DataText;
            customerInfo.Note6 = this.tEdit_Note6.DataText;
            customerInfo.Note7 = this.tEdit_Note7.DataText;
            customerInfo.Note8 = this.tEdit_Note8.DataText;
            customerInfo.Note9 = this.tEdit_Note9.DataText;
            customerInfo.Note10 = this.tEdit_Note10.DataText;

            // Ｅメール情報
            customerInfo.MailAddrKindCode1 = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_MailAddrKindCode1 );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.MailAddrKindName1 = this.GetComboEditorText( this.tComboEditor_MailAddrKindCode1, customerInfo.MailAddrKindCode1 );
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string MailAddrKindName1Str = this.GetComboEditorText(this.tComboEditor_MailAddrKindCode1, customerInfo.MailAddrKindCode1);
            customerInfo.MailAddrKindName1 = MailAddrKindName1Str.Substring(MailAddrKindName1Str.IndexOf(":") + 1);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.MailAddress1 = this.tEdit_MailAddress1.DataText;
            customerInfo.MailSendCode1 = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_MailSendCode1 );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.MailSendName1 = this.GetComboEditorText( this.tComboEditor_MailSendCode1, customerInfo.MailSendCode1 );
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string MailSendName1Str = this.GetComboEditorText(this.tComboEditor_MailSendCode1, customerInfo.MailSendCode1);
            customerInfo.MailSendName1 = MailSendName1Str.Substring(MailSendName1Str.IndexOf(":") + 1);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.MailAddrKindCode2 = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_MailAddrKindCode2 );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.MailAddrKindName2 = this.GetComboEditorText(this.tComboEditor_MailAddrKindCode2, customerInfo.MailAddrKindCode2);
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string MailAddrKindName2Str = this.GetComboEditorText(this.tComboEditor_MailAddrKindCode2, customerInfo.MailAddrKindCode2);
            customerInfo.MailAddrKindName2 = MailAddrKindName2Str.Substring(MailAddrKindName2Str.IndexOf(":") + 1);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.MailAddress2 = this.tEdit_MailAddress2.DataText;
            customerInfo.MailSendCode2 = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_MailSendCode2 );
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.MailSendName2 = this.GetComboEditorText( this.tComboEditor_MailSendCode2, customerInfo.MailSendCode2 );
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string MailSendName2Str = this.GetComboEditorText(this.tComboEditor_MailSendCode2, customerInfo.MailSendCode2);
            customerInfo.MailSendName2 = MailSendName2Str.Substring(MailSendName2Str.IndexOf(":") + 1);
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            if ( this.rButton_MainSendMailAddrCd1.Checked )
            {
                customerInfo.MainSendMailAddrCd = 1;
            }
            else
            {
                customerInfo.MainSendMailAddrCd = 0;
            }

            // 口座情報
            customerInfo.AccountNoInfo1 = this.tEdit_AccountNoInfo1.Text;
            customerInfo.AccountNoInfo2 = this.tEdit_AccountNoInfo2.Text;
            customerInfo.AccountNoInfo3 = this.tEdit_AccountNoInfo3.Text;

            // 伝票・請求書情報
            // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
            //customerInfo.BillOutputName = this.GetComboEditorText( this.tComboEditor_BillOutputCode, customerInfo.BillOutputCode );   // 請求書発行区分名
            // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
            customerInfo.BillOutPutCodeNm = customerInfo.BillOutputName;                                                                // 請求書発行区分名(UI用ダミー項目)
            customerInfo.DmOutCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_DmOutCode );         // ＤＭ出力区分
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //customerInfo.DmOutName = tComboEditor_DmOutCode.Text;                                                               // ＤＭ出力区分名称
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerInfo.DmOutName = tComboEditor_DmOutCode.Text.Substring(tComboEditor_DmOutCode.Text.IndexOf(":") + 1);  
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.CustSlipNoMngCd = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CustSlipNoMngCd );          // 相手伝票番号管理区分
            customerInfo.CustomerSlipNoDiv = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_CustomerSlipNoDiv );      // 得意先伝票番号区分
            customerInfo.QrcodePrtCd = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_QrcodePrtCd );     // ＱＲコード印刷区分

            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
            customerInfo.SalesSlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SalesSlipPrtDiv);       // 納品書出力
            customerInfo.AcpOdrrSlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_AcpOdrrSlipPrtDiv);     // 受注伝票出力
            customerInfo.ShipmSlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_ShipmSlipPrtDiv);       // 貸出伝票出力
            customerInfo.EstimatePrtDiv = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_EstimatePrtDiv);        // 見積伝票出力
            customerInfo.UOESlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_UOESlipPrtDiv);         // UOE伝票出力
            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

            // ADD 2009/04/07 ------>>>
            customerInfo.ReceiptOutputCode = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_ReceiptOutputCode);   // 領収書出力区分
            // ADD 2009/04/07 ------<<<

            // ADD 2009/06/03 ------>>>
            // オンライン情報
            customerInfo.OnlineKindDiv = ComboEditorItemControl.GetComboEditorValueFromText(tComboEditor_OnlineKindDiv);    // オンライン接続方法
            customerInfo.CustomerEpCode = this.tEdit_CustomerEpCode.Text;   // 得意先企業コード
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            customerInfo.SimplInqAcntAcntGrId = this.tEdit_SimplInqAcntAcntGrId.Text.Trim();    // 簡単問合せアカウントグループID
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            customerInfo.CustomerSecCode = this.tEdit_CustomerSecCode.Text; // 得意先拠点コード
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            customerInfo.TotalBillOutputDiv = ComboEditorItemControl.GetComboEditorValueFromText(tComboEditor_TotalBillOutputDiv);      //合計請求書出力区分
            customerInfo.DetailBillOutputCode = ComboEditorItemControl.GetComboEditorValueFromText(tComboEditor_DetailBillOutputCode);  //明細請求書出力区分
            customerInfo.SlipTtlBillOutputDiv = ComboEditorItemControl.GetComboEditorValueFromText(tComboEditor_SlipTtlBillOutputDiv);  //伝票合計請求書出力区分
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            // ADD 梶谷貴士 2021/05/10 --------------------------->>>>>
            if (this.check_CustomerInfoGuideDisp.Checked)
            {
                customerInfo.DisplayDivCode = (int)CustomerInfoAcs.DisplayDivCode.ShowDisplayDivCode;    //表示
            }
            else
            {
                customerInfo.DisplayDivCode = (int)CustomerInfoAcs.DisplayDivCode.HideDisplayDivCode;    //非表示
            }
            // ADD 梶谷貴士 2021/05/10 ---------------------------<<<<<
            // ADD 陳健 K2014/02/06--------------------------->>>>>
            customerInfo.NoteInfo = this.memo_richTextBox.Text;
            // ADD 陳健 K2014/02/06---------------------------<<<<<

            // 得意先種別（UI得意先種別→customerInfo仕入先区分・業販先区分）
            SetCustomerDivCd( ref customerInfo, this.tComboEditor_CustomerDivCd );

            # endregion
        }

        /// <summary>
        /// 得意先クラス→画面格納処理
        /// </summary>
        /// <param name="customerInfo">得意先オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先オブジェクトの情報を画面に表示します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>UpdateNote : 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        /// </remarks>
        private void SetDisplayFormCustomerInfo( CustomerInfo customerInfo )
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 描画停止　＞＞＞
                this.SuspendLayout();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if (customerInfo == null)
                {
                    return;
                }

                if (!customerInfo.IsReceiver)
                {
                    # region [得意先クラス(得意先)→画面]
                    this.tDateEdit_CreateDateTime.SetDateTime(customerInfo.CreateDateTime);									// 作成日
                    this.tDateEdit_UpdateDateTime.SetDateTime(customerInfo.UpdateDateTime);									// 更新日

                    this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);												// 得意先コード
                    this.tEdit_CustomerSubCode.DataText = customerInfo.CustomerSubCode;										// サブコード
                    this.tEdit_Name.DataText = customerInfo.Name;															// 得意先名称１
                    this.tEdit_Name2.DataText = customerInfo.Name2;															// 得意先名称２
                    this.tEdit_Kana.DataText = customerInfo.Kana;															// 得意先カナ
                    //this.tComboEditor_HonorificTitle.Text = customerInfo.HonorificTitle;									// 敬称
                    this.tEdit_HonorificTitle.Text = customerInfo.HonorificTitle;   // 敬称
                    this.SetComboEditorItemIndex(this.tComboEditor_OutputNameCode, customerInfo.OutputNameCode);			// 諸口
                    this.tEdit_PostNo.DataText = customerInfo.PostNo;														// 郵便番号
                    this.tEdit_Address1.DataText = customerInfo.Address1;													// 住所１
                    this.tEdit_Address3.DataText = customerInfo.Address3;													// 住所３
                    this.tEdit_Address4.DataText = customerInfo.Address4;													// 住所４
                    this.tEdit_HomeTelNo.DataText = customerInfo.HomeTelNo;													// 電話番号（自宅）
                    this.tEdit_OfficeTelNo.DataText = customerInfo.OfficeTelNo;												// 電話番号（勤務先）
                    this.tEdit_PortableTelNo.DataText = customerInfo.PortableTelNo;											// 電話番号（携帯）
                    this.tEdit_OthersTelNo.DataText = customerInfo.OthersTelNo;												// 電話番号（他）
                    this.tEdit_HomeFaxNo.DataText = customerInfo.HomeFaxNo;													// FAX（自宅）
                    this.tEdit_OfficeFaxNo.DataText = customerInfo.OfficeFaxNo;												// FAX（勤務先）
                    this.tEdit_SearchTelNo.DataText = customerInfo.SearchTelNo;												// 検索番号
                    this.SetComboEditorItemIndex(this.tComboEditor_MainContactCode, customerInfo.MainContactCode);			// 主連絡先
                    this._claimSectionCode = customerInfo.ClaimSectionCode;                                                 // 請求拠点コード
                    this.tEdit_ClaimSectionCode.Text = customerInfo.ClaimSectionName;                                       // 請求拠点名称

                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                    //this.tNedit_ClaimCode.SetInt( customerInfo.ClaimCode );                                                 // 請求先コード
                    //this.uLabel_ClaimName1.Text = customerInfo.ClaimName;                                                   // 請求先名称１
                    //this.uLabel_ClaimName2.Text = customerInfo.ClaimName2;													// 請求先名称２
                    //this.uLabel_ClaimSnm.Text = customerInfo.ClaimSnm;  													// 請求先略称
                    //this.tNedit_TotalDay.SetInt( customerInfo.TotalDay );														// 締日
                    //this.tNedit_CollectMoneyDay.SetInt( customerInfo.CollectMoneyDay );										// 集金日
                    //this.SetComboEditorItemIndex( this.tComboEditor_CollectMoneyCode, customerInfo.CollectMoneyCode );		// 集金月
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<

                    this.tEdit_CustomerAgentNm.DataText = customerInfo.CustomerAgentNm;										// 得意先担当
                    this.tEdit_BillCollecterNm.DataText = customerInfo.BillCollecterNm;										// 集金担当
                    this.SetComboEditorItemIndex(this.tComboEditor_CorporateDivCode, customerInfo.CorporateDivCode);		// 個人・法人
                    this.SetCustomerDivCdItemIndex(this.tComboEditor_CustomerDivCd, customerInfo.AcceptWholeSale);    // 得意先種別
                    this._mngSectionCode = customerInfo.MngSectionCode;                                                     // 管理拠点コード
                    this.tEdit_MngSectionNm.Text = customerInfo.MngSectionName;                                             // 管理拠点名称
                    this.tNedit_CustAnalysCode1.SetInt(customerInfo.CustAnalysCode1);										// 分析コード１
                    this.tNedit_CustAnalysCode2.SetInt(customerInfo.CustAnalysCode2);										// 分析コード２
                    this.tNedit_CustAnalysCode3.SetInt(customerInfo.CustAnalysCode3);										// 分析コード３
                    this.tNedit_CustAnalysCode4.SetInt(customerInfo.CustAnalysCode4);										// 分析コード４
                    this.tNedit_CustAnalysCode5.SetInt(customerInfo.CustAnalysCode5);										// 分析コード５
                    this.tNedit_CustAnalysCode6.SetInt(customerInfo.CustAnalysCode6);										// 分析コード６
                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                    //this.SetComboEditorItemIndex(this.tComboEditor_BusinessTypeCode, customerInfo.BusinessTypeCode);		// 業種コード
                    //this.SetComboEditorItemIndex(this.tComboEditor_JobTypeCode, customerInfo.JobTypeCode);					// 職種コード
                    //this.SetComboEditorItemIndex(this.tComboEditor_SalesAreaCode, customerInfo.SalesAreaCode);				// 販売エリアコード
                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    this.tEdit_BusinessTypeNm.DataText = customerInfo.BusinessTypeName;                                     // 業種コード
                    this._businessTypeCd = customerInfo.BusinessTypeCode;
                    this.tEdit_JobTypeName.DataText = customerInfo.JobTypeName;                                             // 職種コード
                    this._jobTypeCode = customerInfo.JobTypeCode;
                    this.tEdit_SalesAreaNm.DataText = customerInfo.SalesAreaName;                                           // 販売エリアコード
                    this._saleAreaCd = customerInfo.SalesAreaCode;
                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                    this._custWarehouseCode = customerInfo.CustWarehouseCd;                                                 // 得意先優先倉庫コード
                    this.tEdit_CustWarehouseCd.Text = customerInfo.CustWarehouseName;                                       // 得意先優先倉庫名称
                    this.uLabel_HomeTelNoDspName.Text = customerInfo.HomeTelNoDspName;										// 自宅TEL表示名称
                    this.uLabel_OfficeTelNoDspName.Text = customerInfo.OfficeTelNoDspName;									// 勤務先TEL表示名称
                    this.uLabel_MobileTelNoDspName.Text = customerInfo.MobileTelNoDspName;									// 携帯TEL表示名称
                    this.uLabel_OtherTelNoDspName.Text = customerInfo.OtherTelNoDspName;									// その他TEL表示名称
                    this.uLabel_HomeFaxNoDspName.Text = customerInfo.HomeFaxNoDspName;										// 自宅FAX表示名称
                    this.uLabel_OfficeFaxNoDspName.Text = customerInfo.OfficeFaxNoDspName;									// 勤務先FAX表示名称

                    if (customerInfo.CustomerCode == customerInfo.ClaimCode)
                    {
                        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                        this.SetComboEditorItemIndex( this.tComboEditor_TotalAmntDspWayRef, customerInfo.TotalAmntDspWayRef );	// 総額表示方法参照区分
                        // 参照区分に従い分岐
                        if ( tComboEditor_TotalAmntDspWayRef.SelectedIndex == 0 )
                        {
                            // 全体設定参照
                            //if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                            //{
                            //    tComboEditor_TotalAmountDispWayCd.Enabled = false;
                            //}
                            this.SetComboEditorItemIndex( this.tComboEditor_TotalAmountDispWayCd, this._customerInputAcs.GetTotalAmountDispWayCd( this._enterpriseCode, customerInfo.MngSectionCode ) ); // 総額表示方法区分
                        }
                        else
                        {
                            // 得意先参照
                            //if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                            //{
                            //    tComboEditor_TotalAmountDispWayCd.Enabled = true;
                            //}
                            this.SetComboEditorItemIndex( this.tComboEditor_TotalAmountDispWayCd, customerInfo.TotalAmountDispWayCd );// 総額表示方法区分
                        }
                           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                        // 総額表示区分＝１：する、ならば転嫁方式は「１：得意先参照」「１：明細単位」で固定
                        if (customerInfo.TotalAmountDispWayCd == 1)
                        {
                            customerInfo.CustCTaXLayRefCd = 1;
                            customerInfo.ConsTaxLayMethod = 1;

                            //tComboEditor_CustCTaXLayRefCd.Enabled = false;
                            //tComboEditor_ConsTaxLayMethod.Enabled = false;
                        }
                        //else
                        //{
                        //    if ( customerInfo.LogicalDeleteCode == 0 )
                        //    {
                        //        if ( !customerInfo.IsReceiver )
                        //        {
                        //            if ( customerInfo.ClaimCode == customerInfo.CustomerCode )
                        //            {
                        //                tComboEditor_CustCTaXLayRefCd.Enabled = true;
                        //                tComboEditor_ConsTaxLayMethod.Enabled = true;
                        //            }
                        //        }
                        //    }
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD

                        this.SetComboEditorItemIndex(this.tComboEditor_CustCTaXLayRefCd, customerInfo.CustCTaXLayRefCd);		// 消費税転嫁方式参照区分
                        // 参照区分に従い分岐
                        if (tComboEditor_CustCTaXLayRefCd.SelectedIndex == 0)
                        {
                            // 全体設定参照
                            //if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                            //{
                            //    tComboEditor_ConsTaxLayMethod.Enabled = false;
                            //}
                            this.SetComboEditorItemIndex(this.tComboEditor_ConsTaxLayMethod, this._customerInputAcs.GetConsTaxLayMethod(this._enterpriseCode, 0));     // 消費税転嫁方式
                        }
                        else
                        {
                            // 得意先参照
                            //if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                            //{
                            //    tComboEditor_ConsTaxLayMethod.Enabled = true;
                            //}
                            this.SetComboEditorItemIndex(this.tComboEditor_ConsTaxLayMethod, customerInfo.ConsTaxLayMethod);		// 消費税転嫁方式
                        }

                        // --- ADD 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                        // DEL 2009/06/18 ------>>>
                        // ↑で設定しているので再設定不要
                        //this.SetComboEditorItemIndex(this.tComboEditor_CustCTaXLayRefCd, customerInfo.CustCTaXLayRefCd);		// 消費税転嫁方式参照区分
                        //this.SetComboEditorItemIndex(this.tComboEditor_ConsTaxLayMethod, customerInfo.ConsTaxLayMethod);		// 消費税転嫁方式
                        // DEL 2009/06/18 ------<<<
                        this.tNedit_ClaimCode.SetInt(customerInfo.ClaimCode);                                                 // 請求先コード
                        this.uLabel_ClaimName1.Text = customerInfo.ClaimName;                                                   // 請求先名称１
                        this.uLabel_ClaimName2.Text = customerInfo.ClaimName2;													// 請求先名称２
                        this.uLabel_ClaimSnm.Text = customerInfo.ClaimSnm;  													// 請求先略称
                        this.tNedit_TotalDay.SetInt(customerInfo.TotalDay);														// 締日
                        this.tNedit_CollectMoneyDay.SetInt(customerInfo.CollectMoneyDay);										// 集金日
                        this.SetComboEditorItemIndex(this.tComboEditor_CollectMoneyCode, customerInfo.CollectMoneyCode);		// 集金月

                        // --- DEL 2009/03/02 障害ID:11999対応------------------------------------------------------>>>>>
                        //this.tNedit_SalesUnPrcFrcProcCd.SetInt(customerInfo.SalesUnPrcFrcProcCd);     // 単価端数処理コード
                        //this.tNedit_SalesMoneyFrcProcCd.SetInt(customerInfo.SalesMoneyFrcProcCd);     // 金額端数処理コード
                        // --- ADD 2009/03/02 障害ID:11999対応------------------------------------------------------<<<<<

                        this.tNedit_SalesCnsTaxFrcProcCd.SetInt(customerInfo.SalesCnsTaxFrcProcCd);   // 消費税端数処理コード
                        this.SetComboEditorItemIndex(this.tComboEditor_CollectCond, customerInfo.CollectCond);                  // 回収条件
                        this.SetComboEditorItemIndex(this.tComboEditor_DepoDelCode, customerInfo.DepoDelCode);                  // 入金消込区分
                        this.tNedit_CollectSight.SetInt(customerInfo.CollectSight);                                             // 回収サイト
                        this.tNedit_NTimeCalcStDate.SetInt(customerInfo.NTimeCalcStDate);     // 次回勘定開始日
                        // --- ADD 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<
                    }
                    else
                    {
                        // 子の場合は、親からコピーした現在値の表示のみで良い
                        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                        this.SetComboEditorItemIndex( this.tComboEditor_TotalAmntDspWayRef, customerInfo.TotalAmntDspWayRef );	// 総額表示方法参照区分
                        this.SetComboEditorItemIndex( this.tComboEditor_TotalAmountDispWayCd, customerInfo.TotalAmountDispWayCd );// 総額表示方法区分
                           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

                        // --- CHG 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                        //this.SetComboEditorItemIndex( this.tComboEditor_CustCTaXLayRefCd, customerInfo.CustCTaXLayRefCd );		// 消費税転嫁方式参照区分
                        //this.SetComboEditorItemIndex( this.tComboEditor_ConsTaxLayMethod, customerInfo.ConsTaxLayMethod );		// 消費税転嫁方式

                        CustomerInfo parentCustomerInfo;
                        int status = this._customerInputAcs.ReadStaticMemoryData(out parentCustomerInfo, this._enterpriseCode, customerInfo.ClaimCode);
                        if (status == 0)
                        {
                            this.SetComboEditorItemIndex(this.tComboEditor_CustCTaXLayRefCd, parentCustomerInfo.CustCTaXLayRefCd);		// 消費税転嫁方式参照区分
                            this.SetComboEditorItemIndex(this.tComboEditor_ConsTaxLayMethod, parentCustomerInfo.ConsTaxLayMethod);		// 消費税転嫁方式
                            this.tNedit_ClaimCode.SetInt(parentCustomerInfo.ClaimCode);                                                 // 請求先コード
                            this.uLabel_ClaimName1.Text = parentCustomerInfo.ClaimName;                                                   // 請求先名称１
                            this.uLabel_ClaimName2.Text = parentCustomerInfo.ClaimName2;													// 請求先名称２
                            this.uLabel_ClaimSnm.Text = parentCustomerInfo.ClaimSnm;  													// 請求先略称
                            this.tNedit_TotalDay.SetInt(parentCustomerInfo.TotalDay);														// 締日
                            this.tNedit_CollectMoneyDay.SetInt(parentCustomerInfo.CollectMoneyDay);										// 集金日
                            this.SetComboEditorItemIndex(this.tComboEditor_CollectMoneyCode, parentCustomerInfo.CollectMoneyCode);		// 集金月
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                            //this.tNedit_SalesUnPrcFrcProcCd.SetInt(parentCustomerInfo.SalesUnPrcFrcProcCd);     // 単価端数処理コード
                            //this.tNedit_SalesMoneyFrcProcCd.SetInt(parentCustomerInfo.SalesMoneyFrcProcCd);     // 金額端数処理コード
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                            this.tNedit_SalesCnsTaxFrcProcCd.SetInt(parentCustomerInfo.SalesCnsTaxFrcProcCd);   // 消費税端数処理コード
                            this.SetComboEditorItemIndex(this.tComboEditor_CollectCond, parentCustomerInfo.CollectCond);                  // 回収条件
                            this.SetComboEditorItemIndex(this.tComboEditor_DepoDelCode, parentCustomerInfo.DepoDelCode);                  // 入金消込区分
                            this.tNedit_CollectSight.SetInt(parentCustomerInfo.CollectSight);                                             // 回収サイト
                            this.tNedit_NTimeCalcStDate.SetInt(parentCustomerInfo.NTimeCalcStDate);     // 次回勘定開始日
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                            this.SetComboEditorItemIndex(this.tComboEditor_CreditMngCode, parentCustomerInfo.CreditMngCode); // 与信管理区分
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                        }
                        else
                        {
                            this.SetComboEditorItemIndex(this.tComboEditor_CustCTaXLayRefCd, customerInfo.CustCTaXLayRefCd);		// 消費税転嫁方式参照区分
                            this.SetComboEditorItemIndex(this.tComboEditor_ConsTaxLayMethod, customerInfo.ConsTaxLayMethod);		// 消費税転嫁方式
                            this.tNedit_ClaimCode.SetInt(customerInfo.ClaimCode);                                                 // 請求先コード
                            this.uLabel_ClaimName1.Text = customerInfo.ClaimName;                                                   // 請求先名称１
                            this.uLabel_ClaimName2.Text = customerInfo.ClaimName2;													// 請求先名称２
                            this.uLabel_ClaimSnm.Text = customerInfo.ClaimSnm;  													// 請求先略称
                            this.tNedit_TotalDay.SetInt(customerInfo.TotalDay);														// 締日
                            this.tNedit_CollectMoneyDay.SetInt(customerInfo.CollectMoneyDay);										// 集金日
                            this.SetComboEditorItemIndex(this.tComboEditor_CollectMoneyCode, customerInfo.CollectMoneyCode);		// 集金月
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                            //this.tNedit_SalesUnPrcFrcProcCd.SetInt(customerInfo.SalesUnPrcFrcProcCd);     // 単価端数処理コード
                            //this.tNedit_SalesMoneyFrcProcCd.SetInt(customerInfo.SalesMoneyFrcProcCd);     // 金額端数処理コード
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                            this.tNedit_SalesCnsTaxFrcProcCd.SetInt(customerInfo.SalesCnsTaxFrcProcCd);   // 消費税端数処理コード
                            this.SetComboEditorItemIndex(this.tComboEditor_CollectCond, customerInfo.CollectCond);                  // 回収条件
                            this.SetComboEditorItemIndex(this.tComboEditor_DepoDelCode, customerInfo.DepoDelCode);                  // 入金消込区分
                            this.tNedit_CollectSight.SetInt(customerInfo.CollectSight);                                             // 回収サイト
                            this.tNedit_NTimeCalcStDate.SetInt(customerInfo.NTimeCalcStDate);     // 次回勘定開始日
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                            this.SetComboEditorItemIndex(this.tComboEditor_CreditMngCode, customerInfo.CreditMngCode); // 与信管理区分
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                        }
                        // --- CHG 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<
                    }

                    this.SetComboEditorItemIndex(this.tComboEditor_CustomerAttributeDiv, customerInfo.CustomerAttributeDiv);// 得意先属性区分 

                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                    //this.SetComboEditorItemIndex( this.tComboEditor_CollectCond, customerInfo.CollectCond );                  // 回収条件
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<

                    this.SetComboEditorItemIndex(this.tComboEditor_CreditMngCode, customerInfo.CreditMngCode);              // 与信管理区分

                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                    //this.SetComboEditorItemIndex( this.tComboEditor_DepoDelCode, customerInfo.DepoDelCode );                  // 入金消込区分
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<

                    this.SetComboEditorItemIndex(this.tComboEditor_AccRecDivCd, customerInfo.AccRecDivCd);                  // 売掛区分
                    this.SetComboEditorItemIndex(this.tComboEditor_CustSlipNoMngCd, customerInfo.CustSlipNoMngCd);          // 相手伝票番号管理区分
                    this.SetComboEditorItemIndex(this.tComboEditor_CustomerSlipNoDiv, customerInfo.CustomerSlipNoDiv);      // 得意先伝票番号区分
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
                    //this.SetComboEditorItemIndex( this.tComboEditor_PureCode, customerInfo.PureCode );                        // 純正区分
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL

                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                    //this.tNedit_SalesUnPrcFrcProcCd.SetInt(customerInfo.SalesUnPrcFrcProcCd);     // 単価端数処理コード
                    //this.tNedit_SalesMoneyFrcProcCd.SetInt( customerInfo.SalesMoneyFrcProcCd );     // 金額端数処理コード
                    //this.tNedit_SalesCnsTaxFrcProcCd.SetInt( customerInfo.SalesCnsTaxFrcProcCd );   // 消費税端数処理コード
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<

                    // --- ADD 2009/03/02 障害ID:11999対応------------------------------------------------------>>>>>
                    this.tNedit_SalesUnPrcFrcProcCd.SetInt(customerInfo.SalesUnPrcFrcProcCd);     // 単価端数処理コード
                    this.tNedit_SalesMoneyFrcProcCd.SetInt(customerInfo.SalesMoneyFrcProcCd);     // 金額端数処理コード
                    // --- ADD 2009/03/02 障害ID:11999対応------------------------------------------------------<<<<<

                    this.tEdit_CustomerSnm.Text = customerInfo.CustomerSnm;                                                 // 得意先略称

                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                    //this.tNedit_CollectSight.SetInt( customerInfo.CollectSight );                                             // 回収サイト
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<

                    this.tDateEdit_TransStopDate.SetDateTime(customerInfo.TransStopDate);                                 // 取引中止日
                    this.tDateEdit_CustAgentChgDate.SetDateTime(customerInfo.CustAgentChgDate);                           // 顧客担当変更日
                    this.tEdit_OldCustomerAgentNm.DataText = customerInfo.OldCustomerAgentNm;                               // 旧得意先担当
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------>>>>>
                    //this.tNedit_NTimeCalcStDate.SetInt( customerInfo.NTimeCalcStDate );     // 次回勘定開始日
                    // --- DEL 2009/02/05 障害ID:9388対応------------------------------------------------------<<<<<
                    this.tEdit_CustomerAgent.DataText = customerInfo.CustomerAgent;         // 得意先担当者（相手側）
                    this.SetComboEditorItemIndex(this.tComboEditor_CarMngDivCd, customerInfo.CarMngDivCd);    // 車輌管理区分
                    this.SetComboEditorItemIndex(this.tComboEditor_QrcodePrtCd, customerInfo.QrcodePrtCd);    // ＱＲコード印刷区分

                    // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
                    this.SetComboEditorItemIndex(this.tComboEditor_SalesSlipPrtDiv, customerInfo.SalesSlipPrtDiv);      // 納品書出力区分
                    this.SetComboEditorItemIndex(this.tComboEditor_AcpOdrrSlipPrtDiv, customerInfo.AcpOdrrSlipPrtDiv);  // 受注伝票出力区分
                    this.SetComboEditorItemIndex(this.tComboEditor_ShipmSlipPrtDiv, customerInfo.ShipmSlipPrtDiv);      // 貸出伝票出力区分
                    this.SetComboEditorItemIndex(this.tComboEditor_EstimatePrtDiv, customerInfo.EstimatePrtDiv);        // 見積伝票出力区分
                    this.SetComboEditorItemIndex(this.tComboEditor_UOESlipPrtDiv, customerInfo.UOESlipPrtDiv);          // UOE伝票出力区分
                    // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

                    // 備考情報Ｔａｂ
                    this.tEdit_Note1.DataText = customerInfo.Note1;											// 備考１
                    this.tEdit_Note2.DataText = customerInfo.Note2;											// 備考２
                    this.tEdit_Note3.DataText = customerInfo.Note3;											// 備考３
                    this.tEdit_Note4.DataText = customerInfo.Note4;											// 備考４
                    this.tEdit_Note5.DataText = customerInfo.Note5;											// 備考５
                    this.tEdit_Note6.DataText = customerInfo.Note6;											// 備考６
                    this.tEdit_Note7.DataText = customerInfo.Note7;											// 備考７
                    this.tEdit_Note8.DataText = customerInfo.Note8;											// 備考８
                    this.tEdit_Note9.DataText = customerInfo.Note9;											// 備考９
                    this.tEdit_Note10.DataText = customerInfo.Note10;										// 備考１０

                    // Ｅメール情報Ｔａｂ
                    this.SetComboEditorItemIndex(this.tComboEditor_MailAddrKindCode1, customerInfo.MailAddrKindCode1);		// メールアドレス種別コード１
                    this.tEdit_MailAddress1.DataText = customerInfo.MailAddress1;											// メールアドレス１
                    this.SetComboEditorItemIndex(this.tComboEditor_MailSendCode1, customerInfo.MailSendCode1);				// メール送信区分コード１
                    this.SetComboEditorItemIndex(this.tComboEditor_MailAddrKindCode2, customerInfo.MailAddrKindCode2);		// メールアドレス種別コード２
                    this.tEdit_MailAddress2.DataText = customerInfo.MailAddress2;											// メールアドレス２
                    this.SetComboEditorItemIndex(this.tComboEditor_MailSendCode2, customerInfo.MailSendCode2);				// メール送信区分コード２
                    if (customerInfo.MainSendMailAddrCd > 0)
                    {
                        rButton_MainSendMailAddrCd0.Checked = false;
                        rButton_MainSendMailAddrCd1.Checked = true;
                    }
                    else
                    {
                        rButton_MainSendMailAddrCd0.Checked = true;
                        rButton_MainSendMailAddrCd1.Checked = false;
                    }


                    // 口座情報
                    this.tEdit_AccountNoInfo1.Text = customerInfo.AccountNoInfo1;
                    this.tEdit_AccountNoInfo2.Text = customerInfo.AccountNoInfo2;
                    this.tEdit_AccountNoInfo3.Text = customerInfo.AccountNoInfo3;

                    if (customerInfo.CustomerCode == 0) this.tNedit_CustomerCode.Clear();									// 得意先コード
                    if (customerInfo.TotalDay == 0) this.tNedit_TotalDay.Clear();											// 締日
                    if (customerInfo.CollectMoneyDay == 0) this.tNedit_CollectMoneyDay.Clear();								// 集金日
                    if (customerInfo.CustAnalysCode1 == 0) this.tNedit_CustAnalysCode1.Clear();								// 分析コード１
                    if (customerInfo.CustAnalysCode2 == 0) this.tNedit_CustAnalysCode2.Clear();								// 分析コード２
                    if (customerInfo.CustAnalysCode3 == 0) this.tNedit_CustAnalysCode3.Clear();								// 分析コード３
                    if (customerInfo.CustAnalysCode4 == 0) this.tNedit_CustAnalysCode4.Clear();								// 分析コード４
                    if (customerInfo.CustAnalysCode5 == 0) this.tNedit_CustAnalysCode5.Clear();								// 分析コード５
                    if (customerInfo.CustAnalysCode6 == 0) this.tNedit_CustAnalysCode6.Clear();								// 分析コード６

                    // 伝票・請求書情報
                    // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
                    //this.SetComboEditorItemIndex( this.tComboEditor_BillOutputCode, customerInfo.BillOutputCode );                   // 請求書出力
                    // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
                    this.SetComboEditorItemIndex(this.tComboEditor_DmOutCode, customerInfo.DmOutCode);						// DM出力区分
                    // ADD 梶谷貴士 2021/05/10 --------------------------->>>>>
                    if (customerInfo.DisplayDivCode == (int)CustomerInfoAcs.DisplayDivCode.ShowDisplayDivCode)
                    {
                        this.check_CustomerInfoGuideDisp.Checked = true;
                    }
                    else
                    {
                        this.check_CustomerInfoGuideDisp.Checked = false;
                    }
                    // ADD 梶谷貴士 2021/05/10 ---------------------------<<<<<
                    // ADD 陳健 K2014/02/06--------------------------->>>>>
                    this.memo_richTextBox.Text = customerInfo.NoteInfo;
                    // ADD 陳健 K2014/02/06---------------------------<<<<<

                    // ADD 2009/04/07 ------>>>
                    this.SetComboEditorItemIndex(this.tComboEditor_ReceiptOutputCode, customerInfo.ReceiptOutputCode);  // 領収書出力区分
                    // ADD 2009/04/07 ------<<<

                    // ADD 2009/06/03 ------>>>
                    // オンライン情報
                    this.SetComboEditorItemIndex(this.tComboEditor_OnlineKindDiv, customerInfo.OnlineKindDiv);  // オンライン接続方法
                    this.tEdit_CustomerEpCode.Text = customerInfo.CustomerEpCode;   // 得意先企業コード
                    // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                    this.tEdit_SimplInqAcntAcntGrId.Text = customerInfo.SimplInqAcntAcntGrId;   // 簡単問合せアカウントグループID
                    // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
                    this.tEdit_CustomerSecCode.Text = customerInfo.CustomerSecCode.Trim();  // 得意先拠点コード
                    // ADD 2009/06/03 ------<<<
                    // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                    this.SetComboEditorItemIndex(this.tComboEditor_TotalBillOutputDiv, customerInfo.TotalBillOutputDiv);　　　//合計請求書出力区分
                    this.SetComboEditorItemIndex(this.tComboEditor_DetailBillOutputCode, customerInfo.DetailBillOutputCode);  //明細請求書出力区分
                    this.SetComboEditorItemIndex(this.tComboEditor_SlipTtlBillOutputDiv, customerInfo.SlipTtlBillOutputDiv);  //伝票合計請求書出力区分
                    // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                    # endregion
                }
                else
                {
                    # region [得意先クラス(納入先)→画面]

                    // 納入先情報
                    this.tDateEdit_CreateDateTime.SetDateTime(customerInfo.CreateDateTime);									// 作成日
                    this.tDateEdit_UpdateDateTime.SetDateTime(customerInfo.UpdateDateTime);									// 更新日
                    this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);												// 得意先コード
                    this.tEdit_Name.DataText = customerInfo.Name;															// 得意先名称１
                    this.tEdit_Name2.DataText = customerInfo.Name2;															// 得意先名称２
                    this.tEdit_PostNo.DataText = customerInfo.PostNo;														// 郵便番号
                    this.tEdit_Address1.DataText = customerInfo.Address1;													// 住所１
                    this.tEdit_Address3.DataText = customerInfo.Address3;													// 住所３
                    this.tEdit_Address4.DataText = customerInfo.Address4;													// 住所４
                    this.tEdit_OfficeTelNo.DataText = customerInfo.OfficeTelNo;												// 電話番号（勤務先）
                    this.tEdit_OfficeFaxNo.DataText = customerInfo.OfficeFaxNo;												// FAX（勤務先）
                    this.SetCustomerDivCdItemIndex(this.tComboEditor_CustomerDivCd, customerInfo.AcceptWholeSale);    // 得意先種別

                    // 表示名称（タイトル）
                    this.uLabel_HomeTelNoDspName.Text = customerInfo.HomeTelNoDspName;										// 自宅TEL表示名称
                    this.uLabel_OfficeTelNoDspName.Text = customerInfo.OfficeTelNoDspName;									// 勤務先TEL表示名称
                    this.uLabel_MobileTelNoDspName.Text = customerInfo.MobileTelNoDspName;									// 携帯TEL表示名称
                    this.uLabel_OtherTelNoDspName.Text = customerInfo.OtherTelNoDspName;									// その他TEL表示名称
                    this.uLabel_HomeFaxNoDspName.Text = customerInfo.HomeFaxNoDspName;										// 自宅FAX表示名称
                    this.uLabel_OfficeFaxNoDspName.Text = customerInfo.OfficeFaxNoDspName;									// 勤務先FAX表示名称

                    // 主連絡先
                    rButton_MainSendMailAddrCd0.Checked = true;     // 主連絡先（メールアドレス１）
                    rButton_MainSendMailAddrCd1.Checked = false;    // 主連絡先（メールアドレス２）

                    // 表示補正
                    if (customerInfo.CustomerCode == 0) this.tNedit_CustomerCode.Clear();									// 得意先コード

                    # region [（納入先のとき入力不可項目クリア）]
                    this.tEdit_CustomerSubCode.DataText = string.Empty;										// サブコード
                    this.tEdit_Kana.DataText = string.Empty;															// 得意先カナ
                    this.tEdit_HonorificTitle.Text = string.Empty;   // 敬称
                    this.tEdit_HomeTelNo.DataText = string.Empty;													// 電話番号（自宅）
                    this.tEdit_PortableTelNo.DataText = string.Empty;											// 電話番号（携帯）
                    this.tEdit_OthersTelNo.DataText = string.Empty;												// 電話番号（他）
                    this.tEdit_HomeFaxNo.DataText = string.Empty;													// FAX（自宅）
                    this.tEdit_SearchTelNo.DataText = string.Empty;												// 検索番号
                    this._claimSectionCode = string.Empty;                                                 // 請求拠点コード
                    this.tEdit_ClaimSectionCode.Text = string.Empty;                                       // 請求拠点名称
                    this.tNedit_ClaimCode.Clear();                                                 // 請求先コード
                    this.uLabel_ClaimName1.Text = string.Empty;                                                   // 請求先名称１
                    this.uLabel_ClaimName2.Text = string.Empty;													// 請求先名称２
                    this.uLabel_ClaimSnm.Text = string.Empty;  													// 請求先略称
                    this.tNedit_TotalDay.Clear();														// 締日
                    this.tNedit_CollectMoneyDay.Clear();										// 集金日
                    this.tEdit_CustomerAgentNm.DataText = string.Empty;										// 得意先担当
                    this.tEdit_BillCollecterNm.DataText = string.Empty;										// 集金担当
                    this._mngSectionCode = string.Empty;                                                     // 管理拠点コード
                    this.tEdit_MngSectionNm.Text = string.Empty;                                             // 管理拠点名称
                    this.tNedit_CustAnalysCode1.Clear();										// 分析コード１
                    this.tNedit_CustAnalysCode2.Clear();										// 分析コード２
                    this.tNedit_CustAnalysCode3.Clear();										// 分析コード３
                    this.tNedit_CustAnalysCode4.Clear();										// 分析コード４
                    this.tNedit_CustAnalysCode5.Clear();										// 分析コード５
                    this.tNedit_CustAnalysCode6.Clear();										// 分析コード６
                    this._custWarehouseCode = string.Empty;                                                 // 得意先優先倉庫コード
                    this.tEdit_CustWarehouseCd.Text = string.Empty;                                       // 得意先優先倉庫名称
                    this.tNedit_SalesUnPrcFrcProcCd.Clear();     // 単価端数処理コード
                    this.tNedit_SalesMoneyFrcProcCd.Clear();     // 金額端数処理コード
                    this.tNedit_SalesCnsTaxFrcProcCd.Clear();   // 消費税端数処理コード
                    this.tEdit_CustomerSnm.Text = string.Empty;                                                 // 得意先略称
                    this.tNedit_CollectSight.Clear();                                             // 回収サイト
                    this.tDateEdit_TransStopDate.SetDateTime(DateTime.MinValue);                                 // 取引中止日
                    this.tDateEdit_CustAgentChgDate.SetDateTime(DateTime.MinValue);                           // 顧客担当変更日
                    this.tEdit_OldCustomerAgentNm.DataText = string.Empty;                               // 旧得意先担当
                    this.tNedit_NTimeCalcStDate.Clear();     // 次回勘定開始日
                    this.tEdit_CustomerAgent.DataText = string.Empty;         // 得意先担当者（相手側）
                    this.tEdit_Note1.DataText = string.Empty;											// 備考１
                    this.tEdit_Note2.DataText = string.Empty;											// 備考２
                    this.tEdit_Note3.DataText = string.Empty;											// 備考３
                    this.tEdit_Note4.DataText = string.Empty;											// 備考４
                    this.tEdit_Note5.DataText = string.Empty;											// 備考５
                    this.tEdit_Note6.DataText = string.Empty;											// 備考６
                    this.tEdit_Note7.DataText = string.Empty;											// 備考７
                    this.tEdit_Note8.DataText = string.Empty;											// 備考８
                    this.tEdit_Note9.DataText = string.Empty;											// 備考９
                    this.tEdit_Note10.DataText = string.Empty;										// 備考１０
                    this.tEdit_MailAddress1.DataText = string.Empty;											// メールアドレス１
                    this.tEdit_MailAddress2.DataText = string.Empty;											// メールアドレス２
                    this.tEdit_AccountNoInfo1.Text = string.Empty;
                    this.tEdit_AccountNoInfo2.Text = string.Empty;
                    this.tEdit_AccountNoInfo3.Text = string.Empty;
                    // ADD 梶谷貴士 2021/05/10 ------------------------------>>>>>>
                    this.check_CustomerInfoGuideDisp.Checked = false;
                    // ADD 梶谷貴士 2021/05/10 ------------------------------<<<<<<
                    // ADD 陳健 K2014/02/06 ------------------------------>>>>>>
                    this.memo_richTextBox.Text = string.Empty;
                    // ADD 陳健 K2014/02/06 ------------------------------<<<<<<
                    this.ClearComboEditorItemIndex(this.tComboEditor_OutputNameCode, customerInfo.OutputNameCode);			// 諸口
                    this.ClearComboEditorItemIndex(this.tComboEditor_MainContactCode, customerInfo.MainContactCode);			// 主連絡先
                    this.ClearComboEditorItemIndex(this.tComboEditor_CollectMoneyCode, customerInfo.CollectMoneyCode);		// 集金月
                    this.ClearComboEditorItemIndex(this.tComboEditor_CorporateDivCode, customerInfo.CorporateDivCode);		// 個人・法人
                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                    //this.ClearComboEditorItemIndex(this.tComboEditor_BusinessTypeCode, customerInfo.BusinessTypeCode);		// 業種コード
                    //this.ClearComboEditorItemIndex(this.tComboEditor_JobTypeCode, customerInfo.JobTypeCode);					// 職種コード
                    //this.ClearComboEditorItemIndex(this.tComboEditor_SalesAreaCode, customerInfo.SalesAreaCode);				// 販売エリアコード
                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    this.tEdit_BusinessTypeNm.DataText = string.Empty;                                                      // 業種コード
                    this._businessTypeCd = 0;
                    this.tEdit_JobTypeName.DataText = string.Empty;                                                         // 職種コード
                    this._jobTypeCode = 0;
                    this.tEdit_SalesAreaNm.DataText = string.Empty;                                                         // 販売エリアコード
                    this._saleAreaCd = 0;
                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                    this.ClearComboEditorItemIndex(this.tComboEditor_CustCTaXLayRefCd, customerInfo.CustCTaXLayRefCd);		// 消費税転嫁方式参照区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_ConsTaxLayMethod, customerInfo.ConsTaxLayMethod);		// 消費税転嫁方式
                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    this.ClearComboEditorItemIndex( this.tComboEditor_TotalAmntDspWayRef, customerInfo.TotalAmntDspWayRef );	// 総額表示方法参照区分
                    this.ClearComboEditorItemIndex( this.tComboEditor_TotalAmountDispWayCd, customerInfo.TotalAmountDispWayCd );// 総額表示方法区分
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                    this.ClearComboEditorItemIndex(this.tComboEditor_CustomerAttributeDiv, customerInfo.CustomerAttributeDiv);// 得意先属性区分 
                    this.ClearComboEditorItemIndex(this.tComboEditor_CollectCond, customerInfo.CollectCond);                  // 回収条件
                    this.ClearComboEditorItemIndex(this.tComboEditor_CreditMngCode, customerInfo.CreditMngCode);              // 与信管理区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_DepoDelCode, customerInfo.DepoDelCode);                  // 入金消込区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_AccRecDivCd, customerInfo.AccRecDivCd);                  // 売掛区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_CustSlipNoMngCd, customerInfo.CustSlipNoMngCd);          // 相手伝票番号管理区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_CustomerSlipNoDiv, customerInfo.CustomerSlipNoDiv);      // 得意先伝票番号区分
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
                    //this.ClearComboEditorItemIndex( this.tComboEditor_PureCode, customerInfo.PureCode );                        // 純正区分
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
                    this.ClearComboEditorItemIndex(this.tComboEditor_CarMngDivCd, customerInfo.CarMngDivCd);    // 車輌管理区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_QrcodePrtCd, customerInfo.QrcodePrtCd);    // ＱＲコード印刷区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_MailAddrKindCode1, customerInfo.MailAddrKindCode1);		// メールアドレス種別コード１
                    this.ClearComboEditorItemIndex(this.tComboEditor_MailSendCode1, customerInfo.MailSendCode1);				// メール送信区分コード１
                    this.ClearComboEditorItemIndex(this.tComboEditor_MailAddrKindCode2, customerInfo.MailAddrKindCode2);		// メールアドレス種別コード２
                    this.ClearComboEditorItemIndex(this.tComboEditor_MailSendCode2, customerInfo.MailSendCode2);				// メール送信区分コード２
                    // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
                    //this.ClearComboEditorItemIndex( this.tComboEditor_BillOutputCode, customerInfo.BillOutputCode );			// 請求書出力
                    // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
                    this.ClearComboEditorItemIndex(this.tComboEditor_DmOutCode, customerInfo.DmOutCode);						// DM出力区分

                    // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
                    this.ClearComboEditorItemIndex(this.tComboEditor_SalesSlipPrtDiv, customerInfo.SalesSlipPrtDiv);        // ＱＲコード印刷区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_AcpOdrrSlipPrtDiv, customerInfo.AcpOdrrSlipPrtDiv);    // ＱＲコード印刷区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_ShipmSlipPrtDiv, customerInfo.ShipmSlipPrtDiv);        // ＱＲコード印刷区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_EstimatePrtDiv, customerInfo.EstimatePrtDiv);          // ＱＲコード印刷区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_UOESlipPrtDiv, customerInfo.UOESlipPrtDiv);            // ＱＲコード印刷区分
                    // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

                    // ADD 2009/04/07 ------>>>
                    this.ClearComboEditorItemIndex(this.tComboEditor_ReceiptOutputCode, customerInfo.ReceiptOutputCode);    // 領収書出力区分
                    // ADD 2009/04/07 ------<<<

                    // ADD 2009/06/03 ------>>>
                    // オンライン情報
                    this.ClearComboEditorItemIndex(this.tComboEditor_OnlineKindDiv, customerInfo.OnlineKindDiv);    // オンライン接続方法
                    this.tEdit_CustomerEpCode.Text = customerInfo.CustomerEpCode;  // 得意先企業コード
                    // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                    this.tEdit_SimplInqAcntAcntGrId.Text = customerInfo.SimplInqAcntAcntGrId;   // 簡単問合せアカウントグループID
                    // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
                    this.tEdit_CustomerSecCode.Text = customerInfo.CustomerSecCode; // 得意先拠点コード
                    // ADD 2009/06/03 ------<<<
                    // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                    this.ClearComboEditorItemIndex(this.tComboEditor_TotalBillOutputDiv, customerInfo.TotalBillOutputDiv);      //合計請求書出力区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_DetailBillOutputCode, customerInfo.DetailBillOutputCode);  //明細請求書出力区分
                    this.ClearComboEditorItemIndex(this.tComboEditor_SlipTtlBillOutputDiv, customerInfo.SlipTtlBillOutputDiv);  //伝票合計請求書出力区分
                    // --- ADD  大矢睦美  2010/01/04 ----------<<<<<

                    # endregion

                    # endregion
                }

                // その他
                if (customerInfo.UpdateDateTime == DateTime.MinValue)
                {
                    this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;													// 入力モード（新規）
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                    //this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;												// 入力モード（更新）
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                    if (customerInfo.LogicalDeleteCode == 0)
                    {
                        this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;												// 入力モード（更新）
                    }
                    else
                    {
                        this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;												// 入力モード（削除済）
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                }

                // 入力スタイル変更処理
                this.InputStyleChange(Convert.ToInt32(this.uButton_StyleChange.Tag));

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// --- DEL 2008/09/04 -------------------------------->>>>>
                ////SetInputEnabledByCustomerDivCd( customerInfo.AcceptWholeSale);
                //// --- DEL 2008/09/04 --------------------------------<<<<<
                //// --- ADD 2008/09/04 -------------------------------->>>>>
                //// 入力項目の入力可否設定
                //SetInputEnabledByCustomerDivCd( customerInfo.AcceptWholeSale, customerInfo.LogicalDeleteCode );
                //// --- ADD 2008/09/04 -------------------------------->>>>>
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 削除済み表示更新(or解除)
                SetInputEnabledByLogicalDeleteCode(customerInfo.LogicalDeleteCode);

                if (customerInfo.LogicalDeleteCode == 0)
                {
                    // 得意先or納入先の区分に従い表示
                    SetInputEnabledByCustomerDivCd(customerInfo.AcceptWholeSale);

                    if (!customerInfo.IsReceiver)
                    {
                        bool isParent = (customerInfo.ClaimCode == customerInfo.CustomerCode);

                        // 親・子判断による表示更新
                        SetInputEnabledByParent(isParent);

                        // 総額表示・転嫁方式設定
                        if (isParent)
                        {
                            SetInputEnabledByTotalAmount();
                        }
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                this._beforeName = customerInfo.Name;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            finally
            {
                // 描画再開　＜＜＜
                this.ResumeLayout();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// コンボボックスアイテムクリア（納入先の場合の非表示用）
        /// </summary>
        /// <param name="tComboEditor"></param>
        /// <param name="p"></param>
        private void ClearComboEditorItemIndex( TComboEditor tComboEditor, int p )
        {
            tComboEditor.SelectedIndex = -1;
            tComboEditor.Text = string.Empty;
        }
        /// <summary>
        /// 論理削除区分による画面項目入力可否制御
        /// </summary>
        /// <param name="logicalDeleteCode"></param>
        /// <remarks>
        /// <br>Update Note: 2008.09.04 30452 上野 俊治</br>
        /// <br>            論理削除区分による制御追加</br>
        /// <br>Update Note: 2014/03/10 陳健</br>
        /// <br>            論理削除モードでコントロールの制御</br>
        /// </remarks>
        private void SetInputEnabledByLogicalDeleteCode( int logicalDeleteCode )
        {
            // --- ADD 2008/09/04 -------------------------------->>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            bool inputEnabled = (logicalDeleteCode == 0);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 既にfalse変更済みならば迂回 (得意先コードで判断)
            if ( this.tNedit_CustomerCode.Enabled == inputEnabled )
            {
                return;
            }

            // 対象コントロール一覧生成
            ArrayList falseCtrlList = new ArrayList();
            falseCtrlList.AddRange( this.Container_Panel.Controls );
            falseCtrlList.AddRange( this.panel_SubInfo0.Controls );
            falseCtrlList.AddRange( this.panel_SubInfo2.Controls );
            falseCtrlList.AddRange( this.panel_SubInfo4.Controls );
            falseCtrlList.AddRange( this.panel_SubInfo5.Controls );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            falseCtrlList.AddRange( this.panel_SubInfo6.Controls );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            falseCtrlList.AddRange( this.panel_SubInfo7.Controls );     // ADD 2009/06/03
            // ADD 陳健 K2014/02/06 ------------------------------------------>>>>>
            falseCtrlList.AddRange( this.panel_SubInfo8.Controls );
            // ADD 陳健 K2014/02/06 ------------------------------------------<<<<<

            // 全コントロール使用不可
            foreach ( Control ctrl in falseCtrlList )
            {
                // UPD 陳健 2014/03/10 ---------------------------------------------------------------->>>>>
                //if ( ctrl is TEdit || ctrl is TComboEditor || ctrl is TDateEdit || ctrl is Infragistics.Win.Misc.UltraButton || ctrl is Infragistics.Win.UltraWinEditors.UltraOptionSet || ctrl is RadioButton )
                if ( ctrl is TEdit || ctrl is TComboEditor || ctrl is TDateEdit || ctrl is Infragistics.Win.Misc.UltraButton || ctrl is Infragistics.Win.UltraWinEditors.UltraOptionSet || ctrl is RadioButton || ctrl is RichTextBox )
                // UPD 陳健 2014/03/10 ----------------------------------------------------------------<<<<<
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //ctrl.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    ctrl.Enabled = inputEnabled;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }

            // --- ADD 2008/09/04 --------------------------------<<<<<
        }

        /// <summary>
        /// 得意先種別区分（仕入先区分・業販先区分）による画面項目入力可否制御
        /// </summary>
        /// <param name="acceptWholeSale"></param>
        private void SetInputEnabledByCustomerDivCd( int acceptWholeSale　)
        {
            bool inputEnabled;

            if ( acceptWholeSale == 2 )
            {
                // 納入先の場合は入力不可
                inputEnabled = false;
            }
            else
            {
                // それ以外は入力可
                inputEnabled = true;
            }

            // 既にEnabled変更済みならば迂回（得意先サブコードで判定）
            if ( this.tEdit_CustomerSubCode.Enabled == inputEnabled )
            {
                return;
            }

            // 対象コントロール一覧生成
            ArrayList ctrlList = new ArrayList();
            ctrlList.AddRange( this.Container_Panel.Controls );
            ctrlList.AddRange( this.panel_SubInfo0.Controls );
            ctrlList.AddRange( this.panel_SubInfo2.Controls );
            ctrlList.AddRange( this.panel_SubInfo4.Controls );
            ctrlList.AddRange( this.panel_SubInfo5.Controls );
            ctrlList.AddRange( this.panel_SubInfo6.Controls );
            ctrlList.AddRange( this.panel_SubInfo7.Controls );  // ADD 2009/06/03

            // 対象外コントロール一覧生成
            ArrayList excludeList = new ArrayList();
            // (データ的に、納入先でも使用する項目)
            excludeList.Add( this.tNedit_CustomerCode );
            excludeList.Add( this.tEdit_Name );
            excludeList.Add( this.tEdit_Name2 );
            excludeList.Add( this.tEdit_PostNo );
            excludeList.Add( this.tEdit_Address1 );
            excludeList.Add( this.tNedit_Address2 );
            excludeList.Add( this.tEdit_Address3 );
            excludeList.Add( this.tEdit_Address4 );
            excludeList.Add( this.tEdit_OfficeTelNo );
            excludeList.Add( this.tEdit_OfficeFaxNo );
            excludeList.Add( this.uLabel_ClaimName2 );
            excludeList.Add( this.uLabel_ClaimSnm );
            // (ＵＩ上の都合で、納入先でも使用する項目)
            excludeList.Add( this.tComboEditor_CustomerDivCd );
            excludeList.Add( this.tDateEdit_CreateDateTime );
            excludeList.Add( this.tDateEdit_UpdateDateTime );
            excludeList.Add( this.uButton_AddressGuide );


            // 対象コントロールのEnabledを設定
            foreach ( Control ctrl in ctrlList )
            {
                // 「納入先」かどうかによらず常に入力可能な項目は除外
                if ( excludeList.Contains( ctrl ) ) continue;

                if ( ctrl is TEdit || ctrl is TComboEditor || ctrl is TDateEdit || ctrl is Infragistics.Win.Misc.UltraButton || ctrl is Infragistics.Win.UltraWinEditors.UltraOptionSet || ctrl is RadioButton )
                {
                    ctrl.Enabled = inputEnabled;
                }

                if ( inputEnabled == false )
                {
                    // クリア
                    if ( ctrl is TEdit ) (ctrl as TEdit).DataText = string.Empty;
                    if ( ctrl is TDateEdit ) (ctrl as TDateEdit).SetDateTime( DateTime.MinValue );
                    if ( ctrl is Infragistics.Win.UltraWinEditors.UltraOptionSet ) (ctrl as Infragistics.Win.UltraWinEditors.UltraOptionSet).Value = 0;
                }
            }
        }

        /// <summary>
        /// 親子判定による表示更新処理
        /// </summary>
        /// <param name="isParent"></param>
        private void SetInputEnabledByParent( bool isParent )
        {
            // 既に設定済みなら迂回
            if ( tNedit_TotalDay.Enabled == isParent ) return;

            if ( isParent )
            {
                //--------------------------------------
                // 親の場合
                //--------------------------------------
                tNedit_TotalDay.Enabled = true;
                tComboEditor_CollectMoneyCode.Enabled = true;
                tNedit_CollectMoneyDay.Enabled = true;
                tComboEditor_CollectCond.Enabled = true;
                tNedit_CollectSight.Enabled = true;
                tNedit_NTimeCalcStDate.Enabled = true;
                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                tComboEditor_TotalAmntDspWayRef.Enabled = true;
                tComboEditor_TotalAmountDispWayCd.Enabled = true;
                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                tComboEditor_CustCTaXLayRefCd.Enabled = true;
                tComboEditor_ConsTaxLayMethod.Enabled = true;
                tComboEditor_DepoDelCode.Enabled = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                //tNedit_SalesUnPrcFrcProcCd.Enabled = true;
                //uButton_SalesUnPrcFrcProcCdGuide.Enabled = true;
                //tNedit_SalesMoneyFrcProcCd.Enabled = true;
                //uButton_SalesMoneyFrcProcCdGuide.Enabled = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                tNedit_SalesCnsTaxFrcProcCd.Enabled = true;
                uButton_SalesCnsTaxFrcProcCdGuide.Enabled = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                tComboEditor_CreditMngCode.Enabled = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
            }
            else
            {
                //--------------------------------------
                // 子の場合
                //--------------------------------------
                tNedit_TotalDay.Enabled = false;
                tComboEditor_CollectMoneyCode.Enabled = false;
                tNedit_CollectMoneyDay.Enabled = false;
                tComboEditor_CollectCond.Enabled = false;
                tNedit_CollectSight.Enabled = false;
                tNedit_NTimeCalcStDate.Enabled = false;
                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                tComboEditor_TotalAmntDspWayRef.Enabled = false;
                tComboEditor_TotalAmountDispWayCd.Enabled = false;
                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                tComboEditor_CustCTaXLayRefCd.Enabled = false;
                tComboEditor_ConsTaxLayMethod.Enabled = false;
                tComboEditor_DepoDelCode.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                //tNedit_SalesUnPrcFrcProcCd.Enabled = false;
                //uButton_SalesUnPrcFrcProcCdGuide.Enabled = false;
                //tNedit_SalesMoneyFrcProcCd.Enabled = false;
                //uButton_SalesMoneyFrcProcCdGuide.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                tNedit_SalesCnsTaxFrcProcCd.Enabled = false;
                uButton_SalesCnsTaxFrcProcCdGuide.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                tComboEditor_CreditMngCode.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

                //// 親情報を取得して表示
                //CustomerInfo customerInfo;
                //int status = this._customerInputAcs.GetCustomerInfoFromCustomerCode( ConstantManagement.LogicalMode.GetData0, this.tNedit_ClaimCode.GetInt(), out customerInfo );
                //if ( status == 0 )
                //{
                //    # region [請求先情報セット]
                //    this.uLabel_ClaimName1.Text = customerInfo.ClaimName;                                                   // 請求先名称１
                //    this.uLabel_ClaimName2.Text = customerInfo.ClaimName2;													// 請求先名称２
                //    this.uLabel_ClaimSnm.Text = customerInfo.ClaimSnm;  													// 請求先略称
                //    this.tNedit_TotalDay.SetInt( customerInfo.TotalDay );														// 締日
                //    this.tNedit_CollectMoneyDay.SetInt( customerInfo.CollectMoneyDay );										// 集金日
                //    this.SetComboEditorItemIndex( this.tComboEditor_CollectMoneyCode, customerInfo.CollectMoneyCode );		// 集金月
                //    this.SetComboEditorItemIndex( this.tComboEditor_CustCTaXLayRefCd, customerInfo.CustCTaXLayRefCd );		// 消費税転嫁方式参照区分
                //    // 参照区分に従い分岐
                //    if ( tComboEditor_CustCTaXLayRefCd.SelectedIndex == 0 )
                //    {
                //        // 全体設定参照
                //        if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                //        {
                //            tComboEditor_ConsTaxLayMethod.Enabled = false;
                //        }
                //        this.SetComboEditorItemIndex( this.tComboEditor_ConsTaxLayMethod, this._customerInputAcs.GetConsTaxLayMethod( this._enterpriseCode, 0 ) );     // 消費税転嫁方式
                //    }
                //    else
                //    {
                //        // 得意先参照
                //        if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                //        {
                //            tComboEditor_ConsTaxLayMethod.Enabled = true;
                //        }
                //        this.SetComboEditorItemIndex( this.tComboEditor_ConsTaxLayMethod, customerInfo.ConsTaxLayMethod );		// 消費税転嫁方式
                //    }

                //    this.SetComboEditorItemIndex( this.tComboEditor_TotalAmntDspWayRef, customerInfo.TotalAmntDspWayRef );	// 総額表示方法参照区分
                //    // 参照区分に従い分岐
                //    if ( tComboEditor_TotalAmntDspWayRef.SelectedIndex == 0 )
                //    {
                //        // 全体設定参照
                //        if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                //        {
                //            tComboEditor_TotalAmountDispWayCd.Enabled = false;
                //        }
                //        this.SetComboEditorItemIndex( this.tComboEditor_TotalAmountDispWayCd, this._customerInputAcs.GetTotalAmountDispWayCd( this._enterpriseCode, customerInfo.MngSectionCode ) ); // 総額表示方法区分
                //    }
                //    else
                //    {
                //        // 得意先参照
                //        if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                //        {
                //            tComboEditor_TotalAmountDispWayCd.Enabled = true;
                //        }
                //        this.SetComboEditorItemIndex( this.tComboEditor_TotalAmountDispWayCd, customerInfo.TotalAmountDispWayCd );// 総額表示方法区分
                //    }
                //    this.SetComboEditorItemIndex( this.tComboEditor_CollectCond, customerInfo.CollectCond );                  // 回収条件
                //    # endregion
                //}
            }
        }

        /// <summary>
        /// 総額表示・転嫁方式の入力可否設定
        /// </summary>
        private void SetInputEnabledByTotalAmount()
        {
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            // 総額表示
            if ( tComboEditor_TotalAmntDspWayRef.Enabled )
            {
                // 参照区分に従う
                tComboEditor_TotalAmountDispWayCd.Enabled = (tComboEditor_TotalAmntDspWayRef.SelectedIndex != 0);
            }
            else
            {
                tComboEditor_TotalAmountDispWayCd.Enabled = false;
            }
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //if ( tComboEditor_TotalAmountDispWayCd.SelectedIndex == 0 )
            //{
            //    // 転嫁方式
            //    tComboEditor_CustCTaXLayRefCd.Enabled = true;
            //    // 参照区分に従う
            //    tComboEditor_ConsTaxLayMethod.Enabled = (tComboEditor_CustCTaXLayRefCd.SelectedIndex != 0);
            //}
            //else
            //{
            //    tComboEditor_CustCTaXLayRefCd.Enabled = false;
            //    tComboEditor_ConsTaxLayMethod.Enabled = false;
            //}
            // 転嫁方式
            tComboEditor_CustCTaXLayRefCd.Enabled = true;
            // 参照区分に従う
            tComboEditor_ConsTaxLayMethod.Enabled = (tComboEditor_CustCTaXLayRefCd.SelectedIndex != 0);
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// コンボエディタアイテムインデックス設定処理
        /// </summary>
        /// <param name="sender">対象となるコンボエディタ</param>
        /// <param name="dataValue">設定値</param>
        private void SetComboEditorItemIndex( TComboEditor sender, int dataValue )
        {
            int index = -1;

            if ( dataValue != 0 )
            {
                for ( int i = 0; i < sender.Items.Count; i++ )
                {
                    if ( (sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue) )
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                //if ( (sender.Items.Count > 0) && ((int)sender.Items[0].DataValue == 0) )
                if ( sender.Items.Count > 0 )
                {
                    index = dataValue;
                }
            }

            sender.SelectedIndex = index;
        }
        /// <summary>
        /// コンボエディタアイテムインデックス設定処理（得意先種別専用）
        /// </summary>
        /// <param name="sender">対象となるコンボエディタ</param>
        /// <param name="acceptWholeSale">業販先区分</param>
        private void SetCustomerDivCdItemIndex( TComboEditor sender, int acceptWholeSale )
        {
            int index = -1;

            if ( acceptWholeSale > 1 )
            {
                // 納入先とみなす
                index = 1;
            }
            else
            {
                // 得意先とみなす
                index = 0;
            }

            sender.SelectedIndex = index;
        }

        /// <summary>
        /// コンボエディタ選択アイテムテキスト取得処理
        /// </summary>
        /// <param name="sender">対象となるコンボエディタ</param>
        /// <param name="dataValue">設定値</param>
        /// <returns></returns>
        private string GetComboEditorText( TComboEditor sender, int dataValue )
        {
            int index = -1;
            for ( int i = 0; i < sender.Items.Count; i++ )
            {
                if ( (sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue) )
                {
                    index = i;
                    break;
                }
            }

            if ( index == -1 )
            {
                return string.Empty;
            }
            else
            {
                return sender.Items[index].DisplayText.Trim();
            }
        }

        /// <summary>
        /// 入力スタイル変更処理
        /// </summary>
        /// <param name="style">0:タブタイプ[STYLE_TAB] 1:エクスプローラーバータイプ[STYLE_SCROLL]</param>
        /// <br>UpdateNote : 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        private void InputStyleChange( int style )
        {
            switch ( style )
            {
                case STYLE_TAB:
                    {
                        # region [タブスタイル]
                        this.SubInfo_UTabControl.Visible = true;

                        this.SubInfo0_UTabPageControl.Controls.Add( this.panel_SubInfo0 );
                        this.SubInfo2_UTabPageControl.Controls.Add( this.panel_SubInfo2 );
                        this.SubInfo4_UTabPageControl.Controls.Add( this.panel_SubInfo4 );
                        this.SubInfo5_UTabPageControl.Controls.Add( this.panel_SubInfo5 );
                        this.SubInfo6_UTabPageControl.Controls.Add( this.panel_SubInfo6 );
                        this.SubInfo7_UTabPageControl.Controls.Add( this.panel_SubInfo7 );  // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.SubInfo8_UTabPageControl.Controls.Add(this.panel_SubInfo8);
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.Location = new Point( 0, 0 );
                        this.panel_SubInfo2.Location = new Point( 0, 0 );
                        this.panel_SubInfo4.Location = new Point( 0, 0 );
                        this.panel_SubInfo5.Location = new Point( 0, 0 );
                        this.panel_SubInfo6.Location = new Point( 0, 0 );
                        this.panel_SubInfo7.Location = new Point( 0, 0 );   // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.Location = new Point(0, 0);
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.Width = this.SubInfo_UTabControl.Width - 2;
                        this.panel_SubInfo2.Width = this.SubInfo_UTabControl.Width - 2;
                        this.panel_SubInfo4.Width = this.SubInfo_UTabControl.Width - 2;
                        this.panel_SubInfo5.Width = this.SubInfo_UTabControl.Width - 2;
                        this.panel_SubInfo6.Width = this.SubInfo_UTabControl.Width - 2;
                        this.panel_SubInfo7.Width = this.SubInfo_UTabControl.Width - 2; // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.Width = this.SubInfo_UTabControl.Width - 2;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.BorderStyle = BorderStyle.None;
                        this.panel_SubInfo2.BorderStyle = BorderStyle.None;
                        this.panel_SubInfo4.BorderStyle = BorderStyle.None;
                        this.panel_SubInfo5.BorderStyle = BorderStyle.None;
                        this.panel_SubInfo6.BorderStyle = BorderStyle.None;
                        this.panel_SubInfo7.BorderStyle = BorderStyle.None; // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.BorderStyle = BorderStyle.None;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.uLabel_SubInfo0Title.Visible = false;
                        this.uLabel_SubInfo2Title.Visible = false;
                        this.uLabel_SubInfo4Title.Visible = false;
                        this.uLabel_SubInfo5Title.Visible = false;
                        this.uLabel_SubInfo6Title.Visible = false;
                        this.uLabel_SubInfo7Title.Visible = false;  // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.uLabel_SubInfo8Title.Visible = false;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        // 備考情報Ｔａｂ
                        this.uLabel_Note1Title.Left = 15;
                        this.uLabel_Note2Title.Left = 15;
                        this.uLabel_Note3Title.Left = 15;
                        this.uLabel_Note4Title.Left = 15;
                        this.uLabel_Note5Title.Left = 15;
                        this.uLabel_Note6Title.Left = 485;
                        this.uLabel_Note7Title.Left = 485;
                        this.uLabel_Note8Title.Left = 485;
                        this.uLabel_Note9Title.Left = 485;
                        this.uLabel_Note10Title.Left = 485;

                        this.tEdit_Note1.Left = 120;
                        this.tEdit_Note2.Left = 120;
                        this.tEdit_Note3.Left = 120;
                        this.tEdit_Note4.Left = 120;
                        this.tEdit_Note5.Left = 120;
                        this.tEdit_Note6.Left = 590;
                        this.tEdit_Note7.Left = 590;
                        this.tEdit_Note8.Left = 590;
                        this.tEdit_Note9.Left = 590;
                        this.tEdit_Note10.Left = 590;

                        this.uButton_Note1Guide.Left = 445;
                        this.uButton_Note2Guide.Left = 445;
                        this.uButton_Note3Guide.Left = 445;
                        this.uButton_Note4Guide.Left = 445;
                        this.uButton_Note5Guide.Left = 445;
                        this.uButton_Note6Guide.Left = 915;
                        this.uButton_Note7Guide.Left = 915;
                        this.uButton_Note8Guide.Left = 915;
                        this.uButton_Note9Guide.Left = 915;
                        this.uButton_Note10Guide.Left = 915;

                        // Ｅメール情報Ｔａｂ
                        this.tComboEditor_MailAddrKindCode1.Width = 170;
                        this.tComboEditor_MailAddrKindCode2.Width = 170;

                        // 各タブ
                        this.panel_SubInfo0.Visible = true;
                        this.panel_SubInfo2.Visible = true;
                        this.panel_SubInfo4.Visible = true;
                        this.panel_SubInfo5.Visible = true;
                        this.panel_SubInfo6.Visible = true;
                        this.panel_SubInfo7.Visible = true; // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.Visible = true;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<
                        # endregion

                        break;
                    }
                case STYLE_SCROLL:
                    {
                        # region [スクロールスタイル]
                        this.SubInfo_UTabControl.Visible = false;

                        this.Container_Panel.Controls.Add( this.panel_SubInfo0 );
                        this.Container_Panel.Controls.Add( this.panel_SubInfo2 );
                        this.Container_Panel.Controls.Add( this.panel_SubInfo4 );
                        this.Container_Panel.Controls.Add( this.panel_SubInfo5 );
                        this.Container_Panel.Controls.Add( this.panel_SubInfo6 );
                        this.Container_Panel.Controls.Add( this.panel_SubInfo7 );   // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.Container_Panel.Controls.Add(this.panel_SubInfo8);
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.Visible = true;
                        this.panel_SubInfo2.Visible = true;
                        this.panel_SubInfo4.Visible = true;
                        this.panel_SubInfo5.Visible = true;
                        this.panel_SubInfo6.Visible = true;
                        this.panel_SubInfo7.Visible = true; // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.Visible = true;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.uLabel_SubInfo0Title.Visible = true;
                        this.uLabel_SubInfo2Title.Visible = true;
                        this.uLabel_SubInfo4Title.Visible = true;
                        this.uLabel_SubInfo5Title.Visible = true;
                        this.uLabel_SubInfo6Title.Visible = true;
                        this.uLabel_SubInfo7Title.Visible = true;   // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.uLabel_SubInfo8Title.Visible = true;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.Location = new Point( this.SubInfo_UTabControl.Location.X + this.uLabel_SubInfo0Title.Width, this.SubInfo_UTabControl.Location.Y );
                        this.panel_SubInfo2.Location = new Point( this.panel_SubInfo0.Location.X, this.panel_SubInfo0.Location.Y + this.panel_SubInfo0.Size.Height + 10 );
                        this.panel_SubInfo4.Location = new Point( this.panel_SubInfo0.Location.X, this.panel_SubInfo2.Location.Y + this.panel_SubInfo2.Size.Height + 10 );
                        this.panel_SubInfo5.Location = new Point( this.panel_SubInfo0.Location.X, this.panel_SubInfo4.Location.Y + this.panel_SubInfo4.Size.Height + 10 );
                        this.panel_SubInfo6.Location = new Point( this.panel_SubInfo0.Location.X, this.panel_SubInfo5.Location.Y + this.panel_SubInfo5.Size.Height + 10 );
                        // --- DEL 2010/08/10 ------------------------------------>>>>>
                        //this.panel_SubInfo7.Location = new Point( this.panel_SubInfo0.Location.X, this.panel_SubInfo5.Location.Y + this.panel_SubInfo5.Size.Height + 10 );  // ADD 2009/06/03
                        // --- DEL 2010/08/10 ------------------------------------<<<<<
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        this.panel_SubInfo7.Location = new Point(this.panel_SubInfo0.Location.X, this.panel_SubInfo6.Location.Y + this.panel_SubInfo6.Size.Height + 10);
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.Location = new Point(this.panel_SubInfo7.Location.X, this.panel_SubInfo7.Location.Y + this.panel_SubInfo7.Size.Height + 10);
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo0Title.Width;
                        this.panel_SubInfo2.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo2Title.Width;
                        this.panel_SubInfo4.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo4Title.Width;
                        this.panel_SubInfo5.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo5Title.Width;
                        this.panel_SubInfo6.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo6Title.Width;
                        this.panel_SubInfo7.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo7Title.Width;   // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.Width = this.SubInfo_UTabControl.Width - this.uLabel_SubInfo8Title.Width;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.panel_SubInfo0.BorderStyle = BorderStyle.FixedSingle;
                        this.panel_SubInfo2.BorderStyle = BorderStyle.FixedSingle;
                        this.panel_SubInfo4.BorderStyle = BorderStyle.FixedSingle;
                        this.panel_SubInfo5.BorderStyle = BorderStyle.FixedSingle;
                        this.panel_SubInfo6.BorderStyle = BorderStyle.FixedSingle;
                        this.panel_SubInfo7.BorderStyle = BorderStyle.FixedSingle;  // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.panel_SubInfo8.BorderStyle = BorderStyle.FixedSingle;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.uLabel_SubInfo0Title.Left = this.panel_SubInfo0.Left - this.uLabel_SubInfo0Title.Width;
                        this.uLabel_SubInfo2Title.Left = this.panel_SubInfo2.Left - this.uLabel_SubInfo2Title.Width;
                        this.uLabel_SubInfo4Title.Left = this.panel_SubInfo4.Left - this.uLabel_SubInfo4Title.Width;
                        this.uLabel_SubInfo5Title.Left = this.panel_SubInfo5.Left - this.uLabel_SubInfo5Title.Width;
                        this.uLabel_SubInfo6Title.Left = this.panel_SubInfo6.Left - this.uLabel_SubInfo6Title.Width;
                        this.uLabel_SubInfo7Title.Left = this.panel_SubInfo7.Left - this.uLabel_SubInfo7Title.Width;    // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.uLabel_SubInfo8Title.Left = this.panel_SubInfo8.Left - this.uLabel_SubInfo8Title.Width;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.uLabel_SubInfo0Title.Top = this.panel_SubInfo0.Top;
                        this.uLabel_SubInfo2Title.Top = this.panel_SubInfo2.Top;
                        this.uLabel_SubInfo4Title.Top = this.panel_SubInfo4.Top;
                        this.uLabel_SubInfo5Title.Top = this.panel_SubInfo5.Top;
                        this.uLabel_SubInfo6Title.Top = this.panel_SubInfo6.Top;
                        this.uLabel_SubInfo7Title.Top = this.panel_SubInfo7.Top;    // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.uLabel_SubInfo8Title.Top = this.panel_SubInfo8.Top;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        this.uLabel_SubInfo0Title.Height = this.panel_SubInfo0.Height;
                        this.uLabel_SubInfo2Title.Height = this.panel_SubInfo2.Height;
                        this.uLabel_SubInfo4Title.Height = this.panel_SubInfo4.Height;
                        this.uLabel_SubInfo5Title.Height = this.panel_SubInfo5.Height;
                        this.uLabel_SubInfo6Title.Height = this.panel_SubInfo6.Height;
                        this.uLabel_SubInfo7Title.Height = this.panel_SubInfo7.Height;  // ADD 2009/06/03
                        // ADD 陳健 K2014/02/06 ---------------------------------------------->>>>>
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //if (_opt_Maehashi == (int)Option.ON)
                        //{
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                            this.uLabel_SubInfo8Title.Height = this.panel_SubInfo8.Height;
                        // DEL 梶谷貴士 2021/05/10 ---------------------------------------------->>>>>
                        //}
                        // DEL 梶谷貴士 2021/05/10 ----------------------------------------------<<<<<
                        // ADD 陳健 K2014/02/06 ----------------------------------------------<<<<<

                        // 備考情報Ｔａｂ
                        this.uLabel_Note1Title.Left = 5;
                        this.uLabel_Note2Title.Left = 5;
                        this.uLabel_Note3Title.Left = 5;
                        this.uLabel_Note4Title.Left = 5;
                        this.uLabel_Note5Title.Left = 5;
                        this.uLabel_Note6Title.Left = 465;
                        this.uLabel_Note7Title.Left = 465;
                        this.uLabel_Note8Title.Left = 465;
                        this.uLabel_Note9Title.Left = 465;
                        this.uLabel_Note10Title.Left = 465;

                        this.tEdit_Note1.Left = 110;
                        this.tEdit_Note2.Left = 110;
                        this.tEdit_Note3.Left = 110;
                        this.tEdit_Note4.Left = 110;
                        this.tEdit_Note5.Left = 110;
                        this.tEdit_Note6.Left = 570;
                        this.tEdit_Note7.Left = 570;
                        this.tEdit_Note8.Left = 570;
                        this.tEdit_Note9.Left = 570;
                        this.tEdit_Note10.Left = 570;

                        this.uButton_Note1Guide.Left = 435;
                        this.uButton_Note2Guide.Left = 435;
                        this.uButton_Note3Guide.Left = 435;
                        this.uButton_Note4Guide.Left = 435;
                        this.uButton_Note5Guide.Left = 435;
                        this.uButton_Note6Guide.Left = 895;
                        this.uButton_Note7Guide.Left = 895;
                        this.uButton_Note8Guide.Left = 895;
                        this.uButton_Note9Guide.Left = 895;
                        this.uButton_Note10Guide.Left = 895;

                        // Ｅメール情報Ｔａｂ
                        this.tComboEditor_MailAddrKindCode1.Width = 150;
                        this.tComboEditor_MailAddrKindCode2.Width = 150;
                        # endregion

                        break;
                    }
            }
        }
        /// <summary>
        /// 管理拠点コード転送イベントコール処理
        /// </summary>
        /// <param name="mngSectionCode">転送管理拠点コード</param>
        private void TransmitMngSectionCodeEventCall( string mngSectionCode )
        {
            if ( this.TransmitMngSectionCode != null )
            {
                this.TransmitMngSectionCode( this, mngSectionCode );
            }
        }
        # endregion

        // ===================================================================================== //
        // フォームロードイベント
        // ===================================================================================== //
        # region Form Load Event Method
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKHN09010UA_Load( object sender, System.EventArgs e )
        {
            // 最上位の親コントロールを取得する
            Control parentBuf = this.Parent;
            Control parent = parentBuf;
            while ( parentBuf != null )
            {
                parentBuf = parentBuf.Parent;

                if ( parentBuf != null )
                {
                    parent = parentBuf;
                }
            }

            if ( parent != null )
            {
                if ( parent is Form )
                {
                    this._parentTopForm = (Form)parent;
                    this._parentTopForm.SizeChanged += new EventHandler( this.ParentTopForm_SizeChanged );
                }
            }

            // 画面初期処理
            this.InitialDisplay();

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // 初期表示タブ設定
            if ( this.SubInfo_UTabControl.Visible )
            {
                this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[this._customerInputConstructionAcs.FirstDisplayTab];
                this.SubInfo_UTabControl.ActiveTab.Selected = true;
            }
            // DEL 梶谷貴士 2021/05/10 -------------------->>>>>
            //// ADD 陳健 K2014/02/06 -------------------->>>>>
            //this.adjustControlVisable();
            //// ADD 陳健 K2014/02/06 --------------------<<<<<
            // DEL 梶谷貴士 2021/05/10 --------------------<<<<<
        }
        # endregion

        // ===================================================================================== //
        // タイマー起動イベント
        // ===================================================================================== //
        # region Timer Exec Event Method
        /// <summary>
        /// タイマー起動イベント（未使用）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Initialize_Timer_Tick( object sender, System.EventArgs e )
        {
            this.Initialize_Timer.Enabled = false;

            this.Cursor = Cursors.WaitCursor;

            // 画面初期処理
            this.InitialDisplay();

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            this.Cursor = Cursors.Default;
        }
        # endregion

        // ===================================================================================== //
        // フォーカスコントロールイベント
        // ===================================================================================== //
        # region Focus Control Event Method
        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        /// <br>UpdateNote : 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( this._customerInfo == null ) return;
            if ( e.PrevCtrl == null || e.NextCtrl == null ) return;

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (e.PrevCtrl == uButton_Note6Guide
                || e.PrevCtrl == uButton_Note7Guide
                || e.PrevCtrl == uButton_Note8Guide
                || e.PrevCtrl == uButton_Note9Guide
                || e.PrevCtrl == uButton_Note10Guide
                || e.PrevCtrl == tComboEditor_MailAddrKindCode1
                || e.PrevCtrl == tComboEditor_MailAddrKindCode2
                || e.PrevCtrl == tComboEditor_TotalBillOutputDiv
                || e.PrevCtrl == tComboEditor_DetailBillOutputCode
                || e.PrevCtrl == tComboEditor_SlipTtlBillOutputDiv
                || e.PrevCtrl == tComboEditor_MainContactCode
                || e.PrevCtrl == uButton_ClaimNameGuide
                || e.PrevCtrl == tEdit_SearchTelNo
                || e.PrevCtrl == tComboEditor_OnlineKindDiv
                || e.PrevCtrl == tEdit_SimplInqAcntAcntGrId)
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = null;
                                return;
                            }
                    }
                }
            }

            if (e.PrevCtrl == tComboEditor_ReceiptOutputCode
                || e.PrevCtrl == tComboEditor_DmOutCode
                || e.PrevCtrl == tComboEditor_CustSlipNoMngCd
                || e.PrevCtrl == tComboEditor_CustomerSlipNoDiv
                || e.PrevCtrl == tComboEditor_QrcodePrtCd
                || e.PrevCtrl == tComboEditor_OnlineKindDiv
                || e.PrevCtrl == tEdit_CustomerEpCode
                || e.PrevCtrl == tEdit_CustomerSecCode)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Left:
                            {
                                e.NextCtrl = null;
                                return;
                            }
                    }
                }
            }

            Control nextControlBak = e.NextCtrl;

            #region 項目処理
            switch (e.PrevCtrl.Name)
            {
                case "tComboEditor_MainContactCode":
                case "tComboEditor_MailAddrKindCode2":
                case "tComboEditor_MailAddrKindCode1":
                case "tComboEditor_MailSendCode2":
                case "tComboEditor_MailSendCode1":
                case "tComboEditor_SlipTtlBillOutputDiv":
                case "tComboEditor_DetailBillOutputCode":
                case "tComboEditor_TotalBillOutputDiv":
                case "tComboEditor_UOESlipPrtDiv":
                case "tComboEditor_EstimatePrtDiv":
                case "tComboEditor_ShipmSlipPrtDiv":
                case "tComboEditor_AcpOdrrSlipPrtDiv":
                case "tComboEditor_SalesSlipPrtDiv":
                case "tComboEditor_QrcodePrtCd":
                case "tComboEditor_ReceiptOutputCode":
                case "tComboEditor_DmOutCode":
                case "tComboEditor_CustSlipNoMngCd":
                case "tComboEditor_CustomerSlipNoDiv":
                case "tComboEditor_OnlineKindDiv":
                case "tComboEditor_CarMngDivCd":
                case "tComboEditor_CorporateDivCode":
                case "tComboEditor_CustomerAttributeDiv":
                case "tComboEditor_CustCTaXLayRefCd":
                case "tComboEditor_CustomerDivCd":
                case "tComboEditor_AccRecDivCd":
                case "tComboEditor_DepoDelCode":
                case "tComboEditor_CreditMngCode":
                case "tComboEditor_CollectCond":
                case "tComboEditor_ConsTaxLayMethod":
                case "tComboEditor_CollectMoneyCode":
                case "tComboEditor_OutputNameCode":
                    {
                        this.setTComboEditorByName(e.PrevCtrl.Name);

                        if (e.PrevCtrl.Name.Equals("tComboEditor_OnlineKindDiv") && this.tComboEditor_OnlineKindDiv.Value != null)
                        {
                            string onlineKindDiv = this.tComboEditor_OnlineKindDiv.Value.ToString();
            
                            if ("0".Equals(onlineKindDiv))
                            {
                                this.tEdit_CustomerEpCode.Clear();
                                this.tEdit_CustomerSecCode.Clear();

                                this.tEdit_CustomerEpCode.Enabled = false;
                                this.tEdit_CustomerSecCode.Enabled = false;

                                this.tEdit_SimplInqAcntAcntGrId.Clear();
                                this.tEdit_SimplInqAcntAcntGrId.Enabled = false;
                            }
                            else
                            {
                                this.tEdit_CustomerEpCode.Enabled = true;
                                this.tEdit_SimplInqAcntAcntGrId.Enabled = true;
                                this.tEdit_CustomerSecCode.Enabled = true;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl is TComboEditor)
            {
                this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
            }
            #endregion
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            this._prevControl = e.NextCtrl;

            // 現時点での得意先クラスの情報を退避する
            CustomerInfo customerInfoWork = this._customerInfo.Clone();
            CustomerInfo customerInfoBuff = this._customerInfo.Clone();

            bool isCustomerAgentNmChange = false;
            string mngSectionCode = string.Empty;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            _enterYearOfCustAgentChgDate = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

            # region ＜名前＞
            if ( e.PrevCtrl == this.tNedit_CustomerCode )
            {
                // 得意先コード手動修正フラグをOFFにする
                this._customerCodeChangeFlg = false;

                if ( this._customerInfo.CustomerCode.CompareTo( this.tNedit_CustomerCode.GetInt() ) != 0 )
                {
                    bool codeChangeFlg = false;
                    CustomerInfo customerInfo;

                    if ( (this.tNedit_CustomerCode.GetInt() == 0) && (customerInfoWork.UpdateDateTime != DateTime.MinValue) )
                    {
                        // 既存データ呼び出し中で得意先コードが0の場合は元に戻す
                    }
                    else
                    {
                        // 得意先検索処理（得意先コードより）
                        int status = this._customerInputAcs.GetCustomerInfoFromCustomerCode( ConstantManagement.LogicalMode.GetDataAll, this.tNedit_CustomerCode.GetInt(), out customerInfo );

                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            if ( customerInfo.LogicalDeleteCode == 0 )
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                    this.Name,
                                    "入力されたコードの得意先情報が既に登録されています。" + "\r\n" + "\r\n" +
                                    "【得意先名称：" + customerInfo.Name + " " + customerInfo.Name2 + "】" + "\r\n" + "\r\n" +
                                    "編集を行いますか？",
                                    0,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxDefaultButton.Button1 );

                                switch ( dialogResult )
                                {
                                    case (DialogResult.Yes):
                                        {
                                            if ( this.SelectCodeChanged != null )
                                            {
                                                this._customerInfo = customerInfo.Clone();
                                                codeChangeFlg = true;

                                                // 選択コード変更後発生イベント
                                                CustomerSelectCodeChangeCtlEventArgs cea = new CustomerSelectCodeChangeCtlEventArgs( this.tNedit_CustomerCode.GetInt(), DateTime.MinValue );
                                                this.SelectCodeChanged( sender, cea );
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "入力されたコードの得意先情報は既に削除されています。",
                                    -1,
                                    MessageBoxButtons.OK );

                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                        {
                            if ( customerInfoWork.UpdateDateTime != DateTime.MinValue )
                            {
                                // 既存データ呼び出し中で該当データが存在しないコードが入力された場合は
                                // データを元に戻す
                            }
                            else if ( this._custCdAutoNumbering == MANUAL_NUMBERING_OK )
                            {
                                // 請求先コードに得意先コードをセットする
                                this._customerInfo.ClaimCode = this.tNedit_CustomerCode.GetInt();

                                codeChangeFlg = true;

                                // 選択コード変更後発生イベント
                                CustomerSelectCodeChangeCtlEventArgs cea = new CustomerSelectCodeChangeCtlEventArgs( this.tNedit_CustomerCode.GetInt(), DateTime.MinValue );
                                this.SelectCodeChanged( sender, cea );

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/06 ADD
                                // 請求先＝得意先ならば、請求先名称欄をリアルで更新する（納入先の場合は除く）
                                this.uLabel_ClaimName1.Text = this.tEdit_Name.DataText;
                                this.uLabel_ClaimName2.Text = this.tEdit_Name2.DataText;
                                this.uLabel_ClaimSnm.Text = this.tEdit_CustomerSnm.DataText;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/06 ADD
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "得意先情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK );
                        }
                    }

                    if ( !codeChangeFlg )
                    {
                        this.SetDisplayFormCustomerInfo( customerInfoWork );
                    }
                    else
                    {
                        // 得意先クラスの情報を再度退避する
                        customerInfoWork = this._customerInfo.Clone();
                        customerInfoBuff = this._customerInfo.Clone();
                    }
                }

                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Up:
                        case Keys.Left:
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                            break;
                        case Keys.Right:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    switch ( e.Key )
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                            break;
                    }
                }
            }
            else if ( e.PrevCtrl == this.tEdit_CustomerSubCode )
            {

            }
            else if ( e.PrevCtrl == this.tEdit_Name )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tNedit_CustomerCode;
                                break;
                            }
                        case Keys.Right:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tEdit_Name2 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Right:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                    e.NextCtrl = tNedit_ClaimCode;
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tEdit_CustomerSnm )
            {
                // NextCtrl制御
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = tNedit_ClaimCode;
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                        case Keys.Down:
                            {
                                e.NextCtrl = this.tEdit_Kana;
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tEdit_Kana )
            {
                // NextCtrl制御
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = tNedit_ClaimCode;
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                        case Keys.Down:
                            {
                                e.NextCtrl = this.tEdit_HonorificTitle;
                                break;
                            }
                    }
                }
            }
            //else if ( e.PrevCtrl == this.tComboEditor_HonorificTitle )
            //{
            //    if ( this._customerInfo.HonorificTitle.CompareTo( this.tComboEditor_HonorificTitle.Text ) != 0 )
            //    {
            //        if ( this.tComboEditor_HonorificTitle.Text.Length > 4 )
            //        {
            //            // 得意先クラス→画面格納処理
            //            this.SetDisplayFormCustomerInfo( customerInfoWork );
            //        }
            //    }
            //}
            else if ( e.PrevCtrl == this.tEdit_HonorificTitle )
            {
                if ( this._customerInfo.HonorificTitle.CompareTo( this.tEdit_HonorificTitle.Text ) != 0 )
                {
                    // 画面入力値をセット
                    customerInfoWork.HonorificTitle = this.tEdit_HonorificTitle.Text;
                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo( customerInfoWork );
                }
            }
            else if ( e.PrevCtrl == this.tComboEditor_OutputNameCode )
            {
                // 画面入力値を取得して再表示
                customerInfoWork.OutputNameCode = GetComboEditorInputCode( this.tComboEditor_OutputNameCode, customerInfoWork.OutputNameCode );
                this.SetDisplayFormCustomerInfo( customerInfoWork );

                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Right:
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 DEL
                                //if ( tComboEditor_OutputNameCode.Enabled )
                                //{
                                //    e.NextCtrl = tComboEditor_OutputNameCode;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 ADD
                                if ( tNedit_TotalDay.Enabled )
                                {
                                    e.NextCtrl = tNedit_TotalDay;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 ADD
                                else
                                {
                                    e.NextCtrl = tNedit_ClaimCode;
                                }
                            }
                            break;
                    }
                }
            }
            # endregion
            # region ＜詳細情報＞
            else if ( e.PrevCtrl == this.tEdit_MngSectionNm )
            {
                bool retStatus = true;

                // 画面入力値を取得して再表示
                if ( this._customerInfo.MngSectionName.CompareTo( this.tEdit_MngSectionNm.Text ) != 0 )
                {
                    // 入力されているか？
                    if ( this.tEdit_MngSectionNm.DataText.Trim() != string.Empty )
                    {
                        // 入力拠点コード取得
                        string sectionCode = GetInputCode( tEdit_MngSectionNm );

                        SecInfoSet secInfoSet;
                        int status = this._customerInputAcs.GetSectionFromSectionCode( out secInfoSet, sectionCode );

                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            // 管理拠点を格納
                            _mngSectionCode = secInfoSet.SectionCode;
                            customerInfoWork.MngSectionCode = secInfoSet.SectionCode;
                            customerInfoWork.MngSectionName = secInfoSet.SectionGuideNm;
                            retStatus = true;
                        }
                        else
                        {
                            // 未存在時はクリア
                            _mngSectionCode = string.Empty;
                            customerInfoWork.MngSectionCode = string.Empty;
                            customerInfoWork.MngSectionName = string.Empty;
                            retStatus = false;
                        }
                    }
                    else
                    {
                        // 未入力時はクリア
                        _mngSectionCode = string.Empty;
                        customerInfoWork.MngSectionCode = string.Empty;
                        customerInfoWork.MngSectionName = string.Empty;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo( customerInfoWork );
                }

                // NextCtrl制御
                if ( retStatus )
                {
                    if ( !e.ShiftKey )
                    {
                        switch ( e.Key )
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = tEdit_HonorificTitle;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = tEdit_CustomerAgentNm;
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if ( this.tEdit_MngSectionNm.Text.Trim() == string.Empty )
                                    {
                                        e.NextCtrl = this.uButton_MngSectionNmGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_CustomerAgentNm;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if ( e.PrevCtrl == this.tComboEditor_CorporateDivCode )
            {
                // 画面入力値を取得して再表示
                customerInfoWork.CorporateDivCode = GetComboEditorInputCode( this.tComboEditor_CorporateDivCode, customerInfoWork.CorporateDivCode );
                this.SetDisplayFormCustomerInfo( customerInfoWork );
            }
            else if ( e.PrevCtrl == this.tComboEditor_CustomerAttributeDiv )
            {

            }
            else if ( e.PrevCtrl == this.tComboEditor_CarMngDivCd )
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tEdit_OldCustomerAgentNm;
                                break;
                            }
                    }
                }
                // --- ADD 2010/08/10 ------------------------------------>>>>>
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (string.IsNullOrEmpty(this.tEdit_SalesAreaNm.Text))
                                {
                                    e.NextCtrl = uButton_SalesAreaCdGuide;
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                }
                                break;
                            }
                    }
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( e.PrevCtrl == this.tComboEditor_CustomerDivCd )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // 区分変更処理
                ChangeCustomerDiv( ref customerInfoWork );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                //// 画面入力値を取得して再表示
                //SetCustomerDivCd( ref customerInfoWork, this.tComboEditor_CustomerDivCd );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                this.SetDisplayFormCustomerInfo( customerInfoWork );

                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Up:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                    // 得意先
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
                                    //e.NextCtrl = tComboEditor_PureCode;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
                                    e.NextCtrl = tComboEditor_CarMngDivCd;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = tEdit_Name2;
                                }
                                break;
                            }
                        case Keys.Down:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                    // 得意先
                                    e.NextCtrl = tEdit_CustWarehouseCd;
                                }
                                else
                                {
                                    // 納入先
                                    if ( this.SubInfo_UTabControl.Visible )
                                    {
                                        // Ｔａｂモードの場合
                                        this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY0];
                                        this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                        e.NextCtrl = tEdit_PostNo;
                                    }
                                    else
                                    {  
                                        // Ｂａｒモードの場合
                                        e.NextCtrl = tEdit_PostNo;
                                    }
                                }
                                break;
                            }
                        case Keys.Left:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                    // 得意先
                                    e.NextCtrl = tComboEditor_CorporateDivCode;
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                        case Keys.Right:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                    // 得意先
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if ( !customerInfoWork.IsReceiver )
                                {
                                    // 得意先
                                    e.NextCtrl = tEdit_CustWarehouseCd;
                                }
                                else
                                {
                                    // 納入先
                                    if ( this.SubInfo_UTabControl.Visible )
                                    {
                                        // Ｔａｂモードの場合
                                        this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY0];
                                        this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                        e.NextCtrl = tEdit_PostNo;
                                    }
                                    else
                                    {
                                        // Ｂａｒモードの場合
                                        e.NextCtrl = tEdit_PostNo;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CustAnalysCode1 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tEdit_CustWarehouseCd;
                                break;
                            }
                        case Keys.Down:
                            {
                                if ( SubInfo_UTabControl.Visible )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        case Keys.Left:
                            {
                                e.NextCtrl = this.uButton_SalesAreaCdGuide;
                                break;
                            }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                    }
                }
                else
                {
                    switch ( e.Key )
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = uButton_CustWarehouseGuide;
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CustAnalysCode2 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Down:
                            {
                                if ( SubInfo_UTabControl.Visible )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CustAnalysCode3 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Down:
                            {
                                if ( SubInfo_UTabControl.Visible )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CustAnalysCode4 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Down:
                            {
                                if ( SubInfo_UTabControl.Visible )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CustAnalysCode5 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Down:
                            {
                                if ( SubInfo_UTabControl.Visible )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CustAnalysCode6 )
            {
                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tEdit_CustWarehouseCd;
                                break;
                            }
                        case Keys.Down:
                            {
                                if ( SubInfo_UTabControl.Visible )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                    }
                }
            }
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //else if ( e.PrevCtrl == this.tComboEditor_BusinessTypeCode )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.BusinessTypeCode = GetComboEditorInputCode( this.tComboEditor_BusinessTypeCode, customerInfoWork.BusinessTypeCode );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );

            //    if ( !e.ShiftKey )
            //    {
            //        switch ( e.Key )
            //        {
            //            case Keys.Right:
            //                {
            //                    e.NextCtrl = e.PrevCtrl;
            //                    break;
            //                }
            //        }
            //    }
            //}
            //else if ( e.PrevCtrl == this.tComboEditor_JobTypeCode )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.JobTypeCode = GetComboEditorInputCode( this.tComboEditor_JobTypeCode, customerInfoWork.JobTypeCode );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );

            //    if ( !e.ShiftKey )
            //    {
            //        switch ( e.Key )
            //        {
            //            case Keys.Right:
            //                {
            //                    e.NextCtrl = e.PrevCtrl;
            //                    break;
            //                }
            //        }
            //    }
            //}
            //else if ( e.PrevCtrl == this.tComboEditor_SalesAreaCode )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.SalesAreaCode = GetComboEditorInputCode( this.tComboEditor_SalesAreaCode, customerInfoWork.SalesAreaCode );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );

            //    if ( !e.ShiftKey )
            //    {
            //        switch ( e.Key )
            //        {
            //            case Keys.Down:
            //                {
            //                    if ( this.SubInfo_UTabControl.Visible )
            //                    {
            //                    }
            //                    else
            //                    {
            //                        e.NextCtrl = tEdit_PostNo;
            //                    }
            //                }
            //                break;
            //        }
            //    }
            //}
            // --- DEL 2010/08/10 ------------------------------------<<<<<
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            else if (e.PrevCtrl == this.tEdit_BusinessTypeNm)
            {
                bool retStatus = true;

                if (this._customerInfo.BusinessTypeName.CompareTo(this.tEdit_BusinessTypeNm.Text) != 0)
                {
                    if (this.tEdit_BusinessTypeNm.Text.Trim() != string.Empty)
                    {
                        // 業種コード取得
                        try
                        {
                            int businessTypeCd = Convert.ToInt32(this.tEdit_BusinessTypeNm.Text.Trim());
                            string businessTypeNm = string.Empty;

                            UserGdBd userGdBd = null;
                            UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                            int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 33, businessTypeCd, ref acsDataType);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (userGdBd.LogicalDeleteCode == 0)
                                {
                                    customerInfoWork.BusinessTypeCode = businessTypeCd;
                                    customerInfoWork.BusinessTypeName = userGdBd.GuideName;
                                    this._businessTypeCd = businessTypeCd;
                                    retStatus = true;
                                }
                                else
                                {
                                    customerInfoWork.BusinessTypeCode = 0;
                                    customerInfoWork.BusinessTypeName = string.Empty;
                                    this._businessTypeCd = 0;
                                    retStatus = false;
                                }
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // クリアする
                                customerInfoWork.BusinessTypeCode = 0;
                                customerInfoWork.BusinessTypeName = string.Empty;
                                this._businessTypeCd = 0;
                                retStatus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "業種の取得に失敗しました。",
                                    status,
                                    MessageBoxButtons.OK);
                            }
                        }
                        catch
                        {
                            customerInfoWork.BusinessTypeCode = 0;
                            customerInfoWork.BusinessTypeName = string.Empty;
                            this._businessTypeCd = 0;
                            retStatus = false;
                        }
                    }
                    else
                    {
                        customerInfoWork.BusinessTypeCode = 0;
                        customerInfoWork.BusinessTypeName = string.Empty;
                        this._businessTypeCd = 0;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_JobTypeName;
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_BusinessTypeNm.Text == "")
                                    {
                                        e.NextCtrl = this.uButton_BusinessTypeCdGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_JobTypeName;
                                    }
                                    break;
                                }
                            case Keys.Right:
                                {
                                    e.NextCtrl = this.uButton_BusinessTypeCdGuide;
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == this.tEdit_JobTypeName)
            {
                bool retStatus = true;

                if (this._customerInfo.JobTypeName.CompareTo(this.tEdit_JobTypeName.Text) != 0)
                {
                    if (this.tEdit_JobTypeName.Text.Trim() != string.Empty)
                    {
                        // 職種コード取得
                        try
                        {
                            int jobTypeCd = Convert.ToInt32(this.tEdit_JobTypeName.Text.Trim());

                            // 職種取得
                            string jobTypeNm = string.Empty;
                            UserGdBd userGdBd = null;
                            UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                            int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 34, jobTypeCd, ref acsDataType);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (userGdBd.LogicalDeleteCode == 0)
                                {
                                    customerInfoWork.JobTypeCode = jobTypeCd;
                                    customerInfoWork.JobTypeName = userGdBd.GuideName;
                                    this._jobTypeCode = jobTypeCd;
                                    retStatus = true;
                                }
                                else
                                {
                                    customerInfoWork.JobTypeCode = 0;
                                    customerInfoWork.JobTypeName = string.Empty;
                                    this._jobTypeCode = 0;
                                    retStatus = false; 
                                }
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // クリアする
                                customerInfoWork.JobTypeCode = 0;
                                customerInfoWork.JobTypeName = string.Empty;
                                this._jobTypeCode = 0;
                                retStatus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "職種の取得に失敗しました。",
                                    status,
                                    MessageBoxButtons.OK);
                            }
                        }
                        catch
                        {
                            customerInfoWork.JobTypeCode = 0;
                            customerInfoWork.JobTypeName = string.Empty;
                            this._jobTypeCode = 0;
                            retStatus = false;
                        }
                    }
                    else
                    {
                        customerInfoWork.JobTypeCode = 0;
                        customerInfoWork.JobTypeName = string.Empty;
                        this._jobTypeCode = 0;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_SalesAreaNm;
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_JobTypeName.Text.Trim() == "")
                                    {
                                        e.NextCtrl = this.uButton_JobTypeCodeGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_SalesAreaNm;
                                    }
                                    break;
                                }
                            case Keys.Right:
                                {
                                    e.NextCtrl = this.uButton_JobTypeCodeGuide;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (string.IsNullOrEmpty(this.tEdit_BusinessTypeNm.Text))
                                    {
                                        e.NextCtrl = uButton_BusinessTypeCdGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_BusinessTypeNm;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == this.tEdit_SalesAreaNm)
            {
                bool retStatus = true;

                if (this._customerInfo.SalesAreaName.CompareTo(this.tEdit_SalesAreaNm.Text) != 0)
                {
                    if (this.tEdit_SalesAreaNm.Text.Trim() != string.Empty)
                    {
                        // 地区コード取得
                        try
                        {
                            int salesAreaCd = Convert.ToInt32(this.tEdit_SalesAreaNm.Text.Trim());
                            string salesAreaNm = string.Empty;

                            UserGdBd userGdBd = null;
                            UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                            int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 21, salesAreaCd, ref acsDataType);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (userGdBd.LogicalDeleteCode == 0)
                                {
                                    customerInfoWork.SalesAreaCode = salesAreaCd;
                                    customerInfoWork.SalesAreaName = userGdBd.GuideName;
                                    this._saleAreaCd = salesAreaCd;
                                    retStatus = true;
                                }
                                else
                                {
                                    customerInfoWork.SalesAreaCode = 0;
                                    customerInfoWork.SalesAreaName = string.Empty;
                                    this._saleAreaCd = 0;
                                    retStatus = false; 
                                }
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // クリアする
                                customerInfoWork.SalesAreaCode = 0;
                                customerInfoWork.SalesAreaName = string.Empty;
                                this._saleAreaCd = 0;
                                retStatus = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "地区の取得に失敗しました。",
                                    status,
                                    MessageBoxButtons.OK);
                            }
                        }
                        catch
                        {
                            customerInfoWork.SalesAreaCode = 0;
                            customerInfoWork.SalesAreaName = string.Empty;
                            this._saleAreaCd = 0;
                            retStatus = false;
                        }
                    }
                    else
                    {
                        customerInfoWork.SalesAreaCode = 0;
                        customerInfoWork.SalesAreaName = string.Empty;
                        this._saleAreaCd = 0;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    if (this._style == STYLE_SCROLL)
                                    {
                                        e.NextCtrl = this.tEdit_PostNo;
                                    }
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_SalesAreaNm.Text.Trim() == "")
                                    {
                                        e.NextCtrl = this.uButton_SalesAreaCdGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_CarMngDivCd;
                                    }
                                    break;
                                }
                            case Keys.Right:
                                {
                                    e.NextCtrl = this.uButton_SalesAreaCdGuide;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (string.IsNullOrEmpty(this.tEdit_JobTypeName.Text))
                                    {
                                        e.NextCtrl = uButton_JobTypeCodeGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_JobTypeName;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            else if (e.PrevCtrl == this.tComboEditor_CustSlipNoMngCd)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.CustSlipNoMngCd = GetComboEditorInputCode(this.tComboEditor_CustSlipNoMngCd, customerInfoWork.CustSlipNoMngCd);
                this.SetDisplayFormCustomerInfo(customerInfoWork);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
            //else if ( e.PrevCtrl == this.tComboEditor_PureCode )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.PureCode = GetComboEditorInputCode( this.tComboEditor_PureCode, customerInfoWork.PureCode );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
            else if (e.PrevCtrl == this.tDateEdit_TransStopDate)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = tComboEditor_CarMngDivCd;
                            }
                            break;
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_CustomerSlipNoDiv)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.CustomerSlipNoDiv = GetComboEditorInputCode(this.tComboEditor_CustomerSlipNoDiv, customerInfoWork.CustomerSlipNoDiv);
                this.SetDisplayFormCustomerInfo(customerInfoWork);
            }
            else if (e.PrevCtrl == this.tEdit_CustomerAgentNm)
            {
                bool retStatus = true;

                if (this._customerInfo.CustomerAgentNm.CompareTo(this.tEdit_CustomerAgentNm.Text) != 0)
                {
                    if (tEdit_CustomerAgentNm.Text.TrimEnd() != string.Empty)
                    {
                        // 入力従業員コード取得
                        string employeeCode = GetInputCode(tEdit_CustomerAgentNm);

                        Employee employee = null;
                        int status = this._customerInputAcs.GetEmployeeFromEmployeeCode(employeeCode, out employee);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 従業員クラス→得意先クラスの得意先担当情報格納処理
                            this._customerInputAcs.SetCustomerInfoAgentFromEmployee(employee, ref customerInfoWork);

                            isCustomerAgentNmChange = true;
                            retStatus = true;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // クリアする
                            customerInfoWork.CustomerAgentCd = string.Empty;
                            customerInfoWork.CustomerAgentNm = string.Empty;
                            retStatus = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "従業員情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        // クリアする
                        customerInfoWork.CustomerAgentCd = string.Empty;
                        customerInfoWork.CustomerAgentNm = string.Empty;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_CustAgentChgDate;
                                    _enterYearOfCustAgentChgDate = true;
                                    break;
                                }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_CustomerAgentNm.Text.Trim() == "")
                                    {
                                        e.NextCtrl = this.uButton_CustomerAgentNmGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_OldCustomerAgentNm;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }

            }
            else if (e.PrevCtrl == this.uButton_CustomerAgentNmGuide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_OldCustomerAgentNm)
            {
                bool retStatus = true;

                if (this._customerInfo.OldCustomerAgentNm.CompareTo(this.tEdit_OldCustomerAgentNm.Text) != 0)
                {
                    if (tEdit_OldCustomerAgentNm.Text.TrimEnd() != string.Empty)
                    {
                        // 入力従業員コード取得
                        string employeeCode = GetInputCode(tEdit_OldCustomerAgentNm);
                        Employee employee = null;

                        int status = this._customerInputAcs.GetEmployeeFromEmployeeCode(employeeCode, out employee);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 従業員クラス→得意先クラスの旧担当情報格納処理
                            this._customerInputAcs.SetOldCustomerInfoAgentFromEmployee(employee, ref customerInfoWork);
                            retStatus = true;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // クリアする
                            customerInfoWork.OldCustomerAgentCd = string.Empty;
                            customerInfoWork.OldCustomerAgentNm = string.Empty;
                            retStatus = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "従業員情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        // クリアする
                        customerInfoWork.OldCustomerAgentCd = string.Empty;
                        customerInfoWork.OldCustomerAgentNm = string.Empty;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_OldCustomerAgentNm.Text.Trim() == "")
                                    {
                                        e.NextCtrl = this.uButton_OldCustomerAgentNmGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_CustAgentChgDate;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }

            }
            else if (e.PrevCtrl == this.tEdit_CustWarehouseCd)
            {
                bool retStatus = true;

                // 優先倉庫
                if (this._customerInfo.CustWarehouseName.CompareTo(tEdit_CustWarehouseCd.Text) != 0)
                {
                    if (tEdit_CustWarehouseCd.Text.TrimEnd() != string.Empty)
                    {
                        // ｺｰﾄﾞ変換
                        string warehouseCode = GetInputCode(tEdit_CustWarehouseCd);

                        Warehouse warehouse = null;
                        int status = this._customerInputAcs.GetWarehouseFromWarehouseCode(out warehouse, customerInfoWork.MngSectionCode, warehouseCode);

                        string code = string.Empty;
                        if (warehouse != null)
                        {
                            code = warehouse.WarehouseCode.Trim();
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && code != string.Empty)
                        {
                            customerInfoWork.CustWarehouseCd = code;
                            customerInfoWork.CustWarehouseName = warehouse.WarehouseName;
                            retStatus = true;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // クリア
                            customerInfoWork.CustWarehouseCd = string.Empty;
                            customerInfoWork.CustWarehouseName = string.Empty;
                            retStatus = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "倉庫情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        customerInfoWork.CustWarehouseCd = string.Empty;
                        customerInfoWork.CustWarehouseName = string.Empty;
                        retStatus = true;
                    }
                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = tNedit_CustAnalysCode1;
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_CustWarehouseCd.Text.Trim() == "")
                                    {
                                        e.NextCtrl = this.uButton_CustWarehouseGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_CustAnalysCode1;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == uButton_CustWarehouseGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Down:
                            {
                                e.NextCtrl = tNedit_CustAnalysCode1;
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = tNedit_CustAnalysCode1;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = tEdit_CustWarehouseCd;
                                break;
                            }
                    }
                }
            }
            # endregion
            # region ＜請求情報＞
            else if (e.PrevCtrl == tEdit_ClaimSectionCode)
            {
                bool retStatus = true;

                // 画面入力値を取得して再表示
                if (this._customerInfo.ClaimSectionName.CompareTo(this.tEdit_ClaimSectionCode.Text) != 0)
                {
                    // 入力されているか？
                    if (this.tEdit_ClaimSectionCode.Text.Trim() != string.Empty)
                    {
                        // 入力拠点コード取得
                        string sectionCode = GetInputCode(tEdit_ClaimSectionCode);

                        SecInfoSet secInfoSet;
                        int status = this._customerInputAcs.GetSectionFromSectionCode(out secInfoSet, sectionCode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 管理拠点を格納
                            _claimSectionCode = secInfoSet.SectionCode;
                            customerInfoWork.ClaimSectionCode = secInfoSet.SectionCode;
                            customerInfoWork.ClaimSectionName = secInfoSet.SectionGuideNm;
                            retStatus = true;
                        }
                        else
                        {
                            // 未存在時はクリア
                            _claimSectionCode = string.Empty;
                            customerInfoWork.ClaimSectionCode = string.Empty;
                            customerInfoWork.ClaimSectionName = string.Empty;
                            retStatus = false;
                        }
                    }
                    else
                    {
                        // 未入力時はクリア
                        _claimSectionCode = string.Empty;
                        customerInfoWork.ClaimSectionCode = string.Empty;
                        customerInfoWork.ClaimSectionName = string.Empty;
                        retStatus = true;
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }


                // NextCtrl制御
                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = tNedit_ClaimCode;
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tEdit_ClaimSectionCode.Text.Trim() == string.Empty)
                                    {
                                        e.NextCtrl = this.uButton_ClaimSectionGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_ClaimCode;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == this.uButton_ClaimSectionGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = tNedit_ClaimCode;
                                break;
                            }
                        case Keys.Down:
                            {
                                e.NextCtrl = tNedit_ClaimCode;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = tEdit_ClaimSectionCode;
                            }
                            break;
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_ClaimCode)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                bool isCancel = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD

                if (this._customerInfo.ClaimCode != this.tNedit_ClaimCode.GetInt())
                {
                    if (this.tNedit_ClaimCode.GetInt() != 0)
                    {
                        CustomerInfo customerInfo;

                        // 得意先検索処理（得意先コードより）
                        int status = this._customerInputAcs.GetCustomerInfoFromCustomerCode(ConstantManagement.LogicalMode.GetData0, this.tNedit_ClaimCode.GetInt(), out customerInfo);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
                            //bool isCancel = false;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                            if ((this._customerInfo.CustomerCode != 0) && (this._customerInfo.CustomerCode != customerInfo.CustomerCode) &&
                                (customerInfo.CustomerCode != customerInfo.ClaimCode))
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "選択された得意先は請求先コードが異なる為、請求先として選択できません",
                                    0,
                                    MessageBoxButtons.OK);
                                isCancel = true;
                            }
                            // --- ADD 2008/11/27 -------------------------------->>>>>
                            else if ((this._customerInfo.CustomerCode != 0) && customerInfo.IsReceiver)
                            {
                                TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "選択された得意先は納入先の為、請求先として選択できません",
                                    0,
                                    MessageBoxButtons.OK);
                                isCancel = true;
                            }
                            // --- ADD 2008/11/27 --------------------------------<<<<<
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                            if (!isCancel)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
                            {
                                if ((this._customerInfo.CustomerCode != 0) && (this._customerInfo.ClaimCode != this.tNedit_ClaimCode.GetInt()))
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_QUESTION,
                                        this.Name,
                                        "請求先を変更しようとしています。" + "\r\n" + "\r\n" +
                                        "よろしいですか？",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);

                                    if (dialogResult != DialogResult.Yes)
                                    {
                                        isCancel = true;
                                    }
                                }
                            }

                            if (!isCancel)
                            {
                                // 得意先クラス→得意先クラス（請求先情報）格納処理
                                this._customerInputAcs.SetCustomerInfoClaimInfoFromCustomerInfo(customerInfo, ref customerInfoWork);
                            }
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // 得意先情報クラス（得意先情報）→得意先情報クラス（請求先情報）格納処理
                            this._customerInputAcs.CopyCustomerInfoClaimInfoFromCustomerInfo(ref customerInfoWork);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                            isCancel = true;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "請求先の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                            isCancel = true;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
                        }
                    }
                    else
                    {
                        // 請求先がクリアされた場合は、得意先と同一とする
                        // 得意先情報クラス（得意先情報）→得意先情報クラス（請求先情報）格納処理
                        this._customerInputAcs.CopyCustomerInfoClaimInfoFromCustomerInfo(ref customerInfoWork);
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                if (!isCancel)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (this.tNedit_ClaimCode.Text.Trim() == "")
                                    {
                                        e.NextCtrl = this.uButton_ClaimNameGuide;
                                    }
                                    else
                                    {
                                        if (tNedit_TotalDay.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_TotalDay;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_BillCollecterNm;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
            }
            else if (e.PrevCtrl == this.uButton_ClaimNameGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Down:
                            {
                                if (tNedit_TotalDay.Enabled)
                                {
                                    e.NextCtrl = tNedit_TotalDay;
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_BillCollecterNm;
                                }
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 DEL
                                //if ( this.tNedit_ClaimCode.Text.Trim() == "" )
                                //{
                                //    e.NextCtrl = this.uButton_ClaimNameGuide;
                                //}
                                //else
                                //{
                                //    e.NextCtrl = this.tNedit_TotalDay;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 ADD
                                if (tNedit_TotalDay.Enabled)
                                {
                                    e.NextCtrl = this.tNedit_TotalDay;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_BillCollecterNm;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 ADD
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_TotalDay)
            {

            }
            else if (e.PrevCtrl == this.tNedit_CollectMoneyDay)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tNedit_ClaimCode;
                                break;
                            }
                        case Keys.Down:
                            {
                                e.NextCtrl = tNedit_CollectSight;
                                break;
                            }
                        case Keys.Right:
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_CollectMoneyCode)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.CollectMoneyCode = GetComboEditorInputCode(this.tComboEditor_CollectMoneyCode, customerInfoWork.CollectMoneyCode);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tNedit_ClaimCode;
                                break;
                            }
                    }
                }

            }
            else if (e.PrevCtrl == this.tComboEditor_CollectCond)
            {
                // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tNedit_TotalDay;
                                break;
                            }
                    }
                }
                // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<
            }
            else if (e.PrevCtrl == this.tNedit_CollectSight)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Down:
                            {
                                e.NextCtrl = tNedit_NTimeCalcStDate;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_NTimeCalcStDate)
            {
                // ADD 2009/01/19 不具合対応[9944] ---------->>>>>
                string dayText = this.tNedit_NTimeCalcStDate.Text.Trim();
                if (!string.IsNullOrEmpty(dayText))
                {
                    int dayNumber = int.Parse(dayText);
                    if (dayNumber < 0 || dayNumber > 31)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "次回勘定は 1～31 の範囲で入力してください。",
                            0,
                            MessageBoxButtons.OK
                        );
                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                    else
                    {
                        this.tNedit_NTimeCalcStDate.Text = dayNumber.ToString();
                    }
                }
                // ADD 2009/01/19 不具合対応[9944] ----------<<<<<

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_OldCustomerAgentNmGuide)
            {

            }
            else if (e.PrevCtrl == this.tDateEdit_CustAgentChgDate)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = tComboEditor_CarMngDivCd;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_BillCollecterNm)
            {
                if (this._customerInfo.BillCollecterNm.CompareTo(this.tEdit_BillCollecterNm.Text) != 0)
                {
                    // 入力従業員コード取得
                    string employeeCode = GetInputCode(tEdit_BillCollecterNm);
                    Employee employee = null;

                    int status = this._customerInputAcs.GetEmployeeFromEmployeeCode(employeeCode, out employee);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 従業員クラス→得意先クラスの集金担当情報格納処理
                        this._customerInputAcs.SetBillCollecterFromEmployee(employee, ref customerInfoWork);
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // クリア
                        customerInfoWork.BillCollecterCd = string.Empty;
                        customerInfoWork.BillCollecterNm = string.Empty;
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOPDISP,
                            this.Name,
                            "従業員情報の取得に失敗しました。",
                            status,
                            MessageBoxButtons.OK);
                    }

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (tNedit_NTimeCalcStDate.Enabled)
                                {
                                    e.NextCtrl = tNedit_NTimeCalcStDate;
                                }
                                else
                                {
                                    e.NextCtrl = tNedit_ClaimCode;
                                }
                                break;
                            }
                        case Keys.Down:
                            {
                                // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                                //if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                                //{
                                //    e.NextCtrl = tComboEditor_TotalAmntDspWayRef;
                                //}
                                if (tComboEditor_CustCTaXLayRefCd.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                                //else
                                //{
                                //    e.NextCtrl = tComboEditor_CreditMngCode;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                                else if (tComboEditor_CreditMngCode.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_CreditMngCode;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_AccRecDivCd;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.tEdit_BillCollecterNm.Text.Trim() == "")
                                {
                                    e.NextCtrl = this.uButton_BillCollecterNmGuide;
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 DEL
                                    //e.NextCtrl = this.tComboEditor_TotalAmntDspWayRef;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 ADD
                                    // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                                    //if (tComboEditor_TotalAmntDspWayRef.Enabled)
                                    //{
                                    //    e.NextCtrl = tComboEditor_TotalAmntDspWayRef;
                                    //}
                                    if (tComboEditor_CustCTaXLayRefCd.Enabled)
                                    {
                                        e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                    }
                                    // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                                    else
                                    {
                                        e.NextCtrl = tComboEditor_CreditMngCode;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 ADD
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_BillCollecterNmGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (tNedit_NTimeCalcStDate.Enabled)
                                {
                                    e.NextCtrl = tNedit_NTimeCalcStDate;
                                }
                                else
                                {
                                    e.NextCtrl = tNedit_ClaimCode;
                                }
                                break;
                            }
                        case Keys.Down:
                            {
                                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                if ( tComboEditor_TotalAmountDispWayCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_TotalAmountDispWayCd;
                                }
                                else if (tComboEditor_TotalAmntDspWayRef.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_TotalAmntDspWayRef;
                                }
                                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                if (tComboEditor_ConsTaxLayMethod.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_ConsTaxLayMethod;
                                }
                                else if (tComboEditor_CustCTaXLayRefCd.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                else
                                {
                                    e.NextCtrl = uButton_SalesUnPrcFrcProcCdGuide;
                                }
                                break;
                            }
                    }
                }
            }
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            else if ( e.PrevCtrl == this.tComboEditor_TotalAmntDspWayRef )
            {
                // 画面入力値を取得して再表示
                customerInfoWork.TotalAmntDspWayRef = GetComboEditorInputCode( this.tComboEditor_TotalAmntDspWayRef, customerInfoWork.TotalAmntDspWayRef );
                this.SetDisplayFormCustomerInfo( customerInfoWork );

                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Right:
                            {
                                if ( tComboEditor_TotalAmountDispWayCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_TotalAmountDispWayCd;
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if ( tComboEditor_TotalAmountDispWayCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_TotalAmountDispWayCd;
                                }
                                else if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_CreditMngCode;
                                }
                                break;
                            }
                    }
                }
            }
            else if ( e.PrevCtrl == this.tComboEditor_TotalAmountDispWayCd )
            {
                // 画面入力値を取得して再表示
                customerInfoWork.TotalAmountDispWayCd = GetComboEditorInputCode( this.tComboEditor_TotalAmountDispWayCd, customerInfoWork.TotalAmountDispWayCd );
                this.SetDisplayFormCustomerInfo( customerInfoWork );

                if ( !e.ShiftKey )
                {
                    switch ( e.Key )
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tEdit_BillCollecterNm;
                                break;
                            }
                        case Keys.Down:
                            {
                                if ( tComboEditor_ConsTaxLayMethod.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_ConsTaxLayMethod;
                                }
                                else if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                else
                                {
                                    e.NextCtrl = tNedit_SalesUnPrcFrcProcCd;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if ( tComboEditor_CustCTaXLayRefCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_CreditMngCode;
                                }
                                break;
                            }
                    }
                }
            }
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            else if (e.PrevCtrl == this.tComboEditor_CreditMngCode)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.CreditMngCode = GetComboEditorInputCode(this.tComboEditor_CreditMngCode, customerInfoWork.CreditMngCode);
                this.SetDisplayFormCustomerInfo(customerInfoWork);
            }
            else if (e.PrevCtrl == this.tComboEditor_DepoDelCode)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.DepoDelCode = GetComboEditorInputCode(this.tComboEditor_DepoDelCode, customerInfoWork.DepoDelCode);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Left:
                            {
                                e.NextCtrl = this.uButton_JobTypeCodeGuide;
                                break;
                            }
                    }
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if (e.PrevCtrl == this.tComboEditor_AccRecDivCd)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.AccRecDivCd = GetComboEditorInputCode(this.tComboEditor_AccRecDivCd, customerInfoWork.AccRecDivCd);
                this.SetDisplayFormCustomerInfo(customerInfoWork);


                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Down:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    switch (SubInfo_UTabControl.SelectedTab.Index)
                                    {
                                        case 0:
                                            e.NextCtrl = tEdit_HomeTelNo;
                                            break;
                                        case 1:
                                            e.NextCtrl = tEdit_Note6;
                                            break;
                                        case 2:
                                            e.NextCtrl = tEdit_MailAddress1;
                                            break;
                                        case 3:
                                            e.NextCtrl = tEdit_AccountNoInfo1;
                                            break;
                                        case 4:
                                            //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                            e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                            break;
                                        // ADD 2009/06/03 ------>>>
                                        case 5:
                                            e.NextCtrl = tComboEditor_OnlineKindDiv;
                                            break;
                                        // ADD 2009/06/03 ------<<<
                                        // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                        // ADD 陳健 K2014/02/06 ------------------->>>>>
                                        case 6:
                                            //e.NextCtrl = memo_richTextBox;
                                            e.NextCtrl = check_CustomerInfoGuideDisp;   // UPD 2021/05/10 得意先ガイド表示区分に変更
                                            break;
                                        // ADD 陳健 K2014/02/06 -------------------<<<<<
                                        // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_HomeTelNo;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (tNedit_SalesUnPrcFrcProcCd.Enabled == false)
                                {
                                    if (SubInfo_UTabControl.Visible)
                                    {
                                        switch (SubInfo_UTabControl.SelectedTab.Index)
                                        {
                                            case 0:
                                                e.NextCtrl = tEdit_PostNo;
                                                break;
                                            case 1:
                                                e.NextCtrl = tEdit_Note1;
                                                break;
                                            case 2:
                                                e.NextCtrl = rButton_MainSendMailAddrCd0;
                                                break;
                                            case 3:
                                                e.NextCtrl = tEdit_AccountNoInfo1;
                                                break;
                                            case 4:
                                                //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                                e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                                break;
                                            // ADD 2009/06/03 ------>>>
                                            case 5:
                                                e.NextCtrl = tComboEditor_OnlineKindDiv;
                                                break;
                                            // ADD 2009/06/03 ------<<<
                                            // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                            // ADD 陳健 K2014/02/06 ------------------->>>>>
                                            case 6:
                                                //e.NextCtrl = memo_richTextBox;
                                                e.NextCtrl = check_CustomerInfoGuideDisp;   // UPD 2021/05/10 得意先ガイド表示区分に変更
                                                break;
                                            // ADD 陳健 K2014/02/06 -------------------<<<<<
                                            // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_PostNo;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            // ADD 2009/04/07 ------>>>
            else if (e.PrevCtrl == this.tComboEditor_ReceiptOutputCode)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.ReceiptOutputCode = GetComboEditorInputCode(this.tComboEditor_ReceiptOutputCode, customerInfoWork.ReceiptOutputCode);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_AccountNoInfo3;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY5];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    e.NextCtrl = tEdit_AccountNoInfo3;
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_AccountNoInfo3;
                                }
                                break;
                            }
                    }
                }
            }
            // ADD 2009/04/07 ------<<<
            // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
            //else if (e.PrevCtrl == this.tComboEditor_BillOutputCode)
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.BillOutputCode = GetComboEditorInputCode(this.tComboEditor_BillOutputCode, customerInfoWork.BillOutputCode);
            //    this.SetDisplayFormCustomerInfo(customerInfoWork);

            //    // DEL 2009/04/07 ------>>>
            //    //if (!e.ShiftKey)
            //    //{
            //    //    switch (e.Key)
            //    //    {
            //    //        case Keys.Up:
            //    //            {
            //    //                if (SubInfo_UTabControl.Visible)
            //    //                {
            //    //                    e.NextCtrl = tComboEditor_SalesAreaCode;
            //    //                }
            //    //                else
            //    //                {
            //    //                    e.NextCtrl = tEdit_AccountNoInfo3;
            //    //                }
            //    //                break;
            //    //            }
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    switch (e.Key)
            //    //    {
            //    //        case Keys.Tab:
            //    //        case Keys.Return:
            //    //            {
            //    //                if (SubInfo_UTabControl.Visible)
            //    //                {
            //    //                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY5];
            //    //                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
            //    //                    e.NextCtrl = tEdit_AccountNoInfo3;
            //    //                }
            //    //                else
            //    //                {
            //    //                    e.NextCtrl = tEdit_AccountNoInfo3;
            //    //                }
            //    //                break;
            //    //            }
            //    //    }
            //    //}
            //    // DEL 2009/04/07 ------<<<
            //}
            // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
            else if (e.PrevCtrl == this.tComboEditor_DmOutCode)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.DmOutCode = GetComboEditorInputCode(this.tComboEditor_DmOutCode, customerInfoWork.DmOutCode);
                this.SetDisplayFormCustomerInfo(customerInfoWork);
            }
            else if (e.PrevCtrl == this.tComboEditor_ConsTaxLayMethod)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.ConsTaxLayMethod = GetComboEditorInputCode(this.tComboEditor_ConsTaxLayMethod, customerInfoWork.ConsTaxLayMethod);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                                //if ( tComboEditor_TotalAmountDispWayCd.Enabled )
                                //{
                                //    e.NextCtrl = tComboEditor_TotalAmountDispWayCd;
                                //}
                                //else
                                //{
                                //    e.NextCtrl = tComboEditor_TotalAmntDspWayRef;
                                //}
                                e.NextCtrl = tEdit_BillCollecterNm;
                                // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                                break;
                            }
                        case Keys.Down:
                            {
                                e.NextCtrl = tNedit_SalesUnPrcFrcProcCd;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_CustCTaXLayRefCd)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.CustCTaXLayRefCd = GetComboEditorInputCode(this.tComboEditor_CustCTaXLayRefCd, customerInfoWork.CustCTaXLayRefCd);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                            {
                                if (tComboEditor_ConsTaxLayMethod.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_ConsTaxLayMethod;
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (tComboEditor_ConsTaxLayMethod.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_ConsTaxLayMethod;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_CreditMngCode;
                                }
                                break;
                            }
                    }
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //else if ( e.PrevCtrl == this.SalesUnPrcFrcProcCd_tComboEditor )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.SalesUnPrcFrcProcCd = GetComboEditorInputCode( this.SalesUnPrcFrcProcCd_tComboEditor, customerInfoWork.SalesUnPrcFrcProcCd );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );
            //}
            //else if ( e.PrevCtrl == this.SalesMoneyFrcProcCd_tComboEditor )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.SalesMoneyFrcProcCd = GetComboEditorInputCode( this.SalesMoneyFrcProcCd_tComboEditor, customerInfoWork.SalesMoneyFrcProcCd );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );
            //}
            //else if ( e.PrevCtrl == this.SalesCnsTaxFrcProcCd_TComboEditor )
            //{
            //    // 画面入力値を取得して再表示
            //    customerInfoWork.SalesCnsTaxFrcProcCd = GetComboEditorInputCode( this.SalesCnsTaxFrcProcCd_TComboEditor, customerInfoWork.SalesCnsTaxFrcProcCd );
            //    this.SetDisplayFormCustomerInfo( customerInfoWork );
            //}
            else if (e.PrevCtrl == this.tNedit_SalesUnPrcFrcProcCd)
            {
                bool retStatus = true;
                bool inputFlag = true;

                if (this.tNedit_SalesUnPrcFrcProcCd.Text != string.Empty)
                {
                    // 画面入力値を取得して再表示
                    int code = this.tNedit_SalesUnPrcFrcProcCd.GetInt();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 DEL
                    //if ( this._customerInputAcs.ExistsSalesProcMoney( 2, code ) == false )
                    //{
                    //    code = 0;
                    //    retStatus = false;
                    //}
                    //else
                    //{
                    //    retStatus = true;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
                    retStatus = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
                    customerInfoWork.SalesUnPrcFrcProcCd = code;
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }
                else
                {
                    customerInfoWork.SalesUnPrcFrcProcCd = 0;
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                    retStatus = true;
                    inputFlag = false;
                }

                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Up:
                                {
                                    if (tComboEditor_ConsTaxLayMethod.Enabled)
                                    {
                                        e.NextCtrl = tComboEditor_ConsTaxLayMethod;
                                    }
                                    else if (tComboEditor_CustCTaXLayRefCd.Enabled)
                                    {
                                        e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                    }
                                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                    else if ( tComboEditor_TotalAmountDispWayCd.Enabled )
                                    {
                                        e.NextCtrl = tComboEditor_TotalAmountDispWayCd;
                                    }
                                    else if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                                    {
                                        e.NextCtrl = tComboEditor_TotalAmntDspWayRef;
                                    }
                                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                    else
                                    {
                                        e.NextCtrl = tEdit_BillCollecterNm;
                                    }
                                }
                                break;
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (inputFlag)
                                    {
                                        e.NextCtrl = tNedit_SalesMoneyFrcProcCd;
                                    }
                                    else
                                    {
                                        e.NextCtrl = uButton_SalesUnPrcFrcProcCdGuide;
                                    }
                                }
                                break;
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == this.uButton_SalesUnPrcFrcProcCdGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (tComboEditor_ConsTaxLayMethod.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_ConsTaxLayMethod;
                                }
                                else if (tComboEditor_CustCTaXLayRefCd.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_CustCTaXLayRefCd;
                                }
                                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                else if ( tComboEditor_TotalAmountDispWayCd.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_TotalAmountDispWayCd;
                                }
                                else if ( tComboEditor_TotalAmntDspWayRef.Enabled )
                                {
                                    e.NextCtrl = tComboEditor_TotalAmntDspWayRef;
                                }
                                    --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                else
                                {
                                    e.NextCtrl = tEdit_BillCollecterNm;
                                }
                                break;
                            }
                        case Keys.Right:
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_SalesMoneyFrcProcCd)
            {
                bool retStatus = true;
                bool inputFlag = true;

                if (tNedit_SalesMoneyFrcProcCd.Text != string.Empty)
                {
                    // 画面入力値を取得して再表示
                    int code = this.tNedit_SalesMoneyFrcProcCd.GetInt();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 DEL
                    //if ( this._customerInputAcs.ExistsSalesProcMoney( 0, code ) == false )
                    //{
                    //    code = 0;
                    //    retStatus = false;
                    //}
                    //else
                    //{
                    //    retStatus = true;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
                    retStatus = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
                    customerInfoWork.SalesMoneyFrcProcCd = code;
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }
                else
                {
                    customerInfoWork.SalesMoneyFrcProcCd = 0;
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                    retStatus = true;
                    inputFlag = false;
                }

                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Left:
                                {
                                    if (tComboEditor_DepoDelCode.Enabled)
                                    {
                                        e.NextCtrl = tComboEditor_DepoDelCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                                break;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                            case Keys.Down:
                                {
                                    if (tNedit_SalesCnsTaxFrcProcCd.Enabled)
                                    {
                                        e.NextCtrl = tNedit_SalesCnsTaxFrcProcCd;
                                    }
                                    else if (tComboEditor_AccRecDivCd.Enabled)
                                    {
                                        e.NextCtrl = tComboEditor_AccRecDivCd;
                                    }
                                }
                                break;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (inputFlag)
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                                        //e.NextCtrl = tNedit_SalesCnsTaxFrcProcCd;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                                        if (tNedit_SalesCnsTaxFrcProcCd.Enabled)
                                        {
                                            e.NextCtrl = tNedit_SalesCnsTaxFrcProcCd;
                                        }
                                        else
                                        {
                                            if (SubInfo_UTabControl.Visible)
                                            {
                                                switch (SubInfo_UTabControl.SelectedTab.Index)
                                                {
                                                    case 0:
                                                        e.NextCtrl = tEdit_PostNo;
                                                        break;
                                                    case 1:
                                                        e.NextCtrl = tEdit_Note1;
                                                        break;
                                                    case 2:
                                                        e.NextCtrl = rButton_MainSendMailAddrCd0;
                                                        break;
                                                    case 3:
                                                        e.NextCtrl = tEdit_AccountNoInfo1;
                                                        break;
                                                    case 4:
                                                        //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                                        e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                                        break;
                                                    // ADD 2009/06/03 ------>>>
                                                    case 5:
                                                        e.NextCtrl = tComboEditor_OnlineKindDiv;
                                                        break;
                                                    // ADD 2009/06/03 ------<<<
                                                    // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                                    // ADD 陳健 K2014/02/06 ------------------->>>>>
                                                    case 6:
                                                        //e.NextCtrl = memo_richTextBox;
                                                        e.NextCtrl = check_CustomerInfoGuideDisp;   // UPD 2021/05/10 得意先ガイド表示区分に変更
                                                        break;
                                                    // UPD 陳健 K2014/02/06 -------------------<<<<<
                                                    // DEL 梶谷貴士 2021/05/10 --------------------<<<<<
                                                }
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_PostNo;
                                            }
                                        }
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                                    }
                                    else
                                    {
                                        e.NextCtrl = uButton_SalesMoneyFrcProcCdGuide;
                                    }
                                }
                                break;
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == uButton_SalesMoneyFrcProcCdGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                        case Keys.Down:
                            {
                                if (uButton_SalesCnsTaxFrcProcCdGuide.Enabled)
                                {
                                    e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                }
                                else if (tComboEditor_AccRecDivCd.Enabled)
                                {
                                    e.NextCtrl = tComboEditor_AccRecDivCd;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    switch (SubInfo_UTabControl.SelectedTab.Index)
                                    {
                                        case 0:
                                            e.NextCtrl = tEdit_PostNo;
                                            break;
                                        case 1:
                                            e.NextCtrl = tEdit_Note1;
                                            break;
                                        case 2:
                                            e.NextCtrl = rButton_MainSendMailAddrCd0;
                                            break;
                                        case 3:
                                            e.NextCtrl = tEdit_AccountNoInfo1;
                                            break;
                                        case 4:
                                            //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                            e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                            break;
                                        // ADD 2009/06/03 ------>>>
                                        case 5:
                                            e.NextCtrl = tComboEditor_OnlineKindDiv;
                                            break;
                                        // ADD 2009/06/03 ------<<<
                                        // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                        // ADD 陳健 K2014/02/06 ------------------->>>>>
                                        case 6:
                                            //e.NextCtrl = memo_richTextBox;
                                            e.NextCtrl = check_CustomerInfoGuideDisp;   // UPD 2021/05/10 得意先ガイド表示区分に変更
                                            break;
                                        // ADD 陳健 K2014/02/06 -------------------<<<<<
                                        // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;
                            }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_SalesCnsTaxFrcProcCd)
            {
                bool retStatus = true;
                bool inputFlag = true;

                if (tNedit_SalesCnsTaxFrcProcCd.Text != string.Empty)
                {
                    // 画面入力値を取得して再表示
                    int code = this.tNedit_SalesCnsTaxFrcProcCd.GetInt();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 DEL
                    //if ( this._customerInputAcs.ExistsSalesProcMoney( 1, code ) == false )
                    //{
                    //    code = 0;
                    //    retStatus = false;
                    //}
                    //else
                    //{
                    //    retStatus = true;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
                    retStatus = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
                    customerInfoWork.SalesCnsTaxFrcProcCd = code;
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }
                else
                {
                    customerInfoWork.SalesCnsTaxFrcProcCd = 0;
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                    retStatus = true;
                    inputFlag = false;
                }

                if (retStatus)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    if (SubInfo_UTabControl.Visible)
                                    {
                                        switch (SubInfo_UTabControl.SelectedTab.Index)
                                        {
                                            case 0:
                                                e.NextCtrl = tEdit_HomeFaxNo;
                                                break;
                                            case 1:
                                                e.NextCtrl = tEdit_Note6;
                                                break;
                                            case 2:
                                                e.NextCtrl = tComboEditor_MailAddrKindCode1;
                                                break;
                                            case 3:
                                                e.NextCtrl = tEdit_AccountNoInfo1;
                                                break;
                                            case 4:
                                                //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                                e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                                break;
                                            // ADD 2009/06/03 ------>>>
                                            case 5:
                                                e.NextCtrl = tComboEditor_OnlineKindDiv;
                                                break;
                                            // ADD 2009/06/03 ------<<<
                                            // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                            // ADD 陳健 K2014/02/06 ---------->>>>>
                                            case 6:
                                                //e.NextCtrl = memo_richTextBox;
                                                e.NextCtrl = check_CustomerInfoGuideDisp; // UPD 2021/05/10 得意先ガイド表示区分に変更
                                                break;
                                            // ADD 陳健 K2014/02/06 ----------<<<<<
                                            // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_HomeFaxNo;
                                    }
                                    break;
                                }
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (inputFlag)
                                    {
                                        if (SubInfo_UTabControl.Visible)
                                        {
                                            switch (SubInfo_UTabControl.SelectedTab.Index)
                                            {
                                                case 0:
                                                    e.NextCtrl = tEdit_PostNo;
                                                    break;
                                                case 1:
                                                    e.NextCtrl = tEdit_Note1;
                                                    break;
                                                case 2:
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 DEL
                                                    //e.NextCtrl = tEdit_MailAddress1;
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 DEL
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 ADD
                                                    e.NextCtrl = rButton_MainSendMailAddrCd0;
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 ADD
                                                    break;
                                                case 3:
                                                    e.NextCtrl = tEdit_AccountNoInfo1;
                                                    break;
                                                case 4:
                                                    //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                                    e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                                    break;
                                                // ADD 2009/06/03 ------>>>
                                                case 5:
                                                    e.NextCtrl = tComboEditor_OnlineKindDiv;
                                                    break;
                                                // ADD 2009/06/03 ------<<<
                                                // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                                // ADD 陳健 K2014/02/06 ---------->>>>>
                                                case 6:
                                                    //e.NextCtrl = memo_richTextBox;
                                                    e.NextCtrl = check_CustomerInfoGuideDisp; // UPD 2021/05/10 得意先ガイド表示区分に変更
                                                    break;
                                                // ADD 陳健 K2014/02/06 ----------<<<<<
                                                // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_PostNo;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                    }
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            else if (e.PrevCtrl == this.uButton_SalesCnsTaxFrcProcCdGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                        case Keys.Down:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    switch (SubInfo_UTabControl.SelectedTab.Index)
                                    {
                                        case 0:
                                            e.NextCtrl = tEdit_HomeFaxNo;
                                            break;
                                        case 1:
                                            e.NextCtrl = tEdit_Note6;
                                            break;
                                        case 2:
                                            e.NextCtrl = tComboEditor_MailAddrKindCode1;
                                            break;
                                        case 3:
                                            e.NextCtrl = tEdit_AccountNoInfo1;
                                            break;
                                        case 4:
                                            //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                            e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                            break;
                                        // ADD 2009/06/03 ------>>>
                                        case 5:
                                            e.NextCtrl = tComboEditor_OnlineKindDiv;
                                            break;
                                        // ADD 2009/06/03 ------<<<
                                        // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                        // ADD 陳健 K2014/02/06 ------------------->>>>>
                                        case 6:
                                            //e.NextCtrl = memo_richTextBox;
                                            e.NextCtrl = check_CustomerInfoGuideDisp;   // UPD 2021/05/10 得意先ガイド表示区分に変更
                                            break;
                                        // ADD 陳健 K2014/02/06 -------------------<<<<<
                                        // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_HomeFaxNo;
                                }
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    switch (SubInfo_UTabControl.SelectedTab.Index)
                                    {
                                        case 0:
                                            e.NextCtrl = tEdit_PostNo;
                                            break;
                                        case 1:
                                            e.NextCtrl = tEdit_Note1;
                                            break;
                                        case 2:
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 DEL
                                            //e.NextCtrl = tEdit_MailAddress1;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 ADD
                                            e.NextCtrl = rButton_MainSendMailAddrCd1;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 ADD
                                            break;
                                        case 3:
                                            e.NextCtrl = tEdit_AccountNoInfo1;
                                            break;
                                        case 4:
                                            //e.NextCtrl = tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                            e.NextCtrl = tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                            break;
                                        // ADD 2009/06/03 ------>>>
                                        case 5:
                                            e.NextCtrl = tComboEditor_OnlineKindDiv;
                                            break;
                                        // ADD 2009/06/03 ------<<<
                                        // UPD 梶谷貴士 2021/05/10 -------------------->>>>>
                                        // ADD 陳健 K2014/02/06 ------------------->>>>>
                                        case 6:
                                            //e.NextCtrl = memo_richTextBox;
                                            e.NextCtrl = check_CustomerInfoGuideDisp; // UPD 2021/05/10 得意先ガイド表示区分に変更
                                            break;
                                        // ADD 陳健 K2014/02/06 -------------------<<<<<
                                        // UPD 梶谷貴士 2021/05/10 --------------------<<<<<
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_PostNo;
                                }
                                break;

                            }
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion
            # region ＜連絡先情報＞
            else if (e.PrevCtrl == this.tEdit_PostNo)
            {
                bool codeSetFlg = true;

                if (this._customerInfo.PostNo.CompareTo(this.tEdit_PostNo.Text) != 0)
                {
                    customerInfoWork.PostNo = this.tEdit_PostNo.Text;

                    if (customerInfoWork.PostNo.Trim() != string.Empty)
                    {
                        // 住所検索処理(郵便番号より)
                        AddressGuideResult agResult = null;
                        if (this._customerInputAcs.GetAddressFromPostNo(customerInfoWork.PostNo, out agResult) == 0)
                        {
                            // 住所情報戻り値クラス→得意先クラス格納処理
                            this._customerInputAcs.SetCustomerInfoOwnerAddressFromAddressGuideResult(agResult, ref customerInfoWork);
                            codeSetFlg = true;
                        }
                        else
                        {
                            codeSetFlg = false;
                        }
                    }
                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if (customerInfoWork.PostNo.Trim() == string.Empty)
                {
                    codeSetFlg = false;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (!customerInfoWork.IsReceiver)
                                {
                                    // 得意先
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = tComboEditor_CustomerDivCd;
                                }
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (codeSetFlg)
                                {
                                    e.NextCtrl = this.tEdit_Address1;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                else
                                {
                                    e.NextCtrl = this.uButton_AddressGuide;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (!customerInfoWork.IsReceiver)
                                {
                                    // 得意先
                                    e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = tComboEditor_CustomerDivCd;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_AddressGuide)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (!customerInfoWork.IsReceiver)
                                {
                                    // 得意先
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = tComboEditor_CustomerDivCd;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_Address1)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tEdit_PostNo;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNedit_Address2)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Address3)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Address4)
            {

            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            else if (e.PrevCtrl == this.tEdit_CustomerAgent)
            {
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            else if (e.PrevCtrl == this.tEdit_HomeTelNo)
            {
                if (this._customerInfo.HomeTelNo.CompareTo(this.tEdit_HomeTelNo.Text) != 0)
                {
                    customerInfoWork.HomeTelNo = this.tEdit_HomeTelNo.Text;
                    customerInfoWork.SearchTelNo = this._customerInputAcs.CreateSearchTelNo(customerInfoWork, 0);

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tComboEditor_AccRecDivCd;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_OfficeTelNo)
            {
                if (this._customerInfo.OfficeTelNo.CompareTo(this.tEdit_OfficeTelNo.Text) != 0)
                {
                    customerInfoWork.OfficeTelNo = this.tEdit_OfficeTelNo.Text;
                    customerInfoWork.SearchTelNo = this._customerInputAcs.CreateSearchTelNo(customerInfoWork, 1);

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (!customerInfoWork.IsReceiver)
                                {
                                    // 得意先
                                    e.NextCtrl = tEdit_HomeTelNo;
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = tComboEditor_CustomerDivCd;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_PortableTelNo)
            {
                if (this._customerInfo.PortableTelNo.CompareTo(this.tEdit_PortableTelNo.Text) != 0)
                {
                    customerInfoWork.PortableTelNo = this.tEdit_PortableTelNo.Text;
                    customerInfoWork.SearchTelNo = this._customerInputAcs.CreateSearchTelNo(customerInfoWork, 2);

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }
            }
            else if (e.PrevCtrl == this.tEdit_OthersTelNo)
            {
                if (this._customerInfo.OthersTelNo.CompareTo(this.tEdit_OthersTelNo.Text) != 0)
                {
                    customerInfoWork.OthersTelNo = this.tEdit_OthersTelNo.Text;
                    customerInfoWork.SearchTelNo = this._customerInputAcs.CreateSearchTelNo(customerInfoWork, 5);

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }
            }
            else if (e.PrevCtrl == this.tEdit_HomeFaxNo)
            {
                if (this._customerInfo.HomeFaxNo.CompareTo(this.tEdit_HomeFaxNo.Text) != 0)
                {
                    customerInfoWork.HomeFaxNo = this.tEdit_HomeFaxNo.Text;
                    customerInfoWork.SearchTelNo = this._customerInputAcs.CreateSearchTelNo(customerInfoWork, 3);

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tNedit_SalesCnsTaxFrcProcCd;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_OfficeFaxNo)
            {
                if (this._customerInfo.OfficeFaxNo.CompareTo(this.tEdit_OfficeFaxNo.Text) != 0)
                {
                    customerInfoWork.OfficeFaxNo = this.tEdit_OfficeFaxNo.Text;
                    customerInfoWork.SearchTelNo = this._customerInputAcs.CreateSearchTelNo(customerInfoWork, 4);

                    // 得意先クラス→画面格納処理
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (!customerInfoWork.IsReceiver)
                                {
                                    // 得意先
                                    e.NextCtrl = tEdit_HomeFaxNo;
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = tComboEditor_CustomerDivCd;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (!customerInfoWork.IsReceiver)
                                {
                                    // 得意先
                                    e.NextCtrl = tEdit_SearchTelNo;
                                }
                                else
                                {
                                    // 納入先
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_SearchTelNo)
            {

            }
            else if (e.PrevCtrl == this.tComboEditor_MainContactCode)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.MainContactCode = GetComboEditorInputCode(this.tComboEditor_MainContactCode, customerInfoWork.MainContactCode);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY2];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    e.NextCtrl = this.tEdit_Note1;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = this.tEdit_Note1;
                                }
                                break;
                            }
                    }
                }

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                this._customerInfo.MainContactCode = (int)this.tComboEditor_MainContactCode.Value;
                this.tEdit_SearchTelNo.Text = this._customerInputAcs.CreateSearchTelNo(this._customerInfo);
                // --- ADD 2010/08/10 ------------------------------------>>>>>
            }
            # endregion
            # region ＜備考情報＞
            else if (e.PrevCtrl == this.tEdit_Note1)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_CustomerAgent;
                                }
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if ((this.tEdit_Note1.Text.Trim() == "") && (this.uButton_Note1Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note1Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note2;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY0];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    e.NextCtrl = tComboEditor_MainContactCode;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = tComboEditor_MainContactCode;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note1Guide)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_CustomerAgent;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_Note2)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note2.Text.Trim() == "") && (this.uButton_Note2Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note2Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note3;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note2Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note3)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note3.Text.Trim() == "") && (this.uButton_Note3Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note3Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note4;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note3Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note4)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note4.Text.Trim() == "") && (this.uButton_Note4Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note4Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note5;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note4Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note5)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note5.Text.Trim() == "") && (this.uButton_Note5Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note5Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note6;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note5Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note6)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    e.NextCtrl = tComboEditor_AccRecDivCd;
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_OthersTelNo;
                                }
                                break;
                            }
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note6.Text.Trim() == "") && (this.uButton_Note6Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note6Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note7;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note6Guide)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    e.NextCtrl = tComboEditor_AccRecDivCd;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_MainContactCode;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_Note7)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note7.Text.Trim() == "") && (this.uButton_Note7Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note7Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note8;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note7Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note8)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note8.Text.Trim() == "") && (this.uButton_Note8Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note8Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note9;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note8Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note9)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note9.Text.Trim() == "") && (this.uButton_Note9Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note9Guide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_Note10;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note9Guide)
            {

            }
            else if (e.PrevCtrl == this.tEdit_Note10)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if ((this.tEdit_Note10.Text.Trim() == "") && (this.uButton_Note10Guide.Enabled))
                                {
                                    e.NextCtrl = this.uButton_Note10Guide;
                                }
                                else
                                {
                                    if (this.SubInfo_UTabControl.Visible)
                                    {
                                        // Ｔａｂモードの場合
                                        this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY4];
                                        this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                        e.NextCtrl = this.rButton_MainSendMailAddrCd0;
                                    }
                                    else
                                    {
                                        // Ｂａｒモードの場合
                                        e.NextCtrl = this.rButton_MainSendMailAddrCd0;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_Note10Guide)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY4];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    e.NextCtrl = rButton_MainSendMailAddrCd0;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = rButton_MainSendMailAddrCd0;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = tEdit_Note10;
                                break;
                            }
                    }
                }
            }
            # endregion

            # region ＜Ｅメール情報＞
            else if (e.PrevCtrl == this.rButton_MainSendMailAddrCd0)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_Note5;
                                }
                                break;
                            }
                        case Keys.Down:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd1;
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = tEdit_MailAddress1;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY2];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    e.NextCtrl = uButton_Note10Guide;
                                }
                                else
                                {
                                    e.NextCtrl = uButton_Note10Guide;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_MailAddress1)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = tEdit_Note5;
                                }
                                break;
                            }
                        case Keys.Left:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd0;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd0;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_MailSendCode1)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.MailSendCode1 = GetComboEditorInputCode(this.tComboEditor_MailSendCode1, customerInfoWork.MailSendCode1);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tComboEditor_AccRecDivCd;
                                // --- ADD 2010/08/10 ------------------------------------>>>>>
                                if (this._style == STYLE_SCROLL)
                                {
                                    e.NextCtrl = tEdit_Note10;
                                }
                                // --- ADD 2010/08/10 ------------------------------------<<<<<
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_MailAddrKindCode1)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.MailAddrKindCode1 = GetComboEditorInputCode(this.tComboEditor_MailAddrKindCode1, customerInfoWork.MailAddrKindCode1);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = tNedit_SalesCnsTaxFrcProcCd;
                                // --- ADD 2010/08/10 ------------------------------------>>>>>
                                if (this._style == STYLE_SCROLL)
                                {
                                    e.NextCtrl = tEdit_Note10;
                                }
                                // --- ADD 2010/08/10 ------------------------------------<<<<<
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd1;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.rButton_MainSendMailAddrCd1)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd0;
                                break;
                            }
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = tEdit_MailAddress2;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = tComboEditor_MailAddrKindCode1;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_MailAddress2)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Left:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd1;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                e.NextCtrl = rButton_MainSendMailAddrCd1;
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tComboEditor_MailSendCode2)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.MailSendCode2 = GetComboEditorInputCode(this.tComboEditor_MailSendCode2, customerInfoWork.MailSendCode2);
                this.SetDisplayFormCustomerInfo(customerInfoWork);
            }
            else if (e.PrevCtrl == this.tComboEditor_MailAddrKindCode2)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.MailAddrKindCode2 = GetComboEditorInputCode(this.tComboEditor_MailAddrKindCode2, customerInfoWork.MailAddrKindCode2);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY5];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    e.NextCtrl = this.tEdit_AccountNoInfo1;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = this.tEdit_AccountNoInfo1;
                                }
                                break;
                            }
                    }
                }
            }
            # endregion
            # region ＜口座情報＞
            else if (e.PrevCtrl == this.tEdit_AccountNoInfo1)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = rButton_MainSendMailAddrCd1;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY4];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    e.NextCtrl = tComboEditor_MailAddrKindCode2;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_MailAddrKindCode2;
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_AccountNoInfo2)
            {

            }
            else if (e.PrevCtrl == this.tEdit_AccountNoInfo3)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY6];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    //e.NextCtrl = this.tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                    e.NextCtrl = this.tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    //e.NextCtrl = this.tComboEditor_BillOutputCode;     // DEL 2009/04/07
                                    e.NextCtrl = this.tComboEditor_ReceiptOutputCode;    // ADD 2009/04/07
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = this.tEdit_AccountNoInfo2;
                                break;
                            }
                    }
                }
            }
            # endregion
            # region ＜伝票・請求書情報＞

            // --- CHG 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
            //else if ( e.PrevCtrl == tComboEditor_QrcodePrtCd )
            else if (e.PrevCtrl == tComboEditor_UOESlipPrtDiv)
            // --- CHG 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<
            {
                // DEL 2009/06/03 ------>>>
                //if (!e.ShiftKey)
                //{
                //    switch (e.Key)
                //    {
                //        case Keys.Return:
                //        case Keys.Tab:
                //            {
                //                panel_SubInfo6.Focus();
                //                e.NextCtrl = e.PrevCtrl;
                //            }
                //            break;
                //    }
                //}
                // DEL 2009/06/03 ------<<<

                // ADD 2009/06/03 ------>>>
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    //..
                                    //this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY7];
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY6];
                                    //..
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    // --- UPD  大矢睦美  2010/01/04 ---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_OnlineKindDiv;    // ADD 2009/04/07
                                    e.NextCtrl = this.tComboEditor_TotalBillOutputDiv;
                                    // --- UPD  大矢睦美  2010/01/04 ----------<<<<<
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    // --- UPD  大矢睦美  2010/01/04 ---------->>>>>
                                    //e.NextCtrl = this.tComboEditor_OnlineKindDiv;    // ADD 2009/04/07
                                    e.NextCtrl = this.tComboEditor_TotalBillOutputDiv;
                                    // --- UPD  大矢睦美  2010/01/04 ----------<<<<<
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                // --- UPD  大矢睦美  2010/01/04 ---------->>>>>
                                //e.NextCtrl = this.tEdit_AccountNoInfo2;
                                e.NextCtrl = this.tComboEditor_EstimatePrtDiv;
                                // --- UPD  大矢睦美  2010/01/04 ----------<<<<<
                                break;
                            }
                    }
                }
                // ADD 2009/06/03 ------<<<
            }
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            else if (e.PrevCtrl == tComboEditor_TotalBillOutputDiv)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY6];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    e.NextCtrl = this.tComboEditor_DetailBillOutputCode;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = this.tComboEditor_DetailBillOutputCode;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = this.tComboEditor_UOESlipPrtDiv;
                                break;
                            }
                    }
                }
            }

            else if (e.PrevCtrl == tComboEditor_DetailBillOutputCode)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY6];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    e.NextCtrl = this.tComboEditor_SlipTtlBillOutputDiv;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = this.tComboEditor_SlipTtlBillOutputDiv;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = this.tComboEditor_TotalBillOutputDiv;
                                break;
                            }
                    }
                }
            }

            else if (e.PrevCtrl == tComboEditor_SlipTtlBillOutputDiv)
            {
                // NextCtrl制御
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    // Ｔａｂモードの場合
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY7];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;

                                    e.NextCtrl = this.tComboEditor_OnlineKindDiv;
                                }
                                else
                                {
                                    // Ｂａｒモードの場合
                                    e.NextCtrl = this.tComboEditor_OnlineKindDiv;
                                }
                                break;
                            }
                    }

                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    //switch (e.Key)
                    //{
                    //    case Keys.Enter:
                    //        {
                    //            if (this._style == STYLE_SCROLL && !e.PrevCtrl.Name.Equals(nextControlBak.Name))
                    //            {
                    //                DialogResult dialogResult = TMsgDisp.Show(
                    //                    this,
                    //                    emErrorLevel.ERR_LEVEL_QUESTION,
                    //                    this.Name,
                    //                    "登録してもよろしいですか？",
                    //                    0,
                    //                    MessageBoxButtons.YesNo,
                    //                    MessageBoxDefaultButton.Button1);

                    //                if (dialogResult == DialogResult.Yes)
                    //                {
                    //                    if (this.DataSave != null)
                    //                    {
                    //                        this.DataSave(true);
                    //                        e.NextCtrl = null;
                    //                        return;
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    this.tComboEditor_SlipTtlBillOutputDiv.Focus();
                    //                    e.NextCtrl = null;
                    //                }
                    //            }
                    //            break;
                    //        }
                    //}
                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                e.NextCtrl = this.tComboEditor_DetailBillOutputCode;
                                break;
                            }
                    }
                }
            }
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            # endregion

            // ADD 2009/06/03 ------>>>
            # region ＜オンライン情報＞
            else if (e.PrevCtrl == this.tComboEditor_OnlineKindDiv)
            {
                // 画面入力値を取得して再表示
                customerInfoWork.OnlineKindDiv = GetComboEditorInputCode(this.tComboEditor_OnlineKindDiv, customerInfoWork.OnlineKindDiv);
                this.SetDisplayFormCustomerInfo(customerInfoWork);

                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Up:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    // --- DEL 2010/08/10 ------------------------------------>>>>>
                                    //e.NextCtrl = tComboEditor_SalesAreaCode;
                                    // --- DEL 2010/08/10 ------------------------------------<<<<<
                                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                                    e.NextCtrl = tEdit_SalesAreaNm;
                                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                                }
                                else
                                {
                                    // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
                                    //e.NextCtrl = tComboEditor_UOESlipPrtDiv;
                                    e.NextCtrl = tComboEditor_SlipTtlBillOutputDiv;
                                    // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
                                }
                                break;
                            }
                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                        case Keys.Tab:
                            {
                                if ((int)this.tComboEditor_OnlineKindDiv.Value == 10)
                                {
                                    e.NextCtrl = this.tEdit_CustomerEpCode;
                                }
                                else
                                {
                                    // UPD 陳健 K2014/02/06 ------------------------------>>>>>
                                    //e.NextCtrl = null;
                                    // DEL 梶谷貴士 2021/05/10 ------------------------------>>>>>
                                    //if (_opt_Maehashi == (int)Option.ON)
                                    //{
                                    // DEL 梶谷貴士 2021/05/10 ------------------------------<<<<<
                                        if (this.SubInfo_UTabControl.Visible)
                                        {
                                            this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs["SubInfo8"];
                                            this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                            e.NextCtrl = this.check_CustomerInfoGuideDisp;
                                        }
                                    // DEL 梶谷貴士 2021/05/10 ------------------------------>>>>>
                                    //}
                                    //else
                                    //{
                                        //e.NextCtrl = null;
                                    //}
                                    // DEL 梶谷貴士 2021/05/10 ------------------------------<<<<<
                                    // UPD 陳健 K2014/02/06 ------------------------------<<<<< 
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                if ((int)this.tComboEditor_OnlineKindDiv.Value == 10)
                                {
                                    e.NextCtrl = this.tEdit_CustomerEpCode;
                                    break;
                                }

                                // UPD 陳健 K2014/02/06 ----------------------------------------------------------->>>>>
                                // DEL 梶谷貴士 K2021/05/10 ----------------------------------------------------------->>>>>
                                //if (_opt_Maehashi == (int)Option.OFF)
                                //{
                                //    if ((this.tComboEditor_OnlineKindDiv.Text.IndexOf("なし") >= 0 || this.tComboEditor_OnlineKindDiv.Text.Equals("0"))
                                //        && !e.PrevCtrl.Name.Equals(nextControlBak.Name))
                                //    {
                                //        DialogResult dialogResult = TMsgDisp.Show(
                                //            this,
                                //           emErrorLevel.ERR_LEVEL_QUESTION,
                                //            this.Name,
                                //            "登録してもよろしいですか？",
                                //            0,
                                //            MessageBoxButtons.YesNo,
                                //            MessageBoxDefaultButton.Button1);

                                //        if (dialogResult == DialogResult.Yes)
                                //        {
                                //            if (this.DataSave != null)
                                //            {
                                //                this.DataSave(true);
                                //                e.NextCtrl = null;
                                //                return;
                                //            }
                                //        }
                                //        else
                                //        {
                                //            this.tComboEditor_OnlineKindDiv.Focus();
                                //            this._preComboEditorValue = this.tComboEditor_OnlineKindDiv.Value;
                                //            e.NextCtrl = null;
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                // DEL 梶谷貴士 K2021/05/10 -----------------------------------------------------------<<<<<
                                    if (this.SubInfo_UTabControl.Visible)
                                    {
                                        this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs["SubInfo8"];
                                        this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                        // UPD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                                        //e.NextCtrl = this.memo_richTextBox;
                                        e.NextCtrl = this.check_CustomerInfoGuideDisp;
                                        // UPD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                                    }
                                // DEL 梶谷貴士 K2021/05/10 ----------------------------------------------------------->>>>>
                                //}
                                // DEL 梶谷貴士 K2021/05/10 -----------------------------------------------------------<<<<<
                                break;
                                // UPD 陳健 K2014/02/06 -----------------------------------------------------------<<<<<
                            }
                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Tab:
                        case Keys.Return:
                            {
                                if (SubInfo_UTabControl.Visible)
                                {
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY6];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
                                    //e.NextCtrl = tComboEditor_UOESlipPrtDiv;
                                    e.NextCtrl = tComboEditor_SlipTtlBillOutputDiv;
                                    // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
                                }
                                else
                                {
                                    // --- DEL  大矢睦美  2010/01/04 ---------->>>>>
                                    //e.NextCtrl = tComboEditor_UOESlipPrtDiv;
                                    e.NextCtrl = tComboEditor_SlipTtlBillOutputDiv;
                                    // --- DEL  大矢睦美  2010/01/04 ----------<<<<<
                                }
                                break;
                            }
                    }
                }
            }
            else if (e.PrevCtrl == this.tEdit_CustomerEpCode)
            {

            }
            else if (e.PrevCtrl == this.tEdit_CustomerSecCode)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            {
                                // UPD 陳健 K2014/02/06 ------------------>>>>>
                                //panel_SubInfo7.Focus();
                                //e.NextCtrl = e.PrevCtrl;
                                // DEL 梶谷貴士 2021/05/10 ------------------>>>>>
                                //if (_opt_Maehashi == (int)Option.ON)
                                //{
                                // DEL 梶谷貴士 2021/05/10 ------------------<<<<<
                                    if (this.SubInfo_UTabControl.Visible)
                                    {
                                        this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs["SubInfo8"];
                                        this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                        e.NextCtrl = this.check_CustomerInfoGuideDisp;
                                    }
                                // DEL 梶谷貴士 2021/05/10 ------------------>>>>>
                                //}
                                //else
                                //{
                                //    panel_SubInfo7.Focus();
                                //    e.NextCtrl = e.PrevCtrl;
                                //}
                                // DEL 梶谷貴士 2021/05/10 ------------------<<<<<
                                // UPD 陳健 K2014/02/06 ------------------<<<<<
                            }
                            break;
                    }

                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    switch (e.Key)
                    {
                        case Keys.Enter:
                            {
                                // UPD 陳健 K2014/02/06 ----------------------------------------------------------->>>>>
                                // DEL 梶谷貴士 2021/05/10 ----------------------------------------------------------->>>>>
                                //if (_opt_Maehashi == (int)Option.OFF)
                                //{
                                //    if (!e.PrevCtrl.Name.Equals(nextControlBak.Name))
                                //    {
                                //        DialogResult dialogResult = TMsgDisp.Show(
                                //            this,
                                //            emErrorLevel.ERR_LEVEL_QUESTION,
                                //            this.Name,
                                //            "登録してもよろしいですか？",
                                //            0,
                                //            MessageBoxButtons.YesNo,
                                //            MessageBoxDefaultButton.Button1);

                                //        if (dialogResult == DialogResult.Yes)
                                //        {
                                //            if (this.DataSave != null)
                                //            {
                                //                this.DataSave(true);
                                //                e.NextCtrl = null;
                                //                return;
                                //            }
                                //        }
                                //        else
                                //        {
                                //            this.tEdit_CustomerSecCode.Focus();
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                // DEL 梶谷貴士 2021/05/10 -----------------------------------------------------------<<<<<
                                    if (this.SubInfo_UTabControl.Visible)
                                    {
                                        this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs["SubInfo8"];
                                        this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                        // UPD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                                        //e.NextCtrl = this.memo_richTextBox;
                                        e.NextCtrl = this.check_CustomerInfoGuideDisp;
                                        // UPD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                                    }
                                // DEL 梶谷貴士 2021/05/10 ----------------------------------------------------------->>>>>
                                //}
                                // DEL 梶谷貴士 2021/05/10 -----------------------------------------------------------<<<<<
                                break;
                                // UPD 陳健 K2014/02/06 -----------------------------------------------------------<<<<<
                            }
                    }
                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                }
            }
            // ADD 陳健 K2014/02/06 ----------------------------------------------------->>>>>
            // ADD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
            if (e.PrevCtrl == this.check_CustomerInfoGuideDisp)
            {
                if (e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Enter:
                        case Keys.Tab:
                            {
                                if (this.SubInfo_UTabControl.Visible)
                                {
                                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs["SubInfo7"];
                                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                    if (!this.tEdit_CustomerSecCode.Enabled)
                                    {
                                        e.NextCtrl = this.tComboEditor_OnlineKindDiv;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_CustomerSecCode;
                                    }

                                }
                            }
                            break;
                    }

                }
                else
                {
                    e.NextCtrl = this.memo_richTextBox;
                }
            }
            // ADD 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<
            if (e.PrevCtrl == this.memo_richTextBox)
            {
                if (e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Enter:
                        case Keys.Tab:
                            {
                                // DEL 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                                //if (this.SubInfo_UTabControl.Visible)
                                //{
                                //    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs["SubInfo7"];
                                //    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                                //    if (!this.tEdit_CustomerSecCode.Enabled)
                                //    {
                                //        e.NextCtrl = this.tComboEditor_OnlineKindDiv;
                                //    }
                                //    else
                                //    {
                                //        e.NextCtrl = this.tEdit_CustomerSecCode;
                                //    }

                                //}
                                // DEL 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<
                                // ADD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                                e.NextCtrl = this.check_CustomerInfoGuideDisp;
                                // ADD 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<
                            }
                            break;
                    }

                }
                else
                {
                    //エディタ内でEnterKeyが押された場合
                    if (e.Key == Keys.Enter)
                    {
                        // ADD 梶谷貴士 2021/05/10 ----------------------------------------------------->>>>>
                        if (!saveFlg)
                        {
                        // ADD 梶谷貴士 2021/05/10 -----------------------------------------------------<<<<<
                            if (this.memo_richTextBox.Text.Length < 1000)
                            {
                                e.NextCtrl = null;
                                //改行文字を挿入します
                                this.memo_richTextBox.SelectedText += System.Environment.NewLine;
                                this.memo_richTextBox.AcceptsTab = true;
                            }
                        } // ADD 梶谷貴士 2021/05/10

                    }
                    //エディタ内で TabKeyが押された場合
                    else if (e.Key == Keys.Tab)
                    {
                        if (this.memo_richTextBox.Text.Length < 1000)
                        {
                            //タブを挿入
                            this.memo_richTextBox.SelectedText += "\t";
                            e.NextCtrl = null;
                        }

                    }
                }
            }
            // ADD 陳健 K2014/02/06 -----------------------------------------------------<<<<<
            # endregion
            // ADD 2009/06/03 ------<<<
            
            // 画面→得意先クラス格納処理
            this.GetDisplayDataToCustomerInfo( ref customerInfoWork );

            // メモリ上の内容と比較する
            ArrayList arRetList = customerInfoWork.Compare( customerInfoBuff );

            if ( arRetList.Count > 0 )
            {
                // 得意先クラス→画面格納処理
                // UPD 陳健 K2014/02/06 ----------------------------------------------------->>>>>
                //this.SetDisplayFormCustomerInfo(customerInfoWork);
                if (!this.memo_richTextBox.Focused)
                {
                    this.SetDisplayFormCustomerInfo(customerInfoWork);
                }
                // UPD 陳健 K2014/02/06 -----------------------------------------------------<<<<<

                // Static情報の変更処理
                this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );

                this._customerInfo = customerInfoWork.Clone();
            }

            if ( isCustomerAgentNmChange )
            {
                // 管理拠点コード転送イベントコール処理
                this.TransmitMngSectionCodeEventCall( mngSectionCode );
            }

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (this.SetGuideEnabled != null)
            {
                if (e.NextCtrl != null)
                {
                    switch (e.NextCtrl.Name)
                    {
                        case "tEdit_MngSectionNm":                      // 管理拠点ガイド起動
                        case "tEdit_CustomerAgentNm":                   // 得意先担当
                        case "tEdit_OldCustomerAgentNm":                // 旧担当
                        case "tEdit_CustWarehouseCd":                   // 優先倉庫
                        case "tEdit_ClaimSectionCode":                  // 請求拠点
                        case "tNedit_ClaimCode":                        // 請求先コード
                        case "tEdit_BillCollecterNm":                   // 集金担当
                        case "tNedit_SalesUnPrcFrcProcCd":              // 単価端数処理
                        case "tNedit_SalesMoneyFrcProcCd":              // 金額端数処理
                        case "tNedit_SalesCnsTaxFrcProcCd":             // 消費税端数処理
                        case "tEdit_PostNo":                            // 郵便番号
                        case "tEdit_Note1":                             // 得意先備考１～１０
                        case "tEdit_Note2":                             // 得意先備考１～１０
                        case "tEdit_Note3":                             // 得意先備考１～１０
                        case "tEdit_Note4":                             // 得意先備考１～１０
                        case "tEdit_Note5":                             // 得意先備考１～１０
                        case "tEdit_Note6":                             // 得意先備考１～１０
                        case "tEdit_Note7":                             // 得意先備考１～１０
                        case "tEdit_Note8":                             // 得意先備考１～１０
                        case "tEdit_Note9":                             // 得意先備考１～１０
                        case "tEdit_Note10":                            // 得意先備考１～１０
                        case "tEdit_BusinessTypeNm":                    // 業種
                        case "tEdit_JobTypeName":                       // 職種
                        case "tEdit_SalesAreaNm":                       // 地区
                            {
                                this.SetGuideEnabled(true);
                                break;
                            }
                        default:
                            {
                                if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                    || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                                {
                                    this.SetGuideEnabled(false);
                                }
                                break;
                            }
                    }
                }
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
        }
        /// <summary>
        /// 文字列項目のコード変換処理(ｾﾞﾛ詰め対応)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode( TEdit targetEdit )
        {
            UiSet uiset;
            if ( uiSetControl1.ReadUISet( out uiset, targetEdit.Name ) == 0 )
            {
                // 設定に基づきゼロ詰め
                // （本来この処理を不要にする為のコンポーネントだが、入力方式が特殊なので手動対応する）

                return targetEdit.Text.TrimEnd().PadLeft( uiset.Column, '0' );
            }
            else
            {
                // 設定を取得できなかった場合はそのまま返す。
                return targetEdit.Text.TrimEnd();
            }
        }
        /// <summary>
        /// コンボエディタのコード値取得処理
        /// </summary>
        /// <param name="comboEditor"></param>
        /// <param name="oldCode"></param>
        /// <returns></returns>
        private int GetComboEditorInputCode( TComboEditor comboEditor, int oldCode )
        {
            int code = ComboEditorItemControl.GetComboEditorValue( comboEditor, ComboEditorGetDataType.TAG );

            if ( code < 0 )
            {
                code = oldCode;
            }

            return code;
        }

        /// <summary>
        /// 締日チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 締日チェックを行います。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/12/06</br>
        /// </remarks>
        public int CheckTotalDay(ArrayList customerTotalDayList)
        {
            if (!this.tNedit_TotalDay.Enabled)
            {
                // 締日が入力不可で、チェック対象外
                return 0;
            }
            else
            {
                foreach (int totalDay in customerTotalDayList)
                {
                    if (totalDay == this.tNedit_TotalDay.GetInt())
                    {
                        return 0;
                    }
                }
            }
            return -1;
        }
        # endregion

        // ===================================================================================== //
        // ボタンクリックイベント
        // ===================================================================================== //
        # region Button Click Event Method
        /// <summary>
        /// 住所ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void uButton_AddressGuide_Click( object sender, System.EventArgs e )
        {
            AddressGuideResult agResult = null;
            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (this.tEdit_PostNo.Focused)
            {
                customerInfoWork.PostNo = this.tEdit_PostNo.Text;
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            // 郵便番号ガイド表示処理
            int status = this._customerInputAcs.GetAddressFromPostNo( customerInfoWork.PostNo, out agResult );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;

            // 住所情報戻り値クラス→得意先クラス格納処理
            this._customerInputAcs.SetCustomerInfoOwnerAddressFromAddressGuideResult( agResult, ref customerInfoWork );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            this.tEdit_Address1.Focus();
            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 請求先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void uButton_ClaimNameGuide_Click( object sender, System.EventArgs e )
        {
            // 得意先検索（簡易版）
            PMKHN04005UA customerSearchForm = new PMKHN04005UA( PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY );
            
            // 自動検索する
            customerSearchForm.AutoSearch = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 DEL
            //// 管理営業所 ← 請求営業所をセット
            //customerSearchForm.MngSectionCode = _claimSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            _customerSelected = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            // 選択時イベント処理登録
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler( this.CustomerSearchForm_CustomerSelect );

            // ガイド表示
            customerSearchForm.ShowDialog( this );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            if ( _customerSelected )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            {
                if ( tNedit_TotalDay.Enabled )
                {
                    this.tNedit_TotalDay.Focus();
                }
                else
                {
                    tEdit_BillCollecterNm.Focus();
                    // --- ADD 2010/08/10 ------------------------------------>>>>>
                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                    // --- ADD 2010/08/10 ------------------------------------<<<<<
                }
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車輌検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        {
            if ( customerSearchRet == null ) return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            CustomerInfo claimInfo = null;
            if ( (this._customerInfo.CustomerCode != 0) && (customerSearchRet.CustomerCode != this._customerInfo.CustomerCode) )
            {
                // 請求先情報を取得
                this._customerInputAcs.GetCustomerInfoFromCustomerCode( customerSearchRet.CustomerCode, out claimInfo );
                if ( claimInfo.CustomerCode != claimInfo.ClaimCode )
                {
                    TMsgDisp.Show( this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択された得意先は請求先コードが異なる為、請求先として選択できません",
                        0,
                        MessageBoxButtons.OK );
                    return;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD

            if ( (this._customerInfo.CustomerCode != 0) && (this._customerInfo.ClaimCode != 0) && (this._customerInfo.ClaimCode != customerSearchRet.CustomerCode) )
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "請求先を変更しようとしています。" + "\r\n" + "\r\n" +
                    "よろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1 );

                if ( dialogResult != DialogResult.Yes )
                {
                    return;
                }
            }

            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //// 得意先クラス→得意先クラス（請求先情報）格納処理
            //this._customerInputAcs.SetCustomerInfoClaimInfoFromCustomerInfo( customerSearchRet, ref customerInfoWork );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            // 請求先情報を格納
            if ( claimInfo != null )
            {
                this._customerInputAcs.SetCustomerInfoClaimInfoFromCustomerInfo( claimInfo, ref customerInfoWork );
            }
            else
            {
                this._customerInputAcs.SetCustomerInfoClaimInfoFromCustomerInfo( customerSearchRet, ref customerInfoWork );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            this._prevControl = this.ActiveControl;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            _customerSelected = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

            //if ( (this._customerInfo.ClaimCode == customerSearchRet.CustomerCode) )
            //{
            //    this.tNedit_TotalDay.Focus();
            //}
            //else
            //{
            //    tEdit_BillCollecterNm.Focus();
            //}
        }

        /// <summary>
        /// 得意先担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void uButton_CustomerAgentNmGuide_Click( object sender, System.EventArgs e )
        {
            Employee employee = null;
            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            // 従業員ガイド表示処理
            int status = this._customerInputAcs.ShowEmployeeGuide( out employee );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;

            // 従業員クラス→得意先クラスの得意先担当情報格納処理
            this._customerInputAcs.SetCustomerInfoAgentFromEmployee( employee, ref customerInfoWork );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            // 管理拠点コード転送イベントコール処理
            this.TransmitMngSectionCodeEventCall( employee.BelongSectionCode );

            this.tEdit_OldCustomerAgentNm.Focus();
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (this.SetGuideEnabled != null)
            {
                this.SetGuideEnabled(true);
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            this._prevControl = this.ActiveControl;
        }
        /// <summary>
        /// 旧得意先担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void uButton_OldCustomerAgentNmGuide_Click( object sender, System.EventArgs e )
        {
            Employee employee = null;
            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            // 従業員ガイド表示処理
            int status = this._customerInputAcs.ShowEmployeeGuide( out employee );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;

            // 従業員クラス→得意先クラスの旧得意先担当情報格納処理
            this._customerInputAcs.SetOldCustomerInfoAgentFromEmployee( employee, ref customerInfoWork );

            this.tEdit_OldCustomerAgentNm.Focus();
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (this.SetGuideEnabled != null)
            {
                this.SetGuideEnabled(true);
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            this.tDateEdit_CustAgentChgDate.Focus();
            this._prevControl = this.ActiveControl;
        }
        /// <summary>
        /// 集金担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void uButton_BillCollecterNmGuide_Click( object sender, System.EventArgs e )
        {
            Employee employee = null;
            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            // 従業員ガイド表示処理
            int status = this._customerInputAcs.ShowEmployeeGuide( out employee );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;

            // 従業員クラス→得意先クラスの集金担当情報格納処理
            this._customerInputAcs.SetBillCollecterFromEmployee( employee, ref customerInfoWork );

            //this.tComboEditor_BillOutputCode.Focus();     // DEL 2009/04/07
            this.tComboEditor_ReceiptOutputCode.Focus();    // ADD 2009/04/07
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            this._preComboEditorValue = this.tComboEditor_ReceiptOutputCode.Value;
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //if ( tComboEditor_TotalAmntDspWayRef.Enabled )
            //{
            //    this.tComboEditor_TotalAmntDspWayRef.Focus();
            //}
            if (tComboEditor_CustCTaXLayRefCd.Enabled)
            {
                this.tComboEditor_CustCTaXLayRefCd.Focus();
                // --- ADD 2010/08/10 ------------------------------------>>>>>
                this._preComboEditorValue = this.tComboEditor_CustCTaXLayRefCd.Value;
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
            else
            {
                tComboEditor_CreditMngCode.Focus();
                // --- ADD 2010/08/10 ------------------------------------>>>>>
                this._preComboEditorValue = this.tComboEditor_CreditMngCode.Value;
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (this.tEdit_BillCollecterNm.Focused)
            {
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 備考ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void uButton_Note1Guide_Click( object sender, System.EventArgs e )
        {
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //if ( !(sender is Infragistics.Win.Misc.UltraButton) )
            //{
            //    return;
            //}
            // --- DEL 2010/08/10 ------------------------------------<<<<<

            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            NoteGuidBd noteGuidBd;
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //int noteGuideDivCd = Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString());
            // --- DEL 2010/08/10 ------------------------------------<<<<<

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            int noteGuideDivCd = 0;
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                noteGuideDivCd = Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString());
            }
            else if (this.tEdit_Note1.Focused)
            {
                noteGuideDivCd = 1;
            }
            else if (this.tEdit_Note2.Focused)
            {
                noteGuideDivCd = 2;
            }
            else if (this.tEdit_Note3.Focused)
            {
                noteGuideDivCd = 3;
            }
            else if (this.tEdit_Note4.Focused)
            {
                noteGuideDivCd = 4;
            }
            else if (this.tEdit_Note5.Focused)
            {
                noteGuideDivCd = 5;
            }
            else if (this.tEdit_Note6.Focused)
            {
                noteGuideDivCd = 6;
            }
            else if (this.tEdit_Note7.Focused)
            {
                noteGuideDivCd = 7;
            }
            else if (this.tEdit_Note8.Focused)
            {
                noteGuideDivCd = 8;
            }
            else if (this.tEdit_Note9.Focused)
            {
                noteGuideDivCd = 9;
            }
            else if (this.tEdit_Note10.Focused)
            {
                noteGuideDivCd = 10;
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            // 備考ガイドガイド起動
            int status = this._customerInputAcs.ShowNoteGuideGuide( noteGuideDivCd, out noteGuidBd );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;

            // 備考ガイドボディクラス→得意先情報クラス格納処理
            this._customerInputAcs.SetCustomerInfoFromNoteGuidBd( noteGuideDivCd, noteGuidBd, ref customerInfoWork );

            // 得意先情報クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // 画面→得意先情報クラス格納処理
            this.GetDisplayDataToCustomerInfo( ref customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE1 )
            {
                this.tEdit_Note2.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE2 )
            {
                this.tEdit_Note3.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE3 )
            {
                this.tEdit_Note4.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE4 )
            {
                this.tEdit_Note5.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE5 )
            {
                this.tEdit_Note6.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE6 )
            {
                this.tEdit_Note7.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE7 )
            {
                this.tEdit_Note8.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE8 )
            {
                this.tEdit_Note9.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE9 )
            {
                this.tEdit_Note10.Focus();

                // --- ADD 2010/08/10 ------------------------------------>>>>>
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            else if ( noteGuideDivCd == CustomerInputAcs.NoteGd_DivCd_CUSTOMERNOTE10 )
            {
                if ( this.SubInfo_UTabControl.Visible )
                {
                    // Ｔａｂモードの場合
                    this.SubInfo_UTabControl.ActiveTab = this.SubInfo_UTabControl.Tabs[SUBINFO_KEY4];
                    this.SubInfo_UTabControl.ActiveTab.Selected = true;
                }
                rButton_MainSendMailAddrCd0.Focus();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            this._prevControl = this.ActiveControl;
        }

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// BusinessTypeSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : BusinessTypeSt_GuideBtn_Click時に発生します。</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void uButton_BusinessTypeCdGuide_Click(object sender, EventArgs e)
        {
            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            // 項目に展開
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    this.tEdit_BusinessTypeNm.Text = userGdBd.GuideName;
                    this._businessTypeCd = userGdBd.GuideCode;
                    this.tEdit_JobTypeName.Focus();
                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    this.tEdit_BusinessTypeNm.Text = userGdBd.GuideName;
                    this._businessTypeCd = userGdBd.GuideCode;
                    this.tEdit_JobTypeName.Focus();
                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                }
            }
        }

        /// <summary>
        /// uButton_SalesAreaCdGuide_Click
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : uButton_SalesAreaCdGuide_Click時に発生します。</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void uButton_SalesAreaCdGuide_Click(object sender, EventArgs e)
        {
            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    this.tEdit_SalesAreaNm.Text = userGdBd.GuideName;
                    this._saleAreaCd = userGdBd.GuideCode;
                    this.tComboEditor_CarMngDivCd.Focus();
                    this._preComboEditorValue = this.tComboEditor_CarMngDivCd.Value;
                }
            }
            else
            {
                if (status == 0)
                {
                    this.tEdit_SalesAreaNm.Text = userGdBd.GuideName;
                    this._saleAreaCd = userGdBd.GuideCode;
                    this.tComboEditor_CarMngDivCd.Focus();
                    this._preComboEditorValue = this.tComboEditor_CarMngDivCd.Value;
                }
            }
        }

        /// <summary>
        /// uButton_JobTypeCodeGuide_Click
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note        : uButton_JobTypeCodeGuide_Click時に発生します。</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void uButton_JobTypeCodeGuide_Click(object sender, EventArgs e)
        {
            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 34);

            // 項目に展開
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    this.tEdit_JobTypeName.Text = userGdBd.GuideName;
                    this._jobTypeCode = userGdBd.GuideCode;
                    this.tEdit_SalesAreaNm.Focus();
                }
            }
            else
            {
                if (status == 0)
                {
                    this.tEdit_JobTypeName.Text = userGdBd.GuideName;
                    this._jobTypeCode = userGdBd.GuideCode;
                    this.tEdit_SalesAreaNm.Focus();
                }
            }
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        /// <summary>
        /// 売上端数処理コードガイド起動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            // --- DEL 2010/08/10 ------------------------------------>>>>>
            //string tag = (sender as Infragistics.Win.Misc.UltraButton).Tag.ToString();
            // --- DEL 2010/08/10 ------------------------------------<<<<<

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            string tag = string.Empty;
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                tag = (sender as Infragistics.Win.Misc.UltraButton).Tag.ToString();
            }
            else if (this.tNedit_SalesUnPrcFrcProcCd.Focused)
            {
                tag = "2";
            }
            else if (this.tNedit_SalesMoneyFrcProcCd.Focused)
            {
                tag = "0";
            }
            else if (this.tNedit_SalesCnsTaxFrcProcCd.Focused)
            {
                tag = "1";
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<

            TNedit targetNedit = null;
            int procDiv = 0;

            CustomerInfo customerInfoWork = this._customerInfo.Clone();
            // 得意先情報クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            if ( tag.Trim().CompareTo( "0" ) == 0 )
            {
                // 売上金額
                targetNedit = tNedit_SalesMoneyFrcProcCd;
                procDiv = 0;
            }
            else if ( tag.Trim().CompareTo( "1" ) == 0 )
            {
                // 消費税
                targetNedit = tNedit_SalesCnsTaxFrcProcCd;
                procDiv = 1;
            }
            else if ( tag.Trim().CompareTo( "2" ) == 0 )
            {
                // 売上単価
                targetNedit = tNedit_SalesUnPrcFrcProcCd;
                procDiv = 2;
            }

            // ガイド起動
            SalesProcMoney salesProcMoney;
            int status = this._customerInputAcs.ShowSalesProcMoneyGuide( out salesProcMoney, procDiv );

            // 対象Editに格納
            if ( targetNedit != null && status == 0 )
            {
                targetNedit.SetInt( salesProcMoney.FractionProcCode );

                // 画面→得意先情報クラス格納処理
                this.GetDisplayDataToCustomerInfo( ref customerInfoWork );
                // Static情報の変更処理
                this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
                this._customerInfo = customerInfoWork;

                switch ( targetNedit.Name )
                {
                    case "tNedit_SalesUnPrcFrcProcCd":
                        {
                            tNedit_SalesMoneyFrcProcCd.Focus();
                            // --- ADD 2010/08/10 ------------------------------------>>>>>
                            if (this.SetGuideEnabled != null)
                            {
                                this.SetGuideEnabled(true);
                            }
                            // --- ADD 2010/08/10 ------------------------------------<<<<<
                        }
                        break;
                    case "tNedit_SalesMoneyFrcProcCd":
                        {
                            tNedit_SalesCnsTaxFrcProcCd.Focus();
                            // --- ADD 2010/08/10 ------------------------------------>>>>>
                            if (this.SetGuideEnabled != null)
                            {
                                this.SetGuideEnabled(true);
                            }
                            // --- ADD 2010/08/10 ------------------------------------<<<<<
                        }
                        break;
                    case "tNedit_SalesCnsTaxFrcProcCd":
                        {
                            if ( SubInfo_UTabControl.Visible )
                            {
                                switch ( SubInfo_UTabControl.SelectedTab.Index )
                                {
                                    case 0:
                                        tEdit_PostNo.Focus();
                                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                                        if (this.SetGuideEnabled != null)
                                        {
                                            this.SetGuideEnabled(true);
                                        }
                                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                                        break;
                                    case 1:
                                        tEdit_Note1.Focus();
                                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                                        if (this.SetGuideEnabled != null)
                                        {
                                            this.SetGuideEnabled(true);
                                        }
                                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                                        break;
                                    case 2:
                                        tEdit_MailAddress1.Focus();
                                        break;
                                    case 3:
                                        tEdit_AccountNoInfo1.Focus();
                                        break;
                                    case 4:
                                        //tComboEditor_BillOutputCode.Focus();      // DEL 2009/04/07
                                        tComboEditor_ReceiptOutputCode.Focus();     // ADD 2009/04/07
                                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                                        this._preComboEditorValue = this.tComboEditor_ReceiptOutputCode.Value;
                                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                                        break;
                                    // ADD 2009/06/03 ------>>>
                                    case 5:
                                        tComboEditor_OnlineKindDiv.Focus();
                                        // --- ADD 2010/08/10 ------------------------------------>>>>>
                                        this._preComboEditorValue = this.tComboEditor_OnlineKindDiv.Value;
                                        // --- ADD 2010/08/10 ------------------------------------<<<<<
                                        break;
                                    // ADD 2009/06/03 ------<<<
                                }
                            }
                            else
                            {
                                tEdit_PostNo.Focus();
                                // --- ADD 2010/08/10 ------------------------------------>>>>>
                                if (this.SetGuideEnabled != null)
                                {
                                    this.SetGuideEnabled(true);
                                }
                                // --- ADD 2010/08/10 ------------------------------------<<<<<
                            }
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        /// <summary>
        /// 拠点ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private void SectionNmGuide_uButton_Click( object sender, EventArgs e )
        {
            //string tag = (sender as Infragistics.Win.Misc.UltraButton).Tag.ToString();
            //TEdit targetEdit = null;

            // ガイド起動
            SecInfoSet secInfoSet;
            int status = this._customerInputAcs.ShowSectionGuide( out secInfoSet );

            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            if ( status == 0 )
            {
                // 対象Editに格納
                if ( sender == uButton_MngSectionNmGuide )
                {
                    // 管理拠点
                    this.tEdit_MngSectionNm.Text = secInfoSet.SectionGuideNm;
                    customerInfoWork.MngSectionCode = secInfoSet.SectionCode;
                    customerInfoWork.MngSectionName = secInfoSet.SectionGuideNm;

                    // フォーカス
                    tEdit_CustomerAgentNm.Focus();

                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                }
                else if (sender == uButton_ClaimSectionGuide)
                {
                    // 請求拠点
                    this.tEdit_ClaimSectionCode.Text = secInfoSet.SectionGuideNm;
                    customerInfoWork.ClaimSectionCode = secInfoSet.SectionCode;
                    customerInfoWork.ClaimSectionName = secInfoSet.SectionGuideNm;

                    // フォーカス
                    tNedit_ClaimCode.Focus();

                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                }
                // --- ADD 2010/08/10 ------------------------------------>>>>>
                else if (this.tEdit_MngSectionNm.Focused)
                {
                    // 管理拠点
                    this.tEdit_MngSectionNm.Text = secInfoSet.SectionGuideNm;
                    customerInfoWork.MngSectionCode = secInfoSet.SectionCode;
                    customerInfoWork.MngSectionName = secInfoSet.SectionGuideNm;

                    // フォーカス
                    tEdit_CustomerAgentNm.Focus();

                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                }
                else if (this.tEdit_ClaimSectionCode.Focused)
                {
                    // 請求拠点
                    this.tEdit_ClaimSectionCode.Text = secInfoSet.SectionGuideNm;
                    customerInfoWork.ClaimSectionCode = secInfoSet.SectionCode;
                    customerInfoWork.ClaimSectionName = secInfoSet.SectionGuideNm;

                    // フォーカス
                    tNedit_ClaimCode.Focus();

                    if (this.SetGuideEnabled != null)
                    {
                        this.SetGuideEnabled(true);
                    }
                }
                // --- ADD 2010/08/10 ------------------------------------<<<<<
            }
            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (this.SetGuideEnabled != null)
            {
                this.SetGuideEnabled(true);
            }
            if (this.uButton_ClaimSectionGuide.Focused || this.uButton_MngSectionNmGuide.Focused)
            {
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(false);
                }
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
        }
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustWarehouseGuide_Click( object sender, EventArgs e )
        {
            CustomerInfo customerInfoWork = this._customerInfo.Clone();

            // ガイド表示
            Warehouse warehouse;
            int status = this._customerInputAcs.ShowWarehouseGuide( out warehouse, customerInfoWork.MngSectionCode );

            if (status == 0)
            {
                //　対象Editに格納
                string code = warehouse.WarehouseCode.Trim();
                if (code != string.Empty)
                {
                    this.tEdit_CustWarehouseCd.Text = code;
                    customerInfoWork.CustWarehouseCd = code;
                    customerInfoWork.CustWarehouseName = warehouse.WarehouseName;

                    tNedit_CustAnalysCode1.Focus();
                }
            }
            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( customerInfoWork );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, customerInfoWork );
            this._customerInfo = customerInfoWork;

            // --- ADD 2010/08/10 ------------------------------------>>>>>
            if (status != 0 && this.tEdit_CustWarehouseCd.Focused)
            {
                if (this.SetGuideEnabled != null)
                {
                    this.SetGuideEnabled(true);
                }
            }
            // --- ADD 2010/08/10 ------------------------------------<<<<<
        }
        # endregion

        // ===================================================================================== //
        // 入力値変更イベント
        // ===================================================================================== //
        # region Value Changed Event Method
        /// <summary>
        /// 得意先名称変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tEdit_Name_ValueChanged( object sender, System.EventArgs e )
        {
            if ( !(sender is TEdit) )
            {
                return;
            }

            if ( ((TEdit)sender).Modified == false )
            {
                return;
            }

            if ( ((TEdit)sender) == this.tEdit_Name )
            {
                if ( ((TEdit)sender).Text == "" )
                {
                    this.tEdit_Kana.Clear();
                }
            }

            if ( (TEdit)sender != tEdit_CustomerSnm && tEdit_CustomerSnm.Enabled )
            {
                // 略称の入力補助対応
                if ( _beforeName.Length < this.tEdit_Name.DataText.Length )
                {
                    if ( this.tEdit_Name.DataText.StartsWith( _beforeName ) )
                    {
                        // 自動入力
                        this.tEdit_CustomerSnm.DataText += this.tEdit_Name.DataText.Substring( _beforeName.Length );
                        // 文字列長補正
                        tEdit_CustomerSnm.Text = tEdit_CustomerSnm.Text.Substring( 0, Math.Min( tEdit_CustomerSnm.Text.Length, tEdit_CustomerSnm.ExtEdit.Column ) );
                    }
                }
                _beforeName = this.tEdit_Name.DataText;
                if ( this.tEdit_Name.Text == string.Empty )
                {
                    this.tEdit_CustomerSnm.DataText = string.Empty;
                }
            }

            // 請求先＝得意先ならば、請求先名称欄をリアルで更新する（納入先の場合は除く）
            if ( this._customerInfo.CustomerCode == this._customerInfo.ClaimCode && !_customerInfo.IsReceiver )
            {
                this.uLabel_ClaimName1.Text = this.tEdit_Name.DataText;
                this.uLabel_ClaimName2.Text = this.tEdit_Name2.DataText;
                this.uLabel_ClaimSnm.Text = this.tEdit_CustomerSnm.DataText;
            }
        }

        /// <summary>
        /// 得意先コード値変更後発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_CustomerCode_ValueChanged( object sender, System.EventArgs e )
        {
            if ( ((TNedit)sender).Modified == false )
            {
                return;
            }

            // 得意先コード手動修正フラグをONにする
            this._customerCodeChangeFlg = true;
        }
        /// <summary>
        /// 得意先種別コンボエディタ（仕入先区分・業販先区分制御）変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerDivCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ChangeCustomerDiv( ref this._customerInfo );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 得意先種別変更処理
        /// </summary>
        /// <param name="customerInfo"></param>
        private void ChangeCustomerDiv( ref CustomerInfo customerInfo )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            bool divChanged = false;
            int prevCustomerDiv = 0;
            if ( customerInfo.IsReceiver ) prevCustomerDiv = 1;

            if ( prevCustomerDiv != (int)tComboEditor_CustomerDivCd.Value )
            {
                divChanged = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

            // 仕入先区分・業販先区分をセット
            SetCustomerDivCd( ref customerInfo, this.tComboEditor_CustomerDivCd );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
            // 納入先の場合は常に初期値セット
            //if ( _customerInfo.IsReceiver )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // 区分が変更されたら
            if ( divChanged )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            {
                // 担当者　←　ログイン担当者
                customerInfo.CustomerAgentCd = LoginInfoAcquisition.Employee.EmployeeCode;
                customerInfo.CustomerAgentNm = LoginInfoAcquisition.Employee.Name;
                // 管理拠点←　ログイン担当者所属拠点
                customerInfo.MngSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                customerInfo.MngSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                //// 請求拠点←　ログイン担当者所属拠点
                //_customerInfo.ClaimSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                //_customerInfo.ClaimSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                // 請求先　←　得意先情報(自身)をセット
                customerInfo.ClaimCode = customerInfo.CustomerCode;
                customerInfo.ClaimName = customerInfo.Name;
                customerInfo.ClaimName2 = customerInfo.Name2;
                customerInfo.ClaimSnm = customerInfo.CustomerSnm;

                SecInfoSet secInfoSet;
                int status = this._customerInputAcs.GetSectionFromSectionCode( out secInfoSet, customerInfo.MngSectionCode.Trim() );
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // 請求先拠点 (管理拠点同様にログイン担当所属拠点をセットする目的でコピーする)
                customerInfo.ClaimSectionCode = customerInfo.MngSectionCode;
                customerInfo.ClaimSectionName = customerInfo.MngSectionName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
                // 得意先に変更された場合
                if (customerInfo.AcceptWholeSale == 1)
                {
                    CustomerInfo customerInfoTemp;
                    this._customerInputAcs.InitialStaticMemory(0, this._customerInfo.EnterpriseCode, this._customerInfo.CustomerCode, this._loginSectionCode, out customerInfoTemp);
                    customerInfo.HonorificTitle = customerInfoTemp.HonorificTitle;
                    customerInfo.TotalDay = customerInfoTemp.TotalDay;
                    customerInfo.CollectMoneyDay = customerInfoTemp.CollectMoneyDay;
                    customerInfo.AccRecDivCd = customerInfoTemp.AccRecDivCd;
                    customerInfo.DmOutCode = customerInfoTemp.DmOutCode;
                }
                // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
            }
        }
        /// <summary>
        /// 得意先種別コンボエディタによる仕入先区分・業販先区分制御
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <param name="comboEditor"></param>
        private void SetCustomerDivCd( ref CustomerInfo customerInfo, TComboEditor comboEditor )
        {
            int code = ComboEditorItemControl.GetComboEditorValueFromText( comboEditor );
            int acceptWholeSale;

            switch ( code )
            {
                case 0:
                    // 得意先
                    acceptWholeSale = 1;
                    break;
                case 1:
                    // 納入先
                    acceptWholeSale = 2;
                    break;
                default:
                    // (想定外)
                    acceptWholeSale = 1;
                    break;
            }

            customerInfo.AcceptWholeSale = acceptWholeSale;
        }


        /// <summary>
        /// 主連絡先区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_MainContactCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.MainContactCode = ComboEditorItemControl.GetComboEditorValueFromText( this.tComboEditor_MainContactCode );
            this._customerInfo.SearchTelNo = this._customerInputAcs.CreateSearchTelNo( this._customerInfo );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        /// <summary>
        /// 請求書出力コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_BillOutputCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.BillOutputCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        /// <summary>
        /// DM発行コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_DmOutCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.DmOutCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        /// <summary>
        /// 消費税転嫁方式コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_ConsTaxLayMethod_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.ConsTaxLayMethod = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        /// <summary>
        /// 総額表示参照区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_TotalAmntDspWayRef_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.TotalAmntDspWayRef = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        /// <summary>
        /// 総額表示方法区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_TotalAmountDispWayCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.TotalAmountDispWayCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        /// <summary>
        /// 個人法人区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_CorporateDivCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CorporateDivCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        // --- DEL 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// 業種コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        //private void tComboEditor_BusinessTypeCode_SelectionChangeCommitted( object sender, EventArgs e )
        //{
        //    this._customerInfo.BusinessTypeCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

        //    // 得意先クラス→画面格納処理
        //    this.SetDisplayFormCustomerInfo( this._customerInfo );

        //    // Static情報の変更処理
        //    this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        //}
        /// <summary>
        /// 職種コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        //private void tComboEditor_JobTypeCode_SelectionChangeCommitted( object sender, EventArgs e )
        //{
        //    this._customerInfo.JobTypeCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

        //    // 得意先クラス→画面格納処理
        //    this.SetDisplayFormCustomerInfo( this._customerInfo );

        //    // Static情報の変更処理
        //    this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        //}

        /// <summary>
        /// 販売エリアコンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        //private void tComboEditor_SalesAreaCode_SelectionChangeCommitted( object sender, EventArgs e )
        //{
        //    this._customerInfo.SalesAreaCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

        //    // 得意先クラス→画面格納処理
        //    this.SetDisplayFormCustomerInfo( this._customerInfo );

        //    // Static情報の変更処理
        //    this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        //}
        // --- DEL 2010/08/10 ------------------------------------<<<<<
        /// <summary>
        /// 得意先区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerAttributeDiv_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CustomerAttributeDiv = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 相手伝票番号管理コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustSlipNoMngCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CustSlipNoMngCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
        ///// <summary>
        ///// 純正区分コンボエディタ変更確定後イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tComboEditor_PureCode_SelectionChangeCommitted( object sender, EventArgs e )
        //{
        //    this._customerInfo.PureCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

        //    // 得意先クラス→画面格納処理
        //    this.SetDisplayFormCustomerInfo( this._customerInfo );

        //    // Static情報の変更処理
        //    this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
        /// <summary>
        /// 集金月区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CollectMoneyCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CollectMoneyCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 回収条件コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CollectCond_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CollectCond = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 与信管理区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CreditMngCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CreditMngCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 入金消込区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DepoDelCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.DepoDelCode = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 売掛区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_AccRecDivCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.AccRecDivCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 単価端数処理コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesUnPrcFrcProcCd_tComboEditor_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.SalesUnPrcFrcProcCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 金額端数処理コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesMoneyFrcProcCd_tComboEditor_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.SalesMoneyFrcProcCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 消費税端数処理コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesCnsTaxFrcProcCd_TComboEditor_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.SalesCnsTaxFrcProcCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 得意先伝票番号区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerSlipNoDiv_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CustomerSlipNoDiv = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 消費税転嫁方式参照区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustCTaXLayRefCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CustCTaXLayRefCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 2009.02.20 30413 犬飼 税率設定参照時の消費税転嫁方式の設定を修正 >>>>>>START
            if (this._customerInfo.CustCTaXLayRefCd == 0)
            {
                // 税率設定参照
                this._customerInfo.ConsTaxLayMethod = this._customerInputAcs.GetConsTaxLayMethod(this._enterpriseCode, 0);
            }
            // 2009.02.20 30413 犬飼 税率設定参照時の消費税転嫁方式の設定を修正 <<<<<<END            

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// 車輌管理区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CarMngDivCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.CarMngDivCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }
        /// <summary>
        /// ＱＲコード印刷区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_QrcodePrtCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            this._customerInfo.QrcodePrtCd = ComboEditorItemControl.GetComboEditorValueFromText( (TComboEditor)sender );

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo( this._customerInfo );

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData( this, this._customerInfo );
        }

        // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
        /// <summary>
        /// 納品書出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SalesSlipPrtDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.SalesSlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        /// <summary>
        /// 受注伝票出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_AcpOdrrSlipPrtDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.AcpOdrrSlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        /// <summary>
        /// 貸出伝票出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ShipmSlipPrtDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.ShipmSlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        /// <summary>
        /// 見積伝票出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_EstimatePrtDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.EstimatePrtDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        /// <summary>
        /// UOE伝票出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_UOESlipPrtDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.UOESlipPrtDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

        // ADD 2009/04/07 ------>>>
        /// <summary>
        /// 領収書出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ReceiptOutputCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.ReceiptOutputCode = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        // ADD 2009/04/07 ------<<<

        // ADD 2009/06/03 ------>>>
        /// <summary>
        /// オンライン接続区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_OnlineKindDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.OnlineKindDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// tComboEditor_OnlineKindDiv_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_OnlineKindDiv_SelectionChanged(object sender, EventArgs e)
        {
            int onlineKindDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            if (onlineKindDiv == 0)
            {
                this.tEdit_CustomerEpCode.Clear();
                this.tEdit_CustomerSecCode.Clear();

                this.tEdit_CustomerEpCode.Enabled = false;
                this.tEdit_CustomerSecCode.Enabled = false;

                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                this.tEdit_SimplInqAcntAcntGrId.Clear();
                this.tEdit_SimplInqAcntAcntGrId.Enabled = false;
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            }
            else
            {
                this.tEdit_CustomerEpCode.Enabled = true;
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                this.tEdit_SimplInqAcntAcntGrId.Enabled = true;
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
                this.tEdit_CustomerSecCode.Enabled = true;
            }
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        // --- DEL 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// オンライン接続区分コンボエディタ値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void tComboEditor_OnlineKindDiv_ValueChanged(object sender, EventArgs e)
        //{
        //    int onlineKindDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

        //    if (onlineKindDiv == 0)
        //    {
        //        this.tEdit_CustomerEpCode.Clear();
        //        this.tEdit_CustomerSecCode.Clear();

        //        this.tEdit_CustomerEpCode.Enabled = false;
        //        this.tEdit_CustomerSecCode.Enabled = false;

        //        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
        //        this.tEdit_SimplInqAcntAcntGrId.Clear();
        //        this.tEdit_SimplInqAcntAcntGrId.Enabled = false;
        //        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
        //    }
        //    else
        //    {
        //        this.tEdit_CustomerEpCode.Enabled = true;
        //        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
        //        this.tEdit_SimplInqAcntAcntGrId.Enabled = true;
        //        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
        //        this.tEdit_CustomerSecCode.Enabled = true;
        //    }
        //}
        // --- DEL 2010/08/10 ------------------------------------<<<<<
        // ADD 2009/06/03 ------<<<
        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
        /// <summary>
        /// 合計請求書出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TotalBillOutputDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.TotalBillOutputDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        /// <summary>
        /// 明細請求書出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DetailBillOutputCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.DetailBillOutputCode = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        /// <summary>
        /// 伝票合計請求書出力区分コンボエディタ変更確定後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SlipTtlBillOutputDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this._customerInfo.SlipTtlBillOutputDiv = ComboEditorItemControl.GetComboEditorValueFromText((TComboEditor)sender);

            // 得意先クラス→画面格納処理
            this.SetDisplayFormCustomerInfo(this._customerInfo);

            // Static情報の変更処理
            this._customerInputAcs.WriteStaticMemoryData(this, this._customerInfo);
        }
        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        /// <summary>
        /// tComboEditor_CustomerAttributeDiv_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerAttributeDiv_SelectionChanged(object sender, EventArgs e)
        {
            this.comboInputFlg = false;
        }

        /// <summary>
        /// tComboEditor_CustomerAttributeDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerAttributeDiv_ValueChanged(object sender, EventArgs e)
        {
            this.comboInputFlg = true;
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<
        # endregion

        // ===================================================================================== //
        // サイズ変更後イベント
        // ===================================================================================== //
        # region SizeChanged Event Method
        /// <summary>
        /// バックグラウンドパネルサイズ変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void BackGround_Panel_SizeChanged( object sender, System.EventArgs e )
        {
            this.Container_Panel.Height = this.BackGround_Panel.Height;
        }
        # endregion

        /// <summary>
        /// ｶﾅ内容変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_Kana_ValueChanged( object sender, EventArgs e )
        {
            //if ( tComboEditor_CustomerDivCd.SelectedIndex == 0 )
            if ( !_customerInfo.IsReceiver )
            {
                // 全角から半角に変換し、入力可能文字列長でまるめる
                string kana = ToHalf( tEdit_Kana.Text );
                tEdit_Kana.Text = kana.Substring( 0, Math.Min( tEdit_Kana.ExtEdit.Column, kana.Length) );
            }
            else
            {
                // 納入先ならば入力不可制御する
                tEdit_Kana.Text = string.Empty;
            }
        }
        /// <summary>
        /// 全角→半角変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string ToHalf( string text )
        {
            return Microsoft.VisualBasic.Strings.StrConv( text, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="messageList"></param>
        /// <param name="itemList"></param>
        /// <returns></returns>
        public bool CustomerUnJustDataCheck( out ArrayList messageList, out ArrayList itemList )
        {
            messageList = new ArrayList();
            itemList = new ArrayList();

            if ( !this.uiSetControl1.CheckMatchingSet( this.tEdit_Kana ) )
            {
                messageList.Add( "得意先(ｶﾅ)" );
                itemList.Add( "Kana" );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            CustomerInfo claimInfo;
            this._customerInputAcs.GetCustomerInfoFromCustomerCode( this.tNedit_ClaimCode.GetInt(), out claimInfo );
            if ( claimInfo != null && claimInfo.ClaimCode != claimInfo.CustomerCode )
            {
                messageList.Add( "請求先コード" );
                itemList.Add( "ClaimCode" );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD

            // 親の場合のみチェック
            if ( this.tNedit_CustomerCode.GetInt() == this.tNedit_ClaimCode.GetInt() )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                if ( this.tNedit_TotalDay.GetInt() > 31 )
                {
                    messageList.Add( "締日" );
                    itemList.Add( "TotalDay" );
                }
                if ( this.tNedit_CollectMoneyDay.GetInt() > 31 )
                {
                    messageList.Add( "集金日" );
                    itemList.Add( "CollectMoneyDay" );
                }
                if ( this.tNedit_NTimeCalcStDate.GetInt() > 31 )
                {
                    messageList.Add( "次回勘定開始日" );
                    itemList.Add( "NTimeCalcStDate" );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/25 ADD
                if ( !this._customerInputAcs.ExistsSalesProcMoney( 2, this.tNedit_SalesUnPrcFrcProcCd.GetInt() ) )
                {
                    messageList.Add( "単価端数処理" );
                    itemList.Add( "SalesUnPrcFrcProcCd" );
                }
                if ( !this._customerInputAcs.ExistsSalesProcMoney( 0, this.tNedit_SalesMoneyFrcProcCd.GetInt() ) )
                {
                    messageList.Add( "金額端数処理" );
                    itemList.Add( "SalesMoneyFrcProcCd" );
                }
                if ( !this._customerInputAcs.ExistsSalesProcMoney( 1, this.tNedit_SalesCnsTaxFrcProcCd.GetInt() ) )
                {
                    messageList.Add( "消費税端数処理" );
                    itemList.Add( "SalesCnsTaxFrcProcCd" );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/25 ADD
            }
            return (messageList.Count == 0);
        }
        /// <summary>
        /// ラジオボタン制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButton_MainSendMailAddrCd0_Enter( object sender, EventArgs e )
        {
            // Enterしても即チェック値を変更せず、保持しているデータに依存させる
            if ( _customerInfo.MainSendMailAddrCd == 0 )
            {
                rButton_MainSendMailAddrCd0.Checked = true;
            }
            else
            {
                rButton_MainSendMailAddrCd1.Checked = true;
            }
        }
        /// <summary>
        /// 得意先担当フォーカス進入時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tDateEdit_CustAgentChgDate_Enter( object sender, EventArgs e )
        {
            if ( _enterYearOfCustAgentChgDate )
            {
                try
                {
                    this.SuspendLayout();

                    tDateEdit_CustAgentChgDate.Enter -= tDateEdit_CustAgentChgDate_Enter;
                    this.Focus();
                    this.tDateEdit_CustAgentChgDate.Focus();
                    tDateEdit_CustAgentChgDate.Enter += tDateEdit_CustAgentChgDate_Enter;
                }
                finally
                {
                    this.ResumeLayout();
                }
            }
        }

        private void ultraLabel43_Click(object sender, EventArgs e)
        {
            
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        #region  ガイド起動処理
        /// <summary>
        /// ガイド起動処理
        /// </summary>
        public void ExecuteGuide()
        {
            if (this.tEdit_MngSectionNm.Focused)
            {
                this.SectionNmGuide_uButton_Click(this, new EventArgs());
            }
            else if (this.tEdit_CustomerAgentNm.Focused)
            {
                this.uButton_CustomerAgentNmGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_OldCustomerAgentNm.Focused)
            {
                this.uButton_OldCustomerAgentNmGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_CustWarehouseCd.Focused)
            {
                this.uButton_CustWarehouseGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_ClaimSectionCode.Focused)
            {
                this.SectionNmGuide_uButton_Click(this, new EventArgs());
            }
            else if (this.tNedit_ClaimCode.Focused)
            {
                this.uButton_ClaimNameGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_BillCollecterNm.Focused)
            {
                this.uButton_BillCollecterNmGuide_Click(this, new EventArgs());
            }
            else if (this.tNedit_SalesUnPrcFrcProcCd.Focused)
            {
                this.ultraButton1_Click(this, new EventArgs());
            }
            else if (this.tNedit_SalesMoneyFrcProcCd.Focused)
            {
                this.ultraButton1_Click(this, new EventArgs());
            }
            else if (this.tNedit_SalesCnsTaxFrcProcCd.Focused)
            {
                this.ultraButton1_Click(this, new EventArgs());
            }
            else if (this.tEdit_PostNo.Focused)
            {
                this.uButton_AddressGuide_Click(this, new EventArgs()); 
            }
            else if (this.tEdit_Note1.Focused
               || this.tEdit_Note2.Focused
               || this.tEdit_Note3.Focused
               || this.tEdit_Note4.Focused
               || this.tEdit_Note5.Focused
               || this.tEdit_Note6.Focused
               || this.tEdit_Note7.Focused
               || this.tEdit_Note8.Focused
               || this.tEdit_Note9.Focused
               || this.tEdit_Note10.Focused)
            {
                this.uButton_Note1Guide_Click(this, new EventArgs());
            }
            else if (this.tEdit_BusinessTypeNm.Focused)
            {
                this.uButton_BusinessTypeCdGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_JobTypeName.Focused)
            {
                this.uButton_JobTypeCodeGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_SalesAreaNm.Focused)
            {
                this.uButton_SalesAreaCdGuide_Click(this, new EventArgs());
            }
        }
        #endregion

        /// <summary>
        /// 復活させた時、オンライン接続方法が「0：なし」の場合、３項目は無効
        /// </summary>
        public void OnlineKindCheck()
        {
            if (this.tComboEditor_OnlineKindDiv.Text.Equals("0:なし"))
            {
                this.tEdit_CustomerEpCode.Enabled = false;
                this.tEdit_SimplInqAcntAcntGrId.Enabled = false;
                this.tEdit_CustomerSecCode.Enabled = false;
            }
        }
        // --- ADD 2010/08/10 ------------------------------------<<<<<
        // ADD 陳健 K2014/02/06 ------------------------------------->>>>>
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }

        /// <summary>
        /// コントロールのVisableを設定する。
        /// </summary>
        private void adjustControlVisable()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this.SubInfo_UTabControl.Tabs["SubInfo8"].Visible = true;
                // DEL 梶谷貴士 2021/05/10 ------------------------------------->>>>>
                //this._opt_Maehashi = (int)Option.ON;
                // DEL 梶谷貴士 2021/05/10 -------------------------------------<<<<<
            }
            else
            {
                this.SubInfo_UTabControl.Tabs["SubInfo8"].Visible = false;
                // DEL 梶谷貴士 2021/05/10 ------------------------------------->>>>>
                //this._opt_Maehashi = (int)Option.OFF;
                // DEL 梶谷貴士 2021/05/10 -------------------------------------<<<<<
            }
            #endregion
        }
        // ADD 陳健 K2014/02/06 -------------------------------------<<<<<
        // ADD 陳健 2014/03/12 -------------------------------------------------------------->>>>>
        /// <summary>
        /// MemoRichTextのMouseのRightClickイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void memo_richTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.memo_richTextBox.Enabled == true)
            {
                // 元に戻す
                if (this.memo_richTextBox.CanUndo)
                {
                    this.toolStripMenuItem_Undo.Enabled = true;
                }
                else
                {
                    this.toolStripMenuItem_Undo.Enabled = false;
                }
                // コピーと切り取り
                if (string.IsNullOrEmpty(this.memo_richTextBox.SelectedText))
                {
                    this.toolStripMenuItem_Copy.Enabled = false;
                    this.toolStripMenuItem_Cut.Enabled = false;
                }
                else
                {
                    this.toolStripMenuItem_Copy.Enabled = true;
                    this.toolStripMenuItem_Cut.Enabled = true;
                }
                // 貼り付け
                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                {
                    this.toolStripMenuItem_Paste.Enabled = true;
                }
                else
                {
                    this.toolStripMenuItem_Paste.Enabled = false;
                }

                this.contextMenuStrip1.Show(this.memo_richTextBox, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// MouseRightClickのMenuイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // 元に戻す
            if (toolStripMenuItem_Undo.Selected)
            {
                this.memo_richTextBox.Undo();
            }
            // 切り取り
            if (toolStripMenuItem_Cut.Selected)
            {
                this.memo_richTextBox.Cut();
            }
            // コピー
            if (toolStripMenuItem_Copy.Selected)
            {
                this.memo_richTextBox.Copy();
            }
            // 貼り付け
            if (toolStripMenuItem_Paste.Selected)
            {
                this.memo_richTextBox.Paste();
            }
            // 削除
            if (toolStripMenuItem_Clear.Selected)
            {
                this.memo_richTextBox.Clear();
            }
            // すべて選択
            if (toolStripMenuItem_Select.Selected)
            {
                this.memo_richTextBox.SelectAll();
            }
        }
        // ADD 陳健 2014/03/12 --------------------------------------------------------------<<<<<
    }
}
