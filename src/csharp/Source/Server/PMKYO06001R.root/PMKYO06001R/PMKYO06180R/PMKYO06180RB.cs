//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/05/25  �C�����e : INT��DATETIME�ύX�o�O
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/06/08  �C�����e : �}�X�^����M�s���Ή��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/08/20  �C�����e : myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/08  �C�����e : #23777 �\�[�X���r���[
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00  �쐬�S�� : �c����
// �C �� ��  2020/10/10   �C�����e : PMKOBETSU-4005 ���i�}�X�^�@�艿���l�ϊ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00 �쐬�S�� : ���O
// �� �� ��  2021/08/04  �C�����e : BLINCIDENT-2974 ���i�����������������s���Ȃ��̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common; // ADD 2020/10/10 �c���� PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^�i���[�U�[�o�^�jREADDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>Update Note: BLINCIDENT-2974 ���i�����������������s���Ȃ��̑Ή�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2021/08/04</br>
    /// </remarks>
    public class APGoodsPriceUDB : RemoteDB
    {
        private const string MST_GOODSPRICEU = "���i�}�X�^(���i���)";

        // ���i
        private const string MST_ID_LISTPRICERF = "ListPriceRF";
        // �I�[�v�����i�敪
        private const string MST_ID_OPENPRICEDIVRF = "OpenPriceDivRF";
        // ���i�J�n��
        private const string MST_ID_PRICESTARTDATERF = "PriceStartDateRF";
        // ���P��
        private const string MST_ID_SALESUNITCOSTRF = "SalesUnitCostRF";
        // �d����
        private const string MST_ID_STOCKRATERF = "StockRateRF";

        // ���i
        private Int32 listPriceInt = 0;

        // �I�[�v�����i�敪
        private Int32 openPriceDivInt = 0;

        // ���i�J�n��
        private Int32 priceStartDateInt = 0;

        // ���P��
        private Int32 salesUnitCostInt = 0;

        // �d����
        private Int32 stockRateInt = 0;

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�jREADDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APGoodsPriceUDB()
            : base("PMKYO06181D", "Broadleaf.Application.Remoting.ParamData.APGoodsPriceUWork", "GOODSPRICEURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsPriceUArrList">���i�}�X�^�i���[�U�[�o�^�j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchGoodsPriceU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        {
            return SearchGoodsPriceUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                             sqlTransaction, out goodsPriceUArrList, out retMessage);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsPriceUArrList">���i�}�X�^�i���[�U�[�o�^�j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/10/10</br>
        /// <br>Update Note: BLINCIDENT-2974 ���i�����������������s���Ȃ��̑Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/08/04</br>
        private int SearchGoodsPriceUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsPriceUArrList = new ArrayList();
            APGoodsPriceUWork goodsPriceUWork = null;
            retMessage = string.Empty;
            // ------ UPD 2021/08/04 ���O BLINCIDENT-2974-------->>>>>
            //string sqlStr = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            // ------ UPD 2021/08/04 ���O BLINCIDENT-2974--------<<<<<
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //----- ADD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // ------ UPD 2021/08/04 ���O BLINCIDENT-2974-------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, PRICESTARTDATERF, LISTPRICERF, SALESUNITCOSTRF, STOCKRATERF, OPENPRICEDIVRF, OFFERDATERF, UPDATEDATERF FROM GOODSPRICEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("A.CREATEDATETIMERF" + Environment.NewLine);
                sqlStr.Append(", B.UPDATEDATETIMERF" + Environment.NewLine);
                sqlStr.Append(", A.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(", A.FILEHEADERGUIDRF" + Environment.NewLine);
                sqlStr.Append(", A.UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlStr.Append(", A.UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlStr.Append(", A.UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlStr.Append(", A.LOGICALDELETECODERF" + Environment.NewLine);
                sqlStr.Append(", A.GOODSMAKERCDRF" + Environment.NewLine);
                sqlStr.Append(", A.GOODSNORF" + Environment.NewLine);
                sqlStr.Append(", A.PRICESTARTDATERF" + Environment.NewLine);
                sqlStr.Append(", A.LISTPRICERF" + Environment.NewLine);
                sqlStr.Append(", A.SALESUNITCOSTRF" + Environment.NewLine);
                sqlStr.Append(", A.STOCKRATERF" + Environment.NewLine);
                sqlStr.Append(", A.OPENPRICEDIVRF" + Environment.NewLine);
                sqlStr.Append(", A.OFFERDATERF" + Environment.NewLine);
                sqlStr.Append(", A.UPDATEDATERF " + Environment.NewLine);
                sqlStr.Append("FROM GOODSPRICEURF AS A RIGHT JOIN " + Environment.NewLine);
                sqlStr.Append(" (SELECT DISTINCT ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" ,GOODSMAKERCDRF" + Environment.NewLine);
                sqlStr.Append(" ,GOODSNORF " + Environment.NewLine);
                sqlStr.Append(" ,MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF " + Environment.NewLine);
                sqlStr.Append("  FROM GOODSPRICEURF" + Environment.NewLine);
                sqlStr.Append("  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlStr.Append("  AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF" + Environment.NewLine);//�X�V���������M�J�n��
                sqlStr.Append("  AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF" + Environment.NewLine);//�X�V����<=���M�I����
                sqlStr.Append("  GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF) AS B " + Environment.NewLine);
                sqlStr.Append("ON A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine);//��ƃR�[�h
                sqlStr.Append(" AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF" + Environment.NewLine);//���i���[�J�[
                sqlStr.Append("AND A.GOODSNORF = B.GOODSNORF" + Environment.NewLine);//�i��
                // ------ UPD 2021/08/04 ���O BLINCIDENT-2974--------<<<<<
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���i�}�X�^�i���[�U�[�o�^�j�f�[�^�pSQL
                // ------ UPD 2021/08/04 ���O BLINCIDENT-2974-------->>>>>
                //sqlCommand.CommandText = sqlStr;
                sqlCommand.CommandText = sqlStr.ToString();
                // ------ UPD 2021/08/04 ���O BLINCIDENT-2974--------<<<<<
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsPriceUWork = new APGoodsPriceUWork();

                    goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
                    //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // �ϊ��������s
                    convertDoubleRelease.ReleaseProc();

                    goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<   
                    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    goodsPriceUArrList.Add(goodsPriceUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsPriceUDB.SearchGoodsPriceU Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                //----- ADD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�̌v����������
        /// </summary>
        /// <param name="goodsPriceUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsPriceUCount(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsPriceUCountProc(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�̌v����������
        /// </summary>
        /// <param name="goodsPriceUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsPriceUCountProc(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GOODSPRICEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND PRICESTARTDATERF=@FINDPRICESTARTDATE";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = goodsPriceUWork.GoodsNo;
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                // ���_���ݒ�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsPriceUDB.SearchGoodsPriceUCount Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�̌v����������
        /// </summary>
        /// <param name="goodsPriceUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsUCount(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsUCountProc(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�̌v����������
        /// </summary>
        /// <param name="goodsPriceUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsUCountProc(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = goodsPriceUWork.GoodsNo;

                // ���_���ݒ�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsUDB.SearchGoodsUCount Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        ///  ���i�}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="apGoodsPriceUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���i�}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="apGoodsPriceUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM GOODSPRICEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO ";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            //SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = apGoodsPriceUWork.EnterpriseCode;
            findParaGoodsMakerCd.Value = apGoodsPriceUWork.GoodsMakerCd;
            findParaGoodsNo.Value = apGoodsPriceUWork.GoodsNo;
            // DEL 2009/06/09 ----->>>
            //if (apGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
            //{
            //    findParaPriceStartDate.Value = 0;
            //}
            //else
            //{
            //    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate);
            //}
            // DEL 2009/06/09 -----<<<
            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="apGoodsPriceUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="apGoodsPriceUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/10/10</br>
        private void InsertProc(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            // --- ADD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            try
            {
            // --- ADD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Delete�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO GOODSPRICEURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, PRICESTARTDATERF, LISTPRICERF, SALESUNITCOSTRF, STOCKRATERF, OPENPRICEDIVRF, OFFERDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @GOODSMAKERCD, @GOODSNO, @PRICESTARTDATE, @LISTPRICE, @SALESUNITCOST, @STOCKRATE, @OPENPRICEDIV, @OFFERDATE, @UPDATEDATE)";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsPriceUWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.GoodsMakerCd);
                if (string.IsNullOrEmpty(apGoodsPriceUWork.GoodsNo.Trim()))
                {
                    paraGoodsNo.Value = apGoodsPriceUWork.GoodsNo;
                }
                else
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.GoodsNo);
                }
                // MOD 2009/05/25 --->>>
                if (apGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
                {
                    paraPriceStartDate.Value = 0;
                }
                else
                {
                    paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate);
                }
                // MOD 2009/05/25 ---<<<
                // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.ListPrice);
                convertDoubleRelease.EnterpriseCode = apGoodsPriceUWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = apGoodsPriceUWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = apGoodsPriceUWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = apGoodsPriceUWork.ListPrice;

                // �ϊ��������s
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.SalesUnitCost);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.StockRate);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.OpenPriceDiv);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.OfferDate);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.UpdateDate);


                // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            // --- ADD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
            }
            finally
            {
                // ���
                convertDoubleRelease.Dispose();
            }
            // --- ADD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
        }
        #endregion

        # region [Update]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�X�V
        /// </summary>
        /// <param name="masterDtlDivList">�}�X�^�ڍ׋敪</param>
        /// <param name="apGoodsPriceUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���X�V����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Update(ArrayList masterDtlDivList, APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            UpdateProc(masterDtlDivList, apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�X�V
        /// </summary>
        /// <param name="masterDtlDivList">�}�X�^�ڍ׋敪</param>
        /// <param name="apGoodsPriceUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���X�V����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void UpdateProc(ArrayList masterDtlDivList, APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in masterDtlDivList)
            {
                // ���i
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_LISTPRICERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    listPriceInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �I�[�v�����i�敪
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_OPENPRICEDIVRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    openPriceDivInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // ���i�J�n��
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_PRICESTARTDATERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    priceStartDateInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // ���P��
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SALESUNITCOSTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    salesUnitCostInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �d����
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKRATERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    stockRateInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
            }

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            string sqlText = string.Empty;

            // Delete�R�}���h�̐���
            sqlText = "UPDATE GOODSPRICEURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE ";
            sqlText = sqlText + " , GOODSMAKERCDRF=@GOODSMAKERCD ";
            sqlText = sqlText + " , GOODSNORF=@GOODSNO ";
            // ���i�J�n��
            if (priceStartDateInt == 0)
            {
                sqlText = sqlText + " , PRICESTARTDATERF=@PRICESTARTDATE ";
            }
            // ���i
            if (listPriceInt == 0)
            {
                sqlText = sqlText + " , LISTPRICERF=@LISTPRICE ";
            }
            // ���P��
            if (salesUnitCostInt == 0)
            {
                sqlText = sqlText + " , SALESUNITCOSTRF=@SALESUNITCOST ";
            }
            // �d����
            if (stockRateInt == 0)
            {
                sqlText = sqlText + " , STOCKRATERF=@STOCKRATE ";
            }
            // �I�[�v�����i�敪
            if (openPriceDivInt == 0)
            {
                sqlText = sqlText + " , OPENPRICEDIVRF=@OPENPRICEDIV ";
            }
            sqlText = sqlText + " , OFFERDATERF=@OFFERDATE ";
            sqlText = sqlText + " , UPDATEDATERF=@UPDATEDATE ";
            sqlText = sqlText + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND PRICESTARTDATERF=@FINDPRICESTARTDATE ";

            sqlCommand.CommandText = sqlText;

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            // ���i�J�n��
            if (priceStartDateInt == 0)
            {
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                // MOD 2009/05/25 --->>>
                if (apGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
                {
                    paraPriceStartDate.Value = 0;
                }
                else
                {
                    paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate);
                }
                // MOD 2009/05/25 ---<<<
            }
            // ���i
            if (listPriceInt == 0)
            {
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                paraListPrice.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.ListPrice);
            }
            // ���P��
            if (salesUnitCostInt == 0)
            {
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.SalesUnitCost);
            }
            // �d����
            if (stockRateInt == 0)
            {
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.StockRate);
            }
            // �I�[�v�����i�敪
            if (openPriceDivInt == 0)
            {
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.OpenPriceDiv);
            }

            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsPriceUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.LogicalDeleteCode);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apGoodsPriceUWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apGoodsPriceUWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.GoodsNo);
            }
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.OfferDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.UpdateDate);

            //Parameter�I�u�W�F�N�g�̍쐬(�����p)
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.EnterpriseCode);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.GoodsMakerCd); ;
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.GoodsNo); ;
            findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate); ;


            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 �\�[�X���r���[
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^�j�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="goodsPriceUArrList">���i�}�X�^�i���[�U�[�o�^�j�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchGoodsPriceU(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        //{
        //    return SearchGoodsPriceUProc(enterpriseCodes, paramList, sqlConnection,
        //                       sqlTransaction, out goodsPriceUArrList, out retMessage);
        //}
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^�j�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="goodsPriceUArrList">���i�}�X�^�i���[�U�[�o�^�j�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchGoodsPriceUProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    goodsPriceUArrList = new ArrayList();
        //    //APGoodsPriceUWork goodsPriceUWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    APGoodsProcParamWork param = paramList as APGoodsProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, PRICESTARTDATERF, LISTPRICERF, SALESUNITCOSTRF, STOCKRATERF, OPENPRICEDIVRF, OFFERDATERF, UPDATEDATERF FROM GOODSPRICEURF ";
        //        sqlStr += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

        //        if (param.UpdateDateTimeBegin != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
        //        }
        //        if (param.UpdateDateTimeEnd != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
        //        }
        //        if (param.GoodsMakerCdBeginRF != 0)
        //        {
        //            sqlStr += " AND GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
        //            SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
        //            goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
        //        }

        //        if (param.GoodsMakerCdEndRF != 0)
        //        {
        //            sqlStr += " AND GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
        //            SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
        //            goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
        //        {
        //            sqlStr += " AND GOODSNORF >= @GOODSNOBEGINRF";
        //            SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
        //            goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
        //        {
        //            sqlStr += " AND GOODSNORF <= @GOODSNOENDRF";
        //            SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
        //            goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
        //        }

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

        //        //���i�}�X�^�i���[�U�[�o�^�j�f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;

        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        //            //goodsPriceUWork = new APGoodsPriceUWork();

        //            //goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //            //goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //            //goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
        //            //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
        //            //goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
        //            //goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
        //            //goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
        //            //goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //            //goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

        //            //goodsPriceUArrList.Add(goodsPriceUWork);
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        //            #endregion DEL
        //            goodsPriceUArrList.Add(CopyFromMyReaderToAPGoodsPriceUWork(myReader));//ADD 2011/08/20 �r���[�i�`�F�b�N
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "APGoodsPriceUDB.SearchGoodsPriceU Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    return status;
        //}

        ////-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���擾
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>���i�}�X�^�i���[�U�[�o�^�j�f�[�^</returns>
        ///// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��߂��܂�</br>
        ///// <br>Programmer : �g���Y</br>
        ///// <br>Date       : 2011/08/20</br>
        //private APGoodsPriceUWork CopyFromMyReaderToAPGoodsPriceUWork(SqlDataReader myReader)
        //{
        //    APGoodsPriceUWork goodsPriceUWork = new APGoodsPriceUWork();

        //    goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //    goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
        //    goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
        //    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
        //    goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
        //    goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
        //    goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //    goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

        //    return goodsPriceUWork;
        //}
        ////-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        #endregion
        #endregion
        #endregion 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
    }
}

