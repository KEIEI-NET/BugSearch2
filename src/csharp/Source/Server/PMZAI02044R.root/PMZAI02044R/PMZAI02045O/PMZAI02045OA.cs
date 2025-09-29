using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注残クリアDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注残クリアDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/16 呉元嘯</br>
    /// <br>Date       : 商品管理情報マスタの仕入先を参照するように変更</br>
    /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>Update Note: 2010/08/02 22018 鈴木 正臣</br>
    /// <br>           : 在庫マスタの発注残は仕入データ分を減算せずにゼロを固定でセットするよう変更</br>
    /// <br>Update Note: 2011/04/11 liyp</br>
    /// <br>           : 画面で仕入先を範囲指定しても全データの発注残がクリアされる不具合修正</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesOrderRemainClearDB
    {
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        int SearchUpdate(object extrInfo_SalesOrderRemainClearWork);
        // -------------ADD 2009/12/16------------->>>>>
        /// <summary>
        /// 抽出条件に合致した在庫データの取得。
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの取得を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        [MustCustomSerialization]
        int Search(
           [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
             out object resultList, object extrInfo_SalesOrderRemainClearWork);
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。
        /// </summary>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        // ----------------UPD 2010/06/08--------------->>>>>
        //int Update(object resultList);
        int Update(object resultList, object stockDetailWk);
        // ----------------UPD 2010/06/08---------------<<<<<
        // -------------ADD 2009/12/16-------------<<<<<

        // -------------ADD 2011/04/11------------->>>>>
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。
        /// </summary>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        int Update(object resultList);
        // -------------ADD 2011/04/11-------------<<<<<

        // ----------------ADD 2010/06/08--------------->>>>>
        /// <summary>
        /// 仕入明細データから対象明細の取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した仕入明細データの取得を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        int SearchStockDetail(out object rsultList, object extrInfo_SalesOrderRemainClearWork);

        /// <summary>
        /// 在庫マスタデータから対象明細の取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫マスタデータの取得を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        int SearchStock(out object rsultList, object extrInfo_StockDetailWork);

        // ----------------ADD 2010/06/08---------------<<<<<
        // --- ADD m.suzuki 2010/08/02 ---------->>>>>
        /// <summary>
        /// 仕入明細更新処理（仕入データのみ更新）
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <returns></returns>
        int UpdateStockDetail( object stockDetailWork );
        // --- ADD m.suzuki 2010/08/02 ----------<<<<<
    }
}
