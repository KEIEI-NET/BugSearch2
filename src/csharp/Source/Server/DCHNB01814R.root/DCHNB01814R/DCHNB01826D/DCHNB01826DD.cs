using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region [2008/06/06 M.Kubota DC.NS�̎��_����g�p���Ă��Ȃ��̂œ���]
#if false
    /// public class name:   SalesSlipNewEntryWork
    /// <summary>
    ///                      ����f�[�^(�����Ǎ�)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����f�[�^(�����Ǎ�)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesSlipNewEntryWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�ԍ��A���󒍔ԍ�</summary>
        /// <remarks>�ԍ��̑�����󒍔ԍ�</remarks>
        private Int32 _debitNLnkAcptAnOdr;

        /// <summary>�ԍ��A������`�[�ԍ�</summary>
        /// <remarks>�ԍ��̑��������`�[�ԍ�</remarks>
        private string _debitNLnkSalesSlNum = "";

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���㏤�i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</remarks>
        private Int32 _salesGoodsCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>�T�[�r�X�`�[�敪</summary>
        /// <remarks>0:OFF,1:ON</remarks>
        private Int32 _serviceSlipCd;

        /// <summary>������͋��_�R�[�h</summary>
        /// <remarks>�����^ �������͂������_�R�[�h</remarks>
        private string _salesInpSecCd = "";

        /// <summary>�����v�㋒�_�R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _demandAddUpSecCd = "";

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _searchSlipDate;

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>�����敪</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>���Ϗ��ԍ�</summary>
        private string _estimateFormNo = "";

        /// <summary>���ϋ敪</summary>
        /// <remarks>1:�ʏ팩�ρ@2:�P������</remarks>
        private Int32 _estimateDivide;

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S����</remarks>
        private string _salesInputCode = "";

        /// <summary>������͎Җ���</summary>
        private string _salesInputName = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S����</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S����</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���z�\���|���K�p�敪</summary>
        /// <remarks>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</remarks>
        private Int32 _ttlAmntDispRateApy;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㏬�v�i�ō��݁j�{��ېőΏۊz</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㏬�v�i�Ŕ����j�{��ېőΏۊz</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>���㏬�v�i�ō��݁j</summary>
        /// <remarks>�l����̖��׋��z�̍��v</remarks>
        private Int64 _salesSubtotalTaxInc;

        /// <summary>���㏬�v�i�Ŕ����j</summary>
        /// <remarks>�l����̖��׋��z�̍��v</remarks>
        private Int64 _salesSubtotalTaxExc;

        /// <summary>���㐳�����z</summary>
        /// <remarks>�l���O�̐Ŕ�������z</remarks>
        private Int64 _salseNetPrice;

        /// <summary>���㏬�v�i�Łj</summary>
        /// <remarks>���ł̏ꍇ:�ō���/105*5,�O�ł̏ꍇ:�Ŕ���*5/100</remarks>
        private Int64 _salesSubtotalTax;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>�O�őΏۋ��z�̍��v�i�Ŕ��C�l����j</remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>������őΏۊz</summary>
        /// <remarks>���őΏۋ��z�̍��v�i�ō��j</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>���㏬�v��ېőΏۊz</summary>
        /// <remarks>��ېőΏۋ��z�̍��v</remarks>
        private Int64 _salSubttlSubToTaxFre;

        /// <summary>������z����Ŋz�i�O�Łj</summary>
        /// <remarks>�l���O�̊O�ŏ��i�̏����</remarks>
        private Int64 _salseOutTax;

        /// <summary>������z����Ŋz�i���Łj</summary>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>����l�����z�v�i�Ŕ����j</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>����l���O�őΏۊz���v</summary>
        /// <remarks>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedSalesDisOutTax;

        /// <summary>����l�����őΏۊz���v</summary>
        /// <remarks>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedSalesDisInTax;

        /// <summary>����l����ېőΏۊz���v</summary>
        /// <remarks>��ېŏ��i�l���̔�ېőΏۊz</remarks>
        private Int64 _itdedSalseDisTaxFre;

        /// <summary>����l������Ŋz�i�O�Łj</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>����l������Ŋz�i���Łj</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>�������z�v</summary>
        private Int64 _totalCost;

        /// <summary>�T�[�r�X�a���</summary>
        /// <remarks>�������[�ȂǁA�T�[�r�X�a����̋��z</remarks>
        private Int64 _serviceDeposits;

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����Őŗ�</summary>
        /// <remarks>�ύX2007/8/22(�^,��) ����</remarks>
        private Double _consTaxRate;

        /// <summary>�[�������敪</summary>
        /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
        private Int32 _fractionProcCd;

        /// <summary>���|�����</summary>
        private Int64 _accRecConsTax;

        /// <summary>���������敪</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _autoDepositCd;

        /// <summary>���������`�[�ԍ�</summary>
        /// <remarks>�����������̓����`�[�ԍ�</remarks>
        private Int32 _autoDepositSlipNo;

        /// <summary>�������v�z</summary>
        /// <remarks>�`�[�S�̂̐������v�i�N���W�b�g�萔���͊܂܂Ȃ��j</remarks>
        private Int64 _demandableTtl;

        /// <summary>�����������v�z</summary>
        /// <remarks>�a����������v�z���܂�</remarks>
        private Int64 _depositAllowanceTtl;

        /// <summary>�a����������v�z</summary>
        private Int64 _mnyDepoAllowanceTtl;

        /// <summary>���������c��</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>�����R�[�h</summary>
        /// <remarks>0:�������Ӑ�,1:�������Ӑ�</remarks>
        private Int32 _outputNameCode;

        /// <summary>�`�[�Z���敪</summary>
        /// <remarks>1:���Ӑ�,2:�[����</remarks>
        private Int32 _slipAddressDiv;

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
        /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
        private string _addresseeName2 = "";

        /// <summary>�[�i��X�֔ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseePostNo = "";

        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr1 = "";

        /// <summary>�[�i��Z��2(����)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private Int32 _addresseeAddr2;

        /// <summary>�[�i��Z��3(�Ԓn)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr3 = "";

        /// <summary>�[�i��Z��4(�A�p�[�g����)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr4 = "";

        /// <summary>�[�i��d�b�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeTelNo = "";

        /// <summary>�[�i��FAX�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeFaxNo = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        private string _slipNote2 = "";

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>�ԕi���R</summary>
        private string _retGoodsReason = "";

        /// <summary>���W������</summary>
        /// <remarks>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private DateTime _regiProcDate;

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>POS���V�[�g�ԍ�</summary>
        /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _posReceiptNo;

        /// <summary>����f�[�^�X�V�s�敪</summary>
        /// <remarks>1:�X�V�\,2;�X�V�s��</remarks>
        private Int32 _salesSlipUpdatable;

        /// <summary>���׍s��</summary>
        /// <remarks>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</remarks>
        private Int32 _detailRowCount;

        /// <summary>�d�c�h���M��</summary>
        /// <remarks>YYYYMMDD �iErectricDataInterface�j</remarks>
        private DateTime _ediSendDate;

        /// <summary>�d�c�h�捞��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ediTakeInDate;

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>�`�[���s�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _slipPrintDivCd;

        /// <summary>�`�[���s�ϋ敪</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>����`�[���s��</summary>
        private DateTime _salesSlipPrintDate;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>�����ԍ�</summary>
        /// <remarks>����`����"��"�̎��ɃZ�b�g</remarks>
        private string _orderNumber = "";

        /// <summary>�[�i�敪</summary>
        /// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>�����t���O</summary>
        /// <remarks>0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</remarks>
        private Int32 _reconcileFlag;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�ꎮ�`�[�敪</summary>
        /// <remarks>0:�ʏ�`�[,1:�ꎮ�`�[</remarks>
        private Int32 _completeCd;

        /// <summary>������敪</summary>
        /// <remarks>���������敪�i0:��ʁ@1:�����W���@2:�����`�[�j</remarks>
        private Int32 _claimType;

        /// <summary>������z�[�������敪</summary>
        /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</remarks>
        private Int32 _salesPriceFracProcCd;

        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j</summary>
        /// <remarks>�݌Ɏ��敪���O�̖��׋��z�̏W�v</remarks>
        private Int64 _stockGoodsTtlTaxExc;

        /// <summary>�������i���v���z�i�Ŕ��j</summary>
        /// <remarks>���i�������O�̖��׋��z�̏W�v</remarks>
        private Int64 _pureGoodsTtlTaxExc;

        /// <summary>�艿����敪</summary>
        private Int32 _listPricePrintDiv;

        /// <summary>�����\���敪�P</summary>
        /// <remarks>�ʏ�@�@0:����@1:�a��</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>���Ϗ���ŋ敪</summary>
        /// <remarks>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</remarks>
        private Int32 _estimaTaxDivCd;

        /// <summary>���ύ��v����敪</summary>
        private Int32 _estimateTotalPrtCd;

        /// <summary>���Ϗ�����敪</summary>
        private Int32 _estimateFormPrtCd;

        /// <summary>�_��敪</summary>
        /// <remarks>0:���v��@1:�ꕔ�v��@2:�S�v��</remarks>
        private Int32 _contractDivCd;

        /// <summary>���ό���</summary>
        private string _estimateSubject = "";

        /// <summary>�r���P</summary>
        private string _footnotes1 = "";

        /// <summary>�r���Q</summary>
        private string _footnotes2 = "";

        /// <summary>���σ^�C�g���P</summary>
        private string _estimateTitle1 = "";

        /// <summary>���σ^�C�g���Q</summary>
        private string _estimateTitle2 = "";

        /// <summary>���σ^�C�g���R</summary>
        private string _estimateTitle3 = "";

        /// <summary>���σ^�C�g���S</summary>
        private string _estimateTitle4 = "";

        /// <summary>���σ^�C�g���T</summary>
        private string _estimateTitle5 = "";

        /// <summary>���ϔ��l�P</summary>
        private string _estimateNote1 = "";

        /// <summary>���ϔ��l�Q</summary>
        private string _estimateNote2 = "";

        /// <summary>���ϔ��l�R</summary>
        private string _estimateNote3 = "";

        /// <summary>���ϔ��l�S</summary>
        private string _estimateNote4 = "";

        /// <summary>���ϔ��l�T</summary>
        private string _estimateNote5 = "";

        /// <summary>�݌ɍX�V���_�R�[�h</summary>
        /// <remarks>�蓮�ǉ�����</remarks>
        private string _stockUpdateSecCd = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  MinSectionCode
        /// <summary>�ۃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  DebitNLnkAcptAnOdr
        /// <summary>�ԍ��A���󒍔ԍ��v���p�e�B</summary>
        /// <value>�ԍ��̑�����󒍔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��A���󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNLnkAcptAnOdr
        {
            get { return _debitNLnkAcptAnOdr; }
            set { _debitNLnkAcptAnOdr = value; }
        }

        /// public propaty name  :  DebitNLnkSalesSlNum
        /// <summary>�ԍ��A������`�[�ԍ��v���p�e�B</summary>
        /// <value>�ԍ��̑��������`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��A������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DebitNLnkSalesSlNum
        {
            get { return _debitNLnkSalesSlNum; }
            set { _debitNLnkSalesSlNum = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>���㏤�i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  ServiceSlipCd
        /// <summary>�T�[�r�X�`�[�敪�v���p�e�B</summary>
        /// <value>0:OFF,1:ON</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �T�[�r�X�`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ServiceSlipCd
        {
            get { return _serviceSlipCd; }
            set { _serviceSlipCd = value; }
        }

        /// public propaty name  :  SalesInpSecCd
        /// <summary>������͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �������͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInpSecCd
        {
            get { return _salesInpSecCd; }
            set { _salesInpSecCd = value; }
        }

        /// public propaty name  :  DemandAddUpSecCd
        /// <summary>�����v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DemandAddUpSecCd
        {
            get { return _demandAddUpSecCd; }
            set { _demandAddUpSecCd = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>�X�V���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �f�[�^�̓o�^�X�V���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  SearchSlipDate
        /// <summary>�`�[�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SearchSlipDate
        {
            get { return _searchSlipDate; }
            set { _searchSlipDate = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>�o�ד��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        /// public propaty name  :  EstimateFormNo
        /// <summary>���Ϗ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateFormNo
        {
            get { return _estimateFormNo; }
            set { _estimateFormNo = value; }
        }

        /// public propaty name  :  EstimateDivide
        /// <summary>���ϋ敪�v���p�e�B</summary>
        /// <value>1:�ʏ팩�ρ@2:�P������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateDivide
        {
            get { return _estimateDivide; }
            set { _estimateDivide = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TtlAmntDispRateApy
        /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
        /// <value>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlAmntDispRateApy
        {
            get { return _ttlAmntDispRateApy; }
            set { _ttlAmntDispRateApy = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㏬�v�i�ō��݁j�{��ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㏬�v�i�Ŕ����j�{��ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxInc
        /// <summary>���㏬�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTaxInc
        {
            get { return _salesSubtotalTaxInc; }
            set { _salesSubtotalTaxInc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxExc
        /// <summary>���㏬�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTaxExc
        {
            get { return _salesSubtotalTaxExc; }
            set { _salesSubtotalTaxExc = value; }
        }

        /// public propaty name  :  SalseNetPrice
        /// <summary>���㐳�����z�v���p�e�B</summary>
        /// <value>�l���O�̐Ŕ�������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐳�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalseNetPrice
        {
            get { return _salseNetPrice; }
            set { _salseNetPrice = value; }
        }

        /// public propaty name  :  SalesSubtotalTax
        /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
        /// <value>���ł̏ꍇ:�ō���/105*5,�O�ł̏ꍇ:�Ŕ���*5/100</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTax
        {
            get { return _salesSubtotalTax; }
            set { _salesSubtotalTax = value; }
        }

        /// public propaty name  :  ItdedSalesOutTax
        /// <summary>����O�őΏۊz�v���p�e�B</summary>
        /// <value>�O�őΏۋ��z�̍��v�i�Ŕ��C�l����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesOutTax
        {
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesInTax
        /// <summary>������őΏۊz�v���p�e�B</summary>
        /// <value>���őΏۋ��z�̍��v�i�ō��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesInTax
        {
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
        }

        /// public propaty name  :  SalSubttlSubToTaxFre
        /// <summary>���㏬�v��ېőΏۊz�v���p�e�B</summary>
        /// <value>��ېőΏۋ��z�̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v��ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalSubttlSubToTaxFre
        {
            get { return _salSubttlSubToTaxFre; }
            set { _salSubttlSubToTaxFre = value; }
        }

        /// public propaty name  :  SalseOutTax
        /// <summary>������z����Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�l���O�̊O�ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalseOutTax
        {
            get { return _salseOutTax; }
            set { _salseOutTax = value; }
        }

        /// public propaty name  :  SalAmntConsTaxInclu
        /// <summary>������z����Ŋz�i���Łj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalAmntConsTaxInclu
        {
            get { return _salAmntConsTaxInclu; }
            set { _salAmntConsTaxInclu = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxExc
        /// <summary>����l�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxExc
        {
            get { return _salesDisTtlTaxExc; }
            set { _salesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  ItdedSalesDisOutTax
        /// <summary>����l���O�őΏۊz���v�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesDisOutTax
        {
            get { return _itdedSalesDisOutTax; }
            set { _itdedSalesDisOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesDisInTax
        /// <summary>����l�����őΏۊz���v�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesDisInTax
        {
            get { return _itdedSalesDisInTax; }
            set { _itdedSalesDisInTax = value; }
        }

        /// public propaty name  :  ItdedSalseDisTaxFre
        /// <summary>����l����ېőΏۊz���v�v���p�e�B</summary>
        /// <value>��ېŏ��i�l���̔�ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalseDisTaxFre
        {
            get { return _itdedSalseDisTaxFre; }
            set { _itdedSalseDisTaxFre = value; }
        }

        /// public propaty name  :  SalesDisOutTax
        /// <summary>����l������Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisOutTax
        {
            get { return _salesDisOutTax; }
            set { _salesDisOutTax = value; }
        }

        /// public propaty name  :  SalesDisTtlTaxInclu
        /// <summary>����l������Ŋz�i���Łj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesDisTtlTaxInclu
        {
            get { return _salesDisTtlTaxInclu; }
            set { _salesDisTtlTaxInclu = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  ServiceDeposits
        /// <summary>�T�[�r�X�a����v���p�e�B</summary>
        /// <value>�������[�ȂǁA�T�[�r�X�a����̋��z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �T�[�r�X�a����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ServiceDeposits
        {
            get { return _serviceDeposits; }
            set { _serviceDeposits = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  ConsTaxRate
        /// <summary>����Őŗ��v���p�e�B</summary>
        /// <value>�ύX2007/8/22(�^,��) ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  AccRecConsTax
        /// <summary>���|����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AccRecConsTax
        {
            get { return _accRecConsTax; }
            set { _accRecConsTax = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        /// public propaty name  :  AutoDepositSlipNo
        /// <summary>���������`�[�ԍ��v���p�e�B</summary>
        /// <value>�����������̓����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositSlipNo
        {
            get { return _autoDepositSlipNo; }
            set { _autoDepositSlipNo = value; }
        }

        /// public propaty name  :  DemandableTtl
        /// <summary>�������v�z�v���p�e�B</summary>
        /// <value>�`�[�S�̂̐������v�i�N���W�b�g�萔���͊܂܂Ȃ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DemandableTtl
        {
            get { return _demandableTtl; }
            set { _demandableTtl = value; }
        }

        /// public propaty name  :  DepositAllowanceTtl
        /// <summary>�����������v�z�v���p�e�B</summary>
        /// <value>�a����������v�z���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAllowanceTtl
        {
            get { return _depositAllowanceTtl; }
            set { _depositAllowanceTtl = value; }
        }

        /// public propaty name  :  MnyDepoAllowanceTtl
        /// <summary>�a����������v�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a����������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MnyDepoAllowanceTtl
        {
            get { return _mnyDepoAllowanceTtl; }
            set { _mnyDepoAllowanceTtl = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>���������c���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  OutputNameCode
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// <value>0:�������Ӑ�,1:�������Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  SlipAddressDiv
        /// <summary>�`�[�Z���敪�v���p�e�B</summary>
        /// <value>1:���Ӑ�,2:�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Z���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2�v���p�e�B</summary>
        /// <value>�ǉ�(�o�^�R��) ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  AddresseePostNo
        /// <summary>�[�i��X�֔ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr2
        /// <summary>�[�i��Z��2(����)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��2(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeAddr2
        {
            get { return _addresseeAddr2; }
            set { _addresseeAddr2 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>�[�i��Z��3(�Ԓn)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��3(�Ԓn)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>�[�i��Z��4(�A�p�[�g����)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��4(�A�p�[�g����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>�[�i��d�b�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>�[�i��FAX�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>�`�[���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  RetGoodsReasonDiv
        /// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetGoodsReasonDiv
        {
            get { return _retGoodsReasonDiv; }
            set { _retGoodsReasonDiv = value; }
        }

        /// public propaty name  :  RetGoodsReason
        /// <summary>�ԕi���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RetGoodsReason
        {
            get { return _retGoodsReason; }
            set { _retGoodsReason = value; }
        }

        /// public propaty name  :  RegiProcDate
        /// <summary>���W�������v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime RegiProcDate
        {
            get { return _regiProcDate; }
            set { _regiProcDate = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  PosReceiptNo
        /// <summary>POS���V�[�g�ԍ��v���p�e�B</summary>
        /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POS���V�[�g�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PosReceiptNo
        {
            get { return _posReceiptNo; }
            set { _posReceiptNo = value; }
        }

        /// public propaty name  :  SalesSlipUpdatable
        /// <summary>����f�[�^�X�V�s�敪�v���p�e�B</summary>
        /// <value>1:�X�V�\,2;�X�V�s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����f�[�^�X�V�s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipUpdatable
        {
            get { return _salesSlipUpdatable; }
            set { _salesSlipUpdatable = value; }
        }

        /// public propaty name  :  DetailRowCount
        /// <summary>���׍s���v���p�e�B</summary>
        /// <value>�`�[���̖��ׂ̍s���i����p���ׂ͏����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׍s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailRowCount
        {
            get { return _detailRowCount; }
            set { _detailRowCount = value; }
        }

        /// public propaty name  :  EdiSendDate
        /// <summary>�d�c�h���M���v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdiSendDate
        {
            get { return _ediSendDate; }
            set { _ediSendDate = value; }
        }

        /// public propaty name  :  EdiTakeInDate
        /// <summary>�d�c�h�捞���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  SlipPrintDivCd
        /// <summary>�`�[���s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrintDivCd
        {
            get { return _slipPrintDivCd; }
            set { _slipPrintDivCd = value; }
        }

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  SalesSlipPrintDate
        /// <summary>����`�[���s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesSlipPrintDate
        {
            get { return _salesSlipPrintDate; }
            set { _salesSlipPrintDate = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  OrderNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>����`����"��"�̎��ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>��) 1:�z�B,2:�X���n��,3:����,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ReconcileFlag
        /// <summary>�����t���O�v���p�e�B</summary>
        /// <value>0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReconcileFlag
        {
            get { return _reconcileFlag; }
            set { _reconcileFlag = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  CompleteCd
        /// <summary>�ꎮ�`�[�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�`�[,1:�ꎮ�`�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ�`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompleteCd
        {
            get { return _completeCd; }
            set { _completeCd = value; }
        }

        /// public propaty name  :  ClaimType
        /// <summary>������敪�v���p�e�B</summary>
        /// <value>���������敪�i0:��ʁ@1:�����W���@2:�����`�[�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimType
        {
            get { return _claimType; }
            set { _claimType = value; }
        }

        /// public propaty name  :  SalesPriceFracProcCd
        /// <summary>������z�[�������敪�v���p�e�B</summary>
        /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesPriceFracProcCd
        {
            get { return _salesPriceFracProcCd; }
            set { _salesPriceFracProcCd = value; }
        }

        /// public propaty name  :  StockGoodsTtlTaxExc
        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>�݌Ɏ��敪���O�̖��׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockGoodsTtlTaxExc
        {
            get { return _stockGoodsTtlTaxExc; }
            set { _stockGoodsTtlTaxExc = value; }
        }

        /// public propaty name  :  PureGoodsTtlTaxExc
        /// <summary>�������i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>���i�������O�̖��׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PureGoodsTtlTaxExc
        {
            get { return _pureGoodsTtlTaxExc; }
            set { _pureGoodsTtlTaxExc = value; }
        }

        /// public propaty name  :  ListPricePrintDiv
        /// <summary>�艿����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPricePrintDiv
        {
            get { return _listPricePrintDiv; }
            set { _listPricePrintDiv = value; }
        }

        /// public propaty name  :  EraNameDispCd1
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>�ʏ�@�@0:����@1:�a��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// public propaty name  :  EstimaTaxDivCd
        /// <summary>���Ϗ���ŋ敪�v���p�e�B</summary>
        /// <value>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ���ŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimaTaxDivCd
        {
            get { return _estimaTaxDivCd; }
            set { _estimaTaxDivCd = value; }
        }

        /// public propaty name  :  EstimateTotalPrtCd
        /// <summary>���ύ��v����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ύ��v����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateTotalPrtCd
        {
            get { return _estimateTotalPrtCd; }
            set { _estimateTotalPrtCd = value; }
        }

        /// public propaty name  :  EstimateFormPrtCd
        /// <summary>���Ϗ�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateFormPrtCd
        {
            get { return _estimateFormPrtCd; }
            set { _estimateFormPrtCd = value; }
        }

        /// public propaty name  :  ContractDivCd
        /// <summary>�_��敪�v���p�e�B</summary>
        /// <value>0:���v��@1:�ꕔ�v��@2:�S�v��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ContractDivCd
        {
            get { return _contractDivCd; }
            set { _contractDivCd = value; }
        }

        /// public propaty name  :  EstimateSubject
        /// <summary>���ό����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ό����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateSubject
        {
            get { return _estimateSubject; }
            set { _estimateSubject = value; }
        }

        /// public propaty name  :  Footnotes1
        /// <summary>�r���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Footnotes1
        {
            get { return _footnotes1; }
            set { _footnotes1 = value; }
        }

        /// public propaty name  :  Footnotes2
        /// <summary>�r���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Footnotes2
        {
            get { return _footnotes2; }
            set { _footnotes2 = value; }
        }

        /// public propaty name  :  EstimateTitle1
        /// <summary>���σ^�C�g���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle1
        {
            get { return _estimateTitle1; }
            set { _estimateTitle1 = value; }
        }

        /// public propaty name  :  EstimateTitle2
        /// <summary>���σ^�C�g���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle2
        {
            get { return _estimateTitle2; }
            set { _estimateTitle2 = value; }
        }

        /// public propaty name  :  EstimateTitle3
        /// <summary>���σ^�C�g���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle3
        {
            get { return _estimateTitle3; }
            set { _estimateTitle3 = value; }
        }

        /// public propaty name  :  EstimateTitle4
        /// <summary>���σ^�C�g���S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle4
        {
            get { return _estimateTitle4; }
            set { _estimateTitle4 = value; }
        }

        /// public propaty name  :  EstimateTitle5
        /// <summary>���σ^�C�g���T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateTitle5
        {
            get { return _estimateTitle5; }
            set { _estimateTitle5 = value; }
        }

        /// public propaty name  :  EstimateNote1
        /// <summary>���ϔ��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote1
        {
            get { return _estimateNote1; }
            set { _estimateNote1 = value; }
        }

        /// public propaty name  :  EstimateNote2
        /// <summary>���ϔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote2
        {
            get { return _estimateNote2; }
            set { _estimateNote2 = value; }
        }

        /// public propaty name  :  EstimateNote3
        /// <summary>���ϔ��l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote3
        {
            get { return _estimateNote3; }
            set { _estimateNote3 = value; }
        }

        /// public propaty name  :  EstimateNote4
        /// <summary>���ϔ��l�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote4
        {
            get { return _estimateNote4; }
            set { _estimateNote4 = value; }
        }

        /// public propaty name  :  EstimateNote5
        /// <summary>���ϔ��l�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateNote5
        {
            get { return _estimateNote5; }
            set { _estimateNote5 = value; }
        }

        /// public propaty name  :  StockUpdateSecCd
        /// <summary>�݌ɍX�V���_�R�[�h�v���p�e�B</summary>
        /// <value>�蓮�ǉ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɍX�V���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockUpdateSecCd
        {
            get { return _stockUpdateSecCd; }
            set { _stockUpdateSecCd = value; }
        }


        /// <summary>
        /// ����f�[�^(�����Ǎ�)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesSlipNewEntryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipNewEntryWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlipNewEntryWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesSlipNewEntryWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesSlipNewEntryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesSlipNewEntryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipNewEntryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesSlipNewEntryWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesSlipNewEntryWork || graph is ArrayList || graph is SalesSlipNewEntryWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesSlipNewEntryWork).FullName));

            if (graph != null && graph is SalesSlipNewEntryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesSlipNewEntryWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesSlipNewEntryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesSlipNewEntryWork[])graph).Length;
            }
            else if (graph is SalesSlipNewEntryWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�ԍ��A���󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNLnkAcptAnOdr
            //�ԍ��A������`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //DebitNLnkSalesSlNum
            //����`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //���㏤�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //�T�[�r�X�`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ServiceSlipCd
            //������͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInpSecCd
            //�����v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DemandAddUpSecCd
            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //�`�[�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDate
            //�o�ד��t
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentDay
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DelayPaymentDiv
            //���Ϗ��ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //EstimateFormNo
            //���ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateDivide
            //������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //���z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //���z�\���|���K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDispRateApy
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxExc
            //���㏬�v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTaxInc
            //���㏬�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTaxExc
            //���㐳�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalseNetPrice
            //���㏬�v�i�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //����O�őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesOutTax
            //������őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesInTax
            //���㏬�v��ېőΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalSubttlSubToTaxFre
            //������z����Ŋz�i�O�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalseOutTax
            //������z����Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalAmntConsTaxInclu
            //����l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxExc
            //����l���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesDisOutTax
            //����l�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesDisInTax
            //����l����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalseDisTaxFre
            //����l������Ŋz�i�O�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisOutTax
            //����l������Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesDisTtlTaxInclu
            //�������z�v
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalCost
            //�T�[�r�X�a���
            serInfo.MemberInfo.Add(typeof(Int64)); //ServiceDeposits
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //����Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate
            //�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            //���|�����
            serInfo.MemberInfo.Add(typeof(Int64)); //AccRecConsTax
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //���������`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositSlipNo
            //�������v�z
            serInfo.MemberInfo.Add(typeof(Int64)); //DemandableTtl
            //�����������v�z
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAllowanceTtl
            //�a����������v�z
            serInfo.MemberInfo.Add(typeof(Int64)); //MnyDepoAllowanceTtl
            //���������c��
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAlwcBlnce
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�h��
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputNameCode
            //�`�[�Z���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipAddressDiv
            //�[�i��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //�[�i�於��
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //�[�i�於��2
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName2
            //�[�i��X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AddresseePostNo
            //�[�i��Z��1(�s���{���s��S�E�����E��)
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr1
            //�[�i��Z��2(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeAddr2
            //�[�i��Z��3(�Ԓn)
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr3
            //�[�i��Z��4(�A�p�[�g����)
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeAddr4
            //�[�i��d�b�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeTelNo
            //�[�i��FAX�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeFaxNo
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�`�[���l
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //�`�[���l�Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote2
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //�ԕi���R
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //���W������
            serInfo.MemberInfo.Add(typeof(Int32)); //RegiProcDate
            //���W�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //POS���V�[�g�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PosReceiptNo
            //����f�[�^�X�V�s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipUpdatable
            //���׍s��
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailRowCount
            //�d�c�h���M��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiSendDate
            //�d�c�h�捞��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiTakeInDate
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintDivCd
            //�`�[���s�ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintFinishCd
            //����`�[���s��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrintDate
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //�[�i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //DeliveredGoodsDivNm
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //�����t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //ReconcileFlag
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //�ꎮ�`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CompleteCd
            //������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimType
            //������z�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesPriceFracProcCd
            //�݌ɏ��i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockGoodsTtlTaxExc
            //�������i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add(typeof(Int64)); //PureGoodsTtlTaxExc
            //�艿����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPricePrintDiv
            //�����\���敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd1
            //���Ϗ���ŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimaTaxDivCd
            //���ύ��v����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateTotalPrtCd
            //���Ϗ�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateFormPrtCd
            //�_��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ContractDivCd
            //���ό���
            serInfo.MemberInfo.Add(typeof(string)); //EstimateSubject
            //�r���P
            serInfo.MemberInfo.Add(typeof(string)); //Footnotes1
            //�r���Q
            serInfo.MemberInfo.Add(typeof(string)); //Footnotes2
            //���σ^�C�g���P
            serInfo.MemberInfo.Add(typeof(string)); //EstimateTitle1
            //���σ^�C�g���Q
            serInfo.MemberInfo.Add(typeof(string)); //EstimateTitle2
            //���σ^�C�g���R
            serInfo.MemberInfo.Add(typeof(string)); //EstimateTitle3
            //���σ^�C�g���S
            serInfo.MemberInfo.Add(typeof(string)); //EstimateTitle4
            //���σ^�C�g���T
            serInfo.MemberInfo.Add(typeof(string)); //EstimateTitle5
            //���ϔ��l�P
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote1
            //���ϔ��l�Q
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote2
            //���ϔ��l�R
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote3
            //���ϔ��l�S
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote4
            //���ϔ��l�T
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote5
            //�݌ɍX�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockUpdateSecCd


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesSlipNewEntryWork)
            {
                SalesSlipNewEntryWork temp = (SalesSlipNewEntryWork)graph;

                SetSalesSlipNewEntryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesSlipNewEntryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesSlipNewEntryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesSlipNewEntryWork temp in lst)
                {
                    SetSalesSlipNewEntryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesSlipNewEntryWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 140;

        /// <summary>
        ///  SalesSlipNewEntryWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipNewEntryWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesSlipNewEntryWork(System.IO.BinaryWriter writer, SalesSlipNewEntryWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�ԍ��A���󒍔ԍ�
            writer.Write(temp.DebitNLnkAcptAnOdr);
            //�ԍ��A������`�[�ԍ�
            writer.Write(temp.DebitNLnkSalesSlNum);
            //����`�[�敪
            writer.Write(temp.SalesSlipCd);
            //���㏤�i�敪
            writer.Write(temp.SalesGoodsCd);
            //���|�敪
            writer.Write(temp.AccRecDivCd);
            //�T�[�r�X�`�[�敪
            writer.Write(temp.ServiceSlipCd);
            //������͋��_�R�[�h
            writer.Write(temp.SalesInpSecCd);
            //�����v�㋒�_�R�[�h
            writer.Write(temp.DemandAddUpSecCd);
            //���ьv�㋒�_�R�[�h
            writer.Write(temp.ResultsAddUpSecCd);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //�`�[�������t
            writer.Write((Int64)temp.SearchSlipDate.Ticks);
            //�o�ד��t
            writer.Write((Int64)temp.ShipmentDay.Ticks);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�����敪
            writer.Write(temp.DelayPaymentDiv);
            //���Ϗ��ԍ�
            writer.Write(temp.EstimateFormNo);
            //���ϋ敪
            writer.Write(temp.EstimateDivide);
            //������͎҃R�[�h
            writer.Write(temp.SalesInputCode);
            //������͎Җ���
            writer.Write(temp.SalesInputName);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //��t�]�ƈ�����
            writer.Write(temp.FrontEmployeeNm);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�̔��]�ƈ�����
            writer.Write(temp.SalesEmployeeNm);
            //���z�\�����@�敪
            writer.Write(temp.TotalAmountDispWayCd);
            //���z�\���|���K�p�敪
            writer.Write(temp.TtlAmntDispRateApy);
            //����`�[���v�i�ō��݁j
            writer.Write(temp.SalesTotalTaxInc);
            //����`�[���v�i�Ŕ����j
            writer.Write(temp.SalesTotalTaxExc);
            //���㏬�v�i�ō��݁j
            writer.Write(temp.SalesSubtotalTaxInc);
            //���㏬�v�i�Ŕ����j
            writer.Write(temp.SalesSubtotalTaxExc);
            //���㐳�����z
            writer.Write(temp.SalseNetPrice);
            //���㏬�v�i�Łj
            writer.Write(temp.SalesSubtotalTax);
            //����O�őΏۊz
            writer.Write(temp.ItdedSalesOutTax);
            //������őΏۊz
            writer.Write(temp.ItdedSalesInTax);
            //���㏬�v��ېőΏۊz
            writer.Write(temp.SalSubttlSubToTaxFre);
            //������z����Ŋz�i�O�Łj
            writer.Write(temp.SalseOutTax);
            //������z����Ŋz�i���Łj
            writer.Write(temp.SalAmntConsTaxInclu);
            //����l�����z�v�i�Ŕ����j
            writer.Write(temp.SalesDisTtlTaxExc);
            //����l���O�őΏۊz���v
            writer.Write(temp.ItdedSalesDisOutTax);
            //����l�����őΏۊz���v
            writer.Write(temp.ItdedSalesDisInTax);
            //����l����ېőΏۊz���v
            writer.Write(temp.ItdedSalseDisTaxFre);
            //����l������Ŋz�i�O�Łj
            writer.Write(temp.SalesDisOutTax);
            //����l������Ŋz�i���Łj
            writer.Write(temp.SalesDisTtlTaxInclu);
            //�������z�v
            writer.Write(temp.TotalCost);
            //�T�[�r�X�a���
            writer.Write(temp.ServiceDeposits);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //����Őŗ�
            writer.Write(temp.ConsTaxRate);
            //�[�������敪
            writer.Write(temp.FractionProcCd);
            //���|�����
            writer.Write(temp.AccRecConsTax);
            //���������敪
            writer.Write(temp.AutoDepositCd);
            //���������`�[�ԍ�
            writer.Write(temp.AutoDepositSlipNo);
            //�������v�z
            writer.Write(temp.DemandableTtl);
            //�����������v�z
            writer.Write(temp.DepositAllowanceTtl);
            //�a����������v�z
            writer.Write(temp.MnyDepoAllowanceTtl);
            //���������c��
            writer.Write(temp.DepositAlwcBlnce);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�h��
            writer.Write(temp.HonorificTitle);
            //�����R�[�h
            writer.Write(temp.OutputNameCode);
            //�`�[�Z���敪
            writer.Write(temp.SlipAddressDiv);
            //�[�i��R�[�h
            writer.Write(temp.AddresseeCode);
            //�[�i�於��
            writer.Write(temp.AddresseeName);
            //�[�i�於��2
            writer.Write(temp.AddresseeName2);
            //�[�i��X�֔ԍ�
            writer.Write(temp.AddresseePostNo);
            //�[�i��Z��1(�s���{���s��S�E�����E��)
            writer.Write(temp.AddresseeAddr1);
            //�[�i��Z��2(����)
            writer.Write(temp.AddresseeAddr2);
            //�[�i��Z��3(�Ԓn)
            writer.Write(temp.AddresseeAddr3);
            //�[�i��Z��4(�A�p�[�g����)
            writer.Write(temp.AddresseeAddr4);
            //�[�i��d�b�ԍ�
            writer.Write(temp.AddresseeTelNo);
            //�[�i��FAX�ԍ�
            writer.Write(temp.AddresseeFaxNo);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�`�[���l
            writer.Write(temp.SlipNote);
            //�`�[���l�Q
            writer.Write(temp.SlipNote2);
            //�ԕi���R�R�[�h
            writer.Write(temp.RetGoodsReasonDiv);
            //�ԕi���R
            writer.Write(temp.RetGoodsReason);
            //���W������
            writer.Write((Int64)temp.RegiProcDate.Ticks);
            //���W�ԍ�
            writer.Write(temp.CashRegisterNo);
            //POS���V�[�g�ԍ�
            writer.Write(temp.PosReceiptNo);
            //����f�[�^�X�V�s�敪
            writer.Write(temp.SalesSlipUpdatable);
            //���׍s��
            writer.Write(temp.DetailRowCount);
            //�d�c�h���M��
            writer.Write((Int64)temp.EdiSendDate.Ticks);
            //�d�c�h�捞��
            writer.Write((Int64)temp.EdiTakeInDate.Ticks);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //�`�[���s�敪
            writer.Write(temp.SlipPrintDivCd);
            //�`�[���s�ϋ敪
            writer.Write(temp.SlipPrintFinishCd);
            //����`�[���s��
            writer.Write((Int64)temp.SalesSlipPrintDate.Ticks);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��
            writer.Write(temp.BusinessTypeName);
            //�����ԍ�
            writer.Write(temp.OrderNumber);
            //�[�i�敪
            writer.Write(temp.DeliveredGoodsDiv);
            //�[�i�敪����
            writer.Write(temp.DeliveredGoodsDivNm);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //�����t���O
            writer.Write(temp.ReconcileFlag);
            //�`�[����ݒ�p���[ID
            writer.Write(temp.SlipPrtSetPaperId);
            //�ꎮ�`�[�敪
            writer.Write(temp.CompleteCd);
            //������敪
            writer.Write(temp.ClaimType);
            //������z�[�������敪
            writer.Write(temp.SalesPriceFracProcCd);
            //�݌ɏ��i���v���z�i�Ŕ��j
            writer.Write(temp.StockGoodsTtlTaxExc);
            //�������i���v���z�i�Ŕ��j
            writer.Write(temp.PureGoodsTtlTaxExc);
            //�艿����敪
            writer.Write(temp.ListPricePrintDiv);
            //�����\���敪�P
            writer.Write(temp.EraNameDispCd1);
            //���Ϗ���ŋ敪
            writer.Write(temp.EstimaTaxDivCd);
            //���ύ��v����敪
            writer.Write(temp.EstimateTotalPrtCd);
            //���Ϗ�����敪
            writer.Write(temp.EstimateFormPrtCd);
            //�_��敪
            writer.Write(temp.ContractDivCd);
            //���ό���
            writer.Write(temp.EstimateSubject);
            //�r���P
            writer.Write(temp.Footnotes1);
            //�r���Q
            writer.Write(temp.Footnotes2);
            //���σ^�C�g���P
            writer.Write(temp.EstimateTitle1);
            //���σ^�C�g���Q
            writer.Write(temp.EstimateTitle2);
            //���σ^�C�g���R
            writer.Write(temp.EstimateTitle3);
            //���σ^�C�g���S
            writer.Write(temp.EstimateTitle4);
            //���σ^�C�g���T
            writer.Write(temp.EstimateTitle5);
            //���ϔ��l�P
            writer.Write(temp.EstimateNote1);
            //���ϔ��l�Q
            writer.Write(temp.EstimateNote2);
            //���ϔ��l�R
            writer.Write(temp.EstimateNote3);
            //���ϔ��l�S
            writer.Write(temp.EstimateNote4);
            //���ϔ��l�T
            writer.Write(temp.EstimateNote5);
            //�݌ɍX�V���_�R�[�h
            writer.Write(temp.StockUpdateSecCd);

        }

        /// <summary>
        ///  SalesSlipNewEntryWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesSlipNewEntryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipNewEntryWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesSlipNewEntryWork GetSalesSlipNewEntryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesSlipNewEntryWork temp = new SalesSlipNewEntryWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�ԍ��A���󒍔ԍ�
            temp.DebitNLnkAcptAnOdr = reader.ReadInt32();
            //�ԍ��A������`�[�ԍ�
            temp.DebitNLnkSalesSlNum = reader.ReadString();
            //����`�[�敪
            temp.SalesSlipCd = reader.ReadInt32();
            //���㏤�i�敪
            temp.SalesGoodsCd = reader.ReadInt32();
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //�T�[�r�X�`�[�敪
            temp.ServiceSlipCd = reader.ReadInt32();
            //������͋��_�R�[�h
            temp.SalesInpSecCd = reader.ReadString();
            //�����v�㋒�_�R�[�h
            temp.DemandAddUpSecCd = reader.ReadString();
            //���ьv�㋒�_�R�[�h
            temp.ResultsAddUpSecCd = reader.ReadString();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //�`�[�������t
            temp.SearchSlipDate = new DateTime(reader.ReadInt64());
            //�o�ד��t
            temp.ShipmentDay = new DateTime(reader.ReadInt64());
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�����敪
            temp.DelayPaymentDiv = reader.ReadInt32();
            //���Ϗ��ԍ�
            temp.EstimateFormNo = reader.ReadString();
            //���ϋ敪
            temp.EstimateDivide = reader.ReadInt32();
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //������͎Җ���
            temp.SalesInputName = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //��t�]�ƈ�����
            temp.FrontEmployeeNm = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SalesEmployeeNm = reader.ReadString();
            //���z�\�����@�敪
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //���z�\���|���K�p�敪
            temp.TtlAmntDispRateApy = reader.ReadInt32();
            //����`�[���v�i�ō��݁j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //����`�[���v�i�Ŕ����j
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //���㏬�v�i�ō��݁j
            temp.SalesSubtotalTaxInc = reader.ReadInt64();
            //���㏬�v�i�Ŕ����j
            temp.SalesSubtotalTaxExc = reader.ReadInt64();
            //���㐳�����z
            temp.SalseNetPrice = reader.ReadInt64();
            //���㏬�v�i�Łj
            temp.SalesSubtotalTax = reader.ReadInt64();
            //����O�őΏۊz
            temp.ItdedSalesOutTax = reader.ReadInt64();
            //������őΏۊz
            temp.ItdedSalesInTax = reader.ReadInt64();
            //���㏬�v��ېőΏۊz
            temp.SalSubttlSubToTaxFre = reader.ReadInt64();
            //������z����Ŋz�i�O�Łj
            temp.SalseOutTax = reader.ReadInt64();
            //������z����Ŋz�i���Łj
            temp.SalAmntConsTaxInclu = reader.ReadInt64();
            //����l�����z�v�i�Ŕ����j
            temp.SalesDisTtlTaxExc = reader.ReadInt64();
            //����l���O�őΏۊz���v
            temp.ItdedSalesDisOutTax = reader.ReadInt64();
            //����l�����őΏۊz���v
            temp.ItdedSalesDisInTax = reader.ReadInt64();
            //����l����ېőΏۊz���v
            temp.ItdedSalseDisTaxFre = reader.ReadInt64();
            //����l������Ŋz�i�O�Łj
            temp.SalesDisOutTax = reader.ReadInt64();
            //����l������Ŋz�i���Łj
            temp.SalesDisTtlTaxInclu = reader.ReadInt64();
            //�������z�v
            temp.TotalCost = reader.ReadInt64();
            //�T�[�r�X�a���
            temp.ServiceDeposits = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //����Őŗ�
            temp.ConsTaxRate = reader.ReadDouble();
            //�[�������敪
            temp.FractionProcCd = reader.ReadInt32();
            //���|�����
            temp.AccRecConsTax = reader.ReadInt64();
            //���������敪
            temp.AutoDepositCd = reader.ReadInt32();
            //���������`�[�ԍ�
            temp.AutoDepositSlipNo = reader.ReadInt32();
            //�������v�z
            temp.DemandableTtl = reader.ReadInt64();
            //�����������v�z
            temp.DepositAllowanceTtl = reader.ReadInt64();
            //�a����������v�z
            temp.MnyDepoAllowanceTtl = reader.ReadInt64();
            //���������c��
            temp.DepositAlwcBlnce = reader.ReadInt64();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�h��
            temp.HonorificTitle = reader.ReadString();
            //�����R�[�h
            temp.OutputNameCode = reader.ReadInt32();
            //�`�[�Z���敪
            temp.SlipAddressDiv = reader.ReadInt32();
            //�[�i��R�[�h
            temp.AddresseeCode = reader.ReadInt32();
            //�[�i�於��
            temp.AddresseeName = reader.ReadString();
            //�[�i�於��2
            temp.AddresseeName2 = reader.ReadString();
            //�[�i��X�֔ԍ�
            temp.AddresseePostNo = reader.ReadString();
            //�[�i��Z��1(�s���{���s��S�E�����E��)
            temp.AddresseeAddr1 = reader.ReadString();
            //�[�i��Z��2(����)
            temp.AddresseeAddr2 = reader.ReadInt32();
            //�[�i��Z��3(�Ԓn)
            temp.AddresseeAddr3 = reader.ReadString();
            //�[�i��Z��4(�A�p�[�g����)
            temp.AddresseeAddr4 = reader.ReadString();
            //�[�i��d�b�ԍ�
            temp.AddresseeTelNo = reader.ReadString();
            //�[�i��FAX�ԍ�
            temp.AddresseeFaxNo = reader.ReadString();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�`�[���l
            temp.SlipNote = reader.ReadString();
            //�`�[���l�Q
            temp.SlipNote2 = reader.ReadString();
            //�ԕi���R�R�[�h
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //�ԕi���R
            temp.RetGoodsReason = reader.ReadString();
            //���W������
            temp.RegiProcDate = new DateTime(reader.ReadInt64());
            //���W�ԍ�
            temp.CashRegisterNo = reader.ReadInt32();
            //POS���V�[�g�ԍ�
            temp.PosReceiptNo = reader.ReadInt32();
            //����f�[�^�X�V�s�敪
            temp.SalesSlipUpdatable = reader.ReadInt32();
            //���׍s��
            temp.DetailRowCount = reader.ReadInt32();
            //�d�c�h���M��
            temp.EdiSendDate = new DateTime(reader.ReadInt64());
            //�d�c�h�捞��
            temp.EdiTakeInDate = new DateTime(reader.ReadInt64());
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�`�[���s�敪
            temp.SlipPrintDivCd = reader.ReadInt32();
            //�`�[���s�ϋ敪
            temp.SlipPrintFinishCd = reader.ReadInt32();
            //����`�[���s��
            temp.SalesSlipPrintDate = new DateTime(reader.ReadInt64());
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��
            temp.BusinessTypeName = reader.ReadString();
            //�����ԍ�
            temp.OrderNumber = reader.ReadString();
            //�[�i�敪
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //�[�i�敪����
            temp.DeliveredGoodsDivNm = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //�����t���O
            temp.ReconcileFlag = reader.ReadInt32();
            //�`�[����ݒ�p���[ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //�ꎮ�`�[�敪
            temp.CompleteCd = reader.ReadInt32();
            //������敪
            temp.ClaimType = reader.ReadInt32();
            //������z�[�������敪
            temp.SalesPriceFracProcCd = reader.ReadInt32();
            //�݌ɏ��i���v���z�i�Ŕ��j
            temp.StockGoodsTtlTaxExc = reader.ReadInt64();
            //�������i���v���z�i�Ŕ��j
            temp.PureGoodsTtlTaxExc = reader.ReadInt64();
            //�艿����敪
            temp.ListPricePrintDiv = reader.ReadInt32();
            //�����\���敪�P
            temp.EraNameDispCd1 = reader.ReadInt32();
            //���Ϗ���ŋ敪
            temp.EstimaTaxDivCd = reader.ReadInt32();
            //���ύ��v����敪
            temp.EstimateTotalPrtCd = reader.ReadInt32();
            //���Ϗ�����敪
            temp.EstimateFormPrtCd = reader.ReadInt32();
            //�_��敪
            temp.ContractDivCd = reader.ReadInt32();
            //���ό���
            temp.EstimateSubject = reader.ReadString();
            //�r���P
            temp.Footnotes1 = reader.ReadString();
            //�r���Q
            temp.Footnotes2 = reader.ReadString();
            //���σ^�C�g���P
            temp.EstimateTitle1 = reader.ReadString();
            //���σ^�C�g���Q
            temp.EstimateTitle2 = reader.ReadString();
            //���σ^�C�g���R
            temp.EstimateTitle3 = reader.ReadString();
            //���σ^�C�g���S
            temp.EstimateTitle4 = reader.ReadString();
            //���σ^�C�g���T
            temp.EstimateTitle5 = reader.ReadString();
            //���ϔ��l�P
            temp.EstimateNote1 = reader.ReadString();
            //���ϔ��l�Q
            temp.EstimateNote2 = reader.ReadString();
            //���ϔ��l�R
            temp.EstimateNote3 = reader.ReadString();
            //���ϔ��l�S
            temp.EstimateNote4 = reader.ReadString();
            //���ϔ��l�T
            temp.EstimateNote5 = reader.ReadString();
            //�݌ɍX�V���_�R�[�h
            temp.StockUpdateSecCd = reader.ReadString();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SalesSlipNewEntryWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlipNewEntryWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesSlipNewEntryWork temp = GetSalesSlipNewEntryWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SalesSlipNewEntryWork[])lst.ToArray(typeof(SalesSlipNewEntryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
#endif
    # endregion
}
