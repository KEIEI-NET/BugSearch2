//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PMNS-HTT通信サービス
// プログラム概要   : PMNS-HTT間の通信を行うサービスプログラムです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 佐藤　智之
// 作 成 日  2017/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 佐藤　智之
// 修 正 日  2017/08/01  修正内容 : ２次開発
//----------------------------------------------------------------------------//
// 管理番号  11575094-00 作成担当 : 岸　傑
// 修 正 日  2019/06/13  修正内容 : 大黒商会検品障害対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 白厩  翔也
// 修 正 日  2019/10/16  修正内容 : ６次対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 修 正 日  2019/11/14  修正内容 : ６次対応
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 白厩  翔也
// 修 正 日  2020/04/01  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace PMHND00100S.Common
{
    /// public class name:   clsBtConst
    /// <summary>
    ///                      共通使用する定数定義クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   プロジェクト内で共通使用する定数を定義する</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   2017/08/01  佐藤　智之</br>
    /// <br>                 :   ２次開発</br>
    /// <br></br>
    /// </remarks>
    class clsBtConst
    {
        /// <summary>起動パタメータ</summary>
        public const string START_PARAMETERS = "dsp";

        /// <summary>設定ファイルのKEY　ハンディとのソケット通信　ＩＰアドレス</summary>
        public const string KEY_SOCKETIPADDRESS = "ipaddress";

        /// <summary>設定ファイルのKEY　ハンディとのソケット通信　ポート</summary>
        public const string KEY_SOCKETPORT = "socketport";

        /// <summary>設定ファイルのKEY　ログの出力判定</summary>
        public const string KEY_DEBUGDETAILLOG = "debugdetaillog";
        public const string DEBUG_DETAIL_LOG_ON = "on";
        public const string DEBUG_DETAIL_LOG_OFF = "off";

        /// <summary>設定ファイルのKEY　ＩＰＣアドレス</summary>
        public const string KEY_IPCADDRESS = "ipcaddress";

        // --- ADD 2019/06/13 ---------->>>>>
        /// <summary>設定ファイルのKEY　リトライ回数</summary>
        public const string KEY_RETRYTIMES = "retrytimes";
        /// <summary>設定ファイルのKEY　リトライ間隔</summary>
        public const string KEY_RETRYINTERVAL = "retryinterval";
        // --- ADD 2019/06/13 ----------<<<<<

        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>キー名称  SOCKET_BUFFER_SIZE</summary>
        public const string KEY_SOCKET_BUFFER_SIZE = "socket_buffer_size";
        // -- ADD 2019/10/16 ------------------------------<<<

        /// <summary>対ハンディソケット通信終了コード</summary>
        public const string HT_MSG_CRLF = "\n";
        /// <summary>ソケット通信　通信終了コード長</summary>
        public const Int32 HT_MSG_CRLF_LEN = 1;

        /// <summary>対ハンディソケット エラー</summary>
        public const string HT_MSG_SOCKETERR = "-3";

        /// <summary>ソケット通信　処理区分 ログイン情報取得</summary>
        public const Int32 SCKSYRKBN_GET_LOGININFO = 1;
        /// <summary>ソケット通信　処理区分 商品情報取得</summary>
        public const Int32 SCKSYRKBN_GET_SYOHININFO = 2;
        /// <summary>ソケット通信　処理区分 伝票情報取得 伝票検品</summary>
        public const Int32 SCKSYRKBN_GET_SLIPINFO_MDDENPYOU = 3;
        /// <summary>ソケット通信　処理区分 伝票情報取得 一括検品</summary>
        public const Int32 SCKSYRKBN_GET_SLIPINFO_MDIKKATSU = 4;
        /// <summary>ソケット通信　処理区分 在庫情報取得</summary>
        public const Int32 SCKSYRKBN_GET_ZAIKOINFO = 5;
        /// <summary>ソケット通信　処理区分 伝票情報更新</summary>
        public const Int32 SCKSYRKBN_INS_SLIPINFO = 6;
        /// <summary>ソケット通信　処理区分 商品情報更新（バーコード）</summary>
        public const Int32 SCKSYRKBN_INS_SYOHININFO_BARCODE = 7;
        /// <summary>ソケット通信　処理区分 商品情報更新（数量）</summary>
        public const Int32 SCKSYRKBN_INS_SYOHININFO_SU = 8;

        // -- ADD 2017/08/01 ------------------------------>>>
        /// <summary>ソケット通信　処理区分 在庫仕入(入庫更新)　伝票一覧取得</summary>
        public const Int32 SCKSYRKBN_GET_NYU_SLIPLIST = 9;
        /// <summary>ソケット通信　処理区分 在庫仕入(入庫更新)　伝票情報取得</summary>
        public const Int32 SCKSYRKBN_GET_NYU_SLIPINFO = 10;
        /// <summary>ソケット通信　処理区分 発注先一覧取得</summary>
        public const Int32 SCKSYRKBN_GET_HACLIST = 11;
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫仕入　入庫更新)</summary>
        public const Int32 SCKSYRKBN_INS_NYU_SLIPINFO = 12;
        /// <summary>ソケット通信　処理区分 在庫仕入(UOE以外)　伝票情報取得</summary>
        public const Int32 SCKSYRKBN_GET_NOTUOE_SLIPINFO = 13;
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫仕入　UOE以外)</summary>
        public const Int32 SCKSYRKBN_INS_NOTUOE_SLIPINFO = 14;
        /// <summary>ソケット通信　処理区分 在庫仕入(入荷/出荷)　伝票情報取得</summary>
        public const Int32 SCKSYRKBN_GET_NYUSYU_SLIPINFO = 15;
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫仕入　入荷/出荷)</summary>
        public const Int32 SCKSYRKBN_INS_NYUSYU_SLIPINFO = 16;
        /// <summary>ソケット通信　処理区分 在庫移動(出荷/入荷)　伝票情報取得</summary>
        public const Int32 SCKSYRKBN_GET_IDO_SLIPINFO = 17;
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫移動　出荷/入荷)</summary>
        public const Int32 SCKSYRKBN_INS_IDO_SLIPINFO = 18;
        /// <summary>ソケット通信　処理区分 倉庫情報取得</summary>
        public const Int32 SCKSYRKBN_GET_SOKO_INFO = 19;
        /// <summary>ソケット通信　処理区分 委託在庫補充　伝票情報取得</summary>
        public const Int32 SCKSYRKBN_GET_ITAKU_SLIPINFO = 20;
        /// <summary>ソケット通信　処理区分 検品データ登録(委託在庫補充)</summary>
        public const Int32 SCKSYRKBN_INS_ITAKU_SLIPINFO = 21;
        /// <summary>ソケット通信　処理区分 棚卸(一斉)情報存在確認</summary>
        public const Int32 SCKSYRKBN_GET_TANA_ISSEICHECK = 22;
        /// <summary>ソケット通信　処理区分 棚卸(一斉)情報取得</summary>
        public const Int32 SCKSYRKBN_GET_TANA_ISSEIINFO = 23;
        /// <summary>ソケット通信　処理区分 棚卸データ登録(一斉)</summary>
        public const Int32 SCKSYRKBN_INS_TANA_ISSEIINFO = 24;
        /// <summary>ソケット通信　処理区分 棚卸(循環)情報存在確認</summary>
        public const Int32 SCKSYRKBN_GET_TANA_JYUNCHECK = 25;
        /// <summary>ソケット通信　処理区分 棚卸(循環)情報取得</summary>
        public const Int32 SCKSYRKBN_GET_TANA_JYUNINFO = 26;
        /// <summary>ソケット通信　処理区分 棚卸データ登録(循環)</summary>
        public const Int32 SCKSYRKBN_INS_TANA_JYUNINFO = 27;
        // -- ADD 2017/08/01 ------------------------------<<<
        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>ソケット通信　処理区分 倉庫リスト取得</summary>
        public const Int32 SCKSYRKBN_GET_SOKO_LIST = 28;
        // -- ADD 2019/10/16 ------------------------------<<<
        // -- ADD 2020/04/01 ------------------------------>>>
        /// <summary>ソケット通信　処理区分 商品在庫登録検索（パターン検索）</summary>
        public const Int32 SCKSYRKBN_GET_INS_ZAIKOINFO_PATURN = 29;
        /// <summary>ソケット通信　処理区分 商品在庫登録検索（品番検索）</summary>
        public const Int32 SCKSYRKBN_GET_INS_ZAIKOINFO_GOODSNO = 30;
        /// <summary>ソケット通信　処理区分 商品在庫登録確定</summary>
        public const Int32 SCKSYRKBN_INS_ZAIKO_INSERT = 31;
        /// <summary>ソケット通信　処理区分 UOE発注データ存在チェック</summary>
        public const Int32 SCKSYRKBN_CHK_UOE_ORDER = 32;
        /// <summary>ソケット通信　処理区分 メーカー一覧取得</summary>
        public const Int32 SCKSYRKBN_GET_MAKER_LIST = 33;
        /// <summary>ソケット通信　処理区分 メーカー情報取得</summary>
        public const Int32 SCKSYRKBN_GET_MAKER_INFO = 34;
        /// <summary>ソケット通信　処理区分 仕入先一覧取得</summary>
        public const Int32 SCKSYRKBN_GET_SUPPLIER_LIST = 35;
        /// <summary>ソケット通信　処理区分 仕入先情報取得</summary>
        public const Int32 SCKSYRKBN_GET_SUPPLIER_INFO = 36;
        /// <summary>ソケット通信　処理区分 倉庫情報取得</summary>
        public const Int32 SCKSYRKBN_GET_SOKO_INFO_FOR_STOCK = 37;
        // -- ADD 2020/04/01 ------------------------------<<<

        /// <summary>ソケット通信　処理区分 ログイン情報取得</summary>
        public const string STRING_GET_LOGININFO = "ログイン情報取得";
        /// <summary>ソケット通信　処理区分 商品情報取得</summary>
        public const string STRING_GET_SYOHININFO = "商品情報取得";
        /// <summary>ソケット通信　処理区分 伝票情報取得 伝票検品</summary>
        public const string STRING_GET_SLIPINFO_MDDENPYOU = "伝票情報取得(伝票検品)";
        /// <summary>ソケット通信　処理区分 伝票情報取得 一括検品</summary>
        public const string STRING_GET_SLIPINFO_MDIKKATSU = "伝票情報取得(一括検品)";
        /// <summary>ソケット通信　処理区分 在庫情報取得</summary>
        public const string STRING_GET_ZAIKOINFO = "在庫情報取得";
        /// <summary>ソケット通信　処理区分 伝票情報更新</summary>
        public const string STRING_INS_SLIPINFO = "伝票情報更新";
        /// <summary>ソケット通信　処理区分 商品情報更新（バーコード）</summary>
        public const string STRING_INS_SYOHININFO_BARCODE = "商品情報更新（バーコード）";
        /// <summary>ソケット通信　処理区分 商品情報更新（数量）</summary>
        public const string STRING_INS_SYOHININFO_SU = "商品情報更新（数量）";

        // -- ADD 2017/08/01 ------------------------------>>>
        /// <summary>ソケット通信　処理区分 在庫仕入(入庫更新)　伝票一覧取得</summary>
        public const string STRING_GET_NYU_SLIPLIST = "在庫仕入(入庫更新)　伝票一覧取得";
        /// <summary>ソケット通信　処理区分 在庫仕入(入庫更新)　伝票情報取得</summary>
        public const string STRING_GET_NYU_SLIPINFO = "在庫仕入(入庫更新)　伝票情報取得";
        /// <summary>ソケット通信　処理区分 発注先一覧取得</summary>
        public const string STRING_GET_HACLIST = "発注先一覧取得";
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫仕入　入庫更新)</summary>
        public const string STRING_INS_NYU_SLIPINFO = "検品データ登録(在庫仕入　入庫更新)";
        /// <summary>ソケット通信　処理区分 在庫仕入(UOE以外)　伝票情報取得</summary>
        public const string STRING_GET_NOTUOE_SLIPINFO = "在庫仕入(UOE以外)　伝票情報取得";
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫仕入　UOE以外)</summary>
        public const string STRING_INS_NOTUOE_SLIPINFO = "検品データ登録(在庫仕入　UOE以外)";
        /// <summary>ソケット通信　処理区分 在庫仕入(入荷/出荷)　伝票情報取得</summary>
        public const string STRING_GET_NYUSYU_SLIPINFO = "在庫仕入(入荷/出荷)　伝票情報取得";
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫仕入　入荷/出荷)</summary>
        public const string STRING_INS_NYUSYU_SLIPINFO = "検品データ登録(在庫仕入　入荷/出荷)";
        /// <summary>ソケット通信　処理区分 在庫移動(出荷/入荷)　伝票情報取得</summary>
        public const string STRING_GET_IDO_SLIPINFO = "在庫移動(出荷/入荷)　伝票情報取得";
        /// <summary>ソケット通信　処理区分 検品データ登録(在庫移動　出荷/入荷)</summary>
        public const string STRING_INS_IDO_SLIPINFO = "検品データ登録(在庫移動　出荷/入荷)";
        /// <summary>ソケット通信　処理区分 倉庫情報取得</summary>
        public const string STRING_GET_SOKO_INFO = "倉庫情報取得";
        /// <summary>ソケット通信　処理区分 委託在庫補充　伝票情報取得</summary>
        public const string STRING_GET_ITAKU_SLIPINFO = "委託在庫補充　伝票情報取得";
        /// <summary>ソケット通信　処理区分 検品データ登録(委託在庫補充)</summary>
        public const string STRING_INS_ITAKU_SLIPINFO = "検品データ登録(委託在庫補充)";
        /// <summary>ソケット通信　処理区分 棚卸(一斉)情報存在確認</summary>
        public const string STRING_GET_TANA_ISSEICHECK = "棚卸(一斉)情報存在確認";
        /// <summary>ソケット通信　処理区分 棚卸(一斉)情報取得</summary>
        public const string STRING_GET_TANA_ISSEIINFO = "棚卸(一斉)情報取得";
        /// <summary>ソケット通信　処理区分 棚卸データ登録(一斉)</summary>
        public const string STRING_INS_TANA_ISSEIINFO = "棚卸データ登録(一斉)";
        /// <summary>ソケット通信　処理区分 棚卸(循環)情報存在確認</summary>
        public const string STRING_GET_TANA_JYUNCHECK = "棚卸(循環)情報存在確認";
        /// <summary>ソケット通信　処理区分 棚卸(循環)情報取得</summary>
        public const string STRING_GET_TANA_JYUNINFO = "棚卸(循環)情報取得";
        /// <summary>ソケット通信　処理区分 棚卸データ登録(循環)</summary>
        public const string STRING_INS_TANA_JYUNINFO = "棚卸データ登録(循環)";
        // -- ADD 2017/08/01 ------------------------------<<<
        // -- ADD 2019/11/14 ------------------------------>>>
        /// <summary>ソケット通信　処理区分 倉庫リスト取得</summary>
        public const string STRING_GET_SOKO_LIST = "倉庫リスト取得";
        // -- ADD 2019/11/14 ------------------------------<<<
        // -- ADD 2020/04/01 ------------------------------>>>
        /// <summary>ソケット通信　処理区分 商品在庫登録検索(パターン検索)</summary>
        public const string STRING_GET_INS_ZAIKOINFO_PATURN = "商品在庫登録検索(パターン検索)";
        /// <summary>ソケット通信　処理区分 商品在庫登録検索(品番検索)</summary>
        public const string STRING_GET_INS_ZAIKOINFO_GOODSNO = "商品在庫登録検索(品番検索)";
        /// <summary>ソケット通信　処理区分 商品在庫登録確定</summary>
        public const string STRING_INS_ZAIKO_INSERT = "商品在庫登録確定";
        /// <summary>ソケット通信　処理区分 UOE発注データ存在チェック</summary>
        public const string STRING_CHK_UOE_ORDER = "UOE発注データ存在チェック";
        /// <summary>ソケット通信　処理区分 メーカー一覧取得</summary>
        public const string STRING_GET_MAKER_LIST = "メーカー一覧取得";
        /// <summary>ソケット通信　処理区分 メーカー情報取得</summary>
        public const string STRING_GET_MAKER_INFO = "メーカー情報取得";
        /// <summary>ソケット通信　処理区分 仕入先一覧取得</summary>
        public const string STRING_GET_SUPPLIER_LIST = "仕入先一覧取得";
        /// <summary>ソケット通信　処理区分 仕入先情報取得</summary>
        public const string STRING_GET_SUPPLIER_INFO = "仕入先情報取得";
        // -- ADD 2020/04/01 ------------------------------<<<

        // --- ADD 2019/06/13 ---------->>>>>
        /// <summary>ソケット通信　処理区分 ファイル転送</summary>
        public const Int32 SCKSYRKBN_FILE_TRANSFER = 99;
        /// <summary>ソケット通信　処理区分 ファイル転送</summary>
        public const string STRING_FILE_TRANSFER = "ファイル転送";
        // --- ADD 2019/06/13 ----------<<<<<

        /// <summary>
        /// 指定したログレベルより上のものが出力される。
        /// たとえば、ログレベルに Warnを指定した場合、
        /// Warn以上のログのみ（Warn, Error, Fatalの3種類）出力する。
        /// </summary>
        public enum enumLOG4_KBN
        {
            /// <summary>ログレベル1　システムを停止するような致命的なエラー</summary>
            FATAL = 1,
            /// <summary>ログレベル2　システム停止までいかないが、問題となるエラー</summary>
            ERROR = 2,
            /// <summary>ログレベル3　注意や警告</summary>
            WARN = 3,
            /// <summary>ログレベル4　操作ログ情報</summary>
            INFO = 4,
            /// <summary>ログレベル5　開発用デバッグ情報</summary>
            DEBUG = 5
        }

        // -- UPD 2019/10/16 ------------------------------>>>
        public enum enumStatus
        {
            Nomal    = 0
          , NotFound = 4
          , Timeout  = 5
          , Error    = -1
        }
        // -- UPD 2019/10/16 ------------------------------<<<

    }
}
