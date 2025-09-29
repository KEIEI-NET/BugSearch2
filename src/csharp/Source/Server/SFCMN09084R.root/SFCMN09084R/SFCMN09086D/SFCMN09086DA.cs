using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   AllDefSetWork
	/// <summary>
	///                      �S�̏����l�ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �S�̏����l�ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/10</br>
	/// <br>Genarated Date   :   2008/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      : 2011/07/19 zhouyu</br>
    /// <br>                 : �A�� 1028</br>
    /// <br>                  �C�����e�F�A�� 1028 �݌Ɏd�����͂ŁA�i�ԓ��͌�Ɏ����� �d����=�P �ƕ\������A���݌ɐ���������ĕ\���ɂȂ蕪���肸�炢</br>
    /// <br>                  PM7�ł́A�d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������</br>
    /// <br>                  ����`�[���́C�d���`�[���� ������</br>
    /// <br>Update Note      : 2013/05/02 ���N</br>
    /// <br>�Ǘ��ԍ�         : 10901273-00 2013/06/18�z�M��</br>
    /// <br>                 : Redmine#35434�̑Ή�</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class AllDefSetWork : IFileHeader
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

		/// <summary>���z�\�����@�敪</summary>
		/// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>�����\���ڋq����</summary>
		/// <remarks>0�`31</remarks>
		private Int32 _defDspCustTtlDay;

		/// <summary>�����\���ڋq�W����</summary>
		/// <remarks>0�`31</remarks>
		private Int32 _defDspCustClctMnyDay;

		/// <summary>�����\���W�����敪</summary>
		/// <remarks>0:����,1:����,2:���X��</remarks>
		private Int32 _defDspClctMnyMonthCd;

		/// <summary>�����\���l�E�@�l�敪</summary>
		/// <remarks>0:�l,1:�@�l</remarks>
		private Int32 _iniDspPrslOrCorpCd;

		/// <summary>�����\��DM�敪</summary>
		/// <remarks>0:�c�l�o�͂���,1:�c�l�o�͂��Ȃ�</remarks>
		private Int32 _initDspDmDiv;

		/// <summary>�����\���������o�͋敪</summary>
		/// <remarks>0:�������o�͂���,1:�������o�͂��Ȃ�</remarks>
		private Int32 _defDspBillPrtDivCd;

		/// <summary>�����\���敪�P</summary>
		/// <remarks>0:����@1:�a��i�N���j</remarks>
		private Int32 _eraNameDispCd1;

		/// <summary>�����\���敪�Q</summary>
		/// <remarks>0:����@1:�a��i�ʏ�j�@�@</remarks>
		private Int32 _eraNameDispCd2;

		/// <summary>�����\���敪�R</summary>
		/// <remarks>0:����@1:�a��i���̑��j</remarks>
		private Int32 _eraNameDispCd3;

		/// <summary>���i�ԍ����͋敪</summary>
		/// <remarks>0:�C�Ӂ@1:�K�{</remarks>
		private Int32 _goodsNoInpDiv;




		/// <summary>����Ŏ����␳�敪</summary>
		/// <remarks>0:�����@1:�蓮</remarks>
		private Int32 _cnsTaxAutoCorrDiv;

		/// <summary>�c���Ǘ��敪</summary>
		/// <remarks>0:����@1:���Ȃ� �@�@���`�[�폜���Ɏc�ɖ߂����ǂ��� </remarks>
		private Int32 _remainCntMngDiv;

		/// <summary>�������ʋ敪</summary>
		/// <remarks>0:����@1:�ЊO�����̂݁@2:���Ȃ�</remarks>
		private Int32 _memoMoveDiv;

		/// <summary>�c�������\���敪</summary>
		/// <remarks>0:���Ȃ�,1:�o�׎c,���׎c�̂݁C2:�󔭒��c�̂݁C3:�o�׎c,���׎c ->�󔭒��c 4:�󔭒��c -> �o�׎c,���׎c</remarks>
		private Int32 _remCntAutoDspDiv;

		/// <summary>���z�\���|���K�p�敪</summary>
		/// <remarks>0�F�ō��P��, 1:�Ŕ��P��</remarks>
		private Int32 _ttlAmntDspRateDivCd;

        // --- ADD  ���r��  2010/01/15 ---------->>>>>
        /// <summary>�����\�����v�������o�͋敪</summary>
        /// <remarks>0:�o�͂���@1:�o�͂��Ȃ�</remarks>
        private Int32 _defTtlBillOutput;

        /// <summary>�����\�����א������o�͋敪</summary>
        /// <remarks>0:�o�͂���@1:�o�͂��Ȃ�</remarks>
        private Int32 _defDtlBillOutput;

        /// <summary>�����\���`�[���v�������o�͋敪</summary>
        /// <remarks>0:�o�͂���@1:�o�͂��Ȃ�</remarks>
        private Int32 _defSlTtlBillOutput;
        // --- ADD  ���r��  2010/01/15 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>���׎Z�o��݌ɐ��\���敪</summary>
        /// <remarks>0:�����㔽�f 1:�s�ړ������f</remarks>
        private Int32 _dtlCalcStckCntDsp;
        //ADD 2011/07/19

        // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>���i�݌ɋN���敪</summary>
        /// <remarks>0:���i�݌Ƀ}�X�^�T�@1:���i�݌Ƀ}�X�^�U</remarks>
        private Int32 _goodsStockMstBootDiv;
        // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

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

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>���z�\�����@�敪�v���p�e�B</summary>
		/// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalAmountDispWayCd
		{
			get{return _totalAmountDispWayCd;}
			set{_totalAmountDispWayCd = value;}
		}

		/// public propaty name  :  DefDspCustTtlDay
		/// <summary>�����\���ڋq�����v���p�e�B</summary>
		/// <value>0�`31</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���ڋq�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DefDspCustTtlDay
		{
			get{return _defDspCustTtlDay;}
			set{_defDspCustTtlDay = value;}
		}

		/// public propaty name  :  DefDspCustClctMnyDay
		/// <summary>�����\���ڋq�W�����v���p�e�B</summary>
		/// <value>0�`31</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���ڋq�W�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DefDspCustClctMnyDay
		{
			get{return _defDspCustClctMnyDay;}
			set{_defDspCustClctMnyDay = value;}
		}

		/// public propaty name  :  DefDspClctMnyMonthCd
		/// <summary>�����\���W�����敪�v���p�e�B</summary>
		/// <value>0:����,1:����,2:���X��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���W�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DefDspClctMnyMonthCd
		{
			get{return _defDspClctMnyMonthCd;}
			set{_defDspClctMnyMonthCd = value;}
		}

		/// public propaty name  :  IniDspPrslOrCorpCd
		/// <summary>�����\���l�E�@�l�敪�v���p�e�B</summary>
		/// <value>0:�l,1:�@�l</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���l�E�@�l�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 IniDspPrslOrCorpCd
		{
			get{return _iniDspPrslOrCorpCd;}
			set{_iniDspPrslOrCorpCd = value;}
		}

		/// public propaty name  :  InitDspDmDiv
		/// <summary>�����\��DM�敪�v���p�e�B</summary>
		/// <value>0:�c�l�o�͂���,1:�c�l�o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\��DM�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InitDspDmDiv
		{
			get{return _initDspDmDiv;}
			set{_initDspDmDiv = value;}
		}

		/// public propaty name  :  DefDspBillPrtDivCd
		/// <summary>�����\���������o�͋敪�v���p�e�B</summary>
		/// <value>0:�������o�͂���,1:�������o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���������o�͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DefDspBillPrtDivCd
		{
			get{return _defDspBillPrtDivCd;}
			set{_defDspBillPrtDivCd = value;}
		}

		/// public propaty name  :  EraNameDispCd1
		/// <summary>�����\���敪�P�v���p�e�B</summary>
		/// <value>0:����@1:�a��i�N���j</value>
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

		/// public propaty name  :  EraNameDispCd2
		/// <summary>�����\���敪�Q�v���p�e�B</summary>
		/// <value>0:����@1:�a��i�ʏ�j�@�@</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���敪�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EraNameDispCd2
		{
			get{return _eraNameDispCd2;}
			set{_eraNameDispCd2 = value;}
		}

		/// public propaty name  :  EraNameDispCd3
		/// <summary>�����\���敪�R�v���p�e�B</summary>
		/// <value>0:����@1:�a��i���̑��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���敪�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EraNameDispCd3
		{
			get{return _eraNameDispCd3;}
			set{_eraNameDispCd3 = value;}
		}

		/// public propaty name  :  GoodsNoInpDiv
		/// <summary>���i�ԍ����͋敪�v���p�e�B</summary>
		/// <value>0:�C�Ӂ@1:�K�{</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ����͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNoInpDiv
		{
			get{return _goodsNoInpDiv;}
			set{_goodsNoInpDiv = value;}
		}


		/// public propaty name  :  CnsTaxAutoCorrDiv
		/// <summary>����Ŏ����␳�敪�v���p�e�B</summary>
		/// <value>0:�����@1:�蓮</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����Ŏ����␳�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CnsTaxAutoCorrDiv
		{
			get{return _cnsTaxAutoCorrDiv;}
			set{_cnsTaxAutoCorrDiv = value;}
		}

		/// public propaty name  :  RemainCntMngDiv
		/// <summary>�c���Ǘ��敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ� �@�@���`�[�폜���Ɏc�ɖ߂����ǂ��� </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c���Ǘ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RemainCntMngDiv
		{
			get{return _remainCntMngDiv;}
			set{_remainCntMngDiv = value;}
		}

		/// public propaty name  :  MemoMoveDiv
		/// <summary>�������ʋ敪�v���p�e�B</summary>
		/// <value>0:����@1:�ЊO�����̂݁@2:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MemoMoveDiv
		{
			get{return _memoMoveDiv;}
			set{_memoMoveDiv = value;}
		}

		/// public propaty name  :  RemCntAutoDspDiv
		/// <summary>�c�������\���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�,1:�o�׎c,���׎c�̂݁C2:�󔭒��c�̂݁C3:�o�׎c,���׎c ->�󔭒��c 4:�󔭒��c -> �o�׎c,���׎c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �c�������\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RemCntAutoDspDiv
		{
			get{return _remCntAutoDspDiv;}
			set{_remCntAutoDspDiv = value;}
		}

		/// public propaty name  :  TtlAmntDspRateDivCd
		/// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
		/// <value>0�F�ō��P��, 1:�Ŕ��P��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TtlAmntDspRateDivCd
		{
			get{return _ttlAmntDspRateDivCd;}
			set{_ttlAmntDspRateDivCd = value;}
		}

        // --- ADD  ���r��  2010/01/15 ---------->>>>>
        /// public propaty name  :  DefTtlBillOutput
        /// <summary>�����\�����v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���@1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefTtlBillOutput
        {
            get { return _defTtlBillOutput; }
            set { _defTtlBillOutput = value; }
        }

        /// public propaty name  :  DefDtlBillOutput
        /// <summary>�����\�����א������o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���@1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����א������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefDtlBillOutput
        {
            get { return _defDtlBillOutput; }
            set { _defDtlBillOutput = value; }
        }

        /// public propaty name  :  DefSlTtlBillOutput
        /// <summary>�����\���`�[���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���@1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���`�[���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefSlTtlBillOutput
        {
            get { return _defSlTtlBillOutput; }
            set { _defSlTtlBillOutput = value; }
        }
        // --- ADD  ���r��  2010/01/15 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>���׎Z�o��݌ɐ��\���敪�v���p�e�B</summary>
        /// <value>0:�����㔽�f 1:�s�ړ������f</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׎Z�o��݌ɐ��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlCalcStckCntDsp
        {
            get { return _dtlCalcStckCntDsp; }
            set { _dtlCalcStckCntDsp = value; }
        }
        //ADD 2011/07/19

        // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>���i�݌ɋN���敪</summary>
        /// <value>0:���i�݌Ƀ}�X�^�T 1:���i�݌Ƀ}�X�^�U</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsStockMstBootDiv
        {
            get { return _goodsStockMstBootDiv; }
            set { _goodsStockMstBootDiv = value; }
        }
        // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

		/// <summary>
		/// �S�̏����l�ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>AllDefSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AllDefSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public AllDefSetWork()
		{
		}

	}
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AllDefSetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AllDefSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AllDefSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : �@2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ�         :   10901273-00 2013/06/18�z�M��</br>
        /// <br>                 : �@Redmine#35434�̑Ή�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AllDefSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AllDefSetWork || graph is ArrayList || graph is AllDefSetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AllDefSetWork).FullName));

            if (graph != null && graph is AllDefSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AllDefSetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AllDefSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AllDefSetWork[])graph).Length;
            }
            else if (graph is AllDefSetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //�����\���ڋq����
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspCustTtlDay
            //�����\���ڋq�W����
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspCustClctMnyDay
            //�����\���W�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspClctMnyMonthCd
            //�����\���l�E�@�l�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //IniDspPrslOrCorpCd
            //�����\��DM�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InitDspDmDiv
            //�����\���������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspBillPrtDivCd
            //�����\���敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd1
            //�����\���敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd2
            //�����\���敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd3
            //���i�ԍ����͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoInpDiv
            //����Ŏ����␳�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CnsTaxAutoCorrDiv
            //�c���Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntMngDiv
            //�������ʋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MemoMoveDiv
            //�c�������\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RemCntAutoDspDiv
            //���z�\���|���K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDspRateDivCd
            // --- ADD  ���r��  2010/01/15 ---------->>>>>
            //�����\�����v�������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DefTtlBillOutput
            //�����\�����א������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDtlBillOutput
            //�����\���`�[���v�������o�͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DefSlTtlBillOutput
            // --- ADD  ���r��  2010/01/15 ----------<<<<<
            //ADD 2011/07/19
            //���׎Z�o��݌ɐ��\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlCalcStckCntDsp
            //ADD 2011/07/19
            serInfo.MemberInfo.Add(typeof(Int32));//GoodsStockMstBootDiv // ADD ���N 2013/05/02 Redmine#35434


            serInfo.Serialize(writer, serInfo);
            if (graph is AllDefSetWork)
            {
                AllDefSetWork temp = (AllDefSetWork)graph;

                SetAllDefSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AllDefSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AllDefSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AllDefSetWork temp in lst)
                {
                    SetAllDefSetWork(writer, temp);
                }

            }
        }


        /// <summary>
        /// AllDefSetWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 29; // DEL ���N 2013/05/02 Redmine#35434
        private const int currentMemberCount = 30;// ADD ���N 2013/05/02 Redmine#35434

        /// <summary>
        ///  AllDefSetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : �@2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ�         :   10901273-00 2013/06/18�z�M��</br>
        /// <br>                 : �@Redmine#35434�̑Ή�</br>
        /// </remarks>
        private void SetAllDefSetWork(System.IO.BinaryWriter writer, AllDefSetWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���z�\�����@�敪
            writer.Write(temp.TotalAmountDispWayCd);
            //�����\���ڋq����
            writer.Write(temp.DefDspCustTtlDay);
            //�����\���ڋq�W����
            writer.Write(temp.DefDspCustClctMnyDay);
            //�����\���W�����敪
            writer.Write(temp.DefDspClctMnyMonthCd);
            //�����\���l�E�@�l�敪
            writer.Write(temp.IniDspPrslOrCorpCd);
            //�����\��DM�敪
            writer.Write(temp.InitDspDmDiv);
            //�����\���������o�͋敪
            writer.Write(temp.DefDspBillPrtDivCd);
            //�����\���敪�P
            writer.Write(temp.EraNameDispCd1);
            //�����\���敪�Q
            writer.Write(temp.EraNameDispCd2);
            //�����\���敪�R
            writer.Write(temp.EraNameDispCd3);
            //���i�ԍ����͋敪
            writer.Write(temp.GoodsNoInpDiv);
            //����Ŏ����␳�敪
            writer.Write(temp.CnsTaxAutoCorrDiv);
            //�c���Ǘ��敪
            writer.Write(temp.RemainCntMngDiv);
            //�������ʋ敪
            writer.Write(temp.MemoMoveDiv);
            //�c�������\���敪
            writer.Write(temp.RemCntAutoDspDiv);
            //���z�\���|���K�p�敪
            writer.Write(temp.TtlAmntDspRateDivCd);
            // --- ADD  ���r��  2010/01/15 ---------->>>>>
            //�����\�����v�������o�͋敪
            writer.Write(temp.DefTtlBillOutput);
            //�����\�����א������o�͋敪
            writer.Write(temp.DefDtlBillOutput);
            //�����\���`�[���v�������o�͋敪
            writer.Write(temp.DefSlTtlBillOutput);
            // --- ADD  ���r��  2010/01/15 ----------<<<<<
            //ADD 2011/07/19
            //���׎Z�o��݌ɐ��\���敪
            writer.Write(temp.DtlCalcStckCntDsp);
            //ADD 2011/07/19
            writer.Write(temp.GoodsStockMstBootDiv); // ADD ���N 2013/05/02 Redmine#35434

        }

        /// <summary>
        ///  AllDefSetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AllDefSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : �@2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ�         :   10901273-00 2013/06/18�z�M��</br>
        /// <br>                 : �@Redmine#35434�̑Ή�</br>
        /// </remarks>
        private AllDefSetWork GetAllDefSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AllDefSetWork temp = new AllDefSetWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���z�\�����@�敪
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //�����\���ڋq����
            temp.DefDspCustTtlDay = reader.ReadInt32();
            //�����\���ڋq�W����
            temp.DefDspCustClctMnyDay = reader.ReadInt32();
            //�����\���W�����敪
            temp.DefDspClctMnyMonthCd = reader.ReadInt32();
            //�����\���l�E�@�l�敪
            temp.IniDspPrslOrCorpCd = reader.ReadInt32();
            //�����\��DM�敪
            temp.InitDspDmDiv = reader.ReadInt32();
            //�����\���������o�͋敪
            temp.DefDspBillPrtDivCd = reader.ReadInt32();
            //�����\���敪�P
            temp.EraNameDispCd1 = reader.ReadInt32();
            //�����\���敪�Q
            temp.EraNameDispCd2 = reader.ReadInt32();
            //�����\���敪�R
            temp.EraNameDispCd3 = reader.ReadInt32();
            //���i�ԍ����͋敪
            temp.GoodsNoInpDiv = reader.ReadInt32();
            //����Ŏ����␳�敪
            temp.CnsTaxAutoCorrDiv = reader.ReadInt32();
            //�c���Ǘ��敪
            temp.RemainCntMngDiv = reader.ReadInt32();
            //�������ʋ敪
            temp.MemoMoveDiv = reader.ReadInt32();
            //�c�������\���敪
            temp.RemCntAutoDspDiv = reader.ReadInt32();
            //���z�\���|���K�p�敪
            temp.TtlAmntDspRateDivCd = reader.ReadInt32();
            // --- ADD  ���r��  2010/01/15 ---------->>>>>
            //�����\�����v�������o�͋敪
            temp.DefTtlBillOutput = reader.ReadInt32();
            //�����\�����א������o�͋敪
            temp.DefDtlBillOutput = reader.ReadInt32();
            //�����\���`�[���v�������o�͋敪
            temp.DefSlTtlBillOutput = reader.ReadInt32();
            // --- ADD  ���r��  2010/01/15 ----------<<<<<
            //ADD 2011/07/19
            //���׎Z�o��݌ɐ��\���敪
            temp.DtlCalcStckCntDsp = reader.ReadInt32();
            //ADD 2011/07/19
            temp.GoodsStockMstBootDiv = reader.ReadInt32(); // ADD ���N 2013/05/02 Redmine#35434


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>AllDefSetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AllDefSetWork temp = GetAllDefSetWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (AllDefSetWork[])lst.ToArray(typeof(AllDefSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
