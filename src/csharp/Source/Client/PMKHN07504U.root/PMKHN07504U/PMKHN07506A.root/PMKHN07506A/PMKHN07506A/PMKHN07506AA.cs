using System;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メール送信履歴データアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 980035　金沢　貞義</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public class MailSendHistAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Public Enum

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Costructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MailSendHistAcs()
        {
                   
        }

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method

        /// <summary>
        /// メール送信履歴データを書き込みます。
        /// </summary>
        /// <param name="mailHistList">メール送信履歴データオブジェクト</param>
        /// <returns>STATUS</returns>
        public int Write(List<MailHist> mailHistList)
        {
            return WriteProc(mailHistList);
        }

        /// <summary>
        /// メール送信履歴データを読み込みます。
        /// </summary>
        /// <param name="mailHistList">メール送信履歴データオブジェクトリスト</param>
        /// <returns>STATUS</returns>
        public int Read(out List<MailHist> mailHistList)
        {
            return ReadProc(out mailHistList);
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// メール用初期データを書き込みます。
        /// </summary>
        /// <param name="mailHistList">メール送信履歴データオブジェクト</param>
        /// <returns>STATUS</returns>
        private int WriteProc(List<MailHist> mailHistList)
        {
            string fileName = "QRMAILHIST.XML";
            string fullpath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);
            PMNSMailCommon pmmc = new PMNSMailCommon();
            pmmc.PMNSQRMailHist = mailHistList;

            try
            {
                UserSettingController.SerializeUserSetting(pmmc, fullpath);
            }
            catch
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// メール用初期データを読み込みます。
        /// </summary>
        /// <param name="mailHistList">メール初期明細データオブジェクトリスト</param>
        /// <returns>STATUS</returns>
        private int ReadProc(out List<MailHist> mailHistList)
        {
            mailHistList = new List<MailHist>();

            string fileName = "QRMAILHIST.XML";
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName);

            if (!System.IO.File.Exists(filePath)) return -1;

            try
            {
                object obj = UserSettingController.DeserializeUserSetting(filePath, typeof(PMNSMailCommon));
                if (obj != null && obj is PMNSMailCommon)
                {
                    PMNSMailCommon data = (PMNSMailCommon)obj;
                    mailHistList = data.PMNSQRMailHist;
                }
                else
                {
                    return -2;
                }
            }
            catch
            {
                return -3;
            }

            return 0;
        }

        #endregion
    }

    /// <summary>
    /// メール履歴情報
    /// </summary>
    [Serializable]
    public class PMNSMailCommon
    {
        #region ■ Private Member

        private List<MailHist> _mailHistList;

        #endregion

        #region ■ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMNSMailCommon()
        {

        }
        #endregion

        #region ■ Property

        /// <summary>メール送信履歴リスト</summary>
        public List<MailHist> PMNSQRMailHist
        {
            get { return _mailHistList; }
            set { _mailHistList = value; }
        }
        #endregion
    }
}
