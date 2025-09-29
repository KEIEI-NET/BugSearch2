using System;
using System.Collections;
using System.Collections.Generic;
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
    /// 価格改正設定マスタ アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 価格改正設定マスタ アクセス制御を行います。</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.09.19</br>
    /// <br></br>
    /// <br>Update Note: BLコード更新区分の追加(MANTIS[0014774])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/12/11</br>    
	/// </remarks>
	public class PriceChgSetAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
        private IPriceChgProcStDB _IPriceChgProcStDB = null;

		/// <summary>
		/// 価格改正設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 価格改正設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public PriceChgSetAcs()
		{
			try
			{
				// リモートオブジェクト取得
                this._IPriceChgProcStDB = (IPriceChgProcStDB)MediationPriceChgProcSt.GetPriceChgProcStDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._IPriceChgProcStDB = null;
			}
            
            //ローカルアクセスオブジェクト取得
            //_taxRateSetLcDB = new TaxRateSetLcDB();
		}

        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>検索アクセスタイプ</summary>
        public enum SearchMode
        {
            /// <summary>リモート</summary>
            Remote = 0,
            /// <summary>ローカル</summary>
            Local = 1
        }

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._IPriceChgProcStDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

        /// <summary>
        /// 価格改正設定読み込み処理
        /// </summary>
        /// <param name="priceChkSet">価格改正設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>価格改正設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 価格改正設定を読み込みます。（リモート）</br>
        /// <br>Programmer : 19026 湯山　美樹</br>
        /// <br>Date       : 2007.05.19</br>
        /// </remarks>
        public int Read(out PriceChgSet priceChkSet, string enterpriseCode)
        {
            return Read(out priceChkSet, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
		/// 価格改正設定読み込み処理
		/// </summary>
        /// <param name="priceChkSet">価格改正設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード(リモート or ローカル)</param>
		/// <returns>価格改正設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定を読み込みます。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
        /// <br>Update Note: 2007.05.19 19026 湯山　美樹</br>
        /// <br>           : ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
		public int Read(out PriceChgSet priceChkSet, string enterpriseCode, SearchMode searchMode)
		{
			try
			{
				priceChkSet = null;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

				PriceChgProcStWork priceChgWork = new PriceChgProcStWork();
				priceChgWork.EnterpriseCode = enterpriseCode;

                if (searchMode == SearchMode.Remote)
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(priceChgWork);
                    status = this._IPriceChgProcStDB.Read(ref parabyte, 0);

                    if (status == 0)
                        // XMLの読み込み
                        priceChgWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));
                    else // 価格改正設定取得失敗時
                        priceChgWork = new PriceChgProcStWork();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // 実装されていません。                    
                }

				//if (status == 0)
				// クラス内メンバコピー
				priceChkSet = CopyToPriceChgProcStWorkFromPriceChgSet(priceChgWork);

				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				priceChkSet = null;
				//オフライン時はnullをセット
				this._IPriceChgProcStDB = null;

				return -1;
			}
		}

		/// <summary>
		/// 価格改正設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>価格改正設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public PriceChgSet Deserialize(string fileName)
		{
			PriceChgSet taxrateset = null;
			// ファイル名を渡してプリンタ管理ワーククラスをデシリアライズする
			taxrateset = (PriceChgSet)XmlByteSerializer.Deserialize(fileName,typeof(PriceChgSet));

			// ファイル名を渡して価格改正設定ワーククラスをデシリアライズする
			PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(fileName,typeof(PriceChgProcStWork));

			//デシリアライズ結果を価格改正設定クラスへコピー
			if (PriceChgProcStWork != null) taxrateset = CopyToPriceChgProcStWorkFromPriceChgSet(PriceChgProcStWork);

			return taxrateset;
		}

		/// <summary>
		/// 価格改正設定Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>価格改正設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// ファイル名を渡して価格改正設定ワーククラスをデシリアライズする
			PriceChgProcStWork[] TaxRateSetWorks = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(fileName,typeof(PriceChgProcStWork[]));

			//デシリアライズ結果を価格改正設定クラスへコピー
			if (TaxRateSetWorks != null) 
			{
				al.Capacity = TaxRateSetWorks.Length;
				for(int i=0; i < TaxRateSetWorks.Length; i++)
				{
					al.Add(CopyToPriceChgProcStWorkFromPriceChgSet(TaxRateSetWorks[i]));
				}
			}
			return al;

		}

		/// <summary>
		/// 価格改正設定登録・更新処理
		/// </summary>
        /// <param name="priceChgSet">価格改正設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の登録・更新を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Write(ref PriceChgSet priceChgSet)
		{

			// 記録簿管理クラスから記録簿管理ワーカークラスにメンバコピー
			PriceChgProcStWork taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			
			int status = 0;
			try
			{
				// 記録簿管理書き込み
				status = this._IPriceChgProcStDB.Write(ref parabyte);
				if ( status == 0 )
				{
					// ファイル名を渡して記録簿管理ワーククラスをデシリアライズする
					taxratesetWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork) );
					// クラス内メンバコピー
					priceChgSet = CopyToPriceChgProcStWorkFromPriceChgSet(taxratesetWork);
				}
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._IPriceChgProcStDB = null;
				
				// 通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 価格改正設定シリアライズ処理
		/// </summary>
        /// <param name="priceChgSet">シリアライズ対象価格改正設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 価格改正設定のシリアライズを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void Serialize(PriceChgSet priceChgSet, string fileName)
		{
			//価格改正設定クラスから価格改正設定ワーカークラスにメンバコピー
			PriceChgProcStWork PriceChgProcStWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);
			//税率ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(PriceChgProcStWork,fileName);

		}

		/// <summary>
		/// 価格改正設定Listシリアライズ処理
		/// </summary>
        /// <param name="priceChgSetList">シリアライズ対象価格改正設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 価格改正設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void ListSerialize(ArrayList priceChgSetList,string fileName)
		{
			PriceChgProcStWork[] TaxRateSetWorks = new PriceChgProcStWork[priceChgSetList.Count];
			for(int i= 0; i < priceChgSetList.Count; i++)
			{
				TaxRateSetWorks[i] = CopyToPriceChgSetFromPriceChgProcStWork((PriceChgSet)priceChgSetList[i]);
			}
			//価格改正設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(TaxRateSetWorks,fileName);

		}

		/// <summary>
		/// 価格改正設定論理削除処理
		/// </summary>
        /// <param name="priceChgSet">価格改正設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の論理削除を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int LogicalDelete(ref PriceChgSet priceChgSet)
		{
			try
			{
				PriceChgProcStWork taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// 論理削除
				int status = this._IPriceChgProcStDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して記録簿管理ワーククラスをデシリアライズする
					taxratesetWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize( parabyte, typeof(PriceChgProcStWork));
					// クラス内メンバコピー
					priceChgSet = CopyToPriceChgProcStWorkFromPriceChgSet(taxratesetWork);
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._IPriceChgProcStDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 価格改正設定物理削除処理
		/// </summary>
        /// <param name="priceChgSet">価格改正設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の物理削除を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Delete(PriceChgSet priceChgSet)
		{
			try
			{
				PriceChgProcStWork taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// 記録簿管理物理削除
				int status = this._IPriceChgProcStDB.Delete(parabyte);

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._IPriceChgProcStDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 価格改正設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, 0);
		}

		/// <summary>
		/// 価格改正設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 価格改正設定数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定数の検索を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			PriceChgProcStWork taxratesetWork = new PriceChgProcStWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			// 記録簿管理検索
			int status = this._IPriceChgProcStDB.SearchCnt(out retTotalCnt, parabyte, 0, logicalMode);

			if ( status != 0 )
			{
				retTotalCnt = 0;
			}
	
			return status;
		}

		/// <summary>
		/// 価格改正設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;

			//----- ueno upd ---------- start 2008.01.31
			// 引数なしの場合リモート設定
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 価格改正設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 価格改正設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;

			//----- ueno upd ---------- start 2008.01.31
			// 引数なしの場合リモート設定
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 価格改正設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int retTotalCnt;

			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 件数指定価格改正設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終価格改正設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して価格改正設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PriceChgSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// 引数なしの場合リモート設定
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 件数指定価格改正設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終価格改正設定データオブジェクト（初回はnull指定必須）</param>			
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して価格改正設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, PriceChgSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 件数指定価格改正設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevTaxratesetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終価格改正設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して価格改正設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PriceChgSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// 引数なしの場合リモート設定
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}
		
		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 件数指定価格改正設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevTaxratesetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終価格改正設定データオブジェクト（初回はnull指定必須）</param>			
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して価格改正設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, PriceChgSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 価格改正設定論理削除復活処理
		/// </summary>
		/// <param name="taxrateset">価格改正設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の復活を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Revival(ref PriceChgSet taxrateset)
		{
			try
			{
				PriceChgProcStWork PriceChgProcStWork = CopyToPriceChgSetFromPriceChgProcStWork(taxrateset);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);
				// 復活処理
				int status = this._IPriceChgProcStDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));
					// クラス内メンバコピー
					taxrateset = CopyToPriceChgProcStWorkFromPriceChgSet(PriceChgProcStWork);
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._IPriceChgProcStDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}


		/// <summary>
		/// 価格改正設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevTaxrateset">前回最終価格改正設定データオブジェクト（初回はnull指定必須）</param>
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の検索処理を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31　30167　上野　弘貴</br>
		/// <br>             ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PriceChgSet prevTaxrateset, SearchMode searchMode)
		{
			PriceChgProcStWork taxratesetWork = new PriceChgProcStWork();

			if ( prevTaxrateset != null )
			{
				taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(prevTaxrateset);
			}
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// 次データ有無初期化
			nextData = false;
			// 0で初期化
			retTotalCnt = 0;

			PriceChgProcStWork[] al;
			retList = new ArrayList();
			retList.Clear();

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
			byte[] retbyte = null;

			// 記録簿管理検索
			int status = 1;
			if (readCnt == 0)
			{				
				if (searchMode == SearchMode.Remote)
				{
					status = this._IPriceChgProcStDB.Search( out retbyte, parabyte, 0, logicalMode);
				}
				else
				{
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // 実装されていません。
				}				
			}
			else
			{
				status = this._IPriceChgProcStDB.SearchSpecification( out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt );
			}

			if (status == 0)
			{
				// XMLの読み込み
				al = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(retbyte, typeof(PriceChgProcStWork[]));

				for ( int i = 0; i < al.Length; i++ )
				{
					// サーチ結果取得
					PriceChgProcStWork wkTaxRateSetWork = (PriceChgProcStWork)al[i];
					// 記録簿管理クラスへメンバコピー
					retList.Add( CopyToPriceChgProcStWorkFromPriceChgSet(wkTaxRateSetWork));
				}
			}
			// 全件リードの場合は戻り値の件数をセット
			if ( readCnt == 0 )
			{
				retTotalCnt = retList.Count;
			}
			
			return status;
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 価格改正設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds,string enterpriseCode)
		{
		   return SearchDS(ref ds, enterpriseCode, SearchMode.Remote);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 価格改正設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31　30167　上野　弘貴</br>
		/// <br>             ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds, string enterpriseCode, SearchMode searchMode)
		{
			PriceChgProcStWork taxratesetWork = new PriceChgProcStWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
			byte[] retbyte = null;

			//----- ueno upd ---------- start 2008.01.31
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			if (searchMode == SearchMode.Remote)
			{
				// 記録簿管理サーチ
				status = this._IPriceChgProcStDB.Search(out retbyte, parabyte, 0, 0);
			}
			else
			{
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // 実装されていません。				
			}
			//----- ueno upd ---------- end 2008.01.31

			if ( status == 0 )
			{
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
				
			return status;
		}

		/// <summary>
		/// クラスメンバーコピー処理（価格改正設定ワーククラス⇒価格改正設定クラス）
		/// </summary>
		/// <param name="PriceChgProcStWork">価格改正設定ワーククラス</param>
		/// <returns>価格改正設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定ワーククラスから価格改正設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private PriceChgSet CopyToPriceChgProcStWorkFromPriceChgSet(PriceChgProcStWork PriceChgProcStWork)
		{
			PriceChgSet priceChgSet = new PriceChgSet();

			//ファイルヘッダ部分
			priceChgSet.CreateDateTime			= PriceChgProcStWork.CreateDateTime;
			priceChgSet.UpdateDateTime			= PriceChgProcStWork.UpdateDateTime;
			priceChgSet.EnterpriseCode			= PriceChgProcStWork.EnterpriseCode;
			priceChgSet.FileHeaderGuid			= PriceChgProcStWork.FileHeaderGuid;
			priceChgSet.UpdEmployeeCode		    = PriceChgProcStWork.UpdEmployeeCode;
			priceChgSet.UpdAssemblyId1			= PriceChgProcStWork.UpdAssemblyId1;
			priceChgSet.UpdAssemblyId2			= PriceChgProcStWork.UpdAssemblyId2;
			priceChgSet.LogicalDeleteCode		= PriceChgProcStWork.LogicalDeleteCode;

            priceChgSet.NameUpdDiv               = PriceChgProcStWork.NameUpdDiv; // 名称更新区分
            priceChgSet.PartsLayerUpdDiv         = PriceChgProcStWork.PartsLayerUpdDiv; // 層別更新区分
            priceChgSet.PriceUpdDiv              = PriceChgProcStWork.PriceUpdDiv; // 価格更新区分
            priceChgSet.OpenPriceDiv             = PriceChgProcStWork.OpenPriceDiv; // オープン価格区分
            priceChgSet.PriceMngCnt              = PriceChgProcStWork.PriceMngCnt; // 価格管理件数
            priceChgSet.PriceChgProcDiv          = PriceChgProcStWork.PriceChgProcDiv; // 価格改正処理区分
            // 2009/12/11 Add >>>
            priceChgSet.BLGoodsCdUpdDiv = PriceChgProcStWork.BLGoodsCdUpdDiv;   // BLコード更新区分
            // 2009/12/11 Add <<<
			return priceChgSet;
		}

		/// <summary>
		/// クラスメンバーコピー処理（価格改正設定クラス⇒価格改正設定ワーククラス）
		/// </summary>
        /// <param name="priceChgSet">価格改正設定ワーククラス</param>
		/// <returns>価格改正設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定クラスから価格改正設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private PriceChgProcStWork CopyToPriceChgSetFromPriceChgProcStWork(PriceChgSet priceChgSet)
		{

 			PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();

			PriceChgProcStWork.CreateDateTime			= priceChgSet.CreateDateTime;
			PriceChgProcStWork.UpdateDateTime			= priceChgSet.UpdateDateTime;
			PriceChgProcStWork.EnterpriseCode			= priceChgSet.EnterpriseCode;
			PriceChgProcStWork.FileHeaderGuid			= priceChgSet.FileHeaderGuid;
			PriceChgProcStWork.UpdEmployeeCode		    = priceChgSet.UpdEmployeeCode;
			PriceChgProcStWork.UpdAssemblyId1			= priceChgSet.UpdAssemblyId1;
			PriceChgProcStWork.UpdAssemblyId2			= priceChgSet.UpdAssemblyId2;
			PriceChgProcStWork.LogicalDeleteCode		= priceChgSet.LogicalDeleteCode;

            PriceChgProcStWork.NameUpdDiv               = priceChgSet.NameUpdDiv; // 名称更新区分
            PriceChgProcStWork.PartsLayerUpdDiv         = priceChgSet.PartsLayerUpdDiv; // 層別更新区分
            PriceChgProcStWork.PriceUpdDiv              = priceChgSet.PriceUpdDiv; // 価格更新区分
            PriceChgProcStWork.OpenPriceDiv             = priceChgSet.OpenPriceDiv; // オープン価格区分
            PriceChgProcStWork.PriceMngCnt              = priceChgSet.PriceMngCnt; // 価格管理件数
            PriceChgProcStWork.PriceChgProcDiv          = priceChgSet.PriceChgProcDiv; // 価格改正処理区分
            // 2009/12/11 Add >>>
            PriceChgProcStWork.BLGoodsCdUpdDiv= priceChgSet.BLGoodsCdUpdDiv; // BLコード更新区分
            // 2009/12/11 Add <<<

			return PriceChgProcStWork;
		}

    }
}
