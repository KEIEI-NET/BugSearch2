//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/06  �C�����e : PMKYO06003D�����݂��Ȃ��ƃG���[�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/06/08  �C�����e : �}�X�^����M�s���Ή��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �}�X�^����M�����̂`�o�o���b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �f�[�^���M������DC�T�[�o�[�̃G���[���O�ɂ���
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �W�v�@�R���g���[��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �W�v�@�R���g���[��DB�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.3.31</br>
    /// </remarks>
    public class MstTotalMachControlDB : RemoteWithAppLockDB, IMstTotalMachControlDB
    {

        #region �� �萔 ��
        private const string MST_SECINFOSET = "���_�ݒ�}�X�^";
        private const string MST_SUBSECTION = "����ݒ�}�X�^";
        private const string MST_WAREHOUSE = "�q�ɐݒ�}�X�^";
        private const string MST_EMPLOYEE = "�]�ƈ��ݒ�}�X�^";
        private const string MST_USERGDAREADIVU = "���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j";
        private const string MST_USERGDBUSDIVU = "���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j";
        private const string MST_USERGDCATEU = "���[�U�[�K�C�h�}�X�^�i�Ǝ�j";
        private const string MST_USERGDBUSU = "���[�U�[�K�C�h�}�X�^�i�E��j";
        private const string MST_USERGDGOODSDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDCUSGROUPU = "���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j";
        private const string MST_USERGDBANKU = "���[�U�[�K�C�h�}�X�^�i��s�j";
        private const string MST_USERGDPRIDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDDELIDIVU = "���[�U�[�K�C�h�}�X�^�i�[�i�敪�j";
        private const string MST_USERGDGOODSBIGU = "���[�U�[�K�C�h�}�X�^�i���i�啪�ށj";
        private const string MST_USERGDBUYDIVU = "���[�U�[�K�C�h�}�X�^�i�̔��敪�j";
        private const string MST_USERGDSTOCKDIVOU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j";
        private const string MST_USERGDSTOCKDIVTU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j";
        private const string MST_USERGDRETURNREAU = "���[�U�[�K�C�h�}�X�^�i�ԕi���R�j";
        private const string MST_RATEPROTYMNG = "�|���D��Ǘ��}�X�^";
        private const string MST_RATE = "�|���}�X�^";
        private const string MST_SALESTARGET = "����ڕW�ݒ�}�X�^";
        private const string MST_CUSTOME = "���Ӑ�}�X�^";
        private const string MST_SUPPLIER = "�d����}�X�^";
        private const string MST_JOINPARTSU = "�����}�X�^";
        private const string MST_GOODSSET = "�Z�b�g�}�X�^";
        private const string MST_TBOSEARCHU = "�s�a�n�}�X�^";
        private const string MST_MODELNAMEU = "�Ԏ�}�X�^";
        private const string MST_BLGOODSCDU = "�a�k�R�[�h�}�X�^";
        private const string MST_MAKERU = "���[�J�[�}�X�^";
        private const string MST_GOODSMGROUPU = "���i�����ރ}�X�^";
        private const string MST_BLGROUPU = "�O���[�v�R�[�h�}�X�^";
        private const string MST_BLCODEGUIDE = "BL�R�[�h�K�C�h�}�X�^";
        private const string MST_GOODSU = "���i�}�X�^";
        private const string MST_STOCK = "�݌Ƀ}�X�^";
        private const string MST_PARTSSUBSTU = "��փ}�X�^";
        private const string MST_PARTSPOSCODEU = "���ʃ}�X�^";

        private const string MST_ID_SECINFOSET = "SecInfoSetRF";
        private const string MST_ID_SUBSECTION = "SubSectionRF";
        private const string MST_ID_WAREHOUSE = "WarehouseRF";
        private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOME = "CustomerRF";
        private const string MST_ID_CUSTOMEGROUP = "CustRateGroupRF";
        private const string MST_ID_CUSTOMESLIPMNG = "CustSlipMngRF";
        private const string MST_ID_CUSTOMESLIPNO = "CustSlipNoSetRF";
        private const string MST_ID_SUPPLIER = "SupplierRF";
        private const string MST_ID_JOINPARTSU = "JoinPartsURF";
        private const string MST_ID_GOODSSET = "GoodsSetRF";
        private const string MST_ID_TBOSEARCHU = "TBOSearchURF";
        private const string MST_ID_MODELNAMEU = "ModelNameURF";
        private const string MST_ID_BLGOODSCDU = "BLGoodsCdURF";
        private const string MST_ID_MAKERU = "MakerURF";
        private const string MST_ID_GOODSMGROUPU = "GoodsMGroupURF";
        private const string MST_ID_BLGROUPU = "BLGroupURF";
        private const string MST_ID_BLCODEGUIDE = "BLCodeGuideRF";
        private const string MST_ID_GOODSUMNG = "GoodsMngRF";
        private const string MST_ID_GOODSUPRI = "GoodsPriceURF";
        private const string MST_ID_GOODSU = "GoodsURF";
        private const string MST_ID_GOODSUISO = "IsolIslandPrcRF";
        private const string MST_ID_STOCK = "StockRF";
        private const string MST_ID_PARTSSUBSTU = "PartsSubstURF";
        private const string MST_ID_PARTSPOSCODEU = "PartsPosCodeURF";
        #endregion

        # region �� Private Members ��
        // ���_���ݒ�}�X�^
        private Int32 secInfoSetInt = 0;
        // ����}�X�^
        private Int32 subSectionInt = 0;
        // �q�Ƀ}�X�^
        private Int32 warehouseInt = 0;
        // �]�ƈ��}�X�^
        private Int32 employeeInt = 0;
        // �]�ƈ��ڍ׃}�X�^
        private Int32 employeeDtlInt = 0;
        // ���Ӑ�}�X�^
        private Int32 customerInt = 0;
        // ���Ӑ�}�X�^(�ϓ����)
        private Int32 customerChangeInt = 0;
        // ���Ӑ�}�X�^�i�`�[�Ǘ��j
        private Int32 custSlipMngInt = 0;
        // ���Ӑ�}�X�^�i�|���O���[�v�j
        private Int32 custRateGroupInt = 0;
        // ���Ӑ�}�X�^(�`�[�ԍ�)
        private Int32 custSlipNoSetInt = 0;
        // �d����}�X�^
        private Int32 supplierInt = 0;
        // ���[�J�[�}�X�^�i���[�U�[�o�^���j
        private Int32 makerUInt = 0;
        // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
        private Int32 bLGoodsCdUInt = 0;
        // ���i�}�X�^�i���[�U�[�o�^���j
        private Int32 goodsUInt = 0;
        // ���i�}�X�^�i���[�U�[�o�^�j
        private Int32 goodsPriceInt = 0;
        // ���i�Ǘ����}�X�^
        private Int32 goodsMngInt = 0;
        // �������i�}�X�^
        private Int32 isolIslandPrcInt = 0;
        // �݌Ƀ}�X�^
        private Int32 stockInt = 0;
        // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
        private Int32 userGdAreaDivUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
        private Int32 userGdBusDivUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
        private Int32 userGdCateUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�E��j
        private Int32 userGdBusUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
        private Int32 userGdGoodsDivUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
        private Int32 userGdCusGrouPUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i��s�j
        private Int32 userGdBankUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
        private Int32 userGdPriDivUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
        private Int32 userGdDeliDivUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
        private Int32 userGdGoodsBigUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
        private Int32 userGdBuyDivUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
        private Int32 userGdStockDivOUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
        private Int32 userGdStockDivTUInt = 0;
        // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
        private Int32 userGdReturnReaUInt = 0;
        // �|���D��Ǘ��}�X�^
        private Int32 rateProtyMngInt = 0;
        // �|���}�X�^
        private Int32 rateInt = 0;
        // ���i�Z�b�g�}�X�^
        private Int32 goodsSetInt = 0;
        // ���i��փ}�X�^�i���[�U�[�o�^���j
        private Int32 partsSubstUInt = 0;
        // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
        private Int32 empSalesTargetInt = 0;
        // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
        private Int32 custSalesTargetInt = 0;
        // ���i�ʔ���ڕW�ݒ�}�X�^
        private Int32 gcdSalesTargetInt = 0;
        // ���i�����ރ}�X�^�i���[�U�[�o�^���j
        private Int32 goodsMGroupUInt = 0;
        // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
        private Int32 bLGroupUInt = 0;
        // �����}�X�^�i���[�U�[�o�^���j
        private Int32 joinPartsUInt = 0;
        // TBO�����}�X�^�i���[�U�[�o�^�j
        private Int32 tBOSearchUCountInt = 0;
        // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
        private Int32 partsPosCodeUInt = 0;
        // BL�R�[�h�K�C�h�}�X�^
        private Int32 bLCodeGuideInt = 0;
        // �Ԏ햼�̃}�X�^
        private Int32 modelNameUInt = 0;

        #endregion

        # region �� Constructor ��
        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.4.24</br>
        /// </remarks>
        public MstTotalMachControlDB()
        {
            // �ϐ�������
            //_secInfoSetDB = new DCSecInfoSetDB();
            //_subSectionDB = new DCSubSectionDB();
            //_employeeDB = new DCEmployeeDB();
            //_employeeDtlDB = new DCEmployeeDtlDB();
            //_warehouseDB = new DCWarehouseDB();
            //_customerWorkDB = new DCCustomerDB();
            //_customerChangeDB = new DCCustomerChangeDB();
            //_custSlipMngDB = new DCCustSlipMngDB();
            //_custRateGroupDB = new DCCustRateGroupDB();
            //_custSlipNoSetDB = new DCCustSlipNoSetDB();
            //_supplierDB = new DCSupplierDB();
            //_makerUWorkDB = new DCMakerUDB();
            //_bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
            //_goodsUDB = new DCGoodsUDB();
            //_goodsPriceUDB = new DCGoodsPriceUDB();
            //_goodsMngDB = new DCGoodsMngDB();
            //_isolIslandPrcDB = new DCIsolIslandPrcDB();
            //_stockDB = new DCStockDB();
            //_userGdBdUDB = new DCUserGdBdUDB();
            //_rateProtyMngDB = new DCRateProtyMngDB();
            //_rateDB = new DCRateDB();
            //_goodsSetDB = new DCGoodsSetDB();
            //_partsSubstUDB = new DCPartsSubstUDB();
            //_empSalesTargetDB = new DCEmpSalesTargetDB();
            //_custSalesTargetDB = new DCCustSalesTargetDB();
            //_gcdSalesTargetDB = new DCGcdSalesTargetDB();
            //_goodsGroupUDB = new DCGoodsGroupUDB();
            //_bLGroupUDB = new DCBLGroupUDB();
            //_joinPartsUDB = new DCJoinPartsUDB();
            //_tBOSearchUDB = new DCTBOSearchUDB();
            //_partsPosCodeUDB = new DCPartsPosCodeUDB();
            //_bLCodeGuideDB = new DCBLCodeGuideDB();
            //_modelNameUDB = new DCModelNameUDB();
        }
        #endregion

        # region �� �}�X�^��M�̃f�[�^�������� ��
        /// <summary>
        /// �f�[�^���M�̃f�[�^��������
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="beginningDate">��������</param>
        /// <param name="endingDate">��������</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Summary_DB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();



#if DEBUG
                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                retCSAList = new CustomSerializeArrayList();
                // MOD 2009/06/06 --->>>
                foreach (DCSecMngSndRcvWork secMngSndRcvWork in masterDivList)
                // MOD 2009/06/06 ---<<<
                {
                    // ���_�ݒ�}�X�^
                    if (MST_SECINFOSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_SECINFOSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        secInfoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ����ݒ�}�X�^
                    if (MST_SUBSECTION.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUBSECTION.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        subSectionInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �q�ɐݒ�}�X�^
                    if (MST_WAREHOUSE.Equals(secMngSndRcvWork.MasterName) && MST_ID_WAREHOUSE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        warehouseInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �]�ƈ��}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �]�ƈ��ڍ׃}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���Ӑ�}�X�^
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���Ӑ�}�X�^(�ϓ����)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMECHA.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerChangeInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���Ӑ�}�X�^�i�`�[�Ǘ��j
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipMngInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���Ӑ�}�X�^�i�|���O���[�v�j
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEGROUP.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custRateGroupInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���Ӑ�}�X�^(�`�[�ԍ�)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPNO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipNoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �d����}�X�^
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�J�[�}�X�^�i���[�U�[�o�^���j
                    if (MST_MAKERU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MAKERU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        makerUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
                    if (MST_BLGOODSCDU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGOODSCDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGoodsCdUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i�}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i�}�X�^�i���[�U�[�o�^�j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUPRI.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsPriceInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i�Ǘ����}�X�^
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMngInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �������i�}�X�^
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUISO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        isolIslandPrcInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �݌Ƀ}�X�^
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    if (MST_USERGDAREADIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdAreaDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    if (MST_USERGDBUSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    if (MST_USERGDCATEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCateUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    if (MST_USERGDBUSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (MST_USERGDGOODSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    if (MST_USERGDCUSGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCusGrouPUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    if (MST_USERGDBANKU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBankUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (MST_USERGDPRIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdPriDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    if (MST_USERGDDELIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdDeliDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    if (MST_USERGDGOODSBIGU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsBigUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    if (MST_USERGDSTOCKDIVOU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivOUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    if (MST_USERGDSTOCKDIVTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivTUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    if (MST_USERGDRETURNREAU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdReturnReaUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �|���D��Ǘ��}�X�^
                    if (MST_RATEPROTYMNG.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATEPROTYMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateProtyMngInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �|���}�X�^
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i�Z�b�g�}�X�^
                    if (MST_GOODSSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsSetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i��փ}�X�^�i���[�U�[�o�^���j
                    if (MST_PARTSSUBSTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSSUBSTU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsSubstUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        empSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i�ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GCDSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        gcdSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���i�����ރ}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSMGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSMGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
                    if (MST_BLGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �����}�X�^�i���[�U�[�o�^���j
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // TBO�����}�X�^�i���[�U�[�o�^�j
                    if (MST_TBOSEARCHU.Equals(secMngSndRcvWork.MasterName) && MST_ID_TBOSEARCHU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        tBOSearchUCountInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
                    if (MST_PARTSPOSCODEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSPOSCODEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsPosCodeUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // BL�R�[�h�K�C�h�}�X�^
                    if (MST_BLCODEGUIDE.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLCODEGUIDE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLCodeGuideInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // �Ԏ햼�̃}�X�^
                    if (MST_MODELNAMEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MODELNAMEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        modelNameUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                }

                if (secInfoSetInt != 0)
                {
                    // ���_���ݒ�}�X�^�f�[�^���o
                    ArrayList secInfoSetArrList = new ArrayList();
                    DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
                    status = _secInfoSetDB.SearchSecInfoSet(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out secInfoSetArrList, out retMessage);
                    retCSAList.Add(secInfoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && subSectionInt != 0)
                {
                    // ����}�X�^�f�[�^���o
                    ArrayList subSectionArrList = new ArrayList();
                    DCSubSectionDB _subSectionDB = new DCSubSectionDB();
                    status = _subSectionDB.SearchSubSection(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out subSectionArrList, out retMessage);
                    retCSAList.Add(subSectionArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt != 0)
                {
                    // �]�ƈ��}�X�^�f�[�^���o
                    ArrayList employeeArrList = new ArrayList();
                    DCEmployeeDB _employeeDB = new DCEmployeeDB();
                    status = _employeeDB.SearchEmployee(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    retCSAList.Add(employeeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt != 0)
                {
                    // �]�ƈ��ڍ׃}�X�^�f�[�^���o
                    ArrayList employeeDtlArrList = new ArrayList();
                    DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    retCSAList.Add(employeeDtlArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInt != 0)
                {
                    // �q�Ƀ}�X�^�f�[�^���o
                    ArrayList warehouseArrList = new ArrayList();
                    DCWarehouseDB _warehouseDB = new DCWarehouseDB();
                    status = _warehouseDB.SearchWarehouse(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out warehouseArrList, out retMessage);
                    retCSAList.Add(warehouseArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInt != 0)
                {
                    // ���Ӑ�}�X�^�f�[�^���o
                    ArrayList customerArrList = new ArrayList();
                    DCCustomerDB _customerDB = new DCCustomerDB();
                    status = _customerDB.SearchCustomer(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    retCSAList.Add(customerArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerChangeInt != 0)
                {
                    // ���Ӑ�}�X�^(�ϓ����)�f�[�^���o
                    ArrayList customerChangeArrList = new ArrayList();
                    DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
                    status = _customerChangeDB.SearchCustomerChange(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    retCSAList.Add(customerChangeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipMngInt != 0)
                {
                    // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^���o
                    ArrayList custSlipMngArrList = new ArrayList();
                    DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
                    status = _custSlipMngDB.SearchCustSlipMng(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    retCSAList.Add(custSlipMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custRateGroupInt != 0)
                {
                    // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���o
                    ArrayList custRateGroupArrList = new ArrayList();
                    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                    status = _custRateGroupDB.SearchCustRateGroup(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    retCSAList.Add(custRateGroupArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipNoSetInt != 0)
                {
                    // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^���o
                    ArrayList custSlipNoSetArrList = new ArrayList();
                    DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
                    status = _custSlipNoSetDB.SearchCustSlipNoSet(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    retCSAList.Add(custSlipNoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt != 0)
                {
                    // �d����}�X�^�f�[�^���o
                    ArrayList supplierArrList = new ArrayList();
                    DCSupplierDB _supplierDB = new DCSupplierDB();
                    status = _supplierDB.SearchSupplier(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    retCSAList.Add(supplierArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUInt != 0)
                {
                    // ���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList makerUArrList = new ArrayList();
                    DCMakerUDB _makerUDB = new DCMakerUDB();
                    status = _makerUDB.SearchMakerU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out makerUArrList, out retMessage);
                    retCSAList.Add(makerUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGoodsCdUInt != 0)
                {
                    // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList bLGoodsCdUArrList = new ArrayList();
                    DCBLGoodsCdUDB _bLGoodsCdUDB = new DCBLGoodsCdUDB();
                    status = _bLGoodsCdUDB.SearchBLGoodsCdU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGoodsCdUArrList, out retMessage);
                    retCSAList.Add(bLGoodsCdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUInt != 0)
                {
                    // ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList goodsUArrList = new ArrayList();
                    DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                    status = _goodsUDB.SearchGoodsU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsUArrList, out retMessage);
                    retCSAList.Add(goodsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsPriceInt != 0)
                {
                    // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    ArrayList goodsPriceUArrList = new ArrayList();
                    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                    status = _goodsPriceUDB.SearchGoodsPriceU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    retCSAList.Add(goodsPriceUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMngInt != 0)
                {
                    // ���i�Ǘ����}�X�^�f�[�^���o
                    ArrayList goodsMngArrList = new ArrayList();
                    DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
                    status = _goodsMngDB.SearchGoodsMng(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsMngArrList, out retMessage);
                    retCSAList.Add(goodsMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isolIslandPrcInt != 0)
                {
                    // �������i�}�X�^�f�[�^���o
                    ArrayList isolIslandPrcArrList = new ArrayList();
                    DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
                    status = _isolIslandPrcDB.SearchIsolIslandPrc(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    retCSAList.Add(isolIslandPrcArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0)
                {
                    // �݌Ƀ}�X�^�f�[�^���o
                    ArrayList stockArrList = new ArrayList();
                    DCStockDB _stockDB = new DCStockDB();
                    status = _stockDB.SearchStock(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    retCSAList.Add(stockArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���[�U�[�K�C�h�}�X�^�f�[�^���o
                    ArrayList userGdBdUArrList = new ArrayList();
                    DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    if (userGdAreaDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(21, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    if (userGdBusDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(31, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    if (userGdCateUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(33, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    if (userGdBusUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(34, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (userGdGoodsDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(41, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    if (userGdCusGrouPUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(43, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    if (userGdBankUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(46, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (userGdPriDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(47, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    if (userGdDeliDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(48, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    if (userGdGoodsBigUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(70, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (userGdBuyDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(71, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    if (userGdStockDivOUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(72, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    if (userGdStockDivTUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(73, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    if (userGdReturnReaUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(91, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    retCSAList.Add(userGdBdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateProtyMngInt != 0)
                {
                    // �|���D��Ǘ��}�X�^�f�[�^���o
                    ArrayList rateProtyMngArrList = new ArrayList();
                    DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
                    status = _rateProtyMngDB.SearchRateProtyMng(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateProtyMngArrList, out retMessage);
                    retCSAList.Add(rateProtyMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt != 0)
                {
                    // �|���}�X�^�f�[�^���o
                    ArrayList rateArrList = new ArrayList();
                    DCRateDB _rateDB = new DCRateDB();
                    status = _rateDB.SearchRate(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                    retCSAList.Add(rateArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsSetInt != 0)
                {
                    // ���i�Z�b�g�}�X�^�f�[�^���o
                    ArrayList goodsSetArrList = new ArrayList();
                    DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
                    status = _goodsSetDB.SearchGoodsSet(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsSetArrList, out retMessage);
                    retCSAList.Add(goodsSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsSubstUInt != 0)
                {
                    // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList partsSubstUArrList = new ArrayList();
                    DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
                    status = _partsSubstUDB.SearchPartsSubstU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsSubstUArrList, out retMessage);
                    retCSAList.Add(partsSubstUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && empSalesTargetInt != 0)
                {
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^���o
                    ArrayList empSalesTargetArrList = new ArrayList();
                    DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
                    status = _empSalesTargetDB.SearchEmpSalesTarget(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out empSalesTargetArrList, out retMessage);
                    retCSAList.Add(empSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSalesTargetInt != 0)
                {
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^���o
                    ArrayList custSalesTargetArrList = new ArrayList();
                    DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
                    status = _custSalesTargetDB.SearchCustSalesTarget(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSalesTargetArrList, out retMessage);
                    retCSAList.Add(custSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && gcdSalesTargetInt != 0)
                {
                    // ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^���o
                    ArrayList gcdSalesTargetArrList = new ArrayList();
                    DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                    status = _gcdSalesTargetDB.SearchGcdSalesTarget(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out gcdSalesTargetArrList, out retMessage);
                    retCSAList.Add(gcdSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMGroupUInt != 0)
                {
                    // ���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList goodsGroupUArrList = new ArrayList();
                    DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
                    status = _goodsGroupUDB.SearchGoodsGroupU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsGroupUArrList, out retMessage);
                    retCSAList.Add(goodsGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGroupUInt != 0)
                {
                    // BL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList bLGroupUArrList = new ArrayList();
                    DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
                    status = _bLGroupUDB.SearchBLGroupU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGroupUArrList, out retMessage);
                    retCSAList.Add(bLGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt != 0)
                {
                    // �����}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList joinPartsUArrList = new ArrayList();
                    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    retCSAList.Add(joinPartsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && tBOSearchUCountInt != 0)
                {
                    // TBO�����}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    ArrayList tBOSearchUArrList = new ArrayList();
                    DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
                    status = _tBOSearchUDB.SearchTBOSearchU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out tBOSearchUArrList, out retMessage);
                    retCSAList.Add(tBOSearchUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsPosCodeUInt != 0)
                {
                    // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    ArrayList partsPosCodeUArrList = new ArrayList();
                    DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
                    status = _partsPosCodeUDB.SearchPartsPosCodeU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsPosCodeUArrList, out retMessage);
                    retCSAList.Add(partsPosCodeUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLCodeGuideInt != 0)
                {
                    // BL�R�[�h�K�C�h�}�X�^�f�[�^���o
                    ArrayList bLCodeGuideArrList = new ArrayList();
                    DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
                    status = _bLCodeGuideDB.SearchBLCodeGuide(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLCodeGuideArrList, out retMessage);
                    retCSAList.Add(bLCodeGuideArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && modelNameUInt != 0)
                {
                    // ����}�X�^�f�[�^���o
                    ArrayList modelNameUArrList = new ArrayList();
                    DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
                    status = _modelNameUDB.SearchModelNameU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out modelNameUArrList, out retMessage);
                    retCSAList.Add(modelNameUArrList);
                }
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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

        #region �� �}�X�^���M�̍X�V���� ��
        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage)
        {
            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            // ���Ӑ�}�X�^�i�|���O���[�v�j
            ArrayList _custRateGroupList = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^�j
            ArrayList _goodsPriceUList = new ArrayList();
            // �|���D��Ǘ��}�X�^
            ArrayList _rateProtyMngList = new ArrayList();
            // �|���}�X�^
            ArrayList _rateList = new ArrayList();
            // ���i�Z�b�g�}�X�^
            ArrayList _goodsSetList = new ArrayList();
            // �����}�X�^�i���[�U�[�o�^���j
            ArrayList _joinPartsUList = new ArrayList();
            // TBO�������}�X�^�i���[�U�[�o�^���j
            ArrayList _tboSearchUList = new ArrayList();
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            ArrayList _partsPosCodeUList = new ArrayList();
            // BL�R�[�h�K�C�h�}�X�^
            ArrayList _blCodeGuideList = new ArrayList();

            try
            {
                //���p�����[�^�`�F�b�N
                if (retCSAList == null || retCSAList.Count <= 0)
                {
                    base.WriteErrorLog(null, "�v���O�����G���[�B�p�����[�^�����ݒ�ł�");
                    return status;
                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnectionData(true);

#if DEBUG
                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                resNm = GetResourceName(enterpriseCode);
                // MOD 2009/07/06 --->>>
                //�`�o���b�N
                status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                // MOD 2009/07/06 ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC���_���ݒ�}�X�^�X�V����
                        if (wktype.Equals(typeof(DCSecInfoSetWork)))
                        {
                            DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
                            DCSecInfoSetWork secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                        }
                        // DC����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCSubSectionWork)))
                        {
                            DCSubSectionDB _subSectionDB = new DCSubSectionDB();
                            DCSubSectionWork subSectionWork = (DCSubSectionWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�]�ƈ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmployeeWork)))
                        {
                            DCEmployeeDB _employeeDB = new DCEmployeeDB();
                            DCEmployeeWork employeeWork = (DCEmployeeWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�]�ƈ��ڍ׃}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                        {
                            DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
                            DCEmployeeDtlWork employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�q�Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCWarehouseWork)))
                        {
                            DCWarehouseDB _warehouseDB = new DCWarehouseDB();
                            DCWarehouseWork warehouseWork = (DCWarehouseWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCCustomerWork)))
                        {
                            DCCustomerDB _customerWorkDB = new DCCustomerDB();
                            DCCustomerWork customerWork = (DCCustomerWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^(�ϓ����)�X�V����
                        else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                        {
                            DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
                            DCCustomerChangeWork customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^�i�`�[�Ǘ��j�X�V����
                        else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                        {
                            DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
                            DCCustSlipMngWork custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^�i�|���O���[�v�j�X�V����
                        else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                        {
                            //DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                            DCCustRateGroupWork custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_custRateGroupDB.Delete(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_custRateGroupDB.Insert(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _custRateGroupList.Add(custRateGroupWork);
                        }
                        // DC���Ӑ�}�X�^(�`�[�ԍ�)�X�V����
                        else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                        {
                            DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
                            DCCustSlipNoSetWork custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�d����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCSupplierWork)))
                        {
                            DCSupplierDB _supplierDB = new DCSupplierDB();
                            DCSupplierWork supplierWork = (DCSupplierWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���[�J�[�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCMakerUWork)))
                        {
                            DCMakerUDB _makerUWorkDB = new DCMakerUDB();
                            DCMakerUWork makerUWork = (DCMakerUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                        {
                            DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
                            DCBLGoodsCdUWork bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsUWork)))
                        {
                            DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                            DCGoodsUWork goodsUWork = (DCGoodsUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsUDB.Delete(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsUDB.Insert(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                        {
                            //DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                            DCGoodsPriceUWork goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_goodsPriceUDB.Delete(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_goodsPriceUDB.Insert(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsPriceUList.Add(goodsPriceUWork);
                        }
                        // DC���i�Ǘ����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGoodsMngWork)))
                        {
                            DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
                            DCGoodsMngWork goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�������i�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                        {
                            DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
                            DCIsolIslandPrcWork isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�݌Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCStockWork)))
                        {
                            DCStockDB _stockDB = new DCStockDB();
                            DCStockWork stockWork = (DCStockWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _stockDB.Delete(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���[�U�[�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                        {
                            DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
                            DCUserGdBdUWork userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�|���D��Ǘ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                        {
                            //DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
                            DCRateProtyMngWork rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_rateProtyMngDB.Delete(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_rateProtyMngDB.Insert(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateProtyMngList.Add(rateProtyMngWork);
                        }
                        // DC�|���}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCRateWork)))
                        {
                            //DCRateDB _rateDB = new DCRateDB();
                            DCRateWork rateWork = (DCRateWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_rateDB.Delete(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_rateDB.Insert(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateList.Add(rateWork);
                        }
                        // DC���i�Z�b�g�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGoodsSetWork)))
                        {
                            //DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
                            DCGoodsSetWork goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_goodsSetDB.Delete(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_goodsSetDB.Insert(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsSetList.Add(goodsSetWork);
                        }
                        // DC���i��փ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                        {
                            DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
                            DCPartsSubstUWork partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�]�ƈ��ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                        {
                            DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
                            DCEmpSalesTargetWork empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                        {
                            DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
                            DCCustSalesTargetWork custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                        {
                            DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                            DCGcdSalesTargetWork gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�����ރ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                        {
                            DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
                            DCGoodsGroupUWork goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBL�O���[�v�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCBLGroupUWork)))
                        {
                            DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
                            DCBLGroupUWork bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�����}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                        {
                            //DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                            DCJoinPartsUWork joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_joinPartsUDB.Delete(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_joinPartsUDB.Insert(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _joinPartsUList.Add(joinPartsUWork);
                        }
                        // DCTBO�����}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                        {
                            //DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
                            DCTBOSearchUWork tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_tBOSearchUDB.Delete(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_tBOSearchUDB.Insert(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _tboSearchUList.Add(tBOSearchUWork);
                        }
                        // DC���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                        {
                            //DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
                            DCPartsPosCodeUWork partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_partsPosCodeUDB.Delete(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_partsPosCodeUDB.Insert(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _partsPosCodeUList.Add(partsPosCodeUWork);
                        }
                        // DCBL�R�[�h�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                        {
                            //DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
                            DCBLCodeGuideWork bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_bLCodeGuideDB.Delete(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_bLCodeGuideDB.Insert(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _blCodeGuideList.Add(bLCodeGuideWork);
                        }
                        // DC�Ԏ햼�̃}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCModelNameUWork)))
                        {
                            DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
                            DCModelNameUWork modelNameUWork = (DCModelNameUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                    }
                }

                // ADD 2009/06/09 --->>>
                // ���Ӑ�}�X�^�i�|���O���[�v�j
                if (_custRateGroupList != null && _custRateGroupList.Count > 0)
                {
                    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                    // �폜
                    foreach (DCCustRateGroupWork dcCustRateGroupWork in _custRateGroupList)
                    {
                        _custRateGroupDB.Delete(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCCustRateGroupWork dcCustRateGroupWork in _custRateGroupList)
                    {
                        _custRateGroupDB.Insert(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // ���i�}�X�^�i���[�U�[�o�^�j
                if (_goodsPriceUList != null && _goodsPriceUList.Count > 0)
                {
                    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                    // �폜
                    foreach (DCGoodsPriceUWork dcGoodsPriceUWork in _goodsPriceUList)
                    {
                        _goodsPriceUDB.Delete(dcGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCGoodsPriceUWork dcGoodsPriceUWork in _goodsPriceUList)
                    {
                        _goodsPriceUDB.Insert(dcGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // �|���D��Ǘ��}�X�^
                if (_rateProtyMngList != null && _rateProtyMngList.Count > 0)
                {
                    DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
                    // �폜
                    foreach (DCRateProtyMngWork dcRateProtyMngWork in _rateProtyMngList)
                    {
                        _rateProtyMngDB.Delete(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCRateProtyMngWork dcRateProtyMngWork in _rateProtyMngList)
                    {
                        _rateProtyMngDB.Insert(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // �|���}�X�^
                if (_rateList != null && _rateList.Count > 0)
                {
                    DCRateDB _rateDB = new DCRateDB();
                    // �폜
                    foreach (DCRateWork dcRateWork in _rateList)
                    {
                        _rateDB.Delete(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCRateWork dcRateWork in _rateList)
                    {
                        _rateDB.Insert(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // ���i�Z�b�g�}�X�^
                if (_goodsSetList != null && _goodsSetList.Count > 0)
                {
                    DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
                    // �폜
                    foreach (DCGoodsSetWork dcGoodsSetWork in _goodsSetList)
                    {
                        _goodsSetDB.Delete(dcGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCGoodsSetWork dcGoodsSetWork in _goodsSetList)
                    {
                        _goodsSetDB.Insert(dcGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // �����}�X�^�i���[�U�[�o�^���j
                if (_joinPartsUList != null && _joinPartsUList.Count > 0)
                {
                    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                    // �폜
                    foreach (DCJoinPartsUWork dcJoinPartsUWork in _joinPartsUList)
                    {
                        _joinPartsUDB.Delete(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCJoinPartsUWork dcJoinPartsUWork in _joinPartsUList)
                    {
                        _joinPartsUDB.Insert(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // TBO�������}�X�^�i���[�U�[�o�^���j
                if (_tboSearchUList != null && _tboSearchUList.Count > 0)
                {
                    DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
                    // �폜
                    foreach (DCTBOSearchUWork dcTBOSearchUWork in _tboSearchUList)
                    {
                        _tBOSearchUDB.Delete(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCTBOSearchUWork dcTBOSearchUWork in _tboSearchUList)
                    {
                        _tBOSearchUDB.Insert(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
                if (_partsPosCodeUList != null && _partsPosCodeUList.Count > 0)
                {
                    DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
                    // �폜
                    foreach (DCPartsPosCodeUWork dcPartsPosCodeUWork in _partsPosCodeUList)
                    {
                        _partsPosCodeUDB.Delete(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCPartsPosCodeUWork dcPartsPosCodeUWork in _partsPosCodeUList)
                    {
                        _partsPosCodeUDB.Insert(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // BL�R�[�h�K�C�h�}�X�^
                if (_blCodeGuideList != null && _blCodeGuideList.Count > 0)
                {
                    DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
                    // �폜
                    foreach (DCBLCodeGuideWork dcBLCodeGuideWork in _blCodeGuideList)
                    {
                        _bLCodeGuideDB.Delete(dcBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // �ǉ�
                    foreach (DCBLCodeGuideWork dcBLCodeGuideWork in _blCodeGuideList)
                    {
                        _bLCodeGuideDB.Insert(dcBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // ADD 2009/06/09 ---<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Read(Connection�t) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (resNm != "")
                {
                    // �� 2009/07/06 杍^ modify
                    //�`�o�A�����b�N
                    status = Release(resNm, sqlConnection, sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    // �� 2009/07/06 杍^ modify
                }

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            //STATUS��߂�
            return status;
        }

        #endregion

        # region �� �R�l�N�V������������ ��
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Summary_DB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}
