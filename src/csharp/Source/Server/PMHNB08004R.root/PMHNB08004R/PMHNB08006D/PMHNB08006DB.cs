using System;
using System.Collections;

//using Broadleaf.Library.Data; // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      ���R���[����`�[�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[����`�[�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/02/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009.07.24 ���m add �I�[�g�o�b�N�X�ݒ�ǉ�</br>
    /// <br>Update Note      :   2010/03/01 30531  ��� �r��</br>
    /// <br>                 :   Mantis�y�z���Ӑ�}�X�^�̒[�������ݒ�(�R����)�ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2010/03/24 22018  ��� ���b</br>
    /// <br>                 :   �p�q�R�[�h����Ή��ׁ̈A���Ӑ�}�X�^�̂p�q�R�[�h�󎚋敪��ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2010/07/06 30517 �Ė� �x��</br>
    /// <br>                 :   QR�R�[�h�g�у��[���Ή�</br>
    /// <br>Update Note      :   2011/08/17 caohh</br>
    /// <br>                 :   �����[�g�`���F�`�[P001�Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePSalesSlipWork
    {
        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _sALESSLIPRF_ACPTANODRSTATUSRF;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _sALESSLIPRF_SALESSLIPNUMRF = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����ӁF�`�[�Ɉ󎚂��Ȃ��B���O�C�����_�B</remarks>
        private string _sALESSLIPRF_SECTIONCODERF = "";

        /// <summary>����R�[�h</summary>
        private Int32 _sALESSLIPRF_SUBSECTIONCODERF;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _sALESSLIPRF_DEBITNOTEDIVRF;

        /// <summary>�ԍ��A������`�[�ԍ�</summary>
        /// <remarks>�ԍ��̑��������`�[�ԍ�</remarks>
        private string _sALESSLIPRF_DEBITNLNKSALESSLNUMRF = "";

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _sALESSLIPRF_SALESSLIPCDRF;

        /// <summary>���㏤�i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</remarks>
        private Int32 _sALESSLIPRF_SALESGOODSCDRF;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _sALESSLIPRF_ACCRECDIVCDRF;

        /// <summary>�`�[�������t</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _sALESSLIPRF_SEARCHSLIPDATERF;

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESSLIPRF_SHIPMENTDAYRF;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_SALESDATERF;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private Int32 _sALESSLIPRF_ADDUPADATERF;

        /// <summary>�����敪</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private Int32 _sALESSLIPRF_DELAYPAYMENTDIVRF;

        /// <summary>���Ϗ��ԍ�</summary>
        private string _sALESSLIPRF_ESTIMATEFORMNORF = "";

        /// <summary>���ϋ敪</summary>
        /// <remarks>1:�ʏ팩�ρ@2:�P������</remarks>
        private Int32 _sALESSLIPRF_ESTIMATEDIVIDERF;

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

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF;

        /// <summary>���z�\���|���K�p�敪</summary>
        /// <remarks>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</remarks>
        private Int32 _sALESSLIPRF_TTLAMNTDISPRATEAPYRF;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXINCRF;

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _sALESSLIPRF_SALESTOTALTAXEXCRF;

        /// <summary>���㏬�v�i�ō��݁j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXINCRF;

        /// <summary>���㏬�v�i�Ŕ����j</summary>
        /// <remarks>�l����̖��׋��z�̍��v�i��ېŊ܂܂��j</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXEXCRF;

        /// <summary>���㏬�v�i�Łj</summary>
        /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
        private Int64 _sALESSLIPRF_SALESSUBTOTALTAXRF;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESOUTTAXRF;

        /// <summary>������őΏۊz</summary>
        /// <remarks>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESINTAXRF;

        /// <summary>���㏬�v��ېőΏۊz</summary>
        /// <remarks>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</remarks>
        private Int64 _sALESSLIPRF_SALSUBTTLSUBTOTAXFRERF;

        /// <summary>������z����Ŋz�i���Łj</summary>
        /// <remarks>�l���O�̓��ŏ��i�̏����</remarks>
        private Int64 _sALESSLIPRF_SALAMNTCONSTAXINCLURF;

        /// <summary>����l�����z�v�i�Ŕ����j</summary>
        private Int64 _sALESSLIPRF_SALESDISTTLTAXEXCRF;

        /// <summary>����l���O�őΏۊz���v</summary>
        /// <remarks>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESDISOUTTAXRF;

        /// <summary>����l�����őΏۊz���v</summary>
        /// <remarks>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</remarks>
        private Int64 _sALESSLIPRF_ITDEDSALESDISINTAXRF;

        /// <summary>����l������Ŋz�i�O�Łj</summary>
        /// <remarks>�O�ŏ��i�l���̏���Ŋz</remarks>
        private Int64 _sALESSLIPRF_SALESDISOUTTAXRF;

        /// <summary>����l������Ŋz�i���Łj</summary>
        private Int64 _sALESSLIPRF_SALESDISTTLTAXINCLURF;

        /// <summary>�������z�v</summary>
        private Int64 _sALESSLIPRF_TOTALCOSTRF;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _sALESSLIPRF_CONSTAXLAYMETHODRF;

        /// <summary>����Őŗ�</summary>
        private Double _sALESSLIPRF_CONSTAXRATERF;

        /// <summary>�[�������敪</summary>
        /// <remarks>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</remarks>
        private Int32 _sALESSLIPRF_FRACTIONPROCCDRF;

        /// <summary>���|�����</summary>
        private Int64 _sALESSLIPRF_ACCRECCONSTAXRF;

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

        /// <summary>�����旪��</summary>
        private string _sALESSLIPRF_CLAIMSNMRF = "";

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

        /// <summary>�[�i��X�֔ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _sALESSLIPRF_ADDRESSEEPOSTNORF = "";

        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _sALESSLIPRF_ADDRESSEEADDR1RF = "";

        /// <summary>�[�i��Z��3(�Ԓn)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _sALESSLIPRF_ADDRESSEEADDR3RF = "";

        /// <summary>�[�i��Z��4(�A�p�[�g����)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _sALESSLIPRF_ADDRESSEEADDR4RF = "";

        /// <summary>�[�i��d�b�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _sALESSLIPRF_ADDRESSEETELNORF = "";

        /// <summary>�[�i��FAX�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _sALESSLIPRF_ADDRESSEEFAXNORF = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ�</remarks>
        private string _sALESSLIPRF_PARTYSALESLIPNUMRF = "";

        /// <summary>�`�[���l</summary>
        private string _sALESSLIPRF_SLIPNOTERF = "";

        /// <summary>�`�[���l�Q</summary>
        private string _sALESSLIPRF_SLIPNOTE2RF = "";

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _sALESSLIPRF_RETGOODSREASONDIVRF;

        /// <summary>�ԕi���R</summary>
        private string _sALESSLIPRF_RETGOODSREASONRF = "";

        /// <summary>���W������</summary>
        /// <remarks>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _sALESSLIPRF_REGIPROCDATERF;

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _sALESSLIPRF_CASHREGISTERNORF;

        /// <summary>POS���V�[�g�ԍ�</summary>
        /// <remarks>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</remarks>
        private Int32 _sALESSLIPRF_POSRECEIPTNORF;

        /// <summary>���׍s��</summary>
        private Int32 _sALESSLIPRF_DETAILROWCOUNTRF;

        /// <summary>�d�c�h���M��</summary>
        /// <remarks>YYYYMMDD �iErectricDataInterface�j</remarks>
        private Int32 _sALESSLIPRF_EDISENDDATERF;

        /// <summary>�d�c�h�捞��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESSLIPRF_EDITAKEINDATERF;

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _sALESSLIPRF_UOEREMARK1RF = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _sALESSLIPRF_UOEREMARK2RF = "";

        /// <summary>�`�[���s�ϋ敪</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private Int32 _sALESSLIPRF_SLIPPRINTFINISHCDRF;

        /// <summary>����`�[���s��</summary>
        private Int32 _sALESSLIPRF_SALESSLIPPRINTDATERF;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _sALESSLIPRF_BUSINESSTYPECODERF;

        /// <summary>�Ǝ햼��</summary>
        private string _sALESSLIPRF_BUSINESSTYPENAMERF = "";

        /// <summary>�����ԍ�</summary>
        /// <remarks>����`����"��"�̎��ɃZ�b�g</remarks>
        private string _sALESSLIPRF_ORDERNUMBERRF = "";

        /// <summary>�[�i�敪</summary>
        /// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
        private Int32 _sALESSLIPRF_DELIVEREDGOODSDIVRF;

        /// <summary>�[�i�敪����</summary>
        private string _sALESSLIPRF_DELIVEREDGOODSDIVNMRF = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _sALESSLIPRF_SALESAREACODERF;

        /// <summary>�̔��G���A����</summary>
        private string _sALESSLIPRF_SALESAREANAMERF = "";

        /// <summary>�݌ɏ��i���v���z�i�Ŕ��j</summary>
        /// <remarks>�݌Ɏ��敪���O�̖��׋��z�̏W�v</remarks>
        private Int64 _sALESSLIPRF_STOCKGOODSTTLTAXEXCRF;

        /// <summary>�������i���v���z�i�Ŕ��j</summary>
        /// <remarks>���i�������O�̖��׋��z�̏W�v</remarks>
        private Int64 _sALESSLIPRF_PUREGOODSTTLTAXEXCRF;

        /// <summary>�艿����敪</summary>
        private Int32 _sALESSLIPRF_LISTPRICEPRINTDIVRF;

        /// <summary>�����\���敪�P</summary>
        /// <remarks>�ʏ�@�@0:����@1:�a��</remarks>
        private Int32 _sALESSLIPRF_ERANAMEDISPCD1RF;

        /// <summary>���Ϗ���ŋ敪</summary>
        /// <remarks>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</remarks>
        private Int32 _sALESSLIPRF_ESTIMATAXDIVCDRF;

        /// <summary>���Ϗ�����敪</summary>
        private Int32 _sALESSLIPRF_ESTIMATEFORMPRTCDRF;

        /// <summary>���ό���</summary>
        private string _sALESSLIPRF_ESTIMATESUBJECTRF = "";

        /// <summary>�r���P</summary>
        private string _sALESSLIPRF_FOOTNOTES1RF = "";

        /// <summary>�r���Q</summary>
        private string _sALESSLIPRF_FOOTNOTES2RF = "";

        /// <summary>���σ^�C�g���P</summary>
        private string _sALESSLIPRF_ESTIMATETITLE1RF = "";

        /// <summary>���σ^�C�g���Q</summary>
        private string _sALESSLIPRF_ESTIMATETITLE2RF = "";

        /// <summary>���σ^�C�g���R</summary>
        private string _sALESSLIPRF_ESTIMATETITLE3RF = "";

        /// <summary>���σ^�C�g���S</summary>
        private string _sALESSLIPRF_ESTIMATETITLE4RF = "";

        /// <summary>���σ^�C�g���T</summary>
        private string _sALESSLIPRF_ESTIMATETITLE5RF = "";

        /// <summary>���ϔ��l�P</summary>
        private string _sALESSLIPRF_ESTIMATENOTE1RF = "";

        /// <summary>���ϔ��l�Q</summary>
        private string _sALESSLIPRF_ESTIMATENOTE2RF = "";

        /// <summary>���ϔ��l�R</summary>
        private string _sALESSLIPRF_ESTIMATENOTE3RF = "";

        /// <summary>���ϔ��l�S</summary>
        private string _sALESSLIPRF_ESTIMATENOTE4RF = "";

        /// <summary>���ϔ��l�T</summary>
        private string _sALESSLIPRF_ESTIMATENOTE5RF = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sECINFOSETRF_SECTIONGUIDENMRF = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sECINFOSETRF_SECTIONGUIDESNMRF = "";

        /// <summary>���Ж��̃R�[�h1</summary>
        private Int32 _sECINFOSETRF_COMPANYNAMECD1RF;

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

        /// <summary>�摜���敪</summary>
        /// <remarks>10:���Љ摜,20:POS�Ŏg�p����摜</remarks>
        private Int32 _cOMPANYNMRF_IMAGEINFODIVRF;

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

        /// <summary>���Љ摜</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

        /// <summary>���喼��</summary>
        private string _sUBSECTIONRF_SUBSECTIONNAMERF = "";

        /// <summary>������͎҃J�i</summary>
        private string _eMPINP_KANARF = "";

        /// <summary>������͎ҒZ�k����</summary>
        private string _eMPINP_SHORTNAMERF = "";

        /// <summary>��t�]�ƈ��J�i</summary>
        private string _eMPFRT_KANARF = "";

        /// <summary>��t�]�ƈ��Z�k����</summary>
        private string _eMPFRT_SHORTNAMERF = "";

        /// <summary>�̔��]�ƈ��J�i</summary>
        private string _eMPSAL_KANARF = "";

        /// <summary>�̔��]�ƈ��Z�k����</summary>
        private string _eMPSAL_SHORTNAMERF = "";

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

        /// <summary>�[����T�u�R�[�h</summary>
        private string _cSTADR_CUSTOMERSUBCODERF = "";

        /// <summary>�[���於��</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTADR_NAMERF = "";

        /// <summary>�[���於��2</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTADR_NAME2RF = "";

        /// <summary>�[����h��</summary>
        private string _cSTADR_HONORIFICTITLERF = "";

        /// <summary>�[����J�i</summary>
        private string _cSTADR_KANARF = "";

        /// <summary>�[���旪��</summary>
        private string _cSTADR_CUSTOMERSNMRF = "";

        /// <summary>�[���揔���R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _cSTADR_OUTPUTNAMECODERF;

        /// <summary>�[���敪�̓R�[�h1</summary>
        private Int32 _cSTADR_CUSTANALYSCODE1RF;

        /// <summary>�[���敪�̓R�[�h2</summary>
        private Int32 _cSTADR_CUSTANALYSCODE2RF;

        /// <summary>�[���敪�̓R�[�h3</summary>
        private Int32 _cSTADR_CUSTANALYSCODE3RF;

        /// <summary>�[���敪�̓R�[�h4</summary>
        private Int32 _cSTADR_CUSTANALYSCODE4RF;

        /// <summary>�[���敪�̓R�[�h5</summary>
        private Int32 _cSTADR_CUSTANALYSCODE5RF;

        /// <summary>�[���敪�̓R�[�h6</summary>
        private Int32 _cSTADR_CUSTANALYSCODE6RF;

        /// <summary>�[������l1</summary>
        private string _cSTADR_NOTE1RF = "";

        /// <summary>�[������l2</summary>
        private string _cSTADR_NOTE2RF = "";

        /// <summary>�[������l3</summary>
        private string _cSTADR_NOTE3RF = "";

        /// <summary>�[������l4</summary>
        private string _cSTADR_NOTE4RF = "";

        /// <summary>�[������l5</summary>
        private string _cSTADR_NOTE5RF = "";

        /// <summary>�[������l6</summary>
        private string _cSTADR_NOTE6RF = "";

        /// <summary>�[������l7</summary>
        private string _cSTADR_NOTE7RF = "";

        /// <summary>�[������l8</summary>
        private string _cSTADR_NOTE8RF = "";

        /// <summary>�[������l9</summary>
        private string _cSTADR_NOTE9RF = "";

        /// <summary>�[������l10</summary>
        private string _cSTADR_NOTE10RF = "";

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

        /// <summary>�󒍃X�e�[�^�X����</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private string _hADD_ACPTANODRSTNMRF = "";

        /// <summary>�ԓ`�敪����</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private string _hADD_DEBITNOTEDIVNMRF = "";

        /// <summary>����`�[�敪����</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private string _hADD_SALESSLIPNMRF = "";

        /// <summary>���㏤�i�敪����</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</remarks>
        private string _hADD_SALESGOODSNMRF = "";

        /// <summary>���|�敪����</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private string _hADD_ACCRECDIVNMRF = "";

        /// <summary>�����敪����</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private string _hADD_DELAYPAYMENTDIVNMRF = "";

        /// <summary>���ϋ敪����</summary>
        /// <remarks>1:�ʏ팩�ρ@2:�P������</remarks>
        private string _hADD_ESTIMATEDIVIDENMRF = "";

        /// <summary>����œ]�ŕ�������</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private string _hADD_CONSTAXLAYMETHODNMRF = "";

        /// <summary>���������敪����</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private string _hADD_AUTODEPOSITNMRF = "";

        /// <summary>�`�[���s�ϋ敪����</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private string _hADD_SLIPPRINTFINISHNMRF = "";

        /// <summary>�ꎮ�`�[�敪����</summary>
        /// <remarks>0:�ʏ�`�[,1:�ꎮ�`�[</remarks>
        private string _hADD_COMPLETENMRF = "";

        /// <summary>(�擪)�ԗ��Ǘ��ԍ�</summary>
        /// <remarks>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</remarks>
        private Int32 _hADD_CARMNGNORF;

        /// <summary>(�擪)���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _hADD_CARMNGCODERF = "";

        /// <summary>(�擪)���^�������ԍ�</summary>
        private Int32 _hADD_NUMBERPLATE1CODERF;

        /// <summary>(�擪)���^�����ǖ���</summary>
        private string _hADD_NUMBERPLATE1NAMERF = "";

        /// <summary>(�擪)�ԗ��o�^�ԍ��i��ʁj</summary>
        private string _hADD_NUMBERPLATE2RF = "";

        /// <summary>(�擪)�ԗ��o�^�ԍ��i�J�i�j</summary>
        private string _hADD_NUMBERPLATE3RF = "";

        /// <summary>(�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        private Int32 _hADD_NUMBERPLATE4RF;

        /// <summary>(�擪)���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _hADD_FIRSTENTRYDATERF;

        /// <summary>(�擪)���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _hADD_MAKERCODERF;

        /// <summary>(�擪)���[�J�[�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _hADD_MAKERFULLNAMERF = "";

        /// <summary>(�擪)�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _hADD_MODELCODERF;

        /// <summary>(�擪)�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _hADD_MODELSUBCODERF;

        /// <summary>(�擪)�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _hADD_MODELFULLNAMERF = "";

        /// <summary>(�擪)�r�K�X�L��</summary>
        private string _hADD_EXHAUSTGASSIGNRF = "";

        /// <summary>(�擪)�V���[�Y�^��</summary>
        private string _hADD_SERIESMODELRF = "";

        /// <summary>(�擪)�^���i�ޕʋL���j</summary>
        private string _hADD_CATEGORYSIGNMODELRF = "";

        /// <summary>(�擪)�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _hADD_FULLMODELRF = "";

        /// <summary>(�擪)�^���w��ԍ�</summary>
        private Int32 _hADD_MODELDESIGNATIONNORF;

        /// <summary>(�擪)�ޕʔԍ�</summary>
        private Int32 _hADD_CATEGORYNORF;

        /// <summary>(�擪)�ԑ�^��</summary>
        private string _hADD_FRAMEMODELRF = "";

        /// <summary>(�擪)�ԑ�ԍ�</summary>
        /// <remarks>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</remarks>
        private string _hADD_FRAMENORF = "";

        /// <summary>(�擪)�ԑ�ԍ��i�����p�j</summary>
        /// <remarks>PM7�̎ԑ�ԍ��Ɠ���</remarks>
        private Int32 _hADD_SEARCHFRAMENORF;

        /// <summary>(�擪)�G���W���^������</summary>
        /// <remarks>�G���W������</remarks>
        private string _hADD_ENGINEMODELNMRF = "";

        /// <summary>(�擪)�֘A�^��</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _hADD_RELEVANCEMODELRF = "";

        /// <summary>(�擪)�T�u�Ԗ��R�[�h</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private Int32 _hADD_SUBCARNMCDRF;

        /// <summary>(�擪)�^���O���[�h����</summary>
        /// <remarks>���T�C�N���n�Ŏg�p</remarks>
        private string _hADD_MODELGRADESNAMERF = "";

        /// <summary>(�擪)�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _hADD_COLORCODERF = "";

        /// <summary>(�擪)�J���[����1</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        private string _hADD_COLORNAME1RF = "";

        /// <summary>(�擪)�g�����R�[�h</summary>
        private string _hADD_TRIMCODERF = "";

        /// <summary>(�擪)�g��������</summary>
        private string _hADD_TRIMNAMERF = "";

        /// <summary>(�擪)�ԗ����s����</summary>
        private Int32 _hADD_MILEAGERF;

        /// <summary>�v�����^�Ǘ�No</summary>
        /// <remarks>�����̃��R�[�h�̓`�[���������v�����^�̌��茋��(default)</remarks>
        private Int32 _hADD_PRINTERMNGNORF;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�����̃��R�[�h�̓`�[���������`�[�^�C�v�̌��茋��(default)</remarks>
        private string _hADD_SLIPPRTSETPAPERIDRF = "";

        /// <summary>���Д��l�P</summary>
        private string _hADD_NOTE1RF = "";

        /// <summary>���Д��l�Q</summary>
        private string _hADD_NOTE2RF = "";

        /// <summary>���Д��l�R</summary>
        private string _hADD_NOTE3RF = "";

        /// <summary>�Ĕ��s�}�[�N</summary>
        /// <remarks>�S�p�R�����܂�</remarks>
        private string _hADD_REISSUEMARKRF = "";

        /// <summary>�Q�l����ň󎚖���</summary>
        /// <remarks>�S�p�T�����܂�</remarks>
        private string _hADD_REFCONSTAXPRTNMRF = "";

        /// <summary>������� ��</summary>
        /// <remarks>HH</remarks>
        private Int32 _hADD_PRINTTIMEHOURRF;

        /// <summary>������� ��</summary>
        /// <remarks>MM</remarks>
        private Int32 _hADD_PRINTTIMEMINUTERF;

        /// <summary>������� �b</summary>
        /// <remarks>DD</remarks>
        private Int32 _hADD_PRINTTIMESECONDRF;

        /// <summary>�`�[�������t����N</summary>
        private Int32 _hADD_SEARCHSLIPDATEFYRF;

        /// <summary>�`�[�������t����N��</summary>
        private Int32 _hADD_SEARCHSLIPDATEFSRF;

        /// <summary>�`�[�������t�a��N</summary>
        private Int32 _hADD_SEARCHSLIPDATEFWRF;

        /// <summary>�`�[�������t��</summary>
        private Int32 _hADD_SEARCHSLIPDATEFMRF;

        /// <summary>�`�[�������t��</summary>
        private Int32 _hADD_SEARCHSLIPDATEFDRF;

        /// <summary>�`�[�������t����</summary>
        private string _hADD_SEARCHSLIPDATEFGRF = "";

        /// <summary>�`�[�������t����</summary>
        private string _hADD_SEARCHSLIPDATEFRRF = "";

        /// <summary>�`�[�������t���e����(/)</summary>
        private string _hADD_SEARCHSLIPDATEFLSRF = "";

        /// <summary>�`�[�������t���e����(.)</summary>
        private string _hADD_SEARCHSLIPDATEFLPRF = "";

        /// <summary>�`�[�������t���e����(�N)</summary>
        private string _hADD_SEARCHSLIPDATEFLYRF = "";

        /// <summary>�`�[�������t���e����(��)</summary>
        private string _hADD_SEARCHSLIPDATEFLMRF = "";

        /// <summary>�`�[�������t���e����(��)</summary>
        private string _hADD_SEARCHSLIPDATEFLDRF = "";

        /// <summary>�o�ד��t����N</summary>
        private Int32 _hADD_SHIPMENTDAYFYRF;

        /// <summary>�o�ד��t����N��</summary>
        private Int32 _hADD_SHIPMENTDAYFSRF;

        /// <summary>�o�ד��t�a��N</summary>
        private Int32 _hADD_SHIPMENTDAYFWRF;

        /// <summary>�o�ד��t��</summary>
        private Int32 _hADD_SHIPMENTDAYFMRF;

        /// <summary>�o�ד��t��</summary>
        private Int32 _hADD_SHIPMENTDAYFDRF;

        /// <summary>�o�ד��t����</summary>
        private string _hADD_SHIPMENTDAYFGRF = "";

        /// <summary>�o�ד��t����</summary>
        private string _hADD_SHIPMENTDAYFRRF = "";

        /// <summary>�o�ד��t���e����(/)</summary>
        private string _hADD_SHIPMENTDAYFLSRF = "";

        /// <summary>�o�ד��t���e����(.)</summary>
        private string _hADD_SHIPMENTDAYFLPRF = "";

        /// <summary>�o�ד��t���e����(�N)</summary>
        private string _hADD_SHIPMENTDAYFLYRF = "";

        /// <summary>�o�ד��t���e����(��)</summary>
        private string _hADD_SHIPMENTDAYFLMRF = "";

        /// <summary>�o�ד��t���e����(��)</summary>
        private string _hADD_SHIPMENTDAYFLDRF = "";

        /// <summary>������t����N</summary>
        private Int32 _hADD_SALESDATEFYRF;

        /// <summary>������t����N��</summary>
        private Int32 _hADD_SALESDATEFSRF;

        /// <summary>������t�a��N</summary>
        private Int32 _hADD_SALESDATEFWRF;

        /// <summary>������t��</summary>
        private Int32 _hADD_SALESDATEFMRF;

        /// <summary>������t��</summary>
        private Int32 _hADD_SALESDATEFDRF;

        /// <summary>������t����</summary>
        private string _hADD_SALESDATEFGRF = "";

        /// <summary>������t����</summary>
        private string _hADD_SALESDATEFRRF = "";

        /// <summary>������t���e����(/)</summary>
        private string _hADD_SALESDATEFLSRF = "";

        /// <summary>������t���e����(.)</summary>
        private string _hADD_SALESDATEFLPRF = "";

        /// <summary>������t���e����(�N)</summary>
        private string _hADD_SALESDATEFLYRF = "";

        /// <summary>������t���e����(��)</summary>
        private string _hADD_SALESDATEFLMRF = "";

        /// <summary>������t���e����(��)</summary>
        private string _hADD_SALESDATEFLDRF = "";

        /// <summary>�v����t����N</summary>
        private Int32 _hADD_ADDUPADATEFYRF;

        /// <summary>�v����t����N��</summary>
        private Int32 _hADD_ADDUPADATEFSRF;

        /// <summary>�v����t�a��N</summary>
        private Int32 _hADD_ADDUPADATEFWRF;

        /// <summary>�v����t��</summary>
        private Int32 _hADD_ADDUPADATEFMRF;

        /// <summary>�v����t��</summary>
        private Int32 _hADD_ADDUPADATEFDRF;

        /// <summary>�v����t����</summary>
        private string _hADD_ADDUPADATEFGRF = "";

        /// <summary>�v����t����</summary>
        private string _hADD_ADDUPADATEFRRF = "";

        /// <summary>�v����t���e����(/)</summary>
        private string _hADD_ADDUPADATEFLSRF = "";

        /// <summary>�v����t���e����(.)</summary>
        private string _hADD_ADDUPADATEFLPRF = "";

        /// <summary>�v����t���e����(�N)</summary>
        private string _hADD_ADDUPADATEFLYRF = "";

        /// <summary>�v����t���e����(��)</summary>
        private string _hADD_ADDUPADATEFLMRF = "";

        /// <summary>�v����t���e����(��)</summary>
        private string _hADD_ADDUPADATEFLDRF = "";

        /// <summary>����`�[���s������N</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFYRF;

        /// <summary>����`�[���s������N��</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFSRF;

        /// <summary>����`�[���s���a��N</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFWRF;

        /// <summary>����`�[���s����</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFMRF;

        /// <summary>����`�[���s����</summary>
        private Int32 _hADD_SALESSLIPPRINTDATEFDRF;

        /// <summary>����`�[���s������</summary>
        private string _hADD_SALESSLIPPRINTDATEFGRF = "";

        /// <summary>����`�[���s������</summary>
        private string _hADD_SALESSLIPPRINTDATEFRRF = "";

        /// <summary>����`�[���s�����e����(/)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLSRF = "";

        /// <summary>����`�[���s�����e����(.)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLPRF = "";

        /// <summary>����`�[���s�����e����(�N)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLYRF = "";

        /// <summary>����`�[���s�����e����(��)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLMRF = "";

        /// <summary>����`�[���s�����e����(��)</summary>
        private string _hADD_SALESSLIPPRINTDATEFLDRF = "";

        /// <summary>(�擪)���N�x����N</summary>
        private Int32 _hADD_FIRSTENTRYDATEFYRF;

        /// <summary>(�擪)���N�x����N��</summary>
        private Int32 _hADD_FIRSTENTRYDATEFSRF;

        /// <summary>(�擪)���N�x�a��N</summary>
        private Int32 _hADD_FIRSTENTRYDATEFWRF;

        /// <summary>(�擪)���N�x��</summary>
        private Int32 _hADD_FIRSTENTRYDATEFMRF;

        /// <summary>(�擪)���N�x��</summary>
        private Int32 _hADD_FIRSTENTRYDATEFDRF;

        /// <summary>(�擪)���N�x����</summary>
        private string _hADD_FIRSTENTRYDATEFGRF = "";

        /// <summary>(�擪)���N�x����</summary>
        private string _hADD_FIRSTENTRYDATEFRRF = "";

        /// <summary>(�擪)���N�x���e����(/)</summary>
        private string _hADD_FIRSTENTRYDATEFLSRF = "";

        /// <summary>(�擪)���N�x���e����(.)</summary>
        private string _hADD_FIRSTENTRYDATEFLPRF = "";

        /// <summary>(�擪)���N�x���e����(�N)</summary>
        private string _hADD_FIRSTENTRYDATEFLYRF = "";

        /// <summary>(�擪)���N�x���e����(��)</summary>
        private string _hADD_FIRSTENTRYDATEFLMRF = "";

        /// <summary>(�擪)���N�x���e����(��)</summary>
        private string _hADD_FIRSTENTRYDATEFLDRF = "";

        /// <summary>����p���Ӑ於�́i��i�j</summary>
        /// <remarks>���̂Q���Ȃ��Ƃ���</remarks>
        private string _hADD_PRINTCUSTOMERNAME1RF = "";

        /// <summary>����p���Ӑ於�́i���i�j</summary>
        /// <remarks>���̂Q���Ȃ��Ƃ����̂P</remarks>
        private string _hADD_PRINTCUSTOMERNAME2RF = "";

        /// <summary>����p���Ӑ於�́i���i�j�{�h��</summary>
        /// <remarks>���̂Q���Ȃ��Ƃ����̂P�{�󔒁{�h��</remarks>
        private string _hADD_PRINTCUSTOMERNAME2HNRF = "";

        /// <summary>(�擪)���[�J�[���p����</summary>
        private string _hADD_MAKERHALFNAMERF = "";

        /// <summary>(�擪)�Ԏ피�p����</summary>
        private string _hADD_MODELHALFNAMERF = "";

        /// <summary>�`�[���l�R</summary>
        private string _sALESSLIPRF_SLIPNOTE3RF = "";

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

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _sALESSLIPRF_RESULTSADDUPSECCDRF = "";

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _sALESSLIPRF_UPDATEDATETIMERF;

        // --- ADD 2009.07.24 ���m ------ >>>>>>
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _sANDESETTINGRF_CUSTOMERCODE;

        /// <summary>�[�i��X�܃R�[�h</summary>
        private string _sANDESETTINGRF_ADDRESSEESHOPCD = "";

        /// <summary>�Z�d�Ǘ��R�[�h</summary>
        private string _sANDESETTINGRF_SANDEMNGCODE = "";

        /// <summary>�o��敪</summary>
        private Int32 _sANDESETTINGRF_EXPENSEDIVCD;

        /// <summary>�����敪</summary>
        private Int32 _sANDESETTINGRF_DIRECTSENDINGCD;

        /// <summary>�󒍋敪</summary>
        private Int32 _sANDESETTINGRF_ACPTANORDERDIV;

        /// <summary>�[�i�҃R�[�h</summary>
        private string _sANDESETTINGRF_DELIVERERCD = "";

        /// <summary>�[�i�Җ�</summary>
        private string _sANDESETTINGRF_DELIVERERNM = "";

        /// <summary>�[�i�ҏZ��</summary>
        private string _sANDESETTINGRF_DELIVERERADDRESS = "";

        /// <summary>�[�i�҂s�d�k</summary>
        private string _sANDESETTINGRF_DELIVERERPHONENUM = "";

        /// <summary>���i����</summary>
        private string _sANDESETTINGRF_TRADCOMPNAME = "";

        /// <summary>���i�����_��</summary>
        private string _sANDESETTINGRF_TRADCOMPSECTNAME = "";

        /// <summary>���i���R�[�h�i�����j</summary>
        private string _sANDESETTINGRF_PURETRADCOMPCD = "";

        /// <summary>���i���d�ؗ��i�����j</summary>
        private Double _sANDESETTINGRF_PURETRADCOMPRATE;

        /// <summary>���i���R�[�h�i�D�ǁj</summary>
        private string _sANDESETTINGRF_PRITRADCOMPCD = "";

        /// <summary>���i���d�ؗ��i�D�ǁj</summary>
        private Double _sANDESETTINGRF_PRITRADCOMPRATE;

        /// <summary>AB���i�R�[�h</summary>
        private string _sANDESETTINGRF_ABGOODSCODE = "";

        /// <summary>�R�����g�w��敪</summary>
        /// <remarks>"�V�s�ڃR�����g�w��敪"</remarks>
        private Int32 _sANDESETTINGRF_COMMENTRESERVEDDIV;

        /// <summary>���i���[�J�[�R�[�h�P</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD1;

        /// <summary>���i���[�J�[�R�[�h�Q</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD2;

        /// <summary>���i���[�J�[�R�[�h�R</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD3;

        /// <summary>���i���[�J�[�R�[�h�S</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD4;

        /// <summary>���i���[�J�[�R�[�h�T</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD5;

        /// <summary>���i���[�J�[�R�[�h�U</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD6;

        /// <summary>���i���[�J�[�R�[�h�V</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD7;

        /// <summary>���i���[�J�[�R�[�h�W</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD8;

        /// <summary>���i���[�J�[�R�[�h�X</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD9;

        /// <summary>���i���[�J�[�R�[�h�P�O</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD10;

        /// <summary>���i���[�J�[�R�[�h�P�P</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD11;

        /// <summary>���i���[�J�[�R�[�h�P�Q</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD12;

        /// <summary>���i���[�J�[�R�[�h�P�R</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD13;

        /// <summary>���i���[�J�[�R�[�h�P�S</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD14;

        /// <summary>���i���[�J�[�R�[�h�P�T</summary>
        private Int32 _sANDESETTINGRF_GOODSMAKERCD15;

        /// <summary>���i�n�d�l�敪</summary>
        private Int32 _sANDESETTINGRF_PARTSOEMDIV;
        // --- ADD 2009.07.24 ���m ------ <<<<<<
        // --- ADD  ���r��  2010/03/01 ---------->>>>>
        /// <summary>����P���[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _cSTCST_SALESUNPRCFRCPROCCDRF;

        /// <summary>������z�[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _cSTCST_SALESMONEYFRCPROCCDRF;

        /// <summary>�������Œ[�������R�[�h</summary>
        /// <remarks>0�̏ꍇ�� �W���ݒ�Ƃ���B</remarks>
        private Int32 _cSTCST_SALESCNSTAXFRCPROCCDRF;
        // --- ADD  ���r��  2010/03/01 ----------<<<<<
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// <summary>QR�R�[�h���</summary>
        /// <remarks>0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</remarks>
        private Int32 _cSTCST_QRCODEPRTCDRF;
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        // 2010/07/06 Add >>>
        /// <summary>����f�[�^�w�b�_�K�C�h</summary>
        private Guid _sALESSLIPRF_FILEHEADERGUID;
        // 2010/07/06 Add <<<

        // ---- ADD caohh 2011/08/17 ------>>>>>
        /// <summary>�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_POSTNORF = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_ADDRESS1RF = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_ADDRESS3RF = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_ADDRESS4RF = "";

        /// <summary>�d�b�ԍ��i����j</summary>
        private string _cSTCST_HOMETELNORF = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_OFFICETELNORF = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _cSTCST_PORTABLETELNORF = "";

        /// <summary>FAX�ԍ��i����j</summary>
        private string _cSTCST_HOMEFAXNORF = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _cSTCST_OFFICEFAXNORF = "";

        /// <summary>�d�b�ԍ��i���̑��j</summary>
        private string _cSTCST_OTHERSTELNORF = "";
        // ---- ADD caohh 2011/08/17 ------<<<<<

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
        /// <value>�����ӁF�`�[�Ɉ󎚂��Ȃ��B���O�C�����_�B</value>
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

        /// public propaty name  :  SALESSLIPRF_DEBITNLNKSALESSLNUMRF
        /// <summary>�ԍ��A������`�[�ԍ��v���p�e�B</summary>
        /// <value>�ԍ��̑��������`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��A������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_DEBITNLNKSALESSLNUMRF
        {
            get { return _sALESSLIPRF_DEBITNLNKSALESSLNUMRF; }
            set { _sALESSLIPRF_DEBITNLNKSALESSLNUMRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_SEARCHSLIPDATERF
        /// <summary>�`�[�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SEARCHSLIPDATERF
        {
            get { return _sALESSLIPRF_SEARCHSLIPDATERF; }
            set { _sALESSLIPRF_SEARCHSLIPDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SHIPMENTDAYRF
        /// <summary>�o�ד��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SHIPMENTDAYRF
        {
            get { return _sALESSLIPRF_SHIPMENTDAYRF; }
            set { _sALESSLIPRF_SHIPMENTDAYRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_DELAYPAYMENTDIVRF
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_DELAYPAYMENTDIVRF
        {
            get { return _sALESSLIPRF_DELAYPAYMENTDIVRF; }
            set { _sALESSLIPRF_DELAYPAYMENTDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATEFORMNORF
        /// <summary>���Ϗ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATEFORMNORF
        {
            get { return _sALESSLIPRF_ESTIMATEFORMNORF; }
            set { _sALESSLIPRF_ESTIMATEFORMNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATEDIVIDERF
        /// <summary>���ϋ敪�v���p�e�B</summary>
        /// <value>1:�ʏ팩�ρ@2:�P������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ESTIMATEDIVIDERF
        {
            get { return _sALESSLIPRF_ESTIMATEDIVIDERF; }
            set { _sALESSLIPRF_ESTIMATEDIVIDERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF
        {
            get { return _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF; }
            set { _sALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_TTLAMNTDISPRATEAPYRF
        /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
        /// <value>0�F����i(�ō�)�~�|��, 1:����i(�Ŕ�)�~�|��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_TTLAMNTDISPRATEAPYRF
        {
            get { return _sALESSLIPRF_TTLAMNTDISPRATEAPYRF; }
            set { _sALESSLIPRF_TTLAMNTDISPRATEAPYRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESOUTTAXRF
        /// <summary>����O�őΏۊz�v���p�e�B</summary>
        /// <value>���őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESINTAXRF
        /// <summary>������őΏۊz�v���p�e�B</summary>
        /// <value>��ېőΏۋ��z�̏W�v�i�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESINTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF
        /// <summary>���㏬�v��ېőΏۊz�v���p�e�B</summary>
        /// <value>������z����Ŋz�i�O�Łj+������z����Ŋz�i���Łj�l�����܂܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v��ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF
        {
            get { return _sALESSLIPRF_SALSUBTTLSUBTOTAXFRERF; }
            set { _sALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALAMNTCONSTAXINCLURF
        /// <summary>������z����Ŋz�i���Łj�v���p�e�B</summary>
        /// <value>�l���O�̓��ŏ��i�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z����Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALAMNTCONSTAXINCLURF
        {
            get { return _sALESSLIPRF_SALAMNTCONSTAXINCLURF; }
            set { _sALESSLIPRF_SALAMNTCONSTAXINCLURF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDISTTLTAXEXCRF
        /// <summary>����l�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESDISTTLTAXEXCRF
        {
            get { return _sALESSLIPRF_SALESDISTTLTAXEXCRF; }
            set { _sALESSLIPRF_SALESDISTTLTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESDISOUTTAXRF
        /// <summary>����l���O�őΏۊz���v�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̊O�őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESDISOUTTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESDISOUTTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ITDEDSALESDISINTAXRF
        /// <summary>����l�����őΏۊz���v�v���p�e�B</summary>
        /// <value>���ŏ��i�l���̓��őΏۊz�i�Ŕ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ITDEDSALESDISINTAXRF
        {
            get { return _sALESSLIPRF_ITDEDSALESDISINTAXRF; }
            set { _sALESSLIPRF_ITDEDSALESDISINTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDISOUTTAXRF
        /// <summary>����l������Ŋz�i�O�Łj�v���p�e�B</summary>
        /// <value>�O�ŏ��i�l���̏���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i�O�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESDISOUTTAXRF
        {
            get { return _sALESSLIPRF_SALESDISOUTTAXRF; }
            set { _sALESSLIPRF_SALESDISOUTTAXRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESDISTTLTAXINCLURF
        /// <summary>����l������Ŋz�i���Łj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_SALESDISTTLTAXINCLURF
        {
            get { return _sALESSLIPRF_SALESDISTTLTAXINCLURF; }
            set { _sALESSLIPRF_SALESDISTTLTAXINCLURF = value; }
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

        /// public propaty name  :  SALESSLIPRF_FRACTIONPROCCDRF
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// <value>1:�؎̂�,2:�l�̌ܓ�,3:�؏グ�@�i����Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_FRACTIONPROCCDRF
        {
            get { return _sALESSLIPRF_FRACTIONPROCCDRF; }
            set { _sALESSLIPRF_FRACTIONPROCCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ACCRECCONSTAXRF
        /// <summary>���|����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_ACCRECCONSTAXRF
        {
            get { return _sALESSLIPRF_ACCRECCONSTAXRF; }
            set { _sALESSLIPRF_ACCRECCONSTAXRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_CLAIMSNMRF
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_CLAIMSNMRF
        {
            get { return _sALESSLIPRF_CLAIMSNMRF; }
            set { _sALESSLIPRF_CLAIMSNMRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEPOSTNORF
        /// <summary>�[�i��X�֔ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEPOSTNORF
        {
            get { return _sALESSLIPRF_ADDRESSEEPOSTNORF; }
            set { _sALESSLIPRF_ADDRESSEEPOSTNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEADDR1RF
        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEADDR1RF
        {
            get { return _sALESSLIPRF_ADDRESSEEADDR1RF; }
            set { _sALESSLIPRF_ADDRESSEEADDR1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEADDR3RF
        /// <summary>�[�i��Z��3(�Ԓn)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��3(�Ԓn)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEADDR3RF
        {
            get { return _sALESSLIPRF_ADDRESSEEADDR3RF; }
            set { _sALESSLIPRF_ADDRESSEEADDR3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEADDR4RF
        /// <summary>�[�i��Z��4(�A�p�[�g����)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��4(�A�p�[�g����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEADDR4RF
        {
            get { return _sALESSLIPRF_ADDRESSEEADDR4RF; }
            set { _sALESSLIPRF_ADDRESSEEADDR4RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEETELNORF
        /// <summary>�[�i��d�b�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEETELNORF
        {
            get { return _sALESSLIPRF_ADDRESSEETELNORF; }
            set { _sALESSLIPRF_ADDRESSEETELNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ADDRESSEEFAXNORF
        /// <summary>�[�i��FAX�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ADDRESSEEFAXNORF
        {
            get { return _sALESSLIPRF_ADDRESSEEFAXNORF; }
            set { _sALESSLIPRF_ADDRESSEEFAXNORF = value; }
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

        /// public propaty name  :  SALESSLIPRF_REGIPROCDATERF
        /// <summary>���W�������v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_REGIPROCDATERF
        {
            get { return _sALESSLIPRF_REGIPROCDATERF; }
            set { _sALESSLIPRF_REGIPROCDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_CASHREGISTERNORF
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_CASHREGISTERNORF
        {
            get { return _sALESSLIPRF_CASHREGISTERNORF; }
            set { _sALESSLIPRF_CASHREGISTERNORF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_POSRECEIPTNORF
        /// <summary>POS���V�[�g�ԍ��v���p�e�B</summary>
        /// <value>�@�@�@�@�@�i�T�[�o�[���ڑ����A����`�[���s���邽�߂̏��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POS���V�[�g�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_POSRECEIPTNORF
        {
            get { return _sALESSLIPRF_POSRECEIPTNORF; }
            set { _sALESSLIPRF_POSRECEIPTNORF = value; }
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

        /// public propaty name  :  SALESSLIPRF_EDISENDDATERF
        /// <summary>�d�c�h���M���v���p�e�B</summary>
        /// <value>YYYYMMDD �iErectricDataInterface�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_EDISENDDATERF
        {
            get { return _sALESSLIPRF_EDISENDDATERF; }
            set { _sALESSLIPRF_EDISENDDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_EDITAKEINDATERF
        /// <summary>�d�c�h�捞���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_EDITAKEINDATERF
        {
            get { return _sALESSLIPRF_EDITAKEINDATERF; }
            set { _sALESSLIPRF_EDITAKEINDATERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_SLIPPRINTFINISHCDRF
        /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SLIPPRINTFINISHCDRF
        {
            get { return _sALESSLIPRF_SLIPPRINTFINISHCDRF; }
            set { _sALESSLIPRF_SLIPPRINTFINISHCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESSLIPPRINTDATERF
        /// <summary>����`�[���s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESSLIPPRINTDATERF
        {
            get { return _sALESSLIPRF_SALESSLIPPRINTDATERF; }
            set { _sALESSLIPRF_SALESSLIPPRINTDATERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_BUSINESSTYPECODERF
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_BUSINESSTYPECODERF
        {
            get { return _sALESSLIPRF_BUSINESSTYPECODERF; }
            set { _sALESSLIPRF_BUSINESSTYPECODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_BUSINESSTYPENAMERF
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_BUSINESSTYPENAMERF
        {
            get { return _sALESSLIPRF_BUSINESSTYPENAMERF; }
            set { _sALESSLIPRF_BUSINESSTYPENAMERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ORDERNUMBERRF
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>����`����"��"�̎��ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ORDERNUMBERRF
        {
            get { return _sALESSLIPRF_ORDERNUMBERRF; }
            set { _sALESSLIPRF_ORDERNUMBERRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_SALESAREACODERF
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_SALESAREACODERF
        {
            get { return _sALESSLIPRF_SALESAREACODERF; }
            set { _sALESSLIPRF_SALESAREACODERF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_SALESAREANAMERF
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_SALESAREANAMERF
        {
            get { return _sALESSLIPRF_SALESAREANAMERF; }
            set { _sALESSLIPRF_SALESAREANAMERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_LISTPRICEPRINTDIVRF
        /// <summary>�艿����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_LISTPRICEPRINTDIVRF
        {
            get { return _sALESSLIPRF_LISTPRICEPRINTDIVRF; }
            set { _sALESSLIPRF_LISTPRICEPRINTDIVRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ERANAMEDISPCD1RF
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>�ʏ�@�@0:����@1:�a��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ERANAMEDISPCD1RF
        {
            get { return _sALESSLIPRF_ERANAMEDISPCD1RF; }
            set { _sALESSLIPRF_ERANAMEDISPCD1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATAXDIVCDRF
        /// <summary>���Ϗ���ŋ敪�v���p�e�B</summary>
        /// <value>0:��\�� 1:�O�Łi���ׁj2:���z�\�� 3:�O�Łi�`�[�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ���ŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ESTIMATAXDIVCDRF
        {
            get { return _sALESSLIPRF_ESTIMATAXDIVCDRF; }
            set { _sALESSLIPRF_ESTIMATAXDIVCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATEFORMPRTCDRF
        /// <summary>���Ϗ�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SALESSLIPRF_ESTIMATEFORMPRTCDRF
        {
            get { return _sALESSLIPRF_ESTIMATEFORMPRTCDRF; }
            set { _sALESSLIPRF_ESTIMATEFORMPRTCDRF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATESUBJECTRF
        /// <summary>���ό����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ό����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATESUBJECTRF
        {
            get { return _sALESSLIPRF_ESTIMATESUBJECTRF; }
            set { _sALESSLIPRF_ESTIMATESUBJECTRF = value; }
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

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE1RF
        /// <summary>���σ^�C�g���P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE1RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE1RF; }
            set { _sALESSLIPRF_ESTIMATETITLE1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE2RF
        /// <summary>���σ^�C�g���Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE2RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE2RF; }
            set { _sALESSLIPRF_ESTIMATETITLE2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE3RF
        /// <summary>���σ^�C�g���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE3RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE3RF; }
            set { _sALESSLIPRF_ESTIMATETITLE3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE4RF
        /// <summary>���σ^�C�g���S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE4RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE4RF; }
            set { _sALESSLIPRF_ESTIMATETITLE4RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATETITLE5RF
        /// <summary>���σ^�C�g���T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σ^�C�g���T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATETITLE5RF
        {
            get { return _sALESSLIPRF_ESTIMATETITLE5RF; }
            set { _sALESSLIPRF_ESTIMATETITLE5RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE1RF
        /// <summary>���ϔ��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE1RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE1RF; }
            set { _sALESSLIPRF_ESTIMATENOTE1RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE2RF
        /// <summary>���ϔ��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE2RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE2RF; }
            set { _sALESSLIPRF_ESTIMATENOTE2RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE3RF
        /// <summary>���ϔ��l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE3RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE3RF; }
            set { _sALESSLIPRF_ESTIMATENOTE3RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE4RF
        /// <summary>���ϔ��l�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE4RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE4RF; }
            set { _sALESSLIPRF_ESTIMATENOTE4RF = value; }
        }

        /// public propaty name  :  SALESSLIPRF_ESTIMATENOTE5RF
        /// <summary>���ϔ��l�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϔ��l�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SALESSLIPRF_ESTIMATENOTE5RF
        {
            get { return _sALESSLIPRF_ESTIMATENOTE5RF; }
            set { _sALESSLIPRF_ESTIMATENOTE5RF = value; }
        }

        /// public propaty name  :  SECINFOSETRF_SECTIONGUIDENMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SECINFOSETRF_SECTIONGUIDENMRF
        {
            get { return _sECINFOSETRF_SECTIONGUIDENMRF; }
            set { _sECINFOSETRF_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SECINFOSETRF_SECTIONGUIDESNMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SECINFOSETRF_SECTIONGUIDESNMRF
        {
            get { return _sECINFOSETRF_SECTIONGUIDESNMRF; }
            set { _sECINFOSETRF_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SECINFOSETRF_COMPANYNAMECD1RF
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SECINFOSETRF_COMPANYNAMECD1RF
        {
            get { return _sECINFOSETRF_COMPANYNAMECD1RF; }
            set { _sECINFOSETRF_COMPANYNAMECD1RF = value; }
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

        /// public propaty name  :  COMPANYNMRF_IMAGEINFODIVRF
        /// <summary>�摜���敪�v���p�e�B</summary>
        /// <value>10:���Љ摜,20:POS�Ŏg�p����摜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 COMPANYNMRF_IMAGEINFODIVRF
        {
            get { return _cOMPANYNMRF_IMAGEINFODIVRF; }
            set { _cOMPANYNMRF_IMAGEINFODIVRF = value; }
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
        /// <summary>���Љ摜�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Љ摜�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] IMAGEINFORF_IMAGEINFODATARF
        {
            get { return _iMAGEINFORF_IMAGEINFODATARF; }
            set { _iMAGEINFORF_IMAGEINFODATARF = value; }
        }

        /// public propaty field.NameJp  :  IMAGEINFORF_IMAGEINFODATARFImageObject
        /// <summary>���Љ摜�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Љ摜�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Image IMAGEINFORF_IMAGEINFODATARFImageObject
        {
            get
            {
                if ( _iMAGEINFORF_IMAGEINFODATARF != null )
                {
                    MemoryStream mem = new MemoryStream( _iMAGEINFORF_IMAGEINFODATARF );
                    mem.Position = 0;
                    return Image.FromStream( mem );
                }
                else
                {
                    return null;
                }
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

        /// public propaty name  :  SUBSECTIONRF_SUBSECTIONNAMERF
        /// <summary>���喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SUBSECTIONRF_SUBSECTIONNAMERF
        {
            get { return _sUBSECTIONRF_SUBSECTIONNAMERF; }
            set { _sUBSECTIONRF_SUBSECTIONNAMERF = value; }
        }

        /// public propaty name  :  EMPINP_KANARF
        /// <summary>������͎҃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMPINP_KANARF
        {
            get { return _eMPINP_KANARF; }
            set { _eMPINP_KANARF = value; }
        }

        /// public propaty name  :  EMPINP_SHORTNAMERF
        /// <summary>������͎ҒZ�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎ҒZ�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMPINP_SHORTNAMERF
        {
            get { return _eMPINP_SHORTNAMERF; }
            set { _eMPINP_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMPFRT_KANARF
        /// <summary>��t�]�ƈ��J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMPFRT_KANARF
        {
            get { return _eMPFRT_KANARF; }
            set { _eMPFRT_KANARF = value; }
        }

        /// public propaty name  :  EMPFRT_SHORTNAMERF
        /// <summary>��t�]�ƈ��Z�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��Z�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMPFRT_SHORTNAMERF
        {
            get { return _eMPFRT_SHORTNAMERF; }
            set { _eMPFRT_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMPSAL_KANARF
        /// <summary>�̔��]�ƈ��J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMPSAL_KANARF
        {
            get { return _eMPSAL_KANARF; }
            set { _eMPSAL_KANARF = value; }
        }

        /// public propaty name  :  EMPSAL_SHORTNAMERF
        /// <summary>�̔��]�ƈ��Z�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��Z�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMPSAL_SHORTNAMERF
        {
            get { return _eMPSAL_SHORTNAMERF; }
            set { _eMPSAL_SHORTNAMERF = value; }
        }

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

        /// public propaty name  :  CSTADR_CUSTOMERSUBCODERF
        /// <summary>�[����T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[����T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_CUSTOMERSUBCODERF
        {
            get { return _cSTADR_CUSTOMERSUBCODERF; }
            set { _cSTADR_CUSTOMERSUBCODERF = value; }
        }

        /// public propaty name  :  CSTADR_NAMERF
        /// <summary>�[���於�̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NAMERF
        {
            get { return _cSTADR_NAMERF; }
            set { _cSTADR_NAMERF = value; }
        }

        /// public propaty name  :  CSTADR_NAME2RF
        /// <summary>�[���於��2�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NAME2RF
        {
            get { return _cSTADR_NAME2RF; }
            set { _cSTADR_NAME2RF = value; }
        }

        /// public propaty name  :  CSTADR_HONORIFICTITLERF
        /// <summary>�[����h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_HONORIFICTITLERF
        {
            get { return _cSTADR_HONORIFICTITLERF; }
            set { _cSTADR_HONORIFICTITLERF = value; }
        }

        /// public propaty name  :  CSTADR_KANARF
        /// <summary>�[����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_KANARF
        {
            get { return _cSTADR_KANARF; }
            set { _cSTADR_KANARF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTOMERSNMRF
        /// <summary>�[���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_CUSTOMERSNMRF
        {
            get { return _cSTADR_CUSTOMERSNMRF; }
            set { _cSTADR_CUSTOMERSNMRF = value; }
        }

        /// public propaty name  :  CSTADR_OUTPUTNAMECODERF
        /// <summary>�[���揔���R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���揔���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_OUTPUTNAMECODERF
        {
            get { return _cSTADR_OUTPUTNAMECODERF; }
            set { _cSTADR_OUTPUTNAMECODERF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE1RF
        /// <summary>�[���敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE1RF
        {
            get { return _cSTADR_CUSTANALYSCODE1RF; }
            set { _cSTADR_CUSTANALYSCODE1RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE2RF
        /// <summary>�[���敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE2RF
        {
            get { return _cSTADR_CUSTANALYSCODE2RF; }
            set { _cSTADR_CUSTANALYSCODE2RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE3RF
        /// <summary>�[���敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE3RF
        {
            get { return _cSTADR_CUSTANALYSCODE3RF; }
            set { _cSTADR_CUSTANALYSCODE3RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE4RF
        /// <summary>�[���敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE4RF
        {
            get { return _cSTADR_CUSTANALYSCODE4RF; }
            set { _cSTADR_CUSTANALYSCODE4RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE5RF
        /// <summary>�[���敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE5RF
        {
            get { return _cSTADR_CUSTANALYSCODE5RF; }
            set { _cSTADR_CUSTANALYSCODE5RF = value; }
        }

        /// public propaty name  :  CSTADR_CUSTANALYSCODE6RF
        /// <summary>�[���敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTADR_CUSTANALYSCODE6RF
        {
            get { return _cSTADR_CUSTANALYSCODE6RF; }
            set { _cSTADR_CUSTANALYSCODE6RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE1RF
        /// <summary>�[������l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE1RF
        {
            get { return _cSTADR_NOTE1RF; }
            set { _cSTADR_NOTE1RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE2RF
        /// <summary>�[������l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE2RF
        {
            get { return _cSTADR_NOTE2RF; }
            set { _cSTADR_NOTE2RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE3RF
        /// <summary>�[������l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE3RF
        {
            get { return _cSTADR_NOTE3RF; }
            set { _cSTADR_NOTE3RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE4RF
        /// <summary>�[������l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE4RF
        {
            get { return _cSTADR_NOTE4RF; }
            set { _cSTADR_NOTE4RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE5RF
        /// <summary>�[������l5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE5RF
        {
            get { return _cSTADR_NOTE5RF; }
            set { _cSTADR_NOTE5RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE6RF
        /// <summary>�[������l6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE6RF
        {
            get { return _cSTADR_NOTE6RF; }
            set { _cSTADR_NOTE6RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE7RF
        /// <summary>�[������l7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE7RF
        {
            get { return _cSTADR_NOTE7RF; }
            set { _cSTADR_NOTE7RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE8RF
        /// <summary>�[������l8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE8RF
        {
            get { return _cSTADR_NOTE8RF; }
            set { _cSTADR_NOTE8RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE9RF
        /// <summary>�[������l9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE9RF
        {
            get { return _cSTADR_NOTE9RF; }
            set { _cSTADR_NOTE9RF = value; }
        }

        /// public propaty name  :  CSTADR_NOTE10RF
        /// <summary>�[������l10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������l10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTADR_NOTE10RF
        {
            get { return _cSTADR_NOTE10RF; }
            set { _cSTADR_NOTE10RF = value; }
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

        /// public propaty name  :  HADD_ACPTANODRSTNMRF
        /// <summary>�󒍃X�e�[�^�X���̃v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ACPTANODRSTNMRF
        {
            get { return _hADD_ACPTANODRSTNMRF; }
            set { _hADD_ACPTANODRSTNMRF = value; }
        }

        /// public propaty name  :  HADD_DEBITNOTEDIVNMRF
        /// <summary>�ԓ`�敪���̃v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DEBITNOTEDIVNMRF
        {
            get { return _hADD_DEBITNOTEDIVNMRF; }
            set { _hADD_DEBITNOTEDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPNMRF
        /// <summary>����`�[�敪���̃v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPNMRF
        {
            get { return _hADD_SALESSLIPNMRF; }
            set { _hADD_SALESSLIPNMRF = value; }
        }

        /// public propaty name  :  HADD_SALESGOODSNMRF
        /// <summary>���㏤�i�敪���̃v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,10:���|�p����Œ���(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESGOODSNMRF
        {
            get { return _hADD_SALESGOODSNMRF; }
            set { _hADD_SALESGOODSNMRF = value; }
        }

        /// public propaty name  :  HADD_ACCRECDIVNMRF
        /// <summary>���|�敪���̃v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ACCRECDIVNMRF
        {
            get { return _hADD_ACCRECDIVNMRF; }
            set { _hADD_ACCRECDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_DELAYPAYMENTDIVNMRF
        /// <summary>�����敪���̃v���p�e�B</summary>
        /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_DELAYPAYMENTDIVNMRF
        {
            get { return _hADD_DELAYPAYMENTDIVNMRF; }
            set { _hADD_DELAYPAYMENTDIVNMRF = value; }
        }

        /// public propaty name  :  HADD_ESTIMATEDIVIDENMRF
        /// <summary>���ϋ敪���̃v���p�e�B</summary>
        /// <value>1:�ʏ팩�ρ@2:�P������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϋ敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ESTIMATEDIVIDENMRF
        {
            get { return _hADD_ESTIMATEDIVIDENMRF; }
            set { _hADD_ESTIMATEDIVIDENMRF = value; }
        }

        /// public propaty name  :  HADD_CONSTAXLAYMETHODNMRF
        /// <summary>����œ]�ŕ������̃v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_CONSTAXLAYMETHODNMRF
        {
            get { return _hADD_CONSTAXLAYMETHODNMRF; }
            set { _hADD_CONSTAXLAYMETHODNMRF = value; }
        }

        /// public propaty name  :  HADD_AUTODEPOSITNMRF
        /// <summary>���������敪���̃v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_AUTODEPOSITNMRF
        {
            get { return _hADD_AUTODEPOSITNMRF; }
            set { _hADD_AUTODEPOSITNMRF = value; }
        }

        /// public propaty name  :  HADD_SLIPPRINTFINISHNMRF
        /// <summary>�`�[���s�ϋ敪���̃v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SLIPPRINTFINISHNMRF
        {
            get { return _hADD_SLIPPRINTFINISHNMRF; }
            set { _hADD_SLIPPRINTFINISHNMRF = value; }
        }

        /// public propaty name  :  HADD_COMPLETENMRF
        /// <summary>�ꎮ�`�[�敪���̃v���p�e�B</summary>
        /// <value>0:�ʏ�`�[,1:�ꎮ�`�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ꎮ�`�[�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_COMPLETENMRF
        {
            get { return _hADD_COMPLETENMRF; }
            set { _hADD_COMPLETENMRF = value; }
        }

        /// public propaty name  :  HADD_CARMNGNORF
        /// <summary>(�擪)�ԗ��Ǘ��ԍ��v���p�e�B</summary>
        /// <value>�����̔ԁi���d���̃V�[�P���X�jPM7�ł̎ԗ�SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԗ��Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_CARMNGNORF
        {
            get { return _hADD_CARMNGNORF; }
            set { _hADD_CARMNGNORF = value; }
        }

        /// public propaty name  :  HADD_CARMNGCODERF
        /// <summary>(�擪)���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_CARMNGCODERF
        {
            get { return _hADD_CARMNGCODERF; }
            set { _hADD_CARMNGCODERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE1CODERF
        /// <summary>(�擪)���^�������ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���^�������ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_NUMBERPLATE1CODERF
        {
            get { return _hADD_NUMBERPLATE1CODERF; }
            set { _hADD_NUMBERPLATE1CODERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE1NAMERF
        /// <summary>(�擪)���^�����ǖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���^�����ǖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_NUMBERPLATE1NAMERF
        {
            get { return _hADD_NUMBERPLATE1NAMERF; }
            set { _hADD_NUMBERPLATE1NAMERF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE2RF
        /// <summary>(�擪)�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_NUMBERPLATE2RF
        {
            get { return _hADD_NUMBERPLATE2RF; }
            set { _hADD_NUMBERPLATE2RF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE3RF
        /// <summary>(�擪)�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_NUMBERPLATE3RF
        {
            get { return _hADD_NUMBERPLATE3RF; }
            set { _hADD_NUMBERPLATE3RF = value; }
        }

        /// public propaty name  :  HADD_NUMBERPLATE4RF
        /// <summary>(�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_NUMBERPLATE4RF
        {
            get { return _hADD_NUMBERPLATE4RF; }
            set { _hADD_NUMBERPLATE4RF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATERF
        /// <summary>(�擪)���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATERF
        {
            get { return _hADD_FIRSTENTRYDATERF; }
            set { _hADD_FIRSTENTRYDATERF = value; }
        }

        /// public propaty name  :  HADD_MAKERCODERF
        /// <summary>(�擪)���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_MAKERCODERF
        {
            get { return _hADD_MAKERCODERF; }
            set { _hADD_MAKERCODERF = value; }
        }

        /// public propaty name  :  HADD_MAKERFULLNAMERF
        /// <summary>(�擪)���[�J�[�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���[�J�[�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_MAKERFULLNAMERF
        {
            get { return _hADD_MAKERFULLNAMERF; }
            set { _hADD_MAKERFULLNAMERF = value; }
        }

        /// public propaty name  :  HADD_MODELCODERF
        /// <summary>(�擪)�Ԏ�R�[�h�v���p�e�B</summary>
        /// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_MODELCODERF
        {
            get { return _hADD_MODELCODERF; }
            set { _hADD_MODELCODERF = value; }
        }

        /// public propaty name  :  HADD_MODELSUBCODERF
        /// <summary>(�擪)�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_MODELSUBCODERF
        {
            get { return _hADD_MODELSUBCODERF; }
            set { _hADD_MODELSUBCODERF = value; }
        }

        /// public propaty name  :  HADD_MODELFULLNAMERF
        /// <summary>(�擪)�Ԏ�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�Ԏ�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_MODELFULLNAMERF
        {
            get { return _hADD_MODELFULLNAMERF; }
            set { _hADD_MODELFULLNAMERF = value; }
        }

        /// public propaty name  :  HADD_EXHAUSTGASSIGNRF
        /// <summary>(�擪)�r�K�X�L���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�r�K�X�L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_EXHAUSTGASSIGNRF
        {
            get { return _hADD_EXHAUSTGASSIGNRF; }
            set { _hADD_EXHAUSTGASSIGNRF = value; }
        }

        /// public propaty name  :  HADD_SERIESMODELRF
        /// <summary>(�擪)�V���[�Y�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�V���[�Y�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SERIESMODELRF
        {
            get { return _hADD_SERIESMODELRF; }
            set { _hADD_SERIESMODELRF = value; }
        }

        /// public propaty name  :  HADD_CATEGORYSIGNMODELRF
        /// <summary>(�擪)�^���i�ޕʋL���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�^���i�ޕʋL���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_CATEGORYSIGNMODELRF
        {
            get { return _hADD_CATEGORYSIGNMODELRF; }
            set { _hADD_CATEGORYSIGNMODELRF = value; }
        }

        /// public propaty name  :  HADD_FULLMODELRF
        /// <summary>(�擪)�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FULLMODELRF
        {
            get { return _hADD_FULLMODELRF; }
            set { _hADD_FULLMODELRF = value; }
        }

        /// public propaty name  :  HADD_MODELDESIGNATIONNORF
        /// <summary>(�擪)�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_MODELDESIGNATIONNORF
        {
            get { return _hADD_MODELDESIGNATIONNORF; }
            set { _hADD_MODELDESIGNATIONNORF = value; }
        }

        /// public propaty name  :  HADD_CATEGORYNORF
        /// <summary>(�擪)�ޕʔԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_CATEGORYNORF
        {
            get { return _hADD_CATEGORYNORF; }
            set { _hADD_CATEGORYNORF = value; }
        }

        /// public propaty name  :  HADD_FRAMEMODELRF
        /// <summary>(�擪)�ԑ�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԑ�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FRAMEMODELRF
        {
            get { return _hADD_FRAMEMODELRF; }
            set { _hADD_FRAMEMODELRF = value; }
        }

        /// public propaty name  :  HADD_FRAMENORF
        /// <summary>(�擪)�ԑ�ԍ��v���p�e�B</summary>
        /// <value>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FRAMENORF
        {
            get { return _hADD_FRAMENORF; }
            set { _hADD_FRAMENORF = value; }
        }

        /// public propaty name  :  HADD_SEARCHFRAMENORF
        /// <summary>(�擪)�ԑ�ԍ��i�����p�j�v���p�e�B</summary>
        /// <value>PM7�̎ԑ�ԍ��Ɠ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԑ�ԍ��i�����p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SEARCHFRAMENORF
        {
            get { return _hADD_SEARCHFRAMENORF; }
            set { _hADD_SEARCHFRAMENORF = value; }
        }

        /// public propaty name  :  HADD_ENGINEMODELNMRF
        /// <summary>(�擪)�G���W���^�����̃v���p�e�B</summary>
        /// <value>�G���W������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ENGINEMODELNMRF
        {
            get { return _hADD_ENGINEMODELNMRF; }
            set { _hADD_ENGINEMODELNMRF = value; }
        }

        /// public propaty name  :  HADD_RELEVANCEMODELRF
        /// <summary>(�擪)�֘A�^���v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�֘A�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_RELEVANCEMODELRF
        {
            get { return _hADD_RELEVANCEMODELRF; }
            set { _hADD_RELEVANCEMODELRF = value; }
        }

        /// public propaty name  :  HADD_SUBCARNMCDRF
        /// <summary>(�擪)�T�u�Ԗ��R�[�h�v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�T�u�Ԗ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SUBCARNMCDRF
        {
            get { return _hADD_SUBCARNMCDRF; }
            set { _hADD_SUBCARNMCDRF = value; }
        }

        /// public propaty name  :  HADD_MODELGRADESNAMERF
        /// <summary>(�擪)�^���O���[�h���̃v���p�e�B</summary>
        /// <value>���T�C�N���n�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_MODELGRADESNAMERF
        {
            get { return _hADD_MODELGRADESNAMERF; }
            set { _hADD_MODELGRADESNAMERF = value; }
        }

        /// public propaty name  :  HADD_COLORCODERF
        /// <summary>(�擪)�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_COLORCODERF
        {
            get { return _hADD_COLORCODERF; }
            set { _hADD_COLORCODERF = value; }
        }

        /// public propaty name  :  HADD_COLORNAME1RF
        /// <summary>(�擪)�J���[����1�v���p�e�B</summary>
        /// <value>��ʕ\���p��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�J���[����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_COLORNAME1RF
        {
            get { return _hADD_COLORNAME1RF; }
            set { _hADD_COLORNAME1RF = value; }
        }

        /// public propaty name  :  HADD_TRIMCODERF
        /// <summary>(�擪)�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�g�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_TRIMCODERF
        {
            get { return _hADD_TRIMCODERF; }
            set { _hADD_TRIMCODERF = value; }
        }

        /// public propaty name  :  HADD_TRIMNAMERF
        /// <summary>(�擪)�g�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�g�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_TRIMNAMERF
        {
            get { return _hADD_TRIMNAMERF; }
            set { _hADD_TRIMNAMERF = value; }
        }

        /// public propaty name  :  HADD_MILEAGERF
        /// <summary>(�擪)�ԗ����s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�ԗ����s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_MILEAGERF
        {
            get { return _hADD_MILEAGERF; }
            set { _hADD_MILEAGERF = value; }
        }

        /// public propaty name  :  HADD_PRINTERMNGNORF
        /// <summary>�v�����^�Ǘ�No�v���p�e�B</summary>
        /// <value>�����̃��R�[�h�̓`�[���������v�����^�̌��茋��(default)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�����^�Ǘ�No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_PRINTERMNGNORF
        {
            get { return _hADD_PRINTERMNGNORF; }
            set { _hADD_PRINTERMNGNORF = value; }
        }

        /// public propaty name  :  HADD_SLIPPRTSETPAPERIDRF
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�����̃��R�[�h�̓`�[���������`�[�^�C�v�̌��茋��(default)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SLIPPRTSETPAPERIDRF
        {
            get { return _hADD_SLIPPRTSETPAPERIDRF; }
            set { _hADD_SLIPPRTSETPAPERIDRF = value; }
        }

        /// public propaty name  :  HADD_NOTE1RF
        /// <summary>���Д��l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Д��l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_NOTE1RF
        {
            get { return _hADD_NOTE1RF; }
            set { _hADD_NOTE1RF = value; }
        }

        /// public propaty name  :  HADD_NOTE2RF
        /// <summary>���Д��l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Д��l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_NOTE2RF
        {
            get { return _hADD_NOTE2RF; }
            set { _hADD_NOTE2RF = value; }
        }

        /// public propaty name  :  HADD_NOTE3RF
        /// <summary>���Д��l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Д��l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_NOTE3RF
        {
            get { return _hADD_NOTE3RF; }
            set { _hADD_NOTE3RF = value; }
        }

        /// public propaty name  :  HADD_REISSUEMARKRF
        /// <summary>�Ĕ��s�}�[�N�v���p�e�B</summary>
        /// <value>�S�p�R�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ĕ��s�}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_REISSUEMARKRF
        {
            get { return _hADD_REISSUEMARKRF; }
            set { _hADD_REISSUEMARKRF = value; }
        }

        /// public propaty name  :  HADD_REFCONSTAXPRTNMRF
        /// <summary>�Q�l����ň󎚖��̃v���p�e�B</summary>
        /// <value>�S�p�T�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�l����ň󎚖��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_REFCONSTAXPRTNMRF
        {
            get { return _hADD_REFCONSTAXPRTNMRF; }
            set { _hADD_REFCONSTAXPRTNMRF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMEHOURRF
        /// <summary>������� ���v���p�e�B</summary>
        /// <value>HH</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������� ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMEHOURRF
        {
            get { return _hADD_PRINTTIMEHOURRF; }
            set { _hADD_PRINTTIMEHOURRF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMEMINUTERF
        /// <summary>������� ���v���p�e�B</summary>
        /// <value>MM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������� ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMEMINUTERF
        {
            get { return _hADD_PRINTTIMEMINUTERF; }
            set { _hADD_PRINTTIMEMINUTERF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMESECONDRF
        /// <summary>������� �b�v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������� �b�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMESECONDRF
        {
            get { return _hADD_PRINTTIMESECONDRF; }
            set { _hADD_PRINTTIMESECONDRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFYRF
        /// <summary>�`�[�������t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFYRF
        {
            get { return _hADD_SEARCHSLIPDATEFYRF; }
            set { _hADD_SEARCHSLIPDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFSRF
        /// <summary>�`�[�������t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFSRF
        {
            get { return _hADD_SEARCHSLIPDATEFSRF; }
            set { _hADD_SEARCHSLIPDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFWRF
        /// <summary>�`�[�������t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFWRF
        {
            get { return _hADD_SEARCHSLIPDATEFWRF; }
            set { _hADD_SEARCHSLIPDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFMRF
        /// <summary>�`�[�������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFMRF
        {
            get { return _hADD_SEARCHSLIPDATEFMRF; }
            set { _hADD_SEARCHSLIPDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFDRF
        /// <summary>�`�[�������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SEARCHSLIPDATEFDRF
        {
            get { return _hADD_SEARCHSLIPDATEFDRF; }
            set { _hADD_SEARCHSLIPDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFGRF
        /// <summary>�`�[�������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFGRF
        {
            get { return _hADD_SEARCHSLIPDATEFGRF; }
            set { _hADD_SEARCHSLIPDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFRRF
        /// <summary>�`�[�������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFRRF
        {
            get { return _hADD_SEARCHSLIPDATEFRRF; }
            set { _hADD_SEARCHSLIPDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLSRF
        /// <summary>�`�[�������t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLSRF
        {
            get { return _hADD_SEARCHSLIPDATEFLSRF; }
            set { _hADD_SEARCHSLIPDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLPRF
        /// <summary>�`�[�������t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLPRF
        {
            get { return _hADD_SEARCHSLIPDATEFLPRF; }
            set { _hADD_SEARCHSLIPDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLYRF
        /// <summary>�`�[�������t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLYRF
        {
            get { return _hADD_SEARCHSLIPDATEFLYRF; }
            set { _hADD_SEARCHSLIPDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLMRF
        /// <summary>�`�[�������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLMRF
        {
            get { return _hADD_SEARCHSLIPDATEFLMRF; }
            set { _hADD_SEARCHSLIPDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_SEARCHSLIPDATEFLDRF
        /// <summary>�`�[�������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SEARCHSLIPDATEFLDRF
        {
            get { return _hADD_SEARCHSLIPDATEFLDRF; }
            set { _hADD_SEARCHSLIPDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFYRF
        /// <summary>�o�ד��t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFYRF
        {
            get { return _hADD_SHIPMENTDAYFYRF; }
            set { _hADD_SHIPMENTDAYFYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFSRF
        /// <summary>�o�ד��t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFSRF
        {
            get { return _hADD_SHIPMENTDAYFSRF; }
            set { _hADD_SHIPMENTDAYFSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFWRF
        /// <summary>�o�ד��t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFWRF
        {
            get { return _hADD_SHIPMENTDAYFWRF; }
            set { _hADD_SHIPMENTDAYFWRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFMRF
        /// <summary>�o�ד��t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFMRF
        {
            get { return _hADD_SHIPMENTDAYFMRF; }
            set { _hADD_SHIPMENTDAYFMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFDRF
        /// <summary>�o�ד��t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTDAYFDRF
        {
            get { return _hADD_SHIPMENTDAYFDRF; }
            set { _hADD_SHIPMENTDAYFDRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFGRF
        /// <summary>�o�ד��t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFGRF
        {
            get { return _hADD_SHIPMENTDAYFGRF; }
            set { _hADD_SHIPMENTDAYFGRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFRRF
        /// <summary>�o�ד��t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFRRF
        {
            get { return _hADD_SHIPMENTDAYFRRF; }
            set { _hADD_SHIPMENTDAYFRRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLSRF
        /// <summary>�o�ד��t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLSRF
        {
            get { return _hADD_SHIPMENTDAYFLSRF; }
            set { _hADD_SHIPMENTDAYFLSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLPRF
        /// <summary>�o�ד��t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLPRF
        {
            get { return _hADD_SHIPMENTDAYFLPRF; }
            set { _hADD_SHIPMENTDAYFLPRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLYRF
        /// <summary>�o�ד��t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLYRF
        {
            get { return _hADD_SHIPMENTDAYFLYRF; }
            set { _hADD_SHIPMENTDAYFLYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLMRF
        /// <summary>�o�ד��t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLMRF
        {
            get { return _hADD_SHIPMENTDAYFLMRF; }
            set { _hADD_SHIPMENTDAYFLMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTDAYFLDRF
        /// <summary>�o�ד��t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTDAYFLDRF
        {
            get { return _hADD_SHIPMENTDAYFLDRF; }
            set { _hADD_SHIPMENTDAYFLDRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFYRF
        /// <summary>������t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFYRF
        {
            get { return _hADD_SALESDATEFYRF; }
            set { _hADD_SALESDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFSRF
        /// <summary>������t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFSRF
        {
            get { return _hADD_SALESDATEFSRF; }
            set { _hADD_SALESDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFWRF
        /// <summary>������t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFWRF
        {
            get { return _hADD_SALESDATEFWRF; }
            set { _hADD_SALESDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFMRF
        /// <summary>������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFMRF
        {
            get { return _hADD_SALESDATEFMRF; }
            set { _hADD_SALESDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFDRF
        /// <summary>������t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESDATEFDRF
        {
            get { return _hADD_SALESDATEFDRF; }
            set { _hADD_SALESDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFGRF
        /// <summary>������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFGRF
        {
            get { return _hADD_SALESDATEFGRF; }
            set { _hADD_SALESDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFRRF
        /// <summary>������t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFRRF
        {
            get { return _hADD_SALESDATEFRRF; }
            set { _hADD_SALESDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLSRF
        /// <summary>������t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFLSRF
        {
            get { return _hADD_SALESDATEFLSRF; }
            set { _hADD_SALESDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLPRF
        /// <summary>������t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFLPRF
        {
            get { return _hADD_SALESDATEFLPRF; }
            set { _hADD_SALESDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLYRF
        /// <summary>������t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFLYRF
        {
            get { return _hADD_SALESDATEFLYRF; }
            set { _hADD_SALESDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLMRF
        /// <summary>������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFLMRF
        {
            get { return _hADD_SALESDATEFLMRF; }
            set { _hADD_SALESDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_SALESDATEFLDRF
        /// <summary>������t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESDATEFLDRF
        {
            get { return _hADD_SALESDATEFLDRF; }
            set { _hADD_SALESDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFYRF
        /// <summary>�v����t����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFYRF
        {
            get { return _hADD_ADDUPADATEFYRF; }
            set { _hADD_ADDUPADATEFYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFSRF
        /// <summary>�v����t����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFSRF
        {
            get { return _hADD_ADDUPADATEFSRF; }
            set { _hADD_ADDUPADATEFSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFWRF
        /// <summary>�v����t�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFWRF
        {
            get { return _hADD_ADDUPADATEFWRF; }
            set { _hADD_ADDUPADATEFWRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFMRF
        /// <summary>�v����t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFMRF
        {
            get { return _hADD_ADDUPADATEFMRF; }
            set { _hADD_ADDUPADATEFMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFDRF
        /// <summary>�v����t���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_ADDUPADATEFDRF
        {
            get { return _hADD_ADDUPADATEFDRF; }
            set { _hADD_ADDUPADATEFDRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFGRF
        /// <summary>�v����t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFGRF
        {
            get { return _hADD_ADDUPADATEFGRF; }
            set { _hADD_ADDUPADATEFGRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFRRF
        /// <summary>�v����t�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFRRF
        {
            get { return _hADD_ADDUPADATEFRRF; }
            set { _hADD_ADDUPADATEFRRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLSRF
        /// <summary>�v����t���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLSRF
        {
            get { return _hADD_ADDUPADATEFLSRF; }
            set { _hADD_ADDUPADATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLPRF
        /// <summary>�v����t���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLPRF
        {
            get { return _hADD_ADDUPADATEFLPRF; }
            set { _hADD_ADDUPADATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLYRF
        /// <summary>�v����t���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLYRF
        {
            get { return _hADD_ADDUPADATEFLYRF; }
            set { _hADD_ADDUPADATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLMRF
        /// <summary>�v����t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLMRF
        {
            get { return _hADD_ADDUPADATEFLMRF; }
            set { _hADD_ADDUPADATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_ADDUPADATEFLDRF
        /// <summary>�v����t���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_ADDUPADATEFLDRF
        {
            get { return _hADD_ADDUPADATEFLDRF; }
            set { _hADD_ADDUPADATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFYRF
        /// <summary>����`�[���s������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFYRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFYRF; }
            set { _hADD_SALESSLIPPRINTDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFSRF
        /// <summary>����`�[���s������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFSRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFSRF; }
            set { _hADD_SALESSLIPPRINTDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFWRF
        /// <summary>����`�[���s���a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s���a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFWRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFWRF; }
            set { _hADD_SALESSLIPPRINTDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFMRF
        /// <summary>����`�[���s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFMRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFMRF; }
            set { _hADD_SALESSLIPPRINTDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFDRF
        /// <summary>����`�[���s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SALESSLIPPRINTDATEFDRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFDRF; }
            set { _hADD_SALESSLIPPRINTDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFGRF
        /// <summary>����`�[���s�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFGRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFGRF; }
            set { _hADD_SALESSLIPPRINTDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFRRF
        /// <summary>����`�[���s�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFRRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFRRF; }
            set { _hADD_SALESSLIPPRINTDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLSRF
        /// <summary>����`�[���s�����e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLSRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLSRF; }
            set { _hADD_SALESSLIPPRINTDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLPRF
        /// <summary>����`�[���s�����e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLPRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLPRF; }
            set { _hADD_SALESSLIPPRINTDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLYRF
        /// <summary>����`�[���s�����e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLYRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLYRF; }
            set { _hADD_SALESSLIPPRINTDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLMRF
        /// <summary>����`�[���s�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLMRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLMRF; }
            set { _hADD_SALESSLIPPRINTDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_SALESSLIPPRINTDATEFLDRF
        /// <summary>����`�[���s�����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���s�����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SALESSLIPPRINTDATEFLDRF
        {
            get { return _hADD_SALESSLIPPRINTDATEFLDRF; }
            set { _hADD_SALESSLIPPRINTDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFYRF
        /// <summary>(�擪)���N�x����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFYRF
        {
            get { return _hADD_FIRSTENTRYDATEFYRF; }
            set { _hADD_FIRSTENTRYDATEFYRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFSRF
        /// <summary>(�擪)���N�x����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFSRF
        {
            get { return _hADD_FIRSTENTRYDATEFSRF; }
            set { _hADD_FIRSTENTRYDATEFSRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFWRF
        /// <summary>(�擪)���N�x�a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x�a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFWRF
        {
            get { return _hADD_FIRSTENTRYDATEFWRF; }
            set { _hADD_FIRSTENTRYDATEFWRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFMRF
        /// <summary>(�擪)���N�x���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFMRF
        {
            get { return _hADD_FIRSTENTRYDATEFMRF; }
            set { _hADD_FIRSTENTRYDATEFMRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFDRF
        /// <summary>(�擪)���N�x���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_FIRSTENTRYDATEFDRF
        {
            get { return _hADD_FIRSTENTRYDATEFDRF; }
            set { _hADD_FIRSTENTRYDATEFDRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFGRF
        /// <summary>(�擪)���N�x�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFGRF
        {
            get { return _hADD_FIRSTENTRYDATEFGRF; }
            set { _hADD_FIRSTENTRYDATEFGRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFRRF
        /// <summary>(�擪)���N�x�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFRRF
        {
            get { return _hADD_FIRSTENTRYDATEFRRF; }
            set { _hADD_FIRSTENTRYDATEFRRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLSRF
        /// <summary>(�擪)���N�x���e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLSRF
        {
            get { return _hADD_FIRSTENTRYDATEFLSRF; }
            set { _hADD_FIRSTENTRYDATEFLSRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLPRF
        /// <summary>(�擪)���N�x���e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLPRF
        {
            get { return _hADD_FIRSTENTRYDATEFLPRF; }
            set { _hADD_FIRSTENTRYDATEFLPRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLYRF
        /// <summary>(�擪)���N�x���e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLYRF
        {
            get { return _hADD_FIRSTENTRYDATEFLYRF; }
            set { _hADD_FIRSTENTRYDATEFLYRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLMRF
        /// <summary>(�擪)���N�x���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLMRF
        {
            get { return _hADD_FIRSTENTRYDATEFLMRF; }
            set { _hADD_FIRSTENTRYDATEFLMRF = value; }
        }

        /// public propaty name  :  HADD_FIRSTENTRYDATEFLDRF
        /// <summary>(�擪)���N�x���e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���N�x���e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_FIRSTENTRYDATEFLDRF
        {
            get { return _hADD_FIRSTENTRYDATEFLDRF; }
            set { _hADD_FIRSTENTRYDATEFLDRF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAME1RF
        /// <summary>����p���Ӑ於�́i��i�j�v���p�e�B</summary>
        /// <value>���̂Q���Ȃ��Ƃ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���Ӑ於�́i��i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAME1RF
        {
            get { return _hADD_PRINTCUSTOMERNAME1RF; }
            set { _hADD_PRINTCUSTOMERNAME1RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAME2RF
        /// <summary>����p���Ӑ於�́i���i�j�v���p�e�B</summary>
        /// <value>���̂Q���Ȃ��Ƃ����̂P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���Ӑ於�́i���i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAME2RF
        {
            get { return _hADD_PRINTCUSTOMERNAME2RF; }
            set { _hADD_PRINTCUSTOMERNAME2RF = value; }
        }

        /// public propaty name  :  HADD_PRINTCUSTOMERNAME2HNRF
        /// <summary>����p���Ӑ於�́i���i�j�{�h�̃v���p�e�B</summary>
        /// <value>���̂Q���Ȃ��Ƃ����̂P�{�󔒁{�h��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���Ӑ於�́i���i�j�{�h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_PRINTCUSTOMERNAME2HNRF
        {
            get { return _hADD_PRINTCUSTOMERNAME2HNRF; }
            set { _hADD_PRINTCUSTOMERNAME2HNRF = value; }
        }

        /// public propaty name  :  HADD_MAKERHALFNAMERF
        /// <summary>(�擪)���[�J�[���p���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)���[�J�[���p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_MAKERHALFNAMERF
        {
            get { return _hADD_MAKERHALFNAMERF; }
            set { _hADD_MAKERHALFNAMERF = value; }
        }

        /// public propaty name  :  HADD_MODELHALFNAMERF
        /// <summary>(�擪)�Ԏ피�p���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   (�擪)�Ԏ피�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_MODELHALFNAMERF
        {
            get { return _hADD_MODELHALFNAMERF; }
            set { _hADD_MODELHALFNAMERF = value; }
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

        /// public propaty name  :  SALESSLIPRF_UPDATEDATETIMERF
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SALESSLIPRF_UPDATEDATETIMERF
        {
            get { return _sALESSLIPRF_UPDATEDATETIMERF; }
            set { _sALESSLIPRF_UPDATEDATETIMERF = value; }
        }

        // --- ADD 2009.07.24 ���m ------ >>>>>>
        /// public propaty name  :  SANDESETTINGRF_CUSTOMERCODE
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_CUSTOMERCODE
        {
            get { return _sANDESETTINGRF_CUSTOMERCODE; }
            set { _sANDESETTINGRF_CUSTOMERCODE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_ADDRESSEESHOPCD
        /// <summary>�[�i��X�܃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�܃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_ADDRESSEESHOPCD
        {
            get { return _sANDESETTINGRF_ADDRESSEESHOPCD; }
            set { _sANDESETTINGRF_ADDRESSEESHOPCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_SANDEMNGCODE
        /// <summary>�Z�d�Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�d�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_SANDEMNGCODE
        {
            get { return _sANDESETTINGRF_SANDEMNGCODE; }
            set { _sANDESETTINGRF_SANDEMNGCODE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_EXPENSEDIVCD
        /// <summary>�o��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_EXPENSEDIVCD
        {
            get { return _sANDESETTINGRF_EXPENSEDIVCD; }
            set { _sANDESETTINGRF_EXPENSEDIVCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DIRECTSENDINGCD
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_DIRECTSENDINGCD
        {
            get { return _sANDESETTINGRF_DIRECTSENDINGCD; }
            set { _sANDESETTINGRF_DIRECTSENDINGCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_ACPTANORDERDIV
        /// <summary>�󒍋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_ACPTANORDERDIV
        {
            get { return _sANDESETTINGRF_ACPTANORDERDIV; }
            set { _sANDESETTINGRF_ACPTANORDERDIV = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERCD
        /// <summary>�[�i�҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERCD
        {
            get { return _sANDESETTINGRF_DELIVERERCD; }
            set { _sANDESETTINGRF_DELIVERERCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERNM
        /// <summary>�[�i�Җ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERNM
        {
            get { return _sANDESETTINGRF_DELIVERERNM; }
            set { _sANDESETTINGRF_DELIVERERNM = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERADDRESS
        /// <summary>�[�i�ҏZ���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�ҏZ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERADDRESS
        {
            get { return _sANDESETTINGRF_DELIVERERADDRESS; }
            set { _sANDESETTINGRF_DELIVERERADDRESS = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_DElIVERERPHONENUM
        /// <summary>�[�i�҂s�d�k�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�҂s�d�k�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_DELIVERERPHONENUM
        {
            get { return _sANDESETTINGRF_DELIVERERPHONENUM; }
            set { _sANDESETTINGRF_DELIVERERPHONENUM = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_TRADCOMPNAME
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_TRADCOMPNAME
        {
            get { return _sANDESETTINGRF_TRADCOMPNAME; }
            set { _sANDESETTINGRF_TRADCOMPNAME = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_TRADCOMPSECTNAME
        /// <summary>���i�����_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_TRADCOMPSECTNAME
        {
            get { return _sANDESETTINGRF_TRADCOMPSECTNAME; }
            set { _sANDESETTINGRF_TRADCOMPSECTNAME = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PURETRADCOMPCD
        /// <summary>���i���R�[�h�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_PURETRADCOMPCD
        {
            get { return _sANDESETTINGRF_PURETRADCOMPCD; }
            set { _sANDESETTINGRF_PURETRADCOMPCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PURETRADCOMPRATE
        /// <summary>���i���d�ؗ��i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���d�ؗ��i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SANDESETTINGRF_PURETRADCOMPRATE
        {
            get { return _sANDESETTINGRF_PURETRADCOMPRATE; }
            set { _sANDESETTINGRF_PURETRADCOMPRATE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PRITRADCOMPCD
        /// <summary>���i���R�[�h�i�D�ǁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�i�D�ǁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_PRITRADCOMPCD
        {
            get { return _sANDESETTINGRF_PRITRADCOMPCD; }
            set { _sANDESETTINGRF_PRITRADCOMPCD = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PRITRADCOMPRATE
        /// <summary>���i���d�ؗ��i�D�ǁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���d�ؗ��i�D�ǁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SANDESETTINGRF_PRITRADCOMPRATE
        {
            get { return _sANDESETTINGRF_PRITRADCOMPRATE; }
            set { _sANDESETTINGRF_PRITRADCOMPRATE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_ABGOODSCODE
        /// <summary>AB���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SANDESETTINGRF_ABGOODSCODE
        {
            get { return _sANDESETTINGRF_ABGOODSCODE; }
            set { _sANDESETTINGRF_ABGOODSCODE = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_COMMENTRESERVEDDIV
        /// <summary>�R�����g�w��敪�v���p�e�B</summary>
        /// <value>"�V�s�ڃR�����g�w��敪"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_COMMENTRESERVEDDIV
        {
            get { return _sANDESETTINGRF_COMMENTRESERVEDDIV; }
            set { _sANDESETTINGRF_COMMENTRESERVEDDIV = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD1
        /// <summary>���i���[�J�[�R�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD1
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD1; }
            set { _sANDESETTINGRF_GOODSMAKERCD1 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD2
        /// <summary>���i���[�J�[�R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD2
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD2; }
            set { _sANDESETTINGRF_GOODSMAKERCD2 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD3
        /// <summary>���i���[�J�[�R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD3
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD3; }
            set { _sANDESETTINGRF_GOODSMAKERCD3 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD4
        /// <summary>���i���[�J�[�R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD4
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD4; }
            set { _sANDESETTINGRF_GOODSMAKERCD4 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD5
        /// <summary>���i���[�J�[�R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD5
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD5; }
            set { _sANDESETTINGRF_GOODSMAKERCD5 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD6
        /// <summary>���i���[�J�[�R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD6
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD6; }
            set { _sANDESETTINGRF_GOODSMAKERCD6 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD7
        /// <summary>���i���[�J�[�R�[�h�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD7
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD7; }
            set { _sANDESETTINGRF_GOODSMAKERCD7 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD8
        /// <summary>���i���[�J�[�R�[�h�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD8
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD8; }
            set { _sANDESETTINGRF_GOODSMAKERCD8 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD9
        /// <summary>���i���[�J�[�R�[�h�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD9
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD9; }
            set { _sANDESETTINGRF_GOODSMAKERCD9 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD10
        /// <summary>���i���[�J�[�R�[�h�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD10
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD10; }
            set { _sANDESETTINGRF_GOODSMAKERCD10 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD11
        /// <summary>���i���[�J�[�R�[�h�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD11
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD11; }
            set { _sANDESETTINGRF_GOODSMAKERCD11 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD12
        /// <summary>���i���[�J�[�R�[�h�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD12
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD12; }
            set { _sANDESETTINGRF_GOODSMAKERCD12 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD13
        /// <summary>���i���[�J�[�R�[�h�P�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD13
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD13; }
            set { _sANDESETTINGRF_GOODSMAKERCD13 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD14
        /// <summary>���i���[�J�[�R�[�h�P�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD14
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD14; }
            set { _sANDESETTINGRF_GOODSMAKERCD14 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_GOODSMAKERCD15
        /// <summary>���i���[�J�[�R�[�h�P�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_GOODSMAKERCD15
        {
            get { return _sANDESETTINGRF_GOODSMAKERCD15; }
            set { _sANDESETTINGRF_GOODSMAKERCD15 = value; }
        }

        /// public propaty name  :  SANDESETTINGRF_PARTSOEMDIV
        /// <summary>���i�n�d�l�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�n�d�l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SANDESETTINGRF_PARTSOEMDIV
        {
            get { return _sANDESETTINGRF_PARTSOEMDIV; }
            set { _sANDESETTINGRF_PARTSOEMDIV = value; }
        }
        // --- ADD 2009.07.24 ���m ------ <<<<<<
        // --- ADD  ���r��  2010/03/01 ---------->>>>>
        /// public propaty name  :  CSTCST_SALESUNPRCFRCPROCCDRF
        /// <summary>����P���[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_SALESUNPRCFRCPROCCDRF
        {
            get { return _cSTCST_SALESUNPRCFRCPROCCDRF; }
            set { _cSTCST_SALESUNPRCFRCPROCCDRF = value; }
        }

        /// public propaty name  :  CSTCST_SALESMONEYFRCPROCCDRF
        /// <summary>������z�[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_SALESMONEYFRCPROCCDRF
        {
            get { return _cSTCST_SALESMONEYFRCPROCCDRF; }
            set { _cSTCST_SALESMONEYFRCPROCCDRF = value; }
        }

        /// public propaty name  :  CSTCST_SALESCNSTAXFRCPROCCDRF
        /// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�� �W���ݒ�Ƃ���B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_SALESCNSTAXFRCPROCCDRF
        {
            get { return _cSTCST_SALESCNSTAXFRCPROCCDRF; }
            set { _cSTCST_SALESCNSTAXFRCPROCCDRF = value; }
        }

        // --- ADD  ���r��  2010/03/01 ----------<<<<<
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// public propaty name  :  CSTCST_SALESCNSTAXFRCPROCCDRF
        /// <summary>QR�R�[�h����v���p�e�B</summary>
        /// <value>0:�W�� 1:�󎚂��Ȃ� 2:�󎚂��� 3:�ԕi�܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QR�R�[�h����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CSTCST_QRCODEPRTCDRF
        {
            get { return _cSTCST_QRCODEPRTCDRF; }
            set { _cSTCST_QRCODEPRTCDRF = value; }
        }
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<

        // 2010/07/06 Add >>>
        /// public propaty name  :  SALESSLIPRF_FILEHEADERGUID
        /// <summary>����f�[�^�w�b�_�K�C�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����f�[�^�w�b�_�K�C�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid SALESSLIPRF_FILEHEADERGUID
        {
            get { return _sALESSLIPRF_FILEHEADERGUID; }
            set { _sALESSLIPRF_FILEHEADERGUID = value; }
        }
        // 2010/07/06 Add <<<

        // ---- ADD caohh 2011/08/17 ------>>>>>
        /// public propaty name  :  CSTCST_POSTNORF
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_POSTNORF
        {
            get { return _cSTCST_POSTNORF; }
            set { _cSTCST_POSTNORF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS1RF
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_ADDRESS1RF
        {
            get { return _cSTCST_ADDRESS1RF; }
            set { _cSTCST_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS3RF
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_ADDRESS3RF
        {
            get { return _cSTCST_ADDRESS3RF; }
            set { _cSTCST_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CSTCST_ADDRESS4RF
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_ADDRESS4RF
        {
            get { return _cSTCST_ADDRESS4RF; }
            set { _cSTCST_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CSTCST_HOMETELNORF
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_HOMETELNORF
        {
            get { return _cSTCST_HOMETELNORF; }
            set { _cSTCST_HOMETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICETELNORF
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_OFFICETELNORF
        {
            get { return _cSTCST_OFFICETELNORF; }
            set { _cSTCST_OFFICETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_PORTABLETELNORF
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_PORTABLETELNORF
        {
            get { return _cSTCST_PORTABLETELNORF; }
            set { _cSTCST_PORTABLETELNORF = value; }
        }

        /// public propaty name  :  CSTCST_HOMEFAXNORF
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_HOMEFAXNORF
        {
            get { return _cSTCST_HOMEFAXNORF; }
            set { _cSTCST_HOMEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OFFICEFAXNORF
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_OFFICEFAXNORF
        {
            get { return _cSTCST_OFFICEFAXNORF; }
            set { _cSTCST_OFFICEFAXNORF = value; }
        }

        /// public propaty name  :  CSTCST_OTHERSTELNORF
        /// <summary>�d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CSTCST_OTHERSTELNORF
        {
            get { return _cSTCST_OTHERSTELNORF; }
            set { _cSTCST_OTHERSTELNORF = value; }
        }
        // ---- ADD caohh 2011/08/17 ------<<<<<

        /// <summary>
        /// ���R���[����`�[�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FrePSalesSlipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesSlipWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePSalesSlipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FrePSalesSlipWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FrePSalesSlipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FrePSalesSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesSlipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePSalesSlipWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePSalesSlipWork || graph is ArrayList || graph is FrePSalesSlipWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( FrePSalesSlipWork ).FullName ) );

            if ( graph != null && graph is FrePSalesSlipWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePSalesSlipWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePSalesSlipWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePSalesSlipWork[])graph).Length;
            }
            else if ( graph is FrePSalesSlipWork )
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
            //�ԍ��A������`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DEBITNLNKSALESSLNUMRF
            //����`�[�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESSLIPCDRF
            //���㏤�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESGOODSCDRF
            //���|�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ACCRECDIVCDRF
            //�`�[�������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SEARCHSLIPDATERF
            //�o�ד��t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SHIPMENTDAYRF
            //������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESDATERF
            //�v����t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ADDUPADATERF
            //�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DELAYPAYMENTDIVRF
            //���Ϗ��ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATEFORMNORF
            //���ϋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ESTIMATEDIVIDERF
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
            //���z�\�����@�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF
            //���z�\���|���K�p�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_TTLAMNTDISPRATEAPYRF
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXINCRF
            //����`�[���v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESTOTALTAXEXCRF
            //���㏬�v�i�ō��݁j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXINCRF
            //���㏬�v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXEXCRF
            //���㏬�v�i�Łj
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESSUBTOTALTAXRF
            //����O�őΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESOUTTAXRF
            //������őΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESINTAXRF
            //���㏬�v��ېőΏۊz
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF
            //������z����Ŋz�i���Łj
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALAMNTCONSTAXINCLURF
            //����l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESDISTTLTAXEXCRF
            //����l���O�őΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESDISOUTTAXRF
            //����l�����őΏۊz���v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ITDEDSALESDISINTAXRF
            //����l������Ŋz�i�O�Łj
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESDISOUTTAXRF
            //����l������Ŋz�i���Łj
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_SALESDISTTLTAXINCLURF
            //�������z�v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_TOTALCOSTRF
            //����œ]�ŕ���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CONSTAXLAYMETHODRF
            //����Őŗ�
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESSLIPRF_CONSTAXRATERF
            //�[�������敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_FRACTIONPROCCDRF
            //���|�����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_ACCRECCONSTAXRF
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
            //�����旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_CLAIMSNMRF
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
            //�[�i��X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEPOSTNORF
            //�[�i��Z��1(�s���{���s��S�E�����E��)
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEADDR1RF
            //�[�i��Z��3(�Ԓn)
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEADDR3RF
            //�[�i��Z��4(�A�p�[�g����)
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEADDR4RF
            //�[�i��d�b�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEETELNORF
            //�[�i��FAX�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ADDRESSEEFAXNORF
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_PARTYSALESLIPNUMRF
            //�`�[���l
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTERF
            //�`�[���l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE2RF
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_RETGOODSREASONDIVRF
            //�ԕi���R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RETGOODSREASONRF
            //���W������
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_REGIPROCDATERF
            //���W�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_CASHREGISTERNORF
            //POS���V�[�g�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_POSRECEIPTNORF
            //���׍s��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DETAILROWCOUNTRF
            //�d�c�h���M��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_EDISENDDATERF
            //�d�c�h�捞��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_EDITAKEINDATERF
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK1RF
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_UOEREMARK2RF
            //�`�[���s�ϋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SLIPPRINTFINISHCDRF
            //����`�[���s��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESSLIPPRINTDATERF
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_BUSINESSTYPECODERF
            //�Ǝ햼��
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_BUSINESSTYPENAMERF
            //�����ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ORDERNUMBERRF
            //�[�i�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_DELIVEREDGOODSDIVRF
            //�[�i�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_DELIVEREDGOODSDIVNMRF
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_SALESAREACODERF
            //�̔��G���A����
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SALESAREANAMERF
            //�݌ɏ��i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_STOCKGOODSTTLTAXEXCRF
            //�������i���v���z�i�Ŕ��j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_PUREGOODSTTLTAXEXCRF
            //�艿����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_LISTPRICEPRINTDIVRF
            //�����\���敪�P
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ERANAMEDISPCD1RF
            //���Ϗ���ŋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ESTIMATAXDIVCDRF
            //���Ϗ�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESSLIPRF_ESTIMATEFORMPRTCDRF
            //���ό���
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATESUBJECTRF
            //�r���P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES1RF
            //�r���Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_FOOTNOTES2RF
            //���σ^�C�g���P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE1RF
            //���σ^�C�g���Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE2RF
            //���σ^�C�g���R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE3RF
            //���σ^�C�g���S
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE4RF
            //���σ^�C�g���T
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATETITLE5RF
            //���ϔ��l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE1RF
            //���ϔ��l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE2RF
            //���ϔ��l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE3RF
            //���ϔ��l�S
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE4RF
            //���ϔ��l�T
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_ESTIMATENOTE5RF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SECINFOSETRF_SECTIONGUIDENMRF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SECINFOSETRF_SECTIONGUIDESNMRF
            //���Ж��̃R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SECINFOSETRF_COMPANYNAMECD1RF
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
            //�摜���敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //COMPANYNMRF_IMAGEINFODIVRF
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
            //���Љ摜
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //IMAGEINFORF_IMAGEINFODATARF
            //���喼��
            serInfo.MemberInfo.Add( typeof( string ) ); //SUBSECTIONRF_SUBSECTIONNAMERF
            //������͎҃J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPINP_KANARF
            //������͎ҒZ�k����
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPINP_SHORTNAMERF
            //��t�]�ƈ��J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPFRT_KANARF
            //��t�]�ƈ��Z�k����
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPFRT_SHORTNAMERF
            //�̔��]�ƈ��J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPSAL_KANARF
            //�̔��]�ƈ��Z�k����
            serInfo.MemberInfo.Add( typeof( string ) ); //EMPSAL_SHORTNAMERF
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
            //�[����T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_CUSTOMERSUBCODERF
            //�[���於��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NAMERF
            //�[���於��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NAME2RF
            //�[����h��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_HONORIFICTITLERF
            //�[����J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_KANARF
            //�[���旪��
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_CUSTOMERSNMRF
            //�[���揔���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_OUTPUTNAMECODERF
            //�[���敪�̓R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE1RF
            //�[���敪�̓R�[�h2
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE2RF
            //�[���敪�̓R�[�h3
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE3RF
            //�[���敪�̓R�[�h4
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE4RF
            //�[���敪�̓R�[�h5
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE5RF
            //�[���敪�̓R�[�h6
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTADR_CUSTANALYSCODE6RF
            //�[������l1
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE1RF
            //�[������l2
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE2RF
            //�[������l3
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE3RF
            //�[������l4
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE4RF
            //�[������l5
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE5RF
            //�[������l6
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE6RF
            //�[������l7
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE7RF
            //�[������l8
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE8RF
            //�[������l9
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE9RF
            //�[������l10
            serInfo.MemberInfo.Add( typeof( string ) ); //CSTADR_NOTE10RF
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
            //�󒍃X�e�[�^�X����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ACPTANODRSTNMRF
            //�ԓ`�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DEBITNOTEDIVNMRF
            //����`�[�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPNMRF
            //���㏤�i�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESGOODSNMRF
            //���|�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ACCRECDIVNMRF
            //�����敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_DELAYPAYMENTDIVNMRF
            //���ϋ敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ESTIMATEDIVIDENMRF
            //����œ]�ŕ�������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_CONSTAXLAYMETHODNMRF
            //���������敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_AUTODEPOSITNMRF
            //�`�[���s�ϋ敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SLIPPRINTFINISHNMRF
            //�ꎮ�`�[�敪����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COMPLETENMRF
            //(�擪)�ԗ��Ǘ��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_CARMNGNORF
            //(�擪)���q�Ǘ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_CARMNGCODERF
            //(�擪)���^�������ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_NUMBERPLATE1CODERF
            //(�擪)���^�����ǖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NUMBERPLATE1NAMERF
            //(�擪)�ԗ��o�^�ԍ��i��ʁj
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NUMBERPLATE2RF
            //(�擪)�ԗ��o�^�ԍ��i�J�i�j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NUMBERPLATE3RF
            //(�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_NUMBERPLATE4RF
            //(�擪)���N�x
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATERF
            //(�擪)���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MAKERCODERF
            //(�擪)���[�J�[�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MAKERFULLNAMERF
            //(�擪)�Ԏ�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MODELCODERF
            //(�擪)�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MODELSUBCODERF
            //(�擪)�Ԏ�S�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MODELFULLNAMERF
            //(�擪)�r�K�X�L��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_EXHAUSTGASSIGNRF
            //(�擪)�V���[�Y�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SERIESMODELRF
            //(�擪)�^���i�ޕʋL���j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_CATEGORYSIGNMODELRF
            //(�擪)�^���i�t���^�j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FULLMODELRF
            //(�擪)�^���w��ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MODELDESIGNATIONNORF
            //(�擪)�ޕʔԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_CATEGORYNORF
            //(�擪)�ԑ�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FRAMEMODELRF
            //(�擪)�ԑ�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FRAMENORF
            //(�擪)�ԑ�ԍ��i�����p�j
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHFRAMENORF
            //(�擪)�G���W���^������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ENGINEMODELNMRF
            //(�擪)�֘A�^��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_RELEVANCEMODELRF
            //(�擪)�T�u�Ԗ��R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SUBCARNMCDRF
            //(�擪)�^���O���[�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MODELGRADESNAMERF
            //(�擪)�J���[�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COLORCODERF
            //(�擪)�J���[����1
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_COLORNAME1RF
            //(�擪)�g�����R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_TRIMCODERF
            //(�擪)�g��������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_TRIMNAMERF
            //(�擪)�ԗ����s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_MILEAGERF
            //�v�����^�Ǘ�No
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTERMNGNORF
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SLIPPRTSETPAPERIDRF
            //���Д��l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE1RF
            //���Д��l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE2RF
            //���Д��l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE3RF
            //�Ĕ��s�}�[�N
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_REISSUEMARKRF
            //�Q�l����ň󎚖���
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_REFCONSTAXPRTNMRF
            //������� ��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEHOURRF
            //������� ��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEMINUTERF
            //������� �b
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMESECONDRF
            //�`�[�������t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFYRF
            //�`�[�������t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFSRF
            //�`�[�������t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFWRF
            //�`�[�������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFMRF
            //�`�[�������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SEARCHSLIPDATEFDRF
            //�`�[�������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFGRF
            //�`�[�������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFRRF
            //�`�[�������t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLSRF
            //�`�[�������t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLPRF
            //�`�[�������t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLYRF
            //�`�[�������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLMRF
            //�`�[�������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SEARCHSLIPDATEFLDRF
            //�o�ד��t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFYRF
            //�o�ד��t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFSRF
            //�o�ד��t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFWRF
            //�o�ד��t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFMRF
            //�o�ד��t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTDAYFDRF
            //�o�ד��t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFGRF
            //�o�ד��t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFRRF
            //�o�ד��t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLSRF
            //�o�ד��t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLPRF
            //�o�ד��t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLYRF
            //�o�ד��t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLMRF
            //�o�ד��t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTDAYFLDRF
            //������t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFYRF
            //������t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFSRF
            //������t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFWRF
            //������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFMRF
            //������t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESDATEFDRF
            //������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFGRF
            //������t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFRRF
            //������t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLSRF
            //������t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLPRF
            //������t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLYRF
            //������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLMRF
            //������t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESDATEFLDRF
            //�v����t����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFYRF
            //�v����t����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFSRF
            //�v����t�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFWRF
            //�v����t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFMRF
            //�v����t��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_ADDUPADATEFDRF
            //�v����t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFGRF
            //�v����t����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFRRF
            //�v����t���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLSRF
            //�v����t���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLPRF
            //�v����t���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLYRF
            //�v����t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLMRF
            //�v����t���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_ADDUPADATEFLDRF
            //����`�[���s������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFYRF
            //����`�[���s������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFSRF
            //����`�[���s���a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFWRF
            //����`�[���s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFMRF
            //����`�[���s����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SALESSLIPPRINTDATEFDRF
            //����`�[���s������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFGRF
            //����`�[���s������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFRRF
            //����`�[���s�����e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLSRF
            //����`�[���s�����e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLPRF
            //����`�[���s�����e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLYRF
            //����`�[���s�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLMRF
            //����`�[���s�����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SALESSLIPPRINTDATEFLDRF
            //(�擪)���N�x����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFYRF
            //(�擪)���N�x����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFSRF
            //(�擪)���N�x�a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFWRF
            //(�擪)���N�x��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFMRF
            //(�擪)���N�x��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_FIRSTENTRYDATEFDRF
            //(�擪)���N�x����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFGRF
            //(�擪)���N�x����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFRRF
            //(�擪)���N�x���e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLSRF
            //(�擪)���N�x���e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLPRF
            //(�擪)���N�x���e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLYRF
            //(�擪)���N�x���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLMRF
            //(�擪)���N�x���e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_FIRSTENTRYDATEFLDRF
            //����p���Ӑ於�́i��i�j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAME1RF
            //����p���Ӑ於�́i���i�j
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAME2RF
            //����p���Ӑ於�́i���i�j�{�h��
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_PRINTCUSTOMERNAME2HNRF
            //(�擪)���[�J�[���p����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MAKERHALFNAMERF
            //(�擪)�Ԏ피�p����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_MODELHALFNAMERF
            //�`�[���l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_SLIPNOTE3RF
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
            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESSLIPRF_RESULTSADDUPSECCDRF
            //�X�V����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESSLIPRF_UPDATEDATETIMERF

            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_CustomerCode
            //�[�i��X�܃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_AddresseeShopCd
            //�Z�d�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_SAndEMngCode
            //�o��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_ExpenseDivCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_DirectSendingCd
            //�󒍋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_AcptAnOrderDiv
            //�[�i�҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererCd
            //�[�i�Җ�
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererNm
            //�[�i�ҏZ��
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererAddress
            //�[�i�҂s�d�k
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_DelivererPhoneNum
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_TradCompName
            //���i�����_��
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_TradCompSectName
            //���i���R�[�h�i�����j
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_PureTradCompCd
            //���i���d�ؗ��i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SAndESettingRF_PureTradCompRate
            //���i���R�[�h�i�D�ǁj
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_PriTradCompCd
            //���i���d�ؗ��i�D�ǁj
            serInfo.MemberInfo.Add(typeof(Double)); //SAndESettingRF_PriTradCompRate
            //AB���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndESettingRF_ABGoodsCode
            //�R�����g�w��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_CommentReservedDiv
            //���i���[�J�[�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd1
            //���i���[�J�[�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd2
            //���i���[�J�[�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd3
            //���i���[�J�[�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd4
            //���i���[�J�[�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd5
            //���i���[�J�[�R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd6
            //���i���[�J�[�R�[�h�V
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd7
            //���i���[�J�[�R�[�h�W
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd8
            //���i���[�J�[�R�[�h�X
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd9
            //���i���[�J�[�R�[�h�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd10
            //���i���[�J�[�R�[�h�P�P
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd11
            //���i���[�J�[�R�[�h�P�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd12
            //���i���[�J�[�R�[�h�P�R
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd13
            //���i���[�J�[�R�[�h�P�S
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd14
            //���i���[�J�[�R�[�h�P�T
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_GoodsMakerCd15
            //���i�n�d�l�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SAndESettingRF_PartsOEMDiv
            // --- ADD 2009.07.24 ���m ------ <<<<<<
            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            //����P���[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_SALESUNPRCFRCPROCCD
            //������z�[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_SALESMONEYFRCPROCCDRF
            //�������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CSTCST_SALESCNSTAXFRCPROCCDRF
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            //QR�R�[�h���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CSTCST_QRCODEPRTCDRF
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            //����f�[�^�w�b�_�K�C�h
            serInfo.MemberInfo.Add(typeof(byte[])); //SALESSLIPRF_FILEHEADERGUID
            // 2010/07/06 Add <<<
            // ---- ADD caohh 2011/08/17 ------>>>>>
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_POSTNORF
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_ADDRESS1RF
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_ADDRESS3RF
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_ADDRESS4RF
            //�d�b�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_HOMETELNORF
            //�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_OFFICETELNORF
            //�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_PORTABLETELNORF
            //FAX�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_HOMEFAXNORF
            //FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_OFFICEFAXNORF
            //�d�b�ԍ��i���̑��j
            serInfo.MemberInfo.Add(typeof(string)); //CSTCST_OTHERSTELNORF
            // ---- ADD caohh 2011/08/17 ------<<<<< 

            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePSalesSlipWork )
            {
                FrePSalesSlipWork temp = (FrePSalesSlipWork)graph;

                SetFrePSalesSlipWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePSalesSlipWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePSalesSlipWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePSalesSlipWork temp in lst )
                {
                    SetFrePSalesSlipWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePSalesSlipWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD m.suzuki 2010/03/24 ---------->>>>>
        //// private const int currentMemberCount = 359; // DEL 2009.07.24 ���m
        //// --- ADD  ���r��  2010/03/01 ---------->>>>>
        ////private const int currentMemberCount = 393;  // ADD 2009.07.24 ���m
        //private const int currentMemberCount = 396;
        //// --- ADD  ���r��  2010/03/01 ----------<<<<<
        // 2010/07/06 >>>
        //private const int currentMemberCount = 397;
        //private const int currentMemberCount = 398;// DEL 2011/08/17 caohh
        private const int currentMemberCount = 408;  // ADD 2011/08/17 caohh
        // 2010/07/06 <<<
        // --- UPD m.suzuki 2010/03/24 ----------<<<<<

        /// <summary>
        ///  FrePSalesSlipWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesSlipWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFrePSalesSlipWork( System.IO.BinaryWriter writer, FrePSalesSlipWork temp )
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
            //�ԍ��A������`�[�ԍ�
            writer.Write( temp.SALESSLIPRF_DEBITNLNKSALESSLNUMRF );
            //����`�[�敪
            writer.Write( temp.SALESSLIPRF_SALESSLIPCDRF );
            //���㏤�i�敪
            writer.Write( temp.SALESSLIPRF_SALESGOODSCDRF );
            //���|�敪
            writer.Write( temp.SALESSLIPRF_ACCRECDIVCDRF );
            //�`�[�������t
            writer.Write( temp.SALESSLIPRF_SEARCHSLIPDATERF );
            //�o�ד��t
            writer.Write( temp.SALESSLIPRF_SHIPMENTDAYRF );
            //������t
            writer.Write( temp.SALESSLIPRF_SALESDATERF );
            //�v����t
            writer.Write( temp.SALESSLIPRF_ADDUPADATERF );
            //�����敪
            writer.Write( temp.SALESSLIPRF_DELAYPAYMENTDIVRF );
            //���Ϗ��ԍ�
            writer.Write( temp.SALESSLIPRF_ESTIMATEFORMNORF );
            //���ϋ敪
            writer.Write( temp.SALESSLIPRF_ESTIMATEDIVIDERF );
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
            //���z�\�����@�敪
            writer.Write( temp.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF );
            //���z�\���|���K�p�敪
            writer.Write( temp.SALESSLIPRF_TTLAMNTDISPRATEAPYRF );
            //����`�[���v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXINCRF );
            //����`�[���v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESTOTALTAXEXCRF );
            //���㏬�v�i�ō��݁j
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF );
            //���㏬�v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF );
            //���㏬�v�i�Łj
            writer.Write( temp.SALESSLIPRF_SALESSUBTOTALTAXRF );
            //����O�őΏۊz
            writer.Write( temp.SALESSLIPRF_ITDEDSALESOUTTAXRF );
            //������őΏۊz
            writer.Write( temp.SALESSLIPRF_ITDEDSALESINTAXRF );
            //���㏬�v��ېőΏۊz
            writer.Write( temp.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF );
            //������z����Ŋz�i���Łj
            writer.Write( temp.SALESSLIPRF_SALAMNTCONSTAXINCLURF );
            //����l�����z�v�i�Ŕ����j
            writer.Write( temp.SALESSLIPRF_SALESDISTTLTAXEXCRF );
            //����l���O�őΏۊz���v
            writer.Write( temp.SALESSLIPRF_ITDEDSALESDISOUTTAXRF );
            //����l�����őΏۊz���v
            writer.Write( temp.SALESSLIPRF_ITDEDSALESDISINTAXRF );
            //����l������Ŋz�i�O�Łj
            writer.Write( temp.SALESSLIPRF_SALESDISOUTTAXRF );
            //����l������Ŋz�i���Łj
            writer.Write( temp.SALESSLIPRF_SALESDISTTLTAXINCLURF );
            //�������z�v
            writer.Write( temp.SALESSLIPRF_TOTALCOSTRF );
            //����œ]�ŕ���
            writer.Write( temp.SALESSLIPRF_CONSTAXLAYMETHODRF );
            //����Őŗ�
            writer.Write( temp.SALESSLIPRF_CONSTAXRATERF );
            //�[�������敪
            writer.Write( temp.SALESSLIPRF_FRACTIONPROCCDRF );
            //���|�����
            writer.Write( temp.SALESSLIPRF_ACCRECCONSTAXRF );
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
            //�����旪��
            writer.Write( temp.SALESSLIPRF_CLAIMSNMRF );
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
            //�[�i��X�֔ԍ�
            writer.Write( temp.SALESSLIPRF_ADDRESSEEPOSTNORF );
            //�[�i��Z��1(�s���{���s��S�E�����E��)
            writer.Write( temp.SALESSLIPRF_ADDRESSEEADDR1RF );
            //�[�i��Z��3(�Ԓn)
            writer.Write( temp.SALESSLIPRF_ADDRESSEEADDR3RF );
            //�[�i��Z��4(�A�p�[�g����)
            writer.Write( temp.SALESSLIPRF_ADDRESSEEADDR4RF );
            //�[�i��d�b�ԍ�
            writer.Write( temp.SALESSLIPRF_ADDRESSEETELNORF );
            //�[�i��FAX�ԍ�
            writer.Write( temp.SALESSLIPRF_ADDRESSEEFAXNORF );
            //�����`�[�ԍ�
            writer.Write( temp.SALESSLIPRF_PARTYSALESLIPNUMRF );
            //�`�[���l
            writer.Write( temp.SALESSLIPRF_SLIPNOTERF );
            //�`�[���l�Q
            writer.Write( temp.SALESSLIPRF_SLIPNOTE2RF );
            //�ԕi���R�R�[�h
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONDIVRF );
            //�ԕi���R
            writer.Write( temp.SALESSLIPRF_RETGOODSREASONRF );
            //���W������
            writer.Write( temp.SALESSLIPRF_REGIPROCDATERF );
            //���W�ԍ�
            writer.Write( temp.SALESSLIPRF_CASHREGISTERNORF );
            //POS���V�[�g�ԍ�
            writer.Write( temp.SALESSLIPRF_POSRECEIPTNORF );
            //���׍s��
            writer.Write( temp.SALESSLIPRF_DETAILROWCOUNTRF );
            //�d�c�h���M��
            writer.Write( temp.SALESSLIPRF_EDISENDDATERF );
            //�d�c�h�捞��
            writer.Write( temp.SALESSLIPRF_EDITAKEINDATERF );
            //�t�n�d���}�[�N�P
            writer.Write( temp.SALESSLIPRF_UOEREMARK1RF );
            //�t�n�d���}�[�N�Q
            writer.Write( temp.SALESSLIPRF_UOEREMARK2RF );
            //�`�[���s�ϋ敪
            writer.Write( temp.SALESSLIPRF_SLIPPRINTFINISHCDRF );
            //����`�[���s��
            writer.Write( temp.SALESSLIPRF_SALESSLIPPRINTDATERF );
            //�Ǝ�R�[�h
            writer.Write( temp.SALESSLIPRF_BUSINESSTYPECODERF );
            //�Ǝ햼��
            writer.Write( temp.SALESSLIPRF_BUSINESSTYPENAMERF );
            //�����ԍ�
            writer.Write( temp.SALESSLIPRF_ORDERNUMBERRF );
            //�[�i�敪
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVRF );
            //�[�i�敪����
            writer.Write( temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF );
            //�̔��G���A�R�[�h
            writer.Write( temp.SALESSLIPRF_SALESAREACODERF );
            //�̔��G���A����
            writer.Write( temp.SALESSLIPRF_SALESAREANAMERF );
            //�݌ɏ��i���v���z�i�Ŕ��j
            writer.Write( temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF );
            //�������i���v���z�i�Ŕ��j
            writer.Write( temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF );
            //�艿����敪
            writer.Write( temp.SALESSLIPRF_LISTPRICEPRINTDIVRF );
            //�����\���敪�P
            writer.Write( temp.SALESSLIPRF_ERANAMEDISPCD1RF );
            //���Ϗ���ŋ敪
            writer.Write( temp.SALESSLIPRF_ESTIMATAXDIVCDRF );
            //���Ϗ�����敪
            writer.Write( temp.SALESSLIPRF_ESTIMATEFORMPRTCDRF );
            //���ό���
            writer.Write( temp.SALESSLIPRF_ESTIMATESUBJECTRF );
            //�r���P
            writer.Write( temp.SALESSLIPRF_FOOTNOTES1RF );
            //�r���Q
            writer.Write( temp.SALESSLIPRF_FOOTNOTES2RF );
            //���σ^�C�g���P
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE1RF );
            //���σ^�C�g���Q
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE2RF );
            //���σ^�C�g���R
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE3RF );
            //���σ^�C�g���S
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE4RF );
            //���σ^�C�g���T
            writer.Write( temp.SALESSLIPRF_ESTIMATETITLE5RF );
            //���ϔ��l�P
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE1RF );
            //���ϔ��l�Q
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE2RF );
            //���ϔ��l�R
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE3RF );
            //���ϔ��l�S
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE4RF );
            //���ϔ��l�T
            writer.Write( temp.SALESSLIPRF_ESTIMATENOTE5RF );
            //���_�K�C�h����
            writer.Write( temp.SECINFOSETRF_SECTIONGUIDENMRF );
            //���_�K�C�h����
            writer.Write( temp.SECINFOSETRF_SECTIONGUIDESNMRF );
            //���Ж��̃R�[�h1
            writer.Write( temp.SECINFOSETRF_COMPANYNAMECD1RF );
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
            //�摜���敪
            writer.Write( temp.COMPANYNMRF_IMAGEINFODIVRF );
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
            //���Љ摜
            writer.Write( temp.IMAGEINFORF_IMAGEINFODATARF );
            //���喼��
            writer.Write( temp.SUBSECTIONRF_SUBSECTIONNAMERF );
            //������͎҃J�i
            writer.Write( temp.EMPINP_KANARF );
            //������͎ҒZ�k����
            writer.Write( temp.EMPINP_SHORTNAMERF );
            //��t�]�ƈ��J�i
            writer.Write( temp.EMPFRT_KANARF );
            //��t�]�ƈ��Z�k����
            writer.Write( temp.EMPFRT_SHORTNAMERF );
            //�̔��]�ƈ��J�i
            writer.Write( temp.EMPSAL_KANARF );
            //�̔��]�ƈ��Z�k����
            writer.Write( temp.EMPSAL_SHORTNAMERF );
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
            //�[����T�u�R�[�h
            writer.Write( temp.CSTADR_CUSTOMERSUBCODERF );
            //�[���於��
            writer.Write( temp.CSTADR_NAMERF );
            //�[���於��2
            writer.Write( temp.CSTADR_NAME2RF );
            //�[����h��
            writer.Write( temp.CSTADR_HONORIFICTITLERF );
            //�[����J�i
            writer.Write( temp.CSTADR_KANARF );
            //�[���旪��
            writer.Write( temp.CSTADR_CUSTOMERSNMRF );
            //�[���揔���R�[�h
            writer.Write( temp.CSTADR_OUTPUTNAMECODERF );
            //�[���敪�̓R�[�h1
            writer.Write( temp.CSTADR_CUSTANALYSCODE1RF );
            //�[���敪�̓R�[�h2
            writer.Write( temp.CSTADR_CUSTANALYSCODE2RF );
            //�[���敪�̓R�[�h3
            writer.Write( temp.CSTADR_CUSTANALYSCODE3RF );
            //�[���敪�̓R�[�h4
            writer.Write( temp.CSTADR_CUSTANALYSCODE4RF );
            //�[���敪�̓R�[�h5
            writer.Write( temp.CSTADR_CUSTANALYSCODE5RF );
            //�[���敪�̓R�[�h6
            writer.Write( temp.CSTADR_CUSTANALYSCODE6RF );
            //�[������l1
            writer.Write( temp.CSTADR_NOTE1RF );
            //�[������l2
            writer.Write( temp.CSTADR_NOTE2RF );
            //�[������l3
            writer.Write( temp.CSTADR_NOTE3RF );
            //�[������l4
            writer.Write( temp.CSTADR_NOTE4RF );
            //�[������l5
            writer.Write( temp.CSTADR_NOTE5RF );
            //�[������l6
            writer.Write( temp.CSTADR_NOTE6RF );
            //�[������l7
            writer.Write( temp.CSTADR_NOTE7RF );
            //�[������l8
            writer.Write( temp.CSTADR_NOTE8RF );
            //�[������l9
            writer.Write( temp.CSTADR_NOTE9RF );
            //�[������l10
            writer.Write( temp.CSTADR_NOTE10RF );
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
            //�󒍃X�e�[�^�X����
            writer.Write( temp.HADD_ACPTANODRSTNMRF );
            //�ԓ`�敪����
            writer.Write( temp.HADD_DEBITNOTEDIVNMRF );
            //����`�[�敪����
            writer.Write( temp.HADD_SALESSLIPNMRF );
            //���㏤�i�敪����
            writer.Write( temp.HADD_SALESGOODSNMRF );
            //���|�敪����
            writer.Write( temp.HADD_ACCRECDIVNMRF );
            //�����敪����
            writer.Write( temp.HADD_DELAYPAYMENTDIVNMRF );
            //���ϋ敪����
            writer.Write( temp.HADD_ESTIMATEDIVIDENMRF );
            //����œ]�ŕ�������
            writer.Write( temp.HADD_CONSTAXLAYMETHODNMRF );
            //���������敪����
            writer.Write( temp.HADD_AUTODEPOSITNMRF );
            //�`�[���s�ϋ敪����
            writer.Write( temp.HADD_SLIPPRINTFINISHNMRF );
            //�ꎮ�`�[�敪����
            writer.Write( temp.HADD_COMPLETENMRF );
            //(�擪)�ԗ��Ǘ��ԍ�
            writer.Write( temp.HADD_CARMNGNORF );
            //(�擪)���q�Ǘ��R�[�h
            writer.Write( temp.HADD_CARMNGCODERF );
            //(�擪)���^�������ԍ�
            writer.Write( temp.HADD_NUMBERPLATE1CODERF );
            //(�擪)���^�����ǖ���
            writer.Write( temp.HADD_NUMBERPLATE1NAMERF );
            //(�擪)�ԗ��o�^�ԍ��i��ʁj
            writer.Write( temp.HADD_NUMBERPLATE2RF );
            //(�擪)�ԗ��o�^�ԍ��i�J�i�j
            writer.Write( temp.HADD_NUMBERPLATE3RF );
            //(�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            writer.Write( temp.HADD_NUMBERPLATE4RF );
            //(�擪)���N�x
            writer.Write( temp.HADD_FIRSTENTRYDATERF );
            //(�擪)���[�J�[�R�[�h
            writer.Write( temp.HADD_MAKERCODERF );
            //(�擪)���[�J�[�S�p����
            writer.Write( temp.HADD_MAKERFULLNAMERF );
            //(�擪)�Ԏ�R�[�h
            writer.Write( temp.HADD_MODELCODERF );
            //(�擪)�Ԏ�T�u�R�[�h
            writer.Write( temp.HADD_MODELSUBCODERF );
            //(�擪)�Ԏ�S�p����
            writer.Write( temp.HADD_MODELFULLNAMERF );
            //(�擪)�r�K�X�L��
            writer.Write( temp.HADD_EXHAUSTGASSIGNRF );
            //(�擪)�V���[�Y�^��
            writer.Write( temp.HADD_SERIESMODELRF );
            //(�擪)�^���i�ޕʋL���j
            writer.Write( temp.HADD_CATEGORYSIGNMODELRF );
            //(�擪)�^���i�t���^�j
            writer.Write( temp.HADD_FULLMODELRF );
            //(�擪)�^���w��ԍ�
            writer.Write( temp.HADD_MODELDESIGNATIONNORF );
            //(�擪)�ޕʔԍ�
            writer.Write( temp.HADD_CATEGORYNORF );
            //(�擪)�ԑ�^��
            writer.Write( temp.HADD_FRAMEMODELRF );
            //(�擪)�ԑ�ԍ�
            writer.Write( temp.HADD_FRAMENORF );
            //(�擪)�ԑ�ԍ��i�����p�j
            writer.Write( temp.HADD_SEARCHFRAMENORF );
            //(�擪)�G���W���^������
            writer.Write( temp.HADD_ENGINEMODELNMRF );
            //(�擪)�֘A�^��
            writer.Write( temp.HADD_RELEVANCEMODELRF );
            //(�擪)�T�u�Ԗ��R�[�h
            writer.Write( temp.HADD_SUBCARNMCDRF );
            //(�擪)�^���O���[�h����
            writer.Write( temp.HADD_MODELGRADESNAMERF );
            //(�擪)�J���[�R�[�h
            writer.Write( temp.HADD_COLORCODERF );
            //(�擪)�J���[����1
            writer.Write( temp.HADD_COLORNAME1RF );
            //(�擪)�g�����R�[�h
            writer.Write( temp.HADD_TRIMCODERF );
            //(�擪)�g��������
            writer.Write( temp.HADD_TRIMNAMERF );
            //(�擪)�ԗ����s����
            writer.Write( temp.HADD_MILEAGERF );
            //�v�����^�Ǘ�No
            writer.Write( temp.HADD_PRINTERMNGNORF );
            //�`�[����ݒ�p���[ID
            writer.Write( temp.HADD_SLIPPRTSETPAPERIDRF );
            //���Д��l�P
            writer.Write( temp.HADD_NOTE1RF );
            //���Д��l�Q
            writer.Write( temp.HADD_NOTE2RF );
            //���Д��l�R
            writer.Write( temp.HADD_NOTE3RF );
            //�Ĕ��s�}�[�N
            writer.Write( temp.HADD_REISSUEMARKRF );
            //�Q�l����ň󎚖���
            writer.Write( temp.HADD_REFCONSTAXPRTNMRF );
            //������� ��
            writer.Write( temp.HADD_PRINTTIMEHOURRF );
            //������� ��
            writer.Write( temp.HADD_PRINTTIMEMINUTERF );
            //������� �b
            writer.Write( temp.HADD_PRINTTIMESECONDRF );
            //�`�[�������t����N
            writer.Write( temp.HADD_SEARCHSLIPDATEFYRF );
            //�`�[�������t����N��
            writer.Write( temp.HADD_SEARCHSLIPDATEFSRF );
            //�`�[�������t�a��N
            writer.Write( temp.HADD_SEARCHSLIPDATEFWRF );
            //�`�[�������t��
            writer.Write( temp.HADD_SEARCHSLIPDATEFMRF );
            //�`�[�������t��
            writer.Write( temp.HADD_SEARCHSLIPDATEFDRF );
            //�`�[�������t����
            writer.Write( temp.HADD_SEARCHSLIPDATEFGRF );
            //�`�[�������t����
            writer.Write( temp.HADD_SEARCHSLIPDATEFRRF );
            //�`�[�������t���e����(/)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLSRF );
            //�`�[�������t���e����(.)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLPRF );
            //�`�[�������t���e����(�N)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLYRF );
            //�`�[�������t���e����(��)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLMRF );
            //�`�[�������t���e����(��)
            writer.Write( temp.HADD_SEARCHSLIPDATEFLDRF );
            //�o�ד��t����N
            writer.Write( temp.HADD_SHIPMENTDAYFYRF );
            //�o�ד��t����N��
            writer.Write( temp.HADD_SHIPMENTDAYFSRF );
            //�o�ד��t�a��N
            writer.Write( temp.HADD_SHIPMENTDAYFWRF );
            //�o�ד��t��
            writer.Write( temp.HADD_SHIPMENTDAYFMRF );
            //�o�ד��t��
            writer.Write( temp.HADD_SHIPMENTDAYFDRF );
            //�o�ד��t����
            writer.Write( temp.HADD_SHIPMENTDAYFGRF );
            //�o�ד��t����
            writer.Write( temp.HADD_SHIPMENTDAYFRRF );
            //�o�ד��t���e����(/)
            writer.Write( temp.HADD_SHIPMENTDAYFLSRF );
            //�o�ד��t���e����(.)
            writer.Write( temp.HADD_SHIPMENTDAYFLPRF );
            //�o�ד��t���e����(�N)
            writer.Write( temp.HADD_SHIPMENTDAYFLYRF );
            //�o�ד��t���e����(��)
            writer.Write( temp.HADD_SHIPMENTDAYFLMRF );
            //�o�ד��t���e����(��)
            writer.Write( temp.HADD_SHIPMENTDAYFLDRF );
            //������t����N
            writer.Write( temp.HADD_SALESDATEFYRF );
            //������t����N��
            writer.Write( temp.HADD_SALESDATEFSRF );
            //������t�a��N
            writer.Write( temp.HADD_SALESDATEFWRF );
            //������t��
            writer.Write( temp.HADD_SALESDATEFMRF );
            //������t��
            writer.Write( temp.HADD_SALESDATEFDRF );
            //������t����
            writer.Write( temp.HADD_SALESDATEFGRF );
            //������t����
            writer.Write( temp.HADD_SALESDATEFRRF );
            //������t���e����(/)
            writer.Write( temp.HADD_SALESDATEFLSRF );
            //������t���e����(.)
            writer.Write( temp.HADD_SALESDATEFLPRF );
            //������t���e����(�N)
            writer.Write( temp.HADD_SALESDATEFLYRF );
            //������t���e����(��)
            writer.Write( temp.HADD_SALESDATEFLMRF );
            //������t���e����(��)
            writer.Write( temp.HADD_SALESDATEFLDRF );
            //�v����t����N
            writer.Write( temp.HADD_ADDUPADATEFYRF );
            //�v����t����N��
            writer.Write( temp.HADD_ADDUPADATEFSRF );
            //�v����t�a��N
            writer.Write( temp.HADD_ADDUPADATEFWRF );
            //�v����t��
            writer.Write( temp.HADD_ADDUPADATEFMRF );
            //�v����t��
            writer.Write( temp.HADD_ADDUPADATEFDRF );
            //�v����t����
            writer.Write( temp.HADD_ADDUPADATEFGRF );
            //�v����t����
            writer.Write( temp.HADD_ADDUPADATEFRRF );
            //�v����t���e����(/)
            writer.Write( temp.HADD_ADDUPADATEFLSRF );
            //�v����t���e����(.)
            writer.Write( temp.HADD_ADDUPADATEFLPRF );
            //�v����t���e����(�N)
            writer.Write( temp.HADD_ADDUPADATEFLYRF );
            //�v����t���e����(��)
            writer.Write( temp.HADD_ADDUPADATEFLMRF );
            //�v����t���e����(��)
            writer.Write( temp.HADD_ADDUPADATEFLDRF );
            //����`�[���s������N
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFYRF );
            //����`�[���s������N��
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFSRF );
            //����`�[���s���a��N
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFWRF );
            //����`�[���s����
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFMRF );
            //����`�[���s����
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFDRF );
            //����`�[���s������
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFGRF );
            //����`�[���s������
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFRRF );
            //����`�[���s�����e����(/)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLSRF );
            //����`�[���s�����e����(.)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLPRF );
            //����`�[���s�����e����(�N)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLYRF );
            //����`�[���s�����e����(��)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLMRF );
            //����`�[���s�����e����(��)
            writer.Write( temp.HADD_SALESSLIPPRINTDATEFLDRF );
            //(�擪)���N�x����N
            writer.Write( temp.HADD_FIRSTENTRYDATEFYRF );
            //(�擪)���N�x����N��
            writer.Write( temp.HADD_FIRSTENTRYDATEFSRF );
            //(�擪)���N�x�a��N
            writer.Write( temp.HADD_FIRSTENTRYDATEFWRF );
            //(�擪)���N�x��
            writer.Write( temp.HADD_FIRSTENTRYDATEFMRF );
            //(�擪)���N�x��
            writer.Write( temp.HADD_FIRSTENTRYDATEFDRF );
            //(�擪)���N�x����
            writer.Write( temp.HADD_FIRSTENTRYDATEFGRF );
            //(�擪)���N�x����
            writer.Write( temp.HADD_FIRSTENTRYDATEFRRF );
            //(�擪)���N�x���e����(/)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLSRF );
            //(�擪)���N�x���e����(.)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLPRF );
            //(�擪)���N�x���e����(�N)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLYRF );
            //(�擪)���N�x���e����(��)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLMRF );
            //(�擪)���N�x���e����(��)
            writer.Write( temp.HADD_FIRSTENTRYDATEFLDRF );
            //����p���Ӑ於�́i��i�j
            writer.Write( temp.HADD_PRINTCUSTOMERNAME1RF );
            //����p���Ӑ於�́i���i�j
            writer.Write( temp.HADD_PRINTCUSTOMERNAME2RF );
            //����p���Ӑ於�́i���i�j�{�h��
            writer.Write( temp.HADD_PRINTCUSTOMERNAME2HNRF );
            //(�擪)���[�J�[���p����
            writer.Write( temp.HADD_MAKERHALFNAMERF );
            //(�擪)�Ԏ피�p����
            writer.Write( temp.HADD_MODELHALFNAMERF );
            //�`�[���l�R
            writer.Write( temp.SALESSLIPRF_SLIPNOTE3RF );
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
            //���ьv�㋒�_�R�[�h
            writer.Write( temp.SALESSLIPRF_RESULTSADDUPSECCDRF );
            //�X�V����
            writer.Write( temp.SALESSLIPRF_UPDATEDATETIMERF );

            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //���Ӑ�R�[�h
            writer.Write(temp.SANDESETTINGRF_CUSTOMERCODE);
            //�[�i��X�܃R�[�h
            writer.Write(temp.SANDESETTINGRF_ADDRESSEESHOPCD);
            //�Z�d�Ǘ��R�[�h
            writer.Write(temp.SANDESETTINGRF_SANDEMNGCODE);
            //�o��敪
            writer.Write(temp.SANDESETTINGRF_EXPENSEDIVCD);
            //�����敪
            writer.Write(temp.SANDESETTINGRF_DIRECTSENDINGCD);
            //�󒍋敪
            writer.Write(temp.SANDESETTINGRF_ACPTANORDERDIV);
            //�[�i�҃R�[�h
            writer.Write(temp.SANDESETTINGRF_DELIVERERCD);
            //�[�i�Җ�
            writer.Write(temp.SANDESETTINGRF_DELIVERERNM);
            //�[�i�ҏZ��
            writer.Write(temp.SANDESETTINGRF_DELIVERERADDRESS);
            //�[�i�҂s�d�k
            writer.Write(temp.SANDESETTINGRF_DELIVERERPHONENUM);
            //���i����
            writer.Write(temp.SANDESETTINGRF_TRADCOMPNAME);
            //���i�����_��
            writer.Write(temp.SANDESETTINGRF_TRADCOMPSECTNAME);
            //���i���R�[�h�i�����j
            writer.Write(temp.SANDESETTINGRF_PURETRADCOMPCD);
            //���i���d�ؗ��i�����j
            writer.Write(temp.SANDESETTINGRF_PURETRADCOMPRATE);
            //���i���R�[�h�i�D�ǁj
            writer.Write(temp.SANDESETTINGRF_PRITRADCOMPCD);
            //���i���d�ؗ��i�D�ǁj
            writer.Write(temp.SANDESETTINGRF_PRITRADCOMPRATE);
            //AB���i�R�[�h
            writer.Write(temp.SANDESETTINGRF_ABGOODSCODE);
            //�R�����g�w��敪
            writer.Write(temp.SANDESETTINGRF_COMMENTRESERVEDDIV);
            //���i���[�J�[�R�[�h�P
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD1);
            //���i���[�J�[�R�[�h�Q
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD2);
            //���i���[�J�[�R�[�h�R
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD3);
            //���i���[�J�[�R�[�h�S
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD4);
            //���i���[�J�[�R�[�h�T
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD5);
            //���i���[�J�[�R�[�h�U
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD6);
            //���i���[�J�[�R�[�h�V
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD7);
            //���i���[�J�[�R�[�h�W
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD8);
            //���i���[�J�[�R�[�h�X
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD9);
            //���i���[�J�[�R�[�h�P�O
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD10);
            //���i���[�J�[�R�[�h�P�P
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD11);
            //���i���[�J�[�R�[�h�P�Q
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD12);
            //���i���[�J�[�R�[�h�P�R
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD13);
            //���i���[�J�[�R�[�h�P�S
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD14);
            //���i���[�J�[�R�[�h�P�T
            writer.Write(temp.SANDESETTINGRF_GOODSMAKERCD15);
            //���i�n�d�l�敪
            writer.Write(temp.SANDESETTINGRF_PARTSOEMDIV);
            // --- ADD 2009.07.24 ���m ------ <<<<<<
            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            //����P���[�������R�[�h
            writer.Write(temp.CSTCST_SALESUNPRCFRCPROCCDRF);
            //������z�[�������R�[�h
            writer.Write(temp.CSTCST_SALESMONEYFRCPROCCDRF);
            //�������Œ[�������R�[�h
            writer.Write(temp.CSTCST_SALESCNSTAXFRCPROCCDRF);
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            //QR�R�[�h���
            writer.Write( temp.CSTCST_QRCODEPRTCDRF );
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            //����w�b�_�K�C�h
            byte[] fileHeaderGuidArray = temp.SALESSLIPRF_FILEHEADERGUID.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.SALESSLIPRF_FILEHEADERGUID.ToByteArray());
            // 2010/07/06 Add <<<
            // ---- ADD caohh 2011/08/17 ------>>>>>
            //�X�֔ԍ�
            writer.Write(temp.CSTCST_POSTNORF);
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.CSTCST_ADDRESS1RF);
            //�Z��3�i�Ԓn�j
            writer.Write(temp.CSTCST_ADDRESS3RF);
            //�Z��4�i�A�p�[�g���́j
            writer.Write(temp.CSTCST_ADDRESS4RF);
            //�d�b�ԍ��i����j
            writer.Write(temp.CSTCST_HOMETELNORF);
            //�d�b�ԍ��i�Ζ���j
            writer.Write(temp.CSTCST_OFFICETELNORF);
            //�d�b�ԍ��i�g�сj
            writer.Write(temp.CSTCST_PORTABLETELNORF);
            //FAX�ԍ��i����j
            writer.Write(temp.CSTCST_HOMEFAXNORF);
            //FAX�ԍ��i�Ζ���j
            writer.Write(temp.CSTCST_OFFICEFAXNORF);
            //�d�b�ԍ��i���̑��j
            writer.Write(temp.CSTCST_OTHERSTELNORF);
            // ---- ADD caohh 2011/08/17 ------<<<<<

        }

        /// <summary>
        ///  FrePSalesSlipWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FrePSalesSlipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesSlipWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FrePSalesSlipWork GetFrePSalesSlipWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FrePSalesSlipWork temp = new FrePSalesSlipWork();

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
            //�ԍ��A������`�[�ԍ�
            temp.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = reader.ReadString();
            //����`�[�敪
            temp.SALESSLIPRF_SALESSLIPCDRF = reader.ReadInt32();
            //���㏤�i�敪
            temp.SALESSLIPRF_SALESGOODSCDRF = reader.ReadInt32();
            //���|�敪
            temp.SALESSLIPRF_ACCRECDIVCDRF = reader.ReadInt32();
            //�`�[�������t
            temp.SALESSLIPRF_SEARCHSLIPDATERF = reader.ReadInt32();
            //�o�ד��t
            temp.SALESSLIPRF_SHIPMENTDAYRF = reader.ReadInt32();
            //������t
            temp.SALESSLIPRF_SALESDATERF = reader.ReadInt32();
            //�v����t
            temp.SALESSLIPRF_ADDUPADATERF = reader.ReadInt32();
            //�����敪
            temp.SALESSLIPRF_DELAYPAYMENTDIVRF = reader.ReadInt32();
            //���Ϗ��ԍ�
            temp.SALESSLIPRF_ESTIMATEFORMNORF = reader.ReadString();
            //���ϋ敪
            temp.SALESSLIPRF_ESTIMATEDIVIDERF = reader.ReadInt32();
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
            //���z�\�����@�敪
            temp.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = reader.ReadInt32();
            //���z�\���|���K�p�敪
            temp.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = reader.ReadInt32();
            //����`�[���v�i�ō��݁j
            temp.SALESSLIPRF_SALESTOTALTAXINCRF = reader.ReadInt64();
            //����`�[���v�i�Ŕ����j
            temp.SALESSLIPRF_SALESTOTALTAXEXCRF = reader.ReadInt64();
            //���㏬�v�i�ō��݁j
            temp.SALESSLIPRF_SALESSUBTOTALTAXINCRF = reader.ReadInt64();
            //���㏬�v�i�Ŕ����j
            temp.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = reader.ReadInt64();
            //���㏬�v�i�Łj
            temp.SALESSLIPRF_SALESSUBTOTALTAXRF = reader.ReadInt64();
            //����O�őΏۊz
            temp.SALESSLIPRF_ITDEDSALESOUTTAXRF = reader.ReadInt64();
            //������őΏۊz
            temp.SALESSLIPRF_ITDEDSALESINTAXRF = reader.ReadInt64();
            //���㏬�v��ېőΏۊz
            temp.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = reader.ReadInt64();
            //������z����Ŋz�i���Łj
            temp.SALESSLIPRF_SALAMNTCONSTAXINCLURF = reader.ReadInt64();
            //����l�����z�v�i�Ŕ����j
            temp.SALESSLIPRF_SALESDISTTLTAXEXCRF = reader.ReadInt64();
            //����l���O�őΏۊz���v
            temp.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = reader.ReadInt64();
            //����l�����őΏۊz���v
            temp.SALESSLIPRF_ITDEDSALESDISINTAXRF = reader.ReadInt64();
            //����l������Ŋz�i�O�Łj
            temp.SALESSLIPRF_SALESDISOUTTAXRF = reader.ReadInt64();
            //����l������Ŋz�i���Łj
            temp.SALESSLIPRF_SALESDISTTLTAXINCLURF = reader.ReadInt64();
            //�������z�v
            temp.SALESSLIPRF_TOTALCOSTRF = reader.ReadInt64();
            //����œ]�ŕ���
            temp.SALESSLIPRF_CONSTAXLAYMETHODRF = reader.ReadInt32();
            //����Őŗ�
            temp.SALESSLIPRF_CONSTAXRATERF = reader.ReadDouble();
            //�[�������敪
            temp.SALESSLIPRF_FRACTIONPROCCDRF = reader.ReadInt32();
            //���|�����
            temp.SALESSLIPRF_ACCRECCONSTAXRF = reader.ReadInt64();
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
            //�����旪��
            temp.SALESSLIPRF_CLAIMSNMRF = reader.ReadString();
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
            //�[�i��X�֔ԍ�
            temp.SALESSLIPRF_ADDRESSEEPOSTNORF = reader.ReadString();
            //�[�i��Z��1(�s���{���s��S�E�����E��)
            temp.SALESSLIPRF_ADDRESSEEADDR1RF = reader.ReadString();
            //�[�i��Z��3(�Ԓn)
            temp.SALESSLIPRF_ADDRESSEEADDR3RF = reader.ReadString();
            //�[�i��Z��4(�A�p�[�g����)
            temp.SALESSLIPRF_ADDRESSEEADDR4RF = reader.ReadString();
            //�[�i��d�b�ԍ�
            temp.SALESSLIPRF_ADDRESSEETELNORF = reader.ReadString();
            //�[�i��FAX�ԍ�
            temp.SALESSLIPRF_ADDRESSEEFAXNORF = reader.ReadString();
            //�����`�[�ԍ�
            temp.SALESSLIPRF_PARTYSALESLIPNUMRF = reader.ReadString();
            //�`�[���l
            temp.SALESSLIPRF_SLIPNOTERF = reader.ReadString();
            //�`�[���l�Q
            temp.SALESSLIPRF_SLIPNOTE2RF = reader.ReadString();
            //�ԕi���R�R�[�h
            temp.SALESSLIPRF_RETGOODSREASONDIVRF = reader.ReadInt32();
            //�ԕi���R
            temp.SALESSLIPRF_RETGOODSREASONRF = reader.ReadString();
            //���W������
            temp.SALESSLIPRF_REGIPROCDATERF = reader.ReadInt32();
            //���W�ԍ�
            temp.SALESSLIPRF_CASHREGISTERNORF = reader.ReadInt32();
            //POS���V�[�g�ԍ�
            temp.SALESSLIPRF_POSRECEIPTNORF = reader.ReadInt32();
            //���׍s��
            temp.SALESSLIPRF_DETAILROWCOUNTRF = reader.ReadInt32();
            //�d�c�h���M��
            temp.SALESSLIPRF_EDISENDDATERF = reader.ReadInt32();
            //�d�c�h�捞��
            temp.SALESSLIPRF_EDITAKEINDATERF = reader.ReadInt32();
            //�t�n�d���}�[�N�P
            temp.SALESSLIPRF_UOEREMARK1RF = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.SALESSLIPRF_UOEREMARK2RF = reader.ReadString();
            //�`�[���s�ϋ敪
            temp.SALESSLIPRF_SLIPPRINTFINISHCDRF = reader.ReadInt32();
            //����`�[���s��
            temp.SALESSLIPRF_SALESSLIPPRINTDATERF = reader.ReadInt32();
            //�Ǝ�R�[�h
            temp.SALESSLIPRF_BUSINESSTYPECODERF = reader.ReadInt32();
            //�Ǝ햼��
            temp.SALESSLIPRF_BUSINESSTYPENAMERF = reader.ReadString();
            //�����ԍ�
            temp.SALESSLIPRF_ORDERNUMBERRF = reader.ReadString();
            //�[�i�敪
            temp.SALESSLIPRF_DELIVEREDGOODSDIVRF = reader.ReadInt32();
            //�[�i�敪����
            temp.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SALESSLIPRF_SALESAREACODERF = reader.ReadInt32();
            //�̔��G���A����
            temp.SALESSLIPRF_SALESAREANAMERF = reader.ReadString();
            //�݌ɏ��i���v���z�i�Ŕ��j
            temp.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = reader.ReadInt64();
            //�������i���v���z�i�Ŕ��j
            temp.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = reader.ReadInt64();
            //�艿����敪
            temp.SALESSLIPRF_LISTPRICEPRINTDIVRF = reader.ReadInt32();
            //�����\���敪�P
            temp.SALESSLIPRF_ERANAMEDISPCD1RF = reader.ReadInt32();
            //���Ϗ���ŋ敪
            temp.SALESSLIPRF_ESTIMATAXDIVCDRF = reader.ReadInt32();
            //���Ϗ�����敪
            temp.SALESSLIPRF_ESTIMATEFORMPRTCDRF = reader.ReadInt32();
            //���ό���
            temp.SALESSLIPRF_ESTIMATESUBJECTRF = reader.ReadString();
            //�r���P
            temp.SALESSLIPRF_FOOTNOTES1RF = reader.ReadString();
            //�r���Q
            temp.SALESSLIPRF_FOOTNOTES2RF = reader.ReadString();
            //���σ^�C�g���P
            temp.SALESSLIPRF_ESTIMATETITLE1RF = reader.ReadString();
            //���σ^�C�g���Q
            temp.SALESSLIPRF_ESTIMATETITLE2RF = reader.ReadString();
            //���σ^�C�g���R
            temp.SALESSLIPRF_ESTIMATETITLE3RF = reader.ReadString();
            //���σ^�C�g���S
            temp.SALESSLIPRF_ESTIMATETITLE4RF = reader.ReadString();
            //���σ^�C�g���T
            temp.SALESSLIPRF_ESTIMATETITLE5RF = reader.ReadString();
            //���ϔ��l�P
            temp.SALESSLIPRF_ESTIMATENOTE1RF = reader.ReadString();
            //���ϔ��l�Q
            temp.SALESSLIPRF_ESTIMATENOTE2RF = reader.ReadString();
            //���ϔ��l�R
            temp.SALESSLIPRF_ESTIMATENOTE3RF = reader.ReadString();
            //���ϔ��l�S
            temp.SALESSLIPRF_ESTIMATENOTE4RF = reader.ReadString();
            //���ϔ��l�T
            temp.SALESSLIPRF_ESTIMATENOTE5RF = reader.ReadString();
            //���_�K�C�h����
            temp.SECINFOSETRF_SECTIONGUIDENMRF = reader.ReadString();
            //���_�K�C�h����
            temp.SECINFOSETRF_SECTIONGUIDESNMRF = reader.ReadString();
            //���Ж��̃R�[�h1
            temp.SECINFOSETRF_COMPANYNAMECD1RF = reader.ReadInt32();
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
            //�摜���敪
            temp.COMPANYNMRF_IMAGEINFODIVRF = reader.ReadInt32();
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
            //���Љ摜
            //���喼��
            temp.SUBSECTIONRF_SUBSECTIONNAMERF = reader.ReadString();
            //������͎҃J�i
            temp.EMPINP_KANARF = reader.ReadString();
            //������͎ҒZ�k����
            temp.EMPINP_SHORTNAMERF = reader.ReadString();
            //��t�]�ƈ��J�i
            temp.EMPFRT_KANARF = reader.ReadString();
            //��t�]�ƈ��Z�k����
            temp.EMPFRT_SHORTNAMERF = reader.ReadString();
            //�̔��]�ƈ��J�i
            temp.EMPSAL_KANARF = reader.ReadString();
            //�̔��]�ƈ��Z�k����
            temp.EMPSAL_SHORTNAMERF = reader.ReadString();
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
            //�[����T�u�R�[�h
            temp.CSTADR_CUSTOMERSUBCODERF = reader.ReadString();
            //�[���於��
            temp.CSTADR_NAMERF = reader.ReadString();
            //�[���於��2
            temp.CSTADR_NAME2RF = reader.ReadString();
            //�[����h��
            temp.CSTADR_HONORIFICTITLERF = reader.ReadString();
            //�[����J�i
            temp.CSTADR_KANARF = reader.ReadString();
            //�[���旪��
            temp.CSTADR_CUSTOMERSNMRF = reader.ReadString();
            //�[���揔���R�[�h
            temp.CSTADR_OUTPUTNAMECODERF = reader.ReadInt32();
            //�[���敪�̓R�[�h1
            temp.CSTADR_CUSTANALYSCODE1RF = reader.ReadInt32();
            //�[���敪�̓R�[�h2
            temp.CSTADR_CUSTANALYSCODE2RF = reader.ReadInt32();
            //�[���敪�̓R�[�h3
            temp.CSTADR_CUSTANALYSCODE3RF = reader.ReadInt32();
            //�[���敪�̓R�[�h4
            temp.CSTADR_CUSTANALYSCODE4RF = reader.ReadInt32();
            //�[���敪�̓R�[�h5
            temp.CSTADR_CUSTANALYSCODE5RF = reader.ReadInt32();
            //�[���敪�̓R�[�h6
            temp.CSTADR_CUSTANALYSCODE6RF = reader.ReadInt32();
            //�[������l1
            temp.CSTADR_NOTE1RF = reader.ReadString();
            //�[������l2
            temp.CSTADR_NOTE2RF = reader.ReadString();
            //�[������l3
            temp.CSTADR_NOTE3RF = reader.ReadString();
            //�[������l4
            temp.CSTADR_NOTE4RF = reader.ReadString();
            //�[������l5
            temp.CSTADR_NOTE5RF = reader.ReadString();
            //�[������l6
            temp.CSTADR_NOTE6RF = reader.ReadString();
            //�[������l7
            temp.CSTADR_NOTE7RF = reader.ReadString();
            //�[������l8
            temp.CSTADR_NOTE8RF = reader.ReadString();
            //�[������l9
            temp.CSTADR_NOTE9RF = reader.ReadString();
            //�[������l10
            temp.CSTADR_NOTE10RF = reader.ReadString();
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
            //�󒍃X�e�[�^�X����
            temp.HADD_ACPTANODRSTNMRF = reader.ReadString();
            //�ԓ`�敪����
            temp.HADD_DEBITNOTEDIVNMRF = reader.ReadString();
            //����`�[�敪����
            temp.HADD_SALESSLIPNMRF = reader.ReadString();
            //���㏤�i�敪����
            temp.HADD_SALESGOODSNMRF = reader.ReadString();
            //���|�敪����
            temp.HADD_ACCRECDIVNMRF = reader.ReadString();
            //�����敪����
            temp.HADD_DELAYPAYMENTDIVNMRF = reader.ReadString();
            //���ϋ敪����
            temp.HADD_ESTIMATEDIVIDENMRF = reader.ReadString();
            //����œ]�ŕ�������
            temp.HADD_CONSTAXLAYMETHODNMRF = reader.ReadString();
            //���������敪����
            temp.HADD_AUTODEPOSITNMRF = reader.ReadString();
            //�`�[���s�ϋ敪����
            temp.HADD_SLIPPRINTFINISHNMRF = reader.ReadString();
            //�ꎮ�`�[�敪����
            temp.HADD_COMPLETENMRF = reader.ReadString();
            //(�擪)�ԗ��Ǘ��ԍ�
            temp.HADD_CARMNGNORF = reader.ReadInt32();
            //(�擪)���q�Ǘ��R�[�h
            temp.HADD_CARMNGCODERF = reader.ReadString();
            //(�擪)���^�������ԍ�
            temp.HADD_NUMBERPLATE1CODERF = reader.ReadInt32();
            //(�擪)���^�����ǖ���
            temp.HADD_NUMBERPLATE1NAMERF = reader.ReadString();
            //(�擪)�ԗ��o�^�ԍ��i��ʁj
            temp.HADD_NUMBERPLATE2RF = reader.ReadString();
            //(�擪)�ԗ��o�^�ԍ��i�J�i�j
            temp.HADD_NUMBERPLATE3RF = reader.ReadString();
            //(�擪)�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            temp.HADD_NUMBERPLATE4RF = reader.ReadInt32();
            //(�擪)���N�x
            temp.HADD_FIRSTENTRYDATERF = reader.ReadInt32();
            //(�擪)���[�J�[�R�[�h
            temp.HADD_MAKERCODERF = reader.ReadInt32();
            //(�擪)���[�J�[�S�p����
            temp.HADD_MAKERFULLNAMERF = reader.ReadString();
            //(�擪)�Ԏ�R�[�h
            temp.HADD_MODELCODERF = reader.ReadInt32();
            //(�擪)�Ԏ�T�u�R�[�h
            temp.HADD_MODELSUBCODERF = reader.ReadInt32();
            //(�擪)�Ԏ�S�p����
            temp.HADD_MODELFULLNAMERF = reader.ReadString();
            //(�擪)�r�K�X�L��
            temp.HADD_EXHAUSTGASSIGNRF = reader.ReadString();
            //(�擪)�V���[�Y�^��
            temp.HADD_SERIESMODELRF = reader.ReadString();
            //(�擪)�^���i�ޕʋL���j
            temp.HADD_CATEGORYSIGNMODELRF = reader.ReadString();
            //(�擪)�^���i�t���^�j
            temp.HADD_FULLMODELRF = reader.ReadString();
            //(�擪)�^���w��ԍ�
            temp.HADD_MODELDESIGNATIONNORF = reader.ReadInt32();
            //(�擪)�ޕʔԍ�
            temp.HADD_CATEGORYNORF = reader.ReadInt32();
            //(�擪)�ԑ�^��
            temp.HADD_FRAMEMODELRF = reader.ReadString();
            //(�擪)�ԑ�ԍ�
            temp.HADD_FRAMENORF = reader.ReadString();
            //(�擪)�ԑ�ԍ��i�����p�j
            temp.HADD_SEARCHFRAMENORF = reader.ReadInt32();
            //(�擪)�G���W���^������
            temp.HADD_ENGINEMODELNMRF = reader.ReadString();
            //(�擪)�֘A�^��
            temp.HADD_RELEVANCEMODELRF = reader.ReadString();
            //(�擪)�T�u�Ԗ��R�[�h
            temp.HADD_SUBCARNMCDRF = reader.ReadInt32();
            //(�擪)�^���O���[�h����
            temp.HADD_MODELGRADESNAMERF = reader.ReadString();
            //(�擪)�J���[�R�[�h
            temp.HADD_COLORCODERF = reader.ReadString();
            //(�擪)�J���[����1
            temp.HADD_COLORNAME1RF = reader.ReadString();
            //(�擪)�g�����R�[�h
            temp.HADD_TRIMCODERF = reader.ReadString();
            //(�擪)�g��������
            temp.HADD_TRIMNAMERF = reader.ReadString();
            //(�擪)�ԗ����s����
            temp.HADD_MILEAGERF = reader.ReadInt32();
            //�v�����^�Ǘ�No
            temp.HADD_PRINTERMNGNORF = reader.ReadInt32();
            //�`�[����ݒ�p���[ID
            temp.HADD_SLIPPRTSETPAPERIDRF = reader.ReadString();
            //���Д��l�P
            temp.HADD_NOTE1RF = reader.ReadString();
            //���Д��l�Q
            temp.HADD_NOTE2RF = reader.ReadString();
            //���Д��l�R
            temp.HADD_NOTE3RF = reader.ReadString();
            //�Ĕ��s�}�[�N
            temp.HADD_REISSUEMARKRF = reader.ReadString();
            //�Q�l����ň󎚖���
            temp.HADD_REFCONSTAXPRTNMRF = reader.ReadString();
            //������� ��
            temp.HADD_PRINTTIMEHOURRF = reader.ReadInt32();
            //������� ��
            temp.HADD_PRINTTIMEMINUTERF = reader.ReadInt32();
            //������� �b
            temp.HADD_PRINTTIMESECONDRF = reader.ReadInt32();
            //�`�[�������t����N
            temp.HADD_SEARCHSLIPDATEFYRF = reader.ReadInt32();
            //�`�[�������t����N��
            temp.HADD_SEARCHSLIPDATEFSRF = reader.ReadInt32();
            //�`�[�������t�a��N
            temp.HADD_SEARCHSLIPDATEFWRF = reader.ReadInt32();
            //�`�[�������t��
            temp.HADD_SEARCHSLIPDATEFMRF = reader.ReadInt32();
            //�`�[�������t��
            temp.HADD_SEARCHSLIPDATEFDRF = reader.ReadInt32();
            //�`�[�������t����
            temp.HADD_SEARCHSLIPDATEFGRF = reader.ReadString();
            //�`�[�������t����
            temp.HADD_SEARCHSLIPDATEFRRF = reader.ReadString();
            //�`�[�������t���e����(/)
            temp.HADD_SEARCHSLIPDATEFLSRF = reader.ReadString();
            //�`�[�������t���e����(.)
            temp.HADD_SEARCHSLIPDATEFLPRF = reader.ReadString();
            //�`�[�������t���e����(�N)
            temp.HADD_SEARCHSLIPDATEFLYRF = reader.ReadString();
            //�`�[�������t���e����(��)
            temp.HADD_SEARCHSLIPDATEFLMRF = reader.ReadString();
            //�`�[�������t���e����(��)
            temp.HADD_SEARCHSLIPDATEFLDRF = reader.ReadString();
            //�o�ד��t����N
            temp.HADD_SHIPMENTDAYFYRF = reader.ReadInt32();
            //�o�ד��t����N��
            temp.HADD_SHIPMENTDAYFSRF = reader.ReadInt32();
            //�o�ד��t�a��N
            temp.HADD_SHIPMENTDAYFWRF = reader.ReadInt32();
            //�o�ד��t��
            temp.HADD_SHIPMENTDAYFMRF = reader.ReadInt32();
            //�o�ד��t��
            temp.HADD_SHIPMENTDAYFDRF = reader.ReadInt32();
            //�o�ד��t����
            temp.HADD_SHIPMENTDAYFGRF = reader.ReadString();
            //�o�ד��t����
            temp.HADD_SHIPMENTDAYFRRF = reader.ReadString();
            //�o�ד��t���e����(/)
            temp.HADD_SHIPMENTDAYFLSRF = reader.ReadString();
            //�o�ד��t���e����(.)
            temp.HADD_SHIPMENTDAYFLPRF = reader.ReadString();
            //�o�ד��t���e����(�N)
            temp.HADD_SHIPMENTDAYFLYRF = reader.ReadString();
            //�o�ד��t���e����(��)
            temp.HADD_SHIPMENTDAYFLMRF = reader.ReadString();
            //�o�ד��t���e����(��)
            temp.HADD_SHIPMENTDAYFLDRF = reader.ReadString();
            //������t����N
            temp.HADD_SALESDATEFYRF = reader.ReadInt32();
            //������t����N��
            temp.HADD_SALESDATEFSRF = reader.ReadInt32();
            //������t�a��N
            temp.HADD_SALESDATEFWRF = reader.ReadInt32();
            //������t��
            temp.HADD_SALESDATEFMRF = reader.ReadInt32();
            //������t��
            temp.HADD_SALESDATEFDRF = reader.ReadInt32();
            //������t����
            temp.HADD_SALESDATEFGRF = reader.ReadString();
            //������t����
            temp.HADD_SALESDATEFRRF = reader.ReadString();
            //������t���e����(/)
            temp.HADD_SALESDATEFLSRF = reader.ReadString();
            //������t���e����(.)
            temp.HADD_SALESDATEFLPRF = reader.ReadString();
            //������t���e����(�N)
            temp.HADD_SALESDATEFLYRF = reader.ReadString();
            //������t���e����(��)
            temp.HADD_SALESDATEFLMRF = reader.ReadString();
            //������t���e����(��)
            temp.HADD_SALESDATEFLDRF = reader.ReadString();
            //�v����t����N
            temp.HADD_ADDUPADATEFYRF = reader.ReadInt32();
            //�v����t����N��
            temp.HADD_ADDUPADATEFSRF = reader.ReadInt32();
            //�v����t�a��N
            temp.HADD_ADDUPADATEFWRF = reader.ReadInt32();
            //�v����t��
            temp.HADD_ADDUPADATEFMRF = reader.ReadInt32();
            //�v����t��
            temp.HADD_ADDUPADATEFDRF = reader.ReadInt32();
            //�v����t����
            temp.HADD_ADDUPADATEFGRF = reader.ReadString();
            //�v����t����
            temp.HADD_ADDUPADATEFRRF = reader.ReadString();
            //�v����t���e����(/)
            temp.HADD_ADDUPADATEFLSRF = reader.ReadString();
            //�v����t���e����(.)
            temp.HADD_ADDUPADATEFLPRF = reader.ReadString();
            //�v����t���e����(�N)
            temp.HADD_ADDUPADATEFLYRF = reader.ReadString();
            //�v����t���e����(��)
            temp.HADD_ADDUPADATEFLMRF = reader.ReadString();
            //�v����t���e����(��)
            temp.HADD_ADDUPADATEFLDRF = reader.ReadString();
            //����`�[���s������N
            temp.HADD_SALESSLIPPRINTDATEFYRF = reader.ReadInt32();
            //����`�[���s������N��
            temp.HADD_SALESSLIPPRINTDATEFSRF = reader.ReadInt32();
            //����`�[���s���a��N
            temp.HADD_SALESSLIPPRINTDATEFWRF = reader.ReadInt32();
            //����`�[���s����
            temp.HADD_SALESSLIPPRINTDATEFMRF = reader.ReadInt32();
            //����`�[���s����
            temp.HADD_SALESSLIPPRINTDATEFDRF = reader.ReadInt32();
            //����`�[���s������
            temp.HADD_SALESSLIPPRINTDATEFGRF = reader.ReadString();
            //����`�[���s������
            temp.HADD_SALESSLIPPRINTDATEFRRF = reader.ReadString();
            //����`�[���s�����e����(/)
            temp.HADD_SALESSLIPPRINTDATEFLSRF = reader.ReadString();
            //����`�[���s�����e����(.)
            temp.HADD_SALESSLIPPRINTDATEFLPRF = reader.ReadString();
            //����`�[���s�����e����(�N)
            temp.HADD_SALESSLIPPRINTDATEFLYRF = reader.ReadString();
            //����`�[���s�����e����(��)
            temp.HADD_SALESSLIPPRINTDATEFLMRF = reader.ReadString();
            //����`�[���s�����e����(��)
            temp.HADD_SALESSLIPPRINTDATEFLDRF = reader.ReadString();
            //(�擪)���N�x����N
            temp.HADD_FIRSTENTRYDATEFYRF = reader.ReadInt32();
            //(�擪)���N�x����N��
            temp.HADD_FIRSTENTRYDATEFSRF = reader.ReadInt32();
            //(�擪)���N�x�a��N
            temp.HADD_FIRSTENTRYDATEFWRF = reader.ReadInt32();
            //(�擪)���N�x��
            temp.HADD_FIRSTENTRYDATEFMRF = reader.ReadInt32();
            //(�擪)���N�x��
            temp.HADD_FIRSTENTRYDATEFDRF = reader.ReadInt32();
            //(�擪)���N�x����
            temp.HADD_FIRSTENTRYDATEFGRF = reader.ReadString();
            //(�擪)���N�x����
            temp.HADD_FIRSTENTRYDATEFRRF = reader.ReadString();
            //(�擪)���N�x���e����(/)
            temp.HADD_FIRSTENTRYDATEFLSRF = reader.ReadString();
            //(�擪)���N�x���e����(.)
            temp.HADD_FIRSTENTRYDATEFLPRF = reader.ReadString();
            //(�擪)���N�x���e����(�N)
            temp.HADD_FIRSTENTRYDATEFLYRF = reader.ReadString();
            //(�擪)���N�x���e����(��)
            temp.HADD_FIRSTENTRYDATEFLMRF = reader.ReadString();
            //(�擪)���N�x���e����(��)
            temp.HADD_FIRSTENTRYDATEFLDRF = reader.ReadString();
            //����p���Ӑ於�́i��i�j
            temp.HADD_PRINTCUSTOMERNAME1RF = reader.ReadString();
            //����p���Ӑ於�́i���i�j
            temp.HADD_PRINTCUSTOMERNAME2RF = reader.ReadString();
            //����p���Ӑ於�́i���i�j�{�h��
            temp.HADD_PRINTCUSTOMERNAME2HNRF = reader.ReadString();
            //(�擪)���[�J�[���p����
            temp.HADD_MAKERHALFNAMERF = reader.ReadString();
            //(�擪)�Ԏ피�p����
            temp.HADD_MODELHALFNAMERF = reader.ReadString();
            //�`�[���l�R
            temp.SALESSLIPRF_SLIPNOTE3RF = reader.ReadString();
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
            //���ьv�㋒�_�R�[�h
            temp.SALESSLIPRF_RESULTSADDUPSECCDRF = reader.ReadString();
            //�X�V����
            temp.SALESSLIPRF_UPDATEDATETIMERF = reader.ReadInt64();

            // --- ADD 2009.07.24 ���m ------ >>>>>>
            //���Ӑ�R�[�h
            temp.SANDESETTINGRF_CUSTOMERCODE = reader.ReadInt32();
            //�[�i��X�܃R�[�h
            temp.SANDESETTINGRF_ADDRESSEESHOPCD = reader.ReadString();
            //�Z�d�Ǘ��R�[�h
            temp.SANDESETTINGRF_SANDEMNGCODE = reader.ReadString();
            //�o��敪
            temp.SANDESETTINGRF_EXPENSEDIVCD = reader.ReadInt32();
            //�����敪
            temp.SANDESETTINGRF_DIRECTSENDINGCD = reader.ReadInt32();
            //�󒍋敪
            temp.SANDESETTINGRF_ACPTANORDERDIV = reader.ReadInt32();
            //�[�i�҃R�[�h
            temp.SANDESETTINGRF_DELIVERERCD = reader.ReadString();
            //�[�i�Җ�
            temp.SANDESETTINGRF_DELIVERERNM = reader.ReadString();
            //�[�i�ҏZ��
            temp.SANDESETTINGRF_DELIVERERADDRESS = reader.ReadString();
            //�[�i�҂s�d�k
            temp.SANDESETTINGRF_DELIVERERPHONENUM = reader.ReadString();
            //���i����
            temp.SANDESETTINGRF_TRADCOMPNAME = reader.ReadString();
            //���i�����_��
            temp.SANDESETTINGRF_TRADCOMPSECTNAME = reader.ReadString();
            //���i���R�[�h�i�����j
            temp.SANDESETTINGRF_PURETRADCOMPCD = reader.ReadString();
            //���i���d�ؗ��i�����j
            temp.SANDESETTINGRF_PURETRADCOMPRATE = reader.ReadDouble();
            //���i���R�[�h�i�D�ǁj
            temp.SANDESETTINGRF_PRITRADCOMPCD = reader.ReadString();
            //���i���d�ؗ��i�D�ǁj
            temp.SANDESETTINGRF_PRITRADCOMPRATE = reader.ReadDouble();
            //AB���i�R�[�h
            temp.SANDESETTINGRF_ABGOODSCODE = reader.ReadString();
            //�R�����g�w��敪
            temp.SANDESETTINGRF_COMMENTRESERVEDDIV = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P
            temp.SANDESETTINGRF_GOODSMAKERCD1 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�Q
            temp.SANDESETTINGRF_GOODSMAKERCD2 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�R
            temp.SANDESETTINGRF_GOODSMAKERCD3 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�S
            temp.SANDESETTINGRF_GOODSMAKERCD4 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�T
            temp.SANDESETTINGRF_GOODSMAKERCD5 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�U
            temp.SANDESETTINGRF_GOODSMAKERCD6 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�V
            temp.SANDESETTINGRF_GOODSMAKERCD7 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�W
            temp.SANDESETTINGRF_GOODSMAKERCD8 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�X
            temp.SANDESETTINGRF_GOODSMAKERCD9 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�O
            temp.SANDESETTINGRF_GOODSMAKERCD10 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�P
            temp.SANDESETTINGRF_GOODSMAKERCD11 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�Q
            temp.SANDESETTINGRF_GOODSMAKERCD12 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�R
            temp.SANDESETTINGRF_GOODSMAKERCD13 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�S
            temp.SANDESETTINGRF_GOODSMAKERCD14 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�T
            temp.SANDESETTINGRF_GOODSMAKERCD15 = reader.ReadInt32();
            //���i�n�d�l�敪
            temp.SANDESETTINGRF_PARTSOEMDIV = reader.ReadInt32();
            // --- ADD 2009.07.24 ���m ------ <<<<<<
            // --- ADD  ���r��  2010/03/01 ---------->>>>>
            //����P���[�������R�[�h
            temp.CSTCST_SALESUNPRCFRCPROCCDRF = reader.ReadInt32();
            //������z�[�������R�[�h
            temp.CSTCST_SALESMONEYFRCPROCCDRF = reader.ReadInt32();
            //�������Œ[�������R�[�h
            temp.CSTCST_SALESCNSTAXFRCPROCCDRF = reader.ReadInt32();
            // --- ADD  ���r��  2010/03/01 ----------<<<<<
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            //QR�R�[�h���
            temp.CSTCST_QRCODEPRTCDRF = reader.ReadInt32();
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // 2010/07/06 Add >>>
            //����f�[�^�w�b�_�K�C�h
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.SALESSLIPRF_FILEHEADERGUID = new Guid(fileHeaderGuidArray);
            // 2010/07/06 Add <<<
            // ---- ADD caohh 2011/08/17 ------>>>>>
            //�X�֔ԍ�
            temp.CSTCST_POSTNORF = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.CSTCST_ADDRESS1RF = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.CSTCST_ADDRESS3RF = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.CSTCST_ADDRESS4RF = reader.ReadString();
            //�d�b�ԍ��i����j
            temp.CSTCST_HOMETELNORF = reader.ReadString();
            //�d�b�ԍ��i�Ζ���j
            temp.CSTCST_OFFICETELNORF = reader.ReadString();
            //�d�b�ԍ��i�g�сj
            temp.CSTCST_PORTABLETELNORF = reader.ReadString();
            //FAX�ԍ��i����j
            temp.CSTCST_HOMEFAXNORF = reader.ReadString();
            //FAX�ԍ��i�Ζ���j
            temp.CSTCST_OFFICEFAXNORF = reader.ReadString();
            //�d�b�ԍ��i���̑��j
            temp.CSTCST_OTHERSTELNORF = reader.ReadString();
            // ---- ADD caohh 2011/08/17 ------<<<<<

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
        /// <returns>FrePSalesSlipWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePSalesSlipWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePSalesSlipWork temp = GetFrePSalesSlipWork( reader, serInfo );
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
                    retValue = (FrePSalesSlipWork[])lst.ToArray( typeof( FrePSalesSlipWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
