//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリストUIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/07/22  修正内容 : 削除処理後のウィンドウの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/07/22  修正内容 : ＰＤＦ表示処理の変更
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売価原価アンマッチリストUIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価原価アンマッチリストUIフォームクラス</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public partial class PMHNB02200UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypeUpdate,
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 売価原価アンマッチリストUIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売価原価アンマッチリストUIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        public PMHNB02200UA()
        {
            InitializeComponent();

            _updateBtnClicked = false;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionHashtable = new Hashtable();

            // 売価原価アンマッチリストアクセス
            this._rateUnMatchAcs = new RateUnMatchAcs();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member

        // 実行ボタンをクリックするかどうか
        private bool _updateBtnClicked;

        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 実行ボタン状態取得プロパティ
        private bool _canUpdate = true;
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = false;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = false;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点ハッシュテーブル
        private Hashtable _selectedSectionHashtable = new Hashtable();
        // 売価原価アンマッチリストアクセスクラス
        private RateUnMatchAcs _rateUnMatchAcs;
        // キャンセルかどうか
        private bool _isCancel = false;
        // 削除用の全てデータリスト
        private ArrayList _delList;
        // 削除検索用のコントロール
        private BackgroundWorker bw;
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        #endregion ■ Private Member

        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 実行ボタン状態取得プロパティ </summary>
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }

        /// <summary> 抽出ボタン状態取得プロパティ </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態取得プロパティ </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態取得プロパティ </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無プロパティ </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示プロパティ </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        /// <summary> 本社機能プロパティ </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> 拠点オプションプロパティ </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> 計上拠点選択表示取得プロパティ </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return _printName; }
        }
        #endregion ◆ Public Property

        #region ■ Private Const
        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMHNB02200UA";
        // プログラムID
        private const string ct_PGID = "PMHNB02200U";
        // 帳票名称
        private string _printName = "売価原価アンマッチリスト";
        // 帳票キー	
        private string _printKey = "461a402f-20c6-4b5e-817f-790237550131";
        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ProcessConditionGroup = "ProcessConditionGroup";	// 処理条件
        private const string ct_ExBarGroupNm_ProcessResultGroup = "ProcessResultGroup";		    // 処理結果
        #endregion ◆ Interface member

        #region 処理区分のデータとタイトル
        const string ct_ProcessKbn_Print = "印刷のみ";
        const string ct_ProcessKbn_PrintDelete = "印刷＆削除";
        const string ct_ProcessKbn_Delete = "削除のみ";
        #endregion
        const string ct_ErrorMsg = "選択出来ない区分です。";
        #endregion ■ Private Const

        #region ◎ PMHNB02200UA_Load Event
        /// <summary>
        /// PMHNB02200UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void PMHNB02200UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動  
        }
        #endregion

        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
                // 印刷のみ
                listItem0.DataValue = 0;
                listItem0.DisplayText = ct_ProcessKbn_Print;

                // 印刷＆削除
                Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
                listItem1.DataValue = 1;
                listItem1.DisplayText = ct_ProcessKbn_PrintDelete;

                // 削除のみ
                Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
                listItem2.DataValue = 2;
                listItem2.DisplayText = ct_ProcessKbn_Delete;

                this.tComboEditor_ProcessKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });

                // 「印刷のみ」を選択されています
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();

            return;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            // 未実装
            return true;
        }

        #region ◎ メニューボタンチェック処理
        /// <summary>
        /// メニューボタンチェック処理
        /// </summary>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面のメニューボタンチェックを行う。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private bool MenuButtonCheck()
        {
            bool status = true;
            // PDF表示ボタンをクリックする場合、処理区分をチェックする
            if (_updateBtnClicked == false)
            {
                // 「印刷＆削除」と「削除のみ」を選択する場合
                // upd by liuxz on 2009/07/22 start
                // if ((int)this.tComboEditor_ProcessKbn.Value == 2)
                if ((int)this.tComboEditor_ProcessKbn.Value == 1 || (int)this.tComboEditor_ProcessKbn.Value == 2)
                // upd by liuxz on 2009/07/22 end
                {
                    status = false;
                    // メッセージを表示
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_ErrorMsg, 0);
                    this.tComboEditor_ProcessKbn.Focus();
                }
            }
            return status;
        }
        #endregion ◎ 入力チェック処理
        #endregion ◎ 印刷前確認処理

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // 売価設定削除件数
            this.uLabel_DelUnitPriceKind1Cnt.Text = "0件";
            // 原価設定削除件数
            this.uLabel_DelUnitPriceKind2Cnt.Text = "0件";
            // 定価設定削除件数
            this.uLabel_DelUnitPriceKind3Cnt.Text = "0件";

            // 処理区分が「削除のみ」の場合、PDFボタンをクリックするチェック
            if (MenuButtonCheck() == false)
            {
                _updateBtnClicked = false;
                return -1;
            }
            _updateBtnClicked = false;

            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = _printKey;
            printInfo.prpnm = _printName;
            printInfo.PrintPaperSetCd = 0;
            // 抽出条件クラス
            RateUnMatchCndtn extrInfo = new RateUnMatchCndtn();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            // 抽出条件の設定
            printInfo.jyoken = extrInfo;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                // プレビューの場合
                if (printDialog.EnablePreview == 1)
                {
                    // プレビュー画面を閉じる場合
                    if (printInfo.status == -1)
                    {
                        printInfo.status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                switch (printInfo.status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
                        break;
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        break;
                }

                parameter = printInfo;
                this._isCancel = false;
            }
            else
            {
                // キャンセル
                this._isCancel = true;
            }

            return printInfo.status;
        }

        #region ◎ 数字のフォーマット
        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }

            return ret;
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(RateUnMatchCndtn rateUnMatchCndtn)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 拠点オプション
                rateUnMatchCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                rateUnMatchCndtn.EnterpriseCode = this._enterpriseCode;
                // 選択拠点
                // 全社選択かどうか
                if ((this._selectedSectionHashtable.Count == 1) && this._selectedSectionHashtable.ContainsKey("0"))
                {
                    rateUnMatchCndtn.SectionCodes = null;
                }
                else
                {
                    rateUnMatchCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionHashtable.Values).ToArray(typeof(string));
                }
                // 処理区分
                rateUnMatchCndtn.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion

        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion

        #region ◎ 初期拠点選択表示チェック処理
        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 選択ハッシュテーブル初期化
            this._selectedSectionHashtable.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionHashtable.Add(wk, wk);
            }
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState == CheckState.Checked)
            {
                // 全社が選択された場合
                if (sectionCode == "0")
                {
                    this._selectedSectionHashtable.Clear();

                }

                if (!this._selectedSectionHashtable.ContainsKey(sectionCode))
                {
                    this._selectedSectionHashtable.Add(sectionCode, sectionCode);
                }
            }
            // 拠点選択を解除した時
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionHashtable.ContainsKey(sectionCode))
                {
                    this._selectedSectionHashtable.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region ◎ 実行処理
        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 更新＋印刷処理を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            string errMsg = string.Empty;

            // 売価設定削除件数
            this.uLabel_DelUnitPriceKind1Cnt.Text = "0件";
            // 原価設定削除件数
            this.uLabel_DelUnitPriceKind2Cnt.Text = "0件";
            // 定価設定削除件数
            this.uLabel_DelUnitPriceKind3Cnt.Text = "0件";

            // 処理区分が「削除のみ」の場合
            if ((int)this.tComboEditor_ProcessKbn.Value == 2)
            {
                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                             ct_ClassID,
                             "対象データの削除を実行しますか？",
                             0,
                             MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                // 抽出中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "抽出中";
                form.Message = "現在、データを抽出中です。";

                this._rateUnMatchAcs = new RateUnMatchAcs();
                try
                {
                    // ダイアログ表示
                    form.Show();

                    // 抽出条件クラス
                    RateUnMatchCndtn extrInfo = new RateUnMatchCndtn();

                    // 画面→抽出条件クラス
                    status = this.SetExtraInfoFromScreen(extrInfo);
                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return -1;
                    }

                    // 検索処理
                    status = this._rateUnMatchAcs.SearchAllForDelete(extrInfo, out this._delList, out errMsg);

                    // ダイアログを閉じる
                    form.Close();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
                    }
                    else if (status != (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                    {
                         // 表示文字を設定
                        form.Title = "削除中";
                        form.Message = "現在、データを削除中です。";
                        // ダイアログ表示
                        form.Show();
                        // 削除処理
                        status = this._rateUnMatchAcs.Delete(this._delList, out errMsg);
                        // ダイアログを閉じる
                        form.Close();
                        switch (status)
                        {
                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                // 売価設定削除件数
                                this.uLabel_DelUnitPriceKind1Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind1Cnt) + "件";
                                // 原価設定削除件数
                                this.uLabel_DelUnitPriceKind2Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind2Cnt) + "件";
                                // 定価設定削除件数
                                this.uLabel_DelUnitPriceKind3Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind3Cnt) + "件";

                                // upd by liuxz on 2009/07/22 start
                                //// 登録完了
                                //SaveCompletionDialog dialog = new SaveCompletionDialog();
                                //dialog.ShowDialog(2);
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "削除しました。", 0);
                                // upd by liuxz on 2009/07/22 end
                                break;
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "更新処理で排他エラーとなりました。他の掛率マスタ関連ＰＧを終了させ、再度処理を実行して下さい。", status);
                                break;
                            default:
                                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ダイアログを閉じる
                    form.Close();
                    errMsg = ex.Message;
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                this._updateBtnClicked = true;
                bw = new BackgroundWorker();
                bw.DoWork += bw_DoWork;
                bw.RunWorkerAsync();

                // 印刷処理
                status = Print(ref parameter);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && this._isCancel == false)
                {
                    // 「印刷のみ」以外の場合
                    if ((int)this.tComboEditor_ProcessKbn.Value != 0)
                    {
                        // 警告メッセージ
                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                    ct_ClassID,
                                                    "対象データの削除を実行しますか？",
                                                    0,
                                                    MessageBoxButtons.YesNo);
                        if (dr != DialogResult.No)
                        {
                            // 抽出中画面部品のインスタンスを作成
                            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                            // 表示文字を設定
                            form.Title = "削除中";
                            form.Message = "現在、データを削除中です。";
                            // ダイアログ表示
                            form.Show();

                            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ
                            status = this._rateUnMatchAcs.Delete(this._delList, out errMsg);
                            // ダイアログを閉じる
                            form.Close();
                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    // 売価設定削除件数
                                    this.uLabel_DelUnitPriceKind1Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind1Cnt) + "件";
                                    // 原価設定削除件数
                                    this.uLabel_DelUnitPriceKind2Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind2Cnt) + "件";
                                    // 定価設定削除件数
                                    this.uLabel_DelUnitPriceKind3Cnt.Text = NumberFormat(this._rateUnMatchAcs.DelUnitPriceKind3Cnt) + "件";

                                    // upd by liuxz on 2009/07/22 start
                                    //// 登録完了
                                    //SaveCompletionDialog dialog = new SaveCompletionDialog();
                                    //dialog.ShowDialog(2);
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "削除しました。", 0);
                                    // upd by liuxz on 2009/07/22 end
                                    break;
                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "更新処理で排他エラーとなりました。他の掛率マスタ関連ＰＧを終了させ、再度処理を実行して下さい。", status);
                                    break;
                                default:
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                                    break;
                            }
                        }
                    }
                }
            }

            return status;
        }
        #endregion

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ProcessConditionGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_ProcessResultGroup))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }
        #endregion

        #region ◎ GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ProcessConditionGroup) ||
               (e.Group.Key == ct_ExBarGroupNm_ProcessResultGroup))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }
        #endregion
        #endregion ◆ ueb_MainExplorerBar

        #region ◆ BackgroundWorker Event
        /// <summary>
        /// 削除検索用のイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 削除検索用のイベント処理。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void bw_DoWork(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 抽出条件クラス
            RateUnMatchCndtn extrInfo = new RateUnMatchCndtn();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return;
            }

            // 検索処理
            status = this._rateUnMatchAcs.SearchAllForDelete(extrInfo, out this._delList, out errMsg);
        }
        #endregion

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion
        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

    }
}