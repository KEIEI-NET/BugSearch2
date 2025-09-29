using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesHistAnalyzeCndtnWork
	/// <summary>
	///                      ������e���͕\���o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������e���͕\���o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesHistAnalyzeCndtnWork  
	{
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string[] _sectionCode;

        /// <summary>�J�n�Ώۓ��t</summary>
        private Int32 _st_SalesDate;

        /// <summary>�I���Ώۓ��t</summary>
        private Int32 _ed_SalesDate;

        /// <summary>�J�n�Ώۓ��t(�݌v)</summary>
        /// <remarks>�݌v���o�͈͂̊J�n���t���Z�b�g</remarks>
        private Int32 _st_MonthReportDate;

        /// <summary>�I���Ώۓ��t(�݌v)</summary>
        /// <remarks>�I�����t���Z�b�g</remarks>
        private Int32 _ed_MonthReportDate;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _st_CustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>�J�n�̔��]�ƈ��R�[�h</summary>
        private string _st_SalesEmployeeCd = "";

        /// <summary>�I���̔��]�ƈ��R�[�h</summary>
        private string _ed_SalesEmployeeCd = "";

        /// <summary>�J�n�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _st_SalesAreaCode;

        /// <summary>�I���̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _ed_SalesAreaCode;

        /// <summary>���s�^�C�v</summary>
        /// <remarks>0:���Ӑ��,1:�S���ҕ�,2:�n���</remarks>
        private Int32 _printDiv;


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>�I���Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_MonthReportDate
        /// <summary>�J�n�Ώۓ��t(�݌v)�v���p�e�B</summary>
        /// <value>�݌v���o�͈͂̊J�n���t���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۓ��t(�݌v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_MonthReportDate
        {
            get { return _st_MonthReportDate; }
            set { _st_MonthReportDate = value; }
        }

        /// public propaty name  :  Ed_MonthReportDate
        /// <summary>�I���Ώۓ��t(�݌v)�v���p�e�B</summary>
        /// <value>�I�����t���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۓ��t(�݌v)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_MonthReportDate
        {
            get { return _ed_MonthReportDate; }
            set { _ed_MonthReportDate = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_SalesEmployeeCd
        /// <summary>�J�n�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_SalesEmployeeCd
        {
            get { return _st_SalesEmployeeCd; }
            set { _st_SalesEmployeeCd = value; }
        }

        /// public propaty name  :  Ed_SalesEmployeeCd
        /// <summary>�I���̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_SalesEmployeeCd
        {
            get { return _ed_SalesEmployeeCd; }
            set { _ed_SalesEmployeeCd = value; }
        }

        /// public propaty name  :  St_SalesAreaCode
        /// <summary>�J�n�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesAreaCode
        {
            get { return _st_SalesAreaCode; }
            set { _st_SalesAreaCode = value; }
        }

        /// public propaty name  :  Ed_SalesAreaCode
        /// <summary>�I���̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SalesAreaCode
        {
            get { return _ed_SalesAreaCode; }
            set { _ed_SalesAreaCode = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>���s�^�C�v�v���p�e�B</summary>
        /// <value>0:���Ӑ��,1:�S���ҕ�,2:�n���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }


        /// <summary>
        /// ������e���͕\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesHistAnalyzeCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesHistAnalyzeCndtnWork()
        {
        }

	}
}




