//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入返品予定一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品予定一覧表にアクセスするクラスです</br>
    /// <br>Programer  : FSI高橋 文彰</br>
    /// <br>Date       :  2013/01/28</br>
    /// </remarks>
    public class PMKAK02032A
    {
        // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
        #region public constant
        /// <summary>全拠点レコード用拠点コード</summary>
        public const string CT_AllSectionCode = "000000";
        #endregion

        // ===================================================================================== //
        //  スタティック変数
        // ===================================================================================== //
        #region static variable
        /// <summary>自拠点コード</summary>
        private static string mySectionCode = "";
        /// <summary>帳票出力設定データクラス</summary>
        private static PrtOutSet prtOutSetData = null;
        #endregion

        // ===================================================================================== //
        //  内部使用変数
        // ===================================================================================== //
        #region private member
        /// <summary>拠点情報アクセスクラス</summary>
        private static SecInfoAcs _secInfoAcs;
        /// <summary>帳票出力設定アクセスクラス</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>印刷用DataSet</summary>
        public DataSet _printDataSet;
        /// <summary>バッファDataSet</summary>
        public static DataSet _printBuffDataSet;
        /// <summary>仕入返品予定一覧表データテーブル名</summary>
        private string _Tbl_ShipmentDtl;
        // 帳票タイトル
        private string ListTitle = "仕入返品予定一覧表";
        //抽出条件クラス
		private ExtrInfo_PMKAK02034E _extrInfo_PMKAK02034E;

        #endregion

        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        ///// <summary>仕入返品予定一覧表バッファデータテーブル名</summary>
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター

        /// <summary>
        /// 仕入返品予定一覧表アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02032A()
        {
            this.SettingDataTable();

            // 印刷用DataSet
            this._printDataSet = new DataSet();
            DataSetColumnConstruction(ref this._printDataSet);
            // バッファテーブルデータセット
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // 拠点情報取得
            this.CreateSecInfoAcs();
        }

        #endregion

        // ===================================================================================== //
        // 静的コンストラクタ
        // ===================================================================================== //
        #region 静的コンストラクター

        /// <summary>
        /// 仕入返品予定一覧表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        static PMKAK02032A()
        {
            // 帳票出力設定アクセスクラスインスタンス化
            prtOutSetAcs = new PrtOutSetAcs();

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                mySectionCode = loginEmployee.BelongSectionCode;
            }
        }

        #endregion

        // ===================================================================================== //
        // 外部提供関数
        // ===================================================================================== //
        #region public method

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="prtOutSet">帳票出力設定データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // データは読込済みか？
                if (prtOutSetData != null)
                {
                    prtOutSet = prtOutSetData.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = prtOutSetData.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "帳票出力設定の読込に失敗しました。";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// 仕入返品予定一覧表データ初期化処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Static情報を初期化します。</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --テーブル行初期化-----------------------
            // 抽出結果データテーブルをクリア
            if (this._printDataSet.Tables[_Tbl_ShipmentDtl] != null)
            {
                this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();
            }
            // 抽出結果バッファデータテーブルをクリア
            if (_printBuffDataSet.Tables[_Tbl_ShipmentDtl] != null)
            {
                _printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();
            }
        }

        /// <summary>
        /// 仕入返品予定一覧表データ取得処理
        /// </summary>
        /// <param name="extrInfo_PMKAK02034E"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
		public int Search(ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(extrInfo_PMKAK02034E, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(extrInfo_PMKAK02034E, out message);
                        }
                        break;
                    }
                case 2:
                    {
                        // static only の場合はリモーティングに行かない
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 仕入返品予定一覧表スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();

            if (_printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();
                        buffDr = _printBuffDataSet.Tables[_Tbl_ShipmentDtl].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

        /// <summary>
        /// 仕入返品予定一覧表データ取得処理
        /// </summary>
        /// <param name="extrInfo_PMKAK02034E"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の仕入返品予定一覧表データを取得します。</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
		private int Search(ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";

            try
            {
                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
				StockRetPlnParamWork StockRetPlnList = new StockRetPlnParamWork();

                // 抽出条件パラメータセット
                this.SearchParaSet(extrInfo_PMKAK02034E, ref StockRetPlnList);

                status = this.SearchByMode(out retObj, StockRetPlnList);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;
                
                if ((status == 0) && (retList.Count != 0))
                {
                    // 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        SetTebleRowFromRetList(retList, i);

                    }
                    
                    // データセットのコミット
                    this._printDataSet.AcceptChanges();

                    if (this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        // バッファテーブルへの格納
                        _printBuffDataSet = this._printDataSet.Copy();

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
                else
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;


        }
        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 検索パラメータ設定処理
        /// </summary>
        /// <param name="extrInfo_PMKAK02034E">検索パラメータ</param>
        /// <param name="StockRetPlnList">取得パラメータ</param>
        /// <remarks>
        /// <br>Note       : 検索パラメータの設定を行います。 </br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
		private void SearchParaSet(ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E, ref StockRetPlnParamWork StockRetPlnList)
        {
            #region < 企業コード >
            StockRetPlnList.EnterpriseCode = extrInfo_PMKAK02034E.EnterpriseCode;                 // 企業コード
            #endregion

            #region < 拠点 >

			if (extrInfo_PMKAK02034E.SectionCodes.Length != 0)
			{
				if (extrInfo_PMKAK02034E.SectionCodes[0] == "0")
				{
					// 全社の時
					StockRetPlnList.SectionCodes = new string[0];                                 // 拠点コード
				}
				else
				{
					StockRetPlnList.SectionCodes = extrInfo_PMKAK02034E.SectionCodes;             // 拠点コード
				}
			}
			else
			{
				StockRetPlnList.SectionCodes = new string[0];                                     // 拠点コード
			}
			#endregion

            #region < 画面設定条件 >
 
            StockRetPlnList.SupplierCdSt      = extrInfo_PMKAK02034E.SupplierCdSt;                // 開始仕入先コード
            StockRetPlnList.SupplierCdEd      = extrInfo_PMKAK02034E.SupplierCdEd;                // 終了仕入先コード
			StockRetPlnList.InputDaySt		   = extrInfo_PMKAK02034E.InputDaySt;				  // 開始入力日
			StockRetPlnList.InputDayEd		   = extrInfo_PMKAK02034E.InputDayEd;			      // 終了入力日
			StockRetPlnList.MakeShowDiv	   = extrInfo_PMKAK02034E.MakeShowDiv;                    // 発行タイプ
			StockRetPlnList.SlipDiv		   = extrInfo_PMKAK02034E.SlipDiv;                        // 出力指定
            StockRetPlnList.PrintDailyFooter  = extrInfo_PMKAK02034E.PrintDailyFooter;            // 日付指定
			
			#endregion
        }
        
        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.PMKAK02035EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// モード毎のSearch呼出処理
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="StockRetPlnList">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
		private int SearchByMode(out object retObj, StockRetPlnParamWork StockRetPlnList)
        {
            int status = 0;
            retObj = null;

            IStockRetPlnTableDB _iStockRetListDB = (IStockRetPlnTableDB)MediationStockRetPlnTableDB.GetStockRetPlnTableDB();

            status = _iStockRetListDB.Search(out retObj, StockRetPlnList);

            return status;
        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
			this._Tbl_ShipmentDtl = Broadleaf.Application.UIData.PMKAK02035EA.ct_Tbl_StockRetDtl;
        }

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        private void SetTebleRowFromRetList(ArrayList retList, int setCnt)
        {
			_extrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();
            DataRow dr;
            dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();
            // 明細単位
			StockRetPlnList StockRetPlnList = (StockRetPlnList)retList[setCnt];
            // 拠点コード
            dr[PMKAK02035EA.ct_Col_SectionCode]         = StockRetPlnList.SectionCode;
            // 拠点ガイド名称
            dr[PMKAK02035EA.ct_Col_SectionGuideNm]      = StockRetPlnList.SectionGuideNm;	
            // 入力日付
			dr[PMKAK02035EA.ct_Col_InputDay]			= StockRetPlnList.InputDay;	
            // 仕入日付
			dr[PMKAK02035EA.ct_Col_StockDate]			= StockRetPlnList.StockDate; 
            // 仕入先コード
            dr[PMKAK02035EA.ct_Col_SupplierCd]          = StockRetPlnList.SupplierCd; 
            // 仕入先略称
            dr[PMKAK02035EA.ct_Col_SupplierSnm]         = StockRetPlnList.SupplierSnm;   
            // 商品メーカーコード
            dr[PMKAK02035EA.ct_Col_GoodsMakerCd]        = StockRetPlnList.GoodsMakerCd;  
            // 商品名称
            dr[PMKAK02035EA.ct_Col_MakerName]           = StockRetPlnList.MakerName; 
            // 商品番号
            dr[PMKAK02035EA.ct_Col_GoodsNo]             = StockRetPlnList.GoodsNo;               
            // 仕入数
            dr[PMKAK02035EA.ct_Col_StockCount]          = StockRetPlnList.StockCount;
            // 税抜仕入単価
            dr[PMKAK02035EA.ct_Col_StockUnitPriceFl] = StockRetPlnList.StockUnitPriceFl;
            // 税込仕入単価
            dr[PMKAK02035EA.ct_Col_StockUnitTaxPriceFl] = StockRetPlnList.StockUnitTaxPriceFl;
            // 税抜明細仕入金額
            dr[PMKAK02035EA.ct_Col_StockPriceTaxExc] = StockRetPlnList.StockPriceTaxExc;
            // 税込明細仕入金額
            dr[PMKAK02035EA.ct_Col_StockPriceTaxInc] = StockRetPlnList.StockPriceTaxInc;
            // 税抜伝票金額
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxExc] = StockRetPlnList.StockTtlPricTaxExc;
            // 税込伝票金額
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxInc] = StockRetPlnList.StockTtlPricTaxInc;
            // 伝票消費税
            dr[PMKAK02035EA.ct_Col_SlpConsTax] = StockRetPlnList.SlpConsTax;
            // 明細消費税
            dr[PMKAK02035EA.ct_Col_DtlConsTax] = StockRetPlnList.DtlConsTax;
            // 税抜定価
            dr[PMKAK02035EA.ct_Col_ListPriceTaxExc] = StockRetPlnList.ListPriceTaxExc;
            // 税込定価
            dr[PMKAK02035EA.ct_Col_ListPriceTaxInc] = StockRetPlnList.ListPriceTaxInc;
            // 課税区分
            dr[PMKAK02035EA.ct_Col_TaxationCode] = StockRetPlnList.TaxationCode;
            // 消費税転嫁区分
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = StockRetPlnList.SuppCTaxLayCd;
            // 仕入伝票備考1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = StockRetPlnList.SupplierSlipNote1;
            // 仕入先消費税転嫁方式コード
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = StockRetPlnList.SuppCTaxLayCd;
            // BL商品コード
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = StockRetPlnList.BLGoodsCode;
            // BL商品コード名称
            dr[PMKAK02035EA.ct_Col_GoodsName] = StockRetPlnList.GoodsName;
            // 帳票タイトル
            dr[PMKAK02035EA.ct_Col_ListTitle] = this.ListTitle;                      
            // 仕入伝票備考1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = StockRetPlnList.SupplierSlipNote1;
            // 仕入先消費税転嫁方式コード
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = StockRetPlnList.SuppCTaxLayCd; 
            // BL商品コード
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = StockRetPlnList.BLGoodsCode; 
            
            // 伝票区分
            switch (StockRetPlnList.SupplierSlipCd)
			{
				case 10: // 仕入

                    dr[PMKAK02035EA.ct_Col_SupplierSlipCd] = "仕入";

					break;

				case 20: // 返品

                    dr[PMKAK02035EA.ct_Col_SupplierSlipCd] = "返品";
					
					break;
			}


            // 出力指定(返品予定or返品済の明細ステータス印字用）
            // 返品済の論理削除(通常データとして印字）：仕入データ論理削除:1、仕入明細データ論理削除:1、仕入明細通番:0
            if (StockRetPlnList.SlpLogDelCd == 1 && StockRetPlnList.DtlLogDelCd == 1 && StockRetPlnList.SalesSlipDtlNum == 0)

                    dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "返品済";

            // 仕入予定の削除データ
            else if (StockRetPlnList.SlpLogDelCd == 1 && StockRetPlnList.DtlLogDelCd == 1 && StockRetPlnList.SalesSlipDtlNum > 0)

                    dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "返品予定";

            else
            {
                switch (StockRetPlnList.DtlLogDelCd)
                {
                    case 0: // 返品予定

                        dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "返品予定";

                        break;

                    case 1: // 返品済

                        dr[PMKAK02035EA.ct_Col_ReturnedGoodsType] = "返品済";

                        break;
                }
            }

            // 仕入伝票番号の0埋め
            string padCustomerCode = StockRetPlnList.SupplierSlipNo.ToString("d09");
            dr[PMKAK02035EA.ct_Col_SupplierSlipNo] = padCustomerCode;	

			this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
        }


       
        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            // 拠点コード
            dr[PMKAK02035EA.ct_Col_SectionCode] = sourceDataRow[PMKAK02035EA.ct_Col_SectionCode];  
            // 拠点ガイド名称
            dr[PMKAK02035EA.ct_Col_SectionGuideNm] = sourceDataRow[PMKAK02035EA.ct_Col_SectionGuideNm];  
            // 仕入伝票番号
            dr[PMKAK02035EA.ct_Col_SupplierSlipNo] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSlipNo];  
            // 入力日付
            dr[PMKAK02035EA.ct_Col_InputDay] = sourceDataRow[PMKAK02035EA.ct_Col_InputDay];  
            // 仕入日付
            dr[PMKAK02035EA.ct_Col_StockDate] = sourceDataRow[PMKAK02035EA.ct_Col_StockDate];  
            // 仕入先コード
            dr[PMKAK02035EA.ct_Col_SupplierCd] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierCd];  
            // 仕入先略称
            dr[PMKAK02035EA.ct_Col_SupplierSnm] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSnm];  
            // 商品メーカーコード
            dr[PMKAK02035EA.ct_Col_GoodsMakerCd] = sourceDataRow[PMKAK02035EA.ct_Col_GoodsMakerCd];  
            // 商品名称
            dr[PMKAK02035EA.ct_Col_MakerName] = sourceDataRow[PMKAK02035EA.ct_Col_MakerName];  
            // 商品番号
            dr[PMKAK02035EA.ct_Col_GoodsNo] = sourceDataRow[PMKAK02035EA.ct_Col_GoodsNo];  
            // 仕入数
            dr[PMKAK02035EA.ct_Col_StockCount] = sourceDataRow[PMKAK02035EA.ct_Col_StockCount];  
            // 税抜仕入単価
            dr[PMKAK02035EA.ct_Col_StockUnitPriceFl] = sourceDataRow[PMKAK02035EA.ct_Col_StockUnitPriceFl];  
            // 税込仕入単価
            dr[PMKAK02035EA.ct_Col_StockUnitTaxPriceFl] = sourceDataRow[PMKAK02035EA.ct_Col_StockUnitTaxPriceFl];  
            // 税抜明細仕入金額
            dr[PMKAK02035EA.ct_Col_StockPriceTaxExc] = sourceDataRow[PMKAK02035EA.ct_Col_StockPriceTaxExc];  
            // 税込明細仕入金額
            dr[PMKAK02035EA.ct_Col_StockPriceTaxInc] = sourceDataRow[PMKAK02035EA.ct_Col_StockPriceTaxInc];  
            //税抜伝票金額
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxExc] = sourceDataRow[PMKAK02035EA.ct_Col_StockTtlPricTaxExc];  
            //税込伝票金額
            dr[PMKAK02035EA.ct_Col_StockTtlPricTaxInc] = sourceDataRow[PMKAK02035EA.ct_Col_StockTtlPricTaxInc];  
            //伝票消費税
            dr[PMKAK02035EA.ct_Col_SlpConsTax] = sourceDataRow[PMKAK02035EA.ct_Col_SlpConsTax];  
            //明細消費税
            dr[PMKAK02035EA.ct_Col_DtlConsTax] = sourceDataRow[PMKAK02035EA.ct_Col_DtlConsTax];  
            //税抜定価
            dr[PMKAK02035EA.ct_Col_ListPriceTaxExc] = sourceDataRow[PMKAK02035EA.ct_Col_ListPriceTaxExc];  
            //税込定価
            dr[PMKAK02035EA.ct_Col_ListPriceTaxInc] = sourceDataRow[PMKAK02035EA.ct_Col_ListPriceTaxInc];  
            //課税区分
            dr[PMKAK02035EA.ct_Col_TaxationCode] = sourceDataRow[PMKAK02035EA.ct_Col_TaxationCode];  
            //消費税転嫁区分
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = sourceDataRow[PMKAK02035EA.ct_Col_SuppCTaxLayCd];  
            // 仕入伝票備考1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSlipNote1];  
            // 仕入先消費税転嫁方式コード
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = sourceDataRow[PMKAK02035EA.ct_Col_SuppCTaxLayCd];  
            // BL商品コード
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = sourceDataRow[PMKAK02035EA.ct_Col_BLGoodsCode];  
            // 帳票タイトル
            dr[PMKAK02035EA.ct_Col_ListTitle] = sourceDataRow[PMKAK02035EA.ct_Col_ListTitle];  
            // 仕入伝票備考1
            dr[PMKAK02035EA.ct_Col_SupplierSlipNote1] = sourceDataRow[PMKAK02035EA.ct_Col_SupplierSlipNote1];  
            // 仕入先消費税転嫁方式コード
            dr[PMKAK02035EA.ct_Col_SuppCTaxLayCd] = sourceDataRow[PMKAK02035EA.ct_Col_SuppCTaxLayCd];  
            // BL商品コード
            dr[PMKAK02035EA.ct_Col_BLGoodsCode] = sourceDataRow[PMKAK02035EA.ct_Col_BLGoodsCode];  
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
        #endregion
    }
}
