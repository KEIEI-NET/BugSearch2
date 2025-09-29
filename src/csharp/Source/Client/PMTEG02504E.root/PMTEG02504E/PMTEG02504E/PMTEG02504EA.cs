//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ��`�����ʕ\ ���o�N���X
//                  :   PMTEG02504E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   ���J��
// Date             :   2010.04.21
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// ��`�����ʕ\���o�����N���X
	/// </summary>
	/// <remarks>
    /// <br>note             :   ��`�����ʕ\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2010/03/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class TegataTorihikisakiListReport
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _sectionCodes;

        /// <summary>
        /// ���_�I�v�V�����敪
        /// </summary>
        private bool _isOptSection = false;

        /// <summary>
        /// �S���_�I���敪
        /// </summary>
        private bool _isSelectAllSection = false;

        /// <summary>��`�敪</summary>
        /// <remarks>0:���U 1:���U�@���������U�敪</remarks>
        private Int32 _draftDivide;

        /// <summary>����͈͔N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDate;

        /// <summary>����</summary>
        private Int32 _changePageDiv;

        /// <summary>����^�C�v</summary>
        private Int32 _printType;

        /// <summary>�J�n�����R�[�h</summary>
        private string  _customerCodeSt;

        /// <summary>�I�������R�[�h</summary>
        private string _customerCodeEd;

        /// <summary>�����^�C�g��</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _monthTitles;

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
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>��`�敪�v���p�e�B</summary>
        /// <value>0:���U 1:���U�@���������U�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>����͈͔N��</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����͈͔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>����^�C�v</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// public propaty name  :  MonthTitles
        /// <summary>�����^�C�g���v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] MonthTitles
        {
            get { return _monthTitles; }
            set { _monthTitles = value; }
        }

    }
}
