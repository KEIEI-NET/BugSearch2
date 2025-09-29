using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EBooksFrePBillDetailWork
    /// <summary>
    ///                      ���R���[(������)���׃f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[(������)���׃f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Genarated Date   :   2022/03/07  (CSharp File Generated Date)</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EBooksFrePBillDetailWork
    {
        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _sALESSLIPRF_ACPTANODRSTATUSRF;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _sALESSLIPRF_SALESSLIPNUMRF = "";

        /// <summary>���_�R�[�h</summary>
        private string _sALESSLIPRF_SECTIONCODERF = "";

        /// <summary>����R�[�h</summary>
        private Int32 _sALESSLIPRF_SUBSECTIONCODERF;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _sALESSLIPRF_DEBITNOTEDIVRF;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _sALESSLIPRF_SALESSLIPCDRF;

        /// <summary>���㏤�i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</remarks>
        private Int32 _sALESSLIPRF_SALESGOODSCDRF;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _sALESSLIPRF_ACCRECDIVCDRF;

        /// <summary>�����v�㋒�_�R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _sALESSLIPRF_DEMANDADDUPSECCDRF = "";

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_SALESDATERF;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_ADDUPADATERF;

        /// <summary>���͒S���҃R�[�h</summary>
        /// <remarks>���O�C���S���ҁi�t�r�a�j</remarks>
        private string _sALESSLIPRF_INPUTAGENCDRF = "";

        /// <summary>���͒S���Җ���</summary>
        private string _sALESSLIPRF_INPUTAGENNMRF = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _sALESSLIPRF_SALESINPUTCODERF = "";

        /// <summary>������͎Җ���</summary>
        private string _sALESSLIPRF_SALESINPUTNAMERF = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _sALESSLIPRF_FRONTEMPLOYEECDRF = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _sALESSLIPRF_FRONTEMPLOYEENMRF = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _sALESSLIPRF_SALESEMPLOYEECDRF = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _sALESSLIPRF_SALESEMPLOYEENMRF = "";

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXINCRF;

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXEXCRF;

        /// <summary>���㕔�i���v�i�ō��݁j</summary>
        /// <remarks>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</remarks>
        private Int64 _sALESSLIPRF_SALESPRTTOTALTAXINCRF;

        /// <summary>���㕔�i���v�i�Ŕ����j</summary>
        /// <remarks>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</remarks>
        private Int64 _sALESSLIPRF_SALESPRTTOTALTAXEXCRF;

        /// <summary>�����ƍ��v�i�ō��݁j</summary>
        /// <remarks>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</remarks>
        private Int64 _sALESSLIPRF_SALESWORKTOTALTAXINCRF;

        /// <summary>�����ƍ��v�i�Ŕ����j</summary>
        /// <remarks>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</remarks>
        private Int64 _sALESSLIPRF_SALESWORKTOTALTAXEXCRF;

        /// <summary>���㏬�v�i�ō��݁j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXINCRF;

        /// <summary>���㏬�v�i�Ŕ����j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXEXCRF;

        /// <summary>���㕔�i���v�i�ō��݁j</summary>
        /// <remarks>���i���׋��z�̐ō����v</remarks>
        private Int64 _sALESSLIPRF_SALESPRTSUBTTLINCRF;

        /// <summary>���㕔�i���v�i�Ŕ����j</summary>
        /// <remarks>���i���׋��z�̐Ŕ����v</remarks>
        private Int64 _sALESSLIPRF_SALESPRTSUBTTLEXCRF;

        /// <summary>�����Ə��v�i�ō��݁j</summary>
        /// <remarks>��Ɩ��׋��z�̐ō����v</remarks>
        private Int64 _sALESSLIPRF_SALESWORKSUBTTLINCRF;

        /// <summary>�����Ə��v�i�Ŕ����j</summary>
        /// <remarks>��Ɩ��׋��z�̐Ŕ����v</remarks>
        private Int64 _sALESSLIPRF_SALESWORKSUBTTLEXCRF;

        /// <summary>���㏬�v�i�Łj</summary>
        /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXRF;

        /// <summary>���i�l���Ώۊz���v�i�Ŕ����j</summary>
        /// <remarks>���i�l���z�i�Ŕ����j</remarks>
        private Int64 _sALESSLIPRF_ITDEDPARTSDISOUTTAXRF;

        /// <summary>���i�l���Ώۊz���v�i�ō��݁j</summary>
        /// <remarks>���i�l���z�i�ō��݁j</remarks>
        private Int64 _sALESSLIPRF_ITDEDPARTSDISINTAXRF;

        /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j</summary>
        /// <remarks>��ƒl���z�i�Ŕ����j</remarks>
        private Int64 _sALESSLIPRF_ITDEDWORKDISOUTTAXRF;

        /// <summary>��ƒl���Ώۊz���v�i�ō��݁j</summary>
        /// <remarks>��ƒl���z�i�ō��݁j</remarks>
        private Int64 _sALESSLIPRF_ITDEDWORKDISINTAXRF;

        /// <summary>���i�l����</summary>
        /// <remarks>���v�ɑ΂��Ă̕��i�l����</remarks>
        private Double _sALESSLIPRF_PARTSDISCOUNTRATERF;

        /// <summary>�H���l����</summary>
        /// <remarks>���v�ɑ΂��Ă̍H���l����</remarks>
        private Double _sALESSLIPRF_RAVORDISCOUNTRATERF;

        /// <summary>�������z�v</summary>
        private Int64 _sALESSLIPRF_TOTALCOSTRF;

        /// <summary>����Őŗ�</summary>
        private Double _sALESSLIPRF_CONSTAXRATERF;

        /// <summary>���������敪</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _sALESSLIPRF_AUTODEPOSITCDRF;

        /// <summary>���������`�[�ԍ�</summary>
        /// <remarks>�����������̓����`�[�ԍ�</remarks>
        private Int32 _sALESSLIPRF_AUTODEPOSITSLIPNORF;

        /// <summary>�����������v�z</summary>
        /// <remarks>�a����������v�z���܂�</remarks>
        private Int64 _sALESSLIPRF_DEPOSITALLOWANCETTLRF;

        /// <summary>���������c��</summary>
        private Int64 _sALESSLIPRF_DEPOSITALWCBLNCERF;

        /// <summary>������R�[�h</summary>
        private Int32 _sALESSLIPRF_CLAIMCODERF;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _sALESSLIPRF_CUSTOMERCODERF;

        /// <summary>���Ӑ於��</summary>
        private string _sALESSLIPRF_CUSTOMERNAMERF = "";

        /// <summary>���Ӑ於��2</summary>
        private string _sALESSLIPRF_CUSTOMERNAME2RF = "";

        /// <summary>���Ӑ旪��</summary>
        private string _sALESSLIPRF_CUSTOMERSNMRF = "";

        /// <summary>�h��</summary>
        private string _sALESSLIPRF_HONORIFICTITLERF = "";

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _sALESSLIPRF_ADDRESSEECODERF;

        /// <summary>�[�i�於��</summary>
        private string _sALESSLIPRF_ADDRESSEENAMERF = "";

        /// <summary>�[�i�於��2</summary>
        private string _sALESSLIPRF_ADDRESSEENAME2RF = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _sALESSLIPRF_PARTYSALESLIPNUMRF = "";

        /// <summary>�`�[���l</summary>
        private string _sALESSLIPRF_SLIPNOTERF = "";

        /// <summary>�`�[���l�Q</summary>
        private string _sALESSLIPRF_SLIPNOTE2RF = "";

        /// <summary>�`�[���l�R</summary>
        private string _sALESSLIPRF_SLIPNOTE3RF = "";

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _sALESSLIPRF_RETGOODSREASONDIVRF;

        /// <summary>�ԕi���R</summary>
        private string _sALESSLIPRF_RETGOODSREASONRF = "";

        /// <summary>���׍s��</summary>
        private Int32 _sALESSLIPRF_DETAILROWCOUNTRF;

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _sALESSLIPRF_UOEREMARK1RF = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _sALESSLIPRF_UOEREMARK2RF = "";

        /// <summary>�[�i�敪</summary>
        /// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
        private Int32 _sALESSLIPRF_DELIVEREDGOODSDIVRF;

        /// <summary>�[�i�敪����</summary>
        private string _sALESSLIPRF_DELIVEREDGOODSDIVNMRF = "";

        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j</summary>
        /// <remarks>�݌Ɏ��敪���O�̖��׋��z�̏W�v</remarks>
        private Int64 _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF;

        /// <summary>�������i���v���z�i�Ŕ��j</summary>
        /// <remarks>���i�������O�̖��׋��z�̏W�v</remarks>
        private Int64 _sALESSLIPRF_PUREGOODSTTLTAXEXCRF;

        /// <summary>�r���P</summary>
        private string _sALESSLIPRF_FOOTNOTES1RF = "";

        /// <summary>�r���Q</summary>
        private string _sALESSLIPRF_FOOTNOTES2RF = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sECDTL_SECTIONGUIDENMRF = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sECDTL_SECTIONGUIDESNMRF = "";

        /// <summary>���Ж��̃R�[�h1</summary>
        private Int32 _sECDTL_COMPANYNAMECD1RF;

        /// <summary>���㕔�喼��</summary>
        private string _sUBSAL_SUBSECTIONNAMERF = "";

        /// <summary>�󒍔ԍ�</summary>
        private Int32 _sALESDETAILRF_ACCEPTANORDERNORF;

        /// <summary>����s�ԍ�</summary>
        private Int32 _sALESDETAILRF_SALESROWNORF;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�q��[��(YYYYMMDD)</remarks>
        private Int32 _sALESDETAILRF_DELIGDSCMPLTDUEDATERF;

        /// <summary>���i����</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private Int32 _sALESDETAILRF_GOODSKINDCODERF;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _sALESDETAILRF_GOODSMAKERCDRF;

        /// <summary>���[�J�[����</summary>
        private string _sALESDETAILRF_MAKERNAMERF = "";

        /// <summary>���i�ԍ�</summary>
        private string _sALESDETAILRF_GOODSNORF = "";

        /// <summary>���i����</summary>
        private string _sALESDETAILRF_GOODSNAMERF = "";

        /// <summary>���i������</summary>
        private string _sALESDETAILRF_GOODSSHORTNAMERF = "";

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _sALESDETAILRF_GOODSLGROUPRF;

        /// <summary>���i�啪�ޖ���</summary>
        private string _sALESDETAILRF_GOODSLGROUPNAMERF = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ރR�[�h</remarks>
        private Int32 _sALESDETAILRF_GOODSMGROUPRF;

        /// <summary>���i�����ޖ���</summary>
        private string _sALESDETAILRF_GOODSMGROUPNAMERF = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _sALESDETAILRF_BLGROUPCODERF;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _sALESDETAILRF_BLGROUPNAMERF = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _sALESDETAILRF_BLGOODSCODERF;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _sALESDETAILRF_BLGOODSFULLNAMERF = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _sALESDETAILRF_ENTERPRISEGANRECODERF;

        /// <summary>���Е��ޖ���</summary>
        private string _sALESDETAILRF_ENTERPRISEGANRENAMERF = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _sALESDETAILRF_WAREHOUSECODERF = "";

        /// <summary>�q�ɖ���</summary>
        private string _sALESDETAILRF_WAREHOUSENAMERF = "";

        /// <summary>�q�ɒI��</summary>
        private string _sALESDETAILRF_WAREHOUSESHELFNORF = "";

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _sALESDETAILRF_SALESORDERDIVCDRF;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _sALESDETAILRF_OPENPRICEDIVRF;

        /// <summary>���i�|�������N</summary>
        /// <remarks>���i�̊|���p�����N</remarks>
        private string _sALESDETAILRF_GOODSRATERANKRF = "";

        /// <summary>�艿��</summary>
        private Double _sALESDETAILRF_LISTPRICERATERF;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXINCFLRF;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXEXCFLRF;

        /// <summary>������</summary>
        private Double _sALESDETAILRF_SALESRATERF;

        /// <summary>����P���i�ō��C�����j</summary>
        private Double _sALESDETAILRF_SALESUNPRCTAXINCFLRF;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _sALESDETAILRF_SALESUNPRCTAXEXCFLRF;

        /// <summary>������</summary>
        private Double _sALESDETAILRF_COSTRATERF;

        /// <summary>�����P��</summary>
        private Double _sALESDETAILRF_SALESUNITCOSTRF;

        /// <summary>BL���i�R�[�h�i����j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
        private Int32 _sALESDETAILRF_PRTBLGOODSCODERF;

        /// <summary>BL���i�R�[�h���́i����j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
        private string _sALESDETAILRF_PRTBLGOODSNAMERF = "";

        /// <summary>��ƍH��</summary>
        private Double _sALESDETAILRF_WORKMANHOURRF;

        /// <summary>�o�א�</summary>
        private Double _sALESDETAILRF_SHIPMENTCNTRF;

        /// <summary>������z�i�ō��݁j</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXINCRF;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXEXCRF;

        /// <summary>����</summary>
        private Int64 _sALESDETAILRF_COSTRF;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _sALESDETAILRF_TAXATIONDIVCDRF;

        /// <summary>�����`�[�ԍ��i���ׁj</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _sALESDETAILRF_PARTYSLIPNUMDTLRF = "";

        /// <summary>���ה��l</summary>
        private string _sALESDETAILRF_DTLNOTERF = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _sALESDETAILRF_SUPPLIERCDRF;

        /// <summary>�d���旪��</summary>
        private string _sALESDETAILRF_SUPPLIERSNMRF = "";

        /// <summary>�`�[�����P</summary>
        private string _sALESDETAILRF_SLIPMEMO1RF = "";

        /// <summary>�`�[�����Q</summary>
        private string _sALESDETAILRF_SLIPMEMO2RF = "";

        /// <summary>�`�[�����R</summary>
        private string _sALESDETAILRF_SLIPMEMO3RF = "";

        /// <summary>�Г������P</summary>
        private string _sALESDETAILRF_INSIDEMEMO1RF = "";

        /// <summary>�Г������Q</summary>
        private string _sALESDETAILRF_INSIDEMEMO2RF = "";

        /// <summary>�Г������R</summary>
        private string _sALESDETAILRF_INSIDEMEMO3RF = "";

        /// <summary>�ύX�O�艿</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _sALESDETAILRF_BFLISTPRICERF;

        /// <summary>�ύX�O����</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _sALESDETAILRF_BFSALESUNITPRICERF;

        /// <summary>�ύX�O����</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _sALESDETAILRF_BFUNITCOSTRF;

        /// <summary>�ꎮ���הԍ�</summary>
        /// <remarks>0:�ꎮ�Ȃ��@1�`�ꎮ�A��</remarks>
        private Int32 _sALESDETAILRF_CMPLTSALESROWNORF;

        /// <summary>���[�J�[�R�[�h�i�ꎮ�j</summary>
        private Int32 _sALESDETAILRF_CMPLTGOODSMAKERCDRF;

        /// <summary>���[�J�[���́i�ꎮ�j</summary>
        private string _sALESDETAILRF_CMPLTMAKERNAMERF = "";

        /// <summary>���i���́i�ꎮ�j</summary>
        private string _sALESDETAILRF_CMPLTGOODSNAMERF = "";

        /// <summary>���ʁi�ꎮ�j</summary>
        private Double _sALESDETAILRF_CMPLTSHIPMENTCNTRF;

        /// <summary>����P���i�ꎮ�j</summary>
        /// <remarks>������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</remarks>
        private Double _sALESDETAILRF_CMPLTSALESUNPRCFLRF;

        /// <summary>������z�i�ꎮ�j</summary>
        /// <remarks>������z�i�Ŕ����j�̓���ꎮ���ׂ̍��v</remarks>
        private Int64 _sALESDETAILRF_CMPLTSALESMONEYRF;

        /// <summary>�����P���i�ꎮ�j</summary>
        /// <remarks>�������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</remarks>
        private Double _sALESDETAILRF_CMPLTSALESUNITCOSTRF;

        /// <summary>�������z�i�ꎮ�j</summary>
        /// <remarks>�����̓���ꎮ���ׂ̍��v</remarks>
        private Int64 _sALESDETAILRF_CMPLTCOSTRF;

        /// <summary>�����`�[�ԍ��i�ꎮ�j</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _sALESDETAILRF_CMPLTPARTYSALSLNUMRF = "";

        /// <summary>�ꎮ���l</summary>
        private string _sALESDETAILRF_CMPLTNOTERF = "";

        /// <summary>�ԗ��Ǘ��ԍ�</summary>
        /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
        private Int32 _aCCEPTODRCARRF_CARMNGNORF;

        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _aCCEPTODRCARRF_CARMNGCODERF = "";

        /// <summary>���^�������ԍ�</summary>
        private Int32 _aCCEPTODRCARRF_NUMBERPLATE1CODERF;

        /// <summary>���^�����ǖ���</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE1NAMERF = "";

        /// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE2RF = "";

        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE3RF = "";

        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        private Int32 _aCCEPTODRCARRF_NUMBERPLATE4RF;

        /// <summary>���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aCCEPTODRCARRF_FIRSTENTRYDATERF;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _aCCEPTODRCARRF_MAKERCODERF;

        /// <summary>���[�J�[�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _aCCEPTODRCARRF_MAKERFULLNAMERF = "";

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _aCCEPTODRCARRF_MODELCODERF;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _aCCEPTODRCARRF_MODELSUBCODERF;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _aCCEPTODRCARRF_MODELFULLNAMERF = "";

        /// <summary>�r�K�X�L��</summary>
        private string _aCCEPTODRCARRF_EXHAUSTGASSIGNRF = "";

        /// <summary>�V���[�Y�^��</summary>
        private string _aCCEPTODRCARRF_SERIESMODELRF = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private string _aCCEPTODRCARRF_CATEGORYSIGNMODELRF = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _aCCEPTODRCARRF_FULLMODELRF = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _aCCEPTODRCARRF_MODELDESIGNATIONNORF;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _aCCEPTODRCARRF_CATEGORYNORF;

        /// <summary>�ԑ�^��</summary>
        private string _aCCEPTODRCARRF_FRAMEMODELRF = "";

        /// <summary>�ԑ�ԍ�</summary>
        /// <remarks>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</remarks>
        private string _aCCEPTODRCARRF_FRAMENORF = "";

        /// <summary>�ԑ�ԍ��i�����p�j</summary>
        /// <remarks>PM7�̎ԑ�ԍ��Ɠ���</remarks>
        private Int32 _aCCEPTODRCARRF_SEARCHFRAMENORF;

        /// <summary>�G���W���^������</summary>
        /// <remarks>�G���W������</remarks>
        private string _aCCEPTODRCARRF_ENGINEMODELNMRF = "";

        /// <summary>�֘A�^��</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _aCCEPTODRCARRF_RELEVANCEMODELRF = "";

        /// <summary>�T�u�Ԗ��R�[�h</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private Int32 _aCCEPTODRCARRF_SUBCARNMCDRF;

        /// <summary>�^���O���[�h����</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _aCCEPTODRCARRF_MODELGRADESNAMERF = "";

        /// <summary>�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _aCCEPTODRCARRF_COLORCODERF = "";

        /// <summary>�J���[����1</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        private string _aCCEPTODRCARRF_COLORNAME1RF = "";

        /// <summary>�g�����R�[�h</summary>
        private string _aCCEPTODRCARRF_TRIMCODERF = "";

        /// <summary>�g��������</summary>
        private string _aCCEPTODRCARRF_TRIMNAMERF = "";

        /// <summary>�ԗ����s����</summary>
        private Int32 _aCCEPTODRCARRF_MILEAGERF;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _dEPSITMAINRF_ACPTANODRSTATUSRF;

        /// <summary>�����`�[�ԍ�</summary>
        private Int32 _dEPSITMAINRF_DEPOSITSLIPNORF;

        /// <summary>����`�[�ԍ�</summary>
        private string _dEPSITMAINRF_SALESSLIPNUMRF = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _dEPSITMAINRF_ADDUPSECCODERF = "";

        /// <summary>����R�[�h</summary>
        private Int32 _dEPSITMAINRF_SUBSECTIONCODERF;

        /// <summary>�������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITMAINRF_DEPOSITDATERF;

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITMAINRF_ADDUPADATERF;

        /// <summary>�������z</summary>
        /// <remarks>�l���E�萔�����������z</remarks>
        private Int64 _dEPSITMAINRF_DEPOSITRF;

        /// <summary>�萔�������z</summary>
        private Int64 _dEPSITMAINRF_FEEDEPOSITRF;

        /// <summary>�l�������z</summary>
        private Int64 _dEPSITMAINRF_DISCOUNTDEPOSITRF;

        /// <summary>���������敪</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _dEPSITMAINRF_AUTODEPOSITCDRF;

        /// <summary>�a����敪</summary>
        /// <remarks>0:�ʏ����,1:�a�������</remarks>
        private Int32 _dEPSITMAINRF_DEPOSITCDRF;

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITMAINRF_DRAFTDRAWINGDATERF;

        /// <summary>��`���</summary>
        private Int32 _dEPSITMAINRF_DRAFTKINDRF;

        /// <summary>��`��ޖ���</summary>
        /// <remarks>�񑩁A�בցA���؎�</remarks>
        private string _dEPSITMAINRF_DRAFTKINDNAMERF = "";

        /// <summary>��`�敪����</summary>
        /// <remarks>���U�A��</remarks>
        private string _dEPSITMAINRF_DRAFTDIVIDENAMERF = "";

        /// <summary>��`�ԍ�</summary>
        private string _dEPSITMAINRF_DRAFTNORF = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _dEPSITMAINRF_CUSTOMERCODERF;

        /// <summary>������R�[�h</summary>
        /// <remarks>�����擾�Ӑ�</remarks>
        private Int32 _dEPSITMAINRF_CLAIMCODERF;

        /// <summary>�`�[�E�v</summary>
        private string _dEPSITMAINRF_OUTLINERF = "";

        /// <summary>�����������喼��</summary>
        private string _sUBDEP_SUBSECTIONNAMERF = "";

        /// <summary>�����`�[�ԍ�</summary>
        private Int32 _dEPSITDTLRF_DEPOSITSLIPNORF;

        /// <summary>�����s�ԍ�</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _dEPSITDTLRF_DEPOSITROWNORF;

        /// <summary>����R�[�h</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _dEPSITDTLRF_MONEYKINDCODERF;

        /// <summary>���햼��</summary>
        private string _dEPSITDTLRF_MONEYKINDNAMERF = "";

        /// <summary>����敪</summary>
        private Int32 _dEPSITDTLRF_MONEYKINDDIVRF;

        /// <summary>�������z</summary>
        private Int64 _dEPSITDTLRF_DEPOSITRF;

        /// <summary>�L������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dEPSITDTLRF_VALIDITYTERMRF;

        /// <summary>�󒍃X�e�[�^�X����</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _dADD_ACPTANODRSTATUSRF;

        /// <summary>�ԓ`�敪����</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _dADD_DEBITNOTEDIVRF;

        /// <summary>����`�[�敪����</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _dADD_SALESSLIPCDRF;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private Int32 _dADD_SALESDATERF;

        /// <summary>������t����N</summary>
        private Int32 _dADD_SALESDATEFYRF;

        /// <summary>������t����N��</summary>
        private Int32 _dADD_SALESDATEFSRF;

        /// <summary>������t�a��N</summary>
        private Int32 _dADD_SALESDATEFWRF;

        /// <summary>������t��</summary>
        private Int32 _dADD_SALESDATEFMRF;

        /// <summary>������t��</summary>
        private Int32 _dADD_SALESDATEFDRF;

        /// <summary>������t����</summary>
        private string _dADD_SALESDATEFGRF = "";

        /// <summary>������t����</summary>
        private string _dADD_SALESDATEFRRF = "";

        /// <summary>������t���e����(/)</summary>
        private string _dADD_SALESDATEFLSRF = "";

        /// <summary>������t���e����(.)</summary>
        private string _dADD_SALESDATEFLPRF = "";

        /// <summary>������t���e����(�N)</summary>
        private string _dADD_SALESDATEFLYRF = "";

        /// <summary>������t���e����(��)</summary>
        private string _dADD_SALESDATEFLMRF = "";

        /// <summary>������t���e����(��)</summary>
        private string _dADD_SALESDATEFLDRF = "";

        /// <summary>��񏤕i���v���z�i�Ŕ��j</summary>
        /// <remarks>�݌Ɏ��敪���O�łȂ����׋��z�̏W�v</remarks>
        private Int64 _dADD_STOCKGOODSTTLTAXEXCRF;

        /// <summary>�D�Ǐ��i���v���z�i�Ŕ��j</summary>
        /// <remarks>���i�������O�łȂ����׋��z�̏W�v</remarks>
        private Int64 _dADD_PUREGOODSTTLTAXEXCRF;

        /// <summary>���i��������</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private Int32 _dADD_GOODSKINDCODERF;

        /// <summary>����݌Ɏ�񂹋敪����</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _dADD_SALESORDERDIVCDRF;

        /// <summary>�I�[�v�����i�敪����</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _dADD_OPENPRICEDIVRF;

        /// <summary>�ېŋ敪����</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _dADD_TAXATIONDIVCDRF;

        /// <summary>���N�x����N</summary>
        private Int32 _dADD_FIRSTENTRYDATEFYRF;

        /// <summary>���N�x����N��</summary>
        private Int32 _dADD_FIRSTENTRYDATEFSRF;

        /// <summary>���N�x�a��N</summary>
        private Int32 _dADD_FIRSTENTRYDATEFWRF;

        /// <summary>���N�x��</summary>
        private Int32 _dADD_FIRSTENTRYDATEFMRF;

        /// <summary>���N�x����</summary>
        private string _dADD_FIRSTENTRYDATEFGRF = "";

        /// <summary>���N�x����</summary>
        private string _dADD_FIRSTENTRYDATEFRRF = "";

        /// <summary>���N�x���e����(/)</summary>
        private string _dADD_FIRSTENTRYDATEFLSRF = "";

        /// <summary>���N�x���e����(.)</summary>
        private string _dADD_FIRSTENTRYDATEFLPRF = "";

        /// <summary>���N�x���e����(�N)</summary>
        private string _dADD_FIRSTENTRYDATEFLYRF = "";

        /// <summary>���N�x���e����(��)</summary>
        private string _dADD_FIRSTENTRYDATEFLMRF = "";

        /// <summary>�������t����N</summary>
        private Int32 _dADD_DEPOSITDATEFYRF;

        /// <summary>�������t����N��</summary>
        private Int32 _dADD_DEPOSITDATEFSRF;

        /// <summary>�������t�a��N</summary>
        private Int32 _dADD_DEPOSITDATEFWRF;

        /// <summary>�������t��</summary>
        private Int32 _dADD_DEPOSITDATEFMRF;

        /// <summary>�������t��</summary>
        private Int32 _dADD_DEPOSITDATEFDRF;

        /// <summary>�������t����</summary>
        private string _dADD_DEPOSITDATEFGRF = "";

        /// <summary>�������t����</summary>
        private string _dADD_DEPOSITDATEFRRF = "";

        /// <summary>�������t���e����(/)</summary>
        private string _dADD_DEPOSITDATEFLSRF = "";

        /// <summary>�������t���e����(.)</summary>
        private string _dADD_DEPOSITDATEFLPRF = "";

        /// <summary>�������t���e����(�N)</summary>
        private string _dADD_DEPOSITDATEFLYRF = "";

        /// <summary>�������t���e����(��)</summary>
        private string _dADD_DEPOSITDATEFLMRF = "";

        /// <summary>�������t���e����(��)</summary>
        private string _dADD_DEPOSITDATEFLDRF = "";

        /// <summary>���������敪����</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _dADD_AUTODEPOSITCDRF;

        /// <summary>�a����敪����</summary>
        /// <remarks>0:�ʏ����,1:�a�������</remarks>
        private Int32 _dADD_DEPOSITCDRF;

        /// <summary>��`�U�o������N</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFYRF;

        /// <summary>��`�U�o������N��</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFSRF;

        /// <summary>��`�U�o���a��N</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFWRF;

        /// <summary>��`�U�o����</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFMRF;

        /// <summary>��`�U�o����</summary>
        private Int32 _dADD_DRAFTDRAWINGDATEFDRF;

        /// <summary>��`�U�o������</summary>
        private string _dADD_DRAFTDRAWINGDATEFGRF = "";

        /// <summary>��`�U�o������</summary>
        private string _dADD_DRAFTDRAWINGDATEFRRF = "";

        /// <summary>��`�U�o�����e����(/)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLSRF = "";

        /// <summary>��`�U�o�����e����(.)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLPRF = "";

        /// <summary>��`�U�o�����e����(�N)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLYRF = "";

        /// <summary>��`�U�o�����e����(��)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLMRF = "";

        /// <summary>��`�U�o�����e����(��)</summary>
        private string _dADD_DRAFTDRAWINGDATEFLDRF = "";

        /// <summary>��`�x����������N</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFYRF;

        /// <summary>��`�x����������N��</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFSRF;

        /// <summary>��`�x�������a��N</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFWRF;

        /// <summary>��`�x��������</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFMRF;

        /// <summary>��`�x��������</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private Int32 _dADD_DRAFTPAYTIMELIMITFDRF;

        /// <summary>��`�x����������</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFGRF = "";

        /// <summary>��`�x����������</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFRRF = "";

        /// <summary>��`�x���������e����(/)</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLSRF = "";

        /// <summary>��`�x���������e����(.)</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLPRF = "";

        /// <summary>��`�x���������e����(�N)</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLYRF = "";

        /// <summary>��`�x���������e����(��)</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLMRF = "";

        /// <summary>��`�x���������e����(��)</summary>
        /// <remarks>�L�������Ɠ������e���Z�b�g����</remarks>
        private string _dADD_DRAFTPAYTIMELIMITFLDRF = "";

        /// <summary>�L����������N</summary>
        private Int32 _dADD_VALIDITYTERMFYRF;

        /// <summary>�L����������N��</summary>
        private Int32 _dADD_VALIDITYTERMFSRF;

        /// <summary>�L�������a��N</summary>
        private Int32 _dADD_VALIDITYTERMFWRF;

        /// <summary>�L��������</summary>
        private Int32 _dADD_VALIDITYTERMFMRF;

        /// <summary>�L��������</summary>
        private Int32 _dADD_VALIDITYTERMFDRF;

        /// <summary>�L����������</summary>
        private string _dADD_VALIDITYTERMFGRF = "";

        /// <summary>�L����������</summary>
        private string _dADD_VALIDITYTERMFRRF = "";

        /// <summary>�L���������e����(/)</summary>
        private string _dADD_VALIDITYTERMFLSRF = "";

        /// <summary>�L���������e����(.)</summary>
        private string _dADD_VALIDITYTERMFLPRF = "";

        /// <summary>�L���������e����(�N)</summary>
        private string _dADD_VALIDITYTERMFLYRF = "";

        /// <summary>�L���������e����(��)</summary>
        private string _dADD_VALIDITYTERMFLMRF = "";

        /// <summary>�L���������e����(��)</summary>
        private string _dADD_VALIDITYTERMFLDRF = "";

        /// <summary>�������דE�v</summary>
        /// <remarks>DmdDtlOutlineCodeRF = 0:�󎚂��Ȃ� 1:�i�� 2:�艿</remarks>
        private string _dADD_DMDDTLOUTLINERF = "";

        /// <summary>����`�[�v�^�C�g��</summary>
        /// <remarks>���א������̔���`�[�v�p</remarks>
        private string _dADD_SALESFTTITLERF = "";

        /// <summary>����`�[�v���z</summary>
        /// <remarks>���א������̔���`�[�v�p</remarks>
        private Int64 _dADD_SALESFTPRICERF;

        /// <summary>����`�[�v���l�P</summary>
        /// <remarks>���א������̔���`�[�v�p</remarks>
        private string _dADD_SALESFTNOTE1RF = "";

        /// <summary>����`�[�v���l�Q</summary>
        /// <remarks>���א������̔���`�[�v�p</remarks>
        private string _dADD_SALESFTNOTE2RF = "";

        /// <summary>����`�[�v���l�R</summary>
        /// <remarks>���א������̔���`�[�v�p</remarks>
        private string _dADD_SALESFTNOTE3RF = "";

        /// <summary>���ד`�[�^�C�g��(����/�ԕi)</summary>
        private string _dSAL_DETAILTITLE = "";

        /// <summary>����W�v�^�C�g��</summary>
        private string _dSAL_DETAILSUMTITLE = "";

        /// <summary>����W�v���z</summary>
        private Int64 _dSAL_DETAILSUMPRICE;

        /// <summary>���ד`�[�^�C�g��(����)</summary>
        private string _dDEP_DETAILTITLE = "";

        /// <summary>�����W�v�^�C�g��</summary>
        private string _dDEP_DETAILSUMTITLE = "";

        /// <summary>�����W�v���z</summary>
        private Int64 _dDEP_DETAILSUMPRICE;

        /// <summary>����`�[�敪�i���ׁj</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v</remarks>
        private Int32 _sALESDETAILRF_SALESSLIPCDDTLRF;

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _sALESSLIPRF_RESULTSADDUPSECCDRF = "";

        /// <summary>�������͋��_�R�[�h</summary>
        /// <remarks>�������͂������_�R�[�h</remarks>
        private string _dEPSITMAINRF_INPUTDEPOSITSECCDRF = "";

        /// <summary>���i���̃J�i</summary>
        private string _sALESDETAILRF_GOODSNAMEKANARF = "";

        /// <summary>���[�J�[�J�i����</summary>
        private string _sALESDETAILRF_MAKERKANANAMERF = "";

        /// <summary>�Ԏ피�p����</summary>
        private string _aCCEPTODRCARRF_MODELHALFNAMERF = "";

        /// <summary>����p�i��</summary>
        private string _sALESDETAILRF_PRTGOODSNORF = "";

        /// <summary>����p���[�J�[�R�[�h</summary>
        private Int32 _sALESDETAILRF_PRTMAKERCODERF;

        /// <summary>����p���[�J�[����</summary>
        private string _sALESDETAILRF_PRTMAKERNAMERF = "";

        /// <summary>�����`�[�ԍ��i�w�b�_�p�j</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _dADD_PARTYSALESLIPNUMRF = "";
        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _sALESSLIPRF_CONSTAXLAYMETHODRF;


        /// public propaty name  :  SALESSLIPRF_ACPTANODRSTATUSRF
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ACPTANODRSTATUSRF
        {
            get { return _sALESSLIPRF_ACPTANODRSTATUSRF; }
            set { _sALESSLIPRF_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPNUMRF
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SALESSLIPNUMRF
        {
            get { return _sALESSLIPRF_SALESSLIPNUMRF; }
            set { _sALESSLIPRF_SALESSLIPNUMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SECTIONCODERF
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SECTIONCODERF
        {
            get { return _sALESSLIPRF_SECTIONCODERF; }
            set { _sALESSLIPRF_SECTIONCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SUBSECTIONCODERF
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SUBSECTIONCODERF
        {
            get { return _sALESSLIPRF_SUBSECTIONCODERF; }
            set { _sALESSLIPRF_SUBSECTIONCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEBITNOTEDIVRF
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DEBITNOTEDIVRF
        {
            get { return _sALESSLIPRF_DEBITNOTEDIVRF; }
            set { _sALESSLIPRF_DEBITNOTEDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPCDRF
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESSLIPCDRF
        {
            get { return _sALESSLIPRF_SALESSLIPCDRF; }
            set { _sALESSLIPRF_SALESSLIPCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESGOODSCDRF
        /// <summary>���㏤�i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESGOODSCDRF
        {
            get { return _sALESSLIPRF_SALESGOODSCDRF; }
            set { _sALESSLIPRF_SALESGOODSCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ACCRECDIVCDRF
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ACCRECDIVCDRF
        {
            get { return _sALESSLIPRF_ACCRECDIVCDRF; }
            set { _sALESSLIPRF_ACCRECDIVCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEMANDADDUPSECCDRF
        /// <summary>�����v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_DEMANDADDUPSECCDRF
        {
            get { return _sALESSLIPRF_DEMANDADDUPSECCDRF; }
            set { _sALESSLIPRF_DEMANDADDUPSECCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDATERF
        /// <summary>������t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESDATERF
        {
            get { return _sALESSLIPRF_SALESDATERF; }
            set { _sALESSLIPRF_SALESDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDUPADATERF
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ADDUPADATERF
        {
            get { return _sALESSLIPRF_ADDUPADATERF; }
            set { _sALESSLIPRF_ADDUPADATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_INPUTAGENCDRF
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// <value>���O�C���S���ҁi�t�r�a�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_INPUTAGENCDRF
        {
            get { return _sALESSLIPRF_INPUTAGENCDRF; }
            set { _sALESSLIPRF_INPUTAGENCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_INPUTAGENNMRF
        /// <summary>���͒S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_INPUTAGENNMRF
        {
            get { return _sALESSLIPRF_INPUTAGENNMRF; }
            set { _sALESSLIPRF_INPUTAGENNMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESINPUTCODERF
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SALESINPUTCODERF
        {
            get { return _sALESSLIPRF_SALESINPUTCODERF; }
            set { _sALESSLIPRF_SALESINPUTCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESINPUTNAMERF
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SALESINPUTNAMERF
        {
            get { return _sALESSLIPRF_SALESINPUTNAMERF; }
            set { _sALESSLIPRF_SALESINPUTNAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FRONTEMPLOYEECDRF
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S���ҁi�󒍎ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_FRONTEMPLOYEECDRF
        {
            get { return _sALESSLIPRF_FRONTEMPLOYEECDRF; }
            set { _sALESSLIPRF_FRONTEMPLOYEECDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FRONTEMPLOYEENMRF
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_FRONTEMPLOYEENMRF
        {
            get { return _sALESSLIPRF_FRONTEMPLOYEENMRF; }
            set { _sALESSLIPRF_FRONTEMPLOYEENMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESEMPLOYEECDRF
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SALESEMPLOYEECDRF
        {
            get { return _sALESSLIPRF_SALESEMPLOYEECDRF; }
            set { _sALESSLIPRF_SALESEMPLOYEECDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESEMPLOYEENMRF
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SALESEMPLOYEENMRF
        {
            get { return _sALESSLIPRF_SALESEMPLOYEENMRF; }
            set { _sALESSLIPRF_SALESEMPLOYEENMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESTOTALTAXINCRF
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESTOTALTAXEXCRF
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTTOTALTAXINCRF
        /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㕔�i���v�i�ō��݁j�{���i�l���Ώۊz���v�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESPRTTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESPRTTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTTOTALTAXEXCRF
        /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㕔�i���v�i�Ŕ����j�{���i�l���Ώۊz���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESPRTTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESPRTTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKTOTALTAXINCRF
        /// <summary>�����ƍ��v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�����Ə��v�i�ō��݁j�{��ƒl���Ώۊz���v�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ƍ��v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESWORKTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESWORKTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKTOTALTAXEXCRF
        /// <summary>�����ƍ��v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�����Ə��v�i�Ŕ����j�{��ƒl���Ώۊz���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ƍ��v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESWORKTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESWORKTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSUBTOTALTAXINCRF
        /// <summary>���㏬�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESSUBTOTALTAXINCRF
        {
            get { return _sALESSLIPRF_SALESSUBTOTALTAXINCRF; }
            set { _sALESSLIPRF_SALESSUBTOTALTAXINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSUBTOTALTAXEXCRF
        /// <summary>���㏬�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESSUBTOTALTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESSUBTOTALTAXEXCRF; }
            set { _sALESSLIPRF_SALESSUBTOTALTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTSUBTTLINCRF
        /// <summary>���㕔�i���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���i���׋��z�̐ō����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTSUBTTLINCRF
        {
            get { return _sALESSLIPRF_SALESPRTSUBTTLINCRF; }
            set { _sALESSLIPRF_SALESPRTSUBTTLINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESPRTSUBTTLEXCRF
        /// <summary>���㕔�i���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���i���׋��z�̐Ŕ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�i���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESPRTSUBTTLEXCRF
        {
            get { return _sALESSLIPRF_SALESPRTSUBTTLEXCRF; }
            set { _sALESSLIPRF_SALESPRTSUBTTLEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKSUBTTLINCRF
        /// <summary>�����Ə��v�i�ō��݁j�v���p�e�B</summary>
        /// <value>��Ɩ��׋��z�̐ō����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ə��v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKSUBTTLINCRF
        {
            get { return _sALESSLIPRF_SALESWORKSUBTTLINCRF; }
            set { _sALESSLIPRF_SALESWORKSUBTTLINCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESWORKSUBTTLEXCRF
        /// <summary>�����Ə��v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>��Ɩ��׋��z�̐Ŕ����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ə��v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESWORKSUBTTLEXCRF
        {
            get { return _sALESSLIPRF_SALESWORKSUBTTLEXCRF; }
            set { _sALESSLIPRF_SALESWORKSUBTTLEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSUBTOTALTAXRF
        /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
        /// <value>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESSUBTOTALTAXRF
        {
            get { return _sALESSLIPRF_SALESSUBTOTALTAXRF; }
            set { _sALESSLIPRF_SALESSUBTOTALTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDPARTSDISOUTTAXRF
        /// <summary>���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���i�l���z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDPARTSDISOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDPARTSDISOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDPARTSDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDPARTSDISINTAXRF
        /// <summary>���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���i�l���z�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDPARTSDISINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDPARTSDISINTAXRF; }
            set { _sALESSLIPRF_ITDEDPARTSDISINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDWORKDISOUTTAXRF
        /// <summary>��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>��ƒl���z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƒl���Ώۊz���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDWORKDISOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDWORKDISOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDWORKDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDWORKDISINTAXRF
        /// <summary>��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>��ƒl���z�i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƒl���Ώۊz���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDWORKDISINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDWORKDISINTAXRF; }
            set { _sALESSLIPRF_ITDEDWORKDISINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_PARTSDISCOUNTRATERF
        /// <summary>���i�l�����v���p�e�B</summary>
        /// <value>���v�ɑ΂��Ă̕��i�l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESSLIPRF_PARTSDISCOUNTRATERF
        {
            get { return _sALESSLIPRF_PARTSDISCOUNTRATERF; }
            set { _sALESSLIPRF_PARTSDISCOUNTRATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RAVORDISCOUNTRATERF
        /// <summary>�H���l�����v���p�e�B</summary>
        /// <value>���v�ɑ΂��Ă̍H���l����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �H���l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESSLIPRF_RAVORDISCOUNTRATERF
        {
            get { return _sALESSLIPRF_RAVORDISCOUNTRATERF; }
            set { _sALESSLIPRF_RAVORDISCOUNTRATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_TOTALCOSTRF
        /// <summary>�������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_TOTALCOSTRF
        {
            get { return _sALESSLIPRF_TOTALCOSTRF; }
            set { _sALESSLIPRF_TOTALCOSTRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CONSTAXRATERF
        /// <summary>����Őŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESSLIPRF_CONSTAXRATERF
        {
            get { return _sALESSLIPRF_CONSTAXRATERF; }
            set { _sALESSLIPRF_CONSTAXRATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_AUTODEPOSITCDRF
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_AUTODEPOSITCDRF
        {
            get { return _sALESSLIPRF_AUTODEPOSITCDRF; }
            set { _sALESSLIPRF_AUTODEPOSITCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_AUTODEPOSITSLIPNORF
        /// <summary>���������`�[�ԍ��v���p�e�B</summary>
        /// <value>�����������̓����`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_AUTODEPOSITSLIPNORF
        {
            get { return _sALESSLIPRF_AUTODEPOSITSLIPNORF; }
            set { _sALESSLIPRF_AUTODEPOSITSLIPNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEPOSITALLOWANCETTLRF
        /// <summary>�����������v�z�v���p�e�B</summary>
        /// <value>�a����������v�z���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_DEPOSITALLOWANCETTLRF
        {
            get { return _sALESSLIPRF_DEPOSITALLOWANCETTLRF; }
            set { _sALESSLIPRF_DEPOSITALLOWANCETTLRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DEPOSITALWCBLNCERF
        /// <summary>���������c���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_DEPOSITALWCBLNCERF
        {
            get { return _sALESSLIPRF_DEPOSITALWCBLNCERF; }
            set { _sALESSLIPRF_DEPOSITALWCBLNCERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CLAIMCODERF
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CLAIMCODERF
        {
            get { return _sALESSLIPRF_CLAIMCODERF; }
            set { _sALESSLIPRF_CLAIMCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERCODERF
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CUSTOMERCODERF
        {
            get { return _sALESSLIPRF_CUSTOMERCODERF; }
            set { _sALESSLIPRF_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERNAMERF
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_CUSTOMERNAMERF
        {
            get { return _sALESSLIPRF_CUSTOMERNAMERF; }
            set { _sALESSLIPRF_CUSTOMERNAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERNAME2RF
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_CUSTOMERNAME2RF
        {
            get { return _sALESSLIPRF_CUSTOMERNAME2RF; }
            set { _sALESSLIPRF_CUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CUSTOMERSNMRF
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_CUSTOMERSNMRF
        {
            get { return _sALESSLIPRF_CUSTOMERSNMRF; }
            set { _sALESSLIPRF_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_HONORIFICTITLERF
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_HONORIFICTITLERF
        {
            get { return _sALESSLIPRF_HONORIFICTITLERF; }
            set { _sALESSLIPRF_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEECODERF
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ADDRESSEECODERF
        {
            get { return _sALESSLIPRF_ADDRESSEECODERF; }
            set { _sALESSLIPRF_ADDRESSEECODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEENAMERF
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEENAMERF
        {
            get { return _sALESSLIPRF_ADDRESSEENAMERF; }
            set { _sALESSLIPRF_ADDRESSEENAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEENAME2RF
        /// <summary>�[�i�於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEENAME2RF
        {
            get { return _sALESSLIPRF_ADDRESSEENAME2RF; }
            set { _sALESSLIPRF_ADDRESSEENAME2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_PARTYSALESLIPNUMRF
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_PARTYSALESLIPNUMRF
        {
            get { return _sALESSLIPRF_PARTYSALESLIPNUMRF; }
            set { _sALESSLIPRF_PARTYSALESLIPNUMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SLIPNOTERF
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SLIPNOTERF
        {
            get { return _sALESSLIPRF_SLIPNOTERF; }
            set { _sALESSLIPRF_SLIPNOTERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SLIPNOTE2RF
        /// <summary>�`�[���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SLIPNOTE2RF
        {
            get { return _sALESSLIPRF_SLIPNOTE2RF; }
            set { _sALESSLIPRF_SLIPNOTE2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SLIPNOTE3RF
        /// <summary>�`�[���l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SLIPNOTE3RF
        {
            get { return _sALESSLIPRF_SLIPNOTE3RF; }
            set { _sALESSLIPRF_SLIPNOTE3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RETGOODSREASONDIVRF
        /// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_RETGOODSREASONDIVRF
        {
            get { return _sALESSLIPRF_RETGOODSREASONDIVRF; }
            set { _sALESSLIPRF_RETGOODSREASONDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RETGOODSREASONRF
        /// <summary>�ԕi���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_RETGOODSREASONRF
        {
            get { return _sALESSLIPRF_RETGOODSREASONRF; }
            set { _sALESSLIPRF_RETGOODSREASONRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DETAILROWCOUNTRF
        /// <summary>���׍s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׍s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DETAILROWCOUNTRF
        {
            get { return _sALESSLIPRF_DETAILROWCOUNTRF; }
            set { _sALESSLIPRF_DETAILROWCOUNTRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_UOEREMARK1RF
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_UOEREMARK1RF
        {
            get { return _sALESSLIPRF_UOEREMARK1RF; }
            set { _sALESSLIPRF_UOEREMARK1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_UOEREMARK2RF
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_UOEREMARK2RF
        {
            get { return _sALESSLIPRF_UOEREMARK2RF; }
            set { _sALESSLIPRF_UOEREMARK2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DELIVEREDGOODSDIVRF
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>��) 1:�z�B,2:�X���n��,3:����,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DELIVEREDGOODSDIVRF
        {
            get { return _sALESSLIPRF_DELIVEREDGOODSDIVRF; }
            set { _sALESSLIPRF_DELIVEREDGOODSDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_DELIVEREDGOODSDIVNMRF
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_DELIVEREDGOODSDIVNMRF
        {
            get { return _sALESSLIPRF_DELIVEREDGOODSDIVNMRF; }
            set { _sALESSLIPRF_DELIVEREDGOODSDIVNMRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>�݌Ɏ��敪���O�̖��׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ��i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
        {
            get { return _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF; }
            set { _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_PUREGOODSTTLTAXEXCRF
        /// <summary>�������i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>���i�������O�̖��׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_PUREGOODSTTLTAXEXCRF
        {
            get { return _sALESSLIPRF_PUREGOODSTTLTAXEXCRF; }
            set { _sALESSLIPRF_PUREGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FOOTNOTES1RF
        /// <summary>�r���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_FOOTNOTES1RF
        {
            get { return _sALESSLIPRF_FOOTNOTES1RF; }
            set { _sALESSLIPRF_FOOTNOTES1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_FOOTNOTES2RF
        /// <summary>�r���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_FOOTNOTES2RF
        {
            get { return _sALESSLIPRF_FOOTNOTES2RF; }
            set { _sALESSLIPRF_FOOTNOTES2RF = value; }
        }

        /// public propaty name  :  SECDTL_SECTIONGUIDENMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SECDTL_SECTIONGUIDENMRF
        {
            get { return _sECDTL_SECTIONGUIDENMRF; }
            set { _sECDTL_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SECDTL_SECTIONGUIDESNMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SECDTL_SECTIONGUIDESNMRF
        {
            get { return _sECDTL_SECTIONGUIDESNMRF; }
            set { _sECDTL_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SECDTL_COMPANYNAMECD1RF
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SECDTL_COMPANYNAMECD1RF
        {
            get { return _sECDTL_COMPANYNAMECD1RF; }
            set { _sECDTL_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  SUBSAL_SUBSECTIONNAMERF
        /// <summary>���㕔�喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㕔�喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUBSAL_SUBSECTIONNAMERF
        {
            get { return _sUBSAL_SUBSECTIONNAMERF; }
            set { _sUBSAL_SUBSECTIONNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACCEPTANORDERNORF
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACCEPTANORDERNORF
        {
            get { return _sALESDETAILRF_ACCEPTANORDERNORF; }
            set { _sALESDETAILRF_ACCEPTANORDERNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESROWNORF
        /// <summary>����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESROWNORF
        {
            get { return _sALESDETAILRF_SALESROWNORF; }
            set { _sALESDETAILRF_SALESROWNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_DELIGDSCMPLTDUEDATERF
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�q��[��(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_DELIGDSCMPLTDUEDATERF
        {
            get { return _sALESDETAILRF_DELIGDSCMPLTDUEDATERF; }
            set { _sALESDETAILRF_DELIGDSCMPLTDUEDATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSKINDCODERF
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:���� 1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSKINDCODERF
        {
            get { return _sALESDETAILRF_GOODSKINDCODERF; }
            set { _sALESDETAILRF_GOODSKINDCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMAKERCDRF
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSMAKERCDRF
        {
            get { return _sALESDETAILRF_GOODSMAKERCDRF; }
            set { _sALESDETAILRF_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_MAKERNAMERF
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_MAKERNAMERF
        {
            get { return _sALESDETAILRF_MAKERNAMERF; }
            set { _sALESDETAILRF_MAKERNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNORF
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNORF
        {
            get { return _sALESDETAILRF_GOODSNORF; }
            set { _sALESDETAILRF_GOODSNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNAMERF
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNAMERF
        {
            get { return _sALESDETAILRF_GOODSNAMERF; }
            set { _sALESDETAILRF_GOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSSHORTNAMERF
        /// <summary>���i�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSSHORTNAMERF
        {
            get { return _sALESDETAILRF_GOODSSHORTNAMERF; }
            set { _sALESDETAILRF_GOODSSHORTNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSLGROUPRF
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSLGROUPRF
        {
            get { return _sALESDETAILRF_GOODSLGROUPRF; }
            set { _sALESDETAILRF_GOODSLGROUPRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSLGROUPNAMERF
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSLGROUPNAMERF
        {
            get { return _sALESDETAILRF_GOODSLGROUPNAMERF; }
            set { _sALESDETAILRF_GOODSLGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMGROUPRF
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSMGROUPRF
        {
            get { return _sALESDETAILRF_GOODSMGROUPRF; }
            set { _sALESDETAILRF_GOODSMGROUPRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMGROUPNAMERF
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSMGROUPNAMERF
        {
            get { return _sALESDETAILRF_GOODSMGROUPNAMERF; }
            set { _sALESDETAILRF_GOODSMGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGROUPCODERF
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_BLGROUPCODERF
        {
            get { return _sALESDETAILRF_BLGROUPCODERF; }
            set { _sALESDETAILRF_BLGROUPCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGROUPNAMERF
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_BLGROUPNAMERF
        {
            get { return _sALESDETAILRF_BLGROUPNAMERF; }
            set { _sALESDETAILRF_BLGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGOODSCODERF
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_BLGOODSCODERF
        {
            get { return _sALESDETAILRF_BLGOODSCODERF; }
            set { _sALESDETAILRF_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGOODSFULLNAMERF
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_BLGOODSFULLNAMERF
        {
            get { return _sALESDETAILRF_BLGOODSFULLNAMERF; }
            set { _sALESDETAILRF_BLGOODSFULLNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ENTERPRISEGANRECODERF
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ENTERPRISEGANRECODERF
        {
            get { return _sALESDETAILRF_ENTERPRISEGANRECODERF; }
            set { _sALESDETAILRF_ENTERPRISEGANRECODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ENTERPRISEGANRENAMERF
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_ENTERPRISEGANRENAMERF
        {
            get { return _sALESDETAILRF_ENTERPRISEGANRENAMERF; }
            set { _sALESDETAILRF_ENTERPRISEGANRENAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSECODERF
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSECODERF
        {
            get { return _sALESDETAILRF_WAREHOUSECODERF; }
            set { _sALESDETAILRF_WAREHOUSECODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSENAMERF
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSENAMERF
        {
            get { return _sALESDETAILRF_WAREHOUSENAMERF; }
            set { _sALESDETAILRF_WAREHOUSENAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSESHELFNORF
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSESHELFNORF
        {
            get { return _sALESDETAILRF_WAREHOUSESHELFNORF; }
            set { _sALESDETAILRF_WAREHOUSESHELFNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESORDERDIVCDRF
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESORDERDIVCDRF
        {
            get { return _sALESDETAILRF_SALESORDERDIVCDRF; }
            set { _sALESDETAILRF_SALESORDERDIVCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_OPENPRICEDIVRF
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_OPENPRICEDIVRF
        {
            get { return _sALESDETAILRF_OPENPRICEDIVRF; }
            set { _sALESDETAILRF_OPENPRICEDIVRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSRATERANKRF
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>���i�̊|���p�����N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSRATERANKRF
        {
            get { return _sALESDETAILRF_GOODSRATERANKRF; }
            set { _sALESDETAILRF_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICERATERF
        /// <summary>�艿���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICERATERF
        {
            get { return _sALESDETAILRF_LISTPRICERATERF; }
            set { _sALESDETAILRF_LISTPRICERATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICETAXINCFLRF
        /// <summary>�艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICETAXINCFLRF
        {
            get { return _sALESDETAILRF_LISTPRICETAXINCFLRF; }
            set { _sALESDETAILRF_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICETAXEXCFLRF
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICETAXEXCFLRF
        {
            get { return _sALESDETAILRF_LISTPRICETAXEXCFLRF; }
            set { _sALESDETAILRF_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESRATERF
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESRATERF
        {
            get { return _sALESDETAILRF_SALESRATERF; }
            set { _sALESDETAILRF_SALESRATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNPRCTAXINCFLRF
        /// <summary>����P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNPRCTAXINCFLRF
        {
            get { return _sALESDETAILRF_SALESUNPRCTAXINCFLRF; }
            set { _sALESDETAILRF_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNPRCTAXEXCFLRF
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNPRCTAXEXCFLRF
        {
            get { return _sALESDETAILRF_SALESUNPRCTAXEXCFLRF; }
            set { _sALESDETAILRF_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COSTRATERF
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_COSTRATERF
        {
            get { return _sALESDETAILRF_COSTRATERF; }
            set { _sALESDETAILRF_COSTRATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNITCOSTRF
        /// <summary>�����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNITCOSTRF
        {
            get { return _sALESDETAILRF_SALESUNITCOSTRF; }
            set { _sALESDETAILRF_SALESUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTBLGOODSCODERF
        /// <summary>BL���i�R�[�h�i����j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_PRTBLGOODSCODERF
        {
            get { return _sALESDETAILRF_PRTBLGOODSCODERF; }
            set { _sALESDETAILRF_PRTBLGOODSCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTBLGOODSNAMERF
        /// <summary>BL���i�R�[�h���́i����j�v���p�e�B</summary>
        /// <value>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_PRTBLGOODSNAMERF
        {
            get { return _sALESDETAILRF_PRTBLGOODSNAMERF; }
            set { _sALESDETAILRF_PRTBLGOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WORKMANHOURRF
        /// <summary>��ƍH���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƍH���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_WORKMANHOURRF
        {
            get { return _sALESDETAILRF_WORKMANHOURRF; }
            set { _sALESDETAILRF_WORKMANHOURRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SHIPMENTCNTRF
        /// <summary>�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_SHIPMENTCNTRF
        {
            get { return _sALESDETAILRF_SHIPMENTCNTRF; }
            set { _sALESDETAILRF_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESMONEYTAXINCRF
        /// <summary>������z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESMONEYTAXINCRF
        {
            get { return _sALESDETAILRF_SALESMONEYTAXINCRF; }
            set { _sALESDETAILRF_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESMONEYTAXEXCRF
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESMONEYTAXEXCRF
        {
            get { return _sALESDETAILRF_SALESMONEYTAXEXCRF; }
            set { _sALESDETAILRF_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COSTRF
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_COSTRF
        {
            get { return _sALESDETAILRF_COSTRF; }
            set { _sALESDETAILRF_COSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_TAXATIONDIVCDRF
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_TAXATIONDIVCDRF
        {
            get { return _sALESDETAILRF_TAXATIONDIVCDRF; }
            set { _sALESDETAILRF_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PARTYSLIPNUMDTLRF
        /// <summary>�����`�[�ԍ��i���ׁj�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_PARTYSLIPNUMDTLRF
        {
            get { return _sALESDETAILRF_PARTYSLIPNUMDTLRF; }
            set { _sALESDETAILRF_PARTYSLIPNUMDTLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_DTLNOTERF
        /// <summary>���ה��l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ה��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_DTLNOTERF
        {
            get { return _sALESDETAILRF_DTLNOTERF; }
            set { _sALESDETAILRF_DTLNOTERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERCDRF
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SUPPLIERCDRF
        {
            get { return _sALESDETAILRF_SUPPLIERCDRF; }
            set { _sALESDETAILRF_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERSNMRF
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_SUPPLIERSNMRF
        {
            get { return _sALESDETAILRF_SUPPLIERSNMRF; }
            set { _sALESDETAILRF_SUPPLIERSNMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO1RF
        /// <summary>�`�[�����P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO1RF
        {
            get { return _sALESDETAILRF_SLIPMEMO1RF; }
            set { _sALESDETAILRF_SLIPMEMO1RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO2RF
        /// <summary>�`�[�����Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO2RF
        {
            get { return _sALESDETAILRF_SLIPMEMO2RF; }
            set { _sALESDETAILRF_SLIPMEMO2RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO3RF
        /// <summary>�`�[�����R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO3RF
        {
            get { return _sALESDETAILRF_SLIPMEMO3RF; }
            set { _sALESDETAILRF_SLIPMEMO3RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO1RF
        /// <summary>�Г������P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO1RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO1RF; }
            set { _sALESDETAILRF_INSIDEMEMO1RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO2RF
        /// <summary>�Г������Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO2RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO2RF; }
            set { _sALESDETAILRF_INSIDEMEMO2RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO3RF
        /// <summary>�Г������R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO3RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO3RF; }
            set { _sALESDETAILRF_INSIDEMEMO3RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFLISTPRICERF
        /// <summary>�ύX�O�艿�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_BFLISTPRICERF
        {
            get { return _sALESDETAILRF_BFLISTPRICERF; }
            set { _sALESDETAILRF_BFLISTPRICERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFSALESUNITPRICERF
        /// <summary>�ύX�O�����v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_BFSALESUNITPRICERF
        {
            get { return _sALESDETAILRF_BFSALESUNITPRICERF; }
            set { _sALESDETAILRF_BFSALESUNITPRICERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFUNITCOSTRF
        /// <summary>�ύX�O�����v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_BFUNITCOSTRF
        {
            get { return _sALESDETAILRF_BFUNITCOSTRF; }
            set { _sALESDETAILRF_BFUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESROWNORF
        /// <summary>�ꎮ���הԍ��v���p�e�B</summary>
        /// <value>0:�ꎮ�Ȃ��@1�`�ꎮ�A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ���הԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CMPLTSALESROWNORF
        {
            get { return _sALESDETAILRF_CMPLTSALESROWNORF; }
            set { _sALESDETAILRF_CMPLTSALESROWNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTGOODSMAKERCDRF
        /// <summary>���[�J�[�R�[�h�i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CMPLTGOODSMAKERCDRF
        {
            get { return _sALESDETAILRF_CMPLTGOODSMAKERCDRF; }
            set { _sALESDETAILRF_CMPLTGOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTMAKERNAMERF
        /// <summary>���[�J�[���́i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTMAKERNAMERF
        {
            get { return _sALESDETAILRF_CMPLTMAKERNAMERF; }
            set { _sALESDETAILRF_CMPLTMAKERNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTGOODSNAMERF
        /// <summary>���i���́i�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���́i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTGOODSNAMERF
        {
            get { return _sALESDETAILRF_CMPLTGOODSNAMERF; }
            set { _sALESDETAILRF_CMPLTGOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSHIPMENTCNTRF
        /// <summary>���ʁi�ꎮ�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʁi�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSHIPMENTCNTRF
        {
            get { return _sALESDETAILRF_CMPLTSHIPMENTCNTRF; }
            set { _sALESDETAILRF_CMPLTSHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESUNPRCFLRF
        /// <summary>����P���i�ꎮ�j�v���p�e�B</summary>
        /// <value>������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSALESUNPRCFLRF
        {
            get { return _sALESDETAILRF_CMPLTSALESUNPRCFLRF; }
            set { _sALESDETAILRF_CMPLTSALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESMONEYRF
        /// <summary>������z�i�ꎮ�j�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j�̓���ꎮ���ׂ̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_CMPLTSALESMONEYRF
        {
            get { return _sALESDETAILRF_CMPLTSALESMONEYRF; }
            set { _sALESDETAILRF_CMPLTSALESMONEYRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESUNITCOSTRF
        /// <summary>�����P���i�ꎮ�j�v���p�e�B</summary>
        /// <value>�������z�i�ꎮ�̍��v�j/ ����  ��������R�ʎl�̌ܓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSALESUNITCOSTRF
        {
            get { return _sALESDETAILRF_CMPLTSALESUNITCOSTRF; }
            set { _sALESDETAILRF_CMPLTSALESUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTCOSTRF
        /// <summary>�������z�i�ꎮ�j�v���p�e�B</summary>
        /// <value>�����̓���ꎮ���ׂ̍��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_CMPLTCOSTRF
        {
            get { return _sALESDETAILRF_CMPLTCOSTRF; }
            set { _sALESDETAILRF_CMPLTCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTPARTYSALSLNUMRF
        /// <summary>�����`�[�ԍ��i�ꎮ�j�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i�ꎮ�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTPARTYSALSLNUMRF
        {
            get { return _sALESDETAILRF_CMPLTPARTYSALSLNUMRF; }
            set { _sALESDETAILRF_CMPLTPARTYSALSLNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTNOTERF
        /// <summary>�ꎮ���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTNOTERF
        {
            get { return _sALESDETAILRF_CMPLTNOTERF; }
            set { _sALESDETAILRF_CMPLTNOTERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CARMNGNORF
        /// <summary>�ԗ��Ǘ��ԍ��v���p�e�B</summary>
        /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_CARMNGNORF
        {
            get { return _aCCEPTODRCARRF_CARMNGNORF; }
            set { _aCCEPTODRCARRF_CARMNGNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CARMNGCODERF
        /// <summary>���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_CARMNGCODERF
        {
            get { return _aCCEPTODRCARRF_CARMNGCODERF; }
            set { _aCCEPTODRCARRF_CARMNGCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE1CODERF
        /// <summary>���^�������ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���^�������ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_NUMBERPLATE1CODERF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE1CODERF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE1CODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE1NAMERF
        /// <summary>���^�����ǖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE1NAMERF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE1NAMERF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE1NAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE2RF
        /// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE2RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE2RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE2RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE3RF
        /// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE3RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE3RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE3RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE4RF
        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_NUMBERPLATE4RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE4RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE4RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FIRSTENTRYDATERF
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_FIRSTENTRYDATERF
        {
            get { return _aCCEPTODRCARRF_FIRSTENTRYDATERF; }
            set { _aCCEPTODRCARRF_FIRSTENTRYDATERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERCODERF
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MAKERCODERF
        {
            get { return _aCCEPTODRCARRF_MAKERCODERF; }
            set { _aCCEPTODRCARRF_MAKERCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERFULLNAMERF
        /// <summary>���[�J�[�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MAKERFULLNAMERF
        {
            get { return _aCCEPTODRCARRF_MAKERFULLNAMERF; }
            set { _aCCEPTODRCARRF_MAKERFULLNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELCODERF
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELCODERF
        {
            get { return _aCCEPTODRCARRF_MODELCODERF; }
            set { _aCCEPTODRCARRF_MODELCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELSUBCODERF
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELSUBCODERF
        {
            get { return _aCCEPTODRCARRF_MODELSUBCODERF; }
            set { _aCCEPTODRCARRF_MODELSUBCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELFULLNAMERF
        /// <summary>�Ԏ�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELFULLNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELFULLNAMERF; }
            set { _aCCEPTODRCARRF_MODELFULLNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_EXHAUSTGASSIGNRF
        /// <summary>�r�K�X�L���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�K�X�L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_EXHAUSTGASSIGNRF
        {
            get { return _aCCEPTODRCARRF_EXHAUSTGASSIGNRF; }
            set { _aCCEPTODRCARRF_EXHAUSTGASSIGNRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SERIESMODELRF
        /// <summary>�V���[�Y�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���[�Y�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_SERIESMODELRF
        {
            get { return _aCCEPTODRCARRF_SERIESMODELRF; }
            set { _aCCEPTODRCARRF_SERIESMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CATEGORYSIGNMODELRF
        /// <summary>�^���i�ޕʋL���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�ޕʋL���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_CATEGORYSIGNMODELRF
        {
            get { return _aCCEPTODRCARRF_CATEGORYSIGNMODELRF; }
            set { _aCCEPTODRCARRF_CATEGORYSIGNMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FULLMODELRF
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FULLMODELRF
        {
            get { return _aCCEPTODRCARRF_FULLMODELRF; }
            set { _aCCEPTODRCARRF_FULLMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELDESIGNATIONNORF
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELDESIGNATIONNORF
        {
            get { return _aCCEPTODRCARRF_MODELDESIGNATIONNORF; }
            set { _aCCEPTODRCARRF_MODELDESIGNATIONNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CATEGORYNORF
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_CATEGORYNORF
        {
            get { return _aCCEPTODRCARRF_CATEGORYNORF; }
            set { _aCCEPTODRCARRF_CATEGORYNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FRAMEMODELRF
        /// <summary>�ԑ�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FRAMEMODELRF
        {
            get { return _aCCEPTODRCARRF_FRAMEMODELRF; }
            set { _aCCEPTODRCARRF_FRAMEMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FRAMENORF
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// <value>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FRAMENORF
        {
            get { return _aCCEPTODRCARRF_FRAMENORF; }
            set { _aCCEPTODRCARRF_FRAMENORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SEARCHFRAMENORF
        /// <summary>�ԑ�ԍ��i�����p�j�v���p�e�B</summary>
        /// <value>PM7�̎ԑ�ԍ��Ɠ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��i�����p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_SEARCHFRAMENORF
        {
            get { return _aCCEPTODRCARRF_SEARCHFRAMENORF; }
            set { _aCCEPTODRCARRF_SEARCHFRAMENORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_ENGINEMODELNMRF
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�G���W������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_ENGINEMODELNMRF
        {
            get { return _aCCEPTODRCARRF_ENGINEMODELNMRF; }
            set { _aCCEPTODRCARRF_ENGINEMODELNMRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_RELEVANCEMODELRF
        /// <summary>�֘A�^���v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �֘A�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_RELEVANCEMODELRF
        {
            get { return _aCCEPTODRCARRF_RELEVANCEMODELRF; }
            set { _aCCEPTODRCARRF_RELEVANCEMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SUBCARNMCDRF
        /// <summary>�T�u�Ԗ��R�[�h�v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �T�u�Ԗ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_SUBCARNMCDRF
        {
            get { return _aCCEPTODRCARRF_SUBCARNMCDRF; }
            set { _aCCEPTODRCARRF_SUBCARNMCDRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELGRADESNAMERF
        /// <summary>�^���O���[�h���̃v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELGRADESNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELGRADESNAMERF; }
            set { _aCCEPTODRCARRF_MODELGRADESNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_COLORCODERF
        /// <summary>�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_COLORCODERF
        {
            get { return _aCCEPTODRCARRF_COLORCODERF; }
            set { _aCCEPTODRCARRF_COLORCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_COLORNAME1RF
        /// <summary>�J���[����1�v���p�e�B</summary>
        /// <value>��ʕ\���p��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_COLORNAME1RF
        {
            get { return _aCCEPTODRCARRF_COLORNAME1RF; }
            set { _aCCEPTODRCARRF_COLORNAME1RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_TRIMCODERF
        /// <summary>�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_TRIMCODERF
        {
            get { return _aCCEPTODRCARRF_TRIMCODERF; }
            set { _aCCEPTODRCARRF_TRIMCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_TRIMNAMERF
        /// <summary>�g�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_TRIMNAMERF
        {
            get { return _aCCEPTODRCARRF_TRIMNAMERF; }
            set { _aCCEPTODRCARRF_TRIMNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MILEAGERF
        /// <summary>�ԗ����s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ����s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MILEAGERF
        {
            get { return _aCCEPTODRCARRF_MILEAGERF; }
            set { _aCCEPTODRCARRF_MILEAGERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_ACPTANODRSTATUSRF
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_ACPTANODRSTATUSRF
        {
            get { return _dEPSITMAINRF_ACPTANODRSTATUSRF; }
            set { _dEPSITMAINRF_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITSLIPNORF
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DEPOSITSLIPNORF
        {
            get { return _dEPSITMAINRF_DEPOSITSLIPNORF; }
            set { _dEPSITMAINRF_DEPOSITSLIPNORF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_SALESSLIPNUMRF
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_SALESSLIPNUMRF
        {
            get { return _dEPSITMAINRF_SALESSLIPNUMRF; }
            set { _dEPSITMAINRF_SALESSLIPNUMRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_ADDUPSECCODERF
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_ADDUPSECCODERF
        {
            get { return _dEPSITMAINRF_ADDUPSECCODERF; }
            set { _dEPSITMAINRF_ADDUPSECCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_SUBSECTIONCODERF
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_SUBSECTIONCODERF
        {
            get { return _dEPSITMAINRF_SUBSECTIONCODERF; }
            set { _dEPSITMAINRF_SUBSECTIONCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITDATERF
        /// <summary>�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DEPOSITDATERF
        {
            get { return _dEPSITMAINRF_DEPOSITDATERF; }
            set { _dEPSITMAINRF_DEPOSITDATERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_ADDUPADATERF
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_ADDUPADATERF
        {
            get { return _dEPSITMAINRF_ADDUPADATERF; }
            set { _dEPSITMAINRF_ADDUPADATERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITRF
        /// <summary>�������z�v���p�e�B</summary>
        /// <value>�l���E�萔�����������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPSITMAINRF_DEPOSITRF
        {
            get { return _dEPSITMAINRF_DEPOSITRF; }
            set { _dEPSITMAINRF_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_FEEDEPOSITRF
        /// <summary>�萔�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPSITMAINRF_FEEDEPOSITRF
        {
            get { return _dEPSITMAINRF_FEEDEPOSITRF; }
            set { _dEPSITMAINRF_FEEDEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DISCOUNTDEPOSITRF
        /// <summary>�l�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPSITMAINRF_DISCOUNTDEPOSITRF
        {
            get { return _dEPSITMAINRF_DISCOUNTDEPOSITRF; }
            set { _dEPSITMAINRF_DISCOUNTDEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_AUTODEPOSITCDRF
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_AUTODEPOSITCDRF
        {
            get { return _dEPSITMAINRF_AUTODEPOSITCDRF; }
            set { _dEPSITMAINRF_AUTODEPOSITCDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DEPOSITCDRF
        /// <summary>�a����敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:�a�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DEPOSITCDRF
        {
            get { return _dEPSITMAINRF_DEPOSITCDRF; }
            set { _dEPSITMAINRF_DEPOSITCDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTDRAWINGDATERF
        /// <summary>��`�U�o���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DRAFTDRAWINGDATERF
        {
            get { return _dEPSITMAINRF_DRAFTDRAWINGDATERF; }
            set { _dEPSITMAINRF_DRAFTDRAWINGDATERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTKINDRF
        /// <summary>��`��ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_DRAFTKINDRF
        {
            get { return _dEPSITMAINRF_DRAFTKINDRF; }
            set { _dEPSITMAINRF_DRAFTKINDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTKINDNAMERF
        /// <summary>��`��ޖ��̃v���p�e�B</summary>
        /// <value>�񑩁A�בցA���؎�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_DRAFTKINDNAMERF
        {
            get { return _dEPSITMAINRF_DRAFTKINDNAMERF; }
            set { _dEPSITMAINRF_DRAFTKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTDIVIDENAMERF
        /// <summary>��`�敪���̃v���p�e�B</summary>
        /// <value>���U�A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_DRAFTDIVIDENAMERF
        {
            get { return _dEPSITMAINRF_DRAFTDIVIDENAMERF; }
            set { _dEPSITMAINRF_DRAFTDIVIDENAMERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_DRAFTNORF
        /// <summary>��`�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_DRAFTNORF
        {
            get { return _dEPSITMAINRF_DRAFTNORF; }
            set { _dEPSITMAINRF_DRAFTNORF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_CUSTOMERCODERF
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_CUSTOMERCODERF
        {
            get { return _dEPSITMAINRF_CUSTOMERCODERF; }
            set { _dEPSITMAINRF_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_CLAIMCODERF
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>�����擾�Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITMAINRF_CLAIMCODERF
        {
            get { return _dEPSITMAINRF_CLAIMCODERF; }
            set { _dEPSITMAINRF_CLAIMCODERF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_OUTLINERF
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_OUTLINERF
        {
            get { return _dEPSITMAINRF_OUTLINERF; }
            set { _dEPSITMAINRF_OUTLINERF = value; }
        }

        /// public propaty name  :  SUBDEP_SUBSECTIONNAMERF
        /// <summary>�����������喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUBDEP_SUBSECTIONNAMERF
        {
            get { return _sUBDEP_SUBSECTIONNAMERF; }
            set { _sUBDEP_SUBSECTIONNAMERF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_DEPOSITSLIPNORF
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_DEPOSITSLIPNORF
        {
            get { return _dEPSITDTLRF_DEPOSITSLIPNORF; }
            set { _dEPSITDTLRF_DEPOSITSLIPNORF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_DEPOSITROWNORF
        /// <summary>�����s�ԍ��v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_DEPOSITROWNORF
        {
            get { return _dEPSITDTLRF_DEPOSITROWNORF; }
            set { _dEPSITDTLRF_DEPOSITROWNORF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_MONEYKINDCODERF
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_MONEYKINDCODERF
        {
            get { return _dEPSITDTLRF_MONEYKINDCODERF; }
            set { _dEPSITDTLRF_MONEYKINDCODERF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_MONEYKINDNAMERF
        /// <summary>���햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITDTLRF_MONEYKINDNAMERF
        {
            get { return _dEPSITDTLRF_MONEYKINDNAMERF; }
            set { _dEPSITDTLRF_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_MONEYKINDDIVRF
        /// <summary>����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_MONEYKINDDIVRF
        {
            get { return _dEPSITDTLRF_MONEYKINDDIVRF; }
            set { _dEPSITDTLRF_MONEYKINDDIVRF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_DEPOSITRF
        /// <summary>�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPSITDTLRF_DEPOSITRF
        {
            get { return _dEPSITDTLRF_DEPOSITRF; }
            set { _dEPSITDTLRF_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPSITDTLRF_VALIDITYTERMRF
        /// <summary>�L�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPSITDTLRF_VALIDITYTERMRF
        {
            get { return _dEPSITDTLRF_VALIDITYTERMRF; }
            set { _dEPSITDTLRF_VALIDITYTERMRF = value; }
        }

        /// public propaty name  :  DADD_ACPTANODRSTATUSRF
        /// <summary>�󒍃X�e�[�^�X���̃v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_ACPTANODRSTATUSRF
        {
            get { return _dADD_ACPTANODRSTATUSRF; }
            set { _dADD_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  DADD_DEBITNOTEDIVRF
        /// <summary>�ԓ`�敪���̃v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEBITNOTEDIVRF
        {
            get { return _dADD_DEBITNOTEDIVRF; }
            set { _dADD_DEBITNOTEDIVRF = value; }
        }

        /// public propaty name  :  DADD_SALESSLIPCDRF
        /// <summary>����`�[�敪���̃v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESSLIPCDRF
        {
            get { return _dADD_SALESSLIPCDRF; }
            set { _dADD_SALESSLIPCDRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATERF
        /// <summary>������t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESDATERF
        {
            get { return _dADD_SALESDATERF; }
            set { _dADD_SALESDATERF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFYRF
        /// <summary>������t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFYRF
        {
            get { return _dADD_SALESDATEFYRF; }
            set { _dADD_SALESDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFSRF
        /// <summary>������t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFSRF
        {
            get { return _dADD_SALESDATEFSRF; }
            set { _dADD_SALESDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFWRF
        /// <summary>������t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFWRF
        {
            get { return _dADD_SALESDATEFWRF; }
            set { _dADD_SALESDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFMRF
        /// <summary>������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFMRF
        {
            get { return _dADD_SALESDATEFMRF; }
            set { _dADD_SALESDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFDRF
        /// <summary>������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESDATEFDRF
        {
            get { return _dADD_SALESDATEFDRF; }
            set { _dADD_SALESDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFGRF
        /// <summary>������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFGRF
        {
            get { return _dADD_SALESDATEFGRF; }
            set { _dADD_SALESDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFRRF
        /// <summary>������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFRRF
        {
            get { return _dADD_SALESDATEFRRF; }
            set { _dADD_SALESDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLSRF
        /// <summary>������t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFLSRF
        {
            get { return _dADD_SALESDATEFLSRF; }
            set { _dADD_SALESDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLPRF
        /// <summary>������t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFLPRF
        {
            get { return _dADD_SALESDATEFLPRF; }
            set { _dADD_SALESDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLYRF
        /// <summary>������t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFLYRF
        {
            get { return _dADD_SALESDATEFLYRF; }
            set { _dADD_SALESDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLMRF
        /// <summary>������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFLMRF
        {
            get { return _dADD_SALESDATEFLMRF; }
            set { _dADD_SALESDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_SALESDATEFLDRF
        /// <summary>������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESDATEFLDRF
        {
            get { return _dADD_SALESDATEFLDRF; }
            set { _dADD_SALESDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_STOCKGOODSTTLTAXEXCRF
        /// <summary>��񏤕i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>�݌Ɏ��敪���O�łȂ����׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��񏤕i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DADD_STOCKGOODSTTLTAXEXCRF
        {
            get { return _dADD_STOCKGOODSTTLTAXEXCRF; }
            set { _dADD_STOCKGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  DADD_PUREGOODSTTLTAXEXCRF
        /// <summary>�D�Ǐ��i���v���z�i�Ŕ��j�v���p�e�B</summary>
        /// <value>���i�������O�łȂ����׋��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǐ��i���v���z�i�Ŕ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DADD_PUREGOODSTTLTAXEXCRF
        {
            get { return _dADD_PUREGOODSTTLTAXEXCRF; }
            set { _dADD_PUREGOODSTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  DADD_GOODSKINDCODERF
        /// <summary>���i�������̃v���p�e�B</summary>
        /// <value>0:���� 1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_GOODSKINDCODERF
        {
            get { return _dADD_GOODSKINDCODERF; }
            set { _dADD_GOODSKINDCODERF = value; }
        }

        /// public propaty name  :  DADD_SALESORDERDIVCDRF
        /// <summary>����݌Ɏ�񂹋敪���̃v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_SALESORDERDIVCDRF
        {
            get { return _dADD_SALESORDERDIVCDRF; }
            set { _dADD_SALESORDERDIVCDRF = value; }
        }

        /// public propaty name  :  DADD_OPENPRICEDIVRF
        /// <summary>�I�[�v�����i�敪���̃v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_OPENPRICEDIVRF
        {
            get { return _dADD_OPENPRICEDIVRF; }
            set { _dADD_OPENPRICEDIVRF = value; }
        }

        /// public propaty name  :  DADD_TAXATIONDIVCDRF
        /// <summary>�ېŋ敪���̃v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_TAXATIONDIVCDRF
        {
            get { return _dADD_TAXATIONDIVCDRF; }
            set { _dADD_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFYRF
        /// <summary>���N�x����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFYRF
        {
            get { return _dADD_FIRSTENTRYDATEFYRF; }
            set { _dADD_FIRSTENTRYDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFSRF
        /// <summary>���N�x����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFSRF
        {
            get { return _dADD_FIRSTENTRYDATEFSRF; }
            set { _dADD_FIRSTENTRYDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFWRF
        /// <summary>���N�x�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFWRF
        {
            get { return _dADD_FIRSTENTRYDATEFWRF; }
            set { _dADD_FIRSTENTRYDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFMRF
        /// <summary>���N�x���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFMRF
        {
            get { return _dADD_FIRSTENTRYDATEFMRF; }
            set { _dADD_FIRSTENTRYDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFGRF
        /// <summary>���N�x�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFGRF
        {
            get { return _dADD_FIRSTENTRYDATEFGRF; }
            set { _dADD_FIRSTENTRYDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFRRF
        /// <summary>���N�x�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFRRF
        {
            get { return _dADD_FIRSTENTRYDATEFRRF; }
            set { _dADD_FIRSTENTRYDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLSRF
        /// <summary>���N�x���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLSRF
        {
            get { return _dADD_FIRSTENTRYDATEFLSRF; }
            set { _dADD_FIRSTENTRYDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLPRF
        /// <summary>���N�x���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLPRF
        {
            get { return _dADD_FIRSTENTRYDATEFLPRF; }
            set { _dADD_FIRSTENTRYDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLYRF
        /// <summary>���N�x���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLYRF
        {
            get { return _dADD_FIRSTENTRYDATEFLYRF; }
            set { _dADD_FIRSTENTRYDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLMRF
        /// <summary>���N�x���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLMRF
        {
            get { return _dADD_FIRSTENTRYDATEFLMRF; }
            set { _dADD_FIRSTENTRYDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFYRF
        /// <summary>�������t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFYRF
        {
            get { return _dADD_DEPOSITDATEFYRF; }
            set { _dADD_DEPOSITDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFSRF
        /// <summary>�������t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFSRF
        {
            get { return _dADD_DEPOSITDATEFSRF; }
            set { _dADD_DEPOSITDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFWRF
        /// <summary>�������t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFWRF
        {
            get { return _dADD_DEPOSITDATEFWRF; }
            set { _dADD_DEPOSITDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFMRF
        /// <summary>�������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFMRF
        {
            get { return _dADD_DEPOSITDATEFMRF; }
            set { _dADD_DEPOSITDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFDRF
        /// <summary>�������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEPOSITDATEFDRF
        {
            get { return _dADD_DEPOSITDATEFDRF; }
            set { _dADD_DEPOSITDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFGRF
        /// <summary>�������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFGRF
        {
            get { return _dADD_DEPOSITDATEFGRF; }
            set { _dADD_DEPOSITDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFRRF
        /// <summary>�������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFRRF
        {
            get { return _dADD_DEPOSITDATEFRRF; }
            set { _dADD_DEPOSITDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLSRF
        /// <summary>�������t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLSRF
        {
            get { return _dADD_DEPOSITDATEFLSRF; }
            set { _dADD_DEPOSITDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLPRF
        /// <summary>�������t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLPRF
        {
            get { return _dADD_DEPOSITDATEFLPRF; }
            set { _dADD_DEPOSITDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLYRF
        /// <summary>�������t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLYRF
        {
            get { return _dADD_DEPOSITDATEFLYRF; }
            set { _dADD_DEPOSITDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLMRF
        /// <summary>�������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLMRF
        {
            get { return _dADD_DEPOSITDATEFLMRF; }
            set { _dADD_DEPOSITDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITDATEFLDRF
        /// <summary>�������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DEPOSITDATEFLDRF
        {
            get { return _dADD_DEPOSITDATEFLDRF; }
            set { _dADD_DEPOSITDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_AUTODEPOSITCDRF
        /// <summary>���������敪���̃v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_AUTODEPOSITCDRF
        {
            get { return _dADD_AUTODEPOSITCDRF; }
            set { _dADD_AUTODEPOSITCDRF = value; }
        }

        /// public propaty name  :  DADD_DEPOSITCDRF
        /// <summary>�a����敪���̃v���p�e�B</summary>
        /// <value>0:�ʏ����,1:�a�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DEPOSITCDRF
        {
            get { return _dADD_DEPOSITCDRF; }
            set { _dADD_DEPOSITCDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFYRF
        /// <summary>��`�U�o������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFYRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFYRF; }
            set { _dADD_DRAFTDRAWINGDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFSRF
        /// <summary>��`�U�o������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFSRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFSRF; }
            set { _dADD_DRAFTDRAWINGDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFWRF
        /// <summary>��`�U�o���a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o���a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFWRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFWRF; }
            set { _dADD_DRAFTDRAWINGDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFMRF
        /// <summary>��`�U�o�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFMRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFMRF; }
            set { _dADD_DRAFTDRAWINGDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFDRF
        /// <summary>��`�U�o�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTDRAWINGDATEFDRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFDRF; }
            set { _dADD_DRAFTDRAWINGDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFGRF
        /// <summary>��`�U�o�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFGRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFGRF; }
            set { _dADD_DRAFTDRAWINGDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFRRF
        /// <summary>��`�U�o�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFRRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFRRF; }
            set { _dADD_DRAFTDRAWINGDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLSRF
        /// <summary>��`�U�o�����e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLSRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLSRF; }
            set { _dADD_DRAFTDRAWINGDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLPRF
        /// <summary>��`�U�o�����e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLPRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLPRF; }
            set { _dADD_DRAFTDRAWINGDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLYRF
        /// <summary>��`�U�o�����e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLYRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLYRF; }
            set { _dADD_DRAFTDRAWINGDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLMRF
        /// <summary>��`�U�o�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLMRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLMRF; }
            set { _dADD_DRAFTDRAWINGDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTDRAWINGDATEFLDRF
        /// <summary>��`�U�o�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTDRAWINGDATEFLDRF
        {
            get { return _dADD_DRAFTDRAWINGDATEFLDRF; }
            set { _dADD_DRAFTDRAWINGDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFYRF
        /// <summary>��`�x����������N�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x����������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFYRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFYRF; }
            set { _dADD_DRAFTPAYTIMELIMITFYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFSRF
        /// <summary>��`�x����������N���v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x����������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFSRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFSRF; }
            set { _dADD_DRAFTPAYTIMELIMITFSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFWRF
        /// <summary>��`�x�������a��N�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x�������a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFWRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFWRF; }
            set { _dADD_DRAFTPAYTIMELIMITFWRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFMRF
        /// <summary>��`�x���������v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFMRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFMRF; }
            set { _dADD_DRAFTPAYTIMELIMITFMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFDRF
        /// <summary>��`�x���������v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DRAFTPAYTIMELIMITFDRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFDRF; }
            set { _dADD_DRAFTPAYTIMELIMITFDRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFGRF
        /// <summary>��`�x�����������v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x�����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFGRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFGRF; }
            set { _dADD_DRAFTPAYTIMELIMITFGRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFRRF
        /// <summary>��`�x�����������v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x�����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFRRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFRRF; }
            set { _dADD_DRAFTPAYTIMELIMITFRRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLSRF
        /// <summary>��`�x���������e����(/)�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLSRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLSRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLSRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLPRF
        /// <summary>��`�x���������e����(.)�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLPRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLPRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLPRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLYRF
        /// <summary>��`�x���������e����(�N)�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLYRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLYRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLYRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLMRF
        /// <summary>��`�x���������e����(��)�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLMRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLMRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLMRF = value; }
        }

        /// public propaty name  :  DADD_DRAFTPAYTIMELIMITFLDRF
        /// <summary>��`�x���������e����(��)�v���p�e�B</summary>
        /// <value>�L�������Ɠ������e���Z�b�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x���������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DRAFTPAYTIMELIMITFLDRF
        {
            get { return _dADD_DRAFTPAYTIMELIMITFLDRF; }
            set { _dADD_DRAFTPAYTIMELIMITFLDRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFYRF
        /// <summary>�L����������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L����������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFYRF
        {
            get { return _dADD_VALIDITYTERMFYRF; }
            set { _dADD_VALIDITYTERMFYRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFSRF
        /// <summary>�L����������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L����������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFSRF
        {
            get { return _dADD_VALIDITYTERMFSRF; }
            set { _dADD_VALIDITYTERMFSRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFWRF
        /// <summary>�L�������a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFWRF
        {
            get { return _dADD_VALIDITYTERMFWRF; }
            set { _dADD_VALIDITYTERMFWRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFMRF
        /// <summary>�L���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFMRF
        {
            get { return _dADD_VALIDITYTERMFMRF; }
            set { _dADD_VALIDITYTERMFMRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFDRF
        /// <summary>�L���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_VALIDITYTERMFDRF
        {
            get { return _dADD_VALIDITYTERMFDRF; }
            set { _dADD_VALIDITYTERMFDRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFGRF
        /// <summary>�L�����������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFGRF
        {
            get { return _dADD_VALIDITYTERMFGRF; }
            set { _dADD_VALIDITYTERMFGRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFRRF
        /// <summary>�L�����������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFRRF
        {
            get { return _dADD_VALIDITYTERMFRRF; }
            set { _dADD_VALIDITYTERMFRRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLSRF
        /// <summary>�L���������e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLSRF
        {
            get { return _dADD_VALIDITYTERMFLSRF; }
            set { _dADD_VALIDITYTERMFLSRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLPRF
        /// <summary>�L���������e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLPRF
        {
            get { return _dADD_VALIDITYTERMFLPRF; }
            set { _dADD_VALIDITYTERMFLPRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLYRF
        /// <summary>�L���������e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLYRF
        {
            get { return _dADD_VALIDITYTERMFLYRF; }
            set { _dADD_VALIDITYTERMFLYRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLMRF
        /// <summary>�L���������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLMRF
        {
            get { return _dADD_VALIDITYTERMFLMRF; }
            set { _dADD_VALIDITYTERMFLMRF = value; }
        }

        /// public propaty name  :  DADD_VALIDITYTERMFLDRF
        /// <summary>�L���������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_VALIDITYTERMFLDRF
        {
            get { return _dADD_VALIDITYTERMFLDRF; }
            set { _dADD_VALIDITYTERMFLDRF = value; }
        }

        /// public propaty name  :  DADD_DMDDTLOUTLINERF
        /// <summary>�������דE�v�v���p�e�B</summary>
        /// <value>DmdDtlOutlineCodeRF = 0:�󎚂��Ȃ� 1:�i�� 2:�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������דE�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DMDDTLOUTLINERF
        {
            get { return _dADD_DMDDTLOUTLINERF; }
            set { _dADD_DMDDTLOUTLINERF = value; }
        }

        /// public propaty name  :  DADD_SALESFTTITLERF
        /// <summary>����`�[�v�^�C�g���v���p�e�B</summary>
        /// <value>���א������̔���`�[�v�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�v�^�C�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESFTTITLERF
        {
            get { return _dADD_SALESFTTITLERF; }
            set { _dADD_SALESFTTITLERF = value; }
        }

        /// public propaty name  :  DADD_SALESFTPRICERF
        /// <summary>����`�[�v���z�v���p�e�B</summary>
        /// <value>���א������̔���`�[�v�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�v���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DADD_SALESFTPRICERF
        {
            get { return _dADD_SALESFTPRICERF; }
            set { _dADD_SALESFTPRICERF = value; }
        }

        /// public propaty name  :  DADD_SALESFTNOTE1RF
        /// <summary>����`�[�v���l�P�v���p�e�B</summary>
        /// <value>���א������̔���`�[�v�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�v���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESFTNOTE1RF
        {
            get { return _dADD_SALESFTNOTE1RF; }
            set { _dADD_SALESFTNOTE1RF = value; }
        }

        /// public propaty name  :  DADD_SALESFTNOTE2RF
        /// <summary>����`�[�v���l�Q�v���p�e�B</summary>
        /// <value>���א������̔���`�[�v�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�v���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESFTNOTE2RF
        {
            get { return _dADD_SALESFTNOTE2RF; }
            set { _dADD_SALESFTNOTE2RF = value; }
        }

        /// public propaty name  :  DADD_SALESFTNOTE3RF
        /// <summary>����`�[�v���l�R�v���p�e�B</summary>
        /// <value>���א������̔���`�[�v�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�v���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESFTNOTE3RF
        {
            get { return _dADD_SALESFTNOTE3RF; }
            set { _dADD_SALESFTNOTE3RF = value; }
        }

        /// public propaty name  :  DSAL_DETAILTITLE
        /// <summary>���ד`�[�^�C�g��(����/�ԕi)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד`�[�^�C�g��(����/�ԕi)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DSAL_DETAILTITLE
        {
            get { return _dSAL_DETAILTITLE; }
            set { _dSAL_DETAILTITLE = value; }
        }

        /// public propaty name  :  DSAL_DETAILSUMTITLE
        /// <summary>����W�v�^�C�g���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����W�v�^�C�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DSAL_DETAILSUMTITLE
        {
            get { return _dSAL_DETAILSUMTITLE; }
            set { _dSAL_DETAILSUMTITLE = value; }
        }

        /// public propaty name  :  DSAL_DETAILSUMPRICE
        /// <summary>����W�v���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����W�v���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DSAL_DETAILSUMPRICE
        {
            get { return _dSAL_DETAILSUMPRICE; }
            set { _dSAL_DETAILSUMPRICE = value; }
        }

        /// public propaty name  :  DDEP_DETAILTITLE
        /// <summary>���ד`�[�^�C�g��(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד`�[�^�C�g��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DDEP_DETAILTITLE
        {
            get { return _dDEP_DETAILTITLE; }
            set { _dDEP_DETAILTITLE = value; }
        }

        /// public propaty name  :  DDEP_DETAILSUMTITLE
        /// <summary>�����W�v�^�C�g���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����W�v�^�C�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DDEP_DETAILSUMTITLE
        {
            get { return _dDEP_DETAILSUMTITLE; }
            set { _dDEP_DETAILSUMTITLE = value; }
        }

        /// public propaty name  :  DDEP_DETAILSUMPRICE
        /// <summary>�����W�v���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����W�v���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DDEP_DETAILSUMPRICE
        {
            get { return _dDEP_DETAILSUMPRICE; }
            set { _dDEP_DETAILSUMPRICE = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPCDDTLRF
        /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESSLIPCDDTLRF
        {
            get { return _sALESDETAILRF_SALESSLIPCDDTLRF; }
            set { _sALESDETAILRF_SALESSLIPCDDTLRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_RESULTSADDUPSECCDRF
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_RESULTSADDUPSECCDRF
        {
            get { return _sALESSLIPRF_RESULTSADDUPSECCDRF; }
            set { _sALESSLIPRF_RESULTSADDUPSECCDRF = value; }
        }

        /// public propaty name  :  DEPSITMAINRF_INPUTDEPOSITSECCDRF
        /// <summary>�������͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�������͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPSITMAINRF_INPUTDEPOSITSECCDRF
        {
            get { return _dEPSITMAINRF_INPUTDEPOSITSECCDRF; }
            set { _dEPSITMAINRF_INPUTDEPOSITSECCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNAMEKANARF
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNAMEKANARF
        {
            get { return _sALESDETAILRF_GOODSNAMEKANARF; }
            set { _sALESDETAILRF_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_MAKERKANANAMERF
        /// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_MAKERKANANAMERF
        {
            get { return _sALESDETAILRF_MAKERKANANAMERF; }
            set { _sALESDETAILRF_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELHALFNAMERF
        /// <summary>�Ԏ피�p���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ피�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELHALFNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELHALFNAMERF; }
            set { _aCCEPTODRCARRF_MODELHALFNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTGOODSNORF
        /// <summary>����p�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_PRTGOODSNORF
        {
            get { return _sALESDETAILRF_PRTGOODSNORF; }
            set { _sALESDETAILRF_PRTGOODSNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTMAKERCODERF
        /// <summary>����p���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_PRTMAKERCODERF
        {
            get { return _sALESDETAILRF_PRTMAKERCODERF; }
            set { _sALESDETAILRF_PRTMAKERCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTMAKERNAMERF
        /// <summary>����p���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_PRTMAKERNAMERF
        {
            get { return _sALESDETAILRF_PRTMAKERNAMERF; }
            set { _sALESDETAILRF_PRTMAKERNAMERF = value; }
        }

        /// public propaty name  :  DADD_PARTYSALESLIPNUMRF
        /// <summary>�����`�[�ԍ��i�w�b�_�p�j�v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��i�w�b�_�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_PARTYSALESLIPNUMRF
        {
            get { return _dADD_PARTYSALESLIPNUMRF; }
            set { _dADD_PARTYSALESLIPNUMRF = value; }
        }
        /// public propaty name  :  SALESSLIPRF_CONSTAXLAYMETHODRF
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CONSTAXLAYMETHODRF
        {
            get { return _sALESSLIPRF_CONSTAXLAYMETHODRF; }
            set { _sALESSLIPRF_CONSTAXLAYMETHODRF = value; }
        }


        /// <summary>
        /// ���R���[(������)���׃f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EBooksFrePBillDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillDetailWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EBooksFrePBillDetailWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>EBooksFrePBillDetailWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class EBooksFrePBillDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  EBooksFrePBillDetailWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is EBooksFrePBillDetailWork || graph is ArrayList || graph is EBooksFrePBillDetailWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( EBooksFrePBillDetailWork ).FullName ) );

            if ( graph != null && graph is EBooksFrePBillDetailWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EBooksFrePBillDetailWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is EBooksFrePBillDetailWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EBooksFrePBillDetailWork[])graph).Length;
            }
            else if ( graph is EBooksFrePBillDetailWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ACPTANODRSTATUSRF
            //����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESSLIPNUMRF
            //���_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SECTIONCODERF
            //����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SUBSECTIONCODERF
            //�ԓ`�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DEBITNOTEDIVRF
            //����`�[�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESSLIPCDRF
            //���㏤�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESGOODSCDRF
            //���|�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ACCRECDIVCDRF
            //�����v�㋒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DEMANDADDUPSECCDRF
            //������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESDATERF
            //�v����t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ADDUPADATERF
            //���͒S���҃R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_INPUTAGENCDRF
            //���͒S���Җ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_INPUTAGENNMRF
            //������͎҃R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESINPUTCODERF
            //������͎Җ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESINPUTNAMERF
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FRONTEMPLOYEECDRF
            //��t�]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FRONTEMPLOYEENMRF
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESEMPLOYEECDRF
            //�̔��]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESEMPLOYEENMRF
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXINCRF
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXEXCRF
            //���㕔�i���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTTOTALTAXINCRF
            //���㕔�i���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTTOTALTAXEXCRF
            //�����ƍ��v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKTOTALTAXINCRF
            //�����ƍ��v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKTOTALTAXEXCRF
            //���㏬�v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXINCRF
            //���㏬�v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXEXCRF
            //���㕔�i���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTSUBTTLINCRF
            //���㕔�i���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESPRTSUBTTLEXCRF
            //�����Ə��v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKSUBTTLINCRF
            //�����Ə��v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESWORKSUBTTLEXCRF
            //���㏬�v�i�Łj
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXRF
            //���i�l���Ώۊz���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDPARTSDISOUTTAXRF
            //���i�l���Ώۊz���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDPARTSDISINTAXRF
            //��ƒl���Ώۊz���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDWORKDISOUTTAXRF
            //��ƒl���Ώۊz���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDWORKDISINTAXRF
            //���i�l����
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_PARTSDISCOUNTRATERF
            //�H���l����
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_RAVORDISCOUNTRATERF
            //�������z�v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_TOTALCOSTRF
            //����Őŗ�
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_CONSTAXRATERF
            //���������敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_AUTODEPOSITCDRF
            //���������`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_AUTODEPOSITSLIPNORF
            //�����������v�z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_DEPOSITALLOWANCETTLRF
            //���������c��
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_DEPOSITALWCBLNCERF
            //������R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CLAIMCODERF
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CUSTOMERCODERF
            //���Ӑ於��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CUSTOMERNAMERF
            //���Ӑ於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CUSTOMERNAME2RF
            //���Ӑ旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CUSTOMERSNMRF
            //�h��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_HONORIFICTITLERF
            //�[�i��R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ADDRESSEECODERF
            //�[�i�於��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEENAMERF
            //�[�i�於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEENAME2RF
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_PARTYSALESLIPNUMRF
            //�`�[���l
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTERF
            //�`�[���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE2RF
            //�`�[���l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE3RF
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_RETGOODSREASONDIVRF
            //�ԕi���R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RETGOODSREASONRF
            //���׍s��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DETAILROWCOUNTRF
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK1RF
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK2RF
            //�[�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DELIVEREDGOODSDIVRF
            //�[�i�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DELIVEREDGOODSDIVNMRF
            //�݌ɏ��i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
            //�������i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_PUREGOODSTTLTAXEXCRF
            //�r���P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES1RF
            //�r���Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES2RF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SECDTL_SECTIONGUIDENMRF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SECDTL_SECTIONGUIDESNMRF
            //���Ж��̃R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SECDTL_COMPANYNAMECD1RF
            //���㕔�喼��
            serInfo.MemberInfo.Add( typeof( string ) ); //SUBSAL_SUBSECTIONNAMERF
            //�󒍔ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACCEPTANORDERNORF
            //����s�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESROWNORF
            //�[�i�����\���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_DELIGDSCMPLTDUEDATERF
            //���i����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSKINDCODERF
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSMAKERCDRF
            //���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_MAKERNAMERF
            //���i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNORF
            //���i����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMERF
            //���i������
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSSHORTNAMERF
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSLGROUPRF
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSLGROUPNAMERF
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSMGROUPRF
            //���i�����ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSMGROUPNAMERF
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_BLGROUPCODERF
            //BL�O���[�v�R�[�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_BLGROUPNAMERF
            //BL���i�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_BLGOODSCODERF
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_BLGOODSFULLNAMERF
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ENTERPRISEGANRECODERF
            //���Е��ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_ENTERPRISEGANRENAMERF
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSECODERF
            //�q�ɖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSENAMERF
            //�q�ɒI��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSESHELFNORF
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESORDERDIVCDRF
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_OPENPRICEDIVRF
            //���i�|�������N
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSRATERANKRF
            //�艿��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICERATERF
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXINCFLRF
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXEXCFLRF
            //������
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESRATERF
            //����P���i�ō��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNPRCTAXINCFLRF
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNPRCTAXEXCFLRF
            //������
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_COSTRATERF
            //�����P��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNITCOSTRF
            //BL���i�R�[�h�i����j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTBLGOODSCODERF
            //BL���i�R�[�h���́i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTBLGOODSNAMERF
            //��ƍH��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_WORKMANHOURRF
            //�o�א�
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SHIPMENTCNTRF
            //������z�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXINCRF
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXEXCRF
            //����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_COSTRF
            //�ېŋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_TAXATIONDIVCDRF
            //�����`�[�ԍ��i���ׁj
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PARTYSLIPNUMDTLRF
            //���ה��l
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_DTLNOTERF
            //�d����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SUPPLIERCDRF
            //�d���旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SUPPLIERSNMRF
            //�`�[�����P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO1RF
            //�`�[�����Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO2RF
            //�`�[�����R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO3RF
            //�Г������P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO1RF
            //�Г������Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO2RF
            //�Г������R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO3RF
            //�ύX�O�艿
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFLISTPRICERF
            //�ύX�O����
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFSALESUNITPRICERF
            //�ύX�O����
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFUNITCOSTRF
            //�ꎮ���הԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CMPLTSALESROWNORF
            //���[�J�[�R�[�h�i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CMPLTGOODSMAKERCDRF
            //���[�J�[���́i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTMAKERNAMERF
            //���i���́i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTGOODSNAMERF
            //���ʁi�ꎮ�j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSHIPMENTCNTRF
            //����P���i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSALESUNPRCFLRF
            //������z�i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_CMPLTSALESMONEYRF
            //�����P���i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSALESUNITCOSTRF
            //�������z�i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_CMPLTCOSTRF
            //�����`�[�ԍ��i�ꎮ�j
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTPARTYSALSLNUMRF
            //�ꎮ���l
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTNOTERF
            //�ԗ��Ǘ��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_CARMNGNORF
            //���q�Ǘ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_CARMNGCODERF
            //���^�������ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_NUMBERPLATE1CODERF
            //���^�����ǖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE1NAMERF
            //�ԗ��o�^�ԍ��i��ʁj
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE2RF
            //�ԗ��o�^�ԍ��i�J�i�j
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE3RF
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_NUMBERPLATE4RF
            //���N�x
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_FIRSTENTRYDATERF
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MAKERCODERF
            //���[�J�[�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MAKERFULLNAMERF
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELCODERF
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELSUBCODERF
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELFULLNAMERF
            //�r�K�X�L��
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_EXHAUSTGASSIGNRF
            //�V���[�Y�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_SERIESMODELRF
            //�^���i�ޕʋL���j
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_CATEGORYSIGNMODELRF
            //�^���i�t���^�j
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FULLMODELRF
            //�^���w��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELDESIGNATIONNORF
            //�ޕʔԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_CATEGORYNORF
            //�ԑ�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FRAMEMODELRF
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FRAMENORF
            //�ԑ�ԍ��i�����p�j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_SEARCHFRAMENORF
            //�G���W���^������
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_ENGINEMODELNMRF
            //�֘A�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_RELEVANCEMODELRF
            //�T�u�Ԗ��R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_SUBCARNMCDRF
            //�^���O���[�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELGRADESNAMERF
            //�J���[�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_COLORCODERF
            //�J���[����1
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_COLORNAME1RF
            //�g�����R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_TRIMCODERF
            //�g��������
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_TRIMNAMERF
            //�ԗ����s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MILEAGERF
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_ACPTANODRSTATUSRF
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DEPOSITSLIPNORF
            //����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_SALESSLIPNUMRF
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_ADDUPSECCODERF
            //����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_SUBSECTIONCODERF
            //�������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DEPOSITDATERF
            //�v����t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_ADDUPADATERF
            //�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITMAINRF_DEPOSITRF
            //�萔�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITMAINRF_FEEDEPOSITRF
            //�l�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITMAINRF_DISCOUNTDEPOSITRF
            //���������敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_AUTODEPOSITCDRF
            //�a����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DEPOSITCDRF
            //��`�U�o��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DRAFTDRAWINGDATERF
            //��`���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_DRAFTKINDRF
            //��`��ޖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_DRAFTKINDNAMERF
            //��`�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_DRAFTDIVIDENAMERF
            //��`�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_DRAFTNORF
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_CUSTOMERCODERF
            //������R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITMAINRF_CLAIMCODERF
            //�`�[�E�v
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_OUTLINERF
            //�����������喼��
            serInfo.MemberInfo.Add( typeof( string ) ); //SUBDEP_SUBSECTIONNAMERF
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_DEPOSITSLIPNORF
            //�����s�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_DEPOSITROWNORF
            //����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_MONEYKINDCODERF
            //���햼��
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITDTLRF_MONEYKINDNAMERF
            //����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_MONEYKINDDIVRF
            //�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPSITDTLRF_DEPOSITRF
            //�L������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPSITDTLRF_VALIDITYTERMRF
            //�󒍃X�e�[�^�X����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_ACPTANODRSTATUSRF
            //�ԓ`�敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEBITNOTEDIVRF
            //����`�[�敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESSLIPCDRF
            //������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATERF
            //������t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFYRF
            //������t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFSRF
            //������t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFWRF
            //������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFMRF
            //������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESDATEFDRF
            //������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFGRF
            //������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFRRF
            //������t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLSRF
            //������t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLPRF
            //������t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLYRF
            //������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLMRF
            //������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESDATEFLDRF
            //��񏤕i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_STOCKGOODSTTLTAXEXCRF
            //�D�Ǐ��i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_PUREGOODSTTLTAXEXCRF
            //���i��������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_GOODSKINDCODERF
            //����݌Ɏ�񂹋敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_SALESORDERDIVCDRF
            //�I�[�v�����i�敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_OPENPRICEDIVRF
            //�ېŋ敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_TAXATIONDIVCDRF
            //���N�x����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFYRF
            //���N�x����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFSRF
            //���N�x�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFWRF
            //���N�x��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFMRF
            //���N�x����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFGRF
            //���N�x����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFRRF
            //���N�x���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLSRF
            //���N�x���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLPRF
            //���N�x���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLYRF
            //���N�x���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLMRF
            //�������t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFYRF
            //�������t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFSRF
            //�������t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFWRF
            //�������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFMRF
            //�������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITDATEFDRF
            //�������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFGRF
            //�������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFRRF
            //�������t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLSRF
            //�������t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLPRF
            //�������t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLYRF
            //�������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLMRF
            //�������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DEPOSITDATEFLDRF
            //���������敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_AUTODEPOSITCDRF
            //�a����敪����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DEPOSITCDRF
            //��`�U�o������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFYRF
            //��`�U�o������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFSRF
            //��`�U�o���a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFWRF
            //��`�U�o����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFMRF
            //��`�U�o����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTDRAWINGDATEFDRF
            //��`�U�o������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFGRF
            //��`�U�o������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFRRF
            //��`�U�o�����e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLSRF
            //��`�U�o�����e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLPRF
            //��`�U�o�����e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLYRF
            //��`�U�o�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLMRF
            //��`�U�o�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTDRAWINGDATEFLDRF
            //��`�x����������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFYRF
            //��`�x����������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFSRF
            //��`�x�������a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFWRF
            //��`�x��������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFMRF
            //��`�x��������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DRAFTPAYTIMELIMITFDRF
            //��`�x����������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFGRF
            //��`�x����������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFRRF
            //��`�x���������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLSRF
            //��`�x���������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLPRF
            //��`�x���������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLYRF
            //��`�x���������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLMRF
            //��`�x���������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DRAFTPAYTIMELIMITFLDRF
            //�L����������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFYRF
            //�L����������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFSRF
            //�L�������a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFWRF
            //�L��������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFMRF
            //�L��������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_VALIDITYTERMFDRF
            //�L����������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFGRF
            //�L����������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFRRF
            //�L���������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLSRF
            //�L���������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLPRF
            //�L���������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLYRF
            //�L���������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLMRF
            //�L���������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_VALIDITYTERMFLDRF
            //�������דE�v
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DMDDTLOUTLINERF
            //����`�[�v�^�C�g��
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTTITLERF
            //����`�[�v���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_SALESFTPRICERF
            //����`�[�v���l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTNOTE1RF
            //����`�[�v���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTNOTE2RF
            //����`�[�v���l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESFTNOTE3RF
            //���ד`�[�^�C�g��(����/�ԕi)
            serInfo.MemberInfo.Add( typeof( string ) ); //DSAL_DETAILTITLE
            //����W�v�^�C�g��
            serInfo.MemberInfo.Add( typeof( string ) ); //DSAL_DETAILSUMTITLE
            //����W�v���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DSAL_DETAILSUMPRICE
            //���ד`�[�^�C�g��(����)
            serInfo.MemberInfo.Add( typeof( string ) ); //DDEP_DETAILTITLE
            //�����W�v�^�C�g��
            serInfo.MemberInfo.Add( typeof( string ) ); //DDEP_DETAILSUMTITLE
            //�����W�v���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DDEP_DETAILSUMPRICE
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESSLIPCDDTLRF
            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RESULTSADDUPSECCDRF
            //�������͋��_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPSITMAINRF_INPUTDEPOSITSECCDRF
            //���i���̃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMEKANARF
            //���[�J�[�J�i����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_MAKERKANANAMERF
            //�Ԏ피�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELHALFNAMERF
            //����p�i��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTGOODSNORF
            //����p���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTMAKERCODERF
            //����p���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTMAKERNAMERF
            //�����`�[�ԍ��i�w�b�_�p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_PARTYSALESLIPNUMRF
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //SALESSLIPRF_CONSTAXLAYMETHODRF


            serInfo.Serialize( writer, serInfo );
            if ( graph is EBooksFrePBillDetailWork )
            {
                EBooksFrePBillDetailWork temp = (EBooksFrePBillDetailWork)graph;

                SetEBooksFrePBillDetailWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is EBooksFrePBillDetailWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (EBooksFrePBillDetailWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( EBooksFrePBillDetailWork temp in lst )
                {
                    SetEBooksFrePBillDetailWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// EBooksFrePBillDetailWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 301;

        /// <summary>
        ///  EBooksFrePBillDetailWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillDetailWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEBooksFrePBillDetailWork( System.IO.BinaryWriter writer, EBooksFrePBillDetailWork temp )
        {
            //�󒍃X�e�[�^�X
            writer.Write( temp.SALESSLIPRF_ACPTANODRSTATUSRF );
            //����`�[�ԍ�
            writer.Write( temp.SALESSLIPRF_SALESSLIPNUMRF );
            //���_�R�[�h
            writer.Write( temp.SALESSLIPRF_SECTIONCODERF );
            //����R�[�h
            writer.Write( temp.SALESSLIPRF_SUBSECTIONCODERF );
            //�ԓ`�敪
            writer.Write( temp.SALESSLIPRF_DEBITNOTEDIVRF );
            //����`�[�敪
            writer.Write( temp.SALESSLIPRF_SALESSLIPCDRF );
            //���㏤�i�敪
            writer.Write( temp.SALESSLIPRF_SALESGOODSCDRF );
            //���|�敪
            writer.Write( temp.SALESSLIPRF_ACCRECDIVCDRF );
            //�����v�㋒�_�R�[�h
            writer.Write( temp.SALESSLIPRF_DEMANDADDUPSECCDRF );
            //������t
            writer.Write( temp.SALESSLIPRF_SALESDATERF );
            //�v����t
            writer.Write( temp.SALESSLIPRF_ADDUPADATERF );
            //���͒S���҃R�[�h
            writer.Write( temp.SALESSLIPRF_INPUTAGENCDRF );
            //���͒S���Җ���
            writer.Write( temp.SALESSLIPRF_INPUTAGENNMRF );
            //������͎҃R�[�h
            writer.Write( temp.SALESSLIPRF_SALESINPUTCODERF );
            //������͎Җ���
            writer.Write( temp.SALESSLIPRF_SALESINPUTNAMERF );
            //��t�]�ƈ��R�[�h
            writer.Write( temp.SALESSLIPRF_FRONTEMPLOYEECDRF );
            //��t�]�ƈ�����
            writer.Write( temp.SALESSLIPRF_FRONTEMPLOYEENMRF );
            //�̔��]�ƈ��R�[�h
            writer.Write( temp.SALESSLIPRF_SALESEMPLOYEECDRF );
            //�̔��]�ƈ�����
            writer.Write( temp.SALESSLIPRF_SALESEMPLOYEENMRF );
            //����`�[���v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXINCRF );
            //����`�[���v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXEXCRF );
            //���㕔�i���v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESPRTTOTALTAXINCRF );
            //���㕔�i���v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESPRTTOTALTAXEXCRF );
            //�����ƍ��v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESWORKTOTALTAXINCRF );
            //�����ƍ��v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESWORKTOTALTAXEXCRF );
            //���㏬�v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF );
            //���㏬�v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF );
            //���㕔�i���v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESPRTSUBTTLINCRF );
            //���㕔�i���v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESPRTSUBTTLEXCRF );
            //�����Ə��v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESWORKSUBTTLINCRF );
            //�����Ə��v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESWORKSUBTTLEXCRF );
            //���㏬�v�i�Łj
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXRF );
            //���i�l���Ώۊz���v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_ITDEDPARTSDISOUTTAXRF );
            //���i�l���Ώۊz���v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_ITDEDPARTSDISINTAXRF );
            //��ƒl���Ώۊz���v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_ITDEDWORKDISOUTTAXRF );
            //��ƒl���Ώۊz���v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_ITDEDWORKDISINTAXRF );
            //���i�l����
            writer.Write( temp.SALESSLIPRF_PARTSDISCOUNTRATERF );
            //�H���l����
            writer.Write( temp.SALESSLIPRF_RAVORDISCOUNTRATERF );
            //�������z�v
            writer.Write( temp.SALESSLIPRF_TOTALCOSTRF );
            //����Őŗ�
            writer.Write( temp.SALESSLIPRF_CONSTAXRATERF );
            //���������敪
            writer.Write( temp.SALESSLIPRF_AUTODEPOSITCDRF );
            //���������`�[�ԍ�
            writer.Write( temp.SALESSLIPRF_AUTODEPOSITSLIPNORF );
            //�����������v�z
            writer.Write( temp.SALESSLIPRF_DEPOSITALLOWANCETTLRF );
            //���������c��
            writer.Write( temp.SALESSLIPRF_DEPOSITALWCBLNCERF );
            //������R�[�h
            writer.Write( temp.SALESSLIPRF_CLAIMCODERF );
            //���Ӑ�R�[�h
            writer.Write( temp.SALESSLIPRF_CUSTOMERCODERF );
            //���Ӑ於��
            writer.Write( temp.SALESSLIPRF_CUSTOMERNAMERF );
            //���Ӑ於��2
            writer.Write( temp.SALESSLIPRF_CUSTOMERNAME2RF );
            //���Ӑ旪��
            writer.Write( temp.SALESSLIPRF_CUSTOMERSNMRF );
            //�h��
            writer.Write( temp.SALESSLIPRF_HONORIFICTITLERF );
            //�[�i��R�[�h
            writer.Write( temp.SALESSLIPRF_ADDRESSEECODERF );
            //�[�i�於��
            writer.Write( temp.SALESSLIPRF_ADDRESSEENAMERF );
            //�[�i�於��2
            writer.Write( temp.SALESSLIPRF_ADDRESSEENAME2RF );
            //�����`�[�ԍ�
            writer.Write( temp.SALESSLIPRF_PARTYSALESLIPNUMRF );
            //�`�[���l
            writer.Write( temp.SALESSLIPRF_SLIPNOTERF );
            //�`�[���l�Q
            writer.Write( temp.SALESSLIPRF_SLIPNOTE2RF );
            //�`�[���l�R
            writer.Write( temp.SALESSLIPRF_SLIPNOTE3RF );
            //�ԕi���R�R�[�h
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONDIVRF );
            //�ԕi���R
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONRF );
            //���׍s��
            writer.Write( temp.SALESSLIPRF_DETAILROWCOUNTRF );
            //�t�n�d���}�[�N�P
            writer.Write( temp.SALESSLIPRF_UOEREMARK1RF );
            //�t�n�d���}�[�N�Q
            writer.Write( temp.SALESSLIPRF_UOEREMARK2RF );
            //�[�i�敪
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVRF );
            //�[�i�敪����
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF );
            //�݌ɏ��i���v���z�i�Ŕ��j
            writer.Write( temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF );
            //�������i���v���z�i�Ŕ��j
            writer.Write( temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF );
            //�r���P
            writer.Write( temp.SALESSLIPRF_FOOTNOTES1RF );
            //�r���Q
            writer.Write( temp.SALESSLIPRF_FOOTNOTES2RF );
            //���_�K�C�h����
            writer.Write( temp.SECDTL_SECTIONGUIDENMRF );
            //���_�K�C�h����
            writer.Write( temp.SECDTL_SECTIONGUIDESNMRF );
            //���Ж��̃R�[�h1
            writer.Write( temp.SECDTL_COMPANYNAMECD1RF );
            //���㕔�喼��
            writer.Write( temp.SUBSAL_SUBSECTIONNAMERF );
            //�󒍔ԍ�
            writer.Write( temp.SALESDETAILRF_ACCEPTANORDERNORF );
            //����s�ԍ�
            writer.Write( temp.SALESDETAILRF_SALESROWNORF );
            //�[�i�����\���
            writer.Write( temp.SALESDETAILRF_DELIGDSCMPLTDUEDATERF );
            //���i����
            writer.Write( temp.SALESDETAILRF_GOODSKINDCODERF );
            //���i���[�J�[�R�[�h
            writer.Write( temp.SALESDETAILRF_GOODSMAKERCDRF );
            //���[�J�[����
            writer.Write( temp.SALESDETAILRF_MAKERNAMERF );
            //���i�ԍ�
            writer.Write( temp.SALESDETAILRF_GOODSNORF );
            //���i����
            writer.Write( temp.SALESDETAILRF_GOODSNAMERF );
            //���i������
            writer.Write( temp.SALESDETAILRF_GOODSSHORTNAMERF );
            //���i�啪�ރR�[�h
            writer.Write( temp.SALESDETAILRF_GOODSLGROUPRF );
            //���i�啪�ޖ���
            writer.Write( temp.SALESDETAILRF_GOODSLGROUPNAMERF );
            //���i�����ރR�[�h
            writer.Write( temp.SALESDETAILRF_GOODSMGROUPRF );
            //���i�����ޖ���
            writer.Write( temp.SALESDETAILRF_GOODSMGROUPNAMERF );
            //BL�O���[�v�R�[�h
            writer.Write( temp.SALESDETAILRF_BLGROUPCODERF );
            //BL�O���[�v�R�[�h����
            writer.Write( temp.SALESDETAILRF_BLGROUPNAMERF );
            //BL���i�R�[�h
            writer.Write( temp.SALESDETAILRF_BLGOODSCODERF );
            //BL���i�R�[�h���́i�S�p�j
            writer.Write( temp.SALESDETAILRF_BLGOODSFULLNAMERF );
            //���Е��ރR�[�h
            writer.Write( temp.SALESDETAILRF_ENTERPRISEGANRECODERF );
            //���Е��ޖ���
            writer.Write( temp.SALESDETAILRF_ENTERPRISEGANRENAMERF );
            //�q�ɃR�[�h
            writer.Write( temp.SALESDETAILRF_WAREHOUSECODERF );
            //�q�ɖ���
            writer.Write( temp.SALESDETAILRF_WAREHOUSENAMERF );
            //�q�ɒI��
            writer.Write( temp.SALESDETAILRF_WAREHOUSESHELFNORF );
            //����݌Ɏ�񂹋敪
            writer.Write( temp.SALESDETAILRF_SALESORDERDIVCDRF );
            //�I�[�v�����i�敪
            writer.Write( temp.SALESDETAILRF_OPENPRICEDIVRF );
            //���i�|�������N
            writer.Write( temp.SALESDETAILRF_GOODSRATERANKRF );
            //�艿��
            writer.Write( temp.SALESDETAILRF_LISTPRICERATERF );
            //�艿�i�ō��C�����j
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXINCFLRF );
            //�艿�i�Ŕ��C�����j
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXEXCFLRF );
            //������
            writer.Write( temp.SALESDETAILRF_SALESRATERF );
            //����P���i�ō��C�����j
            writer.Write( temp.SALESDETAILRF_SALESUNPRCTAXINCFLRF );
            //����P���i�Ŕ��C�����j
            writer.Write( temp.SALESDETAILRF_SALESUNPRCTAXEXCFLRF );
            //������
            writer.Write( temp.SALESDETAILRF_COSTRATERF );
            //�����P��
            writer.Write( temp.SALESDETAILRF_SALESUNITCOSTRF );
            //BL���i�R�[�h�i����j
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSCODERF );
            //BL���i�R�[�h���́i����j
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSNAMERF );
            //��ƍH��
            writer.Write( temp.SALESDETAILRF_WORKMANHOURRF );
            //�o�א�
            writer.Write( temp.SALESDETAILRF_SHIPMENTCNTRF );
            //������z�i�ō��݁j
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXINCRF );
            //������z�i�Ŕ����j
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXEXCRF );
            //����
            writer.Write( temp.SALESDETAILRF_COSTRF );
            //�ېŋ敪
            writer.Write( temp.SALESDETAILRF_TAXATIONDIVCDRF );
            //�����`�[�ԍ��i���ׁj
            writer.Write( temp.SALESDETAILRF_PARTYSLIPNUMDTLRF );
            //���ה��l
            writer.Write( temp.SALESDETAILRF_DTLNOTERF );
            //�d����R�[�h
            writer.Write( temp.SALESDETAILRF_SUPPLIERCDRF );
            //�d���旪��
            writer.Write( temp.SALESDETAILRF_SUPPLIERSNMRF );
            //�`�[�����P
            writer.Write( temp.SALESDETAILRF_SLIPMEMO1RF );
            //�`�[�����Q
            writer.Write( temp.SALESDETAILRF_SLIPMEMO2RF );
            //�`�[�����R
            writer.Write( temp.SALESDETAILRF_SLIPMEMO3RF );
            //�Г������P
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO1RF );
            //�Г������Q
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO2RF );
            //�Г������R
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO3RF );
            //�ύX�O�艿
            writer.Write( temp.SALESDETAILRF_BFLISTPRICERF );
            //�ύX�O����
            writer.Write( temp.SALESDETAILRF_BFSALESUNITPRICERF );
            //�ύX�O����
            writer.Write( temp.SALESDETAILRF_BFUNITCOSTRF );
            //�ꎮ���הԍ�
            writer.Write( temp.SALESDETAILRF_CMPLTSALESROWNORF );
            //���[�J�[�R�[�h�i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTGOODSMAKERCDRF );
            //���[�J�[���́i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTMAKERNAMERF );
            //���i���́i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTGOODSNAMERF );
            //���ʁi�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTSHIPMENTCNTRF );
            //����P���i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTSALESUNPRCFLRF );
            //������z�i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTSALESMONEYRF );
            //�����P���i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTSALESUNITCOSTRF );
            //�������z�i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTCOSTRF );
            //�����`�[�ԍ��i�ꎮ�j
            writer.Write( temp.SALESDETAILRF_CMPLTPARTYSALSLNUMRF );
            //�ꎮ���l
            writer.Write( temp.SALESDETAILRF_CMPLTNOTERF );
            //�ԗ��Ǘ��ԍ�
            writer.Write( temp.ACCEPTODRCARRF_CARMNGNORF );
            //���q�Ǘ��R�[�h
            writer.Write( temp.ACCEPTODRCARRF_CARMNGCODERF );
            //���^�������ԍ�
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE1CODERF );
            //���^�����ǖ���
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE1NAMERF );
            //�ԗ��o�^�ԍ��i��ʁj
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE2RF );
            //�ԗ��o�^�ԍ��i�J�i�j
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE3RF );
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE4RF );
            //���N�x
            writer.Write( temp.ACCEPTODRCARRF_FIRSTENTRYDATERF );
            //���[�J�[�R�[�h
            writer.Write( temp.ACCEPTODRCARRF_MAKERCODERF );
            //���[�J�[�S�p����
            writer.Write( temp.ACCEPTODRCARRF_MAKERFULLNAMERF );
            //�Ԏ�R�[�h
            writer.Write( temp.ACCEPTODRCARRF_MODELCODERF );
            //�Ԏ�T�u�R�[�h
            writer.Write( temp.ACCEPTODRCARRF_MODELSUBCODERF );
            //�Ԏ�S�p����
            writer.Write( temp.ACCEPTODRCARRF_MODELFULLNAMERF );
            //�r�K�X�L��
            writer.Write( temp.ACCEPTODRCARRF_EXHAUSTGASSIGNRF );
            //�V���[�Y�^��
            writer.Write( temp.ACCEPTODRCARRF_SERIESMODELRF );
            //�^���i�ޕʋL���j
            writer.Write( temp.ACCEPTODRCARRF_CATEGORYSIGNMODELRF );
            //�^���i�t���^�j
            writer.Write( temp.ACCEPTODRCARRF_FULLMODELRF );
            //�^���w��ԍ�
            writer.Write( temp.ACCEPTODRCARRF_MODELDESIGNATIONNORF );
            //�ޕʔԍ�
            writer.Write( temp.ACCEPTODRCARRF_CATEGORYNORF );
            //�ԑ�^��
            writer.Write( temp.ACCEPTODRCARRF_FRAMEMODELRF );
            //�ԑ�ԍ�
            writer.Write( temp.ACCEPTODRCARRF_FRAMENORF );
            //�ԑ�ԍ��i�����p�j
            writer.Write( temp.ACCEPTODRCARRF_SEARCHFRAMENORF );
            //�G���W���^������
            writer.Write( temp.ACCEPTODRCARRF_ENGINEMODELNMRF );
            //�֘A�^��
            writer.Write( temp.ACCEPTODRCARRF_RELEVANCEMODELRF );
            //�T�u�Ԗ��R�[�h
            writer.Write( temp.ACCEPTODRCARRF_SUBCARNMCDRF );
            //�^���O���[�h����
            writer.Write( temp.ACCEPTODRCARRF_MODELGRADESNAMERF );
            //�J���[�R�[�h
            writer.Write( temp.ACCEPTODRCARRF_COLORCODERF );
            //�J���[����1
            writer.Write( temp.ACCEPTODRCARRF_COLORNAME1RF );
            //�g�����R�[�h
            writer.Write( temp.ACCEPTODRCARRF_TRIMCODERF );
            //�g��������
            writer.Write( temp.ACCEPTODRCARRF_TRIMNAMERF );
            //�ԗ����s����
            writer.Write( temp.ACCEPTODRCARRF_MILEAGERF );
            //�󒍃X�e�[�^�X
            writer.Write( temp.DEPSITMAINRF_ACPTANODRSTATUSRF );
            //�����`�[�ԍ�
            writer.Write( temp.DEPSITMAINRF_DEPOSITSLIPNORF );
            //����`�[�ԍ�
            writer.Write( temp.DEPSITMAINRF_SALESSLIPNUMRF );
            //�v�㋒�_�R�[�h
            writer.Write( temp.DEPSITMAINRF_ADDUPSECCODERF );
            //����R�[�h
            writer.Write( temp.DEPSITMAINRF_SUBSECTIONCODERF );
            //�������t
            writer.Write( temp.DEPSITMAINRF_DEPOSITDATERF );
            //�v����t
            writer.Write( temp.DEPSITMAINRF_ADDUPADATERF );
            //�������z
            writer.Write( temp.DEPSITMAINRF_DEPOSITRF );
            //�萔�������z
            writer.Write( temp.DEPSITMAINRF_FEEDEPOSITRF );
            //�l�������z
            writer.Write( temp.DEPSITMAINRF_DISCOUNTDEPOSITRF );
            //���������敪
            writer.Write( temp.DEPSITMAINRF_AUTODEPOSITCDRF );
            //�a����敪
            writer.Write( temp.DEPSITMAINRF_DEPOSITCDRF );
            //��`�U�o��
            writer.Write( temp.DEPSITMAINRF_DRAFTDRAWINGDATERF );
            //��`���
            writer.Write( temp.DEPSITMAINRF_DRAFTKINDRF );
            //��`��ޖ���
            writer.Write( temp.DEPSITMAINRF_DRAFTKINDNAMERF );
            //��`�敪����
            writer.Write( temp.DEPSITMAINRF_DRAFTDIVIDENAMERF );
            //��`�ԍ�
            writer.Write( temp.DEPSITMAINRF_DRAFTNORF );
            //���Ӑ�R�[�h
            writer.Write( temp.DEPSITMAINRF_CUSTOMERCODERF );
            //������R�[�h
            writer.Write( temp.DEPSITMAINRF_CLAIMCODERF );
            //�`�[�E�v
            writer.Write( temp.DEPSITMAINRF_OUTLINERF );
            //�����������喼��
            writer.Write( temp.SUBDEP_SUBSECTIONNAMERF );
            //�����`�[�ԍ�
            writer.Write( temp.DEPSITDTLRF_DEPOSITSLIPNORF );
            //�����s�ԍ�
            writer.Write( temp.DEPSITDTLRF_DEPOSITROWNORF );
            //����R�[�h
            writer.Write( temp.DEPSITDTLRF_MONEYKINDCODERF );
            //���햼��
            writer.Write( temp.DEPSITDTLRF_MONEYKINDNAMERF );
            //����敪
            writer.Write( temp.DEPSITDTLRF_MONEYKINDDIVRF );
            //�������z
            writer.Write( temp.DEPSITDTLRF_DEPOSITRF );
            //�L������
            writer.Write( temp.DEPSITDTLRF_VALIDITYTERMRF );
            //�󒍃X�e�[�^�X����
            writer.Write( temp.DADD_ACPTANODRSTATUSRF );
            //�ԓ`�敪����
            writer.Write( temp.DADD_DEBITNOTEDIVRF );
            //����`�[�敪����
            writer.Write( temp.DADD_SALESSLIPCDRF );
            //������t
            writer.Write( temp.DADD_SALESDATERF );
            //������t����N
            writer.Write( temp.DADD_SALESDATEFYRF );
            //������t����N��
            writer.Write( temp.DADD_SALESDATEFSRF );
            //������t�a��N
            writer.Write( temp.DADD_SALESDATEFWRF );
            //������t��
            writer.Write( temp.DADD_SALESDATEFMRF );
            //������t��
            writer.Write( temp.DADD_SALESDATEFDRF );
            //������t����
            writer.Write( temp.DADD_SALESDATEFGRF );
            //������t����
            writer.Write( temp.DADD_SALESDATEFRRF );
            //������t���e����(/)
            writer.Write( temp.DADD_SALESDATEFLSRF );
            //������t���e����(.)
            writer.Write( temp.DADD_SALESDATEFLPRF );
            //������t���e����(�N)
            writer.Write( temp.DADD_SALESDATEFLYRF );
            //������t���e����(��)
            writer.Write( temp.DADD_SALESDATEFLMRF );
            //������t���e����(��)
            writer.Write( temp.DADD_SALESDATEFLDRF );
            //��񏤕i���v���z�i�Ŕ��j
            writer.Write( temp.DADD_STOCKGOODSTTLTAXEXCRF );
            //�D�Ǐ��i���v���z�i�Ŕ��j
            writer.Write( temp.DADD_PUREGOODSTTLTAXEXCRF );
            //���i��������
            writer.Write( temp.DADD_GOODSKINDCODERF );
            //����݌Ɏ�񂹋敪����
            writer.Write( temp.DADD_SALESORDERDIVCDRF );
            //�I�[�v�����i�敪����
            writer.Write( temp.DADD_OPENPRICEDIVRF );
            //�ېŋ敪����
            writer.Write( temp.DADD_TAXATIONDIVCDRF );
            //���N�x����N
            writer.Write( temp.DADD_FIRSTENTRYDATEFYRF );
            //���N�x����N��
            writer.Write( temp.DADD_FIRSTENTRYDATEFSRF );
            //���N�x�a��N
            writer.Write( temp.DADD_FIRSTENTRYDATEFWRF );
            //���N�x��
            writer.Write( temp.DADD_FIRSTENTRYDATEFMRF );
            //���N�x����
            writer.Write( temp.DADD_FIRSTENTRYDATEFGRF );
            //���N�x����
            writer.Write( temp.DADD_FIRSTENTRYDATEFRRF );
            //���N�x���e����(/)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLSRF );
            //���N�x���e����(.)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLPRF );
            //���N�x���e����(�N)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLYRF );
            //���N�x���e����(��)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLMRF );
            //�������t����N
            writer.Write( temp.DADD_DEPOSITDATEFYRF );
            //�������t����N��
            writer.Write( temp.DADD_DEPOSITDATEFSRF );
            //�������t�a��N
            writer.Write( temp.DADD_DEPOSITDATEFWRF );
            //�������t��
            writer.Write( temp.DADD_DEPOSITDATEFMRF );
            //�������t��
            writer.Write( temp.DADD_DEPOSITDATEFDRF );
            //�������t����
            writer.Write( temp.DADD_DEPOSITDATEFGRF );
            //�������t����
            writer.Write( temp.DADD_DEPOSITDATEFRRF );
            //�������t���e����(/)
            writer.Write( temp.DADD_DEPOSITDATEFLSRF );
            //�������t���e����(.)
            writer.Write( temp.DADD_DEPOSITDATEFLPRF );
            //�������t���e����(�N)
            writer.Write( temp.DADD_DEPOSITDATEFLYRF );
            //�������t���e����(��)
            writer.Write( temp.DADD_DEPOSITDATEFLMRF );
            //�������t���e����(��)
            writer.Write( temp.DADD_DEPOSITDATEFLDRF );
            //���������敪����
            writer.Write( temp.DADD_AUTODEPOSITCDRF );
            //�a����敪����
            writer.Write( temp.DADD_DEPOSITCDRF );
            //��`�U�o������N
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFYRF );
            //��`�U�o������N��
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFSRF );
            //��`�U�o���a��N
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFWRF );
            //��`�U�o����
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFMRF );
            //��`�U�o����
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFDRF );
            //��`�U�o������
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFGRF );
            //��`�U�o������
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFRRF );
            //��`�U�o�����e����(/)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLSRF );
            //��`�U�o�����e����(.)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLPRF );
            //��`�U�o�����e����(�N)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLYRF );
            //��`�U�o�����e����(��)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLMRF );
            //��`�U�o�����e����(��)
            writer.Write( temp.DADD_DRAFTDRAWINGDATEFLDRF );
            //��`�x����������N
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFYRF );
            //��`�x����������N��
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFSRF );
            //��`�x�������a��N
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFWRF );
            //��`�x��������
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFMRF );
            //��`�x��������
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFDRF );
            //��`�x����������
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFGRF );
            //��`�x����������
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFRRF );
            //��`�x���������e����(/)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLSRF );
            //��`�x���������e����(.)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLPRF );
            //��`�x���������e����(�N)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLYRF );
            //��`�x���������e����(��)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLMRF );
            //��`�x���������e����(��)
            writer.Write( temp.DADD_DRAFTPAYTIMELIMITFLDRF );
            //�L����������N
            writer.Write( temp.DADD_VALIDITYTERMFYRF );
            //�L����������N��
            writer.Write( temp.DADD_VALIDITYTERMFSRF );
            //�L�������a��N
            writer.Write( temp.DADD_VALIDITYTERMFWRF );
            //�L��������
            writer.Write( temp.DADD_VALIDITYTERMFMRF );
            //�L��������
            writer.Write( temp.DADD_VALIDITYTERMFDRF );
            //�L����������
            writer.Write( temp.DADD_VALIDITYTERMFGRF );
            //�L����������
            writer.Write( temp.DADD_VALIDITYTERMFRRF );
            //�L���������e����(/)
            writer.Write( temp.DADD_VALIDITYTERMFLSRF );
            //�L���������e����(.)
            writer.Write( temp.DADD_VALIDITYTERMFLPRF );
            //�L���������e����(�N)
            writer.Write( temp.DADD_VALIDITYTERMFLYRF );
            //�L���������e����(��)
            writer.Write( temp.DADD_VALIDITYTERMFLMRF );
            //�L���������e����(��)
            writer.Write( temp.DADD_VALIDITYTERMFLDRF );
            //�������דE�v
            writer.Write( temp.DADD_DMDDTLOUTLINERF );
            //����`�[�v�^�C�g��
            writer.Write( temp.DADD_SALESFTTITLERF );
            //����`�[�v���z
            writer.Write( temp.DADD_SALESFTPRICERF );
            //����`�[�v���l�P
            writer.Write( temp.DADD_SALESFTNOTE1RF );
            //����`�[�v���l�Q
            writer.Write( temp.DADD_SALESFTNOTE2RF );
            //����`�[�v���l�R
            writer.Write( temp.DADD_SALESFTNOTE3RF );
            //���ד`�[�^�C�g��(����/�ԕi)
            writer.Write( temp.DSAL_DETAILTITLE );
            //����W�v�^�C�g��
            writer.Write( temp.DSAL_DETAILSUMTITLE );
            //����W�v���z
            writer.Write( temp.DSAL_DETAILSUMPRICE );
            //���ד`�[�^�C�g��(����)
            writer.Write( temp.DDEP_DETAILTITLE );
            //�����W�v�^�C�g��
            writer.Write( temp.DDEP_DETAILSUMTITLE );
            //�����W�v���z
            writer.Write( temp.DDEP_DETAILSUMPRICE );
            //����`�[�敪�i���ׁj
            writer.Write( temp.SALESDETAILRF_SALESSLIPCDDTLRF );
            //���ьv�㋒�_�R�[�h
            writer.Write( temp.SALESSLIPRF_RESULTSADDUPSECCDRF );
            //�������͋��_�R�[�h
            writer.Write( temp.DEPSITMAINRF_INPUTDEPOSITSECCDRF );
            //���i���̃J�i
            writer.Write( temp.SALESDETAILRF_GOODSNAMEKANARF );
            //���[�J�[�J�i����
            writer.Write( temp.SALESDETAILRF_MAKERKANANAMERF );
            //�Ԏ피�p����
            writer.Write( temp.ACCEPTODRCARRF_MODELHALFNAMERF );
            //����p�i��
            writer.Write( temp.SALESDETAILRF_PRTGOODSNORF );
            //����p���[�J�[�R�[�h
            writer.Write( temp.SALESDETAILRF_PRTMAKERCODERF );
            //����p���[�J�[����
            writer.Write( temp.SALESDETAILRF_PRTMAKERNAMERF );
            //�����`�[�ԍ��i�w�b�_�p�j
            writer.Write( temp.DADD_PARTYSALESLIPNUMRF );
            //����œ]�ŕ���
            writer.Write(temp.SALESSLIPRF_CONSTAXLAYMETHODRF);
        }

        /// <summary>
        ///  EBooksFrePBillDetailWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EBooksFrePBillDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillDetailWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private EBooksFrePBillDetailWork GetEBooksFrePBillDetailWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EBooksFrePBillDetailWork temp = new EBooksFrePBillDetailWork();

            //�󒍃X�e�[�^�X
            temp.SALESSLIPRF_ACPTANODRSTATUSRF = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SALESSLIPRF_SALESSLIPNUMRF = reader.ReadString();
            //���_�R�[�h
            temp.SALESSLIPRF_SECTIONCODERF = reader.ReadString();
            //����R�[�h
            temp.SALESSLIPRF_SUBSECTIONCODERF = reader.ReadInt32();
            //�ԓ`�敪
            temp.SALESSLIPRF_DEBITNOTEDIVRF = reader.ReadInt32();
            //����`�[�敪
            temp.SALESSLIPRF_SALESSLIPCDRF = reader.ReadInt32();
            //���㏤�i�敪
            temp.SALESSLIPRF_SALESGOODSCDRF = reader.ReadInt32();
            //���|�敪
            temp.SALESSLIPRF_ACCRECDIVCDRF = reader.ReadInt32();
            //�����v�㋒�_�R�[�h
            temp.SALESSLIPRF_DEMANDADDUPSECCDRF = reader.ReadString();
            //������t
            temp.SALESSLIPRF_SALESDATERF = reader.ReadInt32();
            //�v����t
            temp.SALESSLIPRF_ADDUPADATERF = reader.ReadInt32();
            //���͒S���҃R�[�h
            temp.SALESSLIPRF_INPUTAGENCDRF = reader.ReadString();
            //���͒S���Җ���
            temp.SALESSLIPRF_INPUTAGENNMRF = reader.ReadString();
            //������͎҃R�[�h
            temp.SALESSLIPRF_SALESINPUTCODERF = reader.ReadString();
            //������͎Җ���
            temp.SALESSLIPRF_SALESINPUTNAMERF = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.SALESSLIPRF_FRONTEMPLOYEECDRF = reader.ReadString();
            //��t�]�ƈ�����
            temp.SALESSLIPRF_FRONTEMPLOYEENMRF = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SALESSLIPRF_SALESEMPLOYEECDRF = reader.ReadString();
            //�̔��]�ƈ�����
            temp.SALESSLIPRF_SALESEMPLOYEENMRF = reader.ReadString();
            //����`�[���v�i�ō��݁j
            temp.SALESSLIPRF_SALESTOTALTAXINCRF = reader.ReadInt64();
            //����`�[���v�i�Ŕ����j
            temp.SALESSLIPRF_SALESTOTALTAXEXCRF = reader.ReadInt64();
            //���㕔�i���v�i�ō��݁j
            temp.SALESSLIPRF_SALESPRTTOTALTAXINCRF = reader.ReadInt64();
            //���㕔�i���v�i�Ŕ����j
            temp.SALESSLIPRF_SALESPRTTOTALTAXEXCRF = reader.ReadInt64();
            //�����ƍ��v�i�ō��݁j
            temp.SALESSLIPRF_SALESWORKTOTALTAXINCRF = reader.ReadInt64();
            //�����ƍ��v�i�Ŕ����j
            temp.SALESSLIPRF_SALESWORKTOTALTAXEXCRF = reader.ReadInt64();
            //���㏬�v�i�ō��݁j
            temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF = reader.ReadInt64();
            //���㏬�v�i�Ŕ����j
            temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = reader.ReadInt64();
            //���㕔�i���v�i�ō��݁j
            temp.SALESSLIPRF_SALESPRTSUBTTLINCRF = reader.ReadInt64();
            //���㕔�i���v�i�Ŕ����j
            temp.SALESSLIPRF_SALESPRTSUBTTLEXCRF = reader.ReadInt64();
            //�����Ə��v�i�ō��݁j
            temp.SALESSLIPRF_SALESWORKSUBTTLINCRF = reader.ReadInt64();
            //�����Ə��v�i�Ŕ����j
            temp.SALESSLIPRF_SALESWORKSUBTTLEXCRF = reader.ReadInt64();
            //���㏬�v�i�Łj
            temp.SALESSLIPRF_SALESSUBTOTALTAXRF = reader.ReadInt64();
            //���i�l���Ώۊz���v�i�Ŕ����j
            temp.SALESSLIPRF_ITDEDPARTSDISOUTTAXRF = reader.ReadInt64();
            //���i�l���Ώۊz���v�i�ō��݁j
            temp.SALESSLIPRF_ITDEDPARTSDISINTAXRF = reader.ReadInt64();
            //��ƒl���Ώۊz���v�i�Ŕ����j
            temp.SALESSLIPRF_ITDEDWORKDISOUTTAXRF = reader.ReadInt64();
            //��ƒl���Ώۊz���v�i�ō��݁j
            temp.SALESSLIPRF_ITDEDWORKDISINTAXRF = reader.ReadInt64();
            //���i�l����
            temp.SALESSLIPRF_PARTSDISCOUNTRATERF = reader.ReadDouble();
            //�H���l����
            temp.SALESSLIPRF_RAVORDISCOUNTRATERF = reader.ReadDouble();
            //�������z�v
            temp.SALESSLIPRF_TOTALCOSTRF = reader.ReadInt64();
            //����Őŗ�
            temp.SALESSLIPRF_CONSTAXRATERF = reader.ReadDouble();
            //���������敪
            temp.SALESSLIPRF_AUTODEPOSITCDRF = reader.ReadInt32();
            //���������`�[�ԍ�
            temp.SALESSLIPRF_AUTODEPOSITSLIPNORF = reader.ReadInt32();
            //�����������v�z
            temp.SALESSLIPRF_DEPOSITALLOWANCETTLRF = reader.ReadInt64();
            //���������c��
            temp.SALESSLIPRF_DEPOSITALWCBLNCERF = reader.ReadInt64();
            //������R�[�h
            temp.SALESSLIPRF_CLAIMCODERF = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.SALESSLIPRF_CUSTOMERCODERF = reader.ReadInt32();
            //���Ӑ於��
            temp.SALESSLIPRF_CUSTOMERNAMERF = reader.ReadString();
            //���Ӑ於��2
            temp.SALESSLIPRF_CUSTOMERNAME2RF = reader.ReadString();
            //���Ӑ旪��
            temp.SALESSLIPRF_CUSTOMERSNMRF = reader.ReadString();
            //�h��
            temp.SALESSLIPRF_HONORIFICTITLERF = reader.ReadString();
            //�[�i��R�[�h
            temp.SALESSLIPRF_ADDRESSEECODERF = reader.ReadInt32();
            //�[�i�於��
            temp.SALESSLIPRF_ADDRESSEENAMERF = reader.ReadString();
            //�[�i�於��2
            temp.SALESSLIPRF_ADDRESSEENAME2RF = reader.ReadString();
            //�����`�[�ԍ�
            temp.SALESSLIPRF_PARTYSALESLIPNUMRF = reader.ReadString();
            //�`�[���l
            temp.SALESSLIPRF_SLIPNOTERF = reader.ReadString();
            //�`�[���l�Q
            temp.SALESSLIPRF_SLIPNOTE2RF = reader.ReadString();
            //�`�[���l�R
            temp.SALESSLIPRF_SLIPNOTE3RF = reader.ReadString();
            //�ԕi���R�R�[�h
            temp.SALESSLIPRF_RETGOODSREASONDIVRF = reader.ReadInt32();
            //�ԕi���R
            temp.SALESSLIPRF_RETGOODSREASONRF = reader.ReadString();
            //���׍s��
            temp.SALESSLIPRF_DETAILROWCOUNTRF = reader.ReadInt32();
            //�t�n�d���}�[�N�P
            temp.SALESSLIPRF_UOEREMARK1RF = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.SALESSLIPRF_UOEREMARK2RF = reader.ReadString();
            //�[�i�敪
            temp.SALESSLIPRF_DELIVEREDGOODSDIVRF = reader.ReadInt32();
            //�[�i�敪����
            temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = reader.ReadString();
            //�݌ɏ��i���v���z�i�Ŕ��j
            temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = reader.ReadInt64();
            //�������i���v���z�i�Ŕ��j
            temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = reader.ReadInt64();
            //�r���P
            temp.SALESSLIPRF_FOOTNOTES1RF = reader.ReadString();
            //�r���Q
            temp.SALESSLIPRF_FOOTNOTES2RF = reader.ReadString();
            //���_�K�C�h����
            temp.SECDTL_SECTIONGUIDENMRF = reader.ReadString();
            //���_�K�C�h����
            temp.SECDTL_SECTIONGUIDESNMRF = reader.ReadString();
            //���Ж��̃R�[�h1
            temp.SECDTL_COMPANYNAMECD1RF = reader.ReadInt32();
            //���㕔�喼��
            temp.SUBSAL_SUBSECTIONNAMERF = reader.ReadString();
            //�󒍔ԍ�
            temp.SALESDETAILRF_ACCEPTANORDERNORF = reader.ReadInt32();
            //����s�ԍ�
            temp.SALESDETAILRF_SALESROWNORF = reader.ReadInt32();
            //�[�i�����\���
            temp.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = reader.ReadInt32();
            //���i����
            temp.SALESDETAILRF_GOODSKINDCODERF = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.SALESDETAILRF_GOODSMAKERCDRF = reader.ReadInt32();
            //���[�J�[����
            temp.SALESDETAILRF_MAKERNAMERF = reader.ReadString();
            //���i�ԍ�
            temp.SALESDETAILRF_GOODSNORF = reader.ReadString();
            //���i����
            temp.SALESDETAILRF_GOODSNAMERF = reader.ReadString();
            //���i������
            temp.SALESDETAILRF_GOODSSHORTNAMERF = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.SALESDETAILRF_GOODSLGROUPRF = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.SALESDETAILRF_GOODSLGROUPNAMERF = reader.ReadString();
            //���i�����ރR�[�h
            temp.SALESDETAILRF_GOODSMGROUPRF = reader.ReadInt32();
            //���i�����ޖ���
            temp.SALESDETAILRF_GOODSMGROUPNAMERF = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.SALESDETAILRF_BLGROUPCODERF = reader.ReadInt32();
            //BL�O���[�v�R�[�h����
            temp.SALESDETAILRF_BLGROUPNAMERF = reader.ReadString();
            //BL���i�R�[�h
            temp.SALESDETAILRF_BLGOODSCODERF = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.SALESDETAILRF_BLGOODSFULLNAMERF = reader.ReadString();
            //���Е��ރR�[�h
            temp.SALESDETAILRF_ENTERPRISEGANRECODERF = reader.ReadInt32();
            //���Е��ޖ���
            temp.SALESDETAILRF_ENTERPRISEGANRENAMERF = reader.ReadString();
            //�q�ɃR�[�h
            temp.SALESDETAILRF_WAREHOUSECODERF = reader.ReadString();
            //�q�ɖ���
            temp.SALESDETAILRF_WAREHOUSENAMERF = reader.ReadString();
            //�q�ɒI��
            temp.SALESDETAILRF_WAREHOUSESHELFNORF = reader.ReadString();
            //����݌Ɏ�񂹋敪
            temp.SALESDETAILRF_SALESORDERDIVCDRF = reader.ReadInt32();
            //�I�[�v�����i�敪
            temp.SALESDETAILRF_OPENPRICEDIVRF = reader.ReadInt32();
            //���i�|�������N
            temp.SALESDETAILRF_GOODSRATERANKRF = reader.ReadString();
            //�艿��
            temp.SALESDETAILRF_LISTPRICERATERF = reader.ReadDouble();
            //�艿�i�ō��C�����j
            temp.SALESDETAILRF_LISTPRICETAXINCFLRF = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.SALESDETAILRF_LISTPRICETAXEXCFLRF = reader.ReadDouble();
            //������
            temp.SALESDETAILRF_SALESRATERF = reader.ReadDouble();
            //����P���i�ō��C�����j
            temp.SALESDETAILRF_SALESUNPRCTAXINCFLRF = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = reader.ReadDouble();
            //������
            temp.SALESDETAILRF_COSTRATERF = reader.ReadDouble();
            //�����P��
            temp.SALESDETAILRF_SALESUNITCOSTRF = reader.ReadDouble();
            //BL���i�R�[�h�i����j
            temp.SALESDETAILRF_PRTBLGOODSCODERF = reader.ReadInt32();
            //BL���i�R�[�h���́i����j
            temp.SALESDETAILRF_PRTBLGOODSNAMERF = reader.ReadString();
            //��ƍH��
            temp.SALESDETAILRF_WORKMANHOURRF = reader.ReadDouble();
            //�o�א�
            temp.SALESDETAILRF_SHIPMENTCNTRF = reader.ReadDouble();
            //������z�i�ō��݁j
            temp.SALESDETAILRF_SALESMONEYTAXINCRF = reader.ReadInt64();
            //������z�i�Ŕ����j
            temp.SALESDETAILRF_SALESMONEYTAXEXCRF = reader.ReadInt64();
            //����
            temp.SALESDETAILRF_COSTRF = reader.ReadInt64();
            //�ېŋ敪
            temp.SALESDETAILRF_TAXATIONDIVCDRF = reader.ReadInt32();
            //�����`�[�ԍ��i���ׁj
            temp.SALESDETAILRF_PARTYSLIPNUMDTLRF = reader.ReadString();
            //���ה��l
            temp.SALESDETAILRF_DTLNOTERF = reader.ReadString();
            //�d����R�[�h
            temp.SALESDETAILRF_SUPPLIERCDRF = reader.ReadInt32();
            //�d���旪��
            temp.SALESDETAILRF_SUPPLIERSNMRF = reader.ReadString();
            //�`�[�����P
            temp.SALESDETAILRF_SLIPMEMO1RF = reader.ReadString();
            //�`�[�����Q
            temp.SALESDETAILRF_SLIPMEMO2RF = reader.ReadString();
            //�`�[�����R
            temp.SALESDETAILRF_SLIPMEMO3RF = reader.ReadString();
            //�Г������P
            temp.SALESDETAILRF_INSIDEMEMO1RF = reader.ReadString();
            //�Г������Q
            temp.SALESDETAILRF_INSIDEMEMO2RF = reader.ReadString();
            //�Г������R
            temp.SALESDETAILRF_INSIDEMEMO3RF = reader.ReadString();
            //�ύX�O�艿
            temp.SALESDETAILRF_BFLISTPRICERF = reader.ReadDouble();
            //�ύX�O����
            temp.SALESDETAILRF_BFSALESUNITPRICERF = reader.ReadDouble();
            //�ύX�O����
            temp.SALESDETAILRF_BFUNITCOSTRF = reader.ReadDouble();
            //�ꎮ���הԍ�
            temp.SALESDETAILRF_CMPLTSALESROWNORF = reader.ReadInt32();
            //���[�J�[�R�[�h�i�ꎮ�j
            temp.SALESDETAILRF_CMPLTGOODSMAKERCDRF = reader.ReadInt32();
            //���[�J�[���́i�ꎮ�j
            temp.SALESDETAILRF_CMPLTMAKERNAMERF = reader.ReadString();
            //���i���́i�ꎮ�j
            temp.SALESDETAILRF_CMPLTGOODSNAMERF = reader.ReadString();
            //���ʁi�ꎮ�j
            temp.SALESDETAILRF_CMPLTSHIPMENTCNTRF = reader.ReadDouble();
            //����P���i�ꎮ�j
            temp.SALESDETAILRF_CMPLTSALESUNPRCFLRF = reader.ReadDouble();
            //������z�i�ꎮ�j
            temp.SALESDETAILRF_CMPLTSALESMONEYRF = reader.ReadInt64();
            //�����P���i�ꎮ�j
            temp.SALESDETAILRF_CMPLTSALESUNITCOSTRF = reader.ReadDouble();
            //�������z�i�ꎮ�j
            temp.SALESDETAILRF_CMPLTCOSTRF = reader.ReadInt64();
            //�����`�[�ԍ��i�ꎮ�j
            temp.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = reader.ReadString();
            //�ꎮ���l
            temp.SALESDETAILRF_CMPLTNOTERF = reader.ReadString();
            //�ԗ��Ǘ��ԍ�
            temp.ACCEPTODRCARRF_CARMNGNORF = reader.ReadInt32();
            //���q�Ǘ��R�[�h
            temp.ACCEPTODRCARRF_CARMNGCODERF = reader.ReadString();
            //���^�������ԍ�
            temp.ACCEPTODRCARRF_NUMBERPLATE1CODERF = reader.ReadInt32();
            //���^�����ǖ���
            temp.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = reader.ReadString();
            //�ԗ��o�^�ԍ��i��ʁj
            temp.ACCEPTODRCARRF_NUMBERPLATE2RF = reader.ReadString();
            //�ԗ��o�^�ԍ��i�J�i�j
            temp.ACCEPTODRCARRF_NUMBERPLATE3RF = reader.ReadString();
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            temp.ACCEPTODRCARRF_NUMBERPLATE4RF = reader.ReadInt32();
            //���N�x
            temp.ACCEPTODRCARRF_FIRSTENTRYDATERF = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.ACCEPTODRCARRF_MAKERCODERF = reader.ReadInt32();
            //���[�J�[�S�p����
            temp.ACCEPTODRCARRF_MAKERFULLNAMERF = reader.ReadString();
            //�Ԏ�R�[�h
            temp.ACCEPTODRCARRF_MODELCODERF = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ACCEPTODRCARRF_MODELSUBCODERF = reader.ReadInt32();
            //�Ԏ�S�p����
            temp.ACCEPTODRCARRF_MODELFULLNAMERF = reader.ReadString();
            //�r�K�X�L��
            temp.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = reader.ReadString();
            //�V���[�Y�^��
            temp.ACCEPTODRCARRF_SERIESMODELRF = reader.ReadString();
            //�^���i�ޕʋL���j
            temp.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = reader.ReadString();
            //�^���i�t���^�j
            temp.ACCEPTODRCARRF_FULLMODELRF = reader.ReadString();
            //�^���w��ԍ�
            temp.ACCEPTODRCARRF_MODELDESIGNATIONNORF = reader.ReadInt32();
            //�ޕʔԍ�
            temp.ACCEPTODRCARRF_CATEGORYNORF = reader.ReadInt32();
            //�ԑ�^��
            temp.ACCEPTODRCARRF_FRAMEMODELRF = reader.ReadString();
            //�ԑ�ԍ�
            temp.ACCEPTODRCARRF_FRAMENORF = reader.ReadString();
            //�ԑ�ԍ��i�����p�j
            temp.ACCEPTODRCARRF_SEARCHFRAMENORF = reader.ReadInt32();
            //�G���W���^������
            temp.ACCEPTODRCARRF_ENGINEMODELNMRF = reader.ReadString();
            //�֘A�^��
            temp.ACCEPTODRCARRF_RELEVANCEMODELRF = reader.ReadString();
            //�T�u�Ԗ��R�[�h
            temp.ACCEPTODRCARRF_SUBCARNMCDRF = reader.ReadInt32();
            //�^���O���[�h����
            temp.ACCEPTODRCARRF_MODELGRADESNAMERF = reader.ReadString();
            //�J���[�R�[�h
            temp.ACCEPTODRCARRF_COLORCODERF = reader.ReadString();
            //�J���[����1
            temp.ACCEPTODRCARRF_COLORNAME1RF = reader.ReadString();
            //�g�����R�[�h
            temp.ACCEPTODRCARRF_TRIMCODERF = reader.ReadString();
            //�g��������
            temp.ACCEPTODRCARRF_TRIMNAMERF = reader.ReadString();
            //�ԗ����s����
            temp.ACCEPTODRCARRF_MILEAGERF = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.DEPSITMAINRF_ACPTANODRSTATUSRF = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.DEPSITMAINRF_DEPOSITSLIPNORF = reader.ReadInt32();
            //����`�[�ԍ�
            temp.DEPSITMAINRF_SALESSLIPNUMRF = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.DEPSITMAINRF_ADDUPSECCODERF = reader.ReadString();
            //����R�[�h
            temp.DEPSITMAINRF_SUBSECTIONCODERF = reader.ReadInt32();
            //�������t
            temp.DEPSITMAINRF_DEPOSITDATERF = reader.ReadInt32();
            //�v����t
            temp.DEPSITMAINRF_ADDUPADATERF = reader.ReadInt32();
            //�������z
            temp.DEPSITMAINRF_DEPOSITRF = reader.ReadInt64();
            //�萔�������z
            temp.DEPSITMAINRF_FEEDEPOSITRF = reader.ReadInt64();
            //�l�������z
            temp.DEPSITMAINRF_DISCOUNTDEPOSITRF = reader.ReadInt64();
            //���������敪
            temp.DEPSITMAINRF_AUTODEPOSITCDRF = reader.ReadInt32();
            //�a����敪
            temp.DEPSITMAINRF_DEPOSITCDRF = reader.ReadInt32();
            //��`�U�o��
            temp.DEPSITMAINRF_DRAFTDRAWINGDATERF = reader.ReadInt32();
            //��`���
            temp.DEPSITMAINRF_DRAFTKINDRF = reader.ReadInt32();
            //��`��ޖ���
            temp.DEPSITMAINRF_DRAFTKINDNAMERF = reader.ReadString();
            //��`�敪����
            temp.DEPSITMAINRF_DRAFTDIVIDENAMERF = reader.ReadString();
            //��`�ԍ�
            temp.DEPSITMAINRF_DRAFTNORF = reader.ReadString();
            //���Ӑ�R�[�h
            temp.DEPSITMAINRF_CUSTOMERCODERF = reader.ReadInt32();
            //������R�[�h
            temp.DEPSITMAINRF_CLAIMCODERF = reader.ReadInt32();
            //�`�[�E�v
            temp.DEPSITMAINRF_OUTLINERF = reader.ReadString();
            //�����������喼��
            temp.SUBDEP_SUBSECTIONNAMERF = reader.ReadString();
            //�����`�[�ԍ�
            temp.DEPSITDTLRF_DEPOSITSLIPNORF = reader.ReadInt32();
            //�����s�ԍ�
            temp.DEPSITDTLRF_DEPOSITROWNORF = reader.ReadInt32();
            //����R�[�h
            temp.DEPSITDTLRF_MONEYKINDCODERF = reader.ReadInt32();
            //���햼��
            temp.DEPSITDTLRF_MONEYKINDNAMERF = reader.ReadString();
            //����敪
            temp.DEPSITDTLRF_MONEYKINDDIVRF = reader.ReadInt32();
            //�������z
            temp.DEPSITDTLRF_DEPOSITRF = reader.ReadInt64();
            //�L������
            temp.DEPSITDTLRF_VALIDITYTERMRF = reader.ReadInt32();
            //�󒍃X�e�[�^�X����
            temp.DADD_ACPTANODRSTATUSRF = reader.ReadInt32();
            //�ԓ`�敪����
            temp.DADD_DEBITNOTEDIVRF = reader.ReadInt32();
            //����`�[�敪����
            temp.DADD_SALESSLIPCDRF = reader.ReadInt32();
            //������t
            temp.DADD_SALESDATERF = reader.ReadInt32();
            //������t����N
            temp.DADD_SALESDATEFYRF = reader.ReadInt32();
            //������t����N��
            temp.DADD_SALESDATEFSRF = reader.ReadInt32();
            //������t�a��N
            temp.DADD_SALESDATEFWRF = reader.ReadInt32();
            //������t��
            temp.DADD_SALESDATEFMRF = reader.ReadInt32();
            //������t��
            temp.DADD_SALESDATEFDRF = reader.ReadInt32();
            //������t����
            temp.DADD_SALESDATEFGRF = reader.ReadString();
            //������t����
            temp.DADD_SALESDATEFRRF = reader.ReadString();
            //������t���e����(/)
            temp.DADD_SALESDATEFLSRF = reader.ReadString();
            //������t���e����(.)
            temp.DADD_SALESDATEFLPRF = reader.ReadString();
            //������t���e����(�N)
            temp.DADD_SALESDATEFLYRF = reader.ReadString();
            //������t���e����(��)
            temp.DADD_SALESDATEFLMRF = reader.ReadString();
            //������t���e����(��)
            temp.DADD_SALESDATEFLDRF = reader.ReadString();
            //��񏤕i���v���z�i�Ŕ��j
            temp.DADD_STOCKGOODSTTLTAXEXCRF = reader.ReadInt64();
            //�D�Ǐ��i���v���z�i�Ŕ��j
            temp.DADD_PUREGOODSTTLTAXEXCRF = reader.ReadInt64();
            //���i��������
            temp.DADD_GOODSKINDCODERF = reader.ReadInt32();
            //����݌Ɏ�񂹋敪����
            temp.DADD_SALESORDERDIVCDRF = reader.ReadInt32();
            //�I�[�v�����i�敪����
            temp.DADD_OPENPRICEDIVRF = reader.ReadInt32();
            //�ېŋ敪����
            temp.DADD_TAXATIONDIVCDRF = reader.ReadInt32();
            //���N�x����N
            temp.DADD_FIRSTENTRYDATEFYRF = reader.ReadInt32();
            //���N�x����N��
            temp.DADD_FIRSTENTRYDATEFSRF = reader.ReadInt32();
            //���N�x�a��N
            temp.DADD_FIRSTENTRYDATEFWRF = reader.ReadInt32();
            //���N�x��
            temp.DADD_FIRSTENTRYDATEFMRF = reader.ReadInt32();
            //���N�x����
            temp.DADD_FIRSTENTRYDATEFGRF = reader.ReadString();
            //���N�x����
            temp.DADD_FIRSTENTRYDATEFRRF = reader.ReadString();
            //���N�x���e����(/)
            temp.DADD_FIRSTENTRYDATEFLSRF = reader.ReadString();
            //���N�x���e����(.)
            temp.DADD_FIRSTENTRYDATEFLPRF = reader.ReadString();
            //���N�x���e����(�N)
            temp.DADD_FIRSTENTRYDATEFLYRF = reader.ReadString();
            //���N�x���e����(��)
            temp.DADD_FIRSTENTRYDATEFLMRF = reader.ReadString();
            //�������t����N
            temp.DADD_DEPOSITDATEFYRF = reader.ReadInt32();
            //�������t����N��
            temp.DADD_DEPOSITDATEFSRF = reader.ReadInt32();
            //�������t�a��N
            temp.DADD_DEPOSITDATEFWRF = reader.ReadInt32();
            //�������t��
            temp.DADD_DEPOSITDATEFMRF = reader.ReadInt32();
            //�������t��
            temp.DADD_DEPOSITDATEFDRF = reader.ReadInt32();
            //�������t����
            temp.DADD_DEPOSITDATEFGRF = reader.ReadString();
            //�������t����
            temp.DADD_DEPOSITDATEFRRF = reader.ReadString();
            //�������t���e����(/)
            temp.DADD_DEPOSITDATEFLSRF = reader.ReadString();
            //�������t���e����(.)
            temp.DADD_DEPOSITDATEFLPRF = reader.ReadString();
            //�������t���e����(�N)
            temp.DADD_DEPOSITDATEFLYRF = reader.ReadString();
            //�������t���e����(��)
            temp.DADD_DEPOSITDATEFLMRF = reader.ReadString();
            //�������t���e����(��)
            temp.DADD_DEPOSITDATEFLDRF = reader.ReadString();
            //���������敪����
            temp.DADD_AUTODEPOSITCDRF = reader.ReadInt32();
            //�a����敪����
            temp.DADD_DEPOSITCDRF = reader.ReadInt32();
            //��`�U�o������N
            temp.DADD_DRAFTDRAWINGDATEFYRF = reader.ReadInt32();
            //��`�U�o������N��
            temp.DADD_DRAFTDRAWINGDATEFSRF = reader.ReadInt32();
            //��`�U�o���a��N
            temp.DADD_DRAFTDRAWINGDATEFWRF = reader.ReadInt32();
            //��`�U�o����
            temp.DADD_DRAFTDRAWINGDATEFMRF = reader.ReadInt32();
            //��`�U�o����
            temp.DADD_DRAFTDRAWINGDATEFDRF = reader.ReadInt32();
            //��`�U�o������
            temp.DADD_DRAFTDRAWINGDATEFGRF = reader.ReadString();
            //��`�U�o������
            temp.DADD_DRAFTDRAWINGDATEFRRF = reader.ReadString();
            //��`�U�o�����e����(/)
            temp.DADD_DRAFTDRAWINGDATEFLSRF = reader.ReadString();
            //��`�U�o�����e����(.)
            temp.DADD_DRAFTDRAWINGDATEFLPRF = reader.ReadString();
            //��`�U�o�����e����(�N)
            temp.DADD_DRAFTDRAWINGDATEFLYRF = reader.ReadString();
            //��`�U�o�����e����(��)
            temp.DADD_DRAFTDRAWINGDATEFLMRF = reader.ReadString();
            //��`�U�o�����e����(��)
            temp.DADD_DRAFTDRAWINGDATEFLDRF = reader.ReadString();
            //��`�x����������N
            temp.DADD_DRAFTPAYTIMELIMITFYRF = reader.ReadInt32();
            //��`�x����������N��
            temp.DADD_DRAFTPAYTIMELIMITFSRF = reader.ReadInt32();
            //��`�x�������a��N
            temp.DADD_DRAFTPAYTIMELIMITFWRF = reader.ReadInt32();
            //��`�x��������
            temp.DADD_DRAFTPAYTIMELIMITFMRF = reader.ReadInt32();
            //��`�x��������
            temp.DADD_DRAFTPAYTIMELIMITFDRF = reader.ReadInt32();
            //��`�x����������
            temp.DADD_DRAFTPAYTIMELIMITFGRF = reader.ReadString();
            //��`�x����������
            temp.DADD_DRAFTPAYTIMELIMITFRRF = reader.ReadString();
            //��`�x���������e����(/)
            temp.DADD_DRAFTPAYTIMELIMITFLSRF = reader.ReadString();
            //��`�x���������e����(.)
            temp.DADD_DRAFTPAYTIMELIMITFLPRF = reader.ReadString();
            //��`�x���������e����(�N)
            temp.DADD_DRAFTPAYTIMELIMITFLYRF = reader.ReadString();
            //��`�x���������e����(��)
            temp.DADD_DRAFTPAYTIMELIMITFLMRF = reader.ReadString();
            //��`�x���������e����(��)
            temp.DADD_DRAFTPAYTIMELIMITFLDRF = reader.ReadString();
            //�L����������N
            temp.DADD_VALIDITYTERMFYRF = reader.ReadInt32();
            //�L����������N��
            temp.DADD_VALIDITYTERMFSRF = reader.ReadInt32();
            //�L�������a��N
            temp.DADD_VALIDITYTERMFWRF = reader.ReadInt32();
            //�L��������
            temp.DADD_VALIDITYTERMFMRF = reader.ReadInt32();
            //�L��������
            temp.DADD_VALIDITYTERMFDRF = reader.ReadInt32();
            //�L����������
            temp.DADD_VALIDITYTERMFGRF = reader.ReadString();
            //�L����������
            temp.DADD_VALIDITYTERMFRRF = reader.ReadString();
            //�L���������e����(/)
            temp.DADD_VALIDITYTERMFLSRF = reader.ReadString();
            //�L���������e����(.)
            temp.DADD_VALIDITYTERMFLPRF = reader.ReadString();
            //�L���������e����(�N)
            temp.DADD_VALIDITYTERMFLYRF = reader.ReadString();
            //�L���������e����(��)
            temp.DADD_VALIDITYTERMFLMRF = reader.ReadString();
            //�L���������e����(��)
            temp.DADD_VALIDITYTERMFLDRF = reader.ReadString();
            //�������דE�v
            temp.DADD_DMDDTLOUTLINERF = reader.ReadString();
            //����`�[�v�^�C�g��
            temp.DADD_SALESFTTITLERF = reader.ReadString();
            //����`�[�v���z
            temp.DADD_SALESFTPRICERF = reader.ReadInt64();
            //����`�[�v���l�P
            temp.DADD_SALESFTNOTE1RF = reader.ReadString();
            //����`�[�v���l�Q
            temp.DADD_SALESFTNOTE2RF = reader.ReadString();
            //����`�[�v���l�R
            temp.DADD_SALESFTNOTE3RF = reader.ReadString();
            //���ד`�[�^�C�g��(����/�ԕi)
            temp.DSAL_DETAILTITLE = reader.ReadString();
            //����W�v�^�C�g��
            temp.DSAL_DETAILSUMTITLE = reader.ReadString();
            //����W�v���z
            temp.DSAL_DETAILSUMPRICE = reader.ReadInt64();
            //���ד`�[�^�C�g��(����)
            temp.DDEP_DETAILTITLE = reader.ReadString();
            //�����W�v�^�C�g��
            temp.DDEP_DETAILSUMTITLE = reader.ReadString();
            //�����W�v���z
            temp.DDEP_DETAILSUMPRICE = reader.ReadInt64();
            //����`�[�敪�i���ׁj
            temp.SALESDETAILRF_SALESSLIPCDDTLRF = reader.ReadInt32();
            //���ьv�㋒�_�R�[�h
            temp.SALESSLIPRF_RESULTSADDUPSECCDRF = reader.ReadString();
            //�������͋��_�R�[�h
            temp.DEPSITMAINRF_INPUTDEPOSITSECCDRF = reader.ReadString();
            //���i���̃J�i
            temp.SALESDETAILRF_GOODSNAMEKANARF = reader.ReadString();
            //���[�J�[�J�i����
            temp.SALESDETAILRF_MAKERKANANAMERF = reader.ReadString();
            //�Ԏ피�p����
            temp.ACCEPTODRCARRF_MODELHALFNAMERF = reader.ReadString();
            //����p�i��
            temp.SALESDETAILRF_PRTGOODSNORF = reader.ReadString();
            //����p���[�J�[�R�[�h
            temp.SALESDETAILRF_PRTMAKERCODERF = reader.ReadInt32();
            //����p���[�J�[����
            temp.SALESDETAILRF_PRTMAKERNAMERF = reader.ReadString();
            //�����`�[�ԍ��i�w�b�_�p�j
            temp.DADD_PARTYSALESLIPNUMRF = reader.ReadString();
            //����œ]�ŕ���
            temp.SALESSLIPRF_CONSTAXLAYMETHODRF = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>EBooksFrePBillDetailWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillDetailWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                EBooksFrePBillDetailWork temp = GetEBooksFrePBillDetailWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (EBooksFrePBillDetailWork[])lst.ToArray( typeof( EBooksFrePBillDetailWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
