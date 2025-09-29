using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 仕入金額処理区分設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入金額処理区分設定ーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30167 上野 弘貴</br>
    /// <br>Date       : 2007.08.20</br>
    /// <br>Update Note: 2009.07.13 20056 對馬 大輔 LoginInfoAcquisition.OnlineFlagを参照して制御切替を行わない(常にOnline)</br>
    /// </remarks>
	public class StockProcMoneyAcs : IGeneralGuideData
	{
		# region Private Member

		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IStockProcMoneyDB _iStockProcMoneyDB = null;

		// Static格納用HashTable
		private static Hashtable _static_StockProcMoneyTable = null;

		/// <summary>仕入金額処理区分設定マスタクラスSearchフラグ</summary>
		private static bool _searchFlg;

		// ガイド設定ファイル名
		private const string GUIDE_XML_FILENAME = "STOCKPROCMONEYGUIDEPARENT.XML";	// XMLファイル名

		// ガイドパラメータ
		private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";			// 企業コード

		// ガイド項目タイプ
		private const string GUIDE_TYPE_STR = "System.String";						// String型

		// ガイド項目名
		private const string FRACPROCMONEYDIV_TITLE = "FracProcMoneyDiv";			// 端数処理対象金額区分
		private const string FRACTIONPROCCODE_TITLE = "FractionProcCode";			// 端数処理コード
		private const string UPPERLIMITPRICE_TITLE	= "UpperLimitPrice";			// 上限区分
		private const string FRACTIONPROCUNIT_TITLE = "FractionProcUnit";			// 端数処理単位
        private const string FRACTIONPROCCDNM_TITLE = "FractionProcCdNm";           // 端数処理区分名

		# endregion

		/// <summary>
		/// 仕入金額処理区分設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public StockProcMoneyAcs()
		{
			// メモリ生成処理
			MemoryCreate();

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ログイン部品で通信状態を確認
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iStockProcMoneyDB = (IStockProcMoneyDB)MediationStockProcMoneyDB.GetStockProcMoneyDB();
            //    }
            //    catch (Exception)
            //    {		
            //        // オフライン時はnullをセット
            //        this._iStockProcMoneyDB = null;
            //    }
            //}
            //else
            //{
            //    // オフライン時のデータ読み込み(未実装)
            //}

            try
            {
                // リモートオブジェクト取得
                this._iStockProcMoneyDB = (IStockProcMoneyDB)MediationStockProcMoneyDB.GetStockProcMoneyDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockProcMoneyDB = null;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
		/// 仕入金額処理区分設定テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : 仕入金額処理区分設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		static StockProcMoneyAcs()
        {
            // Static格納用HashTable
			_static_StockProcMoneyTable = new Hashtable();
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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iStockProcMoneyDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定 Staticメモリ全件取得処理
		/// </summary>
		/// <param name="retList">仕入金額処理区分設定マスタ クラスList</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <param name="enterpriseCode">企業コード</param>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定マスタ Staticメモリの全件を取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList, string enterpriseCode)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			if ((_static_StockProcMoneyTable == null) || (_static_StockProcMoneyTable.Count == 0))
			{
				this.SearchAll(out retList, enterpriseCode);

				return 0;
			}
			else if (_static_StockProcMoneyTable.Count == 0)
			{
				return 9;
			}

			foreach (StockProcMoney stockProcMoney in _static_StockProcMoneyTable.Values)
			{
				sortedList.Add(CreateHashKey(stockProcMoney), stockProcMoney);
			}
			retList.AddRange(sortedList.Values);

			return 0;
		}

		/// <summary>
		/// 仕入金額処理区分設定読み込み処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="upperLimitPrice">上限金額</param>
		/// <returns>仕入金額処理区分設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定情報を読み込みます。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Read(out StockProcMoney stockProcMoney, string enterpriseCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice)
		{			
			try
			{
				int status = 0;
				stockProcMoney = null;
				StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
				
				// キー項目設定
				stockProcMoneyWork.EnterpriseCode	= enterpriseCode;
				stockProcMoneyWork.FracProcMoneyDiv = fracProcMoneyDiv;
				stockProcMoneyWork.FractionProcCode = fractionProcCode;
				stockProcMoneyWork.UpperLimitPrice	= upperLimitPrice;

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(stockProcMoneyWork);

				// 仕入金額処理区分設定読み込み
				status = this._iStockProcMoneyDB.Read(ref parabyte, 0);

				// XMLの読み込み 
				stockProcMoneyWork = (StockProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockProcMoneyWork));
				
				if (status == 0)
				{
					// クラス内メンバコピー
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Staticに保持
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
				}
				return status;
			}
			catch (Exception)
			{				
				// 通信エラーは-1を戻す
				stockProcMoney = null;
				// オフライン時はnullをセット
				this._iStockProcMoneyDB = null;
				return -1;
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定登録・更新処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定情報の登録・更新を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Write(ref StockProcMoney stockProcMoney)
		{
			int status = 0;

			try
			{
				// 仕入金額処理区分設定クラスから仕入金額処理区分設定ワーククラスにメンバコピー
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);

				ArrayList paraList = new ArrayList();
				paraList.Add(stockProcMoneyWork);
				object paraObj = (object)paraList;

				//仕入金額処理区分設定書き込み
				status = this._iStockProcMoneyDB.Write(ref paraObj);
				
				if (status == 0)
				{
					paraList = paraObj as ArrayList;
					stockProcMoneyWork = (StockProcMoneyWork)paraList[0];

					// クラス内メンバコピー
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Staticに更新
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
				}
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iStockProcMoneyDB = null;
				// 通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 仕入金額処理区分設定論理削除処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定情報の論理削除を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int LogicalDelete(ref StockProcMoney stockProcMoney)
		{
			try
			{
				int status = 0;

				// 仕入金額処理区分設定クラスから仕入金額処理区分設定ワーククラスにメンバコピー
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);

				ArrayList paraList = new ArrayList();
				paraList.Add(stockProcMoneyWork);

				object paraObj = (object)paraList;

				// 論理削除
				status = this._iStockProcMoneyDB.LogicalDelete(ref paraObj);

				if (status == 0)
				{
					paraList = paraObj as ArrayList;
					stockProcMoneyWork = (StockProcMoneyWork)paraList[0];

					// クラス内メンバコピー
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Staticに更新
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney.Clone();
				}
				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iStockProcMoneyDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定物理削除処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定情報の物理削除を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Delete(StockProcMoney stockProcMoney)
		{
			try
			{
				int status = 0;

				// 仕入金額処理区分設定クラスから仕入金額処理区分設定ワーククラスにメンバコピー
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);
				
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(stockProcMoneyWork);

				// 物理削除
				status = this._iStockProcMoneyDB.Delete(parabyte);

				// Staticに更新
				_static_StockProcMoneyTable.Remove(CreateHashKey(stockProcMoney));

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iStockProcMoneyDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定の全検索処理を行います。論理削除データは抽出対象外</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, enterpriseCode, 0, null);
		}

		/// <summary>
		/// 仕入金額処理区分設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
		}

		/// <summary>
		/// 仕入金額処理区分設定論理削除復活処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定情報の復活を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Revival(ref StockProcMoney stockProcMoney)
		{
			try
			{
				int status = 0;

				// 仕入金額処理区分設定クラスから仕入金額処理区分設定ワーククラスにメンバコピー
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);

				ArrayList paraList = new ArrayList();
				paraList.Add(stockProcMoneyWork);
				object paraObj = (object)paraList;

				// 復活処理
				status = this._iStockProcMoneyDB.RevivalLogicalDelete(ref paraObj);

				if (status == 0)
				{
					paraList = paraObj as ArrayList;
					stockProcMoneyWork = (StockProcMoneyWork)paraList[0];

					// クラス内メンバコピー
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Staticに保持
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
				}
				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iStockProcMoneyDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevStockProcMoneyがnullの場合のみ戻る)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="prevStockProcMoney">前回最終仕入金額処理区分設定データオブジェクト（初回はnull指定必須）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定の検索処理を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, StockProcMoney prevStockProcMoney)
		{
			StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
			
			if (prevStockProcMoney != null)
			{
				// 仕入金額処理区分設定クラスから仕入金額処理区分設定ワーククラスにメンバコピー
				stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(prevStockProcMoney);
			}
			stockProcMoneyWork.EnterpriseCode = enterpriseCode;

			// 絞り込み無効
			stockProcMoneyWork.FracProcMoneyDiv = -1;	// 端数処理対象金額区分
			stockProcMoneyWork.FractionProcCode = -1;	// 端数処理コード

			retList = new ArrayList();
			retList.Clear();

			retTotalCnt = 0;
			int status = 0;

			ArrayList paraList = new ArrayList();
			paraList.Clear();	// 取得データ格納用ワーククリア

			object retObj = null;

			ArrayList al = new ArrayList();
			al.Add(stockProcMoneyWork);
			object paraObj = al;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オフラインの場合はキャッシュから読む
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList, enterpriseCode);
            //}
            //else
            //{
            //    StockProcMoney stockProcMoney = new StockProcMoney();

            //    // 検索
            //    status = this._iStockProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);

            //    if (status == 0)
            //    {
            //        // 仕入金額処理区分設定マスタワーカークラス⇒UIクラスStatic転記処理
            //        CopyToStaticFromWorker(retObj as ArrayList);

            //        // パラメータが渡って来ているか確認
            //        paraList = retObj as ArrayList;
            //        StockProcMoneyWork[] wkStockProcMoneyWork = new StockProcMoneyWork[paraList.Count];

            //        // データを元に戻す
            //        for (int i = 0; i < paraList.Count; i++)
            //        {
            //            wkStockProcMoneyWork[i] = (StockProcMoneyWork)paraList[i];
            //        }
            //        for (int i = 0; i < wkStockProcMoneyWork.Length; i++)
            //        {
            //            stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(wkStockProcMoneyWork[i]);
            //            // サーチ結果取得
            //            retList.Add(stockProcMoney);
            //            // スタティック更新
            //            _static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
            //        }
            //        // SearchFlg ON
            //        _searchFlg = true;
            //    }
            //}

            // オフラインの場合はキャッシュから読む
            StockProcMoney stockProcMoney = new StockProcMoney();

            // 検索
            status = this._iStockProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);

            if (status == 0)
            {
                // 仕入金額処理区分設定マスタワーカークラス⇒UIクラスStatic転記処理
                CopyToStaticFromWorker(retObj as ArrayList);

                // パラメータが渡って来ているか確認
                paraList = retObj as ArrayList;
                StockProcMoneyWork[] wkStockProcMoneyWork = new StockProcMoneyWork[paraList.Count];

                // データを元に戻す
                for (int i = 0; i < paraList.Count; i++)
                {
                    wkStockProcMoneyWork[i] = (StockProcMoneyWork)paraList[i];
                }
                for (int i = 0; i < wkStockProcMoneyWork.Length; i++)
                {
                    stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(wkStockProcMoneyWork[i]);
                    // サーチ結果取得
                    retList.Add(stockProcMoney);
                    // スタティック更新
                    _static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
                }
                // SearchFlg ON
                _searchFlg = true;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return status;
		}

        /// <summary>
        /// 仕入金額処理区分設定マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入金額処理区分設定マスタの検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode, int fracProcMoneyDiv, int fractionProcCode)
        {
            ArrayList ar = new ArrayList();
            ArrayList stockProcMoneyList = new ArrayList();

            int status = 0;
            int retTotalCnt;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
            //if (( !_searchFlg ) && ( LoginInfoAcquisition.OnlineFlag ))
            //{
            //    // 仕入金額処理区分設定マスタサーチ
            //    status = this.SearchProc(out stockProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
            //    if (status == 0)
            //    {
            //    }
            //    else
            //    {
            //        return status;
            //    }
            //}

            // オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
            if (!_searchFlg)
            {
                // 仕入金額処理区分設定マスタサーチ
                status = this.SearchProc(out stockProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
                if (status == 0)
                {
                }
                else
                {
                    return status;
                }
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // Staticからガイド表示（オン/オフ共通）	
			foreach (StockProcMoney stockProcMoney in _static_StockProcMoneyTable.Values)
            {
                // 端数処理対象区分が指定されている場合はここで絞り込み
				if ((fracProcMoneyDiv == -1) || (stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv))
                {
                    // 端数処理コードが指定されている場合はここで絞り込み
                    if ((fractionProcCode == -1) || (stockProcMoney.FractionProcCode == fractionProcCode))
                    {
                        // 全社表示
                        ar.Add(stockProcMoney.Clone());
                    }
                }
            }

            ArrayList wkList = ar.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
			foreach (StockProcMoney wkStockProcMoney in wkList)
            {
				if (wkStockProcMoney.LogicalDeleteCode == 0)
                {
					wkSort.Add(CreateHashKey(wkStockProcMoney), wkStockProcMoney);
                }
            }

			StockProcMoney[] stockProcMoneys = new StockProcMoney[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
				stockProcMoneys[i] = (StockProcMoney)wkSort.GetByIndex(i);
            }

			byte[] retbyte = XmlByteSerializer.Serialize(stockProcMoneys);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

		/// <summary>
		/// クラスメンバーコピー処理（仕入金額処理区分設定ワーククラス⇒仕入金額処理区分設定クラス）
		/// </summary>
		/// <param name="stockProcMoneyWork">仕入金額処理区分設定ワーククラス</param>
		/// <returns>仕入金額処理区分設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定ワーククラスから仕入金額処理区分設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private StockProcMoney CopyToStockProcMoneyFromStockProcMoneyWork(StockProcMoneyWork stockProcMoneyWork)
		{
			StockProcMoney stockProcMoney = new StockProcMoney();

			stockProcMoney.CreateDateTime		= stockProcMoneyWork.CreateDateTime;
			stockProcMoney.UpdateDateTime		= stockProcMoneyWork.UpdateDateTime;
			stockProcMoney.EnterpriseCode		= stockProcMoneyWork.EnterpriseCode;
			stockProcMoney.FileHeaderGuid		= stockProcMoneyWork.FileHeaderGuid;
			stockProcMoney.UpdEmployeeCode		= stockProcMoneyWork.UpdEmployeeCode;
			stockProcMoney.UpdAssemblyId1		= stockProcMoneyWork.UpdAssemblyId1;
			stockProcMoney.UpdAssemblyId2		= stockProcMoneyWork.UpdAssemblyId2;
			stockProcMoney.LogicalDeleteCode	= stockProcMoneyWork.LogicalDeleteCode;
			stockProcMoney.FracProcMoneyDiv		= stockProcMoneyWork.FracProcMoneyDiv;
			stockProcMoney.FractionProcCode		= stockProcMoneyWork.FractionProcCode;
			stockProcMoney.UpperLimitPrice		= stockProcMoneyWork.UpperLimitPrice;
			stockProcMoney.FractionProcUnit		= stockProcMoneyWork.FractionProcUnit;
			stockProcMoney.FractionProcCd		= stockProcMoneyWork.FractionProcCd;

			// ガイド用名称設定
			stockProcMoney.FractionProcCdNm		= StockProcMoney.GetFractionProcCdNm(stockProcMoneyWork.FractionProcCd);

			return stockProcMoney;
		}
		
		/// <summary>
		/// クラスメンバーコピー処理（仕入金額処理区分設定クラス⇒仕入金額処理区分設定ワーククラス）
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定ワーククラス</param>
		/// <returns>仕入金額処理区分設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定クラスから仕入金額処理区分設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private StockProcMoneyWork CopyToStockProcMoneyWorkFromStockProcMoney(StockProcMoney stockProcMoney)
		{
			StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();

			stockProcMoneyWork.CreateDateTime		= stockProcMoney.CreateDateTime;
			stockProcMoneyWork.UpdateDateTime		= stockProcMoney.UpdateDateTime;
			stockProcMoneyWork.EnterpriseCode		= stockProcMoney.EnterpriseCode.Trim();
			stockProcMoneyWork.FileHeaderGuid		= stockProcMoney.FileHeaderGuid;
			stockProcMoneyWork.UpdEmployeeCode		= stockProcMoney.UpdEmployeeCode;
			stockProcMoneyWork.UpdAssemblyId1		= stockProcMoney.UpdAssemblyId1;
			stockProcMoneyWork.UpdAssemblyId2		= stockProcMoney.UpdAssemblyId2;
			stockProcMoneyWork.LogicalDeleteCode	= stockProcMoney.LogicalDeleteCode;
			stockProcMoneyWork.FracProcMoneyDiv		= stockProcMoney.FracProcMoneyDiv;
			stockProcMoneyWork.FractionProcCode		= stockProcMoney.FractionProcCode;
			stockProcMoneyWork.UpperLimitPrice		= stockProcMoney.UpperLimitPrice;
			stockProcMoneyWork.FractionProcUnit		= stockProcMoney.FractionProcUnit;
			stockProcMoneyWork.FractionProcCd		= stockProcMoney.FractionProcCd;

			return stockProcMoneyWork;
		}

		/// <summary>
		/// クラスメンバコピー処理 (ガイド選択データ⇒仕入金額処理区分設定マスタクラス)
		/// </summary>
		/// <param name="guideData">ガイド選択データ</param>
		/// <returns>仕入金額処理区分設定マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : ガイド選択データから仕入金額処理区分設定マスタクラスへメンバコピーを行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.28</br>
		/// </remarks>
		private StockProcMoney CopyToStockProcMoneyFromGuideData(Hashtable guideData)
		{
			StockProcMoney stockProcMoney = new StockProcMoney();

			stockProcMoney.FracProcMoneyDiv = int.Parse(guideData[FRACPROCMONEYDIV_TITLE].ToString());		    // 端数処理対象金額区分
			stockProcMoney.FractionProcCode = int.Parse(guideData[FRACTIONPROCCODE_TITLE].ToString());		    // 端数処理コード
			stockProcMoney.UpperLimitPrice	= double.Parse(guideData[UPPERLIMITPRICE_TITLE].ToString());	    // 上限区分
			stockProcMoney.FractionProcUnit = double.Parse(guideData[FRACTIONPROCUNIT_TITLE].ToString());	    // 端数処理単位
			stockProcMoney.FractionProcCdNm = guideData[FRACTIONPROCCDNM_TITLE].ToString();                     // 端数処理区分名(ガイド用)
            stockProcMoney.FractionProcCd = StockProcMoney.GetFractionProcCd(stockProcMoney.FractionProcCdNm);  // 端数処理区分

			return stockProcMoney;
		}

		/// <summary>
		/// 仕入金額処理区分設定マスタガイド起動処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="stockProcMoney">取得データ</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note		: 仕入金額処理区分設定マスタの一覧表示機能を持つガイドを起動します。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.08.28</br>
		/// </remarks>
		public int ExecuteGuid(string enterpriseCode, int fracProcMoneyDiv, int fractionProcCode, out StockProcMoney stockProcMoney)
		{
			int status = -1;
			stockProcMoney = new StockProcMoney();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();

			inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);	// 企業コード
			inObj.Add(FRACPROCMONEYDIV_TITLE, fracProcMoneyDiv);	// 端数処理対象金額区分
			inObj.Add(FRACTIONPROCCODE_TITLE, fractionProcCode);	// 端数処理コード

			// ガイド起動
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				// 選択データの取得
				stockProcMoney = CopyToStockProcMoneyFromGuideData(retObj);
				status = 0;
			}
			// キャンセル
			else
			{
				status = 1;
			}
			return status;
		}

		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note		: 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.08.28</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = -1;
			string enterpriseCode = "";
			int fracProcMoneyDiv = -1;
			int fractionProcCode = -1;

			// 企業コード設定有り
			if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA))
			{
				enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
			}
			// 企業コード設定無し
			else
			{
				// 有り得ないのでエラー
				return status;
			}

			// 端数処理対象金額区分
			if (inParm.ContainsKey(FRACPROCMONEYDIV_TITLE))
			{
				fracProcMoneyDiv = int.Parse(inParm[FRACPROCMONEYDIV_TITLE].ToString());
			}

			// 端数処理コード
			if (inParm.ContainsKey(FRACTIONPROCCODE_TITLE))
			{
				fractionProcCode = int.Parse(inParm[FRACTIONPROCCODE_TITLE].ToString());
            }

            _searchFlg = false;

            // データ取得
			status = Search(ref guideList, enterpriseCode, fracProcMoneyDiv, fractionProcCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				default:
					{
						status = -1;
						break;
					}
			}
			return status;
		}

		/// <summary>
		/// メモリ生成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定アクセスクラスが保持するメモリを生成します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private void MemoryCreate()
		{

			// 仕入金額処理区分設定マスタクラスStatic
			if (_static_StockProcMoneyTable == null)
			{
				_static_StockProcMoneyTable = new Hashtable();
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定ワーカークラス（List） ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="stockProcMoneyWorkList">仕入金額処理区分設定マスタワーカークラスのArrayList</param>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定マスタワーカークラスをUIのクラスに変換して、
		///					 Search用Staticメモリに保持します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private void CopyToStaticFromWorker(List<StockProcMoneyWork> stockProcMoneyWorkList)
		{
			ArrayList stockProcMoneyWorkArray = new ArrayList();
			stockProcMoneyWorkArray.AddRange(stockProcMoneyWorkList);

			CopyToStaticFromWorker(stockProcMoneyWorkArray);
		}

		/// <summary>
		/// 仕入金額処理区分設定ワーカークラス（ArrayList） ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="stockProcMoneyWorkList">仕入金額処理区分設定マスタワーカークラスのArrayList</param>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定ワーカークラスをUIのクラスに変換して、
		///					 Search用Staticメモリに保持します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private void CopyToStaticFromWorker(ArrayList stockProcMoneyWorkList)
		{
			string hashKey;
			foreach (StockProcMoneyWork wkStockProcMoneyWork in stockProcMoneyWorkList)
			{
				StockProcMoney stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(wkStockProcMoneyWork);

				// HashKey:端数処理対象金額区分、端数処理コード、上限金額
				hashKey = CreateHashKey(stockProcMoney);

				_static_StockProcMoneyTable[hashKey] = stockProcMoney;
			}
		}

		/// <summary>
		/// HashTable用Key作成
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定クラス</param>
		/// <returns>Hash用Key</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定クラスからハッシュテーブル用の
		///					 キーを作成します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private string CreateHashKey(StockProcMoney stockProcMoney)
		{
			return stockProcMoney.FracProcMoneyDiv.ToString("d9") +
				   stockProcMoney.FractionProcCode.ToString("d9") +
				   stockProcMoney.UpperLimitPrice.ToString("000000000.00");
		}
	}
}
