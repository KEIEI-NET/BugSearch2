//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : wangf
// �� �� ��  K2013/06/27 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : wujun
// �C �� ��  K2013/07/11 �C�����e : �[�����ݒ莞�A���b�Z�[�W�o�����ɏ풓���N�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : wujun
// �C �� ��  K2013/07/29 �C�����e : ���񑗐M���s���Ԍv�Z�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : �c����
// �C �� ��  K2013/08/07  �C�����e : Redmine#39695 ���o���ʖ����̌��ʉ�ʕ\���̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : �c����
// �C �� ��  K2013/08/12  �C�����e : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Microsoft.Win32;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M�������N��
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M�������N��UI�t�H�[���N���X</br>
    /// <br>Programmer : wangf</br>
    /// <br>Date       : K2013/06/27</br>
    /// <br>UpdateNote : K2013/08/12 �c����</br>
    /// <br>           : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
    /// </remarks>
    public partial class PMSAE04020UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Member
        // ����f�[�^�e�L�X�g�o�� �A�N�Z�X�N���X
        private SalesHistoryAcs _salesHistoryAcs;
        // �ڑ�����ݒ� �A�N�Z�X�N���X
        private ConnectInfoWorkAcs _connectInfoWorkAcs;
        // XML�t�@�C���@�A�N�Z�X�N���X
        private FormattedTextWriter _formattedTextWriter;
        // ��ƃR�[�h
        private string _enterpriseCode;
        // �o�b�`�N������
        //private DateTime _batchStartDate; // DEL BY wujun K2013/07/29
        // �t�@�C������
        private string _fileName;
        // XML�����t�@�C������
        private const string _XMLMEMOFILEPATH = "PMSAE02010U.mem";
        // �d����R�[�h
        private const int _SUPPLIERCD = 0;

        /// <summary>���O���b�Z�[�W�F���M�����G���[</summary>
        private const string LOGMSG_ERROR = "���M�����G���[";

        /// <summary>���O���b�Z�[�W�F�t�H���_�[�s����</summary>
        private const string LOGMSG_FOLDERERROR = "�w�肳�ꂽ�t�H���_�����݂��܂���";

        // ���(millisecond)
        private const int _INTERVAL = 86400000;

        // ADD BY wujun K2013/07/29--------->>>>>>>>>>
        // �ꕪ
        private const int _INTERVALMin = 60000;

        // �������M�����t���O
        private bool autoRunFlg = false;
        // ADD BY wujun K2013/07/29---------<<<<<<<<<

        // �ڑ�����ݒ�
        private ConnectInfoWork _connectInfoWork = null;
        // �[���ݒ�
        private PosTerminalMg _posTerminalMg = null;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ���M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        public PMSAE04020UA()
        {
            // ����������
            InitializeComponent();
            // ���O�C����ƃR�[�h
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �o�b�`�N������
            //_batchStartDate = DateTime.Now; // DEL BY wujun K2013/07/29

            // ����f�[�^�e�L�X�g�o�� �A�N�Z�X�N���X������
            _salesHistoryAcs = new SalesHistoryAcs();
            // �ڑ���A�N�Z�X�N���X
            _connectInfoWorkAcs = new ConnectInfoWorkAcs();
            _formattedTextWriter = new FormattedTextWriter();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// �ڑ�����ݒ�擾
        /// </summary>
        /// <returns>�ڑ�����</returns>
        /// <remarks>
        /// <br>Note		: �ڑ�����ݒ�擾���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private ConnectInfoWork Read()
        {
            ConnectInfoWork connectInfoWork = null;
            //_connectInfoWorkAcs.Read(out connectInfoWork, this._enterpriseCode, _SUPPLIERCD); // DEL BY wujun K2013/07/29
            // ADD BY wujun K2013/07/29--------->>>>>>>>>>
            int status = _connectInfoWorkAcs.Read(out connectInfoWork, this._enterpriseCode, _SUPPLIERCD);
            if (connectInfoWork != null && connectInfoWork.LogicalDeleteCode == 0 &&
                status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
            return connectInfoWork;
        }
            else 
            {
                return null;
            }
            // ADD BY wujun K2013/07/29---------<<<<<<<<<<
            //return connectInfoWork; // DEL BY wujun K2013/07/29
        }

        /// <summary>
        /// �ڑ�����ݒ�
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: �ڑ�����ݒ���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private int Write(ref ConnectInfoWork connectInfoWork)
        {
            int status = 0;
            status = _connectInfoWorkAcs.Write(ref connectInfoWork);
            return status;
        }

        /// <summary>
        /// �ڑ���}�X�^���猟���p�����[�^�[�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ڑ���}�X�^���猟���p�����[�^�[�쐬���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private SalesHistoryCndtn MakeSalesHistoryCndtn(ConnectInfoWork connectInfoWork)
        {
            SalesHistoryCndtn retSalesHistoryCndtn = new SalesHistoryCndtn();
            //��ƃR�[�h
            retSalesHistoryCndtn.EnterpriseCode = this._enterpriseCode;

            // ADD BY wujun K2013/07/29--------->>>>>>>>>>
            // �o�b�`�N�����t
            DateTime _batchStartDate = DateTime.Now;
            // ADD BY wujun K2013/07/29---------<<<<<<<<<

            if (0 == connectInfoWork.CnectSendDiv)
            {
                retSalesHistoryCndtn.PdfOutDiv = 2;
            }
            else if (1 == connectInfoWork.CnectSendDiv)
            {
                retSalesHistoryCndtn.PdfOutDiv = 0;
            }
            // ���M�Ώۂ��u�����܂Łv�̏ꍇ
            if (0 == connectInfoWork.CnectObjectDiv)
            {
                // �����J�n���t
                retSalesHistoryCndtn.AddUpADateSt = DateTimeToInt(_batchStartDate.AddDays(-45));
                // �����I�����t
                retSalesHistoryCndtn.AddUpADateEd = DateTimeToInt(_batchStartDate);
            }
            else
            {
                // �����J�n���t
                retSalesHistoryCndtn.AddUpADateSt = DateTimeToInt(_batchStartDate.AddDays(-46));
                // �����I�����t
                retSalesHistoryCndtn.AddUpADateEd = DateTimeToInt(_batchStartDate.AddDays(-1));
            }
            retSalesHistoryCndtn.SendDataDiv = 1; // ���M�敪(0:�蓮;1:����)

            return retSalesHistoryCndtn;
        }

        /// <summary>
        /// ���ԃt�H�}�b�g�ύX
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: ���ԃt�H�}�b�g�ύX���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private int DateTimeToInt(DateTime dt)
        {
            return dt.Year * 10000 + dt.Month * 100 + dt.Day;
        }

        /// <summary>
        /// ���M�f�[�^�t�@�C���쐬
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: �����M�f�[�^�t�@�C���쐬���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private void MakeOutFileNameFromXmlFile(ConnectInfoWork connectInfoWork)
        {
            string workDir;
            // ڼ޽�ط��擾
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            if (null == key)
            {
                workDir = @"C:\SFNETASM";
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\SFNETASM").ToString();
            }
            _fileName = string.Empty;

            _fileName = GetFolderPath(workDir, connectInfoWork);
        }

        /// <summary>
        /// �t�@�C���p�X�쐬
        /// </summary>
        /// <param name="workDir">�t�H���_</param>
        /// <param name="connectInfoWork">���o�����N���X</param>
        /// <returns>�p�X</returns>
        /// <remarks>
        /// <br>Note		: �t�@�C���p�X���s���B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private string GetFolderPath(string workDir, ConnectInfoWork connectInfoWork)
        {
            string path = string.Empty;
            string filePath = string.Empty;
            XmlDocument xmldoc = new XmlDocument();

            path = workDir + "\\" + Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, _XMLMEMOFILEPATH);
            if (File.Exists(path))
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(path);
                XmlNodeList xmlElems = xmldoc.DocumentElement.SelectSingleNode("//UiMemInputDataForm/UiMemInputDatas").ChildNodes;
                for (int i = 0; i < xmlElems.Count; i++)
                {
                    XmlElement xmlem = (XmlElement)xmlElems[i];
                    if (!"tEdit_FileName".Equals(xmlem["TargetName"].InnerText))
                    {
                        continue;
                    }
                    else
                    {
                        filePath = xmlem["InputData"].InnerText;
                        break;
                    }
                }
                if (!string.Empty.Equals(filePath))
                {
                    try
                    {
                        if (Directory.Exists(Path.GetDirectoryName(filePath)))
                        {
                            if (Path.GetDirectoryName(filePath).EndsWith("\\"))
                            {
                                filePath = Path.GetDirectoryName(filePath)
                                       + connectInfoWork.CnectFileId.Trim()
                                       + DateTime.Now.ToString("yyyyMMddHHmm") + ".TXT";
                            }
                            else
                            {
                                filePath = Path.GetDirectoryName(filePath)
                                       + "\\" + connectInfoWork.CnectFileId.Trim()
                                       + DateTime.Now.ToString("yyyyMMddHHmm") + ".TXT";
                            }
                            return filePath;
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                }
            }
            
            filePath = workDir + "\\" 
                       + Path.Combine(ConstantManagement_ClientDirectory.PRTOUT
                       , connectInfoWork.CnectFileId.Trim() + DateTime.Now.ToString("yyyyMMddHHmm") + ".TXT");

            return filePath;
        }

        /// <summary>
        /// FormattedTextWriter�N���X�ݒ菈��FormattedTextWriter�N���X����)
        /// </summary>
        /// <remarks>
        /// <br>Note		: FormattedTextWriter�N���X�����֐ݒ肷��B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private void SetFormattedTextWriter()
        {
            List<string> schemeList = new List<string>();
            schemeList.Add(PMSAE02014EA.ct_Col_SalesSlipNum);
            schemeList.Add(PMSAE02014EA.ct_Col_RequestDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd);
            schemeList.Add(PMSAE02014EA.ct_Col_AddUpADate);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodDiv);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompCd);
            schemeList.Add(PMSAE02014EA.ct_Col_TradCompRate);
            schemeList.Add(PMSAE02014EA.ct_Col_AbSalesRate);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesRowNo);
            schemeList.Add(PMSAE02014EA.ct_Col_AdministrationNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsNameKana);
            schemeList.Add(PMSAE02014EA.ct_Col_AbGoodsNo);
            schemeList.Add(PMSAE02014EA.ct_Col_ShipmentCnt);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_SalesMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_ShopMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_PriceMoney);
            schemeList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode);
            schemeList.Add(PMSAE02014EA.ct_Col_AreaCd);
            schemeList.Add(PMSAE02014EA.ct_Col_SearchSlipDate);
            schemeList.Add(PMSAE02014EA.ct_Col_SupplierCd);
            schemeList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd);
            schemeList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd);
            schemeList.Add(PMSAE02014EA.ct_Col_OrderNum);
            schemeList.Add(PMSAE02014EA.ct_Col_Filler);

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesSlipNum, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_RequestDiv, 3);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddresseeShopCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AddUpADate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodDiv, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompCd, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TradCompRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbSalesRate, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesRowNo, 2);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AdministrationNo, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNo, 16);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsNameKana, 20);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AbGoodsNo, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShipmentCnt, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoneyTaxExc, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ShopMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_PriceMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SalesMoney, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_TxtCustomerCode, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_AreaCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SearchSlipDate, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_SupplierCd, 8);
            maxLengthList.Add(PMSAE02014EA.ct_Col_ExpenseDivCd, 1);
            maxLengthList.Add(PMSAE02014EA.ct_Col_GoodsMakerCd, 4);
            maxLengthList.Add(PMSAE02014EA.ct_Col_OrderNum, 6);
            maxLengthList.Add(PMSAE02014EA.ct_Col_Filler, 1);

            _formattedTextWriter.DataSource = this._salesHistoryAcs.SalesHistoryDt;
            _formattedTextWriter.DataMember = String.Empty;
            _formattedTextWriter.OutputFileName = _fileName;
            //�e�L�X�g�o�͂��鍀�ږ��̃��X�g
            _formattedTextWriter.SchemeList = schemeList;
            _formattedTextWriter.Splitter = String.Empty;
            _formattedTextWriter.Encloser = String.Empty;
            _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            _formattedTextWriter.FormatList = null;
            _formattedTextWriter.CaptionOutput = false;
            _formattedTextWriter.FixedLength = true;
            _formattedTextWriter.ReplaceList = null;
            _formattedTextWriter.MaxLengthList = maxLengthList;
        }

        /// <summary>
        /// �������MXML����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note		: �������MXML�𐶐�����B</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: K2013/06/27</br>
        /// </remarks>
        private int SaveNetSendSetting()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            try
            {
                int rowsCount = this._salesHistoryAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // �f�[�^�敪������
                XmlElement dtkbn = null;
                // TMY-ID��������
                XmlElement pmwscd = null;
                // ���Ӑ溰�ޏ�����
                XmlElement kjcd = null;
                // ������t������
                XmlElement dndt = null;
                // ����`�[�ԍ�������
                XmlElement dnno = null;
                // ����s�ԍ�������
                XmlElement dngyno = null;
                // ���i�ԍ�������
                XmlElement pmncd = null;
                // ���i���[�J�[�R�[�h������
                XmlElement mkcd = null;
                // BL���i�R�[�h������
                XmlElement blcd = null;
                // �o�א�������
                XmlElement sksu = null;
                // �d����R�[�h������
                XmlElement psicd = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // �f�[�^�敪
                    dtkbn = xmldoc.CreateElement("DTKBN");
                    dtkbn.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["DataDiv"].ToString();
                    data.AppendChild(dtkbn);

                    // �p�[�c�}���[���R�[�h
                    pmwscd = xmldoc.CreateElement("PMWSCD");
                    if (!String.IsNullOrEmpty(this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString()))
                    {
                        pmwscd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["PartsManWSCD"].ToString();
                    }
                    data.AppendChild(pmwscd);

                    // ���Ӑ溰��
                    kjcd = xmldoc.CreateElement("KJCD");
                    kjcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["TxtCustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // ������t
                    dndt = xmldoc.CreateElement("DNDT");
                    dndt.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // ����`�[�ԍ�
                    dnno = xmldoc.CreateElement("DNNO");
                    dnno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // ����s�ԍ�
                    dngyno = xmldoc.CreateElement("DNGYNO");
                    dngyno.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // ���i�ԍ�
                    pmncd = xmldoc.CreateElement("PHNCD");
                    pmncd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsNo"].ToString();
                    data.AppendChild(pmncd);

                    // ���i���[�J�[�R�[�h
                    mkcd = xmldoc.CreateElement("MKCD");
                    mkcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["GoodsMakerCd"].ToString();
                    data.AppendChild(mkcd);

                    // BL���i�R�[�h
                    blcd = xmldoc.CreateElement("BLCD");
                    if (this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"] == DBNull.Value || this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString() == "")
                    {
                        blcd.InnerText = "0000";
                    }
                    else
                    {
                        blcd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["AdministrationNo"].ToString();
                    }
                    data.AppendChild(blcd);

                    // �o�א�
                    sksu = xmldoc.CreateElement("SKSU");
                    sksu.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // �d����R�[�h
                    psicd = xmldoc.CreateElement("PSICD");
                    psicd.InnerText = this._salesHistoryAcs.SalesHistoryDt.Rows[i]["SupplierCd"].ToString();
                    data.AppendChild(psicd);

                    root.AppendChild(data);
                }

                //XML��������
                int index = _fileName.LastIndexOf(".");
                xmlFileName = _fileName.Substring(0, index) + ".XML";
                xmldoc.Save(xmlFileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// �t�@�C���̍폜����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�����폜���܂��B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date	   : K2013/06/27</br>
        /// </remarks>
        private int DeleteFile()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            ArrayList fileList = new ArrayList();

            try
            {
                // �t�@�C�����폜
                FileInfo info = new FileInfo(_fileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date	   : K2013/06/27</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMSAE04020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "",              					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// �C�x���gLoad
        /// </summary>
        /// <param name="sender">�C�x���g�Z���_�[</param>
        /// <param name="e">�C���x���g�p�����[�^�[</param>
        /// <remarks>
        /// <br>Note       : �v��Timer</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// <br>Update Note: wujun</br>
        /// <br>           : �[�����ݒ莞�A���b�Z�[�W�o�����ɏ풓���N�����Ȃ�</br>
        /// <br>Date       : K2013/07/11</br>
        /// </remarks>
        private void PMSAE04020UA_Load(object sender, EventArgs e)
        {
            // �ڑ���}�X�^�ݒ���̎擾
            this._connectInfoWork = this.Read();

            if (null == _connectInfoWork)
            {
                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�ڑ���}�X�^�ݒ���̎擾���s", 0);  //DEL BY wujun  K2013/07/11
                this.Close();  //ADD BY wujun  K2013/07/11
                return;
            }

            // �[���ݒ�̎擾
            this.GetPosTerminalMg(out this._posTerminalMg, this._enterpriseCode);

            if (null == _posTerminalMg)
            {
                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�[���ݒ���̎擾���s", 0);  //DEL BY wujun  K2013/07/11
                this.Close(); //ADD BY wujun  K2013/07/11
                return;
            }

            this.Visible = false;
            this.notifyIcon1.Visible = true;

            // 0�F�������M���� && ���[��
            if (this._connectInfoWork.AutoSendDiv == 0 && this._posTerminalMg.MachineName.ToUpper().Trim() == this._connectInfoWork.SendMachineName.ToUpper().Trim())
            {
                string bootTime = this._connectInfoWork.BootTime.ToString().PadLeft(4,'0');
                // ADD BY wujun K2013/07/29--------->>>>>>>>>>
                int interval = getNextRunTime(bootTime);
                this.autoRunFlg = true;
                // ADD BY wujun K2013/07/29---------<<<<<<<<<<
                // DEL BY wujun K2013/07/29--------->>>>>>>>>>
                //int hours = 0;
                //int minitus = 0;
                //if (bootTime != "0")
                //{
                //    hours = Convert.ToInt16(bootTime.Substring(0, 2));
                //    minitus = Convert.ToInt16(bootTime.Substring(2, 2));
                //}
                //TimeSpan startTime = new TimeSpan(hours, minitus, 0);

                //int interval;
                //// �ڑ���}�X�^�ݒ�̋N������ >= Now
                //if (startTime.CompareTo(DateTime.Now.TimeOfDay) >= 0)
                //{
                //    interval = (int)(startTime.TotalMilliseconds - DateTime.Now.TimeOfDay.TotalMilliseconds);
                //}
                //else
                //{
                //    interval = (int)(_INTERVAL - ((DateTime.Now.TimeOfDay.TotalMilliseconds - startTime.TotalMilliseconds)) % _INTERVAL);
                //}
                // DEL BY wujun K2013/07/29---------<<<<<<<<<<

                // �N���p�x��ݒ�
                timer1.Interval = interval;
                timer1.Enabled = true;
            }
            else
            {
                this.Close();
            }

        }

        // ADD BY wujun K2013/07/29--------->>>>>>>>>>
        /// <summary>
        /// Timer�̎���N�����ԎZ�o
        /// </summary>
        /// <param name="bootTime">�N������</param>
        /// <remarks>
        /// <br>Note       : ������s���Ԍv�Z</br>
        /// <br>Programmer : wujun</br>
        /// <br>Date       : K2013/07/29</br>
        /// </remarks>
        private int getNextRunTime(String bootTime)
        {
            // �V�X�e�����Ԏ擾
            double systemTime = DateTime.Now.TimeOfDay.TotalMilliseconds;

                int hours = 0;
                int minitus = 0;
                if (bootTime != "0")
                {
                    hours = Convert.ToInt16(bootTime.Substring(0, 2));
                    minitus = Convert.ToInt16(bootTime.Substring(2, 2));
                }
            double startTime = new TimeSpan(hours, minitus, 0).TotalMilliseconds;

                int interval;
                // �ڑ���}�X�^�ݒ�̋N������ >= Now
            if (startTime.CompareTo(systemTime) >= 0)
                {
                interval = (int)(startTime - systemTime);
                }
                else
                {
                interval = (int)(_INTERVAL - ((systemTime - startTime)) % _INTERVAL);
            }

            return interval;
        }
        // ADD BY wujun K2013/07/29---------<<<<<<<<<<

        /// <summary>
        /// �v��Timer
        /// </summary>
        /// <param name="sender">�C�x���g�Z���_�[</param>
        /// <param name="e">�C���x���g�p�����[�^�[</param>
        /// <remarks>
        /// <br>Note       : �v��Timer</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                // �������M����
                //this.SendDataAuto();�@// DEL BY wujun K2013/07/29

                // ADD BY wujun K2013/07/29--------->>>>>>>>>>
                //�N���N�t���O���f
                if (this.autoRunFlg)
                {
                    // �������M����
                this.SendDataAuto();
                    this.autoRunFlg = false;
                    // �ꕪ��ɐڑ���}�X�^�̋N�����ԍĎ擾
                    timer1.Interval = _INTERVALMin;
                }
                else
                {
                    // �ڑ���}�X�^�ݒ���̎擾
                    this._connectInfoWork = this.Read();
                    if (null == _connectInfoWork)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�ڑ�����ݒ�}�X�^���o�^����Ă��܂���B", 0);
                        this.Close();
                        return;
                    }
                    string bootTime = this._connectInfoWork.BootTime.ToString().PadLeft(4, '0');

                    int interval = getNextRunTime(bootTime);
                    this.autoRunFlg = true;
                    timer1.Interval = interval;

                }
                // ADD BY wujun K2013/07/29---------<<<<<<<<<
                timer1.Enabled = true;
            }
            // ����Ɉ��
            //timer1.Interval = _INTERVAL;�@// DEL BY wujun K2013/07/29
        }

        /// <summary>
        /// ���M���O�̕\��
        /// </summary>
        //private void ShowLog() // DEL �c���� K2013/08/07 Redmine#39695
        private void ShowLog(int status) // ADD �c���� K2013/08/07 Redmine#39695
        {
            PMSAE04010UA dialogForm = new PMSAE04010UA();
            //dialogForm.ShowDialog(1 // DEL �c���� K2013/08/07 Redmine#39695
            dialogForm.ShowDialog(status // ADD �c���� K2013/08/07 Redmine#39695
                                       , DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0')
                                       , 0
                                       , 0
                                       , 0
                                       , "");
        }
        #endregion

        #region Public Method
        /// <summary>
        /// �������M�������s���B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������M�������s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// <br>UpdateNote : 2013/08/12 �c����</br>
        /// <br>           : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
        /// </remarks>
        public void SendDataAuto()
        {
            int status = -1;
            string errMsg = "";

            int logStatus = 0;
            SAndESalSndLogListResultWork sAndESalSndLogWork = null;

            // �e�L�X�g�t�@�C���� 
            MakeOutFileNameFromXmlFile(this._connectInfoWork);

            // ���o�����N���X�쐬
            SalesHistoryCndtn salesHistoryCndtn = MakeSalesHistoryCndtn(this._connectInfoWork);

            try
            {
                //�f�[�^���o����
                status = this._salesHistoryAcs.SearchSalesHistoryProcMain(salesHistoryCndtn, out errMsg);
            }
            catch (Exception)
            {
                //ShowLog(); // DEL �c���� K2013/08/07 Redmine#39695
                ShowLog(1); // ADD �c���� K2013/08/07 Redmine#39695
                return; // ADD �c���� K2013/08/07 Redmine#39695
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                //ShowLog(); // DEL �c���� K2013/08/07 Redmine#39695
                //----- ADD �c���� K2013/08/07 Redmine#39695 ---------->>>>>
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    ShowLog(2); // �f�[�^�����̏ꍇ�A���M���ʉ�ʂő��M���ʁF���M�ΏۂȂ�
                }
                else
                {
                    ShowLog(1);
                }
                //----- ADD �c���� K2013/08/07 Redmine#39695 ----------<<<<<
                return;
            }
            //�e�L�X�g�o�͏���
            try
            {
                if (string.Empty.Equals(_fileName))
                {
                    this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, -1, LOGMSG_FOLDERERROR);
                    //ShowLog(); // DEL �c���� K2013/08/07 Redmine#39695
                    ShowLog(1); // ADD �c���� K2013/08/07 Redmine#39695
                    return;
                }
                int totalCount = 0;

                //FormattedTextWriter�N���X�̃v���p�e�B
                SetFormattedTextWriter();

                status = _formattedTextWriter.TextOut(out totalCount);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = -1;
                this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logStatus = this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                //ShowLog(); // DEL �c���� K2013/08/07 Redmine#39695
                ShowLog(1); // ADD �c���� K2013/08/07 Redmine#39695
                return;
            }

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this._salesHistoryAcs.SendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                //logStatus = this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR); // DEL �c���� K2013/08/12 Redmine#39695
                logStatus = this._salesHistoryAcs.WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, -1, LOGMSG_ERROR); // ADD �c���� K2013/08/12 Redmine#39695
                //ShowLog(); // DEL �c���� K2013/08/07 Redmine#39695
                ShowLog(1); // ADD �c���� K2013/08/07 Redmine#39695
                return;
            }

            status = SaveNetSendSetting();
            if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = this._salesHistoryAcs.SendAndReceive(ref salesHistoryCndtn, _fileName, out sAndESalSndLogWork, out logStatus);
            }
            

            //S&E���㒊�o�f�[�^�X�V����
            try
            {
                if (status == 0)
                {
                    //�f�[�^���o����
                    status = this._salesHistoryAcs.Write(out errMsg);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // �t�@�C���폜
                        status = this.DeleteFile();
                    }
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                // ���M���ʉ�ʕ\��
                string time = sAndESalSndLogWork.SendDateTimeEnd.ToString();
                string endTime = string.Empty;
                if (!time.Equals("0"))
                {
                    endTime = time.Substring(8, 2) + ":" + time.Substring(10, 2);
                }
                else
                {
                    endTime = string.Empty;
                }
                PMSAE04010UA dialogForm = new PMSAE04010UA();
                dialogForm.ShowDialog(sAndESalSndLogWork.SendResults
                                           , endTime
                                           , sAndESalSndLogWork.SendSlipCount
                                           , sAndESalSndLogWork.SendSlipDtlCnt
                                           , sAndESalSndLogWork.SendSlipTotalMny
                                           , sAndESalSndLogWork.SendErrorContents);
            }

            return;
        }
        #endregion

        # region [�[���ݒ�擾]
        /// <summary>
        /// �[���ݒ�擾����
        /// </summary>
        /// <param name="posTerminalMg">POS�[���Ǘ��ݒ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �[���ݒ�擾�������s���B</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : K2013/06/27</br>
        /// </remarks>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion
    }
}