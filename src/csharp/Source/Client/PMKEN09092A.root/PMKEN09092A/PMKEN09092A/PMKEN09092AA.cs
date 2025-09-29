using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部品代替設定マスタ（ユーザー登録）テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 部品代替設定マスタ（ユーザー登録）テーブルのアクセス制御を行います。</br>
    /// <br>Programmer  : 30413 犬飼</br>
    /// <br>Date        : 2008.07.25</br>
    /// <br>UpdateNote  : 2008/11/28 30462 行澤仁美　バグ修正</br>
    /// </remarks>
    public class PartsSubstUAcs : IGeneralGuideData
    {
        // --------------------------------------------------
		#region Private Members

		// スタティックサーチ用
		private static Hashtable _goodschange_Stc = null;

		// 部品代替設定マスタ（ユーザー登録）リモートオブジェクト格納バッファ
		private IPartsSubstUDB _iPartsSubstUDB = null;
		
		// メーカーアクセスクラス
		private MakerAcs _makerAcs = null;
		
		// メーカーデータ格納用
		private static Hashtable _makerList_Stc = null;
		
		private static bool _isLocalDBRead = false;	// デフォルトはリモート

		// ガイド用
        private const string GUIDE_XML_FILENAME = "PARTSSUBSTUGUIDEPARENT.XML";	    // XMLファイル名
		private const string GUIDE_ENTERPRISECODE_TITLE = "EnterpriseCode";			// 企業コード
		private const string GUIDE_CHGSRCMAKERCD_TITLE = "ChgSrcMakerCd";			// 変換元メーカー
		private const string GUIDE_CHGSRCGOODSNO_TITLE = "ChgSrcGoodsNo";			// 変換元商品番号
		private const string GUIDE_CHGDESTMAKERCD_TITLE = "ChgDestMakerCd";			// 変換先メーカー
		private const string GUIDE_CHGDESTGOODSNO_TITLE = "ChgDestGoodsNo";			// 変換先商品番号

        // ADD 2008/11/28 不具合対応[8317] ---------->>>>>
        /// <summary>ログインユーザー</summary>
        private readonly Employee _loginWorker;           

        /// <summary>自拠点コード</summary>
        private readonly string _ownSectionCode;
        // ADD 2008/11/28 不具合対応[8317] ----------<<<<<
        #endregion 

		#region enum
		/// <summary>
		/// 区分
		/// </summary>
		public enum Division:int
		{
			// ユーザーデータ
			User = 0,
			// 提供データ
			Offer = 1
		}
		#endregion

		#region Constructor

		/// <summary>
        /// 部品代替設定マスタ（ユーザー登録）テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note        : 部品代替設定マスタ（ユーザー登録）テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public PartsSubstUAcs()
		{
			try
			{
				// リモートオブジェクト取得
                this._iPartsSubstUDB = (IPartsSubstUDB)MediationPartsSubstUDB.GetPartsSubstUDB();
				
				// メーカーアクセスクラス
				this._makerAcs = new MakerAcs();
				
				// ローカルフラグ設定
				this._makerAcs.IsLocalDBRead = this.IsLocalDBRead;

                // ADD 2008/11/28 不具合対応[8317] ---------->>>>>
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginWorker = LoginInfoAcquisition.Employee.Clone();
                    this._ownSectionCode = this._loginWorker.BelongSectionCode;
                }
                // ADD 2008/11/28 不具合対応[8317] ----------<<<<<

			}
			catch( Exception )
			{
				// オフライン時はnullをセット
                this._iPartsSubstUDB = null;
			}
		}
		#endregion

        // --------------------------------------------------
        #region Properties
		/// <summary>
		/// ローカルＤＢReadモード
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
        #endregion

		// --------------------------------------------------
		#region GetOnlineMode
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note        : オンラインモードの取得を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int GetOnlineMode()
		{
			// オンラインモードを取得
			if( this._iPartsSubstUDB == null )
			{
				// オフライン
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				// オンライン
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}
		#endregion

		#region メーカー名称取得
		/// <summary>
		/// メーカー名称取得
		/// </summary>
		/// <remarks>
		/// <param name="goodsMakerCd">メーカーコード</param>
		/// <returns>メーカー名称</returns>
		/// <br>Note        : メーカー名称を取得します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public string GetMakerName(int goodsMakerCd)
		{
			string retStr = "";

			if ((_makerList_Stc != null)&&(_makerList_Stc.ContainsKey(goodsMakerCd) == true))
			{
				retStr = _makerList_Stc[goodsMakerCd].ToString();
			}
			return retStr;
		}
		#endregion

		// --------------------------------------------------
		#region Search Methods
		/// <summary>
		///検索処理(論理削除除く)
		/// </summary>
		/// <param name="retList">参照結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			// 部品代替検索
			return SearchCommon(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
		}

		/// <summary>
		///検索処理(論理削除含む)
		/// </summary>
		/// <param name="retList">参照結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode)
		{
            // 部品代替検索
			return SearchCommon(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// マスタ検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="belongSectionCode">拠点コード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : 取得結果をDataSetで返します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode)
		{
			ArrayList retList = new ArrayList();

			int status = 0;

			// マスタサーチ
			status = SearchAll(out retList, enterpriseCode);
			if (status != 0)
			{
				return status;
			}

			ArrayList wkList = retList.Clone() as ArrayList;
			SortedList wkSort = new SortedList();
			string hKey = "";
			
			// --- [全て] --- //
			// そのまま全件返す
			foreach (PartsSubstU wkPartsSubstU in wkList)
			{
				if (wkPartsSubstU.LogicalDeleteCode == 0)
				{
					hKey = CreateHashKey(wkPartsSubstU);
					wkSort.Add(hKey, wkPartsSubstU);
				}
			}

            PartsSubstU[] partsSubstU = new PartsSubstU[wkSort.Count];

			// データを元に戻す
			for (int i = 0; i < wkSort.Count; i++)
			{
                partsSubstU[i] = (PartsSubstU)wkSort.GetByIndex(i);
			}

			byte[] retbyte = XmlByteSerializer.Serialize(partsSubstU);
			XmlByteSerializer.ReadXml(ref ds, retbyte);

			return status;
		}

		/// <summary>
		///検索処理
		/// </summary>
		/// <param name="retList">参照結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除区分</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private int SearchCommon(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = 0;
			bool nextData;
			int retTotalCnt;
			ArrayList list = new ArrayList();
			retList = new ArrayList();
			retList.Clear();
			retTotalCnt = 0;

			_goodschange_Stc = new Hashtable();

			// メーカーマスタ読み込み
			ReadMaker(enterpriseCode);
			
			// ユーザー
			status = SearchUsrProc(ref list, out retTotalCnt, out nextData, enterpriseCode, logicalMode, 0, null);

			retList = list;
            return status;
		}

		/// <summary>
        /// 部品代替設定マスタ検索処理＜ユーザー＞
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevPartsSubst">前回最終部品代替設定オブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定マスタの検索処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private int SearchUsrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsSubstU prevPartsSubst)
		{
			//初期化処理
			int status = 0;
			retTotalCnt = 0;
			nextData = false;
			string hKey;

			//条件抽出クラス(D)の設定
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
			if (prevPartsSubst != null) partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(prevPartsSubst);
            partsSubstUWork.EnterpriseCode = enterpriseCode;

            ArrayList paraList = new ArrayList();
            paraList.Clear();
            object paraobj = partsSubstUWork;
            //object retobj = null;
            object retobj = paraList;
		
			// ローカル
			if (_isLocalDBRead)
			{
                // 新規ではローカルが無さそうなので未処理
			}
			// リモート
			else
			{
                // 部品代替検索
				status = this._iPartsSubstUDB.Search(ref retobj, paraobj, 0, logicalMode);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					paraList = retobj as ArrayList;

					if (paraList != null)
					{
						foreach (PartsSubstUWork wkPartsSubstUWork in paraList)
						{
							hKey = CreateHashKey(wkPartsSubstUWork);
							if (_goodschange_Stc[hKey] != null)
							{
								continue;
							}

							PartsSubstU partsSubstU = CopyToPartsSubstUFromPartsSubstUWork(wkPartsSubstUWork);
							retList.Add(partsSubstU);
							// static保持
							_goodschange_Stc[hKey] = partsSubstU;
						}
					}
					break;
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					break;
				default:
					return status;
			}

			//全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
			return status;
		}

        #endregion

        // --------------------------------------------------
		#region Read Methods
		/// <summary>
        /// 読み込み処理
		/// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="chgSrcMakerCd">変換元コード</param>
        /// <param name="chgSrcGoodsNo">変換元商品番号</param>
        /// <param name="chgDestMakerCd">変換先コード</param>
        /// <param name="chgDestGoodsNo">変換先商品番号</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : マスタ情報の読み込み処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Read(out PartsSubstU partsSubstU, string enterpriseCode, Int32 chgSrcMakerCd, string chgSrcGoodsNo, Int32 chgDestMakerCd, string chgDestGoodsNo)
		{
			int status = 0;

			partsSubstU = new PartsSubstU();
			
			// ユーザー
			status = this.ReadUProc(out partsSubstU, enterpriseCode, chgSrcMakerCd, chgSrcGoodsNo, chgDestMakerCd, chgDestGoodsNo);
			
            return status;
		}

		/// <summary>
        /// 部品代替設定マスタ読み込み処理＜ユーザー＞
		/// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="chgSrcMakerCd">変換元コード</param>
        /// <param name="chgSrcGoodsNo">変換元商品番号</param>
        /// <param name="chgDestMakerCd">変換先コード</param>
        /// <param name="chgDestGoodsNo">変換先商品番号</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定（ユーザー登録）の読み込み処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int ReadUProc(out PartsSubstU partsSubstU, string enterpriseCode, Int32 chgSrcMakerCd, string chgSrcGoodsNo, Int32 chgDestMakerCd, string chgDestGoodsNo)
		{
            int status = 0;
            partsSubstU = null;

            try
            {
                // キー情報をセット
                PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
                partsSubstUWork.EnterpriseCode = enterpriseCode;   // 企業コード
                partsSubstUWork.ChgSrcMakerCd = chgSrcMakerCd;     // 変換元メーカー
                partsSubstUWork.ChgSrcGoodsNo = chgSrcGoodsNo;     // 変換元商品番号
                partsSubstUWork.ChgDestMakerCd = chgDestMakerCd;   // 変換先メーカー
                partsSubstUWork.ChgDestGoodsNo = chgDestGoodsNo;   // 変換先商品番号

                object paraObj = new object();
                paraObj = partsSubstUWork;

				// ローカル
            	if (_isLocalDBRead)
				{
                    // 新規ではローカルが無さそうなので未処理
				}
            	// リモート
				else
				{
                    // 部品代替設定（ユーザー登録）読み込み
                    status = this._iPartsSubstUDB.Read(ref paraObj, 0);
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 結果をメンバコピー
                    partsSubstU = this.CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraObj);
				}
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                partsSubstU = null;
                this._iPartsSubstUDB = null;

                // 通信エラーは-1を返す
				status = -1;
            }
			return status;
		}
        
        #endregion

        // --------------------------------------------------
		#region ReadMaker
		/// <summary>
		/// メーカーデータ読み込み処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : メーカーマスタ情報を全件取得します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private int ReadMaker(string enterpriseCode)
		{
			_makerList_Stc = new Hashtable();
			
			ArrayList makerList;
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			status = this._makerAcs.SearchAll(out makerList, enterpriseCode);

			if ((status == 0) && (makerList.Count > 0))
			{
				foreach (MakerUMnt makerUMnt in (ArrayList)makerList)
				{
					//---------------------------------
					// Key  ：メーカーコード
					// Value：メーカー名称
					//---------------------------------
					_makerList_Stc.Add(makerUMnt.GoodsMakerCd, makerUMnt.MakerName);
				}
			}
			return status;
		}
		#endregion ReadMaker

		// --------------------------------------------------
		#region Write Methods
		/// <summary>
        /// 部品代替設定マスタ登録・更新処理
		/// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定（ユーザー登録）の書き込み処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Write(ref PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                GoodsAcs goodsAcs = new GoodsAcs();
                object paraObj = new object();
                CustomSerializeArrayList csList = new CustomSerializeArrayList();
                string msg = "";

                // ADD 2008/11/28 不具合対応[8317] ---------->>>>>
                #region < 登録データ準備処理 >
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                ArrayList gunitList = new ArrayList();

                GoodsCndtn goodsCndtn = new GoodsCndtn();

                string searchCode;
                int searchType = GetSearchType(partsSubstU.ChgDestGoodsNo, out searchCode);

                // 商品検索条件設定
                goodsCndtn.EnterpriseCode = partsSubstU.EnterpriseCode;
                goodsCndtn.SectionCode = this._ownSectionCode;
                goodsCndtn.GoodsMakerCd = partsSubstU.ChgDestMakerCd;
                goodsCndtn.MakerName = "";
                goodsCndtn.GoodsNo = partsSubstU.ChgDestGoodsNo;
                goodsCndtn.GoodsNoSrchTyp = searchType;

                string message;
                List<GoodsUnitData> list = new List<GoodsUnitData>();

                status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, false, out list, out message);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 該当の商品連結データ取得
                    goodsUnitData = (GoodsUnitData)list[0];

                    // 商品マスタ登録対象？
                    if ((goodsUnitData.OfferKubun == 3) || (goodsUnitData.OfferKubun == 4))
                    {
                        // 商品連結データリストへ追加
                        gunitList.Add(goodsUnitData);
                    }
                }
                #endregion

                // 商品連結データ
                csList.Add(gunitList);
                // ADD 2008/11/28 不具合対応[8317] ----------<<<<<

                // 部品代替設定オブジェクトの追加
                csList.Add(partsSubstU);
                paraObj = csList;

                // 商品マスタクラスを経由して部品代替設定の書き込み
                status = goodsAcs.WriteRelation(ref paraObj, out msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PartsSubstU wkPartsSubstU = (PartsSubstU)((CustomSerializeArrayList)paraObj)[0];
                    partsSubstU = wkPartsSubstU.Clone();
                }

                //PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);

                //ArrayList paraList = new ArrayList();
                //paraList.Add(partsSubstUWork);
                //object paraobj = paraList;

                //// 部品代替設定（ユーザー登録）書き込み
                //status = this._iPartsSubstUDB.Write(ref paraobj);

                //if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    paraList = (ArrayList)paraobj;

                //    partsSubstU = CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraList[0]);
                //}
			}
			catch( Exception )
			{
				// オフライン時はnullをセット
				this._iPartsSubstUDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}
			return status;
		}
		#endregion

		// --------------------------------------------------
		#region LogicalDelete Methods
		/// <summary>
        /// 部品代替設定マスタ論理削除処理
        /// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定（ユーザー登録）の論理削除処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int LogicalDelete(ref PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);
				
				ArrayList paraList = new ArrayList();
				paraList.Add(partsSubstUWork);
				object paraObj = paraList;

                // 部品代替設定（ユーザー登録）論理削除
				status = this._iPartsSubstUDB.LogicalDelete(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
				{
					paraList = (ArrayList)paraObj;
					// クラス内メンバコピー
                    partsSubstU = CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraList[0]);
				}
			}
			catch( Exception )
			{
				// オフライン時はnullをセット
				this._iPartsSubstUDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}
			return status;
        }
		#endregion

		// --------------------------------------------------
		#region Delete Methods

		/// <summary>
        /// 部品代替設定マスタ物理削除処理
		/// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定（ユーザー登録）の物理削除処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Delete(PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);
				
                ArrayList paraList = new ArrayList();
                paraList.Add(partsSubstUWork);
                object paraObj = paraList;

                // 部品代替設定（ユーザー登録）物理削除
                status = this._iPartsSubstUDB.Delete(paraObj);
				
				return status;
			}
			catch (Exception)
			{
				// 通信エラーは-1を返す
				status = -1;
			}
			return status;
		}
		#endregion

		// --------------------------------------------------
		#region Revival Methods
		/// <summary>
        /// 部品代替設定マスタ論理削除復活処理
        /// </summary>
        /// <param name="partsSubstU">部品代替設定（ユーザー登録）オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定（ユーザー登録）の論理削除復活処理を行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Revival(ref PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);
				ArrayList paraList = new ArrayList();
				paraList.Add(partsSubstUWork);
				object paraobj = paraList;

                // 部品代替設定（ユーザー登録）論理削除復活
				status = this._iPartsSubstUDB.RevivalLogicalDelete(ref paraobj);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					paraList = (ArrayList)paraobj;
					// クラス内メンバコピー
                    partsSubstU = CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraList[0]);
				}
				return status;
			}
			catch( Exception )
			{
				// 通信エラーは-1を返す
				status = -1;
			}
			return status;
		}
		#endregion

		// --------------------------------------------------
		#region MemberCopy Methods
        /// <summary>
        /// クラスメンバコピー処理（ユーザー部品代替設定ワーククラス⇒部品代替設定クラス)
		/// </summary>
        /// <param name="partsSubstUWork">ユーザー部品代替設定ワーククラス</param>
        /// <returns>ユーザー部品代替設定クラス</returns>
		/// <remarks>
        /// <br>Note        : ユーザー部品代替設定ワーククラスから
        ///                   ユーザー部品代替設定クラスへメンバコピーを行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private PartsSubstU CopyToPartsSubstUFromPartsSubstUWork(PartsSubstUWork partsSubstUWork)
		{
            PartsSubstU partsSubstU = new PartsSubstU();

			partsSubstU.CreateDateTime			= partsSubstUWork.CreateDateTime;      // 作成日時
			partsSubstU.UpdateDateTime			= partsSubstUWork.UpdateDateTime;      // 更新日時
			partsSubstU.EnterpriseCode			= partsSubstUWork.EnterpriseCode;      // 企業コード
			partsSubstU.FileHeaderGuid			= partsSubstUWork.FileHeaderGuid;      // GUID
			partsSubstU.UpdEmployeeCode		= partsSubstUWork.UpdEmployeeCode;     // 更新従業員コード
			partsSubstU.UpdAssemblyId1			= partsSubstUWork.UpdAssemblyId1;      // 更新アセンブリID1
			partsSubstU.UpdAssemblyId2			= partsSubstUWork.UpdAssemblyId2;      // 更新アセンブリID2
			partsSubstU.LogicalDeleteCode		= partsSubstUWork.LogicalDeleteCode;   // 論理削除区分
			partsSubstU.ChgSrcMakerCd			= partsSubstUWork.ChgSrcMakerCd;       // 変換元メーカー
			partsSubstU.ChgSrcGoodsNo			= partsSubstUWork.ChgSrcGoodsNo;       // 変換元商品番号
			partsSubstU.ChgSrcGoodsNoNoneHp	= partsSubstUWork.ChgSrcGoodsNoNoneHp; // 変換元商品番号(ハイフン無)
			partsSubstU.ChgDestMakerCd			= partsSubstUWork.ChgDestMakerCd;      // 変換先メーカー
			partsSubstU.ChgDestGoodsNo			= partsSubstUWork.ChgDestGoodsNo;      // 変換先商品番号
			partsSubstU.ChgDestGoodsNoNoneHp	= partsSubstUWork.ChgDestGoodsNoNoneHp;// 変換先商品番号(ハイフン無)
			partsSubstU.ApplyStaDate			= partsSubstUWork.ApplyStaDate;        // 適用開始日
			partsSubstU.ApplyEndDate			= partsSubstUWork.ApplyEndDate;        // 適用終了日
			
			return partsSubstU;
		}

        /// <summary>
        /// クラスメンバコピー処理（部品代替設定クラス⇒ユーザー部品代替設定ワーククラス)
		/// </summary>
        /// <param name="partsSubstU">ユーザー部品代替設定クラス</param>
        /// <returns>ユーザー部品代替設定ワーククラス</returns>
		/// <remarks>
        /// <br>Note        : ユーザー部品代替設定クラスから
        ///                   ユーザー部品代替設定ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private PartsSubstUWork CopyToPartsSubstUWorkFromPartsSubstU(PartsSubstU partsSubstU)
		{
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();

			// ハイフンカット
			partsSubstU.ChgSrcGoodsNoNoneHp = partsSubstU.ChgSrcGoodsNo.Replace("-", "");
			partsSubstU.ChgDestGoodsNoNoneHp = partsSubstU.ChgDestGoodsNo.Replace("-", "");

			partsSubstUWork.CreateDateTime			= partsSubstU.CreateDateTime;      // 作成日時
			partsSubstUWork.UpdateDateTime			= partsSubstU.UpdateDateTime;      // 更新日時
			partsSubstUWork.EnterpriseCode			= partsSubstU.EnterpriseCode;      // 企業コード
			partsSubstUWork.FileHeaderGuid			= partsSubstU.FileHeaderGuid;      // GUID
			partsSubstUWork.UpdEmployeeCode		= partsSubstU.UpdEmployeeCode;     // 更新従業員コード
			partsSubstUWork.UpdAssemblyId1			= partsSubstU.UpdAssemblyId1;      // 更新アセンブリID1
			partsSubstUWork.UpdAssemblyId2			= partsSubstU.UpdAssemblyId2;      // 更新アセンブリID2
			partsSubstUWork.LogicalDeleteCode		= partsSubstU.LogicalDeleteCode;   // 論理削除区分
			partsSubstUWork.ChgSrcMakerCd			= partsSubstU.ChgSrcMakerCd;       // 変換元メーカー
			partsSubstUWork.ChgSrcGoodsNo			= partsSubstU.ChgSrcGoodsNo;       // 変換元商品番号
			partsSubstUWork.ChgSrcGoodsNoNoneHp	= partsSubstU.ChgSrcGoodsNoNoneHp; // 変換元商品番号(ハイフン無)
			partsSubstUWork.ChgDestMakerCd			= partsSubstU.ChgDestMakerCd;      // 変換先メーカー
			partsSubstUWork.ChgDestGoodsNo			= partsSubstU.ChgDestGoodsNo;      // 変換先商品番号
			partsSubstUWork.ChgDestGoodsNoNoneHp	= partsSubstU.ChgDestGoodsNoNoneHp;// 変換先商品番号(ハイフン無)
			partsSubstUWork.ApplyStaDate			= partsSubstU.ApplyStaDate;        // 適用開始日
			partsSubstUWork.ApplyEndDate			= partsSubstU.ApplyEndDate;        // 適用終了日
			
			return partsSubstUWork;
		}
		# endregion

		# region HashTable用Key作成
		/// <summary>
		/// HashTable用Key作成
		/// </summary>
        /// <param name="partsSubstU">部品代替設定クラス</param>
		/// <returns>Hash用Key</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定クラスからハッシュテーブル用の
		///				 	  キーを作成します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private string CreateHashKey(PartsSubstU partsSubstU)
		{
			return partsSubstU.ChgSrcMakerCd.ToString("d6") +
					partsSubstU.ChgSrcGoodsNo.PadRight(40) +
					partsSubstU.ChgDestMakerCd.ToString("d6") +
					partsSubstU.ChgDestGoodsNo.PadRight(40);
		}

		/// <summary>
		/// HashTable用Key作成
		/// </summary>
        /// <param name="partsSubstU">部品代替設定ワーククラス</param>
		/// <returns>Hash用Key</returns>
		/// <remarks>
        /// <br>Note        : 部品代替設定ワーククラスからハッシュテーブル用の
		///					  キーを作成します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private string CreateHashKey(PartsSubstUWork partsSubstUWork)
		{
			return partsSubstUWork.ChgSrcMakerCd.ToString("d6") +
					partsSubstUWork.ChgSrcGoodsNo.PadRight(40) +
					partsSubstUWork.ChgDestMakerCd.ToString("d6") +
					partsSubstUWork.ChgDestGoodsNo.PadRight(40);
		}

        #endregion HashTable用Key作成

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="partsSubstU">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note        : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out PartsSubstU partsSubstU)
        {
            int status = -1;
            partsSubstU = new PartsSubstU();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add(GUIDE_ENTERPRISECODE_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
				partsSubstU.ChgSrcMakerCd = Convert.ToInt32(retObj[GUIDE_CHGSRCMAKERCD_TITLE]);	    // 変換元メーカー
				partsSubstU.ChgDestMakerCd = Convert.ToInt32(retObj[GUIDE_CHGDESTMAKERCD_TITLE]);	// 変換先メーカー
                partsSubstU.ChgSrcGoodsNo = retObj[GUIDE_CHGSRCGOODSNO_TITLE].ToString();			// 変換元商品番号
                partsSubstU.ChgDestGoodsNo = retObj[GUIDE_CHGDESTGOODSNO_TITLE].ToString();		    // 変換先商品番号
                
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
        /// <br>Note	    : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // 企業コード設定有り
            if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_TITLE))
            {
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_TITLE].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // マスタテーブル読込み
			status = Search(ref guideList, enterpriseCode);

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

        // ADD 2008/11/28 不具合対応[8317] ---------->>>>>
        #region 検索タイプ取得処理
        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// <br>Note		: 検索する方法を取得する処理を行います。</br>
        /// <br>Programmer  : 30462 行澤</br>
        /// <br>Date        : 2008.11.28</br>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
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
        #endregion 検索タイプ取得処理
        // ADD 2008/11/28 不具合対応[8317] ----------<<<<<
	}
}
