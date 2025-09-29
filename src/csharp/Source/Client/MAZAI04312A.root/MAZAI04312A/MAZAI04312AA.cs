# region ※using
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 在庫受払履歴テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 在庫受払履歴テーブルのアクセス制御を行います。</br>
	/// <br>Programmer	: 渡邉貴裕</br>
	/// <br>Date		: 2007.05.18</br>
    /// <br>Update Note : 2010/11/17  施ヘイ中</br>
    /// <br>            : PM1014の対応の仕様変更</br>
    /// <br>Update Note : 2013/01/15  FSI厚川 宏　管理No.541 買掛オプション追加</br>
	/// </remarks>    
	public class StockAcPayHistAcs : IGeneralGuideData 
	{
		# region ■Private Member
		/// <summary>リモートオブジェクト格納バッファ</summary>        
        private IStockAcPayHisSearchDB _iStockAcPayHisSearchDB = null;
        /// <summary>ユーザーガイドオブジェクト格納バッファ(HashTable)</summary>
		private Hashtable _stockAcPayLstGdBdTable;
		/// <summary>ユーザーガイドオブジェクト格納バッファ(ArrayList)</summary>
		private ArrayList _stockAcPayLstGdBdList;
        /// <summary>在庫受払履歴検索</summary>
        private static Hashtable _stockAcPayListCH = null;
        
		# endregion				    
		  
		# region ■Constracter
		/// <summary>
		/// 在庫受払履歴テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫受払履歴テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public StockAcPayHistAcs()
		{
			// メモリ生成処理
			MemoryCreate();

			// ログイン部品で通信状態を確認
			if (LoginInfoAcquisition.OnlineFlag)
			{
				try
				{
					// リモートオブジェクト取得
                    this._iStockAcPayHisSearchDB = (IStockAcPayHisSearchDB)MediationStockAcPayHisSearchDB.GetStockAcPayHisSearchDB();
				}
				catch (Exception)
				{				
					//オフライン時はnullをセット
					this._iStockAcPayHisSearchDB = null;
				}
			}
			else
			{
				// オフライン時のデータ読み込み
				this.SearchOfflineData();
			}
		}
		# endregion

		# region ◆public int GetOnlineMode()
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.05</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iStockAcPayHisSearchDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}
		# endregion

		#region ■Public Method
		/// <summary>
		/// 在庫受払履歴テーブルStaticメモリ情報オフライン書き込み処理
		/// </summary>
		/// <param name="sender">object（呼出元オブジェクト）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 在庫受払履歴テーブルStaticメモリの情報をローカルファイルに保存します。</br>
		/// <br>Programer  : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			// オフラインシリアライズデータ作成部品I/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status;

			// KeyList設定
			string[] stockAcPayHistKeys = new string[1];
			stockAcPayHistKeys[0] = LoginInfoAcquisition.EnterpriseCode;

			SortedList sortedList = new SortedList();
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();

            /* -----DEL 2008/07/17 使用クラス変更の為 ---------------------------------------------------->>>>>
            foreach (StockAcPayHist stockAcPayHist in _stockAcPayListCH.Values)
            {
                // クラス ⇒ ワーカークラス
                stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHist);

            }
               -----DEL 2008/07/17 -----------------------------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 ----------------------------------------------------------------------->>>>>
            foreach (StockAcPayHisSearchRet stockAcPayHisSearchRet in _stockAcPayListCH.Values)
            {
				// クラス ⇒ ワーカークラス
                stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHisSearchRet);

			}
            // -----ADD 2008/07/17 -----------------------------------------------------------------------<<<<<

			ArrayList carrierWorkList = new ArrayList();  
			carrierWorkList.AddRange(sortedList.Values);
				
			status = offlineDataSerializer.Serialize("CallierAcs", stockAcPayHistKeys, carrierWorkList);

			return status;
		}

        /// <summary>
        /// 在庫受払履歴シリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫受払履歴情報のシリアライズを行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
        /* -----DEL 2008/07/17 使用クラス変更の為 ---------------------------------------------------------------->>>>>
        public void Serialize(StockAcPayHist stockAcPayHist ,string fileName)
        {
            //在庫受払履歴クラスから在庫受払履歴ワーカークラスにメンバコピー
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHist);
            //在庫受払履歴ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(stockAcPayHist,fileName);
        }
           -----DEL 2008/07/17 -----------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 ----------------------------------------------------------------------------------->>>>>
        public void Serialize(StockAcPayHisSearchRet stockAcPayHisSearchRet, string fileName)
        {
            //在庫受払履歴クラスから在庫受払履歴ワーカークラスにメンバコピー
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = CopyToStockAcWorkFromStockAc(stockAcPayHisSearchRet);
            //在庫受払履歴ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(stockAcPayHisSearchRet, fileName);
        }
        // -----ADD 2008/07/17 -----------------------------------------------------------------------------------<<<<<

		/// <summary>
		/// 在庫受払履歴Listシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫受払履歴List情報のシリアライズを行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public void ListSerialize(ArrayList stockAcPayHists,string fileName)
		{
            StockAcPayHisSearchRetWork[] stockAcPayHisSearchRetWorks = new StockAcPayHisSearchRetWork[stockAcPayHists.Count];
			for(int i= 0; i < stockAcPayHists.Count; i++)
			{
                //stockAcPayHisSearchRetWorks[i] = CopyToStockAcWorkFromStockAc((StockAcPayHist)stockAcPayHists[i]);        //DEL 2008/07/17 使用クラス変更の為
                stockAcPayHisSearchRetWorks[i] = CopyToStockAcWorkFromStockAc((StockAcPayHisSearchRet)stockAcPayHists[i]);  //ADD 2008/07/17
            }
            //在庫受払履歴ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(stockAcPayHisSearchRetWorks,fileName);
		}
        /// <summary>
        /// 在庫受払履歴検索処理（論理削除含む）
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 在庫受払履歴の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
        //public int SearchAll(out ArrayList retList,StockAcPayHisSearchPara stockAsPayHisSearchPara)                           //DEL 2008/07/17 在庫入出庫照会抽出結果クラス追加の為
        public int SearchAll(out ArrayList retList, out ArrayList retList2, StockAcPayHisSearchPara stockAsPayHisSearchPara)    //ADD 2008/07/17
		{
			bool nextData;
			int	 retTotalCnt;
            //return SearchProc(out retList, out retTotalCnt, out nextData, stockAsPayHisSearchPara, ConstantManagement.LogicalMode.GetData01, 0, false);                   //DEL 2008/07/17 在庫入出庫照会抽出結果クラス追加の為
            return SearchProc(out retList,out retList2, out retTotalCnt, out nextData, stockAsPayHisSearchPara, ConstantManagement.LogicalMode.GetData01, 0, false);        //ADD 2008/07/17
            
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（在庫受払履歴ワーククラス⇒在庫受払履歴クラス）
        ///// </summary>
        ///// <param name="stockAcPayHistWork">在庫受払履歴ワーククラス</param>
        ///// <returns>在庫受払履歴クラス</returns>
        ///// <remarks>
        ///// <br>Note       : 在庫受払履歴ワーククラスから在庫受払履歴クラスへメンバーのコピーを行います。（レイアウト分のみ）</br>
        ///// <br>Programmer : 渡邉貴裕</br>
        ///// <br>Date       : 2007.05.18</br>
        ///// </remarks>
        //public static StockAcPayHist CopyToStockAcPayHistFromWork(StockAcPayHistWork stockAcPayHistWork)
        //{
        //    StockAcPayHist stockAcPayHist = new StockAcPayHist();

        //    stockAcPayHist.AcPayNote = stockAcPayHistWork.AcPayNote;
        //    stockAcPayHist.AcPaySlipCd = stockAcPayHistWork.AcPaySlipCd;
        //    stockAcPayHist.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
        //    stockAcPayHist.AcPayTransCd = stockAcPayHistWork.AcPayTransCd;
        //    stockAcPayHist.AcpOdrCount = stockAcPayHistWork.AcpOdrCount;
        //    stockAcPayHist.AfAcPayEpCode = stockAcPayHistWork.AfAcPayEpCode;
        //    stockAcPayHist.AfEnterWarehCode = stockAcPayHistWork.AfEnterWarehCode;
        //    stockAcPayHist.AfEnterWarehName = stockAcPayHistWork.AfEnterWarehName;
        //    stockAcPayHist.AfSectionCode = stockAcPayHistWork.AfSectionCode;
        //    stockAcPayHist.AfSectionGuideNm = stockAcPayHistWork.AfSectionGuideNm;
        //    stockAcPayHist.AllowStockCnt = stockAcPayHistWork.AllowStockCnt;
        //    stockAcPayHist.ArrivalCnt = stockAcPayHistWork.ArrivalCnt;
        //    stockAcPayHist.BfEnterWarehCode = stockAcPayHistWork.BfEnterWarehCode;
        //    stockAcPayHist.BfEnterWarehName = stockAcPayHistWork.BfEnterWarehName;
        //    stockAcPayHist.BfSectionCode = stockAcPayHistWork.BfSectionCode;
        //    stockAcPayHist.BfSectionGuideNm = stockAcPayHistWork.BfSectionGuideNm;
        //    stockAcPayHist.CellphoneModelCode = stockAcPayHistWork.CellphoneModelCode;
        //    stockAcPayHist.CellphoneModelName = stockAcPayHistWork.CellphoneModelName;
        //    stockAcPayHist.CustomerCode = stockAcPayHistWork.CustomerCode;
        //    stockAcPayHist.CustomerName = stockAcPayHistWork.CustomerName;
        //    stockAcPayHist.CustomerName2 = stockAcPayHistWork.CustomerName2;
        //    stockAcPayHist.EnterpriseCode = stockAcPayHistWork.EnterpriseCode;
        //    stockAcPayHist.EntrustCnt = stockAcPayHistWork.EntrustCnt;
        //    stockAcPayHist.GoodsCode = stockAcPayHistWork.GoodsCode;
        //    stockAcPayHist.GoodsName = stockAcPayHistWork.GoodsName;
        //    stockAcPayHist.InputAgenCd = stockAcPayHistWork.InputAgenCd;
        //    stockAcPayHist.InputAgenNm = stockAcPayHistWork.InputAgenNm;
        //    stockAcPayHist.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
        //    stockAcPayHist.MovingSupliStock = stockAcPayHistWork.MovingSupliStock;
        //    stockAcPayHist.MovingTrustStock = stockAcPayHistWork.MovingTrustStock;            
        //    stockAcPayHist.ReservedCount = stockAcPayHistWork.ReservedCount;
        //    stockAcPayHist.SalesFormCode = stockAcPayHistWork.SalesFormCode;
        //    stockAcPayHist.SalesFormName = stockAcPayHistWork.SalesFormName;
        //    stockAcPayHist.SalesOrderCount = stockAcPayHistWork.SalesOrderCount;
        //    stockAcPayHist.SectionCode = stockAcPayHistWork.SectionCode;
        //    stockAcPayHist.ShipmentCnt = stockAcPayHistWork.ShipmentCnt;
        //    stockAcPayHist.ShipmentPosCnt = stockAcPayHistWork.ShipmentPosCnt;
        //    stockAcPayHist.SoldCnt = stockAcPayHistWork.SoldCnt;
        //    stockAcPayHist.StockUnitPrice = stockAcPayHistWork.StockUnitPrice;
        //    stockAcPayHist.SupplierStock = stockAcPayHistWork.SupplierStock;
        //    stockAcPayHist.TrustCount = stockAcPayHistWork.TrustCount;

        //    return stockAcPayHist;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（在庫受払履歴明細ワーククラス⇒在庫受払履歴明細クラス）
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 在庫受払履歴ワーククラスから在庫受払履歴クラスへメンバーのコピーを行います。（レイアウト分のみ）</br>
        ///// <br>Programmer : 渡邉貴裕</br>
        ///// <br>Date       : 2007.05.18</br>
        ///// </remarks>
        //public static StockAcPayHisDt CopyToStockAcPayHisDtFromWork(StockAcPayHisDtWork stockAcPayHisDtWork)
        //{
        //    StockAcPayHisDt stockAcPayHisDt = new StockAcPayHisDt();

        //    stockAcPayHisDt.AcPayNote = stockAcPayHisDtWork.AcPayNote;
        //    stockAcPayHisDt.AcPaySlipCd = stockAcPayHisDtWork.AcPaySlipCd;
        //    stockAcPayHisDt.AcPaySlipExpNo = stockAcPayHisDtWork.AcPaySlipExpNo;
        //    stockAcPayHisDt.AcPaySlipNum = stockAcPayHisDtWork.AcPaySlipNum;
        //    stockAcPayHisDt.AcPaySlipRowNo = stockAcPayHisDtWork.AcPaySlipRowNo;
        //    stockAcPayHisDt.AcpOdrCount = stockAcPayHisDtWork.AcpOdrCount;
        //    stockAcPayHisDt.AfAcPayEpCode = stockAcPayHisDtWork.AfAcPayEpCode;
        //    stockAcPayHisDt.AfEnterWarehCode = stockAcPayHisDtWork.AfEnterWarehCode;
        //    stockAcPayHisDt.AfEnterWarehName = stockAcPayHisDtWork.AfEnterWarehName;
        //    stockAcPayHisDt.AfSectionCode = stockAcPayHisDtWork.AfSectionCode;
        //    stockAcPayHisDt.AfSectionGuideNm = stockAcPayHisDtWork.AfSectionGuideNm;
        //    stockAcPayHisDt.AfEnterWarehCode = stockAcPayHisDtWork.AfEnterWarehCode;
        //    stockAcPayHisDt.AfEnterWarehName = stockAcPayHisDtWork.AfEnterWarehName;
        //    stockAcPayHisDt.AllowStockCnt = stockAcPayHisDtWork.AllowStockCnt;
        //    stockAcPayHisDt.ArrivalCnt = stockAcPayHisDtWork.ArrivalCnt;
        //    stockAcPayHisDt.BfEnterWarehCode = stockAcPayHisDtWork.BfEnterWarehCode;
        //    stockAcPayHisDt.BfEnterWarehName = stockAcPayHisDtWork.BfEnterWarehName;
        //    stockAcPayHisDt.BfSectionCode = stockAcPayHisDtWork.BfSectionCode;
        //    stockAcPayHisDt.BfSectionGuideNm = stockAcPayHisDtWork.BfSectionGuideNm;
        //    stockAcPayHisDt.BfEnterWarehCode = stockAcPayHisDt.BfEnterWarehCode;
        //    stockAcPayHisDt.BfEnterWarehName = stockAcPayHisDt.BfEnterWarehName;
        //    stockAcPayHisDt.CarrierEpCode = stockAcPayHisDtWork.CarrierEpCode;
        //    stockAcPayHisDt.CarrierEpName = stockAcPayHisDtWork.CarrierEpName;
        //    stockAcPayHisDt.CellphoneModelCode = stockAcPayHisDtWork.CellphoneModelCode;
        //    stockAcPayHisDt.CellphoneModelName = stockAcPayHisDtWork.CellphoneModelName;
        //    stockAcPayHisDt.CustomerCode = stockAcPayHisDtWork.CustomerCode;
        //    stockAcPayHisDt.CustomerName = stockAcPayHisDtWork.CustomerName;
        //    stockAcPayHisDt.CustomerName2 = stockAcPayHisDtWork.CustomerName2;
        //    stockAcPayHisDt.EnterpriseCode = stockAcPayHisDtWork.EnterpriseCode;
        //    stockAcPayHisDt.EntrustCnt = stockAcPayHisDtWork.EntrustCnt;
        //    stockAcPayHisDt.GoodsCode = stockAcPayHisDtWork.GoodsCode;
        //    stockAcPayHisDt.GoodsName = stockAcPayHisDtWork.GoodsName;
        //    stockAcPayHisDt.InputAgenCd = stockAcPayHisDtWork.InputAgenCd;
        //    stockAcPayHisDt.InputAgenNm = stockAcPayHisDtWork.InputAgenNm;
        //    stockAcPayHisDt.IoGoodsDay = stockAcPayHisDtWork.IoGoodsDay;
        //    stockAcPayHisDt.MoveStatus = stockAcPayHisDtWork.MoveStatus;
        //    stockAcPayHisDt.MovingSupliStock = stockAcPayHisDtWork.MovingSupliStock;
        //    stockAcPayHisDt.MovingTrustStock = stockAcPayHisDtWork.MovingTrustStock;
        //    stockAcPayHisDt.ProductNumber = stockAcPayHisDtWork.ProductNumber;
        //    stockAcPayHisDt.ProductStockGuid = stockAcPayHisDtWork.ProductStockGuid;
        //    stockAcPayHisDt.ReservedCount = stockAcPayHisDtWork.ReservedCount;
        //    stockAcPayHisDt.RomDiv = stockAcPayHisDtWork.RomDiv;
        //    stockAcPayHisDt.SalesFormCode = stockAcPayHisDtWork.SalesFormCode;
        //    stockAcPayHisDt.SalesFormName = stockAcPayHisDtWork.SalesFormName;
        //    stockAcPayHisDt.SalesOrderCount = stockAcPayHisDtWork.SalesOrderCount;
        //    stockAcPayHisDt.SectionCode = stockAcPayHisDtWork.SectionCode;
        //    stockAcPayHisDt.ShipmentCnt = stockAcPayHisDtWork.ShipmentCnt;
        //    stockAcPayHisDt.ShipmentPosCnt = stockAcPayHisDtWork.ShipmentPosCnt;
        //    stockAcPayHisDt.SimProductNumber = stockAcPayHisDtWork.SimProductNumber;
        //    stockAcPayHisDt.SoldCnt = stockAcPayHisDtWork.SoldCnt;
        //    stockAcPayHisDt.StockState = stockAcPayHisDtWork.StockState;
        //    stockAcPayHisDt.StockTelNo1 = stockAcPayHisDtWork.StockTelNo1;
        //    stockAcPayHisDt.StockTelNo2 = stockAcPayHisDtWork.StockTelNo2;
        //    stockAcPayHisDt.StockUnitPrice = stockAcPayHisDtWork.StockUnitPrice;
        //    stockAcPayHisDt.SupplierStock = stockAcPayHisDtWork.SupplierStock;
        //    stockAcPayHisDt.TrustCount = stockAcPayHisDtWork.TrustCount;      
        //    stockAcPayHisDt.AcPayTransCd = stockAcPayHisDtWork.AcPayTransCd;            

        //    return stockAcPayHisDt;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		#region ▼IGeneralGuidData Method
		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note		: 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer	: 渡邉貴裕</br>
		/// <br>Date		: 2007.05.18</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status   = -1;
			string enterpriseCode = "";
			string sectionCode    = "";
			

			// 企業コード設定有り
			if (inParm.ContainsKey("EnterpriseCode"))
			{
				enterpriseCode = inParm["EnterpriseCode"].ToString();
			}
			// 企業コード設定無し
			else
			{
				// 有り得ないのでエラー
				return status;
			}

			// 拠点コード
			if (inParm.ContainsKey("SectionCode"))
			{
				sectionCode = inParm["SectionCode"].ToString();
			}

            // 在庫受払履歴テーブル読込み
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				break;
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					status = 4;
					break;
				}
				default:
				status = -1;
				break;
			}

			return status;
		}

		#endregion

		#endregion

		#region ■Private Method
		/// <summary>
        /// 在庫受払履歴検索処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 在庫受払履歴の検索処理を行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
        /// <br>UpdateNote : 在庫受払履歴が存在しない場合でも、前月末残と現在庫数を表示するように変更。</br>
        /// <br>           : 施ヘイ中</br>
        /// <br>Date       : 2010/11/15</br>
		/// </remarks>
        //private int SearchProc(out ArrayList retList,out int retTotalCnt,out bool nextData,StockAcPayHisSearchPara stockAcPayHisSearchPara,ConstantManagement.LogicalMode logicalMode,int readCnt,bool reAct)                         //DEL 2008/07/17 在庫入出庫照会抽出結果クラス追加の為    
		private int SearchProc(out ArrayList retList,out ArrayList retList2,out int retTotalCnt,out bool nextData,StockAcPayHisSearchPara stockAcPayHisSearchPara,ConstantManagement.LogicalMode logicalMode,int readCnt,bool reAct)    //ADD 2008/07/17
		{
            //StockAcPayHist prevStockAcPayHist = new StockAcPayHist();                 //DEL 2008/07/17 使用していない為
			
			int status;            

            //次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;

			retList = new ArrayList();
			retList.Clear();
            ArrayList paraList = new ArrayList();
            retList2 = new ArrayList();       //ADD 2008/07/17 
            retList2.Clear();                 //ADD 2008/07/17


			if ((_stockAcPayListCH.Count != 0 ) && (reAct != true))
			{
                //キャッシュがあるときの処理
                status = 0;
//				status = SearchStatic(out retList,enterpriseCode,carrierCode);
			}
			else
			{
				object objectStockAcPayListWork = null;
                object objectStockCarEnterCarOutRetWork = null;     //ADD 2008/07/17
                object objectStockAcPayPara = CopyToSearchParaWorkFromSearchPara( stockAcPayHisSearchPara );
                status = 0;
                // 在庫受払履歴検索
				if (readCnt == 0)
				{
                    //status = this._iStockAcPayHisSearchDB.Search(out objectStockAcPayListWork, objectStockAcPayPara, 0, ConstantManagement.LogicalMode.GetData0);                                         //DEL 2008/07/17 在庫入出庫照会抽出結果クラス追加の為
                    status = this._iStockAcPayHisSearchDB.Search(out objectStockAcPayListWork, out objectStockCarEnterCarOutRetWork, objectStockAcPayPara, 0, ConstantManagement.LogicalMode.GetData0);     //ADD 2008/07/17
                }

                if (status == 0)
				{

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// パラメータが渡って来ているか確認  
                    //CustomSerializeArrayList customList = objectStockAcPayListWork as CustomSerializeArrayList;

                    //paraList = customList[0] as ArrayList;

                    //if ((stockAcPayHisSearchPara.ProductNumber != "") || (stockAcPayHisSearchPara.StockTelNo1 != ""))
                    //{
                    //    // 製番あり ⇒在庫受払製番履歴                        
                    //    StockAcPayHisDtWork[] wkstockAcPayHisDtWorks = new StockAcPayHisDtWork[paraList.Count];
                        
                    //    // データを元に戻す
                    //    for(int i=0; i < paraList.Count; i++)
                    //    {
                    //        wkstockAcPayHisDtWorks[i] = (StockAcPayHisDtWork)paraList[i];
                    //    }
                    //    for (int i = 0; i < wkstockAcPayHisDtWorks.Length; i++)
                    //    {
                    //        // サーチ結果取得
                    //        retList.Add(CopyToStockAcPayHisDtFromWork(wkstockAcPayHisDtWorks[i]));
                    //    }                       
                    //}
                    //else
                    //{
                    //    // 製番なし ⇒在庫受払履歴
                    //    StockAcPayHistWork[] wkstockAcPayHistWorks = new StockAcPayHistWork[paraList.Count];
                    //    // データを元に戻す
                    //    for(int i=0; i < paraList.Count; i++)
                    //    {
                    //        wkstockAcPayHistWorks[i] = (StockAcPayHistWork)paraList[i];
                    //    }
                    //    for (int i = 0; i < wkstockAcPayHistWorks.Length; i++)
                    //    {
                    //        // サーチ結果取得
                    //        retList.Add(CopyToStockAcPayHistFromWork(wkstockAcPayHistWorks[i]));
                    //    }                       
                    //}

                    ArrayList retWorkList;
                    ArrayList retWorkList2;     //ADD 2008/07/17
                    // --- UPD 2010/11/15 ---------->>>>> 
                    if ((objectStockAcPayListWork as CustomSerializeArrayList).Count > 0 && (objectStockAcPayListWork as CustomSerializeArrayList)[0] is ArrayList)
                    {
                        retWorkList = (ArrayList)((objectStockAcPayListWork as CustomSerializeArrayList)[0]);
                       // retWorkList2 = (ArrayList)((objectStockCarEnterCarOutRetWork as CustomSerializeArrayList)[0]);     //ADD 2008/07/17
                    }
                    else
                    {
                        retWorkList = new ArrayList();
                       // retWorkList2 = new ArrayList();     //ADD 2008/07/17
                    }           
                    if ((objectStockCarEnterCarOutRetWork as CustomSerializeArrayList).Count > 0 && (objectStockCarEnterCarOutRetWork as CustomSerializeArrayList)[0] is ArrayList)
                    {                       
                        retWorkList2 = (ArrayList)((objectStockCarEnterCarOutRetWork as CustomSerializeArrayList)[0]);    
                    }
                    else
                    {                     
                        retWorkList2 = new ArrayList();     
                    }
                    // --- UPD 2010/11/15 ----------<<<<<
                    foreach ( object retObj in retWorkList )
                    {
                        if ( retObj is StockAcPayHisSearchRetWork )
                        {
                            retList.Add( CopyToStockAcPayHistFromWork( (StockAcPayHisSearchRetWork)retObj ) );
                        }
                    }

                    // -----ADD 2008/07/17 ------------------------------------------------------------------------------------------------------------------>>>>>
                    // 在庫入出庫照会抽出結果クラス内容取得
                    foreach (object retObj in retWorkList2)
                    {
                        if (retObj is StockCarEnterCarOutRetWork)
                        {
                            retList2.Add(CopyToStockCarEnterCarOutFromWork((StockCarEnterCarOutRetWork)retObj));
                        }
                    }
                    // -----ADD 2008/07/17 ------------------------------------------------------------------------------------------------------------------<<<<<

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				

					// SearchFlg ON
				}
			}
			//全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}
        /// <summary>
        /// データ変換（SearchPara→SearchParaWork）
        /// </summary>
        /// <param name="stockAcPayHisSearchPara"></param>
        /// <returns></returns>
		/// <remarks>
		/// <br>Update Note : 2013/01/15  FSI厚川 宏　管理No.541 買掛オプション追加</br>
		/// </remarks>
        private StockAcPayHisSearchParaWork CopyToSearchParaWorkFromSearchPara ( StockAcPayHisSearchPara stockAcPayHisSearchPara )
        {
            StockAcPayHisSearchParaWork paraWork = new StockAcPayHisSearchParaWork();

            paraWork.EnterpriseCode = stockAcPayHisSearchPara.EnterpriseCode; // 企業コード
            //paraWork.ValidDivCd = stockAcPayHisSearchPara.ValidDivCd; // 有効区分         //DEL 2008/07/17 コンパイルエラーとなる為
            paraWork.St_IoGoodsDay = GetLongDateFromDateTime(stockAcPayHisSearchPara.St_IoGoodsDay); // 開始入出荷日
            paraWork.Ed_IoGoodsDay = GetLongDateFromDateTime(stockAcPayHisSearchPara.Ed_IoGoodsDay); // 終了入出荷日
            paraWork.St_AddUpADate = GetLongDateFromDateTime(stockAcPayHisSearchPara.St_AddUpADate); // 開始計上日付
            paraWork.Ed_AddUpADate = GetLongDateFromDateTime(stockAcPayHisSearchPara.Ed_AddUpADate); // 終了計上日付
            paraWork.AcPaySlipCd = stockAcPayHisSearchPara.AcPaySlipCd; // 受払元伝票区分
            paraWork.SectionCodes = stockAcPayHisSearchPara.SectionCodes; // 拠点コード（複数指定）
            paraWork.St_WarehouseCode = stockAcPayHisSearchPara.St_WarehouseCode; // 開始倉庫コード
            paraWork.Ed_WarehouseCode = stockAcPayHisSearchPara.Ed_WarehouseCode; // 終了倉庫コード
            paraWork.St_GoodsMakerCd = stockAcPayHisSearchPara.St_GoodsMakerCd; // 開始商品メーカーコード
            paraWork.Ed_GoodsMakerCd = stockAcPayHisSearchPara.Ed_GoodsMakerCd; // 終了商品メーカーコード
            paraWork.St_AcPaySlipNum = stockAcPayHisSearchPara.St_AcPaySlipNum; // 開始受払元伝票番号
            paraWork.Ed_AcPaySlipNum = stockAcPayHisSearchPara.Ed_AcPaySlipNum; // 終了受払元伝票番号
            paraWork.St_GoodsNo = stockAcPayHisSearchPara.St_GoodsNo; // 開始商品番号
            paraWork.Ed_GoodsNo = stockAcPayHisSearchPara.Ed_GoodsNo; // 終了商品番号
            paraWork.St_HisYearMonth = stockAcPayHisSearchPara.St_HisYearMonth;     // 履歴開始年月     //ADD 2008/07/17
            paraWork.St_AcPayDate = stockAcPayHisSearchPara.St_AcPayDate;           // 受払開始年月日   //ADD 2008/07/17
            // -----ADD 2013/01/15 ---------------------------------------------------------------------------------------->>>>>            
            paraWork.HasStkPay = HasStockingPayment(); //買掛オプション判定
            // -----ADD 2013/01/15 ----------------------------------------------------------------------------------------<<<<<            
            return paraWork;
        }
        /// <summary>
        /// YYYYMMDD日付取得処理 (但しDateTime.MinValueならば0に変換)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateFromDateTime ( DateTime dateTime )
        {
            if ( dateTime == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ( dateTime.Year * 10000 ) + ( dateTime.Month * 100 ) + dateTime.Day;
            }
        }

		/// <summary>
		/// クラスメンバーコピー処理（クラス⇒ワーククラス）
		/// </summary>
		/// <returns>在庫受払履歴クラス</returns>
		/// <remarks>
		/// <br>Note       : 在庫受払履歴クラスから在庫受払履歴ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
        /* -----DEL 2008/07/17 使用クラス変更の為 --------------------------------------------------------------------->>>>>
        private StockAcPayHisSearchRetWork CopyToStockAcWorkFromStockAc(StockAcPayHist stockAcPayHist)
        {

            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();
		
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //stockAcPayHisSearchRetWork.EnterpriseCode = stockAcPayHist.EnterpriseCode;
            //stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHist.AcPaySlipCd;
            //stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHist.AcPaySlipNum;
            //stockAcPayHisSearchRetWork.GoodsCode = stockAcPayHist.GoodsCode;
            //stockAcPayHisSearchRetWork.GoodsName = stockAcPayHist.GoodsName;
            //stockAcPayHisSearchRetWork.SectionCode = stockAcPayHist.SectionCode;
            //stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHist.BfSectionCode;
            //stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHist.BfEnterWarehCode;
            //stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHist.BfEnterWarehName;
            //stockAcPayHisSearchRetWork.AfAcPayEpCode = stockAcPayHist.AfAcPayEpCode;
            //stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHist.AfEnterWarehCode;
            //stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHist.AfEnterWarehName;
            //stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHist.CustomerCode;
            //stockAcPayHisSearchRetWork.CustomerName = stockAcPayHist.CustomerName;
            //stockAcPayHisSearchRetWork.CustomerName2 = stockAcPayHist.CustomerName2;
            //stockAcPayHisSearchRetWork.SalesFormCode = stockAcPayHist.SalesFormCode;
            //stockAcPayHisSearchRetWork.SalesFormName = stockAcPayHist.SalesFormName;
            //stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHist.ArrivalCnt;
            //stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHist.ShipmentCnt;
            //stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHist.SupplierStock;
            //stockAcPayHisSearchRetWork.TrustCount = stockAcPayHist.TrustCount;
            //stockAcPayHisSearchRetWork.ReservedCount = stockAcPayHist.ReservedCount;
            //stockAcPayHisSearchRetWork.AllowStockCnt = stockAcPayHist.AllowStockCnt;
            //stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHist.AcpOdrCount;
            //stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHist.SalesOrderCount;
            //stockAcPayHisSearchRetWork.EntrustCnt = stockAcPayHist.EntrustCnt;
            //stockAcPayHisSearchRetWork.SoldCnt = stockAcPayHist.SoldCnt;
            //stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHist.MovingSupliStock;
            //stockAcPayHisSearchRetWork.MovingTrustStock = stockAcPayHist.MovingTrustStock;
            //stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHist.ShipmentPosCnt;
            //stockAcPayHisSearchRetWork.StockUnitPrice = stockAcPayHist.StockUnitPrice;
            //stockAcPayHisSearchRetWork.CellphoneModelName = stockAcPayHist.CellphoneModelName;
            //stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHist.InputAgenCd;
            //stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHist.InputAgenNm;
            //stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHist.AcPayNote;

            stockAcPayHisSearchRetWork.IoGoodsDay = stockAcPayHist.IoGoodsDay; // 入出荷日
            stockAcPayHisSearchRetWork.AddUpADate = stockAcPayHist.AddUpADate; // 計上日付
            stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHist.AcPaySlipCd; // 受払元伝票区分
            stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHist.AcPaySlipNum; // 受払元伝票番号
            stockAcPayHisSearchRetWork.AcPaySlipRowNo = stockAcPayHist.AcPaySlipRowNo; // 受払元行番号
            stockAcPayHisSearchRetWork.AcPayHistDateTime = stockAcPayHist.AcPayHistDateTime; // 受払履歴作成日時
            stockAcPayHisSearchRetWork.AcPayTransCd = stockAcPayHist.AcPayTransCd; // 受払元取引区分
            stockAcPayHisSearchRetWork.InputSectionCd = stockAcPayHist.InputSectionCd; // 入力拠点コード
            stockAcPayHisSearchRetWork.InputSectionGuidNm = stockAcPayHist.InputSectionGuidNm; // 入力拠点ガイド名称
            stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHist.InputAgenCd; // 入力担当者コード
            stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHist.InputAgenNm; // 入力担当者名称
            stockAcPayHisSearchRetWork.MoveStatus = stockAcPayHist.MoveStatus; // 移動状態
            stockAcPayHisSearchRetWork.CustSlipNo = stockAcPayHist.CustSlipNo; // 相手先伝票番号
            stockAcPayHisSearchRetWork.SlipDtlNum = stockAcPayHist.SlipDtlNum; // 明細通番
            stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHist.AcPayNote; // 受払備考
            stockAcPayHisSearchRetWork.GoodsMakerCd = stockAcPayHist.GoodsMakerCd; // 商品メーカーコード
            stockAcPayHisSearchRetWork.MakerName = stockAcPayHist.MakerName; // メーカー名称
            stockAcPayHisSearchRetWork.GoodsNo = stockAcPayHist.GoodsNo; // 商品番号
            stockAcPayHisSearchRetWork.GoodsName = stockAcPayHist.GoodsName; // 商品名称
            stockAcPayHisSearchRetWork.BLGoodsCode = stockAcPayHist.BLGoodsCode; // BL商品コード
            stockAcPayHisSearchRetWork.BLGoodsFullName = stockAcPayHist.BLGoodsFullName; // BL商品コード名称（全角）
            stockAcPayHisSearchRetWork.SectionCode = stockAcPayHist.SectionCode; // 拠点コード
            stockAcPayHisSearchRetWork.SectionGuideNm = stockAcPayHist.SectionGuideNm; // 拠点ガイド名称
            stockAcPayHisSearchRetWork.WarehouseCode = stockAcPayHist.WarehouseCode; // 倉庫コード
            stockAcPayHisSearchRetWork.WarehouseName = stockAcPayHist.WarehouseName; // 倉庫名称
            stockAcPayHisSearchRetWork.ShelfNo = stockAcPayHist.ShelfNo; // 棚番
            stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHist.BfSectionCode; // 移動元拠点コード
            stockAcPayHisSearchRetWork.BfSectionGuideNm = stockAcPayHist.BfSectionGuideNm; // 移動元拠点ガイド名称
            stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHist.BfEnterWarehCode; // 移動元倉庫コード
            stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHist.BfEnterWarehName; // 移動元倉庫名称
            stockAcPayHisSearchRetWork.BfShelfNo = stockAcPayHist.BfShelfNo; // 移動元棚番
            stockAcPayHisSearchRetWork.AfSectionCode = stockAcPayHist.AfSectionCode; // 移動先拠点コード
            stockAcPayHisSearchRetWork.AfSectionGuideNm = stockAcPayHist.AfSectionGuideNm; // 移動先拠点ガイド名称
            stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHist.AfEnterWarehCode; // 移動先倉庫コード
            stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHist.AfEnterWarehName; // 移動先倉庫名称
            stockAcPayHisSearchRetWork.AfShelfNo = stockAcPayHist.AfShelfNo; // 移動先棚番
            stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHist.CustomerCode; // 得意先コード
            stockAcPayHisSearchRetWork.CustomerName = stockAcPayHist.CustomerName; // 得意先名称
            stockAcPayHisSearchRetWork.CustomerName2 = stockAcPayHist.CustomerName2; // 得意先名称2
            stockAcPayHisSearchRetWork.CustomerSnm = stockAcPayHist.CustomerSnm; // 得意先略称
            stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHist.ArrivalCnt; // 入荷数
            stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHist.ShipmentCnt; // 出荷数
            stockAcPayHisSearchRetWork.OpenPriceDiv = stockAcPayHist.OpenPriceDiv; // オープン価格区分
            stockAcPayHisSearchRetWork.ListPriceTaxExcFl = stockAcPayHist.ListPriceTaxExcFl; // 定価（税抜，浮動）
            stockAcPayHisSearchRetWork.StockUnitPriceFl = stockAcPayHist.StockUnitPriceFl; // 仕入単価（税抜，浮動）
            stockAcPayHisSearchRetWork.StockPrice = stockAcPayHist.StockPrice; // 仕入金額
            stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl = stockAcPayHist.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            stockAcPayHisSearchRetWork.SalesMoney = stockAcPayHist.SalesMoney; // 売上金額
            stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHist.SupplierStock; // 仕入在庫数
            stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHist.AcpOdrCount; // 受注数
            stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHist.SalesOrderCount; // 発注数
            stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHist.MovingSupliStock; // 移動中仕入在庫数
            stockAcPayHisSearchRetWork.NonAddUpShipmCnt = stockAcPayHist.NonAddUpShipmCnt; // 出荷数（未計上）
            stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt = stockAcPayHist.NonAddUpArrGdsCnt; // 入荷数（未計上）
            stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHist.ShipmentPosCnt; // 出荷可能数
            stockAcPayHisSearchRetWork.PresentStockCnt = stockAcPayHist.PresentStockCnt; // 現在庫数量
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return stockAcPayHisSearchRetWork;
        }
           -----DEL 2008/07/17 ----------------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 ---------------------------------------------------------------------------------------->>>>>
        private StockAcPayHisSearchRetWork CopyToStockAcWorkFromStockAc(StockAcPayHisSearchRet stockAcPayHisSearchRet)
        {
            StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();

            stockAcPayHisSearchRetWork.SectionCode = stockAcPayHisSearchRet.SectionCode;                    // 拠点コード
            stockAcPayHisSearchRetWork.SectionGuideNm = stockAcPayHisSearchRet.SectionGuideNm;              // 拠点ガイド名称
            stockAcPayHisSearchRetWork.WarehouseCode = stockAcPayHisSearchRet.WarehouseCode;                // 倉庫コード
            stockAcPayHisSearchRetWork.WarehouseName = stockAcPayHisSearchRet.WarehouseName;                // 倉庫名称
            stockAcPayHisSearchRetWork.GoodsMakerCd = stockAcPayHisSearchRet.GoodsMakerCd;                  // 商品メーカーコード
            stockAcPayHisSearchRetWork.MakerName = stockAcPayHisSearchRet.MakerName;                        // メーカー名称
            stockAcPayHisSearchRetWork.GoodsNo = stockAcPayHisSearchRet.GoodsNo;                            // 商品番号
            stockAcPayHisSearchRetWork.GoodsName = stockAcPayHisSearchRet.GoodsName;                        // 商品名称
            stockAcPayHisSearchRetWork.IoGoodsDay = stockAcPayHisSearchRet.IoGoodsDay;                      // 入出荷日
            stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHisSearchRet.AcPaySlipNum;                  // 受払元伝票番号
            stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHisSearchRet.AcPaySlipCd;                    // 受払元伝票区分
            stockAcPayHisSearchRetWork.AcPayTransCd = stockAcPayHisSearchRet.AcPayTransCd;                  // 受払元取引区分
            stockAcPayHisSearchRetWork.AfSectionCode = stockAcPayHisSearchRet.AfSectionCode;                // 移動先拠点コード
            stockAcPayHisSearchRetWork.AfSectionGuideNm = stockAcPayHisSearchRet.AfSectionGuideNm;          // 移動先拠点ガイド名称
            stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHisSearchRet.AfEnterWarehCode;          // 移動先倉庫コード
            stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHisSearchRet.AfEnterWarehName;          // 移動先倉庫名称
            stockAcPayHisSearchRetWork.AfShelfNo = stockAcPayHisSearchRet.AfShelfNo;                        // 移動先棚番
            stockAcPayHisSearchRetWork.NonAddUpShipmCnt = stockAcPayHisSearchRet.NonAddUpShipmCnt;          // 出荷数（未計上）
            stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt = stockAcPayHisSearchRet.NonAddUpArrGdsCnt;        // 入荷数（未計上）
            stockAcPayHisSearchRetWork.ListPriceTaxExcFl = stockAcPayHisSearchRet.ListPriceTaxExcFl;        // 定価（税抜，浮動）
            stockAcPayHisSearchRetWork.StockUnitPriceFl = stockAcPayHisSearchRet.StockUnitPriceFl;          // 仕入単価（税抜，浮動）
            stockAcPayHisSearchRetWork.AddUpADate = stockAcPayHisSearchRet.AddUpADate;                      // 計上日付
            stockAcPayHisSearchRetWork.AcPaySlipRowNo = stockAcPayHisSearchRet.AcPaySlipRowNo;              // 受払元行番号
            stockAcPayHisSearchRetWork.InputSectionCd = stockAcPayHisSearchRet.InputSectionCd;              // 入力拠点コード
            stockAcPayHisSearchRetWork.InputSectionGuidNm = stockAcPayHisSearchRet.InputSectionGuidNm;      // 入力拠点ガイド名称
            stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHisSearchRet.InputAgenCd;                    // 入力担当者コード
            stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHisSearchRet.InputAgenNm;                    // 入力担当者名称
            stockAcPayHisSearchRetWork.MoveStatus = stockAcPayHisSearchRet.MoveStatus;                      // 移動状態
            stockAcPayHisSearchRetWork.CustSlipNo = stockAcPayHisSearchRet.CustSlipNo;                      // 相手先伝票番号
            stockAcPayHisSearchRetWork.SlipDtlNum = stockAcPayHisSearchRet.SlipDtlNum;                      // 明細通番
            stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHisSearchRet.AcPayNote;                        // 受払備考
            stockAcPayHisSearchRetWork.BLGoodsCode = stockAcPayHisSearchRet.BLGoodsCode;                    // BL商品コード
            stockAcPayHisSearchRetWork.BLGoodsFullName = stockAcPayHisSearchRet.BLGoodsFullName;            // BL商品コード名称（全角）
            stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHisSearchRet.BfSectionCode;                // 移動元拠点コード
            stockAcPayHisSearchRetWork.BfSectionGuideNm = stockAcPayHisSearchRet.BfSectionGuideNm;          // 移動元拠点ガイド名称
            stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHisSearchRet.BfEnterWarehCode;          // 移動元倉庫コード
            stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHisSearchRet.BfEnterWarehName;          // 移動元倉庫名称
            stockAcPayHisSearchRetWork.BfShelfNo = stockAcPayHisSearchRet.BfShelfNo;                        // 移動元棚番
            stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHisSearchRet.CustomerCode;                  // 得意先コード
            stockAcPayHisSearchRetWork.CustomerSnm = stockAcPayHisSearchRet.CustomerSnm;                    // 得意先略称
            stockAcPayHisSearchRetWork.SupplierCd = stockAcPayHisSearchRet.SupplierCd;                      // 仕入先コード
            stockAcPayHisSearchRetWork.SupplierSnm = stockAcPayHisSearchRet.SupplierSnm;                    // 仕入先略称
            stockAcPayHisSearchRetWork.OpenPriceDiv = stockAcPayHisSearchRet.OpenPriceDiv;                  // オープン価格区分
            stockAcPayHisSearchRetWork.StockPrice = stockAcPayHisSearchRet.StockPrice;                      // 仕入金額
            stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl = stockAcPayHisSearchRet.SalesUnPrcTaxExcFl;      // 売上単価（税抜，浮動）
            stockAcPayHisSearchRetWork.SalesMoney = stockAcPayHisSearchRet.SalesMoney;                      // 売上金額
            stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHisSearchRet.SupplierStock;                // 仕入在庫数
            stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHisSearchRet.AcpOdrCount;                    // 受注数
            stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHisSearchRet.SalesOrderCount;            // 発注数
            stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHisSearchRet.MovingSupliStock;          // 移動中仕入在庫数
            stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHisSearchRet.ShipmentPosCnt;              // 出荷可能数
            stockAcPayHisSearchRetWork.PresentStockCnt = stockAcPayHisSearchRet.PresentStockCnt;            // 現在庫数量
            stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHisSearchRet.ArrivalCnt;                      // 入荷数
            stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHisSearchRet.ShipmentCnt;                    // 出荷数
            stockAcPayHisSearchRetWork.AcPayHistDateTime = stockAcPayHisSearchRet.AcPayHistDateTime;        // 受払履歴作成日時
            stockAcPayHisSearchRetWork.ShelfNo = stockAcPayHisSearchRet.ShelfNo;                            // 棚番

            return stockAcPayHisSearchRetWork;
        }
        // -----ADD 2008/07/17 ----------------------------------------------------------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（クラス⇒ワーククラス）
        ///// </summary>
        ///// <returns>在庫受払履歴クラス</returns>
        ///// <remarks>
        ///// <br>Note       : 在庫受払履歴クラスから在庫受払履歴ワーククラスへメンバーのコピーを行います。</br>
        ///// <br>Programmer : 渡邉貴裕</br>
        ///// <br>Date       : 2007.01.19</br>
        ///// </remarks>
        //private StockAcPayHisSearchRetWork CopyToStockAcWorkFromStockAcDt(StockAcPayHisDt stockAcPayHisDt)
        //{

        //    StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork = new StockAcPayHisSearchRetWork();

        //    stockAcPayHisSearchRetWork.EnterpriseCode = stockAcPayHisDt.EnterpriseCode;
        //    stockAcPayHisSearchRetWork.AcPaySlipCd = stockAcPayHisDt.AcPaySlipCd;
        //    stockAcPayHisSearchRetWork.AcPaySlipNum = stockAcPayHisDt.AcPaySlipNum;
        //    stockAcPayHisSearchRetWork.AcPaySlipRowNo = stockAcPayHisDt.AcPaySlipRowNo;
        //    stockAcPayHisSearchRetWork.AcPaySlipExpNo = stockAcPayHisDt.AcPaySlipExpNo;
        //    stockAcPayHisSearchRetWork.AcPayTransCd = stockAcPayHisDt.AcPayTransCd;
        //    stockAcPayHisSearchRetWork.GoodsCode = stockAcPayHisDt.GoodsCode;
        //    stockAcPayHisSearchRetWork.GoodsName = stockAcPayHisDt.GoodsName;
        //    stockAcPayHisSearchRetWork.SectionCode = stockAcPayHisDt.SectionCode;
        //    stockAcPayHisSearchRetWork.BfSectionCode = stockAcPayHisDt.BfSectionCode;
        //    stockAcPayHisSearchRetWork.BfEnterWarehCode = stockAcPayHisDt.BfEnterWarehCode;
        //    stockAcPayHisSearchRetWork.BfEnterWarehName = stockAcPayHisDt.BfEnterWarehName;
        //    stockAcPayHisSearchRetWork.AfAcPayEpCode = stockAcPayHisDt.AfAcPayEpCode;
        //    stockAcPayHisSearchRetWork.AfEnterWarehCode = stockAcPayHisDt.AfEnterWarehCode;
        //    stockAcPayHisSearchRetWork.AfEnterWarehName = stockAcPayHisDt.AfEnterWarehName;
        //    stockAcPayHisSearchRetWork.CarrierEpCode = stockAcPayHisDt.CarrierEpCode;
        //    stockAcPayHisSearchRetWork.CarrierEpName = stockAcPayHisDt.CarrierEpName;
        //    stockAcPayHisSearchRetWork.CustomerCode = stockAcPayHisDt.CustomerCode;
        //    stockAcPayHisSearchRetWork.CustomerName = stockAcPayHisDt.CustomerName;
        //    stockAcPayHisSearchRetWork.CustomerName2 = stockAcPayHisDt.CustomerName2;
        //    stockAcPayHisSearchRetWork.SalesFormCode = stockAcPayHisDt.SalesFormCode;
        //    stockAcPayHisSearchRetWork.SalesFormName = stockAcPayHisDt.SalesFormName;
        //    stockAcPayHisSearchRetWork.ArrivalCnt = stockAcPayHisDt.ArrivalCnt;
        //    stockAcPayHisSearchRetWork.ShipmentCnt = stockAcPayHisDt.ShipmentCnt;
        //    stockAcPayHisSearchRetWork.SupplierStock = stockAcPayHisDt.SupplierStock;
        //    stockAcPayHisSearchRetWork.TrustCount = stockAcPayHisDt.TrustCount;
        //    stockAcPayHisSearchRetWork.ReservedCount = stockAcPayHisDt.ReservedCount;
        //    stockAcPayHisSearchRetWork.AllowStockCnt = stockAcPayHisDt.AllowStockCnt;
        //    stockAcPayHisSearchRetWork.AcpOdrCount = stockAcPayHisDt.AcpOdrCount;
        //    stockAcPayHisSearchRetWork.SalesOrderCount = stockAcPayHisDt.SalesOrderCount;
        //    stockAcPayHisSearchRetWork.EntrustCnt = stockAcPayHisDt.EntrustCnt;
        //    stockAcPayHisSearchRetWork.SoldCnt = stockAcPayHisDt.SoldCnt;
        //    stockAcPayHisSearchRetWork.MovingSupliStock = stockAcPayHisDt.MovingSupliStock;
        //    stockAcPayHisSearchRetWork.MovingTrustStock = stockAcPayHisDt.MovingTrustStock;
        //    stockAcPayHisSearchRetWork.ShipmentPosCnt = stockAcPayHisDt.ShipmentPosCnt;
        //    stockAcPayHisSearchRetWork.StockUnitPrice = stockAcPayHisDt.StockUnitPrice;
        //    stockAcPayHisSearchRetWork.CellphoneModelName = stockAcPayHisDt.CellphoneModelName;
        //    stockAcPayHisSearchRetWork.InputAgenCd = stockAcPayHisDt.InputAgenCd;
        //    stockAcPayHisSearchRetWork.InputAgenNm = stockAcPayHisDt.InputAgenNm;
        //    stockAcPayHisSearchRetWork.AcPayNote = stockAcPayHisDt.AcPayNote;

        //    return stockAcPayHisSearchRetWork;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// データコピー処理（StockAcPayHisSearchRetWork→StockAcPayHist）
        /// </summary>
        /// <param name="stockAcPayHisSearchRetWork"></param>
        /// <returns></returns>
        /* -----DEL 2008/07/17 使用クラス変更の為 ------------------------------------------------------------------------->>>>>
        private StockAcPayHist CopyToStockAcPayHistFromWork(StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork)
        {
            StockAcPayHist stockAcPayHist = new StockAcPayHist();

            stockAcPayHist.IoGoodsDay = stockAcPayHisSearchRetWork.IoGoodsDay; // 入出荷日
            stockAcPayHist.AddUpADate = stockAcPayHisSearchRetWork.AddUpADate; // 計上日付
            stockAcPayHist.AcPaySlipCd = stockAcPayHisSearchRetWork.AcPaySlipCd; // 受払元伝票区分
            stockAcPayHist.AcPaySlipNum = stockAcPayHisSearchRetWork.AcPaySlipNum; // 受払元伝票番号
            stockAcPayHist.AcPaySlipRowNo = stockAcPayHisSearchRetWork.AcPaySlipRowNo; // 受払元行番号
            stockAcPayHist.AcPayHistDateTime = stockAcPayHisSearchRetWork.AcPayHistDateTime; // 受払履歴作成日時
            stockAcPayHist.AcPayTransCd = stockAcPayHisSearchRetWork.AcPayTransCd; // 受払元取引区分
            stockAcPayHist.InputSectionCd = stockAcPayHisSearchRetWork.InputSectionCd; // 入力拠点コード
            stockAcPayHist.InputSectionGuidNm = stockAcPayHisSearchRetWork.InputSectionGuidNm; // 入力拠点ガイド名称
            stockAcPayHist.InputAgenCd = stockAcPayHisSearchRetWork.InputAgenCd; // 入力担当者コード
            stockAcPayHist.InputAgenNm = stockAcPayHisSearchRetWork.InputAgenNm; // 入力担当者名称
            stockAcPayHist.MoveStatus = stockAcPayHisSearchRetWork.MoveStatus; // 移動状態
            stockAcPayHist.CustSlipNo = stockAcPayHisSearchRetWork.CustSlipNo; // 相手先伝票番号
            stockAcPayHist.SlipDtlNum = stockAcPayHisSearchRetWork.SlipDtlNum; // 明細通番
            stockAcPayHist.AcPayNote = stockAcPayHisSearchRetWork.AcPayNote; // 受払備考
            stockAcPayHist.GoodsMakerCd = stockAcPayHisSearchRetWork.GoodsMakerCd; // 商品メーカーコード
            stockAcPayHist.MakerName = stockAcPayHisSearchRetWork.MakerName; // メーカー名称
            stockAcPayHist.GoodsNo = stockAcPayHisSearchRetWork.GoodsNo; // 商品番号
            stockAcPayHist.GoodsName = stockAcPayHisSearchRetWork.GoodsName; // 商品名称
            stockAcPayHist.BLGoodsCode = stockAcPayHisSearchRetWork.BLGoodsCode; // BL商品コード
            stockAcPayHist.BLGoodsFullName = stockAcPayHisSearchRetWork.BLGoodsFullName; // BL商品コード名称（全角）
            stockAcPayHist.SectionCode = stockAcPayHisSearchRetWork.SectionCode; // 拠点コード
            stockAcPayHist.SectionGuideNm = stockAcPayHisSearchRetWork.SectionGuideNm; // 拠点ガイド名称
            stockAcPayHist.WarehouseCode = stockAcPayHisSearchRetWork.WarehouseCode; // 倉庫コード
            stockAcPayHist.WarehouseName = stockAcPayHisSearchRetWork.WarehouseName; // 倉庫名称
            stockAcPayHist.ShelfNo = stockAcPayHisSearchRetWork.ShelfNo; // 棚番
            stockAcPayHist.BfSectionCode = stockAcPayHisSearchRetWork.BfSectionCode; // 移動元拠点コード
            stockAcPayHist.BfSectionGuideNm = stockAcPayHisSearchRetWork.BfSectionGuideNm; // 移動元拠点ガイド名称
            stockAcPayHist.BfEnterWarehCode = stockAcPayHisSearchRetWork.BfEnterWarehCode; // 移動元倉庫コード
            stockAcPayHist.BfEnterWarehName = stockAcPayHisSearchRetWork.BfEnterWarehName; // 移動元倉庫名称
            stockAcPayHist.BfShelfNo = stockAcPayHisSearchRetWork.BfShelfNo; // 移動元棚番
            stockAcPayHist.AfSectionCode = stockAcPayHisSearchRetWork.AfSectionCode; // 移動先拠点コード
            stockAcPayHist.AfSectionGuideNm = stockAcPayHisSearchRetWork.AfSectionGuideNm; // 移動先拠点ガイド名称
            stockAcPayHist.AfEnterWarehCode = stockAcPayHisSearchRetWork.AfEnterWarehCode; // 移動先倉庫コード
            stockAcPayHist.AfEnterWarehName = stockAcPayHisSearchRetWork.AfEnterWarehName; // 移動先倉庫名称
            stockAcPayHist.AfShelfNo = stockAcPayHisSearchRetWork.AfShelfNo; // 移動先棚番
            stockAcPayHist.CustomerCode = stockAcPayHisSearchRetWork.CustomerCode; // 得意先コード
            stockAcPayHist.CustomerName = stockAcPayHisSearchRetWork.CustomerName; // 得意先名称
            stockAcPayHist.CustomerName2 = stockAcPayHisSearchRetWork.CustomerName2; // 得意先名称2
            stockAcPayHist.CustomerSnm = stockAcPayHisSearchRetWork.CustomerSnm; // 得意先略称
            stockAcPayHist.ArrivalCnt = stockAcPayHisSearchRetWork.ArrivalCnt; // 入荷数
            stockAcPayHist.ShipmentCnt = stockAcPayHisSearchRetWork.ShipmentCnt; // 出荷数
            stockAcPayHist.OpenPriceDiv = stockAcPayHisSearchRetWork.OpenPriceDiv; // オープン価格区分
            stockAcPayHist.ListPriceTaxExcFl = stockAcPayHisSearchRetWork.ListPriceTaxExcFl; // 定価（税抜，浮動）
            stockAcPayHist.StockUnitPriceFl = stockAcPayHisSearchRetWork.StockUnitPriceFl; // 仕入単価（税抜，浮動）
            stockAcPayHist.StockPrice = stockAcPayHisSearchRetWork.StockPrice; // 仕入金額
            stockAcPayHist.SalesUnPrcTaxExcFl = stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            stockAcPayHist.SalesMoney = stockAcPayHisSearchRetWork.SalesMoney; // 売上金額
            stockAcPayHist.SupplierStock = stockAcPayHisSearchRetWork.SupplierStock; // 仕入在庫数
            stockAcPayHist.AcpOdrCount = stockAcPayHisSearchRetWork.AcpOdrCount; // 受注数
            stockAcPayHist.SalesOrderCount = stockAcPayHisSearchRetWork.SalesOrderCount; // 発注数
            stockAcPayHist.MovingSupliStock = stockAcPayHisSearchRetWork.MovingSupliStock; // 移動中仕入在庫数
            stockAcPayHist.NonAddUpShipmCnt = stockAcPayHisSearchRetWork.NonAddUpShipmCnt; // 出荷数（未計上）
            stockAcPayHist.NonAddUpArrGdsCnt = stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt; // 入荷数（未計上）
            stockAcPayHist.ShipmentPosCnt = stockAcPayHisSearchRetWork.ShipmentPosCnt; // 出荷可能数
            stockAcPayHist.PresentStockCnt = stockAcPayHisSearchRetWork.PresentStockCnt; // 現在庫数量        

            return stockAcPayHist;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
           -----DEL 2008/07/17 --------------------------------------------------------------------------------------------<<<<< */
        // -----ADD 2008/07/17 -------------------------------------------------------------------------------------------->>>>>
        private StockAcPayHisSearchRet CopyToStockAcPayHistFromWork(StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork)
        {
            StockAcPayHisSearchRet stockAcPayHisSearchRet = new StockAcPayHisSearchRet();

            stockAcPayHisSearchRet.SectionCode = stockAcPayHisSearchRetWork.SectionCode;                    // 拠点コード
            stockAcPayHisSearchRet.SectionGuideNm = stockAcPayHisSearchRetWork.SectionGuideNm;              // 拠点ガイド名称
            stockAcPayHisSearchRet.WarehouseCode = stockAcPayHisSearchRetWork.WarehouseCode;                // 倉庫コード
            stockAcPayHisSearchRet.WarehouseName = stockAcPayHisSearchRetWork.WarehouseName;                // 倉庫名称
            stockAcPayHisSearchRet.GoodsMakerCd = stockAcPayHisSearchRetWork.GoodsMakerCd;                  // 商品メーカーコード
            stockAcPayHisSearchRet.MakerName = stockAcPayHisSearchRetWork.MakerName;                        // メーカー名称
            stockAcPayHisSearchRet.GoodsNo = stockAcPayHisSearchRetWork.GoodsNo;                            // 商品番号
            stockAcPayHisSearchRet.GoodsName = stockAcPayHisSearchRetWork.GoodsName;                        // 商品名称
            stockAcPayHisSearchRet.IoGoodsDay = stockAcPayHisSearchRetWork.IoGoodsDay;                      // 入出荷日
            stockAcPayHisSearchRet.AcPaySlipNum = stockAcPayHisSearchRetWork.AcPaySlipNum;                  // 受払元伝票番号
            stockAcPayHisSearchRet.AcPaySlipCd = stockAcPayHisSearchRetWork.AcPaySlipCd;                    // 受払元伝票区分
            stockAcPayHisSearchRet.AcPayTransCd = stockAcPayHisSearchRetWork.AcPayTransCd;                  // 受払元取引区分
            stockAcPayHisSearchRet.AfSectionCode = stockAcPayHisSearchRetWork.AfSectionCode;                // 移動先拠点コード
            stockAcPayHisSearchRet.AfSectionGuideNm = stockAcPayHisSearchRetWork.AfSectionGuideNm;          // 移動先拠点ガイド名称
            stockAcPayHisSearchRet.AfEnterWarehCode = stockAcPayHisSearchRetWork.AfEnterWarehCode;          // 移動先倉庫コード
            stockAcPayHisSearchRet.AfEnterWarehName = stockAcPayHisSearchRetWork.AfEnterWarehName;          // 移動先倉庫名称
            stockAcPayHisSearchRet.AfShelfNo = stockAcPayHisSearchRetWork.AfShelfNo;                        // 移動先棚番
            stockAcPayHisSearchRet.NonAddUpShipmCnt = stockAcPayHisSearchRetWork.NonAddUpShipmCnt;          // 出荷数（未計上）
            stockAcPayHisSearchRet.NonAddUpArrGdsCnt = stockAcPayHisSearchRetWork.NonAddUpArrGdsCnt;        // 入荷数（未計上）
            stockAcPayHisSearchRet.ListPriceTaxExcFl = stockAcPayHisSearchRetWork.ListPriceTaxExcFl;        // 定価（税抜，浮動）
            stockAcPayHisSearchRet.StockUnitPriceFl = stockAcPayHisSearchRetWork.StockUnitPriceFl;          // 仕入単価（税抜，浮動）
            stockAcPayHisSearchRet.AddUpADate = stockAcPayHisSearchRetWork.AddUpADate;                      // 計上日付
            stockAcPayHisSearchRet.AcPaySlipRowNo = stockAcPayHisSearchRetWork.AcPaySlipRowNo;              // 受払元行番号
            stockAcPayHisSearchRet.InputSectionCd = stockAcPayHisSearchRetWork.InputSectionCd;              // 入力拠点コード
            stockAcPayHisSearchRet.InputSectionGuidNm = stockAcPayHisSearchRetWork.InputSectionGuidNm;      // 入力拠点ガイド名称
            stockAcPayHisSearchRet.InputAgenCd = stockAcPayHisSearchRetWork.InputAgenCd;                    // 入力担当者コード
            stockAcPayHisSearchRet.InputAgenNm = stockAcPayHisSearchRetWork.InputAgenNm;                    // 入力担当者名称
            stockAcPayHisSearchRet.MoveStatus = stockAcPayHisSearchRetWork.MoveStatus;                      // 移動状態
            stockAcPayHisSearchRet.CustSlipNo = stockAcPayHisSearchRetWork.CustSlipNo;                      // 相手先伝票番号
            stockAcPayHisSearchRet.SlipDtlNum = stockAcPayHisSearchRetWork.SlipDtlNum;                      // 明細通番
            stockAcPayHisSearchRet.AcPayNote = stockAcPayHisSearchRetWork.AcPayNote;                        // 受払備考
            stockAcPayHisSearchRet.BLGoodsCode = stockAcPayHisSearchRetWork.BLGoodsCode;                    // BL商品コード
            stockAcPayHisSearchRet.BLGoodsFullName = stockAcPayHisSearchRetWork.BLGoodsFullName;            // BL商品コード名称（全角）
            stockAcPayHisSearchRet.BfSectionCode = stockAcPayHisSearchRetWork.BfSectionCode;                // 移動元拠点コード
            stockAcPayHisSearchRet.BfSectionGuideNm = stockAcPayHisSearchRetWork.BfSectionGuideNm;          // 移動元拠点ガイド名称
            stockAcPayHisSearchRet.BfEnterWarehCode = stockAcPayHisSearchRetWork.BfEnterWarehCode;          // 移動元倉庫コード
            stockAcPayHisSearchRet.BfEnterWarehName = stockAcPayHisSearchRetWork.BfEnterWarehName;          // 移動元倉庫名称
            stockAcPayHisSearchRet.BfShelfNo = stockAcPayHisSearchRetWork.BfShelfNo;                        // 移動元棚番
            stockAcPayHisSearchRet.CustomerCode = stockAcPayHisSearchRetWork.CustomerCode;                  // 得意先コード
            stockAcPayHisSearchRet.CustomerSnm = stockAcPayHisSearchRetWork.CustomerSnm;                    // 得意先略称
            stockAcPayHisSearchRet.SupplierCd = stockAcPayHisSearchRetWork.SupplierCd;                      // 仕入先コード
            stockAcPayHisSearchRet.SupplierSnm = stockAcPayHisSearchRetWork.SupplierSnm;                    // 仕入先略称
            stockAcPayHisSearchRet.OpenPriceDiv = stockAcPayHisSearchRetWork.OpenPriceDiv;                  // オープン価格区分
            stockAcPayHisSearchRet.StockPrice = stockAcPayHisSearchRetWork.StockPrice;                      // 仕入金額
            stockAcPayHisSearchRet.SalesUnPrcTaxExcFl = stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl;      // 売上単価（税抜，浮動）
            stockAcPayHisSearchRet.SalesMoney = stockAcPayHisSearchRetWork.SalesMoney;                      // 売上金額
            stockAcPayHisSearchRet.SupplierStock = stockAcPayHisSearchRetWork.SupplierStock;                // 仕入在庫数
            stockAcPayHisSearchRet.AcpOdrCount = stockAcPayHisSearchRetWork.AcpOdrCount;                    // 受注数
            stockAcPayHisSearchRet.SalesOrderCount = stockAcPayHisSearchRetWork.SalesOrderCount;            // 発注数
            stockAcPayHisSearchRet.MovingSupliStock = stockAcPayHisSearchRetWork.MovingSupliStock;          // 移動中仕入在庫数
            stockAcPayHisSearchRet.ShipmentPosCnt = stockAcPayHisSearchRetWork.ShipmentPosCnt;              // 出荷可能数
            stockAcPayHisSearchRet.PresentStockCnt = stockAcPayHisSearchRetWork.PresentStockCnt;            // 現在庫数量
            stockAcPayHisSearchRet.ArrivalCnt = stockAcPayHisSearchRetWork.ArrivalCnt;                      // 入荷数
            stockAcPayHisSearchRet.ShipmentCnt = stockAcPayHisSearchRetWork.ShipmentCnt;                    // 出荷数
            stockAcPayHisSearchRet.AcPayHistDateTime = stockAcPayHisSearchRetWork.AcPayHistDateTime;        // 受払履歴作成日時
            stockAcPayHisSearchRet.ShelfNo = stockAcPayHisSearchRetWork.ShelfNo;                            // 棚番

            return stockAcPayHisSearchRet;
        }
        private StockCarEnterCarOutRet CopyToStockCarEnterCarOutFromWork(StockCarEnterCarOutRetWork stockAcPayHisSearchRetWork)
        {
            StockCarEnterCarOutRet stockCarEnterCarOutRet = new StockCarEnterCarOutRet();
            stockCarEnterCarOutRet.StockTotal = stockAcPayHisSearchRetWork.StockTotal;                      // 在庫総数
            stockCarEnterCarOutRet.ArrivalCnt = stockAcPayHisSearchRetWork.ArrivalCnt;                      // 入荷数
            stockCarEnterCarOutRet.ShipmentCnt = stockAcPayHisSearchRetWork.ShipmentCnt;                    // 出荷数
            stockCarEnterCarOutRet.RemainCount = stockAcPayHisSearchRetWork.RemainCount;                    // 残数

            return stockCarEnterCarOutRet;
        }
        // -----ADD 2008/07/17 --------------------------------------------------------------------------------------------<<<<<


		/// <summary>
		/// メモリ生成処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫受払履歴設定アクセスクラスが保持するメモリを生成します。</br>
		/// <br>Programer  : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void MemoryCreate()
		{
			// オンラインの場合
			if (LoginInfoAcquisition.OnlineFlag)
			{
				//---拠点情報取得部品インスタンス化---//
                //this._carrierAcs = new CarrierAcs();
				// ユーザーガイドボディ（HashTable）
				if (this._stockAcPayLstGdBdTable == null)
				{
					this._stockAcPayLstGdBdTable= new Hashtable();
				}
				// ユーザーガイドボディ（ArrayList）
				if (this._stockAcPayLstGdBdList == null)
				{
					this._stockAcPayLstGdBdList = new ArrayList();
				}
			}

            // 在庫受払履歴マスタクラスStatic
			if (_stockAcPayListCH == null)
			{
				_stockAcPayListCH = new Hashtable();
			}
		}

        /// <summary>
        /// ラインアップList比較用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : IComparable インターフェイスの実装。</br>
        /// <br>Programmer : 19077 渡邉貴裕</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public class StockAcPayHistKey : IComparer
        {
            /// <summary>
            /// 在庫受払履歴List比較メソッド
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <remarks>
            /// <br>Note       : xとyを比較し、小さいときはマイナス、</br>
            /// <br>           : 大きいときはプラス、同じときはゼロを返します。</br>
            /// <br>Programmer : 19077 渡邉貴裕</br>
            /// <br>Date       : 2007.05.18</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                //StockAcPayHist carrierX = (StockAcPayHist)x;                  //DEL 2008/07/17 使用クラス変更の為
                //StockAcPayHist carrierY = (StockAcPayHist)y;                  //DEL 2008/07/17 使用クラス変更の為
                StockAcPayHisSearchRet carrierX = (StockAcPayHisSearchRet)x;    //ADD 2008/07/17
                StockAcPayHisSearchRet carrierY = (StockAcPayHisSearchRet)y;    //ADD 2008/07/17

                int year;
                int month;
                int day;
                int xDays;
                int yDays;

                year = carrierX.IoGoodsDay.Year;
                month = carrierX.IoGoodsDay.Month;
                day = carrierX.IoGoodsDay.Day;

                xDays = year * 10000 + month * 10 * day;

                year = carrierY.IoGoodsDay.Year;
                month = carrierY.IoGoodsDay.Month;
                day = carrierY.IoGoodsDay.Day;

                yDays = year * 10000 + month * 10 * day;

                return (xDays - yDays);
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 在庫受払履歴ワーカークラス（ArrayList） ⇒ UIクラス変換処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 在庫受払履歴ワーカークラスをUIの部位部品クラスに変換して、
        /////					 Search用Staticメモリに保持します。</br>
        ///// <br>Programer  : 渡邉貴裕</br>
        ///// <br>Date       : 2007.01.19</br>
        ///// </remarks>
        //private void CopyToStaticFromWorker(ArrayList stockAcPayHistWorkList)
        //{
        //    string hashKey;

        //    foreach (StockAcPayHistWork wkstockAcPayHistWork in stockAcPayHistWorkList)
        //    {
        //        StockAcPayHist wkStockAcPayHist = new StockAcPayHist();

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //hashKey = wkstockAcPayHistWork.EnterpriseCode + "-"
        //        //    //+ wkstockAcPayHistWork.MakerCode + "-"
        //        //        + wkstockAcPayHistWork.GoodsCode + "-"
        //        //        + wkstockAcPayHistWork.AcPaySlipCd + "-"
        //        //        + wkstockAcPayHistWork.AcPaySlipNum + "-"
        //        //;
        //        //wkStockAcPayHist.AcPayNote = wkstockAcPayHistWork.AcPayNote;
        //        //wkStockAcPayHist.AcPaySlipCd = wkstockAcPayHistWork.AcPaySlipCd;
        //        //wkStockAcPayHist.AcPaySlipNum = wkstockAcPayHistWork.AcPaySlipNum;
        //        //wkStockAcPayHist.AcpOdrCount = wkstockAcPayHistWork.AcpOdrCount;
        //        //wkStockAcPayHist.AfAcPayEpCode = wkstockAcPayHistWork.AfAcPayEpCode;
        //        //wkStockAcPayHist.AfEnterWarehCode = wkstockAcPayHistWork.AfEnterWarehCode;
        //        //wkStockAcPayHist.AllowStockCnt = wkstockAcPayHistWork.AllowStockCnt;
        //        //wkStockAcPayHist.ArrivalCnt = wkstockAcPayHistWork.ArrivalCnt;
        //        //wkStockAcPayHist.BfEnterWarehCode = wkstockAcPayHistWork.BfEnterWarehCode;
        //        //wkStockAcPayHist.BfEnterWarehName = wkstockAcPayHistWork.BfEnterWarehName;
        //        //wkStockAcPayHist.BfSectionCode = wkstockAcPayHistWork.BfSectionCode;
        //        //wkStockAcPayHist.CellphoneModelCode = wkstockAcPayHistWork.CellphoneModelCode;
        //        //wkStockAcPayHist.CellphoneModelName = wkstockAcPayHistWork.CellphoneModelName;
        //        //wkStockAcPayHist.CellphoneModelCode = wkstockAcPayHistWork.CellphoneModelCode;
        //        //wkStockAcPayHist.CellphoneModelName = wkstockAcPayHistWork.CellphoneModelName;
        //        //wkStockAcPayHist.CustomerCode = wkstockAcPayHistWork.CustomerCode;
        //        //wkStockAcPayHist.CustomerName = wkstockAcPayHistWork.CustomerName;
        //        //wkStockAcPayHist.CustomerName2 = wkstockAcPayHistWork.CustomerName2;
        //        //wkStockAcPayHist.EnterpriseCode = wkstockAcPayHistWork.EnterpriseCode;
        //        //wkStockAcPayHist.EntrustCnt = wkstockAcPayHistWork.EntrustCnt;
        //        //wkStockAcPayHist.GoodsCode = wkstockAcPayHistWork.GoodsCode;
        //        //wkStockAcPayHist.GoodsName = wkstockAcPayHistWork.GoodsName;
        //        //wkStockAcPayHist.InputAgenCd = wkstockAcPayHistWork.InputAgenCd;
        //        //wkStockAcPayHist.InputAgenNm = wkstockAcPayHistWork.InputAgenNm;
        //        //wkStockAcPayHist.IoGoodsDay = wkstockAcPayHistWork.IoGoodsDay;
        //        //wkStockAcPayHist.MovingSupliStock = wkstockAcPayHistWork.MovingSupliStock;
        //        //wkStockAcPayHist.MovingTrustStock = wkstockAcPayHistWork.MovingTrustStock;
        //        //wkStockAcPayHist.ReservedCount = wkstockAcPayHistWork.ReservedCount;
        //        //wkStockAcPayHist.SalesFormCode = wkstockAcPayHistWork.SalesFormCode;
        //        //wkStockAcPayHist.SalesFormName = wkstockAcPayHistWork.SalesFormName;
        //        //wkStockAcPayHist.SalesOrderCount = wkstockAcPayHistWork.SalesOrderCount;
        //        //wkStockAcPayHist.SectionCode = wkstockAcPayHistWork.SectionCode;
        //        //wkStockAcPayHist.ShipmentCnt = wkstockAcPayHistWork.ShipmentCnt;
        //        //wkStockAcPayHist.ShipmentPosCnt = wkstockAcPayHistWork.ShipmentPosCnt;
        //        //wkStockAcPayHist.SoldCnt = wkstockAcPayHistWork.SoldCnt;
        //        //wkStockAcPayHist.StockUnitPrice = wkstockAcPayHistWork.StockUnitPrice;
        //        //wkStockAcPayHist.SupplierStock = wkstockAcPayHistWork.SupplierStock;
        //        //wkStockAcPayHist.TrustCount = wkstockAcPayHistWork.TrustCount;
        //        //_stockAcPayListCH[hashKey] = wkStockAcPayHist;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 在庫受払履歴ワーカークラス（ArrayList） ⇒ UIクラス変換処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 在庫受払履歴ワーカークラスをUIの部位部品クラスに変換して、
        /////					 Search用Staticメモリに保持します。</br>
        ///// <br>Programer  : 渡邉貴裕</br>
        ///// <br>Date       : 2007.01.19</br>
        ///// </remarks>
        //private void CopyToStaticFromWorkerDt(ArrayList stockAcPayHistWorkList)
        //{
        //    string hashKey;

        //    foreach ( StockAcPayHisDtWork stockAcPayHistDtWork in stockAcPayHistWorkList)
        //    {
        //        StockAcPayHisDt wkStockAcPayHisDt = new StockAcPayHisDt();

        //        hashKey = stockAcPayHistDtWork.EnterpriseCode + "-"
        //                + stockAcPayHistDtWork.GoodsCode + "-"
        //                + stockAcPayHistDtWork.AcPaySlipCd + "-"
        //                + stockAcPayHistDtWork.AcPaySlipNum + "-"
        //        ;
        //        wkStockAcPayHisDt.AcPayNote = stockAcPayHistDtWork.AcPayNote;
        //        wkStockAcPayHisDt.AcPaySlipCd = stockAcPayHistDtWork.AcPaySlipCd;
        //        wkStockAcPayHisDt.AcPaySlipExpNo = stockAcPayHistDtWork.AcPaySlipExpNo;
        //        wkStockAcPayHisDt.AcPaySlipNum = stockAcPayHistDtWork.AcPaySlipNum;
        //        wkStockAcPayHisDt.AcPaySlipRowNo = stockAcPayHistDtWork.AcPaySlipRowNo;
        //        wkStockAcPayHisDt.AcpOdrCount = stockAcPayHistDtWork.AcpOdrCount;
        //        wkStockAcPayHisDt.AfAcPayEpCode = stockAcPayHistDtWork.AfAcPayEpCode;
        //        wkStockAcPayHisDt.AfEnterWarehCode = stockAcPayHistDtWork.AfEnterWarehCode;
        //        wkStockAcPayHisDt.AllowStockCnt = stockAcPayHistDtWork.AllowStockCnt;
        //        wkStockAcPayHisDt.ArrivalCnt = stockAcPayHistDtWork.ArrivalCnt;
        //        wkStockAcPayHisDt.BfEnterWarehCode = stockAcPayHistDtWork.BfEnterWarehCode;
        //        wkStockAcPayHisDt.BfEnterWarehName = stockAcPayHistDtWork.BfEnterWarehName;
        //        wkStockAcPayHisDt.BfSectionCode = stockAcPayHistDtWork.BfSectionCode;
        //        wkStockAcPayHisDt.CarrierEpCode = stockAcPayHistDtWork.CarrierEpCode;
        //        wkStockAcPayHisDt.CarrierEpName = stockAcPayHistDtWork.CarrierEpName;
        //        wkStockAcPayHisDt.CellphoneModelCode = stockAcPayHistDtWork.CellphoneModelCode;
        //        wkStockAcPayHisDt.CellphoneModelName = stockAcPayHistDtWork.CellphoneModelName;
        //        wkStockAcPayHisDt.CustomerCode = stockAcPayHistDtWork.CustomerCode;
        //        wkStockAcPayHisDt.CustomerName = stockAcPayHistDtWork.CustomerName;
        //        wkStockAcPayHisDt.CustomerName2 = stockAcPayHistDtWork.CustomerName2;
        //        wkStockAcPayHisDt.EnterpriseCode = stockAcPayHistDtWork.EnterpriseCode;
        //        wkStockAcPayHisDt.EntrustCnt = stockAcPayHistDtWork.EntrustCnt;
        //        wkStockAcPayHisDt.GoodsCode = stockAcPayHistDtWork.GoodsCode;
        //        wkStockAcPayHisDt.GoodsName = stockAcPayHistDtWork.GoodsName;
        //        wkStockAcPayHisDt.InputAgenCd = stockAcPayHistDtWork.InputAgenCd;
        //        wkStockAcPayHisDt.InputAgenNm = stockAcPayHistDtWork.InputAgenNm;
        //        wkStockAcPayHisDt.IoGoodsDay = stockAcPayHistDtWork.IoGoodsDay;
        //        wkStockAcPayHisDt.MoveStatus = stockAcPayHistDtWork.MoveStatus;
        //        wkStockAcPayHisDt.MovingSupliStock = stockAcPayHistDtWork.MovingSupliStock;
        //        wkStockAcPayHisDt.MovingTrustStock = stockAcPayHistDtWork.MovingTrustStock;
        //        wkStockAcPayHisDt.ProductNumber = stockAcPayHistDtWork.ProductNumber;
        //        wkStockAcPayHisDt.ProductStockGuid = stockAcPayHistDtWork.ProductStockGuid;
        //        wkStockAcPayHisDt.ReservedCount = stockAcPayHistDtWork.ReservedCount;
        //        wkStockAcPayHisDt.RomDiv = stockAcPayHistDtWork.RomDiv;
        //        wkStockAcPayHisDt.SalesFormCode = stockAcPayHistDtWork.SalesFormCode;
        //        wkStockAcPayHisDt.SalesFormName = stockAcPayHistDtWork.SalesFormName;
        //        wkStockAcPayHisDt.SalesOrderCount = stockAcPayHistDtWork.SalesOrderCount;
        //        wkStockAcPayHisDt.SectionCode = stockAcPayHistDtWork.SectionCode;
        //        wkStockAcPayHisDt.ShipmentCnt = stockAcPayHistDtWork.ShipmentCnt;
        //        wkStockAcPayHisDt.ShipmentPosCnt = stockAcPayHistDtWork.ShipmentPosCnt;
        //        wkStockAcPayHisDt.SimProductNumber = stockAcPayHistDtWork.SimProductNumber;
        //        wkStockAcPayHisDt.SoldCnt = stockAcPayHistDtWork.SoldCnt;
        //        wkStockAcPayHisDt.StockState = stockAcPayHistDtWork.StockState;
        //        wkStockAcPayHisDt.StockTelNo1 = stockAcPayHistDtWork.StockTelNo1;
        //        wkStockAcPayHisDt.StockTelNo2 = stockAcPayHistDtWork.StockTelNo2;
        //        wkStockAcPayHisDt.StockUnitPrice = stockAcPayHistDtWork.StockUnitPrice;
        //        wkStockAcPayHisDt.SupplierStock = stockAcPayHistDtWork.SupplierStock;
        //        wkStockAcPayHisDt.TrustCount = stockAcPayHistDtWork.TrustCount;

        //        _stockAcPayListCH[hashKey] = wkStockAcPayHisDt;

        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// ローカルファイル読込み処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
		/// <br>Programer  : 渡邉貴裕</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private void SearchOfflineData()
		{
			// オフラインシリアライズデータ作成部品I/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

			// --- Search用 --- //
			// KeyList設定
			string[] carrierKeys = new string[1];
			carrierKeys[0] = LoginInfoAcquisition.EnterpriseCode;
			// ローカルファイル読込み処理
			object wkObj = offlineDataSerializer.DeSerialize("CarrierAcs", carrierKeys);
			// ArrayListにセット
			ArrayList wkList = wkObj as ArrayList;
			
            //if ((wkList != null) &&
            //    (wkList.Count != 0))
            //{
            //    // 在庫受払履歴クラスワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
            //    CopyToStaticFromWorker(wkList);
            //}
		}
		#endregion

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        public static int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *が存在しないため完全一致検索
                return 0;
            }
        }
		// ---ADD 2013/01/15----->>>>>
        /// <summary>
        /// 買掛管理ありか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :買掛管理あり<br/>
        /// <c>false</c>:買掛管理なし        
        /// </returns>
        /// <remarks>
        /// <br>Note       : USBから買掛オプション有無を読込んで、bool型で返します。</br>
        /// <br>Programer  : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private static bool HasStockingPayment()
        {
            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment
            );            
            return purchaseStatus >= PurchaseStatus.Contract;            
        }
		// ---ADD 2013/01/15-----<<<<<

    }
}
