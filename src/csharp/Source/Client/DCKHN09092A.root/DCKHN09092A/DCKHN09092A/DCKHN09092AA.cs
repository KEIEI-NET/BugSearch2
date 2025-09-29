using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

//using Broadleaf.Application.LocalAccess;  // DEL 2008/06/10

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BL商品コードアクセスクラス
    /// </summary>
    /// <remarks>
    /// Note            : BL商品コード情報を取得するためのアクセスクラスです。<br />
    /// Programmer      : 96186 立花裕輔<br />
    /// Date            : 2007.08.01<br />
	/// Update Note     : 2008.01.31 30167 上野　弘貴<br />
	/// 			      ローカルＤＢ対応<br />
	/// Programmer      : 2008.02.27 30167  上野　弘貴</br>
	/// Update Note     : ローカルＤＢ対応（提供データ読込をローカル固定に修正）</br>
    /// <br>UpdateNote  : 2008/06/10 30414　忍　幸史</br>
    /// <br>            : 「BLグループコード」「BLグループコード名称」「商品掛率グループコード」「商品掛率グループ名称」追加</br>
    /// <br>            : 「商品区分グループコード」「商品区分グループコード名称」「商品区分コード」「商品区分コード名称」「商品区分詳細」「商品区分詳細名称」削除</br>
    /// <br>UpdateNote  : 2008/10/22      　照田　貴志</br>
    /// <br>            : バグ修正、仕様変更対応</br>
    // ------------------------------------------------------
    /// </remarks>
	public class BLGoodsCdAcs : IGeneralGuideData
    {
        /// <summary>スタティックサーチ用</summary>
        private static Hashtable _bLGoodsCd_Stc = null;

        /// <summary>リモートオブジェクト格納バッファ</summary>
		//----- ueno del ---------- start 2008.02.27
		//private IBLGoodsCdDB _iBLGoodsCdDB = null;		//提供リモートオブジェクト
		//----- ueno del ---------- end 2008.02.27
		
		private IBLGoodsCdUDB _iBLGoodsCdUDB = null;	//ユーザーリモートオブジェクト

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		//----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// デフォルトはリモート

        private BLGoodsCdLcDB _bLGoodsCdLcDB = null;
		//----- ueno add ---------- end 2008.01.31
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        //private ITbsPartsCodeDB _iTbsPartsCodeDB = null;    // 提供リモートオブジェクト
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

        // --- ADD 2008/10/22 --------------------------------------------------------------------->>>>>
        // BLGoodsCdUMntクラスのBLGoodsCodeをint→Stringにしたもの
        public struct BLGoodsCdUMntWork
        {
            public int BLGloupCode;
            public string BLGoodsCode;                  //int→String
            public string BLGoodsFullName;
            public int BLGoodsGenreCode;
            public string BLGoodsHalfName;
            public string BLGoodsName;
            public System.DateTime CreateDateTime;
            public string CreateDateTimeAdFormal;
            public string CreateDateTimeAdInFormal;
            public string CreateDateTimeJpFormal;
            public string CreateDateTimeJpInFormal;
            public int Division;
            public string DivisionName;
            public string EnterpriseCode;
            public string EnterpriseName;
            public System.Guid FileHeaderGuid;
            public int GoodsRateGrpCode;
            public int LogicalDeleteCode;
            public int OfferDataDiv;
            public System.DateTime OfferDate;
            public string UpdAssemblyId1;
            public string UpdAssemblyId2;
            public System.DateTime UpdateDateTime;
            public string UpdateDateTimeAdFormal;
            public string UpdateDateTimeAdInFormal;
            public string UpdateDateTimeJpFormal;
            public string UpdateDateTimeJpInFormal;
            public string UpdEmployeeCode;
            public string UpdEmployeeName;
        }
        // --- ADD 2008/10/22 ---------------------------------------------------------------------<<<<<

		/// <summary>
        /// BL商品コードアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// -----------------------------------------------------------------------------------
        /// Note       : BL商品コード取得のためのリモートオブジェクトを記述します。<br />
        /// Programmer : 96186  立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------------------
        /// </remarks>
		public BLGoodsCdAcs()
        {
			try
			{
			    // リモートオブジェクト取得
				//----- ueno del ---------- start 2008.02.27
				//this._iBLGoodsCdDB = (IBLGoodsCdDB)MediationBLGoodsCdDB.GetBLGoodsCdDB();
				//----- ueno del ---------- end 2008.02.27

			    this._iBLGoodsCdUDB = (IBLGoodsCdUDB)MediationBLGoodsCdUDB.GetBLGoodsCdUDB();

                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                //this._iTbsPartsCodeDB = (ITbsPartsCodeDB)MediationTbsPartsCodeDB.GetTbsPartsCodeDB();
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
			}
			catch (Exception)
			{
				//----- ueno del ---------- start 2008.02.27
			    //this._iBLGoodsCdDB = null;
				//----- ueno del ---------- end 2008.02.27

			    this._iBLGoodsCdUDB = null;

                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                //this._iTbsPartsCodeDB = null;
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
			}

			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
            //this._bLGoodsCdLcDB = new BLGoodsCdLcDB();  // DEL 2008/06/10
			//----- ueno add ---------- end 2008.01.31
		}

        /// <summary>
        /// BL商品コード全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード名称情報を読み込みます。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
			int status = 0;
			bool nextData;
            int retTotalCnt;
			ArrayList list = new ArrayList();
            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

			_bLGoodsCd_Stc = new Hashtable();

			//ユーザー
			status = SearchUsrProc(ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

			//提供
			//status = SearchOfrProc(ref list, out retTotalCnt, out nextData, ConstantManagement.LogicalMode.GetDataAll, 0, null);
            
            retList = list;
			return 0;
        }

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
        /// BL商品コード検索処理＜ユーザー＞
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevMaker">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コードの検索処理を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2006.12.06<br />
        /// </remarks>
		private int SearchUsrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGoodsCdUMnt prevMaker)
        {
			//初期化処理
            int status = 0;
			retTotalCnt = 0;
            nextData = false;
			string hKey;

			//条件抽出クラス(D)の設定
			BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
			if (prevMaker != null) bLGoodsCdUWork = CopyToBLGoodsCdUWorkFromMaker(prevMaker);
            bLGoodsCdUWork.EnterpriseCode = enterpriseCode;

            ArrayList paraList = new ArrayList();
			ArrayList retobjLlist = new ArrayList();
			paraList.Clear();
            object paraobj = bLGoodsCdUWork;
			object retobj = retobjLlist;

			//リモートオブジェクトの呼び出し
			status = this._iBLGoodsCdUDB.Search(out retobj, paraobj, readCnt, logicalMode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    paraList = retobj as ArrayList;

                    if (paraList != null)
                    {
                        foreach (BLGoodsCdUWork wkBLGoodsCdWork in paraList)
                        {
							//hKey = wkBLGoodsCdWork.BLGoodsCode.ToString("d8") + wkBLGoodsCdWork.BLGoodsCdDerivedNo.ToString("d2");
							hKey = wkBLGoodsCdWork.BLGoodsCode.ToString("d8") ;
							if (_bLGoodsCd_Stc[hKey] != null)
							{
								continue;
							}

							BLGoodsCdUMnt bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdUWork(wkBLGoodsCdWork);
							retList.Add(bLGoodsCdUMnt);
                            // static保持
							_bLGoodsCd_Stc[hKey] = bLGoodsCdUMnt;
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

        ///// <summary>
        ///// BL商品コード検索処理＜提供＞
        ///// </summary>
        ///// <param name="retList">読込結果コレクション</param>
        ///// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        ///// <param name="nextData">次データ有無</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        ///// <param name="readCnt">読込件数</param>
        ///// <param name="prevMaker">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// Note       : BL商品コードの検索処理を行います。<br />
        ///// Programmer : 30414　忍　幸史<br />
        ///// Date       : 2008/06/10<br />
        ///// </remarks>
        //private int SearchOfrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGoodsCdUMnt prevMaker)
        //{
        //    //初期化処理
        //    int status = 0;
        //    retTotalCnt = 0;
        //    nextData = false;
        //    string hKey;

        //    //条件抽出クラス(D)の設定
        //    TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
        //    if (prevMaker != null)
        //    {
        //        tbsPartsCodeWork = CopyToTbsPartsCodeWorkFromMaker(prevMaker);
        //    }

        //    ArrayList paraList = new ArrayList();
        //    paraList.Clear();
        //    object paraobj = tbsPartsCodeWork;
        //    object retobj = null;

        //    status = this._iTbsPartsCodeDB.Search(out retobj, paraobj);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            paraList = retobj as ArrayList;

        //            if (paraList != null)
        //            {
        //                foreach (TbsPartsCodeWork wkTbsPartsCodeWork in paraList)
        //                {
        //                    hKey = wkTbsPartsCodeWork.TbsPartsCode.ToString("d8");
        //                    if (_bLGoodsCd_Stc[hKey] != null)
        //                    {
        //                        continue;
        //                    }

        //                    BLGoodsCdUMnt bLGoodsCdUMnt = CopyToMakerFromTbsPartsCodeWork(wkTbsPartsCodeWork);
        //                    retList.Add(bLGoodsCdUMnt);
        //                    // static保持
        //                    _bLGoodsCd_Stc[hKey] = bLGoodsCdUMnt;
        //                }
        //            }
        //            break;
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            break;
        //        default:
        //            return status;
        //    }

        //    //全件リードの場合は戻り値の件数をセット
        //    if (readCnt == 0) retTotalCnt = retList.Count;
        //    return status;
        //}

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// BL商品コード検索処理＜提供＞
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevMaker">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// Note       : BL商品コードの検索処理を行います。<br />
		/// Programmer : 96186 立花裕輔<br />
		/// Date       : 2006.12.06<br />
		/// </remarks>
		private int SearchOfrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGoodsCdUMnt prevMaker)
		{
			//初期化処理
			int status = 0;
			retTotalCnt = 0;
			nextData = false;
			string hKey;

			//条件抽出クラス(D)の設定
			BLGoodsCdWork bLGoodsCdWork = new BLGoodsCdWork();
			if (prevMaker != null) bLGoodsCdWork = CopyToBLGoodsCdWorkFromMaker(prevMaker);

			ArrayList paraList = new ArrayList();
			paraList.Clear();
			object paraobj = bLGoodsCdWork;
			object retobj = null;

			//----- ueno upd ---------- start 2008.02.27
			// 提供データはローカル固定
			List<BLGoodsCdWork> bLGoodsCdWorkList = new List<BLGoodsCdWork>();
            //status = this._bLGoodsCdLcDB.Search(out bLGoodsCdWorkList, bLGoodsCdWork, 0, logicalMode);  // DEL 2008/06/10
			
			if(status == 0)
			{
				ArrayList al = new ArrayList();
				al.AddRange(bLGoodsCdWorkList);
				retobj = (object)al;
			}
			//----- ueno upd ---------- end 2008.02.27

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					paraList = retobj as ArrayList;

					if (paraList != null)
					{
						foreach (BLGoodsCdWork wkBLGoodsCdWork in paraList)
						{
							//hKey = wkBLGoodsCdWork.BLGoodsCode.ToString("d8") + wkBLGoodsCdWork.BLGoodsCdDerivedNo.ToString("d2");
							hKey = wkBLGoodsCdWork.BLGoodsCode.ToString("d8");
							if (_bLGoodsCd_Stc[hKey] != null)
							{
								continue;
							}

							BLGoodsCdUMnt bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdWork(wkBLGoodsCdWork);
							retList.Add(bLGoodsCdUMnt);
							// static保持
							_bLGoodsCd_Stc[hKey] = bLGoodsCdUMnt;
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

        /// <summary>
		/// BL商品コード読み込みメイン処理
        /// </summary>
        /// <param name="maker">BL商品コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">BL商品コードコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード名称情報を読み込みます。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int Read(out BLGoodsCdUMnt bLGoodsCdUMnt, string enterpriseCode, int bLGoodsCode, int bLGoodsCdDerivedNo)
		{
			int status = 0;

			bLGoodsCdUMnt = new BLGoodsCdUMnt();

			//ユーザー読み込み
			status = ReadUWork(out bLGoodsCdUMnt, enterpriseCode, bLGoodsCode, bLGoodsCdDerivedNo);
			if (status == 0) return(status);

			//BL商品コード読み込み
			status = ReadWork(out bLGoodsCdUMnt, bLGoodsCode, bLGoodsCdDerivedNo);
            return 
                (status);
		}

		/// <summary>
		/// BL商品コード読み込み処理＜提供＞
		/// </summary>
		/// <param name="maker">BL商品コードオブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="makerCode">BL商品コードコード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// Note       : BL商品コード名称情報を読み込みます。<br />
		/// Programmer : 96186 立花裕輔<br />
		/// Date       : 2007.08.01<br />
		/// </remarks>
		private int ReadWork(out BLGoodsCdUMnt bLGoodsCdUMnt, int bLGoodsCode, int bLGoodsCdDerivedNo)
		{
			int status = 0;
			bLGoodsCdUMnt = null;
			try
			{
				// ｢D｣に対して入力パラメータを格納する
				BLGoodsCdWork bLGoodsCdWork = new BLGoodsCdWork();
				bLGoodsCdWork.BLGoodsCode = bLGoodsCode;
				//bLGoodsCdWork.BLGoodsCdDerivedNo = bLGoodsCdDerivedNo; 

				// レスポンス
				ArrayList retList = new ArrayList();

				//----- ueno upd ---------- start 2008.02.27
				// 提供データはローカル固定
                //status = this._bLGoodsCdLcDB.Read(ref bLGoodsCdWork, 0);  // DEL 2008/06/10
				//----- ueno upd ---------- end 2008.02.27
				
				// 成功したら取得データを抽出
				if (status == 0)
				{
					// XMLの読み込み
					bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdWork(bLGoodsCdWork);
				}
				return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				bLGoodsCdUMnt = null;
				//オフライン時はnullをセット
				//this._iBLGoodsCdDB = null;  // iitani d 2007.05.21
				return -1;
			}
			//return status;
		}
        
        /// <summary>
        /// BL商品コード読み込み処理＜提供＞
        /// </summary>
        /// <param name="maker">BL商品コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">BL商品コードコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード名称情報を読み込みます。<br />
        /// Programmer : 30414　忍　幸史<br />
        /// Date       : 2008/06/10<br />
        /// </remarks>
        private int ReadWork(out BLGoodsCdUMnt bLGoodsCdUMnt, int bLGoodsCode, int bLGoodsCdDerivedNo)
        {
            int status = 0;
            bLGoodsCdUMnt = null;

            try
            {
                // ｢D｣に対して入力パラメータを格納する
                TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
                tbsPartsCodeWork.TbsPartsCode = bLGoodsCode;

                // レスポンス
                ArrayList retList = new ArrayList();

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(tbsPartsCodeWork);

                status = this._iTbsPartsCodeDB.Read(ref parabyte);

                // 成功したら取得データを抽出
                if (status == 0)
                {
                    // XMLの読み込み
                    bLGoodsCdUMnt = CopyToMakerFromTbsPartsCodeWork(tbsPartsCodeWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                bLGoodsCdUMnt = null;

                return -1;
            }
        }
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// BL商品コード読み込みメイン処理
        /// </summary>
        /// <param name="bLGoodsCdUMnt">BL商品コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード名称情報を読み込みます。<br />
        /// Programmer : 30414 忍 幸史<br />
        /// Date       : 2008/06/10<br />
        /// </remarks>
        public int Read(out BLGoodsCdUMnt bLGoodsCdUMnt, string enterpriseCode, int bLGoodsCode)
        {
            int status = 0;

            bLGoodsCdUMnt = new BLGoodsCdUMnt();

            //ユーザー読み込み
            status = ReadUWork(out bLGoodsCdUMnt, enterpriseCode, bLGoodsCode);
            //if (status == 0)
            //{
            //    return (status);
            //}

            ////BL商品コード読み込み
            //status = ReadWork(out bLGoodsCdUMnt, bLGoodsCode);

            return (status);
        }

        /// <summary>
		/// BL商品コード読み込み処理＜ユーザー＞
        /// </summary>
        /// <param name="bLGoodsCdUMnt">BL商品コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード名称情報を読み込みます。<br />
        /// Programmer : 30414 忍 幸史<br />
        /// Date       : 2008/06/26<br />
        /// </remarks>
		private int ReadUWork(out BLGoodsCdUMnt bLGoodsCdUMnt, string enterpriseCode, int bLGoodsCode)
        {
			int status = 0;
			bLGoodsCdUMnt = null;
			try
            {
                // ｢D｣に対して入力パラメータを格納する
                BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
                bLGoodsCdUWork.EnterpriseCode = enterpriseCode;
				bLGoodsCdUWork.BLGoodsCode = bLGoodsCode;

                // レスポンス
                ArrayList retList = new ArrayList();

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(bLGoodsCdUWork);

                // BL商品コード名称読み込み(ローカルDB)
                status = this._iBLGoodsCdUDB.Read(ref parabyte, 0);

                // 成功したら取得データを抽出
                if (status == 0)
                {
					// デシリアライズ漏れ対応
                    // XMLの読み込み
					bLGoodsCdUWork = (BLGoodsCdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(BLGoodsCdUWork));

					bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdUWork(bLGoodsCdUWork);
                }
                //}
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
				bLGoodsCdUMnt = null;
                return -1;
            }
		}

        ///// <summary>
        ///// BL商品コード読み込み処理＜提供＞
        ///// </summary>
        ///// <param name="bLGoodsCdUMnt">BL商品コードオブジェクト</param>
        ///// <param name="bLGoodsCode">BL商品コード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// Note       : BL商品コード名称情報を読み込みます。<br />
        ///// Programmer : 30414　忍　幸史<br />
        ///// Date       : 2008/06/10<br />
        ///// </remarks>
        //private int ReadWork(out BLGoodsCdUMnt bLGoodsCdUMnt, int bLGoodsCode)
        //{
        //    int status = 0;
        //    bLGoodsCdUMnt = null;

        //    try
        //    {
        //        // ｢D｣に対して入力パラメータを格納する
        //        TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
        //        tbsPartsCodeWork.TbsPartsCode = bLGoodsCode;

        //        // レスポンス
        //        ArrayList retList = new ArrayList();

        //        // XMLへ変換し、文字列のバイナリ化
        //        byte[] parabyte = XmlByteSerializer.Serialize(tbsPartsCodeWork);

        //        status = this._iTbsPartsCodeDB.Read(ref parabyte);

        //        // 成功したら取得データを抽出
        //        if (status == 0)
        //        {
        //            tbsPartsCodeWork = (TbsPartsCodeWork)XmlByteSerializer.Deserialize(parabyte, typeof(TbsPartsCodeWork));
        //            // XMLの読み込み
        //            bLGoodsCdUMnt = CopyToMakerFromTbsPartsCodeWork(tbsPartsCodeWork);
        //        }
        //        return status;
        //    }
        //    catch (Exception)
        //    {
        //        //通信エラーは-1を戻す
        //        bLGoodsCdUMnt = null;

        //        return -1;
        //    }
        //}

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// BL商品コード読み込み処理＜ユーザー＞
        /// </summary>
        /// <param name="maker">BL商品コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">BL商品コードコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード名称情報を読み込みます。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
        private int ReadUWork(out BLGoodsCdUMnt bLGoodsCdUMnt, string enterpriseCode, int bLGoodsCode, int bLGoodsCdDerivedNo)
        {
            int status = 0;
            bLGoodsCdUMnt = null;
            try
            {

                // オフライン状態の場合
                //if (!LoginInfoAcquisition.OnlineFlag)
                //{
                //    status = ReadStaticMakerMemory(out maker, enterpriseCode, makerCode);

                //}
                //else
                //{
                // ｢D｣に対して入力パラメータを格納する
                BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
                bLGoodsCdUWork.EnterpriseCode = enterpriseCode;
                bLGoodsCdUWork.BLGoodsCode = bLGoodsCode;
                //bLGoodsCdUWork.BLGoodsCdDerivedNo = bLGoodsCdDerivedNo;

                // レスポンス
                ArrayList retList = new ArrayList();

                // XMLへ変換し、文字列のバイナリ化 iitani d
                byte[] parabyte = XmlByteSerializer.Serialize(bLGoodsCdUWork);

                // BL商品コード名称読み込み(ローカルDB) iitani c
                status = this._iBLGoodsCdUDB.Read(ref parabyte, 0);
                //status = this._makerLcDB.Read(ref bLGoodsCdWork, 0);

                // 成功したら取得データを抽出
                if (status == 0)
                {
                    //----- ueno upd ---------- start 2008.01.31
                    // デシリアライズ漏れ対応
                    // XMLの読み込み
                    bLGoodsCdUWork = (BLGoodsCdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(BLGoodsCdUWork));
                    //----- ueno upd ---------- end 2008.01.31

                    bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdUWork(bLGoodsCdUWork);
                }
                //}
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                bLGoodsCdUMnt = null;
                //オフライン時はnullをセット
                //this._iBLGoodsCdDB = null;  // iitani d 2007.05.21
                return -1;
            }
            //return status;
        }
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// BL商品コード登録・更新処理
        /// </summary>
        /// <param name="maker">BL商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード情報の登録・更新を行います。<br />
        /// Programmer : 20006 立花裕輔<br />
        /// Date       : 2006.12.05<br />
        /// </remarks>
		public int Write(ref BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            int status = 0;

            try
            {
				BLGoodsCdUWork bLGoodsCdUWork = this.CopyToBLGoodsCdUWorkFromMaker(bLGoodsCdUMnt);

                // XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(bLGoodsCdUWork);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGoodsCdUWork);
                object paraobj = paraList;

                // BL商品コード名称書き込み(｢A｣→｢O｣へ接続)
                //status = this._iBLGoodsCdUDB.Write(ref parabyte);
                status = this._iBLGoodsCdUDB.Write(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // ファイル名を渡してワーククラスをデシリアライズする
                    //bLGoodsCdWork = (BLGoodsCdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(BLGoodsCdUWork));

					bLGoodsCdUMnt = this.CopyToMakerFromBLGoodsCdUWork((BLGoodsCdUWork)paraList[0]);
                    // static保持
                    //_bLGoodsCd_Stc[maker.GoodsMakerCd] = maker;
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //this._iBLGoodsCdDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
			return status;
        }

        /// <summary>
        /// BL商品コード論理削除処理
        /// </summary>
        /// <param name="maker">BL商品コードオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード情報の論理削除を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int LogicalDelete(ref BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            int status = 0;
            try
            {
				BLGoodsCdUWork bLGoodsCdUWork = CopyToBLGoodsCdUWorkFromMaker(bLGoodsCdUMnt);

                ArrayList paraList = new ArrayList();
				paraList.Add(bLGoodsCdUWork);
                object paraObj = paraList;

                // BL商品コード名称クラス論理削除
                status = this._iBLGoodsCdUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // クラス内メンバコピー
					bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdUWork((BLGoodsCdUWork)paraList[0]);

					// static保持
                    //_bLGoodsCd_Stc[maker.GoodsMakerCd] = maker;

                    //Maker deleteMaker = new Maker();
                    //deleteMaker.EnterpriseCode = maker.EnterpriseCode;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //this._iBLGoodsCdDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
			//return status;
		}

        /// <summary>
        /// BL商品コード物理削除処理
        /// </summary>
        /// <param name="maker">BL商品コードオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード情報の物理削除を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2006.12.06<br />
        /// </remarks>
		public int Delete(BLGoodsCdUMnt bLGoodsCdUMnt)
        {
			int status = 0;
			try
            {
				BLGoodsCdUWork bLGoodsCdUWork = CopyToBLGoodsCdUWorkFromMaker(bLGoodsCdUMnt);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(bLGoodsCdUWork);

                // BL商品コード名称物理削除
                status = this._iBLGoodsCdUDB.Delete(parabyte);

                //bLGoodsCdWork = (BLGoodsCdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(BLGoodsCdUWork));
                //maker = CopyToMakerFromBLGoodsCdWork(bLGoodsCdWork);

                // static削除
                //_bLGoodsCd_Stc.Remove(maker.GoodsMakerCd);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //this._iBLGoodsCdDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
			//return status;
		}

        /// <summary>
        /// BL商品コード論理削除復活処理
        /// </summary>
        /// <param name="maker">BL商品コード名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : BL商品コード情報の復活を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2006.12.06<br />
        /// </remarks>
		public int Revival(ref BLGoodsCdUMnt bLGoodsCdUMnt)
        {
			int status = 0;
			// 論理削除復活はユーザー登録分しかありえない！！
            try
            {
				BLGoodsCdUWork bLGoodsCdUWork = CopyToBLGoodsCdUWorkFromMaker(bLGoodsCdUMnt);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGoodsCdUWork);
                object paraobj = paraList;

                // 復活処理
                status = this._iBLGoodsCdUDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // クラス内メンバコピー
					bLGoodsCdUMnt = CopyToMakerFromBLGoodsCdUWork((BLGoodsCdUWork)paraList[0]);
                    // static保持
                    //_bLGoodsCd_Stc[maker.GoodsMakerCd] = maker;
                }
                return status;
            }
            catch (Exception)
            {
				//----- ueno del ---------- start 2008.02.27
				////オフライン時はnullをセット
				//this._iBLGoodsCdDB = null;
				//----- ueno del ---------- end 2008.02.27

                //通信エラーは-1を戻す
                return -1;
            }
			//return status;
		}

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// クラスメンバーコピー処理（提供BL商品コードワーククラス(D)⇒BL商品コードクラス(E)）
		/// </summary>
		/// <param name="bLGoodsCdWork">BL商品コードワーククラス</param>
		/// <returns>BL商品コードクラス</returns>
		/// <remarks>
		/// Note       : BL商品コードワーククラス(ユーザー)からBL商品コードクラスへメンバーのコピーを行います。<br />
		/// Programmer : 飯谷　耕平<br />
		/// Date       : 2007.04.04<br />
		/// </remarks>
		private BLGoodsCdUMnt CopyToMakerFromBLGoodsCdWork(BLGoodsCdWork bLGoodsCdWork)
		{
			BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
			bLGoodsCdUMnt.CreateDateTime		= bLGoodsCdWork.CreateDateTime;
			bLGoodsCdUMnt.UpdateDateTime		= bLGoodsCdWork.UpdateDateTime;
			bLGoodsCdUMnt.LogicalDeleteCode		= bLGoodsCdWork.LogicalDeleteCode;
			bLGoodsCdUMnt.LargeGoodsGanreCode	= bLGoodsCdWork.LargeGoodsGanreCode;
			bLGoodsCdUMnt.LargeGoodsGanreName	= bLGoodsCdWork.LargeGoodsGanreName;
			bLGoodsCdUMnt.MediumGoodsGanreCode	= bLGoodsCdWork.MediumGoodsGanreCode;
			bLGoodsCdUMnt.MediumGoodsGanreName	= bLGoodsCdWork.MediumGoodsGanreName;
			bLGoodsCdUMnt.DetailGoodsGanreCode	= bLGoodsCdWork.DetailGoodsGanreCode;
			bLGoodsCdUMnt.DetailGoodsGanreName	= bLGoodsCdWork.DetailGoodsGanreName;
            bLGoodsCdUMnt.BLGoodsCode			= bLGoodsCdWork.BLGoodsCode;
			//bLGoodsCdUMnt.BLGoodsCdDerivedNo	= bLGoodsCdWork.BLGoodsCdDerivedNo;
			bLGoodsCdUMnt.BLGoodsFullName		= bLGoodsCdWork.BLGoodsFullName;
			bLGoodsCdUMnt.BLGoodsHalfName		= bLGoodsCdWork.BLGoodsHalfName;
			bLGoodsCdUMnt.BLGoodsGenreCode		= bLGoodsCdWork.BLGoodsGenreCode;
			bLGoodsCdUMnt.Division				= 1;
			bLGoodsCdUMnt.DivisionName = "提供データ";
			return bLGoodsCdUMnt;
		}
		   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// クラスメンバーコピー処理（提供BL商品コードワーククラス(D)⇒BL商品コードクラス(E)）
        /// </summary>
        /// <param name="tbsPartsCodeWork">BL商品コードワーククラス</param>
        /// <returns>BL商品コードクラス</returns>
        /// <remarks>
        /// Note       : BL商品コードワーククラス(ユーザー)からBL商品コードクラスへメンバーのコピーを行います。<br />
        /// Programmer : 30414　忍　幸史<br />
        /// Date       : 2008/06/10<br />
        /// </remarks>
        private BLGoodsCdUMnt CopyToMakerFromTbsPartsCodeWork(TbsPartsCodeWork tbsPartsCodeWork)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            bLGoodsCdUMnt.BLGoodsCode = tbsPartsCodeWork.TbsPartsCode;
            bLGoodsCdUMnt.BLGoodsFullName = tbsPartsCodeWork.TbsPartsFullName;
            bLGoodsCdUMnt.BLGoodsHalfName = tbsPartsCodeWork.TbsPartsHalfName;
            bLGoodsCdUMnt.BLGoodsGenreCode = tbsPartsCodeWork.EquipGenre;
            bLGoodsCdUMnt.BLGloupCode = tbsPartsCodeWork.BLGroupCode;
            bLGoodsCdUMnt.GoodsRateGrpCode = tbsPartsCodeWork.GoodsMGroup;
            bLGoodsCdUMnt.Division = 1;
            bLGoodsCdUMnt.DivisionName = "提供データ";
            return bLGoodsCdUMnt;
        }
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーBL商品コードワーククラス(D)⇒BL商品コードクラス(E)）
		/// </summary>
		/// <param name="bLGoodsCdWork">BL商品コードワーククラス</param>
		/// <returns>BL商品コードクラス</returns>
		/// <remarks>
		/// Note       : BL商品コードワーククラス(ユーザー)からBL商品コードクラスへメンバーのコピーを行います。<br />
		/// Programmer : 飯谷　耕平<br />
		/// Date       : 2007.04.04<br />
		/// </remarks>
		private BLGoodsCdUMnt CopyToMakerFromBLGoodsCdUWork(BLGoodsCdUWork bLGoodsCdUWork)
		{
			BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

			bLGoodsCdUMnt.CreateDateTime = bLGoodsCdUWork.CreateDateTime;
			bLGoodsCdUMnt.UpdateDateTime = bLGoodsCdUWork.UpdateDateTime;
			bLGoodsCdUMnt.EnterpriseCode		= bLGoodsCdUWork.EnterpriseCode;
			bLGoodsCdUMnt.FileHeaderGuid		= bLGoodsCdUWork.FileHeaderGuid;
			bLGoodsCdUMnt.UpdEmployeeCode		= bLGoodsCdUWork.UpdEmployeeCode;
			bLGoodsCdUMnt.UpdAssemblyId1		= bLGoodsCdUWork.UpdAssemblyId1;
			bLGoodsCdUMnt.UpdAssemblyId2		= bLGoodsCdUWork.UpdAssemblyId2;
			bLGoodsCdUMnt.LogicalDeleteCode = bLGoodsCdUWork.LogicalDeleteCode;
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			bLGoodsCdUMnt.LargeGoodsGanreCode = bLGoodsCdUWork.LargeGoodsGanreCode;
			bLGoodsCdUMnt.LargeGoodsGanreName = bLGoodsCdUWork.LargeGoodsGanreName;
			bLGoodsCdUMnt.MediumGoodsGanreCode = bLGoodsCdUWork.MediumGoodsGanreCode;
			bLGoodsCdUMnt.MediumGoodsGanreName = bLGoodsCdUWork.MediumGoodsGanreName;
			bLGoodsCdUMnt.DetailGoodsGanreCode = bLGoodsCdUWork.DetailGoodsGanreCode;
			bLGoodsCdUMnt.DetailGoodsGanreName = bLGoodsCdUWork.DetailGoodsGanreName;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            bLGoodsCdUMnt.BLGoodsCode = bLGoodsCdUWork.BLGoodsCode;
			//bLGoodsCdUMnt.BLGoodsCdDerivedNo = bLGoodsCdUWork.BLGoodsCdDerivedNo;
			bLGoodsCdUMnt.BLGoodsFullName = bLGoodsCdUWork.BLGoodsFullName;
			bLGoodsCdUMnt.BLGoodsHalfName = bLGoodsCdUWork.BLGoodsHalfName;
			bLGoodsCdUMnt.BLGoodsGenreCode = bLGoodsCdUWork.BLGoodsGenreCode;
            bLGoodsCdUMnt.OfferDate = bLGoodsCdUWork.OfferDate;
            bLGoodsCdUMnt.OfferDataDiv = bLGoodsCdUWork.OfferDataDiv;
            if ((bLGoodsCdUMnt.OfferDate == DateTime.MinValue) && (bLGoodsCdUMnt.OfferDataDiv == 0))

            {
                bLGoodsCdUMnt.Division = 0;
                bLGoodsCdUMnt.DivisionName = "ユーザー";
            }
            else
            {
                bLGoodsCdUMnt.Division = 1;
                bLGoodsCdUMnt.DivisionName = "提供";
            }
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            bLGoodsCdUMnt.BLGloupCode = bLGoodsCdUWork.BLGroupCode;
            bLGoodsCdUMnt.GoodsRateGrpCode = bLGoodsCdUWork.GoodsRateGrpCode;
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<


			return bLGoodsCdUMnt;
		}

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// クラスメンバーコピー処理（BL商品コードクラス(E)⇒提供BL商品コードワーククラス(D)）
        /// </summary>
        /// <param name="maker">BL商品コードクラス</param>
        /// <returns>BL商品コードワーカークラス</returns>
        /// <remarks>
        /// Note       : BL商品コードクラスからBL商品コードワーククラスへメンバーのコピーを行います。<br />
        /// Programmer : 立花裕輔<br />
        /// >Date       : 2007.08.01<br />
        /// </remarks>
		private BLGoodsCdWork CopyToBLGoodsCdWorkFromMaker(BLGoodsCdUMnt bLGoodsCdUMnt)
        {
			BLGoodsCdWork bLGoodsCdWork = new BLGoodsCdWork();

			bLGoodsCdWork.CreateDateTime = bLGoodsCdUMnt.CreateDateTime;
			bLGoodsCdWork.UpdateDateTime = bLGoodsCdUMnt.UpdateDateTime;
			bLGoodsCdWork.LogicalDeleteCode = bLGoodsCdUMnt.LogicalDeleteCode;
			bLGoodsCdWork.LargeGoodsGanreCode = bLGoodsCdUMnt.LargeGoodsGanreCode;
			bLGoodsCdWork.LargeGoodsGanreName = bLGoodsCdUMnt.LargeGoodsGanreName;
			bLGoodsCdWork.MediumGoodsGanreCode = bLGoodsCdUMnt.MediumGoodsGanreCode;
			bLGoodsCdWork.MediumGoodsGanreName = bLGoodsCdUMnt.MediumGoodsGanreName;
			bLGoodsCdWork.DetailGoodsGanreCode = bLGoodsCdUMnt.DetailGoodsGanreCode;
			bLGoodsCdWork.DetailGoodsGanreName = bLGoodsCdUMnt.DetailGoodsGanreName;
            bLGoodsCdWork.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
			//bLGoodsCdWork.BLGoodsCdDerivedNo = bLGoodsCdUMnt.BLGoodsCdDerivedNo;
			bLGoodsCdWork.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
			bLGoodsCdWork.BLGoodsHalfName = bLGoodsCdUMnt.BLGoodsHalfName;
			bLGoodsCdWork.BLGoodsGenreCode = bLGoodsCdUMnt.BLGoodsGenreCode;

			return bLGoodsCdWork;
        }
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

		/// <summary>
		/// クラスメンバーコピー処理（BL商品コードクラス(E)⇒ユーザーBL商品コードワーククラス(D)）
		/// </summary>
		/// <param name="maker">BL商品コードクラス</param>
		/// <returns>BL商品コードワーカークラス</returns>
		/// <remarks>
		/// Note       : BL商品コードクラスからBL商品コードワーククラスへメンバーのコピーを行います。<br />
		/// Programmer : 立花裕輔<br />
		/// >Date       : 2007.08.01<br />
		/// </remarks>
		private BLGoodsCdUWork CopyToBLGoodsCdUWorkFromMaker(BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();

			bLGoodsCdUWork.CreateDateTime = bLGoodsCdUMnt.CreateDateTime;
			bLGoodsCdUWork.UpdateDateTime = bLGoodsCdUMnt.UpdateDateTime;
			bLGoodsCdUWork.EnterpriseCode = bLGoodsCdUMnt.EnterpriseCode;
			bLGoodsCdUWork.FileHeaderGuid = bLGoodsCdUMnt.FileHeaderGuid;
			bLGoodsCdUWork.UpdEmployeeCode = bLGoodsCdUMnt.UpdEmployeeCode;
			bLGoodsCdUWork.UpdAssemblyId1 = bLGoodsCdUMnt.UpdAssemblyId1;
			bLGoodsCdUWork.UpdAssemblyId2 = bLGoodsCdUMnt.UpdAssemblyId2;
			bLGoodsCdUWork.LogicalDeleteCode = bLGoodsCdUMnt.LogicalDeleteCode;
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			bLGoodsCdUWork.LargeGoodsGanreCode = bLGoodsCdUMnt.LargeGoodsGanreCode;
			bLGoodsCdUWork.LargeGoodsGanreName = bLGoodsCdUMnt.LargeGoodsGanreName;
			bLGoodsCdUWork.MediumGoodsGanreCode = bLGoodsCdUMnt.MediumGoodsGanreCode;
			bLGoodsCdUWork.MediumGoodsGanreName = bLGoodsCdUMnt.MediumGoodsGanreName;
			bLGoodsCdUWork.DetailGoodsGanreCode = bLGoodsCdUMnt.DetailGoodsGanreCode;
			bLGoodsCdUWork.DetailGoodsGanreName = bLGoodsCdUMnt.DetailGoodsGanreName;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            bLGoodsCdUWork.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
			//bLGoodsCdUWork.BLGoodsCdDerivedNo = bLGoodsCdUMnt.BLGoodsCdDerivedNo;
			bLGoodsCdUWork.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
			bLGoodsCdUWork.BLGoodsHalfName = bLGoodsCdUMnt.BLGoodsHalfName;
			bLGoodsCdUWork.BLGoodsGenreCode = bLGoodsCdUMnt.BLGoodsGenreCode;
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            bLGoodsCdUWork.BLGroupCode = bLGoodsCdUMnt.BLGloupCode;
            bLGoodsCdUWork.GoodsRateGrpCode = bLGoodsCdUMnt.GoodsRateGrpCode;
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
            bLGoodsCdUWork.OfferDate = bLGoodsCdUMnt.OfferDate;
            bLGoodsCdUWork.OfferDataDiv = bLGoodsCdUMnt.OfferDataDiv;              

			return bLGoodsCdUWork;
		}

        // --- ADD 2c008/06/10 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// クラスメンバーコピー処理（BL商品コードクラス(E)⇒提供BL商品コードワーククラス(D)）
        ///// </summary>
        ///// <param name="maker">BL商品コードクラス</param>
        ///// <returns>BL商品コードワーカークラス</returns>
        ///// <remarks>
        ///// Note        : BL商品コードクラスからBL商品コードワーククラスへメンバーのコピーを行います。<br />
        ///// Programmer  : 30414　忍　幸史<br />
        ///// >Date       : 2008/06/10<br />
        ///// </remarks>
        //private TbsPartsCodeWork CopyToTbsPartsCodeWorkFromMaker(BLGoodsCdUMnt bLGoodsCdUMnt)
        //{
        //    TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();

        //    tbsPartsCodeWork.TbsPartsCode = bLGoodsCdUMnt.BLGoodsCode;
        //    tbsPartsCodeWork.TbsPartsFullName = bLGoodsCdUMnt.BLGoodsFullName;
        //    tbsPartsCodeWork.TbsPartsHalfName = bLGoodsCdUMnt.BLGoodsHalfName;
        //    tbsPartsCodeWork.EquipGenre = bLGoodsCdUMnt.BLGoodsGenreCode;
        //    tbsPartsCodeWork.BLGroupCode = bLGoodsCdUMnt.BLGloupCode;
        //    tbsPartsCodeWork.GoodsMGroup = bLGoodsCdUMnt.GoodsRateGrpCode;

        //    return tbsPartsCodeWork;
        //}
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// マスタ検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="belongSectionCode">拠点コード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 取得結果をDataSetで返します。</br>
		/// <br>Programmer	: 96186 立花裕輔</br>
		/// <br>Date		: 2007.08.01</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode)
		{
			//LGoodsGanreWork lgoodsganreWork = new LGoodsGanreWork();
			//lgoodsganreWork.EnterpriseCode = enterpriseCode;

			//ArrayList ar = new ArrayList();


			ArrayList retList = new ArrayList();

			int status = 0;
			//object objectLGoodsGanreWork;

			// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
			//if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
			//{

			// マスタサーチ
			status = SearchAll(out retList, enterpriseCode);
			if (status != 0)
			{
				return status;
			}

			ArrayList wkList = retList.Clone() as ArrayList;
			SortedList wkSort = new SortedList();

			// --- [全て] --- //
			// そのまま全件返す
			foreach (BLGoodsCdUMnt wkBLGoodsCdUMnt in wkList)
			{
				if (wkBLGoodsCdUMnt.LogicalDeleteCode == 0)
				{
					wkSort.Add(wkBLGoodsCdUMnt.BLGoodsCode, wkBLGoodsCdUMnt);
				}
			}
            /* --- DEL 2008/10/22 0詰めされた値を表示する為、BLGoodsCodeをint→String変換したものを使用 ----->>>>>
			BLGoodsCdUMnt[] bLGoodsCdUMnt = new BLGoodsCdUMnt[wkSort.Count];

			// データを元に戻す
			for (int i = 0; i < wkSort.Count; i++)
			{
				bLGoodsCdUMnt[i] = (BLGoodsCdUMnt)wkSort.GetByIndex(i);
			}

			byte[] retbyte = XmlByteSerializer.Serialize(bLGoodsCdUMnt);
			XmlByteSerializer.ReadXml(ref ds, retbyte);
               --- DEL 2008/10/22 ---------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/22 --------------------------------------------------------------------------->>>>>
            BLGoodsCdUMntWork[] bLGoodsCdUMntWork = new BLGoodsCdUMntWork[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                bLGoodsCdUMntWork[i] = this.CopyToWorkFromBLGoodsCdUMnt((BLGoodsCdUMnt)wkSort.GetByIndex(i));
            }

            byte[] retbyte = XmlByteSerializer.Serialize(bLGoodsCdUMntWork);
            XmlByteSerializer.ReadXml(ref ds, retbyte);
            // --- ADD 2008/10/22 ---------------------------------------------------------------------------<<<<<

			return status;
		}

        // --- ADD 2008/10/22 --------------------------------------------------------------------------->>>>>
        /// <summary>
        /// クラスコピー処理(一部のデータをint→String変換)
        /// </summary>
        /// <param name="blGoodsCdMnt"></param>
        /// <returns></returns>
        private BLGoodsCdUMntWork CopyToWorkFromBLGoodsCdUMnt(BLGoodsCdUMnt blGoodsCdMnt)
        {
            BLGoodsCdUMntWork work = new BLGoodsCdUMntWork();
            work.BLGloupCode = blGoodsCdMnt.BLGloupCode;
            work.BLGoodsCode = blGoodsCdMnt.BLGoodsCode.ToString("00000");              //int→String変換
            work.BLGoodsFullName = blGoodsCdMnt.BLGoodsFullName;
            work.BLGoodsGenreCode = blGoodsCdMnt.BLGoodsGenreCode;
            work.BLGoodsHalfName = blGoodsCdMnt.BLGoodsHalfName;
            work.BLGoodsName = blGoodsCdMnt.BLGoodsName;
            work.CreateDateTime = blGoodsCdMnt.CreateDateTime;
            work.CreateDateTimeAdFormal = blGoodsCdMnt.CreateDateTimeAdFormal;
            work.CreateDateTimeAdInFormal = blGoodsCdMnt.CreateDateTimeAdInFormal;
            work.CreateDateTimeJpFormal = blGoodsCdMnt.CreateDateTimeJpFormal;
            work.CreateDateTimeJpInFormal = blGoodsCdMnt.CreateDateTimeJpInFormal;
            work.Division = blGoodsCdMnt.Division;
            work.DivisionName = blGoodsCdMnt.DivisionName;
            work.EnterpriseCode = blGoodsCdMnt.EnterpriseCode;
            work.EnterpriseName = blGoodsCdMnt.EnterpriseName;
            work.FileHeaderGuid = blGoodsCdMnt.FileHeaderGuid;
            work.GoodsRateGrpCode = blGoodsCdMnt.GoodsRateGrpCode;
            work.LogicalDeleteCode = blGoodsCdMnt.LogicalDeleteCode;
            work.OfferDataDiv = blGoodsCdMnt.OfferDataDiv;
            work.OfferDate = blGoodsCdMnt.OfferDate;
            work.UpdAssemblyId1 = blGoodsCdMnt.UpdAssemblyId1;
            work.UpdAssemblyId2 = blGoodsCdMnt.UpdAssemblyId2;
            work.UpdateDateTime = blGoodsCdMnt.UpdateDateTime;
            work.UpdateDateTimeAdFormal = blGoodsCdMnt.UpdateDateTimeAdFormal;
            work.UpdateDateTimeAdInFormal = blGoodsCdMnt.UpdateDateTimeAdInFormal;
            work.UpdateDateTimeJpFormal = blGoodsCdMnt.UpdateDateTimeJpFormal;
            work.UpdateDateTimeJpInFormal = blGoodsCdMnt.UpdateDateTimeJpInFormal;
            work.UpdEmployeeCode = blGoodsCdMnt.UpdEmployeeCode;
            work.UpdEmployeeName = blGoodsCdMnt.UpdEmployeeName;

            return work;
        }
        // --- ADD 2008/10/22 ---------------------------------------------------------------------------<<<<<

		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note		: 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer	: 96186 立花裕輔</br>
		/// <br>Date		: 2007.08.01</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = -1;
			string enterpriseCode = "";

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

			// マスタテーブル読込み(ローカルDB) iitani c
			status = Search(ref guideList, enterpriseCode);
			//status = SearchLocalDB(ref guideList, enterpriseCode);

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

        /// <summary>
        /// BL商品コードマスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="maker">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: BL商品コードマスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 96186 立花裕輔</br>
        /// </remarks>
		public int ExecuteGuid(string enterpriseCode, out BLGoodsCdUMnt bLGoodsCdUMnt)
        {
            int status = -1;
			bLGoodsCdUMnt = new BLGoodsCdUMnt();

			TableGuideParent tableGuideParent = new TableGuideParent("BLGOODSCDGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
				string strCode;

				//BL商品コード
				strCode = retObj["BLGoodsCode"].ToString();
				bLGoodsCdUMnt.BLGoodsCode = int.Parse(strCode);

				//枝番
				//strCode = retObj["BLGoodsCdDerivedNo"].ToString();
				//bLGoodsCdUMnt.BLGoodsCdDerivedNo = int.Parse(strCode);

				//BL商品コード名称（全角）
				bLGoodsCdUMnt.BLGoodsFullName = retObj["BLGoodsFullName"].ToString();

				//BL商品コード名称（半角）
				bLGoodsCdUMnt.BLGoodsHalfName = retObj["BLGoodsHalfName"].ToString();

				//BL商品分類
				strCode = retObj["BLGoodsGenreCode"].ToString();
				bLGoodsCdUMnt.BLGoodsGenreCode = int.Parse(strCode);

                /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
				//商品区分グループコード
				bLGoodsCdUMnt.LargeGoodsGanreCode = retObj["LargeGoodsGanreCode"].ToString();

				//商品区分グループ名称
				bLGoodsCdUMnt.LargeGoodsGanreName = retObj["LargeGoodsGanreName"].ToString();

				//商品区分コード
				bLGoodsCdUMnt.MediumGoodsGanreCode = retObj["MediumGoodsGanreCode"].ToString();

				//商品区分名称
				bLGoodsCdUMnt.MediumGoodsGanreName = retObj["MediumGoodsGanreName"].ToString();

				//商品区分詳細コード
				bLGoodsCdUMnt.DetailGoodsGanreCode = retObj["DetailGoodsGanreCode"].ToString();

				//商品区分詳細名称
				bLGoodsCdUMnt.DetailGoodsGanreName = retObj["DetailGoodsGanreName"].ToString();
				   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
    }
}
