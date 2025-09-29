using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockAcPayHisSearchParaWork
    /// <summary>
    ///                      �݌Ɏ󕥗������������N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɏ󕥗������������N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/23  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// <br>UpdateNote       :   2013/01/15 FSI���� �G�@�Ǘ�No.541 ���|�I�v�V�����ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockAcPayHisSearchParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>�J�n���o�ד�</summary>
        private Int32 _st_IoGoodsDay;

        /// <summary>�I�����o�ד�</summary>
        private Int32 _ed_IoGoodsDay;

        /// <summary>�J�n�v����t</summary>
        private Int32 _st_AddUpADate;

        /// <summary>�I���v����t</summary>
        private Int32 _ed_AddUpADate;

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��(���̕ύX 11:���->���ׁ@22:�ϑ�->�o�ׁj</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>�J�n�q�ɃR�[�h</summary>
        /// <remarks>�o�ׁA���ׂ���������q��</remarks>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        /// <remarks>�o�ׁA���ׂ���������q��</remarks>
        private string _ed_WarehouseCode = "";

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        /// <remarks>�񋟔͈͂̓v���_�N�g���Œ�`</remarks>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        /// <remarks>�񋟔͈͂̓v���_�N�g���Œ�`</remarks>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�n�󕥌��`�[�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</remarks>
        private string _st_AcPaySlipNum = "";

        /// <summary>�I���󕥌��`�[�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</remarks>
        private string _ed_AcPaySlipNum = "";

        /// <summary>�J�n���i�ԍ�</summary>
        private string _st_GoodsNo = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _ed_GoodsNo = "";

        /// <summary>�����J�n�N��</summary>
        /// <remarks>�O���J�n�N�� YYYYMM</remarks>
        private Int32 _st_HisYearMonth;

        /// <summary>�󕥊J�n�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_AcPayDate;

        // ---ADD 2010/11/15 ------------------------>>>>>
        /// <summary>
        /// ���͓�(�J�n)
        /// </summary>
        private DateTime _st_detInputDay;

        /// <summary>
        /// ���͓�(�I��)
        /// </summary>
        private DateTime _ed_detInputDay;

        /// <summary>
        /// ���v��
        /// </summary>
        private int _groupCnt;

        /// <summary>
        /// �o�͏�
        /// </summary>
        private int _sort;

        /// <summary>
        /// �`�[�ԍ�(�J�n)
        /// </summary>
        private string _st_slipNum = "";

        /// <summary>
        /// �`�[�ԍ�(�I��)
        /// </summary>
        private string _ed_slipNum = "";

        /// <summary>
        /// �`�[�敪
        /// </summary>
        private int _slipKuben;
        // ---ADD 2010/11/15 ------------------------<<<<<

        // ---ADD 2013/01/15 ------------------------>>>>>
        /// <summary>
        /// ���|�I�v�V����
        /// </summary>
        private bool _hasStkPay;
        // ---ADD 2013/01/15 ------------------------<<<<<

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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>(�z��)�@�S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  St_IoGoodsDay
        /// <summary>�J�n���o�ד��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���o�ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_IoGoodsDay
        {
            get { return _st_IoGoodsDay; }
            set { _st_IoGoodsDay = value; }
        }

        /// public propaty name  :  Ed_IoGoodsDay
        /// <summary>�I�����o�ד��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����o�ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_IoGoodsDay
        {
            get { return _ed_IoGoodsDay; }
            set { _ed_IoGoodsDay = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>�J�n�v����t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>�I���v����t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��(���̕ύX 11:���->���ׁ@22:�ϑ�->�o�ׁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�o�ׁA���ׂ���������q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�o�ׁA���ׂ���������q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�񋟔͈͂̓v���_�N�g���Œ�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�񋟔͈͂̓v���_�N�g���Œ�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_AcPaySlipNum
        /// <summary>�J�n�󕥌��`�[�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�󕥌��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_AcPaySlipNum
        {
            get { return _st_AcPaySlipNum; }
            set { _st_AcPaySlipNum = value; }
        }

        /// public propaty name  :  Ed_AcPaySlipNum
        /// <summary>�I���󕥌��`�[�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���󕥌��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_AcPaySlipNum
        {
            get { return _ed_AcPaySlipNum; }
            set { _ed_AcPaySlipNum = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  St_HisYearMonth
        /// <summary>�����J�n�N���v���p�e�B</summary>
        /// <value>�O���J�n�N�� YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����J�n�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_HisYearMonth
        {
            get { return _st_HisYearMonth; }
            set { _st_HisYearMonth = value; }
        }

        /// public propaty name  :  St_AcPayDate
        /// <summary>�󕥊J�n�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥊J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_AcPayDate
        {
            get { return _st_AcPayDate; }
            set { _st_AcPayDate = value; }
        }

        // ---ADD 2010/11/15 ------------------------>>>>>
        /// <summary>
        /// ���͓�(�J�n)�v���p�e�B
        /// </summary>
        public DateTime St_detInputDay
        {
            get { return this._st_detInputDay; }
            set { this._st_detInputDay = value; }
        }

        /// <summary>
        /// ���͓�(�I��)�v���p�e�B
        /// </summary>
        public DateTime Ed_detInputDay
        {
            get { return this._ed_detInputDay; }
            set { this._ed_detInputDay = value; }
        }

        /// <summary>
        /// ���v�󎚃v���p�e�B
        /// </summary>
        public int GroupCnt
        {
            get { return this._groupCnt; }
            set { this._groupCnt = value; }
        }

        /// <summary>
        /// �o�͏��v���p�e�B
        /// </summary>
        public int Sort
        {
            get { return this._sort; }
            set { this._sort = value; }
        }

        /// <summary>
        /// �`�[�ԍ�(�J�n)�v���p�e�B
        /// </summary>
        public string St_slipNum
        {
            get { return this._st_slipNum; }
            set { this._st_slipNum = value; }
        }

        /// <summary>
        /// �`�[�ԍ�(�I��)�v���p�e�B
        /// </summary>
        public string Ed_slipNum
        {
            get { return this._ed_slipNum; }
            set { this._ed_slipNum = value; }
        }

        /// <summary>
        /// �`�[�敪�v���p�e�B
        /// </summary>
        public int SlipKuben
        {
            get { return this._slipKuben; }
            set { this._slipKuben = value; }
        }
        // ---ADD 2010/11/15 ------------------------<<<<<

        // ---ADD 2013/01/15 ------------------------>>>>>
        /// <summary>
        /// ���|�I�v�V�����v���p�e�B
        /// </summary>
        public bool HasStkPay
        {
            get { return this._hasStkPay; }
            set { this._hasStkPay = value; }
        }
        // ---ADD 2013/01/15 ------------------------<<<<<

        /// <summary>
        /// �݌Ɏ󕥗������������N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockAcPayHisSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAcPayHisSearchParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockAcPayHisSearchParaWork()
        {
        }

    }

}
