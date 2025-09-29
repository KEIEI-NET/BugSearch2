using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add ---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上金額処理区分設定テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上金額処理区分設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2007.08.20</br>
    /// <br>Update Note: 2008.01.31 30167 上野 弘貴 ローカルＤＢ対応</br>
    /// <br>Update Note: 2009.07.13 20056 對馬 大輔 LoginInfoAcquisition.OnlineFlagを参照して制御切替を行わない(常にOnline)</br>
    /// </remarks>
    public class SalesProcMoneyAcs : IGeneralGuideData
    {
        # region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ISalesProcMoneyDB _iSalesProcMoneyDB = null;

		//----- ueno add ---------- start 2008.01.31
		// ローカルオブジェクト格納バッファ
		private SalesProcMoneyLcDB _salesProcMoneyLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        // Static格納用HashTable
        private static Hashtable _static_SalesProcMoneyTable = null;
        /// <summary>売上金額処理区分設定マスタクラスSearchフラグ</summary>
        private static bool _searchFlg;

        // オフラインデータ格納先パス
        private string _offlineDataDirPath = "";

        private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // ガイドデータサーチモード(0:ローカル,1:リモート)

		//----- ueno upd ---------- start 2008.01.31
        //private static bool _isLocalDBRead = true;
        private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno upd ---------- end 2008.01.31

        # endregion

        #region コンストラクタ
        /// <summary>
        /// 売上金額処理区分設定テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public SalesProcMoneyAcs()
        {
            // メモリ生成処理
            MemoryCreate();

            // オフラインデータ格納先パス
            this._offlineDataDirPath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ログイン部品で通信状態を確認
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iSalesProcMoneyDB = (ISalesProcMoneyDB)MediationSalesProcMoneyDB.GetSalesProcMoneyDB();
            //    }
            //    catch (Exception)
            //    {
            //        // オフライン時はnullをセット
            //        this._iSalesProcMoneyDB = null;
            //    }
            //}
            //else
            //{
            //    // オフライン時のデータ読み込み(未実装)
            //}

            try
            {
                // リモートオブジェクト取得
                this._iSalesProcMoneyDB = (ISalesProcMoneyDB)MediationSalesProcMoneyDB.GetSalesProcMoneyDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesProcMoneyDB = null;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._salesProcMoneyLcDB = new SalesProcMoneyLcDB();
			//----- ueno add ---------- end 2008.01.31
        }

        /// <summary>
        /// 売上金額処理区分設定テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        static SalesProcMoneyAcs()
        {
            // Static格納用HashTable
            _static_SalesProcMoneyTable = new Hashtable();
        }
        #endregion

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

        #region Public Method

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSalesProcMoneyDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定 Staticメモリ全件取得処理
        /// </summary>
        /// <param name="retList">売上金額処理区分設定マスタ クラスList</param>
        /// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定マスタ Staticメモリの全件を取得します。</br>
        /// <br>Programer  : 21024  佐々木  健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        public int SearchStaticMemory( out ArrayList retList, string enterpriseCode )
        {
            retList = new ArrayList();
            retList.Clear();
            SortedList sortedList = new SortedList();

            if (( _static_SalesProcMoneyTable == null ) ||
                ( _static_SalesProcMoneyTable.Count == 0 ))
            {
                //return -1;
                this.SearchAll(out retList, enterpriseCode);

                return 0;
            }
            else if (_static_SalesProcMoneyTable.Count == 0)
            {
                return 9;
            }

            foreach (SalesProcMoney salesProcMoney in _static_SalesProcMoneyTable.Values)
            {
                sortedList.Add(CreateHashKey(salesProcMoney), salesProcMoney);
            }

            retList.AddRange(sortedList.Values);

            return 0;
        }

        /// <summary>
        /// 売上金額処理区分設定読み込み処理
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="upperLimitPrice">上限金額</param>
        /// <returns>売上金額処理区分設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定情報を読み込みます。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Read( out SalesProcMoney salesProcMoney, string enterpriseCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice )
        {
            try
            {
                int status = 0;
                salesProcMoney = null;
                SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

                // キー項目設定
                salesProcMoneyWork.EnterpriseCode = enterpriseCode;
                salesProcMoneyWork.FracProcMoneyDiv = fracProcMoneyDiv;
                salesProcMoneyWork.FractionProcCode = fractionProcCode;
                salesProcMoneyWork.UpperLimitPrice = upperLimitPrice;

				//----- ueno upd ---------- start 2008.01.31
				// ローカル
                if (_isLocalDBRead)
                {
					status = this._salesProcMoneyLcDB.Read(ref salesProcMoneyWork, 0);
                }
                // リモート
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(salesProcMoneyWork);

                    // 売上金額処理区分設定読み込み
                    status = this._iSalesProcMoneyDB.Read(ref parabyte, 0);

                    // XMLの読み込み 
                    salesProcMoneyWork = (SalesProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalesProcMoneyWork));
                }
				//----- ueno upd ---------- end 2008.01.31

                if (status == 0)
                {
                    // クラス内メンバコピー
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Read用Staticに保持
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }
                return status;
            }
            catch (Exception)
            {
                // 通信エラーは-1を戻す
                salesProcMoney = null;
                // オフライン時はnullをセット
                this._iSalesProcMoneyDB = null;
                return -1;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定登録・更新処理
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定情報の登録・更新を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Write( ref SalesProcMoney salesProcMoney )
        {
            int status = 0;

            try
            {
                // 売上金額処理区分設定クラスから売上金額処理区分設定ワーククラスにメンバコピー
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                ArrayList paraList = new ArrayList();
                paraList.Add(salesProcMoneyWork);
                object paraObj = (object)paraList;

                //売上金額処理区分設定書き込み
                status = this._iSalesProcMoneyDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = paraObj as ArrayList;

                    salesProcMoneyWork = (SalesProcMoneyWork)paraList[0];
                    // クラス内メンバコピー
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Read用Staticに更新
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesProcMoneyDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 売上金額処理区分設定論理削除処理
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定情報の論理削除を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int LogicalDelete( ref SalesProcMoney salesProcMoney )
        {
            try
            {
                int status = 0;
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                ArrayList paraList = new ArrayList();
                paraList.Add(salesProcMoneyWork);
                object paraObj = (object)paraList;

                // 論理削除
                status = this._iSalesProcMoneyDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = paraObj as ArrayList;
                    salesProcMoneyWork = (SalesProcMoneyWork)paraList[0];
                    // クラス内メンバコピー
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Read用Staticに更新
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney.Clone();
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesProcMoneyDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定物理削除処理
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定情報の物理削除を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Delete( SalesProcMoney salesProcMoney )
        {
            try
            {
                int status = 0;
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(salesProcMoneyWork);

                // 物理削除
                status = this._iSalesProcMoneyDB.Delete(parabyte);

                // Static更新
                _static_SalesProcMoneyTable.Remove(CreateHashKey(salesProcMoney));

                return status;
               
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesProcMoneyDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Search( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData0, null);
        }

        /// <summary>
        /// 売上金額処理区分設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
        }

        /// <summary>
        /// 件数指定売上金額処理区分設定検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSalesProcMoneyがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="prevSalesProcMoney">前回最終売上金額処理区分設定データオブジェクト（初回はnull指定必須）</param>			
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 件数を指定して売上金額処理区分設定の検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, out int retTotalCnt, string enterpriseCode, SalesProcMoney prevSalesProcMoney )
        {
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01, prevSalesProcMoney);
        }

        /// <summary>
        /// 売上金額処理区分設定マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定マスタの検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        public int Search( ref DataSet ds, string enterpriseCode, int fracProcMoneyDiv )
        {
            ArrayList ar = new ArrayList();
            ArrayList salesProcMoneyList = new ArrayList();

            int status = 0;
            int retTotalCnt;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
            //if (( !_searchFlg ) && ( LoginInfoAcquisition.OnlineFlag ))
            //{
            //    // 売上金額処理区分設定マスタサーチ
            //    status = this.SearchProc(out salesProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
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
                // 売上金額処理区分設定マスタサーチ
                status = this.SearchProc(out salesProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
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
            foreach (SalesProcMoney salesProcMoney in _static_SalesProcMoneyTable.Values)
            {
                // 端数処理対象区分が指定されている場合はここで絞り込み
                if (( fracProcMoneyDiv == -1 ) || ( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ))
                {
                    // 全社表示
                    ar.Add(salesProcMoney.Clone());
                }
            }

            ArrayList wkList = ar.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (SalesProcMoney wkSalesProcMoney in wkList)
            {
                if (wkSalesProcMoney.LogicalDeleteCode == 0)
                {
                    wkSort.Add(CreateHashKey(wkSalesProcMoney),wkSalesProcMoney);
                }
            }

            SalesProcMoney[] salesProcMoneys = new SalesProcMoney[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                salesProcMoneys[i] = (SalesProcMoney)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(salesProcMoneys);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }


        /// <summary>
        /// 売上金額処理区分設定論理削除復活処理
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定情報の復活を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Revival( ref SalesProcMoney salesProcMoney )
        {
            try
            {
                int status = 0;
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                ArrayList paraList = new ArrayList();
                paraList.Add(salesProcMoneyWork);
                object paraObj = (object)paraList;

                // 復活処理
                status = this._iSalesProcMoneyDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = paraObj as ArrayList;
                    salesProcMoneyWork = (SalesProcMoneyWork)paraList[0];

                    // クラス内メンバコピー
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Static更新
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }

                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSalesProcMoneyDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// マスタガイド起動処理(通常(ローカル))
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="salesProcMoney">売上金額処理区分設定UIクラス</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        public int ExecuteGuid( string enterpriseCode, int fracProcMoneyDiv, out SalesProcMoney salesProcMoney )
        {
            if (this.GetOnlineMode() == (int)ConstantManagement.OnlineMode.Offline)
            {
                // ローカル
                return this.ExecuteGuid(enterpriseCode, fracProcMoneyDiv, out salesProcMoney, 0);
            }
            else
            {
                // リモート
                return this.ExecuteGuid(enterpriseCode, fracProcMoneyDiv, out salesProcMoney, 1);
            }
        }

        #region ▼ガイド起動処理
        /// <summary>
        /// 売上金額処理区分設定ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="salesProcMoney">取得データ</param>
        /// <param name="searchMode">読込モード(0:ローカル,1:リモート)</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 売上金額処理区分設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 21024 佐々木 健</br>
        /// <br>Date		: 2007.08.28</br>
        /// </remarks>
        public int ExecuteGuid( string enterpriseCode, int fracProcMoneyDiv, out SalesProcMoney salesProcMoney, int searchMode )
        {
            int status = -1;
            salesProcMoney = new SalesProcMoney();
            TableGuideParent tableGuideParent = new TableGuideParent("SALESPROCMONEYGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("FracProcMoneyDiv", fracProcMoneyDiv);
            // ガイドデータサーチモード(0:ローカル,1:リモート)
            inObj.Add(GUIDE_SEARCHMODE_PARA, searchMode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                salesProcMoney.FracProcMoneyDiv = int.Parse(retObj["FracProcMoneyDiv"].ToString());
                salesProcMoney.UpperLimitPrice = double.Parse(retObj["UpperLimitPrice"].ToString());
                salesProcMoney.FractionProcCdNm = retObj["FractionProcCdNm"].ToString();
                salesProcMoney.FractionProcCode = int.Parse(retObj["FractionProcCode"].ToString());
                salesProcMoney.FractionProcCd = SalesProcMoney.GetFractionProcCd(salesProcMoney.FractionProcCdNm);

                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
        # endregion

        #region ▼IGeneralGuidData Method
        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 21024 佐々木 健</br>
        /// <br>Date		: 2007.08.28</br>
        /// </remarks>
        public int GetGuideData( int mode, Hashtable inParm, ref DataSet guideList )
        {
            int status = -1;
            string enterpriseCode = "";
            int fracProcMoneyDiv = 0;

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // 端数処理対象金額区分設定有り
            if (inParm.ContainsKey("FracProcMoneyDiv"))
            {
                fracProcMoneyDiv = (Int32)inParm["FracProcMoneyDiv"];
            }

            // 売上金額処理区分設定マスタテーブル読込み(ローカルDB)  
            int searchMode = 0;
            _searchFlg = false;
            if (inParm.ContainsKey(GUIDE_SEARCHMODE_PARA))
            {
                searchMode = int.Parse(inParm[GUIDE_SEARCHMODE_PARA].ToString());
            }

            if (searchMode == 1)
            {
                status = Search(ref guideList, enterpriseCode, fracProcMoneyDiv);
            }
            else
            {
                //status = SearchLocalDB(ref guideList, enterpriseCode);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }
        #endregion

        # endregion

        #region Private Method

        /// <summary>
        /// 売上金額処理区分設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSalesProcMoneyがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevSalesProcMoney">前回最終売上金額処理区分設定データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定の検索処理を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private int SearchProc( out ArrayList retList, out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, SalesProcMoney prevSalesProcMoney )
        {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            if (prevSalesProcMoney != null)
            {
                salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(prevSalesProcMoney);
            }
            salesProcMoneyWork.EnterpriseCode = enterpriseCode;
            salesProcMoneyWork.FracProcMoneyDiv = -1;
            salesProcMoneyWork.FractionProcCode = -1;

            retList = new ArrayList();
            retList.Clear();
            ArrayList paraList = new ArrayList();

            retTotalCnt = 0;
            int status = 0;

            object retObj = null;

            ArrayList al = new ArrayList();
            al.Add(salesProcMoneyWork);
            object paraObj = al;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オフラインの場合はキャッシュから読む
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList, enterpriseCode);
            //}
            //else
            //{
            //    SalesProcMoney salesProcMoney = new SalesProcMoney();

            //    //----- ueno upd ---------- start 2008.01.31
            //    if (_isLocalDBRead)
            //    {
            //        // ローカル
            //        List<SalesProcMoneyWork> salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
            //        status = this._salesProcMoneyLcDB.Search(out salesProcMoneyWorkList, salesProcMoneyWork, 0, logicalMode);

            //        if (status == 0)
            //        {
            //            ArrayList wkAl = new ArrayList();
            //            wkAl.AddRange(salesProcMoneyWorkList);
            //            retObj = (object)wkAl;
            //        }
            //    }
            //    else
            //    {
            //        // リモート 
            //        status = this._iSalesProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);
            //    }
            //    //----- ueno upd ---------- end 2008.01.31
				
            //    if (status == 0)
            //    {
            //        // 売上金額処理区分設定マスタワーカークラス⇒UIクラスStatic転記処理
            //        CopyToStaticFromWorker(retObj as ArrayList);

            //        // パラメータが渡って来ているか確認
            //        paraList = retObj as ArrayList;
            //        SalesProcMoneyWork[] wkSalesProcMoneyWork = new SalesProcMoneyWork[paraList.Count];

            //        // データを元に戻す
            //        for (int i = 0; i < paraList.Count; i++)
            //        {
            //            wkSalesProcMoneyWork[i] = (SalesProcMoneyWork)paraList[i];
            //        }
            //        for (int i = 0; i < wkSalesProcMoneyWork.Length; i++)
            //        {
            //            salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(wkSalesProcMoneyWork[i]);
            //            // サーチ結果取得
            //            retList.Add(salesProcMoney);
            //            // スタティック更新
            //            _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
            //        }
            //        // SearchFlg ON
            //        _searchFlg = true;
            //    }
            //}

            SalesProcMoney salesProcMoney = new SalesProcMoney();

            if (_isLocalDBRead)
            {
                // ローカル
                List<SalesProcMoneyWork> salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
                status = this._salesProcMoneyLcDB.Search(out salesProcMoneyWorkList, salesProcMoneyWork, 0, logicalMode);

                if (status == 0)
                {
                    ArrayList wkAl = new ArrayList();
                    wkAl.AddRange(salesProcMoneyWorkList);
                    retObj = (object)wkAl;
                }
            }
            else
            {
                // リモート 
                status = this._iSalesProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);
            }

            if (status == 0)
            {
                // 売上金額処理区分設定マスタワーカークラス⇒UIクラスStatic転記処理
                CopyToStaticFromWorker(retObj as ArrayList);

                // パラメータが渡って来ているか確認
                paraList = retObj as ArrayList;
                SalesProcMoneyWork[] wkSalesProcMoneyWork = new SalesProcMoneyWork[paraList.Count];

                // データを元に戻す
                for (int i = 0; i < paraList.Count; i++)
                {
                    wkSalesProcMoneyWork[i] = (SalesProcMoneyWork)paraList[i];
                }
                for (int i = 0; i < wkSalesProcMoneyWork.Length; i++)
                {
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(wkSalesProcMoneyWork[i]);
                    // サーチ結果取得
                    retList.Add(salesProcMoney);
                    // スタティック更新
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }
                // SearchFlg ON
                _searchFlg = true;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理（売上金額処理区分設定ワーククラス⇒売上金額処理区分設定クラス）
        /// </summary>
        /// <param name="salesProcMoneyWork">売上金額処理区分設定ワーククラス</param>
        /// <returns>売上金額処理区分設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定ワーククラスから売上金額処理区分設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private SalesProcMoney CopyToSalesProcMoneyFromSalesProcMoneyWork( SalesProcMoneyWork salesProcMoneyWork )
        {
            SalesProcMoney salesProcMoney = new SalesProcMoney();

            salesProcMoney.CreateDateTime = salesProcMoneyWork.CreateDateTime;
            salesProcMoney.UpdateDateTime = salesProcMoneyWork.UpdateDateTime;
            salesProcMoney.EnterpriseCode = salesProcMoneyWork.EnterpriseCode;
            salesProcMoney.FileHeaderGuid = salesProcMoneyWork.FileHeaderGuid;
            salesProcMoney.UpdEmployeeCode = salesProcMoneyWork.UpdEmployeeCode;
            salesProcMoney.UpdAssemblyId1 = salesProcMoneyWork.UpdAssemblyId1;
            salesProcMoney.UpdAssemblyId2 = salesProcMoneyWork.UpdAssemblyId2;
            salesProcMoney.LogicalDeleteCode = salesProcMoneyWork.LogicalDeleteCode;
            salesProcMoney.FracProcMoneyDiv = salesProcMoneyWork.FracProcMoneyDiv;
            salesProcMoney.FractionProcCode = salesProcMoneyWork.FractionProcCode;
            salesProcMoney.UpperLimitPrice = salesProcMoneyWork.UpperLimitPrice;
            salesProcMoney.FractionProcUnit = salesProcMoneyWork.FractionProcUnit;
            salesProcMoney.FractionProcCd = salesProcMoneyWork.FractionProcCd;
            salesProcMoney.FractionProcCdNm = SalesProcMoney.GetFractionProcCdNm(salesProcMoneyWork.FractionProcCd);

            return salesProcMoney;
        }

        /// <summary>
        /// クラスメンバーコピー処理（売上金額処理区分設定クラス⇒売上金額処理区分設定ワーククラス）
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定ワーククラス</param>
        /// <returns>売上金額処理区分設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定クラスから売上金額処理区分設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private SalesProcMoneyWork CopyToSalesProcMoneyWorkFromSalesProcMoney( SalesProcMoney salesProcMoney )
        {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            salesProcMoneyWork.CreateDateTime = salesProcMoney.CreateDateTime;
            salesProcMoneyWork.UpdateDateTime = salesProcMoney.UpdateDateTime;
            salesProcMoneyWork.EnterpriseCode = salesProcMoney.EnterpriseCode.Trim();
            salesProcMoneyWork.FileHeaderGuid = salesProcMoney.FileHeaderGuid;
            salesProcMoneyWork.UpdEmployeeCode = salesProcMoney.UpdEmployeeCode;
            salesProcMoneyWork.UpdAssemblyId1 = salesProcMoney.UpdAssemblyId1;
            salesProcMoneyWork.UpdAssemblyId2 = salesProcMoney.UpdAssemblyId2;
            salesProcMoneyWork.LogicalDeleteCode = salesProcMoney.LogicalDeleteCode;
            salesProcMoneyWork.FracProcMoneyDiv = salesProcMoney.FracProcMoneyDiv;
            salesProcMoneyWork.FractionProcCode = salesProcMoney.FractionProcCode;
            salesProcMoneyWork.UpperLimitPrice = salesProcMoney.UpperLimitPrice;
            salesProcMoneyWork.FractionProcUnit = salesProcMoney.FractionProcUnit;
            salesProcMoneyWork.FractionProcCd = salesProcMoney.FractionProcCd;

            return salesProcMoneyWork;
        }

        /// <summary>
        /// メモリ生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定アクセスクラスが保持するメモリを生成します。</br>
        /// <br>Programer  : 21024 佐々木　健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void MemoryCreate()
        {

            // 売上金額処理区分設定マスタクラスStatic
            if (_static_SalesProcMoneyTable == null)
            {
                _static_SalesProcMoneyTable = new Hashtable();
            }
        }

        /// <summary>
        /// ローカルファイル読込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
        /// <br>Programer  : 21024  佐々木　健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // オフラインシリアライズデータ作成部品I/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // --- Search用 --- //
            // KeyList設定
            string[] salesProcMoneyKeys = new string[1];
            salesProcMoneyKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ローカルファイル読込み処理
            object wkObj = offlineDataSerializer.DeSerialize("SalesProcMoneyAcs", salesProcMoneyKeys);
            // ArrayListにセット
            List<SalesProcMoneyWork> wkList = new List<SalesProcMoneyWork>();

            if (( wkList != null ) &&
                ( wkList.Count != 0 ))
            {
                // 売上金額処理区分設定ワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
                CopyToStaticFromWorker(wkList);
            }
        }

        /// <summary>
        /// 売上金額処理区分設定ワーカークラス（List） ⇒ UIクラス変換処理
        /// </summary>
        /// <param name="salesProcMoneyWorkList">売上金額処理区分設定マスタワーカークラスのArrayList</param>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定マスタワーカークラスをUIのクラスに変換して、
        ///					 Search用Staticメモリに保持します。</br>
        /// <br>Programer  : 21024  佐々木  健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void CopyToStaticFromWorker( List<SalesProcMoneyWork> salesProcMoneyWorkList )
        {
            ArrayList salesProcMoneyWorkArray = new ArrayList();
            salesProcMoneyWorkArray.AddRange(salesProcMoneyWorkList);

            CopyToStaticFromWorker(salesProcMoneyWorkArray);
        }

        /// <summary>
        /// 売上金額処理区分設定ワーカークラス（ArrayList） ⇒ UIクラス変換処理
        /// </summary>
        /// <param name="salesProcMoneyWorkList">売上金額処理区分設定マスタワーカークラスのArrayList</param>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定ワーカークラスをUIのクラスに変換して、
        ///					 Search用Staticメモリに保持します。</br>
        /// <br>Programer  : 21024  佐々木  健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void CopyToStaticFromWorker( ArrayList salesProcMoneyWorkList )
        {
            string hashKey;
            foreach (SalesProcMoneyWork wkSalesProcMoneyWork in salesProcMoneyWorkList)
            {
                SalesProcMoney salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(wkSalesProcMoneyWork);

                // HashKey:端数処理対象金額区分、端数処理コード、上限金額
                hashKey = CreateHashKey(salesProcMoney);

                _static_SalesProcMoneyTable[hashKey] = salesProcMoney;
            }
        }

        /// <summary>
        /// HashTable用Key作成
        /// </summary>
        /// <param name="salesProcMoney">売上金額処理区分設定クラス</param>
        /// <returns>Hash用Key</returns>
        /// <remarks>
        /// <br>Note       : 売上金額処理区分設定クラスからハッシュテーブル用の
        ///					 キーを作成します。</br>
        /// <br>Programer  : 21024  佐々木  健</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private string CreateHashKey( SalesProcMoney salesProcMoney )
        {
            return salesProcMoney.FracProcMoneyDiv.ToString("d9") +
                   salesProcMoney.FractionProcCode.ToString("d9") +
                   salesProcMoney.UpperLimitPrice.ToString("000000000.00");
        }

        #endregion
    }
}
