//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入伝票照会
// プログラム概要   : 仕入伝票照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍　幸史
// 作 成 日  2008/11/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応9264
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.UIData;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TBO検索マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: TBO検索マスタのアクセスクラスです。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/11/28</br>
    /// </remarks>
    public class TBOSearchUAcs : IGeneralGuideData
    {
        #region ■ Private Members

        private string _enterpriseCode;
        private string _loginSectionCode;

        private ITBOSearchUDB _iTBOSearchUDB;

        // 拠点マスタアクセスクラス
        private SecInfoAcs _secInfoAcs;
        // メーカーマスタアクセスクラス
        private MakerAcs _makerAcs;
        // BLコードマスタアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;
        // 商品マスタアクセスクラス
        private GoodsAcs _goodsAcs;
        // 在庫マスタアクセスクラス
        private SearchStockAcs _searchStockAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

        #endregion ■ Private Members


        #region ■ Constructor
        /// <summary>
        /// TBO検索マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBO検索マスタアクセスクラの新しいインスタンスを生成します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public TBOSearchUAcs()
        {
            try
            {
                this._iTBOSearchUDB = (ITBOSearchUDB)MediationTBOSearchUDB.GetTBOSearchUDB();
            }
            catch
            {
                this._iTBOSearchUDB = null;
            }

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            // インスタンス生成
            string errMsg;
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._searchStockAcs = new SearchStockAcs();
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out errMsg);

            // マスタ読込
            ReadSecInfoSet();
            ReadMakerUMnt();
            ReadBLGoodsCdUMnt();
        }
        #endregion ■ Constructor


        #region ■ Properties
        /// <summary>
        /// 商品アクセスクラス
        /// </summary>
        public GoodsAcs GoodsAccess
        {
            get { return this._goodsAcs; }
        }
        #endregion ■ Properties


        #region ■ Public Methods

        #region マスタ取得処理
        /// <summary>
        /// 拠点情報マスタ取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public SecInfoSet GetSecInfoSet(string sectionCode)
        {
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode];
            }

            return new SecInfoSet();
        }

        /// <summary>
        /// 在庫マスタ取得処理
        /// </summary>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int GetStock(out Stock stock, int makerCode, string goodsNo, string warehouseCode)
        {
            stock = new Stock();

            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            para.GoodsMakerCd = makerCode;
            para.GoodsNo = goodsNo;
            para.WarehouseCode = warehouseCode;

            List<Stock> stockList;
            string errMsg;
            
            int status = this._searchStockAcs.Search(para, out stockList, out errMsg);
            if (status == 0)
            {
                stock = stockList[0];
            }

            return (status);
        }
        #endregion マスタ取得処理

        #region 名称取得
        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// BLコード名取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <remarks>
        /// <br>Note       : BLコード名(半角)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public string GetBLGoodsCdName(int blGoodsCode)
        {
            string blGoodsCdName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsCdName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
            }

            return blGoodsCdName;
        }
        #endregion 名称取得

        #region 検索処理
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBO検索マスタを全検索します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int SearchAll(out ArrayList tboSearchUList, string enterpriseCode)
        {
            tboSearchUList = new ArrayList();

            // 検索処理
            int status = Search(ref tboSearchUList, enterpriseCode);

            return (status);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="equipGanreCode">装備分類コード</param>
        /// <param name="equipName">装備名称</param>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBO検索マスタを全検索します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int Search(out List<GoodsUnitData> goodsUnitDataList, string enterpriseCode, string sectionCode, int equipGanreCode, string equipName)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;

            string errMsg;
            PartsInfoDataSet partsInfoDataSet;

            try
            {
                status = this._goodsAcs.SearchTBO(cndtn, equipGanreCode, equipName, out partsInfoDataSet, out goodsUnitDataList, out errMsg);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 在庫マスタリスト取得処理(論理削除含む)
        /// </summary>
        /// <param name="stockList">在庫マスタリスト</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   商品連結データに該当する在庫マスタリストを取得します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int GetStockList(out List<Stock> stockList, GoodsUnitData goodsUnitData)
        {
            stockList = new List<Stock>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = goodsUnitData.EnterpriseCode;
                goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
                goodsCndtn.GoodsKindCode = 9;

                string errMsg;
                List<GoodsUnitData> goodsUnitDataList;

                status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg);
                if ((status == 0) && (goodsUnitDataList != null))
                {
                    stockList = goodsUnitDataList[0].StockList;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 装備名称リスト検索処理
        /// </summary>
        /// <param name="equipNameList">装備名称リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="equipGanreCode">装備分類</param>
        /// <param name="searchName">検索装備名称</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   検索装備名称に該当する装備名称を検索します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int SearchEquipNameList(out List<string> equipNameList, string enterpriseCode, string sectionCode, int equipGanreCode, string searchName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            string errMsg;

            equipNameList = new List<string>();

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;

            // マスタサーチ
            try
            {
                status = this._goodsAcs.SearchEquipName(cndtn, equipGanreCode, searchName, out equipNameList, out errMsg);
                if (status != 0)
                {
                    return (status);
                }
            }
            catch
            {
                status = -1;
                return (status);
            }

            return (status);
        }

        /// <summary>
        /// 商品検索処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   商品を検索します。(同一品番検索ガイド有り、ユーザー・提供共に表示)</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int SearchGoods(out GoodsUnitData goodsUnitData, int makerCode, string goodsNo)
        {
            goodsUnitData = new GoodsUnitData();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 商品検索条件設定
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.GoodsMakerCd = makerCode;
                goodsCndtn.GoodsNo = goodsNo;
                goodsCndtn.PriceApplyDate = DateTime.Today;
                SecInfoSet secInfoSet = GetSecInfoSet(this._loginSectionCode);
                List<string> warehouseList = new List<string>();
                warehouseList.Add(secInfoSet.SectWarehouseCd1);

                string errMsg;
                List<GoodsUnitData> goodsUnitDataList;
                
                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                if (status == 0)
                {
                    goodsUnitData = (GoodsUnitData)goodsUnitDataList[0];
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        #endregion 検索処理

        #region 更新処理
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="TBOSearchUList">TBO検索マスタリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBO検索マスタ・商品マスタを更新します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int WriteRelation(ArrayList TBOSearchUList, ArrayList goodsUnitDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            customSerializeArrayList.Add(TBOSearchUList);

            if (goodsUnitDataList.Count > 0)
            {
                customSerializeArrayList.Add(goodsUnitDataList);
            }

            string errMsg;
            object paraObj = customSerializeArrayList;

            status = this._goodsAcs.WriteRelation(ref paraObj, out errMsg);
            if (status == 0)
            {

            }

            return (status);
        }
        #endregion 更新処理

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタリスト</param>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBO検索マスタを物理削除します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        public int Delete(ArrayList tboSearchUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList tboSearchUWorkList = new ArrayList();

            foreach (TBOSearchU tboSearchU in tboSearchUList)
            {
                // クラスメンバコピー処理
                tboSearchUWorkList.Add(CopyToTBOSearchUWorkFromTBOSearchU(tboSearchU));
            }

            object paraObj = tboSearchUWorkList;

            try
            {
                status = this._iTBOSearchUDB.Delete(paraObj);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        #endregion 物理削除処理

        #region ガイド処理
        /// <summary>
        /// 装備名称ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGanreCode">装備分類コード</param>
        /// <param name="searchName">検索名(曖昧検索対応)</param>
        /// <param name="equipName">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 装備名称の一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date	    : 2008/11/28</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, int equipGanreCode, string searchName, out string equipName)
        {
            int status = -1;
            equipName = "";

            TableGuideParent tableGuideParent = new TableGuideParent("EQUIPNAMEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("EquipGanreCode", equipGanreCode);
            inObj.Add("SearchName", searchName);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // 装備名称
                equipName = retObj["EquipName"].ToString();
                
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
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date	    : 2008/11/28</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet dataSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string enterpriseCode = "";
            int equipGanreCode;
            string searchName = "";

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
                equipGanreCode = (int)inParm["EquipGanreCode"];
                searchName = inParm["SearchName"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return (status);
            }

            // マスタテーブル読込み
            status = Search(ref dataSet, enterpriseCode, equipGanreCode, searchName);
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

            return (status);
        }
        #endregion ガイド処理

        #endregion ■ Public Methods


        #region ■ Private Methods

        #region マスタ読込
        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }
        #endregion マスタ読込

        #region 検索処理
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBO検索マスタを検索します。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        private int Search(ref ArrayList tboSearchUList, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                TBOSearchUWork paraWork = new TBOSearchUWork();
                paraWork.EnterpriseCode = enterpriseCode;

                ArrayList tboSearchUWorkList = new ArrayList();
                object retObj = tboSearchUWorkList;
                object paraObj = paraWork;

                // 検索処理
                status = this._iTBOSearchUDB.Search(ref retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == 0)
                {
                    tboSearchUWorkList = retObj as ArrayList;

                    foreach (TBOSearchUWork tboSearchUWork in tboSearchUWorkList)
                    {
                        // クラスメンバコピー処理
                        tboSearchUList.Add(CopyToTBOSearchUFromTBOSearchUWork(tboSearchUWork));
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// マスタ検索処理（ガイド表示用）
        /// </summary>
        /// <param name="dataSet">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGanreCode">装備分類コード</param>
        /// <param name="searchName">検索名(曖昧検索対応)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 取得結果をDataSetで返します。
        /// 　　　　　　　　: Noと装備名称のみのDataSetです。</br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date	    : 2008/11/28</br>
        /// </remarks>
        private int Search(ref DataSet dataSet, string enterpriseCode, int equipGanreCode, string searchName)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            string errMsg;
            List<string> equipNameList;

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = this._enterpriseCode;
            cndtn.SectionCode = this._loginSectionCode;

            // マスタサーチ
            try
            {
                status = this._goodsAcs.SearchEquipName(cndtn, equipGanreCode, searchName, out equipNameList, out errMsg);
                if (status != 0)
                {
                    return (status);
                }
            }
            catch
            {
                status = -1;
                return (status);
            }

            ArrayList wkList = new ArrayList();
            for (int index = 0; index < equipNameList.Count; index++)
            {
                TBOSearchU tboSearchU = new TBOSearchU();
                tboSearchU.No = index + 1;
                tboSearchU.EquipName = equipNameList[index];

                wkList.Add(tboSearchU);
            }

            TBOSearchU[] aryTBOSearchU = new TBOSearchU[wkList.Count];

            // データを元に戻す
            for (int i = 0; i < wkList.Count; i++)
            {
                aryTBOSearchU[i] = (TBOSearchU)wkList[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(aryTBOSearchU);
            XmlByteSerializer.ReadXml(ref dataSet, retbyte);

            return (status);
        }
        #endregion 検索処理

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="tboSearchUWork">TBO検索マスタワーククラス</param>
        /// <returns>TBO検索マスタ</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   クラスメンバをコピーします。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        private TBOSearchU CopyToTBOSearchUFromTBOSearchUWork(TBOSearchUWork tboSearchUWork)
        {
            TBOSearchU tboSearchU = new TBOSearchU();

            tboSearchU.CreateDateTime = tboSearchUWork.CreateDateTime;              // 作成日時
            tboSearchU.UpdateDateTime = tboSearchUWork.UpdateDateTime;              // 更新日時
            tboSearchU.EnterpriseCode = tboSearchUWork.EnterpriseCode;              // 企業コード
            tboSearchU.FileHeaderGuid = tboSearchUWork.FileHeaderGuid;              // GUID
            tboSearchU.UpdEmployeeCode = tboSearchUWork.UpdEmployeeCode;            // 更新従業員コード
            tboSearchU.UpdAssemblyId1 = tboSearchUWork.UpdAssemblyId1;              // 更新アセンブリID1
            tboSearchU.UpdAssemblyId2 = tboSearchUWork.UpdAssemblyId2;              // 更新アセンブリID2
            tboSearchU.LogicalDeleteCode = tboSearchUWork.LogicalDeleteCode;        // 論理削除区分
            tboSearchU.BLGoodsCode = tboSearchUWork.BLGoodsCode;                    // BLコード
            tboSearchU.EquipGenreCode = tboSearchUWork.EquipGenreCode;              // 装備分類
            tboSearchU.EquipName = tboSearchUWork.EquipName;                        // 装備名称
            tboSearchU.CarInfoJoinDispOrder = tboSearchUWork.CarInfoJoinDispOrder;  // 車両結合表示順位
            tboSearchU.JoinDestMakerCd = tboSearchUWork.JoinDestMakerCd;            // 結合先メーカーコード
            tboSearchU.JoinDestMakerName = tboSearchUWork.JoinDestMakerName;        // 結合先メーカー名
            tboSearchU.JoinDestPartsNo = tboSearchUWork.JoinDestPartsNo;            // 結合先品番(-付き品番)
            tboSearchU.JoinDestGoodsName = tboSearchUWork.JoinDestGoodsName;        // 結合先品名
            tboSearchU.JoinQty = tboSearchUWork.JoinQty;                            // 結合QTY
            tboSearchU.EquipSpecialNote = tboSearchUWork.EquipSpecialNote;          // 装備企画・特記事項

            // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 >>>>>>START
            if (tboSearchUWork.JoinDestGoodsName.TrimEnd() == string.Empty)
            {
                // 結合先品名が空白の場合、結合先メーカー名も空白で設定
                tboSearchU.JoinDestMakerName = string.Empty;
                tboSearchU.JoinDestGoodsName = string.Empty;
                // ADD 2009/04/09 ------>>>
                // 商品情報は空白で設定
                tboSearchU.BLGoodsCode = 0;
                tboSearchU.JoinDestMakerCd = 0;
                // ADD 2009/04/09 ------<<<
            }
            // 2009.03.30 30413 犬飼 商品マスタ論理削除時の対応 <<<<<<END
            
            return tboSearchU;
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="tboSearchU">TBO検索マスタ</param>
        /// <returns>TBO検索マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   クラスメンバをコピーします。</br>
        /// <br>Programer        :   30414 忍 幸史</br>
        /// <br>Date             :   2008/11/28</br>
        /// </remarks>
        private TBOSearchUWork CopyToTBOSearchUWorkFromTBOSearchU(TBOSearchU tboSearchU)
        {
            TBOSearchUWork tboSearchUWork = new TBOSearchUWork();

            tboSearchUWork.CreateDateTime = tboSearchU.CreateDateTime;              // 作成日時
            tboSearchUWork.UpdateDateTime = tboSearchU.UpdateDateTime;              // 更新日時
            tboSearchUWork.EnterpriseCode = tboSearchU.EnterpriseCode;              // 企業コード
            tboSearchUWork.FileHeaderGuid = tboSearchU.FileHeaderGuid;              // GUID
            tboSearchUWork.UpdEmployeeCode = tboSearchU.UpdEmployeeCode;            // 更新従業員コード
            tboSearchUWork.UpdAssemblyId1 = tboSearchU.UpdAssemblyId1;              // 更新アセンブリID1
            tboSearchUWork.UpdAssemblyId2 = tboSearchU.UpdAssemblyId2;              // 更新アセンブリID2
            tboSearchUWork.LogicalDeleteCode = tboSearchU.LogicalDeleteCode;        // 論理削除区分
            tboSearchUWork.BLGoodsCode = tboSearchU.BLGoodsCode;                    // BLコード
            tboSearchUWork.EquipGenreCode = tboSearchU.EquipGenreCode;              // 装備分類
            tboSearchUWork.EquipName = tboSearchU.EquipName;                        // 装備名称
            tboSearchUWork.CarInfoJoinDispOrder = tboSearchU.CarInfoJoinDispOrder;  // 車両結合表示順位
            tboSearchUWork.JoinDestMakerCd = tboSearchU.JoinDestMakerCd;            // 結合先メーカーコード
            tboSearchUWork.JoinDestMakerName = tboSearchU.JoinDestMakerName;        // 結合先メーカーコード
            tboSearchUWork.JoinDestPartsNo = tboSearchU.JoinDestPartsNo;            // 結合先品番(-付き品番)
            tboSearchUWork.JoinDestGoodsName = tboSearchU.JoinDestGoodsName;        // 結合先品番(-付き品番)
            tboSearchUWork.JoinQty = tboSearchU.JoinQty;                            // 結合QTY
            tboSearchUWork.EquipSpecialNote = tboSearchU.EquipSpecialNote;          // 装備企画・特記事項
            
            return tboSearchUWork;
        }
        #endregion クラスメンバコピー処理

        #endregion ■ Private Methods
    }
}
