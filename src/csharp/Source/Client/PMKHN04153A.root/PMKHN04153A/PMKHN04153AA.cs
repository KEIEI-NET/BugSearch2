//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����M����\��
// �v���O�����T�v   : ���[�����M����\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2010/05/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// ���[�����M����\���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����M����\�����s���܂��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public partial class MailHistAcs
    {
        # region ��Private Member
        /// <summary>���[�����M�����f�[�^�Z�b�g</summary>
        /// <remarks></remarks> 
        private MailHisResultDataSet _dataSet;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private string _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private MailInfoSettingAcs _mailInfoSettingAcs;

        private static MailHistAcs _mailHistAcs;

        #endregion

        # region Const Members
        private const string XML_FILE_NAME = "QRMAILHIST.XML";

        private const string QRCODE_DISPLAY = "��";
        #endregion

        # region ��Constracter
        /// <summary>
        /// ���[�����M����\���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����M����\���A�N�Z�X�N���X�R���X�g���N�^�����������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/25</br>    
        /// </remarks>
        private MailHistAcs()
        {
            this._dataSet = new MailHisResultDataSet();
            this._mailInfoSettingAcs = new MailInfoSettingAcs();

        }

        /// <summary>
        /// ����`�[���̓A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>����`�[���̓A�N�Z�X�N���X �C���X�^���X</returns>
        public static MailHistAcs GetInstance()
        {
            if (_mailHistAcs == null)
            {
                _mailHistAcs = new MailHistAcs();
            }

            return _mailHistAcs;
        }
        # endregion

        #region ��Public Method
        /// <summary>
        /// �������̒��o����
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="message"></param>
        /// <returns>���o���</returns>
        /// <remarks>
        /// <br>Note       : �������̒��o�������s���B </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/25</br>  
        /// </remarks>
        public int SearchQRMailHist(QrMailHistSearchCond cond, out string message)
        {
            List<QrMailHist> qrMailHistListAll = new List<QrMailHist>();
            List<QrMailHist> qrMailHistList = new List<QrMailHist>();
            message = string.Empty;

            try
            {
                // XML�t�@�C�����痚�������擾����
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
                    message = "XML�t�@�C�������݂��܂���B";
                }
            }
            catch (System.InvalidOperationException)
            {
                message = "XML�t�@�C���̓ǂݍ��݂͎��s���܂����B";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // �����𖞑�������𒊏o����
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
        /// ���[�����M�����f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>���[�����M�����f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : ���[�����M�����f�[�^�Z�b�g�擾�������s���B </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public MailHisResultDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// ���[�����M�����f�[�^�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����M�����f�[�^�Z�b�g�N���A�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       :  2010/05/25</br>
        /// </remarks>
        public void ClearMailHisResultDataTable()
        {
            this._dataSet.MailHistResult.Rows.Clear();
        }

        /// <summary>
        /// ���[�����e���擾����
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="errMess">�G���[���b�Z�[�W</param>
        /// <param name="textContent">���[�����e</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       :���[�����e���擾����B </br>
        /// <br>Programmer : ����</br>
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

        #region ��Private Method

        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="qrMailHistList">���[�����M�������X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���i�[�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void CopyToTable(List<QrMailHist> qrMailHistList)
        {
            this._dataSet.MailHistResult.Rows.Clear();

            foreach (QrMailHist qrMailHist in qrMailHistList)
            {
                // �V�K�s�擾
                MailHisResultDataSet.MailHistResultRow row = this._dataSet.MailHistResult.NewMailHistResultRow();

                # region [copy]

                //���[���t�@�C����
                row.FileName = qrMailHist.FileName;
                //QR�R�[�h�t�@�C����
                row.QRCode = qrMailHist.QRCode;
                //QR�R�[�h(�\���p)
                if (string.IsNullOrEmpty(qrMailHist.QRCode))
                {
                    row.QRCodeDisplay = string.Empty;
                }
                else
                {
                    row.QRCodeDisplay = QRCODE_DISPLAY;
                }
                //���M���t
                row.TransmitDate = TDateTime.LongDateToDateTime(Int32.Parse(qrMailHist.TransmitDate)).ToString("yyyy/MM/dd");
                //���M����
                row.TransmitDateTime = row.TransmitDate + " " + qrMailHist.TransmitTime.Substring(0, 2) + ":" + qrMailHist.TransmitTime.Substring(2, 2);
                //��M�Җ���
                row.EmployeeName = qrMailHist.EmployeeName;
                //CC���
                row.CCInfo = qrMailHist.CCInfo;
                //����
                row.Title = qrMailHist.Title;

                # endregion

                // �ǉ�
                this._dataSet.MailHistResult.AddMailHistResultRow(row);
            }
        }

        /// <summary>
        /// ���[���t�@�C����ǂݍ���
        /// </summary>
        /// <param name="file">�t�@�C���p�[�X</param>
        /// <param name="content">�ǂݏo�����[�����e</param>
        /// <remarks>
        /// <br>Note       : ���[���t�@�C����ǂݍ��݂��s���B</br>
        /// <br>Programmer : ����</br>
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
                //INI�t�@�C���ǂݍ���
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
