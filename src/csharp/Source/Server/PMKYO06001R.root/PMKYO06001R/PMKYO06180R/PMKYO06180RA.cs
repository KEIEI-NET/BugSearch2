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
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------///
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/08/20  �C�����e : myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/08/25  �C�����e : #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/08/29  �C�����e : #24046 �}�X�^����M��ʁF���i�}�X�^�������M�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/02  �C�����e : #24364 ���i�}�X�^�̎d����w��ɂ��� 
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
    /// ���i�}�X�^�i���[�U�[�o�^���jREADDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2020/10/10</br>
    /// <br>Update Note: BLINCIDENT-2974 ���i�����������������s���Ȃ��̑Ή�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2021/08/04</br>
    /// </remarks>
    public class APGoodsUDB : RemoteDB
    {

        #region �� Const Memebers ��
        private const string MST_GOODSNAME = "���i�}�X�^";

        private const string MST_ID_BLGOODSCODERF = "BLGoodsCodeRF";
        private const string MST_ID_ENTERPRISEGANRECODERF = "EnterpriseGanreCodeRF";
        private const string MST_ID_GOODSKINDCODERF = "GoodsKindCodeRF";
        private const string MST_ID_GOODSNAMEKANARF = "GoodsNameKanaRF";
        private const string MST_ID_GOODSNAMERF = "GoodsNameRF";
        private const string MST_ID_GOODSNOTE1RF = "GoodsNote1RF";
        private const string MST_ID_GOODSNOTE2RF = "GoodsNote2RF";
        private const string MST_ID_GOODSRATERANKRF = "GoodsRateRankRF";
        private const string MST_ID_GOODSSPECIALNOTERF = "GoodsSpecialNoteRF";
        private const string MST_ID_JANRF = "JanRF";
        private const string MST_ID_TAXATIONDIVCDRF = "TaxationDivCdRF";

        // BL�R�[�h
        private Int32 blGoodsCodeInt = 0;
        // ���i�敪
        private Int32 enterpriseGanreCodeInt = 0;
        // ���i����
        private Int32 goodsKindCodeInt = 0;
        // �i����
        private Int32 goodsNameKanaInt = 0;
        // �i��
        private Int32 goodsNameInt = 0;
        // ���i���l
        private Int32 goodsNote1Int = 0;
        // ���i���l�Q
        private Int32 goodsNote2Int = 0;
        // �w��
        private Int32 goodsRateRankInt = 0;
        // �K�i�E���L����
        private Int32 goodsSpecialNoteInt = 0;
        // JAN�R�[�h
        private Int32 janInt = 0;
        // �ېŋ敪
        private Int32 taxationDivCdInt = 0;
        #endregion

        #region private
        //���i�}�X�^(���[�U�[�o�^��)
        private int _indexACreateDateTime;
        private int _indexAUpdateDateTime;
        private int _indexAEnterpriseCode;
        private int _indexAFileHeaderGuid;
        private int _indexAUpdEmployeeCode;
        private int _indexAUpdAssemblyId1;
        private int _indexAUpdAssemblyId2;
        private int _indexALogicalDeleteCode;
        private int _indexAGoodsMakerCd;
        private int _indexAGoodsNo;
        private int _indexAGoodsName;
        private int _indexAGoodsNameKana;
        private int _indexAJan;
        private int _indexABLGoodsCode;
        private int _indexADisplayOrder;
        private int _indexAGoodsRateRank;
        private int _indexATaxationDivCd;
        private int _indexAGoodsNoNoneHyphen;
        private int _indexAOfferDate;
        private int _indexAGoodsKindCode;
        private int _indexAGoodsNote1;
        private int _indexAGoodsNote2;
        private int _indexAGoodsSpecialNote;
        private int _indexAEnterpriseGanreCode;
        private int _indexAUpdateDate;
        private int _indexAOfferDataDiv;
        //���i�Ǘ����}�X�^
        private int _indexBCreateDateTime;
        private int _indexBUpdateDateTime;
        private int _indexBEnterpriseCode;
        private int _indexBFileHeaderGuid;
        private int _indexBUpdEmployeeCode;
        private int _indexBUpdAssemblyId1;
        private int _indexBUpdAssemblyId2;
        private int _indexBLogicalDeleteCode;
        private int _indexBSectionCode;
        private int _indexBGoodsMGroup;
        private int _indexBGoodsMakerCd;
        private int _indexBBLGoodsCode;
        private int _indexBGoodsNo;
        private int _indexBSupplierCd;
        private int _indexBSupplierLot;
        //���i�}�X�^(���[�U�[�o�^��)
        private int _indexCCreateDateTime;
        private int _indexCUpdateDateTime;
        private int _indexCEnterpriseCode;
        private int _indexCFileHeaderGuid;
        private int _indexCUpdEmployeeCode;
        private int _indexCUpdAssemblyId1;
        private int _indexCUpdAssemblyId2;
        private int _indexCLogicalDeleteCode;
        private int _indexCGoodsMakerCd;
        private int _indexCGoodsNo;
        private int _indexCPriceStartDate;
        private int _indexCListPrice;
        private int _indexCSalesUnitCost;
        private int _indexCStockRate;
        private int _indexCOpenPriceDiv;
        private int _indexCOfferDate;
        private int _indexCUpdateDate;
        //�������i�}�X�^
        private int _indexDCreateDateTime;
        private int _indexDUpdateDateTime;
        private int _indexDEnterpriseCode;
        private int _indexDFileHeaderGuid;
        private int _indexDUpdEmployeeCode;
        private int _indexDUpdAssemblyId1;
        private int _indexDUpdAssemblyId2;
        private int _indexDLogicalDeleteCode;
        private int _indexDSectionCode;
        private int _indexDMakerCode;
        private int _indexDUpperLimitPrice;
        private int _indexDFractionProcUnit;
        private int _indexDFractionProcCd;
        private int _indexDUpRate;
        #endregion

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���jREADDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APGoodsUDB()
            : base("PMKYO06181D", "Broadleaf.Application.Remoting.ParamData.APGoodsUWork", "GOODSURF")
        {

        }

        #region [Read]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsUArrList">���i�}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchGoodsU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsUArrList, out string retMessage)
        {
            return SearchGoodsUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsUArrList, out retMessage);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsUArrList">���i�}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchGoodsUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsUArrList = new ArrayList();
            APGoodsUWork goodsUWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, JANRF, BLGOODSCODERF, DISPLAYORDERRF, GOODSRATERANKRF, TAXATIONDIVCDRF, GOODSNONONEHYPHENRF, OFFERDATERF, GOODSKINDCODERF, GOODSNOTE1RF, GOODSNOTE2RF, GOODSSPECIALNOTERF, ENTERPRISEGANRECODERF, UPDATEDATERF, OFFERDATADIVRF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //���i�}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsUWork = new APGoodsUWork();

                    goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    goodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    goodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                    goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    goodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    goodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    goodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    goodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    goodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    goodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                    goodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                    goodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
                    goodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    goodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    goodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

                    goodsUArrList.Add(goodsUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsUDB.SearchGoodsU Exception=" + ex.Message);
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
            }
            return status;
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�̌v����������
        /// </summary>
        /// <param name="goodsUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsUCount(APGoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsUCountProc(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�̌v����������
        /// </summary>
        /// <param name="goodsUWork">�����I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^�v����S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsUCountProc(APGoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
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
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUWork.GoodsMakerCd);
                findParaGoodsNo.Value = goodsUWork.GoodsNo;

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
        /// <param name="apGoodsUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APGoodsUWork apGoodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apGoodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  ���i�}�X�^�i���[�U�[�o�^�j�f�[�^�폜
        /// </summary>
        /// <param name="apGoodsUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���폜����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APGoodsUWork apGoodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "DELETE FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";
            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = apGoodsUWork.EnterpriseCode;
            findParaGoodsMakerCd.Value = apGoodsUWork.GoodsMakerCd;
            findParaGoodsNo.Value = apGoodsUWork.GoodsNo;


            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���폜����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="apGoodsUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APGoodsUWork apGoodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apGoodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�o�^
        /// </summary>
        /// <param name="apGoodsUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^��o�^����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(APGoodsUWork apGoodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Delete�R�}���h�̐���
            sqlCommand.CommandText = "INSERT INTO GOODSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, JANRF, BLGOODSCODERF, DISPLAYORDERRF, GOODSRATERANKRF, TAXATIONDIVCDRF, GOODSNONONEHYPHENRF, OFFERDATERF, GOODSKINDCODERF, GOODSNOTE1RF, GOODSNOTE2RF, GOODSSPECIALNOTERF, ENTERPRISEGANRECODERF, UPDATEDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @GOODSMAKERCD, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @JAN, @BLGOODSCODE, @DISPLAYORDER, @GOODSRATERANK, @TAXATIONDIVCD, @GOODSNONONEHYPHEN, @OFFERDATE, @GOODSKINDCODE, @GOODSNOTE1, @GOODSNOTE2, @GOODSSPECIALNOTE, @ENTERPRISEGANRECODE, @UPDATEDATE, @OFFERDATADIV)";

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
            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
            SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
            SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
            SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
            SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
            SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
            SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
            SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
            SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
            SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
            SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.LogicalDeleteCode);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apGoodsUWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apGoodsUWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNo);
            }
            paraGoodsName.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsName);
            paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNameKana);
            paraJan.Value = SqlDataMediator.SqlSetString(apGoodsUWork.Jan);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.BLGoodsCode);
            paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.DisplayOrder);
            paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsRateRank);
            paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.TaxationDivCd);
            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNoNoneHyphen);
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsUWork.OfferDate);
            paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.GoodsKindCode);
            paraGoodsNote1.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNote1);
            paraGoodsNote2.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNote2);
            paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsSpecialNote);
            paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.EnterpriseGanreCode);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsUWork.UpdateDate);
            paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.OfferDataDiv);

            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Update]
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�X�V
        /// </summary>
        /// <param name="masterDtlDivList">�}�X�^�ڍ׋敪</param>
        /// <param name="apGoodsUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���X�V����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        public void Update(ArrayList masterDtlDivList, APGoodsUWork apGoodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            UpdateProc(masterDtlDivList, apGoodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�X�V
        /// </summary>
        /// <param name="masterDtlDivList">�}�X�^�ڍ׋敪</param>
        /// <param name="apGoodsUWork">���i�}�X�^�i���[�U�[�o�^�j�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���X�V����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.04.28</br>
        private void UpdateProc(ArrayList masterDtlDivList, APGoodsUWork apGoodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in masterDtlDivList) 
            {
                // BL�R�[�h
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_BLGOODSCODERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    blGoodsCodeInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // ���i�敪
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_ENTERPRISEGANRECODERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    enterpriseGanreCodeInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // ���i����
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSKINDCODERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsKindCodeInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �i����
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSNAMEKANARF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsNameKanaInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �i��
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSNAMERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsNameInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // ���i���l
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSNOTE1RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsNote1Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // ���i���l�Q
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSNOTE2RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsNote2Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �w��
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSRATERANKRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsRateRankInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �K�i�E���L����
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_GOODSSPECIALNOTERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    goodsSpecialNoteInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // JAN�R�[�h
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_JANRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    janInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // �ېŋ敪
                if (MST_GOODSNAME.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_TAXATIONDIVCDRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    taxationDivCdInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
            }
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            string sqlText = string.Empty;
            // Delete�R�}���h�̐���
            sqlText = "UPDATE GOODSURF SET CREATEDATETIMERF=@CREATEDATETIME ";
            sqlText = sqlText + " , UPDATEDATETIMERF=@UPDATEDATETIME ";
            sqlText = sqlText + " , ENTERPRISECODERF=@ENTERPRISECODE ";
            sqlText = sqlText + " , FILEHEADERGUIDRF=@FILEHEADERGUID ";
            sqlText = sqlText + " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ";
            sqlText = sqlText + " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ";
            sqlText = sqlText + " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ";
            sqlText = sqlText + " , LOGICALDELETECODERF=@LOGICALDELETECODE ";
            sqlText = sqlText + " , GOODSMAKERCDRF=@GOODSMAKERCD ";
            sqlText = sqlText + " , GOODSNORF=@GOODSNO ";
            // �i��
            if (goodsNameInt == 0)
            {
                sqlText = sqlText + " , GOODSNAMERF=@GOODSNAME ";
            }
            // �i����
            if (goodsNameKanaInt == 0)
            {
                sqlText = sqlText + " , GOODSNAMEKANARF=@GOODSNAMEKANA ";
            }
            // JAN�R�[�h
            if (janInt == 0)
            {
                sqlText = sqlText + " , JANRF=@JAN ";
            }
            // BL�R�[�h
            if (blGoodsCodeInt == 0)
            {
                sqlText = sqlText + " , BLGOODSCODERF=@BLGOODSCODE ";
            }
            sqlText = sqlText + " , DISPLAYORDERRF=@DISPLAYORDER ";
            // �w��
            if (goodsRateRankInt == 0)
            {
                sqlText = sqlText + " , GOODSRATERANKRF=@GOODSRATERANK ";
            }
            // �ېŋ敪
            if (taxationDivCdInt == 0)
            {
                sqlText = sqlText + " , TAXATIONDIVCDRF=@TAXATIONDIVCD ";
            }
            sqlText = sqlText + " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ";
            sqlText = sqlText + " , OFFERDATERF=@OFFERDATE ";
            // ���i����
            if (goodsKindCodeInt == 0)
            {
                sqlText = sqlText + " , GOODSKINDCODERF=@GOODSKINDCODE ";
            }
            // ���i���l
            if (goodsNote1Int == 0)
            {
                sqlText = sqlText + " , GOODSNOTE1RF=@GOODSNOTE1 ";
            }
            // ���i���l�Q
            if (goodsNote2Int == 0)
            {
                sqlText = sqlText + " , GOODSNOTE2RF=@GOODSNOTE2 ";
            }
            // �K�i�E���L����
            if (goodsSpecialNoteInt == 0)
            {
                sqlText = sqlText + " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE ";
            }
            // ���i�敪
            if (enterpriseGanreCodeInt == 0)
            {
                sqlText = sqlText + " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE ";
            }
            sqlText = sqlText + " , UPDATEDATERF=@UPDATEDATE ";
            sqlText = sqlText + " , OFFERDATADIVRF=@OFFERDATADIV ";

            sqlText = sqlText + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO ";

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
            // �i��
            if (goodsNameInt == 0)
            {
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsName);
            }
            // �i����
            if (goodsNameKanaInt == 0)
            {
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNameKana);
            }
            // JAN�R�[�h
            if (janInt == 0)
            {
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                paraJan.Value = SqlDataMediator.SqlSetString(apGoodsUWork.Jan);
            }
            // BL�R�[�h
            if (blGoodsCodeInt == 0)
            {
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.BLGoodsCode);
            }
            SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
            // �w��
            if (goodsRateRankInt == 0)
            {
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsRateRank);
            }
            // �ېŋ敪
            if (taxationDivCdInt == 0)
            {
                SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.TaxationDivCd);
            }
            SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            // ���i����
            if (goodsKindCodeInt == 0)
            {
                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.GoodsKindCode);
            }
            // ���i���l
            if (goodsNote1Int == 0)
            {
                SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                paraGoodsNote1.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNote1);
            }
            // ���i���l�Q
            if (goodsNote2Int == 0)
            {
                SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                paraGoodsNote2.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNote2);
            }
            // �K�i�E���L����
            if (goodsSpecialNoteInt == 0)
            {
                SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsSpecialNote);
            }
            // ���i�敪
            if (enterpriseGanreCodeInt == 0)
            {
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.EnterpriseGanreCode);
            }
            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
            SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.LogicalDeleteCode);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apGoodsUWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apGoodsUWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNo);
            }
            paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.DisplayOrder);
            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNoNoneHyphen);
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsUWork.OfferDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsUWork.UpdateDate);
            paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.OfferDataDiv);

            //Parameter�I�u�W�F�N�g�̍쐬(�����p)
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsUWork.EnterpriseCode);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsUWork.GoodsMakerCd); ;
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsUWork.GoodsNo); ;

            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��o�^����
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 �\�[�X���r���[
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^���j�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="goodsUArrList">���i�}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="goodsMngArrList">���i�Ǘ����}�X�^�f�[�^</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchGoodsU(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList goodsUArrList, out ArrayList goodsMngArrList, out string retMessage)
        //{
        //    return SearchGoodsUProc(enterpriseCodes, paramList, sqlConnection,
        //                      sqlTransaction, out goodsUArrList, out goodsMngArrList, out retMessage);
        //}
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^���j�̌�������
        ///// </summary>
        ///// <param name="enterpriseCodes">��ƃR�[�h</param>
        ///// <param name="paramList">��������</param>
        ///// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        ///// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        ///// <param name="goodsUArrList">���i�}�X�^�i���[�U�[�o�^���j�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="goodsMngArrList">���i�Ǘ����}�X�^�f�[�^</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchGoodsUProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList goodsUArrList, out ArrayList goodsMngArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    goodsUArrList = new ArrayList();
        //    goodsMngArrList = new ArrayList();
        //    //APGoodsUWork goodsUWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
        //    //APGoodsMngWork goodsMngWork = null;//DEL 2011/08/20 �r���[�i�`�F�b�N
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    APGoodsProcParamWork param = paramList as APGoodsProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT GOODSURF.CREATEDATETIMERF ACREATEDATETIMERF, GOODSURF.UPDATEDATETIMERF AUPDATEDATETIMERF, GOODSURF.ENTERPRISECODERF AENTERPRISECODERF, GOODSURF.FILEHEADERGUIDRF AFILEHEADERGUIDRF, GOODSURF.UPDEMPLOYEECODERF AUPDEMPLOYEECODERF, GOODSURF.UPDASSEMBLYID1RF AUPDASSEMBLYID1RF, GOODSURF.UPDASSEMBLYID2RF AUPDASSEMBLYID2RF, GOODSURF.LOGICALDELETECODERF ALOGICALDELETECODERF, GOODSURF.GOODSMAKERCDRF AGOODSMAKERCDRF, GOODSURF.GOODSNORF AGOODSNORF, GOODSURF.GOODSNAMERF AGOODSNAMERF, GOODSURF.GOODSNAMEKANARF AGOODSNAMEKANARF, GOODSURF.JANRF AJANRF, GOODSURF.BLGOODSCODERF ABLGOODSCODERF, GOODSURF.DISPLAYORDERRF ADISPLAYORDERRF, GOODSURF.GOODSRATERANKRF AGOODSRATERANKRF, GOODSURF.TAXATIONDIVCDRF ATAXATIONDIVCDRF, GOODSURF.GOODSNONONEHYPHENRF AGOODSNONONEHYPHENRF, GOODSURF.OFFERDATERF AOFFERDATERF, GOODSURF.GOODSKINDCODERF AGOODSKINDCODERF, GOODSURF.GOODSNOTE1RF AGOODSNOTE1RF, GOODSURF.GOODSNOTE2RF AGOODSNOTE2RF, GOODSURF.GOODSSPECIALNOTERF AGOODSSPECIALNOTERF, GOODSURF.ENTERPRISEGANRECODERF AENTERPRISEGANRECODERF, GOODSURF.UPDATEDATERF AUPDATEDATERF, GOODSURF.OFFERDATADIVRF AOFFERDATADIVRF ";
        //        sqlStr += " ,GOODSMNGRF.CREATEDATETIMERF BCREATEDATETIMERF, GOODSMNGRF.UPDATEDATETIMERF BUPDATEDATETIMERF, GOODSMNGRF.ENTERPRISECODERF BENTERPRISECODERF, GOODSMNGRF.FILEHEADERGUIDRF BFILEHEADERGUIDRF, GOODSMNGRF.UPDEMPLOYEECODERF BUPDEMPLOYEECODERF, GOODSMNGRF.UPDASSEMBLYID1RF BUPDASSEMBLYID1RF, GOODSMNGRF.UPDASSEMBLYID2RF BUPDASSEMBLYID2RF, GOODSMNGRF.LOGICALDELETECODERF BLOGICALDELETECODERF, GOODSMNGRF.SECTIONCODERF BSECTIONCODERF, GOODSMNGRF.GOODSMGROUPRF BGOODSMGROUPRF, GOODSMNGRF.GOODSMAKERCDRF BGOODSMAKERCDRF, GOODSMNGRF.BLGOODSCODERF BBLGOODSCODERF, GOODSMNGRF.GOODSNORF BGOODSNORF, GOODSMNGRF.SUPPLIERCDRF BSUPPLIERCDRF, GOODSMNGRF.SUPPLIERLOTRF BSUPPLIERLOTRF ";
        //        sqlStr += " FROM GOODSURF LEFT JOIN GOODSMNGRF ON GOODSMNGRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF AND GOODSMNGRF.BLGOODSCODERF = GOODSURF.BLGOODSCODERF AND GOODSMNGRF.GOODSNORF = GOODSURF.GOODSNORF ";
        //        sqlStr += " WHERE GOODSMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";
        //        sqlStr += " AND GOODSMNGRF.GOODSMGROUPRF=@GOODSMGROUPRF ";
        //        sqlStr += " AND GOODSURF.ENTERPRISECODERF=@FINDENTERPRISECODE ";

        //        if (param.UpdateDateTimeBegin != 0)
        //        {
        //            sqlStr += " AND GOODSURF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
        //        }
        //        if (param.UpdateDateTimeEnd != 0)
        //        {
        //            sqlStr += " AND GOODSURF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
        //        }
        //        if (param.SupplierCdBeginRF != 0)
        //        {
        //            sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
        //            SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
        //            supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
        //        }

        //        if (param.SupplierCdEndRF != 0)
        //        {
        //            sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF";
        //            SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
        //            supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
        //        }

        //        if (param.GoodsMakerCdBeginRF != 0)
        //        {
        //            sqlStr += " AND GOODSURF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
        //            SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
        //            goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
        //        }

        //        if (param.GoodsMakerCdEndRF != 0)
        //        {
        //            sqlStr += " AND GOODSURF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
        //            SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
        //            goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
        //        }

        //        if (param.BLGoodsCodeBeginRF != 0)
        //        {
        //            sqlStr += " AND GOODSURF.BLGOODSCODERF >= @BLGOODSCODEBEGINRF";
        //            SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
        //            bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
        //        }

        //        if (param.BLGoodsCodeEndRF != 0)
        //        {
        //            sqlStr += " AND GOODSURF.BLGOODSCODERF <= @BLGOODSCODEENDRF";
        //            SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
        //            bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
        //        {
        //            sqlStr += " AND GOODSURF.GOODSNORF >= @GOODSNOBEGINRF";
        //            SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
        //            goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
        //        {
        //            sqlStr += " AND GOODSURF.GOODSNORF <= @GOODSNOENDRF";
        //            SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
        //            goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
        //        }

        //        //Order By Key
        //        sqlStr += " ORDER BY GOODSURF.UPDATEDATETIMERF DESC";

        //        //Prameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //        SqlParameter goodsMGroupRF = sqlCommand.Parameters.Add("@GOODSMGROUPRF", SqlDbType.Int);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
        //        goodsMGroupRF.Value = SqlDataMediator.SqlSetInt32(0);

        //        //���i�}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
        //        sqlCommand.CommandText = sqlStr;

        //        // �ǂݍ���
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        //            //goodsUWork = new APGoodsUWork();
        //            //goodsMngWork = new APGoodsMngWork();

        //            //goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("ACREATEDATETIMERF"));
        //            //goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("AUPDATEDATETIMERF"));
        //            //goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AENTERPRISECODERF"));
        //            //goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("AFILEHEADERGUIDRF"));
        //            //goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUPDEMPLOYEECODERF"));
        //            //goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUPDASSEMBLYID1RF"));
        //            //goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUPDASSEMBLYID2RF"));
        //            //goodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ALOGICALDELETECODERF"));
        //            //goodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGOODSMAKERCDRF"));
        //            //goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNORF"));
        //            //goodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNAMERF"));
        //            //goodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNAMEKANARF"));
        //            //goodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AJANRF"));
        //            //goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ABLGOODSCODERF"));
        //            //goodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADISPLAYORDERRF"));
        //            //goodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSRATERANKRF"));
        //            //goodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ATAXATIONDIVCDRF"));
        //            //goodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNONONEHYPHENRF"));
        //            //goodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("AOFFERDATERF"));
        //            //goodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGOODSKINDCODERF"));
        //            //goodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNOTE1RF"));
        //            //goodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNOTE2RF"));
        //            //goodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSSPECIALNOTERF"));
        //            //goodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AENTERPRISEGANRECODERF"));
        //            //goodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("AUPDATEDATERF"));
        //            //goodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AOFFERDATADIVRF"));

        //            //goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BCREATEDATETIMERF"));
        //            //goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BUPDATEDATETIMERF"));
        //            //goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BENTERPRISECODERF"));
        //            //goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("BFILEHEADERGUIDRF"));
        //            //goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUPDEMPLOYEECODERF"));
        //            //goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUPDASSEMBLYID1RF"));
        //            //goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUPDASSEMBLYID2RF"));
        //            //goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLOGICALDELETECODERF"));
        //            //goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BSECTIONCODERF"));
        //            //goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BGOODSMGROUPRF"));
        //            //goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BGOODSMAKERCDRF"));
        //            //goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BBLGOODSCODERF"));
        //            //goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BGOODSNORF"));
        //            //goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BSUPPLIERCDRF"));
        //            //goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BSUPPLIERLOTRF"));

        //            //goodsUArrList.Add(goodsUWork);
        //            //goodsMngArrList.Add(goodsMngWork);
        //            //-----DEL 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        //            #endregion DEL
        //            //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        //            goodsUArrList.Add(CopyFromMyReaderToAPGoodsUWork(myReader));
        //            goodsMngArrList.Add(CopyFromMyReaderToAPGoodsMngWork(myReader));
        //            //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "APGoodsUWork.SearchGoodsU Exception=" + ex.Message);
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
        #endregion

        /// <summary>
        /// ���i�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsAllList">���i�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.25</br>
        public int SearchGoodsAll(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsAllList, out string retMessage)
        {
            return SearchGoodsAllProc(enterpriseCodes, paramList, sqlConnection,
                              sqlTransaction, out goodsAllList, out retMessage);
        }

        /// <summary>
        /// ���i�}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="goodsAllList">���i�}�X�^�f�[�^�I�u�W�F�N�g</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.25</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/10/10</br>
        private int SearchGoodsAllProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsAllList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsAllList = new ArrayList();
            ArrayList goodsUArrList = new ArrayList();
            ArrayList goodsMngArrList = new ArrayList();
            ArrayList goodsPriceUArrList = new ArrayList();
            ArrayList isolIslandPrcArrList = new ArrayList();

            Hashtable aHashTbl = new Hashtable();
            Hashtable bHashTbl = new Hashtable();
            Hashtable cHashTbl = new Hashtable();
            Hashtable dHashTbl = new Hashtable();            
            string aPK = "";
            string bPK = "";
            string cPK = "";
            string dPK = "";
            string space = "�@";//�S�p
            string emptyValue = "";

            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            APGoodsProcParamWork param = paramList as APGoodsProcParamWork;

            //----- ADD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                sqlStr.Append("SELECT ");
                sqlStr.Append("A.CREATEDATETIMERF ACREATEDATETIMERF, A.UPDATEDATETIMERF AUPDATEDATETIMERF, A.ENTERPRISECODERF AENTERPRISECODERF, A.FILEHEADERGUIDRF AFILEHEADERGUIDRF, A.UPDEMPLOYEECODERF AUPDEMPLOYEECODERF, A.UPDASSEMBLYID1RF AUPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF AUPDASSEMBLYID2RF, A.LOGICALDELETECODERF ALOGICALDELETECODERF, A.GOODSMAKERCDRF AGOODSMAKERCDRF, A.GOODSNORF AGOODSNORF, A.GOODSNAMERF AGOODSNAMERF, A.GOODSNAMEKANARF AGOODSNAMEKANARF, A.JANRF AJANRF, A.BLGOODSCODERF ABLGOODSCODERF, A.DISPLAYORDERRF ADISPLAYORDERRF, A.GOODSRATERANKRF AGOODSRATERANKRF, A.TAXATIONDIVCDRF ATAXATIONDIVCDRF, A.GOODSNONONEHYPHENRF AGOODSNONONEHYPHENRF, A.OFFERDATERF AOFFERDATERF, A.GOODSKINDCODERF AGOODSKINDCODERF, A.GOODSNOTE1RF AGOODSNOTE1RF, A.GOODSNOTE2RF AGOODSNOTE2RF, A.GOODSSPECIALNOTERF AGOODSSPECIALNOTERF, A.ENTERPRISEGANRECODERF AENTERPRISEGANRECODERF, A.UPDATEDATERF AUPDATEDATERF, A.OFFERDATADIVRF AOFFERDATADIVRF ");
                sqlStr.Append(" ,B.CREATEDATETIMERF BCREATEDATETIMERF, B.UPDATEDATETIMERF BUPDATEDATETIMERF, B.ENTERPRISECODERF BENTERPRISECODERF, B.FILEHEADERGUIDRF BFILEHEADERGUIDRF, B.UPDEMPLOYEECODERF BUPDEMPLOYEECODERF, B.UPDASSEMBLYID1RF BUPDASSEMBLYID1RF, B.UPDASSEMBLYID2RF BUPDASSEMBLYID2RF, B.LOGICALDELETECODERF BLOGICALDELETECODERF, B.SECTIONCODERF BSECTIONCODERF, B.GOODSMGROUPRF BGOODSMGROUPRF, B.GOODSMAKERCDRF BGOODSMAKERCDRF, B.BLGOODSCODERF BBLGOODSCODERF, B.GOODSNORF BGOODSNORF, B.SUPPLIERCDRF BSUPPLIERCDRF, B.SUPPLIERLOTRF BSUPPLIERLOTRF ");
                sqlStr.Append(" ,C.CREATEDATETIMERF CCREATEDATETIMERF, C.UPDATEDATETIMERF CUPDATEDATETIMERF, C.ENTERPRISECODERF CENTERPRISECODERF, C.FILEHEADERGUIDRF CFILEHEADERGUIDRF, C.UPDEMPLOYEECODERF CUPDEMPLOYEECODERF, C.UPDASSEMBLYID1RF CUPDASSEMBLYID1RF, C.UPDASSEMBLYID2RF CUPDASSEMBLYID2RF, C.LOGICALDELETECODERF CLOGICALDELETECODERF, C.GOODSMAKERCDRF CGOODSMAKERCDRF, C.GOODSNORF CGOODSNORF, C.PRICESTARTDATERF CPRICESTARTDATERF, C.LISTPRICERF CLISTPRICERF, C.SALESUNITCOSTRF CSALESUNITCOSTRF, C.STOCKRATERF CSTOCKRATERF, C.OPENPRICEDIVRF COPENPRICEDIVRF, C.OFFERDATERF COFFERDATERF, C.UPDATEDATERF CUPDATEDATERF ");
                sqlStr.Append(" ,D.CREATEDATETIMERF DCREATEDATETIMERF, D.UPDATEDATETIMERF DUPDATEDATETIMERF, D.ENTERPRISECODERF DENTERPRISECODERF, D.FILEHEADERGUIDRF DFILEHEADERGUIDRF, D.UPDEMPLOYEECODERF DUPDEMPLOYEECODERF, D.UPDASSEMBLYID1RF DUPDASSEMBLYID1RF, D.UPDASSEMBLYID2RF DUPDASSEMBLYID2RF, D.LOGICALDELETECODERF DLOGICALDELETECODERF, D.SECTIONCODERF DSECTIONCODERF, D.MAKERCODERF DMAKERCODERF, D.UPPERLIMITPRICERF DUPPERLIMITPRICERF, D.FRACTIONPROCUNITRF DFRACTIONPROCUNITRF, D.FRACTIONPROCCDRF DFRACTIONPROCCDRF, D.UPRATERF DUPRATERF");
                sqlStr.Append(MakeQueryCondition(param, enterpriseCodes, ref sqlCommand));// ADD ���o���������ʉ�
                #region DEL 2011.09.06 #24364
                //#region FORM
                ////sqlStr.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = A.BLGOODSCODERF AND B.GOODSNORF = A.GOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");//DEL 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���
                ////sqlStr.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = 0 AND B.GOODSNORF = A.GOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");//ADD 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���//DEL 2011/09/02 #24364
                //sqlStr.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = 0 AND (B.GOODSNORF = A.GOODSNORF OR B.GOODSNORF='' OR B.GOODSNORF IS NULL) AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");//ADD 2011/09/02 #24364
                //#region DEL
                ////DEL 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���--------------------->>>>>
                ////if (param.SupplierCdBeginRF != 0)
                ////{
                ////    sqlStr.Append(" AND B.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                ////    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                ////    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                ////}
                ////if (param.SupplierCdEndRF != 0)
                ////{
                ////    sqlStr.Append(" AND B.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                ////    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                ////    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                ////}
                ////DEL 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���---------------------<<<<<
                //#endregion
                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND B.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND B.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //}
                //sqlStr.Append(" AND B.GOODSMGROUPRF=@GOODSMGROUPRF ");

                //sqlStr.Append("LEFT JOIN GOODSPRICEURF AS C ON C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.GOODSMAKERCDRF = A.GOODSMAKERCDRF AND C.GOODSNORF = A.GOODSNORF ");
                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND C.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND C.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //}
                //sqlStr.Append(" LEFT JOIN ISOLISLANDPRCRF AS D ON D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.MAKERCODERF = A.GOODSMAKERCDRF");
                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND D.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND D.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //}
                //#endregion

                //#region WHERE
                //sqlStr.Append(" WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE ");

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND A.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND A.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr.Append(" AND A.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr.Append(" AND A.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGoodsCodeBeginRF != 0)
                //{
                //    sqlStr.Append(" AND A.BLGOODSCODERF >= @BLGOODSCODEBEGINRF");
                //    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                //    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                //}

                //if (param.BLGoodsCodeEndRF != 0)
                //{
                //    sqlStr.Append(" AND A.BLGOODSCODERF <= @BLGOODSCODEENDRF");
                //    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                //    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr.Append(" AND A.GOODSNORF >= @GOODSNOBEGINRF");
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr.Append(" AND A.GOODSNORF <= @GOODSNOENDRF");
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}

                ////ADD 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���--------------------->>>>>
                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr.Append(" AND B.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}
                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr.Append(" AND B.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}
                ////ADD 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���---------------------<<<<
                //#endregion
                #endregion DEL
                //Order By Key
                sqlStr.Append(" ORDER BY A.UPDATEDATETIMERF DESC, A.GOODSMAKERCDRF,A.GOODSNORF,B.SECTIONCODERF,B.BLGOODSCODERF,C.PRICESTARTDATERF,D.UPPERLIMITPRICERF");
                #region DEL
                ////Prameter�I�u�W�F�N�g�̍쐬
                //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter goodsMGroupRF = sqlCommand.Parameters.Add("@GOODSMGROUPRF", SqlDbType.Int);

                ////Parameter�I�u�W�F�N�g�֒l�ݒ�
                //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                //goodsMGroupRF.Value = SqlDataMediator.SqlSetInt32(0);
                #endregion DEL
                //���i�}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr.ToString();
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    SetGoodsUIndex(myReader);
                    SetGoodsMngIndex(myReader);
                    SetGoodsPriceUIndex(myReader);
                    SetIsolIslandPrcIndex(myReader);
                }
                DateTime min = DateTime.MinValue;
                while (myReader.Read())
                {
                    aPK = SqlDataMediator.SqlGetInt32(myReader, _indexAGoodsMakerCd).ToString() 
                            + space + SqlDataMediator.SqlGetString(myReader, _indexAGoodsNo);
                    if (!aHashTbl.Contains(aPK))
                    {
                        aHashTbl.Add(aPK, emptyValue);
                        goodsUArrList.Add(CopyFromMyReaderToAPGoodsUWork(myReader));
                    }
                    //NULL�Ώۂ����X�g�ɒǉ����Ȃ�
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexBUpdateDateTime)) < 0)
                    {
                        //�ǉ����܂��������f
                        bPK = SqlDataMediator.SqlGetString(myReader, _indexBSectionCode)
                                + space + SqlDataMediator.SqlGetInt32(myReader, _indexBGoodsMGroup).ToString()
                                + space + SqlDataMediator.SqlGetInt32(myReader, _indexBGoodsMakerCd).ToString()
                                + space + SqlDataMediator.SqlGetInt32(myReader, _indexBBLGoodsCode).ToString()
                                + space + SqlDataMediator.SqlGetString(myReader, _indexBGoodsNo);
                        if (!bHashTbl.Contains(bPK))
                        {
                            bHashTbl.Add(bPK, emptyValue);
                            goodsMngArrList.Add(CopyFromMyReaderToAPGoodsMngWork(myReader));
                        }
                    }
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCUpdateDateTime)) < 0)
                    {
                        cPK = SqlDataMediator.SqlGetInt32(myReader, _indexCGoodsMakerCd).ToString()
                                + space + SqlDataMediator.SqlGetString(myReader, _indexCGoodsNo)
                                + space + SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexCPriceStartDate).ToString();
                        if (!cHashTbl.Contains(cPK))
                        {
                            cHashTbl.Add(cPK, emptyValue);
                            // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
                            //goodsPriceUArrList.Add(CopyFromMyReaderToAPGoodsPriceUWork(myReader));
                            goodsPriceUArrList.Add(CopyFromMyReaderToAPGoodsPriceUWork(myReader, convertDoubleRelease));
                            // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
                        }
                    }
                    if (min.CompareTo(SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexDUpdateDateTime)) < 0)
                    {
                        dPK = SqlDataMediator.SqlGetString(myReader, _indexDSectionCode)
                                + space + SqlDataMediator.SqlGetString(myReader, _indexDSectionCode)
                                + space + SqlDataMediator.SqlGetInt32(myReader, _indexDMakerCode).ToString()
                                + space + SqlDataMediator.SqlGetDouble(myReader, _indexDUpperLimitPrice).ToString();
                        if (!dHashTbl.Contains(dPK))
                        {
                            dHashTbl.Add(dPK, emptyValue);
                            isolIslandPrcArrList.Add(CopyFromMyReaderToAPIsolIslandPrcWork(myReader));
                        }
                    }
                }
                goodsAllList.Add(goodsUArrList);
                goodsAllList.Add(goodsMngArrList);
                goodsAllList.Add(goodsPriceUArrList);
                goodsAllList.Add(isolIslandPrcArrList);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsUWork.SearchGoodsU Exception=" + ex.Message);
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

        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)----->>>>>
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���i�}�X�^�i���[�U�[�o�^���j�f�[�^</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j�f�[�^��߂��܂�</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011/08/20</br>
        private APGoodsUWork CopyFromMyReaderToAPGoodsUWork(SqlDataReader myReader)
        {
            APGoodsUWork goodsUWork = new APGoodsUWork();
            #region DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            //goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("ACREATEDATETIMERF"));
            //goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("AUPDATEDATETIMERF"));
            //goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AENTERPRISECODERF"));
            //goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("AFILEHEADERGUIDRF"));
            //goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUPDEMPLOYEECODERF"));
            //goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUPDASSEMBLYID1RF"));
            //goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUPDASSEMBLYID2RF"));
            //goodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ALOGICALDELETECODERF"));
            //goodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGOODSMAKERCDRF"));
            //goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNORF"));
            //goodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNAMERF"));
            //goodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNAMEKANARF"));
            //goodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AJANRF"));
            //goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ABLGOODSCODERF"));
            //goodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADISPLAYORDERRF"));
            //goodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSRATERANKRF"));
            //goodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ATAXATIONDIVCDRF"));
            //goodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNONONEHYPHENRF"));
            //goodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("AOFFERDATERF"));
            //goodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AGOODSKINDCODERF"));
            //goodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNOTE1RF"));
            //goodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSNOTE2RF"));
            //goodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGOODSSPECIALNOTERF"));
            //goodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AENTERPRISEGANRECODERF"));
            //goodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("AUPDATEDATERF"));
            //goodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AOFFERDATADIVRF"));
            #endregion

            //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ� ----------------------------->>>>>
            goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexACreateDateTime);
            goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexAUpdateDateTime);
            goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexAEnterpriseCode);
            goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexAFileHeaderGuid);
            goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexAUpdEmployeeCode);
            goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexAUpdAssemblyId1);
            goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexAUpdAssemblyId2);
            goodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexALogicalDeleteCode);
            goodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _indexAGoodsMakerCd);
            goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _indexAGoodsNo);
            goodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, _indexAGoodsName);
            goodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, _indexAGoodsNameKana);
            goodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, _indexAJan);
            goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, _indexABLGoodsCode);
            goodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, _indexADisplayOrder);
            goodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, _indexAGoodsRateRank);
            goodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, _indexATaxationDivCd);
            goodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, _indexAGoodsNoNoneHyphen);
            goodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexAOfferDate);
            goodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, _indexAGoodsKindCode);
            goodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, _indexAGoodsNote1);
            goodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, _indexAGoodsNote2);
            goodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, _indexAGoodsSpecialNote);
            goodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, _indexAEnterpriseGanreCode);
            goodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexAUpdateDate);
            goodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, _indexAOfferDataDiv);
            //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ� -----------------------------<<<<<

            return goodsUWork;
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>���i�Ǘ����}�X�^�f�[�^</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : �g���Y</br>
        /// <br>Date       : 2011/08/20</br>
        private APGoodsMngWork CopyFromMyReaderToAPGoodsMngWork(SqlDataReader myReader)
        {
            APGoodsMngWork goodsMngWork = new APGoodsMngWork();
            #region DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            //goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BCREATEDATETIMERF"));
            //goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BUPDATEDATETIMERF"));
            //goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BENTERPRISECODERF"));
            //goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("BFILEHEADERGUIDRF"));
            //goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUPDEMPLOYEECODERF"));
            //goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUPDASSEMBLYID1RF"));
            //goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUPDASSEMBLYID2RF"));
            //goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLOGICALDELETECODERF"));
            //goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BSECTIONCODERF"));
            //goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BGOODSMGROUPRF"));
            //goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BGOODSMAKERCDRF"));
            //goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BBLGOODSCODERF"));
            //goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BGOODSNORF"));
            //goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BSUPPLIERCDRF"));
            //goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BSUPPLIERLOTRF"));
            #endregion

            //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ� ----------------------------->>>>>
            goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexBCreateDateTime);
            goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexBUpdateDateTime);
            goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexBEnterpriseCode);
            goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexBFileHeaderGuid);
            goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexBUpdEmployeeCode);
            goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexBUpdAssemblyId1);
            goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexBUpdAssemblyId2);
            goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexBLogicalDeleteCode);
            goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _indexBSectionCode);
            goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, _indexBGoodsMGroup);
            goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _indexBGoodsMakerCd);
            goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, _indexBBLGoodsCode);
            goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _indexBGoodsNo);
            goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, _indexBSupplierCd);
            goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, _indexBSupplierLot);
            //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ� -----------------------------<<<<<

            return goodsMngWork;
        }
        //-----ADD 2011/08/20 �r���[�i�`�F�b�N(myReader����D�N���X�֍��ړ]�L���s���Ă�����̓��\�b�h������)-----<<<<<

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="convertDoubleRelease">ConvertDoubleRelease</param>
        /// <returns>���i�}�X�^�i���[�U�[�o�^�j�f�[�^</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^�j�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/10/10</br>
        // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
        //private APGoodsPriceUWork CopyFromMyReaderToAPGoodsPriceUWork(SqlDataReader myReader)
        private APGoodsPriceUWork CopyFromMyReaderToAPGoodsPriceUWork(SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
        {
            APGoodsPriceUWork goodsPriceUWork = new APGoodsPriceUWork();

            goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCCreateDateTime);
            goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCUpdateDateTime);
            goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexCEnterpriseCode);
            goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexCFileHeaderGuid);
            goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexCUpdEmployeeCode);
            goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexCUpdAssemblyId1);
            goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexCUpdAssemblyId2);
            goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexCLogicalDeleteCode);
            goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _indexCGoodsMakerCd);
            goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _indexCGoodsNo);
            goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexCPriceStartDate);
            // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ---------->>>>>
            //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, _indexCListPrice);
            convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, _indexCListPrice);

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/10/10 �c���� PMKOBETSU-4005 ----------<<<<<
            goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, _indexCSalesUnitCost);
            goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, _indexCStockRate);
            goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, _indexCOpenPriceDiv);
            goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexCOfferDate);
            goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexCUpdateDate);

            return goodsPriceUWork;
        }

        /// <summary>
        /// �������i�}�X�^�f�[�^���擾
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�������i�}�X�^�f�[�^</returns>
        /// <br>Note       : �������i�}�X�^�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        private APIsolIslandPrcWork CopyFromMyReaderToAPIsolIslandPrcWork(SqlDataReader myReader)
        {
            APIsolIslandPrcWork isolIslandPrcWork = new APIsolIslandPrcWork();

            isolIslandPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexDCreateDateTime);
            isolIslandPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexDUpdateDateTime);
            isolIslandPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexDEnterpriseCode);
            isolIslandPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexDFileHeaderGuid);
            isolIslandPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexDUpdEmployeeCode);
            isolIslandPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexDUpdAssemblyId1);
            isolIslandPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexDUpdAssemblyId2);
            isolIslandPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexDLogicalDeleteCode);
            isolIslandPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _indexDSectionCode);
            isolIslandPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, _indexDMakerCode);
            isolIslandPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, _indexDUpperLimitPrice);
            isolIslandPrcWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, _indexDFractionProcUnit);
            isolIslandPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, _indexDFractionProcCd);
            isolIslandPrcWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, _indexDUpRate);

            return isolIslandPrcWork;
        }
        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetGoodsUIndex(SqlDataReader myReader)
        {
            _indexACreateDateTime = myReader.GetOrdinal("ACREATEDATETIMERF");
            _indexAUpdateDateTime = myReader.GetOrdinal("AUPDATEDATETIMERF");
            _indexAEnterpriseCode = myReader.GetOrdinal("AENTERPRISECODERF");
            _indexAFileHeaderGuid = myReader.GetOrdinal("AFILEHEADERGUIDRF");
            _indexAUpdEmployeeCode = myReader.GetOrdinal("AUPDEMPLOYEECODERF");
            _indexAUpdAssemblyId1 = myReader.GetOrdinal("AUPDASSEMBLYID1RF");
            _indexAUpdAssemblyId2 = myReader.GetOrdinal("AUPDASSEMBLYID2RF");
            _indexALogicalDeleteCode = myReader.GetOrdinal("ALOGICALDELETECODERF");
            _indexAGoodsMakerCd = myReader.GetOrdinal("AGOODSMAKERCDRF");
            _indexAGoodsNo = myReader.GetOrdinal("AGOODSNORF");
            _indexAGoodsName = myReader.GetOrdinal("AGOODSNAMERF");
            _indexAGoodsNameKana = myReader.GetOrdinal("AGOODSNAMEKANARF");
            _indexAJan = myReader.GetOrdinal("AJANRF");
            _indexABLGoodsCode = myReader.GetOrdinal("ABLGOODSCODERF");
            _indexADisplayOrder = myReader.GetOrdinal("ADISPLAYORDERRF");
            _indexAGoodsRateRank = myReader.GetOrdinal("AGOODSRATERANKRF");
            _indexATaxationDivCd = myReader.GetOrdinal("ATAXATIONDIVCDRF");
            _indexAGoodsNoNoneHyphen = myReader.GetOrdinal("AGOODSNONONEHYPHENRF");
            _indexAOfferDate = myReader.GetOrdinal("AOFFERDATERF");
            _indexAGoodsKindCode = myReader.GetOrdinal("AGOODSKINDCODERF");
            _indexAGoodsNote1 = myReader.GetOrdinal("AGOODSNOTE1RF");
            _indexAGoodsNote2 = myReader.GetOrdinal("AGOODSNOTE2RF");
            _indexAGoodsSpecialNote = myReader.GetOrdinal("AGOODSSPECIALNOTERF");
            _indexAEnterpriseGanreCode = myReader.GetOrdinal("AENTERPRISEGANRECODERF");
            _indexAUpdateDate = myReader.GetOrdinal("AUPDATEDATERF");
            _indexAOfferDataDiv = myReader.GetOrdinal("AOFFERDATADIVRF");
        }
        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetGoodsMngIndex(SqlDataReader myReader)
        {
            _indexBCreateDateTime = myReader.GetOrdinal("BCREATEDATETIMERF");
            _indexBUpdateDateTime = myReader.GetOrdinal("BUPDATEDATETIMERF");
            _indexBEnterpriseCode = myReader.GetOrdinal("BENTERPRISECODERF");
            _indexBFileHeaderGuid = myReader.GetOrdinal("BFILEHEADERGUIDRF");
            _indexBUpdEmployeeCode = myReader.GetOrdinal("BUPDEMPLOYEECODERF");
            _indexBUpdAssemblyId1 = myReader.GetOrdinal("BUPDASSEMBLYID1RF");
            _indexBUpdAssemblyId2 = myReader.GetOrdinal("BUPDASSEMBLYID2RF");
            _indexBLogicalDeleteCode = myReader.GetOrdinal("BLOGICALDELETECODERF");
            _indexBSectionCode = myReader.GetOrdinal("BSECTIONCODERF");
            _indexBGoodsMGroup = myReader.GetOrdinal("BGOODSMGROUPRF");
            _indexBGoodsMakerCd = myReader.GetOrdinal("BGOODSMAKERCDRF");
            _indexBBLGoodsCode = myReader.GetOrdinal("BBLGOODSCODERF");
            _indexBGoodsNo = myReader.GetOrdinal("BGOODSNORF");
            _indexBSupplierCd = myReader.GetOrdinal("BSUPPLIERCDRF");
            _indexBSupplierLot = myReader.GetOrdinal("BSUPPLIERLOTRF");
        }
        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetGoodsPriceUIndex(SqlDataReader myReader)
        {
            _indexCCreateDateTime = myReader.GetOrdinal("CCREATEDATETIMERF");
            _indexCUpdateDateTime = myReader.GetOrdinal("CUPDATEDATETIMERF");
            _indexCEnterpriseCode = myReader.GetOrdinal("CENTERPRISECODERF");
            _indexCFileHeaderGuid = myReader.GetOrdinal("CFILEHEADERGUIDRF");
            _indexCUpdEmployeeCode = myReader.GetOrdinal("CUPDEMPLOYEECODERF");
            _indexCUpdAssemblyId1 = myReader.GetOrdinal("CUPDASSEMBLYID1RF");
            _indexCUpdAssemblyId2 = myReader.GetOrdinal("CUPDASSEMBLYID2RF");
            _indexCLogicalDeleteCode = myReader.GetOrdinal("CLOGICALDELETECODERF");
            _indexCGoodsMakerCd = myReader.GetOrdinal("CGOODSMAKERCDRF");
            _indexCGoodsNo = myReader.GetOrdinal("CGOODSNORF");
            _indexCPriceStartDate = myReader.GetOrdinal("CPRICESTARTDATERF");
            _indexCListPrice = myReader.GetOrdinal("CLISTPRICERF");
            _indexCSalesUnitCost = myReader.GetOrdinal("CSALESUNITCOSTRF");
            _indexCStockRate = myReader.GetOrdinal("CSTOCKRATERF");
            _indexCOpenPriceDiv = myReader.GetOrdinal("COPENPRICEDIVRF");
            _indexCOfferDate = myReader.GetOrdinal("COFFERDATERF");
            _indexCUpdateDate = myReader.GetOrdinal("CUPDATEDATERF");
        }
        /// <summary>
        /// �J�����C���f�b�N�X�i�[����
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : �J�����C���f�b�N�X�i�[�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetIsolIslandPrcIndex(SqlDataReader myReader)
        {
            _indexDCreateDateTime = myReader.GetOrdinal("DCREATEDATETIMERF");
            _indexDUpdateDateTime = myReader.GetOrdinal("DUPDATEDATETIMERF");
            _indexDEnterpriseCode = myReader.GetOrdinal("DENTERPRISECODERF");
            _indexDFileHeaderGuid = myReader.GetOrdinal("DFILEHEADERGUIDRF");
            _indexDUpdEmployeeCode = myReader.GetOrdinal("DUPDEMPLOYEECODERF");
            _indexDUpdAssemblyId1 = myReader.GetOrdinal("DUPDASSEMBLYID1RF");
            _indexDUpdAssemblyId2 = myReader.GetOrdinal("DUPDASSEMBLYID2RF");
            _indexDLogicalDeleteCode = myReader.GetOrdinal("DLOGICALDELETECODERF");
            _indexDSectionCode = myReader.GetOrdinal("DSECTIONCODERF");
            _indexDMakerCode = myReader.GetOrdinal("DMAKERCODERF");
            _indexDUpperLimitPrice = myReader.GetOrdinal("DUPPERLIMITPRICERF");
            _indexDFractionProcUnit = myReader.GetOrdinal("DFRACTIONPROCUNITRF");
            _indexDFractionProcCd = myReader.GetOrdinal("DFRACTIONPROCCDRF");
            _indexDUpRate = myReader.GetOrdinal("DUPRATERF");
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="paramList">��������</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <param name="count">�������ʌ���</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������ʌ�����߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/07/26</br>
        public int SearchGoodsUCount(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out int count, out string retMessage)
        {
            count = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            APGoodsProcParamWork param = paramList as APGoodsProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                #region DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
                //sqlStr = "SELECT COUNT(GOODSURF.ENTERPRISECODERF) ";
                //sqlStr += " FROM GOODSURF LEFT JOIN GOODSMNGRF ON GOODSMNGRF.GoodsMakerCdRF=GOODSURF.GoodsMakerCdRF AND GOODSMNGRF.BLGOODSCODERF = GOODSURF.BLGOODSCODERF AND GOODSMNGRF.GOODSNORF = GOODSURF.GOODSNORF ";
                //sqlStr += " WHERE GOODSMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                //sqlStr += " AND GOODSMNGRF.GOODSMGROUPRF=@GOODSMGROUPRF ";
                //sqlStr += " AND GOODSURF.ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND GOODSURF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND GOODSURF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSURF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSURF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGoodsCodeBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSURF.BLGOODSCODERF >= @BLGOODSCODEBEGINRF";
                //    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                //    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                //}

                //if (param.BLGoodsCodeEndRF != 0)
                //{
                //    sqlStr += " AND GOODSURF.BLGOODSCODERF <= @BLGOODSCODEENDRF";
                //    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                //    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                //}

                //if (param.GoodsNoBeginRF != "")
                //{
                //    sqlStr += " AND GOODSURF.GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (param.GoodsNoEndRF != "")
                //{
                //    sqlStr += " AND GOODSURF.GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                #endregion
                //ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�------->>>>>
                sqlStr.Append("SELECT COUNT(A.CREATEDATETIMERF) ");
                sqlStr.Append(MakeQueryCondition(param, enterpriseCodes, ref sqlCommand));// ADD 2011.09.06 #24364
                #region DEL 2011.09.06 #24364
                //#region FORM
                ////sqlStr.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = A.BLGOODSCODERF AND B.GOODSNORF = A.GOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");//DEL 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���
                ////sqlStr.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = 0 AND B.GOODSNORF = A.GOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");//ADD 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���//DEL 2011/09/02 #24364
                //sqlStr.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = 0 AND (B.GOODSNORF = A.GOODSNORF OR B.GOODSNORF='' OR B.GOODSNORF IS NULL) AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");//ADD 2011/09/02 #24364
                //#region DEL
                ////DEL 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���--------------------->>>>>
                ////if (param.SupplierCdBeginRF != 0)
                ////{
                ////    sqlStr.Append(" AND B.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                ////    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                ////    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                ////}
                ////if (param.SupplierCdEndRF != 0)
                ////{
                ////    sqlStr.Append(" AND B.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                ////    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                ////    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                ////}
                ////DEL 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���---------------------<<<<<
                //#endregion
                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND B.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND B.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //}
                //sqlStr.Append(" AND B.GOODSMGROUPRF=@GOODSMGROUPRF ");

                //sqlStr.Append("LEFT JOIN GOODSPRICEURF AS C ON C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.GOODSMAKERCDRF = A.GOODSMAKERCDRF AND C.GOODSNORF = A.GOODSNORF ");
                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND C.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND C.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //}
                //sqlStr.Append("LEFT JOIN ON ISOLISLANDPRCRF AS D ON D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.GOODSMAKERCDRF = A.GOODSMAKERCDRF");
                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND D.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND D.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //}
                //#endregion

                //#region WHERE
                //sqlStr.Append(" WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE ");

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND A.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND A.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr.Append(" AND A.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr.Append(" AND A.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGoodsCodeBeginRF != 0)
                //{
                //    sqlStr.Append(" AND A.BLGOODSCODERF >= @BLGOODSCODEBEGINRF");
                //    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                //    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                //}

                //if (param.BLGoodsCodeEndRF != 0)
                //{
                //    sqlStr.Append(" AND A.BLGOODSCODERF <= @BLGOODSCODEENDRF");
                //    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                //    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr.Append(" AND A.GOODSNORF >= @GOODSNOBEGINRF");
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr.Append(" AND A.GOODSNORF <= @GOODSNOENDRF");
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}

                ////ADD 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���--------------------->>>>>
                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr.Append(" AND B.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}
                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr.Append(" AND B.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}
                ////ADD 2011/08/25 #24046 ���i�}�X�^�������M�ɂ���---------------------<<<<
                //#endregion
                ////ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�-------<<<<<

                ////Prameter�I�u�W�F�N�g�̍쐬
                //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter goodsMGroupRF = sqlCommand.Parameters.Add("@GOODSMGROUPRF", SqlDbType.Int);

                ////Parameter�I�u�W�F�N�g�֒l�ݒ�
                //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                //goodsMGroupRF.Value = SqlDataMediator.SqlSetInt32(0);
                #endregion DEL
                //���i�}�X�^�i���[�U�[�o�^���j�f�[�^�pSQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/08/25 #23798�������M�ōX�V�{�^�������ŏ������I�����Ȃ�
                // �ǂݍ���
                count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APGoodsUWork.SearchGoodsU Exception=" + ex.Message);
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
            }
            return status;
        }

        /// <summary>
        /// ��������SQL�쐬
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="param">��������</param>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <returns>��������SQL</returns>
        /// <br>Update Note: BLINCIDENT-2974 ���i�����������������s���Ȃ��̑Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/08/04</br>
        private string MakeQueryCondition(APGoodsProcParamWork param, string enterpriseCodes, ref SqlCommand sqlCommand)
        {
            StringBuilder sb = new StringBuilder();

            #region FORM
            sb.Append(" FROM GOODSURF AS A LEFT JOIN GOODSMNGRF AS B ON B.GOODSMAKERCDRF=A.GOODSMAKERCDRF AND B.BLGOODSCODERF = 0 AND (B.GOODSNORF = A.GOODSNORF OR B.GOODSNORF='' OR B.GOODSNORF IS NULL) AND B.ENTERPRISECODERF = A.ENTERPRISECODERF");
            if (param.UpdateDateTimeBegin != 0)
            {
                sb.Append(" AND B.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
            }
            if (param.UpdateDateTimeEnd != 0)
            {
                sb.Append(" AND B.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
            }
            sb.Append(" AND B.GOODSMGROUPRF=@GOODSMGROUPRF ");

            // ------ UPD 2021/08/04 ���O BLINCIDENT-2974-------->>>>>
            //sb.Append("LEFT JOIN GOODSPRICEURF AS C ON C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.GOODSMAKERCDRF = A.GOODSMAKERCDRF AND C.GOODSNORF = A.GOODSNORF ");
            //if (param.UpdateDateTimeBegin != 0)
            //{
            //    sb.Append(" AND C.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
            //}
            //if (param.UpdateDateTimeEnd != 0)
            //{
            //    sb.Append(" AND C.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
            //}
            //���M�J�n�I�����Ԃ����͂���Ȃ��ꍇ
            if (param.UpdateDateTimeBegin == 0 && param.UpdateDateTimeEnd == 0)
            {
                sb.Append("LEFT JOIN GOODSPRICEURF AS C ON C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.GOODSMAKERCDRF = A.GOODSMAKERCDRF AND C.GOODSNORF = A.GOODSNORF ");
            }
            //�S���i�f�[�^�����M�ΏہA���i�f�[�^.�X�V���������i�ʂ̍����ő�X�V����
            else
            {
                sb.Append("LEFT JOIN (SELECT" + Environment.NewLine);
                sb.Append("�@�@�@�@�@GDPR.CREATEDATETIMERF" + Environment.NewLine);
                sb.Append("         ,GD.UPDATEDATETIMERF" + Environment.NewLine);
                sb.Append("         ,GDPR.ENTERPRISECODERF" + Environment.NewLine);
                sb.Append("         ,GDPR.FILEHEADERGUIDRF" + Environment.NewLine);
                sb.Append("         ,GDPR.UPDEMPLOYEECODERF" + Environment.NewLine);
                sb.Append("         ,GDPR.UPDASSEMBLYID1RF" + Environment.NewLine);
                sb.Append("         ,GDPR.UPDASSEMBLYID2RF" + Environment.NewLine);
                sb.Append("         ,GDPR.LOGICALDELETECODERF" + Environment.NewLine);
                sb.Append("         ,GDPR.GOODSMAKERCDRF" + Environment.NewLine);
                sb.Append("         ,GDPR.GOODSNORF" + Environment.NewLine);
                sb.Append("         ,GDPR.PRICESTARTDATERF" + Environment.NewLine);
                sb.Append("         ,GDPR.LISTPRICERF" + Environment.NewLine);
                sb.Append("         ,GDPR.SALESUNITCOSTRF" + Environment.NewLine);
                sb.Append("         ,GDPR.STOCKRATERF" + Environment.NewLine);
                sb.Append("         ,GDPR.OPENPRICEDIVRF" + Environment.NewLine);
                sb.Append("         ,GDPR.OFFERDATERF" + Environment.NewLine);
                sb.Append("         ,GDPR.UPDATEDATERF" + Environment.NewLine);
                sb.Append("         FROM GOODSPRICEURF AS GDPR RIGHT JOIN " + Environment.NewLine);
                sb.Append("          (SELECT DISTINCT ENTERPRISECODERF" + Environment.NewLine);
                sb.Append("          ,GOODSMAKERCDRF" + Environment.NewLine);
                sb.Append("          ,GOODSNORF" + Environment.NewLine);
                sb.Append("          ,MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF" + Environment.NewLine);// ���i�ʂ̍����ő�X�V�������擾
                sb.Append("          FROM GOODSPRICEURF" + Environment.NewLine);
                sb.Append("          WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                if (param.UpdateDateTimeBegin != 0)
                {
                    sb.Append("          AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF" + Environment.NewLine);//�X�V���������M�J�n��
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sb.Append("          AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF" + Environment.NewLine);//�X�V����<=���M�I����
                }
                sb.Append("          GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF) AS GD" + Environment.NewLine);
                sb.Append("      ON GDPR.ENTERPRISECODERF = GD.ENTERPRISECODERF" + Environment.NewLine);//��ƃR�[�h
                sb.Append("      AND GDPR.GOODSMAKERCDRF = GD.GOODSMAKERCDRF" + Environment.NewLine);//���i���[�J�[
                sb.Append("      AND GDPR.GOODSNORF = GD.GOODSNORF" + Environment.NewLine);
                sb.Append("      ) AS C" + Environment.NewLine);
                sb.Append("ON C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.GOODSMAKERCDRF = A.GOODSMAKERCDRF AND C.GOODSNORF = A.GOODSNORF " + Environment.NewLine);
            }
            // ------ UPD 2021/08/04 ���O BLINCIDENT-2974--------<<<<<
            sb.Append(" LEFT JOIN ISOLISLANDPRCRF AS D ON D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.MAKERCODERF = A.GOODSMAKERCDRF");
            if (param.UpdateDateTimeBegin != 0)
            {
                sb.Append(" AND D.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
            }
            if (param.UpdateDateTimeEnd != 0)
            {
                sb.Append(" AND D.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
            }
            #endregion

            #region WHERE
            sb.Append(" WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE ");

            if (param.UpdateDateTimeBegin != 0)
            {
                sb.Append(" AND A.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
            }
            if (param.UpdateDateTimeEnd != 0)
            {
                sb.Append(" AND A.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
            }

            if (param.GoodsMakerCdBeginRF != 0)
            {
                sb.Append(" AND A.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
            }

            if (param.GoodsMakerCdEndRF != 0)
            {
                sb.Append(" AND A.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
            }

            if (param.BLGoodsCodeBeginRF != 0)
            {
                sb.Append(" AND A.BLGOODSCODERF >= @BLGOODSCODEBEGINRF");
                SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
            }

            if (param.BLGoodsCodeEndRF != 0)
            {
                sb.Append(" AND A.BLGOODSCODERF <= @BLGOODSCODEENDRF");
                SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
            }

            if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
            {
                sb.Append(" AND A.GOODSNORF >= @GOODSNOBEGINRF");
                SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
            }

            if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
            {
                sb.Append(" AND A.GOODSNORF <= @GOODSNOENDRF");
                SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
            }

            if (param.SupplierCdBeginRF != 0)
            {
                sb.Append(" AND B.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
            }
            if (param.SupplierCdEndRF != 0)
            {
                sb.Append(" AND B.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
            }
            #endregion WHERE

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter goodsMGroupRF = sqlCommand.Parameters.Add("@GOODSMGROUPRF", SqlDbType.Int);

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
            goodsMGroupRF.Value = SqlDataMediator.SqlSetInt32(0);

            return sb.ToString();
        }
        #endregion
        #endregion 2011/07/26 ������ SCM�Ή�-���_�Ǘ��i10704767-00�j

    }
}

