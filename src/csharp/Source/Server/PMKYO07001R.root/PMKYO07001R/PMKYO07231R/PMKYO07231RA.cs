//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受信仕入データ集計リモート
// プログラム概要   : 仕入データ受信時「仕入月次集計データ、
//                    商品別仕入月次集計データ」を集計する
//                    仕入データ受信時に在庫マスタの更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/05  修正内容 : #24520 発注残クリア時の在庫マスタ更新不正
//----------------------------------------------------------------------------//
// 管理番号              改修担当 : qijh
// 修 正 日  2011/09/13  修正内容 : #24919 発注数が更新されないことを修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 受信仕入データ集計リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 受信仕入データ集計操作を行うクラスです。</br>
	/// <br>Programmer : 張莉莉</br>
	/// <br>Date       : 2011.8.5</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class APTotalizeStockSlip : RemoteDB
	{
		#region [定数定義]
		private const string ctCLASS_NAME = "APTotalizeStockSlip";
		#endregion [定数定義]

		#region [プロパティー定義]
		private APStockInfoConverter _stockInfoConverter = null;
		/// <summary>
		/// 仕入情報ワークコンバーター
		/// </summary>
		private APStockInfoConverter StockInfoConverter
		{
			get
			{
				if (null == _stockInfoConverter)
					_stockInfoConverter = new APStockInfoConverter();
				return _stockInfoConverter;
			}
		}

		private StockSlipDB _stockSlipDB = null;
		/// <summary>
		/// 仕入データDBリモートオブジェクト
		/// </summary>
		private StockSlipDB StockSlipDB
		{
			get
			{
				if (null == _stockSlipDB)
					_stockSlipDB = new StockSlipDB();
				return _stockSlipDB;
			}
		}

		private MonthlyTtlStockUpdDB _monthlyTtlStockUpdDB = null;
		/// <summary>
		/// 仕入月次集計データ更新リモートオブジェクト
		/// </summary>
		private MonthlyTtlStockUpdDB MonthlyTtlStockUpdDB
		{
			get
			{
				if (null == _monthlyTtlStockUpdDB)
					_monthlyTtlStockUpdDB = new MonthlyTtlStockUpdDB();
				return _monthlyTtlStockUpdDB;
			}
		}

		private IOWriteMASIRStockUpdateDB _stockUpdateDB = null;
		/// <summary>
		/// 在庫更新リモートオブジェクト
		/// </summary>
		private IOWriteMASIRStockUpdateDB StockUpdateDB
		{
			get
			{
				if (null == this._stockUpdateDB)
				{

					IOWriteCtrlOptWork ctrlOptWork = new IOWriteCtrlOptWork();
					ctrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
					this._stockUpdateDB = new IOWriteMASIRStockUpdateDB(ctrlOptWork);
				}
				return this._stockUpdateDB;
			}
		}
		#endregion [プロパティー定義]

		#region [パブリック方法]
		/// <summary>
		/// 受信仕入データ集計リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.8.5</br>
		/// </remarks>
		public APTotalizeStockSlip()
		{
		}

		/// <summary>
		/// 仕入受信更新処理
		/// </summary>
		/// <param name="enterpriseCode">受信拠点側の企業コード</param>
		/// <param name="paramStockSlipList">受信した仕入データリスト</param>
		/// <param name="paramStockDetailList">受信した仕入明細データリスト</param>
		/// <param name="stockSlipRecvDiv">仕入データの受信区分</param>
		/// <param name="sqlConnection">DB接続</param>
		/// <param name="sqlTransaction">DBトランザクション</param>
		/// <returns>ステータス</returns>
		public int TotalizeReceivedStockSlip(string enterpriseCode, ArrayList paramStockSlipList, ArrayList paramStockDetailList, int stockSlipRecvDiv, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			// パラメータチェック
			if (!CheckParam(paramStockSlipList, paramStockDetailList))
				return status;

			// 企業コードをバックアップ
			string enterpriseCodeBak = ((APStockSlipWork)paramStockSlipList[0]).EnterpriseCode;
			try
			{
				// 受信拠点側の企業コードをセット
				SetEnterpriseCodeToWorkList(enterpriseCode, paramStockSlipList);
				SetEnterpriseCodeToWorkList(enterpriseCode, paramStockDetailList);
				// 仕入受信更新処理
				status = TotalizeReceivedStockSlipProc(paramStockSlipList, paramStockDetailList, stockSlipRecvDiv, sqlConnection, sqlTransaction);
			}
			finally
			{
				// 企業コードをリストア
				SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramStockSlipList);
				SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramStockDetailList);
			}
			return status;
		}

		/// <summary>
		/// 仕入受信更新処理
		/// </summary>
		/// <param name="paramStockSlipList">受信した仕入データリスト</param>
		/// <param name="paramStockDetailList">受信した仕入明細データリスト</param>
		/// <param name="stockSlipRecvDiv">仕入データの受信区分</param>
		/// <param name="sqlConnection">DB接続</param>
		/// <param name="sqlTransaction">DBトランザクション</param>
		/// <returns>ステータス</returns>
		private int TotalizeReceivedStockSlipProc(ArrayList paramStockSlipList, ArrayList paramStockDetailList, int stockSlipRecvDiv, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			// パラメータを利用して、仕入情報ワークリストを取得(後の処理に当該リストを使用)
			List<APStockInfoWork> stockInfoList = GetAPStockInfoList(paramStockSlipList, paramStockDetailList);
			if (stockInfoList.Count == 0)
				return status;

			// 受信した仕入明細のディクショナリーを取得
			Dictionary<string, APStockDetailWork> stockDetailDic = GetStockDetailDic(paramStockDetailList);

			SqlEncryptInfo sqlEncryptInfo = null;
			bool isHaveStockSlip = false;
			foreach (APStockInfoWork stockInfoWork in stockInfoList)
			{
				StockSlipWork recvdStockSlipWork = null;
				ArrayList recvdStockDetailList = null;
				StockSlipWork secStockSlipWork = null;
				ArrayList secStockDetailList = null;
				// 受信した仕入と仕入明細データと受信拠点側仕入と仕入明細データを取得
				status = GetSecStockInfo(stockInfoWork, out recvdStockSlipWork, out recvdStockDetailList, out secStockSlipWork, out secStockDetailList, sqlConnection, sqlTransaction);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
					// エラーが発生
					return status;

				isHaveStockSlip = (null != secStockSlipWork);// 拠点側仕入ありか

				if (isHaveStockSlip && recvdStockSlipWork.DebitNoteDiv == 0 && secStockSlipWork.DebitNoteDiv == 2)
					// 2:元黒 -> 0:黒伝の場合、集計在庫対象外
					continue;

				// 集計在庫更新前に処理
				TotalizeInitial(recvdStockSlipWork, recvdStockDetailList, secStockDetailList);
								
				if (IsTtlObj(recvdStockSlipWork, secStockSlipWork, isHaveStockSlip))
				{
					// 集計する
					status = TotalizeProc(stockInfoWork, recvdStockSlipWork, recvdStockDetailList, secStockSlipWork, secStockDetailList, sqlConnection, sqlTransaction);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						return status;
				}

				if (2 != stockSlipRecvDiv)
					continue;

				// 在庫更新ありの場合
				CustomSerializeArrayList cstSecList = new CustomSerializeArrayList();
				cstSecList.Add(secStockSlipWork);
				cstSecList.Add(secStockDetailList);

				// 計上元明細リストを取得
				ArrayList addUpOrgDetailList = GetAddUpOrgDetailList(stockDetailDic, recvdStockDetailList);

				CustomSerializeArrayList cstRecvdList = new CustomSerializeArrayList();
				cstRecvdList.Add(recvdStockSlipWork);
				cstRecvdList.Add(recvdStockDetailList);
				cstRecvdList.Add(addUpOrgDetailList);

				object freeParam = null;
				string retMsg = null;
				string retItemInfo = null;

				if (0 == stockInfoWork.StockSlipWork.LogicalDeleteCode)
				{
					// 在庫マスタ更新前準備処理を行い
					status = StockUpdateDB.WriteInitial(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						return status;

					// 在庫マスタ更新処理を行い
					status = StockUpdateDB.Write(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						return status;
				}
				else
				{
					if (secStockSlipWork != null && secStockSlipWork.LogicalDeleteCode == 0)
					{
						// 仕入削除情報を追加
						cstRecvdList.Add(GetStockSlipDeleteWork(secStockSlipWork));

						// 在庫マスタ更新前準備処理を行い
						status = StockUpdateDB.DeleteInitial(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
						if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							return status;

						// 在庫マスタ更新処理を行い
						status = StockUpdateDB.Delete(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
						if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							return status;

					}
				}				
			}
			return status;
		}
		#endregion [パブリック方法]

		#region [プライベート方法]
		/// <summary>
		/// 仕入削除情報を取得
		/// </summary>
		/// <param name="paramStockSlipWork">仕入伝票データ</param>
		/// <returns>仕入削除情報</returns>
		private StockSlipDeleteWork GetStockSlipDeleteWork(StockSlipWork paramStockSlipWork)
		{
			// 仕入削除情報を作成
			StockSlipDeleteWork stockSlipDeleteWork = new StockSlipDeleteWork();
			//仕入形式
			stockSlipDeleteWork.SupplierFormal = paramStockSlipWork.SupplierFormal;
			//赤伝区分
			stockSlipDeleteWork.DebitNoteDiv = paramStockSlipWork.DebitNoteDiv;
			//企業コード
			stockSlipDeleteWork.EnterpriseCode = paramStockSlipWork.EnterpriseCode;
			//仕入伝票番号
			stockSlipDeleteWork.SupplierSlipNo = paramStockSlipWork.SupplierSlipNo;
			//更新日時
			stockSlipDeleteWork.UpdateDateTime = paramStockSlipWork.UpdateDateTime;
			return stockSlipDeleteWork;
		}

		/// <summary>
		/// 仕入集計在庫更新の初期処理を行う
		/// </summary>
		/// <param name="recvdStockSlipWork">受信した仕入データ</param>
		/// <param name="recvdStockDetailList">受信した仕入明細リスト</param>
		/// <param name="secStockDetailList">拠点側の仕入明細リスト</param>
		private void TotalizeInitial(StockSlipWork recvdStockSlipWork, ArrayList recvdStockDetailList, ArrayList secStockDetailList)
		{
			if (recvdStockSlipWork.LogicalDeleteCode == 0)
			{

				// 仕入明細が新規データの場合、又は発注書印刷の場合は発注残数に仕入数を設定
				foreach (StockDetailWork newDtlWork in recvdStockDetailList)
				{
					// ADD 2011.09.08 ---------- >>>>>
					if (newDtlWork.SupplierFormal == 2)
					{
                        newDtlWork.StockCountDifference = newDtlWork.StockCount; // add 2011.09.13 qijh for #24919
						newDtlWork.RemainCntUpdDate = DateTime.Now;
						//発注の場合
						if (newDtlWork.OrderRemainCnt == 0)
						{
							foreach (StockDetailWork oldDtlWork in secStockDetailList)
							{
								//差分数計算の新旧明細比較時に品番、メーカー、倉庫を追加
								if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode &&
									newDtlWork.SupplierFormal == oldDtlWork.SupplierFormal &&
									newDtlWork.StockSlipDtlNum == oldDtlWork.StockSlipDtlNum &&
									newDtlWork.GoodsNo == oldDtlWork.GoodsNo &&
									newDtlWork.GoodsMakerCd == oldDtlWork.GoodsMakerCd &&
									newDtlWork.WarehouseCode == oldDtlWork.WarehouseCode)
								{
									oldDtlWork.StockCount += newDtlWork.StockCount;
								}
							}
						}
					}
					else
					{
					// ADD 2011.09.08 ---------- <<<<<
						newDtlWork.StockCountDifference = newDtlWork.StockCount;
						newDtlWork.OrderRemainCnt = newDtlWork.StockCount;
						newDtlWork.RemainCntUpdDate = DateTime.Now;

						if (recvdStockSlipWork.DebitNoteDiv == 1 || null == secStockDetailList || 0 == secStockDetailList.Count)
							// 赤伝又は拠点側の仕入明細存在しない
							continue;

						foreach (StockDetailWork oldDtlWork in secStockDetailList)
						{

							//差分数計算の新旧明細比較時に品番、メーカー、倉庫を追加
							if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode &&
								newDtlWork.SupplierFormal == oldDtlWork.SupplierFormal &&
								newDtlWork.StockSlipDtlNum == oldDtlWork.StockSlipDtlNum &&
								newDtlWork.GoodsNo == oldDtlWork.GoodsNo &&
								newDtlWork.GoodsMakerCd == oldDtlWork.GoodsMakerCd &&
								newDtlWork.WarehouseCode == oldDtlWork.WarehouseCode)
							{
								// 仕入差分数の設定
								newDtlWork.StockCountDifference = newDtlWork.StockCount - oldDtlWork.StockCount;

								// 発注残数の設定 (更新前発注残数＋更新後仕入差分数)
								newDtlWork.OrderRemainCnt = oldDtlWork.OrderRemainCnt + newDtlWork.StockCountDifference;

								// 仕入差分数が 0 以外の場合は残数更新日を更新する
								if (newDtlWork.StockCountDifference != 0)
								{
									newDtlWork.RemainCntUpdDate = DateTime.Now;
								}
								else
								{
									newDtlWork.RemainCntUpdDate = oldDtlWork.RemainCntUpdDate;
								}
								break;
							}
						}

					}
				}
			}
			else
			{
				// 削除の場合
				if (null != secStockDetailList && secStockDetailList.Count > 0)
				{
					foreach (StockDetailWork oldDtlWork in secStockDetailList)
					{
						oldDtlWork.StockCountDifference = oldDtlWork.StockCount;
					}
				}
			}
		}

		/// <summary>
		/// パラメータをチェック
		/// </summary>
		/// <param name="paramStockSlipList">仕入伝票リスト</param>
		/// <param name="paramStockDetailList">仕入明細リスト</param>
		/// <returns>true:チェックOK、false:チェックNG</returns>
		private bool CheckParam(ArrayList paramStockSlipList, ArrayList paramStockDetailList)
		{
			if (null == paramStockSlipList || null == paramStockDetailList || paramStockSlipList.Count == 0 || paramStockDetailList.Count == 0)
				return false;
			return true;
		}

		/// <summary>
		/// 企業コードをワークリストにセット
		/// </summary>
		/// <param name="code">企業コード</param>
		/// <param name="paramWkList">ワークリスト</param>
		private void SetEnterpriseCodeToWorkList(string code, ArrayList paramWkList)
		{
			if (null == paramWkList || paramWkList.Count == 0)
				return;
			foreach (Broadleaf.Library.Data.IFileHeader header in paramWkList)
				header.EnterpriseCode = code;
		}

		/// <summary>
		/// 計上元明細リストを取得
		/// </summary>
		/// <param name="dic">仕入明細のディクショナリー</param>
		/// <param name="recvdStockDetailList">受信した仕入明細データリスト</param>
		/// <returns>計上元明細リスト</returns>
		private ArrayList GetAddUpOrgDetailList(Dictionary<string, APStockDetailWork> dic, ArrayList recvdStockDetailList)
		{
			ArrayList addUpOrgList = new ArrayList();
			if (null == recvdStockDetailList || recvdStockDetailList.Count == 0)
				return addUpOrgList;

			foreach (StockDetailWork detailwk in recvdStockDetailList)
			{
				if (detailwk.SupplierFormalSrc > 0 && detailwk.StockSlipDtlNumSrc > 0)
				{
					string key = GetStockDetailKey(detailwk.SupplierFormalSrc, detailwk.StockSlipDtlNumSrc);
					if (dic.ContainsKey(key))
					{
						// 計上元明細あり
						APStockDetailWork addUpOrgwk = dic[key];
						if (null != addUpOrgwk)
						{
							AddUpOrgStockDetailWork addUpOrgStockDetailWork = StockInfoConverter.GetAddUpOrgStockDetailWork(addUpOrgwk);
							// 明細関連付けGUIDを設定
							detailwk.DtlRelationGuid = detailwk.FileHeaderGuid;
							addUpOrgStockDetailWork.DtlRelationGuid = detailwk.FileHeaderGuid;
							addUpOrgList.Add(addUpOrgStockDetailWork);
						}
					}
				}
			}
			return addUpOrgList;
		}

		/// <summary>
		/// 仕入明細のキーを作成
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="stockSlipDtlNum">仕入明細通番</param>
		/// <returns>仕入明細のキー</returns>
		private String GetStockDetailKey(int acptAnOdrStatus, long stockSlipDtlNum)
		{
			StringBuilder sbKey = new StringBuilder();
			sbKey.Append(acptAnOdrStatus.ToString().PadLeft(2, '0'));
			sbKey.Append(stockSlipDtlNum.ToString().PadLeft(12, '0'));
			return sbKey.ToString();
		}

		/// <summary>
		/// 受信した仕入明細のディクショナリーを取得
		/// </summary>
		/// <param name="paramStockDetailList">受信した仕入明細データリスト</param>
		/// <returns>ディクショナリー</returns>
		private Dictionary<string, APStockDetailWork> GetStockDetailDic(ArrayList paramStockDetailList)
		{
			Dictionary<string, APStockDetailWork> dic = new Dictionary<string, APStockDetailWork>();
			string key = string.Empty;
			foreach (APStockDetailWork detailwk in paramStockDetailList)
			{
				key = GetStockDetailKey(detailwk.SupplierFormal, detailwk.StockSlipDtlNum);
				if (!dic.ContainsKey(key))
					dic.Add(key, detailwk);
			}
			return dic;
		}

		/// <summary>
		/// 集計対象を判断する
		/// </summary>
		/// <param name="recvdStockSlipWork">受信した仕入データ</param>
		/// <param name="secStockSlipWork">拠点側の仕入データ</param>
		/// <param name="isHaveStockSlip">拠点側の仕入データありかどうか</param>
		/// <returns>true:集計対象 false:集計対象でない</returns>
		private bool IsTtlObj(StockSlipWork recvdStockSlipWork, StockSlipWork secStockSlipWork, bool isHaveStockSlip)
		{
			bool doTotalFlg = false;
			// 集計対象かを判断
			if (recvdStockSlipWork.LogicalDeleteCode == 0)
			{
				// 新規又は更新の場合
				if (recvdStockSlipWork.DebitNoteDiv == 1)
				{
					// 1:赤伝
					if (!isHaveStockSlip)
						doTotalFlg = true;
				}
				else if (recvdStockSlipWork.DebitNoteDiv == 2)
				{
					// 2:元黒
					if (!isHaveStockSlip)
						doTotalFlg = true;
				}
				else
				{
					// 0:黒伝
					if (isHaveStockSlip == false ||
					(isHaveStockSlip && secStockSlipWork.DebitNoteDiv != 2))
						doTotalFlg = true;
				}
			}
			else
			{
				// 伝票削除の場合
				if (isHaveStockSlip && secStockSlipWork.LogicalDeleteCode == 0)
					doTotalFlg = true;
			}
			return doTotalFlg;
		}

		/// <summary>
		/// 受信した仕入と仕入明細データと
		/// 受信拠点側仕入と仕入明細データを取得
		/// </summary>
		/// <param name="paramStockInfoWork">受信した仕入情報</param>
		/// <param name="recvdStockSlipWork">転化した受信の仕入</param>
		/// <param name="recvdStockDetailList">転化した受信の仕入明細リスト</param>
		/// <param name="secStockSlipWork">拠点の仕入</param>
		/// <param name="secStockDetailList">拠点の仕入明細リスト</param>
		/// <param name="sqlConnection">DBの接続</param>
		/// <param name="sqlTransaction">DBトランザクション</param>
		/// <returns>ステータス</returns>
		private int GetSecStockInfo(APStockInfoWork paramStockInfoWork, out StockSlipWork recvdStockSlipWork, out ArrayList recvdStockDetailList,
			out StockSlipWork secStockSlipWork, out ArrayList secStockDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			secStockSlipWork = null;
            secStockDetailList = new ArrayList();

			recvdStockSlipWork = StockInfoConverter.GetSecStockSlipWork(paramStockInfoWork.StockSlipWork); // 受信した仕入データ
			recvdStockDetailList = new ArrayList(); // 受信した仕入明細データリスト
			foreach (APStockDetailWork apDetailWork in paramStockInfoWork.StockDetailWorkList)
			{
				// 受信した仕入明細リストを集計用のパラメータリストにセット
				recvdStockDetailList.Add(StockInfoConverter.GetSecStockDetailWork(apDetailWork));
			}

			// 受信拠点側仕入を取得
			StockSlipReadWork stockSlipReadWork = GetStockSlipReadWork(paramStockInfoWork.StockSlipWork);
			status = StockSlipDB.ReadStockSlipWorkIgnoreDel(out secStockSlipWork, stockSlipReadWork, sqlConnection, sqlTransaction);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
				&& status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
				// エラーが発生
				return status;

			// 受信拠点側に伝票がない
			if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				secStockSlipWork = null;
				return status;
			}

			// 受信拠点の明細データリストを取得
			status = StockSlipDB.ReadStockDetailWorkIgnoreDel(out secStockDetailList, recvdStockDetailList, sqlConnection, sqlTransaction);
			return status;
		}


		/// <summary>
		/// 集計処理を行う
		/// </summary>
		/// <param name="paramStockInfoWork">受信した仕入情報</param>
		/// <param name="recvdStockSlipWork">受信した仕入データ</param>
		/// <param name="recvdStockDetailList">受信した仕入明細リスト</param>
		/// <param name="secStockSlipWork">拠点仕入データ</param>
		/// <param name="secStockDetailList">拠点仕入明細リスト</param>
		/// <param name="sqlConnection">DB接続</param>
		/// <param name="sqlTransaction">DBトランザクション</param>
		/// <returns>ステータス</returns>
		private int TotalizeProc(APStockInfoWork paramStockInfoWork, StockSlipWork recvdStockSlipWork, ArrayList recvdStockDetailList,
			StockSlipWork secStockSlipWork, ArrayList secStockDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			// 集計用のパラメータを作成
			ArrayList newSlipList = new ArrayList(); // 受信した仕入リスト
			ArrayList newItemList = new ArrayList();
			newSlipList.Add(newItemList);
            if (recvdStockSlipWork.LogicalDeleteCode == 0)
			    newItemList.Add(recvdStockSlipWork);
			newItemList.Add(recvdStockDetailList);

			ArrayList oldSlipList = new ArrayList(); // 拠点の仕入リスト
			ArrayList oldItemList = new ArrayList();
			oldSlipList.Add(oldItemList);
			oldItemList.Add(secStockSlipWork);
			oldItemList.Add(secStockDetailList);

			// 集計リモートをコール
			status = MonthlyTtlStockUpdDB.Write(GetMTtlStockUpdParaWork(paramStockInfoWork.StockSlipWork), newSlipList, oldSlipList, sqlConnection, sqlTransaction);
			return status;
		}

		/// <summary>
		/// 仕入月次集計データ更新パラメータを取得する
		/// </summary>
		/// <param name="paramStockSlipWork">受信した仕入データ</param>
		/// <returns>仕入月次集計更新パラメータ</returns>
		private MTtlStockUpdParaWork GetMTtlStockUpdParaWork(APStockSlipWork paramStockSlipWork)
		{
			MTtlStockUpdParaWork mTtlStockUpdParaWork = new MTtlStockUpdParaWork();
			mTtlStockUpdParaWork.EnterpriseCode = paramStockSlipWork.EnterpriseCode;  // 企業コード
			mTtlStockUpdParaWork.StockSectionCd = paramStockSlipWork.SectionCode; // 計上拠点コード(拠点コード)
			mTtlStockUpdParaWork.StockDateYmSt = 0;                                // 計上年月(開始) 0:未指定
			mTtlStockUpdParaWork.StockDateYmEd = 0;                                // 計上年月(終了) 0:未指定
			if (0 == paramStockSlipWork.LogicalDeleteCode)
				mTtlStockUpdParaWork.SlipRegDiv = 1;                                  // 伝票登録区分 1:登録
			else
				mTtlStockUpdParaWork.SlipRegDiv = 0;                                  // 伝票登録区分 0:削除

			return mTtlStockUpdParaWork;
		}

		/// <summary>
		/// 仕入検索条件ワークを取得
		/// </summary>
		/// <param name="paramStockSlipWork">受信した仕入データ</param>
		/// <returns>仕入データ読み込みワーク</returns>
		private StockSlipReadWork GetStockSlipReadWork(APStockSlipWork paramStockSlipWork)
		{
			StockSlipReadWork stockSlipReadWork = new StockSlipReadWork();
			stockSlipReadWork.EnterpriseCode = paramStockSlipWork.EnterpriseCode;
			stockSlipReadWork.SupplierFormal = paramStockSlipWork.SupplierFormal;
			stockSlipReadWork.SupplierSlipNo = paramStockSlipWork.SupplierSlipNo;
			return stockSlipReadWork;
		}

		/// <summary>
		/// 計上元明細かどうかを判断する
		/// </summary>
		/// <param name="paramStockDetailWork">受信した仕入明細データ</param>
		/// <param name="paramStockDetailList">受信した仕入明細データリスト</param>
		/// <returns>true : 計上元明細だ false:計上元明細でない</returns>
		private bool IsAddUpOrgData(APStockDetailWork paramStockDetailWork, ArrayList paramStockDetailList)
		{
			bool isOrgFlg = false;
			for (int i = 0; i < paramStockDetailList.Count; i++)
			{
				APStockDetailWork stockDetailWork = (APStockDetailWork)paramStockDetailList[i];

				if (paramStockDetailWork.SupplierFormal == stockDetailWork.SupplierFormal
					&& paramStockDetailWork.StockSlipDtlNum == stockDetailWork.StockSlipDtlNumSrc)
				{
					isOrgFlg = true;
					return isOrgFlg;
				}
			}
			return isOrgFlg;
		}

		/// <summary>
		/// 受信した仕入情報を組み合わせる
		/// </summary>
		/// <param name="paramStockSlipList">受信した仕入データリスト</param>
		/// <param name="paramStockDetailList">受信した仕入明細データリスト</param>
		/// <returns>組み合わせの仕入情報</returns>
		private List<APStockInfoWork> GetAPStockInfoList(ArrayList paramStockSlipList, ArrayList paramStockDetailList)
		{
			List<APStockInfoWork> stockInfoList = new List<APStockInfoWork>();

			if (null == paramStockSlipList || null == paramStockDetailList
				|| paramStockSlipList.Count == 0 || paramStockDetailList.Count == 0)
				return stockInfoList;

			for (int i = 0; i < paramStockSlipList.Count; i++)
			{
				// 仕入情報ワークを作成
				APStockInfoWork stockInfoWork = new APStockInfoWork();

				APStockSlipWork stockSlipWork = (APStockSlipWork)paramStockSlipList[i];
				// 仕入データを追加
				stockInfoWork.StockSlipWork = stockSlipWork;

				for (int j = 0; j < paramStockDetailList.Count; j++)
				{
					APStockDetailWork stockDetailWork = (APStockDetailWork)paramStockDetailList[j];
					if (stockSlipWork.EnterpriseCode == stockDetailWork.EnterpriseCode
						&& stockSlipWork.SupplierFormal == stockDetailWork.SupplierFormal
						&& stockSlipWork.SupplierSlipNo == stockDetailWork.SupplierSlipNo)
						// 仕入明細データを追加
						stockInfoWork.StockDetailWorkList.Add(stockDetailWork);
				}

				if (stockInfoWork.StockDetailWorkList.Count > 0)
					// 仕入明細がない仕入を対象外とする
					stockInfoList.Add(stockInfoWork);
			}
			return stockInfoList;
		}
		#endregion [プライベート方法]
	}
}
