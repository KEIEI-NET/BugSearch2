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
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/05/25  �C�����e : �\������100�ȏ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/06/08  �C�����e : �}�X�^����M�s���Ή��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ����
// �C �� ��  2009/06/12  �C�����e : public Method��SQL�������ʖڑΉ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : 杍^
// �C �� ��  2009/06/24  �C�����e : PVCS#255 ���i�}�X�^�̎�M�ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �}�X�^����M�����̂`�o�o���b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �f�[�^���M������DC�T�[�o�[�̃G���[���O�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011/07/25  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/08/25  �C�����e : #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/05  �C�����e : #24047 ���M���s���̑Ώ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/09/06  �C�����e : #24364 ���M�^�C���A�E�g���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������ 
// �C �� ��  2011/09/06  �C�����e : #24252 �f�[�^����M���鎞�A
//                                  �݌Ƀ}�X�^�̐��ʂ̍X�V�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : yangmj 
// �C �� ��  2011/10/08  �C�����e : #25778 �}�X�^����M�����[�g��Dispose����������܂���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00 �C���S�� : FSI�� ���j
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ� ���o�����ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ�DC���O���Ԓǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : ���O
// �� �� ��  2021/04/12  �C�����e : ���Ӑ惁�����̒ǉ�
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
    /// DC�R���g���[��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: 2011/10/08 yangmj</br>
    /// <br>             Redmine #25778�̑Ή�</br>
    /// <br>Update Note: 2012/10/16 ������</br>
    ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    [Serializable]
    public class APMSTControlDB : RemoteWithAppLockDB, IAPMSTControlDB
    {
        #region �� Const Memebers ��
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
        // --- DEL 2012/07/26 --------------------------------------------->>>>>
        //private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";
        // --- DEL 2012/07/26 ---------------------------------------------<<<<<
        // --- ADD 2012/07/26 --------------------------------------------->>>>>
        private const string MST_ID_EMPLOYEE = "EmployeeRF";
        // --- ADD 2012/07/26 ---------------------------------------------<<<<<
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOMEMEMO = "CustomerMemoRF"; // ADD 2021/04/12 ���O FOR PMKOBETSU-4136
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

        private const int MAX_CNT = 20000;//ADD 2011.09.06 #24364


        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        private const int CNT_ZERO = 0;
        //��M�敪
        enum CusMemoSedDiv
        {
            // ��M�敪�Ȃ�
            None = 0,
            // ��M�敪����M����i�ǉ��̂݁j
            Add = 1,
            // ��M�敪����M����i�ǉ��E�X�V�j
            AddUpd = 2,
            // ��M�敪����M����i�X�V�̂݁j
            Upd = 3,
        }
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
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
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        // ���Ӑ�}�X�^(�������)
        private Int32 customerMemoInt =  Convert.ToInt32(CusMemoSedDiv.None);
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
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
        public APMSTControlDB()
        {
        }
        #endregion

        # region �� �}�X�^����M���� ��

         /// <summary>
        /// ���M�}�X�^���̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^���̎擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            return SearchMstNameProc(enterpriseCode, out masterNameList);
        }
        /// <summary>
        /// ���M�}�X�^���̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^���̎擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Update Note : 2012/07/26 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        private int SearchMstNameProc(string enterpriseCode, out ArrayList masterNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterNameList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Select�R�}���h�̐���
                sqlString += " SELECT DISTINCT" + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.DISPLAYORDERRF" + Environment.NewLine;
                //sqlString += "    ,A.FILEIDRF" + Environment.NewLine;   // ADD 2012/07/26 �L�w�� //DEL 2012/10/16 ������ for redmine#31026
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                // ADD 2009/05/25 --->>>
                // �\������100�ȏ�
                sqlString += " AND A.DISPLAYORDERRF > @DISPLAYORDER ";
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(100);
                // ADD 2009/05/25 ---<<<


                // ���_�Ǘ����M�敪
                sqlString += " AND A.SECMNGSENDDIVRF=@SECMNGSENDDIVRF ";
                SqlParameter paraSecMngSendDiv = sqlCommand.Parameters.Add("@SECMNGSENDDIVRF", SqlDbType.Int);
                paraSecMngSendDiv.Value = SqlDataMediator.SqlSetInt32(1);

                // ORDER BY
                sqlString += " ORDER BY A.DISPLAYORDERRF ";

                sqlCommand.CommandText = sqlString;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    //secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));  // ADD 2012/07/26 �L�w�� //DEL 2012/10/16 ������ for redmine#31026
                    masterNameList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "APMSTControlDB.SearchMstName Exception=" + e.Message);
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


        /// <summary>
        /// ���M�}�X�^���̋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^���̋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            return SearchMstDoDivProc(enterpriseCode, out masterDivList);
        }
        /// <summary>
        /// ���M�}�X�^���̋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^���̋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note : 2012/07/26 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        private int SearchMstDoDivProc(string enterpriseCode, out ArrayList masterDivList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterDivList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Select�R�}���h�̐���
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FILEIDRF" + Environment.NewLine;
                sqlString += "    ,A.SECMNGSENDDIVRF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;   // ADD 2012/07/26 �L�w��
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlString;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                    secMngSndRcvWork.SecMngSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGSENDDIVRF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));   // ADD 2012/07/26 �L�w��
                    secMngSndRcvWork.EnterpriseCode = enterpriseCode;//ADD 2012/10/16 ������ for redmine#31026
                    masterDivList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.SearchMstDoDiv SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "APMSTControlDB.SearchMstDoDiv Exception=" + e.Message);
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

        /// <summary>
        /// ��M�}�X�^���̋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            return SearchReceMstDoDivProc(enterpriseCode, out masterDivList);
        }
        /// <summary>
        /// ��M�}�X�^���̋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note : 2012/07/26 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        private int SearchReceMstDoDivProc(string enterpriseCode, out ArrayList masterDivList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterDivList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Select�R�}���h�̐���
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FILEIDRF" + Environment.NewLine;
                sqlString += "    ,A.SECMNGRECVDIVRF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;   // ADD 2012/07/26 �L�w��
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlString;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                    secMngSndRcvWork.SecMngRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGRECVDIVRF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));   // ADD 2012/07/26 �L�w��
                    secMngSndRcvWork.EnterpriseCode = enterpriseCode;//ADD 2012/10/16 ������ for redmine#31026
                    masterDivList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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


        /// <summary>
        /// ��M�}�X�^���̖��׋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDtlDivList">�}�X�^���̖��׋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̖��׋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceMstDtlDoDiv(string enterpriseCode, out ArrayList masterDtlDivList)
        {
            return SearchReceMstDtlDoDivProc( enterpriseCode, out  masterDtlDivList);
        }
        /// <summary>
        /// ��M�}�X�^���̖��׋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDtlDivList">�}�X�^���̖��׋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̖��׋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        private int SearchReceMstDtlDoDivProc(string enterpriseCode, out ArrayList masterDtlDivList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterDtlDivList = new ArrayList();
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Select�R�}���h�̐���
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.FILENMRF" + Environment.NewLine;
                sqlString += "    ,A.ITEMIDRF" + Environment.NewLine;
                sqlString += "    ,A.DATAUPDATEDIVRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVDTLRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlString;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvDtlWork = new SecMngSndRcvDtlWork();
                    secMngSndRcvDtlWork.FileNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
                    secMngSndRcvDtlWork.ItemId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMIDRF"));
                    secMngSndRcvDtlWork.DataUpdateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAUPDATEDIVRF"));
                    masterDtlDivList.Add(secMngSndRcvDtlWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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

         /// <summary>
        /// ��M�}�X�^���̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̂��擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            return SearchReceMstNameProc( enterpriseCode, out  masterNameList);
        }
        /// <summary>
        /// ��M�}�X�^���̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̂��擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        private int SearchReceMstNameProc(string enterpriseCode, out ArrayList masterNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterNameList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Select�R�}���h�̐���
                sqlString += " SELECT DISTINCT" + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.DISPLAYORDERRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // ��ƃR�[�h
                sqlString += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                sqlString += "AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                // ADD 2009/05/25 --->>>
                // �\������100�ȏ�
                sqlString += " AND A.DISPLAYORDERRF > @DISPLAYORDER ";
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(100);
                // ADD 2009/05/25 ---<<<

                // ���_�Ǘ���M�敪
                sqlString += "AND A.SECMNGRECVDIVRF!=@SECMNGRECVDIVRF ";
                SqlParameter paraSecMngSendDiv = sqlCommand.Parameters.Add("@SECMNGRECVDIVRF", SqlDbType.Int);
                paraSecMngSendDiv.Value = SqlDataMediator.SqlSetInt32(0);

                // ORDER BY
                sqlString += "ORDER BY A.DISPLAYORDERRF ";

                sqlCommand.CommandText = sqlString;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF")); //ADD 2011/07/25
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    masterNameList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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

        /// <summary>
        /// ���M�̃V���N�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�̃V���N�������擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            return SearchSyncExecDateProc( enterpriseCode, out secMngSetArrList);
        }
        /// <summary>
        /// ���M�̃V���N�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�̃V���N�������擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        private int SearchSyncExecDateProc(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secMngSetArrList = new ArrayList();
            APMSTSecMngSetWork secMngSetWork = null;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlString = string.Empty;

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
                sqlString += " SELECT" + Environment.NewLine;
                sqlString += "      A.SECTIONCODERF" + Environment.NewLine;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                sqlString += "     ,A.SENDDESTSECCODERF" + Environment.NewLine;
                sqlString += "     ,A.AUTOSENDDIVRF" + Environment.NewLine;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                sqlString += "     ,A.SYNCEXECDATERF" + Environment.NewLine;
                sqlString += "     ,B.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "      SECMNGSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "     ,SECINFOSETRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += " WHERE";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //���_�R�[�h
                sqlString += " AND A.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString("00");
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                // ���(1:�}�X�^)
                sqlString += " AND A.KINDRF=@KINDRF ";
                SqlParameter paraKind = sqlCommand.Parameters.Add("@KINDRF", SqlDbType.Int);
                paraKind.Value = SqlDataMediator.SqlSetInt32(1);
                // ��M��(0:���M1:��M)
                sqlString += " AND A.RECEIVECONDITIONRF=@RECEIVECONDITIONRF ";
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITIONRF", SqlDbType.Int);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ";
                SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �_���폜�敪
                sqlString += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ";
                SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                //sqlString += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.SECTIONCODERF = B.SECTIONCODERF";//DEL 2011/07/25
                sqlString += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.SENDDESTSECCODERF = B.SECTIONCODERF";//ADD 2011/07/25


                sqlCommand.CommandText = sqlString;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSetWork = new APMSTSecMngSetWork();
                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                    secMngSetWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
                    secMngSetWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
                    //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
                    secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secMngSetArrList.Add(secMngSetWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MSTControlDB.SearchSyncExecDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MSTControlDB.SearchSyncExecDate Exception=" + e.Message);
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

        /// <summary>
        /// ��M�̃V���N�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�̃V���N�������擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            return SearchReceSyncExecDateProc(enterpriseCode, out secMngSetArrList);
        }
        /// <summary>
        /// ��M�̃V���N�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�̃V���N�������擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note: 2011/10/08 yangmj</br>
        /// <br>             Redmine #25778�̑Ή�</br>
        private int SearchReceSyncExecDateProc(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secMngSetArrList = new ArrayList();
            APMSTSecMngSetWork secMngSetWork = null;
            string resNm = "";

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            SqlTransaction sqlTransaction = null;
            string sqlString = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
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

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            resNm = GetResourceName(enterpriseCode);
            // MOD 2009/07/06 --->>>
            //�`�o���b�N
            status = Lock(resNm, 1, sqlConnection, sqlTransaction);
            // MOD 2009/07/06 ---<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            try
            {
                // Select�R�}���h�̐���
                sqlString += " SELECT" + Environment.NewLine;
                sqlString += "      A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "     ,A.SYNCEXECDATERF" + Environment.NewLine;
                sqlString += "     ,B.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "      SECMNGSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "     ,SECINFOSETRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "     ,SECMNGEPSETRF C WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += " WHERE";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                // ���(1:�}�X�^)
                sqlString += " AND A.KINDRF=@KINDRF ";
                SqlParameter paraKind = sqlCommand.Parameters.Add("@KINDRF", SqlDbType.Int);
                paraKind.Value = SqlDataMediator.SqlSetInt32(1);
                // ��M��(0:���M1:��M)
                sqlString += " AND A.RECEIVECONDITIONRF=@RECEIVECONDITIONRF ";
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITIONRF", SqlDbType.Int);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(1);
                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ";
                SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // �_���폜�敪
                sqlString += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ";
                SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlString += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.SECTIONCODERF = B.SECTIONCODERF ";
                sqlString += " AND A.ENTERPRISECODERF = C.ENTERPRISECODERF AND C.LOGICALDELETECODERF = 0 AND A.SECTIONCODERF = C.SECTIONCODERF ";

                sqlCommand.CommandText = sqlString;
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSetWork = new APMSTSecMngSetWork();
                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
                    secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secMngSetArrList.Add(secMngSetWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MSTControlDB.SearchSyncExecDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MSTControlDB.SearchSyncExecDate Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose(); // ADD 2011/10/08
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

        /// <summary>
        /// PM��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="pmCode">PM��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM��ƃR�[�h���擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        public int SeachPmCode(string enterpriseCode, string baseCode, out string pmCode)
        {
            return SeachPmCodeProc(enterpriseCode,  baseCode, out  pmCode);
        }
        /// <summary>
        /// PM��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="pmCode">PM��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM��ƃR�[�h���擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        private int SeachPmCodeProc(string enterpriseCode, string baseCode, out string pmCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            pmCode = string.Empty;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Select�R�}���h�̐���
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.PMENTERPRISECODERF " + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGEPSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += " WHERE ";
                // ��ƃR�[�h
                sqlString += " A.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // �_���폜�敪
                sqlString += " AND A.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                // ���_�Ǘ���M�敪
                sqlString += " AND A.SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                sqlCommand.CommandText = sqlString;

                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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

        #region �� ���_�Ǘ��ݒ�}�X�^�̍X�V���� ��

         /// <summary>
        /// ���M���_�Ǘ��ݒ�}�X�^�̍X�V����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N����</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M���_�Ǘ��ݒ�}�X�^�̍X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        public int UpdateSecMngSet(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            return UpdateSecMngSetProc(enterpriseCodes, baseCode, updEmployeeCode, syncExecDt, out retMessage);
        }
        /// <summary>
        /// ���M���_�Ǘ��ݒ�}�X�^�̍X�V����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N����</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M���_�Ǘ��ݒ�}�X�^�̍X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        private int UpdateSecMngSetProc(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

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
                sqlCommand = new SqlCommand("", sqlConnection);

                if (string.IsNullOrEmpty(updEmployeeCode))
                {
                    // ���_�Ǘ��ݒ�}�X�^���X�V����
                    //sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE";//DEL 2011/07/25
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE AND SENDDESTSECCODERF = @SENDDESTSECCODE";//ADD 2011/07/25

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }
                else
                {
                    // ���_�Ǘ��ݒ�}�X�^���X�V����
                    //sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";//DEL 2011/07/25
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE AND SENDDESTSECCODERF = @SENDDESTSECCODE";//ADD 2011/07/25

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updEmployeeCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }



                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter findSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);//ADD 2011/07/25

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(1);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                //findSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);//DEL 2011/07/25
                //-----ADD 2011/07/25----->>>>>
                findSectionCode.Value = SqlDataMediator.SqlSetString("00");
                findSendDestSecCode.Value = SqlDataMediator.SqlSetString(baseCode);
                //-----ADD 2011/07/25-----<<<<<

                // ���_�Ǘ��ݒ�}�X�^���X�V����
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.UpdateSecMngSet Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            return status;
        }

        /// <summary>
        /// ��M���_�Ǘ��ݒ�}�X�^�̍X�V����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N����</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M���_�Ǘ��ݒ�}�X�^�̍X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        public int UpdateReceSecMngSet(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            return UpdateReceSecMngSetProc( enterpriseCodes,  baseCode,  updEmployeeCode,  syncExecDt, out  retMessage);
        }
        /// <summary>
        /// ��M���_�Ǘ��ݒ�}�X�^�̍X�V����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N����</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M���_�Ǘ��ݒ�}�X�^�̍X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        private int UpdateReceSecMngSetProc(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

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
                sqlCommand = new SqlCommand("", sqlConnection);

                if (string.IsNullOrEmpty(updEmployeeCode))
                {
                    // ���_�Ǘ��ݒ�}�X�^���X�V����
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE";

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }
                else
                {
                    // ���_�Ǘ��ݒ�}�X�^���X�V����
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE";

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updEmployeeCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }



                //Parameter�I�u�W�F�N�g�̍쐬(�����p)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�(�����p)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(1);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(1);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                // ���_�Ǘ��ݒ�}�X�^���X�V����
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.UpdateReceSecMngSet Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            return status;
        }

        #endregion �� ���_�Ǘ��ݒ�}�X�^�̍X�V���� ��

        # region �� �}�X�^���M�̃f�[�^�������� ��
        /// <summary>
        /// �}�X�^���M�̃f�[�^��������
        /// </summary>
        /// <param name="masterDivList">�}�X�^���̋敪</param>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="updSectionCode">���_�R�[�h</param>
        /// <param name="beginningDate">�J�n���t</param>
        /// <param name="endingDate">�I�����t</param>
        /// <param name="retCSAList">��������</param>
        /// <param name="sndRcvHisConsNo">���M�ԍ�</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// 
        //public int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out string retMessage)//DEL 2011/07/25
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, string updSectionCode, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out int sndRcvHisConsNo, out string retMessage)//ADD 2011/07/25
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            sndRcvHisConsNo = -1; //ADD 2011/07/25
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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



#if DEBUG
                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                retCSAList = new CustomSerializeArrayList();

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // ���_�ݒ�}�X�^
                    if (MST_SECINFOSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_SECINFOSET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        secInfoSetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ����ݒ�}�X�^
                    if (MST_SUBSECTION.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUBSECTION.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        subSectionInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �q�ɐݒ�}�X�^
                    if (MST_WAREHOUSE.Equals(secMngSndRcvWork.MasterName) && MST_ID_WAREHOUSE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        warehouseInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �]�ƈ��}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �]�ƈ��ڍ׃}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���Ӑ�}�X�^
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���Ӑ�}�X�^(�ϓ����)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMECHA.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerChangeInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                    // ���Ӑ�}�X�^(�������)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEMEMO.Equals(secMngSndRcvWork.FileId)
                        &&  Convert.ToInt32(CusMemoSedDiv.Add) == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerMemoInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    // ���Ӑ�}�X�^�i�`�[�Ǘ��j
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPMNG.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custSlipMngInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���Ӑ�}�X�^�i�|���O���[�v�j
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEGROUP.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custRateGroupInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���Ӑ�}�X�^(�`�[�ԍ�)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPNO.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custSlipNoSetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �d����}�X�^
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�J�[�}�X�^�i���[�U�[�o�^���j
                    if (MST_MAKERU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MAKERU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        makerUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
                    if (MST_BLGOODSCDU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGOODSCDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        bLGoodsCdUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�}�X�^�i���[�U�[�o�^�j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUPRI.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsPriceInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�Ǘ����}�X�^
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUMNG.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsMngInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �������i�}�X�^
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUISO.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        isolIslandPrcInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �݌Ƀ}�X�^
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    if (MST_USERGDAREADIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdAreaDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    if (MST_USERGDBUSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBusDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    if (MST_USERGDCATEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdCateUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    if (MST_USERGDBUSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBusUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (MST_USERGDGOODSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdGoodsDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    if (MST_USERGDCUSGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdCusGrouPUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    if (MST_USERGDBANKU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBankUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (MST_USERGDPRIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdPriDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    if (MST_USERGDDELIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdDeliDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    if (MST_USERGDGOODSBIGU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdGoodsBigUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    if (MST_USERGDSTOCKDIVOU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdStockDivOUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    if (MST_USERGDSTOCKDIVTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdStockDivTUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    if (MST_USERGDRETURNREAU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdReturnReaUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �|���D��Ǘ��}�X�^
                    if (MST_RATEPROTYMNG.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATEPROTYMNG.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        rateProtyMngInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �|���}�X�^
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�Z�b�g�}�X�^
                    if (MST_GOODSSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSSET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsSetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i��փ}�X�^�i���[�U�[�o�^���j
                    if (MST_PARTSSUBSTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSSUBSTU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        partsSubstUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        empSalesTargetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custSalesTargetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GCDSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        gcdSalesTargetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�����ރ}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSMGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSMGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsMGroupUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
                    if (MST_BLGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        bLGroupUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �����}�X�^�i���[�U�[�o�^���j
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // TBO�����}�X�^�i���[�U�[�o�^�j
                    if (MST_TBOSEARCHU.Equals(secMngSndRcvWork.MasterName) && MST_ID_TBOSEARCHU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        tBOSearchUCountInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
                    if (MST_PARTSPOSCODEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSPOSCODEU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        partsPosCodeUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // BL�R�[�h�K�C�h�}�X�^
                    if (MST_BLCODEGUIDE.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLCODEGUIDE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        bLCodeGuideInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �Ԏ햼�̃}�X�^
                    if (MST_MODELNAMEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MODELNAMEU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        modelNameUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                }


                if (secInfoSetInt == 1)
                {
                    // ���_���ݒ�}�X�^�f�[�^���o
                    ArrayList secInfoSetArrList = new ArrayList();
                    APSecInfoSetDB _secInfoSetDB = new APSecInfoSetDB();
                    status = _secInfoSetDB.SearchSecInfoSet(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out secInfoSetArrList, out retMessage);
                    retCSAList.Add(secInfoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && subSectionInt == 1)
                {

                    // ����}�X�^�f�[�^���o
                    ArrayList subSectionArrList = new ArrayList();
                    APSubSectionDB _subSectionDB = new APSubSectionDB();
                    status = _subSectionDB.SearchSubSection(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out subSectionArrList, out retMessage);
                    retCSAList.Add(subSectionArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt == 1)
                {
                    // �]�ƈ��}�X�^�f�[�^���o
                    ArrayList employeeArrList = new ArrayList();
                    APEmployeeDB _employeeDB = new APEmployeeDB();
                    status = _employeeDB.SearchEmployee(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    retCSAList.Add(employeeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt == 1)
                {
                    // �]�ƈ��ڍ׃}�X�^�f�[�^���o
                    ArrayList employeeDtlArrList = new ArrayList();
                    APEmployeeDtlDB _employeeDtlDB = new APEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    retCSAList.Add(employeeDtlArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInt == 1)
                {
                    // �q�Ƀ}�X�^�f�[�^���o
                    ArrayList warehouseArrList = new ArrayList();
                    APWarehouseDB _warehouseDB = new APWarehouseDB();
                    status = _warehouseDB.SearchWarehouse(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out warehouseArrList, out retMessage);
                    retCSAList.Add(warehouseArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInt == 1)
                {
                    // ���Ӑ�}�X�^�f�[�^���o
                    ArrayList customerArrList = new ArrayList();
                    APCustomerDB _customerDB = new APCustomerDB();
                    status = _customerDB.SearchCustomer(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    retCSAList.Add(customerArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerChangeInt == 1)
                {
                    // ���Ӑ�}�X�^(�ϓ����)�f�[�^���o
                    ArrayList customerChangeArrList = new ArrayList();
                    APCustomerChangeDB _customerChangeDB = new APCustomerChangeDB();
                    status = _customerChangeDB.SearchCustomerChange(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    retCSAList.Add(customerChangeArrList);
                }
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.Add))
                {
                    // ���Ӑ�}�X�^(�������)�f�[�^���o
                    ArrayList customerMemoArrList = new ArrayList();
                    APCustomerMemoDB _customerMemoDB = new APCustomerMemoDB();
                    status = _customerMemoDB.SearchCustomerMemo(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerMemoArrList, out retMessage);
                    retCSAList.Add(customerMemoArrList);
                }
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipMngInt == 1)
                {
                    // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^���o
                    ArrayList custSlipMngArrList = new ArrayList();
                    APCustSlipMngDB _custSlipMngDB = new APCustSlipMngDB();
                    status = _custSlipMngDB.SearchCustSlipMng(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    retCSAList.Add(custSlipMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custRateGroupInt == 1)
                {
                    // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���o
                    ArrayList custRateGroupArrList = new ArrayList();
                    APCustRateGroupDB _custRateGroupDB = new APCustRateGroupDB();
                    status = _custRateGroupDB.SearchCustRateGroup(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    retCSAList.Add(custRateGroupArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipNoSetInt == 1)
                {
                    // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^���o
                    ArrayList custSlipNoSetArrList = new ArrayList();
                    APCustSlipNoSetDB _custSlipNoSetDB = new APCustSlipNoSetDB();
                    status = _custSlipNoSetDB.SearchCustSlipNoSet(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    retCSAList.Add(custSlipNoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt == 1)
                {
                    // �d����}�X�^�f�[�^���o
                    ArrayList supplierArrList = new ArrayList();
                    APSupplierDB _supplierDB = new APSupplierDB();
                    status = _supplierDB.SearchSupplier(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    retCSAList.Add(supplierArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUInt == 1)
                {
                    ArrayList makerUArrList = new ArrayList();
                    APMakerUDB _makerUDB = new APMakerUDB();
                    // ���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    status = _makerUDB.SearchMakerU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref makerUArrList, out retMessage);
                    retCSAList.Add(makerUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGoodsCdUInt == 1)
                {
                    // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList bLGoodsCdUArrList = new ArrayList();
                    APBLGoodsCdUDB _bLGoodsCdUDB = new APBLGoodsCdUDB();
                    status = _bLGoodsCdUDB.SearchBLGoodsCdU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGoodsCdUArrList, out retMessage);
                    retCSAList.Add(bLGoodsCdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUInt == 1)
                {
                    // ���i�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList goodsUArrList = new ArrayList();
                    APGoodsUDB _goodsUDB = new APGoodsUDB();
                    status = _goodsUDB.SearchGoodsU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsUArrList, out retMessage);
                    retCSAList.Add(goodsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsPriceInt == 1)
                {
                    // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    ArrayList goodsPriceUArrList = new ArrayList();
                    APGoodsPriceUDB _goodsPriceUDB = new APGoodsPriceUDB();
                    status = _goodsPriceUDB.SearchGoodsPriceU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    retCSAList.Add(goodsPriceUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMngInt == 1)
                {
                    // ���i�Ǘ����}�X�^�f�[�^���o
                    ArrayList goodsMngArrList = new ArrayList();
                    APGoodsMngDB _goodsMngDB = new APGoodsMngDB();
                    status = _goodsMngDB.SearchGoodsMng(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsMngArrList, out retMessage);
                    retCSAList.Add(goodsMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isolIslandPrcInt == 1)
                {
                    // �������i�}�X�^�f�[�^���o
                    ArrayList isolIslandPrcArrList = new ArrayList();
                    APIsolIslandPrcDB _isolIslandPrcDB = new APIsolIslandPrcDB();
                    status = _isolIslandPrcDB.SearchIsolIslandPrc(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    retCSAList.Add(isolIslandPrcArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt == 1)
                {
                    // �݌Ƀ}�X�^�f�[�^���o
                    ArrayList stockArrList = new ArrayList();
                    APStockDB _stockDB = new APStockDB();
                    status = _stockDB.SearchStock(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    retCSAList.Add(stockArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���[�U�[�K�C�h�}�X�^�f�[�^���o
                    ArrayList userGdBdUArrList = new ArrayList();
                    APUserGdBdUDB _userGdBdUDB = new APUserGdBdUDB();
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    if (userGdAreaDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(21, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    if (userGdBusDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(31, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    if (userGdCateUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(33, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    if (userGdBusUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(34, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (userGdGoodsDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(41, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    if (userGdCusGrouPUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(43, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    if (userGdBankUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(46, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (userGdPriDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(47, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    if (userGdDeliDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(48, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    if (userGdGoodsBigUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(70, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (userGdBuyDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(71, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    if (userGdStockDivOUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(72, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    if (userGdStockDivTUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(73, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    if (userGdReturnReaUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(91, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    retCSAList.Add(userGdBdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateProtyMngInt == 1)
                {
                    // �|���D��Ǘ��}�X�^�f�[�^���o
                    ArrayList rateProtyMngArrList = new ArrayList();
                    APRateProtyMngDB _rateProtyMngDB = new APRateProtyMngDB();
                    status = _rateProtyMngDB.SearchRateProtyMng(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateProtyMngArrList, out retMessage);
                    retCSAList.Add(rateProtyMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt == 1)
                {
                    // �|���}�X�^�f�[�^���o
                    ArrayList rateArrList = new ArrayList();
                    APRateDB _rateDB = new APRateDB();
                    status = _rateDB.SearchRate(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                    retCSAList.Add(rateArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsSetInt == 1)
                {
                    // ���i�Z�b�g�}�X�^�f�[�^���o
                    ArrayList goodsSetArrList = new ArrayList();
                    APGoodsSetDB _goodsSetDB = new APGoodsSetDB();
                    status = _goodsSetDB.SearchGoodsSet(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsSetArrList, out retMessage);
                    retCSAList.Add(goodsSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsSubstUInt == 1)
                {
                    // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList partsSubstUArrList = new ArrayList();
                    APPartsSubstUDB _partsSubstUDB = new APPartsSubstUDB();
                    status = _partsSubstUDB.SearchPartsSubstU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsSubstUArrList, out retMessage);
                    retCSAList.Add(partsSubstUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && empSalesTargetInt == 1)
                {
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^���o
                    ArrayList empSalesTargetArrList = new ArrayList();
                    APEmpSalesTargetDB _empSalesTargetDB = new APEmpSalesTargetDB();
                    status = _empSalesTargetDB.SearchEmpSalesTarget(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out empSalesTargetArrList, out retMessage);
                    retCSAList.Add(empSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSalesTargetInt == 1)
                {
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^���o
                    ArrayList custSalesTargetArrList = new ArrayList();
                    APCustSalesTargetDB _custSalesTargetDB = new APCustSalesTargetDB();
                    status = _custSalesTargetDB.SearchCustSalesTarget(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSalesTargetArrList, out retMessage);
                    retCSAList.Add(custSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && gcdSalesTargetInt == 1)
                {
                    // ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^���o
                    ArrayList gcdSalesTargetArrList = new ArrayList();
                    APGcdSalesTargetDB _gcdSalesTargetDB = new APGcdSalesTargetDB();
                    status = _gcdSalesTargetDB.SearchGcdSalesTarget(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out gcdSalesTargetArrList, out retMessage);
                    retCSAList.Add(gcdSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMGroupUInt == 1)
                {
                    // ���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList goodsGroupUArrList = new ArrayList();
                    APGoodsGroupUDB _goodsGroupUDB = new APGoodsGroupUDB();
                    status = _goodsGroupUDB.SearchGoodsGroupU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsGroupUArrList, out retMessage);
                    retCSAList.Add(goodsGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGroupUInt == 1)
                {
                    // BL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList bLGroupUArrList = new ArrayList();
                    APBLGroupUDB _bLGroupUDB = new APBLGroupUDB();
                    status = _bLGroupUDB.SearchBLGroupU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGroupUArrList, out retMessage);
                    retCSAList.Add(bLGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt == 1)
                {
                    // �����}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList joinPartsUArrList = new ArrayList();
                    APJoinPartsUDB _joinPartsUDB = new APJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    retCSAList.Add(joinPartsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && tBOSearchUCountInt == 1)
                {
                    // TBO�����}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    ArrayList tBOSearchUArrList = new ArrayList();
                    APTBOSearchUDB _tBOSearchUDB = new APTBOSearchUDB();
                    status = _tBOSearchUDB.SearchTBOSearchU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out tBOSearchUArrList, out retMessage);
                    retCSAList.Add(tBOSearchUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsPosCodeUInt == 1)
                {
                    // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    ArrayList partsPosCodeUArrList = new ArrayList();
                    APPartsPosCodeUDB _partsPosCodeUDB = new APPartsPosCodeUDB();
                    status = _partsPosCodeUDB.SearchPartsPosCodeU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsPosCodeUArrList, out retMessage);
                    retCSAList.Add(partsPosCodeUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLCodeGuideInt == 1)
                {
                    // BL�R�[�h�K�C�h�}�X�^�f�[�^���o
                    ArrayList bLCodeGuideArrList = new ArrayList();
                    APBLCodeGuideDB _bLCodeGuideDB = new APBLCodeGuideDB();
                    status = _bLCodeGuideDB.SearchBLCodeGuide(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLCodeGuideArrList, out retMessage);
                    retCSAList.Add(bLCodeGuideArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && modelNameUInt == 1)
                {
                    // ����}�X�^�f�[�^���o
                    ArrayList modelNameUArrList = new ArrayList();
                    APModelNameUDB _modelNameUDB = new APModelNameUDB();
                    status = _modelNameUDB.SearchModelNameU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out modelNameUArrList, out retMessage);
                    retCSAList.Add(modelNameUArrList);
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                if (retCSAList.Count > 0)
                {
                    long no = -1;
                    NumberingManager numberingManager = new NumberingManager();
                    SerialNumberCode serialnumcd = SerialNumberCode.SndRcvHisConsNo;
                    status = numberingManager.GetSerialNumber(enterpriseCodes, updSectionCode.Trim(), serialnumcd, out no);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                    {
                        sndRcvHisConsNo = (int)no;
                    }
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
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
        /// �}�X�^���M�̍X�V����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="masterDtlDivList">�}�X�^�ڍ׋敪</param>
        /// <param name="retCSAList">�V���N����</param>
        /// <param name="pmEnterpriseCode">PM��ƃR�[�h</param>
        /// <param name="isEmpty">�󔻒f</param>
        /// <param name="searchCountWork">�������[�N</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �}�X�^���M�̍X�V����������B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        public int Update(string enterpriseCode, ArrayList masterDivList, ArrayList masterDtlDivList, ref CustomSerializeArrayList retCSAList, string pmEnterpriseCode, out bool isEmpty, out MstSearchCountWorkWork searchCountWork, out string retMessage)
        {
            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���_���ݒ�f�[�^
            Int32 secInfoSetCount = 0;
            // ����}�X�^
            Int32 subSectionCount = 0;
            // �]�ƈ��}�X�^
            Int32 employeeCount = 0;
            // �]�ƈ��ڍ׃}�X�^
            Int32 employeeDtlCount = 0;
            // �q�Ƀ}�X�^
            Int32 warehouseCount = 0;
            // ���Ӑ�}�X�^
            Int32 customerCount = 0;
            // ���Ӑ�}�X�^(�ϓ����)
            Int32 customerChangeCount = 0;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            // ���Ӑ�}�X�^(�������)
            Int32 customerMemoCount = CNT_ZERO;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            // ���Ӑ�}�X�^�i�`�[�Ǘ��j
            Int32 custSlipMngCount = 0;
            // ���Ӑ�}�X�^�i�|���O���[�v�j
            Int32 custRateGroupCount = 0;
            // ���Ӑ�}�X�^(�`�[�ԍ�)
            Int32 custSlipNoSetCount = 0;
            // �d����}�X�^
            Int32 supplierCount = 0;
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j
            Int32 makerUCount = 0;
            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            Int32 bLGoodsCdUCount = 0;
            // ���i�}�X�^�i���[�U�[�o�^���j
            Int32 goodsUCount = 0;
            // ���i�}�X�^�i���[�U�[�o�^�j
            Int32 goodsPriceCount = 0;
            // ���i�Ǘ����}�X�^
            Int32 goodsMngCount = 0;
            // �������i�}�X�^
            Int32 isolIslandPrcCount = 0;
            // �݌Ƀ}�X�^
            Int32 stockCount = 0;
            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
            Int32 userGdAreaDivUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
            Int32 userGdBusDivUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
            Int32 userGdCateUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�E��j
            Int32 userGdBusUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
            Int32 userGdGoodsDivUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
            Int32 userGdCusGrouPUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i��s�j
            Int32 userGdBankUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
            Int32 userGdPriDivUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
            Int32 userGdDeliDivUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
            Int32 userGdGoodsBigUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
            Int32 userGdBuyDivUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
            Int32 userGdStockDivOUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
            Int32 userGdStockDivTUCount = 0;
            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
            Int32 userGdReturnReaUCount = 0;
            // �|���D��Ǘ��}�X�^
            Int32 rateProtyMngCount = 0;
            // �|���}�X�^
            Int32 rateCount = 0;
            // ���i�Z�b�g�}�X�^
            Int32 goodsSetCount = 0;
            // ���i��փ}�X�^�i���[�U�[�o�^���j
            Int32 partsSubstUCount = 0;
            // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
            Int32 empSalesTargetCount = 0;
            // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
            Int32 custSalesTargetCount = 0;
            // ���i�ʔ���ڕW�ݒ�}�X�^
            Int32 gcdSalesTargetCount = 0;
            // ���i�����ރ}�X�^�i���[�U�[�o�^���j
            Int32 goodsMGroupUCount = 0;
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            Int32 bLGroupUCount = 0;
            // �����}�X�^�i���[�U�[�o�^���j
            Int32 joinPartsUCount = 0;
            // TBO�����}�X�^�i���[�U�[�o�^�j
            Int32 tBOSearchUCount = 0;
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            Int32 partsPosCodeUCount = 0;
            // BL�R�[�h�K�C�h�}�X�^
            Int32 bLCodeGuideCount = 0;
            // �Ԏ햼�̃}�X�^
            Int32 modelNameUCount = 0;

            searchCountWork = new MstSearchCountWorkWork();

            // private field
            APSecInfoSetDB _secInfoSetDB = new APSecInfoSetDB();
            APSecInfoSetWork secInfoSetWork = new APSecInfoSetWork();
            APSubSectionDB _subSectionDB = new APSubSectionDB();
            APSubSectionWork subSectionWork = new APSubSectionWork();
            APEmployeeDB _employeeDB = new APEmployeeDB();
            APEmployeeWork employeeWork = new APEmployeeWork();
            APEmployeeDtlDB _employeeDtlDB = new APEmployeeDtlDB();
            APEmployeeDtlWork employeeDtlWork = new APEmployeeDtlWork();
            APWarehouseDB _warehouseDB = new APWarehouseDB();
            APWarehouseWork warehouseWork = new APWarehouseWork();
            APCustomerDB _customerWorkDB = new APCustomerDB();
            APCustomerWork customerWork = new APCustomerWork();
            APCustomerChangeDB _customerChangeDB = new APCustomerChangeDB();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            APCustomerMemoDB _customerMemoDB = new APCustomerMemoDB();
            APCustomerMemoWork customerMemoWork = new APCustomerMemoWork();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            APCustomerChangeWork customerChangeWork = new APCustomerChangeWork();
            APCustSlipMngDB _custSlipMngDB = new APCustSlipMngDB();
            APCustSlipMngWork custSlipMngWork = new APCustSlipMngWork();
            APCustRateGroupDB _custRateGroupDB = new APCustRateGroupDB();
            APCustRateGroupWork custRateGroupWork = new APCustRateGroupWork();
            APCustSlipNoSetDB _custSlipNoSetDB = new APCustSlipNoSetDB();
            APCustSlipNoSetWork custSlipNoSetWork = new APCustSlipNoSetWork();
            APSupplierDB _supplierDB = new APSupplierDB();
            APSupplierWork supplierWork = new APSupplierWork();
            APMakerUDB _makerUWorkDB = new APMakerUDB();
            APMakerUWork makerUWork = new APMakerUWork();
            APBLGoodsCdUDB _bLGoodsCdUWorkDB = new APBLGoodsCdUDB();
            APBLGoodsCdUWork bLGoodsCdUWork = new APBLGoodsCdUWork();
            APGoodsUDB _goodsUDB = new APGoodsUDB();
            APGoodsUWork goodsUWork = new APGoodsUWork();
            APGoodsPriceUDB _goodsPriceUDB = new APGoodsPriceUDB();
            APGoodsPriceUWork goodsPriceUWork = new APGoodsPriceUWork();
            APGoodsMngDB _goodsMngDB = new APGoodsMngDB();
            APGoodsMngWork goodsMngWork = new APGoodsMngWork();
            APIsolIslandPrcDB _isolIslandPrcDB = new APIsolIslandPrcDB();
            APIsolIslandPrcWork isolIslandPrcWork = new APIsolIslandPrcWork();
            APStockDB _stockDB = new APStockDB();
            APStockWork stockWork = new APStockWork();
            APUserGdBdUDB _userGdBdUDB = new APUserGdBdUDB();
            APUserGdBdUWork userGdBdUWork = new APUserGdBdUWork();
            APRateProtyMngDB _rateProtyMngDB = new APRateProtyMngDB();
            APRateProtyMngWork rateProtyMngWork = new APRateProtyMngWork();
            APRateDB _rateDB = new APRateDB();
            APRateWork rateWork = new APRateWork();
            APGoodsSetDB _goodsSetDB = new APGoodsSetDB();
            APGoodsSetWork goodsSetWork = new APGoodsSetWork();
            APPartsSubstUDB _partsSubstUDB = new APPartsSubstUDB();
            APPartsSubstUWork partsSubstUWork = new APPartsSubstUWork();
            APEmpSalesTargetDB _empSalesTargetDB = new APEmpSalesTargetDB();
            APEmpSalesTargetWork empSalesTargetWork = new APEmpSalesTargetWork();
            APCustSalesTargetDB _custSalesTargetDB = new APCustSalesTargetDB();
            APCustSalesTargetWork custSalesTargetWork = new APCustSalesTargetWork();
            APGcdSalesTargetDB _gcdSalesTargetDB = new APGcdSalesTargetDB();
            APGcdSalesTargetWork gcdSalesTargetWork = new APGcdSalesTargetWork();
            APGoodsGroupUDB _goodsGroupUDB = new APGoodsGroupUDB();
            APGoodsGroupUWork goodsGroupUWork = new APGoodsGroupUWork();
            APBLGroupUDB _bLGroupUDB = new APBLGroupUDB();
            APBLGroupUWork bLGroupUWork = new APBLGroupUWork();
            APJoinPartsUDB _joinPartsUDB = new APJoinPartsUDB();
            APJoinPartsUWork joinPartsUWork = new APJoinPartsUWork();
            APTBOSearchUDB _tBOSearchUDB = new APTBOSearchUDB();
            APTBOSearchUWork tBOSearchUWork = new APTBOSearchUWork();
            APPartsPosCodeUDB _partsPosCodeUDB = new APPartsPosCodeUDB();
            APPartsPosCodeUWork partsPosCodeUWork = new APPartsPosCodeUWork();
            APBLCodeGuideDB _bLCodeGuideDB = new APBLCodeGuideDB();
            APBLCodeGuideWork bLCodeGuideWork = new APBLCodeGuideWork();
            APModelNameUDB _modelNameUDB = new APModelNameUDB();
            APModelNameUWork modelNameUWork = new APModelNameUWork();

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
            // ���i�}�X�^
            ArrayList _goodsUList = new ArrayList();

            // ���Ӑ�}�X�^�i�|���O���[�v�j
            ArrayList _custRateGroupListTmp = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^�j
            ArrayList _goodsPriceUListTmp = new ArrayList();
            // �|���D��Ǘ��}�X�^
            ArrayList _rateProtyMngListTmp = new ArrayList();
            // �|���}�X�^
            ArrayList _rateListTmp = new ArrayList();
            // ���i�Z�b�g�}�X�^
            ArrayList _goodsSetListTmp = new ArrayList();
            // �����}�X�^�i���[�U�[�o�^���j
            ArrayList _joinPartsUListTmp = new ArrayList();
            // TBO�������}�X�^�i���[�U�[�o�^���j
            ArrayList _tboSearchUListTmp = new ArrayList();
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            ArrayList _partsPosCodeUListTmp = new ArrayList();
            // BL�R�[�h�K�C�h�}�X�^
            ArrayList _blCodeGuideListTmp = new ArrayList();


            // ���Ӑ�}�X�^�i�|���O���[�v�j
            ArrayList _custRateGroupListDelTmp = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^�j
            ArrayList _goodsPriceUListDelTmp = new ArrayList();
            // �|���D��Ǘ��}�X�^
            ArrayList _rateProtyMngListDelTmp = new ArrayList();
            // �|���}�X�^
            ArrayList _rateListDelTmp = new ArrayList();
            // ���i�Z�b�g�}�X�^
            ArrayList _goodsSetListDelTmp = new ArrayList();
            // �����}�X�^�i���[�U�[�o�^���j
            ArrayList _joinPartsUListDelTmp = new ArrayList();
            // TBO�������}�X�^�i���[�U�[�o�^���j
            ArrayList _tboSearchUListDelTmp = new ArrayList();
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            ArrayList _partsPosCodeUListDelTmp = new ArrayList();
            // BL�R�[�h�K�C�h�}�X�^
            ArrayList _blCodeGuideListDelTmp = new ArrayList();


            retMessage = string.Empty;
            isEmpty = true;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

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

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
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
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                    // ���Ӑ�}�X�^(�������)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEMEMO.Equals(secMngSndRcvWork.FileId)
                        &&  Convert.ToInt32(CusMemoSedDiv.None) != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerMemoInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
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

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC���_���ݒ�}�X�^�X�V����
                        if (wktype.Equals(typeof(APSecInfoSetWork)))
                        {
                            _secInfoSetDB = new APSecInfoSetDB();
                            secInfoSetWork = (APSecInfoSetWork)retCSATemList[j];
                            secInfoSetWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (secInfoSetInt == 1)
                            {
                                status = _secInfoSetDB.SearchSecInfoSetCount(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    secInfoSetCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (secInfoSetInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                secInfoSetCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (secInfoSetInt == 3)
                            {
                                status = _secInfoSetDB.SearchSecInfoSetCount(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    secInfoSetCount++;
                                }
                            }
                        }
                        // DC����}�X�^�X�V����
                        else if (wktype.Equals(typeof(APSubSectionWork)))
                        {
                            _subSectionDB = new APSubSectionDB();
                            subSectionWork = (APSubSectionWork)retCSATemList[j];
                            subSectionWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (subSectionInt == 1)
                            {
                                status = _subSectionDB.SearchSubSectionCount(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    subSectionCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (subSectionInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                subSectionCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (subSectionInt == 3)
                            {
                                status = _subSectionDB.SearchSubSectionCount(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    subSectionCount++;
                                }
                            }
                        }
                        // DC�]�ƈ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(APEmployeeWork)))
                        {
                            _employeeDB = new APEmployeeDB();
                            employeeWork = (APEmployeeWork)retCSATemList[j];
                            employeeWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (employeeInt == 1)
                            {
                                status = _employeeDB.SearchEmployeeCount(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (employeeInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                employeeCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (employeeInt == 3)
                            {
                                status = _employeeDB.SearchEmployeeCount(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeCount++;
                                }
                            }
                        }
                        // DC�]�ƈ��ڍ׃}�X�^�X�V����
                        else if (wktype.Equals(typeof(APEmployeeDtlWork)))
                        {
                            _employeeDtlDB = new APEmployeeDtlDB();
                            employeeDtlWork = (APEmployeeDtlWork)retCSATemList[j];
                            employeeDtlWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (employeeDtlInt == 1)
                            {
                                status = _employeeDtlDB.SearchEmployeeDtlCount(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeDtlCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (employeeDtlInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                employeeDtlCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (employeeDtlInt == 3)
                            {
                                status = _employeeDtlDB.SearchEmployeeDtlCount(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeDtlCount++;
                                }
                            }
                        }
                        // DC�q�Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(APWarehouseWork)))
                        {
                            _warehouseDB = new APWarehouseDB();
                            warehouseWork = (APWarehouseWork)retCSATemList[j];
                            warehouseWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (warehouseInt == 1)
                            {
                                status = _warehouseDB.SearchWarehouseCount(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    warehouseCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (warehouseInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                warehouseCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (warehouseInt == 3)
                            {
                                status = _warehouseDB.SearchWarehouseCount(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    warehouseCount++;
                                }
                            }
                        }
                        // DC���Ӑ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APCustomerWork)))
                        {
                            _customerWorkDB = new APCustomerDB();
                            customerWork = (APCustomerWork)retCSATemList[j];
                            customerWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (customerInt == 1)
                            {
                                status = _customerWorkDB.SearchCustomerCount(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (customerInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                customerCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (customerInt == 3)
                            {
                                status = _customerWorkDB.SearchCustomerCount(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerCount++;
                                }
                            }
                        }
                        // DC���Ӑ�}�X�^(�ϓ����)�X�V����
                        else if (wktype.Equals(typeof(APCustomerChangeWork)))
                        {
                            _customerChangeDB = new APCustomerChangeDB();
                            customerChangeWork = (APCustomerChangeWork)retCSATemList[j];
                            customerChangeWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (customerChangeInt == 1)
                            {
                                status = _customerChangeDB.SearchCustomerChangeCount(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerChangeCount++; 
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (customerChangeInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                customerChangeCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (customerChangeInt == 3)
                            {
                                status = _customerChangeDB.SearchCustomerChangeCount(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerChangeCount++;
                                }
                            }
                        }
                        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                        // DC���Ӑ�}�X�^(�������)�X�V����
                        else if (wktype.Equals(typeof(APCustomerMemoWork)))
                        {
                            _customerMemoDB = new APCustomerMemoDB();
                            customerMemoWork = (APCustomerMemoWork)retCSATemList[j];
                            customerMemoWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.Add))
                            {
                                status = _customerMemoDB.SearchCustomerMemoCount(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerMemoCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.AddUpd))
                            {
                                // ���݂���f�[�^���폜����B
                                _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                customerMemoCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.Upd))
                            {
                                status = _customerMemoDB.SearchCustomerMemoCount(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerMemoCount++;
                                }
                            }
                        }
                        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                        // DC���Ӑ�}�X�^�i�`�[�Ǘ��j�X�V����
                        else if (wktype.Equals(typeof(APCustSlipMngWork)))
                        {
                            _custSlipMngDB = new APCustSlipMngDB();
                            custSlipMngWork = (APCustSlipMngWork)retCSATemList[j];
                            custSlipMngWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (custSlipMngInt == 1)
                            {
                                status = _custSlipMngDB.SearchCustSlipMngCount(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipMngCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (custSlipMngInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                custSlipMngCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (custSlipMngInt == 3)
                            {
                                status = _custSlipMngDB.SearchCustSlipMngCount(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipMngCount++;
                                }
                            }
                        }
                        // DC���Ӑ�}�X�^�i�|���O���[�v�j�X�V����
                        else if (wktype.Equals(typeof(APCustRateGroupWork)))
                        {
                            custRateGroupWork = (APCustRateGroupWork)retCSATemList[j];
                            custRateGroupWork.EnterpriseCode = enterpriseCode;

                            _custRateGroupList.Add(custRateGroupWork);
                        }
                        // DC���Ӑ�}�X�^(�`�[�ԍ�)�X�V����
                        else if (wktype.Equals(typeof(APCustSlipNoSetWork)))
                        {
                            _custSlipNoSetDB = new APCustSlipNoSetDB();
                            custSlipNoSetWork = (APCustSlipNoSetWork)retCSATemList[j];
                            custSlipNoSetWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (custSlipNoSetInt == 1)
                            {
                                status = _custSlipNoSetDB.SearchCustSlipNoSetCount(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipNoSetCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (custSlipNoSetInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                custSlipNoSetCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (custSlipNoSetInt == 3)
                            {
                                status = _custSlipNoSetDB.SearchCustSlipNoSetCount(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipNoSetCount++;
                                }
                            }
                        }
                        // DC�d����}�X�^�X�V����
                        else if (wktype.Equals(typeof(APSupplierWork)))
                        {
                            _supplierDB = new APSupplierDB();
                            supplierWork = (APSupplierWork)retCSATemList[j];
                            supplierWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (supplierInt == 1)
                            {
                                status = _supplierDB.SearchSupplierCount(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    supplierCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (supplierInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                supplierCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (supplierInt == 3)
                            {
                                status = _supplierDB.SearchSupplierCount(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    supplierCount++;
                                }
                            }
                        }
                        // DC���[�J�[�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APMakerUWork)))
                        {
                            _makerUWorkDB = new APMakerUDB();
                            makerUWork = (APMakerUWork)retCSATemList[j];
                            makerUWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (makerUInt == 1)
                            {
                                status = _makerUWorkDB.SearchMakerUCount(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    makerUCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (makerUInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                makerUCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (makerUInt == 3)
                            {
                                status = _makerUWorkDB.SearchMakerUCount(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    makerUCount++;
                                }
                            }
                        }
                        // DCBL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APBLGoodsCdUWork)))
                        {
                            _bLGoodsCdUWorkDB = new APBLGoodsCdUDB();
                            bLGoodsCdUWork = (APBLGoodsCdUWork)retCSATemList[j];
                            bLGoodsCdUWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (bLGoodsCdUInt == 1)
                            {
                                status = _bLGoodsCdUWorkDB.SearchBLGoodsCdUCount(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGoodsCdUCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (bLGoodsCdUInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                bLGoodsCdUCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (bLGoodsCdUInt == 3)
                            {
                                status = _bLGoodsCdUWorkDB.SearchBLGoodsCdUCount(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGoodsCdUCount++;
                                }
                            }
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APGoodsUWork)))
                        {
                            goodsUWork = (APGoodsUWork)retCSATemList[j];
                            goodsUWork.EnterpriseCode = enterpriseCode;

                            _goodsUList.Add(goodsUWork);

                        }
                        // DC���i�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(APGoodsPriceUWork)))
                        {
                            goodsPriceUWork = (APGoodsPriceUWork)retCSATemList[j];
                            goodsPriceUWork.EnterpriseCode = enterpriseCode;

                            _goodsPriceUList.Add(goodsPriceUWork);
                        }
                        // DC���i�Ǘ����}�X�^�X�V����
                        else if (wktype.Equals(typeof(APGoodsMngWork)))
                        {
                            _goodsMngDB = new APGoodsMngDB();
                            goodsMngWork = (APGoodsMngWork)retCSATemList[j];
                            goodsMngWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (goodsMngInt == 1)
                            {
                                status = _goodsMngDB.SearchGoodsMngCount(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMngCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (goodsMngInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsMngCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (goodsMngInt == 3)
                            {
                                status = _goodsMngDB.SearchGoodsMngCount(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMngCount++;
                                }
                            }
                        }
                        // DC�������i�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APIsolIslandPrcWork)))
                        {
                            _isolIslandPrcDB = new APIsolIslandPrcDB();
                            isolIslandPrcWork = (APIsolIslandPrcWork)retCSATemList[j];
                            isolIslandPrcWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (isolIslandPrcInt == 1)
                            {
                                status = _isolIslandPrcDB.SearchIsolIslandPrcCount(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    isolIslandPrcCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (isolIslandPrcInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                isolIslandPrcCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (isolIslandPrcInt == 3)
                            {
                                status = _isolIslandPrcDB.SearchIsolIslandPrcCount(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    isolIslandPrcCount++;
                                }
                            }
                        }
                        // DC�݌Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(APStockWork)))
                        {
                            _stockDB = new APStockDB();
                            stockWork = (APStockWork)retCSATemList[j];
                            stockWork.EnterpriseCode = enterpriseCode;

                            status = _stockDB.SearchStockCount(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            // ��M�敪����M����i�ǉ��̂݁j
                            if (stockInt == 1)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    //_stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//DEL 2011/09/06 #24252
                                    _stockDB.Insert(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//ADD 2011/09/06 #24252
                                    stockCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (stockInt == 2)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    //_stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//DEL 2011/09/06 #24252
                                    _stockDB.Insert(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//ADD 2011/09/06 #24252
                                    stockCount++;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _stockDB.Update(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    stockCount++;
                                }
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (stockInt == 3)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _stockDB.Update(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    stockCount++;
                                }
                            }
                        }
                        // DC���[�U�[�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APUserGdBdUWork)))
                        {
                            _userGdBdUDB = new APUserGdBdUDB();
                            userGdBdUWork = (APUserGdBdUWork)retCSATemList[j];
                            userGdBdUWork.EnterpriseCode = enterpriseCode;

                            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                            if (userGdBdUWork.UserGuideDivCd == 21)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdAreaDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdAreaDivUCount++; 
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdAreaDivUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdAreaDivUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdAreaDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdAreaDivUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                            else if (userGdBdUWork.UserGuideDivCd == 31)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdBusDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusDivUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdBusDivUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBusDivUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdBusDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusDivUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                            else if (userGdBdUWork.UserGuideDivCd == 33)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdCateUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCateUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdCateUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdCateUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdCateUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCateUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�E��j
                            else if (userGdBdUWork.UserGuideDivCd == 34)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdBusUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusUCount++; 
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdBusUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBusUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdBusUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (userGdBdUWork.UserGuideDivCd == 41)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdGoodsDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsDivUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdGoodsDivUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdGoodsDivUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdGoodsDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsDivUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                            else if (userGdBdUWork.UserGuideDivCd == 43)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdCusGrouPUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCusGrouPUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdCusGrouPUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdCusGrouPUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdCusGrouPUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCusGrouPUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i��s�j
                            else if (userGdBdUWork.UserGuideDivCd == 46)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdBankUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBankUCount++; 
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdBankUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBankUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdBankUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBankUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (userGdBdUWork.UserGuideDivCd == 47)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdPriDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdPriDivUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdPriDivUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdPriDivUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdPriDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdPriDivUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                            else if (userGdBdUWork.UserGuideDivCd == 48)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdDeliDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdDeliDivUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdDeliDivUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdDeliDivUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdDeliDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdDeliDivUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                            else if (userGdBdUWork.UserGuideDivCd == 70)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdGoodsBigUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsBigUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdGoodsBigUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdGoodsBigUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdGoodsBigUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsBigUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                            else if (userGdBdUWork.UserGuideDivCd == 71)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdBuyDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBuyDivUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdBuyDivUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBuyDivUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdBuyDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBuyDivUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                            else if (userGdBdUWork.UserGuideDivCd == 72)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdStockDivOUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivOUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdStockDivOUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdStockDivOUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdStockDivOUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivOUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                            else if (userGdBdUWork.UserGuideDivCd == 73)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdStockDivTUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivTUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdStockDivTUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdStockDivTUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdStockDivTUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivTUCount++;
                                    }
                                }
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                            else if (userGdBdUWork.UserGuideDivCd == 91)
                            {
                                // ��M�敪����M����i�ǉ��̂݁j
                                if (userGdReturnReaUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdReturnReaUCount++;
                                    }
                                }
                                // ��M�敪����M����i�ǉ��E�X�V�j
                                else if (userGdReturnReaUInt == 2)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdReturnReaUCount++;
                                }
                                // ��M�敪����M����i�X�V�̂݁j
                                else if (userGdReturnReaUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // ���݂���f�[�^���폜����B
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // ���o�����f�[�^��o�^����B
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdReturnReaUCount++;
                                    }
                                }
                            }
                        }
                        // DC�|���D��Ǘ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(APRateProtyMngWork)))
                        {
                            rateProtyMngWork = (APRateProtyMngWork)retCSATemList[j];
                            rateProtyMngWork.EnterpriseCode = enterpriseCode;

                            _rateProtyMngList.Add(rateProtyMngWork);
                        }
                        // DC�|���}�X�^�X�V����
                        else if (wktype.Equals(typeof(APRateWork)))
                        {
                            rateWork = (APRateWork)retCSATemList[j];
                            rateWork.EnterpriseCode = enterpriseCode;

                            _rateList.Add(rateWork);
                        }
                        // DC���i�Z�b�g�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APGoodsSetWork)))
                        {
                            goodsSetWork = (APGoodsSetWork)retCSATemList[j];
                            goodsSetWork.EnterpriseCode = enterpriseCode;

                            _goodsSetList.Add(goodsSetWork);
                        }
                        // DC���i��փ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APPartsSubstUWork)))
                        {
                            _partsSubstUDB = new APPartsSubstUDB();
                            partsSubstUWork = (APPartsSubstUWork)retCSATemList[j];
                            partsSubstUWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (partsSubstUInt == 1)
                            {
                                status = _partsSubstUDB.SearchPartsSubstUCount(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    partsSubstUCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (partsSubstUInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                partsSubstUCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (partsSubstUInt == 3)
                            {
                                status = _partsSubstUDB.SearchPartsSubstUCount(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    partsSubstUCount++;
                                }
                            }
                        }
                        // DC�]�ƈ��ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APEmpSalesTargetWork)))
                        {
                            _empSalesTargetDB = new APEmpSalesTargetDB();
                            empSalesTargetWork = (APEmpSalesTargetWork)retCSATemList[j];
                            empSalesTargetWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (empSalesTargetInt == 1)
                            {
                                status = _empSalesTargetDB.SearchEmpSalesTargetCount(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    empSalesTargetCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (empSalesTargetInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                empSalesTargetCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (empSalesTargetInt == 3)
                            {
                                status = _empSalesTargetDB.SearchEmpSalesTargetCount(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    empSalesTargetCount++;
                                }
                            }
                        }
                        // DC���Ӑ�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APCustSalesTargetWork)))
                        {
                            _custSalesTargetDB = new APCustSalesTargetDB();
                            custSalesTargetWork = (APCustSalesTargetWork)retCSATemList[j];
                            custSalesTargetWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (custSalesTargetInt == 1)
                            {
                                status = _custSalesTargetDB.SearchCustSalesTargetCount(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSalesTargetCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (custSalesTargetInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                custSalesTargetCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (custSalesTargetInt == 3)
                            {
                                status = _custSalesTargetDB.SearchCustSalesTargetCount(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSalesTargetCount++;
                                }
                            }
                        }
                        // DC���i�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APGcdSalesTargetWork)))
                        {
                            _gcdSalesTargetDB = new APGcdSalesTargetDB();
                            gcdSalesTargetWork = (APGcdSalesTargetWork)retCSATemList[j];
                            gcdSalesTargetWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (gcdSalesTargetInt == 1)
                            {
                                status = _gcdSalesTargetDB.SearchGcdSalesTargetCount(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    gcdSalesTargetCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (gcdSalesTargetInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                gcdSalesTargetCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (gcdSalesTargetInt == 3)
                            {
                                status = _gcdSalesTargetDB.SearchGcdSalesTargetCount(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    gcdSalesTargetCount++;
                                }
                            }
                        }
                        // DC���i�����ރ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APGoodsGroupUWork)))
                        {
                            _goodsGroupUDB = new APGoodsGroupUDB();
                            goodsGroupUWork = (APGoodsGroupUWork)retCSATemList[j];
                            goodsGroupUWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (goodsMGroupUInt == 1)
                            {
                                status = _goodsGroupUDB.SearchGoodsGroupUCount(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMGroupUCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (goodsMGroupUInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsMGroupUCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (goodsMGroupUInt == 3)
                            {
                                status = _goodsGroupUDB.SearchGoodsGroupUCount(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMGroupUCount++;
                                }
                            }
                        }
                        // DCBL�O���[�v�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APBLGroupUWork)))
                        {
                            _bLGroupUDB = new APBLGroupUDB();
                            bLGroupUWork = (APBLGroupUWork)retCSATemList[j];
                            bLGroupUWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (bLGroupUInt == 1)
                            {
                                status = _bLGroupUDB.SearchBLGroupUCount(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGroupUCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (bLGroupUInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                bLGroupUCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (bLGroupUInt == 3)
                            {
                                status = _bLGroupUDB.SearchBLGroupUCount(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGroupUCount++;
                                }
                            }
                        }
                        // DC�����}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(APJoinPartsUWork)))
                        {
                            joinPartsUWork = (APJoinPartsUWork)retCSATemList[j];
                            joinPartsUWork.EnterpriseCode = enterpriseCode;

                            _joinPartsUList.Add(joinPartsUWork);
                        }
                        // DCTBO�����}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(APTBOSearchUWork)))
                        {
                            tBOSearchUWork = (APTBOSearchUWork)retCSATemList[j];
                            tBOSearchUWork.EnterpriseCode = enterpriseCode;

                            _tboSearchUList.Add(tBOSearchUWork);
                        }
                        // DC���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(APPartsPosCodeUWork)))
                        {
                            partsPosCodeUWork = (APPartsPosCodeUWork)retCSATemList[j];
                            partsPosCodeUWork.EnterpriseCode = enterpriseCode;

                            _partsPosCodeUList.Add(partsPosCodeUWork);
                        }
                        // DCBL�R�[�h�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(APBLCodeGuideWork)))
                        {
                            bLCodeGuideWork = (APBLCodeGuideWork)retCSATemList[j];
                            bLCodeGuideWork.EnterpriseCode = enterpriseCode;

                            _blCodeGuideList.Add(bLCodeGuideWork);
                        }
                        // DC�Ԏ햼�̃}�X�^�X�V����
                        else if (wktype.Equals(typeof(APModelNameUWork)))
                        {
                            _modelNameUDB = new APModelNameUDB();
                            modelNameUWork = (APModelNameUWork)retCSATemList[j];
                            modelNameUWork.EnterpriseCode = enterpriseCode;
                            // ��M�敪����M����i�ǉ��̂݁j
                            if (modelNameUInt == 1)
                            {
                                status = _modelNameUDB.SearchModelNameUCount(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // ���o�����f�[�^��o�^����B
                                    _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    modelNameUCount++;
                                }
                            }
                            // ��M�敪����M����i�ǉ��E�X�V�j
                            else if (modelNameUInt == 2)
                            {
                                // ���݂���f�[�^���폜����B
                                _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // ���o�����f�[�^��o�^����B
                                _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                modelNameUCount++;
                            }
                            // ��M�敪����M����i�X�V�̂݁j
                            else if (modelNameUInt == 3)
                            {
                                status = _modelNameUDB.SearchModelNameUCount(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // ���݂���f�[�^���폜����B
                                    _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // ���o�����f�[�^��o�^����B
                                    _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    modelNameUCount++;
                                }
                            }
                        }
                    }
                }

                // ADD 2009/06/09 --->>>
                // ���Ӑ�}�X�^�i�|���O���[�v�j
                if (_custRateGroupList != null && _custRateGroupList.Count > 0)
                {
                    _custRateGroupDB = new APCustRateGroupDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (custRateGroupInt == 1)
                    {
                        foreach (APCustRateGroupWork work in _custRateGroupList)
                        {
                            status = _custRateGroupDB.SearchCustRateGroupCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _custRateGroupListTmp.Add(work);
                            }
                        }
                        foreach (APCustRateGroupWork apCustRateGroupWork in _custRateGroupListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _custRateGroupDB.Insert(apCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            custRateGroupCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (custRateGroupInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APCustRateGroupWork work in _custRateGroupList)
                        {
                            // �{�Ђɍ폜����B
                            _custRateGroupDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APCustRateGroupWork apCustRateGroupWork in _custRateGroupList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _custRateGroupDB.Insert(apCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            custRateGroupCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (custRateGroupInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APCustRateGroupWork work in _custRateGroupList)
                        {
                            status = _custRateGroupDB.SearchCustRateGroupCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _custRateGroupListTmp.Add(work);
                            }
                        }

                        foreach (APCustRateGroupWork delWork in _custRateGroupListTmp)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _custRateGroupDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APCustRateGroupWork apCustRateGroupWork in _custRateGroupListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _custRateGroupDB.Insert(apCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            custRateGroupCount++;
                        }
                    }
                }
                // ���i�}�X�^�i���[�U�[�o�^�j
                if (_goodsPriceUList != null && _goodsPriceUList.Count > 0)
                {
                    _goodsPriceUDB = new APGoodsPriceUDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (goodsPriceInt == 1)
                    {
                        foreach (APGoodsPriceUWork work in _goodsPriceUList)
                        {
                            status = _goodsPriceUDB.SearchGoodsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _goodsPriceUListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsPriceUWork apGoodsPriceUWork in _goodsPriceUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _goodsPriceUDB.Insert(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsPriceCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (goodsPriceInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APGoodsPriceUWork work in _goodsPriceUList)
                        {
                            // �{�Ђɍ폜����B
                            _goodsPriceUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APGoodsPriceUWork apGoodsPriceUWork in _goodsPriceUList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _goodsPriceUDB.Insert(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsPriceCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (goodsPriceInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APGoodsPriceUWork work in _goodsPriceUList)
                        {
                            status = _goodsPriceUDB.SearchGoodsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _goodsPriceUListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsPriceUWork delWork in _goodsPriceUList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _goodsPriceUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APGoodsPriceUWork apGoodsPriceUWork in _goodsPriceUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _goodsPriceUDB.Insert(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsPriceCount++;
                        }
                    }
                }
                // �|���D��Ǘ��}�X�^
                if (_rateProtyMngList != null && _rateProtyMngList.Count > 0) 
                {
                    _rateProtyMngDB = new APRateProtyMngDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (rateProtyMngInt == 1)
                    {
                        foreach (APRateProtyMngWork work in _rateProtyMngList)
                        {
                            status = _rateProtyMngDB.SearchRateProtyMngCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _rateProtyMngListTmp.Add(work);
                            }
                        }

                        foreach (APRateProtyMngWork apRateProtyMngWork in _rateProtyMngListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _rateProtyMngDB.Insert(apRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateProtyMngCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (rateProtyMngInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APRateProtyMngWork work in _rateProtyMngList)
                        {
                            // �{�Ђɍ폜����B
                            _rateProtyMngDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APRateProtyMngWork apRateProtyMngWork in _rateProtyMngList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _rateProtyMngDB.Insert(apRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateProtyMngCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (rateProtyMngInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APRateProtyMngWork work in _rateProtyMngList)
                        {
                            status = _rateProtyMngDB.SearchRateProtyMngCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _rateProtyMngListTmp.Add(work);
                            }
                        }

                        foreach (APRateProtyMngWork delWork in _rateProtyMngList)
                        {
                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _rateProtyMngDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APRateProtyMngWork apRateProtyMngWork in _rateProtyMngListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _rateProtyMngDB.Insert(apRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateProtyMngCount++;
                        }
                    }
                }
                // �|���}�X�^
                if (_rateList != null && _rateList.Count > 0)
                {
                    _rateDB = new APRateDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (rateInt == 1)
                    {
                        foreach (APRateWork work in _rateList)
                        {
                            status = _rateDB.SearchRateCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _rateListTmp.Add(work);
                            }
                        }

                        foreach (APRateWork apRateWork in _rateListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _rateDB.Insert(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (rateInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APRateWork work in _rateList)
                        {
                            // �{�Ђɍ폜����B
                            _rateDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APRateWork apRateWork in _rateList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _rateDB.Insert(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (rateInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APRateWork work in _rateList)
                        {
                            status = _rateDB.SearchRateCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _rateListTmp.Add(work);
                            }
                        }

                        foreach (APRateWork delWork in _rateList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _rateDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APRateWork apRateWork in _rateListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _rateDB.Insert(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateCount++;
                        }
                    }
                }
                // ���i�Z�b�g�}�X�^
                if (_goodsSetList != null && _goodsSetList.Count > 0)
                {
                    _goodsSetDB = new APGoodsSetDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (goodsSetInt == 1)
                    {
                        foreach (APGoodsSetWork work in _goodsSetList)
                        {
                            status = _goodsSetDB.SearchGoodsSetCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _goodsSetListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsSetWork apGoodsSetWork in _goodsSetListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _goodsSetDB.Insert(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsSetCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (goodsSetInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APGoodsSetWork work in _goodsSetList)
                        {
                            // �{�Ђɍ폜����B
                            _goodsSetDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APGoodsSetWork apGoodsSetWork in _goodsSetList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _goodsSetDB.Insert(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsSetCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (goodsSetInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APGoodsSetWork work in _goodsSetList)
                        {
                            status = _goodsSetDB.SearchGoodsSetCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _goodsSetListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsSetWork delWork in _goodsSetList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _goodsSetDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APGoodsSetWork apGoodsSetWork in _goodsSetListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _goodsSetDB.Insert(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsSetCount++;
                        }
                    }
                }
                // �����}�X�^�i���[�U�[�o�^���j
                if (_joinPartsUList != null && _joinPartsUList.Count > 0)
                {
                    _joinPartsUDB = new APJoinPartsUDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (joinPartsUInt == 1)
                    {
                        foreach (APJoinPartsUWork work in _joinPartsUList)
                        {
                            status = _joinPartsUDB.SearchJoinPartsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _joinPartsUListTmp.Add(work);
                            }
                        }

                        foreach (APJoinPartsUWork apJoinPartsUWork in _joinPartsUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _joinPartsUDB.Insert(apJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            joinPartsUCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (joinPartsUInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APJoinPartsUWork work in _joinPartsUList)
                        {
                            // �{�Ђɍ폜����B
                            _joinPartsUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APJoinPartsUWork apJoinPartsUWork in _joinPartsUList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _joinPartsUDB.Insert(apJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            joinPartsUCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (joinPartsUInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APJoinPartsUWork work in _joinPartsUList)
                        {
                            status = _joinPartsUDB.SearchJoinPartsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _joinPartsUListTmp.Add(work);

                            }
                        }

                        foreach (APJoinPartsUWork delWork in _joinPartsUList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _joinPartsUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APJoinPartsUWork apJoinPartsUWork in _joinPartsUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _joinPartsUDB.Insert(apJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            joinPartsUCount++;
                        }
                    }
                }
                // TBO�������}�X�^�i���[�U�[�o�^���j
                if (_tboSearchUList != null && _tboSearchUList.Count > 0)
                {
                    _tBOSearchUDB = new APTBOSearchUDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (tBOSearchUCountInt == 1)
                    {
                        foreach (APTBOSearchUWork work in _tboSearchUList)
                        {
                            status = _tBOSearchUDB.SearchTBOSearchUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _tboSearchUListTmp.Add(work);
                            }
                        }

                        foreach (APTBOSearchUWork apTBOSearchUWork in _tboSearchUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _tBOSearchUDB.Insert(apTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            tBOSearchUCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (tBOSearchUCountInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APTBOSearchUWork work in _tboSearchUList)
                        {
                            // �{�Ђɍ폜����B
                            _tBOSearchUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APTBOSearchUWork apTBOSearchUWork in _tboSearchUList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _tBOSearchUDB.Insert(apTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            tBOSearchUCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (tBOSearchUCountInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APTBOSearchUWork work in _tboSearchUList)
                        {
                            status = _tBOSearchUDB.SearchTBOSearchUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _tboSearchUListTmp.Add(work);
                            }
                        }

                        foreach (APTBOSearchUWork delWork in _tboSearchUList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _tBOSearchUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APTBOSearchUWork apTBOSearchUWork in _tboSearchUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _tBOSearchUDB.Insert(apTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            tBOSearchUCount++;
                        }
                    }
                }
                // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
                if (_partsPosCodeUList != null && _partsPosCodeUList.Count > 0)
                {
                    _partsPosCodeUDB = new APPartsPosCodeUDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (partsPosCodeUInt == 1)
                    {
                        foreach (APPartsPosCodeUWork work in _partsPosCodeUList)
                        {
                            status = _partsPosCodeUDB.SearchPartsPosCodeUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _partsPosCodeUListTmp.Add(work);
                            }
                        }

                        foreach (APPartsPosCodeUWork apPartsPosCodeUWork in _partsPosCodeUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _partsPosCodeUDB.Insert(apPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            partsPosCodeUCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (partsPosCodeUInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APPartsPosCodeUWork work in _partsPosCodeUList)
                        {
                            // �{�Ђɍ폜����B
                            _partsPosCodeUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APPartsPosCodeUWork apPartsPosCodeUWork in _partsPosCodeUList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _partsPosCodeUDB.Insert(apPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            partsPosCodeUCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (partsPosCodeUInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APPartsPosCodeUWork work in _partsPosCodeUList)
                        {
                            status = _partsPosCodeUDB.SearchPartsPosCodeUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _partsPosCodeUListTmp.Add(work);
                            }
                        }

                        foreach (APPartsPosCodeUWork delWork in _partsPosCodeUList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _partsPosCodeUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APPartsPosCodeUWork apPartsPosCodeUWork in _partsPosCodeUListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _partsPosCodeUDB.Insert(apPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            partsPosCodeUCount++;
                        }
                    }
                }
                // BL�R�[�h�K�C�h�}�X�^
                if (_blCodeGuideList != null && _blCodeGuideList.Count > 0)
                {
                    _bLCodeGuideDB = new APBLCodeGuideDB();

                    // ��M�敪����M����i�ǉ��̂݁j
                    if (bLCodeGuideInt == 1)
                    {
                        foreach (APBLCodeGuideWork work in _blCodeGuideList)
                        {
                            status = _bLCodeGuideDB.SearchBLCodeGuideCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _blCodeGuideListTmp.Add(work);
                            }
                        }

                        foreach (APBLCodeGuideWork apBLCodeGuideWork in _blCodeGuideListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _bLCodeGuideDB.Insert(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            bLCodeGuideCount++;
                        }
                    }
                    // ��M�敪����M����i�ǉ��E�X�V�j
                    else if (bLCodeGuideInt == 2)
                    {
                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APBLCodeGuideWork work in _blCodeGuideList)
                        {
                            // �{�Ђɍ폜����B
                            _bLCodeGuideDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // �f�[�^���{�Ђɍ폜����B
                        foreach (APBLCodeGuideWork apBLCodeGuideWork in _blCodeGuideList)
                        {
                            // ���o�����f�[�^��o�^����B
                            _bLCodeGuideDB.Insert(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            bLCodeGuideCount++;
                        }

                    }
                    // ��M�敪����M����i�X�V�̂݁j
                    else if (bLCodeGuideInt == 3)
                    {
                        // �f�[�^���{�Ђɑ��ݏꍇ�A���o���R�[�h�ɕۑ�����A���́A�{�Ђɍ폜����B
                        foreach (APBLCodeGuideWork work in _blCodeGuideList)
                        {
                            status = _bLCodeGuideDB.SearchBLCodeGuideCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���ݏꍇ�ɂ͖{�Ђ���폜
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _blCodeGuideListTmp.Add(work);
                            }
                        }

                        foreach (APBLCodeGuideWork delWork in _blCodeGuideList)
                        {

                            // ���݂���f�[�^�͖{�Ђɍ폜����B
                            _bLCodeGuideDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APBLCodeGuideWork apBLCodeGuideWork in _blCodeGuideListTmp)
                        {
                            // ���o�����f�[�^��o�^����B
                            _bLCodeGuideDB.Insert(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            bLCodeGuideCount++;
                        }
                    }
                }
                // MOD 2009/06/24 --->>>
                // ���i�}�X�^
                if (_goodsUList != null && _goodsUList.Count > 0)
                {
                    _goodsUDB = new APGoodsUDB();

                    foreach (APGoodsUWork work in _goodsUList)
                    {
                        status = _goodsUDB.SearchGoodsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                        // ��M�敪����M����i�ǉ��̂݁j
                        if (goodsUInt == 1)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // ���o�����f�[�^��o�^����B
                                _goodsUDB.Insert(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                        }
                        // ��M�敪����M����i�ǉ��E�X�V�j
                        else if (goodsUInt == 2)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // ���o�����f�[�^��o�^����B
                                _goodsUDB.Insert(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ���݂���f�[�^���X�V����B
                                _goodsUDB.Update(masterDtlDivList, work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                        }
                        // ��M�敪����M����i�X�V�̂݁j
                        else if (goodsUInt == 3)
                        {
                            // ���o�����f�[�^��o�^����B
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ���݂���f�[�^���X�V����B
                                _goodsUDB.Update(masterDtlDivList, work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                        }
                    }
                }
                // MOD 2009/06/24 ---<<<
                // ADD 2009/06/09 ---<<<

                // ���_���ݒ�f�[�^�f�[�^
                if (secInfoSetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.SecInfoSetCount = secInfoSetCount;
                // ����}�X�^�f�[�^
                if (subSectionCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.SubSectionCount = subSectionCount;
                // �]�ƈ��}�X�^�f�[�^
                if (employeeCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.EmployeeCount = employeeCount;
                // �]�ƈ��ڍ׃}�X�^�f�[�^
                if (employeeDtlCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.EmployeeDtlCount = employeeDtlCount;
                // �q�Ƀ}�X�^
                if (warehouseCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.WarehouseCount = warehouseCount;
                // ���Ӑ�}�X�^�f�[�^
                if (customerCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustomerCount = customerCount;
                // ���Ӑ�}�X�^(�ϓ����)�f�[�^
                if (customerChangeCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustomerChangeCount = customerChangeCount;
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                // ���Ӑ�}�X�^(�������)�f�[�^
                if (customerMemoCount != CNT_ZERO)
                {
                    isEmpty = false;
                }
                searchCountWork.CustomerMemoCount = customerMemoCount;
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^
                if (custSlipMngCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustSlipMngCount = custSlipMngCount;
                // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^
                if (custRateGroupCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustRateGroupCount = custRateGroupCount;
                // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^
                if (custSlipNoSetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustSlipNoSetCount = custSlipNoSetCount;
                // �d����}�X�^
                if (supplierCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.SupplierCount = supplierCount;
                // ���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^
                if (makerUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.MakerUCount = makerUCount;
                // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
                if (bLGoodsCdUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.BLGoodsCdUCount = bLGoodsCdUCount;
                // ���i�}�X�^�i���[�U�[�o�^���j
                if (goodsUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsUCount = goodsUCount;
                // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^
                if (goodsPriceCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsPriceCount = goodsPriceCount;
                // ���i�Ǘ����}�X�^�f�[�^
                if (goodsMngCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsMngCount = goodsMngCount;
                // �������i�}�X�^�f�[�^
                if (isolIslandPrcCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.IsolIslandPrcCount = isolIslandPrcCount;
                // �݌Ƀ}�X�^�f�[�^
                if (stockCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.StockCount = stockCount;
                // ���[�U�[�K�C�h�}�X�^�f�[�^
                // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                if (userGdAreaDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdAreaDivUCount = userGdAreaDivUCount;
                // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                if (userGdBusDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBusDivUCount = userGdBusDivUCount;
                // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                if (userGdCateUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdCateUCount = userGdCateUCount;
                // ���[�U�[�K�C�h�}�X�^�i�E��j
                if (userGdBusUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBusUCount = userGdBusUCount;
                // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                if (userGdGoodsDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdGoodsDivUCount = userGdGoodsDivUCount;
                // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                if (userGdCusGrouPUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdCusGrouPUCount = userGdCusGrouPUCount;
                // ���[�U�[�K�C�h�}�X�^�i��s�j
                if (userGdBankUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBankUCount = userGdBankUCount;
                // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                if (userGdPriDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdPriDivUCount = userGdPriDivUCount;
                // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                if (userGdDeliDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdDeliDivUCount = userGdDeliDivUCount;
                // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                if (userGdGoodsBigUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdGoodsBigUCount = userGdGoodsBigUCount;
                // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                if (userGdBuyDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBuyDivUCount = userGdBuyDivUCount;
                // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                if (userGdStockDivOUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdStockDivOUCount = userGdStockDivOUCount;
                // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                if (userGdStockDivTUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdStockDivTUCount = userGdStockDivTUCount;
                // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                if (userGdReturnReaUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdReturnReaUCount = userGdReturnReaUCount;
                // �|���D��Ǘ��}�X�^�f�[�^
                if (rateProtyMngCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.RateProtyMngCount = rateProtyMngCount;
                // �|���}�X�^�f�[�^
                if (rateCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.RateCount = rateCount;
                // ���i�Z�b�g�}�X�^�f�[�^
                if (goodsSetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsSetCount = goodsSetCount;
                // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^
                if (partsSubstUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.PartsSubstUCount = partsSubstUCount;
                // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^
                if (empSalesTargetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.EmpSalesTargetCount = empSalesTargetCount;
                // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^
                if (custSalesTargetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustSalesTargetCount = custSalesTargetCount;
                // ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^
                if (gcdSalesTargetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GcdSalesTargetCount = gcdSalesTargetCount;
                // ���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^
                if (goodsMGroupUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsMGroupUCount = goodsMGroupUCount;
                // BL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^
                if (bLGroupUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.BLGroupUCount = bLGroupUCount;
                // �����}�X�^�i���[�U�[�o�^���j�f�[�^
                if (joinPartsUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.JoinPartsUCount = joinPartsUCount;
                // TBO�����}�X�^�i���[�U�[�o�^�j�f�[�^
                if (tBOSearchUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.TBOSearchUCount = tBOSearchUCount;
                // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^
                if (partsPosCodeUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.PartsPosCodeUCount = partsPosCodeUCount;
                // BL�R�[�h�K�C�h�}�X�^�f�[�^
                if (bLCodeGuideCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.BLCodeGuideCount = bLCodeGuideCount;
                // �Ԏ햼�̃}�X�^�f�[�^
                if (modelNameUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.ModelNameUCount = modelNameUCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.Update Exception=" + ex.Message);
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

        # region �� [�R�l�N�V������������] ��
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

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
        /// <br>Programmer : 杍^</br>
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
        # endregion �� [�R�l�N�V������������] ��

        #region ADD 2011/07/25 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j
        # region �� �}�X�^���M�̃f�[�^�������� ��
        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="enterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="updSectionCode">���_�R�[�h</param>
        /// <param name="paramList">�}�X�^���o�����N���X</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="sndRcvHisConsNo">���M�ԍ�</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, string updSectionCode, ArrayList paramList, ref CustomSerializeArrayList retCSAList, out int sndRcvHisConsNo, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            sndRcvHisConsNo = -1;

            //���o�����N���X
            // --- ADD 2012/07/26 -------------------------------->>>>>
            APEmployeeProcParamWork employeeProcParam = null;
            APJoinPartsUProcParamWork joinPartsUProcParam = null;
            APUserGdBuyDivUProcParamWork userGdBuyDivUProcParam = null;
            // --- ADD 2012/07/26 --------------------------------<<<<<
            APCustomerProcParamWork customerProcParam = null;
            APGoodsProcParamWork goodsProcParam = null;
            APStockProcParamWork stockProcParam = null;
            APSupplierProcParamWork supplierProcParam = null;
            APRateProcParamWork rateProcParam = null;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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

                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                for (int i = 0; i < paramList.Count; i++)
                {
                    Type paramType = paramList[i].GetType();

                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                    if (paramType.Equals(typeof(APEmployeeProcParamWork)))
                    {
                        employeeProcParam = (APEmployeeProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APJoinPartsUProcParamWork)))
                    {
                        joinPartsUProcParam = (APJoinPartsUProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APUserGdBuyDivUProcParamWork)))
                    {
                        userGdBuyDivUProcParam = (APUserGdBuyDivUProcParamWork)paramList[i];
                    }
                    // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                    if (paramType.Equals(typeof(APCustomerProcParamWork)))
                    {
                        customerProcParam = (APCustomerProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APGoodsProcParamWork)))
                    {
                        goodsProcParam = (APGoodsProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APStockProcParamWork)))
                    {
                        stockProcParam = (APStockProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APSupplierProcParamWork)))
                    {
                        supplierProcParam = (APSupplierProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APRateProcParamWork)))
                    {
                        rateProcParam = (APRateProcParamWork)paramList[i];
                    }
                }

                retCSAList = new CustomSerializeArrayList();

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                    // �]�ƈ��}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �]�ƈ��ڍ׃}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �����}�X�^�i���[�U�[�o�^���j
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                    // ���Ӑ�}�X�^
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ���i�}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �݌Ƀ}�X�^
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �d����}�X�^
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �|���}�X�^
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                }
                // --- ADD 2012/07/26 --------------------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt != 0 && employeeProcParam != null)
                {
                    // �]�ƈ��}�X�^�f�[�^���o
                    ArrayList employeeArrList = new ArrayList();
                    APEmployeeDB _employeeDB = new APEmployeeDB();
                    status = _employeeDB.SearchEmployee(enterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    if (employeeArrList.Count > 0)
                    {
                        retCSAList.Add(employeeArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt != 0 && employeeProcParam != null)
                {
                    // �]�ƈ��ڍ׃}�X�^�f�[�^���o
                    ArrayList employeeDtlArrList = new ArrayList();
                    APEmployeeDtlDB _employeeDtlDB = new APEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(enterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    if (employeeDtlArrList.Count > 0)
                    {
                        retCSAList.Add(employeeDtlArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt != 0 && joinPartsUProcParam != null)
                {
                    // �����}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList joinPartsUArrList = new ArrayList();
                    APJoinPartsUDB _joinPartsUDB = new APJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(enterpriseCodes, joinPartsUProcParam, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    if (joinPartsUArrList.Count > 0)
                    {
                        retCSAList.Add(joinPartsUArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBuyDivUInt != 0 && userGdBuyDivUProcParam != null)
                {
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j�f�[�^���o
                    ArrayList userGdBdUArrList = new ArrayList();
                    APUserGdBdUDB _userGdBdUDB = new APUserGdBdUDB();
                    status = _userGdBdUDB.SearchUserGdBdU(71, enterpriseCodes, userGdBuyDivUProcParam, sqlConnection, sqlTransaction, out userGdBdUArrList, out retMessage);
                    if (userGdBdUArrList.Count > 0)
                    {
                        retCSAList.Add(userGdBdUArrList);
                    }
                }
                // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                if (customerInt != 0 && customerProcParam != null)
                {
                    //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���Ӑ�}�X�^�f�[�^���o
                        ArrayList customerArrList = new ArrayList();
                        APCustomerDB _customerDB = new APCustomerDB();
                        status = _customerDB.SearchAllCustomer(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                        for (int m = 0; m < customerArrList.Count; m++)
                        {
                            if (((ArrayList)customerArrList[m]).Count > 0)
                            {
                                retCSAList.Add(customerArrList[m]);
                            }
                        }
                    }
                    //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------<<<<<
                    #region DEL 
                    //DEL 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------->>>>>                   if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^�f�[�^���o
                    //    ArrayList customerArrList = new ArrayList();
                    //    APCustomerDB _customerDB = new APCustomerDB();
                    //    status = _customerDB.SearchCustomer(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    //    if (customerArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(customerArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���o
                    //    ArrayList custRateGroupArrList = new ArrayList();
                    //    APCustRateGroupDB _custRateGroupDB = new APCustRateGroupDB();
                    //    status = _custRateGroupDB.SearchCustRateGroup(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    //    if (custRateGroupArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(custRateGroupArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^(�ϓ����)�f�[�^���o
                    //    ArrayList customerChangeArrList = new ArrayList();
                    //    APCustomerChangeDB _customerChangeDB = new APCustomerChangeDB();
                    //    status = _customerChangeDB.SearchCustomerChange(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    //    if (customerChangeArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(customerChangeArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^���o
                    //    ArrayList custSlipMngArrList = new ArrayList();
                    //    APCustSlipMngDB _custSlipMngDB = new APCustSlipMngDB();
                    //    status = _custSlipMngDB.SearchCustSlipMng(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    //    if (custSlipMngArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(custSlipMngArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^���o
                    //    ArrayList custSlipNoSetArrList = new ArrayList();
                    //    APCustSlipNoSetDB _custSlipNoSetDB = new APCustSlipNoSetDB();
                    //    status = _custSlipNoSetDB.SearchCustSlipNoSet(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    //    if (custSlipNoSetArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(custSlipNoSetArrList);
                    //    }
                    //}
                    //DEL 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------<<<<<
                    #endregion
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUInt != 0 && goodsProcParam != null)
                {
                    //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���i�}�X�^�S�f�[�^���o
                        ArrayList goodsAllList = new ArrayList();
                        APGoodsUDB _goodsUDB = new APGoodsUDB();
                        status = _goodsUDB.SearchGoodsAll(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsAllList, out retMessage);
                        for (int m = 0; m < goodsAllList.Count; m++)
                        {
                            if (((ArrayList)goodsAllList[m]).Count > 0)
                            {
                                retCSAList.Add(goodsAllList[m]);
                            }
                        }
                    }
                    //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------<<<<<
                    #region DEL
                    //DEL 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------->>>>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���i�}�X�^�i���[�U�[�o�^���j�f�[�^�Ə��i�Ǘ����}�X�^�f�[�^���o
                    //    ArrayList goodsUArrList = new ArrayList();
                    //    ArrayList goodsMngArrList = new ArrayList();
                    //    APGoodsUDB _goodsUDB = new APGoodsUDB();
                    //    status = _goodsUDB.SearchGoodsU(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsUArrList, out goodsMngArrList, out retMessage);
                    //    if (goodsUArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(goodsUArrList);
                    //    }
                    //    if (goodsMngArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(goodsMngArrList);
                    //    }
                    //}

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    //    ArrayList goodsPriceUArrList = new ArrayList();
                    //    APGoodsPriceUDB _goodsPriceUDB = new APGoodsPriceUDB();
                    //    status = _goodsPriceUDB.SearchGoodsPriceU(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    //    if (goodsPriceUArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(goodsPriceUArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // �������i�}�X�^�f�[�^���o
                    //    ArrayList isolIslandPrcArrList = new ArrayList();
                    //    APIsolIslandPrcDB _isolIslandPrcDB = new APIsolIslandPrcDB();
                    //    status = _isolIslandPrcDB.SearchIsolIslandPrc(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    //    if (isolIslandPrcArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(isolIslandPrcArrList);
                    //    }
                    //}
                    //DEL 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------<<<<<
                    #endregion
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0 && stockProcParam != null)
                {
                    // �݌Ƀ}�X�^�f�[�^���o
                    ArrayList stockArrList = new ArrayList();
                    APStockDB _stockDB = new APStockDB();
                    status = _stockDB.SearchStock(enterpriseCodes, stockProcParam, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    if (stockArrList.Count > 0)
                    {
                        retCSAList.Add(stockArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt != 0 && supplierProcParam != null)
                {
                    // �d����}�X�^�f�[�^���o
                    ArrayList supplierArrList = new ArrayList();
                    APSupplierDB _supplierDB = new APSupplierDB();
                    status = _supplierDB.SearchSupplier(enterpriseCodes, supplierProcParam, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    if (supplierArrList.Count > 0)
                    {
                        retCSAList.Add(supplierArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt != 0 && rateProcParam != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �|���}�X�^�f�[�^���o
                        ArrayList rateArrList = new ArrayList();
                        APRateDB _rateDB = new APRateDB();
                        status = _rateDB.SearchRate(enterpriseCodes, rateProcParam, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                        if (rateArrList.Count > 0)
                        {
                            retCSAList.Add(rateArrList);
                        }
                    }
                }

                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //if (retCSAList.Count > 0)//DEL 2011/09/05 #24047
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retCSAList.Count > 0)//ADD 2011/09/05 #24047
                {
                    long no = -1;
                    NumberingManager numberingManager = new NumberingManager();
                    SerialNumberCode serialnumcd = SerialNumberCode.SndRcvHisConsNo;
                    status = numberingManager.GetSerialNumber(enterpriseCodes, updSectionCode.Trim(), serialnumcd, out no);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                    {
                        sndRcvHisConsNo = (int)no;
                    }
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
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

        # region �� �}�X�^��M�̃f�[�^������������ ��
        #region DEL 2011.09.06 #24364
        ///// <summary>
        ///// �}�X�^��M�̃f�[�^��������
        ///// </summary>
        ///// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        ///// <param name="secMngSndRcvWork">�}�X�^�敪</param>
        ///// <param name="param">�}�X�^���o�����N���X</param>
        ///// <param name="count">�߂錏��</param>
        ///// <param name="retMessage">�߂郁�b�Z�[�W</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        ///// <br>Programmer : sundx</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int GetObjCount(string pmEnterpriseCodes, SecMngSndRcvWork secMngSndRcvWork, object param, ref int count, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    retMessage = string.Empty;

        //    //--------------------------
        //    // �f�[�^�x�[�X�I�[�v��
        //    //--------------------------
        //    SqlConnection sqlConnection = null;
        //    SqlTransaction sqlTransaction = null;

        //    try
        //    {
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
        //        if (_connectionText == null || _connectionText == "")
        //        {
        //            return status;
        //        }

        //        sqlConnection = new SqlConnection(_connectionText);
        //        sqlConnection.Open();

        //        // �g�����U�N�V����
        //        sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

        //        switch (secMngSndRcvWork.FileId)
        //        {
        //            case MST_GOODSU:
        //                //���i�}�X�^
        //                APGoodsUDB _goodsUDB = new APGoodsUDB();
        //                status = _goodsUDB.SearchGoodsUCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count, out retMessage);
        //                break;
        //            case MST_STOCK:
        //                // �݌Ƀ}�X�^
        //                APStockDB _stockDB = new APStockDB();
        //                status = _stockDB.SearchStockCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count, out retMessage);
        //                break;
        //            default:
        //                count = -1;
        //                break;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "APMSTControlDB.GetObjCount Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null) sqlTransaction.Dispose();
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        #endregion DEL 2011.09.06 #24364
        //-----ADD 2011.09.06 #24364----->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="enterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="paramList">�}�X�^���o�����N���X</param>
        /// <param name="searchCountWork">�����v�����[�N</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns></returns>
        public int GetObjCount(ArrayList masterDivList, string enterpriseCodes, ArrayList paramList, out MstSearchCountWorkWork searchCountWork, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int count = 0;
            searchCountWork = new MstSearchCountWorkWork();
            retMessage = string.Empty;

            //���o�����N���X
            APGoodsProcParamWork goodsProcParam = null;
            APStockProcParamWork stockProcParam = null;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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

                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                for (int i = 0; i < paramList.Count; i++)
                {
                    Type paramType = paramList[i].GetType();

                    if (paramType.Equals(typeof(APGoodsProcParamWork)))
                    {
                        goodsProcParam = (APGoodsProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APStockProcParamWork)))
                    {
                        stockProcParam = (APStockProcParamWork)paramList[i];
                    }
                }

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // ���i�}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // �݌Ƀ}�X�^
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                }
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0 && stockProcParam != null)
                {
                    // �݌Ƀ}�X�^�f�[�^���o
                    APStockDB _stockDB = new APStockDB();
                    status = _stockDB.SearchStockCount(enterpriseCodes, stockProcParam, sqlConnection, sqlTransaction, out count, out retMessage);
                    if (count > MAX_CNT)
                    {
                        searchCountWork.ErrorKubun = -4;
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "APMSTControlDB.GetObjCount Exception=" + ex.Message);
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
        //-----ADD 2011.09.06 #24364-----<<<<<
        # endregion �� �}�X�^��M�̃f�[�^������������ ��
        #endregion ADD 2011/07/25 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j
    }
}
