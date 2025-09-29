using System;
using System.Collections;

//using Broadleaf.Library.Data; // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesDetailWork
    /// <summary>
    ///                      ���R���[���㖾�׃f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[���㖾�׃f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/01/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/19  douch</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �񓚋敪�ǉ�</br>
    /// <br>Update Note      :   2011/08/11 zhouzy</br>
    /// <br>                     �����[�g�`��</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePSalesDetailWork
    {
        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </remarks>
        private Int32 _sALESDETAILRF_ACPTANODRSTATUSRF;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _sALESDETAILRF_SALESSLIPNUMRF = "";

        /// <summary>�󒍔ԍ�</summary>
        private Int32 _sALESDETAILRF_ACCEPTANORDERNORF;

        /// <summary>����s�ԍ�</summary>
        private Int32 _sALESDETAILRF_SALESROWNORF;

        /// <summary>������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESDETAILRF_SALESDATERF;

        /// <summary>���ʒʔ�</summary>
        private Int64 _sALESDETAILRF_COMMONSEQNORF;

        /// <summary>���㖾�גʔ�</summary>
        private Int64 _sALESDETAILRF_SALESSLIPDTLNUMRF;

        /// <summary>�󒍃X�e�[�^�X�i���j</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _sALESDETAILRF_ACPTANODRSTATUSSRCRF;

        /// <summary>���㖾�גʔԁi���j</summary>
        /// <remarks>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</remarks>
        private Int64 _sALESDETAILRF_SALESSLIPDTLNUMSRCRF;

        /// <summary>�d���`���i�����j</summary>
        /// <remarks>0:�d��,1:����</remarks>
        private Int32 _sALESDETAILRF_SUPPLIERFORMALSYNCRF;

        /// <summary>�d�����גʔԁi�����j</summary>
        /// <remarks>�����v�㎞�̎d�����גʔԂ��Z�b�g</remarks>
        private Int64 _sALESDETAILRF_STOCKSLIPDTLNUMSYNCRF;

        /// <summary>����`�[�敪�i���ׁj</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v</remarks>
        private Int32 _sALESDETAILRF_SALESSLIPCDDTLRF;

        /// <summary>�݌ɊǗ��L���敪</summary>
        /// <remarks>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</remarks>
        private Int32 _sALESDETAILRF_STOCKMNGEXISTCDRF;

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

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _sALESDETAILRF_CUSTRATEGRPCODERF;

        /// <summary>�艿��</summary>
        private Double _sALESDETAILRF_LISTPRICERATERF;

        /// <summary>�艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXINCFLRF;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXEXCFLRF;

        /// <summary>�艿�ύX�敪</summary>
        /// <remarks>0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j</remarks>
        private Int32 _sALESDETAILRF_LISTPRICECHNGCDRF;

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

        /// <summary>�o�א�</summary>
        private Double _sALESDETAILRF_SHIPMENTCNTRF;

        /// <summary>�󒍐���</summary>
        /// <remarks>��,�o�ׂŎg�p</remarks>
        private Double _sALESDETAILRF_ACCEPTANORDERCNTRF;

        /// <summary>�󒍒�����</summary>
        /// <remarks>���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o</remarks>
        private Double _sALESDETAILRF_ACPTANODRADJUSTCNTRF;

        /// <summary>�󒍎c��</summary>
        /// <remarks>�󒍐��ʁ{�󒍒������|�o�א�</remarks>
        private Double _sALESDETAILRF_ACPTANODRREMAINCNTRF;

        /// <summary>�c���X�V��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESDETAILRF_REMAINCNTUPDDATERF;

        /// <summary>������z�i�ō��݁j</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXINCRF;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXEXCRF;

        /// <summary>����</summary>
        private Int64 _sALESDETAILRF_COSTRF;

        /// <summary>�e���`�F�b�N�敪</summary>
        /// <remarks>0:����,1:��������,2:���v�̏グ�߂�</remarks>
        private Int32 _sALESDETAILRF_GRSPROFITCHKDIVRF;

        /// <summary>���㏤�i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</remarks>
        private Int32 _sALESDETAILRF_SALESGOODSCDRF;

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

        /// <summary>�����ԍ�</summary>
        private string _sALESDETAILRF_ORDERNUMBERRF = "";

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

        /// <summary>���i���[�J�[����</summary>
        private string _mAKGDS_MAKERSHORTNAMERF = "";

        /// <summary>���i���[�J�[�J�i����</summary>
        private string _mAKGDS_MAKERKANANAMERF = "";

        /// <summary>���[�U�[�������i���[�J�[�R�[�h</summary>
        /// <remarks>�i���[�U�[�f�[�^�ɊY�����L�鎖���`�F�b�N����ׂ̍��ځj</remarks>
        private Int32 _mAKGDS_GOODSMAKERCDRF;

        /// <summary>�ꎮ���[�J�[����</summary>
        private string _mAKCMP_MAKERSHORTNAMERF = "";

        /// <summary>�ꎮ���[�J�[�J�i����</summary>
        private string _mAKCMP_MAKERKANANAMERF = "";

        /// <summary>���[�U�[�����ꎮ���[�J�[�R�[�h</summary>
        /// <remarks>�i���[�U�[�f�[�^�ɊY�����L�鎖���`�F�b�N����ׂ̍��ځj</remarks>
        private Int32 _mAKCMP_GOODSMAKERCDRF;

        /// <summary>���i���̃J�i</summary>
        private string _gOODSURF_GOODSNAMEKANARF = "";

        /// <summary>JAN�R�[�h</summary>
        private string _gOODSURF_JANRF = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _gOODSURF_GOODSRATERANKRF = "";

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _gOODSURF_GOODSNONONEHYPHENRF = "";

        /// <summary>���i���l�P</summary>
        private string _gOODSURF_GOODSNOTE1RF = "";

        /// <summary>���i���l�Q</summary>
        private string _gOODSURF_GOODSNOTE2RF = "";

        /// <summary>���i�K�i�E���L����</summary>
        private string _gOODSURF_GOODSSPECIALNOTERF = "";

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</remarks>
        private Double _sTOCKRF_SHIPMENTPOSCNTRF;

        /// <summary>�d���I�ԂP</summary>
        private string _sTOCKRF_DUPLICATIONSHELFNO1RF = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _sTOCKRF_DUPLICATIONSHELFNO2RF = "";

        /// <summary>���i�Ǘ��敪�P</summary>
        private string _sTOCKRF_PARTSMANAGEMENTDIVIDE1RF = "";

        /// <summary>���i�Ǘ��敪�Q</summary>
        private string _sTOCKRF_PARTSMANAGEMENTDIVIDE2RF = "";

        /// <summary>�݌ɔ��l�P</summary>
        private string _sTOCKRF_STOCKNOTE1RF = "";

        /// <summary>�݌ɔ��l�Q</summary>
        private string _sTOCKRF_STOCKNOTE2RF = "";

        /// <summary>�q�ɔ��l1</summary>
        private string _wAREHOUSERF_WAREHOUSENOTE1RF = "";

        /// <summary>���Ӑ�|���f�q����</summary>
        private string _uSRCSG_GUIDENAMERF = "";

        /// <summary>���[�U�[�����d����R�[�h</summary>
        /// <remarks>�i���[�U�[�c�a�ɊY�������邩�`�F�b�N����ׂ̍��ځj</remarks>
        private Int32 _sUPPLIERRF_SUPPLIERCDRF;

        /// <summary>�d���於1</summary>
        private string _sUPPLIERRF_SUPPLIERNM1RF = "";

        /// <summary>�d���於2</summary>
        private string _sUPPLIERRF_SUPPLIERNM2RF = "";

        /// <summary>�d����h��</summary>
        private string _sUPPLIERRF_SUPPHONORIFICTITLERF = "";

        /// <summary>�d����J�i</summary>
        private string _sUPPLIERRF_SUPPLIERKANARF = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private Int32 _sUPPLIERRF_PURECODERF;

        /// <summary>�d������l1</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE1RF = "";

        /// <summary>�d������l2</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE2RF = "";

        /// <summary>�d������l3</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE3RF = "";

        /// <summary>�d������l4</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE4RF = "";

        /// <summary>���[�U�[����BL���i�R�[�h</summary>
        /// <remarks>�i���[�U�[�c�a�ɊY�����L�邩�`�F�b�N����ׂ̍��ځj</remarks>
        private Int32 _bLGOODSCDURF_BLGOODSCODERF;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGOODSCDURF_BLGOODSHALFNAMERF = "";

        /// <summary>�݌ɊǗ��L���敪����</summary>
        /// <remarks>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</remarks>
        private string _dADD_STOCKMNGEXISTNMRF = "";

        /// <summary>���i��������</summary>
        /// <remarks>0:���� 1:�D��</remarks>
        private string _dADD_GOODSKINDNAMERF = "";

        /// <summary>����݌Ɏ�񂹋敪����</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private string _dADD_SALESORDERDIVNMRF = "";

        /// <summary>�I�[�v�����i�敪����</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private string _dADD_OPENPRICEDIVNMRF = "";

        /// <summary>�e���`�F�b�N�敪����</summary>
        /// <remarks>0:����,1:��������,2:���v�̏グ�߂�</remarks>
        private string _dADD_GRSPROFITCHKDIVNMRF = "";

        /// <summary>���㏤�i�敪����</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</remarks>
        private string _dADD_SALESGOODSNMRF = "";

        /// <summary>�ېŋ敪����</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private string _dADD_TAXATIONDIVNMRF = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private string _dADD_PURECODENMRF = "";

        /// <summary>�[�i�����\�������N</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFYRF;

        /// <summary>�[�i�����\�������N��</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFSRF;

        /// <summary>�[�i�����\����a��N</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFWRF;

        /// <summary>�[�i�����\�����</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFMRF;

        /// <summary>�[�i�����\�����</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFDRF;

        /// <summary>�[�i�����\�������</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFGRF = "";

        /// <summary>�[�i�����\�������</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFRRF = "";

        /// <summary>�[�i�����\������e����(/)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLSRF = "";

        /// <summary>�[�i�����\������e����(.)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLPRF = "";

        /// <summary>�[�i�����\������e����(�N)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLYRF = "";

        /// <summary>�[�i�����\������e����(��)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLMRF = "";

        /// <summary>�[�i�����\������e����(��)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLDRF = "";

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

        /// <summary>�݌Ɏ��敪�}�[�N</summary>
        /// <remarks>*:���C��:�݌�</remarks>
        private string _dADD_SALESORDERDIVMARKRF = "";

        /// <summary>���[�J�[���p����</summary>
        private string _aCCEPTODRCARRF_MAKERHALFNAMERF = "";

        /// <summary>�Ԏ피�p����</summary>
        private string _aCCEPTODRCARRF_MODELHALFNAMERF = "";

        /// <summary>BL���i�R�[�h�i����j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h�i���i�������ʁj</remarks>
        private Int32 _sALESDETAILRF_PRTBLGOODSCODERF;

        /// <summary>BL���i�R�[�h���́i����j</summary>
        /// <remarks>�|���Z�o���Ɏg�p����BL�R�[�h���́i���i�������ʁj</remarks>
        private string _sALESDETAILRF_PRTBLGOODSNAMERF = "";

        /// <summary>����p�i��</summary>
        private string _sALESDETAILRF_PRTGOODSNORF = "";

        /// <summary>����p���[�J�[�R�[�h</summary>
        private Int32 _sALESDETAILRF_PRTMAKERCODERF;

        /// <summary>����p���[�J�[����</summary>
        private string _sALESDETAILRF_PRTMAKERNAMERF = "";

        /// <summary>����p���[�J�[�J�i����</summary>
        private string _mAKPRT_MAKERKANANAMERF = "";

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

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _sALESDETAILRF_SALESCODERF;

        /// <summary>�̔��敪����</summary>
        private string _sALESDETAILRF_SALESCDNMRF = "";

        /// <summary>���i���̃J�i</summary>
        private string _sALESDETAILRF_GOODSNAMEKANARF = "";

        // --- ADD 2009.07.24 ���m ------ >>>>>>
        /// <summary>AB���i�R�[�h</summary>
        private string _sANDEGOODSCDCHGRF_ABGOODSCODE = "";
        // --- ADD 2009.07.24 ���m ------ <<<<<<

        // --- ADD 2011.07.19  ------ >>>>>>
        /// <summary>�����񓚋敪(SCM)</summary>
        /// <remarks>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</remarks>
        private Int32 _sALESDETAILRF_AUTOANSWERDIVSCMRF;
        // --- ADD 2011.07.19  ------ <<<<<<
	    // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// <summary>�󔭒����</summary>
        private Int16 _sALESDETAILRF_ACCEPTORORDERKINDRF;
        /// <summary>�⍇���ԍ�</summary>
        private Int64 _sALESDETAILRF_INQUIRYNUMBERRF;
        /// <summary>�⍇���s�ԍ�</summary>
        private Int32 _sALESDETAILRF_INQROWNUMBERRF;
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end


        /// public propaty name  :  SALESDETAILRF_ACPTANODRSTATUSRF
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��,70:�w����,80:�N���[��,99:�ꎞ�ۊ�  </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACPTANODRSTATUSRF
        {
            get { return _sALESDETAILRF_ACPTANODRSTATUSRF; }
            set { _sALESDETAILRF_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPNUMRF
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_SALESSLIPNUMRF
        {
            get { return _sALESDETAILRF_SALESSLIPNUMRF; }
            set { _sALESDETAILRF_SALESSLIPNUMRF = value; }
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

        /// public propaty name  :  SALESDETAILRF_SALESDATERF
        /// <summary>������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESDATERF
        {
            get { return _sALESDETAILRF_SALESDATERF; }
            set { _sALESDETAILRF_SALESDATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COMMONSEQNORF
        /// <summary>���ʒʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʒʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_COMMONSEQNORF
        {
            get { return _sALESDETAILRF_COMMONSEQNORF; }
            set { _sALESDETAILRF_COMMONSEQNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPDTLNUMRF
        /// <summary>���㖾�גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESSLIPDTLNUMRF
        {
            get { return _sALESDETAILRF_SALESSLIPDTLNUMRF; }
            set { _sALESDETAILRF_SALESSLIPDTLNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACPTANODRSTATUSSRCRF
        /// <summary>�󒍃X�e�[�^�X�i���j�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACPTANODRSTATUSSRCRF
        {
            get { return _sALESDETAILRF_ACPTANODRSTATUSSRCRF; }
            set { _sALESDETAILRF_ACPTANODRSTATUSSRCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPDTLNUMSRCRF
        /// <summary>���㖾�גʔԁi���j�v���p�e�B</summary>
        /// <value>�v�㎞�̌��f�[�^���גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԁi���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESSLIPDTLNUMSRCRF
        {
            get { return _sALESDETAILRF_SALESSLIPDTLNUMSRCRF; }
            set { _sALESDETAILRF_SALESSLIPDTLNUMSRCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERFORMALSYNCRF
        /// <summary>�d���`���i�����j�v���p�e�B</summary>
        /// <value>0:�d��,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SUPPLIERFORMALSYNCRF
        {
            get { return _sALESDETAILRF_SUPPLIERFORMALSYNCRF; }
            set { _sALESDETAILRF_SUPPLIERFORMALSYNCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF
        /// <summary>�d�����גʔԁi�����j�v���p�e�B</summary>
        /// <value>�����v�㎞�̎d�����גʔԂ��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԁi�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF
        {
            get { return _sALESDETAILRF_STOCKSLIPDTLNUMSYNCRF; }
            set { _sALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = value; }
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

        /// public propaty name  :  SALESDETAILRF_STOCKMNGEXISTCDRF
        /// <summary>�݌ɊǗ��L���敪�v���p�e�B</summary>
        /// <value>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɊǗ��L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_STOCKMNGEXISTCDRF
        {
            get { return _sALESDETAILRF_STOCKMNGEXISTCDRF; }
            set { _sALESDETAILRF_STOCKMNGEXISTCDRF = value; }
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

        /// public propaty name  :  SALESDETAILRF_CUSTRATEGRPCODERF
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CUSTRATEGRPCODERF
        {
            get { return _sALESDETAILRF_CUSTRATEGRPCODERF; }
            set { _sALESDETAILRF_CUSTRATEGRPCODERF = value; }
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

        /// public propaty name  :  SALESDETAILRF_LISTPRICECHNGCDRF
        /// <summary>�艿�ύX�敪�v���p�e�B</summary>
        /// <value>0:�ύX�Ȃ�,1:�ύX����@�i�艿����́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�ύX�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_LISTPRICECHNGCDRF
        {
            get { return _sALESDETAILRF_LISTPRICECHNGCDRF; }
            set { _sALESDETAILRF_LISTPRICECHNGCDRF = value; }
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

        /// public propaty name  :  SALESDETAILRF_ACCEPTANORDERCNTRF
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// <value>��,�o�ׂŎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_ACCEPTANORDERCNTRF
        {
            get { return _sALESDETAILRF_ACCEPTANORDERCNTRF; }
            set { _sALESDETAILRF_ACCEPTANORDERCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACPTANODRADJUSTCNTRF
        /// <summary>�󒍒������v���p�e�B</summary>
        /// <value>���݂̎󒍐��́u�󒍐��ʁ{�󒍒������v�ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍒������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_ACPTANODRADJUSTCNTRF
        {
            get { return _sALESDETAILRF_ACPTANODRADJUSTCNTRF; }
            set { _sALESDETAILRF_ACPTANODRADJUSTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACPTANODRREMAINCNTRF
        /// <summary>�󒍎c���v���p�e�B</summary>
        /// <value>�󒍐��ʁ{�󒍒������|�o�א�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SALESDETAILRF_ACPTANODRREMAINCNTRF
        {
            get { return _sALESDETAILRF_ACPTANODRREMAINCNTRF; }
            set { _sALESDETAILRF_ACPTANODRREMAINCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_REMAINCNTUPDDATERF
        /// <summary>�c���X�V���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���X�V���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_REMAINCNTUPDDATERF
        {
            get { return _sALESDETAILRF_REMAINCNTUPDDATERF; }
            set { _sALESDETAILRF_REMAINCNTUPDDATERF = value; }
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

        /// public propaty name  :  SALESDETAILRF_GRSPROFITCHKDIVRF
        /// <summary>�e���`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:����,1:��������,2:���v�̏グ�߂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GRSPROFITCHKDIVRF
        {
            get { return _sALESDETAILRF_GRSPROFITCHKDIVRF; }
            set { _sALESDETAILRF_GRSPROFITCHKDIVRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESGOODSCDRF
        /// <summary>���㏤�i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESGOODSCDRF
        {
            get { return _sALESDETAILRF_SALESGOODSCDRF; }
            set { _sALESDETAILRF_SALESGOODSCDRF = value; }
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

        /// public propaty name  :  SALESDETAILRF_ORDERNUMBERRF
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_ORDERNUMBERRF
        {
            get { return _sALESDETAILRF_ORDERNUMBERRF; }
            set { _sALESDETAILRF_ORDERNUMBERRF = value; }
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

        /// public propaty name  :  MAKGDS_MAKERSHORTNAMERF
        /// <summary>���i���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKGDS_MAKERSHORTNAMERF
        {
            get { return _mAKGDS_MAKERSHORTNAMERF; }
            set { _mAKGDS_MAKERSHORTNAMERF = value; }
        }

        /// public propaty name  :  MAKGDS_MAKERKANANAMERF
        /// <summary>���i���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKGDS_MAKERKANANAMERF
        {
            get { return _mAKGDS_MAKERKANANAMERF; }
            set { _mAKGDS_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  MAKGDS_GOODSMAKERCDRF
        /// <summary>���[�U�[�������i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�i���[�U�[�f�[�^�ɊY�����L�鎖���`�F�b�N����ׂ̍��ځj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�������i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MAKGDS_GOODSMAKERCDRF
        {
            get { return _mAKGDS_GOODSMAKERCDRF; }
            set { _mAKGDS_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  MAKCMP_MAKERSHORTNAMERF
        /// <summary>�ꎮ���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKCMP_MAKERSHORTNAMERF
        {
            get { return _mAKCMP_MAKERSHORTNAMERF; }
            set { _mAKCMP_MAKERSHORTNAMERF = value; }
        }

        /// public propaty name  :  MAKCMP_MAKERKANANAMERF
        /// <summary>�ꎮ���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKCMP_MAKERKANANAMERF
        {
            get { return _mAKCMP_MAKERKANANAMERF; }
            set { _mAKCMP_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  MAKCMP_GOODSMAKERCDRF
        /// <summary>���[�U�[�����ꎮ���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�i���[�U�[�f�[�^�ɊY�����L�鎖���`�F�b�N����ׂ̍��ځj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�����ꎮ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MAKCMP_GOODSMAKERCDRF
        {
            get { return _mAKCMP_GOODSMAKERCDRF; }
            set { _mAKCMP_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNAMEKANARF
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_GOODSNAMEKANARF
        {
            get { return _gOODSURF_GOODSNAMEKANARF; }
            set { _gOODSURF_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  GOODSURF_JANRF
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_JANRF
        {
            get { return _gOODSURF_JANRF; }
            set { _gOODSURF_JANRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSRATERANKRF
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_GOODSRATERANKRF
        {
            get { return _gOODSURF_GOODSRATERANKRF; }
            set { _gOODSURF_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNONONEHYPHENRF
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_GOODSNONONEHYPHENRF
        {
            get { return _gOODSURF_GOODSNONONEHYPHENRF; }
            set { _gOODSURF_GOODSNONONEHYPHENRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNOTE1RF
        /// <summary>���i���l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_GOODSNOTE1RF
        {
            get { return _gOODSURF_GOODSNOTE1RF; }
            set { _gOODSURF_GOODSNOTE1RF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNOTE2RF
        /// <summary>���i���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_GOODSNOTE2RF
        {
            get { return _gOODSURF_GOODSNOTE2RF; }
            set { _gOODSURF_GOODSNOTE2RF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSSPECIALNOTERF
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GOODSURF_GOODSSPECIALNOTERF
        {
            get { return _gOODSURF_GOODSSPECIALNOTERF; }
            set { _gOODSURF_GOODSSPECIALNOTERF = value; }
        }

        /// public propaty name  :  STOCKRF_SHIPMENTPOSCNTRF
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ��{����݌ɐ��|�i�d���݌ɕ��ϑ����{������ϑ����j�|�i�ړ����d���݌ɐ��{�ړ�������݌ɐ��j�|�󒍐�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double STOCKRF_SHIPMENTPOSCNTRF
        {
            get { return _sTOCKRF_SHIPMENTPOSCNTRF; }
            set { _sTOCKRF_SHIPMENTPOSCNTRF = value; }
        }

        /// public propaty name  :  STOCKRF_DUPLICATIONSHELFNO1RF
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STOCKRF_DUPLICATIONSHELFNO1RF
        {
            get { return _sTOCKRF_DUPLICATIONSHELFNO1RF; }
            set { _sTOCKRF_DUPLICATIONSHELFNO1RF = value; }
        }

        /// public propaty name  :  STOCKRF_DUPLICATIONSHELFNO2RF
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STOCKRF_DUPLICATIONSHELFNO2RF
        {
            get { return _sTOCKRF_DUPLICATIONSHELFNO2RF; }
            set { _sTOCKRF_DUPLICATIONSHELFNO2RF = value; }
        }

        /// public propaty name  :  STOCKRF_PARTSMANAGEMENTDIVIDE1RF
        /// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STOCKRF_PARTSMANAGEMENTDIVIDE1RF
        {
            get { return _sTOCKRF_PARTSMANAGEMENTDIVIDE1RF; }
            set { _sTOCKRF_PARTSMANAGEMENTDIVIDE1RF = value; }
        }

        /// public propaty name  :  STOCKRF_PARTSMANAGEMENTDIVIDE2RF
        /// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STOCKRF_PARTSMANAGEMENTDIVIDE2RF
        {
            get { return _sTOCKRF_PARTSMANAGEMENTDIVIDE2RF; }
            set { _sTOCKRF_PARTSMANAGEMENTDIVIDE2RF = value; }
        }

        /// public propaty name  :  STOCKRF_STOCKNOTE1RF
        /// <summary>�݌ɔ��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STOCKRF_STOCKNOTE1RF
        {
            get { return _sTOCKRF_STOCKNOTE1RF; }
            set { _sTOCKRF_STOCKNOTE1RF = value; }
        }

        /// public propaty name  :  STOCKRF_STOCKNOTE2RF
        /// <summary>�݌ɔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string STOCKRF_STOCKNOTE2RF
        {
            get { return _sTOCKRF_STOCKNOTE2RF; }
            set { _sTOCKRF_STOCKNOTE2RF = value; }
        }

        /// public propaty name  :  WAREHOUSERF_WAREHOUSENOTE1RF
        /// <summary>�q�ɔ��l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WAREHOUSERF_WAREHOUSENOTE1RF
        {
            get { return _wAREHOUSERF_WAREHOUSENOTE1RF; }
            set { _wAREHOUSERF_WAREHOUSENOTE1RF = value; }
        }

        /// public propaty name  :  USRCSG_GUIDENAMERF
        /// <summary>���Ӑ�|���f�q���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���f�q���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string USRCSG_GUIDENAMERF
        {
            get { return _uSRCSG_GUIDENAMERF; }
            set { _uSRCSG_GUIDENAMERF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERCDRF
        /// <summary>���[�U�[�����d����R�[�h�v���p�e�B</summary>
        /// <value>�i���[�U�[�c�a�ɊY�������邩�`�F�b�N����ׂ̍��ځj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�����d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SUPPLIERRF_SUPPLIERCDRF
        {
            get { return _sUPPLIERRF_SUPPLIERCDRF; }
            set { _sUPPLIERRF_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNM1RF
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNM1RF
        {
            get { return _sUPPLIERRF_SUPPLIERNM1RF; }
            set { _sUPPLIERRF_SUPPLIERNM1RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNM2RF
        /// <summary>�d���於2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNM2RF
        {
            get { return _sUPPLIERRF_SUPPLIERNM2RF; }
            set { _sUPPLIERRF_SUPPLIERNM2RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPHONORIFICTITLERF
        /// <summary>�d����h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPHONORIFICTITLERF
        {
            get { return _sUPPLIERRF_SUPPHONORIFICTITLERF; }
            set { _sUPPLIERRF_SUPPHONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERKANARF
        /// <summary>�d����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERKANARF
        {
            get { return _sUPPLIERRF_SUPPLIERKANARF; }
            set { _sUPPLIERRF_SUPPLIERKANARF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_PURECODERF
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SUPPLIERRF_PURECODERF
        {
            get { return _sUPPLIERRF_PURECODERF; }
            set { _sUPPLIERRF_PURECODERF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE1RF
        /// <summary>�d������l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE1RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE1RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE1RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE2RF
        /// <summary>�d������l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE2RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE2RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE2RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE3RF
        /// <summary>�d������l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE3RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE3RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE3RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE4RF
        /// <summary>�d������l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE4RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE4RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE4RF = value; }
        }

        /// public propaty name  :  BLGOODSCDURF_BLGOODSCODERF
        /// <summary>���[�U�[����BL���i�R�[�h�v���p�e�B</summary>
        /// <value>�i���[�U�[�c�a�ɊY�����L�邩�`�F�b�N����ׂ̍��ځj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[����BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGOODSCDURF_BLGOODSCODERF
        {
            get { return _bLGOODSCDURF_BLGOODSCODERF; }
            set { _bLGOODSCDURF_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  BLGOODSCDURF_BLGOODSHALFNAMERF
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGOODSCDURF_BLGOODSHALFNAMERF
        {
            get { return _bLGOODSCDURF_BLGOODSHALFNAMERF; }
            set { _bLGOODSCDURF_BLGOODSHALFNAMERF = value; }
        }

        /// public propaty name  :  DADD_STOCKMNGEXISTNMRF
        /// <summary>�݌ɊǗ��L���敪���̃v���p�e�B</summary>
        /// <value>0:�݌ɊǗ����Ȃ�,1:�݌ɊǗ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɊǗ��L���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_STOCKMNGEXISTNMRF
        {
            get { return _dADD_STOCKMNGEXISTNMRF; }
            set { _dADD_STOCKMNGEXISTNMRF = value; }
        }

        /// public propaty name  :  DADD_GOODSKINDNAMERF
        /// <summary>���i�������̃v���p�e�B</summary>
        /// <value>0:���� 1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_GOODSKINDNAMERF
        {
            get { return _dADD_GOODSKINDNAMERF; }
            set { _dADD_GOODSKINDNAMERF = value; }
        }

        /// public propaty name  :  DADD_SALESORDERDIVNMRF
        /// <summary>����݌Ɏ�񂹋敪���̃v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESORDERDIVNMRF
        {
            get { return _dADD_SALESORDERDIVNMRF; }
            set { _dADD_SALESORDERDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_OPENPRICEDIVNMRF
        /// <summary>�I�[�v�����i�敪���̃v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_OPENPRICEDIVNMRF
        {
            get { return _dADD_OPENPRICEDIVNMRF; }
            set { _dADD_OPENPRICEDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_GRSPROFITCHKDIVNMRF
        /// <summary>�e���`�F�b�N�敪���̃v���p�e�B</summary>
        /// <value>0:����,1:��������,2:���v�̏グ�߂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_GRSPROFITCHKDIVNMRF
        {
            get { return _dADD_GRSPROFITCHKDIVNMRF; }
            set { _dADD_GRSPROFITCHKDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_SALESGOODSNMRF
        /// <summary>���㏤�i�敪���̃v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����),11:���E,12:���E(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESGOODSNMRF
        {
            get { return _dADD_SALESGOODSNMRF; }
            set { _dADD_SALESGOODSNMRF = value; }
        }

        /// public propaty name  :  DADD_TAXATIONDIVNMRF
        /// <summary>�ېŋ敪���̃v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_TAXATIONDIVNMRF
        {
            get { return _dADD_TAXATIONDIVNMRF; }
            set { _dADD_TAXATIONDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_PURECODENMRF
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_PURECODENMRF
        {
            get { return _dADD_PURECODENMRF; }
            set { _dADD_PURECODENMRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFYRF
        /// <summary>�[�i�����\�������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFYRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFYRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFSRF
        /// <summary>�[�i�����\�������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\�������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFSRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFSRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFWRF
        /// <summary>�[�i�����\����a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFWRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFWRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFMRF
        /// <summary>�[�i�����\������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFMRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFMRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFDRF
        /// <summary>�[�i�����\������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFDRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFDRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFGRF
        /// <summary>�[�i�����\��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFGRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFGRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFRRF
        /// <summary>�[�i�����\��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFRRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFRRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLSRF
        /// <summary>�[�i�����\������e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLSRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLSRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLPRF
        /// <summary>�[�i�����\������e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLPRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLPRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLYRF
        /// <summary>�[�i�����\������e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLYRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLYRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLMRF
        /// <summary>�[�i�����\������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLMRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLMRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLDRF
        /// <summary>�[�i�����\������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLDRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLDRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLDRF = value; }
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

        /// public propaty name  :  DADD_SALESORDERDIVMARKRF
        /// <summary>�݌Ɏ��敪�}�[�N�v���p�e�B</summary>
        /// <value>*:���C��:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ��敪�}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SALESORDERDIVMARKRF
        {
            get { return _dADD_SALESORDERDIVMARKRF; }
            set { _dADD_SALESORDERDIVMARKRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERHALFNAMERF
        /// <summary>���[�J�[���p���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MAKERHALFNAMERF
        {
            get { return _aCCEPTODRCARRF_MAKERHALFNAMERF; }
            set { _aCCEPTODRCARRF_MAKERHALFNAMERF = value; }
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

        /// public propaty name  :  MAKPRT_MAKERKANANAMERF
        /// <summary>����p���[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MAKPRT_MAKERKANANAMERF
        {
            get { return _mAKPRT_MAKERKANANAMERF; }
            set { _mAKPRT_MAKERKANANAMERF = value; }
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

        /// public propaty name  :  SALESDETAILRF_SALESCODERF
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESCODERF
        {
            get { return _sALESDETAILRF_SALESCODERF; }
            set { _sALESDETAILRF_SALESCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESCDNMRF
        /// <summary>�̔��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESDETAILRF_SALESCDNMRF
        {
            get { return _sALESDETAILRF_SALESCDNMRF; }
            set { _sALESDETAILRF_SALESCDNMRF = value; }
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

        // --- ADD 2009.07.24 ���m ------ >>>>>>
        /// public propaty name  :  SAndEGoodsCdChgRF_ABGoodsCode
        /// <summary>AB���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDEGOODSCDCHGRF_ABGOODSCODE
        {
            get { return _sANDEGOODSCDCHGRF_ABGOODSCODE; }
            set { _sANDEGOODSCDCHGRF_ABGOODSCODE = value; }
        }
        // --- ADD 2009.07.24 ���m ------ <<<<<<

        // --- ADD 2011.07.19  ------ >>>>>>
        /// public propaty name  :  SALESDETAILRF_AUTOANSWERDIVSCMRF        
        /// <summary>�����񓚋敪(SCM)�v���p�e�B</summary>
        /// <value>0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪(SCM)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_AUTOANSWERDIVSCMRF
        {
            get { return _sALESDETAILRF_AUTOANSWERDIVSCMRF; }
            set { _sALESDETAILRF_AUTOANSWERDIVSCMRF = value; }
        }
        // --- ADD 2011.07.19  ------ <<<<<<
		// add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
        /// public propaty name  :  SALESDETAILRF_ACCEPTORORDERKINDRF
        /// <summary>�󔭒���ʃJ�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󔭒���ʃJ�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 SALESDETAILRF_ACCEPTORORDERKINDRF
        {
            get { return _sALESDETAILRF_ACCEPTORORDERKINDRF; }
            set { _sALESDETAILRF_ACCEPTORORDERKINDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INQUIRYNUMBERRF
        /// <summary>�⍇���ԍ��J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESDETAILRF_INQUIRYNUMBERRF
        {
            get { return _sALESDETAILRF_INQUIRYNUMBERRF; }
            set { _sALESDETAILRF_INQUIRYNUMBERRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INQROWNUMBERRF
        /// <summary>�⍇���s�ԍ��J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���s�ԍ��J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESDETAILRF_INQROWNUMBERRF
        {
            get { return _sALESDETAILRF_INQROWNUMBERRF; }
            set { _sALESDETAILRF_INQROWNUMBERRF = value; }
        }
        // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end


        /// <summary>
        /// ���R���[���㖾�׃f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FrePSalesDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesDetailWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePSalesDetailWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FrePSalesDetailWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FrePSalesDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FrePSalesDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePSalesDetailWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePSalesDetailWork || graph is ArrayList || graph is FrePSalesDetailWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( FrePSalesDetailWork ).FullName ) );

            if ( graph != null && graph is FrePSalesDetailWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePSalesDetailWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePSalesDetailWork[])graph).Length;
            }
            else if ( graph is FrePSalesDetailWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACPTANODRSTATUSRF
            //����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SALESSLIPNUMRF
            //�󒍔ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACCEPTANORDERNORF
            //����s�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESROWNORF
            //������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESDATERF
            //���ʒʔ�
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_COMMONSEQNORF
            //���㖾�גʔ�
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESSLIPDTLNUMRF
            //�󒍃X�e�[�^�X�i���j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACPTANODRSTATUSSRCRF
            //���㖾�גʔԁi���j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESSLIPDTLNUMSRCRF
            //�d���`���i�����j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SUPPLIERFORMALSYNCRF
            //�d�����גʔԁi�����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESSLIPCDDTLRF
            //�݌ɊǗ��L���敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_STOCKMNGEXISTCDRF
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
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CUSTRATEGRPCODERF
            //�艿��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICERATERF
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXINCFLRF
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXEXCFLRF
            //�艿�ύX�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_LISTPRICECHNGCDRF
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
            //�o�א�
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SHIPMENTCNTRF
            //�󒍐���
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_ACCEPTANORDERCNTRF
            //�󒍒�����
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_ACPTANODRADJUSTCNTRF
            //�󒍎c��
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_ACPTANODRREMAINCNTRF
            //�c���X�V��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_REMAINCNTUPDDATERF
            //������z�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXINCRF
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXEXCRF
            //����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_COSTRF
            //�e���`�F�b�N�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GRSPROFITCHKDIVRF
            //���㏤�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESGOODSCDRF
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
            //�����ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_ORDERNUMBERRF
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
            //���i���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKGDS_MAKERSHORTNAMERF
            //���i���[�J�[�J�i����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKGDS_MAKERKANANAMERF
            //���[�U�[�������i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MAKGDS_GOODSMAKERCDRF
            //�ꎮ���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKCMP_MAKERSHORTNAMERF
            //�ꎮ���[�J�[�J�i����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKCMP_MAKERKANANAMERF
            //���[�U�[�����ꎮ���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MAKCMP_GOODSMAKERCDRF
            //���i���̃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNAMEKANARF
            //JAN�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_JANRF
            //���i�|�������N
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSRATERANKRF
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNONONEHYPHENRF
            //���i���l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNOTE1RF
            //���i���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNOTE2RF
            //���i�K�i�E���L����
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSSPECIALNOTERF
            //�o�׉\��
            serInfo.MemberInfo.Add( typeof( Double ) ); //STOCKRF_SHIPMENTPOSCNTRF
            //�d���I�ԂP
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_DUPLICATIONSHELFNO1RF
            //�d���I�ԂQ
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_DUPLICATIONSHELFNO2RF
            //���i�Ǘ��敪�P
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_PARTSMANAGEMENTDIVIDE1RF
            //���i�Ǘ��敪�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_PARTSMANAGEMENTDIVIDE2RF
            //�݌ɔ��l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_STOCKNOTE1RF
            //�݌ɔ��l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_STOCKNOTE2RF
            //�q�ɔ��l1
            serInfo.MemberInfo.Add( typeof( string ) ); //WAREHOUSERF_WAREHOUSENOTE1RF
            //���Ӑ�|���f�q����
            serInfo.MemberInfo.Add( typeof( string ) ); //USRCSG_GUIDENAMERF
            //���[�U�[�����d����R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SUPPLIERRF_SUPPLIERCDRF
            //�d���於1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNM1RF
            //�d���於2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNM2RF
            //�d����h��
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPHONORIFICTITLERF
            //�d����J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERKANARF
            //�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SUPPLIERRF_PURECODERF
            //�d������l1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE1RF
            //�d������l2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE2RF
            //�d������l3
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE3RF
            //�d������l4
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE4RF
            //���[�U�[����BL���i�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGOODSCDURF_BLGOODSCODERF
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGOODSCDURF_BLGOODSHALFNAMERF
            //�݌ɊǗ��L���敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_STOCKMNGEXISTNMRF
            //���i��������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_GOODSKINDNAMERF
            //����݌Ɏ�񂹋敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESORDERDIVNMRF
            //�I�[�v�����i�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_OPENPRICEDIVNMRF
            //�e���`�F�b�N�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_GRSPROFITCHKDIVNMRF
            //���㏤�i�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESGOODSNMRF
            //�ېŋ敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_TAXATIONDIVNMRF
            //�����敪
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_PURECODENMRF
            //�[�i�����\�������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFYRF
            //�[�i�����\�������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFSRF
            //�[�i�����\����a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFWRF
            //�[�i�����\�����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFMRF
            //�[�i�����\�����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFDRF
            //�[�i�����\�������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFGRF
            //�[�i�����\�������
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFRRF
            //�[�i�����\������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLSRF
            //�[�i�����\������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLPRF
            //�[�i�����\������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLYRF
            //�[�i�����\������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLMRF
            //�[�i�����\������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLDRF
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
            //�݌Ɏ��敪�}�[�N
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESORDERDIVMARKRF
            //���[�J�[���p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MAKERHALFNAMERF
            //�Ԏ피�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELHALFNAMERF
            //BL���i�R�[�h�i����j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTBLGOODSCODERF
            //BL���i�R�[�h���́i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTBLGOODSNAMERF
            //����p�i��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTGOODSNORF
            //����p���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTMAKERCODERF
            //����p���[�J�[����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTMAKERNAMERF
            //����p���[�J�[�J�i����
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKPRT_MAKERKANANAMERF
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
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESCODERF
            //�̔��敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SALESCDNMRF
            //���i���̃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMEKANARF
            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //AB���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndEGoodsCdChgRF_ABGoodsCode
            // --- ADD 2009.07.24 ���m ------ <<<<<<
            // --- ADD 2011.07.19  ------ >>>>>>
            //�����񓚋敪(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //SALESDETAILRF_AUTOANSWERDIVSCMRF
            // --- ADD 2011.07.19  ------ <<<<<<
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            //�󔭒����
            serInfo.MemberInfo.Add(typeof(Int16)); //SALESDETAILRF_ACCEPTORORDERKINDRF
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //SALESDETAILRF_INQUIRYNUMBERRF
            //�⍇���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SALESDETAILRF_INQROWNUMBERRF
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end


            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePSalesDetailWork )
            {
                FrePSalesDetailWork temp = (FrePSalesDetailWork)graph;

                SetFrePSalesDetailWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePSalesDetailWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePSalesDetailWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePSalesDetailWork temp in lst )
                {
                    SetFrePSalesDetailWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePSalesDetailWork�����o��(public�v���p�e�B��)
        /// </summary>
        // private const int currentMemberCount = 189; // DEL ���m 2009.07.24
        // private const int currentMemberCount = 190; // ADD ���m 2009.07.24 // DEL 2011.07.19
        private const int currentMemberCount = 191; // ADD 2011.07.19

        /// <summary>
        ///  FrePSalesDetailWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesDetailWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFrePSalesDetailWork( System.IO.BinaryWriter writer, FrePSalesDetailWork temp )
        {
            //�󒍃X�e�[�^�X
            writer.Write( temp.SALESDETAILRF_ACPTANODRSTATUSRF );
            //����`�[�ԍ�
            writer.Write( temp.SALESDETAILRF_SALESSLIPNUMRF );
            //�󒍔ԍ�
            writer.Write( temp.SALESDETAILRF_ACCEPTANORDERNORF );
            //����s�ԍ�
            writer.Write( temp.SALESDETAILRF_SALESROWNORF );
            //������t
            writer.Write( temp.SALESDETAILRF_SALESDATERF );
            //���ʒʔ�
            writer.Write( temp.SALESDETAILRF_COMMONSEQNORF );
            //���㖾�גʔ�
            writer.Write( temp.SALESDETAILRF_SALESSLIPDTLNUMRF );
            //�󒍃X�e�[�^�X�i���j
            writer.Write( temp.SALESDETAILRF_ACPTANODRSTATUSSRCRF );
            //���㖾�גʔԁi���j
            writer.Write( temp.SALESDETAILRF_SALESSLIPDTLNUMSRCRF );
            //�d���`���i�����j
            writer.Write( temp.SALESDETAILRF_SUPPLIERFORMALSYNCRF );
            //�d�����גʔԁi�����j
            writer.Write( temp.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF );
            //����`�[�敪�i���ׁj
            writer.Write( temp.SALESDETAILRF_SALESSLIPCDDTLRF );
            //�݌ɊǗ��L���敪
            writer.Write( temp.SALESDETAILRF_STOCKMNGEXISTCDRF );
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
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write( temp.SALESDETAILRF_CUSTRATEGRPCODERF );
            //�艿��
            writer.Write( temp.SALESDETAILRF_LISTPRICERATERF );
            //�艿�i�ō��C�����j
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXINCFLRF );
            //�艿�i�Ŕ��C�����j
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXEXCFLRF );
            //�艿�ύX�敪
            writer.Write( temp.SALESDETAILRF_LISTPRICECHNGCDRF );
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
            //�o�א�
            writer.Write( temp.SALESDETAILRF_SHIPMENTCNTRF );
            //�󒍐���
            writer.Write( temp.SALESDETAILRF_ACCEPTANORDERCNTRF );
            //�󒍒�����
            writer.Write( temp.SALESDETAILRF_ACPTANODRADJUSTCNTRF );
            //�󒍎c��
            writer.Write( temp.SALESDETAILRF_ACPTANODRREMAINCNTRF );
            //�c���X�V��
            writer.Write( temp.SALESDETAILRF_REMAINCNTUPDDATERF );
            //������z�i�ō��݁j
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXINCRF );
            //������z�i�Ŕ����j
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXEXCRF );
            //����
            writer.Write( temp.SALESDETAILRF_COSTRF );
            //�e���`�F�b�N�敪
            writer.Write( temp.SALESDETAILRF_GRSPROFITCHKDIVRF );
            //���㏤�i�敪
            writer.Write( temp.SALESDETAILRF_SALESGOODSCDRF );
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
            //�����ԍ�
            writer.Write( temp.SALESDETAILRF_ORDERNUMBERRF );
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
            //���i���[�J�[����
            writer.Write( temp.MAKGDS_MAKERSHORTNAMERF );
            //���i���[�J�[�J�i����
            writer.Write( temp.MAKGDS_MAKERKANANAMERF );
            //���[�U�[�������i���[�J�[�R�[�h
            writer.Write( temp.MAKGDS_GOODSMAKERCDRF );
            //�ꎮ���[�J�[����
            writer.Write( temp.MAKCMP_MAKERSHORTNAMERF );
            //�ꎮ���[�J�[�J�i����
            writer.Write( temp.MAKCMP_MAKERKANANAMERF );
            //���[�U�[�����ꎮ���[�J�[�R�[�h
            writer.Write( temp.MAKCMP_GOODSMAKERCDRF );
            //���i���̃J�i
            writer.Write( temp.GOODSURF_GOODSNAMEKANARF );
            //JAN�R�[�h
            writer.Write( temp.GOODSURF_JANRF );
            //���i�|�������N
            writer.Write( temp.GOODSURF_GOODSRATERANKRF );
            //�n�C�t�������i�ԍ�
            writer.Write( temp.GOODSURF_GOODSNONONEHYPHENRF );
            //���i���l�P
            writer.Write( temp.GOODSURF_GOODSNOTE1RF );
            //���i���l�Q
            writer.Write( temp.GOODSURF_GOODSNOTE2RF );
            //���i�K�i�E���L����
            writer.Write( temp.GOODSURF_GOODSSPECIALNOTERF );
            //�o�׉\��
            writer.Write( temp.STOCKRF_SHIPMENTPOSCNTRF );
            //�d���I�ԂP
            writer.Write( temp.STOCKRF_DUPLICATIONSHELFNO1RF );
            //�d���I�ԂQ
            writer.Write( temp.STOCKRF_DUPLICATIONSHELFNO2RF );
            //���i�Ǘ��敪�P
            writer.Write( temp.STOCKRF_PARTSMANAGEMENTDIVIDE1RF );
            //���i�Ǘ��敪�Q
            writer.Write( temp.STOCKRF_PARTSMANAGEMENTDIVIDE2RF );
            //�݌ɔ��l�P
            writer.Write( temp.STOCKRF_STOCKNOTE1RF );
            //�݌ɔ��l�Q
            writer.Write( temp.STOCKRF_STOCKNOTE2RF );
            //�q�ɔ��l1
            writer.Write( temp.WAREHOUSERF_WAREHOUSENOTE1RF );
            //���Ӑ�|���f�q����
            writer.Write( temp.USRCSG_GUIDENAMERF );
            //���[�U�[�����d����R�[�h
            writer.Write( temp.SUPPLIERRF_SUPPLIERCDRF );
            //�d���於1
            writer.Write( temp.SUPPLIERRF_SUPPLIERNM1RF );
            //�d���於2
            writer.Write( temp.SUPPLIERRF_SUPPLIERNM2RF );
            //�d����h��
            writer.Write( temp.SUPPLIERRF_SUPPHONORIFICTITLERF );
            //�d����J�i
            writer.Write( temp.SUPPLIERRF_SUPPLIERKANARF );
            //�����敪
            writer.Write( temp.SUPPLIERRF_PURECODERF );
            //�d������l1
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE1RF );
            //�d������l2
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE2RF );
            //�d������l3
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE3RF );
            //�d������l4
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE4RF );
            //���[�U�[����BL���i�R�[�h
            writer.Write( temp.BLGOODSCDURF_BLGOODSCODERF );
            //BL���i�R�[�h���́i���p�j
            writer.Write( temp.BLGOODSCDURF_BLGOODSHALFNAMERF );
            //�݌ɊǗ��L���敪����
            writer.Write( temp.DADD_STOCKMNGEXISTNMRF );
            //���i��������
            writer.Write( temp.DADD_GOODSKINDNAMERF );
            //����݌Ɏ�񂹋敪����
            writer.Write( temp.DADD_SALESORDERDIVNMRF );
            //�I�[�v�����i�敪����
            writer.Write( temp.DADD_OPENPRICEDIVNMRF );
            //�e���`�F�b�N�敪����
            writer.Write( temp.DADD_GRSPROFITCHKDIVNMRF );
            //���㏤�i�敪����
            writer.Write( temp.DADD_SALESGOODSNMRF );
            //�ېŋ敪����
            writer.Write( temp.DADD_TAXATIONDIVNMRF );
            //�����敪
            writer.Write( temp.DADD_PURECODENMRF );
            //�[�i�����\�������N
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFYRF );
            //�[�i�����\�������N��
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFSRF );
            //�[�i�����\����a��N
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFWRF );
            //�[�i�����\�����
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFMRF );
            //�[�i�����\�����
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFDRF );
            //�[�i�����\�������
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFGRF );
            //�[�i�����\�������
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFRRF );
            //�[�i�����\������e����(/)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLSRF );
            //�[�i�����\������e����(.)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLPRF );
            //�[�i�����\������e����(�N)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLYRF );
            //�[�i�����\������e����(��)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLMRF );
            //�[�i�����\������e����(��)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLDRF );
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
            //�݌Ɏ��敪�}�[�N
            writer.Write( temp.DADD_SALESORDERDIVMARKRF );
            //���[�J�[���p����
            writer.Write( temp.ACCEPTODRCARRF_MAKERHALFNAMERF );
            //�Ԏ피�p����
            writer.Write( temp.ACCEPTODRCARRF_MODELHALFNAMERF );
            //BL���i�R�[�h�i����j
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSCODERF );
            //BL���i�R�[�h���́i����j
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSNAMERF );
            //����p�i��
            writer.Write( temp.SALESDETAILRF_PRTGOODSNORF );
            //����p���[�J�[�R�[�h
            writer.Write( temp.SALESDETAILRF_PRTMAKERCODERF );
            //����p���[�J�[����
            writer.Write( temp.SALESDETAILRF_PRTMAKERNAMERF );
            //����p���[�J�[�J�i����
            writer.Write( temp.MAKPRT_MAKERKANANAMERF );
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
            //�̔��敪�R�[�h
            writer.Write( temp.SALESDETAILRF_SALESCODERF );
            //�̔��敪����
            writer.Write( temp.SALESDETAILRF_SALESCDNMRF );
            //���i���̃J�i
            writer.Write( temp.SALESDETAILRF_GOODSNAMEKANARF );
            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //AB���i�R�[�h
            writer.Write(temp.SANDEGOODSCDCHGRF_ABGOODSCODE);
            // --- ADD 2009.07.24 ���m ------ <<<<<<
            // --- ADD 2011.07.19 ------ >>>>>>
            //�����񓚋敪(SCM)
            writer.Write(temp.SALESDETAILRF_AUTOANSWERDIVSCMRF);
            // --- ADD 2011.07.19 ------ <<<<<<
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            //�󔭒����
            writer.Write(temp.SALESDETAILRF_ACCEPTORORDERKINDRF);
            //�⍇���ԍ�
            writer.Write(temp.SALESDETAILRF_INQUIRYNUMBERRF);
            //�⍇���s�ԍ�
            writer.Write(temp.SALESDETAILRF_INQROWNUMBERRF);
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end
        }

        /// <summary>
        ///  FrePSalesDetailWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FrePSalesDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesDetailWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FrePSalesDetailWork GetFrePSalesDetailWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FrePSalesDetailWork temp = new FrePSalesDetailWork();

            //�󒍃X�e�[�^�X
            temp.SALESDETAILRF_ACPTANODRSTATUSRF = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SALESDETAILRF_SALESSLIPNUMRF = reader.ReadString();
            //�󒍔ԍ�
            temp.SALESDETAILRF_ACCEPTANORDERNORF = reader.ReadInt32();
            //����s�ԍ�
            temp.SALESDETAILRF_SALESROWNORF = reader.ReadInt32();
            //������t
            temp.SALESDETAILRF_SALESDATERF = reader.ReadInt32();
            //���ʒʔ�
            temp.SALESDETAILRF_COMMONSEQNORF = reader.ReadInt64();
            //���㖾�גʔ�
            temp.SALESDETAILRF_SALESSLIPDTLNUMRF = reader.ReadInt64();
            //�󒍃X�e�[�^�X�i���j
            temp.SALESDETAILRF_ACPTANODRSTATUSSRCRF = reader.ReadInt32();
            //���㖾�גʔԁi���j
            temp.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = reader.ReadInt64();
            //�d���`���i�����j
            temp.SALESDETAILRF_SUPPLIERFORMALSYNCRF = reader.ReadInt32();
            //�d�����גʔԁi�����j
            temp.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = reader.ReadInt64();
            //����`�[�敪�i���ׁj
            temp.SALESDETAILRF_SALESSLIPCDDTLRF = reader.ReadInt32();
            //�݌ɊǗ��L���敪
            temp.SALESDETAILRF_STOCKMNGEXISTCDRF = reader.ReadInt32();
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
            //���Ӑ�|���O���[�v�R�[�h
            temp.SALESDETAILRF_CUSTRATEGRPCODERF = reader.ReadInt32();
            //�艿��
            temp.SALESDETAILRF_LISTPRICERATERF = reader.ReadDouble();
            //�艿�i�ō��C�����j
            temp.SALESDETAILRF_LISTPRICETAXINCFLRF = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.SALESDETAILRF_LISTPRICETAXEXCFLRF = reader.ReadDouble();
            //�艿�ύX�敪
            temp.SALESDETAILRF_LISTPRICECHNGCDRF = reader.ReadInt32();
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
            //�o�א�
            temp.SALESDETAILRF_SHIPMENTCNTRF = reader.ReadDouble();
            //�󒍐���
            temp.SALESDETAILRF_ACCEPTANORDERCNTRF = reader.ReadDouble();
            //�󒍒�����
            temp.SALESDETAILRF_ACPTANODRADJUSTCNTRF = reader.ReadDouble();
            //�󒍎c��
            temp.SALESDETAILRF_ACPTANODRREMAINCNTRF = reader.ReadDouble();
            //�c���X�V��
            temp.SALESDETAILRF_REMAINCNTUPDDATERF = reader.ReadInt32();
            //������z�i�ō��݁j
            temp.SALESDETAILRF_SALESMONEYTAXINCRF = reader.ReadInt64();
            //������z�i�Ŕ����j
            temp.SALESDETAILRF_SALESMONEYTAXEXCRF = reader.ReadInt64();
            //����
            temp.SALESDETAILRF_COSTRF = reader.ReadInt64();
            //�e���`�F�b�N�敪
            temp.SALESDETAILRF_GRSPROFITCHKDIVRF = reader.ReadInt32();
            //���㏤�i�敪
            temp.SALESDETAILRF_SALESGOODSCDRF = reader.ReadInt32();
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
            //�����ԍ�
            temp.SALESDETAILRF_ORDERNUMBERRF = reader.ReadString();
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
            //���i���[�J�[����
            temp.MAKGDS_MAKERSHORTNAMERF = reader.ReadString();
            //���i���[�J�[�J�i����
            temp.MAKGDS_MAKERKANANAMERF = reader.ReadString();
            //���[�U�[�������i���[�J�[�R�[�h
            temp.MAKGDS_GOODSMAKERCDRF = reader.ReadInt32();
            //�ꎮ���[�J�[����
            temp.MAKCMP_MAKERSHORTNAMERF = reader.ReadString();
            //�ꎮ���[�J�[�J�i����
            temp.MAKCMP_MAKERKANANAMERF = reader.ReadString();
            //���[�U�[�����ꎮ���[�J�[�R�[�h
            temp.MAKCMP_GOODSMAKERCDRF = reader.ReadInt32();
            //���i���̃J�i
            temp.GOODSURF_GOODSNAMEKANARF = reader.ReadString();
            //JAN�R�[�h
            temp.GOODSURF_JANRF = reader.ReadString();
            //���i�|�������N
            temp.GOODSURF_GOODSRATERANKRF = reader.ReadString();
            //�n�C�t�������i�ԍ�
            temp.GOODSURF_GOODSNONONEHYPHENRF = reader.ReadString();
            //���i���l�P
            temp.GOODSURF_GOODSNOTE1RF = reader.ReadString();
            //���i���l�Q
            temp.GOODSURF_GOODSNOTE2RF = reader.ReadString();
            //���i�K�i�E���L����
            temp.GOODSURF_GOODSSPECIALNOTERF = reader.ReadString();
            //�o�׉\��
            temp.STOCKRF_SHIPMENTPOSCNTRF = reader.ReadDouble();
            //�d���I�ԂP
            temp.STOCKRF_DUPLICATIONSHELFNO1RF = reader.ReadString();
            //�d���I�ԂQ
            temp.STOCKRF_DUPLICATIONSHELFNO2RF = reader.ReadString();
            //���i�Ǘ��敪�P
            temp.STOCKRF_PARTSMANAGEMENTDIVIDE1RF = reader.ReadString();
            //���i�Ǘ��敪�Q
            temp.STOCKRF_PARTSMANAGEMENTDIVIDE2RF = reader.ReadString();
            //�݌ɔ��l�P
            temp.STOCKRF_STOCKNOTE1RF = reader.ReadString();
            //�݌ɔ��l�Q
            temp.STOCKRF_STOCKNOTE2RF = reader.ReadString();
            //�q�ɔ��l1
            temp.WAREHOUSERF_WAREHOUSENOTE1RF = reader.ReadString();
            //���Ӑ�|���f�q����
            temp.USRCSG_GUIDENAMERF = reader.ReadString();
            //���[�U�[�����d����R�[�h
            temp.SUPPLIERRF_SUPPLIERCDRF = reader.ReadInt32();
            //�d���於1
            temp.SUPPLIERRF_SUPPLIERNM1RF = reader.ReadString();
            //�d���於2
            temp.SUPPLIERRF_SUPPLIERNM2RF = reader.ReadString();
            //�d����h��
            temp.SUPPLIERRF_SUPPHONORIFICTITLERF = reader.ReadString();
            //�d����J�i
            temp.SUPPLIERRF_SUPPLIERKANARF = reader.ReadString();
            //�����敪
            temp.SUPPLIERRF_PURECODERF = reader.ReadInt32();
            //�d������l1
            temp.SUPPLIERRF_SUPPLIERNOTE1RF = reader.ReadString();
            //�d������l2
            temp.SUPPLIERRF_SUPPLIERNOTE2RF = reader.ReadString();
            //�d������l3
            temp.SUPPLIERRF_SUPPLIERNOTE3RF = reader.ReadString();
            //�d������l4
            temp.SUPPLIERRF_SUPPLIERNOTE4RF = reader.ReadString();
            //���[�U�[����BL���i�R�[�h
            temp.BLGOODSCDURF_BLGOODSCODERF = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGOODSCDURF_BLGOODSHALFNAMERF = reader.ReadString();
            //�݌ɊǗ��L���敪����
            temp.DADD_STOCKMNGEXISTNMRF = reader.ReadString();
            //���i��������
            temp.DADD_GOODSKINDNAMERF = reader.ReadString();
            //����݌Ɏ�񂹋敪����
            temp.DADD_SALESORDERDIVNMRF = reader.ReadString();
            //�I�[�v�����i�敪����
            temp.DADD_OPENPRICEDIVNMRF = reader.ReadString();
            //�e���`�F�b�N�敪����
            temp.DADD_GRSPROFITCHKDIVNMRF = reader.ReadString();
            //���㏤�i�敪����
            temp.DADD_SALESGOODSNMRF = reader.ReadString();
            //�ېŋ敪����
            temp.DADD_TAXATIONDIVNMRF = reader.ReadString();
            //�����敪
            temp.DADD_PURECODENMRF = reader.ReadString();
            //�[�i�����\�������N
            temp.DADD_DELIGDSCMPLTDUEDATEFYRF = reader.ReadInt32();
            //�[�i�����\�������N��
            temp.DADD_DELIGDSCMPLTDUEDATEFSRF = reader.ReadInt32();
            //�[�i�����\����a��N
            temp.DADD_DELIGDSCMPLTDUEDATEFWRF = reader.ReadInt32();
            //�[�i�����\�����
            temp.DADD_DELIGDSCMPLTDUEDATEFMRF = reader.ReadInt32();
            //�[�i�����\�����
            temp.DADD_DELIGDSCMPLTDUEDATEFDRF = reader.ReadInt32();
            //�[�i�����\�������
            temp.DADD_DELIGDSCMPLTDUEDATEFGRF = reader.ReadString();
            //�[�i�����\�������
            temp.DADD_DELIGDSCMPLTDUEDATEFRRF = reader.ReadString();
            //�[�i�����\������e����(/)
            temp.DADD_DELIGDSCMPLTDUEDATEFLSRF = reader.ReadString();
            //�[�i�����\������e����(.)
            temp.DADD_DELIGDSCMPLTDUEDATEFLPRF = reader.ReadString();
            //�[�i�����\������e����(�N)
            temp.DADD_DELIGDSCMPLTDUEDATEFLYRF = reader.ReadString();
            //�[�i�����\������e����(��)
            temp.DADD_DELIGDSCMPLTDUEDATEFLMRF = reader.ReadString();
            //�[�i�����\������e����(��)
            temp.DADD_DELIGDSCMPLTDUEDATEFLDRF = reader.ReadString();
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
            //�݌Ɏ��敪�}�[�N
            temp.DADD_SALESORDERDIVMARKRF = reader.ReadString();
            //���[�J�[���p����
            temp.ACCEPTODRCARRF_MAKERHALFNAMERF = reader.ReadString();
            //�Ԏ피�p����
            temp.ACCEPTODRCARRF_MODELHALFNAMERF = reader.ReadString();
            //BL���i�R�[�h�i����j
            temp.SALESDETAILRF_PRTBLGOODSCODERF = reader.ReadInt32();
            //BL���i�R�[�h���́i����j
            temp.SALESDETAILRF_PRTBLGOODSNAMERF = reader.ReadString();
            //����p�i��
            temp.SALESDETAILRF_PRTGOODSNORF = reader.ReadString();
            //����p���[�J�[�R�[�h
            temp.SALESDETAILRF_PRTMAKERCODERF = reader.ReadInt32();
            //����p���[�J�[����
            temp.SALESDETAILRF_PRTMAKERNAMERF = reader.ReadString();
            //����p���[�J�[�J�i����
            temp.MAKPRT_MAKERKANANAMERF = reader.ReadString();
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
            //�̔��敪�R�[�h
            temp.SALESDETAILRF_SALESCODERF = reader.ReadInt32();
            //�̔��敪����
            temp.SALESDETAILRF_SALESCDNMRF = reader.ReadString();
            //���i���̃J�i
            temp.SALESDETAILRF_GOODSNAMEKANARF = reader.ReadString();
            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //AB���i�R�[�h
            temp.SANDEGOODSCDCHGRF_ABGOODSCODE = reader.ReadString();
            // --- ADD 2009.07.24 ���m ------ <<<<<<
            // --- ADD 2011.07.19 ------ >>>>>>
            //�����񓚋敪(SCM)
            temp.SALESDETAILRF_AUTOANSWERDIVSCMRF = reader.ReadInt32();
            // --- ADD 2011.07.19 ------ <<<<<<
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811 begin
            //�󔭒����
            temp.SALESDETAILRF_ACCEPTORORDERKINDRF = reader.ReadInt16();
            //�⍇���ԍ�
            temp.SALESDETAILRF_INQUIRYNUMBERRF = reader.ReadInt64();
            //�⍇���s�ԍ�
            temp.SALESDETAILRF_INQROWNUMBERRF = reader.ReadInt32();
            // add by zhouzy for PCCUOE�����[�g�`�[���s 20110811  end

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
        /// <returns>FrePSalesDetailWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesDetailWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePSalesDetailWork temp = GetFrePSalesDetailWork( reader, serInfo );
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
                    retValue = (FrePSalesDetailWork[])lst.ToArray( typeof( FrePSalesDetailWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
