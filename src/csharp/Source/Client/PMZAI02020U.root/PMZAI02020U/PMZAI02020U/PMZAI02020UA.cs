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
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    // <summary>
    /// 在庫マスタ一覧印刷UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ一覧印刷UIフォームクラス</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009.01.13</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMZAI02020UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
    {

        #region ■ Constructor
        /// <summary>
        /// 在庫マスタ一覧印刷UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ一覧印刷UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// <br></br>
        /// </remarks>
        public PMZAI02020UA()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 在庫マスタ一覧印刷アクセスクラス
            this._stockMasterTblAcs = new StockMasterTblAcs();

            // 倉庫マスタアクセスクラス
            this._wareHouseAcs = new WarehouseAcs();
            // 仕入先マスタアクセスクラス
            this._supplierAcs = new SupplierAcs();
            // メーカーマスタアクセスクラス
            this._makerAcs = new MakerAcs();
            // ユーザーガイドアクセスクラス
            this._userGuideAcs = new UserGuideAcs();
            // 商品中分類アクセスクラス
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            // BLグループアクセスクラス
            this._blGroupUAcs = new BLGroupUAcs();
            // BLコードアクセスクラス
            this._blGoodsCdAcs = new BLGoodsCdAcs();
        }
        #endregion

        #region ■ Private Member
        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
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

        #endregion ◆ Interface member

        // 拠点コード
        private string _enterpriseCode = "";
        // 在庫マスタ一覧印刷アクセスクラス
        private StockMasterTblAcs _stockMasterTblAcs;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ガイドアクセスクラス
        // 倉庫マスタアクセスクラス
        private WarehouseAcs _wareHouseAcs;
        // 仕入先マスタアクセスクラス
        private SupplierAcs _supplierAcs;
        // メーカーマスタアクセスクラス
        private MakerAcs _makerAcs;
        // ユーザーガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;
        // 商品中分類アクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs;
        // BLグループアクセスクラス
        private BLGroupUAcs _blGroupUAcs;
        // BLコードアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;
        
        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "PMZAI02020UA";
        // プログラムID
        private const string ct_PGID = "PMZAI02020U";
        // 帳票名称
        private const string ct_PrintName = "在庫マスタ一覧印刷";
        // 帳票キー	
        private const string ct_PrintKey = "86aa7f12-55e0-4988-8585-1645e2ffbb5a";
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件
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

        #endregion ◆ Public Property

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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // 抽出条件クラス
            ExtrInfo_StockMasterTbl extrInfo = new ExtrInfo_StockMasterTbl();

            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }

            // 帳票選択ガイド
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 印刷情報データリストを取得
            ArrayList retMList = null;
            status = this._stockMasterTblAcs.SearchMasterData(out retMList, this._enterpriseCode, printInfo.prpid, printInfo.prinm);
            if (status != 0)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "帳票レイアウトの取得に失敗しました。", 0);
                return -1;
            }
            extrInfo.PrintInfoList = (ArrayList)retMList.Clone();

            // 抽出条件の設定
            printInfo.jyoken = extrInfo;
            
            // 抽出呼び出し
            PMZAI02021EA freePrint = new PMZAI02021EA(printInfo);
            status = freePrint.ExtrPrintData();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
                return -1;
            }

            // 印刷呼び出し
            object prtObj = LoadAssemblyFrom("PMZAI02022P", "Broadleaf.Drawing.Printing.PMZAI02022PA");
            if (prtObj is IPrintProc)
            {
                (prtObj as IPrintProc).Printinfo = freePrint.Printinfo;
                (prtObj as IPrintProc).StartPrint();
            }

            return printInfo.status;
        }
        #endregion

        #region ◎ クラスインスタンス化
        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note 　　  : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.15</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:起動パラメータを変更する場合はここで行う。
            this.Show();
            return;
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 倉庫
                this.tEdit_WarehouseCode_St.Clear();
                this.tEdit_WarehouseCode_Ed.Clear();
                // 棚番
                this.tEdit_WarehouseShelfNo_St.Clear();
                this.tEdit_WarehouseShelfNo_Ed.Clear();
                // 仕入先
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();
                // メーカー
                this.tNedit_GoodsMakerCd_St.Clear();
                this.tNedit_GoodsMakerCd_Ed.Clear();
                // 商品大分類
                this.tNedit_GoodsLGroup_St.Clear();
                this.tNedit_GoodsLGroup_Ed.Clear();
                // 商品中分類
                this.tNedit_GoodsMGroup_St.Clear();
                this.tNedit_GoodsMGroup_Ed.Clear();
                // グループコード
                this.tNedit_BLGloupCode_St.Clear();
                this.tNedit_BLGloupCode_Ed.Clear();
                // BLコード
                this.tNedit_BLGoodsCode_St.Clear();
                this.tNedit_BLGoodsCode_Ed.Clear();
                // 品番
                this.tEdit_GoodsNo_St.Clear();
                this.tEdit_GoodsNo_Ed.Clear();
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
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "の範囲指定に誤りがあります";
            
            errMessage = "";
            errComponent = null;

            // 倉庫チェック
            if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            {
                errMessage = string.Format("倉庫{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 棚番チェック
            else if ((this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("棚番{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseShelfNo_St;
                status = false;
            }
            // 仕入先チェック
            else if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // メーカーチェック
            else if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 商品大分類チェック
            else if ((this.tNedit_GoodsLGroup_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsLGroup_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()))
            {
                errMessage = string.Format("商品大分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品中分類チェック
            else if ((this.tNedit_GoodsMGroup_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("商品中分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // グループコードチェック
            else if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // BLコードチェック
            else if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("BLコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 品番チェック
            else if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            
            return status;
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">抽出条件クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // 企業コード
                extrInfo_StockMasterTbl.EnterpriseCode = this._enterpriseCode;
                // 倉庫
                // 開始
                if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                {
                    extrInfo_StockMasterTbl.St_WarehouseCode = "";
                }
                else
                {
                    extrInfo_StockMasterTbl.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                }
                // 終了
                if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                {
                    extrInfo_StockMasterTbl.Ed_WarehouseCode = "";
                }
                else
                {
                    extrInfo_StockMasterTbl.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                }
                // 棚番
                extrInfo_StockMasterTbl.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text.Trim();
                extrInfo_StockMasterTbl.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text.Trim();
                // 仕入先
                extrInfo_StockMasterTbl.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                extrInfo_StockMasterTbl.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
                // メーカーコード
                extrInfo_StockMasterTbl.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                extrInfo_StockMasterTbl.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // 商品大分類
                extrInfo_StockMasterTbl.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                extrInfo_StockMasterTbl.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();
                // 商品中分類
                extrInfo_StockMasterTbl.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                extrInfo_StockMasterTbl.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // グループコード
                extrInfo_StockMasterTbl.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                extrInfo_StockMasterTbl.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // BLコード
                extrInfo_StockMasterTbl.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                extrInfo_StockMasterTbl.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                // 品番
                extrInfo_StockMasterTbl.St_GoodsNo = this.tEdit_GoodsNo_St.Text.Trim();
                extrInfo_StockMasterTbl.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text.Trim();

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion ◆ 印刷前処理

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
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
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
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

        #region ◆ エラーメッセージ表示
        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion ■ Private Method

        #region ■ Control Event
        #region ◆ PMZAI02020UA
        #region ◎ PMZAI02020UA_Load Event
        /// <summary>
        /// PMZAI02020UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        /// 
        private void PMZAI02020UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // 初期化タイマー起動
            Initialize_Timer.Enabled = true;

            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動
        }
        #endregion
        #endregion ◆ PMZAI02020UA

        #region ◆ ueb_MainExplorerBar
        #region ◎ GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009.01.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }

        }
        #endregion
        #endregion ◆ ueb_MainExplorerBar Event


        #region ◎ 開始倉庫ガイドボタンクリックイベント
        /// <summary>
        /// 開始倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // ガイド起動
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = wareHouse.WarehouseCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了倉庫ガイドボタンクリックイベント
        /// <summary>
        /// 終了倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // ガイド起動
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = wareHouse.WarehouseCode.TrimEnd();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始仕入先ガイドボタンクリックイベント
        /// <summary>
        /// 開始仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了仕入先ガイドボタンクリックイベント
        /// <summary>
        /// 終了仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始メーカーガイドボタンクリックイベント
        /// <summary>
        /// 開始メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了メーカーガイドボタンクリックイベント
        /// <summary>
        /// 終了メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;
            
            // ガイド起動
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始商品大分類ガイドボタンクリックイベント
        /// <summary>
        /// 開始商品大分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd;
            UserGdHd userGdHd;
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                this.tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了商品大分類ガイドボタンクリックイベント
        /// <summary>
        /// 終了商品大分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd;
            UserGdHd userGdHd;
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始商品中分類ガイドボタンクリックイベント
        /// <summary>
        /// 開始商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            GoodsGroupU goodgroupU;            
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了商品中分類ガイドボタンクリックイベント
        /// <summary>
        /// 終了商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            GoodsGroupU goodgroupU;
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始グループコードガイドボタンクリックイベント
        /// <summary>
        /// 開始グループコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了グループコードガイドボタンクリックイベント
        /// <summary>
        /// 終了グループコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 開始BLコードガイドボタンクリックイベント
        /// <summary>
        /// 開始BLコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ 終了BLコードガイドボタンクリックイベント
        /// <summary>
        /// 終了BLコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_Ed_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region ◎ tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // 倉庫(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // 倉庫(終了)→棚番(開始)
                        e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // 仕入先(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // メーカー(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // メーカー(終了)→商品大分類(開始)
                        e.NextCtrl = this.tNedit_GoodsLGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
                    {
                        // 商品大分類(開始)→商品大分類(終了)
                        e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
                    {
                        // 商品大分類(終了)→商品中分類(開始)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        // 商品中分類(開始)→商品中分類(終了)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        // 商品中分類(終了)→グループコード(開始)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // グループコード(開始)→グループコード(終了)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // グループコード(終了)→BLコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BLコード(開始)→BLコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BLコード(終了)→品番(開始)
                        e.NextCtrl = this.tEdit_GoodsNo_St;
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_GoodsNo_St)
                    {
                        // 品番(開始)→BLコード(終了)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // BLコード(終了)→BLコード(開始)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // BLコード(開始)→グループコード(終了)
                        e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        // グループコード(終了)→グループコード(開始)
                        e.NextCtrl = this.tNedit_BLGloupCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        // グループコード(開始)→商品中分類(終了)
                        e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        // 商品中分類(終了)→商品中分類(開始)
                        e.NextCtrl = this.tNedit_GoodsMGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        // 商品中分類(開始)→商品大分類(終了)
                        e.NextCtrl = this.tNedit_GoodsLGroup_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
                    {
                        // 商品大分類(終了)→商品大分類(開始)
                        e.NextCtrl = this.tNedit_GoodsLGroup_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
                    {
                        // 商品大分類(開始)→メーカー(終了)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // メーカー(終了)→メーカー(開始)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // メーカー(開始)→仕入先(終了)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // 仕入先(終了)→仕入先(開始)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
                    {
                        // 棚番(開始)→倉庫(終了)
                        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        // 倉庫(終了)→倉庫(開始)
                        e.NextCtrl = this.tEdit_WarehouseCode_St;
                    }
                }
            }
        }
        #endregion
        #endregion ■ Control Event

        #region ◆ Initialize_Timer
        #region ◎ Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コントロール初期化
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // ガイドボタンのアイコン設定
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsLGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                ParentToolbarSettingEvent(this);	// ツールバー設定イベント
            }
            finally
            {
                // 初期フォーカス
                this.tEdit_WarehouseCode_St.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #endregion ◆ Initialize_Timer

    }
}
