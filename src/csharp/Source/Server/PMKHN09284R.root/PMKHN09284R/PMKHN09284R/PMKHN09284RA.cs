//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�w�ʕϊ�����
// �v���O�����T�v   : �a�k�R�[�h�w�ʕϊ�����DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/01/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2010/01/25  �C�����e : Redmine:2603
//                                  �|���ϊ��d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2010/01/26  �C�����e : Redmine:2628
//                                  ���i�E�����f�[�^�̃^�C���A�E�g�l��ݒ�̎d�l�ύX
//                                  �D�ǐݒ�ϊ��O�̃R�[�h���g�p�̎d�l�ύX
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@���i�Ǘ���񃍃O�o�͓��e�Ə������ʃ��X�g�ɒǉ������̎d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2010/01/27  �C�����e : Redmine:2658
//                                  �|���}�X�^�̃p�����[�^�b�̏����̎d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/02/01  �C�����e : Redmine#2710�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2010/02/02  �C�����e : Redmine#2742�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2010/02/03  �C�����e : Redmine#2783�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2010/02/05  �C�����e : Redmine#2841�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2010/02/08  �C�����e : Redmine#2879�̓����f�[�^�X�V�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2010/02/09  �C�����e : Redmine#2909�̂a�k�R�[�h(�|��)�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �a�k�R�[�h�w�ʕϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �a�k�R�[�h�w�ʕϊ������̎��s�������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2010/01/12</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/25 ���M</br>
    /// <br>           : Redmine:2603</br>
    /// <br>             �|���ϊ��d�l�ύX</br>
    /// <br>Update Note: 2010/01/26 杍^</br>
    /// <br>           : Redmine:2628</br>
    /// <br>             �^�C���A�E�g�l��ݒ�̎d�l�ύX</br>
    /// <br>Update Note: 2010/01/27 ���M</br>
    /// <br>           : Redmine:2658</br>
    /// <br>             �|���}�X�^�̃p�����[�^�b�̏����̎d�l�ύX</br>
    /// <br>Update Note: 2010/02/01 ������</br>
    /// <br>           : Redmine#2710�̑Ή�</br>
    /// <br>Update Note: 2010/02/02 ���M</br>
    /// <br>           : Redmine#2742�̑Ή�</br>
    /// <br>Update Note: 2010/02/03 ���M</br>
    /// <br>           : Redmine#2783�̑Ή�</br>
    /// <br>Update Note: 2010/02/05 ���M</br>
    /// <br>           : Redmine#2841�̑Ή�</br>
    /// <br>Update Note: 2010/02/08 杍^</br>
    /// <br>           : Redmine#2879�̓����f�[�^�X�V�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2010/02/09 杍^</br>
    /// <br>           : Redmine#2909�̂a�k�R�[�h(�|��)�̏C��</br>
    /// </remarks>
    [Serializable]
    public class DataBLGoodsRateRankConvertDB : RemoteWithAppLockDB, IDataBLGoodsRateRankConvertDB
    {
        #region -- Private Members --
        //����
        private const string COL_NM_CreateDateTime = "CreateDateTime";
        private const string COL_NM_UpdateDateTime = "UpdateDateTime";
        private const string COL_NM_EnterpriseCode = "EnterpriseCode";
        private const string COL_NM_FileHeaderGuid = "FileHeaderGuid";
        private const string COL_NM_UpdEmployeeCode = "UpdEmployeeCode";
        private const string COL_NM_UpdAssemblyId1 = "UpdAssemblyId1";
        private const string COL_NM_UpdAssemblyId2 = "UpdAssemblyId2";
        private const string COL_NM_LogicalDeleteCode = "LogicalDeleteCode";
        private const string COL_NM_SectionCode = "SectionCode";
        private const string COL_NM_ChangeFlag = "ChangeFlag";
        private const string COL_NM_ObjectFlag = "ObjectFlag";
        //�|���}�X�^
        private const string COL_NM_UnitRateSetDivCd = "UnitRateSetDivCd";
        private const string COL_NM_UnitPriceKind = "UnitPriceKind";
        private const string COL_NM_RateSettingDivide = "RateSettingDivide";
        private const string COL_NM_RateMngGoodsCd = "RateMngGoodsCd";
        private const string COL_NM_RateMngGoodsNm = "RateMngGoodsNm";
        private const string COL_NM_RateMngCustCd = "RateMngCustCd";
        private const string COL_NM_RateMngCustNm = "RateMngCustNm";
        private const string COL_NM_GoodsMakerCd = "GoodsMakerCd";
        private const string COL_NM_GoodsNo = "GoodsNo";
        private const string COL_NM_GoodsRateRank = "GoodsRateRank";
        private const string COL_NM_GoodsRateGrpCode = "GoodsRateGrpCode";
        private const string COL_NM_BLGroupCode = "BLGroupCode";
        private const string COL_NM_BLGoodsCode = "BLGoodsCode";
        private const string COL_NM_CustomerCode = "CustomerCode";
        private const string COL_NM_CustRateGrpCode = "CustRateGrpCode";
        private const string COL_NM_SupplierCd = "SupplierCd";
        private const string COL_NM_LotCount = "LotCount";
        private const string COL_NM_PriceFl = "PriceFl";
        private const string COL_NM_RateVal = "RateVal";
        private const string COL_NM_UpRate = "UpRate";
        private const string COL_NM_GrsProfitSecureRate = "GrsProfitSecureRate";
        private const string COL_NM_UnPrcFracProcUnit = "UnPrcFracProcUnit";
        private const string COL_NM_UnPrcFracProcDiv = "UnPrcFracProcDiv";
        private const string COL_NM_BfGoodsMakerCd = "BfGoodsMakerCd";
        private const string COL_NM_BfBLGoodsCode = "BfBLGoodsCode";
        private const string COL_NM_BfGoodsRateRank = "BfGoodsRateRank";
        private const string COL_NM_index = "index";
        private const string COL_NM_GoodsMakerFlag = "GoodsMakerFlag";
        private const string COL_NM_GoodsRateRankFlag = "GoodsRateRankFlag";
        private const string COL_NM_BLGoodsCodeFlag = "BLGoodsCodeFlag";
        private const string COL_NM_BfUnitRateSetDivCd = "BfUnitRateSetDivCd";

        //�D�ǐݒ�}�X�^
        private const string COL_NM_GoodsMGroup = "GoodsMGroup";
        private const string COL_NM_TbsPartsCode = "TbsPartsCode";
        private const string COL_NM_TbsPartsCdDerivedNo = "TbsPartsCdDerivedNo";
        private const string COL_NM_MakerDispOrder = "MakerDispOrder";
        private const string COL_NM_PartsMakerCd = "PartsMakerCd";
        private const string COL_NM_PrimeDispOrder = "PrimeDispOrder";
        private const string COL_NM_PrmSetDtlNo1 = "PrmSetDtlNo1";
        private const string COL_NM_PrmSetDtlName1 = "PrmSetDtlName1";
        private const string COL_NM_PrmSetDtlNo2 = "PrmSetDtlNo2";
        private const string COL_NM_PrmSetDtlName2 = "PrmSetDtlName2";
        private const string COL_NM_PrimeDisplayCode = "PrimeDisplayCode";
        private const string COL_NM_OfferDate = "OfferDate";
        private const string COL_NM_BfTbsPartsCode = "BfTbsPartsCode";
        private const string COL_NM_BfPrmSetDtlNo1 = "BfPrmSetDtlNo1";
        private const string COL_NM_BfPrmSetDtlNo2 = "BfPrmSetDtlNo2";
        private const string COL_NM_SortChangeFlag = "SortChangeFlag";

        // --- UPD 2010/02/03 ---------->>>>>
        private const string COL_NM_BfMakerDispOrder = "BfMakerDispOrder";
        private const string COL_NM_BfPrimeDispOrder = "BfPrimeDispOrder";
        // --- UPD 2010/02/03 ----------<<<<<

        // ���i�}�X�^�i���[�U�[�o�^���j
        private const string GOODSURF_TABLE_NM = "GOODSURF";
        // ���㖾�׃f�[�^
        private const string SALESDETAILRF_TABLE_NM = "SALESDETAILRF";
        // ���㗚�𖾍׃f�[�^
        private const string SALESHISTDTLRF_TABLE_NM = "SALESHISTDTLRF";
        // �d�����׃f�[�^
        private const string STOCKDETAILRF_TABLE_NM = "STOCKDETAILRF";
        // �d�����𖾍׃f�[�^
        private const string STOCKSLHISTDTLRF_TABLE_NM = "STOCKSLHISTDTLRF";
        // �݌Ɉړ��f�[�^
        private const string STOCKMOVERF_TABLE_NM = "STOCKMOVERF";
        // �݌ɒ������׃f�[�^
        private const string STOCKADJUSTDTLRF_TABLE_NM = "STOCKADJUSTDTLRF";
        // �݌Ɏ󕥗����f�[�^
        private const string STOCKACPAYHISTRF_TABLE_NM = "STOCKACPAYHISTRF";

        //���i�Ǘ����}�X�^
        private const string COL_NM_SupplierLot = "SupplierLot";//�������b�g

        #endregion

        /// <summary>
        /// �a�k�R�[�h�w�ʕϊ�����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// </remarks>
        public DataBLGoodsRateRankConvertDB()
            :
            base("PMKHN09286D", "Broadleaf.Application.Remoting.ParamData.ResultListWork", "")
        {
        }

        #region [�a�k�R�[�h�w�ʕϊ�����]
        /// <summary>
        /// �f�[�^�N���A�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="excellentSetFile_A">�D�ǐݒ�p�����[�^���X�g�`</param>
        /// <param name="excellentSetFile_B">�D�ǐݒ�p�����[�^���X�g�a</param>
        /// <param name="excellentSetFile_C">�D�ǐݒ�p�����[�^���X�g�b</param>
        /// <param name="goodsFile_A">���i�p�����[�^���X�g�`</param>
        /// <param name="goodsFile_B">���i�p�����[�^���X�g�a</param>
        /// <param name="goodsFile_C">���i�p�����[�^���X�g�b</param>
        /// <param name="partsFile">���ʃp�����[�^�̃��X�g</param>
        /// <param name="rateFile_A">�|���p�����[�^���X�g�`</param>
        /// <param name="rateFile_B">�|���p�����[�^���X�g�a</param>
        /// <param name="rateFile_C">�|���p�����[�^���X�g�b</param>
        /// <param name="retList">�������ʃ��X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        public int Update(string enterpriseCode, object rateFile_A, object rateFile_B, object rateFile_C, object goodsFile_A,
            object goodsFile_B, object goodsFile_C, object partsFile, object excellentSetFile_A, object excellentSetFile_B,
            object excellentSetFile_C, out object retList, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;
            ShareCheckInfo info = new ShareCheckInfo();
            retList = null;
            ArrayList resultList = new ArrayList();
            errMsg = string.Empty;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // Read�p�R�l�N�V�������C���X�^���X��
                sqlConnection_read = CreateSqlConnection();
                if (sqlConnection_read == null) return status;
                sqlConnection_read.Open();

                //���g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                #region �r������
                //�V�X�e�����b�N(���)
                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0)
                {
                    return status;
                }
                #endregion

                #region �ϊ�����
                ArrayList rateAList = (ArrayList)rateFile_A;
                ArrayList rateBList = (ArrayList)rateFile_B;
                ArrayList rateCList = (ArrayList)rateFile_C;
                ArrayList goodsAList = (ArrayList)goodsFile_A;
                ArrayList goodsBList = (ArrayList)goodsFile_B;
                ArrayList goodsCList = (ArrayList)goodsFile_C;
                ArrayList partsList = (ArrayList)partsFile;
                ArrayList excellentSetAList = (ArrayList)excellentSetFile_A;
                ArrayList excellentSetBList = (ArrayList)excellentSetFile_B;
                ArrayList excellentSetCList = (ArrayList)excellentSetFile_C;

                try
                {
                    //���|���}�X�^�X�V����
                    status = RateUpdateProc(enterpriseCode, rateAList, rateBList, rateCList, ref resultList, ref sqlConnection, ref sqlTransaction, ref sqlConnection_read);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) return status;
                    //�����i�}�X�^�E�����n�f�[�^�X�V����
                    status = GoodsUpdateProc(enterpriseCode, goodsAList, goodsBList, goodsCList, ref resultList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) return status;
                    //�����ʃ}�X�^�X�V����
                    status = PartsPosCodeUpdateProc(enterpriseCode, partsList, ref resultList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) return status;
                    //���D�ǐݒ�}�X�^�X�V����
                    status = PrmSettingUpdateProc(enterpriseCode, excellentSetAList, excellentSetBList, excellentSetCList, ref resultList, ref sqlConnection, ref sqlTransaction, ref sqlConnection_read);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) return status;
                    //�����i�Ǘ����}�X�^�X�V����
                    status = GoodsMngUpdateProc(enterpriseCode, rateBList, rateCList, ref resultList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        retList = resultList;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.Update Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    //�V�X�e�����b�N����
                    int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = st;
                    }

                    //���R�~�b�gor���[���o�b�N
                    //����X�V���R�~�b�g�A�ُ픭�������[���o�b�N
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) sqlTransaction.Commit();
                    else sqlTransaction.Rollback();
                }

                #endregion
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.Update");
                errMsg = ex.Message;
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region �|���}�X�^�X�V����
        /// <summary>
        /// �|���}�X�^�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="rateAList">�|���p�����[�^���X�g�`</param>
        /// <param name="rateBList">�|���p�����[�^���X�g�a</param>
        /// <param name="rateCList">�|���p�����[�^���X�g�b</param>
        /// <param name="retList">retList</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <param name="sqlConnection_read">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^�X�V����(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/25 ���M �|���ϊ��d�l�ύX�Ή�</br>
        /// <br>Update Note: 2010/01/27 ���M �|���}�X�^�̃p�����[�^�b�̏�����ύX�̑Ή�</br>
        /// <br>Update Note: 2010/02/03 ���M Redmine#2783�̑Ή�</br>
        private int RateUpdateProc(string enterpriseCode, ArrayList rateAList, ArrayList rateBList, ArrayList rateCList, ref ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,ref SqlConnection sqlConnection_read)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (rateAList.Count == 0 && rateBList.Count == 0 && rateCList.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList al = new ArrayList();
            RateDB rateDB = new RateDB();

            #region DataSet����\�z����
            DataTable rateSetTable = new DataTable();
            rateSetTable.Columns.Add(COL_NM_CreateDateTime, typeof(DateTime));
            rateSetTable.Columns.Add(COL_NM_UpdateDateTime, typeof(DateTime));
            rateSetTable.Columns.Add(COL_NM_EnterpriseCode, typeof(string));
            rateSetTable.Columns.Add(COL_NM_FileHeaderGuid, typeof(Guid));
            rateSetTable.Columns.Add(COL_NM_UpdEmployeeCode, typeof(string));
            rateSetTable.Columns.Add(COL_NM_UpdAssemblyId1, typeof(string));
            rateSetTable.Columns.Add(COL_NM_UpdAssemblyId2, typeof(string));
            rateSetTable.Columns.Add(COL_NM_LogicalDeleteCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_SectionCode, typeof(string));
            rateSetTable.Columns.Add(COL_NM_UnitRateSetDivCd, typeof(string));
            rateSetTable.Columns.Add(COL_NM_UnitPriceKind, typeof(string));
            rateSetTable.Columns.Add(COL_NM_RateSettingDivide, typeof(string));
            rateSetTable.Columns.Add(COL_NM_RateMngGoodsCd, typeof(string));
            rateSetTable.Columns.Add(COL_NM_RateMngGoodsNm, typeof(string));
            rateSetTable.Columns.Add(COL_NM_RateMngCustCd, typeof(string));
            rateSetTable.Columns.Add(COL_NM_RateMngCustNm, typeof(string));
            rateSetTable.Columns.Add(COL_NM_GoodsMakerCd, typeof(int));
            rateSetTable.Columns.Add(COL_NM_GoodsNo, typeof(string));
            rateSetTable.Columns.Add(COL_NM_GoodsRateRank, typeof(string));
            rateSetTable.Columns.Add(COL_NM_GoodsRateGrpCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BLGroupCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BLGoodsCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_CustomerCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_CustRateGrpCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_SupplierCd, typeof(int));
            rateSetTable.Columns.Add(COL_NM_LotCount, typeof(double));
            rateSetTable.Columns.Add(COL_NM_PriceFl, typeof(double));
            rateSetTable.Columns.Add(COL_NM_RateVal, typeof(double));
            rateSetTable.Columns.Add(COL_NM_UpRate, typeof(double));
            rateSetTable.Columns.Add(COL_NM_GrsProfitSecureRate, typeof(double));
            rateSetTable.Columns.Add(COL_NM_UnPrcFracProcUnit, typeof(double));
            rateSetTable.Columns.Add(COL_NM_UnPrcFracProcDiv, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BfGoodsMakerCd, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BfBLGoodsCode, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BfGoodsRateRank, typeof(string));
            rateSetTable.Columns.Add(COL_NM_index, typeof(int));
            rateSetTable.Columns.Add(COL_NM_GoodsMakerFlag, typeof(int));
            rateSetTable.Columns.Add(COL_NM_GoodsRateRankFlag, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BLGoodsCodeFlag, typeof(int));
            rateSetTable.Columns.Add(COL_NM_ChangeFlag, typeof(int));
            rateSetTable.Columns.Add(COL_NM_ObjectFlag, typeof(int));
            rateSetTable.Columns.Add(COL_NM_BfUnitRateSetDivCd, typeof(string));
            #endregion

            #region �|���}�X�^(RATERF)�̓��e��S��
            try
            {
                RateWork rateWork = new RateWork();
                rateWork.EnterpriseCode = enterpriseCode;
                rateWork.LotCount = -1.0;
                // --- UPD 2010/02/03 ---------->>>>>
                //status = rateDB.SearchSubSectionProc(out al, rateWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection_read);
                status = rateDB.SearchSubSectionProc(out al, rateWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection_read);
                // --- UPD 2010/02/03 ----------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            #endregion

            int index = 1;
            foreach (RateWork rate in al)
            {
                #region �W�J����
                DataRow dataRow = rateSetTable.NewRow();
                dataRow[COL_NM_CreateDateTime] = rate.CreateDateTime;
                dataRow[COL_NM_UpdateDateTime] = rate.UpdateDateTime;
                dataRow[COL_NM_EnterpriseCode] = rate.EnterpriseCode;
                dataRow[COL_NM_FileHeaderGuid] = rate.FileHeaderGuid;
                dataRow[COL_NM_UpdEmployeeCode] = rate.UpdEmployeeCode;
                dataRow[COL_NM_UpdAssemblyId1] = rate.UpdAssemblyId1;
                dataRow[COL_NM_UpdAssemblyId2] = rate.UpdAssemblyId2;
                dataRow[COL_NM_LogicalDeleteCode] = rate.LogicalDeleteCode;
                dataRow[COL_NM_SectionCode] = rate.SectionCode;
                dataRow[COL_NM_UnitRateSetDivCd] = rate.UnitRateSetDivCd;
                dataRow[COL_NM_UnitPriceKind] = rate.UnitPriceKind;
                dataRow[COL_NM_RateSettingDivide] = rate.RateSettingDivide;
                dataRow[COL_NM_RateMngGoodsCd] = rate.RateMngGoodsCd;
                dataRow[COL_NM_RateMngGoodsNm] = rate.RateMngGoodsNm;
                dataRow[COL_NM_RateMngCustCd] = rate.RateMngCustCd;
                dataRow[COL_NM_RateMngCustNm] = rate.RateMngCustNm;
                dataRow[COL_NM_GoodsMakerCd] = rate.GoodsMakerCd;
                dataRow[COL_NM_GoodsNo] = rate.GoodsNo;
                dataRow[COL_NM_GoodsRateRank] = rate.GoodsRateRank;
                dataRow[COL_NM_GoodsRateGrpCode] = rate.GoodsRateGrpCode;
                dataRow[COL_NM_BLGroupCode] = rate.BLGroupCode;
                dataRow[COL_NM_BLGoodsCode] = rate.BLGoodsCode;
                dataRow[COL_NM_CustomerCode] = rate.CustomerCode;
                dataRow[COL_NM_CustRateGrpCode] = rate.CustRateGrpCode;
                dataRow[COL_NM_SupplierCd] = rate.SupplierCd;
                dataRow[COL_NM_LotCount] = rate.LotCount;
                dataRow[COL_NM_PriceFl] = rate.PriceFl;
                dataRow[COL_NM_RateVal] = rate.RateVal;
                dataRow[COL_NM_UpRate] = rate.UpRate;
                dataRow[COL_NM_GrsProfitSecureRate] = rate.GrsProfitSecureRate;
                dataRow[COL_NM_UnPrcFracProcUnit] = rate.UnPrcFracProcUnit;
                dataRow[COL_NM_UnPrcFracProcDiv] = rate.UnPrcFracProcDiv;
                dataRow[COL_NM_BfGoodsMakerCd] = rate.GoodsMakerCd;
                dataRow[COL_NM_BfBLGoodsCode] = rate.BLGoodsCode;
                dataRow[COL_NM_BfGoodsRateRank] = rate.GoodsRateRank;
                dataRow[COL_NM_index] = index++;
                dataRow[COL_NM_GoodsMakerFlag] = 0;
                dataRow[COL_NM_GoodsRateRankFlag] = 0;
                dataRow[COL_NM_BLGoodsCodeFlag] = 0;
                dataRow[COL_NM_ChangeFlag] = 0;
                dataRow[COL_NM_ObjectFlag] = 1;
                dataRow[COL_NM_BfUnitRateSetDivCd] = rate.UnitRateSetDivCd;

                rateSetTable.Rows.Add(dataRow);

                #endregion
            }

            //�|���p�����[�^�`�̏���
            #region �|���p�����[�^�`�̏���
            foreach (RateParaAWork rateParaAWork in rateAList)
            {
                DataRow[] rows = rateSetTable.Select(string.Format("{0}='{1}' AND {2}={3}",
                    rateSetTable.Columns[COL_NM_GoodsMakerCd].ColumnName, "0",
                    rateSetTable.Columns[COL_NM_BfBLGoodsCode].ColumnName, int.Parse(rateParaAWork.BeforeBlCd)));

                foreach (DataRow row in rows)
                {
                    ArrayList arrayList = rateParaAWork.MakerList;
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        DataRow dataRow = rateSetTable.NewRow();
                        dataRow.ItemArray = row.ItemArray;
                        row[COL_NM_ChangeFlag] = 1;
                        dataRow[COL_NM_GoodsMakerFlag] = 1;
                        dataRow[COL_NM_GoodsMakerCd] = Int32.Parse(arrayList[i].ToString());
                        dataRow[COL_NM_index] = rateSetTable.Rows.Count + 1;
                        rateSetTable.Rows.Add(dataRow);
                    }
                }
            }
            #endregion

            //�|���p�����[�^�a�̏���
            #region �|���p�����[�^�a�̏���
            foreach (RateParaBWork rateParaBWork in rateBList)
            {
                DataRow[] rows = rateSetTable.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                    rateSetTable.Columns[COL_NM_GoodsRateRank].ColumnName, string.Empty,
                    rateSetTable.Columns[COL_NM_GoodsMakerCd].ColumnName, int.Parse(rateParaBWork.MakerCd),
                    rateSetTable.Columns[COL_NM_BLGoodsCode].ColumnName, int.Parse(rateParaBWork.BeforeBlCd)));

                // --- ADD 2010/01/25 -------------->>>
                DataRow[] rowsNew = rateSetTable.Select(string.Format("{0}<>'{1}' AND {2}={3} AND {4}={5}",
                    rateSetTable.Columns[COL_NM_GoodsRateRank].ColumnName, string.Empty,
                    rateSetTable.Columns[COL_NM_GoodsMakerCd].ColumnName, int.Parse(rateParaBWork.MakerCd),
                    rateSetTable.Columns[COL_NM_BLGoodsCode].ColumnName, int.Parse(rateParaBWork.BeforeBlCd)));

                // --- ADD 2010/01/25 --------------<<<

                foreach (DataRow row in rows)
                {
                    ArrayList arrayList = rateParaBWork.LevelList;

                    if (arrayList != null && arrayList.Count > 0)
                    {
                        for (int i = 0; i < arrayList.Count; i++)
                        {
                            DataRow dataRow = rateSetTable.NewRow();
                            dataRow.ItemArray = row.ItemArray;
                            //row[COL_NM_ChangeFlag] = 1; DEL 2010/01/25
                            dataRow[COL_NM_GoodsRateRankFlag] = 1;
                            dataRow[COL_NM_index] = rateSetTable.Rows.Count + 1;
                            dataRow[COL_NM_BLGoodsCode] = rateParaBWork.AfterBlCd;
                            dataRow[COL_NM_GoodsRateRank] = arrayList[i].ToString();

                            rateSetTable.Rows.Add(dataRow);
                        }

                        rateSetTable.Rows.Remove(row);
                    }
                    else
                    {
                        DataRow dataRow = rateSetTable.NewRow();
                        dataRow.ItemArray = row.ItemArray;
                        //row[COL_NM_ChangeFlag] = 1; DEL 2010/01/25
                        dataRow[COL_NM_BLGoodsCode] = rateParaBWork.AfterBlCd;
                        dataRow[COL_NM_index] = rateSetTable.Rows.Count + 1;
                        rateSetTable.Rows.Add(dataRow);
                        rateSetTable.Rows.Remove(row);
                    }
                }

                // --- ADD 2010/01/25 -------------->>>
                foreach (DataRow rowNew in rowsNew)
                {
                    if (rateParaBWork.LevelList != null && rateParaBWork.LevelList.Count > 0)
                    {
                        DataRow dataRow = rateSetTable.NewRow();
                        dataRow.ItemArray = rowNew.ItemArray;
                        dataRow[COL_NM_index] = rateSetTable.Rows.Count + 1;
                        dataRow[COL_NM_BLGoodsCode] = rateParaBWork.AfterBlCd;
                        rateSetTable.Rows.Add(dataRow);
                        rateSetTable.Rows.Remove(rowNew);
                    }
                }
                // --- ADD 2010/01/25 --------------<<<
            }
            #endregion

            //�|���p�����[�^�b�̏���
            #region �|���p�����[�^�b�̏���
            foreach (RateParaCWork rateParaCWork in rateCList)
            {
                DataRow[] rows = rateSetTable.Select(string.Format("{0}={1} AND {2}={3}",
                    rateSetTable.Columns[COL_NM_GoodsMakerCd].ColumnName, int.Parse(rateParaCWork.MakerCd),
                    rateSetTable.Columns[COL_NM_BLGoodsCode].ColumnName, int.Parse(rateParaCWork.BeforeBlCd)));

                foreach (DataRow row in rows)
                {
                    ArrayList arrayList = rateParaCWork.AfterBlList;
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        DataRow dataRow = rateSetTable.NewRow();
                        dataRow.ItemArray = row.ItemArray;
                        //row[COL_NM_ChangeFlag] = 1; DEL 2010/01/25
                        dataRow[COL_NM_index] = rateSetTable.Rows.Count + 1;
                        dataRow[COL_NM_BLGoodsCode] = Int32.Parse(arrayList[i].ToString());
                        if ((int)dataRow[COL_NM_BLGoodsCode] != (int)dataRow[COL_NM_BfBLGoodsCode])
                        {
                            dataRow[COL_NM_BLGoodsCodeFlag] = 1;
                        }
                        // ---ADD 2010/01/27 --------->>>>
                        else
                        {
                            dataRow[COL_NM_ChangeFlag] = 1;
                        }
                        // ---ADD 2010/01/27 ---------<<<<
                        rateSetTable.Rows.Add(dataRow);
                    }

                    rateSetTable.Rows.Remove(row); //ADD 2010/01/25
                }
            }

            #endregion

            //�ϊ��t���O�̍X�V
            foreach (DataRow row in rateSetTable.Rows)
            {
                if (((int)row[COL_NM_GoodsMakerCd] != (int)row[COL_NM_BfGoodsMakerCd])
                    || (row[COL_NM_GoodsRateRank].ToString().Trim() != row[COL_NM_BfGoodsRateRank].ToString().Trim())
                    || ((int)row[COL_NM_BLGoodsCode] != (int)row[COL_NM_BfBLGoodsCode]))
                {
                    row[COL_NM_ChangeFlag] = 1;
                }
            }

            //�Ώۃt���O�̍X�V
            foreach (DataRow row in rateSetTable.Rows)
            {
                DataView rateSetView = new DataView(rateSetTable);
                rateSetView.Sort = this.MakeRateSetSort(rateSetTable);
                rateSetView.RowFilter = KeyofDic(rateSetTable, row);
                if (rateSetView.Count > 0)
                {
                    //�Y������DataView��̐擪�s�Ǝ��̓��e���P�ł��قȂ�ꍇ�́u�Ώۃt���O�v��"0"���Z�b�g����
                    if (((int)rateSetView[0][COL_NM_BfGoodsMakerCd] != (int)row[COL_NM_BfGoodsMakerCd])
                    || ((int)rateSetView[0][COL_NM_BfBLGoodsCode] != (int)row[COL_NM_BfBLGoodsCode])
                    || (!rateSetView[0][COL_NM_BfGoodsRateRank].ToString().Trim().Equals(row[COL_NM_BfGoodsRateRank].ToString().Trim())))
                    {
                        row[COL_NM_ObjectFlag] = 0;
                    }
                }
            }

            //�|���ݒ�敪�̍X�V
            foreach (DataRow row in rateSetTable.Rows)
            {
                if ((int)row[COL_NM_ChangeFlag] != 0)
                {
                    RateSettingMd(row);
                }
            }

            //�|���}�X�^�X�V DCKHN09164R
            ArrayList delList = new ArrayList();
            ArrayList updList = new ArrayList();

            foreach (DataRow row in rateSetTable.Rows)
            {
                if ((int)row[COL_NM_ChangeFlag] != 0)
                {
                    RateWork rateWork = new RateWork();
                    rateWork.EnterpriseCode = row[COL_NM_EnterpriseCode].ToString();
                    rateWork.SectionCode = row[COL_NM_SectionCode].ToString();
                    rateWork.UpdateDateTime = (DateTime)row[COL_NM_UpdateDateTime];
                    rateWork.UnitRateSetDivCd = row[COL_NM_BfUnitRateSetDivCd].ToString();
                    rateWork.GoodsMakerCd = (int)row[COL_NM_BfGoodsMakerCd];
                    rateWork.GoodsNo = row[COL_NM_GoodsNo].ToString();
                    rateWork.GoodsRateRank = row[COL_NM_BfGoodsRateRank].ToString();
                    rateWork.GoodsRateGrpCode = (int)row[COL_NM_GoodsRateGrpCode];
                    rateWork.BLGroupCode = (int)row[COL_NM_BLGroupCode];
                    rateWork.BLGoodsCode = (int)row[COL_NM_BfBLGoodsCode];
                    rateWork.CustomerCode = (int)row[COL_NM_CustomerCode];
                    rateWork.CustRateGrpCode = (int)row[COL_NM_CustRateGrpCode];
                    rateWork.SupplierCd = (int)row[COL_NM_SupplierCd];
                    rateWork.LotCount = (double)row[COL_NM_LotCount];
                    delList.Add(rateWork);

                    ResultListWork resultListWork = new ResultListWork();

                    //�Ώۃt���O��0�̏ꍇ
                    if ((int)row[COL_NM_ObjectFlag] == 0)
                    {
                        resultListWork.TableName = "�|��Ͻ�";
                        resultListWork.Status = "�d��";
                        resultListWork.Key = SetkeyString(row);
                        resultListWork.Content = SetContentString(row, (int)row[COL_NM_ObjectFlag]);
                    }
                    else
                    {
                        resultListWork.TableName = "�|��Ͻ�";
                        resultListWork.Status = "�ϊ�";
                        resultListWork.Key = SetkeyString(row);
                        resultListWork.Content = SetContentString(row, (int)row[COL_NM_ObjectFlag]);

                        RateWork rateUpdWork = new RateWork();

                        #region �W�J����
                        rateUpdWork.SectionCode = row[COL_NM_SectionCode].ToString();
                        rateUpdWork.UnitRateSetDivCd = row[COL_NM_UnitRateSetDivCd].ToString();
                        rateUpdWork.UnitPriceKind = row[COL_NM_UnitPriceKind].ToString();
                        rateUpdWork.RateSettingDivide = row[COL_NM_RateSettingDivide].ToString();
                        rateUpdWork.RateMngGoodsCd = row[COL_NM_RateMngGoodsCd].ToString();
                        rateUpdWork.RateMngGoodsNm = row[COL_NM_RateMngGoodsNm].ToString();
                        rateUpdWork.RateMngCustCd = row[COL_NM_RateMngCustCd].ToString();
                        rateUpdWork.RateMngCustNm = row[COL_NM_RateMngCustNm].ToString();
                        rateUpdWork.GoodsMakerCd = (int)row[COL_NM_GoodsMakerCd];
                        rateUpdWork.GoodsNo = row[COL_NM_GoodsNo].ToString();
                        rateUpdWork.GoodsRateRank = row[COL_NM_GoodsRateRank].ToString();
                        rateUpdWork.GoodsRateGrpCode = (int)row[COL_NM_GoodsRateGrpCode];
                        rateUpdWork.BLGroupCode = (int)row[COL_NM_BLGroupCode];
                        rateUpdWork.BLGoodsCode = (int)row[COL_NM_BLGoodsCode];
                        rateUpdWork.CustomerCode = (int)row[COL_NM_CustomerCode];
                        rateUpdWork.CustRateGrpCode = (int)row[COL_NM_CustRateGrpCode];
                        rateUpdWork.SupplierCd = (int)row[COL_NM_SupplierCd];
                        rateUpdWork.LotCount = (double)row[COL_NM_LotCount];
                        rateUpdWork.PriceFl = (double)row[COL_NM_PriceFl];
                        rateUpdWork.RateVal = (double)row[COL_NM_RateVal];
                        rateUpdWork.UpRate = (double)row[COL_NM_UpRate];
                        rateUpdWork.GrsProfitSecureRate = (double)row[COL_NM_GrsProfitSecureRate];
                        rateUpdWork.UnPrcFracProcUnit = (double)row[COL_NM_UnPrcFracProcUnit];
                        rateUpdWork.UnPrcFracProcDiv = (int)row[COL_NM_UnPrcFracProcDiv];
                        // --- ADD 2010/02/05 -------------->>>
                        rateUpdWork.LogicalDeleteCode = (int)row[COL_NM_LogicalDeleteCode];
                        // --- ADD 2010/02/05 --------------<<<
                        #endregion

                        updList.Add(rateUpdWork);
                    }

                    if (((int)row[COL_NM_GoodsMakerCd] != (int)row[COL_NM_BfGoodsMakerCd])
                        || (row[COL_NM_GoodsRateRank] != row[COL_NM_BfGoodsRateRank])
                        || ((int)row[COL_NM_BLGoodsCode] != (int)row[COL_NM_BfBLGoodsCode]))
                    {
                        retList.Add(resultListWork);
                    }
                }
            }

            //Filter
            FilterRateData(ref delList, ref updList);

            try
            {
                if (delList.Count > 0)
                {
                    status = rateDB.DeleteSubSectionProc(delList, ref sqlConnection, ref sqlTransaction);
                }

                if (updList.Count > 0)
                {
                    status = WriteRateProc(ref updList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="rateWorkList">RateWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        private int WriteRateProc(ref ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            string command = string.Empty;

            ArrayList al = new ArrayList();

            int logicalDeleteCode = 0;// ADD 2010/02/05

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                        RateWork rateWork = rateWorkList[i] as RateWork;

                        # region [INSERT��]
                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                        sqlCommand.CommandText += " )" + Environment.NewLine;
                        sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                        sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                        sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                        sqlCommand.CommandText += " )" + Environment.NewLine;
                        # endregion

                        // --- ADD 2010/02/05 -------------->>>
                        logicalDeleteCode = rateWork.LogicalDeleteCode;
                        // --- ADD 2010/02/05 --------------<<<

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rateWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        // --- ADD 2010/02/05 -------------->>>
                        rateWork.LogicalDeleteCode = logicalDeleteCode;
                        // --- ADD 2010/02/05 --------------<<<

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                        SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                        SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                        SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                        SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                        SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                        SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                        SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                        SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        paraGoodsNo.Value = rateWork.GoodsNo;
                        paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                        paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rateWork);
                    }

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;
        }

        /// <summary>
        /// �f�[�^�쐬Filter��������
        /// </summary>
        /// <param name="delList"></param>
        /// <param name="updList"></param>
        /// <returns></returns>
        /// <br>Note       : �f�[�^�쐬Filter��������</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private void FilterRateData(ref ArrayList delList, ref ArrayList updList)
        {
            //delete�f�[�^��Filter
            if (delList.Count > 0)
            {
                Dictionary<string, RateWork> dic = new Dictionary<string, RateWork>();
                ArrayList delArrayList = new ArrayList();
                foreach (RateWork work in delList)
                {
                    string key = work.EnterpriseCode.Trim() + "-" + work.SectionCode.Trim() + "-" +
                         work.UnitRateSetDivCd.ToString() + "-" + work.GoodsMakerCd.ToString() + "-" +
                         work.GoodsNo.ToString() + "-" + work.GoodsRateRank.Trim() + "-" +
                         work.GoodsRateGrpCode.ToString() + "-" + work.BLGroupCode.ToString() + "-" +
                         work.BLGoodsCode.ToString() + "-" + work.CustomerCode.ToString() + "-" +
                         work.CustRateGrpCode.ToString() + "-" + work.SupplierCd.ToString() + "-" + work.LotCount.ToString();
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, work);
                    }
                }
                foreach (string key in dic.Keys)
                {
                    delArrayList.Add(dic[key]);
                }

                delList = delArrayList;
            }
            //updata�f�[�^��Filter
            if (updList.Count > 0)
            {
                Dictionary<string, RateWork> dic = new Dictionary<string, RateWork>();
                ArrayList updArrayList = new ArrayList();
                foreach (RateWork work in updList)
                {
                    string key = work.EnterpriseCode.Trim() + "-" + work.SectionCode.Trim() + "-" +
                         work.UnitRateSetDivCd.ToString() + "-" + work.GoodsMakerCd.ToString() + "-" +
                         work.GoodsNo.ToString() + "-" + work.GoodsRateRank.Trim() + "-" +
                         work.GoodsRateGrpCode.ToString() + "-" + work.BLGroupCode.ToString() + "-" +
                         work.BLGoodsCode.ToString() + "-" + work.CustomerCode.ToString() + "-" +
                         work.CustRateGrpCode.ToString() + "-" + work.SupplierCd.ToString() + "-" + work.LotCount.ToString();
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, work);
                    }
                }
                foreach (string key in dic.Keys)
                {
                    updArrayList.Add(dic[key]);
                }

                updList = updArrayList;
            }
        }

        /// <summary>
        /// �f�B�N�V���i���L�[
        /// </summary>
        /// <param name="rateSetTable">rowView</param>
        /// <param name="row">row</param>
        /// <returns>dic�L�[</returns>
        /// <remarks>
        /// <br>Note       : �f�B�N�V���i���L�[�������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// </remarks>
        private string KeyofDic(DataTable rateSetTable, DataRow row)
        {
            string rowFilterString = string.Empty;
            rowFilterString = string.Format("{0}='{1}' AND {2} = {3} AND {4} = '{5}' AND {6} = '{7}' AND {8} ={9} AND {10} ={11} " +
                "AND {12} ={13} AND {14} ={15} AND {16} ={17} AND {18} ={19}",
                 rateSetTable.Columns[COL_NM_SectionCode].ColumnName, row[COL_NM_SectionCode],
                 rateSetTable.Columns[COL_NM_GoodsMakerCd].ColumnName, row[COL_NM_GoodsMakerCd],
                 rateSetTable.Columns[COL_NM_GoodsNo].ColumnName, row[COL_NM_GoodsNo],
                 rateSetTable.Columns[COL_NM_GoodsRateRank].ColumnName, row[COL_NM_GoodsRateRank],
                 rateSetTable.Columns[COL_NM_GoodsRateGrpCode].ColumnName, row[COL_NM_GoodsRateGrpCode],
                 rateSetTable.Columns[COL_NM_BLGroupCode].ColumnName, row[COL_NM_BLGroupCode],
                 rateSetTable.Columns[COL_NM_BLGoodsCode].ColumnName, row[COL_NM_BLGoodsCode],
                 rateSetTable.Columns[COL_NM_CustomerCode].ColumnName, row[COL_NM_CustomerCode],
                 rateSetTable.Columns[COL_NM_CustRateGrpCode].ColumnName, row[COL_NM_CustRateGrpCode],
                 rateSetTable.Columns[COL_NM_SupplierCd].ColumnName, row[COL_NM_SupplierCd]);
            return rowFilterString;
        }

        /// <summary>
        /// �f�[�^�쐬�\�[�g����������
        /// </summary>
        /// <param name="rateSetTable"></param>
        /// <returns></returns>
        /// <br>Note       :  �\�[�g����������</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string MakeRateSetSort(DataTable rateSetTable)
        {
            string sortString = string.Empty;
            sortString = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                rateSetTable.Columns[COL_NM_SectionCode].ColumnName,
                rateSetTable.Columns[COL_NM_GoodsMakerCd].ColumnName,
                rateSetTable.Columns[COL_NM_GoodsNo].ColumnName,
                rateSetTable.Columns[COL_NM_GoodsRateRank].ColumnName,
                rateSetTable.Columns[COL_NM_GoodsRateGrpCode].ColumnName,
                rateSetTable.Columns[COL_NM_BLGroupCode].ColumnName,
                rateSetTable.Columns[COL_NM_BLGoodsCode].ColumnName,
                rateSetTable.Columns[COL_NM_CustomerCode].ColumnName,
                rateSetTable.Columns[COL_NM_CustRateGrpCode].ColumnName,
                rateSetTable.Columns[COL_NM_SupplierCd].ColumnName,
                rateSetTable.Columns[COL_NM_GoodsMakerFlag].ColumnName,
                rateSetTable.Columns[COL_NM_GoodsRateRankFlag].ColumnName,
                rateSetTable.Columns[COL_NM_BLGoodsCodeFlag].ColumnName,
                rateSetTable.Columns[COL_NM_index].ColumnName);
            return sortString;
        }

        /// <summary>
        /// �������e�쐬�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="flag">flag</param>
        /// <br>Note       :  �������e�쐬�̏�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string SetContentString(DataRow row, int flag)
        {
            string contentString = string.Empty;

            if (flag == 0)
            {
                contentString = "���ɓo�^����Ă��܂��B";
            }

            int goodsMakerFlag = (int)row[COL_NM_GoodsMakerFlag];
            int goodsRateRankFlag = (int)row[COL_NM_GoodsRateRankFlag];
            int bLGoodsCodeFlag = (int)row[COL_NM_BLGoodsCodeFlag];
            string bFGoodsMakerCd = ((int)row[COL_NM_GoodsMakerCd]).ToString("d4");
            string bFGoodsRateRank = row[COL_NM_GoodsRateRank].ToString();
            string bFBLGoodsCode = ((int)row[COL_NM_BLGoodsCode]).ToString("d5");

            if (goodsMakerFlag == 0 && goodsRateRankFlag == 0 && bLGoodsCodeFlag ==0)
            {
                contentString += "BL���ޓ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode;
            }
            else if (goodsMakerFlag == 0 && goodsRateRankFlag == 0 && bLGoodsCodeFlag == 1)
            {
                contentString += "BL���ޕ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode;
            }
            else if (goodsMakerFlag == 0 && goodsRateRankFlag == 1 && bLGoodsCodeFlag == 0)
            {
                contentString += "BL���ޓ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode + " �w��:" + bFGoodsRateRank;
            }
            else if (goodsMakerFlag == 0 && goodsRateRankFlag == 1 && bLGoodsCodeFlag == 1)
            {
                contentString += "BL���ޓ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode + " �w��:" + bFGoodsRateRank;
            }
            else if (goodsMakerFlag == 1 && goodsRateRankFlag == 0 && bLGoodsCodeFlag == 0)
            {
                contentString += "Ұ���ʓW�J Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode;
            }
            else if (goodsMakerFlag == 1 && goodsRateRankFlag == 0 && bLGoodsCodeFlag == 1)
            {
                contentString += "BL���ޕ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode;
            }
            else if (goodsMakerFlag == 1 && goodsRateRankFlag == 1 && bLGoodsCodeFlag == 0)
            {
                contentString += "BL���ޓ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode + " �w��:" + bFGoodsRateRank;
            }
            else if (goodsMakerFlag == 1 && goodsRateRankFlag == 1 && bLGoodsCodeFlag == 1)
            {
                contentString += "BL���ޓ��� Ұ��:" + bFGoodsMakerCd + " BL:" + bFBLGoodsCode + " �w��:" + bFGoodsRateRank;
            }

            return contentString;
        }

        /// <summary>
        /// �L�[���쐬�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <br>Note       :  �L�[���쐬�̏�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string SetkeyString(DataRow row)
        {
            string keyString = string.Empty;

            //�P�����
            int unitPriceKind = Int32.Parse(row[COL_NM_UnitPriceKind].ToString());
            if (unitPriceKind == 1)
            {
                keyString += "�����ݒ�";
            }
            else if (unitPriceKind == 2)
            {
                keyString += "�����ݒ�";
            }
            else if (unitPriceKind == 3)
            {
                keyString += "���i�ݒ�";
            }
            //���_�R�[�h
            if (!string.IsNullOrEmpty(row[COL_NM_SectionCode].ToString().Trim()))
            {
                keyString += " ���_:" + row[COL_NM_SectionCode].ToString().Trim().PadLeft(2, '0');
            }
            //�ϊ��O���[�J�[�R�[�h
            if ((int)row[COL_NM_BfGoodsMakerCd] != 0)
            {
                keyString += " Ұ��:" + ((int)row[COL_NM_BfGoodsMakerCd]).ToString("d4");
            }
            //���i�ԍ�
            if (!string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString().Trim()))
            {
                keyString += " �i��:" + row[COL_NM_GoodsNo].ToString();
            }
            //�ϊ��O�w��
            if (!string.IsNullOrEmpty(row[COL_NM_BfGoodsRateRank].ToString().Trim()))
            {
                keyString += " �w��:" + row[COL_NM_BfGoodsRateRank].ToString();
            }
            //���i�|���O���[�v�R�[�h
            if ((int)row[COL_NM_GoodsRateGrpCode] != 0)
            {
                keyString += " �|GR:" + ((int)row[COL_NM_GoodsRateGrpCode]).ToString("d4");
            }
            //�a�k�O���[�v�R�[�h
            if ((int)row[COL_NM_BLGroupCode] != 0)
            {
                keyString += " ��ٰ��:" + ((int)row[COL_NM_BLGroupCode]).ToString("d4");
            }
            //�ϊ��O�a�k�R�[�h
            if ((int)row[COL_NM_BfBLGoodsCode] != 0)
            {
                keyString += " BL:" + ((int)row[COL_NM_BfBLGoodsCode]).ToString("d5");
            }
            //���Ӑ�R�[�h
            if ((int)row[COL_NM_CustomerCode] != 0)
            {
                keyString += " ��:" + ((int)row[COL_NM_CustomerCode]).ToString("d8");
            }
            //���Ӑ�|���O���[�v�R�[�h
            if ((int)row[COL_NM_CustRateGrpCode] != 0)
            {
                keyString += " ���|G:" + ((int)row[COL_NM_CustRateGrpCode]).ToString("d8");
            }
            //�d����R�[�h
            if ((int)row[COL_NM_SupplierCd] != 0)
            {
                keyString += " �d:" + ((int)row[COL_NM_SupplierCd]).ToString("d6");
            }
            //���b�g��
            if ((double)row[COL_NM_LotCount] != 0)
            {
                keyString += " ���:" + string.Format("{0:###,###,##0}", row[COL_NM_LotCount].ToString());
            }
            return keyString;
        }

        /// <summary>
        /// �|���ݒ�敪�X�V�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <br>Note       :  �|���ݒ�敪�X�V�̏���</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private void RateSettingMd(DataRow row)
        {
            if ((int)row[COL_NM_GoodsMakerCd] != 0 && !string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "A";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+�i��";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (!string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] != 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "B";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+�w��+BL����";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (!string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] != 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "C";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+�w��+��ٰ�ߺ���";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] != 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "D";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+BL����";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] != 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "E";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+��ٰ�ߺ���";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] != 0))
            {
                row[COL_NM_RateMngGoodsCd] = "F";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+���i�|��G";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (!string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "G";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+�w��";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (!string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "G";
                row[COL_NM_RateMngGoodsNm] = "Ұ��+�w��";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] == 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] != 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "H";
                row[COL_NM_RateMngGoodsNm] = "BL����";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] == 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] != 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "I";
                row[COL_NM_RateMngGoodsNm] = "��ٰ�ߺ���";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] == 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] != 0))
            {
                row[COL_NM_RateMngGoodsCd] = "J";
                row[COL_NM_RateMngGoodsNm] = "������";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] != 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "K";
                row[COL_NM_RateMngGoodsNm] = "Ұ��";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }
            else if ((int)row[COL_NM_GoodsMakerCd] == 0 && string.IsNullOrEmpty(row[COL_NM_GoodsNo].ToString())
                && (string.IsNullOrEmpty(row[COL_NM_GoodsRateRank].ToString().Trim())) && ((int)row[COL_NM_BLGoodsCode] == 0)
                && ((int)row[COL_NM_BLGroupCode] == 0) && ((int)row[COL_NM_GoodsRateGrpCode] == 0))
            {
                row[COL_NM_RateMngGoodsCd] = "L";
                row[COL_NM_RateMngGoodsNm] = "�w��Ȃ�";
                row[COL_NM_RateSettingDivide] = row[COL_NM_RateMngCustCd].ToString() + row[COL_NM_RateMngGoodsCd].ToString();
            }

            row[COL_NM_UnitRateSetDivCd] = row[COL_NM_UnitPriceKind].ToString() + row[COL_NM_RateSettingDivide].ToString();
        }
        #endregion �|���}�X�^�X�V����

        #region ���i�}�X�^�E�����n�f�[�^�X�V����
        /// <summary>
        /// ���i�}�X�^�E�����n�f�[�^�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsAList">���i�}�X�^���X�g�`</param>
        /// <param name="goodsBList">���i�}�X�^���X�g�a</param>
        /// <param name="goodsCList">���i�}�X�^���X�g�b</param>
        /// <param name="retList">�������ʃ��X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�E�����n�f�[�^�X�V����(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/08 杍^ redmine#2879�Ή�</br>
        /// </remarks>
        private int GoodsUpdateProc(string enterpriseCode, ArrayList goodsAList, ArrayList goodsBList, ArrayList goodsCList, ref ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ResultListWork resultListWork = null;

            // �X�V�w�b�_���
            GoodsUWork goodsUWork = new GoodsUWork();
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)goodsUWork;
            FileHeader fileHeader = new FileHeader(obj);
            fileHeader.SetUpdateHeader(ref flhd, obj);

            #region ���i�}�X�^���X�g�`
            if (goodsAList != null && goodsAList.Count != 0)
            {
                ArrayList tempList = new ArrayList();

                // Ұ�����ށA�ϊ��OBL���ށA���i�Ԃ�SORT
                goodsAList.Sort(new GoodsParaAWorkComparer());

                ArrayList goodsResultAList = new ArrayList();
                Int32 makerCdBak = 0;
                Int32 blGoodsCodeBak = 0;
                string goodsNoBak = string.Empty;
                string beforeLevel = string.Empty;
                string afterLevel = string.Empty;
                string sqlstr = string.Empty;
                ArrayList sqlList = new ArrayList();
                GoodsTempWork goodsTempWork = null;
                bool firstDataFlg = true;

                for (int i = 0; i < goodsAList.Count; i++ )
                {
                    GoodsParaAWork goodsParaAWork = (GoodsParaAWork)goodsAList[i];

                    if (string.IsNullOrEmpty(goodsParaAWork.TopGoodsNo))
                    {
                        status = this.GoodsASearchProc(enterpriseCode, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, sqlstr, sqlList, out goodsResultAList, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (GoodsUWork GoodsUWork1 in goodsResultAList)
                            {
                                if (GoodsUWork1.GoodsRateRank.Trim().Equals(goodsParaAWork.AfterLevel.Trim()))
                                {
                                    continue;
                                }
                                goodsTempWork = new GoodsTempWork();
                                goodsTempWork.GoodsMakerCd = int.Parse(goodsParaAWork.MakerCd);
                                goodsTempWork.BLGoodsCode = int.Parse(goodsParaAWork.BeforeBlCd);
                                goodsTempWork.GoodsNo = GoodsUWork1.GoodsNo;
                                goodsTempWork.GoodsRateRankBf = GoodsUWork1.GoodsRateRank;
                                goodsTempWork.GoodsRateRankAf = goodsParaAWork.AfterLevel;
                                tempList.Add(goodsTempWork);
                            }

                            // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(GOODSURF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // --- ADD 2010/02/08 ----------->>>>
                            // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            // --- ADD 2010/02/08 -----------<<<<

                            continue;
                        }
                        else
                        {
                            return status;
                        }

                        makerCdBak = 0;
                        blGoodsCodeBak = 0;
                        goodsNoBak = string.Empty;
                        sqlstr = string.Empty;
                        sqlList = new ArrayList();
                    }
                    else
                    {
                        if (firstDataFlg)
                        {
                            firstDataFlg = false;
                            makerCdBak = int.Parse(goodsParaAWork.MakerCd);
                            blGoodsCodeBak = int.Parse(goodsParaAWork.BeforeBlCd);
                            goodsNoBak = goodsParaAWork.TopGoodsNo;

                            status = this.GoodsASearchProc(enterpriseCode, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, sqlstr, sqlList, out goodsResultAList, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                foreach (GoodsUWork GoodsUWork1 in goodsResultAList)
                                {
                                    if (GoodsUWork1.GoodsRateRank.Trim().Equals(goodsParaAWork.AfterLevel.Trim()))
                                    {
                                        continue;
                                    }
                                    goodsTempWork = new GoodsTempWork();
                                    goodsTempWork.GoodsMakerCd = int.Parse(goodsParaAWork.MakerCd);
                                    goodsTempWork.BLGoodsCode = int.Parse(goodsParaAWork.BeforeBlCd);
                                    goodsTempWork.GoodsNo = GoodsUWork1.GoodsNo;
                                    goodsTempWork.GoodsRateRankBf = GoodsUWork1.GoodsRateRank;
                                    goodsTempWork.GoodsRateRankAf = goodsParaAWork.AfterLevel;
                                    tempList.Add(goodsTempWork);
                                }

                                // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(GOODSURF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // --- ADD 2010/02/08 ----------->>>>
                                // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                // --- ADD 2010/02/08 -----------<<<<

                                continue;
                            }
                            else
                            {
                                return status;
                            }
                            sqlstr = goodsNoBak;
                            sqlList.Add(goodsNoBak);
                        }
                        else
                        {
                            if (makerCdBak == int.Parse(goodsParaAWork.MakerCd)
                                && blGoodsCodeBak == int.Parse(goodsParaAWork.BeforeBlCd))
                            {
                                if (0 == goodsNoBak.IndexOf(goodsParaAWork.TopGoodsNo))
                                {
                                    status = this.GoodsASearchProc(enterpriseCode, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, sqlstr, sqlList, out goodsResultAList, ref sqlConnection, ref sqlTransaction);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        foreach (GoodsUWork GoodsUWork1 in goodsResultAList)
                                        {
                                            if (GoodsUWork1.GoodsRateRank.Trim().Equals(goodsParaAWork.AfterLevel.Trim()))
                                            {
                                                continue;
                                            }
                                            goodsTempWork = new GoodsTempWork();
                                            goodsTempWork.GoodsMakerCd = int.Parse(goodsParaAWork.MakerCd);
                                            goodsTempWork.BLGoodsCode = int.Parse(goodsParaAWork.BeforeBlCd);
                                            goodsTempWork.GoodsNo = GoodsUWork1.GoodsNo;
                                            goodsTempWork.GoodsRateRankBf = GoodsUWork1.GoodsRateRank;
                                            goodsTempWork.GoodsRateRankAf = goodsParaAWork.AfterLevel;
                                            tempList.Add(goodsTempWork);
                                        }

                                        // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(GOODSURF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // --- ADD 2010/02/08 ----------->>>>
                                        // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // --- ADD 2010/02/08 -----------<<<<

                                        continue;
                                    }
                                    else
                                    {
                                        return status;
                                    }

                                    goodsNoBak = goodsParaAWork.TopGoodsNo;
                                    sqlstr = goodsNoBak;
                                }
                                else
                                {
                                    sqlstr = string.Empty;

                                    status = this.GoodsASearchProc(enterpriseCode, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, sqlstr, sqlList, out goodsResultAList, ref sqlConnection, ref sqlTransaction);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        foreach (GoodsUWork GoodsUWork1 in goodsResultAList)
                                        {
                                            if (GoodsUWork1.GoodsRateRank.Trim().Equals(goodsParaAWork.AfterLevel.Trim()))
                                            {
                                                continue;
                                            }
                                            goodsTempWork = new GoodsTempWork();
                                            goodsTempWork.GoodsMakerCd = int.Parse(goodsParaAWork.MakerCd);
                                            goodsTempWork.BLGoodsCode = int.Parse(goodsParaAWork.BeforeBlCd);
                                            goodsTempWork.GoodsNo = GoodsUWork1.GoodsNo;
                                            goodsTempWork.GoodsRateRankBf = GoodsUWork1.GoodsRateRank;
                                            goodsTempWork.GoodsRateRankAf = goodsParaAWork.AfterLevel;
                                            tempList.Add(goodsTempWork);
                                        }

                                        // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(GOODSURF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // --- ADD 2010/02/08 ----------->>>>
                                        // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                        status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                        // --- ADD 2010/02/08 -----------<<<<

                                        continue;
                                    }
                                    else
                                    {
                                        return status;
                                    }
                                    goodsNoBak = goodsParaAWork.TopGoodsNo;
                                    sqlstr = goodsNoBak;
                                }

                                sqlList.Add(goodsNoBak);
                            }
                            else
                            {
                                sqlstr = string.Empty;
                                sqlList = new ArrayList();

                                status = this.GoodsASearchProc(enterpriseCode, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, sqlstr, sqlList, out goodsResultAList, ref sqlConnection, ref sqlTransaction);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    foreach (GoodsUWork GoodsUWork1 in goodsResultAList)
                                    {
                                        if (GoodsUWork1.GoodsRateRank.Trim().Equals(goodsParaAWork.AfterLevel.Trim()))
                                        {
                                            continue;
                                        }
                                        goodsTempWork = new GoodsTempWork();
                                        goodsTempWork.GoodsMakerCd = int.Parse(goodsParaAWork.MakerCd);
                                        goodsTempWork.BLGoodsCode = int.Parse(goodsParaAWork.BeforeBlCd);
                                        goodsTempWork.GoodsNo = GoodsUWork1.GoodsNo;
                                        goodsTempWork.GoodsRateRankBf = GoodsUWork1.GoodsRateRank;
                                        goodsTempWork.GoodsRateRankAf = goodsParaAWork.AfterLevel;
                                        tempList.Add(goodsTempWork);
                                    }

                                    // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(GOODSURF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // --- ADD 2010/02/08 ----------->>>>
                                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(SALESDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(SALESHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(STOCKDETAILRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                                    status = this.GoodsAUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, goodsParaAWork.AfterLevel, int.Parse(goodsParaAWork.MakerCd), int.Parse(goodsParaAWork.BeforeBlCd), goodsParaAWork.TopGoodsNo, goodsUWork, sqlstr, sqlList, ref sqlConnection, ref sqlTransaction);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                                    // --- ADD 2010/02/08 -----------<<<<

                                    continue;
                                }
                                else
                                {
                                    return status;
                                }

                                makerCdBak = int.Parse(goodsParaAWork.MakerCd);
                                blGoodsCodeBak = int.Parse(goodsParaAWork.BeforeBlCd);
                                goodsNoBak = goodsParaAWork.TopGoodsNo;
                                sqlstr = goodsNoBak;
                                sqlList.Add(goodsNoBak);
                            }
                        }
                    }
                }

                if (tempList.Count > 0)
                {
                    tempList.Sort(new GoodsTempWorkComparer());

                    GoodsTempWork tempWork = null;
                    ResultListWork resultListTempWork = null;
                    for (int m = 0; m < tempList.Count; m++)
                    {
                        tempWork = (GoodsTempWork)tempList[m];
                        resultListTempWork = new ResultListWork();
                        resultListTempWork.TableName = "���iϽ�";
                        resultListTempWork.Status = "�ϊ�";
                        resultListTempWork.Key = "Ұ��:" + tempWork.GoodsMakerCd.ToString("0000") + " �i��:" + tempWork.GoodsNo;
                        // �ϊ��O�w�ʂ�string.Empty�̏ꍇ�A"�ݒ�Ȃ�"�Əo�͂���B
                        if (string.IsNullOrEmpty(tempWork.GoodsRateRankBf.Trim()))
                        {
                            resultListTempWork.Content = "�w�ʕϊ�[�ݒ�Ȃ�" + "��" + tempWork.GoodsRateRankAf.Trim() + "]";
                        }
                        else
                        {
                            resultListTempWork.Content = "�w�ʕϊ�[" + tempWork.GoodsRateRankBf.Trim() + "��" + tempWork.GoodsRateRankAf.Trim() + "]";
                        }
                        retList.Add(resultListTempWork);
                    }
                }
            }
            #endregion

            #region ���i�}�X�^���X�g�a
            if (goodsBList != null && goodsBList.Count != 0)
            {
                ArrayList goodsResultBList = new ArrayList();
                foreach (GoodsParaBWork goodsParaBWork in goodsBList)
                {
                    status = this.GoodsBSearchProc(enterpriseCode, int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, out goodsResultBList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        for (int i = 0; i < goodsResultBList.Count; i++)
                        {
                            GoodsUWork goodsBWork = (GoodsUWork)goodsResultBList[i];

                            if (int.Parse(goodsParaBWork.AfterBlCd) == goodsBWork.BLGoodsCode)
                            {
                                continue;
                            }
                            resultListWork = new ResultListWork();
                            resultListWork.TableName = "���iϽ�";
                            resultListWork.Status = "�ϊ�";
                            resultListWork.Key = "Ұ��:" + goodsParaBWork.MakerCd.ToString() + " �i��:" + goodsParaBWork.halfGoodsNp;
                            resultListWork.Content = "BL���ޕϊ�[" + goodsBWork.BLGoodsCode.ToString("00000") + "��" + goodsParaBWork.AfterBlCd + "]";
                            retList.Add(resultListWork);
                        }

                        // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsBUpdateProc(GOODSURF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status; 
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //continue;      // DEL 2010/02/08
                    }
                    else
                    {
                        return status;
                    }

                    // --- ADD 2010/02/08 --------->>>>
                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(SALESDETAILRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(SALESHISTDTLRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(STOCKDETAILRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �݌Ɉړ��f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(STOCKMOVERF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �݌ɒ������׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(STOCKADJUSTDTLRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �݌Ɏ󕥗����f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdateProc(STOCKACPAYHISTRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    // �X�V�����|�Q
                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdate2Proc(SALESDETAILRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdate2Proc(SALESHISTDTLRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdate2Proc(STOCKDETAILRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdate2Proc(STOCKSLHISTDTLRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    // �X�V�����|�R
                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdate3Proc(SALESDETAILRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsBUpdate3Proc(SALESHISTDTLRF_TABLE_NM, int.Parse(goodsParaBWork.AfterBlCd), int.Parse(goodsParaBWork.MakerCd), goodsParaBWork.halfGoodsNp, goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // --- ADD 2010/02/08 --------------<<<
                }
            }
            #endregion

            #region ���i�}�X�^���X�g�b
            if (goodsCList != null && goodsCList.Count != 0)
            {
                ArrayList goodsResultCList = new ArrayList();
                foreach (GoodsParaCWork goodsParaCWork in goodsCList)
                {
                    // --- DEL 2010/02/08 -------->>>>
                    //if (int.Parse(goodsParaCWork.BeforeBlCd) == int.Parse(goodsParaCWork.AfterBlCd))
                    //{
                    //    continue;
                    //}
                    // --- DEL 2010/02/08 --------<<<<

                    // --- UPD 2010/02/08 -------->>>>
                    if (int.Parse(goodsParaCWork.BeforeBlCd) != int.Parse(goodsParaCWork.AfterBlCd))
                    {
                        status = this.GoodsCSearchProc(enterpriseCode, int.Parse(goodsParaCWork.MakerCd), int.Parse(goodsParaCWork.BeforeBlCd), out goodsResultCList, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            for (int i = 0; i < goodsResultCList.Count; i++)
                            {
                                GoodsUWork goodsCWork = (GoodsUWork)goodsResultCList[i];
                                resultListWork = new ResultListWork();
                                resultListWork.TableName = "���iϽ�";
                                resultListWork.Status = "�ϊ�";
                                resultListWork.Key = "Ұ��:" + goodsParaCWork.MakerCd + " �i��:" + goodsCWork.GoodsNo;
                                resultListWork.Content = "BL���ޕϊ�[" + goodsParaCWork.BeforeBlCd + "��" + goodsParaCWork.AfterBlCd + "]";
                                retList.Add(resultListWork);
                            }

                            // ���iϽ��ɑ΂���UPDATE���𔭍s���čX�V���s���B
                            status = this.GoodsCUpdateProc(GOODSURF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //continue;   // DEL 2010/02/08
                        }
                        else
                        {
                            return status;
                        }

                        // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(SALESDETAILRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(SALESHISTDTLRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(STOCKDETAILRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(STOCKSLHISTDTLRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        // �݌Ɉړ��f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(STOCKMOVERF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        // �݌ɒ������׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(STOCKADJUSTDTLRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                        // �݌Ɏ󕥗����f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                        status = this.GoodsCUpdateProc(STOCKACPAYHISTRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    }
                    // --- UPD 2010/02/08 --------<<<<

                    // --- ADD 2010/02/08 -------------->>>
                    // �X�V�����|�Q
                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsCUpdate2Proc(SALESDETAILRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsCUpdate2Proc(SALESHISTDTLRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �d�����׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsCUpdate2Proc(STOCKDETAILRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �d�����𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsCUpdate2Proc(STOCKSLHISTDTLRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // �X�V�����|�R
                    // ���㖾�׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsCUpdate3Proc(SALESDETAILRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // ���㗚�𖾍׃f�[�^�ɑ΂���UPDATE���𔭍s���čX�V���s���B
                    status = this.GoodsCUpdate3Proc(SALESHISTDTLRF_TABLE_NM, int.Parse(goodsParaCWork.BeforeBlCd), int.Parse(goodsParaCWork.AfterBlCd), int.Parse(goodsParaCWork.MakerCd), goodsUWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    // --- ADD 2010/02/08 --------------<<<
                }
            }
            #endregion

            return status;
        }

        #region ���i�}�X�^���X�g�`��������
        /// <summary>
        /// ���i�}�X�^���X�g�`��������(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="sqlstr">SQL�ϐ�</param>
        /// <param name="sqlList">SQL���X�g�ϐ�</param>
        /// <param name="goodsList">���i�}�X�^���X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/03 杍^ �_���폜���ɂ��ĒǋL</br>
        /// </remarks>
        private int GoodsASearchProc(string enterpriseCode, Int32 goodsMakerCd, Int32 blGoodsCode, string goodsNo, string sqlstr, ArrayList sqlList, out ArrayList goodsList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsList = new ArrayList();
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //sqlStr = "SELECT GOODSMAKERCDRF , BLGOODSCODERF, GOODSNORF, GOODSRATERANKRF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE " + Environment.NewLine; // DEL 2010/02/03 
                sqlStr = "SELECT GOODSMAKERCDRF , BLGOODSCODERF, GOODSNORF, GOODSRATERANKRF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE " + Environment.NewLine;     // ADD 2010/02/03 
                if (!string.IsNullOrEmpty(goodsNo))
                {
                    if (!string.IsNullOrEmpty(sqlstr))
                    {
                        sqlStr += " AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo + "%");

                        sqlStr += " AND GOODSNORF NOT LIKE @FINDGOODSNOTEMP" + Environment.NewLine;
                        SqlParameter findParaGoodsNoTemp = sqlCommand.Parameters.Add("@FINDGOODSNOTEMP", SqlDbType.NVarChar);
                        findParaGoodsNoTemp.Value = SqlDataMediator.SqlSetString(sqlstr + "%");
                    }
                    else
                    {
                        sqlStr += " AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo + "%");
                    }
                }
                else
                {
                    SqlParameter findParaGoodsNo = null;
                    for (int i = 0; i < sqlList.Count; i++ )
                    {
                        sqlStr += " AND GOODSNORF NOT LIKE @FINDGOODSNO" + i.ToString() + Environment.NewLine;
                        findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO" + i.ToString(), SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(sqlList[i] + "%");
                    }
                }

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);   // DEL 2010/02/03 
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                //findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);              // DEL 2010/02/03 
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);


                // ����}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                GoodsUWork goodsUWork = null;

                while (myReader.Read())
                {
                    goodsUWork = new GoodsUWork();
                    goodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    goodsList.Add(goodsUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsASearchProc Exception=" + ex.Message);
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
        #endregion

        #region ���i�}�X�^���X�g�`�X�V����
        /// <summary>
        /// ���i�}�X�^���X�g�`�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="goodsRateRank">�w��</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlstr">SQL�ϐ�</param>
        /// <param name="sqlList">SQL���X�g�ϐ�</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/26 杍^ redmine#2628�Ή�</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        /// </remarks>
        private int GoodsAUpdateProc(string tableName, string goodsRateRank, Int32 goodsMakerCd, Int32 blGoodsCode, string goodsNo, GoodsUWork goodsUWork, string sqlstr, ArrayList sqlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                    // --- UPD 2010/02/05 -------------->>>
                       //+ tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , GOODSRATERANKRF=@GOODSRATERANK WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                       +tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , GOODSRATERANKRF=@GOODSRATERANK WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    // --- UPD 2010/02/05 --------------<<<
                if (!string.IsNullOrEmpty(goodsNo))
                {
                    if (!string.IsNullOrEmpty(sqlstr))
                    {
                        sqlStr += " AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo + "%");

                        sqlStr += " AND GOODSNORF NOT LIKE @FINDGOODSNOTEMP" + Environment.NewLine;
                        SqlParameter findParaGoodsNoTemp = sqlCommand.Parameters.Add("@FINDGOODSNOTEMP", SqlDbType.NVarChar);
                        findParaGoodsNoTemp.Value = SqlDataMediator.SqlSetString(sqlstr + "%");
                    }
                    else
                    {
                        sqlStr += " AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo + "%");
                    }
                }
                else
                {
                    SqlParameter findParaGoodsNo = null;
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        sqlStr += " AND GOODSNORF NOT LIKE @FINDGOODSNO" + i.ToString() + Environment.NewLine;
                        findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO" + i.ToString(), SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(sqlList[i] + "%");
                    }
                }
                sqlStr += " AND ((GOODSRATERANKRF IS NULL) OR (GOODSRATERANKRF IS NOT NULL AND GOODSRATERANKRF <> @FINDGOODSRATERANK))" + Environment.NewLine;

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                // --- DEL 2010/02/05 -------------->>>
                //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                // --- DEL 2010/02/05 --------------<<<
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                // --- DEL 2010/02/05 -------------->>>
                //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.LogicalDeleteCode);
                // --- DEL 2010/02/05 --------------<<<
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsRateRank);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);
                findParaBLGoodsCode2.Value = SqlDataMediator.SqlSetString(goodsRateRank);

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;                 // ADD 2010/01/26

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsAUpdateProc Exception=" + ex.Message);
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
        #endregion

        #region ���i�}�X�^���X�g�a��������
        /// <summary>
        /// ���i�}�X�^���X�g�a��������(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsList">���i�}�X�^���X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/03 杍^ �_���폜���ɂ��ĒǋL</br>
        /// </remarks>
        private int GoodsBSearchProc(string enterpriseCode, Int32 goodsMakerCd, string goodsNo, out ArrayList goodsList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsList = new ArrayList();
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //sqlStr = "SELECT BLGOODSCODERF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";  // DEL 2010/02/03
                sqlStr = "SELECT BLGOODSCODERF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";   // ADD 2010/02/03

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);    // DEL 2010/02/03
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                //findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);                     // DEL 2010/02/03
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);

                // ����}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                GoodsUWork goodsUWork = null;

                while (myReader.Read())
                {
                    goodsUWork = new GoodsUWork();
                    goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsList.Add(goodsUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsBSearchProc Exception=" + ex.Message);
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
        #endregion

        #region ���i�}�X�^���X�g�a�X�V����
        /// <summary>
        /// ���i�}�X�^���X�g�a�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/26 杍^ redmine#2628�Ή�</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        /// </remarks>
        private int GoodsBUpdateProc(string tableName, Int32 blGoodsCode, Int32 goodsMakerCd, string goodsNo, GoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                    // --- UPD 2010/02/05 -------------->>>
                       //+ tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , BLGOODSCODERF=@BLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                       +tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , BLGOODSCODERF=@BLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                   // --- UPD 2010/02/05 --------------<<<
                sqlStr += " AND BLGOODSCODERF <> @FINDBLGOODSCODERF" + Environment.NewLine;
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                // --- DEL 2010/02/05 -------------->>>
                //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                // --- DEL 2010/02/05 --------------<<<
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODERF", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                // --- DEL 2010/02/05 -------------->>>
                //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.LogicalDeleteCode);
                // --- DEL 2010/02/05 --------------<<<
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;                 // ADD 2010/01/26

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsBUpdateProc Exception=" + ex.Message);
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
        #endregion

        // --- ADD 2010/02/08 -------------->>>
        #region ���i�}�X�^���X�g�a�X�V�����|�Q
        /// <summary>
        /// ���i�}�X�^���X�g�a�X�V�����|�Q(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������|�Q(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/02/08</br>
        /// </remarks>
        private int GoodsBUpdate2Proc(string tableName, Int32 blGoodsCode, Int32 goodsMakerCd, string goodsNo, GoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                + tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , RATEBLGOODSCODERF=@RATEBLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND RATEBLGOODSCODERF <> @FINDRATEBLGOODSCODE AND RATEBLGOODSCODERF <> @FINDRATEBLGOODSCODE2 " + Environment.NewLine;
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaRateBLGoodsCode = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaRateBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE2", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);
                findParaRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaRateBLGoodsCode2.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsBUpdate2Proc Exception=" + ex.Message);
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
        #endregion

        #region ���i�}�X�^���X�g�a�X�V�����|�R
        /// <summary>
        /// ���i�}�X�^���X�g�a�X�V�����|�R(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������|�R(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/02/08</br>
        /// </remarks>
        private int GoodsBUpdate3Proc(string tableName, Int32 blGoodsCode, Int32 goodsMakerCd, string goodsNo, GoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                + tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , PRTBLGOODSCODERF=@PRTBLGOODSCODERF WHERE PRTMAKERCODERF=@FINDPRTMAKERCODE AND PRTGOODSNORF=@FINDPRTGOODSNO AND PRTBLGOODSCODERF <> @FINDPRTBLGOODSCODE " + Environment.NewLine;
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraPrtBLGoodsCode = sqlCommand.Parameters.Add("@PRTBLGOODSCODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaPrtMakerCode = sqlCommand.Parameters.Add("@FINDPRTMAKERCODE", SqlDbType.Int);
                SqlParameter findParaPrtGoodsNo = sqlCommand.Parameters.Add("@FINDPRTGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPrtBLGoodsCode = sqlCommand.Parameters.Add("@FINDPRTBLGOODSCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaPrtGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);
                findParaPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsBUpdate3Proc Exception=" + ex.Message);
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
        #endregion
        // --- ADD 2010/02/08 --------------<<<

        #region ���i�}�X�^���X�g�b��������
        /// <summary>
        /// ���i�}�X�^���X�g�b��������(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsList">���i�}�X�^���X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/03 杍^ �_���폜���ɂ��ĒǋL</br>
        /// </remarks>
        private int GoodsCSearchProc(string enterpriseCode, Int32 goodsMakerCd, Int32 blGoodsCode, out ArrayList goodsList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsList = new ArrayList();
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //sqlStr = "SELECT GOODSNORF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE";  // DEL 2010/02/03
                sqlStr = "SELECT GOODSNORF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE";      // ADD 2010/02/03
                 
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);    // DEL 2010/02/03
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                //findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);                     // DEL 2010/02/03
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                // ����}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                GoodsUWork goodsUWork = null;

                while (myReader.Read())
                {
                    goodsUWork = new GoodsUWork();
                    goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsList.Add(goodsUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsCSearchProc Exception=" + ex.Message);
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
        #endregion

        #region ���i�}�X�^���X�g�b�X�V����
        /// <summary>
        /// ���i�}�X�^���X�g�b�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="blGoodsCodeBf">�ϊ��OBL���i�R�[�h</param>
        /// <param name="blGoodsCodeAf">�ϊ���BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/26 杍^ redmine#2628�Ή�</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        /// </remarks>
        private int GoodsCUpdateProc(string tableName, Int32 blGoodsCodeBf, Int32 blGoodsCodeAf, Int32 goodsMakerCd, GoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                    // --- UPD 2010/02/05 -------------->>>
                       //+ tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , BLGOODSCODERF=@BLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE";
                       +tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , BLGOODSCODERF=@BLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE";
                    // --- UPD 2010/02/05 --------------<<<
                sqlStr += "";
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                // --- DEL 2010/02/05 -------------->>>
                //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                // --- DEL 2010/02/05 --------------<<<
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODERF", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                // --- DEL 2010/02/05 -------------->>>
                //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsUWork.LogicalDeleteCode);
                // --- DEL 2010/02/05 --------------<<<
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeAf);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeBf);

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;                 // ADD 2010/01/26

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsCUpdateProc Exception=" + ex.Message);
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
        #endregion

        // --- ADD 2010/02/08 -------------->>>
        #region ���i�}�X�^���X�g�b�X�V�����|�Q
        /// <summary>
        /// ���i�}�X�^���X�g�b�X�V�����|�Q(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="blGoodsCodeBf">�ϊ��OBL���i�R�[�h</param>
        /// <param name="blGoodsCodeAf">�ϊ���BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������|�Q(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/02/08</br>
        /// <br>Update Note: 2010/02/09 杍^ Redmine#2909�̂a�k�R�[�h(�|��)�̏C��</br>
        /// </remarks>
        private int GoodsCUpdate2Proc(string tableName, Int32 blGoodsCodeBf, Int32 blGoodsCodeAf, Int32 goodsMakerCd, GoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                //+ tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , RATEBLGOODSCODERF=@RATEBLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND BLGOODSCODERF=@FINDBLGOODSCODE AND RATEBLGOODSCODERF <> @FINDRATEBLGOODSCODE AND RATEBLGOODSCODERF <> @FINDRATEBLGOODSCODE2";       // DEL 2010/02/09
                + tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , RATEBLGOODSCODERF=@RATEBLGOODSCODERF WHERE GOODSMAKERCDRF=@FINDGOODSMAKERCD AND RATEBLGOODSCODERF=@FINDRATEBLGOODSCODE AND RATEBLGOODSCODERF <> @FINDRATEBLGOODSCODE1 AND RATEBLGOODSCODERF <> @FINDRATEBLGOODSCODE2";   // ADD 2010/02/09
                sqlStr += "";
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODERF", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeAf);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                // --- UPD 2010/02/09 ------->>>>>
                //SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                //SqlParameter findParaRateBLGoodsCode = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE", SqlDbType.Int);
                //SqlParameter findParaRateBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE2", SqlDbType.Int);
                SqlParameter findParaRateBLGoodsCode = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaRateBLGoodsCode1 = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE1", SqlDbType.Int);
                SqlParameter findParaRateBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDRATEBLGOODSCODE2", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                //findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeBf);
                //findParaRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                //findParaRateBLGoodsCode2.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeAf);
                findParaRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeBf);
                findParaRateBLGoodsCode1.Value = SqlDataMediator.SqlSetInt32(0);
                findParaRateBLGoodsCode2.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeAf);
                // --- UPD 2010/02/09 -------<<<<<

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;       

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsCUpdate2Proc Exception=" + ex.Message);
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
        #endregion

        #region ���i�}�X�^���X�g�b�X�V�����|�R
        /// <summary>
        /// ���i�}�X�^���X�g�b�X�V�����|�R(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="tableName">�e�[�u����</param>
        /// <param name="blGoodsCodeBf">�ϊ��OBL���i�R�[�h</param>
        /// <param name="blGoodsCodeAf">�ϊ���BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsUWork">goodsUWork</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������|�R(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/02/08</br>
        /// </remarks>
        private int GoodsCUpdate3Proc(string tableName, Int32 blGoodsCodeBf, Int32 blGoodsCodeAf, Int32 goodsMakerCd, GoodsUWork goodsUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "UPDATE "
                + tableName + " SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , PRTBLGOODSCODERF=@PRTBLGOODSCODERF WHERE PRTMAKERCODERF=@FINDPRTMAKERCODE AND PRTBLGOODSCODERF=@FINDPRTBLGOODSCODE AND PRTBLGOODSCODERF <> @FINDPRTBLGOODSCODE2 ";
                sqlStr += "";
                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraPrtBLGoodsCode = sqlCommand.Parameters.Add("@PRTBLGOODSCODERF", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsUWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsUWork.UpdAssemblyId2);
                paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeAf);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaPrtMakerCode = sqlCommand.Parameters.Add("@FINDPRTMAKERCODE", SqlDbType.Int);
                SqlParameter findParaPrtBLGoodsCode = sqlCommand.Parameters.Add("@FINDPRTBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaPrtBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDPRTBLGOODSCODE2", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeBf);
                findParaPrtBLGoodsCode2.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeAf);

                // ���i�}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;

                sqlCommand.CommandTimeout = 3600;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsCUpdate3Proc Exception=" + ex.Message);
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
        #endregion
        // --- ADD 2010/02/08 --------------<<<

        #region ���i�p�����[�^��r�N���X
        /// <summary>
        /// ���i�p�����[�^��r�N���X(Ұ������(�~��)�A�ϊ��OBL����(�~��)�A���i��(�~��))
        /// </summary>
        public class GoodsParaAWorkComparer : Comparer<GoodsParaAWork>
        {
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(GoodsParaAWork x, GoodsParaAWork y)
            {
                int result = y.MakerCd.CompareTo(x.MakerCd);
                if (result != 0) return result;

                result = y.BeforeBlCd.CompareTo(x.BeforeBlCd);
                if (result != 0) return result;

                result = y.TopGoodsNo.CompareTo(x.TopGoodsNo);
                return result;
            }
        }

        /// <summary>
        /// ���i�p�����[�^��r�N���X(Ұ������(����)�ABL����(����)�A�i��(����))
        /// </summary>
        public class GoodsTempWorkComparer : Comparer<GoodsTempWork>
        {
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(GoodsTempWork x, GoodsTempWork y)
            {
                int result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                if (result != 0) return result;

                result = x.BLGoodsCode.CompareTo(y.BLGoodsCode);
                if (result != 0) return result;

                result = x.GoodsNo.CompareTo(y.GoodsNo);
                return result;
            }
        }
        #endregion

        #endregion ���i�}�X�^�E�����n�f�[�^�X�V����

        #region ���ʃ}�X�^�X�V����
        /// <summary>
        /// ���ʃ}�X�^�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="partsFile">���ʃ}�X�^���X�g</param>
        /// <param name="retList">�������ʃ��X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�X�V����(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        private int PartsPosCodeUpdateProc(string enterpriseCode, ArrayList partsFile, ref ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            Int32 maxPosDispOrder = 0;
            ArrayList partsPosCodeUList = null;
            string sectionStr = string.Empty;

            ResultListWork resultListWork = null;

            foreach (PartsParaWork partsParaWork in partsFile)
            {
                // �ϊ��O�a�k�R�[�h�Ƃa�k�R�[�h����v���郌�R�[�h��S�����o����B
                status = this.PartsPosCodeSearchProc(1, enterpriseCode, string.Empty, -1, -1, int.Parse(partsParaWork.BeforeBlCd), out maxPosDispOrder, out partsPosCodeUList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (PartsPosCodeUWork partsPosCodeUWork in partsPosCodeUList)
                    {
                        // ���o�����e���R�[�h��莟�̃L�[�l���擾���āA���ʃ}�X�^�ɊY�����R�[�h���������`�F�b�N����B
                        status = this.PartsPosCodeSearchProc(2, enterpriseCode, partsPosCodeUWork.SectionCode, partsPosCodeUWork.CustomerCode, partsPosCodeUWork.SearchPartsPosCode, int.Parse(partsParaWork.AfterBlCd), out maxPosDispOrder, out partsPosCodeUList, ref sqlConnection, ref sqlTransaction);
                        // �Y�����R�[�h��������
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // �o�^�w�b�_���
                            PartsPosCodeUWork updateWork = new PartsPosCodeUWork();
                            object objInsert = (object)this;
                            IFileHeader insertIf = (IFileHeader)updateWork;
                            FileHeader fileInsert = new FileHeader(objInsert);
                            fileInsert.SetInsertHeader(ref insertIf, objInsert);

                            // --- ADD 2010/02/05 -------------->>>
                            updateWork.LogicalDeleteCode = partsPosCodeUWork.LogicalDeleteCode;
                            // --- ADD 2010/02/05 --------------<<<

                            // ��ƃR�[�h�E���_�R�[�h�E���Ӑ�R�[�h�E�������ʃR�[�h������̃��R�[�h�̌������ʕ\�����ʂ̍ő�l�{�P���Z�b�g����B
                            status = this.PartsPosCodeSearchProc(3, enterpriseCode, partsPosCodeUWork.SectionCode, partsPosCodeUWork.CustomerCode, partsPosCodeUWork.SearchPartsPosCode, int.Parse(partsParaWork.BeforeBlCd), out maxPosDispOrder, out partsPosCodeUList, ref sqlConnection, ref sqlTransaction);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ���ʃ}�X�^�ɐV�K���R�[�h��ǉ�����B
                                status = this.PartsPosCodeInsertProc(enterpriseCode, maxPosDispOrder + 1, int.Parse(partsParaWork.AfterBlCd), partsPosCodeUWork, updateWork, ref sqlConnection, ref sqlTransaction);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    resultListWork = new ResultListWork();
                                    resultListWork.TableName = "����Ͻ�";
                                    resultListWork.Status = "�ϊ�";
                                    if (string.IsNullOrEmpty(partsPosCodeUWork.SectionCode.Trim()))
                                    {
                                        resultListWork.Key = "���_:00 ���Ӑ�:" + partsPosCodeUWork.CustomerCode.ToString("00000000")
                                                            + " ����:" + partsPosCodeUWork.SearchPartsPosCode.ToString("00") + " BL:" + partsParaWork.BeforeBlCd;
                                    }
                                    else
                                    {
                                        resultListWork.Key = "���_:" + partsPosCodeUWork.SectionCode + " ���Ӑ�:" + partsPosCodeUWork.CustomerCode.ToString("00000000")
                                                            + " ����:" + partsPosCodeUWork.SearchPartsPosCode.ToString("00") + " BL:" + partsParaWork.BeforeBlCd;
                                    }
                                    resultListWork.Content = "���ʂւ̒ǉ�BL����:" + partsParaWork.AfterBlCd;
                                    retList.Add(resultListWork);
                                }
                                else
                                {
                                    return status;
                                }
                            }
                            else
                            {
                                return status;
                            }
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �Y�����R�[�h���L�鎞�A���������A���̃��R�[�h�ɐi�ށB
                            continue;
                        }
                        else
                        {
                            return status;
                        }
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    continue;
                }
                else
                {
                    return status;
                }
            }
            return status;
        }

        #region ���ʃ}�X�^��������
        /// <summary>
        /// ���ʃ}�X�^��������(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="mode">�����敪</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="searchPartsPosCode">�������ʃR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="maxPosDispOrder">�������ʕ\������</param>
        /// <param name="partsPosCodeList">���ʃ}�X�^���X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/03 ���M Redmine#2783�̑Ή�</br>
        private int PartsPosCodeSearchProc(Int32 mode, string enterpriseCode, string sectionCode, Int32 customerCode, Int32 searchPartsPosCode, Int32 tbsPartsCode, out Int32 maxPosDispOrder, out ArrayList partsPosCodeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            partsPosCodeList = new ArrayList();
            maxPosDispOrder = 0;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                if (mode == 1)
                {
                    #region �ϊ��O�a�k�R�[�h�Ƃa�k�R�[�h����v���郌�R�[�h��S�����o����B
                    // �ϊ��O�a�k�R�[�h�Ƃa�k�R�[�h����v���郌�R�[�h��S�����o����B
                    // --- UPD 2010/02/03 ---------->>>>>
                    //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, SEARCHPARTSPOSCODERF, SEARCHPARTSPOSNAMERF, POSDISPORDERRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, OFFERDATERF, OFFERDATADIVRF FROM PARTSPOSCODEURF WHERE TBSPARTSCODERF=@FINDTBSPARTSCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                    sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, SEARCHPARTSPOSCODERF, SEARCHPARTSPOSNAMERF, POSDISPORDERRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, OFFERDATERF, OFFERDATADIVRF FROM PARTSPOSCODEURF WHERE TBSPARTSCODERF=@FINDTBSPARTSCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    // --- UPD 2010/02/03 ----------<<<<<

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // --- DEL 2010/02/03 ---------->>>>>
                    //SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    // --- DEL 2010/02/03 ----------<<<<<
                    SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    // --- DEL 2010/02/03 ---------->>>>>
                    //findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    // --- DEL 2010/02/03 ----------<<<<<
                    findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCode);

                    // ����}�X�^�f�[�^�pSQL
                    sqlCommand.CommandText = sqlStr;
                    // �ǂݍ���
                    myReader = sqlCommand.ExecuteReader();

                    PartsPosCodeUWork partsPosCodeUWork = null;

                    while (myReader.Read())
                    {
                        partsPosCodeUWork = new PartsPosCodeUWork();
                        partsPosCodeUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        partsPosCodeUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        partsPosCodeUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        partsPosCodeUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        partsPosCodeUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        partsPosCodeUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        partsPosCodeUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        partsPosCodeUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        partsPosCodeUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                        partsPosCodeUWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        partsPosCodeUWork.SearchPartsPosCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPARTSPOSCODERF"));
                        partsPosCodeUWork.SearchPartsPosName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSPOSNAMERF"));
                        partsPosCodeUWork.PosDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSDISPORDERRF"));
                        partsPosCodeUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                        partsPosCodeUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                        partsPosCodeUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        partsPosCodeUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                        partsPosCodeList.Add(partsPosCodeUWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion

                }
                else if (mode == 2)
                {
                    #region ���o�����e���R�[�h��莟�̃L�[�l���擾���āA���ʃ}�X�^�ɊY�����R�[�h���������`�F�b�N����B
                    // ���o�����e���R�[�h��莟�̃L�[�l���擾���āA���ʃ}�X�^�ɊY�����R�[�h���������`�F�b�N����B
                    sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, SEARCHPARTSPOSCODERF, SEARCHPARTSPOSNAMERF, POSDISPORDERRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, OFFERDATERF, OFFERDATADIVRF FROM PARTSPOSCODEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE AND TBSPARTSCODERF=@FINDTBSPARTSCODE";

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                    SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    if (!string.IsNullOrEmpty(sectionCode.Trim()))
                    {
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                    }
                    else
                    {
                        findParaSectionCode.Value = string.Empty;
                    }
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                    findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(searchPartsPosCode);
                    findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCode);

                    // ����}�X�^�f�[�^�pSQL
                    sqlCommand.CommandText = sqlStr;
                    // �ǂݍ���
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion
                }
                else if (mode == 3)
                {
                    #region ��ƃR�[�h�E���_�R�[�h�E���Ӑ�R�[�h�E�������ʃR�[�h������̃��R�[�h�̌������ʕ\�����ʂ̍ő�l�̎擾
                    // ��ƃR�[�h�E���_�R�[�h�E���Ӑ�R�[�h�E�������ʃR�[�h������̃��R�[�h�̌������ʕ\�����ʂ̍ő�l�̎擾
                    sqlStr = "SELECT MAX(POSDISPORDERRF) MAXPOSDISPORDERRF FROM PARTSPOSCODEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE";

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    if (!string.IsNullOrEmpty(sectionCode.Trim()))
                    {
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                    }
                    else
                    {
                        findParaSectionCode.Value = string.Empty;
                    }
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                    findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(searchPartsPosCode);

                    // ����}�X�^�f�[�^�pSQL
                    sqlCommand.CommandText = sqlStr;
                    // �ǂݍ���
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        maxPosDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAXPOSDISPORDERRF"));
                    }
                    else
                    {
                        maxPosDispOrder = 0;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    #endregion
                }
                else
                {
                    // mode�s���ł��B
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.PartsPosCodeSearchProc Exception=" + ex.Message);
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
        #endregion

        #region ���ʃ}�X�^�o�^����
        /// <summary>
        /// ���ʃ}�X�^�o�^����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="posDispOrder">�������ʕ\������</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="partsPosCodeUWork">���ʃ}�X�^���[�N</param>
        /// <param name="updateWork">�X�V�w�[�_���</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�o�^����(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/01/12</br>
        private int PartsPosCodeInsertProc(string enterpriseCode, Int32 posDispOrder, Int32 tbsPartsCode, PartsPosCodeUWork partsPosCodeUWork, PartsPosCodeUWork updateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "INSERT INTO PARTSPOSCODEURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CUSTOMERCODERF, SEARCHPARTSPOSCODERF, SEARCHPARTSPOSNAMERF, POSDISPORDERRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CUSTOMERCODE, @SEARCHPARTSPOSCODE, @SEARCHPARTSPOSNAME, @POSDISPORDER, @TBSPARTSCODE, @TBSPARTSCDDERIVEDNO, @OFFERDATE, @OFFERDATADIV)";

                //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSearchPartsPosCode = sqlCommand.Parameters.Add("@SEARCHPARTSPOSCODE", SqlDbType.Int);
                SqlParameter paraSearchPartsPosName = sqlCommand.Parameters.Add("@SEARCHPARTSPOSNAME", SqlDbType.NVarChar);
                SqlParameter paraPosDispOrder = sqlCommand.Parameters.Add("@POSDISPORDER", SqlDbType.Int);
                SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updateWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(updateWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(updateWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateWork.LogicalDeleteCode);
                if (!string.IsNullOrEmpty(partsPosCodeUWork.SectionCode.Trim()))
                {
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.SectionCode);
                }
                else
                {
                    paraSectionCode.Value = string.Empty;
                }

                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                paraSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                paraSearchPartsPosName.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.SearchPartsPosName);
                paraPosDispOrder.Value = SqlDataMediator.SqlSetInt32(posDispOrder);
                paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(tbsPartsCode);
                paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(0);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsPosCodeUWork.OfferDate);
                paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.OfferDataDiv);

                // ���ʃ}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.PartsPosCodeInsertProc Exception=" + ex.Message);
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
        #endregion

        #endregion ���ʃ}�X�^�X�V����

        #region �D�ǐݒ�}�X�^�X�V����
        /// <summary>
        /// �D�ǐݒ�}�X�^�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="excellentSetAList">�D�ǐݒ�p�����[�^���X�g�`</param>
        /// <param name="excellentSetBList">�D�ǐݒ�p�����[�^���X�g�a</param>
        /// <param name="excellentSetCList">�D�ǐݒ�p�����[�^���X�g�b</param>
        /// <param name="retList">retList�b</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <param name="sqlConnection_read">sql�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�}�X�^�X�V����(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/26 杍^ redmine#2628�Ή�</br>
        /// <br>Update Note: 2010/02/02 ���M redmine#2742�Ή�</br>
        /// <br>Update Note: 2010/02/03 ���M Redmine#2783�̑Ή�</br>
        /// </remarks>
        private int PrmSettingUpdateProc(string enterpriseCode, ArrayList excellentSetAList, ArrayList excellentSetBList, ArrayList excellentSetCList, ref ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlConnection sqlConnection_read)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (excellentSetAList.Count == 0 && excellentSetBList.Count == 0 && excellentSetCList.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList al = new ArrayList();
            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();

            #region DataSet����\�z����
            DataTable prmSettingTable = new DataTable();
            prmSettingTable.Columns.Add(COL_NM_CreateDateTime, typeof(DateTime));
            prmSettingTable.Columns.Add(COL_NM_UpdateDateTime, typeof(DateTime));
            prmSettingTable.Columns.Add(COL_NM_EnterpriseCode, typeof(string));
            prmSettingTable.Columns.Add(COL_NM_FileHeaderGuid, typeof(Guid));
            prmSettingTable.Columns.Add(COL_NM_UpdEmployeeCode, typeof(string));
            prmSettingTable.Columns.Add(COL_NM_UpdAssemblyId1, typeof(string));
            prmSettingTable.Columns.Add(COL_NM_UpdAssemblyId2, typeof(string));
            prmSettingTable.Columns.Add(COL_NM_LogicalDeleteCode, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_SectionCode, typeof(string));

            prmSettingTable.Columns.Add(COL_NM_GoodsMGroup, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_TbsPartsCode, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_TbsPartsCdDerivedNo, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_MakerDispOrder, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_PartsMakerCd, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_PrimeDispOrder, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_PrmSetDtlNo1, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_PrmSetDtlName1, typeof(string));
            prmSettingTable.Columns.Add(COL_NM_PrmSetDtlNo2, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_PrmSetDtlName2, typeof(string));
            prmSettingTable.Columns.Add(COL_NM_PrimeDisplayCode, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_OfferDate, typeof(int));

            prmSettingTable.Columns.Add(COL_NM_BfTbsPartsCode, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_BfPrmSetDtlNo1, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_BfPrmSetDtlNo2, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_ChangeFlag, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_SortChangeFlag, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_ObjectFlag, typeof(int));
            // --- ADD 2010/02/03 ---------->>>>>
            prmSettingTable.Columns.Add(COL_NM_BfMakerDispOrder, typeof(int));
            prmSettingTable.Columns.Add(COL_NM_BfPrimeDispOrder, typeof(int));
            // --- ADD 2010/02/03 ----------<<<<<
            #endregion

            #region �D�ǐݒ�}�X�^(PRMSETTINGURF)�̓��e��S��
            try
            {
                SqlTransaction sqlTransactionSelect = null;
                PrmSettingUWork prmSettingUWork = new PrmSettingUWork();
                prmSettingUWork.EnterpriseCode = enterpriseCode;
                prmSettingUWork.PrimeDisplayCode = -1;

                // --- UPD 2010/02/03 ---------->>>>>
                //status = prmSettingUDB.Search(ref al, prmSettingUWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection_read, ref sqlTransactionSelect);
                status = prmSettingUDB.Search(ref al, prmSettingUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection_read, ref sqlTransactionSelect);
                // --- UPD 2010/02/03 ----------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            #endregion

            foreach (PrmSettingUWork prmSetting in al)
            {
                #region �W�J����
                DataRow dataRow = prmSettingTable.NewRow();
                dataRow[COL_NM_CreateDateTime] = prmSetting.CreateDateTime;
                dataRow[COL_NM_UpdateDateTime] = prmSetting.UpdateDateTime;
                dataRow[COL_NM_EnterpriseCode] = prmSetting.EnterpriseCode;
                dataRow[COL_NM_FileHeaderGuid] = prmSetting.FileHeaderGuid;
                dataRow[COL_NM_UpdEmployeeCode] = prmSetting.UpdEmployeeCode;
                dataRow[COL_NM_UpdAssemblyId1] = prmSetting.UpdAssemblyId1;
                dataRow[COL_NM_UpdAssemblyId2] = prmSetting.UpdAssemblyId2;
                dataRow[COL_NM_LogicalDeleteCode] = prmSetting.LogicalDeleteCode;
                dataRow[COL_NM_SectionCode] = prmSetting.SectionCode;

                dataRow[COL_NM_GoodsMGroup] = prmSetting.GoodsMGroup;
                dataRow[COL_NM_TbsPartsCode] = prmSetting.TbsPartsCode;
                dataRow[COL_NM_TbsPartsCdDerivedNo] = prmSetting.TbsPartsCdDerivedNo;
                dataRow[COL_NM_MakerDispOrder] = prmSetting.MakerDispOrder;
                dataRow[COL_NM_PartsMakerCd] = prmSetting.PartsMakerCd;
                dataRow[COL_NM_PrimeDispOrder] = prmSetting.PrimeDispOrder;
                dataRow[COL_NM_PrmSetDtlNo1] = prmSetting.PrmSetDtlNo1;
                dataRow[COL_NM_PrmSetDtlName1] = prmSetting.PrmSetDtlName1;
                dataRow[COL_NM_PrmSetDtlNo2] = prmSetting.PrmSetDtlNo2;
                dataRow[COL_NM_PrmSetDtlName2] = prmSetting.PrmSetDtlName2;
                dataRow[COL_NM_PrimeDisplayCode] = prmSetting.PrimeDisplayCode;
                dataRow[COL_NM_OfferDate] = prmSetting.OfferDate;
                dataRow[COL_NM_BfTbsPartsCode] = prmSetting.TbsPartsCode;
                dataRow[COL_NM_BfPrmSetDtlNo1] = prmSetting.PrmSetDtlNo1;
                dataRow[COL_NM_BfPrmSetDtlNo2] = prmSetting.PrmSetDtlNo2;
                dataRow[COL_NM_ChangeFlag] = 0;
                dataRow[COL_NM_SortChangeFlag] = 0;
                dataRow[COL_NM_ObjectFlag] = 1;
                // --- ADD 2010/02/03 ---------->>>>>
                dataRow[COL_NM_BfMakerDispOrder] = prmSetting.MakerDispOrder;
                dataRow[COL_NM_BfPrimeDispOrder] = prmSetting.PrimeDispOrder;
                // --- ADD 2010/02/03 ----------<<<<<

                prmSettingTable.Rows.Add(dataRow);

                #endregion
            }

            //�D�ǐݒ�p�����[�^�`�̏���
            #region �D�ǐݒ�p�����[�^�`�̏���
            foreach (ExcellentSetParaAWork excellentSetParaAWork in excellentSetAList)
            {
                DataRow[] rows = prmSettingTable.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                    prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName, excellentSetParaAWork.MakerCd,
                    prmSettingTable.Columns[COL_NM_BfTbsPartsCode].ColumnName, excellentSetParaAWork.BeforeBlCd,
                    prmSettingTable.Columns[COL_NM_BfPrmSetDtlNo1].ColumnName, excellentSetParaAWork.BeforeSelectCd));

                foreach (DataRow row in rows)
                {
                    row[COL_NM_TbsPartsCode] = excellentSetParaAWork.AfterBlCd;
                    row[COL_NM_ChangeFlag] = 1;
                }
            }
            #endregion

            //�D�ǐݒ�p�����[�^�a�̏���
            #region �D�ǐݒ�p�����[�^�a�̏���
            foreach (ExcellentSetParaBWork excellentSetParaBWork in excellentSetBList)
            {
                DataRow[] rows = prmSettingTable.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                    prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName, excellentSetParaBWork.MakerCd,
                    // --- UPD 2010/01/26 -------------->>>>
                    //prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName, excellentSetParaBWork.BeforeBlCd,
                    //prmSettingTable.Columns[COL_NM_PrmSetDtlNo1].ColumnName, excellentSetParaBWork.BeforeSelectCd));
                    prmSettingTable.Columns[COL_NM_BfTbsPartsCode].ColumnName, excellentSetParaBWork.BeforeBlCd,
                    prmSettingTable.Columns[COL_NM_BfPrmSetDtlNo1].ColumnName, excellentSetParaBWork.BeforeSelectCd));
                    // --- UPD 2010/01/26 --------------<<<<

                foreach (DataRow row in rows)
                {
                    row[COL_NM_PrmSetDtlNo1] = excellentSetParaBWork.AfterSelectCd;
                    row[COL_NM_ChangeFlag] = 1;
                }
            }
            #endregion

            //�D�ǐݒ�p�����[�^�b�̏���
            #region �D�ǐݒ�p�����[�^�b�̏���
            foreach (ExcellentSetParaCWork excellentSetParaCWork in excellentSetCList)
            {
                DataRow[] rows = prmSettingTable.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7}",
                    prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName, excellentSetParaCWork.MakerCd,
                    // --- UPD 2010/01/26 -------------->>>>
                    //prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName, excellentSetParaCWork.BeforeBlCd,
                    //prmSettingTable.Columns[COL_NM_PrmSetDtlNo1].ColumnName, excellentSetParaCWork.BeforeSelectCd,
                    //prmSettingTable.Columns[COL_NM_PrmSetDtlNo2].ColumnName, excellentSetParaCWork.BeforeKindCd));
                    prmSettingTable.Columns[COL_NM_BfTbsPartsCode].ColumnName, excellentSetParaCWork.BeforeBlCd,
                    prmSettingTable.Columns[COL_NM_BfPrmSetDtlNo1].ColumnName, excellentSetParaCWork.BeforeSelectCd,
                    prmSettingTable.Columns[COL_NM_BfPrmSetDtlNo2].ColumnName, excellentSetParaCWork.BeforeKindCd));
                    // --- UPD 2010/01/26 --------------<<<<

                foreach (DataRow row in rows)
                {
                    row[COL_NM_PrmSetDtlNo2] = excellentSetParaCWork.AfterKindCd;
                    row[COL_NM_ChangeFlag] = 1;
                }
            }
            #endregion

            //�Ώۃt���O�̍X�V
            #region �Ώۃt���O�̍X�V
            foreach (DataRow row in prmSettingTable.Rows)
            {
                DataView prmSettingView = new DataView(prmSettingTable);
                prmSettingView.Sort = this.MakeprmSettingSort(prmSettingTable);
                prmSettingView.RowFilter = KeyofDicPrmSetting(prmSettingTable, row);
                if (prmSettingView.Count > 0)
                {
                    //�Y������DataView��̐擪�s�Ǝ��̓��e���P�ł��قȂ�ꍇ�́u�Ώۃt���O�v��"0"���Z�b�g����
                    if (((int)prmSettingView[0][COL_NM_BfTbsPartsCode] != (int)row[COL_NM_BfTbsPartsCode])
                    || ((int)prmSettingView[0][COL_NM_BfPrmSetDtlNo1] != (int)row[COL_NM_BfPrmSetDtlNo1])
                    || ((int)prmSettingView[0][COL_NM_BfPrmSetDtlNo2] != (int)row[COL_NM_BfPrmSetDtlNo2]))
                    {
                        row[COL_NM_ObjectFlag] = 0;
                        row[COL_NM_ChangeFlag] = 1;
                    }
                }
            }
            #endregion

            //�\�����̍X�V
            #region �\�����̍X�V
            int indexReflash = 1;
            int bFmakeCode = -1;
            string Key = string.Empty;
            DataView prmSettingObjectView = new DataView(prmSettingTable);

            //-----------------------------------------------------------------------------
            // �\�[�g���w��
            //-----------------------------------------------------------------------------
            prmSettingObjectView.Sort = this.MakeprmSettingObjectSort(prmSettingTable);

            Dictionary<String, DataRowView> dicObject = new Dictionary<string, DataRowView>();
            foreach (DataRowView rowView in prmSettingObjectView)
            {
                Key = rowView[COL_NM_SectionCode].ToString() + "." +
                    rowView[COL_NM_GoodsMGroup].ToString() + "." +
                    rowView[COL_NM_TbsPartsCode].ToString();

                if (!dicObject.ContainsKey(Key))
                {
                    // --- UPD 2010/02/02 -------------->>>
                    //bFmakeCode = -1;
                    //indexReflash = 1;
                    //dicObject.Add(Key, rowView);

                    //DataRow[] drs = prmSettingObjectView.Table.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                    //prmSettingTable.Columns[COL_NM_SectionCode].ColumnName, rowView[COL_NM_SectionCode],
                    //prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName, rowView[COL_NM_GoodsMGroup],
                    //prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName, rowView[COL_NM_TbsPartsCode]));

                    //���[�J�[�\����
                    //foreach (DataRow dr in drs)
                    //{
                    //    if ((int)dr[COL_NM_PartsMakerCd] != bFmakeCode)
                    //    {
                    //        if ((int)dr[COL_NM_MakerDispOrder] != indexReflash)
                    //        {
                    //            dr[COL_NM_MakerDispOrder] = indexReflash;
                    //            dr[COL_NM_ChangeFlag] = 1;
                    //            dr[COL_NM_SortChangeFlag] = 1;
                    //            indexReflash++;
                    //        }
                    //        bFmakeCode = (int)dr[COL_NM_PartsMakerCd];
                    //    }
                    //    else
                    //    {
                    //        if ((int)dr[COL_NM_MakerDispOrder] != indexReflash)
                    //        {
                    //            dr[COL_NM_MakerDispOrder] = indexReflash;
                    //            dr[COL_NM_ChangeFlag] = 1;
                    //            dr[COL_NM_SortChangeFlag] = 1;
                    //        }
                    //        else
                    //        {
                    //            indexReflash++;
                    //        }
                    //    }
                    //}
                    indexReflash = 0;
                    dicObject.Add(Key, rowView);
                    Dictionary<int, int> goodsMakerKey = new Dictionary<int, int>();

                    DataRow[] drs = prmSettingObjectView.Table.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                    prmSettingTable.Columns[COL_NM_SectionCode].ColumnName, rowView[COL_NM_SectionCode],
                    prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName, rowView[COL_NM_GoodsMGroup],
                    prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName, rowView[COL_NM_TbsPartsCode]));

                    //���[�J�[�\����
                    foreach (DataRow dr in drs)
                    {
                        if (!goodsMakerKey.ContainsKey((int)dr[COL_NM_PartsMakerCd]))
                        {
                            goodsMakerKey.Add((int)dr[COL_NM_PartsMakerCd], ++indexReflash);

                            if ((int)dr[COL_NM_MakerDispOrder] != indexReflash)
                            {
                                dr[COL_NM_MakerDispOrder] = indexReflash;
                                dr[COL_NM_ChangeFlag] = 1;
                                dr[COL_NM_SortChangeFlag] = 1;
                            }
                        }
                        else
                        {
                            if (goodsMakerKey[(int)dr[COL_NM_PartsMakerCd]] != (int)dr[COL_NM_MakerDispOrder])
                            {
                                dr[COL_NM_MakerDispOrder] = goodsMakerKey[(int)dr[COL_NM_PartsMakerCd]];
                                dr[COL_NM_ChangeFlag] = 1;
                                dr[COL_NM_SortChangeFlag] = 1;
                            }
                        }
                    }
                    // --- UPD 2010/02/02 --------------<<<
                }
            }

            //-----------------------------------------------------------------------------
            // �\�[�g���w��
            //-----------------------------------------------------------------------------
            // --- UPD 2010/02/02 -------------->>>
            //prmSettingObjectView.Sort = this.MakeprmSettingObjectSort(prmSettingTable);
            // --- DEL 2010/02/03 ---------->>>>>
            //prmSettingObjectView.Sort = string.Format("{0},{1},{2},{3},{4}",
            //    prmSettingTable.Columns[COL_NM_SectionCode].ColumnName,
            //    prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName,
            //    prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName,
            //    prmSettingTable.Columns[COL_NM_MakerDispOrder].ColumnName,
            //    prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName);
            // --- DEL 2010/02/03 ----------<<<<<
            // --- UPD 2010/02/02 --------------<<<

            // --- ADD 2010/02/03 ---------->>>>>
            prmSettingObjectView.Sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                prmSettingTable.Columns[COL_NM_SectionCode].ColumnName,
                prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName,
                prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName,
                prmSettingTable.Columns[COL_NM_MakerDispOrder].ColumnName,
                prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName,
                prmSettingTable.Columns[COL_NM_BfMakerDispOrder].ColumnName,
                prmSettingTable.Columns[COL_NM_BfPrimeDispOrder].ColumnName,
                prmSettingTable.Columns[COL_NM_PrmSetDtlNo2].ColumnName);
            // --- ADD 2010/02/03 ----------<<<<<

            dicObject.Clear();

            foreach (DataRowView rowView in prmSettingObjectView)
            {
                Key = rowView[COL_NM_SectionCode].ToString() + "." +
                    rowView[COL_NM_GoodsMGroup].ToString() + "." +
                    rowView[COL_NM_TbsPartsCode].ToString();

                if (!dicObject.ContainsKey(Key))
                {
                    bFmakeCode = -1;
                    indexReflash = 1;
                    dicObject.Add(Key, rowView);

                    DataRow[] drs = prmSettingObjectView.Table.Select(string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                    prmSettingTable.Columns[COL_NM_SectionCode].ColumnName, rowView[COL_NM_SectionCode],
                    prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName, rowView[COL_NM_GoodsMGroup],
                    prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName, rowView[COL_NM_TbsPartsCode]));

                    //�D�Ǖ\����
                    bFmakeCode = -1;
                    indexReflash = 1;
                    foreach (DataRow dr in drs)
                    {
                        if ((int)dr[COL_NM_PartsMakerCd] == bFmakeCode)
                        {
                            if ((int)dr[COL_NM_PrimeDispOrder] != indexReflash)
                            {
                                dr[COL_NM_PrimeDispOrder] = indexReflash;
                                dr[COL_NM_ChangeFlag] = 1;
                                dr[COL_NM_SortChangeFlag] = 1;
                            }
                            indexReflash++;
                        }
                        else
                        {
                            indexReflash = 1;
                            if ((int)dr[COL_NM_PrimeDispOrder] != indexReflash)
                            {
                                dr[COL_NM_PrimeDispOrder] = indexReflash;
                                dr[COL_NM_ChangeFlag] = 1;
                                dr[COL_NM_SortChangeFlag] = 1;
                            }
                            bFmakeCode = (int)dr[COL_NM_PartsMakerCd];
                            indexReflash++;
                        }
                    }
                }
            }
            #endregion

            //�D�ǐݒ�}�X�^�X�V PMKEN09032R
            ArrayList delList = new ArrayList();
            ArrayList updList = new ArrayList();

            foreach (DataRow row in prmSettingObjectView.Table.Rows)
            {
                if ((int)row[COL_NM_ChangeFlag] != 0)
                {
                    PrmSettingUWork prmSettingUWork = new PrmSettingUWork();
                    prmSettingUWork.EnterpriseCode = row[COL_NM_EnterpriseCode].ToString();
                    prmSettingUWork.UpdateDateTime = (DateTime)row[COL_NM_UpdateDateTime];
                    prmSettingUWork.SectionCode = row[COL_NM_SectionCode].ToString();
                    prmSettingUWork.GoodsMGroup = (int)row[COL_NM_GoodsMGroup];
                    prmSettingUWork.TbsPartsCode = (int)row[COL_NM_BfTbsPartsCode];
                    prmSettingUWork.PartsMakerCd = (int)row[COL_NM_PartsMakerCd];
                    prmSettingUWork.PrmSetDtlNo1 = (int)row[COL_NM_BfPrmSetDtlNo1];
                    prmSettingUWork.PrmSetDtlNo2 = (int)row[COL_NM_BfPrmSetDtlNo2];

                    delList.Add(prmSettingUWork);

                    ResultListWork resultListWork = new ResultListWork();
                    ResultListWork resultListWorkNew = new ResultListWork();

                    //�Ώۃt���O��0�̏ꍇ
                    if ((int)row[COL_NM_ObjectFlag] == 0)
                    {
                        resultListWork.TableName = "�D�ǐݒ�Ͻ�";
                        resultListWork.Status = "�d��";
                        resultListWork.Key = SetPrmSettingkeyString(row);
                        resultListWork.Content = SetPrmSettingContentString(row, (int)row[COL_NM_ObjectFlag]);

                        retList.Add(resultListWork); // ADD 2010/02/03
                    }
                    else
                    {
                        resultListWork.TableName = "�D�ǐݒ�Ͻ�";
                        resultListWork.Status = "�ϊ�";
                        resultListWork.Key = SetPrmSettingkeyString(row);
                        resultListWork.Content = SetPrmSettingContentString(row, (int)row[COL_NM_ObjectFlag]);


                        PrmSettingUWork prmSettingUWorkUpd = new PrmSettingUWork();

                        #region �W�J����
                        prmSettingUWorkUpd.SectionCode = row[COL_NM_SectionCode].ToString();

                        prmSettingUWorkUpd.GoodsMGroup = (int)row[COL_NM_GoodsMGroup];
                        prmSettingUWorkUpd.TbsPartsCode = (int)row[COL_NM_TbsPartsCode];
                        prmSettingUWorkUpd.TbsPartsCdDerivedNo = (int)row[COL_NM_TbsPartsCdDerivedNo];
                        prmSettingUWorkUpd.MakerDispOrder = (int)row[COL_NM_MakerDispOrder];
                        prmSettingUWorkUpd.PartsMakerCd = (int)row[COL_NM_PartsMakerCd];
                        prmSettingUWorkUpd.PrimeDispOrder = (int)row[COL_NM_PrimeDispOrder];
                        prmSettingUWorkUpd.PrmSetDtlNo1 = (int)row[COL_NM_PrmSetDtlNo1];
                        prmSettingUWorkUpd.PrmSetDtlName1 = row[COL_NM_PrmSetDtlName1].ToString();
                        prmSettingUWorkUpd.PrmSetDtlNo2 = (int)row[COL_NM_PrmSetDtlNo2];
                        prmSettingUWorkUpd.PrmSetDtlName2 = row[COL_NM_PrmSetDtlName2].ToString();
                        prmSettingUWorkUpd.PrimeDisplayCode = (int)row[COL_NM_PrimeDisplayCode];
                        prmSettingUWorkUpd.OfferDate = (int)row[COL_NM_OfferDate];
                        // --- ADD 2010/02/05 -------------->>>
                        prmSettingUWorkUpd.LogicalDeleteCode = (int)row[COL_NM_LogicalDeleteCode];
                        // --- ADD 2010/02/05 --------------<<<
                        #endregion

                        updList.Add(prmSettingUWorkUpd);

                        // --- ADD 2010/02/03 ---------->>>>>
                        if ((int)row[COL_NM_TbsPartsCode] != (int)row[COL_NM_BfTbsPartsCode]
                            || (int)row[COL_NM_PrmSetDtlNo1] != (int)row[COL_NM_BfPrmSetDtlNo1]
                            || (int)row[COL_NM_PrmSetDtlNo2] != (int)row[COL_NM_BfPrmSetDtlNo2])
                        {
                            retList.Add(resultListWork);
                        }
                        // --- ADD 2010/02/03 ----------<<<<<
                    }

                    // retList.Add(resultListWork); DEL 2010/02/03

                    if ((int)row[COL_NM_SortChangeFlag] != 0 && (int)row[COL_NM_ObjectFlag] != 0)
                    {
                        resultListWorkNew.TableName = "�D�ǐݒ�Ͻ�";
                        resultListWorkNew.Status = "�ϊ�";
                        resultListWorkNew.Key = SetPrmSettingkeyString(row);
                        resultListWorkNew.Content = "�\������Ұ�����ɕύX���܂��B";
                        retList.Add(resultListWorkNew);
                    }
                }
            }

            try
            {
                if (delList.Count > 0)
                {
                    status = prmSettingUDB.Delete(delList, ref sqlConnection, ref sqlTransaction);
                }
                if (updList.Count > 0)
                {
                    status = WritePrmSettingUProc(ref updList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�ǉ��E�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        private int WritePrmSettingUProc(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            int logicalDeleteCode = 0;// ADD 2010/02/05

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                        sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                        sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                        sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                        sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                        sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                        sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                        sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                        sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                        sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                        sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += "    ,@GOODSMGROUP" + Environment.NewLine;
                        sqlText += "    ,@TBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                        sqlText += "    ,@MAKERDISPORDER" + Environment.NewLine;
                        sqlText += "    ,@PARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    ,@PRIMEDISPORDER" + Environment.NewLine;
                        sqlText += "    ,@PRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    ,@PRMSETDTLNAME1" + Environment.NewLine;
                        sqlText += "    ,@PRMSETDTLNO2" + Environment.NewLine;
                        sqlText += "    ,@PRMSETDTLNAME2" + Environment.NewLine;
                        sqlText += "    ,@PRIMEDISPLAYCODE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // --- ADD 2010/02/05 -------------->>>
                        logicalDeleteCode = prmSettingUWork.LogicalDeleteCode;
                        // --- ADD 2010/02/05 --------------<<<

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)prmSettingUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        // --- ADD 2010/02/05 -------------->>>
                        prmSettingUWork.LogicalDeleteCode = logicalDeleteCode;
                        // --- ADD 2010/02/05 --------------<<<

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraMakerDispOrder = sqlCommand.Parameters.Add("@MAKERDISPORDER", SqlDbType.Int);
                        SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPrimeDispOrder = sqlCommand.Parameters.Add("@PRIMEDISPORDER", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName1 = sqlCommand.Parameters.Add("@PRMSETDTLNAME1", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPrimeDisplayCode = sqlCommand.Parameters.Add("@PRIMEDISPLAYCODE", SqlDbType.Int);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(prmSettingUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCdDerivedNo);
                        paraMakerDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.MakerDispOrder);
                        paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        paraPrimeDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDispOrder);
                        paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        paraPrmSetDtlName1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName1);
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
                        paraPrmSetDtlName2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2);
                        if (prmSettingUWork.TbsPartsCode == 0)
                        {
                            paraPrimeDisplayCode.Value = 0;
                        }
                        else
                        {
                            paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        }

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
                    }

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            prmSettingUList = al;

            return status;
        }

        /// <summary>
        /// �������e�쐬�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="flag">flag</param>
        /// <br>Note       :  �������e�쐬�̏�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string SetPrmSettingContentString(DataRow row, int flag)
        {
            string contentString = string.Empty;
            int partsMakerCd = (int)row[COL_NM_PartsMakerCd];
            int tbsPartsCode = (int)row[COL_NM_TbsPartsCode];
            int prmSetDtlNo1 = (int)row[COL_NM_PrmSetDtlNo1];
            int prmSetDtlNo2 = (int)row[COL_NM_PrmSetDtlNo2];

            if (flag == 0)
            {
                contentString = "���ɓo�^����Ă��܂��B";
                contentString += "BL���ޓ��� Ұ��:" + partsMakerCd.ToString("d4") + " BL:" + tbsPartsCode.ToString("d5");
            }
            else
            {
                contentString += "BL���ޓ��� Ұ��:" + partsMakerCd.ToString("d4") + " BL:" + 
                    tbsPartsCode.ToString("d5") + "�ڸ�:" + prmSetDtlNo1.ToString("d4") + "���:" + prmSetDtlNo2.ToString("d4");
            }


            return contentString;
        }

        /// <summary>
        /// �L�[���쐬�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <br>Note       :  �L�[���쐬�̏�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string SetPrmSettingkeyString(DataRow row)
        {
            string keyString = string.Empty;

            //���_�R�[�h
            if (!string.IsNullOrEmpty(row[COL_NM_SectionCode].ToString().Trim()))
            {
                keyString += " ���_:" + row[COL_NM_SectionCode].ToString().Trim().PadLeft(2, '0');
            }
            //���i�����ރR�[�h
            if ((int)row[COL_NM_GoodsMGroup] != 0)
            {
                keyString += " ������:" + ((int)row[COL_NM_GoodsMGroup]).ToString("d4");
            }
            //�ύX�O�a�k�R�[�h
            if ((int)row[COL_NM_BfTbsPartsCode] != 0)
            {
                keyString += " BL:" + ((int)row[COL_NM_BfTbsPartsCode]).ToString("d5");
            }
            //���[�J�[�R�[�h
            if ((int)row[COL_NM_PartsMakerCd] != 0)
            {
                keyString += " Ұ��:" + ((int)row[COL_NM_PartsMakerCd]).ToString("d4");
            }
            //�ϊ��O�Z���N�g�R�[�h�P
            if ((int)row[COL_NM_BfPrmSetDtlNo1] != 0)
            {
                keyString += " �ڸ�:" + ((int)row[COL_NM_BfPrmSetDtlNo1]).ToString("d4");
            }
            //�ϊ��O��ʃR�[�h�P
            if ((int)row[COL_NM_BfPrmSetDtlNo2] != 0)
            {
                keyString += " ���:" + ((int)row[COL_NM_BfPrmSetDtlNo2]).ToString("d4");
            }
            return keyString;
        }

        /// <summary>
        /// �f�[�^�쐬�\�[�g����������
        /// </summary>
        /// <param name="prmSettingTable"></param>
        /// <returns></returns>
        /// <br>Note       :  �\�[�g����������</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string MakeprmSettingObjectSort(DataTable prmSettingTable)
        {
            string sortString = string.Empty;
            sortString = string.Format("{0},{1},{2},{3},{4},{5},{6}",
                prmSettingTable.Columns[COL_NM_SectionCode].ColumnName,
                prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName,
                prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName,
                prmSettingTable.Columns[COL_NM_MakerDispOrder].ColumnName,
                prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName,
                prmSettingTable.Columns[COL_NM_PrimeDispOrder].ColumnName,
                prmSettingTable.Columns[COL_NM_PrmSetDtlNo2].ColumnName);
            return sortString;
        }

        /// <summary>
        /// �f�B�N�V���i���L�[
        /// </summary>
        /// <param name="prmSettingTable">prmSettingTable</param>
        /// <param name="row">row</param>
        /// <returns>dic�L�[</returns>
        /// <remarks>
        /// <br>Note       : �f�B�N�V���i���L�[�������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        /// </remarks>
        private string KeyofDicPrmSetting(DataTable prmSettingTable, DataRow row)
        {
            string rowFilterString = string.Empty;
            rowFilterString = string.Format("{0}='{1}' AND {2} = {3} AND {4} = {5} AND {6} = {7} AND {8} ={9}",
                 prmSettingTable.Columns[COL_NM_SectionCode].ColumnName, row[COL_NM_SectionCode],
                 prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName, row[COL_NM_GoodsMGroup],
                 prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName, row[COL_NM_TbsPartsCode],
                 prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName, row[COL_NM_PartsMakerCd],
                 prmSettingTable.Columns[COL_NM_PrmSetDtlNo2].ColumnName, row[COL_NM_PrmSetDtlNo2]);
            return rowFilterString;
        }

        /// <summary>
        /// �f�[�^�쐬�\�[�g����������
        /// </summary>
        /// <param name="prmSettingTable"></param>
        /// <returns></returns>
        /// <br>Note       :  �\�[�g����������</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        private string MakeprmSettingSort(DataTable prmSettingTable)
        {
            string sortString = string.Empty;
            sortString = string.Format("{0},{1},{2},{3},{4},{5},{6}",
                prmSettingTable.Columns[COL_NM_SectionCode].ColumnName,
                prmSettingTable.Columns[COL_NM_GoodsMGroup].ColumnName,
                prmSettingTable.Columns[COL_NM_TbsPartsCode].ColumnName,
                prmSettingTable.Columns[COL_NM_PartsMakerCd].ColumnName,
                prmSettingTable.Columns[COL_NM_PrmSetDtlNo2].ColumnName,
                prmSettingTable.Columns[COL_NM_ChangeFlag].ColumnName,
                prmSettingTable.Columns[COL_NM_PrmSetDtlNo1].ColumnName);
            return sortString;
        }
        #endregion �D�ǐݒ�}�X�^�X�V����

        #region ���i�Ǘ����}�X�^�X�V����
        /// <summary>
        /// ���i�Ǘ����}�X�^�X�V����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="rateBList">�|���p�����[�^���X�g�a</param>
        /// <param name="rateCList">�|���p�����[�^���X�g�b</param>
        /// <param name="retList">retList</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�X�V����(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/26 杍^ redmine#2628�Ή�</br>
        /// <br>Update Note: 2010/02/01 ������ redmine#2710�Ή�</br>
        /// </remarks>
        private int GoodsMngUpdateProc(string enterpriseCode, ArrayList rateBList, ArrayList rateCList, ref ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            if (rateBList.Count == 0 && rateCList.Count == 0) return status;
            ArrayList al = new ArrayList();
            //Remote:���i�Ǘ����}�X�^
            GoodsMngDB goodsMngDB = new GoodsMngDB();
            #region DataSet����\�z����
            DataTable goodsMngTable = new DataTable();
            goodsMngTable.Columns.Add(COL_NM_CreateDateTime, typeof(DateTime));
            goodsMngTable.Columns.Add(COL_NM_UpdateDateTime, typeof(DateTime));
            goodsMngTable.Columns.Add(COL_NM_EnterpriseCode, typeof(string));
            goodsMngTable.Columns.Add(COL_NM_FileHeaderGuid, typeof(Guid));
            goodsMngTable.Columns.Add(COL_NM_UpdEmployeeCode, typeof(string));
            goodsMngTable.Columns.Add(COL_NM_UpdAssemblyId1, typeof(string));
            goodsMngTable.Columns.Add(COL_NM_UpdAssemblyId2, typeof(string));
            goodsMngTable.Columns.Add(COL_NM_LogicalDeleteCode, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_SectionCode, typeof(string));

            goodsMngTable.Columns.Add(COL_NM_GoodsMGroup, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_GoodsMakerCd, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_BLGoodsCode, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_GoodsNo, typeof(string));
            goodsMngTable.Columns.Add(COL_NM_SupplierCd, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_SupplierLot, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_BfBLGoodsCode, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_ChangeFlag, typeof(int));
            goodsMngTable.Columns.Add(COL_NM_ObjectFlag, typeof(int));
            #endregion

            #region ���i�Ǘ����}�X�^(GoodsMngRF)�̓��e��S��
            try
            {
                // [�a�k�R�[�h���O]�ƈ�v���郌�R�[�h��S�����o����B
                status = this.GoodsMngSearchProc(enterpriseCode, out al, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            #endregion

            foreach (GoodsMngWork goodsMngWork in al)
            {
                #region �W�J����
                DataRow dataRow = goodsMngTable.NewRow();
                dataRow[COL_NM_CreateDateTime] = goodsMngWork.CreateDateTime;
                dataRow[COL_NM_UpdateDateTime] = goodsMngWork.UpdateDateTime;
                dataRow[COL_NM_EnterpriseCode] = goodsMngWork.EnterpriseCode;
                dataRow[COL_NM_FileHeaderGuid] = goodsMngWork.FileHeaderGuid;
                dataRow[COL_NM_UpdEmployeeCode] = goodsMngWork.UpdEmployeeCode;
                dataRow[COL_NM_UpdAssemblyId1] = goodsMngWork.UpdAssemblyId1;
                dataRow[COL_NM_UpdAssemblyId2] = goodsMngWork.UpdAssemblyId2;
                dataRow[COL_NM_LogicalDeleteCode] = goodsMngWork.LogicalDeleteCode;
                dataRow[COL_NM_SectionCode] = goodsMngWork.SectionCode;

                dataRow[COL_NM_GoodsMGroup] = goodsMngWork.GoodsMGroup;
                dataRow[COL_NM_GoodsMakerCd] = goodsMngWork.GoodsMakerCd;
                dataRow[COL_NM_BLGoodsCode] = goodsMngWork.BLGoodsCode;
                dataRow[COL_NM_GoodsNo] = goodsMngWork.GoodsNo;
                dataRow[COL_NM_SupplierCd] = goodsMngWork.SupplierCd;
                dataRow[COL_NM_SupplierLot] = goodsMngWork.SupplierLot;
                dataRow[COL_NM_BfBLGoodsCode] = goodsMngWork.BLGoodsCode;
                dataRow[COL_NM_ChangeFlag] = 0;
                dataRow[COL_NM_ObjectFlag] = 1;
                goodsMngTable.Rows.Add(dataRow);
                #endregion
            }

            //�|���p�����[�^�a�̏���
            #region �|���p�����[�^�a�̏���
            foreach (RateParaBWork rateParaBWork in rateBList)
            {
                //���[�J�[�R�[�h�A�ϊ��O�a�k�R�[�h���|���p�����[�^�a���X�g�Ɋ܂܂�Ă��鎞
                DataRow[] rows = goodsMngTable.Select(string.Format("{0}={1} AND {2}={3}",
                    goodsMngTable.Columns[COL_NM_GoodsMakerCd].ColumnName, Int32.Parse(rateParaBWork.MakerCd),
                    goodsMngTable.Columns[COL_NM_BfBLGoodsCode].ColumnName, Int32.Parse(rateParaBWork.BeforeBlCd)));
                foreach (DataRow row in rows)
                {
                    row[COL_NM_BLGoodsCode] = Int32.Parse(rateParaBWork.AfterBlCd);
                    row[COL_NM_ChangeFlag] = 1;
                }
            }
            #endregion

            //�|���p�����[�^�b�̏���
            #region �|���p�����[�^�b�̏���
            foreach (RateParaCWork rateParaCWork in rateCList)
            {
                DataRow[] rows = goodsMngTable.Select(string.Format("{0}={1} AND {2}={3}",
                    goodsMngTable.Columns[COL_NM_GoodsMakerCd].ColumnName, Int32.Parse(rateParaCWork.MakerCd),
                    goodsMngTable.Columns[COL_NM_BfBLGoodsCode].ColumnName, Int32.Parse(rateParaCWork.BeforeBlCd)));

                foreach (DataRow row in rows)
                {
                    ArrayList arrayList = rateParaCWork.AfterBlList;
                    for (int i = 0; i < arrayList.Count; i++)
                    {
                        DataRow dataRow = goodsMngTable.NewRow();
                        dataRow.ItemArray = row.ItemArray;
                        dataRow[COL_NM_BLGoodsCode] = Int32.Parse(arrayList[i].ToString());
                        dataRow[COL_NM_ChangeFlag] = 1;
                        goodsMngTable.Rows.Add(dataRow);
                    }
                }
            }
            #endregion

            //�Ώۃt���O�̍X�V
            #region �Ώۃt���O�̍X�V

            foreach (DataRow row in goodsMngTable.Rows)
            {
                DataView goodsMngView = new DataView(goodsMngTable);
                goodsMngView.Sort = this.MakeGoodsMngSort(goodsMngTable);
                goodsMngView.RowFilter = this.MakeGoodsMngRowFilter(goodsMngTable, row);
                if (goodsMngView.Count > 0)
                {
                    //�Y������DataView��̐擪�s�Ǝ��̓��e���P�ł��قȂ�ꍇ�́u�Ώۃt���O�v��"0"���Z�b�g����
                    if ((int)goodsMngView[0][COL_NM_BfBLGoodsCode] != (int)row[COL_NM_BfBLGoodsCode])
                    {
                        row[COL_NM_ObjectFlag] = 0;
                    }
                }
            }
            #endregion

            //���i�Ǘ����}�X�^�X�V
            #region ���i�Ǘ����}�X�^�X�V
            ArrayList delList = new ArrayList();
            ArrayList updList = new ArrayList();

            foreach (DataRow row in goodsMngTable.Rows)
            {
                if ((int)row[COL_NM_ChangeFlag] != 0)
                {
                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    goodsMngWork.CreateDateTime = (DateTime)row[COL_NM_CreateDateTime];
                    goodsMngWork.UpdateDateTime = (DateTime)row[COL_NM_UpdateDateTime];
                    goodsMngWork.EnterpriseCode = row[COL_NM_EnterpriseCode].ToString();
                    goodsMngWork.FileHeaderGuid = (Guid)row[COL_NM_FileHeaderGuid];
                    goodsMngWork.UpdEmployeeCode = row[COL_NM_UpdEmployeeCode].ToString();
                    goodsMngWork.UpdAssemblyId1 = row[COL_NM_UpdAssemblyId1].ToString();
                    goodsMngWork.UpdAssemblyId2 = row[COL_NM_UpdAssemblyId2].ToString();
                    goodsMngWork.LogicalDeleteCode = (int)row[COL_NM_LogicalDeleteCode];
                    goodsMngWork.SectionCode = row[COL_NM_SectionCode].ToString();
                    goodsMngWork.GoodsMakerCd = (int)row[COL_NM_GoodsMakerCd];
                    goodsMngWork.GoodsNo = row[COL_NM_GoodsNo].ToString();
                    goodsMngWork.GoodsMGroup = (int)row[COL_NM_GoodsMGroup];
                    goodsMngWork.BLGoodsCode = (int)row[COL_NM_BfBLGoodsCode];
                    goodsMngWork.SupplierCd = (int)row[COL_NM_SupplierCd];
                    goodsMngWork.SupplierLot = (int)row[COL_NM_SupplierLot];
                    delList.Add(goodsMngWork);

                    ResultListWork resultListWork = new ResultListWork();

                    //�Ώۃt���O��0�̏ꍇ
                    if ((int)row[COL_NM_ObjectFlag] == 0)
                    {
                        resultListWork.TableName = "���i�Ǘ����Ͻ�";
                        resultListWork.Status = "�d��";
                        resultListWork.Key = SetGoodsMngkeyString(row);
                        resultListWork.Content = SetGoodsMngContentString(row, (int)row[COL_NM_ObjectFlag]);
                    }
                    //�Ώۃt���O��0�̏ꍇ
                    else
                    {
                        // -----------ADD 2010/02/01----------->>>>>
                        GoodsMngWork work = new GoodsMngWork();

                        #region �W�J����
                        work.SectionCode = row[COL_NM_SectionCode].ToString();
                        work.GoodsMakerCd = (int)row[COL_NM_GoodsMakerCd];
                        work.GoodsNo = row[COL_NM_GoodsNo].ToString();
                        work.BLGoodsCode = (int)row[COL_NM_BLGoodsCode];
                        work.GoodsMGroup = (int)row[COL_NM_GoodsMGroup];
                        work.SupplierCd = (int)row[COL_NM_SupplierCd];
                        work.SupplierLot = (int)row[COL_NM_SupplierLot];
                        // --- ADD 2010/02/05 -------------->>>
                        work.LogicalDeleteCode = (int)row[COL_NM_LogicalDeleteCode];
                        // --- ADD 2010/02/05 --------------<<<
                        #endregion

                        updList.Add(work);
                        //-----------ADD 2010/02/01-----------<<<<<
                        // --- ADD 2010/01/26 -------------->>>>
                        // �a�k�R�[�h���ϊ��O�a�k�R�[�h�̏ꍇ�A�������ʃ��X�g�ɓ��e��ǉ�����B
                        if ((int)row[COL_NM_BfBLGoodsCode] == (int)row[COL_NM_BLGoodsCode])
                        {
                            continue;
                        }
                        // --- ADD 2010/01/26 --------------<<<<

                        resultListWork.TableName = "���i�Ǘ����Ͻ�";
                        resultListWork.Status = "�ϊ�";
                        resultListWork.Key = SetGoodsMngkeyString(row);
                        resultListWork.Content = SetGoodsMngContentString(row, (int)row[COL_NM_ObjectFlag]);

                        // -----------DEL 2010/02/01----------->>>>>
                        //GoodsMngWork work = new GoodsMngWork();

                        //#region �W�J����
                        //work.SectionCode = row[COL_NM_SectionCode].ToString();
                        //work.GoodsMakerCd = (int)row[COL_NM_GoodsMakerCd];
                        //work.GoodsNo = row[COL_NM_GoodsNo].ToString();
                        //work.BLGoodsCode = (int)row[COL_NM_BLGoodsCode];
                        //work.GoodsMGroup = (int)row[COL_NM_GoodsMGroup];
                        //work.SupplierCd = (int)row[COL_NM_SupplierCd];
                        //work.SupplierLot = (int)row[COL_NM_SupplierLot];
                        //#endregion

                        //updList.Add(work);
                        // -----------DEL 2010/02/01-----------<<<<<
                    }

                    retList.Add(resultListWork);
                }
            }

            //Filter
            FilterGoodsMngData(ref delList, ref updList);

            try
            {
                if (delList.Count > 0)
                {
                    status = goodsMngDB.DeleteGoodsMngProc(delList, ref sqlConnection, ref sqlTransaction);
                }
                if (updList.Count > 0)
                {
                    status = WriteGoodsMngProc(updList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            #endregion ���i�Ǘ����}�X�^�X�V
            return status;
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMngList">���i�Ǘ����}�X�^���X�g</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^��������(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/03 ���M Redmine#2783�̑Ή�</br>
        private int GoodsMngSearchProc(string enterpriseCode, out ArrayList goodsMngList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            goodsMngList = new ArrayList();
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                #region [�a�k�R�[�h���O]�ƈ�v���郌�R�[�h��S�����o����B
                // [�a�k�R�[�h���O]�ƈ�v���郌�R�[�h��S�����o����B
                // --- UPD 2010/02/03 ---------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, GOODSMAKERCDRF, BLGOODSCODERF, GOODSNORF, SUPPLIERCDRF, SUPPLIERLOTRF FROM GOODSMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=0 AND BLGOODSCODERF != 0";
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, GOODSMGROUPRF, GOODSMAKERCDRF, BLGOODSCODERF, GOODSNORF, SUPPLIERCDRF, SUPPLIERLOTRF FROM GOODSMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BLGOODSCODERF != 0";
                // --- UPD 2010/02/03 ----------<<<<<

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // ���i�Ǘ����}�X�^�f�[�^�pSQL
                sqlCommand.CommandText = sqlStr;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                GoodsMngWork goodsMngWork = null;

                while (myReader.Read())
                {
                    goodsMngWork = new GoodsMngWork();
                    goodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    goodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    goodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    goodsMngList.Add(goodsMngWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataBLGoodsRateRankConvertDB.GoodsMngSearchProc Exception=" + ex.Message);
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
        /// �f�[�^�쐬Filter��������
        /// </summary>
        /// <param name="delList"></param>
        /// <param name="updList"></param>
        /// <returns></returns>
        /// <br>Note       : �f�[�^�쐬Filter��������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        private void FilterGoodsMngData(ref ArrayList delList, ref ArrayList updList)
        {
            //delete�f�[�^��Filter
            if (delList.Count > 0)
            {
                Dictionary<string, GoodsMngWork> dic = new Dictionary<string,GoodsMngWork>();
                ArrayList delArrayList = new ArrayList();
                foreach (GoodsMngWork work in delList)
                {
                    string key = work.EnterpriseCode.Trim() + "-" + work.SectionCode.Trim() + "-" +
                         work.GoodsMGroup.ToString() + "-" + work.GoodsMakerCd.ToString() + "-" + 
                         work.BLGoodsCode.ToString() + work.GoodsNo.Trim();
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, work);
                    }
                }
                foreach (string key in dic.Keys)
                {
                    delArrayList.Add(dic[key]);
                }

                delList = delArrayList;
            }
            //updata�f�[�^��Filter
            if (updList.Count > 0)
            {
                Dictionary<string, GoodsMngWork> dic = new Dictionary<string, GoodsMngWork>();
                ArrayList updArrayList = new ArrayList();
                foreach (GoodsMngWork work in updList)
                {
                    string key = work.EnterpriseCode.Trim() + "-" + work.SectionCode.Trim() + "-" +
                         work.GoodsMGroup.ToString() + "-" + work.GoodsMakerCd.ToString() + "-" +
                         work.BLGoodsCode.ToString() + work.GoodsNo.Trim();
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, work);
                    }
                }
                foreach (string key in dic.Keys)
                {
                    updArrayList.Add(dic[key]);
                }

                updList = updArrayList;
            }
        }

        /// <summary>
        /// �f�[�^�쐬�\�[�g����������
        /// </summary>
        /// <param name="goodsMngTable"></param>
        /// <returns></returns>
        /// <br>Note       : �\�[�g����������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        private string MakeGoodsMngSort(DataTable goodsMngTable)
        {
            string sortString = string.Empty;
            sortString = string.Format("{0},{1},{2},{3},{4}",
                goodsMngTable.Columns[COL_NM_SectionCode].ColumnName,
                goodsMngTable.Columns[COL_NM_GoodsMakerCd].ColumnName,
                goodsMngTable.Columns[COL_NM_GoodsMGroup].ColumnName,
                goodsMngTable.Columns[COL_NM_BLGoodsCode].ColumnName,
                goodsMngTable.Columns[COL_NM_ChangeFlag].ColumnName);
            return sortString;
        }

        /// <summary>
        /// �f�[�^�쐬RowFilter��������
        /// </summary>
        /// <param name="goodsMngTable"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        /// <br>Note       : RowFilter��������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        private string MakeGoodsMngRowFilter(DataTable goodsMngTable, DataRow row)
        {
            string rowFilterString = string.Empty;
            rowFilterString = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7}",
                 goodsMngTable.Columns[COL_NM_SectionCode].ColumnName, row[COL_NM_SectionCode],
                 goodsMngTable.Columns[COL_NM_GoodsMakerCd].ColumnName, row[COL_NM_GoodsMakerCd],
                 goodsMngTable.Columns[COL_NM_GoodsMGroup].ColumnName, row[COL_NM_GoodsMGroup],
                 goodsMngTable.Columns[COL_NM_BLGoodsCode].ColumnName, row[COL_NM_BLGoodsCode]);
            return rowFilterString;
        }

        /// <summary>
        /// �������e�쐬�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="flag">flag</param>
        /// <return>�������e</return>
        /// <remarks>
        /// <br>Note       : �������e�쐬�̏���</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/01/26 杍^ redmine#2628�Ή�</br>
        /// </remarks>
        private string SetGoodsMngContentString(DataRow row, int flag)
        {
            string contentString = string.Empty;

            if (flag == 0)
            {
                //contentString = "���ɓo�^����Ă��܂��B";              // DEL 2010/01/26
                contentString = "���ɓo�^����Ă��܂��BBL���ޕϊ� ";     // ADD 2010/01/26
            }
            else
            {
                contentString = "BL���ޕϊ� ";
            }
            //���[�J�[�R�[�h
            if ((int)row[COL_NM_GoodsMakerCd] != 0)
            {
                contentString += " Ұ��:" + ((int)row[COL_NM_GoodsMakerCd]).ToString("D4");
            }
            //�a�k�R�[�h
            if ((int)row[COL_NM_BfBLGoodsCode] != 0)
            {
                contentString += " BL:" + ((int)row[COL_NM_BLGoodsCode]).ToString("D5");
            }
            return contentString;
        }

        /// <summary>
        /// �L�[���쐬�̏���
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <return>�L�[���</return>
        /// <br>Note       : �L�[���쐬�̏�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        private string SetGoodsMngkeyString(DataRow row)
        {
            string keyString = string.Empty;

            //���_�R�[�h
            if (!string.IsNullOrEmpty(row[COL_NM_SectionCode].ToString().Trim()))
            {
                keyString += " ���_:" + row[COL_NM_SectionCode].ToString().Trim().PadLeft(2, '0');
            }
            //���[�J�[�R�[�h
            if ((int)row[COL_NM_GoodsMakerCd] != 0)
            {
                keyString += " Ұ��:" + ((int)row[COL_NM_GoodsMakerCd]).ToString("D4");
            }
            //�����ރR�[�h
            if (!string.IsNullOrEmpty(row[COL_NM_GoodsMGroup].ToString()))
            {
                keyString += " ������:" + ((int)row[COL_NM_GoodsMGroup]).ToString("D4");
            }
            //�ϊ��O�a�k�R�[�h
            if ((int)row[COL_NM_BfBLGoodsCode] != 0)
            {
                keyString += " BL:" + ((int)row[COL_NM_BfBLGoodsCode]).ToString("00000");
            }
            return keyString;
        }

        /// <summary>
        /// ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/12</br>
        /// <br>Update Note: 2010/02/05 ���M Redmine#2841�̑Ή�</br>
        private int WriteGoodsMngProc(ArrayList goodsMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int logicalDeleteCode = 0;// ADD 2010/02/05
            try
            {
                if (goodsMngWorkList != null)
                {
                    for (int i = 0; i < goodsMngWorkList.Count; i++)
                    {
                        string sqlTxt = "";
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        GoodsMngWork goodsMngWork = goodsMngWorkList[i] as GoodsMngWork;
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (goodsMngWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                        sqlTxt = "";
                        sqlTxt += "INSERT INTO GOODSMNGRF" + Environment.NewLine;
                        sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                        sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                        sqlTxt += " )" + Environment.NewLine;
                        sqlTxt += " VALUES" + Environment.NewLine;
                        sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                        sqlTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                        sqlTxt += "  ,@SUPPLIERLOT" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSMGROUP" + Environment.NewLine;
                        sqlTxt += " )" + Environment.NewLine;

                        //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = sqlTxt;

                        // --- ADD 2010/02/05 -------------->>>
                        logicalDeleteCode = goodsMngWork.LogicalDeleteCode;
                        // --- ADD 2010/02/05 --------------<<<

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsMngWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        // --- ADD 2010/02/05 -------------->>>
                        goodsMngWork.LogicalDeleteCode = logicalDeleteCode;
                        // --- ADD 2010/02/05 --------------<<<

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierLot = sqlCommand.Parameters.Add("@SUPPLIERLOT", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        if (SqlDataMediator.SqlSetString(goodsMngWork.SectionCode) == DBNull.Value)
                        {
                            paraSectionCode.Value = "";
                        }
                        else
                        {
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsMngWork.SectionCode);
                        }
                        if (SqlDataMediator.SqlSetString(goodsMngWork.GoodsNo) == DBNull.Value)
                        {
                            paraGoodsNo.Value = "";

                        }
                        else
                        {
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsMngWork.GoodsNo);
                        }
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsMngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsMngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsMngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsMngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsMngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsMngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsMngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.GoodsMakerCd);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.SupplierCd);
                        paraSupplierLot.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.SupplierLot);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsMngWork.GoodsMGroup);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }        
        #endregion ���i�Ǘ����}�X�^�X�V����

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
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
