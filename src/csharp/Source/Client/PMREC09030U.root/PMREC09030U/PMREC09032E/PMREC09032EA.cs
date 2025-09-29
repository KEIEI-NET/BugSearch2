using System;
using System.Collections;
using System.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerSearchPara
	/// <summary>
	///                      ���Ӑ挟�������p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ挟�������p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/02/14  (CSharp File Generated Date)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
    /// <br>             MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 �� ��</br>
    /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/08/19 ���C��</br>
    /// <br>             PCC���Зp���Ӑ�K�C�h�ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 ���юR</br>
    /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public class RecBgnGrpPara
	{
		/// <summary>��ƃR�[�h</summary>
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>���������i�O���[�v�R�[�h</summary>
		/// <remarks>0:�O���[�v����</remarks>
		private Int16 _brgnGoodsGrpCode;

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>���������i�O���[�v�^�C�g��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _brgnGoodsGrpTitle = "";

		/// <summary>���������i�O���[�v�R�����g�^�O</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _brgnGoodsGrpTag = "";

		/// <summary>���������i�O���[�v�R�����g</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _brgnGoodsGrpComment = "";

		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int64 CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int64 UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
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
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpCode
		/// <summary>���������i�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>0:�O���[�v����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������i�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 BrgnGoodsGrpCode
		{
			get{return _brgnGoodsGrpCode;}
			set{_brgnGoodsGrpCode = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpTitle
		/// <summary>���������i�O���[�v�^�C�g���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������i�O���[�v�^�C�g���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BrgnGoodsGrpTitle
		{
			get{return _brgnGoodsGrpTitle;}
			set{_brgnGoodsGrpTitle = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpTag
		/// <summary>���������i�O���[�v�R�����g�^�O�v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������i�O���[�v�R�����g�^�O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BrgnGoodsGrpTag
		{
			get{return _brgnGoodsGrpTag;}
			set{_brgnGoodsGrpTag = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpComment
		/// <summary>���������i�O���[�v�R�����g�v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������i�O���[�v�R�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BrgnGoodsGrpComment
		{
			get{return _brgnGoodsGrpComment;}
			set{_brgnGoodsGrpComment = value;}
		}


		/// <summary>
        /// ���������i�O���[�v�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
        /// <returns>RecBgnGrpPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RecBgnGrpPara()
		{
		}

		/// <summary>
        /// ���������i�O���[�v�����p�����[�^�N���X�R���X�g���N�^
		/// </summary>
        /// <param name="CreateDateTime">�쐬����</param>
        /// <param name="UpdateDateTime">�X�V����</param>
        /// <param name="LogicalDeleteCode">�_���폜�敪</param>
        /// <param name="InqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="InqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="BrgnGoodsGrpCode">���������i�O���[�v�R�[�h</param>
        /// <param name="DisplayOrder">�\������</param>
        /// <param name="BrgnGoodsGrpTitle">���������i�O���[�v�^�C�g��</param>
        /// <param name="BrgnGoodsGrpTag">���������i�O���[�v�R�����g�^�O</param>
        /// <param name="BrgnGoodsGrpComment">���������i�O���[�v�R�����g</param>
        /// <returns>RecBgnGrpPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        public RecBgnGrpPara(Int64 CreateDateTime, Int64 UpdateDateTime, Int32 LogicalDeleteCode, string InqOriginalEpCd, string InqOriginalSecCd, Int16 BrgnGoodsGrpCode, Int32 DisplayOrder, string BrgnGoodsGrpTitle, string BrgnGoodsGrpTag, string BrgnGoodsGrpComment)
        {
            this._createDateTime = CreateDateTime;
            this._updateDateTime = UpdateDateTime;
            this._logicalDeleteCode = LogicalDeleteCode;
            this._inqOriginalEpCd = InqOriginalEpCd;
            this._inqOriginalSecCd = InqOriginalSecCd;
            this._brgnGoodsGrpCode = BrgnGoodsGrpCode;
            this._displayOrder = DisplayOrder;
            this._brgnGoodsGrpTitle = BrgnGoodsGrpTitle;
            this._brgnGoodsGrpTag = BrgnGoodsGrpTag;
            this._brgnGoodsGrpComment = BrgnGoodsGrpComment;
           
        }

		/// <summary>
        /// ���������i�O���[�v�����p�����[�^�N���X��������
		/// </summary>
        /// <returns>RecBgnGrpPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RecBgnGrpPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public RecBgnGrpPara Clone()
		{
            return new RecBgnGrpPara(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._brgnGoodsGrpCode, this._displayOrder, this._brgnGoodsGrpTitle, this._brgnGoodsGrpTag, this._brgnGoodsGrpComment);
        }

		/// <summary>
        /// ���������i�O���[�v�����p�����[�^�N���X��r����
		/// </summary>
        /// <param name="target">��r�Ώۂ�RecBgnGrpPara�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpPara�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(RecBgnGrpPara target)
		{
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.BrgnGoodsGrpCode == target.BrgnGoodsGrpCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.BrgnGoodsGrpTitle == target.BrgnGoodsGrpTitle)
                 && (this.BrgnGoodsGrpTag == target.BrgnGoodsGrpTag)
                 && (this.BrgnGoodsGrpComment == target.BrgnGoodsGrpComment)
                 );
		}

		/// <summary>
        /// ���������i�O���[�v�����p�����[�^�N���X��r����
		/// </summary>
        /// <param name="recBgnGrpPara1">��r����RecBgnGrpPara�N���X�̃C���X�^���X</param>
        /// <param name="recBgnGrpPara2">��r����RecBgnGrpPara�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpPara�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static bool Equals(RecBgnGrpPara recBgnGrpPara1, RecBgnGrpPara recBgnGrpPara2)
		{
            return ((recBgnGrpPara1.CreateDateTime == recBgnGrpPara2.CreateDateTime)
                 && (recBgnGrpPara1.UpdateDateTime == recBgnGrpPara2.UpdateDateTime)
                 && (recBgnGrpPara1.LogicalDeleteCode == recBgnGrpPara2.LogicalDeleteCode)
                 && (recBgnGrpPara1.InqOriginalEpCd == recBgnGrpPara2.InqOriginalEpCd)
                 && (recBgnGrpPara1.InqOriginalSecCd == recBgnGrpPara2.InqOriginalSecCd)
                 && (recBgnGrpPara1.BrgnGoodsGrpCode == recBgnGrpPara2.BrgnGoodsGrpCode)
                 && (recBgnGrpPara1.DisplayOrder == recBgnGrpPara2.DisplayOrder)
                 && (recBgnGrpPara1.BrgnGoodsGrpTitle == recBgnGrpPara2.BrgnGoodsGrpTitle)
                 && (recBgnGrpPara1.BrgnGoodsGrpTag == recBgnGrpPara2.BrgnGoodsGrpTag)
                 && (recBgnGrpPara1.BrgnGoodsGrpComment == recBgnGrpPara2.BrgnGoodsGrpComment)
                 );
		}
		/// <summary>
        /// ���������i�O���[�v���������p�����[�^�N���X��r����
		/// </summary>
        /// <param name="target">��r�Ώۂ�RecBgnGrpRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public ArrayList Compare(RecBgnGrpPara target)
		{
			ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.BrgnGoodsGrpCode != target.BrgnGoodsGrpCode) resList.Add("BrgnGoodsGrpCode");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.BrgnGoodsGrpTitle != target.BrgnGoodsGrpTitle) resList.Add("BrgnGoodsGrpTitle");
            if (this.BrgnGoodsGrpTag != target.BrgnGoodsGrpTag) resList.Add("BrgnGoodsGrpTag");
            if (this.BrgnGoodsGrpComment != target.BrgnGoodsGrpComment) resList.Add("BrgnGoodsGrpComment");

			return resList;
		}

		/// <summary>
        /// ���������i�O���[�v�����p�����[�^�N���X��r����
		/// </summary>
        /// <param name="recBgnGrpPara1">��r����RecBgnGrpRet�N���X�̃C���X�^���X</param>
        /// <param name="recBgnGrpPara2">��r����RecBgnGrpRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGrpRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        public static ArrayList Compare(RecBgnGrpPara recBgnGrpPara1, RecBgnGrpPara recBgnGrpPara2)
		{
			ArrayList resList = new ArrayList();
            if (recBgnGrpPara1.CreateDateTime != recBgnGrpPara2.CreateDateTime) resList.Add("CreateDateTime");
            if (recBgnGrpPara1.UpdateDateTime != recBgnGrpPara2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (recBgnGrpPara1.LogicalDeleteCode != recBgnGrpPara2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (recBgnGrpPara1.InqOriginalEpCd != recBgnGrpPara2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (recBgnGrpPara1.InqOriginalSecCd != recBgnGrpPara2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (recBgnGrpPara1.BrgnGoodsGrpCode != recBgnGrpPara2.BrgnGoodsGrpCode) resList.Add("BrgnGoodsGrpCode");
            if (recBgnGrpPara1.DisplayOrder != recBgnGrpPara2.DisplayOrder) resList.Add("DisplayOrder");
            if (recBgnGrpPara1.BrgnGoodsGrpTitle != recBgnGrpPara2.BrgnGoodsGrpTitle) resList.Add("BrgnGoodsGrpTitle");
            if (recBgnGrpPara1.BrgnGoodsGrpTag != recBgnGrpPara2.BrgnGoodsGrpTag) resList.Add("BrgnGoodsGrpTag");
            if (recBgnGrpPara1.BrgnGoodsGrpComment != recBgnGrpPara2.BrgnGoodsGrpComment) resList.Add("BrgnGoodsGrpComment");
            
            return resList;
		}
	}
}
