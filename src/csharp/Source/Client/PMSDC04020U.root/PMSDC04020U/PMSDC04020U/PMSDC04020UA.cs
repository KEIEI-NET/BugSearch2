//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00 �쐬�S�� : 杍^
// �� �� ��  K2019/12/02 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00 �쐬�S�� : ����
// �� �� ��  2020/02/04  �C�����e : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�
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
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/12/02</br>
    /// </remarks>
    public partial class PMSDC04020UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Member
        // ����f�[�^�e�L�X�g�o�� �A�N�Z�X�N���X
        private SalesCprtAcs _salesCprtAcs;
        // �ڑ�����ݒ� �A�N�Z�X�N���X
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs;
        // ��ƃR�[�h
        private string _enterpriseCode;

        /// <summary>���O���b�Z�[�W�F���M�����G���[</summary>
        private const string LOGMSG_ERROR = "���M�����G���[";

        /// <summary>���O���b�Z�[�W�F�t�H���_�[�s����</summary>
        private const string LOGMSG_FOLDERERROR = "�w�肳�ꂽ�t�H���_�����݂��܂���";

        // ���(millisecond)
        private const int _INTERVAL = 86400000;

        // �ꕪ
        private const int _INTERVALMin = 60000;

        //  ����������sFlg
        private bool fstRunFlg = false;

        // �N�����Ԃ����ԑѓ�Flg
        private bool aotoRunFlg = false;
        // �ڑ�����ݒ�List
        private ArrayList _connectInfoList = null;

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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        public PMSDC04020UA()
        {
            // ����������
            InitializeComponent();
            // ���O�C����ƃR�[�h
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ����f�[�^�e�L�X�g�o�� �A�N�Z�X�N���X������
            _salesCprtAcs = new SalesCprtAcs();
            // �ڑ���A�N�Z�X�N���X
            _connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// �ڑ�����ݒ�擾
        /// </summary>
        /// <returns>�ڑ�����</returns>
        /// <remarks>
        /// <br>Note		: �ڑ�����ݒ�擾���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private ArrayList Read()
        {
            ArrayList connectInfoList = new ArrayList();
            connectInfoList.Clear();
            ArrayList aotoConnectInfoList = new ArrayList();
            aotoConnectInfoList.Clear();

            // �ڑ�����ݒ�擾
            int status = this._connectInfoWorkAcs.SearchAll(out connectInfoList, this._enterpriseCode);

            if (connectInfoList != null && connectInfoList.Count > 0)
            {
                foreach (SalCprtConnectInfoWork salCprtConnectInfoWork in connectInfoList)
                {
                    // �ڑ���ݒ�}�X�^�ɓo�^�ςݒ[���ԍ��̑Ή��[�����̂ƈ�v����ꍇ���������M�̏ꍇ
                    if (salCprtConnectInfoWork.LogicalDeleteCode == 0 
                        && salCprtConnectInfoWork.AutoSendDiv == 0
                        && (this._posTerminalMg.MachineName.ToUpper().Trim() == salCprtConnectInfoWork.SendMachineName.ToUpper().Trim()))
                    {
                        aotoConnectInfoList.Add(salCprtConnectInfoWork);
                    }
                }
            }

            if (aotoConnectInfoList != null && aotoConnectInfoList.Count > 0 &&
                status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return aotoConnectInfoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �ڑ�����ݒ�
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: �ڑ�����ݒ���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private int Write(ref SalCprtConnectInfoWork connectInfoWork)
        {
            int status = 0;
            status = _connectInfoWorkAcs.Write(ref connectInfoWork, 0);
            return status;
        }

        /// <summary>
        /// �ڑ���}�X�^���猟���p�����[�^�[�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ڑ���}�X�^���猟���p�����[�^�[�쐬���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private SalesCprtCndtnWork MakeSalesHistoryCndtn(SalCprtConnectInfoWork connectInfoWork)
        {
            SalesCprtCndtnWork retSalesCprtCndtn = new SalesCprtCndtnWork();
            // ��ƃR�[�h
            retSalesCprtCndtn.EnterpriseCode = this._enterpriseCode;
            // ���Ӑ�R�[�h
            retSalesCprtCndtn.CustomerCode = connectInfoWork.CustomerCode;
            // ���_�R�[�h
            retSalesCprtCndtn.SectionCode = connectInfoWork.SectionCode.PadLeft(2,'0');

            // �����J�n����
            try
            {
                retSalesCprtCndtn.SearchTimeSt = DateTime.ParseExact(connectInfoWork.FrstSendDate.ToString(), "yyyyMMdd", null);

            }
            catch
            {
                retSalesCprtCndtn.SearchTimeSt = DateTime.MinValue;
            }

            // �������M�ڑ��敪
            retSalesCprtCndtn.AutoDataSendDiv = connectInfoWork.CnectSendDiv;

            // ���M�敪(0:�蓮;1:����)
            retSalesCprtCndtn.SendDataDiv = 1; 

            return retSalesCprtCndtn;
        }

        /// <summary>
        /// ���ԃt�H�}�b�g�ύX
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>int</returns>
        /// <remarks>
        /// <br>Note		: ���ԃt�H�}�b�g�ύX���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: K2019/12/02</br>
        /// </remarks>
        private int DateTimeToInt(DateTime dt)
        {
            return dt.Year * 10000 + dt.Month * 100 + dt.Day;
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : K2019/12/02</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMSDC04020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private void PMSDC04020UA_Load(object sender, EventArgs e)
        {
            // �[���ݒ�̎擾
            this.GetPosTerminalMg(out this._posTerminalMg, this._enterpriseCode);

            if (null == _posTerminalMg)
            {
                // �[�����ݒ莞�A�풓���N�����Ȃ�
                this.Close();
                return;
            }

            // �ڑ���}�X�^�ݒ���̎擾
            this._connectInfoList = this.Read();

            if (null == _connectInfoList || _connectInfoList.Count == 0)
            {
                // �ڑ���}�X�^�ݒ�擾�ł��Ȃ����A�풓���N�����Ȃ�
                this.Close();
                return;
            }

            this.Visible = false;
            this.notifyIcon1.Visible = true;

            // ���M���ԑѓ��Ȃ�A�������M�N��
            int interval = getNextRunTime();
            if (!this.aotoRunFlg)
            {
                timer1.Interval = interval;
            }
            
            timer1.Enabled = true;
        }

        /// <summary>
        /// Timer�̎���N�����ԎZ�o
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������s���Ԍv�Z</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private int getNextRunTime()
        {
            SalCprtConnectInfoWork connectInfo = (SalCprtConnectInfoWork)_connectInfoList[0];

            // �N������
            string bootTime = connectInfo.BootTime.ToString().PadLeft(4, '0');
            // �I������
            string endTime = connectInfo.EndTime.ToString().PadLeft(4, '0');
            // �V�X�e�����Ԏ擾
            double systemTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double nextTime = connectInfo.ExecInterval * _INTERVALMin + systemTime;

            int stHours = 0;
            int stMinitus = 0;
            if (bootTime != "0")
            {
                stHours = Convert.ToInt16(bootTime.Substring(0, 2));
                stMinitus = Convert.ToInt16(bootTime.Substring(2, 2));
            }

            int edHours = 0;
            int edMinitus = 0;
            if (endTime != "0")
            {
                edHours = Convert.ToInt16(endTime.Substring(0, 2));
                edMinitus = Convert.ToInt16(endTime.Substring(2, 2));
            }

            double stTime = new TimeSpan(stHours, stMinitus, 0).TotalMilliseconds;
            double edTime = new TimeSpan(edHours, edMinitus, 0).TotalMilliseconds;

            int interval;

            this.fstRunFlg = false;
            // �ڑ���}�X�^�ݒ�̋N������ >= Now
            if (stTime.CompareTo(systemTime) >= 0)
            {
                interval = (int)(stTime - systemTime);
            }
            else
            {

                // Now > �ڑ���}�X�^�ݒ�̏I������
                if (systemTime.CompareTo(edTime) > 0 || nextTime.CompareTo(edTime) > 0)
                {
                    interval = (int)(_INTERVAL - systemTime + stTime);
                    this.fstRunFlg = true;
                }
                else
                {
                    interval = (int)(connectInfo.ExecInterval * _INTERVALMin);
                    this.aotoRunFlg = true;
                }
            }

            return interval;
        }

        /// <summary>
        /// �v��Timer
        /// </summary>
        /// <param name="sender">�C�x���g�Z���_�[</param>
        /// <param name="e">�C���x���g�p�����[�^�[</param>
        /// <remarks>
        /// <br>Note       : �v��Timer</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;

                if (this.fstRunFlg)
                {
                    // �����̏�����s���A�ڑ���}�X�^�ݒ���̎擾
                    this._connectInfoList = this.Read();
                    if (null == this._connectInfoList || this._connectInfoList.Count == 0)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�ڑ�����ݒ�}�X�^���o�^����Ă��܂���B", 0);
                        this.Close();
                        return;
                    }
                }
                // �������M����
                foreach (SalCprtConnectInfoWork connectInfoWork in this._connectInfoList)
                {
                    this.SendDataAuto(connectInfoWork);
                }

                // �ݒ�̎��s�Ԋu��ɐڑ���}�X�^�̋N�����ԍĎ擾                   
                timer1.Interval = getNextRunTime();

                timer1.Enabled = true;
            }
        }

        /// <summary>
        /// ���M�t�@�C���������
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note		: ���M�t�@�C���������</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private String GetXmlFileName(string fileName)
        {
            string xmlFileName = string.Empty;
            if (!String.IsNullOrEmpty(fileName))
            {
                if (fileName.Contains("."))
                {
                    int index = fileName.LastIndexOf(".");
                    fileName = fileName.Substring(0, index) + ".XML";
                }
                else
                {
                    fileName = fileName + ".XML";
                }
                xmlFileName = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT) + "\\" + fileName;
            }
            return xmlFileName;
        }

        /// <summary>
        /// �������MXML����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �������MXML�𐶐�����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int SaveNetSendSetting(string fileName, ref SalesCprtCndtnWork salesCprtCndtnWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageIn = string.Empty;
            string xmlFileName = string.Empty;
            List<long> timeSortList = new List<long>();

            try
            {
                int rowsCount = this._salesCprtAcs.SalesHistoryDt.Rows.Count;
                XmlNode root = null;
                XmlElement data = null;
                // �X�V����������
                XmlElement update = null;
                // �`�[�敪������
                XmlElement kubun = null;
                // ���Ӑ溰�ޏ�����
                XmlElement kjcd = null;
                // ������t������
                XmlElement dndt = null;
                // ����`�[�ԍ�������
                XmlElement dnno = null;
                // ����s�ԍ�������uButton_SectionGuide
                XmlElement dngyno = null;
                // �i��������
                XmlElement pmncd = null;
                // ���[�J�[��������
                XmlElement mkname = null;
                // BL���i�R�[�h������
                XmlElement blcd = null;
                // �o�א�������
                XmlElement sksu = null;
                // ����P��������
                XmlElement unprc = null;
                // ������z������
                XmlElement taxexc = null;
                // ���l�P������
                XmlElement note = null;
                // ���l2������
                XmlElement note2 = null;
                // ���l3������
                XmlElement note3 = null;
                // �����`�[�ԍ�������
                XmlElement mtdnno = null;
                XmlDocument xmldoc = new XmlDocument();
                XmlElement xmlelem = xmldoc.CreateElement("", "NETSEND", "");
                xmldoc.AppendChild(xmlelem);

                long dateTimeLong = 0;
                for (int i = 0; i < rowsCount; i++)
                {
                    root = xmldoc.SelectSingleNode("NETSEND");
                    data = xmldoc.CreateElement("DATA");

                    // �X�V����
                    update = xmldoc.CreateElement("KOSINBI");
                    update.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["UpdateDateTime"].ToString();
                    if (long.TryParse(this._salesCprtAcs.SalesHistoryDt.Rows[i]["UpdateDateTime"].ToString(), out dateTimeLong))
                    {
                        timeSortList.Add(dateTimeLong);
                    }
                    data.AppendChild(update);

                    // �v���
                    dndt = xmldoc.CreateElement("KEIJOBI");
                    dndt.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["AddUpADate"].ToString();
                    data.AppendChild(dndt);

                    // ����`�[�ԍ�
                    dnno = xmldoc.CreateElement("DENNO");
                    dnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipNum"].ToString();
                    data.AppendChild(dnno);

                    // ����s�ԍ�
                    dngyno = xmldoc.CreateElement("ROWNO");
                    dngyno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesRowNo"].ToString();
                    data.AppendChild(dngyno);

                    // �`�[�敪
                    kubun = xmldoc.CreateElement("DENKUBUN");
                    kubun.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesSlipCd"].ToString();
                    data.AppendChild(kubun);

                    // ���Ӑ溰��
                    kjcd = xmldoc.CreateElement("TOKUCD");
                    kjcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["CustomerCode"].ToString();
                    data.AppendChild(kjcd);

                    // BL���i�R�[�h
                    blcd = xmldoc.CreateElement("HINCD");
                    blcd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["BLGoodsCode"].ToString();
                    data.AppendChild(blcd);

                    // �i��
                    pmncd = xmldoc.CreateElement("HINMEI");
                    pmncd.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["GoodsNameKana"].ToString();
                    data.AppendChild(pmncd);

                    // ���[�J�[��
                    mkname = xmldoc.CreateElement("MAKERMEI");
                    mkname.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["MakerName"].ToString();
                    data.AppendChild(mkname);

                    // �o�א�
                    sksu = xmldoc.CreateElement("SYUKKASU");
                    sksu.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["ShipmentCnt"].ToString();
                    data.AppendChild(sksu);

                    // ����P��
                    unprc = xmldoc.CreateElement("URITAN");
                    unprc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesUnPrcTaxExcFl"].ToString();
                    data.AppendChild(unprc);

                    // ������z
                    taxexc = xmldoc.CreateElement("URIKIN");
                    taxexc.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SalesMoneyTaxExc"].ToString();
                    data.AppendChild(taxexc);

                    // ���l�P
                    note = xmldoc.CreateElement("BIKO1");
                    note.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote"].ToString();
                    data.AppendChild(note);
                    // ���l�Q
                    note2 = xmldoc.CreateElement("BIKO2");
                    note2.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote2"].ToString();
                    data.AppendChild(note2);
                    // ���l�R
                    note3 = xmldoc.CreateElement("BIKO3");
                    note3.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["SlipNote3"].ToString();
                    data.AppendChild(note3);

                    // �����`�[�ԍ�
                    mtdnno = xmldoc.CreateElement("MOTODENNO");
                    mtdnno.InnerText = this._salesCprtAcs.SalesHistoryDt.Rows[i]["DebitNLnkSalesSlNum"].ToString();
                    data.AppendChild(mtdnno);

                    root.AppendChild(data);
                }

                timeSortList.Sort();
                long minTime = timeSortList[0];

                timeSortList.Reverse();
                long maxTime = timeSortList[0];

                salesCprtCndtnWork.SalesInfoTimeSt = minTime;
                salesCprtCndtnWork.SalesInfoTimeEd = maxTime;

                //XML��������
                xmlFileName = this.GetXmlFileName(fileName);
                xmldoc.Save(xmlFileName);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// XML�̍폜
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: XML�̍폜����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        private int DeleteXmlFile(string fileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string resultMessageDe = string.Empty;
            string xmlFileName = this.GetXmlFileName(fileName);
            try
            {
                // �t�@�C�����폜
                FileInfo info = new FileInfo(xmlFileName);
                info.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show();
            }
        }

        /// <summary>
        /// �I���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // �m�F���b�Z�[�W��\������B
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_QUESTION,                // �G���[���x��
                        "PMSDC04020U",						                // �A�Z���u���h�c�܂��̓N���X�h�c
                        "����A�g�������M",				                        // �v���O��������
                        "", 								            // ��������
                        "",									            // �I�y���[�V����
                        "�I�����������s���Ă���낵���ł����H",						    // �\�����郁�b�Z�[�W
                        -1, 							                // �X�e�[�^�X�l
                        null, 								            // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.YesNo, 				        // �\������{�^��
                        MessageBoxDefaultButton.Button1);	            // �����\���{�^��

            // ���͉�ʂ֖߂�B
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// �������M�������s���B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������M�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// <br>Update Note : 2020/02/04 ���� ���</br>
        /// <br>�Ǘ��ԍ�    : 11570219-00</br>
        /// <br>            : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public void SendDataAuto(SalCprtConnectInfoWork connectInfoWork)
        {
            int status = -1;
            string errMsg = "";

            int logStatus = 0;
            SalCprtSndLogListResultWork salCprtSndLogWork = null;

            // ���o�����N���X�쐬
            SalesCprtCndtnWork salesCprtCndtn = MakeSalesHistoryCndtn(connectInfoWork);

            try
            {
                // �f�[�^���o����
                // --- UPD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 >>>>>
                //status = this._salesCprtAcs.SearchSalesHistoryProcMain(salesCprtCndtn, out errMsg);
                status = this._salesCprtAcs.SearchSalesHistoryProcMain(salesCprtCndtn, out errMsg, connectInfoWork);
                // --- UPD 2020/02/04 T.Obara ---------- �C�����e�ꗗNo.2 <<<<<
            }
            catch (Exception)
            {
                return;
            }

            // �������MXML����
            string fileName = string.Empty;
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                fileName = connectInfoWork.CnectFileId;
            }
            else
            {
                return;
            }

            this.DeleteXmlFile(fileName);
            status = SaveNetSendSetting(fileName, ref salesCprtCndtn);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = this._salesCprtAcs.SendAndReceive(ref salesCprtCndtn, fileName, out salCprtSndLogWork, out logStatus);
            }
            
            //���㒊�o�f�[�^�X�V����
            try
            {
                if (status == 0)
                {
                    //�f�[�^�X�V����
                    status = this._salesCprtAcs.Write(out errMsg);

                    if (status == 0)
                    {
                        // ����A�g�ڑ����}�X�^�X�V
                        SalCprtConnectInfoWork updConnectInfo = connectInfoWork;
                        updConnectInfo.LtAtSadDateTime = DateTime.Now;

                        status = this._connectInfoWorkAcs.Write(ref updConnectInfo, 0);
                    }

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion

    }
}