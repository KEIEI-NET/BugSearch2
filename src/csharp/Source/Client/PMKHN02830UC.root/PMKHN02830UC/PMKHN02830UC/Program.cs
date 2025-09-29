using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace PMKHN02830UC
{
    /// <summary>
    /// ��ʂ̋N���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ʂ��N������</br>											
    /// <br>Programmer : zhujw</br>
    /// <br>Date       : K2014/05/08</br>											
    /// <br>�Ǘ��ԍ�   : 11070071-00 �ۓ�����ʊJ���ʑΉ�</br>	
    /// </remarks>	
    static class Program
    {
        private const string BLANKALL = "b2#_%";   //�S�p�X�y�[�X
        private const string BLANKHALF = "b1#_%";  //���p�X�y�[�X
        private const string BLANKDOUBLEQUOTE = "b3#_%";  //�_�u���N�H�[�e�[�V�����}�[�N

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ���Ӑ�(�R�[�h)
            string customerCode = string.Empty;

            // ���Ӑ�(����)
            string customerSnm = string.Empty;

            // ������(�R�[�h)
            string claimCode  = string.Empty;

            // ������(����)
            string claimSnm = string.Empty;

            // �X�֔ԍ� 
            string postNo = string.Empty;

            // �Z���P
            string address1  = string.Empty;

            // �Z���Q
            string address2 = string.Empty;

            // �Z���R
            string address3 = string.Empty;

            // ����d�b
            string homeTelNo = string.Empty;

            // ����FAX
            string homeFaxNo = string.Empty;

            // �Ζ���d�b
            string officeTelNo = string.Empty;

            // �Ζ���FAX
            string officeFaxNo = string.Empty;

            // �g�ѓd�b
            string portableTelNo = string.Empty;

            // ����ALL
            string pureCustRateGrpCode = string.Empty;

            // �D��ALL
            string excellentCustRateGrpCode  = string.Empty;

            // ���Ӑ�S����
            string customerAgent = string.Empty;

            // �S����(�R�[�h)
            string customerAgentCd = string.Empty;

            // �S���Җ�
            string customerAgentNm = string.Empty;

            // �Ǝ�(�R�[�h)
            string businessTypeCode = string.Empty;
            
            // �Ǝ햼
            string businessTypeName = string.Empty;

            // �n��(�R�[�h)
            string salesAreaCode = string.Empty;

            // �n��(����)
            string salesAreaName = string.Empty;

            // ���|�敪
            string accRecDivCd = string.Empty;

            // ����
            string TotalDay = string.Empty;

            // �W����
            string collectMoneyName = string.Empty;

            // �W����
            string collectMoneyDay = string.Empty;

            // �������
            string collectCond = string.Empty;

            // ����
            string noteInfo = string.Empty;

            // ��ƃR�[�h
            string enterpriseCode = string.Empty;

            // ����d�b
            string homeTelNoDspName = string.Empty;

            // �Ζ���d�b
            string officeTelNoDspName = string.Empty;

            // �g�ѓd�b
            string mobileTelNoDspName = string.Empty;

            // ����FAX
            string homeFaxNoDspName = string.Empty;

            // �Ζ���FAX
            string officeFaxNoDspName = string.Empty;

            // PID 
            string PID = string.Empty;

            // UPD 2021/04/13 ���J >>>>>>>>>>
            // �^�C�g��No
            string titleNo = string.Empty;
            // UPD 2021/04/13 ���J <<<<<<<<<<

            if (args.Length > 0)
            {
                // ���Ӑ�(�R�[�h)
                if (!string.IsNullOrEmpty(args[0].Trim()))
                {
                    customerCode = GetNewString(args[0]);
                }
                // ���Ӑ�(����)
                if (!string.IsNullOrEmpty(args[1].Trim()))
                {
                    customerSnm = GetNewString(args[1]);
                }
                // ������(�R�[�h)
                if (!string.IsNullOrEmpty(args[2].Trim()))
                {
                    claimCode = GetNewString(args[2]);
                }

                // ������(����)
                if (!string.IsNullOrEmpty(args[3].Trim()))
                {
                    claimSnm = GetNewString(args[3]);
                }

                // �X�֔ԍ� 
                if (!string.IsNullOrEmpty(args[4].Trim()))
                {
                    postNo = GetNewString(args[4]);
                }

                // �Z���P
                if (!string.IsNullOrEmpty(args[5].Trim()))
                {
                    address1 = GetNewString(args[5]);
                }

                // �Z���Q
                if (!string.IsNullOrEmpty(args[6].Trim()))
                {
                    address2 = GetNewString(args[6]);
                }

                // �Z���R
                if (!string.IsNullOrEmpty(args[7].Trim()))
                {
                    address3 = GetNewString(args[7]);
                }

                // ����d�b
                if (!string.IsNullOrEmpty(args[8].Trim()))
                {
                    homeTelNo = GetNewString(args[8]);
                }

                // ����FAX
                if (!string.IsNullOrEmpty(args[9].Trim()))
                {
                    homeFaxNo = GetNewString(args[9]);
                }

                // �Ζ���d�b
                if (!string.IsNullOrEmpty(args[10].Trim()))
                {
                    officeTelNo = GetNewString(args[10]);
                }

                // �Ζ���FAX
                if (!string.IsNullOrEmpty(args[11].Trim()))
                {
                    officeFaxNo = GetNewString(args[11]);
                }

                // �g�ѓd�b
                if (!string.IsNullOrEmpty(args[12].Trim()))
                {
                    portableTelNo = GetNewString(args[12]);
                }

                // ����ALL
                if (!string.IsNullOrEmpty(args[13].Trim()))
                {
                    pureCustRateGrpCode = GetNewString(args[13]);
                }

                // �D��ALL
                if (!string.IsNullOrEmpty(args[14].Trim()))
                {
                    excellentCustRateGrpCode = GetNewString(args[14]);
                }

                // ���Ӑ�S����
                if (!string.IsNullOrEmpty(args[15].Trim()))
                {
                    customerAgent = GetNewString(args[15]);
                }

                // �S����(�R�[�h)
                if (!string.IsNullOrEmpty(args[16].Trim()))
                {
                    customerAgentCd = GetNewString(args[16]);
                }

                // �S���Җ�
                if (!string.IsNullOrEmpty(args[17].Trim()))
                {
                    customerAgentNm = GetNewString(args[17]);
                }

                // �Ǝ�(�R�[�h)
                if (!string.IsNullOrEmpty(args[18].Trim()))
                {
                    businessTypeCode = GetNewString(args[18]);
                }

                // �Ǝ햼
                if (!string.IsNullOrEmpty(args[19].Trim()))
                {
                    businessTypeName = GetNewString(args[19]);
                }

                // �n��(�R�[�h)
                if (!string.IsNullOrEmpty(args[20].Trim()))
                {
                    salesAreaCode = GetNewString(args[20]);
                }

                // �n��(����)
                if (!string.IsNullOrEmpty(args[21].Trim()))
                {
                    salesAreaName = GetNewString(args[21]);
                }

                // ���|�敪
                if (!string.IsNullOrEmpty(args[22].Trim()))
                {
                    accRecDivCd = GetNewString(args[22]);
                }

                // ����
                if (!string.IsNullOrEmpty(args[23].Trim()))
                {
                    TotalDay = GetNewString(args[23]);
                }

                // �W����
                if (!string.IsNullOrEmpty(args[24].Trim()))
                {
                    collectMoneyName = GetNewString(args[24]);
                }

                // �W����
                if (!string.IsNullOrEmpty(args[25].Trim()))
                {
                    collectMoneyDay = GetNewString(args[25]);
                }

                // �������
                if (!string.IsNullOrEmpty(args[26].Trim()))
                {
                    collectCond = GetNewString(args[26]);
                }

                // ����
                if (!string.IsNullOrEmpty(args[27].Trim()))
                {
                    noteInfo = GetNewString(args[27]);
                }

                // ����d�b
                if (!string.IsNullOrEmpty(args[28].Trim()))
                {
                    homeTelNoDspName = GetNewString(args[28]);
                }

                // �Ζ���d�b
                if (!string.IsNullOrEmpty(args[29].Trim()))
                {
                    officeTelNoDspName = GetNewString(args[29]);
                }

                // �g�ѓd�b
                if (!string.IsNullOrEmpty(args[30].Trim()))
                {
                    mobileTelNoDspName = GetNewString(args[30]);
                }

                // ����FAX
                if (!string.IsNullOrEmpty(args[31].Trim()))
                {
                    homeFaxNoDspName = GetNewString(args[31]);
                }

                // �Ζ���FAX
                if (!string.IsNullOrEmpty(args[32].Trim()))
                {
                    officeFaxNoDspName = GetNewString(args[32]);
                }

                // PID
                if (!string.IsNullOrEmpty(args[33].Trim()))
                {
                    PID = GetNewString(args[33]);
                }

                // UPD 2021/04/13 ���J >>>>>>>>>>
                // �^�C�g��No
                if (!string.IsNullOrEmpty(args[34].Trim()))
                {
                    titleNo = GetNewString(args[34]);
                }
                // UPD 2021/04/13 ���J <<<<<<<<<<

            }

            // UPD 2021/04/13 ���J >>>>>>>>>>
            //Application.Run(new PMKHN02830UCA(customerCode, customerSnm, claimCode,
            // claimSnm, postNo, address1, address2,
            // address3, homeTelNo, officeTelNo, portableTelNo,
            // homeFaxNo, officeFaxNo, pureCustRateGrpCode, excellentCustRateGrpCode,
            // customerAgent, customerAgentCd, customerAgentNm, businessTypeCode,
            // businessTypeName, salesAreaCode, salesAreaName,
            // accRecDivCd, TotalDay, collectMoneyName, collectMoneyDay,
            // collectCond, noteInfo, homeTelNoDspName, officeTelNoDspName, mobileTelNoDspName, homeFaxNoDspName, officeFaxNoDspName,PID));
            Application.Run(new PMKHN02830UCA(customerCode,  customerSnm,  claimCode, 
             claimSnm,  postNo, address1,  address2,
             address3, homeTelNo, officeTelNo, portableTelNo,
             homeFaxNo,  officeFaxNo,  pureCustRateGrpCode,  excellentCustRateGrpCode,
             customerAgent, customerAgentCd, customerAgentNm, businessTypeCode,
             businessTypeName, salesAreaCode, salesAreaName,
             accRecDivCd, TotalDay, collectMoneyName, collectMoneyDay,
             collectCond, noteInfo, homeTelNoDspName, officeTelNoDspName, mobileTelNoDspName, homeFaxNoDspName, officeFaxNoDspName, PID, titleNo));
            // UPD 2021/04/13 ���J <<<<<<<<<<
        }

        static string GetNewString(string stringValue)
        {
            string Info = string.Empty;
            string Info2 = string.Empty;
            string info3 = string.Empty;
            Info = stringValue.Replace(BLANKHALF, " ");
            Info2 = Info.Replace(BLANKALL, "�@");
            info3 = Info2.Replace(BLANKDOUBLEQUOTE, "\"");
            return info3;
        }
    }
}