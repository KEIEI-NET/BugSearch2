using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_UpdHisDspWork
	/// <summary>
	///                      �X�V����\�����o�������[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �X�V����\�����o�������[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_UpdHisDspWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�o�͑Ώۋ��_</summary>
		/// <remarks>null�̏ꍇ�͑S���_</remarks>
		private string[] _addupSecCodeList;

		/// <summary>�J�n�����X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ����N����</remarks>
		private Int32 _st_CAddUpUpdDate;

		/// <summary>�I�������X�V�N����</summary>
		/// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ����N����</remarks>
		private Int32 _ed_CAddUpUpdDate;

		/// <summary>�J�n�����X�V���s�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_CAddUpUpdExecDate;

		/// <summary>�I�������X�V���s�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_CAddUpUpdExecDate;

		/// <summary>�\���敪</summary>
		/// <remarks>0:�����A1:�x���A2:���㌎���A3:�d������</remarks>
		private Int32 _dispDiv;

		/// <summary>�������</summary>
		/// <remarks>-1�S�āA0:�X�V�����A1:��������</remarks>
		private Int32 _procKnd;

		/// <summary>���ʎ��</summary>
		/// <remarks>-1�F�S�āA0�F����I���A1�F�ُ�I��</remarks>
		private Int32 _rsltKnd;


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  AddupSecCodeList
		/// <summary>�o�͑Ώۋ��_�v���p�e�B</summary>
		/// <value>null�̏ꍇ�͑S���_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͑Ώۋ��_�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string[] AddupSecCodeList
		{
			get{return _addupSecCodeList;}
			set{_addupSecCodeList = value;}
		}

		/// public propaty name  :  St_CAddUpUpdDate
		/// <summary>�J�n�����X�V�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CAddUpUpdDate
		{
			get{return _st_CAddUpUpdDate;}
			set{_st_CAddUpUpdDate = value;}
		}

		/// public propaty name  :  Ed_CAddUpUpdDate
		/// <summary>�I�������X�V�N�����v���p�e�B</summary>
		/// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ����N����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CAddUpUpdDate
		{
			get{return _ed_CAddUpUpdDate;}
			set{_ed_CAddUpUpdDate = value;}
		}

		/// public propaty name  :  St_CAddUpUpdExecDate
		/// <summary>�J�n�����X�V���s�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����X�V���s�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CAddUpUpdExecDate
		{
			get{return _st_CAddUpUpdExecDate;}
			set{_st_CAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  Ed_CAddUpUpdExecDate
		/// <summary>�I�������X�V���s�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������X�V���s�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CAddUpUpdExecDate
		{
			get{return _ed_CAddUpUpdExecDate;}
			set{_ed_CAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  DispDiv
		/// <summary>�\���敪�v���p�e�B</summary>
		/// <value>0:�����A1:�x���A2:���㌎���A3:�d������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DispDiv
		{
			get{return _dispDiv;}
			set{_dispDiv = value;}
		}

		/// public propaty name  :  ProcKnd
		/// <summary>������ʃv���p�e�B</summary>
		/// <value>-1�S�āA0:�X�V�����A1:��������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ProcKnd
		{
			get{return _procKnd;}
			set{_procKnd = value;}
		}

		/// public propaty name  :  RsltKnd
		/// <summary>���ʎ�ʃv���p�e�B</summary>
		/// <value>-1�F�S�āA0�F����I���A1�F�ُ�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʎ�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RsltKnd
		{
			get{return _rsltKnd;}
			set{_rsltKnd = value;}
		}


		/// <summary>
		/// �X�V����\�����o�������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_UpdHisDspWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_UpdHisDspWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_UpdHisDspWork()
		{
		}

	}
}
