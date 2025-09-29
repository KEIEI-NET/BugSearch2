using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// <summary>
	/// 請求印刷設定マスタアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求印刷設定マスタのアクセス制御を行います。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2005.08.03</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.20 22021 谷藤　範幸</br>
	/// <br>			・得意先電話番号印字区分の追加</br>
	/// <br>Update Note: 2006.01.27 22021 谷藤　範幸</br>
	/// <br>			・請求書印刷一時中断枚数の追加</br>
	/// <br>Update Note:   2006.06.01 23001 秋山　亮介</br>
	/// <br>                          1.集金予定表出力区分を追加</br>
	/// <br>                          2.集金予定表集金予定額（諸費用）を追加</br>
	/// <br>                          3.集金予定表出力タイプを追加</br>
	/// <br>Update Note: 2007.06.27 20031 古賀　小百合</br>
    /// <br>			・テーブル修正による項目削除</br>
    /// <br>                1.請求前受付出力区分を削除</br>
    /// <br>                2.請求書消費税出力区分を削除</br>
    /// <br>                3.請求書自社プロテクト印刷名称１～４を削除</br>
    /// <br>                4.請求書摘要１、２を削除</br>
    /// <br>                5.集金予定表出力区分を削除</br>
    /// <br>                6.集金予定表集金予定額（諸費用）を削除</br>
    /// <br>                7.集金予定表出力タイプを削除</br>
    /// </remarks>
	/// </summary>
	public class BillPrtStAcs
	{	
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IBillPrtStDB _iBillPrtStDB = null;

		/// <summary>
		/// 請求印刷設定マスタアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求印刷設定マスタの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		public BillPrtStAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iBillPrtStDB = (IBillPrtStDB)MediationBillPrtStDB.GetBillPrtStDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iBillPrtStDB = null;
			}
		}

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iBillPrtStDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// 自賠責設定読み込み処理
		/// </summary>
		/// <param name="billPrtSt">自賠責設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>自賠責設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自賠責設定を読み込みます。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Read(out BillPrtSt billPrtSt, string enterpriseCode)
		{			
			try
			{
				billPrtSt = null;
				BillPrtStWork billPrtStWork = new BillPrtStWork();
				billPrtStWork.EnterpriseCode = enterpriseCode;

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(billPrtStWork);

				//自賠責設定読み込み
				int status = this._iBillPrtStDB.Read(ref parabyte,0);

				if (status == 0)
				{
					// XMLの読み込み
					billPrtStWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));
					// クラス内メンバコピー
					billPrtSt = CopyToBillPrtStFromBillPrtStWork(billPrtStWork);
				}
				
				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				billPrtSt = null;
				//オフライン時はnullをセット
				this._iBillPrtStDB = null;
				return -1;
			}
		}

		/// <summary>
		/// 自賠責設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>自賠責設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自賠責設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public BillPrtSt Deserialize(string fileName)
		{
			BillPrtSt billPrtSt = null;
			// ファイル名を渡して自賠責設定ワーククラスをデシリアライズする
			BillPrtStWork billPrtStWork = (BillPrtStWork)XmlByteSerializer.Deserialize(fileName,typeof(BillPrtStWork));

			//デシリアライズ結果を自賠責設定クラスへコピー
			if (billPrtStWork != null) billPrtSt = CopyToBillPrtStFromBillPrtStWork(billPrtStWork);

			return billPrtSt;
		}

		/// <summary>
		/// 自賠責設定Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>自賠責設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 自賠責設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList billPrtStList = new ArrayList();
			// ファイル名を渡して自賠責設定ワーククラスをデシリアライズする
			BillPrtStWork[] billPrtStWorks = (BillPrtStWork[])XmlByteSerializer.Deserialize(fileName,typeof(BillPrtStWork[]));

			//デシリアライズ結果を自賠責設定クラスへコピー
			if (billPrtStWorks != null) 
			{
				billPrtStList.Capacity = billPrtStWorks.Length;
				for(int i=0; i < billPrtStWorks.Length; i++)
				{
					billPrtStList.Add(CopyToBillPrtStFromBillPrtStWork(billPrtStWorks[i]));
				}
			}
			return billPrtStList;
		}

		/// <summary>
		/// 自賠責設定登録・更新処理
		/// </summary>
		/// <param name="billPrtSt">自賠責設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自賠責設定の登録・更新を行います。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref BillPrtSt billPrtSt)
		{
			//クラスからワーカークラスにメンバコピー
			BillPrtStWork billPrtStWork = CopyToBillPrtStWorkFromBillPrtSt(billPrtSt);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(billPrtStWork);

			int status = 0;
			try
			{
				//書き込み
				status = this._iBillPrtStDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡してワーククラスをデシリアライズする
					billPrtStWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));
					// クラス内メンバコピー
					billPrtSt = CopyToBillPrtStFromBillPrtStWork(billPrtStWork);
				}

			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iBillPrtStDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 自賠責設定シリアライズ処理
		/// </summary>
		/// <param name="billPrtSt">シリアライズ対象自賠責設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 自賠責設定のシリアライズを行います。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void Serialize(BillPrtSt billPrtSt,string fileName)
		{
			//クラスからワーカークラスにメンバコピー
			BillPrtStWork billPrtStWork = CopyToBillPrtStWorkFromBillPrtSt(billPrtSt);
			//ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(billPrtStWork,fileName);
		}

		/// <summary>
		/// 自賠責設定Listシリアライズ処理
		/// </summary>
		/// <param name="billPrtStList">シリアライズ対象自賠責設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 自賠責設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void ListSerialize(ArrayList billPrtStList,string fileName)
		{
			BillPrtStWork[] billPrtStWorks = new BillPrtStWork[billPrtStList.Count];
			for(int i= 0; i < billPrtStList.Count; i++)
			{
				billPrtStWorks[i] = CopyToBillPrtStWorkFromBillPrtSt((BillPrtSt)billPrtStList[i]);
			}
			//自賠責設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(billPrtStWorks,fileName);
		}

		/// <summary>
		/// クラスメンバーコピー処理（自賠責設定ワーククラス⇒自賠責設定クラス）
		/// </summary>
		/// <returns>自賠責設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自賠責設定ワーククラスから自賠責設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		// <param name="billPrtStWork">自賠責設定ワーククラス</param>
		private BillPrtSt CopyToBillPrtStFromBillPrtStWork(BillPrtStWork billPrtStWork)
		{
			BillPrtSt billPrtSt = new BillPrtSt();

			//ファイルヘッダ部分
			billPrtSt.CreateDateTime			= billPrtStWork.CreateDateTime;
			billPrtSt.UpdateDateTime			= billPrtStWork.UpdateDateTime;
			billPrtSt.EnterpriseCode			= billPrtStWork.EnterpriseCode;
			billPrtSt.FileHeaderGuid			= billPrtStWork.FileHeaderGuid;
			billPrtSt.UpdEmployeeCode		    = billPrtStWork.UpdEmployeeCode;
			billPrtSt.UpdAssemblyId1			= billPrtStWork.UpdAssemblyId1;
			billPrtSt.UpdAssemblyId2			= billPrtStWork.UpdAssemblyId2;
			billPrtSt.LogicalDeleteCode		    = billPrtStWork.LogicalDeleteCode;

			//請求印刷設定管理コード
			billPrtSt.BillPrtStMngCd            = billPrtStWork.BillPrtStMngCd;//TODO 必要か？

			//金額出力区分
			billPrtSt.BillTableOutCd			= billPrtStWork.BillTableOutCd;
			billPrtSt.TotalBillOutputDiv		= billPrtStWork.TotalBillOutputDiv;
			billPrtSt.DetailBillOutputCode      = billPrtStWork.DetailBillOutputCode;

            # region 2007.06.27  S.Koga  DEL
            //// 請求前受付出力区分
            //billPrtSt.BillBfRmonOutItem			= billPrtStWork.BillBfRmonOutItem;
			
            ////請求書消費税出力区分
            //billPrtSt.BillConsTaxOutPutCd	    = billPrtStWork.BillConsTaxOutPutCd;
            # endregion

            //請求末日印字区分
			billPrtSt.BillLastDayPrtDiv			= billPrtStWork.BillLastDayPrtDiv;

            # region 2007.06.27  S.Koga  DEL
            ////請求書自社プロテクト印刷名称
            //billPrtSt.BillEpProtectPrtNm1			= billPrtStWork.BillEpProtectPrtNm1;
            //billPrtSt.BillEpProtectPrtNm2			= billPrtStWork.BillEpProtectPrtNm2;
            //billPrtSt.BillEpProtectPrtNm3			= billPrtStWork.BillEpProtectPrtNm3;
            //billPrtSt.BillEpProtectPrtNm4			= billPrtStWork.BillEpProtectPrtNm4;
            # endregion

			//請求書自社名印字区分
			billPrtSt.BillCoNmPrintOutCd			= billPrtStWork.BillCoNmPrintOutCd;
			
			//請求書銀行名印字区分 
			billPrtSt.BillBankNmPrintOut			= billPrtStWork.BillBankNmPrintOut;

            # region 2007.06.27  S.Koga  DEL
            ////請求書摘要
            //billPrtSt.BillOutline1					= billPrtStWork.BillOutline1;
            //billPrtSt.BillOutline2					= billPrtStWork.BillOutline2;
            # endregion

            // 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//得意先電話番号印字区分 
			billPrtSt.CustTelNoPrtDivCd				= billPrtStWork.CustTelNoPrtDivCd;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //請求書一時中断枚数
            billPrtSt.BillPrtSuspendCnt				= billPrtStWork.BillPrtSuspendCnt;
            // 2005.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
               --- DEL 2008/06/13 --------------------------------<<<<< */

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// 集金予定表出力区分
            //billPrtSt.ClctMnyPlnDocOutCd            = billPrtStWork.ClctMnyPlnDocOutCd;
            //// 集金予定表集金予定額（諸費用）
            //billPrtSt.ClctMnyPlnDocVarCst           = billPrtStWork.ClctMnyPlnDocVarCst;
            //// 集金予定表出力タイプ
            //billPrtSt.ClctMnyPlnDocOutType          = billPrtStWork.ClctMnyPlnDocOutType;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

            return billPrtSt;
		}

		/// <summary>
		/// クラスメンバーコピー処理（自賠責設定クラス⇒自賠責設定ワーククラス）
		/// </summary>
		/// <param name="billPrtSt">自賠責設定ワーククラス</param>
		/// <returns>自賠責設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自賠責設定クラスから自賠責設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 92041 坂本　明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private BillPrtStWork CopyToBillPrtStWorkFromBillPrtSt(BillPrtSt billPrtSt)
		{
			BillPrtStWork billPrtStWork = new BillPrtStWork();

			billPrtStWork.CreateDateTime			= billPrtSt.CreateDateTime;
			billPrtStWork.UpdateDateTime			= billPrtSt.UpdateDateTime;
			billPrtStWork.EnterpriseCode			= billPrtSt.EnterpriseCode;
			billPrtStWork.FileHeaderGuid			= billPrtSt.FileHeaderGuid;
			billPrtStWork.UpdEmployeeCode		    = billPrtSt.UpdEmployeeCode;
			billPrtStWork.UpdAssemblyId1			= billPrtSt.UpdAssemblyId1;
			billPrtStWork.UpdAssemblyId2			= billPrtSt.UpdAssemblyId2;
			billPrtStWork.LogicalDeleteCode		    = billPrtSt.LogicalDeleteCode;
			
			//請求印刷設定管理コード
			billPrtStWork.BillPrtStMngCd            = billPrtSt.BillPrtStMngCd;//TODO 必要か？

			//金額出力区分
			billPrtStWork.BillTableOutCd			= billPrtSt.BillTableOutCd;
			billPrtStWork.TotalBillOutputDiv		= billPrtSt.TotalBillOutputDiv;
			billPrtStWork.DetailBillOutputCode      = billPrtSt.DetailBillOutputCode;

            # region 2007.06.27  S.Koga  DEL
            //// 請求前受付出力区分
            //billPrtStWork.BillBfRmonOutItem			= billPrtSt.BillBfRmonOutItem;

            ////請求書消費税出力区分
            //billPrtStWork.BillConsTaxOutPutCd	    = billPrtSt.BillConsTaxOutPutCd;
            # endregion

            //請求末日印字区分
			billPrtStWork.BillLastDayPrtDiv			= billPrtSt.BillLastDayPrtDiv;

            # region 2007.06.27  S.Koga  DEL
            ////請求書自社プロテクト印刷名称
            //billPrtStWork.BillEpProtectPrtNm1			= billPrtSt.BillEpProtectPrtNm1;
            //billPrtStWork.BillEpProtectPrtNm2			= billPrtSt.BillEpProtectPrtNm2;
            //billPrtStWork.BillEpProtectPrtNm3			= billPrtSt.BillEpProtectPrtNm3;
            //billPrtStWork.BillEpProtectPrtNm4			= billPrtSt.BillEpProtectPrtNm4;
            # endregion

            //請求書自社名印字区分
			billPrtStWork.BillCoNmPrintOutCd			= billPrtSt.BillCoNmPrintOutCd;
			
			//請求書銀行名印字区分 
			billPrtStWork.BillBankNmPrintOut			= billPrtSt.BillBankNmPrintOut;

            # region 2007.06.27  S.Koga DEL
            ////請求書摘要
            //billPrtStWork.BillOutline1					= billPrtSt.BillOutline1;
            //billPrtStWork.BillOutline2					= billPrtSt.BillOutline2;
            # endregion

            // 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//得意先電話番号印字区分 
			billPrtStWork.CustTelNoPrtDivCd				= billPrtSt.CustTelNoPrtDivCd;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			// 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//請求書印刷一時中断枚数 
			billPrtStWork.BillPrtSuspendCnt				= billPrtSt.BillPrtSuspendCnt;
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
               --- DEL 2008/06/13 --------------------------------<<<<< */

            # region 2007.06.27  S.Koga DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// 集金予定表出力区分
            //billPrtStWork.ClctMnyPlnDocOutCd            = billPrtSt.ClctMnyPlnDocOutCd;
            //// 集金予定表集金予定額（諸費用）
            //billPrtStWork.ClctMnyPlnDocVarCst           = billPrtSt.ClctMnyPlnDocVarCst;
            //// 集金予定表出力タイプ
            //billPrtStWork.ClctMnyPlnDocOutType          = billPrtSt.ClctMnyPlnDocOutType;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

            return billPrtStWork;
		}
	}
}
