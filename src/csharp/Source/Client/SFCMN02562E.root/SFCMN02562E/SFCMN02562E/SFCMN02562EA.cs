using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmEpCnect
	/// <summary>
	///                      SCM��ƘA���}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM��ƘA���}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2009/05/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ScmEpCnect 
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�A������ƃR�[�h</summary>
		private string _cnectOriginalEpCd = "";

		/// <summary>�A������Ɩ���</summary>
		private string _cnectOriginalEpNm = "";

		/// <summary>�A�����ƃR�[�h</summary>
		private string _cnectOtherEpCd = "";

		/// <summary>�A�����Ɩ���</summary>
		private string _cnectOtherEpNm = "";

		/// <summary>���ʋ敪</summary>
		/// <remarks>0:�A���L�� 1:�A������</remarks>
		private Int32 _discDivCd;


		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  CnectOriginalEpCd
		/// <summary>�A������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOriginalEpCd
		{
			get{return _cnectOriginalEpCd;}
			set{_cnectOriginalEpCd = value;}
		}

		/// public propaty name  :  CnectOriginalEpNm
		/// <summary>�A������Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A������Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOriginalEpNm
		{
			get{return _cnectOriginalEpNm;}
			set{_cnectOriginalEpNm = value;}
		}

		/// public propaty name  :  CnectOtherEpCd
		/// <summary>�A�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOtherEpCd
		{
			get{return _cnectOtherEpCd;}
			set{_cnectOtherEpCd = value;}
		}

		/// public propaty name  :  CnectOtherEpNm
		/// <summary>�A�����Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �A�����Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CnectOtherEpNm
		{
			get{return _cnectOtherEpNm;}
			set{_cnectOtherEpNm = value;}
		}

		/// public propaty name  :  DiscDivCd
		/// <summary>���ʋ敪�v���p�e�B</summary>
		/// <value>0:�A���L�� 1:�A������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DiscDivCd
		{
			get{return _discDivCd;}
			set{_discDivCd = value;}
		}


		/// <summary>
		/// SCM��ƘA���}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>ScmEpCnect�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpCnect�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmEpCnect()
		{
		}

		/// <summary>
		/// SCM��ƘA���}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
		/// <param name="cnectOriginalEpNm">�A������Ɩ���</param>
		/// <param name="cnectOtherEpCd">�A�����ƃR�[�h</param>
		/// <param name="cnectOtherEpNm">�A�����Ɩ���</param>
		/// <param name="discDivCd">���ʋ敪(0:�A���L�� 1:�A������)</param>
		/// <returns>ScmEpCnect�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpCnect�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmEpCnect(DateTime createDateTime,DateTime updateDateTime,Int32 logicalDeleteCode,string cnectOriginalEpCd,string cnectOriginalEpNm,string cnectOtherEpCd,string cnectOtherEpNm,Int32 discDivCd)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._cnectOriginalEpCd = cnectOriginalEpCd;
			this._cnectOriginalEpNm = cnectOriginalEpNm;
			this._cnectOtherEpCd = cnectOtherEpCd;
			this._cnectOtherEpNm = cnectOtherEpNm;
			this._discDivCd = discDivCd;

		}

		/// <summary>
		/// SCM��ƘA���}�X�^��������
		/// </summary>
		/// <returns>ScmEpCnect�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmEpCnect�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmEpCnect Clone()
		{
			return new ScmEpCnect(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._cnectOriginalEpCd,this._cnectOriginalEpNm,this._cnectOtherEpCd,this._cnectOtherEpNm,this._discDivCd);
		}

		/// <summary>
		/// SCM��ƘA���}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmEpCnect�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpCnect�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmEpCnect target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
				 && (this.CnectOriginalEpNm == target.CnectOriginalEpNm)
				 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
				 && (this.CnectOtherEpNm == target.CnectOtherEpNm)
				 && (this.DiscDivCd == target.DiscDivCd));
		}

		/// <summary>
		/// SCM��ƘA���}�X�^��r����
		/// </summary>
		/// <param name="scmEpCnect1">
		///                    ��r����ScmEpCnect�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmEpCnect2">��r����ScmEpCnect�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpCnect�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ScmEpCnect scmEpCnect1, ScmEpCnect scmEpCnect2)
		{
			return ((scmEpCnect1.CreateDateTime == scmEpCnect2.CreateDateTime)
				 && (scmEpCnect1.UpdateDateTime == scmEpCnect2.UpdateDateTime)
				 && (scmEpCnect1.LogicalDeleteCode == scmEpCnect2.LogicalDeleteCode)
				 && (scmEpCnect1.CnectOriginalEpCd == scmEpCnect2.CnectOriginalEpCd)
				 && (scmEpCnect1.CnectOriginalEpNm == scmEpCnect2.CnectOriginalEpNm)
				 && (scmEpCnect1.CnectOtherEpCd == scmEpCnect2.CnectOtherEpCd)
				 && (scmEpCnect1.CnectOtherEpNm == scmEpCnect2.CnectOtherEpNm)
				 && (scmEpCnect1.DiscDivCd == scmEpCnect2.DiscDivCd));
		}
		/// <summary>
		/// SCM��ƘA���}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmEpCnect�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpCnect�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmEpCnect target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.CnectOriginalEpCd != target.CnectOriginalEpCd)resList.Add("CnectOriginalEpCd");
			if(this.CnectOriginalEpNm != target.CnectOriginalEpNm)resList.Add("CnectOriginalEpNm");
			if(this.CnectOtherEpCd != target.CnectOtherEpCd)resList.Add("CnectOtherEpCd");
			if(this.CnectOtherEpNm != target.CnectOtherEpNm)resList.Add("CnectOtherEpNm");
			if(this.DiscDivCd != target.DiscDivCd)resList.Add("DiscDivCd");

			return resList;
		}

		/// <summary>
		/// SCM��ƘA���}�X�^��r����
		/// </summary>
		/// <param name="scmEpCnect1">��r����ScmEpCnect�N���X�̃C���X�^���X</param>
		/// <param name="scmEpCnect2">��r����ScmEpCnect�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmEpCnect�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ScmEpCnect scmEpCnect1, ScmEpCnect scmEpCnect2)
		{
			ArrayList resList = new ArrayList();
			if(scmEpCnect1.CreateDateTime != scmEpCnect2.CreateDateTime)resList.Add("CreateDateTime");
			if(scmEpCnect1.UpdateDateTime != scmEpCnect2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(scmEpCnect1.LogicalDeleteCode != scmEpCnect2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(scmEpCnect1.CnectOriginalEpCd != scmEpCnect2.CnectOriginalEpCd)resList.Add("CnectOriginalEpCd");
			if(scmEpCnect1.CnectOriginalEpNm != scmEpCnect2.CnectOriginalEpNm)resList.Add("CnectOriginalEpNm");
			if(scmEpCnect1.CnectOtherEpCd != scmEpCnect2.CnectOtherEpCd)resList.Add("CnectOtherEpCd");
			if(scmEpCnect1.CnectOtherEpNm != scmEpCnect2.CnectOtherEpNm)resList.Add("CnectOtherEpNm");
			if(scmEpCnect1.DiscDivCd != scmEpCnect2.DiscDivCd)resList.Add("DiscDivCd");

			return resList;
		}
	}
}
