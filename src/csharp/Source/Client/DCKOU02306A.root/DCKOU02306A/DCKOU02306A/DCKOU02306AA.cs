//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入荷一覧表
// プログラム概要   : 入荷一覧表アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢　貞義
// 作 成 日  2007/10/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/26  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応9803、11150、11153、12398
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
    /// 入荷一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷一覧表にアクセスするクラスです</br>
    /// <br>Programer  : 980035　金沢　貞義</br>
    /// <br>Date       : 2007.10.19</br>
    /// <br>Update     : 2008/09/26 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Update     : 2009/04/08 上野 俊治　障害対応9803、11150、11153、12398</br>
    /// </remarks>
    public class DCKOU02306A
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

        /// <summary>入荷一覧表データテーブル名</summary>
        private string _Tbl_ShipmentDtl;

        /// <summary>表示順位</summary>
		//private string CT_Sort1_Odr = "CustomerCode, ArrivalGoodsDay";                  // 得意先→入荷日付
		//private string CT_Sort2_Odr = "StockAgentCode, CustomerCode, ArrivalGoodsDay"; // 担当者→得意先→入荷日付

		private string CT_Sort1_Odr = "SectionCode, CustomerCode, ArrivalGoodsDay, SupplierSlipNo";					//仕入先→入荷日→伝票番号
		private string CT_Sort2_Odr = "SectionCode, ArrivalGoodsDay, CustomerCode, SupplierSlipNo";					//入荷日→仕入先→伝票番号
		private string CT_Sort3_Odr = "SectionCode, StockAgentCode, CustomerCode, ArrivalGoodsDay, SupplierSlipNo";	//担当者→仕入先→入荷日→伝票番号
		private string CT_Sort4_Odr = "SectionCode, ArrivalGoodsDay, SupplierSlipNo";								//入荷日→伝票番号
		private string CT_Sort5_Odr = "SectionCode, SupplierSlipNo";												//伝票番号

        private string CT_UpperOrder = " ASC";		// 昇順出力
        //private string CT_DownOrder  = " DESC";	// 降順出力

        //private string ListTitle = "入荷一覧表";    // 帳票タイトル  // DEL 2008/06/25
        private string ListTitle = "入荷確認表";    // 帳票タイトル  // ADD 2008/06/25

		private ExtrInfo_DCKOU02304E _extrInfo_DCKOU02304E;	//抽出条件クラス

		// 伝票行数を数える変数
        //private int slipRowNo = 0;  // DEL 2008/06/25

        #endregion

        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        ///// <summary>入荷一覧表バッファデータテーブル名</summary>
        //public const string CT_SalesOrderBuffDataTable = Broadleaf.Application.UIData.DCKOU02305EA.CT_SalesOrderAgentBuffDataTable;
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター

        /// <summary>
        /// 入荷一覧表アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public DCKOU02306A()
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
        /// 入荷一覧表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static DCKOU02306A()
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
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
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
        /// 入荷一覧表データ初期化処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Static情報を初期化します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
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
        /// 入荷一覧表データ取得処理
        /// </summary>
        /// <param name="extrInfo_DCKOU02304E"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
        /// <returns></returns>
		public int Search(ExtrInfo_DCKOU02304E extrInfo_DCKOU02304E, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(extrInfo_DCKOU02304E, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(extrInfo_DCKOU02304E, out message);
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
        /// 入荷一覧表スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
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
        /// 入荷一覧表データ取得処理
        /// </summary>
        /// <param name="extrInfo_DCKOU02304E"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の入荷一覧表データを取得します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
		private int Search(ExtrInfo_DCKOU02304E extrInfo_DCKOU02304E, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";

            try
            {
                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
				ArrivalListParamWork arrivalListParamWork = new ArrivalListParamWork();

                // 抽出条件パラメータセット
                this.SearchParaSet(extrInfo_DCKOU02304E, ref arrivalListParamWork);

                status = this.SearchByMode(out retObj, arrivalListParamWork);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;
                
                if ((status == 0) && (retList.Count != 0))
                {
                    // 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        //DataRow dr;
                        //dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();

                        //SetTebleRowFromRetList(ref dr, retList, i);
                        SetTebleRowFromRetList(retList, i);

                        //this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
                    }

                    // 2009.02.13 30413 犬飼 発行タイプによるフィルタ処理追加 >>>>>>START
                    // 発行タイプ「入荷計上」の場合、未計上数によるフィルタ処理
                    if (extrInfo_DCKOU02304E.MakeShowDiv == 1)
                    {
                        FilterByAcptAnOdrRemainCnt();
                    }
                    
                    // データセットのコミット
                    this._printDataSet.AcceptChanges();

                    // バッファテーブルへの格納
                    //_printBuffDataSet = this._printDataSet.Copy();

                    //status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    // 2009.02.13 30413 犬飼 発行タイプによるフィルタ処理追加 <<<<<<END
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

            #region ************* 仮データ ***************
            //int intWork;

            //for (int i = 1; i < 5; i++)
            //{
            //    for (int j = 1; j < 10; j++)
            //    {
            //        DataRow dr;
            //        dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();

            //        dr[DCKOU02305EA.ct_Col_SectionCode] = i.ToString();                      // 拠点コード
            //        dr[DCKOU02305EA.ct_Col_SectionGuideNm] = "テスト拠点" + i.ToString();    // 拠点ガイド名称
            //        dr[DCKOU02305EA.ct_Col_SupplierSlipNo] = 123456789 + j;                  // 仕入伝票番号
            //        dr[DCKOU02305EA.ct_Col_SupplierSlipCd] = 10;                             // 仕入伝票区分
            //        dr[DCKOU02305EA.ct_Col_AccPayDivCd] = 1;                                 // 買掛区分
            //        dr[DCKOU02305EA.ct_Col_InputDay] = DateTime.Parse("2008/06/24");         // 入力日
            //        dr[DCKOU02305EA.ct_Col_StockDate] = DateTime.Parse("2008/06/22");        // 仕入日
            //        if (j % 2 != 0)
            //        {
            //            dr[DCKOU02305EA.ct_Col_ArrivalGoodsDay] = DateTime.Parse("2008/06/24");  // 入荷日

            //            // 仕入先コード、仕入先名称
            //            dr[DCKOU02305EA.ct_Col_SupplierCd] = j;
            //            dr[DCKOU02305EA.ct_Col_SupplierSnm] = "仕入先名" + j.ToString();
            //        }
            //        else
            //        {
            //            dr[DCKOU02305EA.ct_Col_ArrivalGoodsDay] = DateTime.Parse("2008/06/23");  // 入荷日

            //            // 仕入先コード、仕入先名称
            //            intWork = j - 1;
            //            dr[DCKOU02305EA.ct_Col_SupplierCd] = intWork;
            //            dr[DCKOU02305EA.ct_Col_SupplierSnm] = "仕入先名" + intWork.ToString();
            //        }
            //        dr[DCKOU02305EA.ct_Col_PayeeCode] = j;                                   // 支払先コード
            //        dr[DCKOU02305EA.ct_Col_PayeeSnm] = "支払先名" + j.ToString();            // 支払先名称
            //        if (j % 2 != 0)
            //        {
            //            // 仕入担当者コード、仕入担当者名称
            //            dr[DCKOU02305EA.ct_Col_StockAgentCode] = j;
            //            dr[DCKOU02305EA.ct_Col_StockAgentName] = "仕入担当者名" + j.ToString();
            //        }
            //        else
            //        {
            //            // 仕入担当者コード、仕入担当者名称
            //            intWork = j - 1;
            //            dr[DCKOU02305EA.ct_Col_StockAgentCode] = intWork;
            //            dr[DCKOU02305EA.ct_Col_StockAgentName] = "仕入担当者名" + intWork.ToString();
            //        }
            //        if (j % 2 != 0)
            //        {
            //            // 仕入入力者コード、仕入入力者名称
            //            dr[DCKOU02305EA.ct_Col_StockInputCode] = j;
            //            dr[DCKOU02305EA.ct_Col_StockInputName] = "仕入入力者名称";
            //        }
            //        else
            //        {
            //            // 仕入入力者コード、仕入入力者名称
            //            intWork = j - 1;
            //            dr[DCKOU02305EA.ct_Col_StockInputCode] = intWork;
            //            dr[DCKOU02305EA.ct_Col_StockInputName] = "仕入入力者名称" + intWork.ToString();
            //        }
            //        dr[DCKOU02305EA.ct_Col_PartySaleSlipNum] = "DenpyoNo90123456789";        // 相手先伝票番号（明細）
            //        dr[DCKOU02305EA.ct_Col_StockRowNo] = 123;
            //        dr[DCKOU02305EA.ct_Col_StockSlipCdDtl] = 0;                              // 仕入伝票区分(明細)
            //        dr[DCKOU02305EA.ct_Col_GoodsMakerCd] = j;                                // 商品メーカーコード
            //        dr[DCKOU02305EA.ct_Col_MakerName] = "メーカー名" + j.ToString();         // メーカー名称
            //        dr[DCKOU02305EA.ct_Col_GoodsNo] = "90915-10001-1234567990915-10001-12345679";     // 商品番号
            //        dr[DCKOU02305EA.ct_Col_GoodsName] = "テスト商品名７８９０";                       // 商品名称
            //        double workCnt = 100;
            //        dr[DCKOU02305EA.ct_Col_StockCount] = workCnt;                            // 仕入数
            //        dr[DCKOU02305EA.ct_Col_OrderCnt] = 50;                                   // 発注数量
            //        dr[DCKOU02305EA.ct_Col_OrderAdjustCnt] = 50;                             // 発注調整数
            //        dr[DCKOU02305EA.ct_Col_OrderRemainCnt] = 5;                              // 発注残数
            //        dr[DCKOU02305EA.ct_Col_StockUnitPriceFl] = 2500;                         // 単価
            //        dr[DCKOU02305EA.ct_Col_StockPriceTaxExc] = 2500 * workCnt;               // 金額
            //        dr[DCKOU02305EA.ct_Col_TaxationCode] = 0;                                // 課税区分
            //        dr[DCKOU02305EA.ct_Col_WarehouseCode] = "1";                             // 倉庫コード
            //        dr[DCKOU02305EA.ct_Col_WarehouseName] = "倉庫名称";                      // 倉庫名称
            //        dr[DCKOU02305EA.ct_Col_SupplierSlipCd] = 10;


            //        if (j % 2 == 0)
            //        {
            //            dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "掛仕入";              // 取引区分名称
            //        }
            //        else
            //        {
            //            dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "掛返品";              // 取引区分名称
            //        }
            //        workCnt = 30;
            //        dr[DCKOU02305EA.ct_Col_UnAddUpCnt] = workCnt;                            // 未計上数（発注残数）
            //        //dr[DCKOU02305EA.ct_Col_UnAddUpAmount] = 1000 * workCnt;                // 未計上金額
            //        dr[DCKOU02305EA.ct_Col_UnAddUpAmount] = workCnt * 2500;                  // 未計上金額

            //        dr[DCKOU02305EA.ct_Col_AddUpCnt] = 70;                                   // 計上数（入荷数）
            //        dr[DCKOU02305EA.ct_Col_DtlNote] = "明細備考";                            // 明細備考

            //        dr[DCKOU02305EA.ct_Col_DebitNoteDiv] = 3;
            //        dr[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl] = "黒伝";

            //        dr[DCKOU02305EA.ct_Col_ListTitle] = this.ListTitle;                      // 帳票タイトル

            //        this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
            //    }
            //}


            ////for (int i = 1; i < 5; i++)
            ////{
            ////    for (int j = 1; j < 69; j++)
            ////    {
            ////        DataRow dr;
            ////        dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();

            ////        dr[DCKOU02305EA.ct_Col_SectionCode] = i.ToString();                      // 拠点コード
            ////        dr[DCKOU02305EA.ct_Col_SectionGuideNm] = "";    // 拠点ガイド名称
            ////        dr[DCKOU02305EA.ct_Col_SupplierSlipNo] = 0;                  // 仕入伝票番号
            ////        dr[DCKOU02305EA.ct_Col_SupplierSlipCd] = 10;                             // 仕入伝票区分
            ////        dr[DCKOU02305EA.ct_Col_AccPayDivCd] = 0;                                 // 買掛区分
            ////        dr[DCKOU02305EA.ct_Col_InputDay] = DateTime.Parse("2008/06/24");         // 入力日
            ////        dr[DCKOU02305EA.ct_Col_StockDate] = DateTime.Parse("2008/06/22");        // 仕入日
            ////        if (j % 2 != 0)
            ////        {
            ////            dr[DCKOU02305EA.ct_Col_ArrivalGoodsDay] = DateTime.Parse("2008/06/24");  // 入荷日

            ////            // 仕入先コード、仕入先名称
            ////            dr[DCKOU02305EA.ct_Col_SupplierCd] = 0;
            ////            dr[DCKOU02305EA.ct_Col_SupplierSnm] = "";
            ////        }
            ////        else
            ////        {
            ////            dr[DCKOU02305EA.ct_Col_ArrivalGoodsDay] = DateTime.Parse("2008/06/23");  // 入荷日

            ////            // 仕入先コード、仕入先名称
            ////            intWork = j - 1;
            ////            dr[DCKOU02305EA.ct_Col_SupplierCd] = 0;
            ////            dr[DCKOU02305EA.ct_Col_SupplierSnm] = "";
            ////        }
            ////        dr[DCKOU02305EA.ct_Col_PayeeCode] = 0;                                   // 支払先コード
            ////        dr[DCKOU02305EA.ct_Col_PayeeSnm] = "";            // 支払先名称
            ////        if (j % 2 != 0)
            ////        {
            ////            // 仕入担当者コード、仕入担当者名称
            ////            dr[DCKOU02305EA.ct_Col_StockAgentCode] = 0;
            ////            dr[DCKOU02305EA.ct_Col_StockAgentName] = "";
            ////        }
            ////        else
            ////        {
            ////            // 仕入担当者コード、仕入担当者名称
            ////            intWork = j - 1;
            ////            dr[DCKOU02305EA.ct_Col_StockAgentCode] = 0;
            ////            dr[DCKOU02305EA.ct_Col_StockAgentName] = "";
            ////        }
            ////        if (j % 2 != 0)
            ////        {
            ////            // 仕入入力者コード、仕入入力者名称
            ////            dr[DCKOU02305EA.ct_Col_StockInputCode] = 0;
            ////            dr[DCKOU02305EA.ct_Col_StockInputName] = "";
            ////        }
            ////        else
            ////        {
            ////            // 仕入入力者コード、仕入入力者名称
            ////            intWork = j - 1;
            ////            dr[DCKOU02305EA.ct_Col_StockInputCode] = 0;
            ////            dr[DCKOU02305EA.ct_Col_StockInputName] = "";
            ////        }
            ////        dr[DCKOU02305EA.ct_Col_PartySaleSlipNum] = "";        // 相手先伝票番号（明細）
            ////        dr[DCKOU02305EA.ct_Col_StockRowNo] = 0;
            ////        dr[DCKOU02305EA.ct_Col_StockSlipCdDtl] = 0;                              // 仕入伝票区分(明細)
            ////        dr[DCKOU02305EA.ct_Col_GoodsMakerCd] = 0;                                // 商品メーカーコード
            ////        dr[DCKOU02305EA.ct_Col_MakerName] = "";         // メーカー名称
            ////        dr[DCKOU02305EA.ct_Col_GoodsNo] = "";     // 商品番号
            ////        dr[DCKOU02305EA.ct_Col_GoodsName] = "";                       // 商品名称
            ////        double workCnt = 100;
            ////        dr[DCKOU02305EA.ct_Col_StockCount] = 1;                            // 仕入数
            ////        dr[DCKOU02305EA.ct_Col_OrderCnt] = 0;                                   // 発注数量
            ////        dr[DCKOU02305EA.ct_Col_OrderAdjustCnt] = 0;                             // 発注調整数
            ////        dr[DCKOU02305EA.ct_Col_OrderRemainCnt] = 0;                              // 発注残数
            ////        dr[DCKOU02305EA.ct_Col_StockUnitPriceFl] = 1000;                         // 単価
            ////        dr[DCKOU02305EA.ct_Col_StockPriceTaxExc] = 1000;               // 金額
            ////        dr[DCKOU02305EA.ct_Col_TaxationCode] = 0;                                // 課税区分
            ////        dr[DCKOU02305EA.ct_Col_WarehouseCode] = "";                             // 倉庫コード
            ////        dr[DCKOU02305EA.ct_Col_WarehouseName] = "";                      // 倉庫名称
            ////        dr[DCKOU02305EA.ct_Col_SupplierSlipCd] = 0;


            ////        if (j % 2 == 0)
            ////        {
            ////            dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "";              // 取引区分名称
            ////        }
            ////        else
            ////        {
            ////            dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "";              // 取引区分名称
            ////        }
            ////        workCnt = 1;
            ////        dr[DCKOU02305EA.ct_Col_UnAddUpCnt] = workCnt;                            // 未計上数（発注残数）
            ////        //dr[DCKOU02305EA.ct_Col_UnAddUpAmount] = 1000 * workCnt;                // 未計上金額
            ////        dr[DCKOU02305EA.ct_Col_UnAddUpAmount] = workCnt * 1000;                  // 未計上金額

            ////        dr[DCKOU02305EA.ct_Col_AddUpCnt] = 1;                                   // 計上数（入荷数）
            ////        dr[DCKOU02305EA.ct_Col_DtlNote] = "";                            // 明細備考

            ////        dr[DCKOU02305EA.ct_Col_DebitNoteDiv] = 0;
            ////        dr[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl] = "";

            ////        dr[DCKOU02305EA.ct_Col_ListTitle] = this.ListTitle;                      // 帳票タイトル

            ////        this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
            ////    }
            ////}

            //status = 0;

            //return status;
            #endregion
        }
        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 検索パラメータ設定処理
        /// </summary>
        /// <param name="extrInfo_DCKOU02304E">検索パラメータ</param>
        /// <param name="arrivalListParamWork">取得パラメータ</param>
        /// <remarks>
        /// <br>Note       : 検索パラメータの設定を行います。 </br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
		private void SearchParaSet(ExtrInfo_DCKOU02304E extrInfo_DCKOU02304E, ref ArrivalListParamWork arrivalListParamWork)
        {
            #region < 企業コード >
            arrivalListParamWork.EnterpriseCode = extrInfo_DCKOU02304E.EnterpriseCode;                                // 企業コード
            #endregion

            #region < 拠点 >

			if (extrInfo_DCKOU02304E.SectionCodes.Length != 0)
			{
				if (extrInfo_DCKOU02304E.SectionCodes[0] == "0")
				{
					// 全社の時
					arrivalListParamWork.SectionCodes = new string[0];                                  // 拠点コード
				}
				else
				{
					arrivalListParamWork.SectionCodes = extrInfo_DCKOU02304E.SectionCodes;      // 拠点コード
				}
			}
			else
			{
				arrivalListParamWork.SectionCodes = new string[0];                                      // 拠点コード
			}
			#endregion

            #region < 画面設定条件 >
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			arrivalListParamWork.CustomerCodeSt = extrInfo_DCKOU02304E.CustomerCodeSt;                             // 開始得意先コード
			arrivalListParamWork.CustomerCodeEd = extrInfo_DCKOU02304E.CustomerCodeEd;                             // 終了得意先コード

			arrivalListParamWork.StockInputCodeSt = extrInfo_DCKOU02304E.StockInputCodeSt;                         // 開始仕入入力者コード
			arrivalListParamWork.StockInputCodeEd = extrInfo_DCKOU02304E.StockInputCodeEd;                         // 終了仕入入力者コード
               --- DEL 2008/06/25 --------------------------------<<<<< */

            arrivalListParamWork.SupplierCdSt = extrInfo_DCKOU02304E.SupplierCdSt;
            arrivalListParamWork.SupplierCdEd = extrInfo_DCKOU02304E.SupplierCdEd;

            arrivalListParamWork.StockAgentCodeSt = extrInfo_DCKOU02304E.StockAgentCodeSt;                         // 開始仕入担当者コード
			//TODO 08.02.05 リモートで不具合が出ている
			arrivalListParamWork.StockAgentCodeEd = extrInfo_DCKOU02304E.StockAgentCodeEd;                         // 終了仕入担当者コード
			
            //arrivalListParamWork.SupplierSlipNoSt = Convert.ToInt32(extrInfo_DCKOU02304E.SupplierSlipNoSt);		　 // 開始仕入伝票番号(仕入伝票番号)
            //arrivalListParamWork.SupplierSlipNoEd = Convert.ToInt32(extrInfo_DCKOU02304E.SupplierSlipNoEd);        // 終了仕入伝票番号(仕入伝票番号)
            arrivalListParamWork.SupplierSlipNoSt = extrInfo_DCKOU02304E.SupplierSlipNoSt;		　 // 開始仕入伝票番号(仕入伝票番号)
            arrivalListParamWork.SupplierSlipNoEd = extrInfo_DCKOU02304E.SupplierSlipNoEd;        // 終了仕入伝票番号(仕入伝票番号)

			arrivalListParamWork.StockDateSt	  = extrInfo_DCKOU02304E.StockDateSt;							   // 開始仕入日
			arrivalListParamWork.StockDateEd	  = extrInfo_DCKOU02304E.StockDateEd;							   // 終了仕入日
            
			arrivalListParamWork.ArrivalGoodsDaySt = extrInfo_DCKOU02304E.ArrivalGoodsDaySt;					   // 開始入荷日
			arrivalListParamWork.ArrivalGoodsDayEd = extrInfo_DCKOU02304E.ArrivalGoodsDayEd;					   // 終了入荷日

			arrivalListParamWork.InputDaySt		   = extrInfo_DCKOU02304E.InputDaySt;							   // 開始入力日
			arrivalListParamWork.InputDayEd		   = extrInfo_DCKOU02304E.InputDayEd;							   // 終了入力日
			
			arrivalListParamWork.MakeShowDiv	   = extrInfo_DCKOU02304E.MakeShowDiv;                             // 作表区分
			arrivalListParamWork.SlipDiv		   = extrInfo_DCKOU02304E.SlipDiv;                                 // 伝票区分
            
			arrivalListParamWork.SortOrder         = extrInfo_DCKOU02304E.SortOrder;                               // 出力順

			arrivalListParamWork.DebitNoteDiv	   = extrInfo_DCKOU02304E.DebitNoteDiv;                            // 赤伝区分

            // --- ADD 2009/04/08 -------------------------------->>>>>
            arrivalListParamWork.St_PartySaleSlipNum = extrInfo_DCKOU02304E.PartySalesSlipNumSt;                    // 開始伝票番号(相手先伝票番号)
            arrivalListParamWork.Ed_PartySaleSlipNum = extrInfo_DCKOU02304E.PartySalesSlipNumEd;                    // 終了伝票番号(相手先伝票番号)
            // --- ADD 2009/04/08 --------------------------------<<<<<
			
			#endregion

            #region < 画面設定条件(リスト) >
            #endregion
        }
        
        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.DCKOU02305EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// モード毎のSearch呼出処理
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="arrivalListParamWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
		private int SearchByMode(out object retObj, ArrivalListParamWork arrivalListParamWork)
        {
            int status = 0;
            retObj = null;

			IArrivalListDB _iArrivalListDB = (IArrivalListDB)MediationArrivalListDB.GetArrivalListDB();

            status = _iArrivalListDB.Search(out retObj, arrivalListParamWork);

            return status;
        }

        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
		private string GetPrintOderQuerry(ExtrInfo_DCKOU02304E extrInfo_DCKOU02304E)
        {
            string orderQuerry = "";

            // ソート順設定
            switch (extrInfo_DCKOU02304E.SortOrder)
            {
				case 0:
					{
						// 仕入先→入荷日→伝票番号
						orderQuerry = CT_Sort1_Odr;
						break;
					}
				case 1:
					{
						// 入荷日→仕入先→伝票番号
						orderQuerry = CT_Sort2_Odr;
						break;
					}
				case 2:
					{
						// 担当者→仕入先→入荷日→伝票番号
						orderQuerry = CT_Sort3_Odr;
						break;
					}
				case 3:
					{
						// 入荷日→伝票番号
						orderQuerry = CT_Sort4_Odr;
						break;
					}
				case 4:
					{
						// 伝票番号
						orderQuerry = CT_Sort5_Odr;
						break;
					}
			}

            // 昇順固定
            orderQuerry += CT_UpperOrder;

            return orderQuerry;
        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
			this._Tbl_ShipmentDtl = Broadleaf.Application.UIData.DCKOU02305EA.ct_Tbl_ArrivalDtl;
        }

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        //private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        private void SetTebleRowFromRetList(ArrayList retList, int setCnt)
        {
			_extrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();

			double shipmentCnt;		//入荷数
			double addUpCnt;		//計上数
			double unAddUpAmount;	//未計上金額

            DataRow dr;
            dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].NewRow();

            // 明細単位
			ArrivalListResultWork arrivalListResultWork = (ArrivalListResultWork)retList[setCnt];
            
            dr[DCKOU02305EA.ct_Col_SectionCode]         = arrivalListResultWork.SectionCode;		   // 拠点コード
            dr[DCKOU02305EA.ct_Col_SectionGuideNm]      = arrivalListResultWork.SectionGuideNm;		   // 拠点ガイド名称
			dr[DCKOU02305EA.ct_Col_SupplierSlipNo]		= arrivalListResultWork.SupplierSlipNo;		   // 仕入伝票番号
			dr[DCKOU02305EA.ct_Col_SupplierSlipCd]		= arrivalListResultWork.SupplierSlipCd;		   // 仕入伝票区分（ヘッダ）
			dr[DCKOU02305EA.ct_Col_AccPayDivCd]			= arrivalListResultWork.AccPayDivCd;		   // 買掛区分
			dr[DCKOU02305EA.ct_Col_DebitNoteDiv]		= arrivalListResultWork.DebitNoteDiv;          // 赤伝区分
			dr[DCKOU02305EA.ct_Col_InputDay]			= arrivalListResultWork.InputDay;			   // 入力日付	
			dr[DCKOU02305EA.ct_Col_ArrivalGoodsDay]		= arrivalListResultWork.ArrivalGoodsDay;       // 入荷日付
			dr[DCKOU02305EA.ct_Col_StockDate]			= arrivalListResultWork.StockDate;             // 仕入日付

            /* --- DEL 2008/06/25 -------------------------------->>>>>
			dr[DCKOU02305EA.ct_Col_CustomerCode]		= arrivalListResultWork.CustomerCode;          // 得意先コード
			dr[DCKOU02305EA.ct_Col_CustomerName]		= arrivalListResultWork.CustomerName;          // 得意先名称
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            dr[DCKOU02305EA.ct_Col_SupplierCd]          = arrivalListResultWork.SupplierCd;            // 仕入先コード
            dr[DCKOU02305EA.ct_Col_SupplierSnm]         = arrivalListResultWork.SupplierSnm;           // 仕入先略称
            // --- ADD 2008/06/25 --------------------------------<<<<< 

			dr[DCKOU02305EA.ct_Col_PayeeCode]			= arrivalListResultWork.PayeeCode;             // 支払先コード
			dr[DCKOU02305EA.ct_Col_PayeeSnm]			= arrivalListResultWork.PayeeSnm;              // 支払先名称
			dr[DCKOU02305EA.ct_Col_StockAgentCode]		= arrivalListResultWork.StockAgentCode;        // 仕入担当者コード
			dr[DCKOU02305EA.ct_Col_StockAgentName]		= arrivalListResultWork.StockAgentName;        // 仕入担当者名称
			dr[DCKOU02305EA.ct_Col_StockInputCode]		= arrivalListResultWork.StockInputCode;        // 仕入入力者コード
			dr[DCKOU02305EA.ct_Col_StockInputName]		= arrivalListResultWork.StockInputName;        // 仕入入力者名称
			dr[DCKOU02305EA.ct_Col_PartySaleSlipNum]	= arrivalListResultWork.PartySaleSlipNum;	   // 相手先伝票番号
			dr[DCKOU02305EA.ct_Col_StockRowNo]			= arrivalListResultWork.StockRowNo;			   // 仕入行番号
			dr[DCKOU02305EA.ct_Col_StockSlipCdDtl]		= arrivalListResultWork.StockSlipCdDtl;		   // 仕入伝票区分（明細）
            dr[DCKOU02305EA.ct_Col_GoodsMakerCd]        = arrivalListResultWork.GoodsMakerCd;          // 商品メーカーコード
            dr[DCKOU02305EA.ct_Col_MakerName]           = arrivalListResultWork.MakerName;             // メーカー名称
            dr[DCKOU02305EA.ct_Col_GoodsNo]             = arrivalListResultWork.GoodsNo;               // 商品番号
            dr[DCKOU02305EA.ct_Col_GoodsName]           = arrivalListResultWork.GoodsName;             // 商品名称
			dr[DCKOU02305EA.ct_Col_OrderCnt]			= arrivalListResultWork.OrderCnt;			   // 発注数量
			dr[DCKOU02305EA.ct_Col_OrderAdjustCnt]		= arrivalListResultWork.OrderAdjustCnt;		   // 発注調整数
			dr[DCKOU02305EA.ct_Col_OrderRemainCnt]		= arrivalListResultWork.OrderRemainCnt;		   // 発注残数
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			dr[DCKOU02305EA.ct_Col_UnitCode]			= arrivalListResultWork.UnitCode;			   // 単位コード
			dr[DCKOU02305EA.ct_Col_UnitName]			= arrivalListResultWork.UnitName;			   // 単位名称
               --- DEL 2008/06/25 --------------------------------<<<<< */
			dr[DCKOU02305EA.ct_Col_StockUnitTaxPriceFl] = arrivalListResultWork.StockUnitTaxPriceFl;   // 仕入単価（税込，浮動）
			dr[DCKOU02305EA.ct_Col_StockUnitPriceFl]	= arrivalListResultWork.StockUnitPriceFl;	   // 仕入単価（税抜，浮動）
			dr[DCKOU02305EA.ct_Col_StockPriceTaxInc]	= arrivalListResultWork.StockPriceTaxInc;	   // 仕入金額（税込み）
			dr[DCKOU02305EA.ct_Col_StockPriceTaxExc]	= arrivalListResultWork.StockPriceTaxExc;	   // 仕入金額（税抜き）
			dr[DCKOU02305EA.ct_Col_TaxationCode]		= arrivalListResultWork.TaxationCode;          // 課税区分
            dr[DCKOU02305EA.ct_Col_WarehouseCode]       = arrivalListResultWork.WarehouseCode;         // 倉庫コード
            dr[DCKOU02305EA.ct_Col_WarehouseName]       = arrivalListResultWork.WarehouseName;         // 倉庫名称
			//dr[DCKOU02305EA.ct_Col_DtlNote]			= arrivalListResultWork.DtlNote;	           // 明細備考

			shipmentCnt = arrivalListResultWork.OrderCnt + arrivalListResultWork.OrderAdjustCnt;
			dr[DCKOU02305EA.ct_Col_StockCount]			= shipmentCnt;								   // 入荷数(仕入数)（＝発注数量＋発注調整数）

			addUpCnt = arrivalListResultWork.OrderCnt + arrivalListResultWork.OrderAdjustCnt - arrivalListResultWork.OrderRemainCnt;
			dr[DCKOU02305EA.ct_Col_AddUpCnt]			= addUpCnt;									   // 計上数（＝発注数量＋発注調整数＋発注残数）
			
			dr[DCKOU02305EA.ct_Col_UnAddUpCnt]			= arrivalListResultWork.OrderRemainCnt;		   // 未計上数（＝発注残数）

            // --- DEL 2008/09/26 未計上金額 = 未計上数 × 仕入単価(税抜) の為 -------------------------------------------------------------------->>>>>
			//unAddUpAmount = arrivalListResultWork.OrderRemainCnt * arrivalListResultWork.StockUnitTaxPriceFl;//(＝発注残数×仕入単価（税込，浮動）)
            // --- DEL 2008/09/26 未計上金額 = 未計上数 × 仕入単価(税抜) の為 --------------------------------------------------------------------<<<<<
            // --- ADD 2008/09/26 ----------------------------------------------------------------------------------------------------------------->>>>>
            unAddUpAmount = arrivalListResultWork.OrderRemainCnt * arrivalListResultWork.StockUnitPriceFl;      //(＝発注残数×仕入単価（税抜，浮動）)
            // --- ADD 2008/09/26 -----------------------------------------------------------------------------------------------------------------<<<<<
            dr[DCKOU02305EA.ct_Col_UnAddUpAmount] = Math.Round(unAddUpAmount, 0, MidpointRounding.AwayFromZero);// 未計上金額（unAddUpAmountの端数（小数点）を四捨五入した値）

			switch (arrivalListResultWork.DebitNoteDiv)
			{
				case 0: // 黒伝

					dr[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl] = "黒伝";
					
					break;

				case 1: //赤伝

					dr[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl] = "赤伝";

					break;

				case 2: // 元黒

					dr[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl] = "元黒";
					
					break;
			}

			// 伝票区分名称・伝票枚数
			switch (arrivalListResultWork.SupplierSlipCd)
			{
				case 10: // 10:仕入

                    // ---DEL 2009/06/26 不具合対応[13590] ---------------------------->>>>>
                    //// 2009.02.06 30413 犬飼 "仕入"→"入荷"に修正 >>>>>>START
                    ////dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "仕入";   // MOD 2009/01/16 不具合対応[9805] "掛仕入"→"仕入"
                    //dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "入荷";
                    //// 2009.02.06 30413 犬飼 "仕入"→"入荷"に修正 <<<<<<END
                    //// ---DEL 2009/06/26 不具合対応[13590] ----------------------------<<<<<
                    dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "仕入";       //ADD 2009/06/26 不具合対応[135590]
					
					break;

				case 20: // 20:返品

                    dr[DCKOU02305EA.ct_Col_TransactionsDivName] = "返品";   // MOD 2009/01/16 不具合対応[9805] "掛返品"→"返品"

					break;
			}

			dr[DCKOU02305EA.ct_Col_ListTitle] = this.ListTitle;                       // 帳票タイトル

			//double workSalesPrc;
			//if (arrivalListResultWork.TaxationDivCd == 2)
			//{
			//    workSalesPrc = arrivalListResultWork.StockUnitTaxPriceFl;                       // 仕入単価（税込，浮動）
			//    dr[DCKOU02305EA.ct_Col_TaxationDiv]     = "*";                                  // 課税区分
			//}
			//else
			//{
			//    workSalesPrc = arrivalListResultWork.StockUnitPriceFl;                       // 仕入単価（税抜，浮動）
			//    dr[DCKOU02305EA.ct_Col_TaxationDiv]     = "";                                   // 課税区分
			//}
			//dr[DCKOU02305EA.ct_Col_StockUnitPriceFl]  = workSalesPrc;                         // 仕入単価（浮動）

			//dr[DCKOU02305EA.ct_Col_ShipmentAmount]      = workSalesPrc * workCnt;               // 入荷金額

			// 赤伝区分名称（明細）

            // --- ADD 2009/04/08 -------------------------------->>>>>
            dr[DCKOU02305EA.ct_Col_StockAddUpADate] = arrivalListResultWork.StockAddUpADate; // 仕入計上日付
            dr[DCKOU02305EA.ct_Col_SupplierSlipNote1] = arrivalListResultWork.SupplierSlipNote1; // 仕入伝票備考1
            dr[DCKOU02305EA.ct_Col_SupplierSlipNote2] = arrivalListResultWork.SupplierSlipNote2; // 仕入伝票備考2
            dr[DCKOU02305EA.ct_Col_SuppCTaxLayCd] = arrivalListResultWork.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            dr[DCKOU02305EA.ct_Col_BLGoodsCode] = arrivalListResultWork.BLGoodsCode; // BL商品コード
            dr[DCKOU02305EA.ct_Col_BLGoodsFullName] = arrivalListResultWork.BLGoodsFullName; // BL商品コード名称
            dr[DCKOU02305EA.ct_Col_StockOrderDivCd] = arrivalListResultWork.StockOrderDivCd; // 仕入在庫取寄せ区分
            // 仕入在庫取寄せ区分名称
            if (arrivalListResultWork.StockOrderDivCd == 0)
            {
                dr[DCKOU02305EA.ct_Col_StockOrderDivName] = "取寄";
            }
            else if (arrivalListResultWork.StockOrderDivCd == 1)
            {
                dr[DCKOU02305EA.ct_Col_StockOrderDivName] = "在庫";
            }
            else
            {
                dr[DCKOU02305EA.ct_Col_StockOrderDivName] = string.Empty;
            }
            dr[DCKOU02305EA.ct_Col_StockPriceConsTax] = arrivalListResultWork.StockPriceConsTax; // 仕入金額消費税額

            dr[DCKOU02305EA.ct_Col_ArrivalRemainCnt] = arrivalListResultWork.OrderRemainCnt; // 入荷残数(発注残数)
            dr[DCKOU02305EA.ct_Col_ArrivalRemainPrice] 
                = arrivalListResultWork.OrderRemainCnt * arrivalListResultWork.StockUnitPriceFl; // 入荷残金額(発注残数×仕入単価(税抜))
            // --- ADD 2009/04/08 --------------------------------<<<<<
			
			this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Add(dr);
        }

        // 2009.02.13 30413 犬飼 発行タイプによるフィルタ処理追加 >>>>>>START
        /// <summary>
        /// 見積残数フィルタ処理
        /// </summary>
        /// <remarks>
        /// <br>明細の数量と見積残数が全て同じ伝票を削除する</br>
        /// </remarks>
        private void FilterByAcptAnOdrRemainCnt()
        {
            // 伝票番号順にソート
            DataTable copyTable = this._printDataSet.Tables[_Tbl_ShipmentDtl].Copy();

            DataRow[] drList = copyTable.Select("", DCKOU02305EA.ct_Col_SupplierSlipNo);

            this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Clear();

            foreach (DataRow sortedRow in drList)
            {
                this._printDataSet.Tables[_Tbl_ShipmentDtl].ImportRow(sortedRow);
            }


            bool isOK = false; // 印字対象フラグ
            DataRow dr;
            List<int> sameSlipRowIndex = new List<int>();
            // 前回処理伝票番号
            string beforeSalesSlip = string.Empty;
            for (int i = this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.Count - 1; i >= 0; i--)
            {
                dr = this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows[i];

                if (dr[DCKOU02305EA.ct_Col_SupplierSlipNo].ToString() == beforeSalesSlip)
                {
                    if (!isOK)
                    {
                        // チェック
                        isOK = this.CheckByAcptAnOdrRemainCnt(dr);
                    }

                    sameSlipRowIndex.Add(i);
                }
                else
                {
                    if (beforeSalesSlip != string.Empty
                        && !isOK)
                    {
                        // 削除処理実行
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.RemoveAt(delIndex);
                        }
                    }

                    // 初期化
                    isOK = false;
                    sameSlipRowIndex.Clear();
                    beforeSalesSlip = dr[DCKOU02305EA.ct_Col_SupplierSlipNo].ToString();

                    // チェック
                    isOK = this.CheckByAcptAnOdrRemainCnt(dr);

                    sameSlipRowIndex.Add(i);
                }

                if (i == 0)
                {
                    if (!isOK)
                    {
                        // 削除処理実行
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._printDataSet.Tables[_Tbl_ShipmentDtl].Rows.RemoveAt(delIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 1明細の受注残数チェック
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool CheckByAcptAnOdrRemainCnt(DataRow dr)
        {
            if ((double)dr[DCKOU02305EA.ct_Col_StockCount] != (double)dr[DCKOU02305EA.ct_Col_UnAddUpCnt])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // 2009.02.13 30413 犬飼 発行タイプによるフィルタ処理追加 <<<<<<END
                    
        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            dr[DCKOU02305EA.ct_Col_SectionCode]         = sourceDataRow[DCKOU02305EA.ct_Col_SectionCode];        // 拠点コード
            dr[DCKOU02305EA.ct_Col_SectionGuideNm]      = sourceDataRow[DCKOU02305EA.ct_Col_SectionGuideNm];     // 拠点ガイド名称
            dr[DCKOU02305EA.ct_Col_StockInputCode]      = sourceDataRow[DCKOU02305EA.ct_Col_StockInputCode];     // 仕入入力者コード
            dr[DCKOU02305EA.ct_Col_StockInputName]      = sourceDataRow[DCKOU02305EA.ct_Col_StockInputName];     // 仕入入力者名称
            dr[DCKOU02305EA.ct_Col_StockAgentCode]		= sourceDataRow[DCKOU02305EA.ct_Col_StockAgentCode];	 // 仕入担当者コード
            dr[DCKOU02305EA.ct_Col_StockAgentName]		= sourceDataRow[DCKOU02305EA.ct_Col_StockAgentName];     // 仕入担当者名称
            dr[DCKOU02305EA.ct_Col_SupplierSlipCd]      = sourceDataRow[DCKOU02305EA.ct_Col_SupplierSlipCd];     // 仕入伝票区分（ヘッダ）
            dr[DCKOU02305EA.ct_Col_SupplierSlipNo]      = sourceDataRow[DCKOU02305EA.ct_Col_SupplierSlipNo];     // 仕入伝票番号
			dr[DCKOU02305EA.ct_Col_SupplierSlipCd]		= sourceDataRow[DCKOU02305EA.ct_Col_SupplierSlipCd];     // 仕入伝票区分（ヘッダ）
			dr[DCKOU02305EA.ct_Col_StockDate]			= sourceDataRow[DCKOU02305EA.ct_Col_StockDate];          // 仕入日付
			dr[DCKOU02305EA.ct_Col_ArrivalGoodsDay]		= sourceDataRow[DCKOU02305EA.ct_Col_ArrivalGoodsDay];    // 入荷日付
            /* --- DEL 2008/06/25 -------------------------------->>>>>
            dr[DCKOU02305EA.ct_Col_CustomerCode]        = sourceDataRow[DCKOU02305EA.ct_Col_CustomerCode];       // 得意先コード
            dr[DCKOU02305EA.ct_Col_CustomerName]        = sourceDataRow[DCKOU02305EA.ct_Col_CustomerName];       // 得意先名称
               --- DEL 2008/06/25 --------------------------------<<<<< */
            dr[DCKOU02305EA.ct_Col_PayeeCode]           = sourceDataRow[DCKOU02305EA.ct_Col_PayeeCode];          // 支払先コード
            dr[DCKOU02305EA.ct_Col_PayeeSnm]            = sourceDataRow[DCKOU02305EA.ct_Col_PayeeSnm];           // 支払先名称
            dr[DCKOU02305EA.ct_Col_GoodsMakerCd]        = sourceDataRow[DCKOU02305EA.ct_Col_GoodsMakerCd];       // 商品メーカーコード
            dr[DCKOU02305EA.ct_Col_MakerName]           = sourceDataRow[DCKOU02305EA.ct_Col_MakerName];          // メーカー名称
            dr[DCKOU02305EA.ct_Col_GoodsNo]             = sourceDataRow[DCKOU02305EA.ct_Col_GoodsNo];            // 商品番号
            dr[DCKOU02305EA.ct_Col_GoodsName]           = sourceDataRow[DCKOU02305EA.ct_Col_GoodsName];          // 商品名称
            dr[DCKOU02305EA.ct_Col_WarehouseCode]       = sourceDataRow[DCKOU02305EA.ct_Col_WarehouseCode];      // 倉庫コード
            dr[DCKOU02305EA.ct_Col_WarehouseName]       = sourceDataRow[DCKOU02305EA.ct_Col_WarehouseName];      // 倉庫名称
            dr[DCKOU02305EA.ct_Col_AccPayDivCd]         = sourceDataRow[DCKOU02305EA.ct_Col_AccPayDivCd];        // 買掛区分
            dr[DCKOU02305EA.ct_Col_TransactionsDivName] = sourceDataRow[DCKOU02305EA.ct_Col_TransactionsDivName];// 伝票区分名称
            dr[DCKOU02305EA.ct_Col_StockUnitPriceFl]	= sourceDataRow[DCKOU02305EA.ct_Col_StockUnitPriceFl];   // 仕入単価（税抜，浮動）
			dr[DCKOU02305EA.ct_Col_StockUnitTaxPriceFl]	= sourceDataRow[DCKOU02305EA.ct_Col_StockUnitTaxPriceFl];// 仕入単価（税込，浮動）
            dr[DCKOU02305EA.ct_Col_StockCount]			= sourceDataRow[DCKOU02305EA.ct_Col_StockCount];         // 入荷数
            dr[DCKOU02305EA.ct_Col_UnAddUpCnt]          = sourceDataRow[DCKOU02305EA.ct_Col_UnAddUpCnt];         // 未計上数
            dr[DCKOU02305EA.ct_Col_UnAddUpAmount]       = sourceDataRow[DCKOU02305EA.ct_Col_UnAddUpAmount];      // 未計上金額
            dr[DCKOU02305EA.ct_Col_AddUpCnt]            = sourceDataRow[DCKOU02305EA.ct_Col_AddUpCnt];           // 計上数
			dr[DCKOU02305EA.ct_Col_OrderCnt]			= sourceDataRow[DCKOU02305EA.ct_Col_OrderCnt];			 // 発注数量
			dr[DCKOU02305EA.ct_Col_OrderAdjustCnt]		= sourceDataRow[DCKOU02305EA.ct_Col_OrderRemainCnt];	 // 発注調整数
			dr[DCKOU02305EA.ct_Col_OrderRemainCnt]		= sourceDataRow[DCKOU02305EA.ct_Col_OrderRemainCnt];	 // 発注残数
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			dr[DCKOU02305EA.ct_Col_UnitCode]			= sourceDataRow[DCKOU02305EA.ct_Col_UnitCode];           // 単位コード
            dr[DCKOU02305EA.ct_Col_UnitName]            = sourceDataRow[DCKOU02305EA.ct_Col_UnitName];           // 単位名称
               --- DEL 2008/06/25 --------------------------------<<<<< */
            dr[DCKOU02305EA.ct_Col_DtlNote]             = sourceDataRow[DCKOU02305EA.ct_Col_DtlNote];            // 明細備考
			dr[DCKOU02305EA.ct_Col_TaxationCode]		= sourceDataRow[DCKOU02305EA.ct_Col_TaxationCode];       // 課税区分
            dr[DCKOU02305EA.ct_Col_ListTitle]           = sourceDataRow[DCKOU02305EA.ct_Col_ListTitle];          // 帳票タイトル
			dr[DCKOU02305EA.ct_Col_InputDay]			= sourceDataRow[DCKOU02305EA.ct_Col_InputDay];			 // 入力日付	
			dr[DCKOU02305EA.ct_Col_PartySaleSlipNum]	= sourceDataRow[DCKOU02305EA.ct_Col_PartySaleSlipNum];	 // 相手先伝票番号（ヘッダ）
			dr[DCKOU02305EA.ct_Col_StockRowNo]			= sourceDataRow[DCKOU02305EA.ct_Col_StockRowNo];		 // 仕入行番号
			dr[DCKOU02305EA.ct_Col_StockSlipCdDtl]		= sourceDataRow[DCKOU02305EA.ct_Col_StockSlipCdDtl];	 // 仕入伝票区分（明細）
			dr[DCKOU02305EA.ct_Col_StockPriceTaxInc]	= sourceDataRow[DCKOU02305EA.ct_Col_StockPriceTaxInc];	 // 仕入金額（税込み）
			dr[DCKOU02305EA.ct_Col_StockPriceTaxExc]	= sourceDataRow[DCKOU02305EA.ct_Col_StockPriceTaxExc];	 // 仕入金額（税抜き）
			dr[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl] = sourceDataRow[DCKOU02305EA.ct_Col_DebitNoteDivNameDtl];// 赤伝区分名称（明細）
		
		
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
