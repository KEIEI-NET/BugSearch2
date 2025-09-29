using System;
using System.Collections;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.LocalAccess;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 全体初期値設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 全体初期値設定のアクセス制御を行います。</br>
	/// <br>Programmer : 23006　高橋 明子</br>
	/// <br>Date       : 2005.10.03</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.04  23006 高橋 明子</br>
	/// <br>			   ・ファイル仕様書変更の為、対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.20  23006 高橋 明子</br>
	/// <br>			   ・拠点情報取得部品対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.26  23006 高橋 明子</br>
	/// <br>				・鈑金オフライン対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.19  23006 高橋 明子</br>
	/// <br>				・キャッシュ一本化対応</br>
    /// <br></br>
    /// <br>Update Note : 2006.08.31  23006 高橋 明子</br>
    /// <br>				・拠点機能対応</br>
    /// <br></br>
    /// <br>Update Note : 2006.09.05  23006 高橋 明子</br>
    /// <br>				・SetStaticMemoryメソッド追加</br>
    /// <br></br>
    /// <br>Update Note : 2006.12.05  18322 木村 武正</br>
    /// <br>				○ 携帯システム対応により以下の項目を削除</br>
    /// <br>                     ・管区コード</br>
    /// <br>                     ・初期表示住所コード1～3</br>
    /// <br>                     ・初期表示住所1～3</br>
    /// <br>                     ・88No.の自賠責算定区分</br>
    /// <br>                     ・車両確定選択方式</br>
    /// <br>                     ・陸運事務所番号</br>
    /// <br></br>
    /// <br>Update Note : 2007.03.05  30005 木建　翼</br>
    /// <br>                ○ 携帯システム対応により以下の項目を追加</br>
    /// <br>                     ・会員情報管理区分</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.23  30005 木建　翼</br>
    /// <br>                ○ MobileKing では使用しない処理を削除(サーバでエラーが発生したため)</br>
    /// <br>                     ・AreaGroupAcs, AreaGroup の削除</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.25　19026　湯山　美樹</br>
    /// <br>				○ ローカルアクセス対応</br>
    /// <br></br>
    /// <br>Update Note : 2007.08.08 20056  對馬 大輔</br>
    /// <br>                ○流通販売基幹対応</br>
    /// <br>                ・元号表示区分１・２・３</br>
	/// <br>Update Note : 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 　 ・ローカルＤＢ対応</br>
    /// <br>Update Note : 2008/06/04 30414  忍　幸史</br>
    /// <br>                ・「顧客コード自動発番」「得意先削除チェック」「会員情報管理」削除</br>
    /// <br>Update Note : 2010/01/18 30531  大矢　睦美</br>
    /// <br>                ・請求書タイプ毎の出力区分を追加（３項目）</br>
    /// <br>Update Note : 2010/05/25 22008  長内　数馬</br>
    /// <br>                ・オフライン対応</br>
    /// <br>Update Note : 2011/07/19 zhouyu</br>
    /// <br>                ・連番 1028</br>
    /// <br>                  修正内容：連番 1028 在庫仕入入力で、品番入力後に自動で 仕入数=１ と表示され、現在庫数が足されて表示になり分かりずらい</br>
    /// <br>                  PM7では、仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>                  売上伝票入力，仕入伝票入力 も同じ</br>
    /// <br>Update Note : 王君</br>
    /// <br>Date        : 2013/05/02</br>
    /// <br>管理番号    : 10901273-00 2013/06/18配信分 </br>
    /// <br>            : Redmine#35434 商品在庫マスタ起動区分の追加</br>
    /// </remarks>
	public class AllDefSetAcs
	{
		#region -- リモートオブジェクト格納バッファ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// リモートオブジェクト格納バッファ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		private IAllDefSetDB _iAllDefSetDB = null;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.20 TAKAHASHI ADD START
		// 拠点情報取得用
		private SecInfoAcs _secInfoAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.20 TAKAHASHI ADD END

		/// <remarks>管区名称取得用</remarks>
		public ArrayList areaKindList;
		private Hashtable areaKindTable;
		// 2007.05.23 deleted by T-Kidate : MobileKingでは使用しない
        //private AreaGroupAcs areaGroupAcs;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.26 TAKAHASHI ADD START
		// Static格納用HashTable
		private static Hashtable _static_AllDefSetTable = null;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.26 TAKAHASHI ADD END

		//----- ueno add ---------- start 2008.01.31
		// ローカルＤＢモード        
		private static bool _isLocalDBRead = false;	// デフォルトはリモート	        
		//----- ueno add ---------- end 2008.01.31	

		#endregion

        #region [ローカルアクセス用]
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        /// <summary> ローカルアクセスオブジェクト </summary>
        private AllDefSetLcDB _allDefSetLcDB = null;
        #endregion

		#region -- コンストラクタ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		static AllDefSetAcs()
		{
			// Static格納用HashTable
			_static_AllDefSetTable = new Hashtable();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// <br></br>
		/// <br>Note       : オフライン対応</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public AllDefSetAcs()
		{
            // -- UPD 2010/05/25 --------------------------->>>
            ////オンラインの場合
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iAllDefSetDB = (IAllDefSetDB)MediationAllDefSetDB.GetAllDefSetDB();
            //    }
            //    catch(Exception)
            //    {
            //        // オフライン時はnullをセット
            //        this._iAllDefSetDB = null;
            //    }
            //}
            //else
            //// オフラインの場合
            //{
            //    // オフラインシリアライズデータ作成部品I/O
            //    OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            //    // HashTableのKey設定
            //    string [] keyList = new string[1];
            //    keyList[0] = LoginInfoAcquisition.EnterpriseCode;

            //    // ローカルファイル読込み処理
            //    object wkObj = offlineDataSerializer.DeSerialize("AllDefSetAcs", keyList);

            //    ArrayList wkList = wkObj as ArrayList;

            //    // 全体初期値設定ワーククラス（ArrayList）→UIクラス（Static）変換処理
            //    CopyToAllDefSetFromAllDefSetWork(wkList);
            //}

            try
            {
                // リモートオブジェクト取得
                this._iAllDefSetDB = (IAllDefSetDB)MediationAllDefSetDB.GetAllDefSetDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iAllDefSetDB = null;
            }
            // -- UPD 2010/05/25 ---------------------------<<<

			//----- ueno del ---------- start 2008.01.31
			// ローカルＤＢ対応により取得位置変更
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.20 TAKAHASHI ADD START
			// 拠点情報取得用
			//this._secInfoAcs = new SecInfoAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.20 TAKAHASHI ADD END
			//----- ueno del ---------- end 2008.01.31

			// 管区名称取得用
			this.areaKindList = null;
			this.areaKindTable = new Hashtable();
            // 2007.05.23 deleted by T-Kidate : MobileKingでは使用しない
			//this.areaGroupAcs = new AreaGroupAcs();

            //ローカルアクセスオブジェクトインスタンス化
            _allDefSetLcDB = new AllDefSetLcDB();
		}
		#endregion

		#region -- オンラインモード 列挙型 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// オンラインモードの列挙型です。
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}
		#endregion

		#region -- オンラインモード取得処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iAllDefSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}
		#endregion

		#region -- 読み込み処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 読み込み処理
		/// </summary>
		/// <param name="allDefSet">UIデータクラス</param>
		/// <param name="enterpriseCode">企業コード</param> 
		/// <param name="sectionCode">拠点コード</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
        public int Read(out AllDefSet allDefSet, string enterpriseCode, string sectionCode)
        {
            return Read(out allDefSet, enterpriseCode, sectionCode, SearchMode.Remote);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="allDefSet">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2006.05.25</br>
        /// </remarks>
        public int Read(out AllDefSet allDefSet, string enterpriseCode, string sectionCode, SearchMode searchMode)
		{
			try
			{
                int status = 0;

                allDefSet = null;

				//----- ueno add---------- start 2008.01.31
				_isLocalDBRead = searchMode == SearchMode.Local ? true : false;
				//----- ueno add---------- end 2008.01.31

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI DELETE START
                //AllDefSetWork allDefSetWork = new AllDefSetWork();
                //allDefSetWork.EnterpriseCode = enterpriseCode;
                //allDefSetWork.SectionCode    = sectionCode;

                //// オンラインの場合
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                //    // ワーククラス→ＸＭＬ（バイナリ化）
                //    byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);

                //    // 読み込み処理
                //    status = this._iAllDefSetDB.Read(ref parabyte,0);

                //    if (status == 0)
                //    {
                //        // ワーククラス←ＸＭＬ
                //        allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

                //        // UIデータクラス←ワーククラス
                //        allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                //        // HashTableのKey
                //        string keysOfHashTable = allDefSet.SectionCode;

                //        // スタティック領域に情報を保持
                //        _static_AllDefSetTable[keysOfHashTable] = allDefSet;
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                //    }
                //}
                //// オフラインの場合
                //else
                //{
                //    status = ReadStaticMemory(out allDefSet, enterpriseCode, sectionCode);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI DELETE END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                if ((_static_AllDefSetTable == null) || (_static_AllDefSetTable.Count <= 0))
                {
                    ArrayList dataList;

                    status = this.SearchAll(out dataList, enterpriseCode, searchMode);
                }
                
                status = ReadStaticMemory(out allDefSet, enterpriseCode, sectionCode);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI ADD END

				return status;
			}
			catch (Exception)
			{				    
                allDefSet = null;
                // オフライン時はnullをセット
                this._iAllDefSetDB = null;
                // 通信エラーは-1を戻す
                return -1;                
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static領域保持処理（オフライン対応）
		/// </summary>
		/// <param name="allDefSet">全体初期値設定クラス</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 取得した値をStatic領域に保持します。（オフライン対応）</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int ReadStaticMemory(out AllDefSet allDefSet, string enterpriseCode, string sectionCode)
		{
			allDefSet = new AllDefSet();

			// HashTableのKey
			string keysOfHashTable = sectionCode;

			if (_static_AllDefSetTable == null)
			{
				return -1;
			}

			// Staticからデータを検索する
			if (_static_AllDefSetTable[keysOfHashTable] == null)
			{
				return 4;
			}
			else
			{
				allDefSet = (AllDefSet)_static_AllDefSetTable[keysOfHashTable];
			}
			
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static領域全件取得処理（オフライン対応）
		/// </summary>
		/// <param name="retList">クラスList</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : Static領域のデータ全件を取得します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			if (_static_AllDefSetTable == null)
			{
				return -1;
			}
			else if (_static_AllDefSetTable.Count == 0)
			{
				return 9;
			}

			foreach (AllDefSet allDefSet in _static_AllDefSetTable.Values)
			{
				sortedList.Add(allDefSet.SectionCode, allDefSet);
			}

			retList.AddRange(sortedList.Values);

			return 0;
		}
		#endregion

		#region -- デシリアライズ処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	デシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>UIデータクラスリスト</returns>
		/// <remarks>
		/// <br>Note       : ワーククラスをデシリアライズします。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public AllDefSet Deserialize(string fileName)
		{
			AllDefSet allDefSet = null;
			// ファイル名を渡してワーククラスをデシリアライズする
			AllDefSetWork allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(fileName, typeof(AllDefSetWork));

			//デシリアライズ結果をUIクラスへコピー
			if (allDefSetWork != null)
			{
				allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);
			}

			return allDefSet;
		}
		#endregion

		#region -- 全体初期値設定レコード追加処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期値設定レコード追加処理
		/// </summary>
		/// <param name="allDefSet">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定レコードを追加します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分 </br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private int AddNewAllDefSetRecord(out AllDefSet allDefSet, string enterpriseCode, string sectionCode)
		{
			allDefSet = new AllDefSet();  

			// 企業コード
			allDefSet.EnterpriseCode = enterpriseCode;

			// 拠点コード  
			allDefSet.SectionCode    = sectionCode;				 

            // ↓ 20061205 18322 d
			//// 管区コード 初期値
			//allDefSet.DistrictCode = 4;
            //


			//// 初期表示住所コード1 初期値
			//allDefSet.DefDispAddrCd1 = 0;
            //
			//// 初期表示住所コード2 初期値
			//allDefSet.DefDispAddrCd2 = 0;
            //
			//// 初期表示住所コード3 初期値
			//allDefSet.DefDispAddrCd3 = 0;
            // ↑ 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
			// 初期表示住所コード4 初期値
//			allDefSet.DefDispAddrCd4 = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END

            // ↓ 20061205 18322 d
            //// 初期表示住所1 初期値
			//allDefSet.DefDispAddress = "";
            //
			//// 88No.の自賠責算定区分 初期値
			//allDefSet.No88AutoLiaCalcDiv = 0;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 顧客コード自動発番区分 初期値
			allDefSet.CustCdAutoNumbering = 0;

			// 得意先削除チェック区分 初期値
			allDefSet.CustomerDelChkDivCd = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // 初期表示顧客締日 初期値
			allDefSet.DefDspCustTtlDay = 31;

			// 初期表示顧客集金日 初期値
			allDefSet.DefDspCustClctMnyDay = 10;

			// 初期表示集金月区分 初期値
			allDefSet.DefDspClctMnyMonthCd = 1;

			// 初期表示個人・法人区分 初期値
			allDefSet.IniDspPrslOrCorpCd = 0;

			// 初期表示DM区分 初期値
			allDefSet.InitDspDmDiv = 0;

			// 初期表示請求書出力区分 初期値
			allDefSet.DefDspBillPrtDivCd = 0;

            // ↓ 20061205 18322 d
			//// 車両確定選択方式 初期値
			//allDefSet.CarFixSelectMethod = 0;
            //
            //// 陸運事務所番号 初期値
            //allDefSet.LandTransBranchCd = 0;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // 会員情報管理区分 初期値
            allDefSet.MemberInfoDispCd = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			// 総額表示方法区分 初期値
			allDefSet.TotalAmountDispWayCd = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // 元号表示区分１ 初期値
            allDefSet.EraNameDispCd1 = 0;
            // 元号表示区分２ 初期値
            allDefSet.EraNameDispCd2 = 0;
            // 元号表示区分３ 初期値
            allDefSet.EraNameDispCd3 = 0;

            // 商品番号入力区分
            allDefSet.GoodsNoInpDiv = 0;
            // 消費税自動補正区分
            allDefSet.CnsTaxAutoCorrDiv = 0;
            // 残数管理区分
            allDefSet.RemainCntMngDiv = 0;
            // メモ複写区分
            allDefSet.MemoMoveDiv = 0;
            // 残数自動表示区分
            allDefSet.RemCntAutoDspDiv = 0;
            // 総額表示掛率適用区分
            allDefSet.TtlAmntDspRateDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            //初期表示合計請求書出力区分　初期値
            allDefSet.DefTtlBillOutput = 0;
            //初期表示明細請求書出力区分　初期値
            allDefSet.DefDtlBillOutput = 0;
            //初期表示伝票合計請求書出力区分　初期値
            allDefSet.DefSlTtlBillOutput = 0;
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<

            //ADD 2011/07/19
            //仕入・出荷後数表示区分
            allDefSet.DtlCalcStckCntDsp = 0;
            //ADD 2011/07/19

            // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
            // 商品在庫マスタ起動区分
            allDefSet.GoodsStockMSTBootDiv = 0;
            // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

			// 新規登録処理
			int status = this.Write(ref allDefSet);
			return status;
		}
		#endregion

		#region -- 登録･更新処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 登録・更新処理
		/// </summary>
		/// <param name="allDefSet">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 登録・更新処理を行います。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Write(ref AllDefSet allDefSet)
		{		
			// UIデータクラス→ワーク
			AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);

			int status = 0;

			try
			{
				// 書き込み処理
				status = this._iAllDefSetDB.Write(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡してワーククラスをデシリアライズする
					allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));
					// クラス内メンバコピー
					allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                    //_static_AllDefSetTable[allDefSet.SectionCode] = allDefSet;
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI ADD END
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iAllDefSetDB = null;
				// 通信エラーは-1を戻す
				status = -1;
			}
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 登録・更新処理（オフライン対応）
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 登録・更新処理を行います。（オフライン対応）</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status = 0;

			if (_static_AllDefSetTable.Count != 0)
			{
				// HashTableのKey
				string [] keyList = new string[1];
				keyList[0] = LoginInfoAcquisition.EnterpriseCode;

				AllDefSetWork allDefSetWork = new AllDefSetWork();

				ArrayList allDefSetList = new ArrayList();

				foreach (AllDefSet allDefSet in _static_AllDefSetTable.Values)
				{
					allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);
					allDefSetList.Add(allDefSetWork);
				}

				// 全体初期値設定ワーク→（バイナリ）
				status = offlineDataSerializer.Serialize("AllDefSetAcs", keyList, allDefSetList);
			}

			return status;
		}
		#endregion

		#region -- 削除処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 論理削除処理
		/// </summary>
		/// <param name="allDefSet">全体初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の論理削除を行います。（未実装）</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int LogicalDelete(ref AllDefSet allDefSet)
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            try
            {
                AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);
                // 拠点情報論理削除
                int status = this._iAllDefSetDB.LogicalDelete(ref parabyte);
                if (status == 0)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(AllDefSetWork));
                    // クラス内メンバコピー
                    allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iAllDefSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 物理削除処理
		/// </summary>
		/// <param name="allDefSet">全体初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の物理削除を行います。（未実装）</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Delete(AllDefSet allDefSet)
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            try
            {
                AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);
                // 拠点情報物理削除
                int status = this._iAllDefSetDB.Delete(parabyte);
                if (status == 0)
                {
                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iAllDefSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}
		#endregion

		#region -- 検索･復活処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntProc(out retTotalCnt, enterpriseCode, 0);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期値設定件数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定件数の検索を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		private int SearchCntProc(out int retTotalCnt,string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			AllDefSetWork allDefSetWork = new AllDefSetWork();

			allDefSetWork.EnterpriseCode = enterpriseCode;
			
			//	XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);

			//	全体初期値設定件数検索
			int status = this._iAllDefSetDB.SearchCnt(out retTotalCnt, parabyte, 0,logicalMode);

			if ( status != 0 ) retTotalCnt = 0;

			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期値設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;            
			return SearchProc(out retList,out retTotalCnt,out nextData, enterpriseCode, 0, 0, null, SearchMode.Remote);            
		}

		//----- ueno add---------- start 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期値設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
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
		//----- ueno add---------- end 2008.01.31

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期値設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {            
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);            
        }

        /// <summary>
        /// 全体初期値設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2006.05.25</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 件数指定全体初期値設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevAllDefSet">前回最終全体初期値設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して車販書類全体設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,AllDefSet prevAllDefSet)
		{			
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevAllDefSet, SearchMode.Remote);
            
		}

		//----- ueno add---------- start 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 件数指定全体初期値設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevAllDefSet">前回最終全体初期値設定データオブジェクト（初回はnull指定必須）</param>			
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して車販書類全体設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, AllDefSet prevAllDefSet, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevAllDefSet, searchMode);
		}
		//----- ueno add---------- end 2008.01.31

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 件数指定全体初期値設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevCSlpPrtSetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevAllDefSet">前回最終全体初期値設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して全体初期値設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,AllDefSet prevAllDefSet)
		{			    
			return SearchProc(out retList,out retTotalCnt, out nextData,enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevAllDefSet, SearchMode.Remote);            
		}

		//----- ueno add---------- start 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 件数指定全体初期値設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevCSlpPrtSetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevAllDefSet">前回最終全体初期値設定データオブジェクト（初回はnull指定必須）</param>			
		/// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して全体初期値設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
		/// <br>Programmer : 30167　上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, AllDefSet prevAllDefSet, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevAllDefSet, searchMode);
		}
		//----- ueno add---------- end 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全体初期値設定論理削除復活処理
		/// </summary>
		/// <param name="allDefSet">全体初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の復活を行います。（未実装）</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Revival(ref AllDefSet allDefSet)
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            try
            {
                AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);
                // 復活処理
                int status = this._iAllDefSetDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(AllDefSetWork));
                    // クラス内メンバコピー
                    allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();

                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iAllDefSetDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/		
		/// <summary>
		/// 全体初期値設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>  
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevAllDefSet">前回最終車販書類全体設定データオブジェクト（初回はnull指定必須）</param>
        /// <param name="searchMode">検索モード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定の検索処理を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.16</br>
        /// <br></br>
        /// <br>UpdateNote : 2007.05.25　19026　湯山　美樹</br>
        /// <br>             ローカルアクセス対応。シグネチャ変更（searchMode追加）</br>
		/// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, AllDefSet prevAllDefSet, SearchMode searchMode)
		{
			//----- ueno add---------- start 2008.01.31
			_isLocalDBRead = searchMode == SearchMode.Local ? true : false;
			//----- ueno add---------- end 2008.01.31

			AllDefSetWork allDefSetWork = new AllDefSetWork();

			if (prevAllDefSet != null)
			{
				allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(prevAllDefSet);
			}

			allDefSetWork.EnterpriseCode = enterpriseCode;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// 削除されていない拠点コード確保用
			ArrayList aliveSectionCodeList = new ArrayList();
            
            // 拠点コードのコレクションを取得
			int sectionStatus = GetAliveSectionCodeList(out aliveSectionCodeList, enterpriseCode);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // 次データ有無初期化
			nextData = false;

			// 読込対象データ総件数0で初期化
			retTotalCnt = 0;

			retList = new ArrayList();
			retList.Clear();

			ArrayList allDefSetWorkList = new ArrayList();
			allDefSetWorkList.Clear();

			// 拠点情報取得処理
			ArrayList wkList = new ArrayList() ;
			wkList.Clear();

			int status = 0;

			object paraobj = allDefSetWork;
			object retobj = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2007.05.23 T-Kidate DELETE START
            //this.MakeAreaKindTable(enterpriseCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<2007.05.23 T-Kidate DELETE END

            // ○● 2007.05.25 湯山 オフラインでもオンラインでも同じ処理 ●○
            //// オフラインの場合
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);
            //}
            //// オンラインの場合
            //else
            //{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                if ((_static_AllDefSetTable != null) && (_static_AllDefSetTable.Count > 0))
                {
                    status = this.SearchStaticMemory(out retList);
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                else
                {
                    // 全体設定検索
                    
                    if (searchMode == SearchMode.Remote)
                    {
                        status = this._iAllDefSetDB.Search(out retobj, paraobj, 0, logicalMode);
                    }
                    // ローカルアクセス対応  -- 2007.05.25 湯山
                    else                                       
                    {
                        List<AllDefSetWork> list;
                        status = this._allDefSetLcDB.Search(out list, (AllDefSetWork)paraobj, 0, logicalMode);
                        ArrayList al = new ArrayList(list);
                        retobj = (object)al;
                    }

                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {

                        allDefSetWorkList = retobj as ArrayList;

                        if (allDefSetWorkList == null)
                        {
                            return status; //7
                        }

                        foreach (AllDefSetWork wkallDefSetWork in allDefSetWorkList)
                        {
                            //wkList.Add(CopyToAllDefSetFromAllDefSetWork(wkallDefSetWork));  // DEL 2008/06/04
                            retList.Add(CopyToAllDefSetFromAllDefSetWork(wkallDefSetWork));  // ADD 2008/06/04
                        }

                        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                        // 拠点がある場合
                        if (sectionStatus == 0)
                        {
                            foreach (string sectionCode in aliveSectionCodeList)
                            {
                                AllDefSet allDefSet = null;

                                for (int ix = 0; ix < wkList.Count; ix++)
                                {

                                    if (((AllDefSet)wkList[ix]).SectionCode.TrimEnd() == sectionCode.TrimEnd())
                                    {
                                        // 拠点があるのでリストに追加
                                        allDefSet = (AllDefSet)wkList[ix];
                                        retList.Add(allDefSet);
                                    }
                                }

                                // 拠点はあるが全体初期値設定に無いとき
                                if (allDefSet == null)
                                {
                                    // 拠点情報に合わせてレコードを追加
                                    int st = AddNewAllDefSetRecord(out allDefSet, enterpriseCode, sectionCode);

                                    if (st == 0)
                                    {
                                        retList.Add(allDefSet);
                                    }
                                }

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                                // HashTableのKey
                                string keysOfHashTable = allDefSet.SectionCode;

                                // スタティック領域に情報を保持
                                _static_AllDefSetTable[keysOfHashTable] = allDefSet;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                            }
                        }
                           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                        // 読込対象データ総件数←ArrayListの件数
                        retTotalCnt = retList.Count;
                    }
                }

				// STATUS を設定
				if( ( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) && 
					( retList.Count == 0 ) ) {
					status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
				}
			//}
			// 全件リードの場合は戻り値の件数をセット
			if (readCnt == 0)
			{
				retTotalCnt = retList.Count;
			}

			return status;
		}
		#endregion

        #region -- SetStatic --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// StaticDataの登録・更新
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : StaticDataの登録・更新処理を行います。</br>
        /// <br>Programmer : 23006　高橋 明子</br>
        /// <br>Date       : 2006.09.05</br>
        /// </remarks>
        public static int SetStaticMemory(ArrayList setDataList)
        {
            if ((setDataList == null) || (setDataList.Count <= 0))
            {
                return -1;
            }

            foreach (AllDefSet allDefSet in setDataList)
            {
                string keysOfHashTable = allDefSet.SectionCode;

                _static_AllDefSetTable[keysOfHashTable] = allDefSet;
            }

            return 0;
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（全体初期値設定ワーククラス⇒全体初期値設定クラス）
		/// </summary>
		/// <param name="allDefSetWork">全体初期値設定ワーククラス</param>
		/// <returns>全体初期値設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定ワーククラスから全体初期値設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分 </br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private AllDefSet CopyToAllDefSetFromAllDefSetWork(AllDefSetWork allDefSetWork)
		{
			AllDefSet allDefSet = new AllDefSet();

			allDefSet.CreateDateTime    = allDefSetWork.CreateDateTime;
			allDefSet.UpdateDateTime    = allDefSetWork.UpdateDateTime;
			allDefSet.EnterpriseCode    = allDefSetWork.EnterpriseCode;
			allDefSet.FileHeaderGuid    = allDefSetWork.FileHeaderGuid;
			allDefSet.UpdEmployeeCode   = allDefSetWork.UpdEmployeeCode;
			allDefSet.UpdAssemblyId1    = allDefSetWork.UpdAssemblyId1;
			allDefSet.UpdAssemblyId2    = allDefSetWork.UpdAssemblyId2;
			allDefSet.LogicalDeleteCode = allDefSetWork.LogicalDeleteCode;
			allDefSet.SectionCode       = allDefSetWork.SectionCode;

            // ↓ 20061205 18322 d
			//allDefSet.DistrictCode         = allDefSetWork.DistrictCode;
			//allDefSet.DefDispAddrCd1       = allDefSetWork.DefDispAddrCd1;
			//allDefSet.DefDispAddrCd2       = allDefSetWork.DefDispAddrCd2;
			//allDefSet.DefDispAddrCd3       = allDefSetWork.DefDispAddrCd3;
			//allDefSet.DefDispAddress       = allDefSetWork.DefDispAddress;
			//allDefSet.No88AutoLiaCalcDiv   = allDefSetWork.No88AutoLiaCalcDiv;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSet.CustCdAutoNumbering  = allDefSetWork.CustCdAutoNumbering;
			allDefSet.CustomerDelChkDivCd  = allDefSetWork.CustomerDelChkDivCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            allDefSet.DefDspCustTtlDay     = allDefSetWork.DefDspCustTtlDay;
			allDefSet.DefDspCustClctMnyDay = allDefSetWork.DefDspCustClctMnyDay;
			allDefSet.DefDspClctMnyMonthCd = allDefSetWork.DefDspClctMnyMonthCd;
			allDefSet.IniDspPrslOrCorpCd   = allDefSetWork.IniDspPrslOrCorpCd;
			allDefSet.InitDspDmDiv         = allDefSetWork.InitDspDmDiv;
			allDefSet.DefDspBillPrtDivCd   = allDefSetWork.DefDspBillPrtDivCd;

            // ↓ 20061205 18322 d
			//allDefSet.CarFixSelectMethod   = allDefSetWork.CarFixSelectMethod;
            //allDefSet.LandTransBranchCd    = allDefSetWork.LandTransBranchCd;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            allDefSet.MemberInfoDispCd = allDefSetWork.MemberInfoDispCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            //allDefSet.SectionName  = GetSectionName(allDefSetWork.EnterpriseCode, allDefSetWork.SectionCode);

            // ↓ 20061205 18322 d
			//allDefSet.DistrictName = GetDistrictName(allDefSetWork.EnterpriseCode, allDefSetWork.DistrictCode);
            // ↑ 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			allDefSet.TotalAmountDispWayCd = allDefSetWork.TotalAmountDispWayCd;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            allDefSet.EraNameDispCd1 = allDefSetWork.EraNameDispCd1;
            allDefSet.EraNameDispCd2 = allDefSetWork.EraNameDispCd2;
            allDefSet.EraNameDispCd3 = allDefSetWork.EraNameDispCd3;
            allDefSet.GoodsNoInpDiv = allDefSetWork.GoodsNoInpDiv;
            allDefSet.CnsTaxAutoCorrDiv = allDefSetWork.CnsTaxAutoCorrDiv;
            allDefSet.RemainCntMngDiv = allDefSetWork.RemainCntMngDiv;
            allDefSet.MemoMoveDiv = allDefSetWork.MemoMoveDiv;
            allDefSet.RemCntAutoDspDiv = allDefSetWork.RemCntAutoDspDiv;
            allDefSet.TtlAmntDspRateDivCd = allDefSetWork.TtlAmntDspRateDivCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            allDefSet.DefTtlBillOutput = allDefSetWork.DefTtlBillOutput;
            allDefSet.DefDtlBillOutput = allDefSetWork.DefDtlBillOutput;
            allDefSet.DefSlTtlBillOutput = allDefSetWork.DefSlTtlBillOutput;
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD 2011/07/19
            //仕入・出荷後数表示区分
            allDefSet.DtlCalcStckCntDsp = allDefSetWork.DtlCalcStckCntDsp;
            //ADD 2011/07/19

            allDefSet.GoodsStockMSTBootDiv = allDefSetWork.GoodsStockMstBootDiv; // 商品在庫起動区分　// ADD 王君 2013/05/02 Redmine#35434
            return allDefSet;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（全体初期値設定ワーククラス⇒全体初期値設定クラス）
		/// </summary>
		/// <param name="allDefSetWorkList">全体初期値設定ワーククラス</param>
		/// <returns>全体初期値設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定ワーククラスから全体初期値設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分 </br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private void CopyToAllDefSetFromAllDefSetWork(ArrayList allDefSetWorkList)
		{
			// HashTableのKey
			string keyOfHashTable = null;

			// ArrayListが空の場合
			if (allDefSetWorkList == null)
				return;

			foreach (AllDefSetWork allDefSetWork in allDefSetWorkList)
			{
				AllDefSet allDefSet = new AllDefSet();

				keyOfHashTable = allDefSetWork.SectionCode;

				allDefSet.CreateDateTime    = allDefSetWork.CreateDateTime;
				allDefSet.UpdateDateTime    = allDefSetWork.UpdateDateTime;
				allDefSet.EnterpriseCode    = allDefSetWork.EnterpriseCode;
				allDefSet.FileHeaderGuid    = allDefSetWork.FileHeaderGuid;
				allDefSet.UpdEmployeeCode   = allDefSetWork.UpdEmployeeCode;
				allDefSet.UpdAssemblyId1    = allDefSetWork.UpdAssemblyId1;
				allDefSet.UpdAssemblyId2    = allDefSetWork.UpdAssemblyId2;
				allDefSet.LogicalDeleteCode = allDefSetWork.LogicalDeleteCode;
				allDefSet.SectionCode       = allDefSetWork.SectionCode;

                // ↓ 20061205 18322 d
				//allDefSet.DistrictCode   = allDefSetWork.DistrictCode;
				//allDefSet.DefDispAddrCd1 = allDefSetWork.DefDispAddrCd1;
				//allDefSet.DefDispAddrCd2 = allDefSetWork.DefDispAddrCd2;
				//allDefSet.DefDispAddrCd3 = allDefSetWork.DefDispAddrCd3;
				//allDefSet.DefDispAddress       = allDefSetWork.DefDispAddress;
				//allDefSet.No88AutoLiaCalcDiv   = allDefSetWork.No88AutoLiaCalcDiv;
                // ↑ 20061205 18322 d

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                allDefSet.CustCdAutoNumbering = allDefSetWork.CustCdAutoNumbering;
				allDefSet.CustomerDelChkDivCd  = allDefSetWork.CustomerDelChkDivCd;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                
                allDefSet.DefDspCustTtlDay     = allDefSetWork.DefDspCustTtlDay;
				allDefSet.DefDspCustClctMnyDay = allDefSetWork.DefDspCustClctMnyDay;
				allDefSet.DefDspClctMnyMonthCd = allDefSetWork.DefDspClctMnyMonthCd;
				allDefSet.IniDspPrslOrCorpCd   = allDefSetWork.IniDspPrslOrCorpCd;
				allDefSet.InitDspDmDiv         = allDefSetWork.InitDspDmDiv;
				allDefSet.DefDspBillPrtDivCd   = allDefSetWork.DefDspBillPrtDivCd;
                allDefSet.TotalAmountDispWayCd = allDefSetWork.TotalAmountDispWayCd;

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                // 2007.03.05 added by T-Kidate
                allDefSet.MemberInfoDispCd = allDefSetWork.MemberInfoDispCd;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // ↓ 20061205 18322 d
				//allDefSet.CarFixSelectMethod   = allDefSetWork.CarFixSelectMethod;
                //allDefSet.LandTransBranchCd    = allDefSetWork.LandTransBranchCd;
                // ↑ 20061205 18322 d

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
                allDefSet.EraNameDispCd1 = allDefSetWork.EraNameDispCd1;
                allDefSet.EraNameDispCd2 = allDefSetWork.EraNameDispCd2;
                allDefSet.EraNameDispCd3 = allDefSetWork.EraNameDispCd3;
                allDefSet.GoodsNoInpDiv = allDefSetWork.GoodsNoInpDiv;
                allDefSet.CnsTaxAutoCorrDiv = allDefSetWork.CnsTaxAutoCorrDiv;
                allDefSet.RemainCntMngDiv = allDefSetWork.RemainCntMngDiv;
                allDefSet.MemoMoveDiv = allDefSetWork.MemoMoveDiv;
                allDefSet.RemCntAutoDspDiv = allDefSetWork.RemCntAutoDspDiv;
                allDefSet.TtlAmntDspRateDivCd = allDefSetWork.TtlAmntDspRateDivCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

                // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
                allDefSet.DefTtlBillOutput = allDefSetWork.DefTtlBillOutput;
                allDefSet.DefDtlBillOutput = allDefSetWork.DefDtlBillOutput;
                allDefSet.DefSlTtlBillOutput = allDefSetWork.DefSlTtlBillOutput;
                // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
                //ADD 2011/07/19
                //仕入・出荷後数表示区分
                allDefSet.DtlCalcStckCntDsp = allDefSetWork.DtlCalcStckCntDsp;
                //ADD 2011/07/19
                allDefSet.GoodsStockMSTBootDiv = allDefSetWork.GoodsStockMstBootDiv; // 商品在庫起動区分 // ADD 王君 2013/05/02 Redmine#35434 
                
                _static_AllDefSetTable[keyOfHashTable] = allDefSet;

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（全体初期値設定クラス⇒全体初期値設定ワーククラス）
		/// </summary>
		/// <param name="allDefSet">全体初期値設定クラス</param>
		/// <returns>車販書類全体設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 全体初期値設定クラスから全体初期値設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分 </br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		private AllDefSetWork CopyToAllDefSetWorkFromAllDefSet(AllDefSet allDefSet)
		{
			AllDefSetWork allDefSetWork = new AllDefSetWork();

			allDefSetWork.CreateDateTime      = allDefSet.CreateDateTime;
			allDefSetWork.UpdateDateTime      = allDefSet.UpdateDateTime;
			allDefSetWork.EnterpriseCode      = allDefSet.EnterpriseCode;
			allDefSetWork.FileHeaderGuid      = allDefSet.FileHeaderGuid;
			allDefSetWork.UpdEmployeeCode     = allDefSet.UpdEmployeeCode;
			allDefSetWork.UpdAssemblyId1      = allDefSet.UpdAssemblyId1;
			allDefSetWork.UpdAssemblyId2      = allDefSet.UpdAssemblyId2;
			allDefSetWork.LogicalDeleteCode   = allDefSet.LogicalDeleteCode;
			allDefSetWork.SectionCode         = allDefSet.SectionCode;

            // ↓ 20061205 18322 d
			//allDefSetWork.DistrictCode         = allDefSet.DistrictCode;
			//allDefSetWork.DefDispAddrCd1       = allDefSet.DefDispAddrCd1;
			//allDefSetWork.DefDispAddrCd2       = allDefSet.DefDispAddrCd2;
			//allDefSetWork.DefDispAddrCd3       = allDefSet.DefDispAddrCd3;
            // ↑ 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
//			allDefSetWork.DefDispAddrCd4       = allDefSet.DefDispAddrCd4;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			
            // ↓ 20061205 18322 d
			//allDefSetWork.DefDispAddress       = allDefSet.DefDispAddress.TrimEnd();
			//allDefSetWork.No88AutoLiaCalcDiv   = allDefSet.No88AutoLiaCalcDiv;
            // ↑ 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			allDefSetWork.CustCdAutoNumbering  = allDefSet.CustCdAutoNumbering;
			allDefSetWork.CustomerDelChkDivCd  = allDefSet.CustomerDelChkDivCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            allDefSetWork.DefDspCustTtlDay     = allDefSet.DefDspCustTtlDay;
			allDefSetWork.DefDspCustClctMnyDay = allDefSet.DefDspCustClctMnyDay;
			allDefSetWork.DefDspClctMnyMonthCd = allDefSet.DefDspClctMnyMonthCd;
			allDefSetWork.IniDspPrslOrCorpCd   = allDefSet.IniDspPrslOrCorpCd;
			allDefSetWork.InitDspDmDiv         = allDefSet.InitDspDmDiv;
			allDefSetWork.DefDspBillPrtDivCd   = allDefSet.DefDspBillPrtDivCd;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            allDefSetWork.MemberInfoDispCd = allDefSet.MemberInfoDispCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ↓ 20061205 18322 d
			//allDefSetWork.CarFixSelectMethod   = allDefSet.CarFixSelectMethod;
            //allDefSetWork.LandTransBranchCd    = allDefSet.LandTransBranchCd;
            // ↑ 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			allDefSetWork.TotalAmountDispWayCd = allDefSet.TotalAmountDispWayCd;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            allDefSetWork.EraNameDispCd1 = allDefSet.EraNameDispCd1;
            allDefSetWork.EraNameDispCd2 = allDefSet.EraNameDispCd2;
            allDefSetWork.EraNameDispCd3 = allDefSet.EraNameDispCd3;

            allDefSetWork.GoodsNoInpDiv = allDefSet.GoodsNoInpDiv;
            allDefSetWork.CnsTaxAutoCorrDiv = allDefSet.CnsTaxAutoCorrDiv;
            allDefSetWork.RemainCntMngDiv = allDefSet.RemainCntMngDiv;
            allDefSetWork.MemoMoveDiv = allDefSet.MemoMoveDiv;
            allDefSetWork.RemCntAutoDspDiv = allDefSet.RemCntAutoDspDiv;
            allDefSetWork.TtlAmntDspRateDivCd = allDefSet.TtlAmntDspRateDivCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            allDefSetWork.DefTtlBillOutput = allDefSet.DefTtlBillOutput;
            allDefSetWork.DefDtlBillOutput = allDefSet.DefDtlBillOutput;
            allDefSetWork.DefSlTtlBillOutput = allDefSet.DefSlTtlBillOutput;            
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //ADD 2011/07/19
            //仕入・出荷後数表示区分
            allDefSetWork.DtlCalcStckCntDsp = allDefSet.DtlCalcStckCntDsp;
            //ADD 2011/07/19
            allDefSetWork.GoodsStockMstBootDiv = allDefSet.GoodsStockMSTBootDiv;// 商品在庫起動区分 // ADD 王君 2013/05/02 Redmine#35434 
            return allDefSetWork;
		}
		#endregion
		
		#region -- 対象データチェック、名称取得 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 対象データチェック
		/// </summary>
		/// <param name="allDefSet">対象データ</param>
		/// <param name="allDefSetPara">パラメータ</param>
		/// <returns>チェック結果（true:OK false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 対象データとパラメータを比較します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		private bool checkTarGetData(AllDefSet allDefSet, AllDefSet allDefSetPara)
		{
			// 企業コードを比較
			if (allDefSetPara.EnterpriseCode != null)
			{
				if (!allDefSetPara.EnterpriseCode.Equals(allDefSet.EnterpriseCode))
					return false;
			}
			return true;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 拠点名称取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点名称</returns>
		/// <remarks>
		/// <br>Note       : 拠点コードから拠点名称を取得します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// <br></br>
		/// <br>Note       : 拠点情報取得部品対応</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Update Note: 2005.10.20</br>
		/// </remarks>
		public string GetSectionName(string enterpriseCode, string sectionCode)
		{
			//----- ueno add ---------- start 2008.01.31
			// ローカルＤＢ拠点対応
			ConstructSecInfoAcs();
			//----- ueno add ---------- end 2008.01.31

			foreach (SecInfoSet	secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				if (secInfoSet.SectionCode.TrimEnd() == "0")
				{
					return "未登録";
				}
				else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
					(secInfoSet.LogicalDeleteCode == 0))
				{
					return secInfoSet.SectionGuideNm;
				}
			}
			return "未登録";

//			SecInfoSet secInfoSet = new SecInfoSet();
//			SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
//
//			int status = secInfoSetAcs.Read(out secInfoSet, enterpriseCode, sectionCode);
//
//			switch (status)
//			{
//				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//				{
//					if (secInfoSet.LogicalDeleteCode == 0)
//					{
//						return secInfoSet.SectionGuideNm;
//					}
//					else
//					{
//						return "削除済";
//					}
//				}
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					return "未登録";
//				}
//				default :
//				{
//					return "";
//				}
//			}
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ローカルＤＢ対応拠点情報クラス作成処理
		/// </summary>
		/// <returns>Boolean</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		private Boolean ConstructSecInfoAcs()
		{
			if (this._secInfoAcs == null)
			{
				this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
				if (this._secInfoAcs != null)
				{
					return true;
				}
			}
			return false;
		}
		//----- ueno add ---------- end 2008.01.31

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 拠点情報取得処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の検索処理を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.03</br>
		/// <br></br>
		/// <br>Note       : 拠点情報取得部品対応</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Update Note: 2005.10.20</br>
		/// </remarks>
		private int GetAliveSectionCodeList(out ArrayList retList, string enterpriseCode)
        {
            retList = new ArrayList();

			//----- ueno add ---------- start 2008.01.31
			// ローカルＤＢ拠点対応
			ConstructSecInfoAcs();
			//----- ueno add ---------- end 2008.01.31

            if (this._secInfoAcs.SecInfoSetList.Length != 0)
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.31 TAKAHASHI DELETE START
                    //retList.Add(secInfoSet.SectionCode);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.31 TAKAHASHI DELETE END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.31 TAKAHASHI ADD START
                    if (this._secInfoAcs.SecInfoSet.MainOfficeFuncFlag == 0)
                    {
                        // 本社機能フラグが0:拠点の場合、自拠点のデータのみを格納
                        if (this._secInfoAcs.SecInfoSet.SectionCode.TrimEnd() == secInfoSet.SectionCode.TrimEnd())
                        {
                            retList.Add(secInfoSet.SectionCode);
                        }
                    }
                    else
                    {
                        // 本社機能フラグが1:本社の場合、全拠点のデータを格納
                        retList.Add(secInfoSet.SectionCode);
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.31 TAKAHASHI ADD END
                }
                return 0;
            }
            else
            {
                return -1;
            }

            //			SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            //			ArrayList wkList = new ArrayList();
            //			retList = new ArrayList();
            //			int status = secInfoSetAcs.SearchAll(out wkList, enterpriseCode);
            //
            //			if(status==0)
            //			{
            //				foreach(SecInfoSet secInfoSet in wkList)
            //				{
            //					if(secInfoSet.LogicalDeleteCode == 0)
            //					{
            //						retList.Add(secInfoSet.SectionCode);
            //					}
            //				}
            //			}
            //			return status;
        }

        // 2007.05.23 deleted by T-Kidate : MobileKingでは使用しないため　<<<<<<<<<<<<<<<<<<<<<<Start
        /*----------------------------------------------------------------------------------*/
        ///// <summary>
        ///// AreaKindTable作成
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : AreaKindTable作成を作成します。</br>
        ///// <br>Programmer : 23006　高橋 明子</br>
        ///// <br>Date       : 2006.09.05</br>
        ///// </remarks>
        //private void MakeAreaKindTable(string enterpriseCode)
        //{
            
            //// 管区名称読み込み(初回のみ)
            //// 論理削除分は含まない
            //if (this.areaKindTable.Count == 0)
            //{
            //    this.areaKindList = new ArrayList();

            //    int status = this.areaGroupAcs.SearchAll(out areaKindList, enterpriseCode);

            //    foreach (AreaGroup areaGroupWork in areaKindList)
            //    {
            //        if ((areaGroupWork.LogicalDeleteCode == 0) &&
            //            (areaGroupWork.AreaKind == 0))
            //        {
            //            this.areaKindTable.Add(areaGroupWork.AreaGroupCode, areaGroupWork.Clone());
            //        }
            //    }
            //}
            //                                                                <<<<<<<<<<<<End
        //}
		/*----------------------------------------------------------------------------------*/
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<End

		/// <summary>
		/// 管区名称取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="districtCd">管区コード</param>
		/// <returns>管区名称</returns>
		/// <remarks>
		/// <br>Note       : 管区コードから管区名称を取得します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.04</br>
		/// <br></br>
		/// <br>Update Note : 2005.12.19  23006 高橋 明子</br>
		/// <br>				・キャッシュ一本化対応</br>
		/// </remarks>
		private string GetDistrictName(string enterpriseCode, int districtCd)
		{
			//nt status = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2007.05.23 T-Kidate DELETE START
			//AreaGroup areaGroup = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<2007.05.23 T-Kidate DELETE END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI DELETE START
            //// 管区名称読み込み(初回のみ)
            //// 論理削除分は含まない
            //if 	(this.areaKindTable.Count == 0)
            //{	
            //    this.areaKindList = new ArrayList();

            //    status = this.areaGroupAcs.SearchAll(out areaKindList, enterpriseCode);
			
            //    foreach(AreaGroup areaGroupWork in areaKindList)
            //    {
            //        if ((areaGroupWork.LogicalDeleteCode == 0) &&
            //            (areaGroupWork.AreaKind == 0))
            //        {
            //            this.areaKindTable.Add(areaGroupWork.AreaGroupCode, areaGroupWork.Clone());
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI DELETE END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate DELETE START
            //this.MakeAreaKindTable(enterpriseCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate DELETE END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI ADD END
						
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate DELETE START   
			// 管区Bufferから取得
            //areaGroup = (AreaGroup)this.areaKindTable[districtCd];
								
            //// 該当コードが無かった場合StatusにNotFoundを設定
            //if (areaGroup == null)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //    {
            //        if (areaGroup.LogicalDeleteCode != 0)
            //        {
            //            return "削除済";
            //        }
            //        else
            //        {
            //            // 管区名称を返す
            //            return areaGroup.AreaName;
            //        }
					
            //    }
            //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //    {
            //        return "未登録";
            //    }
            //    default:
            //    {
                    return "";
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate DELETE END
			
        }
		#endregion
	}
}
