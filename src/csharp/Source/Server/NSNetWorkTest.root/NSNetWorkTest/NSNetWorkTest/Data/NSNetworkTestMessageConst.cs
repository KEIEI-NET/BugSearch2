using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkTest.Data
{
    /// <summary>
    /// メッセージ定数管理クラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public class NSNetworkTestMsgConst
    {
        #region データグリッドビュー関係
        /// <summary>プロキシサーバーの存在確認</summary>
        public const string TEST_PROXY_SERVER = "プロキシサーバーの確認";
        /// <summary>WEBサーバーへの通信テスト</summary>
        public const string TEST_WEB_SERVER = "WEBサーバーへの通信確認";
        /// <summary>アプリケーションサーバーへの通信テスト</summary>
        public const string TEST_AP_SERVER = "アプリケーションサーバーへの通信確認";
        /// <summary>アプリケーション配信テスト</summary>
        public const string TEST_DELIVERY_SERVER = "アプリケーション配信確認";
        /// <summary>未確認</summary>
        public const string TEST_RESULT_NONE = "未処理";

        /// <summary>列名英語：ITEM(項目)</summary>
        public const string TEST_COLUMN_ITEM = "ITEM";
        /// <summary>列名和名：項目(ITEM)</summary>
        public const string TEST_COLUMN_ITEMNAME = "項目";

        /// <summary>列名英語：RESULT(結果)</summary>
        public const string TEST_COLUMN_RESULT = "RESULT";
        /// <summary>列名和名：結果(RESULT)</summary>
        public const string TEST_COLUMN_RESULTNAME = "結果";
        
        #endregion

        #region メッセージボックス
        /// <summary>メッセージ：確認</summary>
        public const string MSG_TITLE_CONFIRMATION = "確認";
        /// <summary>メッセージ：情報</summary>
        public const string MSG_TITLE_INFORMATION = "情報";
        /// <summary>メッセージ：警告</summary>
        public const string MSG_TITLE_WARNING = "警告";
        /// <summary>メッセージ：エラー</summary>
        public const string MSG_TITLE_ERROR = "エラー";
        /// <summary>メッセージ：バージョン</summary>
        public const string MSG_TITLE_VERSION = "バージョン";

        /// <summary>メッセージ：本当に終了しますか？</summary>
        public const string MSG_ENDCHECK = "本当に終了しますか？";
        /// <summary>メッセージ：テスト結果がありません。テストを実行してください</summary>
        public const string MSG_TESTDATANOTFOUND = "テスト結果がありません。\r\nテストを実行してください。";
        
        /// <summary>メッセージ：ステスト結果の保存を行いますか？</summary>
        public const string MSG_RESULTDATASAVE_CHECK = "テスト結果の保存を行いますか？";
        /// <summary>メッセージ：正常にテスト結果を保存できました</summary>
        public const string MSG_RESULTDATASAVE_OK = "正常にテスト結果を保存できました。";
        /// <summary>メッセージ：テスト結果保存処理にてエラーが発生しました。</summary>
        public const string MSG_RESULTDATASAVE_NG = "テスト結果保存処理にてエラーが発生しました。";


         /// <summary>メッセージ：ヘルプのプロキシ設定を確認してください。</summary>
        //public const string MSG_RESULTPROXYCHECK_NG = "NG：ヘルプのプロキシ設定を確認してください。";
        public const string MSG_RESULTPROXYCHECK_NG = "NG：プロキシ設定を確認してください。";
        /// <summary>メッセージ：ヘルプのネットワーク設定を確認してください。</summary>
        //public const string MSG_RESULTNETWORK_NG = "NG：ヘルプのネットワーク設定を確認してください。";
        public const string MSG_RESULTNETWORK_NG = "NG：ネットワーク設定を確認してください。";
        
        /// <summary>メッセージ：NG：アプリケーションサーバーへの通信確認をしてください。</summary>
        public const string MSG_RESULTAP_NG = "NG：アプリケーションサーバーへの通信確認をしてください。";
        /// <summary>メッセージ：NG：WEBサーバーへの通信確認をしてください。</summary>
        public const string MSG_RESULTWEB_NG = "NG：WEBサーバーへの通信確認をしてください。";
        /// <summary>メッセージ：NG：アプリケーション配信確認をしてください。</summary>
        public const string MSG_RESULTBITS_NG = "NG：アプリケーション配信確認をしてください。";
        /// <summary>メッセージ：NG：プロキシサーバーの確認をしてください。</summary>
        public const string MSG_RESULTPROXY_NG = "NG：プロキシサーバーの確認をしてください。";


        /// <summary>メッセージ：設定ファイル取得中にエラーが発生しました。</summary>
        public const string MSG_CONFIGLOAD_NG = "設定ファイル取得中にエラーが発生しました。";
        /// <summary>メッセージ：設定ファイル更新中にエラーが発生しました。</summary>
        public const string MSG_CONFIGSAVE_NG = "設定ファイル更新中にエラーが発生しました。";

        /// <summary>メッセージ：連続実行は許可されておりません。</summary>
        public const string MSG_CONTINUOSEXECTION_NG = "連続実行は許可されておりません。";

        /// <summary>メッセージ：処理を中止しますか？</summary>
        public const string MSG_IS_PROCESSINGDISCONTINUED = "処理を中止しますか？";
        /// <summary>メッセージ：ネットワーク通信テスト中は行なえません。</summary>
        public const string MSG_EXECUTING_LOADSAVE_NG = "ネットワーク通信テスト中は行なえません。";
        /// <summary>メッセージ：失敗した通信テストがありました。\r\nエラー内容を表示しますか？</summary>
        public const string MSG_RESULTNGSHOW_NG = "失敗した通信テストがありました。\r\nエラー内容を表示しますか？";
        /// <summary>メッセージ：処理が中止されました。アプリケーションを終了します。</summary>
        public const string MSG_EXECUTINGSOPAPPCLOSE_NG = "処理が中止されました。アプリケーションを終了します。";
        /// <summary>メッセージ：全てのテストが正常に終了しました。</summary>
        public const string MSG_RESULTOK_OK = "全てのテストが正常に終了しました。";
        /// <summary>メッセージ：テスト設定ファイルが存在しません</summary>
        public const string MSG_EXISTENCE_NG = "設定ファイルが存在しません";
        /// <summary>メッセージ：テスト製品を選択してください</summary>
        public const string MSG_SELECT_NG = "製品を選択してください";
        /// <summary>メッセージ：app.configファイルを確認してください</summary>
        public const string MSG_CONFIG_NG = "app.configファイルを確認してください";
            
        #endregion

        /// <summary>メッセージ：OK</summary>
        public const string MSG_OK = "OK";
        /// <summary>メッセージ：NG</summary>
        public const string MSG_NG = "NG";
    }
}
