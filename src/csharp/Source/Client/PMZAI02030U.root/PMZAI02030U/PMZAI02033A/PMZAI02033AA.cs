using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注残クリアアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注残クリアのアクセスクラスです。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.10.23</br>
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>            ・排他制御処理追加。</br>
    /// <br>Update Note: 2009/12/16 呉元嘯</br>
    /// <br>            ・商品管理情報マスタの仕入先を参照するように変更</br>
    /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/22 30517 夏野 駿希</br>
    /// <br>            ・商品属性がその他の商品に対してクリア処理がかからない不具合の修正</br>
    /// <br>Update Note: 2010/08/02 22018 鈴木 正臣</br>
    /// <br>            ・在庫マスタの発注残は仕入データ分を減算せずにゼロを固定でセットするよう変更</br>
    /// <br>Update Note: 2011/04/11 liyp</br>
    /// <br>           : 画面で仕入先を範囲指定しても全データの発注残がクリアされる不具合修正</br>
    /// </remarks>
    public class SalesOrderRemainClearAcs
    {
        #region ■ コンストラクタ
        public SalesOrderRemainClearAcs()
        {
        }
        #endregion

        #region publicメソッド
        /// <summary>
        /// 発注残クリア実行
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// <br>Update Note: 2011/04/11 liyp</br>
        /// <br>           : 画面で仕入先を範囲指定しても全データの発注残がクリアされる不具合修正</br>
        /// </remarks>
        public int Clear(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear, out string msg)
        {
            msg = string.Empty;
            int status = 0;

            ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork;
            
            // 検索条件設定
            this.SetClearParameter(extrInfo_SalesOrderRemainClear, out extrInfo_SalesOrderRemainClearWork);         

            // 実行
            ISalesOrderRemainClearDB mediationSalesOrderRemainClearDB =
                (ISalesOrderRemainClearDB) MediationSalesOrderRemainClearDB.GetSalesOrderRemainClearDB();

            //status = mediationSalesOrderRemainClearDB.SearchUpdate(extrInfo_SalesOrderRemainClearWork);// DEL 2009/12/16
            // -------------ADD 2009/12/16------------->>>>>
            // -------------UPD 2010/06/08------------->>>>>
            //object resultList = null;
            object stockDetailResultList = null;
            bool updateStatus = false;
            // 商品管理情報マスタ取得用
            GoodsAcs _goodsAcs = new GoodsAcs();
            //status = mediationSalesOrderRemainClearDB.Search(out resultList, extrInfo_SalesOrderRemainClearWork);
            status = mediationSalesOrderRemainClearDB.SearchStockDetail(out stockDetailResultList, extrInfo_SalesOrderRemainClearWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList stockDetailResultData = stockDetailResultList as ArrayList;
                foreach (StockDetailWork sdw in stockDetailResultData)
                {
                    object resultList = null;
                    status = mediationSalesOrderRemainClearDB.SearchStock(out resultList, sdw);
                    // -------------UPD 2010/06/08-------------<<<<<
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList resultData = resultList as ArrayList;
                        if (resultData != null)
                        {
                            // 商品管理在庫クラスから仕入れ情報を取得し、ない場合は結果として返さない
                            List<GoodsUnitData> unitDataList = new List<GoodsUnitData>();
                            GoodsUnitData unitData = new GoodsUnitData();
                            string message = string.Empty;
                            ArrayList al = new ArrayList();
                            int st_SupplierCd = extrInfo_SalesOrderRemainClearWork.St_SupplierCd;
                            int ed_SupplierCd = extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd;
                            // 画面.仕入先未入力した場合
                            if (st_SupplierCd == 0 && ed_SupplierCd == 999999)
                            {
                                al = resultData;
                            }
                            else
                            {
                                foreach (StockWork sw in resultData)
                                {
                                    int status_1 = 0;
                                    // 在庫マスタの発注先が未設定の場合
                                    if (sw.StockSupplierCode == 0)
                                    {
                                        // 商品在庫管理クラスを検索
                                        GoodsCndtn condition = new GoodsCndtn();
                                        condition.EnterpriseCode = sw.EnterpriseCode;
                                        condition.SectionCode = sw.SectionCode;
                                        condition.GoodsMakerCd = sw.GoodsMakerCd;
                                        condition.GoodsNo = sw.GoodsNo;
                                        // 2010/06/22 Add 商品属性に関わらずクリアする >>>
                                        condition.GoodsKindCode = 9;
                                        // 2010/06/22 Add <<<
                                        //SearchStockAcs.LogWrite("▼商品検索　開始");
                                        status_1 = _goodsAcs.Search(condition, out unitDataList, out message);
                                        //SearchStockAcs.LogWrite("▲商品検索　終了");
                                        if (status_1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            unitData = unitDataList[0];
                                            _goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);
                                            // 商品管理情報マスタ.仕入先がある場合
                                            if (unitData.SupplierCd != 0)
                                            {
                                                CheckData(ref al, st_SupplierCd, ed_SupplierCd, unitData.SupplierCd, sw);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        CheckData(ref al, st_SupplierCd, ed_SupplierCd, sw.StockSupplierCode, sw);
                                    }

                                }
                            }
                            //データがある場合
                            if (al.Count > 0)
                            {
                                // -------------UPD 2010/06/08------------->>>>>
                                //status = mediationSalesOrderRemainClearDB.Update(al);
                                // --- UPD m.suzuki 2010/08/02 ---------->>>>>
                                //status = mediationSalesOrderRemainClearDB.Update(al, sdw);
                                status = mediationSalesOrderRemainClearDB.UpdateStockDetail( sdw ); // 仕入データ更新
                                // --- UPD m.suzuki 2010/08/02 ----------<<<<<
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    updateStatus = true;
                                }
                                // -------------UPD 2010/06/08-------------<<<<<
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                    }
                    // -------------ADD 2010/06/08------------->>>>>
                }
                if (updateStatus)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // -------------ADD 2010/06/08-------------<<<<<
            // --- ADD m.suzuki 2010/08/02 ---------->>>>>
            if ( status != (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT &&
                 status != (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT &&
                 status != (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT )
            {
                // 在庫マスタの発注残をクリア
                // status = mediationSalesOrderRemainClearDB.SearchUpdate( extrInfo_SalesOrderRemainClearWork ); // DEL 2011/04/01
                // -------------ADD 2011/04/11------------->>>>>
                object resultList2 = null;
                status = mediationSalesOrderRemainClearDB.Search(out resultList2, extrInfo_SalesOrderRemainClearWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultData2 = resultList2 as ArrayList;
                    if (resultData2 != null)
                    {
                        // 商品管理在庫クラスから仕入れ情報を取得し、ない場合は結果として返さない
                        List<GoodsUnitData> unitDataList2 = new List<GoodsUnitData>();
                        GoodsUnitData unitData2 = new GoodsUnitData();
                        string message = string.Empty;
                        ArrayList al = new ArrayList();
                        int st_SupplierCd = extrInfo_SalesOrderRemainClearWork.St_SupplierCd;
                        int ed_SupplierCd = extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd;
                        // 画面.仕入先未入力した場合
                        if (st_SupplierCd == 0 && ed_SupplierCd == 999999)
                        {
                            al = resultData2;
                        }
                        else
                        {
                            foreach (StockWork sw in resultData2)
                            {
                                int status_1 = 0;
                                // 在庫マスタの発注先が未設定の場合
                                if (sw.StockSupplierCode == 0)
                                {
                                    // 商品在庫管理クラスを検索
                                    GoodsCndtn condition = new GoodsCndtn();
                                    condition.EnterpriseCode = sw.EnterpriseCode;
                                    condition.SectionCode = sw.SectionCode;
                                    condition.GoodsMakerCd = sw.GoodsMakerCd;
                                    condition.GoodsNo = sw.GoodsNo;
                                    condition.GoodsKindCode = 9; // 商品属性に関わらずクリアする
                                    //SearchStockAcs.LogWrite("▼商品検索　開始");
                                    status_1 = _goodsAcs.Search(condition, out unitDataList2, out message);
                                    //SearchStockAcs.LogWrite("▲商品検索　終了");
                                    if (status_1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        unitData2 = unitDataList2[0];
                                        _goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData2);
                                        // 商品管理情報マスタ.仕入先がある場合
                                        if (unitData2.SupplierCd != 0)
                                        {
                                            CheckData(ref al, st_SupplierCd, ed_SupplierCd, unitData2.SupplierCd, sw);
                                        }
                                    }
                                }
                                else
                                {
                                    CheckData(ref al, st_SupplierCd, ed_SupplierCd, sw.StockSupplierCode, sw);
                                }

                            }
                        }
                        //データがある場合
                        if (al.Count > 0)
                        {
                            status = mediationSalesOrderRemainClearDB.Update(al);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
                // -------------ADD 2011/04/11-------------<<<<<
            }
            // --- ADD m.suzuki 2010/08/02 ----------<<<<<

            // -------------ADD 2009/12/16-------------<<<<<
            switch (status)
            {
                // --- ADD 2009/02/02 -------------------------------->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    msg = "シェアチェックエラー(企業ロック)です。" + "\r\n"
                            + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    msg = "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                        + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                        + "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n";
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    msg = "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                        + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                        + "再試行するか、しばらく待ってから再度処理を行ってください。" + "\r\n";
                    break;
                // --- ADD 2009/02/02 --------------------------------<<<<<
            }

            return status;
        }

        // ----------ADD 2009/12/16------------>>>>>
        /// <summary>
        /// 在庫データのチェック
        /// </summary>
        /// <remarks>
        /// <param name="al">al</param>
        /// <param name="st_SupplierCd">画面の開始仕入先</param>
        /// <param name="ed_SupplierCd">画面の終了仕入先</param>
        /// <param name="supplier">在庫データの仕入先</param>
        /// <param name="sw">在庫データ</param>
        /// <br>Note       : 在庫データのチェックを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        private void CheckData(ref ArrayList al, int st_SupplierCd, int ed_SupplierCd, int supplier, StockWork sw)
        {
            // 開始仕入先と終了仕入先入力した場合
            if (st_SupplierCd != 0 && ed_SupplierCd != 999999)
            {
                if (supplier >= st_SupplierCd && supplier <= ed_SupplierCd)
                {
                    al.Add(sw);
                }
            }
            // 開始仕入先入力した場合
            else if (st_SupplierCd != 0 && ed_SupplierCd == 999999)
            {
                if (supplier >= st_SupplierCd)
                {
                    al.Add(sw);
                }
            }
            // 終了仕入先入力した場合
            else if (st_SupplierCd == 0 && ed_SupplierCd != 999999)
            {
                if (supplier <= ed_SupplierCd)
                {
                    al.Add(sw);
                }
            }
        }
        // ----------ADD 2009/12/16------------<<<<<
        #endregion

        #region ■ privateメソッド
        /// <summary>
        /// リモート抽出条件設定
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear"></param>
        /// <param name="extrInfo_SalesOrderRemainClearWork"></param>
        /// <remarks>
        /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        private void SetClearParameter(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear,
                                        out ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork)
        {
            extrInfo_SalesOrderRemainClearWork = new ExtrInfo_SalesOrderRemainClearWork();

            extrInfo_SalesOrderRemainClearWork.EnterpriseCode = extrInfo_SalesOrderRemainClear.EnterpriseCode;
            extrInfo_SalesOrderRemainClearWork.St_WarehouseCode = extrInfo_SalesOrderRemainClear.St_WarehouseCode;
            extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode = extrInfo_SalesOrderRemainClear.Ed_WarehouseCode;
            extrInfo_SalesOrderRemainClearWork.St_SupplierCd = extrInfo_SalesOrderRemainClear.St_SupplierCd;
            extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd = extrInfo_SalesOrderRemainClear.Ed_SupplierCd;
            // ----------DEL 2010/06/08------------>>>>>
            //extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd = extrInfo_SalesOrderRemainClear.St_GoodsMakerCd;
            //extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd = extrInfo_SalesOrderRemainClear.Ed_GoodsMakerCd;
            //extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode = extrInfo_SalesOrderRemainClear.St_BLGoodsCode;
            //extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode = extrInfo_SalesOrderRemainClear.Ed_BLGoodsCode;
            // ----------DEL 2010/06/08------------<<<<<
        }
        #endregion
    }
}
