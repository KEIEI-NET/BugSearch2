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
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/06/09  �C�����e : �}�X�^����M�s���Ή��ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �}�X�^����M�����̂`�o�o���b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �f�[�^���M������DC�T�[�o�[�̃G���[���O�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/08/25  �C�����e : #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00 �C���S�� : FSI�� ���j
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ� ���o�����ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/26  �C�����e : ���_�Ǘ�DC���O���Ԓǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2012/09/05  �C�����e : AP�A�����b�N���̏����ύX�i���b�N�o���Ȃ������ꍇ�̓A�����b�N���Ȃ��j
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
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br>Update Note : 2012/07/26 �L�w�� </br>
    /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
    /// <br>Update Note: 2012/10/16 ������</br>
    ///	<br>			 10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    public class MstDCControlDB : RemoteWithAppLockDB, IMstDCControlDB
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
        //private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";   // DEL 2012/07/26 �L�w��
        private const string MST_ID_EMPLOYEE = "EmployeeRF";   // ADD 2012/07/26 �L�w��
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
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
        private const int CNT_ZERO = 0;
        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
        #endregion �� Const Memebers ��

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
        private Int32 customerMemoInt = CNT_ZERO;
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
        # endregion �� Private Members ��

        # region �� Constructor ��
        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.4.24</br>
        /// </remarks>
        public MstDCControlDB()
        {
        }
        # endregion �� Constructor ��

        # region �� �}�X�^��M�̃f�[�^�������� ��
        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
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
        /// <br>Update Note : 2012/07/26 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out string retMessage)
        {
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����J�n�������擾����B
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;

            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            ArrayList tempSndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork tempSndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // ��ƃR�[�h
                tempSndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;
                // ���_�R�[�h
                tempSndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //����M�������O���M�ԍ�
                tempSndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // ����M�敪:��M�����i�J�n�j
                tempSndRcvHisTableWork.SendOrReceiveDivCd = 3;
                // ����M����
                tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                // ���
                tempSndRcvHisTableWork.Kind = 1;
                // ����M���O���o�����敪
                tempSndRcvHisTableWork.SndLogExtraCondDiv = 0;
                // ���M���ƃR�[�h
                tempSndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;
                // ���M�拒�_�R�[�h
                tempSndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;
                //���M�ΏۊJ�n����
                tempSndRcvHisTableWork.SndObjStartDate = beginningDate;
                //���M�ΏۏI������
                tempSndRcvHisTableWork.SndObjEndDate = endingDate;
                // ����M�敪
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // ����M�̏ꍇ
                    tempSndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // ��M�̏ꍇ
                    tempSndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // �G���[���e
                tempSndRcvHisTableWork.SndRcvErrContents = retMessage;
                // ����M�t�@�C���h�c
                tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
            }
            SndRcvHisTableDB tempSndRcvHisResDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisResDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
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
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ����ݒ�}�X�^
                    if (MST_SUBSECTION.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUBSECTION.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        subSectionInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �q�ɐݒ�}�X�^
                    if (MST_WAREHOUSE.Equals(secMngSndRcvWork.MasterName) && MST_ID_WAREHOUSE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        warehouseInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �]�ƈ��}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �]�ƈ��ڍ׃}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���Ӑ�}�X�^
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���Ӑ�}�X�^(�ϓ����)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMECHA.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerChangeInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                    // ���Ӑ�}�X�^(�������)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEMEMO.Equals(secMngSndRcvWork.FileId)
                        && CNT_ZERO != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerMemoInt = secMngSndRcvWork.SecMngRecvDiv;
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    // ���Ӑ�}�X�^�i�`�[�Ǘ��j
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipMngInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���Ӑ�}�X�^�i�|���O���[�v�j
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEGROUP.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custRateGroupInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���Ӑ�}�X�^(�`�[�ԍ�)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPNO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipNoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �d����}�X�^
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�J�[�}�X�^�i���[�U�[�o�^���j
                    if (MST_MAKERU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MAKERU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        makerUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
                    if (MST_BLGOODSCDU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGOODSCDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGoodsCdUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�}�X�^�i���[�U�[�o�^�j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUPRI.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsPriceInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�Ǘ����}�X�^
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMngInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �������i�}�X�^
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUISO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        isolIslandPrcInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �݌Ƀ}�X�^
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    if (MST_USERGDAREADIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdAreaDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    if (MST_USERGDBUSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    if (MST_USERGDCATEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCateUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    if (MST_USERGDBUSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (MST_USERGDGOODSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    if (MST_USERGDCUSGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCusGrouPUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    if (MST_USERGDBANKU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBankUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    if (MST_USERGDPRIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdPriDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    if (MST_USERGDDELIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdDeliDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    if (MST_USERGDGOODSBIGU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsBigUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    if (MST_USERGDSTOCKDIVOU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivOUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    if (MST_USERGDSTOCKDIVTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivTUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    if (MST_USERGDRETURNREAU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdReturnReaUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �|���D��Ǘ��}�X�^
                    if (MST_RATEPROTYMNG.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATEPROTYMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateProtyMngInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �|���}�X�^
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�Z�b�g�}�X�^
                    if (MST_GOODSSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsSetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i��փ}�X�^�i���[�U�[�o�^���j
                    if (MST_PARTSSUBSTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSSUBSTU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsSubstUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        empSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�ʔ���ڕW�ݒ�}�X�^
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GCDSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        gcdSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�����ރ}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSMGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSMGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
                    if (MST_BLGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �����}�X�^�i���[�U�[�o�^���j
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // TBO�����}�X�^�i���[�U�[�o�^�j
                    if (MST_TBOSEARCHU.Equals(secMngSndRcvWork.MasterName) && MST_ID_TBOSEARCHU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        tBOSearchUCountInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
                    if (MST_PARTSPOSCODEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSPOSCODEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsPosCodeUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // BL�R�[�h�K�C�h�}�X�^
                    if (MST_BLCODEGUIDE.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLCODEGUIDE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLCodeGuideInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �Ԏ햼�̃}�X�^
                    if (MST_MODELNAMEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MODELNAMEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        modelNameUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                }

                // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }
                    
                }
                // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<

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
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerMemoInt != CNT_ZERO)
                {
                    // ���Ӑ�}�X�^(�������)�f�[�^���o
                    ArrayList customerMemoArrList = new ArrayList();
                    DCCustomerMemoDB _customerMemoDB = new DCCustomerMemoDB();
                    status = _customerMemoDB.SearchCustomerMemo(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerMemoArrList, out retMessage);
                    retCSAList.Add(customerMemoArrList);
                }
                // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
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
                base.WriteErrorLog(ex, "MstDCControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
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
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����I�����t���擾����B
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // ��ƃR�[�h
                //sndRcvHisTableWork.EnterpriseCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;//ADD 2012/10/16 ������ for redmine#31026
                // ���_�R�[�h
                sndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //����M�������O���M�ԍ�
                sndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //// ����M�敪
                //sndRcvHisTableWork.SendOrReceiveDivCd = 1;
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                // ����M�敪:��M�����i�I���j
                sndRcvHisTableWork.SendOrReceiveDivCd = 4;
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                // ����M����
                //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 ������ for redmine#31026
                // ���
                sndRcvHisTableWork.Kind = 1;
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //// ����M���O���o�����敪
                //sndRcvHisTableWork.SndLogExtraCondDiv = ((DCSecMngSndRcvWork)masterDivList[0]).SndLogExtraCondDiv;
                //// �����J�n����
                //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                //// �����I������
                //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                // ����M���O���o�����敪
                sndRcvHisTableWork.SndLogExtraCondDiv = 0;
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                // ���M���ƃR�[�h
                //sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestEpCode;//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//ADD 2012/10/16 ������ for redmine#31026
                // ���M�拒�_�R�[�h
                sndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                //���M�ΏۊJ�n����
                sndRcvHisTableWork.SndObjStartDate = beginningDate;
                //���M�ΏۏI������
                sndRcvHisTableWork.SndObjEndDate = endingDate;
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                // ����M���
                if (status == 0)
                {   // DC�X�V�����̏ꍇ
                    sndRcvHisTableWork.SndRcvCondition = 0;
                }
                else
                {   // DC�X�V���s�̏ꍇ
                    sndRcvHisTableWork.SndRcvCondition = 1;
                }
                // ����M�敪
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // ����M�̏ꍇ
                    sndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // ��M�̏ꍇ
                    sndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // �G���[���e
                sndRcvHisTableWork.SndRcvErrContents = retMessage;
                // ����M�t�@�C���h�c
                sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            }
            
            SndRcvHisTableDB sndRcvHisResDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisResDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
            return status;
        }

        # endregion �� �}�X�^��M�̃f�[�^�������� ��

        #region �� �}�X�^���M�̍X�V���� ��
        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage)
        {
            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 >>>
            // �O�̈�AP���b�N�p�̃X�e�[�^�X��p�ӂ���B
            int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 <<<
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            // private field
            DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
            DCSecInfoSetWork secInfoSetWork = new DCSecInfoSetWork();
            DCSubSectionDB _subSectionDB = new DCSubSectionDB();
            DCSubSectionWork subSectionWork = new DCSubSectionWork();
            DCEmployeeDB _employeeDB = new DCEmployeeDB();
            DCEmployeeWork employeeWork = new DCEmployeeWork();
            DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
            DCEmployeeDtlWork employeeDtlWork = new DCEmployeeDtlWork();
            DCWarehouseDB _warehouseDB = new DCWarehouseDB();
            DCWarehouseWork warehouseWork = new DCWarehouseWork();
            DCCustomerDB _customerWorkDB = new DCCustomerDB();
            DCCustomerWork customerWork = new DCCustomerWork();
            DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
            DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            DCCustomerMemoDB _customerMemoDB = new DCCustomerMemoDB();
            DCCustomerMemoWork customerMemoWork = new DCCustomerMemoWork();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
            DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();
            DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
            DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();
            DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
            DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();
            DCSupplierDB _supplierDB = new DCSupplierDB();
            DCSupplierWork supplierWork = new DCSupplierWork();
            DCMakerUDB _makerUWorkDB = new DCMakerUDB();
            DCMakerUWork makerUWork = new DCMakerUWork();
            DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
            DCBLGoodsCdUWork bLGoodsCdUWork = new DCBLGoodsCdUWork();
            DCGoodsUDB _goodsUDB = new DCGoodsUDB();
            DCGoodsUWork goodsUWork = new DCGoodsUWork();
            DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
            DCGoodsPriceUWork goodsPriceUWork = new DCGoodsPriceUWork();
            DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
            DCGoodsMngWork goodsMngWork = new DCGoodsMngWork();
            DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
            DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();
            DCStockDB _stockDB = new DCStockDB();
            DCStockWork stockWork = new DCStockWork();
            DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
            DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();
            DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
            DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();
            DCRateDB _rateDB = new DCRateDB();
            DCRateWork rateWork = new DCRateWork();
            DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
            DCGoodsSetWork goodsSetWork = new DCGoodsSetWork();
            DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
            DCPartsSubstUWork partsSubstUWork = new DCPartsSubstUWork();
            DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
            DCEmpSalesTargetWork empSalesTargetWork = new DCEmpSalesTargetWork();
            DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
            DCCustSalesTargetWork custSalesTargetWork = new DCCustSalesTargetWork();
            DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
            DCGcdSalesTargetWork gcdSalesTargetWork = new DCGcdSalesTargetWork();
            DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
            DCGoodsGroupUWork goodsGroupUWork = new DCGoodsGroupUWork();
            DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
            DCBLGroupUWork bLGroupUWork = new DCBLGroupUWork();
            DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
            DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();
            DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
            DCTBOSearchUWork tBOSearchUWork = new DCTBOSearchUWork();
            DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
            DCPartsPosCodeUWork partsPosCodeUWork = new DCPartsPosCodeUWork();
            DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
            DCBLCodeGuideWork bLCodeGuideWork = new DCBLCodeGuideWork();
            DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
            DCModelNameUWork modelNameUWork = new DCModelNameUWork();

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
                // del 2012/09/05 >>>
                //// MOD 2009/07/06 --->>>
                ////�`�o���b�N
                //status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                //// MOD 2009/07/06 ---<<<

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                // del 2012/09/05 <<<
                // add 2012/09/05 >>>
                //�`�o���b�N
                status2 = Lock(resNm, 1, sqlConnection, sqlTransaction);

                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status2;
                }
                status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // add 2012/09/05 <<<

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC���_���ݒ�}�X�^�X�V����
                        if (wktype.Equals(typeof(DCSecInfoSetWork)))
                        {
                            _secInfoSetDB = new DCSecInfoSetDB();
                            secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                        }
                        // DC����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCSubSectionWork)))
                        {
                            _subSectionDB = new DCSubSectionDB();
                            subSectionWork = (DCSubSectionWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�]�ƈ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmployeeWork)))
                        {
                            _employeeDB = new DCEmployeeDB();
                            employeeWork = (DCEmployeeWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�]�ƈ��ڍ׃}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                        {
                            _employeeDtlDB = new DCEmployeeDtlDB();
                            employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�q�Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCWarehouseWork)))
                        {
                            _warehouseDB = new DCWarehouseDB();
                            warehouseWork = (DCWarehouseWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCCustomerWork)))
                        {
                            _customerWorkDB = new DCCustomerDB();
                            customerWork = (DCCustomerWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^(�ϓ����)�X�V����
                        else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                        {
                            _customerChangeDB = new DCCustomerChangeDB();
                            customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                        // DC���Ӑ�}�X�^(�������)�X�V����
                        else if (wktype.Equals(typeof(DCCustomerMemoWork)))
                        {
                            _customerMemoDB = new DCCustomerMemoDB();
                            customerMemoWork = (DCCustomerMemoWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                        // DC���Ӑ�}�X�^�i�`�[�Ǘ��j�X�V����
                        else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                        {
                            _custSlipMngDB = new DCCustSlipMngDB();
                            custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�}�X�^�i�|���O���[�v�j�X�V����
                        else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                        {

                            custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_custRateGroupDB.Delete(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_custRateGroupDB.Insert(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ����f�[�^
                            _custRateGroupList.Add(custRateGroupWork);
                        }
                        // DC���Ӑ�}�X�^(�`�[�ԍ�)�X�V����
                        else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                        {
                            _custSlipNoSetDB = new DCCustSlipNoSetDB();
                            custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�d����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCSupplierWork)))
                        {
                            _supplierDB = new DCSupplierDB();
                            supplierWork = (DCSupplierWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���[�J�[�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCMakerUWork)))
                        {
                            _makerUWorkDB = new DCMakerUDB();
                            makerUWork = (DCMakerUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                        {
                            _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
                            bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsUWork)))
                        {
                            _goodsUDB = new DCGoodsUDB();
                            goodsUWork = (DCGoodsUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsUDB.Delete(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsUDB.Insert(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                        {
                            goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_goodsPriceUDB.Delete(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_goodsPriceUDB.Insert(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsPriceUList.Add(goodsPriceUWork);
                        }
                        // DC���i�Ǘ����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGoodsMngWork)))
                        {
                            _goodsMngDB = new DCGoodsMngDB();
                            goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�������i�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                        {
                            _isolIslandPrcDB = new DCIsolIslandPrcDB();
                            isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�݌Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCStockWork)))
                        {
                            _stockDB = new DCStockDB();
                            stockWork = (DCStockWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _stockDB.Delete(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���[�U�[�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                        {
                            _userGdBdUDB = new DCUserGdBdUDB();
                            userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�|���D��Ǘ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                        {
                            rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_rateProtyMngDB.Delete(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_rateProtyMngDB.Insert(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateProtyMngList.Add(rateProtyMngWork);
                        }
                        // DC�|���}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCRateWork)))
                        {
                            rateWork = (DCRateWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_rateDB.Delete(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_rateDB.Insert(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateList.Add(rateWork);
                        }
                        // DC���i�Z�b�g�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGoodsSetWork)))
                        {
                            goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_goodsSetDB.Delete(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_goodsSetDB.Insert(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsSetList.Add(goodsSetWork);
                        }
                        // DC���i��փ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                        {
                            _partsSubstUDB = new DCPartsSubstUDB();
                            partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�]�ƈ��ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                        {
                            _empSalesTargetDB = new DCEmpSalesTargetDB();
                            empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���Ӑ�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                        {
                            _custSalesTargetDB = new DCCustSalesTargetDB();
                            custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                        {
                            _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                            gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC���i�����ރ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                        {
                            _goodsGroupUDB = new DCGoodsGroupUDB();
                            goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBL�O���[�v�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCBLGroupUWork)))
                        {
                            _bLGroupUDB = new DCBLGroupUDB();
                            bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC�����}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                        {
                            joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_joinPartsUDB.Delete(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_joinPartsUDB.Insert(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _joinPartsUList.Add(joinPartsUWork);
                        }
                        // DCTBO�����}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                        {
                            tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_tBOSearchUDB.Delete(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_tBOSearchUDB.Insert(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _tboSearchUList.Add(tBOSearchUWork);
                        }
                        // DC���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                        {
                            partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_partsPosCodeUDB.Delete(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_partsPosCodeUDB.Insert(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _partsPosCodeUList.Add(partsPosCodeUWork);
                        }
                        // DCBL�R�[�h�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                        {
                            bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                            //// ���݂���f�[�^���폜����B
                            //_bLCodeGuideDB.Delete(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// ���o�����f�[�^��o�^����B
                            //_bLCodeGuideDB.Insert(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _blCodeGuideList.Add(bLCodeGuideWork);
                        }
                        // DC�Ԏ햼�̃}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCModelNameUWork)))
                        {
                            _modelNameUDB = new DCModelNameUDB();
                            modelNameUWork = (DCModelNameUWork)retCSATemList[j];
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
                    _custRateGroupDB = new DCCustRateGroupDB();
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
                    _goodsPriceUDB = new DCGoodsPriceUDB();
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
                    _rateProtyMngDB = new DCRateProtyMngDB();
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
                    _rateDB = new DCRateDB();
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
                    _goodsSetDB = new DCGoodsSetDB();
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
                    _joinPartsUDB = new DCJoinPartsUDB();
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
                    _tBOSearchUDB = new DCTBOSearchUDB();
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
                    _partsPosCodeUDB = new DCPartsPosCodeUDB();
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
                    _bLCodeGuideDB = new DCBLCodeGuideDB();
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
                base.WriteErrorLog(ex, "MstDCControlDB.Update SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MstDCControlDB.Update Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // upd 2012/09/05 >>>
                //if (resNm != "")
                if (resNm != "" && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // upd 2012/09/05 <<<
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
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);

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

        #region ADD 2011/07/26 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j
        # region �� �}�X�^��M�̃f�[�^�������� ��
        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="paramList">�}�X�^���o�����N���X</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        /// <br>Update Note : 2012/07/26 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, ArrayList paramList, ref CustomSerializeArrayList retCSAList, out string retMessage)
        {
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����J�n�������擾����B
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            ArrayList tempSndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork tempSndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // ��ƃR�[�h
                tempSndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;
                // ���_�R�[�h
                tempSndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //����M�������O���M�ԍ�
                tempSndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // ����M�敪:��M�����i�J�n�j
                tempSndRcvHisTableWork.SendOrReceiveDivCd = 3;
                // ����M����
                tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                // ���
                tempSndRcvHisTableWork.Kind = 1;
                // ����M���O���o�����敪
                tempSndRcvHisTableWork.SndLogExtraCondDiv = 1;
                // ���M���ƃR�[�h
                tempSndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;
                // ���M�拒�_�R�[�h
                tempSndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;

                for (int i=0;i< paramList.Count;i++)
                {
                    if (paramList[i].GetType() == typeof(CustomerProcParamWork))
                    {
                        CustomerProcParamWork customerProcParamWork = (CustomerProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = customerProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = customerProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(GoodsProcParamWork))
                    {
                        GoodsProcParamWork goodsProcParamWork = (GoodsProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = goodsProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = goodsProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(StockProcParamWork))
                    {
                        StockProcParamWork stockProcParamWork = (StockProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = stockProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = stockProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(SupplierProcParamWork))
                    {
                        SupplierProcParamWork supplierProcParamWork = (SupplierProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = supplierProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = supplierProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(RateProcParamWork))
                    {
                        RateProcParamWork rateProcParamWork = (RateProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = rateProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = rateProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    // --- ADD 2012/07/26 ------------------------------>>>>>
                	else if (paramList[i].GetType() == typeof(EmployeeProcParamWork))
                	{
                        EmployeeProcParamWork employeeProcParamWork = (EmployeeProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = employeeProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = employeeProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(JoinPartsUProcParamWork))
                	{
                        JoinPartsUProcParamWork joinPartsUProcParamWork = (JoinPartsUProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = joinPartsUProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = joinPartsUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(UserGdBuyDivUProcParamWork))
                	{
                        UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = (UserGdBuyDivUProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        tempSndRcvHisTableWork.SndObjStartDate = userGdBuyDivUProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        tempSndRcvHisTableWork.SndObjEndDate = userGdBuyDivUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    // --- ADD 2012/07/26 ------------------------------<<<<<
                }
                // ����M�敪
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // ����M�̏ꍇ
                    tempSndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // ��M�̏ꍇ
                    tempSndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // �G���[���e
                tempSndRcvHisTableWork.SndRcvErrContents = retMessage;
                // ����M�t�@�C���h�c
                tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
            }
            SndRcvHisTableDB tempSndRcvHisResDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisResDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

            //���o�����N���X
            // --- ADD 2012/07/26 ------------------------------>>>>>
            EmployeeProcParamWork employeeProcParam = null;
            JoinPartsUProcParamWork joinPartsUProcParam = null;
            UserGdBuyDivUProcParamWork userGdBuyDivUProcParam = null;
            // --- ADD 2012/07/26 ------------------------------<<<<<
            CustomerProcParamWork customerProcParam = null;
            GoodsProcParamWork goodsProcParam = null;
            StockProcParamWork stockProcParam = null;
            SupplierProcParamWork supplierProcParam = null;
            RateProcParamWork rateProcParam = null;

            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                for(int i = 0; i< paramList.Count;i++)
                {
                    Type paramType = paramList[i].GetType();

                    // --- ADD 2012/07/26 ------------------------------------------->>>>>
                    if (paramType.Equals(typeof(EmployeeProcParamWork)))
                    {
                        employeeProcParam = (EmployeeProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(JoinPartsUProcParamWork)))
                    {
                        joinPartsUProcParam = (JoinPartsUProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(UserGdBuyDivUProcParamWork)))
                    {
                        userGdBuyDivUProcParam = (UserGdBuyDivUProcParamWork)paramList[i];
                    }
                    // --- ADD 2012/07/26 -------------------------------------------<<<<<
                    if (paramType.Equals(typeof(CustomerProcParamWork)))
                    {
                        customerProcParam = (CustomerProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(GoodsProcParamWork)))
                    {
                        goodsProcParam = (GoodsProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(StockProcParamWork)))
                    {
                        stockProcParam = (StockProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(SupplierProcParamWork)))
                    {
                        supplierProcParam = (SupplierProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(RateProcParamWork)))
                    {
                        rateProcParam = (RateProcParamWork)paramList[i];
                    }                
                }

                retCSAList = new CustomSerializeArrayList();

                foreach (DCSecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                    // �]�ƈ��}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // �]�ƈ��ڍ׃}�X�^
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // �����}�X�^�i���[�U�[�o�^���j
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                    // ���Ӑ�}�X�^
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ���i�}�X�^�i���[�U�[�o�^���j
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �݌Ƀ}�X�^
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �d����}�X�^
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // �|���}�X�^
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                }

                // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }

                }
                // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<

                // --- ADD 2012/07/26 --------------------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt != 0 && employeeProcParam != null)
                {
                    // �]�ƈ��}�X�^�f�[�^���o
                    ArrayList employeeArrList = new ArrayList();
                    DCEmployeeDB _employeeDB = new DCEmployeeDB();
                    status = _employeeDB.SearchEmployee(pmEnterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    retCSAList.Add(employeeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt != 0 && employeeProcParam != null)
                {
                    // �]�ƈ��ڍ׃}�X�^�f�[�^���o
                    ArrayList employeeDtlArrList = new ArrayList();
                    DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(pmEnterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    retCSAList.Add(employeeDtlArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt != 0 && joinPartsUProcParam != null)
                {
                    // �����}�X�^�i���[�U�[�o�^���j�f�[�^���o
                    ArrayList joinPartsUArrList = new ArrayList();
                    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(pmEnterpriseCodes, joinPartsUProcParam, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    retCSAList.Add(joinPartsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBuyDivUInt != 0 && userGdBuyDivUProcParam != null)
                {
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j�f�[�^���o
                    ArrayList userGdBdUArrList = new ArrayList();
                    DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
                    status = _userGdBdUDB.SearchUserGdBdU(71, pmEnterpriseCodes, userGdBuyDivUProcParam, sqlConnection, sqlTransaction, out userGdBdUArrList, out retMessage);
                    retCSAList.Add(userGdBdUArrList);
                }
                // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                if (customerInt != 0 && customerProcParam != null)
                {
                    //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���Ӑ�}�X�^�f�[�^���o
                        ArrayList customerArrList = new ArrayList();
                        DCCustomerDB _customerDB = new DCCustomerDB();
                        status = _customerDB.SearchAllCustomer(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                        for (int m = 0; m < customerArrList.Count; m++)
                        {
                            retCSAList.Add(customerArrList[m]);
                        }
                    }
                    //ADD 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------<<<<<
                    #region DEL 
                    //DEL 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�--------------------------------->>>>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^�f�[�^���o
                    //    ArrayList customerArrList = new ArrayList();
                    //    DCCustomerDB _customerDB = new DCCustomerDB();
                    //    status = _customerDB.SearchCustomer(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    //    retCSAList.Add(customerArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^���o
                    //    ArrayList custRateGroupArrList = new ArrayList();
                    //    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                    //    status = _custRateGroupDB.SearchCustRateGroup(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    //    retCSAList.Add(custRateGroupArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^(�ϓ����)�f�[�^���o
                    //    ArrayList customerChangeArrList = new ArrayList();
                    //    DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
                    //    status = _customerChangeDB.SearchCustomerChange(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    //    retCSAList.Add(customerChangeArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^���o
                    //    ArrayList custSlipMngArrList = new ArrayList();
                    //    DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
                    //    status = _custSlipMngDB.SearchCustSlipMng(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    //    retCSAList.Add(custSlipMngArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^���o
                    //    ArrayList custSlipNoSetArrList = new ArrayList();
                    //    DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
                    //    status = _custSlipNoSetDB.SearchCustSlipNoSet(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    //    retCSAList.Add(custSlipNoSetArrList);
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
                        DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                        status = _goodsUDB.SearchGoodsAll(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsAllList, out retMessage);
                        for (int m = 0; m < goodsAllList.Count; m++)
                        {
                            retCSAList.Add(goodsAllList[m]);
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
                    //    DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                    //    status = _goodsUDB.SearchGoodsU(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsUArrList, out goodsMngArrList, out retMessage);
                    //    retCSAList.Add(goodsUArrList);
                    //}

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^���o
                    //    ArrayList goodsPriceUArrList = new ArrayList();
                    //    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                    //    status = _goodsPriceUDB.SearchGoodsPriceU(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    //    retCSAList.Add(goodsPriceUArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // �������i�}�X�^�f�[�^���o
                    //    ArrayList isolIslandPrcArrList = new ArrayList();
                    //    DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
                    //    status = _isolIslandPrcDB.SearchIsolIslandPrc(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    //    retCSAList.Add(isolIslandPrcArrList);
                    //}
                    //DEL 2011/08/25 #23798 �������M�ōX�V�{�^�������ŏ������I�����Ȃ�---------------------------------<<<<<
                    #endregion
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0 && stockProcParam != null)
                {
                    // �݌Ƀ}�X�^�f�[�^���o
                    ArrayList stockArrList = new ArrayList();
                    DCStockDB _stockDB = new DCStockDB();
                    status = _stockDB.SearchStock(pmEnterpriseCodes, stockProcParam, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    retCSAList.Add(stockArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt != 0 && supplierProcParam != null)
                {
                    // �d����}�X�^�f�[�^���o
                    ArrayList supplierArrList = new ArrayList();
                    DCSupplierDB _supplierDB = new DCSupplierDB();
                    status = _supplierDB.SearchSupplier(pmEnterpriseCodes, supplierProcParam, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    retCSAList.Add(supplierArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt != 0 && rateProcParam != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �|���}�X�^�f�[�^���o
                        ArrayList rateArrList = new ArrayList();
                        DCRateDB _rateDB = new DCRateDB();
                        status = _rateDB.SearchRate(pmEnterpriseCodes, rateProcParam, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                        retCSAList.Add(rateArrList);
                    }                    
                }                
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MstDCControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
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
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����I�����t���擾����B
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // ��ƃR�[�h
                //sndRcvHisTableWork.EnterpriseCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;//ADD 2012/10/16 ������ for redmine#31026
                // ���_�R�[�h
                sndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //����M�������O���M�ԍ�
                sndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //// ����M�敪
                //sndRcvHisTableWork.SendOrReceiveDivCd = 1;
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                // ����M�敪:��M�����i�I���j
                sndRcvHisTableWork.SendOrReceiveDivCd = 4;
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                // ����M����
                //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 ������ for redmine#31026
                // ���
                sndRcvHisTableWork.Kind = 1;
                // ����M���O���o�����敪
                //sndRcvHisTableWork.SndLogExtraCondDiv = ((DCSecMngSndRcvWork)masterDivList[0]).SndLogExtraCondDiv;//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.SndLogExtraCondDiv = 1;//ADD 2012/10/16 ������ for redmine#31026
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //// �����J�n����
                //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                //// �����I������
                //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                // ���M���ƃR�[�h
                //sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestEpCode;//DEL 2012/10/16 ������ for redmine#31026
                sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//ADD 2012/10/16 ������ for redmine#31026
                // ���M�拒�_�R�[�h
                sndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                for (int i = 0; i < paramList.Count; i++)
                {
                    if (paramList[i].GetType() == typeof(CustomerProcParamWork))
                    {
                        CustomerProcParamWork customerProcParamWork = (CustomerProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = customerProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = customerProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(GoodsProcParamWork))
                    {
                        GoodsProcParamWork goodsProcParamWork = (GoodsProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = goodsProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = goodsProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(StockProcParamWork))
                    {
                        StockProcParamWork stockProcParamWork = (StockProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = stockProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = stockProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(SupplierProcParamWork))
                    {
                        SupplierProcParamWork supplierProcParamWork = (SupplierProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = supplierProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = supplierProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(RateProcParamWork))
                    {
                        RateProcParamWork rateProcParamWork = (RateProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = rateProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = rateProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                	else if (paramList[i].GetType() == typeof(EmployeeProcParamWork))
                    {
                        EmployeeProcParamWork employeeProcParamWork = (EmployeeProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = employeeProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = employeeProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(JoinPartsUProcParamWork))
                    {
                        JoinPartsUProcParamWork joinPartsUProcParamWork = (JoinPartsUProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = joinPartsUProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = joinPartsUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(UserGdBuyDivUProcParamWork))
                    {
                        UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = (UserGdBuyDivUProcParamWork)paramList[i];
                        //���M�ΏۊJ�n����
                        sndRcvHisTableWork.SndObjStartDate = userGdBuyDivUProcParamWork.UpdateDateTimeBegin;
                        //���M�ΏۏI������
                        sndRcvHisTableWork.SndObjEndDate = userGdBuyDivUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	// --- ADD 2012/07/26 ---------------------------------------------<<<<<
                }
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                // ����M���
                if (status == 0)
                {   // DC�X�V�����̏ꍇ
                    sndRcvHisTableWork.SndRcvCondition = 0;
                }
                else
                {   // DC�X�V���s�̏ꍇ
                    sndRcvHisTableWork.SndRcvCondition = 1;
                }
                // ����M�敪
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // ����M�̏ꍇ
                    sndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // ��M�̏ꍇ
                    sndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // �G���[���e
                sndRcvHisTableWork.SndRcvErrContents = retMessage;
                // ����M�t�@�C���h�c
                sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            }
            SndRcvHisTableDB sndRcvHisResDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisResDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<

            return status;
        }

        # endregion �� �}�X�^��M�̃f�[�^�������� ��

        #region �� �}�X�^���M�̍X�V���� ��
        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.30</br>
        /// <br>Update Note : 2012/07/26 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage)
        {
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
            //// �����J�n�������擾����B
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            //// ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            ArrayList tempSndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork tempSndRcvHisTableWork = null;

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                    ArrayList tempLogList = logList[i] as ArrayList;

                    for (int j = 0; j < tempLogList.Count; j++)
                    {
                        if (tempLogList[j].GetType() == typeof(SndRcvHisWork))
                        {
                            tempSndRcvHisTableWork = new SndRcvHisTableWork();
                            // ��ƃR�[�h
                            tempSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)tempLogList[j]).EnterpriseCode;
                            // ���_�R�[�h
                            tempSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)tempLogList[j]).SectionCode;
                            // ����M���𑗐M�ԍ�
                            tempSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)tempLogList[j]).SndRcvHisConsNo;
                            // ����M�敪:���M�����i�J�n�j
                            tempSndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // ����M����
                            tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                            // ���
                            tempSndRcvHisTableWork.Kind = 1;
                            // ����M���O���o�����敪
                            tempSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)tempLogList[j]).SndLogExtraCondDiv;
                            // ���M���ƃR�[�h
                            tempSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)tempLogList[j]).SendDestEpCode;
                            // ���M�拒�_�R�[�h
                            tempSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)tempLogList[j]).SendDestSecCode;
                            //���M�ΏۊJ�n����
                            tempSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)tempLogList[j]).SndObjStartDate.Ticks;
                            //���M�ΏۏI������
                            tempSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)tempLogList[j]).SndObjEndDate.Ticks;
                            // ����M���
                            tempSndRcvHisTableWork.SndRcvCondition = 0;
                            // ����M�敪
                            tempSndRcvHisTableWork.TempReceiveDiv = 0;
                            // ����M�t�@�C���h�c
                            tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                            tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
                        }
                    }
                }
            }
            SndRcvHisTableDB tempSndRcvHisTableDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisTableDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 >>>
            // �O�̈�AP���b�N�p�̃X�e�[�^�X��p��
            int status3 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 <<<
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            // private field
            DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
            DCSecInfoSetWork secInfoSetWork = new DCSecInfoSetWork();
            DCSubSectionDB _subSectionDB = new DCSubSectionDB();
            DCSubSectionWork subSectionWork = new DCSubSectionWork();
            DCEmployeeDB _employeeDB = new DCEmployeeDB();
            DCEmployeeWork employeeWork = new DCEmployeeWork();
            DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
            DCEmployeeDtlWork employeeDtlWork = new DCEmployeeDtlWork();
            DCWarehouseDB _warehouseDB = new DCWarehouseDB();
            DCWarehouseWork warehouseWork = new DCWarehouseWork();
            DCCustomerDB _customerWorkDB = new DCCustomerDB();
            DCCustomerWork customerWork = new DCCustomerWork();
            DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
            DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            DCCustomerMemoDB _customerMemoDB = new DCCustomerMemoDB();
            DCCustomerMemoWork customerMemoWork = new DCCustomerMemoWork();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
            DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();
            DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
            DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();
            DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
            DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();
            DCSupplierDB _supplierDB = new DCSupplierDB();
            DCSupplierWork supplierWork = new DCSupplierWork();
            DCMakerUDB _makerUWorkDB = new DCMakerUDB();
            DCMakerUWork makerUWork = new DCMakerUWork();
            DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
            DCBLGoodsCdUWork bLGoodsCdUWork = new DCBLGoodsCdUWork();
            DCGoodsUDB _goodsUDB = new DCGoodsUDB();
            DCGoodsUWork goodsUWork = new DCGoodsUWork();
            DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
            DCGoodsPriceUWork goodsPriceUWork = new DCGoodsPriceUWork();
            DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
            DCGoodsMngWork goodsMngWork = new DCGoodsMngWork();
            DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
            DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();
            DCStockDB _stockDB = new DCStockDB();
            DCStockWork stockWork = new DCStockWork();
            DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
            DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();
            DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
            DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();
            DCRateDB _rateDB = new DCRateDB();
            DCRateWork rateWork = new DCRateWork();
            DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
            DCGoodsSetWork goodsSetWork = new DCGoodsSetWork();
            DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
            DCPartsSubstUWork partsSubstUWork = new DCPartsSubstUWork();
            DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
            DCEmpSalesTargetWork empSalesTargetWork = new DCEmpSalesTargetWork();
            DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
            DCCustSalesTargetWork custSalesTargetWork = new DCCustSalesTargetWork();
            DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
            DCGcdSalesTargetWork gcdSalesTargetWork = new DCGcdSalesTargetWork();
            DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
            DCGoodsGroupUWork goodsGroupUWork = new DCGoodsGroupUWork();
            DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
            DCBLGroupUWork bLGroupUWork = new DCBLGroupUWork();
            DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
            DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();
            DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
            DCTBOSearchUWork tBOSearchUWork = new DCTBOSearchUWork();
            DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
            DCPartsPosCodeUWork partsPosCodeUWork = new DCPartsPosCodeUWork();
            DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
            DCBLCodeGuideWork bLCodeGuideWork = new DCBLCodeGuideWork();
            DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
            DCModelNameUWork modelNameUWork = new DCModelNameUWork();
            //����M���o�����������O
            SndRcvHisDB _logDB = new SndRcvHisDB();

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

                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                resNm = GetResourceName(enterpriseCode);
                // del 2012/09/05 >>>
                //// MOD 2009/07/06 --->>>
                ////�`�o���b�N
                //status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                //// MOD 2009/07/06 ---<<<

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                // del 2012/09/05 <<<
                // add 2012/09/05 >>>
                //�`�o���b�N
                status3 = Lock(resNm, 1, sqlConnection, sqlTransaction);

                if (status3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status3;
                }
                status3 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // add 2012/09/05 <<<

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC���_���ݒ�}�X�^�X�V����
                        if (wktype.Equals(typeof(DCSecInfoSetWork)))
                        {
                            _secInfoSetDB = new DCSecInfoSetDB();
                            secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_SECINFOSET))
                            {
                                tempSndRcvDic.Add(MST_ID_SECINFOSET, MST_ID_SECINFOSET);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCSubSectionWork)))
                        {
                            _subSectionDB = new DCSubSectionDB();
                            subSectionWork = (DCSubSectionWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_SUBSECTION))
                            {
                                tempSndRcvDic.Add(MST_ID_SUBSECTION, MST_ID_SUBSECTION);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�]�ƈ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmployeeWork)))
                        {
                            _employeeDB = new DCEmployeeDB();
                            employeeWork = (DCEmployeeWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_EMPLOYEE))
                            {
                                tempSndRcvDic.Add(MST_ID_EMPLOYEE, MST_ID_EMPLOYEE);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�]�ƈ��ڍ׃}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                        {
                            _employeeDtlDB = new DCEmployeeDtlDB();
                            employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_EMPLOYEEDTL))
                            {
                                tempSndRcvDic.Add(MST_ID_EMPLOYEEDTL, MST_ID_EMPLOYEEDTL);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�q�Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCWarehouseWork)))
                        {
                            _warehouseDB = new DCWarehouseDB();
                            warehouseWork = (DCWarehouseWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_WAREHOUSE))
                            {
                                tempSndRcvDic.Add(MST_ID_WAREHOUSE, MST_ID_WAREHOUSE);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���Ӑ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCCustomerWork)))
                        {
                            _customerWorkDB = new DCCustomerDB();
                            customerWork = (DCCustomerWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOME))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOME, MST_ID_CUSTOME);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���Ӑ�}�X�^(�ϓ����)�X�V����
                        else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                        {
                            _customerChangeDB = new DCCustomerChangeDB();
                            customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMECHA))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMECHA, MST_ID_CUSTOMECHA);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                        // DC���Ӑ�}�X�^(�������)�X�V����
                        else if (wktype.Equals(typeof(DCCustomerMemoWork)))
                        {
                            _customerMemoDB = new DCCustomerMemoDB();
                            customerMemoWork = (DCCustomerMemoWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMEMEMO))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMEMEMO, MST_ID_CUSTOMEMEMO);
                            }
                        }
                        // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                        // DC���Ӑ�}�X�^�i�`�[�Ǘ��j�X�V����
                        else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                        {
                            _custSlipMngDB = new DCCustSlipMngDB();
                            custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMESLIPMNG))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMESLIPMNG, MST_ID_CUSTOMESLIPMNG);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���Ӑ�}�X�^�i�|���O���[�v�j�X�V����
                        else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                        {

                            custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];                           
                            // ����f�[�^
                            _custRateGroupList.Add(custRateGroupWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMEGROUP))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMEGROUP, MST_ID_CUSTOMEGROUP);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���Ӑ�}�X�^(�`�[�ԍ�)�X�V����
                        else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                        {
                            _custSlipNoSetDB = new DCCustSlipNoSetDB();
                            custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMESLIPNO))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMESLIPNO, MST_ID_CUSTOMESLIPNO);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�d����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCSupplierWork)))
                        {
                            _supplierDB = new DCSupplierDB();
                            supplierWork = (DCSupplierWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_SUPPLIER))
                            {
                                tempSndRcvDic.Add(MST_ID_SUPPLIER, MST_ID_SUPPLIER);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���[�J�[�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCMakerUWork)))
                        {
                            _makerUWorkDB = new DCMakerUDB();
                            makerUWork = (DCMakerUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_MAKERU))
                            {
                                tempSndRcvDic.Add(MST_ID_MAKERU, MST_ID_MAKERU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCBL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                        {
                            _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
                            bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_BLGOODSCDU))
                            {
                                tempSndRcvDic.Add(MST_ID_BLGOODSCDU, MST_ID_BLGOODSCDU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsUWork)))
                        {
                            _goodsUDB = new DCGoodsUDB();
                            goodsUWork = (DCGoodsUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsUDB.Delete(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsUDB.Insert(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSU))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSU, MST_ID_GOODSU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                        {
                            goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                            _goodsPriceUList.Add(goodsPriceUWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSUPRI))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSUPRI, MST_ID_GOODSUPRI);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i�Ǘ����}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGoodsMngWork)))
                        {
                            _goodsMngDB = new DCGoodsMngDB();
                            goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSUMNG))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSUMNG, MST_ID_GOODSUMNG);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�������i�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                        {
                            _isolIslandPrcDB = new DCIsolIslandPrcDB();
                            isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSUISO))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSUISO, MST_ID_GOODSUISO);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�݌Ƀ}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCStockWork)))
                        {
                            _stockDB = new DCStockDB();
                            stockWork = (DCStockWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _stockDB.Delete(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_STOCK))
                            {
                                tempSndRcvDic.Add(MST_ID_STOCK, MST_ID_STOCK);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���[�U�[�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                        {
                            _userGdBdUDB = new DCUserGdBdUDB();
                            userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_USERGDU))
                            {
                                tempSndRcvDic.Add(MST_ID_USERGDU, MST_ID_USERGDU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�|���D��Ǘ��}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                        {
                            rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                            _rateProtyMngList.Add(rateProtyMngWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_RATEPROTYMNG))
                            {
                                tempSndRcvDic.Add(MST_ID_RATEPROTYMNG, MST_ID_RATEPROTYMNG);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�|���}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCRateWork)))
                        {
                            rateWork = (DCRateWork)retCSATemList[j];
                            _rateList.Add(rateWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_RATE))
                            {
                                tempSndRcvDic.Add(MST_ID_RATE, MST_ID_RATE);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i�Z�b�g�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGoodsSetWork)))
                        {
                            goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                            _goodsSetList.Add(goodsSetWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSSET))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSSET, MST_ID_GOODSSET);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i��փ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                        {
                            _partsSubstUDB = new DCPartsSubstUDB();
                            partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_PARTSSUBSTU))
                            {
                                tempSndRcvDic.Add(MST_ID_PARTSSUBSTU, MST_ID_PARTSSUBSTU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�]�ƈ��ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                        {
                            _empSalesTargetDB = new DCEmpSalesTargetDB();
                            empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_EMPSALESTARGET))
                            {
                                tempSndRcvDic.Add(MST_ID_EMPSALESTARGET, MST_ID_EMPSALESTARGET);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���Ӑ�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                        {
                            _custSalesTargetDB = new DCCustSalesTargetDB();
                            custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTSALESTARGET))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTSALESTARGET, MST_ID_CUSTSALESTARGET);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i�ʔ���ڕW�ݒ�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                        {
                            _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                            gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GCDSALESTARGET))
                            {
                                tempSndRcvDic.Add(MST_ID_GCDSALESTARGET, MST_ID_GCDSALESTARGET);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���i�����ރ}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                        {
                            _goodsGroupUDB = new DCGoodsGroupUDB();
                            goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSMGROUPU))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSMGROUPU, MST_ID_GOODSMGROUPU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCBL�O���[�v�}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCBLGroupUWork)))
                        {
                            _bLGroupUDB = new DCBLGroupUDB();
                            bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_BLGROUPU))
                            {
                                tempSndRcvDic.Add(MST_ID_BLGROUPU, MST_ID_BLGROUPU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�����}�X�^�i���[�U�[�o�^���j�X�V����
                        else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                        {
                            joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                            _joinPartsUList.Add(joinPartsUWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_JOINPARTSU))
                            {
                                tempSndRcvDic.Add(MST_ID_JOINPARTSU, MST_ID_JOINPARTSU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCTBO�����}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                        {
                            tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                            _tboSearchUList.Add(tBOSearchUWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_TBOSEARCHU))
                            {
                                tempSndRcvDic.Add(MST_ID_TBOSEARCHU, MST_ID_TBOSEARCHU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�X�V����
                        else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                        {
                            partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                            _partsPosCodeUList.Add(partsPosCodeUWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_PARTSPOSCODEU))
                            {
                                tempSndRcvDic.Add(MST_ID_PARTSPOSCODEU, MST_ID_PARTSPOSCODEU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCBL�R�[�h�K�C�h�}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                        {
                            bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                            _blCodeGuideList.Add(bLCodeGuideWork);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_BLCODEGUIDE))
                            {
                                tempSndRcvDic.Add(MST_ID_BLCODEGUIDE, MST_ID_BLCODEGUIDE);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC�Ԏ햼�̃}�X�^�X�V����
                        else if (wktype.Equals(typeof(DCModelNameUWork)))
                        {
                            _modelNameUDB = new DCModelNameUDB();
                            modelNameUWork = (DCModelNameUWork)retCSATemList[j];
                            // ���݂���f�[�^���폜����B
                            _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // ���o�����f�[�^��o�^����B
                            _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_MODELNAMEU))
                            {
                                tempSndRcvDic.Add(MST_ID_MODELNAMEU, MST_ID_MODELNAMEU);
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                        }
                    }
                }
                // ADD 2009/06/09 --->>>
                // ���Ӑ�}�X�^�i�|���O���[�v�j
                if (_custRateGroupList != null && _custRateGroupList.Count > 0)
                {
                    _custRateGroupDB = new DCCustRateGroupDB();
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
                    _goodsPriceUDB = new DCGoodsPriceUDB();
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
                    _rateProtyMngDB = new DCRateProtyMngDB();
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
                    _rateDB = new DCRateDB();
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
                    _goodsSetDB = new DCGoodsSetDB();
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
                    _joinPartsUDB = new DCJoinPartsUDB();
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
                    _tBOSearchUDB = new DCTBOSearchUDB();
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
                    _partsPosCodeUDB = new DCPartsPosCodeUDB();
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
                    _bLCodeGuideDB = new DCBLCodeGuideDB();
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

                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }

                }

                ArrayList temSndRcvHisResWorkList = new ArrayList();
                SndRcvHisTableWork temSndRcvHisTableWork = null;

                for (int i = 0; i < logList.Count; i++)
                {
                    if (logList[i].GetType() == typeof(ArrayList))
                    {
                        ArrayList temLogList = logList[i] as ArrayList;

                        for (int j = 0; j < temLogList.Count; j++)
                        {
                            if (temLogList[j].GetType() == typeof(SndRcvHisWork))
                            {
                                temSndRcvHisTableWork = new SndRcvHisTableWork();
                                // ��ƃR�[�h
                                temSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)temLogList[j]).EnterpriseCode;
                                // ���_�R�[�h
                                temSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)temLogList[j]).SectionCode;
                                // ����M���𑗐M�ԍ�
                                temSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)temLogList[j]).SndRcvHisConsNo;
                                // ����M�敪:���M�����i�I���j
                                temSndRcvHisTableWork.SendOrReceiveDivCd = 1;
                                // ����M����
                                temSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                                // ���
                                temSndRcvHisTableWork.Kind = 1;
                                // ����M���O���o�����敪
                                temSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)temLogList[j]).SndLogExtraCondDiv;
                                // ���M���ƃR�[�h
                                temSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)temLogList[j]).SendDestEpCode;
                                // ���M�拒�_�R�[�h
                                temSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)temLogList[j]).SendDestSecCode;
                                //���M�ΏۊJ�n����
                                temSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)temLogList[j]).SndObjStartDate.Ticks;
                                //���M�ΏۏI������
                                temSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)temLogList[j]).SndObjEndDate.Ticks;
                                // ����M���
                                temSndRcvHisTableWork.SndRcvCondition = 0;
                                // ����M�敪
                                temSndRcvHisTableWork.TempReceiveDiv = 0;
                                // ����M�t�@�C���h�c
                                temSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                                temSndRcvHisResWorkList.Add(temSndRcvHisTableWork);
                            }
                        }
                    }
                }

                SndRcvHisTableDB temSndRcvHisTableDB = new SndRcvHisTableDB();
                object temObjSndRcvHisResWorkList = temSndRcvHisResWorkList as object;
                temSndRcvHisTableDB.Write(ref temObjSndRcvHisResWorkList);
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                //�������O
                status2 = _logDB.WriteProc(logList, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MstDCControlDB.Update SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/26 �L�w��
            }
            catch (Exception e)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(e, "MstDCControlDB.Update Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = e.Message;    // ADD 2012/07/26 �L�w��
            }
            finally
            {
                // upd 2012/09/05 >>>
                //if (resNm != "")
                if (resNm != "" && status3 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // upd 2012/09/05 <<<
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
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
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
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            //STATUS��߂�
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = status2;
            }
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// �����I�����t���擾����B
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                    ArrayList al= logList[i] as ArrayList;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (al[j].GetType() == typeof(SndRcvHisWork))
                        {
                            // ��ƃR�[�h
                            sndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)al[j]).EnterpriseCode;
                            // ���_�R�[�h
                            sndRcvHisTableWork.SectionCode = ((SndRcvHisWork)al[j]).SectionCode;
                            // ����M���𑗐M�ԍ�
                            sndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)al[j]).SndRcvHisConsNo;
                            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //// ����M�敪
                            //sndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            // ����M�敪:���M�����i����M�����X�V�j
                            sndRcvHisTableWork.SendOrReceiveDivCd = 2;
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ����M����
                            //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 ������ for redmine#31026
                            sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 ������ for redmine#31026
                            // ���
                            sndRcvHisTableWork.Kind = 1;
                            // ����M���O���o�����敪
                            sndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)al[j]).SndLogExtraCondDiv;
                            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //// �����J�n����
                            //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                            //// �����I������
                            //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ���M���ƃR�[�h
                            sndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)al[j]).SendDestEpCode;
                            // ���M�拒�_�R�[�h
                            sndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)al[j]).SendDestSecCode;
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //���M�ΏۊJ�n����
                            sndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)al[j]).SndObjStartDate.Ticks;
                            //���M�ΏۏI������
                            sndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)al[j]).SndObjEndDate.Ticks;
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ����M���
                            if (status == 0)
                            {
                                sndRcvHisTableWork.SndRcvCondition = 0;
                            }
                            else
                            {
                                sndRcvHisTableWork.SndRcvCondition = 1;
                                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                                // �G���[���e
                                if (string.IsNullOrEmpty(retMessage))
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = "�������O�X�V���s���܂����B";
                                }
                                else
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = retMessage;
                                }
                                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                            }
                            // ����M�敪
                            sndRcvHisTableWork.TempReceiveDiv = 0;
                            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                            //// �G���[���e
                            //sndRcvHisTableWork.SndRcvErrContents = retMessage;
                            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                            // ����M�t�@�C���h�c
                            //sndRcvHisTableWork.SndRcvFileID = ((SndRcvHisWork)al[j]).SndRcvFileID;//DEL 2012/10/16 ������ for redmine#31026
                            sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;//ADD 2012/10/16 ������ for redmine#31026

                            sndRcvHisResWorkList.Add(sndRcvHisTableWork);
                        }
                    }
                }
            }
            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD �L�w�� 2012/07/26 FOR Redmine#31026---------<<<<<

            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            ////STATUS��߂�
            //if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = status2;
            //}
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            return status;
        }

        #endregion

        # region �� �}�X�^��M�̃f�[�^������������ ��
        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
        /// </summary>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="secMngSndRcvWork">�}�X�^�敪</param>
        /// <param name="param">�}�X�^���o�����N���X</param>
        /// <param name="count">�߂錏��</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        public int GetObjCount(string pmEnterpriseCodes, DCSecMngSndRcvWork secMngSndRcvWork, object param, ref int count, out string retMessage)
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
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                // �g�����U�N�V����
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                switch (secMngSndRcvWork.FileId)
                { 
                    case MST_GOODSU:
                        //���i�}�X�^
                        DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                        status = _goodsUDB.SearchGoodsUCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count,out retMessage);
                        break;
                    case MST_STOCK:
                        // �݌Ƀ}�X�^
                        DCStockDB _stockDB = new DCStockDB();
                        status = _stockDB.SearchStockCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count, out retMessage);
                        break;
                    default:
                        count = -1;
                        break;
                
                }
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "MstDCControlDB.GetObjCount Exception=" + ex.Message);
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
        # endregion �� �}�X�^��M�̃f�[�^������������ ��
        #endregion ADD 2011/07/26 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j


        #region �� �}�X�^�f�[�^�̃N���A���� ��DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        ///// <summary>
        ///// D�}�X�^�f�[�^�̃N���A����
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : ���ɂȂ�</br>
        ///// <br>Programmer : ����</br>
        ///// <br>Date       : 2011.08.26</br>
        ///// </remarks>
        //public int DCMSDataClear(string enterpriseCode)
        //{
        //    //��STATUS������
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //    SqlCommand sqlCommand = null;
        //    string resNm = "";

        //    // private field
        //    DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
        //    DCSecInfoSetWork secInfoSetWork = new DCSecInfoSetWork();
        //    DCSubSectionDB _subSectionDB = new DCSubSectionDB();
        //    DCSubSectionWork subSectionWork = new DCSubSectionWork();
        //    DCEmployeeDB _employeeDB = new DCEmployeeDB();
        //    DCEmployeeWork employeeWork = new DCEmployeeWork();
        //    DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
        //    DCEmployeeDtlWork employeeDtlWork = new DCEmployeeDtlWork();
        //    DCWarehouseDB _warehouseDB = new DCWarehouseDB();
        //    DCWarehouseWork warehouseWork = new DCWarehouseWork();
        //    DCCustomerDB _customerWorkDB = new DCCustomerDB();
        //    DCCustomerWork customerWork = new DCCustomerWork();
        //    DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
        //    DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();
        //    DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
        //    DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();
        //    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
        //    DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();
        //    DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
        //    DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();
        //    DCSupplierDB _supplierDB = new DCSupplierDB();
        //    DCSupplierWork supplierWork = new DCSupplierWork();
        //    DCMakerUDB _makerUWorkDB = new DCMakerUDB();
        //    DCMakerUWork makerUWork = new DCMakerUWork();
        //    DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
        //    DCBLGoodsCdUWork bLGoodsCdUWork = new DCBLGoodsCdUWork();
        //    DCGoodsUDB _goodsUDB = new DCGoodsUDB();
        //    DCGoodsUWork goodsUWork = new DCGoodsUWork();
        //    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
        //    DCGoodsPriceUWork goodsPriceUWork = new DCGoodsPriceUWork();
        //    DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
        //    DCGoodsMngWork goodsMngWork = new DCGoodsMngWork();
        //    DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
        //    DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();
        //    DCStockDB _stockDB = new DCStockDB();
        //    DCStockWork stockWork = new DCStockWork();
        //    DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
        //    DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();
        //    DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
        //    DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();
        //    DCRateDB _rateDB = new DCRateDB();
        //    DCRateWork rateWork = new DCRateWork();
        //    DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
        //    DCGoodsSetWork goodsSetWork = new DCGoodsSetWork();
        //    DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
        //    DCPartsSubstUWork partsSubstUWork = new DCPartsSubstUWork();
        //    DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
        //    DCEmpSalesTargetWork empSalesTargetWork = new DCEmpSalesTargetWork();
        //    DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
        //    DCCustSalesTargetWork custSalesTargetWork = new DCCustSalesTargetWork();
        //    DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
        //    DCGcdSalesTargetWork gcdSalesTargetWork = new DCGcdSalesTargetWork();
        //    DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
        //    DCGoodsGroupUWork goodsGroupUWork = new DCGoodsGroupUWork();
        //    DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
        //    DCBLGroupUWork bLGroupUWork = new DCBLGroupUWork();
        //    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
        //    DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();
        //    DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
        //    DCTBOSearchUWork tBOSearchUWork = new DCTBOSearchUWork();
        //    DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
        //    DCPartsPosCodeUWork partsPosCodeUWork = new DCPartsPosCodeUWork();
        //    DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
        //    DCBLCodeGuideWork bLCodeGuideWork = new DCBLCodeGuideWork();
        //    DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
        //    DCModelNameUWork modelNameUWork = new DCModelNameUWork();

        //    try
        //    {
				
        //        // �R�l�N�V��������
        //        sqlConnection = this.CreateSqlConnectionData(true);

        //        // �g�����U�N�V����
        //        sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

        //        resNm = GetResourceName(enterpriseCode);

        //        //�`�o���b�N
        //        status = Lock(resNm, 1, sqlConnection, sqlTransaction);

        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            return status;
        //        }

        //        //	���_�ݒ�}�X�^
        //        _secInfoSetDB = new DCSecInfoSetDB();
        //        _secInfoSetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	����ݒ�}�X�^
        //        _subSectionDB = new DCSubSectionDB();
        //        _subSectionDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�q�ɐݒ�}�X�^
        //        _warehouseDB = new DCWarehouseDB();
        //        _warehouseDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�]�ƈ��ڍ׃}�X�^
        //        _employeeDtlDB = new DCEmployeeDtlDB();
        //        _employeeDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�]�ƈ��ݒ�}�X�^
        //        _employeeDB = new DCEmployeeDB();
        //        _employeeDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���[�U�[�K�C�h�}�X�^
        //        _userGdBdUDB = new DCUserGdBdUDB();
        //        _userGdBdUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�|���D��Ǘ��}�X�^
        //        _rateProtyMngDB = new DCRateProtyMngDB();
        //        _rateProtyMngDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�|���}�X�^
        //        _rateDB = new DCRateDB();
        //        _rateDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���i�ʔ���ڕW�ݒ�}�X�^
        //        _gcdSalesTargetDB = new DCGcdSalesTargetDB();
        //        _gcdSalesTargetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���Ӑ�ʔ���ڕW�ݒ�}�X�^
        //        _custSalesTargetDB = new DCCustSalesTargetDB();
        //        _custSalesTargetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�]�ƈ��ʔ���ڕW�ݒ�}�X�^
        //        _empSalesTargetDB = new DCEmpSalesTargetDB();
        //        _empSalesTargetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���Ӑ�}�X�^
        //        _customerWorkDB = new DCCustomerDB();
        //        _customerWorkDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���Ӑ�}�X�^(�`�[�ԍ�)
        //        _custSlipNoSetDB = new DCCustSlipNoSetDB();
        //        _custSlipNoSetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���Ӑ�}�X�^(�ϓ����)
        //        _customerChangeDB = new DCCustomerChangeDB();
        //        _customerChangeDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���Ӑ�}�X�^�i�|���O���[�v�j
        //        _custRateGroupDB = new DCCustRateGroupDB();
        //        _custRateGroupDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���Ӑ�}�X�^�i�`�[�Ǘ��j
        //        _custSlipMngDB = new DCCustSlipMngDB();
        //        _custSlipMngDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�d����}�X�^
        //        _supplierDB = new DCSupplierDB();
        //        _supplierDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�����}�X�^
        //        _joinPartsUDB = new DCJoinPartsUDB();
        //        _joinPartsUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�Z�b�g�}�X�^
        //        _goodsSetDB = new DCGoodsSetDB();
        //        _goodsSetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�s�a�n�}�X�^
        //        _tBOSearchUDB = new DCTBOSearchUDB();
        //        _tBOSearchUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�Ԏ햼�̃}�X�^
        //        _modelNameUDB = new DCModelNameUDB();
        //        _modelNameUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�a�k�R�[�h�}�X�^
        //        _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
        //        _bLGoodsCdUWorkDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���[�J�[�}�X�^
        //        _makerUWorkDB = new DCMakerUDB();
        //        _makerUWorkDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���i�����ރ}�X�^
        //        _goodsGroupUDB = new DCGoodsGroupUDB();
        //        _goodsGroupUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�O���[�v�R�[�h�}�X�^
        //        _bLGroupUDB = new DCBLGroupUDB();
        //        _bLGroupUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	BL�R�[�h�K�C�h�}�X�^
        //        _bLCodeGuideDB = new DCBLCodeGuideDB();
        //        _bLCodeGuideDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���i�Ǘ����}�X�^
        //        _goodsMngDB = new DCGoodsMngDB();
        //        _goodsMngDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���i�}�X�^(���i���j
        //        _goodsPriceUDB = new DCGoodsPriceUDB();
        //        _goodsPriceUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���i�}�X�^
        //        _goodsUDB = new DCGoodsUDB();
        //        _goodsUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�������i�}�X�^
        //        _isolIslandPrcDB = new DCIsolIslandPrcDB();
        //        _isolIslandPrcDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	�݌Ƀ}�X�^
        //        _stockDB = new DCStockDB();
        //        _stockDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	��փ}�X�^
        //        _partsSubstUDB = new DCPartsSubstUDB();
        //        _partsSubstUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	���ʃ}�X�^
        //        _partsPosCodeUDB = new DCPartsPosCodeUDB();
        //        _partsPosCodeUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        // ���M�������O
        //        this.ClearSndRcvEtr(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //        this.ClearSndRcvhis(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        // ���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(ex, "MstDCControlDB.Update SqlException=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    catch (Exception e)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        base.WriteErrorLog(e, "MstDCControlDB.Update Exception=" + e.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (resNm != "")
        //        {
        //            //�`�o�A�����b�N
        //            status2 = Release(resNm, sqlConnection, sqlTransaction);

        //            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            }
        //        }

        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //        }

        //        if (sqlTransaction != null) sqlTransaction.Dispose();
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    //STATUS��߂�
        //    if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        status = status2;
        //    }
        //    return status;
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
		#endregion

		// ADD 2011.08.26 ���� ---------->>>>>
		# region [ClearSndRcvEtr] DLL by Liangsd 
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// R�N���X�� Method��SQL�������ʖ�
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearSndRcvEtr(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearSndRcvEtrProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        //}
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearSndRcvEtrProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Delete�R�}���h�̐���
        //    sqlCommand.CommandText = "DELETE FROM SNDRCVETRRF WHERE EXISTS ( SELECT * FROM SNDRCVHISRF WHERE (SNDRCVHISRF.ENTERPRISECODERF = @FINFENTERPRISECODE OR SNDRCVHISRF.SENDDESTEPCODERF = @FINDSENDDESTEPCODE ) AND SNDRCVHISRF.KINDRF = @FINDKIND AND SNDRCVHISRF.ENTERPRISECODERF = SNDRCVETRRF.ENTERPRISECODERF AND SNDRCVHISRF.SECTIONCODERF = SNDRCVETRRF.SECTIONCODERF AND SNDRCVHISRF.SNDRCVHISCONSNORF = SNDRCVETRRF.SNDRCVHISCONSNORF ) ";
        //    //Prameter�I�u�W�F�N�g�̍쐬
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINFENTERPRISECODE", SqlDbType.NChar);
        //    SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
        //    SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);

        //    //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //    findParaEnterpriseCode.Value = enterpriseCode;
        //    findParaSendEstEpCode.Value = enterpriseCode;
        //    paraKind.Value = SqlDataMediator.SqlSetInt32(1);

        //    // �f�[�^���폜����
        //    sqlCommand.ExecuteNonQuery();

        //}
        //#endregion

        //# region [ClearSndRcvhis]
        //// R�N���X�� Method��SQL�������ʖ�
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearSndRcvhis(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearSndRcvhisProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        //}
        ///// <summary>
        ///// �f�[�^�N���A
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <param name="sqlCommand">SQL�R�����g</param>
        ///// <returns></returns>
        //private void ClearSndRcvhisProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Delete�R�}���h�̐���
        //    sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF WHERE ( ENTERPRISECODERF=@FINDENTERPRISECODE OR SENDDESTEPCODERF=@FINDSENDDESTEPCODE) AND KINDRF=@FINDKINDRF ";
        //    //Prameter�I�u�W�F�N�g�̍쐬
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
        //    SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);

        //    //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //    findParaEnterpriseCode.Value = enterpriseCode;
        //    findParaSendEstEpCode.Value = enterpriseCode;
        //    paraKind.Value = SqlDataMediator.SqlSetInt32(1);

        //    // �f�[�^���폜����
        //    sqlCommand.ExecuteNonQuery();

        //}
		#endregion
		// ADD 2011.08.26 ���� ----------<<<<<
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
    }
}
