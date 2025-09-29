//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー品番パターンマスタ
// プログラム概要   : メーカー品番パターンマスタ DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// メーカー品番パターンマスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : メーカー品番パターンマスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 陳艶丹</br>
	/// <br>Date       : 2020/03/09</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyMakerGoodsPtrnDB
	{
		#region カスタムシリアライズ対応メソッド
        /// <summary>
        /// メーカー品番パターンマスタ情報を物理削除します
        /// </summary>
        /// <param name="paraMakerGoodsPtrnWork">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー品番パターンマスタ情報を物理削除します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        int Delete(object paraMakerGoodsPtrnWork);

		/// <summary>
		/// メーカー品番パターンマスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="makerGoodsPtrnWork">検索結果</param>
        /// <param name="paraMakerGoodsPtrnWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : メーカー品番パターンマスタLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 陳艶丹</br>
		/// <br>Date       : 2020/03/09</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
			out object makerGoodsPtrnWork,
            HandyMakerGoodsPtrnWork paraMakerGoodsPtrnWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定された条件のメーカー品番パターンマスタ情報を戻します
        /// </summary>
        /// <param name="parabyte">HandyMakerGoodsPtrnWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカー品番パターンマスタ情報を戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 指定された条件のメーカー品番パターンマスタ情報を戻します
        /// </summary>
        /// <param name="makerGoodsPtrnWorkList">makerGoodsPtrnWorkListオブジェクト</param>
        /// <param name="paraMakerGoodsPtrnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="mode">0：マスタ用；1：部品制御用</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカー品番パターンマスタ情報を戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        int ReadByMakerAndBarCodeLength(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
			out object makerGoodsPtrnWorkList,
           HandyMakerGoodsPtrnWork paraMakerGoodsPtrnWork, 
            int readMode, int mode);

		/// <summary>
		/// メーカー品番パターンマスタ情報を登録、更新します
		/// </summary>
        /// <param name="parabyte">HandyMakerGoodsPtrnWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メーカー品番パターンマスタ情報を登録、更新します</br>
		/// <br>Programmer : 陳艶丹</br>
		/// <br>Date       : 2020/03/09</br>
        int Write(ref byte[] parabyte);

		/// <summary>
		/// メーカー品番パターンマスタ情報を論理削除します
		/// </summary>
        /// <param name="paraMakerGoodsPtrnWork">検索条件</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メーカー品番パターンマスタ情報を論理削除します</br>
		/// <br>Programmer : 陳艶丹</br>
		/// <br>Date       : 2020/03/09</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
            ref object paraMakerGoodsPtrnWork
			);

		/// <summary>
		/// 論理削除メーカー品番パターンマスタ情報を復活します
		/// </summary>
        /// <param name="paraMakerGoodsPtrnWork">検索条件</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除メーカー品番パターンマスタ情報を復活します</br>
		/// <br>Programmer : 陳艶丹</br>
		/// <br>Date       : 2020/03/09</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
            ref object paraMakerGoodsPtrnWork
			);
		#endregion

        #region  [メーカー品番パターンマスタ検索履歴照会]
        /// <summary>
        /// メーカー品番パターンマスタ検索履歴抽出処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="retObj">メーカー品番パターンマスタ検索履歴情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタ検索履歴抽出処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchHis(object condObj, out object retObj);
        #endregion

        #region  [商品バーコード関連付けマスタ検索]
        /// <summary>
        /// 商品バーコード関連付けマスタ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsBarCode">パーコード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="retObj">商品バーコード関連付けマスタ情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ検索処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchGoodsBarCodeRevn(string enterpriseCode, string goodsBarCode, int goodsMakerCd, out object retObj);
        #endregion

        #region  [ハンディ在庫登録管理データ登録]
        /// <summary>
        /// ハンディ在庫登録管理データ登録処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディ在庫登録管理データ登録処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteMng(object condObj);
        #endregion
        
        #region  [UOE発注データ存在チェック]
        /// <summary>
        /// UOE発注データ存在チェック処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="count">戻り件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データ存在チェック処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchHandyUOEOrder(ref object condObj, out int count);
        #endregion

        #region  [在庫一括削除対象検索処理]
        /// <summary>
        /// 在庫一括削除対象検索処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="retObj">在庫一括削除対象情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫一括削除対象検索処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchDeleteStockWithMng(object condObj,
             [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyDeleteStockRsltWork")]
             out object retObj);

        /// <summary>
        /// 在庫一括削除対象削除処理
        /// </summary>
        /// <param name="handyDeleteStockRsltWork">削除条件</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫一括削除対象削除します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        int DeleteStockWithMng(object handyDeleteStockRsltWork, string enterpriseCode);
        #endregion

        #region [メーカー品番パターン検索履歴データ登録]
        /// <summary>
        /// メーカー品番パターン検索履歴データを登録、更新します
        /// </summary>
        /// <param name="parabyte">HandyMakerGoodsPtrnHisResultWorkオブジェクト</param>
        /// <param name="mode">0:新規登録；1：更新</param>
        /// <param name="callMode">0：パターン検索処理；1：パターン検索処理以外</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー品番パターン検索履歴データを登録、更新します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        int WriteHis(ref byte[] parabyte, int mode, int callMode);
        #endregion
	}
}
