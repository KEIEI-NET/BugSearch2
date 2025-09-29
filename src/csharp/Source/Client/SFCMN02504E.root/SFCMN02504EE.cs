using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdReadParam
	/// <summary>
	///                      SCM�󔭒��Ǎ������N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󔭒��Ǎ������N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/4/30</br>
	/// <br>Genarated Date   :   2011/05/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2011/5/19  �{���@���[</br>
	/// <br>                 :   SCM�I�v�V����(PM�A�g 3������)�Ή�</br>
	/// <br>                 :   �ESF-PM�A�g�w�����ԍ�</br>
	/// <br>                 :   ���ڒǉ�</br>
	/// </remarks>
	[Serializable]
	public class ScmOdReadParam
	{
		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�⍇���ԍ�</summary>
		private Int64 _inquiryNumber;

		/// <summary>�ŐV���ʋ敪</summary>
		/// <remarks>0:�ŐV�f�[�^ 1:���f�[�^</remarks>
		private Int16 _latestDiscCode;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V�����b�~���b</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>SF-PM�A�g�w�����ԍ�</summary>
		private string _sfPmCprtInstSlipNo = "";


		/// public propaty name  :  InqOriginalEpCd
		/// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get { return _inqOriginalEpCd; }
			set { _inqOriginalEpCd = value; }
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get { return _inqOriginalSecCd; }
			set { _inqOriginalSecCd = value; }
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get { return _inqOtherEpCd; }
			set { _inqOtherEpCd = value; }
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get { return _inqOtherSecCd; }
			set { _inqOtherSecCd = value; }
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
		}

		/// public propaty name  :  LatestDiscCode
		/// <summary>�ŐV���ʋ敪�v���p�e�B</summary>
		/// <value>0:�ŐV�f�[�^ 1:���f�[�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŐV���ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 LatestDiscCode
		{
			get { return _latestDiscCode; }
			set { _latestDiscCode = value; }
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get { return _updateDate; }
			set { _updateDate = value; }
		}

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>�X�V�N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>�X�V�N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>�X�V�N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>�X�V�N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V�����b�~���b�v���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����b�~���b�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get { return _updateTime; }
			set { _updateTime = value; }
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
		/// <value>1:�⍇���E���� 2:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get { return _inqOrdAnsDivCd; }
			set { _inqOrdAnsDivCd = value; }
		}

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM�A�g�w�����ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SF-PM�A�g�w�����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SfPmCprtInstSlipNo
		{
			get { return _sfPmCprtInstSlipNo; }
			set { _sfPmCprtInstSlipNo = value; }
		}


		/// <summary>
		/// SCM�󔭒��Ǎ������N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ScmOdReadParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdReadParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdReadParam()
		{
		}

		/// <summary>
		/// SCM�󔭒��Ǎ������N���X�R���X�g���N�^
		/// </summary>
		/// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
		/// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
		/// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
		/// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
		/// <param name="inquiryNumber">�⍇���ԍ�</param>
		/// <param name="latestDiscCode">�ŐV���ʋ敪(0:�ŐV�f�[�^ 1:���f�[�^)</param>
		/// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
		/// <param name="updateTime">�X�V�����b�~���b(HHMMSSXXX)</param>
		/// <param name="inqOrdAnsDivCd">�┭�E�񓚎��(1:�⍇���E���� 2:��)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM�A�g�w�����ԍ�</param>
		/// <returns>ScmOdReadParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdReadParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdReadParam(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int16 latestDiscCode, DateTime updateDate, Int32 updateTime, Int32 inqOrdAnsDivCd, string sfPmCprtInstSlipNo)
		{
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this._latestDiscCode = latestDiscCode;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;

		}

		/// <summary>
		/// SCM�󔭒��Ǎ������N���X��������
		/// </summary>
		/// <returns>ScmOdReadParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdReadParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdReadParam Clone()
		{
			return new ScmOdReadParam(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._latestDiscCode, this._updateDate, this._updateTime, this._inqOrdAnsDivCd, this._sfPmCprtInstSlipNo);
		}

		/// <summary>
		/// SCM�󔭒��Ǎ������N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdReadParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdReadParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmOdReadParam target)
		{
			return ((this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo));
		}

		/// <summary>
		/// SCM�󔭒��Ǎ������N���X��r����
		/// </summary>
		/// <param name="scmOdReadParam1">
		///                    ��r����ScmOdReadParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmOdReadParam2">��r����ScmOdReadParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdReadParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ScmOdReadParam scmOdReadParam1, ScmOdReadParam scmOdReadParam2)
		{
			return ((scmOdReadParam1.InqOriginalEpCd == scmOdReadParam2.InqOriginalEpCd)
				 && (scmOdReadParam1.InqOriginalSecCd == scmOdReadParam2.InqOriginalSecCd)
				 && (scmOdReadParam1.InqOtherEpCd == scmOdReadParam2.InqOtherEpCd)
				 && (scmOdReadParam1.InqOtherSecCd == scmOdReadParam2.InqOtherSecCd)
				 && (scmOdReadParam1.InquiryNumber == scmOdReadParam2.InquiryNumber)
				 && (scmOdReadParam1.LatestDiscCode == scmOdReadParam2.LatestDiscCode)
				 && (scmOdReadParam1.UpdateDate == scmOdReadParam2.UpdateDate)
				 && (scmOdReadParam1.UpdateTime == scmOdReadParam2.UpdateTime)
				 && (scmOdReadParam1.InqOrdAnsDivCd == scmOdReadParam2.InqOrdAnsDivCd)
				 && (scmOdReadParam1.SfPmCprtInstSlipNo == scmOdReadParam2.SfPmCprtInstSlipNo));
		}
		/// <summary>
		/// SCM�󔭒��Ǎ������N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdReadParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdReadParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmOdReadParam target)
		{
			ArrayList resList = new ArrayList();
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
			if (this.InqOrdAnsDivCd != target.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");

			return resList;
		}

		/// <summary>
		/// SCM�󔭒��Ǎ������N���X��r����
		/// </summary>
		/// <param name="scmOdReadParam1">��r����ScmOdReadParam�N���X�̃C���X�^���X</param>
		/// <param name="scmOdReadParam2">��r����ScmOdReadParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdReadParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdReadParam scmOdReadParam1, ScmOdReadParam scmOdReadParam2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdReadParam1.InqOriginalEpCd != scmOdReadParam2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdReadParam1.InqOriginalSecCd != scmOdReadParam2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdReadParam1.InqOtherEpCd != scmOdReadParam2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdReadParam1.InqOtherSecCd != scmOdReadParam2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdReadParam1.InquiryNumber != scmOdReadParam2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdReadParam1.LatestDiscCode != scmOdReadParam2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdReadParam1.UpdateDate != scmOdReadParam2.UpdateDate) resList.Add("UpdateDate");
			if (scmOdReadParam1.UpdateTime != scmOdReadParam2.UpdateTime) resList.Add("UpdateTime");
			if (scmOdReadParam1.InqOrdAnsDivCd != scmOdReadParam2.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (scmOdReadParam1.SfPmCprtInstSlipNo != scmOdReadParam2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");

			return resList;
		}
	}
}
