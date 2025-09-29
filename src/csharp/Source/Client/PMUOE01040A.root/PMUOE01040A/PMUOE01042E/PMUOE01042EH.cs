//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : UOE����M�W���[�i�����o�����N���X
// �v���O�����T�v   : UOE����M�W���[�i�����o�����̒�`
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SndRcvJnlSearch
	/// <summary>
	///                      UOE����M�W���[�i�����o����
	/// </summary>
	/// <remarks>
	/// <br>note             :   UOE����M�W���[�i�����o�����w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/06/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SndRcvJnlSearch
	{
		/// <summary>UOE������R�[�h</summary>
		/// <remarks>0:�S��</remarks>
		private Int32 _uOESupplierCd;

		/// <summary>�����񓚔ԍ�</summary>
		/// <remarks>0:�S��</remarks>
		private Int32 _uOESalesOrderNo;

		/// <summary>�����񓚍s�ԍ�</summary>
		/// <remarks>0:�S��</remarks>
		private Int32 _uOESalesOrderRowNo;


		/// public propaty name  :  UOESupplierCd
		/// <summary>UOE������R�[�h�v���p�e�B</summary>
		/// <value>0:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UOESupplierCd
		{
			get { return _uOESupplierCd; }
			set { _uOESupplierCd = value; }
		}

		/// public propaty name  :  UOESalesOrderNo
		/// <summary>�����񓚔ԍ��v���p�e�B</summary>
		/// <value>0:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����񓚔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UOESalesOrderNo
		{
			get { return _uOESalesOrderNo; }
			set { _uOESalesOrderNo = value; }
		}

		/// public propaty name  :  UOESalesOrderRowNo
		/// <summary>�����񓚍s�ԍ��v���p�e�B</summary>
		/// <value>0:�S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����񓚍s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UOESalesOrderRowNo
		{
			get { return _uOESalesOrderRowNo; }
			set { _uOESalesOrderRowNo = value; }
		}


		/// <summary>
		/// UOE����M�W���[�i�����o�����R���X�g���N�^
		/// </summary>
		/// <returns>SndRcvJnlSearch�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SndRcvJnlSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SndRcvJnlSearch()
		{
		}

		/// <summary>
		/// UOE����M�W���[�i�����o�����R���X�g���N�^
		/// </summary>
		/// <param name="uOESupplierCd">UOE������R�[�h(0:�S��)</param>
		/// <param name="uOESalesOrderNo">�����񓚔ԍ�(0:�S��)</param>
		/// <param name="uOESalesOrderRowNo">�����񓚍s�ԍ�(0:�S��)</param>
		/// <returns>SndRcvJnlSearch�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SndRcvJnlSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SndRcvJnlSearch(Int32 uOESupplierCd, Int32 uOESalesOrderNo, Int32 uOESalesOrderRowNo)
		{
			this._uOESupplierCd = uOESupplierCd;
			this._uOESalesOrderNo = uOESalesOrderNo;
			this._uOESalesOrderRowNo = uOESalesOrderRowNo;

		}

		/// <summary>
		/// UOE����M�W���[�i�����o������������
		/// </summary>
		/// <returns>SndRcvJnlSearch�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SndRcvJnlSearch�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SndRcvJnlSearch Clone()
		{
			return new SndRcvJnlSearch(this._uOESupplierCd, this._uOESalesOrderNo, this._uOESalesOrderRowNo);
		}

		/// <summary>
		/// UOE����M�W���[�i�����o������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SndRcvJnlSearch�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SndRcvJnlSearch�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SndRcvJnlSearch target)
		{
			return ((this.UOESupplierCd == target.UOESupplierCd)
				 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
				 && (this.UOESalesOrderRowNo == target.UOESalesOrderRowNo));
		}

		/// <summary>
		/// UOE����M�W���[�i�����o������r����
		/// </summary>
		/// <param name="sndRcvJnlSearch1">
		///                    ��r����SndRcvJnlSearch�N���X�̃C���X�^���X
		/// </param>
		/// <param name="sndRcvJnlSearch2">��r����SndRcvJnlSearch�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SndRcvJnlSearch�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SndRcvJnlSearch sndRcvJnlSearch1, SndRcvJnlSearch sndRcvJnlSearch2)
		{
			return ((sndRcvJnlSearch1.UOESupplierCd == sndRcvJnlSearch2.UOESupplierCd)
				 && (sndRcvJnlSearch1.UOESalesOrderNo == sndRcvJnlSearch2.UOESalesOrderNo)
				 && (sndRcvJnlSearch1.UOESalesOrderRowNo == sndRcvJnlSearch2.UOESalesOrderRowNo));
		}
		/// <summary>
		/// UOE����M�W���[�i�����o������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SndRcvJnlSearch�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SndRcvJnlSearch�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SndRcvJnlSearch target)
		{
			ArrayList resList = new ArrayList();
			if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
			if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
			if (this.UOESalesOrderRowNo != target.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");

			return resList;
		}

		/// <summary>
		/// UOE����M�W���[�i�����o������r����
		/// </summary>
		/// <param name="sndRcvJnlSearch1">��r����SndRcvJnlSearch�N���X�̃C���X�^���X</param>
		/// <param name="sndRcvJnlSearch2">��r����SndRcvJnlSearch�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SndRcvJnlSearch�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SndRcvJnlSearch sndRcvJnlSearch1, SndRcvJnlSearch sndRcvJnlSearch2)
		{
			ArrayList resList = new ArrayList();
			if (sndRcvJnlSearch1.UOESupplierCd != sndRcvJnlSearch2.UOESupplierCd) resList.Add("UOESupplierCd");
			if (sndRcvJnlSearch1.UOESalesOrderNo != sndRcvJnlSearch2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
			if (sndRcvJnlSearch1.UOESalesOrderRowNo != sndRcvJnlSearch2.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");

			return resList;
		}
	}
}
