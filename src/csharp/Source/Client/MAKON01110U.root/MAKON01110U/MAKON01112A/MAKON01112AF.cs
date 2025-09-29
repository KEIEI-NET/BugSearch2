using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �d�����͗p�����l�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͂̏����l���Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>2010.01.06 30434 �H�� �b�D MANTIS[0014857] �S���҂�ۑ�����ێ�����ݒ��ǉ�</br>
    /// </remarks>
    [Serializable]
    public class StockSlipInputInitData
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _enterpriseCode = "";
        private string _sectionCode = "";
        private int _supplierCode = 0;
        private string _warehouseCode = "";
        private string _stockAgentCode = "";    // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ�
        private const string ctXML_FILE_NAME = "MAKON01112A_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �d�����͗p�����l�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�����͗p�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// </remarks>
        public StockSlipInputInitData()
        {
            //
        }

        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="stockAgentCode">�S���҃R�[�h</param>
        /// <remarks>
        /// <br>Note       : �d�����͗p�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2008.05.21</br>
        /// <br>2010.01.06 30434 �H�� �b�D MANTIS[0014857] �S���҂�ۑ�����ێ�����ݒ��ǉ�</br>
        /// </remarks>
        public StockSlipInputInitData(string enterpriseCode, string sectionCode, int supplierCode, string warehouseCode,
            string stockAgentCode   // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ�
        )
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
			this._supplierCode = supplierCode;
            this._warehouseCode = warehouseCode;
            this._stockAgentCode = stockAgentCode;  // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ�
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>��ƃR�[�h</summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>���_�R�[�h</summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>�d����R�[�h</summary>
        public int SupplierCode
        {
			get { return this._supplierCode; }
			set { this._supplierCode = value; }
        }

        /// <summary>�q�ɃR�[�h</summary>
        public string WarehouseCode
        {
            get { return this._warehouseCode; }
            set { this._warehouseCode = value; }
        }

        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ---------->>>>>
        /// <summary>�S���҃R�[�h</summary>
        public string StockAgentCode
        {
            get { return this._stockAgentCode; }
            set { this._stockAgentCode = value; }
        }
        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ----------<<<<<
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �V���A���C�Y����
        /// </summary>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(this, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));
        }

        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME)))
            {
                try
                {
                    StockSlipInputInitData data = UserSettingController.DeserializeUserSetting<StockSlipInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                    this._enterpriseCode = data.EnterpriseCode;
                    this._sectionCode = data.SectionCode;
                    this._supplierCode = data.SupplierCode;
                    this._warehouseCode = data.WarehouseCode;
                    this._stockAgentCode = data.StockAgentCode; // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ�
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));
                }
            }
        }
        # endregion
    }
}