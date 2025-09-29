using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePStockMoveSlipWork
    /// <summary>
    ///                      ���R���[�݌Ɉړ��`�[�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�݌Ɉړ��`�[�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/01/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePStockMoveSlipWork
    {
        /// <summary>�݌Ɉړ��`��</summary>
        /// <remarks>1:�݌Ɉړ��A2�F�q�Ɉړ�</remarks>
        private Int32 _mOVH_STOCKMOVEFORMALRF;

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _mOVH_STOCKMOVESLIPNORF;

        /// <summary>�ړ������_�R�[�h</summary>
        private string _mOVH_BFSECTIONCODERF = "";

        /// <summary>�ړ������_�K�C�h����</summary>
        private string _mOVH_BFSECTIONGUIDESNMRF = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _mOVH_BFENTERWAREHCODERF = "";

        /// <summary>�ړ����q�ɖ���</summary>
        private string _mOVH_BFENTERWAREHNAMERF = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _mOVH_AFSECTIONCODERF = "";

        /// <summary>�ړ��拒�_�K�C�h����</summary>
        private string _mOVH_AFSECTIONGUIDESNMRF = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _mOVH_AFENTERWAREHCODERF = "";

        /// <summary>�ړ���q�ɖ���</summary>
        private string _mOVH_AFENTERWAREHNAMERF = "";

        /// <summary>�o�ח\���</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private Int32 _mOVH_SHIPMENTSCDLDAYRF;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _mOVH_INPUTDAYRF;

        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h</summary>
        /// <remarks>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _mOVH_STOCKMVEMPCODERF = "";

        /// <summary>�݌Ɉړ����͏]�ƈ�����</summary>
        private string _mOVH_STOCKMVEMPNAMERF = "";

        /// <summary>�o�גS���]�ƈ��R�[�h</summary>
        /// <remarks>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _mOVH_SHIPAGENTCDRF = "";

        /// <summary>�o�גS���]�ƈ�����</summary>
        private string _mOVH_SHIPAGENTNMRF = "";

        /// <summary>����S���]�ƈ��R�[�h</summary>
        /// <remarks>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</remarks>
        private string _mOVH_RECEIVEAGENTCDRF = "";

        /// <summary>����S���]�ƈ�����</summary>
        private string _mOVH_RECEIVEAGENTNMRF = "";

        /// <summary>�`�[�E�v</summary>
        private string _mOVH_OUTLINERF = "";

        /// <summary>�q�ɔ��l1</summary>
        /// <remarks>�݌Ɉړ����̈ړ��`�[�ɏo�͂�����l���Z�b�g</remarks>
        private string _mOVH_WAREHOUSENOTE1RF = "";

        /// <summary>�`�[���s�ϋ敪</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private Int32 _mOVH_SLIPPRINTFINISHCDRF;

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sEC1_SECTIONGUIDENMRF = "";

        /// <summary>���Ж��̃R�[�h1</summary>
        private Int32 _sEC1_COMPANYNAMECD1RF;

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sEC2_SECTIONGUIDENMRF = "";

        /// <summary>���Ж��̃R�[�h1</summary>
        private Int32 _sEC2_COMPANYNAMECD1RF;

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

        /// <summary>����PR��</summary>
        private string _cMP1_COMPANYPRRF = "";

        /// <summary>���Ж���1</summary>
        private string _cMP1_COMPANYNAME1RF = "";

        /// <summary>���Ж���2</summary>
        private string _cMP1_COMPANYNAME2RF = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _cMP1_POSTNORF = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _cMP1_ADDRESS1RF = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _cMP1_ADDRESS3RF = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _cMP1_ADDRESS4RF = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP1_COMPANYTELNO1RF = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP1_COMPANYTELNO2RF = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP1_COMPANYTELNO3RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP1_COMPANYTELTITLE1RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP1_COMPANYTELTITLE2RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP1_COMPANYTELTITLE3RF = "";

        /// <summary>��s�U���ē���</summary>
        private string _cMP1_TRANSFERGUIDANCERF = "";

        /// <summary>��s����1</summary>
        private string _cMP1_ACCOUNTNOINFO1RF = "";

        /// <summary>��s����2</summary>
        private string _cMP1_ACCOUNTNOINFO2RF = "";

        /// <summary>��s����3</summary>
        private string _cMP1_ACCOUNTNOINFO3RF = "";

        /// <summary>���Аݒ�E�v1</summary>
        private string _cMP1_COMPANYSETNOTE1RF = "";

        /// <summary>���Аݒ�E�v2</summary>
        private string _cMP1_COMPANYSETNOTE2RF = "";

        /// <summary>�摜���敪</summary>
        /// <remarks>10:���Љ摜,20:POS�Ŏg�p����摜</remarks>
        private Int32 _cMP1_IMAGEINFODIVRF;

        /// <summary>�摜���R�[�h</summary>
        private Int32 _cMP1_IMAGEINFOCODERF;

        /// <summary>����URL</summary>
        private string _cMP1_COMPANYURLRF = "";

        /// <summary>����PR��2</summary>
        /// <remarks>��\����𓙂̏������</remarks>
        private string _cMP1_COMPANYPRSENTENCE2RF = "";

        /// <summary>�摜�󎚗p�R�����g1</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _cMP1_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>�摜�󎚗p�R�����g2</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _cMP1_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>����PR��</summary>
        private string _cMP2_COMPANYPRRF = "";

        /// <summary>���Ж���1</summary>
        private string _cMP2_COMPANYNAME1RF = "";

        /// <summary>���Ж���2</summary>
        private string _cMP2_COMPANYNAME2RF = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _cMP2_POSTNORF = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _cMP2_ADDRESS1RF = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _cMP2_ADDRESS3RF = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _cMP2_ADDRESS4RF = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP2_COMPANYTELNO1RF = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP2_COMPANYTELNO2RF = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP2_COMPANYTELNO3RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP2_COMPANYTELTITLE1RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP2_COMPANYTELTITLE2RF = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP2_COMPANYTELTITLE3RF = "";

        /// <summary>��s�U���ē���</summary>
        private string _cMP2_TRANSFERGUIDANCERF = "";

        /// <summary>��s����1</summary>
        private string _cMP2_ACCOUNTNOINFO1RF = "";

        /// <summary>��s����2</summary>
        private string _cMP2_ACCOUNTNOINFO2RF = "";

        /// <summary>��s����3</summary>
        private string _cMP2_ACCOUNTNOINFO3RF = "";

        /// <summary>���Аݒ�E�v1</summary>
        private string _cMP2_COMPANYSETNOTE1RF = "";

        /// <summary>���Аݒ�E�v2</summary>
        private string _cMP2_COMPANYSETNOTE2RF = "";

        /// <summary>����URL</summary>
        private string _cMP2_COMPANYURLRF = "";

        /// <summary>����PR��2</summary>
        /// <remarks>��\����𓙂̏������</remarks>
        private string _cMP2_COMPANYPRSENTENCE2RF = "";

        /// <summary>�摜�󎚗p�R�����g1</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _cMP2_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>�摜�󎚗p�R�����g2</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _cMP2_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>�J�i</summary>
        private string _eMP1_KANARF = "";

        /// <summary>�Z�k����</summary>
        private string _eMP1_SHORTNAMERF = "";

        /// <summary>�J�i</summary>
        private string _eMP2_KANARF = "";

        /// <summary>�Z�k����</summary>
        private string _eMP2_SHORTNAMERF = "";

        /// <summary>�J�i</summary>
        private string _eMP3_KANARF = "";

        /// <summary>�Z�k����</summary>
        private string _eMP3_SHORTNAMERF = "";

        /// <summary>�摜���f�[�^</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

        /// <summary>�݌Ɉړ��`������</summary>
        /// <remarks>1:�݌Ɉړ��A2�F�q�Ɉړ�</remarks>
        private string _hADD_STOCKMOVEFORMALNMRF = "";

        /// <summary>�o�ח\�������N</summary>
        private Int32 _hADD_SHIPMENTSCDLDFYRF;

        /// <summary>�o�ח\�������N��</summary>
        private Int32 _hADD_SHIPMENTSCDLDFSRF;

        /// <summary>�o�ח\����a��N</summary>
        private Int32 _hADD_SHIPMENTSCDLDFWRF;

        /// <summary>�o�ח\�����</summary>
        private Int32 _hADD_SHIPMENTSCDLDFMRF;

        /// <summary>�o�ח\�����</summary>
        private Int32 _hADD_SHIPMENTSCDLDFDRF;

        /// <summary>�o�ח\�������</summary>
        private string _hADD_SHIPMENTSCDLDFGRF = "";

        /// <summary>�o�ח\�������</summary>
        private string _hADD_SHIPMENTSCDLDFRRF = "";

        /// <summary>�o�ח\������e����(/)</summary>
        private string _hADD_SHIPMENTSCDLDFLSRF = "";

        /// <summary>�o�ח\������e����(.)</summary>
        private string _hADD_SHIPMENTSCDLDFLPRF = "";

        /// <summary>�o�ח\������e����(�N)</summary>
        private string _hADD_SHIPMENTSCDLDFLYRF = "";

        /// <summary>�o�ח\������e����(��)</summary>
        private string _hADD_SHIPMENTSCDLDFLMRF = "";

        /// <summary>�o�ח\������e����(��)</summary>
        private string _hADD_SHIPMENTSCDLDFLDRF = "";

        /// <summary>���͓�����N</summary>
        private Int32 _hADD_INPUTDFYRF;

        /// <summary>���͓�����N��</summary>
        private Int32 _hADD_INPUTDFSRF;

        /// <summary>���͓��a��N</summary>
        private Int32 _hADD_INPUTDFWRF;

        /// <summary>���͓���</summary>
        private Int32 _hADD_INPUTDFMRF;

        /// <summary>���͓���</summary>
        private Int32 _hADD_INPUTDFDRF;

        /// <summary>���͓�����</summary>
        private string _hADD_INPUTDFGRF = "";

        /// <summary>���͓�����</summary>
        private string _hADD_INPUTDFRRF = "";

        /// <summary>���͓����e����(/)</summary>
        private string _hADD_INPUTDFLSRF = "";

        /// <summary>���͓����e����(.)</summary>
        private string _hADD_INPUTDFLPRF = "";

        /// <summary>���͓����e����(�N)</summary>
        private string _hADD_INPUTDFLYRF = "";

        /// <summary>���͓����e����(��)</summary>
        private string _hADD_INPUTDFLMRF = "";

        /// <summary>���͓����e����(��)</summary>
        private string _hADD_INPUTDFLDRF = "";

        /// <summary>���Д��l�P</summary>
        private string _hADD_NOTE1RF = "";

        /// <summary>���Д��l�Q</summary>
        private string _hADD_NOTE2RF = "";

        /// <summary>���Д��l�R</summary>
        private string _hADD_NOTE3RF = "";

        /// <summary>�Ĕ��s�}�[�N</summary>
        private string _hADD_REISSUEMARKRF = "";

        /// <summary>�v�����^�Ǘ�No</summary>
        /// <remarks>�����̃��R�[�h�̓`�[���������v�����^�̌��茋��(default)</remarks>
        private Int32 _hADD_PRINTERMNGNORF;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�����̃��R�[�h�̓`�[���������`�[�^�C�v�̌��茋��(default)</remarks>
        private string _hADD_SLIPPRTSETPAPERIDRF = "";

        /// <summary>������� ��</summary>
        /// <remarks>HH</remarks>
        private Int32 _hADD_PRINTTIMEHOURRF;

        /// <summary>������� ��</summary>
        /// <remarks>MM</remarks>
        private Int32 _hADD_PRINTTIMEMINUTERF;

        /// <summary>������� �b</summary>
        /// <remarks>DD</remarks>
        private Int32 _hADD_PRINTTIMESECONDRF;

        /// <summary>�`�[���v���z</summary>
        /// <remarks>�y�d���P���~�ړ����z</remarks>
        private Int64 _hADD_TTLSTOCKMOVEPRICERF;

        /// <summary>�`�[���v���z(�W�����i)</summary>
        /// <remarks>�y�艿�~�ړ����z</remarks>
        private Int64 _hADD_TTLSTOCKMOVELISTPRICERF;

        /// <summary>���͋��_�R�[�h</summary>
        private string _mOVH_UPDATESECCDRF = "";

        /// <summary>���͋��_�K�C�h����</summary>
        private string _sEC0_SECTIONGUIDESNMRF = "";

        /// <summary>���͋��_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sEC0_SECTIONGUIDENMRF = "";


        /// public propaty name  :  MOVH_STOCKMOVEFORMALRF
        /// <summary>�݌Ɉړ��`���v���p�e�B</summary>
        /// <value>1:�݌Ɉړ��A2�F�q�Ɉړ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVH_STOCKMOVEFORMALRF
        {
            get { return _mOVH_STOCKMOVEFORMALRF; }
            set { _mOVH_STOCKMOVEFORMALRF = value; }
        }

        /// public propaty name  :  MOVH_STOCKMOVESLIPNORF
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVH_STOCKMOVESLIPNORF
        {
            get { return _mOVH_STOCKMOVESLIPNORF; }
            set { _mOVH_STOCKMOVESLIPNORF = value; }
        }

        /// public propaty name  :  MOVH_BFSECTIONCODERF
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_BFSECTIONCODERF
        {
            get { return _mOVH_BFSECTIONCODERF; }
            set { _mOVH_BFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVH_BFSECTIONGUIDESNMRF
        /// <summary>�ړ������_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_BFSECTIONGUIDESNMRF
        {
            get { return _mOVH_BFSECTIONGUIDESNMRF; }
            set { _mOVH_BFSECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  MOVH_BFENTERWAREHCODERF
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_BFENTERWAREHCODERF
        {
            get { return _mOVH_BFENTERWAREHCODERF; }
            set { _mOVH_BFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVH_BFENTERWAREHNAMERF
        /// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_BFENTERWAREHNAMERF
        {
            get { return _mOVH_BFENTERWAREHNAMERF; }
            set { _mOVH_BFENTERWAREHNAMERF = value; }
        }

        /// public propaty name  :  MOVH_AFSECTIONCODERF
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_AFSECTIONCODERF
        {
            get { return _mOVH_AFSECTIONCODERF; }
            set { _mOVH_AFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVH_AFSECTIONGUIDESNMRF
        /// <summary>�ړ��拒�_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_AFSECTIONGUIDESNMRF
        {
            get { return _mOVH_AFSECTIONGUIDESNMRF; }
            set { _mOVH_AFSECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  MOVH_AFENTERWAREHCODERF
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_AFENTERWAREHCODERF
        {
            get { return _mOVH_AFENTERWAREHCODERF; }
            set { _mOVH_AFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVH_AFENTERWAREHNAMERF
        /// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_AFENTERWAREHNAMERF
        {
            get { return _mOVH_AFENTERWAREHNAMERF; }
            set { _mOVH_AFENTERWAREHNAMERF = value; }
        }

        /// public propaty name  :  MOVH_SHIPMENTSCDLDAYRF
        /// <summary>�o�ח\����v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVH_SHIPMENTSCDLDAYRF
        {
            get { return _mOVH_SHIPMENTSCDLDAYRF; }
            set { _mOVH_SHIPMENTSCDLDAYRF = value; }
        }

        /// public propaty name  :  MOVH_INPUTDAYRF
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVH_INPUTDAYRF
        {
            get { return _mOVH_INPUTDAYRF; }
            set { _mOVH_INPUTDAYRF = value; }
        }

        /// public propaty name  :  MOVH_STOCKMVEMPCODERF
        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_STOCKMVEMPCODERF
        {
            get { return _mOVH_STOCKMVEMPCODERF; }
            set { _mOVH_STOCKMVEMPCODERF = value; }
        }

        /// public propaty name  :  MOVH_STOCKMVEMPNAMERF
        /// <summary>�݌Ɉړ����͏]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ����͏]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_STOCKMVEMPNAMERF
        {
            get { return _mOVH_STOCKMVEMPNAMERF; }
            set { _mOVH_STOCKMVEMPNAMERF = value; }
        }

        /// public propaty name  :  MOVH_SHIPAGENTCDRF
        /// <summary>�o�גS���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�גS���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_SHIPAGENTCDRF
        {
            get { return _mOVH_SHIPAGENTCDRF; }
            set { _mOVH_SHIPAGENTCDRF = value; }
        }

        /// public propaty name  :  MOVH_SHIPAGENTNMRF
        /// <summary>�o�גS���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�גS���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_SHIPAGENTNMRF
        {
            get { return _mOVH_SHIPAGENTNMRF; }
            set { _mOVH_SHIPAGENTNMRF = value; }
        }

        /// public propaty name  :  MOVH_RECEIVEAGENTCDRF
        /// <summary>����S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_RECEIVEAGENTCDRF
        {
            get { return _mOVH_RECEIVEAGENTCDRF; }
            set { _mOVH_RECEIVEAGENTCDRF = value; }
        }

        /// public propaty name  :  MOVH_RECEIVEAGENTNMRF
        /// <summary>����S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_RECEIVEAGENTNMRF
        {
            get { return _mOVH_RECEIVEAGENTNMRF; }
            set { _mOVH_RECEIVEAGENTNMRF = value; }
        }

        /// public propaty name  :  MOVH_OUTLINERF
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_OUTLINERF
        {
            get { return _mOVH_OUTLINERF; }
            set { _mOVH_OUTLINERF = value; }
        }

        /// public propaty name  :  MOVH_WAREHOUSENOTE1RF
        /// <summary>�q�ɔ��l1�v���p�e�B</summary>
        /// <value>�݌Ɉړ����̈ړ��`�[�ɏo�͂�����l���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_WAREHOUSENOTE1RF
        {
            get { return _mOVH_WAREHOUSENOTE1RF; }
            set { _mOVH_WAREHOUSENOTE1RF = value; }
        }

        /// public propaty name  :  MOVH_SLIPPRINTFINISHCDRF
        /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MOVH_SLIPPRINTFINISHCDRF
        {
            get { return _mOVH_SLIPPRINTFINISHCDRF; }
            set { _mOVH_SLIPPRINTFINISHCDRF = value; }
        }

        /// public propaty name  :  SEC1_SECTIONGUIDENMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SEC1_SECTIONGUIDENMRF
        {
            get { return _sEC1_SECTIONGUIDENMRF; }
            set { _sEC1_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SEC1_COMPANYNAMECD1RF
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SEC1_COMPANYNAMECD1RF
        {
            get { return _sEC1_COMPANYNAMECD1RF; }
            set { _sEC1_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  SEC2_SECTIONGUIDENMRF
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SEC2_SECTIONGUIDENMRF
        {
            get { return _sEC2_SECTIONGUIDENMRF; }
            set { _sEC2_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SEC2_COMPANYNAMECD1RF
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SEC2_COMPANYNAMECD1RF
        {
            get { return _sEC2_COMPANYNAMECD1RF; }
            set { _sEC2_COMPANYNAMECD1RF = value; }
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

        /// public propaty name  :  CMP1_COMPANYPRRF
        /// <summary>����PR���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYPRRF
        {
            get { return _cMP1_COMPANYPRRF; }
            set { _cMP1_COMPANYPRRF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYNAME1RF
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYNAME1RF
        {
            get { return _cMP1_COMPANYNAME1RF; }
            set { _cMP1_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYNAME2RF
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYNAME2RF
        {
            get { return _cMP1_COMPANYNAME2RF; }
            set { _cMP1_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  CMP1_POSTNORF
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_POSTNORF
        {
            get { return _cMP1_POSTNORF; }
            set { _cMP1_POSTNORF = value; }
        }

        /// public propaty name  :  CMP1_ADDRESS1RF
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_ADDRESS1RF
        {
            get { return _cMP1_ADDRESS1RF; }
            set { _cMP1_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CMP1_ADDRESS3RF
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_ADDRESS3RF
        {
            get { return _cMP1_ADDRESS3RF; }
            set { _cMP1_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CMP1_ADDRESS4RF
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_ADDRESS4RF
        {
            get { return _cMP1_ADDRESS4RF; }
            set { _cMP1_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELNO1RF
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYTELNO1RF
        {
            get { return _cMP1_COMPANYTELNO1RF; }
            set { _cMP1_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELNO2RF
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYTELNO2RF
        {
            get { return _cMP1_COMPANYTELNO2RF; }
            set { _cMP1_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELNO3RF
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYTELNO3RF
        {
            get { return _cMP1_COMPANYTELNO3RF; }
            set { _cMP1_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELTITLE1RF
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYTELTITLE1RF
        {
            get { return _cMP1_COMPANYTELTITLE1RF; }
            set { _cMP1_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELTITLE2RF
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYTELTITLE2RF
        {
            get { return _cMP1_COMPANYTELTITLE2RF; }
            set { _cMP1_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELTITLE3RF
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYTELTITLE3RF
        {
            get { return _cMP1_COMPANYTELTITLE3RF; }
            set { _cMP1_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  CMP1_TRANSFERGUIDANCERF
        /// <summary>��s�U���ē����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�U���ē����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_TRANSFERGUIDANCERF
        {
            get { return _cMP1_TRANSFERGUIDANCERF; }
            set { _cMP1_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  CMP1_ACCOUNTNOINFO1RF
        /// <summary>��s����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_ACCOUNTNOINFO1RF
        {
            get { return _cMP1_ACCOUNTNOINFO1RF; }
            set { _cMP1_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  CMP1_ACCOUNTNOINFO2RF
        /// <summary>��s����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_ACCOUNTNOINFO2RF
        {
            get { return _cMP1_ACCOUNTNOINFO2RF; }
            set { _cMP1_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  CMP1_ACCOUNTNOINFO3RF
        /// <summary>��s����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_ACCOUNTNOINFO3RF
        {
            get { return _cMP1_ACCOUNTNOINFO3RF; }
            set { _cMP1_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYSETNOTE1RF
        /// <summary>���Аݒ�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYSETNOTE1RF
        {
            get { return _cMP1_COMPANYSETNOTE1RF; }
            set { _cMP1_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYSETNOTE2RF
        /// <summary>���Аݒ�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYSETNOTE2RF
        {
            get { return _cMP1_COMPANYSETNOTE2RF; }
            set { _cMP1_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  CMP1_IMAGEINFODIVRF
        /// <summary>�摜���敪�v���p�e�B</summary>
        /// <value>10:���Љ摜,20:POS�Ŏg�p����摜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CMP1_IMAGEINFODIVRF
        {
            get { return _cMP1_IMAGEINFODIVRF; }
            set { _cMP1_IMAGEINFODIVRF = value; }
        }

        /// public propaty name  :  CMP1_IMAGEINFOCODERF
        /// <summary>�摜���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CMP1_IMAGEINFOCODERF
        {
            get { return _cMP1_IMAGEINFOCODERF; }
            set { _cMP1_IMAGEINFOCODERF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYURLRF
        /// <summary>����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYURLRF
        {
            get { return _cMP1_COMPANYURLRF; }
            set { _cMP1_COMPANYURLRF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYPRSENTENCE2RF
        /// <summary>����PR��2�v���p�e�B</summary>
        /// <value>��\����𓙂̏������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_COMPANYPRSENTENCE2RF
        {
            get { return _cMP1_COMPANYPRSENTENCE2RF; }
            set { _cMP1_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  CMP1_IMAGECOMMENTFORPRT1RF
        /// <summary>�摜�󎚗p�R�����g1�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_IMAGECOMMENTFORPRT1RF
        {
            get { return _cMP1_IMAGECOMMENTFORPRT1RF; }
            set { _cMP1_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  CMP1_IMAGECOMMENTFORPRT2RF
        /// <summary>�摜�󎚗p�R�����g2�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP1_IMAGECOMMENTFORPRT2RF
        {
            get { return _cMP1_IMAGECOMMENTFORPRT2RF; }
            set { _cMP1_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYPRRF
        /// <summary>����PR���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYPRRF
        {
            get { return _cMP2_COMPANYPRRF; }
            set { _cMP2_COMPANYPRRF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYNAME1RF
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYNAME1RF
        {
            get { return _cMP2_COMPANYNAME1RF; }
            set { _cMP2_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYNAME2RF
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYNAME2RF
        {
            get { return _cMP2_COMPANYNAME2RF; }
            set { _cMP2_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  CMP2_POSTNORF
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_POSTNORF
        {
            get { return _cMP2_POSTNORF; }
            set { _cMP2_POSTNORF = value; }
        }

        /// public propaty name  :  CMP2_ADDRESS1RF
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_ADDRESS1RF
        {
            get { return _cMP2_ADDRESS1RF; }
            set { _cMP2_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CMP2_ADDRESS3RF
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_ADDRESS3RF
        {
            get { return _cMP2_ADDRESS3RF; }
            set { _cMP2_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CMP2_ADDRESS4RF
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_ADDRESS4RF
        {
            get { return _cMP2_ADDRESS4RF; }
            set { _cMP2_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELNO1RF
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYTELNO1RF
        {
            get { return _cMP2_COMPANYTELNO1RF; }
            set { _cMP2_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELNO2RF
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYTELNO2RF
        {
            get { return _cMP2_COMPANYTELNO2RF; }
            set { _cMP2_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELNO3RF
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYTELNO3RF
        {
            get { return _cMP2_COMPANYTELNO3RF; }
            set { _cMP2_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELTITLE1RF
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYTELTITLE1RF
        {
            get { return _cMP2_COMPANYTELTITLE1RF; }
            set { _cMP2_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELTITLE2RF
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYTELTITLE2RF
        {
            get { return _cMP2_COMPANYTELTITLE2RF; }
            set { _cMP2_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELTITLE3RF
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYTELTITLE3RF
        {
            get { return _cMP2_COMPANYTELTITLE3RF; }
            set { _cMP2_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  CMP2_TRANSFERGUIDANCERF
        /// <summary>��s�U���ē����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�U���ē����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_TRANSFERGUIDANCERF
        {
            get { return _cMP2_TRANSFERGUIDANCERF; }
            set { _cMP2_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  CMP2_ACCOUNTNOINFO1RF
        /// <summary>��s����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_ACCOUNTNOINFO1RF
        {
            get { return _cMP2_ACCOUNTNOINFO1RF; }
            set { _cMP2_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  CMP2_ACCOUNTNOINFO2RF
        /// <summary>��s����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_ACCOUNTNOINFO2RF
        {
            get { return _cMP2_ACCOUNTNOINFO2RF; }
            set { _cMP2_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  CMP2_ACCOUNTNOINFO3RF
        /// <summary>��s����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_ACCOUNTNOINFO3RF
        {
            get { return _cMP2_ACCOUNTNOINFO3RF; }
            set { _cMP2_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYSETNOTE1RF
        /// <summary>���Аݒ�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYSETNOTE1RF
        {
            get { return _cMP2_COMPANYSETNOTE1RF; }
            set { _cMP2_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYSETNOTE2RF
        /// <summary>���Аݒ�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYSETNOTE2RF
        {
            get { return _cMP2_COMPANYSETNOTE2RF; }
            set { _cMP2_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYURLRF
        /// <summary>����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYURLRF
        {
            get { return _cMP2_COMPANYURLRF; }
            set { _cMP2_COMPANYURLRF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYPRSENTENCE2RF
        /// <summary>����PR��2�v���p�e�B</summary>
        /// <value>��\����𓙂̏������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_COMPANYPRSENTENCE2RF
        {
            get { return _cMP2_COMPANYPRSENTENCE2RF; }
            set { _cMP2_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  CMP2_IMAGECOMMENTFORPRT1RF
        /// <summary>�摜�󎚗p�R�����g1�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_IMAGECOMMENTFORPRT1RF
        {
            get { return _cMP2_IMAGECOMMENTFORPRT1RF; }
            set { _cMP2_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  CMP2_IMAGECOMMENTFORPRT2RF
        /// <summary>�摜�󎚗p�R�����g2�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CMP2_IMAGECOMMENTFORPRT2RF
        {
            get { return _cMP2_IMAGECOMMENTFORPRT2RF; }
            set { _cMP2_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  EMP1_KANARF
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMP1_KANARF
        {
            get { return _eMP1_KANARF; }
            set { _eMP1_KANARF = value; }
        }

        /// public propaty name  :  EMP1_SHORTNAMERF
        /// <summary>�Z�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMP1_SHORTNAMERF
        {
            get { return _eMP1_SHORTNAMERF; }
            set { _eMP1_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMP2_KANARF
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMP2_KANARF
        {
            get { return _eMP2_KANARF; }
            set { _eMP2_KANARF = value; }
        }

        /// public propaty name  :  EMP2_SHORTNAMERF
        /// <summary>�Z�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMP2_SHORTNAMERF
        {
            get { return _eMP2_SHORTNAMERF; }
            set { _eMP2_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMP3_KANARF
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMP3_KANARF
        {
            get { return _eMP3_KANARF; }
            set { _eMP3_KANARF = value; }
        }

        /// public propaty name  :  EMP3_SHORTNAMERF
        /// <summary>�Z�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EMP3_SHORTNAMERF
        {
            get { return _eMP3_SHORTNAMERF; }
            set { _eMP3_SHORTNAMERF = value; }
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

        /// public propaty name  :  HADD_STOCKMOVEFORMALNMRF
        /// <summary>�݌Ɉړ��`�����̃v���p�e�B</summary>
        /// <value>1:�݌Ɉړ��A2�F�q�Ɉړ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_STOCKMOVEFORMALNMRF
        {
            get { return _hADD_STOCKMOVEFORMALNMRF; }
            set { _hADD_STOCKMOVEFORMALNMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFYRF
        /// <summary>�o�ח\�������N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFYRF
        {
            get { return _hADD_SHIPMENTSCDLDFYRF; }
            set { _hADD_SHIPMENTSCDLDFYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFSRF
        /// <summary>�o�ח\�������N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\�������N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFSRF
        {
            get { return _hADD_SHIPMENTSCDLDFSRF; }
            set { _hADD_SHIPMENTSCDLDFSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFWRF
        /// <summary>�o�ח\����a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\����a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFWRF
        {
            get { return _hADD_SHIPMENTSCDLDFWRF; }
            set { _hADD_SHIPMENTSCDLDFWRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFMRF
        /// <summary>�o�ח\������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFMRF
        {
            get { return _hADD_SHIPMENTSCDLDFMRF; }
            set { _hADD_SHIPMENTSCDLDFMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFDRF
        /// <summary>�o�ח\������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFDRF
        {
            get { return _hADD_SHIPMENTSCDLDFDRF; }
            set { _hADD_SHIPMENTSCDLDFDRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFGRF
        /// <summary>�o�ח\��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFGRF
        {
            get { return _hADD_SHIPMENTSCDLDFGRF; }
            set { _hADD_SHIPMENTSCDLDFGRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFRRF
        /// <summary>�o�ח\��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFRRF
        {
            get { return _hADD_SHIPMENTSCDLDFRRF; }
            set { _hADD_SHIPMENTSCDLDFRRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLSRF
        /// <summary>�o�ח\������e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLSRF
        {
            get { return _hADD_SHIPMENTSCDLDFLSRF; }
            set { _hADD_SHIPMENTSCDLDFLSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLPRF
        /// <summary>�o�ח\������e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLPRF
        {
            get { return _hADD_SHIPMENTSCDLDFLPRF; }
            set { _hADD_SHIPMENTSCDLDFLPRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLYRF
        /// <summary>�o�ח\������e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLYRF
        {
            get { return _hADD_SHIPMENTSCDLDFLYRF; }
            set { _hADD_SHIPMENTSCDLDFLYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLMRF
        /// <summary>�o�ח\������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLMRF
        {
            get { return _hADD_SHIPMENTSCDLDFLMRF; }
            set { _hADD_SHIPMENTSCDLDFLMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLDRF
        /// <summary>�o�ח\������e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\������e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLDRF
        {
            get { return _hADD_SHIPMENTSCDLDFLDRF; }
            set { _hADD_SHIPMENTSCDLDFLDRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFYRF
        /// <summary>���͓�����N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�����N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_INPUTDFYRF
        {
            get { return _hADD_INPUTDFYRF; }
            set { _hADD_INPUTDFYRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFSRF
        /// <summary>���͓�����N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�����N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_INPUTDFSRF
        {
            get { return _hADD_INPUTDFSRF; }
            set { _hADD_INPUTDFSRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFWRF
        /// <summary>���͓��a��N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��a��N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_INPUTDFWRF
        {
            get { return _hADD_INPUTDFWRF; }
            set { _hADD_INPUTDFWRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFMRF
        /// <summary>���͓����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_INPUTDFMRF
        {
            get { return _hADD_INPUTDFMRF; }
            set { _hADD_INPUTDFMRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFDRF
        /// <summary>���͓����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HADD_INPUTDFDRF
        {
            get { return _hADD_INPUTDFDRF; }
            set { _hADD_INPUTDFDRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFGRF
        /// <summary>���͓������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFGRF
        {
            get { return _hADD_INPUTDFGRF; }
            set { _hADD_INPUTDFGRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFRRF
        /// <summary>���͓������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFRRF
        {
            get { return _hADD_INPUTDFRRF; }
            set { _hADD_INPUTDFRRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLSRF
        /// <summary>���͓����e����(/)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����e����(/)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFLSRF
        {
            get { return _hADD_INPUTDFLSRF; }
            set { _hADD_INPUTDFLSRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLPRF
        /// <summary>���͓����e����(.)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����e����(.)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFLPRF
        {
            get { return _hADD_INPUTDFLPRF; }
            set { _hADD_INPUTDFLPRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLYRF
        /// <summary>���͓����e����(�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����e����(�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFLYRF
        {
            get { return _hADD_INPUTDFLYRF; }
            set { _hADD_INPUTDFLYRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLMRF
        /// <summary>���͓����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFLMRF
        {
            get { return _hADD_INPUTDFLMRF; }
            set { _hADD_INPUTDFLMRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLDRF
        /// <summary>���͓����e����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓����e����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HADD_INPUTDFLDRF
        {
            get { return _hADD_INPUTDFLDRF; }
            set { _hADD_INPUTDFLDRF = value; }
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

        /// public propaty name  :  HADD_TTLSTOCKMOVEPRICERF
        /// <summary>�`�[���v���z�v���p�e�B</summary>
        /// <value>�y�d���P���~�ړ����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���v���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_TTLSTOCKMOVEPRICERF
        {
            get { return _hADD_TTLSTOCKMOVEPRICERF; }
            set { _hADD_TTLSTOCKMOVEPRICERF = value; }
        }

        /// public propaty name  :  HADD_TTLSTOCKMOVELISTPRICERF
        /// <summary>�`�[���v���z(�W�����i)�v���p�e�B</summary>
        /// <value>�y�艿�~�ړ����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���v���z(�W�����i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 HADD_TTLSTOCKMOVELISTPRICERF
        {
            get { return _hADD_TTLSTOCKMOVELISTPRICERF; }
            set { _hADD_TTLSTOCKMOVELISTPRICERF = value; }
        }

        /// public propaty name  :  MOVH_UPDATESECCDRF
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MOVH_UPDATESECCDRF
        {
            get { return _mOVH_UPDATESECCDRF; }
            set { _mOVH_UPDATESECCDRF = value; }
        }

        /// public propaty name  :  SEC0_SECTIONGUIDESNMRF
        /// <summary>���͋��_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SEC0_SECTIONGUIDESNMRF
        {
            get { return _sEC0_SECTIONGUIDESNMRF; }
            set { _sEC0_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SEC0_SECTIONGUIDENMRF
        /// <summary>���͋��_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SEC0_SECTIONGUIDENMRF
        {
            get { return _sEC0_SECTIONGUIDENMRF; }
            set { _sEC0_SECTIONGUIDENMRF = value; }
        }


        /// <summary>
        /// ���R���[�݌Ɉړ��`�[�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FrePStockMoveSlipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveSlipWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePStockMoveSlipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FrePStockMoveSlipWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveSlipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FrePStockMoveSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveSlipWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePStockMoveSlipWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePStockMoveSlipWork || graph is ArrayList || graph is FrePStockMoveSlipWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( FrePStockMoveSlipWork ).FullName ) );

            if ( graph != null && graph is FrePStockMoveSlipWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePStockMoveSlipWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePStockMoveSlipWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePStockMoveSlipWork[])graph).Length;
            }
            else if ( graph is FrePStockMoveSlipWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�݌Ɉړ��`��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_STOCKMOVEFORMALRF
            //�݌Ɉړ��`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_STOCKMOVESLIPNORF
            //�ړ������_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFSECTIONCODERF
            //�ړ������_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFSECTIONGUIDESNMRF
            //�ړ����q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFENTERWAREHCODERF
            //�ړ����q�ɖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFENTERWAREHNAMERF
            //�ړ��拒�_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFSECTIONCODERF
            //�ړ��拒�_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFSECTIONGUIDESNMRF
            //�ړ���q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFENTERWAREHCODERF
            //�ړ���q�ɖ���
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFENTERWAREHNAMERF
            //�o�ח\���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_SHIPMENTSCDLDAYRF
            //���͓�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_INPUTDAYRF
            //�݌Ɉړ����͏]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_STOCKMVEMPCODERF
            //�݌Ɉړ����͏]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_STOCKMVEMPNAMERF
            //�o�גS���]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_SHIPAGENTCDRF
            //�o�גS���]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_SHIPAGENTNMRF
            //����S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_RECEIVEAGENTCDRF
            //����S���]�ƈ�����
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_RECEIVEAGENTNMRF
            //�`�[�E�v
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_OUTLINERF
            //�q�ɔ��l1
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_WAREHOUSENOTE1RF
            //�`�[���s�ϋ敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_SLIPPRINTFINISHCDRF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC1_SECTIONGUIDENMRF
            //���Ж��̃R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SEC1_COMPANYNAMECD1RF
            //���_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC2_SECTIONGUIDENMRF
            //���Ж��̃R�[�h1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SEC2_COMPANYNAMECD1RF
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
            //����PR��
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYPRRF
            //���Ж���1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYNAME1RF
            //���Ж���2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYNAME2RF
            //�X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_POSTNORF
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ADDRESS1RF
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ADDRESS3RF
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ADDRESS4RF
            //���Гd�b�ԍ�1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELNO1RF
            //���Гd�b�ԍ�2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELNO2RF
            //���Гd�b�ԍ�3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELNO3RF
            //���Гd�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELTITLE1RF
            //���Гd�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELTITLE2RF
            //���Гd�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELTITLE3RF
            //��s�U���ē���
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_TRANSFERGUIDANCERF
            //��s����1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ACCOUNTNOINFO1RF
            //��s����2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ACCOUNTNOINFO2RF
            //��s����3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ACCOUNTNOINFO3RF
            //���Аݒ�E�v1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYSETNOTE1RF
            //���Аݒ�E�v2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYSETNOTE2RF
            //�摜���敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CMP1_IMAGEINFODIVRF
            //�摜���R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CMP1_IMAGEINFOCODERF
            //����URL
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYURLRF
            //����PR��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYPRSENTENCE2RF
            //�摜�󎚗p�R�����g1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_IMAGECOMMENTFORPRT1RF
            //�摜�󎚗p�R�����g2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_IMAGECOMMENTFORPRT2RF
            //����PR��
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYPRRF
            //���Ж���1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYNAME1RF
            //���Ж���2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYNAME2RF
            //�X�֔ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_POSTNORF
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ADDRESS1RF
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ADDRESS3RF
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ADDRESS4RF
            //���Гd�b�ԍ�1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELNO1RF
            //���Гd�b�ԍ�2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELNO2RF
            //���Гd�b�ԍ�3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELNO3RF
            //���Гd�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELTITLE1RF
            //���Гd�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELTITLE2RF
            //���Гd�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELTITLE3RF
            //��s�U���ē���
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_TRANSFERGUIDANCERF
            //��s����1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ACCOUNTNOINFO1RF
            //��s����2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ACCOUNTNOINFO2RF
            //��s����3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ACCOUNTNOINFO3RF
            //���Аݒ�E�v1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYSETNOTE1RF
            //���Аݒ�E�v2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYSETNOTE2RF
            //����URL
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYURLRF
            //����PR��2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYPRSENTENCE2RF
            //�摜�󎚗p�R�����g1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_IMAGECOMMENTFORPRT1RF
            //�摜�󎚗p�R�����g2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_IMAGECOMMENTFORPRT2RF
            //�J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP1_KANARF
            //�Z�k����
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP1_SHORTNAMERF
            //�J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP2_KANARF
            //�Z�k����
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP2_SHORTNAMERF
            //�J�i
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP3_KANARF
            //�Z�k����
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP3_SHORTNAMERF
            //�摜���f�[�^
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //IMAGEINFORF_IMAGEINFODATARF
            //�݌Ɉړ��`������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STOCKMOVEFORMALNMRF
            //�o�ח\�������N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFYRF
            //�o�ח\�������N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFSRF
            //�o�ח\����a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFWRF
            //�o�ח\�����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFMRF
            //�o�ח\�����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFDRF
            //�o�ח\�������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFGRF
            //�o�ח\�������
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFRRF
            //�o�ח\������e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLSRF
            //�o�ח\������e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLPRF
            //�o�ח\������e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLYRF
            //�o�ח\������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLMRF
            //�o�ח\������e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLDRF
            //���͓�����N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFYRF
            //���͓�����N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFSRF
            //���͓��a��N
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFWRF
            //���͓���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFMRF
            //���͓���
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFDRF
            //���͓�����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFGRF
            //���͓�����
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFRRF
            //���͓����e����(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLSRF
            //���͓����e����(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLPRF
            //���͓����e����(�N)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLYRF
            //���͓����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLMRF
            //���͓����e����(��)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLDRF
            //���Д��l�P
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE1RF
            //���Д��l�Q
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE2RF
            //���Д��l�R
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE3RF
            //�Ĕ��s�}�[�N
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_REISSUEMARKRF
            //�v�����^�Ǘ�No
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTERMNGNORF
            //�`�[����ݒ�p���[ID
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SLIPPRTSETPAPERIDRF
            //������� ��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEHOURRF
            //������� ��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEMINUTERF
            //������� �b
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMESECONDRF
            //�`�[���v���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_TTLSTOCKMOVEPRICERF
            //�`�[���v���z(�W�����i)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_TTLSTOCKMOVELISTPRICERF
            //���͋��_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_UPDATESECCDRF
            //���͋��_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC0_SECTIONGUIDESNMRF
            //���͋��_�K�C�h����
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC0_SECTIONGUIDENMRF


            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePStockMoveSlipWork )
            {
                FrePStockMoveSlipWork temp = (FrePStockMoveSlipWork)graph;

                SetFrePStockMoveSlipWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePStockMoveSlipWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePStockMoveSlipWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePStockMoveSlipWork temp in lst )
                {
                    SetFrePStockMoveSlipWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePStockMoveSlipWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 131;

        /// <summary>
        ///  FrePStockMoveSlipWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveSlipWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFrePStockMoveSlipWork( System.IO.BinaryWriter writer, FrePStockMoveSlipWork temp )
        {
            //�݌Ɉړ��`��
            writer.Write( temp.MOVH_STOCKMOVEFORMALRF );
            //�݌Ɉړ��`�[�ԍ�
            writer.Write( temp.MOVH_STOCKMOVESLIPNORF );
            //�ړ������_�R�[�h
            writer.Write( temp.MOVH_BFSECTIONCODERF );
            //�ړ������_�K�C�h����
            writer.Write( temp.MOVH_BFSECTIONGUIDESNMRF );
            //�ړ����q�ɃR�[�h
            writer.Write( temp.MOVH_BFENTERWAREHCODERF );
            //�ړ����q�ɖ���
            writer.Write( temp.MOVH_BFENTERWAREHNAMERF );
            //�ړ��拒�_�R�[�h
            writer.Write( temp.MOVH_AFSECTIONCODERF );
            //�ړ��拒�_�K�C�h����
            writer.Write( temp.MOVH_AFSECTIONGUIDESNMRF );
            //�ړ���q�ɃR�[�h
            writer.Write( temp.MOVH_AFENTERWAREHCODERF );
            //�ړ���q�ɖ���
            writer.Write( temp.MOVH_AFENTERWAREHNAMERF );
            //�o�ח\���
            writer.Write( temp.MOVH_SHIPMENTSCDLDAYRF );
            //���͓�
            writer.Write( temp.MOVH_INPUTDAYRF );
            //�݌Ɉړ����͏]�ƈ��R�[�h
            writer.Write( temp.MOVH_STOCKMVEMPCODERF );
            //�݌Ɉړ����͏]�ƈ�����
            writer.Write( temp.MOVH_STOCKMVEMPNAMERF );
            //�o�גS���]�ƈ��R�[�h
            writer.Write( temp.MOVH_SHIPAGENTCDRF );
            //�o�גS���]�ƈ�����
            writer.Write( temp.MOVH_SHIPAGENTNMRF );
            //����S���]�ƈ��R�[�h
            writer.Write( temp.MOVH_RECEIVEAGENTCDRF );
            //����S���]�ƈ�����
            writer.Write( temp.MOVH_RECEIVEAGENTNMRF );
            //�`�[�E�v
            writer.Write( temp.MOVH_OUTLINERF );
            //�q�ɔ��l1
            writer.Write( temp.MOVH_WAREHOUSENOTE1RF );
            //�`�[���s�ϋ敪
            writer.Write( temp.MOVH_SLIPPRINTFINISHCDRF );
            //���_�K�C�h����
            writer.Write( temp.SEC1_SECTIONGUIDENMRF );
            //���Ж��̃R�[�h1
            writer.Write( temp.SEC1_COMPANYNAMECD1RF );
            //���_�K�C�h����
            writer.Write( temp.SEC2_SECTIONGUIDENMRF );
            //���Ж��̃R�[�h1
            writer.Write( temp.SEC2_COMPANYNAMECD1RF );
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
            //����PR��
            writer.Write( temp.CMP1_COMPANYPRRF );
            //���Ж���1
            writer.Write( temp.CMP1_COMPANYNAME1RF );
            //���Ж���2
            writer.Write( temp.CMP1_COMPANYNAME2RF );
            //�X�֔ԍ�
            writer.Write( temp.CMP1_POSTNORF );
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.CMP1_ADDRESS1RF );
            //�Z��3�i�Ԓn�j
            writer.Write( temp.CMP1_ADDRESS3RF );
            //�Z��4�i�A�p�[�g���́j
            writer.Write( temp.CMP1_ADDRESS4RF );
            //���Гd�b�ԍ�1
            writer.Write( temp.CMP1_COMPANYTELNO1RF );
            //���Гd�b�ԍ�2
            writer.Write( temp.CMP1_COMPANYTELNO2RF );
            //���Гd�b�ԍ�3
            writer.Write( temp.CMP1_COMPANYTELNO3RF );
            //���Гd�b�ԍ��^�C�g��1
            writer.Write( temp.CMP1_COMPANYTELTITLE1RF );
            //���Гd�b�ԍ��^�C�g��2
            writer.Write( temp.CMP1_COMPANYTELTITLE2RF );
            //���Гd�b�ԍ��^�C�g��3
            writer.Write( temp.CMP1_COMPANYTELTITLE3RF );
            //��s�U���ē���
            writer.Write( temp.CMP1_TRANSFERGUIDANCERF );
            //��s����1
            writer.Write( temp.CMP1_ACCOUNTNOINFO1RF );
            //��s����2
            writer.Write( temp.CMP1_ACCOUNTNOINFO2RF );
            //��s����3
            writer.Write( temp.CMP1_ACCOUNTNOINFO3RF );
            //���Аݒ�E�v1
            writer.Write( temp.CMP1_COMPANYSETNOTE1RF );
            //���Аݒ�E�v2
            writer.Write( temp.CMP1_COMPANYSETNOTE2RF );
            //�摜���敪
            writer.Write( temp.CMP1_IMAGEINFODIVRF );
            //�摜���R�[�h
            writer.Write( temp.CMP1_IMAGEINFOCODERF );
            //����URL
            writer.Write( temp.CMP1_COMPANYURLRF );
            //����PR��2
            writer.Write( temp.CMP1_COMPANYPRSENTENCE2RF );
            //�摜�󎚗p�R�����g1
            writer.Write( temp.CMP1_IMAGECOMMENTFORPRT1RF );
            //�摜�󎚗p�R�����g2
            writer.Write( temp.CMP1_IMAGECOMMENTFORPRT2RF );
            //����PR��
            writer.Write( temp.CMP2_COMPANYPRRF );
            //���Ж���1
            writer.Write( temp.CMP2_COMPANYNAME1RF );
            //���Ж���2
            writer.Write( temp.CMP2_COMPANYNAME2RF );
            //�X�֔ԍ�
            writer.Write( temp.CMP2_POSTNORF );
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write( temp.CMP2_ADDRESS1RF );
            //�Z��3�i�Ԓn�j
            writer.Write( temp.CMP2_ADDRESS3RF );
            //�Z��4�i�A�p�[�g���́j
            writer.Write( temp.CMP2_ADDRESS4RF );
            //���Гd�b�ԍ�1
            writer.Write( temp.CMP2_COMPANYTELNO1RF );
            //���Гd�b�ԍ�2
            writer.Write( temp.CMP2_COMPANYTELNO2RF );
            //���Гd�b�ԍ�3
            writer.Write( temp.CMP2_COMPANYTELNO3RF );
            //���Гd�b�ԍ��^�C�g��1
            writer.Write( temp.CMP2_COMPANYTELTITLE1RF );
            //���Гd�b�ԍ��^�C�g��2
            writer.Write( temp.CMP2_COMPANYTELTITLE2RF );
            //���Гd�b�ԍ��^�C�g��3
            writer.Write( temp.CMP2_COMPANYTELTITLE3RF );
            //��s�U���ē���
            writer.Write( temp.CMP2_TRANSFERGUIDANCERF );
            //��s����1
            writer.Write( temp.CMP2_ACCOUNTNOINFO1RF );
            //��s����2
            writer.Write( temp.CMP2_ACCOUNTNOINFO2RF );
            //��s����3
            writer.Write( temp.CMP2_ACCOUNTNOINFO3RF );
            //���Аݒ�E�v1
            writer.Write( temp.CMP2_COMPANYSETNOTE1RF );
            //���Аݒ�E�v2
            writer.Write( temp.CMP2_COMPANYSETNOTE2RF );
            //����URL
            writer.Write( temp.CMP2_COMPANYURLRF );
            //����PR��2
            writer.Write( temp.CMP2_COMPANYPRSENTENCE2RF );
            //�摜�󎚗p�R�����g1
            writer.Write( temp.CMP2_IMAGECOMMENTFORPRT1RF );
            //�摜�󎚗p�R�����g2
            writer.Write( temp.CMP2_IMAGECOMMENTFORPRT2RF );
            //�J�i
            writer.Write( temp.EMP1_KANARF );
            //�Z�k����
            writer.Write( temp.EMP1_SHORTNAMERF );
            //�J�i
            writer.Write( temp.EMP2_KANARF );
            //�Z�k����
            writer.Write( temp.EMP2_SHORTNAMERF );
            //�J�i
            writer.Write( temp.EMP3_KANARF );
            //�Z�k����
            writer.Write( temp.EMP3_SHORTNAMERF );
            //�摜���f�[�^
            writer.Write( temp.IMAGEINFORF_IMAGEINFODATARF );
            //�݌Ɉړ��`������
            writer.Write( temp.HADD_STOCKMOVEFORMALNMRF );
            //�o�ח\�������N
            writer.Write( temp.HADD_SHIPMENTSCDLDFYRF );
            //�o�ח\�������N��
            writer.Write( temp.HADD_SHIPMENTSCDLDFSRF );
            //�o�ח\����a��N
            writer.Write( temp.HADD_SHIPMENTSCDLDFWRF );
            //�o�ח\�����
            writer.Write( temp.HADD_SHIPMENTSCDLDFMRF );
            //�o�ח\�����
            writer.Write( temp.HADD_SHIPMENTSCDLDFDRF );
            //�o�ח\�������
            writer.Write( temp.HADD_SHIPMENTSCDLDFGRF );
            //�o�ח\�������
            writer.Write( temp.HADD_SHIPMENTSCDLDFRRF );
            //�o�ח\������e����(/)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLSRF );
            //�o�ח\������e����(.)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLPRF );
            //�o�ח\������e����(�N)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLYRF );
            //�o�ח\������e����(��)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLMRF );
            //�o�ח\������e����(��)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLDRF );
            //���͓�����N
            writer.Write( temp.HADD_INPUTDFYRF );
            //���͓�����N��
            writer.Write( temp.HADD_INPUTDFSRF );
            //���͓��a��N
            writer.Write( temp.HADD_INPUTDFWRF );
            //���͓���
            writer.Write( temp.HADD_INPUTDFMRF );
            //���͓���
            writer.Write( temp.HADD_INPUTDFDRF );
            //���͓�����
            writer.Write( temp.HADD_INPUTDFGRF );
            //���͓�����
            writer.Write( temp.HADD_INPUTDFRRF );
            //���͓����e����(/)
            writer.Write( temp.HADD_INPUTDFLSRF );
            //���͓����e����(.)
            writer.Write( temp.HADD_INPUTDFLPRF );
            //���͓����e����(�N)
            writer.Write( temp.HADD_INPUTDFLYRF );
            //���͓����e����(��)
            writer.Write( temp.HADD_INPUTDFLMRF );
            //���͓����e����(��)
            writer.Write( temp.HADD_INPUTDFLDRF );
            //���Д��l�P
            writer.Write( temp.HADD_NOTE1RF );
            //���Д��l�Q
            writer.Write( temp.HADD_NOTE2RF );
            //���Д��l�R
            writer.Write( temp.HADD_NOTE3RF );
            //�Ĕ��s�}�[�N
            writer.Write( temp.HADD_REISSUEMARKRF );
            //�v�����^�Ǘ�No
            writer.Write( temp.HADD_PRINTERMNGNORF );
            //�`�[����ݒ�p���[ID
            writer.Write( temp.HADD_SLIPPRTSETPAPERIDRF );
            //������� ��
            writer.Write( temp.HADD_PRINTTIMEHOURRF );
            //������� ��
            writer.Write( temp.HADD_PRINTTIMEMINUTERF );
            //������� �b
            writer.Write( temp.HADD_PRINTTIMESECONDRF );
            //�`�[���v���z
            writer.Write( temp.HADD_TTLSTOCKMOVEPRICERF );
            //�`�[���v���z(�W�����i)
            writer.Write( temp.HADD_TTLSTOCKMOVELISTPRICERF );
            //���͋��_�R�[�h
            writer.Write( temp.MOVH_UPDATESECCDRF );
            //���͋��_�K�C�h����
            writer.Write( temp.SEC0_SECTIONGUIDESNMRF );
            //���͋��_�K�C�h����
            writer.Write( temp.SEC0_SECTIONGUIDENMRF );

        }

        /// <summary>
        ///  FrePStockMoveSlipWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FrePStockMoveSlipWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveSlipWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FrePStockMoveSlipWork GetFrePStockMoveSlipWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FrePStockMoveSlipWork temp = new FrePStockMoveSlipWork();

            //�݌Ɉړ��`��
            temp.MOVH_STOCKMOVEFORMALRF = reader.ReadInt32();
            //�݌Ɉړ��`�[�ԍ�
            temp.MOVH_STOCKMOVESLIPNORF = reader.ReadInt32();
            //�ړ������_�R�[�h
            temp.MOVH_BFSECTIONCODERF = reader.ReadString();
            //�ړ������_�K�C�h����
            temp.MOVH_BFSECTIONGUIDESNMRF = reader.ReadString();
            //�ړ����q�ɃR�[�h
            temp.MOVH_BFENTERWAREHCODERF = reader.ReadString();
            //�ړ����q�ɖ���
            temp.MOVH_BFENTERWAREHNAMERF = reader.ReadString();
            //�ړ��拒�_�R�[�h
            temp.MOVH_AFSECTIONCODERF = reader.ReadString();
            //�ړ��拒�_�K�C�h����
            temp.MOVH_AFSECTIONGUIDESNMRF = reader.ReadString();
            //�ړ���q�ɃR�[�h
            temp.MOVH_AFENTERWAREHCODERF = reader.ReadString();
            //�ړ���q�ɖ���
            temp.MOVH_AFENTERWAREHNAMERF = reader.ReadString();
            //�o�ח\���
            temp.MOVH_SHIPMENTSCDLDAYRF = reader.ReadInt32();
            //���͓�
            temp.MOVH_INPUTDAYRF = reader.ReadInt32();
            //�݌Ɉړ����͏]�ƈ��R�[�h
            temp.MOVH_STOCKMVEMPCODERF = reader.ReadString();
            //�݌Ɉړ����͏]�ƈ�����
            temp.MOVH_STOCKMVEMPNAMERF = reader.ReadString();
            //�o�גS���]�ƈ��R�[�h
            temp.MOVH_SHIPAGENTCDRF = reader.ReadString();
            //�o�גS���]�ƈ�����
            temp.MOVH_SHIPAGENTNMRF = reader.ReadString();
            //����S���]�ƈ��R�[�h
            temp.MOVH_RECEIVEAGENTCDRF = reader.ReadString();
            //����S���]�ƈ�����
            temp.MOVH_RECEIVEAGENTNMRF = reader.ReadString();
            //�`�[�E�v
            temp.MOVH_OUTLINERF = reader.ReadString();
            //�q�ɔ��l1
            temp.MOVH_WAREHOUSENOTE1RF = reader.ReadString();
            //�`�[���s�ϋ敪
            temp.MOVH_SLIPPRINTFINISHCDRF = reader.ReadInt32();
            //���_�K�C�h����
            temp.SEC1_SECTIONGUIDENMRF = reader.ReadString();
            //���Ж��̃R�[�h1
            temp.SEC1_COMPANYNAMECD1RF = reader.ReadInt32();
            //���_�K�C�h����
            temp.SEC2_SECTIONGUIDENMRF = reader.ReadString();
            //���Ж��̃R�[�h1
            temp.SEC2_COMPANYNAMECD1RF = reader.ReadInt32();
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
            //����PR��
            temp.CMP1_COMPANYPRRF = reader.ReadString();
            //���Ж���1
            temp.CMP1_COMPANYNAME1RF = reader.ReadString();
            //���Ж���2
            temp.CMP1_COMPANYNAME2RF = reader.ReadString();
            //�X�֔ԍ�
            temp.CMP1_POSTNORF = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.CMP1_ADDRESS1RF = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.CMP1_ADDRESS3RF = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.CMP1_ADDRESS4RF = reader.ReadString();
            //���Гd�b�ԍ�1
            temp.CMP1_COMPANYTELNO1RF = reader.ReadString();
            //���Гd�b�ԍ�2
            temp.CMP1_COMPANYTELNO2RF = reader.ReadString();
            //���Гd�b�ԍ�3
            temp.CMP1_COMPANYTELNO3RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��1
            temp.CMP1_COMPANYTELTITLE1RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��2
            temp.CMP1_COMPANYTELTITLE2RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��3
            temp.CMP1_COMPANYTELTITLE3RF = reader.ReadString();
            //��s�U���ē���
            temp.CMP1_TRANSFERGUIDANCERF = reader.ReadString();
            //��s����1
            temp.CMP1_ACCOUNTNOINFO1RF = reader.ReadString();
            //��s����2
            temp.CMP1_ACCOUNTNOINFO2RF = reader.ReadString();
            //��s����3
            temp.CMP1_ACCOUNTNOINFO3RF = reader.ReadString();
            //���Аݒ�E�v1
            temp.CMP1_COMPANYSETNOTE1RF = reader.ReadString();
            //���Аݒ�E�v2
            temp.CMP1_COMPANYSETNOTE2RF = reader.ReadString();
            //�摜���敪
            temp.CMP1_IMAGEINFODIVRF = reader.ReadInt32();
            //�摜���R�[�h
            temp.CMP1_IMAGEINFOCODERF = reader.ReadInt32();
            //����URL
            temp.CMP1_COMPANYURLRF = reader.ReadString();
            //����PR��2
            temp.CMP1_COMPANYPRSENTENCE2RF = reader.ReadString();
            //�摜�󎚗p�R�����g1
            temp.CMP1_IMAGECOMMENTFORPRT1RF = reader.ReadString();
            //�摜�󎚗p�R�����g2
            temp.CMP1_IMAGECOMMENTFORPRT2RF = reader.ReadString();
            //����PR��
            temp.CMP2_COMPANYPRRF = reader.ReadString();
            //���Ж���1
            temp.CMP2_COMPANYNAME1RF = reader.ReadString();
            //���Ж���2
            temp.CMP2_COMPANYNAME2RF = reader.ReadString();
            //�X�֔ԍ�
            temp.CMP2_POSTNORF = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.CMP2_ADDRESS1RF = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.CMP2_ADDRESS3RF = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.CMP2_ADDRESS4RF = reader.ReadString();
            //���Гd�b�ԍ�1
            temp.CMP2_COMPANYTELNO1RF = reader.ReadString();
            //���Гd�b�ԍ�2
            temp.CMP2_COMPANYTELNO2RF = reader.ReadString();
            //���Гd�b�ԍ�3
            temp.CMP2_COMPANYTELNO3RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��1
            temp.CMP2_COMPANYTELTITLE1RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��2
            temp.CMP2_COMPANYTELTITLE2RF = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��3
            temp.CMP2_COMPANYTELTITLE3RF = reader.ReadString();
            //��s�U���ē���
            temp.CMP2_TRANSFERGUIDANCERF = reader.ReadString();
            //��s����1
            temp.CMP2_ACCOUNTNOINFO1RF = reader.ReadString();
            //��s����2
            temp.CMP2_ACCOUNTNOINFO2RF = reader.ReadString();
            //��s����3
            temp.CMP2_ACCOUNTNOINFO3RF = reader.ReadString();
            //���Аݒ�E�v1
            temp.CMP2_COMPANYSETNOTE1RF = reader.ReadString();
            //���Аݒ�E�v2
            temp.CMP2_COMPANYSETNOTE2RF = reader.ReadString();
            //����URL
            temp.CMP2_COMPANYURLRF = reader.ReadString();
            //����PR��2
            temp.CMP2_COMPANYPRSENTENCE2RF = reader.ReadString();
            //�摜�󎚗p�R�����g1
            temp.CMP2_IMAGECOMMENTFORPRT1RF = reader.ReadString();
            //�摜�󎚗p�R�����g2
            temp.CMP2_IMAGECOMMENTFORPRT2RF = reader.ReadString();
            //�J�i
            temp.EMP1_KANARF = reader.ReadString();
            //�Z�k����
            temp.EMP1_SHORTNAMERF = reader.ReadString();
            //�J�i
            temp.EMP2_KANARF = reader.ReadString();
            //�Z�k����
            temp.EMP2_SHORTNAMERF = reader.ReadString();
            //�J�i
            temp.EMP3_KANARF = reader.ReadString();
            //�Z�k����
            temp.EMP3_SHORTNAMERF = reader.ReadString();
            //�摜���f�[�^
            //�݌Ɉړ��`������
            temp.HADD_STOCKMOVEFORMALNMRF = reader.ReadString();
            //�o�ח\�������N
            temp.HADD_SHIPMENTSCDLDFYRF = reader.ReadInt32();
            //�o�ח\�������N��
            temp.HADD_SHIPMENTSCDLDFSRF = reader.ReadInt32();
            //�o�ח\����a��N
            temp.HADD_SHIPMENTSCDLDFWRF = reader.ReadInt32();
            //�o�ח\�����
            temp.HADD_SHIPMENTSCDLDFMRF = reader.ReadInt32();
            //�o�ח\�����
            temp.HADD_SHIPMENTSCDLDFDRF = reader.ReadInt32();
            //�o�ח\�������
            temp.HADD_SHIPMENTSCDLDFGRF = reader.ReadString();
            //�o�ח\�������
            temp.HADD_SHIPMENTSCDLDFRRF = reader.ReadString();
            //�o�ח\������e����(/)
            temp.HADD_SHIPMENTSCDLDFLSRF = reader.ReadString();
            //�o�ח\������e����(.)
            temp.HADD_SHIPMENTSCDLDFLPRF = reader.ReadString();
            //�o�ח\������e����(�N)
            temp.HADD_SHIPMENTSCDLDFLYRF = reader.ReadString();
            //�o�ח\������e����(��)
            temp.HADD_SHIPMENTSCDLDFLMRF = reader.ReadString();
            //�o�ח\������e����(��)
            temp.HADD_SHIPMENTSCDLDFLDRF = reader.ReadString();
            //���͓�����N
            temp.HADD_INPUTDFYRF = reader.ReadInt32();
            //���͓�����N��
            temp.HADD_INPUTDFSRF = reader.ReadInt32();
            //���͓��a��N
            temp.HADD_INPUTDFWRF = reader.ReadInt32();
            //���͓���
            temp.HADD_INPUTDFMRF = reader.ReadInt32();
            //���͓���
            temp.HADD_INPUTDFDRF = reader.ReadInt32();
            //���͓�����
            temp.HADD_INPUTDFGRF = reader.ReadString();
            //���͓�����
            temp.HADD_INPUTDFRRF = reader.ReadString();
            //���͓����e����(/)
            temp.HADD_INPUTDFLSRF = reader.ReadString();
            //���͓����e����(.)
            temp.HADD_INPUTDFLPRF = reader.ReadString();
            //���͓����e����(�N)
            temp.HADD_INPUTDFLYRF = reader.ReadString();
            //���͓����e����(��)
            temp.HADD_INPUTDFLMRF = reader.ReadString();
            //���͓����e����(��)
            temp.HADD_INPUTDFLDRF = reader.ReadString();
            //���Д��l�P
            temp.HADD_NOTE1RF = reader.ReadString();
            //���Д��l�Q
            temp.HADD_NOTE2RF = reader.ReadString();
            //���Д��l�R
            temp.HADD_NOTE3RF = reader.ReadString();
            //�Ĕ��s�}�[�N
            temp.HADD_REISSUEMARKRF = reader.ReadString();
            //�v�����^�Ǘ�No
            temp.HADD_PRINTERMNGNORF = reader.ReadInt32();
            //�`�[����ݒ�p���[ID
            temp.HADD_SLIPPRTSETPAPERIDRF = reader.ReadString();
            //������� ��
            temp.HADD_PRINTTIMEHOURRF = reader.ReadInt32();
            //������� ��
            temp.HADD_PRINTTIMEMINUTERF = reader.ReadInt32();
            //������� �b
            temp.HADD_PRINTTIMESECONDRF = reader.ReadInt32();
            //�`�[���v���z
            temp.HADD_TTLSTOCKMOVEPRICERF = reader.ReadInt64();
            //�`�[���v���z(�W�����i)
            temp.HADD_TTLSTOCKMOVELISTPRICERF = reader.ReadInt64();
            //���͋��_�R�[�h
            temp.MOVH_UPDATESECCDRF = reader.ReadString();
            //���͋��_�K�C�h����
            temp.SEC0_SECTIONGUIDESNMRF = reader.ReadString();
            //���͋��_�K�C�h����
            temp.SEC0_SECTIONGUIDENMRF = reader.ReadString();


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
        /// <returns>FrePStockMoveSlipWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePStockMoveSlipWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePStockMoveSlipWork temp = GetFrePStockMoveSlipWork( reader, serInfo );
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
                    retValue = (FrePStockMoveSlipWork[])lst.ToArray( typeof( FrePStockMoveSlipWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
