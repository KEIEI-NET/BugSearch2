//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷対応表
// プログラム概要   : 型式別出荷対応表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhshh
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 型式別出荷対応表UIクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式別出荷対応表UIで、抽出条件を入力します。</br>       
    /// <br>Programmer : zhshh</br>                                   
    /// <br>Date       : 2010.04.21</br>                                   
    /// </remarks>
    public partial class PMSYA02200UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {
        #region ■ Constructor
        /// <summary>
        /// 型式別出荷対応表UIクラスコンストラクタ　　　　　　　　　　　　　　　　　　 　
        /// </summary>
        /// <remarks>
        /// <br>Note       : 型式別出荷対応表UI初期化およびインスタンスの生成を行う</br>                 
        /// <br>Programmer : zhshh</br>                                  
        /// <br>Date       : 2010.04.21</br>                                     
        /// </remarks>
        public PMSYA02200UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseAcs = new WarehouseAcs();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            this._carMngInputAcs = CarMngInputAcs.GetInstance();
        }

        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member

        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;
        // 設定ボタン表示有無プロパティ
        private bool _visibledSetButton = true;
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        // 企業コード
        private string _enterpriseCode = "";
        // ログイン情報
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private ModelShipRsltListCndtn _modelShipRsltListCndtn;

        //日付取得部品
        private DateGetAcs _dateGet;

        private CarMngInputAcs _carMngInputAcs;

        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;

        ///メーカーマスタアクセスクラス
        private MakerAcs _makerAcs = null;

        /// <summary>MAKHN09332A)倉庫</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>SFKTN09002A)拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMSYA02200UA";
        // プログラムID
        private const string ct_PGID = "PMSYA02200U";
        // 帳票名称
        private const string PDF_PRINT_NAME = "型式別出荷対応表";
        private string _printName = PDF_PRINT_NAME;
        // 帳票キー	
        private const string PDF_PRINT_KEY = "156cc2cb-3afc-45bc-ac54-5017c884fa2f";
        private string _printKey = PDF_PRINT_KEY;
        #endregion ◆ Interface member

        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です。";
        const string ct_RangeError = "の範囲指定に誤りがあります。";

        #endregion

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
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

        /// <summary> 設定ボタン表示プロパティ </summary>
        public bool VisibledSetButton
        {
            get { return this._visibledSetButton; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        /// <remarks>
        /// <br>Note		: 抽出処理を行う。</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._modelShipRsltListCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }
        #endregion

        #endregion ◆ Public Method
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <param name="addUpCd">計上拠点</param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
            get { return _printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期値セット・区分
                this.uos_GroupBySectionDiv.Value = 1;   // 拠点毎
                this.uos_RsltTtlDiv.Value = 0;          //在庫取寄指定
                this.uos_NewPageDiv.Value = 1;          //改頁

                // 初期値セット・文字列
                //車種
                this.tNedit_St_MakerCode.DataText = string.Empty; 
                this.tNedit_St_ModelCode.DataText = string.Empty;
                this.tNedit_St_ModelSubCode.DataText = string.Empty;
                this.tNedit_Ed_MakerCode.DataText = string.Empty;
                this.tNedit_Ed_ModelCode.DataText = string.Empty;
                this.tNedit_Ed_ModelSubCode.DataText = string.Empty;

                //代表型式
                this.tEdit_FullModel.DataText = string.Empty;

                //メーカー
                this.tNedit_St_GoodsMakerCd.DataText = string.Empty;
                this.tNedit_Ed_GoodsMakerCd.DataText = string.Empty;

                //ＢＬコード
                this.tNedit_St_BLGoodsCode.DataText = string.Empty;
                this.tNedit_Ed_BLGoodsCode.DataText = string.Empty;

                //倉庫
                this.tEdit_WarehouseCode.Text = string.Empty;
                this.uLabel_WarehouseName.Text = string.Empty;
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this._ownSectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!String.IsNullOrEmpty(sectionInfo.SectWarehouseCd1))
                    {
                        this.tEdit_WarehouseCode.Text = sectionInfo.SectWarehouseCd1.Trim().PadLeft(4,'0');
                        // コードから名称へ変換
                        Warehouse warehouseInfo;
                        int statusWarehouse = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, sectionInfo.SectWarehouseCd1);
                        if (statusWarehouse == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.uLabel_WarehouseName.Text = warehouseInfo.WarehouseName;
                        }
                    }
                }

                // 売上日
                this.tde_St_SalesDay.SetDateTime(DateTime.Now);
                this.tde_Ed_SalesDay.SetDateTime(DateTime.Now);

                // ボタン設定
                this.SetIconImage(this.ub_St_ModelFullGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_ModelFullGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_MakerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MakerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_WarehouseGuide, Size16_Index.STAR1);


                // 初期フォーカスセット
                this.uos_GroupBySectionDiv.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        /// <remarks>
        /// <br>Note		: ボタンアイコンの設定を行う</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理

        /// <summary>
        /// 日付範囲チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="tde_St_OrderDataCreateDate">開始日付</param>
        /// <param name="tde_Ed_OrderDataCreateDate">終了日付</param>
        /// <returns>日付範囲チェック結果</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;

            // 売上日（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref tde_St_SalesDay, ref tde_Ed_SalesDay) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始日{0}", ct_InputError);
                            errComponent = this.tde_St_SalesDay;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_SalesDay;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("売上日{0}", ct_RangeError);
                            errComponent = this.tde_Ed_SalesDay;
                            status = false;
                        }
                        break;
                }
            }
            if(status == false)
            {
                return status;
            }
            // 入力日（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref tde_St_InputDay, ref tde_Ed_InputDay) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始日{0}", ct_InputError);
                            errComponent = this.tde_St_InputDay;
                        }
                        status = false;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了日{0}", ct_InputError);
                            errComponent = this.tde_Ed_InputDay;
                        }
                        status = false;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.tde_Ed_InputDay;
                        }
                        status = false;
                        break;
                }
            }
            if (status == false)
            {
                return status;
            }

            //車種
            if ((this.tNedit_St_MakerCode.GetInt() != 0 || this.tNedit_St_ModelCode.GetInt() != 0 || this.tNedit_St_ModelSubCode.GetInt() != 0)
                && (this.tNedit_Ed_MakerCode.GetInt() != 0 || this.tNedit_Ed_ModelCode.GetInt() != 0 || this.tNedit_Ed_ModelSubCode.GetInt() != 0))
            { 
                if (this.tNedit_St_MakerCode.GetInt() > GetEndCode(this.tNedit_Ed_MakerCode))
                {
                    errMessage = string.Format("車種{0}", ct_RangeError);
                    errComponent = this.tNedit_Ed_MakerCode;
                    status = false;
                }
                else if (this.tNedit_St_MakerCode.GetInt() == GetEndCode(this.tNedit_Ed_MakerCode) 
                    && this.tNedit_St_ModelCode.GetInt() > GetEndCode(this.tNedit_Ed_ModelCode))
                {
                    errMessage = string.Format("車種{0}", ct_RangeError);
                    errComponent = this.tNedit_Ed_ModelCode;
                    status = false;
                }
                else if (this.tNedit_St_MakerCode.GetInt() == GetEndCode(this.tNedit_Ed_MakerCode) 
                    && this.tNedit_St_ModelCode.GetInt() == GetEndCode(this.tNedit_Ed_ModelCode)
                    && this.tNedit_St_ModelSubCode.GetInt() > GetEndCode(this.tNedit_Ed_ModelSubCode))
                {
                    errMessage = string.Format("車種{0}", ct_RangeError);
                    errComponent = this.tNedit_Ed_ModelSubCode;
                    status = false;
                }
            }
            // メーカーｺｰﾄﾞ
            else if (this.tNedit_St_GoodsMakerCd.GetInt() > GetEndCode(this.tNedit_Ed_GoodsMakerCd))
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_Ed_GoodsMakerCd;
                status = false;
            }
            // ＢＬｺｰﾄﾞ
            else if (this.tNedit_St_BLGoodsCode.GetInt() > GetEndCode(this.tNedit_Ed_BLGoodsCode))
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_Ed_BLGoodsCode;
                status = false;
            }
            return status;
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit">数値項目</param>
        /// <returns>コード値</returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit">数値項目</param>
        /// <param name="endCodeOnDB">画面上コンポーネントのColumn</param>
        /// <returns>コード値</returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._modelShipRsltListCndtn = new ModelShipRsltListCndtn();
            try
            {
                // 企業コード
                this._modelShipRsltListCndtn.EnterpriseCode = this._enterpriseCode;
                // 「全拠点」が選択されている場合はリストをクリア
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
                this._modelShipRsltListCndtn.IsOptSection = this._isOptSection;
                // 計上拠点コード（複数指定）
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._modelShipRsltListCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // 集計方法
                this._modelShipRsltListCndtn.GroupBySectionDiv = (ModelShipRsltListCndtn.GroupBySectionDivState)this.uos_GroupBySectionDiv.Value;
                // 売上日
                this._modelShipRsltListCndtn.SalesDateSt = this.tde_St_SalesDay.GetDateTime();
                this._modelShipRsltListCndtn.SalesDateEd = this.tde_Ed_SalesDay.GetDateTime();
                // 入力日
                this._modelShipRsltListCndtn.InputDateSt = this.tde_St_InputDay.GetDateTime();
                this._modelShipRsltListCndtn.InputDateEd = this.tde_Ed_InputDay.GetDateTime();
                // 在庫取寄指定
                this._modelShipRsltListCndtn.RsltTtlDiv = (ModelShipRsltListCndtn.RsltTtlDivState)this.uos_RsltTtlDiv.Value;
                // 改頁
                this._modelShipRsltListCndtn.NewPageDiv = (ModelShipRsltListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;
                //車種（開始）
                this._modelShipRsltListCndtn.CarMakerCodeSt = this.tNedit_St_MakerCode.GetInt();
                this._modelShipRsltListCndtn.CarModelCodeSt = this.tNedit_St_ModelCode.GetInt();
                this._modelShipRsltListCndtn.CarModelSubCodeSt = this.tNedit_St_ModelSubCode.GetInt();

                //車種（終了）
                this._modelShipRsltListCndtn.CarMakerCodeEd = this.tNedit_Ed_MakerCode.GetInt();
                this._modelShipRsltListCndtn.CarModelCodeEd = this.tNedit_Ed_ModelCode.GetInt();
                this._modelShipRsltListCndtn.CarModelSubCodeEd = this.tNedit_Ed_ModelSubCode.GetInt();
                //代表型式
                this._modelShipRsltListCndtn.ModelName = this.tEdit_FullModel.Text;
                // 代表型式抽出区分
                this._modelShipRsltListCndtn.ModelOutDiv = (ModelShipRsltListCndtn.ModelOutDivState)this.tComboEditor_FullModelFuzzy.Value;
                //メーカー
                this._modelShipRsltListCndtn.MakerCodeSt = this.tNedit_St_GoodsMakerCd.GetInt();
                this._modelShipRsltListCndtn.MakerCodeEd = this.tNedit_Ed_GoodsMakerCd.GetInt();
                // ＢＬコード
                this._modelShipRsltListCndtn.BLGoodsCodeSt = this.tNedit_St_BLGoodsCode.GetInt();
                this._modelShipRsltListCndtn.BLGoodsCodeEd = this.tNedit_Ed_BLGoodsCode.GetInt();
                //倉庫
                this._modelShipRsltListCndtn.WarehouseCode = this.tEdit_WarehouseCode.Text;
                this._modelShipRsltListCndtn.WarehouseName = this.uLabel_WarehouseName.Text;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion ◆ 印刷前処理

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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

        #endregion ■ Private Method

        # region Control Events

        /// <summary>
        /// PMSYA02200UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void PMSYA02200UA_Load(object sender, EventArgs e)
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
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバー設定イベント
            ParentToolbarSettingEvent(this);
        }
        # endregion

        # region ガイド イベント
        /// <summary>
        /// エクスプローラーバー グループ縮小 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが縮小される前に発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPublishGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// エクスプローラーバー グループ展開 イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : グループが展開される前に発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPublishGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ＢＬコードガイドボタンがクリック時に発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_St_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_Ed_BLGoodsCode.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_Ed_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_WarehouseCode.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 車種ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 車種ガイドボタンがクリック時に発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode;
            int modelCode;
            int modelSubCode;
            if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
            {
                makerCode = this.tNedit_St_MakerCode.GetInt();
                modelCode = this.tNedit_St_ModelCode.GetInt();
                modelSubCode = this.tNedit_St_ModelSubCode.GetInt();
            }
            else
            {
                makerCode = this.tNedit_Ed_MakerCode.GetInt();
                modelCode = this.tNedit_Ed_ModelCode.GetInt();
                modelSubCode = this.tNedit_Ed_ModelSubCode.GetInt();
            }
            int status = modelNameUAcs.ExecuteGuid2(makerCode, modelCode, modelSubCode, this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //開始、終了どちらのボタンが押されたか？
                if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
                {
                    //開始
                    this.tNedit_St_MakerCode.SetInt(modelNameU.MakerCode);
                    this.tNedit_St_ModelCode.SetInt(modelNameU.ModelCode);
                    this.tNedit_St_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                }
                else
                {
                    //終了
                    this.tNedit_Ed_MakerCode.SetInt(modelNameU.MakerCode);
                    this.tNedit_Ed_ModelCode.SetInt(modelNameU.ModelCode);
                    this.tNedit_Ed_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                }

                // 次の項目へフォーカス移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();
            }
            //メーカーガイド起動
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            switch (status)
            {
                //取得
                case 0:
                    {
                        if (makerUMnt != null)
                        {
                            //開始、終了どちらのボタンが押されたか？
                            if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_MakerGuide)
                            {
                                //開始
                                this.tNedit_St_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            }
                            else
                            {
                                //終了
                                this.tNedit_Ed_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            }

                            // 次のコントロールへフォーカスを移動
                            this.SelectNextControl((Control)sender, true, true, true, true);
                        }
                        break;
                    }
                //キャンセル
                case 1:
                    {

                        break;
                    }
            }
        }

        /// <summary>
        /// Control.Leave イベント (tEdit_WarehouseCode)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力フォーカスがコントロールを離れると発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void tEdit_WarehouseCode_Leave(object sender, EventArgs e)
        {
            if (!tEdit_WarehouseCode.Modified)
            {
                return;
            }

            if (tEdit_WarehouseCode.Text.Equals(string.Empty))
            {
                this.uLabel_WarehouseName.Text = "";
            }
            else
            {
                tEdit_WarehouseCode.Text = tEdit_WarehouseCode.Text.PadLeft(4,'0');
                Warehouse warehouseInfo;
                int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, this.tEdit_WarehouseCode.Text.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_WarehouseName.Text = warehouseInfo.WarehouseName;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    #region マスタ未登録
                    //-----------------------------------------------------------------------------
                    // マスタ未登録
                    //-----------------------------------------------------------------------------
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "倉庫が存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    this.tEdit_WarehouseCode.Text = string.Empty;
                    this.uLabel_WarehouseName.Text = string.Empty;
                    this.tEdit_WarehouseCode.Focus();
                    #endregion
                }
            }
        }

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;

            int status = this._warehouseAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._ownSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    this.tEdit_WarehouseCode.DataText = warehouseData.WarehouseCode.TrimEnd();
                    this.uLabel_WarehouseName.Text = warehouseData.WarehouseName.Trim();

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                //キャンセルなのでなにもしない
            }
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォーカスコント時に発生します。</br>
        /// <br>Programmer  : zhshh</br>
        /// <br>Date        : 2010.04.21</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            string str = null;
            if (!e.ShiftKey)
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    switch (e.PrevCtrl.Name)
                    {
                        case "tNedit_St_MakerCode":
                            {
                                if (0 == this.tNedit_St_MakerCode.GetInt())
                                {
                                    this.tNedit_St_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_ModelCode;
                                break;
                            }
                        case "tNedit_St_ModelCode":
                            {
                                if (0 == this.tNedit_St_ModelCode.GetInt())
                                {
                                    this.tNedit_St_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_ModelSubCode;
                                break;
                            }
                        case "tNedit_St_ModelSubCode":
                            {
                                if (0 == this.tNedit_St_ModelSubCode.GetInt())
                                {
                                    this.tNedit_St_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_ModelFullGuide;
                                break;
                            }
                        case "ub_St_ModelFullGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_MakerCode;
                                break;
                            }
                        case "tNedit_Ed_MakerCode":
                            {
                                if (0 == this.tNedit_Ed_MakerCode.GetInt())
                                {
                                    this.tNedit_Ed_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_ModelCode;
                                break;
                            }
                        case "tNedit_Ed_ModelCode":
                            {
                                if (0 == this.tNedit_Ed_ModelCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_ModelSubCode;
                                break;
                            }
                        case "tNedit_Ed_ModelSubCode":
                            {
                                if (0 == this.tNedit_Ed_ModelSubCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_ModelFullGuide;
                                break;
                            }
                        case "ub_Ed_ModelFullGuide":
                            {
                                e.NextCtrl = this.tEdit_FullModel;
                                break;
                            }
                        case "tEdit_FullModel":
                            {
                                e.NextCtrl = this.tComboEditor_FullModelFuzzy;
                                break;
                            }
                        case "tComboEditor_FullModelFuzzy":
                            {
                                e.NextCtrl = this.tNedit_St_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_St_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_St_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_St_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_MakerGuide;
                                break;
                            }
                        case "ub_St_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_Ed_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_Ed_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_Ed_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_MakerGuide;
                                break;
                            }
                        case "ub_Ed_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_St_BLGoodsCode;
                                break;
                            }
                        case "tNedit_St_BLGoodsCode":
                            {
                                if (0 == this.tNedit_St_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_St_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_BLGoodsCodeGuide;
                                break;
                            }
                        case "ub_St_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_BLGoodsCode;
                                break;
                            }
                        case "tNedit_Ed_BLGoodsCode":
                            {
                                if (0 == this.tNedit_Ed_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_Ed_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_BLGoodsCodeGuide;
                                break;
                            }
                        case "ub_Ed_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode;
                                break;
                            }
                    }
                }
            }
            else
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    switch (e.PrevCtrl.Name)
                    {
                        case "tNedit_St_MakerCode":
                            {
                                if (0 == this.tNedit_St_MakerCode.GetInt())
                                {
                                    this.tNedit_St_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.uos_NewPageDiv;
                                break;
                            }
                        case "tNedit_St_ModelCode":
                            {
                                if (0 == this.tNedit_St_ModelCode.GetInt())
                                {
                                    this.tNedit_St_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_MakerCode;
                                break;
                            }
                        case "tNedit_St_ModelSubCode":
                            {
                                if (0 == this.tNedit_St_ModelSubCode.GetInt())
                                {
                                    this.tNedit_St_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_ModelCode;
                                break;
                            }
                        case "ub_St_ModelFullGuide":
                            {
                                e.NextCtrl = this.tNedit_St_ModelSubCode;
                                break;
                            }
                        case "tNedit_Ed_MakerCode":
                            {
                                if (0 == this.tNedit_Ed_MakerCode.GetInt())
                                {
                                    this.tNedit_Ed_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_ModelFullGuide;
                                break;
                            }
                        case "tNedit_Ed_ModelCode":
                            {
                                if (0 == this.tNedit_Ed_ModelCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_MakerCode;
                                break;
                            }
                        case "tNedit_Ed_ModelSubCode":
                            {
                                if (0 == this.tNedit_Ed_ModelSubCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_ModelCode;
                                break;
                            }
                        case "ub_Ed_ModelFullGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_ModelSubCode;
                                break;
                            }
                        case "tEdit_FullModel":
                            {
                                e.NextCtrl = this.ub_Ed_ModelFullGuide;
                                break;
                            }
                        case "tComboEditor_FullModelFuzzy":
                            {
                                e.NextCtrl = this.tEdit_FullModel;
                                break;
                            }
                        case "tNedit_St_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_St_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_St_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.tComboEditor_FullModelFuzzy;
                                break;
                            }
                        case "ub_St_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_St_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_Ed_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_Ed_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_Ed_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_MakerGuide;
                                break;
                            }
                        case "ub_Ed_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_St_BLGoodsCode":
                            {
                                if (0 == this.tNedit_St_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_St_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_MakerGuide;
                                break;
                            }
                        case "ub_St_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tNedit_St_BLGoodsCode;
                                break;
                            }
                        case "tNedit_Ed_BLGoodsCode":
                            {
                                if (0 == this.tNedit_Ed_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_Ed_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_BLGoodsCodeGuide;
                                break;
                            }
                        case "ub_Ed_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_BLGoodsCode;
                                break;
                            }
                        case "tEdit_WarehouseCode":
                            {
                                str = this.tEdit_WarehouseCode.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_WarehouseCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_BLGoodsCodeGuide;
                                break;
                            }
                    }
                }
            }
        }


        # endregion     
    }
}
