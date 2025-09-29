//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ʌ��Ϗ��E�I���\ 
// �v���O�����T�v   : ���Ӑ�ʌ��Ϗ��E�I���\ DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970531-00  �쐬�S�� : songg
// �� �� ��  K2013/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : ������
// �C �� ��  2020/08/20   �C�����e : PMKOBETSU-4005 ���i�}�X�^�@�艿���l�ϊ��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ʌ��Ϗ��E�I���\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʌ��Ϗ��E�I���\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : K2013/12/03</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2020/08/20</br>
    /// </remarks>
    [Serializable]
    public class TakekawaQuotaInventWorkDB : RemoteDB, ITakekawaQuotaInventWorkDB
    {
        /// <summary>
        /// ���Ӑ�ʌ��Ϗ��E�I���\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        public TakekawaQuotaInventWorkDB()
            :
            base("PMMIT02009DC", "Broadleaf.Application.Remoting.ParamData.TakekawaQuotaInventResultWork", "SUPLIERPAYRF")
        {
        }

        #region �� [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�ʌ��Ϗ��E�I���\��߂��܂�
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">��������</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name="takekawaQuotaInventCndtnWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʌ��Ϗ��E�I���\��߂��܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        public int Search(out object takekawaQuotaInventResultWork, 
            out object goodsPriceUWorkList,
            object takekawaQuotaInventCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            takekawaQuotaInventResultWork = null;
            goodsPriceUWorkList = null;
            SqlConnection sqlConnection = null;

            TakekawaQuotaInventCndtnWork paraCndtnWork = takekawaQuotaInventCndtnWork as TakekawaQuotaInventCndtnWork;
            try
            {
                //SQL������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �I���敪�F0:���Ϗ�,1:�I���\
                if (paraCndtnWork.SelectFlg == 0)
                {
                    status = SearchProcForQuotation(out takekawaQuotaInventResultWork,
                        out goodsPriceUWorkList,
                        paraCndtnWork, logicalMode, ref sqlConnection);
                }
                else
                {
                    status = SearchProcForInventory(out takekawaQuotaInventResultWork,
                        out goodsPriceUWorkList,
                        paraCndtnWork, logicalMode, ref sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.Search Exception=" + ex.Message);
                takekawaQuotaInventResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion  //[Search]

        #region
        /// <summary>
        /// ����S�̐ݒ�̎擾����
        /// </summary>
        /// <param name="takekawaQuotaInventCndtnWork">��������</param>
        /// <returns>���ׂĔ���S�̐ݒ�</returns>
        /// <remarks>
        /// <br>Note       : ����S�̐ݒ�̎擾�������s���B</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        private Dictionary<string, SalesTtlStWork> GetSalesTtlSt(TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork)
        {
            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
            object tempSalesTtlStList = null;

            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode; // ��ƃR�[�h�ݒ�
            ArrayList salesTtlStWorkList = new ArrayList();
            salesTtlStWorkList.Add(salesTtlStWork);
            salesTtlStDB.Search(out tempSalesTtlStList, salesTtlStWorkList, 0, ConstantManagement.LogicalMode.GetData0);

            Dictionary<string, SalesTtlStWork> salesTtlStWorkDic = new Dictionary<string, SalesTtlStWork>();
            foreach (SalesTtlStWork tempSalesTtlStWork in (ArrayList)tempSalesTtlStList)
            {
                if (!salesTtlStWorkDic.ContainsKey(tempSalesTtlStWork.SectionCode.Trim()))
                {
                    salesTtlStWorkDic.Add(tempSalesTtlStWork.SectionCode.Trim(), tempSalesTtlStWork);
                }
            }

            return salesTtlStWorkDic;
        }
        #endregion

        #region �� [SearchProcForQuotation]���Ӑ�ʌ��Ϗ�����
        /// <summary>
        /// ���Ӑ�ʌ��Ϗ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">��������</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name="takekawaQuotaInventCndtnWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : ���Ӑ�ʌ��Ϗ��E�I���\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProcForQuotation(out object takekawaQuotaInventResultWork,
            out object goodsPriceUWorkList,
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,
            ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //��������
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            takekawaQuotaInventResultWork = null;
            goodsPriceUWorkList = null;

            // �S�Ĕ���S�̐ݒ��񌟍�
            Dictionary<string, SalesTtlStWork> salesTtlStDic = GetSalesTtlSt(takekawaQuotaInventCndtnWork);

            ArrayList retList = new ArrayList();   //���o����

            ArrayList tempGoodsPriceUWorkList = new ArrayList(); // ���i�}�X�^���X�g

            //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);

                #region [Select���쐬]
                selectTxt.Append(" SELECT  ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.PRICESTARTDATERF, -- ���i�}�X�^.���i�J�n��").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.LISTPRICERF, --���i�}�X�^.�艿�i�����j").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.SALESUNITCOSTRF, --���i�}�X�^.�����P��").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.STOCKRATERF, --���i�}�X�^.�d����").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OPENPRICEDIVRF, --���i�}�X�^.�I�[�v�����i�敪").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OFFERDATERF, --���i�}�X�^.�񋟓��t").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.UPDATEDATERF, --���i�}�X�^.�X�V�N����").Append(Environment.NewLine);

                selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BL�O���[�v�R�[�h").Append(Environment.NewLine);

                selectTxt.Append(" STOCK.ENTERPRISECODERF, -- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.WAREHOUSECODERF, -- �q�ɃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.WAREHOUSESHELFNORF, -- �q�ɒI�� ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.GOODSMAKERCDRF, -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.GOODSNORF, -- ���i�ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.SECTIONCODERF AS STOCK_SECTIONCODERF, --�݌ɂ̋��_�R�[�h").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNAMERF, -- ���i���� ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNORF AS GOODSU_GOODSNORF, -- ���i�}�X�^�̘_���폜���f�p���� ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.BLGOODSCODERF, -- �a�k���i�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSRATERANKRF, -- ���i�|�������N ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.TAXATIONDIVCDRF,-- �ېŋ敪 ").Append(Environment.NewLine);

                selectTxt.Append(" BLGROUPU.GOODSMGROUPRF, -- ���i�����ރR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.WAREHOUSECODERF, -- �q�ɃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.WAREHOUSENAMERF, -- �q�ɖ��� ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.CUSTOMERCODERF, --���Ӑ�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAMERF,-- ���Ӑ於�̂P ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAME2RF, -- ���Ӑ於�̂Q ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.MNGSECTIONCODERF AS SECTIONCODERF, -- ���_�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESUNPRCFRCPROCCDRF, --����P���[�������R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESCNSTAXFRCPROCCDRF, --�������Œ[�������R�[�h ").Append(Environment.NewLine);

                selectTxt.Append(" CLAIMER.CUSTCTAXLAYREFCDRF,--������̓��Ӑ����œ]�ŕ����Q�Ƌ敪").Append(Environment.NewLine);
                selectTxt.Append(" CLAIMER.CONSTAXLAYMETHODRF,--������̏���œ]�ŕ���").Append(Environment.NewLine);

                selectTxt.Append(" SECINFOSET.SECTIONGUIDENMRF, --���_�K�C�h���� ").Append(Environment.NewLine);
                selectTxt.Append(" SECINFOSET.COMPANYNAMECD1RF, --���Ж��̃R�[�h1 ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.POSTNORF, -- �X�֔ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS1RF, -- �Z��1�i�s���{���s��S�E�����E���j ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS3RF -- �Z��3�i�Ԓn�j ").Append(Environment.NewLine);
                
                selectTxt.Append(" FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) -- �݌Ƀ}�X�^ ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --���i�}�X�^").Append(Environment.NewLine);
                selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSNORF = GOODSU.GOODSNORF -- ���i�ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --�a�k���i�R�[�h�}�X�^(���[�U�[)").Append(Environment.NewLine);
                selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL���i�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BL�O���[�v�}�X�^�i���[�U�[�o�^���j").Append(Environment.NewLine);
                selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BL�O���[�v�R�[�h ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) --�q�Ƀ}�X�^").Append(Environment.NewLine);
                selectTxt.Append(" ON STOCK.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF-- �q�ɃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                
                selectTxt.Append(" INNER JOIN CUSTOMERRF AS CUSTOMER WITH (READUNCOMMITTED) --���Ӑ�}�X�^").Append(Environment.NewLine);
                selectTxt.Append(" ON WAREHOUSE.ENTERPRISECODERF = CUSTOMER.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF = CUSTOMER.CUSTOMERCODERF--���Ӑ�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);


                selectTxt.Append(" LEFT JOIN CUSTOMERRF AS CLAIMER WITH (READUNCOMMITTED) --���Ӑ�}�X�^�i��������j").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = CLAIMER.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.CLAIMCODERF = CLAIMER.CUSTOMERCODERF--���Ӑ�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CLAIMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                
                selectTxt.Append(" INNER JOIN SECINFOSETRF AS SECINFOSET WITH (READUNCOMMITTED)-- ���_���ݒ�}�X�^ ").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = SECINFOSET.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF = SECINFOSET.SECTIONCODERF-- ���_�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                
                selectTxt.Append(" LEFT JOIN COMPANYNMRF AS COMPANYNM WITH (READUNCOMMITTED)--���Ж��̃}�X�^ ").Append(Environment.NewLine);
                selectTxt.Append(" ON SECINFOSET.ENTERPRISECODERF = COMPANYNM.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.COMPANYNAMECD1RF = COMPANYNM.COMPANYNAMECDRF--���Ж��̃R�[�h ").Append(Environment.NewLine);

                // ���\�A�b�v
                // ���i�}�X�^�����擾����
                selectTxt.Append(" LEFT JOIN GOODSPRICEURF AS GOODSPRICEU WITH (READUNCOMMITTED)--���i�}�X�^ ").Append(Environment.NewLine);
                selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSPRICEU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSPRICEU.GOODSMAKERCDRF--���i���[�J�[�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSNORF = GOODSPRICEU.GOODSNORF--���i�ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSPRICEU.LOGICALDELETECODERF = 0--�_���폜�敪 ").Append(Environment.NewLine);


                #region where
                selectTxt.Append("  WHERE  ").Append(Environment.NewLine);
                selectTxt.Append("  STOCK.ENTERPRISECODERF = @ENTERPRISECODE1 -- ��ƃR�[�h ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.EnterpriseCode);
                selectTxt.Append("  AND STOCK.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                //���_�R�[�h
                if (takekawaQuotaInventCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in takekawaQuotaInventCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt.Append(" AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ")");
                        selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF IN (" + sectionCodestr + ")");
                    }
                    selectTxt.Append(Environment.NewLine);
                }


                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim()))
                {
                    selectTxt.Append(" AND STOCK.WAREHOUSECODERF >= @WAREHOUSECODEST1 -- �q�ɃR�[�h�J�n ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEST1 = sqlCommand.Parameters.Add("@WAREHOUSECODEST1", SqlDbType.NChar);
                    paraWAREHOUSECODEST1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim());
                }

                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim()))
                {
                    selectTxt.Append(" AND STOCK.WAREHOUSECODERF <= @WAREHOUSECODEED1 -- �q�ɃR�[�h�I�� ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEED1 = sqlCommand.Parameters.Add("@WAREHOUSECODEED1", SqlDbType.NChar);
                    paraWAREHOUSECODEED1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim());

                }

                if (takekawaQuotaInventCndtnWork.GoodsMakerCdSt != 0)
                {
                    selectTxt.Append(" AND STOCK.GOODSMAKERCDRF >= @GOODSMAKERCDST1 -- ���[�J�[�J�n ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDST1 = sqlCommand.Parameters.Add("@GOODSMAKERCDST1", SqlDbType.Int);
                    paraGOODSMAKERCDST1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdSt);
                }

                if (takekawaQuotaInventCndtnWork.GoodsMakerCdEd != 0)
                {
                    selectTxt.Append(" AND STOCK.GOODSMAKERCDRF <= @GOODSMAKERCDED1 -- ���[�J�[�I�� ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDED1 = sqlCommand.Parameters.Add("@GOODSMAKERCDED1", SqlDbType.Int);
                    paraGOODSMAKERCDED1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdEd);
                }

                if (takekawaQuotaInventCndtnWork.CustomerCodeSt != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF >= @CUSTOMERCODEST4 -- ���Ӑ�J�n ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEST4 = sqlCommand.Parameters.Add("@CUSTOMERCODEST4", SqlDbType.Int);
                    paraCUSTOMERCODEST4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeSt);
                }
                if (takekawaQuotaInventCndtnWork.CustomerCodeEd != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF <= @CUSTOMERCODEED4 -- ���Ӑ�I�� ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEED4 = sqlCommand.Parameters.Add("@CUSTOMERCODEED4", SqlDbType.Int);
                    paraCUSTOMERCODEED4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeEd);
                }
                #endregion


                selectTxt.Append("  --���_, ���Ӑ�, �q��, �I��, �i��,���[�J�[ ASC").Append(Environment.NewLine);
                selectTxt.Append("  --���i�J�n�� DESC").Append(Environment.NewLine);
                selectTxt.Append(" ORDER BY CUSTOMER.MNGSECTIONCODERF ASC, WAREHOUSE.CUSTOMERCODERF ASC, WAREHOUSE.WAREHOUSECODERF ASC, STOCK.WAREHOUSESHELFNORF ASC, STOCK.GOODSNORF ASC, STOCK.GOODSMAKERCDRF ASC ").Append(Environment.NewLine);
                selectTxt.Append(" , GOODSPRICEU.PRICESTARTDATERF DESC ").Append(Environment.NewLine);

                #endregion

                sqlCommand.CommandText = selectTxt.ToString();

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();


                // �d����擾�p
                GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
                Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //���_�{���[�J�[�{�i��
                Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //���_�{�����ށ{���[�J�[�{�a�k
                Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //���_�{�����ށ{���[�J�[
                Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //���_�{���[�J�[

                // ���i�Ǘ���񂷂ׂĎ擾
                goodsSupplierGetter.GetGoodsMngInfo(takekawaQuotaInventCndtnWork.EnterpriseCode,
                    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);


                // key : ���[�J�[�@�{�@�i��
                Dictionary<string, string> goodsDic = new Dictionary<string, string>();

                // �a�k���i�R�[�h�}�X�^Dictionary(�L�[�FBL���i�R�[�h)
                Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic = new Dictionary<int, BLGoodsCdUWork>();


                while (myReader.Read())
                {
                    // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                    //TakekawaQuotaInventResultWork resultWork = CopyToTakekawaQuotaResultWorkFromReader(ref myReader,
                    //    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                    //    takekawaQuotaInventCndtnWork, ref goodsSupplierGetter, ref goodsDic, ref tempGoodsPriceUWorkList,
                    //    ref salesTtlStDic,
                    //    ref blGoodsCdUDic);
                    TakekawaQuotaInventResultWork resultWork = CopyToTakekawaQuotaResultWorkFromReader(ref myReader,
                        ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                        takekawaQuotaInventCndtnWork, ref goodsSupplierGetter, ref goodsDic, ref tempGoodsPriceUWorkList,
                        ref salesTtlStDic,
                        ref blGoodsCdUDic, convertDoubleRelease);
                    // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
                    if (null != resultWork)
                    {
                        retList.Add(resultWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // �f�[�^���Ȃ��ꍇ�A
                if ((null == retList) || (retList.Count == 0))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchProcForQuotation Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }

                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            }

            takekawaQuotaInventResultWork = retList;
            goodsPriceUWorkList = tempGoodsPriceUWorkList;

            return status;
        }
        #endregion  //[SearchProcForQuotation]

        #region �� [SearchProcForInventory]���Ӑ�ʒI���\����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ʒI���\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">��������</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name="takekawaQuotaInventCndtnWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓��Ӑ�ʒI���\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProcForInventory(out object takekawaQuotaInventResultWork,
            out object goodsPriceUWorkList, 
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork, 
            ConstantManagement.LogicalMode logicalMode, 
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //��������
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            takekawaQuotaInventResultWork = null;
            goodsPriceUWorkList = null;

            // �S�Ĕ���S�̐ݒ��񌟍�
            Dictionary<string, SalesTtlStWork> salesTtlStDic = GetSalesTtlSt(takekawaQuotaInventCndtnWork);

            ArrayList retList = new ArrayList();   //���o����

            ArrayList tempGoodsPriceUWorkList = new ArrayList(); // ���i�}�X�^���X�g

            //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);

                #region [Select���쐬]
                selectTxt.Append(" SELECT  ").Append(Environment.NewLine);

                selectTxt.Append(" GOODSPRICEU.PRICESTARTDATERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.LISTPRICERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.SALESUNITCOSTRF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.STOCKRATERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OPENPRICEDIVRF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OFFERDATERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.UPDATEDATERF, ").Append(Environment.NewLine);

                selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BL�O���[�v�R�[�h").Append(Environment.NewLine);

                selectTxt.Append(" CASE WHEN INVENTORYDATA.INVENTORYDAYRF IS NOT NULL THEN INVENTORYDATA.INVENTORYSTOCKCNTRF ELSE INVENTORYDATA.STOCKTOTALRF END AS INVENTORYSTOCKCNTRF, --�I���݌ɐ�(��ʕ\���p) ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.INVENTORYSTOCKCNTRF AS INVENTORYSTOCKCNTRF1, --�I���݌ɐ�(�`�F�b�N�p) ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.SUPPLIERCDRF, -- �d����R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.ENTERPRISECODERF, -- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.WAREHOUSECODERF, -- �q�ɃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.WAREHOUSESHELFNORF, -- �q�ɒI�� ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.GOODSMAKERCDRF, -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.GOODSNORF, -- ���i�ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.SECTIONCODERF AS INVENTORYDATA_SECTIONCODERF, -- �I���f�[�^�̋��_�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.BLGOODSCODERF, -- BL���i�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNAMERF, -- ���i���� ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNORF AS GOODSU_GOODSNORF, -- ���i�}�X�^�̘_���폜���f�p���� ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSRATERANKRF, -- ���i�|�������N ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.TAXATIONDIVCDRF,-- �ېŋ敪 ").Append(Environment.NewLine);

                selectTxt.Append(" BLGROUPU.GOODSMGROUPRF, -- ���i�����ރR�[�h ").Append(Environment.NewLine);

                selectTxt.Append(" WAREHOUSE.WAREHOUSECODERF, -- �q�ɃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.WAREHOUSENAMERF, -- �q�ɖ��� ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.CUSTOMERCODERF, --���Ӑ�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAMERF,-- ���Ӑ於�̂P ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAME2RF, -- ���Ӑ於�̂Q ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.MNGSECTIONCODERF AS SECTIONCODERF, -- ���_�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESUNPRCFRCPROCCDRF, --����P���[�������R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESCNSTAXFRCPROCCDRF, --�������Œ[�������R�[�h ").Append(Environment.NewLine);

                selectTxt.Append(" CLAIMER.CUSTCTAXLAYREFCDRF,--������̓��Ӑ����œ]�ŕ����Q�Ƌ敪").Append(Environment.NewLine);
                selectTxt.Append(" CLAIMER.CONSTAXLAYMETHODRF,--������̏���œ]�ŕ���").Append(Environment.NewLine);

                selectTxt.Append(" SECINFOSET.SECTIONGUIDENMRF, --���_�K�C�h���� ").Append(Environment.NewLine);
                selectTxt.Append(" SECINFOSET.COMPANYNAMECD1RF, --���Ж��̃R�[�h1 ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.POSTNORF, -- �X�֔ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS1RF, -- �Z��1�i�s���{���s��S�E�����E���j ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS3RF -- �Z��3�i�Ԓn�j ").Append(Environment.NewLine);
                selectTxt.Append(" FROM INVENTORYDATARF AS INVENTORYDATA WITH (READUNCOMMITTED)  -- �I���f�[�^ ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --���i�}�X�^").Append(Environment.NewLine);
                selectTxt.Append(" ON INVENTORYDATA.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSNORF = GOODSU.GOODSNORF -- ���i�ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --�a�k���i�R�[�h�}�X�^(���[�U�[)").Append(Environment.NewLine);
                selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL���i�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BL�O���[�v�}�X�^�i���[�U�[�o�^���j").Append(Environment.NewLine);
                selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BL�O���[�v�R�[�h ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append(" ON INVENTORYDATA.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF-- �q�ɃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN CUSTOMERRF AS CUSTOMER WITH (READUNCOMMITTED) --���Ӑ�}�X�^").Append(Environment.NewLine);
                selectTxt.Append(" ON WAREHOUSE.ENTERPRISECODERF = CUSTOMER.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF = CUSTOMER.CUSTOMERCODERF--���Ӑ�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN CUSTOMERRF AS CLAIMER WITH (READUNCOMMITTED) --���Ӑ�}�X�^�i��������j").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = CLAIMER.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.CLAIMCODERF = CLAIMER.CUSTOMERCODERF--���Ӑ�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CLAIMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN SECINFOSETRF AS SECINFOSET WITH (READUNCOMMITTED)-- ���_���ݒ�}�X�^ ").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = SECINFOSET.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF = SECINFOSET.SECTIONCODERF-- ���_�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN COMPANYNMRF AS COMPANYNM WITH (READUNCOMMITTED)--���Ж��̃}�X�^ ").Append(Environment.NewLine);
                selectTxt.Append(" ON SECINFOSET.ENTERPRISECODERF = COMPANYNM.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.COMPANYNAMECD1RF = COMPANYNM.COMPANYNAMECDRF--���Ж��̃R�[�h ").Append(Environment.NewLine);

                // ���\�A�b�v
                // ���i�}�X�^�����擾����
                selectTxt.Append(" LEFT JOIN GOODSPRICEURF AS GOODSPRICEU WITH (READUNCOMMITTED)--���i�}�X�^ ").Append(Environment.NewLine);
                selectTxt.Append(" ON INVENTORYDATA.ENTERPRISECODERF = GOODSPRICEU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSMAKERCDRF = GOODSPRICEU.GOODSMAKERCDRF--���i���[�J�[�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSNORF = GOODSPRICEU.GOODSNORF--���i�ԍ� ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSPRICEU.LOGICALDELETECODERF = 0--�_���폜�敪 ").Append(Environment.NewLine);

                selectTxt.Append("  WHERE  ").Append(Environment.NewLine);
                selectTxt.Append("  INVENTORYDATA.ENTERPRISECODERF = @ENTERPRISECODE1 -- ��ƃR�[�h ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.EnterpriseCode);

                selectTxt.Append("  AND INVENTORYDATA.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);

                //���_�R�[�h
                if (takekawaQuotaInventCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in takekawaQuotaInventCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt.Append(" AND INVENTORYDATA.SECTIONCODERF IN (" + sectionCodestr + ")");
                        selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF IN (" + sectionCodestr + ")");
                    }
                    selectTxt.Append(Environment.NewLine);
                }


                if (takekawaQuotaInventCndtnWork.StSupplierCd != 0)
                {
                    selectTxt.Append(" AND INVENTORYDATA.SUPPLIERCDRF >= @STSUPPLIERCD1 -- �d����J�n ").Append(Environment.NewLine);
                    SqlParameter paraSTSUPPLIERCD1 = sqlCommand.Parameters.Add("@STSUPPLIERCD1", SqlDbType.Int);
                    paraSTSUPPLIERCD1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.StSupplierCd);
                }

                if (takekawaQuotaInventCndtnWork.EdSupplierCd != 0)
                {
                    selectTxt.Append(" AND INVENTORYDATA.SUPPLIERCDRF <= @EDSUPPLIERCD1 -- �d����I�� ").Append(Environment.NewLine);
                    SqlParameter paraEDSUPPLIERCD1 = sqlCommand.Parameters.Add("@EDSUPPLIERCD1", SqlDbType.Int);
                    paraEDSUPPLIERCD1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.EdSupplierCd);
                }


                if (takekawaQuotaInventCndtnWork.GoodsMakerCdSt != 0)
                {
                    selectTxt.Append(" AND GOODSU.GOODSMAKERCDRF >= @GOODSMAKERCDST2 -- ���[�J�[�J�n ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDST2 = sqlCommand.Parameters.Add("@GOODSMAKERCDST2", SqlDbType.Int);
                    paraGOODSMAKERCDST2.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdSt);
                }

                if (takekawaQuotaInventCndtnWork.GoodsMakerCdEd != 0)
                {
                    selectTxt.Append(" AND GOODSU.GOODSMAKERCDRF <= @GOODSMAKERCDED2 -- ���[�J�[�I�� ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDED2 = sqlCommand.Parameters.Add("@GOODSMAKERCDED2", SqlDbType.Int);
                    paraGOODSMAKERCDED2.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdEd);
                }

                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim()))
                {
                    selectTxt.Append(" AND WAREHOUSE.WAREHOUSECODERF >= @WAREHOUSECODEST4 -- �q�ɃR�[�h�J�n ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEST4 = sqlCommand.Parameters.Add("@WAREHOUSECODEST4", SqlDbType.NChar);
                    paraWAREHOUSECODEST4.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim());
                }

                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim()))
                {
                    selectTxt.Append(" AND WAREHOUSE.WAREHOUSECODERF <= @WAREHOUSECODEED4 -- �q�ɃR�[�h�I�� ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEED4 = sqlCommand.Parameters.Add("@WAREHOUSECODEED4", SqlDbType.NChar);
                    paraWAREHOUSECODEED4.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim());
                }

                if (takekawaQuotaInventCndtnWork.CustomerCodeSt != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF >= @CUSTOMERCODEST4 -- ���Ӑ�J�n ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEST4 = sqlCommand.Parameters.Add("@CUSTOMERCODEST4", SqlDbType.Int);
                    paraCUSTOMERCODEST4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeSt);
                }
                if (takekawaQuotaInventCndtnWork.CustomerCodeEd != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF <= @CUSTOMERCODEED4 -- ���Ӑ�I�� ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEED4 = sqlCommand.Parameters.Add("@CUSTOMERCODEED4", SqlDbType.Int);
                    paraCUSTOMERCODEED4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeEd);
                }


                selectTxt.Append("  --���_, ���Ӑ�, �q��, �I��, �i��,���[�J�[ ").Append(Environment.NewLine);
                selectTxt.Append(" ORDER BY CUSTOMER.MNGSECTIONCODERF ASC, WAREHOUSE.CUSTOMERCODERF ASC, WAREHOUSE.WAREHOUSECODERF ASC, INVENTORYDATA.WAREHOUSESHELFNORF ASC, INVENTORYDATA.GOODSNORF ASC, INVENTORYDATA.GOODSMAKERCDRF ASC ").Append(Environment.NewLine);
                selectTxt.Append(" , GOODSPRICEU.PRICESTARTDATERF DESC ").Append(Environment.NewLine);

                #endregion

                sqlCommand.CommandText = selectTxt.ToString();

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();


                // key : ���[�J�[�@�{�@�i��
                Dictionary<string, string> goodsDic = new Dictionary<string, string>();

                // �a�k���i�R�[�h�}�X�^Dictionary(�L�[�FBL���i�R�[�h)
                Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic = new Dictionary<int, BLGoodsCdUWork>();

                while (myReader.Read())
                {
                    // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                    //TakekawaQuotaInventResultWork resultWork = CopyToTakekawaInventResultWorkFromReader(ref myReader, takekawaQuotaInventCndtnWork,
                    //    ref goodsDic, ref tempGoodsPriceUWorkList, ref salesTtlStDic, ref blGoodsCdUDic);
                    TakekawaQuotaInventResultWork resultWork = CopyToTakekawaInventResultWorkFromReader(ref myReader, takekawaQuotaInventCndtnWork,
                        ref goodsDic, ref tempGoodsPriceUWorkList, ref salesTtlStDic, ref blGoodsCdUDic, convertDoubleRelease);
                    // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<

                    if (resultWork != null)
                    {
                        retList.Add(resultWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchProcForInventory Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }

                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            }

            takekawaQuotaInventResultWork = retList;
            goodsPriceUWorkList = tempGoodsPriceUWorkList; 

            return status;
        }
        #endregion  //[SearchProcForInventory]

        #region �� [���Ӑ�ʌ��Ϗ����o���ʃN���X�i�[����]
        /// <summary>
        /// ���Ӑ�ʌ��Ϗ��E�I���\���o���ʃN���X�i�[���� Reader �� TakekawaQuotaInventResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsMngDic1">���_�{���[�J�[�{�i��Dictionary</param>
        /// <param name="goodsMngDic2">���_�{�����ށ{���[�J�[�{�a�k�R�[�hDictionary</param>
        /// <param name="goodsMngDic3">���_�{�����ށ{���[�J�[Dictionary</param>
        /// <param name="goodsMngDic4">���_�{���[�J�[Dictionary</param>
        /// <param name="takekawaQuotaInventCndtnWork">��������</param>
        /// <param name="goodsSupplierGetter">GoodsSupplierGetter</param>
        /// <param name="goodsDic">���i���`�F�b�N�pDictionary</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name="salesTtlStDic">�S�Ĕ���S�̐ݒ���Dictionary</param>
        /// <param name="blGoodsCdUDic">�a�k���i�R�[�h�}�X�^Dictionary</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>TakekawaQuotaInventResultWork</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
        //private TakekawaQuotaInventResultWork CopyToTakekawaQuotaResultWorkFromReader(ref SqlDataReader myReader,
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // ���_�{���[�J�[�{�i��
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // ���_�{�����ށ{���[�J�[�{�a�k�R�[�h
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // ���_�{�����ށ{���[�J�[
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // ���_�{���[�J�[
        //    TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,// ��������
        //    ref GoodsSupplierGetter goodsSupplierGetter,
        //    ref Dictionary<string, string> goodsDic, 
        //    ref ArrayList goodsPriceUWorkList,
        //    ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
        //    ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic)
        private TakekawaQuotaInventResultWork CopyToTakekawaQuotaResultWorkFromReader(ref SqlDataReader myReader,
            ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // ���_�{���[�J�[�{�i��
            ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // ���_�{�����ށ{���[�J�[�{�a�k�R�[�h
            ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // ���_�{�����ށ{���[�J�[
            ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // ���_�{���[�J�[
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,// ��������
            ref GoodsSupplierGetter goodsSupplierGetter,
            ref Dictionary<string, string> goodsDic,
            ref ArrayList goodsPriceUWorkList,
            ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
            ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic,
            ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
        {
            //�t�B���^
            // �݌Ƀ}�X�^�̋��_�R�[�h�Ɠ��Ӑ�̊Ǘ����_�s���ŁA�ΏۊO�Ƃ���
            string customerMngSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();
            string stockSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_SECTIONCODERF")).Trim();
            if (!customerMngSection.Equals(stockSection))
            {
                return null;
            }

            TakekawaQuotaInventResultWork resultWork = new TakekawaQuotaInventResultWork();
            #region [���o����-�l�Z�b�g]
            resultWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // ���_����
            resultWork.SectionPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));// ���_�X�֔ԍ�
            resultWork.SectionAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));// ���_�Z���@
            resultWork.SectionAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));// ���_�Z���A
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));// �q�ɃR�[�h
            resultWork.WarehouseNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// �q�ɖ���
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));// �q�ɒI��
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));// ���i�ԍ�
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));// ���i����
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));// ���i���[�J�[�R�[�h
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// ���_�R�[�h
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));// ���Ӑ�R�[�h
            resultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));// ���Ӑ於�̂P
            resultWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));// ���Ӑ於�̂P
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));// BL���i�R�[�h

            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BL�O���[�v�R�[�h
            resultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));//���i�|���O���[�v�R�[�h
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//���i�|�������N
            resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));//�ېŋ敪

            resultWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));//���Ӑ�̔���P���[�������R�[�h
            resultWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));//���Ӑ�̔������Œ[�������R�[�h

            resultWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));// ������̓��Ӑ����œ]�ŕ����Q�Ƌ敪
            resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// ������̏���œ]�ŕ���




            // ���Ӑ�̊Ǘ����_���A����S�̐ݒ���擾
            SalesTtlStWork tempSalesTtlStWork = null;
            if (salesTtlStDic.ContainsKey(resultWork.SectionCode.Trim()))
            {
                tempSalesTtlStWork = salesTtlStDic[resultWork.SectionCode.Trim()];
            }

            // �����_���Ȃ��ꍇ�A�S�̂̔���グ�S�̐ݒ���擾
            if (null == tempSalesTtlStWork)
            {
                if (salesTtlStDic.ContainsKey("00"))
                {
                    tempSalesTtlStWork = salesTtlStDic["00"];
                }
            }

            // BL�R�[�h�O�Ή����f����
            if ((null != tempSalesTtlStWork) && (resultWork.BLGoodsCode == 0) && 
                (tempSalesTtlStWork.BLGoodsCdZeroSuprt == 1) && // BL�R�[�h�O�Ή��t���O
                    (tempSalesTtlStWork.BLGoodsCdChange > 0)) // �ϊ��R�[�h������
            {
                // �ϊ��R�[�h�ēx�ݒ�
                resultWork.BLGoodsCode = tempSalesTtlStWork.BLGoodsCdChange;

                #region BLGoodsCode�ēx�ύX�̏ꍇ�A���֏��ēx�ݒ肪�K�v�ł��B
                if (blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                {
                    // BL�O���[�v�R�[�h
                    resultWork.BLGroupCode = blGoodsCdUDic[resultWork.BLGoodsCode].BLGroupCode;
                    // ���i�|���O���[�v�R�[�h
                    resultWork.GoodsRateGrpCode = blGoodsCdUDic[resultWork.BLGoodsCode].GoodsRateGrpCode;
                }
                else
                {
                    BLGoodsCdUWork tempBLGoodsCdUWork = new BLGoodsCdUWork();

                    // BL���i���Č���
                    int blGoodsCdU_status = this.SearchBLInfo(takekawaQuotaInventCndtnWork.EnterpriseCode,
                        resultWork.BLGoodsCode,
                        out tempBLGoodsCdUWork);
                    if (0 == blGoodsCdU_status)
                    {
                        // BL�O���[�v�R�[�h
                        resultWork.BLGroupCode = tempBLGoodsCdUWork.BLGroupCode;
                        // ���i�|���O���[�v�R�[�h
                        resultWork.GoodsRateGrpCode = tempBLGoodsCdUWork.GoodsRateGrpCode;

                        if (!blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                        {
                            blGoodsCdUDic.Add(resultWork.BLGoodsCode, tempBLGoodsCdUWork);
                        }
                    }
                }
                #endregion
            }

            // BL�R�[�h�t�B���^����
            if ((resultWork.BLGoodsCode < takekawaQuotaInventCndtnWork.BLGoodsCodeSt)
                    || (resultWork.BLGoodsCode > takekawaQuotaInventCndtnWork.BLGoodsCodeEd))
            {
                return null;
            }

            // �J�n���i�I�Ԕ���
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoSt))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, "<", takekawaQuotaInventCndtnWork.WarehouseShelfNoSt, 8))
                {
                    return null;
                }
            }

            // �I�����i�I�Ԕ���
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoEd))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, ">", takekawaQuotaInventCndtnWork.WarehouseShelfNoEd, 8))
                {
                    return null;
                }
            }

            // �d����R�[�h
            int supplierCd = 0;

            #region ���i�d���擾�f�[�^�N���X
            GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
            goodsSupplierDataWork.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode;// ��ƃR�[�h
            goodsSupplierDataWork.SectionCode = resultWork.SectionCode;      �@// ���Ӑ�̊Ǘ����_�R�[�h
            goodsSupplierDataWork.GoodsMakerCd = resultWork.GoodsMakerCd;     // ���[�J�[�R�[�h
            goodsSupplierDataWork.GoodsNo = resultWork.GoodsNo;              // ���i�ԍ�
            goodsSupplierDataWork.BLGoodsCode = resultWork.BLGoodsCode;     // BL�R�[�h
            goodsSupplierDataWork.GoodsMGroup = resultWork.GoodsRateGrpCode; // ���i������
            goodsSupplierGetter.GetSupplierInfo(ref goodsSupplierDataWork, goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4);

            // ���_��茟�����Ȃ��ꍇ�A�S�Ђōēx�������܂��B
            if (null != goodsSupplierDataWork)
            {
                supplierCd = goodsSupplierDataWork.SupplierCd;
            }
            else
            {
                supplierCd = 0;
            }

            // �d����R�[�h�ݒ�
            resultWork.SupplierCd = supplierCd;


            // �������d����R�[�h�t�B���^����������
            if ((supplierCd < takekawaQuotaInventCndtnWork.StSupplierCd) 
                || (supplierCd > takekawaQuotaInventCndtnWork.EdSupplierCd))
            {
                return null;
            }
            #endregion

            #region ���i�}�X�^���擾
            // ���i�}�X�^���擾
            GoodsPriceUWork tempGoodsPriceUWork = new GoodsPriceUWork();
            tempGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            tempGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            tempGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            //tempGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = tempGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = tempGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            tempGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            tempGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            tempGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            tempGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            tempGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            tempGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            if ((tempGoodsPriceUWork.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(tempGoodsPriceUWork.GoodsNo)))
            {
                goodsPriceUWorkList.Add(tempGoodsPriceUWork);
            }
            #endregion

            // ��ʕ\���p�݌ɏ��͈�擾
            // key : �q�� + �i�� �{���[�J�[
            string key = resultWork.WarehouseCode + ":"
              + resultWork.GoodsNo + ":"
              + resultWork.GoodsMakerCd.ToString();
            if (goodsDic.ContainsKey(key))
            {
                return null;
            }
            else
            {
                goodsDic.Add(key, key);
            }


            // ���i���Ȃ��ꍇ�A���i���̍ēx�ݒ肪�K�v�ł�
            if (string.IsNullOrEmpty(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSU_GOODSNORF"))))
            {
                resultWork.GoodsName = "********************";
            }


            #endregion  //[���o����-�l�Z�b�g]

            return resultWork;
        }

        /// <summary>
        /// ���Ӑ�ʒI���\���o���ʃN���X�i�[���� Reader �� TakekawaQuotaInventResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="takekawaQuotaInventCndtnWork">��������</param>
        /// <param name="goodsDic">���i�`�F�b�N�pDictionary</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name="salesTtlStDic">�S�Ĕ���S�̐ݒ���Dictionary</param>
        /// <param name="blGoodsCdUDic">�a�k���i�R�[�h�}�X�^Dictionary</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>TakekawaQuotaInventResultWork</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
        //private TakekawaQuotaInventResultWork CopyToTakekawaInventResultWorkFromReader(ref SqlDataReader myReader, 
        //    TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,
        //    ref Dictionary<string, string> goodsDic, 
        //    ref ArrayList goodsPriceUWorkList,
        //    ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
        //    ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic)
        private TakekawaQuotaInventResultWork CopyToTakekawaInventResultWorkFromReader(ref SqlDataReader myReader,
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,
            ref Dictionary<string, string> goodsDic,
            ref ArrayList goodsPriceUWorkList,
            ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
            ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic,
            ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
        {
            //�t�B���^
            // �I���f�[�^�̋��_�R�[�h�Ɠ��Ӑ�̊Ǘ����_�s���ŁA�ΏۊO�Ƃ���
            string customerMngSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();
            string inventorySection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INVENTORYDATA_SECTIONCODERF")).Trim();
            if (!customerMngSection.Equals(inventorySection))
            {
                return null;
            }

            TakekawaQuotaInventResultWork resultWork = new TakekawaQuotaInventResultWork();
            #region [���o����-�l�Z�b�g]
            resultWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // ���_����
            resultWork.SectionPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));// ���_�X�֔ԍ�
            resultWork.SectionAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));// ���_�Z���@
            resultWork.SectionAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));// ���_�Z���A
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));// �q�ɃR�[�h
            resultWork.WarehouseNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// �q�ɖ���
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));// �q�ɒI��
            resultWork.StockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("InventoryStockCntRF"));// �I���݌ɐ�(��ʕ\���p)
            resultWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF1"));// �I���݌ɐ�(�`�F�b�N�p)
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));// ���i�ԍ�
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));// ���i����
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));// ���i���[�J�[�R�[�h
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// ���_�R�[�h
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));// ���Ӑ�R�[�h
            resultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));// ���Ӑ於�̂P
            resultWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));// ���Ӑ於�̂P
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));// �a�k���i�R�[�h
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));// �d����R�[�h

            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BL�O���[�v�R�[�h
            resultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));//���i�|���O���[�v�R�[�h
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//���i�|�������N
            resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));//�ېŋ敪

            resultWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));//���Ӑ�̔���P���[�������R�[�h
            resultWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));//���Ӑ�̔������Œ[�������R�[�h

            resultWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));// ������̓��Ӑ����œ]�ŕ����Q�Ƌ敪
            resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// ������̏���œ]�ŕ���

            // ���Ӑ�̊Ǘ����_���A����S�̐ݒ���擾
            SalesTtlStWork tempSalesTtlStWork = null;
            if (salesTtlStDic.ContainsKey(resultWork.SectionCode.Trim()))
            {
                tempSalesTtlStWork = salesTtlStDic[resultWork.SectionCode.Trim()];
            }

            // �����_���Ȃ��ꍇ�A�S�̂̔���グ�S�̐ݒ���擾
            if (null == tempSalesTtlStWork)
            {
                if (salesTtlStDic.ContainsKey("00"))
                {
                    tempSalesTtlStWork = salesTtlStDic["00"];
                }
            }


            if ((null != tempSalesTtlStWork) && 
                (resultWork.BLGoodsCode == 0) &&
                (tempSalesTtlStWork.BLGoodsCdZeroSuprt == 1) && // BL�R�[�h�O�Ή��t���O
                (tempSalesTtlStWork.BLGoodsCdChange > 0)) // �ϊ��R�[�h������
            {
                resultWork.BLGoodsCode = tempSalesTtlStWork.BLGoodsCdChange;

                #region BLGoodsCode�ēx�ύX�̏ꍇ�A���֏��ēx�ݒ肪�K�v�ł��B
                if (blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                {
                    // BL�O���[�v�R�[�h
                    resultWork.BLGroupCode = blGoodsCdUDic[resultWork.BLGoodsCode].BLGroupCode;
                    // ���i�|���O���[�v�R�[�h(������)
                    resultWork.GoodsRateGrpCode = blGoodsCdUDic[resultWork.BLGoodsCode].GoodsRateGrpCode;
                }
                else
                {
                    BLGoodsCdUWork tempBLGoodsCdUWork = new BLGoodsCdUWork();

                    // BL���i���Č���
                    int blGoodsCdU_status = this.SearchBLInfo(takekawaQuotaInventCndtnWork.EnterpriseCode,
                        resultWork.BLGoodsCode,
                        out tempBLGoodsCdUWork);
                    if (0 == blGoodsCdU_status)
                    {
                        // BL�O���[�v�R�[�h
                        resultWork.BLGroupCode = tempBLGoodsCdUWork.BLGroupCode;
                        // ���i�|���O���[�v�R�[�h
                        resultWork.GoodsRateGrpCode = tempBLGoodsCdUWork.GoodsRateGrpCode;

                        if (!blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                        {
                            blGoodsCdUDic.Add(resultWork.BLGoodsCode, tempBLGoodsCdUWork);
                        }
                    }
                }
                #endregion
            }

            // BL�R�[�h�t�B���^����
            if ((resultWork.BLGoodsCode < takekawaQuotaInventCndtnWork.BLGoodsCodeSt)
                    || (resultWork.BLGoodsCode > takekawaQuotaInventCndtnWork.BLGoodsCodeEd))
            {
                return null;
            }

            // �J�n���i�I�Ԕ���
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoSt))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, "<", takekawaQuotaInventCndtnWork.WarehouseShelfNoSt, 8))
                {
                    return null;
                }
            }

            // �I�����i�I�Ԕ���
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoEd))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, ">", takekawaQuotaInventCndtnWork.WarehouseShelfNoEd, 8))
                {
                    return null;
                }
            }

            #region ���i�}�X�^���擾
            // ���i�}�X�^���擾
            GoodsPriceUWork tempGoodsPriceUWork = new GoodsPriceUWork();
            tempGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            tempGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            tempGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ---------->>>>>
            //tempGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = tempGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = tempGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            tempGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/08/20 ������ PMKOBETSU-4005 ----------<<<<<
            tempGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            tempGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            tempGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            tempGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            tempGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            if ((tempGoodsPriceUWork.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(tempGoodsPriceUWork.GoodsNo)))
            {
                goodsPriceUWorkList.Add(tempGoodsPriceUWork);
            }
            #endregion

            // ��ʕ\���p�݌ɏ��͈�擾
            // key : �q�Ɂ@�{�@�i�ԁ@�{���[�J�[ +
            string key = resultWork.WarehouseCode + ":"
              + resultWork.GoodsNo + ":"
              + resultWork.GoodsMakerCd.ToString();

            if (goodsDic.ContainsKey(key))
            {
                return null;
            }
            else
            {
                goodsDic.Add(key, key);
            }

            // ���i���Ȃ��ꍇ�A���i���̍ēx�ݒ肪�K�v�ł�
            if (string.IsNullOrEmpty(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSU_GOODSNORF"))))
            {
                resultWork.GoodsName = "********************";
            }
            #endregion  //[���o����-�l�Z�b�g]
            return resultWork;
        }
        #endregion

        #region BL���i�R�[�h���ABL���i�R�[�h�}�X�^��񌟍�����
        /// <summary>
        /// BL���i�R�[�h���ABL���i�R�[�h�}�X�^��BL�O���[�v��񌟍�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="blGoodsCode">bl���i�R�[�h</param>
        /// <param name="blGoodsCdUWork">BL���i�R�[�h�}�X�^���</param>
        /// <returns></returns>
        private int SearchBLInfo(string enterpriseCode, int blGoodsCode, out BLGoodsCdUWork blGoodsCdUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            blGoodsCdUWork = null;

            SqlConnection sqlConnection = null;

            try
            {
                //SQL������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();


                status = SearchBlInfoProc(ref sqlConnection, enterpriseCode, blGoodsCode,
                    out blGoodsCdUWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchBLInfo Exception=" + ex.Message);
                blGoodsCdUWork = null;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��BL���i�R�[�h�}�X�^���߂��܂�
        /// </summary>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="blGoodsCode">�a�k�R�[�h</param>
        /// <param name="blGoodsCdUWork">BL���i�R�[�h�}�X�^���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        private int SearchBlInfoProc(ref SqlConnection sqlConnection, 
            string enterpriseCode, int blGoodsCode,
            out BLGoodsCdUWork blGoodsCdUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //��������
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            blGoodsCdUWork = null;

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);


                selectTxt.Append(" SELECT ").Append(Environment.NewLine);
                selectTxt.Append(" BLGOODSCDU.BLGOODSCODERF,-- BL���i�R�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BL�O���[�v�R�[�h  ").Append(Environment.NewLine);
                selectTxt.Append(" BLGROUPU.GOODSMGROUPRF -- ���i�����ރR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" FROM BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED)  --�a�k�R�[�h�}�X�^(���[�U�[) ").Append(Environment.NewLine);
                selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED)  --BL�O���[�v�}�X�^�i���[�U�[�o�^���j ").Append(Environment.NewLine);
                selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BL�O���[�v�R�[�h ").Append(Environment.NewLine);

                selectTxt.Append(" WHERE ").Append(Environment.NewLine);
                selectTxt.Append(" BLGOODSCDU.ENTERPRISECODERF = @ENTERPRISECODE1 -- ��ƃR�[�h ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                selectTxt.Append(" AND BLGOODSCDU.BLGOODSCODERF = @BLGOODSCODE -- BL�R�[�h ").Append(Environment.NewLine);

                SqlParameter paraBLGOODSCODE = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.NChar);
                paraBLGOODSCODE.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                sqlCommand.CommandText = selectTxt.ToString();

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    CopyToBlInfoResultWorkFromReader(ref myReader, out blGoodsCdUWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                blGoodsCdUWork = null;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchBlInfoProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                blGoodsCdUWork = null;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// BL���i�R�[�h�}�X�^��񒊏o���ʃN���X�i�[���� Reader �� BLGoodsCdUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blGoodsCdUWork">�a�k���i�R�[�h�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        private void CopyToBlInfoResultWorkFromReader(ref SqlDataReader myReader, 
            out BLGoodsCdUWork blGoodsCdUWork)
        {
            blGoodsCdUWork = new BLGoodsCdUWork();

            blGoodsCdUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
            blGoodsCdUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));    // BL�O���[�v�R�[�h
            blGoodsCdUWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));// ���i�����ރR�[�h
        }
        #endregion

        #region �� [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
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

        #endregion

        #region �������r����
        /// <summary>
        /// �������r�����@
        /// </summary>
        /// <param name="sStr1">��r�Ώە�����P</param>
        /// <param name="sCTL">�R���g���[��</param>
        /// <param name="sStr2">��r�Ώە�����Q</param>
        /// <param name="iMaxLen">��r�ő啶����</param>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note		: ��������r���܂�</br>
        /// <br>Programmer	: songg</br>
        /// <br>Date		: K2013/12/03</br>
        /// </remarks>
        private Boolean xCOMPSTR(string sStr1, string sCTL, string sStr2, int iMaxLen)
        {
            string pStr1 = string.Empty;
            string pStr2 = string.Empty;
            int iDumyLen;
            int iLen1;
            int iLen2;
            int iRet;
            int iIdx;
            int iStrLen;
            string sWrk1;
            string sWrk2;
            string sDumySpace;

            Boolean result = false;
            sWrk1 = sStr1;
            sWrk2 = sStr2;

            // ��r������P�̕ҏW
            iStrLen = sStr1.Length;
            iDumyLen = iMaxLen - iStrLen;
            sDumySpace = "";
            for (iIdx = 1; iIdx <= iDumyLen; iIdx++)
            {
                sDumySpace = sDumySpace + " ";
            }
            sWrk1 = sWrk1 + sDumySpace;


            iLen1 = 0;


            // ��r������Q�̕ҏW
            iStrLen = sStr2.Length;
            iDumyLen = iMaxLen - iStrLen;
            sDumySpace = "";
            for (iIdx = 1; iIdx <= iDumyLen; iIdx++)
            {
                sDumySpace = sDumySpace + " ";
            }
            sWrk2 = sWrk2 + sDumySpace;

            // ��r������Q��'*'�̌���
            iLen2 = sWrk2.LastIndexOf('*');

            if ((iLen1 <= 0) && (iLen2 <= 0))
            {
                iLen1 = iMaxLen;
                iLen2 = iMaxLen;
            }
            else
            {
                if (iLen1 <= 0)
                {
                    iLen1 = iLen2;
                }
                else
                {
                    iLen2 = iLen1;
                }
            }

            //�������r
            pStr1 = sWrk1.Substring(0, iLen1);

            pStr2 = sWrk2.Substring(0, iLen2);

            iRet = string.Compare(pStr1, pStr2, StringComparison.Ordinal);

            // sStr1 = Str2
            if (sCTL.Equals("="))
            {
                if (iRet == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 > Str2
            if (sCTL.Equals(">"))
            {
                if (iRet > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 < Str2
            if (sCTL.Equals("<"))
            {
                if (iRet < 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 >= Str2
            if (sCTL.Equals(">="))
            {
                if (iRet >= 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 <= Str2
            if (sCTL.Equals("<="))
            {
                if (iRet <= 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }
        #endregion

    }
}


    

