using System;
using System.IO;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �������ϗp�����l�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ς̏����l���Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.09.25</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EstimateInputInitData
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private string _enterpriseCode = "";
        private int _customerCode = 0;
        private const string ctXML_FILE_NAME = "PMMIT01012A_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �������ϗp�����l�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������ϗp�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2008.09.25</br>
        /// </remarks>
        public EstimateInputInitData()
        {
            //
        }

        /// <summary>
        /// �������ϗp���[�U�[�ݒ�N���X
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �������ϗp�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2008.09.25</br>
        /// </remarks>
        public EstimateInputInitData( string enterpriseCode, int customerCode) 
        {
            this._enterpriseCode = enterpriseCode;
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
                EstimateInputInitData data = UserSettingController.DeserializeUserSetting<EstimateInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                this._enterpriseCode = data.EnterpriseCode;
                this._customerCode = data.CustomerCode;
            }
        }
        # endregion
    }
}