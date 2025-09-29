using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_SalesOrderRemainClear
    /// <summary>
    ///                      �����c�N���A���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����c�N���A���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ExtrInfo_SalesOrderRemainClear
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_SupplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>�J�n���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  St_WarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  St_SupplierCd
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
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


        /// <summary>
        /// �����c�N���A���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_SalesOrderRemainClear�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_SalesOrderRemainClear()
        {
        }

        /// <summary>
        /// �����c�N���A���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="st_WarehouseCode">�J�n�q�ɃR�[�h</param>
        /// <param name="ed_WarehouseCode">�I���q�ɃR�[�h</param>
        /// <param name="st_SupplierCd">�J�n�d����R�[�h</param>
        /// <param name="ed_SupplierCd">�I���d����R�[�h</param>
        /// <param name="st_GoodsMakerCd">�J�n���[�J�[�R�[�h</param>
        /// <param name="ed_GoodsMakerCd">�I�����[�J�[�R�[�h</param>
        /// <param name="st_BLGoodsCode">�J�nBL���i�R�[�h</param>
        /// <param name="ed_BLGoodsCode">�I��BL���i�R�[�h</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_SalesOrderRemainClear�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_SalesOrderRemainClear(string enterpriseCode, string st_WarehouseCode, string ed_WarehouseCode, Int32 st_SupplierCd, Int32 ed_SupplierCd, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, Int32 st_BLGoodsCode, Int32 ed_BLGoodsCode, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._st_WarehouseCode = st_WarehouseCode;
            this._ed_WarehouseCode = ed_WarehouseCode;
            this._st_SupplierCd = st_SupplierCd;
            this._ed_SupplierCd = ed_SupplierCd;
            this._st_GoodsMakerCd = st_GoodsMakerCd;
            this._ed_GoodsMakerCd = ed_GoodsMakerCd;
            this._st_BLGoodsCode = st_BLGoodsCode;
            this._ed_BLGoodsCode = ed_BLGoodsCode;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// �����c�N���A���o�����N���X��������
        /// </summary>
        /// <returns>ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_SalesOrderRemainClear Clone()
        {
            return new ExtrInfo_SalesOrderRemainClear(this._enterpriseCode, this._st_WarehouseCode, this._ed_WarehouseCode, this._st_SupplierCd, this._ed_SupplierCd, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._enterpriseName);
        }

        /// <summary>
        /// �����c�N���A���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_SalesOrderRemainClear�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(ExtrInfo_SalesOrderRemainClear target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.St_WarehouseCode == target.St_WarehouseCode)
                 && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
                 && (this.St_SupplierCd == target.St_SupplierCd)
                 && (this.Ed_SupplierCd == target.Ed_SupplierCd)
                 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
                 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �����c�N���A���o�����N���X��r����
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear1">
        ///                    ��r����ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X
        /// </param>
        /// <param name="extrInfo_SalesOrderRemainClear2">��r����ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_SalesOrderRemainClear�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear1, ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear2)
        {
            return ((extrInfo_SalesOrderRemainClear1.EnterpriseCode == extrInfo_SalesOrderRemainClear2.EnterpriseCode)
                 && (extrInfo_SalesOrderRemainClear1.St_WarehouseCode == extrInfo_SalesOrderRemainClear2.St_WarehouseCode)
                 && (extrInfo_SalesOrderRemainClear1.Ed_WarehouseCode == extrInfo_SalesOrderRemainClear2.Ed_WarehouseCode)
                 && (extrInfo_SalesOrderRemainClear1.St_SupplierCd == extrInfo_SalesOrderRemainClear2.St_SupplierCd)
                 && (extrInfo_SalesOrderRemainClear1.Ed_SupplierCd == extrInfo_SalesOrderRemainClear2.Ed_SupplierCd)
                 && (extrInfo_SalesOrderRemainClear1.St_GoodsMakerCd == extrInfo_SalesOrderRemainClear2.St_GoodsMakerCd)
                 && (extrInfo_SalesOrderRemainClear1.Ed_GoodsMakerCd == extrInfo_SalesOrderRemainClear2.Ed_GoodsMakerCd)
                 && (extrInfo_SalesOrderRemainClear1.St_BLGoodsCode == extrInfo_SalesOrderRemainClear2.St_BLGoodsCode)
                 && (extrInfo_SalesOrderRemainClear1.Ed_BLGoodsCode == extrInfo_SalesOrderRemainClear2.Ed_BLGoodsCode)
                 && (extrInfo_SalesOrderRemainClear1.EnterpriseName == extrInfo_SalesOrderRemainClear2.EnterpriseName));
        }
        /// <summary>
        /// �����c�N���A���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_SalesOrderRemainClear�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(ExtrInfo_SalesOrderRemainClear target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.St_WarehouseCode != target.St_WarehouseCode) resList.Add("St_WarehouseCode");
            if (this.Ed_WarehouseCode != target.Ed_WarehouseCode) resList.Add("Ed_WarehouseCode");
            if (this.St_SupplierCd != target.St_SupplierCd) resList.Add("St_SupplierCd");
            if (this.Ed_SupplierCd != target.Ed_SupplierCd) resList.Add("Ed_SupplierCd");
            if (this.St_GoodsMakerCd != target.St_GoodsMakerCd) resList.Add("St_GoodsMakerCd");
            if (this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd) resList.Add("Ed_GoodsMakerCd");
            if (this.St_BLGoodsCode != target.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (this.Ed_BLGoodsCode != target.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// �����c�N���A���o�����N���X��r����
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClear1">��r����ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</param>
        /// <param name="extrInfo_SalesOrderRemainClear2">��r����ExtrInfo_SalesOrderRemainClear�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_SalesOrderRemainClear�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear1, ExtrInfo_SalesOrderRemainClear extrInfo_SalesOrderRemainClear2)
        {
            ArrayList resList = new ArrayList();
            if (extrInfo_SalesOrderRemainClear1.EnterpriseCode != extrInfo_SalesOrderRemainClear2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (extrInfo_SalesOrderRemainClear1.St_WarehouseCode != extrInfo_SalesOrderRemainClear2.St_WarehouseCode) resList.Add("St_WarehouseCode");
            if (extrInfo_SalesOrderRemainClear1.Ed_WarehouseCode != extrInfo_SalesOrderRemainClear2.Ed_WarehouseCode) resList.Add("Ed_WarehouseCode");
            if (extrInfo_SalesOrderRemainClear1.St_SupplierCd != extrInfo_SalesOrderRemainClear2.St_SupplierCd) resList.Add("St_SupplierCd");
            if (extrInfo_SalesOrderRemainClear1.Ed_SupplierCd != extrInfo_SalesOrderRemainClear2.Ed_SupplierCd) resList.Add("Ed_SupplierCd");
            if (extrInfo_SalesOrderRemainClear1.St_GoodsMakerCd != extrInfo_SalesOrderRemainClear2.St_GoodsMakerCd) resList.Add("St_GoodsMakerCd");
            if (extrInfo_SalesOrderRemainClear1.Ed_GoodsMakerCd != extrInfo_SalesOrderRemainClear2.Ed_GoodsMakerCd) resList.Add("Ed_GoodsMakerCd");
            if (extrInfo_SalesOrderRemainClear1.St_BLGoodsCode != extrInfo_SalesOrderRemainClear2.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (extrInfo_SalesOrderRemainClear1.Ed_BLGoodsCode != extrInfo_SalesOrderRemainClear2.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (extrInfo_SalesOrderRemainClear1.EnterpriseName != extrInfo_SalesOrderRemainClear2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
