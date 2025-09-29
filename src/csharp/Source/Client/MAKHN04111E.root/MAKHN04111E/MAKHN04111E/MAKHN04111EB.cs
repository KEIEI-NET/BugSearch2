//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�A���f�[�^�N���X
// �v���O�����T�v   : ���i���o�����p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� :              �쐬�S�� : 
// �� �� �� : 2008/10/01   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11470007-00  �쐬�S�� : 30757 ���X�؁@�M�p
// �� �� �� : 2018/04/05   �C�����e : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// public class name:   GoodsCndtn
	/// <summary>
	///                      ���i���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���i���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/10/1</br>
	/// <br>Genarated Date   :   2009/02/13  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2009/12/18�@21024 ���X�� ��</br>
    /// <br>                     �_���폜���[�h��ǉ�(MANTIS[0014661])</br>
    /// <br></br>
    /// <br>Update Note      :   2011/05/18�@22018 ��� ���b</br>
    /// <br>                     SCM���ǁ@BL�R�[�h�}�Ԃ�ǉ�</br>
    /// <br>Update Note      :   2015/08/17 �c����</br>
    /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
    /// <br>Update Note      :   2018/04/05  30757 ���X�؁@�M�p</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
    /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
    /// </remarks>
	public class GoodsCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i�ԍ������敪</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v</remarks>
		private Int32 _goodsNoSrchTyp;

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>���i���̌����敪</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v</remarks>
		private Int32 _goodsNameSrchTyp;

		/// <summary>���i���̃J�i</summary>
		private string _goodsNameKana = "";

		/// <summary>���i�J�i���̌����敪</summary>
		/// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v</remarks>
		private Int32 _goodsNameKanaSrchTyp;

		/// <summary>JAN�R�[�h</summary>
		/// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
		private string _jan = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>���i�啪�ރR�[�h</summary>
		/// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
		private Int32 _goodsLGroup;

		/// <summary>���i�啪�ޖ���</summary>
		private string _goodsLGroupName = "";

		/// <summary>���i�����ރR�[�h</summary>
		/// <remarks>�������ށi�}�X�^�L�j</remarks>
		private Int32 _goodsMGroup;

		/// <summary>���i�����ޖ���</summary>
		private string _goodsMGroupName = "";

		/// <summary>BL�O���[�v�R�[�h</summary>
		/// <remarks>���O���[�v�R�[�h</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BL�O���[�v�R�[�h����</summary>
		private string _bLGroupName = "";

		/// <summary>���i����</summary>
		/// <remarks>9:�S�đΏ�</remarks>
		private Int32 _goodsKindCode;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���������敪</summary>
		/// <remarks>0:���������Ȃ�,1:������������</remarks>
		private Int32 _joinSearchDiv;

		/// <summary>�ԗ��������ʃN���X</summary>
		/// <remarks>BL�R�[�h�������̂ݎg�p</remarks>
		private PMKEN01010E _searchCarInfo;

		/// <summary>��֏����敪</summary>
		/// <remarks>0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _substCondDivCd;

		/// <summary>�D�Ǒ�֏����敪</summary>
		/// <remarks>0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _prmSubstCondDivCd;

		/// <summary>��֓K�p�敪</summary>
		/// <remarks>0:���Ȃ�,1:����(�����A�Z�b�g),2:�S��(�����A�Z�b�g�A����)�@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _substApplyDivCd;

		/// <summary>������ʐ���敪</summary>
		/// <remarks>0:PM7,1:PM.NS�@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _searchUICntDivCd;

		/// <summary>�G���^�[�L�[�����敪</summary>
		/// <remarks>0:PM7,1:�I��,2:����ʁ@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _enterProcDivCd;

		/// <summary>�i�Ԍ����敪</summary>
		/// <remarks>0:PM7(�Z�b�g�̂�),1:�����E�Z�b�g�E��ւ���@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _partsNoSearchDivCd;

		/// <summary>�i�Ԍ�������敪</summary>
		/// <remarks>�����l�h.�h�@�G���g������̕��i�������̂ݗL��</remarks>
		private string _partsJoinCntDivCd = "";

		/// <summary>�����\���敪�P</summary>
		/// <remarks>0:����,1:�a���i�N���j�@�G���g������̕��i�������̂ݗL��</remarks>
		private Int32 _eraNameDispCd1;

		/// <summary>���i�����D�揇�敪</summary>
		/// <remarks>0:����,1:�D��</remarks>
		private Int32 _partsSearchPriDivCd;

		/// <summary>���������\���敪</summary>
		/// <remarks>0:�\����,1:�݌ɏ�</remarks>
		private Int32 _joinInitDispDiv;

		/// <summary>���Ӑ�R�[�h</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _customerCode;

		/// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _custRateGrpCode;

		/// <summary>���i�K�p��</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private DateTime _priceApplyDate;

		/// <summary>����P���[�������R�[�h</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _salesUnPrcFrcProcCd;

		/// <summary>�d���P���[�������R�[�h</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _stockUnPrcFrcProcCd;

		/// <summary>�ŗ�</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Double _taxRate;

		/// <summary>���z�\�����@�敪</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>���z�\���|���K�p�敪</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _ttlAmntDspRateDivCd;

		/// <summary>�������Œ[�������R�[�h</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _salesCnsTaxFrcProcCd;

		/// <summary>�d������Œ[�������R�[�h</summary>
		/// <remarks>�P���Z�o�p</remarks>
		private Int32 _stockCnsTaxFrcProcCd;

		/// <summary>�D��q�ɃR�[�h���X�g</summary>
		/// <remarks>����i�ԑI���E�C���h�E�̏����I���݌ɏ��̌���Ɏg�p</remarks>
		private List<string> _listPriorWarehouse;

		/// <summary>�d������擾�敪</summary>
		/// <remarks>0:�ݒ肠�� 1:�ݒ�Ȃ�</remarks>
		private Int32 _isSettingSupplier;

		/// <summary>����œ]�ŕ���</summary>
		/// <remarks>0:�`�[�]�� 1:���ד]�� 2:�����e 3:�����q 9:��ې�</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>�s�����ݒ�敪</summary>
		/// <remarks>0:�ݒ肠�� 1:�ݒ�Ȃ�</remarks>
		private Int32 _isSettingVariousMst;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";

        // 2009/12/18 Add >>>
        /// <summary>�_���폜���[�h</summary>
        private int _logicalMode = 0;
        // 2009/12/18 Add <<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>BL�R�[�h�}��</summary>
        private int _bLGoodsDrCode = 0;
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _addUpSectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";
        //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<

        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL���ꕔ�i�T�u�R�[�h</summary>
        private Int32 _blUtyPtSbCd = 0;
        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

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

		/// public propaty name  :  MakerName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
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

		/// public propaty name  :  GoodsNoSrchTyp
		/// <summary>���i�ԍ������敪�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNoSrchTyp
		{
			get{return _goodsNoSrchTyp;}
			set{_goodsNoSrchTyp = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>���i���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  GoodsNameSrchTyp
		/// <summary>���i���̌����敪�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̌����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNameSrchTyp
		{
			get{return _goodsNameSrchTyp;}
			set{_goodsNameSrchTyp = value;}
		}

		/// public propaty name  :  GoodsNameKana
		/// <summary>���i���̃J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���̃J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  GoodsNameKanaSrchTyp
		/// <summary>���i�J�i���̌����敪�v���p�e�B</summary>
		/// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�i���̌����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNameKanaSrchTyp
		{
			get{return _goodsNameKanaSrchTyp;}
			set{_goodsNameKanaSrchTyp = value;}
		}

		/// public propaty name  :  Jan
		/// <summary>JAN�R�[�h�v���p�e�B</summary>
		/// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   JAN�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Jan
		{
			get{return _jan;}
			set{_jan = value;}
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

		/// public propaty name  :  GoodsLGroup
		/// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
		/// <value>���啪�ށi���[�U�[�K�C�h�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsLGroup
		{
			get{return _goodsLGroup;}
			set{_goodsLGroup = value;}
		}

		/// public propaty name  :  GoodsLGroupName
		/// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsLGroupName
		{
			get{return _goodsLGroupName;}
			set{_goodsLGroupName = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>���i�����ރR�[�h�v���p�e�B</summary>
		/// <value>�������ށi�}�X�^�L�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>���i�����ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

		/// public propaty name  :  BLGroupCode
		/// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���O���[�v�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGroupCode
		{
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
		}

		/// public propaty name  :  BLGroupName
		/// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGroupName
		{
			get{return _bLGroupName;}
			set{_bLGroupName = value;}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>���i�����v���p�e�B</summary>
		/// <value>9:�S�đΏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
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

		/// public propaty name  :  JoinSearchDiv
		/// <summary>���������敪�v���p�e�B</summary>
		/// <value>0:���������Ȃ�,1:������������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinSearchDiv
		{
			get{return _joinSearchDiv;}
			set{_joinSearchDiv = value;}
		}

		/// public propaty name  :  SearchCarInfo
		/// <summary>�ԗ��������ʃN���X�v���p�e�B</summary>
		/// <value>BL�R�[�h�������̂ݎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��������ʃN���X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PMKEN01010E SearchCarInfo
		{
			get{return _searchCarInfo;}
			set{_searchCarInfo = value;}
		}

		/// public propaty name  :  SubstCondDivCd
		/// <summary>��֏����敪�v���p�e�B</summary>
		/// <value>0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֏����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstCondDivCd
		{
			get{return _substCondDivCd;}
			set{_substCondDivCd = value;}
		}

		/// public propaty name  :  PrmSubstCondDivCd
		/// <summary>�D�Ǒ�֏����敪�v���p�e�B</summary>
		/// <value>0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�Ǒ�֏����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrmSubstCondDivCd
		{
			get{return _prmSubstCondDivCd;}
			set{_prmSubstCondDivCd = value;}
		}

		/// public propaty name  :  SubstApplyDivCd
		/// <summary>��֓K�p�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�,1:����(�����A�Z�b�g),2:�S��(�����A�Z�b�g�A����)�@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֓K�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstApplyDivCd
		{
			get{return _substApplyDivCd;}
			set{_substApplyDivCd = value;}
		}

		/// public propaty name  :  SearchUICntDivCd
		/// <summary>������ʐ���敪�v���p�e�B</summary>
		/// <value>0:PM7,1:PM.NS�@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������ʐ���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchUICntDivCd
		{
			get{return _searchUICntDivCd;}
			set{_searchUICntDivCd = value;}
		}

		/// public propaty name  :  EnterProcDivCd
		/// <summary>�G���^�[�L�[�����敪�v���p�e�B</summary>
		/// <value>0:PM7,1:�I��,2:����ʁ@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �G���^�[�L�[�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EnterProcDivCd
		{
			get{return _enterProcDivCd;}
			set{_enterProcDivCd = value;}
		}

		/// public propaty name  :  PartsNoSearchDivCd
		/// <summary>�i�Ԍ����敪�v���p�e�B</summary>
		/// <value>0:PM7(�Z�b�g�̂�),1:�����E�Z�b�g�E��ւ���@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i�Ԍ����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsNoSearchDivCd
		{
			get{return _partsNoSearchDivCd;}
			set{_partsNoSearchDivCd = value;}
		}

		/// public propaty name  :  PartsJoinCntDivCd
		/// <summary>�i�Ԍ�������敪�v���p�e�B</summary>
		/// <value>�����l�h.�h�@�G���g������̕��i�������̂ݗL��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i�Ԍ�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PartsJoinCntDivCd
		{
			get{return _partsJoinCntDivCd;}
			set{_partsJoinCntDivCd = value;}
		}

		/// public propaty name  :  EraNameDispCd1
		/// <summary>�����\���敪�P�v���p�e�B</summary>
		/// <value>0:����,1:�a���i�N���j�@�G���g������̕��i�������̂ݗL��</value>
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

		/// public propaty name  :  PartsSearchPriDivCd
		/// <summary>���i�����D�揇�敪�v���p�e�B</summary>
		/// <value>0:����,1:�D��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����D�揇�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsSearchPriDivCd
		{
			get{return _partsSearchPriDivCd;}
			set{_partsSearchPriDivCd = value;}
		}

		/// public propaty name  :  JoinInitDispDiv
		/// <summary>���������\���敪�v���p�e�B</summary>
		/// <value>0:�\����,1:�݌ɏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinInitDispDiv
		{
			get{return _joinInitDispDiv;}
			set{_joinInitDispDiv = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
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

		/// public propaty name  :  CustRateGrpCode
		/// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
		}

		/// public propaty name  :  PriceApplyDate
		/// <summary>���i�K�p���v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�K�p���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PriceApplyDate
		{
			get{return _priceApplyDate;}
			set{_priceApplyDate = value;}
		}

		/// public propaty name  :  SalesUnPrcFrcProcCd
		/// <summary>����P���[�������R�[�h�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����P���[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesUnPrcFrcProcCd
		{
			get{return _salesUnPrcFrcProcCd;}
			set{_salesUnPrcFrcProcCd = value;}
		}

		/// public propaty name  :  StockUnPrcFrcProcCd
		/// <summary>�d���P���[�������R�[�h�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockUnPrcFrcProcCd
		{
			get{return _stockUnPrcFrcProcCd;}
			set{_stockUnPrcFrcProcCd = value;}
		}

		/// public propaty name  :  TaxRate
		/// <summary>�ŗ��v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double TaxRate
		{
			get{return _taxRate;}
			set{_taxRate = value;}
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>���z�\�����@�敪�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
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

		/// public propaty name  :  TtlAmntDspRateDivCd
		/// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
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

		/// public propaty name  :  SalesCnsTaxFrcProcCd
		/// <summary>�������Œ[�������R�[�h�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������Œ[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesCnsTaxFrcProcCd
		{
			get{return _salesCnsTaxFrcProcCd;}
			set{_salesCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  StockCnsTaxFrcProcCd
		/// <summary>�d������Œ[�������R�[�h�v���p�e�B</summary>
		/// <value>�P���Z�o�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d������Œ[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCnsTaxFrcProcCd
		{
			get{return _stockCnsTaxFrcProcCd;}
			set{_stockCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  ListPriorWarehouse
		/// <summary>�D��q�ɃR�[�h���X�g�v���p�e�B</summary>
		/// <value>����i�ԑI���E�C���h�E�̏����I���݌ɏ��̌���Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D��q�ɃR�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<string> ListPriorWarehouse
		{
			get{return _listPriorWarehouse;}
			set{_listPriorWarehouse = value;}
		}

		/// public propaty name  :  IsSettingSupplier
		/// <summary>�d������擾�敪�v���p�e�B</summary>
		/// <value>0:�ݒ肠�� 1:�ݒ�Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d������擾�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 IsSettingSupplier
		{
			get{return _isSettingSupplier;}
			set{_isSettingSupplier = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>����œ]�ŕ����v���p�e�B</summary>
		/// <value>0:�`�[�]�� 1:���ד]�� 2:�����e 3:�����q 9:��ې�</value>
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

		/// public propaty name  :  IsSettingVariousMst
		/// <summary>�s�����ݒ�敪�v���p�e�B</summary>
		/// <value>0:�ݒ肠�� 1:�ݒ�Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �s�����ݒ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 IsSettingVariousMst
		{
			get{return _isSettingVariousMst;}
			set{_isSettingVariousMst = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}

        // 2009/12/18 Add >>>
        /// public propaty name  :  LogicalMode
        /// <summary>�_���폜���[�h�v���p�e�B</summary>
        public Int32 LogicalMode
        {
            get { return _logicalMode; }
            set { _logicalMode = value; }
        }
        // 2009/12/18 Add <<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL�R�[�h�}�ԃv���p�e�B</summary>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
        /// public propaty name  :  AddUpSectionCode
        /// <summary>�Ǘ����_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSectionCode
        {
            get { return _addUpSectionCode; }
            set { _addUpSectionCode = value; }
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
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<

        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�p�����[�^</summary>
        /// <value>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>�Ǘ��ԍ�   : 11470007-00</br>
        /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL���ꕔ�i�T�u�R�[�h�p�����[�^</summary>
        /// <value>BL���ꕔ�i�T�u�R�[�h</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�T�u�R�[�h�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>�Ǘ��ԍ�   : 11470007-00</br>
        /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

		/// <summary>
		/// ���i���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>GoodsCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsCndtn()
		{
		}

		/// <summary>
		/// ���i���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsNoSrchTyp">���i�ԍ������敪(0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v)</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="goodsNameSrchTyp">���i���̌����敪(0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v)</param>
		/// <param name="goodsNameKana">���i���̃J�i</param>
		/// <param name="goodsNameKanaSrchTyp">���i�J�i���̌����敪(0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v)</param>
		/// <param name="jan">JAN�R�[�h(�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h)</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="goodsLGroup">���i�啪�ރR�[�h(���啪�ށi���[�U�[�K�C�h�j)</param>
		/// <param name="goodsLGroupName">���i�啪�ޖ���</param>
		/// <param name="goodsMGroup">���i�����ރR�[�h(�������ށi�}�X�^�L�j)</param>
		/// <param name="goodsMGroupName">���i�����ޖ���</param>
		/// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
		/// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
		/// <param name="goodsKindCode">���i����(9:�S�đΏ�)</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="joinSearchDiv">���������敪(0:���������Ȃ�,1:������������)</param>
		/// <param name="searchCarInfo">�ԗ��������ʃN���X(BL�R�[�h�������̂ݎg�p)</param>
		/// <param name="substCondDivCd">��֏����敪(0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="prmSubstCondDivCd">�D�Ǒ�֏����敪(0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="substApplyDivCd">��֓K�p�敪(0:���Ȃ�,1:����(�����A�Z�b�g),2:�S��(�����A�Z�b�g�A����)�@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="searchUICntDivCd">������ʐ���敪(0:PM7,1:PM.NS�@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="enterProcDivCd">�G���^�[�L�[�����敪(0:PM7,1:�I��,2:����ʁ@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="partsNoSearchDivCd">�i�Ԍ����敪(0:PM7(�Z�b�g�̂�),1:�����E�Z�b�g�E��ւ���@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="partsJoinCntDivCd">�i�Ԍ�������敪(�����l�h.�h�@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="eraNameDispCd1">�����\���敪�P(0:����,1:�a���i�N���j�@�G���g������̕��i�������̂ݗL��)</param>
		/// <param name="partsSearchPriDivCd">���i�����D�揇�敪(0:����,1:�D��)</param>
		/// <param name="joinInitDispDiv">���������\���敪(0:�\����,1:�݌ɏ�)</param>
		/// <param name="customerCode">���Ӑ�R�[�h(�P���Z�o�p)</param>
		/// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h(�P���Z�o�p)</param>
		/// <param name="priceApplyDate">���i�K�p��(�P���Z�o�p)</param>
		/// <param name="salesUnPrcFrcProcCd">����P���[�������R�[�h(�P���Z�o�p)</param>
		/// <param name="stockUnPrcFrcProcCd">�d���P���[�������R�[�h(�P���Z�o�p)</param>
		/// <param name="taxRate">�ŗ�(�P���Z�o�p)</param>
		/// <param name="totalAmountDispWayCd">���z�\�����@�敪(�P���Z�o�p)</param>
		/// <param name="ttlAmntDspRateDivCd">���z�\���|���K�p�敪(�P���Z�o�p)</param>
		/// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h(�P���Z�o�p)</param>
		/// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h(�P���Z�o�p)</param>
		/// <param name="listPriorWarehouse">�D��q�ɃR�[�h���X�g(����i�ԑI���E�C���h�E�̏����I���݌ɏ��̌���Ɏg�p)</param>
		/// <param name="isSettingSupplier">�d������擾�敪(0:�ݒ肠�� 1:�ݒ�Ȃ�)</param>
		/// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�]�� 1:���ד]�� 2:�����e 3:�����q 9:��ې�)</param>
		/// <param name="isSettingVariousMst">�s�����ݒ�敪(0:�ݒ肠�� 1:�ݒ�Ȃ�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <returns>GoodsCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
		/// </remarks>
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        //// 2009/12/18 >>>
        ////public GoodsCndtn(string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName)
        //public GoodsCndtn(string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode)
        //// 2009/12/18 <<<
        //public GoodsCndtn( string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode, Int32 bLGoodsDrCode ) // DEL 2015/08/17 �c���� Redmine#47036
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
        public GoodsCndtn( string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode, Int32 bLGoodsDrCode,
            string addUpSectionCode, string warehouseCode)
        //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
        {
			this._enterpriseCode = enterpriseCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsNoSrchTyp = goodsNoSrchTyp;
			this._goodsName = goodsName;
			this._goodsNameSrchTyp = goodsNameSrchTyp;
			this._goodsNameKana = goodsNameKana;
			this._goodsNameKanaSrchTyp = goodsNameKanaSrchTyp;
			this._jan = jan;
			this._bLGoodsCode = bLGoodsCode;
			this._goodsLGroup = goodsLGroup;
			this._goodsLGroupName = goodsLGroupName;
			this._goodsMGroup = goodsMGroup;
			this._goodsMGroupName = goodsMGroupName;
			this._bLGroupCode = bLGroupCode;
			this._bLGroupName = bLGroupName;
			this._goodsKindCode = goodsKindCode;
			this._sectionCode = sectionCode;
			this._joinSearchDiv = joinSearchDiv;
			this._searchCarInfo = searchCarInfo;
			this._substCondDivCd = substCondDivCd;
			this._prmSubstCondDivCd = prmSubstCondDivCd;
			this._substApplyDivCd = substApplyDivCd;
			this._searchUICntDivCd = searchUICntDivCd;
			this._enterProcDivCd = enterProcDivCd;
			this._partsNoSearchDivCd = partsNoSearchDivCd;
			this._partsJoinCntDivCd = partsJoinCntDivCd;
			this._eraNameDispCd1 = eraNameDispCd1;
			this._partsSearchPriDivCd = partsSearchPriDivCd;
			this._joinInitDispDiv = joinInitDispDiv;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._priceApplyDate = priceApplyDate;
			this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
			this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
			this._taxRate = taxRate;
			this._totalAmountDispWayCd = totalAmountDispWayCd;
			this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
			this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
			this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
			this._listPriorWarehouse = listPriorWarehouse;
			this._isSettingSupplier = isSettingSupplier;
			this._consTaxLayMethod = consTaxLayMethod;
			this._isSettingVariousMst = isSettingVariousMst;
			this._enterpriseName = enterpriseName;
			this._bLGoodsName = bLGoodsName;
            this._logicalMode = logicalMode;    // 2009/12/18 Add
            this._bLGoodsDrCode = bLGoodsDrCode;    // ADD m.suzuki 2011/05/18
            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            this._addUpSectionCode = addUpSectionCode;
            this._warehouseCode = warehouseCode;
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
        }

        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>
        /// ���i���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsNoSrchTyp">���i�ԍ������敪(0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v)</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsNameSrchTyp">���i���̌����敪(0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v)</param>
        /// <param name="goodsNameKana">���i���̃J�i</param>
        /// <param name="goodsNameKanaSrchTyp">���i�J�i���̌����敪(0:���S��v,1:�O����v����,2:�����v����,3:�B������,4:�n�C�t���������S��v)</param>
        /// <param name="jan">JAN�R�[�h(�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h(���啪�ށi���[�U�[�K�C�h�j)</param>
        /// <param name="goodsLGroupName">���i�啪�ޖ���</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h(�������ށi�}�X�^�L�j)</param>
        /// <param name="goodsMGroupName">���i�����ޖ���</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="goodsKindCode">���i����(9:�S�đΏ�)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="joinSearchDiv">���������敪(0:���������Ȃ�,1:������������)</param>
        /// <param name="searchCarInfo">�ԗ��������ʃN���X(BL�R�[�h�������̂ݎg�p)</param>
        /// <param name="substCondDivCd">��֏����敪(0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="prmSubstCondDivCd">�D�Ǒ�֏����敪(0:��ւ��Ȃ�,1:��ւ���(�݌ɖ�),2:��ւ���(�݌ɖ���)�@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="substApplyDivCd">��֓K�p�敪(0:���Ȃ�,1:����(�����A�Z�b�g),2:�S��(�����A�Z�b�g�A����)�@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="searchUICntDivCd">������ʐ���敪(0:PM7,1:PM.NS�@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="enterProcDivCd">�G���^�[�L�[�����敪(0:PM7,1:�I��,2:����ʁ@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="partsNoSearchDivCd">�i�Ԍ����敪(0:PM7(�Z�b�g�̂�),1:�����E�Z�b�g�E��ւ���@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="partsJoinCntDivCd">�i�Ԍ�������敪(�����l�h.�h�@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="eraNameDispCd1">�����\���敪�P(0:����,1:�a���i�N���j�@�G���g������̕��i�������̂ݗL��)</param>
        /// <param name="partsSearchPriDivCd">���i�����D�揇�敪(0:����,1:�D��)</param>
        /// <param name="joinInitDispDiv">���������\���敪(0:�\����,1:�݌ɏ�)</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�P���Z�o�p)</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h(�P���Z�o�p)</param>
        /// <param name="priceApplyDate">���i�K�p��(�P���Z�o�p)</param>
        /// <param name="salesUnPrcFrcProcCd">����P���[�������R�[�h(�P���Z�o�p)</param>
        /// <param name="stockUnPrcFrcProcCd">�d���P���[�������R�[�h(�P���Z�o�p)</param>
        /// <param name="taxRate">�ŗ�(�P���Z�o�p)</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(�P���Z�o�p)</param>
        /// <param name="ttlAmntDspRateDivCd">���z�\���|���K�p�敪(�P���Z�o�p)</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h(�P���Z�o�p)</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h(�P���Z�o�p)</param>
        /// <param name="listPriorWarehouse">�D��q�ɃR�[�h���X�g(����i�ԑI���E�C���h�E�̏����I���݌ɏ��̌���Ɏg�p)</param>
        /// <param name="isSettingSupplier">�d������擾�敪(0:�ݒ肠�� 1:�ݒ�Ȃ�)</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�]�� 1:���ד]�� 2:�����e 3:�����q 9:��ې�)</param>
        /// <param name="isSettingVariousMst">�s�����ݒ�敪(0:�ݒ肠�� 1:�ݒ�Ȃ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="addUpSectionCode"></param>
        /// <param name="bLGoodsDrCode">BL���i�R�[�h�}��</param>
        /// <param name="logicalMode"></param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="blUtyPtSbCdRF">BL���ꕔ�i�T�u�R�[�h</param>
        /// <param name="blUtyPtThCdRF">BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</param>
        /// <returns>GoodsCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�T�u�R�[�h�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>�Ǘ��ԍ�   : 11470007-00</br>
        /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public GoodsCndtn(
              string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp
            , string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup
            , string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo 
            , Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd
            , string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode
            , DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd
            , Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod
            , Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode, Int32 bLGoodsDrCode, string addUpSectionCode
            , string warehouseCode, string blUtyPtThCdRF, Int32 blUtyPtSbCdRF
            ) : this( enterpriseCode, goodsMakerCd, makerName, goodsNo, goodsNoSrchTyp, goodsName, goodsNameSrchTyp
            , goodsNameKana, goodsNameKanaSrchTyp, jan, bLGoodsCode, goodsLGroup, goodsLGroupName, goodsMGroup
            , goodsMGroupName, bLGroupCode, bLGroupName, goodsKindCode, sectionCode, joinSearchDiv, searchCarInfo
            , substCondDivCd, prmSubstCondDivCd, substApplyDivCd, searchUICntDivCd, enterProcDivCd, partsNoSearchDivCd
            , partsJoinCntDivCd, eraNameDispCd1, partsSearchPriDivCd, joinInitDispDiv, customerCode, custRateGrpCode
            , priceApplyDate, salesUnPrcFrcProcCd, stockUnPrcFrcProcCd, taxRate, totalAmountDispWayCd, ttlAmntDspRateDivCd
            , salesCnsTaxFrcProcCd, stockCnsTaxFrcProcCd, listPriorWarehouse, isSettingSupplier, consTaxLayMethod
            , isSettingVariousMst, enterpriseName, bLGoodsName, logicalMode, bLGoodsDrCode,addUpSectionCode, warehouseCode
            )
        {
            this._blUtyPtThCd = blUtyPtThCdRF;
            this._blUtyPtSbCd = blUtyPtSbCdRF;
        }
        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

		/// <summary>
		/// ���i���o�����N���X��������
		/// </summary>
		/// <returns>GoodsCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// <br>Update Note      :   2018/04/05  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
		/// </remarks>
		public GoodsCndtn Clone()
		{
            // ----UPD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
            ////// 2009/12/18 >>>
            //////return new GoodsCndtn(this._enterpriseCode,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsNoSrchTyp,this._goodsName,this._goodsNameSrchTyp,this._goodsNameKana,this._goodsNameKanaSrchTyp,this._jan,this._bLGoodsCode,this._goodsLGroup,this._goodsLGroupName,this._goodsMGroup,this._goodsMGroupName,this._bLGroupCode,this._bLGroupName,this._goodsKindCode,this._sectionCode,this._joinSearchDiv,this._searchCarInfo,this._substCondDivCd,this._prmSubstCondDivCd,this._substApplyDivCd,this._searchUICntDivCd,this._enterProcDivCd,this._partsNoSearchDivCd,this._partsJoinCntDivCd,this._eraNameDispCd1,this._partsSearchPriDivCd,this._joinInitDispDiv,this._customerCode,this._custRateGrpCode,this._priceApplyDate,this._salesUnPrcFrcProcCd,this._stockUnPrcFrcProcCd,this._taxRate,this._totalAmountDispWayCd,this._ttlAmntDspRateDivCd,this._salesCnsTaxFrcProcCd,this._stockCnsTaxFrcProcCd,this._listPriorWarehouse,this._isSettingSupplier,this._consTaxLayMethod,this._isSettingVariousMst,this._enterpriseName,this._bLGoodsName);
            ////return new GoodsCndtn(this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode);
            ////// 2009/12/18 <<<
            ////return new GoodsCndtn( this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode, this._bLGoodsDrCode ); // DEL 2015/08/17 �c���� Redmine#47036
            //// --- UPD m.suzuki 2011/05/18 ----------<<<<<
            ////----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            //return new GoodsCndtn(this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode, this._bLGoodsDrCode, 
            //    this._addUpSectionCode, this._warehouseCode);
            ////----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
            return new GoodsCndtn(this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode, this._bLGoodsDrCode, 
                this._addUpSectionCode, this._warehouseCode,this._blUtyPtThCd, this._blUtyPtSbCd);
            // ----UPD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        }

		/// <summary>
		/// ���i���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�GoodsCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// <br>Update Note      :   2018/04/05  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
		/// </remarks>
		public bool Equals(GoodsCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameSrchTyp == target.GoodsNameSrchTyp)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.GoodsNameKanaSrchTyp == target.GoodsNameKanaSrchTyp)
				 && (this.Jan == target.Jan)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.GoodsLGroup == target.GoodsLGroup)
				 && (this.GoodsLGroupName == target.GoodsLGroupName)
				 && (this.GoodsMGroup == target.GoodsMGroup)
				 && (this.GoodsMGroupName == target.GoodsMGroupName)
				 && (this.BLGroupCode == target.BLGroupCode)
				 && (this.BLGroupName == target.BLGroupName)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.JoinSearchDiv == target.JoinSearchDiv)
				 && (this.SearchCarInfo == target.SearchCarInfo)
				 && (this.SubstCondDivCd == target.SubstCondDivCd)
				 && (this.PrmSubstCondDivCd == target.PrmSubstCondDivCd)
				 && (this.SubstApplyDivCd == target.SubstApplyDivCd)
				 && (this.SearchUICntDivCd == target.SearchUICntDivCd)
				 && (this.EnterProcDivCd == target.EnterProcDivCd)
				 && (this.PartsNoSearchDivCd == target.PartsNoSearchDivCd)
				 && (this.PartsJoinCntDivCd == target.PartsJoinCntDivCd)
				 && (this.EraNameDispCd1 == target.EraNameDispCd1)
				 && (this.PartsSearchPriDivCd == target.PartsSearchPriDivCd)
				 && (this.JoinInitDispDiv == target.JoinInitDispDiv)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.PriceApplyDate == target.PriceApplyDate)
				 && (this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd)
				 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
				 && (this.TaxRate == target.TaxRate)
				 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
				 && (this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd)
				 && (this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd)
				 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
				 && (this.ListPriorWarehouse == target.ListPriorWarehouse)
				 && (this.IsSettingSupplier == target.IsSettingSupplier)
				 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				 && (this.IsSettingVariousMst == target.IsSettingVariousMst)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && ( this.LogicalMode == target.LogicalMode )   // 2009/12/18 Add
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode)    // ADD m.suzuki 2011/05/18
                 //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
                 && (this.AddUpSectionCode == target.AddUpSectionCode)
                 && (this.WarehouseCode == target.WarehouseCode)
                 //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
                 // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
                 && (this.BlUtyPtThCd == target.BlUtyPtThCd)
                 && (this.BlUtyPtSbCd == target.BlUtyPtSbCd) 
                 // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
                 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// ���i���o�����N���X��r����
		/// </summary>
		/// <param name="goodsCndtn1">
		///                    ��r����GoodsCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="goodsCndtn2">��r����GoodsCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// <br>Update Note      :   2018/04/05  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
		/// </remarks>
		public static bool Equals(GoodsCndtn goodsCndtn1, GoodsCndtn goodsCndtn2)
		{
			return ((goodsCndtn1.EnterpriseCode == goodsCndtn2.EnterpriseCode)
				 && (goodsCndtn1.GoodsMakerCd == goodsCndtn2.GoodsMakerCd)
				 && (goodsCndtn1.MakerName == goodsCndtn2.MakerName)
				 && (goodsCndtn1.GoodsNo == goodsCndtn2.GoodsNo)
				 && (goodsCndtn1.GoodsNoSrchTyp == goodsCndtn2.GoodsNoSrchTyp)
				 && (goodsCndtn1.GoodsName == goodsCndtn2.GoodsName)
				 && (goodsCndtn1.GoodsNameSrchTyp == goodsCndtn2.GoodsNameSrchTyp)
				 && (goodsCndtn1.GoodsNameKana == goodsCndtn2.GoodsNameKana)
				 && (goodsCndtn1.GoodsNameKanaSrchTyp == goodsCndtn2.GoodsNameKanaSrchTyp)
				 && (goodsCndtn1.Jan == goodsCndtn2.Jan)
				 && (goodsCndtn1.BLGoodsCode == goodsCndtn2.BLGoodsCode)
				 && (goodsCndtn1.GoodsLGroup == goodsCndtn2.GoodsLGroup)
				 && (goodsCndtn1.GoodsLGroupName == goodsCndtn2.GoodsLGroupName)
				 && (goodsCndtn1.GoodsMGroup == goodsCndtn2.GoodsMGroup)
				 && (goodsCndtn1.GoodsMGroupName == goodsCndtn2.GoodsMGroupName)
				 && (goodsCndtn1.BLGroupCode == goodsCndtn2.BLGroupCode)
				 && (goodsCndtn1.BLGroupName == goodsCndtn2.BLGroupName)
				 && (goodsCndtn1.GoodsKindCode == goodsCndtn2.GoodsKindCode)
				 && (goodsCndtn1.SectionCode == goodsCndtn2.SectionCode)
				 && (goodsCndtn1.JoinSearchDiv == goodsCndtn2.JoinSearchDiv)
				 && (goodsCndtn1.SearchCarInfo == goodsCndtn2.SearchCarInfo)
				 && (goodsCndtn1.SubstCondDivCd == goodsCndtn2.SubstCondDivCd)
				 && (goodsCndtn1.PrmSubstCondDivCd == goodsCndtn2.PrmSubstCondDivCd)
				 && (goodsCndtn1.SubstApplyDivCd == goodsCndtn2.SubstApplyDivCd)
				 && (goodsCndtn1.SearchUICntDivCd == goodsCndtn2.SearchUICntDivCd)
				 && (goodsCndtn1.EnterProcDivCd == goodsCndtn2.EnterProcDivCd)
				 && (goodsCndtn1.PartsNoSearchDivCd == goodsCndtn2.PartsNoSearchDivCd)
				 && (goodsCndtn1.PartsJoinCntDivCd == goodsCndtn2.PartsJoinCntDivCd)
				 && (goodsCndtn1.EraNameDispCd1 == goodsCndtn2.EraNameDispCd1)
				 && (goodsCndtn1.PartsSearchPriDivCd == goodsCndtn2.PartsSearchPriDivCd)
				 && (goodsCndtn1.JoinInitDispDiv == goodsCndtn2.JoinInitDispDiv)
				 && (goodsCndtn1.CustomerCode == goodsCndtn2.CustomerCode)
				 && (goodsCndtn1.CustRateGrpCode == goodsCndtn2.CustRateGrpCode)
				 && (goodsCndtn1.PriceApplyDate == goodsCndtn2.PriceApplyDate)
				 && (goodsCndtn1.SalesUnPrcFrcProcCd == goodsCndtn2.SalesUnPrcFrcProcCd)
				 && (goodsCndtn1.StockUnPrcFrcProcCd == goodsCndtn2.StockUnPrcFrcProcCd)
				 && (goodsCndtn1.TaxRate == goodsCndtn2.TaxRate)
				 && (goodsCndtn1.TotalAmountDispWayCd == goodsCndtn2.TotalAmountDispWayCd)
				 && (goodsCndtn1.TtlAmntDspRateDivCd == goodsCndtn2.TtlAmntDspRateDivCd)
				 && (goodsCndtn1.SalesCnsTaxFrcProcCd == goodsCndtn2.SalesCnsTaxFrcProcCd)
				 && (goodsCndtn1.StockCnsTaxFrcProcCd == goodsCndtn2.StockCnsTaxFrcProcCd)
				 && (goodsCndtn1.ListPriorWarehouse == goodsCndtn2.ListPriorWarehouse)
				 && (goodsCndtn1.IsSettingSupplier == goodsCndtn2.IsSettingSupplier)
				 && (goodsCndtn1.ConsTaxLayMethod == goodsCndtn2.ConsTaxLayMethod)
				 && (goodsCndtn1.IsSettingVariousMst == goodsCndtn2.IsSettingVariousMst)
				 && (goodsCndtn1.EnterpriseName == goodsCndtn2.EnterpriseName)
                 && ( goodsCndtn1.LogicalMode == goodsCndtn2.LogicalMode )      // 2009/12/18 Add
                 && (goodsCndtn1.BLGoodsDrCode == goodsCndtn2.BLGoodsDrCode)    // ADD m.suzuki 2011/05/18
                //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
                 && (goodsCndtn1.AddUpSectionCode == goodsCndtn2.AddUpSectionCode)
                 && (goodsCndtn1.WarehouseCode == goodsCndtn2.WarehouseCode)
                //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
                 // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
                 && (goodsCndtn1.BlUtyPtThCd == goodsCndtn2.BlUtyPtThCd)
                 && (goodsCndtn1.BlUtyPtSbCd == goodsCndtn2.BlUtyPtSbCd) 
                 // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
                 && (goodsCndtn1.BLGoodsName == goodsCndtn2.BLGoodsName));
		}
		/// <summary>
		/// ���i���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�GoodsCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// <br>Update Note      :   2018/04/05  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
		/// </remarks>
		public ArrayList Compare(GoodsCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsNoSrchTyp != target.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameSrchTyp != target.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.GoodsNameKanaSrchTyp != target.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(this.Jan != target.Jan)resList.Add("Jan");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.GoodsLGroup != target.GoodsLGroup)resList.Add("GoodsLGroup");
			if(this.GoodsLGroupName != target.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(this.GoodsMGroup != target.GoodsMGroup)resList.Add("GoodsMGroup");
			if(this.GoodsMGroupName != target.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(this.BLGroupCode != target.BLGroupCode)resList.Add("BLGroupCode");
			if(this.BLGroupName != target.BLGroupName)resList.Add("BLGroupName");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.JoinSearchDiv != target.JoinSearchDiv)resList.Add("JoinSearchDiv");
			if(this.SearchCarInfo != target.SearchCarInfo)resList.Add("SearchCarInfo");
			if(this.SubstCondDivCd != target.SubstCondDivCd)resList.Add("SubstCondDivCd");
			if(this.PrmSubstCondDivCd != target.PrmSubstCondDivCd)resList.Add("PrmSubstCondDivCd");
			if(this.SubstApplyDivCd != target.SubstApplyDivCd)resList.Add("SubstApplyDivCd");
			if(this.SearchUICntDivCd != target.SearchUICntDivCd)resList.Add("SearchUICntDivCd");
			if(this.EnterProcDivCd != target.EnterProcDivCd)resList.Add("EnterProcDivCd");
			if(this.PartsNoSearchDivCd != target.PartsNoSearchDivCd)resList.Add("PartsNoSearchDivCd");
			if(this.PartsJoinCntDivCd != target.PartsJoinCntDivCd)resList.Add("PartsJoinCntDivCd");
			if(this.EraNameDispCd1 != target.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(this.PartsSearchPriDivCd != target.PartsSearchPriDivCd)resList.Add("PartsSearchPriDivCd");
			if(this.JoinInitDispDiv != target.JoinInitDispDiv)resList.Add("JoinInitDispDiv");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(this.PriceApplyDate != target.PriceApplyDate)resList.Add("PriceApplyDate");
			if(this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd)resList.Add("SalesUnPrcFrcProcCd");
			if(this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(this.TaxRate != target.TaxRate)resList.Add("TaxRate");
			if(this.TotalAmountDispWayCd != target.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd)resList.Add("TtlAmntDspRateDivCd");
			if(this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd)resList.Add("SalesCnsTaxFrcProcCd");
			if(this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(this.ListPriorWarehouse != target.ListPriorWarehouse)resList.Add("ListPriorWarehouse");
			if(this.IsSettingSupplier != target.IsSettingSupplier)resList.Add("IsSettingSupplier");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.IsSettingVariousMst != target.IsSettingVariousMst)resList.Add("IsSettingVariousMst");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            if (this.LogicalMode != target.LogicalMode) resList.Add("LogicalMode"); // 2009/12/18 Add
            if ( this.BLGoodsDrCode != target.BLGoodsDrCode ) resList.Add( "LogicalMode" ); // ADD m.suzuki 2011/05/18
            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            if (this.AddUpSectionCode != target.AddUpSectionCode) resList.Add("AddUpSectionCode");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
            // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            if (this.BlUtyPtThCd != target.BlUtyPtThCd) resList.Add("BlUtyPtThCd");
            if (this.BlUtyPtSbCd != target.BlUtyPtSbCd) resList.Add("BlUtyPtSbCd");
            // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

			return resList;
		}

		/// <summary>
		/// ���i���o�����N���X��r����
		/// </summary>
		/// <param name="goodsCndtn1">��r����GoodsCndtn�N���X�̃C���X�^���X</param>
		/// <param name="goodsCndtn2">��r����GoodsCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>                     Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// <br>Update Note      :   2018/04/05  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>                     BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
		/// </remarks>
		public static ArrayList Compare(GoodsCndtn goodsCndtn1, GoodsCndtn goodsCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(goodsCndtn1.EnterpriseCode != goodsCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(goodsCndtn1.GoodsMakerCd != goodsCndtn2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(goodsCndtn1.MakerName != goodsCndtn2.MakerName)resList.Add("MakerName");
			if(goodsCndtn1.GoodsNo != goodsCndtn2.GoodsNo)resList.Add("GoodsNo");
			if(goodsCndtn1.GoodsNoSrchTyp != goodsCndtn2.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(goodsCndtn1.GoodsName != goodsCndtn2.GoodsName)resList.Add("GoodsName");
			if(goodsCndtn1.GoodsNameSrchTyp != goodsCndtn2.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(goodsCndtn1.GoodsNameKana != goodsCndtn2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(goodsCndtn1.GoodsNameKanaSrchTyp != goodsCndtn2.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(goodsCndtn1.Jan != goodsCndtn2.Jan)resList.Add("Jan");
			if(goodsCndtn1.BLGoodsCode != goodsCndtn2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(goodsCndtn1.GoodsLGroup != goodsCndtn2.GoodsLGroup)resList.Add("GoodsLGroup");
			if(goodsCndtn1.GoodsLGroupName != goodsCndtn2.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(goodsCndtn1.GoodsMGroup != goodsCndtn2.GoodsMGroup)resList.Add("GoodsMGroup");
			if(goodsCndtn1.GoodsMGroupName != goodsCndtn2.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(goodsCndtn1.BLGroupCode != goodsCndtn2.BLGroupCode)resList.Add("BLGroupCode");
			if(goodsCndtn1.BLGroupName != goodsCndtn2.BLGroupName)resList.Add("BLGroupName");
			if(goodsCndtn1.GoodsKindCode != goodsCndtn2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(goodsCndtn1.SectionCode != goodsCndtn2.SectionCode)resList.Add("SectionCode");
			if(goodsCndtn1.JoinSearchDiv != goodsCndtn2.JoinSearchDiv)resList.Add("JoinSearchDiv");
			if(goodsCndtn1.SearchCarInfo != goodsCndtn2.SearchCarInfo)resList.Add("SearchCarInfo");
			if(goodsCndtn1.SubstCondDivCd != goodsCndtn2.SubstCondDivCd)resList.Add("SubstCondDivCd");
			if(goodsCndtn1.PrmSubstCondDivCd != goodsCndtn2.PrmSubstCondDivCd)resList.Add("PrmSubstCondDivCd");
			if(goodsCndtn1.SubstApplyDivCd != goodsCndtn2.SubstApplyDivCd)resList.Add("SubstApplyDivCd");
			if(goodsCndtn1.SearchUICntDivCd != goodsCndtn2.SearchUICntDivCd)resList.Add("SearchUICntDivCd");
			if(goodsCndtn1.EnterProcDivCd != goodsCndtn2.EnterProcDivCd)resList.Add("EnterProcDivCd");
			if(goodsCndtn1.PartsNoSearchDivCd != goodsCndtn2.PartsNoSearchDivCd)resList.Add("PartsNoSearchDivCd");
			if(goodsCndtn1.PartsJoinCntDivCd != goodsCndtn2.PartsJoinCntDivCd)resList.Add("PartsJoinCntDivCd");
			if(goodsCndtn1.EraNameDispCd1 != goodsCndtn2.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(goodsCndtn1.PartsSearchPriDivCd != goodsCndtn2.PartsSearchPriDivCd)resList.Add("PartsSearchPriDivCd");
			if(goodsCndtn1.JoinInitDispDiv != goodsCndtn2.JoinInitDispDiv)resList.Add("JoinInitDispDiv");
			if(goodsCndtn1.CustomerCode != goodsCndtn2.CustomerCode)resList.Add("CustomerCode");
			if(goodsCndtn1.CustRateGrpCode != goodsCndtn2.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(goodsCndtn1.PriceApplyDate != goodsCndtn2.PriceApplyDate)resList.Add("PriceApplyDate");
			if(goodsCndtn1.SalesUnPrcFrcProcCd != goodsCndtn2.SalesUnPrcFrcProcCd)resList.Add("SalesUnPrcFrcProcCd");
			if(goodsCndtn1.StockUnPrcFrcProcCd != goodsCndtn2.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(goodsCndtn1.TaxRate != goodsCndtn2.TaxRate)resList.Add("TaxRate");
			if(goodsCndtn1.TotalAmountDispWayCd != goodsCndtn2.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(goodsCndtn1.TtlAmntDspRateDivCd != goodsCndtn2.TtlAmntDspRateDivCd)resList.Add("TtlAmntDspRateDivCd");
			if(goodsCndtn1.SalesCnsTaxFrcProcCd != goodsCndtn2.SalesCnsTaxFrcProcCd)resList.Add("SalesCnsTaxFrcProcCd");
			if(goodsCndtn1.StockCnsTaxFrcProcCd != goodsCndtn2.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(goodsCndtn1.ListPriorWarehouse != goodsCndtn2.ListPriorWarehouse)resList.Add("ListPriorWarehouse");
			if(goodsCndtn1.IsSettingSupplier != goodsCndtn2.IsSettingSupplier)resList.Add("IsSettingSupplier");
			if(goodsCndtn1.ConsTaxLayMethod != goodsCndtn2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(goodsCndtn1.IsSettingVariousMst != goodsCndtn2.IsSettingVariousMst)resList.Add("IsSettingVariousMst");
			if(goodsCndtn1.EnterpriseName != goodsCndtn2.EnterpriseName)resList.Add("EnterpriseName");
			if(goodsCndtn1.BLGoodsName != goodsCndtn2.BLGoodsName)resList.Add("BLGoodsName");
            if (goodsCndtn1.LogicalMode != goodsCndtn2.LogicalMode) resList.Add("LogicalMode");     // 2009/12/18 Add
            if ( goodsCndtn1.BLGoodsDrCode != goodsCndtn2.BLGoodsDrCode ) resList.Add( "BLGoodsDrCode" );     // ADD m.suzuki 2011/05/18
            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            if (goodsCndtn1.AddUpSectionCode != goodsCndtn2.AddUpSectionCode) resList.Add("AddUpSectionCode");
            if (goodsCndtn1.WarehouseCode != goodsCndtn2.WarehouseCode) resList.Add("WarehouseCode");
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<
            // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            if (goodsCndtn1.BlUtyPtThCd != goodsCndtn2.BlUtyPtThCd) resList.Add("BlUtyPtThCd");
            if (goodsCndtn1.BlUtyPtSbCd != goodsCndtn2.BlUtyPtSbCd) resList.Add("BlUtyPtSbCd");
            // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

			return resList;
		}

        /// <summary>
        /// ���i�}�X�^�i���o�����N���X�j��������
        /// </summary>
        /// <returns></returns>
        public GoodsCndtn Create()
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this.EnterpriseCode;

            // ���L���ڂ͌��f�[�^���ق�����
            goodsCndtn.GoodsNoSrchTyp = this.GoodsNoSrchTyp;
            goodsCndtn.GoodsNameKanaSrchTyp = this.GoodsNameKanaSrchTyp;
            goodsCndtn.GoodsNameSrchTyp = this.GoodsNameSrchTyp;
            goodsCndtn.GoodsKindCode = this.GoodsKindCode;

            return goodsCndtn;
        }

        /// <summary>
        /// ���������敪
        /// </summary>
        public enum JoinSearchDivType : int
        {
            /// <summary>�����Ȃ�</summary>
            NoSearch = 0,
            /// <summary>��������</summary>
            Search = 1
        }
	}
}
