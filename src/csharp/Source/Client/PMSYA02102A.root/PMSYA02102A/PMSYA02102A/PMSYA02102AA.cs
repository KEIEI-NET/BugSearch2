//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 当月車検車両一覧アクセスクラス
// プログラム概要   : 当月車検車両一覧で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 薛祺
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// Update Note  : 2010/05/08 王海立 redmine #7156の対応
//　　　　　　　: 車種と得意先コードの帳票の印字
//----------------------------------------------------------------------------//
/// Update Note : 2010.05.18 zhangsf Redmine #7784の対応
///             : ・帳票レイアウト修正
//----------------------------------------------------------------------------//
/// Update Note : 2010.05.24 姜凱 Redmine #7784の対応
///             : ・印字順修正
//----------------------------------------------------------------------------//
// Update Note : 2013.04.11 FSI斎藤 和宏 10900269-00 SPK車台番号文字列対応
//              : ・車台No.にVINコードとして17桁まで表示可能にする対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 当月車検車両一覧アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 当月車検車両一覧で使用するデータを取得する</br>
	/// <br>Programmer : 薛祺</br>
	/// <br>Date       : 2010.04.21</br>
	/// </remarks>
	public class MonthCarInspectListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 当月車検車両一覧アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 当月車検車両一覧アクセスクラスの初期化を行う。</br>
		/// <br>Programmer : 薛祺</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		public MonthCarInspectListAcs()
		{
			this._iMonthCarInspectListResultDB = (IMonthCarInspectListResultDB)MediationMonthCarInspectListResultDB.GetMonthCarInspectListResultDB();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		// 当月車検車両一覧検索インタフェース
		IMonthCarInspectListResultDB _iMonthCarInspectListResultDB;

		// DataSetオブジェクト
		private DataSet _dataSet;

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// データセット(読み取り専用)
		/// </summary>
		public DataSet DataSet
		{
			get { return this._dataSet; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 当月車検車両一覧データ取得
		/// <summary>
		/// 当月車検車両一覧データ取得
		/// </summary>
		/// <param name="monthCarInspectListPara">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する当月車検車両一覧データを取得する。</br>
		/// <br>Programmer : 薛祺</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		public int SearchMonthCarInspectListProcMain(MonthCarInspectListPara monthCarInspectListPara, out string errMsg)
		{
			return this.SearchMonthCarInspectListProc(monthCarInspectListPara, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="monthCarInspectListPara">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する当月車検車両一覧データを取得する。</br>
		/// <br>Programmer : 薛祺</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		private int SearchMonthCarInspectListProc(MonthCarInspectListPara monthCarInspectListPara, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = String.Empty;
			try
			{
				// DataTable Create
				PMSYA02105EA.CreateDataTable(ref _dataSet);

				// 抽出条件展開
				MonthCarInspectListParaWork monthCarInspectListParaWork = new MonthCarInspectListParaWork();
				// 画面検索情報->remoteDean>s
				status = this.SetCondInfo(ref monthCarInspectListPara, out monthCarInspectListParaWork, out errMsg);

				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retList = null;
				object paraWorkRef = monthCarInspectListParaWork;
				status = _iMonthCarInspectListResultDB.Search(out retList, paraWorkRef);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						// --- UPD 2010/05/24 ---------->>>>>
						// ConverToDataSetForPdf(_dataSet.Tables[PMSYA02105EA.ct_Tbl_MonthCarInspectListReportData], (ArrayList)retList, monthCarInspectListParaWork);
						ConverToDataSetForPdf(_dataSet.Tables[PMSYA02105EA.ct_Tbl_MonthCarInspectListReportData], (ArrayList)retList, monthCarInspectListParaWork, monthCarInspectListPara);
						// --- UPD 2010/05/24 ----------<<<<<
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

						if (this._dataSet.Tables[PMSYA02105EA.ct_Tbl_MonthCarInspectListReportData].Rows.Count < 1)
						{
							status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						}
						else
						{
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						}
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "当月車検車両一覧表の帳票出力データの取得に失敗しました。";
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
		/// <param name="monthCarInspectListPara">UI抽出条件クラス</param>
		/// <param name="monthCarInspectListParaWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : なし</br>
		/// <br>Programmer : 薛祺</br>
		/// <br>Date	   : 2010.04.21</br>
		/// </remarks>
		private int SetCondInfo(ref MonthCarInspectListPara monthCarInspectListPara, out MonthCarInspectListParaWork monthCarInspectListParaWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			monthCarInspectListParaWork = new MonthCarInspectListParaWork();
			try
			{
				// 企業コード
				monthCarInspectListParaWork.EnterpriseCode = monthCarInspectListPara.EnterpriseCode;

				// 拠点
				if (monthCarInspectListPara.SectionCodes.Length != 0)
				{
					if (monthCarInspectListPara.IsSelectAllSection)
					{
						// 全社の時
						monthCarInspectListParaWork.MngSectionCode = null;
					}
					else
					{
						monthCarInspectListParaWork.MngSectionCode = monthCarInspectListPara.SectionCodes;
					}
				}
				else
				{
					monthCarInspectListParaWork.MngSectionCode = null;
				}

				// 開始得意先コード
				monthCarInspectListParaWork.StCustomerCode = monthCarInspectListPara.StCustomerCode;
				// 終了得意先コード
				monthCarInspectListParaWork.EdCustomerCode = monthCarInspectListPara.EdCustomerCode;

				// 開始車輌管理コード
				monthCarInspectListParaWork.StCarMngCode = monthCarInspectListPara.StCarMngCode;
				// 終了車輌管理コード
				monthCarInspectListParaWork.EdCarMngCode = monthCarInspectListPara.EdCarMngCode;

				// 車検満期日
				monthCarInspectListParaWork.InspectMaturityDate = monthCarInspectListPara.InspectMaturityDate;
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// DataTableにデータを設定処理
		/// </summary>
		/// <param name="dataTable">帳票用DataTable</param>
		/// <param name="retList">検索情報リスト</param>
		/// <param name="paraWork">paraWork</param>
		/// <remarks>
		/// <br>Note       : なし</br>
		/// <br>Programmer : 薛祺</br>
		/// <br>Date       : 2010.04.21</br>
		/// <br>Update Note: 2010/05/10 王海立 車種と得意先コードの帳票の印字</br>
		/// </remarks>
		// --- UPD 2010/05/24 ---------->>>>>
		//private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, MonthCarInspectListParaWork paraWork)
		private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, MonthCarInspectListParaWork paraWork, MonthCarInspectListPara monthCarInspectListPara)
		{

			// 比較用の得意先コード
			string nextCustomerCode = string.Empty;
			// 比較用の得意先コード+車検満期日
			string nextCustomerCode_InspectMaturityDate = string.Empty;
			// 改頁 = べた打ちの場合、一つページは30件は表示します。
			int pageRow = 30;
			// 改頁 = 1行空行の場合、一つページは15件は表示します。
			int pageRow2 = 15;

			if ((int)monthCarInspectListPara.ChangeRowDiv == 1)
			{
				// 改頁 = 1行空行の場合、一つページは15件は表示します。
				pageRow = pageRow2;
			}
			// --- UPD 2010/05/24 ----------<<<<<

			for (int i = 0; i < retList.Count; i++)
			{
				MonthCarInspectListResultWork rsltInfo = (MonthCarInspectListResultWork)retList[i];
				DataRow dr = null;
				dr = dataTable.NewRow();

				// 同一得意先は印字しない、ページが変わったときは印字する。
				if ((!nextCustomerCode.Equals(string.Format("{0:D8}", rsltInfo.CustomerCode)))
					|| (((int)monthCarInspectListPara.ChangePageDiv == 0) && (i % pageRow == 0)))
				{
					// 得意先コード
					dr[PMSYA02105EA.ct_Col_CustomerCode] = string.Format("{0:D8}", rsltInfo.CustomerCode);
					// 得意先略称
					dr[PMSYA02105EA.ct_Col_CustomerSnm] = rsltInfo.CustomerSnm;
				}
				else
				{
					// 得意先コード
					dr[PMSYA02105EA.ct_Col_CustomerCode] = string.Empty;
					// 得意先略称
					dr[PMSYA02105EA.ct_Col_CustomerSnm] = string.Empty;
				}

				// 管理拠点コード
				dr[PMSYA02105EA.ct_Col_MngSectionCode] = rsltInfo.MngSectionCode;
				// 企業コード
				dr[PMSYA02105EA.ct_Col_EnterpriseCode] = rsltInfo.EnterpriseCode;
				// 論理削除区分
				dr[PMSYA02105EA.ct_Col_LogicalDeleteCode] = rsltInfo.LogicalDeleteCode;
				// --- UPD 2010/05/24 ---------->>>>>
				// 得意先コード
				// --- UPD 2010/05/10 ---------->>>>>
				//dr[PMSYA02105EA.ct_Col_CustomerCode] = rsltInfo.CustomerCode;
				//dr[PMSYA02105EA.ct_Col_CustomerCode] = string.Format("{0:D8}", rsltInfo.CustomerCode);
				// --- UPD 2010/05/10 ----------<<<<<
				// 比較用の得意先コード
				nextCustomerCode = string.Format("{0:D8}", rsltInfo.CustomerCode);
				// --- UPD 2010/05/24 ----------<<<<<
				// 車両管理番号
				dr[PMSYA02105EA.ct_Col_CarMngNo] = rsltInfo.CarMngNo;
				// 車輌管理コード
				dr[PMSYA02105EA.ct_Col_CarMngCode] = rsltInfo.CarMngCode;
				// 登録番号
				StringBuilder numberPlate = new StringBuilder();
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate1Name))
				{
					// 陸運事務局名称
					//numberPlate.Append(rsltInfo.NumberPlate1Name);// DEL 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append(rsltInfo.NumberPlate1Name.PadRight(4, '　'));// ADD 2010.05.18 zhangsf FOR Redmine #7784
				}
				else // ADD 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append("　　　　");// ADD 2010.05.18 zhangsf FOR Redmine #7784
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate2))
				{
					if (!string.IsNullOrEmpty(numberPlate.ToString()))
					{
						numberPlate.Append(" ");
					}
					// 車両登録番号（種別）
					//numberPlate.Append(rsltInfo.NumberPlate2);// DEL 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append(rsltInfo.NumberPlate2.PadLeft(3, ' '));// ADD 2010.05.18 zhangsf FOR Redmine #7784
				}
				else // ADD 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append("   ");// ADD 2010.05.18 zhangsf FOR Redmine #7784
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate3))
				{
					if (!string.IsNullOrEmpty(numberPlate.ToString()))
					{
						numberPlate.Append(" ");
					}
					// 車両登録番号（カナ）
					numberPlate.Append(rsltInfo.NumberPlate3);
				}
				else // ADD 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append("　");// ADD 2010.05.18 zhangsf FOR Redmine #7784
				if (!string.IsNullOrEmpty(numberPlate.ToString()))
				{
					numberPlate.Append(" ");
				}
				if (rsltInfo.NumberPlate4 != 0)// ADD 2010.05.18 zhangsf FOR Redmine #7784
					// 車両登録番号（プレート番号）
					//numberPlate.Append(rsltInfo.NumberPlate4.ToString());// DEL 2010.05.18 zhangsf FOR Redmine #7784
					numberPlate.Append((rsltInfo.NumberPlate4.ToString()).PadLeft(4, ' '));// ADD 2010.05.18 zhangsf FOR Redmine #7784

				dr[PMSYA02105EA.ct_Col_NumberPlate] = numberPlate.ToString();
				// 初年度 
				if (rsltInfo.FirstEntryDate == "0")
				{
					// 0のときは空白
					dr[PMSYA02105EA.ct_Col_FirstEntryDate] = string.Empty;
				}
				else if (rsltInfo.FirstEntryDate.Length == 6)
				{

					dr[PMSYA02105EA.ct_Col_FirstEntryDate] = rsltInfo.FirstEntryDate.Substring(0, 4) + "/" + rsltInfo.FirstEntryDate.Substring(4, 2);
				}

				// 車種コード
				// --- UPD 2010/05/10 ---------->>>>>
				//dr[PMSYA02105EA.ct_Col_ModelCode] = rsltInfo.MakerCode + "-" + rsltInfo.ModelCode + "-" + rsltInfo.ModelSubCode;
				dr[PMSYA02105EA.ct_Col_ModelCode] = string.Format("{0:D3}", rsltInfo.MakerCode) + "-" + string.Format("{0:D3}", rsltInfo.ModelCode) + "-" + string.Format("{0:D3}", rsltInfo.ModelSubCode);
				// --- UPD 2010/05/10 ----------<<<<<
				// 車種半角名称
				dr[PMSYA02105EA.ct_Col_ModelHalfName] = rsltInfo.ModelHalfName;
				// 型式（フル型）
				dr[PMSYA02105EA.ct_Col_FullModel] = rsltInfo.FullModel;
				// 車台番号
				//dr[PMSYA02105EA.ct_Col_FrameNo] = rsltInfo.FrameNo;// DEL 2010.05.18 zhangsf FOR Redmine #7784
				// ADD 2010.05.18 zhangsf FOR Redmine #7784 *-------------------->>>
				if (!string.IsNullOrEmpty(rsltInfo.NumberPlate1Name))
				{
					string frameNo;
                    // --- DEL 2013/04/11 ---------->>>>>
                    //if (rsltInfo.FrameNo.Length >= 8)
                    //    frameNo = rsltInfo.FrameNo.Substring(0, 8);
                    //else
                    //    frameNo = rsltInfo.FrameNo.PadLeft(8, ' ');
                    // --- DEL 2013/04/11 ----------<<<<<
                    // --- ADD 2013/04/11 ---------->>>>>
                    // 文字列として扱うので、右詰め表示は行わない。
                    if (rsltInfo.FrameNo.Length >= 17)
                        frameNo = rsltInfo.FrameNo.Substring(0, 17);
                    else
                        frameNo = rsltInfo.FrameNo;
                    // --- ADD 2013/04/11 ----------<<<<<

					dr[PMSYA02105EA.ct_Col_FrameNo] = frameNo;
				}
				else
				{
					dr[PMSYA02105EA.ct_Col_FrameNo] = "";
				}
				// ADD 2010.05.18 zhangsf FOR Redmine #7784 <<<--------------------*
				// --- UPD 2010/05/24 ---------->>>>>
				// 同一得意先コード+車検満期日は印字しない
				if (!nextCustomerCode_InspectMaturityDate.Equals(string.Format("{0:D8}", rsltInfo.CustomerCode)
					+ "|" + rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd")))
				{
					// 車検満期日
					dr[PMSYA02105EA.ct_Col_InspectMaturityDate] = rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd");
				}
				else
				{
					// 車検満期日
					dr[PMSYA02105EA.ct_Col_InspectMaturityDate] = string.Empty;
				}
				// 比較用の得意先コード+車検満期日
				nextCustomerCode_InspectMaturityDate = string.Format("{0:D8}", rsltInfo.CustomerCode) + "|"
					+ rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd");
				// --- UPD 2010/05/24 ----------<<<<<

				// 車検期間
				dr[PMSYA02105EA.ct_Col_CarInspectYear] = rsltInfo.CarInspectYear;
				// Group (車検満期日 +
				//dr[PMSYA02105EA.ct_Col_Group] = rsltInfo.InspectMaturityDate.ToString("yyyy/MM/dd") + rsltInfo.CustomerCode;// DEL 2010.05.18 zhangsf FOR Redmine #7784
				dr[PMSYA02105EA.ct_Col_Group] = rsltInfo.CustomerCode;// ADD 2010.05.18 zhangsf FOR Redmine #7784

				dataTable.Rows.Add(dr);
			}
		}
		#endregion
		#endregion ◆ データ展開処理

		#endregion ■ Private Method
	}
}
