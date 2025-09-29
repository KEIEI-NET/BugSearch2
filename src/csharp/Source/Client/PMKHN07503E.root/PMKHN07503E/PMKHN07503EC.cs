using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    //******************************************************************************************
    //
    //  このソースファイルには「メール送信ライブラリ」に関連するクラス, 各種パラメータや、
    //  各種定義が実装されています
    //
    //******************************************************************************************


    /// <summary>
    /// メール送信ライブラリ操作パラメータ
    /// </summary>
    /// <remarks>
    /// OperationMode が 0:Automatic の場合は MailInfoBaseの設定値を使用する
    /// OperationMode が 0:Automatic以外(Specify等) の場合に このパラメータの設定値を使用する(足りない項目はMailInfoBaseの設定値または規定値を使用)
    /// </remarks>
    public class MailSenderOperationInfo
    {
        // OperationMode が Automatic の場合は MailInfoBaseの設定値を使用する
        // OperationMode が Automatic以外(Specify等) の場合に このパラメータの設定値を使用する(足りない項目はMailInfoBaseの設定値または規定値を使用)


        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MailSenderOperationInfo()
        {
            OperationMode = 0;

        }

        /// <summary>
        /// コンストラクタ(操作モード指定)
        /// </summary>
        /// <param name="operationMode">操作モード 0:Automatic(デフォルト設定で動作します), 1:Specify(指定されたプロパティ値を使用します)  </param>
        public MailSenderOperationInfo(int operationMode)
        {
            OperationMode = operationMode;
        }
        #endregion


        #region プロパティ
        /// <summary>
        /// 操作モード 0:Automatic(デフォルト設定で動作します), 1:Specify(指定されたプロパティ値を使用します)
        /// </summary>
        public int OperationMode = 0;


        // 以下に外部から直接操作しても良い設定を宣言してください(当面は不要)
        // (メール送信管理設定マスタの全ての項目は不要だと思います)

        /// <summary>
        /// BCCバックアップ送信 true:送信する
        /// </summary>
        public bool SendBccBackup = true;

        /// <summary>
        /// 進捗ダイアログ表示区分 true:表示する
        /// </summary>
        public bool DispProgressDialog = true;

        /// <summary>
        /// エラーダイアログ表示区分 true:表示する
        /// </summary>
        public bool DispErrorDialog = false;

        /// <summary>
        /// 送信ステータス
        /// </summary>
        public int SendStatus = 0;

        /// <summary>
        /// エラーメッセージ (送信ステータスに対するメッセージ)  
        /// </summary>
        public string StatusMessage = "";


        #endregion

    }
}
