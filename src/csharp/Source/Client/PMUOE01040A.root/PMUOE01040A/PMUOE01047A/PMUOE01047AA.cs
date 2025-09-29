//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 回答データアクセスクラス
// プログラム概要   : 回答データアクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//           2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//
// 管理番号  　　　　　  作成担当 : 吉岡 
// 修 正 日  2014/02/04  修正内容 : Redmine#41551 システムテスト障害№10
//----------------------------------------------------------------------------//
// 管理番号  　　　　　  作成担当 : 吉岡 
// 修 正 日  2014/02/12  修正内容 : Redmine#41551 システムテスト障害№10 デグレ対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 劉超 
// 修 正 日  2014/09/19  修正内容 : Redmine#43265 イスコ　UOE送信処理回答画面にてメーカー違いの同一品番選択ウィンドウが表示される
//----------------------------------------------------------------------------//
// 管理番号  11575094-00 作成担当 : 岸 
// 修 正 日  2019/06/13  修正内容 : 大黒商会検品障害対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 回答データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 回答データアクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// <br>Update Note : 2014/09/19 劉超</br>
    /// <br>管理番号    : 11070149-00</br>
    /// <br>              Redmine#43265の対応 イスコ　UOE送信処理回答画面にてメーカー違いの同一品番選択ウィンドウが表示される</br>
    /// </remarks>
	public partial class UOEAnswerAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UOEAnswerAcs()
		{
			//企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ログイン拠点コード
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

			//ＵＯＥ送受信ＪＮＬアクセスクラス
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//ＵＯＥ発注データアクセスクラス
            this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();

            //ＵＯＥ送受信制御初期化クラス
            this._uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

            // 2009/05/25 START >>>>>>
            //UOE発注データ・仕入明細データ更新リモートオブジェクト
            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            // 2009/05/25 END   <<<<<<
            // --- ADD 2019/06/13 ---------->>>>>
            //操作履歴ログデータアクセスクラス
            this._uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
            // --- ADD 2019/06/13 ----------<<<<<
        }

        // 2009/05/25 START >>>>>>
        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns></returns>
        public static UOEAnswerAcs GetInstance()
        {
            if (_uOEAnswerAcs == null)
            {
                _uOEAnswerAcs = new UOEAnswerAcs();
            }
            return _uOEAnswerAcs;
        }
        // 2009/05/25 END   <<<<<<
        // --- ADD 2019/06/13 ---------->>>>>
        //操作履歴ログアクセスクラス
        private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;
        // --- ADD 2019/06/13 ----------<<<<<

		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//企業コード
		private string _enterpriseCode = "";

		//ログイン拠点コード
		private string _loginSectionCd = "";

		//ＵＯＥ発注データアクセスクラス
		private UOEOrderDtlAcs _uOEOrderDtlAcs = null;

		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        //ＵＯＥ送受信制御初期化クラス
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        // 2009/05/25 START >>>>>>
        //アクセスクラス インスタンス
        private static UOEAnswerAcs _uOEAnswerAcs = null;

        //UOE発注データ・仕入明細データ更新リモート
        private IIOWriteControlDB _iIOWriteControlDB = null;
        // 2009/05/25 END   <<<<<<
        # endregion

		// ===================================================================================== //
		// 定数群
		// ===================================================================================== //
		#region Public Const Member
		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region 送受信ＪＮＬ＜DataSet＞
        /// <summary>
        /// 送受信ＪＮＬ＜DataSet＞
        /// </summary>
        public DataSet UoeJnlDataSet
        {
            get { return this._uoeSndRcvJnlAcs.UoeJnlDataSet; }
        }
        # endregion

        # region 送受信ＪＮＬ(発注)＜DataTable＞
        /// <summary>
        /// 送受信ＪＮＬ(発注)＜DataTable＞
        /// </summary>
        public DataTable OrderTable
        {
            get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
        }
        # endregion

        # region UOE発注＜DataTable＞
        /// <summary>
        /// UOE発注＜DataTable＞
        /// </summary>
        public DataTable UOEOrderDtlTable
        {
            get { return this.UoeJnlDataSet.Tables[UOEOrderDtlSchema.CT_UOEOrderDtlDataTable]; }
        }
        # endregion

        # region 仕入データ＜DataTable＞
        /// <summary>
        /// 仕入データ＜DataTable＞
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region 仕入明細＜DataTable＞
        /// <summary>
        /// 仕入明細＜DataTable＞
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region 回答データの取得(正常終了分)
        /// <summary>
        /// 回答データの取得(正常終了分)
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <param name="stockSlipGrpList">仕入情報オブジェクト</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データオブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpDtAnswerNormal(UOESupplier uOESupplier, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // パラメータ初期化処理
                //-----------------------------------------------------------
                # region パラメータ初期化処理
                StockSlipGrp stockSlipGrp = new StockSlipGrp();
                # endregion

                //-----------------------------------------------------------
                // 送受信ＪＮＬのフィルタ・ソート設定
                //-----------------------------------------------------------
                # region 送受信ＪＮＬのフィルタ・ソート設定
                // viewを取得
                DataView view = GetOrderFormCreateView(0, 0, uOESupplier.UOESupplierCd);
                if ( view.Count == 0 ) return(status);

                Int32 uOESalesOrderNo = 0;
                Int32 savUOESalesOrderNo = 0;
                # endregion

                // ADD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 仕入日設定 (UOE発注データから、売上日付を設定)
                DateTime stockDate = DateTime.Now;
                // ADD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach (DataRowView dr in view)
                {
                    //-----------------------------------------------------------
                    // ＵＯＥ発注DataTableのFIND処理
                    //-----------------------------------------------------------
                    # region ＵＯＥ発注DataTableのFIND処理
                    // ＵＯＥ発注DataTableのFIND処理
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = uOESupplier.UOESupplierCd;
                    findUOEOrderDtl[1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    findUOEOrderDtl[2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo];
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);
                    if (uOEOrderDtlRow == null) continue;

                    //ＫＥＹ項目の取得
                    uOESalesOrderNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];           //UOE発注番号
                    Int32 uOESalesOrderRowNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];  // UOE発注行番号
                    Int32 dataSendCode = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode];	        // データ送信区分
                    Int32 dataRecoverDiv = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv];	    // データ復旧区分

                    string substPartsNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo];         //代替品番
                    Int32 answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd];         //回答メーカーコード

                    # endregion

                    //-----------------------------------------------------------
                    //  ＪＮＬ→ＵＯＥ発注データの設定(正常終了分)
                    //-----------------------------------------------------------
                    # region  ＪＮＬ→ＵＯＥ発注データの設定(正常終了分)
                    # region 代替品番のﾊｲﾌﾝ付品番への置き換え処理
                    //代替品番のﾊｲﾌﾝ付品番への置き換え処理
                    //代替品番が存在
                    //代替品番にハイフンなし
                    if ((substPartsNo.Trim() != "") && (substPartsNo.IndexOf("-") == -1))
                    {
                        List<GoodsUnitData> list = null;
                        //status = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list); // DEL 2014/09/19 劉超 FOR Redmine#43265
                        // ------ ADD START 2014/09/19 劉超 FOR Redmine#43265 ------>>>>>
                        List<Int32> makerCdLt = _uoeSndRcvCtlInitAcs.GetMakerCdLt(uOESupplier);
                        if (makerCdLt.Count == 0 && int.Parse(uOESupplier.CommAssemblyId) >= 1000)
                        {
                            status = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list, answerMakerCd);
                        }
                        else
                        {
                            status = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list);
                        }
                        // ------ ADD END 2014/09/19 劉超 FOR Redmine#43265 ------<<<<<
                        //選択なし
                        //該当品番なし
                        if ((status == -1) || (status == 1) || (list == null))
                        {
                            answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd];	//発注時メーカーコード
                            status = 0;
                        }
                        //該当品番あり
                        else if (list.Count > 0)
                        {
                            substPartsNo = list[0].GoodsNo;			//品番
                            answerMakerCd = list[0].GoodsMakerCd;	//メーカーコード
                        }
                    }
                    # endregion

                    # region 入庫更新フラグ(1:入庫済)の設定
                    //初期処理
                    int enterUpdDivSec = 0;		//拠点
                    int enterUpdDivBO1 = 0;		//BO1
                    int enterUpdDivBO2 = 0;		//BO2
                    int enterUpdDivBO3 = 0;		//BO3
                    int enterUpdDivMaker = 0;	//ﾒｰｶｰ
                    int enterUpdDivEO = 0;		//EO

                    //システム区分
                    Int32 systemDivCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SystemDivCd];

                    //入庫更新フラグ(1:入庫済)の設定
                    int warehouseCode = 0;
                    UoeCommonFnc.ToInt32FromString((string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseCode], out warehouseCode);

                    //発注先が明治産業の場合(仕入データ受信区分＝1:有り)
                    //システム区分＝伝発発注分
                    //システム区分＝（手入力、検索発注）の取寄品
                    if((this._uoeSndRcvJnlAcs.ChkMeiji(uOESupplier) == true)
                    || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                    || (((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                    || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search))
                        && (warehouseCode == 0)))
                    {
                        enterUpdDivSec = 1;		//拠点
                        enterUpdDivBO1 = 1;		//BO1
                        enterUpdDivBO2 = 1;		//BO2
                        enterUpdDivBO3 = 1;		//BO3
                        enterUpdDivMaker = 1;	//ﾒｰｶｰ
                        enterUpdDivEO = 1;		//EO
                    }
                    //システム区分＝（手入力、検索発注の在庫品）
                    //システム区分＝在庫一括
                    else if ((((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)
                            || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)) && (warehouseCode != 0))
                            || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Lump))
                    {
                        //拠点
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] == 0) enterUpdDivSec = 1;
                        //BO1
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] == 0) enterUpdDivBO1 = 1;
                        //BO2
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] == 0) enterUpdDivBO2 = 1;
                        //BO3
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] == 0) enterUpdDivBO3 = 1;
                        //ﾒｰｶｰ
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] == 0) enterUpdDivMaker = 1;
                        //EO
                        if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] == 0) enterUpdDivEO = 1;
                    }
                    # endregion

                    # region 送受信ＪＮＬDataTable設定処理
                    //送受信ＪＮＬDataTable設定処理
                    dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = answerMakerCd;	// 回答メーカーコード
                    dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = substPartsNo;	// 代替品番
                    # endregion

                    # region ＵＯＥ発注DataTable設定処理
                    //UOE回答データ部
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveDate] = (DateTime)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveDate];	// 受信日付
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveTime] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveTime];	// 受信時刻
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = answerMakerCd;	// 回答メーカーコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo];	// 回答品番
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName];	// 回答品名
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = substPartsNo;	// 代替品番
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE拠点出庫数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];	// BO出庫数1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2];	// BO出庫数2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3];	// BO出庫数3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt];	// メーカーフォロー数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt];	// 未出庫数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt];	// UOE拠点在庫数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount1];	// BO在庫数1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount2];	// BO在庫数2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount3];	// BO在庫数3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo];	// UOE拠点伝票番号
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1];	// BO伝票番号１
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2];	// BO伝票番号２
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3];	// BO伝票番号３
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount];	// EO引当数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOManagementNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOManagementNo];	// BO管理番号
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice];	// 回答定価
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];	// 回答原価単価
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESubstMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESubstMark];	// UOE代替マーク
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEStockMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEStockMark];	// UOE在庫マーク
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd];	// 層別コード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE出荷拠点コード１（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE出荷拠点コード２（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE出荷拠点コード３（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1];	// UOE拠点コード１（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2];	// UOE拠点コード２（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3];	// UOE拠点コード３（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4];	// UOE拠点コード４（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5];	// UOE拠点コード５（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6];	// UOE拠点コード６（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7];	// UOE拠点コード７（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE在庫数１（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE在庫数２（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE在庫数３（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE在庫数４（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE在庫数５（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE在庫数６（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE在庫数７（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd];	// UOE卸コード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd];	// UOE他コード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEHMCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEHMCd];	// UOEＨＭコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOCount];	// ＢＯ数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode];	// UOEマークコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SourceShipment] = (string)dr[OrderSndRcvJnlSchema.ct_Col_SourceShipment];	// 出荷元
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ItemCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_ItemCode];	// アイテムコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOECheckCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOECheckCode];	// UOEチェックコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage];	// ヘッドエラーメッセージ
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage];	// ラインエラーメッセージ

                    //データ区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode] = dataSendCode;	// データ送信区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = dataRecoverDiv;	// データ復旧区分

                    //入庫更新区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = enterUpdDivSec;	// 拠点
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = enterUpdDivBO1;	// BO1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = enterUpdDivBO2;	// BO2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = enterUpdDivBO3;	// BO3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = enterUpdDivMaker;	// ﾒｰｶｰ
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = enterUpdDivEO;	// EO
                    # endregion

                    # region ＵＯＥ発注(DataTable→UOEOrderDtlWork)
                    UOEOrderDtlWork uOEOrderDtlWork = _uoeSndRcvJnlAcs.CreateUOEOrderDtlWorkFromSchema(ref uOEOrderDtlRow);
                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    # endregion
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入データの作成
                    //-----------------------------------------------------------
                    # region 仕入データ作成
                    // UOE発注番号が変わった場合
                    if ((savUOESalesOrderNo != 0)
                    && (uOESalesOrderNo != 0)
                    && (uOESalesOrderNo != savUOESalesOrderNo))
                    {
                        //仕入データＷｏｒｋの作成
                        StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                                                                uOESupplier.UOESupplierCd,
                                                                savUOESalesOrderNo,
                                                                out message);
                        if (stockSlipWork == null)
                        {
                            return (-1);
                        }

                        //リスト追加
                        stockSlipGrp.stockSlipWork = stockSlipWork;
                        stockSlipGrpList.Add(stockSlipGrp);
                        stockSlipGrp = new StockSlipGrp();
                    }
                    //現在処理中のUOE発注番号を保存
                    savUOESalesOrderNo = uOESalesOrderNo;
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入明細の作成
                    //-----------------------------------------------------------
                    # region 仕入明細の作成
                    # region 仕入明細(ＪＮＬ→DataTable)
                    //ＵＯＥ発注先の送信区分＝正常 復旧区分＝復旧対象外のレコードのみ仕入明細の更新を実施
                    //if ((dataSendCode != (int)EnumUoeConst.ctDataSendCode.ct_OK)
                    //|| (dataRecoverDiv != (int)EnumUoeConst.ctDataRecoverDiv.ct_NO))
                    //{
                    //    continue;
                    //}

                    // ＪＮＬ→仕入明細
                    object[] findStockDetail = new object[2];
                    findStockDetail[0] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SupplierFormal];
                    findStockDetail[1] = (Guid)dr[OrderSndRcvJnlSchema.ct_Col_DtlRelationGuid];
                    DataRow stockDetailRow = StockDetailTable.Rows.Find(findStockDetail);
                    if (stockDetailRow == null) continue;

                    // 仕入先情報の取得
                    int supplierCd = (int)stockDetailRow[StockDetailSchema.ct_Col_SupplierCd];
                    Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(supplierCd);

                    //共通伝票番号の設定
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipNo] = uOESalesOrderNo;

                    //共通伝票行番号の設定
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipRowNo] = uOESalesOrderRowNo;

                    //-----------------------------------------------------------
                    // 発注数
                    //-----------------------------------------------------------
                    #region 発注数の設定
                    //発注数の設定
                    Int32 cnt = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt]
                                + (Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount];
                    stockDetailRow[StockDetailSchema.ct_Col_OrderCnt] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_StockCount] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_OrderRemainCnt] = (double)cnt;
                    #endregion

                    //-----------------------------------------------------------
                    // 課税区分の算出(0:課税,1:非課税,2:課税（内税）)
                    //-----------------------------------------------------------
                    #region 課税区分の算出
                    int dstTaxationCode = (int)stockDetailRow[StockDetailSchema.ct_Col_TaxationCode];

                    if ((supplier.SuppCTaxLayCd == 9)
                    || (supplier.SuppCTaxationCd == 1)
                    || (dstTaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        dstTaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // 定価
                    //-----------------------------------------------------------
                    #region 定価
                    // DEL 2014/02/12 吉岡 #41551 システムテスト障害№10 デグレ対応 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    // ADD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 仕入日設定 (UOE発注データから、売上日付を設定)
                    //if (uOEOrderDtlWork != null && uOEOrderDtlWork.SalesDate != DateTime.MinValue)
                    //{
                    //    stockDate = uOEOrderDtlWork.SalesDate;
                    //}
                    // ADD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    # endregion
                    // DEL 2014/02/12 吉岡 #41551 システムテスト障害№10 デグレ対応 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2014/02/12 吉岡 #41551 システムテスト障害№10 デグレ対応 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 仕入日設定 (UOE発注データから、売上日付を設定)
                    // 伝発計上日 マシン日付：０　売伝日付：１
                    if (_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv.Equals(1))
                    {
                        if (uOEOrderDtlWork != null && uOEOrderDtlWork.SalesDate != DateTime.MinValue)
                        {
                            stockDate = uOEOrderDtlWork.SalesDate;
                        }
                    }
                    // ADD 2014/02/12 吉岡 #41551 システムテスト障害№10 デグレ対応 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    
                    //定価（税抜，浮動）
                    double dstPrice = (double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice];
                    
                    stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = dstPrice;
                    
                    //定価（税込，浮動）
                    if(supplier != null)
                    {
                        // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                        stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd, stockDate);
                        // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }   
                    #endregion

                    //-----------------------------------------------------------
                    // 仕入単価変更区分
                    //-----------------------------------------------------------
                    #region 仕入単価変更区分
                    //仕入単価変更区分
                    //変更前原価と回答原価が異なる

                    double srcCost = (double)stockDetailRow[StockDetailSchema.ct_Col_BfStockUnitPriceFl];
                    double dstCost = (double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];

                    if(srcCost != dstCost)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 1;
                    }
                    //変更前原価と回答原価が同一
                    else
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 0;
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // 仕入単価
                    //-----------------------------------------------------------
                    #region 仕入単価
                    //仕入単価（税抜，浮動）
                    stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl] = (double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];

                    //仕入単価（税込，浮動）
                    if (supplier != null)
                    {
                        // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // stockDetailRow[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd, stockDate);
                        // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // 仕入金額の算出
                    //-----------------------------------------------------------
                    #region 仕入金額
                    if (supplier != null)
                    {
                        long stockPriceTaxInc = 0;
                        long stockPriceTaxExc = 0;
                        long stockPriceConsTax = 0;

                        // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                        //    (double)cnt,
                        //    (double)stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl],
                        //    dstTaxationCode,
                        //    supplier.StockMoneyFrcProcCd,
                        //    supplier.StockCnsTaxFrcProcCd,
                        //    out stockPriceTaxInc,
                        //    out stockPriceTaxExc,
                        //    out stockPriceConsTax);
                        #endregion
                        bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                            (double)cnt,
                            (double)stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl],
                            dstTaxationCode,
                            supplier.StockMoneyFrcProcCd,
                            supplier.StockCnsTaxFrcProcCd,
                            stockDate,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax);
                        // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

                        if (bStatus == true)
                        {
                            //仕入金額（税抜き）
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = stockPriceTaxExc;

                            //仕入金額（税込み）
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = stockPriceTaxInc;
                        }
                        else
                        {
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = 0;
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = 0;
                        }
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // 消費税の算出
                    //-----------------------------------------------------------
                    #region 消費税
                    //仕入金額消費税額
                    stockDetailRow[StockDetailSchema.ct_Col_StockPriceConsTax] = (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc]
                                                                               - (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc];
                    #endregion

                    # endregion

                    # region 仕入明細(DataTable→StockDetailWork)
                    StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(stockDetailRow);
                    stockSlipGrp.stockDetailWorkList.Add(stockDetailWork);
                    # endregion
                    # endregion
                }
                //-----------------------------------------------------------
                // 仕入データの作成
                //-----------------------------------------------------------
                # region 仕入データ作成
                if((savUOESalesOrderNo != 0) && (uOESalesOrderNo != 0))
                {
                    //仕入データＷｏｒｋの作成
                    // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                    //                    uOESupplier.UOESupplierCd,
                    //                    savUOESalesOrderNo,
                    //                    out message);
                    StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                                                            uOESupplier.UOESupplierCd,
                                                            savUOESalesOrderNo,
                                                            out message,
                                                            stockDate);
                    // UPD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

                    if (stockSlipWork == null)
                    {
                        return (-1);
                    }

                    //リスト追加
                    stockSlipGrp.stockSlipWork = stockSlipWork;
                    stockSlipGrpList.Add(stockSlipGrp);
                    stockSlipGrp = new StockSlipGrp();
                }
                # endregion

            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
        }
        # endregion


		# region 回答データの取得(復旧対象分)
        /// <summary>
        /// 回答データの取得(復旧対象分)
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データオブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpDtAnswerRecover(UOESupplier uOESupplier, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // 送受信ＪＮＬのフィルタ・ソート設定
                //-----------------------------------------------------------
                # region 送受信ＪＮＬのフィルタ・ソート設定
                // viewを取得
                DataView view = GetOrderFormCreateView(1, 0, uOESupplier.UOESupplierCd);
                if ( view.Count == 0 ) return(status);
                # endregion

                foreach (DataRowView dr in view)
                {
                    //-----------------------------------------------------------
                    // ＵＯＥ発注DataTableのFIND処理
                    //-----------------------------------------------------------
                    # region ＵＯＥ発注DataTableのFIND処理
                    // ＵＯＥ発注DataTableのFIND処理
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = uOESupplier.UOESupplierCd;
                    findUOEOrderDtl[1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    findUOEOrderDtl[2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo];
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);
                    if (uOEOrderDtlRow == null) continue;

                    //ＫＥＹ項目の取得
                    Int32 dataSendCode = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode];	        // データ送信区分
                    Int32 dataRecoverDiv = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv];	    // データ復旧区分
                    # endregion

                    //-----------------------------------------------------------
                    //  ＪＮＬ→ＵＯＥ発注データの設定(復旧対象分)
                    //-----------------------------------------------------------
                    # region  ＪＮＬ→ＵＯＥ発注データの設定(復旧対象分)
                    # region ＵＯＥ発注DataTable設定処理
                    //ＵＯＥ発注DataTable設定処理
                    //UOE発注データ部
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SendTerminalNo] = 0;	// 送信端末番号のクリア

                    //データ区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode] = dataSendCode;	// データ送信区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = dataRecoverDiv;	// データ復旧区分
                    # endregion

                    # region ＵＯＥ発注(DataTable→UOEOrderDtlWork)
                    UOEOrderDtlWork uOEOrderDtlWork = _uoeSndRcvJnlAcs.CreateUOEOrderDtlWorkFromSchema(ref uOEOrderDtlRow);
                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    # endregion
                    # endregion
                }

            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
        }
        # endregion

		# region 回答データの更新処理
		/// <summary>
		/// 回答データ更新処理
		/// </summary>
		/// <param name="orderSndRcvJnlList">送受信ＪＮＬクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>0:正常 0以外:エラー</returns>
		public int UpDtAnswer(UOESupplier uOESupplier, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // パラメータ初期化処理
                //-----------------------------------------------------------
                # region パラメータ初期化処理
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();
                # endregion

                //-----------------------------------------------------------
                // 回答データの取得(正常終了分)
                //-----------------------------------------------------------
                # region 回答データの取得(正常終了分)
                status = UpDtAnswerNormal(uOESupplier, ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 回答データの取得(復旧対象分)
                //-----------------------------------------------------------
                # region 回答データの取得(復旧対象分)
                status = UpDtAnswerRecover(uOESupplier, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 回答データ更新処理
                //-----------------------------------------------------------
                # region 回答データ更新処理
                status = _uOEOrderDtlAcs.Write(ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 更新結果→Datatable
                //-----------------------------------------------------------
                # region 更新結果→Datatable
                if((stockSlipGrpList == null) || (uOEOrderDtlWorkList == null))
                {
                    return (status);
                }
                if ((stockSlipGrpList.Count == 0) && (uOEOrderDtlWorkList.Count == 0))
                {
                    return (status);
                }

                //ＵＯＥ発注データ→ＵＯＥ発注データテーブルの更新 
                status = _uoeSndRcvJnlAcs.UpdateTableFromUOEOrderDtlList(uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                foreach (StockSlipGrp grp in stockSlipGrpList)
                {
                    //仕入明細→仕入明細テーブルの更新
                    // --- ADD 2019/06/13 ---------->>>>>
                    string asseNm = "入庫更新";
                    string procNm = "UpDtAnswer";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "", uOESupplier.UOESupplierCd);
                    // --- ADD 2019/06/13 ----------<<<<<
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailList(StockDetailTable, grp.stockDetailWorkList, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    // --- ADD 2019/06/13 ---------->>>>>
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "", uOESupplier.UOESupplierCd);
                    // --- ADD 2019/06/13 ----------<<<<<

                    //仕入データ→仕入データテーブルの更新
                    if (grp.stockSlipWork != null)
                    {
                        //仕入明細より共通伝票番号を取得
                        StockDetailWork work = null;
                        string commonSlipNo = "";

                        status = _uoeSndRcvJnlAcs.ReadStockDetailWork(
                                        StockDetailTable,
                                        grp.stockDetailWorkList[0].SupplierFormal,
                                        grp.stockDetailWorkList[0].DtlRelationGuid,
                                        out work,
                                        out commonSlipNo,
                                        out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }

                        status = _uoeSndRcvJnlAcs.UpdateTableFromStockSlipWork(StockSlipTable, grp.stockSlipWork, commonSlipNo, out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }
                    }
                }
                # endregion
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 仕入データ作成(DataTable)

        // ADD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入データ作成(DataTable)
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="stockDate">仕入日</param>
        /// <returns>スタータス</returns>
        private StockSlipWork GetStockSlipWorkFromStockDetailDataTable(int uOESupplierCd, int uOESalesOrderNo, out string message, DateTime stockDate)
        {
            //変数の初期化
            StockSlipWork rst = new StockSlipWork();
            message = "";

            try
            {
                //-----------------------------------------------------------
                // 仕入明細の取得
                //-----------------------------------------------------------
                # region 仕入明細の取得
                DataView view = GetStockDetailFormCreateView(uOESupplierCd, uOESalesOrderNo);
                int detailCount = view.Count;
                if (detailCount == 0) return (null);

                List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                StockDetailWork stockDetailWork = null;
                foreach (DataRowView dataRowView in view)
                {
                    stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowView.Row);
                    uoeStockDetailWorkList.Add(stockDetailWork);
                }
                #endregion

                //-----------------------------------------------------------
                // 送受信ＪＮＬの取得
                //-----------------------------------------------------------
                # region 送受信ＪＮＬの取得
                DataView orderView = GetOrderFormCreateView(uOESupplierCd, uOESalesOrderNo);
                if (orderView == null) return (null);
                if (orderView.Count == 0) return (null);
                DataRow uOEOrderDtlRow = orderView[0].Row;
                #endregion

                //-----------------------------------------------------------
                // 全体初期値設定マスタの取得
                //-----------------------------------------------------------
                AllDefSet allDefSet = _uoeSndRcvCtlInitAcs.GetAllDefSet();

                //-----------------------------------------------------------
                // 仕入先情報の取得
                //-----------------------------------------------------------
                #region 仕入先情報の設定
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(stockDetailWork.SupplierCd);
                if (supplier == null)
                {
                    message = "仕入先が存在しません。";
                    return (null);
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入データの設定
                //-----------------------------------------------------------
                # region 仕入データの設定
                rst.EnterpriseCode = this._enterpriseCode;                                  // 企業コード
                rst.SupplierFormal = 2;	                                                    // 仕入形式　＝　2:発注
                rst.SupplierSlipNo = stockDetailWork.SupplierSlipNo;	                    // 仕入伝票番号
                rst.SectionCode = this._loginSectionCd;	                                    // 拠点コード
                rst.SubSectionCode = stockDetailWork.SubSectionCode;	                    // 部門コード
                rst.DebitNoteDiv = 0;	                                                    // 赤伝区分 ＝　0:黒伝
                rst.DebitNLnkSuppSlipNo = 0;	                                            // 赤黒連結仕入伝票番号
                rst.SupplierSlipCd = 10;	                                                // 仕入伝票区分　＝　10:仕入
                rst.StockGoodsCd = 0;	                                                    // 仕入商品区分　＝　0:商品
                rst.AccPayDivCd = 1;	                                                    // 買掛区分　＝　1:買掛
                rst.StockSectionCd = _loginSectionCd;	                                    // 仕入拠点コード
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // 仕入計上拠点コード
                rst.StockSlipUpdateCd = 0;	                                                // 仕入伝票更新区分 0:未更新
                rst.InputDay = DateTime.Now;	                                            // 入力日　＝　システム日付
                rst.ArrivalGoodsDay = DateTime.MinValue;	                                // 入荷日
                rst.StockDate = DateTime.MinValue;	                                        // 仕入日
                rst.StockAddUpADate = DateTime.MinValue;	                                // 仕入計上日付
                rst.DelayPaymentDiv = 0;	                                                // 来勘区分 0:当月
                rst.PayeeCode = supplier.PayeeCode;                                         // 支払先コード

                Supplier payee = _uoeSndRcvCtlInitAcs.GetSupplier(supplier.PayeeCode);      // 支払先略称
                rst.PayeeSnm = payee.SupplierSnm;	                                        // 

                rst.SupplierCd = stockDetailWork.SupplierCd;	                            // 仕入先コード
                rst.SupplierNm1 = supplier.SupplierNm1;                                     // 仕入先名1
                rst.SupplierNm2 = supplier.SupplierNm2;                                     // 仕入先名2
                rst.SupplierSnm = supplier.SupplierSnm;                                     // 仕入先略称
                rst.BusinessTypeCode = supplier.BusinessTypeCode;	                        // 業種コード
                rst.BusinessTypeName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(33, supplier.BusinessTypeCode);            // 業種名称

                rst.SalesAreaCode = supplier.SalesAreaCode;	                                // 販売エリアコード
                rst.SalesAreaName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(21, supplier.SalesAreaCode);	// 販売エリア名称

                rst.StockInputCode = stockDetailWork.StockInputCode;	                    // 仕入入力者コード
                rst.StockInputName = stockDetailWork.StockInputName;	                    // 仕入入力者名称
                rst.StockAgentCode = stockDetailWork.StockAgentCode;	                    // 仕入担当者コード
                rst.StockAgentName = stockDetailWork.StockAgentName;	                    // 仕入担当者名称

                rst.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;	                    // 仕入先総額表示方法区分
                rst.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;	                    // 総額表示掛率適用区分


                rst.TaxAdjust = 0;	                                                        // 消費税調整額
                rst.BalanceAdjust = 0;	                                                    // 残高調整額
                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // 仕入先消費税転嫁方式コード
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(stockDate) ;	    // 仕入先消費税税率
                rst.AccPayConsTax = 0;	                                                    // 買掛消費税

                // 仕入データの情報算出
                //仕入端数処理区分
                //1:切捨て,2:四捨五入,3:切上げ　（消費税）
                //端数処理単位
                StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                            1,
                                                            supplier.StockCnsTaxFrcProcCd,
                                                            999999999);
                rst.StockFractionProcCd = stockProcMoney.FractionProcCd;                    //仕入端数処理区分

                rst.AutoPayment = 0;	                                                    // 自動支払区分 0：通常支払
                rst.AutoPaySlipNum = 0;	                                                    // 自動支払伝票番号
                rst.RetGoodsReasonDiv = 0;	                                                // 返品理由コード
                rst.RetGoodsReason = string.Empty;	                                        // 返品理由
                rst.PartySaleSlipNum = string.Empty;	                                    // 相手先伝票番号
                rst.SupplierSlipNote1 = string.Empty;	                                    // 仕入伝票備考1
                rst.SupplierSlipNote2 = string.Empty;	                                    // 仕入伝票備考2
                rst.DetailRowCount = detailCount;	                                        // 明細行数　＝　行数カウント値
                rst.EdiSendDate = DateTime.MinValue;	                                    // ＥＤＩ送信日
                rst.EdiTakeInDate = DateTime.MinValue;	                                    // ＥＤＩ取込日
                rst.UoeRemark1 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark1];// ＵＯＥリマーク１
                rst.UoeRemark2 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark2];// ＵＯＥリマーク２
                rst.SlipPrintDivCd = 0;	                                                    // 伝票発行区分
                rst.SlipPrintFinishCd = 0;	                                                // 伝票発行済区分
                rst.StockSlipPrintDate = DateTime.MinValue;	                                // 仕入伝票発行日
                rst.SlipPrtSetPaperId = string.Empty;	                                    // 伝票印刷設定用帳票ID
                rst.SlipAddressDiv = 2;	                                                    // 伝票住所区分　＝　2:納入先
                rst.AddresseeCode = 0;	                                                    // 納品先コード
                rst.AddresseeName = string.Empty;	                                        // 納品先名称
                rst.AddresseeName2 = string.Empty;	                                        // 納品先名称2
                rst.AddresseePostNo = string.Empty;	                                        // 納品先郵便番号
                rst.AddresseeAddr1 = string.Empty;	                                        // 納品先住所1(都道府県市区郡・町村・字)
                rst.AddresseeAddr3 = string.Empty;	                                        // 納品先住所3(番地)
                rst.AddresseeAddr4 = string.Empty;	                                        // 納品先住所4(アパート名称)
                rst.AddresseeTelNo = string.Empty;	                                        // 納品先電話番号
                rst.AddresseeFaxNo = string.Empty;	                                        // 納品先FAX番号
                rst.DirectSendingCd = stockDetailWork.DirectSendingCd;	                    // 直送区分

                // 仕入データの情報算出
                StockSlipPriceCalculator.TotalPriceSetting(
                                            ref rst,
                                            uoeStockDetailWorkList,
                                            stockProcMoney.FractionProcUnit,
                                            stockProcMoney.FractionProcCd);
                #endregion
            }
            catch (Exception ex)
            {
                message = ex.Message;
                rst = null;
            }
            return (rst);
        }
        // ADD 2014/02/04 吉岡 #41551 システムテスト障害№10 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 仕入データ作成(DataTable)
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>スタータス</returns>
        private StockSlipWork GetStockSlipWorkFromStockDetailDataTable(int uOESupplierCd, int uOESalesOrderNo, out string message)
        {
            //変数の初期化
            StockSlipWork rst = new StockSlipWork();
  			message = "";

            try
            {
                //-----------------------------------------------------------
                // 仕入明細の取得
                //-----------------------------------------------------------
                # region 仕入明細の取得
                DataView view = GetStockDetailFormCreateView(uOESupplierCd, uOESalesOrderNo);
                int detailCount = view.Count;
                if (detailCount == 0) return (null);

                List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                StockDetailWork stockDetailWork = null;
                foreach (DataRowView dataRowView in view)
                {
                    stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowView.Row);
                    uoeStockDetailWorkList.Add(stockDetailWork);
                }
                #endregion

                //-----------------------------------------------------------
                // 送受信ＪＮＬの取得
                //-----------------------------------------------------------
                # region 送受信ＪＮＬの取得
                DataView orderView = GetOrderFormCreateView(uOESupplierCd, uOESalesOrderNo);
                if (orderView == null)  return(null);
                if (orderView.Count == 0)  return(null);
                DataRow uOEOrderDtlRow = orderView[0].Row;
                #endregion

                //-----------------------------------------------------------
                // 全体初期値設定マスタの取得
                //-----------------------------------------------------------
                AllDefSet allDefSet = _uoeSndRcvCtlInitAcs.GetAllDefSet();

                //-----------------------------------------------------------
                // 仕入先情報の取得
                //-----------------------------------------------------------
                #region 仕入先情報の設定
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(stockDetailWork.SupplierCd);
                if (supplier == null)
                {
                    message = "仕入先が存在しません。";
                    return (null);
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入データの設定
                //-----------------------------------------------------------
                # region 仕入データの設定
                rst.EnterpriseCode = this._enterpriseCode;                                  // 企業コード
                rst.SupplierFormal = 2;	                                                    // 仕入形式　＝　2:発注
                rst.SupplierSlipNo = stockDetailWork.SupplierSlipNo;	                    // 仕入伝票番号
                rst.SectionCode = this._loginSectionCd;	                                    // 拠点コード
                rst.SubSectionCode = stockDetailWork.SubSectionCode;	                    // 部門コード
                rst.DebitNoteDiv = 0;	                                                    // 赤伝区分 ＝　0:黒伝
                rst.DebitNLnkSuppSlipNo = 0;	                                            // 赤黒連結仕入伝票番号
                rst.SupplierSlipCd = 10;	                                                // 仕入伝票区分　＝　10:仕入
                rst.StockGoodsCd = 0;	                                                    // 仕入商品区分　＝　0:商品
                rst.AccPayDivCd = 1;	                                                    // 買掛区分　＝　1:買掛
                rst.StockSectionCd = _loginSectionCd;	                                    // 仕入拠点コード
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // 仕入計上拠点コード
                rst.StockSlipUpdateCd = 0;	                                                // 仕入伝票更新区分 0:未更新
                rst.InputDay = DateTime.Now;	                                            // 入力日　＝　システム日付
                rst.ArrivalGoodsDay = DateTime.MinValue;	                                // 入荷日
                rst.StockDate = DateTime.MinValue;	                                        // 仕入日
                rst.StockAddUpADate = DateTime.MinValue;	                                // 仕入計上日付
                rst.DelayPaymentDiv = 0;	                                                // 来勘区分 0:当月
                rst.PayeeCode = supplier.PayeeCode;                                         // 支払先コード

                Supplier payee = _uoeSndRcvCtlInitAcs.GetSupplier(supplier.PayeeCode);      // 支払先略称
                rst.PayeeSnm = payee.SupplierSnm;	                                        // 

                rst.SupplierCd = stockDetailWork.SupplierCd;	                            // 仕入先コード
                rst.SupplierNm1 = supplier.SupplierNm1;                                     // 仕入先名1
                rst.SupplierNm2 = supplier.SupplierNm2;                                     // 仕入先名2
                rst.SupplierSnm = supplier.SupplierSnm;                                     // 仕入先略称
                rst.BusinessTypeCode = supplier.BusinessTypeCode;	                        // 業種コード
                rst.BusinessTypeName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(33, supplier.BusinessTypeCode);            // 業種名称

                rst.SalesAreaCode = supplier.SalesAreaCode;	                                // 販売エリアコード
                rst.SalesAreaName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(21,supplier.SalesAreaCode);	// 販売エリア名称

                rst.StockInputCode = stockDetailWork.StockInputCode;	                    // 仕入入力者コード
                rst.StockInputName = stockDetailWork.StockInputName;	                    // 仕入入力者名称
                rst.StockAgentCode = stockDetailWork.StockAgentCode;	                    // 仕入担当者コード
                rst.StockAgentName = stockDetailWork.StockAgentName;	                    // 仕入担当者名称

                rst.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;	                    // 仕入先総額表示方法区分
                rst.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;	                    // 総額表示掛率適用区分


                rst.TaxAdjust = 0;	                                                        // 消費税調整額
                rst.BalanceAdjust = 0;	                                                    // 残高調整額
                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // 仕入先消費税転嫁方式コード
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);;	// 仕入先消費税税率
                rst.AccPayConsTax = 0;	                                                    // 買掛消費税

                // 仕入データの情報算出
                //仕入端数処理区分
                //1:切捨て,2:四捨五入,3:切上げ　（消費税）
                //端数処理単位
                StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                            1,
                                                            supplier.StockCnsTaxFrcProcCd,
                                                            999999999);
                rst.StockFractionProcCd = stockProcMoney.FractionProcCd;                    //仕入端数処理区分

                rst.AutoPayment = 0;	                                                    // 自動支払区分 0：通常支払
                rst.AutoPaySlipNum = 0;	                                                    // 自動支払伝票番号
                rst.RetGoodsReasonDiv = 0;	                                                // 返品理由コード
                rst.RetGoodsReason = string.Empty;	                                        // 返品理由
                rst.PartySaleSlipNum = string.Empty;	                                    // 相手先伝票番号
                rst.SupplierSlipNote1 = string.Empty;	                                    // 仕入伝票備考1
                rst.SupplierSlipNote2 = string.Empty;	                                    // 仕入伝票備考2
                rst.DetailRowCount = detailCount;	                                        // 明細行数　＝　行数カウント値
                rst.EdiSendDate = DateTime.MinValue;	                                    // ＥＤＩ送信日
                rst.EdiTakeInDate = DateTime.MinValue;	                                    // ＥＤＩ取込日
                rst.UoeRemark1 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark1];// ＵＯＥリマーク１
                rst.UoeRemark2 = (string)uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark2];// ＵＯＥリマーク２
                rst.SlipPrintDivCd = 0;	                                                    // 伝票発行区分
                rst.SlipPrintFinishCd = 0;	                                                // 伝票発行済区分
                rst.StockSlipPrintDate = DateTime.MinValue;	                                // 仕入伝票発行日
                rst.SlipPrtSetPaperId = string.Empty;	                                    // 伝票印刷設定用帳票ID
                rst.SlipAddressDiv = 2;	                                                    // 伝票住所区分　＝　2:納入先
                rst.AddresseeCode = 0;	                                                    // 納品先コード
                rst.AddresseeName = string.Empty;	                                        // 納品先名称
                rst.AddresseeName2 = string.Empty;	                                        // 納品先名称2
                rst.AddresseePostNo = string.Empty;	                                        // 納品先郵便番号
                rst.AddresseeAddr1 = string.Empty;	                                        // 納品先住所1(都道府県市区郡・町村・字)
                rst.AddresseeAddr3 = string.Empty;	                                        // 納品先住所3(番地)
                rst.AddresseeAddr4 = string.Empty;	                                        // 納品先住所4(アパート名称)
                rst.AddresseeTelNo = string.Empty;	                                        // 納品先電話番号
                rst.AddresseeFaxNo = string.Empty;	                                        // 納品先FAX番号
                rst.DirectSendingCd = stockDetailWork.DirectSendingCd;	                    // 直送区分

                // 仕入データの情報算出
                StockSlipPriceCalculator.TotalPriceSetting(
                                            ref rst,
                                            uoeStockDetailWorkList,
                                            stockProcMoney.FractionProcUnit,
                                            stockProcMoney.FractionProcCd);
                #endregion
            }
			catch (Exception ex)
			{
				message = ex.Message;
                rst = null;
			}
            return (rst);
        }

        # endregion

        # region 仕入明細の抽出
        /// <summary>
        /// 仕入明細の抽出
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns>回答更新対象データ</returns>
        private DataView GetStockDetailFormCreateView(int uOESupplierCd, int uOESalesOrderNo)
        {
            DataView view = new DataView(this.StockDetailTable);

            // フィルター設定
            string rowFilterText = string.Format("{0} = {1}",
                                            StockDetailSchema.ct_Col_CommonSlipNo, uOESalesOrderNo            
                                            );
            view.RowFilter = rowFilterText;

            // ソート順設定
            string sortText = string.Format("{0}, {1}",
                                            StockDetailSchema.ct_Col_CommonSlipNo,
                                            StockDetailSchema.ct_Col_CommonSlipRowNo
                                            );
            view.Sort = sortText;

            return view;
        }
        # endregion

        # region 回答更新対象データの抽出
        /// <summary>
        /// 回答更新対象データの抽出
        /// </summary>
        /// <param name="filterMode">0:正常終了 1:復旧対象</param>
        /// <param name="uOEKind">UOE種別</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns>回答更新対象データ</returns>
        private DataView GetOrderFormCreateView(int filterMode, int uOEKind, int uOESupplierCd)
        {
            DataView view = new DataView(this.OrderTable);
            string rowFilterText = "";

            // フィルター設定
            // 「UOE種別+UOE発注先コード+データ送信区分+データ復旧区分」でフィルタをかける
            //正常終了
            if (filterMode == 0)
            {
                rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} <> {5} AND {6} <> {7} AND {8} = {9}",
                                                OrderSndRcvJnlSchema.ct_Col_UOEKind, uOEKind,
                                                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_NonProcess,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process,
                                                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO
                                                );
            }
            //復旧対象
            else
            {
                rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} <> {5} AND {6} <> {7} AND {8} = {9}",
                                                OrderSndRcvJnlSchema.ct_Col_UOEKind, uOEKind,
                                                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_NonProcess,
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process,
                                                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv, (int)EnumUoeConst.ctDataRecoverDiv.ct_YES
                                                );
            }
            view.RowFilter = rowFilterText;

            // ソート順設定
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// 回答更新対象データの抽出
        /// </summary>
        /// <param name="uOEKind">UOE種別</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="uOESalesOrderRowNo">UOE発注行番号</param>
        /// <returns>回答更新対象データ</returns>
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        private DataView GetOrderFormCreateView(int uOESupplierCd, int uOESalesOrderNo)
        {
            DataView view = new DataView(this.OrderTable);

            string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo, uOESalesOrderNo
                                            );


            // ソート順設定
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.Sort = sortText;
            view.RowFilter = rowFilterText; // ADD wangyl 2013/02/06 Redmine#34578
            return view;
        }
    	# endregion
       // --- ADD 2019/06/13 ---------->>>>>
        # region ＤＳＰログ書き込み
        /// <summary>
        /// ＤＳＰログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm">処理名</param>
        /// <param name="logDataObjAssemblyNm">アセンブリ名</param>
        /// <param name="logDataOperationCd">操作コード</param>
        /// <param name="logOperationStatus">ステータス</param>
        /// <param name="logDataMassage">メッセージ</param>
        /// <param name="uOESupplierCd">仕入先コード</param>
        private void logd_update(string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            _uoeOprtnHisLogAcs.logd_update(this, logDataObjProcNm, logDataObjAssemblyNm, logDataOperationCd, logOperationStatus, logDataMassage, uOESupplierCd);
        }
        # endregion
        // --- ADD 2019/06/13 ----------<<<<<

        # endregion
	}
}
