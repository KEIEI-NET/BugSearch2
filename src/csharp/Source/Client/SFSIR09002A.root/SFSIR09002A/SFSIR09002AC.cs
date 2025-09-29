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
    /// 仕入在庫全体設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入在庫全体設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 19018 Y.Gamoto</br>
    /// <br>Date       : 2005.04.12</br>
    /// <br></br>
    /// <br>Update Note: 2005.06.21 22035 三橋 弘憲</br>
    /// <br>           : 文字列の最後にあるスペースを削除</br>
    /// <br>Update Note: 2006.12.20 20031 古賀　小百合</br>
    /// <br>           : 項目追加</br>
    /// <br>Update Note: 2007.06.12 30005 木建　翼</br>
    /// <br>           : 検索条件「仕入価格取得単位区分」追加</br>
	/// <br>Update Note: 2008.02.18 30167 上野　弘貴</br>
	/// <br>			 自動支払関連項目追加</br>
    /// <br>Update Note: 2008.02.27 20081 疋田 勇人</br>
    /// <br>			 入出荷数区分２を追加</br>
    /// <br>UpdateNote : 2008/06/06 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>   
    /// <br>UpdateNote : 2008/07/22 30415 柴田 倫幸</br>
    /// <br>        	 ・項目の削除による修正</br>   
    /// <br>UpdateNote : 2008/9/12 30452 上野 俊治</br>
    /// <br>        	 ・在庫検索区分の追加</br>
    /// <br>UpdateNote : 2008.12.01　21024　佐々木 健</br>
    /// <br>        	 ・Searchメソッドの実装</br>
    /// <br>        	 ・金種取得時に不要な処理を繰り返さないように修正</br>
    /// <br>UpdateNote : 2009.02.25　20056 對馬 大輔</br>
    /// <br>        	 ・仕入在庫全体情報のみ取得するSearchメソッド追加</br>
    /// </remarks>
    public class StockTtlStAcs
    {
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IStockTtlStDB _iStockTtlStDB = null;

		//----- ueno add ---------- start 2008.02.18
		// 金額種別設定マスタアクセスクラス
		private MoneyKindAcs _moneyKindAcs = null;

		// 金額種別区分マスタアクセスクラス
		private MnyKindDivAcs _mnyKindDivAcs = null;
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// 仕入在庫全体設定テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public StockTtlStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iStockTtlStDB = (IStockTtlStDB)MediationStockTtlStDB.GetStockTtlStDB();

				//----- ueno add ---------- start 2008.02.18
				// 金額種別設定マスタアクセスクラス
				this._moneyKindAcs = new MoneyKindAcs();

				// 金額種別区分マスタアクセスクラス
				this._mnyKindDivAcs = new MnyKindDivAcs();
				//----- ueno add ---------- end 2008.02.18

                // 2008.12.01 Add >>>
                StockTtlSt._autoPayMoneyKindCodeList = null;
                StockTtlSt._mnyKindDivList = null;
                // 2008.12.01 Add <<<
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iStockTtlStDB = null;
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
        /// オンラインモード取得
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>		
        public int GetOnlineMode()
        {
            if (this._iStockTtlStDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

		//----- ueno add ---------- start 2008.02.18
		#region 自動支払金種区分コード取得処理
		/// <summary>
		/// 自動支払金種区分コード取得処理
		/// </summary>
		/// <param name="autoPayMoneyKindCode">自動支払金種コード</param>
		/// <returns>自動支払金種区分コード</returns>
		/// <remarks>
		/// <br>Note       : 自動支払金種区分コードを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public int GetAutoPayMoneyKindDiv(int autoPayMoneyKindCode)
		{
			int autoPayMoneyKindDiv = 0;

			if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(autoPayMoneyKindCode) == true)
			{
				MoneyKind moneyKind = (MoneyKind)StockTtlSt._autoPayMoneyKindCodeList[autoPayMoneyKindCode];
				autoPayMoneyKindDiv = moneyKind.MoneyKindDiv;	// 金額種別区分設定
			}
			return autoPayMoneyKindDiv;
		}
		#endregion

		#region 自動支払金種名称取得処理
		/// <summary>
		/// 自動支払金種名称取得処理
		/// </summary>
		/// <param name="autoPayMoneyKindCode">自動支払金種コード</param>
		/// <returns>自動支払金種名称</returns>
		/// <remarks>
		/// <br>Note       : 自動支払金種名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public string GetAutoPayMoneyKindName(int autoPayMoneyKindCode)
		{
			string autoPayMoneyKindName = "";

			if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(autoPayMoneyKindCode) == true)
			{
				MoneyKind moneyKind = (MoneyKind)StockTtlSt._autoPayMoneyKindCodeList[autoPayMoneyKindCode];
				autoPayMoneyKindName = moneyKind.MoneyKindName;	// 金種名称設定
			}
			return autoPayMoneyKindName;
		}
		#endregion
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// 仕入在庫全体設定読み込み処理
        /// </summary>
        /// <param name="stockttlset">仕入在庫全体設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>   
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定を読み込みます。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public int Read(out StockTtlSt stockttlset, string enterpriseCode)
        {
            try
            {
				//----- ueno add ---------- start 2008.02.18
				// 金額種別設定データ取得設定
				SetMoneyKindList(enterpriseCode);

				// 金額種別区分データ取得設定
				SetMnyKindDivList();
				//----- ueno add ---------- end 2008.02.18

                stockttlset = null;
                StockTtlStWork stockttlsetWork = new StockTtlStWork();
                stockttlsetWork.EnterpriseCode = enterpriseCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockttlsetWork);

                //仕入在庫全体設定読み込み
                int status = this._iStockTtlStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    stockttlsetWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));
                    // クラス内メンバコピー
                    stockttlset = CopyToStockTtlStFromStockTtlStWork(stockttlsetWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                stockttlset = null;
                //オフライン時はnullをセット
                this._iStockTtlStDB = null;
                return -1;
            }
        }

        //----- ueno add ---------- start 2008.02.18
		/// <summary>
		/// 金額種別設定データ設定処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定データの取得を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private int SetMoneyKindList(string enterpriseCode)
		{
            // 2008.12.01 Del >>>
            //if (StockTtlSt._autoPayMoneyKindCodeList == null)
            //{
            //    StockTtlSt._autoPayMoneyKindCodeList = new SortedList();
            //}

            //ArrayList wkMoneyKindList = null;				// 全ての金額種別設定リスト
            //int status = this._moneyKindAcs.Search(out wkMoneyKindList, enterpriseCode);

            //if (status == 0)
            //{
            //    foreach (MoneyKind moneyKind in wkMoneyKindList)
            //    {
            //        // 金種設定区分が"入金"のデータのみ設定する
            //        if (moneyKind.PriceStCode == 0)
            //        {
            //            if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(moneyKind.MoneyKindCode) == false)
            //            {
            //                // key:金種コード, value:金額種別設定オブジェクト
            //                StockTtlSt._autoPayMoneyKindCodeList.Add(moneyKind.MoneyKindCode, moneyKind);
            //            }
            //        }
            //    }
            //}
            if (StockTtlSt._autoPayMoneyKindCodeList == null)
            {
                StockTtlSt._autoPayMoneyKindCodeList = new SortedList();

                ArrayList wkMoneyKindList = null;				// 全ての金額種別設定リスト
                int status = this._moneyKindAcs.Search(out wkMoneyKindList, enterpriseCode);

                if (status == 0)
                {
                    foreach (MoneyKind moneyKind in wkMoneyKindList)
                    {
                        // 金種設定区分が"入金"のデータのみ設定する
                        if (moneyKind.PriceStCode == 0)
                        {
                            if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(moneyKind.MoneyKindCode) == false)
                            {
                                // key:金種コード, value:金額種別設定オブジェクト
                                StockTtlSt._autoPayMoneyKindCodeList.Add(moneyKind.MoneyKindCode, moneyKind);
                            }
                        }
                    }
                }
            }
            // 2008.12.01 Del <<<
            return 0;
		}

		/// <summary>
		///  金額種別区分データ設定処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別区分データの取得を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private int SetMnyKindDivList()
		{
            // 2008.12.01 Update >>>
            //if (StockTtlSt._mnyKindDivList == null)
            //{
            //    StockTtlSt._mnyKindDivList = new SortedList();
            //}

            //ArrayList mnyKindDivList = null;
            //this._mnyKindDivAcs.Search(out mnyKindDivList);

            //foreach (MnyKindDiv mnyKindDiv in mnyKindDivList)
            //{
            //    if (StockTtlSt._mnyKindDivList.ContainsKey(mnyKindDiv.MoneyKindDiv) == false)
            //    {
            //        StockTtlSt._mnyKindDivList.Add(mnyKindDiv.MoneyKindDiv, mnyKindDiv.MoneyKindDivName);
            //    }
            //}

            if (StockTtlSt._mnyKindDivList == null)
            {
                StockTtlSt._mnyKindDivList = new SortedList();

                ArrayList mnyKindDivList = null;
                this._mnyKindDivAcs.Search(out mnyKindDivList);

                foreach (MnyKindDiv mnyKindDiv in mnyKindDivList)
                {
                    if (StockTtlSt._mnyKindDivList.ContainsKey(mnyKindDiv.MoneyKindDiv) == false)
                    {
                        StockTtlSt._mnyKindDivList.Add(mnyKindDiv.MoneyKindDiv, mnyKindDiv.MoneyKindDivName);
                    }
                }
            }
            // 2008.12.01 Update <<<
            return 0;
		}
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// 仕入在庫全体設定クラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>仕入在庫全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public StockTtlSt Deserialize(string fileName)
        {
            StockTtlSt stockttlset = null;

            // ファイル名を渡して>仕入在庫全体設定ワーククラスをデシリアライズする
            StockTtlStWork stockttlsetWork = (StockTtlStWork)XmlByteSerializer.Deserialize(fileName, typeof(StockTtlStWork));
            //デシリアライズ結果を>仕入在庫全体設定クラスへコピー
            if (stockttlsetWork != null) stockttlset = CopyToStockTtlStFromStockTtlStWork(stockttlsetWork);
            return stockttlset;
        }

        /// <summary>
        /// 仕入在庫全体設定Listクラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>仕入在庫全体設定クラスLIST</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定リストクラスをデシリアライズします。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>		
        public ArrayList ListDeserialize(string fileName)
        {
            ArrayList al = new ArrayList();
            // ファイル名を渡して仕入在庫全体設定ワーククラスをデシリアライズする
            StockTtlStWork[] stockttlsetWorks = (StockTtlStWork[])XmlByteSerializer.Deserialize(fileName, typeof(StockTtlStWork[]));

            //デシリアライズ結果を仕入在庫全体設定クラスへコピー
            if (stockttlsetWorks != null)
            {
                al.Capacity = stockttlsetWorks.Length;
                for (int i = 0; i < stockttlsetWorks.Length; i++)
                {
                    al.Add(CopyToStockTtlStFromStockTtlStWork(stockttlsetWorks[i]));
                }
            }
            return al;
        }

        // 2008.12.01 Add >>>
        /// <summary>
        /// 仕入在庫全体設定検索処理
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の検索処理を行います。論理削除データは抽出されません</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2008.12.01 Add <<<

        /// <summary>
        /// 仕入在庫全体設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// 仕入在庫全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の検索処理を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            StockTtlStWork stockTtlStWork = new StockTtlStWork();
            stockTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            // 金額種別設定データ取得設定
            SetMoneyKindList(enterpriseCode);

            // 金額種別区分データ取得設定
            SetMnyKindDivList();

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = stockTtlStWork;
            object retobj = null;

            // 仕入在庫全体設定全件検索
            status = this._iStockTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (StockTtlStWork wkStockTtlStWork in wkList)
                    {
                        retList.Add(CopyToStockTtlStFromStockTtlStWork(wkStockTtlStWork));
                    }
                }
            }

            return status;
        }

        // 2009.02.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入在庫全体設定検索処理
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        public int SearchOnlyStockTtlInfo(out ArrayList retList, string enterpriseCode)
        {
            return SearchOnlyStockTtlInfoProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        /// <summary>
        /// 仕入在庫全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        private int SearchOnlyStockTtlInfoProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            StockTtlStWork stockTtlStWork = new StockTtlStWork();
            stockTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = stockTtlStWork;
            object retobj = null;

            // 仕入在庫全体設定全件検索
            status = this._iStockTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (StockTtlStWork wkStockTtlStWork in wkList)
                    {
                        retList.Add(CopyToStockTtlStFromStockTtlStWork(wkStockTtlStWork));
                    }
                }
            }

            return status;
        }
        // 2009.02.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 仕入在庫全体設定論理削除処理
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int LogicalDelete(ref StockTtlSt stockTtlSt)
        {
            int status = 0;

            try
            {
                // 仕入在庫全体設定クラスを仕入在庫全体設定ワーククラスへメンバコピー
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // 論理削除
                //Object paraObj = (object)stockTtlStWork;
                //status = this._iStockTtlStDB.LogicalDelete(ref paraObj);
                status = this._iStockTtlStDB.LogicalDelete(ref parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 仕入在庫全体設定ワーククラスをデシリアライズ
                    stockTtlStWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));

                    // 仕入在庫全体設定ワーククラスを仕入在庫全体設定クラスにメンバコピー
                    //stockTtlStWork = paraObj as StockTtlStWork;
                    //stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                    stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 仕入在庫全体設定物理削除処理
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の物理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Delete(StockTtlSt stockTtlSt)
        {
            int status = 0;
            try
            {
                // 仕入在庫全体設定クラスを仕入在庫全体設定ワーククラスへメンバコピー
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);
                // XML変換し、文字列をバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // 仕入在庫全体設定物理削除
                status = this._iStockTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iStockTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 仕入在庫全体設定論理削除復活処理
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Revival(ref StockTtlSt stockTtlSt)
        {
            int status = 0;

            try
            {
                // 仕入在庫全体設定クラスを仕入在庫全体設定ワーククラスへメンバコピー
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // 復活
                //Object paraObj = (object)stockTtlStWork;
                //status = this._iStockTtlStDB.RevivalLogicalDelete(ref paraObj);
                status = this._iStockTtlStDB.RevivalLogicalDelete(ref parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 仕入在庫全体設定ワーククラスをデシリアライズ
                    stockTtlStWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));

                    // 仕入在庫全体設定ワーククラスを仕入在庫全体設定クラスにメンバコピー
                    //stockTtlStWork = paraObj as StockTtlStWork;
                    //stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                    stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 仕入在庫全体設定登録・更新処理
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体設定クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public int Write(ref StockTtlSt stockTtlSt)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //クラスからワーカークラスにメンバコピー
            StockTtlStWork stockttlsetWork = CopyToStockTtlStWorkFromStockTtlSt(stockttlset);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(stockttlsetWork);
            //object objStockKtlStWork = (object)stockttlsetWork;

            int status = 0;
            try
            {
                //書き込み
                status = this._iStockTtlStDB.Write(ref parabyte);
                //status = this._iStockTtlStDB.Write(ref objStockKtlStWork);
                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズする
                    stockttlsetWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));
                    //ArrayList stockttlsetWorkList = new ArrayList();
                    //stockttlsetWorkList = (ArrayList) objStockKtlStWork;
                    //stockttlsetWork = (StockTtlStWork)stockttlsetWorkList[0];
                    // クラス内メンバコピー
                    stockttlset = CopyToAutoliasetFromStockTtlStWork(stockttlsetWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iStockTtlStDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            int status = 0;

            try
            {
                // 仕入在庫全体設定クラスを仕入在庫全体設定ワーククラスへメンバコピー
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // 保存
                //Object paraObj = (object)stockTtlStWork;
                //status = this._iStockTtlStDB.Write(ref paraObj);
                status = this._iStockTtlStDB.Write(ref parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 仕入在庫全体設定ワーククラスをデシリアライズ
                    stockTtlStWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));

                    // 仕入在庫全体設定ワーククラスから仕入在庫全体設定クラスへメンバコピー
                    //ArrayList wklist = (ArrayList)paraObj;
                    //stockTtlStWork = wklist[0] as StockTtlStWork;
                    //stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);

                    stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 仕入在庫全体設定シリアライズ処理
        /// </summary>
        /// <param name="stockttlset">シリアライズ対象仕入在庫全体設定クラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定のシリアライズを行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public void Serialize(StockTtlSt stockttlset, string fileName)
        {
            //クラスからワーカークラスにメンバコピー
            StockTtlStWork stockttlWork = CopyToStockTtlStWorkFromStockTtlSt(stockttlset);
            //従ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(stockttlWork, fileName);
        }


        /// <summary>
        /// 仕入在庫全体設定Listシリアライズ処理
        /// </summary>
        /// <param name="stockttlsetList">シリアライズ対象仕入在庫全体設定Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定List情報のシリアライズを行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public void ListSerialize(ArrayList stockttlsetList, string fileName)
        {
            StockTtlStWork[] stockttlsetWorks = new StockTtlStWork[stockttlsetList.Count];
            for (int i = 0; i < stockttlsetList.Count; i++)
            {
                stockttlsetWorks[i] = CopyToStockTtlStWorkFromStockTtlSt((StockTtlSt)stockttlsetList[i]);
            }
            //仕入在庫全体設定ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(stockttlsetWorks, fileName);
        }

        /// <summary>
        /// クラスメンバーコピー処理（仕入在庫全体設定ワーククラス⇒仕入在庫全体設定クラス）
        /// </summary>
        /// <param name="stockTtlStWork">仕入在庫全体設定ワーククラス</param>
        /// <returns>仕入在庫全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定ワーククラスから仕入在庫全体設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// <br>-------------------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 検索条件「仕入価格取得単位区分」追加</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.06.12</br>
        /// </remarks>
        private StockTtlSt CopyToStockTtlStFromStockTtlStWork(StockTtlStWork stockTtlStWork)
        {
            StockTtlSt stockTtlSt = new StockTtlSt();

            //ファイルヘッダ部分
            stockTtlSt.CreateDateTime = stockTtlStWork.CreateDateTime;
            stockTtlSt.UpdateDateTime = stockTtlStWork.UpdateDateTime;
            stockTtlSt.EnterpriseCode = stockTtlStWork.EnterpriseCode;
            stockTtlSt.FileHeaderGuid = stockTtlStWork.FileHeaderGuid;
            stockTtlSt.UpdEmployeeCode = stockTtlStWork.UpdEmployeeCode;
            stockTtlSt.UpdAssemblyId1 = stockTtlStWork.UpdAssemblyId1;
            stockTtlSt.UpdAssemblyId2 = stockTtlStWork.UpdAssemblyId2;
            stockTtlSt.LogicalDeleteCode = stockTtlStWork.LogicalDeleteCode;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //データ部分
            stockTtlSt.StockAllStMngCd = stockTtlStWork.StockAllStMngCd;
            stockTtlSt.ValidDtConsTaxRate1 = stockTtlStWork.ValidDtConsTaxRate1;
            stockTtlSt.ConsTaxRate1 = stockTtlStWork.ConsTaxRate1;
            stockTtlSt.ValidDtConsTaxRate2 = stockTtlStWork.ValidDtConsTaxRate2;
            stockTtlSt.ConsTaxRate2 = stockTtlStWork.ConsTaxRate2;
            stockTtlSt.ValidDtConsTaxRate3 = stockTtlStWork.ValidDtConsTaxRate3;
            stockTtlSt.ConsTaxRate3 = stockTtlStWork.ConsTaxRate3;
               --- DEL 2008/06/06 --------------------------------<<<<< */
            
            //stockttlset.AutoEntryStockCd = stockttlsetWork.AutoEntryStockCd;
            //stockttlset.BeatStockCondCd = stockttlsetWork.BeatStockCondCd;
            stockTtlSt.StockDiscountName = stockTtlStWork.StockDiscountName;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            stockTtlSt.PartsUnitPrcZeroCd = stockTtlStWork.PartsUnitPrcZeroCd;
            // 2006.06.09 tsuchida add
            stockTtlSt.TotalAmountDispWayCd = stockTtlStWork.TotalAmountDispWayCd;
            stockTtlSt.SuppCTaxLayCd = stockTtlStWork.SuppCTaxLayCd;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            //2007.12.18 TACHIBANA ADD >>>>>>>>>>>>>>>>>>>>>>						
            stockTtlSt.RgdsSlipPrtDiv = stockTtlStWork.RgdsSlipPrtDiv;
            stockTtlSt.RgdsUnPrcPrtDiv = stockTtlStWork.RgdsUnPrcPrtDiv;
            stockTtlSt.RgdsZeroPrtDiv = stockTtlStWork.RgdsZeroPrtDiv;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //stockTtlSt.IoGoodsCntDiv = stockTtlStWork.IoGoodsCntDiv;
            //stockTtlSt.IoGoodsCntDiv2 = stockTtlStWork.IoGoodsCntDiv2;    // 2008.02.27 add
            //stockTtlSt.SupplierFormalIni = stockTtlStWork.SupplierFormalIni;
            //stockTtlSt.SalesSlipDtlConf = stockTtlStWork.SalesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            stockTtlSt.ListPriceInpDiv = stockTtlStWork.ListPriceInpDiv;
            stockTtlSt.UnitPriceInpDiv = stockTtlStWork.UnitPriceInpDiv;
            stockTtlSt.DtlNoteDispDiv = stockTtlStWork.DtlNoteDispDiv;
			//2007.12.18 TACHIBANA ADD <<<<<<<<<<<<<<<<<<<<<<						

			//----- ueno add ---------- start 2008.02.18
            stockTtlSt.AutoPayMoneyKindCode = stockTtlStWork.AutoPayMoneyKindCode;
            stockTtlSt.AutoPayMoneyKindName = stockTtlStWork.AutoPayMoneyKindName;
            stockTtlSt.AutoPayMoneyKindDiv = stockTtlStWork.AutoPayMoneyKindDiv;
			//----- ueno add ---------- end 2008.02.18

            // --- ADD 2008/06/06 -------------------------------->>>>>
            stockTtlSt.SectionCode = stockTtlStWork.SectionCode;
            stockTtlSt.AutoPayment = stockTtlStWork.AutoPayment;
            stockTtlSt.PriceCostUpdtDiv = stockTtlStWork.PriceCostUpdtDiv;
            stockTtlSt.AutoEntryGoodsDivCd = stockTtlStWork.AutoEntryGoodsDivCd;
            stockTtlSt.PriceCheckDivCd = stockTtlStWork.PriceCheckDivCd;
            stockTtlSt.StockUnitChgDivCd = stockTtlStWork.StockUnitChgDivCd;
            stockTtlSt.SectDspDivCd = stockTtlStWork.SectDspDivCd;
            stockTtlSt.SlipDateClrDivCd = stockTtlStWork.SlipDateClrDivCd;
            stockTtlSt.PaySlipDateClrDiv = stockTtlStWork.PaySlipDateClrDiv;
            stockTtlSt.PaySlipDateAmbit = stockTtlStWork.PaySlipDateAmbit;
            // --- ADD 2008/06/06 --------------------------------<<<<< 
            // --- ADD 2008/09/12 -------------------------------->>>>>
            stockTtlSt.StockSearchDiv = stockTtlStWork.StockSearchDiv;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            stockTtlSt.GoodsNmReDispDivCd = stockTtlStWork.GoodsNmReDispDivCd;
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END
            
            return stockTtlSt;
        }

        /// <summary>
        /// クラスメンバーコピー処理（仕入在庫全体設定クラス⇒仕入在庫全体設定ワーククラス）
        /// </summary>
        /// <param name="stockTtlSt">仕入在庫全体クラス</param>
        /// <returns>仕入在庫全体ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定クラスから仕入在庫全体設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// <br>-------------------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 検索条件「仕入価格取得単位区分」追加</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.06.12</br>
        /// </remarks>
        private StockTtlStWork CopyToStockTtlStWorkFromStockTtlSt(StockTtlSt stockTtlSt)
        {
            StockTtlStWork stockTtlStWork = new StockTtlStWork();

            //ファイルヘッダ部分
            stockTtlStWork.CreateDateTime = stockTtlSt.CreateDateTime;
            stockTtlStWork.UpdateDateTime = stockTtlSt.UpdateDateTime;
            stockTtlStWork.EnterpriseCode = stockTtlSt.EnterpriseCode;
            stockTtlStWork.FileHeaderGuid = stockTtlSt.FileHeaderGuid;
            stockTtlStWork.UpdEmployeeCode = stockTtlSt.UpdEmployeeCode;
            stockTtlStWork.UpdAssemblyId1 = stockTtlSt.UpdAssemblyId1;
            stockTtlStWork.UpdAssemblyId2 = stockTtlSt.UpdAssemblyId2;
            stockTtlStWork.LogicalDeleteCode = stockTtlSt.LogicalDeleteCode;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //データ部分
            stockTtlStWork.StockAllStMngCd = stockTtlSt.StockAllStMngCd;
            stockTtlStWork.ValidDtConsTaxRate1 = stockTtlSt.ValidDtConsTaxRate1;
            stockTtlStWork.ConsTaxRate1 = stockTtlSt.ConsTaxRate1;
            stockTtlStWork.ValidDtConsTaxRate2 = stockTtlSt.ValidDtConsTaxRate2;
            stockTtlStWork.ConsTaxRate2 = stockTtlSt.ConsTaxRate2;
            stockTtlStWork.ValidDtConsTaxRate3 = stockTtlSt.ValidDtConsTaxRate3;
            stockTtlStWork.ConsTaxRate3 = stockTtlSt.ConsTaxRate3;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            stockTtlStWork.StockDiscountName = stockTtlSt.StockDiscountName.TrimEnd();

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            stockTtlStWork.PartsUnitPrcZeroCd = stockTtlSt.PartsUnitPrcZeroCd;
            stockTtlStWork.TotalAmountDispWayCd = stockTtlSt.TotalAmountDispWayCd;
            stockTtlStWork.SuppCTaxLayCd = stockTtlSt.SuppCTaxLayCd;
               --- DEL 2008/06/06 --------------------------------<<<<< */
            
            //2007.12.18 TACHIBANA ADD >>>>>>>>>>>>>>>>>>>>>>						
            stockTtlStWork.RgdsSlipPrtDiv = stockTtlSt.RgdsSlipPrtDiv;
            stockTtlStWork.RgdsUnPrcPrtDiv = stockTtlSt.RgdsUnPrcPrtDiv;
            stockTtlStWork.RgdsZeroPrtDiv = stockTtlSt.RgdsZeroPrtDiv;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //stockTtlStWork.IoGoodsCntDiv = stockTtlSt.IoGoodsCntDiv;
            //stockTtlStWork.IoGoodsCntDiv2 = stockTtlSt.IoGoodsCntDiv2;   // 2008.02.27 add
            //stockTtlStWork.SupplierFormalIni = stockTtlSt.SupplierFormalIni;
            //stockTtlStWork.SalesSlipDtlConf = stockTtlSt.SalesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            stockTtlStWork.ListPriceInpDiv = stockTtlSt.ListPriceInpDiv;
            stockTtlStWork.UnitPriceInpDiv = stockTtlSt.UnitPriceInpDiv;
            stockTtlStWork.DtlNoteDispDiv = stockTtlSt.DtlNoteDispDiv;
			//2007.12.18 TACHIBANA ADD <<<<<<<<<<<<<<<<<<<<<<						

			//----- ueno add ---------- start 2008.02.18
            stockTtlStWork.AutoPayMoneyKindCode = stockTtlSt.AutoPayMoneyKindCode;
            stockTtlStWork.AutoPayMoneyKindName = stockTtlSt.AutoPayMoneyKindName;
            stockTtlStWork.AutoPayMoneyKindDiv = stockTtlSt.AutoPayMoneyKindDiv;
			//----- ueno add ---------- end 2008.02.18

            // --- ADD 2008/06/06 -------------------------------->>>>>
            stockTtlStWork.SectionCode = stockTtlSt.SectionCode;         
            stockTtlStWork.AutoPayment = stockTtlSt.AutoPayment;         
            stockTtlStWork.PriceCostUpdtDiv = stockTtlSt.PriceCostUpdtDiv;   
            stockTtlStWork.AutoEntryGoodsDivCd = stockTtlSt.AutoEntryGoodsDivCd; 
            stockTtlStWork.PriceCheckDivCd = stockTtlSt.PriceCheckDivCd;     
            stockTtlStWork.StockUnitChgDivCd = stockTtlSt.StockUnitChgDivCd;   
            stockTtlStWork.SectDspDivCd = stockTtlSt.SectDspDivCd;        
            stockTtlStWork.SlipDateClrDivCd = stockTtlSt.SlipDateClrDivCd;    
            stockTtlStWork.PaySlipDateClrDiv = stockTtlSt.PaySlipDateClrDiv;
            stockTtlStWork.PaySlipDateAmbit = stockTtlSt.PaySlipDateAmbit;    
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // --- ADD 2008/09/12 -------------------------------->>>>>
            stockTtlStWork.StockSearchDiv = stockTtlSt.StockSearchDiv;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 犬飼 項目追加 >>>>>>START
            stockTtlStWork.GoodsNmReDispDivCd = stockTtlSt.GoodsNmReDispDivCd;
            // 2009.04.02 30413 犬飼 項目追加 <<<<<<END

            return stockTtlStWork;
        }


        /// <summary>
        /// 対象データチェック
        /// </summary>
        /// <param name="stockttlset">対象データ</param>
        /// <param name="stockttlsetPara">パラメータ</param>
        /// <returns>チェック結果（true:OK false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 対象データとパラメータを比較します。</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        private bool checkTarGetData(StockTtlSt stockttlset, StockTtlSt stockttlsetPara)
        {
            // 企業コードを比較
            if (stockttlsetPara.EnterpriseCode != null)
            {
                if (!stockttlsetPara.EnterpriseCode.Equals(stockttlset.EnterpriseCode))
                    return false;
            }
            return true;
        }

    }
}
