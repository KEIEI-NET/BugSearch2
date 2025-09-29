# region ※using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 伝票検索 テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 伝票検索を行います。</br>
    /// <br>Programmer   : 22018  鈴木 正臣</br>
    /// <br>Date         : 2008.09.01</br>
    /// <br>Update Note  : 2009/02/16 30414 忍 幸史 障害ID:10825,11543対応</br>
    /// <br>             : 2009/04/03       照田 貴志　不具合対応[12857]</br>
    /// </remarks>
    public class StockAdjRefAcs
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IStockAdjRefSearchDB _iStockAdjRefSearchDB = null;
        

        /// <summary>拠点オプションフラグ</summary>
        private bool _optSection;
		// 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;													
        private StockAdjDataSet _dataSet;
        
        private static StockAdjDataSet.StockAdjustDataTable _stockSlipCache;
        private static StockAdjRefSearchParaWork _paraStockSlipCache;

        private static SortedList _nameList;
        private static StockAdjRefAcs _searchSlipAcs;

        private AdjustStockAcs _adjustStockAcs;

        private string _enterpriseCode;             // 企業コード

        private const string MESSAGE_NoResult = "検索条件に一致する伝票は存在しません。";
        private const string MESSAGE_ErrResult = "伝票情報の取得に失敗しました。";
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // 受払元伝票区分名称ディクショナリ
        private Dictionary<int, string> _acPaySlipCdNmDic;
        // 受払元取引区分名称ディクショナリ
        private Dictionary<int, string> _acPayTransCdNmDic;

        # endregion

        // デリゲート処理
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        # region ■Constracter
        /// <summary>
        /// 伝票検索 テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品大分類マスタ テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public StockAdjRefAcs()
        {
            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 拠点OPの判定
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockAdjDataSet();

            this._adjustStockAcs = AdjustStockAcs.GetInstance();

            // 名称ディクショナリ生成
            CreateNameDictionary();

            // ログイン部品で通信状態を確認
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iStockAdjRefSearchDB = (IStockAdjRefSearchDB)MediationStockAdjRefSearchDB.GetStockAdjRefSearchDB();
                }
                catch (Exception)
                {
                    //オフライン時はnullをセット
                    this._iStockAdjRefSearchDB = null;
                }
            }
            else
            {
                // オフライン時のデータ読み込み
                //this.SearchOfflineData();
                MessageBox.Show("オフライン状態のため検索が実行できません。");
            }
        }
        /// <summary>
        /// 名称ディクショナリの生成
        /// </summary>
        private void CreateNameDictionary()
        {
            // 受払元伝票区分
            _acPaySlipCdNmDic = new Dictionary<int, string>();
            _acPaySlipCdNmDic.Add( 10, "仕入" );
            _acPaySlipCdNmDic.Add( 11, "受託" );
            _acPaySlipCdNmDic.Add( 12, "受計上" );
            _acPaySlipCdNmDic.Add( 13, "在庫仕入" );
            _acPaySlipCdNmDic.Add( 20, "売上" );
            _acPaySlipCdNmDic.Add( 21, "売計上" );
            _acPaySlipCdNmDic.Add( 22, "委託" );
            _acPaySlipCdNmDic.Add( 23, "売切" );
            _acPaySlipCdNmDic.Add( 30, "移動出荷" );
            _acPaySlipCdNmDic.Add( 31, "移動入荷" );
            _acPaySlipCdNmDic.Add( 40, "調整" );
            _acPaySlipCdNmDic.Add( 41, "半黒" );
            _acPaySlipCdNmDic.Add( 42, "マスタメンテ" );
            _acPaySlipCdNmDic.Add( 50, "棚卸" );
            // 2009.01.08 add [9639]
            // 在庫組立・分解処理などでできた調整データの区分を追加
            // 60：組立、61：分解、70：補充入庫、71：補充出庫
            _acPaySlipCdNmDic.Add( 60, "組立" );
            _acPaySlipCdNmDic.Add( 61, "分解" );
            _acPaySlipCdNmDic.Add( 70, "補充入庫" );
            _acPaySlipCdNmDic.Add( 71, "補充出庫" );
            // 2009.01.08 add [9639]

            // 受払元取引区分
            _acPayTransCdNmDic = new Dictionary<int, string>();
            _acPayTransCdNmDic.Add( 10, "通常伝票" );
            _acPayTransCdNmDic.Add( 11, "返品" );
            _acPayTransCdNmDic.Add( 12, "値引" );
            _acPayTransCdNmDic.Add( 20, "赤伝" );
            _acPayTransCdNmDic.Add( 21, "削除" );
            _acPayTransCdNmDic.Add( 22, "解除" );
            _acPayTransCdNmDic.Add( 30, "在庫数調整" );
            _acPayTransCdNmDic.Add( 31, "原価調整" );
            _acPayTransCdNmDic.Add( 32, "製番調整" );
            _acPayTransCdNmDic.Add( 33, "不良品" );
            _acPayTransCdNmDic.Add( 34, "抜出" );
            _acPayTransCdNmDic.Add( 35, "消去" );
            _acPayTransCdNmDic.Add( 40, "過不足更新" );
            _acPayTransCdNmDic.Add( 90, "取消" );
        }
        # endregion

        /// <summary>
        /// 伝票検索アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>伝票検索アクセスクラス インスタンス</returns>
        public static StockAdjRefAcs GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new StockAdjRefAcs();
            }

            return _searchSlipAcs;
        }

        /// <summary>
        /// 伝票検索データセット取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        public StockAdjDataSet DataSet
        {
            get { return this._dataSet; }
        }

        # region ◆public int GetOnlineMode()
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iStockAdjRefSearchDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        # endregion

        #region ■Private Method


        /// <summary>
        /// 伝票データテーブル キャッシュ処理
        /// </summary>
        private void CacheStockSlipTable()
        {
            if (_stockSlipCache == null)
            {
                _stockSlipCache = new StockAdjDataSet.StockAdjustDataTable();
            }

            this._dataSet.StockAdjust.AcceptChanges();
            _stockSlipCache = (StockAdjDataSet.StockAdjustDataTable)this._dataSet.StockAdjust.Copy();
        }

        /// <summary>
        /// 検索条件クラス(再表示用) キャッシュ処理
        /// </summary>
        private void CacheParaStockSlip(StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            // 検索条件値
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new StockAdjRefSearchParaWork();
            }
            _paraStockSlipCache = stockAdjRefSearchParaWork;

            // 名称
            if (_nameList == null)
            {
                _nameList = new SortedList();
            }

            // デリゲートにて画面の名称項目値リストを取得・格納
            if (this.GetNameList != null)
            {
                _nameList = this.GetNameList();
            }
        }

        #endregion


        #region ■Public Method

        /// <summary>
        /// 伝票情報 読込・データセット格納実行処理
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
        /// <br>Programmer : 980023 飯谷  飯谷</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public int SetSearchData(StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            List<StockAdjRefSearchRetWork> retData;
            
            // リモート呼び出し
            int status = this.Search( out retData, stockAdjRefSearchParaWork );
            this.ClearStockAdjustDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
                    // 1明細取得
                    StockAdjRefSearchRetWork stockAdjRefSearchRetWork = retData[i];

                    // データテーブルに格納
                    CopyToTable( stockAdjRefSearchRetWork );
                }

                // 検索データのキャッシュ
                this.CacheStockSlipTable();

                // 検索条件のキャッシュ
                this.CacheParaStockSlip(stockAdjRefSearchParaWork);
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                if (this.StatusBarMessageSetting != null)
                {
                    this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                }
            }
            return status;
        }

        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="stockAdjRefSearchRetWork"></param>
        private void CopyToTable( StockAdjRefSearchRetWork retWork )
        {
            // 新規行取得
            StockAdjDataSet.StockAdjustRow row = _dataSet.StockAdjust.NewStockAdjustRow();

            # region [copy]
            row.RowNo = _dataSet.StockAdjust.Rows.Count + 1;    // 行№
            row.EnterpriseCode = retWork.EnterpriseCode; // 企業コード
            row.SectionCode = retWork.SectionCode; // 拠点コード
            row.SectionGuideSnm = retWork.SectionGuideSnm; // 拠点ガイド略称
            row.WarehouseCode = retWork.WarehouseCode; // 倉庫コード
            row.WarehouseName = retWork.WarehouseName; // 倉庫名称
            row.AcPaySlipCd = retWork.AcPaySlipCd; // 受払元伝票区分
            row.AcPaySlipCdNm = this.GetAcPaySlipCdName( retWork.AcPaySlipCd ); // 受払元伝票区分名称
            row.AcPayTransCd = retWork.AcPayTransCd; // 受払元取引区分
            row.AcPayTransCdNm = this.GetAcPayTransCdName( retWork.AcPayTransCd ); // 受払元取引区分名称
            row.InputDay = this.GetDate( retWork.InputDay ); // 入力日付
            row.AdjustDate = this.GetDate( retWork.AdjustDate ); // 調整日付
            row.StockAdjustSlipNo = retWork.StockAdjustSlipNo; // 在庫調整伝票番号
            row.StockAgentCode = retWork.StockAgentCode; // 入力担当者コード
            row.StockAgentName = retWork.StockAgentName; // 入力担当者名称
            row.SlipNote = retWork.SlipNote; // 伝票備考
            row.StockSubttlPrice = retWork.StockSubttlPrice; // 仕入金額小計
            row.StockAdjObject = retWork; // 結果workオブジェクト
            # endregion

            // 追加
            _dataSet.StockAdjust.AddStockAdjustRow( row );
        }

        /// <summary>
        /// 受払元取引区分名称取得処理
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetAcPayTransCdName( int acPayTransCd )
        {
            if ( _acPayTransCdNmDic == null )
            {
                return string.Empty;
            }
            else if ( !_acPayTransCdNmDic.ContainsKey( acPayTransCd ) )
            {
                return string.Empty;
            }
            else
            {
                return _acPayTransCdNmDic[acPayTransCd]; 
            }
        }

        /// <summary>
        /// 受払元伝票区分名称取得処理
        /// </summary>
        /// <param name="acPaySlipCd"></param>
        /// <returns></returns>
        public string GetAcPaySlipCdName( int acPaySlipCd )
        {
            if ( _acPaySlipCdNmDic == null )
            {
                return string.Empty;
            }
            else if ( !_acPaySlipCdNmDic.ContainsKey( acPaySlipCd ) )
            {
                return string.Empty;
            }
            else
            {
                return _acPaySlipCdNmDic[acPaySlipCd];
            }
        }
        /// <summary>
        /// 日付文字列　取得処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDate( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                //return dateTime.ToString( "yyyy年MM月dd日" );         //DEL 2009/04/03 不具合対応[12857]
                return dateTime.ToString("yyyy/MM/dd");                 //ADD 2009/04/03 不具合対応[12857]
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        public void ClearStockAdjustDataTable()
        {
            this._dataSet.StockAdjust.Rows.Clear();

            // キャッシュデータの取り直し(クリア状態にする)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);
        }
        
        /// <summary>
        /// 伝票情報 読み込み処理
        /// </summary>
        /// <param name="stockSlipWorks">仕入データ オブジェクト配列</param>
        /// <param name="stockAdjRefSearchParaWork">仕入伝票検索パラメータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報を読み込みます。</br>
        /// <br>Programmer : 980023 飯谷  飯谷</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public int Search(out List<StockAdjRefSearchRetWork> stockAdjRefSearchRetWorks, StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            

            try
            {
                int status;
                stockAdjRefSearchRetWorks = new List<StockAdjRefSearchRetWork>();

                // オンラインの場合リモート取得
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                    paraList.Add(stockAdjRefSearchParaWork);

                    CustomSerializeArrayList retList = new CustomSerializeArrayList();

                    object paraObj = (object)paraList;
                    object retObj = (object)retList;

                    //伝票情報取得
                    status = this._iStockAdjRefSearchDB.Search(ref paraObj, out retObj);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        int setCount = 0;
                        retList = (CustomSerializeArrayList)retObj;
                        for (int i = 0; i < retList.Count; i++)
                        {
                            stockAdjRefSearchRetWorks.Add((StockAdjRefSearchRetWork)retList[i]);
                            setCount++;
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                    else
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_ErrResult);
                        }
                    }
                }
                else	// オフラインの場合
                {
                    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                stockAdjRefSearchRetWorks = null;
                //オフライン時はnullをセット
                this._iStockAdjRefSearchDB= null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 伝票データテーブルキャッシュ取得処理
        /// </summary>
        /// <returns>伝票データテーブルキャッシュ</returns>
        public StockAdjDataSet.StockAdjustDataTable GetStockSlipTableCache()
        {
            return _stockSlipCache;
        }

        /// <summary>
        /// 画面名称項目値リスト キャッシュ取得処理
        /// </summary>
        /// <returns>画面名称項目値リスト キャッシュ</returns>
        public SortedList GetCacheNmaeList()
        {
            return _nameList;
        }


        /// <summary>
        /// 検索条件クラスキャッシュ取得処理
        /// </summary>
        /// <returns>検索条件クラスキャッシュ</returns>
        public StockAdjRefSearchParaWork GetParaStockSlipCache()
        {
            return _paraStockSlipCache;
        }

        /// <summary>
        /// 選択行テーブルデータ取得処理
        /// </summary>
        /// <param name="getRowNo">グリッド選択RowNo</param>
        /// <returns>仕入データクラス</returns>
        /// <remarks>
        /// <br>Note       : データテーブルから、指定行の仕入データクラスを返します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public StockAdjRefSearchRetWork GetSelectedRowData(int getRowNo)
        {
            return (StockAdjRefSearchRetWork)this._dataSet.StockAdjust[getRowNo].StockAdjObject;
        }

        /// <summary>
        /// 対象伝票明細情報取得処理
        /// </summary>
        /// <param name="supplierSlipNo">伝票番号</param>
        public void SetDetailData(int stockAdjustSlipNo)
		{
            // 在庫仕入伝票の読み込み
            StockAdjust stockAdjust;
            List<StockAdjustDtl> stockAdjustDtlList;

            int status = this._adjustStockAcs.ReadDBData( stockAdjustSlipNo, out stockAdjust, out stockAdjustDtlList );
            if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                int rowNo = 1;

                // 明細表示にデータ格納
                foreach ( StockAdjustDtl stockAdjustDtl in stockAdjustDtlList )
                {
                    // 行生成
                    StockAdjDataSet.StockAdjustDtlRow row = this._dataSet.StockAdjustDtl.NewStockAdjustDtlRow();

                    // 行内容セット
                    # region [row]
                    row.RowNo = rowNo++;
                    row.GoodsNo = stockAdjustDtl.GoodsNo; // 商品番号
                    row.GoodsName = stockAdjustDtl.GoodsName; // 商品名称
                    row.MakerName = stockAdjustDtl.MakerName; // メーカー名称
                    // --- CHG 2009/02/16 障害ID:11543対応------------------------------------------------------>>>>>
                    //row.BLGoodsCode = stockAdjustDtl.BLGoodsCode; // BL商品コード
                    if (stockAdjustDtl.BLGoodsCode != 0)
                    {
                        row.BLGoodsCode = stockAdjustDtl.BLGoodsCode.ToString("00000"); // BL商品コード
                    }
                    else
                    {
                        row.BLGoodsCode = "";
                    }
                    // --- CHG 2009/02/16 障害ID:11543対応------------------------------------------------------<<<<<
                    row.ListPriceFl = stockAdjustDtl.ListPriceFl; // 定価（浮動）
                    row.OpenPriceDiv = stockAdjustDtl.OpenPriceDiv; // オープン価格区分
                    row.ListPriceFlView = this.GetListPriceFlForView( stockAdjustDtl ); // 定価（表示用）
                    row.AdjustCount = stockAdjustDtl.AdjustCount; // 調整数
                    row.StockUnitPriceFl = stockAdjustDtl.StockUnitPriceFl; // 仕入単価（税抜,浮動）
                    row.StockPriceTaxExc = stockAdjustDtl.StockPriceTaxExc; // 仕入金額（税抜き）
                    row.DtlNote = stockAdjustDtl.DtlNote; // 明細備考
                    // --- ADD 2009/02/16 障害ID:10825対応------------------------------------------------------>>>>>
                    row.WarehouseCode = stockAdjustDtl.WarehouseCode;
                    row.WarehouseName = stockAdjustDtl.WarehouseName;
                    // --- ADD 2009/02/16 障害ID:10825対応------------------------------------------------------<<<<<
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
                    row.WarehouseShelfNo = stockAdjustDtl.WarehouseShelfNo; // 棚番
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
                    # endregion

                    // 行追加
                    this._dataSet.StockAdjustDtl.AddStockAdjustDtlRow( row );
                }
            }
		}
        /// <summary>
        /// 表示用 標準価格 内容取得処理
        /// </summary>
        /// <param name="stockAdjustDtl"></param>
        /// <returns></returns>
        private string GetListPriceFlForView( StockAdjustDtl stockAdjustDtl )
        {
            if ( stockAdjustDtl.OpenPriceDiv == 0 )
            {
                // 0:通常
                return stockAdjustDtl.ListPriceFl.ToString( "#,##0" );
            }
            else
            {
                // 1:オープン価格
                return "オープン価格";
            }
        }

		// ===================================================================================== //
		// 商品関連処理
		// ===================================================================================== //
		# region Goods Control Methods

		/// <summary>
		/// 検索タイプ取得処理
		/// </summary>
		/// <param name="inputCode">入力されたコード</param>
		/// <param name="searchCode">検索用コード（*を除く）</param>
		/// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
		public static int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *が存在しないため完全一致検索
				return 0;
			}
		}

		# endregion

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        // 2008.12.25 [9573]
        ///// <summary>
        ///// 本社機能／拠点機能チェック処理
        ///// </summary>
        ///// <returns>true:本社機能 false:拠点機能</returns>
        //public bool IsMainOfficeFunc()
        //{
        //    bool isMainOfficeFunc = false;

        //    // 拠点制御アクセスクラスインスタンス化処理
        //    this.CreateSecInfoAcs();

        //    // ログイン担当拠点情報の取得
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        // 本社機能か？
        //        if (secInfoSet.MainOfficeFuncFlag == 1)
        //        {
        //            isMainOfficeFunc = true;
        //        }
        //    }
        //    else
        //    {
        //        throw new ApplicationException(MESSAGE_NONOWNSECTION);
        //    }

        //    return isMainOfficeFunc;
        //}
        // 2008.12.25 [9573]

		# endregion
    }
}
