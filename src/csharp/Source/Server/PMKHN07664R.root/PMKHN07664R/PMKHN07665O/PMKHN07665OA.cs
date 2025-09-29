//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品管理情報マスタ（インポート）
// プログラム概要   : 商品管理情報マスタ（インポート）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/06/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2012/07/03  修正内容 : お客様の指摘の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2012/07/13  修正内容 : お客様の指摘の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/19  修正内容 : 障害一覧の指摘NO.110の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品管理情報マスタ（インポート）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品管理情報マスタ（インポート）DBインターフェースです。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsMngImportDB
    {
        /// <summary>
        /// 商品管理情報マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="checkKbn">チェック区分</param>
        /// <param name="importGoodsWorkList">商品管理情報マスタインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataList">エラーテーブル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタ（インポート）のインポート処理を行う。</br>
        /// <br>Programmer : 張曼</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note: 2012/07/13 張曼</br>
        /// <br>管理番号   : 10801804-00、大陽案件、お客様の指摘の対応</br>
        /// <br>Update Note : 2012/07/19 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
        /// </remarks>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            Int32 checkKbn, // ADD 姚学剛 2012/07/19 FOR REDMINE#30388
            //[CustomSerializationMethodParameterAttribute("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
            [CustomSerializationMethodParameterAttribute("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.ImportGoodsMngWork")] // ---ADD 2012/07/13 張曼
            ref object importGoodsWorkList,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            out Int32 errCnt,
            //out DataTable dataTable,// ---DEL 2012/07/03 張曼
            //out ArrayList dataList,   // ---ADD 2012/07/03 張曼 // ---DEL 2012/07/13 張曼
            // --- ADD 2012/07/13 張曼 ----->>>>>
            [CustomSerializationMethodParameterAttribute("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.ImportGoodsMngWork")]
            out object dataList,
            // --- ADD 2012/07/13 張曼 -----<<<<<
            out string errMsg);

    }
}
