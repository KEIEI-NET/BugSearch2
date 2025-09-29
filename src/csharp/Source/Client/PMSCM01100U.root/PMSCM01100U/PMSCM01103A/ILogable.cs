//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田 誠
// 作 成 日  2011/06/01  修正内容 : テーブルレイアウト変更に伴う項目の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/27  修正内容 : 2013/03/13配信 SCM障害№10378対応
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 李侠
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.WebDB;

namespace Broadleaf.Application.Controller
{
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// ログインターフェース
    /// </summary>
    public interface ILogable
    {
        /// <summary>
        /// ログを書込みます。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        void WriteLog(string msg);
    }

    /// <summary>
    /// メッセージユーティリティ
    /// </summary>
    public static class MsgUtil
    {
        #region <CSV変換>

        /// <summary>カンマ</summary>
        public const string COMMA = ",";

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmHeaderRecordList">SCM受発注データのレコードリスト</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<WebHeaderRecordType> scmHeaderRecordList)
        {
            IList<ISCMOrderHeaderRecord> webHeaderRecordList = new List<ISCMOrderHeaderRecord>();
            {
                foreach (WebHeaderRecordType webRecord in scmHeaderRecordList)
                {
                    webHeaderRecordList.Add(new WebSCMOrderHeaderRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (webHeaderRecordList != null && webHeaderRecordList.Count > 0)
                {
                    if (webHeaderRecordList[0] is UserSCMOrderHeaderRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.得意先コード").Append(COMMA);
                        csv.Append("15.更新年月日").Append(COMMA);
                        csv.Append("16.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("17.回答区分").Append(COMMA);
                        csv.Append("18.確定日").Append(COMMA);
                        csv.Append("19.問合せ・発注備考").Append(COMMA);
                        csv.Append("20.添付ファイル").Append(COMMA);
                        csv.Append("21.添付ファイル名").Append(COMMA);
                        csv.Append("22.問合せ従業員コード").Append(COMMA);
                        csv.Append("23.問合せ従業員名称").Append(COMMA);
                        csv.Append("24.回答従業員コード").Append(COMMA);
                        csv.Append("25.回答従業員名称").Append(COMMA);
                        csv.Append("26.問合せ日").Append(COMMA);
                        csv.Append("27.受注ステータス").Append(COMMA);
                        csv.Append("28.売上伝票番号").Append(COMMA);
                        csv.Append("29.売上伝票合計(税込み)").Append(COMMA);
                        csv.Append("30.売上小計(税)").Append(COMMA);
                        csv.Append("31.問合せ・発注種別").Append(COMMA);
                        csv.Append("32.問発・回答種別").Append(COMMA);
                        csv.Append("33.受信日時").Append(COMMA);
                        //csv.Append("34.回答作成区分").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("34.回答作成区分").Append(COMMA);
                        csv.Append("35.キャンセル区分").Append(COMMA);
                        csv.Append("36.CMT連携区分").Append(COMMA);
                        csv.Append("37.SF-PM連携指示書番号").Append(Environment.NewLine);
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ先企業コード").Append(COMMA);
                        csv.Append("07.問合せ先拠点コード").Append(COMMA);
                        csv.Append("08.問合せ番号").Append(COMMA);
                        csv.Append("09.更新年月日").Append(COMMA);
                        csv.Append("10.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("11.回答区分").Append(COMMA);
                        csv.Append("12.確定日").Append(COMMA);
                        csv.Append("13.問合せ・発注備考").Append(COMMA);
                        csv.Append("14.問合せ従業員コード").Append(COMMA);
                        csv.Append("15.問合せ従業員名称").Append(COMMA);
                        csv.Append("16.回答従業員コード").Append(COMMA);
                        csv.Append("17.回答従業員名称").Append(COMMA);
                        csv.Append("18.問合せ日").Append(COMMA);
                        csv.Append("19.問合せ・発注種別").Append(COMMA);
                        csv.Append("20.問発・回答種別").Append(COMMA);
                        csv.Append("21.受信日時").Append(COMMA);
                        //csv.Append("22.最新識別区分").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("22.最新識別区分").Append(COMMA);
                        csv.Append("23.キャンセル区分").Append(COMMA);
                        csv.Append("24.CMT連携区分").Append(COMMA);
                        csv.Append("25.SF-PM連携指示書番号").Append(Environment.NewLine);
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderHeaderRecord scmHeaderRecord in webHeaderRecordList)
                {
                    csv.Append(scmHeaderRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmCarRecord">SCM受発注データ(車両情報)のレコード</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(WebCarRecordType scmCarRecord)
        {
            if (scmCarRecord == null) return "null" + Environment.NewLine;

            IList<WebCarRecordType> scmCarRecordList = new List<WebCarRecordType>();
            {
                scmCarRecordList.Add(scmCarRecord);
            }
            return ConvertCSV(scmCarRecordList);
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmCarRecordList">SCM受発注データ(車両情報)のレコードリスト</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<WebCarRecordType> scmCarRecordList)
        {
            IList<ISCMOrderCarRecord> webCarRecordList = new List<ISCMOrderCarRecord>();
            {
                foreach (WebCarRecordType webRecord in scmCarRecordList)
                {
                    webCarRecordList.Add(new WebSCMOrderCarRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (webCarRecordList != null && webCarRecordList.Count > 0)
                {
                    if (webCarRecordList[0] is UserSCMOrderCarRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ番号").Append(COMMA);
                        csv.Append("12.陸運事務所番号").Append(COMMA);
                        csv.Append("13.陸運事務局名称").Append(COMMA);
                        csv.Append("14.車両登録番号(種別)").Append(COMMA);
                        csv.Append("15.車両登録番号(カナ)").Append(COMMA);
                        csv.Append("16.車両登録番号(プレート番号)").Append(COMMA);
                        csv.Append("17.型式指定番号").Append(COMMA);
                        csv.Append("18.類別番号").Append(COMMA);
                        csv.Append("19.メーカーコード").Append(COMMA);
                        csv.Append("20.車種コード").Append(COMMA);
                        csv.Append("21.車種サブコード").Append(COMMA);
                        csv.Append("22.車種名").Append(COMMA);
                        csv.Append("23.車検証型式").Append(COMMA);
                        csv.Append("24.型式(フル型)").Append(COMMA);
                        csv.Append("25.車台番号").Append(COMMA);
                        csv.Append("26.車台型式").Append(COMMA);
                        csv.Append("27.シャシーNo").Append(COMMA);
                        csv.Append("28.車両固有番号").Append(COMMA);
                        csv.Append("29.生産年式(NUMタイプ)").Append(COMMA);
                        csv.Append("30.コメント").Append(COMMA);
                        csv.Append("31.リペアカラーコード").Append(COMMA);
                        csv.Append("32.カラー名称1").Append(COMMA);
                        csv.Append("33.トリムコード").Append(COMMA);
                        csv.Append("34.トリム名称").Append(COMMA);
                        csv.Append("35.車両走行距離").Append(COMMA);
                        csv.Append("36.装備オブジェクト").Append(COMMA);
                        csv.Append("37.受注ステータス").Append(COMMA);
                        csv.Append("38.売上伝票番号").Append(Environment.NewLine);

                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ番号").Append(COMMA);
                        csv.Append("07.陸運事務所番号").Append(COMMA);
                        csv.Append("08.陸運事務局名称").Append(COMMA);
                        csv.Append("09.車両登録番号(種別)").Append(COMMA);
                        csv.Append("10.車両登録番号(カナ)").Append(COMMA);
                        csv.Append("11.車両登録番号(プレート番号)").Append(COMMA);
                        csv.Append("12.型式指定番号").Append(COMMA);
                        csv.Append("13.類別番号").Append(COMMA);
                        csv.Append("14.メーカーコード").Append(COMMA);
                        csv.Append("15.車種コード").Append(COMMA);
                        csv.Append("16.車種サブコード").Append(COMMA);
                        csv.Append("17.車種名").Append(COMMA);
                        csv.Append("18.車検証型式").Append(COMMA);
                        csv.Append("19.型式(フル型)").Append(COMMA);
                        csv.Append("20.車台番号").Append(COMMA);
                        csv.Append("21.車台型式").Append(COMMA);
                        csv.Append("22.シャシーNo").Append(COMMA);
                        csv.Append("23.車両固有番号").Append(COMMA);
                        csv.Append("24.生産年式(NUMタイプ)").Append(COMMA);
                        csv.Append("25.コメント").Append(COMMA);
                        csv.Append("26.リペアカラーコード").Append(COMMA);
                        csv.Append("27.カラー名称1").Append(COMMA);
                        csv.Append("28.トリムコード").Append(COMMA);
                        csv.Append("29.トリム名称").Append(COMMA);
                        csv.Append("30.車両走行距離").Append(COMMA);
                        csv.Append("31.装備オブジェクト").Append(Environment.NewLine);

                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderCarRecord scmCarRecord in webCarRecordList)
                {
                    csv.Append(scmCarRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmAnswerRecordList">SCM受発注明細データ(回答)のレコードリスト</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 李侠</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public static string ConvertCSV(IList<WebAnswerRecordType> scmAnswerRecordList)
        {
            IList<ISCMOrderAnswerRecord> webAnswerRecordList = new List<ISCMOrderAnswerRecord>();
            {
                foreach (WebAnswerRecordType webRecord in scmAnswerRecordList)
                {
                    webAnswerRecordList.Add(new WebSCMOrderAnswerRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (webAnswerRecordList != null && webAnswerRecordList.Count > 0)
                {
                    if (webAnswerRecordList[0] is UserSCMOrderAnswerRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.更新年月日").Append(COMMA);
                        csv.Append("15.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("16.問合せ行番号").Append(COMMA);
                        csv.Append("17.問合せ行番号枝番").Append(COMMA);
                        csv.Append("18.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("19.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("20.商品種別").Append(COMMA);
                        csv.Append("21.リサイクル部品種別").Append(COMMA);
                        csv.Append("22.リサイクル部品名称").Append(COMMA);
                        csv.Append("23.納品区分").Append(COMMA);
                        csv.Append("24.取扱区分").Append(COMMA);
                        csv.Append("25.商品形態").Append(COMMA);
                        csv.Append("26.納品確認区分").Append(COMMA);
                        csv.Append("27.納品完了予定日").Append(COMMA);
                        csv.Append("28.回答納期").Append(COMMA);
                        csv.Append("29.BL商品コード").Append(COMMA);
                        csv.Append("30.BL商品コード枝番").Append(COMMA);
                        csv.Append("31.問発商品名").Append(COMMA);
                        csv.Append("32.回答商品名").Append(COMMA);
                        csv.Append("33.発注数").Append(COMMA);
                        csv.Append("34.納品数").Append(COMMA);
                        csv.Append("35.商品番号").Append(COMMA);
                        csv.Append("36.商品メーカーコード").Append(COMMA);
                        csv.Append("37.商品メーカー名称").Append(COMMA);
                        csv.Append("38.純正商品メーカーコード").Append(COMMA);
                        csv.Append("39.問発純正商品番号").Append(COMMA);
                        csv.Append("40.回答純正商品番号").Append(COMMA);
                        csv.Append("41.定価").Append(COMMA);
                        csv.Append("42.単価").Append(COMMA);
                        csv.Append("43.商品補足情報").Append(COMMA);
                        csv.Append("44.粗利額").Append(COMMA);
                        csv.Append("45.粗利率").Append(COMMA);
                        csv.Append("46.回答期限").Append(COMMA);
                        csv.Append("47.備考(明細)").Append(COMMA);
                        csv.Append("48.添付ファイル(明細)").Append(COMMA);
                        csv.Append("49.添付ファイル名(明細)").Append(COMMA);
                        csv.Append("50.棚番").Append(COMMA);
                        csv.Append("51.追加区分").Append(COMMA);
                        csv.Append("52.訂正区分").Append(COMMA);
                        csv.Append("53.受注ステータス").Append(COMMA);
                        csv.Append("54.売上伝票番号").Append(COMMA);
                        csv.Append("55.売上伝票行番号").Append(COMMA);
                        csv.Append("56.キャンペーンコード").Append(COMMA);
                        csv.Append("57.在庫区分").Append(COMMA);
                        csv.Append("58.問合せ・発注種別").Append(COMMA);
                        csv.Append("59.表示順位").Append(COMMA);
                        //csv.Append("60.商品管理番号").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("60.商品管理番号").Append(COMMA);  //DEL 2011/06/01
                        csv.Append("61.キャンセル状態区分").Append(COMMA);
                        csv.Append("62.PM受注ステータス").Append(COMMA);
                        csv.Append("63.PM売上伝票番号").Append(COMMA);
                        csv.Append("64.PM売上行番号").Append(COMMA);
                        csv.Append("65.明細取込区分").Append(COMMA);
                        csv.Append("66.PM倉庫コード").Append(COMMA);
                        csv.Append("67.PM倉庫名称").Append(COMMA);
                        csv.Append("68.PM棚番").Append(Environment.NewLine);
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ先企業コード").Append(COMMA);
                        csv.Append("07.問合せ先拠点コード").Append(COMMA);
                        csv.Append("08.問合せ番号").Append(COMMA);
                        csv.Append("09.更新年月日").Append(COMMA);
                        csv.Append("10.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("11.問合せ行番号").Append(COMMA);
                        csv.Append("12.問合せ行番号枝番").Append(COMMA);
                        csv.Append("13.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("14.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("15.商品種別").Append(COMMA);
                        csv.Append("16.リサイクル部品種別").Append(COMMA);
                        csv.Append("17.リサイクル部品名称").Append(COMMA);
                        csv.Append("18.納品区分").Append(COMMA);
                        csv.Append("19.取扱区分").Append(COMMA);
                        csv.Append("20.商品形態").Append(COMMA);
                        csv.Append("21.納品確認区分").Append(COMMA);
                        csv.Append("22.納品完了予定日").Append(COMMA);
                        csv.Append("23.回答納期").Append(COMMA);
                        csv.Append("24.BL商品コード").Append(COMMA);
                        csv.Append("25.BL商品コード枝番").Append(COMMA);
                        csv.Append("26.問発商品名").Append(COMMA);
                        csv.Append("27.回答商品名").Append(COMMA);
                        csv.Append("28.発注数").Append(COMMA);
                        csv.Append("29.納品数").Append(COMMA);
                        csv.Append("30.商品番号").Append(COMMA);
                        csv.Append("31.商品メーカーコード").Append(COMMA);
                        csv.Append("32.商品メーカー名称").Append(COMMA);
                        csv.Append("33.純正商品メーカーコード").Append(COMMA);
                        csv.Append("34.問発純正商品番号").Append(COMMA);
                        csv.Append("35.回答純正商品番号").Append(COMMA);
                        csv.Append("36.定価").Append(COMMA);
                        csv.Append("37.単価").Append(COMMA);
                        csv.Append("38.商品補足情報").Append(COMMA);
                        csv.Append("39.粗利額").Append(COMMA);
                        csv.Append("40.粗利率").Append(COMMA);
                        csv.Append("41.回答期限").Append(COMMA);
                        csv.Append("42.備考(明細)").Append(COMMA);
                        csv.Append("43.棚番").Append(COMMA);
                        csv.Append("44.追加区分").Append(COMMA);
                        csv.Append("45.訂正区分").Append(COMMA);
                        csv.Append("46.問合せ・発注種別").Append(COMMA);
                        csv.Append("47.表示順位").Append(COMMA);
                        //csv.Append("48.最新識別区分").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("48.最新識別区分").Append(COMMA);
                        csv.Append("49.キャンセル状態区分").Append(COMMA);
                        csv.Append("50.PM受注ステータス").Append(COMMA);
                        csv.Append("51.PM売上伝票番号").Append(COMMA);
                        csv.Append("52.PM売上行番号").Append(COMMA);
                        csv.Append("53.明細取込区分").Append(COMMA);
                        csv.Append("54.PM倉庫コード").Append(COMMA);
                        csv.Append("55.PM倉庫名称").Append(COMMA);
                        // UPD 2018/04/16 李侠 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("56.PM棚番").Append(Environment.NewLine);
                        csv.Append("56.PM棚番").Append(COMMA);
                        csv.Append("57.問発BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("58.問発BL統一部品サブコード").Append(COMMA);
                        csv.Append("59.回答BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("60.回答BL統一部品サブコード").Append(COMMA);
                        csv.Append("61.回答BL商品コード").Append(COMMA);
                        csv.Append("62.回答BL商品コード枝番").Append(Environment.NewLine);
                        // UPD 2018/04/16 李侠 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderAnswerRecord scmAnswerRecord in webAnswerRecordList)
                {
                    csv.Append(scmAnswerRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        // ADD 2012/12/27 2013/03/13配信 SCM障害№10378対応 ------------------------------------>>>>> 
        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmDetailRecordList">SCM受発注明細データ(問合せ・発注)のレコードリスト</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 李侠</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public static string ConvertCSV(List<WebDetailRecordType> scmDetailRecordList)
        {
            List<ISCMOrderDetailRecord> webDetailRecordList = new List<ISCMOrderDetailRecord>();
            {
                foreach (WebDetailRecordType webRecord in scmDetailRecordList)
                {
                    webDetailRecordList.Add(new WebSCMOrderDetailRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (webDetailRecordList != null && webDetailRecordList.Count > 0)
                {
                    if (webDetailRecordList[0] is UserSCMOrderDetailRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.更新年月日").Append(COMMA);
                        csv.Append("15.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("16.問合せ行番号").Append(COMMA);
                        csv.Append("17.問合せ行番号枝番").Append(COMMA);
                        csv.Append("18.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("19.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("20.商品種別").Append(COMMA);
                        csv.Append("21.リサイクル部品種別").Append(COMMA);
                        csv.Append("22.リサイクル部品名称").Append(COMMA);
                        csv.Append("23.納品区分").Append(COMMA);
                        csv.Append("24.取扱区分").Append(COMMA);
                        csv.Append("25.商品形態").Append(COMMA);
                        csv.Append("26.納品確認区分").Append(COMMA);
                        csv.Append("27.納品完了予定日").Append(COMMA);
                        csv.Append("28.回答納期").Append(COMMA);
                        csv.Append("29.BL商品コード").Append(COMMA);
                        csv.Append("30.BL商品コード枝番").Append(COMMA);
                        csv.Append("31.問発商品名").Append(COMMA);
                        csv.Append("32.回答商品名").Append(COMMA);
                        csv.Append("33.発注数").Append(COMMA);
                        csv.Append("34.納品数").Append(COMMA);
                        csv.Append("35.商品番号").Append(COMMA);
                        csv.Append("36.商品メーカーコード").Append(COMMA);
                        csv.Append("37.商品メーカー名称").Append(COMMA);
                        csv.Append("38.純正商品メーカーコード").Append(COMMA);
                        csv.Append("39.問発純正商品番号").Append(COMMA);
                        csv.Append("40.回答純正商品番号").Append(COMMA);
                        csv.Append("41.定価").Append(COMMA);
                        csv.Append("42.単価").Append(COMMA);
                        csv.Append("43.商品補足情報").Append(COMMA);
                        csv.Append("44.粗利額").Append(COMMA);
                        csv.Append("45.粗利率").Append(COMMA);
                        csv.Append("46.回答期限").Append(COMMA);
                        csv.Append("47.備考(明細)").Append(COMMA);
                        csv.Append("48.添付ファイル(明細)").Append(COMMA);
                        csv.Append("49.添付ファイル名(明細)").Append(COMMA);
                        csv.Append("50.棚番").Append(COMMA);
                        csv.Append("51.追加区分").Append(COMMA);
                        csv.Append("52.訂正区分").Append(COMMA);
                        csv.Append("53.問合せ・発注種別").Append(COMMA);
                        csv.Append("54.表示順位").Append(COMMA);
                        csv.Append("55.キャンセル状態区分").Append(COMMA);
                        csv.Append("53.受注ステータス").Append(COMMA);
                        csv.Append("54.売上伝票番号").Append(COMMA);
                        csv.Append("55.売上伝票行番号").Append(Environment.NewLine);

                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.更新年月日").Append(COMMA);
                        csv.Append("15.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("16.問合せ行番号").Append(COMMA);
                        csv.Append("17.問合せ行番号枝番").Append(COMMA);
                        csv.Append("18.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("19.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("20.商品種別").Append(COMMA);
                        csv.Append("21.リサイクル部品種別").Append(COMMA);
                        csv.Append("22.リサイクル部品名称").Append(COMMA);
                        csv.Append("23.納品区分").Append(COMMA);
                        csv.Append("24.取扱区分").Append(COMMA);
                        csv.Append("25.商品形態").Append(COMMA);
                        csv.Append("26.納品確認区分").Append(COMMA);
                        csv.Append("27.納品完了予定日").Append(COMMA);
                        csv.Append("28.回答納期").Append(COMMA);
                        csv.Append("29.BL商品コード").Append(COMMA);
                        csv.Append("30.BL商品コード枝番").Append(COMMA);
                        csv.Append("31.問発商品名").Append(COMMA);
                        csv.Append("32.回答商品名").Append(COMMA);
                        csv.Append("33.発注数").Append(COMMA);
                        csv.Append("34.納品数").Append(COMMA);
                        csv.Append("35.商品番号").Append(COMMA);
                        csv.Append("36.商品メーカーコード").Append(COMMA);
                        csv.Append("37.商品メーカー名称").Append(COMMA);
                        csv.Append("38.純正商品メーカーコード").Append(COMMA);
                        csv.Append("39.問発純正商品番号").Append(COMMA);
                        csv.Append("40.回答純正商品番号").Append(COMMA);
                        csv.Append("41.定価").Append(COMMA);
                        csv.Append("42.単価").Append(COMMA);
                        csv.Append("43.商品補足情報").Append(COMMA);
                        csv.Append("44.粗利額").Append(COMMA);
                        csv.Append("45.粗利率").Append(COMMA);
                        csv.Append("46.回答期限").Append(COMMA);
                        csv.Append("47.備考(明細)").Append(COMMA);
                        csv.Append("48.添付ファイル(明細)").Append(COMMA);
                        csv.Append("49.添付ファイル名(明細)").Append(COMMA);
                        csv.Append("50.棚番").Append(COMMA);
                        csv.Append("51.追加区分").Append(COMMA);
                        csv.Append("52.訂正区分").Append(COMMA);
                        csv.Append("53.問合せ・発注種別").Append(COMMA);
                        csv.Append("54.表示順位").Append(COMMA);
                        csv.Append("55.キャンセル状態区分").Append(COMMA);
                        csv.Append("53.受注ステータス").Append(COMMA);
                        csv.Append("54.売上伝票番号").Append(COMMA);
                        // UPD 2018/04/16 李侠 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("55.売上伝票行番号").Append(Environment.NewLine);
                        csv.Append("55.売上伝票行番号").Append(COMMA);
                        csv.Append("56.問発BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("57.問発BL統一部品サブコード").Append(COMMA);
                        csv.Append("58.回答BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("59.回答BL統一部品サブコード").Append(COMMA);
                        csv.Append("60.回答BL商品コード").Append(COMMA);
                        csv.Append("61.回答BL商品コード枝番").Append(Environment.NewLine);
                        // UPD 2018/04/16 李侠 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderDetailRecord scmDetailRecord in webDetailRecordList)
                {
                    csv.Append(scmDetailRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }
        // ADD 2012/12/27 2013/03/13配信 SCM障害№10378対応 ------------------------------------<<<<< 

        #endregion // </CSV変換>
    }
}
