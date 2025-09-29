using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAcPayListCndtn
	/// <summary>
	///                      �݌Ɏ󕥊m�F�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɏ󕥊m�F�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/13  (CSharp File Generated Date)</br>
    /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// </remarks>
	public class StockAcPayListCndtn
	{
        # region �� private field ��

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�L���敪</summary>
        /// <remarks>0:�L�� 1:�����i�C���O���͍폜�j</remarks>
        private Int32 _validDivCd;

        /// <summary>�J�n���o�ד�</summary>
        private DateTime _st_IoGoodsDay;

        /// <summary>�I�����o�ד�</summary>
        private DateTime _ed_IoGoodsDay;

        /// <summary>�J�n�v����t</summary>
        /// <remarks>�i�\�����ځj</remarks>
        private DateTime _st_AddUpADate;

        /// <summary>�I���v����t</summary>
        /// <remarks>�i�\�����ځj</remarks>
        private DateTime _ed_AddUpADate;

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>-1:�S��,10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>���_�R�[�h�i�����w��j</summary>
        /// <remarks>�i���z��j�o�ׁA���ׂ��������鋒�_</remarks>
        private string[] _sectionCodes = new string[0];

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

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        # endregion  �� private field ��

        # region �� public propaty ��

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

        /// public propaty name  :  ValidDivCd
        /// <summary>�L���敪�v���p�e�B</summary>
        /// <value>0:�L�� 1:�����i�C���O���͍폜�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ValidDivCd
        {
            get { return _validDivCd; }
            set { _validDivCd = value; }
        }

        /// public propaty name  :  St_IoGoodsDay
        /// <summary>�J�n���o�ד��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���o�ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_IoGoodsDay
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
        public DateTime Ed_IoGoodsDay
        {
            get { return _ed_IoGoodsDay; }
            set { _ed_IoGoodsDay = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>�J�n�v����t�v���p�e�B</summary>
        /// <value>�i�\�����ځj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>�I���v����t�v���p�e�B</summary>
        /// <value>�i�\�����ځj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>-1:�S��,10:�d��,11:����,12:��v��,20:����,21:���v��,22:�o��,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,50:�I��</value>
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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i���z��j�o�ׁA���ׂ��������鋒�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
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

        # endregion �� public propaty ��

        # region �� private field (���������ȊO) ��
        /// <summary>
        /// ���_�I�v�V�����敪
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// �S���_�I���敪
        /// </summary>
        private bool _isSelectAllSection = false;
        //--- ADD 2008/07/02 ---------->>>>>
        /// <summary>
        /// ���ŏ��
        /// </summary>
        private int _changePage;
        //--- ADD 2008/07/02 ----------<<<<<

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
        # endregion �� private field (���������ȊO) ��

        # region �� public propaty (���������ȊO) ��
        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }
        //--- ADD 2008/07/02 ---------->>>>>
        /// <summary>
        /// ���ŏ��v���p�e�B
        /// </summary>
        public int ChangePage
        {
            get { return this._changePage; }
            set { this._changePage = value; }
        }
        //--- ADD 2008/07/02 ----------<<<<<

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
        # endregion �� public propaty (���������ȊO) ��

        # region �� public Enum (���������ȊO) ��
        # endregion �� public Enum (���������ȊO) ��

        #region �� public const (���������ȊO) ��
        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>���� �S�� �R�[�h</summary>
        public const int ct_All_Code = -1;
        /// <summary>���� �S�� ����</summary>
        public const string ct_All_Name = "�S��";
        #endregion

        # region �� Constructor ��

        /// <summary>
        /// �݌Ɏ󕥊m�F�\�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>StockAcPayListCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAcPayListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockAcPayListCndtn ()
        {
        }
        # endregion �� Constructor ��
    }
}
