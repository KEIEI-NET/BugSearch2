//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�K�C�h
//                    PMKHN02830UC.exe
// �v���O�����T�v   : ���Ӑ�K�C�h�̐V�K
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : zhujw
// �C �� ��  K2014/05/08 �C�����e : �ۓ�����ʊJ���ʑΉ��A�V�K�쐬
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : 32653   ���J �M�m
// �C �� ��  2021/04/13 �C�����e : ���Ӑ���K�C�h�\��PKG�Ή�
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : 杍^
// �C �� ��  2021/06/21 �C�����e : ���Ӑ���K�C�h�\���̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
// ADD 2021/04/13 ���J >>>>>>>>>>
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
// ADD 2021/04/13 ���J <<<<<<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>											
    /// ���Ӑ�K�C�hUI�N���X											
    /// </summary>											
    /// <remarks>											
    /// <br>Note       : ���Ӑ�K�C�hUI�N���X</br>											
    /// <br>Programmer : zhujw</br>
    /// <br>Date       : K2014/05/08</br>											
    /// <br>�Ǘ��ԍ�   : 11070071-00 �ۓ�����ʊJ���ʑΉ�</br>			
    /// <br>Programmer : 32653 ���J �M�m</br>
    /// <br>Date       : 2021/04/13</br>											
    /// <br>�Ǘ��ԍ�   : 11770021-00 ���Ӑ���K�C�h�\��PKG�Ή�</br>		
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2021/06/21</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00 ���Ӑ���K�C�h�\���̑Ή�</br>
    public partial class PMKHN02830UCA : Form
    {
        private const string XML_NAME_SALE = "MAHNB01001U";  // ����`�[����
        // ADD 2021/04/13 ���J >>>>>>>>>>
        private const string xPathDocPath = "PMKHN02830U_CustomerGuideDis.XML";
        private const string PartsmanPass = @"SOFTWARE\Broadleaf\Product\Partsman"; //Partsman�t�H���_�̃p�X
        private const string InstallDirectory = "InstallDirectory"; //�C���X�g�[���f�B���N�g��
        private const string elePosCustomer = "PosCustomer"; //���Ӑ�
        private const string eleCustomerClaim = "CustomerClaim"; //������
        private const string elePostNo = "PostNo"; //�X�֔ԍ�
        private const string eleAddress = "Address"; //�Z��
        private const string eleHomeTelNoFaxNo = "HomeTelNoFaxNo"; //����d�b/FAX
        private const string eleOfficeTelNoFaxNo = "OfficeTelNoFaxNo"; //�Ζ���d�b/FAX
        private const string eleCellphoneNo = "CellphoneNo"; //�g�ѓd�b
        private const string elePureAll = "PureAll"; //����ALL
        private const string elePrimeAll = "PrimeAll"; //�D��ALL
        private const string eleAgent = "Agent"; //�S����
        private const string eleCustomerAgent = "CustomerAgent"; //���Ӑ�S����
        private const string eleBusinessType = "BusinessType"; //�Ǝ�
        private const string eleArea = "Area"; //�n��
        private const string eleAccRecDiv = "AccRecDiv"; //���|�敪
        private const string eleCollectMoney = "CollectMoney"; //����/�����/�����/�������
        private const string eleMemo = "Memo"; //����
        private const string CHECK_ON = "1"; //�`�F�b�N��ON
        private const int Top_Space = 15; //��ʏ㕔����e���ڂ܂ł̋���
        private const int Down_Space = 44; //��ʉ�������e���ڂ܂ł̋���
        private const int defItmHeight = 20; //�e���ڂ̍���
        private const int defaultSize_Width = 592; //�f�t�H���g�̓��Ӑ���K�C�h��ʂ̉���
        private const int defaultSize_Height = 561; //�f�t�H���g�̓��Ӑ���K�C�h��ʂ̏c��
        // ���O�o�͕��i
        OutLogCommon LogCommon;
        // �N���C�A���g���O�o�͓��e
        private const string ErrorMessage1 = "PMKHN002830UC Ok_Button_Click XML�f�[�^�擾�ŗ�O����";
        private const string ErrorMessage2 = "PMKHN002830UC selectByXML XML�p�X�擾�ŗ�O����";
        // PGID
        private const string CtPGID = "PMKHN002830UC";
        // ADD 2021/04/13 ���J <<<<<<<<<<
        private int _pID;
        // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� ----->>>>>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);
        private static bool ChangeState = false;

        private const int UFlags = 0x53;
        private const int LocationZero = 0;
        private const int KEY_ESC = 27;
        // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� -----<<<<<

        /// <summary>
        /// ���Ӑ�K�C�h�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="customerCode">���Ӑ�(�R�[�h)</param>
        /// <param name="customerSnm">���Ӑ�(����)</param>
        /// <param name="claimCode">������(�R�[�h)</param>
        /// <param name="claimSnm">������(����)</param>
        /// <param name="postNo">�X�֔ԍ�</param>
        /// <param name="address1">�Z���P</param>
        /// <param name="address2">�Z��3</param>
        /// <param name="address3">�Z��4</param>
        /// <param name="homeTelNo">����d�b</param>
        /// <param name="officeTelNo">����FAX</param>
        /// <param name="portableTelNo">�Ζ���d�b</param>
        /// <param name="homeFaxNo">�Ζ���FAX</param>
        /// <param name="officeFaxNo">�g�ѓd�b</param>
        /// <param name="pureCustRateGrpCode">����ALL</param>
        /// <param name="excellentCustRateGrpCode">�D��ALL</param>
        /// <param name="customerAgent">���Ӑ�S����</param>
        /// <param name="customerAgentCd">�S����(�R�[�h)</param>
        /// <param name="customerAgentNm">�S���Җ�</param>
        /// <param name="businessTypeCode">�Ǝ�(�R�[�h)</param>
        /// <param name="businessTypeName">�Ǝ햼</param>
        /// <param name="salesAreaCode">�n��(�R�[�h)</param>
        /// <param name="salesAreaName">�n��(����)</param>
        /// <param name="accRecDivCd">���|�敪</param>
        /// <param name="TotalDay">����</param>
        /// <param name="collectMoneyName">�W����</param>
        /// <param name="collectMoneyDay">�W����</param>
        /// <param name="collectCond">�������</param>
        /// <param name="noteInfo">����</param>
        /// <param name="homeTelNoDspName">����d�b</param>
        /// <param name="officeTelNoDspName">�Ζ���d�b</param>
        /// <param name="mobileTelNoDspName">�g�ѓd�b</param>
        /// <param name="homeFaxNoDspName">����FAX</param>
        /// <param name="officeFaxNoDspName">�Ζ���FAX</param>
        /// <param name="PID">ProcessID</param>
        /// <param name="titleNo">�^�C�g��No</param>
        // UPD 2021/04/13 ���J >>>>>>>>>>
        //public PMKHN02830UCA(string customerCode, string customerSnm, string claimCode, 
        //    string claimSnm, string postNo,string address1, string address2,
        //    string address3,string homeTelNo,string officeTelNo,string portableTelNo,
        //    string homeFaxNo, string officeFaxNo, string pureCustRateGrpCode, string excellentCustRateGrpCode,
        //    string customerAgent,string customerAgentCd,string customerAgentNm,string businessTypeCode,
        //    string businessTypeName,string salesAreaCode,string salesAreaName,
        //    string accRecDivCd,string TotalDay,string collectMoneyName,string collectMoneyDay,
        //    string collectCond, string noteInfo,string homeTelNoDspName,
        //    string officeTelNoDspName,string mobileTelNoDspName,string homeFaxNoDspName,string officeFaxNoDspName,string PID)
        public PMKHN02830UCA(string customerCode, string customerSnm, string claimCode, 
            string claimSnm, string postNo,string address1, string address2,
            string address3,string homeTelNo,string officeTelNo,string portableTelNo,
            string homeFaxNo, string officeFaxNo, string pureCustRateGrpCode, string excellentCustRateGrpCode,
            string customerAgent,string customerAgentCd,string customerAgentNm,string businessTypeCode,
            string businessTypeName,string salesAreaCode,string salesAreaName,
            string accRecDivCd,string TotalDay,string collectMoneyName,string collectMoneyDay,
            string collectCond, string noteInfo,string homeTelNoDspName,
            string officeTelNoDspName,string mobileTelNoDspName,string homeFaxNoDspName,string officeFaxNoDspName,string PID,string titleNo)
        // UPD 2021/04/13 ���J <<<<<<<<<<
        {
            InitializeComponent();

            // ADD 2021/04/13 ���J >>>>>>>>>>
            // �^�C�g��No
            if (!string.IsNullOrEmpty(titleNo.Trim()))
            {
                // �^�C�g��
                this.Text = this.Text + titleNo;
            }
            // ADD 2021/04/13 ���J <<<<<<<<<<

            // PID
            if (!string.IsNullOrEmpty(PID))
            {
                _pID = Convert.ToInt32(PID);
            }

            if (!string.IsNullOrEmpty(homeTelNoDspName.Trim()))
            {
                // ����d�b
                this.uLabel_HomeTelNoDspName.Text = homeTelNoDspName;
            }
            else
            {
                this.uLabel_HomeTelNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(officeTelNoDspName.Trim()))
            {
                // �Ζ���d�b
                this.uLabel_OfficeTelNoDspName.Text = officeTelNoDspName;
            }
            else
            {
                this.uLabel_OfficeTelNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(mobileTelNoDspName.Trim()))
            {
                // �g�ѓd�b
                this.uLabel_MobileTelNoDspName.Text = mobileTelNoDspName;
            }
            else
            {
                this.uLabel_MobileTelNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(homeFaxNoDspName.Trim()))
            {
                // ����FAX
                this.uLabel_HomeFaxNoDspName.Text = homeFaxNoDspName;
            }
            else
            {
                this.uLabel_HomeFaxNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(officeFaxNoDspName.Trim()))
            {
                // �Ζ���FAX
                this.uLabel_OfficeFaxNoDspName.Text = officeFaxNoDspName;
            }
            else
            {
                this.uLabel_OfficeFaxNoDspName.Text = string.Empty;
            }

            // ���Ӑ�(�R�[�h)
            this.uLabel_CustomerCode.Text = customerCode;
            // ���Ӑ�(����)
            this.uLabel_CustomerName.Text = customerSnm;
            // ������(�R�[�h)
            this.ultraLabel_ClaimCode.Text = claimCode;
            // ������(����)
            this.ultraLabel_ClaimName.Text = claimSnm;
            // �X�֔ԍ� 
            this.ultraLabel_PostNo.Text = postNo;
            // �Z���P
            this.ultraLabel_Address1.Text = address1;
            // �Z���Q
            this.ultraLabel_Address3.Text = address2;
            // �Z���R
            this.ultraLabel_Address4.Text = address3;
            // ����d�b
            this.ultraLabel_HomeTelNo.Text = homeTelNo;
            // ����FAX
            this.ultraLabel_HomeFaxNo.Text = homeFaxNo;
            // �Ζ���d�b
            this.ultraLabel_OfficeTelNo.Text = officeTelNo;
            // �Ζ���FAX
            this.ultraLabel_OfficeFaxNo.Text = officeFaxNo;
            // �g�ѓd�b
            this.ultraLabel_PortableTelNo.Text = portableTelNo;
            // ����ALL
            this.ultraLabel_Pure.Text = pureCustRateGrpCode;
            // �D��ALL
            this.ultraLabel_Excellent.Text = excellentCustRateGrpCode;
            // ���Ӑ�S����
            this.ultraLabel_CustomerAgent.Text = customerAgent;
            // �S����(�R�[�h)
            this.ultraLabel_CustomerAgentCd.Text = customerAgentCd;
            // �S���Җ�
            this.ultraLabel_CustomerAgentNm.Text = customerAgentNm;
            // �Ǝ�(�R�[�h)
            this.ultraLabel_BusinessTypeCode.Text = businessTypeCode;
            // �Ǝ햼
            this.ultraLabel_BusinessTypeName.Text = businessTypeName;
            // �n��(�R�[�h)
            this.ultraLabel_SalesAreaCode.Text = salesAreaCode;
            // �n��(����)
            this.ultraLabel_SalesAreaName.Text = salesAreaName;
            // ���|�敪
            this.ultraLabel_AccRecDivCd.Text = accRecDivCd;
            // ����
            this.ultraLabel_TotalDay.Text = TotalDay;
            // �W����
            this.ultraLabel_CollectMoneyName.Text = collectMoneyName;
            // �W����
            this.ultraLabel_CollectMoneyDay.Text = collectMoneyDay;
            // �������
            this.ultraLabel_CollectCond.Text = collectCond;

            if (!string.IsNullOrEmpty(noteInfo.Trim()))
            {
                //���̐ݒ�
                this.Memo_TextBox.Text = noteInfo;
            }
            else
            {
                //���̐ݒ�
                this.Memo_TextBox.Text = string.Empty;
            }

            // ADD 2021/04/13 ���J >>>>>>>>>>
            //XML����\���������ǂݍ���
            //selectByXML();
            // ADD 2021/04/13 ���J <<<<<<<<<<

            //�t�H�[�J�X��擪�ɃZ�b�g
            this.Memo_TextBox.Select(0, 0);
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        /// <br>Programmer : 32653 ���J �M�m</br>
        /// <br>Date       : 2021/04/13</br>											
        /// <br>�Ǘ��ԍ�   : 11770021-00 ���Ӑ���K�C�h�\��PKG�Ή�</br>	
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/06/21</br>											
        /// <br>�Ǘ��ԍ�   : 11770021-00 ���Ӑ���K�C�h�\���̑Ή�</br>	
        private void PMKHN02830UCA_Load(object sender, EventArgs e)
        {
            //��ʂ͑O�ʂɃZ�b�g
            selectByXML();// ADD 2021/04/13 ���J
            //this.TopMost = true; //DEL 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή�
            SetGuidButtonIcon();
        }

        /// <summary>
        /// �ݒ�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ݒ�{�^���ɃA�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���J �M�m</br>
        /// <br>Date        : 2021/04/13</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.Ok_Button.ImageList = IconResourceManagement.ImageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.SETUP1;
        }

        /// <summary>
        /// timer1_Tick�C�x���g
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            timer1.Enabled = false;
        }

        /// <summary>
        /// timer2_Tick�C�x���g
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        /// <remarks>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/06/21</br>											
        /// <br>�Ǘ��ԍ�   : 11770021-00 ���Ӑ���K�C�h�\���̑Ή�</br>	
        /// </remarks>
        private void timer2_Tick(object sender, EventArgs e)
        {
            bool closeflag = false;
            IntPtr intptr = IntPtr.Zero; // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή�
            Process[] allProgresse = System.Diagnostics.Process.GetProcessesByName(XML_NAME_SALE);
            if (allProgresse.Length == 0)
            {
                //����`�[���͑��݂��Ȃ��ꍇ�A�{��ʕ���
                this.Close();
            }
            else
            {
                foreach (Process pro in allProgresse)
                {
                    if (pro.Id.Equals(Convert.ToInt32(_pID)))
                    {
                        closeflag = true;
                        intptr = pro.MainWindowHandle;// ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή�
                    }
                }
                if (!closeflag)
                {
                    //����`�[���͑��݂��Ȃ��ꍇ�A�{��ʕ���
                    this.Close();
                }
                // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� ----->>>>>
                else
                {
                    //���݃A�N�e�B�u�ɂȂ��Ă���E�B���h�E���ďo�����H
                    if (intptr == GetForegroundWindow())
                    {
                        //�O��`�F�b�N���͌ďo�����A�N�e�B�u�ł͂Ȃ��������H
                        if (ChangeState == true)
                        {
                            //���Ӑ�K�C�h�\�����őO�ʕ\������
                            SetWindowPos(this.Handle, intptr, LocationZero, LocationZero, LocationZero, LocationZero, UFlags);
                        }
                        ChangeState = false;
                    }
                    else
                    {
                        ChangeState = true;
                    }
                }
                // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� -----<<<<<
            }
        }

        /// <summary>
        /// MemoRichText��Mouse��RightClick�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Memo_TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // ���ɖ߂�
                this.toolStripMenuItem_Undo.Enabled = false;
                // �؂���
                this.toolStripMenuItem_Cut.Enabled = false;
                // �폜
                this.toolStripMenuItem_Clear.Enabled = false;
                // �R�s�[
                if (string.IsNullOrEmpty(this.Memo_TextBox.SelectedText))
                {
                    this.toolStripMenuItem_Copy.Enabled = false;
                }
                else
                {
                    this.toolStripMenuItem_Copy.Enabled = true;
                }
                // �\��t��
                this.toolStripMenuItem_Paste.Enabled = false;

                this.contextMenuStrip1.Show(this.Memo_TextBox, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// MouseRightClick��Menu�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // ���ɖ߂�
            if (toolStripMenuItem_Undo.Selected)
            {
                this.Memo_TextBox.Undo();
            }
            // �؂���
            if (toolStripMenuItem_Cut.Selected)
            {
                this.Memo_TextBox.Cut();
            }
            // �R�s�[
            if (toolStripMenuItem_Copy.Selected)
            {
                this.Memo_TextBox.Copy();
            }
            // �\��t��
            if (toolStripMenuItem_Paste.Selected)
            {
                this.Memo_TextBox.Paste();
            }
            // �폜
            if (toolStripMenuItem_Clear.Selected)
            {
                this.Memo_TextBox.Clear();
            }
            // ���ׂđI��
            if (toolStripMenuItem_Select.Selected)
            {
                this.Memo_TextBox.SelectAll();
            }
        }

        /// <summary>
        /// �ݒ�{�^���̃N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            try
            {
                PMKHN02840UA demandConfirm = new PMKHN02840UA();

                DialogResult dialogResult = demandConfirm.ShowDialog(this);

                //�_�C�A���O�ɂĂn�j�{�^�����������ꂽ�ꍇ�A���ڂ���V����
                if (dialogResult == DialogResult.OK)
                {
                    this.Hide();
                    this.selectByXML();
                    this.Show();
                    this.Memo_TextBox.Select(0, 0);
                }
            }
            catch (Exception ex)
            {
                // ���O�o��
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(CtPGID, ErrorMessage1, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }
        }

        // ADD 2021/04/13 ���J >>>>>>>>>>
        /// <summary>
        /// xml�t�@�C���̓ǂݍ��݃C�x���g
        /// </summary>
        private void selectByXML()
        {
            int dispItmCount = 0; //�\�����ڂ̃`�F�b�N���J�E���g
            String xmlFileNameDocPrt = "";
            try
            {
                Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(PartsmanPass);
                xmlFileNameDocPrt = Path.Combine(Path.Combine((string)(keys.GetValue(InstallDirectory)), ConstantManagement_ClientDirectory.UISettings), xPathDocPath);
            }
            catch(Exception ex)
            {
                // ���O�o��
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(CtPGID, ErrorMessage2, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }

            if (File.Exists(xmlFileNameDocPrt))
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

                //���Ӑ���\���ݒ��XML�t�@�C����ǂݍ���
                using (XmlReader xmlReader = XmlReader.Create(xmlFileNameDocPrt, xmlReaderSettings))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement(elePosCustomer))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel1.Visible = true;
                                this.uLabel_CustomerCode.Visible = true;
                                this.uLabel_CustomerName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel1.Visible = false;
                                this.uLabel_CustomerCode.Visible = false;
                                this.uLabel_CustomerName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCustomerClaim))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel2.Location = new Point(this.ultraLabel2.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_ClaimCode.Location = new Point(this.ultraLabel_ClaimCode.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_ClaimName.Location = new Point(this.ultraLabel_ClaimName.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel2.Visible = true;
                                this.ultraLabel_ClaimCode.Visible = true;
                                this.ultraLabel_ClaimName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel2.Visible = false;
                                this.ultraLabel_ClaimCode.Visible = false;
                                this.ultraLabel_ClaimName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(elePostNo))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel3.Location = new Point(this.ultraLabel3.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_PostNo.Location = new Point(this.ultraLabel_PostNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel3.Visible = true;
                                this.ultraLabel_PostNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel3.Visible = false;
                                this.ultraLabel_PostNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleAddress))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA3�s���̃J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel4.Location = new Point(this.ultraLabel4.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Address1.Location = new Point(this.ultraLabel_Address1.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Address3.Location = new Point(this.ultraLabel_Address3.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel_Address4.Location = new Point(this.ultraLabel_Address4.Location.X, Top_Space + defItmHeight * (dispItmCount + 2));

                                this.ultraLabel4.Visible = true;
                                this.ultraLabel_Address1.Visible = true;
                                this.ultraLabel_Address3.Visible = true;
                                this.ultraLabel_Address4.Visible = true;
                                dispItmCount = dispItmCount + 3;
                            }
                            else
                            {
                                this.ultraLabel4.Visible = false;
                                this.ultraLabel_Address1.Visible = false;
                                this.ultraLabel_Address3.Visible = false;
                                this.ultraLabel_Address4.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleHomeTelNoFaxNo))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.uLabel_HomeTelNoDspName.Location = new Point(this.uLabel_HomeTelNoDspName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_HomeTelNo.Location = new Point(this.ultraLabel_HomeTelNo.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.uLabel_HomeFaxNoDspName.Location = new Point(this.uLabel_HomeFaxNoDspName.Location.X, Top_Space + 1 + defItmHeight * dispItmCount);
                                this.ultraLabel_HomeFaxNo.Location = new Point(this.ultraLabel_HomeFaxNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.uLabel_HomeTelNoDspName.Visible = true;
                                this.ultraLabel_HomeTelNo.Visible = true;
                                this.uLabel_HomeFaxNoDspName.Visible = true;
                                this.ultraLabel_HomeFaxNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.uLabel_HomeTelNoDspName.Visible = false;
                                this.ultraLabel_HomeTelNo.Visible = false;
                                this.uLabel_HomeFaxNoDspName.Visible = false;
                                this.ultraLabel_HomeFaxNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleOfficeTelNoFaxNo))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.uLabel_OfficeTelNoDspName.Location = new Point(this.uLabel_OfficeTelNoDspName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_OfficeTelNo.Location = new Point(this.ultraLabel_OfficeTelNo.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.uLabel_OfficeFaxNoDspName.Location = new Point(this.uLabel_OfficeFaxNoDspName.Location.X, Top_Space + 1 + defItmHeight * dispItmCount);
                                this.ultraLabel_OfficeFaxNo.Location = new Point(this.ultraLabel_OfficeFaxNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.uLabel_OfficeTelNoDspName.Visible = true;
                                this.ultraLabel_OfficeTelNo.Visible = true;
                                this.uLabel_OfficeFaxNoDspName.Visible = true;
                                this.ultraLabel_OfficeFaxNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.uLabel_OfficeTelNoDspName.Visible = false;
                                this.ultraLabel_OfficeTelNo.Visible = false;
                                this.uLabel_OfficeFaxNoDspName.Visible = false;
                                this.ultraLabel_OfficeFaxNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCellphoneNo))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.uLabel_MobileTelNoDspName.Location = new Point(this.uLabel_MobileTelNoDspName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_PortableTelNo.Location = new Point(this.ultraLabel_PortableTelNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.uLabel_MobileTelNoDspName.Visible = true;
                                this.ultraLabel_PortableTelNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.uLabel_MobileTelNoDspName.Visible = false;
                                this.ultraLabel_PortableTelNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(elePureAll))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel10.Location = new Point(this.ultraLabel10.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Pure.Location = new Point(this.ultraLabel_Pure.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel10.Visible = true;
                                this.ultraLabel_Pure.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel10.Visible = false;
                                this.ultraLabel_Pure.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(elePrimeAll))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel11.Location = new Point(this.ultraLabel11.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Excellent.Location = new Point(this.ultraLabel_Excellent.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel11.Visible = true;
                                this.ultraLabel_Excellent.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel11.Visible = false;
                                this.ultraLabel_Excellent.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleAgent))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel12.Location = new Point(this.ultraLabel12.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CustomerAgentCd.Location = new Point(this.ultraLabel_CustomerAgentCd.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CustomerAgentNm.Location = new Point(this.ultraLabel_CustomerAgentNm.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel12.Visible = true;
                                this.ultraLabel_CustomerAgentCd.Visible = true;
                                this.ultraLabel_CustomerAgentNm.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel12.Visible = false;
                                this.ultraLabel_CustomerAgentCd.Visible = false;
                                this.ultraLabel_CustomerAgentNm.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCustomerAgent))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel13.Location = new Point(this.ultraLabel13.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CustomerAgent.Location = new Point(this.ultraLabel_CustomerAgent.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel13.Visible = true;
                                this.ultraLabel_CustomerAgent.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel13.Visible = false;
                                this.ultraLabel_CustomerAgent.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleBusinessType))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel14.Location = new Point(this.ultraLabel14.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_BusinessTypeCode.Location = new Point(this.ultraLabel_BusinessTypeCode.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_BusinessTypeName.Location = new Point(this.ultraLabel_BusinessTypeName.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel14.Visible = true;
                                this.ultraLabel_BusinessTypeCode.Visible = true;
                                this.ultraLabel_BusinessTypeName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel14.Visible = false;
                                this.ultraLabel_BusinessTypeCode.Visible = false;
                                this.ultraLabel_BusinessTypeName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleArea))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel15.Location = new Point(this.ultraLabel15.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_SalesAreaCode.Location = new Point(this.ultraLabel_SalesAreaCode.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_SalesAreaName.Location = new Point(this.ultraLabel_SalesAreaName.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel15.Visible = true;
                                this.ultraLabel_SalesAreaCode.Visible = true;
                                this.ultraLabel_SalesAreaName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel15.Visible = false;
                                this.ultraLabel_SalesAreaCode.Visible = false;
                                this.ultraLabel_SalesAreaName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleAccRecDiv))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA�J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel16.Location = new Point(this.ultraLabel16.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_AccRecDivCd.Location = new Point(this.ultraLabel_AccRecDivCd.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel16.Visible = true;
                                this.ultraLabel_AccRecDivCd.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel16.Visible = false;
                                this.ultraLabel_AccRecDivCd.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCollectMoney))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA2�s���̃J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel17.Location = new Point(this.ultraLabel17.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_TotalDay.Location = new Point(this.ultraLabel_TotalDay.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel18.Location = new Point(this.ultraLabel18.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel19.Location = new Point(this.ultraLabel19.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CollectMoneyName.Location = new Point(this.ultraLabel_CollectMoneyName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel22.Location = new Point(this.ultraLabel22.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel_CollectCond.Location = new Point(this.ultraLabel_CollectCond.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel20.Location = new Point(this.ultraLabel20.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel_CollectMoneyDay.Location = new Point(this.ultraLabel_CollectMoneyDay.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel21.Location = new Point(this.ultraLabel21.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));

                                this.ultraLabel17.Visible = true;
                                this.ultraLabel_TotalDay.Visible = true;
                                this.ultraLabel18.Visible = true;
                                this.ultraLabel19.Visible = true;
                                this.ultraLabel_CollectMoneyName.Visible = true;
                                this.ultraLabel22.Visible = true;
                                this.ultraLabel_CollectCond.Visible = true;
                                this.ultraLabel20.Visible = true;
                                this.ultraLabel_CollectMoneyDay.Visible = true;
                                this.ultraLabel21.Visible = true;
                                dispItmCount = dispItmCount + 2;
                            }
                            else
                            {
                                this.ultraLabel17.Visible = false;
                                this.ultraLabel_TotalDay.Visible = false;
                                this.ultraLabel18.Visible = false;
                                this.ultraLabel19.Visible = false;
                                this.ultraLabel_CollectMoneyName.Visible = false;
                                this.ultraLabel22.Visible = false;
                                this.ultraLabel_CollectCond.Visible = false;
                                this.ultraLabel20.Visible = false;
                                this.ultraLabel_CollectMoneyDay.Visible = false;
                                this.ultraLabel21.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleMemo))
                        {
                            //�`�F�b�N�������Ă���Ε\����ON�ɂ��āA7�s���J�E���g�𑝂₷
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel73.Location = new Point(this.ultraLabel73.Location.X, Top_Space * 2 + defItmHeight * dispItmCount);
                                this.Memo_TextBox.Location = new Point(this.Memo_TextBox.Location.X, Top_Space * 2 + defItmHeight * dispItmCount);

                                this.ultraLabel73.Visible = true;
                                this.Memo_TextBox.Visible = true;
                                dispItmCount = dispItmCount + 7;
                            }
                            else
                            {
                                this.ultraLabel73.Visible = false;
                                this.Memo_TextBox.Visible = false;
                            }
                        }


                    }
                    //�\�����ڂ̐��Ǝ�ނɉ����ăE�B���h�E�T�C�Y��ύX
                    this.Size = new Size(this.Size.Width, Top_Space + dispItmCount * defItmHeight + Down_Space);
                }
            }
            else
            {
                this.Size = new Size(defaultSize_Width, defaultSize_Height);
            }
        }

        /// <summary>
        /// �t�H�[�����񊈐���ԂɕύX�C�x���g
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        private void PMKHN02830UCA_Deactivate(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, TMemPos.FormInfoData> formInfoDic = new Dictionary<string, TMemPos.FormInfoData>();
                // �E�C���h�E�Y�ʒu�����擾����
                Rectangle bounds = this.Bounds;
                // �E�C���h�E�Y��Ԃ��擾����
                FormWindowState windowsState = this.WindowState;
                switch (this.WindowState)
                {
                    case FormWindowState.Minimized:
                        bounds = this.RestoreBounds;
                        windowsState = FormWindowState.Normal;
                        break;
                    case FormWindowState.Maximized:
                        bounds = this.RestoreBounds;
                        break;
                }
                // �t�H�[�������쐬����
                formInfoDic[this.GetType().Name] = new TMemPos.FormInfoData(this.GetType().Name, bounds, windowsState);
                List<TMemPos.FormInfoData> list = new List<TMemPos.FormInfoData>(formInfoDic.Values);
                // �ʒu���t�@�C���ɕۑ�����
                UserSettingController.SerializeUserSetting(list.ToArray(), ConstantManagement_ClientDirectory.UISettings_FormPos + "\\" + Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath) + ".pos");
            }
            catch
            {
            }
        }
        // ADD 2021/04/13 ���J <<<<<<<<<<

        // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� ----->>>>>
        /// <summary>
        /// �t�H�[����KeyPress�C�x���g
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        /// <remarks>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2021/06/21</br>											
        /// <br>�Ǘ��ԍ�   : 11770021-00 ���Ӑ���K�C�h�\���̑Ή�</br>	
        /// </remarks>
        private void PMKHN02830UCA_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)KEY_ESC:
                    // ESC�����A��ʂ����
                    this.Close();
                    break;
            }
        }
        // ADD 杍^ 2021/06/21 ���Ӑ���K�C�h�\���̑Ή� -----<<<<<
    }
}