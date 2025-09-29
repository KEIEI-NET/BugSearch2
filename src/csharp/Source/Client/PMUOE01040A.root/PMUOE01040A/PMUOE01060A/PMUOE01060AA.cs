//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ発注情報アクセスクラス
// プログラム概要   : ＵＯＥ発注情報アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10502378-00 作成担当 : 立花 裕輔
// 作 成 日  2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号  XXXXXXXX-00 作成担当 : 長内 数馬
// 作 成 日  2011/10/27  修正内容 : 22008 長内 数馬 伝票明細追加情報セット不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangmj
// 作 成 日  2012/09/20  修正内容 : redmine#32404の対応
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
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// ＵＯＥ発注情報アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ＵＯＥ発注情報アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2009/05/25</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>Update Note: 2012/09/20 yangmj redmine#23404の対応</br>
	/// </remarks>
	public partial class UoeOrderInfoAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
        public UoeOrderInfoAcs()
		{
			//企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ログイン拠点コード
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //UOE発注データ・仕入明細データ更新リモートオブジェクト
            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();

            //UOE発注データ リモートオブジェクト
            this._iIOWriteUOEOdrDtlDB = (IIOWriteUOEOdrDtlDB)MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();

            //仕入データ リモートオブジェクト
            this._iStockSlipDB = (IStockSlipDB)MediationStockSlipDB.GetStockSlipDB();

            //入庫更新 リモートオブジェクト
            this._iUOEStockUpdateDB = MediationUOEStockUpdateDB.GetUOEStockUpdateDB();
        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns></returns>
        public static UoeOrderInfoAcs GetInstance()
        {
            if (_uoeOrderInfoAcs == null)
            {
                _uoeOrderInfoAcs = new UoeOrderInfoAcs();
            }
            return _uoeOrderInfoAcs;
        }
        # endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
        //アクセスクラス インスタンス
        private static UoeOrderInfoAcs _uoeOrderInfoAcs = null;

		//企業コード
		private string _enterpriseCode = "";

		//ログイン拠点コード
		private string _loginSectionCd = "";

        //UOE発注データ・仕入明細データ更新リモート
        private IIOWriteControlDB _iIOWriteControlDB = null;

        //UOE発注データ リモートオブジェクト
        private IIOWriteUOEOdrDtlDB _iIOWriteUOEOdrDtlDB = null;

        //仕入データ リモートオブジェクト
        private IStockSlipDB _iStockSlipDB = null;

        //入庫更新 リモートオブジェクト
        private IUOEStockUpdateDB _iUOEStockUpdateDB = null;

        # endregion

		// ===================================================================================== //
		// 定数群
		// ===================================================================================== //
		#region Public Const Member
        // メッセージ
        private const string MESSAGE_NoResult = "条件に一致するデータは存在しません。";
        private const string MESSAGE_ErrResult = "データの取得に失敗しました。";
        private const string MESSAGE_NotFound = "処理対象のデータが存在しません。";
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
        # endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ■ ＵＯＥ発注データ・仕入明細の更新処理
        /// <summary>
        /// ＵＯＥ発注データ・仕入明細の更新処理
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="StockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int WriteUOEOrderDtl(
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            return (WriteUOEOrderDtl(
                ref uOEOrderDtlWorkList,
                ref stockDetailWorkList,
                1,
                out message));
        }
        # endregion

        # region ■ ＵＯＥ発注データ・仕入明細の作成処理
        /// <summary>
        /// ＵＯＥ発注データ・仕入明細の作成処理
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="StockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="mode">動作モード 0:新規作成 1:確定時処理</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int WriteUOEOrderDtl(
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            int mode,
            out string message)
        {
            //-----------------------------------------------------------
            // 変数の初期化
            //-----------------------------------------------------------
            # region 変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            # endregion

            try
            {
                //-----------------------------------------------------------
                // 仕入明細データの不正データを削除
                //-----------------------------------------------------------
                # region ＵＯＥ発注データに発注番号・発注行番号を付加
                for (int i = 0; i < stockDetailWorkList.Count; i++)
                {
                    //仕入担当者名称
                    if (stockDetailWorkList[i].StockAgentName.Length > 16)
                    {
                        string strRemove = stockDetailWorkList[i].StockAgentName.Remove(16);
                        stockDetailWorkList[i].StockAgentName = strRemove;
                    }

                    //仕入入力者名称
                    if (stockDetailWorkList[i].StockInputName.Length > 16)
                    {
                        string strRemove = stockDetailWorkList[i].StockInputName.Remove(16);
                        stockDetailWorkList[i].StockInputName = strRemove;
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // ＵＯＥ発注データに発注番号・発注行番号を付加
                //-----------------------------------------------------------
                # region ＵＯＥ発注データに発注番号・発注行番号を付加
                //処理中フラグの設定・ＵＯＥ発注先一覧の取得
                DateTime dateTimeNow = DateTime.Now;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
		        {
                    //受信日付（ReceiveDateRF）にシステム日付をセット
                    uOEOrderDtlWorkList[i].ReceiveDate = dateTimeNow;


                    //回答埋め込みデータの場合
                    if (uOEOrderDtlWorkList[i].DataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_Insert)
                    {
                        //送信フラグ「9:正常終了」を設定
                        uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

                        //復旧フラグ「9:正常終了」を設定
                        uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                    }
                    //未処理データの場合
                    else
                    {
                        //確定時処理
                        if (mode == 1)
                        {
                            //送信フラグ「1:処理中」を設定
                            uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_Process;

                            //復旧フラグ「0:未処理」を設定
                            uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess;
                        }
                        //新規処理
                        else
                        {
                            //送信フラグ「0:未処理」を設定
                            uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_NonProcess;

                            //復旧フラグ「0:未処理」を設定
                            uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess;
                        }
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // ＵＯＥ発注データ・仕入明細の作成処理
                //-----------------------------------------------------------
                # region ＵＯＥ発注データ・仕入明細の作成処理
                IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
                List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

                status = WriteUOEOrderDtl(
                    ref iOWriteCtrlOptWork,
                    ref slipDetailAddInfoWorkList,
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList,
                    out message);
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

        # region ■ ＵＯＥ発注回答更新処理
        /// <summary>
        /// ＵＯＥ発注回答更新処理
        /// </summary>
        /// <param name="stockSlipGrpList">ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注データ定義リスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int Write(ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//パラメータクラス作成
                CustomSerializeArrayList csAry = ToCustomSerializeFromStockSlipGrpList(stockSlipGrpList, uOEOrderDtlWorkList);
				object setObj = (object)csAry;

                do
                {
                    status = this._iIOWriteUOEOdrDtlDB.OrderFixation(ref setObj);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "シェアチェックエラー（拠点ロック）です。\r"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                } while ((status == 850) || (status == 851) || (status == 852));

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (setObj is ArrayList))
				{
                    DivisionCustomSerializeArrayList((CustomSerializeArrayList)setObj, ref stockSlipGrpList, ref uOEOrderDtlWorkList);
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
				}
				else
				{
					message = MESSAGE_NoResult;
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

        # region ■ ＵＯＥ発注データの検索処理
        /// <summary>
        /// ＵＯＥ発注データの検索処理
        /// </summary>
        /// <param name="para">検索パラメータ</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注ワーク</param>
        /// <param name="stockDetailWorkList">仕入明細ワーク</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int Search(UOESendProcCndtnPara para, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
			message = "";

			try
			{
                UOESendProcCndtnWork uOESendProcCndtnWork = ToUOESendProcCndtnWorkFromPara(para);

                ArrayList uOEOrderDtlWorkAry = new ArrayList(); 
                ArrayList stockDetailWorkAry = new ArrayList();

                object uOESendProcCndtnWorkObj = uOESendProcCndtnWork;
                object uOEOrderDtlWorkAryObj = uOEOrderDtlWorkAry;
                object stockDetailWorkAryObj = stockDetailWorkAry;

                status = this._iIOWriteUOEOdrDtlDB.Search(  uOESendProcCndtnWorkObj,
                                                            ref uOEOrderDtlWorkAryObj,
                                                            ref stockDetailWorkAryObj,
                                                            0,
                                                            ConstantManagement.LogicalMode.GetData0);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uOEOrderDtlWorkAryObj is ArrayList)
                && (stockDetailWorkAryObj is ArrayList))
				{
					ArrayList retUOEOrderDtlWorkAry = (ArrayList)uOEOrderDtlWorkAryObj;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDetailWorkAryObj;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
				}
				else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
						 (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					message = MESSAGE_NoResult;
                    uOEOrderDtlWorkList = null;
                    stockDetailWorkList = null;
                }
				else
				{
					message = MESSAGE_NoResult;
				}
			}
			catch (Exception ex)
			{
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

        # region ■ ＵＯＥ発注データの検索処理＜UOE発注番号・品番＞
        /// <summary>
        /// ■ ＵＯＥ発注データの検索処理＜UOE発注番号・品番＞
        /// </summary>
        /// <param name="para">ArrayList＜UOEOdrDtlGodsReadCndtnWork＞</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int UoeOdrDtlGodsReadAll(ArrayList paraAry, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();

            try
            {
                //パラメータ設定
                ArrayList uOEOrderDtlWorkAry = new ArrayList();
                ArrayList stockDetailWorkAry = new ArrayList();

                object paraList = paraAry;
                object uoeOrderDtlList = uOEOrderDtlWorkAry;
                object stockDtlList = stockDetailWorkAry;

                //リモート処理の呼び出し
                status = this._iIOWriteUOEOdrDtlDB.UoeOdrDtlGodsReadAll(
                    paraList,
                    ref uoeOrderDtlList,
                    ref stockDtlList);

                //戻値の設定
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeOrderDtlList is ArrayList)
                && (stockDtlList is ArrayList))
                {
                    ArrayList retUOEOrderDtlWorkAry = (ArrayList)uoeOrderDtlList;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDtlList;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    message = MESSAGE_NoResult;
                    uOEOrderDtlWorkList = null;
                    stockDetailWorkList = null;
                }
                else
                {
                    message = MESSAGE_NoResult;
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

        # region ■ ＵＯＥ発注データの検索処理＜UOE発注先・相手先伝票番号＞
        /// <summary>
        /// ■ ＵＯＥ発注データの検索処理＜UOE発注先・相手先伝票番号＞
        /// </summary>
        /// <param name="para">ArrayList＜UOEStockUpdSearchWork＞</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int SearchAllPartySlip(ArrayList paraAry, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();

            try
            {
                //パラメータ設定
                ArrayList uOEOrderDtlWorkAry = new ArrayList();
                object paraList = paraAry;
                object uoeOrderDtlList = uOEOrderDtlWorkAry;

                //UOEStockUpdSearchWork uOEStockUpdSearchWork

                //リモート処理の呼び出し
                status = this._iUOEStockUpdateDB.SearchAllPartySlip(
                    paraList,
                    ref uoeOrderDtlList,
                    0,
                    0);              

                //戻値の設定
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (uoeOrderDtlList is ArrayList))
                {
                    ArrayList retUOEOrderDtlWorkAry = (ArrayList)uoeOrderDtlList;

                    uOEOrderDtlWorkList.AddRange((UOEOrderDtlWork[])retUOEOrderDtlWorkAry.ToArray(typeof(UOEOrderDtlWork)));
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)EnumUoeConst.Status.ct_NORMAL;
                    message = String.Empty;
                    uOEOrderDtlWorkList = null;
                }
                else
                {
                    uOEOrderDtlWorkList = null;
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

        # region ■ 仕入情報の読み込み処理＜仕入日・相手先伝票番号＞
        /// <summary>
        /// ■ 仕入情報の読み込み処理＜仕入日・相手先伝票番号＞
        /// </summary>
        /// <param name="paraAry">ArrayList＜StockSlipWork＞</param>
        /// <param name="stockSlipWorkList">仕入データオブジェクト</param>
        /// <param name="stockDetailWorkList">仕入明細データオブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int StockSlipPartySaleSlipNumReadAll(ArrayList paraAry, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

            stockSlipWorkList = new List<StockSlipWork>();
            stockDetailWorkList = new List<StockDetailWork>();

            try
            {
                //パラメータ設定
                ArrayList stockSlipWorkAry = new ArrayList();
                ArrayList stockDetailWorkAry = new ArrayList();

                object paraAryobj = paraAry;
                object stockSlipAryObj = stockSlipWorkList;
                object stockDetailAryObj = stockDetailWorkList;

                //リモート処理の呼び出し
                status = this._iStockSlipDB.StockSlipPartySaleSlipNumReadAll(
                                    paraAryobj,
                                    out stockSlipAryObj,
                                    out stockDetailAryObj);

                //戻値の設定
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (stockSlipAryObj is ArrayList)
                && (stockDetailAryObj is ArrayList))
                {
                    ArrayList retStockSlipWorkAry = (ArrayList)stockSlipAryObj;
                    ArrayList retStockDetailWorkAry = (ArrayList)stockDetailAryObj;

                    stockSlipWorkList.AddRange((StockSlipWork[])retStockSlipWorkAry.ToArray(typeof(StockSlipWork)));
                    stockDetailWorkList.AddRange((StockDetailWork[])retStockDetailWorkAry.ToArray(typeof(StockDetailWork)));
                }
                else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    message = MESSAGE_NoResult;
                    stockSlipWorkList = null;
                    stockDetailWorkList = null;
                }
                else
                {
                    message = MESSAGE_NoResult;
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

        # region ■ ＵＯＥ発注データの削除処理
        /// <summary>
		/// ＵＯＥ発注データの削除処理
		/// </summary>
		/// <param name="list">ＵＯＥ発注データ</param>
		/// <param name="message">メッセージ</param>
		/// <returns></returns>
		public int Delete(List<UOEOrderDtlWork> list, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				if (list == null)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}
				if (list.Count == 0)
				{
					message = MESSAGE_NotFound;
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					return (status);
				}

                //パラメータの設定
                ArrayList registList = new ArrayList();
                registList.AddRange(list);
				object uoeOrderDtlList = (object)registList;

                status = this._iIOWriteUOEOdrDtlDB.LogicalDelete(ref uoeOrderDtlList);
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
        # region ＵＯＥ発注データ・仕入明細の作成処理
        /// <summary>
        /// ＵＯＥ発注データ・仕入明細の作成処理
        /// </summary>
        /// <param name="iOWriteCtrlOptWork">売上・仕入制御オプション</param>
        /// <param name="slipDetailAddInfoWorkList">伝票明細追加情報データリスト</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="StockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int WriteUOEOrderDtl(
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList,
            out string message)
        {
            # region 変数の初期化
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            //戻り値の初期化

            //ArrayListの初期化
            ArrayList slipDetailAddInfoWorkArry = null;
            ArrayList uOEOrderDtlWorkArry = null;
            ArrayList stockDetailWorkArry = null;
            # endregion

            try
            {
                # region ＵＯＥ発注データリストより各種リストを取得
                status = GetOrderWorkFromUOEOrderDtl(
                    uOEOrderDtlWorkList,
                    stockDetailWorkList,
                    out uOEOrderDtlWorkArry,
                    out stockDetailWorkArry,
                    out slipDetailAddInfoWorkArry,
                    out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                # region リモート処理のパラメータ設定
                //売上・仕入制御オプションの設定
                IOWriteCtrlOptWork iOWriteCtrlOptWorkClass = new IOWriteCtrlOptWork();

                iOWriteCtrlOptWorkClass.CtrlStartingPoint = 1;              //制御起点
                iOWriteCtrlOptWorkClass.AcpOdrrAddUpRemDiv = 0;             //受注データ計上残区分
                iOWriteCtrlOptWorkClass.ShipmAddUpRemDiv = 0;               //出荷データ計上残区分
                iOWriteCtrlOptWorkClass.RetGoodsStockEtyDiv = 0;            //返品時在庫登録区分
                iOWriteCtrlOptWorkClass.SupplierSlipDelDiv = 0;             //仕入伝票削除区分
                iOWriteCtrlOptWorkClass.RemainCntMngDiv = 0;                //残数管理区分
                iOWriteCtrlOptWorkClass.EnterpriseCode = _enterpriseCode;   //企業コード
                iOWriteCtrlOptWorkClass.CarMngDivCd = 0;                    //車両管理区分

                //リモート処理のパラメータ設定
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraUoeDetailList = new CustomSerializeArrayList();
                CustomSerializeArrayList paraStockList = new CustomSerializeArrayList();

                object objUOEOrderDtlWorkList = (object)uOEOrderDtlWorkArry;
                object objStockDetailWorkList = (object)stockDetailWorkArry;
                object objIOWriteCtrlOptWorkClass = (object)iOWriteCtrlOptWorkClass;
                object objSlipDetailAddInfoWorkList = (object)slipDetailAddInfoWorkArry;


                paraUoeDetailList.Add(objUOEOrderDtlWorkList);
                paraList.Add(paraUoeDetailList);

                paraStockList.Add(objSlipDetailAddInfoWorkList);
                paraStockList.Add(objStockDetailWorkList);

                paraList.Add(paraStockList);
                paraList.Add(objIOWriteCtrlOptWorkClass);

                object objParaList = (object)paraList;
                # endregion

                # region リモート処理の呼び出し
                //リモート処理の呼び出し
                string retItemInfo = "";
                do
                {
                    status = _iIOWriteControlDB.Write(ref objParaList, out message, out retItemInfo);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "シェアチェックエラー（拠点ロック）です。\r"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                } while ((status == 850) || (status == 851) || (status == 852));

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                # region 戻り値の設定
                //戻り値の設定
                iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
                slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                CustomSerializeArrayListForAfterWrite(
                    objParaList,
                    ref iOWriteCtrlOptWork,
                    ref slipDetailAddInfoWorkList,
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList);
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

        # region ＵＯＥ発注確定用パラメーター作成
        /// <summary>
        /// ＵＯＥ発注確定用パラメーター作成
        /// </summary>
        /// <param name="stockSlipGrpList">ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注データ定義リスト</param>
        /// <returns>ＵＯＥ発注確定用パラメーター</returns>
        private CustomSerializeArrayList ToCustomSerializeFromStockSlipGrpList(List<StockSlipGrp> stockSlipGrpList, List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            //------------------------------------------------------------------------------------
            // csAry構成
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --ArrayList                     UOE発注データリスト
            //          --UOEOrderDtlWork           UOE発注データ
            //      --CustomSerializeArrayList      仕入データリスト
            //          --StockSlipWork             仕入ヘッダクラス
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細クラス
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList csAry = new CustomSerializeArrayList();

            try
            {
                //UOE発注データ格納処理
                ArrayList uOEOrderDtlWorkAry = new ArrayList();
                uOEOrderDtlWorkAry.AddRange(uOEOrderDtlWorkList);

                //CustomSerializeArrayListへ設定
                csAry.Add(uOEOrderDtlWorkAry);

                //仕入情報格納処理
                foreach (StockSlipGrp stockSlipGrp in stockSlipGrpList)
                {
                    CustomSerializeArrayList stockGrpAry = new CustomSerializeArrayList();

                    //仕入ヘッダクラス
                    stockGrpAry.Add(stockSlipGrp.stockSlipWork);

                    //仕入明細クラス
                    ArrayList dtl = new ArrayList();
                    dtl.AddRange(stockSlipGrp.stockDetailWorkList);
                    stockGrpAry.Add(dtl);

                    //CustomSerializeArrayListへ設定
                    csAry.Add(stockGrpAry);
                }

            }
            catch (Exception)
            {
                csAry = null;
            }
            return (csAry);
        }
        # endregion

        # region CustomSerializeArrayListを各種データオブジェクトへ分割
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトへ分割
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipGrpList">ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注データ定義リスト</param>
        private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            List<UOEOrderDtlWork> returnUOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            List<StockSlipGrp> returnStockSlipGrpList = new List<StockSlipGrp>();

            try
            {
                //------------------------------------------------------------------------------------
                // csAry構成
                //------------------------------------------------------------------------------------
                //  CustomSerializeArrayList            統合リスト
                //      --ArrayList                     UOE発注データリスト
                //          --UOEOrderDtlWork           UOE発注データ
                //      --CustomSerializeArrayList      仕入データリスト
                //          --StockSlipWork             仕入ヘッダクラス
                //          --ArrayList                 仕入明細リスト
                //              --StockDetailWork       仕入明細クラス
                //------------------------------------------------------------------------------------


                for (int i = 0; i < paraList.Count; i++)
                {
                    if (paraList[i] is ArrayList)
                    {
                        ArrayList list = (ArrayList)paraList[i];
                        if (list.Count == 0) continue;

                        //UOE発注データ
                        if (list[0] is UOEOrderDtlWork)
                        {
                            foreach (UOEOrderDtlWork work in list)
                            {
                                returnUOEOrderDtlWorkList.Add(work);
                            }
                        }
                        //仕入情報
                        else if((list[0] is ArrayList) || (list[0] is StockSlipWork))
                        {
                            StockSlipGrp stockSlipGrp = new StockSlipGrp();
                            for (int j = 0; j < list.Count; j++)
                            {
                                //仕入ヘッダー
                                if (list[j] is StockSlipWork)
                                {
                                    stockSlipGrp.stockSlipWork = (StockSlipWork)list[j];
                                }
                                //仕入明細
                                else if (list[j] is ArrayList)
                                {
                                    ArrayList dtlList = (ArrayList)list[j];
                                    if (dtlList[0] is StockDetailWork)
                                    {
                                        foreach (StockDetailWork work in dtlList)
                                        {
                                            stockSlipGrp.stockDetailWorkList.Add(work);
                                        }
                                    }
                                }
                            }
                            returnStockSlipGrpList.Add(stockSlipGrp);
                        }
                    }
                }
            }
            catch (Exception)
            {
                returnStockSlipGrpList = null;
                returnUOEOrderDtlWorkList = null;
            }

            //戻り値設定
            stockSlipGrpList = returnStockSlipGrpList;
            uOEOrderDtlWorkList = returnUOEOrderDtlWorkList;
        }
        # endregion

        # region UOE発注データ抽出条件変換(para→Work)
        /// <summary>
        /// UOE発注データ抽出条件変換(para→Work)
        /// </summary>
        /// <param name="para">UOE発注データ抽出条件パラメータ</param>
        /// <returns>UOE発注データ抽出条件Work</returns>
        /// <br>Update Note: 2012/09/20 yangmj redmine#23404の対応</br>
        private UOESendProcCndtnWork ToUOESendProcCndtnWorkFromPara(UOESendProcCndtnPara para)
        {
            UOESendProcCndtnWork returnUOESendProcCndtnWork = new UOESendProcCndtnWork();

   			try
			{
                returnUOESendProcCndtnWork.CashRegisterNo = para.CashRegisterNo;
                returnUOESendProcCndtnWork.CustomerCode = para.CustomerCode;
                returnUOESendProcCndtnWork.EnterpriseCode = para.EnterpriseCode;
                returnUOESendProcCndtnWork.St_InputDay = para.St_InputDay;
                returnUOESendProcCndtnWork.Ed_InputDay = para.Ed_InputDay;
                returnUOESendProcCndtnWork.SystemDivCd = para.SystemDivCd;
                returnUOESendProcCndtnWork.St_UOESalesOrderNo = para.St_UOESalesOrderNo;
                returnUOESendProcCndtnWork.Ed_UOESalesOrderNo = para.Ed_UOESalesOrderNo;
                returnUOESendProcCndtnWork.UOESupplierCd = para.UOESupplierCd;
                returnUOESendProcCndtnWork.St_OnlineNo = para.St_OnlineNo;
                returnUOESendProcCndtnWork.Ed_OnlineNo = para.Ed_OnlineNo;
                returnUOESendProcCndtnWork.DataSendCodes = para.DataSendCodes;
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
                if (LoginInfoAcquisition.Employee != null)
                {
                    returnUOESendProcCndtnWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<
			}
			catch (Exception)
			{
                returnUOESendProcCndtnWork = new UOESendProcCndtnWork();;
			}
			return (returnUOESendProcCndtnWork);
        }
		# endregion

        # region ＵＯＥ発注データリストよりＵＯＥ発注ＷＯＲＫリスト・仕入明細ＷＯＲＫリストを取得
        /// <summary>
        /// ＵＯＥ発注データリストよりＵＯＥ発注ＷＯＲＫリスト・仕入明細ＷＯＲＫリストを取得
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="stockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        /// <param name="uOEOrderDtlWorkArry">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="stockDetailWorkArry">仕入明細ＷＯＲＫリスト</param>
        /// <param name="slipDetailAddInfoWorkArry">伝票明細追加情報データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetOrderWorkFromUOEOrderDtl(List<UOEOrderDtlWork> uOEOrderDtlWorkList,
                                                List<StockDetailWork> stockDetailWorkList,
                                                out ArrayList uOEOrderDtlWorkArry,
                                                out ArrayList stockDetailWorkArry,
                                                out ArrayList slipDetailAddInfoWorkArry,
                                                out string message)
        {
            # region 変数の初期化
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkArry = null;
            stockDetailWorkArry = null;
            slipDetailAddInfoWorkArry = null;
            message = "";

            ArrayList returnUOEOrderDtlWorkArry = new ArrayList();
            ArrayList returnStockDetailWorkArry = new ArrayList();
            ArrayList returnSlipDetailAddInfoWorkArry = new ArrayList();

            //SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // DEL 2011/10/27
            int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // ADD 2011/10/27
            #endregion

            try
            {
                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    //Guid値取得
                    Guid guid = Guid.NewGuid();

                    # region ＵＯＥ発注データよりＵＯＥ発注ＷＯＲＫを取得
                    //ＵＯＥ発注データよりＵＯＥ発注ＷＯＲＫを取得
                    UOEOrderDtlWork uOEOrderDtlWork = uOEOrderDtlWorkList[i];
                    uOEOrderDtlWork.DtlRelationGuid = guid;
                    #endregion

                    # region ＵＯＥ発注データより仕入明細ＷＯＲＫを取得
                    //ＵＯＥ発注データより仕入明細ＷＯＲＫを取得
                    StockDetailWork stockDetailWork = stockDetailWorkList[i];
                    stockDetailWork.DtlRelationGuid = guid;
                    #endregion

                    # region 伝票明細追加情報データ設定
                    //伝票明細追加情報データ
                    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();  // ADD 2011/10/27
                    slipDetailAddInfoWork.DtlRelationGuid = guid;               //明細関連付けGUID
                    slipDetailAddInfoWork.GoodsEntryDiv = 0;                    //商品登録区分
                    slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;   //商品提供日付
                    slipDetailAddInfoWork.PriceUpdateDiv = 0;                   //価格更新区分
                    slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;   //価格開始日付
                    slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;   //価格提供日付
                    slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;         //車両関連付けGUID
                    // -- ADD 2011/10/27 ------------------------>>>
                    slipDtlRegOrder++;
                    slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;    //伝票登録優先順位
                    // -- ADD 2011/10/27 ------------------------<<<
                    #endregion

                    # region リスト追加処理
                    //リスト追加処理
                    returnUOEOrderDtlWorkArry.Add(uOEOrderDtlWork);
                    returnStockDetailWorkArry.Add(stockDetailWork);
                    returnSlipDetailAddInfoWorkArry.Add(slipDetailAddInfoWork);
                    #endregion
                }

                //結果の格納
                uOEOrderDtlWorkArry = returnUOEOrderDtlWorkArry;
                stockDetailWorkArry  = returnStockDetailWorkArry;
                slipDetailAddInfoWorkArry = returnSlipDetailAddInfoWorkArry;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

		# endregion

        #region カスタムシリアライズアレイリスト分割処理
        /// <summary>
        /// カスタムシリアライズアレイリスト分割処理
        /// </summary>
        /// <param name="paraList">カスタムシリアライズアレイリスト</param>
        /// <param name="iOWriteCtrlOptWork">売上・仕入制御オプション</param>
        /// <param name="slipDetailAddInfoWorkList">伝票明細追加情報データリスト</param>
        /// <param name="uOEOrderDtlWorkList">ＵＯＥ発注ＷＯＲＫリスト</param>
        /// <param name="stockDetailWorkList">仕入明細ＷＯＲＫリスト</param>
        private void CustomSerializeArrayListForAfterWrite(object paraList,
            ref IOWriteCtrlOptWork iOWriteCtrlOptWork,
            ref List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList,
            ref List<UOEOrderDtlWork> uOEOrderDtlWorkList,
            ref List<StockDetailWork> stockDetailWorkList)
        {
            foreach (object tempObj in (CustomSerializeArrayList)paraList)
            {
                if (tempObj is IOWriteCtrlOptWork)
                {
                    # region 売上・仕入制御オプション
                    //売上・仕入制御オプション
                    iOWriteCtrlOptWork = (IOWriteCtrlOptWork)tempObj;
                    # endregion
                }
                else if(tempObj is ArrayList)
                {
                    ArrayList tempAry = (ArrayList)tempObj;
                    if(tempAry.Count == 0)  continue;

                    foreach(object tempObj2 in tempAry)
                    {
                        if(tempObj2 is ArrayList)
                        {
                            ArrayList tempAry2 = (ArrayList)tempObj2;

                            if(tempAry2[0] is SlipDetailAddInfoWork)
                            {
                                # region 伝票明細追加情報データリスト
                                //伝票明細追加情報データリスト
                                foreach(SlipDetailAddInfoWork work in tempAry2)
                                {
                                    slipDetailAddInfoWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is UOEOrderDtlWork)
                            {
                                # region ＵＯＥ発注ＷＯＲＫリスト
                                //ＵＯＥ発注ＷＯＲＫリスト
                                foreach (UOEOrderDtlWork work in tempAry2)
                                {
                                    uOEOrderDtlWorkList.Add(work);
                                }
                                # endregion
                            }
                            else if(tempAry2[0] is StockDetailWork)
                            {
                                # region 仕入明細ＷＯＲＫリスト
                                //仕入明細ＷＯＲＫリスト
                                foreach (StockDetailWork work in tempAry2)
                                {
                                    stockDetailWorkList.Add(work);
                                }
                                # endregion
                            }
                        }

                    }
                }
            }
        }
        # endregion
        # endregion
    }
}
