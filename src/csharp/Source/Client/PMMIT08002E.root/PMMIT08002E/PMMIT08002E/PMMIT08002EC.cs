using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FrePEstFmDetail
    /// <summary>
    ///                      ���R���[���Ϗ����׃f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[���Ϗ����׃f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FrePEstFmDetail
    {
        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _sALESDETAILRF_SALESSLIPNUMRF = "";

        /// <summary>����s�ԍ�</summary>
        private Int32 _sALESDETAILRF_SALESROWNORF;

        /// <summary>�������i���[�J�[�R�[�h</summary>
        private Int32 _dPURE_GOODSMAKERCDRF;

        /// <summary>�������[�J�[����</summary>
        private string _dPURE_MAKERNAMERF = "";

        /// <summary>�������[�J�[�J�i����</summary>
        private string _dPURE_MAKERKANANAMERF = "";

        /// <summary>�������i�ԍ�</summary>
        private string _dPURE_GOODSNORF = "";

        /// <summary>�������i����</summary>
        private string _dPURE_GOODSNAMERF = "";

        /// <summary>�������i���̃J�i</summary>
        private string _dPURE_GOODSNAMEKANARF = "";

        /// <summary>����BL���i�R�[�h</summary>
        private Int32 _dPURE_BLGOODSCODERF;

        /// <summary>��������P���i�ō��C�����j</summary>
        private Double _dPURE_SALESUNPRCTAXINCFLRF;

        /// <summary>��������P���i�Ŕ��C�����j</summary>
        private Double _dPURE_SALESUNPRCTAXEXCFLRF;

        /// <summary>�����艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _dPURE_LISTPRICETAXINCFLRF;

        /// <summary>�����艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _dPURE_LISTPRICETAXEXCFLRF;

        /// <summary>����������z�i�ō��݁j</summary>
        private Int64 _dPURE_SALESMONEYTAXINCRF;

        /// <summary>����������z�i�Ŕ����j</summary>
        private Int64 _dPURE_SALESMONEYTAXEXCRF;

        /// <summary>�����ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _dPURE_TAXATIONDIVCDRF;

        /// <summary>��������P��</summary>
        /// <remarks>�������p</remarks>
        private Double _dPURE_SALESUNPRCFLRF;

        /// <summary>�����艿</summary>
        /// <remarks>�������p</remarks>
        private Double _dPURE_LISTPRICERF;

        /// <summary>�����o�א�</summary>
        /// <remarks>�������p</remarks>
        private Double _dPURE_SHIPMENTCNTRF;

        /// <summary>����������z</summary>
        /// <remarks>�������p</remarks>
        private Int64 _dPURE_SALESMONEYRF;

        /// <summary>�D�Ǐ��i���[�J�[�R�[�h</summary>
        private Int32 _dPRIM_GOODSMAKERCDRF;

        /// <summary>�D�ǃ��[�J�[����</summary>
        private string _dPRIM_MAKERNAMERF = "";

        /// <summary>�D�ǃ��[�J�[�J�i����</summary>
        private string _dPRIM_MAKERKANANAMERF = "";

        /// <summary>�D�Ǐ��i�ԍ�</summary>
        private string _dPRIM_GOODSNORF = "";

        /// <summary>�D�Ǐ��i����</summary>
        private string _dPRIM_GOODSNAMERF = "";

        /// <summary>�D�Ǐ��i���̃J�i</summary>
        private string _dPRIM_GOODSNAMEKANARF = "";

        /// <summary>�D��BL���i�R�[�h</summary>
        private Int32 _dPRIM_BLGOODSCODERF;

        /// <summary>�D�ǔ���P���i�ō��C�����j</summary>
        private Double _dPRIM_SALESUNPRCTAXINCFLRF;

        /// <summary>�D�ǔ���P���i�Ŕ��C�����j</summary>
        private Double _dPRIM_SALESUNPRCTAXEXCFLRF;

        /// <summary>�D�ǒ艿�i�ō��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _dPRIM_LISTPRICETAXINCFLRF;

        /// <summary>�D�ǒ艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _dPRIM_LISTPRICETAXEXCFLRF;

        /// <summary>�D�ǔ�����z�i�ō��݁j</summary>
        private Int64 _dPRIM_SALESMONEYTAXINCRF;

        /// <summary>�D�ǔ�����z�i�Ŕ����j</summary>
        private Int64 _dPRIM_SALESMONEYTAXEXCRF;

        /// <summary>�D�ǉېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _dPRIM_TAXATIONDIVCDRF;

        /// <summary>�D�ǔ���P��</summary>
        /// <remarks>�������p</remarks>
        private Double _dPRIM_SALESUNPRCFLRF;

        /// <summary>�D�ǒ艿</summary>
        /// <remarks>�������p</remarks>
        private Double _dPRIM_LISTPRICERF;

        /// <summary>�D�Ǐo�א�</summary>
        /// <remarks>�������p</remarks>
        private Double _dPRIM_SHIPMENTCNTRF;

        /// <summary>�D�ǔ�����z</summary>
        /// <remarks>�������p</remarks>
        private Int64 _dPRIM_SALESMONEYRF;

        /// <summary>�I�v�V�����E�K�i���</summary>
        private string _dADD_SPECIALNOTE = "";


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

        /// public propaty name  :  DPURE_GOODSMAKERCDRF
        /// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DPURE_GOODSMAKERCDRF
        {
            get { return _dPURE_GOODSMAKERCDRF; }
            set { _dPURE_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  DPURE_MAKERNAMERF
        /// <summary>�������[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPURE_MAKERNAMERF
        {
            get { return _dPURE_MAKERNAMERF; }
            set { _dPURE_MAKERNAMERF = value; }
        }

        /// public propaty name  :  DPURE_MAKERKANANAMERF
        /// <summary>�������[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPURE_MAKERKANANAMERF
        {
            get { return _dPURE_MAKERKANANAMERF; }
            set { _dPURE_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  DPURE_GOODSNORF
        /// <summary>�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPURE_GOODSNORF
        {
            get { return _dPURE_GOODSNORF; }
            set { _dPURE_GOODSNORF = value; }
        }

        /// public propaty name  :  DPURE_GOODSNAMERF
        /// <summary>�������i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPURE_GOODSNAMERF
        {
            get { return _dPURE_GOODSNAMERF; }
            set { _dPURE_GOODSNAMERF = value; }
        }

        /// public propaty name  :  DPURE_GOODSNAMEKANARF
        /// <summary>�������i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPURE_GOODSNAMEKANARF
        {
            get { return _dPURE_GOODSNAMEKANARF; }
            set { _dPURE_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  DPURE_BLGOODSCODERF
        /// <summary>����BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DPURE_BLGOODSCODERF
        {
            get { return _dPURE_BLGOODSCODERF; }
            set { _dPURE_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  DPURE_SALESUNPRCTAXINCFLRF
        /// <summary>��������P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_SALESUNPRCTAXINCFLRF
        {
            get { return _dPURE_SALESUNPRCTAXINCFLRF; }
            set { _dPURE_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  DPURE_SALESUNPRCTAXEXCFLRF
        /// <summary>��������P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_SALESUNPRCTAXEXCFLRF
        {
            get { return _dPURE_SALESUNPRCTAXEXCFLRF; }
            set { _dPURE_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPURE_LISTPRICETAXINCFLRF
        /// <summary>�����艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_LISTPRICETAXINCFLRF
        {
            get { return _dPURE_LISTPRICETAXINCFLRF; }
            set { _dPURE_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  DPURE_LISTPRICETAXEXCFLRF
        /// <summary>�����艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_LISTPRICETAXEXCFLRF
        {
            get { return _dPURE_LISTPRICETAXEXCFLRF; }
            set { _dPURE_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPURE_SALESMONEYTAXINCRF
        /// <summary>����������z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DPURE_SALESMONEYTAXINCRF
        {
            get { return _dPURE_SALESMONEYTAXINCRF; }
            set { _dPURE_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  DPURE_SALESMONEYTAXEXCRF
        /// <summary>����������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DPURE_SALESMONEYTAXEXCRF
        {
            get { return _dPURE_SALESMONEYTAXEXCRF; }
            set { _dPURE_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  DPURE_TAXATIONDIVCDRF
        /// <summary>�����ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DPURE_TAXATIONDIVCDRF
        {
            get { return _dPURE_TAXATIONDIVCDRF; }
            set { _dPURE_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  DPURE_SALESUNPRCFLRF
        /// <summary>��������P���v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_SALESUNPRCFLRF
        {
            get { return _dPURE_SALESUNPRCFLRF; }
            set { _dPURE_SALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  DPURE_LISTPRICERF
        /// <summary>�����艿�v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_LISTPRICERF
        {
            get { return _dPURE_LISTPRICERF; }
            set { _dPURE_LISTPRICERF = value; }
        }

        /// public propaty name  :  DPURE_SHIPMENTCNTRF
        /// <summary>�����o�א��v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPURE_SHIPMENTCNTRF
        {
            get { return _dPURE_SHIPMENTCNTRF; }
            set { _dPURE_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  DPURE_SALESMONEYRF
        /// <summary>����������z�v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DPURE_SALESMONEYRF
        {
            get { return _dPURE_SALESMONEYRF; }
            set { _dPURE_SALESMONEYRF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSMAKERCDRF
        /// <summary>�D�Ǐ��i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǐ��i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DPRIM_GOODSMAKERCDRF
        {
            get { return _dPRIM_GOODSMAKERCDRF; }
            set { _dPRIM_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  DPRIM_MAKERNAMERF
        /// <summary>�D�ǃ��[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǃ��[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPRIM_MAKERNAMERF
        {
            get { return _dPRIM_MAKERNAMERF; }
            set { _dPRIM_MAKERNAMERF = value; }
        }

        /// public propaty name  :  DPRIM_MAKERKANANAMERF
        /// <summary>�D�ǃ��[�J�[�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǃ��[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPRIM_MAKERKANANAMERF
        {
            get { return _dPRIM_MAKERKANANAMERF; }
            set { _dPRIM_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSNORF
        /// <summary>�D�Ǐ��i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǐ��i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPRIM_GOODSNORF
        {
            get { return _dPRIM_GOODSNORF; }
            set { _dPRIM_GOODSNORF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSNAMERF
        /// <summary>�D�Ǐ��i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǐ��i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPRIM_GOODSNAMERF
        {
            get { return _dPRIM_GOODSNAMERF; }
            set { _dPRIM_GOODSNAMERF = value; }
        }

        /// public propaty name  :  DPRIM_GOODSNAMEKANARF
        /// <summary>�D�Ǐ��i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǐ��i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DPRIM_GOODSNAMEKANARF
        {
            get { return _dPRIM_GOODSNAMEKANARF; }
            set { _dPRIM_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  DPRIM_BLGOODSCODERF
        /// <summary>�D��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DPRIM_BLGOODSCODERF
        {
            get { return _dPRIM_BLGOODSCODERF; }
            set { _dPRIM_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  DPRIM_SALESUNPRCTAXINCFLRF
        /// <summary>�D�ǔ���P���i�ō��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǔ���P���i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_SALESUNPRCTAXINCFLRF
        {
            get { return _dPRIM_SALESUNPRCTAXINCFLRF; }
            set { _dPRIM_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESUNPRCTAXEXCFLRF
        /// <summary>�D�ǔ���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǔ���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_SALESUNPRCTAXEXCFLRF
        {
            get { return _dPRIM_SALESUNPRCTAXEXCFLRF; }
            set { _dPRIM_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_LISTPRICETAXINCFLRF
        /// <summary>�D�ǒ艿�i�ō��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǒ艿�i�ō��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_LISTPRICETAXINCFLRF
        {
            get { return _dPRIM_LISTPRICETAXINCFLRF; }
            set { _dPRIM_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_LISTPRICETAXEXCFLRF
        /// <summary>�D�ǒ艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǒ艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_LISTPRICETAXEXCFLRF
        {
            get { return _dPRIM_LISTPRICETAXEXCFLRF; }
            set { _dPRIM_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESMONEYTAXINCRF
        /// <summary>�D�ǔ�����z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǔ�����z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DPRIM_SALESMONEYTAXINCRF
        {
            get { return _dPRIM_SALESMONEYTAXINCRF; }
            set { _dPRIM_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESMONEYTAXEXCRF
        /// <summary>�D�ǔ�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǔ�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DPRIM_SALESMONEYTAXEXCRF
        {
            get { return _dPRIM_SALESMONEYTAXEXCRF; }
            set { _dPRIM_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  DPRIM_TAXATIONDIVCDRF
        /// <summary>�D�ǉېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǉېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DPRIM_TAXATIONDIVCDRF
        {
            get { return _dPRIM_TAXATIONDIVCDRF; }
            set { _dPRIM_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESUNPRCFLRF
        /// <summary>�D�ǔ���P���v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǔ���P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_SALESUNPRCFLRF
        {
            get { return _dPRIM_SALESUNPRCFLRF; }
            set { _dPRIM_SALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  DPRIM_LISTPRICERF
        /// <summary>�D�ǒ艿�v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǒ艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_LISTPRICERF
        {
            get { return _dPRIM_LISTPRICERF; }
            set { _dPRIM_LISTPRICERF = value; }
        }

        /// public propaty name  :  DPRIM_SHIPMENTCNTRF
        /// <summary>�D�Ǐo�א��v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǐo�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DPRIM_SHIPMENTCNTRF
        {
            get { return _dPRIM_SHIPMENTCNTRF; }
            set { _dPRIM_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  DPRIM_SALESMONEYRF
        /// <summary>�D�ǔ�����z�v���p�e�B</summary>
        /// <value>�������p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǔ�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DPRIM_SALESMONEYRF
        {
            get { return _dPRIM_SALESMONEYRF; }
            set { _dPRIM_SALESMONEYRF = value; }
        }

        /// public propaty name  :  DADD_SPECIALNOTE
        /// <summary>�I�v�V�����E�K�i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�v�V�����E�K�i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DADD_SPECIALNOTE
        {
            get { return _dADD_SPECIALNOTE; }
            set { _dADD_SPECIALNOTE = value; }
        }


        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>FrePEstFmDetail�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePEstFmDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePEstFmDetail()
        {
        }

        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="sALESDETAILRF_SALESSLIPNUMRF">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
        /// <param name="sALESDETAILRF_SALESROWNORF">����s�ԍ�</param>
        /// <param name="dPURE_GOODSMAKERCDRF">�������i���[�J�[�R�[�h</param>
        /// <param name="dPURE_MAKERNAMERF">�������[�J�[����</param>
        /// <param name="dPURE_MAKERKANANAMERF">�������[�J�[�J�i����</param>
        /// <param name="dPURE_GOODSNORF">�������i�ԍ�</param>
        /// <param name="dPURE_GOODSNAMERF">�������i����</param>
        /// <param name="dPURE_GOODSNAMEKANARF">�������i���̃J�i</param>
        /// <param name="dPURE_BLGOODSCODERF">����BL���i�R�[�h</param>
        /// <param name="dPURE_SALESUNPRCTAXINCFLRF">��������P���i�ō��C�����j</param>
        /// <param name="dPURE_SALESUNPRCTAXEXCFLRF">��������P���i�Ŕ��C�����j</param>
        /// <param name="dPURE_LISTPRICETAXINCFLRF">�����艿�i�ō��C�����j(�Ŕ���)</param>
        /// <param name="dPURE_LISTPRICETAXEXCFLRF">�����艿�i�Ŕ��C�����j(�ō���)</param>
        /// <param name="dPURE_SALESMONEYTAXINCRF">����������z�i�ō��݁j</param>
        /// <param name="dPURE_SALESMONEYTAXEXCRF">����������z�i�Ŕ����j</param>
        /// <param name="dPURE_TAXATIONDIVCDRF">�����ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="dPURE_SALESUNPRCFLRF">��������P��(�������p)</param>
        /// <param name="dPURE_LISTPRICERF">�����艿(�������p)</param>
        /// <param name="dPURE_SHIPMENTCNTRF">�����o�א�(�������p)</param>
        /// <param name="dPURE_SALESMONEYRF">����������z(�������p)</param>
        /// <param name="dPRIM_GOODSMAKERCDRF">�D�Ǐ��i���[�J�[�R�[�h</param>
        /// <param name="dPRIM_MAKERNAMERF">�D�ǃ��[�J�[����</param>
        /// <param name="dPRIM_MAKERKANANAMERF">�D�ǃ��[�J�[�J�i����</param>
        /// <param name="dPRIM_GOODSNORF">�D�Ǐ��i�ԍ�</param>
        /// <param name="dPRIM_GOODSNAMERF">�D�Ǐ��i����</param>
        /// <param name="dPRIM_GOODSNAMEKANARF">�D�Ǐ��i���̃J�i</param>
        /// <param name="dPRIM_BLGOODSCODERF">�D��BL���i�R�[�h</param>
        /// <param name="dPRIM_SALESUNPRCTAXINCFLRF">�D�ǔ���P���i�ō��C�����j</param>
        /// <param name="dPRIM_SALESUNPRCTAXEXCFLRF">�D�ǔ���P���i�Ŕ��C�����j</param>
        /// <param name="dPRIM_LISTPRICETAXINCFLRF">�D�ǒ艿�i�ō��C�����j(�Ŕ���)</param>
        /// <param name="dPRIM_LISTPRICETAXEXCFLRF">�D�ǒ艿�i�Ŕ��C�����j(�ō���)</param>
        /// <param name="dPRIM_SALESMONEYTAXINCRF">�D�ǔ�����z�i�ō��݁j</param>
        /// <param name="dPRIM_SALESMONEYTAXEXCRF">�D�ǔ�����z�i�Ŕ����j</param>
        /// <param name="dPRIM_TAXATIONDIVCDRF">�D�ǉېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="dPRIM_SALESUNPRCFLRF">�D�ǔ���P��(�������p)</param>
        /// <param name="dPRIM_LISTPRICERF">�D�ǒ艿(�������p)</param>
        /// <param name="dPRIM_SHIPMENTCNTRF">�D�Ǐo�א�(�������p)</param>
        /// <param name="dPRIM_SALESMONEYRF">�D�ǔ�����z(�������p)</param>
        /// <param name="dADD_SPECIALNOTE">�I�v�V�����E�K�i���</param>
        /// <returns>FrePEstFmDetail�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePEstFmDetail�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePEstFmDetail( string sALESDETAILRF_SALESSLIPNUMRF, Int32 sALESDETAILRF_SALESROWNORF, Int32 dPURE_GOODSMAKERCDRF, string dPURE_MAKERNAMERF, string dPURE_MAKERKANANAMERF, string dPURE_GOODSNORF, string dPURE_GOODSNAMERF, string dPURE_GOODSNAMEKANARF, Int32 dPURE_BLGOODSCODERF, Double dPURE_SALESUNPRCTAXINCFLRF, Double dPURE_SALESUNPRCTAXEXCFLRF, Double dPURE_LISTPRICETAXINCFLRF, Double dPURE_LISTPRICETAXEXCFLRF, Int64 dPURE_SALESMONEYTAXINCRF, Int64 dPURE_SALESMONEYTAXEXCRF, Int32 dPURE_TAXATIONDIVCDRF, Double dPURE_SALESUNPRCFLRF, Double dPURE_LISTPRICERF, Double dPURE_SHIPMENTCNTRF, Int64 dPURE_SALESMONEYRF, Int32 dPRIM_GOODSMAKERCDRF, string dPRIM_MAKERNAMERF, string dPRIM_MAKERKANANAMERF, string dPRIM_GOODSNORF, string dPRIM_GOODSNAMERF, string dPRIM_GOODSNAMEKANARF, Int32 dPRIM_BLGOODSCODERF, Double dPRIM_SALESUNPRCTAXINCFLRF, Double dPRIM_SALESUNPRCTAXEXCFLRF, Double dPRIM_LISTPRICETAXINCFLRF, Double dPRIM_LISTPRICETAXEXCFLRF, Int64 dPRIM_SALESMONEYTAXINCRF, Int64 dPRIM_SALESMONEYTAXEXCRF, Int32 dPRIM_TAXATIONDIVCDRF, Double dPRIM_SALESUNPRCFLRF, Double dPRIM_LISTPRICERF, Double dPRIM_SHIPMENTCNTRF, Int64 dPRIM_SALESMONEYRF, string dADD_SPECIALNOTE )
        {
            this._sALESDETAILRF_SALESSLIPNUMRF = sALESDETAILRF_SALESSLIPNUMRF;
            this._sALESDETAILRF_SALESROWNORF = sALESDETAILRF_SALESROWNORF;
            this._dPURE_GOODSMAKERCDRF = dPURE_GOODSMAKERCDRF;
            this._dPURE_MAKERNAMERF = dPURE_MAKERNAMERF;
            this._dPURE_MAKERKANANAMERF = dPURE_MAKERKANANAMERF;
            this._dPURE_GOODSNORF = dPURE_GOODSNORF;
            this._dPURE_GOODSNAMERF = dPURE_GOODSNAMERF;
            this._dPURE_GOODSNAMEKANARF = dPURE_GOODSNAMEKANARF;
            this._dPURE_BLGOODSCODERF = dPURE_BLGOODSCODERF;
            this._dPURE_SALESUNPRCTAXINCFLRF = dPURE_SALESUNPRCTAXINCFLRF;
            this._dPURE_SALESUNPRCTAXEXCFLRF = dPURE_SALESUNPRCTAXEXCFLRF;
            this._dPURE_LISTPRICETAXINCFLRF = dPURE_LISTPRICETAXINCFLRF;
            this._dPURE_LISTPRICETAXEXCFLRF = dPURE_LISTPRICETAXEXCFLRF;
            this._dPURE_SALESMONEYTAXINCRF = dPURE_SALESMONEYTAXINCRF;
            this._dPURE_SALESMONEYTAXEXCRF = dPURE_SALESMONEYTAXEXCRF;
            this._dPURE_TAXATIONDIVCDRF = dPURE_TAXATIONDIVCDRF;
            this._dPURE_SALESUNPRCFLRF = dPURE_SALESUNPRCFLRF;
            this._dPURE_LISTPRICERF = dPURE_LISTPRICERF;
            this._dPURE_SHIPMENTCNTRF = dPURE_SHIPMENTCNTRF;
            this._dPURE_SALESMONEYRF = dPURE_SALESMONEYRF;
            this._dPRIM_GOODSMAKERCDRF = dPRIM_GOODSMAKERCDRF;
            this._dPRIM_MAKERNAMERF = dPRIM_MAKERNAMERF;
            this._dPRIM_MAKERKANANAMERF = dPRIM_MAKERKANANAMERF;
            this._dPRIM_GOODSNORF = dPRIM_GOODSNORF;
            this._dPRIM_GOODSNAMERF = dPRIM_GOODSNAMERF;
            this._dPRIM_GOODSNAMEKANARF = dPRIM_GOODSNAMEKANARF;
            this._dPRIM_BLGOODSCODERF = dPRIM_BLGOODSCODERF;
            this._dPRIM_SALESUNPRCTAXINCFLRF = dPRIM_SALESUNPRCTAXINCFLRF;
            this._dPRIM_SALESUNPRCTAXEXCFLRF = dPRIM_SALESUNPRCTAXEXCFLRF;
            this._dPRIM_LISTPRICETAXINCFLRF = dPRIM_LISTPRICETAXINCFLRF;
            this._dPRIM_LISTPRICETAXEXCFLRF = dPRIM_LISTPRICETAXEXCFLRF;
            this._dPRIM_SALESMONEYTAXINCRF = dPRIM_SALESMONEYTAXINCRF;
            this._dPRIM_SALESMONEYTAXEXCRF = dPRIM_SALESMONEYTAXEXCRF;
            this._dPRIM_TAXATIONDIVCDRF = dPRIM_TAXATIONDIVCDRF;
            this._dPRIM_SALESUNPRCFLRF = dPRIM_SALESUNPRCFLRF;
            this._dPRIM_LISTPRICERF = dPRIM_LISTPRICERF;
            this._dPRIM_SHIPMENTCNTRF = dPRIM_SHIPMENTCNTRF;
            this._dPRIM_SALESMONEYRF = dPRIM_SALESMONEYRF;
            this._dADD_SPECIALNOTE = dADD_SPECIALNOTE;

        }

        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^��������
        /// </summary>
        /// <returns>FrePEstFmDetail�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����FrePEstFmDetail�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePEstFmDetail Clone()
        {
            return new FrePEstFmDetail( this._sALESDETAILRF_SALESSLIPNUMRF, this._sALESDETAILRF_SALESROWNORF, this._dPURE_GOODSMAKERCDRF, this._dPURE_MAKERNAMERF, this._dPURE_MAKERKANANAMERF, this._dPURE_GOODSNORF, this._dPURE_GOODSNAMERF, this._dPURE_GOODSNAMEKANARF, this._dPURE_BLGOODSCODERF, this._dPURE_SALESUNPRCTAXINCFLRF, this._dPURE_SALESUNPRCTAXEXCFLRF, this._dPURE_LISTPRICETAXINCFLRF, this._dPURE_LISTPRICETAXEXCFLRF, this._dPURE_SALESMONEYTAXINCRF, this._dPURE_SALESMONEYTAXEXCRF, this._dPURE_TAXATIONDIVCDRF, this._dPURE_SALESUNPRCFLRF, this._dPURE_LISTPRICERF, this._dPURE_SHIPMENTCNTRF, this._dPURE_SALESMONEYRF, this._dPRIM_GOODSMAKERCDRF, this._dPRIM_MAKERNAMERF, this._dPRIM_MAKERKANANAMERF, this._dPRIM_GOODSNORF, this._dPRIM_GOODSNAMERF, this._dPRIM_GOODSNAMEKANARF, this._dPRIM_BLGOODSCODERF, this._dPRIM_SALESUNPRCTAXINCFLRF, this._dPRIM_SALESUNPRCTAXEXCFLRF, this._dPRIM_LISTPRICETAXINCFLRF, this._dPRIM_LISTPRICETAXEXCFLRF, this._dPRIM_SALESMONEYTAXINCRF, this._dPRIM_SALESMONEYTAXEXCRF, this._dPRIM_TAXATIONDIVCDRF, this._dPRIM_SALESUNPRCFLRF, this._dPRIM_LISTPRICERF, this._dPRIM_SHIPMENTCNTRF, this._dPRIM_SALESMONEYRF, this._dADD_SPECIALNOTE );
        }

        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�FrePEstFmDetail�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePEstFmDetail�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( FrePEstFmDetail target )
        {
            return ((this.SALESDETAILRF_SALESSLIPNUMRF == target.SALESDETAILRF_SALESSLIPNUMRF)
                 && (this.SALESDETAILRF_SALESROWNORF == target.SALESDETAILRF_SALESROWNORF)
                 && (this.DPURE_GOODSMAKERCDRF == target.DPURE_GOODSMAKERCDRF)
                 && (this.DPURE_MAKERNAMERF == target.DPURE_MAKERNAMERF)
                 && (this.DPURE_MAKERKANANAMERF == target.DPURE_MAKERKANANAMERF)
                 && (this.DPURE_GOODSNORF == target.DPURE_GOODSNORF)
                 && (this.DPURE_GOODSNAMERF == target.DPURE_GOODSNAMERF)
                 && (this.DPURE_GOODSNAMEKANARF == target.DPURE_GOODSNAMEKANARF)
                 && (this.DPURE_BLGOODSCODERF == target.DPURE_BLGOODSCODERF)
                 && (this.DPURE_SALESUNPRCTAXINCFLRF == target.DPURE_SALESUNPRCTAXINCFLRF)
                 && (this.DPURE_SALESUNPRCTAXEXCFLRF == target.DPURE_SALESUNPRCTAXEXCFLRF)
                 && (this.DPURE_LISTPRICETAXINCFLRF == target.DPURE_LISTPRICETAXINCFLRF)
                 && (this.DPURE_LISTPRICETAXEXCFLRF == target.DPURE_LISTPRICETAXEXCFLRF)
                 && (this.DPURE_SALESMONEYTAXINCRF == target.DPURE_SALESMONEYTAXINCRF)
                 && (this.DPURE_SALESMONEYTAXEXCRF == target.DPURE_SALESMONEYTAXEXCRF)
                 && (this.DPURE_TAXATIONDIVCDRF == target.DPURE_TAXATIONDIVCDRF)
                 && (this.DPURE_SALESUNPRCFLRF == target.DPURE_SALESUNPRCFLRF)
                 && (this.DPURE_LISTPRICERF == target.DPURE_LISTPRICERF)
                 && (this.DPURE_SHIPMENTCNTRF == target.DPURE_SHIPMENTCNTRF)
                 && (this.DPURE_SALESMONEYRF == target.DPURE_SALESMONEYRF)
                 && (this.DPRIM_GOODSMAKERCDRF == target.DPRIM_GOODSMAKERCDRF)
                 && (this.DPRIM_MAKERNAMERF == target.DPRIM_MAKERNAMERF)
                 && (this.DPRIM_MAKERKANANAMERF == target.DPRIM_MAKERKANANAMERF)
                 && (this.DPRIM_GOODSNORF == target.DPRIM_GOODSNORF)
                 && (this.DPRIM_GOODSNAMERF == target.DPRIM_GOODSNAMERF)
                 && (this.DPRIM_GOODSNAMEKANARF == target.DPRIM_GOODSNAMEKANARF)
                 && (this.DPRIM_BLGOODSCODERF == target.DPRIM_BLGOODSCODERF)
                 && (this.DPRIM_SALESUNPRCTAXINCFLRF == target.DPRIM_SALESUNPRCTAXINCFLRF)
                 && (this.DPRIM_SALESUNPRCTAXEXCFLRF == target.DPRIM_SALESUNPRCTAXEXCFLRF)
                 && (this.DPRIM_LISTPRICETAXINCFLRF == target.DPRIM_LISTPRICETAXINCFLRF)
                 && (this.DPRIM_LISTPRICETAXEXCFLRF == target.DPRIM_LISTPRICETAXEXCFLRF)
                 && (this.DPRIM_SALESMONEYTAXINCRF == target.DPRIM_SALESMONEYTAXINCRF)
                 && (this.DPRIM_SALESMONEYTAXEXCRF == target.DPRIM_SALESMONEYTAXEXCRF)
                 && (this.DPRIM_TAXATIONDIVCDRF == target.DPRIM_TAXATIONDIVCDRF)
                 && (this.DPRIM_SALESUNPRCFLRF == target.DPRIM_SALESUNPRCFLRF)
                 && (this.DPRIM_LISTPRICERF == target.DPRIM_LISTPRICERF)
                 && (this.DPRIM_SHIPMENTCNTRF == target.DPRIM_SHIPMENTCNTRF)
                 && (this.DPRIM_SALESMONEYRF == target.DPRIM_SALESMONEYRF)
                 && (this.DADD_SPECIALNOTE == target.DADD_SPECIALNOTE));
        }

        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^��r����
        /// </summary>
        /// <param name="frePEstFmDetail1">
        ///                    ��r����FrePEstFmDetail�N���X�̃C���X�^���X
        /// </param>
        /// <param name="frePEstFmDetail2">��r����FrePEstFmDetail�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePEstFmDetail�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( FrePEstFmDetail frePEstFmDetail1, FrePEstFmDetail frePEstFmDetail2 )
        {
            return ((frePEstFmDetail1.SALESDETAILRF_SALESSLIPNUMRF == frePEstFmDetail2.SALESDETAILRF_SALESSLIPNUMRF)
                 && (frePEstFmDetail1.SALESDETAILRF_SALESROWNORF == frePEstFmDetail2.SALESDETAILRF_SALESROWNORF)
                 && (frePEstFmDetail1.DPURE_GOODSMAKERCDRF == frePEstFmDetail2.DPURE_GOODSMAKERCDRF)
                 && (frePEstFmDetail1.DPURE_MAKERNAMERF == frePEstFmDetail2.DPURE_MAKERNAMERF)
                 && (frePEstFmDetail1.DPURE_MAKERKANANAMERF == frePEstFmDetail2.DPURE_MAKERKANANAMERF)
                 && (frePEstFmDetail1.DPURE_GOODSNORF == frePEstFmDetail2.DPURE_GOODSNORF)
                 && (frePEstFmDetail1.DPURE_GOODSNAMERF == frePEstFmDetail2.DPURE_GOODSNAMERF)
                 && (frePEstFmDetail1.DPURE_GOODSNAMEKANARF == frePEstFmDetail2.DPURE_GOODSNAMEKANARF)
                 && (frePEstFmDetail1.DPURE_BLGOODSCODERF == frePEstFmDetail2.DPURE_BLGOODSCODERF)
                 && (frePEstFmDetail1.DPURE_SALESUNPRCTAXINCFLRF == frePEstFmDetail2.DPURE_SALESUNPRCTAXINCFLRF)
                 && (frePEstFmDetail1.DPURE_SALESUNPRCTAXEXCFLRF == frePEstFmDetail2.DPURE_SALESUNPRCTAXEXCFLRF)
                 && (frePEstFmDetail1.DPURE_LISTPRICETAXINCFLRF == frePEstFmDetail2.DPURE_LISTPRICETAXINCFLRF)
                 && (frePEstFmDetail1.DPURE_LISTPRICETAXEXCFLRF == frePEstFmDetail2.DPURE_LISTPRICETAXEXCFLRF)
                 && (frePEstFmDetail1.DPURE_SALESMONEYTAXINCRF == frePEstFmDetail2.DPURE_SALESMONEYTAXINCRF)
                 && (frePEstFmDetail1.DPURE_SALESMONEYTAXEXCRF == frePEstFmDetail2.DPURE_SALESMONEYTAXEXCRF)
                 && (frePEstFmDetail1.DPURE_TAXATIONDIVCDRF == frePEstFmDetail2.DPURE_TAXATIONDIVCDRF)
                 && (frePEstFmDetail1.DPURE_SALESUNPRCFLRF == frePEstFmDetail2.DPURE_SALESUNPRCFLRF)
                 && (frePEstFmDetail1.DPURE_LISTPRICERF == frePEstFmDetail2.DPURE_LISTPRICERF)
                 && (frePEstFmDetail1.DPURE_SHIPMENTCNTRF == frePEstFmDetail2.DPURE_SHIPMENTCNTRF)
                 && (frePEstFmDetail1.DPURE_SALESMONEYRF == frePEstFmDetail2.DPURE_SALESMONEYRF)
                 && (frePEstFmDetail1.DPRIM_GOODSMAKERCDRF == frePEstFmDetail2.DPRIM_GOODSMAKERCDRF)
                 && (frePEstFmDetail1.DPRIM_MAKERNAMERF == frePEstFmDetail2.DPRIM_MAKERNAMERF)
                 && (frePEstFmDetail1.DPRIM_MAKERKANANAMERF == frePEstFmDetail2.DPRIM_MAKERKANANAMERF)
                 && (frePEstFmDetail1.DPRIM_GOODSNORF == frePEstFmDetail2.DPRIM_GOODSNORF)
                 && (frePEstFmDetail1.DPRIM_GOODSNAMERF == frePEstFmDetail2.DPRIM_GOODSNAMERF)
                 && (frePEstFmDetail1.DPRIM_GOODSNAMEKANARF == frePEstFmDetail2.DPRIM_GOODSNAMEKANARF)
                 && (frePEstFmDetail1.DPRIM_BLGOODSCODERF == frePEstFmDetail2.DPRIM_BLGOODSCODERF)
                 && (frePEstFmDetail1.DPRIM_SALESUNPRCTAXINCFLRF == frePEstFmDetail2.DPRIM_SALESUNPRCTAXINCFLRF)
                 && (frePEstFmDetail1.DPRIM_SALESUNPRCTAXEXCFLRF == frePEstFmDetail2.DPRIM_SALESUNPRCTAXEXCFLRF)
                 && (frePEstFmDetail1.DPRIM_LISTPRICETAXINCFLRF == frePEstFmDetail2.DPRIM_LISTPRICETAXINCFLRF)
                 && (frePEstFmDetail1.DPRIM_LISTPRICETAXEXCFLRF == frePEstFmDetail2.DPRIM_LISTPRICETAXEXCFLRF)
                 && (frePEstFmDetail1.DPRIM_SALESMONEYTAXINCRF == frePEstFmDetail2.DPRIM_SALESMONEYTAXINCRF)
                 && (frePEstFmDetail1.DPRIM_SALESMONEYTAXEXCRF == frePEstFmDetail2.DPRIM_SALESMONEYTAXEXCRF)
                 && (frePEstFmDetail1.DPRIM_TAXATIONDIVCDRF == frePEstFmDetail2.DPRIM_TAXATIONDIVCDRF)
                 && (frePEstFmDetail1.DPRIM_SALESUNPRCFLRF == frePEstFmDetail2.DPRIM_SALESUNPRCFLRF)
                 && (frePEstFmDetail1.DPRIM_LISTPRICERF == frePEstFmDetail2.DPRIM_LISTPRICERF)
                 && (frePEstFmDetail1.DPRIM_SHIPMENTCNTRF == frePEstFmDetail2.DPRIM_SHIPMENTCNTRF)
                 && (frePEstFmDetail1.DPRIM_SALESMONEYRF == frePEstFmDetail2.DPRIM_SALESMONEYRF)
                 && (frePEstFmDetail1.DADD_SPECIALNOTE == frePEstFmDetail2.DADD_SPECIALNOTE));
        }
        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�FrePEstFmDetail�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePEstFmDetail�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( FrePEstFmDetail target )
        {
            ArrayList resList = new ArrayList();
            if ( this.SALESDETAILRF_SALESSLIPNUMRF != target.SALESDETAILRF_SALESSLIPNUMRF ) resList.Add( "SALESDETAILRF_SALESSLIPNUMRF" );
            if ( this.SALESDETAILRF_SALESROWNORF != target.SALESDETAILRF_SALESROWNORF ) resList.Add( "SALESDETAILRF_SALESROWNORF" );
            if ( this.DPURE_GOODSMAKERCDRF != target.DPURE_GOODSMAKERCDRF ) resList.Add( "DPURE_GOODSMAKERCDRF" );
            if ( this.DPURE_MAKERNAMERF != target.DPURE_MAKERNAMERF ) resList.Add( "DPURE_MAKERNAMERF" );
            if ( this.DPURE_MAKERKANANAMERF != target.DPURE_MAKERKANANAMERF ) resList.Add( "DPURE_MAKERKANANAMERF" );
            if ( this.DPURE_GOODSNORF != target.DPURE_GOODSNORF ) resList.Add( "DPURE_GOODSNORF" );
            if ( this.DPURE_GOODSNAMERF != target.DPURE_GOODSNAMERF ) resList.Add( "DPURE_GOODSNAMERF" );
            if ( this.DPURE_GOODSNAMEKANARF != target.DPURE_GOODSNAMEKANARF ) resList.Add( "DPURE_GOODSNAMEKANARF" );
            if ( this.DPURE_BLGOODSCODERF != target.DPURE_BLGOODSCODERF ) resList.Add( "DPURE_BLGOODSCODERF" );
            if ( this.DPURE_SALESUNPRCTAXINCFLRF != target.DPURE_SALESUNPRCTAXINCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXINCFLRF" );
            if ( this.DPURE_SALESUNPRCTAXEXCFLRF != target.DPURE_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXEXCFLRF" );
            if ( this.DPURE_LISTPRICETAXINCFLRF != target.DPURE_LISTPRICETAXINCFLRF ) resList.Add( "DPURE_LISTPRICETAXINCFLRF" );
            if ( this.DPURE_LISTPRICETAXEXCFLRF != target.DPURE_LISTPRICETAXEXCFLRF ) resList.Add( "DPURE_LISTPRICETAXEXCFLRF" );
            if ( this.DPURE_SALESMONEYTAXINCRF != target.DPURE_SALESMONEYTAXINCRF ) resList.Add( "DPURE_SALESMONEYTAXINCRF" );
            if ( this.DPURE_SALESMONEYTAXEXCRF != target.DPURE_SALESMONEYTAXEXCRF ) resList.Add( "DPURE_SALESMONEYTAXEXCRF" );
            if ( this.DPURE_TAXATIONDIVCDRF != target.DPURE_TAXATIONDIVCDRF ) resList.Add( "DPURE_TAXATIONDIVCDRF" );
            if ( this.DPURE_SALESUNPRCFLRF != target.DPURE_SALESUNPRCFLRF ) resList.Add( "DPURE_SALESUNPRCFLRF" );
            if ( this.DPURE_LISTPRICERF != target.DPURE_LISTPRICERF ) resList.Add( "DPURE_LISTPRICERF" );
            if ( this.DPURE_SHIPMENTCNTRF != target.DPURE_SHIPMENTCNTRF ) resList.Add( "DPURE_SHIPMENTCNTRF" );
            if ( this.DPURE_SALESMONEYRF != target.DPURE_SALESMONEYRF ) resList.Add( "DPURE_SALESMONEYRF" );
            if ( this.DPRIM_GOODSMAKERCDRF != target.DPRIM_GOODSMAKERCDRF ) resList.Add( "DPRIM_GOODSMAKERCDRF" );
            if ( this.DPRIM_MAKERNAMERF != target.DPRIM_MAKERNAMERF ) resList.Add( "DPRIM_MAKERNAMERF" );
            if ( this.DPRIM_MAKERKANANAMERF != target.DPRIM_MAKERKANANAMERF ) resList.Add( "DPRIM_MAKERKANANAMERF" );
            if ( this.DPRIM_GOODSNORF != target.DPRIM_GOODSNORF ) resList.Add( "DPRIM_GOODSNORF" );
            if ( this.DPRIM_GOODSNAMERF != target.DPRIM_GOODSNAMERF ) resList.Add( "DPRIM_GOODSNAMERF" );
            if ( this.DPRIM_GOODSNAMEKANARF != target.DPRIM_GOODSNAMEKANARF ) resList.Add( "DPRIM_GOODSNAMEKANARF" );
            if ( this.DPRIM_BLGOODSCODERF != target.DPRIM_BLGOODSCODERF ) resList.Add( "DPRIM_BLGOODSCODERF" );
            if ( this.DPRIM_SALESUNPRCTAXINCFLRF != target.DPRIM_SALESUNPRCTAXINCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXINCFLRF" );
            if ( this.DPRIM_SALESUNPRCTAXEXCFLRF != target.DPRIM_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXEXCFLRF" );
            if ( this.DPRIM_LISTPRICETAXINCFLRF != target.DPRIM_LISTPRICETAXINCFLRF ) resList.Add( "DPRIM_LISTPRICETAXINCFLRF" );
            if ( this.DPRIM_LISTPRICETAXEXCFLRF != target.DPRIM_LISTPRICETAXEXCFLRF ) resList.Add( "DPRIM_LISTPRICETAXEXCFLRF" );
            if ( this.DPRIM_SALESMONEYTAXINCRF != target.DPRIM_SALESMONEYTAXINCRF ) resList.Add( "DPRIM_SALESMONEYTAXINCRF" );
            if ( this.DPRIM_SALESMONEYTAXEXCRF != target.DPRIM_SALESMONEYTAXEXCRF ) resList.Add( "DPRIM_SALESMONEYTAXEXCRF" );
            if ( this.DPRIM_TAXATIONDIVCDRF != target.DPRIM_TAXATIONDIVCDRF ) resList.Add( "DPRIM_TAXATIONDIVCDRF" );
            if ( this.DPRIM_SALESUNPRCFLRF != target.DPRIM_SALESUNPRCFLRF ) resList.Add( "DPRIM_SALESUNPRCFLRF" );
            if ( this.DPRIM_LISTPRICERF != target.DPRIM_LISTPRICERF ) resList.Add( "DPRIM_LISTPRICERF" );
            if ( this.DPRIM_SHIPMENTCNTRF != target.DPRIM_SHIPMENTCNTRF ) resList.Add( "DPRIM_SHIPMENTCNTRF" );
            if ( this.DPRIM_SALESMONEYRF != target.DPRIM_SALESMONEYRF ) resList.Add( "DPRIM_SALESMONEYRF" );
            if ( this.DADD_SPECIALNOTE != target.DADD_SPECIALNOTE ) resList.Add( "DADD_SPECIALNOTE" );

            return resList;
        }

        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^��r����
        /// </summary>
        /// <param name="frePEstFmDetail1">��r����FrePEstFmDetail�N���X�̃C���X�^���X</param>
        /// <param name="frePEstFmDetail2">��r����FrePEstFmDetail�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePEstFmDetail�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( FrePEstFmDetail frePEstFmDetail1, FrePEstFmDetail frePEstFmDetail2 )
        {
            ArrayList resList = new ArrayList();
            if ( frePEstFmDetail1.SALESDETAILRF_SALESSLIPNUMRF != frePEstFmDetail2.SALESDETAILRF_SALESSLIPNUMRF ) resList.Add( "SALESDETAILRF_SALESSLIPNUMRF" );
            if ( frePEstFmDetail1.SALESDETAILRF_SALESROWNORF != frePEstFmDetail2.SALESDETAILRF_SALESROWNORF ) resList.Add( "SALESDETAILRF_SALESROWNORF" );
            if ( frePEstFmDetail1.DPURE_GOODSMAKERCDRF != frePEstFmDetail2.DPURE_GOODSMAKERCDRF ) resList.Add( "DPURE_GOODSMAKERCDRF" );
            if ( frePEstFmDetail1.DPURE_MAKERNAMERF != frePEstFmDetail2.DPURE_MAKERNAMERF ) resList.Add( "DPURE_MAKERNAMERF" );
            if ( frePEstFmDetail1.DPURE_MAKERKANANAMERF != frePEstFmDetail2.DPURE_MAKERKANANAMERF ) resList.Add( "DPURE_MAKERKANANAMERF" );
            if ( frePEstFmDetail1.DPURE_GOODSNORF != frePEstFmDetail2.DPURE_GOODSNORF ) resList.Add( "DPURE_GOODSNORF" );
            if ( frePEstFmDetail1.DPURE_GOODSNAMERF != frePEstFmDetail2.DPURE_GOODSNAMERF ) resList.Add( "DPURE_GOODSNAMERF" );
            if ( frePEstFmDetail1.DPURE_GOODSNAMEKANARF != frePEstFmDetail2.DPURE_GOODSNAMEKANARF ) resList.Add( "DPURE_GOODSNAMEKANARF" );
            if ( frePEstFmDetail1.DPURE_BLGOODSCODERF != frePEstFmDetail2.DPURE_BLGOODSCODERF ) resList.Add( "DPURE_BLGOODSCODERF" );
            if ( frePEstFmDetail1.DPURE_SALESUNPRCTAXINCFLRF != frePEstFmDetail2.DPURE_SALESUNPRCTAXINCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXINCFLRF" );
            if ( frePEstFmDetail1.DPURE_SALESUNPRCTAXEXCFLRF != frePEstFmDetail2.DPURE_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPURE_SALESUNPRCTAXEXCFLRF" );
            if ( frePEstFmDetail1.DPURE_LISTPRICETAXINCFLRF != frePEstFmDetail2.DPURE_LISTPRICETAXINCFLRF ) resList.Add( "DPURE_LISTPRICETAXINCFLRF" );
            if ( frePEstFmDetail1.DPURE_LISTPRICETAXEXCFLRF != frePEstFmDetail2.DPURE_LISTPRICETAXEXCFLRF ) resList.Add( "DPURE_LISTPRICETAXEXCFLRF" );
            if ( frePEstFmDetail1.DPURE_SALESMONEYTAXINCRF != frePEstFmDetail2.DPURE_SALESMONEYTAXINCRF ) resList.Add( "DPURE_SALESMONEYTAXINCRF" );
            if ( frePEstFmDetail1.DPURE_SALESMONEYTAXEXCRF != frePEstFmDetail2.DPURE_SALESMONEYTAXEXCRF ) resList.Add( "DPURE_SALESMONEYTAXEXCRF" );
            if ( frePEstFmDetail1.DPURE_TAXATIONDIVCDRF != frePEstFmDetail2.DPURE_TAXATIONDIVCDRF ) resList.Add( "DPURE_TAXATIONDIVCDRF" );
            if ( frePEstFmDetail1.DPURE_SALESUNPRCFLRF != frePEstFmDetail2.DPURE_SALESUNPRCFLRF ) resList.Add( "DPURE_SALESUNPRCFLRF" );
            if ( frePEstFmDetail1.DPURE_LISTPRICERF != frePEstFmDetail2.DPURE_LISTPRICERF ) resList.Add( "DPURE_LISTPRICERF" );
            if ( frePEstFmDetail1.DPURE_SHIPMENTCNTRF != frePEstFmDetail2.DPURE_SHIPMENTCNTRF ) resList.Add( "DPURE_SHIPMENTCNTRF" );
            if ( frePEstFmDetail1.DPURE_SALESMONEYRF != frePEstFmDetail2.DPURE_SALESMONEYRF ) resList.Add( "DPURE_SALESMONEYRF" );
            if ( frePEstFmDetail1.DPRIM_GOODSMAKERCDRF != frePEstFmDetail2.DPRIM_GOODSMAKERCDRF ) resList.Add( "DPRIM_GOODSMAKERCDRF" );
            if ( frePEstFmDetail1.DPRIM_MAKERNAMERF != frePEstFmDetail2.DPRIM_MAKERNAMERF ) resList.Add( "DPRIM_MAKERNAMERF" );
            if ( frePEstFmDetail1.DPRIM_MAKERKANANAMERF != frePEstFmDetail2.DPRIM_MAKERKANANAMERF ) resList.Add( "DPRIM_MAKERKANANAMERF" );
            if ( frePEstFmDetail1.DPRIM_GOODSNORF != frePEstFmDetail2.DPRIM_GOODSNORF ) resList.Add( "DPRIM_GOODSNORF" );
            if ( frePEstFmDetail1.DPRIM_GOODSNAMERF != frePEstFmDetail2.DPRIM_GOODSNAMERF ) resList.Add( "DPRIM_GOODSNAMERF" );
            if ( frePEstFmDetail1.DPRIM_GOODSNAMEKANARF != frePEstFmDetail2.DPRIM_GOODSNAMEKANARF ) resList.Add( "DPRIM_GOODSNAMEKANARF" );
            if ( frePEstFmDetail1.DPRIM_BLGOODSCODERF != frePEstFmDetail2.DPRIM_BLGOODSCODERF ) resList.Add( "DPRIM_BLGOODSCODERF" );
            if ( frePEstFmDetail1.DPRIM_SALESUNPRCTAXINCFLRF != frePEstFmDetail2.DPRIM_SALESUNPRCTAXINCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXINCFLRF" );
            if ( frePEstFmDetail1.DPRIM_SALESUNPRCTAXEXCFLRF != frePEstFmDetail2.DPRIM_SALESUNPRCTAXEXCFLRF ) resList.Add( "DPRIM_SALESUNPRCTAXEXCFLRF" );
            if ( frePEstFmDetail1.DPRIM_LISTPRICETAXINCFLRF != frePEstFmDetail2.DPRIM_LISTPRICETAXINCFLRF ) resList.Add( "DPRIM_LISTPRICETAXINCFLRF" );
            if ( frePEstFmDetail1.DPRIM_LISTPRICETAXEXCFLRF != frePEstFmDetail2.DPRIM_LISTPRICETAXEXCFLRF ) resList.Add( "DPRIM_LISTPRICETAXEXCFLRF" );
            if ( frePEstFmDetail1.DPRIM_SALESMONEYTAXINCRF != frePEstFmDetail2.DPRIM_SALESMONEYTAXINCRF ) resList.Add( "DPRIM_SALESMONEYTAXINCRF" );
            if ( frePEstFmDetail1.DPRIM_SALESMONEYTAXEXCRF != frePEstFmDetail2.DPRIM_SALESMONEYTAXEXCRF ) resList.Add( "DPRIM_SALESMONEYTAXEXCRF" );
            if ( frePEstFmDetail1.DPRIM_TAXATIONDIVCDRF != frePEstFmDetail2.DPRIM_TAXATIONDIVCDRF ) resList.Add( "DPRIM_TAXATIONDIVCDRF" );
            if ( frePEstFmDetail1.DPRIM_SALESUNPRCFLRF != frePEstFmDetail2.DPRIM_SALESUNPRCFLRF ) resList.Add( "DPRIM_SALESUNPRCFLRF" );
            if ( frePEstFmDetail1.DPRIM_LISTPRICERF != frePEstFmDetail2.DPRIM_LISTPRICERF ) resList.Add( "DPRIM_LISTPRICERF" );
            if ( frePEstFmDetail1.DPRIM_SHIPMENTCNTRF != frePEstFmDetail2.DPRIM_SHIPMENTCNTRF ) resList.Add( "DPRIM_SHIPMENTCNTRF" );
            if ( frePEstFmDetail1.DPRIM_SALESMONEYRF != frePEstFmDetail2.DPRIM_SALESMONEYRF ) resList.Add( "DPRIM_SALESMONEYRF" );
            if ( frePEstFmDetail1.DADD_SPECIALNOTE != frePEstFmDetail2.DADD_SPECIALNOTE ) resList.Add( "DADD_SPECIALNOTE" );

            return resList;
        }
    }
}
