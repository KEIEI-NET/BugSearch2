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
// �C �� ��  2009/06/17  �C�����e : PVCS�[#161 ���o�Ώۃf�[�^�����݂��Ȃ��ꍇ�̃��O�ɂ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/06  �C�����e : �}�X�^����M�����̂`�o�o���b�N�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011/07/25  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/27  �C�����e : #23922 ��M�����őΏۊO�̍��ڂ���M����Ă��܂��܂��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/30  �C�����e : #24191 �}�X�^���M�i�������M�j�̑��M���s���ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/31  �C�����e : Redmine #24278 �f�[�^������M�������N�����܂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : ������
// �C �� ��  2011/09/05  �C�����e : #24047 ���M���s���̑Ώ��ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/09/06  �C�����e : #24364 ���M�^�C���A�E�g���̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : �g���Y
// �C �� ��  2011/09/15  �C�����e : #23934 ���M�I�����t�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �C���S�� : FSI���� �f��
// �C �� ��  2012/07/26  �C�����e : ���o�����敪�ɏ]�ƈ��A���[�U�[�K�C�h(�̔��敪)�A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770021-00 �쐬�S�� : ���O
// �� �� ��  2021/04/12  �C�����e : ���Ӑ惁�����̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �}�X�^����M�����X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �}�X�^����M�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// <br>Update Note: 2021/04/12 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
    /// </remarks>
    public class MstUpdCountAcs
    {
        #region �� Const Memebers ��
        private const string ZERO_0 = "0";
        private const string MARK_1 = ":";
        private const string MARK_2 = "�A";
        private const string MARK_3 = " ";
        private const string MARK_4 = ",";
        private const string PROGRAM_ID = "PMKYO01201UA";
        private const string PROGRAM_NAME = "�}�X�^����M����";
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

        private const string COUNTNAME = "��";

        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        private const string FILEID_CUSTOMER = "CustomerRF";
        private const string FILEID_GOODS = "GoodsURF";
        private const string FILEID_STOCK = "StockRF";
        private const string FILEID_SUPPLIER = "SupplierRF";
        private const string FILEID_RATE = "RateRF";
        // --- ADD 2012/07/26 ------------------------->>>>>
        private const string FILEID_EMPLOYEE = "EmployeeDtlRF";
        private const string FILEID_JOINPARTSU = "JoinPartsURF";
        private const string FILEID_USERGDU = "UserGdBdURF";
        // --- ADD 2012/07/26 -------------------------<<<<<
        private const int MAX_CNT = 20000;
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        private const int INT_ZERO = 0; //ADD 2021/04/12 ���O FOR PMKOBETSU-4136
        #endregion �� Const Memebers ��

        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private MstUpdCountAcs()
        {
            // �ϐ�������
            this._dataSet = new UpdateResultDataSet();
            this._extractionConditionDataSet = new ExtractionConditionDataSet();
            this._receiveInfoDataSet = new ReceiveInfoDataSet();
            this._receiveConditionDataSet = new ReceiveConditionDataSet();

            this._updateResultDataTable = this._dataSet.UpdateResult;
            this._extractionConditionDataTable = this._extractionConditionDataSet.ExtractionCondition;
            this._receiveInfoDataTable = this._receiveInfoDataSet.ReceiveInfo;
            this._receiveConditionDataTable = this._receiveConditionDataSet.ReceiveCondition;
            this._secMngConnectStAcs = new SecMngConnectStAcs();
        }
        # endregion �� Constructor ��

        # region �� Properties ��

        /// <summary>
        /// �f�[�^���M�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public UpdateResultDataSet.UpdateResultDataTable UpdateResultDataTable
        {
            get { return _updateResultDataTable; }
        }

        /// <summary>
        /// �f�[�^���M�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public ExtractionConditionDataSet.ExtractionConditionDataTable ExtractionConditionDataTable
        {
            get { return _extractionConditionDataTable; }
        }

        /// <summary>
        /// �f�[�^���M�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public ReceiveInfoDataSet.ReceiveInfoDataTable ReceiveInfoDataTable
        {
            get { return _receiveInfoDataTable; }
        }

        /// <summary>
        /// �f�[�^���M�����f�[�^�e�[�u���v���p�e�B
        /// </summary>
        public ReceiveConditionDataSet.ReceiveConditionDataTable ReceiveConditionDataTable
        {
            get { return _receiveConditionDataTable; }
        }
        //ADD 2011/08/31 Redmine #24278-------------->>>>>
        /// <summary>
        /// �����蓮�敪
        /// </summary>
        public Boolean AutoSendRecvDiv
        {
            get { return _autoSendRecvDiv; }
            set { _autoSendRecvDiv = value; }
        }
        //ADD 2011/08/31 Redmine #24278--------------<<<<<
        # endregion �� Properties ��

        # region �� Private Members ��
        // ���M���f�[�^�Z�b�g
        private UpdateResultDataSet _dataSet;
        // ���M�����f�[�^�Z�b�g
        private ExtractionConditionDataSet _extractionConditionDataSet;
        // ��M���f�[�^�Z�b�g
        private ReceiveInfoDataSet _receiveInfoDataSet;
        // ��M�����f�[�^�Z�b�g
        private ReceiveConditionDataSet _receiveConditionDataSet;
        // ���M���f�[�^�e�[�u��
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // ���M�����f�[�^�e�[�u��
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        // ��M���f�[�^�e�[�u��
        private ReceiveInfoDataSet.ReceiveInfoDataTable _receiveInfoDataTable;
        // ��M�����f�[�^�e�[�u��
        private ReceiveConditionDataSet.ReceiveConditionDataTable _receiveConditionDataTable;
        // ���_�Ǘ��ڑ���ݒ�A�N�Z�X
        private SecMngConnectStAcs _secMngConnectStAcs;
        private static MstUpdCountAcs _mstUpdCountAcs;
        private IMstDCControlDB _iMstDCControlDB;
        private IMstTotalMachControlDB _iMstTotalMachControlDB;
        private IAPMSTControlDB _iAPMSTControlDB;
        private ISndRcvHisDB _iSndRcvHisRFDB; //ADD 2011/07/25
        private bool _autoSendRecvDiv = false;//ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���


        # endregion �� Private Members ��

        # region �� �f�[�^���M�����A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// �f�[�^���M�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�f�[�^���M�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static MstUpdCountAcs GetInstance()
        {
            if (_mstUpdCountAcs == null)
            {
                _mstUpdCountAcs = new MstUpdCountAcs();
            }

            return _mstUpdCountAcs;
        }
        # endregion �� �f�[�^���M�����A�N�Z�X�N���X �C���X�^���X�擾���� ��

        # region �� �}�X�^����M���� ��
        /// <summary>
        /// ���M���}�X�^���̎擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���}�X�^���̂̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int LoadMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            masterNameList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchMstName(enterpriseCode, out masterNameList);
            return status;
        }

        /// <summary>
        /// ���M���敪�擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^�敪���X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���敪�̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int LoadMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            masterDivList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchMstDoDiv(enterpriseCode, out masterDivList);
            return status;
        }

        /// <summary>
        /// ��M���敪�擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^�敪���X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��M���敪�̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int LoadReceMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            masterDivList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceMstDoDiv(enterpriseCode, out masterDivList);
            return status;
        }

        /// <summary>
        /// ��M��񖾍׋敪�擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDtlDivList">�}�X�^�敪���X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��M��񖾍׋敪�̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int LoadReceMstDtlDoDiv(string enterpriseCode, out ArrayList masterDtlDivList)
        {
            masterDtlDivList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceMstDtlDoDiv(enterpriseCode, out masterDtlDivList);
            return status;
        }

        /// <summary>
        /// ��M���}�X�^���̎擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��M���}�X�^���̂̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int LoadReceMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            masterNameList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceMstName(enterpriseCode, out masterNameList);
            return status;
        }

        /// <summary>
        /// ��M���PM�R�[�h�擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="pmCode">PM�R�[�h</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��M���PM�R�[�h�̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int SeachPmCode(string enterpriseCode, string baseCode, out string pmCode)
        {
            pmCode = string.Empty;
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SeachPmCode(enterpriseCode, baseCode, out pmCode);
            return status;
        }

        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>
        /// ���M���񃊃��[�h
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCodeList">���_���X�g</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int ReloadSecMngSetInfo(string enterpriseCode, out ArrayList baseCodeList)
        {
            baseCodeList = new ArrayList();
            ArrayList secMngSetArrList = new ArrayList();
            // ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchSyncExecDate(enterpriseCode, out secMngSetArrList);
            // ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            foreach (APMSTSecMngSetWork secMngSetWork in secMngSetArrList)
            {
                baseCodeList.Add(secMngSetWork.SendDestSecCode);
            }
            return status;
        }
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

        /// <summary>
        /// ���M���V���N�����擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="startDt">�V���N����</param>
        /// <param name="baseCodeNameList">���_���X�g</param>
        /// <param name="sendDivFlg">���M�敪�t���O 0:�������M 1:�蓮���M</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���V���N�����̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        //public int LoadSyncExecDate(string enterpriseCode, out DateTime startDt, out ArrayList baseCodeNameList)//DEL 2011/07/25
        public int LoadSyncExecDate(string enterpriseCode, out DateTime startDt, out ArrayList baseCodeNameList, int sendDivFlg)
        {
            startDt = new DateTime();
            ExtractionConditionDataSet.ExtractionConditionRow row = null;
            baseCodeNameList = new ArrayList();
            BaseCodeNameWork baseCodeNameWork = null;
            ArrayList secMngSetArrList = new ArrayList();
            // ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchSyncExecDate(enterpriseCode, out secMngSetArrList);
            // ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            DateTime syncExecDate = new DateTime();
            String syncExecDateHour = string.Empty;
            String syncExecDateMinute = string.Empty;
            String syncExecDateSecond = string.Empty;
            DateTime endDate = new DateTime();
            String endDateHour = string.Empty;
            String endDateMinute = string.Empty;
            String endDateSecond = string.Empty;

            // ���M�̏ꍇ�A
            foreach (APMSTSecMngSetWork secMngSetWork in secMngSetArrList)
            {
                // �������ʂ�ݒ���s��
                row = _extractionConditionDataTable.NewExtractionConditionRow();
                // ���_�R�[�h
                //row.BaseCode = secMngSetWork.SectionCode;//DEL 2011/07/26
                row.BaseCode = secMngSetWork.SendDestSecCode;//ADD 2011/07/26
                // ���_����
                row.BaseName = secMngSetWork.SectionGuideNm;

                baseCodeNameWork = new BaseCodeNameWork();
                //baseCodeNameWork.SectionCode = secMngSetWork.SectionCode;//DEL 2011/07/26
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                baseCodeNameWork.SectionCode = secMngSetWork.SendDestSecCode;
                baseCodeNameWork.SyncExecDate = secMngSetWork.SyncExecDate;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                baseCodeNameWork.SectionGuideNm = secMngSetWork.SectionGuideNm;
                //baseCodeNameList.Add(baseCodeNameWork);//DEL 2011/07/26
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //�������M�̏ꍇ
                if (sendDivFlg == 0)
                {
                    //�������M�敪���0�F�������M���飂̋��_�𑗐M��ΏۂƂ���
                    if (secMngSetWork.AutoSendDiv == 0)
                    {
                        baseCodeNameList.Add(baseCodeNameWork);
                    }
                }
                else
                {
                    baseCodeNameList.Add(baseCodeNameWork);
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                syncExecDate = secMngSetWork.SyncExecDate;
                // ���A���A�b�A2���⑫
                syncExecDateHour = syncExecDate.Hour.ToString();
                syncExecDateMinute = syncExecDate.Minute.ToString();
                syncExecDateSecond = syncExecDate.Second.ToString();
                // ��2���⑫
                if (syncExecDateHour.Length == 1)
                {
                    syncExecDateHour = ZERO_0 + syncExecDateHour;
                }
                // ��2���⑫
                if (syncExecDateMinute.Length == 1)
                {
                    syncExecDateMinute = ZERO_0 + syncExecDateMinute;
                }
                // �b2���⑫
                if (syncExecDateSecond.Length == 1)
                {
                    syncExecDateSecond = ZERO_0 + syncExecDateSecond;
                }
                // �J�n���t
                row.BeginningDate = syncExecDate;
                startDt = syncExecDate;
                // �J�n����
                row.BeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //�����J�n���t(Hidden)
                row.InitBeginningDate = syncExecDate;
                //�����J�n����(Hidden)
                row.InitBeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

                // �V�X�e������
                endDate = System.DateTime.Now;
                endDateHour = endDate.Hour.ToString();
                endDateMinute = endDate.Minute.ToString();
                endDateSecond = endDate.Second.ToString();
                // ��2���⑫
                if (endDateHour.Length == 1)
                {
                    endDateHour = ZERO_0 + endDateHour;
                }
                // ��2���⑫
                if (endDateMinute.Length == 1)
                {
                    endDateMinute = ZERO_0 + endDateMinute;
                }
                // �b2���⑫
                if (endDateSecond.Length == 1)
                {
                    endDateSecond = ZERO_0 + endDateSecond;
                }
                // �I�����t
                row.EndDate = endDate;
                // �I������
                row.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;

                _extractionConditionDataTable.Rows.Add(row);
            }

            return status;
        }

        /// <summary>
        /// ��M���V���N�����擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <param name="baseCodeNameList">���_���X�g</param>
        /// <param name="sndRcvHisList">����M�������O�f�[�^���X�g</param>
        /// <param name="sndRcvEtrList">����M���o�����������O�f�[�^���X�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��M���V���N�����̎擾�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        //public int LoadReceSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList, out ArrayList baseCodeNameList)//DEL 2011/07/25
        public int LoadReceSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList, out ArrayList baseCodeNameList, out ArrayList sndRcvHisList, out ArrayList sndRcvEtrList)
        {
            //ReceiveConditionDataSet.ReceiveConditionRow ReceiveRow = null;//DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            baseCodeNameList = new ArrayList();
            BaseCodeNameWork baseCodeNameWork = null;
            secMngSetArrList = new ArrayList();
            //string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
            #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            //// ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
            //this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            //int status = _iAPMSTControlDB.SearchReceSyncExecDate(enterpriseCode, out secMngSetArrList);
            //// ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status;
            //}

            //DateTime syncExecDate = new DateTime();
            //String syncExecDateHour = string.Empty;
            //String syncExecDateMinute = string.Empty;
            //String syncExecDateSecond = string.Empty;
            //DateTime endDate = new DateTime();
            //String endDateHour = string.Empty;
            //String endDateMinute = string.Empty;
            //String endDateSecond = string.Empty;

            //foreach (APMSTSecMngSetWork secMngSetWork in secMngSetArrList)
            //{
            //    // �������ʂ�ݒ���s��
            //    ReceiveRow = _receiveConditionDataTable.NewReceiveConditionRow();
            //    // ���_�R�[�h
            //    ReceiveRow.BaseCode = secMngSetWork.SectionCode;
            //    // ���_����
            //    ReceiveRow.BaseName = secMngSetWork.SectionGuideNm;

            //    baseCodeNameWork = new BaseCodeNameWork();
            //    baseCodeNameWork.SectionCode = secMngSetWork.SectionCode;
            //    baseCodeNameWork.SectionGuideNm = secMngSetWork.SectionGuideNm;
            //    baseCodeNameList.Add(baseCodeNameWork);

            //    syncExecDate = secMngSetWork.SyncExecDate;
            //    // ���A���A�b�A2���⑫
            //    syncExecDateHour = syncExecDate.Hour.ToString();
            //    syncExecDateMinute = syncExecDate.Minute.ToString();
            //    syncExecDateSecond = syncExecDate.Second.ToString();
            //    // ��2���⑫
            //    if (syncExecDateHour.Length == 1)
            //    {
            //        syncExecDateHour = ZERO_0 + syncExecDateHour;
            //    }
            //    // ��2���⑫
            //    if (syncExecDateMinute.Length == 1)
            //    {
            //        syncExecDateMinute = ZERO_0 + syncExecDateMinute;
            //    }
            //    // �b2���⑫
            //    if (syncExecDateSecond.Length == 1)
            //    {
            //        syncExecDateSecond = ZERO_0 + syncExecDateSecond;
            //    }
            //    // �J�n���t
            //    ReceiveRow.BeginningDate = syncExecDate;
            //    // �J�n����
            //    ReceiveRow.BeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;

            //    // �V�X�e������
            //    endDate = System.DateTime.Now;
            //    endDateHour = endDate.Hour.ToString();
            //    endDateMinute = endDate.Minute.ToString();
            //    endDateSecond = endDate.Second.ToString();
            //    // ��2���⑫
            //    if (endDateHour.Length == 1)
            //    {
            //        endDateHour = ZERO_0 + endDateHour;
            //    }
            //    // ��2���⑫
            //    if (endDateMinute.Length == 1)
            //    {
            //        endDateMinute = ZERO_0 + endDateMinute;
            //    }
            //    // �b2���⑫
            //    if (endDateSecond.Length == 1)
            //    {
            //        endDateSecond = ZERO_0 + endDateSecond;
            //    }
            //    // �I�����t
            //    ReceiveRow.EndDate = endDate;
            //    // �I������
            //    ReceiveRow.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;

            //    _receiveConditionDataTable.Rows.Add(ReceiveRow);
            //}
            #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            sndRcvHisList = new ArrayList();
            sndRcvEtrList = new ArrayList();
            this._iSndRcvHisRFDB = MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
            SndRcvHisCondWork _sndRcvHisCondWork = new SndRcvHisCondWork();
            _sndRcvHisCondWork.EnterpriseCode = enterpriseCode;
            //_sndRcvHisCondWork.SectionCode = sectionCode;//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂��� ---------->>>>>
            string belongSectionCode = string.Empty;
            if (_autoSendRecvDiv)
            {
                int ret = GetBelongSectionCodeFormXml(ref belongSectionCode);
                if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return ret;
                }
                _sndRcvHisCondWork.SectionCode = belongSectionCode;
            }
            else
            {
                _sndRcvHisCondWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂��� ----------<<<<<
            _sndRcvHisCondWork.SendOrReceiveDivCd = 0;
            _sndRcvHisCondWork.Kind = 1;
            object objList = null;
            int status = _iSndRcvHisRFDB.Search(_sndRcvHisCondWork, out objList);
            // ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            ArrayList retList = (ArrayList)objList;
            if (retList != null)
            {
                for (int i = 0; i < retList.Count; i++)
                {
                    Type wktype = retList[i].GetType();
                    if (wktype.Equals(typeof(SndRcvHisWork)))
                    {
                        sndRcvHisList.Add(retList[i]);
                    }
                    else if (wktype.Equals(typeof(ArrayList)))
                    {
                        ArrayList subResultList = (ArrayList)retList[i];
                        sndRcvEtrList.AddRange((ArrayList)retList[i]);
                    }
                }
            }
            
            ReceiveConditionDataSet.ReceiveConditionRow ReceiveRow = null;
            DateTime beginDateTime = new DateTime();
            String beginDateHour = string.Empty;
            String beginDateMinute = string.Empty;
            String beginDateSecond = string.Empty;
            DateTime endDateTime = new DateTime();
            String endDateHour = string.Empty;
            String endDateMinute = string.Empty;
            String endDateSecond = string.Empty;
            foreach (SndRcvHisWork sndRcvHisWork in sndRcvHisList)
            {
                // �������ʂ�ݒ���s��
                ReceiveRow = _receiveConditionDataTable.NewReceiveConditionRow();
                ReceiveRow.EnterpriseCode = sndRcvHisWork.EnterpriseCode;
                ReceiveRow.BaseCode = sndRcvHisWork.SectionCode;
                #region DEL
                //DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>>
                //SecInfoAcs secInfoAcs = new SecInfoAcs();
                //string secName = string.Empty;
                //try
                //{
                //    foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                //    {
                //        if (secInfoSet.SectionCode.Trim() == ReceiveRow.BaseCode.Trim().PadLeft(2, '0'))
                //        {
                //            ReceiveRow.BaseName = secInfoSet.SectionGuideNm.Trim();
                //            secName = secInfoSet.SectionGuideNm.Trim();
                //            break;
                //        }
                //    }
                //}
                //catch
                //{
                //    ReceiveRow.BaseName = string.Empty;
                //    secName = string.Empty;
                //}
                //DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>>
                #endregion
                //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>>                
                string secName = string.Empty;
                if (_autoSendRecvDiv == false)
                {
                    SecInfoAcs secInfoAcs = new SecInfoAcs();
                    try
                    {
                        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                        {
                            if (secInfoSet.SectionCode.Trim() == ReceiveRow.BaseCode.Trim().PadLeft(2, '0'))
                            {
                                ReceiveRow.BaseName = secInfoSet.SectionGuideNm.Trim();
                                secName = secInfoSet.SectionGuideNm.Trim();
                                break;
                            }
                        }
                    }
                    catch
                    {
                        ReceiveRow.BaseName = string.Empty;
                        secName = string.Empty;
                    }
                }
                //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>>
                baseCodeNameWork = new BaseCodeNameWork();
                baseCodeNameWork.SectionCode = sndRcvHisWork.SectionCode;
                baseCodeNameWork.SectionGuideNm = secName;
                baseCodeNameList.Add(baseCodeNameWork);

                ReceiveRow.ExtraCondDiv = sndRcvHisWork.SndLogExtraCondDiv;
                if (ReceiveRow.ExtraCondDiv == 0)
                {
                    ReceiveRow.ExtraCondDivNm = "����";
                }
                else
                {
                    ReceiveRow.ExtraCondDivNm = "����";
                }
                ReceiveRow.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                // ���A���A�b�A2���⑫
                beginDateTime = sndRcvHisWork.SndObjStartDate;
                beginDateHour = beginDateTime.Hour.ToString();
                beginDateMinute = beginDateTime.Minute.ToString();
                beginDateSecond = beginDateTime.Second.ToString();
                // ��2���⑫
                if (beginDateHour.Length == 1)
                {
                    beginDateHour = ZERO_0 + beginDateHour;
                }
                // ��2���⑫
                if (beginDateMinute.Length == 1)
                {
                    beginDateMinute = ZERO_0 + beginDateMinute;
                }
                // �b2���⑫
                if (beginDateSecond.Length == 1)
                {
                    beginDateSecond = ZERO_0 + beginDateSecond;
                }
                // �J�n���t
                ReceiveRow.BeginningDate = beginDateTime;
                // �J�n����
                if (beginDateTime != DateTime.MinValue)
                {
                    ReceiveRow.BeginningTime = beginDateHour + MARK_1 + beginDateMinute + MARK_1 + beginDateSecond;
                }
                else
                {
                    ReceiveRow.BeginningTime = "";
                }

                // ���A���A�b�A2���⑫
                endDateTime = sndRcvHisWork.SndObjEndDate;
                endDateHour = endDateTime.Hour.ToString();
                endDateMinute = endDateTime.Minute.ToString();
                endDateSecond = endDateTime.Second.ToString();
                // ��2���⑫
                if (endDateHour.Length == 1)
                {
                    endDateHour = ZERO_0 + endDateHour;
                }
                // ��2���⑫
                if (endDateMinute.Length == 1)
                {
                    endDateMinute = ZERO_0 + endDateMinute;
                }
                // �b2���⑫
                if (endDateSecond.Length == 1)
                {
                    endDateSecond = ZERO_0 + endDateSecond;
                }
                // �J�n���t
                ReceiveRow.EndDate = endDateTime;
                // �J�n����
                if (endDateTime != DateTime.MinValue)
                {
                    ReceiveRow.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;
                }
                else
                {
                    ReceiveRow.EndTime = "";
                }

                _receiveConditionDataTable.Rows.Add(ReceiveRow);
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            return status;
        }
        /// <summary>
        /// �����_�R�[�h���擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>		
        /// <br>Note		: �����_�R�[�h�擾�������s���B</br>
        /// <br>Programmer	: ������</br>	
        /// <br>Date		: 2011.09.01</br>
        /// </remarks>
        private int GetBelongSectionCodeFormXml(ref string belongSectionCode)
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ServiceFilesInputAcs sfInputAcs = ServiceFilesInputAcs.GetInstance();
            string msg = string.Empty;
            int flg = 0;
            stauts = sfInputAcs.SearchForAutoSendRecv(ref msg, ref flg);
            if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                belongSectionCode = sfInputAcs.SecInfo.SecInfo.Rows[0][0].ToString();
            }
            return stauts;
        }
        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA���M���`�F�b�N���s���B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCodeNameList">���_�R�[�h���X�g</param>
        /// <param name="startDt">�V���N����</param>
        /// <returns>�Ǎ�����</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA���M���`�F�b�N���s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public bool SendUpdateProc(string enterpriseCode, ArrayList baseCodeNameList, out DateTime startDt)
        {
            string retMessage = string.Empty;
            bool isUpdate = true;
            startDt = new DateTime();
            ArrayList secMngSetArrList = new ArrayList();
            // ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchSyncExecDate(enterpriseCode, out secMngSetArrList);

            // ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isUpdate = false;
                return isUpdate;
            }
            ArrayList baseCodeNameArr = new ArrayList();

            // ���_�R�[�h���X�g
            foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
            {
                baseCodeNameArr.Add(baseCodeNameWork.SectionCode);
            }

            // ���_�R�[�hNULL�̏ꍇ�ƕύX�����̏ꍇ�A
            foreach (APMSTSecMngSetWork work in secMngSetArrList) 
            {
                if (string.IsNullOrEmpty(work.SectionCode)
                    || !baseCodeNameArr.Contains(work.SectionCode))
                {
                    isUpdate = false;
                    return isUpdate;
                }

                startDt = work.SyncExecDate;
            }

            return isUpdate;

        }

        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA��M���`�F�b�N���s���B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCodeNameList">���_�R�[�h���X�g</param>
        /// <param name="secMngSetArrList">�V���N���ԃ��X�g</param>
        /// <param name="isTimeOut">����</param>
        /// <returns>�Ǎ�����</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA��M���`�F�b�N���s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public bool ReceUpdateProc(string enterpriseCode, ArrayList baseCodeNameList, out ArrayList secMngSetArrList, out bool isTimeOut)
        {
            string retMessage = string.Empty;
            bool isUpdate = true;
            isTimeOut = false;
            secMngSetArrList = new ArrayList();
            // ���_�Ǘ��ݒ�����擾���āA�������ݒ���s��
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceSyncExecDate(enterpriseCode, out secMngSetArrList);
            // ADD 2009/07/06 --->>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                isTimeOut = true;
                return isUpdate;
            }
            // ADD 2009/07/06 ---<<<
            // ����0���̏ꍇ�A������DB�G���[�̏ꍇ�A
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isUpdate = false;
                return isUpdate;
            }
            ArrayList baseCodeNameOneArr = new ArrayList();
            ArrayList baseCodeNameTwoArr = new ArrayList();

            // ���_�R�[�h���X�g
            foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
            {
                baseCodeNameOneArr.Add(baseCodeNameWork.SectionCode);
            }

            foreach (APMSTSecMngSetWork work in secMngSetArrList)
            {
                baseCodeNameTwoArr.Add(work.SectionCode);
            }

            // ���_�R�[�hNULL�̏ꍇ�ƕύX�����̏ꍇ�A
            foreach (string baseCode in baseCodeNameOneArr)
            {
                if (!baseCodeNameTwoArr.Contains(baseCode)) 
                {
                    isUpdate = false;
                    return isUpdate;
                }
            }


            return isUpdate;

        }

        /// <summary>
        /// ���������t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���������t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            // �O���̏ꍇ�A
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + COUNTNAME;
            }
            // �Z���̏ꍇ�A
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + MARK_4 + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            // �㌅�̏ꍇ�A
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + MARK_4
                    + searchCountStr.Substring(searchCountLen - 6, 3) + MARK_4
                    + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            return searchCountStr;
        }

        /// <summary>
        /// �S�Ď�M�X�V���ʑ��݂��Ȃ��ꍇ���O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�Ď�M�X�V���ʑ��݂��Ȃ��ꍇ���O�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public void ReceLogOutProc()
        {
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();
            // ��M���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
            // MOD 2009/06/17 --->>>
            //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
            // MOD 2009/06/17 ---<<<
        }

        /// <summary>
        /// �}�X�^���o���������邩�ǂ������f
        /// </summary>
        /// <param name="objWork">�}�X�^���o�����Ώ�</param>
        /// <returns>true:���o�������� false:���o�����Ȃ�</returns>
        private bool isInput(object objWork)
        {
            bool isInput = false;
            if (objWork == null) return isInput;
            Type wkType = objWork.GetType();
            //���Ӑ�}�X�^���o����
            if (wkType.Equals(typeof(APCustomerProcParamWork)))
            {
                APCustomerProcParamWork custParam = (APCustomerProcParamWork)objWork;
                if (custParam.BusinessTypeCodeBeginRF != 0
                    || custParam.BusinessTypeCodeEndRF != 0
                    || custParam.CustomerAgentCdBeginRF != ""
                    || custParam.CustomerAgentCdEndRF != ""
                    || custParam.CustomerCodeBeginRF != 0
                    || custParam.CustomerCodeEndRF != 0
                    || custParam.KanaBeginRF != ""
                    || custParam.KanaEndRF != ""
                    || custParam.MngSectionCodeBeginRF != ""
                    || custParam.MngSectionCodeEndRF != ""
                    || custParam.SalesAreaCodeBeginRF != 0
                    || custParam.SalesAreaCodeEndRF != 0
                    || custParam.UpdateDateTimeBegin != 0
                    || custParam.UpdateDateTimeEnd != 0
                )
                {
                    isInput = true;
                }
            }
            //���i�}�X�^���o����
            else if (wkType.Equals(typeof(APGoodsProcParamWork)))
            {
                APGoodsProcParamWork goodsParam = (APGoodsProcParamWork)objWork;
                if (goodsParam.BLGoodsCodeBeginRF != 0
                    || goodsParam.BLGoodsCodeEndRF != 0
                    || goodsParam.GoodsMakerCdBeginRF != 0
                    || goodsParam.GoodsMakerCdEndRF != 0
                    || goodsParam.GoodsNoBeginRF != ""
                    || goodsParam.GoodsNoEndRF != ""
                    || goodsParam.SupplierCdBeginRF != 0
                    || goodsParam.SupplierCdEndRF != 0
                    || goodsParam.UpdateDateTimeBegin != 0
                    || goodsParam.UpdateDateTimeEnd != 0
                )
                {
                    isInput = true;
                }
            }
            //�݌Ƀ}�X�^���o����
            else if (wkType.Equals(typeof(APStockProcParamWork)))
            {
                APStockProcParamWork stockParam = (APStockProcParamWork)objWork;
                if (stockParam.BLGloupCodeBeginRF != 0
                    || stockParam.BLGloupCodeEndRF != 0
                    || stockParam.GoodsMakerCdBeginRF != 0
                    || stockParam.GoodsMakerCdEndRF != 0
                    || stockParam.GoodsNoBeginRF != ""
                    || stockParam.GoodsNoEndRF != ""
                    || stockParam.SupplierCdBeginRF != 0
                    || stockParam.SupplierCdEndRF != 0
                    || stockParam.UpdateDateTimeBegin != 0
                    || stockParam.UpdateDateTimeEnd != 0
                    || stockParam.WarehouseCodeBeginRF != ""
                    || stockParam.WarehouseCodeEndRF != ""
                    || stockParam.WarehouseShelfNoBeginRF != ""
                    || stockParam.WarehouseShelfNoEndRF != ""
                )
                {
                    isInput = true;
                }
            }
            //�d����}�X�^���o����
            else if (wkType.Equals(typeof(APSupplierProcParamWork)))
            {
                APSupplierProcParamWork suppParam = (APSupplierProcParamWork)objWork;
                if (suppParam.SupplierCdBeginRF != 0
                    || suppParam.SupplierCdEndRF != 0
                    || suppParam.UpdateDateTimeBegin != 0
                    || suppParam.UpdateDateTimeEnd != 0
                )
                {
                    isInput = true;
                }
            }
            //�|���}�X�^���o����
            else if (wkType.Equals(typeof(APRateProcParamWork)))
            {
                APRateProcParamWork rateParam = (APRateProcParamWork)objWork;
                if (rateParam.BLGoodsCodeBeginRF != 0
                    || rateParam.BLGoodsCodeEndRF != 0
                    || rateParam.CustomerCodeBeginRF != 0
                    || rateParam.CustomerCodeEndRF != 0
                    || rateParam.CustRateGrpCodeBeginRF != 0
                    || rateParam.CustRateGrpCodeEndRF != 0
                    || rateParam.GoodsMakerCdBeginRF != 0
                    || rateParam.GoodsMakerCdEndRF != 0
                    || rateParam.GoodsNoBeginRF != ""
                    || rateParam.GoodsNoEndRF != ""
                    || rateParam.GoodsRateGrpCodeBeginRF != 0
                    || rateParam.GoodsRateGrpCodeEndRF != 0
                    || rateParam.GoodsRateRankBeginRF != ""
                    || rateParam.GoodsRateRankEndRF != ""
                    || rateParam.RateSettingDivideRF != ""
                    || rateParam.SetFunRF != ""
                    || rateParam.SupplierCdBeginRF != 0
                    || rateParam.SupplierCdEndRF != 0
                    || rateParam.UnitPriceKindRF != ""
                    || rateParam.UpdateDateTimeBegin != 0
                    || rateParam.UpdateDateTimeEnd != 0
                    // --- ADD 2012/07/26 ------------------------->>>>>
                    || rateParam.SectionCodeBeginRF != ""
                    || rateParam.SectionCodeEndRF != ""
                    // --- ADD 2012/07/26 -------------------------<<<<<
                )
                {
                    isInput = true;
                }
            }
            // --- ADD 2012/07/26 ------------------------->>>>>
            //�]�ƈ��ݒ�}�X�^���o����
            else if (wkType.Equals(typeof(APEmployeeProcParamWork)))
            {
                APEmployeeProcParamWork employeeParam = (APEmployeeProcParamWork)objWork;
                if (employeeParam.UpdateDateTimeBegin != 0
                    || employeeParam.UpdateDateTimeEnd != 0
                    || employeeParam.BelongSectionCdBeginRF != ""
                    || employeeParam.BelongSectionCdEndRF != ""
                    || employeeParam.EmployeeCdBeginRF != ""
                    || employeeParam.EmployeeCdEndRF != ""
                )
                {
                    isInput = true;
                }
            }
            //�����}�X�^���o����
            else if (wkType.Equals(typeof(APJoinPartsUProcParamWork)))
            {
                APJoinPartsUProcParamWork joinPartsUParam = (APJoinPartsUProcParamWork)objWork;
                if (joinPartsUParam.UpdateDateTimeBegin != 0
                    || joinPartsUParam.UpdateDateTimeEnd != 0
                    || joinPartsUParam.JoinSourPartsNoWithHBeginRF != ""
                    || joinPartsUParam.JoinSourPartsNoWithHEndRF != ""
                    || joinPartsUParam.JoinSourceMakerCodeBeginRF != 0
                    || joinPartsUParam.JoinSourceMakerCodeEndRF != 0
                    || joinPartsUParam.JoinDispOrderBeginRF != 0
                    || joinPartsUParam.JoinDispOrderEndRF != 0
                    || joinPartsUParam.JoinDestMakerCodeBeginRF != 0
                    || joinPartsUParam.JoinDestMakerCodeEndRF != 0
                )
                {
                    isInput = true;
                }
            }
            //���[�U�[�K�C�h�}�X�^(�̔��敪)
            else if (wkType.Equals(typeof(APUserGdBuyDivUProcParamWork)))
            {
                APUserGdBuyDivUProcParamWork userGdBuyDivUParam = (APUserGdBuyDivUProcParamWork)objWork;
                if (userGdBuyDivUParam.UpdateDateTimeBegin != 0
                    || userGdBuyDivUParam.UpdateDateTimeEnd != 0
                    || userGdBuyDivUParam.GuideCodeBeginRF != 0
                    || userGdBuyDivUParam.GuideCodeEndRF != 0
                )
                {
                    isInput = true;
                }
            }
            // --- ADD 2012/07/26 -------------------------<<<<<
            return isInput;
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA���M�������s��
        /// </summary>
        /// <param name="extractCondDiv">���o�����敪</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="paramList">����M���o�����������O�f�[�^���X�g</param>
        /// <param name="pmEnterpriseCode">���M���ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^�敪���X�g</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="startTime">�V���N����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updSectionCode">���O�C�����[�U�[���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="searchCountWork">�����v��</param>
        /// <param name="isEmpty">��̔��f</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA���M�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        //public int SendProc(Int32 connectPointDiv, ArrayList masterDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, 
        //                       string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)
        //-----DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        public int SendProc(Int32 extractCondDiv, Int32 connectPointDiv, ArrayList paramList, string pmEnterpriseCode, ArrayList masterDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, 
                               string updSectionCode, string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        {
            string retMessage;
            isEmpty = false;
            searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            DateTime minSyncExecDt = new DateTime(); //ADD 2011/07/25
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            // ���o�E�X�V�R���g���[�����������[�g���Ăяo���Ē��o�f�[�^���擾���A���o���ʃN���X��Ԃ��܂��B
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            //int status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            int status = 0;
            int no = 0;
            if (extractCondDiv == 0)
            {
                //�������M�̏ꍇ�A
                status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, updSectionCode, beginningTime, endingTime, ref retCSAList, out no, out retMessage);
            }
            else
            {
                //-----ADD 2011.0906 #24364----->>>>>
                status = _iAPMSTControlDB.GetObjCount(masterDivList, enterpriseCode, paramList, out searchCountWork, out retMessage);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (searchCountWork.ErrorKubun == -3 || searchCountWork.ErrorKubun == -4))
                {
                    return status;
                }
                //-----ADD 2011.0906 #24364-----<<<<<
                status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, updSectionCode, paramList, ref retCSAList, out no, out retMessage);
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            // ���o���ʐ���̏ꍇ�A�f�[�^�ϊ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // �f�[�^�ϊ�����
                //syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList); //DEL 2011/07/25
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out syncExecDt, out minSyncExecDt, out isEmpty, retCSAList);
                //ADD 2011/09/15 fengwx #23934----->>>>>
                int updListCount = 0;
                foreach (ArrayList childList in updCSAList)
                {
                    updListCount += childList.Count;
                }
                if (updListCount > 0 && updListCount - searchCountWork.RateProtyMngCount - searchCountWork.PartsPosCodeUCount - searchCountWork.BLCodeGuideCount == 0)
                {
                    //�|���D��Ǘ��}�X�^�A���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�ABL�R�[�h�K�C�h�}�X�^
                    //�O�̃e�[�u�������𑗐M����ꍇ�A
                    //���M�ΏۊJ�n���������.�J�n���t+�J�n����
                    //���M�ΏۏI�����������.�I�����t+�I������
                    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
                    syncExecDt = new DateTime(endingTime);
                }
                //ADD 2011/09/15 fengwx #23934-----<<<<<
                if (extractCondDiv == 1)
                {
                    //�������M�̏ꍇ�A�݌Ƀ}�X�^�Ə��i�}�X�^�̌������`�F�b�N���s��
                    if (searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount + searchCountWork.IsolIslandPrcCount > MAX_CNT)
                    {
                        searchCountWork.ErrorKubun = -3;
                        return status;
                    }
                    else if (searchCountWork.StockCount > MAX_CNT)
                    {
                        searchCountWork.ErrorKubun = -4;
                        return status;
                    }
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                if (isEmpty)
                {
                    // MOD 2009/06/17 ---->>>
                    // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                    //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    return status;
                }
                else
                {
                    // �f�[�^�X�V����
                    if (connectPointDiv == 0)
                    {
                        this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                        // �f�[�^�X�V����
                        //status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, out retMessage); //DEL 2011/07/25
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        ArrayList objList = new ArrayList();

                        //**********************����M�������O�f�[�^�̐ݒ�**********************//
                        SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
                        //��ƃR�[�h:���O�C�����[�U�[�̊�ƃR�[�h
                        sndRcvHisWork.EnterpriseCode = enterpriseCode;
                        //�_���폜�敪
                        sndRcvHisWork.LogicalDeleteCode = 0;
                        //���_�R�[�h:���O�C�����[�U�[�̋��_�R�[�h
                        sndRcvHisWork.SectionCode = updSectionCode;
                        //����M�������O���M�ԍ�
                        sndRcvHisWork.SndRcvHisConsNo = no;
                        //���M����:�V�X�e�����t
                        sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                        //����M���O���p�敪:�0:���_�Ǘ��
                        sndRcvHisWork.SndLogUseDiv = 0;
                        //����M�敪:�0:���M�
                        sndRcvHisWork.SendOrReceiveDivCd = 0;
                        //���:�1:�}�X�^�
                        sndRcvHisWork.Kind = 1;
                        //����M���O���o�����敪
                        sndRcvHisWork.SndLogExtraCondDiv = extractCondDiv;
                        //���M�Ώۋ��_�R�[�h
                        sndRcvHisWork.ExtraObjSecCode = "";
                        //���M�ΏۊJ�n�����A���M�ΏۏI������
                        if (extractCondDiv == 0)
                        {
                            sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                            sndRcvHisWork.SndObjEndDate = syncExecDt;
                        }
                        else
                        {
                            if (beginningTime != 0 && endingTime != 0)
                            {
                                sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvHisWork.SndObjEndDate = syncExecDt;
                            }
                            else
                            {
                                sndRcvHisWork.SndObjStartDate = DateTime.MinValue;
                                sndRcvHisWork.SndObjEndDate = DateTime.MinValue;
                            }
                        }
                        //���M���ƃR�[�h
                        sndRcvHisWork.SendDestEpCode = pmEnterpriseCode;
                        //���M�拒�_�R�[�h
                        sndRcvHisWork.SendDestSecCode = baseCode;
                        objList.Add(sndRcvHisWork);
                        //**********************����M�������O�f�[�^�̐ݒ�**********************//

                        //******************����M���o�����������O�f�[�^�̐ݒ�******************//
                        ArrayList sndRcvCondHisList = new ArrayList();
                        //���o�����敪���������̏ꍇ�̂݁A����M���o�����������O�f�[�^��o�^�\
                        if (extractCondDiv == 1)
                        {
                            APCustomerProcParamWork customerProcParam = null;
                            APGoodsProcParamWork goodsProcParam = null;
                            APStockProcParamWork stockProcParam = null;
                            APSupplierProcParamWork supplierProcParam = null;
                            APRateProcParamWork rateProcParam = null;
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            APEmployeeProcParamWork employeeProcParam = null;
                            APJoinPartsUProcParamWork joinPartsUProcParam = null;
                            APUserGdBuyDivUProcParamWork userGdBuyDivUProcParam = null;
                            // --- ADD 2012/07/26 -------------------------<<<<<

                            for (int i = 0; i < paramList.Count; i++)
                            {
                                Type paramType = paramList[i].GetType();
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
                                // --- ADD 2012/07/26 ------------------------->>>>>
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
                                // --- ADD 2012/07/26 -------------------------<<<<<
                            }
                            int derivNo = 1;
                            //���Ӑ�}�X�^���o����
                            if (customerProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APCustomerProcParamToSndRcvEtrWork(customerProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_CUSTOMER;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //���i�}�X�^���o����
                            if (goodsProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APGoodsProcParamToSndRcvEtrWork(goodsProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_GOODS;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //�݌Ƀ}�X�^���o����
                            if (stockProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APStockProcParamToSndRcvEtrWork(stockProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_STOCK;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //�d����}�X�^���o����
                            if (supplierProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APSupplierProcParamToSndRcvEtrWork(supplierProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_SUPPLIER;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //�|���}�X�^���o����
                            if (rateProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APRateProcParamToSndRcvEtrWork(rateProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_RATE;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            //�]�ƈ��}�X�^���o����
                            if (employeeProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APEmployeeProcParamToSndRcvEtrWork(employeeProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_EMPLOYEE;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //�����}�X�^���o����
                            if (joinPartsUProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APJoinPartsUProcParamToSndRcvEtrWork(joinPartsUProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_JOINPARTSU;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //���[�U�[�K�C�h�}�X�^(�̔��敪)���o����
                            if (userGdBuyDivUProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APUserGdBuyDivUProcParamToSndRcvEtrWork(userGdBuyDivUProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_USERGDU;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            // --- ADD 2012/07/26 -------------------------<<<<<
                        }
                        objList.Add(sndRcvCondHisList);
                        //******************����M���o�����������O�f�[�^�̐ݒ�******************//

                        ArrayList paraList = new ArrayList();
                        paraList.Add(objList);
                        status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, paraList, out retMessage);
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    }
                    else
                    {
                        this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                        // �f�[�^�X�V����
                        status = _iMstTotalMachControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                    }

                }

            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                searchCountWork.ErrorKubun = -1;
                return status;
            }

            // status��0����̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                foreach (SecMngSndRcvWork work in masterNameList)
                {
                    logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                    // ���_�ݒ�}�X�^
                    if (MST_SECINFOSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                    }
                    // ����ݒ�}�X�^
                    else if (MST_SUBSECTION.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                    }
                    // �q�ɐݒ�}�X�^
                    else if (MST_WAREHOUSE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                    }
                    // �]�ƈ��ݒ�}�X�^
                    else if (MST_EMPLOYEE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    else if (MST_USERGDCATEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    else if (MST_USERGDBUSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    else if (MST_USERGDBANKU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsBigUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                    }
                    // �|���D��Ǘ��}�X�^
                    else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                    }
                    // �|���}�X�^
                    else if (MST_RATE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                    }
                    // ����ڕW�ݒ�}�X�^
                    else if (MST_SALESTARGET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                    }
                    // ���Ӑ�}�X�^
                    else if (MST_CUSTOME.Equals(work.MasterName))
                    {
                        // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                        //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                        //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                        logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                        // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    }
                    // �d����}�X�^
                    else if (MST_SUPPLIER.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                    }
                    // �����}�X�^
                    else if (MST_JOINPARTSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                    }
                    // �Z�b�g�}�X�^
                    else if (MST_GOODSSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                    }
                    // �s�a�n�}�X�^
                    else if (MST_TBOSEARCHU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                    }
                    // �Ԏ�}�X�^
                    else if (MST_MODELNAMEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                    }
                    // �a�k�R�[�h�}�X�^
                    else if (MST_BLGOODSCDU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                    }
                    // ���[�J�[�}�X�^
                    else if (MST_MAKERU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                    }
                    // ���i�����ރ}�X�^
                    else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                    }
                    // �O���[�v�R�[�h�}�X�^
                    else if (MST_BLGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                    }
                    // BL�R�[�h�K�C�h�}�X�^
                    else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                    }
                    // ���i�}�X�^
                    else if (MST_GOODSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                            + searchCountWork.IsolIslandPrcCount) + MARK_2;
                    }
                    // �݌Ƀ}�X�^
                    else if (MST_STOCK.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                    }
                    // ��փ}�X�^
                    else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                    }
                    // ���ʃ}�X�^
                    else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                    }
                }

                logStr = logStr.Trim();
                logStr = logStr.Substring(0, logStr.Length - 1);
                string logStrTemp = string.Empty;

                Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                byte[] SourceStr_Bytes;
                byte[] CutStr_Bytes = new byte[500];


                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                Int32 logStrLen = SourceStr_Bytes.Length;

                for (; 0 < logStrLen; )
                {
                    if (logStrLen > 500)
                    {
                        Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                        logStrTemp = myEncoding.GetString(CutStr_Bytes);
                        logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                        logStrTemp = logStrTemp + COUNTNAME;
                        logStrTemp = logStrTemp.Trim();
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                            logStrTemp, "����(���_�F" + baseCode + ")");
                        logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                        logStr = logStr.Trim();

                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        logStrLen = logStrLen - 500;
                    }
                    else
                    {
                        logStr = logStr.Trim();
                        if (!string.IsNullOrEmpty(logStr))
                        {
                            if (logStr.Substring(0, 1).Equals("�A"))
                            {
                                logStr = logStr.Substring(2);
                            }
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                logStr, "����(���_�F" + baseCode + ")");
                        }
                        break;
                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                searchCountWork.ErrorKubun = -2;
                return status;
            }
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                //searchCountWork.ErrorKubun = -1;//DEL 2011/09/05 #24047
                searchCountWork.ErrorKubun = -5;//ADD 2011/09/05 #24047
                return status;
            }
            // ���_�Ǘ��ݒ�}�X�^�̍X�V
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                //if (startTime < syncExecDt)//DEL 2011/08/30 #24191 �}�X�^���M�i�������M�j�̑��M���s���ɂ���
                if (startTime < syncExecDt && extractCondDiv != 1)//ADD 2011/08/30 #24191 �}�X�^���M�i�������M�j�̑��M���s���ɂ���
                {
                    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                    status = _iAPMSTControlDB.UpdateSecMngSet(enterpriseCode, baseCode, updEmployeeCode, syncExecDt, out retMessage);
                }
            }
            return status;

        }

        /// <summary>
        /// ���_�Ǘ�����M�Ώۃf�[�^PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="secMngSndRcvWork">D���_�Ǘ�����M�Ώۃf�[�^</param>
        /// <returns>AP���_�Ǘ�����M�Ώۃf�[�^</returns>
        public DCSecMngSndRcvWork SearchDataFromUpdData(SecMngSndRcvWork secMngSndRcvWork)
        {
            if (secMngSndRcvWork == null)
            {
                return null;
            }

            DCSecMngSndRcvWork dcSecInfoSetWork = new DCSecMngSndRcvWork();
            // ���_���ݒ�f�[�^�ϊ�
            dcSecInfoSetWork.CreateDateTime = secMngSndRcvWork.CreateDateTime;
            dcSecInfoSetWork.UpdateDateTime = secMngSndRcvWork.UpdateDateTime;
            dcSecInfoSetWork.EnterpriseCode = secMngSndRcvWork.EnterpriseCode;
            dcSecInfoSetWork.FileHeaderGuid = secMngSndRcvWork.FileHeaderGuid;
            dcSecInfoSetWork.UpdEmployeeCode = secMngSndRcvWork.UpdEmployeeCode;
            dcSecInfoSetWork.UpdAssemblyId1 = secMngSndRcvWork.UpdAssemblyId1;
            dcSecInfoSetWork.UpdAssemblyId2 = secMngSndRcvWork.UpdAssemblyId2;
            dcSecInfoSetWork.LogicalDeleteCode = secMngSndRcvWork.LogicalDeleteCode;
            dcSecInfoSetWork.DisplayOrder = secMngSndRcvWork.DisplayOrder;
            dcSecInfoSetWork.MasterName = secMngSndRcvWork.MasterName;
            dcSecInfoSetWork.FileId = secMngSndRcvWork.FileId;
            dcSecInfoSetWork.FileNm = secMngSndRcvWork.FileNm;
            dcSecInfoSetWork.UserGuideDivCd = secMngSndRcvWork.UserGuideDivCd;
            dcSecInfoSetWork.SecMngSendDiv = secMngSndRcvWork.SecMngSendDiv;
            dcSecInfoSetWork.SecMngRecvDiv = secMngSndRcvWork.SecMngRecvDiv;

            return dcSecInfoSetWork;
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA��M�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="masterDivList">�}�X�^�敪���X�g</param>
        /// <param name="masterDtlDivList">�}�X�^���׋敪���X�g</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="secMngSetArrList">�V���N���ԃ��X�g</param>
        /// <param name="paramList">�}�X�^���o�������X�g</param>
        /// <param name="sndRcvHisWork">����M�������O�f�[�^���[�N</param>
        /// <param name="pmEnterpriseCode">PM��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="baseCode">���_�R�[�g</param>
        /// <param name="searchCountWork">�����v��</param>
        /// <param name="isEmpty">��̔��f</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA��M�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        //public int ReceProc(string enterpriseCode, Int32 connectPointDiv, ArrayList masterDivList, ArrayList masterDtlDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, string pmEnterpriseCode,//DEL 2011/07/25
                       //string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)//DEL 2011/07/25
        public int ReceProc(string enterpriseCode, Int32 connectPointDiv, ArrayList masterDivList, ArrayList masterDtlDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, ArrayList paramList, //ADD 2011/07/25
                        SndRcvHisWork sndRcvHisWork, string pmEnterpriseCode, string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)
        {
            string retMessage;
            isEmpty = false;
            DateTime syncExecDt = new DateTime();
            searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string updBaseCode = baseCode;
            baseCode = baseCode.Trim();

            ArrayList masterDivTempList = new ArrayList();
            DCSecMngSndRcvWork dcSecMngSndRcvWork = null;
            foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
            {
                dcSecMngSndRcvWork = this.SearchDataFromUpdData(secMngSndRcvWork);
                masterDivTempList.Add(dcSecMngSndRcvWork);
            }

            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            ArrayList condParamList = new ArrayList();
            foreach(SndRcvEtrWork sndRcvEtrWork in paramList)
            {
                if (sndRcvEtrWork.FileId.Equals(FILEID_CUSTOMER))
                {
                    CustomerProcParamWork customerProcParamWork = SndRcvEtrWorkToCustomerProcParamWork(sndRcvEtrWork);
                    customerProcParamWork.UpdateDateTimeBegin = beginningTime;
                    customerProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(customerProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_GOODS))
                {
                    GoodsProcParamWork goodsProcParamWork = SndRcvEtrWorkToGoodsProcParamWork(sndRcvEtrWork);
                    goodsProcParamWork.UpdateDateTimeBegin = beginningTime;
                    goodsProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(goodsProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_STOCK))
                {
                    StockProcParamWork stockProcParamWork = SndRcvEtrWorkToStockProcParamWork(sndRcvEtrWork);
                    stockProcParamWork.UpdateDateTimeBegin = beginningTime;
                    stockProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(stockProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_SUPPLIER))
                {
                    SupplierProcParamWork supplierProcParamWork = SndRcvEtrWorkToSupplierProcParamWork(sndRcvEtrWork);
                    supplierProcParamWork.UpdateDateTimeBegin = beginningTime;
                    supplierProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(supplierProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_RATE))
                {
                    RateProcParamWork rateProcParamWork = SndRcvEtrWorkToRateProcParamWork(sndRcvEtrWork);
                    rateProcParamWork.UpdateDateTimeBegin = beginningTime;
                    rateProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(rateProcParamWork);
                }
                // --- ADD 2012/07/26 ------------------------->>>>>
                else if (sndRcvEtrWork.FileId.Equals(FILEID_EMPLOYEE))
                {
                    EmployeeProcParamWork employeeProcParamWork = SndRcvEtrWorkToEmployeeProcParamWork(sndRcvEtrWork);
                    employeeProcParamWork.UpdateDateTimeBegin = beginningTime;
                    employeeProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(employeeProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_JOINPARTSU))
                {
                    JoinPartsUProcParamWork joinPartsUProcParamWork = SndRcvEtrWorkToJoinPartsUProcParamWork(sndRcvEtrWork);
                    joinPartsUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    joinPartsUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(joinPartsUProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_USERGDU))
                {
                    UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = SndRcvEtrWorkToUserGdBuyDivUProcParamWork(sndRcvEtrWork);
                    userGdBuyDivUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    userGdBuyDivUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(userGdBuyDivUProcParamWork);
                }
                // --- ADD 2012/07/26 -------------------------<<<<<
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<

            // ���o�E�X�V�R���g���[�����������[�g���Ăяo���Ē��o�f�[�^���擾���A���o���ʃN���X��Ԃ��܂��B
            // �f�[�^�X�V����
            if (connectPointDiv == 0)
            {
                this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                // �f�[�^���o����
                //status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                if (sndRcvHisWork.SndLogExtraCondDiv == 0)
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
                }
                else
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, condParamList, ref retCSAList, out retMessage);
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            else
            {
                this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                // �f�[�^���o����
                status = _iMstTotalMachControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
            }

            // ���o���ʐ���̏ꍇ�A�f�[�^�ϊ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // �f�[�^�ϊ�����
                syncExecDt = this.ReceDivisionCustomSerializeArrayList(out updCSAList, retCSAList);
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                if (updCSAList == null || updCSAList.Count <= 0)
                {
                    isEmpty = true;
                    return status;
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                // �f�[�^�X�V����
                this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                status = _iAPMSTControlDB.Update(enterpriseCode, masterDivList, masterDtlDivList, ref updCSAList, pmEnterpriseCode, out isEmpty, out searchCountWork, out retMessage);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (isEmpty)
                    {
                        // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                        return status;
                    }
                    else
                    {
                        string logStr = string.Empty;
                        foreach (SecMngSndRcvWork work in masterNameList)
                        {
                            logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                            // ���_�ݒ�}�X�^
                            if (MST_SECINFOSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                            }
                            // ����ݒ�}�X�^
                            else if (MST_SUBSECTION.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                            }
                            // �q�ɐݒ�}�X�^
                            else if (MST_WAREHOUSE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                            }
                            // �]�ƈ��ݒ�}�X�^
                            else if (MST_EMPLOYEE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                            else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                            else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                            else if (MST_USERGDCATEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�E��j
                            else if (MST_USERGDBUSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                            else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i��s�j
                            else if (MST_USERGDBANKU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                            else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                            else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                            else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                            else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                            else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                            else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // �|���D��Ǘ��}�X�^
                            else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                            }
                            // �|���}�X�^
                            else if (MST_RATE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                            }
                            // ����ڕW�ݒ�}�X�^
                            else if (MST_SALESTARGET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                            }
                            // ���Ӑ�}�X�^
                            else if (MST_CUSTOME.Equals(work.MasterName))
                            {
                                // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                                //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                                logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                                // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                            }
                            // �d����}�X�^
                            else if (MST_SUPPLIER.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                            }
                            // �����}�X�^
                            else if (MST_JOINPARTSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                            }
                            // �Z�b�g�}�X�^
                            else if (MST_GOODSSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                            }
                            // �s�a�n�}�X�^
                            else if (MST_TBOSEARCHU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                            }
                            // �Ԏ�}�X�^
                            else if (MST_MODELNAMEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                            }
                            // �a�k�R�[�h�}�X�^
                            else if (MST_BLGOODSCDU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                            }
                            // ���[�J�[�}�X�^
                            else if (MST_MAKERU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                            }
                            // ���i�����ރ}�X�^
                            else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                            }
                            // �O���[�v�R�[�h�}�X�^
                            else if (MST_BLGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                            }
                            // BL�R�[�h�K�C�h�}�X�^
                            else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                            }
                            // ���i�}�X�^
                            else if (MST_GOODSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                    + searchCountWork.IsolIslandPrcCount) + MARK_2;
                            }
                            // �݌Ƀ}�X�^
                            else if (MST_STOCK.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                            }
                            // ��փ}�X�^
                            else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                            }
                            // ���ʃ}�X�^
                            else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                            }
                        }

                        logStr = logStr.Trim();
                        logStr = logStr.Substring(0, logStr.Length - 1);
                        string logStrTemp = string.Empty;

                        Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                        byte[] SourceStr_Bytes;
                        byte[] CutStr_Bytes = new byte[500];


                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        Int32 logStrLen = SourceStr_Bytes.Length;

                        for (; 0 < logStrLen; )
                        {
                            if (logStrLen > 500)
                            {
                                Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                                logStrTemp = myEncoding.GetString(CutStr_Bytes);
                                logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                                logStrTemp = logStrTemp + COUNTNAME;
                                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                    logStrTemp, "����(���_�F" + baseCode + ")");
                                logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                                logStr = logStr.Trim();

                                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                                logStrLen = logStrLen - 500;
                            }
                            else
                            {
                                logStr = logStr.Trim();
                                if (!string.IsNullOrEmpty(logStr))
                                {
                                    if (logStr.Substring(0, 1).Equals("�A"))
                                    {
                                        logStr = logStr.Substring(2);
                                    }
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                    logStr, "����(���_�F" + baseCode + ")");
                                }
                                break;
                            }
                        }
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    searchCountWork.ErrorKubun = -2;
                    return status;
                }
                else
                {
                    // MOD 2009/06/17 ---->>>
                    //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCode + ")");
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCode + ")", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    searchCountWork.ErrorKubun = -1;
                    return status;
                }
            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCode + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                searchCountWork.ErrorKubun = -1;
                return status;
            }

            // ���_�Ǘ��ݒ�}�X�^�̍X�V
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                //DateTime startTime = new DateTime();
                //// ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                //foreach (APMSTSecMngSetWork work in secMngSetArrList)
                //{
                //    if (updBaseCode.Equals(work.SectionCode))
                //    {
                //        startTime = work.SyncExecDate;
                //        break;
                //    }
                //}
                //if (startTime < syncExecDt)
                //{
                //    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                //    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                //    status = _iAPMSTControlDB.UpdateReceSecMngSet(enterpriseCode, updBaseCode, updEmployeeCode, syncExecDt, out retMessage);
                //}
                #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //���M�������O�f�[�^�̍X�V
                ArrayList updList = new ArrayList();
                //����M�敪�͢1:��M��ɍX�V
                sndRcvHisWork.SendOrReceiveDivCd = 1;
                updList.Add(sndRcvHisWork);
                status = _iSndRcvHisRFDB.WriteRcvHisWork(ref updList);
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            return status;

        }

        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA�������M�������s��
        /// </summary>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <param name="masterDivList">�}�X�^�敪���X�g</param>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="startTime">�V���N����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA�������M�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        public int AutoServersSendProc(Int32 connectPointDiv, ArrayList masterNameList, ArrayList masterDivList, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode,
                       string updEmployeeCode, string baseCode)
        {
            string retMessage;
            bool isEmpty = false;
            MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            DateTime minSyncExecDt = new DateTime(); //ADD 2011/07/25
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();
            string baseCodeLog = baseCode.Trim();

            // ���o�E�X�V�R���g���[�����������[�g���Ăяo���Ē��o�f�[�^���擾���A���o���ʃN���X��Ԃ��܂��B
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            //int status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            int no;
            string pmEnterpriseCode = string.Empty;
            //string updSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂��� ---------->>>>>
            string updSectionCode = string.Empty;            
            int ret = GetBelongSectionCodeFormXml(ref updSectionCode);
            if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return ret;
            }            
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂��� ----------<<<<<
            this.SeachPmCode(enterpriseCode, baseCode, out pmEnterpriseCode);
            
            int status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, updSectionCode, beginningTime, endingTime, ref retCSAList, out no, out retMessage);
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            // ���o���ʐ���̏ꍇ�A�f�[�^�ϊ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // �f�[�^�ϊ�����
                //syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList); //DEL 2011/07/25
                this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out syncExecDt, out minSyncExecDt, out isEmpty, retCSAList); //ADD 2011/07/25
                //ADD 2011/09/15 fengwx #23934----->>>>>
                int updListCount = 0;
                foreach (ArrayList childList in updCSAList)
                {
                    updListCount += childList.Count;
                }
                if (updListCount > 0 && updListCount - searchCountWork.RateProtyMngCount - searchCountWork.PartsPosCodeUCount - searchCountWork.BLCodeGuideCount == 0)
                {
                    //�|���D��Ǘ��}�X�^�A���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�ABL�R�[�h�K�C�h�}�X�^
                    //�O�̃e�[�u�������𑗐M����ꍇ�A
                    //���M�ΏۊJ�n����:���.�J�n���t+�J�n����
                    //���M�ΏۏI������:���.�I�����t+�I������
                    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
                    syncExecDt = new DateTime(endingTime);
                }
                //ADD 2011/09/15 fengwx #23934-----<<<<<
                if (isEmpty)
                {
                    // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                    // MOD 2009/06/17 ---->>>
                    //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    return status;
                }
                else
                {
                    // �f�[�^�X�V����
                    if (connectPointDiv == 0)
                    {
                        this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                        // �f�[�^�X�V����
                        //status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, out retMessage); //DEL 2011/07/25
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        ArrayList objList = new ArrayList();

                        //**********************����M�������O�f�[�^�̐ݒ�**********************//
                        SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
                        //��ƃR�[�h:���O�C�����[�U�[�̊�ƃR�[�h
                        sndRcvHisWork.EnterpriseCode = enterpriseCode;
                        //�_���폜�敪
                        sndRcvHisWork.LogicalDeleteCode = 0;
                        //���_�R�[�h:���O�C�����[�U�[�̋��_�R�[�h
                        sndRcvHisWork.SectionCode = updSectionCode;
                        //����M�������O���M�ԍ�
                        sndRcvHisWork.SndRcvHisConsNo = no;
                        //���M����:�V�X�e�����t
                        sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                        //����M���O���p�敪:�0:���_�Ǘ��
                        sndRcvHisWork.SndLogUseDiv = 0;
                        //����M�敪:�0:���M�
                        sndRcvHisWork.SendOrReceiveDivCd = 0;
                        //���:�1:�}�X�^�
                        sndRcvHisWork.Kind = 1;
                        //����M���O���o�����敪�0:�����
                        sndRcvHisWork.SndLogExtraCondDiv = 0;
                        //���M�Ώۋ��_�R�[�h
                        sndRcvHisWork.ExtraObjSecCode = "";
                        //���M�ΏۊJ�n�����A���M�ΏۏI������
                        sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                        sndRcvHisWork.SndObjEndDate = syncExecDt;
                        //���M���ƃR�[�h
                        sndRcvHisWork.SendDestEpCode = pmEnterpriseCode;
                        //���M�拒�_�R�[�h
                        sndRcvHisWork.SendDestSecCode = baseCode;
                        objList.Add(sndRcvHisWork);
                        //**********************����M�������O�f�[�^�̐ݒ�**********************//

                        //******************����M���o�����������O�f�[�^�̐ݒ�******************//
                        //�������M�̏ꍇ�͓o�^���Ȃ����߁A�󃊃X�g��ݒ肷��
                        ArrayList sndRcvCondHisList = new ArrayList();
                        objList.Add(sndRcvCondHisList);
                        //******************����M���o�����������O�f�[�^�̐ݒ�******************//

                        ArrayList paraList = new ArrayList();
                        paraList.Add(objList);
                        status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, paraList, out retMessage);
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                    }
                    else
                    {
                        this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                        // �f�[�^�X�V����
                        status = _iMstTotalMachControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                    }

                }

            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + baseCodeLog + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCodeLog + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                return status;
            }

            // status��0����̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                foreach (SecMngSndRcvWork work in masterNameList)
                {
                    logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                    // ���_�ݒ�}�X�^
                    if (MST_SECINFOSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                    }
                    // ����ݒ�}�X�^
                    else if (MST_SUBSECTION.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                    }
                    // �q�ɐݒ�}�X�^
                    else if (MST_WAREHOUSE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                    }
                    // �]�ƈ��ݒ�}�X�^
                    else if (MST_EMPLOYEE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                    else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                    else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                    else if (MST_USERGDCATEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�E��j
                    else if (MST_USERGDBUSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                    else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i��s�j
                    else if (MST_USERGDBANKU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                    else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                    else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                    else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsBigUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                    else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                    else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                    else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                    }
                    // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                    else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                    }
                    // �|���D��Ǘ��}�X�^
                    else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                    }
                    // �|���}�X�^
                    else if (MST_RATE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                    }
                    // ����ڕW�ݒ�}�X�^
                    else if (MST_SALESTARGET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                    }
                    // ���Ӑ�}�X�^
                    else if (MST_CUSTOME.Equals(work.MasterName))
                    {
                        // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                        //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                        //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                        logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                        // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    }
                    // �d����}�X�^
                    else if (MST_SUPPLIER.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                    }
                    // �����}�X�^
                    else if (MST_JOINPARTSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                    }
                    // �Z�b�g�}�X�^
                    else if (MST_GOODSSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                    }
                    // �s�a�n�}�X�^
                    else if (MST_TBOSEARCHU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                    }
                    // �Ԏ�}�X�^
                    else if (MST_MODELNAMEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                    }
                    // �a�k�R�[�h�}�X�^
                    else if (MST_BLGOODSCDU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                    }
                    // ���[�J�[�}�X�^
                    else if (MST_MAKERU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                    }
                    // ���i�����ރ}�X�^
                    else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                    }
                    // �O���[�v�R�[�h�}�X�^
                    else if (MST_BLGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                    }
                    // BL�R�[�h�K�C�h�}�X�^
                    else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                    }
                    // ���i�}�X�^
                    else if (MST_GOODSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                            + searchCountWork.IsolIslandPrcCount) + MARK_2;
                    }
                    // �݌Ƀ}�X�^
                    else if (MST_STOCK.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                    }
                    // ��փ}�X�^
                    else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                    }
                    // ���ʃ}�X�^
                    else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                    }
                }

                logStr = logStr.Trim();
                logStr = logStr.Substring(0, logStr.Length - 1);
                string logStrTemp = string.Empty;

                Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                byte[] SourceStr_Bytes;
                byte[] CutStr_Bytes = new byte[500];


                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                Int32 logStrLen = SourceStr_Bytes.Length;

                for (; 0 < logStrLen; )
                {
                    if (logStrLen > 500)
                    {
                        Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                        logStrTemp = myEncoding.GetString(CutStr_Bytes);
                        logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                        logStrTemp = logStrTemp + COUNTNAME;
                        operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                            logStrTemp, "����(���_�F" + baseCodeLog + ")");
                        logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                        logStr = logStr.Trim();

                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        logStrLen = logStrLen - 500;
                    }
                    else
                    {
                        logStr = logStr.Trim();
                        if (!string.IsNullOrEmpty(logStr))
                        {
                            if (logStr.Substring(0, 1).Equals("�A"))
                            {
                                logStr = logStr.Substring(2);
                            }
                            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                            logStr, "����(���_�F" + baseCodeLog + ")");
                        }

                        break;
                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                return status;
            }
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCodeLog + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCodeLog + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                return status;
            }

            // ���_�Ǘ��ݒ�}�X�^�̍X�V
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                if (startTime < syncExecDt)
                {
                    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                    status = _iAPMSTControlDB.UpdateSecMngSet(enterpriseCode, baseCode, updEmployeeCode, syncExecDt, out retMessage);
                }
            }
            return status;

        }

        /// <summary>
        /// ���_�Ǘ��ݒ�����擾���āA������M�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^�敪���X�g</param>
        /// <param name="masterDtlDivList">�}�X�^���׋敪���X�g</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="beginningTime">�J�n����</param>
        /// <param name="endingTime">�I������</param>
        /// <param name="secMngSetArrList">�V���N���ԃ��X�g</param>
        /// <param name="paramList">����M���o�����������O�f�[�^���X�g</param>
        /// <param name="recSndRcvHisWork">����M�������O�f�[�^���[�N</param>
        /// <param name="pmEnterpriseCode">PM��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="baseCode">���_�R�[�g</param>
        /// <param name="isEmpty">�󔻒f</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�����擾���āA������M�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        //public int AutoServersReceProc(string enterpriseCode, ArrayList masterNameList, ArrayList masterDivList, ArrayList masterDtlDivList, Int32 connectPointDiv, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, string pmEnterpriseCode,
        //       string updEmployeeCode, string baseCode, out bool isEmpty)//DEL 2011/07/25
        public int AutoServersReceProc(string enterpriseCode, ArrayList masterNameList, ArrayList masterDivList, ArrayList masterDtlDivList, Int32 connectPointDiv, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, ArrayList paramList, 
            SndRcvHisWork recSndRcvHisWork, string pmEnterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty)//ADD 2011/07/25
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage;
            string baseCodeLog = baseCode.Trim();
            isEmpty = false;
            DateTime syncExecDt = new DateTime();
            MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();

            // �� 2009.06.22 ���m add PVCS.231
            ArrayList masterDivTempList = new ArrayList();
            DCSecMngSndRcvWork dcSecMngSndRcvWork = null;
            foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
            {
                dcSecMngSndRcvWork = this.SearchDataFromUpdData(secMngSndRcvWork);
                masterDivTempList.Add(dcSecMngSndRcvWork);
            }
            // �� 2009.06.22 ���m add

            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            ArrayList condParamList = new ArrayList();
            foreach (SndRcvEtrWork sndRcvEtrWork in paramList)
            {
                if (sndRcvEtrWork.FileId.Equals(FILEID_CUSTOMER))
                {
                    CustomerProcParamWork customerProcParamWork = SndRcvEtrWorkToCustomerProcParamWork(sndRcvEtrWork);
                    customerProcParamWork.UpdateDateTimeBegin = beginningTime;
                    customerProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(customerProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_GOODS))
                {
                    GoodsProcParamWork goodsProcParamWork = SndRcvEtrWorkToGoodsProcParamWork(sndRcvEtrWork);
                    goodsProcParamWork.UpdateDateTimeBegin = beginningTime;
                    goodsProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(goodsProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_STOCK))
                {
                    StockProcParamWork stockProcParamWork = SndRcvEtrWorkToStockProcParamWork(sndRcvEtrWork);
                    stockProcParamWork.UpdateDateTimeBegin = beginningTime;
                    stockProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(stockProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_SUPPLIER))
                {
                    SupplierProcParamWork supplierProcParamWork = SndRcvEtrWorkToSupplierProcParamWork(sndRcvEtrWork);
                    supplierProcParamWork.UpdateDateTimeBegin = beginningTime;
                    supplierProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(supplierProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_RATE))
                {
                    RateProcParamWork rateProcParamWork = SndRcvEtrWorkToRateProcParamWork(sndRcvEtrWork);
                    rateProcParamWork.UpdateDateTimeBegin = beginningTime;
                    rateProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(rateProcParamWork);
                }
                // --- ADD 2012/07/26 ------------------------->>>>>
                else if (sndRcvEtrWork.FileId.Equals(FILEID_EMPLOYEE))
                {
                    EmployeeProcParamWork employeeProcParamWork = SndRcvEtrWorkToEmployeeProcParamWork(sndRcvEtrWork);
                    employeeProcParamWork.UpdateDateTimeBegin = beginningTime;
                    employeeProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(employeeProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_JOINPARTSU))
                {
                    JoinPartsUProcParamWork joinPartsUProcParamWork = SndRcvEtrWorkToJoinPartsUProcParamWork(sndRcvEtrWork);
                    joinPartsUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    joinPartsUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(joinPartsUProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_USERGDU))
                {
                    UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = SndRcvEtrWorkToUserGdBuyDivUProcParamWork(sndRcvEtrWork);
                    userGdBuyDivUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    userGdBuyDivUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(userGdBuyDivUProcParamWork);
                }
                // --- ADD 2012/07/26 -------------------------<<<<<
            }
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            // ���o�E�X�V�R���g���[�����������[�g���Ăяo���Ē��o�f�[�^���擾���A���o���ʃN���X��Ԃ��܂��B
            if (connectPointDiv == 0)
            {
                this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                // �f�[�^���o����
                //status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                if (recSndRcvHisWork.SndLogExtraCondDiv == 0)
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
                }
                else
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, condParamList, ref retCSAList, out retMessage);
                }
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            else
            {
                this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                // �f�[�^���o����
                status = _iMstTotalMachControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
            }

            // ���o���ʐ���̏ꍇ�A�f�[�^�ϊ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // �f�[�^�ϊ�����
                syncExecDt = this.ReceDivisionCustomSerializeArrayList(out updCSAList, retCSAList);


                // �f�[�^�X�V����
                this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                status = _iAPMSTControlDB.Update(enterpriseCode, masterDivList, masterDtlDivList, ref updCSAList, pmEnterpriseCode, out isEmpty, out searchCountWork, out retMessage);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (isEmpty)
                    {
                        // ���o����CustomSerializeArrayList�̓��e�����݂��Ȃ��ꍇ�A
                        return status;
                    }
                    else
                    {
                        string logStr = string.Empty;
                        foreach (SecMngSndRcvWork work in masterNameList)
                        {
                            logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                            // ���_�ݒ�}�X�^
                            if (MST_SECINFOSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                            }
                            // ����ݒ�}�X�^
                            else if (MST_SUBSECTION.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                            }
                            // �q�ɐݒ�}�X�^
                            else if (MST_WAREHOUSE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                            }
                            // �]�ƈ��ݒ�}�X�^
                            else if (MST_EMPLOYEE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                            else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                            else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                            else if (MST_USERGDCATEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�E��j
                            else if (MST_USERGDBUSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                            else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i��s�j
                            else if (MST_USERGDBANKU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                            else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                            else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                            else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                            else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                            else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                            else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // �|���D��Ǘ��}�X�^
                            else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                            }
                            // �|���}�X�^
                            else if (MST_RATE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                            }
                            // ����ڕW�ݒ�}�X�^
                            else if (MST_SALESTARGET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                            }
                            // ���Ӑ�}�X�^
                            else if (MST_CUSTOME.Equals(work.MasterName))
                            {
                                // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                                //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                                logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                                // ------ UPD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                            }
                            // �d����}�X�^
                            else if (MST_SUPPLIER.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                            }
                            // �����}�X�^
                            else if (MST_JOINPARTSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                            }
                            // �Z�b�g�}�X�^
                            else if (MST_GOODSSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                            }
                            // �s�a�n�}�X�^
                            else if (MST_TBOSEARCHU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                            }
                            // �Ԏ�}�X�^
                            else if (MST_MODELNAMEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                            }
                            // �a�k�R�[�h�}�X�^
                            else if (MST_BLGOODSCDU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                            }
                            // ���[�J�[�}�X�^
                            else if (MST_MAKERU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                            }
                            // ���i�����ރ}�X�^
                            else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                            }
                            // �O���[�v�R�[�h�}�X�^
                            else if (MST_BLGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                            }
                            // BL�R�[�h�K�C�h�}�X�^
                            else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                            }
                            // ���i�}�X�^
                            else if (MST_GOODSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                    + searchCountWork.IsolIslandPrcCount) + MARK_2;
                            }
                            // �݌Ƀ}�X�^
                            else if (MST_STOCK.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                            }
                            // ��փ}�X�^
                            else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                            }
                            // ���ʃ}�X�^
                            else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                            }
                        }

                        logStr = logStr.Trim();
                        logStr = logStr.Substring(0, logStr.Length - 1);
                        string logStrTemp = string.Empty;

                        Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                        byte[] SourceStr_Bytes;
                        byte[] CutStr_Bytes = new byte[500];


                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        Int32 logStrLen = SourceStr_Bytes.Length;

                        for (; 0 < logStrLen; )
                        {
                            if (logStrLen > 500)
                            {
                                Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                                logStrTemp = myEncoding.GetString(CutStr_Bytes);
                                logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                                logStrTemp = logStrTemp + COUNTNAME;
                                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                    logStrTemp, "����(���_�F" + baseCodeLog + ")");
                                logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                                logStr = logStr.Trim();

                                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                                logStrLen = logStrLen - 500;
                            }
                            else
                            {
                                logStr = logStr.Trim();
                                if (!string.IsNullOrEmpty(logStr))
                                {
                                    if (logStr.Substring(0, 1).Equals("�A"))
                                    {
                                        logStr = logStr.Substring(2);
                                    }
                                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                            logStr, "����(���_�F" + baseCodeLog + ")");
                                }
                                break;
                            }
                        }
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    return status;
                }
                else
                {
                    // MOD 2009/06/17 ---->>>
                    //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCodeLog + ")");
                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + baseCodeLog + ")", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    return status;
                }


            }
            // ���o�������G���[�̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v�֑�����B
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + baseCodeLog + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + baseCodeLog + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                return status;
            }

            // status��0����̏ꍇ�A�u4�@���엚�����O�f�[�^�ւ̏������݁v
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status;
            //}
            //else
            //{
            //    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + baseCodeLog + ")");
            //}

            // ���_�Ǘ��ݒ�}�X�^�̍X�V
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                #region DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                //DateTime startTime = new DateTime();
                //// ��L���o�������_�R�[�h�ɑ΂��đS�f�[�^�̍X�V���t�Q�Ƃ��A�擾���R�[�h�̍ŐV���R�[�h���t���Z�o���܂��B
                //foreach (APMSTSecMngSetWork work in secMngSetArrList)
                //{
                //    if (baseCode.Equals(work.SectionCode))
                //    {
                //        startTime = work.SyncExecDate;
                //        break;
                //    }
                //}

                //if (startTime < syncExecDt)
                //{
                //    // ���_�Ǘ��ݒ�}�X�^�̍X�V
                //    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                //    status = _iAPMSTControlDB.UpdateReceSecMngSet(enterpriseCode, baseCode, updEmployeeCode, syncExecDt, out retMessage);
                //}
                #endregion DEL 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                //���M�������O�f�[�^�̍X�V
                ArrayList updList = new ArrayList();
                //����M�敪�͢1:��M��ɍX�V
                recSndRcvHisWork.SendOrReceiveDivCd = 1;
                updList.Add(recSndRcvHisWork);
                status = _iSndRcvHisRFDB.WriteRcvHisWork(ref updList);
                //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            }
            return status;

        }

        # endregion �� �}�X�^����M���� ��

        # region �� �f�[�^�ϊ����� ��
        /// <summary>
        /// ���M�f�[�^�ϊ�����
        /// </summary>
        /// <param name="updCSAList">���o�f�[�^</param>
        /// <param name="searchCountWork">�X�V�f�[�^</param>
        /// <param name="syncExecDt">�ő�V���N����</param>
        /// <param name="minSyncExecDt">�ŏ��V���N����</param>
        /// <param name="isEmpty">�󔻒f</param>
        /// <param name="retCSAList">���ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : ���M�f�[�^�ϊ������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 ���Ӑ惁�����̒ǉ�</br>
        /// </remarks>
        //private DateTime DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out MstSearchCountWorkWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList) //DEL 2011/07/25
        private void DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out MstSearchCountWorkWork searchCountWork, out DateTime syncExecDt, out DateTime minSyncExecDt, out bool isEmpty, CustomSerializeArrayList retCSAList) //ADD 2011/07/25
        {
            // ���_���ݒ�f�[�^
            Int32 secInfoSetCount = 0;
            ArrayList dcSecInfoSetList = new ArrayList();
            // ����}�X�^
            Int32 subSectionCount = 0;
            ArrayList dcSubSectionList = new ArrayList();
            // �]�ƈ��}�X�^
            Int32 employeeCount = 0;
            ArrayList dcEmployeeList = new ArrayList();
            // �]�ƈ��ڍ׃}�X�^
            Int32 employeeDtlCount = 0;
            ArrayList dcEmployeeDtlList = new ArrayList();
            // �q�Ƀ}�X�^
            Int32 warehouseCount = 0;
            ArrayList dcWarehouseList = new ArrayList();
            // ���Ӑ�}�X�^
            Int32 customerCount = 0;
            ArrayList dcCustomerList = new ArrayList();
            // ���Ӑ�}�X�^(�ϓ����)
            Int32 customerChangeCount = 0;
            ArrayList dcCustomerChangeList = new ArrayList();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            // ���Ӑ�}�X�^(�ϓ����)
            Int32 customerMemoCount = INT_ZERO;
            ArrayList dcCustomerMemoList = new ArrayList();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            // ���Ӑ�}�X�^�i�`�[�Ǘ��j
            Int32 custSlipMngCount = 0;
            ArrayList dcCustSlipMngList = new ArrayList();
            // ���Ӑ�}�X�^�i�|���O���[�v�j
            Int32 custRateGroupCount = 0;
            ArrayList dcCustRateGroupList = new ArrayList();
            // ���Ӑ�}�X�^(�`�[�ԍ�)
            Int32 custSlipNoSetCount = 0;
            ArrayList dcCustSlipNoSetList = new ArrayList();
            // �d����}�X�^
            Int32 supplierCount = 0;
            ArrayList dcSupplierList = new ArrayList();
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j
            Int32 makerUCount = 0;
            ArrayList dcMakerUList = new ArrayList();
            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            Int32 bLGoodsCdUCount = 0;
            ArrayList dcBLGoodsCdUList = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^���j
            Int32 goodsUCount = 0;
            ArrayList dcGoodsUList = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^�j
            Int32 goodsPriceCount = 0;
            ArrayList dcGoodsPriceList = new ArrayList();
            // ���i�Ǘ����}�X�^
            Int32 goodsMngCount = 0;
            ArrayList dcGoodsMngList = new ArrayList();
            // �������i�}�X�^
            Int32 isolIslandPrcCount = 0;
            ArrayList dcIsolIslandPrcList = new ArrayList();
            // �݌Ƀ}�X�^
            Int32 stockCount = 0;
            ArrayList dcStockList = new ArrayList();
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
            ArrayList dcUserGdBdUList = new ArrayList();
            // �|���D��Ǘ��}�X�^
            Int32 rateProtyMngCount = 0;
            ArrayList dcRateProtyMngList = new ArrayList();
            // �|���}�X�^
            Int32 rateCount = 0;
            ArrayList dcRateList = new ArrayList();
            // ���i�Z�b�g�}�X�^
            Int32 goodsSetCount = 0;
            ArrayList dcGoodsSetList = new ArrayList();
            // ���i��փ}�X�^�i���[�U�[�o�^���j
            Int32 partsSubstUCount = 0;
            ArrayList dcPartsSubstUList = new ArrayList();
            // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
            Int32 empSalesTargetCount = 0;
            ArrayList dcEmpSalesTargetList = new ArrayList();
            // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
            Int32 custSalesTargetCount = 0;
            ArrayList dcCustSalesTargetList = new ArrayList();
            // ���i�ʔ���ڕW�ݒ�}�X�^
            Int32 gcdSalesTargetCount = 0;
            ArrayList dcGcdSalesTargetList = new ArrayList();
            // ���i�����ރ}�X�^�i���[�U�[�o�^���j
            Int32 goodsMGroupUCount = 0;
            ArrayList dcGoodsMGroupUList = new ArrayList();
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            Int32 bLGroupUCount = 0;
            ArrayList dcBLGroupUList = new ArrayList();
            // �����}�X�^�i���[�U�[�o�^���j
            Int32 joinPartsUCount = 0;
            ArrayList dcJoinPartsUList = new ArrayList();
            // TBO�����}�X�^�i���[�U�[�o�^�j
            Int32 tBOSearchUCount = 0;
            ArrayList dcTBOSearchUList = new ArrayList();
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            Int32 partsPosCodeUCount = 0;
            ArrayList dcPartsPosCodeUList = new ArrayList();
            // BL�R�[�h�K�C�h�}�X�^
            Int32 bLCodeGuideCount = 0;
            ArrayList dcBLCodeGuideList = new ArrayList();
            // �Ԏ햼�̃}�X�^
            Int32 modelNameUCount = 0;
            ArrayList dcModelNameUList = new ArrayList();

            updCSAList = new CustomSerializeArrayList();
            searchCountWork = new MstSearchCountWorkWork();
            //DateTime syncExecDt = new DateTime(); //DEL 2011/07/25
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
            syncExecDt = new DateTime();
            minSyncExecDt = System.DateTime.Now;
            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
            isEmpty = true;

            //���p�����[�^�`�F�b�N
            if (retCSAList == null || retCSAList.Count <= 0)
            {
                //return syncExecDt; //DEL 2011/07/25
                return; //ADD 2011/07/25
            }

            for (int i = 0; i < retCSAList.Count; i++)
            {
                ArrayList retCSATemList = (ArrayList)retCSAList[i];
                for (int j = 0; j < retCSATemList.Count; j++)
                {
                    isEmpty = false;

                    Type wktype = retCSATemList[j].GetType();

                    // DC���_���ݒ�f�[�^�ϊ�����
                    if (wktype.Equals(typeof(APSecInfoSetWork)))
                    {
                        APSecInfoSetWork secInfoSetWork = (APSecInfoSetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (secInfoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = secInfoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (secInfoSetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = secInfoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCSecInfoSetWork dcSecInfoSetWork = MstConvertReceive.SearchDataFromUpdateData(secInfoSetWork);
                        dcSecInfoSetList.Add(dcSecInfoSetWork);
                        secInfoSetCount++;

                    }
                    // DC����f�[�^�X�V����
                    else if (wktype.Equals(typeof(APSubSectionWork)))
                    {
                        APSubSectionWork subSectionWork = (APSubSectionWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (subSectionWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = subSectionWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        // �ŐV���R�[�h���t�@=���@�ŏ����_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (subSectionWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = subSectionWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCSubSectionWork dcSubSectionWork = MstConvertReceive.SearchDataFromUpdateData(subSectionWork);
                        dcSubSectionList.Add(dcSubSectionWork);
                        subSectionCount++;
                    }
                    // DC�]�ƈ��}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APEmployeeWork)))
                    {
                        APEmployeeWork employeeWork = (APEmployeeWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (employeeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        // �ŐV���R�[�h���t�@=���@�ŏ����_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (employeeWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = employeeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCEmployeeWork dcEmployeeWork = MstConvertReceive.SearchDataFromUpdateData(employeeWork);
                        dcEmployeeList.Add(dcEmployeeWork);
                        employeeCount++;
                    }
                    // DC�]�ƈ��ڍ׃}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APEmployeeDtlWork)))
                    {
                        APEmployeeDtlWork employeeDtlWork = (APEmployeeDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (employeeDtlWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeDtlWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (employeeDtlWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = employeeDtlWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCEmployeeDtlWork dcEmployeeDtlWork = MstConvertReceive.SearchDataFromUpdateData(employeeDtlWork);
                        dcEmployeeDtlList.Add(dcEmployeeDtlWork);
                        employeeDtlCount++;
                    }
                    // DC�q�Ƀ}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APWarehouseWork)))
                    {
                        APWarehouseWork warehouseWork = (APWarehouseWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (warehouseWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = warehouseWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (warehouseWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = warehouseWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCWarehouseWork dcWarehouseWork = MstConvertReceive.SearchDataFromUpdateData(warehouseWork);
                        dcWarehouseList.Add(dcWarehouseWork);
                        warehouseCount++;
                    }
                    // DC���Ӑ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustomerWork)))
                    {
                        APCustomerWork customerWork = (APCustomerWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (customerWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (customerWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = customerWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCCustomerWork dcCustomerWork = MstConvertReceive.SearchDataFromUpdateData(customerWork);
                        dcCustomerList.Add(dcCustomerWork);
                        customerCount++;
                    }
                    // DC���Ӑ�}�X�^(�ϓ����)�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustomerChangeWork)))
                    {
                        APCustomerChangeWork customerChangeWork = (APCustomerChangeWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (customerChangeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerChangeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (customerChangeWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = customerChangeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCCustomerChangeWork dcCustomerChangeWork = MstConvertReceive.SearchDataFromUpdateData(customerChangeWork);
                        dcCustomerChangeList.Add(dcCustomerChangeWork);
                        customerChangeCount++;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                    // DC���Ӑ�}�X�^(�������)�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustomerMemoWork)))
                    {
                        APCustomerMemoWork customerMemoWork = (APCustomerMemoWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (customerMemoWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerMemoWork.UpdateDateTime;
                        }
                        if (customerMemoWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = customerMemoWork.UpdateDateTime;
                        }
                        DCCustomerMemoWork dcCustomerMemoWork = MstConvertReceive.SearchDataFromUpdateData(customerMemoWork);
                        dcCustomerMemoList.Add(dcCustomerMemoWork);
                        customerMemoCount++;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    // DC���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustSlipMngWork)))
                    {
                        APCustSlipMngWork custSlipMngWork = (APCustSlipMngWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custSlipMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (custSlipMngWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custSlipMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCCustSlipMngWork dcCustSlipMngWork = MstConvertReceive.SearchDataFromUpdateData(custSlipMngWork);
                        dcCustSlipMngList.Add(dcCustSlipMngWork);
                        custSlipMngCount++;
                    }
                    // DC���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustRateGroupWork)))
                    {
                        APCustRateGroupWork custRateGroupWork = (APCustRateGroupWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custRateGroupWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custRateGroupWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (custRateGroupWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custRateGroupWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCCustRateGroupWork dcCustRateGroupWork = MstConvertReceive.SearchDataFromUpdateData(custRateGroupWork);
                        dcCustRateGroupList.Add(dcCustRateGroupWork);
                        custRateGroupCount++;
                    }
                    // DC���Ӑ�i�`�[�ԍ��j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustSlipNoSetWork)))
                    {
                        APCustSlipNoSetWork custSlipNoSetWork = (APCustSlipNoSetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custSlipNoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipNoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (custSlipNoSetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custSlipNoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCCustSlipNoSetWork dcCustSlipNoSetWork = MstConvertReceive.SearchDataFromUpdateData(custSlipNoSetWork);
                        dcCustSlipNoSetList.Add(dcCustSlipNoSetWork);
                        custSlipNoSetCount++;
                    }
                    // DC�d����}�X�^�X�V����
                    else if (wktype.Equals(typeof(APSupplierWork)))
                    {
                        APSupplierWork supplierWork = (APSupplierWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (supplierWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = supplierWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (supplierWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = supplierWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCSupplierWork dcSupplierWork = MstConvertReceive.SearchDataFromUpdateData(supplierWork);
                        dcSupplierList.Add(dcSupplierWork);
                        supplierCount++;
                    }
                    // DC���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APMakerUWork)))
                    {
                        APMakerUWork makerUWork = (APMakerUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (makerUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = makerUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (makerUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = makerUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCMakerUWork dcMakerUWork = MstConvertReceive.SearchDataFromUpdateData(makerUWork);
                        dcMakerUList.Add(dcMakerUWork);
                        makerUCount++;
                    }
                    // DCBL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�X�V����
                    else if (wktype.Equals(typeof(APBLGoodsCdUWork)))
                    {
                        APBLGoodsCdUWork bLGoodsCdUWork = (APBLGoodsCdUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (bLGoodsCdUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGoodsCdUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (bLGoodsCdUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = bLGoodsCdUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCBLGoodsCdUWork dcBLGoodsCdUWork = MstConvertReceive.SearchDataFromUpdateData(bLGoodsCdUWork);
                        dcBLGoodsCdUList.Add(dcBLGoodsCdUWork);
                        bLGoodsCdUCount++;
                    }
                    // DC���i�}�X�^�i���[�U�[�o�^���j�X�V����
                    else if (wktype.Equals(typeof(APGoodsUWork)))
                    {
                        APGoodsUWork goodsUWork = (APGoodsUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (goodsUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCGoodsUWork dcGoodsUWork = MstConvertReceive.SearchDataFromUpdateData(goodsUWork);
                        dcGoodsUList.Add(dcGoodsUWork);
                        goodsUCount++;
                    }
                    // DC���i�}�X�^�i���[�U�[�o�^�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APGoodsPriceUWork)))
                    {
                        APGoodsPriceUWork goodsPriceUWork = (APGoodsPriceUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsPriceUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsPriceUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (goodsPriceUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsPriceUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCGoodsPriceUWork dcGoodsPriceUWork = MstConvertReceive.SearchDataFromUpdateData(goodsPriceUWork);
                        dcGoodsPriceList.Add(dcGoodsPriceUWork);
                        goodsPriceCount++;
                    }
                    // DC���i�Ǘ����}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APGoodsMngWork)))
                    {
                        APGoodsMngWork goodsMngWork = (APGoodsMngWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (goodsMngWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCGoodsMngWork dcGoodsMngWork = MstConvertReceive.SearchDataFromUpdateData(goodsMngWork);
                        dcGoodsMngList.Add(dcGoodsMngWork);
                        goodsMngCount++;
                    }
                    // DC�������i�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APIsolIslandPrcWork)))
                    {
                        APIsolIslandPrcWork isolIslandPrcWork = (APIsolIslandPrcWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (isolIslandPrcWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = isolIslandPrcWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (isolIslandPrcWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = isolIslandPrcWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCIsolIslandPrcWork dcIsolIslandPrcWork = MstConvertReceive.SearchDataFromUpdateData(isolIslandPrcWork);
                        dcIsolIslandPrcList.Add(dcIsolIslandPrcWork);
                        isolIslandPrcCount++;
                    }
                    // DC�݌Ƀ}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APStockWork)))
                    {
                        APStockWork stockWork = (APStockWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (stockWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = stockWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (stockWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = stockWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCStockWork dcStockWork = MstConvertReceive.SearchDataFromUpdateData(stockWork);
                        dcStockList.Add(dcStockWork);
                        stockCount++;
                    }
                    // DC���[�U�[�K�C�h�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APUserGdBdUWork)))
                    {
                        APUserGdBdUWork userGdBdUWork = (APUserGdBdUWork)retCSATemList[j];
                        // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                        if (userGdBdUWork.UserGuideDivCd == 21)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdAreaDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 31)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBusDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                        else if (userGdBdUWork.UserGuideDivCd == 33)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdCateUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�E��j
                        else if (userGdBdUWork.UserGuideDivCd == 34)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBusUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 41)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdGoodsDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                        else if (userGdBdUWork.UserGuideDivCd == 43)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdCusGrouPUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i��s�j
                        else if (userGdBdUWork.UserGuideDivCd == 46)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBankUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 47)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdPriDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 48)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdDeliDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                        else if (userGdBdUWork.UserGuideDivCd == 70)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdGoodsBigUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 71)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBuyDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                        else if (userGdBdUWork.UserGuideDivCd == 72)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdStockDivOUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                        else if (userGdBdUWork.UserGuideDivCd == 73)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdStockDivTUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                        else if (userGdBdUWork.UserGuideDivCd == 91)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdReturnReaUCount++;
                        }
                    }
                    // DC�|���D��Ǘ��}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APRateProtyMngWork)))
                    {
                        APRateProtyMngWork rateProtyMngWork = (APRateProtyMngWork)retCSATemList[j];
                        //DEL 2011/08/27 #23922 ��M�����ŃV���N���ԂƊ֌W������܂���----->>>>>
                        //// �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        //if (rateProtyMngWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = rateProtyMngWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (rateProtyMngWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = rateProtyMngWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        //DEL 2011/08/27 #23922 ��M�����ŃV���N���ԂƊ֌W������܂���-----<<<<<
                        DCRateProtyMngWork dcRateProtyMngWork = MstConvertReceive.SearchDataFromUpdateData(rateProtyMngWork);
                        dcRateProtyMngList.Add(dcRateProtyMngWork);
                        rateProtyMngCount++;
                    }
                    // DC�|���}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APRateWork)))
                    {
                        APRateWork rateWork = (APRateWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (rateWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = rateWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (rateWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = rateWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCRateWork dcRateWork = MstConvertReceive.SearchDataFromUpdateData(rateWork);
                        dcRateList.Add(dcRateWork);
                        rateCount++;
                    }
                    // DC���i�Z�b�g�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APGoodsSetWork)))
                    {
                        APGoodsSetWork goodsSetWork = (APGoodsSetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (goodsSetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCGoodsSetWork dcGoodsSetWork = MstConvertReceive.SearchDataFromUpdateData(goodsSetWork);
                        dcGoodsSetList.Add(dcGoodsSetWork);
                        goodsSetCount++;
                    }
                    // DC���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APPartsSubstUWork)))
                    {
                        APPartsSubstUWork partsSubstUWork = (APPartsSubstUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (partsSubstUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = partsSubstUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (partsSubstUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = partsSubstUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCPartsSubstUWork dcPartsSubstUWork = MstConvertReceive.SearchDataFromUpdateData(partsSubstUWork);
                        dcPartsSubstUList.Add(dcPartsSubstUWork);
                        partsSubstUCount++;
                    }
                    // DC�]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APEmpSalesTargetWork)))
                    {
                        APEmpSalesTargetWork empSalesTargetWork = (APEmpSalesTargetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (empSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = empSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (empSalesTargetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = empSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCEmpSalesTargetWork dcEmpSalesTargetWork = MstConvertReceive.SearchDataFromUpdateData(empSalesTargetWork);
                        dcEmpSalesTargetList.Add(dcEmpSalesTargetWork);
                        empSalesTargetCount++;
                    }
                    // DC���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APCustSalesTargetWork)))
                    {
                        APCustSalesTargetWork custSalesTargetWork = (APCustSalesTargetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (custSalesTargetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCCustSalesTargetWork dcCustSalesTargetWork = MstConvertReceive.SearchDataFromUpdateData(custSalesTargetWork);
                        dcCustSalesTargetList.Add(dcCustSalesTargetWork);
                        custSalesTargetCount++;
                    }
                    // DC���i�ʔ���ڕW�ݒ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APGcdSalesTargetWork)))
                    {
                        APGcdSalesTargetWork gcdSalesTargetWork = (APGcdSalesTargetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (gcdSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = gcdSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (gcdSalesTargetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = gcdSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCGcdSalesTargetWork dcGcdSalesTargetWork = MstConvertReceive.SearchDataFromUpdateData(gcdSalesTargetWork);
                        dcGcdSalesTargetList.Add(dcGcdSalesTargetWork);
                        gcdSalesTargetCount++;
                    }
                    // DC���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APGoodsGroupUWork)))
                    {
                        APGoodsGroupUWork goodsGroupUWork = (APGoodsGroupUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (goodsGroupUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCGoodsGroupUWork dcGoodsGroupUWork = MstConvertReceive.SearchDataFromUpdateData(goodsGroupUWork);
                        dcGoodsMGroupUList.Add(dcGoodsGroupUWork);
                        goodsMGroupUCount++;
                    }
                    // DCBL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APBLGroupUWork)))
                    {
                        APBLGroupUWork bLGroupUWork = (APBLGroupUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (bLGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (bLGroupUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = bLGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCBLGroupUWork dcBLGroupUWork = MstConvertReceive.SearchDataFromUpdateData(bLGroupUWork);
                        dcBLGroupUList.Add(dcBLGroupUWork);
                        bLGroupUCount++;
                    }
                    // DC�����}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APJoinPartsUWork)))
                    {
                        APJoinPartsUWork joinPartsUWork = (APJoinPartsUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (joinPartsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = joinPartsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (joinPartsUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = joinPartsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCJoinPartsUWork dcJoinPartsUWork = MstConvertReceive.SearchDataFromUpdateData(joinPartsUWork);
                        dcJoinPartsUList.Add(dcJoinPartsUWork);
                        joinPartsUCount++;
                    }
                    // DCTBO�����}�X�^�i���[�U�[�o�^�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APTBOSearchUWork)))
                    {
                        APTBOSearchUWork tBOSearchUWork = (APTBOSearchUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (tBOSearchUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = tBOSearchUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (tBOSearchUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = tBOSearchUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCTBOSearchUWork dcTBOSearchUWork = MstConvertReceive.SearchDataFromUpdateData(tBOSearchUWork);
                        dcTBOSearchUList.Add(dcTBOSearchUWork);
                        tBOSearchUCount++;
                    }
                    // DC���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APPartsPosCodeUWork)))
                    {
                        APPartsPosCodeUWork partsPosCodeUWork = (APPartsPosCodeUWork)retCSATemList[j];
                        //DEL 2011/08/27 #23922 ��M�����ŃV���N���ԂƊ֌W������܂���----->>>>>
                        //// �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        //if (partsPosCodeUWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = partsPosCodeUWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (partsPosCodeUWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = partsPosCodeUWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        //DEL 2011/08/27 #23922 ��M�����ŃV���N���ԂƊ֌W������܂���-----<<<<<
                        DCPartsPosCodeUWork dcPartsPosCodeUWork = MstConvertReceive.SearchDataFromUpdateData(partsPosCodeUWork);
                        dcPartsPosCodeUList.Add(dcPartsPosCodeUWork);
                        partsPosCodeUCount++;
                    }
                    // DCBL�R�[�h�K�C�h�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APBLCodeGuideWork)))
                    {
                        APBLCodeGuideWork bLCodeGuideWork = (APBLCodeGuideWork)retCSATemList[j];
                        //DEL 2011/08/27 #23922 ��M�����ŃV���N���ԂƊ֌W������܂���----->>>>>
                        //// �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        //if (bLCodeGuideWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = bLCodeGuideWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        //if (bLCodeGuideWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = bLCodeGuideWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        //DEL 2011/08/27 #23922 ��M�����ŃV���N���ԂƊ֌W������܂���-----<<<<<
                        DCBLCodeGuideWork dcBLCodeGuideWork = MstConvertReceive.SearchDataFromUpdateData(bLCodeGuideWork);
                        dcBLCodeGuideList.Add(dcBLCodeGuideWork);
                        bLCodeGuideCount++;
                    }
                    // DC�Ԏ햼�̃}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(APModelNameUWork)))
                    {
                        APModelNameUWork modelNameUWork = (APModelNameUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (modelNameUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = modelNameUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
                        if (modelNameUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = modelNameUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
                        DCModelNameUWork dcModelNameUWork = MstConvertReceive.SearchDataFromUpdateData(modelNameUWork);
                        dcModelNameUList.Add(dcModelNameUWork);
                        modelNameUCount++;
                    }
                    else
                    {
                        // 
                    }
                }
            }

            // ���_���ݒ�f�[�^�f�[�^
            updCSAList.Add(dcSecInfoSetList);
            searchCountWork.SecInfoSetCount = secInfoSetCount;
            // ����}�X�^�f�[�^
            updCSAList.Add(dcSubSectionList);
            searchCountWork.SubSectionCount = subSectionCount;
            // �]�ƈ��}�X�^�f�[�^
            updCSAList.Add(dcEmployeeList);
            searchCountWork.EmployeeCount = employeeCount;
            // �]�ƈ��ڍ׃}�X�^�f�[�^
            updCSAList.Add(dcEmployeeDtlList);
            searchCountWork.EmployeeDtlCount = employeeDtlCount;
            // �q�Ƀ}�X�^
            updCSAList.Add(dcWarehouseList);
            searchCountWork.WarehouseCount = warehouseCount;
            // ���Ӑ�}�X�^�f�[�^
            updCSAList.Add(dcCustomerList);
            searchCountWork.CustomerCount = customerCount;
            // ���Ӑ�}�X�^(�ϓ����)�f�[�^
            updCSAList.Add(dcCustomerChangeList);
            searchCountWork.CustomerChangeCount = customerChangeCount;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            // ���Ӑ�}�X�^(�������)�f�[�^
            updCSAList.Add(dcCustomerMemoList);
            searchCountWork.CustomerMemoCount = customerMemoCount;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^
            updCSAList.Add(dcCustSlipMngList);
            searchCountWork.CustSlipMngCount = custSlipMngCount;
            // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^
            updCSAList.Add(dcCustRateGroupList);
            searchCountWork.CustRateGroupCount = custRateGroupCount;
            // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^
            updCSAList.Add(dcCustSlipNoSetList);
            searchCountWork.CustSlipNoSetCount = custSlipNoSetCount;
            // �d����}�X�^
            updCSAList.Add(dcSupplierList);
            searchCountWork.SupplierCount = supplierCount;
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(dcMakerUList);
            searchCountWork.MakerUCount = makerUCount;
            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            updCSAList.Add(dcBLGoodsCdUList);
            searchCountWork.BLGoodsCdUCount = bLGoodsCdUCount;
            // ���i�}�X�^�i���[�U�[�o�^���j
            updCSAList.Add(dcGoodsUList);
            searchCountWork.GoodsUCount = goodsUCount;
            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^
            updCSAList.Add(dcGoodsPriceList);
            searchCountWork.GoodsPriceCount = goodsPriceCount;
            // ���i�Ǘ����}�X�^�f�[�^
            updCSAList.Add(dcGoodsMngList);
            searchCountWork.GoodsMngCount = goodsMngCount;
            // �������i�}�X�^�f�[�^
            updCSAList.Add(dcIsolIslandPrcList);
            searchCountWork.IsolIslandPrcCount = isolIslandPrcCount;
            // �݌Ƀ}�X�^�f�[�^
            updCSAList.Add(dcStockList);
            searchCountWork.StockCount = stockCount;
            // ���[�U�[�K�C�h�}�X�^�f�[�^
            updCSAList.Add(dcUserGdBdUList);
            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
            searchCountWork.UserGdAreaDivUCount = userGdAreaDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
            searchCountWork.UserGdBusDivUCount = userGdBusDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
            searchCountWork.UserGdCateUCount = userGdCateUCount;
            // ���[�U�[�K�C�h�}�X�^�i�E��j
            searchCountWork.UserGdBusUCount = userGdBusUCount;
            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
            searchCountWork.UserGdGoodsDivUCount = userGdGoodsDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
            searchCountWork.UserGdCusGrouPUCount = userGdCusGrouPUCount;
            // ���[�U�[�K�C�h�}�X�^�i��s�j
            searchCountWork.UserGdBankUCount = userGdBankUCount;
            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
            searchCountWork.UserGdPriDivUCount = userGdPriDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
            searchCountWork.UserGdDeliDivUCount = userGdDeliDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
            searchCountWork.UserGdGoodsBigUCount = userGdGoodsBigUCount;
            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
            searchCountWork.UserGdBuyDivUCount = userGdBuyDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
            searchCountWork.UserGdStockDivOUCount = userGdStockDivOUCount;
            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
            searchCountWork.UserGdStockDivTUCount = userGdStockDivTUCount;
            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
            searchCountWork.UserGdReturnReaUCount = userGdReturnReaUCount;
            // �|���D��Ǘ��}�X�^�f�[�^
            updCSAList.Add(dcRateProtyMngList);
            searchCountWork.RateProtyMngCount = rateProtyMngCount;
            // �|���}�X�^�f�[�^
            updCSAList.Add(dcRateList);
            searchCountWork.RateCount = rateCount;
            // ���i�Z�b�g�}�X�^�f�[�^
            updCSAList.Add(dcGoodsSetList);
            searchCountWork.GoodsSetCount = goodsSetCount;
            // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(dcPartsSubstUList);
            searchCountWork.PartsSubstUCount = partsSubstUCount;
            // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^
            updCSAList.Add(dcEmpSalesTargetList);
            searchCountWork.EmpSalesTargetCount = empSalesTargetCount;
            // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^
            updCSAList.Add(dcCustSalesTargetList);
            searchCountWork.CustSalesTargetCount = custSalesTargetCount;
            // ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^
            updCSAList.Add(dcGcdSalesTargetList);
            searchCountWork.GcdSalesTargetCount = gcdSalesTargetCount;
            // ���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(dcGoodsMGroupUList);
            searchCountWork.GoodsMGroupUCount = goodsMGroupUCount;
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(dcBLGroupUList);
            searchCountWork.BLGroupUCount = bLGroupUCount;
            // �����}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(dcJoinPartsUList);
            searchCountWork.JoinPartsUCount = joinPartsUCount;
            // TBO�����}�X�^�i���[�U�[�o�^�j�f�[�^
            updCSAList.Add(dcTBOSearchUList);
            searchCountWork.TBOSearchUCount = tBOSearchUCount;
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^
            updCSAList.Add(dcPartsPosCodeUList);
            searchCountWork.PartsPosCodeUCount = partsPosCodeUCount;
            // BL�R�[�h�K�C�h�}�X�^�f�[�^
            updCSAList.Add(dcBLCodeGuideList);
            searchCountWork.BLCodeGuideCount = bLCodeGuideCount;
            // �Ԏ햼�̃}�X�^�f�[�^
            updCSAList.Add(dcModelNameUList);
            searchCountWork.ModelNameUCount = modelNameUCount;

            //return syncExecDt; //DEL 2011/07/25
        }

        /// <summary>
        /// ��M�f�[�^�ϊ�����
        /// </summary>
        /// <param name="updCSAList">���o�f�[�^</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <returns>�V���N����</returns>
        /// <remarks>
        /// <br>Note       : ��M�f�[�^�ϊ��������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        private DateTime ReceDivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, CustomSerializeArrayList retCSAList)
        {
            // ���_���ݒ�f�[�^
            Int32 secInfoSetCount = 0;
            ArrayList apSecInfoSetList = new ArrayList();
            // ����}�X�^
            Int32 subSectionCount = 0;
            ArrayList apSubSectionList = new ArrayList();
            // �]�ƈ��}�X�^
            Int32 employeeCount = 0;
            ArrayList apEmployeeList = new ArrayList();
            // �]�ƈ��ڍ׃}�X�^
            Int32 employeeDtlCount = 0;
            ArrayList apEmployeeDtlList = new ArrayList();
            // �q�Ƀ}�X�^
            Int32 warehouseCount = 0;
            ArrayList apWarehouseList = new ArrayList();
            // ���Ӑ�}�X�^
            Int32 customerCount = 0;
            ArrayList apCustomerList = new ArrayList();
            // ���Ӑ�}�X�^(�ϓ����)
            Int32 customerChangeCount = 0;
            ArrayList apCustomerChangeList = new ArrayList();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            // ���Ӑ�}�X�^(�ϓ����)
            Int32 customerMemoCount = INT_ZERO;
            ArrayList apCustomerMemoList = new ArrayList();
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            // ���Ӑ�}�X�^�i�`�[�Ǘ��j
            Int32 custSlipMngCount = 0;
            ArrayList apCustSlipMngList = new ArrayList();
            // ���Ӑ�}�X�^�i�|���O���[�v�j
            Int32 custRateGroupCount = 0;
            ArrayList apCustRateGroupList = new ArrayList();
            // ���Ӑ�}�X�^(�`�[�ԍ�)
            Int32 custSlipNoSetCount = 0;
            ArrayList apCustSlipNoSetList = new ArrayList();
            // �d����}�X�^
            Int32 supplierCount = 0;
            ArrayList apSupplierList = new ArrayList();
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j
            Int32 makerUCount = 0;
            ArrayList apMakerUList = new ArrayList();
            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            Int32 bLGoodsCdUCount = 0;
            ArrayList apBLGoodsCdUList = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^���j
            Int32 goodsUCount = 0;
            ArrayList apGoodsUList = new ArrayList();
            // ���i�}�X�^�i���[�U�[�o�^�j
            Int32 goodsPriceCount = 0;
            ArrayList apGoodsPriceList = new ArrayList();
            // ���i�Ǘ����}�X�^
            Int32 goodsMngCount = 0;
            ArrayList apGoodsMngList = new ArrayList();
            // �������i�}�X�^
            Int32 isolIslandPrcCount = 0;
            ArrayList apIsolIslandPrcList = new ArrayList();
            // �݌Ƀ}�X�^
            Int32 stockCount = 0;
            ArrayList apStockList = new ArrayList();
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
            ArrayList apUserGdBdUList = new ArrayList();
            // �|���D��Ǘ��}�X�^
            Int32 rateProtyMngCount = 0;
            ArrayList apRateProtyMngList = new ArrayList();
            // �|���}�X�^
            Int32 rateCount = 0;
            ArrayList apRateList = new ArrayList();
            // ���i�Z�b�g�}�X�^
            Int32 goodsSetCount = 0;
            ArrayList apGoodsSetList = new ArrayList();
            // ���i��փ}�X�^�i���[�U�[�o�^���j
            Int32 partsSubstUCount = 0;
            ArrayList apPartsSubstUList = new ArrayList();
            // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
            Int32 empSalesTargetCount = 0;
            ArrayList apEmpSalesTargetList = new ArrayList();
            // ���Ӑ�ʔ���ڕW�ݒ�}�X�^
            Int32 custSalesTargetCount = 0;
            ArrayList apCustSalesTargetList = new ArrayList();
            // ���i�ʔ���ڕW�ݒ�}�X�^
            Int32 gcdSalesTargetCount = 0;
            ArrayList apGcdSalesTargetList = new ArrayList();
            // ���i�����ރ}�X�^�i���[�U�[�o�^���j
            Int32 goodsMGroupUCount = 0;
            ArrayList apGoodsMGroupUList = new ArrayList();
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            Int32 bLGroupUCount = 0;
            ArrayList apBLGroupUList = new ArrayList();
            // �����}�X�^�i���[�U�[�o�^���j
            Int32 joinPartsUCount = 0;
            ArrayList apJoinPartsUList = new ArrayList();
            // TBO�����}�X�^�i���[�U�[�o�^�j
            Int32 tBOSearchUCount = 0;
            ArrayList apTBOSearchUList = new ArrayList();
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
            Int32 partsPosCodeUCount = 0;
            ArrayList apPartsPosCodeUList = new ArrayList();
            // BL�R�[�h�K�C�h�}�X�^
            Int32 bLCodeGuideCount = 0;
            ArrayList apBLCodeGuideList = new ArrayList();
            // �Ԏ햼�̃}�X�^
            Int32 modelNameUCount = 0;
            ArrayList apModelNameUList = new ArrayList();

            updCSAList = new CustomSerializeArrayList();
            MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            DateTime syncExecDt = new DateTime();


            //���p�����[�^�`�F�b�N
            if (retCSAList == null || retCSAList.Count <= 0)
            {
                return syncExecDt;
            }

            for (int i = 0; i < retCSAList.Count; i++)
            {
                ArrayList retCSATemList = (ArrayList)retCSAList[i];
                for (int j = 0; j < retCSATemList.Count; j++)
                {
                    Type wktype = retCSATemList[j].GetType();

                    // AP���_���ݒ�f�[�^�ϊ�����
                    if (wktype.Equals(typeof(DCSecInfoSetWork)))
                    {
                        DCSecInfoSetWork secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (secInfoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = secInfoSetWork.UpdateDateTime;
                        }
                        APSecInfoSetWork apSecInfoSetWork = MstRecConvertReceive.SearchDataFromUpdateData(secInfoSetWork);
                        apSecInfoSetList.Add(apSecInfoSetWork);
                        secInfoSetCount++;

                    }
                    // AP����f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCSubSectionWork)))
                    {
                        DCSubSectionWork subSectionWork = (DCSubSectionWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (subSectionWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = subSectionWork.UpdateDateTime;
                        }
                        APSubSectionWork apSubSectionWork = MstRecConvertReceive.SearchDataFromUpdateData(subSectionWork);
                        apSubSectionList.Add(apSubSectionWork);
                        subSectionCount++;
                    }
                    // AP�]�ƈ��}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCEmployeeWork)))
                    {
                        DCEmployeeWork employeeWork = (DCEmployeeWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (employeeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeWork.UpdateDateTime;
                        }
                        APEmployeeWork apEmployeeWork = MstRecConvertReceive.SearchDataFromUpdateData(employeeWork);
                        apEmployeeList.Add(apEmployeeWork);
                        employeeCount++;
                    }
                    // AP�]�ƈ��ڍ׃}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                    {
                        DCEmployeeDtlWork employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (employeeDtlWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeDtlWork.UpdateDateTime;
                        }
                        APEmployeeDtlWork apEmployeeDtlWork = MstRecConvertReceive.SearchDataFromUpdateData(employeeDtlWork);
                        apEmployeeDtlList.Add(apEmployeeDtlWork);
                        employeeDtlCount++;
                    }
                    // AP�q�Ƀ}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCWarehouseWork)))
                    {
                        DCWarehouseWork warehouseWork = (DCWarehouseWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (warehouseWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = warehouseWork.UpdateDateTime;
                        }
                        APWarehouseWork apWarehouseWork = MstRecConvertReceive.SearchDataFromUpdateData(warehouseWork);
                        apWarehouseList.Add(apWarehouseWork);
                        warehouseCount++;
                    }
                    // AP���Ӑ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustomerWork)))
                    {
                        DCCustomerWork customerWork = (DCCustomerWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (customerWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerWork.UpdateDateTime;
                        }
                        APCustomerWork apCustomerWork = MstRecConvertReceive.SearchDataFromUpdateData(customerWork);
                        apCustomerList.Add(apCustomerWork);
                        customerCount++;
                    }
                    // AP���Ӑ�}�X�^(�ϓ����)�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                    {
                        DCCustomerChangeWork customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (customerChangeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerChangeWork.UpdateDateTime;
                        }
                        APCustomerChangeWork apCustomerChangeWork = MstRecConvertReceive.SearchDataFromUpdateData(customerChangeWork);
                        apCustomerChangeList.Add(apCustomerChangeWork);
                        customerChangeCount++;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
                    // AP���Ӑ�}�X�^(�������)�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustomerMemoWork)))
                    {
                        DCCustomerMemoWork customerMemoWork = (DCCustomerMemoWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (customerMemoWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerMemoWork.UpdateDateTime;
                        }
                        APCustomerMemoWork apCustomerMemoWork = MstRecConvertReceive.SearchDataFromUpdateData(customerMemoWork);
                        apCustomerMemoList.Add(apCustomerMemoWork);
                        customerMemoCount++;
                    }
                    // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
                    // AP���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                    {
                        DCCustSlipMngWork custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custSlipMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipMngWork.UpdateDateTime;
                        }
                        APCustSlipMngWork apCustSlipMngWork = MstRecConvertReceive.SearchDataFromUpdateData(custSlipMngWork);
                        apCustSlipMngList.Add(apCustSlipMngWork);
                        custSlipMngCount++;
                    }
                    // AP���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                    {
                        DCCustRateGroupWork custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custRateGroupWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custRateGroupWork.UpdateDateTime;
                        }
                        APCustRateGroupWork apCustRateGroupWork = MstRecConvertReceive.SearchDataFromUpdateData(custRateGroupWork);
                        apCustRateGroupList.Add(apCustRateGroupWork);
                        custRateGroupCount++;
                    }
                    // AP���Ӑ�i�`�[�ԍ��j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                    {
                        DCCustSlipNoSetWork custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custSlipNoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipNoSetWork.UpdateDateTime;
                        }
                        APCustSlipNoSetWork apCustSlipNoSetWork = MstRecConvertReceive.SearchDataFromUpdateData(custSlipNoSetWork);
                        apCustSlipNoSetList.Add(apCustSlipNoSetWork);
                        custSlipNoSetCount++;
                    }
                    // AP�d����}�X�^�X�V����
                    else if (wktype.Equals(typeof(DCSupplierWork)))
                    {
                        DCSupplierWork supplierWork = (DCSupplierWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (supplierWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = supplierWork.UpdateDateTime;
                        }
                        APSupplierWork apSupplierWork = MstRecConvertReceive.SearchDataFromUpdateData(supplierWork);
                        apSupplierList.Add(apSupplierWork);
                        supplierCount++;
                    }
                    // AP���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCMakerUWork)))
                    {
                        DCMakerUWork makerUWork = (DCMakerUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (makerUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = makerUWork.UpdateDateTime;
                        }
                        APMakerUWork apMakerUWork = MstRecConvertReceive.SearchDataFromUpdateData(makerUWork);
                        apMakerUList.Add(apMakerUWork);
                        makerUCount++;
                    }
                    // APBL���i�R�[�h�}�X�^�i���[�U�[�o�^���j�X�V����
                    else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                    {
                        DCBLGoodsCdUWork bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (bLGoodsCdUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGoodsCdUWork.UpdateDateTime;
                        }
                        APBLGoodsCdUWork apBLGoodsCdUWork = MstRecConvertReceive.SearchDataFromUpdateData(bLGoodsCdUWork);
                        apBLGoodsCdUList.Add(apBLGoodsCdUWork);
                        bLGoodsCdUCount++;
                    }
                    // AP���i�}�X�^�i���[�U�[�o�^���j�X�V����
                    else if (wktype.Equals(typeof(DCGoodsUWork)))
                    {
                        DCGoodsUWork goodsUWork = (DCGoodsUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsUWork.UpdateDateTime;
                        }
                        APGoodsUWork apGoodsUWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsUWork);
                        apGoodsUList.Add(apGoodsUWork);
                        goodsUCount++;
                    }
                    // AP���i�}�X�^�i���[�U�[�o�^�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                    {
                        DCGoodsPriceUWork goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsPriceUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsPriceUWork.UpdateDateTime;
                        }
                        APGoodsPriceUWork apGoodsPriceUWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsPriceUWork);
                        apGoodsPriceList.Add(apGoodsPriceUWork);
                        goodsPriceCount++;
                    }
                    // AP���i�Ǘ����}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCGoodsMngWork)))
                    {
                        DCGoodsMngWork goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsMngWork.UpdateDateTime;
                        }
                        APGoodsMngWork apGoodsMngWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsMngWork);
                        apGoodsMngList.Add(apGoodsMngWork);
                        goodsMngCount++;
                    }
                    // AP�������i�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                    {
                        DCIsolIslandPrcWork isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (isolIslandPrcWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = isolIslandPrcWork.UpdateDateTime;
                        }
                        APIsolIslandPrcWork apIsolIslandPrcWork = MstRecConvertReceive.SearchDataFromUpdateData(isolIslandPrcWork);
                        apIsolIslandPrcList.Add(apIsolIslandPrcWork);
                        isolIslandPrcCount++;
                    }
                    // AP�݌Ƀ}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCStockWork)))
                    {
                        DCStockWork stockWork = (DCStockWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (stockWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = stockWork.UpdateDateTime;
                        }
                        APStockWork apStockWork = MstRecConvertReceive.SearchDataFromUpdateData(stockWork);
                        apStockList.Add(apStockWork);
                        stockCount++;
                    }
                    // AP���[�U�[�K�C�h�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                    {
                        DCUserGdBdUWork userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                        // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                        if (userGdBdUWork.UserGuideDivCd == 21)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdAreaDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 31)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBusDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                        else if (userGdBdUWork.UserGuideDivCd == 33)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdCateUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�E��j
                        else if (userGdBdUWork.UserGuideDivCd == 34)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBusUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 41)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdGoodsDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                        else if (userGdBdUWork.UserGuideDivCd == 43)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdCusGrouPUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i��s�j
                        else if (userGdBdUWork.UserGuideDivCd == 46)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBankUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 47)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdPriDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 48)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdDeliDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                        else if (userGdBdUWork.UserGuideDivCd == 70)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdGoodsBigUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                        else if (userGdBdUWork.UserGuideDivCd == 71)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBuyDivUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                        else if (userGdBdUWork.UserGuideDivCd == 72)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdStockDivOUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                        else if (userGdBdUWork.UserGuideDivCd == 73)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdStockDivTUCount++;
                        }
                        // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                        else if (userGdBdUWork.UserGuideDivCd == 91)
                        {
                            // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdReturnReaUCount++;
                        }
                    }
                    // AP�|���D��Ǘ��}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                    {
                        DCRateProtyMngWork rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (rateProtyMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = rateProtyMngWork.UpdateDateTime;
                        }
                        APRateProtyMngWork apRateProtyMngWork = MstRecConvertReceive.SearchDataFromUpdateData(rateProtyMngWork);
                        apRateProtyMngList.Add(apRateProtyMngWork);
                        rateProtyMngCount++;
                    }
                    // AP�|���}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCRateWork)))
                    {
                        DCRateWork rateWork = (DCRateWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (rateWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = rateWork.UpdateDateTime;
                        }
                        APRateWork apRateWork = MstRecConvertReceive.SearchDataFromUpdateData(rateWork);
                        apRateList.Add(apRateWork);
                        rateCount++;
                    }
                    // AP���i�Z�b�g�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCGoodsSetWork)))
                    {
                        DCGoodsSetWork goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsSetWork.UpdateDateTime;
                        }
                        APGoodsSetWork apGoodsSetWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsSetWork);
                        apGoodsSetList.Add(apGoodsSetWork);
                        goodsSetCount++;
                    }
                    // AP���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                    {
                        DCPartsSubstUWork partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (partsSubstUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = partsSubstUWork.UpdateDateTime;
                        }
                        APPartsSubstUWork apPartsSubstUWork = MstRecConvertReceive.SearchDataFromUpdateData(partsSubstUWork);
                        apPartsSubstUList.Add(apPartsSubstUWork);
                        partsSubstUCount++;
                    }
                    // AP�]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                    {
                        DCEmpSalesTargetWork empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (empSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = empSalesTargetWork.UpdateDateTime;
                        }
                        APEmpSalesTargetWork apEmpSalesTargetWork = MstRecConvertReceive.SearchDataFromUpdateData(empSalesTargetWork);
                        apEmpSalesTargetList.Add(apEmpSalesTargetWork);
                        empSalesTargetCount++;
                    }
                    // AP���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                    {
                        DCCustSalesTargetWork custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (custSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSalesTargetWork.UpdateDateTime;
                        }
                        APCustSalesTargetWork apCustSalesTargetWork = MstRecConvertReceive.SearchDataFromUpdateData(custSalesTargetWork);
                        apCustSalesTargetList.Add(apCustSalesTargetWork);
                        custSalesTargetCount++;
                    }
                    // AP���i�ʔ���ڕW�ݒ�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                    {
                        DCGcdSalesTargetWork gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (gcdSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = gcdSalesTargetWork.UpdateDateTime;
                        }
                        APGcdSalesTargetWork apGcdSalesTargetWork = MstRecConvertReceive.SearchDataFromUpdateData(gcdSalesTargetWork);
                        apGcdSalesTargetList.Add(apGcdSalesTargetWork);
                        gcdSalesTargetCount++;
                    }
                    // AP���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                    {
                        DCGoodsGroupUWork goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (goodsGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsGroupUWork.UpdateDateTime;
                        }
                        APGoodsGroupUWork apGoodsGroupUWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsGroupUWork);
                        apGoodsMGroupUList.Add(apGoodsGroupUWork);
                        goodsMGroupUCount++;
                    }
                    // APBL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCBLGroupUWork)))
                    {
                        DCBLGroupUWork bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (bLGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGroupUWork.UpdateDateTime;
                        }
                        APBLGroupUWork apBLGroupUWork = MstRecConvertReceive.SearchDataFromUpdateData(bLGroupUWork);
                        apBLGroupUList.Add(apBLGroupUWork);
                        bLGroupUCount++;
                    }
                    // AP�����}�X�^�i���[�U�[�o�^���j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                    {
                        DCJoinPartsUWork joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (joinPartsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = joinPartsUWork.UpdateDateTime;
                        }
                        APJoinPartsUWork apJoinPartsUWork = MstRecConvertReceive.SearchDataFromUpdateData(joinPartsUWork);
                        apJoinPartsUList.Add(apJoinPartsUWork);
                        joinPartsUCount++;
                    }
                    // APTBO�����}�X�^�i���[�U�[�o�^�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                    {
                        DCTBOSearchUWork tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (tBOSearchUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = tBOSearchUWork.UpdateDateTime;
                        }
                        APTBOSearchUWork apTBOSearchUWork = MstRecConvertReceive.SearchDataFromUpdateData(tBOSearchUWork);
                        apTBOSearchUList.Add(apTBOSearchUWork);
                        tBOSearchUCount++;
                    }
                    // AP���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                    {
                        DCPartsPosCodeUWork partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (partsPosCodeUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = partsPosCodeUWork.UpdateDateTime;
                        }
                        APPartsPosCodeUWork apPartsPosCodeUWork = MstRecConvertReceive.SearchDataFromUpdateData(partsPosCodeUWork);
                        apPartsPosCodeUList.Add(apPartsPosCodeUWork);
                        partsPosCodeUCount++;
                    }
                    // APBL�R�[�h�K�C�h�}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                    {
                        DCBLCodeGuideWork bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (bLCodeGuideWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLCodeGuideWork.UpdateDateTime;
                        }
                        APBLCodeGuideWork apBLCodeGuideWork = MstRecConvertReceive.SearchDataFromUpdateData(bLCodeGuideWork);
                        apBLCodeGuideList.Add(apBLCodeGuideWork);
                        bLCodeGuideCount++;
                    }
                    // AP�Ԏ햼�̃}�X�^�f�[�^�X�V����
                    else if (wktype.Equals(typeof(DCModelNameUWork)))
                    {
                        DCModelNameUWork modelNameUWork = (DCModelNameUWork)retCSATemList[j];
                        // �ŐV���R�[�h���t�@=���@���_�Ǘ��ݒ�}�X�^.�V���N���s���t�̏ꍇ�A
                        if (modelNameUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = modelNameUWork.UpdateDateTime;
                        }
                        APModelNameUWork apModelNameUWork = MstRecConvertReceive.SearchDataFromUpdateData(modelNameUWork);
                        apModelNameUList.Add(apModelNameUWork);
                        modelNameUCount++;
                    }
                    else
                    {
                        // 
                    }
                }
            }

            // ���_���ݒ�f�[�^�f�[�^
            updCSAList.Add(apSecInfoSetList);
            searchCountWork.SecInfoSetCount = secInfoSetCount;
            // ����}�X�^�f�[�^
            updCSAList.Add(apSubSectionList);
            searchCountWork.SubSectionCount = subSectionCount;
            // �]�ƈ��}�X�^�f�[�^
            updCSAList.Add(apEmployeeList);
            searchCountWork.EmployeeCount = employeeCount;
            // �]�ƈ��ڍ׃}�X�^�f�[�^
            updCSAList.Add(apEmployeeDtlList);
            searchCountWork.EmployeeDtlCount = employeeDtlCount;
            // �q�Ƀ}�X�^
            updCSAList.Add(apWarehouseList);
            searchCountWork.WarehouseCount = warehouseCount;
            // ���Ӑ�}�X�^�f�[�^
            updCSAList.Add(apCustomerList);
            searchCountWork.CustomerCount = customerCount;
            // ���Ӑ�}�X�^(�ϓ����)�f�[�^
            updCSAList.Add(apCustomerChangeList);
            searchCountWork.CustomerChangeCount = customerChangeCount;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136-------->>>>>
            // ���Ӑ�}�X�^(�������)�f�[�^
            updCSAList.Add(apCustomerMemoList);
            searchCountWork.CustomerMemoCount = customerMemoCount;
            // ------ ADD 2021/04/12 ���O FOR PMKOBETSU-4136--------<<<<<
            // ���Ӑ�}�X�^�i�`�[�Ǘ��j�f�[�^
            updCSAList.Add(apCustSlipMngList);
            searchCountWork.CustSlipMngCount = custSlipMngCount;
            // ���Ӑ�}�X�^�i�|���O���[�v�j�f�[�^
            updCSAList.Add(apCustRateGroupList);
            searchCountWork.CustRateGroupCount = custRateGroupCount;
            // ���Ӑ�}�X�^(�`�[�ԍ�)�f�[�^
            updCSAList.Add(apCustSlipNoSetList);
            searchCountWork.CustSlipNoSetCount = custSlipNoSetCount;
            // �d����}�X�^
            updCSAList.Add(apSupplierList);
            searchCountWork.SupplierCount = supplierCount;
            // ���[�J�[�}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(apMakerUList);
            searchCountWork.MakerUCount = makerUCount;
            // BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
            updCSAList.Add(apBLGoodsCdUList);
            searchCountWork.BLGoodsCdUCount = bLGoodsCdUCount;
            // ���i�}�X�^�i���[�U�[�o�^���j
            updCSAList.Add(apGoodsUList);
            searchCountWork.GoodsUCount = goodsUCount;
            // ���i�}�X�^�i���[�U�[�o�^�j�f�[�^
            updCSAList.Add(apGoodsPriceList);
            searchCountWork.GoodsPriceCount = goodsPriceCount;
            // ���i�Ǘ����}�X�^�f�[�^
            updCSAList.Add(apGoodsMngList);
            searchCountWork.GoodsMngCount = goodsMngCount;
            // �������i�}�X�^�f�[�^
            updCSAList.Add(apIsolIslandPrcList);
            searchCountWork.IsolIslandPrcCount = isolIslandPrcCount;
            // �݌Ƀ}�X�^�f�[�^
            updCSAList.Add(apStockList);
            searchCountWork.StockCount = stockCount;
            // ���[�U�[�K�C�h�}�X�^�f�[�^
            updCSAList.Add(apUserGdBdUList);
            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
            searchCountWork.UserGdAreaDivUCount = userGdAreaDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
            searchCountWork.UserGdBusDivUCount = userGdBusDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
            searchCountWork.UserGdCateUCount = userGdCateUCount;
            // ���[�U�[�K�C�h�}�X�^�i�E��j
            searchCountWork.UserGdBusUCount = userGdBusUCount;
            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
            searchCountWork.UserGdGoodsDivUCount = userGdGoodsDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
            searchCountWork.UserGdCusGrouPUCount = userGdCusGrouPUCount;
            // ���[�U�[�K�C�h�}�X�^�i��s�j
            searchCountWork.UserGdBankUCount = userGdBankUCount;
            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
            searchCountWork.UserGdPriDivUCount = userGdPriDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
            searchCountWork.UserGdDeliDivUCount = userGdDeliDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
            searchCountWork.UserGdGoodsBigUCount = userGdGoodsBigUCount;
            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
            searchCountWork.UserGdBuyDivUCount = userGdBuyDivUCount;
            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
            searchCountWork.UserGdStockDivOUCount = userGdStockDivOUCount;
            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
            searchCountWork.UserGdStockDivTUCount = userGdStockDivTUCount;
            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
            searchCountWork.UserGdReturnReaUCount = userGdReturnReaUCount;
            // �|���D��Ǘ��}�X�^�f�[�^
            updCSAList.Add(apRateProtyMngList);
            searchCountWork.RateProtyMngCount = rateProtyMngCount;
            // �|���}�X�^�f�[�^
            updCSAList.Add(apRateList);
            searchCountWork.RateCount = rateCount;
            // ���i�Z�b�g�}�X�^�f�[�^
            updCSAList.Add(apGoodsSetList);
            searchCountWork.GoodsSetCount = goodsSetCount;
            // ���i��փ}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(apPartsSubstUList);
            searchCountWork.PartsSubstUCount = partsSubstUCount;
            // �]�ƈ��ʔ���ڕW�ݒ�}�X�^�f�[�^
            updCSAList.Add(apEmpSalesTargetList);
            searchCountWork.EmpSalesTargetCount = empSalesTargetCount;
            // ���Ӑ�ʔ���ڕW�ݒ�}�X�^�f�[�^
            updCSAList.Add(apCustSalesTargetList);
            searchCountWork.CustSalesTargetCount = custSalesTargetCount;
            // ���i�ʔ���ڕW�ݒ�}�X�^�f�[�^
            updCSAList.Add(apGcdSalesTargetList);
            searchCountWork.GcdSalesTargetCount = gcdSalesTargetCount;
            // ���i�����ރ}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(apGoodsMGroupUList);
            searchCountWork.GoodsMGroupUCount = goodsMGroupUCount;
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(apBLGroupUList);
            searchCountWork.BLGroupUCount = bLGroupUCount;
            // �����}�X�^�i���[�U�[�o�^���j�f�[�^
            updCSAList.Add(apJoinPartsUList);
            searchCountWork.JoinPartsUCount = joinPartsUCount;
            // TBO�����}�X�^�i���[�U�[�o�^�j�f�[�^
            updCSAList.Add(apTBOSearchUList);
            searchCountWork.TBOSearchUCount = tBOSearchUCount;
            // ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�f�[�^
            updCSAList.Add(apPartsPosCodeUList);
            searchCountWork.PartsPosCodeUCount = partsPosCodeUCount;
            // BL�R�[�h�K�C�h�}�X�^�f�[�^
            updCSAList.Add(apBLCodeGuideList);
            searchCountWork.BLCodeGuideCount = bLCodeGuideCount;
            // �Ԏ햼�̃}�X�^�f�[�^
            updCSAList.Add(apModelNameUList);
            searchCountWork.ModelNameUCount = modelNameUCount;

            return syncExecDt;
        }

        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="customerProcParam">���Ӑ�}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APCustomerProcParamToSndRcvEtrWork(APCustomerProcParamWork customerProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = customerProcParam.CustomerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = customerProcParam.CustomerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond2 = customerProcParam.KanaBeginRF;
            sndRcvEtrWork.EndCond2 = customerProcParam.KanaEndRF;
            sndRcvEtrWork.StartCond3 = customerProcParam.MngSectionCodeBeginRF;
            sndRcvEtrWork.EndCond3 = customerProcParam.MngSectionCodeEndRF;
            sndRcvEtrWork.StartCond4 = customerProcParam.CustomerAgentCdBeginRF;
            sndRcvEtrWork.EndCond4 = customerProcParam.CustomerAgentCdEndRF;
            sndRcvEtrWork.StartCond5 = customerProcParam.SalesAreaCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond5 = customerProcParam.SalesAreaCodeEndRF.ToString();
            sndRcvEtrWork.StartCond6 = customerProcParam.BusinessTypeCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond6 = customerProcParam.BusinessTypeCodeEndRF.ToString();
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="goodsProcParam">���i�}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APGoodsProcParamToSndRcvEtrWork(APGoodsProcParamWork goodsProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = goodsProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = goodsProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond2 = goodsProcParam.GoodsMakerCdBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = goodsProcParam.GoodsMakerCdEndRF.ToString();
            sndRcvEtrWork.StartCond3 = goodsProcParam.BLGoodsCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = goodsProcParam.BLGoodsCodeEndRF.ToString();
            sndRcvEtrWork.StartCond4 = goodsProcParam.GoodsNoBeginRF;
            sndRcvEtrWork.EndCond4 = goodsProcParam.GoodsNoEndRF;
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="stockProcParam">�݌Ƀ}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APStockProcParamToSndRcvEtrWork(APStockProcParamWork stockProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = stockProcParam.WarehouseCodeBeginRF;
            sndRcvEtrWork.EndCond1 = stockProcParam.WarehouseCodeEndRF;
            sndRcvEtrWork.StartCond2 = stockProcParam.WarehouseShelfNoBeginRF;
            sndRcvEtrWork.EndCond2 = stockProcParam.WarehouseShelfNoEndRF;
            sndRcvEtrWork.StartCond3 = stockProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = stockProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond4 = stockProcParam.GoodsMakerCdBeginRF.ToString();
            sndRcvEtrWork.EndCond4 = stockProcParam.GoodsMakerCdEndRF.ToString();
            sndRcvEtrWork.StartCond5 = stockProcParam.BLGloupCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond5 = stockProcParam.BLGloupCodeEndRF.ToString();
            sndRcvEtrWork.StartCond6 = stockProcParam.GoodsNoBeginRF;
            sndRcvEtrWork.EndCond6 = stockProcParam.GoodsNoEndRF;
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="supplierProcParam">�d����}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APSupplierProcParamToSndRcvEtrWork(APSupplierProcParamWork supplierProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = supplierProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = supplierProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond2 = "";
            sndRcvEtrWork.EndCond2 = "";
            sndRcvEtrWork.StartCond3 = "";
            sndRcvEtrWork.EndCond3 = "";
            sndRcvEtrWork.StartCond4 = "";
            sndRcvEtrWork.EndCond4 = "";
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="rateProcParam">�|���}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APRateProcParamToSndRcvEtrWork(APRateProcParamWork rateProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = rateProcParam.UnitPriceKindRF;
            sndRcvEtrWork.EndCond1 = rateProcParam.SetFunRF;
            // --- DEL 2012/07/26 ------------------------->>>>>
            //sndRcvEtrWork.StartCond2 = rateProcParam.RateSettingDivideRF;
            //sndRcvEtrWork.EndCond2 = "";
            // --- DEL 2012/07/26 -------------------------<<<<<
            // --- ADD 2012/07/26 ------------------------->>>>>
            sndRcvEtrWork.StartCond2 = rateProcParam.SectionCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = rateProcParam.SectionCodeEndRF.ToString();
            // --- ADD 2012/07/26 -------------------------<<<<<
            sndRcvEtrWork.StartCond3 = rateProcParam.CustRateGrpCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = rateProcParam.CustRateGrpCodeEndRF.ToString();
            sndRcvEtrWork.StartCond4 = rateProcParam.CustomerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond4 = rateProcParam.CustomerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond5 = rateProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond5 = rateProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond6 = rateProcParam.GoodsMakerCdBeginRF.ToString();
            sndRcvEtrWork.EndCond6 = rateProcParam.GoodsMakerCdEndRF.ToString();
            sndRcvEtrWork.StartCond7 = rateProcParam.GoodsRateRankBeginRF;
            sndRcvEtrWork.EndCond7 = rateProcParam.GoodsRateRankEndRF;
            sndRcvEtrWork.StartCond8 = rateProcParam.GoodsRateGrpCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond8 = rateProcParam.GoodsRateGrpCodeEndRF.ToString();
            sndRcvEtrWork.StartCond9 = rateProcParam.BLGoodsCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond9 = rateProcParam.BLGoodsCodeEndRF.ToString();
            sndRcvEtrWork.StartCond10 = rateProcParam.GoodsNoBeginRF;
            sndRcvEtrWork.EndCond10 = rateProcParam.GoodsNoEndRF;

            return sndRcvEtrWork;
        }
        // --- ADD 2012/07/26 ------------------------->>>>>
        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="employeeProcParam">�]�ƈ��ݒ�}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APEmployeeProcParamToSndRcvEtrWork(APEmployeeProcParamWork employeeProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = employeeProcParam.BelongSectionCdBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = employeeProcParam.BelongSectionCdEndRF.ToString();
            sndRcvEtrWork.StartCond2 = employeeProcParam.EmployeeCdBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = employeeProcParam.EmployeeCdEndRF.ToString();
            sndRcvEtrWork.StartCond3 = "";
            sndRcvEtrWork.EndCond3 = "";
            sndRcvEtrWork.StartCond4 = "";
            sndRcvEtrWork.EndCond4 = "";
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="joinPartsUProcParam">�����}�X�^���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APJoinPartsUProcParamToSndRcvEtrWork(APJoinPartsUProcParamWork joinPartsUProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = joinPartsUProcParam.JoinSourPartsNoWithHBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = joinPartsUProcParam.JoinSourPartsNoWithHEndRF.ToString();
            sndRcvEtrWork.StartCond2 = joinPartsUProcParam.JoinSourceMakerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = joinPartsUProcParam.JoinSourceMakerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond3 = joinPartsUProcParam.JoinDispOrderBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = joinPartsUProcParam.JoinDispOrderEndRF.ToString();
            sndRcvEtrWork.StartCond4 = joinPartsUProcParam.JoinDestMakerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond4 = joinPartsUProcParam.JoinDestMakerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^
        /// </summary>
        /// <param name="userGdBuyDivUProcParam">���[�U�[�K�C�h�}�X�^(�̔��敪)���o����</param>
        /// <returns></returns>
        public SndRcvEtrWork APUserGdBuyDivUProcParamToSndRcvEtrWork(APUserGdBuyDivUProcParamWork userGdBuyDivUProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = userGdBuyDivUProcParam.GuideCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = userGdBuyDivUProcParam.GuideCodeEndRF.ToString();
            sndRcvEtrWork.StartCond2 = "";
            sndRcvEtrWork.EndCond2 = "";
            sndRcvEtrWork.StartCond3 = "";
            sndRcvEtrWork.EndCond3 = "";
            sndRcvEtrWork.StartCond4 = "";
            sndRcvEtrWork.EndCond4 = "";
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }
        // --- ADD 2012/07/26 -------------------------<<<<<

        /// <summary>
        /// ���Ӑ�}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public CustomerProcParamWork SndRcvEtrWorkToCustomerProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            CustomerProcParamWork customerProcParam = new CustomerProcParamWork();

            customerProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            customerProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            customerProcParam.KanaBeginRF = sndRcvEtrWork.StartCond2;
            customerProcParam.KanaEndRF = sndRcvEtrWork.EndCond2;
            customerProcParam.MngSectionCodeBeginRF = sndRcvEtrWork.StartCond3;
            customerProcParam.MngSectionCodeEndRF = sndRcvEtrWork.EndCond3;
            customerProcParam.CustomerAgentCdBeginRF = sndRcvEtrWork.StartCond4;
            customerProcParam.CustomerAgentCdEndRF = sndRcvEtrWork.EndCond4;
            customerProcParam.SalesAreaCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            customerProcParam.SalesAreaCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            customerProcParam.BusinessTypeCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            customerProcParam.BusinessTypeCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);

            return customerProcParam;
        }

        /// <summary>
        /// ���i�}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public GoodsProcParamWork SndRcvEtrWorkToGoodsProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            GoodsProcParamWork goodsProcParam = new GoodsProcParamWork();

            goodsProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            goodsProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            goodsProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
            goodsProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
            goodsProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            goodsProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            goodsProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond4;
            goodsProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond4;

            return goodsProcParam;
        }

        /// <summary>
        /// �݌Ƀ}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public StockProcParamWork SndRcvEtrWorkToStockProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            StockProcParamWork stockProcParam = new StockProcParamWork();

            stockProcParam.WarehouseCodeBeginRF = sndRcvEtrWork.StartCond1;
            stockProcParam.WarehouseCodeEndRF = sndRcvEtrWork.EndCond1;
            stockProcParam.WarehouseShelfNoBeginRF = sndRcvEtrWork.StartCond2;
            stockProcParam.WarehouseShelfNoEndRF = sndRcvEtrWork.EndCond2;
            stockProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            stockProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            stockProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            stockProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            stockProcParam.BLGloupCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            stockProcParam.BLGloupCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            stockProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond6;
            stockProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond6;

            return stockProcParam;
        }

        /// <summary>
        /// �d����}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public SupplierProcParamWork SndRcvEtrWorkToSupplierProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            SupplierProcParamWork supplierProcParam = new SupplierProcParamWork();

            supplierProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            supplierProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);

            return supplierProcParam;
        }

        /// <summary>
        /// �|���}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public RateProcParamWork SndRcvEtrWorkToRateProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            RateProcParamWork rateProcParam = new RateProcParamWork();

            rateProcParam.UnitPriceKindRF = sndRcvEtrWork.StartCond1;
            rateProcParam.SetFunRF = sndRcvEtrWork.EndCond1;
            // --- ADD 2012/07/26 ------------------------->>>>>
            rateProcParam.SectionCodeBeginRF = sndRcvEtrWork.StartCond2;
            rateProcParam.SectionCodeEndRF = sndRcvEtrWork.EndCond2;
            // --- ADD 2012/07/26 -------------------------<<<<<
            rateProcParam.CustRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            rateProcParam.CustRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            rateProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            rateProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            rateProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            rateProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            rateProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            rateProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
            rateProcParam.GoodsRateRankBeginRF = sndRcvEtrWork.StartCond7;
            rateProcParam.GoodsRateRankEndRF = sndRcvEtrWork.EndCond7;
            rateProcParam.GoodsRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond8);
            rateProcParam.GoodsRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond8);
            rateProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond9);
            rateProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond9);
            rateProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond10;
            rateProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond10;

            return rateProcParam;
        }
        //-----ADD 2011/07/25 �g���Y SCM�Ή�-���_�Ǘ��i10704767-00�j-----<<<<<
        // --- ADD 2012/07/26 ------------------------->>>>>
        /// <summary>
        /// �]�ƈ��ݒ�}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public EmployeeProcParamWork SndRcvEtrWorkToEmployeeProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            EmployeeProcParamWork employeeProcParam = new EmployeeProcParamWork();

            employeeProcParam.BelongSectionCdBeginRF = sndRcvEtrWork.StartCond1;
            employeeProcParam.BelongSectionCdEndRF = sndRcvEtrWork.EndCond1;
            employeeProcParam.EmployeeCdBeginRF = sndRcvEtrWork.StartCond2;
            employeeProcParam.EmployeeCdEndRF = sndRcvEtrWork.EndCond2;

            return employeeProcParam;
        }

        /// <summary>
        /// �����}�X�^���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public JoinPartsUProcParamWork SndRcvEtrWorkToJoinPartsUProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            JoinPartsUProcParamWork joinPartsUProcParam = new JoinPartsUProcParamWork();

            joinPartsUProcParam.JoinSourPartsNoWithHBeginRF = sndRcvEtrWork.StartCond1;
            joinPartsUProcParam.JoinSourPartsNoWithHEndRF = sndRcvEtrWork.EndCond1;
            joinPartsUProcParam.JoinSourceMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
            joinPartsUProcParam.JoinSourceMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
            joinPartsUProcParam.JoinDispOrderBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            joinPartsUProcParam.JoinDispOrderEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            joinPartsUProcParam.JoinDestMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            joinPartsUProcParam.JoinDestMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);

            return joinPartsUProcParam;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(�̔��敪)���o����
        /// </summary>
        /// <param name="sndRcvEtrWork">����M���o�����������O�f�[�^</param>
        /// <returns></returns>
        public UserGdBuyDivUProcParamWork SndRcvEtrWorkToUserGdBuyDivUProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            UserGdBuyDivUProcParamWork userGdBuyDivUProcParam = new UserGdBuyDivUProcParamWork();

            userGdBuyDivUProcParam.GuideCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            userGdBuyDivUProcParam.GuideCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);

            return userGdBuyDivUProcParam;
        }
        // --- ADD 2012/07/26 -------------------------<<<<<
        # endregion �� �f�[�^�ϊ����� ��

        #region �� �I�t���C����ԃ`�F�b�N���� ��

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        /// <remarks>
        /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�ڑ��\���菈�����s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion �� �I�t���C����ԃ`�F�b�N���� ��

        #region �� �ڑ���`�F�b�N���� ��
        /// <summary>
        /// �ڑ���`�F�b�N����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڑ���`�F�b�N�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�`�F�b�N��������</returns>
        public bool CheckConnect(string enterpriseCode, out int connectPointDiv, out string errMsg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);
            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;
                if (connectPointDiv == 0)
                {
                    // �ڑ��悪�u�f�[�^�Z���^�[�v�̏ꍇ�A����Ƃ��Ė߂�B
                    retResult = true;
                }
                else
                {
                    // �ڑ��悪�u�W�v�@�v�̏ꍇ
                    retResult = CheckRegistryKey(secMngConnectSt);
                    if (retResult == false)
                    {
                        errMsg = "�ڑ���̐ݒ肪�s���ł��B";
                    }
                }
            }
            else
            {
                errMsg = "�ڑ�����̎擾�����Ɏ��s���܂����B";
                retResult = false;
            }

            return retResult;
        }

        /// <summary>
        /// �}�X�^���̃`�F�b�N����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�ڑ���敪</param>
        /// <returns>���茋��</returns>
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃`�F�b�N�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        public bool CheckMasterDiv(string enterpriseCode, ArrayList masterNameList)
        {
            bool isContains = true;
            ArrayList masterNameCompareList = new ArrayList();
            ArrayList compareOneList = new ArrayList();
            ArrayList compareTwoList = new ArrayList();
            int status = this.LoadMstName(enterpriseCode, out masterNameCompareList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SecMngSndRcvWork work in masterNameCompareList)
                {
                    compareOneList.Add(work.MasterName);
                }
            }

            foreach (SecMngSndRcvWork work in masterNameList)
            {
                compareTwoList.Add(work.MasterName);
            }


            foreach (string mastName in compareOneList)
            {
                if (!compareTwoList.Contains(mastName))
                {
                    isContains = false;
                    return isContains;
                }
            }

            foreach (string mastName in compareTwoList)
            {
                if (!compareOneList.Contains(mastName))
                {
                    isContains = false;
                    return isContains;
                }
            }

            return isContains;
        }

        /// <summary>
        /// �����N���ڑ���`�F�b�N����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���茋��</returns>
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����N���ڑ���`�F�b�N�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�`�F�b�N��������</returns>
        public bool AutoServersCheckConnect(string enterpriseCode, out int connectPointDiv, out string errMsg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);
            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;
                if (connectPointDiv == 0 || connectPointDiv == 1)
                {
                    // �ڑ��悪�u�f�[�^�Z���^�[�v�̏ꍇ�A����Ƃ��Ė߂�B
                    retResult = true;
                }
            }
            else
            {
                errMsg = "�ڑ�����̎擾�����Ɏ��s���܂����B";
                retResult = false;
            }

            return retResult;
        }

        /// <summary>���W�X�g������`�F�b�N����
        /// <param name="secMngConnectSt">���_�Ǘ��ڑ���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���W�X�g������`�F�b�N�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        private bool CheckRegistryKey(SecMngConnectSt secMngConnectSt)
        {
            bool retResult = false;
            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 != null && rKey2 != null)
                {
                    // ���W�X�g���捞
                    string apServerIpAddress = rKey1.GetValue("%Domain%").ToString();
                    string dbServerIpAddress = rKey2.GetValue("%DataSource%").ToString();

                    if (String.IsNullOrEmpty(apServerIpAddress) || String.IsNullOrEmpty(dbServerIpAddress))
                    {
                        retResult = false;
                    }
                    else
                    {
                        retResult = (secMngConnectSt.ApServerIpAddress == apServerIpAddress) && (secMngConnectSt.DbServerIpAddress == dbServerIpAddress);
                    }
                }
                else
                {
                    // ���W�X�g����񂪖��ݒ�̏ꍇ
                    retResult = false;
                }
            }
            catch (Exception)
            {
                retResult = false;
            }

            return retResult;
        }

        #endregion �� �ڑ���`�F�b�N���� ��

    }
}
