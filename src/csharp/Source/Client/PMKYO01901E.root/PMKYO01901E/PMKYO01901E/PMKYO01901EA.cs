//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �G���[�ڍ׃f�[�^�N���X
// �v���O�����T�v   : �G���[�ڍו\���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �v��
// �� �� ��  2011/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PMKYO01901EA
    /// <summary>
    ///                      �G���[�ڍ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   �G���[�ڍ׃w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PMKYO01901EA
    {
        ///<summary>�e�[�u������</summary>
        public const string Tbl_ErrorInfoTable = "ERRORINFO";

        /// <summary>�`�[�敪</summary>
        private string _noFlg = "";

        /// <summary>�`�[�ԍ�</summary>
        private string _no = "";

        /// <summary>���t</summary>
        private string _date = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_��</summary>
        private string _sectionNm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private string _customerCode;

        /// <summary>���Ӑ�(�d����)��</summary>
        private string _customerNm = "";

        /// <summary>�G���[���e</summary>
        private string _error = "";


        /// public propaty name  :  NoFlg
        /// <summary>�`�[�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NoFlg
        {
            get { return _noFlg; }
            set { _noFlg = value; }
        }

        /// public propaty name  :  No
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string No
        {
            get { return _no; }
            set { _no = value; }
        }

        /// public propaty name  :  Date
        /// <summary>���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Date
        {
            get { return _date; }
            set { _date = value; }
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

        /// public propaty name  :  SectionNm
        /// <summary>���_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionNm
        {
            get { return _sectionNm; }
            set { _sectionNm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerNm
        /// <summary>���Ӑ�(�d����)���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�(�d����)���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerNm
        {
            get { return _customerNm; }
            set { _customerNm = value; }
        }

        /// public propaty name  :  Error
        /// <summary>�G���[���e�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }


        /// <summary>
        /// �G���[�ڍ׃R���X�g���N�^
        /// </summary>
        /// <returns>PMKYO01901EA�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMKYO01901EA�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PMKYO01901EA()
        {
        }

        /// <summary>
        /// �G���[�ڍ׃R���X�g���N�^
        /// </summary>
        /// <param name="noFlg">�`�[�敪</param>
        /// <param name="no">�`�[�ԍ�</param>
        /// <param name="date">���t</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionNm">���_��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerNm">���Ӑ�(�d����)��</param>
        /// <param name="error">�G���[���e</param>
        /// <returns>PMKYO01901EA�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMKYO01901EA�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PMKYO01901EA(string noFlg, string no, string date, string sectionCode, string sectionNm, string customerCode, string customerNm, string error)
        {
            this._noFlg = noFlg;
            this._no = no;
            this._date = date;
            this._sectionCode = sectionCode;
            this._sectionNm = sectionNm;
            this._customerCode = customerCode;
            this._customerNm = customerNm;
            this._error = error;

        }

        /// <summary>
        /// �G���[�ڍו�������
        /// </summary>
        /// <returns>PMKYO01901EA�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PMKYO01901EA�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PMKYO01901EA Clone()
        {
            return new PMKYO01901EA(this._noFlg, this._no, this._date, this._sectionCode, this._sectionNm, this._customerCode, this._customerNm, this._error);
        }

        /// <summary>
        /// �G���[�ڍה�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PMKYO01901EA�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMKYO01901EA�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PMKYO01901EA target)
        {
            return ((this.NoFlg == target.NoFlg)
                 && (this.No == target.No)
                 && (this.Date == target.Date)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionNm == target.SectionNm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerNm == target.CustomerNm)
                 && (this.Error == target.Error));
        }

        /// <summary>
        /// �G���[�ڍה�r����
        /// </summary>
        /// <param name="pMKYO01901EA1">
        ///                    ��r����PMKYO01901EA�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pMKYO01901EA2">��r����PMKYO01901EA�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMKYO01901EA�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PMKYO01901EA pMKYO01901EA1, PMKYO01901EA pMKYO01901EA2)
        {
            return ((pMKYO01901EA1.NoFlg == pMKYO01901EA2.NoFlg)
                 && (pMKYO01901EA1.No == pMKYO01901EA2.No)
                 && (pMKYO01901EA1.Date == pMKYO01901EA2.Date)
                 && (pMKYO01901EA1.SectionCode == pMKYO01901EA2.SectionCode)
                 && (pMKYO01901EA1.SectionNm == pMKYO01901EA2.SectionNm)
                 && (pMKYO01901EA1.CustomerCode == pMKYO01901EA2.CustomerCode)
                 && (pMKYO01901EA1.CustomerNm == pMKYO01901EA2.CustomerNm)
                 && (pMKYO01901EA1.Error == pMKYO01901EA2.Error));
        }
        /// <summary>
        /// �G���[�ڍה�r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PMKYO01901EA�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMKYO01901EA�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PMKYO01901EA target)
        {
            ArrayList resList = new ArrayList();
            if (this.NoFlg != target.NoFlg) resList.Add("NoFlg");
            if (this.No != target.No) resList.Add("No");
            if (this.Date != target.Date) resList.Add("Date");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionNm != target.SectionNm) resList.Add("SectionNm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerNm != target.CustomerNm) resList.Add("CustomerNm");
            if (this.Error != target.Error) resList.Add("Error");

            return resList;
        }

        /// <summary>
        /// �G���[�ڍה�r����
        /// </summary>
        /// <param name="pMKYO01901EA1">��r����PMKYO01901EA�N���X�̃C���X�^���X</param>
        /// <param name="pMKYO01901EA2">��r����PMKYO01901EA�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PMKYO01901EA�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PMKYO01901EA pMKYO01901EA1, PMKYO01901EA pMKYO01901EA2)
        {
            ArrayList resList = new ArrayList();
            if (pMKYO01901EA1.NoFlg != pMKYO01901EA2.NoFlg) resList.Add("NoFlg");
            if (pMKYO01901EA1.No != pMKYO01901EA2.No) resList.Add("No");
            if (pMKYO01901EA1.Date != pMKYO01901EA2.Date) resList.Add("Date");
            if (pMKYO01901EA1.SectionCode != pMKYO01901EA2.SectionCode) resList.Add("SectionCode");
            if (pMKYO01901EA1.SectionNm != pMKYO01901EA2.SectionNm) resList.Add("SectionNm");
            if (pMKYO01901EA1.CustomerCode != pMKYO01901EA2.CustomerCode) resList.Add("CustomerCode");
            if (pMKYO01901EA1.CustomerNm != pMKYO01901EA2.CustomerNm) resList.Add("CustomerNm");
            if (pMKYO01901EA1.Error != pMKYO01901EA2.Error) resList.Add("Error");

            return resList;
        }
    }
}
