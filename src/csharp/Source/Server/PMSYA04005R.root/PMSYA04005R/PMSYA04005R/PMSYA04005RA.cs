//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�o�ו��i�\��
// �v���O�����T�v   : ���q�o�ו��i�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/10/20  �C�����e : PM-2-A Redmin#702�A749�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/10/23  �C�����e : PM-2-A Redmin#829�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �C �� ��  2009/12/24  �C�����e : MANTIS[14822] ���q�Ǘ��}�X�^ �L�[�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/22  �C�����e : �Ɖ�v���O�����̃��O�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/08/09  �C�����e : 2012/09/12�z�M���ARedmine#31532 ���q�o�ו��i�\�� �\�[�g���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� �G
// �C �� ��  2013/03/25  �C�����e : SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��
//----------------------------------------------------------------------------//
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
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���q�o�ו��i�\������READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�o�ו��i�\������READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.09.10</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/20 ������</br>
    /// <br>             Redmin#702�A749�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/23 ������</br>
    /// <br>             Redmin#829�Ή�</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2012/08/09 ������</br>
    /// <br>             Redmine#31532 ���q�o�ו��i�\�� �\�[�g���s��</br>
    /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
    /// <br>Programmer : FSI���� �G</br>
    /// <br>Date       : 2013/03/25</br>
    /// </remarks>
    [Serializable]
    public class CarShipmentPartsDispDB : RemoteDB, ICarShipmentPartsDispDB
    {
        #region ���q�o�ו��i�\����������
        /// <summary>
        /// ���q�o�ו��i�\����������
        /// </summary>
        /// <param name="carManagementList">��������</param>
        /// <param name="carManagementObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���q�o�ו��i�\������</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        public int CarInfoSearch(ref ArrayList carManagementList, object carManagementObj)
        {
            // ---UPD 2011/03/22---------->>>>>
            //return CarInfoSearchProc(ref carManagementList, carManagementObj);
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CarInfoConditionWorkWork carInfoConditionWorkWork = carManagementObj as CarInfoConditionWorkWork;

            SqlConnection sqlConnection = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carInfoConditionWorkWork.EnterpriseCode, "���q�o�ו��i�\��", "���o�J�n");

                status = CarInfoSearchProc(ref carManagementList, carManagementObj);

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carInfoConditionWorkWork.EnterpriseCode, "���q�o�ו��i�\��", "���o�I��");
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "CarShipmentPartsDispDB.CarInfoSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            
            return status;
            // ---UPD 2011/03/22---------->>>>>
        }

        /// <summary>
        /// ���q�o�ו��i�\����������
        /// </summary>
        /// <param name="carManagementList">��������</param>
        /// <param name="carManagementObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���q�o�ו��i�\������</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: 2012/08/09 ������</br>
        /// <br>             Redmine#31532 ���q�o�ו��i�\�� �\�[�g���s��</br>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/25</br>
        private int CarInfoSearchProc(ref ArrayList carManagementList, object carManagementObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CarInfoConditionWorkWork carInfoConditionWorkWork = carManagementObj as CarInfoConditionWorkWork;
            carManagementList = new ArrayList();
            CarShipmentPartsDispWork carShipmentPartsDispWork = null;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            sqlCommand = new SqlCommand("", sqlConnection);
            try
            {
                // Select�R�}���h�̐���
                sqlStr = " SELECT "
                + " ACCEPTODRCARRF.CARMNGCODERF, "                // ADD 2009/10/10 �󒍃}�X�^(���q).���q�Ǘ��R�[�h
                + " SALESHISTORYRF.SALESDATERF, "                // ���㗚���f�[�^.������t
                + " SALESHISTORYRF.SLIPNOTERF AS NOTERF, "                // ���㗚���f�[�^.�`�[���l
                + " SALESHISTORYRF.SALESSLIPNUMRF, "                // ���㗚���f�[�^.����`�[�ԍ�
                + " SALESHISTDTLRF.GOODSNAMERF, "                // ���㗚�𖾍׃f�[�^.���i����
                + " SALESHISTDTLRF.GOODSNORF, "                // ���㗚�𖾍׃f�[�^.���i�ԍ�
                + " SALESHISTDTLRF.GOODSMAKERCDRF, "                // ���㗚�𖾍׃f�[�^.���i���[�J�[�R�[�h
                + " SALESHISTDTLRF.BLGOODSCODERF, "                // ���㗚�𖾍׃f�[�^.BL���i�R�[�h
                + " SALESHISTDTLRF.WAREHOUSECODERF, "                // ���㗚�𖾍׃f�[�^.�q�ɃR�[�h
                + " SALESHISTDTLRF.WAREHOUSESHELFNORF, "                // ���㗚�𖾍׃f�[�^.�q�ɒI��
                + " SALESHISTDTLRF.SALESROWNORF,"�@�@�@�@�@�@�@�@//�s�ԍ��@//ADD BY ������ on 2012/08/09 for Redmine#31532
                + " SALESHISTDTLRF.SALESORDERDIVCDRF, "                // ���㗚�𖾍׃f�[�^.����݌Ɏ�񂹋敪
                + " SALESHISTDTLRF.LISTPRICETAXEXCFLRF, "                // ���㗚�𖾍׃f�[�^.�艿�i�Ŕ��C�����j
                + " SALESHISTDTLRF.SHIPMENTCNTRF, "                // ���㗚�𖾍׃f�[�^.�o�א�
                + " SALESHISTDTLRF.SALESUNPRCTAXEXCFLRF, "                // ���㗚�𖾍׃f�[�^.����P���i�Ŕ��C�����j
                + " SALESHISTDTLRF.SALESMONEYTAXEXCRF, "                // ���㗚�𖾍׃f�[�^.������z�i�Ŕ����j
                + " SALESHISTDTLRF.SALESUNITCOSTRF, "                // ���㗚�𖾍׃f�[�^.�����P��
                + " 0 AS GROSSPROFITRF, "                            // 0 �e�����z  // ADD 2009/10/10
                + " SALESHISTDTLRF.WAREHOUSENAMERF, "                // ���㗚�𖾍׃f�[�^.�q�ɖ���
                + " SALESHISTDTLRF.COSTRF, "                // ���㗚�𖾍׃f�[�^.����
                + " SALESHISTDTLRF.SALESSLIPCDDTLRF, "            // ���㗚�𖾍׃f�[�^.����`�[�敪�i���ׁj // ADD 2009/10/23
                + " ACCEPTODRCARRF.CARNOTERF, "                // �󒍃}�X�^�i�ԗ��j.���q���l
                + " ACCEPTODRCARRF.MILEAGERF, "                // �󒍃}�X�^�i�ԗ��j.���s����
                + " ACCEPTODRCARRF.MODELDESIGNATIONNORF, "                // �󒍃}�X�^�i�ԗ��j.�^���w��ԍ�
                + " ACCEPTODRCARRF.CATEGORYNORF, "                // �󒍃}�X�^�i�ԗ��j.�ޕʔԍ�
                + " ACCEPTODRCARRF.ENGINEMODELNMRF, "                // �󒍃}�X�^�i�ԗ��j.�G���W���^������
                + " ACCEPTODRCARRF.FULLMODELRF, "                // �󒍃}�X�^�i�ԗ��j.�^���i�t���^�j
                + " ACCEPTODRCARRF.MAKERCODERF, "                // �󒍃}�X�^�i�ԗ��j.���[�J�[�R�[�h
                + " ACCEPTODRCARRF.MODELCODERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ�R�[�h
                + " ACCEPTODRCARRF.MODELSUBCODERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ�T�u�R�[�h
                + " ACCEPTODRCARRF.MODELFULLNAMERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ�S�p����
                + " ACCEPTODRCARRF.MODELHALFNAMERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ피�p����
                + " ACCEPTODRCARRF.FIRSTENTRYDATERF, "                // �󒍃}�X�^�i�ԗ��j.���N�x
                + " ACCEPTODRCARRF.FRAMENORF, "                // �󒍃}�X�^�i�ԗ��j.�ԑ�ԍ�
                + " ACCEPTODRCARRF.COLORCODERF, "                // �󒍃}�X�^�i�ԗ��j.�J���[�R�[�h
                + " ACCEPTODRCARRF.COLORNAME1RF, "                // �󒍃}�X�^�i�ԗ��j.�J���[����1
                + " ACCEPTODRCARRF.TRIMCODERF, "                // �󒍃}�X�^�i�ԗ��j.�g�����R�[�h
                + " ACCEPTODRCARRF.TRIMNAMERF, "                // �󒍃}�X�^�i�ԗ��j.�g��������
                + " ACCEPTODRCARRF.NUMBERPLATE1CODERF, "                // �󒍃}�X�^�i�ԗ��j.���^�������ԍ�
                + " ACCEPTODRCARRF.NUMBERPLATE1NAMERF, "                // �󒍃}�X�^�i�ԗ��j.���^�����ǖ���
                + " ACCEPTODRCARRF.NUMBERPLATE2RF, "                // �󒍃}�X�^�i�ԗ��j.�ԗ��o�^�ԍ��i��ʁj
                + " ACCEPTODRCARRF.NUMBERPLATE3RF, "                // �󒍃}�X�^�i�ԗ��j.�ԗ��o�^�ԍ��i�J�i�j
                + " ACCEPTODRCARRF.NUMBERPLATE4RF, "                // �󒍃}�X�^�i�ԗ��j.�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                + " ACCEPTODRCARRF.DOMESTICFOREIGNCODERF, "                // �󒍃}�X�^�i�ԗ��j.���Y�^�O�ԋ敪 // ADD 2013/03/25
                + " CARMANAGEMENTRF.SERIESMODELRF, "               // ���q�Ǘ��}�X�^.�V���[�Y�^��
                + " CARMANAGEMENTRF.CATEGORYSIGNMODELRF, "               // ���q�Ǘ��}�X�^.�^���i�ޕʋL���j
                + " CARMANAGEMENTRF.STPRODUCETYPEOFYEARRF, "               // ���q�Ǘ��}�X�^.�J�n���Y�N��
                + " CARMANAGEMENTRF.EDPRODUCETYPEOFYEARRF, "               // ���q�Ǘ��}�X�^.�I�����Y�N��
                + " CARMANAGEMENTRF.STPRODUCEFRAMENORF, "               // ���q�Ǘ��}�X�^.���Y�ԑ�ԍ��J�n
                + " CARMANAGEMENTRF.EDPRODUCEFRAMENORF, "               // ���q�Ǘ��}�X�^.���Y�ԑ�ԍ��I��
                + " CARMANAGEMENTRF.MODELGRADENMRF, "               // ���q�Ǘ��}�X�^.�^���O���[�h����
                + " CARMANAGEMENTRF.ENGINEMODELRF, "               // ���q�Ǘ��}�X�^.�����@�^���i�G���W���j
                + " CARMANAGEMENTRF.BODYNAMERF, "               // ���q�Ǘ��}�X�^.�{�f�B�[����
                + " CARMANAGEMENTRF.DOORCOUNTRF, "               // ���q�Ǘ��}�X�^.�h�A��
                    //+ " CARMANAGEMENTRF.ENGINEMODELNMRF, "               // ���q�Ǘ��}�X�^.�G���W���^������
                + " CARMANAGEMENTRF.ENGINEDISPLACENMRF, "               // ���q�Ǘ��}�X�^.�r�C�ʖ���
                + " CARMANAGEMENTRF.EDIVNMRF, "               // ���q�Ǘ��}�X�^.E�敪����
                + " CARMANAGEMENTRF.TRANSMISSIONNMRF, "               // ���q�Ǘ��}�X�^.�~�b�V��������
                + " CARMANAGEMENTRF.WHEELDRIVEMETHODNMRF, "               // ���q�Ǘ��}�X�^.�쓮��������
                + " CARMANAGEMENTRF.SHIFTNMRF, "               // ���q�Ǘ��}�X�^.�V�t�g����
                + " CARMANAGEMENTRF.ADDICARSPECTITLE1RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��1
                + " CARMANAGEMENTRF.ADDICARSPECTITLE2RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��2
                + " CARMANAGEMENTRF.ADDICARSPECTITLE3RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��3
                + " CARMANAGEMENTRF.ADDICARSPECTITLE4RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��4
                + " CARMANAGEMENTRF.ADDICARSPECTITLE5RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��5
                + " CARMANAGEMENTRF.ADDICARSPECTITLE6RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��6
                + " CARMANAGEMENTRF.ADDICARSPEC1RF, "               // ���q�Ǘ��}�X�^.�ǉ�����1
                + " CARMANAGEMENTRF.ADDICARSPEC2RF, "               // ���q�Ǘ��}�X�^.�ǉ�����2
                + " CARMANAGEMENTRF.ADDICARSPEC3RF, "               // ���q�Ǘ��}�X�^.�ǉ�����3
                + " CARMANAGEMENTRF.ADDICARSPEC4RF, "               // ���q�Ǘ��}�X�^.�ǉ�����4
                + " CARMANAGEMENTRF.ADDICARSPEC5RF, "               // ���q�Ǘ��}�X�^.�ǉ�����5
                + " CARMANAGEMENTRF.ADDICARSPEC6RF, "               // ���q�Ǘ��}�X�^.�ǉ�����6
                + " MAKERURF.MAKERNAMERF, "                // ���[�J�[�}�X�^�i���[�U�[�o�^�j.���[�J�[����
                + " STOCKRF.SHIPMENTPOSCNTRF, "                   // �݌Ƀ}�X�^.�o�׉\��
                + " SALESHISTORYRF.ACPTANODRSTATUSRF " // ���㗚���f�[�^.�󒍃X�e�[�^�X
                + " FROM "
                    // ���㗚���f�[�^ WITH (READUNCOMMITTED)
                + " SALESHISTORYRF WITH (READUNCOMMITTED) "
                    // INNER JOIN ���㗚�𖾍׃f�[�^ WITH (READUNCOMMITTED) ON (
                + " INNER JOIN SALESHISTDTLRF WITH (READUNCOMMITTED) ON ( "
                    // ���㗚���f�[�^.��ƃR�[�h = ���㗚�𖾍׃f�[�^.��ƃR�[�h
                + " SALESHISTORYRF.ENTERPRISECODERF = SALESHISTDTLRF.ENTERPRISECODERF "
                    // ���㗚���f�[�^.�󒍃X�e�[�^�X = ���㗚�𖾍׃f�[�^.�󒍃X�e�[�^�X
                + " AND SALESHISTORYRF.ACPTANODRSTATUSRF = SALESHISTDTLRF.ACPTANODRSTATUSRF "
                    // ���㗚���f�[�^.����`�[�ԍ� = ���㗚�𖾍׃f�[�^.����`�[�ԍ�
                + " AND SALESHISTORYRF.SALESSLIPNUMRF = SALESHISTDTLRF.SALESSLIPNUMRF "
                    // ���㗚���f�[�^.�_���폜�敪 = �u0�F�L���v
                + " AND SALESHISTORYRF.LOGICALDELETECODERF = 0 "
                    // ���㗚���f�[�^.�󒍃X�e�[�^�X = �u30�F����v
                + " AND SALESHISTORYRF.ACPTANODRSTATUSRF = 30  "
                    // ���㗚���f�[�^.��ƃR�[�h = ���O�C���S����.��ƃR�[�h
                + " AND SALESHISTORYRF.ENTERPRISECODERF = @FINDENTERPRISECODERF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.EnterpriseCode);

                    // ���㗚���f�[�^.���ьv�㋒�_�R�[�h = ���.���_�R�[�h
                    // ��ʓ��͗L�莞
                if (!"00".Equals(carInfoConditionWorkWork.SectionCode))
                {
                    sqlStr += " AND SALESHISTORYRF.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCDRF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCDRF", SqlDbType.NChar);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.SectionCode.Trim());
                }
                // ���㗚���f�[�^.������t >= ���.������i�J�n�j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.StSalesDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SALESDATERF >= @FINDSTSALESDATERF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@FINDSTSALESDATERF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraStSalesDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StSalesDate);
                }
                // ���㗚���f�[�^.������t <= ���.������i�I���j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.EdSalesDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SALESDATERF <= @FINDEDSALESDATERF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@FINDEDSALESDATERF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdSalesDate);
                }
                // ���㗚���f�[�^.�`�[�������t >= ���.���͓��i�J�n�j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.StInputDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SEARCHSLIPDATERF >= @FINDSTSEARCHSLIPDATERF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraStInputDate = sqlCommand.Parameters.Add("@FINDSTSEARCHSLIPDATERF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraStInputDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StInputDate);
                }
                // ���㗚���f�[�^.�`�[�������t <= ���.���͓��i�I���j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.EdInputDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SEARCHSLIPDATERF <= @FINDEDSEARCHSLIPDATERF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraEdInputDate = sqlCommand.Parameters.Add("@FINDEDSEARCHSLIPDATERF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraEdInputDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdInputDate);
                }
                // ���㗚���f�[�^.���Ӑ�R�[�h = ���.���Ӑ�R�[�h
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.CustomerCode != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.CUSTOMERCODERF = @FINDCUSTOMERCODERF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CustomerCode);
                }
                // ���㗚�𖾍׃f�[�^.�_���폜�敪 = �u0�F�L���v
                sqlStr += " AND SALESHISTDTLRF.LOGICALDELETECODERF = 0 "
                    // �i ���㗚�𖾍׃f�[�^.����`�[�敪�i���ׁj= �u0�F����v
                    //    OR ���㗚�𖾍׃f�[�^.����`�[�敪�i���ׁj= �u1�F�ԕi�v)
                + " AND (SALESHISTDTLRF.SALESSLIPCDDTLRF = 0 OR SALESHISTDTLRF.SALESSLIPCDDTLRF = 1) ";
                    // ���㗚�𖾍׃f�[�^.BL�O���[�v�R�[�h = ���.BL�O���[�v�R�[�h
                    // ��ʓ��͗L�莞
                    if (carInfoConditionWorkWork.BLGroupCode != 0)
                    {
                        sqlStr += " AND SALESHISTDTLRF.BLGROUPCODERF = @FINDBLGROUPCODERF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODERF", SqlDbType.Int);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGroupCode);
                    }
                    // ���㗚�𖾍׃f�[�^.BL���i�R�[�h = ���.BL���i�R�[�h
                    // ��ʓ��͗L�莞
                    if (carInfoConditionWorkWork.BLGoodsCode != 0)
                    {
                        sqlStr += " AND SALESHISTDTLRF.BLGOODSCODERF = @FINDBLGOODSCODERF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODERF", SqlDbType.Int);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGoodsCode);
                    }
                    // ���㗚�𖾍׃f�[�^.�q�ɃR�[�h = ���.�q�ɃR�[�h
                    // ��ʓ��͗L�莞
                    if (!string.IsNullOrEmpty(carInfoConditionWorkWork.WarehouseCode))
                    {
                        sqlStr += " AND SALESHISTDTLRF.WAREHOUSECODERF = @FINDWAREHOUSECODERF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODERF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.WarehouseCode.Trim());
                    }
                    // ��ʂ̍݌Ɏ��敪���u���v��I���̏ꍇ
                    // ���㗚�𖾍׃f�[�^.����݌Ɏ�񂹋敪 = �u1�F�݌Ɂv
                    if (carInfoConditionWorkWork.SalesOrderDivCd == 1)
                    {
                        sqlStr += " AND SALESHISTDTLRF.SALESORDERDIVCDRF = 1 ";
                    }
                    // ��ʂ̍݌Ɏ��敪���u�݌Ɂv��I���̏ꍇ
                    // ���㗚�𖾍׃f�[�^.����݌Ɏ�񂹋敪 = �u0�F���v
                    else if (carInfoConditionWorkWork.SalesOrderDivCd == 2)
                    {
                        sqlStr += " AND SALESHISTDTLRF.SALESORDERDIVCDRF = 0 ";
                    }
                    // ��ʂ̕i�������͗L�莞
                    if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsName))
                    {
                        // ��ʂ̕i�������敪���u�ƈ�v�v��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i���� = ���.�i��
                        if (carInfoConditionWorkWork.GoodsNameDiv == 0)
                        {
                            // ���S��v�̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF = @FINDGOODSNAMERF ";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim());
                        }
                        // ��ʂ̕i�������敪���u�Ŏn�܂�v��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i���� LIKE ���.�i��+% 
                        else if (carInfoConditionWorkWork.GoodsNameDiv == 1)
                        {
                            // �O����v�̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF LIKE @FINDGOODSNAMERF ";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim() + "%");
                        }
                        // ��ʂ̕i�������敪���u���܂ށv��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i���� LIKE %+���.�i��+%
                        else if (carInfoConditionWorkWork.GoodsNameDiv == 2)
                        {
                            // �܂݂̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF LIKE @FINDGOODSNAMERF";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsName.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim() + "%");
                        }
                        // ��ʂ̕i�������敪���u�ŏI���v��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i���� LIKE %+���.�i��
                        else
                        {
                            // �����v�̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF LIKE @FINDGOODSNAMERF";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsName.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim());
                        }
                    }
                    // ��ʂ̕i�Ԃ����͗L�莞
                    if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsNo))
                    {
                        // ��ʂ̕i�Ԍ����敪���u�ƈ�v�v��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i�ԍ� = ���.�i��
                        if (carInfoConditionWorkWork.GoodsNoDiv == 0)
                        {
                            // ���S��v�̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF = @FINDGOODSNORF ";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim());
                        }
                        // ��ʂ̕i�Ԍ����敪���u�Ŏn�܂�v��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i�ԍ� LIKE ���.�i��+% 
                        else if (carInfoConditionWorkWork.GoodsNoDiv == 1)
                        {
                            // �O����v�̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF LIKE @FINDGOODSNORF ";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                        }
                        // ��ʂ̕i�Ԍ����敪���u���܂ށv��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i�ԍ� LIKE %+���.�i��+%
                        else if (carInfoConditionWorkWork.GoodsNoDiv == 2)
                        {
                            // �܂݂̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF LIKE @FINDGOODSNORF";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                        }
                        // ��ʂ̕i�������敪���u�ŏI���v��I���̏ꍇ
                        // ���㗚�𖾍׃f�[�^.���i�ԍ� LIKE %+���.�i��
                        else
                        {
                            // �����v�̏ꍇ
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF LIKE @FINDGOODSNORF";
                            // Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim());
                        }
                    }

                    sqlStr += " ) ";

                    // INNER JOIN �󒍃}�X�^(���q) WITH (READUNCOMMITTED) ON (
                    sqlStr += " INNER JOIN ACCEPTODRCARRF WITH (READUNCOMMITTED) ON ( "
                        // ���㗚�𖾍׃f�[�^.��ƃR�[�h = �󒍃}�X�^(���q).��ƃR�[�h
                    + " SALESHISTDTLRF.ENTERPRISECODERF = ACCEPTODRCARRF.ENTERPRISECODERF "
                            // ���㗚�𖾍׃f�[�^.�󒍔ԍ� = �󒍃}�X�^(���q).�󒍔ԍ�
                    + " AND SALESHISTDTLRF.ACCEPTANORDERNORF = ACCEPTODRCARRF.ACCEPTANORDERNORF "
                            // ���㗚�𖾍׃f�[�^.�󒍃X�e�[�^�X = �u30�F����v
                    + " AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30 "
                            // �i �󒍃}�X�^(���q).�󒍃X�e�[�^�X = �u7�F����vOR �󒍃}�X�^(���q).�󒍃X�e�[�^�X = �u8�F�ԕi�v �j
                    + " AND (ACCEPTODRCARRF.ACPTANODRSTATUSRF = 7 OR ACCEPTODRCARRF.ACPTANODRSTATUSRF = 8) "
                        // �󒍃}�X�^(���q).�f�[�^���̓V�X�e�� = �u10�FPM�v
                    + " AND ACCEPTODRCARRF.DATAINPUTSYSTEMRF = 10 "
                    // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� <> 0
                    +" AND ACCEPTODRCARRF.CARMNGNORF <> 0 "
                     // �󒍃}�X�^(���q).�_���폜�敪 = �u0�F�L���v
                    + " AND ACCEPTODRCARRF.LOGICALDELETECODERF = 0 ";
                    // �����ŕێ��̎ԗ��Ǘ��ԍ���0�̏ꍇ�A�󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� = ���.�ԗ��Ǘ��ԍ�
                    if (carInfoConditionWorkWork.CarMngNo != 0)
                    {
                        sqlStr += " AND ACCEPTODRCARRF.CARMNGNORF = @FINDCARMNGNORF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNORF", SqlDbType.Int);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CarMngNo);
                    }

                        // ��ʂ̌^�������͗L�莞
                        if (!string.IsNullOrEmpty(carInfoConditionWorkWork.FullModel))
                        {
                            // ��ʂ̌^�������敪���u�ƈ�v�v��I���̏ꍇ
                            // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j = ���.�^��
                            if (carInfoConditionWorkWork.FullModelDiv == 0)
                            {
                                // ���S��v�̏ꍇ
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') = @FINDFULLMODELRF ";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraFullModel.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim());
                            }
                            // ��ʂ̌^�������敪���u�Ŏn�܂�v��I���̏ꍇ
                            // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j LIKE ���.�^��+% 
                            else if (carInfoConditionWorkWork.FullModelDiv == 1)
                            {
                                // �O����v�̏ꍇ
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODELRF ";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraFullModel.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim() + "%");
                            }
                            // ��ʂ̌^�������敪���u���܂ށv��I���̏ꍇ
                            // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j LIKE %+���.�^��+%
                            else if (carInfoConditionWorkWork.FullModelDiv == 2)
                            {
                                // �܂݂̏ꍇ
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODELRF";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraFullModel.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim() + "%");
                            }
                            // ��ʂ̌^�������敪���u�ŏI���v��I���̏ꍇ
                            // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j LIKE %+���.�^��
                            else
                            {
                                // �����v�̏ꍇ
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODELRF";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraFullModel.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim());
                            }
                        }
                        // ��ʂ̎��q���l�����͗L�莞
                        if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarNote))
                        {
                            // ��ʂ̎��q���l�����敪���u�ƈ�v�v��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q���l = ���.���q���l
                            if (carInfoConditionWorkWork.CarNoteDiv == 0)
                            {
                                // ���S��v�̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF = @FINDCARNOTERF ";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarNote.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim());
                            }
                            // ��ʂ̎��q���l�����敪���u�Ŏn�܂�v��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q���l LIKE ���.���q���l+% 
                            else if (carInfoConditionWorkWork.CarNoteDiv == 1)
                            {
                                // �O����v�̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTERF ";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarNote.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim() + "%");
                            }
                            // ��ʂ̎��q���l�����敪���u���܂ށv��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q���l LIKE %+���.���q���l+%
                            else if (carInfoConditionWorkWork.CarNoteDiv == 2)
                            {
                                // �܂݂̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTERF";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarNote.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim() + "%");
                            }
                            // ��ʂ̎��q���l�����敪���u�ŏI���v��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q���l LIKE %+���.���q���l
                            else
                            {
                                // �����v�̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTERF";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarNote.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim());
                            }
                        }
                        // ��ʂ̊Ǘ��ԍ������͗L�莞
                        if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarMngCode))
                        {
                            // ��ʂ̊Ǘ��ԍ������敪���u�ƈ�v�v��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q�Ǘ��R�[�h = ���.�Ǘ��ԍ�
                            if (carInfoConditionWorkWork.CarMngCodeDiv == 0)
                            {
                                // ���S��v�̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF = @FINDCARMNGCODERF ";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim());
                            }
                            // ��ʂ̊Ǘ��ԍ������敪���u�Ŏn�܂�v��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q�Ǘ��R�[�h LIKE ���.�Ǘ��ԍ�+% 
                            else if (carInfoConditionWorkWork.CarMngCodeDiv == 1)
                            {
                                // �O����v�̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODERF ";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                            }
                            // ��ʂ̊Ǘ��ԍ������敪���u���܂ށv��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q�Ǘ��R�[�h LIKE %+���.�Ǘ��ԍ�+%
                            else if (carInfoConditionWorkWork.CarMngCodeDiv == 2)
                            {
                                // �܂݂̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODERF";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                            }
                            // ��ʂ̊Ǘ��ԍ������敪���u�ŏI���v��I���̏ꍇ
                            // �󒍃}�X�^(���q).���q�Ǘ��R�[�h LIKE %+���.�Ǘ��ԍ�
                            else
                            {
                                // �����v�̏ꍇ
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODERF";
                                // Prameter�I�u�W�F�N�g�̍쐬
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim());
                            }
                        }

                sqlStr += " ) ";

                // INNER JOIN ���q�Ǘ��}�X�^ WITH (READUNCOMMITTED) ON (
                sqlStr += " INNER JOIN CARMANAGEMENTRF WITH (READUNCOMMITTED) ON ( "
                    // ���㗚���f�[�^.��ƃR�[�h = ���q�Ǘ��}�X�^.��ƃR�[�h
                    + " SALESHISTORYRF.ENTERPRISECODERF = CARMANAGEMENTRF.ENTERPRISECODERF "
                    // ���㗚���f�[�^.���Ӑ�R�[�h = ���q�Ǘ��}�X�^.���Ӑ�R�[�h
                    + " AND SALESHISTORYRF.CUSTOMERCODERF = CARMANAGEMENTRF.CUSTOMERCODERF "
                    // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� = ���q�Ǘ��}�X�^.�ԗ��Ǘ��ԍ�
                    + " AND ACCEPTODRCARRF.CARMNGNORF = CARMANAGEMENTRF.CARMNGNORF "
                    // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� = ���q�Ǘ��}�X�^.�ԗ��Ǘ��ԍ� // 2009/12/24
                    + " AND ACCEPTODRCARRF.CARMNGCODERF = CARMANAGEMENTRF.CARMNGCODERF " // 2009/12/24
                    // ���q�Ǘ��}�X�^.�_���폜�敪 = �u0�F�L���v
                    + " AND CARMANAGEMENTRF.LOGICALDELETECODERF = 0) ";
                // LEFT JOIN ���[�J�[�}�X�^�i���[�U�[�o�^�j WITH (READUNCOMMITTED) ON (
                sqlStr += " LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ON ( "
                    // ���㗚�𖾍׃f�[�^.��ƃR�[�h = ���[�J�[�}�X�^�i���[�U�[�o�^�j.��ƃR�[�h
                    + " SALESHISTDTLRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF "
                    // ���㗚�𖾍׃f�[�^.���i���[�J�[�R�[�h = ���[�J�[�}�X�^�i���[�U�[�o�^�j.���i���[�J�[�R�[�h
                    + " AND SALESHISTDTLRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF "
                    // ���[�J�[�}�X�^�i���[�U�[�o�^�j.�_���폜�敪 = �u0�F�L���v
                    + " AND MAKERURF.LOGICALDELETECODERF = 0) ";
                // LEFT JOIN �݌Ƀ}�X�^ WITH (READUNCOMMITTED) ON (
                sqlStr += " LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ON ( "
                    // ���㗚�𖾍׃f�[�^.��ƃR�[�h = �݌Ƀ}�X�^.��ƃR�[�h
                    + " SALESHISTDTLRF.ENTERPRISECODERF = STOCKRF.ENTERPRISECODERF "
                    // ���㗚�𖾍׃f�[�^.���i���[�J�[�R�[�h = �݌Ƀ}�X�^.���i���[�J�[�R�[�h
                    + " AND SALESHISTDTLRF.GOODSMAKERCDRF = STOCKRF.GOODSMAKERCDRF "
                    // ���㗚�𖾍׃f�[�^.���i�ԍ� = �݌Ƀ}�X�^.���i�ԍ�
                    + " AND SALESHISTDTLRF.GOODSNORF = STOCKRF.GOODSNORF "
                    // ���㗚�𖾍׃f�[�^.�q�ɃR�[�h = �݌Ƀ}�X�^.�q�ɃR�[�h
                    + " AND SALESHISTDTLRF.WAREHOUSECODERF = STOCKRF.WAREHOUSECODERF "
                    // �݌Ƀ}�X�^.�_���폜�敪 = �u0�F�L���v
                    + " AND STOCKRF.LOGICALDELETECODERF = 0) ";

                // sqlStr += " UNION "  // DEL 2009/10/20 Redmin#749�Ή�
                sqlStr += " UNION ALL " // ADD 2009/10/20 Redmin#749�Ή�
                + " SELECT "
                + " ACCEPTODRCARRF.CARMNGCODERF, "                // ADD 2009/10/10 �󒍃}�X�^(���q).���q�Ǘ��R�[�h
                + " CNVCARPARTSRF.SALESDATERF, "                // ���q���i�f�[�^(�R���o�[�g).������t
                + " CNVCARPARTSRF.DTLNOTERF AS NOTERF, "                // ���q���i�f�[�^(�R���o�[�g).���ה��l
                + " CNVCARPARTSRF.SALESSLIPNUMRF, "                // ���q���i�f�[�^(�R���o�[�g).����`�[�ԍ�
                + " CNVCARPARTSRF.GOODSNAMERF, "                // ���q���i�f�[�^(�R���o�[�g).���i����
                + " CNVCARPARTSRF.GOODSNORF, "                // ���q���i�f�[�^(�R���o�[�g).���i�ԍ�
                + " CNVCARPARTSRF.GOODSMAKERCDRF, "                // ���q���i�f�[�^(�R���o�[�g).���i���[�J�[�R�[�h
                + " CNVCARPARTSRF.BLGOODSCODERF, "                // ���q���i�f�[�^(�R���o�[�g).BL���i�R�[�h
                + " NULL AS WAREHOUSECODERF, "                // NULL.�q�ɃR�[�h
                + " NULL AS WAREHOUSESHELFNORF, "                // NULL.�q�ɒI��
                + " CNVCARPARTSRF.SALESROWNORF,"              //�s�ԍ��@//ADD BY ������ on 2012/08/09 for Redmine#31532
                + " CNVCARPARTSRF.SALESORDERDIVCDRF, "                // ���q���i�f�[�^(�R���o�[�g).����݌Ɏ�񂹋敪
                + " CNVCARPARTSRF.LISTPRICETAXEXCFLRF, "                // ���q���i�f�[�^(�R���o�[�g).�艿�i�Ŕ��C�����j
                + " CNVCARPARTSRF.SHIPMENTCNTRF, "                // ���q���i�f�[�^(�R���o�[�g).�o�א�
                + " CNVCARPARTSRF.SALESUNPRCTAXEXCFLRF, "                // ���q���i�f�[�^(�R���o�[�g).����P���i�Ŕ��C�����j
                + " CNVCARPARTSRF.SALESMONEYTAXEXCRF, "                // ���q���i�f�[�^(�R���o�[�g).������z�i�Ŕ����j
                + " CNVCARPARTSRF.SALESUNITCOSTRF, "                // ���q���i�f�[�^(�R���o�[�g).�����P��
                + " CNVCARPARTSRF.GROSSPROFITRF, "                // ���q���i�f�[�^(�R���o�[�g).�e�����z // ADD 2009/10/10
                + " NULL AS WAREHOUSENAMERF, "                // NULL.�q�ɖ���
                + " -999999999 AS COSTRF, "                           // -999999999.����
                + " 0 AS SALESSLIPCDDTLRF, "            // 0.����`�[�敪�i���ׁj // ADD 2009/10/23
                + " ACCEPTODRCARRF.CARNOTERF, "                // �󒍃}�X�^�i�ԗ��j.���q���l
                + " ACCEPTODRCARRF.MILEAGERF, "                // �󒍃}�X�^�i�ԗ��j.���s����
                + " ACCEPTODRCARRF.MODELDESIGNATIONNORF, "                // �󒍃}�X�^�i�ԗ��j.�^���w��ԍ�
                + " ACCEPTODRCARRF.CATEGORYNORF, "                // �󒍃}�X�^�i�ԗ��j.�ޕʔԍ�
                + " ACCEPTODRCARRF.ENGINEMODELNMRF, "                // �󒍃}�X�^�i�ԗ��j.�G���W���^������
                + " ACCEPTODRCARRF.FULLMODELRF, "                // �󒍃}�X�^�i�ԗ��j.�^���i�t���^�j
                + " ACCEPTODRCARRF.MAKERCODERF, "                // �󒍃}�X�^�i�ԗ��j.���[�J�[�R�[�h
                + " ACCEPTODRCARRF.MODELCODERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ�R�[�h
                + " ACCEPTODRCARRF.MODELSUBCODERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ�T�u�R�[�h
                + " ACCEPTODRCARRF.MODELFULLNAMERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ�S�p����
                + " ACCEPTODRCARRF.MODELHALFNAMERF, "                // �󒍃}�X�^�i�ԗ��j.�Ԏ피�p����
                + " ACCEPTODRCARRF.FIRSTENTRYDATERF, "                // �󒍃}�X�^�i�ԗ��j.���N�x
                + " ACCEPTODRCARRF.FRAMENORF, "                // �󒍃}�X�^�i�ԗ��j.�ԑ�ԍ�
                + " ACCEPTODRCARRF.COLORCODERF, "                // �󒍃}�X�^�i�ԗ��j.�J���[�R�[�h
                + " ACCEPTODRCARRF.COLORNAME1RF, "                // �󒍃}�X�^�i�ԗ��j.�J���[����1
                + " ACCEPTODRCARRF.TRIMCODERF, "                // �󒍃}�X�^�i�ԗ��j.�g�����R�[�h
                + " ACCEPTODRCARRF.TRIMNAMERF, "                // �󒍃}�X�^�i�ԗ��j.�g��������
                + " ACCEPTODRCARRF.NUMBERPLATE1CODERF, "                // �󒍃}�X�^�i�ԗ��j.���^�������ԍ�
                + " ACCEPTODRCARRF.NUMBERPLATE1NAMERF, "                // �󒍃}�X�^�i�ԗ��j.���^�����ǖ���
                + " ACCEPTODRCARRF.NUMBERPLATE2RF, "                // �󒍃}�X�^�i�ԗ��j.�ԗ��o�^�ԍ��i��ʁj
                + " ACCEPTODRCARRF.NUMBERPLATE3RF, "                // �󒍃}�X�^�i�ԗ��j.�ԗ��o�^�ԍ��i�J�i�j
                + " ACCEPTODRCARRF.NUMBERPLATE4RF, "                // �󒍃}�X�^�i�ԗ��j.�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                + " ACCEPTODRCARRF.DOMESTICFOREIGNCODERF, "                // �󒍃}�X�^�i�ԗ��j.���Y�^�O�ԋ敪 // ADD 2013/03/25
                + " CARMANAGEMENTRF.SERIESMODELRF, "               // ���q�Ǘ��}�X�^.�V���[�Y�^��
                + " CARMANAGEMENTRF.CATEGORYSIGNMODELRF, "               // ���q�Ǘ��}�X�^.�^���i�ޕʋL���j
                + " CARMANAGEMENTRF.STPRODUCETYPEOFYEARRF, "               // ���q�Ǘ��}�X�^.�J�n���Y�N��
                + " CARMANAGEMENTRF.EDPRODUCETYPEOFYEARRF, "               // ���q�Ǘ��}�X�^.�I�����Y�N��
                + " CARMANAGEMENTRF.STPRODUCEFRAMENORF, "               // ���q�Ǘ��}�X�^.���Y�ԑ�ԍ��J�n
                + " CARMANAGEMENTRF.EDPRODUCEFRAMENORF, "               // ���q�Ǘ��}�X�^.���Y�ԑ�ԍ��I��
                + " CARMANAGEMENTRF.MODELGRADENMRF, "               // ���q�Ǘ��}�X�^.�^���O���[�h����
                + " CARMANAGEMENTRF.ENGINEMODELRF, "               // ���q�Ǘ��}�X�^.�����@�^���i�G���W���j
                + " CARMANAGEMENTRF.BODYNAMERF, "               // ���q�Ǘ��}�X�^.�{�f�B�[����
                + " CARMANAGEMENTRF.DOORCOUNTRF, "               // ���q�Ǘ��}�X�^.�h�A��
                    //+ " CARMANAGEMENTRF.ENGINEMODELNMRF, "               // ���q�Ǘ��}�X�^.�G���W���^������
                + " CARMANAGEMENTRF.ENGINEDISPLACENMRF, "               // ���q�Ǘ��}�X�^.�r�C�ʖ���
                + " CARMANAGEMENTRF.EDIVNMRF, "               // ���q�Ǘ��}�X�^.E�敪����
                + " CARMANAGEMENTRF.TRANSMISSIONNMRF, "               // ���q�Ǘ��}�X�^.�~�b�V��������
                + " CARMANAGEMENTRF.WHEELDRIVEMETHODNMRF, "               // ���q�Ǘ��}�X�^.�쓮��������
                + " CARMANAGEMENTRF.SHIFTNMRF, "               // ���q�Ǘ��}�X�^.�V�t�g����
                + " CARMANAGEMENTRF.ADDICARSPECTITLE1RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��1
                + " CARMANAGEMENTRF.ADDICARSPECTITLE2RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��2
                + " CARMANAGEMENTRF.ADDICARSPECTITLE3RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��3
                + " CARMANAGEMENTRF.ADDICARSPECTITLE4RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��4
                + " CARMANAGEMENTRF.ADDICARSPECTITLE5RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��5
                + " CARMANAGEMENTRF.ADDICARSPECTITLE6RF, "               // ���q�Ǘ��}�X�^.�ǉ������^�C�g��6
                + " CARMANAGEMENTRF.ADDICARSPEC1RF, "               // ���q�Ǘ��}�X�^.�ǉ�����1
                + " CARMANAGEMENTRF.ADDICARSPEC2RF, "               // ���q�Ǘ��}�X�^.�ǉ�����2
                + " CARMANAGEMENTRF.ADDICARSPEC3RF, "               // ���q�Ǘ��}�X�^.�ǉ�����3
                + " CARMANAGEMENTRF.ADDICARSPEC4RF, "               // ���q�Ǘ��}�X�^.�ǉ�����4
                + " CARMANAGEMENTRF.ADDICARSPEC5RF, "               // ���q�Ǘ��}�X�^.�ǉ�����5
                + " CARMANAGEMENTRF.ADDICARSPEC6RF, "               // ���q�Ǘ��}�X�^.�ǉ�����6
                + " MAKERURF.MAKERNAMERF, "                // ���[�J�[�}�X�^�i���[�U�[�o�^�j.���[�J�[����
                + " 0 AS SHIPMENTPOSCNTRF, "                   // 0.�o�׉\��
                + " CNVCARPARTSRF.ACPTANODRSTATUSRF " // ���q���i�f�[�^(�R���o�[�g).�󒍃X�e�[�^�X
                + " FROM "
                    // ���q���i�f�[�^(�R���o�[�g) WITH (READUNCOMMITTED)
                + " CNVCARPARTSRF WITH (READUNCOMMITTED) "
                    // INNER JOIN �󒍃}�X�^(���q) WITH (READUNCOMMITTED) ON (
                + " INNER JOIN ACCEPTODRCARRF WITH (READUNCOMMITTED) ON ( "
                    // ���q���i�f�[�^.��ƃR�[�h = �󒍃}�X�^(���q).��ƃR�[�h
                + " CNVCARPARTSRF.ENTERPRISECODERF = ACCEPTODRCARRF.ENTERPRISECODERF "
                    // ���q���i�f�[�^.�󒍔ԍ� = �󒍃}�X�^(���q).�󒍔ԍ�
                + " AND CNVCARPARTSRF.ACCEPTANORDERNORF = ACCEPTODRCARRF.ACCEPTANORDERNORF "
                    // ���q���i�f�[�^.�󒍃X�e�[�^�X = �󒍃}�X�^(���q).�󒍃X�e�[�^�X
                + " AND CNVCARPARTSRF.ACPTANODRSTATUSRF = ACCEPTODRCARRF.ACPTANODRSTATUSRF "
                    // ���q���i�f�[�^.�_���폜�敪 = �u0�F�L���v
                + " AND CNVCARPARTSRF.LOGICALDELETECODERF = 0 "
                    // �i ���q���i�f�[�^.�󒍃X�e�[�^�X = �u7�F����vOR ���q���i�f�[�^.�󒍃X�e�[�^�X = �u8�F�ԕi�v)
                + " AND (CNVCARPARTSRF.ACPTANODRSTATUSRF = 7 OR CNVCARPARTSRF.ACPTANODRSTATUSRF = 8) "
                    // ���q���i�f�[�^.��ƃR�[�h = ���O�C���S����.��ƃR�[�h
                + " AND CNVCARPARTSRF.ENTERPRISECODERF = @FINDENTERPRISECODE2RF ";
                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE2RF", SqlDbType.NChar);
                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.EnterpriseCode);

                // ���q���i�f�[�^.���ьv�㋒�_�R�[�h = ���.���_�R�[�h
                // ��ʓ��͗L�莞
                if (!"00".Equals(carInfoConditionWorkWork.SectionCode))
                {
                    sqlStr += " AND CNVCARPARTSRF.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraResultsAddUpSecCd2 = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD2RF", SqlDbType.NChar);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraResultsAddUpSecCd2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.SectionCode.Trim());
                }
                // ���q���i�f�[�^.������t >= ���.������i�J�n�j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.StSalesDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF >= @FINDSTSALESDATE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraStSalesDate2 = sqlCommand.Parameters.Add("@FINDSTSALESDATE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraStSalesDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StSalesDate);
                }
                // ���q���i�f�[�^.������t <= ���.������i�I���j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.EdSalesDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF <= @FINDEDSALESDATE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraEdSalesDate2 = sqlCommand.Parameters.Add("@FINDEDSALESDATE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraEdSalesDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdSalesDate);
                }
                // ���q���i�f�[�^.������t >= ���.���͓��i�J�n�j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.StInputDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF >= @FINDSTSEARCHSLIPDATE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraStInputDate2 = sqlCommand.Parameters.Add("@FINDSTSEARCHSLIPDATE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraStInputDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StInputDate);
                }
                // ���q���i�f�[�^.������t <= ���.���͓��i�I���j
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.EdInputDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF <= @FINDEDSEARCHSLIPDATE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraEdInputDate2 = sqlCommand.Parameters.Add("@FINDEDSEARCHSLIPDATE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraEdInputDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdInputDate);
                }
                // ���q���i�f�[�^.���Ӑ�R�[�h = ���.���Ӑ�R�[�h
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.CustomerCode != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.CUSTOMERCODERF = @FINDCUSTOMERCODE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCustomerCode2 = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCustomerCode2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CustomerCode);
                }
                // ���q���i�f�[�^.BL�O���[�v�R�[�h = ���.BL�O���[�v�R�[�h
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.BLGroupCode != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.BLGROUPCODERF = @FINDBLGROUPCODE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraBLGroupCode2 = sqlCommand.Parameters.Add("@FINDBLGROUPCODE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraBLGroupCode2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGroupCode);
                }
                // ���q���i�f�[�^.BL���i�R�[�h = ���.BL���i�R�[�h
                // ��ʓ��͗L�莞
                if (carInfoConditionWorkWork.BLGoodsCode != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.BLGOODSCODERF = @FINDBLGOODSCODE2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDBLGOODSCODE2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraBLGoodsCode2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGoodsCode);
                }
                // ��ʂ̍݌Ɏ��敪���u���v��I���̏ꍇ
                // ���q���i�f�[�^.����݌Ɏ�񂹋敪 = �u1�F�݌Ɂv
                if (carInfoConditionWorkWork.SalesOrderDivCd == 1)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESORDERDIVCDRF = 1 ";
                }
                // ��ʂ̍݌Ɏ��敪���u�݌Ɂv��I���̏ꍇ
                // ���q���i�f�[�^.����݌Ɏ�񂹋敪 = �u0�F���v
                else if (carInfoConditionWorkWork.SalesOrderDivCd == 2)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESORDERDIVCDRF = 0 ";
                }
                // ��ʂ̕i�������͗L�莞
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsName))
                {
                    // ��ʂ̕i�������敪���u�ƈ�v�v��I���̏ꍇ
                    // ���q���i�f�[�^.���i���� = ���.�i��
                    if (carInfoConditionWorkWork.GoodsNameDiv == 0)
                    {
                        // ���S��v�̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF = @FINDGOODSNAME2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim());
                    }
                    // ��ʂ̕i�������敪���u�Ŏn�܂�v��I���̏ꍇ
                    // ���q���i�f�[�^.���i���� LIKE ���.�i��+% 
                    else if (carInfoConditionWorkWork.GoodsNameDiv == 1)
                    {
                        // �O����v�̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF LIKE @FINDGOODSNAME2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim() + "%");
                    }
                    // ��ʂ̕i�������敪���u���܂ށv��I���̏ꍇ
                    // ���q���i�f�[�^.���i���� LIKE %+���.�i��+%
                    else if (carInfoConditionWorkWork.GoodsNameDiv == 2)
                    {
                        // �܂݂̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF LIKE @FINDGOODSNAME2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim() + "%");
                    }
                    // ��ʂ̕i�������敪���u�ŏI���v��I���̏ꍇ
                    // ���q���i�f�[�^.���i���� LIKE %+���.�i��
                    else
                    {
                        // �����v�̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF LIKE @FINDGOODSNAME2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim());
                    }
                }
                // ��ʂ̕i�Ԃ����͗L�莞
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsNo))
                {
                    // ��ʂ̕i�Ԍ����敪���u�ƈ�v�v��I���̏ꍇ
                    // ���q���i�f�[�^.���i�ԍ� = ���.�i��
                    if (carInfoConditionWorkWork.GoodsNoDiv == 0)
                    {
                        // ���S��v�̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF = @FINDGOODSNO2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim());
                    }
                    // ��ʂ̕i�Ԍ����敪���u�Ŏn�܂�v��I���̏ꍇ
                    // ���q���i�f�[�^.���i�ԍ� LIKE ���.�i��+% 
                    else if (carInfoConditionWorkWork.GoodsNoDiv == 1)
                    {
                        // �O����v�̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF LIKE @FINDGOODSNO2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                    }
                    // ��ʂ̕i�Ԍ����敪���u���܂ށv��I���̏ꍇ
                    // ���q���i�f�[�^.���i�ԍ� LIKE %+���.�i��+%
                    else if (carInfoConditionWorkWork.GoodsNoDiv == 2)
                    {
                        // �܂݂̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF LIKE @FINDGOODSNO2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                    }
                    // ��ʂ̕i�������敪���u�ŏI���v��I���̏ꍇ
                    // ���q���i�f�[�^.���i�ԍ� LIKE %+���.�i��
                    else
                    {
                        // �����v�̏ꍇ
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF LIKE @FINDGOODSNO2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim());
                    }
                }
                // �󒍃}�X�^(���q).�_���폜�敪 = �u0�F�L���v
                sqlStr += " AND ACCEPTODRCARRF.LOGICALDELETECODERF = 0 "
                // �󒍃}�X�^(���q).�f�[�^���̓V�X�e�� = �u10�FPM�v
                +" AND ACCEPTODRCARRF.DATAINPUTSYSTEMRF = 10 "
                // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� <> 0
                +" AND ACCEPTODRCARRF.CARMNGNORF <> 0 "
                // �󒍃}�X�^(���q).�_���폜�敪 = �u0�F�L���v
                +" AND ACCEPTODRCARRF.LOGICALDELETECODERF = 0 ";
                // �����ŕێ��̎ԗ��Ǘ��ԍ���0�̏ꍇ�A�󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� = ���.�ԗ��Ǘ��ԍ�
                if (carInfoConditionWorkWork.CarMngNo != 0)
                {
                    sqlStr += " AND ACCEPTODRCARRF.CARMNGNORF = @FINDCARMNGNO2RF ";
                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCarMngNo2 = sqlCommand.Parameters.Add("@FINDCARMNGNO2RF", SqlDbType.Int);
                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCarMngNo2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CarMngNo);
                }
                // ��ʂ̌^�������͗L�莞
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.FullModel))
                {
                    // ��ʂ̌^�������敪���u�ƈ�v�v��I���̏ꍇ
                    // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j = ���.�^��
                    if (carInfoConditionWorkWork.FullModelDiv == 0)
                    {
                        // ���S��v�̏ꍇ
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') = @FINDFULLMODEL2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraFullModel2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim());
                    }
                    // ��ʂ̌^�������敪���u�Ŏn�܂�v��I���̏ꍇ
                    // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j LIKE ���.�^��+% 
                    else if (carInfoConditionWorkWork.FullModelDiv == 1)
                    {
                        // �O����v�̏ꍇ
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODEL2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraFullModel2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim() + "%");
                    }
                    // ��ʂ̌^�������敪���u���܂ށv��I���̏ꍇ
                    // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j LIKE %+���.�^��+%
                    else if (carInfoConditionWorkWork.FullModelDiv == 2)
                    {
                        // �܂݂̏ꍇ
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODEL2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraFullModel2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim() + "%");
                    }
                    // ��ʂ̌^�������敪���u�ŏI���v��I���̏ꍇ
                    // �󒍃}�X�^�i�ԗ��j.�V���[�Y�^�� + '-' + �󒍃}�X�^�i�ԗ��j.�^���i�ޕʋL���j LIKE %+���.�^��
                    else
                    {
                        // �����v�̏ꍇ
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODEL2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraFullModel2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim());
                    }
                }
                // ��ʂ̎��q���l�����͗L�莞
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarNote))
                {
                    // ��ʂ̎��q���l�����敪���u�ƈ�v�v��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q���l = ���.���q���l
                    if (carInfoConditionWorkWork.CarNoteDiv == 0)
                    {
                        // ���S��v�̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF = @FINDCARNOTE2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarNote2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim());
                    }
                    // ��ʂ̎��q���l�����敪���u�Ŏn�܂�v��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q���l LIKE ���.���q���l+% 
                    else if (carInfoConditionWorkWork.CarNoteDiv == 1)
                    {
                        // �O����v�̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTE2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarNote2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim() + "%");
                    }
                    // ��ʂ̎��q���l�����敪���u���܂ށv��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q���l LIKE %+���.���q���l+%
                    else if (carInfoConditionWorkWork.CarNoteDiv == 2)
                    {
                        // �܂݂̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTE2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarNote2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim() + "%");
                    }
                    // ��ʂ̎��q���l�����敪���u�ŏI���v��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q���l LIKE %+���.���q���l
                    else
                    {
                        // �����v�̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTE2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarNote2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim());
                    }
                }
                // ��ʂ̊Ǘ��ԍ������͗L�莞
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarMngCode))
                {
                    // ��ʂ̊Ǘ��ԍ������敪���u�ƈ�v�v��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q�Ǘ��R�[�h = ���.�Ǘ��ԍ�
                    if (carInfoConditionWorkWork.CarMngCodeDiv == 0)
                    {
                        // ���S��v�̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF = @FINDCARMNGCODE2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim());
                    }
                    // ��ʂ̊Ǘ��ԍ������敪���u�Ŏn�܂�v��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q�Ǘ��R�[�h LIKE ���.�Ǘ��ԍ�+% 
                    else if (carInfoConditionWorkWork.CarMngCodeDiv == 1)
                    {
                        // �O����v�̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODE2RF ";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                    }
                    // ��ʂ̊Ǘ��ԍ������敪���u���܂ށv��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q�Ǘ��R�[�h LIKE %+���.�Ǘ��ԍ�+%
                    else if (carInfoConditionWorkWork.CarMngCodeDiv == 2)
                    {
                        // �܂݂̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODE2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                    }
                    // ��ʂ̊Ǘ��ԍ������敪���u�ŏI���v��I���̏ꍇ
                    // �󒍃}�X�^(���q).���q�Ǘ��R�[�h LIKE %+���.�Ǘ��ԍ�
                    else
                    {
                        // �����v�̏ꍇ
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODE2RF";
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim());
                    }
                }

                sqlStr += " ) ";

                // INNER JOIN ���q�Ǘ��}�X�^ WITH (READUNCOMMITTED) ON (
                sqlStr += " INNER JOIN CARMANAGEMENTRF WITH (READUNCOMMITTED) ON ( "
                    // ���q���i�f�[�^.��ƃR�[�h = ���q�Ǘ��}�X�^.��ƃR�[�h
                    + " CNVCARPARTSRF.ENTERPRISECODERF = CARMANAGEMENTRF.ENTERPRISECODERF "
                    // ���q���i�f�[�^.���Ӑ�R�[�h = ���q�Ǘ��}�X�^.���Ӑ�R�[�h
                    + " AND CNVCARPARTSRF.CUSTOMERCODERF = CARMANAGEMENTRF.CUSTOMERCODERF "
                    // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� = ���q�Ǘ��}�X�^.�ԗ��Ǘ��ԍ�
                    + " AND ACCEPTODRCARRF.CARMNGNORF = CARMANAGEMENTRF.CARMNGNORF "
                    // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� = ���q�Ǘ��}�X�^.�ԗ��Ǘ��ԍ� // 2009/12/24
                    + " AND ACCEPTODRCARRF.CARMNGCODERF = CARMANAGEMENTRF.CARMNGCODERF " // 2009/12/24
                    // ���q�Ǘ��}�X�^.�_���폜�敪 = �u0�F�L���v
                    + " AND CARMANAGEMENTRF.LOGICALDELETECODERF = 0) ";
                // LEFT JOIN ���[�J�[�}�X�^�i���[�U�[�o�^�j WITH (READUNCOMMITTED) ON (
                sqlStr += " LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ON ( "
                    // ���q���i�f�[�^.��ƃR�[�h = ���[�J�[�}�X�^�i���[�U�[�o�^�j.��ƃR�[�h
                    + " CNVCARPARTSRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF "
                    // ���q���i�f�[�^.���i���[�J�[�R�[�h = ���[�J�[�}�X�^�i���[�U�[�o�^�j.���i���[�J�[�R�[�h
                    + " AND CNVCARPARTSRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF "
                    // ���[�J�[�}�X�^�i���[�U�[�o�^�j.�_���폜�敪 = �u0�F�L���v
                    + " AND MAKERURF.LOGICALDELETECODERF = 0) ";
                // ��ʂ̕\���敪���u�o�ו��i�v�̎�
                // ORDER BY ������t�A���i���́A���i�ԍ��A���i���[�J�[�R�[�h
                if (carInfoConditionWorkWork.DispDiv == 1)
                {
                    //sqlStr += " ORDER BY 1, 4, 5, 6 ";// DEL 2009/10/20 Redmin#702�Ή�
                    //sqlStr += " ORDER BY 2,5, 6, 7 ";// ADD 2009/10/20 Redmin#702�Ή�  //DEL BY ������ on 2012/08/09 for Redmine#31532
                    sqlStr += " ORDER BY 2,11,5, 6, 7 "; //ADD BY ������ on 2012/08/09 for Redmine#31532
                }
                // ��ʂ̕\���敪���u�o�ו��i�i���v�j�v�̏ꍇ
                else
                {
                    //sqlStr += " ORDER BY 4, 5, 6, 7, 8, 9";// DEL 2009/10/20 Redmin#702�Ή�
                    sqlStr += " ORDER BY 5, 6, 7, 8, 9, 10";// ADD 2009/10/20 Redmin#702�Ή�
                }

                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                // ��ʂ̕\���敪���u�o�ו��i�v�̎�
                if (carInfoConditionWorkWork.DispDiv == 1)
                {
                    #region ��ʂ̕\���敪���u�o�ו��i�v�̎�
                    while (myReader.Read())
                    {
                        carShipmentPartsDispWork = new CarShipmentPartsDispWork();
                        carShipmentPartsDispWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF")); // ADD 2009/10/10
                        carShipmentPartsDispWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                        carShipmentPartsDispWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTERF"));
                        carShipmentPartsDispWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                        carShipmentPartsDispWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                        carShipmentPartsDispWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                        carShipmentPartsDispWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        carShipmentPartsDispWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        carShipmentPartsDispWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                        carShipmentPartsDispWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                        carShipmentPartsDispWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                        carShipmentPartsDispWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                        carShipmentPartsDispWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                        carShipmentPartsDispWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                        carShipmentPartsDispWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                        carShipmentPartsDispWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));
                        carShipmentPartsDispWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        carShipmentPartsDispWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
                        carShipmentPartsDispWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                        carShipmentPartsDispWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                        carShipmentPartsDispWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                        carShipmentPartsDispWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                        carShipmentPartsDispWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                        carShipmentPartsDispWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                        carShipmentPartsDispWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                        carShipmentPartsDispWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                        carShipmentPartsDispWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                        carShipmentPartsDispWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                        carShipmentPartsDispWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                        carShipmentPartsDispWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                        carShipmentPartsDispWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                        carShipmentPartsDispWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
                        carShipmentPartsDispWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                        carShipmentPartsDispWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                        carShipmentPartsDispWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                        carShipmentPartsDispWork.EngineModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELRF"));
                        carShipmentPartsDispWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                        carShipmentPartsDispWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));
                        carShipmentPartsDispWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                        carShipmentPartsDispWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                        carShipmentPartsDispWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                        carShipmentPartsDispWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                        carShipmentPartsDispWork.AddiCarSpec1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC1RF"));
                        carShipmentPartsDispWork.AddiCarSpec2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC2RF"));
                        carShipmentPartsDispWork.AddiCarSpec3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC3RF"));
                        carShipmentPartsDispWork.AddiCarSpec4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC4RF"));
                        carShipmentPartsDispWork.AddiCarSpec5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC5RF"));
                        carShipmentPartsDispWork.AddiCarSpec6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC6RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE1RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE2RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE3RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE4RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE5RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE6RF"));
                        carShipmentPartsDispWork.StProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));
                        carShipmentPartsDispWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));
                        carShipmentPartsDispWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                        carShipmentPartsDispWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                        carShipmentPartsDispWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                        carShipmentPartsDispWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                        carShipmentPartsDispWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                        carShipmentPartsDispWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        carShipmentPartsDispWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
                        carShipmentPartsDispWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                        carShipmentPartsDispWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                        carShipmentPartsDispWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                        carShipmentPartsDispWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                        carShipmentPartsDispWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                        carShipmentPartsDispWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                        carShipmentPartsDispWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                        carShipmentPartsDispWork.RowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));//ADD BY �����@on 2012/08/09 for Redmine#31532
                        carShipmentPartsDispWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));// ADD 2013/03/25
                        carManagementList.Add(carShipmentPartsDispWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion
                }
                // ��ʂ̕\���敪���u�o�ו��i�i���v�j�v�̏ꍇ
                else
                {
                    #region ��ʂ̕\���敪���u�o�ו��i�i���v�j�v�̏ꍇ
                    ArrayList tempList = new ArrayList();
                    CarShipmentPartsDispWork dispWork = null;
                    while (myReader.Read())
                    {
                        dispWork = new CarShipmentPartsDispWork();
                        dispWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                        dispWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                        dispWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                        dispWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        dispWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        dispWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                        dispWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                        dispWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                        dispWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                        dispWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                        dispWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                        dispWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                        dispWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                        dispWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        dispWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                        dispWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        dispWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        dispWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                        tempList.Add(dispWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }


                    if (tempList.Count > 0)
                    {

                        string goodsName = string.Empty;
                        string goodsNo = string.Empty;
                        int goodsMakerCd = 0;
                        int blGoodsCode = 0;
                        // ����`�[�ԍ�
                        string salesSlipNum = string.Empty;
                        // �󒍃X�e�[�^�X
                        int acptAnOdrStatus = 0;
                        string warehouseCode = string.Empty;
                        // �I��
                        string warehouseShelfNo = string.Empty;
                        // ������z
                        long salesMoneyTaxExc = 0;
                        // �o�א�
                        double shipmentCnt = 0;
                        // �o�׉�
                        int shipmentCntTotal = 0;
                        // ����݌Ɏ�񂹋敪��[0:���]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                        double shipmentCntInTotal = 0;
                        // ����݌Ɏ�񂹋敪��[1:�݌�]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                        double shipmentCntOutTotal = 0;

                        // ���[�J�[����
                        string makerName = string.Empty;
                        // �q��
                        string warehouseName = string.Empty;
                        // ���݌ɐ�
                        double shipmentPosCnt = 0;

                        for (int i = 0; i < tempList.Count; i++)
                        {
                            CarShipmentPartsDispWork tempWork = (CarShipmentPartsDispWork)tempList[i];
                            if (i == 0)
                            {
                                // �󒍃X�e�[�^�X
                                acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                // ����`�[�ԍ�
                                salesSlipNum = tempWork.SalesSlipNum;
                                // �i��
                                goodsName = tempWork.GoodsName;
                                // �i��
                                goodsNo = tempWork.GoodsNo;
                                // ���[�J�[�R�[�h
                                goodsMakerCd = tempWork.GoodsMakerCd;
                                // BL�R�[�h
                                blGoodsCode = tempWork.BLGoodsCode;
                                // �q�ɃR�[�h
                                warehouseCode = tempWork.WarehouseCode;
                                // �I��
                                warehouseShelfNo = tempWork.WarehouseShelfNo;
                                // ������z
                                salesMoneyTaxExc = tempWork.SalesMoneyTaxExc;
                                // �o�א�
                                shipmentCnt = tempWork.ShipmentCnt;
                                //---------UPD 2009/10/23--------->>>>>
                                // �ԕi
                                if ((tempWork.SalesSlipCdDtl == 1) || (tempWork.AcptAnOdrStatus == 8))
                                {
                                    // �o�׉�
                                    shipmentCntTotal = -1;
                                }
                                // ����
                                else
                                {
                                    // �o�׉�
                                    shipmentCntTotal = 1;
                                }
                                //---------UPD 2009/10/23---------<<<<<
                                // ����݌Ɏ�񂹋敪��[0:���]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                                if (tempWork.SalesOrderDivCd == 0)
                                {
                                    shipmentCntOutTotal = tempWork.ShipmentCnt;
                                }
                                // ����݌Ɏ�񂹋敪��[1:�݌�]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                                else if (tempWork.SalesOrderDivCd == 1)
                                {
                                    shipmentCntInTotal = tempWork.ShipmentCnt;
                                }
                                // ���[�J�[
                                makerName = tempWork.MakerName;
                                // �q��
                                warehouseName = tempWork.WarehouseName;
                                // ���݌ɐ�
                                shipmentPosCnt = tempWork.ShipmentPosCnt;
                            }
                            else
                            {
                                if (goodsName.Equals(tempWork.GoodsName)
                                    && goodsNo.Equals(tempWork.GoodsNo)
                                    && goodsMakerCd == tempWork.GoodsMakerCd
                                    && blGoodsCode == tempWork.BLGoodsCode
                                    && warehouseCode.Equals(tempWork.WarehouseCode)
                                    && warehouseShelfNo.Equals(tempWork.WarehouseShelfNo))
                                {
                                    // ������z
                                    salesMoneyTaxExc = salesMoneyTaxExc + tempWork.SalesMoneyTaxExc;
                                    // �o�א�
                                    shipmentCnt = shipmentCnt + tempWork.ShipmentCnt;
                                    //--------UPD  2009/10/23------>>>>>
                                    //if (!acptAnOdrStatus.Equals(tempWork.AcptAnOdrStatus) || !salesSlipNum.Equals(tempWork.SalesSlipNum))
                                    //{
                                    // �ԕi
                                    if ((tempWork.SalesSlipCdDtl == 1) || (tempWork.AcptAnOdrStatus == 8))
                                    {
                                        // �o�׉�
                                        shipmentCntTotal = shipmentCntTotal - 1;
                                        acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                        salesSlipNum = tempWork.SalesSlipNum;
                                    }
                                    // ����
                                    else
                                    {
                                        // �o�׉�
                                        shipmentCntTotal = shipmentCntTotal + 1;
                                        acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                        salesSlipNum = tempWork.SalesSlipNum;
                                    }
                                    //}
                                    //--------UPD  2009/10/23------>>>>>
                                    // ����݌Ɏ�񂹋敪��[0:���]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                                    if (tempWork.SalesOrderDivCd == 0)
                                    {
                                        shipmentCntOutTotal += tempWork.ShipmentCnt;
                                    }
                                    // ����݌Ɏ�񂹋敪��[1:�݌�]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                                    else if (tempWork.SalesOrderDivCd == 1)
                                    {
                                        shipmentCntInTotal += tempWork.ShipmentCnt;
                                    }
                                }
                                else
                                {
                                    carShipmentPartsDispWork = new CarShipmentPartsDispWork();
                                    // �i��
                                    carShipmentPartsDispWork.GoodsName = goodsName;
                                    // �i��
                                    carShipmentPartsDispWork.GoodsNo = goodsNo;
                                    carShipmentPartsDispWork.GoodsMakerCd = goodsMakerCd;
                                    // ���[�J�[
                                    carShipmentPartsDispWork.MakerName = makerName;
                                    // --- UPD 2009/09/08 -------------->>>
                                    // BL�R�[�h
                                    carShipmentPartsDispWork .BLGoodsCode= blGoodsCode;
                                    // --- UPD 2009/09/08 --------------<<<
                                    // ������z
                                    carShipmentPartsDispWork.SalesMoneyTaxExcTotal = salesMoneyTaxExc;
                                    // ����
                                    carShipmentPartsDispWork.ShipmentTotalCnt = shipmentCnt;
                                    // �o�׉�
                                    carShipmentPartsDispWork.ShipmentCntTotal = shipmentCntTotal;
                                    // �q��
                                    carShipmentPartsDispWork.WarehouseName = warehouseName;
                                    carShipmentPartsDispWork.WarehouseCode = warehouseCode;
                                    // �I��
                                    carShipmentPartsDispWork.WarehouseShelfNo = warehouseShelfNo;
                                    // ���݌ɐ�
                                    carShipmentPartsDispWork.ShipmentPosCnt = shipmentPosCnt;
                                    // ���ʁi�݌Ɂj
                                    carShipmentPartsDispWork.ShipmentCntInTotal = shipmentCntInTotal;
                                    // ���ʁi���j
                                    carShipmentPartsDispWork.ShipmentCntOutTotal = shipmentCntOutTotal;

                                    carManagementList.Add(carShipmentPartsDispWork);
                                    // �N���A
                                    shipmentCntOutTotal = 0;
                                    shipmentCntInTotal = 0;

                                    // �󒍃X�e�[�^�X
                                    acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                    // ����`�[�ԍ�
                                    salesSlipNum = tempWork.SalesSlipNum;
                                    // �i��
                                    goodsName = tempWork.GoodsName;
                                    // �i��
                                    goodsNo = tempWork.GoodsNo;
                                    // ���[�J�[�R�[�h
                                    goodsMakerCd = tempWork.GoodsMakerCd;
                                    // BL�R�[�h
                                    blGoodsCode = tempWork.BLGoodsCode;
                                    // �q�ɃR�[�h
                                    warehouseCode = tempWork.WarehouseCode;
                                    // ������z
                                    salesMoneyTaxExc = tempWork.SalesMoneyTaxExc;
                                    // �o�א�
                                    shipmentCnt = tempWork.ShipmentCnt;
                                    //----------UPD 2009/10/23---------->>>>>
                                    // �ԕi
                                    if ((tempWork.SalesSlipCdDtl == 1) || (tempWork.AcptAnOdrStatus == 8))
                                    {
                                        // �o�׉�
                                        shipmentCntTotal = -1;
                                    }
                                    else
                                    {
                                        // �o�׉�
                                        shipmentCntTotal = 1;
                                    }
                                    //----------UPD 2009/10/23----------<<<<<
                                        // ����݌Ɏ�񂹋敪��[0:���]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                                    if (tempWork.SalesOrderDivCd == 0)
                                    {
                                        shipmentCntOutTotal = tempWork.ShipmentCnt;
                                    }
                                    // ����݌Ɏ�񂹋敪��[1:�݌�]�̔��㗚�𖾍׃f�[�^.�o�א��̍��v
                                    else if (tempWork.SalesOrderDivCd == 1)
                                    {
                                        shipmentCntInTotal = tempWork.ShipmentCnt;
                                    }
                                    // ���[�J�[
                                    makerName = tempWork.MakerName;
                                    // �q��
                                    warehouseName = tempWork.WarehouseName;
                                    // �I��
                                    warehouseShelfNo = tempWork.WarehouseShelfNo;
                                    // ���݌ɐ�
                                    shipmentPosCnt = tempWork.ShipmentPosCnt;
                                }
                            }

                            if (i == tempList.Count - 1)
                            {
                                carShipmentPartsDispWork = new CarShipmentPartsDispWork();
                                // �i��
                                carShipmentPartsDispWork.GoodsName = goodsName;
                                // �i��
                                carShipmentPartsDispWork.GoodsNo = goodsNo;
                                // ���[�J�[
                                carShipmentPartsDispWork.GoodsMakerCd = goodsMakerCd;
                                carShipmentPartsDispWork.MakerName = makerName;
                                // --- UPD 2009/09/08 -------------->>>
                                // BL�R�[�h
                                carShipmentPartsDispWork.BLGoodsCode = blGoodsCode;
                                // --- UPD 2009/09/08 --------------<<<
                                // ������z
                                carShipmentPartsDispWork.SalesMoneyTaxExcTotal = salesMoneyTaxExc;
                                // ����
                                carShipmentPartsDispWork.ShipmentTotalCnt = shipmentCnt;
                                // �o�׉�
                                carShipmentPartsDispWork.ShipmentCntTotal = shipmentCntTotal;
                                // �q��
                                carShipmentPartsDispWork.WarehouseName = warehouseName;
                                carShipmentPartsDispWork.WarehouseCode = warehouseCode;
                                // �I��
                                carShipmentPartsDispWork.WarehouseShelfNo = warehouseShelfNo;
                                // ���݌ɐ�
                                carShipmentPartsDispWork.ShipmentPosCnt = shipmentPosCnt;
                                // ���ʁi�݌Ɂj
                                carShipmentPartsDispWork.ShipmentCntInTotal = shipmentCntInTotal;
                                // ���ʁi���j
                                carShipmentPartsDispWork.ShipmentCntOutTotal = shipmentCntOutTotal;

                                carManagementList.Add(carShipmentPartsDispWork);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (SqlException e)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(e, errmsg, e.Number);
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "CarShipmentPartsDispDB.CarInfoSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion
    }
}
