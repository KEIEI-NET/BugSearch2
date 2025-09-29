//using System;
//using System.Collections.Generic;
//using System.Text;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{

    /// <summary>
    /// メール送信ライブラリ操作インタフェース
    /// </summary>
    /// <remarks>
    /// メールの送信を行う各種ライブラリに関する操作を定義します
    /// </remarks>
    public interface IMailSender
    {

        /// <summary>
        /// メール送信
        /// </summary>
        /// <param name="mailSenderOperationInfo">メール送信ライブラリ操作パラメータ</param>
        /// <param name="mailSourceData">送信対象メールデータソース</param>
        /// <returns>処理ステータス</returns>
        int SendMail(ref MailSenderOperationInfo mailSenderOperationInfo, MailSourceData mailSourceData);


        /// <summary>
        /// メール送信ライブラリバージョン
        /// </summary>
        string Version{get;}

        /// <summary>
        /// 処理終了フラグ
        /// </summary>
        bool SendEndFlg{get;}
    
    }



}
