//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�׎��ѕ\
// �v���O�����T�v   : �^���ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//Update Note : 2010/05/07 ���C�� redmine #7001
//              �^���ʏo�בΉ��\�̎󒍃X�e�[�^�X�ɂ��āA�d�l�̕ύX
//Update Note : 2010/05/13 ���C�� redmine #7109
//              �Q�_�d�l�ύX�̑Ή�
//Update Note : 2010/05/16 ���C�� redmine #7109
//              �I�Ԃƌ��݌ɐ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhshh
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note : 2010.05.19 zhangsf Redmine #7784�̑Ή�
//             : �E�^���ʏo�בΉ��\�^�e��C��
//----------------------------------------------------------------------------//
// Update Note : 2014/11/20 wujun
// �Ǘ��ԍ�    : 11002003-00   Redmine#43035 #52������Q�̑Ή�
//             : �`�[��񂪑S�����l�ȓ`�[���������݂����ꍇ�A�W�v���ʕs���̑Ή�
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
    /// �^���ʏo�׎��ѕ\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ʏo�׎��ѕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : zhshh</br>
    /// <br>Date       : 2010.04.22</br>
    /// </remarks>
    [Serializable]
    public class ModelShipResultDB : RemoteDB, IModelShipResultDB
    {
        /// <summary>
        /// �^���ʏo�׎��ѕ\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public ModelShipResultDB()
            :
        base("PMSYA02209D", "Broadleaf.Application.Remoting.ParamData.ModelShipResultWork", "MODELSHIPRESULTWORK") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̌^���ʏo�׎��ѕ\��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="modelShipRsltCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̌^���ʏo�׃f�[�^��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/08 ���C�� REDMINE #7109�̑Ή�</br>
        public int Search(out object modelShipResultWork, object modelShipRsltCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            modelShipResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                status = SearchProc(out modelShipResultWork, modelShipRsltCndtnWork, ref sqlConnection);

                // --- DEL 2010/05/08 ---------->>>>>
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    //�Ή��i�Ԃ̎擾
                //    status = SearchGoodNoProc(ref modelShipResultWork, modelShipRsltCndtnWork, ref sqlConnection);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //    }
                //}
                // --- DEL 2010/05/08 ----------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ModelShipResultDB.Search");
                modelShipResultWork = new ArrayList();
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

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̌^���ʏo�׎��ѕ\��S�Ė߂��܂�
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="_modelShipRsltCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/16 ���C�� �݌Ƀ}�X�^��ǂݍ��ޏ����̒ǉ�</br>
        /// <br>Update Note: 2014/11/20 wujun</br>
        /// <br>�Ǘ��ԍ�   : 11002003-00�@RedMine#43035 #52������Q�̑Ή�</br>
        /// <br>         �@: �`�[��񂪑S�����l�ȓ`�[���������݂����ꍇ�A�W�v���ʕs���̑Ή�</br>
        private int SearchProc(out object modelShipResultWork, object _modelShipRsltCndtnWork, ref SqlConnection sqlConnection)
        {
            ModelShipRsltCndtnWork modelShipRsltCndtnWork = _modelShipRsltCndtnWork as ModelShipRsltCndtnWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            modelShipResultWork = new ArrayList();
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" AA.SALESSLIPNUMRF SALESSLIPNUMRF, ");//����`�[�ԍ�  //  ADD 2014/11/20 wujun FOR Redmine#43035
                sb.Append(" AA.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");//���ьv�㋒�_�R�[�h
                sb.Append(" AA.SALESDATERF SALESDATERF, ");//������t
                sb.Append(" AB.SALESROWNORF SALESROWNORF, ");//����s�ԍ�			
                sb.Append(" AB.GOODSKINDCODERF GOODSKINDCODERF, ");//���i����			
                sb.Append(" AB.GOODSMAKERCDRF GOODSMAKERCDRF, ");//���i���[�J�[�R�[�h			
                sb.Append(" AB.GOODSNORF GOODSNORF, ");//���i�ԍ�			
                sb.Append(" AB.GOODSNAMEKANARF GOODSNAMERF, ");//���i���̃J�i			
                sb.Append(" AB.BLGOODSCODERF BLGOODSCODERF, ");//BL���i�R�[�h			
                sb.Append(" AB.SALESUNPRCTAXEXCFLRF SALESUNPRCTAXEXCFLRF, ");//����P���i�Ŕ��C�����j			
                sb.Append(" AB.SHIPMENTCNTRF SHIPMENTCNTRF, ");//�o�א�			
                sb.Append(" AB.SALESORDERDIVCDRF SALESORDERDIVCDRF, ");//����݌Ɏ�񂹋敪			
                sb.Append(" AB.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, ");//������z�i�Ŕ����j			
                sb.Append(" SECINFOSETRF.SECTIONGUIDESNMRF SECTIONGUIDESNMRF, ");//���_�K�C�h����					
                sb.Append(" BLGOODSCDURF.BLGOODSHALFNAMERF BLGOODSHALFNAMERF, ");//BL���i�R�[�h���́i���p�j	
                sb.Append(" AC.CARMNGNORF CARMNGNORF, ");//�ԗ��Ǘ��ԍ�			
                sb.Append(" AC.MAKERCODERF MAKERCODERF, ");//���[�J�[�R�[�h			
                sb.Append(" AC.MODELCODERF MODELCODERF, ");//�Ԏ�R�[�h			
                sb.Append(" AC.MODELSUBCODERF MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h			
                sb.Append(" AC.MODELHALFNAMERF MODELHALFNAMERF, ");//�Ԏ피�p����			
                sb.Append(" AC.SERIESMODELRF SERIESMODELRF, ");//�V���[�Y�^��			
                sb.Append(" AC.CATEGORYSIGNMODELRF CATEGORYSIGNMODELRF, ");//�^���i�ޕʔԍ��j			
                sb.Append(" AC.FULLMODELRF FULLMODELRF, ");//�^���i�t���j
                // --- ADD 2010/05/16 ---------->>>>>
                sb.Append(" STOCKRF.SUPPLIERSTOCKRF SUPPLIERSTOCKRF, ");//���݌ɐ�
                sb.Append(" STOCKRF.WAREHOUSESHELFNORF WAREHOUSESHELFNORF, ");//�I��
                // --- ADD 2010/05/16 ----------<<<<<
                sb.Append(" MAKERURF.MAKERNAMERF MAKERNAMERF ");//���[�J�[����(����)

                sb.Append(" FROM ");
                //���㗚���f�[�^
                sb.Append(" SALESHISTORYRF AA WITH (READUNCOMMITTED) ");
                //���_���ݒ�}�X�^
                sb.Append(" LEFT JOIN SECINFOSETRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON SECINFOSETRF.ENTERPRISECODERF = AA.ENTERPRISECODERF ");
                sb.Append(" AND SECINFOSETRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND SECINFOSETRF.SECTIONCODERF=AA.RESULTSADDUPSECCDRF ");
                //���㗚�𖾍׃f�[�^
                sb.Append(" ,SALESHISTDTLRF AB WITH (READUNCOMMITTED) ");

                //�a�k���i�R�[�h�}�X�^(���[�U�[)
                sb.Append(" LEFT JOIN BLGOODSCDURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON BLGOODSCDURF.ENTERPRISECODERF=AB.ENTERPRISECODERF ");
                sb.Append(" AND BLGOODSCDURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND BLGOODSCDURF.BLGOODSCODERF=AB.BLGOODSCODERF ");
                //���[�J�[�}�X�^
                sb.Append(" LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON MAKERURF.ENTERPRISECODERF=AB.ENTERPRISECODERF ");
                sb.Append(" AND MAKERURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND MAKERURF.GOODSMAKERCDRF=AB.GOODSMAKERCDRF ");
                // --- ADD 2010/05/16 ---------->>>>>
                //�݌Ƀ}�X�^
                sb.Append(" LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON STOCKRF.ENTERPRISECODERF=AB.ENTERPRISECODERF ");
                sb.Append(" AND STOCKRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND STOCKRF.GOODSMAKERCDRF=AB.GOODSMAKERCDRF ");
                sb.Append(" AND STOCKRF.GOODSNORF=AB.GOODSNORF ");
                sb.Append(" AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                // --- ADD 2010/05/16 ----------<<<<<
                //�󒍃}�X�^(���q)
                sb.Append(" ,ACCEPTODRCARRF AC WITH (READUNCOMMITTED) ");

                sb.Append(MakeWhereStringA(ref sqlCommand, modelShipRsltCndtnWork));

                sb.Append(" UNION ");

                sb.Append("SELECT ");
                sb.Append(" CN.SALESSLIPNUMRF SALESSLIPNUMRF, ");//����`�[�ԍ�  //  ADD 2014/11/20 wujun FOR Redmine#43035
                sb.Append(" CN.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");//���ьv�㋒�_�R�[�h
                sb.Append(" CN.SALESDATERF SALESDATERF, ");//������t
                sb.Append(" CN.SALESROWNORF SALESROWNORF, ");//����s�ԍ�			
                sb.Append(" CN.GOODSKINDCODERF GOODSKINDCODERF, ");//���i����			
                sb.Append(" CN.GOODSMAKERCDRF GOODSMAKERCDRF, ");//���i���[�J�[�R�[�h			
                sb.Append(" CN.GOODSNORF GOODSNORF, ");//���i�ԍ�			
                sb.Append(" CN.GOODSNAMERF GOODSNAMERF, ");//���i����			
                sb.Append(" CN.BLGOODSCODERF BLGOODSCODERF, ");//BL���i�R�[�h			
                sb.Append(" CN.SALESUNPRCTAXEXCFLRF SALESUNPRCTAXEXCFLRF, ");//����P���i�Ŕ��C�����j			
                sb.Append(" CN.SHIPMENTCNTRF SHIPMENTCNTRF, ");//�o�א�			
                sb.Append(" CN.SALESORDERDIVCDRF SALESORDERDIVCDRF, ");//����݌Ɏ�񂹋敪			
                sb.Append(" CN.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, ");//������z�i�Ŕ����j			
                sb.Append(" SECINFOSETRF.SECTIONGUIDESNMRF SECTIONGUIDESNMRF, ");//���_�K�C�h����					
                sb.Append(" BLGOODSCDURF.BLGOODSHALFNAMERF BLGOODSHALFNAMERF, ");//BL���i�R�[�h���́i���p�j	
                sb.Append(" AC.CARMNGNORF CARMNGNORF, ");//�ԗ��Ǘ��ԍ�			
                sb.Append(" AC.MAKERCODERF MAKERCODERF, ");//���[�J�[�R�[�h			
                sb.Append(" AC.MODELCODERF MODELCODERF, ");//�Ԏ�R�[�h			
                sb.Append(" AC.MODELSUBCODERF MODELSUBCODERF, ");//�Ԏ�T�u�R�[�h			
                sb.Append(" AC.MODELHALFNAMERF MODELHALFNAMERF, ");//�Ԏ피�p����			
                sb.Append(" AC.SERIESMODELRF SERIESMODELRF, ");//�V���[�Y�^��			
                sb.Append(" AC.CATEGORYSIGNMODELRF CATEGORYSIGNMODELRF, ");//�^���i�ޕʔԍ��j			
                sb.Append(" AC.FULLMODELRF FULLMODELRF, ");//�^���i�t���j
                // --- ADD 2010/05/16 ---------->>>>>
                sb.Append(" STOCKRF.SUPPLIERSTOCKRF SUPPLIERSTOCKRF, ");//���݌ɐ�
                sb.Append(" STOCKRF.WAREHOUSESHELFNORF WAREHOUSESHELFNORF, ");//�I��
                // --- ADD 2010/05/16 ----------<<<<<
                sb.Append(" MAKERURF.MAKERNAMERF MAKERNAMERF ");//���[�J�[����(����)

                sb.Append(" FROM ");
                //�󒍃}�X�^(���q)
                sb.Append(" ACCEPTODRCARRF AC WITH (READUNCOMMITTED), ");
                //���q���i�f�[�^(�R���o�[�g)
                sb.Append(" CNVCARPARTSRF CN WITH (READUNCOMMITTED) ");
                //���_���ݒ�}�X�^
                sb.Append(" LEFT JOIN SECINFOSETRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON SECINFOSETRF.ENTERPRISECODERF = CN.ENTERPRISECODERF ");
                sb.Append(" AND SECINFOSETRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND SECINFOSETRF.SECTIONCODERF=CN.RESULTSADDUPSECCDRF ");
                //�a�k���i�R�[�h�}�X�^(���[�U�[)
                sb.Append(" LEFT JOIN BLGOODSCDURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON BLGOODSCDURF.ENTERPRISECODERF=CN.ENTERPRISECODERF ");
                sb.Append(" AND BLGOODSCDURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND BLGOODSCDURF.BLGOODSCODERF=CN.BLGOODSCODERF ");
                //���[�J�[�}�X�^
                sb.Append(" LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON MAKERURF.ENTERPRISECODERF=CN.ENTERPRISECODERF ");
                sb.Append(" AND MAKERURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND MAKERURF.GOODSMAKERCDRF=CN.GOODSMAKERCDRF ");
                // --- ADD 2010/05/16 ---------->>>>>
                //�݌Ƀ}�X�^
                sb.Append(" LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON STOCKRF.ENTERPRISECODERF=CN.ENTERPRISECODERF ");
                sb.Append(" AND STOCKRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND STOCKRF.GOODSMAKERCDRF=CN.GOODSMAKERCDRF ");
                sb.Append(" AND STOCKRF.GOODSNORF=CN.GOODSNORF ");
                sb.Append(" AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                // --- ADD 2010/05/16 ----------<<<<<

                sb.Append(MakeWhereStringB(ref sqlCommand, modelShipRsltCndtnWork));

                // ��ʂ̏W�v���@���u�S�Ёv��I���̏ꍇ
                if (modelShipRsltCndtnWork.GroupBySectionDiv == 0)
                {
                    //�Ԏ탁�[�J�[�A�Ԏ�R�[�h�A�Ԏ�T�u�R�[�h�A�t���^���A�a�k�R�[�h�A�o�׃��[�J�[�A�o�וi��
                    sb.Append(" ORDER BY ");
                    sb.Append(" MAKERCODERF, ");
                    sb.Append(" MODELCODERF, ");
                    sb.Append(" MODELSUBCODERF, ");
                    sb.Append(" FULLMODELRF, ");
                    sb.Append(" BLGOODSCODERF, ");
                    sb.Append(" GOODSMAKERCDRF, ");
                    sb.Append(" GOODSNORF ");

                }
                // ��ʂ̏W�v���@���u���_���v��I���̏ꍇ
                else if (modelShipRsltCndtnWork.GroupBySectionDiv == 1)
                {
                    //���ьv�㋒�_�R�[�h�A�Ԏ탁�[�J�[�A�Ԏ�R�[�h�A�Ԏ�T�u�R�[�h�A�t���^���A�a�k�R�[�h�A�o�׃��[�J�[�A�o�וi��
                    sb.Append(" ORDER BY ");
                    sb.Append(" RESULTSADDUPSECCDRF, ");
                    sb.Append(" MAKERCODERF, ");
                    sb.Append(" MODELCODERF, ");
                    sb.Append(" MODELSUBCODERF, ");
                    sb.Append(" FULLMODELRF, ");
                    sb.Append(" BLGOODSCODERF, ");
                    sb.Append(" GOODSMAKERCDRF, ");
                    sb.Append(" GOODSNORF ");
                }

                // --- ADD 2010/05/13 ---------->>>>>
                //�q�ɃR�[�h
                SqlParameter Para_WarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Char);
                Para_WarehouseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.WarehouseCode);
                // --- ADD 2010/05/13 ----------<<<<<

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    ModelShipResultWork wkModelShipResultWork = new ModelShipResultWork();

                    //�d���f�[�^���ʎ擾���e�i�[
                    wkModelShipResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkModelShipResultWork.SalesDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkModelShipResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkModelShipResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    wkModelShipResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkModelShipResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkModelShipResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkModelShipResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkModelShipResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    wkModelShipResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkModelShipResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkModelShipResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkModelShipResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkModelShipResultWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    wkModelShipResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    wkModelShipResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    wkModelShipResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    wkModelShipResultWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    wkModelShipResultWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                    wkModelShipResultWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                    wkModelShipResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    wkModelShipResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkModelShipResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    // --- ADD 2010/05/16 ---------->>>>>
                    //�d���݌ɐ�
                    wkModelShipResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    //�q�ɒI��
                    wkModelShipResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    // --- ADD 2010/05/16 ----------<<<<<
                    #endregion

                    al.Add(wkModelShipResultWork);
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

            modelShipResultWork = al;

            return status;
        }

        // --- ADD 2010/05/08 ---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ���S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="enterpriseCode">�����p�����[�^</param>
        /// <param name="warehouseCode">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��f�[�^��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010.05.08</br>
        //public int SearchStock(ref object modelShipResultWorkObject, string warehouseCode)//DEL 2010/05/13
        public int SearchStock(ref object modelShipResultWorkObject, string enterpriseCode, string warehouseCode)//ADD 2010/05/13
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                //status = SearchStockProc(ref modelShipResultWorkObject, warehouseCode, ref sqlConnection);//DEL 2010/05/13
                status = SearchStockProc(ref modelShipResultWorkObject, enterpriseCode, warehouseCode, ref sqlConnection);//ADD 2010/05/13
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ModelShipResultDB.SearchStock");
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

            return status;
        }

        /// <summary>
        /// �d���݌ɐ��Ƒq�ɒI�Ԃ̎擾
        /// </summary>
        /// <param name="modelShipResultWorkObject">��������</param>
        /// <param name="enterpriseCode">�����p�����[�^</param>
        /// <param name="warehouseCode">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���݌ɐ��Ƒq�ɒI�Ԃ��擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010.05.08</br>
        /// <br>Update Note: 2010/05/13 ���C�� �݌Ƀ}�X�^�̃`�F�b�N��Q�̑Ή�</br>
        //private int SearchStockProc(ref object modelShipResultWorkObject, string warehouseCode, ref SqlConnection sqlConnection)//DEL 2010/05/13
        private int SearchStockProc(ref object modelShipResultWorkObject, string enterpriseCode, string warehouseCode, ref SqlConnection sqlConnection)//ADD 2010/05/13
        {
            ArrayList modelShipResultWorkList = modelShipResultWorkObject as ArrayList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- ADD 2010/05/13 ---------->>>>>
            //ModelShipResultWork newWork = null;//DEL 2010/05/16
            bool isFind = false;
            // --- ADD 2010/05/13 ----------<<<<<

            foreach (ModelShipResultWork modelShipResultWorkTmp in modelShipResultWorkList)
            {
                // --- DEL 2010/05/13 ---------->>>>>
                ////���i��ʂ� 0:�����A�q�ɃR�[�h���P�ȏ�̏ꍇ
                //if (modelShipResultWorkTmp.GoodsKindCode != 0 
                //    || warehouseCode.CompareTo("000001") < 0 
                //    || modelShipResultWorkTmp.JoinDestMakerCd == 0 
                //    || string.IsNullOrEmpty(modelShipResultWorkTmp.JoinDestPartsNo))
                //{
                //    continue;
                //}
                // --- DEL 2010/05/13 ----------<<<<<
                try
                {
                    sqlCommand = new SqlCommand("", sqlConnection);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT ");
                    sb.Append("SUPPLIERSTOCKRF, ");
                    // --- UPD 2010/05/13 ---------->>>>>
                    sb.Append("WAREHOUSESHELFNORF ");
                    //sb.Append("WAREHOUSESHELFNORF, ");
                    //sb.Append("MAKERNAMERF ");
                    // --- UPD 2010/05/13 ----------<<<<<
                    sb.Append("FROM ");
                    sb.Append("STOCKRF WITH (READUNCOMMITTED) ");
                    // --- DEL 2010/05/13 ---------->>>>>
                    //sb.Append("LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
                    //sb.Append("ON MAKERURF.ENTERPRISECODERF=STOCKRF.ENTERPRISECODERF ");
                    //sb.Append("AND MAKERURF.LOGICALDELETECODERF=0 ");
                    //sb.Append("AND MAKERURF.GOODSMAKERCDRF=STOCKRF.GOODSMAKERCDRF ");
                    // --- DEL 2010/05/13 ----------<<<<<
                    sb.Append("WHERE ");
                    sb.Append("STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sb.Append("AND STOCKRF.LOGICALDELETECODERF=0 ");
                    sb.Append("AND STOCKRF.SUPPLIERSTOCKRF>0 ");
                    sb.Append("AND STOCKRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD ");
                    sb.Append("AND STOCKRF.GOODSNORF=@FINDGOODSNO ");
                    sb.Append("AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");

                    //��ƃR�[�h
                    SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
                    //Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.EnterpriseCode);
                    Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    //�����惁�[�J�[�R�[�h
                    SqlParameter Para_JoinDestMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    Para_JoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(modelShipResultWorkTmp.JoinDestMakerCd);
                    //������i��(�|�t���i��)
                    SqlParameter Para_JoinDestPartsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.Char);
                    Para_JoinDestPartsNo.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.JoinDestPartsNo);
                    //�q�ɃR�[�h
                    SqlParameter Para_WarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Char);
                    Para_WarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseCode);

                    sqlCommand.CommandText = sb.ToString();

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        #region ���o����-�l�Z�b�g
                        // --- DEL 2010/05/13 ---------->>>>>
                        ////�d���݌ɐ�
                        //modelShipResultWorkTmp.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                        ////�q�ɒI��
                        //modelShipResultWorkTmp.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        ////���[�J�[����2
                        //modelShipResultWorkTmp.MakerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        // --- DEL 2010/05/13 ----------<<<<<
                        // --- ADD 2010/05/13 ---------->>>>>
                        // --- DEL 2010/05/16 ---------->>>>>
                        //newWork = new ModelShipResultWork();
                        ////�d���݌ɐ�
                        //newWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                        ////�q�ɒI��
                        //newWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        // --- DEL 2010/05/16 ----------<<<<<

                        isFind = true;
                        // --- ADD 2010/05/13 ----------<<<<<
                        #endregion

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
                // --- ADD 2010/05/13 ---------->>>>>
                // �݌ɏ����擾���A���ʂ�߂�
                if (isFind)
                {
                    modelShipResultWorkList = new ArrayList();
                    // --- UPD 2010/05/16 ---------->>>>>
                    //modelShipResultWorkList.Add(newWork);
                    modelShipResultWorkList.Add(modelShipResultWorkTmp);
                    // --- UPD 2010/05/16 ----------<<<<<
                    break;
                }
                // ����ȊO�̏ꍇ�A���̌����\�����ʂ̌�������ɑ΂��ē����`�F�b�N���s��
                // --- ADD 2010/05/13 ----------<<<<<
            }
            // --- ADD 2010/05/13 ---------->>>>>
            // �݌ɏ����擾���Ȃ��A���ʃ��X�g���N���A����
            if (!isFind)
            {
                modelShipResultWorkList = new ArrayList();
            }
            modelShipResultWorkObject = modelShipResultWorkList as object;
            // --- ADD 2010/05/13 ----------<<<<<

            return status;
        }
        // --- ADD 2010/05/08 ----------<<<<<

        // --- DEL 2010/05/08 ---------->>>>>
        #region DEL 2010/05/08
        ///// <summary>
        ///// �Ή��i�Ԃ̎擾
        ///// </summary>
        ///// <param name="modelShipResultWork">�����p�����[�^</param>
        ///// <param name="_modelShipRsltCndtnWork">�����p�����[�^</param>
        ///// <param name="sqlConnection">�R�l�N�V����</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �Ή��i�Ԃ��擾���܂��B</br>
        ///// <br>Programmer : zhshh</br>
        ///// <br>Date       : 2010.04.22</br>
        //private int SearchGoodNoProc(ref object modelShipResultWork, object _modelShipRsltCndtnWork, ref SqlConnection sqlConnection)
        //{
        //    //�����}�X�^�̌�����i�ԁi�D�Ǖi�ԁj�ƌ����惁�[�J�[�i�D�ǃ��[�J�[�j�̃��X�g�̎擾
        //    ArrayList modelShipResultWorkList = modelShipResultWork as ArrayList;

        //    ModelShipRsltCndtnWork modelShipRsltCndtnWork = _modelShipRsltCndtnWork as ModelShipRsltCndtnWork;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    ArrayList newModelShipResultWorkList = null;   //���o����

        //    foreach(ModelShipResultWork modelShipResultWorkTmp in modelShipResultWorkList)
        //    {
        //        newModelShipResultWorkList = new ArrayList();

        //        //���i��ʂ� 0:�����A�q�ɃR�[�h���P�ȏ�̏ꍇ
        //        if (modelShipResultWorkTmp.GoodsKindCode == 0 && modelShipRsltCndtnWork.WarehouseCode.CompareTo("000001") >= 0)
        //        {
        //            try
        //            {
        //                sqlCommand = new SqlCommand("", sqlConnection);

        //                StringBuilder sb = new StringBuilder();
        //                sb.Append("SELECT ");
        //                sb.Append("JOINDESTMAKERCDRF, ");
        //                sb.Append("JOINDESTPARTSNORF ");
        //                sb.Append("FROM ");
        //                sb.Append("JOINPARTSURF WITH (READUNCOMMITTED)");
        //                sb.Append("WHERE ");
        //                sb.Append("ENTERPRISECODERF= @FINDENTERPRISECODE ");
        //                sb.Append("AND LOGICALDELETECODERF=0 ");
        //                sb.Append("AND JOINSOURCEMAKERCODERF= @FINDJOINSOURCEMAKERCODE ");
        //                sb.Append("AND JOINSOURPARTSNOWITHHRF= @FINDJOINSOURPARTSNOWITHH ");
        //                sb.Append("AND JOINDESTMAKERCDRF IN (");
        //                sb.Append("SELECT ");
        //                sb.Append("PARTSMAKERCDRF ");
        //                sb.Append("FROM ");
        //                sb.Append("PRMSETTINGURF WITH (READUNCOMMITTED)");
        //                sb.Append("WHERE ");
        //                sb.Append("ENTERPRISECODERF= @FINDENTERPRISECODE ");
        //                sb.Append("AND LOGICALDELETECODERF=0 ");
        //                sb.Append(") ");
        //                sb.Append("ORDER BY ");
        //                sb.Append("JOINDISPORDERRF ");

        //                //��ƃR�[�h
        //                SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
        //                Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.EnterpriseCode);
        //                //���������[�J�[�R�[�h
        //                SqlParameter Para_JoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
        //                Para_JoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(modelShipResultWorkTmp.GoodsMakerCd);
        //                //�������i��(�|�t���i��)
        //                SqlParameter Para_JoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.Char);
        //                Para_JoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.GoodsNo);

        //                sqlCommand.CommandText = sb.ToString();

        //                myReader = sqlCommand.ExecuteReader();

        //                while (myReader.Read())
        //                {
        //                    #region ���o����-�l�Z�b�g
        //                    ModelShipResultWork wkModelShipResultWork = new ModelShipResultWork();
        //                    //�����惁�[�J�[�R�[�h
        //                    wkModelShipResultWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
        //                    //������i��(�|�t���i��)    
        //                    wkModelShipResultWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
        //                    #endregion

        //                    newModelShipResultWorkList.Add(wkModelShipResultWork);
        //                }
        //                if (newModelShipResultWorkList.Count >= 1)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //                }

        //            }
        //            catch (SqlException ex)
        //            {
        //                //���N���X�ɗ�O��n���ď������Ă��炤
        //                status = base.WriteSQLErrorLog(ex);
        //            }
        //            finally
        //            {
        //                if (null != sqlCommand)
        //                {
        //                    sqlCommand.Dispose();
        //                }
        //                if (null != myReader && !myReader.IsClosed)
        //                {
        //                    myReader.Close();
        //                }
        //            }

        //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                ModelShipResultWork newModelShipResultWork;
        //                //�d���݌ɐ��Ƒq�ɒI�Ԃ̎擾
        //                status = SearchStockProc(newModelShipResultWorkList, modelShipResultWorkTmp, out newModelShipResultWork, _modelShipRsltCndtnWork, ref sqlConnection);

        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    //�d���݌ɐ�
        //                    modelShipResultWorkTmp.SupplierStock = newModelShipResultWork.SupplierStock;
        //                    //�q�ɒI��
        //                    modelShipResultWorkTmp.WarehouseShelfNo = newModelShipResultWork.WarehouseShelfNo;
        //                    //�����惁�[�J�[�R�[�h
        //                    modelShipResultWorkTmp.JoinDestMakerCd = newModelShipResultWork.JoinDestMakerCd;
        //                    //������i��(�|�t���i��)
        //                    modelShipResultWorkTmp.JoinDestPartsNo = newModelShipResultWork.JoinDestPartsNo;
        //                    //���[�J�[����2
        //                    modelShipResultWorkTmp.MakerName2 = newModelShipResultWork.MakerName2;
        //                    //���������[�J�[�R�[�h
        //                    modelShipResultWorkTmp.JoinSourceMakerCode = modelShipResultWorkTmp.GoodsMakerCd;
        //                    //�������i��(�|�t���i��)
        //                    modelShipResultWorkTmp.JoinSourPartsNoWithH = modelShipResultWorkTmp.GoodsNo;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// �d���݌ɐ��Ƒq�ɒI�Ԃ̎擾
        ///// </summary>
        ///// <param name="modelShipResultWorkList">�����p�����[�^</param>
        ///// <param name="modelShipResultWork">�����p�����[�^</param>
        ///// <param name="newModelShipResultWork">��������</param>
        ///// <param name="_modelShipRsltCndtnWork">�����p�����[�^</param>
        ///// <param name="sqlConnection">�R�l�N�V����</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �d���݌ɐ��Ƒq�ɒI�Ԃ��擾���܂��B</br>
        ///// <br>Programmer : zhshh</br>
        ///// <br>Date       : 2010.04.22</br>
        //private int SearchStockProc(ArrayList modelShipResultWorkList, ModelShipResultWork modelShipResultWork, out ModelShipResultWork newModelShipResultWork, object _modelShipRsltCndtnWork, ref SqlConnection sqlConnection)
        //{
        //    ModelShipRsltCndtnWork modelShipRsltCndtnWork = _modelShipRsltCndtnWork as ModelShipRsltCndtnWork;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    newModelShipResultWork = new ModelShipResultWork();//���o����

        //    foreach (ModelShipResultWork modelShipResultWorkTmp in modelShipResultWorkList)
        //    {
        //        try
        //        {
        //            sqlCommand = new SqlCommand("", sqlConnection);

        //            StringBuilder sb = new StringBuilder();
        //            sb.Append("SELECT ");
        //            sb.Append("SUPPLIERSTOCKRF, ");
        //            sb.Append("WAREHOUSESHELFNORF, ");
        //            sb.Append("MAKERNAMERF ");
        //            sb.Append("FROM ");
        //            sb.Append("STOCKRF WITH (READUNCOMMITTED) ");
        //            sb.Append("LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
        //            sb.Append("ON MAKERURF.ENTERPRISECODERF=STOCKRF.ENTERPRISECODERF ");
        //            sb.Append("AND MAKERURF.LOGICALDELETECODERF=0 ");
        //            sb.Append("AND MAKERURF.GOODSMAKERCDRF=STOCKRF.GOODSMAKERCDRF ");
        //            sb.Append("WHERE ");
        //            sb.Append("STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
        //            sb.Append("AND STOCKRF.LOGICALDELETECODERF=0 ");
        //            sb.Append("AND STOCKRF.SUPPLIERSTOCKRF>0 ");
        //            sb.Append("AND STOCKRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD ");
        //            sb.Append("AND STOCKRF.GOODSNORF=@FINDGOODSNO ");
        //            sb.Append("AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");

        //            //��ƃR�[�h
        //            SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
        //            Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.EnterpriseCode);
        //            //�����惁�[�J�[�R�[�h
        //            SqlParameter Para_JoinDestMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            Para_JoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(modelShipResultWorkTmp.JoinDestMakerCd);
        //            //������i��(�|�t���i��)
        //            SqlParameter Para_JoinDestPartsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.Char);
        //            Para_JoinDestPartsNo.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.JoinDestPartsNo);
        //            //�q�ɃR�[�h
        //            SqlParameter Para_WarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Char);
        //            Para_WarehouseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.WarehouseCode);

        //            sqlCommand.CommandText = sb.ToString();

        //            myReader = sqlCommand.ExecuteReader();

        //            if (myReader.Read())
        //            {
        //                #region ���o����-�l�Z�b�g
        //                //�����惁�[�J�[�R�[�h
        //                newModelShipResultWork.JoinDestMakerCd = modelShipResultWorkTmp.JoinDestMakerCd;
        //                //������i��(�|�t���i��)
        //                newModelShipResultWork.JoinDestPartsNo = modelShipResultWorkTmp.JoinDestPartsNo;
        //                //�d���݌ɐ�
        //                newModelShipResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
        //                //�q�ɒI��
        //                newModelShipResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
        //                //���[�J�[����2
        //                newModelShipResultWork.MakerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
        //                #endregion

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            //���N���X�ɗ�O��n���ď������Ă��炤
        //            status = base.WriteSQLErrorLog(ex);
        //        }
        //        finally
        //        {
        //            if (null != sqlCommand)
        //            {
        //                sqlCommand.Dispose();
        //            }
        //            if (null != myReader && !myReader.IsClosed)
        //            {
        //                myReader.Close();
        //            }
        //        }

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            break;
        //        }
        //    }

        //    return status;
        //}
        #endregion
        // --- DEL 2010/05/08 ----------<<<<<
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_modelShipRsltCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/07 ���C�� �󒍃X�e�[�^�X�̎d�l�ύX</br>
        /// <br>Update Note: 2010/05/13 ���C�� �Q�_�d�l�ύX�̑Ή�</br>
        /// </remarks>
        private string MakeWhereStringA(ref SqlCommand sqlCommand, ModelShipRsltCndtnWork _modelShipRsltCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            // ���㗚���f�[�^.��ƃR�[�h �� ���㗚�𖾍׃f�[�^.��ƃR�[�h
            retstring += " AA.ENTERPRISECODERF=AB.ENTERPRISECODERF";

            // ���㗚���f�[�^.�󒍃X�e�[�^�X �� ���㗚�𖾍׃f�[�^.�󒍃X�e�[�^�X
            retstring += " AND AA.ACPTANODRSTATUSRF=AB.ACPTANODRSTATUSRF";

            // --- UPD 2010/05/07 ---------->>>>>
            //// ���㗚���f�[�^.�󒍃X�e�[�^�X �� �󒍃}�X�^(���q).�󒍃X�e�[�^�X
            //retstring += " AND AA.ACPTANODRSTATUSRF=AC.ACPTANODRSTATUSRF";
            // �󒍃}�X�^�i���q�j��join����
            retstring += " AND AC.ACPTANODRSTATUSRF='7'";
            // --- UPD 2010/05/07 ----------<<<<<

            // ���㗚���f�[�^.����`�[�ԍ� �� ���㗚�𖾍׃f�[�^.����`�[�ԍ�
            retstring += " AND AA.SALESSLIPNUMRF=AB.SALESSLIPNUMRF";

            // ���㗚�𖾍׃f�[�^.��ƃR�[�h �� �󒍃}�X�^(���q).��ƃR�[�h
            retstring += " AND AB.ENTERPRISECODERF=AC.ENTERPRISECODERF";

            // ���㗚�𖾍׃f�[�^.�󒍔ԍ� �� �󒍃}�X�^(���q).�󒍔ԍ�
            retstring += " AND AB.ACCEPTANORDERNORF=AC.ACCEPTANORDERNORF";

            // ���㗚���f�[�^.��ƃR�[�h�����O�C���S���҂̊�ƃR�[�h
            retstring += " AND AA.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.EnterpriseCode);

            //���㗚���f�[�^.�_���폜�敪 �� 0
            retstring += " AND AA.LOGICALDELETECODERF = 0 ";
            //���㗚���f�[�^.�󒍃X�e�[�^�X�� 30(����)
            retstring += " AND AA.ACPTANODRSTATUSRF = 30 ";

            //���_�R�[�h
            if (_modelShipRsltCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _modelShipRsltCndtnWork.SectionCodeList)
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
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateSt))
            {
                retstring += "AND AA.SALESDATERF>=@ST_SALESDAYRF ";
                SqlParameter Para_St_salesDate = sqlCommand.Parameters.Add("@ST_SALESDAYRF", SqlDbType.Int);
                Para_St_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateEd))
            {
                retstring += "AND AA.SALESDATERF<=@ED_SALESDAYRF ";
                SqlParameter Para_Ed_salesDate = sqlCommand.Parameters.Add("@ED_SALESDAYRF", SqlDbType.Int);
                Para_Ed_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateEd);
            }

            // ���㗚���f�[�^.�`�[�������t
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateSt))
            {
                retstring += "AND AA.SEARCHSLIPDATERF>=@ST_SECHSDAYRF ";
                SqlParameter Para_St_sechDate = sqlCommand.Parameters.Add("@ST_SECHSDAYRF", SqlDbType.Int);
                Para_St_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateEd))
            {
                retstring += "AND AA.SEARCHSLIPDATERF<=@ED_SECHSDAYRF ";
                SqlParameter Para_Ed_sechDate = sqlCommand.Parameters.Add("@ED_SECHSDAYRF", SqlDbType.Int);
                Para_Ed_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateEd);
            }

            // �󒍃}�X�^(���q).�_���폜�敪 �� �u0�F�L���v
            retstring += " AND AC.LOGICALDELETECODERF = 0 ";

            // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� ��	 0
            retstring += " AND AC.CARMNGNORF <> 0 ";

            // �󒍃}�X�^(���q).���[�J�[�R�[�h
            if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)
            {
                retstring += " AND AC.MAKERCODERF>=@ACST_MAKERCODERF ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MAKERCODERF", SqlDbType.Int);
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarMakerCodeEd)
            {
                retstring += " AND AC.MAKERCODERF<=@ACED_MAKERCODERF ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MAKERCODERF", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeEd);
            }

            // �󒍃}�X�^(���q).�Ԏ�R�[�h
            //if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)// DEL 2010.05.19 zhangsf FOR Redmine #7784
            if (0 != _modelShipRsltCndtnWork.CarModelCodeSt)// ADD 2010.05.19 zhangsf FOR Redmine #7784
            {
                retstring += " AND AC.MODELCODERF>=@ACST_MODELCODERF ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MODELCODERF", SqlDbType.Int);
                //Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);// ADD 2010.05.19 zhangsf FOR Redmine #7784
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeSt);// ADD 2010.05.19 zhangsf FOR Redmine #7784
            }

            if (0 != _modelShipRsltCndtnWork.CarModelCodeEd)
            {
                retstring += " AND AC.MODELCODERF<=@ACED_MODELCODERF ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MODELCODERF", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeEd);
            }

            // �󒍃}�X�^(���q).�Ԏ�T�u�R�[�h
            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeSt)
            {
                retstring += " AND AC.MODELSUBCODERF>=@ACST_MODELSUBCODERF ";
                SqlParameter Para_St_CarModelSubCode = sqlCommand.Parameters.Add("@ACST_MODELSUBCODERF", SqlDbType.Int);
                Para_St_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeEd)
            {
                retstring += " AND AC.MODELSUBCODERF<=@ACED_MODELSUBCODERF ";
                SqlParameter Para_Ed_CarModelSubCode = sqlCommand.Parameters.Add("@ACED_MODELSUBCODERF", SqlDbType.Int);
                Para_Ed_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeEd);
            }

            // ���㗚�𖾍׃f�[�^.�_���폜�敪 �� �u0�F�L���v
            retstring += " AND AB.LOGICALDELETECODERF = 0 ";

            // --- UPD 2010/05/13 ---------->>>>>
            //// ���㗚�𖾍׃f�[�^.����`�[�敪 �� �u0�F����vOR�u1�F�ԕi�vOR �u2�F�l���v
            //retstring += " AND ( AB.SALESSLIPCDDTLRF = 0 OR  AB.SALESSLIPCDDTLRF = 1 OR  AB.SALESSLIPCDDTLRF = 2 )";
            // ���㗚�𖾍׃f�[�^.����`�[�敪 �� �u0�F����vOR�u1�F�ԕi�v
            retstring += " AND ( AB.SALESSLIPCDDTLRF = 0 OR  AB.SALESSLIPCDDTLRF = 1 )";
            // --- UPD 2010/05/13 ----------<<<<<

            // ���㗚�𖾍׃f�[�^.BL���i�R�[�h
            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeSt)
            {
                retstring += " AND AB.BLGOODSCODERF>=@ST_GOODSCODERF ";
                SqlParameter Para_St_BLgoodsCode = sqlCommand.Parameters.Add("@ST_GOODSCODERF", SqlDbType.Int);
                Para_St_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeEd)
            {
                retstring += " AND AB.BLGOODSCODERF<=@ED_GOODSCODERF ";
                SqlParameter Para_Ed_BLgoodsCode = sqlCommand.Parameters.Add("@ED_GOODSCODERF", SqlDbType.Int);
                Para_Ed_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeEd);
            }

            // ���㗚�𖾍׃f�[�^.���i���[�J�[�R�[�h
            if (0 != _modelShipRsltCndtnWork.MakerCodeSt)
            {
                retstring += " AND AB.GOODSMAKERCDRF>=@CNST_GOODSMAKERCDRF ";
                SqlParameter Para_St_MakerCode = sqlCommand.Parameters.Add("@CNST_GOODSMAKERCDRF", SqlDbType.Int);
                Para_St_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.MakerCodeEd)
            {
                retstring += " AND AB.GOODSMAKERCDRF<=@CNED_GOODSMAKERCDRF ";
                SqlParameter Para_Ed_MakerCode = sqlCommand.Parameters.Add("@CNED_GOODSMAKERCDRF", SqlDbType.Int);
                Para_Ed_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeEd);
            }

            // ���㗚�𖾍׃f�[�^.���i�ԍ�
            retstring += " AND AB.GOODSNORF<>'' ";

            // ���㗚�𖾍׃f�[�^.����݌Ɏ�񂹋敪 
            if (_modelShipRsltCndtnWork.RsltTtlDiv == 1)
            {
                // 1:�݌�
                retstring += " AND AB.SALESORDERDIVCDRF = 1 ";
            }
            else if (_modelShipRsltCndtnWork.RsltTtlDiv == 2)
            {
                // 2:���
                retstring += " AND AB.SALESORDERDIVCDRF = 0 ";
            }

            // --- UPD 2010/05/13 ---------->>>>>
            //// �󒍃}�X�^(���q).�V���[�Y�^�� �^���i�ޕʋL���j
            //if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            //{
            //    // 0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���
            //    if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
            //    }
            //}
            // �󒍃}�X�^(���q).�t���^��
            if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            {
                // 0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���
                if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
                {
                    retstring += " AND AC.FULLMODELRF = @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
                }
            }
            // --- UPD 2010/05/13 ----------<<<<<

            #endregion
            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_modelShipRsltCndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/13 ���C�� �Q�_�d�l�ύX�̑Ή�</br>
        /// </remarks>
        private string MakeWhereStringB(ref SqlCommand sqlCommand, ModelShipRsltCndtnWork _modelShipRsltCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE ";

            // ���q���i�f�[�^(�R���o�[�g).��ƃR�[�h �� �󒍃}�X�^(���q).��ƃR�[�h
            retstring += " AC.ENTERPRISECODERF=CN.ENTERPRISECODERF";

            // ���q���i�f�[�^(�R���o�[�g).�󒍔ԍ� �� �󒍃}�X�^(���q).�󒍔ԍ�
            retstring += " AND AC.ACCEPTANORDERNORF=CN.ACCEPTANORDERNORF";

            // ���q���i�f�[�^(�R���o�[�g).�󒍃X�e�[�^�X �� �󒍃}�X�^(���q).�󒍃X�e�[�^�X
            retstring += " AND AC.ACPTANODRSTATUSRF=CN.ACPTANODRSTATUSRF";

            // ���q���i�f�[�^(�R���o�[�g).�_���폜�敪 �� �󒍃}�X�^(���q).�_���폜�敪
            retstring += " AND AC.LOGICALDELETECODERF=CN.LOGICALDELETECODERF";

            // ���q���i�f�[�^(�R���o�[�g).�f�[�^���̓V�X�e�� �� �󒍃}�X�^(���q).�f�[�^���̓V�X�e��
            retstring += " AND AC.DATAINPUTSYSTEMRF=CN.DATAINPUTSYSTEMRF";

            // ���q���i�f�[�^(�R���o�[�g).��ƃR�[�h�����O�C���S���҂̊�ƃR�[�h
            retstring += " AND CN.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.EnterpriseCode);

            retstring += " AND CN.LOGICALDELETECODERF = 0 ";
            retstring += " AND (CN.ACPTANODRSTATUSRF = 7 OR CN.ACPTANODRSTATUSRF = 8)";

            //���_�R�[�h
            if (_modelShipRsltCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _modelShipRsltCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND CN.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // ���q���i�f�[�^(�R���o�[�g).������t																																	
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateSt))
            {
                retstring += "AND CN.SALESDATERF>=@CNST_SALESDAY ";
                SqlParameter Para_St_salesDate = sqlCommand.Parameters.Add("@CNST_SALESDAY", SqlDbType.Int);
                Para_St_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateEd))
            {
                retstring += "AND CN.SALESDATERF<=@CNED_SALESDAY ";
                SqlParameter Para_Ed_salesDate = sqlCommand.Parameters.Add("@CNED_SALESDAY", SqlDbType.Int);
                Para_Ed_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).������t
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateSt))
            {
                retstring += "AND CN.SALESDATERF>=@CNST_SECHSDAY ";
                SqlParameter Para_St_sechDate = sqlCommand.Parameters.Add("@CNST_SECHSDAY", SqlDbType.Int);
                Para_St_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateEd))
            {
                retstring += "AND CN.SALESDATERF<=@CNED_SECHSDAY ";
                SqlParameter Para_Ed_sechDate = sqlCommand.Parameters.Add("@CNED_SECHSDAY", SqlDbType.Int);
                Para_Ed_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).BL���i�R�[�h
            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeSt)
            {
                retstring += " AND CN.BLGOODSCODERF>=@CNST_GOODSCODE ";
                SqlParameter Para_St_BLgoodsCode = sqlCommand.Parameters.Add("@CNST_GOODSCODE", SqlDbType.Int);
                Para_St_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeEd)
            {
                retstring += " AND CN.BLGOODSCODERF<=@CNED_GOODSCODE ";
                SqlParameter Para_Ed_BLgoodsCode = sqlCommand.Parameters.Add("@CNED_GOODSCODE", SqlDbType.Int);
                Para_Ed_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).���i���[�J�[�R�[�h
            if (0 != _modelShipRsltCndtnWork.MakerCodeSt)
            {
                retstring += " AND CN.GOODSMAKERCDRF>=@CNST_GOODSMAKERCD ";
                SqlParameter Para_St_MakerCode = sqlCommand.Parameters.Add("@CNST_GOODSMAKERCD", SqlDbType.Int);
                Para_St_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.MakerCodeEd)
            {
                retstring += " AND CN.GOODSMAKERCDRF<=@CNED_GOODSMAKERCD ";
                SqlParameter Para_Ed_MakerCode = sqlCommand.Parameters.Add("@CNED_GOODSMAKERCD", SqlDbType.Int);
                Para_Ed_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeEd);
            }

            // ���q���i�f�[�^(�R���o�[�g).���i�ԍ�
            retstring += " AND CN.GOODSNORF<>'' ";

            // ���q���i�f�[�^(�R���o�[�g).����݌Ɏ�񂹋敪 
            if (_modelShipRsltCndtnWork.RsltTtlDiv == 1)
            {
                // 1:�݌�
                retstring += " AND CN.SALESORDERDIVCDRF = 1 ";
            }
            else if (_modelShipRsltCndtnWork.RsltTtlDiv == 2)
            {
                // 2:���
                retstring += " AND CN.SALESORDERDIVCDRF = 0 ";
            }

            // �󒍃}�X�^(���q).�ԗ��Ǘ��ԍ� ��	 0
            retstring += " AND AC.CARMNGNORF <> 0 ";

            // --- UPD 2010/05/13 ---------->>>>>
            //// �󒍃}�X�^(���q).�V���[�Y�^�� �^���i�ޕʋL���j
            //if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            //{
            //    // 0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���
            //    if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
            //    }
            //}
            // �󒍃}�X�^(���q).�t���^��
            if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            {
                // 0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���
                if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
                {
                    retstring += " AND AC.FULLMODELRF = @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
                }
            }
            // --- UPD 2010/05/13 ----------<<<<<

            // �󒍃}�X�^(���q).���[�J�[�R�[�h
            if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)
            {
                retstring += " AND AC.MAKERCODERF>=@ACST_MAKERCODE ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MAKERCODE", SqlDbType.Int);
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarMakerCodeEd)
            {
                retstring += " AND AC.MAKERCODERF<=@ACED_MAKERCODE ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MAKERCODE", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeEd);
            }

            // �󒍃}�X�^(���q).�Ԏ�R�[�h
            //if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)// DEL 2010.05.19 zhangsf FOR Redmine #7784
            if (0 != _modelShipRsltCndtnWork.CarModelCodeSt)// ADD 2010.05.19 zhangsf FOR Redmine #7784
            {
                retstring += " AND AC.MODELCODERF>=@ACST_MODELCODE ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MODELCODE", SqlDbType.Int);
                //Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);// DEL 2010.05.19 zhangsf FOR Redmine #7784
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeSt);// ADD 2010.05.19 zhangsf FOR Redmine #7784
            }

            if (0 != _modelShipRsltCndtnWork.CarModelCodeEd)
            {
                retstring += " AND AC.MODELCODERF<=@ACED_MODELCODE ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MODELCODE", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeEd);
            }

            // �󒍃}�X�^(���q).�Ԏ�T�u�R�[�h
            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeSt)
            {
                retstring += " AND AC.MODELSUBCODERF>=@ACST_MODELSUBCODE ";
                SqlParameter Para_St_CarModelSubCode = sqlCommand.Parameters.Add("@ACST_MODELSUBCODE", SqlDbType.Int);
                Para_St_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeEd)
            {
                retstring += " AND AC.MODELSUBCODERF<=@ACED_MODELSUBCODE ";
                SqlParameter Para_Ed_CarModelSubCode = sqlCommand.Parameters.Add("@ACED_MODELSUBCODE", SqlDbType.Int);
                Para_Ed_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeEd);
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
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
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
