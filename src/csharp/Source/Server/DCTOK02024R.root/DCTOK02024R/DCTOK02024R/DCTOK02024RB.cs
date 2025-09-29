using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    interface ISalesSlipReport
    {
        string MakeSelectString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork cndtnWork);
        SalesDayMonthReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork);
    }

    /// <summary>
    /// TotalType����Ώۂ̏W�v�P�ʂ�񋓂��܂��B
    /// </summary>
    enum TotalType
    {
        Customer = 0,  //0:���Ӑ��
        Agent = 1,     //1:�S���ҕ�
        AcpOdr = 2,    //2:�󒍎ҕ�
        Pblsher = 3,   //3:���s�ҕ�
        Area = 4,      //4:�n���
        BzType = 5,    //5:�Ǝ��
        SaleCd = 6     //6:�̔��敪��
    };

    /// <summary>
    /// �]�ƈ��敪��񋓂��܂��B
    /// </summary>
    enum EmployeeDivCd
    {
        Agent = 10,   //10:�̔��S����
        AcpOdr = 20,  //20:��t�S����
        Pblsher = 30  //30:���͒S����
    }

    /// <summary>
    /// ���[�U�[�K�C�h�}�X�^�Q�Ɨp���[�U�[�K�C�h�敪��񋓂��܂��B
    /// </summary>
    enum UserGuideDivCd
    {
        SalesAreaCode = 21,     //�̔��G���A�敪
        BusinessTypeCode = 33,  //�Ǝ�
        SalesCode = 71          //�̔��敪
    }

    class SalesSlipReportBase
    {
        /// <summary>
        /// ����������̕\��/��\���𔻒肵�܂��B
        /// </summary>
        /// <param name="bCondition">������</param>
        /// <param name="Text">������</param>
        /// <returns></returns>
        protected string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }

        /// <summary>
        /// �W�v�P�ʂƏo�͏�����Ή�����SQL���𐶐����܂��B
        /// </summary>
        /// <param name="iTotalType">�W�v�P��</param>
        /// <param name="iOutType">�o�͏�</param>
        /// <param name="iTtlType">�W�v���@</param>
        /// <param name="sTblNm">�e�[�u��������</param>
        /// <returns></returns>
        protected string GetOutType_SQLCMD_MT(Int32 iTotalType, Int32 iOutType, Int32 iTtlType, string sTblNm)
        {
            string sRetBuf = null;

            #region [�W�v�P�ʊm�F]
            switch (iTotalType)
            {
                case (int)TotalType.Customer:  //0:���Ӑ��
                    #region [�o�͏��m�F]
                    if ((iTtlType == 1) && (iOutType != 3))
                        //sRetBuf += "," + sTblNm + ".SECTIONCODERF" + Environment.NewLine;   //���_�R�[�h // DEL 2008.12.08
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //���_�R�[�h // ADD 2008.12.08
                    if ((iOutType == 0) ||
                        (iOutType == 2) ||
                        (iOutType == 3))
                    {
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //���Ӑ�R�[�h
                    }
                    #endregion
                    break;
                case (int)TotalType.Agent:     //1:�S���ҕ�
                case (int)TotalType.AcpOdr:    //2:�󒍎ҕ�
                case (int)TotalType.Pblsher:   //3:���s�ҕ�
                    #region [�o�͏��m�F]
                    //���ʎg�p
                    sRetBuf += IFBy(iTotalType == (int)TotalType.Agent,
                               "," + sTblNm + ".SALESEMPLOYEECDRF" + Environment.NewLine);  //�̔��]�ƈ��R�[�h
                    sRetBuf += IFBy(iTotalType == (int)TotalType.AcpOdr,
                               "," + sTblNm + ".FRONTEMPLOYEECDRF" + Environment.NewLine);  //��t�]�ƈ��R�[�h
                    sRetBuf += IFBy(iTotalType == (int)TotalType.Pblsher,
                               "," + sTblNm + ".SALESINPUTCODERF" + Environment.NewLine);   //������͎҃R�[�h
                    if ((iTtlType == 1) && (iOutType != 3))
                        //sRetBuf += "," + sTblNm + ".SECTIONCODERF" + Environment.NewLine;   //���_�R�[�h // DEL 2008.12.08
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //���_�R�[�h // ADD 2008.12.08
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //���Ӑ�R�[�h
                    #endregion
                    break;
                case (int)TotalType.Area:      //4:�n���
                case (int)TotalType.BzType:    //5:�Ǝ��
                    #region [�o�͏��m�F]
                    if (iTtlType == 1)
                        //sRetBuf += "," + sTblNm + ".SECTIONCODERF" + Environment.NewLine;   //���_�R�[�h // DEL 2008.12.08
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //���_�R�[�h // ADD 2008.12.08
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //���Ӑ�R�[�h
                    #endregion
                    break;
                case (int)TotalType.SaleCd:    //6:�̔��敪��
                    //�̔��敪�ʂ̏ꍇ�͂Ȃ�
                    break;
                default:
                    break;
            }
            #endregion

            return sRetBuf;
        }
    }
}
