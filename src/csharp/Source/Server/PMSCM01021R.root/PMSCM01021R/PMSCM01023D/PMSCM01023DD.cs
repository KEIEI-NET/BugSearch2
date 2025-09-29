//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�֘A�f�[�^�f�[�^�p�����[�^
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :   �����ڒǉ�
//                        �L�����Z����ԋ敪
// Programmer       :   21024 ���X�� ��
// Date             :   2010/05/26
//----------------------------------------------------------------------
// Update Note      :   �����ڒǉ�
//                        PM���݌�
//                        �Z�b�g���i���[�J�[�R�[�h
//                        �Z�b�g���i�ԍ�
//                        �Z�b�g���i�e�q�ԍ�
// Programmer       :   ����
// Date             :   2011/08/10
//----------------------------------------------------------------------
// Update Note      :   �����ڒǉ�
//                        ���i�K�i�E���L����
// Programmer       :   �� �B
// Date             :   2012/01/10
//----------------------------------------------------------------------
// Update Note      :   �����ڒǉ�
//                        PS�Ǘ��ԍ�
// Programmer       :   �g�� �F�� 30745
// Date             :   2012/04/12
//----------------------------------------------------------------------
// Update Note      :   �����ڒǉ�
//                        �������ϕ��i�R�[�h
// Programmer       :   �� �B
// Date             :   2012/05/30
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
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region delete
    /*
    /// public class name:   SCMAcOdrDtlAsWork
	/// <summary>
	///                      SCM�󒍖��׃f�[�^�i�񓚁j���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍖��׃f�[�^�i�񓚁j���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/06/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/13  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �񓚍s�ԍ�</br>
	/// <br>                 :   �񓚍s�ԍ��}��</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   �������L�[�ɒǉ� 3,9,10,11,12,13,14,15</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ���׎捞�敪</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���T�C�N�����i���</br>
	/// <br>                 :   ���T�C�N�����i��ʖ���</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �\������</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �񓚔[���@20��10</br>
	/// <br>Update Note      :   2009/05/27  ����</br>
	/// <br>                 :   �����ڒǉ�(�L�[�ɒǉ��j</br>
	/// <br>                 :   �⍇�����ƃR�[�h</br>
	/// <br>                 :   �⍇���拒�_�R�[�h</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17</br>
	/// <br>Update Note      :   2009/05/28  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���i�Ǘ��ԍ�</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   ���i�⑫���@24��255</br>
	/// <br>Update Note      :   2009/06/02  ����</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �������i���[�J�[�R�[�h�@2��3</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���i���[�J�[����</br>
	/// <br>Update Note      :   2009/06/15  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ���i���i�J�i�j</br>
	/// <br>                 :   �������i�ԍ�</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �┭���i��</br>
	/// <br>                 :   �񓚏��i��</br>
	/// <br>                 :   �┭�������i�ԍ�</br>
	/// <br>                 :   �񓚏������i�ԍ�</br>
	/// <br>                 :   ���L�[�ǉ�</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17,53,54,55</br>
    /// <br></br>
    /// <br>Update Note      :   2010/05/26  21024 ���X�� ��</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �L�����Z����ԋ敪</br>
    /// <br></br>
    /// <br>Update Note      :   2011/02/09  21024 ���X�� ��</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���׎捞�敪</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDtlAsWork : IFileHeader
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

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V����</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�⍇���s�ԍ�</summary>
		private Int32 _inqRowNumber;

		/// <summary>�⍇���s�ԍ��}��</summary>
		private Int32 _inqRowNumDerivedNo;

		/// <summary>�⍇�������׎���GUID</summary>
		private Guid _inqOrgDtlDiscGuid;

		/// <summary>�⍇���斾�׎���GUID</summary>
		/// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
		private Guid _inqOthDtlDiscGuid;

		/// <summary>���i���</summary>
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</remarks>
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
		/// <remarks>0:�I�[�v�����i</remarks>
		private Int64 _listPrice;

		/// <summary>�P��</summary>
		private Int64 _unitPrice;

		/// <summary>���i�⑫���</summary>
		/// <remarks>PS�̂t�q�k</remarks>
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

		/// <summary>�Y�t�t�@�C��(����)</summary>
        private Byte[] _appendingFileDtl = new Byte[0];

		/// <summary>�Y�t�t�@�C����(����)</summary>
		private string _appendingFileNmDtl = "";

		/// <summary>�I��</summary>
		private string _shelfNo = "";

		/// <summary>�ǉ��敪</summary>
		private Int32 _additionalDivCd;

		/// <summary>�����敪</summary>
		private Int32 _correctDivCD;

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>����s�ԍ�</summary>
		private Int32 _salesRowNo;

		/// <summary>�L�����y�[���R�[�h</summary>
		/// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
		private Int32 _campaignCode;

		/// <summary>�݌ɋ敪</summary>
		/// <remarks>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</remarks>
		private Int32 _stockDiv;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>���i�Ǘ��ԍ�</summary>
		/// <remarks>PS�Ǘ��ԍ�</remarks>
		private Int32 _goodsMngNo;

        // 2010/05/26 Add >>>
        /// <summary>�L�����Z����ԋ敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
        private Int16 _cancelCndtinDiv;
        // 2010/05/26 Add <<<
        // 2011/02/09 Add >>>
        /// <summary>���׎捞�敪</summary>
        /// <remarks>0:���捞 1:�捞��</remarks>
        private Int32 _dtlTakeinDivCd;
        // 2011/02/09 Add <<<

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
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V���ԃv���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  InqRowNumber
		/// <summary>�⍇���s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumber
		{
			get{return _inqRowNumber;}
			set{_inqRowNumber = value;}
		}

		/// public propaty name  :  InqRowNumDerivedNo
		/// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumDerivedNo
		{
			get{return _inqRowNumDerivedNo;}
			set{_inqRowNumDerivedNo = value;}
		}

		/// public propaty name  :  InqOrgDtlDiscGuid
		/// <summary>�⍇�������׎���GUID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������׎���GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid InqOrgDtlDiscGuid
		{
			get{return _inqOrgDtlDiscGuid;}
			set{_inqOrgDtlDiscGuid = value;}
		}

		/// public propaty name  :  InqOthDtlDiscGuid
		/// <summary>�⍇���斾�׎���GUID�v���p�e�B</summary>
		/// <value>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���斾�׎���GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid InqOthDtlDiscGuid
		{
			get{return _inqOthDtlDiscGuid;}
			set{_inqOthDtlDiscGuid = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</value>
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
		/// <value>0:�I�[�v�����i</value>
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
		/// <value>PS�̂t�q�k</value>
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

        /// public propaty name  :  AppendingFileDtl
        /// <summary>�Y�t�t�@�C��(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Y�t�t�@�C��(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] AppendingFileDtl
        {
            get { return _appendingFileDtl; }
            set { _appendingFileDtl = value; }
        }

		/// public propaty name  :  AppendingFileNmDtl
		/// <summary>�Y�t�t�@�C����(����)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C����(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AppendingFileNmDtl
		{
			get{return _appendingFileNmDtl;}
			set{_appendingFileNmDtl = value;}
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

		/// public propaty name  :  AdditionalDivCd
		/// <summary>�ǉ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ǉ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AdditionalDivCd
		{
			get{return _additionalDivCd;}
			set{_additionalDivCd = value;}
		}

		/// public propaty name  :  CorrectDivCD
		/// <summary>�����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CorrectDivCD
		{
			get{return _correctDivCD;}
			set{_correctDivCD = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesRowNo
		/// <summary>����s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesRowNo
		{
			get{return _salesRowNo;}
			set{_salesRowNo = value;}
		}

		/// public propaty name  :  CampaignCode
		/// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
		/// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  StockDiv
		/// <summary>�݌ɋ敪�v���p�e�B</summary>
		/// <value>�ϑ��݌ɁA���Ӑ�݌ɁA�D��q�ɁA���Ѝ݌ɁA��݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
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

		/// public propaty name  :  GoodsMngNo
		/// <summary>���i�Ǘ��ԍ��v���p�e�B</summary>
		/// <value>PS�Ǘ��ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�Ǘ��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMngNo
		{
			get{return _goodsMngNo;}
			set{_goodsMngNo = value;}
		}

        // 2010/05/26 Add >>>
        /// public propaty name  :  CancelCndtinDiv
        /// <summary>�L�����Z����ԋ敪�v���p�e�B</summary>
        /// <value>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����Z����ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CancelCndtinDiv
        {
            get { return _cancelCndtinDiv; }
            set { _cancelCndtinDiv = value; }
        }
        // 2010/05/26 Add <<<

        // 2011/02/09 Add >>>
        /// public propaty name  :  DtlTakeinDivCd
        /// <summary>���׎捞�敪�v���p�e�B</summary>
        /// <value>0:���捞 1:�捞��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׎捞�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlTakeinDivCd
        {
            get { return _dtlTakeinDivCd; }
            set { _dtlTakeinDivCd = value; }
        }
        // 2011/02/09 Add <<<

		/// <summary>
		/// SCM�󒍖��׃f�[�^�i�񓚁j���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDtlAsWork()
		{
		}

    }
    */
    # endregion

	/// public class name:   SCMAcOdrDtlAsWork
	/// <summary>
	///                      SCM�󒍖��׃f�[�^�i�񓚁j���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍖��׃f�[�^�i�񓚁j���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/13  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �񓚍s�ԍ�</br>
	/// <br>                 :   �񓚍s�ԍ��}��</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   �������L�[�ɒǉ� 3,9,10,11,12,13,14,15</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ���׎捞�敪</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���T�C�N�����i���</br>
	/// <br>                 :   ���T�C�N�����i��ʖ���</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �\������</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �񓚔[���@20��10</br>
	/// <br>Update Note      :   2009/05/27  ����</br>
	/// <br>                 :   �����ڒǉ�(�L�[�ɒǉ��j</br>
	/// <br>                 :   �⍇�����ƃR�[�h</br>
	/// <br>                 :   �⍇���拒�_�R�[�h</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17</br>
	/// <br>Update Note      :   2009/05/28  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���i�Ǘ��ԍ�</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   ���i�⑫���@24��255</br>
	/// <br>Update Note      :   2009/06/02  ����</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �������i���[�J�[�R�[�h�@2��3</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���i���[�J�[����</br>
	/// <br>Update Note      :   2009/06/15  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ���i���i�J�i�j</br>
	/// <br>                 :   �������i�ԍ�</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �┭���i��</br>
	/// <br>                 :   �񓚏��i��</br>
	/// <br>                 :   �┭�������i�ԍ�</br>
	/// <br>                 :   �񓚏������i�ԍ�</br>
	/// <br>                 :   ���L�[�ǉ�</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17,53,54,55</br>
	/// <br>Update Note      :   2009/06/26  ����</br>
	/// <br>                 :   ���⑫�ύX</br>
	/// <br>                 :   �݌ɋ敪</br>
	/// <br>                 :   0:��݌�,1:�ϑ��݌�,2:���Ӑ�݌�,3:�D��q��,4:���Ѝ݌�</br>
	/// <br>Update Note      :   2010/05/25  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �L�����Z����ԋ敪</br>
	/// <br>Update Note      :   2011/2/9  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   ���׎捞�敪</br>
	/// <br>Update Note      :   2011/5/19  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �q�ɃR�[�h</br>
	/// <br>                 :   �q�ɖ���</br>
	/// <br>                 :   �q�ɒI��</br>
    /// <br>Update Note      :   2011/08/10  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   PM���݌�</br>
    /// <br>                 :   �Z�b�g���i���[�J�[�R�[�h</br>
    /// <br>                 :   �Z�b�g���i�ԍ�</br>
    /// <br>                 :   �Z�b�g���i�e�q�ԍ�</br>
    /// <br>Update Note      :   2012/01/10  �� �B</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���i�K�i�E���L����</br>
    /// <br>Update Note      :   2012/04/12  �g�� �F�� 30745</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   PS�Ǘ��ԍ�</br>
    /// <br>Update Note      :   2012/05/30  �� �B</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �������ϕ��i�R�[�h</br>
    /// <br>Update Note      :   2013/05/08  �g��</br>
    /// <br>                 :   2013/06/18�z�M�@SCM��Q��10308,��10528</br>
    /// <br>Update Note      :   2013/05/15  �g��</br>
    /// <br>                 :   2013/06/18�z�M�@SCM��Q��10410</br>
    /// <br>Update Note      :   �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh</br>
    /// <br>                 :   �z�M���Ȃ��� Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή� </br>
    /// <br>Update Note      :   2014/06/04  ���� ����q</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �D�ǐݒ�ڍ׃R�[�h�Q</br>
    /// <br>                 :   �D�ǐݒ�ڍז��̂Q</br>
    /// <br>                 :   �݌ɏ󋵋敪</br>
    /// <br>Update Note      :   2014/12/19 30744 ���� ����q</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>			     :   SCM������ PMNS�Ή� �ݏo�敪�A���[�J�[��]�������i�A�I�[�v�����i�敪�̒ǉ�</br>
    /// <br>Update Note      :   2015/01/19  31065 �L�� ���O</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   ���R�����h�Ή�</br>
    /// <br>Update Note      :   2015/01/30  30744 ���� ����q</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ ���Y�N���A�ԑ�ԍ��Ή� �^���ʕ��i�̗p�N���A�^���ʕ��i�p�~�N���A�^���ʕ��i�̗p�ԑ�ԍ��A�^���ʕ��i�p�~�ԑ�ԍ��̒ǉ�</br>
    /// <br>Update Note      :   2015/02/10  30745 �g��</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ �񓚔[���敪�Ή� ���ڒǉ�</br>
    /// <br>Update Note      :   2015/02/20  31126 ����</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>                 :   SCM������ �b������ʓ��L�Ή�</br>
    /// <br>                 :   ���i�K�i�E���L����(�H�����)�A���i�K�i�E���L����(�J�[�I�[�i�[����)�A�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�̒ǉ�</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDtlAsWork : IFileHeader
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

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V����</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�⍇���s�ԍ�</summary>
		private Int32 _inqRowNumber;

		/// <summary>�⍇���s�ԍ��}��</summary>
		private Int32 _inqRowNumDerivedNo;

		/// <summary>�⍇�������׎���GUID</summary>
		private Guid _inqOrgDtlDiscGuid;

		/// <summary>�⍇���斾�׎���GUID</summary>
		/// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
		private Guid _inqOthDtlDiscGuid;

		/// <summary>���i���</summary>
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</remarks>
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
		/// <remarks>0:�I�[�v�����i</remarks>
		private Int64 _listPrice;

		/// <summary>�P��</summary>
		private Int64 _unitPrice;

		/// <summary>���i�⑫���</summary>
		/// <remarks>PS�̂t�q�k</remarks>
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

		/// <summary>�Y�t�t�@�C��(����)</summary>
		private Byte[] _appendingFileDtl = new Byte[0];

		/// <summary>�Y�t�t�@�C����(����)</summary>
		private string _appendingFileNmDtl = "";

		/// <summary>�I��</summary>
		private string _shelfNo = "";

		/// <summary>�ǉ��敪</summary>
		private Int32 _additionalDivCd;

		/// <summary>�����敪</summary>
		private Int32 _correctDivCD;

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>����s�ԍ�</summary>
		private Int32 _salesRowNo;

		/// <summary>�L�����y�[���R�[�h</summary>
		/// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
		private Int32 _campaignCode;

		/// <summary>�݌ɋ敪</summary>
		/// <remarks>0:��݌�,1:�ϑ��݌�,2:���Ӑ�݌�,3:�D��q��,4:���Ѝ݌�</remarks>
		private Int32 _stockDiv;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>���i�Ǘ��ԍ�</summary>
		/// <remarks>PS�Ǘ��ԍ�</remarks>
		private Int32 _goodsMngNo;

		/// <summary>�L�����Z����ԋ敪</summary>
		/// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
		private Int16 _cancelCndtinDiv;

		/// <summary>���׎捞�敪</summary>
		/// <remarks>0:���捞 1:�捞��</remarks>
		private Int32 _dtlTakeinDivCd;

		/// <summary>�q�ɃR�[�h</summary>
		private string _warehouseCode = "";

		/// <summary>�q�ɖ���</summary>
		private string _warehouseName = "";

		/// <summary>�q�ɒI��</summary>
		private string _warehouseShelfNo = "";

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>PM���݌�</summary>
        private Double _pmPrsntCount;

        /// <summary>�Z�b�g���i���[�J�[�R�[�h</summary>
        private Int32 _setPartsMkrCd;

        /// <summary>�Z�b�g���i�ԍ�</summary>
        private string _setPartsNumber = "";

        /// <summary>�Z�b�g���i�e�q�ԍ�</summary>
        /// <remarks>0:�e,1-*:�q</remarks>
        private Int32 _setPartsMainSubNo;
        // -- ADD 2011/08/10   ------ <<<<<<

        // 2012/01/10 Add >>>
        /// <summary>���i�K�i�E���L����</summary>
        private string _GoodsSpecialNote = "";
        // 2012/01/10 Add <<<

        // 2012/04/12 Add >>> 
        /// <summary>PS�Ǘ��ԍ�</summary>
        private Int32 _psMngNo;
        // 2012/04/12 Add <<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>�������ϕ��i�R�[�h</summary>
        private string _AutoEstimatePartsCd = "";
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> ����`�[���v�i�ō��j���擾�܂��͐ݒ肵�܂��B </summary>
        private Int64 _salesTotalTaxInc;
        /// <summary> ����`�[���v�i�Ŕ��j���擾�܂��͐ݒ肵�܂��B</summary>
        private Int64 _salesTotalTaxExc;
        /// <summary>SCM����œ]�ŕ������擾�܂��͐ݒ肵�܂��B</summary>
        private Int32 _scmConsTaxLayMethod;
        /// <summary>����Őŗ����擾�܂��͐ݒ肵�܂��B</summary>
        private Double _consTaxRate;
        /// <summary> SCM�[�������敪���擾�܂��͐ݒ肵�܂��B</summary>
        private Int32 _scmFractionProcCd;
        /// <summary> ���|����ł��擾�܂��͐ݒ肵�܂��B</summary>
        private Int64 _accRecConsTax;
        /// <summary> PM��������擾�܂��͐ݒ肵�܂��B </summary>
        private Int32 _pMSalesDate;
        /// <summary> �d����`�[���s�������擾�܂��͐ݒ肵�܂��B</summary>
        private Int32 _suppSlpPrtTime;
        /// <summary> ������z�i�ō��݁j���擾�܂��͐ݒ肵�܂��B </summary>
        private Int64 _salesMoneyTaxInc;
        /// <summary> ������z�i�Ŕ����j���擾�܂��͐ݒ肵�܂��B</summary>
        private Int64 _salesMoneyTaxExc;
        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �f�[�^���̓V�X�e�����擾�܂��͐ݒ肵�܂��B </summary>
        private Int32 _dataInputSystem;
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>PM��Ǒq�ɃR�[�h</summary>
        private string _pmMainMngWarehouseCd = "";

        /// <summary>PM��Ǒq�ɖ���</summary>
        private string _pmMainMngWarehouseName = "";

        /// <summary>PM��ǒI��</summary>
        private string _pmMainMngShelfNo = "";

        /// <summary>PM��ǌ��݌�</summary>
        private Double _pmMainMngPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾�@��ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2 = 0;

        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
        private string _prmSetDtlName2 = "";

        /// <summary>�݌ɏ󋵋敪</summary>
        private Int16 _stockStatusDiv = 0;
        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary>�ݏo�敪</summary>
        private Int16 _rentDiv = 0;
        /// <summary>���[�J�[��]�������i</summary>
        private Int64 _mkrSuggestRtPric = 0;
        /// <summary>�I�[�v�����i�敪</summary>
        private Int32 _openPriceDiv = 0;
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        /// <summary>���������i�I���敪</summary>
        private Int16 _bgnGoodsDiv = 0;
        // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// <summary>�^���ʕ��i�̗p�N��</summary>
        private Int32 _modelPrtsAdptYm = 0;
        /// <summary>�^���ʕ��i�p�~�N��</summary>
        private Int32 _modelPrtsAblsYm = 0;
        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAdptFrameNo = 0;
        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAblsFrameNo = 0;
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

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
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V���ԃv���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  InqRowNumber
		/// <summary>�⍇���s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumber
		{
			get{return _inqRowNumber;}
			set{_inqRowNumber = value;}
		}

		/// public propaty name  :  InqRowNumDerivedNo
		/// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumDerivedNo
		{
			get{return _inqRowNumDerivedNo;}
			set{_inqRowNumDerivedNo = value;}
		}

		/// public propaty name  :  InqOrgDtlDiscGuid
		/// <summary>�⍇�������׎���GUID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������׎���GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid InqOrgDtlDiscGuid
		{
			get{return _inqOrgDtlDiscGuid;}
			set{_inqOrgDtlDiscGuid = value;}
		}

		/// public propaty name  :  InqOthDtlDiscGuid
		/// <summary>�⍇���斾�׎���GUID�v���p�e�B</summary>
		/// <value>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���斾�׎���GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid InqOthDtlDiscGuid
		{
			get{return _inqOthDtlDiscGuid;}
			set{_inqOthDtlDiscGuid = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</value>
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
		/// <value>0:�I�[�v�����i</value>
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
		/// <value>PS�̂t�q�k</value>
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

		/// public propaty name  :  AppendingFileDtl
		/// <summary>�Y�t�t�@�C��(����)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Byte[] AppendingFileDtl
		{
			get{return _appendingFileDtl;}
			set{_appendingFileDtl = value;}
		}

		/// public propaty name  :  AppendingFileNmDtl
		/// <summary>�Y�t�t�@�C����(����)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C����(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AppendingFileNmDtl
		{
			get{return _appendingFileNmDtl;}
			set{_appendingFileNmDtl = value;}
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

		/// public propaty name  :  AdditionalDivCd
		/// <summary>�ǉ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ǉ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AdditionalDivCd
		{
			get{return _additionalDivCd;}
			set{_additionalDivCd = value;}
		}

		/// public propaty name  :  CorrectDivCD
		/// <summary>�����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CorrectDivCD
		{
			get{return _correctDivCD;}
			set{_correctDivCD = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesRowNo
		/// <summary>����s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesRowNo
		{
			get{return _salesRowNo;}
			set{_salesRowNo = value;}
		}

		/// public propaty name  :  CampaignCode
		/// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
		/// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  StockDiv
		/// <summary>�݌ɋ敪�v���p�e�B</summary>
		/// <value>0:��݌�,1:�ϑ��݌�,2:���Ӑ�݌�,3:�D��q��,4:���Ѝ݌�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
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

		/// public propaty name  :  GoodsMngNo
		/// <summary>���i�Ǘ��ԍ��v���p�e�B</summary>
		/// <value>PS�Ǘ��ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�Ǘ��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMngNo
		{
			get{return _goodsMngNo;}
			set{_goodsMngNo = value;}
		}

		/// public propaty name  :  CancelCndtinDiv
		/// <summary>�L�����Z����ԋ敪�v���p�e�B</summary>
		/// <value>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����Z����ԋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 CancelCndtinDiv
		{
			get{return _cancelCndtinDiv;}
			set{_cancelCndtinDiv = value;}
		}

		/// public propaty name  :  DtlTakeinDivCd
		/// <summary>���׎捞�敪�v���p�e�B</summary>
		/// <value>0:���捞 1:�捞��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���׎捞�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DtlTakeinDivCd
		{
			get{return _dtlTakeinDivCd;}
			set{_dtlTakeinDivCd = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>�q�ɖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>�q�ɒI�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

        // -- ADD 2011/08/10   ------ >>>>>>
        /// public propaty name  :  PmPrsntCount
        /// <summary>PM���݌��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���݌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PmPrsntCount
        {
            get { return _pmPrsntCount; }
            set { _pmPrsntCount = value; }
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
            get { return _setPartsMkrCd; }
            set { _setPartsMkrCd = value; }
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
            get { return _setPartsNumber; }
            set { _setPartsNumber = value; }
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
            get { return _setPartsMainSubNo; }
            set { _setPartsMainSubNo = value; }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // 2012/01/10 Add >>>
        /// public propaty name  :  GoodsSpecialNote
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _GoodsSpecialNote; }
            set { _GoodsSpecialNote = value; }
        }
        // 2012/01/10 Add <<<
        // 2012/04/12 Add >>>
        /// public propaty name  :  PSMngNo
        /// <summary>PS�Ǘ��ԍ�</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PS�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PSMngNo
        {
            get { return _psMngNo; }
            set { _psMngNo = value; }
        }
        // 2012/04/12 Add <<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// public propaty name  :  AutoEstimatePartsCd
        /// <summary>�������ϕ��i�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ϕ��i�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AutoEstimatePartsCd
        {
            get { return _AutoEstimatePartsCd; }
            set { _AutoEstimatePartsCd = value; }
        }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<


        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��j���̃v���p�e�B</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ��j�v���p�e�B</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  ScmConsTaxLayMethod
        /// <summary>SCM����œ]�ŕ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM����œ]�ŕ����v���p�e�B</br>
        /// </remarks>
        public Int32 ScmConsTaxLayMethod
        {
            get { return _scmConsTaxLayMethod; }
            set { _scmConsTaxLayMethod = value; }
        }

        /// public propaty name  :  ConsTaxRate
        /// <summary>����Őŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Őŗ��v���p�e�B</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }

        /// public propaty name  :  ScmFractionProcCd
        /// <summary>SCM�[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�[�������敪�v���p�e�B</br>
        /// </remarks>
        public Int32 ScmFractionProcCd
        {
            get { return _scmFractionProcCd; }
            set { _scmFractionProcCd = value; }
        }

        /// public propaty name  :  AccRecConsTax
        /// <summary>���|����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|����Ńv���p�e�B</br>
        /// </remarks>
        public Int64 AccRecConsTax
        {
            get { return _accRecConsTax; }
            set { _accRecConsTax = value; }
        }

        /// public propaty name  :  PMSalesDate
        /// <summary>PM������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM������v���p�e�B</br>
        /// </remarks>
        public Int32 PMSalesDate
        {
            get { return _pMSalesDate; }
            set { _pMSalesDate = value; }
        }

        /// public propaty name  :  SuppSlpPrtTime
        /// <summary>�d����`�[���s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����`�[���s�����v���p�e�B</br>
        /// </remarks>
        public Int32 SuppSlpPrtTime
        {
            get { return _suppSlpPrtTime; }
            set { _suppSlpPrtTime = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>������z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�ō��݁j�v���p�e�B</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }
        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
            get { return _pmMainMngWarehouseCd; }
            set { _pmMainMngWarehouseCd = value; }
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

        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾�@��ʃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>�D�ǐݒ�ڍז��̂Q�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>note             :   �݌ɏ󋵋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }
        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// public propaty name  :  RentDiv
        /// <summary>�ݏo�敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 RentDiv
        {
            get { return _rentDiv; }
            set { _rentDiv = value; }
        }

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
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        /// public propaty name  :  BgnGoodsDiv
        /// <summary>���������i�I���敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�I���敪�v���p�e�B�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 BgnGoodsDiv
        {
            get { return _bgnGoodsDiv; }
            set { _bgnGoodsDiv = value; }
        }
        // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
        
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>�^���ʕ��i�̗p�N���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }

        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>�^���ʕ��i�p�~�N���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�p�~�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
        }

        /// public propaty name  :  ModelPrtsAdptFrameNo
        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ��v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return _modelPrtsAdptFrameNo; }
            set { _modelPrtsAdptFrameNo = value; }
        }

        /// public propaty name  :  ModelPrtsAblsFrameNo
        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ��v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�p�~�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return _modelPrtsAblsFrameNo; }
            set { _modelPrtsAblsFrameNo = value; }
        }
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

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
        /// <br>note             :   ���i�K�i�E���L����(�H�����)�v���p�e�B</br>
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
        /// <br>note             :   ���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</br>
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
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</br>
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
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// SCM�󒍖��׃f�[�^�i�񓚁j���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDtlAsWork()
		{
		}

	}

    # region delete
    /*
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAcOdrDtlAsWork || graph is ArrayList || graph is SCMAcOdrDtlAsWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAcOdrDtlAsWork).FullName));

            if (graph != null && graph is SCMAcOdrDtlAsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAcOdrDtlAsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAcOdrDtlAsWork[])graph).Length;
            }
            else if (graph is SCMAcOdrDtlAsWork)
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
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //�⍇���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //�⍇���s�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //�⍇�������׎���GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
            //�⍇���斾�׎���GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
            //���i���
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //���T�C�N�����i���
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //���T�C�N�����i��ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //�戵�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //���i�`��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //�[�i�m�F�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //�񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDeliveryDate
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //�┭���i��
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //�񓚏��i��
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //�[�i��
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //�������i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //�┭�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //�񓚏������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //�艿
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //�P��
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //���i�⑫���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //�e����
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //�񓚊���
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //���l(����)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //�Y�t�t�@�C��(����)
            serInfo.MemberInfo.Add(typeof(Byte[])); //AppendingFileDtl
            //�Y�t�t�@�C����(����)
            serInfo.MemberInfo.Add(typeof(string)); //AppendingFileNmDtl
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //�ǉ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //���i�Ǘ��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMngNo
            // 2010/05/26 Add >>>
            //�L�����Z����ԋ敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelCndtinDiv
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            //���׎捞�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
            // 2011/02/09 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAcOdrDtlAsWork)
            {
                SCMAcOdrDtlAsWork temp = (SCMAcOdrDtlAsWork)graph;

                SetSCMAcOdrDtlAsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAcOdrDtlAsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAcOdrDtlAsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAcOdrDtlAsWork temp in lst)
                {
                    SetSCMAcOdrDtlAsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAcOdrDtlAsWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2011/02/09 >>>
        //// 2010/05/26 >>>
        ////private const int currentMemberCount = 60;
        //private const int currentMemberCount = 61;
        //// 2010/05/26 <<<
        private const int currentMemberCount = 62;
        // 2011/02/09 <<<

        /// <summary>
        ///  SCMAcOdrDtlAsWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMAcOdrDtlAsWork(System.IO.BinaryWriter writer, SCMAcOdrDtlAsWork temp)
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
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd);
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�X�V����
            writer.Write(temp.UpdateTime);
            //�⍇���s�ԍ�
            writer.Write(temp.InqRowNumber);
            //�⍇���s�ԍ��}��
            writer.Write(temp.InqRowNumDerivedNo);
            //�⍇�������׎���GUID
            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
            writer.Write(inqOrgDtlDiscGuidArray.Length);
            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
            //�⍇���斾�׎���GUID
            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
            writer.Write(inqOthDtlDiscGuidArray.Length);
            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
            //���i���
            writer.Write(temp.GoodsDivCd);
            //���T�C�N�����i���
            writer.Write(temp.RecyclePrtKindCode);
            //���T�C�N�����i��ʖ���
            writer.Write(temp.RecyclePrtKindName);
            //�[�i�敪
            writer.Write(temp.DeliveredGoodsDiv);
            //�戵�敪
            writer.Write(temp.HandleDivCode);
            //���i�`��
            writer.Write(temp.GoodsShape);
            //�[�i�m�F�敪
            writer.Write(temp.DelivrdGdsConfCd);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //�񓚔[��
            writer.Write(temp.AnswerDeliveryDate);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h�}��
            writer.Write(temp.BLGoodsDrCode);
            //�┭���i��
            writer.Write(temp.InqGoodsName);
            //�񓚏��i��
            writer.Write(temp.AnsGoodsName);
            //������
            writer.Write(temp.SalesOrderCount);
            //�[�i��
            writer.Write(temp.DeliveredGoodsCount);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i���[�J�[����
            writer.Write(temp.GoodsMakerNm);
            //�������i���[�J�[�R�[�h
            writer.Write(temp.PureGoodsMakerCd);
            //�┭�������i�ԍ�
            writer.Write(temp.InqPureGoodsNo);
            //�񓚏������i�ԍ�
            writer.Write(temp.AnsPureGoodsNo);
            //�艿
            writer.Write(temp.ListPrice);
            //�P��
            writer.Write(temp.UnitPrice);
            //���i�⑫���
            writer.Write(temp.GoodsAddInfo);
            //�e���z
            writer.Write(temp.RoughRrofit);
            //�e����
            writer.Write(temp.RoughRate);
            //�񓚊���
            writer.Write((Int64)temp.AnswerLimitDate.Ticks);
            //���l(����)
            writer.Write(temp.CommentDtl);
            //�Y�t�t�@�C��(����)
            writer.Write(temp.AppendingFileDtl.Length);
            writer.Write(temp.AppendingFileDtl);
            //�Y�t�t�@�C����(����)
            writer.Write(temp.AppendingFileNmDtl);
            //�I��
            writer.Write(temp.ShelfNo);
            //�ǉ��敪
            writer.Write(temp.AdditionalDivCd);
            //�����敪
            writer.Write(temp.CorrectDivCD);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //�\������
            writer.Write(temp.DisplayOrder);
            //���i�Ǘ��ԍ�
            writer.Write(temp.GoodsMngNo);
            // 2010/05/26 Add >>>
            //�L�����Z����ԋ敪
            writer.Write(temp.CancelCndtinDiv);
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            //���׎捞�敪
            writer.Write(temp.DtlTakeinDivCd);
            // 2011/02/09 Add <<<
        }

        /// <summary>
        ///  SCMAcOdrDtlAsWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMAcOdrDtlAsWork temp = new SCMAcOdrDtlAsWork();

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
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString();
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateTime = reader.ReadInt32();
            //�⍇���s�ԍ�
            temp.InqRowNumber = reader.ReadInt32();
            //�⍇���s�ԍ��}��
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //�⍇�������׎���GUID
            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
            //�⍇���斾�׎���GUID
            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
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
            //�Y�t�t�@�C��(����)
            int appendingFileDtlLength = reader.ReadInt32();
            temp.AppendingFileDtl = reader.ReadBytes(appendingFileDtlLength);
            //�Y�t�t�@�C����(����)
            temp.AppendingFileNmDtl = reader.ReadString();
            //�I��
            temp.ShelfNo = reader.ReadString();
            //�ǉ��敪
            temp.AdditionalDivCd = reader.ReadInt32();
            //�����敪
            temp.CorrectDivCD = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //���i�Ǘ��ԍ�
            temp.GoodsMngNo = reader.ReadInt32();
            // 2010/05/26 Add >>>
            //�L�����Z����ԋ敪
            temp.CancelCndtinDiv = reader.ReadInt16();
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            //���׎捞�敪
            temp.DtlTakeinDivCd = reader.ReadInt32();
            // 2011/02/09 Add <<<

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
        /// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAcOdrDtlAsWork temp = GetSCMAcOdrDtlAsWork(reader, serInfo);
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
                    retValue = (SCMAcOdrDtlAsWork[])lst.ToArray(typeof(SCMAcOdrDtlAsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    */
    # endregion

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2018/04/16  �c����</br>
    /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
    /// </remarks>
    public class SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate �����o
    	
	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is SCMAcOdrDtlAsWork || graph is ArrayList || graph is SCMAcOdrDtlAsWork[]) )
			    throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAcOdrDtlAsWork).FullName ) );

		    if( graph != null && graph is SCMAcOdrDtlAsWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork" );

		    //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		    int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is SCMAcOdrDtlAsWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((SCMAcOdrDtlAsWork[])graph).Length;
		    }
		    else if( graph is SCMAcOdrDtlAsWork )
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
		    //�X�V�N����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateDate
		    //�X�V����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateTime
		    //�⍇���s�ԍ�
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqRowNumber
		    //�⍇���s�ԍ��}��
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqRowNumDerivedNo
		    //�⍇�������׎���GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //InqOrgDtlDiscGuid
		    //�⍇���斾�׎���GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //InqOthDtlDiscGuid
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
		    //�Y�t�t�@�C��(����)
		    serInfo.MemberInfo.Add( typeof(Byte[]) ); //AppendingFileDtl
		    //�Y�t�t�@�C����(����)
		    serInfo.MemberInfo.Add( typeof(string) ); //AppendingFileNmDtl
		    //�I��
		    serInfo.MemberInfo.Add( typeof(string) ); //ShelfNo
		    //�ǉ��敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AdditionalDivCd
		    //�����敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CorrectDivCD
		    //�󒍃X�e�[�^�X
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcptAnOdrStatus
		    //����`�[�ԍ�
		    serInfo.MemberInfo.Add( typeof(string) ); //SalesSlipNum
		    //����s�ԍ�
		    serInfo.MemberInfo.Add( typeof(Int32) ); //SalesRowNo
		    //�L�����y�[���R�[�h
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CampaignCode
		    //�݌ɋ敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //StockDiv
		    //�⍇���E�������
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqOrdDivCd
		    //�\������
		    serInfo.MemberInfo.Add( typeof(Int32) ); //DisplayOrder
		    //���i�Ǘ��ԍ�
		    serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsMngNo
		    //�L�����Z����ԋ敪
		    serInfo.MemberInfo.Add( typeof(Int16) ); //CancelCndtinDiv
		    //���׎捞�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //DtlTakeinDivCd
		    //�q�ɃR�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //WarehouseCode
		    //�q�ɖ���
		    serInfo.MemberInfo.Add( typeof(string) ); //WarehouseName
		    //�q�ɒI��
		    serInfo.MemberInfo.Add( typeof(string) ); //WarehouseShelfNo

            // -- ADD 2011/08/10   ------ >>>>>>
            //PM���݌�
            serInfo.MemberInfo.Add(typeof(Double)); //PmPrsntCount
            //�Z�b�g���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsMkrCd
            //�Z�b�g���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SetPartsNumber
            //�Z�b�g���i�e�q�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsMainSubNo
            // -- ADD 2011/08/10   ------ <<<<<<
            // 2012/01/10 Add >>>
            // <summary>���i�K�i�E���L����</summary>
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            // 2012/01/10 Add <<<
            // 2012/04/12 Add >>>�@
            // <summary>PS�Ǘ��ԍ�</summary>
            serInfo.MemberInfo.Add(typeof(Int32)); //PSMngNo
            // 2012/04/12 Add <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            // <summary>�������ϕ��i�R�[�h</summary>
            serInfo.MemberInfo.Add(typeof(string)); //AutoEstimatePartsCd
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ����`�[���v�i�ō��j
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesTotalTaxInc 
            // ����`�[���v�i�Ŕ��j
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesTotalTaxExc
            // SCM����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); // ScmConsTaxLayMethod
            // ����Őŗ�
            serInfo.MemberInfo.Add(typeof(Double)); // ConsTaxRate
            // SCM�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); // ScmFractionProcCd
            // ���|�����
            serInfo.MemberInfo.Add(typeof(Int64)); // AccRecConsTax
            // PM�����
            serInfo.MemberInfo.Add(typeof(Int32)); // PMSalesDate
            // �d����`�[���s����
            serInfo.MemberInfo.Add(typeof(Int32)); // SuppSlpPrtTime
            // ������z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesMoneyTaxInc 
            // ������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesMoneyTaxExc
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �f�[�^���̓V�X�e��
            serInfo.MemberInfo.Add(typeof(Int32)); // DataInputSystem
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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

            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            //�D�ǐݒ�ڍ׃R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //�D�ǐݒ�ڍז��̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //�D�ǐݒ�ڍ׃R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int16)); //StockStatusDiv
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            //�ݏo�敪
            serInfo.MemberInfo.Add(typeof(Int16)); //RentDiv
            //���[�J�[��]�������i
            serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

            // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
	        // ���������i�I���敪
            serInfo.MemberInfo.Add(typeof(Int16)); //BgnGoodsDiv
            // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            //�^���ʕ��i�̗p�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAdptYm
            //�^���ʕ��i�p�~�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAblsYm
            //�^���ʕ��i�̗p�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAdptFrameNo
            //�^���ʕ��i�p�~�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAblsFrameNo
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �񓚔[���敪
            serInfo.MemberInfo.Add(typeof(Int16)); // AnsDeliDateDiv
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
		    if( graph is SCMAcOdrDtlAsWork )
		    {
			    SCMAcOdrDtlAsWork temp = (SCMAcOdrDtlAsWork)graph;

			    SetSCMAcOdrDtlAsWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is SCMAcOdrDtlAsWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((SCMAcOdrDtlAsWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(SCMAcOdrDtlAsWork temp in lst)
			    {
				    SetSCMAcOdrDtlAsWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// SCMAcOdrDtlAsWork�����o��(public�v���p�e�B��)
	    /// </summary>
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        //// DEL 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //#region ���\�[�X
        ////private const int currentMemberCount = 65; // DEL 2011/08/10
        //// 2012/01/10 UPD >>>
        ////private const int currentMemberCount = 69; // ADD 2011/08/10
        ////private const int currentMemberCount = 70; // 2012/04/12 DEL  
        //// 2012/01/10 UPD <<<
        ////private const int currentMemberCount = 71; // 2012/04/12 ADD //DEL 2012/05/30
        ////// UPD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        ////// private const int currentMemberCount = 72;  //ADD 2012/05/30
        ////// ���̈Č��ƏC�������B���Č��̑Ή��ŁA10���̒ǉ��B
        ////private const int currentMemberCount = 82;
        ////// UPD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //#endregion
        //// DEL 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //// ���̈Č��ƏC�������B���Č��̑Ή��ŁA��10308,��10528��10���̒ǉ��A��10410��1���̒ǉ�
        ////private const int currentMemberCount = 83;    // DEL 2013/02/27 qijh #34752
        //// DEL 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        ////private const int currentMemberCount = 87;      // ADD 2013/02/27 qijh #34752
        //// DEL 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
        //// ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        //// UPD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        ////private const int currentMemberCount = 90;
        //// UPD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
        ////private const int currentMemberCount = 93;
        //// UPD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        ////private const int currentMemberCount = 94;
        //private const int currentMemberCount = 98;
        //// UPD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
        //// UPD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        //// UPD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
        //// ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
        #endregion
        //private const int currentMemberCount = 99;    // DEL 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�
        //private const int currentMemberCount = 103;     // ADD 2015/02/20 ���� SCM������ �b������ʓ��L�Ή�// DEL 2018/04/16 �c���� �VBL�R�[�h�Ή�
        private const int currentMemberCount = 109;// ADD 2018/04/16 �c���� �VBL�R�[�h�Ή�
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    		
	    /// <summary>
	    ///  SCMAcOdrDtlAsWork�C���X�^���X��������
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
	    /// </remarks>
	    private void SetSCMAcOdrDtlAsWork( System.IO.BinaryWriter writer, SCMAcOdrDtlAsWork temp )
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
		    //�X�V�N����
		    writer.Write( (Int64)temp.UpdateDate.Ticks );
		    //�X�V����
		    writer.Write( temp.UpdateTime );
		    //�⍇���s�ԍ�
		    writer.Write( temp.InqRowNumber );
		    //�⍇���s�ԍ��}��
		    writer.Write( temp.InqRowNumDerivedNo );
		    //�⍇�������׎���GUID
		    byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
		    writer.Write( inqOrgDtlDiscGuidArray.Length );
		    writer.Write( temp.InqOrgDtlDiscGuid.ToByteArray() );
		    //�⍇���斾�׎���GUID
		    byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
		    writer.Write( inqOthDtlDiscGuidArray.Length );
		    writer.Write( temp.InqOthDtlDiscGuid.ToByteArray() );
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
		    writer.Write( (Int64)temp.DeliGdsCmpltDueDate.Ticks );
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
		    writer.Write( (Int64)temp.AnswerLimitDate.Ticks );
		    //���l(����)
		    writer.Write( temp.CommentDtl );
		    //�Y�t�t�@�C��(����)
            writer.Write( temp.AppendingFileDtl.Length );
            writer.Write( temp.AppendingFileDtl );
		    //�Y�t�t�@�C����(����)
		    writer.Write( temp.AppendingFileNmDtl );
		    //�I��
		    writer.Write( temp.ShelfNo );
		    //�ǉ��敪
		    writer.Write( temp.AdditionalDivCd );
		    //�����敪
		    writer.Write( temp.CorrectDivCD );
		    //�󒍃X�e�[�^�X
		    writer.Write( temp.AcptAnOdrStatus );
		    //����`�[�ԍ�
		    writer.Write( temp.SalesSlipNum );
		    //����s�ԍ�
		    writer.Write( temp.SalesRowNo );
		    //�L�����y�[���R�[�h
		    writer.Write( temp.CampaignCode );
		    //�݌ɋ敪
		    writer.Write( temp.StockDiv );
		    //�⍇���E�������
		    writer.Write( temp.InqOrdDivCd );
		    //�\������
		    writer.Write( temp.DisplayOrder );
		    //���i�Ǘ��ԍ�
		    writer.Write( temp.GoodsMngNo );
		    //�L�����Z����ԋ敪
		    writer.Write( temp.CancelCndtinDiv );
		    //���׎捞�敪
		    writer.Write( temp.DtlTakeinDivCd );
		    //�q�ɃR�[�h
		    writer.Write( temp.WarehouseCode );
		    //�q�ɖ���
		    writer.Write( temp.WarehouseName );
		    //�q�ɒI��
		    writer.Write( temp.WarehouseShelfNo );

            // -- ADD 2011/08/10   ------ >>>>>>
            //PM���݌�
            writer.Write(temp.PmPrsntCount);
            //�Z�b�g���i���[�J�[�R�[�h
            writer.Write(temp.SetPartsMkrCd);
            //�Z�b�g���i�ԍ�
            writer.Write(temp.SetPartsNumber);
            //�Z�b�g���i�e�q�ԍ�
            writer.Write(temp.SetPartsMainSubNo);
            // -- ADD 2011/08/10   ------ <<<<<<
            // 2012/01/10 ADD >>>
            //���i�K�i�E���L����
            writer.Write(temp.GoodsSpecialNote);
            // 2012/01/10 ADD <<<
            // 2012/04/12 ADD >>> 
            //PS�Ǘ��ԍ�
            writer.Write(temp.PSMngNo);
            // 2012/04/12 ADD <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            //�������ϕ��i�R�[�h
            writer.Write(temp.AutoEstimatePartsCd);
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ����`�[���v�i�ō��j
            writer.Write(temp.SalesTotalTaxInc);
            // ����`�[���v�i�Ŕ��j
            writer.Write(temp.SalesTotalTaxExc);
            // SCM����œ]�ŕ���
            writer.Write(temp.ScmConsTaxLayMethod);
            // ����Őŗ�
            writer.Write(temp.ConsTaxRate);
            // SCM�[�������敪
            writer.Write(temp.ScmFractionProcCd);
            // ���|����ł��擾�܂��͐ݒ肵�܂��B
            writer.Write(temp.AccRecConsTax);
            // PM��������擾�܂��͐ݒ肵�܂��B
            writer.Write(temp.PMSalesDate);
            // �d����`�[���s�������擾�܂��͐ݒ肵�܂��B
            writer.Write(temp.SuppSlpPrtTime);
            // ������z�i�ō��݁j
            writer.Write(temp.SalesMoneyTaxInc);
            // ������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �f�[�^���̓V�X�e��
            writer.Write(temp.DataInputSystem);
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            // �D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.PrmSetDtlNo2);
            // �D�ǐݒ�ڍז��̂Q
            writer.Write(temp.PrmSetDtlName2);
            // �݌ɏ󋵋敪
            writer.Write(temp.StockStatusDiv);
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            // �ݏo�敪
            writer.Write(temp.RentDiv);
            // ���[�J�[��]�������i
            writer.Write(temp.MkrSuggestRtPric);
            // �I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

            // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
	        // ���������i�I���敪
            writer.Write(temp.BgnGoodsDiv);
            // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            // �^���ʕ��i�̗p�N��
            writer.Write(temp.ModelPrtsAdptYm);
            // �^���ʕ��i�p�~�N��
            writer.Write(temp.ModelPrtsAblsYm);
            // �^���ʕ��i�̗p�ԑ�ԍ�
            writer.Write(temp.ModelPrtsAdptFrameNo);
            // �^���ʕ��i�p�~�ԑ�ԍ�
            writer.Write(temp.ModelPrtsAblsFrameNo);
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �񓚔[���敪
            writer.Write(temp.AnsDeliDateDiv);
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
	    ///  SCMAcOdrDtlAsWork�C���X�^���X�擾
	    /// </summary>
	    /// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16  �c����</br>
        /// <br>                 :   �Ǘ��ԍ� 11470007-00</br>
        /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A�┭BL���ꕔ�i�T�u�R�[�h�A��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�A��BL���ꕔ�i�T�u�R�[�h�A��BL���i�R�[�h�A��BL���i�R�[�h�}�Ԃ̒ǉ�</br>
	    /// </remarks>
	    private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		    SCMAcOdrDtlAsWork temp = new SCMAcOdrDtlAsWork();

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
		    //�X�V�N����
		    temp.UpdateDate = new DateTime(reader.ReadInt64());
		    //�X�V����
		    temp.UpdateTime = reader.ReadInt32();
		    //�⍇���s�ԍ�
		    temp.InqRowNumber = reader.ReadInt32();
		    //�⍇���s�ԍ��}��
		    temp.InqRowNumDerivedNo = reader.ReadInt32();
		    //�⍇�������׎���GUID
		    int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
		    byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
		    temp.InqOrgDtlDiscGuid = new Guid( inqOrgDtlDiscGuidArray );
		    //�⍇���斾�׎���GUID
		    int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
		    byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
		    temp.InqOthDtlDiscGuid = new Guid( inqOthDtlDiscGuidArray );
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
		    //�Y�t�t�@�C��(����)
		    int appendingFileDtlLength = reader.ReadInt32();
            temp.AppendingFileDtl = reader.ReadBytes(appendingFileDtlLength);
		    //�Y�t�t�@�C����(����)
		    temp.AppendingFileNmDtl = reader.ReadString();
		    //�I��
		    temp.ShelfNo = reader.ReadString();
		    //�ǉ��敪
		    temp.AdditionalDivCd = reader.ReadInt32();
		    //�����敪
		    temp.CorrectDivCD = reader.ReadInt32();
		    //�󒍃X�e�[�^�X
		    temp.AcptAnOdrStatus = reader.ReadInt32();
		    //����`�[�ԍ�
		    temp.SalesSlipNum = reader.ReadString();
		    //����s�ԍ�
		    temp.SalesRowNo = reader.ReadInt32();
		    //�L�����y�[���R�[�h
		    temp.CampaignCode = reader.ReadInt32();
		    //�݌ɋ敪
		    temp.StockDiv = reader.ReadInt32();
		    //�⍇���E�������
		    temp.InqOrdDivCd = reader.ReadInt32();
		    //�\������
		    temp.DisplayOrder = reader.ReadInt32();
		    //���i�Ǘ��ԍ�
		    temp.GoodsMngNo = reader.ReadInt32();
		    //�L�����Z����ԋ敪
		    temp.CancelCndtinDiv = reader.ReadInt16();
		    //���׎捞�敪
		    temp.DtlTakeinDivCd = reader.ReadInt32();
		    //�q�ɃR�[�h
		    temp.WarehouseCode = reader.ReadString();
		    //�q�ɖ���
		    temp.WarehouseName = reader.ReadString();
		    //�q�ɒI��
		    temp.WarehouseShelfNo = reader.ReadString();

            // -- ADD 2011/08/10   ------ >>>>>>
            //PM���݌�
            temp.PmPrsntCount = reader.ReadDouble();
            //�Z�b�g���i���[�J�[�R�[�h
            temp.SetPartsMkrCd = reader.ReadInt32();
            //�Z�b�g���i�ԍ�
            temp.SetPartsNumber = reader.ReadString();
            //�Z�b�g���i�e�q�ԍ�
            temp.SetPartsMainSubNo = reader.ReadInt32();
            // -- ADD 2011/08/10   ------ <<<<<<
            // 2012/01/10 ADD >>>
            //���i�K�i�E���L����
            temp.GoodsSpecialNote = reader.ReadString();
            // 2012/01/10 ADD <<<
            // 2012/04/12 ADD >>> 
            //PS�Ǘ��ԍ�
            temp.PSMngNo = reader.ReadInt32();
            // 2012/04/12 ADD <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            //�������ϕ��i�R�[�h
            temp.AutoEstimatePartsCd = reader.ReadString();
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ����`�[���v�i�ō��j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            // ����`�[���v�i�Ŕ��j
            temp.SalesTotalTaxExc = reader.ReadInt64();
            // SCM����œ]�ŕ���
            temp.ScmConsTaxLayMethod = reader.ReadInt32();
            // ����Őŗ�
            temp.ConsTaxRate = reader.ReadDouble();
            // SCM�[�������敪
            temp.ScmFractionProcCd = reader.ReadInt32();
            // ���|�����
            temp.AccRecConsTax = reader.ReadInt64();
            // PM�����
            temp.PMSalesDate = reader.ReadInt32();
            // �d����`�[���s����
            temp.SuppSlpPrtTime = reader.ReadInt32();
            // ������z�i�ō��݁j
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            // ������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �f�[�^���̓V�X�e��
            temp.DataInputSystem = reader.ReadInt32();
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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

            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            // �D�ǐݒ�ڍ׃R�[�h�Q
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            // �D�ǐݒ�ڍז��̂Q
            temp.PrmSetDtlName2 = reader.ReadString();
            // �݌ɏ󋵋敪
            temp.StockStatusDiv = reader.ReadInt16();
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            // �ݏo�敪
            temp.RentDiv = reader.ReadInt16();
            // ���[�J�[��]�������i
            temp.MkrSuggestRtPric = reader.ReadInt64();
            // �I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

            // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
            // ���������i�I���敪
            temp.BgnGoodsDiv = reader.ReadInt16();
            // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            // �^���ʕ��i�̗p�N��
            temp.ModelPrtsAdptYm = reader.ReadInt32();
            // �^���ʕ��i�p�~�N��
            temp.ModelPrtsAblsYm = reader.ReadInt32();
            // �^���ʕ��i�̗p�ԑ�ԍ�
            temp.ModelPrtsAdptFrameNo = reader.ReadInt32();
            // �^���ʕ��i�p�~�ԑ�ԍ�
            temp.ModelPrtsAblsFrameNo = reader.ReadInt32();
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �񓚔[���敪
            temp.AnsDeliDateDiv = reader.ReadInt16();
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
	    /// <returns>SCMAcOdrDtlAsWork�N���X�̃C���X�^���X(object)</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDtlAsWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    SCMAcOdrDtlAsWork temp = GetSCMAcOdrDtlAsWork( reader, serInfo );
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
				    retValue = (SCMAcOdrDtlAsWork[])lst.ToArray(typeof(SCMAcOdrDtlAsWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }
}
