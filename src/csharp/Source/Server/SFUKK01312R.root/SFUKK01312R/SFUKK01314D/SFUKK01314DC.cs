using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SeiKingetDetailParameter
	/// <summary>
	///                      ����KINGET���חp���o�����p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����KINGET���חp�̒��o�����p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/03/31</br>
	/// <br>Genarated Date   :   2005/07/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class SeiKingetDetailParameter
	{
		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string _addUpSecCode = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>�v��N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _addUpDate;

		/// <summary>����</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>���t�͈́i�J�n�j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _startDateSpan;

		/// <summary>���t�͈́i�I���j</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _endDateSpan;


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
			get{return _addUpSecCode;}
			set{_addUpSecCode = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  AddUpDate
		/// <summary>�v��N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v��N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddUpDate
		{
			get{return _addUpDate;}
			set{_addUpDate = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>�����v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  StartDateSpan
		/// <summary>���t�͈́i�J�n�j�v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���t�͈́i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartDateSpan
		{
			get{return _startDateSpan;}
			set{_startDateSpan = value;}
		}

		/// public propaty name  :  EndDateSpan
		/// <summary>���t�͈́i�I���j�v���p�e�B</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���t�͈́i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndDateSpan
		{
			get{return _endDateSpan;}
			set{_endDateSpan = value;}
		}


		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SeiKingetDetailParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SeiKingetDetailParameter()
		{
		}

		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpDate">�v��N����(YYYYMMDD)</param>
		/// <param name="totalDay">����</param>
		/// <param name="startDateSpan">���t�͈́i�J�n�j(YYYYMMDD)</param>
		/// <param name="endDateSpan">���t�͈́i�I���j(YYYYMMDD)</param>
		/// <returns>SeiKingetDetailParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SeiKingetDetailParameter(string addUpSecCode,Int32 customerCode,Int32 addUpDate,Int32 totalDay,Int32 startDateSpan,Int32 endDateSpan)
		{
			this._addUpSecCode = addUpSecCode;
			this._customerCode = customerCode;
			this._addUpDate = addUpDate;
			this._totalDay = totalDay;
			this._startDateSpan = startDateSpan;
			this._endDateSpan = endDateSpan;
		}

		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X��������
		/// </summary>
		/// <returns>SeiKingetDetailParameter�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SeiKingetDetailParameter�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SeiKingetDetailParameter Clone()
		{
			return new SeiKingetDetailParameter(this._addUpSecCode,this._customerCode,this._addUpDate,this._totalDay,this._startDateSpan,this._endDateSpan);
		}

		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�����������܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Clear()
		{
			this._addUpSecCode = "";
			this._customerCode = 0;
			this._addUpDate = 0;
			this._totalDay = 0;
			this._startDateSpan = 0;
			this._endDateSpan = 0;
		}

		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SeiKingetDetailParameter�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SeiKingetDetailParameter target)
		{
			return ((this.AddUpSecCode == target.AddUpSecCode)
				&& (this.CustomerCode == target.CustomerCode)
				&& (this.AddUpDate == target.AddUpDate)
				&& (this.TotalDay == target.TotalDay)
				&& (this.StartDateSpan == target.StartDateSpan)
				&& (this.EndDateSpan == target.EndDateSpan));
		}

		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="custDmdPrc1">��r����SeiKingetDetailParameter�N���X�̃C���X�^���X</param>
		/// <param name="custDmdPrc2">��r����SeiKingetDetailParameter�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SeiKingetDetailParameter custDmdPrc1, SeiKingetDetailParameter custDmdPrc2)
		{
			return ((custDmdPrc1.AddUpSecCode == custDmdPrc2.AddUpSecCode)
				&& (custDmdPrc1.CustomerCode == custDmdPrc2.CustomerCode)
				&& (custDmdPrc1.AddUpDate == custDmdPrc2.AddUpDate)
				&& (custDmdPrc1.TotalDay == custDmdPrc2.TotalDay)
				&& (custDmdPrc1.StartDateSpan == custDmdPrc2.StartDateSpan)
				&& (custDmdPrc1.EndDateSpan == custDmdPrc2.EndDateSpan));
		}
		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SeiKingetDetailParameter�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SeiKingetDetailParameter target)
		{
			ArrayList resList = new ArrayList();
			if(this.AddUpSecCode != target.AddUpSecCode)resList.Add("AddUpSecCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.AddUpDate != target.AddUpDate)resList.Add("AddUpDate");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.StartDateSpan != target.StartDateSpan)resList.Add("StartDateSpan");
			if(this.EndDateSpan != target.EndDateSpan)resList.Add("EndDateSpan");

			return resList;
		}

		/// <summary>
		/// ����KINGET���חp���o�����p�����[�^�N���X��r����
		/// </summary>
		/// <param name="custDmdPrc1">��r����SeiKingetDetailParameter�N���X�̃C���X�^���X</param>
		/// <param name="custDmdPrc2">��r����SeiKingetDetailParameter�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SeiKingetDetailParameter�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SeiKingetDetailParameter custDmdPrc1, SeiKingetDetailParameter custDmdPrc2)
		{
			ArrayList resList = new ArrayList();
			if(custDmdPrc1.AddUpSecCode != custDmdPrc2.AddUpSecCode)resList.Add("AddUpSecCode");
			if(custDmdPrc1.CustomerCode != custDmdPrc2.CustomerCode)resList.Add("CustomerCode");
			if(custDmdPrc1.AddUpDate != custDmdPrc2.AddUpDate)resList.Add("AddUpDate");
			if(custDmdPrc1.TotalDay != custDmdPrc2.TotalDay)resList.Add("TotalDay");
			if(custDmdPrc1.StartDateSpan != custDmdPrc2.StartDateSpan)resList.Add("StartDateSpan");
			if(custDmdPrc1.EndDateSpan != custDmdPrc2.EndDateSpan)resList.Add("EndDateSpan");

			return resList;
		}
	}
}
