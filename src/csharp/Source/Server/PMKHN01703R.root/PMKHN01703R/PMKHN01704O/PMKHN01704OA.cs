//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換処理DB RemoteObject Interface
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/02   修正内容 : Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/16   修正内容 : Redmine#44209 優良設定マスタ変換の仕様変更の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
using Broadleaf.Application.Remoting.ParamData;// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 品番変換処理DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 品番変換処理DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2015/01/26</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMeijiGoodsChgAllDB
	{
        /// <summary>
        /// 品番変換処理（インポート）のインポート処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換処理インポートデータリスト</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換処理（インポート）のインポート処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeMst(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
            out object dataList,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 errCnt,
            out string errMsg);

        /// <summary>
        /// 商品在庫マスタの変換処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="goodsStockSucObj">商品在庫変換成功リスト</param>
        /// <param name="goodsStockErrObj">商品在庫変換エラーリスト</param>
        /// <param name="goodsReadCnt">商品読込件数</param>
        /// <param name="priceReadCnt">価格取込件数</param>
        /// <param name="stockReadCnt">在庫取込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品在庫マスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応----->>>>>
        //int GoodsChangeGoodsStock(
        //    object importGoodsWorkList,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object goodsSucObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object goodsErrObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object priceSucObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object priceErrObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object stockSucObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object stockErrObj,
        //    out Int32 goodsReadCnt,
        //    out Int32 priceReadCnt,
        //    out Int32 stockReadCnt);
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        int GoodsChangeGoodsStock(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
            out object goodsStockSucObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
            out object goodsStockErrObj,
            out Int32 goodsReadCnt,
            out Int32 priceReadCnt,
            out Int32 stockReadCnt);
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

        /// <summary>
        /// 商品管理情報マスタの変換処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeGoodsMng(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeiJiGoodsMngWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeiJiGoodsMngWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// 掛率マスタの変換処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeRate(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiRateWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiRateWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// 結合マスタの変換処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeJoin(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewJoinPartsWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewJoinPartsWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// 代替マスタの変換処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 代替マスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeParts(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiPartsSubstWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiPartsSubstWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// セットマスタの変換処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : セットマスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeSet(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.GoodsSetChgWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.GoodsSetChgWork")]
            out object dataList,
            out Int32 readCnt);

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        /// <summary>
        /// 優良設定マスタの変換処理。
        /// </summary>
        /// <param name="cndWork">品番変換マスタインポートデータリスト</param>
        /// <param name="offerPrmDic">提供分優良設定データ</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="loginCnt">更新件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="csvErr"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int PrmSettingChange(
            object cndWork,
            Dictionary<string, PrmSettingWork> offerPrmDic,// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewPrmSettingUWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewPrmSettingUWork")]
            out object dataList,
            out Int32 readCnt,
            out Int32 loginCnt,
            out string errMsg,
            out bool csvErr);
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        /// <summary>
        /// 貸出データ更新処理
        /// </summary>
        /// <param name="cndWork">品番変換マスタインポートデータリスト</param>
        /// <param name="sucObjectList">登録したデータ</param>
        /// <param name="errObjectList">エラーテーブル</param>
        /// <param name="readCnt">読込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 貸出データの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int ShipmentChange(
            object cndWork,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.ShipmentChangeWork")]
            out object sucObjectList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.ShipmentChangeWork")]
            out object errObjectList,
            out Int32 readCnt);
	}
}
