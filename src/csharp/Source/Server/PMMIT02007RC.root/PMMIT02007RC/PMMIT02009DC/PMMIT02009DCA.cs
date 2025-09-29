//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ʌ��Ϗ��E�I���\
// �v���O�����T�v   : ���Ӑ�ʌ��Ϗ��E�I���\���o�����N���X���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970531-00  �쐬�S�� : songg
// �� �� ��  K2013/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   TakekawaQuotaInventCndtnWork
	/// <summary>
	///                      ���Ӑ�ʌ��Ϗ��E�I���\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�ʌ��Ϗ��E�I���\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Genarated Date   :   K2013/12/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class TakekawaQuotaInventCndtnWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCodes;

        /// <summary>���O�C�����[�U�[�̋��_�R�[�h</summary>
        private string _loginUserSecCode;

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD ������������߂���t�B</remarks>
        private Int32 _addUpDate;

        /// <summary></summary>
        private DateTime _oprDate;

        /// <summary>���Ӑ�J�n</summary>
        private Int32 _customerCodeSt;

        /// <summary>���Ӑ�I��</summary>
        private Int32 _customerCodeEd;

        /// <summary>�q�ɊJ�n</summary>
        private string _warehouseCodeSt = "";

        /// <summary>�q�ɏI��</summary>
        private string _warehouseCodeEd = "";

        /// <summary>�I���敪</summary>
        /// <remarks>0:���Ϗ�,1:�I���\</remarks>
        private Int32 _selectFlg;

        /// <summary>�I�ԊJ�n</summary>
        private string _warehouseShelfNoSt = "";

        /// <summary>�I�ԏI��</summary>
        private string _warehouseShelfNoEd = "";

        /// <summary>�d����J�n</summary>
        private Int32 _stSupplierCd;

        /// <summary>�d����I��</summary>
        private Int32 _edSupplierCd;

        /// <summary>BL�R�[�h�J�n</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>BL�R�[�h�I��</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>���[�J�[�J�n</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>���[�J�[�I��</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�I�Ԍv�󎚋敪</summary>
        /// <remarks>0:�I�Ԍv�󎚂���,1:�I�Ԍv�󎚂��Ȃ�</remarks>
        private Int32 _shelfNoPrintFlg;

        /// <summary>�I�������͕������敪</summary>
        /// <remarks>0:�}�V���݌ɐ����̗p,1:�����͈���</remarks>
        private Int32 _shelfNoOprFlg;


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

        /// public propaty name  :  LoginUserSecCode
        /// <summary>���O�C�����[�U�[�̋��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C�����[�U�[�̋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginUserSecCode
		{
            get { return _loginUserSecCode; }
            set { _loginUserSecCode = value; }
		}

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD ������������߂���t�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

        /// public propaty name  :  OprDate
        /// <summary>�x���\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OprDate
        {
            get { return _oprDate; }
            set { _oprDate = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>���Ӑ�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>���Ӑ�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  WarehouseCodeSt
        /// <summary>�q�ɊJ�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɊJ�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>�q�ɏI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɏI���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        /// public propaty name  :  SelectFlg
        /// <summary>�I���敪�v���p�e�B</summary>
        /// <value>0:���Ϗ�,1:�I���\</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelectFlg
        {
            get { return _selectFlg; }
            set { _selectFlg = value; }
        }

        /// public propaty name  :  WarehouseShelfNoSt
        /// <summary>�I�ԊJ�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԊJ�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNoSt
        {
            get { return _warehouseShelfNoSt; }
            set { _warehouseShelfNoSt = value; }
        }

        /// public propaty name  :  WarehouseShelfNoEd
        /// <summary>�I�ԏI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԏI���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNoEd
        {
            get { return _warehouseShelfNoEd; }
            set { _warehouseShelfNoEd = value; }
        }

        /// public propaty name  :  StSupplierCd
        /// <summary>�d����J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StSupplierCd
        {
            get { return _stSupplierCd; }
            set { _stSupplierCd = value; }
        }

        /// public propaty name  :  EdSupplierCd
        /// <summary>�d����I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdSupplierCd
        {
            get { return _edSupplierCd; }
            set { _edSupplierCd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>BL�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>BL�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>���[�J�[�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>���[�J�[�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  ShelfNoPrintFlg
        /// <summary>�I�Ԍv�󎚋敪�v���p�e�B</summary>
        /// <value>0:�I�Ԍv�󎚂���,1:�I�Ԍv�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�Ԍv�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShelfNoPrintFlg
        {
            get { return _shelfNoPrintFlg; }
            set { _shelfNoPrintFlg = value; }
        }

        /// public propaty name  :  ShelfNoOprFlg
        /// <summary>�I�������͕������敪�v���p�e�B</summary>
        /// <value>0:�}�V���݌ɐ����̗p,1:�����͈���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������͕������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShelfNoOprFlg
        {
            get { return _shelfNoOprFlg; }
            set { _shelfNoOprFlg = value; }
        }

		/// <summary>
		/// ���Ӑ�ʌ��Ϗ��E�I���\���o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>TakekawaQuotaInventCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TakekawaQuotaInventCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TakekawaQuotaInventCndtnWork()
		{
		}

	}
}
