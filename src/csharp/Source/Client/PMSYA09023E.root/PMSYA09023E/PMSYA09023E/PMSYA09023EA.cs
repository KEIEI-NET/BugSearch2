using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���q�Ǘ��}�X�^�����������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����q�Ǘ��}�X�^����������񏉊����y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/09/07</br>
    /// </remarks>
    public class CarManagementExtractInfo
    {
        # region �� Private Field

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private int _customerCode;

        /// <summary>���Ӑ�R�[�h�J�n</summary>
        private int _customerCodeSt;

        /// <summary>���Ӑ�R�[�h�I��</summary>
        private int _customerCodeEd;

        /// <summary>�Ǘ��ԍ�</summary>
        private string _carMngCode;

        /// <summary>�����敪</summary>
        private int _searchDiv;

        # endregion �� Private Field

        # region �� Public Propaty
        /// <summary>
        /// ��ƃR�[�h�v���p�e�B
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>
        /// ���Ӑ�R�[�h�v���p�e�B
        /// </summary>
        public int CustomerCode
        {
            get { return this._customerCode; }
            set { this._customerCode = value; }
        }

        /// <summary>
        /// ���Ӑ�R�[�h�J�n�v���p�e�B
        /// </summary>
        public int CustomerCodeSt
        {
            get { return this._customerCodeSt; }
            set { this._customerCodeSt = value; }
        }

        /// <summary>
        /// ���Ӑ�R�[�h�I���v���p�e�B
        /// </summary>
        public int CustomerCodeEd
        {
            get { return this._customerCodeEd; }
            set { this._customerCodeEd = value; }
        }

        /// <summary>
        /// �Ǘ��ԍ��v���p�e�B
        /// </summary>
        public string CarMngCode
        {
            get { return this._carMngCode; }
            set { this._carMngCode = value; }
        }

        /// <summary>
        /// �����敪�I���v���p�e�B
        /// </summary>
        public int SearchDiv
        {
            get { return this._searchDiv; }
            set { this._searchDiv = value; }
        }
        # endregion �� Public Propaty

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CarManagementExtractInfo()
        {

        }
        #endregion
    }
}
