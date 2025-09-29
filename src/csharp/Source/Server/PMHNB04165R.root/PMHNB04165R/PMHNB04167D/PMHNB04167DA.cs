//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2010/07/20  �C�����e : ���J��
//----------------------------------------------------------------------------//


using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   EmployeeResultsListCndtnWork
	/// <summary>
    ///                      �S���ҕʎ��яƉ�o�����N���X���[�N
	/// </summary>
	/// <remarks>
    /// <br>note             :   �S���ҕʎ��яƉ�o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class EmployeeResultsListCndtnWork
	{

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        /// <summary>�Q�Ƌ敪</summary>
        /// <remarks>�S���ҁA�󒍎ҁA���s��</remarks>
        private Int32 _referType;

        /// <summary>���ԋ敪</summary>
        /// <remarks>���v�A���v�A����</remarks>
        private Int32 _duringType;


        /// <summary>�S����(�J�n)</summary>
        private string _st_EmployeeCode;

        /// <summary>�S����(�I��)</summary>
        private string _ed_EmployeeCode;


        /// <summary>����(�J�n)YYYYMMDD</summary>
        /// <remarks>�Ȃ�</remarks>
        private DateTime _st_DuringTime;

        /// <summary>����(�I��)YYYYMMDD</summary>
        /// <remarks>�Ȃ�</remarks>
        private DateTime _ed_DuringTime;


        /// <summary>����(�J�n)YYYYMM</summary>
        /// <remarks>�Ȃ�</remarks>
        private DateTime _st_YearMonth;

        /// <summary>����(�I��)YYYYMM</summary>
        /// <remarks>�Ȃ�</remarks>
        private DateTime _ed_YearMonth;

        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>���_�R�[�h���X�g</summary>
        /// <remarks>�Ȃ�</remarks>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>��ʃr���[�E�o�̓r���[�t���O</summary>
        private string _viewFlg = string.Empty;
        // --- ADD 2010/07/20 --------------------------------<<<<<

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
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
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

        /// public propaty name  :  ReferType
        /// <summary>�Q�Ƌ敪�v���p�e�B</summary>
        /// <value>�S���ҁA�󒍎ҁA���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReferType
        {
            get { return _referType; }
            set { _referType = value; }
        }

        /// public propaty name  :  DuringType
        /// <summary>���ԋ敪�v���p�e�B</summary>
        /// <value>���v�A���v�A����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DuringType
        {
            get { return _duringType; }
            set { _duringType = value; }
        }


        /// <summary>�S����(�J�n)</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// <summary>�S����(�I��)</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// <summary>����(�J�n)YYYYMMDD</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_DuringTime
        {
            get { return _st_DuringTime; }
            set { _st_DuringTime = value; }
        }

        /// <summary>����(�I��)YYYYMMDD</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_DuringTime
        {
            get { return _ed_DuringTime; }
            set { _ed_DuringTime = value; }
        }


        /// <summary>����(�J�n)YYYYMM</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_YearMonth
        {
            get { return _st_YearMonth; }
            set { _st_YearMonth = value; }
        }

        /// <summary>����(�I��)YYYYMM</summary>
        /// <remarks>
        /// <br>Note             :   �Ȃ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_YearMonth
        {
            get { return _ed_YearMonth; }
            set { _ed_YearMonth = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// ���_�R�[�h���X�g
        /// </summary>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }

        /// <summary>
        /// ��ʃr���[�E�o�̓r���[�t���O
        /// </summary>
        public string ViewFlg
        {
            get { return _viewFlg; }
            set { _viewFlg = value; }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

		/// <summary>
        /// �S���ҕʎ��яƉ�o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeResultsListCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeResultsListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public EmployeeResultsListCndtnWork()
		{
		}

	}
}




