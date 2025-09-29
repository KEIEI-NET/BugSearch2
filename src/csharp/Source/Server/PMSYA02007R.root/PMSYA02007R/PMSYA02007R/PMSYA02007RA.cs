//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���q�ʏo�׎��ѕ\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�ʏo�׎��ѕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.09.15</br>
    /// </remarks>
    [Serializable]
    public class CarShipResultDB : RemoteDB, ICarShipResultDB
    {
        /// <summary>
        /// ���q�ʏo�׎��ѕ\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public CarShipResultDB()
            :
        base("PMSYA02009D", "Broadleaf.Application.Remoting.ParamData.CarShipResultWork", "CARSHIPRESULTWORK") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��q�ʏo�׎��ѕ\��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="carShipResultWork">��������</param>
        /// <param name="carShipRsltCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��q�ʏo�׃f�[�^��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        public int Search(out object carShipResultWork, object carShipRsltCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            carShipResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                return SearchProc(out carShipResultWork, carShipRsltCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CarShipResultDB.Search");
                carShipResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎��q�ʏo�׎��ѕ\��S�Ė߂��܂�
        /// </summary>
        /// <param name="carShipResultWork">��������</param>
        /// <param name="_carShipRsltCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        private int SearchProc(out object carShipResultWork, object _carShipRsltCndtnWork, ref SqlConnection sqlConnection)
        {
            CarShipRsltCndtnWork carShipRsltCndtnWork = _carShipRsltCndtnWork as CarShipRsltCndtnWork;
            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            carShipResultWork = new ArrayList();
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" SALESSLIPNUMRF, ");
                sb.Append(" RESULTSADDUPSECCDRF, ");
                sb.Append(" SALESDATERF, ");
                sb.Append(" CUSTOMERCODERF, ");
                sb.Append(" CUSTOMERSNMRF, ");
                sb.Append(" SALESROWNORF, ");
                sb.Append(" GOODSMAKERCDRF, ");
                sb.Append(" GOODSNORF, ");
                sb.Append(" GOODSNAMEKANARF, ");
                sb.Append(" BLGOODSCODERF, ");
                sb.Append(" BLGOODSHALFNAMERF, ");
                sb.Append(" BLGROUPCODERF, ");
                sb.Append(" BLGROUPKANANAMERF, ");
                sb.Append(" LISTPRICETAXEXCFLRF, ");
                sb.Append(" SALESUNPRCTAXEXCFLRF, ");
                sb.Append(" SALESUNITCOSTRF, ");
                sb.Append(" SHIPMENTCNTRF, ");
                sb.Append(" SHIPMENTCNTINRF, ");
                sb.Append(" SHIPMENTCNTNOTINRF, ");
                sb.Append(" SALESORDERDIVCDRF, ");
                sb.Append(" SALESMONEYTAXEXCRF, ");
                sb.Append(" SECTIONGUIDESNMRF, ");
                sb.Append(" GROSSPROFITRF, ");
                sb.Append(" CARMNGNORF, ");
                sb.Append(" CARMNGCODERF, ");
                sb.Append(" NUMBERPLATE1NAMERF, ");
                sb.Append(" NUMBERPLATE2RF, ");
                sb.Append(" NUMBERPLATE3RF, ");
                sb.Append(" NUMBERPLATE4RF, ");
                sb.Append(" FIRSTENTRYDATERF, ");
                sb.Append(" MAKERCODERF, ");
                sb.Append(" MODELCODERF, ");
                sb.Append(" MODELSUBCODERF, ");
                sb.Append(" MODELHALFNAMERF, ");
                sb.Append(" FULLMODELRF, ");
                sb.Append(" MILEAGERF ");
                sb.Append(" FROM ( ");

                sb.Append("SELECT ");
                sb.Append("  A_1.ENTERPRISECODERF, ");
                sb.Append("  A_1.SALESSLIPNUMRF, ");
                sb.Append("  A_1.RESULTSADDUPSECCDRF, ");
                sb.Append("  A_1.SALESDATERF, ");
                sb.Append("  A_1.CUSTOMERCODERF, ");
                sb.Append("  A_1.SALESROWNORF, ");
                sb.Append("  A_1.GOODSMAKERCDRF, ");
                sb.Append("  A_1.GOODSNORF, ");
                sb.Append("  A_1.GOODSNAMEKANARF, ");
                sb.Append("  A_1.BLGOODSCODERF, ");
                sb.Append("  A_1.BLGROUPCODERF, ");
                sb.Append("  A_1.LISTPRICETAXEXCFLRF, ");
                sb.Append("  A_1.SALESUNPRCTAXEXCFLRF, ");
                sb.Append("  A_1.SALESUNITCOSTRF, ");
                sb.Append("  A_1.SHIPMENTCNTRF , ");
                sb.Append("  A_1.SHIPMENTCNTINRF, ");
                sb.Append("  A_1.SHIPMENTCNTNOTINRF, ");
                sb.Append("  A_1.SALESORDERDIVCDRF, ");
                sb.Append("  A_1.SALESMONEYTAXEXCRF, ");
                sb.Append("  A_1.ACCEPTANORDERNORF, ");
                sb.Append("  A_1.GROSSPROFITRF, ");
                sb.Append("  A_1.CARMNGNORF, ");
                sb.Append("  A_1.CARMNGCODERF, ");
                sb.Append("  A_1.NUMBERPLATE1NAMERF, ");
                sb.Append("  A_1.NUMBERPLATE2RF, ");
                sb.Append("  A_1.NUMBERPLATE3RF, ");
                sb.Append("  A_1.NUMBERPLATE4RF, ");
                sb.Append("  A_1.FIRSTENTRYDATERF, ");
                sb.Append("  A_1.MAKERCODERF, ");
                sb.Append("  A_1.MODELCODERF, ");
                sb.Append("  A_1.MODELSUBCODERF, ");
                sb.Append("  A_1.MODELHALFNAMERF, ");
                sb.Append("  A_1.FULLMODELRF, ");
                sb.Append("  A_1.MILEAGERF, ");

                sb.Append(" D.CUSTOMERSNMRF, E.BLGOODSHALFNAMERF,F.BLGROUPKANANAMERF,G.SECTIONGUIDESNMRF FROM (");
                sb.Append(" SELECT ");
                sb.Append("  AA.ENTERPRISECODERF,AA.SALESSLIPNUMRF, ");
                sb.Append("  AA.RESULTSADDUPSECCDRF, ");
                sb.Append("  AA.SALESDATERF, ");
                sb.Append("  AA.CUSTOMERCODERF, ");
                sb.Append("  AB.SALESROWNORF, ");
                sb.Append("  AB.GOODSMAKERCDRF, ");
                sb.Append("  AB.GOODSNORF, ");
                sb.Append("  AB.GOODSNAMEKANARF, ");
                sb.Append("  AB.BLGOODSCODERF, ");
                sb.Append("  AB.BLGROUPCODERF, ");
                sb.Append("  AB.LISTPRICETAXEXCFLRF, ");
                sb.Append("  AB.SALESUNPRCTAXEXCFLRF, ");
                sb.Append("  AB.SALESUNITCOSTRF, ");
                sb.Append("  AB.SHIPMENTCNTRF , ");
                sb.Append("  AB.SHIPMENTCNTINRF, ");
                sb.Append("  AB.SHIPMENTCNTNOTINRF, ");
                sb.Append("  AB.SALESORDERDIVCDRF, ");
                sb.Append("  AB.SALESMONEYTAXEXCRF, ");
                sb.Append("  AB.ACCEPTANORDERNORF, ");
                sb.Append("  AB.GROSSPROFITRF, ");
                sb.Append("  AC.CARMNGNORF, ");
                sb.Append("  AC.CARMNGCODERF, ");
                sb.Append("  AC.NUMBERPLATE1NAMERF, ");
                sb.Append("  AC.NUMBERPLATE2RF, ");
                sb.Append("  AC.NUMBERPLATE3RF, ");
                sb.Append("  AC.NUMBERPLATE4RF, ");
                sb.Append("  AC.FIRSTENTRYDATERF, ");
                sb.Append("  AC.MAKERCODERF, ");
                sb.Append("  AC.MODELCODERF, ");
                sb.Append("  AC.MODELSUBCODERF, ");
                sb.Append("  AC.MODELHALFNAMERF, ");
                sb.Append("  AC.FULLMODELRF, ");
                sb.Append("  AC.MILEAGERF ");

                sb.Append("  FROM( ");

                sb.Append("  SELECT ");
                sb.Append("  A.SALESSLIPCDDTLRF,A.LOGICALDELETECODERF, A.SALESROWNORF, ");
                sb.Append("  A.GOODSMAKERCDRF, ");
                sb.Append("  A.ACCEPTANORDERNORF, ");
                sb.Append("  A.GOODSNORF, ");
                sb.Append("  A.GOODSNAMEKANARF, ");
                sb.Append("  A.BLGOODSCODERF, ");
                sb.Append("  A.BLGROUPCODERF, ");
                sb.Append("  A.LISTPRICETAXEXCFLRF, ");
                sb.Append("  A.SALESUNPRCTAXEXCFLRF, ");
                sb.Append("  A.SALESUNITCOSTRF, ");
                sb.Append("  A.SALESMONEYTAXEXCRF, ");
                sb.Append("  A.ENTERPRISECODERF,A.ACPTANODRSTATUSRF,A.SALESSLIPNUMRF,");
                sb.Append("  A.SHIPMENTCNTRF, ");
                sb.Append("  B.SHIPMENTCNTRF AS SHIPMENTCNTINRF, ");
                sb.Append("  C.SHIPMENTCNTRF AS SHIPMENTCNTNOTINRF, ");
                sb.Append("  A.SALESORDERDIVCDRF, ");
                sb.Append("  (A.SALESMONEYTAXEXCRF-A.COSTRF) AS GROSSPROFITRF");
                sb.Append("  FROM ");
                sb.Append("  SALESHISTDTLRF A WITH (READUNCOMMITTED)");
                sb.Append("  LEFT JOIN ");
                sb.Append("  SALESHISTDTLRF B WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF  ");
                sb.Append("  AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF   ");
                sb.Append("  AND A.SALESSLIPDTLNUMRF =  B.SALESSLIPDTLNUMRF  ");
                sb.Append("  AND B.SALESORDERDIVCDRF =  1  ");
                sb.Append("  LEFT JOIN  ");
                sb.Append("  SALESHISTDTLRF C WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF =  C.ENTERPRISECODERF  ");
                sb.Append("   AND A.ACPTANODRSTATUSRF = C.ACPTANODRSTATUSRF   ");
                sb.Append("   AND A.SALESSLIPDTLNUMRF =  C.SALESSLIPDTLNUMRF  ");
                sb.Append("   AND C.SALESORDERDIVCDRF =  0  ");
                sb.Append("  ) AB  ,SALESHISTORYRF AA, ACCEPTODRCARRF AC");

                sb.Append(MakeWhereStringA(ref sqlCommand, carShipRsltCndtnWork));

                sb.Append("  ) A_1  ");
                sb.Append(" LEFT JOIN CUSTOMERRF D WITH (READUNCOMMITTED)");
                sb.Append(" ON A_1.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                sb.Append(" AND A_1.CUSTOMERCODERF =  D.CUSTOMERCODERF ");
                sb.Append(" AND D.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN BLGOODSCDURF E WITH (READUNCOMMITTED)");
                sb.Append(" ON A_1.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                sb.Append(" AND A_1.BLGOODSCODERF =  E.BLGOODSCODERF ");
                sb.Append(" AND E.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN BLGROUPURF F WITH (READUNCOMMITTED)");
                sb.Append(" ON A_1.ENTERPRISECODERF =  F.ENTERPRISECODERF ");
                sb.Append(" AND A_1.BLGROUPCODERF =  F.BLGROUPCODERF ");
                sb.Append(" AND F.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SECINFOSETRF G WITH (READUNCOMMITTED)");
                sb.Append(" ON A_1.ENTERPRISECODERF =  G.ENTERPRISECODERF ");
                sb.Append(" AND A_1.RESULTSADDUPSECCDRF =  G.SECTIONCODERF ");
                sb.Append(" AND G.LOGICALDELETECODERF = 0 ");

                sb.Append(" UNION ");
                sb.Append(" SELECT ");
                sb.Append("  B_1.ENTERPRISECODERF, ");
                sb.Append("  B_1.SALESSLIPNUMRF, ");
                sb.Append("  B_1.RESULTSADDUPSECCDRF, ");
                sb.Append("  B_1.SALESDATERF, ");
                sb.Append("  B_1.CUSTOMERCODERF, ");
                sb.Append("  B_1.SALESROWNORF, ");
                sb.Append("  B_1.GOODSMAKERCDRF, ");
                sb.Append("  B_1.GOODSNORF, ");
                sb.Append("  B_1.GOODSNAMEKANARF, ");
                sb.Append("  B_1.BLGOODSCODERF, ");
                sb.Append("  B_1.BLGROUPCODERF, ");
                sb.Append("  B_1.LISTPRICETAXEXCFLRF, ");
                sb.Append("  B_1.SALESUNPRCTAXEXCFLRF, ");
                sb.Append("  B_1.SALESUNITCOSTRF, ");
                sb.Append("  B_1.SHIPMENTCNTRF, ");
                sb.Append("  B_1.SHIPMENTCNTINRF, ");
                sb.Append("  B_1.SHIPMENTCNTNOTINRF, ");
                sb.Append("  B_1.SALESORDERDIVCDRF, ");
                sb.Append("  B_1.SALESMONEYTAXEXCRF, ");
                sb.Append("  B_1.ACCEPTANORDERNORF, ");
                sb.Append("  B_1.GROSSPROFITRF, ");
                sb.Append("  B_1.CARMNGNORF, ");
                sb.Append("  B_1.CARMNGCODERF, ");
                sb.Append("  B_1.NUMBERPLATE1NAMERF, ");
                sb.Append("  B_1.NUMBERPLATE2RF, ");
                sb.Append("  B_1.NUMBERPLATE3RF, ");
                sb.Append("  B_1.NUMBERPLATE4RF, ");
                sb.Append("  B_1.FIRSTENTRYDATERF, ");
                sb.Append("  B_1.MAKERCODERF, ");
                sb.Append("  B_1.MODELCODERF, ");
                sb.Append("  B_1.MODELSUBCODERF, ");
                sb.Append("  B_1.MODELHALFNAMERF, ");
                sb.Append("  B_1.FULLMODELRF, ");
                sb.Append("  B_1.MILEAGERF, ");

                sb.Append(" D1.CUSTOMERSNMRF, E1.BLGOODSHALFNAMERF,F1.BLGROUPKANANAMERF,G1.SECTIONGUIDESNMRF FROM (");
                sb.Append(" SELECT ");
                sb.Append("  BA.ENTERPRISECODERF, ");
                sb.Append("  BA.SALESSLIPNUMRF, ");
                sb.Append("  BA.RESULTSADDUPSECCDRF, ");
                sb.Append("  BA.SALESDATERF, ");
                sb.Append("  BA.CUSTOMERCODERF, ");
                sb.Append("  BA.SALESROWNORF, ");
                sb.Append("  BA.GOODSMAKERCDRF, ");
                sb.Append("  BA.GOODSNORF, ");
                sb.Append("  BA.GOODSNAMEKANARF, ");
                sb.Append("  BA.BLGOODSCODERF, ");
                sb.Append("  BA.BLGROUPCODERF, ");
                sb.Append("  BA.LISTPRICETAXEXCFLRF, ");
                sb.Append("  BA.SALESUNPRCTAXEXCFLRF, ");
                sb.Append("  BA.SALESUNITCOSTRF, ");
                sb.Append("  BA.SHIPMENTCNTRF, ");
                sb.Append("  BA.SHIPMENTCNTINRF, ");
                sb.Append("  BA.SHIPMENTCNTNOTINRF, ");
                sb.Append("  BA.SALESORDERDIVCDRF, ");
                sb.Append("  BA.SALESMONEYTAXEXCRF, ");
                sb.Append("  BA.ACCEPTANORDERNORF, ");
                sb.Append("  BA.GROSSPROFITRF, ");
                sb.Append("  BB.CARMNGNORF, ");
                sb.Append("  BB.CARMNGCODERF, ");
                sb.Append("  BB.NUMBERPLATE1NAMERF, ");
                sb.Append("  BB.NUMBERPLATE2RF, ");
                sb.Append("  BB.NUMBERPLATE3RF, ");
                sb.Append("  BB.NUMBERPLATE4RF, ");
                sb.Append("  BB.FIRSTENTRYDATERF, ");
                sb.Append("  BB.MAKERCODERF, ");
                sb.Append("  BB.MODELCODERF, ");
                sb.Append("  BB.MODELSUBCODERF, ");
                sb.Append("  BB.MODELHALFNAMERF, ");
                sb.Append("  BB.FULLMODELRF, ");
                sb.Append("  BB.MILEAGERF ");

                sb.Append(" FROM ");
                sb.Append(" ( ");
                sb.Append(" SELECT ");
                sb.Append("  Bq.ENTERPRISECODERF,Bq.ACCEPTANORDERNORF,");
                sb.Append("  Bq.ACPTANODRSTATUSRF,Bq.LOGICALDELETECODERF, ");
                sb.Append("  Bq.SALESMONEYTAXEXCRF, ");
                sb.Append("  Bq.GROSSPROFITRF, ");
                sb.Append("  Bq.SALESSLIPNUMRF, ");
                sb.Append("  Bq.RESULTSADDUPSECCDRF, ");
                sb.Append("  Bq.SALESDATERF, ");
                sb.Append("  Bq.CUSTOMERCODERF, ");
                sb.Append("  Bq.SALESROWNORF, ");
                sb.Append("  Bq.GOODSMAKERCDRF, ");
                sb.Append("  Bq.GOODSNORF, ");
                sb.Append("  Bq.GOODSNAMERF as GOODSNAMEKANARF, ");
                sb.Append("  Bq.BLGOODSCODERF, ");
                sb.Append("  Bq.BLGROUPCODERF, ");
                sb.Append("  Bq.LISTPRICETAXEXCFLRF, ");
                sb.Append("  Bq.SALESUNPRCTAXEXCFLRF, ");
                sb.Append("  Bq.SALESUNITCOSTRF, ");
                sb.Append("  Bq.SHIPMENTCNTRF AS SHIPMENTCNTRF, ");
                sb.Append("  Bq1.SHIPMENTCNTRF AS SHIPMENTCNTINRF, ");
                sb.Append("  Bq2.SHIPMENTCNTRF AS SHIPMENTCNTNOTINRF, ");
                sb.Append("  Bq.SALESORDERDIVCDRF ");
                sb.Append(" FROM CNVCARPARTSRF Bq WITH (READUNCOMMITTED)");
                sb.Append(" LEFT JOIN CNVCARPARTSRF Bq1 WITH (READUNCOMMITTED)");
                sb.Append("  ON Bq1.ENTERPRISECODERF = Bq.ENTERPRISECODERF   ");
                sb.Append("  AND Bq1.SALESSLIPDTLNUMRF =  Bq.SALESSLIPDTLNUMRF  ");
                sb.Append("  AND Bq1.SALESORDERDIVCDRF =  1  ");
                sb.Append(" LEFT JOIN CNVCARPARTSRF Bq2 WITH (READUNCOMMITTED)");
                sb.Append("  ON Bq2.ENTERPRISECODERF = Bq.ENTERPRISECODERF   ");
                sb.Append("  AND Bq2.SALESSLIPDTLNUMRF =  Bq.SALESSLIPDTLNUMRF  ");
                sb.Append("  AND Bq2.SALESORDERDIVCDRF =  0  ");
                sb.Append(" ) BA,ACCEPTODRCARRF BB");

                sb.Append(MakeWhereStringB(ref sqlCommand, carShipRsltCndtnWork));

                sb.Append("  ) B_1  ");

                sb.Append(" LEFT JOIN CUSTOMERRF D1 WITH (READUNCOMMITTED)");
                sb.Append(" ON B_1.ENTERPRISECODERF =  D1.ENTERPRISECODERF ");
                sb.Append(" AND B_1.CUSTOMERCODERF =  D1.CUSTOMERCODERF ");
                sb.Append(" AND D1.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN BLGOODSCDURF E1 WITH (READUNCOMMITTED)");
                sb.Append(" ON B_1.ENTERPRISECODERF =  E1.ENTERPRISECODERF ");
                sb.Append(" AND B_1.BLGOODSCODERF =  E1.BLGOODSCODERF ");
                sb.Append(" AND E1.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN BLGROUPURF F1 WITH (READUNCOMMITTED)");
                sb.Append(" ON B_1.ENTERPRISECODERF =  F1.ENTERPRISECODERF ");
                sb.Append(" AND B_1.BLGROUPCODERF =  F1.BLGROUPCODERF ");
                sb.Append(" AND F1.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SECINFOSETRF G1 WITH (READUNCOMMITTED)");
                sb.Append(" ON B_1.ENTERPRISECODERF =  G1.ENTERPRISECODERF ");
                sb.Append(" AND B_1.RESULTSADDUPSECCDRF =  G1.SECTIONCODERF ");
                sb.Append(" AND G1.LOGICALDELETECODERF = 0 ");

                sb.Append(" ) TABLE_A ");

                // ��ʂ̏W�v���@���u���ѕ\�v��I���̏ꍇ
                if (carShipRsltCndtnWork.GroupBySectionDiv == 0)
                {
                    // ���גP�ʂ��u�i�ԁv��I���̏ꍇ
                    if (carShipRsltCndtnWork.DetailDataValue == 0)
                    {
                        sb.Append(" ORDER BY ");
                        sb.Append(" RESULTSADDUPSECCDRF, ");
                        sb.Append(" CUSTOMERCODERF, ");
                        sb.Append(" CARMNGCODERF, ");
                        sb.Append(" CARMNGNORF, ");
                        sb.Append(" BLGROUPCODERF, ");
                        sb.Append(" BLGOODSCODERF, ");
                        sb.Append(" GOODSNORF, ");
                        sb.Append(" GOODSMAKERCDRF ");
                    }
                    // ���גP�ʂ��u�a�k�R�[�h�v��I���̏ꍇ
                    else if (carShipRsltCndtnWork.DetailDataValue == 1)
                    {
                        sb.Append(" ORDER BY ");
                        sb.Append(" RESULTSADDUPSECCDRF, ");
                        sb.Append(" CUSTOMERCODERF, ");
                        sb.Append(" CARMNGCODERF, ");
                        sb.Append(" CARMNGNORF, ");
                        sb.Append(" BLGROUPCODERF, ");
                        sb.Append(" BLGOODSCODERF ");
                    }
                    // ���גP�ʂ��u�O���[�v�R�[�h�v��I���̏ꍇ
                    else if (carShipRsltCndtnWork.DetailDataValue == 2)
                    {
                        sb.Append(" ORDER BY ");
                        sb.Append(" RESULTSADDUPSECCDRF, ");
                        sb.Append(" CUSTOMERCODERF, ");
                        sb.Append(" CARMNGCODERF, ");
                        sb.Append(" CARMNGNORF, ");
                        sb.Append(" BLGROUPCODERF ");
                    }

                }
                // ��ʂ̏W�v���@���u���X�g�v��I���̏ꍇ
                else if (carShipRsltCndtnWork.GroupBySectionDiv == 1)
                {
                    sb.Append(" ORDER BY ");
                    sb.Append(" RESULTSADDUPSECCDRF, ");
                    sb.Append(" CUSTOMERCODERF, ");
                    sb.Append(" CARMNGCODERF, ");
                    sb.Append(" CARMNGNORF, ");
                    sb.Append(" SALESDATERF, ");
                    sb.Append(" SALESSLIPNUMRF, ");
                    sb.Append(" SALESROWNORF ");
                }

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    CarShipResultWork wkCarShipResultWork = new CarShipResultWork();
                    
                    //�d���f�[�^���ʎ擾���e�i�[
                    wkCarShipResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkCarShipResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkCarShipResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkCarShipResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkCarShipResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkCarShipResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkCarShipResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkCarShipResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkCarShipResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkCarShipResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkCarShipResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    wkCarShipResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkCarShipResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
                    wkCarShipResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkCarShipResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkCarShipResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkCarShipResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkCarShipResultWork.ShipmentCntIn = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTINRF"));
                    wkCarShipResultWork.ShipmentCntNotIn = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTNOTINRF"));
                    wkCarShipResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    wkCarShipResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkCarShipResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkCarShipResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                    wkCarShipResultWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    wkCarShipResultWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                    wkCarShipResultWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                    wkCarShipResultWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                    wkCarShipResultWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                    wkCarShipResultWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                    wkCarShipResultWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                    wkCarShipResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    wkCarShipResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    wkCarShipResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    wkCarShipResultWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    wkCarShipResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    wkCarShipResultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
                    #endregion

                    al.Add(wkCarShipResultWork);
                }
                if (al.Count < 1)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
            }

            carShipResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_carShipRsltCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private string MakeWhereStringA(ref SqlCommand sqlCommand, CarShipRsltCndtnWork _carShipRsltCndtnWork )
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            // ���㗚���f�[�^.��ƃR�[�h �� ���㗚�𖾍׃f�[�^.��ƃR�[�h
            retstring += " AA.ENTERPRISECODERF=AB.ENTERPRISECODERF";

            // ���㗚���f�[�^.�󒍃X�e�[�^�X �� ���㗚�𖾍׃f�[�^.�󒍃X�e�[�^�X
            retstring += " AND AA.ACPTANODRSTATUSRF=AB.ACPTANODRSTATUSRF";

            // ���㗚���f�[�^.����`�[�ԍ� �� ���㗚�𖾍׃f�[�^.����`�[�ԍ�
            retstring += " AND AA.SALESSLIPNUMRF=AB.SALESSLIPNUMRF";

            // ���㗚�𖾍׃f�[�^.��ƃR�[�h �� �󒍃}�X�^(���q).��ƃR�[�h
            retstring += " AND AB.ENTERPRISECODERF=AC.ENTERPRISECODERF";

            // �󒍃}�X�^(���q).�󒍃X�e�[�^�X =7,8
            retstring += " AND ( AC.ACPTANODRSTATUSRF = 7 OR  AC.ACPTANODRSTATUSRF = 8)";
            
            // ���㗚�𖾍׃f�[�^.�󒍔ԍ� �� �󒍃}�X�^(���q).�󒍔ԍ�
            retstring += " AND AB.ACCEPTANORDERNORF=AC.ACCEPTANORDERNORF";

            // ���㗚���f�[�^.��ƃR�[�h�����O�C���S���҂̊�ƃR�[�h
            retstring += " AND AA.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.EnterpriseCode);

            retstring += " AND AA.LOGICALDELETECODERF = 0 ";
            retstring += " AND AA.ACPTANODRSTATUSRF = 30 ";

            //���_�R�[�h
            if (_carShipRsltCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _carShipRsltCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND AA.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // ���㗚���f�[�^.������t																																	
            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.SalesDateSt))
            {
                retstring += "AND AA.SALESDATERF>=@ST_SALESDAY ";
                SqlParameter Para_St_salesDate = sqlCommand.Parameters.Add("@ST_SALESDAY", SqlDbType.Int);
                Para_St_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.SalesDateSt);
            }

            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.SalesDateEd))
            {
                retstring += "AND AA.SALESDATERF<=@ED_SALESDAY ";
                SqlParameter Para_Ed_salesDate = sqlCommand.Parameters.Add("@ED_SALESDAY", SqlDbType.Int);
                Para_Ed_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.SalesDateEd);
            }

            // ���㗚���f�[�^.�`�[�������t
            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.InputDateSt))
            {
                retstring += "AND AA.SEARCHSLIPDATERF>=@ST_SECHSDAY ";
                SqlParameter Para_St_sechDate = sqlCommand.Parameters.Add("@ST_SECHSDAY", SqlDbType.Int);
                Para_St_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.InputDateSt);
            }

            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.InputDateEd))
            {
                retstring += "AND AA.SEARCHSLIPDATERF<=@ED_SECHSDAY ";
                SqlParameter Para_Ed_sechDate = sqlCommand.Parameters.Add("@ED_SECHSDAY", SqlDbType.Int);
                Para_Ed_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.InputDateEd);
            }

            // ���㗚���f�[�^.���Ӑ�R�[�h
            if (0 != _carShipRsltCndtnWork.CustomerCodeSt)
            {
                retstring += " AND AA.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                SqlParameter Para_St_customerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                Para_St_customerCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.CustomerCodeSt);
            }

            if (0 != _carShipRsltCndtnWork.CustomerCodeEd)
            {
                retstring += " AND AA.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                SqlParameter Para_Ed_customerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                Para_Ed_customerCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.CustomerCodeEd);
            }

            // �󒍃}�X�^(���q).�_���폜�敪 �� �u0�F�L���v
            retstring += " AND AC.LOGICALDELETECODERF = 0 ";

            // �󒍃}�X�^(���q).���q�Ǘ��R�[�h
            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.CarMngCodeSt))
            {
                retstring += " AND AC.CARMNGCODERF>=@ST_CARMNGCODE ";
                SqlParameter Para_St_carmngCode = sqlCommand.Parameters.Add("@ST_CARMNGCODE", SqlDbType.NChar);
                Para_St_carmngCode.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.CarMngCodeSt);
            }

            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.CarMngCodeEd))
            {
                retstring += " AND AC.CARMNGCODERF<=@ED_CARMNGCODE ";
                SqlParameter Para_Ed_carmngCode = sqlCommand.Parameters.Add("@ED_CARMNGCODE", SqlDbType.NChar);
                Para_Ed_carmngCode.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.CarMngCodeEd);
            }

            // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� ��	 0
            retstring += " AND AC.CARMNGNORF <> 0 ";

            // �󒍃}�X�^(���q).���q���l
            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.SlipNoteCar))
            {
                // 0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���
                if (_carShipRsltCndtnWork.CarOutDiv == 0)
                {
                    retstring += " AND AC.CARNOTERF=@CARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.SlipNoteCar);
                }
                else if(_carShipRsltCndtnWork.CarOutDiv == 1)
                {
                    retstring += " AND AC.CARNOTERF LIKE @CARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.SlipNoteCar+"%");
                }
                else if(_carShipRsltCndtnWork.CarOutDiv == 2)
                {
                    retstring += " AND AC.CARNOTERF LIKE @CARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString("%" + _carShipRsltCndtnWork.SlipNoteCar + "%");
                }
                else if (_carShipRsltCndtnWork.CarOutDiv == 3)
                {
                    retstring += " AND AC.CARNOTERF LIKE @CARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString("%" + _carShipRsltCndtnWork.SlipNoteCar);
                }

            }

            // ���㗚�𖾍׃f�[�^.�_���폜�敪 �� �u0�F�L���v
            retstring += " AND AB.LOGICALDELETECODERF = 0 ";

            // ���㗚�𖾍׃f�[�^.����`�[�敪 �� �u0�F����vOR�u1�F�ԕi�v
            retstring += " AND ( AB.SALESSLIPCDDTLRF = 0 OR  AB.SALESSLIPCDDTLRF = 1 )";

            // ���㗚�𖾍׃f�[�^.BL�O���[�v�R�[�h 
            if (0 != _carShipRsltCndtnWork.BLGroupCodeSt)
            {
                retstring += " AND AB.BLGROUPCODERF>=@ST_BLGROUP ";
                SqlParameter Para_St_BLgroupCode = sqlCommand.Parameters.Add("@ST_BLGROUP", SqlDbType.Int);
                Para_St_BLgroupCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGroupCodeSt);
            }

            if (0 != _carShipRsltCndtnWork.BLGroupCodeEd)
            {
                retstring += " AND AB.BLGROUPCODERF<=@ED_BLGROUP ";
                SqlParameter Para_Ed_BLgroupCode = sqlCommand.Parameters.Add("@ED_BLGROUP", SqlDbType.Int);
                Para_Ed_BLgroupCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGroupCodeEd);
            }

            // ���㗚�𖾍׃f�[�^.BL���i�R�[�h
            if (0 != _carShipRsltCndtnWork.BLGoodsCodeSt)
            {
                retstring += " AND AB.BLGOODSCODERF>=@ST_GOODSCODE ";
                SqlParameter Para_St_BLgoodsCode = sqlCommand.Parameters.Add("@ST_GOODSCODE", SqlDbType.Int);
                Para_St_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGoodsCodeSt);
            }

            if (0 != _carShipRsltCndtnWork.BLGoodsCodeEd)
            {
                retstring += " AND AB.BLGOODSCODERF<=@ED_GOODSCODE ";
                SqlParameter Para_Ed_BLgoodsCode = sqlCommand.Parameters.Add("@ED_GOODSCODE", SqlDbType.Int);
                Para_Ed_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGoodsCodeEd);
            }

            // ���㗚�𖾍׃f�[�^.���i�ԍ�
            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.GoodsNoSt))
            {
                retstring += " AND AB.GOODSNORF>=@ST_GOODSNO ";
                SqlParameter Para_St_BLgoodsNo = sqlCommand.Parameters.Add("@ST_GOODSNO", SqlDbType.NChar);
                Para_St_BLgoodsNo.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.GoodsNoSt);
            }

            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.GoodsNoEd))
            {
                retstring += " AND AB.GOODSNORF<=@ED_GOODSNO ";
                SqlParameter Para_Ed_BLgoodsNo = sqlCommand.Parameters.Add("@ED_GOODSNO", SqlDbType.NChar);
                Para_Ed_BLgoodsNo.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.GoodsNoEd);
            }

            // ���㗚�𖾍׃f�[�^.����݌Ɏ�񂹋敪 
            if (_carShipRsltCndtnWork.RsltTtlDiv == 1)
            {
                // 1:�݌�
                retstring += " AND AB.SALESORDERDIVCDRF = 1 ";
            }
            else if (_carShipRsltCndtnWork.RsltTtlDiv == 2)
            {
                // 2:���
                retstring += " AND AB.SALESORDERDIVCDRF = 0 ";
            }
          
           
            #endregion
            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_carShipRsltCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private string MakeWhereStringB(ref SqlCommand sqlCommand, CarShipRsltCndtnWork _carShipRsltCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            // ���q���i�f�[�^(�R���o�[�g).��ƃR�[�h �� �󒍃}�X�^(���q).��ƃR�[�h
            retstring += " BA.ENTERPRISECODERF=BB.ENTERPRISECODERF";

            // ���q���i�f�[�^(�R���o�[�g).�󒍔ԍ� �� �󒍃}�X�^(���q).�󒍔ԍ�
            retstring += " AND BA.ACCEPTANORDERNORF=BB.ACCEPTANORDERNORF";

            // ���q���i�f�[�^(�R���o�[�g).�󒍃X�e�[�^�X �� �󒍃}�X�^(���q).�󒍃X�e�[�^�X
            retstring += " AND BA.ACPTANODRSTATUSRF=BB.ACPTANODRSTATUSRF";

            // ���q���i�f�[�^(�R���o�[�g).��ƃR�[�h�����O�C���S���҂̊�ƃR�[�h
            retstring += " AND BA.ENTERPRISECODERF=@BENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@BENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.EnterpriseCode);

            retstring += " AND BA.LOGICALDELETECODERF = 0 ";
            retstring += " AND (BA.ACPTANODRSTATUSRF = 7 OR BA.ACPTANODRSTATUSRF = 8)";

            //���_�R�[�h
            if (_carShipRsltCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _carShipRsltCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND BA.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // ���q���i�f�[�^(�R���o�[�g).������t																																	
            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.SalesDateSt))
            {
                retstring += "AND BA.SALESDATERF>=@BST_SALESDAY ";
                SqlParameter Para_St_salesDate = sqlCommand.Parameters.Add("@BST_SALESDAY", SqlDbType.Int);
                Para_St_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.SalesDateSt);
            }

            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.SalesDateEd))
            {
                retstring += "AND BA.SALESDATERF<=@BED_SALESDAY ";
                SqlParameter Para_Ed_salesDate = sqlCommand.Parameters.Add("@BED_SALESDAY", SqlDbType.Int);
                Para_Ed_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.SalesDateEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).������t
            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.InputDateSt))
            {
                retstring += "AND BA.SALESDATERF>=@BST_SECHSDAY ";
                SqlParameter Para_St_sechDate = sqlCommand.Parameters.Add("@BST_SECHSDAY", SqlDbType.Int);
                Para_St_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.InputDateSt);
            }

            if (!DateTime.MinValue.Equals(_carShipRsltCndtnWork.InputDateEd))
            {
                retstring += "AND BA.SALESDATERF<=@BED_SECHSDAY ";
                SqlParameter Para_Ed_sechDate = sqlCommand.Parameters.Add("@BED_SECHSDAY", SqlDbType.Int);
                Para_Ed_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_carShipRsltCndtnWork.InputDateEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).���Ӑ�R�[�h
            if (0 != _carShipRsltCndtnWork.CustomerCodeSt)
            {
                retstring += " AND BA.CUSTOMERCODERF>=@BST_CUSTOMERCODE ";
                SqlParameter Para_St_customerCode = sqlCommand.Parameters.Add("@BST_CUSTOMERCODE", SqlDbType.Int);
                Para_St_customerCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.CustomerCodeSt);
            }

            if (0 != _carShipRsltCndtnWork.CustomerCodeEd)
            {
                retstring += " AND BA.CUSTOMERCODERF<=@BED_CUSTOMERCODE ";
                SqlParameter Para_Ed_customerCode = sqlCommand.Parameters.Add("@BED_CUSTOMERCODE", SqlDbType.Int);
                Para_Ed_customerCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.CustomerCodeEd);
            }

            // �󒍃}�X�^(���q).�_���폜�敪 �� �u0�F�L���v
            retstring += " AND BB.LOGICALDELETECODERF = 0 ";

            // �󒍃}�X�^(���q).���q�Ǘ��R�[�h
            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.CarMngCodeSt))
            {
                retstring += " AND BB.CARMNGCODERF>=@BST_CARMNGCODE ";
                SqlParameter Para_St_carmngCode = sqlCommand.Parameters.Add("@BST_CARMNGCODE", SqlDbType.NChar);
                Para_St_carmngCode.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.CarMngCodeSt);
            }

            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.CarMngCodeEd))
            {
                retstring += " AND BB.CARMNGCODERF<=@BED_CARMNGCODE ";
                SqlParameter Para_Ed_carmngCode = sqlCommand.Parameters.Add("@BED_CARMNGCODE", SqlDbType.NChar);
                Para_Ed_carmngCode.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.CarMngCodeEd);
            }

            // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� ��	 0
            retstring += " AND BB.CARMNGNORF <> 0 ";

            // �󒍃}�X�^(���q).���q���l
            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.SlipNoteCar))
            {
                // 0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���
                if (_carShipRsltCndtnWork.CarOutDiv == 0)
                {
                    retstring += " AND BB.CARNOTERF=@BCARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@BCARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.SlipNoteCar);
                }
                else if (_carShipRsltCndtnWork.CarOutDiv == 1)
                {
                    retstring += " AND BB.CARNOTERF LIKE @BCARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@BCARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.SlipNoteCar + "%");
                }
                else if (_carShipRsltCndtnWork.CarOutDiv == 2)
                {
                    retstring += " AND BB.CARNOTERF LIKE @BCARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@BCARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString("%" + _carShipRsltCndtnWork.SlipNoteCar + "%");
                }
                else if (_carShipRsltCndtnWork.CarOutDiv == 3)
                {
                    retstring += " AND BB.CARNOTERF LIKE @BCARNOTE ";
                    SqlParameter Para_carNote = sqlCommand.Parameters.Add("@BCARNOTE", SqlDbType.NChar);
                    Para_carNote.Value = SqlDataMediator.SqlSetString("%" + _carShipRsltCndtnWork.SlipNoteCar);
                }

            }

            // ���q���i�f�[�^(�R���o�[�g).BL�O���[�v�R�[�h 
            if (0 != _carShipRsltCndtnWork.BLGroupCodeSt)
            {
                retstring += " AND BA.BLGROUPCODERF>=@BST_BLGROUP ";
                SqlParameter Para_St_BLgroupCode = sqlCommand.Parameters.Add("@BST_BLGROUP", SqlDbType.Int);
                Para_St_BLgroupCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGroupCodeSt);
            }

            if (0 != _carShipRsltCndtnWork.BLGroupCodeEd)
            {
                retstring += " AND BA.BLGROUPCODERF<=@BED_BLGROUP ";
                SqlParameter Para_Ed_BLgroupCode = sqlCommand.Parameters.Add("@BED_BLGROUP", SqlDbType.Int);
                Para_Ed_BLgroupCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGroupCodeEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).BL���i�R�[�h
            if (0 != _carShipRsltCndtnWork.BLGoodsCodeSt)
            {
                retstring += " AND BA.BLGOODSCODERF>=@BST_GOODSCODE ";
                SqlParameter Para_St_BLgoodsCode = sqlCommand.Parameters.Add("@BST_GOODSCODE", SqlDbType.Int);
                Para_St_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGoodsCodeSt);
            }

            if (0 != _carShipRsltCndtnWork.BLGoodsCodeEd)
            {
                retstring += " AND BA.BLGOODSCODERF<=@BED_GOODSCODE ";
                SqlParameter Para_Ed_BLgoodsCode = sqlCommand.Parameters.Add("@BED_GOODSCODE", SqlDbType.Int);
                Para_Ed_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_carShipRsltCndtnWork.BLGoodsCodeEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).���i�ԍ�
            if (!string.IsNullOrEmpty( _carShipRsltCndtnWork.GoodsNoSt))
            {
                retstring += " AND BA.GOODSNORF>=@BST_GOODSNO ";
                SqlParameter Para_St_BLgoodsNo = sqlCommand.Parameters.Add("@BST_GOODSNO", SqlDbType.NChar);
                Para_St_BLgoodsNo.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.GoodsNoSt);
            }

            if (!string.IsNullOrEmpty(_carShipRsltCndtnWork.GoodsNoEd))
            {
                retstring += " AND BA.GOODSNORF<=@BED_GOODSNO ";
                SqlParameter Para_Ed_BLgoodsNo = sqlCommand.Parameters.Add("@BED_GOODSNO", SqlDbType.NChar);
                Para_Ed_BLgoodsNo.Value = SqlDataMediator.SqlSetString(_carShipRsltCndtnWork.GoodsNoEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).����݌Ɏ�񂹋敪 
            if (_carShipRsltCndtnWork.RsltTtlDiv == 1)
            {
                // 1:�݌�
                retstring += " AND BA.SALESORDERDIVCDRF = 1 ";
            }
            else if (_carShipRsltCndtnWork.RsltTtlDiv == 2)
            {
                // 2:���
                retstring += " AND BA.SALESORDERDIVCDRF = 0 ";
            }

            #endregion
            return retstring;
        }


        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //�R�l�N�V������������
    }
}
