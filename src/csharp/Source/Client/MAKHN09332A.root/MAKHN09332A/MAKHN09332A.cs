using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 倉庫テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// -----------------------------------------------------------------------------------
    /// <br>Note       : 倉庫テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 22022 段上 知子</br>
    /// <br>Date       : 2006.12.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: Read、ガイドのSearch の処理をローカルDBからの読込に変更</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.04.04</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: 拠点コードの比較の際、TrimEndをかけた状態で行うように修正</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.05.25</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ガイドに論理削除のデータが出てしまっていたのを修正</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.06.05</br>
    /// -----------------------------------------------------------------------------------
	/// <br>UpdateNote	: Read、ガイドのSearch の処理をリモートDBからの読込に変更</br>
	/// <br>Programmer	: 30167　上野　弘貴</br>
	/// <br>Date		: 2007.09.12</br>
	/// -----------------------------------------------------------------------------------
	/// <br>Update Note : ローカルＤＢ対応（コメントされていた部分復活、及び不足部分追加）</br>
	/// <br>Programmer	: 30167 上野　弘貴</br>
	/// <br>Date		: 2008.01.31</br>
	/// -----------------------------------------------------------------------------------
    /// <br>Update Note : 「得意先」「主管倉庫」「在庫一括リマーク」追加、「倉庫備考2～5」削除</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/06/04</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : ハンディ６次改良</br>
    /// <br>Programmer	: 31739 岸　傑</br>
    /// <br>Date		: 2019/11/13</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : ハンディ仕入れ時在庫登録対応</br>
    /// <br>Programmer	: 31739 岸　傑</br>
    /// <br>Date		: 2020/04/08</br>
    /// -----------------------------------------------------------------------------------
    /// </remarks>
    public class WarehouseAcs : IGeneralGuideData
    {
        # region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        IWarehouseDB _iwarehouseDB = null;
        WarehouseLcDB _warehouseLcDB = null;  // iitani a

        // キャッシュ用ハッシュテーブル
        static private Hashtable _WarehouseTable = null;

        // ガイド設定ファイル名
        private const string GUIDE_XML_FILENAME = "WAREHOUSEGUIDEPARENT.XML";   // XMLファイル名

        // ガイドパラメータ
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // 企業コード

        // ガイド項目タイプ
        private const string GUIDE_TYPE_STR = "System.String";              // String型

        // ガイド項目名
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";                // 拠点コード
        private const string GUIDE_WAREHOUSECODE_TITLE = "WarehouseCode";              // 倉庫コード
        private const string GUIDE_WAREHOUSENAME_TITLE = "WarehouseName";              // 倉庫名称
        private const string GUIDE_WAREHOUSENOTE1_TITLE = "WarehouseNote1";             // 倉庫備考1
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string GUIDE_WAREHOUSENOTE2_TITLE = "WarehouseNote2";             // 倉庫備考2
        private const string GUIDE_WAREHOUSENOTE3_TITLE = "WarehouseNote3";             // 倉庫備考3
        private const string GUIDE_WAREHOUSENOTE4_TITLE = "WarehouseNote4";             // 倉庫備考4
        private const string GUIDE_WAREHOUSENOTE5_TITLE = "WarehouseNote5";             // 倉庫備考5
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";                 // 得意先コード
        private const string GUIDE_MAINMNGWAREHOUSECD_TITLE = "MainMngWarehouseCd";     // 主管倉庫コード
        private const string GUIDE_STOCKBLANKREMARK_TITLE = "StockBlnktRemark";         // 在庫一括リマーク
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

        //----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31

        # endregion

        # region Constructor

        /// <summary>
        /// 倉庫テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public WarehouseAcs()
        {
            _WarehouseTable = null;
            try
            {
                // リモートオブジェクト取得
                this._iwarehouseDB = (IWarehouseDB)MediationWarehouseDB.GetWarehouseDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iwarehouseDB = null;
            }

            // ローカルDBアクセスオブジェクト取得
            this._warehouseLcDB = new WarehouseLcDB();   // iitani a
        }

        # endregion

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

        #region GetOnlineMode

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iwarehouseDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Read Methods

        /// <summary>
        /// 倉庫読み込み処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報を読み込みます。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Read(out Warehouse warehouse, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            try
            {
                warehouse = null;
                int status = 0;
                WarehouseWork warehouseWork = new WarehouseWork();
                warehouseWork.EnterpriseCode = enterpriseCode;
                warehouseWork.SectionCode = sectionCode;
                warehouseWork.WarehouseCode = warehouseCode;

				//----- ueno upd ---------- start 2008.01.31
				// ローカル
				if (_isLocalDBRead)
				{
					status = this._warehouseLcDB.Read(ref warehouseWork, 0);
				}
				// リモート
				else
				{
					//----- ueno ---------- start 2007.09.12
					// XMLへ変換し、文字列のバイナリ化 iitani d
					byte[] parabyte = XmlByteSerializer.Serialize(warehouseWork);
					
					// 倉庫読み込み
					status = this._iwarehouseDB.Read(ref parabyte, 0);
					//----- ueno ---------- end   2007.09.12

					if (status == 0)
					{
						//----- ueno ---------- start 2007.09.12
						// XMLの読み込み iitani d
						warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));
						//----- ueno ---------- end   2007.09.12
						
						// クラス内メンバコピー
						//warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);
					}
				}

				if (status == 0)
				{
					// クラス内メンバコピー
					warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);
				}
				//----- ueno upd ---------- end 2008.01.31

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                warehouse = null;
                //オフライン時はnullをセット
                this._iwarehouseDB = null;
                return -1;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// 倉庫登録・更新処理
        /// </summary>
        /// <param name="warehouse">倉庫</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報の登録・更新を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Write(ref Warehouse warehouse)
        {
            // 倉庫クラスから倉庫ワーカークラスにメンバコピー
            WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);

            ArrayList paraList = new ArrayList();

            paraList.Add(warehouseWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //倉庫書き込み
                status = this._iwarehouseDB.Write(ref paraObj);
                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    warehouseWork = (WarehouseWork)paraList[0];

                    // クラス内メンバコピー
                    warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);

                    // キャッシュ更新
                    UpdateCache(warehouse);

                }
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// 倉庫論理削除処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報の論理削除を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int LogicalDelete(ref Warehouse warehouse)
        {
            int status = 0;

            try
            {
                // 倉庫変換
                ArrayList paraLst = new ArrayList();
                WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);
                paraLst.Add(warehouseWork);
                object paraObj = paraLst;

                // 論理削除
                status = this._iwarehouseDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    warehouseWork = (WarehouseWork)paraLst[0];
                    // クラス内メンバコピー
                    warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);

                    // キャッシュ更新
                    UpdateCache(warehouse);

                    Warehouse deleteLineup = new Warehouse();
                    deleteLineup.EnterpriseCode = warehouse.EnterpriseCode;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iwarehouseDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// 倉庫論理削除復活処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報の復活を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Revival(ref Warehouse warehouse)
        {
            try
            {
                WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(warehouseWork);

                object paraObj = paraLst;

                // 復活処理
                int status = this._iwarehouseDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    warehouseWork = (WarehouseWork)paraLst[0];
                    // クラス内メンバコピー
                    warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);

                    UpdateCache(warehouse);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iwarehouseDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// 倉庫物理削除処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報の物理削除を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Delete(Warehouse warehouse)
        {
            try
            {
                WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(warehouseWork);

                // 倉庫物理削除
                int status = this._iwarehouseDB.Delete(parabyte);

                if (status == 0)
                {
                    RemoveCache(warehouse);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iwarehouseDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// 倉庫全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }
        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// ハンディ用倉庫全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 31739 岸</br>
        /// <br>Date       : 2019.11.13</br>
        /// </remarks>
        public int SearchHandy(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchHandyProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }
        // --- ADD 2019/11/13 ----------<<<<<
        // --- ADD 2020/04/08 ---------->>>>>
        /// <summary>
        /// ハンディ用倉庫名取得処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名を取得します</br>
        /// <br>Programmer : 31739 岸</br>
        /// <br>Date       : 2020.04.08</br>
        /// </remarks>
        public int ReadHandy(out object warehouseObj, object enterpriseCode, object sectioncode, object warehousecode)
        {
            string ent = enterpriseCode as string;
            string sec = sectioncode as string;
            string warecd = warehousecode as string;
            Warehouse result = new Warehouse();
            int status = this.Read(out result, ent, sec, warecd);
            ArrayList resultArrayList = new ArrayList();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            	if (result != null)
            	{
                    WarehouseWork resultWk = CopyToWarehouseWorkFromWarehouse(result);

                    resultArrayList.Add(resultWk);
                }
            }

            warehouseObj = (object)resultArrayList;
            return status;
        }
        // --- ADD 2020/04/08 ----------<<<<<

        /// <summary>
        /// 倉庫全検索処理(拠点絞込み)（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">拠点コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null);
        }

        /// <summary>
        /// 倉庫検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// 倉庫検索処理(拠点絞り込み)（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">倉庫コード</param>		        
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// 倉庫検索処理(拠点絞込み)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevWarehouseがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevWarehouse">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の検索処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, Warehouse prevWarehouse)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            if (prevWarehouse != null) warehouseWork = CopyToWarehouseWorkFromWarehouse(prevWarehouse);

            warehouseWork.EnterpriseCode = enterpriseCode;
            //warehouseWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            retTotalCnt = 0;
            int status_o = 0;

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = warehouseWork;
            object retobj = null;

			//----- ueno upd ---------- start 2008.01.31
			// ローカル
			if (_isLocalDBRead)
			{
                List<WarehouseWork> warehouseWorkList = new List<WarehouseWork>();
				status_o = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, logicalMode);

				if (status_o == 0)
				{
					ArrayList al = new ArrayList();
					al.AddRange(warehouseWorkList);
					retobj = (object)al;
				}
			}
			// リモート
			else
			{
                status_o = this._iwarehouseDB.Search(out retobj, paraobj, 0, logicalMode);
			}
			//----- ueno upd ---------- end 2008.01.31

            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        wkList = retobj as ArrayList;

                        if (wkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in wkList)
                            {
                                // ----- iitani c ---------- start 2007.05.25
                                //if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                //    ((wkLineupWork.SectionCode == sectionCode) || (wkLineupWork.SectionCode == "")))
                                if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                    ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                                // ----- iitani c ---------- end 2007.05.25
                                {
                                    //メンバコピー
                                    retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                }
                            }

                            retTotalCnt = retList.Count;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status_o;
                    }
            }

            return status_o;

        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 倉庫検索処理(拠点絞込み)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevWarehouseがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevWarehouse">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の検索処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int SearchHandyProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, Warehouse prevWarehouse)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            //if (prevWarehouse != null) warehouseWork = CopyToWarehouseWorkFromWarehouse(prevWarehouse);

            warehouseWork.EnterpriseCode = enterpriseCode;
            //warehouseWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            retTotalCnt = 0;
            int status_o = 0;

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = warehouseWork;
            object retobj = null;

            //----- ueno upd ---------- start 2008.01.31
            // ローカル
            if (_isLocalDBRead)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"c:\work\20191118_9332ALog.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "Local!");
                }
                List<WarehouseWork> warehouseWorkList = new List<WarehouseWork>();
                status_o = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, logicalMode);

                if (status_o == 0)
                {
                    ArrayList al = new ArrayList();
                    al.AddRange(warehouseWorkList);
                    retobj = (object)al;
                }
            }
            // リモート
            else
            {
                status_o = this._iwarehouseDB.Search(out retobj, paraobj, 0, logicalMode);
            }
            //----- ueno upd ---------- end 2008.01.31

            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        wkList = retobj as ArrayList;

                        if (wkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in wkList)
                            {
                                // ----- iitani c ---------- start 2007.05.25
                                //if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                //    ((wkLineupWork.SectionCode == sectionCode) || (wkLineupWork.SectionCode == "")))
                                if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                    ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                                // ----- iitani c ---------- end 2007.05.25
                                {
                                    //メンバコピー
                                    //retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                    retList.Add(wkLineupWork);
                                }
                            }

                            retTotalCnt = retList.Count;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status_o;
                    }
            }

            return status_o;

        }
        // --- ADD 2019/11/13 ----------<<<<<

        /// <summary>
        /// 倉庫マスタ検索処理（ローカルDB(ガイド)用）
        /// </summary>
        /// <param name="retList">取得結果格納用ArrayList</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 倉庫マスタのローカルDB検索処理を行い、取得結果をArryListで返します。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public int SearchLocalDB(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = enterpriseCode;
            warehouseWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            int status = 0;

            List<WarehouseWork> warehouseWorkList = null;
            // ----- 2007.06.05 ---------- iitani c start ローカルDBの倉庫から論理削除も含めてSearchしたいケースは無いと想定
            //status = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, ConstantManagement.LogicalMode.GetData01);
            status = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, ConstantManagement.LogicalMode.GetData0);
            // ----- 2007.06.05 ---------- iitani c start 

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (warehouseWorkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in warehouseWorkList)
                            {
                                // ----- iitani c ---------- start 2007.05.25
                                //if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                //    ((wkLineupWork.SectionCode == sectionCode) || (wkLineupWork.SectionCode == "")))
                                if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                    ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                                // ----- iitani c ---------- end 2007.05.25
                                {
                                    //メンバコピー
                                    retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                }
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status;
                    }
            }

            return status;
        }


        #endregion

        #region Cache Methods

        /// <summary>
        /// キャッシュ内データ登録更新処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <remarks>
        /// <br>Note       : キャッシュ内のデータの登録・更新を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void UpdateCache(Warehouse warehouse)
        {
            if (_WarehouseTable == null)
            {
                _WarehouseTable = new Hashtable();
            }

            Hashtable warehouseTable = null;		// 倉庫コード別ハッシュテーブル

            // ハッシュテーブルにキャリアが登録されている
            if (_WarehouseTable.ContainsKey(warehouse.SectionCode) == true)
            {
                // 倉庫コード別ハッシュテーブル取得
                warehouseTable = (Hashtable)_WarehouseTable[warehouse.SectionCode];
            }
            // ハッシュテーブルにキャリアが登録されていない
            else
            {
                // 倉庫コード別ハッシュテーブルを生成
                warehouseTable = new Hashtable();
                // キャリア別ハッシュテーブルに追加
                _WarehouseTable.Add(warehouse.SectionCode, warehouseTable);
            }
        }

        /// <summary>
        /// キャッシュ内データ削除処理
        /// </summary>
        /// <param name="Warehouse">ラ倉庫オブジェクト</param>
        /// <remarks>
        /// <br>Note       : キャッシュ内データから指定された倉庫オブジェクトを削除します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void RemoveCache(Warehouse Warehouse)
        {
            if (_WarehouseTable == null)
            {
                // データが存在していない
                return;
            }

            Hashtable warehouseTable = null;		// 倉庫コード別ハッシュテーブル

            // ハッシュテーブルにキャリアが登録されている
            if (_WarehouseTable.ContainsKey(Warehouse.SectionCode) == false)
            {
                // データが存在していない
                return;
            }
            // 倉庫コード別ハッシュテーブル取得
            warehouseTable = (Hashtable)_WarehouseTable[Warehouse.SectionCode];
        }

        # endregion

        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバーコピー処理（倉庫ワーククラス⇒倉庫）
        /// </summary>
        /// <param name="warehouseWork">倉庫ワーククラス</param>
        /// <returns>倉庫</returns>
        /// <remarks>
        /// <br>Note       : 倉庫ワーククラスから倉庫へメンバーのコピーを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private Warehouse CopyToWarehouseFromWarehouseWork(WarehouseWork warehouseWork)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.CreateDateTime = warehouseWork.CreateDateTime;
            warehouse.UpdateDateTime = warehouseWork.UpdateDateTime;
            warehouse.FileHeaderGuid = warehouseWork.FileHeaderGuid;
            warehouse.LogicalDeleteCode = warehouseWork.LogicalDeleteCode;
            warehouse.EnterpriseCode = warehouseWork.EnterpriseCode;

            warehouse.SectionCode = warehouseWork.SectionCode;
            warehouse.WarehouseCode = warehouseWork.WarehouseCode;
            warehouse.WarehouseName = warehouseWork.WarehouseName;
            warehouse.WarehouseNote1 = warehouseWork.WarehouseNote1;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.WarehouseNote2 = warehouseWork.WarehouseNote2;
            warehouse.WarehouseNote3 = warehouseWork.WarehouseNote3;
            warehouse.WarehouseNote4 = warehouseWork.WarehouseNote4;
            warehouse.WarehouseNote5 = warehouseWork.WarehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.CustomerCode = warehouseWork.CustomerCode;
            warehouse.MainMngWarehouseCd = warehouseWork.MainMngWarehouseCd;
            warehouse.StockBlnktRemark = warehouseWork.StockBlnktRemark;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return warehouse;
        }

        /// <summary>
        /// クラスメンバーコピー処理（倉庫⇒倉庫ワーククラス）
        /// </summary>
        /// <param name="warehouse">倉庫クラス</param>
        /// <returns>倉庫ワーク</returns>
        /// <remarks>
        /// <br>Note       : 倉庫から倉庫ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private WarehouseWork CopyToWarehouseWorkFromWarehouse(Warehouse warehouse)
        {
            WarehouseWork warehouseWork = new WarehouseWork();

            warehouseWork.CreateDateTime = warehouse.CreateDateTime;
            warehouseWork.UpdateDateTime = warehouse.UpdateDateTime;
            warehouseWork.EnterpriseCode = warehouse.EnterpriseCode;
            warehouseWork.FileHeaderGuid = warehouse.FileHeaderGuid;

            warehouseWork.LogicalDeleteCode = warehouse.LogicalDeleteCode;
            warehouseWork.SectionCode = warehouse.SectionCode;
            warehouseWork.WarehouseCode = warehouse.WarehouseCode;
            warehouseWork.WarehouseName = warehouse.WarehouseName;
            warehouseWork.WarehouseNote1 = warehouse.WarehouseNote1;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouseWork.WarehouseNote2 = warehouse.WarehouseNote2;
            warehouseWork.WarehouseNote3 = warehouse.WarehouseNote3;
            warehouseWork.WarehouseNote4 = warehouse.WarehouseNote4;
            warehouseWork.WarehouseNote5 = warehouse.WarehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouseWork.CustomerCode = warehouse.CustomerCode;
            warehouseWork.MainMngWarehouseCd = warehouse.MainMngWarehouseCd;
            warehouseWork.StockBlnktRemark = warehouse.StockBlnktRemark;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return warehouseWork;
        }

        /// <summary>
        /// クラスメンバコピー処理 (ガイド選択データ⇒仕訳科目設定マスタクラス)
        /// </summary>
        /// <param name="guideData">ガイド選択データ</param>
        /// <returns>仕訳科目設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ガイド選択データから仕訳科目設定マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private Warehouse CopyToWarehouseFromGuideData(Hashtable guideData)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.SectionCode = (string)guideData[GUIDE_SECTIONCODE_TITLE];       // 拠点コード
            warehouse.WarehouseCode = (string)guideData[GUIDE_WAREHOUSECODE_TITLE];     // 倉庫コード
            warehouse.WarehouseName = (string)guideData[GUIDE_WAREHOUSENAME_TITLE];     // 倉庫名称
            warehouse.WarehouseNote1 = (string)guideData[GUIDE_WAREHOUSENOTE1_TITLE];    // 倉庫備考1
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.WarehouseNote2 = (string)guideData[GUIDE_WAREHOUSENOTE2_TITLE];    // 倉庫備考2
            warehouse.WarehouseNote3 = (string)guideData[GUIDE_WAREHOUSENOTE3_TITLE];    // 倉庫備考3
            warehouse.WarehouseNote4 = (string)guideData[GUIDE_WAREHOUSENOTE4_TITLE];    // 倉庫備考4
            warehouse.WarehouseNote5 = (string)guideData[GUIDE_WAREHOUSENOTE5_TITLE];    // 倉庫備考5
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if ((string)guideData[GUIDE_CUSTOMERCODE_TITLE] == null)
            {
                warehouse.CustomerCode = 0;
            }
            else
            {
                if ((string)guideData[GUIDE_CUSTOMERCODE_TITLE] == "")
                {
                    warehouse.CustomerCode = 0;
                }
                else
                {
                    warehouse.CustomerCode = int.Parse((string)guideData[GUIDE_CUSTOMERCODE_TITLE]);  // 得意先コード
                }
            }
            warehouse.MainMngWarehouseCd = (string)guideData[GUIDE_MAINMNGWAREHOUSECD_TITLE];  // 主管倉庫コード
            warehouse.StockBlnktRemark = (string)guideData[GUIDE_STOCKBLANKREMARK_TITLE];      // 在庫一括リマーク
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return warehouse;
        }

        /// <summary>
        /// DataRowコピー処理（倉庫クラス⇒ガイド用DataRow）
        /// </summary>
        /// <param name="guideRow">ガイド用DataRow</param>
        /// <param name="warehouse">倉庫クラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫クラスからガイド用DataRowへコピーを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void CopyToGuideRowFromWarehouse(ref DataRow guideRow, Warehouse warehouse)
        {
            guideRow[GUIDE_SECTIONCODE_TITLE] = warehouse.SectionCode;        // 拠点コード
            guideRow[GUIDE_WAREHOUSECODE_TITLE] = warehouse.WarehouseCode;      // 倉庫コード
            guideRow[GUIDE_WAREHOUSENAME_TITLE] = warehouse.WarehouseName;      // 倉庫名称
            guideRow[GUIDE_WAREHOUSENOTE1_TITLE] = warehouse.WarehouseNote1;     // 倉庫備考1
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            guideRow[GUIDE_WAREHOUSENOTE2_TITLE] = warehouse.WarehouseNote2;     // 倉庫備考2
            guideRow[GUIDE_WAREHOUSENOTE3_TITLE] = warehouse.WarehouseNote3;     // 倉庫備考3
            guideRow[GUIDE_WAREHOUSENOTE4_TITLE] = warehouse.WarehouseNote4;     // 倉庫備考4
            guideRow[GUIDE_WAREHOUSENOTE5_TITLE] = warehouse.WarehouseNote5;     // 倉庫備考5
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            guideRow[GUIDE_CUSTOMERCODE_TITLE] = warehouse.CustomerCode;               // 得意先コード
            guideRow[GUIDE_MAINMNGWAREHOUSECD_TITLE] = warehouse.MainMngWarehouseCd;   // 主管倉庫コード
            guideRow[GUIDE_STOCKBLANKREMARK_TITLE] = warehouse.StockBlnktRemark;       // 在庫一括リマーク
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        #endregion

        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="jnlItemsSetDisp">取得データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int ExecuteGuid(out Warehouse warehouse, string enterpriseCode, string sectionCode)
        {
            int status = -1;
            warehouse = new Warehouse();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);   // 企業コード
            //inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);        // 拠点コード  // DEL 2008/06/04
            
            //// --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            //if (sectionCode != "")
            //{
            //    inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);        // 拠点コード
            //}
            //// --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // ガイド起動
            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // 選択データの取得
                warehouse = CopyToWarehouseFromGuideData(retObj);
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="jnlItemsSetDisp">取得データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 20414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int ExecuteGuid(out Warehouse warehouse, string enterpriseCode)
        {
            int status = -1;
            status = ExecuteGuid(out warehouse, enterpriseCode, "");

            return status;
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

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

            // 拠点コード設定有り
            if (inParm.ContainsKey(GUIDE_SECTIONCODE_TITLE))
            {
                sectionCode = inParm[GUIDE_SECTIONCODE_TITLE].ToString();
            }

			//----- ueno upd ---------- start 2008.01.31
			// マスタテーブル読込み
            ArrayList retList;

			// ローカル
			if (_isLocalDBRead)
            {
				status = this.SearchLocalDB(out retList, enterpriseCode, sectionCode);
			}
			// リモート
			else
			{
				status = this.Search(out retList, enterpriseCode, sectionCode);
			}
			//----- ueno upd ---------- end 2008.01.31

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ガイド初期起動時
                        if (guideList.Tables.Count == 0)
                        {
                            // ガイド用データセット列情報構築
                            this.GuideDataSetColumnConstruction(ref guideList);
                        }

                        // ガイド用データセットの作成
                        this.GetGuideDataSet(ref guideList, retList, inParm);

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
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
        /// <param name="inParm">絞込条件</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList, Hashtable inParm)
        {
            Warehouse warehouse = null;
            DataRow guideRow = null;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while (dataCnt < retList.Count)
            {
                warehouse = (Warehouse)retList[dataCnt];
                guideRow = retDataSet.Tables[0].NewRow();
                // データコピー処理
                CopyToGuideRowFromWarehouse(ref guideRow, warehouse);
                // データ追加
                retDataSet.Tables[0].Rows.Add(guideRow);

                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// ガイド用データセット列情報構築処理
        /// </summary>
        /// <param name="guideList">ガイド用データセット</param>>
        /// <remarks>
        /// <br>Note       : ガイド用データセットの列情報を構築します。
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction(ref DataSet guideList)
        {
            DataTable table = new DataTable();
            DataColumn column;

            // 拠点コード
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_SECTIONCODE_TITLE;
            table.Columns.Add(column);

            // 倉庫コード
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSECODE_TITLE;
            table.Columns.Add(column);

            // 倉庫名称
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENAME_TITLE;
            table.Columns.Add(column);

            // 倉庫備考
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE1_TITLE;
            table.Columns.Add(column);

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 倉庫備考2
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE2_TITLE;
            table.Columns.Add(column);

            // 倉庫備考3
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE3_TITLE;
            table.Columns.Add(column);

            // 倉庫備考4
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE4_TITLE;
            table.Columns.Add(column);

            // 倉庫備考5
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE5_TITLE;
            table.Columns.Add(column);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 得意先コード
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_CUSTOMERCODE_TITLE;
            table.Columns.Add(column);

            // 主管倉庫コード
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_MAINMNGWAREHOUSECD_TITLE;
            table.Columns.Add(column);

            // 在庫一括リマーク
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_STOCKBLANKREMARK_TITLE;
            table.Columns.Add(column);
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // テーブルコピー
            guideList.Tables.Add(table.Clone());
        }

        #endregion
    }
}
