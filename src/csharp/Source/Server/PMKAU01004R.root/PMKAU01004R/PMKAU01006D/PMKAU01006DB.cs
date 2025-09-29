using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PdfAllOutputFrePBillHeadWork
    /// <summary>
    ///                      ���R���[�������w�b�_�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�������w�b�_�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Genarated Date   :   2022/03/07  (CSharp File Generated Date)</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EBooksFrePBillHeadWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _cUSTDMDPRCRF_ADDUPSECCODERF = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>������e�R�[�h</remarks>
        private Int32 _cUSTDMDPRCRF_CLAIMCODERF;

        /// <summary>�����於��</summary>
        private string _cUSTDMDPRCRF_CLAIMNAMERF = "";

        /// <summary>�����於��2</summary>
        private string _cUSTDMDPRCRF_CLAIMNAME2RF = "";

        /// <summary>�����旪��</summary>
        private string _cUSTDMDPRCRF_CLAIMSNMRF = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _cUSTDMDPRCRF_CUSTOMERCODERF;

        /// <summary>���Ӑ於��</summary>
        private string _cUSTDMDPRCRF_CUSTOMERNAMERF = "";

        /// <summary>���Ӑ於��2</summary>
        private string _cUSTDMDPRCRF_CUSTOMERNAME2RF = "";

        /// <summary>���Ӑ旪��</summary>
        private string _cUSTDMDPRCRF_CUSTOMERSNMRF = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private Int32 _cUSTDMDPRCRF_ADDUPDATERF;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _cUSTDMDPRCRF_ADDUPYEARMONTHRF;

        /// <summary>�O�񐿋����z</summary>
        private Int64 _cUSTDMDPRCRF_LASTTIMEDEMANDRF;

        /// <summary>����萔���z�i�ʏ�����j</summary>
        private Int64 _cUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;

        /// <summary>����l���z�i�ʏ�����j</summary>
        private Int64 _cUSTDMDPRCRF_THISTIMEDISDMDNRMLRF;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>�����z�̍��v���z</remarks>
        private Int64 _cUSTDMDPRCRF_THISTIMEDMDNRMLRF;

        /// <summary>����J�z�c���i�����v�j</summary>
        /// <remarks>����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j</remarks>
        private Int64 _cUSTDMDPRCRF_THISTIMETTLBLCDMDRF;

        /// <summary>���E�㍡�񔄏���z</summary>
        private Int64 _cUSTDMDPRCRF_OFSTHISTIMESALESRF;

        /// <summary>���E�㍡�񔄏�����</summary>
        private Int64 _cUSTDMDPRCRF_OFSTHISSALESTAXRF;

        /// <summary>���E��O�őΏۊz</summary>
        /// <remarks>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF;

        /// <summary>���E����őΏۊz</summary>
        /// <remarks>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDOFFSETINTAXRF;

        /// <summary>���E���ېőΏۊz</summary>
        /// <remarks>���E�p�F��ېŊz�̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDOFFSETTAXFREERF;

        /// <summary>���E��O�ŏ����</summary>
        /// <remarks>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _cUSTDMDPRCRF_OFFSETOUTTAXRF;

        /// <summary>���E����ŏ����</summary>
        /// <remarks>���E�p�F���ŏ���ł̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_OFFSETINTAXRF;

        /// <summary>���񔄏���z</summary>
        /// <remarks>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
        private Int64 _cUSTDMDPRCRF_THISTIMESALESRF;

        /// <summary>���񔄏�����</summary>
        private Int64 _cUSTDMDPRCRF_THISSALESTAXRF;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDSALESOUTTAXRF;

        /// <summary>������őΏۊz</summary>
        /// <remarks>�����p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDSALESINTAXRF;

        /// <summary>�����ېőΏۊz</summary>
        /// <remarks>�����p�F��ېŊz�̏W�v</remarks>
        private Int64 _cUSTDMDPRCRF_ITDEDSALESTAXFREERF;

        /// <summary>����O�Ŋz</summary>
        /// <remarks>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _cUSTDMDPRCRF_SALESOUTTAXRF;

        /// <summary>������Ŋz</summary>
        /// <remarks>�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</remarks>
        private Int64 _cUSTDMDPRCRF_SALESINTAXRF;

        /// <summary>���񔄏�ԕi���z</summary>
        /// <remarks>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRICRGDSRF;

        /// <summary>���񔄏�ԕi�����</summary>
        /// <remarks>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRCTAXRGDSRF;

        /// <summary>�ԕi�O�őΏۊz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDRETOUTTAXRF;

        /// <summary>�ԕi���őΏۊz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDRETINTAXRF;

        /// <summary>�ԕi��ېőΏۊz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDRETTAXFREERF;

        /// <summary>�ԕi�O�Ŋz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLRETOUTERTAXRF;

        /// <summary>�ԕi���Ŋz���v</summary>
        /// <remarks>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
        private Int64 _cUSTDMDPRCRF_TTLRETINNERTAXRF;

        /// <summary>���񔄏�l�����z</summary>
        /// <remarks>�|���F�Ŕ����̔���l�����z</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRICDISRF;

        /// <summary>���񔄏�l�������</summary>
        /// <remarks>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
        private Int64 _cUSTDMDPRCRF_THISSALESPRCTAXDISRF;

        /// <summary>�l���O�őΏۊz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDDISOUTTAXRF;

        /// <summary>�l�����őΏۊz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDDISINTAXRF;

        /// <summary>�l����ېőΏۊz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLITDEDDISTAXFREERF;

        /// <summary>�l���O�Ŋz���v</summary>
        private Int64 _cUSTDMDPRCRF_TTLDISOUTERTAXRF;

        /// <summary>�l�����Ŋz���v</summary>
        /// <remarks>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz</remarks>
        private Int64 _cUSTDMDPRCRF_TTLDISINNERTAXRF;

        /// <summary>����Œ����z</summary>
        private Int64 _cUSTDMDPRCRF_TAXADJUSTRF;

        /// <summary>�c�������z</summary>
        private Int64 _cUSTDMDPRCRF_BALANCEADJUSTRF;

        /// <summary>�v�Z�㐿�����z</summary>
        /// <remarks>���񐿋����z</remarks>
        private Int64 _cUSTDMDPRCRF_AFCALDEMANDPRICERF;

        /// <summary>��2��O�c���i�����v�j</summary>
        private Int64 _cUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF;

        /// <summary>��3��O�c���i�����v�j</summary>
        private Int64 _cUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private Int32 _cUSTDMDPRCRF_STARTCADDUPUPDDATERF;

        /// <summary>����`�[����</summary>
        /// <remarks>�|���̓`�[����</remarks>
        private Int32 _cUSTDMDPRCRF_SALESSLIPCOUNTRF;

        /// <summary>���������s��</summary>
        /// <remarks>"YYYYMMDD"  �������𔭍s�����N����</remarks>
        private Int32 _cUSTDMDPRCRF_BILLPRINTDATERF;

        /// <summary>�����\���</summary>
        private Int32 _cUSTDMDPRCRF_EXPECTEDDEPOSITDATERF;

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _cUSTDMDPRCRF_COLLECTCONDRF;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
        private Int32 _cUSTDMDPRCRF_CONSTAXLAYMETHODRF;

        /// <summary>����ŗ�</summary>
        /// <remarks>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</remarks>
        private Double _cUSTDMDPRCRF_CONSTAXRATERF;

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sECHED_SECTIONGUIDENMRF = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sECHED_SECTIONGUIDESNMRF = "";

        /// <summary>���Ж��̃R�[�h1</summary>
        private Int32 _sECHED_COMPANYNAMECD1RF;

        /// <summary>����PR��</summary>
        private string _cOMPANYNMRF_COMPANYPRRF = "";

        /// <summary>���Ж���1</summary>
        private string _cOMPANYNMRF_COMPANYNAME1RF = "";

        /// <summary>���Ж���2</summary>
        private string _cOMPANYNMRF_COMPANYNAME2RF = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _cOMPANYNMRF_POSTNORF = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _cOMPANYNMRF_ADDRESS1RF = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _cOMPANYNMRF_ADDRESS3RF = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _cOMPANYNMRF_ADDRESS4RF = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO1RF = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO2RF = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYNMRF_COMPANYTELNO3RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE1RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE2RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYNMRF_COMPANYTELTITLE3RF = "";

        /// <summary>��s�U���ē���</summary>
        private string _cOMPANYNMRF_TRANSFERGUIDANCERF = "";

        /// <summary>��s����1</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO1RF = "";

        /// <summary>��s����2</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO2RF = "";

        /// <summary>��s����3</summary>
        private string _cOMPANYNMRF_ACCOUNTNOINFO3RF = "";

        /// <summary>���Аݒ�E�v1</summary>
        private string _cOMPANYNMRF_COMPANYSETNOTE1RF = "";

        /// <summary>���Аݒ�E�v2</summary>
        private string _cOMPANYNMRF_COMPANYSETNOTE2RF = "";

        /// <summary>�摜���R�[�h</summary>
        private Int32 _cOMPANYNMRF_IMAGEINFOCODERF;

        /// <summary>����URL</summary>
        private string _cOMPANYNMRF_COMPANYURLRF = "";

        /// <summary>����PR��2</summary>
        /// <remarks>��\����𓙂̏������</remarks>
        private string _cOMPANYNMRF_COMPANYPRSENTENCE2RF = "";

        /// <summary>�摜�󎚗p�R�����g1</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>�摜�󎚗p�R�����g2</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>�摜���f�[�^</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

        /// <summary>���Ӑ�T�u�R�[�h</summary>
        private string _cSTCST_CUSTOMERSUBCODERF = "";

        /// <summary>���Ӑ於��</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_NAMERF = "";

        /// <summary>���Ӑ於��2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_NAME2RF = "";

        /// <summary>���Ӑ�h��</summary>
        private string _cSTCST_HONORIFICTITLERF = "";

        /// <summary>���Ӑ�J�i</summary>
        private string _cSTCST_KANARF = "";

        /// <summary>���Ӑ旪��</summary>
        private string _cSTCST_CUSTOMERSNMRF = "";

        /// <summary>���Ӑ揔���R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _cSTCST_OUTPUTNAMECODERF;

        /// <summary>���Ӑ�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_POSTNORF = "";

        /// <summary>���Ӑ�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_ADDRESS1RF = "";

        /// <summary>���Ӑ�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_ADDRESS3RF = "";

        /// <summary>���Ӑ�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_ADDRESS4RF = "";

        /// <summary>���Ӑ敪�̓R�[�h1</summary>
        private Int32 _cSTCST_CUSTANALYSCODE1RF;

        /// <summary>���Ӑ敪�̓R�[�h2</summary>
        private Int32 _cSTCST_CUSTANALYSCODE2RF;

        /// <summary>���Ӑ敪�̓R�[�h3</summary>
        private Int32 _cSTCST_CUSTANALYSCODE3RF;

        /// <summary>���Ӑ敪�̓R�[�h4</summary>
        private Int32 _cSTCST_CUSTANALYSCODE4RF;

        /// <summary>���Ӑ敪�̓R�[�h5</summary>
        private Int32 _cSTCST_CUSTANALYSCODE5RF;

        /// <summary>���Ӑ敪�̓R�[�h6</summary>
        private Int32 _cSTCST_CUSTANALYSCODE6RF;

        /// <summary>���Ӑ���l1</summary>
        private string _cSTCST_NOTE1RF = "";

        /// <summary>���Ӑ���l2</summary>
        private string _cSTCST_NOTE2RF = "";

        /// <summary>���Ӑ���l3</summary>
        private string _cSTCST_NOTE3RF = "";

        /// <summary>���Ӑ���l4</summary>
        private string _cSTCST_NOTE4RF = "";

        /// <summary>���Ӑ���l5</summary>
        private string _cSTCST_NOTE5RF = "";

        /// <summary>���Ӑ���l6</summary>
        private string _cSTCST_NOTE6RF = "";

        /// <summary>���Ӑ���l7</summary>
        private string _cSTCST_NOTE7RF = "";

        /// <summary>���Ӑ���l8</summary>
        private string _cSTCST_NOTE8RF = "";

        /// <summary>���Ӑ���l9</summary>
        private string _cSTCST_NOTE9RF = "";

        /// <summary>���Ӑ���l10</summary>
        private string _cSTCST_NOTE10RF = "";

        // --- ADD START �c������ 2022/10/18 ----->>>>>
        /// <summary>�������Œ[�������R�[�h</summary>
        private Int32 _cSTCLM_SALESCNSTAXFRCPROCCDRF;
        // --- ADD END �c������ 2022/10/18 -----<<<<<

        /// <summary>������T�u�R�[�h</summary>
        private string _cSTCLM_CUSTOMERSUBCODERF = "";

        /// <summary>�����於��</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_NAMERF = "";

        /// <summary>�����於��2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_NAME2RF = "";

        /// <summary>������h��</summary>
        private string _cSTCLM_HONORIFICTITLERF = "";

        /// <summary>������J�i</summary>
        private string _cSTCLM_KANARF = "";

        /// <summary>�����旪��</summary>
        private string _cSTCLM_CUSTOMERSNMRF = "";

        /// <summary>�����揔���R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _cSTCLM_OUTPUTNAMECODERF;

        /// <summary>������X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_POSTNORF = "";

        /// <summary>������Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_ADDRESS1RF = "";

        /// <summary>������Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_ADDRESS3RF = "";

        /// <summary>������Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_ADDRESS4RF = "";

        /// <summary>�����敪�̓R�[�h1</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE1RF;

        /// <summary>�����敪�̓R�[�h2</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE2RF;

        /// <summary>�����敪�̓R�[�h3</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE3RF;

        /// <summary>�����敪�̓R�[�h4</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE4RF;

        /// <summary>�����敪�̓R�[�h5</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE5RF;

        /// <summary>�����敪�̓R�[�h6</summary>
        private Int32 _cSTCLM_CUSTANALYSCODE6RF;

        /// <summary>��������l1</summary>
        private string _cSTCLM_NOTE1RF = "";

        /// <summary>��������l2</summary>
        private string _cSTCLM_NOTE2RF = "";

        /// <summary>��������l3</summary>
        private string _cSTCLM_NOTE3RF = "";

        /// <summary>��������l4</summary>
        private string _cSTCLM_NOTE4RF = "";

        /// <summary>��������l5</summary>
        private string _cSTCLM_NOTE5RF = "";

        /// <summary>��������l6</summary>
        private string _cSTCLM_NOTE6RF = "";

        /// <summary>��������l7</summary>
        private string _cSTCLM_NOTE7RF = "";

        /// <summary>��������l8</summary>
        private string _cSTCLM_NOTE8RF = "";

        /// <summary>��������l9</summary>
        private string _cSTCLM_NOTE9RF = "";

        /// <summary>��������l10</summary>
        private string _cSTCLM_NOTE10RF = "";

        /// <summary>���Ж���1</summary>
        private string _cOMPANYINFRF_COMPANYNAME1RF = "";

        /// <summary>���Ж���2</summary>
        private string _cOMPANYINFRF_COMPANYNAME2RF = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _cOMPANYINFRF_POSTNORF = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _cOMPANYINFRF_ADDRESS1RF = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _cOMPANYINFRF_ADDRESS3RF = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _cOMPANYINFRF_ADDRESS4RF = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO1RF = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO2RF = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO3RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE1RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE2RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE3RF = "";

        /// <summary>�����ݒ����R�[�h1</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD1RF;

        /// <summary>�����ݒ����R�[�h2</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD2RF;

        /// <summary>�����ݒ����R�[�h3</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD3RF;

        /// <summary>�����ݒ����R�[�h4</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD4RF;

        /// <summary>�����ݒ����R�[�h5</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD5RF;

        /// <summary>�����ݒ����R�[�h6</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD6RF;

        /// <summary>�����ݒ����R�[�h7</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD7RF;

        /// <summary>�����ݒ����R�[�h8</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD8RF;

        /// <summary>�����ݒ����R�[�h9</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD9RF;

        /// <summary>�����ݒ����R�[�h10</summary>
        private Int32 _dEPOSITSTRF_DEPOSITSTKINDCD10RF;

        /// <summary>�������햼��1</summary>
        private string _dEPT01_MONEYKINDNAMERF = "";

        /// <summary>�������z1</summary>
        private Int64 _dEPT01_DEPOSITRF;

        /// <summary>�������햼��2</summary>
        private string _dEPT02_MONEYKINDNAMERF = "";

        /// <summary>�������z2</summary>
        private Int64 _dEPT02_DEPOSITRF;

        /// <summary>�������햼��3</summary>
        private string _dEPT03_MONEYKINDNAMERF = "";

        /// <summary>�������z3</summary>
        private Int64 _dEPT03_DEPOSITRF;

        /// <summary>�������햼��4</summary>
        private string _dEPT04_MONEYKINDNAMERF = "";

        /// <summary>�������z4</summary>
        private Int64 _dEPT04_DEPOSITRF;

        /// <summary>�������햼��5</summary>
        private string _dEPT05_MONEYKINDNAMERF = "";

        /// <summary>�������z5</summary>
        private Int64 _dEPT05_DEPOSITRF;

        /// <summary>�������햼��6</summary>
        private string _dEPT06_MONEYKINDNAMERF = "";

        /// <summary>�������z6</summary>
        private Int64 _dEPT06_DEPOSITRF;

        /// <summary>�������햼��7</summary>
        private string _dEPT07_MONEYKINDNAMERF = "";

        /// <summary>�������z7</summary>
        private Int64 _dEPT07_DEPOSITRF;

        /// <summary>�������햼��8</summary>
        private string _dEPT08_MONEYKINDNAMERF = "";

        /// <summary>�������z8</summary>
        private Int64 _dEPT08_DEPOSITRF;

        /// <summary>�������햼��9</summary>
        private string _dEPT09_MONEYKINDNAMERF = "";

        /// <summary>�������z9</summary>
        private Int64 _dEPT09_DEPOSITRF;

        /// <summary>�������햼��10</summary>
        private string _dEPT10_MONEYKINDNAMERF = "";

        /// <summary>�������z10</summary>
        private Int64 _dEPT10_DEPOSITRF;

        /// <summary>�v��N��������N</summary>
        private Int32 _hADD_ADDUPDATEFYRF;

        /// <summary>�v��N��������N��</summary>
        private Int32 _hADD_ADDUPDATEFSRF;

        /// <summary>�v��N�����a��N</summary>
        private Int32 _hADD_ADDUPDATEFWRF;

        /// <summary>�v��N������</summary>
        private Int32 _hADD_ADDUPDATEFMRF;

        /// <summary>�v��N������</summary>
        private Int32 _hADD_ADDUPDATEFDRF;

        /// <summary>�v��N��������</summary>
        private string _hADD_ADDUPDATEFGRF = "";

        /// <summary>�v��N��������</summary>
        private string _hADD_ADDUPDATEFRRF = "";

        /// <summary>�v��N�������e����(/)</summary>
        private string _hADD_ADDUPDATEFLSRF = "";

        /// <summary>�v��N�������e����(.)</summary>
        private string _hADD_ADDUPDATEFLPRF = "";

        /// <summary>�v��N�������e����(�N)</summary>
        private string _hADD_ADDUPDATEFLYRF = "";

        /// <summary>�v��N�������e����(��)</summary>
        private string _hADD_ADDUPDATEFLMRF = "";

        /// <summary>�v��N�������e����(��)</summary>
        private string _hADD_ADDUPDATEFLDRF = "";

        /// <summary>�v��N������N</summary>
        private Int32 _hADD_ADDUPYEARMONTHFYRF;

        /// <summary>�v��N������N��</summary>
        private Int32 _hADD_ADDUPYEARMONTHFSRF;

        /// <summary>�v��N���a��N</summary>
        private Int32 _hADD_ADDUPYEARMONTHFWRF;

        /// <summary>�v��N����</summary>
        private Int32 _hADD_ADDUPYEARMONTHFMRF;

        /// <summary>�v��N������</summary>
        private string _hADD_ADDUPYEARMONTHFGRF = "";

        /// <summary>�v��N������</summary>
        private string _hADD_ADDUPYEARMONTHFRRF = "";

        /// <summary>�v��N�����e����(/)</summary>
        private string _hADD_ADDUPYEARMONTHFLSRF = "";

        /// <summary>�v��N�����e����(.)</summary>
        private string _hADD_ADDUPYEARMONTHFLPRF = "";

        /// <summary>�v��N�����e����(�N)</summary>
        private string _hADD_ADDUPYEARMONTHFLYRF = "";

        /// <summary>�v��N�����e����(��)</summary>
        private string _hADD_ADDUPYEARMONTHFLMRF = "";

        /// <summary>�����X�V�J�n�N��������N</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFYRF;

        /// <summary>�����X�V�J�n�N��������N��</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFSRF;

        /// <summary>�����X�V�J�n�N�����a��N</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFWRF;

        /// <summary>�����X�V�J�n�N������</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFMRF;

        /// <summary>�����X�V�J�n�N������</summary>
        private Int32 _hADD_STARTCADDUPUPDDATEFDRF;

        /// <summary>�����X�V�J�n�N��������</summary>
        private string _hADD_STARTCADDUPUPDDATEFGRF = "";

        /// <summary>�����X�V�J�n�N��������</summary>
        private string _hADD_STARTCADDUPUPDDATEFRRF = "";

        /// <summary>�����X�V�J�n�N�������e����(/)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLSRF = "";

        /// <summary>�����X�V�J�n�N�������e����(.)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLPRF = "";

        /// <summary>�����X�V�J�n�N�������e����(�N)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLYRF = "";

        /// <summary>�����X�V�J�n�N�������e����(��)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLMRF = "";

        /// <summary>�����X�V�J�n�N�������e����(��)</summary>
        private string _hADD_STARTCADDUPUPDDATEFLDRF = "";

        /// <summary>���������s������N</summary>
        private Int32 _hADD_BILLPRINTDATEFYRF;

        /// <summary>���������s������N��</summary>
        private Int32 _hADD_BILLPRINTDATEFSRF;

        /// <summary>���������s���a��N</summary>
        private Int32 _hADD_BILLPRINTDATEFWRF;

        /// <summary>���������s����</summary>
        private Int32 _hADD_BILLPRINTDATEFMRF;

        /// <summary>���������s����</summary>
        private Int32 _hADD_BILLPRINTDATEFDRF;

        /// <summary>���������s������</summary>
        private string _hADD_BILLPRINTDATEFGRF = "";

        /// <summary>���������s������</summary>
        private string _hADD_BILLPRINTDATEFRRF = "";

        /// <summary>���������s�����e����(/)</summary>
        private string _hADD_BILLPRINTDATEFLSRF = "";

        /// <summary>���������s�����e����(.)</summary>
        private string _hADD_BILLPRINTDATEFLPRF = "";

        /// <summary>���������s�����e����(�N)</summary>
        private string _hADD_BILLPRINTDATEFLYRF = "";

        /// <summary>���������s�����e����(��)</summary>
        private string _hADD_BILLPRINTDATEFLMRF = "";

        /// <summary>���������s�����e����(��)</summary>
        private string _hADD_BILLPRINTDATEFLDRF = "";

        /// <summary>�����\�������N</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFYRF;

        /// <summary>�����\�������N��</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFSRF;

        /// <summary>�����\����a��N</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFWRF;

        /// <summary>�����\�����</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFMRF;

        /// <summary>�����\�����</summary>
        private Int32 _hADD_EXPECTEDDEPOSITDATEFDRF;

        /// <summary>�����\�������</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFGRF = "";

        /// <summary>�����\�������</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFRRF = "";

        /// <summary>�����\������e����(/)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLSRF = "";

        /// <summary>�����\������e����(.)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLPRF = "";

        /// <summary>�����\������e����(�N)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLYRF = "";

        /// <summary>�����\������e����(��)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLMRF = "";

        /// <summary>�����\������e����(��)</summary>
        private string _hADD_EXPECTEDDEPOSITDATEFLDRF = "";

        /// <summary>�����������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private string _hADD_COLLECTCONDNMRF = "";

        /// <summary>�������^�C�g��</summary>
        private string _hADD_DMDFORMTITLERF = "";

        /// <summary>�������^�C�g���Q</summary>
        /// <remarks>�T��</remarks>
        private string _hADD_DMDFORMTITLE2RF = "";

        /// <summary>�������R�����g�P</summary>
        private string _hADD_DMDFORMCOMENT1RF = "";

        /// <summary>�������R�����g�Q</summary>
        private string _hADD_DMDFORMCOMENT2RF = "";

        /// <summary>�������R�����g�R</summary>
        private string _hADD_DMDFORMCOMENT3RF = "";

        /// <summary>�������z(�l������)</summary>
        /// <remarks>�Z�o�l�F����������z�i�ʏ�����j�|����l���z�i�ʏ�����j</remarks>
        private Int64 _hADD_DMDNRMLEXDISRF;

        /// <summary>�������z(�萔������)</summary>
        /// <remarks>�Z�o�l�F����������z�i�ʏ�����j�|����萔���z�i�ʏ�����j</remarks>
        private Int64 _hADD_DMDNRMLEXFEERF;

        /// <summary>�������z(�l���E�萔������)</summary>
        /// <remarks>�Z�o�l�F����������z�i�ʏ�����j�|����l���z�i�ʏ�����j�|����萔���z�i�ʏ�����j</remarks>
        private Int64 _hADD_DMDNRMLEXDISFEERF;

        /// <summary>�������z(�l���{�萔��)</summary>
        /// <remarks>�Z�o�l�F����l���z�i�ʏ�����j�{����萔���z�i�ʏ�����j</remarks>
        private Int64 _hADD_DMDNRMLSAMDISFEERF;

        /// <summary>���񔄏�z(�Ŕ�)</summary>
        /// <remarks>�Z�o�l�F���񔄏�z(�Ŕ�)�{�c�������z</remarks>
        private Int64 _hADD_THISSALESANDADJUSTRF;

        /// <summary>���񔄏�����</summary>
        /// <remarks>�Z�o�l�F���񔄏����Ł{����Œ����z</remarks>
        private Int64 _hADD_THISTAXANDADJUSTRF;

        /// <summary>���͔��s���t</summary>
        private Int32 _hADD_ISSUEDAYRF;

        /// <summary>���͔��s���t����N</summary>
        private Int32 _hADD_ISSUEDAYFYRF;

        /// <summary>���͔��s���t����N��</summary>
        private Int32 _hADD_ISSUEDAYFSRF;

        /// <summary>���͔��s���t�a��N</summary>
        private Int32 _hADD_ISSUEDAYFWRF;

        /// <summary>���͔��s���t��</summary>
        private Int32 _hADD_ISSUEDAYFMRF;

        /// <summary>���͔��s���t��</summary>
        private Int32 _hADD_ISSUEDAYFDRF;

        /// <summary>���͔��s���t����</summary>
        private string _hADD_ISSUEDAYFGRF = "";

        /// <summary>���͔��s���t����</summary>
        private string _hADD_ISSUEDAYFRRF = "";

        /// <summary>���͔��s���t���e����(/)</summary>
        private string _hADD_ISSUEDAYFLSRF = "";

        /// <summary>���͔��s���t���e����(.)</summary>
        private string _hADD_ISSUEDAYFLPRF = "";

        /// <summary>���͔��s���t���e����(�N)</summary>
        private string _hADD_ISSUEDAYFLYRF = "";

        /// <summary>���͔��s���t���e����(��)</summary>
        private string _hADD_ISSUEDAYFLMRF = "";

        /// <summary>���͔��s���t���e����(��)</summary>
        private string _hADD_ISSUEDAYFLDRF = "";

        /// <summary>������Ӑ�T�u�R�[�h</summary>
        private string _cADD_CUSTOMERSUBCODERF = "";

        /// <summary>������Ӑ於��</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_NAMERF = "";

        /// <summary>������Ӑ於��2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_NAME2RF = "";

        /// <summary>������Ӑ�h��</summary>
        private string _cADD_HONORIFICTITLERF = "";

        /// <summary>������Ӑ�J�i</summary>
        private string _cADD_KANARF = "";

        /// <summary>������Ӑ旪��</summary>
        private string _cADD_CUSTOMERSNMRF = "";

        /// <summary>������Ӑ揔���R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _cADD_OUTPUTNAMECODERF;

        /// <summary>������Ӑ�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_POSTNORF = "";

        /// <summary>������Ӑ�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_ADDRESS1RF = "";

        /// <summary>������Ӑ�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_ADDRESS3RF = "";

        /// <summary>������Ӑ�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_ADDRESS4RF = "";

        /// <summary>������Ӑ敪�̓R�[�h1</summary>
        private Int32 _cADD_CUSTANALYSCODE1RF;

        /// <summary>������Ӑ敪�̓R�[�h2</summary>
        private Int32 _cADD_CUSTANALYSCODE2RF;

        /// <summary>������Ӑ敪�̓R�[�h3</summary>
        private Int32 _cADD_CUSTANALYSCODE3RF;

        /// <summary>������Ӑ敪�̓R�[�h4</summary>
        private Int32 _cADD_CUSTANALYSCODE4RF;

        /// <summary>������Ӑ敪�̓R�[�h5</summary>
        private Int32 _cADD_CUSTANALYSCODE5RF;

        /// <summary>������Ӑ敪�̓R�[�h6</summary>
        private Int32 _cADD_CUSTANALYSCODE6RF;

        /// <summary>������Ӑ���l1</summary>
        private string _cADD_NOTE1RF = "";

        /// <summary>������Ӑ���l2</summary>
        private string _cADD_NOTE2RF = "";

        /// <summary>������Ӑ���l3</summary>
        private string _cADD_NOTE3RF = "";

        /// <summary>������Ӑ���l4</summary>
        private string _cADD_NOTE4RF = "";

        /// <summary>������Ӑ���l5</summary>
        private string _cADD_NOTE5RF = "";

        /// <summary>������Ӑ���l6</summary>
        private string _cADD_NOTE6RF = "";

        /// <summary>������Ӑ���l7</summary>
        private string _cADD_NOTE7RF = "";

        /// <summary>������Ӑ���l8</summary>
        private string _cADD_NOTE8RF = "";

        /// <summary>������Ӑ���l9</summary>
        private string _cADD_NOTE9RF = "";

        /// <summary>������Ӑ���l10</summary>
        private string _cADD_NOTE10RF = "";

        /// <summary>����p���Ӑ於�́i��i�j</summary>
        private string _cADD_PRINTCUSTOMERNAME1RF = "";

        /// <summary>����p���Ӑ於�́i���i�j</summary>
        private string _cADD_PRINTCUSTOMERNAME2RF = "";

        /// <summary>����p���Ӑ於�́i���i�j�{�h��</summary>
        private string _cADD_PRINTCUSTOMERNAME2HNRF = "";

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _cSTCST_COLLECTMONEYNAMERF = "";

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _cSTCST_COLLECTMONEYDAYRF;

        /// <summary>������Ӑ�R�[�h</summary>
        private Int32 _cADD_CUSTOMERCODERF;

        /// <summary>������Ӑ�d�b�ԍ��i����j</summary>
        private string _cADD_HOMETELNORF = "";

        /// <summary>������Ӑ�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_OFFICETELNORF = "";

        /// <summary>������Ӑ�d�b�ԍ��i�g�сj</summary>
        private string _cADD_PORTABLETELNORF = "";

        /// <summary>������Ӑ�FAX�ԍ��i����j</summary>
        private string _cADD_HOMEFAXNORF = "";

        /// <summary>������Ӑ�FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cADD_OFFICEFAXNORF = "";

        /// <summary>������Ӑ�d�b�ԍ��i���̑��j</summary>
        private string _cADD_OTHERSTELNORF = "";

        /// <summary>���Ӑ�d�b�ԍ��i����j</summary>
        private string _cSTCST_HOMETELNORF = "";

        /// <summary>���Ӑ�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_OFFICETELNORF = "";

        /// <summary>���Ӑ�d�b�ԍ��i�g�сj</summary>
        private string _cSTCST_PORTABLETELNORF = "";

        /// <summary>���Ӑ�FAX�ԍ��i����j</summary>
        private string _cSTCST_HOMEFAXNORF = "";

        /// <summary>���Ӑ�FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_OFFICEFAXNORF = "";

        /// <summary>���Ӑ�d�b�ԍ��i���̑��j</summary>
        private string _cSTCST_OTHERSTELNORF = "";

        /// <summary>������d�b�ԍ��i����j</summary>
        private string _cSTCLM_HOMETELNORF = "";

        /// <summary>������d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_OFFICETELNORF = "";

        /// <summary>������d�b�ԍ��i�g�сj</summary>
        private string _cSTCLM_PORTABLETELNORF = "";

        /// <summary>������FAX�ԍ��i����j</summary>
        private string _cSTCLM_HOMEFAXNORF = "";

        /// <summary>������FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCLM_OFFICEFAXNORF = "";

        /// <summary>������d�b�ԍ��i���̑��j</summary>
        private string _cSTCLM_OTHERSTELNORF = "";

        /// <summary>���񔄏�z(�ō�)</summary>
        /// <remarks>�Z�o�l�F���񔄏�z(�Ŕ�)�{�c�������z�{���񔄏����Ł{����Œ����z</remarks>
        private Int64 _hADD_THISSALESANDADJUSTTAXINCRF;

        /// <summary>������W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _cSTCLM_COLLECTMONEYNAMERF = "";

        /// <summary>������W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _cSTCLM_COLLECTMONEYDAYRF;

        /// <summary>���ы��_�R�[�h</summary>
        /// <remarks>���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _cUSTDMDPRCRF_RESULTSSECTCDRF = "";

        /// <summary>���Ӑ於�P�{���Ӑ於�Q</summary>
        /// <remarks>���̂P�{���̂Q</remarks>
        private string _hADD_PRINTCUSTOMERNAMEJOIN12RF = "";

        /// <summary>���Ӑ於�P�{���Ӑ於�Q�{�h��</summary>
        /// <remarks>���̂P�{���̂Q�{�󔒁{�h��</remarks>
        private string _hADD_PRINTCUSTOMERNAMEJOIN12HNRF = "";

        /// <summary>���Ж��P�i�O���j</summary>
        private string _hADD_PRINTENTERPRISENAME1FHRF = "";

        /// <summary>���Ж��P�i�㔼�j</summary>
        private string _hADD_PRINTENTERPRISENAME1LHRF = "";

        /// <summary>���Ж��Q�i�O���j</summary>
        private string _hADD_PRINTENTERPRISENAME2FHRF = "";

        /// <summary>���Ж��Q�i�㔼�j</summary>
        private string _hADD_PRINTENTERPRISENAME2LHRF = "";

        /// <summary>����TEL�\������</summary>
        private string _aLITMDSPNMRF_HOMETELNODSPNAMERF = "";

        /// <summary>�Ζ���TEL�\������</summary>
        private string _aLITMDSPNMRF_OFFICETELNODSPNAMERF = "";

        /// <summary>�g��TEL�\������</summary>
        private string _aLITMDSPNMRF_MOBILETELNODSPNAMERF = "";

        /// <summary>����FAX�\������</summary>
        private string _aLITMDSPNMRF_HOMEFAXNODSPNAMERF = "";

        /// <summary>�Ζ���FAX�\������</summary>
        private string _aLITMDSPNMRF_OFFICEFAXNODSPNAMERF = "";

        /// <summary>���̑�TEL�\������</summary>
        private string _aLITMDSPNMRF_OTHERTELNODSPNAMERF = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _cSTCLM_SALESAREACODERF;

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _cSTCLM_CUSTOMERAGENTCDRF = "";

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _cSTCLM_BILLCOLLECTERCDRF = "";

        /// <summary>���ڋq�S���]�ƈ��R�[�h</summary>
        private string _cSTCLM_OLDCUSTOMERAGENTCDRF = "";

        /// <summary>�ڋq�S���ύX��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _cSTCLM_CUSTAGENTCHGDATERF;

        /// <summary>�������ԍ�</summary>
        private Int32 _cUSTDMDPRCRF_BILLNORF;

        /// <summary>�W�����敪�R�[�h</summary>
        private Int32 _cSTCST_COLLECTMONEYCODERF;

        /// <summary>������W�����敪�R�[�h</summary>
        private Int32 _cSTCLM_COLLECTMONEYCODERF;

        /// <summary>����</summary>
        private Int32 _cSTCLM_TOTALDAYRF;

        /// <summary>�ŗ�1�^�C�g��</summary>
        /// <remarks>�ŗ�1�^�C�g��</remarks>
        private Int32 _titleTaxRate1;

        /// <summary>�ŗ�2�^�C�g��</summary>
        /// <remarks>�ŗ�2�^�C�g��</remarks>
        private Int32 _titleTaxRate2;

        /// <summary>�ŗ�(1)�Ώۋ��z���v(�Ŕ���)</summary>
        /// <remarks>�ŗ�(1)�Ώۋ��z���v(�Ŕ���)</remarks>
        private double _totalThisTimeSalesTaxExRate1;

        /// <summary>�ŗ�(2)�Ώۋ��z���v(�Ŕ���)</summary>
        /// <remarks>�ŗ�(2)�Ώۋ��z���v(�Ŕ���)</remarks>
        private double _totalThisTimeSalesTaxExRate2;

        /// <summary>�Ŋz(1)</summary>
        /// <remarks>�Ŋz(1)</remarks>
        private double _totalThisTimeTaxRate1;

        /// <summary>�Ŋz(2)</summary>
        /// <remarks>�Ŋz(2)</remarks>
        private double _totalThisTimeTaxRate2;


        /// public propaty name  :  CUSTDMDPRCRF_ADDUPSECCODERF
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_ADDUPSECCODERF
        {
            get { return _cUSTDMDPRCRF_ADDUPSECCODERF; }
            set { _cUSTDMDPRCRF_ADDUPSECCODERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMCODERF
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_CLAIMCODERF
        {
            get { return _cUSTDMDPRCRF_CLAIMCODERF; }
            set { _cUSTDMDPRCRF_CLAIMCODERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMNAMERF
        /// <summary>�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CLAIMNAMERF
        {
            get { return _cUSTDMDPRCRF_CLAIMNAMERF; }
            set { _cUSTDMDPRCRF_CLAIMNAMERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMNAME2RF
        /// <summary>�����於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CLAIMNAME2RF
        {
            get { return _cUSTDMDPRCRF_CLAIMNAME2RF; }
            set { _cUSTDMDPRCRF_CLAIMNAME2RF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CLAIMSNMRF
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CLAIMSNMRF
        {
            get { return _cUSTDMDPRCRF_CLAIMSNMRF; }
            set { _cUSTDMDPRCRF_CLAIMSNMRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERCODERF
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_CUSTOMERCODERF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERCODERF; }
            set { _cUSTDMDPRCRF_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERNAMERF
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CUSTOMERNAMERF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERNAMERF; }
            set { _cUSTDMDPRCRF_CUSTOMERNAMERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERNAME2RF
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CUSTOMERNAME2RF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERNAME2RF; }
            set { _cUSTDMDPRCRF_CUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CUSTOMERSNMRF
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_CUSTOMERSNMRF
        {
            get { return _cUSTDMDPRCRF_CUSTOMERSNMRF; }
            set { _cUSTDMDPRCRF_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ADDUPDATERF
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_ADDUPDATERF
        {
            get { return _cUSTDMDPRCRF_ADDUPDATERF; }
            set { _cUSTDMDPRCRF_ADDUPDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ADDUPYEARMONTHRF
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_ADDUPYEARMONTHRF
        {
            get { return _cUSTDMDPRCRF_ADDUPYEARMONTHRF; }
            set { _cUSTDMDPRCRF_ADDUPYEARMONTHRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_LASTTIMEDEMANDRF
        /// <summary>�O�񐿋����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񐿋����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_LASTTIMEDEMANDRF
        {
            get { return _cUSTDMDPRCRF_LASTTIMEDEMANDRF; }
            set { _cUSTDMDPRCRF_LASTTIMEDEMANDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF
        /// <summary>����萔���z�i�ʏ�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����萔���z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF
        {
            get { return _cUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF; }
            set { _cUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF
        /// <summary>����l���z�i�ʏ�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF
        {
            get { return _cUSTDMDPRCRF_THISTIMEDISDMDNRMLRF; }
            set { _cUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMEDMDNRMLRF
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>�����z�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMEDMDNRMLRF
        {
            get { return _cUSTDMDPRCRF_THISTIMEDMDNRMLRF; }
            set { _cUSTDMDPRCRF_THISTIMEDMDNRMLRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMETTLBLCDMDRF
        /// <summary>����J�z�c���i�����v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMETTLBLCDMDRF
        {
            get { return _cUSTDMDPRCRF_THISTIMETTLBLCDMDRF; }
            set { _cUSTDMDPRCRF_THISTIMETTLBLCDMDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFSTHISTIMESALESRF
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFSTHISTIMESALESRF
        {
            get { return _cUSTDMDPRCRF_OFSTHISTIMESALESRF; }
            set { _cUSTDMDPRCRF_OFSTHISTIMESALESRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFSTHISSALESTAXRF
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFSTHISSALESTAXRF
        {
            get { return _cUSTDMDPRCRF_OFSTHISSALESTAXRF; }
            set { _cUSTDMDPRCRF_OFSTHISSALESTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF
        /// <summary>���E��O�őΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDOFFSETINTAXRF
        /// <summary>���E����őΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E����őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDOFFSETINTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDOFFSETINTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDOFFSETINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF
        /// <summary>���E���ېőΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F��ېŊz�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E���ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF
        {
            get { return _cUSTDMDPRCRF_ITDEDOFFSETTAXFREERF; }
            set { _cUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFFSETOUTTAXRF
        /// <summary>���E��O�ŏ���Ńv���p�e�B</summary>
        /// <value>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��O�ŏ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFFSETOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_OFFSETOUTTAXRF; }
            set { _cUSTDMDPRCRF_OFFSETOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_OFFSETINTAXRF
        /// <summary>���E����ŏ���Ńv���p�e�B</summary>
        /// <value>���E�p�F���ŏ���ł̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E����ŏ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_OFFSETINTAXRF
        {
            get { return _cUSTDMDPRCRF_OFFSETINTAXRF; }
            set { _cUSTDMDPRCRF_OFFSETINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISTIMESALESRF
        /// <summary>���񔄏���z�v���p�e�B</summary>
        /// <value>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISTIMESALESRF
        {
            get { return _cUSTDMDPRCRF_THISTIMESALESRF; }
            set { _cUSTDMDPRCRF_THISTIMESALESRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESTAXRF
        /// <summary>���񔄏����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESTAXRF
        {
            get { return _cUSTDMDPRCRF_THISSALESTAXRF; }
            set { _cUSTDMDPRCRF_THISSALESTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDSALESOUTTAXRF
        /// <summary>����O�őΏۊz�v���p�e�B</summary>
        /// <value>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDSALESOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDSALESOUTTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDSALESOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDSALESINTAXRF
        /// <summary>������őΏۊz�v���p�e�B</summary>
        /// <value>�����p�F���Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDSALESINTAXRF
        {
            get { return _cUSTDMDPRCRF_ITDEDSALESINTAXRF; }
            set { _cUSTDMDPRCRF_ITDEDSALESINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ITDEDSALESTAXFREERF
        /// <summary>�����ېőΏۊz�v���p�e�B</summary>
        /// <value>�����p�F��ېŊz�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ITDEDSALESTAXFREERF
        {
            get { return _cUSTDMDPRCRF_ITDEDSALESTAXFREERF; }
            set { _cUSTDMDPRCRF_ITDEDSALESTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_SALESOUTTAXRF
        /// <summary>����O�Ŋz�v���p�e�B</summary>
        /// <value>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_SALESOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_SALESOUTTAXRF; }
            set { _cUSTDMDPRCRF_SALESOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_SALESINTAXRF
        /// <summary>������Ŋz�v���p�e�B</summary>
        /// <value>�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_SALESINTAXRF
        {
            get { return _cUSTDMDPRCRF_SALESINTAXRF; }
            set { _cUSTDMDPRCRF_SALESINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRICRGDSRF
        /// <summary>���񔄏�ԕi���z�v���p�e�B</summary>
        /// <value>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRICRGDSRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRICRGDSRF; }
            set { _cUSTDMDPRCRF_THISSALESPRICRGDSRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF
        /// <summary>���񔄏�ԕi����Ńv���p�e�B</summary>
        /// <value>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRCTAXRGDSRF; }
            set { _cUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF
        /// <summary>�ԕi�O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDRETOUTTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDRETINTAXRF
        /// <summary>�ԕi���őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDRETINTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDRETINTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDRETINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDRETTAXFREERF
        /// <summary>�ԕi��ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi��ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDRETTAXFREERF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDRETTAXFREERF; }
            set { _cUSTDMDPRCRF_TTLITDEDRETTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLRETOUTERTAXRF
        /// <summary>�ԕi�O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLRETOUTERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLRETOUTERTAXRF; }
            set { _cUSTDMDPRCRF_TTLRETOUTERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLRETINNERTAXRF
        /// <summary>�ԕi���Ŋz���v�v���p�e�B</summary>
        /// <value>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLRETINNERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLRETINNERTAXRF; }
            set { _cUSTDMDPRCRF_TTLRETINNERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRICDISRF
        /// <summary>���񔄏�l�����z�v���p�e�B</summary>
        /// <value>�|���F�Ŕ����̔���l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRICDISRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRICDISRF; }
            set { _cUSTDMDPRCRF_THISSALESPRICDISRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_THISSALESPRCTAXDISRF
        /// <summary>���񔄏�l������Ńv���p�e�B</summary>
        /// <value>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_THISSALESPRCTAXDISRF
        {
            get { return _cUSTDMDPRCRF_THISSALESPRCTAXDISRF; }
            set { _cUSTDMDPRCRF_THISSALESPRCTAXDISRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF
        /// <summary>�l���O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDDISOUTTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDDISINTAXRF
        /// <summary>�l�����őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDDISINTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDDISINTAXRF; }
            set { _cUSTDMDPRCRF_TTLITDEDDISINTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLITDEDDISTAXFREERF
        /// <summary>�l����ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLITDEDDISTAXFREERF
        {
            get { return _cUSTDMDPRCRF_TTLITDEDDISTAXFREERF; }
            set { _cUSTDMDPRCRF_TTLITDEDDISTAXFREERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLDISOUTERTAXRF
        /// <summary>�l���O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLDISOUTERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLDISOUTERTAXRF; }
            set { _cUSTDMDPRCRF_TTLDISOUTERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TTLDISINNERTAXRF
        /// <summary>�l�����Ŋz���v�v���p�e�B</summary>
        /// <value>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TTLDISINNERTAXRF
        {
            get { return _cUSTDMDPRCRF_TTLDISINNERTAXRF; }
            set { _cUSTDMDPRCRF_TTLDISINNERTAXRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_TAXADJUSTRF
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_TAXADJUSTRF
        {
            get { return _cUSTDMDPRCRF_TAXADJUSTRF; }
            set { _cUSTDMDPRCRF_TAXADJUSTRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_BALANCEADJUSTRF
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_BALANCEADJUSTRF
        {
            get { return _cUSTDMDPRCRF_BALANCEADJUSTRF; }
            set { _cUSTDMDPRCRF_BALANCEADJUSTRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_AFCALDEMANDPRICERF
        /// <summary>�v�Z�㐿�����z�v���p�e�B</summary>
        /// <value>���񐿋����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�Z�㐿�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_AFCALDEMANDPRICERF
        {
            get { return _cUSTDMDPRCRF_AFCALDEMANDPRICERF; }
            set { _cUSTDMDPRCRF_AFCALDEMANDPRICERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
        /// <summary>��2��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��2��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
        {
            get { return _cUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF; }
            set { _cUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF
        /// <summary>��3��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��3��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF
        {
            get { return _cUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF; }
            set { _cUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_STARTCADDUPUPDDATERF
        /// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_STARTCADDUPUPDDATERF
        {
            get { return _cUSTDMDPRCRF_STARTCADDUPUPDDATERF; }
            set { _cUSTDMDPRCRF_STARTCADDUPUPDDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_SALESSLIPCOUNTRF
        /// <summary>����`�[�����v���p�e�B</summary>
        /// <value>�|���̓`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_SALESSLIPCOUNTRF
        {
            get { return _cUSTDMDPRCRF_SALESSLIPCOUNTRF; }
            set { _cUSTDMDPRCRF_SALESSLIPCOUNTRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_BILLPRINTDATERF
        /// <summary>���������s���v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �������𔭍s�����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_BILLPRINTDATERF
        {
            get { return _cUSTDMDPRCRF_BILLPRINTDATERF; }
            set { _cUSTDMDPRCRF_BILLPRINTDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF
        /// <summary>�����\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF
        {
            get { return _cUSTDMDPRCRF_EXPECTEDDEPOSITDATERF; }
            set { _cUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_COLLECTCONDRF
        /// <summary>��������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_COLLECTCONDRF
        {
            get { return _cUSTDMDPRCRF_COLLECTCONDRF; }
            set { _cUSTDMDPRCRF_COLLECTCONDRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CONSTAXLAYMETHODRF
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_CONSTAXLAYMETHODRF
        {
            get { return _cUSTDMDPRCRF_CONSTAXLAYMETHODRF; }
            set { _cUSTDMDPRCRF_CONSTAXLAYMETHODRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_CONSTAXRATERF
        /// <summary>����ŗ��v���p�e�B</summary>
        /// <value>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CUSTDMDPRCRF_CONSTAXRATERF
        {
            get { return _cUSTDMDPRCRF_CONSTAXRATERF; }
            set { _cUSTDMDPRCRF_CONSTAXRATERF = value; }
        }

        /// public propaty name  :  SECHED_SECTIONGUIDENMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SECHED_SECTIONGUIDENMRF
        {
            get { return _sECHED_SECTIONGUIDENMRF; }
            set { _sECHED_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SECHED_SECTIONGUIDESNMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SECHED_SECTIONGUIDESNMRF
        {
            get { return _sECHED_SECTIONGUIDESNMRF; }
            set { _sECHED_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SECHED_COMPANYNAMECD1RF
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SECHED_COMPANYNAMECD1RF
        {
            get { return _sECHED_COMPANYNAMECD1RF; }
            set { _sECHED_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYPRRF
        /// <summary>����PR���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYPRRF
        {
            get { return _cOMPANYNMRF_COMPANYPRRF; }
            set { _cOMPANYNMRF_COMPANYPRRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYNAME1RF
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYNAME1RF
        {
            get { return _cOMPANYNMRF_COMPANYNAME1RF; }
            set { _cOMPANYNMRF_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYNAME2RF
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYNAME2RF
        {
            get { return _cOMPANYNMRF_COMPANYNAME2RF; }
            set { _cOMPANYNMRF_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_POSTNORF
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_POSTNORF
        {
            get { return _cOMPANYNMRF_POSTNORF; }
            set { _cOMPANYNMRF_POSTNORF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS1RF
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS1RF
        {
            get { return _cOMPANYNMRF_ADDRESS1RF; }
            set { _cOMPANYNMRF_ADDRESS1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS3RF
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS3RF
        {
            get { return _cOMPANYNMRF_ADDRESS3RF; }
            set { _cOMPANYNMRF_ADDRESS3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ADDRESS4RF
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_ADDRESS4RF
        {
            get { return _cOMPANYNMRF_ADDRESS4RF; }
            set { _cOMPANYNMRF_ADDRESS4RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO1RF
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO1RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO1RF; }
            set { _cOMPANYNMRF_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO2RF
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO2RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO2RF; }
            set { _cOMPANYNMRF_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELNO3RF
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELNO3RF
        {
            get { return _cOMPANYNMRF_COMPANYTELNO3RF; }
            set { _cOMPANYNMRF_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE1RF
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE1RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE1RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE2RF
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE2RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE2RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYTELTITLE3RF
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYTELTITLE3RF
        {
            get { return _cOMPANYNMRF_COMPANYTELTITLE3RF; }
            set { _cOMPANYNMRF_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_TRANSFERGUIDANCERF
        /// <summary>��s�U���ē����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�U���ē����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_TRANSFERGUIDANCERF
        {
            get { return _cOMPANYNMRF_TRANSFERGUIDANCERF; }
            set { _cOMPANYNMRF_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO1RF
        /// <summary>��s����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO1RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO1RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO2RF
        /// <summary>��s����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO2RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO2RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_ACCOUNTNOINFO3RF
        /// <summary>��s����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_ACCOUNTNOINFO3RF
        {
            get { return _cOMPANYNMRF_ACCOUNTNOINFO3RF; }
            set { _cOMPANYNMRF_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYSETNOTE1RF
        /// <summary>���Аݒ�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYSETNOTE1RF
        {
            get { return _cOMPANYNMRF_COMPANYSETNOTE1RF; }
            set { _cOMPANYNMRF_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYSETNOTE2RF
        /// <summary>���Аݒ�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYSETNOTE2RF
        {
            get { return _cOMPANYNMRF_COMPANYSETNOTE2RF; }
            set { _cOMPANYNMRF_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGEINFOCODERF
        /// <summary>�摜���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 COMPANYNMRF_IMAGEINFOCODERF
        {
            get { return _cOMPANYNMRF_IMAGEINFOCODERF; }
            set { _cOMPANYNMRF_IMAGEINFOCODERF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYURLRF
        /// <summary>����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYURLRF
        {
            get { return _cOMPANYNMRF_COMPANYURLRF; }
            set { _cOMPANYNMRF_COMPANYURLRF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_COMPANYPRSENTENCE2RF
        /// <summary>����PR��2�v���p�e�B</summary>
        /// <value>��\����𓙂̏������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_COMPANYPRSENTENCE2RF
        {
            get { return _cOMPANYNMRF_COMPANYPRSENTENCE2RF; }
            set { _cOMPANYNMRF_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGECOMMENTFORPRT1RF
        /// <summary>�摜�󎚗p�R�����g1�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_IMAGECOMMENTFORPRT1RF
        {
            get { return _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF; }
            set { _cOMPANYNMRF_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  COMPANYNMRF_IMAGECOMMENTFORPRT2RF
        /// <summary>�摜�󎚗p�R�����g2�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYNMRF_IMAGECOMMENTFORPRT2RF
        {
            get { return _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF; }
            set { _cOMPANYNMRF_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  IMAGEINFORF_IMAGEINFODATARF
        /// <summary>�摜���f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] IMAGEINFORF_IMAGEINFODATARF
        {
            get { return _iMAGEINFORF_IMAGEINFODATARF; }
            set { _iMAGEINFORF_IMAGEINFODATARF = value; }
        }

        /// public propaty field.NameJp  :  IMAGEINFORF_IMAGEINFODATARFImageObject
        /// <summary>�摜���f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Image IMAGEINFORF_IMAGEINFODATARFImageObject
        {
            get
            {
                MemoryStream mem = new MemoryStream( _iMAGEINFORF_IMAGEINFODATARF );
                mem.Position = 0;
                return Image.FromStream( mem );
            }
            set
            {
                _iMAGEINFORF_IMAGEINFODATARF = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save( mem, System.Drawing.Imaging.ImageFormat.Bmp );
                _iMAGEINFORF_IMAGEINFODATARF = mem.ToArray();
            }
        }

        /// public propaty name  :  CSTCST_CUSTOMERSUBCODERF
        /// <summary>���Ӑ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_CUSTOMERSUBCODERF
        {
            get { return _cSTCST_CUSTOMERSUBCODERF; }
            set { _cSTCST_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CSTCST_NAMERF
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NAMERF
        {
            get { return _cSTCST_NAMERF; }
            set { _cSTCST_NAMERF = value; }
        }

        /// public propaty name  :  CSTCST_NAME2RF
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NAME2RF
        {
            get { return _cSTCST_NAME2RF; }
            set { _cSTCST_NAME2RF = value; }
        }

        /// public propaty name  :  CSTCST_HONORIFICTITLERF
        /// <summary>���Ӑ�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_HONORIFICTITLERF
        {
            get { return _cSTCST_HONORIFICTITLERF; }
            set { _cSTCST_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CSTCST_KANARF
        /// <summary>���Ӑ�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_KANARF
        {
            get { return _cSTCST_KANARF; }
            set { _cSTCST_KANARF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTOMERSNMRF
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_CUSTOMERSNMRF
        {
            get { return _cSTCST_CUSTOMERSNMRF; }
            set { _cSTCST_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CSTCST_OUTPUTNAMECODERF
        /// <summary>���Ӑ揔���R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ揔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_OUTPUTNAMECODERF
        {
            get { return _cSTCST_OUTPUTNAMECODERF; }
            set { _cSTCST_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CSTCST_POSTNORF
        /// <summary>���Ӑ�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_POSTNORF
        {
            get { return _cSTCST_POSTNORF; }
            set { _cSTCST_POSTNORF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS1RF
        /// <summary>���Ӑ�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_ADDRESS1RF
        {
            get { return _cSTCST_ADDRESS1RF; }
            set { _cSTCST_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS3RF
        /// <summary>���Ӑ�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_ADDRESS3RF
        {
            get { return _cSTCST_ADDRESS3RF; }
            set { _cSTCST_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS4RF
        /// <summary>���Ӑ�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_ADDRESS4RF
        {
            get { return _cSTCST_ADDRESS4RF; }
            set { _cSTCST_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE1RF
        /// <summary>���Ӑ敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE1RF
        {
            get { return _cSTCST_CUSTANALYSCODE1RF; }
            set { _cSTCST_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE2RF
        /// <summary>���Ӑ敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE2RF
        {
            get { return _cSTCST_CUSTANALYSCODE2RF; }
            set { _cSTCST_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE3RF
        /// <summary>���Ӑ敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE3RF
        {
            get { return _cSTCST_CUSTANALYSCODE3RF; }
            set { _cSTCST_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE4RF
        /// <summary>���Ӑ敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE4RF
        {
            get { return _cSTCST_CUSTANALYSCODE4RF; }
            set { _cSTCST_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE5RF
        /// <summary>���Ӑ敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE5RF
        {
            get { return _cSTCST_CUSTANALYSCODE5RF; }
            set { _cSTCST_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CSTCST_CUSTANALYSCODE6RF
        /// <summary>���Ӑ敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_CUSTANALYSCODE6RF
        {
            get { return _cSTCST_CUSTANALYSCODE6RF; }
            set { _cSTCST_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE1RF
        /// <summary>���Ӑ���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE1RF
        {
            get { return _cSTCST_NOTE1RF; }
            set { _cSTCST_NOTE1RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE2RF
        /// <summary>���Ӑ���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE2RF
        {
            get { return _cSTCST_NOTE2RF; }
            set { _cSTCST_NOTE2RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE3RF
        /// <summary>���Ӑ���l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE3RF
        {
            get { return _cSTCST_NOTE3RF; }
            set { _cSTCST_NOTE3RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE4RF
        /// <summary>���Ӑ���l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE4RF
        {
            get { return _cSTCST_NOTE4RF; }
            set { _cSTCST_NOTE4RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE5RF
        /// <summary>���Ӑ���l5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE5RF
        {
            get { return _cSTCST_NOTE5RF; }
            set { _cSTCST_NOTE5RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE6RF
        /// <summary>���Ӑ���l6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE6RF
        {
            get { return _cSTCST_NOTE6RF; }
            set { _cSTCST_NOTE6RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE7RF
        /// <summary>���Ӑ���l7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE7RF
        {
            get { return _cSTCST_NOTE7RF; }
            set { _cSTCST_NOTE7RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE8RF
        /// <summary>���Ӑ���l8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE8RF
        {
            get { return _cSTCST_NOTE8RF; }
            set { _cSTCST_NOTE8RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE9RF
        /// <summary>���Ӑ���l9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE9RF
        {
            get { return _cSTCST_NOTE9RF; }
            set { _cSTCST_NOTE9RF = value; }
        }

        /// public propaty name  :  CSTCST_NOTE10RF
        /// <summary>���Ӑ���l10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ���l10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_NOTE10RF
        {
            get { return _cSTCST_NOTE10RF; }
            set { _cSTCST_NOTE10RF = value; }
        }

        // --- ADD START �c������ 2022/10/18 ----->>>>>
        /// public propaty name  :  CSTCLM_SALESCNSTAXFRCPROCCDRF
        /// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_SALESCNSTAXFRCPROCCDRF
        {
            get { return _cSTCLM_SALESCNSTAXFRCPROCCDRF; }
            set { _cSTCLM_SALESCNSTAXFRCPROCCDRF = value; }
        }
        // --- ADD END �c������ 2022/10/18 -----<<<<<
        /// public propaty name  :  CSTCLM_CUSTOMERSUBCODERF
        /// <summary>������T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_CUSTOMERSUBCODERF
        {
            get { return _cSTCLM_CUSTOMERSUBCODERF; }
            set { _cSTCLM_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CSTCLM_NAMERF
        /// <summary>�����於�̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NAMERF
        {
            get { return _cSTCLM_NAMERF; }
            set { _cSTCLM_NAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_NAME2RF
        /// <summary>�����於��2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NAME2RF
        {
            get { return _cSTCLM_NAME2RF; }
            set { _cSTCLM_NAME2RF = value; }
        }

        /// public propaty name  :  CSTCLM_HONORIFICTITLERF
        /// <summary>������h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_HONORIFICTITLERF
        {
            get { return _cSTCLM_HONORIFICTITLERF; }
            set { _cSTCLM_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CSTCLM_KANARF
        /// <summary>������J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_KANARF
        {
            get { return _cSTCLM_KANARF; }
            set { _cSTCLM_KANARF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTOMERSNMRF
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_CUSTOMERSNMRF
        {
            get { return _cSTCLM_CUSTOMERSNMRF; }
            set { _cSTCLM_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CSTCLM_OUTPUTNAMECODERF
        /// <summary>�����揔���R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����揔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_OUTPUTNAMECODERF
        {
            get { return _cSTCLM_OUTPUTNAMECODERF; }
            set { _cSTCLM_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CSTCLM_POSTNORF
        /// <summary>������X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_POSTNORF
        {
            get { return _cSTCLM_POSTNORF; }
            set { _cSTCLM_POSTNORF = value; }
        }

        /// public propaty name  :  CSTCLM_ADDRESS1RF
        /// <summary>������Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_ADDRESS1RF
        {
            get { return _cSTCLM_ADDRESS1RF; }
            set { _cSTCLM_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CSTCLM_ADDRESS3RF
        /// <summary>������Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_ADDRESS3RF
        {
            get { return _cSTCLM_ADDRESS3RF; }
            set { _cSTCLM_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CSTCLM_ADDRESS4RF
        /// <summary>������Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_ADDRESS4RF
        {
            get { return _cSTCLM_ADDRESS4RF; }
            set { _cSTCLM_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE1RF
        /// <summary>�����敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE1RF
        {
            get { return _cSTCLM_CUSTANALYSCODE1RF; }
            set { _cSTCLM_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE2RF
        /// <summary>�����敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE2RF
        {
            get { return _cSTCLM_CUSTANALYSCODE2RF; }
            set { _cSTCLM_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE3RF
        /// <summary>�����敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE3RF
        {
            get { return _cSTCLM_CUSTANALYSCODE3RF; }
            set { _cSTCLM_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE4RF
        /// <summary>�����敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE4RF
        {
            get { return _cSTCLM_CUSTANALYSCODE4RF; }
            set { _cSTCLM_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE5RF
        /// <summary>�����敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE5RF
        {
            get { return _cSTCLM_CUSTANALYSCODE5RF; }
            set { _cSTCLM_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTANALYSCODE6RF
        /// <summary>�����敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTANALYSCODE6RF
        {
            get { return _cSTCLM_CUSTANALYSCODE6RF; }
            set { _cSTCLM_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE1RF
        /// <summary>��������l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE1RF
        {
            get { return _cSTCLM_NOTE1RF; }
            set { _cSTCLM_NOTE1RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE2RF
        /// <summary>��������l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE2RF
        {
            get { return _cSTCLM_NOTE2RF; }
            set { _cSTCLM_NOTE2RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE3RF
        /// <summary>��������l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE3RF
        {
            get { return _cSTCLM_NOTE3RF; }
            set { _cSTCLM_NOTE3RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE4RF
        /// <summary>��������l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE4RF
        {
            get { return _cSTCLM_NOTE4RF; }
            set { _cSTCLM_NOTE4RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE5RF
        /// <summary>��������l5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE5RF
        {
            get { return _cSTCLM_NOTE5RF; }
            set { _cSTCLM_NOTE5RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE6RF
        /// <summary>��������l6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE6RF
        {
            get { return _cSTCLM_NOTE6RF; }
            set { _cSTCLM_NOTE6RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE7RF
        /// <summary>��������l7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE7RF
        {
            get { return _cSTCLM_NOTE7RF; }
            set { _cSTCLM_NOTE7RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE8RF
        /// <summary>��������l8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE8RF
        {
            get { return _cSTCLM_NOTE8RF; }
            set { _cSTCLM_NOTE8RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE9RF
        /// <summary>��������l9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE9RF
        {
            get { return _cSTCLM_NOTE9RF; }
            set { _cSTCLM_NOTE9RF = value; }
        }

        /// public propaty name  :  CSTCLM_NOTE10RF
        /// <summary>��������l10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_NOTE10RF
        {
            get { return _cSTCLM_NOTE10RF; }
            set { _cSTCLM_NOTE10RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYNAME1RF
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYNAME1RF
        {
            get { return _cOMPANYINFRF_COMPANYNAME1RF; }
            set { _cOMPANYINFRF_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYNAME2RF
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYNAME2RF
        {
            get { return _cOMPANYINFRF_COMPANYNAME2RF; }
            set { _cOMPANYINFRF_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_POSTNORF
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_POSTNORF
        {
            get { return _cOMPANYINFRF_POSTNORF; }
            set { _cOMPANYINFRF_POSTNORF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS1RF
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS1RF
        {
            get { return _cOMPANYINFRF_ADDRESS1RF; }
            set { _cOMPANYINFRF_ADDRESS1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS3RF
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS3RF
        {
            get { return _cOMPANYINFRF_ADDRESS3RF; }
            set { _cOMPANYINFRF_ADDRESS3RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS4RF
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS4RF
        {
            get { return _cOMPANYINFRF_ADDRESS4RF; }
            set { _cOMPANYINFRF_ADDRESS4RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO1RF
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO1RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO1RF; }
            set { _cOMPANYINFRF_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO2RF
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO2RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO2RF; }
            set { _cOMPANYINFRF_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO3RF
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO3RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO3RF; }
            set { _cOMPANYINFRF_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE1RF
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE1RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE1RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE2RF
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE2RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE2RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE3RF
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE3RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE3RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD1RF
        /// <summary>�����ݒ����R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD1RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD1RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD1RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD2RF
        /// <summary>�����ݒ����R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD2RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD2RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD2RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD3RF
        /// <summary>�����ݒ����R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD3RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD3RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD3RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD4RF
        /// <summary>�����ݒ����R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD4RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD4RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD4RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD5RF
        /// <summary>�����ݒ����R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD5RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD5RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD5RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD6RF
        /// <summary>�����ݒ����R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD6RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD6RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD6RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD7RF
        /// <summary>�����ݒ����R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD7RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD7RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD7RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD8RF
        /// <summary>�����ݒ����R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD8RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD8RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD8RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD9RF
        /// <summary>�����ݒ����R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD9RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD9RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD9RF = value; }
        }

        /// public propaty name  :  DEPOSITSTRF_DEPOSITSTKINDCD10RF
        /// <summary>�����ݒ����R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DEPOSITSTRF_DEPOSITSTKINDCD10RF
        {
            get { return _dEPOSITSTRF_DEPOSITSTKINDCD10RF; }
            set { _dEPOSITSTRF_DEPOSITSTKINDCD10RF = value; }
        }

        /// public propaty name  :  DEPT01_MONEYKINDNAMERF
        /// <summary>�������햼��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT01_MONEYKINDNAMERF
        {
            get { return _dEPT01_MONEYKINDNAMERF; }
            set { _dEPT01_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT01_DEPOSITRF
        /// <summary>�������z1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT01_DEPOSITRF
        {
            get { return _dEPT01_DEPOSITRF; }
            set { _dEPT01_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT02_MONEYKINDNAMERF
        /// <summary>�������햼��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT02_MONEYKINDNAMERF
        {
            get { return _dEPT02_MONEYKINDNAMERF; }
            set { _dEPT02_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT02_DEPOSITRF
        /// <summary>�������z2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT02_DEPOSITRF
        {
            get { return _dEPT02_DEPOSITRF; }
            set { _dEPT02_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT03_MONEYKINDNAMERF
        /// <summary>�������햼��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT03_MONEYKINDNAMERF
        {
            get { return _dEPT03_MONEYKINDNAMERF; }
            set { _dEPT03_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT03_DEPOSITRF
        /// <summary>�������z3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT03_DEPOSITRF
        {
            get { return _dEPT03_DEPOSITRF; }
            set { _dEPT03_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT04_MONEYKINDNAMERF
        /// <summary>�������햼��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT04_MONEYKINDNAMERF
        {
            get { return _dEPT04_MONEYKINDNAMERF; }
            set { _dEPT04_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT04_DEPOSITRF
        /// <summary>�������z4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT04_DEPOSITRF
        {
            get { return _dEPT04_DEPOSITRF; }
            set { _dEPT04_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT05_MONEYKINDNAMERF
        /// <summary>�������햼��5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT05_MONEYKINDNAMERF
        {
            get { return _dEPT05_MONEYKINDNAMERF; }
            set { _dEPT05_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT05_DEPOSITRF
        /// <summary>�������z5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT05_DEPOSITRF
        {
            get { return _dEPT05_DEPOSITRF; }
            set { _dEPT05_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT06_MONEYKINDNAMERF
        /// <summary>�������햼��6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT06_MONEYKINDNAMERF
        {
            get { return _dEPT06_MONEYKINDNAMERF; }
            set { _dEPT06_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT06_DEPOSITRF
        /// <summary>�������z6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT06_DEPOSITRF
        {
            get { return _dEPT06_DEPOSITRF; }
            set { _dEPT06_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT07_MONEYKINDNAMERF
        /// <summary>�������햼��7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT07_MONEYKINDNAMERF
        {
            get { return _dEPT07_MONEYKINDNAMERF; }
            set { _dEPT07_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT07_DEPOSITRF
        /// <summary>�������z7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT07_DEPOSITRF
        {
            get { return _dEPT07_DEPOSITRF; }
            set { _dEPT07_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT08_MONEYKINDNAMERF
        /// <summary>�������햼��8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT08_MONEYKINDNAMERF
        {
            get { return _dEPT08_MONEYKINDNAMERF; }
            set { _dEPT08_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT08_DEPOSITRF
        /// <summary>�������z8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT08_DEPOSITRF
        {
            get { return _dEPT08_DEPOSITRF; }
            set { _dEPT08_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT09_MONEYKINDNAMERF
        /// <summary>�������햼��9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT09_MONEYKINDNAMERF
        {
            get { return _dEPT09_MONEYKINDNAMERF; }
            set { _dEPT09_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT09_DEPOSITRF
        /// <summary>�������z9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT09_DEPOSITRF
        {
            get { return _dEPT09_DEPOSITRF; }
            set { _dEPT09_DEPOSITRF = value; }
        }

        /// public propaty name  :  DEPT10_MONEYKINDNAMERF
        /// <summary>�������햼��10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼��10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DEPT10_MONEYKINDNAMERF
        {
            get { return _dEPT10_MONEYKINDNAMERF; }
            set { _dEPT10_MONEYKINDNAMERF = value; }
        }

        /// public propaty name  :  DEPT10_DEPOSITRF
        /// <summary>�������z10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DEPT10_DEPOSITRF
        {
            get { return _dEPT10_DEPOSITRF; }
            set { _dEPT10_DEPOSITRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFYRF
        /// <summary>�v��N��������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N��������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFYRF
        {
            get { return _hADD_ADDUPDATEFYRF; }
            set { _hADD_ADDUPDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFSRF
        /// <summary>�v��N��������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N��������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFSRF
        {
            get { return _hADD_ADDUPDATEFSRF; }
            set { _hADD_ADDUPDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFWRF
        /// <summary>�v��N�����a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFWRF
        {
            get { return _hADD_ADDUPDATEFWRF; }
            set { _hADD_ADDUPDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFMRF
        /// <summary>�v��N�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFMRF
        {
            get { return _hADD_ADDUPDATEFMRF; }
            set { _hADD_ADDUPDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFDRF
        /// <summary>�v��N�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPDATEFDRF
        {
            get { return _hADD_ADDUPDATEFDRF; }
            set { _hADD_ADDUPDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFGRF
        /// <summary>�v��N���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFGRF
        {
            get { return _hADD_ADDUPDATEFGRF; }
            set { _hADD_ADDUPDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFRRF
        /// <summary>�v��N���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFRRF
        {
            get { return _hADD_ADDUPDATEFRRF; }
            set { _hADD_ADDUPDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLSRF
        /// <summary>�v��N�������e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLSRF
        {
            get { return _hADD_ADDUPDATEFLSRF; }
            set { _hADD_ADDUPDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLPRF
        /// <summary>�v��N�������e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLPRF
        {
            get { return _hADD_ADDUPDATEFLPRF; }
            set { _hADD_ADDUPDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLYRF
        /// <summary>�v��N�������e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLYRF
        {
            get { return _hADD_ADDUPDATEFLYRF; }
            set { _hADD_ADDUPDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLMRF
        /// <summary>�v��N�������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLMRF
        {
            get { return _hADD_ADDUPDATEFLMRF; }
            set { _hADD_ADDUPDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPDATEFLDRF
        /// <summary>�v��N�������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPDATEFLDRF
        {
            get { return _hADD_ADDUPDATEFLDRF; }
            set { _hADD_ADDUPDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFYRF
        /// <summary>�v��N������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFYRF
        {
            get { return _hADD_ADDUPYEARMONTHFYRF; }
            set { _hADD_ADDUPYEARMONTHFYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFSRF
        /// <summary>�v��N������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFSRF
        {
            get { return _hADD_ADDUPYEARMONTHFSRF; }
            set { _hADD_ADDUPYEARMONTHFSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFWRF
        /// <summary>�v��N���a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFWRF
        {
            get { return _hADD_ADDUPYEARMONTHFWRF; }
            set { _hADD_ADDUPYEARMONTHFWRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFMRF
        /// <summary>�v��N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPYEARMONTHFMRF
        {
            get { return _hADD_ADDUPYEARMONTHFMRF; }
            set { _hADD_ADDUPYEARMONTHFMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFGRF
        /// <summary>�v��N�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFGRF
        {
            get { return _hADD_ADDUPYEARMONTHFGRF; }
            set { _hADD_ADDUPYEARMONTHFGRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFRRF
        /// <summary>�v��N�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFRRF
        {
            get { return _hADD_ADDUPYEARMONTHFRRF; }
            set { _hADD_ADDUPYEARMONTHFRRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLSRF
        /// <summary>�v��N�����e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLSRF
        {
            get { return _hADD_ADDUPYEARMONTHFLSRF; }
            set { _hADD_ADDUPYEARMONTHFLSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLPRF
        /// <summary>�v��N�����e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLPRF
        {
            get { return _hADD_ADDUPYEARMONTHFLPRF; }
            set { _hADD_ADDUPYEARMONTHFLPRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLYRF
        /// <summary>�v��N�����e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLYRF
        {
            get { return _hADD_ADDUPYEARMONTHFLYRF; }
            set { _hADD_ADDUPYEARMONTHFLYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPYEARMONTHFLMRF
        /// <summary>�v��N�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPYEARMONTHFLMRF
        {
            get { return _hADD_ADDUPYEARMONTHFLMRF; }
            set { _hADD_ADDUPYEARMONTHFLMRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFYRF
        /// <summary>�����X�V�J�n�N��������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N��������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFYRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFYRF; }
            set { _hADD_STARTCADDUPUPDDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFSRF
        /// <summary>�����X�V�J�n�N��������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N��������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFSRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFSRF; }
            set { _hADD_STARTCADDUPUPDDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFWRF
        /// <summary>�����X�V�J�n�N�����a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFWRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFWRF; }
            set { _hADD_STARTCADDUPUPDDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFMRF
        /// <summary>�����X�V�J�n�N�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFMRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFMRF; }
            set { _hADD_STARTCADDUPUPDDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFDRF
        /// <summary>�����X�V�J�n�N�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_STARTCADDUPUPDDATEFDRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFDRF; }
            set { _hADD_STARTCADDUPUPDDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFGRF
        /// <summary>�����X�V�J�n�N���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFGRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFGRF; }
            set { _hADD_STARTCADDUPUPDDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFRRF
        /// <summary>�����X�V�J�n�N���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFRRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFRRF; }
            set { _hADD_STARTCADDUPUPDDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLSRF
        /// <summary>�����X�V�J�n�N�������e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLSRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLSRF; }
            set { _hADD_STARTCADDUPUPDDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLPRF
        /// <summary>�����X�V�J�n�N�������e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLPRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLPRF; }
            set { _hADD_STARTCADDUPUPDDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLYRF
        /// <summary>�����X�V�J�n�N�������e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLYRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLYRF; }
            set { _hADD_STARTCADDUPUPDDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLMRF
        /// <summary>�����X�V�J�n�N�������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLMRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLMRF; }
            set { _hADD_STARTCADDUPUPDDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_STARTCADDUPUPDDATEFLDRF
        /// <summary>�����X�V�J�n�N�������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STARTCADDUPUPDDATEFLDRF
        {
            get { return _hADD_STARTCADDUPUPDDATEFLDRF; }
            set { _hADD_STARTCADDUPUPDDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFYRF
        /// <summary>���������s������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFYRF
        {
            get { return _hADD_BILLPRINTDATEFYRF; }
            set { _hADD_BILLPRINTDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFSRF
        /// <summary>���������s������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFSRF
        {
            get { return _hADD_BILLPRINTDATEFSRF; }
            set { _hADD_BILLPRINTDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFWRF
        /// <summary>���������s���a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s���a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFWRF
        {
            get { return _hADD_BILLPRINTDATEFWRF; }
            set { _hADD_BILLPRINTDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFMRF
        /// <summary>���������s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFMRF
        {
            get { return _hADD_BILLPRINTDATEFMRF; }
            set { _hADD_BILLPRINTDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFDRF
        /// <summary>���������s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_BILLPRINTDATEFDRF
        {
            get { return _hADD_BILLPRINTDATEFDRF; }
            set { _hADD_BILLPRINTDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFGRF
        /// <summary>���������s�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFGRF
        {
            get { return _hADD_BILLPRINTDATEFGRF; }
            set { _hADD_BILLPRINTDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFRRF
        /// <summary>���������s�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFRRF
        {
            get { return _hADD_BILLPRINTDATEFRRF; }
            set { _hADD_BILLPRINTDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLSRF
        /// <summary>���������s�����e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLSRF
        {
            get { return _hADD_BILLPRINTDATEFLSRF; }
            set { _hADD_BILLPRINTDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLPRF
        /// <summary>���������s�����e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLPRF
        {
            get { return _hADD_BILLPRINTDATEFLPRF; }
            set { _hADD_BILLPRINTDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLYRF
        /// <summary>���������s�����e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLYRF
        {
            get { return _hADD_BILLPRINTDATEFLYRF; }
            set { _hADD_BILLPRINTDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLMRF
        /// <summary>���������s�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLMRF
        {
            get { return _hADD_BILLPRINTDATEFLMRF; }
            set { _hADD_BILLPRINTDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_BILLPRINTDATEFLDRF
        /// <summary>���������s�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_BILLPRINTDATEFLDRF
        {
            get { return _hADD_BILLPRINTDATEFLDRF; }
            set { _hADD_BILLPRINTDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFYRF
        /// <summary>�����\�������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFYRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFYRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFSRF
        /// <summary>�����\�������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFSRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFSRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFWRF
        /// <summary>�����\����a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\����a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFWRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFWRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFMRF
        /// <summary>�����\������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFMRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFMRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFDRF
        /// <summary>�����\������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_EXPECTEDDEPOSITDATEFDRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFDRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFGRF
        /// <summary>�����\��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFGRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFGRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFRRF
        /// <summary>�����\��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFRRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFRRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLSRF
        /// <summary>�����\������e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLSRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLSRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLPRF
        /// <summary>�����\������e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLPRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLPRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLYRF
        /// <summary>�����\������e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLYRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLYRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLMRF
        /// <summary>�����\������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLMRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLMRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_EXPECTEDDEPOSITDATEFLDRF
        /// <summary>�����\������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXPECTEDDEPOSITDATEFLDRF
        {
            get { return _hADD_EXPECTEDDEPOSITDATEFLDRF; }
            set { _hADD_EXPECTEDDEPOSITDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_COLLECTCONDNMRF
        /// <summary>����������̃v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_COLLECTCONDNMRF
        {
            get { return _hADD_COLLECTCONDNMRF; }
            set { _hADD_COLLECTCONDNMRF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMTITLERF
        /// <summary>�������^�C�g���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������^�C�g���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DMDFORMTITLERF
        {
            get { return _hADD_DMDFORMTITLERF; }
            set { _hADD_DMDFORMTITLERF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMTITLE2RF
        /// <summary>�������^�C�g���Q�v���p�e�B</summary>
        /// <value>�T��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������^�C�g���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DMDFORMTITLE2RF
        {
            get { return _hADD_DMDFORMTITLE2RF; }
            set { _hADD_DMDFORMTITLE2RF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMCOMENT1RF
        /// <summary>�������R�����g�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DMDFORMCOMENT1RF
        {
            get { return _hADD_DMDFORMCOMENT1RF; }
            set { _hADD_DMDFORMCOMENT1RF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMCOMENT2RF
        /// <summary>�������R�����g�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DMDFORMCOMENT2RF
        {
            get { return _hADD_DMDFORMCOMENT2RF; }
            set { _hADD_DMDFORMCOMENT2RF = value; }
        }

        /// public propaty name  :  HADD_DMDFORMCOMENT3RF
        /// <summary>�������R�����g�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DMDFORMCOMENT3RF
        {
            get { return _hADD_DMDFORMCOMENT3RF; }
            set { _hADD_DMDFORMCOMENT3RF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLEXDISRF
        /// <summary>�������z(�l������)�v���p�e�B</summary>
        /// <value>�Z�o�l�F����������z�i�ʏ�����j�|����l���z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z(�l������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLEXDISRF
        {
            get { return _hADD_DMDNRMLEXDISRF; }
            set { _hADD_DMDNRMLEXDISRF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLEXFEERF
        /// <summary>�������z(�萔������)�v���p�e�B</summary>
        /// <value>�Z�o�l�F����������z�i�ʏ�����j�|����萔���z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z(�萔������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLEXFEERF
        {
            get { return _hADD_DMDNRMLEXFEERF; }
            set { _hADD_DMDNRMLEXFEERF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLEXDISFEERF
        /// <summary>�������z(�l���E�萔������)�v���p�e�B</summary>
        /// <value>�Z�o�l�F����������z�i�ʏ�����j�|����l���z�i�ʏ�����j�|����萔���z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z(�l���E�萔������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLEXDISFEERF
        {
            get { return _hADD_DMDNRMLEXDISFEERF; }
            set { _hADD_DMDNRMLEXDISFEERF = value; }
        }

        /// public propaty name  :  HADD_DMDNRMLSAMDISFEERF
        /// <summary>�������z(�l���{�萔��)�v���p�e�B</summary>
        /// <value>�Z�o�l�F����l���z�i�ʏ�����j�{����萔���z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z(�l���{�萔��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_DMDNRMLSAMDISFEERF
        {
            get { return _hADD_DMDNRMLSAMDISFEERF; }
            set { _hADD_DMDNRMLSAMDISFEERF = value; }
        }

        /// public propaty name  :  HADD_THISSALESANDADJUSTRF
        /// <summary>���񔄏�z(�Ŕ�)�v���p�e�B</summary>
        /// <value>�Z�o�l�F���񔄏�z(�Ŕ�)�{�c�������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�z(�Ŕ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_THISSALESANDADJUSTRF
        {
            get { return _hADD_THISSALESANDADJUSTRF; }
            set { _hADD_THISSALESANDADJUSTRF = value; }
        }

        /// public propaty name  :  HADD_THISTAXANDADJUSTRF
        /// <summary>���񔄏����Ńv���p�e�B</summary>
        /// <value>�Z�o�l�F���񔄏����Ł{����Œ����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_THISTAXANDADJUSTRF
        {
            get { return _hADD_THISTAXANDADJUSTRF; }
            set { _hADD_THISTAXANDADJUSTRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYRF
        /// <summary>���͔��s���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYRF
        {
            get { return _hADD_ISSUEDAYRF; }
            set { _hADD_ISSUEDAYRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFYRF
        /// <summary>���͔��s���t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFYRF
        {
            get { return _hADD_ISSUEDAYFYRF; }
            set { _hADD_ISSUEDAYFYRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFSRF
        /// <summary>���͔��s���t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFSRF
        {
            get { return _hADD_ISSUEDAYFSRF; }
            set { _hADD_ISSUEDAYFSRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFWRF
        /// <summary>���͔��s���t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFWRF
        {
            get { return _hADD_ISSUEDAYFWRF; }
            set { _hADD_ISSUEDAYFWRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFMRF
        /// <summary>���͔��s���t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFMRF
        {
            get { return _hADD_ISSUEDAYFMRF; }
            set { _hADD_ISSUEDAYFMRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFDRF
        /// <summary>���͔��s���t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ISSUEDAYFDRF
        {
            get { return _hADD_ISSUEDAYFDRF; }
            set { _hADD_ISSUEDAYFDRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFGRF
        /// <summary>���͔��s���t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFGRF
        {
            get { return _hADD_ISSUEDAYFGRF; }
            set { _hADD_ISSUEDAYFGRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFRRF
        /// <summary>���͔��s���t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFRRF
        {
            get { return _hADD_ISSUEDAYFRRF; }
            set { _hADD_ISSUEDAYFRRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLSRF
        /// <summary>���͔��s���t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLSRF
        {
            get { return _hADD_ISSUEDAYFLSRF; }
            set { _hADD_ISSUEDAYFLSRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLPRF
        /// <summary>���͔��s���t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLPRF
        {
            get { return _hADD_ISSUEDAYFLPRF; }
            set { _hADD_ISSUEDAYFLPRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLYRF
        /// <summary>���͔��s���t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLYRF
        {
            get { return _hADD_ISSUEDAYFLYRF; }
            set { _hADD_ISSUEDAYFLYRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLMRF
        /// <summary>���͔��s���t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLMRF
        {
            get { return _hADD_ISSUEDAYFLMRF; }
            set { _hADD_ISSUEDAYFLMRF = value; }
        }

        /// public propaty name  :  HADD_ISSUEDAYFLDRF
        /// <summary>���͔��s���t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͔��s���t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ISSUEDAYFLDRF
        {
            get { return _hADD_ISSUEDAYFLDRF; }
            set { _hADD_ISSUEDAYFLDRF = value; }
        }

        /// public propaty name  :  CADD_CUSTOMERSUBCODERF
        /// <summary>������Ӑ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_CUSTOMERSUBCODERF
        {
            get { return _cADD_CUSTOMERSUBCODERF; }
            set { _cADD_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CADD_NAMERF
        /// <summary>������Ӑ於�̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NAMERF
        {
            get { return _cADD_NAMERF; }
            set { _cADD_NAMERF = value; }
        }

        /// public propaty name  :  CADD_NAME2RF
        /// <summary>������Ӑ於��2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NAME2RF
        {
            get { return _cADD_NAME2RF; }
            set { _cADD_NAME2RF = value; }
        }

        /// public propaty name  :  CADD_HONORIFICTITLERF
        /// <summary>������Ӑ�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_HONORIFICTITLERF
        {
            get { return _cADD_HONORIFICTITLERF; }
            set { _cADD_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CADD_KANARF
        /// <summary>������Ӑ�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_KANARF
        {
            get { return _cADD_KANARF; }
            set { _cADD_KANARF = value; }
        }

        /// public propaty name  :  CADD_CUSTOMERSNMRF
        /// <summary>������Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_CUSTOMERSNMRF
        {
            get { return _cADD_CUSTOMERSNMRF; }
            set { _cADD_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CADD_OUTPUTNAMECODERF
        /// <summary>������Ӑ揔���R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ揔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_OUTPUTNAMECODERF
        {
            get { return _cADD_OUTPUTNAMECODERF; }
            set { _cADD_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CADD_POSTNORF
        /// <summary>������Ӑ�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_POSTNORF
        {
            get { return _cADD_POSTNORF; }
            set { _cADD_POSTNORF = value; }
        }

        /// public propaty name  :  CADD_ADDRESS1RF
        /// <summary>������Ӑ�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_ADDRESS1RF
        {
            get { return _cADD_ADDRESS1RF; }
            set { _cADD_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CADD_ADDRESS3RF
        /// <summary>������Ӑ�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_ADDRESS3RF
        {
            get { return _cADD_ADDRESS3RF; }
            set { _cADD_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CADD_ADDRESS4RF
        /// <summary>������Ӑ�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_ADDRESS4RF
        {
            get { return _cADD_ADDRESS4RF; }
            set { _cADD_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE1RF
        /// <summary>������Ӑ敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE1RF
        {
            get { return _cADD_CUSTANALYSCODE1RF; }
            set { _cADD_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE2RF
        /// <summary>������Ӑ敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE2RF
        {
            get { return _cADD_CUSTANALYSCODE2RF; }
            set { _cADD_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE3RF
        /// <summary>������Ӑ敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE3RF
        {
            get { return _cADD_CUSTANALYSCODE3RF; }
            set { _cADD_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE4RF
        /// <summary>������Ӑ敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE4RF
        {
            get { return _cADD_CUSTANALYSCODE4RF; }
            set { _cADD_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE5RF
        /// <summary>������Ӑ敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE5RF
        {
            get { return _cADD_CUSTANALYSCODE5RF; }
            set { _cADD_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CADD_CUSTANALYSCODE6RF
        /// <summary>������Ӑ敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTANALYSCODE6RF
        {
            get { return _cADD_CUSTANALYSCODE6RF; }
            set { _cADD_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CADD_NOTE1RF
        /// <summary>������Ӑ���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE1RF
        {
            get { return _cADD_NOTE1RF; }
            set { _cADD_NOTE1RF = value; }
        }

        /// public propaty name  :  CADD_NOTE2RF
        /// <summary>������Ӑ���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE2RF
        {
            get { return _cADD_NOTE2RF; }
            set { _cADD_NOTE2RF = value; }
        }

        /// public propaty name  :  CADD_NOTE3RF
        /// <summary>������Ӑ���l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE3RF
        {
            get { return _cADD_NOTE3RF; }
            set { _cADD_NOTE3RF = value; }
        }

        /// public propaty name  :  CADD_NOTE4RF
        /// <summary>������Ӑ���l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE4RF
        {
            get { return _cADD_NOTE4RF; }
            set { _cADD_NOTE4RF = value; }
        }

        /// public propaty name  :  CADD_NOTE5RF
        /// <summary>������Ӑ���l5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE5RF
        {
            get { return _cADD_NOTE5RF; }
            set { _cADD_NOTE5RF = value; }
        }

        /// public propaty name  :  CADD_NOTE6RF
        /// <summary>������Ӑ���l6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE6RF
        {
            get { return _cADD_NOTE6RF; }
            set { _cADD_NOTE6RF = value; }
        }

        /// public propaty name  :  CADD_NOTE7RF
        /// <summary>������Ӑ���l7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE7RF
        {
            get { return _cADD_NOTE7RF; }
            set { _cADD_NOTE7RF = value; }
        }

        /// public propaty name  :  CADD_NOTE8RF
        /// <summary>������Ӑ���l8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE8RF
        {
            get { return _cADD_NOTE8RF; }
            set { _cADD_NOTE8RF = value; }
        }

        /// public propaty name  :  CADD_NOTE9RF
        /// <summary>������Ӑ���l9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE9RF
        {
            get { return _cADD_NOTE9RF; }
            set { _cADD_NOTE9RF = value; }
        }

        /// public propaty name  :  CADD_NOTE10RF
        /// <summary>������Ӑ���l10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ���l10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_NOTE10RF
        {
            get { return _cADD_NOTE10RF; }
            set { _cADD_NOTE10RF = value; }
        }

        /// public propaty name  :  CADD_PRINTCUSTOMERNAME1RF
        /// <summary>����p���Ӑ於�́i��i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���Ӑ於�́i��i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_PRINTCUSTOMERNAME1RF
        {
            get { return _cADD_PRINTCUSTOMERNAME1RF; }
            set { _cADD_PRINTCUSTOMERNAME1RF = value; }
        }

        /// public propaty name  :  CADD_PRINTCUSTOMERNAME2RF
        /// <summary>����p���Ӑ於�́i���i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���Ӑ於�́i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_PRINTCUSTOMERNAME2RF
        {
            get { return _cADD_PRINTCUSTOMERNAME2RF; }
            set { _cADD_PRINTCUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  CADD_PRINTCUSTOMERNAME2HNRF
        /// <summary>����p���Ӑ於�́i���i�j�{�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���Ӑ於�́i���i�j�{�h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_PRINTCUSTOMERNAME2HNRF
        {
            get { return _cADD_PRINTCUSTOMERNAME2HNRF; }
            set { _cADD_PRINTCUSTOMERNAME2HNRF = value; }
        }

        /// public propaty name  :  CSTCST_COLLECTMONEYNAMERF
        /// <summary>�W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_COLLECTMONEYNAMERF
        {
            get { return _cSTCST_COLLECTMONEYNAMERF; }
            set { _cSTCST_COLLECTMONEYNAMERF = value; }
        }

        /// public propaty name  :  CSTCST_COLLECTMONEYDAYRF
        /// <summary>�W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_COLLECTMONEYDAYRF
        {
            get { return _cSTCST_COLLECTMONEYDAYRF; }
            set { _cSTCST_COLLECTMONEYDAYRF = value; }
        }

        /// public propaty name  :  CADD_CUSTOMERCODERF
        /// <summary>������Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CADD_CUSTOMERCODERF
        {
            get { return _cADD_CUSTOMERCODERF; }
            set { _cADD_CUSTOMERCODERF = value; }
        }

        /// public propaty name  :  CADD_HOMETELNORF
        /// <summary>������Ӑ�d�b�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_HOMETELNORF
        {
            get { return _cADD_HOMETELNORF; }
            set { _cADD_HOMETELNORF = value; }
        }

        /// public propaty name  :  CADD_OFFICETELNORF
        /// <summary>������Ӑ�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_OFFICETELNORF
        {
            get { return _cADD_OFFICETELNORF; }
            set { _cADD_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CADD_PORTABLETELNORF
        /// <summary>������Ӑ�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_PORTABLETELNORF
        {
            get { return _cADD_PORTABLETELNORF; }
            set { _cADD_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CADD_HOMEFAXNORF
        /// <summary>������Ӑ�FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_HOMEFAXNORF
        {
            get { return _cADD_HOMEFAXNORF; }
            set { _cADD_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CADD_OFFICEFAXNORF
        /// <summary>������Ӑ�FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_OFFICEFAXNORF
        {
            get { return _cADD_OFFICEFAXNORF; }
            set { _cADD_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CADD_OTHERSTELNORF
        /// <summary>������Ӑ�d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ӑ�d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CADD_OTHERSTELNORF
        {
            get { return _cADD_OTHERSTELNORF; }
            set { _cADD_OTHERSTELNORF = value; }
        }

        /// public propaty name  :  CSTCST_HOMETELNORF
        /// <summary>���Ӑ�d�b�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_HOMETELNORF
        {
            get { return _cSTCST_HOMETELNORF; }
            set { _cSTCST_HOMETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICETELNORF
        /// <summary>���Ӑ�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_OFFICETELNORF
        {
            get { return _cSTCST_OFFICETELNORF; }
            set { _cSTCST_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_PORTABLETELNORF
        /// <summary>���Ӑ�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_PORTABLETELNORF
        {
            get { return _cSTCST_PORTABLETELNORF; }
            set { _cSTCST_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_HOMEFAXNORF
        /// <summary>���Ӑ�FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_HOMEFAXNORF
        {
            get { return _cSTCST_HOMEFAXNORF; }
            set { _cSTCST_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICEFAXNORF
        /// <summary>���Ӑ�FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_OFFICEFAXNORF
        {
            get { return _cSTCST_OFFICEFAXNORF; }
            set { _cSTCST_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OTHERSTELNORF
        /// <summary>���Ӑ�d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_OTHERSTELNORF
        {
            get { return _cSTCST_OTHERSTELNORF; }
            set { _cSTCST_OTHERSTELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_HOMETELNORF
        /// <summary>������d�b�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_HOMETELNORF
        {
            get { return _cSTCLM_HOMETELNORF; }
            set { _cSTCLM_HOMETELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_OFFICETELNORF
        /// <summary>������d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_OFFICETELNORF
        {
            get { return _cSTCLM_OFFICETELNORF; }
            set { _cSTCLM_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_PORTABLETELNORF
        /// <summary>������d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_PORTABLETELNORF
        {
            get { return _cSTCLM_PORTABLETELNORF; }
            set { _cSTCLM_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CSTCLM_HOMEFAXNORF
        /// <summary>������FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_HOMEFAXNORF
        {
            get { return _cSTCLM_HOMEFAXNORF; }
            set { _cSTCLM_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCLM_OFFICEFAXNORF
        /// <summary>������FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_OFFICEFAXNORF
        {
            get { return _cSTCLM_OFFICEFAXNORF; }
            set { _cSTCLM_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCLM_OTHERSTELNORF
        /// <summary>������d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_OTHERSTELNORF
        {
            get { return _cSTCLM_OTHERSTELNORF; }
            set { _cSTCLM_OTHERSTELNORF = value; }
        }

        /// public propaty name  :  HADD_THISSALESANDADJUSTTAXINCRF
        /// <summary>���񔄏�z(�ō�)�v���p�e�B</summary>
        /// <value>�Z�o�l�F���񔄏�z(�Ŕ�)�{�c�������z�{���񔄏����Ł{����Œ����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�z(�ō�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_THISSALESANDADJUSTTAXINCRF
        {
            get { return _hADD_THISSALESANDADJUSTTAXINCRF; }
            set { _hADD_THISSALESANDADJUSTTAXINCRF = value; }
        }

        /// public propaty name  :  CSTCLM_COLLECTMONEYNAMERF
        /// <summary>������W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_COLLECTMONEYNAMERF
        {
            get { return _cSTCLM_COLLECTMONEYNAMERF; }
            set { _cSTCLM_COLLECTMONEYNAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_COLLECTMONEYDAYRF
        /// <summary>������W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_COLLECTMONEYDAYRF
        {
            get { return _cSTCLM_COLLECTMONEYDAYRF; }
            set { _cSTCLM_COLLECTMONEYDAYRF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_RESULTSSECTCDRF
        /// <summary>���ы��_�R�[�h�v���p�e�B</summary>
        /// <value>���яW�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ы��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CUSTDMDPRCRF_RESULTSSECTCDRF
        {
            get { return _cUSTDMDPRCRF_RESULTSSECTCDRF; }
            set { _cUSTDMDPRCRF_RESULTSSECTCDRF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAMEJOIN12RF
        /// <summary>���Ӑ於�P�{���Ӑ於�Q�v���p�e�B</summary>
        /// <value>���̂P�{���̂Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�P�{���Ӑ於�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAMEJOIN12RF
        {
            get { return _hADD_PRINTCUSTOMERNAMEJOIN12RF; }
            set { _hADD_PRINTCUSTOMERNAMEJOIN12RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAMEJOIN12HNRF
        /// <summary>���Ӑ於�P�{���Ӑ於�Q�{�h�̃v���p�e�B</summary>
        /// <value>���̂P�{���̂Q�{�󔒁{�h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�P�{���Ӑ於�Q�{�h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAMEJOIN12HNRF
        {
            get { return _hADD_PRINTCUSTOMERNAMEJOIN12HNRF; }
            set { _hADD_PRINTCUSTOMERNAMEJOIN12HNRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME1FHRF
        /// <summary>���Ж��P�i�O���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��P�i�O���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME1FHRF
        {
            get { return _hADD_PRINTENTERPRISENAME1FHRF; }
            set { _hADD_PRINTENTERPRISENAME1FHRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME1LHRF
        /// <summary>���Ж��P�i�㔼�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��P�i�㔼�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME1LHRF
        {
            get { return _hADD_PRINTENTERPRISENAME1LHRF; }
            set { _hADD_PRINTENTERPRISENAME1LHRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME2FHRF
        /// <summary>���Ж��Q�i�O���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��Q�i�O���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME2FHRF
        {
            get { return _hADD_PRINTENTERPRISENAME2FHRF; }
            set { _hADD_PRINTENTERPRISENAME2FHRF = value; }
        }

        /// public propaty name  :  HADD_PRINTENTERPRISENAME2LHRF
        /// <summary>���Ж��Q�i�㔼�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��Q�i�㔼�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTENTERPRISENAME2LHRF
        {
            get { return _hADD_PRINTENTERPRISENAME2LHRF; }
            set { _hADD_PRINTENTERPRISENAME2LHRF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_HOMETELNODSPNAMERF
        /// <summary>����TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ALITMDSPNMRF_HOMETELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_HOMETELNODSPNAMERF; }
            set { _aLITMDSPNMRF_HOMETELNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_OFFICETELNODSPNAMERF
        /// <summary>�Ζ���TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ζ���TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ALITMDSPNMRF_OFFICETELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_OFFICETELNODSPNAMERF; }
            set { _aLITMDSPNMRF_OFFICETELNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_MOBILETELNODSPNAMERF
        /// <summary>�g��TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g��TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ALITMDSPNMRF_MOBILETELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_MOBILETELNODSPNAMERF; }
            set { _aLITMDSPNMRF_MOBILETELNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_HOMEFAXNODSPNAMERF
        /// <summary>����FAX�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����FAX�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ALITMDSPNMRF_HOMEFAXNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_HOMEFAXNODSPNAMERF; }
            set { _aLITMDSPNMRF_HOMEFAXNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_OFFICEFAXNODSPNAMERF
        /// <summary>�Ζ���FAX�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ζ���FAX�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ALITMDSPNMRF_OFFICEFAXNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_OFFICEFAXNODSPNAMERF; }
            set { _aLITMDSPNMRF_OFFICEFAXNODSPNAMERF = value; }
        }

        /// public propaty name  :  ALITMDSPNMRF_OTHERTELNODSPNAMERF
        /// <summary>���̑�TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̑�TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ALITMDSPNMRF_OTHERTELNODSPNAMERF
        {
            get { return _aLITMDSPNMRF_OTHERTELNODSPNAMERF; }
            set { _aLITMDSPNMRF_OTHERTELNODSPNAMERF = value; }
        }

        /// public propaty name  :  CSTCLM_SALESAREACODERF
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_SALESAREACODERF
        {
            get { return _cSTCLM_SALESAREACODERF; }
            set { _cSTCLM_SALESAREACODERF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTOMERAGENTCDRF
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_CUSTOMERAGENTCDRF
        {
            get { return _cSTCLM_CUSTOMERAGENTCDRF; }
            set { _cSTCLM_CUSTOMERAGENTCDRF = value; }
        }

        /// public propaty name  :  CSTCLM_BILLCOLLECTERCDRF
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_BILLCOLLECTERCDRF
        {
            get { return _cSTCLM_BILLCOLLECTERCDRF; }
            set { _cSTCLM_BILLCOLLECTERCDRF = value; }
        }

        /// public propaty name  :  CSTCLM_OLDCUSTOMERAGENTCDRF
        /// <summary>���ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCLM_OLDCUSTOMERAGENTCDRF
        {
            get { return _cSTCLM_OLDCUSTOMERAGENTCDRF; }
            set { _cSTCLM_OLDCUSTOMERAGENTCDRF = value; }
        }

        /// public propaty name  :  CSTCLM_CUSTAGENTCHGDATERF
        /// <summary>�ڋq�S���ύX���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_CUSTAGENTCHGDATERF
        {
            get { return _cSTCLM_CUSTAGENTCHGDATERF; }
            set { _cSTCLM_CUSTAGENTCHGDATERF = value; }
        }

        /// public propaty name  :  CUSTDMDPRCRF_BILLNORF
        /// <summary>�������ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CUSTDMDPRCRF_BILLNORF
        {
            get { return _cUSTDMDPRCRF_BILLNORF; }
            set { _cUSTDMDPRCRF_BILLNORF = value; }
        }

        /// public propaty name  :  CSTCST_COLLECTMONEYCODERF
        /// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_COLLECTMONEYCODERF
        {
            get { return _cSTCST_COLLECTMONEYCODERF; }
            set { _cSTCST_COLLECTMONEYCODERF = value; }
        }

        /// public propaty name  :  CSTCLM_COLLECTMONEYCODERF
        /// <summary>������W�����敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_COLLECTMONEYCODERF
        {
            get { return _cSTCLM_COLLECTMONEYCODERF; }
            set { _cSTCLM_COLLECTMONEYCODERF = value; }
        }

        /// public propaty name  :  CSTCLM_TOTALDAYRF
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCLM_TOTALDAYRF
        {
            get { return _cSTCLM_TOTALDAYRF; }
            set { _cSTCLM_TOTALDAYRF = value; }
        }

        /// public propaty name  :  TitleTaxRate1
        /// <summary>�ŗ�1�^�C�g��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int TitleTaxRate1
        {
            get { return _titleTaxRate1; }
            set { _titleTaxRate1 = value; }
        }

        /// public propaty name  :  TitleTaxRate2
        /// <summary>�ŗ�2�^�C�g��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int TitleTaxRate2
        {
            get { return _titleTaxRate2; }
            set { _titleTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxInRate1
        /// <summary>�ŗ�(1)�Ώۋ��z���v(�Ŕ���) </summary>
        /// <value>�ŗ�(1)�Ώۋ��z���v(�Ŕ���)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�(1)�Ώۋ��z���v(�Ŕ���) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double TotalThisTimeSalesTaxExRate1
        {
            get { return _totalThisTimeSalesTaxExRate1; }
            set { _totalThisTimeSalesTaxExRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxExRate2
        /// <summary>�ŗ�(2)�Ώۋ��z���v(�Ŕ���) </summary>
        /// <value>�ŗ�(2)�Ώۋ��z���v(�Ŕ���)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�(2)�Ώۋ��z���v(�Ŕ���) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double TotalThisTimeSalesTaxExRate2
        {
            get { return _totalThisTimeSalesTaxExRate2; }
            set { _totalThisTimeSalesTaxExRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeTaxRate1
        /// <summary>�Ŋz(1) </summary>
        /// <value>�Ŋz(1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�(1)�Ώۋ��z���v(�Ŕ���) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double TotalThisTimeTaxRate1
        {
            get { return _totalThisTimeTaxRate1; }
            set { _totalThisTimeTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeTaxRate2
        /// <summary>�Ŋz(2) </summary>
        /// <value>�Ŋz(2)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�(2)�Ώۋ��z���v(�Ŕ���) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double TotalThisTimeTaxRate2
        {
            get { return _totalThisTimeTaxRate2; }
            set { _totalThisTimeTaxRate2 = value; }
        }


        /// <summary>
        /// ���R���[�������w�b�_�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EBooksFrePBillHeadWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillHeadWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EBooksFrePBillHeadWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>EBooksFrePBillHeadWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillHeadWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      : 2022/10/18 �c������</br>
    /// <br>�Ǘ��ԍ�         : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
    /// </remarks>
    public class EBooksFrePBillHeadWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillHeadWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  EBooksFrePBillHeadWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is EBooksFrePBillHeadWork || graph is ArrayList || graph is EBooksFrePBillHeadWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( EBooksFrePBillHeadWork ).FullName ) );

            if ( graph != null && graph is EBooksFrePBillHeadWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EBooksFrePBillHeadWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is EBooksFrePBillHeadWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EBooksFrePBillHeadWork[])graph).Length;
            }
            else if ( graph is EBooksFrePBillHeadWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_ADDUPSECCODERF
            //������R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_CLAIMCODERF
            //�����於��
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CLAIMNAMERF
            //�����於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CLAIMNAME2RF
            //�����旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CLAIMSNMRF
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_CUSTOMERCODERF
            //���Ӑ於��
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CUSTOMERNAMERF
            //���Ӑ於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CUSTOMERNAME2RF
            //���Ӑ旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_CUSTOMERSNMRF
            //�v��N����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_ADDUPDATERF
            //�v��N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_ADDUPYEARMONTHRF
            //�O�񐿋����z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_LASTTIMEDEMANDRF
            //����萔���z�i�ʏ�����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF
            //����l���z�i�ʏ�����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMEDMDNRMLRF
            //����J�z�c���i�����v�j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMETTLBLCDMDRF
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFSTHISTIMESALESRF
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFSTHISSALESTAXRF
            //���E��O�őΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF
            //���E����őΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDOFFSETINTAXRF
            //���E���ېőΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF
            //���E��O�ŏ����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFFSETOUTTAXRF
            //���E����ŏ����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_OFFSETINTAXRF
            //���񔄏���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISTIMESALESRF
            //���񔄏�����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESTAXRF
            //����O�őΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDSALESOUTTAXRF
            //������őΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDSALESINTAXRF
            //�����ېőΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ITDEDSALESTAXFREERF
            //����O�Ŋz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_SALESOUTTAXRF
            //������Ŋz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_SALESINTAXRF
            //���񔄏�ԕi���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRICRGDSRF
            //���񔄏�ԕi�����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF
            //�ԕi�O�őΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF
            //�ԕi���őΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDRETINTAXRF
            //�ԕi��ېőΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDRETTAXFREERF
            //�ԕi�O�Ŋz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLRETOUTERTAXRF
            //�ԕi���Ŋz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLRETINNERTAXRF
            //���񔄏�l�����z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRICDISRF
            //���񔄏�l�������
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_THISSALESPRCTAXDISRF
            //�l���O�őΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF
            //�l�����őΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDDISINTAXRF
            //�l����ېőΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLITDEDDISTAXFREERF
            //�l���O�Ŋz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLDISOUTERTAXRF
            //�l�����Ŋz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TTLDISINNERTAXRF
            //����Œ����z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_TAXADJUSTRF
            //�c�������z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_BALANCEADJUSTRF
            //�v�Z�㐿�����z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_AFCALDEMANDPRICERF
            //��2��O�c���i�����v�j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
            //��3��O�c���i�����v�j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF
            //�����X�V�J�n�N����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_STARTCADDUPUPDDATERF
            //����`�[����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_SALESSLIPCOUNTRF
            //���������s��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_BILLPRINTDATERF
            //�����\���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF
            //�������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_COLLECTCONDRF
            //����œ]�ŕ���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CUSTDMDPRCRF_CONSTAXLAYMETHODRF
            //����ŗ�
            serInfo.MemberInfo.Add( typeof( Double ) ); //CUSTDMDPRCRF_CONSTAXRATERF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SECHED_SECTIONGUIDENMRF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SECHED_SECTIONGUIDESNMRF
            //���Ж��̃R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SECHED_COMPANYNAMECD1RF
            //����PR��
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYPRRF
            //���Ж���1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYNAME1RF
            //���Ж���2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYNAME2RF
            //�X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_POSTNORF
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ADDRESS1RF
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ADDRESS3RF
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ADDRESS4RF
            //���Гd�b�ԍ�1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELNO1RF
            //���Гd�b�ԍ�2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELNO2RF
            //���Гd�b�ԍ�3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELNO3RF
            //���Гd�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELTITLE1RF
            //���Гd�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELTITLE2RF
            //���Гd�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYTELTITLE3RF
            //��s�U���ē���
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_TRANSFERGUIDANCERF
            //��s����1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ACCOUNTNOINFO1RF
            //��s����2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ACCOUNTNOINFO2RF
            //��s����3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_ACCOUNTNOINFO3RF
            //���Аݒ�E�v1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYSETNOTE1RF
            //���Аݒ�E�v2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYSETNOTE2RF
            //�摜���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //COMPANYNMRF_IMAGEINFOCODERF
            //����URL
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYURLRF
            //����PR��2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_COMPANYPRSENTENCE2RF
            //�摜�󎚗p�R�����g1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_IMAGECOMMENTFORPRT1RF
            //�摜�󎚗p�R�����g2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYNMRF_IMAGECOMMENTFORPRT2RF
            //�摜���f�[�^
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //IMAGEINFORF_IMAGEINFODATARF
            //���Ӑ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_CUSTOMERSUBCODERF
            //���Ӑ於��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NAMERF
            //���Ӑ於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NAME2RF
            //���Ӑ�h��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_HONORIFICTITLERF
            //���Ӑ�J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_KANARF
            //���Ӑ旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_CUSTOMERSNMRF
            //���Ӑ揔���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_OUTPUTNAMECODERF
            //���Ӑ�X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_POSTNORF
            //���Ӑ�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_ADDRESS1RF
            //���Ӑ�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_ADDRESS3RF
            //���Ӑ�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_ADDRESS4RF
            //���Ӑ敪�̓R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE1RF
            //���Ӑ敪�̓R�[�h2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE2RF
            //���Ӑ敪�̓R�[�h3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE3RF
            //���Ӑ敪�̓R�[�h4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE4RF
            //���Ӑ敪�̓R�[�h5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE5RF
            //���Ӑ敪�̓R�[�h6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_CUSTANALYSCODE6RF
            //���Ӑ���l1
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE1RF
            //���Ӑ���l2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE2RF
            //���Ӑ���l3
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE3RF
            //���Ӑ���l4
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE4RF
            //���Ӑ���l5
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE5RF
            //���Ӑ���l6
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE6RF
            //���Ӑ���l7
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE7RF
            //���Ӑ���l8
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE8RF
            //���Ӑ���l9
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE9RF
            //���Ӑ���l10
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_NOTE10RF
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            //�������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));      // CSTCLM_SALESCNSTAXFRCPROCCDRF
            // --- ADD END �c������ 2022/10/18 -----<<<<<
            //������T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_CUSTOMERSUBCODERF
            //�����於��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NAMERF
            //�����於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NAME2RF
            //������h��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_HONORIFICTITLERF
            //������J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_KANARF
            //�����旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_CUSTOMERSNMRF
            //�����揔���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_OUTPUTNAMECODERF
            //������X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_POSTNORF
            //������Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_ADDRESS1RF
            //������Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_ADDRESS3RF
            //������Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_ADDRESS4RF
            //�����敪�̓R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE1RF
            //�����敪�̓R�[�h2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE2RF
            //�����敪�̓R�[�h3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE3RF
            //�����敪�̓R�[�h4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE4RF
            //�����敪�̓R�[�h5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE5RF
            //�����敪�̓R�[�h6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTANALYSCODE6RF
            //��������l1
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE1RF
            //��������l2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE2RF
            //��������l3
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE3RF
            //��������l4
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE4RF
            //��������l5
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE5RF
            //��������l6
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE6RF
            //��������l7
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE7RF
            //��������l8
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE8RF
            //��������l9
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE9RF
            //��������l10
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_NOTE10RF
            //���Ж���1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYNAME1RF
            //���Ж���2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYNAME2RF
            //�X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_POSTNORF
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS1RF
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS3RF
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS4RF
            //���Гd�b�ԍ�1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO1RF
            //���Гd�b�ԍ�2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO2RF
            //���Гd�b�ԍ�3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO3RF
            //���Гd�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE1RF
            //���Гd�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE2RF
            //���Гd�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE3RF
            //�����ݒ����R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD1RF
            //�����ݒ����R�[�h2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD2RF
            //�����ݒ����R�[�h3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD3RF
            //�����ݒ����R�[�h4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD4RF
            //�����ݒ����R�[�h5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD5RF
            //�����ݒ����R�[�h6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD6RF
            //�����ݒ����R�[�h7
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD7RF
            //�����ݒ����R�[�h8
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD8RF
            //�����ݒ����R�[�h9
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD9RF
            //�����ݒ����R�[�h10
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DEPOSITSTRF_DEPOSITSTKINDCD10RF
            //�������햼��1
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT01_MONEYKINDNAMERF
            //�������z1
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT01_DEPOSITRF
            //�������햼��2
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT02_MONEYKINDNAMERF
            //�������z2
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT02_DEPOSITRF
            //�������햼��3
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT03_MONEYKINDNAMERF
            //�������z3
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT03_DEPOSITRF
            //�������햼��4
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT04_MONEYKINDNAMERF
            //�������z4
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT04_DEPOSITRF
            //�������햼��5
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT05_MONEYKINDNAMERF
            //�������z5
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT05_DEPOSITRF
            //�������햼��6
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT06_MONEYKINDNAMERF
            //�������z6
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT06_DEPOSITRF
            //�������햼��7
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT07_MONEYKINDNAMERF
            //�������z7
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT07_DEPOSITRF
            //�������햼��8
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT08_MONEYKINDNAMERF
            //�������z8
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT08_DEPOSITRF
            //�������햼��9
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT09_MONEYKINDNAMERF
            //�������z9
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT09_DEPOSITRF
            //�������햼��10
            serInfo.MemberInfo.Add( typeof( string ) ); //DEPT10_MONEYKINDNAMERF
            //�������z10
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DEPT10_DEPOSITRF
            //�v��N��������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFYRF
            //�v��N��������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFSRF
            //�v��N�����a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFWRF
            //�v��N������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFMRF
            //�v��N������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPDATEFDRF
            //�v��N��������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFGRF
            //�v��N��������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFRRF
            //�v��N�������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLSRF
            //�v��N�������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLPRF
            //�v��N�������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLYRF
            //�v��N�������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLMRF
            //�v��N�������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPDATEFLDRF
            //�v��N������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFYRF
            //�v��N������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFSRF
            //�v��N���a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFWRF
            //�v��N����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPYEARMONTHFMRF
            //�v��N������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFGRF
            //�v��N������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFRRF
            //�v��N�����e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLSRF
            //�v��N�����e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLPRF
            //�v��N�����e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLYRF
            //�v��N�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPYEARMONTHFLMRF
            //�����X�V�J�n�N��������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFYRF
            //�����X�V�J�n�N��������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFSRF
            //�����X�V�J�n�N�����a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFWRF
            //�����X�V�J�n�N������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFMRF
            //�����X�V�J�n�N������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_STARTCADDUPUPDDATEFDRF
            //�����X�V�J�n�N��������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFGRF
            //�����X�V�J�n�N��������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFRRF
            //�����X�V�J�n�N�������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLSRF
            //�����X�V�J�n�N�������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLPRF
            //�����X�V�J�n�N�������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLYRF
            //�����X�V�J�n�N�������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLMRF
            //�����X�V�J�n�N�������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STARTCADDUPUPDDATEFLDRF
            //���������s������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFYRF
            //���������s������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFSRF
            //���������s���a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFWRF
            //���������s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFMRF
            //���������s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_BILLPRINTDATEFDRF
            //���������s������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFGRF
            //���������s������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFRRF
            //���������s�����e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLSRF
            //���������s�����e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLPRF
            //���������s�����e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLYRF
            //���������s�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLMRF
            //���������s�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_BILLPRINTDATEFLDRF
            //�����\�������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFYRF
            //�����\�������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFSRF
            //�����\����a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFWRF
            //�����\�����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFMRF
            //�����\�����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_EXPECTEDDEPOSITDATEFDRF
            //�����\�������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFGRF
            //�����\�������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFRRF
            //�����\������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLSRF
            //�����\������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLPRF
            //�����\������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLYRF
            //�����\������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLMRF
            //�����\������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXPECTEDDEPOSITDATEFLDRF
            //�����������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COLLECTCONDNMRF
            //�������^�C�g��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMTITLERF
            //�������^�C�g���Q
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMTITLE2RF
            //�������R�����g�P
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMCOMENT1RF
            //�������R�����g�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMCOMENT2RF
            //�������R�����g�R
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DMDFORMCOMENT3RF
            //�������z(�l������)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLEXDISRF
            //�������z(�萔������)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLEXFEERF
            //�������z(�l���E�萔������)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLEXDISFEERF
            //�������z(�l���{�萔��)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_DMDNRMLSAMDISFEERF
            //���񔄏�z(�Ŕ�)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_THISSALESANDADJUSTRF
            //���񔄏�����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_THISTAXANDADJUSTRF
            //���͔��s���t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYRF
            //���͔��s���t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFYRF
            //���͔��s���t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFSRF
            //���͔��s���t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFWRF
            //���͔��s���t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFMRF
            //���͔��s���t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ISSUEDAYFDRF
            //���͔��s���t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFGRF
            //���͔��s���t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFRRF
            //���͔��s���t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLSRF
            //���͔��s���t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLPRF
            //���͔��s���t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLYRF
            //���͔��s���t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLMRF
            //���͔��s���t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ISSUEDAYFLDRF
            //������Ӑ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_CUSTOMERSUBCODERF
            //������Ӑ於��
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NAMERF
            //������Ӑ於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NAME2RF
            //������Ӑ�h��
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_HONORIFICTITLERF
            //������Ӑ�J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_KANARF
            //������Ӑ旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_CUSTOMERSNMRF
            //������Ӑ揔���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_OUTPUTNAMECODERF
            //������Ӑ�X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_POSTNORF
            //������Ӑ�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_ADDRESS1RF
            //������Ӑ�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_ADDRESS3RF
            //������Ӑ�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_ADDRESS4RF
            //������Ӑ敪�̓R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE1RF
            //������Ӑ敪�̓R�[�h2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE2RF
            //������Ӑ敪�̓R�[�h3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE3RF
            //������Ӑ敪�̓R�[�h4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE4RF
            //������Ӑ敪�̓R�[�h5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE5RF
            //������Ӑ敪�̓R�[�h6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTANALYSCODE6RF
            //������Ӑ���l1
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE1RF
            //������Ӑ���l2
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE2RF
            //������Ӑ���l3
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE3RF
            //������Ӑ���l4
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE4RF
            //������Ӑ���l5
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE5RF
            //������Ӑ���l6
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE6RF
            //������Ӑ���l7
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE7RF
            //������Ӑ���l8
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE8RF
            //������Ӑ���l9
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE9RF
            //������Ӑ���l10
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_NOTE10RF
            //����p���Ӑ於�́i��i�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PRINTCUSTOMERNAME1RF
            //����p���Ӑ於�́i���i�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PRINTCUSTOMERNAME2RF
            //����p���Ӑ於�́i���i�j�{�h��
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PRINTCUSTOMERNAME2HNRF
            //�W�����敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_COLLECTMONEYNAMERF
            //�W����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_COLLECTMONEYDAYRF
            //������Ӑ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CADD_CUSTOMERCODERF
            //������Ӑ�d�b�ԍ��i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_HOMETELNORF
            //������Ӑ�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_OFFICETELNORF
            //������Ӑ�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_PORTABLETELNORF
            //������Ӑ�FAX�ԍ��i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_HOMEFAXNORF
            //������Ӑ�FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_OFFICEFAXNORF
            //������Ӑ�d�b�ԍ��i���̑��j
            serInfo.MemberInfo.Add( typeof( string ) ); //CADD_OTHERSTELNORF
            //���Ӑ�d�b�ԍ��i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_HOMETELNORF
            //���Ӑ�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_OFFICETELNORF
            //���Ӑ�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_PORTABLETELNORF
            //���Ӑ�FAX�ԍ��i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_HOMEFAXNORF
            //���Ӑ�FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_OFFICEFAXNORF
            //���Ӑ�d�b�ԍ��i���̑��j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCST_OTHERSTELNORF
            //������d�b�ԍ��i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_HOMETELNORF
            //������d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OFFICETELNORF
            //������d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_PORTABLETELNORF
            //������FAX�ԍ��i����j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_HOMEFAXNORF
            //������FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OFFICEFAXNORF
            //������d�b�ԍ��i���̑��j
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OTHERSTELNORF
            //���񔄏�z(�ō�)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_THISSALESANDADJUSTTAXINCRF
            //������W�����敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_COLLECTMONEYNAMERF
            //������W����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_COLLECTMONEYDAYRF
            //���ы��_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CUSTDMDPRCRF_RESULTSSECTCDRF
            //���Ӑ於�P�{���Ӑ於�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAMEJOIN12RF
            //���Ӑ於�P�{���Ӑ於�Q�{�h��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAMEJOIN12HNRF
            //���Ж��P�i�O���j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME1FHRF
            //���Ж��P�i�㔼�j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME1LHRF
            //���Ж��Q�i�O���j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME2FHRF
            //���Ж��Q�i�㔼�j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTENTERPRISENAME2LHRF
            //����TEL�\������
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_HOMETELNODSPNAMERF
            //�Ζ���TEL�\������
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_OFFICETELNODSPNAMERF
            //�g��TEL�\������
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_MOBILETELNODSPNAMERF
            //����FAX�\������
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_HOMEFAXNODSPNAMERF
            //�Ζ���FAX�\������
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_OFFICEFAXNODSPNAMERF
            //���̑�TEL�\������
            serInfo.MemberInfo.Add( typeof( string ) ); //ALITMDSPNMRF_OTHERTELNODSPNAMERF
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_SALESAREACODERF
            //�ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_CUSTOMERAGENTCDRF
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_BILLCOLLECTERCDRF
            //���ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTCLM_OLDCUSTOMERAGENTCDRF
            //�ڋq�S���ύX��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCLM_CUSTAGENTCHGDATERF
            //�������ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CUSTDMDPRCRF_BILLNORF
            //�W�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_COLLECTMONEYCODERF

            //������W�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCLM_COLLECTMONEYCODERF

            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCLM_TOTALDAYRF

            // �ŗ�1�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // �ŗ�2�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // �ŗ�(1)�Ώۋ��z���v(�Ŕ���)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeSalesTaxExRate1
            // �ŗ�(2)�Ώۋ��z���v(�Ŕ���)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeSalesTaxExRate2
            // �Ŋz(1)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeTaxRate1
            // �Ŋz(2)
            serInfo.MemberInfo.Add(typeof(Double)); //TotalThisTimeTaxRate2


            serInfo.Serialize( writer, serInfo );
            if ( graph is EBooksFrePBillHeadWork )
            {
                EBooksFrePBillHeadWork temp = (EBooksFrePBillHeadWork)graph;

                SetEBooksFrePBillHeadWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is EBooksFrePBillHeadWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (EBooksFrePBillHeadWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( EBooksFrePBillHeadWork temp in lst )
                {
                    SetEBooksFrePBillHeadWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// EBooksFrePBillHeadWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 345; // --- DEL �c������ 2022/10/18
        private const int currentMemberCount = 346; // --- ADD �c������ 2022/10/18

        /// <summary>
        ///  EBooksFrePBillHeadWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillHeadWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�         : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        private void SetEBooksFrePBillHeadWork( System.IO.BinaryWriter writer, EBooksFrePBillHeadWork temp )
        {
            //�v�㋒�_�R�[�h
            writer.Write( temp.CUSTDMDPRCRF_ADDUPSECCODERF );
            //������R�[�h
            writer.Write( temp.CUSTDMDPRCRF_CLAIMCODERF );
            //�����於��
            writer.Write( temp.CUSTDMDPRCRF_CLAIMNAMERF );
            //�����於��2
            writer.Write( temp.CUSTDMDPRCRF_CLAIMNAME2RF );
            //�����旪��
            writer.Write( temp.CUSTDMDPRCRF_CLAIMSNMRF );
            //���Ӑ�R�[�h
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERCODERF );
            //���Ӑ於��
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERNAMERF );
            //���Ӑ於��2
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERNAME2RF );
            //���Ӑ旪��
            writer.Write( temp.CUSTDMDPRCRF_CUSTOMERSNMRF );
            //�v��N����
            writer.Write( temp.CUSTDMDPRCRF_ADDUPDATERF );
            //�v��N��
            writer.Write( temp.CUSTDMDPRCRF_ADDUPYEARMONTHRF );
            //�O�񐿋����z
            writer.Write( temp.CUSTDMDPRCRF_LASTTIMEDEMANDRF );
            //����萔���z�i�ʏ�����j
            writer.Write( temp.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF );
            //����l���z�i�ʏ�����j
            writer.Write( temp.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF );
            //����������z�i�ʏ�����j
            writer.Write( temp.CUSTDMDPRCRF_THISTIMEDMDNRMLRF );
            //����J�z�c���i�����v�j
            writer.Write( temp.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF );
            //���E�㍡�񔄏���z
            writer.Write( temp.CUSTDMDPRCRF_OFSTHISTIMESALESRF );
            //���E�㍡�񔄏�����
            writer.Write( temp.CUSTDMDPRCRF_OFSTHISSALESTAXRF );
            //���E��O�őΏۊz
            writer.Write( temp.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF );
            //���E����őΏۊz
            writer.Write( temp.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF );
            //���E���ېőΏۊz
            writer.Write( temp.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF );
            //���E��O�ŏ����
            writer.Write( temp.CUSTDMDPRCRF_OFFSETOUTTAXRF );
            //���E����ŏ����
            writer.Write( temp.CUSTDMDPRCRF_OFFSETINTAXRF );
            //���񔄏���z
            writer.Write( temp.CUSTDMDPRCRF_THISTIMESALESRF );
            //���񔄏�����
            writer.Write( temp.CUSTDMDPRCRF_THISSALESTAXRF );
            //����O�őΏۊz
            writer.Write( temp.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF );
            //������őΏۊz
            writer.Write( temp.CUSTDMDPRCRF_ITDEDSALESINTAXRF );
            //�����ېőΏۊz
            writer.Write( temp.CUSTDMDPRCRF_ITDEDSALESTAXFREERF );
            //����O�Ŋz
            writer.Write( temp.CUSTDMDPRCRF_SALESOUTTAXRF );
            //������Ŋz
            writer.Write( temp.CUSTDMDPRCRF_SALESINTAXRF );
            //���񔄏�ԕi���z
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRICRGDSRF );
            //���񔄏�ԕi�����
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF );
            //�ԕi�O�őΏۊz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF );
            //�ԕi���őΏۊz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDRETINTAXRF );
            //�ԕi��ېőΏۊz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF );
            //�ԕi�O�Ŋz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLRETOUTERTAXRF );
            //�ԕi���Ŋz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLRETINNERTAXRF );
            //���񔄏�l�����z
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRICDISRF );
            //���񔄏�l�������
            writer.Write( temp.CUSTDMDPRCRF_THISSALESPRCTAXDISRF );
            //�l���O�őΏۊz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF );
            //�l�����őΏۊz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDDISINTAXRF );
            //�l����ېőΏۊz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF );
            //�l���O�Ŋz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLDISOUTERTAXRF );
            //�l�����Ŋz���v
            writer.Write( temp.CUSTDMDPRCRF_TTLDISINNERTAXRF );
            //����Œ����z
            writer.Write( temp.CUSTDMDPRCRF_TAXADJUSTRF );
            //�c�������z
            writer.Write( temp.CUSTDMDPRCRF_BALANCEADJUSTRF );
            //�v�Z�㐿�����z
            writer.Write( temp.CUSTDMDPRCRF_AFCALDEMANDPRICERF );
            //��2��O�c���i�����v�j
            writer.Write( temp.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF );
            //��3��O�c���i�����v�j
            writer.Write( temp.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF );
            //�����X�V�J�n�N����
            writer.Write( temp.CUSTDMDPRCRF_STARTCADDUPUPDDATERF );
            //����`�[����
            writer.Write( temp.CUSTDMDPRCRF_SALESSLIPCOUNTRF );
            //���������s��
            writer.Write( temp.CUSTDMDPRCRF_BILLPRINTDATERF );
            //�����\���
            writer.Write( temp.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF );
            //�������
            writer.Write( temp.CUSTDMDPRCRF_COLLECTCONDRF );
            //����œ]�ŕ���
            writer.Write( temp.CUSTDMDPRCRF_CONSTAXLAYMETHODRF );
            //����ŗ�
            writer.Write( temp.CUSTDMDPRCRF_CONSTAXRATERF );
            //���_�K�C�h����
            writer.Write( temp.SECHED_SECTIONGUIDENMRF );
            //���_�K�C�h����
            writer.Write( temp.SECHED_SECTIONGUIDESNMRF );
            //���Ж��̃R�[�h1
            writer.Write( temp.SECHED_COMPANYNAMECD1RF );
            //����PR��
            writer.Write( temp.COMPANYNMRF_COMPANYPRRF );
            //���Ж���1
            writer.Write( temp.COMPANYNMRF_COMPANYNAME1RF );
            //���Ж���2
            writer.Write( temp.COMPANYNMRF_COMPANYNAME2RF );
            //�X�֔ԍ�
            writer.Write( temp.COMPANYNMRF_POSTNORF );
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.COMPANYNMRF_ADDRESS1RF );
            //�Z��3�i�Ԓn�j
            writer.Write( temp.COMPANYNMRF_ADDRESS3RF );
            //�Z��4�i�A�p�[�g���́j
            writer.Write( temp.COMPANYNMRF_ADDRESS4RF );
            //���Гd�b�ԍ�1
            writer.Write( temp.COMPANYNMRF_COMPANYTELNO1RF );
            //���Гd�b�ԍ�2
            writer.Write( temp.COMPANYNMRF_COMPANYTELNO2RF );
            //���Гd�b�ԍ�3
            writer.Write( temp.COMPANYNMRF_COMPANYTELNO3RF );
            //���Гd�b�ԍ��^�C�g��1
            writer.Write( temp.COMPANYNMRF_COMPANYTELTITLE1RF );
            //���Гd�b�ԍ��^�C�g��2
            writer.Write( temp.COMPANYNMRF_COMPANYTELTITLE2RF );
            //���Гd�b�ԍ��^�C�g��3
            writer.Write( temp.COMPANYNMRF_COMPANYTELTITLE3RF );
            //��s�U���ē���
            writer.Write( temp.COMPANYNMRF_TRANSFERGUIDANCERF );
            //��s����1
            writer.Write( temp.COMPANYNMRF_ACCOUNTNOINFO1RF );
            //��s����2
            writer.Write( temp.COMPANYNMRF_ACCOUNTNOINFO2RF );
            //��s����3
            writer.Write( temp.COMPANYNMRF_ACCOUNTNOINFO3RF );
            //���Аݒ�E�v1
            writer.Write( temp.COMPANYNMRF_COMPANYSETNOTE1RF );
            //���Аݒ�E�v2
            writer.Write( temp.COMPANYNMRF_COMPANYSETNOTE2RF );
            //�摜���R�[�h
            writer.Write( temp.COMPANYNMRF_IMAGEINFOCODERF );
            //����URL
            writer.Write( temp.COMPANYNMRF_COMPANYURLRF );
            //����PR��2
            writer.Write( temp.COMPANYNMRF_COMPANYPRSENTENCE2RF );
            //�摜�󎚗p�R�����g1
            writer.Write( temp.COMPANYNMRF_IMAGECOMMENTFORPRT1RF );
            //�摜�󎚗p�R�����g2
            writer.Write( temp.COMPANYNMRF_IMAGECOMMENTFORPRT2RF );
            //�摜���f�[�^
            writer.Write( temp.IMAGEINFORF_IMAGEINFODATARF );
            //���Ӑ�T�u�R�[�h
            writer.Write( temp.CSTCST_CUSTOMERSUBCODERF );
            //���Ӑ於��
            writer.Write( temp.CSTCST_NAMERF );
            //���Ӑ於��2
            writer.Write( temp.CSTCST_NAME2RF );
            //���Ӑ�h��
            writer.Write( temp.CSTCST_HONORIFICTITLERF );
            //���Ӑ�J�i
            writer.Write( temp.CSTCST_KANARF );
            //���Ӑ旪��
            writer.Write( temp.CSTCST_CUSTOMERSNMRF );
            //���Ӑ揔���R�[�h
            writer.Write( temp.CSTCST_OUTPUTNAMECODERF );
            //���Ӑ�X�֔ԍ�
            writer.Write( temp.CSTCST_POSTNORF );
            //���Ӑ�Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.CSTCST_ADDRESS1RF );
            //���Ӑ�Z��3�i�Ԓn�j
            writer.Write( temp.CSTCST_ADDRESS3RF );
            //���Ӑ�Z��4�i�A�p�[�g���́j
            writer.Write( temp.CSTCST_ADDRESS4RF );
            //���Ӑ敪�̓R�[�h1
            writer.Write( temp.CSTCST_CUSTANALYSCODE1RF );
            //���Ӑ敪�̓R�[�h2
            writer.Write( temp.CSTCST_CUSTANALYSCODE2RF );
            //���Ӑ敪�̓R�[�h3
            writer.Write( temp.CSTCST_CUSTANALYSCODE3RF );
            //���Ӑ敪�̓R�[�h4
            writer.Write( temp.CSTCST_CUSTANALYSCODE4RF );
            //���Ӑ敪�̓R�[�h5
            writer.Write( temp.CSTCST_CUSTANALYSCODE5RF );
            //���Ӑ敪�̓R�[�h6
            writer.Write( temp.CSTCST_CUSTANALYSCODE6RF );
            //���Ӑ���l1
            writer.Write( temp.CSTCST_NOTE1RF );
            //���Ӑ���l2
            writer.Write( temp.CSTCST_NOTE2RF );
            //���Ӑ���l3
            writer.Write( temp.CSTCST_NOTE3RF );
            //���Ӑ���l4
            writer.Write( temp.CSTCST_NOTE4RF );
            //���Ӑ���l5
            writer.Write( temp.CSTCST_NOTE5RF );
            //���Ӑ���l6
            writer.Write( temp.CSTCST_NOTE6RF );
            //���Ӑ���l7
            writer.Write( temp.CSTCST_NOTE7RF );
            //���Ӑ���l8
            writer.Write( temp.CSTCST_NOTE8RF );
            //���Ӑ���l9
            writer.Write( temp.CSTCST_NOTE9RF );
            //���Ӑ���l10
            writer.Write( temp.CSTCST_NOTE10RF );
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            //�������Œ[�������R�[�h
            writer.Write(temp.CSTCLM_SALESCNSTAXFRCPROCCDRF);
            // --- ADD END �c������ 2022/10/18 -----<<<<<
            //������T�u�R�[�h
            writer.Write( temp.CSTCLM_CUSTOMERSUBCODERF );
            //�����於��
            writer.Write( temp.CSTCLM_NAMERF );
            //�����於��2
            writer.Write( temp.CSTCLM_NAME2RF );
            //������h��
            writer.Write( temp.CSTCLM_HONORIFICTITLERF );
            //������J�i
            writer.Write( temp.CSTCLM_KANARF );
            //�����旪��
            writer.Write( temp.CSTCLM_CUSTOMERSNMRF );
            //�����揔���R�[�h
            writer.Write( temp.CSTCLM_OUTPUTNAMECODERF );
            //������X�֔ԍ�
            writer.Write( temp.CSTCLM_POSTNORF );
            //������Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.CSTCLM_ADDRESS1RF );
            //������Z��3�i�Ԓn�j
            writer.Write( temp.CSTCLM_ADDRESS3RF );
            //������Z��4�i�A�p�[�g���́j
            writer.Write( temp.CSTCLM_ADDRESS4RF );
            //�����敪�̓R�[�h1
            writer.Write( temp.CSTCLM_CUSTANALYSCODE1RF );
            //�����敪�̓R�[�h2
            writer.Write( temp.CSTCLM_CUSTANALYSCODE2RF );
            //�����敪�̓R�[�h3
            writer.Write( temp.CSTCLM_CUSTANALYSCODE3RF );
            //�����敪�̓R�[�h4
            writer.Write( temp.CSTCLM_CUSTANALYSCODE4RF );
            //�����敪�̓R�[�h5
            writer.Write( temp.CSTCLM_CUSTANALYSCODE5RF );
            //�����敪�̓R�[�h6
            writer.Write( temp.CSTCLM_CUSTANALYSCODE6RF );
            //��������l1
            writer.Write( temp.CSTCLM_NOTE1RF );
            //��������l2
            writer.Write( temp.CSTCLM_NOTE2RF );
            //��������l3
            writer.Write( temp.CSTCLM_NOTE3RF );
            //��������l4
            writer.Write( temp.CSTCLM_NOTE4RF );
            //��������l5
            writer.Write( temp.CSTCLM_NOTE5RF );
            //��������l6
            writer.Write( temp.CSTCLM_NOTE6RF );
            //��������l7
            writer.Write( temp.CSTCLM_NOTE7RF );
            //��������l8
            writer.Write( temp.CSTCLM_NOTE8RF );
            //��������l9
            writer.Write( temp.CSTCLM_NOTE9RF );
            //��������l10
            writer.Write( temp.CSTCLM_NOTE10RF );
            //���Ж���1
            writer.Write( temp.COMPANYINFRF_COMPANYNAME1RF );
            //���Ж���2
            writer.Write( temp.COMPANYINFRF_COMPANYNAME2RF );
            //�X�֔ԍ�
            writer.Write( temp.COMPANYINFRF_POSTNORF );
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.COMPANYINFRF_ADDRESS1RF );
            //�Z��3�i�Ԓn�j
            writer.Write( temp.COMPANYINFRF_ADDRESS3RF );
            //�Z��4�i�A�p�[�g���́j
            writer.Write( temp.COMPANYINFRF_ADDRESS4RF );
            //���Гd�b�ԍ�1
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO1RF );
            //���Гd�b�ԍ�2
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO2RF );
            //���Гd�b�ԍ�3
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO3RF );
            //���Гd�b�ԍ��^�C�g��1
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE1RF );
            //���Гd�b�ԍ��^�C�g��2
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE2RF );
            //���Гd�b�ԍ��^�C�g��3
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE3RF );
            //�����ݒ����R�[�h1
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD1RF );
            //�����ݒ����R�[�h2
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD2RF );
            //�����ݒ����R�[�h3
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD3RF );
            //�����ݒ����R�[�h4
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD4RF );
            //�����ݒ����R�[�h5
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD5RF );
            //�����ݒ����R�[�h6
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD6RF );
            //�����ݒ����R�[�h7
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD7RF );
            //�����ݒ����R�[�h8
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD8RF );
            //�����ݒ����R�[�h9
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD9RF );
            //�����ݒ����R�[�h10
            writer.Write( temp.DEPOSITSTRF_DEPOSITSTKINDCD10RF );
            //�������햼��1
            writer.Write( temp.DEPT01_MONEYKINDNAMERF );
            //�������z1
            writer.Write( temp.DEPT01_DEPOSITRF );
            //�������햼��2
            writer.Write( temp.DEPT02_MONEYKINDNAMERF );
            //�������z2
            writer.Write( temp.DEPT02_DEPOSITRF );
            //�������햼��3
            writer.Write( temp.DEPT03_MONEYKINDNAMERF );
            //�������z3
            writer.Write( temp.DEPT03_DEPOSITRF );
            //�������햼��4
            writer.Write( temp.DEPT04_MONEYKINDNAMERF );
            //�������z4
            writer.Write( temp.DEPT04_DEPOSITRF );
            //�������햼��5
            writer.Write( temp.DEPT05_MONEYKINDNAMERF );
            //�������z5
            writer.Write( temp.DEPT05_DEPOSITRF );
            //�������햼��6
            writer.Write( temp.DEPT06_MONEYKINDNAMERF );
            //�������z6
            writer.Write( temp.DEPT06_DEPOSITRF );
            //�������햼��7
            writer.Write( temp.DEPT07_MONEYKINDNAMERF );
            //�������z7
            writer.Write( temp.DEPT07_DEPOSITRF );
            //�������햼��8
            writer.Write( temp.DEPT08_MONEYKINDNAMERF );
            //�������z8
            writer.Write( temp.DEPT08_DEPOSITRF );
            //�������햼��9
            writer.Write( temp.DEPT09_MONEYKINDNAMERF );
            //�������z9
            writer.Write( temp.DEPT09_DEPOSITRF );
            //�������햼��10
            writer.Write( temp.DEPT10_MONEYKINDNAMERF );
            //�������z10
            writer.Write( temp.DEPT10_DEPOSITRF );
            //�v��N��������N
            writer.Write( temp.HADD_ADDUPDATEFYRF );
            //�v��N��������N��
            writer.Write( temp.HADD_ADDUPDATEFSRF );
            //�v��N�����a��N
            writer.Write( temp.HADD_ADDUPDATEFWRF );
            //�v��N������
            writer.Write( temp.HADD_ADDUPDATEFMRF );
            //�v��N������
            writer.Write( temp.HADD_ADDUPDATEFDRF );
            //�v��N��������
            writer.Write( temp.HADD_ADDUPDATEFGRF );
            //�v��N��������
            writer.Write( temp.HADD_ADDUPDATEFRRF );
            //�v��N�������e����(/)
            writer.Write( temp.HADD_ADDUPDATEFLSRF );
            //�v��N�������e����(.)
            writer.Write( temp.HADD_ADDUPDATEFLPRF );
            //�v��N�������e����(�N)
            writer.Write( temp.HADD_ADDUPDATEFLYRF );
            //�v��N�������e����(��)
            writer.Write( temp.HADD_ADDUPDATEFLMRF );
            //�v��N�������e����(��)
            writer.Write( temp.HADD_ADDUPDATEFLDRF );
            //�v��N������N
            writer.Write( temp.HADD_ADDUPYEARMONTHFYRF );
            //�v��N������N��
            writer.Write( temp.HADD_ADDUPYEARMONTHFSRF );
            //�v��N���a��N
            writer.Write( temp.HADD_ADDUPYEARMONTHFWRF );
            //�v��N����
            writer.Write( temp.HADD_ADDUPYEARMONTHFMRF );
            //�v��N������
            writer.Write( temp.HADD_ADDUPYEARMONTHFGRF );
            //�v��N������
            writer.Write( temp.HADD_ADDUPYEARMONTHFRRF );
            //�v��N�����e����(/)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLSRF );
            //�v��N�����e����(.)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLPRF );
            //�v��N�����e����(�N)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLYRF );
            //�v��N�����e����(��)
            writer.Write( temp.HADD_ADDUPYEARMONTHFLMRF );
            //�����X�V�J�n�N��������N
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFYRF );
            //�����X�V�J�n�N��������N��
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFSRF );
            //�����X�V�J�n�N�����a��N
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFWRF );
            //�����X�V�J�n�N������
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFMRF );
            //�����X�V�J�n�N������
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFDRF );
            //�����X�V�J�n�N��������
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFGRF );
            //�����X�V�J�n�N��������
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFRRF );
            //�����X�V�J�n�N�������e����(/)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLSRF );
            //�����X�V�J�n�N�������e����(.)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLPRF );
            //�����X�V�J�n�N�������e����(�N)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLYRF );
            //�����X�V�J�n�N�������e����(��)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLMRF );
            //�����X�V�J�n�N�������e����(��)
            writer.Write( temp.HADD_STARTCADDUPUPDDATEFLDRF );
            //���������s������N
            writer.Write( temp.HADD_BILLPRINTDATEFYRF );
            //���������s������N��
            writer.Write( temp.HADD_BILLPRINTDATEFSRF );
            //���������s���a��N
            writer.Write( temp.HADD_BILLPRINTDATEFWRF );
            //���������s����
            writer.Write( temp.HADD_BILLPRINTDATEFMRF );
            //���������s����
            writer.Write( temp.HADD_BILLPRINTDATEFDRF );
            //���������s������
            writer.Write( temp.HADD_BILLPRINTDATEFGRF );
            //���������s������
            writer.Write( temp.HADD_BILLPRINTDATEFRRF );
            //���������s�����e����(/)
            writer.Write( temp.HADD_BILLPRINTDATEFLSRF );
            //���������s�����e����(.)
            writer.Write( temp.HADD_BILLPRINTDATEFLPRF );
            //���������s�����e����(�N)
            writer.Write( temp.HADD_BILLPRINTDATEFLYRF );
            //���������s�����e����(��)
            writer.Write( temp.HADD_BILLPRINTDATEFLMRF );
            //���������s�����e����(��)
            writer.Write( temp.HADD_BILLPRINTDATEFLDRF );
            //�����\�������N
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFYRF );
            //�����\�������N��
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFSRF );
            //�����\����a��N
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFWRF );
            //�����\�����
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFMRF );
            //�����\�����
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFDRF );
            //�����\�������
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFGRF );
            //�����\�������
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFRRF );
            //�����\������e����(/)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLSRF );
            //�����\������e����(.)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLPRF );
            //�����\������e����(�N)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLYRF );
            //�����\������e����(��)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLMRF );
            //�����\������e����(��)
            writer.Write( temp.HADD_EXPECTEDDEPOSITDATEFLDRF );
            //�����������
            writer.Write( temp.HADD_COLLECTCONDNMRF );
            //�������^�C�g��
            writer.Write( temp.HADD_DMDFORMTITLERF );
            //�������^�C�g���Q
            writer.Write( temp.HADD_DMDFORMTITLE2RF );
            //�������R�����g�P
            writer.Write( temp.HADD_DMDFORMCOMENT1RF );
            //�������R�����g�Q
            writer.Write( temp.HADD_DMDFORMCOMENT2RF );
            //�������R�����g�R
            writer.Write( temp.HADD_DMDFORMCOMENT3RF );
            //�������z(�l������)
            writer.Write( temp.HADD_DMDNRMLEXDISRF );
            //�������z(�萔������)
            writer.Write( temp.HADD_DMDNRMLEXFEERF );
            //�������z(�l���E�萔������)
            writer.Write( temp.HADD_DMDNRMLEXDISFEERF );
            //�������z(�l���{�萔��)
            writer.Write( temp.HADD_DMDNRMLSAMDISFEERF );
            //���񔄏�z(�Ŕ�)
            writer.Write( temp.HADD_THISSALESANDADJUSTRF );
            //���񔄏�����
            writer.Write( temp.HADD_THISTAXANDADJUSTRF );
            //���͔��s���t
            writer.Write( temp.HADD_ISSUEDAYRF );
            //���͔��s���t����N
            writer.Write( temp.HADD_ISSUEDAYFYRF );
            //���͔��s���t����N��
            writer.Write( temp.HADD_ISSUEDAYFSRF );
            //���͔��s���t�a��N
            writer.Write( temp.HADD_ISSUEDAYFWRF );
            //���͔��s���t��
            writer.Write( temp.HADD_ISSUEDAYFMRF );
            //���͔��s���t��
            writer.Write( temp.HADD_ISSUEDAYFDRF );
            //���͔��s���t����
            writer.Write( temp.HADD_ISSUEDAYFGRF );
            //���͔��s���t����
            writer.Write( temp.HADD_ISSUEDAYFRRF );
            //���͔��s���t���e����(/)
            writer.Write( temp.HADD_ISSUEDAYFLSRF );
            //���͔��s���t���e����(.)
            writer.Write( temp.HADD_ISSUEDAYFLPRF );
            //���͔��s���t���e����(�N)
            writer.Write( temp.HADD_ISSUEDAYFLYRF );
            //���͔��s���t���e����(��)
            writer.Write( temp.HADD_ISSUEDAYFLMRF );
            //���͔��s���t���e����(��)
            writer.Write( temp.HADD_ISSUEDAYFLDRF );
            //������Ӑ�T�u�R�[�h
            writer.Write( temp.CADD_CUSTOMERSUBCODERF );
            //������Ӑ於��
            writer.Write( temp.CADD_NAMERF );
            //������Ӑ於��2
            writer.Write( temp.CADD_NAME2RF );
            //������Ӑ�h��
            writer.Write( temp.CADD_HONORIFICTITLERF );
            //������Ӑ�J�i
            writer.Write( temp.CADD_KANARF );
            //������Ӑ旪��
            writer.Write( temp.CADD_CUSTOMERSNMRF );
            //������Ӑ揔���R�[�h
            writer.Write( temp.CADD_OUTPUTNAMECODERF );
            //������Ӑ�X�֔ԍ�
            writer.Write( temp.CADD_POSTNORF );
            //������Ӑ�Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.CADD_ADDRESS1RF );
            //������Ӑ�Z��3�i�Ԓn�j
            writer.Write( temp.CADD_ADDRESS3RF );
            //������Ӑ�Z��4�i�A�p�[�g���́j
            writer.Write( temp.CADD_ADDRESS4RF );
            //������Ӑ敪�̓R�[�h1
            writer.Write( temp.CADD_CUSTANALYSCODE1RF );
            //������Ӑ敪�̓R�[�h2
            writer.Write( temp.CADD_CUSTANALYSCODE2RF );
            //������Ӑ敪�̓R�[�h3
            writer.Write( temp.CADD_CUSTANALYSCODE3RF );
            //������Ӑ敪�̓R�[�h4
            writer.Write( temp.CADD_CUSTANALYSCODE4RF );
            //������Ӑ敪�̓R�[�h5
            writer.Write( temp.CADD_CUSTANALYSCODE5RF );
            //������Ӑ敪�̓R�[�h6
            writer.Write( temp.CADD_CUSTANALYSCODE6RF );
            //������Ӑ���l1
            writer.Write( temp.CADD_NOTE1RF );
            //������Ӑ���l2
            writer.Write( temp.CADD_NOTE2RF );
            //������Ӑ���l3
            writer.Write( temp.CADD_NOTE3RF );
            //������Ӑ���l4
            writer.Write( temp.CADD_NOTE4RF );
            //������Ӑ���l5
            writer.Write( temp.CADD_NOTE5RF );
            //������Ӑ���l6
            writer.Write( temp.CADD_NOTE6RF );
            //������Ӑ���l7
            writer.Write( temp.CADD_NOTE7RF );
            //������Ӑ���l8
            writer.Write( temp.CADD_NOTE8RF );
            //������Ӑ���l9
            writer.Write( temp.CADD_NOTE9RF );
            //������Ӑ���l10
            writer.Write( temp.CADD_NOTE10RF );
            //����p���Ӑ於�́i��i�j
            writer.Write( temp.CADD_PRINTCUSTOMERNAME1RF );
            //����p���Ӑ於�́i���i�j
            writer.Write( temp.CADD_PRINTCUSTOMERNAME2RF );
            //����p���Ӑ於�́i���i�j�{�h��
            writer.Write( temp.CADD_PRINTCUSTOMERNAME2HNRF );
            //�W�����敪����
            writer.Write( temp.CSTCST_COLLECTMONEYNAMERF );
            //�W����
            writer.Write( temp.CSTCST_COLLECTMONEYDAYRF );
            //������Ӑ�R�[�h
            writer.Write( temp.CADD_CUSTOMERCODERF );
            //������Ӑ�d�b�ԍ��i����j
            writer.Write( temp.CADD_HOMETELNORF );
            //������Ӑ�d�b�ԍ��i�Ζ���j
            writer.Write( temp.CADD_OFFICETELNORF );
            //������Ӑ�d�b�ԍ��i�g�сj
            writer.Write( temp.CADD_PORTABLETELNORF );
            //������Ӑ�FAX�ԍ��i����j
            writer.Write( temp.CADD_HOMEFAXNORF );
            //������Ӑ�FAX�ԍ��i�Ζ���j
            writer.Write( temp.CADD_OFFICEFAXNORF );
            //������Ӑ�d�b�ԍ��i���̑��j
            writer.Write( temp.CADD_OTHERSTELNORF );
            //���Ӑ�d�b�ԍ��i����j
            writer.Write( temp.CSTCST_HOMETELNORF );
            //���Ӑ�d�b�ԍ��i�Ζ���j
            writer.Write( temp.CSTCST_OFFICETELNORF );
            //���Ӑ�d�b�ԍ��i�g�сj
            writer.Write( temp.CSTCST_PORTABLETELNORF );
            //���Ӑ�FAX�ԍ��i����j
            writer.Write( temp.CSTCST_HOMEFAXNORF );
            //���Ӑ�FAX�ԍ��i�Ζ���j
            writer.Write( temp.CSTCST_OFFICEFAXNORF );
            //���Ӑ�d�b�ԍ��i���̑��j
            writer.Write( temp.CSTCST_OTHERSTELNORF );
            //������d�b�ԍ��i����j
            writer.Write( temp.CSTCLM_HOMETELNORF );
            //������d�b�ԍ��i�Ζ���j
            writer.Write( temp.CSTCLM_OFFICETELNORF );
            //������d�b�ԍ��i�g�сj
            writer.Write( temp.CSTCLM_PORTABLETELNORF );
            //������FAX�ԍ��i����j
            writer.Write( temp.CSTCLM_HOMEFAXNORF );
            //������FAX�ԍ��i�Ζ���j
            writer.Write( temp.CSTCLM_OFFICEFAXNORF );
            //������d�b�ԍ��i���̑��j
            writer.Write( temp.CSTCLM_OTHERSTELNORF );
            //���񔄏�z(�ō�)
            writer.Write( temp.HADD_THISSALESANDADJUSTTAXINCRF );
            //������W�����敪����
            writer.Write( temp.CSTCLM_COLLECTMONEYNAMERF );
            //������W����
            writer.Write( temp.CSTCLM_COLLECTMONEYDAYRF );
            //���ы��_�R�[�h
            writer.Write( temp.CUSTDMDPRCRF_RESULTSSECTCDRF );
            //���Ӑ於�P�{���Ӑ於�Q
            writer.Write( temp.HADD_PRINTCUSTOMERNAMEJOIN12RF );
            //���Ӑ於�P�{���Ӑ於�Q�{�h��
            writer.Write( temp.HADD_PRINTCUSTOMERNAMEJOIN12HNRF );
            //���Ж��P�i�O���j
            writer.Write( temp.HADD_PRINTENTERPRISENAME1FHRF );
            //���Ж��P�i�㔼�j
            writer.Write( temp.HADD_PRINTENTERPRISENAME1LHRF );
            //���Ж��Q�i�O���j
            writer.Write( temp.HADD_PRINTENTERPRISENAME2FHRF );
            //���Ж��Q�i�㔼�j
            writer.Write( temp.HADD_PRINTENTERPRISENAME2LHRF );
            //����TEL�\������
            writer.Write( temp.ALITMDSPNMRF_HOMETELNODSPNAMERF );
            //�Ζ���TEL�\������
            writer.Write( temp.ALITMDSPNMRF_OFFICETELNODSPNAMERF );
            //�g��TEL�\������
            writer.Write( temp.ALITMDSPNMRF_MOBILETELNODSPNAMERF );
            //����FAX�\������
            writer.Write( temp.ALITMDSPNMRF_HOMEFAXNODSPNAMERF );
            //�Ζ���FAX�\������
            writer.Write( temp.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF );
            //���̑�TEL�\������
            writer.Write( temp.ALITMDSPNMRF_OTHERTELNODSPNAMERF );
            //�̔��G���A�R�[�h
            writer.Write( temp.CSTCLM_SALESAREACODERF );
            //�ڋq�S���]�ƈ��R�[�h
            writer.Write( temp.CSTCLM_CUSTOMERAGENTCDRF );
            //�W���S���]�ƈ��R�[�h
            writer.Write( temp.CSTCLM_BILLCOLLECTERCDRF );
            //���ڋq�S���]�ƈ��R�[�h
            writer.Write( temp.CSTCLM_OLDCUSTOMERAGENTCDRF );
            //�ڋq�S���ύX��
            writer.Write( temp.CSTCLM_CUSTAGENTCHGDATERF );
            //�������ԍ�
            writer.Write(temp.CUSTDMDPRCRF_BILLNORF);
            //�W�����敪�R�[�h
            writer.Write(temp.CSTCST_COLLECTMONEYCODERF);

            //������W�����敪�R�[�h
            writer.Write(temp.CSTCLM_COLLECTMONEYCODERF);

            //����
            writer.Write(temp.CSTCLM_TOTALDAYRF);

            //�ŗ�1�^�C�g��
            writer.Write(temp.TitleTaxRate1);
            //�ŗ�2�^�C�g��
            writer.Write(temp.TitleTaxRate2);
            // �ŗ�(1)�Ώۋ��z���v(�Ŕ���)
            writer.Write(temp.TotalThisTimeSalesTaxExRate1);
            // �ŗ�(2)�Ώۋ��z���v(�Ŕ���)
            writer.Write(temp.TotalThisTimeSalesTaxExRate2);
            // �Ŋz(1)
            writer.Write(temp.TotalThisTimeTaxRate1);
            // �Ŋz(2)
            writer.Write(temp.TotalThisTimeTaxRate2);

        }

        /// <summary>
        ///  EBooksFrePBillHeadWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EBooksFrePBillHeadWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillHeadWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        private EBooksFrePBillHeadWork GetEBooksFrePBillHeadWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EBooksFrePBillHeadWork temp = new EBooksFrePBillHeadWork();

            //�v�㋒�_�R�[�h
            temp.CUSTDMDPRCRF_ADDUPSECCODERF = reader.ReadString();
            //������R�[�h
            temp.CUSTDMDPRCRF_CLAIMCODERF = reader.ReadInt32();
            //�����於��
            temp.CUSTDMDPRCRF_CLAIMNAMERF = reader.ReadString();
            //�����於��2
            temp.CUSTDMDPRCRF_CLAIMNAME2RF = reader.ReadString();
            //�����旪��
            temp.CUSTDMDPRCRF_CLAIMSNMRF = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CUSTDMDPRCRF_CUSTOMERCODERF = reader.ReadInt32();
            //���Ӑ於��
            temp.CUSTDMDPRCRF_CUSTOMERNAMERF = reader.ReadString();
            //���Ӑ於��2
            temp.CUSTDMDPRCRF_CUSTOMERNAME2RF = reader.ReadString();
            //���Ӑ旪��
            temp.CUSTDMDPRCRF_CUSTOMERSNMRF = reader.ReadString();
            //�v��N����
            temp.CUSTDMDPRCRF_ADDUPDATERF = reader.ReadInt32();
            //�v��N��
            temp.CUSTDMDPRCRF_ADDUPYEARMONTHRF = reader.ReadInt32();
            //�O�񐿋����z
            temp.CUSTDMDPRCRF_LASTTIMEDEMANDRF = reader.ReadInt64();
            //����萔���z�i�ʏ�����j
            temp.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = reader.ReadInt64();
            //����l���z�i�ʏ�����j
            temp.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = reader.ReadInt64();
            //����J�z�c���i�����v�j
            temp.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.CUSTDMDPRCRF_OFSTHISTIMESALESRF = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.CUSTDMDPRCRF_OFSTHISSALESTAXRF = reader.ReadInt64();
            //���E��O�őΏۊz
            temp.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = reader.ReadInt64();
            //���E����őΏۊz
            temp.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = reader.ReadInt64();
            //���E���ېőΏۊz
            temp.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = reader.ReadInt64();
            //���E��O�ŏ����
            temp.CUSTDMDPRCRF_OFFSETOUTTAXRF = reader.ReadInt64();
            //���E����ŏ����
            temp.CUSTDMDPRCRF_OFFSETINTAXRF = reader.ReadInt64();
            //���񔄏���z
            temp.CUSTDMDPRCRF_THISTIMESALESRF = reader.ReadInt64();
            //���񔄏�����
            temp.CUSTDMDPRCRF_THISSALESTAXRF = reader.ReadInt64();
            //����O�őΏۊz
            temp.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = reader.ReadInt64();
            //������őΏۊz
            temp.CUSTDMDPRCRF_ITDEDSALESINTAXRF = reader.ReadInt64();
            //�����ېőΏۊz
            temp.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = reader.ReadInt64();
            //����O�Ŋz
            temp.CUSTDMDPRCRF_SALESOUTTAXRF = reader.ReadInt64();
            //������Ŋz
            temp.CUSTDMDPRCRF_SALESINTAXRF = reader.ReadInt64();
            //���񔄏�ԕi���z
            temp.CUSTDMDPRCRF_THISSALESPRICRGDSRF = reader.ReadInt64();
            //���񔄏�ԕi�����
            temp.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = reader.ReadInt64();
            //�ԕi�O�őΏۊz���v
            temp.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = reader.ReadInt64();
            //�ԕi���őΏۊz���v
            temp.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = reader.ReadInt64();
            //�ԕi��ېőΏۊz���v
            temp.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = reader.ReadInt64();
            //�ԕi�O�Ŋz���v
            temp.CUSTDMDPRCRF_TTLRETOUTERTAXRF = reader.ReadInt64();
            //�ԕi���Ŋz���v
            temp.CUSTDMDPRCRF_TTLRETINNERTAXRF = reader.ReadInt64();
            //���񔄏�l�����z
            temp.CUSTDMDPRCRF_THISSALESPRICDISRF = reader.ReadInt64();
            //���񔄏�l�������
            temp.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = reader.ReadInt64();
            //�l���O�őΏۊz���v
            temp.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = reader.ReadInt64();
            //�l�����őΏۊz���v
            temp.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = reader.ReadInt64();
            //�l����ېőΏۊz���v
            temp.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = reader.ReadInt64();
            //�l���O�Ŋz���v
            temp.CUSTDMDPRCRF_TTLDISOUTERTAXRF = reader.ReadInt64();
            //�l�����Ŋz���v
            temp.CUSTDMDPRCRF_TTLDISINNERTAXRF = reader.ReadInt64();
            //����Œ����z
            temp.CUSTDMDPRCRF_TAXADJUSTRF = reader.ReadInt64();
            //�c�������z
            temp.CUSTDMDPRCRF_BALANCEADJUSTRF = reader.ReadInt64();
            //�v�Z�㐿�����z
            temp.CUSTDMDPRCRF_AFCALDEMANDPRICERF = reader.ReadInt64();
            //��2��O�c���i�����v�j
            temp.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = reader.ReadInt64();
            //��3��O�c���i�����v�j
            temp.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = reader.ReadInt64();
            //�����X�V�J�n�N����
            temp.CUSTDMDPRCRF_STARTCADDUPUPDDATERF = reader.ReadInt32();
            //����`�[����
            temp.CUSTDMDPRCRF_SALESSLIPCOUNTRF = reader.ReadInt32();
            //���������s��
            temp.CUSTDMDPRCRF_BILLPRINTDATERF = reader.ReadInt32();
            //�����\���
            temp.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = reader.ReadInt32();
            //�������
            temp.CUSTDMDPRCRF_COLLECTCONDRF = reader.ReadInt32();
            //����œ]�ŕ���
            temp.CUSTDMDPRCRF_CONSTAXLAYMETHODRF = reader.ReadInt32();
            //����ŗ�
            temp.CUSTDMDPRCRF_CONSTAXRATERF = reader.ReadDouble();
            //���_�K�C�h����
            temp.SECHED_SECTIONGUIDENMRF = reader.ReadString();
            //���_�K�C�h����
            temp.SECHED_SECTIONGUIDESNMRF = reader.ReadString();
            //���Ж��̃R�[�h1
            temp.SECHED_COMPANYNAMECD1RF = reader.ReadInt32();
            //����PR��
            temp.COMPANYNMRF_COMPANYPRRF = reader.ReadString();
            //���Ж���1
            temp.COMPANYNMRF_COMPANYNAME1RF = reader.ReadString();
            //���Ж���2
            temp.COMPANYNMRF_COMPANYNAME2RF = reader.ReadString();
            //�X�֔ԍ�
            temp.COMPANYNMRF_POSTNORF = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.COMPANYNMRF_ADDRESS1RF = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.COMPANYNMRF_ADDRESS3RF = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.COMPANYNMRF_ADDRESS4RF = reader.ReadString();
            //���Гd�b�ԍ�1
            temp.COMPANYNMRF_COMPANYTELNO1RF = reader.ReadString();
            //���Гd�b�ԍ�2
            temp.COMPANYNMRF_COMPANYTELNO2RF = reader.ReadString();
            //���Гd�b�ԍ�3
            temp.COMPANYNMRF_COMPANYTELNO3RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��1
            temp.COMPANYNMRF_COMPANYTELTITLE1RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��2
            temp.COMPANYNMRF_COMPANYTELTITLE2RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��3
            temp.COMPANYNMRF_COMPANYTELTITLE3RF = reader.ReadString();
            //��s�U���ē���
            temp.COMPANYNMRF_TRANSFERGUIDANCERF = reader.ReadString();
            //��s����1
            temp.COMPANYNMRF_ACCOUNTNOINFO1RF = reader.ReadString();
            //��s����2
            temp.COMPANYNMRF_ACCOUNTNOINFO2RF = reader.ReadString();
            //��s����3
            temp.COMPANYNMRF_ACCOUNTNOINFO3RF = reader.ReadString();
            //���Аݒ�E�v1
            temp.COMPANYNMRF_COMPANYSETNOTE1RF = reader.ReadString();
            //���Аݒ�E�v2
            temp.COMPANYNMRF_COMPANYSETNOTE2RF = reader.ReadString();
            //�摜���R�[�h
            temp.COMPANYNMRF_IMAGEINFOCODERF = reader.ReadInt32();
            //����URL
            temp.COMPANYNMRF_COMPANYURLRF = reader.ReadString();
            //����PR��2
            temp.COMPANYNMRF_COMPANYPRSENTENCE2RF = reader.ReadString();
            //�摜�󎚗p�R�����g1
            temp.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = reader.ReadString();
            //�摜�󎚗p�R�����g2
            temp.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = reader.ReadString();
            //�摜���f�[�^
            //���ʕs�\//IMAGEINFORF_IMAGEINFODATARF
            //���Ӑ�T�u�R�[�h
            temp.CSTCST_CUSTOMERSUBCODERF = reader.ReadString();
            //���Ӑ於��
            temp.CSTCST_NAMERF = reader.ReadString();
            //���Ӑ於��2
            temp.CSTCST_NAME2RF = reader.ReadString();
            //���Ӑ�h��
            temp.CSTCST_HONORIFICTITLERF = reader.ReadString();
            //���Ӑ�J�i
            temp.CSTCST_KANARF = reader.ReadString();
            //���Ӑ旪��
            temp.CSTCST_CUSTOMERSNMRF = reader.ReadString();
            //���Ӑ揔���R�[�h
            temp.CSTCST_OUTPUTNAMECODERF = reader.ReadInt32();
            //���Ӑ�X�֔ԍ�
            temp.CSTCST_POSTNORF = reader.ReadString();
            //���Ӑ�Z��1�i�s���{���s��S�E�����E���j
            temp.CSTCST_ADDRESS1RF = reader.ReadString();
            //���Ӑ�Z��3�i�Ԓn�j
            temp.CSTCST_ADDRESS3RF = reader.ReadString();
            //���Ӑ�Z��4�i�A�p�[�g���́j
            temp.CSTCST_ADDRESS4RF = reader.ReadString();
            //���Ӑ敪�̓R�[�h1
            temp.CSTCST_CUSTANALYSCODE1RF = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h2
            temp.CSTCST_CUSTANALYSCODE2RF = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h3
            temp.CSTCST_CUSTANALYSCODE3RF = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h4
            temp.CSTCST_CUSTANALYSCODE4RF = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h5
            temp.CSTCST_CUSTANALYSCODE5RF = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h6
            temp.CSTCST_CUSTANALYSCODE6RF = reader.ReadInt32();
            //���Ӑ���l1
            temp.CSTCST_NOTE1RF = reader.ReadString();
            //���Ӑ���l2
            temp.CSTCST_NOTE2RF = reader.ReadString();
            //���Ӑ���l3
            temp.CSTCST_NOTE3RF = reader.ReadString();
            //���Ӑ���l4
            temp.CSTCST_NOTE4RF = reader.ReadString();
            //���Ӑ���l5
            temp.CSTCST_NOTE5RF = reader.ReadString();
            //���Ӑ���l6
            temp.CSTCST_NOTE6RF = reader.ReadString();
            //���Ӑ���l7
            temp.CSTCST_NOTE7RF = reader.ReadString();
            //���Ӑ���l8
            temp.CSTCST_NOTE8RF = reader.ReadString();
            //���Ӑ���l9
            temp.CSTCST_NOTE9RF = reader.ReadString();
            //���Ӑ���l10
            temp.CSTCST_NOTE10RF = reader.ReadString();
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            //�������Œ[�������R�[�h
            temp.CSTCLM_SALESCNSTAXFRCPROCCDRF = reader.ReadInt32();
            // --- ADD END �c������ 2022/10/18 -----<<<<<
            //������T�u�R�[�h
            temp.CSTCLM_CUSTOMERSUBCODERF = reader.ReadString();
            //�����於��
            temp.CSTCLM_NAMERF = reader.ReadString();
            //�����於��2
            temp.CSTCLM_NAME2RF = reader.ReadString();
            //������h��
            temp.CSTCLM_HONORIFICTITLERF = reader.ReadString();
            //������J�i
            temp.CSTCLM_KANARF = reader.ReadString();
            //�����旪��
            temp.CSTCLM_CUSTOMERSNMRF = reader.ReadString();
            //�����揔���R�[�h
            temp.CSTCLM_OUTPUTNAMECODERF = reader.ReadInt32();
            //������X�֔ԍ�
            temp.CSTCLM_POSTNORF = reader.ReadString();
            //������Z��1�i�s���{���s��S�E�����E���j
            temp.CSTCLM_ADDRESS1RF = reader.ReadString();
            //������Z��3�i�Ԓn�j
            temp.CSTCLM_ADDRESS3RF = reader.ReadString();
            //������Z��4�i�A�p�[�g���́j
            temp.CSTCLM_ADDRESS4RF = reader.ReadString();
            //�����敪�̓R�[�h1
            temp.CSTCLM_CUSTANALYSCODE1RF = reader.ReadInt32();
            //�����敪�̓R�[�h2
            temp.CSTCLM_CUSTANALYSCODE2RF = reader.ReadInt32();
            //�����敪�̓R�[�h3
            temp.CSTCLM_CUSTANALYSCODE3RF = reader.ReadInt32();
            //�����敪�̓R�[�h4
            temp.CSTCLM_CUSTANALYSCODE4RF = reader.ReadInt32();
            //�����敪�̓R�[�h5
            temp.CSTCLM_CUSTANALYSCODE5RF = reader.ReadInt32();
            //�����敪�̓R�[�h6
            temp.CSTCLM_CUSTANALYSCODE6RF = reader.ReadInt32();
            //��������l1
            temp.CSTCLM_NOTE1RF = reader.ReadString();
            //��������l2
            temp.CSTCLM_NOTE2RF = reader.ReadString();
            //��������l3
            temp.CSTCLM_NOTE3RF = reader.ReadString();
            //��������l4
            temp.CSTCLM_NOTE4RF = reader.ReadString();
            //��������l5
            temp.CSTCLM_NOTE5RF = reader.ReadString();
            //��������l6
            temp.CSTCLM_NOTE6RF = reader.ReadString();
            //��������l7
            temp.CSTCLM_NOTE7RF = reader.ReadString();
            //��������l8
            temp.CSTCLM_NOTE8RF = reader.ReadString();
            //��������l9
            temp.CSTCLM_NOTE9RF = reader.ReadString();
            //��������l10
            temp.CSTCLM_NOTE10RF = reader.ReadString();
            //���Ж���1
            temp.COMPANYINFRF_COMPANYNAME1RF = reader.ReadString();
            //���Ж���2
            temp.COMPANYINFRF_COMPANYNAME2RF = reader.ReadString();
            //�X�֔ԍ�
            temp.COMPANYINFRF_POSTNORF = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.COMPANYINFRF_ADDRESS1RF = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.COMPANYINFRF_ADDRESS3RF = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.COMPANYINFRF_ADDRESS4RF = reader.ReadString();
            //���Гd�b�ԍ�1
            temp.COMPANYINFRF_COMPANYTELNO1RF = reader.ReadString();
            //���Гd�b�ԍ�2
            temp.COMPANYINFRF_COMPANYTELNO2RF = reader.ReadString();
            //���Гd�b�ԍ�3
            temp.COMPANYINFRF_COMPANYTELNO3RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��1
            temp.COMPANYINFRF_COMPANYTELTITLE1RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��2
            temp.COMPANYINFRF_COMPANYTELTITLE2RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��3
            temp.COMPANYINFRF_COMPANYTELTITLE3RF = reader.ReadString();
            //�����ݒ����R�[�h1
            temp.DEPOSITSTRF_DEPOSITSTKINDCD1RF = reader.ReadInt32();
            //�����ݒ����R�[�h2
            temp.DEPOSITSTRF_DEPOSITSTKINDCD2RF = reader.ReadInt32();
            //�����ݒ����R�[�h3
            temp.DEPOSITSTRF_DEPOSITSTKINDCD3RF = reader.ReadInt32();
            //�����ݒ����R�[�h4
            temp.DEPOSITSTRF_DEPOSITSTKINDCD4RF = reader.ReadInt32();
            //�����ݒ����R�[�h5
            temp.DEPOSITSTRF_DEPOSITSTKINDCD5RF = reader.ReadInt32();
            //�����ݒ����R�[�h6
            temp.DEPOSITSTRF_DEPOSITSTKINDCD6RF = reader.ReadInt32();
            //�����ݒ����R�[�h7
            temp.DEPOSITSTRF_DEPOSITSTKINDCD7RF = reader.ReadInt32();
            //�����ݒ����R�[�h8
            temp.DEPOSITSTRF_DEPOSITSTKINDCD8RF = reader.ReadInt32();
            //�����ݒ����R�[�h9
            temp.DEPOSITSTRF_DEPOSITSTKINDCD9RF = reader.ReadInt32();
            //�����ݒ����R�[�h10
            temp.DEPOSITSTRF_DEPOSITSTKINDCD10RF = reader.ReadInt32();
            //�������햼��1
            temp.DEPT01_MONEYKINDNAMERF = reader.ReadString();
            //�������z1
            temp.DEPT01_DEPOSITRF = reader.ReadInt64();
            //�������햼��2
            temp.DEPT02_MONEYKINDNAMERF = reader.ReadString();
            //�������z2
            temp.DEPT02_DEPOSITRF = reader.ReadInt64();
            //�������햼��3
            temp.DEPT03_MONEYKINDNAMERF = reader.ReadString();
            //�������z3
            temp.DEPT03_DEPOSITRF = reader.ReadInt64();
            //�������햼��4
            temp.DEPT04_MONEYKINDNAMERF = reader.ReadString();
            //�������z4
            temp.DEPT04_DEPOSITRF = reader.ReadInt64();
            //�������햼��5
            temp.DEPT05_MONEYKINDNAMERF = reader.ReadString();
            //�������z5
            temp.DEPT05_DEPOSITRF = reader.ReadInt64();
            //�������햼��6
            temp.DEPT06_MONEYKINDNAMERF = reader.ReadString();
            //�������z6
            temp.DEPT06_DEPOSITRF = reader.ReadInt64();
            //�������햼��7
            temp.DEPT07_MONEYKINDNAMERF = reader.ReadString();
            //�������z7
            temp.DEPT07_DEPOSITRF = reader.ReadInt64();
            //�������햼��8
            temp.DEPT08_MONEYKINDNAMERF = reader.ReadString();
            //�������z8
            temp.DEPT08_DEPOSITRF = reader.ReadInt64();
            //�������햼��9
            temp.DEPT09_MONEYKINDNAMERF = reader.ReadString();
            //�������z9
            temp.DEPT09_DEPOSITRF = reader.ReadInt64();
            //�������햼��10
            temp.DEPT10_MONEYKINDNAMERF = reader.ReadString();
            //�������z10
            temp.DEPT10_DEPOSITRF = reader.ReadInt64();
            //�v��N��������N
            temp.HADD_ADDUPDATEFYRF = reader.ReadInt32();
            //�v��N��������N��
            temp.HADD_ADDUPDATEFSRF = reader.ReadInt32();
            //�v��N�����a��N
            temp.HADD_ADDUPDATEFWRF = reader.ReadInt32();
            //�v��N������
            temp.HADD_ADDUPDATEFMRF = reader.ReadInt32();
            //�v��N������
            temp.HADD_ADDUPDATEFDRF = reader.ReadInt32();
            //�v��N��������
            temp.HADD_ADDUPDATEFGRF = reader.ReadString();
            //�v��N��������
            temp.HADD_ADDUPDATEFRRF = reader.ReadString();
            //�v��N�������e����(/)
            temp.HADD_ADDUPDATEFLSRF = reader.ReadString();
            //�v��N�������e����(.)
            temp.HADD_ADDUPDATEFLPRF = reader.ReadString();
            //�v��N�������e����(�N)
            temp.HADD_ADDUPDATEFLYRF = reader.ReadString();
            //�v��N�������e����(��)
            temp.HADD_ADDUPDATEFLMRF = reader.ReadString();
            //�v��N�������e����(��)
            temp.HADD_ADDUPDATEFLDRF = reader.ReadString();
            //�v��N������N
            temp.HADD_ADDUPYEARMONTHFYRF = reader.ReadInt32();
            //�v��N������N��
            temp.HADD_ADDUPYEARMONTHFSRF = reader.ReadInt32();
            //�v��N���a��N
            temp.HADD_ADDUPYEARMONTHFWRF = reader.ReadInt32();
            //�v��N����
            temp.HADD_ADDUPYEARMONTHFMRF = reader.ReadInt32();
            //�v��N������
            temp.HADD_ADDUPYEARMONTHFGRF = reader.ReadString();
            //�v��N������
            temp.HADD_ADDUPYEARMONTHFRRF = reader.ReadString();
            //�v��N�����e����(/)
            temp.HADD_ADDUPYEARMONTHFLSRF = reader.ReadString();
            //�v��N�����e����(.)
            temp.HADD_ADDUPYEARMONTHFLPRF = reader.ReadString();
            //�v��N�����e����(�N)
            temp.HADD_ADDUPYEARMONTHFLYRF = reader.ReadString();
            //�v��N�����e����(��)
            temp.HADD_ADDUPYEARMONTHFLMRF = reader.ReadString();
            //�����X�V�J�n�N��������N
            temp.HADD_STARTCADDUPUPDDATEFYRF = reader.ReadInt32();
            //�����X�V�J�n�N��������N��
            temp.HADD_STARTCADDUPUPDDATEFSRF = reader.ReadInt32();
            //�����X�V�J�n�N�����a��N
            temp.HADD_STARTCADDUPUPDDATEFWRF = reader.ReadInt32();
            //�����X�V�J�n�N������
            temp.HADD_STARTCADDUPUPDDATEFMRF = reader.ReadInt32();
            //�����X�V�J�n�N������
            temp.HADD_STARTCADDUPUPDDATEFDRF = reader.ReadInt32();
            //�����X�V�J�n�N��������
            temp.HADD_STARTCADDUPUPDDATEFGRF = reader.ReadString();
            //�����X�V�J�n�N��������
            temp.HADD_STARTCADDUPUPDDATEFRRF = reader.ReadString();
            //�����X�V�J�n�N�������e����(/)
            temp.HADD_STARTCADDUPUPDDATEFLSRF = reader.ReadString();
            //�����X�V�J�n�N�������e����(.)
            temp.HADD_STARTCADDUPUPDDATEFLPRF = reader.ReadString();
            //�����X�V�J�n�N�������e����(�N)
            temp.HADD_STARTCADDUPUPDDATEFLYRF = reader.ReadString();
            //�����X�V�J�n�N�������e����(��)
            temp.HADD_STARTCADDUPUPDDATEFLMRF = reader.ReadString();
            //�����X�V�J�n�N�������e����(��)
            temp.HADD_STARTCADDUPUPDDATEFLDRF = reader.ReadString();
            //���������s������N
            temp.HADD_BILLPRINTDATEFYRF = reader.ReadInt32();
            //���������s������N��
            temp.HADD_BILLPRINTDATEFSRF = reader.ReadInt32();
            //���������s���a��N
            temp.HADD_BILLPRINTDATEFWRF = reader.ReadInt32();
            //���������s����
            temp.HADD_BILLPRINTDATEFMRF = reader.ReadInt32();
            //���������s����
            temp.HADD_BILLPRINTDATEFDRF = reader.ReadInt32();
            //���������s������
            temp.HADD_BILLPRINTDATEFGRF = reader.ReadString();
            //���������s������
            temp.HADD_BILLPRINTDATEFRRF = reader.ReadString();
            //���������s�����e����(/)
            temp.HADD_BILLPRINTDATEFLSRF = reader.ReadString();
            //���������s�����e����(.)
            temp.HADD_BILLPRINTDATEFLPRF = reader.ReadString();
            //���������s�����e����(�N)
            temp.HADD_BILLPRINTDATEFLYRF = reader.ReadString();
            //���������s�����e����(��)
            temp.HADD_BILLPRINTDATEFLMRF = reader.ReadString();
            //���������s�����e����(��)
            temp.HADD_BILLPRINTDATEFLDRF = reader.ReadString();
            //�����\�������N
            temp.HADD_EXPECTEDDEPOSITDATEFYRF = reader.ReadInt32();
            //�����\�������N��
            temp.HADD_EXPECTEDDEPOSITDATEFSRF = reader.ReadInt32();
            //�����\����a��N
            temp.HADD_EXPECTEDDEPOSITDATEFWRF = reader.ReadInt32();
            //�����\�����
            temp.HADD_EXPECTEDDEPOSITDATEFMRF = reader.ReadInt32();
            //�����\�����
            temp.HADD_EXPECTEDDEPOSITDATEFDRF = reader.ReadInt32();
            //�����\�������
            temp.HADD_EXPECTEDDEPOSITDATEFGRF = reader.ReadString();
            //�����\�������
            temp.HADD_EXPECTEDDEPOSITDATEFRRF = reader.ReadString();
            //�����\������e����(/)
            temp.HADD_EXPECTEDDEPOSITDATEFLSRF = reader.ReadString();
            //�����\������e����(.)
            temp.HADD_EXPECTEDDEPOSITDATEFLPRF = reader.ReadString();
            //�����\������e����(�N)
            temp.HADD_EXPECTEDDEPOSITDATEFLYRF = reader.ReadString();
            //�����\������e����(��)
            temp.HADD_EXPECTEDDEPOSITDATEFLMRF = reader.ReadString();
            //�����\������e����(��)
            temp.HADD_EXPECTEDDEPOSITDATEFLDRF = reader.ReadString();
            //�����������
            temp.HADD_COLLECTCONDNMRF = reader.ReadString();
            //�������^�C�g��
            temp.HADD_DMDFORMTITLERF = reader.ReadString();
            //�������^�C�g���Q
            temp.HADD_DMDFORMTITLE2RF = reader.ReadString();
            //�������R�����g�P
            temp.HADD_DMDFORMCOMENT1RF = reader.ReadString();
            //�������R�����g�Q
            temp.HADD_DMDFORMCOMENT2RF = reader.ReadString();
            //�������R�����g�R
            temp.HADD_DMDFORMCOMENT3RF = reader.ReadString();
            //�������z(�l������)
            temp.HADD_DMDNRMLEXDISRF = reader.ReadInt64();
            //�������z(�萔������)
            temp.HADD_DMDNRMLEXFEERF = reader.ReadInt64();
            //�������z(�l���E�萔������)
            temp.HADD_DMDNRMLEXDISFEERF = reader.ReadInt64();
            //�������z(�l���{�萔��)
            temp.HADD_DMDNRMLSAMDISFEERF = reader.ReadInt64();
            //���񔄏�z(�Ŕ�)
            temp.HADD_THISSALESANDADJUSTRF = reader.ReadInt64();
            //���񔄏�����
            temp.HADD_THISTAXANDADJUSTRF = reader.ReadInt64();
            //���͔��s���t
            temp.HADD_ISSUEDAYRF = reader.ReadInt32();
            //���͔��s���t����N
            temp.HADD_ISSUEDAYFYRF = reader.ReadInt32();
            //���͔��s���t����N��
            temp.HADD_ISSUEDAYFSRF = reader.ReadInt32();
            //���͔��s���t�a��N
            temp.HADD_ISSUEDAYFWRF = reader.ReadInt32();
            //���͔��s���t��
            temp.HADD_ISSUEDAYFMRF = reader.ReadInt32();
            //���͔��s���t��
            temp.HADD_ISSUEDAYFDRF = reader.ReadInt32();
            //���͔��s���t����
            temp.HADD_ISSUEDAYFGRF = reader.ReadString();
            //���͔��s���t����
            temp.HADD_ISSUEDAYFRRF = reader.ReadString();
            //���͔��s���t���e����(/)
            temp.HADD_ISSUEDAYFLSRF = reader.ReadString();
            //���͔��s���t���e����(.)
            temp.HADD_ISSUEDAYFLPRF = reader.ReadString();
            //���͔��s���t���e����(�N)
            temp.HADD_ISSUEDAYFLYRF = reader.ReadString();
            //���͔��s���t���e����(��)
            temp.HADD_ISSUEDAYFLMRF = reader.ReadString();
            //���͔��s���t���e����(��)
            temp.HADD_ISSUEDAYFLDRF = reader.ReadString();
            //������Ӑ�T�u�R�[�h
            temp.CADD_CUSTOMERSUBCODERF = reader.ReadString();
            //������Ӑ於��
            temp.CADD_NAMERF = reader.ReadString();
            //������Ӑ於��2
            temp.CADD_NAME2RF = reader.ReadString();
            //������Ӑ�h��
            temp.CADD_HONORIFICTITLERF = reader.ReadString();
            //������Ӑ�J�i
            temp.CADD_KANARF = reader.ReadString();
            //������Ӑ旪��
            temp.CADD_CUSTOMERSNMRF = reader.ReadString();
            //������Ӑ揔���R�[�h
            temp.CADD_OUTPUTNAMECODERF = reader.ReadInt32();
            //������Ӑ�X�֔ԍ�
            temp.CADD_POSTNORF = reader.ReadString();
            //������Ӑ�Z��1�i�s���{���s��S�E�����E���j
            temp.CADD_ADDRESS1RF = reader.ReadString();
            //������Ӑ�Z��3�i�Ԓn�j
            temp.CADD_ADDRESS3RF = reader.ReadString();
            //������Ӑ�Z��4�i�A�p�[�g���́j
            temp.CADD_ADDRESS4RF = reader.ReadString();
            //������Ӑ敪�̓R�[�h1
            temp.CADD_CUSTANALYSCODE1RF = reader.ReadInt32();
            //������Ӑ敪�̓R�[�h2
            temp.CADD_CUSTANALYSCODE2RF = reader.ReadInt32();
            //������Ӑ敪�̓R�[�h3
            temp.CADD_CUSTANALYSCODE3RF = reader.ReadInt32();
            //������Ӑ敪�̓R�[�h4
            temp.CADD_CUSTANALYSCODE4RF = reader.ReadInt32();
            //������Ӑ敪�̓R�[�h5
            temp.CADD_CUSTANALYSCODE5RF = reader.ReadInt32();
            //������Ӑ敪�̓R�[�h6
            temp.CADD_CUSTANALYSCODE6RF = reader.ReadInt32();
            //������Ӑ���l1
            temp.CADD_NOTE1RF = reader.ReadString();
            //������Ӑ���l2
            temp.CADD_NOTE2RF = reader.ReadString();
            //������Ӑ���l3
            temp.CADD_NOTE3RF = reader.ReadString();
            //������Ӑ���l4
            temp.CADD_NOTE4RF = reader.ReadString();
            //������Ӑ���l5
            temp.CADD_NOTE5RF = reader.ReadString();
            //������Ӑ���l6
            temp.CADD_NOTE6RF = reader.ReadString();
            //������Ӑ���l7
            temp.CADD_NOTE7RF = reader.ReadString();
            //������Ӑ���l8
            temp.CADD_NOTE8RF = reader.ReadString();
            //������Ӑ���l9
            temp.CADD_NOTE9RF = reader.ReadString();
            //������Ӑ���l10
            temp.CADD_NOTE10RF = reader.ReadString();
            //����p���Ӑ於�́i��i�j
            temp.CADD_PRINTCUSTOMERNAME1RF = reader.ReadString();
            //����p���Ӑ於�́i���i�j
            temp.CADD_PRINTCUSTOMERNAME2RF = reader.ReadString();
            //����p���Ӑ於�́i���i�j�{�h��
            temp.CADD_PRINTCUSTOMERNAME2HNRF = reader.ReadString();
            //�W�����敪����
            temp.CSTCST_COLLECTMONEYNAMERF = reader.ReadString();
            //�W����
            temp.CSTCST_COLLECTMONEYDAYRF = reader.ReadInt32();
            //������Ӑ�R�[�h
            temp.CADD_CUSTOMERCODERF = reader.ReadInt32();
            //������Ӑ�d�b�ԍ��i����j
            temp.CADD_HOMETELNORF = reader.ReadString();
            //������Ӑ�d�b�ԍ��i�Ζ���j
            temp.CADD_OFFICETELNORF = reader.ReadString();
            //������Ӑ�d�b�ԍ��i�g�сj
            temp.CADD_PORTABLETELNORF = reader.ReadString();
            //������Ӑ�FAX�ԍ��i����j
            temp.CADD_HOMEFAXNORF = reader.ReadString();
            //������Ӑ�FAX�ԍ��i�Ζ���j
            temp.CADD_OFFICEFAXNORF = reader.ReadString();
            //������Ӑ�d�b�ԍ��i���̑��j
            temp.CADD_OTHERSTELNORF = reader.ReadString();
            //���Ӑ�d�b�ԍ��i����j
            temp.CSTCST_HOMETELNORF = reader.ReadString();
            //���Ӑ�d�b�ԍ��i�Ζ���j
            temp.CSTCST_OFFICETELNORF = reader.ReadString();
            //���Ӑ�d�b�ԍ��i�g�сj
            temp.CSTCST_PORTABLETELNORF = reader.ReadString();
            //���Ӑ�FAX�ԍ��i����j
            temp.CSTCST_HOMEFAXNORF = reader.ReadString();
            //���Ӑ�FAX�ԍ��i�Ζ���j
            temp.CSTCST_OFFICEFAXNORF = reader.ReadString();
            //���Ӑ�d�b�ԍ��i���̑��j
            temp.CSTCST_OTHERSTELNORF = reader.ReadString();
            //������d�b�ԍ��i����j
            temp.CSTCLM_HOMETELNORF = reader.ReadString();
            //������d�b�ԍ��i�Ζ���j
            temp.CSTCLM_OFFICETELNORF = reader.ReadString();
            //������d�b�ԍ��i�g�сj
            temp.CSTCLM_PORTABLETELNORF = reader.ReadString();
            //������FAX�ԍ��i����j
            temp.CSTCLM_HOMEFAXNORF = reader.ReadString();
            //������FAX�ԍ��i�Ζ���j
            temp.CSTCLM_OFFICEFAXNORF = reader.ReadString();
            //������d�b�ԍ��i���̑��j
            temp.CSTCLM_OTHERSTELNORF = reader.ReadString();
            //���񔄏�z(�ō�)
            temp.HADD_THISSALESANDADJUSTTAXINCRF = reader.ReadInt64();
            //������W�����敪����
            temp.CSTCLM_COLLECTMONEYNAMERF = reader.ReadString();
            //������W����
            temp.CSTCLM_COLLECTMONEYDAYRF = reader.ReadInt32();
            //���ы��_�R�[�h
            temp.CUSTDMDPRCRF_RESULTSSECTCDRF = reader.ReadString();
            //���Ӑ於�P�{���Ӑ於�Q
            temp.HADD_PRINTCUSTOMERNAMEJOIN12RF = reader.ReadString();
            //���Ӑ於�P�{���Ӑ於�Q�{�h��
            temp.HADD_PRINTCUSTOMERNAMEJOIN12HNRF = reader.ReadString();
            //���Ж��P�i�O���j
            temp.HADD_PRINTENTERPRISENAME1FHRF = reader.ReadString();
            //���Ж��P�i�㔼�j
            temp.HADD_PRINTENTERPRISENAME1LHRF = reader.ReadString();
            //���Ж��Q�i�O���j
            temp.HADD_PRINTENTERPRISENAME2FHRF = reader.ReadString();
            //���Ж��Q�i�㔼�j
            temp.HADD_PRINTENTERPRISENAME2LHRF = reader.ReadString();
            //����TEL�\������
            temp.ALITMDSPNMRF_HOMETELNODSPNAMERF = reader.ReadString();
            //�Ζ���TEL�\������
            temp.ALITMDSPNMRF_OFFICETELNODSPNAMERF = reader.ReadString();
            //�g��TEL�\������
            temp.ALITMDSPNMRF_MOBILETELNODSPNAMERF = reader.ReadString();
            //����FAX�\������
            temp.ALITMDSPNMRF_HOMEFAXNODSPNAMERF = reader.ReadString();
            //�Ζ���FAX�\������
            temp.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF = reader.ReadString();
            //���̑�TEL�\������
            temp.ALITMDSPNMRF_OTHERTELNODSPNAMERF = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.CSTCLM_SALESAREACODERF = reader.ReadInt32();
            //�ڋq�S���]�ƈ��R�[�h
            temp.CSTCLM_CUSTOMERAGENTCDRF = reader.ReadString();
            //�W���S���]�ƈ��R�[�h
            temp.CSTCLM_BILLCOLLECTERCDRF = reader.ReadString();
            //���ڋq�S���]�ƈ��R�[�h
            temp.CSTCLM_OLDCUSTOMERAGENTCDRF = reader.ReadString();
            //�ڋq�S���ύX��
            temp.CSTCLM_CUSTAGENTCHGDATERF = reader.ReadInt32();
            //�������ԍ�
            temp.CUSTDMDPRCRF_BILLNORF = reader.ReadInt32();
            //�W�����敪�R�[�h
            temp.CSTCST_COLLECTMONEYCODERF = reader.ReadInt32();

            //������W�����敪�R�[�h
            temp.CSTCLM_COLLECTMONEYCODERF = reader.ReadInt32();

            //����
            temp.CSTCLM_TOTALDAYRF = reader.ReadInt32();
            //�ŗ�1�^�C�g��
            temp.TitleTaxRate1 = reader.ReadInt32();
            //�ŗ�2�^�C�g��
            temp.TitleTaxRate2 = reader.ReadInt32();
            // �ŗ�(1)�Ώۋ��z���v(�Ŕ���)
            temp.TotalThisTimeSalesTaxExRate1 = reader.ReadDouble();
            // �ŗ�(2)�Ώۋ��z���v(�Ŕ���)
            temp.TotalThisTimeSalesTaxExRate2 = reader.ReadDouble();
            // �Ŋz(1)
            temp.TotalThisTimeTaxRate1 = reader.ReadDouble();
            // �Ŋz(2)
            temp.TotalThisTimeTaxRate2 = reader.ReadDouble();


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
        /// <returns>EBooksFrePBillHeadWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EBooksFrePBillHeadWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                EBooksFrePBillHeadWork temp = GetEBooksFrePBillHeadWork( reader, serInfo );
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
                    retValue = (EBooksFrePBillHeadWork[])lst.ToArray( typeof( EBooksFrePBillHeadWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
