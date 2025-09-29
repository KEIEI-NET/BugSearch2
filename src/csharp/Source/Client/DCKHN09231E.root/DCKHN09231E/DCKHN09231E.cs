using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcptAnOdrTtlSt
    /// <summary>
    ///                      �󔭒��Ǘ��S�̐ݒ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󔭒��Ǘ��S�̐ݒ�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/11  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/06/06 30415 �ēc �ύK</br>
    /// <br>        	         �E�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��</br>    
    /// </remarks>
    public class AcptAnOdrTtlSt
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�I�[���O�͑S��</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// <summary>�����ԍ��\��</summary>
		/// <remarks>1.����� 2.����́i7���j�{�󒍔ԍ��i��7���j�B�B�B</remarks>
		private Int32 _orderNumberCompo;
           --- DEL 2008/06/06 --------------------------------<<<<< */
        
		/// <summary>���ϐ����f�敪</summary>
		/// <remarks>0:�o�א� 1:�󒍐�</remarks>
		private Int32 _estmCountReflectDiv;

		/// <summary>�󒍓`�[���s�敪</summary>
		/// <remarks>0:���Ȃ� 1:����</remarks>
		private Int32 _acpOdrrSlipPrtDiv;

		/// <summary>�e�`�w�����敪</summary>
		/// <remarks>0:���Ȃ� 1:����</remarks>
		private Int32 _faxOrderDiv;

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// <summary>�h�b�g�N�������敪</summary>
		/// <remarks>0:���Ȃ� 1:����</remarks>
		private Int32 _dotKulOrderDiv;
           --- DEL 2008/06/06 --------------------------------<<<<< */


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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�I�[���O�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// public propaty name  :  OrderNumberCompo
		/// <summary>�����ԍ��\���v���p�e�B</summary>
		/// <value>1.����� 2.����́i7���j�{�󒍔ԍ��i��7���j�B�B�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ԍ��\���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OrderNumberCompo
		{
			get{return _orderNumberCompo;}
			set{_orderNumberCompo = value;}
		}
           --- DEL 2008/06/06 --------------------------------<<<<< */
        

		/// public propaty name  :  EstmCountReflectDiv
		/// <summary>���ϐ����f�敪�v���p�e�B</summary>
		/// <value>0:�o�א� 1:�󒍐�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϐ����f�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstmCountReflectDiv
		{
			get{return _estmCountReflectDiv;}
			set{_estmCountReflectDiv = value;}
		}

		/// public propaty name  :  AcpOdrrSlipPrtDiv
		/// <summary>�󒍓`�[���s�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍓`�[���s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcpOdrrSlipPrtDiv
		{
			get{return _acpOdrrSlipPrtDiv;}
			set{_acpOdrrSlipPrtDiv = value;}
		}

		/// public propaty name  :  FaxOrderDiv
		/// <summary>�e�`�w�����敪�v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�`�w�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FaxOrderDiv
		{
			get{return _faxOrderDiv;}
			set{_faxOrderDiv = value;}
		}

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// public propaty name  :  DotKulOrderDiv
		/// <summary>�h�b�g�N�������敪�v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �h�b�g�N�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DotKulOrderDiv
		{
			get{return _dotKulOrderDiv;}
			set{_dotKulOrderDiv = value;}
		}
           --- DEL 2008/06/06 --------------------------------<<<<< */
        

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ�R���X�g���N�^
		/// </summary>
		/// <returns>AcptAnOdrTtlSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AcptAnOdrTtlSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public AcptAnOdrTtlSt()
		{
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="estmCountReflectDiv">���ϐ����f�敪</param>
        /// <param name="acpOdrrSlipPrtDiv">�󒍓`�[���s�敪</param>
        /// <param name="faxOrderDiv">�e�`�w�����敪</param>
		/// <returns>AcptAnOdrTtlSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AcptAnOdrTtlSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public AcptAnOdrTtlSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 estmCountReflectDiv,Int32 acpOdrrSlipPrtDiv ,Int32 faxOrderDiv)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;              // ADD 2008/06/06
            //this._orderNumberCompo = orderNumberCompo;  // DEL 2008/06/06
            this._estmCountReflectDiv = estmCountReflectDiv;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._faxOrderDiv = faxOrderDiv;
            //this._dotKulOrderDiv = dotKulOrderDiv;      // DEL 2008/06/06
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ蕡������
		/// </summary>
		/// <returns>AcptAnOdrTtlSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AcptAnOdrTtlSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public AcptAnOdrTtlSt Clone()
		{
			return new AcptAnOdrTtlSt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._estmCountReflectDiv,this._acpOdrrSlipPrtDiv,this._faxOrderDiv);
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�AcptAnOdrTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AcptAnOdrTtlSt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(AcptAnOdrTtlSt target)
		{
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)                  // ADD 2008/06/06
                //&& (this.OrderNumberCompo == target.OrderNumberCompo)       // DEL 2008/06/06
                 && (this.EstmCountReflectDiv == target.EstmCountReflectDiv)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.FaxOrderDiv == target.FaxOrderDiv)
                //&& (this.DotKulOrderDiv == target.DotKulOrderDiv)           // DEL 2008/06/06 
                 );
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ��r����
		/// </summary>
		/// <param name="acptAnOdrTtlSt1">
		///                    ��r����AcptAnOdrTtlSt�N���X�̃C���X�^���X
		/// </param>
		/// <param name="acptAnOdrTtlSt2">��r����AcptAnOdrTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AcptAnOdrTtlSt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(AcptAnOdrTtlSt acptAnOdrTtlSt1, AcptAnOdrTtlSt acptAnOdrTtlSt2)
		{
			return ((acptAnOdrTtlSt1.CreateDateTime == acptAnOdrTtlSt2.CreateDateTime)
				 && (acptAnOdrTtlSt1.UpdateDateTime == acptAnOdrTtlSt2.UpdateDateTime)
				 && (acptAnOdrTtlSt1.EnterpriseCode == acptAnOdrTtlSt2.EnterpriseCode)
				 && (acptAnOdrTtlSt1.FileHeaderGuid == acptAnOdrTtlSt2.FileHeaderGuid)
				 && (acptAnOdrTtlSt1.UpdEmployeeCode == acptAnOdrTtlSt2.UpdEmployeeCode)
				 && (acptAnOdrTtlSt1.UpdAssemblyId1 == acptAnOdrTtlSt2.UpdAssemblyId1)
				 && (acptAnOdrTtlSt1.UpdAssemblyId2 == acptAnOdrTtlSt2.UpdAssemblyId2)
				 && (acptAnOdrTtlSt1.LogicalDeleteCode == acptAnOdrTtlSt2.LogicalDeleteCode)
                 && (acptAnOdrTtlSt1.SectionCode == acptAnOdrTtlSt2.SectionCode)                  // ADD 2008/06/06 
                 //&& (acptAnOdrTtlSt1.OrderNumberCompo == acptAnOdrTtlSt2.OrderNumberCompo)      // DEL 2008/06/06
                 && (acptAnOdrTtlSt1.EstmCountReflectDiv == acptAnOdrTtlSt2.EstmCountReflectDiv)
                 && (acptAnOdrTtlSt1.AcpOdrrSlipPrtDiv == acptAnOdrTtlSt2.AcpOdrrSlipPrtDiv)
                 && (acptAnOdrTtlSt1.FaxOrderDiv == acptAnOdrTtlSt2.FaxOrderDiv)
                //&& (acptAnOdrTtlSt1.DotKulOrderDiv == acptAnOdrTtlSt2.DotKulOrderDiv)           // DEL 2008/06/06
                 );
		}
		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�AcptAnOdrTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AcptAnOdrTtlSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(AcptAnOdrTtlSt target)
		{
			ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");                         // ADD 2008/06/06
            //if (this.OrderNumberCompo != target.OrderNumberCompo) resList.Add("OrderNumberCompo");        // DEL 2008/06/06
            if (this.EstmCountReflectDiv != target.EstmCountReflectDiv) resList.Add("EstmCountReflectDiv");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.FaxOrderDiv != target.FaxOrderDiv) resList.Add("FaxOrderDiv");
            //if (this.DotKulOrderDiv != target.DotKulOrderDiv) resList.Add("DotKulOrderDiv");              // DEL 2008/06/06

			return resList;
		}

		/// <summary>
		/// �󔭒��Ǘ��S�̐ݒ��r����
		/// </summary>
		/// <param name="acptAnOdrTtlSt1">��r����AcptAnOdrTtlSt�N���X�̃C���X�^���X</param>
		/// <param name="acptAnOdrTtlSt2">��r����AcptAnOdrTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AcptAnOdrTtlSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(AcptAnOdrTtlSt acptAnOdrTtlSt1, AcptAnOdrTtlSt acptAnOdrTtlSt2)
		{
			ArrayList resList = new ArrayList();
            if (acptAnOdrTtlSt1.CreateDateTime != acptAnOdrTtlSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (acptAnOdrTtlSt1.UpdateDateTime != acptAnOdrTtlSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (acptAnOdrTtlSt1.EnterpriseCode != acptAnOdrTtlSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acptAnOdrTtlSt1.FileHeaderGuid != acptAnOdrTtlSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (acptAnOdrTtlSt1.UpdEmployeeCode != acptAnOdrTtlSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (acptAnOdrTtlSt1.UpdAssemblyId1 != acptAnOdrTtlSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (acptAnOdrTtlSt1.UpdAssemblyId2 != acptAnOdrTtlSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (acptAnOdrTtlSt1.LogicalDeleteCode != acptAnOdrTtlSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (acptAnOdrTtlSt1.SectionCode != acptAnOdrTtlSt2.SectionCode) resList.Add("SectionCode");                          // ADD 2008/06/06
            //if (acptAnOdrTtlSt1.OrderNumberCompo != acptAnOdrTtlSt2.OrderNumberCompo) resList.Add("OrderNumberCompo");         // DEL 2008/06/06
            if (acptAnOdrTtlSt1.EstmCountReflectDiv != acptAnOdrTtlSt2.EstmCountReflectDiv) resList.Add("EstmCountReflectDiv");
            if (acptAnOdrTtlSt1.AcpOdrrSlipPrtDiv != acptAnOdrTtlSt2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (acptAnOdrTtlSt1.FaxOrderDiv != acptAnOdrTtlSt2.FaxOrderDiv) resList.Add("FaxOrderDiv");
            //if (acptAnOdrTtlSt1.DotKulOrderDiv != acptAnOdrTtlSt2.DotKulOrderDiv) resList.Add("DotKulOrderDiv");               // DEL 2008/06/06

			return resList;
		}
	}
}
