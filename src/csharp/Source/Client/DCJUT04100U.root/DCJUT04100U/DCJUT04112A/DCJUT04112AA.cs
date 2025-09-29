# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注残照会 テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 伝票検索を行います。</br>
	/// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2007.10.15</br>
    /// <br>Update Note : 2009/02/25 30414 忍 幸史 障害ID:7882対応</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/25　22008 長内 数馬</br>
    /// <br>              オフライン対応</br>
    /// </remarks>
    public class AcptAnOdrRemainRefAcs
    {
        # region ■ private const ■
        private const string MESSAGE_NoResult = "検索条件に一致する伝票は存在しません。";
        private const string MESSAGE_ErrResult = "伝票情報の取得に失敗しました。";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
        private const string ct_DateFormat = "yyyy/MM/dd";
        # endregion ■ private const ■

        # region ■ private static member ■
        private static SecInfoAcs _secInfoAcs;                      // 拠点アクセスクラス
        # endregion ■ private static member ■

        # region ■ private member ■
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IAcptAnOdrRemainRefDB _iAcptAnOdrRemainRefDB = null;
        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
        /// <summary>データテーブル</summary>
        private DataTable _acptAnOdrRemainRefTable;
        private string _enterpriseCode;             // 企業コード
        /// <summary>売上金額端数処理クラス</summary>
        private SalesFractionCalculate _salesFractionCalculate;
        /// <summary>得意先マスタアクセス</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>表示用データビュー</summary>
        private DataView _displayDataView;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.20 TOKUNAGA ADD START
        // 拠点コード (商品検索マスタを初期化するために必要)
        private string _sectionCode;

        // メーカーコード (メーカーが特定された場合の品番検索に使用)
        private int _makerCode = 0;

        private int _inpAgentDispDiv;                       // 設定値保存用：売上全体設定．発行者表示区分

        // 発行者表示区分(DCKHN09211Eの区分と合わせる必要あり)
        private const int INP_AGT_DISP = 0;         // 0:する
        private const int INP_AGT_NODISP = 1;       // 1:しない
        private const int INP_AGT_NESSESALY = 2;    // 2:必須

        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>
        /// メーカーコード
        /// </summary>
        public int MakerCode
        {
            get { return this._makerCode; }
            set { this._makerCode = value; }
        }

        /// <summary>
        /// 発行者表示区分
        /// </summary>
        public int InpAgentDispDiv
        {
            get { return this._inpAgentDispDiv; }
            set { this._inpAgentDispDiv = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.20 TOKUNAGA ADD END
        # endregion ■ private member ■

        # region ■ event ■

        // 出力メッセージ設定イベント
        /// <summary>メッセージ設定イベント</summary>
        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        /// <summary>
        /// メッセージ設定イベント定義
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);
        // 行選択状態変更イベント
        /// <summary>行選択状態変更イベント</summary>
        public event EventHandler SelectedDataChange;

        # endregion ■ event ■

        # region ■Constracter
        /// <summary>
		/// 発注残照会 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : 発注残照会アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public AcptAnOdrRemainRefAcs()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // データテーブル生成
            DCJUT04102AC.CreateDataTable( ref this._acptAnOdrRemainRefTable, this._inpAgentDispDiv );
            // プライマリキー設定（行番号）
            this._acptAnOdrRemainRefTable.PrimaryKey = new DataColumn[] { this._acptAnOdrRemainRefTable.Columns[DCJUT04102AC.ct_Col_RowNoView] };
            
            // 売上金額端数処理クラスインスタンス取得
            this._salesFractionCalculate = SalesFractionCalculate.GetInstance();
            this._salesFractionCalculate.SearchInitial( this._enterpriseCode );

            // 得意先マスタアクセス
            this._customerInfoAcs = new CustomerInfoAcs();

            // ログイン部品で通信状態を確認
            // -- UPD 2010/05/25 ----------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iAcptAnOdrRemainRefDB = (IAcptAnOdrRemainRefDB)MediationAcptAnOdrRemainRefDB.GetAcptAnOdrRemainRefDB();
            //    }
            //    catch (Exception)
            //    {
            //        //オフライン時はnullをセット
            //        this._iAcptAnOdrRemainRefDB = null;
            //    }
            //}
            //else
            //{
            //    // オフライン時のデータ読み込み
            //    //this.SearchOfflineData();
            //    MessageBox.Show("オフライン状態のため検索が実行できません。");
            //}

            try
            {
                // リモートオブジェクト取得
                this._iAcptAnOdrRemainRefDB = (IAcptAnOdrRemainRefDB)MediationAcptAnOdrRemainRefDB.GetAcptAnOdrRemainRefDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iAcptAnOdrRemainRefDB = null;
            }
            // -- UPD 2010/05/25 -----------------------<<<
        }
        # endregion

        # region ◆public int GetOnlineMode()
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iAcptAnOdrRemainRefDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        # endregion

        #region ■Private Method

        /// <summary>
        /// テーブル行追加　（リモート結果クラス→テーブルデータ行）
        /// </summary>
        /// <param name="index">テーブル行番号(0から始まるindex)</param>
        /// <param name="refDataWork">リモート結果クラス</param>
        private void AddDataRowFromResultWork(int index, AcptAnOdrRemainRefDataWork refDataWork)//, string exSalesSlipNum)
        {
            DataRow newRow = this._acptAnOdrRemainRefTable.NewRow();

            newRow[DCJUT04102AC.ct_Col_EnterpriseCode] = refDataWork.EnterpriseCode;            // 企業コード
            newRow[DCJUT04102AC.ct_Col_AcptAnOdrStatus] = refDataWork.AcptAnOdrStatus;          // 受注ステータス
            newRow[DCJUT04102AC.ct_Col_SalesSlipNum] = refDataWork.SalesSlipNum;                // 売上伝票番号
            newRow[DCJUT04102AC.ct_Col_AcceptAnOrderNo] = refDataWork.AcceptAnOrderNo;          // 受注番号
            newRow[DCJUT04102AC.ct_Col_CommonSeqNo] = refDataWork.CommonSeqNo;                  // 共通通番
            newRow[DCJUT04102AC.ct_Col_SalesSlipDtlNum] = refDataWork.SalesSlipDtlNum;          // 売上明細通番
            if (refDataWork.CustomerCode > 0) // 0の時は空白
            {
                newRow[DCJUT04102AC.ct_Col_CustomerCode] = refDataWork.CustomerCode.ToString().PadLeft(8, '0');                // 得意先コード
            }
            newRow[DCJUT04102AC.ct_Col_CustomerSnm] = refDataWork.CustomerSnm;                  // 得意先略称
            newRow[DCJUT04102AC.ct_Col_SalesEmployeeNm] = refDataWork.SalesEmployeeNm;          // 販売従業員名称
            newRow[DCJUT04102AC.ct_Col_SalesInputNm] = refDataWork.SalesInputName;              // 発行者名称 [9094]
            newRow[DCJUT04102AC.ct_Col_AddresseeName] = refDataWork.AddresseeName;              // 納品先名称
            newRow[DCJUT04102AC.ct_Col_AddresseeName2] = refDataWork.AddresseeName2;            // 納品先名称2
            newRow[DCJUT04102AC.ct_Col_FrontEmployeeNm] = refDataWork.FrontEmployeeNm;          // 受付従業員名称
            newRow[DCJUT04102AC.ct_Col_SalesDate] = refDataWork.SalesDate;                      // 売上日付
            newRow[DCJUT04102AC.ct_Col_GoodsNo] = refDataWork.GoodsNo;                          // 商品番号
            newRow[DCJUT04102AC.ct_Col_GoodsName] = refDataWork.GoodsName;                      // 商品名称
            newRow[DCJUT04102AC.ct_Col_MakerName] = refDataWork.MakerName;                      // メーカー名称
            newRow[DCJUT04102AC.ct_Col_AcceptAnOrderCnt] = refDataWork.AcceptAnOrderCnt;        // 受注数量
            newRow[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt] = refDataWork.AcptAnOdrRemainCnt;    // 受注残数
            //newRow[DCJUT04102AC.ct_Col_UnitName] = refDataWork.UnitName;                        // 単位名称
            newRow[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl] = refDataWork.SalesUnPrcTaxExcFl;    // 売上単価（税抜，浮動）
            //newRow[DCJUT04102AC.ct_Col_BargainNm] = refDataWork.BargainNm;                      // 特売区分名称
            newRow[DCJUT04102AC.ct_Col_PartySlipNumDtl] = refDataWork.PartySlipNumDtl;          // 相手先伝票番号（明細）
            newRow[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc] = refDataWork.StdUnPrcSalUnPrc;        // 基準単価（売上単価）
            newRow[DCJUT04102AC.ct_Col_SalesUnitCost] = refDataWork.SalesUnitCost;              // 原価単価
            newRow[DCJUT04102AC.ct_Col_SupplierSnm] = refDataWork.SupplierSnm;                  // 仕入先略称
            newRow[DCJUT04102AC.ct_Col_DtlNote] = refDataWork.DtlNote;                          // 明細備考
            //newRow[DCJUT04102AC.ct_Col_CustomerDeliveryDate] = refDataWork.CustomerDeliveryDate; // 客先納期
            newRow[DCJUT04102AC.ct_Col_SlipMemo1] = refDataWork.SlipMemo1;                      // 伝票メモ１
            newRow[DCJUT04102AC.ct_Col_SlipMemo2] = refDataWork.SlipMemo2;                      // 伝票メモ２
            newRow[DCJUT04102AC.ct_Col_SlipMemo3] = refDataWork.SlipMemo3;                      // 伝票メモ３
            //newRow[DCJUT04102AC.ct_Col_SlipMemo4] = refDataWork.SlipMemo4;                      // 伝票メモ４
            //newRow[DCJUT04102AC.ct_Col_SlipMemo5] = refDataWork.SlipMemo5;                      // 伝票メモ５
            //newRow[DCJUT04102AC.ct_Col_SlipMemo6] = refDataWork.SlipMemo6;                      // 伝票メモ６
            newRow[DCJUT04102AC.ct_Col_InsideMemo1] = refDataWork.InsideMemo1;                  // 社内メモ１
            newRow[DCJUT04102AC.ct_Col_InsideMemo2] = refDataWork.InsideMemo2;                  // 社内メモ２
            newRow[DCJUT04102AC.ct_Col_InsideMemo3] = refDataWork.InsideMemo3;                  // 社内メモ３
            //newRow[DCJUT04102AC.ct_Col_InsideMemo4] = refDataWork.InsideMemo4;                  // 社内メモ４
            //newRow[DCJUT04102AC.ct_Col_InsideMemo5] = refDataWork.InsideMemo5;                  // 社内メモ５
            //newRow[DCJUT04102AC.ct_Col_InsideMemo6] = refDataWork.InsideMemo6;                  // 社内メモ６
            //newRow[DCJUT04102AC.ct_Col_SupplierFormal] = refDataWork.SupplierFormal;            // 仕入形式
            //newRow[DCJUT04102AC.ct_Col_StockSlipDtlNum] = refDataWork.StockSlipDtlNum;          // 仕入明細通番
            //newRow[DCJUT04102AC.ct_Col_OrderNumber] = refDataWork.OrderNumber;                  // 発注番号
            //newRow[DCJUT04102AC.ct_Col_ExpectDeliveryDate] = refDataWork.ExpectDeliveryDate;    // 希望納期
            //newRow[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] = refDataWork.DeliGdsCmpltDueDate;  // 納品完了予定日
            //newRow[DCJUT04102AC.ct_Col_ArrivalGoodsDay] = refDataWork.ArrivalGoodsDay;          // 入荷日
            //newRow[DCJUT04102AC.ct_Col_StockCount] = refDataWork.StockCount;                    // 仕入数
            //newRow[DCJUT04102AC.ct_Col_StockUnitPriceFl] = refDataWork.StockUnitPriceFl;        // 仕入単価（税抜，浮動）

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            if (refDataWork.SupplierCd > 0) // 0の時は空白
            {
                newRow[DCJUT04102AC.ct_Col_SupplierCd] = refDataWork.SupplierCd.ToString().PadLeft(6, '0');                    // 仕入先コード
            }
            newRow[DCJUT04102AC.ct_Col_WarehouseCode] = refDataWork.WarehouseCode;
            newRow[DCJUT04102AC.ct_Col_WarehouseName] = refDataWork.WarehouseName;
            string slipCdDtl;
            switch (refDataWork.SalesSlipCdDtl)
            {
                case 0: slipCdDtl = "売上"; break;
                case 1: slipCdDtl = "返品"; break;
                case 2: slipCdDtl = "値引"; break;
                case 3: slipCdDtl = "注釈"; break;
                case 4: slipCdDtl = "小計"; break;
                case 5: slipCdDtl = "作業"; break;
                default: slipCdDtl = ""; break;
            }
            newRow[DCJUT04102AC.ct_Col_SalesSlipCdDtl] = slipCdDtl;
            if (refDataWork.BLGoodsCode > 0) // 0の時は空白
            {
                newRow[DCJUT04102AC.ct_Col_BLGoodsCode] = refDataWork.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            newRow[DCJUT04102AC.ct_Col_SalesPriceTotal] = refDataWork.ListPriceTaxExcFl * refDataWork.AcceptAnOrderCnt;
            // 消費税転嫁区分によって内容を変える
            // 総額表示＝するの時は明細単位のみ
            if ((refDataWork.ConsTaxLayMethod == 0) ||// 伝票単位
                (refDataWork.ConsTaxLayMethod == 1)) // 明細単位
            {
                newRow[DCJUT04102AC.ct_Col_SalesPriceConsTax] = refDataWork.SalesPriceConsTax;
            }
            else if ((refDataWork.ConsTaxLayMethod == 2) || // 請求親
                    (refDataWork.ConsTaxLayMethod == 3) || // 請求子
                    (refDataWork.ConsTaxLayMethod == 9)) // 非課税
            {
                // 内税のときのみ表示
                if (refDataWork.TaxationDivCd == 2)
                {
                    newRow[DCJUT04102AC.ct_Col_SalesPriceConsTax] = refDataWork.SalesPriceConsTax;
                }
                else
                {
                    newRow[DCJUT04102AC.ct_Col_SalesPriceConsTax] = DBNull.Value;
                }
            }
            newRow[DCJUT04102AC.ct_Col_ListPriceTaxExc] = refDataWork.ListPriceTaxExcFl;
            newRow[DCJUT04102AC.ct_Col_SalesTotalCost] = refDataWork.SalesUnitCost * refDataWork.AcceptAnOrderCnt;
            newRow[DCJUT04102AC.ct_Col_ShipmentCnt] = refDataWork.ShipmentCnt;
            newRow[DCJUT04102AC.ct_Col_CarMngCode] = refDataWork.CarMngCode;
            newRow[DCJUT04102AC.ct_Col_ModelDesignationNo] = refDataWork.ModelDesignationNo;
            newRow[DCJUT04102AC.ct_Col_CategoryNo] = refDataWork.CategoryNo;
            if (refDataWork.ModelDesignationNo > 0 || refDataWork.CategoryNo > 0)
            {
                string tmpModel = "00000" + refDataWork.ModelDesignationNo.ToString();
                tmpModel = tmpModel.Substring(tmpModel.Length - 5, 5);
                string tmpCategory = "0000" + refDataWork.CategoryNo.ToString();
                tmpCategory = tmpCategory.Substring(tmpCategory.Length - 4, 4);
                newRow[DCJUT04102AC.ct_Col_ModelCategory] = tmpModel + "-" + tmpCategory;
            }
            newRow[DCJUT04102AC.ct_Col_ModelFullName] = refDataWork.ModelFullName;
            newRow[DCJUT04102AC.ct_Col_FullModel] = refDataWork.FullModel;
            newRow[DCJUT04102AC.ct_Col_SearchSlipDate] = refDataWork.SearchSlipDate;//TDateTime.DateTimeToLongDate(refDataWork.SearchSlipDate);
            if (refDataWork.SearchSlipDate != DateTime.MinValue)
            {
                newRow[DCJUT04102AC.ct_Col_SearchSlipDateString] = refDataWork.SearchSlipDate.ToString("yyyy/MM/dd");// TDateTime.DateTimeToString("yyyy/MM/dd", refDataWork.SearchSlipDate);
            }
            newRow[DCJUT04102AC.ct_Col_ShipmentDay] = refDataWork.ShipmentDay;// TDateTime.DateTimeToLongDate(refDataWork.ShipmentDay);
            if (refDataWork.ShipmentDay != DateTime.MinValue)
            {
                newRow[DCJUT04102AC.ct_Col_ShipmentDayString] = refDataWork.ShipmentDay.ToString("yyyy/MM/dd");// TDateTime.DateTimeToString("yyyy/MM/dd", refDataWork.ShipmentDay);
            }
            newRow[DCJUT04102AC.ct_Col_AddUpADate] = refDataWork.AddUpADate;// TDateTime.DateTimeToLongDate(refDataWork.AddUpADate);
            if (refDataWork.AddUpADate != DateTime.MinValue)
            {
                newRow[DCJUT04102AC.ct_Col_AddUpADateString] = refDataWork.AddUpADate.ToString("yyyy/MM/dd");//TDateTime.DateTimeToString("yyyy/MM/dd", refDataWork.AddUpADate);
            }
            newRow[DCJUT04102AC.ct_Col_SectionName] = refDataWork.SectionGuideNm;
            if (refDataWork.ClaimCode > 0) // 0の時は空白
            {
                newRow[DCJUT04102AC.ct_Col_ClaimCode] = refDataWork.ClaimCode.ToString().PadLeft(8, '0');
            }
            newRow[DCJUT04102AC.ct_Col_ClaimSnm] = refDataWork.ClaimSnm;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END
            // 2008.12.12 add start [9095]
            newRow[DCJUT04102AC.ct_Col_SalesRowNo] = refDataWork.SalesRowNo;
            // 2008.12.12 add end [9095]
            //-------------------------------------------------------------------------------------
            // （※以下、ＵＩ制御・表示用項目）
            //-------------------------------------------------------------------------------------
            newRow[DCJUT04102AC.ct_Col_RowNoView] = index + 1;  // 表示行番号
            newRow[DCJUT04102AC.ct_Col_SelectRowFlag] = false;  // 選択フラグ

            //newRow[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice] = GetAcptAnOdrRemainPrice( newRow ); // 受注残金額
            newRow[DCJUT04102AC.ct_Col_MemoExistsFlag] = GetMemoExists( newRow );   // メモ有無フラグ

            if ( (bool)newRow[DCJUT04102AC.ct_Col_MemoExistsFlag] == true )
            {
                newRow[DCJUT04102AC.ct_Col_MemoExistsMark] = "○"; // メモマーク
            }
            else
            {
                newRow[DCJUT04102AC.ct_Col_MemoExistsMark] = string.Empty; // メモマーク
            }

            //--- 表示用日付 ---//
            SetDatesForView( ref newRow );

            //-------------------------------------------------------------------------------------
            // 行追加
            //-------------------------------------------------------------------------------------
            this._acptAnOdrRemainRefTable.Rows.Add( newRow );
        }
        /// <summary>
        /// 表示用日付設定処理
        /// </summary>
        /// <param name="row"></param>
        private void SetDatesForView ( ref DataRow row )
        {
            // 売上日付（表示用）
            if ( (DateTime)row[DCJUT04102AC.ct_Col_SalesDate] == DateTime.MinValue )
            {
                row[DCJUT04102AC.ct_Col_SalesDateView] = string.Empty;
            }
            else
            {
                row[DCJUT04102AC.ct_Col_SalesDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_SalesDate] ).ToString( "yyyy/MM/dd" );
            }

            //// 客先納期（表示用）
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_CustomerDeliveryDate] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_CustomerDeliveryDateView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_CustomerDeliveryDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_CustomerDeliveryDate] ).ToString( "yyyy/MM/dd" );
            //}

            //// 希望納期（表示用）
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_ExpectDeliveryDate] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_ExpectDeliveryDateView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_ExpectDeliveryDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_ExpectDeliveryDate] ).ToString( "yyyy/MM/dd" );
            //}

            //// 納品完了予定日（表示用）
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView] = ( (DateTime)row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] ).ToString( "yyyy/MM/dd" );
            //}

            //// 入荷日（表示用）
            //if ( (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] == DateTime.MinValue )
            //{
            //    row[DCJUT04102AC.ct_Col_ArrivalGoodsDayView] = string.Empty;
            //}
            //else
            //{
            //    row[DCJUT04102AC.ct_Col_ArrivalGoodsDayView] = ( (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] ).ToString( "yyyy/MM/dd" );
            //}
        }
        /// <summary>
        /// メモ有無判定処理
        /// </summary>
        /// <param name="row">データテーブル行</param>
        /// <returns>メモ有無(true:有り／false:無し)</returns>
        private bool GetMemoExists ( DataRow row )
        {
            // 伝票メモ
            if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo1] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo2] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo3] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo4] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo5] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_SlipMemo6] ).TrimEnd() != string.Empty ) return true;
            // 社内メモ
            if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo1] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo2] ).TrimEnd() != string.Empty ) return true;
            if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo3] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo4] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo5] ).TrimEnd() != string.Empty ) return true;
            //if ( ( (string)row[DCJUT04102AC.ct_Col_InsideMemo6] ).TrimEnd() != string.Empty ) return true;

            return false;
        }
        /// <summary>
        /// 受注残金額算出処理
        /// </summary>
        /// <param name="row">データテーブル行</param>
        /// <returns>受注残金額（受注残数×売上単価）</returns>
        /// <remarks>
        /// <br>得意先の端数処理コードを取得し、売上端数処理マスタを参照して端数処理します。</br>
        /// </remarks>
        private Int64 GetAcptAnOdrRemainPrice ( DataRow row )
        {
            double unitPrice = (double)row[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl]; // 単価
            double remainCnt = (double)row[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt]; // 受注残数
            
            // 端数処理コード取得
            int customerCd = (int)row[DCJUT04102AC.ct_Col_CustomerCode];
            CustomerInfo customerInfo = null;

            if (customerCd != 0) 
            {
                // 得意先マスタ読み込み
                this.GetCustomerInfo( customerCd, out customerInfo );
            }

            if ( customerInfo != null )
            {
                // 金額端数処理マスタに従った端数処理を行う
                return (Int64)this._salesFractionCalculate.GetSalesPrice( unitPrice * remainCnt, customerInfo.SalesMoneyFrcProcCd );
            }
            else
            {
                // もし得意先読み込みできなくても
                // 暫定的な計算結果を返す。
                return (Int64)(unitPrice * remainCnt);
            }
        }
        /// <summary>
        /// 得意先情報取得
        /// </summary>
        /// <param name="customerCd"></param>
        /// <param name="customerInfo"></param>
        /// <remarks>
        /// <br>得意先マスタアクセスクラスの呼出を行います。</br>
        /// <br>キャッシュ読み込みを優先して行い、未キャッシュのみリモート呼び出しします。</br>
        /// </remarks>
        private void GetCustomerInfo ( int customerCd, out CustomerInfo customerInfo )
        {
            int status = this._customerInfoAcs.ReadCacheMemoryData( out customerInfo, this._enterpriseCode, customerCd );
            if ( status != 0 )
            {
                this._customerInfoAcs.ReadDBData( this._enterpriseCode, customerCd, out customerInfo );
            }
        }

        /// <summary>
        /// テーブル行更新　（リモート結果クラス→テーブルデータ行）
        /// </summary>
        /// <param name="index">テーブル行№(0から始まるindex)</param>
        /// <param name="refDataWork">リモート結果クラス</param>
        private void UpdateRowFromResultWork ( int index, AcptAnOdrRemainRefDataWork refDataWork)
        {
            //SupplierFormalState supplierFormal = (SupplierFormalState)refDataWork.SupplierFormal;
            
            // 更新対象行取得
            if (index >= this._acptAnOdrRemainRefTable.Rows.Count) return;
            DataRow row = this._acptAnOdrRemainRefTable.Rows[index];
            
            if (row == null) return;

            // 仕入形式により処理が異なる
            //switch ( supplierFormal )
            //{
            //    //---------------------------------------------------------------------------------------------------
            //    // 仕入
            //    //---------------------------------------------------------------------------------------------------
            //    //case SupplierFormalState.Stock:
            //    //    {
            //    //        // 入荷日が新しいならば更新
            //    //        if ( refDataWork.ArrivalGoodsDay > (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] )
            //    //        {
            //    //            row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] = refDataWork.ArrivalGoodsDay;     // 入荷日
            //    //            row[DCJUT04102AC.ct_Col_StockUnitPriceFl] = refDataWork.StockUnitPriceFl;   // 仕入単価
            //    //        }

            //    //        // 入荷数を加算
            //    //        row[DCJUT04102AC.ct_Col_StockCount] = (double)row[DCJUT04102AC.ct_Col_StockCount] + refDataWork.StockCount;

            //    //        break;
            //    //    }
            //    //---------------------------------------------------------------------------------------------------
            //    // 入荷
            //    //---------------------------------------------------------------------------------------------------
            //    //case SupplierFormalState.Arrival:
            //    //    {
            //    //        // 入荷日が新しいならば更新
            //    //        if ( refDataWork.ArrivalGoodsDay > (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] )
            //    //        {
            //    //            row[DCJUT04102AC.ct_Col_ArrivalGoodsDay] = refDataWork.ArrivalGoodsDay;     // 入荷日
            //    //            row[DCJUT04102AC.ct_Col_StockUnitPriceFl] = refDataWork.StockUnitPriceFl;   // 仕入単価
            //    //        }

            //    //        // 入荷数を加算
            //    //        row[DCJUT04102AC.ct_Col_StockCount] = (double)row[DCJUT04102AC.ct_Col_StockCount] + refDataWork.StockCount;

            //    //        break;
            //    //    }
            //    //---------------------------------------------------------------------------------------------------
            //    // 発注
            //    //---------------------------------------------------------------------------------------------------
            //    case SupplierFormalState.Order:
            //        {
            //            // 発注情報が既に入っていて、今回レコードが新しいならば更新
            //            if ( (string)row[DCJUT04102AC.ct_Col_OrderNumber] != string.Empty &&
            //                refDataWork.StockSlipDtlNum > (Int64)row[DCJUT04102AC.ct_Col_StockSlipDtlNum] )
            //            {
            //                row[DCJUT04102AC.ct_Col_StockSlipDtlNum] = refDataWork.StockSlipDtlNum;         // 仕入明細通番
            //                row[DCJUT04102AC.ct_Col_OrderNumber] = refDataWork.OrderNumber;                 // 発注番号
            //                row[DCJUT04102AC.ct_Col_ExpectDeliveryDate] = refDataWork.ExpectDeliveryDate;   // 希望納期
            //                row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate] = refDataWork.DeliGdsCmpltDueDate; // 納品完了予定日
            //            }
            //            break;
            //        }
            //    default:
            //        break;
            //}

            //--- 表示用日付 ---//
            SetDatesForView( ref row );
   
        }

        /// <summary>
        /// 行Find処理（プライマリキー：行№）
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns></returns>
        private DataRow FindDataRowByPrimaryKey ( int rowNo )
        {
            return this._acptAnOdrRemainRefTable.Rows.Find( rowNo );
        }
        /// <summary>
        /// データコピー処理（データ行ビュー→照会抽出結果データ）
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private AcptAnOdrRemainRefData CopyToRefDataFromRow ( DataRow row )
        {
            AcptAnOdrRemainRefData refData = new AcptAnOdrRemainRefData();

            refData.EnterpriseCode = (string)row[DCJUT04102AC.ct_Col_EnterpriseCode]; // 企業コード
            refData.AcptAnOdrStatus = (Int32)row[DCJUT04102AC.ct_Col_AcptAnOdrStatus]; // 受注ステータス
            refData.SalesSlipNum = (string)row[DCJUT04102AC.ct_Col_SalesSlipNum]; // 売上伝票番号
            refData.AcceptAnOrderNo = (Int32)row[DCJUT04102AC.ct_Col_AcceptAnOrderNo]; // 受注番号
            refData.CommonSeqNo = (Int64)row[DCJUT04102AC.ct_Col_CommonSeqNo]; // 共通通番
            refData.SalesSlipDtlNum = (Int64)row[DCJUT04102AC.ct_Col_SalesSlipDtlNum]; // 売上明細通番
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_CustomerCode].ToString()))
            {
                refData.CustomerCode = Int32.Parse(row[DCJUT04102AC.ct_Col_CustomerCode].ToString()); // 得意先コード
            }
            else
            {
                refData.CustomerCode = 0;
            }
            refData.CustomerSnm = (string)row[DCJUT04102AC.ct_Col_CustomerSnm]; // 得意先略称
            refData.SalesEmployeeNm = (string)row[DCJUT04102AC.ct_Col_SalesEmployeeNm]; // 販売従業員名称
            refData.AddresseeName = (string)row[DCJUT04102AC.ct_Col_AddresseeName]; // 納品先名称
            refData.AddresseeName2 = (string)row[DCJUT04102AC.ct_Col_AddresseeName2]; // 納品先名称2
            refData.FrontEmployeeNm = (string)row[DCJUT04102AC.ct_Col_FrontEmployeeNm]; // 受付従業員名称
            refData.SalesDate = (DateTime)row[DCJUT04102AC.ct_Col_SalesDate]; // 売上日付
            refData.GoodsNo = (string)row[DCJUT04102AC.ct_Col_GoodsNo]; // 商品番号
            refData.GoodsName = (string)row[DCJUT04102AC.ct_Col_GoodsName]; // 商品名称
            refData.MakerName = (string)row[DCJUT04102AC.ct_Col_MakerName]; // メーカー名称
            refData.AcceptAnOrderCnt = (Double)row[DCJUT04102AC.ct_Col_AcceptAnOrderCnt]; // 受注数量
            refData.AcptAnOdrRemainCnt = (Double)row[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt]; // 受注残数
            //refData.UnitName = (string)row[DCJUT04102AC.ct_Col_UnitName]; // 単位名称
            refData.SalesUnPrcTaxExcFl = (Double)row[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl]; // 売上単価（税抜，浮動）
            //refData.BargainNm = (string)row[DCJUT04102AC.ct_Col_BargainNm]; // 特売区分名称
            refData.PartySlipNumDtl = (string)row[DCJUT04102AC.ct_Col_PartySlipNumDtl]; // 相手先伝票番号（明細）
            refData.StdUnPrcSalUnPrc = (Double)row[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc]; // 基準単価（売上単価）
            refData.SalesUnitCost = (Double)row[DCJUT04102AC.ct_Col_SalesUnitCost]; // 原価単価
            refData.SupplierSnm = (string)row[DCJUT04102AC.ct_Col_SupplierSnm]; // 仕入先略称
            refData.DtlNote = (string)row[DCJUT04102AC.ct_Col_DtlNote]; // 明細備考
            //refData.CustomerDeliveryDate = (DateTime)row[DCJUT04102AC.ct_Col_CustomerDeliveryDate]; // 客先納期
            refData.SlipMemo1 = (string)row[DCJUT04102AC.ct_Col_SlipMemo1]; // 伝票メモ１
            refData.SlipMemo2 = (string)row[DCJUT04102AC.ct_Col_SlipMemo2]; // 伝票メモ２
            refData.SlipMemo3 = (string)row[DCJUT04102AC.ct_Col_SlipMemo3]; // 伝票メモ３
            //refData.SlipMemo4 = (string)row[DCJUT04102AC.ct_Col_SlipMemo4]; // 伝票メモ４
            //refData.SlipMemo5 = (string)row[DCJUT04102AC.ct_Col_SlipMemo5]; // 伝票メモ５
            //refData.SlipMemo6 = (string)row[DCJUT04102AC.ct_Col_SlipMemo6]; // 伝票メモ６
            refData.InsideMemo1 = (string)row[DCJUT04102AC.ct_Col_InsideMemo1]; // 社内メモ１
            refData.InsideMemo2 = (string)row[DCJUT04102AC.ct_Col_InsideMemo2]; // 社内メモ２
            refData.InsideMemo3 = (string)row[DCJUT04102AC.ct_Col_InsideMemo3]; // 社内メモ３
            //refData.InsideMemo4 = (string)row[DCJUT04102AC.ct_Col_InsideMemo4]; // 社内メモ４
            //refData.InsideMemo5 = (string)row[DCJUT04102AC.ct_Col_InsideMemo5]; // 社内メモ５
            //refData.InsideMemo6 = (string)row[DCJUT04102AC.ct_Col_InsideMemo6]; // 社内メモ６
            //refData.SupplierFormal = (Int32)row[DCJUT04102AC.ct_Col_SupplierFormal]; // 仕入形式
            //refData.StockSlipDtlNum = (Int64)row[DCJUT04102AC.ct_Col_StockSlipDtlNum]; // 仕入明細通番
            //refData.OrderNumber = (string)row[DCJUT04102AC.ct_Col_OrderNumber]; // 発注番号
            //refData.ExpectDeliveryDate = (DateTime)row[DCJUT04102AC.ct_Col_ExpectDeliveryDate]; // 希望納期
            //refData.DeliGdsCmpltDueDate = (DateTime)row[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDate]; // 納品完了予定日
            //refData.ArrivalGoodsDay = (DateTime)row[DCJUT04102AC.ct_Col_ArrivalGoodsDay]; // 入荷日
            //refData.StockCount = (Double)row[DCJUT04102AC.ct_Col_StockCount]; // 仕入数
            //refData.StockUnitPriceFl = (Double)row[DCJUT04102AC.ct_Col_StockUnitPriceFl]; // 仕入単価（税抜，浮動）
            refData.RowNoView = (Int32)row[DCJUT04102AC.ct_Col_RowNoView]; // 行№
            refData.SelectRowFlag = (bool)row[DCJUT04102AC.ct_Col_SelectRowFlag]; // 行選択フラグ
            //refData.AcptAnOdrRemainPrice = (Int64)row[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice]; // 受注残金額
            refData.MemoExistsMark = (string)row[DCJUT04102AC.ct_Col_MemoExistsMark]; // メモマーク
            refData.MemoExistsFlag = (bool)row[DCJUT04102AC.ct_Col_MemoExistsFlag]; // メモ有フラグ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_SupplierCd].ToString()))
            {
                refData.SupplierCd = Int32.Parse(row[DCJUT04102AC.ct_Col_SupplierCd].ToString());                    // 仕入先コード
            }
            else
            {
                refData.SupplierCd = 0;
            }
            refData.WarehouseCode = (string)row[DCJUT04102AC.ct_Col_WarehouseCode];
            refData.WarehouseName = (string)row[DCJUT04102AC.ct_Col_WarehouseName];

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
            string salesSlipCdDtl = string.Empty;
            Int32 slipCd = 0;
            salesSlipCdDtl = (string)row[DCJUT04102AC.ct_Col_SalesSlipCdDtl];
            switch (salesSlipCdDtl)
            {
                case "売上": slipCd = 0; break;
                case "返品": slipCd = 1; break;
                case "値引": slipCd = 2; break;
                case "注釈": slipCd = 3; break;
                case "小計": slipCd = 4; break;
                case "作業": slipCd = 5; break;
            }
            refData.SalesSlipCdDtl = slipCd;

            if (row[DCJUT04102AC.ct_Col_SalesPriceConsTax] == DBNull.Value)
            {
                refData.SalesPriceConsTax = 0;
            }
            else
            {
                refData.SalesPriceConsTax = (Double)row[DCJUT04102AC.ct_Col_SalesPriceConsTax];//(long)row[DCJUT04102AC.ct_Col_SalesPriceConsTax];
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_BLGoodsCode].ToString()))
            {
                refData.BLGoodsCode = Int32.Parse(row[DCJUT04102AC.ct_Col_BLGoodsCode].ToString());
            }
            else
            {
                refData.BLGoodsCode = 0;
            }
            refData.ListPriceTaxExcFl = (Double)row[DCJUT04102AC.ct_Col_ListPriceTaxExc];
            refData.ShipmentCnt = (Double)row[DCJUT04102AC.ct_Col_ShipmentCnt];
            refData.CarMngCode = (string)row[DCJUT04102AC.ct_Col_CarMngCode];
            refData.ModelDesignationNo = (Int32)row[DCJUT04102AC.ct_Col_ModelDesignationNo];
            refData.CategoryNo = (Int32)row[DCJUT04102AC.ct_Col_CategoryNo];
            refData.ModelFullName = (string)row[DCJUT04102AC.ct_Col_ModelFullName];
            refData.SearchSlipDate = (DateTime)row[DCJUT04102AC.ct_Col_SearchSlipDate];
            refData.AddUpADate = (DateTime)row[DCJUT04102AC.ct_Col_AddUpADate];
            refData.SectionGuideNm = (string)row[DCJUT04102AC.ct_Col_SectionName];
            if (!String.IsNullOrEmpty(row[DCJUT04102AC.ct_Col_ClaimCode].ToString()))
            {
                refData.ClaimCode = Int32.Parse(row[DCJUT04102AC.ct_Col_ClaimCode].ToString());
            }
            else
            {
                refData.ClaimCode = 0;
            }
            refData.ClaimSnm = (string)row[DCJUT04102AC.ct_Col_ClaimSnm];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

            return refData;
        }

        #endregion

        #region ■Public Method

        # region ■ データビューの取得 ■
        /// <summary>
        /// データビュー取得（ＵＩ表示用）
        /// </summary>
        /// <returns></returns>
        public DataView GetDataViewForDisplay()
        {
            if ( _displayDataView == null )
            {
                // ビューを生成して返す
                _displayDataView = new DataView( this._acptAnOdrRemainRefTable );
            }
            return _displayDataView;
        }
        # endregion ■ データビューの取得 ■

        /// <summary>
        /// 照会選択データリスト取得処理
        /// </summary>
        /// <returns></returns>
        public List<AcptAnOdrRemainRefData> GetRefDataListOfSelected ()
        {
            // ビューを生成して、選択済みフラグでフィルタをかける
            DataView view = new DataView( this._acptAnOdrRemainRefTable );
            view.RowFilter = string.Format( "{0} = '{1}'", 
                                                DCJUT04102AC.ct_Col_SelectRowFlag, true );

            // 返却リストの生成
            List<AcptAnOdrRemainRefData> refDataList = new List<AcptAnOdrRemainRefData>();
            foreach ( DataRowView rowView in view )
            {
                refDataList.Add( CopyToRefDataFromRow( rowView.Row ) );
            }

            return refDataList;
        }

        # region ■ 行選択チェック編集 ■
        /// <summary>
        /// 行選択チェック処理（bool反転）
        /// </summary>
        /// <param name="rowNo"></param>
        public void SetRowSelected ( int rowNo )
        {
            // 行№で検索
            DataRow row = FindDataRowByPrimaryKey( rowNo );
            if ( row == null ) return;

            // チェック値bool反転セット
            row[DCJUT04102AC.ct_Col_SelectRowFlag] = !(bool)row[DCJUT04102AC.ct_Col_SelectRowFlag];

            // 選択データ変更イベント
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        /// <summary>
        /// 行選択チェック処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="rowSelected"></param>
        public void SetRowSelected ( int rowNo, bool rowSelected )
        {
            // 行№で検索
            DataRow row = FindDataRowByPrimaryKey( rowNo );
            if ( row == null ) return;

            // チェック値セット
            row[DCJUT04102AC.ct_Col_SelectRowFlag] = rowSelected;

            // 選択データ変更イベント
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        /// <summary>
        /// 全ての行の選択チェックをセット
        /// </summary>
        public void SetRowSelectedAll ( bool rowSelected )
        {
            // 全ての行の選択チェックを設定
            foreach ( DataRow row in this._acptAnOdrRemainRefTable.Rows )
            {
                row[DCJUT04102AC.ct_Col_SelectRowFlag] = rowSelected;
            }

            // 選択データ変更イベント
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        # endregion ■ 行選択チェック編集 ■

        # region ■ 集計値の取得処理 ■
        /// <summary>
        /// 選択済み行数取得処理
        /// </summary>
        public int GetRowCountOfSelected ()
        {
            // データビューを生成して、選択済みフラグでフィルタをかける
            DataView view = new DataView( this._acptAnOdrRemainRefTable );
            view.RowFilter = string.Format( "{0} = '{1}'", 
                                                DCJUT04102AC.ct_Col_SelectRowFlag, true );
            // 件数を返す
            return view.Count;
        }
        # endregion ■ 集計値の取得処理 ■

        /// <summary>
		/// 発注残照会 読込・データセット格納実行処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
		/// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        public int Search ( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn )
        {
            // 売上データ検索
            List<AcptAnOdrRemainRefDataWork> retData;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            _displayDataView.RowFilter = CreateRowFilter( acptAnOdrRemainRefCndtn );

            // リモートに渡す入荷状況は「０：全て」で固定にする。（UIで制御する為）
            //acptAnOdrRemainRefCndtn.ArrivalStateDiv = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            int status = this.SearchDB( out retData, acptAnOdrRemainRefCndtn );

            // テーブルクリア
            this.ClearTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データ展開処理
                DevListData( acptAnOdrRemainRefCndtn, retData );

                // No.列は1から間を開けずに表示されなければならない[9095]
                DataTable table = _displayDataView.ToTable();
                int rowCount = 1;
                foreach (DataRow row in table.Rows)
                {
                    int rowNo = (Int32)row[DCJUT04102AC.ct_Col_RowNoView];
                    DataRow[] orgRow = this._acptAnOdrRemainRefTable.Select("RowNoView = " + rowNo.ToString());
                    orgRow[0][DCJUT04102AC.ct_Col_RowNoDisplay] = rowCount;
                    rowCount++;
                }
                // [9095] end

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // 行フィルタによりデータなしになった場合
                    if (_displayDataView.Count <= 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                if (this.StatusBarMessageSetting != null)
                {
                    this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                }
            }
            return status;
        }

        /// <summary>
        /// 行フィルタ文字列生成
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn"></param>
        /// <returns></returns>
        private string CreateRowFilter( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn )
        {
            string filterText = string.Empty;

            //-----------------------------------------------------------
            // 受注残数 > 0 のみを対象とする
            //-----------------------------------------------------------

            // 受注ステータスによってフィルタを変化させる(設計者指示)
            // 2008.12.12 add start [9095]
            switch ( acptAnOdrRemainRefCndtn.AcpOdrStateDiv )
            {
                // 計上済み分1
                case 1:
                    {
                        filterText = filterText = string.Format("{0} = 0", DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt);
                        break;
                    }
                // 未計上分
                case 2:
                    {
                        filterText = string.Format("{0} > 0", DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt);
                        break;
                    }
                // 全て
                default:
                    {
                        // 全て
                        filterText = string.Empty;
                        break;
                    }
            }
            // 2008.12.12 add end [9095]
            

            //-----------------------------------------------------------
            // 入荷状況
            //-----------------------------------------------------------
            //switch ( acptAnOdrRemainRefCndtn.ArrivalStateDiv )
            //{
                // 入荷済み
                //case 1:
                //    {
                //        if ( !string.IsNullOrEmpty( filterText ) )
                //        {
                //            filterText += " AND ";
                //        }
                //        // 発注番号なし　or　入荷日セット済み
                //        filterText += string.Format( "{0} = '{1}' OR {2} <> '{3}'",
                //                                      DCJUT04102AC.ct_Col_OrderNumber, string.Empty,
                //                                      DCJUT04102AC.ct_Col_ArrivalGoodsDayView, string.Empty );
                //    }
                //    break;
                //// 未入荷のみ
                //case 2:
                //    {
                //        if ( !string.IsNullOrEmpty( filterText ) )
                //        {
                //            filterText += " AND ";
                //        }
                //        // 発注番号あり　and　入荷日未セット
                //        filterText += string.Format( "{0} <> '{1}' AND {2} = '{3}'",
                //                                      DCJUT04102AC.ct_Col_OrderNumber, string.Empty,
                //                                      DCJUT04102AC.ct_Col_ArrivalGoodsDayView, string.Empty );
                //    }
                //    break;
                // 全て
                //default:
                //    {
                //        //// 全て
                //        //filterText = string.Empty;
                //    }
                //    break;
            //}

            return filterText;
        }
        /// <summary>
        /// データ展開処理（リモートResultWork　→　DataTable）
        /// </summary>
        /// <param name="acptAnOdrRemainRefCndtn"></param>
        /// <param name="retData"></param>
        private void DevListData ( AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn, List<AcptAnOdrRemainRefDataWork> retData )
        {
            // 受注伝票ディクショナリ（重複チェック用）<CommonSeqNo,RowIndex>
            Dictionary<Int64, int> salesSlipDic = new Dictionary<Int64, int>();

            // テーブル格納済みindex
            int index = 0;

            // 伝票番号(仕入SEQ/支払No)保存
            //string exSalesSlipNum = string.Empty;

            // リモートResultWorkから抽出
            foreach ( AcptAnOdrRemainRefDataWork refDataWork in retData )
            {
                Int64 seqNo = refDataWork.CommonSeqNo;
                //exSalesSlipNum = refDataWork.SalesSlipNum;

                if ( salesSlipDic.ContainsKey( seqNo ) )
                {
                    // データが存在→更新
                    UpdateRowFromResultWork(salesSlipDic[seqNo], refDataWork);//, exSalesSlipNum);
                }
                else
                {
                    // データが非存在→追加
                    AddDataRowFromResultWork(index, refDataWork);//, exSalesSlipNum);
                    salesSlipDic.Add( seqNo, index );

                    index++;
                }
            }
        }

        /// <summary>
        /// データセットクリア処理
        /// </summary>
        public void ClearTable()
        {
            // テーブルクリア
            this._acptAnOdrRemainRefTable.Rows.Clear();

            // 選択データ変更イベント
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }
        /// <summary>
        /// 抽出条件コピー処理（ＵＩ条件クラス→リモート条件クラス（売上））
        /// </summary>
        /// <param name="cndtn"></param>
        /// <returns></returns>
        private AcptAnOdrRemainRefCndtnWork CopyToSalesCndtnWorkFromCndtn ( AcptAnOdrRemainRefCndtn cndtn )
        {
            AcptAnOdrRemainRefCndtnWork cndtnWork = new AcptAnOdrRemainRefCndtnWork();
            
            cndtnWork.EnterpriseCode = cndtn.EnterpriseCode; // 企業コード
            cndtnWork.SectionCode = cndtn.SectionCode; // 拠点コード
            //cndtnWork.SubSectionCode = cndtn.SubSectionCode; // 部門コード
            //cndtnWork.MinSectionCode = cndtn.MinSectionCode; // 課コード
            cndtnWork.CustomerCode = cndtn.CustomerCode; // 得意先コード
            cndtnWork.SalesInputCode = cndtn.SalesInputCode; // 売上入力者コード
            cndtnWork.FrontEmployeeCd = cndtn.FrontEmployeeCd; // 受付従業員コード
            cndtnWork.SalesEmployeeCd = cndtn.SalesEmployeeCd; // 販売従業員コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA MODIFY START
            cndtnWork.ClaimCode = cndtn.ClaimCode;  // 請求先コード
            cndtnWork.GoodsNameSrchTyp = cndtn.GoodsNmVagueSrch; // 曖昧検索フラグ
            //if (cndtn.GoodsNmVagueSrch > 0)
            //{
            //    cndtnWork.GoodsNmVagueSrch = true;
            //}
            //else
            //{
            //    cndtnWork.GoodsNmVagueSrch = false;
            //}
            cndtnWork.St_SalesSlipNum = cndtn.St_SalesSlipNum; // 伝票番号（開始）
            cndtnWork.Ed_SalesSlipNum = cndtn.Ed_SalesSlipNum; // 伝票番号（終了）
            cndtnWork.AcpOdrStateDiv = cndtn.AcpOdrStateDiv; // 受注状況フラグ
            cndtnWork.FullModel = cndtn.FullModel; // 絞込型式
            cndtnWork.St_SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.St_SalesDate); // 売上日付(開始)
            cndtnWork.Ed_SalesDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.Ed_SalesDate); // 売上日付(終了)
            //cndtnWork.St_SearchSlipDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.St_SearchSlipDate); // 伝票検索(開始)
            //cndtnWork.Ed_SearchSlipDate = TDateTime.LongDateToDateTime("yyyymmdd", cndtn.Ed_SearchSlipDate); // 伝票検索(終了)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA MODIFY END
            cndtnWork.GoodsMakerCd = cndtn.GoodsMakerCd; // 商品メーカーコード
            cndtnWork.GoodsNo = cndtn.GoodsNo; // 商品番号
            // 2008.10.14 add start
            cndtnWork.GoodsNoSrchTyp = cndtn.GoodsNoSrchTyp;
            // 2008.10.14 add end
            cndtnWork.GoodsName = cndtn.GoodsName; // 商品名称
            //cndtnWork.PartySlipNumDtl = cndtn.PartySlipNumDtl; // 相手先伝票番号(明細)
            //cndtnWork.St_DeliGdsCmpltDueDate = cndtn.St_DeliGdsCmpltDueDate; // 納品完了予定日(開始)
            //cndtnWork.Ed_DeliGdsCmpltDueDate = cndtn.Ed_DeliGdsCmpltDueDate; // 納品完了予定日(終了)
            //cndtnWork.ArrivalStateDiv = cndtn.ArrivalStateDiv; // 入荷状況区分
            //cndtnWork.St_ArrivalDate = cndtn.St_ArrivalDate; // 入荷日(開始)
            //cndtnWork.Ed_ArrivalDate = cndtn.Ed_ArrivalDate; // 入荷日(終了)
            // 2008.12.12 add start [9101]
            cndtnWork.FullModelSrchTyp = cndtn.FullModelSrchTyp;
            // 2008.12.12 add end [9101]

            // --- ADD 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            cndtnWork.St_SearchSlipDate = TDateTime.LongDateToDateTime(cndtn.St_SearchSlipDate);
            cndtnWork.Ed_SearchSlipDate = TDateTime.LongDateToDateTime(cndtn.Ed_SearchSlipDate);
            // --- ADD 2009/02/25 障害ID:7882対応------------------------------------------------------<<<<<

            return cndtnWork;
        }
        
        /// <summary>
        /// 売上データ情報 読み込み処理
        /// </summary>
        /// <param name="acptAnOdrRemainRefDataWorkList">仕入データ オブジェクト配列</param>
        /// <param name="acptAnOdrRemainRefCndtn">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
		/// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int SearchDB(out List<AcptAnOdrRemainRefDataWork> acptAnOdrRemainRefDataWorkList, AcptAnOdrRemainRefCndtn acptAnOdrRemainRefCndtn)
        {
            try
            {
                int status;
                acptAnOdrRemainRefDataWorkList = new List<AcptAnOdrRemainRefDataWork>();

                // オンラインの場合リモート取得
                // -- DEL 2010/05/25 ----------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 -----------------<<<
                    ArrayList retList = new CustomSerializeArrayList();

                    object paraObj = (object)CopyToSalesCndtnWorkFromCndtn(acptAnOdrRemainRefCndtn);
                    object retObj = (object)retList;

                    //伝票情報取得
                    status = this._iAcptAnOdrRemainRefDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 返却リストに格納
                        foreach (AcptAnOdrRemainRefDataWork acptAnOdrRemainRefDataForSalesWork in (CustomSerializeArrayList)retObj)
						{
							acptAnOdrRemainRefDataWorkList.Add(acptAnOdrRemainRefDataForSalesWork);
						}

                        // 格納できなければステータスを書き換える
                        if ( acptAnOdrRemainRefDataWorkList.Count == 0 )
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                    else
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_ErrResult);
                        }
                    }
                // -- DEL 2010/05/25 ------------------------>>>
                //}
                //else	// オフラインの場合
                //{
                //    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                //    status = -1;
                //}
                // -- DEL 2010/05/25 ------------------------<<<

                // 選択データ変更イベント
                if ( this.SelectedDataChange != null )
                {
                    this.SelectedDataChange( this, new EventArgs() );
                }

                return status;
            }
            catch (Exception)
            {
                if ( this.StatusBarMessageSetting != null )
                {
                    this.StatusBarMessageSetting( this, MESSAGE_ErrResult );
                }

                acptAnOdrRemainRefDataWorkList = null;
                //オフライン時はnullをセット
                this._iAcptAnOdrRemainRefDB= null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

		/// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;

            int status = employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return employee.Name.Trim();
            }
            else
            {
                return "";
            }
        }

		/// <summary>
		/// メーカー名称取得処理
		/// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>メーカー名称</returns>
		public string GetName_FromGoodsMaker(int goodsMakerCd)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;

			int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				return makerUMnt.MakerName.Trim();
			}
			else
			{
				return "";
			}
		}

		/// <summary>
        /// 商品名称取得処理
        /// </summary>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsName">(出力)商品名称</param>
        /// <returns>true:存在あり、false:存在しない</returns>
		public bool CheckGoodsExist(string goodsCode, out string goodsName)
        {
            List<GoodsUnitData> goodsUnitDataList;
            GoodsAcs goodsAcs = new GoodsAcs();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.20 TOKUNAGA ADD START
            string msg;
            int s = goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out msg);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.20 TOKUNAGA ADD END
            
			goodsName = "";

            // 商品コードのみの指定で
            GoodsCndtn cnd = new GoodsCndtn();
            cnd.EnterpriseCode = this._enterpriseCode;
            cnd.SectionCode = this._sectionCode;
            cnd.GoodsNo = goodsCode;
            if (this._makerCode != 0)
            {
                cnd.GoodsMakerCd = this._makerCode;
            }

            //int status = goodsAcs.Search(cnd, out goodsUnitDataList, out msg);
            //int status = goodsAcs.Read(this._enterpriseCode, this._sectionCode, goodsCode, out goodsUnitDataList);
            //int status = goodsAcs.SearchPartsFromGoodsNoForMst(cnd, out goodsUnitDataList, out msg);
            int status = goodsAcs.Search(cnd, out goodsUnitDataList, out msg);

            if( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList.Count != 0) )
            {
				goodsName = goodsUnitDataList[0].GoodsName;
                return true;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 本社機能／拠点機能チェック処理
        /// </summary>
        /// <returns>true:本社機能 false:拠点機能</returns>
        public bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // ログイン担当拠点情報の取得
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // 本社機能か？
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }
            else
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }

		/// <summary>
		/// 日付文字列を取得します。
		/// </summary>
		/// <param name="date">日付</param>
		/// <param name="format">フォーマット文字列</param>
		/// <returns>日付文字列</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
        }

        # region ■ 指定行取得 ■
        /// <summary>
        /// 行取得処理
        /// </summary>
        /// <param name="rowNo"></param>
        public void GetRow( int rowNo )
        {
            // 行№で検索
            DataRow row = FindDataRowByPrimaryKey( rowNo );
            if ( row == null )
                return;

            // チェック値bool反転セット
            row[DCJUT04102AC.ct_Col_SelectRowFlag] = !(bool)row[DCJUT04102AC.ct_Col_SelectRowFlag];

            // 選択データ変更イベント
            if ( this.SelectedDataChange != null )
            {
                this.SelectedDataChange( this, new EventArgs() );
            }
        }

        # endregion ■  ■

        # endregion

        # region ■ public enum ■
        /// <summary>
        /// 仕入形式　列挙型
        /// </summary>
        public enum SupplierFormalState
        {
            /// <summary>仕入</summary>
            Stock = 0,
            /// <summary>入荷</summary>
            Arrival = 1,
            /// <summary>発注</summary>
            Order = 2,
        }
        # endregion ■ public enum ■

    }
}
