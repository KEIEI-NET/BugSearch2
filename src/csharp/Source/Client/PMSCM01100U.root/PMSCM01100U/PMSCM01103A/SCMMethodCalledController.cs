//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/13  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 13.フル型式固定番号からのＢＬコード検索回数改良対応
//                                : 14.明細取込区分の更新方法を改良対応
//                                : 15.SCM受発注データ（車両情報）取得方法改良対応
//                                : 16.純正品検索改良対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メソッドコールによる起動の回答送信処理コントローラクラス
    /// </summary>
    public sealed class SCMMethodCalledController : PMNSBatchController
    {
        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="headerList">SCM受注データのレコードリスト</param>
        /// <param name="carList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="answerList">SCMっ受注明細データ(回答)のレコードリスト</param>
        public SCMMethodCalledController(
            IList<ISCMOrderHeaderRecord> headerList,
            IList<ISCMOrderCarRecord> carList,
            IList<ISCMOrderDetailRecord> detailList,
            IList<ISCMOrderAnswerRecord> answerList
        )
        {
            // SCMIOにデータを渡す
            SCMIO.FoundSendingHeaderList = headerList;
            SCMIO.FoundSendingCarList = carList;
            //SCMIO.FoundSendingDetailList = detailList;
            SCMIO.FoundSendingAnswerList = answerList;
        }
        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// カスタムコンストラクタ(PCCUOEのため新規追加)
        /// </summary>
        /// <param name="headerList">SCM受注データのレコードリスト</param>
        /// <param name="carList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="answerList">SCMっ受注明細データ(回答)のレコードリスト</param>
        /// <param name="setDtList">SCMセットマスタのレコードリスト</param>
        public SCMMethodCalledController(
            IList<ISCMOrderHeaderRecord> headerList,
            IList<ISCMOrderCarRecord> carList,
            IList<ISCMOrderAnswerRecord> answerList,
            IList<ISCMAcOdSetDtRecord> setDtList
        )
        {
            // SCMIOにデータを渡す
            SCMIO.FoundSendingHeaderList = headerList;
            SCMIO.FoundSendingCarList = carList;
            SCMIO.FoundSendingAnswerList = answerList;
            SCMIO.FoundSendingSetDtList = setDtList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ---------------------------------->>>>>
        /// <summary>
        /// カスタムコンストラクタ(PCCUOEのため新規追加)
        /// </summary>
        /// <param name="headerList">SCM受注データのレコードリスト</param>
        /// <param name="carList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="answerList">SCMっ受注明細データ(回答)のレコードリスト</param>
        /// <param name="setDtList">SCMセットマスタのレコードリスト</param>
        public SCMMethodCalledController(
            IList<ISCMOrderHeaderRecord> headerList,
            IList<ISCMOrderCarRecord> carList,
            IList<ISCMOrderAnswerRecord> answerList,
            IList<ISCMAcOdSetDtRecord> setDtList,
            List<ScmOdDtCar> scmOdDtCarList
        )
        {
            // SCMIOにデータを渡す
            SCMIO.FoundSendingHeaderList = headerList;
            SCMIO.FoundSendingCarList = carList;
            SCMIO.FoundSendingAnswerList = answerList;
            SCMIO.FoundSendingSetDtList = setDtList;

            // SCM受発注データ（車両情報）マップにデータをキャッシュする
            this.SCMWebDB.SetWebCarReaccessionMap(scmOdDtCarList, headerList[0]);
        }
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ----------------------------------<<<<<

        #endregion // </Constructor>
    }
}
