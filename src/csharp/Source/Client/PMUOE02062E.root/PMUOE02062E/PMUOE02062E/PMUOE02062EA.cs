using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   EnterSchOrderCndtn
	/// <summary>
	///                      ���ɗ\��\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���ɗ\��\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/03  (CSharp File Generated Date)</br>
    /// <br>Note             :   �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// <br>Programmer       :   杍^</br>
    /// <br>Date             :   2017/09/14</br>
	/// </remarks>
    public class EnterSchOrderCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�I�v�V���������敪</summary>
        private bool _isOptSection;

        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        private bool _isMainOfficeFunc;

        /// <summary>���_�R�[�h�i�����w��j</summary>
        private string[] _sectionCodes;

        /// <summary>�J�nUOE������R�[�h</summary>
        private Int32 _st_UOESupplierCd;

        /// <summary>�I��UOE������R�[�h</summary>
        private Int32 _ed_UOESupplierCd;

        /// <summary>������R�[�h�w��(�����w��)</summary>
        /// <remarks>null�̏ꍇ�́A�J�n�I���͈͎w����g�p</remarks>
        private Int32[] _uOESupplierCds;

        /// <summary>�J�n��M���t</summary>
        private DateTime _st_ReceiveDate;

        /// <summary>�I����M���t</summary>
        private DateTime _ed_ReceiveDate;

        /// <summary>����^�C�v</summary>
        /// <remarks>0:���ɕ��̂� 1:���[�J�[�t�H���[���̂݁@2:���i���̂�</remarks>
        private Int32 _printTypeCndtn;

        /// <summary>�o�͏�</summary>
        private Int32 _sortOrderDiv;

        /// <summary>����</summary>
        private Int32 _newPageDiv;

        /// <summary>�����撊�o����</summary>
        private int _supplierExtra;

        /// <summary>���[�^�C�v�敪</summary>
        private int _printDiv;

        /// <summary>���[�^�C�v�敪����</summary>
        private string _printDivName = string.Empty;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary>�o�[�R�[�h�󎚋敪</summary>
        private int _barCodeShowDiv;
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

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

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�I�v�V���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�Ћ@�\�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>�S�БI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S�БI���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._sectionCodes.Length == 1) && (this._sectionCodes[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  St_UOESupplierCd
        /// <summary>�J�nUOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nUOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_UOESupplierCd
        {
            get { return _st_UOESupplierCd; }
            set { _st_UOESupplierCd = value; }
        }

        /// public propaty name  :  Ed_UOESupplierCd
        /// <summary>�I��UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_UOESupplierCd
        {
            get { return _ed_UOESupplierCd; }
            set { _ed_UOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCds
        /// <summary>������R�[�h�w��(�����w��)�v���p�e�B</summary>
        /// <value>null�̏ꍇ�́A�J�n�I���͈͎w����g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�w��(�����w��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] UOESupplierCds
        {
            get { return _uOESupplierCds; }
            set { _uOESupplierCds = value; }
        }

        /// public propaty name  :  St_ReceiveDate
        /// <summary>�J�n��M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n��M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>�I����M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I����M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  PrintTypeCndtn
        /// <summary>����^�C�v�v���p�e�B</summary>
        /// <value>0:���ɕ��̂� 1:���[�J�[�t�H���[���̂݁@2:���i���̂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintTypeCndtn
        {
            get { return _printTypeCndtn; }
            set { _printTypeCndtn = value; }
        }

        /// public propaty name  :  SortOrderDiv
        /// <summary>�o�͏��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͏��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SortOrderDiv
        {
            get { return _sortOrderDiv; }
            set { _sortOrderDiv = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>���Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  SupplierExtra
        /// <summary>�����撊�o�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����撊�o�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierExtra
        {
            get { return this._supplierExtra; }
            set { this._supplierExtra = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>���[�^�C�v�敪�v���p�e�B</summary>
        /// <value>�ݒ�̗p�r�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>���[�^�C�v�敪�v���p�e�B����(�ǂݎ���p)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
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

        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// public propaty name  :  BarCodeShowDiv
        /// <summary>�o�[�R�[�h�󎚋敪�v���p�e�B</summary>
        /// <value>�ݒ�̗p�r�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�[�R�[�h�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int BarCodeShowDiv
        {
            get { return _barCodeShowDiv; }
            set { _barCodeShowDiv = value; }
        }
        // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        /// <summary>
        /// ���ɗ\��\���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>EnterSchOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EnterSchOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EnterSchOrderCndtn()
        {
        }
    }
}
