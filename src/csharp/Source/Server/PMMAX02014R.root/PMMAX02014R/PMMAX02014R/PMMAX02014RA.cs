//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�ꊇ�X�V
// �v���O�����T�v   : �o�i�ꊇ�X�V DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/01/22   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : 杍^
// �� �� ��  2020/06/18   �C�����e : PMKOBETSU-4005 �d�a�d�΍�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources; 
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �o�i�ꊇ�X�VDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �o�i�ꊇ�X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �v��</br>
    /// <br>Date        : 2016/01/22</br>
    /// <br>Update Note : PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class PartsMaxStockUpdDB : RemoteDB, IPartsMaxStockUpdDB
    {
        #region Private Const
        // �ő匟������
        private const int MAXCOUNT = 100000;
        #endregion

        #region PartsMaxStockUpdDB�@�R���X�g���N�^
        /// <summary>
        /// �o�i�ꊇ�X�V�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public PartsMaxStockUpdDB()
        {
        }
        #endregion

        #region Private Method
        /// <summary>
        /// SELECT��SQL��
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="partsMaxStockUpdateCndtnWork">��������</param>
        /// <returns>select��</returns>
        /// <br>Note       : SELECT��SQL����߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        private String GetSelectStr(SqlCommand sqlCommand, PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork)
        {
            StringBuilder selectTxt = new StringBuilder();

            selectTxt.Append(" SELECT  ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.PRICESTARTDATERF, -- ���i�}�X�^.���i�J�n��").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.LISTPRICERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.SALESUNITCOSTRF, ").Append(Environment.NewLine); // ���i�}�X�^�̌����P��
            selectTxt.Append(" GOODSPRICEU.STOCKRATERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.OPENPRICEDIVRF, --���i�}�X�^.�I�[�v�����i�敪").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSPRICEU.OFFERDATERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.UPDATEDATERF, ").Append(Environment.NewLine);

            selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BL�O���[�v�R�[�h").Append(Environment.NewLine);
            selectTxt.Append(" BLGOODSCDU.GOODSRATEGRPCODERF, --���i�|���O���[�v�R�[�h").Append(Environment.NewLine);
            selectTxt.Append(" STOCK.ENTERPRISECODERF, -- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.WAREHOUSECODERF, -- �q�ɃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.GOODSMAKERCDRF, -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.GOODSNORF, -- ���i�ԍ� ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.SHIPMENTPOSCNTRF, --�o�׉\��").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSU.GOODSNAMERF, -- ���i���� ").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSU.BLGOODSCODERF, -- �a�k���i�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSU.GOODSRATERANKRF, -- ���i�|�������N ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSU.TAXATIONDIVCDRF,-- �ېŋ敪 ").Append(Environment.NewLine);
            selectTxt.Append(" MAKERU.MAKERNAMERF, -- ���i���[�J�[���� ").Append(Environment.NewLine);                                     
            selectTxt.Append(" BLGROUPU.GOODSMGROUPRF, -- ���i�����ރR�[�h ").Append(Environment.NewLine);
            selectTxt.Append(" WAREHOUSE.WAREHOUSENAMERF, -- �q�ɖ��� ").Append(Environment.NewLine);                                     
            selectTxt.Append(" WAREHOUSE.SECTIONCODERF --�q�Ƀ}�X�^�̊Ǘ����_ ").Append(Environment.NewLine);                                     


            selectTxt.Append(" FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) -- �݌Ƀ}�X�^ ").Append(Environment.NewLine);
            // ���i�}�X�^
            selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --���i�}�X�^").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSNORF = GOODSU.GOODSNORF -- ���i�ԍ� ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" LEFT JOIN MAKERURF AS MAKERU WITH (READUNCOMMITTED) --���[�J�[�}�X�^�i���[�U�[�o�^���j").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = MAKERU.ENTERPRISECODERF -- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = MAKERU.GOODSMAKERCDRF -- ���i���[�J�[�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND MAKERU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --�a�k���i�R�[�h�}�X�^(���[�U�[)").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL���i�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BL�O���[�v�}�X�^�i���[�U�[�o�^���j").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BL�O���[�v�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND BLGROUPU.LOGICALDELETECODERF = 0-- �_���폜�敪 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" INNER JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) --�q�Ƀ}�X�^").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF-- �q�ɃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND WAREHOUSE.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

            // ���i�}�X�^�����擾����
            selectTxt.Append(" LEFT JOIN GOODSPRICEURF AS GOODSPRICEU WITH (READUNCOMMITTED)--���i�}�X�^ ").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSPRICEU.ENTERPRISECODERF-- ��ƃR�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSPRICEU.GOODSMAKERCDRF--���i���[�J�[�R�[�h ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSNORF = GOODSPRICEU.GOODSNORF--���i�ԍ� ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND GOODSPRICEU.LOGICALDELETECODERF = 0--�_���폜�敪 ").Append(Environment.NewLine);                                     

            selectTxt.Append("AND GOODSPRICEU.PRICESTARTDATERF =  ").Append(Environment.NewLine);
            selectTxt.Append("(SELECT MAX(PRICESTARTDATERF) ").Append(Environment.NewLine);
            selectTxt.Append("FROM GOODSPRICEURF GSP_B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

            selectTxt.Append("WHERE GSP_B.ENTERPRISECODERF=STOCK.ENTERPRISECODERF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSNORF=STOCK.GOODSNORF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.PRICESTARTDATERF <= @PRICESTARTDATE)").Append(Environment.NewLine);
            SqlParameter paraPRICESTARTDATE = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
            paraPRICESTARTDATE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.PriceStartDate);

            return selectTxt.ToString();
        }

        /// <summary>
        /// WHERE����SQL��
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="partsMaxStockUpdateCndtnWork">��������</param>
        /// <returns>where����SQL��</returns>
        /// <br>Note       : WHERE��SQL����߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        private String GetWhereStr(SqlCommand sqlCommand, PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork)
        {
            StringBuilder selectTxt = new StringBuilder();

            selectTxt.Append("  WHERE  ").Append(Environment.NewLine);
            selectTxt.Append("  STOCK.ENTERPRISECODERF = @ENTERPRISECODE1 -- ��ƃR�[�h ").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(partsMaxStockUpdateCndtnWork.EnterpriseCode);
            selectTxt.Append("  AND STOCK.LOGICALDELETECODERF = 0 -- �_���폜�敪 ").Append(Environment.NewLine);


            // �q�ɺ��ރ��X�g
            if (null != partsMaxStockUpdateCndtnWork.WarehouseCodes &&
                partsMaxStockUpdateCndtnWork.WarehouseCodes.Length > 0)
            {
                string warehouseCodestr = "";
                foreach (string warehousecdstr in partsMaxStockUpdateCndtnWork.WarehouseCodes)
                {
                    if (warehouseCodestr != "")
                    {
                        warehouseCodestr += ",";
                    }
                    warehouseCodestr += "'" + warehousecdstr + "'";
                }

                if (warehouseCodestr != "")
                {
                    selectTxt.Append(" AND STOCK.WAREHOUSECODERF IN (" + warehouseCodestr + ") -- �q�ɃR�[�h ").Append(Environment.NewLine);
                }
            }

            // �݌ɍŏI�X�V���t
            // �݌�.�X�V�N���� >= ���.�݌ɍŏI�X�V���t
            if (partsMaxStockUpdateCndtnWork.LastStockUpdDate != 0)
            {
                selectTxt.Append(" AND STOCK.UPDATEDATERF >= @LASTSTOCKUPDDATE  ").Append(Environment.NewLine);
                SqlParameter paraLASTSTOCKUPDDATE = sqlCommand.Parameters.Add("@LASTSTOCKUPDDATE", SqlDbType.Int);
                paraLASTSTOCKUPDDATE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.LastStockUpdDate);
            }

            // ���i.BL�R�[�h = ���.BL�R�[�h
            if (partsMaxStockUpdateCndtnWork.BLGoodsCode != 0)
            {
                selectTxt.Append(" AND GOODSU.BLGOODSCODERF = @BLGOODSCODE  ").Append(Environment.NewLine);
                SqlParameter paraBLGOODSCODE = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGOODSCODE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.BLGoodsCode);
            }

            // ���[�J�[
            if (partsMaxStockUpdateCndtnWork.GoodsMakerCd != 0)
            {
                selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = @GOODSMAKERCD -- ���[�J�[ ").Append(Environment.NewLine);
                SqlParameter paraGOODSMAKERCD = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGOODSMAKERCD.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.GoodsMakerCd);
            }

            // BL�R�[�h�}�X�^.���i�|���O���[�v�R�[�h = ���.���i�|��G
            if (partsMaxStockUpdateCndtnWork.RateGrpCode != 0)
            {
                selectTxt.Append(" AND BLGOODSCDU.GOODSRATEGRPCODERF = @RATEGRPCODE -- ���i�|��G ").Append(Environment.NewLine);
                SqlParameter paraRATEGRPCODE = sqlCommand.Parameters.Add("@RATEGRPCODE", SqlDbType.Int);
                paraRATEGRPCODE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.RateGrpCode);
            }


            //�O���[�v�R�[�h�}�X�^.�����ރR�[�h = ���.������
            if (partsMaxStockUpdateCndtnWork.GoodsMGroup != 0)
            {
                selectTxt.Append(" AND BLGROUPU.GOODSMGROUPRF = @GOODSMGROUP -- ������ ").Append(Environment.NewLine);
                SqlParameter paraGOODSMGROUP = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                paraGOODSMGROUP.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.GoodsMGroup);
            }

            selectTxt.Append(" ORDER BY STOCK.WAREHOUSECODERF, STOCK.GOODSMAKERCDRF, STOCK.GOODSNORF");

            return selectTxt.ToString();
        }

        /// <summary>
        /// �o�i�ꊇ�X�V���o���ʃN���X�i�[���� Reader �� PartsMaxStockUpdateResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsMngDic1">���_�{���[�J�[�{�i��Dictionary</param>
        /// <param name="goodsMngDic2">���_�{�����ށ{���[�J�[�{�a�k�R�[�hDictionary</param>
        /// <param name="goodsMngDic3">���_�{�����ށ{���[�J�[Dictionary</param>
        /// <param name="goodsMngDic4">���_�{���[�J�[Dictionary</param>
        /// <param name="partsMaxStockUpdateCndtnWork">��������</param>
        /// <param name="goodsSupplierGetter">GoodsSupplierGetter</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>PartsMaxStockUpdateResultWork</returns>
        /// <remarks>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
        //private PartsMaxStockUpdateResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader,
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // ���_�{���[�J�[�{�i��
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // ���_�{�����ށ{���[�J�[�{�a�k�R�[�h
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // ���_�{�����ށ{���[�J�[
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // ���_�{���[�J�[
        //    PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,// ��������
        //    ref GoodsSupplierGetter goodsSupplierGetter)
        private PartsMaxStockUpdateResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader,
            ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // ���_�{���[�J�[�{�i��
            ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // ���_�{�����ށ{���[�J�[�{�a�k�R�[�h
            ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // ���_�{�����ށ{���[�J�[
            ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // ���_�{���[�J�[
            PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,// ��������
            ref GoodsSupplierGetter goodsSupplierGetter, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
        {
            PartsMaxStockUpdateResultWork resultWork = new PartsMaxStockUpdateResultWork();
            #region [���o����-�l�Z�b�g]

            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));// �q�ɃR�[�h
            resultWork.WarehouseNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// �q�ɖ���
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));// ���i�ԍ�
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));// ���i����
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));// ���i���[�J�[�R�[�h
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// �q�ɂ̊Ǘ����_�R�[�h
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));// ���[�J�[����
            resultWork.StockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));// �݌Ƀ}�X�^.�o�׉\��
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));// BL���i�R�[�h
            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BL�O���[�v�R�[�h    BL�R�[�h�}�X�^�DBL��ٰ�ߺ���
            resultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));//���i�|���O���[�v�R�[�h    BL�R�[�h�}�X�^.���i�|���O���[�v�R�[�h 
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//���i�|�������N    ���i�}�X�^(���[�U�[)�D���i�|�������N
            resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));// �ېŋ敪

            resultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            //resultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = partsMaxStockUpdateCndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = resultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = resultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            resultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            resultWork.GpuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));// ���i�}�X�^�̌����P��
            resultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));// �I�[�v�����i�敪
            resultWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            resultWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            // �d����R�[�h
            int supplierCd = 0;

            #region ���i�d���擾�f�[�^�N���X
            GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
            goodsSupplierDataWork.EnterpriseCode = partsMaxStockUpdateCndtnWork.EnterpriseCode;// ��ƃR�[�h
            goodsSupplierDataWork.SectionCode = resultWork.SectionCode;      �@// ���Ӑ�̊Ǘ����_�R�[�h
            goodsSupplierDataWork.GoodsMakerCd = resultWork.GoodsMakerCd;     // ���[�J�[�R�[�h
            goodsSupplierDataWork.GoodsNo = resultWork.GoodsNo;              // ���i�ԍ�
            goodsSupplierDataWork.BLGoodsCode = resultWork.BLGoodsCode;     // BL�R�[�h

            int goodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));// ���i������
            goodsSupplierDataWork.GoodsMGroup = goodsMGroup; // ���i������
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
            if ((partsMaxStockUpdateCndtnWork.SupplierCd != 0)
                && (supplierCd != partsMaxStockUpdateCndtnWork.SupplierCd))
            {
                return null;
            }
            #endregion

            #endregion  //[���o����-�l�Z�b�g]

            return resultWork;
        }
        #endregion  //[Search]

        #region ���������擾
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��iMAX�����擾����
        /// </summary>
        /// <param name="searchCount">��������</param>
        /// <param name="partsMaxStockUpdateCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̕��iMAX�����擾�������܂�</br>
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public int SearchCount(out int searchCount, object partsMaxStockUpdateCndtnWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            searchCount = 0;
            errMessage = "";
            PartsMaxStockUpdateCndtnWork paraCndtnWork = partsMaxStockUpdateCndtnWork as PartsMaxStockUpdateCndtnWork;

            try
            {
                //SQL������
                using (SqlConnection sqlConnection = CreateSqlConnection(true))
                {
                    if (sqlConnection == null) return status;

                    status = SearchCountProc(out searchCount,
                        paraCndtnWork, sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.SearchCount Exception=" + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �o�i�ꊇ�X�V������S�Ė߂��܂�
        /// </summary>
        /// <param name="searchCount">��������</param>
        /// <param name="partsMaxStockUpdateCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �o�i�ꊇ�X�VLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchCountProc(out int searchCount,
            PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,
            SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            searchCount = 0;

            //��������
            SqlDataReader myReader = null;

            ArrayList retList = new ArrayList();   //���o����
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            try
            {
                StringBuilder selectTxt = new StringBuilder();
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection))
                {
                    // [Select���쐬]
                    #region [Select���쐬]
                    selectTxt.Append(GetSelectStr(sqlCommand, partsMaxStockUpdateCndtnWork));
                    #endregion

                    // [Where���쐬]
                    #region [Where���쐬]
                    selectTxt.Append(GetWhereStr(sqlCommand, partsMaxStockUpdateCndtnWork));
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
                    goodsSupplierGetter.GetGoodsMngInfo(partsMaxStockUpdateCndtnWork.EnterpriseCode,
                        ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);


                    while (myReader.Read())
                    {
                        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                        //PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                        //    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                        //    partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter);
                        PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                            ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                            partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter, convertDoubleRelease);
                        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                        if (null != resultWork)
                        {
                            ++searchCount;

                            if (searchCount > MAXCOUNT)
                            {
                                break;
                            }
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // �f�[�^���Ȃ��ꍇ�A
                    if (searchCount == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    else if (searchCount > MAXCOUNT)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }
                }
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.SearchCountProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion
        
        #region �f�[�^�擾
        /// �w�肳�ꂽ�����̏o�i�ꊇ�X�V��߂��܂�
        /// <param name="partsMaxStockUpdateResultWork">��������</param>
        /// <param name="partsMaxStockUpdateCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <br>Note       : �w�肳�ꂽ�����̏o�i�ꊇ�X�V��߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        public int Search(out object partsMaxStockUpdateResultWork,
            object partsMaxStockUpdateCndtnWork, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            partsMaxStockUpdateResultWork = null;
            errMessage = string.Empty;

            PartsMaxStockUpdateCndtnWork paraCndtnWork = partsMaxStockUpdateCndtnWork as PartsMaxStockUpdateCndtnWork;
            try
            {
                //SQL������
                using (SqlConnection sqlConnection = CreateSqlConnection(true))
                {
                    if (sqlConnection == null) return status;


                    status = SearchProc(out partsMaxStockUpdateResultWork,
                        paraCndtnWork, sqlConnection, out errMessage, loopIndex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.Search Exception=" + ex.Message);
                partsMaxStockUpdateResultWork = new ArrayList();
                errMessage = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �o�i�ꊇ�X�VLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="partsMaxStockUpdateResultWork">��������</param>
        /// <param name="partsMaxStockUpdateCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Note       : �o�i�ꊇ�X�VLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchProc(out object partsMaxStockUpdateResultWork,
            PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,
            SqlConnection sqlConnection, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            errMessage = "";
            //��������
            SqlDataReader myReader = null;
            partsMaxStockUpdateResultWork = null;

            ArrayList retList = new ArrayList();   //���o����
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            try
            {
                StringBuilder selectTxt = new StringBuilder();
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection))
                {
                    // [Select���쐬]
                    #region [Select���쐬]
                    selectTxt.Append(GetSelectStr(sqlCommand, partsMaxStockUpdateCndtnWork));
                    #endregion

                    // [Where���쐬]
                    #region [Where���쐬]
                    selectTxt.Append(GetWhereStr(sqlCommand, partsMaxStockUpdateCndtnWork));
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
                    goodsSupplierGetter.GetGoodsMngInfo(partsMaxStockUpdateCndtnWork.EnterpriseCode,
                        ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);


                    // key : ���[�J�[�@�{�@�i��
                    Dictionary<string, string> goodsDic = new Dictionary<string, string>();

                    int cnt = 0;
                    while (myReader.Read())
                    {
                        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                        //PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                        //    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                        //    partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter);
                        PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                            ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                            partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter, convertDoubleRelease);
                        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                        if (null != resultWork)
                        {
                            cnt++;

                            if ((cnt >= (loopIndex * partsMaxStockUpdateCndtnWork.DataSize + 1))
                                &&
                                (cnt <= ((loopIndex + 1) * partsMaxStockUpdateCndtnWork.DataSize)))
                            {
                                retList.Add(resultWork);
                            }
                        }


                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // �f�[�^���Ȃ��ꍇ�A
                    if ((null == retList) || (retList.Count == 0))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }

            partsMaxStockUpdateResultWork = retList;

            return status;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ����� false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection���������B</br>
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }
        #endregion  //�R�l�N�V������������
    }
}
