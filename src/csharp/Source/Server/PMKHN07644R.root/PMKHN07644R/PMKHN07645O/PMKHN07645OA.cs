//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ（インポート）
// プログラム概要   : 得意先マスタ（インポート）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/06/12  修正内容 : 大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/03  修正内容 ：大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/11  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.62の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/13  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.7の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/20  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.108の対応
//----------------------------------------------------------------------------//
using System;
using System.Data;// ADD  2012/06/12  李亜博 Redmine#30393
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ（インポート）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（インポート）DBインターフェースです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2012/06/12 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
    /// <br>Update Note: 2012/07/03 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
    /// <br>Update Note: 2012/07/11 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.62の対応</br>
    /// <br>Update Note: 2012/07/13 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.7の対応</br>
    /// <br>Update Note: 2012/07/20 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomerImportDB
    {
        /// <summary>
        /// 得意先マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="checkDiv">チェック区分</param>
        /// <param name="consTaxLay">消費税転嫁方式</param>
        /// <param name="objImportWorkList">インポートデータリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="logCnt">ログ件数</param>// ADD  2012/06/12  李亜博 Redmine#30393
        /// <param name="logArrayList">ログリスト</param>// ADD  2012/07/03  李亜博 Redmine#30393
        /// <param name="enterpriseCode">企業コード</param>// ADD  2012/06/12  李亜博 Redmine#30393
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（インポート）のインポート処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2012/07/03 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.62の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            Int32 checkDiv, // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
            //[CustomSerializationMethodParameterAttribute("PMKHN09016D", "Broadleaf.Application.Remoting.ParamData.CustomerWork")]// DEL  2012/06/12  李亜博 Redmine#30393
            //ref object importWorkList, //DEL  2012/06/12  李亜博 Redmine#30393
            //ref object importWorkTable,//ADD  2012/06/12  李亜博 Redmine#30393 DEL  2012/07/03  李亜博 Redmine#30393
            Int32 consTaxLay,// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
            [CustomSerializationMethodParameterAttribute("PMKHN07646D", "Broadleaf.Application.Remoting.ParamData.CustomerGroupWork")]// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            ref object objImportWorkList,// ADD  2012/07/03  李亜博 Redmine#30393
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
            out Int32 logCnt,
            //out DataTable logTable, // DEL  2012/07/03  李亜博 Redmine#30393
            //out ArrayList logArrayList,// ADD  2012/07/03  李亜博 Redmine#30393// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            // ------ ADD START 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.7の対応-------->>>>
          [CustomSerializationMethodParameterAttribute("PMKHN07646D", "Broadleaf.Application.Remoting.ParamData.CustomerGroupWork")]
            out object logArrayList,
            // ------ ADD END 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.7の対応--------<<<<
            string enterpriseCode,
            // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
            out string errMsg);

    }
}
