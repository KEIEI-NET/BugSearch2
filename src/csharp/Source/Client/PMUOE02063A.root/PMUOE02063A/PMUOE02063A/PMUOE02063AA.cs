using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 入庫予定表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入庫予定表で使用するデータを取得する。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.03</br>
    /// <br>Note       : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/09/14</br>
    /// </remarks>
    public class EnterSchOrderAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 入庫予定表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入庫予定表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30413 犬飼</br>
	    /// <br>Date       : 2008.12.03</br>
		/// </remarks>
		public EnterSchOrderAcs()
		{
            this._iEnterSchOrderWorkDB = (IEnterSchOrderWorkDB)MediationEnterSchOrderWorkDB.GetEnterSchOrderWorkDB();
		}

		/// <summary>
        /// 入庫予定表表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入庫予定表表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        static EnterSchOrderAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
			
			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        #endregion ■ Static Member

        #region ■ Private Member
        IEnterSchOrderWorkDB _iEnterSchOrderWorkDB;         // 入庫予定表リモート

        private DataSet _enterSchDs;				        // 入庫予定表データセット

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>重複のBO伝票番号編集用-F</summary>
        private const string DuplicationSlipNoF = "-F";
        /// <summary>重複のBO伝票番号編集用-F2</summary>
        private const string DuplicationSlipNoF2 = "-F2";
        /// <summary>重複のBO伝票番号編集用-F3</summary>
        private const string DuplicationSlipNoF3 = "-F3";
        /// <summary>UOE拠点出庫の設定 仕入伝票番号(バーコード化用)</summary>
        private const string BangoNasiKyoTen = "BANGO-NASI-KYOTEN";
        /// <summary>BO1出庫の設定 仕入伝票番号(バーコード化用)</summary>
        private const string BangoNasiBo1 = "BANGO-NASI-BO1";
        /// <summary>BO2出庫の設定 仕入伝票番号(バーコード化用)</summary>
        private const string BangoNasiBo2 = "BANGO-NASI-BO2";
        /// <summary>BO3出庫の設定 仕入伝票番号(バーコード化用)</summary>
        private const string BangoNasiBo3 = "BANGO-NASI-BO3";
        /// <summary>ﾒｰｶｰﾌｫﾛｰ分出庫の設定 仕入伝票番号(バーコード化用)</summary>
        private const string BangoNasiMaker = "BANGO-NASI-MAKER";
        /// <summary>EO引当分出庫の設定 仕入伝票番号(バーコード化用)</summary>
        private const string BangoNasiEo = "BANGO-NASI-EO";

        /// <summary> バーコード印字区分「False:印字しない True:印字する」</summary>
        private bool _barCodeShowDiv = false;
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        
        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// 入庫予定表データセット(読み取り専用)
        /// </summary>
        public DataSet EnterSchDs
        {
            get { return this._enterSchDs; }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// バーコード印字区分「False:印字しない True:印字する」
        /// </summary>
        public bool BarCodeShowDiv
        {
            get { return _barCodeShowDiv; }
            set { _barCodeShowDiv = value; }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 請求データ取得
        /// <summary>
        /// 入庫予定表データ取得
        /// </summary>
        /// <param name="enterSchOrderCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入庫予定表データを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// <br>Note       : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        public int SearchEnterSchOrder(EnterSchOrderCndtn enterSchOrderCndtn, out string errMsg)
        {
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            // バーコード印字する場合
            if (enterSchOrderCndtn.BarCodeShowDiv == 0)
            {
                this._barCodeShowDiv = true;
            }
            // バーコード印字しない場合
            else
            {
                this._barCodeShowDiv = false;
            }
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

            return this.SearchEnterSchOrderProc(enterSchOrderCndtn, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 入庫予定表データ取得
        /// <summary>
        /// 入庫予定表データ取得
        /// </summary>
        /// <param name="enterSchOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入庫予定表データを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        private int SearchEnterSchOrderProc(EnterSchOrderCndtn enterSchOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                EnterSchResult.CreateDataTableResultEnterSch(ref this._enterSchDs);
                EnterSchOrderCndtnWork enterSchOrderCndtnWork = new EnterSchOrderCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevEnterSchOrder(enterSchOrderCndtn, out enterSchOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                status = this._iEnterSchOrderWorkDB.Search(out retList, (object)enterSchOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevEnterSchOrderData(enterSchOrderCndtn, this._enterSchDs.Tables[EnterSchResult.Col_Tbl_Result_EnterSch], (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "入庫予定表データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="enterSchOrderCndtn">UI抽出条件クラス</param>
        /// <param name="enterSchOrderCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevEnterSchOrder(EnterSchOrderCndtn enterSchOrderCndtn, out EnterSchOrderCndtnWork enterSchOrderCndtnWork, out string errMsg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            enterSchOrderCndtnWork = new EnterSchOrderCndtnWork();

            try
            {
                // 企業コード
                enterSchOrderCndtnWork.EnterpriseCode = enterSchOrderCndtn.EnterpriseCode;

                // 抽出条件パラメータセット
                if (enterSchOrderCndtn.SectionCodes.Length != 0)
                {
                    if (enterSchOrderCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        enterSchOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        enterSchOrderCndtnWork.SectionCodes = enterSchOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    enterSchOrderCndtnWork.SectionCodes = null;
                }


                enterSchOrderCndtnWork.St_UOESupplierCd = enterSchOrderCndtn.St_UOESupplierCd;          // 開始UOE発注先コード
                enterSchOrderCndtnWork.Ed_UOESupplierCd = enterSchOrderCndtn.Ed_UOESupplierCd;          // 終了UOE発注先コード
                enterSchOrderCndtnWork.UOESupplierCds = enterSchOrderCndtn.UOESupplierCds;              // 仕入先指定

                enterSchOrderCndtnWork.St_ReceiveDate = enterSchOrderCndtn.St_ReceiveDate;	            // 開始受信日付
                enterSchOrderCndtnWork.Ed_ReceiveDate = enterSchOrderCndtn.Ed_ReceiveDate;	            // 終了受信日付

                enterSchOrderCndtnWork.PrintTypeCndtn = enterSchOrderCndtn.PrintTypeCndtn;              // 印刷タイプ
                
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 入庫予定表データ展開処理
        /// <summary>
        /// 入庫予定表データ展開処理
        /// </summary>
        /// <param name="enterSchOrderCndtn">UI抽出条件クラス</param>
        /// <param name="enterSchOrderDt">展開対象DataTable</param>
        /// <param name="enterSchResultWorkList">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 入庫予定表データを展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        private void DevEnterSchOrderData(EnterSchOrderCndtn enterSchOrderCndtn, DataTable enterSchOrderDt, ArrayList enterSchResultWorkList)
        {
            foreach (EnterSchResultWork enterSchResultWork in enterSchResultWorkList)
            {
                if (enterSchOrderCndtn.PrintTypeCndtn == 0)
                {
                    // 入庫分のみ
                    if (enterSchResultWork.UOESectOutGoodsCnt != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 0);
                    }
                    if (enterSchResultWork.BOShipmentCnt1 != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 1);
                    }
                    if (enterSchResultWork.BOShipmentCnt2 != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 2);
                    }
                    if (enterSchResultWork.BOShipmentCnt3 != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 3);
                    }
                    if (enterSchResultWork.MakerFollowCnt != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 4);
                    }
                    if (enterSchResultWork.EOAlwcCount != 0)
                    {
                        DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 5);
                    }
                }
                else if (enterSchOrderCndtn.PrintTypeCndtn == 1)
                {
                    // ﾒｰｶｰﾌｫﾛｰ分のみ
                    DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 4);
                }
                else
                {
                    // 欠品分のみ
                    DataSetEnterSchOrder(enterSchOrderDt, enterSchResultWork, 6);
                }

            }
        }
        #endregion


        /// <summary>
        /// 取得データ設定処理
        /// </summary>
        /// <param name="enterSchOrderDt">展開対象DataTable</param>
        /// <param name="enterSchResultWork">取得データ</param>
        /// <param name="addFlg">データ設定フラグ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// <br>UpdateNote : ハンディターミナル二次開発の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : 2017/09/14</br>
        /// </remarks>
        private void DataSetEnterSchOrder(DataTable enterSchOrderDt, EnterSchResultWork enterSchResultWork, int addFlg)
        {
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            string boSlipNo1 = string.Empty;
            string boSlipNo2 = string.Empty;
            string boSlipNo3 = string.Empty;

            // バーコード印字する場合
            if (this._barCodeShowDiv)
            {
                this.UpdBOSlipNo(enterSchResultWork, out boSlipNo1, out boSlipNo2, out boSlipNo3);
            }
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

            DataRow dr;

            dr = enterSchOrderDt.NewRow();

            // 入庫予定表データ展開
            #region 入庫予定表データ展開
            // 拠点コード
            dr[EnterSchResult.Col_SectionCode] = enterSchResultWork.SectionCode;
            // 拠点ガイド略称
            dr[EnterSchResult.Col_SectionGuideSnm] = enterSchResultWork.SectionGuideSnm;
            // 倉庫コード
            dr[EnterSchResult.Col_WarehouseCode] = enterSchResultWork.WarehouseCode;
            // 倉庫名称
            dr[EnterSchResult.Col_WarehouseName] = enterSchResultWork.WarehouseName;
            // 倉庫棚番
            dr[EnterSchResult.Col_WarehouseShelfNo] = enterSchResultWork.WarehouseShelfNo;
            // 商品番号
            dr[EnterSchResult.Col_GoodsNo] = enterSchResultWork.GoodsNo;
            // 商品メーカーコード
            dr[EnterSchResult.Col_GoodsMakerCd] = enterSchResultWork.GoodsMakerCd;
            // 商品名称
            dr[EnterSchResult.Col_GoodsName] = enterSchResultWork.GoodsName;
            // 受注数量
            dr[EnterSchResult.Col_AcceptAnOrderCnt] = enterSchResultWork.AcceptAnOrderCnt;
            // UOE拠点出庫数
            dr[EnterSchResult.Col_UOESectOutGoodsCnt] = enterSchResultWork.UOESectOutGoodsCnt;
            // BO出庫数1
            dr[EnterSchResult.Col_BOShipmentCnt1] = enterSchResultWork.BOShipmentCnt1;
            // BO出庫数2
            dr[EnterSchResult.Col_BOShipmentCnt2] = enterSchResultWork.BOShipmentCnt2;
            // BO出庫数3
            dr[EnterSchResult.Col_BOShipmentCnt3] = enterSchResultWork.BOShipmentCnt3;
            // メーカーフォロー数
            dr[EnterSchResult.Col_MakerFollowCnt] = enterSchResultWork.MakerFollowCnt;
            // EO引当数
            dr[EnterSchResult.Col_EOAlwcCount] = enterSchResultWork.EOAlwcCount;
            // 回答定価
            dr[EnterSchResult.Col_AnswerListPrice] = enterSchResultWork.AnswerListPrice;
            // 回答原価単価
            dr[EnterSchResult.Col_AnswerSalesUnitCost] = enterSchResultWork.AnswerSalesUnitCost;
            // 仕入先コード
            dr[EnterSchResult.Col_SupplierCd] = enterSchResultWork.SupplierCd;
            // BO伝票番号１
            dr[EnterSchResult.Col_BOSlipNo1] = enterSchResultWork.BOSlipNo1;
            // BO伝票番号２
            dr[EnterSchResult.Col_BOSlipNo2] = enterSchResultWork.BOSlipNo2;
            // BO伝票番号３
            dr[EnterSchResult.Col_BOSlipNo3] = enterSchResultWork.BOSlipNo3;
            // UOE拠点伝票番号
            dr[EnterSchResult.Col_UOESectionSlipNo] = enterSchResultWork.UOESectionSlipNo;
            // ＵＯＥリマーク１
            dr[EnterSchResult.Col_UoeRemark1] = enterSchResultWork.UoeRemark1;
            // ＵＯＥリマーク２
            dr[EnterSchResult.Col_UoeRemark2] = enterSchResultWork.UoeRemark2;
            // 受信日付
            dr[EnterSchResult.Col_ReceiveDate] = TDateTime.DateTimeToString("YYYY/MM/DD", enterSchResultWork.ReceiveDate);

            if (addFlg == 0)
            {
                // UOE拠点出庫数
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = enterSchResultWork.UOESectOutGoodsCnt;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = 0;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.UOESectionSlipNo;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(enterSchResultWork.UOESectionSlipNo))
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = enterSchResultWork.UOESectionSlipNo;
                    }
                    else
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiKyoTen;
                    }
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else if (addFlg == 1)
            {
                // BO出庫数1
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.BOShipmentCnt1;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.BOSlipNo1;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(boSlipNo1))
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = boSlipNo1;
                    }
                    else
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiBo1;
                    }
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else if (addFlg == 2)
            {
                // BO出庫数2
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.BOShipmentCnt2;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.BOSlipNo2;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(boSlipNo2))
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = boSlipNo2;
                    }
                    else
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiBo2;
                    }
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else if (addFlg == 3)
            {
                // BO出庫数3
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.BOShipmentCnt3;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = enterSchResultWork.BOSlipNo3;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    if (!string.IsNullOrEmpty(boSlipNo3))
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = boSlipNo3;
                    }
                    else
                    {
                        // 仕入SEQ番号(バーコード化用)
                        dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiBo3;
                    }
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else if (addFlg == 4)
            {
                // ﾒｰｶｰﾌｫﾛｰ分
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.MakerFollowCnt;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = "";

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    // 仕入SEQ番号(バーコード化用)
                    dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiMaker;
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else if (addFlg == 5)
            {
                // EO引当数
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = enterSchResultWork.EOAlwcCount;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = "";

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    // 仕入SEQ番号(バーコード化用)
                    dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = BangoNasiEo;
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }
            else
            {
                // 欠品分のみ
                // 入庫数(印刷用)
                dr[EnterSchResult.Col_OutGoodsCnt_Print] = 0;
                // BO数(印刷用)
                dr[EnterSchResult.Col_BOCnt_Print] = 0;
                // 仕入伝票番号(印刷用)
                dr[EnterSchResult.Col_SlipNo_Print] = "";

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                // バーコード印字する場合
                if (this._barCodeShowDiv)
                {
                    // 仕入SEQ番号(バーコード化用)
                    dr[EnterSchResult.ct_Col_SupplierSeqNoForBarCode] = string.Empty;
                }
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
            }

            // TableにAdd
            enterSchOrderDt.Rows.Add(dr);
        }

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// 重複のBO伝票番号編集処理
        /// </summary>
        /// <param name="handyUOEOrderListWork">UOE発注データ</param>
        /// <param name="boSlipNo1">BO1伝票番号</param>
        /// <param name="boSlipNo2">BO2伝票番号</param>
        /// <param name="boSlipNo3">BO3伝票番号</param>
        /// <remarks>
        /// <br>Note       : 重複のBO伝票番号によって、通信IDよて、「-F」の編集処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/09/14</br>
        /// </remarks>
        private void UpdBOSlipNo(EnterSchResultWork enterSchResultWork, out string boSlipNo1, out string boSlipNo2, out string boSlipNo3)
        {
            // UOE伝票番号
            string tempUOESectionSlipNo = enterSchResultWork.UOESectionSlipNo;
            // BO1伝票番号
            string tempBOSlipNo1 = enterSchResultWork.BOSlipNo1;
            boSlipNo1 = enterSchResultWork.BOSlipNo1;
            // BO2伝票番号
            string tempBOSlipNo2 = enterSchResultWork.BOSlipNo2;
            boSlipNo2 = enterSchResultWork.BOSlipNo2;
            // BO3伝票番号
            string tempBOSlipNo3 = enterSchResultWork.BOSlipNo3;
            boSlipNo3 = enterSchResultWork.BOSlipNo3;

            switch (enterSchResultWork.CommAssemblyId.Trim())
            {
                // ホンダ e-Parts「通信ID：0502」の場合
                case EnumUoeConst.ctCommAssemblyId_0502:
                    {
                        // BO1伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            boSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                        }

                        // BO2伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo))
                            {
                                boSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) || tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                boSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
                // ホンダ e-Parts「通信ID：0502」以外の場合
                default:
                    {
                        // BO1伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            if (tempBOSlipNo1.Equals(tempUOESectionSlipNo))
                            {
                                boSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                            }
                        }

                        // BO2伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo2.Equals(tempBOSlipNo1))
                            {
                                boSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo1) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                boSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
            }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        #endregion ◆ データ展開処理
        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得

        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票設定データ取得
        #endregion ■ Private Method
    }
}
