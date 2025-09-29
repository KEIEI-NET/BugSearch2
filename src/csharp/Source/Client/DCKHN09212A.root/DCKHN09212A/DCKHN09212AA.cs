using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
	/// <summary>
	///  売上全体設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       :  売上全体設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30167 上野　弘貴</br>
	/// <br>Date       : 2007.12.06</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
	/// <br>Update Note: 2008.02.18 30167 上野　弘貴</br>
	/// <br>			 自動入金関連項目追加（金額種別区分マスタデータ取得）</br>
	/// <br>Update Note: 2008.02.26 30167 上野　弘貴</br>
	/// <br>			 項目追加（入出荷数区分２, 値引名称）</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/06/09</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/07/22、2008/08/25 項目削除の為、修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2008.12.01 Searchメソッドの追加</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.02.25 売上全体設定のみ取得するSearchメソッドの追加</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/19 朱俊成</br>
    /// <br>             PM.NS-3-A・保守依頼②</br>
    /// <br>             表示区分プロセスを追加</br>
    /// <br>Update Note: 2010/01/29 李侠</br>
    /// <br>             PM1003・四次改良</br>
    /// <br>             受注数入力を追加</br>																						
    /// <br>Update Note: 2010/05/04 王海立</br>
    /// <br>             PM1007・6次改良</br>
    /// <br>             発行者チェック区分、入力倉庫チェック区分を追加</br>
    /// <br>Update Note: 2010/04/30 姜凱</br>																						
    /// <br>             PM1007D・自由検索</br>																						
    /// <br>             自由検索部品自動登録区分を追加</br>
    /// <br>Update Note: 2010/05/14 工藤</br>
    /// <br>             品名表示対応：品名表示区分の詳細設定を追加</br>   
    /// <br></br>
    /// <br>Update Note: 2010/05/25 長内 数馬</br>
    /// <br>             オフライン対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/15 鈴木 正臣</br>
    /// <br>             成果物統合</br>
    /// <br>　　　　　　　　オフライン対応 2010/05/25 の組込</br>
    /// <br>Update Note: 2010/08/04 楊明俊</br>
    /// <br>             PM1012</br>
    /// <br>             小数点表示区分を追加</br>
    /// <br>Update Note: 2011/06/07 22008 長内数馬</br>
    /// <br>             販売区分表示区分を追加</br>
    /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫</br>
    /// <br>             貸出仕入区分を追加</br>
    /// <br>Update Note: 2012/12/27 脇田靖之</br>
    /// <br>             自社品番印字対応</br>
    /// <br>Update Note: 2013/01/15 FSI福原 一樹</br>
    /// <br>             仕入返品予定機能</br>
    /// <br>Update Note: 2013/01/16 脇田靖之</br>
    /// <br>             自社品番印字対応仕様変更対応</br>
    /// <br>Update Note: 2013/01/21 cheq</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33797 自動入金備考区分を追加</br>
    /// <br>Update Note: 2013/02/05 脇田靖之</br>
    /// <br>             ＢＬコード０対応</br>
    /// <br>Update Note  2017/04/13 譚洪</br>
    /// <br>             売上伝票入力画面の仕入担当者セット方法を変更</br>
    /// <br>             仕入担当参照区分の追加</br>
    /// </remarks>
	public class SalesTtlStAcs
	{
		#region << Private Members

		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ISalesTtlStDB _iSalesTtlStDB       = null;

		//----- ueno add ---------- start 2008.01.31
		private SalesTtlStLcDB _salesTtlStLcDB = null;

		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31

		/// <summary> 売上全体設定スタティックオブジェクト</summary>
		private static SalesTtlSt _salesTtlStStaticBuf = null;

		//----- ueno add ---------- start 2008.02.18
		// 金額種別設定マスタアクセスクラス
		private MoneyKindAcs _moneyKindAcs = null;

		// 金額種別区分マスタアクセスクラス
		private MnyKindDivAcs _mnyKindDivAcs = null;
		//----- ueno add ---------- end 2008.02.18

		#endregion

		#region << Constructor >>

		/// <summary>
		///  売上全体設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       :  売上全体設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public SalesTtlStAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iSalesTtlStDB = MediationSalesTtlStDB.GetSalesTtlStDB();

				//----- ueno add ---------- start 2008.02.18
				// 金額種別設定マスタアクセスクラス
				this._moneyKindAcs = new MoneyKindAcs();

				// 金額種別区分マスタアクセスクラス
				this._mnyKindDivAcs = new MnyKindDivAcs();
				//----- ueno add ---------- end 2008.02.18
			}
			catch( Exception )
			{
				// オフライン時はnullをセット
				this._iSalesTtlStDB = null;
			}

			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._salesTtlStLcDB = new SalesTtlStLcDB();
			//----- ueno add ---------- end 2008.01.31
		}

		#endregion

		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  プロパティ
		//================================================================================
		/// <summary>
		/// ローカルＤＢReadモード
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31

		#region << GetOnlineMode >>

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードの取得を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSalesTtlStDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

		//----- ueno add ---------- start 2008.02.18
		#region 自動入金金種区分コード取得処理
		/// <summary>
		///  自動入金金種区分コード取得処理
		/// </summary>
		/// <param name="autoDepoKindCode">自動入金金種コード</param>
		/// <returns>自動入金金種区分コード</returns>
		/// <remarks>
		/// <br>Note       : 金額種別区分コードを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public int GetAutoDepoKindDivCd(int autoDepoKindCode)
		{
			int autoDepoKindDivCd = 0;

			if (SalesTtlSt._autoDepoKindCodeList.ContainsKey(autoDepoKindCode) == true)
			{
				MoneyKind moneyKind = (MoneyKind)SalesTtlSt._autoDepoKindCodeList[autoDepoKindCode];
				autoDepoKindDivCd = moneyKind.MoneyKindDiv;	// 金額種別区分設定
			}
			return autoDepoKindDivCd;
		}
		#endregion

		#region 自動入金金種名称取得処理
		/// <summary>
		///  自動入金金種名称取得処理
		/// </summary>
		/// <param name="autoDepoKindCode">自動入金金種コード</param>
		/// <returns>自動入金金種名称</returns>
		/// <remarks>
		/// <br>Note       : 自動入金金種名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public string GetAutoDepoKindName(int autoDepoKindCode)
		{
			string autoDepoKindName = "";

			if (SalesTtlSt._autoDepoKindCodeList.ContainsKey(autoDepoKindCode) == true)
			{
				MoneyKind moneyKind = (MoneyKind)SalesTtlSt._autoDepoKindCodeList[autoDepoKindCode];
				autoDepoKindName = moneyKind.MoneyKindName;	// 金種名称設定
			}
			return autoDepoKindName;
		}
		#endregion
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// 売上全体設定読み込み処理（通常）
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        //public int Read( out SalesTtlSt salesTtlSt, string enterpriseCode )  // UPD 2008/08/25
        public int Read(out SalesTtlSt salesTtlSt, string enterpriseCode, string sectionCode)      // UPD 2008/08/25
		{
			int status = 0;

			salesTtlSt = null;

            // オンラインの場合
            // -- UPD 2010/05/25 ------------------------->>>
            //if( LoginInfoAcquisition.OnlineFlag == true ) {
            //    // リモートから取得
            //    //status = this.ReadProc( out salesTtlSt, enterpriseCode );  // UPD 2008/08/25
            //    status = this.ReadProc(out salesTtlSt, enterpriseCode, sectionCode);          // UPD 2008/08/25
            //}
            //// オフラインの場合
            //else {
            //    status = this.ReadOfflineProc(out SalesTtlStAcs._salesTtlStStaticBuf, enterpriseCode);
            //}

            status = this.ReadProc( out salesTtlSt, enterpriseCode, sectionCode );          // UPD 2008/08/25
            // -- UPD 2010/05/25 -------------------------<<<

			return status;
		}

        /// <summary>
        /// 売上全体設定読み込み処理（スタティックデータ取得）
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        //public int ReadStatic( out SalesTtlSt salesTtlSt, string enterpriseCode )  // DEL 2008/08/25
        public int ReadStatic(out SalesTtlSt salesTtlSt, string enterpriseCode, string sectionCode)      // ADD 2008/08/25
		{
			int status = 0;

			salesTtlSt = null;

			try {
				if (SalesTtlStAcs._salesTtlStStaticBuf == null)
				{
                    // オンラインの場合
                    // -- UPD 2010/05/25 --------------------------->>>
                    //if( LoginInfoAcquisition.OnlineFlag == true ) {
                    //    // リモートから取得
                    //    //status = this.ReadProc(out SalesTtlStAcs._salesTtlStStaticBuf, enterpriseCode); // UPD 2008/08/25
                    //    status = this.ReadProc(out SalesTtlStAcs._salesTtlStStaticBuf, enterpriseCode, sectionCode); // UPD 2008/08/25
                    //}
                    //// オフラインの場合
                    //else {
                    //    status = this.ReadOfflineProc(out SalesTtlStAcs._salesTtlStStaticBuf, enterpriseCode);
                    //}

                    status = this.ReadProc( out SalesTtlStAcs._salesTtlStStaticBuf, enterpriseCode, sectionCode );
                    // -- UPD 2010/05/25 ---------------------------<<<

					switch( status ) {
						case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							break;
						}
						case ( int )ConstantManagement.DB_Status.ctDB_EOF:
						case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						{
							break;
						}
						default:
						{
							return status;
						}
					}
				}

				if (SalesTtlStAcs._salesTtlStStaticBuf != null)
				{
					salesTtlSt = SalesTtlStAcs._salesTtlStStaticBuf.Clone();
				}
				else {
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch( Exception ) {
				status = -1;
			}

			return status;
		}

        /// <summary>
        /// 売上全体設定読み込み処理（メイン）
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        //private int ReadProc( out SalesTtlSt salesTtlSt, string enterpriseCode )  // UPD 2008/08/25
        private int ReadProc(out SalesTtlSt salesTtlSt, string enterpriseCode, string sectionCode)      // UPD 2008/08/25
		{
			int status = 0;

			try {

				//----- ueno add ---------- start 2008.02.18
				// 金額種別設定データ取得設定
				SetMoneyKindList(enterpriseCode);

				// 金額種別区分データ取得設定
				SetMnyKindDivList();
				//----- ueno add ---------- end 2008.02.18
				
				salesTtlSt = null;

				// キー情報をセット
				SalesTtlStWork salesTtlStWork  = new SalesTtlStWork();
                salesTtlStWork.EnterpriseCode = enterpriseCode;    // 企業コード
                salesTtlStWork.SectionCode = sectionCode;          // 拠点コード // ADD 2008/08/25

				//----- ueno upd ---------- start 2008.01.31
				// ローカル
				if (_isLocalDBRead)
				{
					status = this._salesTtlStLcDB.Read(ref salesTtlStWork, 0);
				}
				// リモート
				else
				{
					// XMLシリアライズ
					byte[] parabyte = XmlByteSerializer.Serialize( salesTtlStWork );

					// 読み込み
					status = this._iSalesTtlStDB.Read(ref parabyte, 0);

					if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
					{
						// デシリアライズしてワーククラスを取得
						salesTtlStWork = (SalesTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalesTtlStWork));

						//// 結果をメンバコピー
						//salesTtlSt = this.CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 結果をメンバコピー
					salesTtlSt = this.CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
				}
				//----- ueno upd ---------- end 2008.01.31
			}
			catch( Exception )
			{
				// オフライン時はnullをセット
				salesTtlSt = null;
				this._iSalesTtlStDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		//----- ueno add ---------- start 2008.02.18
		/// <summary>
		///  金額種別設定データ設定処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定データの取得を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public int SetMoneyKindList(string enterpriseCode)
		{
			if (SalesTtlSt._autoDepoKindCodeList == null)
			{
				SalesTtlSt._autoDepoKindCodeList = new SortedList();
			}
			
			// ローカルＤＢフラグ設定
			this._moneyKindAcs.IsLocalDBRead = this.IsLocalDBRead;
			
			ArrayList wkMoneyKindList = null;				// 全ての金額種別設定リスト
			int status = this._moneyKindAcs.Search(out wkMoneyKindList, enterpriseCode);
			
			if(status == 0)
			{
				foreach(MoneyKind moneyKind in wkMoneyKindList)
				{
					// 金種設定区分が"入金"のデータのみ設定する
					if(moneyKind.PriceStCode == 0)
					{
						if (SalesTtlSt._autoDepoKindCodeList.ContainsKey(moneyKind.MoneyKindCode) == false)
						{
							// key:金種コード, value:金額種別設定オブジェクト
							SalesTtlSt._autoDepoKindCodeList.Add(moneyKind.MoneyKindCode, moneyKind);
						}
					}
				}
			}
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
		public int SetMnyKindDivList()
		{
			if(SalesTtlSt._mnyKindDivList == null)
			{
				SalesTtlSt._mnyKindDivList = new SortedList();
			}
			
			ArrayList mnyKindDivList = null;
			this._mnyKindDivAcs.Search(out mnyKindDivList);

			foreach (MnyKindDiv mnyKindDiv in mnyKindDivList)
			{
				if (SalesTtlSt._mnyKindDivList.ContainsKey(mnyKindDiv.MoneyKindDiv) == false)
				{
					SalesTtlSt._mnyKindDivList.Add(mnyKindDiv.MoneyKindDiv, mnyKindDiv.MoneyKindDivName);
				}
			}
			return 0;
		}
		//----- ueno add ---------- end 2008.02.18

		/// <summary>
		///  売上全体設定読み込み処理 (オフライン)
		/// </summary>
		/// <param name="salesTtlSt"> 売上全体設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       :  売上全体設定の読み込みを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private int ReadOfflineProc( out SalesTtlSt salesTtlSt, string enterpriseCode )
		{
			int status = 0;

			salesTtlSt = null;

			try {
				status = this.LoadOfflineData( enterpriseCode );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if (SalesTtlStAcs._salesTtlStStaticBuf != null)
					{
						salesTtlSt = SalesTtlStAcs._salesTtlStStaticBuf.Clone();
					}
					else {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
				}
			}
			catch( Exception ) {
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 書き込み処理
		/// </summary>
		/// <param name="salesTtlSt"> 売上全体設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       :  売上全体設定オブジェクトの書き込みを行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
		/// </remarks>
		public int Write( ref SalesTtlSt salesTtlSt )
		{
            int status = 0;

            try
            {
                // 見積初期値設定クラスを見積初期値設定ワーククラスへメンバコピー
                SalesTtlStWork salesTtlStWork = CopyToSalesTtlStWorkFromSalesTtlSt(salesTtlSt);

                // 保存
                Object paraObj = (object)salesTtlStWork;
                status = this._iSalesTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 見積初期値設定ワーククラスから見積初期値設定クラスへメンバコピー
                    ArrayList wklist = (ArrayList)paraObj;
                    salesTtlStWork = wklist[0] as SalesTtlStWork;
                    salesTtlSt = CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
		}

        /* --- DEL 2008/06/09 -------------------------------->>>>>
        /// <summary>
        /// 書き込み処理 (メイン)
        /// </summary>
        /// <param name="salesTtlSt"> 売上全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  売上全体設定オブジェクトの書き込みを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        private int WriteProc( ref SalesTtlSt salesTtlSt )
        {
            int status = 0;

            try
            {
                SalesTtlStWork salesTtlStWork = this.CopyToSalesTtlStWorkFromSalesTtlSt( salesTtlSt );

                object paraObj = salesTtlStWork;
				
                // 書き込み
                status = this._iSalesTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    salesTtlStWork = paraObj as SalesTtlStWork;

                    if (salesTtlStWork != null)
                    {
                        // 結果をメンバコピー
                        salesTtlSt = this.CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
                    }
                }
            }
            catch( Exception )
            {
                // オフライン時はnullをセット
                this._iSalesTtlStDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }
           --- DEL 2008/06/09 --------------------------------<<<<< */

        // 2008.12.01 Add >>>
        /// <summary>
        /// 売上全体設定検索処理(論理削除データは除外)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の検索処理を行います。論理削除データは抽出されません。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2008.12.01 Add <<<

        /// <summary>
        /// 売上全体設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// 売上全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の検索処理を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            // 金額種別設定データ取得設定
            SetMoneyKindList(enterpriseCode);

            // 金額種別区分データ取得設定
            SetMnyKindDivList();

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = salesTtlStWork;
            object retobj = null;

             // 売上全体設定全件検索
            status = this._iSalesTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (SalesTtlStWork wkSalesTtlStWork in wkList)
                    {
                        retList.Add(CopyToSalesTtlStFromSalesTtlStWork(wkSalesTtlStWork));
                    }
                }
            }

            return status;
        }

        // 2009.02.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 売上全体設定検索処理(論理削除データは除外、売上全体設定情報のみ取得)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>売上全体設定情報の取得のみを行い、余計なセット等は行わない</remarks>
        public int SearchOnlySalesTtlInfo(out ArrayList retList, string enterpriseCode)
        {
            return SearchOnlySalesTtlInfoProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        /// 売上全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>売上全体設定情報の取得のみを行い、余計なセット等は行わない</remarks>
        private int SearchOnlySalesTtlInfoProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = salesTtlStWork;
            object retobj = null;

            // 売上全体設定全件検索
            status = this._iSalesTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (SalesTtlStWork wkSalesTtlStWork in wkList)
                    {
                        retList.Add(CopyToSalesTtlStFromSalesTtlStWork(wkSalesTtlStWork));
                    }
                }
            }

            return status;
        }
        // 2009.02.25  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 売上全体設定論理削除処理
        /// </summary>
        /// <param name="estimateDefSet">売上全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public int LogicalDelete(ref SalesTtlSt salesTtlSt)
        {
            int status = 0;

            try
            {
                //  売上全体設定クラスを 売上全体設定ワーククラスへメンバコピー
                SalesTtlStWork salesTtlStWork = CopyToSalesTtlStWorkFromSalesTtlSt(salesTtlSt);

                // 論理削除
                Object paraObj = (object)salesTtlStWork;
                status = this._iSalesTtlStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //  売上全体設定ワーククラスを 売上全体設定クラスにメンバコピー
                    salesTtlStWork = paraObj as SalesTtlStWork;
                    salesTtlSt = CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 売上全体設定物理削除処理
        /// </summary>
        /// <param name="estimateDefSet">売上全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の物理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public int Delete(SalesTtlSt salesTtlSt)
        {
            int status = 0;
            try
            {
                // 売上全体設定クラスを売上全体設定ワーククラスへメンバコピー
                SalesTtlStWork salesTtlStWork = CopyToSalesTtlStWorkFromSalesTtlSt(salesTtlSt);
                // XML変換し、文字列をバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(salesTtlStWork);

                // 売上全体設定物理削除
                status = this._iSalesTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iSalesTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 売上全体設定論理削除復活処理
        /// </summary>
        /// <param name="estimateDefSet">売上全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        public int Revival(ref SalesTtlSt salesTtlSt)
        {
            int status = 0;

            try
            {
                // 売上全体設定クラスを売上全体設定ワーククラスへメンバコピー
                SalesTtlStWork salesTtlStWork = CopyToSalesTtlStWorkFromSalesTtlSt(salesTtlSt);

                // 復活
                Object paraObj = (object)salesTtlStWork;
                status = this._iSalesTtlStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上全体設定ワーククラスを売上全体設定クラスにメンバコピー
                    salesTtlStWork = paraObj as SalesTtlStWork;
                    salesTtlSt = CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

		#region << オフライン保存関連 >>

        // --- DEL 2008/08/25 -------------------------------->>>>>
        ///// <summary>
        ///// オフラインデータの書き込み
        ///// </summary>
        ///// <param name="sender">object</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : static な領域に保持されたデータをローカルファイルに書き込みます。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2007.12.06</br>
        ///// </remarks>
        //public int WriteOfflineData( object sender )
        //{
        //    int status = 0;
        //    string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        //    try
        //    {
        //        // 保存用データ取得
        //        SalesTtlSt salesTtlSt = null;
        //        status = this.ReadStatic( out salesTtlSt, enterpriseCode );
        //        if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
        //        {
        //            SalesTtlStWork salesTtlStWork = this.CopyToSalesTtlStWorkFromSalesTtlSt( salesTtlSt );

        //            // オフライン保存オブジェクト
        //            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

        //            // キーを設定
        //            string[] keyList	= new string[ 2 ];
        //            keyList[ 0 ]		= enterpriseCode.TrimEnd();    // 企業コード
        //            keyList[ 1 ]		= "0";                         // 表示名称管理No (0固定)

        //            // オフラインデータを書き込み
        //            status = offlineDataSerializer.Serialize( "SalesTtlStAcs", keyList, salesTtlStWork );
        //        }
        //    }
        //    catch( Exception )
        //    {
        //        status = -1;
        //    }

        //    return status;
        //}
        // --- DEL 2008/08/25 --------------------------------<<<<< 

		/// <summary>
		/// ローカルファイルデータロード処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ローカルファイルのデータをロードし、static な領域に格納します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private int LoadOfflineData( string enterpriseCode )
		{
			int status = 0;

			try {
				// オフライン保存オブジェクト
				OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

				// キーを設定
				string[] keyList	= new string[ 1 ];
				keyList[ 0 ]		= enterpriseCode.TrimEnd();    // 企業コード
				keyList[ 1 ]		= "0";                         // 表示名称管理No (0固定)

				// ローカルファイルから読込
				object retobj = offlineDataSerializer.DeSerialize( "SalesTtlStAcs", keyList );

				SalesTtlStWork salesTtlStWork = retobj as SalesTtlStWork;
				if( salesTtlStWork != null )
				{
					SalesTtlStAcs._salesTtlStStaticBuf = this.CopyToSalesTtlStFromSalesTtlStWork(salesTtlStWork);
				}
				else
				{
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch( Exception )
			{
				status = -1;
			}

			return status;
		}

		#endregion

		#region << Class Member Copy Methods >>

		/// <summary>
		/// クラスメンバコピー処理（ 売上全体設定クラス→ 売上全体設定ワーククラス）
		/// </summary>
		/// <param name="salesTtlSt">全 売上全体設定クラス</param>
		/// <returns>全 売上全体設定ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : 全 売上全体設定クラスから全 売上全体設定ワーククラスへメンバコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/07 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		private SalesTtlStWork CopyToSalesTtlStWorkFromSalesTtlSt(SalesTtlSt salesTtlSt)
		{
			SalesTtlStWork salesTtlStWork = new SalesTtlStWork();

			salesTtlStWork.CreateDateTime		= salesTtlSt.CreateDateTime;		// 作成日時
			salesTtlStWork.UpdateDateTime		= salesTtlSt.UpdateDateTime;		// 更新日時
			salesTtlStWork.EnterpriseCode		= salesTtlSt.EnterpriseCode;		// 企業コード
			salesTtlStWork.FileHeaderGuid		= salesTtlSt.FileHeaderGuid;		// GUID
			salesTtlStWork.UpdEmployeeCode		= salesTtlSt.UpdEmployeeCode;		// 更新従業員コード
			salesTtlStWork.UpdAssemblyId1		= salesTtlSt.UpdAssemblyId1;		// 更新アセンブリID1
			salesTtlStWork.UpdAssemblyId2		= salesTtlSt.UpdAssemblyId2;		// 更新アセンブリID2
			salesTtlStWork.LogicalDeleteCode	= salesTtlSt.LogicalDeleteCode;		// 論理削除区分
			salesTtlStWork.SalesSlipPrtDiv		= salesTtlSt.SalesSlipPrtDiv;		// 売上伝票発行区分
			salesTtlStWork.ShipmSlipPrtDiv		= salesTtlSt.ShipmSlipPrtDiv;		// 出荷伝票発行区分
			//salesTtlStWork.ZeroPrtDiv			= salesTtlSt.ZeroPrtDiv;			// ゼロ円印刷区分       // DEL 2008/07/22
			salesTtlStWork.ShipmSlipUnPrcPrtDiv	= salesTtlSt.ShipmSlipUnPrcPrtDiv;	// 出荷伝票単価印刷区分

            // --- DEL 2008/07/16 -------------------------------->>>>>
            ////salesTtlStWork.IoGoodsCntDiv		= salesTtlSt.IoGoodsCntDiv;			// 入荷数区分
            ////----- ueno add ---------- start 2008.02.26
            //salesTtlStWork.IoGoodsCntDiv2		= salesTtlSt.IoGoodsCntDiv2;		// 入荷数区分２
            ////----- ueno add ---------- end 2008.02.26
            //salesTtlStWork.SalesFormalIn		= salesTtlSt.SalesFormalIn;			// 売上形式初期値
            //salesTtlStWork.StockDetailConf		= salesTtlSt.StockDetailConf;		// 仕入明細確認
            // --- DEL 2008/07/16 --------------------------------<<<<< 

			salesTtlStWork.GrsProfitCheckLower	= salesTtlSt.GrsProfitCheckLower;	// 粗利チェック下限
			salesTtlStWork.GrsProfitCheckBest	= salesTtlSt.GrsProfitCheckBest;	// 粗利チェック適正
			salesTtlStWork.GrsProfitCheckUpper	= salesTtlSt.GrsProfitCheckUpper;	// 粗利チェック上限
			salesTtlStWork.GrsProfitChkLowSign	= salesTtlSt.GrsProfitChkLowSign;	// 粗利下限記号
			salesTtlStWork.GrsProfitChkBestSign	= salesTtlSt.GrsProfitChkBestSign;	// 粗利適正記号
			salesTtlStWork.GrsProfitChkUprSign	= salesTtlSt.GrsProfitChkUprSign;	// 粗利上限記号
			salesTtlStWork.GrsProfitChkMaxSign	= salesTtlSt.GrsProfitChkMaxSign;	// 粗利最大記号
			salesTtlStWork.SalesAgentChngDiv	= salesTtlSt.SalesAgentChngDiv;		// 売上担当変更区分
			salesTtlStWork.AcpOdrAgentDispDiv	= salesTtlSt.AcpOdrAgentDispDiv;	// 受注者表示区分
			salesTtlStWork.BrSlipNote2DispDiv	= salesTtlSt.BrSlipNote2DispDiv;	// 伝票備考２表示区分
			salesTtlStWork.DtlNoteDispDiv		= salesTtlSt.DtlNoteDispDiv;		// 明細備考表示区分
			salesTtlStWork.UnPrcNonSettingDiv	= salesTtlSt.UnPrcNonSettingDiv;	// 売価未設定区分
			salesTtlStWork.AcpOdrrAddUpRemDiv	= salesTtlSt.AcpOdrrAddUpRemDiv;	// 受注データ計上残区分
			salesTtlStWork.ShipmAddUpRemDiv		= salesTtlSt.ShipmAddUpRemDiv;		// 出荷データ計上残区分
			salesTtlStWork.RetGoodsStockEtyDiv	= salesTtlSt.RetGoodsStockEtyDiv;	// 返品時在庫登録区分
			salesTtlStWork.ListPriceSelectDiv	= salesTtlSt.ListPriceSelectDiv;	// 定価選択区分
			salesTtlStWork.MakerInpDiv			= salesTtlSt.MakerInpDiv;			// メーカー入力区分
			salesTtlStWork.BLGoodsCdInpDiv		= salesTtlSt.BLGoodsCdInpDiv;		// BL商品コード入力区分
			salesTtlStWork.SupplierInpDiv		= salesTtlSt.SupplierInpDiv;		// 仕入先入力区分
			salesTtlStWork.SupplierSlipDelDiv	= salesTtlSt.SupplierSlipDelDiv;	// 仕入伝票削除区分
			salesTtlStWork.CustGuideDispDiv		= salesTtlSt.CustGuideDispDiv;		// 得意先ガイド初期表示区分
			salesTtlStWork.SlipChngDivDate		= salesTtlSt.SlipChngDivDate;		// 伝票修正区分（日付）
			salesTtlStWork.SlipChngDivCost		= salesTtlSt.SlipChngDivCost;		// 伝票修正区分（原価）
			salesTtlStWork.SlipChngDivUnPrc		= salesTtlSt.SlipChngDivUnPrc;		// 伝票修正区分（売価）
			salesTtlStWork.SlipChngDivLPrice	= salesTtlSt.SlipChngDivLPrice;		// 伝票修正区分（定価）

            // 2008.12.11 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
            salesTtlStWork.RetSlipChngDivCost = salesTtlSt.RetSlipChngDivCost;      // 返品伝票修正区分（原価）
            salesTtlStWork.RetSlipChngDivUnPrc = salesTtlSt.RetSlipChngDivUnPrc;    // 返品伝票修正区分（売価）
            // 2008.12.11 30413 犬飼 返品伝票修正区分の追加 <<<<<<END

			//----- ueno add ---------- start 2008.02.18
			salesTtlStWork.AutoDepoKindCode		= salesTtlSt.AutoDepoKindCode;		// 自動入金金種コード
			salesTtlStWork.AutoDepoKindName		= salesTtlSt.AutoDepoKindName;		// 自動金種区分名称
			salesTtlStWork.AutoDepoKindDivCd	= salesTtlSt.AutoDepoKindDivCd;		// 自動入金金種区分
			//----- ueno add ---------- end 2008.02.18
			//----- ueno add ---------- start 2008.02.26
			salesTtlStWork.DiscountName			= salesTtlSt.DiscountName;			// 値引名称
			//----- ueno add ---------- end 2008.02.26

            // --- ADD 2008/06/09 -------------------------------->>>>>
            salesTtlStWork.SectionCode          = salesTtlSt.SectionCode;           // 拠点コード        
            salesTtlStWork.EstmateAddUpRemDiv   = salesTtlSt.EstmateAddUpRemDiv;    // 見積データ計上残区分
            salesTtlStWork.InpAgentDispDiv      = salesTtlSt.InpAgentDispDiv;       // 発行者表示区分
            salesTtlStWork.CustOrderNoDispDiv   = salesTtlSt.CustOrderNoDispDiv;    // 得意先注番表示区分
            salesTtlStWork.CarMngNoDispDiv      = salesTtlSt.CarMngNoDispDiv;       // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>>
            salesTtlStWork.PriceSelectDispDiv   = salesTtlSt.PriceSelectDispDiv;    // 表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<
            salesTtlStWork.AcpOdrInputDiv       = salesTtlSt.AcpOdrInputDiv;        // ADD 2010/01/29 受注数入力を追加
            salesTtlStWork.InpAgentChkDiv       = salesTtlSt.InpAgentChkDiv;        // ADD 2010/05/04 発行者チェック区分を追加
            salesTtlStWork.InpWarehChkDiv       = salesTtlSt.InpWarehChkDiv;        // ADD 2010/05/04 入力倉庫チェック区分を追加
            salesTtlStWork.BrSlipNote3DispDiv   = salesTtlSt.BrSlipNote3DispDiv;    // 伝票備考３表示区分
            salesTtlStWork.SlipDateClrDivCd     = salesTtlSt.SlipDateClrDivCd;      // 伝票日付クリア区分
            salesTtlStWork.AutoEntryGoodsDivCd  = salesTtlSt.AutoEntryGoodsDivCd;   // 商品自動登録
            salesTtlStWork.CostCheckDivCd       = salesTtlSt.CostCheckDivCd;        // 原価チェック区分
            salesTtlStWork.JoinInitDispDiv      = salesTtlSt.JoinInitDispDiv;       // 結合初期表示区分
            salesTtlStWork.AutoDepositCd        = salesTtlSt.AutoDepositCd;         // 自動入金区分
            salesTtlStWork.SubstCondDivCd       = salesTtlSt.SubstCondDivCd;        // 代替条件区分
            salesTtlStWork.SlipCreateProcess    = salesTtlSt.SlipCreateProcess;     // 伝票作成方法
            salesTtlStWork.WarehouseChkDiv      = salesTtlSt.WarehouseChkDiv;       // 倉庫チェック区分
            salesTtlStWork.PartsSearchDivCd     = salesTtlSt.PartsSearchDivCd;      // 部品検索区分
            salesTtlStWork.GrsProfitDspCd       = salesTtlSt.GrsProfitDspCd;        // 粗利表示区分
            salesTtlStWork.PartsSearchPriDivCd  = salesTtlSt.PartsSearchPriDivCd;   // 部品検索優先順区分
            salesTtlStWork.SalesStockDiv        = salesTtlSt.SalesStockDiv;         // 売上仕入区分
            salesTtlStWork.PrtBLGoodsCodeDiv    = salesTtlSt.PrtBLGoodsCodeDiv;     // 印刷用BL商品コード区分
            salesTtlStWork.SectDspDivCd         = salesTtlSt.SectDspDivCd;          // 拠点表示区分
            salesTtlStWork.GoodsNmReDispDivCd   = salesTtlSt.GoodsNmReDispDivCd;    // 商品名再表示区分
            salesTtlStWork.CostDspDivCd         = salesTtlSt.CostDspDivCd;          // 原価表示区分
            salesTtlStWork.DepoSlipDateClrDiv   = salesTtlSt.DepoSlipDateClrDiv;    // 入金伝票日付クリア区分
            salesTtlStWork.DepoSlipDateAmbit    = salesTtlSt.DepoSlipDateAmbit;     // 入金伝票日付範囲区分
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            // --- ADD 2008/07/22 -------------------------------->>>>>
            salesTtlStWork.InpGrsProfChkLower = salesTtlSt.InpGrsProfChkLower;      // 入力粗利チェック下限
            salesTtlStWork.InpGrsProfChkUpper = salesTtlSt.InpGrsProfChkUpper;      // 入力粗利チェック上限
            salesTtlStWork.InpGrsPrfChkLowDiv = salesTtlSt.InpGrsProfChkLowDiv;     // 入力粗利チェック下限区分
            salesTtlStWork.InpGrsPrfChkUppDiv = salesTtlSt.InpGrsProfChkUppDiv;     // 入力粗利チェック上限区分
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            salesTtlStWork.PrmSubstCondDivCd= salesTtlSt.PrmSubstCondDivCd;         // 優良代替条件区分
            salesTtlStWork.SubstApplyDivCd  = salesTtlSt.SubstApplyDivCd;           // 代替適用区分
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            salesTtlStWork.PartsNameDspDivCd = salesTtlSt.PartsNameDspDivCd;        // 品名表示区分
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<
            salesTtlStWork.BLGoodsCdDerivNoDiv = salesTtlSt.BLGoodsCdDerivNoDiv;    // BLコード枝番

            // --- ADD 2010/04/30-------------------------------->>>>>
            salesTtlStWork.FrSrchPrtAutoEntDiv = salesTtlSt.FrSrchPrtAutoEntDiv;    // 自由検索部品自動登録区分
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            salesTtlStWork.BLCdPrtsNmDspDivCd1 = salesTtlSt.BLCdPrtsNmDspDivCd1;    // BLコード検索品名表示区分１
            salesTtlStWork.BLCdPrtsNmDspDivCd2 = salesTtlSt.BLCdPrtsNmDspDivCd2;    // BLコード検索品名表示区分２
            salesTtlStWork.BLCdPrtsNmDspDivCd3 = salesTtlSt.BLCdPrtsNmDspDivCd3;    // BLコード検索品名表示区分３
            salesTtlStWork.BLCdPrtsNmDspDivCd4 = salesTtlSt.BLCdPrtsNmDspDivCd4;    // BLコード検索品名表示区分４
            salesTtlStWork.GdNoPrtsNmDspDivCd1 = salesTtlSt.GdNoPrtsNmDspDivCd1;    // 品番検索品名表示区分１
            salesTtlStWork.GdNoPrtsNmDspDivCd2 = salesTtlSt.GdNoPrtsNmDspDivCd2;    // 品番検索品名表示区分２
            salesTtlStWork.GdNoPrtsNmDspDivCd3 = salesTtlSt.GdNoPrtsNmDspDivCd3;    // 品番検索品名表示区分３
            salesTtlStWork.GdNoPrtsNmDspDivCd4 = salesTtlSt.GdNoPrtsNmDspDivCd4;    // 品番検索品名表示区分４
            salesTtlStWork.PrmPrtsNmUseDivCd = salesTtlSt.PrmPrtsNmUseDivCd;        // 優良部品検索品名使用区分
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            salesTtlStWork.DwnPLCdSpDivCd = salesTtlSt.DwnPLCdSpDivCd;    // 小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            salesTtlStWork.SalesCdDspDivCd = salesTtlSt.SalesCdDspDivCd;    // 販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            salesTtlStWork.RentStockDiv = salesTtlSt.RentStockDiv;    // 貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            salesTtlStWork.EpPartsNoPrtCd = salesTtlSt.EpPartsNoPrtCd;          // 自社品番印字区分
            salesTtlStWork.EpPartsNoAddChar = salesTtlSt.EpPartsNoAddChar;      // 自社品番付加文字
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            salesTtlStWork.PrintGoodsNoDef = salesTtlSt.PrintGoodsNoDef;        // 印字品番初期値
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
	        // --- ADD 2013/01/15 ---------->>>>>
            salesTtlStWork.StockRetGoodsPlnDiv = salesTtlSt.StockRetGoodsPlnDiv; // 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<
            salesTtlStWork.AutoDepositNoteDiv = salesTtlSt.AutoDepositNoteDiv;  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            salesTtlStWork.BLGoodsCdZeroSuprt = salesTtlSt.BLGoodsCdZeroSuprt;  // BLコード０対応
            salesTtlStWork.BLGoodsCdChange = salesTtlSt.BLGoodsCdChange;        // 変換コード
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            salesTtlStWork.StockEmpRefDiv = salesTtlSt.StockEmpRefDiv;        // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

			return salesTtlStWork;
		}

		/// <summary>
		/// クラスメンバコピー処理（ 売上全体設定ワーククラス→ 売上全体設定クラス）
		/// </summary>
		/// <param name="salesTtlStWork">全 売上全体設定ワーククラス</param>
		/// <returns>全 売上全体設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 全 売上全体設定ワーククラスから全 売上全体設定クラスへメンバコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		private SalesTtlSt CopyToSalesTtlStFromSalesTtlStWork(SalesTtlStWork salesTtlStWork)
		{
			SalesTtlSt salesTtlSt = new SalesTtlSt();

			salesTtlSt.CreateDateTime		= salesTtlStWork.CreateDateTime;		// 作成日時
			salesTtlSt.UpdateDateTime		= salesTtlStWork.UpdateDateTime;		// 更新日時
			salesTtlSt.EnterpriseCode		= salesTtlStWork.EnterpriseCode;		// 企業コード
			salesTtlSt.FileHeaderGuid		= salesTtlStWork.FileHeaderGuid;		// GUID
			salesTtlSt.UpdEmployeeCode		= salesTtlStWork.UpdEmployeeCode;		// 更新従業員コード
			salesTtlSt.UpdAssemblyId1		= salesTtlStWork.UpdAssemblyId1;		// 更新アセンブリID1
			salesTtlSt.UpdAssemblyId2		= salesTtlStWork.UpdAssemblyId2;		// 更新アセンブリID2
			salesTtlSt.LogicalDeleteCode	= salesTtlStWork.LogicalDeleteCode;		// 論理削除区分
			salesTtlSt.SalesSlipPrtDiv		= salesTtlStWork.SalesSlipPrtDiv;		// 売上伝票発行区分
			salesTtlSt.ShipmSlipPrtDiv		= salesTtlStWork.ShipmSlipPrtDiv;		// 出荷伝票発行区分
			//salesTtlSt.ZeroPrtDiv			= salesTtlStWork.ZeroPrtDiv;			// ゼロ円印刷区分        // DEL 2008/07/22
			salesTtlSt.ShipmSlipUnPrcPrtDiv = salesTtlStWork.ShipmSlipUnPrcPrtDiv;	// 出荷伝票単価印刷区分

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //salesTtlSt.IoGoodsCntDiv		= salesTtlStWork.IoGoodsCntDiv;			// 入荷数区分
            ////----- ueno add ---------- start 2008.02.26
            //salesTtlSt.IoGoodsCntDiv2		= salesTtlStWork.IoGoodsCntDiv2;		// 入荷数区分２
            ////----- ueno add ---------- end 2008.02.26
            //salesTtlSt.SalesFormalIn		= salesTtlStWork.SalesFormalIn;			// 売上形式初期値
            //salesTtlSt.StockDetailConf		= salesTtlStWork.StockDetailConf;		// 仕入明細確認
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			salesTtlSt.GrsProfitCheckLower	= salesTtlStWork.GrsProfitCheckLower;	// 粗利チェック下限
			salesTtlSt.GrsProfitCheckBest	= salesTtlStWork.GrsProfitCheckBest;	// 粗利チェック適正
			salesTtlSt.GrsProfitCheckUpper	= salesTtlStWork.GrsProfitCheckUpper;	// 粗利チェック上限
			salesTtlSt.GrsProfitChkLowSign	= salesTtlStWork.GrsProfitChkLowSign;	// 粗利下限記号
			salesTtlSt.GrsProfitChkBestSign = salesTtlStWork.GrsProfitChkBestSign;	// 粗利適正記号
			salesTtlSt.GrsProfitChkUprSign	= salesTtlStWork.GrsProfitChkUprSign;	// 粗利上限記号
			salesTtlSt.GrsProfitChkMaxSign	= salesTtlStWork.GrsProfitChkMaxSign;	// 粗利最大記号
			salesTtlSt.SalesAgentChngDiv	= salesTtlStWork.SalesAgentChngDiv;		// 売上担当変更区分
			salesTtlSt.AcpOdrAgentDispDiv	= salesTtlStWork.AcpOdrAgentDispDiv;	// 受注者表示区分
			salesTtlSt.BrSlipNote2DispDiv	= salesTtlStWork.BrSlipNote2DispDiv;	// 伝票備考２表示区分
			salesTtlSt.DtlNoteDispDiv		= salesTtlStWork.DtlNoteDispDiv;		// 明細備考表示区分
			salesTtlSt.UnPrcNonSettingDiv	= salesTtlStWork.UnPrcNonSettingDiv;	// 売価未設定区分
			salesTtlSt.AcpOdrrAddUpRemDiv	= salesTtlStWork.AcpOdrrAddUpRemDiv;	// 受注データ計上残区分
			salesTtlSt.ShipmAddUpRemDiv		= salesTtlStWork.ShipmAddUpRemDiv;		// 出荷データ計上残区分
			salesTtlSt.RetGoodsStockEtyDiv	= salesTtlStWork.RetGoodsStockEtyDiv;	// 返品時在庫登録区分
			salesTtlSt.ListPriceSelectDiv	= salesTtlStWork.ListPriceSelectDiv;	// 定価選択区分
			salesTtlSt.MakerInpDiv			= salesTtlStWork.MakerInpDiv;			// メーカー入力区分
			salesTtlSt.BLGoodsCdInpDiv		= salesTtlStWork.BLGoodsCdInpDiv;		// BL商品コード入力区分
			salesTtlSt.SupplierInpDiv		= salesTtlStWork.SupplierInpDiv;		// 仕入先入力区分
			salesTtlSt.SupplierSlipDelDiv	= salesTtlStWork.SupplierSlipDelDiv;	// 仕入伝票削除区分
			salesTtlSt.CustGuideDispDiv		= salesTtlStWork.CustGuideDispDiv;		// 得意先ガイド初期表示区分
			salesTtlSt.SlipChngDivDate		= salesTtlStWork.SlipChngDivDate;		// 伝票修正区分（日付）
			salesTtlSt.SlipChngDivCost		= salesTtlStWork.SlipChngDivCost;		// 伝票修正区分（原価）
			salesTtlSt.SlipChngDivUnPrc		= salesTtlStWork.SlipChngDivUnPrc;		// 伝票修正区分（売価）
			salesTtlSt.SlipChngDivLPrice	= salesTtlStWork.SlipChngDivLPrice;		// 伝票修正区分（定価）

            // 2008.12.11 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
            salesTtlSt.RetSlipChngDivCost = salesTtlStWork.RetSlipChngDivCost;      // 返品伝票修正区分（原価）
            salesTtlSt.RetSlipChngDivUnPrc = salesTtlStWork.RetSlipChngDivUnPrc;    // 返品伝票修正区分（売価）
            // 2008.12.11 30413 犬飼 返品伝票修正区分の追加 <<<<<<END

			//----- ueno add ---------- start 2008.02.18
			salesTtlSt.AutoDepoKindCode		= salesTtlStWork.AutoDepoKindCode;		// 自動入金金種コード
			salesTtlSt.AutoDepoKindName		= salesTtlStWork.AutoDepoKindName;		// 自動金種区分名称
			salesTtlSt.AutoDepoKindDivCd	= salesTtlStWork.AutoDepoKindDivCd;		// 自動入金金種区分
			//----- ueno add ---------- end 2008.02.18
			//----- ueno add ---------- start 2008.02.26
			salesTtlSt.DiscountName			= salesTtlStWork.DiscountName;			// 値引名称
			//----- ueno add ---------- end 2008.02.26

            // --- ADD 2008/06/09 -------------------------------->>>>>
            salesTtlSt.SectionCode          = salesTtlStWork.SectionCode;           // 拠点コード        
            salesTtlSt.EstmateAddUpRemDiv   = salesTtlStWork.EstmateAddUpRemDiv;    // 見積データ計上残区分
            salesTtlSt.InpAgentDispDiv      = salesTtlStWork.InpAgentDispDiv;       // 発行者表示区分
            salesTtlSt.CustOrderNoDispDiv   = salesTtlStWork.CustOrderNoDispDiv;    // 得意先注番表示区分
            salesTtlSt.CarMngNoDispDiv      = salesTtlStWork.CarMngNoDispDiv;       // 車輌管理番号表示区分
            // --- ADD 2009/10/19 ---------->>>>>
            salesTtlSt.PriceSelectDispDiv   = salesTtlStWork.PriceSelectDispDiv;    // 表示区分プロセス
            // --- ADD 2009/10/19 ----------<<<<<
            salesTtlSt.AcpOdrInputDiv 　　　= salesTtlStWork.AcpOdrInputDiv; 　　　 // ADD 2010/01/29 受注数入力を追加
            salesTtlSt.InpAgentChkDiv       = salesTtlStWork.InpAgentChkDiv;        // ADD 2010/05/04 発行者チェック区分を追加
            salesTtlSt.InpWarehChkDiv       = salesTtlStWork.InpWarehChkDiv;        // ADD 2010/05/04 入力倉庫チェック区分を追加
            salesTtlSt.BrSlipNote3DispDiv   = salesTtlStWork.BrSlipNote3DispDiv;    // 伝票備考３表示区分
            salesTtlSt.SlipDateClrDivCd     = salesTtlStWork.SlipDateClrDivCd;      // 伝票日付クリア区分
            salesTtlSt.AutoEntryGoodsDivCd  = salesTtlStWork.AutoEntryGoodsDivCd;   // 商品自動登録
            salesTtlSt.CostCheckDivCd       = salesTtlStWork.CostCheckDivCd;        // 原価チェック区分
            salesTtlSt.JoinInitDispDiv      = salesTtlStWork.JoinInitDispDiv;       // 結合初期表示区分
            salesTtlSt.AutoDepositCd        = salesTtlStWork.AutoDepositCd;         // 自動入金区分
            salesTtlSt.SubstCondDivCd       = salesTtlStWork.SubstCondDivCd;        // 代替条件区分
            salesTtlSt.SlipCreateProcess    = salesTtlStWork.SlipCreateProcess;     // 伝票作成方法
            salesTtlSt.WarehouseChkDiv      = salesTtlStWork.WarehouseChkDiv;       // 倉庫チェック区分
            salesTtlSt.PartsSearchDivCd     = salesTtlStWork.PartsSearchDivCd;      // 部品検索区分
            salesTtlSt.GrsProfitDspCd       = salesTtlStWork.GrsProfitDspCd;        // 粗利表示区分
            salesTtlSt.PartsSearchPriDivCd  = salesTtlStWork.PartsSearchPriDivCd;   // 部品検索優先順区分
            salesTtlSt.SalesStockDiv        = salesTtlStWork.SalesStockDiv;         // 売上仕入区分
            salesTtlSt.PrtBLGoodsCodeDiv    = salesTtlStWork.PrtBLGoodsCodeDiv;     // 印刷用BL商品コード区分
            salesTtlSt.SectDspDivCd         = salesTtlStWork.SectDspDivCd;          // 拠点表示区分
            salesTtlSt.GoodsNmReDispDivCd   = salesTtlStWork.GoodsNmReDispDivCd;    // 商品名再表示区分
            salesTtlSt.CostDspDivCd         = salesTtlStWork.CostDspDivCd;          // 原価表示区分
            salesTtlSt.DepoSlipDateClrDiv   = salesTtlStWork.DepoSlipDateClrDiv;    // 入金伝票日付クリア区分
            salesTtlSt.DepoSlipDateAmbit    = salesTtlStWork.DepoSlipDateAmbit;     // 入金伝票日付範囲区分
            // --- ADD 2008/06/09 --------------------------------<<<<< 

            // --- ADD 2008/07/22 -------------------------------->>>>>
            salesTtlSt.InpGrsProfChkLower = salesTtlStWork.InpGrsProfChkLower;      // 入力粗利チェック下限
            salesTtlSt.InpGrsProfChkUpper = salesTtlStWork.InpGrsProfChkUpper;      // 入力粗利チェック上限
            salesTtlSt.InpGrsProfChkLowDiv = salesTtlStWork.InpGrsPrfChkLowDiv;     // 入力粗利チェック下限区分
            salesTtlSt.InpGrsProfChkUppDiv = salesTtlStWork.InpGrsPrfChkUppDiv;     // 入力粗利チェック上限区分
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            salesTtlSt.PrmSubstCondDivCd= salesTtlStWork.PrmSubstCondDivCd;         // 優良代替条件区分
            salesTtlSt.SubstApplyDivCd  = salesTtlStWork.SubstApplyDivCd;           // 代替適用区分
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<

            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
            salesTtlSt.PartsNameDspDivCd = salesTtlStWork.PartsNameDspDivCd;        // 品名表示区分
            // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<
            salesTtlSt.BLGoodsCdDerivNoDiv = salesTtlStWork.BLGoodsCdDerivNoDiv;    // BLコード枝番

            // --- ADD 2010/04/30-------------------------------->>>>>
            salesTtlSt.FrSrchPrtAutoEntDiv = salesTtlStWork.FrSrchPrtAutoEntDiv;    // 自由検索部品自動登録区分
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            salesTtlSt.BLCdPrtsNmDspDivCd1 = salesTtlStWork.BLCdPrtsNmDspDivCd1;    // BLコード検索品名表示区分１
            salesTtlSt.BLCdPrtsNmDspDivCd2 = salesTtlStWork.BLCdPrtsNmDspDivCd2;    // BLコード検索品名表示区分２
            salesTtlSt.BLCdPrtsNmDspDivCd3 = salesTtlStWork.BLCdPrtsNmDspDivCd3;    // BLコード検索品名表示区分３
            salesTtlSt.BLCdPrtsNmDspDivCd4 = salesTtlStWork.BLCdPrtsNmDspDivCd4;    // BLコード検索品名表示区分４
            salesTtlSt.GdNoPrtsNmDspDivCd1 = salesTtlStWork.GdNoPrtsNmDspDivCd1;    // 品番検索品名表示区分１
            salesTtlSt.GdNoPrtsNmDspDivCd2 = salesTtlStWork.GdNoPrtsNmDspDivCd2;    // 品番検索品名表示区分２
            salesTtlSt.GdNoPrtsNmDspDivCd3 = salesTtlStWork.GdNoPrtsNmDspDivCd3;    // 品番検索品名表示区分３
            salesTtlSt.GdNoPrtsNmDspDivCd4 = salesTtlStWork.GdNoPrtsNmDspDivCd4;    // 品番検索品名表示区分４
            salesTtlSt.PrmPrtsNmUseDivCd = salesTtlStWork.PrmPrtsNmUseDivCd;        // 優良部品検索品名使用区分
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
            // --- ADD 2010/08/04---------->>>>>
            salesTtlSt.DwnPLCdSpDivCd = salesTtlStWork.DwnPLCdSpDivCd;    // 小数点表示区分
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07---------->>>>>
            salesTtlSt.SalesCdDspDivCd = salesTtlStWork.SalesCdDspDivCd;    // 販売区分表示区分
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23---------->>>>>
            salesTtlSt.RentStockDiv = salesTtlStWork.RentStockDiv;    // 貸出仕入区分
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            salesTtlSt.EpPartsNoPrtCd = salesTtlStWork.EpPartsNoPrtCd;          // 自社品番印字区分
            salesTtlSt.EpPartsNoAddChar = salesTtlStWork.EpPartsNoAddChar;      // 自社品番付加文字
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            salesTtlSt.PrintGoodsNoDef = salesTtlStWork.PrintGoodsNoDef;        // 印字品番初期値
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
			// --- ADD 2013/01/15 ---------->>>>>
            salesTtlSt.StockRetGoodsPlnDiv = salesTtlStWork.StockRetGoodsPlnDiv; // 仕入返品予定機能区分
            // --- ADD 2013/01/15 ----------<<<<<
            salesTtlSt.AutoDepositNoteDiv = salesTtlStWork.AutoDepositNoteDiv;  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            salesTtlSt.BLGoodsCdZeroSuprt = salesTtlStWork.BLGoodsCdZeroSuprt;  // BLコード０対応
            salesTtlSt.BLGoodsCdChange = salesTtlStWork.BLGoodsCdChange;        // 変換コード
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            salesTtlSt.StockEmpRefDiv = salesTtlStWork.StockEmpRefDiv;    // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

			return salesTtlSt;
		}

		#endregion
	}
}
