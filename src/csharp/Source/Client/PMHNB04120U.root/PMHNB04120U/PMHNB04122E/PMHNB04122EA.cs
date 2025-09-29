using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomInqOrderCndtn
    /// <summary>
    ///                      ���Ӑ�ߔN�x���яƉ�o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ߔN�x���яƉ�o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomInqOrderCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>���Ӑ於��</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _customerName = "";
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<

        /// <summary>�J�n�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _st_AddUpYearMonth;

        /// <summary>�I���v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _ed_AddUpYearMonth;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
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
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        // ---------------------- ADD 2010/07/20 -----------------------------------<<<<<
        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>�J�n�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>�I���v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
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

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }


        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>CustomInqOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomInqOrderCndtn()
        {
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="st_AddUpYearMonth">�J�n�v��N��(YYYYMM)</param>
        /// <param name="ed_AddUpYearMonth">�I���v��N��(YYYYMM)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="customerName">���Ӑ於��</param> // ADD 2010/07/20 
        /// <returns>CustomInqOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public CustomInqOrderCndtn(string enterpriseCode, string addUpSecCode, Int32 customerCode, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, string enterpriseName, string addUpSecName) // DEL 2010/07/20 
        public CustomInqOrderCndtn(string enterpriseCode, string addUpSecCode, Int32 customerCode, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, string enterpriseName, string addUpSecName, string customerName) // ADD 2010/07/20 
        {
            this._enterpriseCode = enterpriseCode;
            this._addUpSecCode = addUpSecCode;
            this._customerCode = customerCode;
            this._st_AddUpYearMonth = st_AddUpYearMonth;
            this._ed_AddUpYearMonth = ed_AddUpYearMonth;
            this._enterpriseName = enterpriseName;
            this._addUpSecName = addUpSecName;
            this._customerName = customerName; // ADD 2010/07/20 

        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X��������
        /// </summary>
        /// <returns>CustomInqOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomInqOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomInqOrderCndtn Clone()
        {
            //return new CustomInqOrderCndtn(this._enterpriseCode, this._addUpSecCode, this._customerCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._addUpSecName); // DEL 2010/07/20 
            return new CustomInqOrderCndtn(this._enterpriseCode, this._addUpSecCode, this._customerCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._addUpSecName, this._customerName); // ADD 2010/07/20 
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomInqOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustomInqOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
                 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.CustomerName == target.CustomerName)); // ADD 2010/07/20 
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X��r����
        /// </summary>
        /// <param name="customInqOrderCndtn1">
        ///                    ��r����CustomInqOrderCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="customInqOrderCndtn2">��r����CustomInqOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustomInqOrderCndtn customInqOrderCndtn1, CustomInqOrderCndtn customInqOrderCndtn2)
        {
            return ((customInqOrderCndtn1.EnterpriseCode == customInqOrderCndtn2.EnterpriseCode)
                 && (customInqOrderCndtn1.AddUpSecCode == customInqOrderCndtn2.AddUpSecCode)
                 && (customInqOrderCndtn1.CustomerCode == customInqOrderCndtn2.CustomerCode)
                 && (customInqOrderCndtn1.St_AddUpYearMonth == customInqOrderCndtn2.St_AddUpYearMonth)
                 && (customInqOrderCndtn1.Ed_AddUpYearMonth == customInqOrderCndtn2.Ed_AddUpYearMonth)
                 && (customInqOrderCndtn1.EnterpriseName == customInqOrderCndtn2.EnterpriseName)
                 && (customInqOrderCndtn1.AddUpSecName == customInqOrderCndtn2.AddUpSecName)
                 && (customInqOrderCndtn1.CustomerName == customInqOrderCndtn2.CustomerName)); // ADD 2010/07/20 
        }
        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomInqOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustomInqOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.St_AddUpYearMonth != target.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName"); // ADD 2010/07/20 

            return resList;
        }

        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ�o�����N���X��r����
        /// </summary>
        /// <param name="customInqOrderCndtn1">��r����CustomInqOrderCndtn�N���X�̃C���X�^���X</param>
        /// <param name="customInqOrderCndtn2">��r����CustomInqOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomInqOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustomInqOrderCndtn customInqOrderCndtn1, CustomInqOrderCndtn customInqOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (customInqOrderCndtn1.EnterpriseCode != customInqOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customInqOrderCndtn1.AddUpSecCode != customInqOrderCndtn2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (customInqOrderCndtn1.CustomerCode != customInqOrderCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (customInqOrderCndtn1.St_AddUpYearMonth != customInqOrderCndtn2.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (customInqOrderCndtn1.Ed_AddUpYearMonth != customInqOrderCndtn2.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (customInqOrderCndtn1.EnterpriseName != customInqOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (customInqOrderCndtn1.AddUpSecName != customInqOrderCndtn2.AddUpSecName) resList.Add("AddUpSecName");
            if (customInqOrderCndtn1.CustomerName != customInqOrderCndtn2.CustomerName) resList.Add("CustomerName"); // ADD 2010/07/20 

            return resList;
        }
    }
}
