using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 在庫調整データDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫調整データDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2007.02.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockAdjustDB
	{

        #region カスタムシリアライズ対応メソッド
        /// <summary>
		/// 指定された在庫調整データGuidの在庫調整データを戻します
		/// </summary>
		/// <param name="parabyte">StockAdjustWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された在庫調整データGuidの在庫調整データを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
		int Read(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object parabyte, int readMode);

		/// <summary>
		/// 在庫調整データ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 在庫調整データ情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
		int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object parabyte, out string retMsg);

		/// <summary>
		/// 在庫調整データLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="stockAdjustWork">検索結果</param>
		/// <param name="parastockAdjustWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object stockAdjustWork,
			object parastockAdjustWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 在庫調整データ、在庫調整明細データLISTを戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockAdjustSlipNo">在庫仕入伝票番号</param>
        /// <param name="stockAdjustWork">在庫調整データ検索結果</param>
        /// <param name="stockAdjustDtlWork">在庫調整明細データ検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.09.02</br>
        [MustCustomSerialization]
        int SearchSlipAndDtl(
            string enterpriseCode,int stockAdjustSlipNo,
            [CustomSerializationMethodParameterAttribute("MAZAI04366D", "Broadleaf.Application.Remoting.ParamData.StockAdjustWork")]
			ref ArrayList stockAdjustWork,
            [CustomSerializationMethodParameterAttribute("MAZAI04366D", "Broadleaf.Application.Remoting.ParamData.StockAdjustDtlWork")]
			ref ArrayList stockAdjustDtlWork
            );
        
        /// <summary>
		/// 在庫調整データ情報を登録、更新します(在庫仕入入力用)
		/// </summary>
		/// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 在庫調整データ情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork,
            out string retMsg
			);

        /// <summary>
        /// 在庫調整データ情報を登録、更新します(在庫一括登録、商品在庫マスメン用)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustListオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int WriteBatch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustCustList,
            out string retMsg
            );
        // --- DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        ///// <summary>
        ///// 棚卸データを元在庫調整データ情報を登録、更新します
        ///// </summary>
        ///// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        ///// <param name="retMsg">メッセージ</param>
        ///// <param name="shelfNoUpdateDiv">棚番更新区分 (0:する 1:しない)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2007.02.14</br>
        //[MustCustomSerialization]
        //int WriteInventory(
        //    [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
        //    ref object stockAdjustWork,
        //    out string retMsg,
        //    int shelfNoUpdateDiv  
        //    );
        // --- DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<

        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        /// <summary>
        /// 棚卸データを元在庫調整データ情報を登録、更新します
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="shelfNoUpdateDiv">棚番更新区分 (0:する 1:しない)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : 2015/08/21</br>
        int WriteInventory(
            object stockAdjustWork,
            out string retMsg,
            int shelfNoUpdateDiv
            );

        /// <summary>
        /// 棚卸検索(過不足專用)　陳嘯
        /// </summary>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="inventInputUpdateCndtnWork">更新パラメータ</param>
        /// <param name="isSaved">isSaved</param>
        /// <param name="secInfoSetDic">拠点コードと名称</param>
        /// <param name="warehouseDic">倉庫コードと名称</param>
        /// <param name="makerUMntDic">メーカコードと名称</param>
        /// <param name="blGoodsCdUMntDic">BL商品コードと名称</param>
        /// <param name="meaaage">meaaage</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        int SearchInventAndUpdate(
            object paraobj,
            object inventInputUpdateCndtnWork,
            out bool isSaved,
            object secInfoSetDic,
            object warehouseDic,
            object makerUMntDic,
            object blGoodsCdUMntDic,
            out string meaaage
            );
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<

        /// <summary>
        /// 在庫調整データ情報を登録、更新します(委託補充用)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="warehouseList">シェアチェック用倉庫リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int WriteEntrust(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork,
            out string retMsg,
            ref object warehouseList
            );

        /// <summary>
		/// 在庫調整データ情報を論理削除します
		/// </summary>
		/// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 在庫調整データ情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork
			);

		/// <summary>
		/// 論理削除在庫調整データ情報を復活します
		/// </summary>
		/// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除在庫調整データ情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork
			);
		#endregion
	}
}
