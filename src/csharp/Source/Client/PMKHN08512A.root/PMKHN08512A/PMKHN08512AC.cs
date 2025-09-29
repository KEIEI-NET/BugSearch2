using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 倉庫情報テーブルアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 倉庫情報テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class WarehousePrintSetAcs 
	{

		/// <summary>リモートオブジェクト格納バッファ</summary>
        IWarehouseDB _iwarehouseDB = null;
        WarehouseLcDB _warehouseLcDB = null;

        private static bool _isLocalDBRead = false;

        /// <summary>拠点情報格納バッファ</summary>
        private Hashtable _secInfTable = null;

        /// <summary>拠点倉庫名称格納バッファ</summary>
        private Hashtable _sectWarehouseNmTable = null;


        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 倉庫情報テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 倉庫情報テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public WarehousePrintSetAcs()
		{

            this._secInfTable = null;
            this._sectWarehouseNmTable = null;

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
            this._warehouseLcDB = new WarehouseLcDB();   
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
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
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

		/// <summary>
		/// 倉庫情報全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 倉庫情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, WarehousePrintWork warehousePrintWork)
		{
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, 0, 0,  warehousePrintWork);
		}

		/// <summary>
        /// 倉庫情報検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 倉庫情報の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, WarehousePrintWork warehousePrintWork)
		{
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt,  enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0,  warehousePrintWork);
		}

		

		/// <summary>
        /// 倉庫情報検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="warehousePrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 倉庫情報の検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, WarehousePrintWork warehousePrintWork)
		{

            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            retTotalCnt = 0;
            int status_o = 0;
            int checkstatus = 0;

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = warehouseWork;
            object retobj = null;

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

            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        wkList = retobj as ArrayList;

                        if (wkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in wkList)
                            {
                            
                                    // 抽出処理
                                    checkstatus = DataCheck(wkLineupWork, warehousePrintWork);
                                    if (checkstatus == 0)
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

        /// <summary>
        /// 拠点情報検索
        /// </summary>
        /// <param name="sectionGuideNm"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int GetSecInf(out string sectionGuideNm, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            SecInfoSet secInfoSet = null;

            sectionGuideNm = "";

            // 自社情報読み込み
            status = ReadSecInf(out secInfoSet, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sectionGuideNm = secInfoSet.SectionGuideNm;
            }

            return status;
        }

        /// <summary>
        /// 拠点情報読込処理
        /// </summary>
        /// <param name="SecInfoSet"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadSecInf(out SecInfoSet secInfoSet, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            secInfoSet = null;

            status = SetSecInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 読み込み失敗
                return status;
            }

            // テーブルにキーが存在している
            if (this._secInfTable.ContainsKey(sectionCode) == true)
            {
                secInfoSet = ((SecInfoSet)this._secInfTable[sectionCode]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }           

            return status;
        }

        /// <summary>
        /// 拠点情報検索処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetSecInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._secInfTable == null)
            {
                this._secInfTable = new Hashtable();
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._secInfTable.Clear();
                status = secInfoSetAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (this._secInfTable.ContainsKey(secInfoSet.SectionCode) == false)
                        {
                            this._secInfTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
                        }
                    }
                }

            }
            return status;
        }

        /// <summary>
        /// 拠点倉庫名称の取得処理
        /// </summary>
        /// <param name="warehouseName">拠点倉庫名称</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">拠点倉庫コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点倉庫コードから拠点倉庫名称を取得します</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        /// 
        public int GetWarehouseName(out string warehouseName, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            int status = 0;
            Warehouse warehouse = null;

            warehouseName = "";

            // 倉庫情報読み込み
            status = ReadWarehouseInf(out warehouse, enterpriseCode, warehouseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                warehouseName = warehouse.WarehouseName;
            }

            return status;
        }

        /// <summary>
        /// 倉庫情報読込処理
        /// </summary>
        /// <param name="SecInfoSet"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadWarehouseInf(out Warehouse warehouse, string enterpriseCode, string warehouseCode)
        {
            int status = 0;
            warehouse = null;

            status = SetWarehouseInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 読み込み失敗
                return status;
            }

            // テーブルにキーが存在している
            if (this._sectWarehouseNmTable.ContainsKey(warehouseCode) == true)
            {
                warehouse = ((Warehouse)this._sectWarehouseNmTable[warehouseCode]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// 倉庫情報検索処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetWarehouseInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._sectWarehouseNmTable == null)
            {
                this._sectWarehouseNmTable = new Hashtable();
                WarehouseAcs warehouseAcs = new WarehouseAcs();
                warehouseAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._sectWarehouseNmTable.Clear();
                status = warehouseAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (this._sectWarehouseNmTable.ContainsKey(warehouse.WarehouseCode.Trim()) == false)
                        {
                            this._sectWarehouseNmTable.Add(warehouse.WarehouseCode.Trim(), warehouse.Clone());
                        }
                    }
                }

            }
            return status;
        }

        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private string GetCustomerName(out string customerName,string enterpriseCode,int customerCode )
        {
            customerName = "";

            int status;
            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            try
            {
                status = customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm;
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// クラスメンバーコピー処理（倉庫情報ワーククラス⇒拠点情報クラス）
        /// </summary>
        /// <param name="wkLineupWork">倉庫情報ワーククラス</param>
        /// <returns>倉庫情報クラス</returns>
        /// <remarks>
        /// <br>Note       : 倉庫情報ワーククラスから倉庫情報クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private WarehousePrintSet CopyToWarehouseFromWarehouseWork(WarehouseWork wkLineupWork)
        {

            WarehousePrintSet warehousePrintSet = new WarehousePrintSet();

            warehousePrintSet.WarehouseCode = wkLineupWork.WarehouseCode;
            warehousePrintSet.WarehouseName = wkLineupWork.WarehouseName;
            warehousePrintSet.SectionCode = wkLineupWork.SectionCode;

            // ガイド名称取得
            string sectionGuideNm = null;
            GetSecInf(out sectionGuideNm, wkLineupWork.EnterpriseCode, wkLineupWork.SectionCode);
            warehousePrintSet.SectionGuideNm = sectionGuideNm;
            warehousePrintSet.CustomerCode = wkLineupWork.CustomerCode;

            // 得意先名称取得
            string CustomerSnm=null;
            GetCustomerName(out CustomerSnm, wkLineupWork.EnterpriseCode, wkLineupWork.CustomerCode);
            warehousePrintSet.CustomerSnm = CustomerSnm;
            warehousePrintSet.MainMngWarehouseCd = wkLineupWork.MainMngWarehouseCd;

            // 優先倉庫名称取得
            string warehouse = null;
            GetWarehouseName(out warehouse, wkLineupWork.EnterpriseCode,
                wkLineupWork.SectionCode, wkLineupWork.MainMngWarehouseCd.Trim().PadLeft(4,'0'));
            warehousePrintSet.MainWarehouseName = warehouse;
            warehousePrintSet.StockBlnktRemark = wkLineupWork.StockBlnktRemark;

            return warehousePrintSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="secInfoSetWork"></param>
        /// <param name="warehousePrintWork"></param>
        /// <returns></returns>
        private int DataCheck(WarehouseWork warehouseWork, WarehousePrintWork warehousePrintWork)
        {
            int status = 0;

            if (warehouseWork.LogicalDeleteCode != warehousePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = warehouseWork.UpdateDateTime.Year.ToString("0000") +
                                warehouseWork.UpdateDateTime.Month.ToString("00") +
                                warehouseWork.UpdateDateTime.Day.ToString("00");

            if (warehousePrintWork.LogicalDeleteCode == 1 &&
                warehousePrintWork.DeleteDateTimeSt != 0 &&
                warehousePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < warehousePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > warehousePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (warehousePrintWork.LogicalDeleteCode == 1 &&
                        warehousePrintWork.DeleteDateTimeSt != 0 &&
                        warehousePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < warehousePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (warehousePrintWork.LogicalDeleteCode == 1 &&
                       warehousePrintWork.DeleteDateTimeSt == 0 &&
                       warehousePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > warehousePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!warehousePrintWork.WarehouseCodeSt.Trim().Equals(string.Empty) &&
                !warehousePrintWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(warehouseWork.WarehouseCode) < Int32.Parse(warehousePrintWork.WarehouseCodeSt) ||
                   Int32.Parse(warehouseWork.WarehouseCode) > Int32.Parse(warehousePrintWork.WarehouseCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!warehousePrintWork.WarehouseCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(warehouseWork.WarehouseCode) < Int32.Parse(warehousePrintWork.WarehouseCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!warehousePrintWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(warehouseWork.WarehouseCode) > Int32.Parse(warehousePrintWork.WarehouseCodeEd))
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
