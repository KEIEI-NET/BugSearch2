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
	/// 入金設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 23013 牧　将人</br>
	/// <br>Date       : 2005.08.04</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.21  23006 高橋 明子</br>
	/// <br>				    ・金種コード参照対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 高橋 明子</br>
	/// <br>				・親マスタ反映同期対応</br>
	/// </remarks>
	public class DepositStAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IDepositStDB _iDepositStDB = null;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
		// 金額種別登録修正マスタ名称取得用
		private Hashtable _getDepositKindBuff;
		private MoneyKind _moneyKind;
		private MoneyKindAcs _moneyKindAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

		/// <summary>
		/// 入金設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public DepositStAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iDepositStDB = (IDepositStDB)MediationDepositStDB.GetDepositStDB();
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iDepositStDB = null;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
			// 金額種別登録修正マスタ名称取得用
			this._getDepositKindBuff = new Hashtable();
			this._moneyKind = new MoneyKind();
			this._moneyKindAcs = new MoneyKindAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END
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
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iDepositStDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// KEY指定入金設定読み込み処理
		/// </summary>
		/// <param name="depositSt">入金設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="depositStMngCd">入金設定管理No</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 入金設定情報を読み込みます。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public int Read(out DepositSt depositSt, string enterpriseCode, int depositStMngCd)
		{
			try
			{
				depositSt = null;
				DepositStWork depositStWork = new DepositStWork();
				depositStWork.EnterpriseCode = enterpriseCode;
				depositStWork.DepositStMngCd = depositStMngCd;

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(depositStWork);

				// 入金設定読み込み
				int status = this._iDepositStDB.Read(ref parabyte, 0);

				if (status == 0)
				{
					// XMLの読み込み
					depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte, typeof(DepositStWork));
					// クラス内メンバコピー
					depositSt = CopyToDepositStFromDepositStWork(depositStWork);
				}
				return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				depositSt = null;
				//オフライン時はnullをセット
				this._iDepositStDB = null;

				return -1;
			}
		}
		/// <summary>
		/// 入金設定登録・更新処理
		/// </summary>
		/// <param name="depositSt">入金設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金設定情報の登録・更新を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public int Write(ref DepositSt depositSt)
		{
			// 入金設定クラスから入金設定ワーカークラスにメンバコピー
			DepositStWork depositStWork = CopyToDepositStWorkFromDepositSt(depositSt);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(depositStWork);

			int status = 0;
			try
			{
				// 入金設定ワーク書き込み
				status = this._iDepositStDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡して入金設定ワーククラスをデシリアライズする
					depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte, typeof(DepositStWork));
					// クラス内メンバコピー
					depositSt = CopyToDepositStFromDepositStWork(depositStWork);
				}
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iDepositStDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}
		/// <summary>
		/// クラスメンバーコピー処理（入金設定ワーククラス⇒入金設定クラス）
		/// </summary>
		/// <param name="depositStWork">入金設定ワーククラス</param>
		/// <returns>入金設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 入金設定ワーククラスから入金設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		private DepositSt CopyToDepositStFromDepositStWork(DepositStWork depositStWork)
		{
			DepositSt depositSt = new DepositSt();

			depositSt.CreateDateTime		= depositStWork.CreateDateTime;
			depositSt.UpdateDateTime		= depositStWork.UpdateDateTime;
			depositSt.EnterpriseCode		= depositStWork.EnterpriseCode;
			depositSt.FileHeaderGuid		= depositStWork.FileHeaderGuid;
			depositSt.UpdEmployeeCode		= depositStWork.UpdEmployeeCode;
			depositSt.UpdAssemblyId1		= depositStWork.UpdAssemblyId1;
			depositSt.UpdAssemblyId2		= depositStWork.UpdAssemblyId2;
			depositSt.LogicalDeleteCode		= depositStWork.LogicalDeleteCode;

			depositSt.DepositStMngCd		= depositStWork.DepositStMngCd;
			depositSt.DepositInitDspNo		= depositStWork.DepositInitDspNo;
			//depositSt.InitSelMoneyKindCd	= depositStWork.InitSelMoneyKindCd;
			depositSt.DepositStKindCd1		= depositStWork.DepositStKindCd1;
			depositSt.DepositStKindCd2		= depositStWork.DepositStKindCd2;
			depositSt.DepositStKindCd3		= depositStWork.DepositStKindCd3;
			depositSt.DepositStKindCd4		= depositStWork.DepositStKindCd4;
			depositSt.DepositStKindCd5		= depositStWork.DepositStKindCd5;
			depositSt.DepositStKindCd6		= depositStWork.DepositStKindCd6;
			depositSt.DepositStKindCd7		= depositStWork.DepositStKindCd7;
			depositSt.DepositStKindCd8		= depositStWork.DepositStKindCd8;
			depositSt.DepositStKindCd9		= depositStWork.DepositStKindCd9;
			depositSt.DepositStKindCd10		= depositStWork.DepositStKindCd10;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //depositSt.DepositCallMonths		= depositStWork.DepositCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			depositSt.AlwcDepoCallMonthsCd	= depositStWork.AlwcDepoCallMonthsCd;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
			//金額種別登録修正マスタより取得した名称を使用
			depositSt.DepositStKindCdNm1   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd1);
			depositSt.DepositStKindCdNm2   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd2);
			depositSt.DepositStKindCdNm3   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd3);
			depositSt.DepositStKindCdNm4   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd4);
			depositSt.DepositStKindCdNm5   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd5);
			depositSt.DepositStKindCdNm6   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd6);
			depositSt.DepositStKindCdNm7   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd7);
			depositSt.DepositStKindCdNm8   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd8);
			depositSt.DepositStKindCdNm9   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd9);
			depositSt.DepositStKindCdNm10  = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd10);
			//depositSt.InitSelMoneyKindCdNm = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.InitSelMoneyKindCd);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

			return depositSt;
		}

		/// <summary>
		/// クラスメンバーコピー処理（入金設定クラス⇒入金設定ワーククラス）
		/// </summary>
		/// <param name="depositSt">入金設定ワーククラス</param>
		/// <returns>入金設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 入金設定クラスから入金設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		private DepositStWork CopyToDepositStWorkFromDepositSt(DepositSt depositSt)
		{
			DepositStWork depositStWork = new DepositStWork();

			depositStWork.CreateDateTime		= depositSt.CreateDateTime;
			depositStWork.UpdateDateTime		= depositSt.UpdateDateTime;
			depositStWork.EnterpriseCode		= depositSt.EnterpriseCode;
			depositStWork.FileHeaderGuid		= depositSt.FileHeaderGuid;
			depositStWork.UpdEmployeeCode		= depositSt.UpdEmployeeCode;
			depositStWork.UpdAssemblyId1		= depositSt.UpdAssemblyId1;
			depositStWork.UpdAssemblyId2		= depositSt.UpdAssemblyId2;
			depositStWork.LogicalDeleteCode		= depositSt.LogicalDeleteCode;

			depositStWork.DepositStMngCd		= depositSt.DepositStMngCd;
			depositStWork.DepositInitDspNo		= depositSt.DepositInitDspNo;	
			//depositStWork.InitSelMoneyKindCd	= depositSt.InitSelMoneyKindCd;
			depositStWork.DepositStKindCd1		= depositSt.DepositStKindCd1;
			depositStWork.DepositStKindCd2		= depositSt.DepositStKindCd2;
			depositStWork.DepositStKindCd3		= depositSt.DepositStKindCd3;
			depositStWork.DepositStKindCd4		= depositSt.DepositStKindCd4;
			depositStWork.DepositStKindCd5		= depositSt.DepositStKindCd5;
			depositStWork.DepositStKindCd6		= depositSt.DepositStKindCd6;
			depositStWork.DepositStKindCd7		= depositSt.DepositStKindCd7;
			depositStWork.DepositStKindCd8		= depositSt.DepositStKindCd8;
			depositStWork.DepositStKindCd9		= depositSt.DepositStKindCd9;
			depositStWork.DepositStKindCd10		= depositSt.DepositStKindCd10;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //depositStWork.DepositCallMonths		= depositSt.DepositCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			depositStWork.AlwcDepoCallMonthsCd	= depositSt.AlwcDepoCallMonthsCd;

			return depositStWork;
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 金種名称取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="depositStKindCd">金種コード</param>   
		/// <remarks>
		/// <br>Note       : 金種名称を取得します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.09.21</br>
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
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

	}
}
