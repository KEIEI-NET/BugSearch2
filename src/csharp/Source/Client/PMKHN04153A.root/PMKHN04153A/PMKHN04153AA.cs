//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール送信履歴表示
// プログラム概要   : メール送信履歴表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2010/05/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using Broadleaf.Application.UIData;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メール送信履歴表示アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メール送信履歴表示を行います。</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public partial class MailHistAcs
    {
        # region ■Private Member
        /// <summary>メール送信履歴データセット</summary>
        /// <remarks></remarks> 
        private MailHisResultDataSet _dataSet;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private string _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private MailInfoSettingAcs _mailInfoSettingAcs;

        private static MailHistAcs _mailHistAcs;

        #endregion

        # region Const Members
        private const string XML_FILE_NAME = "QRMAILHIST.XML";

        private const string QRCODE_DISPLAY = "●";
        #endregion

        # region ■Constracter
        /// <summary>
        /// メール送信履歴表示アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール送信履歴表示アクセスクラスコンストラクタを初期化します。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/25</br>    
        /// </remarks>
        private MailHistAcs()
        {
            this._dataSet = new MailHisResultDataSet();
            this._mailInfoSettingAcs = new MailInfoSettingAcs();

        }

        /// <summary>
        /// 売上伝票入力アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>売上伝票入力アクセスクラス インスタンス</returns>
        public static MailHistAcs GetInstance()
        {
            if (_mailHistAcs == null)
            {
                _mailHistAcs = new MailHistAcs();
            }

            return _mailHistAcs;
        }
        # endregion

        #region ■Public Method
        /// <summary>
        /// 履歴情報の抽出処理
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="message"></param>
        /// <returns>抽出状態</returns>
        /// <remarks>
        /// <br>Note       : 履歴情報の抽出処理を行う。 </br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/25</br>  
        /// </remarks>
        public int SearchQRMailHist(QrMailHistSearchCond cond, out string message)
        {
            List<QrMailHist> qrMailHistListAll = new List<QrMailHist>();
            List<QrMailHist> qrMailHistList = new List<QrMailHist>();
            message = string.Empty;

            try
            {
                // XMLファイルから履歴情報を取得する
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
                {
                    XmlElement root = null;
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                    root = xmldoc.DocumentElement;

                    if (root.HasChildNodes)
                    {
                        XmlNodeList PMNSQRMailHistNodes = root.ChildNodes;

                        for (int i = 0; i < PMNSQRMailHistNodes.Count; i++)
                        {
                            if (PMNSQRMailHistNodes[i].HasChildNodes)
                            {
                                XmlNodeList MailHistNodes = PMNSQRMailHistNodes[i].ChildNodes;

                                for (int j = 0; j < MailHistNodes.Count; j++)
                                {
                                    if (MailHistNodes[j].HasChildNodes)
                                    {
                                        XmlNodeList nodes = MailHistNodes[j].ChildNodes;
                                        QrMailHist qrMailHist = new QrMailHist();

                                        for (int k = 0; k < nodes.Count; k++)
                                        {

                                            if (nodes[k].Name.ToLower() == "filename")
                                            {
                                                qrMailHist.FileName = nodes[k].InnerXml;
                                            }
                                            if (nodes[k].Name.ToLower() == "qrcode")
                                            {
                                                qrMailHist.QRCode = nodes[k].InnerXml;
                                            }
                                            if (nodes[k].Name.ToLower() == "transmitdate")
                                            {
                                                qrMailHist.TransmitDate = nodes[k].InnerXml;
                                            }
                                            if (nodes[k].Name.ToLower() == "transmittime")
                                            {
                                                qrMailHist.TransmitTime = nodes[k].InnerXml;
                                            }
                                            if (nodes[k].Name.ToLower() == "employeename")
                                            {
                                                qrMailHist.EmployeeName = nodes[k].InnerXml;
                                            }
                                            if (nodes[k].Name.ToLower() == "ccinfo")
                                            {
                                                qrMailHist.CCInfo = nodes[k].InnerXml;
                                            }
                                            if (nodes[k].Name.ToLower() == "title")
                                            {
                                                qrMailHist.Title = nodes[k].InnerXml;
                                            }
                                        }
                                        qrMailHistListAll.Add(qrMailHist);
                                    }
                                }
                            }

                        }
                    }

                }
                else
                {
                    message = "XMLファイルが存在しません。";
                }
            }
            catch (System.InvalidOperationException)
            {
                message = "XMLファイルの読み込みは失敗しました。";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // 条件を満足する情報を抽出する
            foreach(QrMailHist qrMailHist in qrMailHistListAll)
            {
                if (cond.TransmitDateSt.ToString("yyyyMMdd").CompareTo(qrMailHist.TransmitDate) <= 0 && cond.TransmitDateEd.ToString("yyyyMMdd").CompareTo(qrMailHist.TransmitDate) >= 0)
                {
                    qrMailHistList.Add(qrMailHist);
                }
            }

            if (qrMailHistList.Count > 0)
            {
                qrMailHistList.Sort(new QrMailHist.QrMailHistComparer());
                CopyToTable(qrMailHistList);
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// メール送信履歴データセット取得処理
        /// </summary>
        /// <returns>メール送信履歴データセット</returns>
        /// <remarks>
        /// <br>Note       : メール送信履歴データセット取得処理を行う。 </br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public MailHisResultDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// メール送信履歴データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール送信履歴データセットクリア処理を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       :  2010/05/25</br>
        /// </remarks>
        public void ClearMailHisResultDataTable()
        {
            this._dataSet.MailHistResult.Rows.Clear();
        }

        /// <summary>
        /// メール内容を取得する
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="errMess">エラーメッセージ</param>
        /// <param name="textContent">メール内容</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       :メール内容を取得する。 </br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/25</br>  
        /// </remarks>
        public int GetMailHistDetail(string fileName, out string errMess, out string textContent)
        {
            errMess = string.Empty;
            textContent = string.Empty;
            string filePath = string.Empty;
            MailInfoSetting mailInfoSetting = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                status = this._mailInfoSettingAcs.Read(out mailInfoSetting, this._enterpriseCode, this._sectionCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (mailInfoSetting.LogicalDeleteCode == 0)
                    {
                        filePath = mailInfoSetting.FilePathNm + Path.DirectorySeparatorChar + fileName;

                        if (System.IO.File.Exists(filePath))
                        {
                            ReadTextFile(filePath, out textContent);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region ■Private Method

        /// <summary>
        /// データテーブル格納処理
        /// </summary>
        /// <param name="qrMailHistList">メール送信履歴リスト</param>
        /// <remarks>
        /// <br>Note       : データテーブル格納処理を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void CopyToTable(List<QrMailHist> qrMailHistList)
        {
            this._dataSet.MailHistResult.Rows.Clear();

            foreach (QrMailHist qrMailHist in qrMailHistList)
            {
                // 新規行取得
                MailHisResultDataSet.MailHistResultRow row = this._dataSet.MailHistResult.NewMailHistResultRow();

                # region [copy]

                //メールファイル名
                row.FileName = qrMailHist.FileName;
                //QRコードファイル名
                row.QRCode = qrMailHist.QRCode;
                //QRコード(表示用)
                if (string.IsNullOrEmpty(qrMailHist.QRCode))
                {
                    row.QRCodeDisplay = string.Empty;
                }
                else
                {
                    row.QRCodeDisplay = QRCODE_DISPLAY;
                }
                //送信日付
                row.TransmitDate = TDateTime.LongDateToDateTime(Int32.Parse(qrMailHist.TransmitDate)).ToString("yyyy/MM/dd");
                //送信日時
                row.TransmitDateTime = row.TransmitDate + " " + qrMailHist.TransmitTime.Substring(0, 2) + ":" + qrMailHist.TransmitTime.Substring(2, 2);
                //受信者名称
                row.EmployeeName = qrMailHist.EmployeeName;
                //CC情報
                row.CCInfo = qrMailHist.CCInfo;
                //件名
                row.Title = qrMailHist.Title;

                # endregion

                // 追加
                this._dataSet.MailHistResult.AddMailHistResultRow(row);
            }
        }

        /// <summary>
        /// メールファイルを読み込み
        /// </summary>
        /// <param name="file">ファイルパース</param>
        /// <param name="content">読み出すメール内容</param>
        /// <remarks>
        /// <br>Note       : メールファイルを読み込みを行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void ReadTextFile(string file, out string content)
        {
            content = string.Empty;
            StreamReader sr = null;
            StringBuilder mailContent = new StringBuilder();
            string line = string.Empty;
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INIファイル読み込み
                while (null != line)
                {
                    mailContent.Append(line);
                    mailContent.Append(Environment.NewLine);
                    line = sr.ReadLine();
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }

            content = mailContent.ToString();

        }
        #endregion

    }
}
