using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ������͗p�����l�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l���Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    [Serializable]
    public class SalesSlipInputInitData
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _enterpriseCode = string.Empty;
        private string _sectionCode = string.Empty;
        private int _customerCode = 0;
        private const string ctXML_FILE_NAME = "MAHNB01012A_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ������͗p�����l�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������͗p�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public SalesSlipInputInitData()
        {
            //
        }

        /// <summary>
        /// ������͗p���[�U�[�ݒ�N���X
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ������͗p�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public SalesSlipInputInitData(string enterpriseCode, string sectionCode, int customerCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
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

        /// <summary>���Ӑ�R�[�h</summary>
        public int CustomerCode
        {
            get { return this._customerCode; }
            set { this._customerCode = value; }
        }
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
                SalesSlipInputInitData data = UserSettingController.DeserializeUserSetting<SalesSlipInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                this._enterpriseCode = data.EnterpriseCode;
                this._sectionCode = data.SectionCode;
                this._customerCode = data.CustomerCode;
            }
        }
        # endregion
    }
}