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
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 税率設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 税率設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 21041 中村　健</br>
	/// <br>Date       : 2005.04.01</br>
	/// <br>Update Note: 2005.06.21 96138 佐藤  健治</br>
	/// <br>           : 文字列項目語尾のスペースカット。</br>
    /// <br>Update Note: 2007.05.19 19026 湯山　美樹</br>
    /// <br>           : ローカルアクセス対応(Readのみ)</br>
    /// <br>Update Note: 2007.08.16 980035 金沢 貞義</br>
    /// <br>			 端数処理区分を削除して消費税転嫁方式を追加</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
    /// <br>Update Note: 2008.07.31 21024 佐々木　健</br>
    /// <br>			 税率取得用メソッド追加</br>
    /// <br>Update Note: 2008.12.01 21024 佐々木　健</br>
    /// <br>			 Searchのリモート修正対応</br>
    /// <br>Update Note: 2013/12/16 譚洪</br>
    /// <br>			 Redmine#41551の対応 消費税8%増税に伴って、発見された障害の対応</br>
    /// <br></br>
	/// </remarks>
	public class TaxRateSetAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ITaxRateSetDB _iTaxratesetDB = null;
        /// <summary>ローカルDBアクセスクラス</summary>
        private TaxRateSetLcDB _taxRateSetLcDB = null;

		/// <summary>
		/// 税率設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 税率設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public TaxRateSetAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iTaxratesetDB = (ITaxRateSetDB)MediationTaxRateSetDB.GetTaxRateSetDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iTaxratesetDB = null;
			}
            
            //ローカルアクセスオブジェクト取得
            _taxRateSetLcDB = new TaxRateSetLcDB();
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
			if (this._iTaxratesetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

        /// <summary>
        /// 税率設定読み込み処理
        /// </summary>
        /// <param name="taxrateset">税率設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="taxRateCode">税率コード</param>
        /// <returns>税率設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 税率設定を読み込みます。（リモート）</br>
        /// <br>Programmer : 19026 湯山　美樹</br>
        /// <br>Date       : 2007.05.19</br>
        /// </remarks>
        public int Read(out TaxRateSet taxrateset, string enterpriseCode, int taxRateCode)
        {
            return Read(out taxrateset, enterpriseCode, taxRateCode, SearchMode.Remote);
        }

        /// <summary>
		/// 税率設定読み込み処理
		/// </summary>
		/// <param name="taxrateset">税率設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="taxRateCode">税率コード</param>
        /// <param name="searchMode">検索モード(リモート or ローカル)</param>
		/// <returns>税率設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 税率設定を読み込みます。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
        /// <br>Update Note: 2007.05.19 19026 湯山　美樹</br>
        /// <br>           : ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
		public int Read(out TaxRateSet taxrateset, string enterpriseCode, int taxRateCode, SearchMode searchMode)
		{
			try
			{
				taxrateset = null;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

				TaxRateSetWork taxratesetWork = new TaxRateSetWork();
				taxratesetWork.EnterpriseCode = enterpriseCode;
				taxratesetWork.TaxRateCode = taxRateCode;

                if (searchMode == SearchMode.Remote)
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
                    status = this._iTaxratesetDB.Read(ref parabyte, 0);

                    if (status == 0)
                        // XMLの読み込み
                        taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork));
                }
                else
                {
                    status = this._taxRateSetLcDB.Read(ref taxratesetWork, 0);
                }

				if (status == 0)
					// クラス内メンバコピー
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(taxratesetWork);

				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				taxrateset = null;
				//オフライン時はnullをセット
				this._iTaxratesetDB = null;

				return -1;
			}
		}

		/// <summary>
		/// 税率設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>税率設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 税率設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public TaxRateSet Deserialize(string fileName)
		{
			TaxRateSet taxrateset = null;
			// ファイル名を渡してプリンタ管理ワーククラスをデシリアライズする
			taxrateset = (TaxRateSet)XmlByteSerializer.Deserialize(fileName,typeof(TaxRateSet));

			// ファイル名を渡して税率設定ワーククラスをデシリアライズする
			TaxRateSetWork TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(fileName,typeof(TaxRateSetWork));

			//デシリアライズ結果を税率設定クラスへコピー
			if (TaxRateSetWork != null) taxrateset = CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWork);

			return taxrateset;
		}

		/// <summary>
		/// 税率設定Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>税率設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 税率設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// ファイル名を渡して税率設定ワーククラスをデシリアライズする
			TaxRateSetWork[] TaxRateSetWorks = (TaxRateSetWork[])XmlByteSerializer.Deserialize(fileName,typeof(TaxRateSetWork[]));

			//デシリアライズ結果を税率設定クラスへコピー
			if (TaxRateSetWorks != null) 
			{
				al.Capacity = TaxRateSetWorks.Length;
				for(int i=0; i < TaxRateSetWorks.Length; i++)
				{
					al.Add(CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWorks[i]));
				}
			}
			return al;

		}

		/// <summary>
		/// 税率設定登録・更新処理
		/// </summary>
		/// <param name="taxrateset">税率設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の登録・更新を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Write(ref TaxRateSet taxrateset)
		{

			// 記録簿管理クラスから記録簿管理ワーカークラスにメンバコピー
			TaxRateSetWork taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			
			int status = 0;
			try
			{
				// 記録簿管理書き込み
				status = this._iTaxratesetDB.Write(ref parabyte);
				if ( status == 0 )
				{
					// ファイル名を渡して記録簿管理ワーククラスをデシリアライズする
					taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork) );
					// クラス内メンバコピー
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(taxratesetWork);
				}
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iTaxratesetDB = null;
				
				// 通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 税率設定List比較用クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : IComparable インターフェイスの実装。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public class TaxratesetKey : IComparer  
		{
			/// <summary>
			/// List比較メソッド
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <remarks>
			/// <br>Note       : xとyを比較し、小さいときはマイナス、</br>
			/// <br>           : 大きいときはプラス、同じときはゼロを返します。</br>
			/// <br>Programmer : 21041 中村　健</br>
			/// <br>Date       : 2005.04.01</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				TaxRateSet taxratesetX = (TaxRateSet)x;
				TaxRateSet taxratesetY = (TaxRateSet)y;
				return (taxratesetX.TaxRateCode - taxratesetY.TaxRateCode);
			}
		}

		/// <summary>
		/// 税率設定シリアライズ処理
		/// </summary>
		/// <param name="taxrateset">シリアライズ対象税率設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 税率設定のシリアライズを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void Serialize(TaxRateSet taxrateset, string fileName)
		{
			//税率設定クラスから税率設定ワーカークラスにメンバコピー
			TaxRateSetWork TaxRateSetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
			//税率ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(TaxRateSetWork,fileName);

		}

		/// <summary>
		/// 税率設定Listシリアライズ処理
		/// </summary>
		/// <param name="taxratesetList">シリアライズ対象税率設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 税率設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void ListSerialize(ArrayList taxratesetList,string fileName)
		{
			TaxRateSetWork[] TaxRateSetWorks = new TaxRateSetWork[taxratesetList.Count];
			for(int i= 0; i < taxratesetList.Count; i++)
			{
				TaxRateSetWorks[i] = CopyToTaxRateSetWorkFromTaxrateset((TaxRateSet)taxratesetList[i]);
			}
			//税率設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(TaxRateSetWorks,fileName);

		}

		/// <summary>
		/// 税率設定論理削除処理
		/// </summary>
		/// <param name="taxrateset">税率設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の論理削除を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int LogicalDelete(ref TaxRateSet taxrateset)
		{
			try
			{
				TaxRateSetWork taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// 論理削除
				int status = this._iTaxratesetDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して記録簿管理ワーククラスをデシリアライズする
					taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize( parabyte, typeof(TaxRateSetWork));
					// クラス内メンバコピー
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(taxratesetWork);
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iTaxratesetDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 税率設定物理削除処理
		/// </summary>
		/// <param name="taxrateset">税率設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の物理削除を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Delete(TaxRateSet taxrateset)
		{
			try
			{
				TaxRateSetWork taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// 記録簿管理物理削除
				int status = this._iTaxratesetDB.Delete(parabyte);

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iTaxratesetDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 税率設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 税率設定検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, 0);
		}

		/// <summary>
		/// 税率設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 税率設定検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 税率設定数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定数の検索を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			TaxRateSetWork taxratesetWork = new TaxRateSetWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			// 記録簿管理検索
			int status = this._iTaxratesetDB.SearchCnt(out retTotalCnt, parabyte, 0, logicalMode);

			if ( status != 0 )
			{
				retTotalCnt = 0;
			}
	
			return status;
		}

		/// <summary>
		/// 税率設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
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
		/// 税率設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
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
		/// 税率設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
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
		/// 税率設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
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
		/// 件数指定税率設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終税率設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して税率設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,TaxRateSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// 引数なしの場合リモート設定
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 件数指定税率設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終税率設定データオブジェクト（初回はnull指定必須）</param>			
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して税率設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, TaxRateSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 件数指定税率設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevTaxratesetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終税率設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して税率設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,TaxRateSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// 引数なしの場合リモート設定
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}
		
		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 件数指定税率設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevTaxratesetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevTaxrateset">前回最終税率設定データオブジェクト（初回はnull指定必須）</param>			
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して税率設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, TaxRateSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 税率設定論理削除復活処理
		/// </summary>
		/// <param name="taxrateset">税率設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の復活を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Revival(ref TaxRateSet taxrateset)
		{
			try
			{
				TaxRateSetWork TaxRateSetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(TaxRateSetWork);
				// 復活処理
				int status = this._iTaxratesetDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork));
					// クラス内メンバコピー
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWork);
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iTaxratesetDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}


		/// <summary>
		/// 税率設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevTaxrateset">前回最終税率設定データオブジェクト（初回はnull指定必須）</param>
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の検索処理を行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31　30167　上野　弘貴</br>
		/// <br>             ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, TaxRateSet prevTaxrateset, SearchMode searchMode)
		{
			TaxRateSetWork taxratesetWork = new TaxRateSetWork();

			if ( prevTaxrateset != null )
			{
				taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(prevTaxrateset);
			}
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// 次データ有無初期化
			nextData = false;
			// 0で初期化
			retTotalCnt = 0;

			TaxRateSetWork[] al;
			retList = new ArrayList();
			retList.Clear();

            // 2008.12.01 Update >>>
            //// XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
            //byte[] retbyte = null;

            //// 記録簿管理検索
            //int status = 1;
            //if (readCnt == 0)
            //{
            //    //----- ueno upd ---------- start 2008.01.31
            //    if (searchMode == SearchMode.Remote)
            //    {
            //        status = this._iTaxratesetDB.Search( out retbyte, parabyte, 0, logicalMode);
            //    }
            //    else
            //    {
            //        List<TaxRateSetWork> taxRateSetWorkList = new List<TaxRateSetWork>();
            //        status = this._taxRateSetLcDB.Search(out taxRateSetWorkList, taxratesetWork, 0, logicalMode);

            //        if (status == 0)
            //        {
            //            ArrayList wkAl = new ArrayList();
            //            wkAl.AddRange(taxRateSetWorkList);

            //            byte[] wkByte = XmlByteSerializer.Serialize(taxRateSetWorkList);
            //            retbyte = wkByte;
            //        }
            //    }
            //    //----- ueno upd ---------- end 2008.01.31
            //}
            //else
            //{
            //    status = this._iTaxratesetDB.SearchSpecification( out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt );
            //}

            //if (status == 0)
            //{
            //    // XMLの読み込み
            //    al = (TaxRateSetWork[])XmlByteSerializer.Deserialize(retbyte, typeof(TaxRateSetWork[]));

            //    for ( int i = 0; i < al.Length; i++ )
            //    {
            //        // サーチ結果取得
            //        TaxRateSetWork wkTaxRateSetWork = (TaxRateSetWork)al[i];
            //        // 記録簿管理クラスへメンバコピー
            //        retList.Add( CopyToTaxratesetFromTaxRateSetWork(wkTaxRateSetWork));
            //    }
            //}
            //// 全件リードの場合は戻り値の件数をセット
            //if ( readCnt == 0 )
            //{
            //    retTotalCnt = retList.Count;
            //}

            int status = 1;

            if (readCnt == 0)
            {
                ArrayList retArrayList = new ArrayList();
                if (searchMode == SearchMode.Remote)
                {
                    object retObj;
                    object paraObj = taxratesetWork;
                    status = this._iTaxratesetDB.Search(out retObj, paraObj, 0, logicalMode);
                    if (retObj is ArrayList)
                    {
                        retArrayList = (ArrayList)retObj;
                    }
                }
                else
                {
                    List<TaxRateSetWork> taxRateSetWorkList = new List<TaxRateSetWork>();
                    status = this._taxRateSetLcDB.Search(out taxRateSetWorkList, taxratesetWork, 0, logicalMode);

                    if (status == 0)
                    {
                        retArrayList.AddRange(taxRateSetWorkList);
                    }
                }

                if (status == 0)
                {
                    foreach (TaxRateSetWork wkTaxRateSetWork in retArrayList)
                    {
                        // 記録簿管理クラスへメンバコピー
                        retList.Add(CopyToTaxratesetFromTaxRateSetWork(wkTaxRateSetWork));
                    }
                }
                retTotalCnt = retList.Count;
            }
            else
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
                byte[] retbyte = null;

                status = this._iTaxratesetDB.SearchSpecification(out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt);

                if (status == 0)
                {
                    // XMLの読み込み
                    al = (TaxRateSetWork[])XmlByteSerializer.Deserialize(retbyte, typeof(TaxRateSetWork[]));

                    for (int i = 0; i < al.Length; i++)
                    {
                        // サーチ結果取得
                        TaxRateSetWork wkTaxRateSetWork = (TaxRateSetWork)al[i];
                        // 記録簿管理クラスへメンバコピー
                        retList.Add(CopyToTaxratesetFromTaxRateSetWork(wkTaxRateSetWork));
                    }
                }
            }
            // 2008.12.01 Update <<<
			
			return status;
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// 税率設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds,string enterpriseCode)
		{
		   return SearchDS(ref ds, enterpriseCode, SearchMode.Remote);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 税率設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 税率設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31　30167　上野　弘貴</br>
		/// <br>             ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds, string enterpriseCode, SearchMode searchMode)
		{
			TaxRateSetWork taxratesetWork = new TaxRateSetWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
			byte[] retbyte = null;

			//----- ueno upd ---------- start 2008.01.31
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			if (searchMode == SearchMode.Remote)
			{
				// 記録簿管理サーチ
				status = this._iTaxratesetDB.Search(out retbyte, parabyte, 0, 0);
			}
			else
			{
				// 記録簿管理サーチ
				List<TaxRateSetWork> taxRateSetWorkList = new List<TaxRateSetWork>();
				status = this._taxRateSetLcDB.Search(out taxRateSetWorkList, taxratesetWork, 0, 0);

				if (status == 0)
				{
					ArrayList wkAl = new ArrayList();
					wkAl.AddRange(taxRateSetWorkList);

					byte[] wkByte = XmlByteSerializer.Serialize(taxRateSetWorkList);
					retbyte = wkByte;
				}
			}
			//----- ueno upd ---------- end 2008.01.31

			if ( status == 0 )
			{
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
				
			return status;
		}

		/// <summary>
		/// クラスメンバーコピー処理（税率設定ワーククラス⇒税率設定クラス）
		/// </summary>
		/// <param name="TaxRateSetWork">税率設定ワーククラス</param>
		/// <returns>税率設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 税率設定ワーククラスから税率設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>

		private TaxRateSet CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWork TaxRateSetWork)
		{
			TaxRateSet taxrateset = new TaxRateSet();

			//ファイルヘッダ部分
			taxrateset.CreateDateTime			= TaxRateSetWork.CreateDateTime;
			taxrateset.UpdateDateTime			= TaxRateSetWork.UpdateDateTime;
			taxrateset.EnterpriseCode			= TaxRateSetWork.EnterpriseCode;
			taxrateset.FileHeaderGuid			= TaxRateSetWork.FileHeaderGuid;
			taxrateset.UpdEmployeeCode		    = TaxRateSetWork.UpdEmployeeCode;
			taxrateset.UpdAssemblyId1			= TaxRateSetWork.UpdAssemblyId1;
			taxrateset.UpdAssemblyId2			= TaxRateSetWork.UpdAssemblyId2;
			taxrateset.LogicalDeleteCode			= TaxRateSetWork.LogicalDeleteCode;

			taxrateset.TaxRateCode				= TaxRateSetWork.TaxRateCode;
			taxrateset.TaxRateProperNounNm		= TaxRateSetWork.TaxRateProperNounNm;
			taxrateset.TaxRateName				= TaxRateSetWork.TaxRateName;
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //taxrateset.FractionProcCd         = TaxRateSetWork.FractionProcCd;
            taxrateset.ConsTaxLayMethod         = TaxRateSetWork.ConsTaxLayMethod;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
            taxrateset.TaxRateStartDate = TaxRateSetWork.TaxRateStartDate;
			taxrateset.TaxRateEndDate			= TaxRateSetWork.TaxRateEndDate;
			taxrateset.TaxRate					= TaxRateSetWork.TaxRate;
			taxrateset.TaxRateStartDate2		= TaxRateSetWork.TaxRateStartDate2;
			taxrateset.TaxRateEndDate2			= TaxRateSetWork.TaxRateEndDate2;
			taxrateset.TaxRate2					= TaxRateSetWork.TaxRate2;
			taxrateset.TaxRateStartDate3		= TaxRateSetWork.TaxRateStartDate3;
			taxrateset.TaxRateEndDate3			= TaxRateSetWork.TaxRateEndDate3;
			taxrateset.TaxRate3					= TaxRateSetWork.TaxRate3;
			return taxrateset;
		}

		/// <summary>
		/// クラスメンバーコピー処理（税率設定クラス⇒税率設定ワーククラス）
		/// </summary>
		/// <param name="taxrateset">税率設定ワーククラス</param>
		/// <returns>税率設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 税率設定クラスから税率設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private TaxRateSetWork CopyToTaxRateSetWorkFromTaxrateset(TaxRateSet taxrateset)
		{

 			TaxRateSetWork TaxRateSetWork = new TaxRateSetWork();

			TaxRateSetWork.CreateDateTime			= taxrateset.CreateDateTime;
			TaxRateSetWork.UpdateDateTime			= taxrateset.UpdateDateTime;
			TaxRateSetWork.EnterpriseCode			= taxrateset.EnterpriseCode;
			TaxRateSetWork.FileHeaderGuid			= taxrateset.FileHeaderGuid;
			TaxRateSetWork.UpdEmployeeCode		    = taxrateset.UpdEmployeeCode;
			TaxRateSetWork.UpdAssemblyId1			= taxrateset.UpdAssemblyId1;
			TaxRateSetWork.UpdAssemblyId2			= taxrateset.UpdAssemblyId2;
			TaxRateSetWork.LogicalDeleteCode		= taxrateset.LogicalDeleteCode;

			TaxRateSetWork.TaxRateCode				= taxrateset.TaxRateCode;
			// 2005.06.21 文字列項目のスペースカット。 >>>> START
			/*
			TaxRateSetWork.TaxRateProperNounNm		= taxrateset.TaxRateProperNounNm;
			TaxRateSetWork.TaxRateName				= taxrateset.TaxRateName;
			*/
			TaxRateSetWork.TaxRateProperNounNm		= taxrateset.TaxRateProperNounNm.TrimEnd();
			TaxRateSetWork.TaxRateName				= taxrateset.TaxRateName.TrimEnd();
			// 2005.06.21 文字列項目のスペースカット。 >>>> END

            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //TaxRateSetWork.FractionProcCd         = taxrateset.FractionProcCd;
            TaxRateSetWork.ConsTaxLayMethod         = taxrateset.ConsTaxLayMethod;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
            TaxRateSetWork.TaxRateStartDate         = taxrateset.TaxRateStartDate;
			TaxRateSetWork.TaxRateEndDate			= taxrateset.TaxRateEndDate;
			TaxRateSetWork.TaxRate					= taxrateset.TaxRate;
			TaxRateSetWork.TaxRateStartDate2		= taxrateset.TaxRateStartDate2;
			TaxRateSetWork.TaxRateEndDate2			= taxrateset.TaxRateEndDate2;
			TaxRateSetWork.TaxRate2					= taxrateset.TaxRate2;
			TaxRateSetWork.TaxRateStartDate3		= taxrateset.TaxRateStartDate3;
			TaxRateSetWork.TaxRateEndDate3			= taxrateset.TaxRateEndDate3;
			TaxRateSetWork.TaxRate3					= taxrateset.TaxRate3;

			return TaxRateSetWork;
		}
		/// <summary>
		/// 対象データチェック
		/// </summary>
		/// <param name="taxrateset">対象データ</param>
		/// <param name="taxratesetPara">パラメータ</param>
		/// <returns>チェック結果（true:OK false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 対象データとパラメータを比較します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private bool checkTarGetData(
			TaxRateSet taxrateset,
			TaxRateSet taxratesetPara)
		{
			// 企業コードを比較
			if (taxratesetPara.EnterpriseCode != null)
				if (!taxratesetPara.EnterpriseCode.Equals(taxrateset.EnterpriseCode))
					return false;

			// コード比較
			if (taxratesetPara.TaxRateCode > 0)
				if (!taxratesetPara.TaxRateCode.Equals(taxrateset.TaxRateCode))
					return false;

			return true;
		}

        // 2008.07.31 Add >>>
        /// <summary>
        /// 税率設定マスタより、対象日の税率を取得します。
        /// </summary>
        /// <param name="taxRateSet">税率設定クラスオブジェクト</param>
        /// <param name="targetDate">対象日</param>
        /// <returns>税率</returns>
        public static double GetTaxRate( TaxRateSet taxRateSet, DateTime targetDate )
        {
            double taxRate = 0;

            //if (taxRateSet == null) return taxRate; // DEL 譚洪 2013/12/16

            // --------- ADD 譚洪 2013/12/16 -------------- >>>>>>>
            if (taxRateSet == null || targetDate == null) return taxRate;

            taxRateSet.TaxRateStartDate = new DateTime(taxRateSet.TaxRateStartDate.Year, taxRateSet.TaxRateStartDate.Month, taxRateSet.TaxRateStartDate.Day);

            taxRateSet.TaxRateEndDate = new DateTime(taxRateSet.TaxRateEndDate.Year, taxRateSet.TaxRateEndDate.Month, taxRateSet.TaxRateEndDate.Day);

            taxRateSet.TaxRateStartDate2 = new DateTime(taxRateSet.TaxRateStartDate2.Year, taxRateSet.TaxRateStartDate2.Month, taxRateSet.TaxRateStartDate2.Day);

            taxRateSet.TaxRateEndDate2 = new DateTime(taxRateSet.TaxRateEndDate2.Year, taxRateSet.TaxRateEndDate2.Month, taxRateSet.TaxRateEndDate2.Day);

            taxRateSet.TaxRateStartDate3 = new DateTime(taxRateSet.TaxRateStartDate3.Year, taxRateSet.TaxRateStartDate3.Month, taxRateSet.TaxRateStartDate3.Day);

            taxRateSet.TaxRateEndDate3 = new DateTime(taxRateSet.TaxRateEndDate3.Year, taxRateSet.TaxRateEndDate3.Month, taxRateSet.TaxRateEndDate3.Day);

            targetDate = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day);
            // --------- ADD 譚洪 2013/12/16 -------------- <<<<<<<

            //
            if (( targetDate >= taxRateSet.TaxRateStartDate ) && ( targetDate <= taxRateSet.TaxRateEndDate ))
            {
                taxRate = taxRateSet.TaxRate;                
            }
            else if (( targetDate >= taxRateSet.TaxRateStartDate2 ) && ( targetDate <= taxRateSet.TaxRateEndDate2 ))
            {
                taxRate = taxRateSet.TaxRate2;
            }
            else if ((targetDate >= taxRateSet.TaxRateStartDate3) && (targetDate <= taxRateSet.TaxRateEndDate3))
            {
                taxRate = taxRateSet.TaxRate3;
            }

            return taxRate;
        }
        // 2008.07.31 Add <<<

    }
}
