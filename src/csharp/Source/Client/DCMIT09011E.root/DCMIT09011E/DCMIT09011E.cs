using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   EstimateDefSet
	/// <summary>
	///                      ���Ϗ����l�ݒ�
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ϗ����l�ݒ�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/01/21  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/06/03 30415 �ēc �ύK</br>
    /// <br>        	         �E�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��</br>  
	/// </remarks>
	public class EstimateDefSet
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

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

        /* --- DEL 2008/06/03 -------------------------------->>>>>
        /// <summary>�[�������敪</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _fractionProcCd;

        /// <summary>����œ]�ŕ���</summary>
        private Int32 _consTaxLayMethod;
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// <summary>����ň���敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _consTaxPrintDiv;

		/// <summary>�艿����敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _listPricePrintDiv;

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <summary>�����\���敪�P</summary>
		/// <remarks>0:����@1:�a��</remarks>
		private Int32 _eraNameDispCd1;
        
        /// <summary>���ύ��v����敪</summary>
		/// <remarks>0:�ӂ̂݁@1:���ז����@2:���v���@3:������Ȃ�</remarks>
		private Int32 _estimateTotalPrtCd;

		/// <summary>���Ϗ�����敪</summary>
		/// <remarks>0:�ʏ� 1:1�łɓ���Ȃ��ꍇ���וʎ� 2:���וʎ�</remarks>
		private Int32 _estimateFormPrtCd;

		/// <summary>�h�̈���敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _honorificTitlePrtCd;

		/// <summary>���ψ˗��敪</summary>
		/// <remarks>0:�ʏ� 1:1�łɓ���Ȃ��ꍇ���וʎ� 2:���וʎ�</remarks>
		private Int32 _estimateRequestCd;
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// <summary>���Ϗ��ԍ��̔ԋ敪</summary>
		/// <remarks>0:�L��@1:����</remarks>
		private Int32 _estmFormNoPickDiv;


		/// <summary>���σ^�C�g���P</summary>
		private string _estimateTitle1 = "";


		/// <summary>���ϔ��l�P</summary>
		private string _estimateNote1 = "";

		/// <summary>���ϔ��l�Q</summary>
		private string _estimateNote2 = "";

		/// <summary>���ϔ��l�R</summary>
		private string _estimateNote3 = "";


		/// <summary>���Ϗ����s�敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _estimatePrtDiv;

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <summary>���ψ˗������s�敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _estimateReqPrtDiv;

		/// <summary>���ϊm�F�����s�敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _estimateConfPrtDiv;
           --- DEL 2008/06/03 --------------------------------<<<<< */

        /// <summary>�e�`�w���ϋ敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _faxEstimatetDiv;

        // --- ADD 2008/06/03 -------------------------------->>>>>
        /// <summary>�i�Ԉ󎚋敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _partsNoPrtCd;

        /// <summary>�I�v�V�����󎚋敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _optionPringDivCd;

        /// <summary>���i�I���敪</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _partsSelectDivCd;

        /// <summary>���i�����敪</summary>
        /// <remarks>0:���i����,1:�i�Ԍ���</remarks>
        private Int32 _partsSearchDivCd;

        /// <summary>���σf�[�^�쐬�敪</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _estimateDtCreateDiv;

        /// <summary>���Ϗ��L������</summary>
        private Int32 _estimateValidityTerm;

        /// <summary>�|���g�p�敪</summary>
        /// <remarks>0:�������艿 1:�|���w��,2:�|���ݒ�</remarks>
        private Int32 _rateUseCode;
        // --- ADD 2008/06/03 --------------------------------<<<<< 


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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// public propaty name  :  FractionProcCd
		/// <summary>�[�������敪�v���p�e�B</summary>
		/// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>����œ]�ŕ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get{return _consTaxLayMethod;}
			set{_consTaxLayMethod = value;}
		}
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// public propaty name  :  ConsTaxPrintDiv
		/// <summary>����ň���敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ň���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ConsTaxPrintDiv
		{
			get{return _consTaxPrintDiv;}
			set{_consTaxPrintDiv = value;}
		}

		/// public propaty name  :  ListPricePrintDiv
		/// <summary>�艿����敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ListPricePrintDiv
		{
			get{return _listPricePrintDiv;}
			set{_listPricePrintDiv = value;}
		}

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// public propaty name  :  EraNameDispCd1
		/// <summary>�����\���敪�P�v���p�e�B</summary>
		/// <value>0:����@1:�a��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���敪�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EraNameDispCd1
		{
			get{return _eraNameDispCd1;}
			set{_eraNameDispCd1 = value;}
		}

		/// public propaty name  :  EstimateTotalPrtCd
		/// <summary>���ύ��v����敪�v���p�e�B</summary>
		/// <value>0:�ӂ̂݁@1:���ז����@2:���v���@3:������Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ύ��v����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimateTotalPrtCd
		{
			get{return _estimateTotalPrtCd;}
			set{_estimateTotalPrtCd = value;}
		}

		/// public propaty name  :  EstimateFormPrtCd
		/// <summary>���Ϗ�����敪�v���p�e�B</summary>
		/// <value>0:�ʏ� 1:1�łɓ���Ȃ��ꍇ���וʎ� 2:���וʎ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ϗ�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimateFormPrtCd
		{
			get{return _estimateFormPrtCd;}
			set{_estimateFormPrtCd = value;}
		}

		/// public propaty name  :  HonorificTitlePrtCd
		/// <summary>�h�̈���敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �h�̈���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HonorificTitlePrtCd
		{
			get{return _honorificTitlePrtCd;}
			set{_honorificTitlePrtCd = value;}
		}

		/// public propaty name  :  EstimateRequestCd
		/// <summary>���ψ˗��敪�v���p�e�B</summary>
		/// <value>0:�ʏ� 1:1�łɓ���Ȃ��ꍇ���וʎ� 2:���וʎ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ψ˗��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimateRequestCd
		{
			get{return _estimateRequestCd;}
			set{_estimateRequestCd = value;}
		}
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// public propaty name  :  EstmFormNoPickDiv
		/// <summary>���Ϗ��ԍ��̔ԋ敪�v���p�e�B</summary>
		/// <value>0:�L��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ϗ��ԍ��̔ԋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstmFormNoPickDiv
		{
			get{return _estmFormNoPickDiv;}
			set{_estmFormNoPickDiv = value;}
		}



		/// public propaty name  :  EstimateTitle1
		/// <summary>���σ^�C�g���P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���σ^�C�g���P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EstimateTitle1
		{
			get{return _estimateTitle1;}
			set{_estimateTitle1 = value;}
		}


		/// public propaty name  :  EstimateNote1
		/// <summary>���ϔ��l�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϔ��l�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EstimateNote1
		{
			get{return _estimateNote1;}
			set{_estimateNote1 = value;}
		}

		/// public propaty name  :  EstimateNote2
		/// <summary>���ϔ��l�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϔ��l�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EstimateNote2
		{
			get{return _estimateNote2;}
			set{_estimateNote2 = value;}
		}

		/// public propaty name  :  EstimateNote3
		/// <summary>���ϔ��l�R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϔ��l�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EstimateNote3
		{
			get{return _estimateNote3;}
			set{_estimateNote3 = value;}
		}


		/// public propaty name  :  EstimatePrtDiv
		/// <summary>���Ϗ����s�敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ϗ����s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimatePrtDiv
		{
			get{return _estimatePrtDiv;}
			set{_estimatePrtDiv = value;}
		}

        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// public propaty name  :  EstimateReqPrtDiv
		/// <summary>���ψ˗������s�敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ψ˗������s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimateReqPrtDiv
		{
			get{return _estimateReqPrtDiv;}
			set{_estimateReqPrtDiv = value;}
		}

		/// public propaty name  :  EstimateConfPrtDiv
		/// <summary>���ϊm�F�����s�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ϊm�F�����s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimateConfPrtDiv
		{
			get{return _estimateConfPrtDiv;}
			set{_estimateConfPrtDiv = value;}
		}
           --- DEL 2008/06/03 --------------------------------<<<<< */
        
        /// public propaty name  :  FaxEstimatetDiv
		/// <summary>�e�`�w���ϋ敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�`�w���ϋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FaxEstimatetDiv
		{
			get{return _faxEstimatetDiv;}
			set{_faxEstimatetDiv = value;}
		}

        // --- ADD 2008/06/03 -------------------------------->>>>>
        /// public propaty name  :  PartsNoPrtCd
        /// <summary>�i�Ԉ󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  OptionPringDivCd
        /// <summary>�I�v�V�����󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�v�V�����󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 OptionPringDivCd
        {
            get { return _optionPringDivCd; }
            set { _optionPringDivCd = value; }
        }

        /// public propaty name  :  PartsSelectDivCd
        /// <summary>���i�I���敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���敪�v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 PartsSelectDivCd
        {
            get { return _partsSelectDivCd; }
            set { _partsSelectDivCd = value; }
        }

        /// public propaty name  :  PartsSearchDivCd
        /// <summary>���i�����敪�v���p�e�B</summary>
        /// <value>0:���i����,1:�i�Ԍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����敪�v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 PartsSearchDivCd
        {
            get { return _partsSearchDivCd; }
            set { _partsSearchDivCd = value; }
        }

        /// public propaty name  :  EstimateDtCreateDiv
        /// <summary>���σf�[�^�쐬�敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^�쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 EstimateDtCreateDiv
        {
            get { return _estimateDtCreateDiv; }
            set { _estimateDtCreateDiv = value; }
        }

        /// public propaty name  :  EstimateValidityTerm
        /// <summary>���Ϗ��L�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��L�������v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 EstimateValidityTerm
        {
            get { return _estimateValidityTerm; }
            set { _estimateValidityTerm = value; }
        }

        /// public propaty name  :  RateUseCode
        /// <summary>�|���g�p�敪�v���p�e�B</summary>
        /// <value>0:�������艿 1:�|���w��,2:�|���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   �ēc �ύK</br>
        /// </remarks>
        public Int32 RateUseCode
        {
            get { return _rateUseCode; }
            set { _rateUseCode = value; }
        }
        // --- ADD 2008/06/03 --------------------------------<<<<< 


		/// <summary>
		/// ���Ϗ����l�ݒ�R���X�g���N�^
		/// </summary>
		/// <returns>EstimateDefSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateDefSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public EstimateDefSet()
		{
		}

		/// <summary>
		/// ���Ϗ����l�ݒ�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="sectionCode">���_�R�[�h</param>
        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <param name="fractionProcCd">�[�������敪(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
		/// <param name="consTaxLayMethod">����œ]�ŕ���</param>
           --- DEL 2008/06/03 --------------------------------<<<<< */
        /// <param name="consTaxPrintDiv">����ň���敪(0:����@1:���Ȃ�)</param>
		/// <param name="listPricePrintDiv">�艿����敪(0:���Ȃ��@1:����)</param>
        /* --- DEL 2008/06/03 -------------------------------->>>>>
		/// <param name="eraNameDispCd1">�����\���敪�P(0:����@1:�a��)</param>
		/// <param name="estimateTotalPrtCd">���ύ��v����敪(0:�ӂ̂݁@1:���ז����@2:���v���@3:������Ȃ�)</param>
		/// <param name="estimateFormPrtCd">���Ϗ�����敪(0:�ʏ� 1:1�łɓ���Ȃ��ꍇ���וʎ� 2:���וʎ�)</param>
		/// <param name="honorificTitlePrtCd">�h�̈���敪(0:����@1:���Ȃ�)</param>
		/// <param name="estimateRequestCd">���ψ˗��敪(0:�ʏ� 1:1�łɓ���Ȃ��ꍇ���וʎ� 2:���וʎ�)</param>
	           --- DEL 2008/06/03 --------------------------------<<<<< */
        /// <param name="estmFormNoPickDiv">���Ϗ��ԍ��̔ԋ敪(0:�L��@1:����)</param>
		/// <param name="estimateTitle1">���σ^�C�g���P</param>
		/// <param name="estimateNote1">���ϔ��l�P</param>
		/// <param name="estimateNote2">���ϔ��l�Q</param>
		/// <param name="estimateNote3">���ϔ��l�R</param>
		/// <param name="estimatePrtDiv">���Ϗ����s�敪(0:����@1:���Ȃ�)</param>
		/// <param name="estimateReqPrtDiv">���ψ˗������s�敪(0:����@1:���Ȃ�)</param>
		/// <param name="estimateConfPrtDiv">���ϊm�F�����s�敪(0:���Ȃ��@1:����)</param>
		/// <param name="faxEstimatetDiv">�e�`�w���ϋ敪(0:���Ȃ��@1:����)</param>
        /// <param name="faxEstimatetDiv">�i�Ԉ󎚋敪(0:���Ȃ��@1:����)</param>
        /// <param name="faxEstimatetDiv">�I�v�V�����󎚋敪(0:���Ȃ��@1:����)</param>
        /// <param name="faxEstimatetDiv">���i�I���敪(0:����,1:���Ȃ�)</param>
        /// <param name="faxEstimatetDiv">���i�����敪(0:���i����,1:�i�Ԍ���)</param>
        /// <param name="faxEstimatetDiv">���σf�[�^�쐬�敪(0:����,1:���Ȃ�)</param>
        /// <param name="faxEstimatetDiv">���Ϗ��L������</param>
        /// <param name="faxEstimatetDiv">�|���g�p�敪(0:�������艿 1:�|���w��,2:�|���ݒ�)</param>		
        /// <returns>EstimateDefSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateDefSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        //public EstimateDefSet(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 fractionProcCd,Int32 consTaxLayMethod,Int32 consTaxPrintDiv,Int32 listPricePrintDiv,Int32 eraNameDispCd1,Int32 estimateTotalPrtCd,Int32 estimateFormPrtCd,Int32 honorificTitlePrtCd,Int32 estimateRequestCd,Int32 estmFormNoPickDiv,string estimateTitle1,string estimateNote1,string estimateNote2,string estimateNote3,Int32 estimatePrtDiv,Int32 estimateReqPrtDiv,Int32 estimateConfPrtDiv,Int32 faxEstimatetDiv) // DEL 2008/06/03
        public EstimateDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 consTaxPrintDiv, Int32 listPricePrintDiv, Int32 estmFormNoPickDiv,  string estimateTitle1,  string estimateNote1, string estimateNote2, string estimateNote3, Int32 estimatePrtDiv, Int32 faxEstimatetDiv, Int32 partsNoPrtCd, Int32 optionPringDivCd, Int32 partsSelectDivCd, Int32 partsSearchDivCd, Int32 estimateDtCreateDiv, Int32 estimateValidityTerm, Int32 rateUseCode) // ADD 2008/06/03
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
            /* --- DEL 2008/06/03 -------------------------------->>>>>
                this._fractionProcCd = fractionProcCd;
                this._consTaxLayMethod = consTaxLayMethod;
               --- DEL 2008/06/03 --------------------------------<<<<< */
            this._consTaxPrintDiv = consTaxPrintDiv;
			this._listPricePrintDiv = listPricePrintDiv;
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			this._eraNameDispCd1 = eraNameDispCd1;
			this._estimateTotalPrtCd = estimateTotalPrtCd;
			this._estimateFormPrtCd = estimateFormPrtCd;
			this._honorificTitlePrtCd = honorificTitlePrtCd;
			this._estimateRequestCd = estimateRequestCd;
               --- DEL 2008/06/03 --------------------------------<<<<< */
            this._estmFormNoPickDiv = estmFormNoPickDiv;
			this._estimateTitle1 = estimateTitle1;
			this._estimateNote1 = estimateNote1;
			this._estimateNote2 = estimateNote2;
			this._estimateNote3 = estimateNote3;
			this._estimatePrtDiv = estimatePrtDiv;
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			this._estimateReqPrtDiv = estimateReqPrtDiv;
			this._estimateConfPrtDiv = estimateConfPrtDiv;
               --- DEL 2008/06/03 --------------------------------<<<<< */
            this._faxEstimatetDiv = faxEstimatetDiv;
            // --- ADD 2008/06/03 -------------------------------->>>>>
            this._partsNoPrtCd = partsNoPrtCd;
            this._optionPringDivCd = optionPringDivCd;
            this._partsSelectDivCd = partsSelectDivCd;
            this._partsSearchDivCd = partsSearchDivCd;
            this._estimateDtCreateDiv = estimateDtCreateDiv;
            this._estimateValidityTerm = estimateValidityTerm;
            this._rateUseCode = rateUseCode;
            // --- ADD 2008/06/03 --------------------------------<<<<< 
		}

		/// <summary>
		/// ���Ϗ����l�ݒ蕡������
		/// </summary>
		/// <returns>EstimateDefSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����EstimateDefSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public EstimateDefSet Clone()
		{
            // DEL 2008/06/03
            //return new EstimateDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._fractionProcCd, this._consTaxLayMethod, this._consTaxPrintDiv, this._listPricePrintDiv, this._eraNameDispCd1, this._estimateTotalPrtCd, this._estimateFormPrtCd, this._honorificTitlePrtCd, this._estimateRequestCd, this._estmFormNoPickDiv, this._estimateTitle1, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimatePrtDiv, this._estimateReqPrtDiv, this._estimateConfPrtDiv, this._faxEstimatetDiv);
            // ADD 2008/06/03
            return new EstimateDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._consTaxPrintDiv, this._listPricePrintDiv, this._estmFormNoPickDiv,  this._estimateTitle1, this._estimateNote1, this._estimateNote2, this._estimateNote3, this._estimatePrtDiv, this._faxEstimatetDiv, this._partsNoPrtCd, this._optionPringDivCd, this._partsSelectDivCd, this._partsSearchDivCd, this._estimateDtCreateDiv, this._estimateValidityTerm, this._rateUseCode);
		}

		/// <summary>
		/// ���Ϗ����l�ݒ��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�EstimateDefSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateDefSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(EstimateDefSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                   --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (this.ConsTaxPrintDiv == target.ConsTaxPrintDiv)
				 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EstimateTotalPrtCd == target.EstimateTotalPrtCd)
                 && (this.EstimateFormPrtCd == target.EstimateFormPrtCd)
                 && (this.HonorificTitlePrtCd == target.HonorificTitlePrtCd)
                 && (this.EstimateRequestCd == target.EstimateRequestCd)
                  --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (this.EstmFormNoPickDiv == target.EstmFormNoPickDiv)
				 && (this.EstimateTitle1 == target.EstimateTitle1)
				 && (this.EstimateNote1 == target.EstimateNote1)
				 && (this.EstimateNote2 == target.EstimateNote2)
				 && (this.EstimateNote3 == target.EstimateNote3)
				 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
				 && (this.EstimateReqPrtDiv == target.EstimateReqPrtDiv)
				 && (this.EstimateConfPrtDiv == target.EstimateConfPrtDiv)
                    --- DEL 2008/06/03 --------------------------------<<<<< */
				 && (this.FaxEstimatetDiv == target.FaxEstimatetDiv)
                 // --- ADD 2008/06/03 -------------------------------->>>>>
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.OptionPringDivCd == target.OptionPringDivCd)
                 && (this.PartsSelectDivCd == target.PartsSelectDivCd)
                 && (this.PartsSearchDivCd == target.PartsSearchDivCd)
                 && (this.EstimateDtCreateDiv == target.EstimateDtCreateDiv)
                 && (this.EstimateValidityTerm == target.EstimateValidityTerm)
                 && (this.RateUseCode == target.RateUseCode)
                 // --- ADD 2008/06/03 --------------------------------<<<<< 
                 );
		}

		/// <summary>
		/// ���Ϗ����l�ݒ��r����
		/// </summary>
		/// <param name="estimateDefSet1">
		///                    ��r����EstimateDefSet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="estimateDefSet2">��r����EstimateDefSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateDefSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(EstimateDefSet estimateDefSet1, EstimateDefSet estimateDefSet2)
		{
			return ((estimateDefSet1.CreateDateTime == estimateDefSet2.CreateDateTime)
				 && (estimateDefSet1.UpdateDateTime == estimateDefSet2.UpdateDateTime)
				 && (estimateDefSet1.EnterpriseCode == estimateDefSet2.EnterpriseCode)
				 && (estimateDefSet1.FileHeaderGuid == estimateDefSet2.FileHeaderGuid)
				 && (estimateDefSet1.UpdEmployeeCode == estimateDefSet2.UpdEmployeeCode)
				 && (estimateDefSet1.UpdAssemblyId1 == estimateDefSet2.UpdAssemblyId1)
				 && (estimateDefSet1.UpdAssemblyId2 == estimateDefSet2.UpdAssemblyId2)
				 && (estimateDefSet1.LogicalDeleteCode == estimateDefSet2.LogicalDeleteCode)
				 && (estimateDefSet1.SectionCode == estimateDefSet2.SectionCode)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (estimateDefSet1.FractionProcCd == estimateDefSet2.FractionProcCd)
                 && (estimateDefSet1.ConsTaxLayMethod == estimateDefSet2.ConsTaxLayMethod)
                    --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (estimateDefSet1.ConsTaxPrintDiv == estimateDefSet2.ConsTaxPrintDiv)
				 && (estimateDefSet1.ListPricePrintDiv == estimateDefSet2.ListPricePrintDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
                 && (estimateDefSet1.EraNameDispCd1 == estimateDefSet2.EraNameDispCd1)
                 && (estimateDefSet1.EstimateTotalPrtCd == estimateDefSet2.EstimateTotalPrtCd)
                 && (estimateDefSet1.EstimateFormPrtCd == estimateDefSet2.EstimateFormPrtCd)
                 && (estimateDefSet1.HonorificTitlePrtCd == estimateDefSet2.HonorificTitlePrtCd)
                 && (estimateDefSet1.EstimateRequestCd == estimateDefSet2.EstimateRequestCd)
                   --- DEL 2008/06/03 --------------------------------<<<<< */
                 && (estimateDefSet1.EstmFormNoPickDiv == estimateDefSet2.EstmFormNoPickDiv)
				 && (estimateDefSet1.EstimateTitle1 == estimateDefSet2.EstimateTitle1)
				 && (estimateDefSet1.EstimateNote1 == estimateDefSet2.EstimateNote1)
				 && (estimateDefSet1.EstimateNote2 == estimateDefSet2.EstimateNote2)
				 && (estimateDefSet1.EstimateNote3 == estimateDefSet2.EstimateNote3)
				 && (estimateDefSet1.EstimatePrtDiv == estimateDefSet2.EstimatePrtDiv)
                 /* --- DEL 2008/06/03 -------------------------------->>>>>
				 && (estimateDefSet1.EstimateReqPrtDiv == estimateDefSet2.EstimateReqPrtDiv)
				 && (estimateDefSet1.EstimateConfPrtDiv == estimateDefSet2.EstimateConfPrtDiv)
                    --- DEL 2008/06/03 --------------------------------<<<<< */
				 && (estimateDefSet1.FaxEstimatetDiv == estimateDefSet2.FaxEstimatetDiv)
                 // --- ADD 2008/06/03 -------------------------------->>>>>
                 && (estimateDefSet1.PartsNoPrtCd == estimateDefSet2.PartsNoPrtCd)
                 && (estimateDefSet1.OptionPringDivCd == estimateDefSet2.OptionPringDivCd)
                 && (estimateDefSet1.PartsSelectDivCd == estimateDefSet2.PartsSelectDivCd)
                 && (estimateDefSet1.PartsSearchDivCd == estimateDefSet2.PartsSearchDivCd)
                 && (estimateDefSet1.EstimateDtCreateDiv == estimateDefSet2.EstimateDtCreateDiv)
                 && (estimateDefSet1.EstimateValidityTerm == estimateDefSet2.EstimateValidityTerm)
                 && (estimateDefSet1.RateUseCode == estimateDefSet2.RateUseCode)
                 // --- ADD 2008/06/03 --------------------------------<<<<< 
                 );
		}
		/// <summary>
		/// ���Ϗ����l�ݒ��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�EstimateDefSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateDefSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(EstimateDefSet target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (this.ConsTaxPrintDiv != target.ConsTaxPrintDiv)resList.Add("ConsTaxPrintDiv");
			if(this.ListPricePrintDiv != target.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(this.EraNameDispCd1 != target.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(this.EstimateTotalPrtCd != target.EstimateTotalPrtCd)resList.Add("EstimateTotalPrtCd");
			if(this.EstimateFormPrtCd != target.EstimateFormPrtCd)resList.Add("EstimateFormPrtCd");
			if(this.HonorificTitlePrtCd != target.HonorificTitlePrtCd)resList.Add("HonorificTitlePrtCd");
			if(this.EstimateRequestCd != target.EstimateRequestCd)resList.Add("EstimateRequestCd");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (this.EstmFormNoPickDiv != target.EstmFormNoPickDiv)resList.Add("EstmFormNoPickDiv");
			if(this.EstimateTitle1 != target.EstimateTitle1)resList.Add("EstimateTitle1");
			if(this.EstimateNote1 != target.EstimateNote1)resList.Add("EstimateNote1");
			if(this.EstimateNote2 != target.EstimateNote2)resList.Add("EstimateNote2");
			if(this.EstimateNote3 != target.EstimateNote3)resList.Add("EstimateNote3");
			if(this.EstimatePrtDiv != target.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(this.EstimateReqPrtDiv != target.EstimateReqPrtDiv)resList.Add("EstimateReqPrtDiv");
			if(this.EstimateConfPrtDiv != target.EstimateConfPrtDiv)resList.Add("EstimateConfPrtDiv");
               --- DEL 2008/06/03 --------------------------------<<<<< */
			if(this.FaxEstimatetDiv != target.FaxEstimatetDiv)resList.Add("FaxEstimatetDiv");
            // --- ADD 2008/06/03 -------------------------------->>>>>
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (this.OptionPringDivCd != target.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (this.PartsSelectDivCd != target.PartsSelectDivCd) resList.Add("PartsSelectDivCd");
            if (this.PartsSearchDivCd != target.PartsSearchDivCd) resList.Add("PartsSearchDivCd");
            if (this.EstimateDtCreateDiv != target.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (this.EstimateValidityTerm != target.EstimateValidityTerm) resList.Add("EstimateValidityTerm");
            if (this.RateUseCode != target.RateUseCode) resList.Add("RateUseCode");
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return resList;
		}

		/// <summary>
		/// ���Ϗ����l�ݒ��r����
		/// </summary>
		/// <param name="estimateDefSet1">��r����EstimateDefSet�N���X�̃C���X�^���X</param>
		/// <param name="estimateDefSet2">��r����EstimateDefSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EstimateDefSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(EstimateDefSet estimateDefSet1, EstimateDefSet estimateDefSet2)
		{
			ArrayList resList = new ArrayList();
			if(estimateDefSet1.CreateDateTime != estimateDefSet2.CreateDateTime)resList.Add("CreateDateTime");
			if(estimateDefSet1.UpdateDateTime != estimateDefSet2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(estimateDefSet1.EnterpriseCode != estimateDefSet2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(estimateDefSet1.FileHeaderGuid != estimateDefSet2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(estimateDefSet1.UpdEmployeeCode != estimateDefSet2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(estimateDefSet1.UpdAssemblyId1 != estimateDefSet2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(estimateDefSet1.UpdAssemblyId2 != estimateDefSet2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(estimateDefSet1.LogicalDeleteCode != estimateDefSet2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(estimateDefSet1.SectionCode != estimateDefSet2.SectionCode)resList.Add("SectionCode");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            if(estimateDefSet1.FractionProcCd != estimateDefSet2.FractionProcCd)resList.Add("FractionProcCd");
            if(estimateDefSet1.ConsTaxLayMethod != estimateDefSet2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (estimateDefSet1.ConsTaxPrintDiv != estimateDefSet2.ConsTaxPrintDiv)resList.Add("ConsTaxPrintDiv");
			if(estimateDefSet1.ListPricePrintDiv != estimateDefSet2.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(estimateDefSet1.EraNameDispCd1 != estimateDefSet2.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(estimateDefSet1.EstimateTotalPrtCd != estimateDefSet2.EstimateTotalPrtCd)resList.Add("EstimateTotalPrtCd");
			if(estimateDefSet1.EstimateFormPrtCd != estimateDefSet2.EstimateFormPrtCd)resList.Add("EstimateFormPrtCd");
			if(estimateDefSet1.HonorificTitlePrtCd != estimateDefSet2.HonorificTitlePrtCd)resList.Add("HonorificTitlePrtCd");
			if(estimateDefSet1.EstimateRequestCd != estimateDefSet2.EstimateRequestCd)resList.Add("EstimateRequestCd");
               --- DEL 2008/06/03 --------------------------------<<<<< */
            if (estimateDefSet1.EstmFormNoPickDiv != estimateDefSet2.EstmFormNoPickDiv)resList.Add("EstmFormNoPickDiv");
			if(estimateDefSet1.EstimateTitle1 != estimateDefSet2.EstimateTitle1)resList.Add("EstimateTitle1");
			if(estimateDefSet1.EstimateNote1 != estimateDefSet2.EstimateNote1)resList.Add("EstimateNote1");
			if(estimateDefSet1.EstimateNote2 != estimateDefSet2.EstimateNote2)resList.Add("EstimateNote2");
			if(estimateDefSet1.EstimateNote3 != estimateDefSet2.EstimateNote3)resList.Add("EstimateNote3");
			if(estimateDefSet1.EstimatePrtDiv != estimateDefSet2.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
            /* --- DEL 2008/06/03 -------------------------------->>>>>
			if(estimateDefSet1.EstimateReqPrtDiv != estimateDefSet2.EstimateReqPrtDiv)resList.Add("EstimateReqPrtDiv");
			if(estimateDefSet1.EstimateConfPrtDiv != estimateDefSet2.EstimateConfPrtDiv)resList.Add("EstimateConfPrtDiv");
               --- DEL 2008/06/06 --------------------------------<<<<< */
            if (estimateDefSet1.FaxEstimatetDiv != estimateDefSet2.FaxEstimatetDiv)resList.Add("FaxEstimatetDiv");
            // --- ADD 2008/06/03 -------------------------------->>>>>
            if (estimateDefSet1.PartsNoPrtCd != estimateDefSet2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (estimateDefSet1.OptionPringDivCd != estimateDefSet2.OptionPringDivCd) resList.Add("OptionPringDivCd");
            if (estimateDefSet1.PartsSelectDivCd != estimateDefSet2.PartsSelectDivCd) resList.Add("PartsSelectDivCd");
            if (estimateDefSet1.PartsSearchDivCd != estimateDefSet2.PartsSearchDivCd) resList.Add("PartsSearchDivCd");
            if (estimateDefSet1.EstimateDtCreateDiv != estimateDefSet2.EstimateDtCreateDiv) resList.Add("EstimateDtCreateDiv");
            if (estimateDefSet1.EstimateValidityTerm != estimateDefSet2.EstimateValidityTerm) resList.Add("EstimateValidityTerm");
            if (estimateDefSet1.RateUseCode != estimateDefSet2.RateUseCode) resList.Add("RateUseCode");
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return resList;
		}
	}
}
