using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_AccPayBalanceWork
    /// <summary>
    ///                      ���|�c���������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�c���������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/10/02 FSI�����@�v �d�����������Ή� �d�������@�\�I�v�V�����ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_AccPayBalanceWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h�i�����w��j</summary>
        /// <remarks>�i�z��j</remarks>
        private string[] _sectionCodes;

        /// <summary>�J�n�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _st_AddUpYearMonth;

        /// <summary>�I���v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

        /// <summary>�J�n������R�[�h</summary>
        private Int32 _st_PayeeCode;

        /// <summary>�I��������R�[�h</summary>
        private Int32 _ed_PayeeCode;

        // ---------- ADD 2012/10/02 ---------->>>>>
        /// <summary>�d�������@�\�I�v�V�����L���^���� </summary>
        private bool _sumOpt;
        // ---------- ADD 2012/10/02 ----------<<<<<

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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i�z��j</value>
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

        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>�J�n�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpYearMonth
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
        public DateTime Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
        }

        /// public propaty name  :  St_PayeeCode
        /// <summary>�J�n������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_PayeeCode
        {
            get { return _st_PayeeCode; }
            set { _st_PayeeCode = value; }
        }

        /// public propaty name  :  Ed_PayeeCode
        /// <summary>�I��������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_PayeeCode
        {
            get { return _ed_PayeeCode; }
            set { _ed_PayeeCode = value; }
        }

        // ---------- ADD 2012/10/02 ---------->>>>>
        /// public propaty name  :  SumOpt
        /// <summary>�d�������@�\�I�v�V�����L���^�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������@�\�I�v�V�����L���^�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool SumOpt
        {
            get { return _sumOpt; }
            set { _sumOpt = value; }
        }
        // ---------- ADD 2012/10/02 ----------<<<<<

        /// <summary>
        /// ���|�c���������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_AccPayBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_AccPayBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_AccPayBalanceWork()
        {
        }

    }
}
