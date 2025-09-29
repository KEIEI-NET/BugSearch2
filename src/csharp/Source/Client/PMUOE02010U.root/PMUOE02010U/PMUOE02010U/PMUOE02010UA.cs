using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 回線エラーリスト UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 回線エラーリスト UIフォームクラス</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/04</br>
    /// <br></br>
    /// </remarks>
	public partial class PMUOE02010UA : Form,
                                        IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                        IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{

        #region ■定数、変数、構造体
        // 定数
        private const string CLASS_ID = "PMUOE02010UA";     // クラスID
        private const string PG_ID = "PMUOE02010U";         // プログラムID

        // 変数
        private string _enterpriseCode = "";                        // 企業コード
        private List<OrderSndRcvJnl> _circuitErrorList = null;      // 回線エラーリスト　※送受信ジャーナル(発注)と同じレイアウト

        // IPrintConditionInpTypeインターフェイス用変数
        private bool _canExtract = false;                   // 抽出ボタン   状態取得プロパティ
        private bool _canPdf = true;                        // PDF出力ボタン状態取得プロパティ
        private bool _canPrint = true;                      // 印刷ボタン   状態取得プロパティ
        private bool _visibledExtractButton = false;        // 抽出ボタン   表示有無プロパティ
        private bool _visibledPdfButton = true;             // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPrintButton = true;           // 印刷ボタン   表示有無プロパティ

        // IPrintConditionInpTypePdfCareerインターフェイス用変数
        private string _printName = "";                     // 帳票名称
        private string _printKey = "";                      // 帳票キー	
        #endregion

        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="circuitErrorList">回線エラーリスト　送受信ジャーナル(発注)と同レイアウト</param>
        /// <remarks>
        /// <br>Note       : クラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/04</br>
        /// <br></br>
        /// </remarks>
        public PMUOE02010UA(List<OrderSndRcvJnl> circuitErrorList)
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 回線エラーリスト取得
            this._circuitErrorList = circuitErrorList;
        }
        #endregion ■Constructor - end

        #region ■Public
        #region ▼IPrintConditionInpTypeインターフェイス用プロパティ
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
        #endregion

        #region ▼IPrintConditionInpTypePdfCareerインターフェイス用プロパティ
        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }
        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return this._printName; }
        }
        #endregion

        #region ▼Print(印刷開始)
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = PG_ID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            printInfo.PrintPaperSetCd = 0;

            // 印刷対象データの設定
            printInfo.rdData = this._circuitErrorList;

            // 帳票選択ガイド呼び出し
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                // 該当データなし
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "該当するデータがありません", 0, MessageBoxButtons.OK);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ▼PrintBeforeCheck(印刷前チェック処理　未使用)
        /// <summary>
        /// 印刷前チェック処理
        /// </summary>
        /// <returns>True固定</returns>
        /// <remarks>
        /// <br>Note		: 印刷前チェック処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            // チェックは無いので処理終了
            return true;
        }
        #endregion

        #region ▼Extract(抽出処理　未使用)
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0固定</returns>
        /// <remarks>
        /// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion

        #region ▼Show(画面表示処理　未使用)
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/04</br>
        /// </remarks>
        public void Show(object parameter)
        {
        }
        #endregion

        #region ▼ParentToolbarSettingEvent(親ツールバー設定イベント　未使用)
        /// <summary> 親ツールバー設定イベント</summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion
        #endregion ■Public - end
    }
}