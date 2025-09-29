//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�󒍃Z�b�g���i�f�[�^
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   ����
// Date             :   2011/08/10
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : ���L���ڂ̒ǉ�
//                                     �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
//                                     �┭BL���ꕔ�i�T�u�R�[�h
//                                     ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
//                                     ��BL���ꕔ�i�T�u�R�[�h
//                                     ��BL���i�R�[�h
//                                     ��BL���i�R�[�h�}��
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SCMAcOdSetDtWork
	/// <summary>
	///                      SCM�󒍃Z�b�g���i�f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍃Z�b�g���i�f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2011/08/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �󒍃X�e�[�^�X</br>
	/// <br>                 :   ����`�[�ԍ�</br>
	/// <br>                 :   ����`�[���v�i�ō��݁j</br>
	/// <br>                 :   ���㏬�v�i�Łj</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ������</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �┭�E�񓚎��</br>
	/// <br>                 :   ��M����</br>
	/// <br>Update Note      :   2009/05/29  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �񓚍쐬�敪</br>
	/// <br>Update Note      :   2009/06/15  ����</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,11,13,14,15,17,18��3,9,11,13,14,15,17,18,29,30</br>
	/// <br>Update Note      :   2009/06/16  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �⍇������Ɩ���</br>
	/// <br>                 :   �⍇�������_����</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �⍇�������_�R�[�h�@16��6</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,11,13,14,15,17,18,29,30��3,9,10,11,12,13,15,16,27,28</br>
	/// <br>Update Note      :   2010/05/25  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �L�����Z���敪</br>
	/// <br>                 :   CMT�A�g�敪</br>
	/// <br>Update Note      :   2011/2/17  ����</br>
	/// <br>                 :   ��CMT�A�g�敪�⑫ �C��</br>
	/// <br>                 :   11:�⍇�������� 12:���������񓚂�ǉ�</br>
	/// <br>Update Note      :   2011/5/19  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   SF-PM�A�g�w�����ԍ�</br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh</br>
    /// <br>                 :   �z�M���Ȃ��� Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή� </br>
    /// <br>Update Note      :   2013/05/09 30744 ���� ����q</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���i�K�i�E���L����</br>
    /// <br>                 :   SCM��Q��10470�Ή�</br>
    /// <br>Update Note      :   2015/01/19  31065 �L�� ���O</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ PMNS�Ή� �Z�b�g�i�Ƀ��[�J�[��]�������i�A�I�[�v�����i�敪�̒ǉ�</br>
    /// <br>Update Note      :   2015/02/10  30745 �g��</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ �񓚔[���敪�Ή� ���ڒǉ�</br>
    /// <br>Update Note      :   2015/02/20  31126 ����</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ �b������ʓ��L�Ή�</br>
    /// <br>                 :   ���i�K�i�E���L����(�H�����)�A���i�K�i�E���L����(�J�[�I�[�i�[����)�A�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�̒ǉ�</br>
    /// <br>Update Note      :   2015/02/27  30744 ����</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ �b������ʓ��L�Ή�</br>
    /// <br>                 :   �D�ǐݒ�ڍז��̂Q�R�[�h�A�D�ǐݒ�ڍז��̂Q�A�݌ɏ󋵋敪�̒ǉ�</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdSetDtWork : IFileHeader
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

		/// <summary>�Z�b�g���i���[�J�[�R�[�h</summary>
		private Int32 _setPartsMkrCd;

		/// <summary>�Z�b�g���i�ԍ�</summary>
		private string _setPartsNumber = "";

		/// <summary>�Z�b�g���i�e�q�ԍ�</summary>
		/// <remarks>0:�e,1-*:�q</remarks>
		private Int32 _setPartsMainSubNo;

		/// <summary>���i���</summary>
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����</remarks>
		private Int32 _goodsDivCd;

		/// <summary>���T�C�N�����i���</summary>
		/// <remarks>1:���r���h 2:����</remarks>
		private Int32 _recyclePrtKindCode;

		/// <summary>���T�C�N�����i��ʖ���</summary>
		private string _recyclePrtKindName = "";

		/// <summary>�[�i�敪</summary>
		/// <remarks>0:�z��,1:����</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>�戵�敪</summary>
		/// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
		private Int32 _handleDivCode;

		/// <summary>���i�`��</summary>
		/// <remarks>1:���i,2:�p�i</remarks>
		private Int32 _goodsShape;

		/// <summary>�[�i�m�F�敪</summary>
		/// <remarks>0:���m�F,1:�m�F</remarks>
		private Int32 _delivrdGdsConfCd;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>�[�i�\����t YYYYMMDD</remarks>
        private DateTime _deliGdsCmpltDueDate;

		/// <summary>�񓚔[��</summary>
		private string _answerDeliveryDate = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h�}��</summary>
		private Int32 _bLGoodsDrCode;

		/// <summary>�┭���i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _inqGoodsName = "";

		/// <summary>�񓚏��i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _ansGoodsName = "";

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�[�i��</summary>
		private Double _deliveredGoodsCount;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���i���[�J�[����</summary>
		private string _goodsMakerNm = "";

		/// <summary>�������i���[�J�[�R�[�h</summary>
		private Int32 _pureGoodsMakerCd;

		/// <summary>�┭�������i�ԍ�</summary>
		/// <remarks>(���p�̂�)</remarks>
		private string _inqPureGoodsNo = "";

		/// <summary>�񓚏������i�ԍ�</summary>
		/// <remarks>(���p�̂�)</remarks>
		private string _ansPureGoodsNo = "";

		/// <summary>�艿</summary>
		private Int64 _listPrice;

		/// <summary>�P��</summary>
		private Int64 _unitPrice;

		/// <summary>���i�⑫���</summary>
		private string _goodsAddInfo = "";

		/// <summary>�e���z</summary>
		private Int64 _roughRrofit;

		/// <summary>�e����</summary>
		private Double _roughRate;

		/// <summary>�񓚊���</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _answerLimitDate;

		/// <summary>���l(����)</summary>
		private string _commentDtl = "";

		/// <summary>�I��</summary>
		private string _shelfNo = "";

		/// <summary>PM�󒍃X�e�[�^�X</summary>
		/// <remarks>10�F���� 20:�� 30:���� 40:�o��</remarks>
		private Int32 _pMAcptAnOdrStatus;

		/// <summary>PM����`�[�ԍ�</summary>
		/// <remarks>PM�̔���`�[�ԍ�</remarks>
		private Int32 _pMSalesSlipNum;

		/// <summary>PM����s�ԍ�</summary>
		private Int32 _pMSalesRowNo;

		/// <summary>PM�q�ɃR�[�h</summary>
		private string _pmWarehouseCd = "";

		/// <summary>PM�q�ɖ���</summary>
		private string _pmWarehouseName = "";

		/// <summary>PM�I��</summary>
		private string _pmShelfNo = "";

		/// <summary>PM���݌�</summary>
		private Double _pmPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>PM��Ǒq�ɃR�[�h</summary>
        private string _pmMainMngWarehouseCde = "";

        /// <summary>PM��Ǒq�ɖ���</summary>
        private string _pmMainMngWarehouseName = "";

        /// <summary>PM��ǒI��</summary>
        private string _pmMainMngShelfNo = "";

        /// <summary>PM��ǌ��݌�</summary>
        private Double _pmMainMngPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        /// <summary>���i�K�i�E���L����</summary>
        private string _goodsSpclInstruction = "";
        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<

        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary>���[�J�[��]�������i</summary>
        private Int64 _mkrSuggestRtPric = 0;
        /// <summary>�I�[�v�����i�敪</summary>
        private Int32 _openPriceDiv = 0;
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �񓚔[���敪</summary>
        private Int16 _ansDeliDateDiv = 0;
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>���i�K�i�E���L����(�H�����)</summary>
        private string _goodsSpecialNtForFac = "";
        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)</summary>
        private string _goodsSpecialNtForCOw = "";
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)</summary>
        private string _prmSetDtlName2ForFac = "";
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</summary>
        private string _prmSetDtlName2ForCOw = "";
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        private Int32 _prmSetDtlNo2 = 0;
        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        private string _prmSetDtlName2 = "";
        /// <summary>�݌ɏ󋵋敪</summary>
        private Int16 _stockStatusDiv = 0;
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private string _inqBlUtyPtThCd = "";

        /// <summary>�┭BL���ꕔ�i�T�u�R�[�h</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private Int32 _inqBlUtyPtSbCd;

        /// <summary>��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private string _ansBlUtyPtThCd = "";

        /// <summary>��BL���ꕔ�i�T�u�R�[�h</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private Int32 _ansBlUtyPtSbCd;

        /// <summary>��BL���i�R�[�h</summary>
        private Int32 _ansBLGoodsCode;

        /// <summary>��BL���i�R�[�h�}��</summary>
        private Int32 _ansBLGoodsDrCode;
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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

		/// public propaty name  :  InqOtherEpCd
		/// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
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
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
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
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
		}

		/// public propaty name  :  SetPartsMkrCd
		/// <summary>�Z�b�g���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetPartsMkrCd
		{
			get{return _setPartsMkrCd;}
			set{_setPartsMkrCd = value;}
		}

		/// public propaty name  :  SetPartsNumber
		/// <summary>�Z�b�g���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetPartsNumber
		{
			get{return _setPartsNumber;}
			set{_setPartsNumber = value;}
		}

		/// public propaty name  :  SetPartsMainSubNo
		/// <summary>�Z�b�g���i�e�q�ԍ��v���p�e�B</summary>
		/// <value>0:�e,1-*:�q</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i�e�q�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetPartsMainSubNo
		{
			get{return _setPartsMainSubNo;}
			set{_setPartsMainSubNo = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  RecyclePrtKindCode
		/// <summary>���T�C�N�����i��ʃv���p�e�B</summary>
		/// <value>1:���r���h 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���T�C�N�����i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RecyclePrtKindCode
		{
			get{return _recyclePrtKindCode;}
			set{_recyclePrtKindCode = value;}
		}

		/// public propaty name  :  RecyclePrtKindName
		/// <summary>���T�C�N�����i��ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���T�C�N�����i��ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RecyclePrtKindName
		{
			get{return _recyclePrtKindName;}
			set{_recyclePrtKindName = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>�[�i�敪�v���p�e�B</summary>
		/// <value>0:�z��,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DeliveredGoodsDiv
		{
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
		}

		/// public propaty name  :  HandleDivCode
		/// <summary>�戵�敪�v���p�e�B</summary>
		/// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �戵�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HandleDivCode
		{
			get{return _handleDivCode;}
			set{_handleDivCode = value;}
		}

		/// public propaty name  :  GoodsShape
		/// <summary>���i�`�ԃv���p�e�B</summary>
		/// <value>1:���i,2:�p�i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�`�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsShape
		{
			get{return _goodsShape;}
			set{_goodsShape = value;}
		}

		/// public propaty name  :  DelivrdGdsConfCd
		/// <summary>�[�i�m�F�敪�v���p�e�B</summary>
		/// <value>0:���m�F,1:�m�F</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DelivrdGdsConfCd
		{
			get{return _delivrdGdsConfCd;}
			set{_delivrdGdsConfCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  AnswerDeliveryDate
		/// <summary>�񓚔[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚔[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerDeliveryDate
		{
			get{return _answerDeliveryDate;}
			set{_answerDeliveryDate = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsDrCode
		/// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsDrCode
		{
			get{return _bLGoodsDrCode;}
			set{_bLGoodsDrCode = value;}
		}

		/// public propaty name  :  InqGoodsName
		/// <summary>�┭���i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭���i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqGoodsName
		{
			get{return _inqGoodsName;}
			set{_inqGoodsName = value;}
		}

		/// public propaty name  :  AnsGoodsName
		/// <summary>�񓚏��i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏��i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsGoodsName
		{
			get{return _ansGoodsName;}
			set{_ansGoodsName = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  DeliveredGoodsCount
		/// <summary>�[�i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double DeliveredGoodsCount
		{
			get{return _deliveredGoodsCount;}
			set{_deliveredGoodsCount = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsMakerNm
		/// <summary>���i���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsMakerNm
		{
			get{return _goodsMakerNm;}
			set{_goodsMakerNm = value;}
		}

		/// public propaty name  :  PureGoodsMakerCd
		/// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PureGoodsMakerCd
		{
			get{return _pureGoodsMakerCd;}
			set{_pureGoodsMakerCd = value;}
		}

		/// public propaty name  :  InqPureGoodsNo
		/// <summary>�┭�������i�ԍ��v���p�e�B</summary>
		/// <value>(���p�̂�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqPureGoodsNo
		{
			get{return _inqPureGoodsNo;}
			set{_inqPureGoodsNo = value;}
		}

		/// public propaty name  :  AnsPureGoodsNo
		/// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
		/// <value>(���p�̂�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsPureGoodsNo
		{
			get{return _ansPureGoodsNo;}
			set{_ansPureGoodsNo = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>�艿�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>�P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  GoodsAddInfo
		/// <summary>���i�⑫���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�⑫���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsAddInfo
		{
			get{return _goodsAddInfo;}
			set{_goodsAddInfo = value;}
		}

		/// public propaty name  :  RoughRrofit
		/// <summary>�e���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 RoughRrofit
		{
			get{return _roughRrofit;}
			set{_roughRrofit = value;}
		}

		/// public propaty name  :  RoughRate
		/// <summary>�e�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double RoughRate
		{
			get{return _roughRate;}
			set{_roughRate = value;}
		}

		/// public propaty name  :  AnswerLimitDate
		/// <summary>�񓚊����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public DateTime AnswerLimitDate
		{
			get{return _answerLimitDate;}
			set{_answerLimitDate = value;}
		}

		/// public propaty name  :  CommentDtl
		/// <summary>���l(����)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CommentDtl
		{
			get{return _commentDtl;}
			set{_commentDtl = value;}
		}

		/// public propaty name  :  ShelfNo
		/// <summary>�I�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ShelfNo
		{
			get{return _shelfNo;}
			set{_shelfNo = value;}
		}

		/// public propaty name  :  PMAcptAnOdrStatus
		/// <summary>PM�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10�F���� 20:�� 30:���� 40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PMAcptAnOdrStatus
		{
			get{return _pMAcptAnOdrStatus;}
			set{_pMAcptAnOdrStatus = value;}
		}

		/// public propaty name  :  PMSalesSlipNum
		/// <summary>PM����`�[�ԍ��v���p�e�B</summary>
		/// <value>PM�̔���`�[�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PMSalesSlipNum
		{
			get{return _pMSalesSlipNum;}
			set{_pMSalesSlipNum = value;}
		}

		/// public propaty name  :  PMSalesRowNo
		/// <summary>PM����s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PMSalesRowNo
		{
			get{return _pMSalesRowNo;}
			set{_pMSalesRowNo = value;}
		}

		/// public propaty name  :  PmWarehouseCd
		/// <summary>PM�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmWarehouseCd
		{
			get{return _pmWarehouseCd;}
			set{_pmWarehouseCd = value;}
		}

		/// public propaty name  :  PmWarehouseName
		/// <summary>PM�q�ɖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmWarehouseName
		{
			get{return _pmWarehouseName;}
			set{_pmWarehouseName = value;}
		}

		/// public propaty name  :  PmShelfNo
		/// <summary>PM�I�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmShelfNo
		{
			get{return _pmShelfNo;}
			set{_pmShelfNo = value;}
		}

		/// public propaty name  :  PmPrsntCount
		/// <summary>PM���݌��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM���݌��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PmPrsntCount
		{
			get{return _pmPrsntCount;}
			set{_pmPrsntCount = value;}
		}

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  PmMainMngWarehouseCd
        /// <summary>PM��Ǒq�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��Ǒq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmMainMngWarehouseCd
        {
            get { return _pmMainMngWarehouseCde; }
            set { _pmMainMngWarehouseCde = value; }
        }

        /// public propaty name  :  PmMainMngWarehouseName
        /// <summary>PM��Ǒq�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��Ǒq�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmMainMngWarehouseName
        {
            get { return _pmMainMngWarehouseName; }
            set { _pmMainMngWarehouseName = value; }
        }

        /// public propaty name  :  PmMainMngShelfNo
        /// <summary>PM��ǒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ǒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmMainMngShelfNo
        {
            get { return _pmMainMngShelfNo; }
            set { _pmMainMngShelfNo = value; }
        }

        /// public propaty name  :  PmMainMngPrsntCount
        /// <summary>PM��ǌ��݌��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ǌ��݌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PmMainMngPrsntCount
        {
            get { return _pmMainMngPrsntCount; }
            set { _pmMainMngPrsntCount = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>

        /// public propaty name  :  GoodsSpclInstruction
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpclInstruction
        {
            get { return _goodsSpclInstruction; }
            set { _goodsSpclInstruction = value; }
        }

        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<

        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>���[�J�[��]�������i�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[��]�������i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDeliDateDiv
        /// <summary>�񓚔[���敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�v���p�e�B</br>
        /// </remarks>
        public Int16 AnsDeliDateDiv
        {
            get { return _ansDeliDateDiv; }
            set { _ansDeliDateDiv = value; }
        }
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  GoodsSpecialNtForFac
        /// <summary>���i�K�i�E���L����(�H�����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���i�K�i�E���L����(�H�����)�v���p�e�B</br>
        /// </remarks>
        public string GoodsSpecialNtForFac
        {
            get { return _goodsSpecialNtForFac; }
            set { _goodsSpecialNtForFac = value; }
        }

        /// public propaty name  :  GoodsSpecialNtForCOw
        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string GoodsSpecialNtForCOw
        {
            get { return _goodsSpecialNtForCOw; }
            set { _goodsSpecialNtForCOw = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForCOw
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>�D�ǐݒ�ڍז��̂Q�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �D�ǐݒ�ڍז��̂Q�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  StockStatusDiv
        /// <summary>�݌ɏ󋵋敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �݌ɏ󋵋敪�v���p�e�B</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  InqBlUtyPtThCd
        /// <summary>�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public string InqBlUtyPtThCd
        {
            get { return _inqBlUtyPtThCd; }
            set { _inqBlUtyPtThCd = value; }
        }

        /// public propaty name  :  InqBlUtyPtSbCd
        /// <summary>�┭BL���ꕔ�i�T�u�R�[�h�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭BL���ꕔ�i�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 InqBlUtyPtSbCd
        {
            get { return _inqBlUtyPtSbCd; }
            set { _inqBlUtyPtSbCd = value; }
        }

        /// public propaty name  :  AnsBlUtyPtThCd
        /// <summary>��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public string AnsBlUtyPtThCd
        {
            get { return _ansBlUtyPtThCd; }
            set { _ansBlUtyPtThCd = value; }
        }

        /// public propaty name  :  AnsBlUtyPtSbCd
        /// <summary>��BL���ꕔ�i�T�u�R�[�h�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���ꕔ�i�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 AnsBlUtyPtSbCd
        {
            get { return _ansBlUtyPtSbCd; }
            set { _ansBlUtyPtSbCd = value; }
        }

        /// public propaty name  :  AnsBLGoodsCode
        /// <summary>��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 AnsBLGoodsCode
        {
            get { return _ansBLGoodsCode; }
            set { _ansBLGoodsCode = value; }
        }

        /// public propaty name  :  AnsBLGoodsDrCode
        /// <summary>��BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 AnsBLGoodsDrCode
        {
            get { return _ansBLGoodsDrCode; }
            set { _ansBLGoodsDrCode = value; }
        }
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<


        /// <summary>
		/// SCM�󒍃Z�b�g���i�f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdSetDtWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdSetDtWork()
		{
		}

        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="setPartsMkrCd">�Z�b�g���i���[�J�[�R�[�h</param>
        /// <param name="setPartsNumber">�Z�b�g���i�ԍ�</param>
        /// <param name="setPartsMainSubNo">�Z�b�g���i�e�q�ԍ�(0:�e,1-*:�q)</param>
        /// <param name="goodsDivCd">���i���(0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����)</param>
        /// <param name="recyclePrtKindCode">���T�C�N�����i���(1:���r���h 2:����)</param>
        /// <param name="recyclePrtKindName">���T�C�N�����i��ʖ���</param>
        /// <param name="deliveredGoodsDiv">�[�i�敪(0:�z��,1:����)</param>
        /// <param name="handleDivCode">�戵�敪(0:��舵���i,1:�[���m�F��,2:����舵���i)</param>
        /// <param name="goodsShape">���i�`��(1:���i,2:�p�i)</param>
        /// <param name="delivrdGdsConfCd">�[�i�m�F�敪(0:���m�F,1:�m�F)</param>
        /// <param name="deliGdsCmpltDueDate">�[�i�����\���(�[�i�\����t YYYYMMDD)</param>
        /// <param name="answerDeliveryDate">�񓚔[��</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsDrCode">BL���i�R�[�h�}��</param>
        /// <param name="inqGoodsName">�┭���i��((���p�S�p����))</param>
        /// <param name="ansGoodsName">�񓚏��i��((���p�S�p����))</param>
        /// <param name="salesOrderCount">������</param>
        /// <param name="deliveredGoodsCount">�[�i��</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsMakerNm">���i���[�J�[����</param>
        /// <param name="pureGoodsMakerCd">�������i���[�J�[�R�[�h</param>
        /// <param name="inqPureGoodsNo">�┭�������i�ԍ�((���p�̂�))</param>
        /// <param name="ansPureGoodsNo">�񓚏������i�ԍ�((���p�̂�))</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="unitPrice">�P��</param>
        /// <param name="goodsAddInfo">���i�⑫���</param>
        /// <param name="roughRrofit">�e���z</param>
        /// <param name="roughRate">�e����</param>
        /// <param name="answerLimitDate">�񓚊���(YYYYMMDD)</param>
        /// <param name="commentDtl">���l(����)</param>
        /// <param name="shelfNo">�I��</param>
        /// <param name="pMAcptAnOdrStatus">PM�󒍃X�e�[�^�X(10�F���� 20:�� 30:���� 40:�o��)</param>
        /// <param name="pMSalesSlipNum">PM����`�[�ԍ�(PM�̔���`�[�ԍ�)</param>
        /// <param name="pMSalesRowNo">PM����s�ԍ�</param>
        /// <param name="pmWarehouseCd">PM�q�ɃR�[�h</param>
        /// <param name="pmWarehouseName">PM�q�ɖ���</param>
        /// <param name="pmShelfNo">PM�I��</param>
        /// <param name="pmPrsntCount">PM���݌�</param>
        /// <param name="pmMainMngWarehouseCd">PM��Ǒq�ɃR�[�h</param>
        /// <param name="pmMainMngWarehouseName">PM��Ǒq�ɖ���</param>
        /// <param name="pmMainMngShelfNo">PM��ǒI��</param>
        /// <param name="pmMainMngPrsntCount">PM��ǌ��݌�</param>
        /// <param name="goodsSpclInstruction">���i�K�i�E���L����</param>
        /// <param name="mkrSuggestRtPric">���[�J�[��]�������i</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪</param>
        /// <param name="ansDeliDateDiv">�񓚔[���敪</param>
        /// <param name="goodsSpecialNtForFac">���i�K�i�E���L����(�H�����)</param>
        /// <param name="goodsSpecialNtForCOw">���i�K�i�E���L����(�J�[�I�[�i�[����)</param>
        /// <param name="prmSetDtlName2ForFac">�D�ǐݒ�ڍז��̂Q(�H�����)</param>
        /// <param name="prmSetDtlName2ForCOw">�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</param>
        /// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q</param>
        /// <param name="prmSetDtlName2">�D�ǐݒ�ڍז��̂Q</param>
        /// <param name="stockStatusDiv">�݌ɏ󋵋敪</param>
        /// <param name="inqBlUtyPtThCd">�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)(.C �R�[�h�̌n����)</param>
        /// <param name="inqBlUtyPtSbCd">�┭BL���ꕔ�i�T�u�R�[�h(.C �R�[�h�̌n����)</param>
        /// <param name="ansBlUtyPtThCd">��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)(.C �R�[�h�̌n����)</param>
        /// <param name="ansBlUtyPtSbCd">��BL���ꕔ�i�T�u�R�[�h(.C �R�[�h�̌n����)</param>
        /// <param name="ansBLGoodsCode">��BL���i�R�[�h</param>
        /// <param name="ansBLGoodsDrCode">��BL���i�R�[�h�}��</param>
        /// <returns>SCMAcOdSetDtWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
        /// </remarks>
        public SCMAcOdSetDtWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int32 setPartsMkrCd, string setPartsNumber, Int32 setPartsMainSubNo, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 pMAcptAnOdrStatus, Int32 pMSalesSlipNum, Int32 pMSalesRowNo, string pmWarehouseCd, string pmWarehouseName, string pmShelfNo, Double pmPrsntCount
            , string pmMainMngWarehouseCd, string pmMainMngWarehouseName, string pmMainMngShelfNo, Double pmMainMngPrsntCount // ADD 2013/02/27 qijh #34752
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
            , string goodsSpclInstruction
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
            , Int64 mkrSuggestRtPric, Int32 openPriceDiv // ADD 2015/01/19 �L�� SCM������ PMNS�Ή�
            , Int16 ansDeliDateDiv // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
            , string goodsSpecialNtForFac // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
            , string goodsSpecialNtForCOw // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
            , string prmSetDtlName2ForFac // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
            , string prmSetDtlName2ForCOw // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
            , int prmSetDtlNo2      // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�
            , string prmSetDtlName2 // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�
            , short stockStatusDiv    // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            , string inqBlUtyPtThCd
            ,Int32 inqBlUtyPtSbCd
            ,string ansBlUtyPtThCd
            ,Int32 ansBlUtyPtSbCd
            ,Int32 ansBLGoodsCode
            ,Int32 ansBLGoodsDrCode
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            )
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();	//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inquiryNumber = inquiryNumber;
            this._setPartsMkrCd = setPartsMkrCd;
            this._setPartsNumber = setPartsNumber;
            this._setPartsMainSubNo = setPartsMainSubNo;
            this._goodsDivCd = goodsDivCd;
            this._recyclePrtKindCode = recyclePrtKindCode;
            this._recyclePrtKindName = recyclePrtKindName;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._handleDivCode = handleDivCode;
            this._goodsShape = goodsShape;
            this._delivrdGdsConfCd = delivrdGdsConfCd;
            this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
            this._answerDeliveryDate = answerDeliveryDate;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsDrCode = bLGoodsDrCode;
            this._inqGoodsName = inqGoodsName;
            this._ansGoodsName = ansGoodsName;
            this._salesOrderCount = salesOrderCount;
            this._deliveredGoodsCount = deliveredGoodsCount;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMakerNm = goodsMakerNm;
            this._pureGoodsMakerCd = pureGoodsMakerCd;
            this._inqPureGoodsNo = inqPureGoodsNo;
            this._ansPureGoodsNo = ansPureGoodsNo;
            this._listPrice = listPrice;
            this._unitPrice = unitPrice;
            this._goodsAddInfo = goodsAddInfo;
            this._roughRrofit = roughRrofit;
            this._roughRate = roughRate;
            this._answerLimitDate = answerLimitDate;
            this._commentDtl = commentDtl;
            this._shelfNo = shelfNo;
            this._pMAcptAnOdrStatus = pMAcptAnOdrStatus;
            this._pMSalesSlipNum = pMSalesSlipNum;
            this._pMSalesRowNo = pMSalesRowNo;
            this._pmWarehouseCd = pmWarehouseCd;
            this._pmWarehouseName = pmWarehouseName;
            this._pmShelfNo = pmShelfNo;
            this._pmPrsntCount = pmPrsntCount;
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            this._pmMainMngWarehouseCde = pmMainMngWarehouseCd;
            this._pmMainMngWarehouseName = pmMainMngWarehouseName;
            this._pmMainMngShelfNo = pmMainMngShelfNo;
            this._pmMainMngPrsntCount = pmMainMngPrsntCount;
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
            this._goodsSpclInstruction = GoodsSpclInstruction;
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
            // ADD 2015/01/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            this._mkrSuggestRtPric = mkrSuggestRtPric;
            this._openPriceDiv = openPriceDiv;
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._ansDeliDateDiv = ansDeliDateDiv;
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._goodsSpecialNtForFac = goodsSpecialNtForFac;
            this._goodsSpecialNtForCOw = goodsSpecialNtForCOw;
            this._prmSetDtlName2ForFac = prmSetDtlName2ForFac;
            this._prmSetDtlName2ForCOw = prmSetDtlName2ForCOw;
            // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._prmSetDtlName2 = prmSetDtlName2;
            this._stockStatusDiv = stockStatusDiv;
            // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._inqBlUtyPtThCd = inqBlUtyPtThCd;
            this._inqBlUtyPtSbCd = inqBlUtyPtSbCd;
            this._ansBlUtyPtThCd = ansBlUtyPtThCd;
            this._ansBlUtyPtSbCd = ansBlUtyPtSbCd;
            this._ansBLGoodsCode = ansBLGoodsCode;
            this._ansBLGoodsDrCode = ansBLGoodsDrCode;
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^���[�N��������
        /// </summary>
        /// <returns>SCMAcOdSetDtWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMAcOdSetDtWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
        /// </remarks>
        public SCMAcOdSetDtWork Clone()
        {
            return new SCMAcOdSetDtWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._setPartsMkrCd, this._setPartsNumber, this._setPartsMainSubNo, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._pMAcptAnOdrStatus, this._pMSalesSlipNum, this._pMSalesRowNo, this._pmWarehouseCd, this._pmWarehouseName, this._pmShelfNo, this._pmPrsntCount//@@@@20230303
                , this._pmMainMngWarehouseCde, this._pmMainMngWarehouseName, this._pmMainMngShelfNo, this._pmMainMngPrsntCount // ADD 2013/02/27 qijh #34752
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
                , this._goodsSpclInstruction
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
                , this._mkrSuggestRtPric, this._openPriceDiv // ADD 2015/01/19 �L�� SCM������ PMNS�Ή�
                , this._ansDeliDateDiv  // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή�
                , this._goodsSpecialNtForFac  // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
                , this._goodsSpecialNtForCOw  // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
                , this._prmSetDtlName2ForFac  // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
                , this._prmSetDtlName2ForCOw  // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
                , this._prmSetDtlNo2       // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�
                , this._prmSetDtlName2     // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�
                , this._stockStatusDiv     // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                , this._inqBlUtyPtThCd
                , this._inqBlUtyPtSbCd
                , this._ansBlUtyPtThCd
                , this._ansBlUtyPtSbCd
                , this._ansBLGoodsCode
                , this._ansBLGoodsDrCode
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
        }

        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SCMAcOdSetDtWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
        /// </remarks>
        public bool Equals(SCMAcOdSetDtWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())	//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InquiryNumber == target.InquiryNumber)
                 && (this.SetPartsMkrCd == target.SetPartsMkrCd)
                 && (this.SetPartsNumber == target.SetPartsNumber)
                 && (this.SetPartsMainSubNo == target.SetPartsMainSubNo)
                 && (this.GoodsDivCd == target.GoodsDivCd)
                 && (this.RecyclePrtKindCode == target.RecyclePrtKindCode)
                 && (this.RecyclePrtKindName == target.RecyclePrtKindName)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.HandleDivCode == target.HandleDivCode)
                 && (this.GoodsShape == target.GoodsShape)
                 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
                 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
                 && (this.AnswerDeliveryDate == target.AnswerDeliveryDate)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode)
                 && (this.InqGoodsName == target.InqGoodsName)
                 && (this.AnsGoodsName == target.AnsGoodsName)
                 && (this.SalesOrderCount == target.SalesOrderCount)
                 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMakerNm == target.GoodsMakerNm)
                 && (this.PureGoodsMakerCd == target.PureGoodsMakerCd)
                 && (this.InqPureGoodsNo == target.InqPureGoodsNo)
                 && (this.AnsPureGoodsNo == target.AnsPureGoodsNo)
                 && (this.ListPrice == target.ListPrice)
                 && (this.UnitPrice == target.UnitPrice)
                 && (this.GoodsAddInfo == target.GoodsAddInfo)
                 && (this.RoughRrofit == target.RoughRrofit)
                 && (this.RoughRate == target.RoughRate)
                 && (this.AnswerLimitDate == target.AnswerLimitDate)
                 && (this.CommentDtl == target.CommentDtl)
                 && (this.ShelfNo == target.ShelfNo)
                 && (this.PMAcptAnOdrStatus == target.PMAcptAnOdrStatus)
                 && (this.PMSalesSlipNum == target.PMSalesSlipNum)
                 && (this.PMSalesRowNo == target.PMSalesRowNo)
                 && (this.PmWarehouseCd == target.PmWarehouseCd)
                 && (this.PmWarehouseName == target.PmWarehouseName)
                 && (this.PmShelfNo == target.PmShelfNo)
                 && (this.PmPrsntCount == target.PmPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                 && (this.PmMainMngWarehouseCd == target.PmMainMngWarehouseCd)
                 && (this.PmMainMngWarehouseName == target.PmMainMngWarehouseName)
                 && (this.PmMainMngShelfNo == target.PmMainMngShelfNo)
                 && (this.PmMainMngPrsntCount == target.PmMainMngPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
                 && (this.PmPrsntCount == target.PmPrsntCount)
                 && (this.GoodsSpclInstruction == target.GoodsSpclInstruction)
                // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
                 && (this.MkrSuggestRtPric == target.MkrSuggestRtPric)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (this.AnsDeliDateDiv == target.AnsDeliDateDiv)
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (this.GoodsSpecialNtForFac == target.GoodsSpecialNtForFac)
                && (this.GoodsSpecialNtForCOw == target.GoodsSpecialNtForCOw)
                && (this.PrmSetDtlName2ForFac == target.PrmSetDtlName2ForFac)
                && (this.PrmSetDtlName2ForCOw == target.PrmSetDtlName2ForCOw)
                // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
                && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
                && (this.StockStatusDiv == target.StockStatusDiv)
                // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.InqBlUtyPtThCd == target.InqBlUtyPtThCd)
                 && (this.InqBlUtyPtSbCd == target.InqBlUtyPtSbCd)
                 && (this.AnsBlUtyPtThCd == target.AnsBlUtyPtThCd)
                 && (this.AnsBlUtyPtSbCd == target.AnsBlUtyPtSbCd)
                 && (this.AnsBLGoodsCode == target.AnsBLGoodsCode)
                 && (this.AnsBLGoodsDrCode == target.AnsBLGoodsDrCode)
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
        }

        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^���[�N��r����
        /// </summary>
        /// <param name="scmAcOdSetDt1">
        ///                    ��r����SCMAcOdSetDtWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="scmAcOdSetDt2">��r����SCMAcOdSetDtWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
        /// </remarks>
        public static bool Equals(SCMAcOdSetDtWork scmAcOdSetDt1, SCMAcOdSetDtWork scmAcOdSetDt2)
        {
            return ((scmAcOdSetDt1.CreateDateTime == scmAcOdSetDt2.CreateDateTime)
                 && (scmAcOdSetDt1.UpdateDateTime == scmAcOdSetDt2.UpdateDateTime)
                 && (scmAcOdSetDt1.EnterpriseCode == scmAcOdSetDt2.EnterpriseCode)
                 && (scmAcOdSetDt1.FileHeaderGuid == scmAcOdSetDt2.FileHeaderGuid)
                 && (scmAcOdSetDt1.UpdEmployeeCode == scmAcOdSetDt2.UpdEmployeeCode)
                 && (scmAcOdSetDt1.UpdAssemblyId1 == scmAcOdSetDt2.UpdAssemblyId1)
                 && (scmAcOdSetDt1.UpdAssemblyId2 == scmAcOdSetDt2.UpdAssemblyId2)
                 && (scmAcOdSetDt1.LogicalDeleteCode == scmAcOdSetDt2.LogicalDeleteCode)
                 && (scmAcOdSetDt1.InqOriginalEpCd.Trim() == scmAcOdSetDt2.InqOriginalEpCd.Trim())	//@@@@20230303
                 && (scmAcOdSetDt1.InqOriginalSecCd == scmAcOdSetDt2.InqOriginalSecCd)
                 && (scmAcOdSetDt1.InqOtherEpCd == scmAcOdSetDt2.InqOtherEpCd)
                 && (scmAcOdSetDt1.InqOtherSecCd == scmAcOdSetDt2.InqOtherSecCd)
                 && (scmAcOdSetDt1.InquiryNumber == scmAcOdSetDt2.InquiryNumber)
                 && (scmAcOdSetDt1.SetPartsMkrCd == scmAcOdSetDt2.SetPartsMkrCd)
                 && (scmAcOdSetDt1.SetPartsNumber == scmAcOdSetDt2.SetPartsNumber)
                 && (scmAcOdSetDt1.SetPartsMainSubNo == scmAcOdSetDt2.SetPartsMainSubNo)
                 && (scmAcOdSetDt1.GoodsDivCd == scmAcOdSetDt2.GoodsDivCd)
                 && (scmAcOdSetDt1.RecyclePrtKindCode == scmAcOdSetDt2.RecyclePrtKindCode)
                 && (scmAcOdSetDt1.RecyclePrtKindName == scmAcOdSetDt2.RecyclePrtKindName)
                 && (scmAcOdSetDt1.DeliveredGoodsDiv == scmAcOdSetDt2.DeliveredGoodsDiv)
                 && (scmAcOdSetDt1.HandleDivCode == scmAcOdSetDt2.HandleDivCode)
                 && (scmAcOdSetDt1.GoodsShape == scmAcOdSetDt2.GoodsShape)
                 && (scmAcOdSetDt1.DelivrdGdsConfCd == scmAcOdSetDt2.DelivrdGdsConfCd)
                 && (scmAcOdSetDt1.DeliGdsCmpltDueDate == scmAcOdSetDt2.DeliGdsCmpltDueDate)
                 && (scmAcOdSetDt1.AnswerDeliveryDate == scmAcOdSetDt2.AnswerDeliveryDate)
                 && (scmAcOdSetDt1.BLGoodsCode == scmAcOdSetDt2.BLGoodsCode)
                 && (scmAcOdSetDt1.BLGoodsDrCode == scmAcOdSetDt2.BLGoodsDrCode)
                 && (scmAcOdSetDt1.InqGoodsName == scmAcOdSetDt2.InqGoodsName)
                 && (scmAcOdSetDt1.AnsGoodsName == scmAcOdSetDt2.AnsGoodsName)
                 && (scmAcOdSetDt1.SalesOrderCount == scmAcOdSetDt2.SalesOrderCount)
                 && (scmAcOdSetDt1.DeliveredGoodsCount == scmAcOdSetDt2.DeliveredGoodsCount)
                 && (scmAcOdSetDt1.GoodsNo == scmAcOdSetDt2.GoodsNo)
                 && (scmAcOdSetDt1.GoodsMakerCd == scmAcOdSetDt2.GoodsMakerCd)
                 && (scmAcOdSetDt1.GoodsMakerNm == scmAcOdSetDt2.GoodsMakerNm)
                 && (scmAcOdSetDt1.PureGoodsMakerCd == scmAcOdSetDt2.PureGoodsMakerCd)
                 && (scmAcOdSetDt1.InqPureGoodsNo == scmAcOdSetDt2.InqPureGoodsNo)
                 && (scmAcOdSetDt1.AnsPureGoodsNo == scmAcOdSetDt2.AnsPureGoodsNo)
                 && (scmAcOdSetDt1.ListPrice == scmAcOdSetDt2.ListPrice)
                 && (scmAcOdSetDt1.UnitPrice == scmAcOdSetDt2.UnitPrice)
                 && (scmAcOdSetDt1.GoodsAddInfo == scmAcOdSetDt2.GoodsAddInfo)
                 && (scmAcOdSetDt1.RoughRrofit == scmAcOdSetDt2.RoughRrofit)
                 && (scmAcOdSetDt1.RoughRate == scmAcOdSetDt2.RoughRate)
                 && (scmAcOdSetDt1.AnswerLimitDate == scmAcOdSetDt2.AnswerLimitDate)
                 && (scmAcOdSetDt1.CommentDtl == scmAcOdSetDt2.CommentDtl)
                 && (scmAcOdSetDt1.ShelfNo == scmAcOdSetDt2.ShelfNo)
                 && (scmAcOdSetDt1.PMAcptAnOdrStatus == scmAcOdSetDt2.PMAcptAnOdrStatus)
                 && (scmAcOdSetDt1.PMSalesSlipNum == scmAcOdSetDt2.PMSalesSlipNum)
                 && (scmAcOdSetDt1.PMSalesRowNo == scmAcOdSetDt2.PMSalesRowNo)
                 && (scmAcOdSetDt1.PmWarehouseCd == scmAcOdSetDt2.PmWarehouseCd)
                 && (scmAcOdSetDt1.PmWarehouseName == scmAcOdSetDt2.PmWarehouseName)
                 && (scmAcOdSetDt1.PmShelfNo == scmAcOdSetDt2.PmShelfNo)
                 && (scmAcOdSetDt1.PmPrsntCount == scmAcOdSetDt2.PmPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                 && (scmAcOdSetDt1.PmMainMngWarehouseCd == scmAcOdSetDt2.PmMainMngWarehouseCd)
                 && (scmAcOdSetDt1.PmMainMngWarehouseName == scmAcOdSetDt2.PmMainMngWarehouseName)
                 && (scmAcOdSetDt1.PmMainMngShelfNo == scmAcOdSetDt2.PmMainMngShelfNo)
                 && (scmAcOdSetDt1.PmMainMngPrsntCount == scmAcOdSetDt2.PmMainMngPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
                 && (scmAcOdSetDt1.PmPrsntCount == scmAcOdSetDt2.PmPrsntCount)
                 && (scmAcOdSetDt1.GoodsSpclInstruction == scmAcOdSetDt2.GoodsSpclInstruction)
                // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
                 && (scmAcOdSetDt1.MkrSuggestRtPric == scmAcOdSetDt2.MkrSuggestRtPric)
                 && (scmAcOdSetDt1.OpenPriceDiv == scmAcOdSetDt2.OpenPriceDiv)
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (scmAcOdSetDt1.AnsDeliDateDiv == scmAcOdSetDt2.AnsDeliDateDiv)
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (scmAcOdSetDt1.GoodsSpecialNtForFac == scmAcOdSetDt2.GoodsSpecialNtForFac)
                && (scmAcOdSetDt1.GoodsSpecialNtForCOw == scmAcOdSetDt2.GoodsSpecialNtForCOw)
                && (scmAcOdSetDt1.PrmSetDtlName2ForFac == scmAcOdSetDt2.PrmSetDtlName2ForFac)
                && (scmAcOdSetDt1.PrmSetDtlName2ForCOw == scmAcOdSetDt2.PrmSetDtlName2ForCOw)
                // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
                && (scmAcOdSetDt1.PrmSetDtlNo2 == scmAcOdSetDt2.PrmSetDtlNo2)
                && (scmAcOdSetDt1.PrmSetDtlName2 == scmAcOdSetDt2.PrmSetDtlName2)
                && (scmAcOdSetDt1.StockStatusDiv == scmAcOdSetDt2.StockStatusDiv)
                // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (scmAcOdSetDt1.InqBlUtyPtThCd == scmAcOdSetDt2.InqBlUtyPtThCd)
                 && (scmAcOdSetDt1.InqBlUtyPtSbCd == scmAcOdSetDt2.InqBlUtyPtSbCd)
                 && (scmAcOdSetDt1.AnsBlUtyPtThCd == scmAcOdSetDt2.AnsBlUtyPtThCd)
                 && (scmAcOdSetDt1.AnsBlUtyPtSbCd == scmAcOdSetDt2.AnsBlUtyPtSbCd)
                 && (scmAcOdSetDt1.AnsBLGoodsCode == scmAcOdSetDt2.AnsBLGoodsCode)
                 && (scmAcOdSetDt1.AnsBLGoodsDrCode == scmAcOdSetDt2.AnsBLGoodsDrCode)
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
        }
        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SCMAcOdSetDtWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
        /// </remarks>
        public ArrayList Compare(SCMAcOdSetDtWork target)
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
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            if (this.SetPartsMkrCd != target.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (this.SetPartsNumber != target.SetPartsNumber) resList.Add("SetPartsNumber");
            if (this.SetPartsMainSubNo != target.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
            if (this.RecyclePrtKindCode != target.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (this.RecyclePrtKindName != target.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.HandleDivCode != target.HandleDivCode) resList.Add("HandleDivCode");
            if (this.GoodsShape != target.GoodsShape) resList.Add("GoodsShape");
            if (this.DelivrdGdsConfCd != target.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (this.AnswerDeliveryDate != target.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (this.InqGoodsName != target.InqGoodsName) resList.Add("InqGoodsName");
            if (this.AnsGoodsName != target.AnsGoodsName) resList.Add("AnsGoodsName");
            if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
            if (this.DeliveredGoodsCount != target.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (this.PureGoodsMakerCd != target.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (this.InqPureGoodsNo != target.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (this.AnsPureGoodsNo != target.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.UnitPrice != target.UnitPrice) resList.Add("UnitPrice");
            if (this.GoodsAddInfo != target.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (this.RoughRrofit != target.RoughRrofit) resList.Add("RoughRrofit");
            if (this.RoughRate != target.RoughRate) resList.Add("RoughRate");
            if (this.AnswerLimitDate != target.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (this.CommentDtl != target.CommentDtl) resList.Add("CommentDtl");
            if (this.ShelfNo != target.ShelfNo) resList.Add("ShelfNo");
            if (this.PMAcptAnOdrStatus != target.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (this.PMSalesSlipNum != target.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (this.PMSalesRowNo != target.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (this.PmWarehouseCd != target.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (this.PmWarehouseName != target.PmWarehouseName) resList.Add("PmWarehouseName");
            if (this.PmShelfNo != target.PmShelfNo) resList.Add("PmShelfNo");
            if (this.PmPrsntCount != target.PmPrsntCount) resList.Add("PmPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            if (this.PmMainMngWarehouseCd != target.PmMainMngWarehouseCd) resList.Add("PmMainMngWarehouseCd");
            if (this.PmMainMngWarehouseName != target.PmMainMngWarehouseName) resList.Add("PmMainMngWarehouseName");
            if (this.PmMainMngShelfNo != target.PmMainMngShelfNo) resList.Add("PmMainMngShelfNo");
            if (this.PmMainMngPrsntCount != target.PmMainMngPrsntCount) resList.Add("PmMainMngPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
            if (this.GoodsSpclInstruction != target.GoodsSpclInstruction) resList.Add("GoodsSpclInstruction");
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
            if (this.MkrSuggestRtPric != target.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AnsDeliDateDiv != target.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.GoodsSpecialNtForFac != target.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (this.GoodsSpecialNtForCOw != target.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (this.PrmSetDtlName2ForFac != target.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (this.PrmSetDtlName2ForCOw != target.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.PrmSetDtlName2 != target.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (this.StockStatusDiv != target.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.InqBlUtyPtThCd != target.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (this.InqBlUtyPtSbCd != target.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (this.AnsBlUtyPtThCd != target.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (this.AnsBlUtyPtSbCd != target.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (this.AnsBLGoodsCode != target.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (this.AnsBLGoodsDrCode != target.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return resList;
        }

        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^���[�N��r����
        /// </summary>
        /// <param name="scmAcOdSetDt1">��r����SCMAcOdSetDtWork�N���X�̃C���X�^���X</param>
        /// <param name="scmAcOdSetDt2">��r����SCMAcOdSetDtWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
        /// </remarks>
        public static ArrayList Compare(SCMAcOdSetDtWork scmAcOdSetDt1, SCMAcOdSetDtWork scmAcOdSetDt2)
        {
            ArrayList resList = new ArrayList();
            if (scmAcOdSetDt1.CreateDateTime != scmAcOdSetDt2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmAcOdSetDt1.UpdateDateTime != scmAcOdSetDt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmAcOdSetDt1.EnterpriseCode != scmAcOdSetDt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (scmAcOdSetDt1.FileHeaderGuid != scmAcOdSetDt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (scmAcOdSetDt1.UpdEmployeeCode != scmAcOdSetDt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (scmAcOdSetDt1.UpdAssemblyId1 != scmAcOdSetDt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (scmAcOdSetDt1.UpdAssemblyId2 != scmAcOdSetDt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (scmAcOdSetDt1.LogicalDeleteCode != scmAcOdSetDt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmAcOdSetDt1.InqOriginalEpCd.Trim() != scmAcOdSetDt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
            if (scmAcOdSetDt1.InqOriginalSecCd != scmAcOdSetDt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (scmAcOdSetDt1.InqOtherEpCd != scmAcOdSetDt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (scmAcOdSetDt1.InqOtherSecCd != scmAcOdSetDt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (scmAcOdSetDt1.InquiryNumber != scmAcOdSetDt2.InquiryNumber) resList.Add("InquiryNumber");
            if (scmAcOdSetDt1.SetPartsMkrCd != scmAcOdSetDt2.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (scmAcOdSetDt1.SetPartsNumber != scmAcOdSetDt2.SetPartsNumber) resList.Add("SetPartsNumber");
            if (scmAcOdSetDt1.SetPartsMainSubNo != scmAcOdSetDt2.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (scmAcOdSetDt1.GoodsDivCd != scmAcOdSetDt2.GoodsDivCd) resList.Add("GoodsDivCd");
            if (scmAcOdSetDt1.RecyclePrtKindCode != scmAcOdSetDt2.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (scmAcOdSetDt1.RecyclePrtKindName != scmAcOdSetDt2.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (scmAcOdSetDt1.DeliveredGoodsDiv != scmAcOdSetDt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (scmAcOdSetDt1.HandleDivCode != scmAcOdSetDt2.HandleDivCode) resList.Add("HandleDivCode");
            if (scmAcOdSetDt1.GoodsShape != scmAcOdSetDt2.GoodsShape) resList.Add("GoodsShape");
            if (scmAcOdSetDt1.DelivrdGdsConfCd != scmAcOdSetDt2.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (scmAcOdSetDt1.DeliGdsCmpltDueDate != scmAcOdSetDt2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (scmAcOdSetDt1.AnswerDeliveryDate != scmAcOdSetDt2.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (scmAcOdSetDt1.BLGoodsCode != scmAcOdSetDt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (scmAcOdSetDt1.BLGoodsDrCode != scmAcOdSetDt2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (scmAcOdSetDt1.InqGoodsName != scmAcOdSetDt2.InqGoodsName) resList.Add("InqGoodsName");
            if (scmAcOdSetDt1.AnsGoodsName != scmAcOdSetDt2.AnsGoodsName) resList.Add("AnsGoodsName");
            if (scmAcOdSetDt1.SalesOrderCount != scmAcOdSetDt2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (scmAcOdSetDt1.DeliveredGoodsCount != scmAcOdSetDt2.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (scmAcOdSetDt1.GoodsNo != scmAcOdSetDt2.GoodsNo) resList.Add("GoodsNo");
            if (scmAcOdSetDt1.GoodsMakerCd != scmAcOdSetDt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (scmAcOdSetDt1.GoodsMakerNm != scmAcOdSetDt2.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (scmAcOdSetDt1.PureGoodsMakerCd != scmAcOdSetDt2.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (scmAcOdSetDt1.InqPureGoodsNo != scmAcOdSetDt2.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (scmAcOdSetDt1.AnsPureGoodsNo != scmAcOdSetDt2.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (scmAcOdSetDt1.ListPrice != scmAcOdSetDt2.ListPrice) resList.Add("ListPrice");
            if (scmAcOdSetDt1.UnitPrice != scmAcOdSetDt2.UnitPrice) resList.Add("UnitPrice");
            if (scmAcOdSetDt1.GoodsAddInfo != scmAcOdSetDt2.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (scmAcOdSetDt1.RoughRrofit != scmAcOdSetDt2.RoughRrofit) resList.Add("RoughRrofit");
            if (scmAcOdSetDt1.RoughRate != scmAcOdSetDt2.RoughRate) resList.Add("RoughRate");
            if (scmAcOdSetDt1.AnswerLimitDate != scmAcOdSetDt2.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (scmAcOdSetDt1.CommentDtl != scmAcOdSetDt2.CommentDtl) resList.Add("CommentDtl");
            if (scmAcOdSetDt1.ShelfNo != scmAcOdSetDt2.ShelfNo) resList.Add("ShelfNo");
            if (scmAcOdSetDt1.PMAcptAnOdrStatus != scmAcOdSetDt2.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (scmAcOdSetDt1.PMSalesSlipNum != scmAcOdSetDt2.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (scmAcOdSetDt1.PMSalesRowNo != scmAcOdSetDt2.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (scmAcOdSetDt1.PmWarehouseCd != scmAcOdSetDt2.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (scmAcOdSetDt1.PmWarehouseName != scmAcOdSetDt2.PmWarehouseName) resList.Add("PmWarehouseName");
            if (scmAcOdSetDt1.PmShelfNo != scmAcOdSetDt2.PmShelfNo) resList.Add("PmShelfNo");
            if (scmAcOdSetDt1.PmPrsntCount != scmAcOdSetDt2.PmPrsntCount) resList.Add("PmPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            if (scmAcOdSetDt1.PmMainMngWarehouseCd != scmAcOdSetDt2.PmMainMngWarehouseCd) resList.Add("PmMainMngWarehouseCd");
            if (scmAcOdSetDt1.PmMainMngWarehouseName != scmAcOdSetDt2.PmMainMngWarehouseName) resList.Add("PmMainMngWarehouseName");
            if (scmAcOdSetDt1.PmMainMngShelfNo != scmAcOdSetDt2.PmMainMngShelfNo) resList.Add("PmMainMngShelfNo");
            if (scmAcOdSetDt1.PmMainMngPrsntCount != scmAcOdSetDt2.PmMainMngPrsntCount) resList.Add("PmMainMngPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
            if (scmAcOdSetDt1.GoodsSpclInstruction != scmAcOdSetDt2.GoodsSpclInstruction) resList.Add("GoodsSpclInstruction");
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
            if (scmAcOdSetDt1.MkrSuggestRtPric != scmAcOdSetDt2.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (scmAcOdSetDt1.OpenPriceDiv != scmAcOdSetDt2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmAcOdSetDt1.AnsDeliDateDiv != scmAcOdSetDt2.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmAcOdSetDt1.GoodsSpecialNtForFac != scmAcOdSetDt2.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (scmAcOdSetDt1.GoodsSpecialNtForCOw != scmAcOdSetDt2.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (scmAcOdSetDt1.PrmSetDtlName2ForFac != scmAcOdSetDt2.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (scmAcOdSetDt1.PrmSetDtlName2ForCOw != scmAcOdSetDt2.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
            if (scmAcOdSetDt1.PrmSetDtlNo2 != scmAcOdSetDt2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (scmAcOdSetDt1.PrmSetDtlName2 != scmAcOdSetDt2.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (scmAcOdSetDt1.StockStatusDiv != scmAcOdSetDt2.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmAcOdSetDt1.InqBlUtyPtThCd != scmAcOdSetDt2.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (scmAcOdSetDt1.InqBlUtyPtSbCd != scmAcOdSetDt2.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (scmAcOdSetDt1.AnsBlUtyPtThCd != scmAcOdSetDt2.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (scmAcOdSetDt1.AnsBlUtyPtSbCd != scmAcOdSetDt2.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (scmAcOdSetDt1.AnsBLGoodsCode != scmAcOdSetDt2.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (scmAcOdSetDt1.AnsBLGoodsDrCode != scmAcOdSetDt2.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return resList;
        }
	}
	
	/// <summary>
///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
/// </summary>
/// <returns>SCMAcOdSetDtWork�N���X�̃C���X�^���X(object)</returns>
/// <remarks>
/// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
/// </remarks>
public class ScmAcOdSetDtWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
	#region ICustomSerializationSurrogate �����o
	
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	/// </summary>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  ScmAcOdSetDtWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is SCMAcOdSetDtWork || graph is ArrayList || graph is SCMAcOdSetDtWork[]) )
			throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAcOdSetDtWork).FullName ) );

		if( graph != null && graph is SCMAcOdSetDtWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork" );

		//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}
                else if( graph is SCMAcOdSetDtWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((SCMAcOdSetDtWork[])graph).Length;
		}
		else if( graph is SCMAcOdSetDtWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		//�쐬����
		serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
		//�X�V����
		serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
		//��ƃR�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		//GUID
		serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
		//�X�V�]�ƈ��R�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
		//�X�V�A�Z���u��ID1
		serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
		//�X�V�A�Z���u��ID2
		serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
		//�_���폜�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
		//�⍇������ƃR�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalEpCd
		//�⍇�������_�R�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalSecCd
		//�⍇�����ƃR�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //InqOtherEpCd
		//�⍇���拒�_�R�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //InqOtherSecCd
		//�⍇���ԍ�
		serInfo.MemberInfo.Add( typeof(Int64) ); //InquiryNumber
		//�Z�b�g���i���[�J�[�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //SetPartsMkrCd
		//�Z�b�g���i�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //SetPartsNumber
		//�Z�b�g���i�e�q�ԍ�
		serInfo.MemberInfo.Add( typeof(Int32) ); //SetPartsMainSubNo
		//���i���
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsDivCd
		//���T�C�N�����i���
		serInfo.MemberInfo.Add( typeof(Int32) ); //RecyclePrtKindCode
		//���T�C�N�����i��ʖ���
		serInfo.MemberInfo.Add( typeof(string) ); //RecyclePrtKindName
		//�[�i�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //DeliveredGoodsDiv
		//�戵�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //HandleDivCode
		//���i�`��
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsShape
		//�[�i�m�F�敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //DelivrdGdsConfCd
		//�[�i�����\���
		serInfo.MemberInfo.Add( typeof(Int32) ); //DeliGdsCmpltDueDate
		//�񓚔[��
		serInfo.MemberInfo.Add( typeof(string) ); //AnswerDeliveryDate
		//BL���i�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //BLGoodsCode
		//BL���i�R�[�h�}��
		serInfo.MemberInfo.Add( typeof(Int32) ); //BLGoodsDrCode
		//�┭���i��
		serInfo.MemberInfo.Add( typeof(string) ); //InqGoodsName
		//�񓚏��i��
		serInfo.MemberInfo.Add( typeof(string) ); //AnsGoodsName
		//������
		serInfo.MemberInfo.Add( typeof(Double) ); //SalesOrderCount
		//�[�i��
		serInfo.MemberInfo.Add( typeof(Double) ); //DeliveredGoodsCount
		//���i�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsNo
		//���i���[�J�[�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsMakerCd
		//���i���[�J�[����
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsMakerNm
		//�������i���[�J�[�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //PureGoodsMakerCd
		//�┭�������i�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //InqPureGoodsNo
		//�񓚏������i�ԍ�
		serInfo.MemberInfo.Add( typeof(string) ); //AnsPureGoodsNo
		//�艿
		serInfo.MemberInfo.Add( typeof(Int64) ); //ListPrice
		//�P��
		serInfo.MemberInfo.Add( typeof(Int64) ); //UnitPrice
		//���i�⑫���
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsAddInfo
		//�e���z
		serInfo.MemberInfo.Add( typeof(Int64) ); //RoughRrofit
		//�e����
		serInfo.MemberInfo.Add( typeof(Double) ); //RoughRate
		//�񓚊���
		serInfo.MemberInfo.Add( typeof(Int32) ); //AnswerLimitDate
		//���l(����)
		serInfo.MemberInfo.Add( typeof(string) ); //CommentDtl
		//�I��
		serInfo.MemberInfo.Add( typeof(string) ); //ShelfNo
		//PM�󒍃X�e�[�^�X
		serInfo.MemberInfo.Add( typeof(Int32) ); //PMAcptAnOdrStatus
		//PM����`�[�ԍ�
		serInfo.MemberInfo.Add( typeof(Int32) ); //PMSalesSlipNum
		//PM����s�ԍ�
		serInfo.MemberInfo.Add( typeof(Int32) ); //PMSalesRowNo
		//PM�q�ɃR�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //PmWarehouseCd
		//PM�q�ɖ���
		serInfo.MemberInfo.Add( typeof(string) ); //PmWarehouseName
		//PM�I��
		serInfo.MemberInfo.Add( typeof(string) ); //PmShelfNo
		//PM���݌�
		serInfo.MemberInfo.Add( typeof(Double) ); //PmPrsntCount
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        //PM��Ǒq�ɃR�[�h
        serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseCd 
        //PM��Ǒq�ɖ���
        serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseName
        //PM��ǒI��
        serInfo.MemberInfo.Add(typeof(string)); //PmMainMngShelfNo
        //PM��ǌ��݌�
        serInfo.MemberInfo.Add(typeof(Double)); //PmMainMngPrsntCount
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        //���i�K�i�E���L����
        serInfo.MemberInfo.Add(typeof(string)); //GoodsSpclInstruction
        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<

        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
        // ���[�J�[��]�������i
        serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
	    // �I�[�v�����i�敪
        serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // �񓚔[���敪
        serInfo.MemberInfo.Add(typeof(Int16)); // AnsDeliDateDiv
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        // �D�ǐݒ�ڍ׃R�[�h�Q
        serInfo.MemberInfo.Add(typeof(Int32)); // PrmSetDtlNo2
        // �D�ǐݒ�ڍז��̂Q
        serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2
        // �݌ɏ󋵋敪
        serInfo.MemberInfo.Add(typeof(Int32)); // StockStatusDiv
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // ���i�K�i�E���L����(�H�����)
        serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForFac
        // ���i�K�i�E���L����(�J�[�I�[�i�[����)
        serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForCOw
        // �D�ǐݒ�ڍז��̂Q(�H�����)
        serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForFac
        // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
        serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForCOw
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
        serInfo.MemberInfo.Add(typeof(string)); //InqBlUtyPtThCd
        //�┭BL���ꕔ�i�T�u�R�[�h
        serInfo.MemberInfo.Add(typeof(Int32)); //InqBlUtyPtSbCd
        //��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
        serInfo.MemberInfo.Add(typeof(string)); //AnsBlUtyPtThCd
        //��BL���ꕔ�i�T�u�R�[�h
        serInfo.MemberInfo.Add(typeof(Int32)); //AnsBlUtyPtSbCd
        //��BL���i�R�[�h
        serInfo.MemberInfo.Add(typeof(Int32)); //AnsBLGoodsCode
        //��BL���i�R�[�h�}��
        serInfo.MemberInfo.Add(typeof(Int32)); //AnsBLGoodsDrCode
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        serInfo.Serialize(writer, serInfo);
		if( graph is SCMAcOdSetDtWork )
		{
			SCMAcOdSetDtWork temp = (SCMAcOdSetDtWork)graph;

			SetScmAcOdSetDtWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is SCMAcOdSetDtWork[])
			{
				lst = new ArrayList();
				lst.AddRange((SCMAcOdSetDtWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(SCMAcOdSetDtWork temp in lst)
			{
				SetScmAcOdSetDtWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// SCMAcOdSetDtWork�����o��(public�v���p�e�B��)
	/// </summary>
    // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
    #region ���\�[�X
    ////private const int currentMemberCount = 52;// DEL 2013/02/27 qijh #34752
    //// UPD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
    ////private const int currentMemberCount = 56; // ADD 2013/02/27 qijh #34752	
    //// UPD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
    ////private const int currentMemberCount = 57;
    //private const int currentMemberCount = 59;
    //// UPD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
    //// UPD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
    #endregion
    //private const int currentMemberCount = 60;    // DEL 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
    //private const int currentMemberCount = 64;      // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
    //private const int currentMemberCount = 67;      // ADD 2015/02/27 SCM������ �b������ʓ��L�Ή�// DEL 2018/04/16 �c���� �VBL�R�[�h�Ή�
    private const int currentMemberCount = 73;// ADD 2018/04/16 �c���� �VBL�R�[�h�Ή�
    // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
	
	/// <summary>
	///  SCMAcOdSetDtWork�C���X�^���X��������
	/// </summary>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�̃C���X�^���X����������</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
	/// </remarks>
	private void SetScmAcOdSetDtWork( System.IO.BinaryWriter writer, SCMAcOdSetDtWork temp )
	{
		//�쐬����
		writer.Write( (Int64)temp.CreateDateTime.Ticks );
		//�X�V����
		writer.Write( (Int64)temp.UpdateDateTime.Ticks );
		//��ƃR�[�h
		writer.Write( temp.EnterpriseCode );
		//GUID
		byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
		writer.Write( fileHeaderGuidArray.Length );
		writer.Write( temp.FileHeaderGuid.ToByteArray() );
		//�X�V�]�ƈ��R�[�h
		writer.Write( temp.UpdEmployeeCode );
		//�X�V�A�Z���u��ID1
		writer.Write( temp.UpdAssemblyId1 );
		//�X�V�A�Z���u��ID2
		writer.Write( temp.UpdAssemblyId2 );
		//�_���폜�敪
		writer.Write( temp.LogicalDeleteCode );
		//�⍇������ƃR�[�h
        writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
		//�⍇�������_�R�[�h
		writer.Write( temp.InqOriginalSecCd );
		//�⍇�����ƃR�[�h
		writer.Write( temp.InqOtherEpCd );
		//�⍇���拒�_�R�[�h
		writer.Write( temp.InqOtherSecCd );
		//�⍇���ԍ�
		writer.Write( temp.InquiryNumber );
		//�Z�b�g���i���[�J�[�R�[�h
		writer.Write( temp.SetPartsMkrCd );
		//�Z�b�g���i�ԍ�
		writer.Write( temp.SetPartsNumber );
		//�Z�b�g���i�e�q�ԍ�
		writer.Write( temp.SetPartsMainSubNo );
		//���i���
		writer.Write( temp.GoodsDivCd );
		//���T�C�N�����i���
		writer.Write( temp.RecyclePrtKindCode );
		//���T�C�N�����i��ʖ���
		writer.Write( temp.RecyclePrtKindName );
		//�[�i�敪
		writer.Write( temp.DeliveredGoodsDiv );
		//�戵�敪
		writer.Write( temp.HandleDivCode );
		//���i�`��
		writer.Write( temp.GoodsShape );
		//�[�i�m�F�敪
		writer.Write( temp.DelivrdGdsConfCd );
		//�[�i�����\���
        writer.Write((Int64)temp.CreateDateTime.Ticks);
		//�񓚔[��
		writer.Write( temp.AnswerDeliveryDate );
		//BL���i�R�[�h
		writer.Write( temp.BLGoodsCode );
		//BL���i�R�[�h�}��
		writer.Write( temp.BLGoodsDrCode );
		//�┭���i��
		writer.Write( temp.InqGoodsName );
		//�񓚏��i��
		writer.Write( temp.AnsGoodsName );
		//������
		writer.Write( temp.SalesOrderCount );
		//�[�i��
		writer.Write( temp.DeliveredGoodsCount );
		//���i�ԍ�
		writer.Write( temp.GoodsNo );
		//���i���[�J�[�R�[�h
		writer.Write( temp.GoodsMakerCd );
		//���i���[�J�[����
		writer.Write( temp.GoodsMakerNm );
		//�������i���[�J�[�R�[�h
		writer.Write( temp.PureGoodsMakerCd );
		//�┭�������i�ԍ�
		writer.Write( temp.InqPureGoodsNo );
		//�񓚏������i�ԍ�
		writer.Write( temp.AnsPureGoodsNo );
		//�艿
		writer.Write( temp.ListPrice );
		//�P��
		writer.Write( temp.UnitPrice );
		//���i�⑫���
		writer.Write( temp.GoodsAddInfo );
		//�e���z
		writer.Write( temp.RoughRrofit );
		//�e����
		writer.Write( temp.RoughRate );
		//�񓚊���
        writer.Write((Int64)temp.CreateDateTime.Ticks);
		//���l(����)
		writer.Write( temp.CommentDtl );
		//�I��
		writer.Write( temp.ShelfNo );
		//PM�󒍃X�e�[�^�X
		writer.Write( temp.PMAcptAnOdrStatus );
		//PM����`�[�ԍ�
		writer.Write( temp.PMSalesSlipNum );
		//PM����s�ԍ�
		writer.Write( temp.PMSalesRowNo );
		//PM�q�ɃR�[�h
		writer.Write( temp.PmWarehouseCd );
		//PM�q�ɖ���
		writer.Write( temp.PmWarehouseName );
		//PM�I��
		writer.Write( temp.PmShelfNo );
		//PM���݌�
		writer.Write( temp.PmPrsntCount );
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        //PM��Ǒq�ɃR�[�h
        writer.Write(temp.PmMainMngWarehouseCd);
        //PM��Ǒq�ɖ���
        writer.Write(temp.PmMainMngWarehouseName);
        //PM��ǒI��
        writer.Write(temp.PmMainMngShelfNo);
        //PM��ǌ��݌�
        writer.Write(temp.PmMainMngPrsntCount);
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        //���i�K�i�E���L����
        writer.Write(temp.GoodsSpclInstruction);
        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
        //���[�J�[��]�������i
        writer.Write(temp.MkrSuggestRtPric);
        //�I�[�v�����i�敪
        writer.Write(temp.OpenPriceDiv);
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // �񓚔[���敪
        writer.Write(temp.AnsDeliDateDiv);
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        // �D�ǐݒ�ڍ׃R�[�h�Q
        writer.Write(temp.PrmSetDtlNo2);
        // �D�ǐݒ�ڍז��̂Q
        writer.Write(temp.PrmSetDtlName2);
        // �݌ɏ󋵋敪
        writer.Write(temp.StockStatusDiv);
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // ���i�K�i�E���L����(�H�����)
        writer.Write(temp.GoodsSpecialNtForFac);
        // ���i�K�i�E���L����(�J�[�I�[�i�[����)
        writer.Write(temp.GoodsSpecialNtForCOw);
        // �D�ǐݒ�ڍז��̂Q(�H�����)
        writer.Write(temp.PrmSetDtlName2ForFac);
        // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
        writer.Write(temp.PrmSetDtlName2ForCOw);
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
        writer.Write(temp.InqBlUtyPtThCd);
        //�┭BL���ꕔ�i�T�u�R�[�h
        writer.Write(temp.InqBlUtyPtSbCd);
        //��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
        writer.Write(temp.AnsBlUtyPtThCd);
        //��BL���ꕔ�i�T�u�R�[�h
        writer.Write(temp.AnsBlUtyPtSbCd);
        //��BL���i�R�[�h
        writer.Write(temp.AnsBLGoodsCode);
        //��BL���i�R�[�h�}��
        writer.Write(temp.AnsBLGoodsDrCode);
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }

	/// <summary>
	///  SCMAcOdSetDtWork�C���X�^���X�擾
	/// </summary>
	/// <returns>SCMAcOdSetDtWork�N���X�̃C���X�^���X</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�̃C���X�^���X���擾���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
	/// </remarks>
	private SCMAcOdSetDtWork GetScmAcOdSetDtWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		// serInfo.MemberInfo.Count < currentMemberCount
		// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		SCMAcOdSetDtWork temp = new SCMAcOdSetDtWork();

		//�쐬����
		temp.CreateDateTime = new DateTime(reader.ReadInt64());
		//�X�V����
		temp.UpdateDateTime = new DateTime(reader.ReadInt64());
		//��ƃR�[�h
		temp.EnterpriseCode = reader.ReadString();
		//GUID
		int lenOfFileHeaderGuidArray = reader.ReadInt32();
		byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
		temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
		//�X�V�]�ƈ��R�[�h
		temp.UpdEmployeeCode = reader.ReadString();
		//�X�V�A�Z���u��ID1
		temp.UpdAssemblyId1 = reader.ReadString();
		//�X�V�A�Z���u��ID2
		temp.UpdAssemblyId2 = reader.ReadString();
		//�_���폜�敪
		temp.LogicalDeleteCode = reader.ReadInt32();
		//�⍇������ƃR�[�h
        temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
		//�⍇�������_�R�[�h
		temp.InqOriginalSecCd = reader.ReadString();
		//�⍇�����ƃR�[�h
		temp.InqOtherEpCd = reader.ReadString();
		//�⍇���拒�_�R�[�h
		temp.InqOtherSecCd = reader.ReadString();
		//�⍇���ԍ�
		temp.InquiryNumber = reader.ReadInt64();
		//�Z�b�g���i���[�J�[�R�[�h
		temp.SetPartsMkrCd = reader.ReadInt32();
		//�Z�b�g���i�ԍ�
		temp.SetPartsNumber = reader.ReadString();
		//�Z�b�g���i�e�q�ԍ�
		temp.SetPartsMainSubNo = reader.ReadInt32();
		//���i���
		temp.GoodsDivCd = reader.ReadInt32();
		//���T�C�N�����i���
		temp.RecyclePrtKindCode = reader.ReadInt32();
		//���T�C�N�����i��ʖ���
		temp.RecyclePrtKindName = reader.ReadString();
		//�[�i�敪
		temp.DeliveredGoodsDiv = reader.ReadInt32();
		//�戵�敪
		temp.HandleDivCode = reader.ReadInt32();
		//���i�`��
		temp.GoodsShape = reader.ReadInt32();
		//�[�i�m�F�敪
		temp.DelivrdGdsConfCd = reader.ReadInt32();
		//�[�i�����\���
		temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
		//�񓚔[��
		temp.AnswerDeliveryDate = reader.ReadString();
		//BL���i�R�[�h
		temp.BLGoodsCode = reader.ReadInt32();
		//BL���i�R�[�h�}��
		temp.BLGoodsDrCode = reader.ReadInt32();
		//�┭���i��
		temp.InqGoodsName = reader.ReadString();
		//�񓚏��i��
		temp.AnsGoodsName = reader.ReadString();
		//������
		temp.SalesOrderCount = reader.ReadDouble();
		//�[�i��
		temp.DeliveredGoodsCount = reader.ReadDouble();
		//���i�ԍ�
		temp.GoodsNo = reader.ReadString();
		//���i���[�J�[�R�[�h
		temp.GoodsMakerCd = reader.ReadInt32();
		//���i���[�J�[����
		temp.GoodsMakerNm = reader.ReadString();
		//�������i���[�J�[�R�[�h
		temp.PureGoodsMakerCd = reader.ReadInt32();
		//�┭�������i�ԍ�
		temp.InqPureGoodsNo = reader.ReadString();
		//�񓚏������i�ԍ�
		temp.AnsPureGoodsNo = reader.ReadString();
		//�艿
		temp.ListPrice = reader.ReadInt64();
		//�P��
		temp.UnitPrice = reader.ReadInt64();
		//���i�⑫���
		temp.GoodsAddInfo = reader.ReadString();
		//�e���z
		temp.RoughRrofit = reader.ReadInt64();
		//�e����
		temp.RoughRate = reader.ReadDouble();
		//�񓚊���
        temp.AnswerLimitDate = new DateTime(reader.ReadInt64());
		//���l(����)
		temp.CommentDtl = reader.ReadString();
		//�I��
		temp.ShelfNo = reader.ReadString();
		//PM�󒍃X�e�[�^�X
		temp.PMAcptAnOdrStatus = reader.ReadInt32();
		//PM����`�[�ԍ�
		temp.PMSalesSlipNum = reader.ReadInt32();
		//PM����s�ԍ�
		temp.PMSalesRowNo = reader.ReadInt32();
		//PM�q�ɃR�[�h
		temp.PmWarehouseCd = reader.ReadString();
		//PM�q�ɖ���
		temp.PmWarehouseName = reader.ReadString();
		//PM�I��
		temp.PmShelfNo = reader.ReadString();
		//PM���݌�
		temp.PmPrsntCount = reader.ReadDouble();
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        //PM��Ǒq�ɃR�[�h
        temp.PmMainMngWarehouseCd = reader.ReadString();
        //PM��Ǒq�ɖ���
        temp.PmMainMngWarehouseName = reader.ReadString();
        //PM��ǒI��
        temp.PmMainMngShelfNo = reader.ReadString();
        //PM��ǌ��݌�
        temp.PmMainMngPrsntCount = reader.ReadDouble();
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        //���i�K�i�E���L����
        temp.GoodsSpclInstruction = reader.ReadString();
        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
        //���[�J�[��]�������i
        temp.MkrSuggestRtPric = reader.ReadInt64();
        //�I�[�v�����i�敪
        temp.OpenPriceDiv = reader.ReadInt32();
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // �񓚔[���敪
        temp.AnsDeliDateDiv = reader.ReadInt16();
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        // �D�ǐݒ�ڍ׃R�[�h�Q
        temp.PrmSetDtlNo2 = reader.ReadInt32();
        // �D�ǐݒ�ڍז��̂Q
        temp.PrmSetDtlName2 = reader.ReadString();
        // �݌ɏ󋵋敪
        temp.StockStatusDiv = reader.ReadInt16();
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // ���i�K�i�E���L����(�H�����)
        temp.GoodsSpecialNtForFac = reader.ReadString();
        // ���i�K�i�E���L����(�J�[�I�[�i�[����)
        temp.GoodsSpecialNtForCOw = reader.ReadString();
        // �D�ǐݒ�ڍז��̂Q(�H�����)
        temp.PrmSetDtlName2ForFac = reader.ReadString();
        // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
        temp.PrmSetDtlName2ForCOw = reader.ReadString();
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
        temp.InqBlUtyPtThCd = reader.ReadString();
        //�┭BL���ꕔ�i�T�u�R�[�h
        temp.InqBlUtyPtSbCd = reader.ReadInt32();
        //��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
        temp.AnsBlUtyPtThCd = reader.ReadString();
        //��BL���ꕔ�i�T�u�R�[�h
        temp.AnsBlUtyPtSbCd = reader.ReadInt32();
        //��BL���i�R�[�h
        temp.AnsBLGoodsCode = reader.ReadInt32();
        //��BL���i�R�[�h�}��
        temp.AnsBLGoodsDrCode = reader.ReadInt32();
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			//�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			//�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			//�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
			{
				Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
			}
		}
		return temp;
	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
	/// </summary>
	/// <returns>SCMAcOdSetDtWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   SCMAcOdSetDtWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			SCMAcOdSetDtWork temp = GetScmAcOdSetDtWork( reader, serInfo );
			lst.Add( temp );
		}
		switch(serInfo.RetTypeInfo)
		{
			case 0:
				retValue = lst;
				break;
			case 1:
				retValue = lst[0];
				break;
			case 2:
				retValue = (SCMAcOdSetDtWork[])lst.ToArray(typeof(SCMAcOdSetDtWork));
				break;
		}
		return retValue;
	}

	#endregion
}

}
