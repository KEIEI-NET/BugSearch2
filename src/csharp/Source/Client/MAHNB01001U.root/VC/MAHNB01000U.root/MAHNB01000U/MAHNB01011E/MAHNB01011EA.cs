using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesSlip
    /// <summary>
    ///                      ����f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���X�y���~�X�C��</br>
    /// <br>                 :   ����l����ېőΏۊz���v</br>
    /// <br>                 :   ���㐳�����z</br>
    /// <br>                 :   ������z����Ŋz�i�O�Łj</br>
    /// <br>Update Note      :   2008/9/25  ���n</br>
    /// <br>                 :   ������f�[�^���C�A�E�g�ɑ΂��A�ȉ��̍��ڒǉ�</br>
    /// <br>                 :   ���̓��[�h�A����`�[�敪(��ʕ\���p)</br>
    /// <br>                 :   �󒍃X�e�[�^�X�A���Ӑ�|���O���[�v�R�[�h</br>
    /// <br>                 :   �����於�́@�����於�̂Q</br>
    /// <br>                 :   �^�M�Ǘ��敪�A�����A���񊨒�J�n��</br>
    /// <br>                 :   �e���v�Z�p������z</br>
    /// <br>                 :   ���_���́A���喼�́A�ԗ��Ǘ��敪</br>
    /// <br>                 :   ���i�������[�h�A�ԗ��������[�h</br>
    /// <br>                 :   ������(�������ϗp)�A���σf�[�^�쐬�敪(�������ϗp)</br>
    /// <br>                 :   ���Ӑ撍�ԕ\���敪�A���Ӑ�D��q�ɃR�[�h�A������~��</br>
    /// <br>Update Note  : 2009/09/08 ���M</br>
    /// <br>               PM.NS-2-A�E���q�Ǘ�</br>
    /// <br>               ���q�Ǘ��@�\�̒ǉ�</br>
    /// <br>Update Note : 2009/12/17 ���n ��� �ێ�˗��B�Ή�</br>
    /// <br>             MANTIS[14756] �����C�����A�`�[�^�C�v�̖��א��ɏ]�����א��𐧌�����</br>
    /// <br>Update Note :  2009/12/23 ���M</br>
    /// <br>               PM.NS-5-A�EPM.NS�ێ�˗��C</br>
    /// <br>               PM.NS�ێ�˗��C��ǉ�</br>
    /// <br>Update Note :  2010/01/27 ���M</br>
    /// <br>               PM.NS�ێ�˗��S�����ǑΉ���ǉ�</br>
    /// <br>               �݌ɏ��X�Vfalg��ǉ�</br>
    /// <br>Update Note :  2010/02/26 ���n ��� </br>
    /// <br>               SCM�Ή�</br>
    /// <br>Update Note :  2010/04/08 ���n ��� </br>
    /// <br>               SCM�Ή�</br>
    /// <br>Update Note :  2011/07/18 ���R </br>
    /// <br>               �񓚋敪�̒ǉ�</br>
    /// <br>Update Note :  2011/12/15 tianjw</br>
    /// <br>               Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note :  2013/01/18 �c����</br>
    /// <br>�Ǘ��ԍ�    :  10806793-00 2013/03/13�z�M��</br>
    /// <br>            :  Redmine#33797 �����������l�敪�̒ǉ�</br>
    /// </remarks>
    public class SalesSlip
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

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

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

        /// <summary>����`�[�X�V�敪</summary>
        /// <remarks>0:���X�V,1:�X�V����</remarks>
        private Int32 _salesSlipUpdateCd;

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _searchSlipDate;

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        // ----- ADD 2011/12/15 ------------------->>>>>
        /// <summary>�O�񔄏���t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _preSalesDate;
        // ----- ADD 2011/12/15 -------------------<<<<<

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>�����敪</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private Int32 _delayPaymentDiv;

        /// <summary>���Ϗ��ԍ�</summary>
        private string _estimateFormNo = "";

        /// <summary>���ϋ敪</summary>
        /// <remarks>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</remarks>
        private Int32 _estimateDivide;

        /// <summary>���͒S���҃R�[�h</summary>
        /// <remarks>���O�C���S���ҁi�t�r�a�j</remarks>
        private string _inputAgenCd = "";

        /// <summary>���͒S���Җ���</summary>
        private string _inputAgenNm = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>������͎Җ���</summary>
        private string _salesInputName = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
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
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>���㕔�i���v�i�ō��݁j</summary>
        /// <remarks>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</remarks>
        private Int64 _salesPrtTotalTaxInc;

        /// <summary>���㕔�i���v�i�Ŕ����j</summary>
        /// <remarks>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</remarks>
        private Int64 _salesPrtTotalTaxExc;

        /// <summary>�����ƍ��v�i�ō��݁j</summary>
        /// <remarks>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</remarks>
        private Int64 _salesWorkTotalTaxInc;

        /// <summary>�����ƍ��v�i�Ŕ����j</summary>
        /// <remarks>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</remarks>
        private Int64 _salesWorkTotalTaxExc;

        /// <summary>���㏬�v�i�ō��݁j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _salesSubtotalTaxInc;

        /// <summary>���㏬�v�i�Ŕ����j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _salesSubtotalTaxExc;

        /// <summary>���㕔�i���v�i�ō��݁j</summary>
        /// <remarks>���i���׋��z�̐ō����v</remarks>
        private Int64 _salesPrtSubttlInc;

        /// <summary>���㕔�i���v�i�Ŕ����j</summary>
        /// <remarks>���i���׋��z�̐Ŕ����v</remarks>
        private Int64 _salesPrtSubttlExc;

        /// <summary>�����Ə��v�i�ō��݁j</summary>
        /// <remarks>��Ɩ��׋��z�̐ō����v</remarks>
        private Int64 _salesWorkSubttlInc;

        /// <summary>�����Ə��v�i�Ŕ����j</summary>
        /// <remarks>��Ɩ��׋��z�̐Ŕ����v</remarks>
        private Int64 _salesWorkSubttlExc;

        /// <summary>���㐳�����z</summary>
        /// <remarks>�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j</remarks>
        private Int64 _salesNetPrice;

        /// <summary>���㏬�v�i�Łj</summary>
        /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
        private Int64 _salesSubtotalTax;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>������őΏۊz</summary>
        /// <remarks>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>���㏬�v��ېőΏۊz</summary>
        /// <remarks>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</remarks>
        private Int64 _salSubttlSubToTaxFre;

        /// <summary>������z����Ŋz�i�O�Łj</summary>
        /// <remarks>�l���O�̊O�ŏ��i�̏����</remarks>
        private Int64 _salesOutTax;

        /// <summary>������z����Ŋz�i���Łj</summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _salAmntConsTaxInclu;

        /// <summary>����l�����z�v�i�Ŕ����j</summary>
        private Int64 _salesDisTtlTaxExc;

        /// <summary>����l���O�őΏۊz���v</summary>
        /// <remarks>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedSalesDisOutTax;

        /// <summary>����l�����őΏۊz���v</summary>
        /// <remarks>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</remarks>
        private Int64 _itdedSalesDisInTax;

        /// <summary>���i�l���Ώۊz���v�i�Ŕ����j</summary>
        /// <remarks>���i�l���z�i�Ŕ����j</remarks>
        private Int64 _itdedPartsDisOutTax;

        /// <summary>���i�l���Ώۊz���v�i�ō��݁j</summary>
        /// <remarks>���i�l���z�i�ō��݁j</remarks>
        private Int64 _itdedPartsDisInTax;

        /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j</summary>
        /// <remarks>��ƒl���z�i�Ŕ����j</remarks>
        private Int64 _itdedWorkDisOutTax;

        /// <summary>��ƒl���Ώۊz���v�i�ō��݁j</summary>
        /// <remarks>��ƒl���z�i�ō��݁j</remarks>
        private Int64 _itdedWorkDisInTax;

        /// <summary>����l����ېőΏۊz���v</summary>
        /// <remarks>��ېŏ��i�l���̔�ېőΏۊz</remarks>
        private Int64 _itdedSalesDisTaxFre;

        /// <summary>����l������Ŋz�i�O�Łj</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _salesDisOutTax;

        /// <summary>����l������Ŋz�i���Łj</summary>
        private Int64 _salesDisTtlTaxInclu;

        /// <summary>���i�l����</summary>
        /// <remarks>���v�ɑ΂��Ă̕��i�l����</remarks>
        private Double _partsDiscountRate;

        /// <summary>�H���l����</summary>
        /// <remarks>���v�ɑ΂��Ă̍H���l����</remarks>
        private Double _ravorDiscountRate;

        /// <summary>�������z�v</summary>
        private Int64 _totalCost;

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

        //----- ADD 2013/01/18 �c���� Redmine#33797 ----->>>>>
        /// <summary>�����������l�敪</summary>
        /// <remarks>0:����`�[�ԍ� 1:����`�[���l 2:����</remarks>
        private Int32 _autoDepositNoteDiv;
        //----- ADD 2013/01/18 �c���� Redmine#33797 -----<<<<<

        /// <summary>���������`�[�ԍ�</summary>
        /// <remarks>�����������̓����`�[�ԍ�</remarks>
        private Int32 _autoDepositSlipNo;

        /// <summary>�����������v�z</summary>
        /// <remarks>�a����������v�z���܂�</remarks>
        private Int64 _depositAllowanceTtl;

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

        /// <summary>��������</summary>
        private string _outputName = "";

        /// <summary>���Ӑ�`�[�ԍ�</summary>
        private Int32 _custSlipNo;

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
        /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
        private string _partySaleSlipNum = "";

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>���q���l</summary>
        private string _carSlipNote = "";

        /// <summary>���s����</summary>
        private string _mileage = "";

        // --- ADD 2009/09/08 ----------<<<<<

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        private string _slipNote3 = "";

        // --- ADD 2009/12/23 ---------->>>>>

        /// <summary>�`�[���l�R�[�h</summary>
        private Int32 _slipNoteCode;

        /// <summary>�`�[���l�Q�R�[�h</summary>
        private Int32 _slipNote2Code;

        /// <summary>�`�[���l�R�R�[�h</summary>
        private Int32 _slipNote3Code;

        // --- ADD 2009/12/23 ----------<<<<<

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

        /// <summary>���Ϗ�����敪</summary>
        private Int32 _estimateFormPrtCd;

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

        /// <summary>���ϗL������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _estimateValidityDate;

        /// <summary>�i�Ԉ󎚋敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _partsNoPrtCd;

        /// <summary>�I�v�V�����󎚋敪</summary>
        /// <remarks>0:���Ȃ�,1:����</remarks>
        private Int32 _optionPringDivCd;

        /// <summary>�|���g�p�敪</summary>
        /// <remarks>0:�������艿 1:�|���w��,2:�|���ݒ�</remarks>
        private Int32 _rateUseCode;

        /// <summary>���̓��[�h</summary>
        /// <remarks>0:�ʏ���̓��[�h 1:�ԕi���̓��[�h 2:�ԓ`���̓��[�h</remarks>
        private Int32 _inputMode;

        /// <summary>����`�[�敪(��ʕ\���p)</summary>
        /// <remarks>10:�|���� 20:�|�ԕi 30:�������� 40:�����ԕi</remarks>
        private Int32 _salesSlipDisplay;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatusDisplay;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>�����於��</summary>
        /// <remarks>�������Ӑ於��</remarks>
        private string _claimName = "";

        /// <summary>�����於�̂Q</summary>
        /// <remarks>�������Ӑ於�̂Q</remarks>
        private string _claimName2 = "";

        /// <summary>�^�M�Ǘ��敪</summary>
        private Int32 _creditMngCode;

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>���񊨒�J�n��</summary>
        /// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>�e���v�Z�p������z</summary>
        private Int64 _totalMoneyForGrossProfit;

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>���喼��</summary>
        private string _subSectionName = "";

        /// <summary>���q�Ǘ��敪</summary>
        /// <remarks>0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��</remarks>
        private Int32 _carMngDivCd;

        /// <summary>���i�������[�h</summary>
        /// <remarks>0:�i�Ԍ����A1:BL�R�[�h����</remarks>
        private Int32 _searchMode;

        /// <summary>�ԗ��������[�h</summary>
        /// <remarks>0:�^�������A1:���f���v���[�g����</remarks>
        private Int32 _searchCarMode;

        /// <summary>������</summary>
        /// <remarks>���������ϗp</remarks>
        private Double _salesRate;

        /// <summary>���σf�[�^�쐬�敪</summary>
        /// <remarks>���������ϗp</remarks>
        private Int32 _estimateDtCreateDiv;

        /// <summary>���Ӑ撍�ԕ\���敪</summary>
        /// <remarks>0:���Ȃ��@1:����i���Ӑ�}�X�^ 0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����j</remarks>
        private Int32 _custOrderNoDispDiv;

        /// <summary>���Ӑ�D��q�ɃR�[�h</summary>
        private string _custWarehouseCd = "";

        /// <summary>������~��</summary>
        private DateTime _transStopDate;

        //>>>2010/02/26
        /// <summary>�I�����C����ʋ敪</summary>
        /// <remarks>0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</remarks>
        private Int32 _onlineKindDiv;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�񓚋敪</summary>
        /// <remarks>0:�ʏ� 1:�S��</remarks>
        private Int32 _answerDiv;

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;
        //<<<2010/02/26
        //>>>2010/04/08
        /// <summary>�⍇���E�������</summary>
        private Int32 _inqOrdDivCd;
        //<<<2010/04/08

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>���ьv�㋒�_����</summary>
        private string _resultsAddUpSecNm = "";

        // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>���׍s��</summary>
        private Int32 _detailRowCountForReadSlip;
        // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ---------------------- ADD START 2011/07/18 ���R ----------------->>>>>
        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>1:�ʏ�(PCC�A�g�Ȃ�)�A2:�蓮�񓚁A3:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪(SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        // ---------------------- ADD END   2011.02.09 ���R -----------------<<<<<
        // --- ADD 2010/01/27 -------------->>>>>
        /// <summary>�݌ɏ��X�V���f</summary>
        private bool _stockUpdateFlag�@= false;
        // --- ADD 2010/01/27 --------------<<<<<

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  SalesSlipUpdateCd
        /// <summary>����`�[�X�V�敪�v���p�e�B</summary>
        /// <value>0:���X�V,1:�X�V����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipUpdateCd
        {
            get { return _salesSlipUpdateCd; }
            set { _salesSlipUpdateCd = value; }
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

        /// public propaty name  :  SearchSlipDateJpFormal
        /// <summary>�`�[�������t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateJpInFormal
        /// <summary>�`�[�������t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateAdFormal
        /// <summary>�`�[�������t ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _searchSlipDate); }
            set { }
        }

        /// public propaty name  :  SearchSlipDateAdInFormal
        /// <summary>�`�[�������t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchSlipDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _searchSlipDate); }
            set { }
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

        /// public propaty name  :  ShipmentDayJpFormal
        /// <summary>�o�ד��t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayJpInFormal
        /// <summary>�o�ד��t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdFormal
        /// <summary>�o�ד��t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdInFormal
        /// <summary>�o�ד��t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay); }
            set { }
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

        // ----- ADD 2011/12/15 ------------------->>>>>
        /// public propaty name  :  PreSalesDate
        /// <summary>�O�񔄏���t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񔄏���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PreSalesDate
        {
            get { return _preSalesDate; }
            set { _preSalesDate = value; }
        }
        // ----- ADD 2011/12/15 -------------------<<<<<

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>������t �a��v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>������t �a��(��)�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>������t ����v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>������t ����(��)�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
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

        /// public propaty name  :  AddUpADateJpFormal
        /// <summary>�v����t �a��v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateJpInFormal
        /// <summary>�v����t �a��(��)�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdFormal
        /// <summary>�v����t ����v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdInFormal
        /// <summary>�v����t ����(��)�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
            set { }
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
        /// <value>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</value>
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

        /// public propaty name  :  InputAgenCd
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// <value>���O�C���S���ҁi�t�r�a�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  InputAgenNm
        /// <summary>���͒S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenNm
        {
            get { return _inputAgenNm; }
            set { _inputAgenNm = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
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
        /// <value>��t�S���ҁi�󒍎ҁj</value>
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
        /// <value>�v��S���ҁi�S���ҁj</value>
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
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
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
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
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

        /// public propaty name  :  SalesPrtTotalTaxInc
        /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtTotalTaxInc
        {
            get { return _salesPrtTotalTaxInc; }
            set { _salesPrtTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPrtTotalTaxExc
        /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtTotalTaxExc
        {
            get { return _salesPrtTotalTaxExc; }
            set { _salesPrtTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesWorkTotalTaxInc
        /// <summary>�����ƍ��v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ƍ��v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkTotalTaxInc
        {
            get { return _salesWorkTotalTaxInc; }
            set { _salesWorkTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesWorkTotalTaxExc
        /// <summary>�����ƍ��v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ƍ��v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkTotalTaxExc
        {
            get { return _salesWorkTotalTaxExc; }
            set { _salesWorkTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesSubtotalTaxInc
        /// <summary>���㏬�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
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
        /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
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

        /// public propaty name  :  SalesPrtSubttlInc
        /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���i���׋��z�̐ō����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtSubttlInc
        {
            get { return _salesPrtSubttlInc; }
            set { _salesPrtSubttlInc = value; }
        }

        /// public propaty name  :  SalesPrtSubttlExc
        /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���i���׋��z�̐Ŕ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrtSubttlExc
        {
            get { return _salesPrtSubttlExc; }
            set { _salesPrtSubttlExc = value; }
        }

        /// public propaty name  :  SalesWorkSubttlInc
        /// <summary>�����Ə��v�i�ō��݁j�v���p�e�B</summary>
        /// <value>��Ɩ��׋��z�̐ō����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ə��v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkSubttlInc
        {
            get { return _salesWorkSubttlInc; }
            set { _salesWorkSubttlInc = value; }
        }

        /// public propaty name  :  SalesWorkSubttlExc
        /// <summary>�����Ə��v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>��Ɩ��׋��z�̐Ŕ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ə��v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesWorkSubttlExc
        {
            get { return _salesWorkSubttlExc; }
            set { _salesWorkSubttlExc = value; }
        }

        /// public propaty name  :  SalesNetPrice
        /// <summary>���㐳�����z�v���p�e�B</summary>
        /// <value>�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐳�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesNetPrice
        {
            get { return _salesNetPrice; }
            set { _salesNetPrice = value; }
        }

        /// public propaty name  :  SalesSubtotalTax
        /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
        /// <value>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</value>
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
        /// <value>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </value>
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
        /// <value>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</value>
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
        /// <value>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</value>
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

        /// public propaty name  :  SalesOutTax
        /// <summary>������z����Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�l���O�̊O�ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesOutTax
        {
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
        }

        /// public propaty name  :  SalAmntConsTaxInclu
        /// <summary>������z����Ŋz�i���Łj�v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
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

        /// public propaty name  :  ItdedPartsDisOutTax
        /// <summary>���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���i�l���z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedPartsDisOutTax
        {
            get { return _itdedPartsDisOutTax; }
            set { _itdedPartsDisOutTax = value; }
        }

        /// public propaty name  :  ItdedPartsDisInTax
        /// <summary>���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���i�l���z�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedPartsDisInTax
        {
            get { return _itdedPartsDisInTax; }
            set { _itdedPartsDisInTax = value; }
        }

        /// public propaty name  :  ItdedWorkDisOutTax
        /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>��ƒl���z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedWorkDisOutTax
        {
            get { return _itdedWorkDisOutTax; }
            set { _itdedWorkDisOutTax = value; }
        }

        /// public propaty name  :  ItdedWorkDisInTax
        /// <summary>��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>��ƒl���z�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedWorkDisInTax
        {
            get { return _itdedWorkDisInTax; }
            set { _itdedWorkDisInTax = value; }
        }

        /// public propaty name  :  ItdedSalesDisTaxFre
        /// <summary>����l����ېőΏۊz���v�v���p�e�B</summary>
        /// <value>��ېŏ��i�l���̔�ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesDisTaxFre
        {
            get { return _itdedSalesDisTaxFre; }
            set { _itdedSalesDisTaxFre = value; }
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

        /// public propaty name  :  PartsDiscountRate
        /// <summary>���i�l�����v���p�e�B</summary>
        /// <value>���v�ɑ΂��Ă̕��i�l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PartsDiscountRate
        {
            get { return _partsDiscountRate; }
            set { _partsDiscountRate = value; }
        }

        /// public propaty name  :  RavorDiscountRate
        /// <summary>�H���l�����v���p�e�B</summary>
        /// <value>���v�ɑ΂��Ă̍H���l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �H���l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RavorDiscountRate
        {
            get { return _ravorDiscountRate; }
            set { _ravorDiscountRate = value; }
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

        //----- ADD 2013/01/18 �c���� Redmine#33797 ----->>>>>
        /// public propaty name  :  AutoDepositNoteDiv
        /// <summary>�����������l�敪�v���p�e�B</summary>
        /// <value>0:����`�[�ԍ� 1:����`�[���l 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositNoteDiv
        {
            get { return _autoDepositNoteDiv; }
            set { _autoDepositNoteDiv = value; }
        }
        //----- ADD 2013/01/18 �c���� Redmine#33797 -----<<<<<

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

        /// public propaty name  :  OutputName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
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
        /// <value>���Ӑ撍���ԍ��i���`�ԍ��j</value>
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

        // --- ADD 2009/09/08 ---------->>>>>

        /// public propaty name  :  CarSlipNote
        /// <summary>���q���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarSlipNote
        {
            get { return _carSlipNote; }
            set { _carSlipNote = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>���s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        // --- ADD 2009/09/08 ----------<<<<<

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

        /// public propaty name  :  SlipNote3
        /// <summary>�`�[���l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        // --- ADD 2009/12/23 ---------->>>>>
        /// public propaty name  :  SlipNoteCode
        /// <summary>�`�[���l�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNoteCode
        {
            get { return _slipNoteCode; }
            set { _slipNoteCode = value; }
        }

        /// public propaty name  :  SlipNote2Code
        /// <summary>�`�[���l�Q�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNote2Code
        {
            get { return _slipNote2Code; }
            set { _slipNote2Code = value; }
        }

        /// public propaty name  :  SlipNote3Code
        /// <summary>�`�[���l�R�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNote3Code
        {
            get { return _slipNote3Code; }
            set { _slipNote3Code = value; }
        }
        // --- ADD 2009/12/23 ----------<<<<<

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

        /// public propaty name  :  RegiProcDateJpFormal
        /// <summary>���W������ �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  RegiProcDateJpInFormal
        /// <summary>���W������ �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  RegiProcDateAdFormal
        /// <summary>���W������ ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _regiProcDate); }
            set { }
        }

        /// public propaty name  :  RegiProcDateAdInFormal
        /// <summary>���W������ ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W������ ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RegiProcDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _regiProcDate); }
            set { }
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

        /// public propaty name  :  EdiSendDateJpFormal
        /// <summary>�d�c�h���M�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateJpInFormal
        /// <summary>�d�c�h���M�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdFormal
        /// <summary>�d�c�h���M�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediSendDate); }
            set { }
        }

        /// public propaty name  :  EdiSendDateAdInFormal
        /// <summary>�d�c�h���M�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiSendDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediSendDate); }
            set { }
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

        /// public propaty name  :  EdiTakeInDateJpFormal
        /// <summary>�d�c�h�捞�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateJpInFormal
        /// <summary>�d�c�h�捞�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdFormal
        /// <summary>�d�c�h�捞�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ediTakeInDate); }
            set { }
        }

        /// public propaty name  :  EdiTakeInDateAdInFormal
        /// <summary>�d�c�h�捞�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdiTakeInDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ediTakeInDate); }
            set { }
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

        /// public propaty name  :  SalesSlipPrintDateJpFormal
        /// <summary>����`�[���s�� �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipPrintDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipPrintDateJpInFormal
        /// <summary>����`�[���s�� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipPrintDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipPrintDateAdFormal
        /// <summary>����`�[���s�� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipPrintDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesSlipPrintDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipPrintDateAdInFormal
        /// <summary>����`�[���s�� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipPrintDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesSlipPrintDate); }
            set { }
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

        /// public propaty name  :  EstimateValidityDate
        /// <summary>���ϗL�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EstimateValidityDate
        {
            get { return _estimateValidityDate; }
            set { _estimateValidityDate = value; }
        }

        /// public propaty name  :  EstimateValidityDateJpFormal
        /// <summary>���ϗL������ �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateJpInFormal
        /// <summary>���ϗL������ �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateAdFormal
        /// <summary>���ϗL������ ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  EstimateValidityDateAdInFormal
        /// <summary>���ϗL������ ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϗL������ ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstimateValidityDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _estimateValidityDate); }
            set { }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  OptionPringDivCd
        /// <summary>�I�v�V�����󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�v�V�����󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OptionPringDivCd
        {
            get { return _optionPringDivCd; }
            set { _optionPringDivCd = value; }
        }

        /// public propaty name  :  RateUseCode
        /// <summary>�|���g�p�敪�v���p�e�B</summary>
        /// <value>0:�������艿 1:�|���w��,2:�|���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateUseCode
        {
            get { return _rateUseCode; }
            set { _rateUseCode = value; }
        }

        /// public propaty name  :  InputMode
        /// <summary>���̓��[�h�v���p�e�B</summary>
        /// <value>0:�ʏ���̓��[�h 1:�ԕi���̓��[�h 2:�ԓ`���̓��[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̓��[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InputMode
        {
            get { return _inputMode; }
            set { _inputMode = value; }
        }

        /// public propaty name  :  SalesSlipDisplay
        /// <summary>����`�[�敪(��ʕ\���p)�v���p�e�B</summary>
        /// <value>10:�|���� 20:�|�ԕi 30:�������� 40:�����ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪(��ʕ\���p)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipDisplay
        {
            get { return _salesSlipDisplay; }
            set { _salesSlipDisplay = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusDisplay
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusDisplay
        {
            get { return _acptAnOdrStatusDisplay; }
            set { _acptAnOdrStatusDisplay = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// <value>�������Ӑ於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於�̂Q�v���p�e�B</summary>
        /// <value>�������Ӑ於�̂Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  CreditMngCode
        /// <summary>�^�M�Ǘ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>���񊨒�J�n���v���p�e�B</summary>
        /// <value>01�`31�܂Łi�ȗ��\�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  TotalMoneyForGrossProfit
        /// <summary>�e���v�Z�p������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���v�Z�p������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalMoneyForGrossProfit
        {
            get { return _totalMoneyForGrossProfit; }
            set { _totalMoneyForGrossProfit = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>���喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  CarMngDivCd
        /// <summary>���q�Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }

        /// public propaty name  :  SearchMode
        /// <summary>���i�������[�h�v���p�e�B</summary>
        /// <value>0:�i�Ԍ����A1:BL�R�[�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchMode
        {
            get { return _searchMode; }
            set { _searchMode = value; }
        }

        /// public propaty name  :  SearchCarMode
        /// <summary>�ԗ��������[�h�v���p�e�B</summary>
        /// <value>0:�^�������A1:���f���v���[�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��������[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchCarMode
        {
            get { return _searchCarMode; }
            set { _searchCarMode = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>�������v���p�e�B</summary>
        /// <value>���������ϗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  EstimateDtCreateDiv
        /// <summary>���σf�[�^�쐬�敪�v���p�e�B</summary>
        /// <value>���������ϗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^�쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateDtCreateDiv
        {
            get { return _estimateDtCreateDiv; }
            set { _estimateDtCreateDiv = value; }
        }

        /// public propaty name  :  CustOrderNoDispDiv
        /// <summary>���Ӑ撍�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����i���Ӑ�}�X�^ 0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ撍�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustOrderNoDispDiv
        {
            get { return _custOrderNoDispDiv; }
            set { _custOrderNoDispDiv = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>���Ӑ�D��q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�D��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  TransStopDate
        /// <summary>������~���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TransStopDate
        {
            get { return _transStopDate; }
            set { _transStopDate = value; }
        }

        /// public propaty name  :  TransStopDateJpFormal
        /// <summary>������~�� �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateJpInFormal
        /// <summary>������~�� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdFormal
        /// <summary>������~�� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdInFormal
        /// <summary>������~�� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������~�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransStopDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _transStopDate); }
            set { }
        }

        //>>>2010/02/26
        /// public propaty name  :  OnlineKindDiv
        /// <summary>�I�����C����ʋ敪�v���p�e�B</summary>
        /// <value>0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C����ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  AnswerDiv
        /// <summary>�񓚋敪�v���p�e�B</summary>
        /// <value>0:�ʏ� 1:�S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDiv
        {
            get { return _answerDiv; }
            set { _answerDiv = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }
        //<<<2010/02/26

        //>>>2010/04/08
        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }
        //<<<2010/04/08

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  ResultsAddUpSecNm
        /// <summary>���ьv�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecNm
        {
            get { return _resultsAddUpSecNm; }
            set { _resultsAddUpSecNm = value; }
        }

        // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  DetailRowCountForReadSlip
        /// <summary>���׍s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׍s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailRowCountForReadSlip
        {
            get { return _detailRowCountForReadSlip; }
            set { _detailRowCountForReadSlip = value; }
        }
        // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2010/01/27 -------------->>>>>
        /// public propaty name  :  StockUpdateFlag
        /// <summary>�݌ɏ��X�V���f�v���p�e�B(false: �X�V true:�X�V���Ȃ�)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ��X�V���f�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool StockUpdateFlag
        {
            get { return _stockUpdateFlag; }
            set { _stockUpdateFlag = value; }
        }
        // --- ADD 2010/01/27 --------------<<<<<

        /// <summary>
        /// ����f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>SalesSlip�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlip�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlip()
        {
        }

        /// <summary>
        /// ����f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
        /// <param name="salesSlipNum">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
        /// <param name="debitNLnkSalesSlNum">�ԍ��A������`�[�ԍ�(�ԍ��̑��������`�[�ԍ�)</param>
        /// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi)</param>
        /// <param name="salesGoodsCd">���㏤�i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����))</param>
        /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="salesInpSecCd">������͋��_�R�[�h(�����^ �������͂������_�R�[�h)</param>
        /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h(�����^)</param>
        /// <param name="resultsAddUpSecCd">���ьv�㋒�_�R�[�h(���ьv����s����Ɠ��̋��_�R�[�h)</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
        /// <param name="salesSlipUpdateCd">����`�[�X�V�敪(0:���X�V,1:�X�V����)</param>
        /// <param name="searchSlipDate">�`�[�������t(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="shipmentDay">�o�ד��t(YYYYMMDD)</param>
        /// <param name="salesDate">������t(���ϓ��A�󒍓��A����������˂�B(YYYYMMDD))</param>
        /// <param name="preSalesDate">�O�񔄏���t(���ϓ��A�󒍓��A����������˂�B(YYYYMMDD))</param> // ADD 2011/12/15
        /// <param name="addUpADate">�v����t(�������@(YYYYMMDD))</param>
        /// <param name="delayPaymentDiv">�����敪(0:����(�����Ȃ�),1:����,2:�ė����c9:9������)</param>
        /// <param name="estimateFormNo">���Ϗ��ԍ�</param>
        /// <param name="estimateDivide">���ϋ敪(1:�ʏ팩�ρ@2:�P�����ρ@3:��������)</param>
        /// <param name="inputAgenCd">���͒S���҃R�[�h(���O�C���S���ҁi�t�r�a�j)</param>
        /// <param name="inputAgenNm">���͒S���Җ���</param>
        /// <param name="salesInputCode">������͎҃R�[�h(���͒S���ҁi���s�ҁj)</param>
        /// <param name="salesInputName">������͎Җ���</param>
        /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(��t�S���ҁi�󒍎ҁj)</param>
        /// <param name="frontEmployeeNm">��t�]�ƈ�����</param>
        /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(�v��S���ҁi�S���ҁj)</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="ttlAmntDispRateApy">���z�\���|���K�p�敪(0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��)</param>
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��݁j(���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz)</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ����j(���㐳�����z�{����l�����z�v�i�Ŕ����j)</param>
        /// <param name="salesPrtTotalTaxInc">���㕔�i���v�i�ō��݁j(���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j)</param>
        /// <param name="salesPrtTotalTaxExc">���㕔�i���v�i�Ŕ����j(���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j)</param>
        /// <param name="salesWorkTotalTaxInc">�����ƍ��v�i�ō��݁j(�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j)</param>
        /// <param name="salesWorkTotalTaxExc">�����ƍ��v�i�Ŕ����j(�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j)</param>
        /// <param name="salesSubtotalTaxInc">���㏬�v�i�ō��݁j(�l����̖��׋��z�̍��v�i��ېŊ܂܂��j)</param>
        /// <param name="salesSubtotalTaxExc">���㏬�v�i�Ŕ����j(�l����̖��׋��z�̍��v�i��ېŊ܂܂��j)</param>
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��݁j(���i���׋��z�̐ō����v)</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ����j(���i���׋��z�̐Ŕ����v)</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��݁j(��Ɩ��׋��z�̐ō����v)</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ����j(��Ɩ��׋��z�̐Ŕ����v)</param>
        /// <param name="salesNetPrice">���㐳�����z(�l���O�̐Ŕ�������z�i�O�ŕ��A���ŕ��A��ېŕ��̍��v�j)</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj(�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j)</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz(���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j )</param>
        /// <param name="itdedSalesInTax">������őΏۊz(��ېőΏۋ��z�̏W�v�i�l���܂܂��j)</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz(������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�)</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj(�l���O�̊O�ŏ��i�̏����)</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj(�l���O�̓��ŏ��i�̏����)</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ����j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v(�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j)</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v(���ŏ��i�l���̓��őΏۊz�i�Ŕ��j)</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ����j(���i�l���z�i�Ŕ����j)</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��݁j(���i�l���z�i�ō��݁j)</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ����j(��ƒl���z�i�Ŕ����j)</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��݁j(��ƒl���z�i�ō��݁j)</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v(��ېŏ��i�l���̔�ېőΏۊz)</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj(�O�ŏ��i�l���̏���Ŋz)</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="partsDiscountRate">���i�l����(���v�ɑ΂��Ă̕��i�l����)</param>
        /// <param name="ravorDiscountRate">�H���l����(���v�ɑ΂��Ă̍H���l����)</param>
        /// <param name="totalCost">�������z�v</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�)</param>
        /// <param name="consTaxRate">����Őŗ�(�ύX2007/8/22(�^,��) ����)</param>
        /// <param name="fractionProcCd">�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj)</param>
        /// <param name="accRecConsTax">���|�����</param>
        /// <param name="autoDepositCd">���������敪(0:�ʏ����,1:��������)</param>
        /// <param name="autoDepositNoteDiv">�����������l�敪(0:����`�[�ԍ� 1:����`�[���l 2:����)</param>  // ADD 2013/01/18 �c���� Redmine#33797
        /// <param name="autoDepositSlipNo">���������`�[�ԍ�(�����������̓����`�[�ԍ�)</param>
        /// <param name="depositAllowanceTtl">�����������v�z(�a����������v�z���܂�)</param>
        /// <param name="depositAlwcBlnce">���������c��</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="outputNameCode">�����R�[�h(0:�������Ӑ�,1:�������Ӑ�)</param>
        /// <param name="outputName">��������</param>
        /// <param name="custSlipNo">���Ӑ�`�[�ԍ�</param>
        /// <param name="slipAddressDiv">�`�[�Z���敪(1:���Ӑ�,2:�[����)</param>
        /// <param name="addresseeCode">�[�i��R�[�h</param>
        /// <param name="addresseeName">�[�i�於��</param>
        /// <param name="addresseeName2">�[�i�於��2(�ǉ�(�o�^�R��) ����)</param>
        /// <param name="addresseePostNo">�[�i��X�֔ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr1">�[�i��Z��1(�s���{���s��S�E�����E��)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr3">�[�i��Z��3(�Ԓn)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr4">�[�i��Z��4(�A�p�[�g����)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeTelNo">�[�i��d�b�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeFaxNo">�[�i��FAX�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�(���Ӑ撍���ԍ��i���`�ԍ��j)</param>
        /// <param name="carSlipNote">���q���l</param>
        /// <param name="mileage">���s����</param>
        /// <param name="slipNote">�`�[���l</param>
        /// <param name="slipNote2">�`�[���l�Q</param>
        /// <param name="slipNote3">�`�[���l�R</param>
        /// <param name="slipNoteCode">�`�[���l�R�[�h</param>
        /// <param name="slipNote2Code">�`�[���l�Q�R�[�h</param>
        /// <param name="slipNote3Code">�`�[���l�R�R�[�h</param>
        /// <param name="retGoodsReasonDiv">�ԕi���R�R�[�h</param>
        /// <param name="retGoodsReason">�ԕi���R</param>
        /// <param name="regiProcDate">���W������(YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
        /// <param name="cashRegisterNo">���W�ԍ�(�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
        /// <param name="posReceiptNo">POS���V�[�g�ԍ�(�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j)</param>
        /// <param name="detailRowCount">���׍s��(�`�[���̖��ׂ̍s���i����p���ׂ͏����j)</param>
        /// <param name="ediSendDate">�d�c�h���M��(YYYYMMDD �iErectricDataInterface�j)</param>
        /// <param name="ediTakeInDate">�d�c�h�捞��(YYYYMMDD)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P(UserOrderEntory)</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="slipPrintDivCd">�`�[���s�敪(0:���Ȃ� 1:����)</param>
        /// <param name="slipPrintFinishCd">�`�[���s�ϋ敪(0:�����s 1:���s��)</param>
        /// <param name="salesSlipPrintDate">����`�[���s��</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <param name="orderNumber">�����ԍ�(����`����"��"�̎��ɃZ�b�g)</param>
        /// <param name="deliveredGoodsDiv">�[�i�敪(��) 1:�z�B,2:�X���n��,3:����,�c)</param>
        /// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
        /// <param name="salesAreaName">�̔��G���A����</param>
        /// <param name="reconcileFlag">�����t���O(0:�c���� 9:�c�����@�i�󒍁A�o�ׂɂĎg�p�j)</param>
        /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(����`���ƃZ�b�g�œ`�[�^�C�v�Ǘ��}�X�^���Q��)</param>
        /// <param name="completeCd">�ꎮ�`�[�敪(0:�ʏ�`�[,1:�ꎮ�`�[)</param>
        /// <param name="salesPriceFracProcCd">������z�[�������敪(1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i���㖾�׃f�[�^�̋��z�p�j)</param>
        /// <param name="stockGoodsTtlTaxExc">�݌ɏ��i���v���z�i�Ŕ��j(�݌Ɏ��敪���O�̖��׋��z�̏W�v)</param>
        /// <param name="pureGoodsTtlTaxExc">�������i���v���z�i�Ŕ��j(���i�������O�̖��׋��z�̏W�v)</param>
        /// <param name="listPricePrintDiv">�艿����敪</param>
        /// <param name="eraNameDispCd1">�����\���敪�P(�ʏ�@�@0:����@1:�a��)</param>
        /// <param name="estimaTaxDivCd">���Ϗ���ŋ敪(0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j)</param>
        /// <param name="estimateFormPrtCd">���Ϗ�����敪</param>
        /// <param name="estimateSubject">���ό���</param>
        /// <param name="footnotes1">�r���P</param>
        /// <param name="footnotes2">�r���Q</param>
        /// <param name="estimateTitle1">���σ^�C�g���P</param>
        /// <param name="estimateTitle2">���σ^�C�g���Q</param>
        /// <param name="estimateTitle3">���σ^�C�g���R</param>
        /// <param name="estimateTitle4">���σ^�C�g���S</param>
        /// <param name="estimateTitle5">���σ^�C�g���T</param>
        /// <param name="estimateNote1">���ϔ��l�P</param>
        /// <param name="estimateNote2">���ϔ��l�Q</param>
        /// <param name="estimateNote3">���ϔ��l�R</param>
        /// <param name="estimateNote4">���ϔ��l�S</param>
        /// <param name="estimateNote5">���ϔ��l�T</param>
        /// <param name="estimateValidityDate">���ϗL������(YYYYMMDD)</param>
        /// <param name="partsNoPrtCd">�i�Ԉ󎚋敪(0:���Ȃ�,1:����)</param>
        /// <param name="optionPringDivCd">�I�v�V�����󎚋敪(0:���Ȃ�,1:����)</param>
        /// <param name="rateUseCode">�|���g�p�敪(0:�������艿 1:�|���w��,2:�|���ݒ�)</param>
        /// <param name="inputMode">���̓��[�h(0:�ʏ���̓��[�h 1:�ԕi���̓��[�h 2:�ԓ`���̓��[�h)</param>
        /// <param name="salesSlipDisplay">����`�[�敪(��ʕ\���p)(10:�|���� 20:�|�ԕi 30:�������� 40:�����ԕi)</param>
        /// <param name="acptAnOdrStatusDisplay">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="claimName">�����於��(�������Ӑ於��)</param>
        /// <param name="claimName2">�����於�̂Q(�������Ӑ於�̂Q)</param>
        /// <param name="creditMngCode">�^�M�Ǘ��敪</param>
        /// <param name="totalDay">����(DD)</param>
        /// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
        /// <param name="totalMoneyForGrossProfit">�e���v�Z�p������z</param>
        /// <param name="sectionName">���_����</param>
        /// <param name="subSectionName">���喼��</param>
        /// <param name="carMngDivCd">���q�Ǘ��敪(0:���Ȃ��A1:�o�^(�m�F)�A2:�o�^(����) 3:�o�^��)</param>
        /// <param name="searchMode">���i�������[�h(0:�i�Ԍ����A1:BL�R�[�h����)</param>
        /// <param name="searchCarMode">�ԗ��������[�h(0:�^�������A1:���f���v���[�g����)</param>
        /// <param name="salesRate">������(���������ϗp)</param>
        /// <param name="estimateDtCreateDiv">���σf�[�^�쐬�敪(���������ϗp)</param>
        /// <param name="custOrderNoDispDiv">���Ӑ撍�ԕ\���敪(0:���Ȃ��@1:����i���Ӑ�}�X�^ 0:�S�̐ݒ�Q�� 1:���Ȃ��@2:����j)</param>
        /// <param name="custWarehouseCd">���Ӑ�D��q�ɃR�[�h</param>
        /// <param name="transStopDate">������~��</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="resultsAddUpSecNm">���ьv�㋒�_����</param>
        /// <param name="resultsAddUpSecNm">���׍s��</param> // ADD 2009/12/17
        /// <param name="stockUpdateFlag">�݌ɏ��X�V���f</param> // ADD 2010/01/27
        /// <returns>SalesSlip�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlip�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //>>>2010/04/08
        ////>>>2010/02/26
        ////// 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //////public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm)
        ////public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip)
        ////// 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip)
        ////<<<2010/02/26
        // --- ADD 2010/01/27 -------------->>>>>
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip)
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip, bool stockUpdateFlag)// del 2011/07/18 ���R
        // --- ADD 2010/01/27 --------------<<<<<
        //<<<2010/04/08
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip, bool stockUpdateFlag, int autoAnswerDivSCM)// add 2011/07/18 ���R // DEL 2011/12/15
        //public SalesSlip(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, string debitNLnkSalesSlNum, Int32 salesSlipCd, Int32 salesGoodsCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, Int32 salesSlipUpdateCd, DateTime searchSlipDate, DateTime shipmentDay, DateTime salesDate, DateTime preSalesDate, DateTime addUpADate, Int32 delayPaymentDiv, string estimateFormNo, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string salesInputName, string frontEmployeeCd, string frontEmployeeNm, string salesEmployeeCd, string salesEmployeeNm, Int32 totalAmountDispWayCd, Int32 ttlAmntDispRateApy, Int64 salesTotalTaxInc, Int64 salesTotalTaxExc, Int64 salesPrtTotalTaxInc, Int64 salesPrtTotalTaxExc, Int64 salesWorkTotalTaxInc, Int64 salesWorkTotalTaxExc, Int64 salesSubtotalTaxInc, Int64 salesSubtotalTaxExc, Int64 salesPrtSubttlInc, Int64 salesPrtSubttlExc, Int64 salesWorkSubttlInc, Int64 salesWorkSubttlExc, Int64 salesNetPrice, Int64 salesSubtotalTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 salSubttlSubToTaxFre, Int64 salesOutTax, Int64 salAmntConsTaxInclu, Int64 salesDisTtlTaxExc, Int64 itdedSalesDisOutTax, Int64 itdedSalesDisInTax, Int64 itdedPartsDisOutTax, Int64 itdedPartsDisInTax, Int64 itdedWorkDisOutTax, Int64 itdedWorkDisInTax, Int64 itdedSalesDisTaxFre, Int64 salesDisOutTax, Int64 salesDisTtlTaxInclu, Double partsDiscountRate, Double ravorDiscountRate, Int64 totalCost, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 accRecConsTax, Int32 autoDepositCd, Int32 autoDepositSlipNo, Int64 depositAllowanceTtl, Int64 depositAlwcBlnce, Int32 claimCode, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 outputNameCode, string outputName, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string carSlipNote, string mileage, string slipNote, string slipNote2, string slipNote3, Int32 slipNoteCode, Int32 slipNote2Code, Int32 slipNote3Code, Int32 retGoodsReasonDiv, string retGoodsReason, DateTime regiProcDate, Int32 cashRegisterNo, Int32 posReceiptNo, Int32 detailRowCount, DateTime ediSendDate, DateTime ediTakeInDate, string uoeRemark1, string uoeRemark2, Int32 slipPrintDivCd, Int32 slipPrintFinishCd, DateTime salesSlipPrintDate, Int32 businessTypeCode, string businessTypeName, string orderNumber, Int32 deliveredGoodsDiv, string deliveredGoodsDivNm, Int32 salesAreaCode, string salesAreaName, Int32 reconcileFlag, string slipPrtSetPaperId, Int32 completeCd, Int32 salesPriceFracProcCd, Int64 stockGoodsTtlTaxExc, Int64 pureGoodsTtlTaxExc, Int32 listPricePrintDiv, Int32 eraNameDispCd1, Int32 estimaTaxDivCd, Int32 estimateFormPrtCd, string estimateSubject, string footnotes1, string footnotes2, string estimateTitle1, string estimateTitle2, string estimateTitle3, string estimateTitle4, string estimateTitle5, string estimateNote1, string estimateNote2, string estimateNote3, string estimateNote4, string estimateNote5, DateTime estimateValidityDate, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 rateUseCode, Int32 inputMode, Int32 salesSlipDisplay, Int32 acptAnOdrStatusDisplay, Int32 custRateGrpCode, string claimName, string claimName2, Int32 creditMngCode, Int32 totalDay, Int32 nTimeCalcStDate, Int64 totalMoneyForGrossProfit, string sectionName, string subSectionName, Int32 carMngDivCd, Int32 searchMode, Int32 searchCarMode, Double salesRate, Int32 estimateDtCreateDiv, Int32 custOrderNoDispDiv, string custWarehouseCd, DateTime transStopDate, Int32 onlineKindDiv, string inqOriginalEpCd, string inqOriginalSecCd, Int32 answerDiv, Int64 inquiryNumber, Int32 inqOrdDivCd, string enterpriseName, string updEmployeeName, string resultsAddUpSecNm, Int32 detailRowCountForReadSlip, bool stockUpdateFlag, int autoAnswerDivSCM)// add 2011/07/18 ���R // ADD 2011/12/15 // DEL 2013/01/18 �c���� Redmine#33797
        //----- ADD 2013/01/18 �c���� Redmine#33797 ---------->>>>>
        public SalesSlip(
            DateTime createDateTime,
            DateTime updateDateTime,
            string enterpriseCode,
            Guid fileHeaderGuid,
            string updEmployeeCode,
            string updAssemblyId1,
            string updAssemblyId2,
            Int32 logicalDeleteCode,
            Int32 acptAnOdrStatus,
            string salesSlipNum,
            string sectionCode,
            Int32 subSectionCode,
            Int32 debitNoteDiv,
            string debitNLnkSalesSlNum,
            Int32 salesSlipCd,
            Int32 salesGoodsCd,
            Int32 accRecDivCd,
            string salesInpSecCd,
            string demandAddUpSecCd,
            string resultsAddUpSecCd,
            string updateSecCd,
            Int32 salesSlipUpdateCd,
            DateTime searchSlipDate,
            DateTime shipmentDay,
            DateTime salesDate,
            DateTime preSalesDate,
            DateTime addUpADate,
            Int32 delayPaymentDiv,
            string estimateFormNo,
            Int32 estimateDivide,
            string inputAgenCd,
            string inputAgenNm,
            string salesInputCode,
            string salesInputName,
            string frontEmployeeCd,
            string frontEmployeeNm,
            string salesEmployeeCd,
            string salesEmployeeNm,
            Int32 totalAmountDispWayCd,
            Int32 ttlAmntDispRateApy,
            Int64 salesTotalTaxInc,
            Int64 salesTotalTaxExc,
            Int64 salesPrtTotalTaxInc,
            Int64 salesPrtTotalTaxExc,
            Int64 salesWorkTotalTaxInc,
            Int64 salesWorkTotalTaxExc,
            Int64 salesSubtotalTaxInc,
            Int64 salesSubtotalTaxExc,
            Int64 salesPrtSubttlInc,
            Int64 salesPrtSubttlExc,
            Int64 salesWorkSubttlInc,
            Int64 salesWorkSubttlExc,
            Int64 salesNetPrice,
            Int64 salesSubtotalTax,
            Int64 itdedSalesOutTax,
            Int64 itdedSalesInTax,
            Int64 salSubttlSubToTaxFre,
            Int64 salesOutTax,
            Int64 salAmntConsTaxInclu,
            Int64 salesDisTtlTaxExc,
            Int64 itdedSalesDisOutTax,
            Int64 itdedSalesDisInTax,
            Int64 itdedPartsDisOutTax,
            Int64 itdedPartsDisInTax,
            Int64 itdedWorkDisOutTax,
            Int64 itdedWorkDisInTax,
            Int64 itdedSalesDisTaxFre,
            Int64 salesDisOutTax,
            Int64 salesDisTtlTaxInclu,
            Double partsDiscountRate,
            Double ravorDiscountRate,
            Int64 totalCost,
            Int32 consTaxLayMethod,
            Double consTaxRate,
            Int32 fractionProcCd,
            Int64 accRecConsTax,
            Int32 autoDepositCd,
            Int32 autoDepositNoteDiv, // �����������l�敪(0:����`�[�ԍ� 1:����`�[���l 2:����)
            Int32 autoDepositSlipNo,
            Int64 depositAllowanceTtl,
            Int64 depositAlwcBlnce,
            Int32 claimCode,
            string claimSnm,
            Int32 customerCode,
            string customerName,
            string customerName2,
            string customerSnm,
            string honorificTitle,
            Int32 outputNameCode,
            string outputName,
            Int32 custSlipNo,
            Int32 slipAddressDiv,
            Int32 addresseeCode,
            string addresseeName,
            string addresseeName2,
            string addresseePostNo,
            string addresseeAddr1,
            string addresseeAddr3,
            string addresseeAddr4,
            string addresseeTelNo,
            string addresseeFaxNo,
            string partySaleSlipNum,
            string carSlipNote,
            string mileage,
            string slipNote,
            string slipNote2,
            string slipNote3,
            Int32 slipNoteCode,
            Int32 slipNote2Code,
            Int32 slipNote3Code,
            Int32 retGoodsReasonDiv,
            string retGoodsReason,
            DateTime regiProcDate,
            Int32 cashRegisterNo,
            Int32 posReceiptNo,
            Int32 detailRowCount,
            DateTime ediSendDate,
            DateTime ediTakeInDate,
            string uoeRemark1,
            string uoeRemark2,
            Int32 slipPrintDivCd,
            Int32 slipPrintFinishCd,
            DateTime salesSlipPrintDate,
            Int32 businessTypeCode,
            string businessTypeName,
            string orderNumber,
            Int32 deliveredGoodsDiv,
            string deliveredGoodsDivNm,
            Int32 salesAreaCode,
            string salesAreaName,
            Int32 reconcileFlag,
            string slipPrtSetPaperId,
            Int32 completeCd,
            Int32 salesPriceFracProcCd,
            Int64 stockGoodsTtlTaxExc,
            Int64 pureGoodsTtlTaxExc,
            Int32 listPricePrintDiv,
            Int32 eraNameDispCd1,
            Int32 estimaTaxDivCd,
            Int32 estimateFormPrtCd,
            string estimateSubject,
            string footnotes1,
            string footnotes2,
            string estimateTitle1,
            string estimateTitle2,
            string estimateTitle3,
            string estimateTitle4,
            string estimateTitle5,
            string estimateNote1,
            string estimateNote2,
            string estimateNote3,
            string estimateNote4,
            string estimateNote5,
            DateTime estimateValidityDate,
            Int32 partsNoPrtCd,
            Int32 optionPringDivCd,
            Int32 rateUseCode,
            Int32 inputMode,
            Int32 salesSlipDisplay,
            Int32 acptAnOdrStatusDisplay,
            Int32 custRateGrpCode,
            string claimName,
            string claimName2,
            Int32 creditMngCode,
            Int32 totalDay,
            Int32 nTimeCalcStDate,
            Int64 totalMoneyForGrossProfit,
            string sectionName,
            string subSectionName,
            Int32 carMngDivCd,
            Int32 searchMode,
            Int32 searchCarMode,
            Double salesRate,
            Int32 estimateDtCreateDiv,
            Int32 custOrderNoDispDiv,
            string custWarehouseCd,
            DateTime transStopDate,
            Int32 onlineKindDiv,
            string inqOriginalEpCd,
            string inqOriginalSecCd,
            Int32 answerDiv,
            Int64 inquiryNumber,
            Int32 inqOrdDivCd,
            string enterpriseName,
            string updEmployeeName,
            string resultsAddUpSecNm,
            Int32 detailRowCountForReadSlip,
            bool stockUpdateFlag,
            int autoAnswerDivSCM)
        //----- ADD 2013/01/18 �c���� Redmine#33797 ----------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._debitNoteDiv = debitNoteDiv;
            this._debitNLnkSalesSlNum = debitNLnkSalesSlNum;
            this._salesSlipCd = salesSlipCd;
            this._salesGoodsCd = salesGoodsCd;
            this._accRecDivCd = accRecDivCd;
            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this._salesSlipUpdateCd = salesSlipUpdateCd;
            this.SearchSlipDate = searchSlipDate;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
            this.PreSalesDate = preSalesDate; // ADD 2011/12/15
            this.AddUpADate = addUpADate;
            this._delayPaymentDiv = delayPaymentDiv;
            this._estimateFormNo = estimateFormNo;
            this._estimateDivide = estimateDivide;
            this._inputAgenCd = inputAgenCd;
            this._inputAgenNm = inputAgenNm;
            this._salesInputCode = salesInputCode;
            this._salesInputName = salesInputName;
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this._salesEmployeeCd = salesEmployeeCd;
            this._salesEmployeeNm = salesEmployeeNm;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._ttlAmntDispRateApy = ttlAmntDispRateApy;
            this._salesTotalTaxInc = salesTotalTaxInc;
            this._salesTotalTaxExc = salesTotalTaxExc;
            this._salesPrtTotalTaxInc = salesPrtTotalTaxInc;
            this._salesPrtTotalTaxExc = salesPrtTotalTaxExc;
            this._salesWorkTotalTaxInc = salesWorkTotalTaxInc;
            this._salesWorkTotalTaxExc = salesWorkTotalTaxExc;
            this._salesSubtotalTaxInc = salesSubtotalTaxInc;
            this._salesSubtotalTaxExc = salesSubtotalTaxExc;
            this._salesPrtSubttlInc = salesPrtSubttlInc;
            this._salesPrtSubttlExc = salesPrtSubttlExc;
            this._salesWorkSubttlInc = salesWorkSubttlInc;
            this._salesWorkSubttlExc = salesWorkSubttlExc;
            this._salesNetPrice = salesNetPrice;
            this._salesSubtotalTax = salesSubtotalTax;
            this._itdedSalesOutTax = itdedSalesOutTax;
            this._itdedSalesInTax = itdedSalesInTax;
            this._salSubttlSubToTaxFre = salSubttlSubToTaxFre;
            this._salesOutTax = salesOutTax;
            this._salAmntConsTaxInclu = salAmntConsTaxInclu;
            this._salesDisTtlTaxExc = salesDisTtlTaxExc;
            this._itdedSalesDisOutTax = itdedSalesDisOutTax;
            this._itdedSalesDisInTax = itdedSalesDisInTax;
            this._itdedPartsDisOutTax = itdedPartsDisOutTax;
            this._itdedPartsDisInTax = itdedPartsDisInTax;
            this._itdedWorkDisOutTax = itdedWorkDisOutTax;
            this._itdedWorkDisInTax = itdedWorkDisInTax;
            this._itdedSalesDisTaxFre = itdedSalesDisTaxFre;
            this._salesDisOutTax = salesDisOutTax;
            this._salesDisTtlTaxInclu = salesDisTtlTaxInclu;
            this._partsDiscountRate = partsDiscountRate;
            this._ravorDiscountRate = ravorDiscountRate;
            this._totalCost = totalCost;
            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._accRecConsTax = accRecConsTax;
            this._autoDepositCd = autoDepositCd;
            this._autoDepositNoteDiv = autoDepositNoteDiv; // �����������l�敪(0:����`�[�ԍ� 1:����`�[���l 2:����) // ADD 2013/01/18 �c���� Redmine#33797
            this._autoDepositSlipNo = autoDepositSlipNo;
            this._depositAllowanceTtl = depositAllowanceTtl;
            this._depositAlwcBlnce = depositAlwcBlnce;
            this._claimCode = claimCode;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._honorificTitle = honorificTitle;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._custSlipNo = custSlipNo;
            this._slipAddressDiv = slipAddressDiv;
            this._addresseeCode = addresseeCode;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._addresseePostNo = addresseePostNo;
            this._addresseeAddr1 = addresseeAddr1;
            this._addresseeAddr3 = addresseeAddr3;
            this._addresseeAddr4 = addresseeAddr4;
            this._addresseeTelNo = addresseeTelNo;
            this._addresseeFaxNo = addresseeFaxNo;
            this._partySaleSlipNum = partySaleSlipNum;
            // --- ADD 2009/09/08 ---------->>>>>
            this._carSlipNote = carSlipNote;
            this._mileage = mileage;
            // --- ADD 2009/09/08 ----------<<<<<
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            // --- ADD 2009/12/23 ---------->>>>>
            this._slipNoteCode = slipNoteCode;
            this._slipNote2Code = slipNote2Code;
            this._slipNote3Code = slipNote3Code;
            // --- ADD 2009/12/23 ----------<<<<<
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this.RegiProcDate = regiProcDate;
            this._cashRegisterNo = cashRegisterNo;
            this._posReceiptNo = posReceiptNo;
            this._detailRowCount = detailRowCount;
            this.EdiSendDate = ediSendDate;
            this.EdiTakeInDate = ediTakeInDate;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._slipPrintDivCd = slipPrintDivCd;
            this._slipPrintFinishCd = slipPrintFinishCd;
            this.SalesSlipPrintDate = salesSlipPrintDate;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._orderNumber = orderNumber;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._reconcileFlag = reconcileFlag;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._completeCd = completeCd;
            this._salesPriceFracProcCd = salesPriceFracProcCd;
            this._stockGoodsTtlTaxExc = stockGoodsTtlTaxExc;
            this._pureGoodsTtlTaxExc = pureGoodsTtlTaxExc;
            this._listPricePrintDiv = listPricePrintDiv;
            this._eraNameDispCd1 = eraNameDispCd1;
            this._estimaTaxDivCd = estimaTaxDivCd;
            this._estimateFormPrtCd = estimateFormPrtCd;
            this._estimateSubject = estimateSubject;
            this._footnotes1 = footnotes1;
            this._footnotes2 = footnotes2;
            this._estimateTitle1 = estimateTitle1;
            this._estimateTitle2 = estimateTitle2;
            this._estimateTitle3 = estimateTitle3;
            this._estimateTitle4 = estimateTitle4;
            this._estimateTitle5 = estimateTitle5;
            this._estimateNote1 = estimateNote1;
            this._estimateNote2 = estimateNote2;
            this._estimateNote3 = estimateNote3;
            this._estimateNote4 = estimateNote4;
            this._estimateNote5 = estimateNote5;
            this.EstimateValidityDate = estimateValidityDate;
            this._partsNoPrtCd = partsNoPrtCd;
            this._optionPringDivCd = optionPringDivCd;
            this._rateUseCode = rateUseCode;
            this._inputMode = inputMode;
            this._salesSlipDisplay = salesSlipDisplay;
            this._acptAnOdrStatusDisplay = acptAnOdrStatusDisplay;
            this._custRateGrpCode = custRateGrpCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._creditMngCode = creditMngCode;
            this._totalDay = totalDay;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._totalMoneyForGrossProfit = totalMoneyForGrossProfit;
            this._sectionName = sectionName;
            this._subSectionName = subSectionName;
            this._carMngDivCd = carMngDivCd;
            this._searchMode = searchMode;
            this._searchCarMode = searchCarMode;
            this._salesRate = salesRate;
            this._estimateDtCreateDiv = estimateDtCreateDiv;
            this._custOrderNoDispDiv = custOrderNoDispDiv;
            this._custWarehouseCd = custWarehouseCd;
            this.TransStopDate = transStopDate;
            //>>>2010/02/26
            this._onlineKindDiv = onlineKindDiv;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._answerDiv = answerDiv;
            this._inquiryNumber = inquiryNumber;
            //<<<2010/02/26
            //>>>2010/04/08
            this._inqOrdDivCd = inqOrdDivCd;
            //<<<2010/04/08
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._resultsAddUpSecNm = resultsAddUpSecNm;
            this._detailRowCountForReadSlip = detailRowCountForReadSlip; // ADD 2009/12/17
            this._stockUpdateFlag = stockUpdateFlag; // ADD 2010/01/27
            this._autoAnswerDivSCM = autoAnswerDivSCM; // add 2011/07/18 ���R
        }

        /// <summary>
        /// ����f�[�^��������
        /// </summary>
        /// <returns>SalesSlip�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesSlip�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesSlip Clone()
        {
            //>>>2010/04/08
            ////>>>2010/02/26
            //////return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm); // DEL 2009/12/17
            ////return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip); // ADD 2009/12/17
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip); // ADD 2009/12/17
            ////<<<2010/02/26
            // --- UPD 2010/01/27 -------------->>>>>
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip);
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip, this._stockUpdateFlag);// del 2011/07/18 ���R
            // --- UPD 2010/01/27 --------------<<<<<
            //<<<2010/04/08
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip, this._stockUpdateFlag, this._autoAnswerDivSCM);// add 2011/07/18 ���R // DEL 2011/12/15
            //return new SalesSlip(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._debitNLnkSalesSlNum, this._salesSlipCd, this._salesGoodsCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._salesSlipUpdateCd, this._searchSlipDate, this._shipmentDay, this._salesDate, this._preSalesDate, this._addUpADate, this._delayPaymentDiv, this._estimateFormNo, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._salesInputName, this._frontEmployeeCd, this._frontEmployeeNm, this._salesEmployeeCd, this._salesEmployeeNm, this._totalAmountDispWayCd, this._ttlAmntDispRateApy, this._salesTotalTaxInc, this._salesTotalTaxExc, this._salesPrtTotalTaxInc, this._salesPrtTotalTaxExc, this._salesWorkTotalTaxInc, this._salesWorkTotalTaxExc, this._salesSubtotalTaxInc, this._salesSubtotalTaxExc, this._salesPrtSubttlInc, this._salesPrtSubttlExc, this._salesWorkSubttlInc, this._salesWorkSubttlExc, this._salesNetPrice, this._salesSubtotalTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._salSubttlSubToTaxFre, this._salesOutTax, this._salAmntConsTaxInclu, this._salesDisTtlTaxExc, this._itdedSalesDisOutTax, this._itdedSalesDisInTax, this._itdedPartsDisOutTax, this._itdedPartsDisInTax, this._itdedWorkDisOutTax, this._itdedWorkDisInTax, this._itdedSalesDisTaxFre, this._salesDisOutTax, this._salesDisTtlTaxInclu, this._partsDiscountRate, this._ravorDiscountRate, this._totalCost, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._accRecConsTax, this._autoDepositCd, this._autoDepositSlipNo, this._depositAllowanceTtl, this._depositAlwcBlnce, this._claimCode, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._outputNameCode, this._outputName, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._carSlipNote, this._mileage, this._slipNote, this._slipNote2, this._slipNote3, this._slipNoteCode, this._slipNote2Code, this._slipNote3Code, this._retGoodsReasonDiv, this._retGoodsReason, this._regiProcDate, this._cashRegisterNo, this._posReceiptNo, this._detailRowCount, this._ediSendDate, this._ediTakeInDate, this._uoeRemark1, this._uoeRemark2, this._slipPrintDivCd, this._slipPrintFinishCd, this._salesSlipPrintDate, this._businessTypeCode, this._businessTypeName, this._orderNumber, this._deliveredGoodsDiv, this._deliveredGoodsDivNm, this._salesAreaCode, this._salesAreaName, this._reconcileFlag, this._slipPrtSetPaperId, this._completeCd, this._salesPriceFracProcCd, this._stockGoodsTtlTaxExc, this._pureGoodsTtlTaxExc, this._listPricePrintDiv, this._eraNameDispCd1, this._estimaTaxDivCd, this._estimateFormPrtCd, this._estimateSubject, this._footnotes1, this._footnotes2, this._estimateTitle1, this._estimateTitle2, this._estimateTitle3, this._estimateTitle4, this._estimateTitle5, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimateNote4, this._estimateNote5, this._estimateValidityDate, this._partsNoPrtCd, this._optionPringDivCd, this._rateUseCode, this._inputMode, this._salesSlipDisplay, this._acptAnOdrStatusDisplay, this._custRateGrpCode, this._claimName, this._claimName2, this._creditMngCode, this._totalDay, this._nTimeCalcStDate, this._totalMoneyForGrossProfit, this._sectionName, this._subSectionName, this._carMngDivCd, this._searchMode, this._searchCarMode, this._salesRate, this._estimateDtCreateDiv, this._custOrderNoDispDiv, this._custWarehouseCd, this._transStopDate, this._onlineKindDiv, this._inqOriginalEpCd, this._inqOriginalSecCd, this._answerDiv, this._inquiryNumber, this._inqOrdDivCd, this._enterpriseName, this._updEmployeeName, this._resultsAddUpSecNm, this._detailRowCountForReadSlip, this._stockUpdateFlag, this._autoAnswerDivSCM);// ADD 2011/12/15 // DEL 2013/01/18 �c���� Redmine#33797
            //----- ADD 2013/01/18 �c���� Redmine#33797 ---------->>>>>
            return new SalesSlip(
                this._createDateTime,
                this._updateDateTime,
                this._enterpriseCode,
                this._fileHeaderGuid,
                this._updEmployeeCode,
                this._updAssemblyId1,
                this._updAssemblyId2,
                this._logicalDeleteCode,
                this._acptAnOdrStatus,
                this._salesSlipNum,
                this._sectionCode,
                this._subSectionCode,
                this._debitNoteDiv,
                this._debitNLnkSalesSlNum,
                this._salesSlipCd,
                this._salesGoodsCd,
                this._accRecDivCd,
                this._salesInpSecCd,
                this._demandAddUpSecCd,
                this._resultsAddUpSecCd,
                this._updateSecCd,
                this._salesSlipUpdateCd,
                this._searchSlipDate,
                this._shipmentDay,
                this._salesDate,
                this._preSalesDate,
                this._addUpADate,
                this._delayPaymentDiv,
                this._estimateFormNo,
                this._estimateDivide,
                this._inputAgenCd,
                this._inputAgenNm,
                this._salesInputCode,
                this._salesInputName,
                this._frontEmployeeCd,
                this._frontEmployeeNm,
                this._salesEmployeeCd,
                this._salesEmployeeNm,
                this._totalAmountDispWayCd,
                this._ttlAmntDispRateApy,
                this._salesTotalTaxInc,
                this._salesTotalTaxExc,
                this._salesPrtTotalTaxInc,
                this._salesPrtTotalTaxExc,
                this._salesWorkTotalTaxInc,
                this._salesWorkTotalTaxExc,
                this._salesSubtotalTaxInc,
                this._salesSubtotalTaxExc,
                this._salesPrtSubttlInc,
                this._salesPrtSubttlExc,
                this._salesWorkSubttlInc,
                this._salesWorkSubttlExc,
                this._salesNetPrice,
                this._salesSubtotalTax,
                this._itdedSalesOutTax,
                this._itdedSalesInTax,
                this._salSubttlSubToTaxFre,
                this._salesOutTax,
                this._salAmntConsTaxInclu,
                this._salesDisTtlTaxExc,
                this._itdedSalesDisOutTax,
                this._itdedSalesDisInTax,
                this._itdedPartsDisOutTax,
                this._itdedPartsDisInTax,
                this._itdedWorkDisOutTax,
                this._itdedWorkDisInTax,
                this._itdedSalesDisTaxFre,
                this._salesDisOutTax,
                this._salesDisTtlTaxInclu,
                this._partsDiscountRate,
                this._ravorDiscountRate,
                this._totalCost,
                this._consTaxLayMethod,
                this._consTaxRate,
                this._fractionProcCd,
                this._accRecConsTax,
                this._autoDepositCd,
                this._autoDepositNoteDiv, // �����������l�敪(0:����`�[�ԍ� 1:����`�[���l 2:����)
                this._autoDepositSlipNo,
                this._depositAllowanceTtl,
                this._depositAlwcBlnce,
                this._claimCode,
                this._claimSnm,
                this._customerCode,
                this._customerName,
                this._customerName2,
                this._customerSnm,
                this._honorificTitle,
                this._outputNameCode,
                this._outputName,
                this._custSlipNo,
                this._slipAddressDiv,
                this._addresseeCode,
                this._addresseeName,
                this._addresseeName2,
                this._addresseePostNo,
                this._addresseeAddr1,
                this._addresseeAddr3,
                this._addresseeAddr4,
                this._addresseeTelNo,
                this._addresseeFaxNo,
                this._partySaleSlipNum,
                this._carSlipNote,
                this._mileage,
                this._slipNote,
                this._slipNote2,
                this._slipNote3,
                this._slipNoteCode,
                this._slipNote2Code,
                this._slipNote3Code,
                this._retGoodsReasonDiv,
                this._retGoodsReason,
                this._regiProcDate,
                this._cashRegisterNo,
                this._posReceiptNo,
                this._detailRowCount,
                this._ediSendDate,
                this._ediTakeInDate,
                this._uoeRemark1,
                this._uoeRemark2,
                this._slipPrintDivCd,
                this._slipPrintFinishCd,
                this._salesSlipPrintDate,
                this._businessTypeCode,
                this._businessTypeName,
                this._orderNumber,
                this._deliveredGoodsDiv,
                this._deliveredGoodsDivNm,
                this._salesAreaCode,
                this._salesAreaName,
                this._reconcileFlag,
                this._slipPrtSetPaperId,
                this._completeCd,
                this._salesPriceFracProcCd,
                this._stockGoodsTtlTaxExc,
                this._pureGoodsTtlTaxExc,
                this._listPricePrintDiv,
                this._eraNameDispCd1,
                this._estimaTaxDivCd,
                this._estimateFormPrtCd,
                this._estimateSubject,
                this._footnotes1,
                this._footnotes2,
                this._estimateTitle1,
                this._estimateTitle2,
                this._estimateTitle3,
                this._estimateTitle4,
                this._estimateTitle5,
                this._estimateNote1,
                this._estimateNote2,
                this._estimateNote3,
                this._estimateNote4,
                this._estimateNote5,
                this._estimateValidityDate,
                this._partsNoPrtCd,
                this._optionPringDivCd,
                this._rateUseCode,
                this._inputMode,
                this._salesSlipDisplay,
                this._acptAnOdrStatusDisplay,
                this._custRateGrpCode,
                this._claimName,
                this._claimName2,
                this._creditMngCode,
                this._totalDay,
                this._nTimeCalcStDate,
                this._totalMoneyForGrossProfit,
                this._sectionName,
                this._subSectionName,
                this._carMngDivCd,
                this._searchMode,
                this._searchCarMode,
                this._salesRate,
                this._estimateDtCreateDiv,
                this._custOrderNoDispDiv,
                this._custWarehouseCd,
                this._transStopDate,
                this._onlineKindDiv,
                this._inqOriginalEpCd.Trim(),//@@@@20230303
                this._inqOriginalSecCd,
                this._answerDiv,
                this._inquiryNumber,
                this._inqOrdDivCd,
                this._enterpriseName,
                this._updEmployeeName,
                this._resultsAddUpSecNm,
                this._detailRowCountForReadSlip,
                this._stockUpdateFlag,
                this._autoAnswerDivSCM);
            //----- ADD 2013/01/18 �c���� Redmine#33797 ----------<<<<<
        }

        /// <summary>
        /// ����f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesSlip�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlip�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalesSlip target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.DebitNoteDiv == target.DebitNoteDiv)
                 && (this.DebitNLnkSalesSlNum == target.DebitNLnkSalesSlNum)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesGoodsCd == target.SalesGoodsCd)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.SalesInpSecCd == target.SalesInpSecCd)
                 && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
                 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.SalesSlipUpdateCd == target.SalesSlipUpdateCd)
                 && (this.SearchSlipDate == target.SearchSlipDate)
                 && (this.ShipmentDay == target.ShipmentDay)
                 && (this.SalesDate == target.SalesDate)
                 && (this.PreSalesDate == target.PreSalesDate) // ADD 2011/12/15
                 && (this.AddUpADate == target.AddUpADate)
                 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
                 && (this.EstimateFormNo == target.EstimateFormNo)
                 && (this.EstimateDivide == target.EstimateDivide)
                 && (this.InputAgenCd == target.InputAgenCd)
                 && (this.InputAgenNm == target.InputAgenNm)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
                 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
                 && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
                 && (this.SalesPrtTotalTaxInc == target.SalesPrtTotalTaxInc)
                 && (this.SalesPrtTotalTaxExc == target.SalesPrtTotalTaxExc)
                 && (this.SalesWorkTotalTaxInc == target.SalesWorkTotalTaxInc)
                 && (this.SalesWorkTotalTaxExc == target.SalesWorkTotalTaxExc)
                 && (this.SalesSubtotalTaxInc == target.SalesSubtotalTaxInc)
                 && (this.SalesSubtotalTaxExc == target.SalesSubtotalTaxExc)
                 && (this.SalesPrtSubttlInc == target.SalesPrtSubttlInc)
                 && (this.SalesPrtSubttlExc == target.SalesPrtSubttlExc)
                 && (this.SalesWorkSubttlInc == target.SalesWorkSubttlInc)
                 && (this.SalesWorkSubttlExc == target.SalesWorkSubttlExc)
                 && (this.SalesNetPrice == target.SalesNetPrice)
                 && (this.SalesSubtotalTax == target.SalesSubtotalTax)
                 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
                 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
                 && (this.SalSubttlSubToTaxFre == target.SalSubttlSubToTaxFre)
                 && (this.SalesOutTax == target.SalesOutTax)
                 && (this.SalAmntConsTaxInclu == target.SalAmntConsTaxInclu)
                 && (this.SalesDisTtlTaxExc == target.SalesDisTtlTaxExc)
                 && (this.ItdedSalesDisOutTax == target.ItdedSalesDisOutTax)
                 && (this.ItdedSalesDisInTax == target.ItdedSalesDisInTax)
                 && (this.ItdedPartsDisOutTax == target.ItdedPartsDisOutTax)
                 && (this.ItdedPartsDisInTax == target.ItdedPartsDisInTax)
                 && (this.ItdedWorkDisOutTax == target.ItdedWorkDisOutTax)
                 && (this.ItdedWorkDisInTax == target.ItdedWorkDisInTax)
                 && (this.ItdedSalesDisTaxFre == target.ItdedSalesDisTaxFre)
                 && (this.SalesDisOutTax == target.SalesDisOutTax)
                 && (this.SalesDisTtlTaxInclu == target.SalesDisTtlTaxInclu)
                 && (this.PartsDiscountRate == target.PartsDiscountRate)
                 && (this.RavorDiscountRate == target.RavorDiscountRate)
                 && (this.TotalCost == target.TotalCost)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.AccRecConsTax == target.AccRecConsTax)
                 && (this.AutoDepositCd == target.AutoDepositCd)
                 && (this.AutoDepositNoteDiv == target.AutoDepositNoteDiv) // ADD 2013/01/18 �c���� Redmine#33797
                 && (this.AutoDepositSlipNo == target.AutoDepositSlipNo)
                 && (this.DepositAllowanceTtl == target.DepositAllowanceTtl)
                 && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.OutputName == target.OutputName)
                 && (this.CustSlipNo == target.CustSlipNo)
                 && (this.SlipAddressDiv == target.SlipAddressDiv)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.AddresseeName == target.AddresseeName)
                 && (this.AddresseeName2 == target.AddresseeName2)
                 && (this.AddresseePostNo == target.AddresseePostNo)
                 && (this.AddresseeAddr1 == target.AddresseeAddr1)
                 && (this.AddresseeAddr3 == target.AddresseeAddr3)
                 && (this.AddresseeAddr4 == target.AddresseeAddr4)
                 && (this.AddresseeTelNo == target.AddresseeTelNo)
                 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.CarSlipNote == target.CarSlipNote)   // ADD 2009/09/08
                 && (this.Mileage == target.Mileage)   // ADD 2009/09/08
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
                 // --- ADD 2009/12/23 ---------->>>>>
                 && (this.SlipNoteCode == target.SlipNoteCode)
                 && (this.SlipNote2Code == target.SlipNote2Code)
                 && (this.SlipNote3Code == target.SlipNote3Code)
                 // --- ADD 2009/12/23 ----------<<<<<
                 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
                 && (this.RetGoodsReason == target.RetGoodsReason)
                 && (this.RegiProcDate == target.RegiProcDate)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.PosReceiptNo == target.PosReceiptNo)
                 && (this.DetailRowCount == target.DetailRowCount)
                 && (this.EdiSendDate == target.EdiSendDate)
                 && (this.EdiTakeInDate == target.EdiTakeInDate)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SlipPrintDivCd == target.SlipPrintDivCd)
                 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
                 && (this.SalesSlipPrintDate == target.SalesSlipPrintDate)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.OrderNumber == target.OrderNumber)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.ReconcileFlag == target.ReconcileFlag)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.CompleteCd == target.CompleteCd)
                 && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
                 && (this.StockGoodsTtlTaxExc == target.StockGoodsTtlTaxExc)
                 && (this.PureGoodsTtlTaxExc == target.PureGoodsTtlTaxExc)
                 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EstimaTaxDivCd == target.EstimaTaxDivCd)
                 && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
                 && (this.EstimateSubject == target.EstimateSubject)
                 && (this.Footnotes1 == target.Footnotes1)
                 && (this.Footnotes2 == target.Footnotes2)
                 && (this.EstimateTitle1 == target.EstimateTitle1)
                 && (this.EstimateTitle2 == target.EstimateTitle2)
                 && (this.EstimateTitle3 == target.EstimateTitle3)
                 && (this.EstimateTitle4 == target.EstimateTitle4)
                 && (this.EstimateTitle5 == target.EstimateTitle5)
                 && (this.EstimateNote1 == target.EstimateNote1)
                 && (this.EstimateNote2 == target.EstimateNote2)
                 && (this.EstimateNote3 == target.EstimateNote3)
                 && (this.EstimateNote4 == target.EstimateNote4)
                 && (this.EstimateNote5 == target.EstimateNote5)
                 && (this.EstimateValidityDate == target.EstimateValidityDate)
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.OptionPringDivCd == target.OptionPringDivCd)
                 && (this.RateUseCode == target.RateUseCode)
                 && (this.InputMode == target.InputMode)
                 && (this.SalesSlipDisplay == target.SalesSlipDisplay)
                 && (this.AcptAnOdrStatusDisplay == target.AcptAnOdrStatusDisplay)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.CreditMngCode == target.CreditMngCode)
                 && (this.TotalDay == target.TotalDay)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.TotalMoneyForGrossProfit == target.TotalMoneyForGrossProfit)
                 && (this.SectionName == target.SectionName)
                 && (this.SubSectionName == target.SubSectionName)
                 && (this.CarMngDivCd == target.CarMngDivCd)
                 && (this.SearchMode == target.SearchMode)
                 && (this.SearchCarMode == target.SearchCarMode)
                 && (this.SalesRate == target.SalesRate)
                 && (this.EstimateDtCreateDiv == target.EstimateDtCreateDiv)
                 && (this.CustOrderNoDispDiv == target.CustOrderNoDispDiv)
                 && (this.CustWarehouseCd == target.CustWarehouseCd)
                 && (this.TransStopDate == target.TransStopDate)
                //>>>2010/02/26
                 && (this.OnlineKindDiv == target.OnlineKindDiv)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.AnswerDiv == target.AnswerDiv)
                 && (this.InquiryNumber == target.InquiryNumber)
                //<<<2010/02/26
                //>>>2010/04/08
                 && (this.InqOrdDivCd == target.InqOrdDivCd)
                //<<<2010/04/08
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DetailRowCountForReadSlip == target.DetailRowCountForReadSlip) // ADD 2009/12/17
                 && (this.StockUpdateFlag == target.StockUpdateFlag) // ADD 2010/01/27
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM) // add 2011/07/18 ���R
                 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm));
        }

        /// <summary>
        /// ����f�[�^��r����
        /// </summary>
        /// <param name="salesSlip1">
        ///                    ��r����SalesSlip�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesSlip2">��r����SalesSlip�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlip�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalesSlip salesSlip1, SalesSlip salesSlip2)
        {
            return ((salesSlip1.CreateDateTime == salesSlip2.CreateDateTime)
                 && (salesSlip1.UpdateDateTime == salesSlip2.UpdateDateTime)
                 && (salesSlip1.EnterpriseCode == salesSlip2.EnterpriseCode)
                 && (salesSlip1.FileHeaderGuid == salesSlip2.FileHeaderGuid)
                 && (salesSlip1.UpdEmployeeCode == salesSlip2.UpdEmployeeCode)
                 && (salesSlip1.UpdAssemblyId1 == salesSlip2.UpdAssemblyId1)
                 && (salesSlip1.UpdAssemblyId2 == salesSlip2.UpdAssemblyId2)
                 && (salesSlip1.LogicalDeleteCode == salesSlip2.LogicalDeleteCode)
                 && (salesSlip1.AcptAnOdrStatus == salesSlip2.AcptAnOdrStatus)
                 && (salesSlip1.SalesSlipNum == salesSlip2.SalesSlipNum)
                 && (salesSlip1.SectionCode == salesSlip2.SectionCode)
                 && (salesSlip1.SubSectionCode == salesSlip2.SubSectionCode)
                 && (salesSlip1.DebitNoteDiv == salesSlip2.DebitNoteDiv)
                 && (salesSlip1.DebitNLnkSalesSlNum == salesSlip2.DebitNLnkSalesSlNum)
                 && (salesSlip1.SalesSlipCd == salesSlip2.SalesSlipCd)
                 && (salesSlip1.SalesGoodsCd == salesSlip2.SalesGoodsCd)
                 && (salesSlip1.AccRecDivCd == salesSlip2.AccRecDivCd)
                 && (salesSlip1.SalesInpSecCd == salesSlip2.SalesInpSecCd)
                 && (salesSlip1.DemandAddUpSecCd == salesSlip2.DemandAddUpSecCd)
                 && (salesSlip1.ResultsAddUpSecCd == salesSlip2.ResultsAddUpSecCd)
                 && (salesSlip1.UpdateSecCd == salesSlip2.UpdateSecCd)
                 && (salesSlip1.SalesSlipUpdateCd == salesSlip2.SalesSlipUpdateCd)
                 && (salesSlip1.SearchSlipDate == salesSlip2.SearchSlipDate)
                 && (salesSlip1.ShipmentDay == salesSlip2.ShipmentDay)
                 && (salesSlip1.SalesDate == salesSlip2.SalesDate)
                 && (salesSlip1.PreSalesDate == salesSlip2.PreSalesDate) // ADD 2011/12/15
                 && (salesSlip1.AddUpADate == salesSlip2.AddUpADate)
                 && (salesSlip1.DelayPaymentDiv == salesSlip2.DelayPaymentDiv)
                 && (salesSlip1.EstimateFormNo == salesSlip2.EstimateFormNo)
                 && (salesSlip1.EstimateDivide == salesSlip2.EstimateDivide)
                 && (salesSlip1.InputAgenCd == salesSlip2.InputAgenCd)
                 && (salesSlip1.InputAgenNm == salesSlip2.InputAgenNm)
                 && (salesSlip1.SalesInputCode == salesSlip2.SalesInputCode)
                 && (salesSlip1.SalesInputName == salesSlip2.SalesInputName)
                 && (salesSlip1.FrontEmployeeCd == salesSlip2.FrontEmployeeCd)
                 && (salesSlip1.FrontEmployeeNm == salesSlip2.FrontEmployeeNm)
                 && (salesSlip1.SalesEmployeeCd == salesSlip2.SalesEmployeeCd)
                 && (salesSlip1.SalesEmployeeNm == salesSlip2.SalesEmployeeNm)
                 && (salesSlip1.TotalAmountDispWayCd == salesSlip2.TotalAmountDispWayCd)
                 && (salesSlip1.TtlAmntDispRateApy == salesSlip2.TtlAmntDispRateApy)
                 && (salesSlip1.SalesTotalTaxInc == salesSlip2.SalesTotalTaxInc)
                 && (salesSlip1.SalesTotalTaxExc == salesSlip2.SalesTotalTaxExc)
                 && (salesSlip1.SalesPrtTotalTaxInc == salesSlip2.SalesPrtTotalTaxInc)
                 && (salesSlip1.SalesPrtTotalTaxExc == salesSlip2.SalesPrtTotalTaxExc)
                 && (salesSlip1.SalesWorkTotalTaxInc == salesSlip2.SalesWorkTotalTaxInc)
                 && (salesSlip1.SalesWorkTotalTaxExc == salesSlip2.SalesWorkTotalTaxExc)
                 && (salesSlip1.SalesSubtotalTaxInc == salesSlip2.SalesSubtotalTaxInc)
                 && (salesSlip1.SalesSubtotalTaxExc == salesSlip2.SalesSubtotalTaxExc)
                 && (salesSlip1.SalesPrtSubttlInc == salesSlip2.SalesPrtSubttlInc)
                 && (salesSlip1.SalesPrtSubttlExc == salesSlip2.SalesPrtSubttlExc)
                 && (salesSlip1.SalesWorkSubttlInc == salesSlip2.SalesWorkSubttlInc)
                 && (salesSlip1.SalesWorkSubttlExc == salesSlip2.SalesWorkSubttlExc)
                 && (salesSlip1.SalesNetPrice == salesSlip2.SalesNetPrice)
                 && (salesSlip1.SalesSubtotalTax == salesSlip2.SalesSubtotalTax)
                 && (salesSlip1.ItdedSalesOutTax == salesSlip2.ItdedSalesOutTax)
                 && (salesSlip1.ItdedSalesInTax == salesSlip2.ItdedSalesInTax)
                 && (salesSlip1.SalSubttlSubToTaxFre == salesSlip2.SalSubttlSubToTaxFre)
                 && (salesSlip1.SalesOutTax == salesSlip2.SalesOutTax)
                 && (salesSlip1.SalAmntConsTaxInclu == salesSlip2.SalAmntConsTaxInclu)
                 && (salesSlip1.SalesDisTtlTaxExc == salesSlip2.SalesDisTtlTaxExc)
                 && (salesSlip1.ItdedSalesDisOutTax == salesSlip2.ItdedSalesDisOutTax)
                 && (salesSlip1.ItdedSalesDisInTax == salesSlip2.ItdedSalesDisInTax)
                 && (salesSlip1.ItdedPartsDisOutTax == salesSlip2.ItdedPartsDisOutTax)
                 && (salesSlip1.ItdedPartsDisInTax == salesSlip2.ItdedPartsDisInTax)
                 && (salesSlip1.ItdedWorkDisOutTax == salesSlip2.ItdedWorkDisOutTax)
                 && (salesSlip1.ItdedWorkDisInTax == salesSlip2.ItdedWorkDisInTax)
                 && (salesSlip1.ItdedSalesDisTaxFre == salesSlip2.ItdedSalesDisTaxFre)
                 && (salesSlip1.SalesDisOutTax == salesSlip2.SalesDisOutTax)
                 && (salesSlip1.SalesDisTtlTaxInclu == salesSlip2.SalesDisTtlTaxInclu)
                 && (salesSlip1.PartsDiscountRate == salesSlip2.PartsDiscountRate)
                 && (salesSlip1.RavorDiscountRate == salesSlip2.RavorDiscountRate)
                 && (salesSlip1.TotalCost == salesSlip2.TotalCost)
                 && (salesSlip1.ConsTaxLayMethod == salesSlip2.ConsTaxLayMethod)
                 && (salesSlip1.ConsTaxRate == salesSlip2.ConsTaxRate)
                 && (salesSlip1.FractionProcCd == salesSlip2.FractionProcCd)
                 && (salesSlip1.AccRecConsTax == salesSlip2.AccRecConsTax)
                 && (salesSlip1.AutoDepositCd == salesSlip2.AutoDepositCd)
                 && (salesSlip1.AutoDepositNoteDiv == salesSlip2.AutoDepositNoteDiv) // ADD 2013/01/18 �c���� Redmine#33797
                 && (salesSlip1.AutoDepositSlipNo == salesSlip2.AutoDepositSlipNo)
                 && (salesSlip1.DepositAllowanceTtl == salesSlip2.DepositAllowanceTtl)
                 && (salesSlip1.DepositAlwcBlnce == salesSlip2.DepositAlwcBlnce)
                 && (salesSlip1.ClaimCode == salesSlip2.ClaimCode)
                 && (salesSlip1.ClaimSnm == salesSlip2.ClaimSnm)
                 && (salesSlip1.CustomerCode == salesSlip2.CustomerCode)
                 && (salesSlip1.CustomerName == salesSlip2.CustomerName)
                 && (salesSlip1.CustomerName2 == salesSlip2.CustomerName2)
                 && (salesSlip1.CustomerSnm == salesSlip2.CustomerSnm)
                 && (salesSlip1.HonorificTitle == salesSlip2.HonorificTitle)
                 && (salesSlip1.OutputNameCode == salesSlip2.OutputNameCode)
                 && (salesSlip1.OutputName == salesSlip2.OutputName)
                 && (salesSlip1.CustSlipNo == salesSlip2.CustSlipNo)
                 && (salesSlip1.SlipAddressDiv == salesSlip2.SlipAddressDiv)
                 && (salesSlip1.AddresseeCode == salesSlip2.AddresseeCode)
                 && (salesSlip1.AddresseeName == salesSlip2.AddresseeName)
                 && (salesSlip1.AddresseeName2 == salesSlip2.AddresseeName2)
                 && (salesSlip1.AddresseePostNo == salesSlip2.AddresseePostNo)
                 && (salesSlip1.AddresseeAddr1 == salesSlip2.AddresseeAddr1)
                 && (salesSlip1.AddresseeAddr3 == salesSlip2.AddresseeAddr3)
                 && (salesSlip1.AddresseeAddr4 == salesSlip2.AddresseeAddr4)
                 && (salesSlip1.AddresseeTelNo == salesSlip2.AddresseeTelNo)
                 && (salesSlip1.AddresseeFaxNo == salesSlip2.AddresseeFaxNo)
                 && (salesSlip1.PartySaleSlipNum == salesSlip2.PartySaleSlipNum)
                 && (salesSlip1.CarSlipNote == salesSlip2.CarSlipNote)   // ADD 2009/09/08
                 && (salesSlip1.Mileage == salesSlip2.Mileage)   // ADD 2009/09/08
                 && (salesSlip1.SlipNote == salesSlip2.SlipNote)
                 && (salesSlip1.SlipNote2 == salesSlip2.SlipNote2)
                 && (salesSlip1.SlipNote3 == salesSlip2.SlipNote3)
                 // --- ADD 2009/12/23 ---------->>>>>
                 && (salesSlip1.SlipNoteCode == salesSlip2.SlipNoteCode)
                 && (salesSlip1.SlipNote2Code == salesSlip2.SlipNote2Code)
                 && (salesSlip1.SlipNote3Code == salesSlip2.SlipNote3Code)
                 // --- ADD 2009/12/23 ----------<<<<<
                 && (salesSlip1.RetGoodsReasonDiv == salesSlip2.RetGoodsReasonDiv)
                 && (salesSlip1.RetGoodsReason == salesSlip2.RetGoodsReason)
                 && (salesSlip1.RegiProcDate == salesSlip2.RegiProcDate)
                 && (salesSlip1.CashRegisterNo == salesSlip2.CashRegisterNo)
                 && (salesSlip1.PosReceiptNo == salesSlip2.PosReceiptNo)
                 && (salesSlip1.DetailRowCount == salesSlip2.DetailRowCount)
                 && (salesSlip1.EdiSendDate == salesSlip2.EdiSendDate)
                 && (salesSlip1.EdiTakeInDate == salesSlip2.EdiTakeInDate)
                 && (salesSlip1.UoeRemark1 == salesSlip2.UoeRemark1)
                 && (salesSlip1.UoeRemark2 == salesSlip2.UoeRemark2)
                 && (salesSlip1.SlipPrintDivCd == salesSlip2.SlipPrintDivCd)
                 && (salesSlip1.SlipPrintFinishCd == salesSlip2.SlipPrintFinishCd)
                 && (salesSlip1.SalesSlipPrintDate == salesSlip2.SalesSlipPrintDate)
                 && (salesSlip1.BusinessTypeCode == salesSlip2.BusinessTypeCode)
                 && (salesSlip1.BusinessTypeName == salesSlip2.BusinessTypeName)
                 && (salesSlip1.OrderNumber == salesSlip2.OrderNumber)
                 && (salesSlip1.DeliveredGoodsDiv == salesSlip2.DeliveredGoodsDiv)
                 && (salesSlip1.DeliveredGoodsDivNm == salesSlip2.DeliveredGoodsDivNm)
                 && (salesSlip1.SalesAreaCode == salesSlip2.SalesAreaCode)
                 && (salesSlip1.SalesAreaName == salesSlip2.SalesAreaName)
                 && (salesSlip1.ReconcileFlag == salesSlip2.ReconcileFlag)
                 && (salesSlip1.SlipPrtSetPaperId == salesSlip2.SlipPrtSetPaperId)
                 && (salesSlip1.CompleteCd == salesSlip2.CompleteCd)
                 && (salesSlip1.SalesPriceFracProcCd == salesSlip2.SalesPriceFracProcCd)
                 && (salesSlip1.StockGoodsTtlTaxExc == salesSlip2.StockGoodsTtlTaxExc)
                 && (salesSlip1.PureGoodsTtlTaxExc == salesSlip2.PureGoodsTtlTaxExc)
                 && (salesSlip1.ListPricePrintDiv == salesSlip2.ListPricePrintDiv)
                 && (salesSlip1.EraNameDispCd1 == salesSlip2.EraNameDispCd1)
                 && (salesSlip1.EstimaTaxDivCd == salesSlip2.EstimaTaxDivCd)
                 && (salesSlip1.EstimateFormPrtCd == salesSlip2.EstimateFormPrtCd)
                 && (salesSlip1.EstimateSubject == salesSlip2.EstimateSubject)
                 && (salesSlip1.Footnotes1 == salesSlip2.Footnotes1)
                 && (salesSlip1.Footnotes2 == salesSlip2.Footnotes2)
                 && (salesSlip1.EstimateTitle1 == salesSlip2.EstimateTitle1)
                 && (salesSlip1.EstimateTitle2 == salesSlip2.EstimateTitle2)
                 && (salesSlip1.EstimateTitle3 == salesSlip2.EstimateTitle3)
                 && (salesSlip1.EstimateTitle4 == salesSlip2.EstimateTitle4)
                 && (salesSlip1.EstimateTitle5 == salesSlip2.EstimateTitle5)
                 && (salesSlip1.EstimateNote1 == salesSlip2.EstimateNote1)
                 && (salesSlip1.EstimateNote2 == salesSlip2.EstimateNote2)
                 && (salesSlip1.EstimateNote3 == salesSlip2.EstimateNote3)
                 && (salesSlip1.EstimateNote4 == salesSlip2.EstimateNote4)
                 && (salesSlip1.EstimateNote5 == salesSlip2.EstimateNote5)
                 && (salesSlip1.EstimateValidityDate == salesSlip2.EstimateValidityDate)
                 && (salesSlip1.PartsNoPrtCd == salesSlip2.PartsNoPrtCd)
                 && (salesSlip1.OptionPringDivCd == salesSlip2.OptionPringDivCd)
                 && (salesSlip1.RateUseCode == salesSlip2.RateUseCode)
                 && (salesSlip1.InputMode == salesSlip2.InputMode)
                 && (salesSlip1.SalesSlipDisplay == salesSlip2.SalesSlipDisplay)
                 && (salesSlip1.AcptAnOdrStatusDisplay == salesSlip2.AcptAnOdrStatusDisplay)
                 && (salesSlip1.CustRateGrpCode == salesSlip2.CustRateGrpCode)
                 && (salesSlip1.ClaimName == salesSlip2.ClaimName)
                 && (salesSlip1.ClaimName2 == salesSlip2.ClaimName2)
                 && (salesSlip1.CreditMngCode == salesSlip2.CreditMngCode)
                 && (salesSlip1.TotalDay == salesSlip2.TotalDay)
                 && (salesSlip1.NTimeCalcStDate == salesSlip2.NTimeCalcStDate)
                 && (salesSlip1.TotalMoneyForGrossProfit == salesSlip2.TotalMoneyForGrossProfit)
                 && (salesSlip1.SectionName == salesSlip2.SectionName)
                 && (salesSlip1.SubSectionName == salesSlip2.SubSectionName)
                 && (salesSlip1.CarMngDivCd == salesSlip2.CarMngDivCd)
                 && (salesSlip1.SearchMode == salesSlip2.SearchMode)
                 && (salesSlip1.SearchCarMode == salesSlip2.SearchCarMode)
                 && (salesSlip1.SalesRate == salesSlip2.SalesRate)
                 && (salesSlip1.EstimateDtCreateDiv == salesSlip2.EstimateDtCreateDiv)
                 && (salesSlip1.CustOrderNoDispDiv == salesSlip2.CustOrderNoDispDiv)
                 && (salesSlip1.CustWarehouseCd == salesSlip2.CustWarehouseCd)
                 && (salesSlip1.TransStopDate == salesSlip2.TransStopDate)
                //>>>2010/02/26
                 && (salesSlip1.OnlineKindDiv == salesSlip2.OnlineKindDiv)
                 && (salesSlip1.InqOriginalEpCd.Trim() == salesSlip2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (salesSlip1.InqOriginalSecCd == salesSlip2.InqOriginalSecCd)
                 && (salesSlip1.AnswerDiv == salesSlip2.AnswerDiv)
                 && (salesSlip1.InquiryNumber == salesSlip2.InquiryNumber)
                //<<<2010/02/26
                //>>>2010/04/08
                 && (salesSlip1.InqOrdDivCd == salesSlip2.InqOrdDivCd)
                //<<<2010/04/08
                 && (salesSlip1.EnterpriseName == salesSlip2.EnterpriseName)
                 && (salesSlip1.UpdEmployeeName == salesSlip2.UpdEmployeeName)
                 && (salesSlip1.DetailRowCountForReadSlip == salesSlip2.DetailRowCountForReadSlip) // ADD 2009/12/17
                 && (salesSlip1.StockUpdateFlag == salesSlip2.StockUpdateFlag) // ADD 2010/01/27
                 && (salesSlip1.AutoAnswerDivSCM == salesSlip2.AutoAnswerDivSCM) // add 2011/07/18 ���R
                 && (salesSlip1.ResultsAddUpSecNm == salesSlip2.ResultsAddUpSecNm));
        }
        /// <summary>
        /// ����f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesSlip�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlip�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalesSlip target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.DebitNLnkSalesSlNum != target.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.SalesGoodsCd != target.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SalesSlipUpdateCd != target.SalesSlipUpdateCd) resList.Add("SalesSlipUpdateCd");
            if (this.SearchSlipDate != target.SearchSlipDate) resList.Add("SearchSlipDate");
            if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.PreSalesDate != target.PreSalesDate) resList.Add("PreSalesDate"); // ADD 2011/12/15
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.DelayPaymentDiv != target.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (this.EstimateFormNo != target.EstimateFormNo) resList.Add("EstimateFormNo");
            if (this.EstimateDivide != target.EstimateDivide) resList.Add("EstimateDivide");
            if (this.InputAgenCd != target.InputAgenCd) resList.Add("InputAgenCd");
            if (this.InputAgenNm != target.InputAgenNm) resList.Add("InputAgenNm");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TtlAmntDispRateApy != target.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (this.SalesTotalTaxInc != target.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
            if (this.SalesTotalTaxExc != target.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (this.SalesPrtTotalTaxInc != target.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
            if (this.SalesPrtTotalTaxExc != target.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
            if (this.SalesWorkTotalTaxInc != target.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
            if (this.SalesWorkTotalTaxExc != target.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
            if (this.SalesSubtotalTaxInc != target.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
            if (this.SalesSubtotalTaxExc != target.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
            if (this.SalesPrtSubttlInc != target.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
            if (this.SalesPrtSubttlExc != target.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
            if (this.SalesWorkSubttlInc != target.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
            if (this.SalesWorkSubttlExc != target.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
            if (this.SalesNetPrice != target.SalesNetPrice) resList.Add("SalesNetPrice");
            if (this.SalesSubtotalTax != target.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
            if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (this.SalSubttlSubToTaxFre != target.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
            if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
            if (this.SalAmntConsTaxInclu != target.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
            if (this.SalesDisTtlTaxExc != target.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
            if (this.ItdedSalesDisOutTax != target.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
            if (this.ItdedSalesDisInTax != target.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
            if (this.ItdedPartsDisOutTax != target.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
            if (this.ItdedPartsDisInTax != target.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
            if (this.ItdedWorkDisOutTax != target.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
            if (this.ItdedWorkDisInTax != target.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
            if (this.ItdedSalesDisTaxFre != target.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
            if (this.SalesDisOutTax != target.SalesDisOutTax) resList.Add("SalesDisOutTax");
            if (this.SalesDisTtlTaxInclu != target.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
            if (this.PartsDiscountRate != target.PartsDiscountRate) resList.Add("PartsDiscountRate");
            if (this.RavorDiscountRate != target.RavorDiscountRate) resList.Add("RavorDiscountRate");
            if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.AccRecConsTax != target.AccRecConsTax) resList.Add("AccRecConsTax");
            if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
            if (this.AutoDepositNoteDiv != target.AutoDepositNoteDiv) resList.Add("AutoDepositNoteDiv"); // ADD 2013/01/18 �c���� Redmine#33797
            if (this.AutoDepositSlipNo != target.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
            if (this.DepositAllowanceTtl != target.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
            if (this.CustSlipNo != target.CustSlipNo) resList.Add("CustSlipNo");
            if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
            if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.CarSlipNote != target.CarSlipNote) resList.Add("CarSlipNote");   // ADD 2009/09/08
            if (this.Mileage != target.Mileage) resList.Add("Mileage");   // ADD 2009/09/08
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            // --- ADD 2009/12/23 ---------->>>>>
            if (this.SlipNoteCode != target.SlipNoteCode) resList.Add("SlipNoteCode");
            if (this.SlipNote2Code != target.SlipNote2Code) resList.Add("SlipNote2Code");
            if (this.SlipNote3Code != target.SlipNote3Code) resList.Add("SlipNote3Code");
            // --- ADD 2009/12/23 ----------<<<<<
            if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
            if (this.RegiProcDate != target.RegiProcDate) resList.Add("RegiProcDate");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.PosReceiptNo != target.PosReceiptNo) resList.Add("PosReceiptNo");
            if (this.DetailRowCount != target.DetailRowCount) resList.Add("DetailRowCount");
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.SlipPrintDivCd != target.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (this.SalesSlipPrintDate != target.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.OrderNumber != target.OrderNumber) resList.Add("OrderNumber");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.ReconcileFlag != target.ReconcileFlag) resList.Add("ReconcileFlag");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.CompleteCd != target.CompleteCd) resList.Add("CompleteCd");
            if (this.SalesPriceFracProcCd != target.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
            if (this.StockGoodsTtlTaxExc != target.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
            if (this.PureGoodsTtlTaxExc != target.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
            if (this.ListPricePrintDiv != target.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.EstimaTaxDivCd != target.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
            if (this.EstimateFormPrtCd != target.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
            if (this.EstimateSubject != target.EstimateSubject) resList.Add("EstimateSubject");
            if (this.Footnotes1 != target.Footnotes1) resList.Add("Footnotes1");
            if (this.Footnotes2 != target.Footnotes2) resList.Add("Footnotes2");
            if (this.EstimateTitle1 != target.EstimateTitle1) resList.Add("EstimateTitle1");
            if (this.EstimateTitle2 != target.EstimateTitle2) resList.Add("EstimateTitle2");
            if (this.EstimateTitle3 != target.EstimateTitle3) resList.Add("EstimateTitle3");
            if (this.EstimateTitle4 != target.EstimateTitle4) resList.Add("EstimateTitle4");
            if (this.EstimateTitle5 != target.EstimateTitle5) resList.Add("EstimateTitle5");
            if (this.EstimateNote1 != target.EstimateNote1) resList.Add("EstimateNote1");
            if (this.EstimateNote2 != target.EstimateNote2) resList.Add("EstimateNote2");
            if (this.EstimateNote3 != target.EstimateNote3) resList.Add("EstimateNote3");
            if (this.EstimateNote4 != target.EstimateNote4) resList.Add("EstimateNote4");
            if (this.EstimateNote5 != target.EstimateNote5) resList.Add("EstimateNote5");
            if (this.EstimateValidityDate != target.EstimateValidityDate) resList.Add("EstimateValidityDate");
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (this.OptionPringDivCd != target.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (this.RateUseCode != target.RateUseCode) resList.Add("RateUseCode");
            if (this.InputMode != target.InputMode) resList.Add("InputMode");
            if (this.SalesSlipDisplay != target.SalesSlipDisplay) resList.Add("SalesSlipDisplay");
            if (this.AcptAnOdrStatusDisplay != target.AcptAnOdrStatusDisplay) resList.Add("AcptAnOdrStatusDisplay");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.CreditMngCode != target.CreditMngCode) resList.Add("CreditMngCode");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (this.TotalMoneyForGrossProfit != target.TotalMoneyForGrossProfit) resList.Add("TotalMoneyForGrossProfit");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.SubSectionName != target.SubSectionName) resList.Add("SubSectionName");
            if (this.CarMngDivCd != target.CarMngDivCd) resList.Add("CarMngDivCd");
            if (this.SearchMode != target.SearchMode) resList.Add("SearchMode");
            if (this.SearchCarMode != target.SearchCarMode) resList.Add("SearchCarMode");
            if (this.SalesRate != target.SalesRate) resList.Add("SalesRate");
            if (this.EstimateDtCreateDiv != target.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (this.CustOrderNoDispDiv != target.CustOrderNoDispDiv) resList.Add("CustOrderNoDispDiv");
            if (this.CustWarehouseCd != target.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (this.TransStopDate != target.TransStopDate) resList.Add("TransStopDate");
            //>>>2010/02/26
            if (this.OnlineKindDiv != target.OnlineKindDiv) resList.Add("OnlineKindDiv");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.AnswerDiv != target.AnswerDiv) resList.Add("AnswerDiv");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            //<<<2010/02/26
            //>>>2010/04/08
            if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
            //<<<2010/04/08
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (this.DetailRowCountForReadSlip != target.DetailRowCountForReadSlip) resList.Add("DetailRowCountForReadSlip"); // ADD 2009/12/17
            if (this.StockUpdateFlag != target.StockUpdateFlag) resList.Add("StockUpdateFlag"); // ADD 2010/01/27
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); // add 2011/07/18 ���R
            return resList;
        }

        /// <summary>
        /// ����f�[�^��r����
        /// </summary>
        /// <param name="salesSlip1">��r����SalesSlip�N���X�̃C���X�^���X</param>
        /// <param name="salesSlip2">��r����SalesSlip�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesSlip�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalesSlip salesSlip1, SalesSlip salesSlip2)
        {
            ArrayList resList = new ArrayList();
            if (salesSlip1.CreateDateTime != salesSlip2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesSlip1.UpdateDateTime != salesSlip2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesSlip1.EnterpriseCode != salesSlip2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesSlip1.FileHeaderGuid != salesSlip2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesSlip1.UpdEmployeeCode != salesSlip2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesSlip1.UpdAssemblyId1 != salesSlip2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesSlip1.UpdAssemblyId2 != salesSlip2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesSlip1.LogicalDeleteCode != salesSlip2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesSlip1.AcptAnOdrStatus != salesSlip2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (salesSlip1.SalesSlipNum != salesSlip2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (salesSlip1.SectionCode != salesSlip2.SectionCode) resList.Add("SectionCode");
            if (salesSlip1.SubSectionCode != salesSlip2.SubSectionCode) resList.Add("SubSectionCode");
            if (salesSlip1.DebitNoteDiv != salesSlip2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (salesSlip1.DebitNLnkSalesSlNum != salesSlip2.DebitNLnkSalesSlNum) resList.Add("DebitNLnkSalesSlNum");
            if (salesSlip1.SalesSlipCd != salesSlip2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (salesSlip1.SalesGoodsCd != salesSlip2.SalesGoodsCd) resList.Add("SalesGoodsCd");
            if (salesSlip1.AccRecDivCd != salesSlip2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (salesSlip1.SalesInpSecCd != salesSlip2.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (salesSlip1.DemandAddUpSecCd != salesSlip2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (salesSlip1.ResultsAddUpSecCd != salesSlip2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (salesSlip1.UpdateSecCd != salesSlip2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (salesSlip1.SalesSlipUpdateCd != salesSlip2.SalesSlipUpdateCd) resList.Add("SalesSlipUpdateCd");
            if (salesSlip1.SearchSlipDate != salesSlip2.SearchSlipDate) resList.Add("SearchSlipDate");
            if (salesSlip1.ShipmentDay != salesSlip2.ShipmentDay) resList.Add("ShipmentDay");
            if (salesSlip1.SalesDate != salesSlip2.SalesDate) resList.Add("SalesDate");
            if (salesSlip1.PreSalesDate != salesSlip2.PreSalesDate) resList.Add("PreSalesDate"); // ADD 2011/12/15
            if (salesSlip1.AddUpADate != salesSlip2.AddUpADate) resList.Add("AddUpADate");
            if (salesSlip1.DelayPaymentDiv != salesSlip2.DelayPaymentDiv) resList.Add("DelayPaymentDiv");
            if (salesSlip1.EstimateFormNo != salesSlip2.EstimateFormNo) resList.Add("EstimateFormNo");
            if (salesSlip1.EstimateDivide != salesSlip2.EstimateDivide) resList.Add("EstimateDivide");
            if (salesSlip1.InputAgenCd != salesSlip2.InputAgenCd) resList.Add("InputAgenCd");
            if (salesSlip1.InputAgenNm != salesSlip2.InputAgenNm) resList.Add("InputAgenNm");
            if (salesSlip1.SalesInputCode != salesSlip2.SalesInputCode) resList.Add("SalesInputCode");
            if (salesSlip1.SalesInputName != salesSlip2.SalesInputName) resList.Add("SalesInputName");
            if (salesSlip1.FrontEmployeeCd != salesSlip2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (salesSlip1.FrontEmployeeNm != salesSlip2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (salesSlip1.SalesEmployeeCd != salesSlip2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (salesSlip1.SalesEmployeeNm != salesSlip2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (salesSlip1.TotalAmountDispWayCd != salesSlip2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (salesSlip1.TtlAmntDispRateApy != salesSlip2.TtlAmntDispRateApy) resList.Add("TtlAmntDispRateApy");
            if (salesSlip1.SalesTotalTaxInc != salesSlip2.SalesTotalTaxInc) resList.Add("SalesTotalTaxInc");
            if (salesSlip1.SalesTotalTaxExc != salesSlip2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (salesSlip1.SalesPrtTotalTaxInc != salesSlip2.SalesPrtTotalTaxInc) resList.Add("SalesPrtTotalTaxInc");
            if (salesSlip1.SalesPrtTotalTaxExc != salesSlip2.SalesPrtTotalTaxExc) resList.Add("SalesPrtTotalTaxExc");
            if (salesSlip1.SalesWorkTotalTaxInc != salesSlip2.SalesWorkTotalTaxInc) resList.Add("SalesWorkTotalTaxInc");
            if (salesSlip1.SalesWorkTotalTaxExc != salesSlip2.SalesWorkTotalTaxExc) resList.Add("SalesWorkTotalTaxExc");
            if (salesSlip1.SalesSubtotalTaxInc != salesSlip2.SalesSubtotalTaxInc) resList.Add("SalesSubtotalTaxInc");
            if (salesSlip1.SalesSubtotalTaxExc != salesSlip2.SalesSubtotalTaxExc) resList.Add("SalesSubtotalTaxExc");
            if (salesSlip1.SalesPrtSubttlInc != salesSlip2.SalesPrtSubttlInc) resList.Add("SalesPrtSubttlInc");
            if (salesSlip1.SalesPrtSubttlExc != salesSlip2.SalesPrtSubttlExc) resList.Add("SalesPrtSubttlExc");
            if (salesSlip1.SalesWorkSubttlInc != salesSlip2.SalesWorkSubttlInc) resList.Add("SalesWorkSubttlInc");
            if (salesSlip1.SalesWorkSubttlExc != salesSlip2.SalesWorkSubttlExc) resList.Add("SalesWorkSubttlExc");
            if (salesSlip1.SalesNetPrice != salesSlip2.SalesNetPrice) resList.Add("SalesNetPrice");
            if (salesSlip1.SalesSubtotalTax != salesSlip2.SalesSubtotalTax) resList.Add("SalesSubtotalTax");
            if (salesSlip1.ItdedSalesOutTax != salesSlip2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (salesSlip1.ItdedSalesInTax != salesSlip2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (salesSlip1.SalSubttlSubToTaxFre != salesSlip2.SalSubttlSubToTaxFre) resList.Add("SalSubttlSubToTaxFre");
            if (salesSlip1.SalesOutTax != salesSlip2.SalesOutTax) resList.Add("SalesOutTax");
            if (salesSlip1.SalAmntConsTaxInclu != salesSlip2.SalAmntConsTaxInclu) resList.Add("SalAmntConsTaxInclu");
            if (salesSlip1.SalesDisTtlTaxExc != salesSlip2.SalesDisTtlTaxExc) resList.Add("SalesDisTtlTaxExc");
            if (salesSlip1.ItdedSalesDisOutTax != salesSlip2.ItdedSalesDisOutTax) resList.Add("ItdedSalesDisOutTax");
            if (salesSlip1.ItdedSalesDisInTax != salesSlip2.ItdedSalesDisInTax) resList.Add("ItdedSalesDisInTax");
            if (salesSlip1.ItdedPartsDisOutTax != salesSlip2.ItdedPartsDisOutTax) resList.Add("ItdedPartsDisOutTax");
            if (salesSlip1.ItdedPartsDisInTax != salesSlip2.ItdedPartsDisInTax) resList.Add("ItdedPartsDisInTax");
            if (salesSlip1.ItdedWorkDisOutTax != salesSlip2.ItdedWorkDisOutTax) resList.Add("ItdedWorkDisOutTax");
            if (salesSlip1.ItdedWorkDisInTax != salesSlip2.ItdedWorkDisInTax) resList.Add("ItdedWorkDisInTax");
            if (salesSlip1.ItdedSalesDisTaxFre != salesSlip2.ItdedSalesDisTaxFre) resList.Add("ItdedSalesDisTaxFre");
            if (salesSlip1.SalesDisOutTax != salesSlip2.SalesDisOutTax) resList.Add("SalesDisOutTax");
            if (salesSlip1.SalesDisTtlTaxInclu != salesSlip2.SalesDisTtlTaxInclu) resList.Add("SalesDisTtlTaxInclu");
            if (salesSlip1.PartsDiscountRate != salesSlip2.PartsDiscountRate) resList.Add("PartsDiscountRate");
            if (salesSlip1.RavorDiscountRate != salesSlip2.RavorDiscountRate) resList.Add("RavorDiscountRate");
            if (salesSlip1.TotalCost != salesSlip2.TotalCost) resList.Add("TotalCost");
            if (salesSlip1.ConsTaxLayMethod != salesSlip2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (salesSlip1.ConsTaxRate != salesSlip2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (salesSlip1.FractionProcCd != salesSlip2.FractionProcCd) resList.Add("FractionProcCd");
            if (salesSlip1.AccRecConsTax != salesSlip2.AccRecConsTax) resList.Add("AccRecConsTax");
            if (salesSlip1.AutoDepositCd != salesSlip2.AutoDepositCd) resList.Add("AutoDepositCd");
            if (salesSlip1.AutoDepositNoteDiv != salesSlip2.AutoDepositNoteDiv) resList.Add("AutoDepositNoteDiv"); // ADD 2013/01/18 �c���� Redmine#33797
            if (salesSlip1.AutoDepositSlipNo != salesSlip2.AutoDepositSlipNo) resList.Add("AutoDepositSlipNo");
            if (salesSlip1.DepositAllowanceTtl != salesSlip2.DepositAllowanceTtl) resList.Add("DepositAllowanceTtl");
            if (salesSlip1.DepositAlwcBlnce != salesSlip2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (salesSlip1.ClaimCode != salesSlip2.ClaimCode) resList.Add("ClaimCode");
            if (salesSlip1.ClaimSnm != salesSlip2.ClaimSnm) resList.Add("ClaimSnm");
            if (salesSlip1.CustomerCode != salesSlip2.CustomerCode) resList.Add("CustomerCode");
            if (salesSlip1.CustomerName != salesSlip2.CustomerName) resList.Add("CustomerName");
            if (salesSlip1.CustomerName2 != salesSlip2.CustomerName2) resList.Add("CustomerName2");
            if (salesSlip1.CustomerSnm != salesSlip2.CustomerSnm) resList.Add("CustomerSnm");
            if (salesSlip1.HonorificTitle != salesSlip2.HonorificTitle) resList.Add("HonorificTitle");
            if (salesSlip1.OutputNameCode != salesSlip2.OutputNameCode) resList.Add("OutputNameCode");
            if (salesSlip1.OutputName != salesSlip2.OutputName) resList.Add("OutputName");
            if (salesSlip1.CustSlipNo != salesSlip2.CustSlipNo) resList.Add("CustSlipNo");
            if (salesSlip1.SlipAddressDiv != salesSlip2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (salesSlip1.AddresseeCode != salesSlip2.AddresseeCode) resList.Add("AddresseeCode");
            if (salesSlip1.AddresseeName != salesSlip2.AddresseeName) resList.Add("AddresseeName");
            if (salesSlip1.AddresseeName2 != salesSlip2.AddresseeName2) resList.Add("AddresseeName2");
            if (salesSlip1.AddresseePostNo != salesSlip2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (salesSlip1.AddresseeAddr1 != salesSlip2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (salesSlip1.AddresseeAddr3 != salesSlip2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (salesSlip1.AddresseeAddr4 != salesSlip2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (salesSlip1.AddresseeTelNo != salesSlip2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (salesSlip1.AddresseeFaxNo != salesSlip2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (salesSlip1.PartySaleSlipNum != salesSlip2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (salesSlip1.CarSlipNote != salesSlip2.CarSlipNote) resList.Add("CarSlipNote");   // ADD 2009/09/08
            if (salesSlip1.Mileage != salesSlip2.Mileage) resList.Add("Mileage");   // ADD 2009/09/08
            if (salesSlip1.SlipNote != salesSlip2.SlipNote) resList.Add("SlipNote");
            if (salesSlip1.SlipNote2 != salesSlip2.SlipNote2) resList.Add("SlipNote2");
            if (salesSlip1.SlipNote3 != salesSlip2.SlipNote3) resList.Add("SlipNote3");
            // --- ADD 2009/12/23 ---------->>>>>
            if (salesSlip1.SlipNoteCode != salesSlip2.SlipNoteCode) resList.Add("SlipNoteCode");
            if (salesSlip1.SlipNote2Code != salesSlip2.SlipNote2Code) resList.Add("SlipNote2Code");
            if (salesSlip1.SlipNote3Code != salesSlip2.SlipNote3Code) resList.Add("SlipNote3Code");
            // --- ADD 2009/12/23 ----------<<<<<
            if (salesSlip1.RetGoodsReasonDiv != salesSlip2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (salesSlip1.RetGoodsReason != salesSlip2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (salesSlip1.RegiProcDate != salesSlip2.RegiProcDate) resList.Add("RegiProcDate");
            if (salesSlip1.CashRegisterNo != salesSlip2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (salesSlip1.PosReceiptNo != salesSlip2.PosReceiptNo) resList.Add("PosReceiptNo");
            if (salesSlip1.DetailRowCount != salesSlip2.DetailRowCount) resList.Add("DetailRowCount");
            if (salesSlip1.EdiSendDate != salesSlip2.EdiSendDate) resList.Add("EdiSendDate");
            if (salesSlip1.EdiTakeInDate != salesSlip2.EdiTakeInDate) resList.Add("EdiTakeInDate");
            if (salesSlip1.UoeRemark1 != salesSlip2.UoeRemark1) resList.Add("UoeRemark1");
            if (salesSlip1.UoeRemark2 != salesSlip2.UoeRemark2) resList.Add("UoeRemark2");
            if (salesSlip1.SlipPrintDivCd != salesSlip2.SlipPrintDivCd) resList.Add("SlipPrintDivCd");
            if (salesSlip1.SlipPrintFinishCd != salesSlip2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (salesSlip1.SalesSlipPrintDate != salesSlip2.SalesSlipPrintDate) resList.Add("SalesSlipPrintDate");
            if (salesSlip1.BusinessTypeCode != salesSlip2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (salesSlip1.BusinessTypeName != salesSlip2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (salesSlip1.OrderNumber != salesSlip2.OrderNumber) resList.Add("OrderNumber");
            if (salesSlip1.DeliveredGoodsDiv != salesSlip2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (salesSlip1.DeliveredGoodsDivNm != salesSlip2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (salesSlip1.SalesAreaCode != salesSlip2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (salesSlip1.SalesAreaName != salesSlip2.SalesAreaName) resList.Add("SalesAreaName");
            if (salesSlip1.ReconcileFlag != salesSlip2.ReconcileFlag) resList.Add("ReconcileFlag");
            if (salesSlip1.SlipPrtSetPaperId != salesSlip2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (salesSlip1.CompleteCd != salesSlip2.CompleteCd) resList.Add("CompleteCd");
            if (salesSlip1.SalesPriceFracProcCd != salesSlip2.SalesPriceFracProcCd) resList.Add("SalesPriceFracProcCd");
            if (salesSlip1.StockGoodsTtlTaxExc != salesSlip2.StockGoodsTtlTaxExc) resList.Add("StockGoodsTtlTaxExc");
            if (salesSlip1.PureGoodsTtlTaxExc != salesSlip2.PureGoodsTtlTaxExc) resList.Add("PureGoodsTtlTaxExc");
            if (salesSlip1.ListPricePrintDiv != salesSlip2.ListPricePrintDiv) resList.Add("ListPricePrintDiv");
            if (salesSlip1.EraNameDispCd1 != salesSlip2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (salesSlip1.EstimaTaxDivCd != salesSlip2.EstimaTaxDivCd) resList.Add("EstimaTaxDivCd");
            if (salesSlip1.EstimateFormPrtCd != salesSlip2.EstimateFormPrtCd) resList.Add("EstimateFormPrtCd");
            if (salesSlip1.EstimateSubject != salesSlip2.EstimateSubject) resList.Add("EstimateSubject");
            if (salesSlip1.Footnotes1 != salesSlip2.Footnotes1) resList.Add("Footnotes1");
            if (salesSlip1.Footnotes2 != salesSlip2.Footnotes2) resList.Add("Footnotes2");
            if (salesSlip1.EstimateTitle1 != salesSlip2.EstimateTitle1) resList.Add("EstimateTitle1");
            if (salesSlip1.EstimateTitle2 != salesSlip2.EstimateTitle2) resList.Add("EstimateTitle2");
            if (salesSlip1.EstimateTitle3 != salesSlip2.EstimateTitle3) resList.Add("EstimateTitle3");
            if (salesSlip1.EstimateTitle4 != salesSlip2.EstimateTitle4) resList.Add("EstimateTitle4");
            if (salesSlip1.EstimateTitle5 != salesSlip2.EstimateTitle5) resList.Add("EstimateTitle5");
            if (salesSlip1.EstimateNote1 != salesSlip2.EstimateNote1) resList.Add("EstimateNote1");
            if (salesSlip1.EstimateNote2 != salesSlip2.EstimateNote2) resList.Add("EstimateNote2");
            if (salesSlip1.EstimateNote3 != salesSlip2.EstimateNote3) resList.Add("EstimateNote3");
            if (salesSlip1.EstimateNote4 != salesSlip2.EstimateNote4) resList.Add("EstimateNote4");
            if (salesSlip1.EstimateNote5 != salesSlip2.EstimateNote5) resList.Add("EstimateNote5");
            if (salesSlip1.EstimateValidityDate != salesSlip2.EstimateValidityDate) resList.Add("EstimateValidityDate");
            if (salesSlip1.PartsNoPrtCd != salesSlip2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (salesSlip1.OptionPringDivCd != salesSlip2.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (salesSlip1.RateUseCode != salesSlip2.RateUseCode) resList.Add("RateUseCode");
            if (salesSlip1.InputMode != salesSlip2.InputMode) resList.Add("InputMode");
            if (salesSlip1.SalesSlipDisplay != salesSlip2.SalesSlipDisplay) resList.Add("SalesSlipDisplay");
            if (salesSlip1.AcptAnOdrStatusDisplay != salesSlip2.AcptAnOdrStatusDisplay) resList.Add("AcptAnOdrStatusDisplay");
            if (salesSlip1.CustRateGrpCode != salesSlip2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (salesSlip1.ClaimName != salesSlip2.ClaimName) resList.Add("ClaimName");
            if (salesSlip1.ClaimName2 != salesSlip2.ClaimName2) resList.Add("ClaimName2");
            if (salesSlip1.CreditMngCode != salesSlip2.CreditMngCode) resList.Add("CreditMngCode");
            if (salesSlip1.TotalDay != salesSlip2.TotalDay) resList.Add("TotalDay");
            if (salesSlip1.NTimeCalcStDate != salesSlip2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (salesSlip1.TotalMoneyForGrossProfit != salesSlip2.TotalMoneyForGrossProfit) resList.Add("TotalMoneyForGrossProfit");
            if (salesSlip1.SectionName != salesSlip2.SectionName) resList.Add("SectionName");
            if (salesSlip1.SubSectionName != salesSlip2.SubSectionName) resList.Add("SubSectionName");
            if (salesSlip1.CarMngDivCd != salesSlip2.CarMngDivCd) resList.Add("CarMngDivCd");
            if (salesSlip1.SearchMode != salesSlip2.SearchMode) resList.Add("SearchMode");
            if (salesSlip1.SearchCarMode != salesSlip2.SearchCarMode) resList.Add("SearchCarMode");
            if (salesSlip1.SalesRate != salesSlip2.SalesRate) resList.Add("SalesRate");
            if (salesSlip1.EstimateDtCreateDiv != salesSlip2.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (salesSlip1.CustOrderNoDispDiv != salesSlip2.CustOrderNoDispDiv) resList.Add("CustOrderNoDispDiv");
            if (salesSlip1.CustWarehouseCd != salesSlip2.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (salesSlip1.TransStopDate != salesSlip2.TransStopDate) resList.Add("TransStopDate");
            //<<<2010/02/26
            if (salesSlip1.OnlineKindDiv != salesSlip2.OnlineKindDiv) resList.Add("OnlineKindDiv");
            if (salesSlip1.InqOriginalEpCd.Trim() != salesSlip2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (salesSlip1.InqOriginalSecCd != salesSlip2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (salesSlip1.AnswerDiv != salesSlip2.AnswerDiv) resList.Add("AnswerDiv");
            if (salesSlip1.InquiryNumber != salesSlip2.InquiryNumber) resList.Add("InquiryNumber");
            //<<<2010/02/26
            //>>>2010/04/08
            if (salesSlip1.InqOrdDivCd != salesSlip2.InqOrdDivCd) resList.Add("InqOrdDivCd");
            //<<<2010/04/08
            if (salesSlip1.EnterpriseName != salesSlip2.EnterpriseName) resList.Add("EnterpriseName");
            if (salesSlip1.UpdEmployeeName != salesSlip2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (salesSlip1.ResultsAddUpSecNm != salesSlip2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (salesSlip1.DetailRowCountForReadSlip != salesSlip2.DetailRowCountForReadSlip) resList.Add("DetailRowCountForReadSlip"); // ADD 2009/12/17
            if (salesSlip1.StockUpdateFlag != salesSlip2.StockUpdateFlag) resList.Add("StockUpdateFlag"); // ADD 2010/01/27
            if (salesSlip1.AutoAnswerDivSCM != salesSlip2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM"); // add 2011/07/18 ���R
            return resList;
        }
    }
}
