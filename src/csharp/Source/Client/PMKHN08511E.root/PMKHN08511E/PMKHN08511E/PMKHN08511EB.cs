using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   WarehouseSet
    /// <summary>
    ///                      �q�Ƀ}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �q�Ƀ}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class WarehousePrintSet
    {
        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>��Ǒq�ɃR�[�h</summary>
        /// <remarks>�ϑ��̏ꍇ�ɍ݌ɕ�[���s�����̑q��</remarks>
        private string _mainMngWarehouseCd = "";

        /// <summary>��Ǒq�ɖ���</summary>
        private string _mainWarehouseName = "";

        /// <summary>�݌Ɉꊇ���}�[�N</summary>
        /// <remarks>�݌Ɉꊇ�����̎��Ɏg�p�i�R���{�T���g�p�j</remarks>
        private string _stockBlnktRemark = "";


        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
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

        /// public propaty name  :  MainMngWarehouseCd
        /// <summary>��Ǒq�ɃR�[�h�v���p�e�B</summary>
        /// <value>�ϑ��̏ꍇ�ɍ݌ɕ�[���s�����̑q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ǒq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainMngWarehouseCd
        {
            get { return _mainMngWarehouseCd; }
            set { _mainMngWarehouseCd = value; }
        }

        /// public propaty name  :  MainWarehouseName
        /// <summary>��Ǒq�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ǒq�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainWarehouseName
        {
            get { return _mainWarehouseName; }
            set { _mainWarehouseName = value; }
        }

        /// public propaty name  :  StockBlnktRemark
        /// <summary>�݌Ɉꊇ���}�[�N�v���p�e�B</summary>
        /// <value>�݌Ɉꊇ�����̎��Ɏg�p�i�R���{�T���g�p�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉꊇ���}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }

        /// <summary>
        /// �q�ɏ��i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public WarehousePrintSet Clone()
        {
            return new WarehousePrintSet(this._warehouseCode, this._warehouseName, this._sectionCode, this._sectionGuideNm, this._customerCode, this._customerSnm, this._mainMngWarehouseCd, this._mainWarehouseName, this._stockBlnktRemark);

        }

        /// <summary>
        /// �q�ɏ��i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>WarehouseSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   WarehouseSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public WarehousePrintSet()
        {
        }

        /// <summary>
        /// �q�ɏ��i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="WarehouseCode"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="MainMngWarehouseCd"></param>
        /// <param name="MainWarehouseName"></param>
        /// <param name="stockBlnktRemark"></param>
        public WarehousePrintSet(string WarehouseCode, string WarehouseName, string SectionCode, string SectionGuideNm, Int32 CustomerCode, string CustomerSnm, string MainMngWarehouseCd, string MainWarehouseName, string stockBlnktRemark)
        {
            this._warehouseCode = WarehouseCode;
            this._warehouseName = WarehouseName;
            this._sectionCode = SectionCode;
            this._sectionGuideNm = SectionGuideNm;
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._mainMngWarehouseCd = MainMngWarehouseCd;
            this._mainWarehouseName = MainWarehouseName;
            this._stockBlnktRemark = stockBlnktRemark;
        }
    }
}
