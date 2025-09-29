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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 支払設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 21027 須川  程志郎</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.22  23006 高橋 明子</br>
	/// <br>				    ・金種コード参照対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 高橋 明子</br>
	/// <br>				・親マスタ反映同期対応</br>
    /// <br>Update Note : 2006.06.09  22029 平山 恵美</br>
    /// <br>				・新レイアウト対応</br>
    /// <br>Update Note : 2008.06.18  徳永 俊詞</br>
    /// <br>	　      ・項目「支払伝票呼出月数」削除</br>
    /// 
    /// </remarks>
	public class PaymentSetAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IPaymentSetDB _iPaymentSetDB = null;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
		// 金額種別登録修正マスタ名称取得用
		private Hashtable _getDepositKindBuff;
		private MoneyKind _moneyKind;
		private MoneyKindAcs _moneyKindAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END

		/// <summary>
		/// 支払設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public PaymentSetAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iPaymentSetDB = (IPaymentSetDB)MediationPaymentSetDB.GetPaymentSetDB();
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iPaymentSetDB = null;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
			// 金額種別登録修正マスタ名称取得用
			this._getDepositKindBuff = new Hashtable();
			this._moneyKind = new MoneyKind();
			this._moneyKindAcs = new MoneyKindAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END
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
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iPaymentSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// KEY指定支払設定読み込み処理
		/// </summary>
		/// <param name="paymentSet">支払設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="payStMngNo">支払設定管理No</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 支払設定情報を読み込みます。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int Read(out PaymentSet paymentSet, string enterpriseCode, int payStMngNo)
		{
			try
			{
				paymentSet = null;
				PaymentSetWork paymentSetWork = new PaymentSetWork();
				paymentSetWork.EnterpriseCode = enterpriseCode;
				paymentSetWork.PayStMngNo = payStMngNo;

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(paymentSetWork);

				// 支払設定読み込み
				int status = this._iPaymentSetDB.Read(ref parabyte, 0);

				if (status == 0)
				{
					// XMLの読み込み
					paymentSetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSetWork));
					// クラス内メンバコピー
					paymentSet = CopyToPaymentSetFromPaymentSetWork(paymentSetWork);
				}
				return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				paymentSet = null;
				//オフライン時はnullをセット
				this._iPaymentSetDB = null;

				return -1;
			}
		}

		/// <summary>
		/// 支払設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>支払設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 支払設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public PaymentSet Deserialize(string fileName)
		{
			PaymentSet paymentSet = null;
			// ファイル名を渡して支払設定ワーククラスをデシリアライズする
			PaymentSetWork paymentSetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(fileName, typeof(PaymentSetWork));

			//デシリアライズ結果を支払設定クラスへコピー
			if (paymentSetWork != null)
			{
				paymentSet = CopyToPaymentSetFromPaymentSetWork(paymentSetWork);
			}

			return paymentSet;
		}

		/// <summary>
		/// 支払設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>支払設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 支払設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// ファイル名を渡して支払設定ワーククラスをデシリアライズする
			PaymentSetWork[] paymentSetWorks = (PaymentSetWork[])XmlByteSerializer.Deserialize(fileName, typeof(PaymentSetWork[]));

			// デシリアライズ結果を支払設定クラスへコピー
			if (paymentSetWorks != null)
			{
				al.Capacity = paymentSetWorks.Length;
				for( int i = 0; i < paymentSetWorks.Length; i++ )
				{
					al.Add(CopyToPaymentSetFromPaymentSetWork(paymentSetWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// 支払設定登録・更新処理
		/// </summary>
		/// <param name="paymentSet">支払設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 支払設定情報の登録・更新を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int Write(ref PaymentSet paymentSet)
		{
			// 支払設定クラスから支払設定ワーカークラスにメンバコピー
			PaymentSetWork paymentSetWork = CopyToPaymentSetWorkFromPaymentSet(paymentSet);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(paymentSetWork);

			int status = 0;
			try
			{
				// 支払設定ワーク書き込み
				status = this._iPaymentSetDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡して支払設定ワーククラスをデシリアライズする
					paymentSetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSetWork));
					// クラス内メンバコピー
					paymentSet = CopyToPaymentSetFromPaymentSetWork(paymentSetWork);
				}
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iPaymentSetDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 支払設定シリアライズ処理
		/// </summary>
		/// <param name="paymentSet">シリアライズ対象支払設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 支払設定情報のシリアライズを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public void Serialize(PaymentSet paymentSet, string fileName)
		{
			// 支払設定クラスから支払設定ワーカークラスにメンバコピー
			PaymentSetWork paymentSetWork = CopyToPaymentSetWorkFromPaymentSet(paymentSet);
			// 支払設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(paymentSetWork, fileName);
		}

		/// <summary>
		/// 支払設定Listシリアライズ処理
		/// </summary>
		/// <param name="paymentSetList">シリアライズ対象支払設定クラスList</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 支払設定クラスListのシリアライズを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public void ListSerialize(ArrayList paymentSetList, string fileName)
		{
			PaymentSetWork[] paymentSetWorks = new PaymentSetWork[paymentSetList.Count];
			for(int i= 0; i < paymentSetList.Count; i++)
			{
				paymentSetWorks[i] = CopyToPaymentSetWorkFromPaymentSet((PaymentSet)paymentSetList[i]);
			}
			// 支払設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(paymentSetWorks, fileName);
		}

		/// <summary>
		/// クラスメンバーコピー処理（支払設定ワーククラス⇒支払設定クラス）
		/// </summary>
		/// <param name="paymentSetWork">支払設定ワーククラス</param>
		/// <returns>支払設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 支払設定ワーククラスから支払設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private PaymentSet CopyToPaymentSetFromPaymentSetWork(PaymentSetWork paymentSetWork)
		{
			PaymentSet paymentSet = new PaymentSet();

			paymentSet.CreateDateTime	 = paymentSetWork.CreateDateTime;
			paymentSet.UpdateDateTime	 = paymentSetWork.UpdateDateTime;
			paymentSet.EnterpriseCode	 = paymentSetWork.EnterpriseCode;
			paymentSet.FileHeaderGuid	 = paymentSetWork.FileHeaderGuid;
			paymentSet.UpdEmployeeCode	 = paymentSetWork.UpdEmployeeCode;
			paymentSet.UpdAssemblyId1	 = paymentSetWork.UpdAssemblyId1;
			paymentSet.UpdAssemblyId2	 = paymentSetWork.UpdAssemblyId2;
			paymentSet.LogicalDeleteCode = paymentSetWork.LogicalDeleteCode;

			paymentSet.PayStMngNo		   = paymentSetWork.PayStMngNo;
	　　　　//2006.06.09  EMI Del		paymentSet.PayInitDspScrNumber = paymentSetWork.PayInitDspScrNumber;
            //2006.06.09  EMI Del		paymentSet.PayInitSystemDiv	   = paymentSetWork.PayInitSystemDiv;
            //2006.06.09  EMI Del		paymentSet.DspOrderOfPaySt	   = paymentSetWork.DspOrderOfPaySt;
            //2006.06.09  EMI Del		paymentSet.LumpSumMoneyKindCd  = paymentSetWork.LumpSumMoneyKindCd;
			paymentSet.PayStMoneyKindCd1   = paymentSetWork.PayStMoneyKindCd1;
			paymentSet.PayStMoneyKindCd2   = paymentSetWork.PayStMoneyKindCd2;
			paymentSet.PayStMoneyKindCd3   = paymentSetWork.PayStMoneyKindCd3;
			paymentSet.PayStMoneyKindCd4   = paymentSetWork.PayStMoneyKindCd4;
			paymentSet.PayStMoneyKindCd5   = paymentSetWork.PayStMoneyKindCd5;
			paymentSet.PayStMoneyKindCd6   = paymentSetWork.PayStMoneyKindCd6;
			paymentSet.PayStMoneyKindCd7   = paymentSetWork.PayStMoneyKindCd7;
			paymentSet.PayStMoneyKindCd8   = paymentSetWork.PayStMoneyKindCd8;
			paymentSet.PayStMoneyKindCd9   = paymentSetWork.PayStMoneyKindCd9;
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            paymentSet.PayStMoneyKindCd10 = paymentSetWork.PayStMoneyKindCd10;
            //paymentSet.InitSelMoneyKindCd = paymentSetWork.InitSelMoneyKindCd;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //paymentSet.PaySlipCallMonths = paymentSetWork.PaySlipCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
			paymentSet.PayStMoneyKindNm1 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd1);
			paymentSet.PayStMoneyKindNm2 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd2);
			paymentSet.PayStMoneyKindNm3 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd3);
			paymentSet.PayStMoneyKindNm4 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd4);
			paymentSet.PayStMoneyKindNm5 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd5);
			paymentSet.PayStMoneyKindNm6 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd6);
			paymentSet.PayStMoneyKindNm7 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd7);
			paymentSet.PayStMoneyKindNm8 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd8);
			paymentSet.PayStMoneyKindNm9 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd9);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            paymentSet.PayStMoneyKindNm10 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd10);
            //paymentSet.InitSelMoneyKindNm = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.InitSelMoneyKindCd); 
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return paymentSet; 
		}

		/// <summary>
		/// クラスメンバーコピー処理（支払設定クラス⇒支払設定ワーククラス）
		/// </summary>
		/// <param name="paymentSet">支払設定ワーククラス</param>
		/// <returns>支払設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 支払設定クラスから支払設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private PaymentSetWork CopyToPaymentSetWorkFromPaymentSet(PaymentSet paymentSet)
		{
			PaymentSetWork paymentSetWork = new PaymentSetWork();

			paymentSetWork.CreateDateTime		= paymentSet.CreateDateTime;
			paymentSetWork.UpdateDateTime		= paymentSet.UpdateDateTime;
			paymentSetWork.EnterpriseCode		= paymentSet.EnterpriseCode;
			paymentSetWork.FileHeaderGuid		= paymentSet.FileHeaderGuid;
			paymentSetWork.UpdEmployeeCode		= paymentSet.UpdEmployeeCode;
			paymentSetWork.UpdAssemblyId1		= paymentSet.UpdAssemblyId1;
			paymentSetWork.UpdAssemblyId2		= paymentSet.UpdAssemblyId2;
			paymentSetWork.LogicalDeleteCode	= paymentSet.LogicalDeleteCode;

			paymentSetWork.PayStMngNo			= paymentSet.PayStMngNo;
            //2006.06.09  EMI Del		paymentSetWork.PayInitDspScrNumber	= paymentSet.PayInitDspScrNumber;
            //2006.06.09  EMI Del		paymentSetWork.PayInitSystemDiv		= paymentSet.PayInitSystemDiv;
            //2006.06.09  EMI Del		paymentSetWork.DspOrderOfPaySt		= paymentSet.DspOrderOfPaySt;
            //2006.06.09  EMI Del		paymentSetWork.LumpSumMoneyKindCd	= paymentSet.LumpSumMoneyKindCd;
			paymentSetWork.PayStMoneyKindCd1	= paymentSet.PayStMoneyKindCd1;
			paymentSetWork.PayStMoneyKindCd2	= paymentSet.PayStMoneyKindCd2;
			paymentSetWork.PayStMoneyKindCd3	= paymentSet.PayStMoneyKindCd3;
			paymentSetWork.PayStMoneyKindCd4	= paymentSet.PayStMoneyKindCd4;
			paymentSetWork.PayStMoneyKindCd5	= paymentSet.PayStMoneyKindCd5;
			paymentSetWork.PayStMoneyKindCd6	= paymentSet.PayStMoneyKindCd6;
			paymentSetWork.PayStMoneyKindCd7	= paymentSet.PayStMoneyKindCd7;
			paymentSetWork.PayStMoneyKindCd8	= paymentSet.PayStMoneyKindCd8;
			paymentSetWork.PayStMoneyKindCd9	= paymentSet.PayStMoneyKindCd9;
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            paymentSetWork.PayStMoneyKindCd10   = paymentSet.PayStMoneyKindCd10;
            //paymentSetWork.InitSelMoneyKindCd = paymentSet.InitSelMoneyKindCd;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //paymentSetWork.PaySlipCallMonths = paymentSet.PaySlipCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return paymentSetWork;
		} 

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 金種名称取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="depositStKindCd">金種コード</param>   
		/// <remarks>
		/// <br>Note        : 金種名称を取得します。</br>
		/// <br>Programmer  : 23006  高橋 明子</br>
		/// <br>Date        : 2005.09.22</br>
		/// <br></br>
		/// <br>Update Note : 金種名称を取得します。</br>
		/// <br>Programmer  : 23006  高橋 明子</br>
		/// <br>Date        : 2005.12.20</br>
		/// </remarks>
		public string GetDepsitStKindNm(string enterpriseCode, int depositStKindCd)
		{		
			int status = 0;
			int moneyKindMode = 1;

			ArrayList allMoneyKindList = new ArrayList();
			Hashtable moneyKindTable = new Hashtable();

			// 金額種別マスタより、論理削除分も含むデータを取得
			status = this._moneyKindAcs.GetBuff(out allMoneyKindList, enterpriseCode, moneyKindMode);

			if (status == 0)
			{
				foreach (MoneyKind moneyKindInfo in allMoneyKindList)
				{
					// 金額設定区分が「0:入金」の場合、比較
					if ((moneyKindInfo.PriceStCode == 0) && (moneyKindInfo.MoneyKindCode == depositStKindCd))
					{
						if (moneyKindInfo.LogicalDeleteCode == 0)
						{
							return moneyKindInfo.MoneyKindName;
						}
						else
						{
							return "削除済";
						}
					}
				}

				return "未登録";
			}
			else
			{
				return "";
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END
	}
}
