using System;
using System.Collections;
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
    class CustPrtPprBlDspRsltQuery : ICustPrtPpr
    {
        #region [CustPrtPprBlDspRsltWork�p SELECT��]
        /// <summary>
        /// �c���Ɖ�̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="iParam"></param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�c���Ɖ�̃��X�g���oSELECT��</returns>
        /// <br>Note       : �c���Ɖ�̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, ConstantManagement.LogicalMode logicalMode)
        {
            CustPrtPprWork _custPrtPprWork = paramWork as CustPrtPprWork;
            return this.MakeSelectStringProc(ref sqlCommand, _custPrtPprWork, logicalMode);
        }
        #endregion  //[CustPrtPprBlDspRsltWork�p SELECT��]

        #region [CustPrtPprBlDspRsltWork�p SELECT����������]
        /// <summary>
        /// �c���Ɖ�̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�c���Ɖ�̃��X�g���oSELECT��</returns>
        /// <br>Note       : �c���Ɖ�̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // CUSTDMDPRCRF  CTDMD  ���Ӑ搿�����z�}�X�^

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  CTDMD.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
            selectTxt += " ,CTDMD.LASTTIMEDEMANDRF" + Environment.NewLine;
            selectTxt += " ,CTDMD.AFCALDEMANDPRICERF" + Environment.NewLine;
            selectTxt += " ,CTDMD.ADDUPYEARMONTHRF" + Environment.NewLine;
            selectTxt += " ,CTDMD.CONSTAXLAYMETHODRF" + Environment.NewLine;
            // -- UPD 2010/06/09 ---------------------------------------->>>
            //selectTxt += " FROM CUSTDMDPRCRF AS CTDMD" + Environment.NewLine;
            selectTxt += " FROM CUSTDMDPRCRF AS CTDMD WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 ----------------------------------------<<<

            //WHERE���̍쐬
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, logicalMode);
            #endregion

            return selectTxt;
        }
        #endregion  //[CustPrtPprBlDspRsltWork�p SELECT����������]

        #region [CustPrtPprBlDspRsltWork�p WHERE����������]
        /// <summary>
        /// �c���Ɖ�̃��X�g���o�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�c���Ɖ�̃��X�g���o�pWHERE��</returns>
        /// <br>Note       : �c���Ɖ�̃��X�g���o�pWHERE�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " CTDMD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND CTDMD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND CTDMD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (paramWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND CTDMD.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���Ӑ�R�[�h
            if (paramWork.CustomerCode != 0)
            {
                retstring += " AND CTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
            }

            //������R�[�h
            if (paramWork.ClaimCode != 0)
            {
                retstring += " AND CTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(paramWork.ClaimCode);
            }

            //�v��N��
            if (paramWork.AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND CTDMD.ADDUPYEARMONTHRF>=@ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonth);
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprBlDspRsltWork�p WHERE����������]

        #region [CustPrtPprBlDspRsltWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustPrtPprBlDspRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprWork</param>
        /// <param name="iParam"></param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam)
        {
            CustPrtPprWork _custPrtPprWork = paramWork as CustPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader, _custPrtPprWork);
        }
        #endregion  //[CustPrtPprBlDspRsltWork���� �ďo]

        #region [CustPrtPprBlDspRsltWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuppPrtPprBlDspRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprWork</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        private CustPrtPprBlDspRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CustPrtPprWork paramWork)
        {
            #region ���o����-�l�Z�b�g
            CustPrtPprBlDspRsltWork resultWork = new CustPrtPprBlDspRsltWork();

            resultWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            resultWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            resultWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            resultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            #endregion

            return resultWork;
        }
        #endregion  //[CustPrtPprBlDspRsltWork����]
    }
}
