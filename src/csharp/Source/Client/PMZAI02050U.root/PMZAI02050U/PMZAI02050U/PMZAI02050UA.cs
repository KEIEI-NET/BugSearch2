//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫看板印刷
// プログラム概要   : 在庫看板印刷UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/12/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応13102
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫看板印刷UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫看板印刷UIフォームクラス</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>Update Note: 2009/04/13 30452 上野 俊治</br>
    /// <br>            ・障害対応13102</br>
    /// <br></br>
    /// </remarks>
    public partial class PMZAI02050UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMZAI02050UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // ガイドアクセスクラス初期化
            this._employeeAcs = new EmployeeAcs();
            this._userGuideAcs = new UserGuideAcs();

            // 抽出条件クラス
            this._stockSignOrderCndtn = new StockSignOrderCndtn();
        }
        #endregion

        #region ■ private定数
        #region Interface関連
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMZAI02050UA";
        // プログラムID
        private const string ct_PGID = "PMZAI02050U";
        //// 帳票名称
        private string _printName = "在庫看板印刷";
        // 帳票キー	
        private string _printKey = "6851b06d-20e0-4679-911b-5a19f3e6ebd1";
        #endregion
        #endregion

        #region ■ private変数

        #region Interface関連
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 DEL
        //private bool _canPdf = true;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
        private bool _canPdf = false;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ
	    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 DEL
        //private bool _visibledPdfButton = true;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
        private bool _visibledPdfButton = false;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 従業員マスタアクセスクラス
        EmployeeAcs _employeeAcs;
        // ユーザマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;

        // メーカーガイド
        private MakerAcs _makerAcs;
        // 倉庫ガイド用
        WarehouseAcs _wareHouseAcs;

        // 在庫看板印刷 抽出条件データクラス
        private StockSignOrderCndtn _stockSignOrderCndtn;

        // 企業コード
        private string _enterpriseCode = "";

        #endregion

        #region ■ IPrintConditionInpType メンバ
        #region イベント
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Publicプロパティ
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

        #region ◆ Public Method
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

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            switch ((int)this.tComboEditor_LabelType.SelectedItem.DataValue)
            {
                //商品別、得意先別、担当者別
                case (int)StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine:
                    {
                        printInfo.PrintPaperSetCd = 0;
                        break;
                    }
                case (int)StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine:
                    {
                        printInfo.PrintPaperSetCd = 1;
                        break;
                    }
                case (int)StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine:
                    {
                        printInfo.PrintPaperSetCd = 2;
                        break;
                    }
                //BLコード別
                case (int)StockSignOrderCndtn.LabelTypeState.Laser_FourByEleven:
                    {
                        printInfo.PrintPaperSetCd = 3;
                        break;
                    }
            }
            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._stockSignOrderCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
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
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
            return;
        }
        #endregion

        #endregion
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◆ Public Property

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

        #endregion ◆ Public Property


        #region ◆ Public Method

        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState == CheckState.Checked)
            {
                // 全社が選択された場合
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();

                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }

            }
            // 拠点選択を解除した時
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
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
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // 選択リスト初期化
            this._selectedSectionList.Clear();

            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, wk);
            }
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
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypeSelectedSection メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

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

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ privateメソッド
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化を行う</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ガイドボタン設定
                this.SetIconImage(this.uButton_GoodsMakerCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GoodsMakerCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_WarehouseCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_WarehouseCodeEdGuid, Size16_Index.STAR1);

                // 倉庫
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                // メーカー
                this.tNedit_GoodsMakerCd_St.SetInt(0);
                this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                // 棚番
                this.tEdit_WarehouseShelfNo_St.DataText = string.Empty;
                this.tEdit_WarehouseShelfNo_Ed.DataText = string.Empty;
                // 品番
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;

                // 印刷順
                this.tComboEditor_PrintOrder.Value = 0;

                // 印刷タイプ
                this.tComboEditor_PrintType.Value = 0;
                // ラベルタイプ
                this.tComboEditor_LabelType.Value = 0;
                // 印刷開始行
                this.tComboEditor_StartRow.ResetItems();
                this.SetPrintStartRow();
                this.tComboEditor_StartRow.SelectedIndex = 0;
                
                // 初期フォーカス設定
                this.tEdit_WarehouseCode_St.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";

            // 倉庫
            if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("倉庫コード{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // メーカー
            else if ((this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("メーカーコード{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 棚番
            if ((this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("棚番{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseShelfNo_St;
                status = false;
            }
            // 品番
            if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            

            return status;
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 全拠点チェック
                bool allSections = false;

                foreach (object obj in _selectedSectionList.Values)
                {
                    if (obj is string)
                    {
                        if ((obj as string) == "0")
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if (allSections)
                {
                    _selectedSectionList.Clear();
                }

                // 拠点オプション
                this._stockSignOrderCndtn.IsOptSection = this._isOptSection;
                // 拠点コード
                this._stockSignOrderCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 企業コード
                this._stockSignOrderCndtn.EnterpriseCode = this._enterpriseCode;

                this._stockSignOrderCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText; // 倉庫コード(開始)
                this._stockSignOrderCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText; // 倉庫コード(終了)
                this._stockSignOrderCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt(); // 商品メーカーコード(開始)
                this._stockSignOrderCndtn.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt(); // 商品メーカーコード(終了)
                this._stockSignOrderCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText; // 倉庫棚番(開始)
                this._stockSignOrderCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText; // 倉庫棚番(終了)
                this._stockSignOrderCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.DataText; // 商品番号(開始)
                this._stockSignOrderCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.DataText; // 商品番号(終了)
                this._stockSignOrderCndtn.PrintOrder 
                    = (StockSignOrderCndtn.PrintOrderState)this.tComboEditor_PrintOrder.SelectedItem.DataValue; // 印刷順
                this._stockSignOrderCndtn.PrintType 
                    = (StockSignOrderCndtn.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue; // 印刷タイプ
                this._stockSignOrderCndtn.LabelType 
                    = (StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue; // ラベルタイプ
                this._stockSignOrderCndtn.PrintStartRow 
                    = (StockSignOrderCndtn.PrintStartRowState)this.tComboEditor_StartRow.SelectedItem.DataValue; // 印刷開始行
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 印刷開始行設定
        /// </summary>
        private void SetPrintStartRow()
        {
            Infragistics.Win.ValueListItem listItem;

            if ((StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue 
                == StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine
                || (StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue 
                == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine)
            {
                // ドット
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "２行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "３行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "４行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "５行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 5;
                listItem.DataValue = 5;
                listItem.DisplayText = "６行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 6;
                listItem.DataValue = 6;
                listItem.DisplayText = "７行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 7;
                listItem.DataValue = 7;
                listItem.DisplayText = "８行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 8;
                listItem.DataValue = 8;
                listItem.DisplayText = "９行目";
                this.tComboEditor_StartRow.Items.Add(listItem);
            }
            else if ((StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue 
                == StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine)
            {
                // 3×9 レーザー
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "１行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "２行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "３行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "４行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "５行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 5;
                listItem.DataValue = 5;
                listItem.DisplayText = "６行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 6;
                listItem.DataValue = 6;
                listItem.DisplayText = "７行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 7;
                listItem.DataValue = 7;
                listItem.DisplayText = "８行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 8;
                listItem.DataValue = 8;
                listItem.DisplayText = "９行目";
                this.tComboEditor_StartRow.Items.Add(listItem);
            }
            else
            {
                // 4×11 レーザー
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "１行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "２行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "３行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "４行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "５行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 5;
                listItem.DataValue = 5;
                listItem.DisplayText = "６行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 6;
                listItem.DataValue = 6;
                listItem.DisplayText = "７行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 7;
                listItem.DataValue = 7;
                listItem.DisplayText = "８行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 8;
                listItem.DataValue = 8;
                listItem.DisplayText = "９行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 9;
                listItem.DataValue = 9;
                listItem.DisplayText = "１０行目";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 10;
                listItem.DataValue = 10;
                listItem.DisplayText = "１１行目";
                this.tComboEditor_StartRow.Items.Add(listItem);
            }

        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
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

        #region ■ コントロールイベント
        /// <summary>
        /// PMZAI02050UA_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02050UA_Load(object sender, EventArgs e)
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

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// tComboEditor_LabelType_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ラベルタイプの変更時、印刷開始行の設定を変更する。</br>
        /// <br>Programmer	: 30452 上野 俊治</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private void tComboEditor_LabelType_ValueChanged(object sender, EventArgs e)
        {
            // 選択中の値を保持
            object tmpObj;

            if (this.tComboEditor_StartRow.SelectedItem != null)
            {
                tmpObj = this.tComboEditor_StartRow.SelectedItem.DataValue;
            }
            else
            {
                tmpObj = 0;
            }

            this.tComboEditor_StartRow.ResetItems();

            this.SetPrintStartRow();

            this.tComboEditor_StartRow.Value = tmpObj;

            if (this.tComboEditor_StartRow.SelectedItem == null)
            {
                this.tComboEditor_StartRow.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 倉庫ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCodeStGuid_Click(object sender, EventArgs e)
        {
            if (this._wareHouseAcs == null)
            {
                this._wareHouseAcs = new WarehouseAcs();
            }

            Warehouse warehouse;
            int status = this._wareHouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdStGuid_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_WarehouseShelfNo_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // タブ、Enterキーでのガイド遷移不可
            if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                if (e.NextCtrl == uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_St;
                }
                else if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }
                else if (e.NextCtrl == this.uButton_GoodsMakerCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                if (e.NextCtrl == this.uButton_GoodsMakerCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                }
                else if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                }
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
            {
                if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
            }
        }

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

    }
}