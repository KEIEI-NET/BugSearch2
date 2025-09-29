using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
# if false
	/// public class name:   GoodsUnitData
	/// <summary>
	///                      ���i�A���f�[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���i�A���f�[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/06/12</br>
	/// <br>Genarated Date   :   2008/10/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class GoodsUnitData
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

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���[�J�[����</summary>
		/// <remarks>���[�J�}�X�^���擾</remarks>
		private string _makerName = "";

		/// <summary>���[�J�[����</summary>
		/// <remarks>���[�J�}�X�^���擾</remarks>
		private string _makerShortName = "";

		/// <summary>���[�J�[�J�i����</summary>
		/// <remarks>���[�J�}�X�^���擾</remarks>
		private string _makerKanaName = "";

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i����</summary>
		private string _goodsName = "";

		/// <summary>���i���̃J�i</summary>
		/// <remarks>�����p�J�i</remarks>
		private string _goodsNameKana = "";

		/// <summary>JAN�R�[�h</summary>
		/// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
		private string _jan = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h���́i�S�p�j</summary>
		/// <remarks>BL���i�R�[�h�}�X�^���擾</remarks>
		private string _bLGoodsFullName = "";

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>���i�啪�ރR�[�h</summary>
		/// <remarks>BL�O���[�v�}�X�^���擾</remarks>
		private Int32 _goodsLGroup;

		/// <summary>���i�啪�ޖ���</summary>
		/// <remarks>���[�U�[�K�C�h���擾</remarks>
		private string _goodsLGroupName = "";

		/// <summary>���i�����ރR�[�h</summary>
		/// <remarks>BL�O���[�v�}�X�^���擾</remarks>
		private Int32 _goodsMGroup;

		/// <summary>���i�����ޖ���</summary>
		/// <remarks>���i�����ރ}�X�^���擾</remarks>
		private string _goodsMGroupName = "";

		/// <summary>BL�O���[�v�R�[�h</summary>
		/// <remarks>BL�R�[�h�}�X�^���擾</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BL�O���[�v�R�[�h����</summary>
		/// <remarks>BL�O���[�v�}�X�^���擾</remarks>
		private string _bLGroupName = "";

		/// <summary>���i�|�������N</summary>
		/// <remarks>�w��</remarks>
		private string _goodsRateRank = "";

		/// <summary>�ېŋ敪</summary>
		/// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
		private Int32 _taxationDivCd;

		/// <summary>�n�C�t�������i�ԍ�</summary>
		private string _goodsNoNoneHyphen = "";

		/// <summary>�񋟓��t</summary>
		private DateTime _offerDate;

		/// <summary>���i����</summary>
		private Int32 _goodsKindCode;

		/// <summary>���i���l�P</summary>
		private string _goodsNote1 = "";

		/// <summary>���i���l�Q</summary>
		private string _goodsNote2 = "";

		/// <summary>���i�K�i�E���L����</summary>
		private string _goodsSpecialNote = "";

		/// <summary>���Е��ރR�[�h</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>���Е��ޖ���</summary>
		/// <remarks>���[�U�[�K�C�h���擾</remarks>
		private string _enterpriseGanreName = "";

		/// <summary>�X�V�N����</summary>
		private DateTime _updateDate;

		/// <summary>���i�|���O���[�v�R�[�h</summary>
		/// <remarks>BL�R�[�h�}�X�^���擾</remarks>
		private Int32 _goodsRateGrpCode;

		/// <summary>���i�|���O���[�v�R�[�h����</summary>
		/// <remarks>���i�����ރ}�X�^���擾</remarks>
		private string _goodsRateGrpName = "";

		/// <summary>�̔��敪�R�[�h</summary>
		/// <remarks>BL�O���[�v�}�X�^���擾</remarks>
		private Int32 _salesCode;

		/// <summary>�̔��敪����</summary>
		/// <remarks>���[�U�[�K�C�h���擾</remarks>
		private string _salesCodeName = "";

		/// <summary>�d����R�[�h</summary>
		/// <remarks>���i�Ǘ����}�X�^���擾</remarks>
		private Int32 _supplierCd;

		/// <summary>�d���於1</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private string _supplierNm1 = "";

		/// <summary>�d���於2</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private string _supplierNm2 = "";

		/// <summary>�d����h��</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private string _suppHonorificTitle = "";

		/// <summary>�d����J�i</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private string _supplierKana = "";

		/// <summary>�d���旪��</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private string _supplierSnm = "";

		/// <summary>�d���P���[�������R�[�h</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private Int32 _stockUnPrcFrcProcCd;

		/// <summary>�d������Œ[�������R�[�h</summary>
		/// <remarks>�d����}�X�^���擾</remarks>
		private Int32 _stockCnsTaxFrcProcCd;

		/// <summary>�������b�g</summary>
		/// <remarks>���i�Ǘ����}�X�^���擾</remarks>
		private Int32 _supplierLot;

		/// <summary>�V�[�N���b�g�敪</summary>
		/// <remarks>�D�ǐݒ�}�X�^���擾�@0:�ʏ�@1:�V�[�N���b�g</remarks>
		private Int32 _secretCode;

		/// <summary>�\������</summary>
		/// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
		private Int32 _primePartsDisplayOrder;

		/// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
		/// <remarks>�D�ǐݒ�}�X�^���擾�@�Z���N�g�R�[�h</remarks>
		private Int32 _prmSetDtlNo1;

		/// <summary>�D�ǐݒ�ڍז��̂P</summary>
		/// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
		private string _prmSetDtlName1 = "";

		/// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
		/// <remarks>�D�ǐݒ�}�X�^���擾�@��ʃR�[�h</remarks>
		private Int32 _prmSetDtlNo2;

		/// <summary>�D�ǐݒ�ڍז��̂Q</summary>
		/// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
		private string _prmSetDtlName2 = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>���i�Ǘ����}�X�^�擾�Ŏg�p</remarks>
		private string _sectionCode = "";

		/// <summary>���i���</summary>
		/// <remarks>List<GoodsPrice></remarks>
		private List<GoodsPrice> _goodsPriceList;

		/// <summary>�݌ɏ��</summary>
		/// <remarks>List<Stock></remarks>
		private List<Stock> _stockList;

		/// <summary>�񋟋敪</summary>
		/// <remarks>0:���[�U�[�o�^,1:�񋟏����ҏW,2:�񋟗D�ǕҏW,3:�񋟏���,4:�񋟗D��,5:TBO,7:�I���W�i�����i</remarks>
		private Int32 _offerKubun;

		/// <summary>���i���(��������)</summary>
		/// <remarks>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</remarks>
		private Int32 _goodsKind;

		/// <summary>���i���(�����Ȃ�)</summary>
		/// <remarks>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</remarks>
		private Int32 _goodsKindResolved;

		/// <summary>�����\������</summary>
		private Int32 _joinDispOrder;

		/// <summary>����QTY</summary>
		private Double _joinQty;

		/// <summary>�����K�i�E���L����</summary>
		private string _joinSpecialNote = "";

		/// <summary>�Z�b�g�\������</summary>
		private Int32 _setDispOrder;

		/// <summary>�Z�b�gQTY</summary>
		private Double _setQty;

		/// <summary>�Z�b�g�K�i�E���L����</summary>
		private string _setSpecialNote = "";

		/// <summary>���iQTY</summary>
		private Double _partsQty;

		/// <summary>�񋟃f�[�^�敪</summary>
		/// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
		private Int32 _offerDataDiv;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";


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
		/// <value>���[�J�}�X�^���擾</value>
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

		/// public propaty name  :  MakerShortName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// <value>���[�J�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerShortName
		{
			get{return _makerShortName;}
			set{_makerShortName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
		/// <value>���[�J�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerKanaName
		{
			get{return _makerKanaName;}
			set{_makerKanaName = value;}
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

		/// public propaty name  :  GoodsNameKana
		/// <summary>���i���̃J�i�v���p�e�B</summary>
		/// <value>�����p�J�i</value>
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

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
		/// <value>BL���i�R�[�h�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
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

		/// public propaty name  :  GoodsLGroup
		/// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
		/// <value>BL�O���[�v�}�X�^���擾</value>
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
		/// <value>���[�U�[�K�C�h���擾</value>
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
		/// <value>BL�O���[�v�}�X�^���擾</value>
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
		/// <value>���i�����ރ}�X�^���擾</value>
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
		/// <value>BL�R�[�h�}�X�^���擾</value>
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
		/// <value>BL�O���[�v�}�X�^���擾</value>
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

		/// public propaty name  :  GoodsRateRank
		/// <summary>���i�|�������N�v���p�e�B</summary>
		/// <value>�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|�������N�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsRateRank
		{
			get{return _goodsRateRank;}
			set{_goodsRateRank = value;}
		}

		/// public propaty name  :  TaxationDivCd
		/// <summary>�ېŋ敪�v���p�e�B</summary>
		/// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ېŋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  GoodsNoNoneHyphen
		/// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNoNoneHyphen
		{
			get{return _goodsNoNoneHyphen;}
			set{_goodsNoNoneHyphen = value;}
		}

		/// public propaty name  :  OfferDate
		/// <summary>�񋟓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime OfferDate
		{
			get{return _offerDate;}
			set{_offerDate = value;}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>���i�����v���p�e�B</summary>
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

		/// public propaty name  :  GoodsNote1
		/// <summary>���i���l�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���l�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNote1
		{
			get{return _goodsNote1;}
			set{_goodsNote1 = value;}
		}

		/// public propaty name  :  GoodsNote2
		/// <summary>���i���l�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���l�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNote2
		{
			get{return _goodsNote2;}
			set{_goodsNote2 = value;}
		}

		/// public propaty name  :  GoodsSpecialNote
		/// <summary>���i�K�i�E���L�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsSpecialNote
		{
			get{return _goodsSpecialNote;}
			set{_goodsSpecialNote = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreName
		/// <summary>���Е��ޖ��̃v���p�e�B</summary>
		/// <value>���[�U�[�K�C�h���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseGanreName
		{
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
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

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>�X�V�N���� �a��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>�X�V�N���� �a��(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>�X�V�N���� ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>�X�V�N���� ����(��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  GoodsRateGrpCode
		/// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>BL�R�[�h�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsRateGrpCode
		{
			get{return _goodsRateGrpCode;}
			set{_goodsRateGrpCode = value;}
		}

		/// public propaty name  :  GoodsRateGrpName
		/// <summary>���i�|���O���[�v�R�[�h���̃v���p�e�B</summary>
		/// <value>���i�����ރ}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�|���O���[�v�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsRateGrpName
		{
			get{return _goodsRateGrpName;}
			set{_goodsRateGrpName = value;}
		}

		/// public propaty name  :  SalesCode
		/// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
		/// <value>BL�O���[�v�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesCode
		{
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCodeName
		/// <summary>�̔��敪���̃v���p�e�B</summary>
		/// <value>���[�U�[�K�C�h���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesCodeName
		{
			get{return _salesCodeName;}
			set{_salesCodeName = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// <value>���i�Ǘ����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierNm1
		/// <summary>�d���於1�v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���於1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
		}

		/// public propaty name  :  SupplierNm2
		/// <summary>�d���於2�v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���於2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierNm2
		{
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
		}

		/// public propaty name  :  SuppHonorificTitle
		/// <summary>�d����h�̃v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����h�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SuppHonorificTitle
		{
			get{return _suppHonorificTitle;}
			set{_suppHonorificTitle = value;}
		}

		/// public propaty name  :  SupplierKana
		/// <summary>�d����J�i�v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierKana
		{
			get{return _supplierKana;}
			set{_supplierKana = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>�d���旪�̃v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  StockUnPrcFrcProcCd
		/// <summary>�d���P���[�������R�[�h�v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
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

		/// public propaty name  :  StockCnsTaxFrcProcCd
		/// <summary>�d������Œ[�������R�[�h�v���p�e�B</summary>
		/// <value>�d����}�X�^���擾</value>
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

		/// public propaty name  :  SupplierLot
		/// <summary>�������b�g�v���p�e�B</summary>
		/// <value>���i�Ǘ����}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������b�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierLot
		{
			get{return _supplierLot;}
			set{_supplierLot = value;}
		}

		/// public propaty name  :  SecretCode
		/// <summary>�V�[�N���b�g�敪�v���p�e�B</summary>
		/// <value>�D�ǐݒ�}�X�^���擾�@0:�ʏ�@1:�V�[�N���b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�[�N���b�g�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SecretCode
		{
			get{return _secretCode;}
			set{_secretCode = value;}
		}

		/// public propaty name  :  PrimePartsDisplayOrder
		/// <summary>�\�����ʃv���p�e�B</summary>
		/// <value>�D�ǐݒ�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrimePartsDisplayOrder
		{
			get{return _primePartsDisplayOrder;}
			set{_primePartsDisplayOrder = value;}
		}

		/// public propaty name  :  PrmSetDtlNo1
		/// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
		/// <value>�D�ǐݒ�}�X�^���擾�@�Z���N�g�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrmSetDtlNo1
		{
			get{return _prmSetDtlNo1;}
			set{_prmSetDtlNo1 = value;}
		}

		/// public propaty name  :  PrmSetDtlName1
		/// <summary>�D�ǐݒ�ڍז��̂P�v���p�e�B</summary>
		/// <value>�D�ǐݒ�}�X�^���擾</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�ǐݒ�ڍז��̂P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrmSetDtlName1
		{
			get{return _prmSetDtlName1;}
			set{_prmSetDtlName1 = value;}
		}

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
			get{return _prmSetDtlNo2;}
			set{_prmSetDtlNo2 = value;}
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
			get{return _prmSetDtlName2;}
			set{_prmSetDtlName2 = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>���i�Ǘ����}�X�^�擾�Ŏg�p</value>
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

		/// public propaty name  :  GoodsPriceList
		/// <summary>���i���v���p�e�B</summary>
		/// <value>List<GoodsPrice></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<GoodsPrice> GoodsPriceList
		{
			get{return _goodsPriceList;}
			set{_goodsPriceList = value;}
		}

		/// public propaty name  :  StockList
		/// <summary>�݌ɏ��v���p�e�B</summary>
		/// <value>List<Stock></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɏ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public List<Stock> StockList
		{
			get{return _stockList;}
			set{_stockList = value;}
		}

		/// public propaty name  :  OfferKubun
		/// <summary>�񋟋敪�v���p�e�B</summary>
		/// <value>0:���[�U�[�o�^,1:�񋟏����ҏW,2:�񋟗D�ǕҏW,3:�񋟏���,4:�񋟗D��,5:TBO,7:�I���W�i�����i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferKubun
		{
			get{return _offerKubun;}
			set{_offerKubun = value;}
		}

		/// public propaty name  :  GoodsKind
		/// <summary>���i���(��������)�v���p�e�B</summary>
		/// <value>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���(��������)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsKind
		{
			get{return _goodsKind;}
			set{_goodsKind = value;}
		}

		/// public propaty name  :  GoodsKindResolved
		/// <summary>���i���(�����Ȃ�)�v���p�e�B</summary>
		/// <value>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���(�����Ȃ�)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsKindResolved
		{
			get{return _goodsKindResolved;}
			set{_goodsKindResolved = value;}
		}

		/// public propaty name  :  JoinDispOrder
		/// <summary>�����\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinDispOrder
		{
			get{return _joinDispOrder;}
			set{_joinDispOrder = value;}
		}

		/// public propaty name  :  JoinQty
		/// <summary>����QTY�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����QTY�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double JoinQty
		{
			get{return _joinQty;}
			set{_joinQty = value;}
		}

		/// public propaty name  :  JoinSpecialNote
		/// <summary>�����K�i�E���L�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinSpecialNote
		{
			get{return _joinSpecialNote;}
			set{_joinSpecialNote = value;}
		}

		/// public propaty name  :  SetDispOrder
		/// <summary>�Z�b�g�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetDispOrder
		{
			get{return _setDispOrder;}
			set{_setDispOrder = value;}
		}

		/// public propaty name  :  SetQty
		/// <summary>�Z�b�gQTY�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�gQTY�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SetQty
		{
			get{return _setQty;}
			set{_setQty = value;}
		}

		/// public propaty name  :  SetSpecialNote
		/// <summary>�Z�b�g�K�i�E���L�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetSpecialNote
		{
			get{return _setSpecialNote;}
			set{_setSpecialNote = value;}
		}

		/// public propaty name  :  PartsQty
		/// <summary>���iQTY�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���iQTY�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PartsQty
		{
			get{return _partsQty;}
			set{_partsQty = value;}
		}

		/// public propaty name  :  OfferDataDiv
		/// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
		/// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OfferDataDiv
		{
			get{return _offerDataDiv;}
			set{_offerDataDiv = value;}
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
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


		/// <summary>
		/// ���i�A���f�[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>GoodsUnitData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsUnitData()
		{
		}

		/// <summary>
		/// ���i�A���f�[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����(���[�J�}�X�^���擾)</param>
		/// <param name="makerShortName">���[�J�[����(���[�J�}�X�^���擾)</param>
		/// <param name="makerKanaName">���[�J�[�J�i����(���[�J�}�X�^���擾)</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="goodsNameKana">���i���̃J�i(�����p�J�i)</param>
		/// <param name="jan">JAN�R�[�h(�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h)</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j(BL���i�R�[�h�}�X�^���擾)</param>
		/// <param name="displayOrder">�\������</param>
		/// <param name="goodsLGroup">���i�啪�ރR�[�h(BL�O���[�v�}�X�^���擾)</param>
		/// <param name="goodsLGroupName">���i�啪�ޖ���(���[�U�[�K�C�h���擾)</param>
		/// <param name="goodsMGroup">���i�����ރR�[�h(BL�O���[�v�}�X�^���擾)</param>
		/// <param name="goodsMGroupName">���i�����ޖ���(���i�����ރ}�X�^���擾)</param>
		/// <param name="bLGroupCode">BL�O���[�v�R�[�h(BL�R�[�h�}�X�^���擾)</param>
		/// <param name="bLGroupName">BL�O���[�v�R�[�h����(BL�O���[�v�}�X�^���擾)</param>
		/// <param name="goodsRateRank">���i�|�������N(�w��)</param>
		/// <param name="taxationDivCd">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
		/// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
		/// <param name="offerDate">�񋟓��t</param>
		/// <param name="goodsKindCode">���i����</param>
		/// <param name="goodsNote1">���i���l�P</param>
		/// <param name="goodsNote2">���i���l�Q</param>
		/// <param name="goodsSpecialNote">���i�K�i�E���L����</param>
		/// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
		/// <param name="enterpriseGanreName">���Е��ޖ���(���[�U�[�K�C�h���擾)</param>
		/// <param name="updateDate">�X�V�N����</param>
		/// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h(BL�R�[�h�}�X�^���擾)</param>
		/// <param name="goodsRateGrpName">���i�|���O���[�v�R�[�h����(���i�����ރ}�X�^���擾)</param>
		/// <param name="salesCode">�̔��敪�R�[�h(BL�O���[�v�}�X�^���擾)</param>
		/// <param name="salesCodeName">�̔��敪����(���[�U�[�K�C�h���擾)</param>
		/// <param name="supplierCd">�d����R�[�h(���i�Ǘ����}�X�^���擾)</param>
		/// <param name="supplierNm1">�d���於1(�d����}�X�^���擾)</param>
		/// <param name="supplierNm2">�d���於2(�d����}�X�^���擾)</param>
		/// <param name="suppHonorificTitle">�d����h��(�d����}�X�^���擾)</param>
		/// <param name="supplierKana">�d����J�i(�d����}�X�^���擾)</param>
		/// <param name="supplierSnm">�d���旪��(�d����}�X�^���擾)</param>
		/// <param name="stockUnPrcFrcProcCd">�d���P���[�������R�[�h(�d����}�X�^���擾)</param>
		/// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h(�d����}�X�^���擾)</param>
		/// <param name="supplierLot">�������b�g(���i�Ǘ����}�X�^���擾)</param>
		/// <param name="secretCode">�V�[�N���b�g�敪(�D�ǐݒ�}�X�^���擾�@0:�ʏ�@1:�V�[�N���b�g)</param>
		/// <param name="primePartsDisplayOrder">�\������(�D�ǐݒ�}�X�^���擾)</param>
		/// <param name="prmSetDtlNo1">�D�ǐݒ�ڍ׃R�[�h�P(�D�ǐݒ�}�X�^���擾�@�Z���N�g�R�[�h)</param>
		/// <param name="prmSetDtlName1">�D�ǐݒ�ڍז��̂P(�D�ǐݒ�}�X�^���擾)</param>
		/// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q(�D�ǐݒ�}�X�^���擾�@��ʃR�[�h)</param>
		/// <param name="prmSetDtlName2">�D�ǐݒ�ڍז��̂Q(�D�ǐݒ�}�X�^���擾)</param>
		/// <param name="sectionCode">���_�R�[�h(���i�Ǘ����}�X�^�擾�Ŏg�p)</param>
		/// <param name="goodsPriceList">���i���(List<GoodsPrice>)</param>
		/// <param name="stockList">�݌ɏ��(List<Stock>)</param>
		/// <param name="offerKubun">�񋟋敪(0:���[�U�[�o�^,1:�񋟏����ҏW,2:�񋟗D�ǕҏW,3:�񋟏���,4:�񋟗D��,5:TBO,7:�I���W�i�����i)</param>
		/// <param name="goodsKind">���i���(��������)(1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0)</param>
		/// <param name="goodsKindResolved">���i���(�����Ȃ�)(1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0)</param>
		/// <param name="joinDispOrder">�����\������</param>
		/// <param name="joinQty">����QTY</param>
		/// <param name="joinSpecialNote">�����K�i�E���L����</param>
		/// <param name="setDispOrder">�Z�b�g�\������</param>
		/// <param name="setQty">�Z�b�gQTY</param>
		/// <param name="setSpecialNote">�Z�b�g�K�i�E���L����</param>
		/// <param name="partsQty">���iQTY</param>
		/// <param name="offerDataDiv">�񋟃f�[�^�敪(0:���[�U�f�[�^,1:�񋟃f�[�^)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
		/// <returns>GoodsUnitData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsUnitData(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 goodsMakerCd,string makerName,string makerShortName,string makerKanaName,string goodsNo,string goodsName,string goodsNameKana,string jan,Int32 bLGoodsCode,string bLGoodsFullName,Int32 displayOrder,Int32 goodsLGroup,string goodsLGroupName,Int32 goodsMGroup,string goodsMGroupName,Int32 bLGroupCode,string bLGroupName,string goodsRateRank,Int32 taxationDivCd,string goodsNoNoneHyphen,DateTime offerDate,Int32 goodsKindCode,string goodsNote1,string goodsNote2,string goodsSpecialNote,Int32 enterpriseGanreCode,string enterpriseGanreName,DateTime updateDate,Int32 goodsRateGrpCode,string goodsRateGrpName,Int32 salesCode,string salesCodeName,Int32 supplierCd,string supplierNm1,string supplierNm2,string suppHonorificTitle,string supplierKana,string supplierSnm,Int32 stockUnPrcFrcProcCd,Int32 stockCnsTaxFrcProcCd,Int32 supplierLot,Int32 secretCode,Int32 primePartsDisplayOrder,Int32 prmSetDtlNo1,string prmSetDtlName1,Int32 prmSetDtlNo2,string prmSetDtlName2,string sectionCode,List<GoodsPrice> goodsPriceList,List<Stock> stockList,Int32 offerKubun,Int32 goodsKind,Int32 goodsKindResolved,Int32 joinDispOrder,Double joinQty,string joinSpecialNote,Int32 setDispOrder,Double setQty,string setSpecialNote,Double partsQty,Int32 offerDataDiv,string enterpriseName,string updEmployeeName,string bLGoodsName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._makerShortName = makerShortName;
			this._makerKanaName = makerKanaName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._goodsNameKana = goodsNameKana;
			this._jan = jan;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._displayOrder = displayOrder;
			this._goodsLGroup = goodsLGroup;
			this._goodsLGroupName = goodsLGroupName;
			this._goodsMGroup = goodsMGroup;
			this._goodsMGroupName = goodsMGroupName;
			this._bLGroupCode = bLGroupCode;
			this._bLGroupName = bLGroupName;
			this._goodsRateRank = goodsRateRank;
			this._taxationDivCd = taxationDivCd;
			this._goodsNoNoneHyphen = goodsNoNoneHyphen;
			this._offerDate = offerDate;
			this._goodsKindCode = goodsKindCode;
			this._goodsNote1 = goodsNote1;
			this._goodsNote2 = goodsNote2;
			this._goodsSpecialNote = goodsSpecialNote;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this.UpdateDate = updateDate;
			this._goodsRateGrpCode = goodsRateGrpCode;
			this._goodsRateGrpName = goodsRateGrpName;
			this._salesCode = salesCode;
			this._salesCodeName = salesCodeName;
			this._supplierCd = supplierCd;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._suppHonorificTitle = suppHonorificTitle;
			this._supplierKana = supplierKana;
			this._supplierSnm = supplierSnm;
			this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
			this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
			this._supplierLot = supplierLot;
			this._secretCode = secretCode;
			this._primePartsDisplayOrder = primePartsDisplayOrder;
			this._prmSetDtlNo1 = prmSetDtlNo1;
			this._prmSetDtlName1 = prmSetDtlName1;
			this._prmSetDtlNo2 = prmSetDtlNo2;
			this._prmSetDtlName2 = prmSetDtlName2;
			this._sectionCode = sectionCode;
			this._goodsPriceList = goodsPriceList;
			this._stockList = stockList;
			this._offerKubun = offerKubun;
			this._goodsKind = goodsKind;
			this._goodsKindResolved = goodsKindResolved;
			this._joinDispOrder = joinDispOrder;
			this._joinQty = joinQty;
			this._joinSpecialNote = joinSpecialNote;
			this._setDispOrder = setDispOrder;
			this._setQty = setQty;
			this._setSpecialNote = setSpecialNote;
			this._partsQty = partsQty;
			this._offerDataDiv = offerDataDiv;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// ���i�A���f�[�^�N���X��������
		/// </summary>
		/// <returns>GoodsUnitData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsUnitData�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsUnitData Clone()
		{
			return new GoodsUnitData(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._goodsMakerCd,this._makerName,this._makerShortName,this._makerKanaName,this._goodsNo,this._goodsName,this._goodsNameKana,this._jan,this._bLGoodsCode,this._bLGoodsFullName,this._displayOrder,this._goodsLGroup,this._goodsLGroupName,this._goodsMGroup,this._goodsMGroupName,this._bLGroupCode,this._bLGroupName,this._goodsRateRank,this._taxationDivCd,this._goodsNoNoneHyphen,this._offerDate,this._goodsKindCode,this._goodsNote1,this._goodsNote2,this._goodsSpecialNote,this._enterpriseGanreCode,this._enterpriseGanreName,this._updateDate,this._goodsRateGrpCode,this._goodsRateGrpName,this._salesCode,this._salesCodeName,this._supplierCd,this._supplierNm1,this._supplierNm2,this._suppHonorificTitle,this._supplierKana,this._supplierSnm,this._stockUnPrcFrcProcCd,this._stockCnsTaxFrcProcCd,this._supplierLot,this._secretCode,this._primePartsDisplayOrder,this._prmSetDtlNo1,this._prmSetDtlName1,this._prmSetDtlNo2,this._prmSetDtlName2,this._sectionCode,this._goodsPriceList,this._stockList,this._offerKubun,this._goodsKind,this._goodsKindResolved,this._joinDispOrder,this._joinQty,this._joinSpecialNote,this._setDispOrder,this._setQty,this._setSpecialNote,this._partsQty,this._offerDataDiv,this._enterpriseName,this._updEmployeeName,this._bLGoodsName);
		}

		/// <summary>
		/// ���i�A���f�[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�GoodsUnitData�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(GoodsUnitData target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.MakerShortName == target.MakerShortName)
				 && (this.MakerKanaName == target.MakerKanaName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.Jan == target.Jan)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.GoodsLGroup == target.GoodsLGroup)
				 && (this.GoodsLGroupName == target.GoodsLGroupName)
				 && (this.GoodsMGroup == target.GoodsMGroup)
				 && (this.GoodsMGroupName == target.GoodsMGroupName)
				 && (this.BLGroupCode == target.BLGroupCode)
				 && (this.BLGroupName == target.BLGroupName)
				 && (this.GoodsRateRank == target.GoodsRateRank)
				 && (this.TaxationDivCd == target.TaxationDivCd)
				 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
				 && (this.OfferDate == target.OfferDate)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsNote1 == target.GoodsNote1)
				 && (this.GoodsNote2 == target.GoodsNote2)
				 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
				 && (this.GoodsRateGrpName == target.GoodsRateGrpName)
				 && (this.SalesCode == target.SalesCode)
				 && (this.SalesCodeName == target.SalesCodeName)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SuppHonorificTitle == target.SuppHonorificTitle)
				 && (this.SupplierKana == target.SupplierKana)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
				 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
				 && (this.SupplierLot == target.SupplierLot)
				 && (this.SecretCode == target.SecretCode)
				 && (this.PrimePartsDisplayOrder == target.PrimePartsDisplayOrder)
				 && (this.PrmSetDtlNo1 == target.PrmSetDtlNo1)
				 && (this.PrmSetDtlName1 == target.PrmSetDtlName1)
				 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
				 && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
				 && (this.SectionCode == target.SectionCode)
                 //&& (this.GoodsPriceList == target.GoodsPriceList)
                 //&& (this.StockList == target.StockList)
				 && (this.OfferKubun == target.OfferKubun)
				 && (this.GoodsKind == target.GoodsKind)
				 && (this.GoodsKindResolved == target.GoodsKindResolved)
				 && (this.JoinDispOrder == target.JoinDispOrder)
				 && (this.JoinQty == target.JoinQty)
				 && (this.JoinSpecialNote == target.JoinSpecialNote)
				 && (this.SetDispOrder == target.SetDispOrder)
				 && (this.SetQty == target.SetQty)
				 && (this.SetSpecialNote == target.SetSpecialNote)
				 && (this.PartsQty == target.PartsQty)
				 && (this.OfferDataDiv == target.OfferDataDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.BLGoodsName == target.BLGoodsName)
                 && (EqualsGoodsPriceList( this.GoodsPriceList, target.GoodsPriceList )));
		}

		/// <summary>
		/// ���i�A���f�[�^�N���X��r����
		/// </summary>
		/// <param name="goodsUnitData1">
		///                    ��r����GoodsUnitData�N���X�̃C���X�^���X
		/// </param>
		/// <param name="goodsUnitData2">��r����GoodsUnitData�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
		{
            return ((goodsUnitData1.CreateDateTime == goodsUnitData2.CreateDateTime)
                 && (goodsUnitData1.UpdateDateTime == goodsUnitData2.UpdateDateTime)
                 && (goodsUnitData1.EnterpriseCode == goodsUnitData2.EnterpriseCode)
                 && (goodsUnitData1.FileHeaderGuid == goodsUnitData2.FileHeaderGuid)
                 && (goodsUnitData1.UpdEmployeeCode == goodsUnitData2.UpdEmployeeCode)
                 && (goodsUnitData1.UpdAssemblyId1 == goodsUnitData2.UpdAssemblyId1)
                 && (goodsUnitData1.UpdAssemblyId2 == goodsUnitData2.UpdAssemblyId2)
                 && (goodsUnitData1.LogicalDeleteCode == goodsUnitData2.LogicalDeleteCode)
                 && (goodsUnitData1.GoodsMakerCd == goodsUnitData2.GoodsMakerCd)
                 && (goodsUnitData1.MakerName == goodsUnitData2.MakerName)
                 && (goodsUnitData1.MakerShortName == goodsUnitData2.MakerShortName)
                 && (goodsUnitData1.MakerKanaName == goodsUnitData2.MakerKanaName)
                 && (goodsUnitData1.GoodsNo == goodsUnitData2.GoodsNo)
                 && (goodsUnitData1.GoodsName == goodsUnitData2.GoodsName)
                 && (goodsUnitData1.GoodsNameKana == goodsUnitData2.GoodsNameKana)
                 && (goodsUnitData1.Jan == goodsUnitData2.Jan)
                 && (goodsUnitData1.BLGoodsCode == goodsUnitData2.BLGoodsCode)
                 && (goodsUnitData1.BLGoodsFullName == goodsUnitData2.BLGoodsFullName)
                 && (goodsUnitData1.DisplayOrder == goodsUnitData2.DisplayOrder)
                 && (goodsUnitData1.GoodsLGroup == goodsUnitData2.GoodsLGroup)
                 && (goodsUnitData1.GoodsLGroupName == goodsUnitData2.GoodsLGroupName)
                 && (goodsUnitData1.GoodsMGroup == goodsUnitData2.GoodsMGroup)
                 && (goodsUnitData1.GoodsMGroupName == goodsUnitData2.GoodsMGroupName)
                 && (goodsUnitData1.BLGroupCode == goodsUnitData2.BLGroupCode)
                 && (goodsUnitData1.BLGroupName == goodsUnitData2.BLGroupName)
                 && (goodsUnitData1.GoodsRateRank == goodsUnitData2.GoodsRateRank)
                 && (goodsUnitData1.TaxationDivCd == goodsUnitData2.TaxationDivCd)
                 && (goodsUnitData1.GoodsNoNoneHyphen == goodsUnitData2.GoodsNoNoneHyphen)
                 && (goodsUnitData1.OfferDate == goodsUnitData2.OfferDate)
                 && (goodsUnitData1.GoodsKindCode == goodsUnitData2.GoodsKindCode)
                 && (goodsUnitData1.GoodsNote1 == goodsUnitData2.GoodsNote1)
                 && (goodsUnitData1.GoodsNote2 == goodsUnitData2.GoodsNote2)
                 && (goodsUnitData1.GoodsSpecialNote == goodsUnitData2.GoodsSpecialNote)
                 && (goodsUnitData1.EnterpriseGanreCode == goodsUnitData2.EnterpriseGanreCode)
                 && (goodsUnitData1.EnterpriseGanreName == goodsUnitData2.EnterpriseGanreName)
                 && (goodsUnitData1.UpdateDate == goodsUnitData2.UpdateDate)
                 && (goodsUnitData1.GoodsRateGrpCode == goodsUnitData2.GoodsRateGrpCode)
                 && (goodsUnitData1.GoodsRateGrpName == goodsUnitData2.GoodsRateGrpName)
                 && (goodsUnitData1.SalesCode == goodsUnitData2.SalesCode)
                 && (goodsUnitData1.SalesCodeName == goodsUnitData2.SalesCodeName)
                 && (goodsUnitData1.SupplierCd == goodsUnitData2.SupplierCd)
                 && (goodsUnitData1.SupplierNm1 == goodsUnitData2.SupplierNm1)
                 && (goodsUnitData1.SupplierNm2 == goodsUnitData2.SupplierNm2)
                 && (goodsUnitData1.SuppHonorificTitle == goodsUnitData2.SuppHonorificTitle)
                 && (goodsUnitData1.SupplierKana == goodsUnitData2.SupplierKana)
                 && (goodsUnitData1.SupplierSnm == goodsUnitData2.SupplierSnm)
                 && (goodsUnitData1.StockUnPrcFrcProcCd == goodsUnitData2.StockUnPrcFrcProcCd)
                 && (goodsUnitData1.StockCnsTaxFrcProcCd == goodsUnitData2.StockCnsTaxFrcProcCd)
                 && (goodsUnitData1.SupplierLot == goodsUnitData2.SupplierLot)
                 && (goodsUnitData1.SecretCode == goodsUnitData2.SecretCode)
                 && (goodsUnitData1.PrimePartsDisplayOrder == goodsUnitData2.PrimePartsDisplayOrder)
                 && (goodsUnitData1.PrmSetDtlNo1 == goodsUnitData2.PrmSetDtlNo1)
                 && (goodsUnitData1.PrmSetDtlName1 == goodsUnitData2.PrmSetDtlName1)
                 && (goodsUnitData1.PrmSetDtlNo2 == goodsUnitData2.PrmSetDtlNo2)
                 && (goodsUnitData1.PrmSetDtlName2 == goodsUnitData2.PrmSetDtlName2)
                 && (goodsUnitData1.SectionCode == goodsUnitData2.SectionCode)
                 //&& (goodsUnitData1.GoodsPriceList == goodsUnitData2.GoodsPriceList)
                 //&& (goodsUnitData1.StockList == goodsUnitData2.StockList)
                 && (goodsUnitData1.OfferKubun == goodsUnitData2.OfferKubun)
                 && (goodsUnitData1.GoodsKind == goodsUnitData2.GoodsKind)
                 && (goodsUnitData1.GoodsKindResolved == goodsUnitData2.GoodsKindResolved)
                 && (goodsUnitData1.JoinDispOrder == goodsUnitData2.JoinDispOrder)
                 && (goodsUnitData1.JoinQty == goodsUnitData2.JoinQty)
                 && (goodsUnitData1.JoinSpecialNote == goodsUnitData2.JoinSpecialNote)
                 && (goodsUnitData1.SetDispOrder == goodsUnitData2.SetDispOrder)
                 && (goodsUnitData1.SetQty == goodsUnitData2.SetQty)
                 && (goodsUnitData1.SetSpecialNote == goodsUnitData2.SetSpecialNote)
                 && (goodsUnitData1.PartsQty == goodsUnitData2.PartsQty)
                 && (goodsUnitData1.OfferDataDiv == goodsUnitData2.OfferDataDiv)
                 && (goodsUnitData1.EnterpriseName == goodsUnitData2.EnterpriseName)
                 && (goodsUnitData1.UpdEmployeeName == goodsUnitData2.UpdEmployeeName)
                 && (goodsUnitData1.BLGoodsName == goodsUnitData2.BLGoodsName)
                 && (EqualsGoodsPriceList( goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList )));
		}
		/// <summary>
		/// ���i�A���f�[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�GoodsUnitData�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(GoodsUnitData target)
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
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.MakerShortName != target.MakerShortName)resList.Add("MakerShortName");
			if(this.MakerKanaName != target.MakerKanaName)resList.Add("MakerKanaName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.Jan != target.Jan)resList.Add("Jan");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.GoodsLGroup != target.GoodsLGroup)resList.Add("GoodsLGroup");
			if(this.GoodsLGroupName != target.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(this.GoodsMGroup != target.GoodsMGroup)resList.Add("GoodsMGroup");
			if(this.GoodsMGroupName != target.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(this.BLGroupCode != target.BLGroupCode)resList.Add("BLGroupCode");
			if(this.BLGroupName != target.BLGroupName)resList.Add("BLGroupName");
			if(this.GoodsRateRank != target.GoodsRateRank)resList.Add("GoodsRateRank");
			if(this.TaxationDivCd != target.TaxationDivCd)resList.Add("TaxationDivCd");
			if(this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen)resList.Add("GoodsNoNoneHyphen");
			if(this.OfferDate != target.OfferDate)resList.Add("OfferDate");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsNote1 != target.GoodsNote1)resList.Add("GoodsNote1");
			if(this.GoodsNote2 != target.GoodsNote2)resList.Add("GoodsNote2");
			if(this.GoodsSpecialNote != target.GoodsSpecialNote)resList.Add("GoodsSpecialNote");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(this.GoodsRateGrpName != target.GoodsRateGrpName)resList.Add("GoodsRateGrpName");
			if(this.SalesCode != target.SalesCode)resList.Add("SalesCode");
			if(this.SalesCodeName != target.SalesCodeName)resList.Add("SalesCodeName");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SuppHonorificTitle != target.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(this.SupplierKana != target.SupplierKana)resList.Add("SupplierKana");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(this.SupplierLot != target.SupplierLot)resList.Add("SupplierLot");
			if(this.SecretCode != target.SecretCode)resList.Add("SecretCode");
			if(this.PrimePartsDisplayOrder != target.PrimePartsDisplayOrder)resList.Add("PrimePartsDisplayOrder");
			if(this.PrmSetDtlNo1 != target.PrmSetDtlNo1)resList.Add("PrmSetDtlNo1");
			if(this.PrmSetDtlName1 != target.PrmSetDtlName1)resList.Add("PrmSetDtlName1");
			if(this.PrmSetDtlNo2 != target.PrmSetDtlNo2)resList.Add("PrmSetDtlNo2");
			if(this.PrmSetDtlName2 != target.PrmSetDtlName2)resList.Add("PrmSetDtlName2");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
            //if(this.GoodsPriceList != target.GoodsPriceList)resList.Add("GoodsPriceList");
            //if(this.StockList != target.StockList)resList.Add("StockList");
			if(this.OfferKubun != target.OfferKubun)resList.Add("OfferKubun");
			if(this.GoodsKind != target.GoodsKind)resList.Add("GoodsKind");
			if(this.GoodsKindResolved != target.GoodsKindResolved)resList.Add("GoodsKindResolved");
			if(this.JoinDispOrder != target.JoinDispOrder)resList.Add("JoinDispOrder");
			if(this.JoinQty != target.JoinQty)resList.Add("JoinQty");
			if(this.JoinSpecialNote != target.JoinSpecialNote)resList.Add("JoinSpecialNote");
			if(this.SetDispOrder != target.SetDispOrder)resList.Add("SetDispOrder");
			if(this.SetQty != target.SetQty)resList.Add("SetQty");
			if(this.SetSpecialNote != target.SetSpecialNote)resList.Add("SetSpecialNote");
			if(this.PartsQty != target.PartsQty)resList.Add("PartsQty");
			if(this.OfferDataDiv != target.OfferDataDiv)resList.Add("OfferDataDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            if ( !EqualsGoodsPriceList( this.GoodsPriceList, target.GoodsPriceList ) ) resList.Add( "GoodsPriceList" );

			return resList;
		}

		/// <summary>
		/// ���i�A���f�[�^�N���X��r����
		/// </summary>
		/// <param name="goodsUnitData1">��r����GoodsUnitData�N���X�̃C���X�^���X</param>
		/// <param name="goodsUnitData2">��r����GoodsUnitData�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
		{
			ArrayList resList = new ArrayList();
			if(goodsUnitData1.CreateDateTime != goodsUnitData2.CreateDateTime)resList.Add("CreateDateTime");
			if(goodsUnitData1.UpdateDateTime != goodsUnitData2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(goodsUnitData1.EnterpriseCode != goodsUnitData2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(goodsUnitData1.FileHeaderGuid != goodsUnitData2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(goodsUnitData1.UpdEmployeeCode != goodsUnitData2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(goodsUnitData1.UpdAssemblyId1 != goodsUnitData2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(goodsUnitData1.UpdAssemblyId2 != goodsUnitData2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(goodsUnitData1.LogicalDeleteCode != goodsUnitData2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(goodsUnitData1.GoodsMakerCd != goodsUnitData2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(goodsUnitData1.MakerName != goodsUnitData2.MakerName)resList.Add("MakerName");
			if(goodsUnitData1.MakerShortName != goodsUnitData2.MakerShortName)resList.Add("MakerShortName");
			if(goodsUnitData1.MakerKanaName != goodsUnitData2.MakerKanaName)resList.Add("MakerKanaName");
			if(goodsUnitData1.GoodsNo != goodsUnitData2.GoodsNo)resList.Add("GoodsNo");
			if(goodsUnitData1.GoodsName != goodsUnitData2.GoodsName)resList.Add("GoodsName");
			if(goodsUnitData1.GoodsNameKana != goodsUnitData2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(goodsUnitData1.Jan != goodsUnitData2.Jan)resList.Add("Jan");
			if(goodsUnitData1.BLGoodsCode != goodsUnitData2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(goodsUnitData1.BLGoodsFullName != goodsUnitData2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(goodsUnitData1.DisplayOrder != goodsUnitData2.DisplayOrder)resList.Add("DisplayOrder");
			if(goodsUnitData1.GoodsLGroup != goodsUnitData2.GoodsLGroup)resList.Add("GoodsLGroup");
			if(goodsUnitData1.GoodsLGroupName != goodsUnitData2.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(goodsUnitData1.GoodsMGroup != goodsUnitData2.GoodsMGroup)resList.Add("GoodsMGroup");
			if(goodsUnitData1.GoodsMGroupName != goodsUnitData2.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(goodsUnitData1.BLGroupCode != goodsUnitData2.BLGroupCode)resList.Add("BLGroupCode");
			if(goodsUnitData1.BLGroupName != goodsUnitData2.BLGroupName)resList.Add("BLGroupName");
			if(goodsUnitData1.GoodsRateRank != goodsUnitData2.GoodsRateRank)resList.Add("GoodsRateRank");
			if(goodsUnitData1.TaxationDivCd != goodsUnitData2.TaxationDivCd)resList.Add("TaxationDivCd");
			if(goodsUnitData1.GoodsNoNoneHyphen != goodsUnitData2.GoodsNoNoneHyphen)resList.Add("GoodsNoNoneHyphen");
			if(goodsUnitData1.OfferDate != goodsUnitData2.OfferDate)resList.Add("OfferDate");
			if(goodsUnitData1.GoodsKindCode != goodsUnitData2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(goodsUnitData1.GoodsNote1 != goodsUnitData2.GoodsNote1)resList.Add("GoodsNote1");
			if(goodsUnitData1.GoodsNote2 != goodsUnitData2.GoodsNote2)resList.Add("GoodsNote2");
			if(goodsUnitData1.GoodsSpecialNote != goodsUnitData2.GoodsSpecialNote)resList.Add("GoodsSpecialNote");
			if(goodsUnitData1.EnterpriseGanreCode != goodsUnitData2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(goodsUnitData1.EnterpriseGanreName != goodsUnitData2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(goodsUnitData1.UpdateDate != goodsUnitData2.UpdateDate)resList.Add("UpdateDate");
			if(goodsUnitData1.GoodsRateGrpCode != goodsUnitData2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(goodsUnitData1.GoodsRateGrpName != goodsUnitData2.GoodsRateGrpName)resList.Add("GoodsRateGrpName");
			if(goodsUnitData1.SalesCode != goodsUnitData2.SalesCode)resList.Add("SalesCode");
			if(goodsUnitData1.SalesCodeName != goodsUnitData2.SalesCodeName)resList.Add("SalesCodeName");
			if(goodsUnitData1.SupplierCd != goodsUnitData2.SupplierCd)resList.Add("SupplierCd");
			if(goodsUnitData1.SupplierNm1 != goodsUnitData2.SupplierNm1)resList.Add("SupplierNm1");
			if(goodsUnitData1.SupplierNm2 != goodsUnitData2.SupplierNm2)resList.Add("SupplierNm2");
			if(goodsUnitData1.SuppHonorificTitle != goodsUnitData2.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(goodsUnitData1.SupplierKana != goodsUnitData2.SupplierKana)resList.Add("SupplierKana");
			if(goodsUnitData1.SupplierSnm != goodsUnitData2.SupplierSnm)resList.Add("SupplierSnm");
			if(goodsUnitData1.StockUnPrcFrcProcCd != goodsUnitData2.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(goodsUnitData1.StockCnsTaxFrcProcCd != goodsUnitData2.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(goodsUnitData1.SupplierLot != goodsUnitData2.SupplierLot)resList.Add("SupplierLot");
			if(goodsUnitData1.SecretCode != goodsUnitData2.SecretCode)resList.Add("SecretCode");
			if(goodsUnitData1.PrimePartsDisplayOrder != goodsUnitData2.PrimePartsDisplayOrder)resList.Add("PrimePartsDisplayOrder");
			if(goodsUnitData1.PrmSetDtlNo1 != goodsUnitData2.PrmSetDtlNo1)resList.Add("PrmSetDtlNo1");
			if(goodsUnitData1.PrmSetDtlName1 != goodsUnitData2.PrmSetDtlName1)resList.Add("PrmSetDtlName1");
			if(goodsUnitData1.PrmSetDtlNo2 != goodsUnitData2.PrmSetDtlNo2)resList.Add("PrmSetDtlNo2");
			if(goodsUnitData1.PrmSetDtlName2 != goodsUnitData2.PrmSetDtlName2)resList.Add("PrmSetDtlName2");
			if(goodsUnitData1.SectionCode != goodsUnitData2.SectionCode)resList.Add("SectionCode");
            //if(goodsUnitData1.GoodsPriceList != goodsUnitData2.GoodsPriceList)resList.Add("GoodsPriceList");
            //if(goodsUnitData1.StockList != goodsUnitData2.StockList)resList.Add("StockList");
			if(goodsUnitData1.OfferKubun != goodsUnitData2.OfferKubun)resList.Add("OfferKubun");
			if(goodsUnitData1.GoodsKind != goodsUnitData2.GoodsKind)resList.Add("GoodsKind");
			if(goodsUnitData1.GoodsKindResolved != goodsUnitData2.GoodsKindResolved)resList.Add("GoodsKindResolved");
			if(goodsUnitData1.JoinDispOrder != goodsUnitData2.JoinDispOrder)resList.Add("JoinDispOrder");
			if(goodsUnitData1.JoinQty != goodsUnitData2.JoinQty)resList.Add("JoinQty");
			if(goodsUnitData1.JoinSpecialNote != goodsUnitData2.JoinSpecialNote)resList.Add("JoinSpecialNote");
			if(goodsUnitData1.SetDispOrder != goodsUnitData2.SetDispOrder)resList.Add("SetDispOrder");
			if(goodsUnitData1.SetQty != goodsUnitData2.SetQty)resList.Add("SetQty");
			if(goodsUnitData1.SetSpecialNote != goodsUnitData2.SetSpecialNote)resList.Add("SetSpecialNote");
			if(goodsUnitData1.PartsQty != goodsUnitData2.PartsQty)resList.Add("PartsQty");
			if(goodsUnitData1.OfferDataDiv != goodsUnitData2.OfferDataDiv)resList.Add("OfferDataDiv");
			if(goodsUnitData1.EnterpriseName != goodsUnitData2.EnterpriseName)resList.Add("EnterpriseName");
			if(goodsUnitData1.UpdEmployeeName != goodsUnitData2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(goodsUnitData1.BLGoodsName != goodsUnitData2.BLGoodsName)resList.Add("BLGoodsName");
            if ( !EqualsGoodsPriceList( goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList ) ) resList.Add( "GoodsPriceList" );

			return resList;
		}
        /// <summary>
        /// ���i����r����
        /// </summary>
        /// <param name="hashtable"></param>
        /// <param name="hashtable_2"></param>
        /// <returns></returns>
        private static bool EqualsGoodsPriceList(List<GoodsPrice> list, List<GoodsPrice> list2)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
            //if ((list != null) && (list.Count != 0) && (list2 != null) && (list2.Count != 0))
            //{
            //    list.Sort();
            //    foreach (GoodsPrice goodsPrice in list)
            //    {
            //        // Find�ŕi�ԁE���[�J�[�E���i�J�n�����������i�����擾����
            //        GoodsPrice goodsPrice2 = list2.Find(
            //            delegate (GoodsPrice data)
            //            {
            //                return ((goodsPrice.GoodsNo == data.GoodsNo) &&
            //                    (goodsPrice.GoodsMakerCd == data.GoodsMakerCd) &&
            //                    (goodsPrice.PriceStartDate == data.PriceStartDate));
            //            }
            //            );

            //        // �擾�������i�����r
            //        if (goodsPrice2 == null) break;
            //        if (!goodsPrice.Equals(goodsPrice2)) return false;
            //    }
            //}
            //return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // ����null�Ȃ�OK
            if ( list == null && list2 == null ) return true;
            // �Е�null�Ȃ�NG
            if ( list != null && list2 == null ) return false;
            if ( list == null && list2 != null ) return false;
            // �v�f���Ⴂ��NG
            if ( list.Count != list2.Count ) return false;

            // list�x�[�X�ŊY������list2�̃��R�[�h��T��
            foreach ( GoodsPrice price in list )
            {
                GoodsPrice price2 = list2.Find(
                    delegate( GoodsPrice target )
                    {
                        return ((price.GoodsNo == target.GoodsNo) &&
                                (price.GoodsMakerCd == target.GoodsMakerCd) &&
                                (price.PriceStartDate == target.PriceStartDate));
                    } 
                    );
                if ( price2 == null ) return false;

                // ���i�N���X��r
                ArrayList priceComparelist = price.Compare( price2 );
                int differCount = priceComparelist.Count;
                if ( priceComparelist.Contains( "CreateDateTime" ) ) differCount--;
                if ( priceComparelist.Contains( "UpdateDateTime" ) ) differCount--;
                if ( priceComparelist.Contains( "UpdateDate" ) ) differCount--;
                if ( differCount > 0 ) return false;
            }

            // �v�f���������Ȃ̂�list�x�[�X�őS�ĊY������΋t�̑��������Ȃ��Ă�OK
            return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
        }
	}
# endif

    /// public class name:   GoodsUnitData
    /// <summary>
    ///                      ���i�A���f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�A���f�[�^�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/06/12</br>
    /// <br>Genarated Date   :   2008/11/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// <br>Update Note      :   2009/10/19 ������</br>
    /// <br>                     PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>                     �ێ�˗��A��ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2009/11/24�@21024 ���X�� ��</br>
    /// <br>                     ����BL�R�[�h��ǉ�(MANTIS[0014674])</br>
    /// <br></br>
    /// <br>Update Note      :   2010/03/02�@21024 ���X�� ��</br>
    /// <br>                     �ϊ�BL�R�[�h�̒ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2010/06/10�@22018 ��� ���b</br>
    /// <br>                     ���R�������i�ŗL�ԍ��̒ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2014/01/15 �{�{ ����</br>
    /// <br>                     ���������̒ǉ�</br>
    /// <br>Update Note      :   2014/02/10 ���z</br>
    /// <br>                 :   Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2015/01/07 30744 ���� ����q</br>
    /// <br>                     ���[�J�[��]�������i�Ή�</br>
    /// <br></br>
    /// <br>Update Note      :   2015/02/25 30744 ���� ����q</br>
    /// <br>                     SCM������ C������ʑΉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2015/03/18 30744 ���� ����q</br>
    /// <br>                     SCM���������[�J�[��]�������i�Ή� 2015/01/07�Ή������O</br>
    /// <br></br>
    /// </remarks>
    public class GoodsUnitData
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

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�}�X�^���擾</remarks>
        private string _makerName = "";

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�}�X�^���擾</remarks>
        private string _makerShortName = "";

        /// <summary>���[�J�[�J�i����</summary>
        /// <remarks>���[�J�}�X�^���擾</remarks>
        private string _makerKanaName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        /// <remarks>�����p�J�i</remarks>
        private string _goodsNameKana = "";

        /// <summary>JAN�R�[�h</summary>
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
        private string _jan = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        /// <remarks>BL���i�R�[�h�}�X�^���擾</remarks>
        private string _bLGoodsFullName = "";

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>BL�O���[�v�}�X�^���擾</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���</summary>
        /// <remarks>���[�U�[�K�C�h���擾</remarks>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>BL�O���[�v�}�X�^���擾</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���</summary>
        /// <remarks>���i�����ރ}�X�^���擾</remarks>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>BL�R�[�h�}�X�^���擾</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        /// <remarks>BL�O���[�v�}�X�^���擾</remarks>
        private string _bLGroupName = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>�񋟓��t</summary>
        private DateTime _offerDate;

        /// <summary>���i����</summary>
        private Int32 _goodsKindCode;

        /// <summary>���i���l�P</summary>
        private string _goodsNote1 = "";

        /// <summary>���i���l�Q</summary>
        private string _goodsNote2 = "";

        /// <summary>���i�K�i�E���L����</summary>
        private string _goodsSpecialNote = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        /// <remarks>���[�U�[�K�C�h���擾</remarks>
        private string _enterpriseGanreName = "";

        /// <summary>�X�V�N����</summary>
        private DateTime _updateDate;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>BL�R�[�h�}�X�^���擾</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>���i�|���O���[�v�R�[�h����</summary>
        /// <remarks>���i�����ރ}�X�^���擾</remarks>
        private string _goodsRateGrpName = "";

        /// <summary>�̔��敪�R�[�h</summary>
        /// <remarks>BL�O���[�v�}�X�^���擾</remarks>
        private Int32 _salesCode;

        /// <summary>�̔��敪����</summary>
        /// <remarks>���[�U�[�K�C�h���擾</remarks>
        private string _salesCodeName = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>���i�Ǘ����}�X�^���擾</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private string _supplierNm2 = "";

        /// <summary>�d����h��</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private string _suppHonorificTitle = "";

        /// <summary>�d����J�i</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private string _supplierKana = "";

        /// <summary>�d���旪��</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private string _supplierSnm = "";

        /// <summary>�d���P���[�������R�[�h</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>�d������Œ[�������R�[�h</summary>
        /// <remarks>�d����}�X�^���擾</remarks>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>�������b�g</summary>
        /// <remarks>���i�Ǘ����}�X�^���擾</remarks>
        private Int32 _supplierLot;

        /// <summary>�V�[�N���b�g�敪</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾�@0:�ʏ�@1:�V�[�N���b�g</remarks>
        private Int32 _secretCode;

        /// <summary>�\������</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
        private Int32 _primePartsDisplayOrder;

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾�@�Z���N�g�R�[�h</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>�D�ǐݒ�ڍז��̂P</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
        private string _prmSetDtlName1 = "";

        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾�@��ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
        private string _prmSetDtlName2 = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���i�Ǘ����}�X�^�擾�Ŏg�p</remarks>
        private string _sectionCode = "";

        /// <summary>���i���</summary>
        /// <remarks></remarks>
        private List<GoodsPrice> _goodsPriceList;

        /// <summary>�݌ɏ��</summary>
        /// <remarks></remarks>
        private List<Stock> _stockList;

        /// <summary>�񋟋敪</summary>
        /// <remarks>0:���[�U�[�o�^,1:�񋟏����ҏW,2:�񋟗D�ǕҏW,3:�񋟏���,4:�񋟗D��,5:TBO,7:�I���W�i�����i</remarks>
        private Int32 _offerKubun;

        /// <summary>���i���(��������)</summary>
        /// <remarks>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</remarks>
        private Int32 _goodsKind;

        /// <summary>���i���(�����Ȃ�)</summary>
        /// <remarks>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</remarks>
        private Int32 _goodsKindResolved;

        /// <summary>�����\������</summary>
        private Int32 _joinDispOrder;

        /// <summary>����QTY</summary>
        private Double _joinQty;

        /// <summary>�����K�i�E���L����</summary>
        private string _joinSpecialNote = "";

        /// <summary>�Z�b�g�\������</summary>
        private Int32 _setDispOrder;

        /// <summary>�Z�b�gQTY</summary>
        private Double _setQty;

        /// <summary>�Z�b�g�K�i�E���L����</summary>
        private string _setSpecialNote = "";

        /// <summary>���iQTY</summary>
        private Double _partsQty;

        /// <summary>�񋟃f�[�^�敪</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;

        /// <summary>�I��q�ɃR�[�h</summary>
        /// <remarks>�t�h�I�����ꂽ�݌ɂ̑q�ɃR�[�h�i���ʁj</remarks>
        private string _selectedWarehouseCode = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        //-------ADD 2009/10/19--------->>>>>
        /// <summary>�艿(�I��)</summary>
        private Double _selectedListPrice;

        /// <summary>�W�����i�I��L���敪</summary>
        private Int32 _selectedListPriceDiv;

        /// <summary>����p�i��</summary>
        private string _prtGoodsNo;

        /// <summary>����p���[�J�[�R�[�h</summary>
        private Int32 _prtMakerCode;

        /// <summary>����p���[�J�[����</summary>
        private string _prtMakerName;

        /// <summary>����p�i�ԗL���敪</summary>
        private Int32 _selectedGoodsNoDiv;
        //-------ADD 2009/10/19---------<<<<<

        // 2009/11/24 Add >>>
        /// <summary>����BL�R�[�h</summary>
        private Int32 _searchBLCode;
        // 2009/11/24 Add <<<

        // 2010/03/02 Add >>>
        /// <summary>�ϊ�BL�R�[�h</summary>
        /// <remarks>�ϊ���BL�R�[�h(SCM�Ŏg�p)</remarks>
        private Int32 _bLGoodsCodeChange;
        // 2010/03/02 Add <<<

        // --- ADD m.suzuki 2010/06/10 ---------->>>>>
        /// <summary>���R�������i�ŗL�ԍ�</summary>
        private string _freSrchPrtPropNo = "";
        // --- ADD m.suzuki 2010/06/10 ----------<<<<<

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>���������i���[�J�[�R�[�h</summary>
        private Int32 _joinSourceMakerCode;
        /// <summary>���������i�ԍ�</summary>
        private string _joinSrcPartsNoWithH = "";
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        // -------- ADD START 2014/02/10 ���z -------->>>>>
        /// <summary>���i�}�X�^�\���p�I�v�V����</summary>
        private Int32 _optKonmanGoodsMstCtl;

        /// <summary>�K�i</summary>
        private string _standard = "";

        /// <summary>�׎p</summary>
        private string _packing = "";

        /// <summary>�o�n�rNo.</summary>
        private string _posNo = "";

        /// <summary>���[�J�[�i��</summary>
        private string _makerGoodsNo = "";

        /// <summary>�쐬�����U</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTimeA;

        /// <summary>�X�V�����U</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTimeA;

        /// <summary>GUID�U</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuidA;
        // -------- ADD END 2014/02/10 ���z --------<<<<<

        // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        //// ADD 2015/01/07 ���[�J�[��]�������i�Ή� --------------------->>>>>
        ///// <summary>���[�J�[��]�������i���</summary>
        ///// <remarks></remarks>
        //private List<GoodsPrice> _mkrSuggestRtPricList;
        //// ADD 2015/01/07 ���[�J�[��]�������i�Ή� ---------------------<<<<<
        // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        // ADD 2015/02/25 SCM������ C������ʑΉ� -------------------------->>>>>
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)</summary>
        private string _prmSetDtlName2ForFac = "";
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</summary>
        private string _prmSetDtlName2ForCOw = "";
        // ADD 2015/02/25 SCM������ C������ʑΉ� --------------------------<<<<<

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _createDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _createDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _createDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _createDateTime ); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDateTime ); }
            set { }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>���[�J�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>���[�J�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  MakerKanaName
        /// <summary>���[�J�[�J�i���̃v���p�e�B</summary>
        /// <value>���[�J�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set { _makerKanaName = value; }
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
            get { return _goodsNo; }
            set { _goodsNo = value; }
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
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// <value>�����p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
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
            get { return _jan; }
            set { _jan = value; }
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
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// <value>BL���i�R�[�h�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
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
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>BL�O���[�v�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>BL�O���[�v�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// <value>���i�����ރ}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>BL�R�[�h�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// <value>BL�O���[�v�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>���i���l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _goodsNote1; }
            set { _goodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>���i���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _goodsNote2; }
            set { _goodsNote2 = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
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
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  UpdateDateJpInFormal
        /// <summary>�X�V�N���� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdFormal
        /// <summary>�X�V�N���� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdInFormal
        /// <summary>�X�V�N���� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>BL�R�[�h�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpName
        /// <summary>���i�|���O���[�v�R�[�h���̃v���p�e�B</summary>
        /// <value>���i�����ރ}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateGrpName
        {
            get { return _goodsRateGrpName; }
            set { _goodsRateGrpName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// <value>BL�O���[�v�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCodeName
        /// <summary>�̔��敪���̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>���i�Ǘ����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於2�v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SuppHonorificTitle
        /// <summary>�d����h�̃v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>�d����J�i�v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>�d���P���[�������R�[�h�v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>�d������Œ[�������R�[�h�v���p�e�B</summary>
        /// <value>�d����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>�������b�g�v���p�e�B</summary>
        /// <value>���i�Ǘ����}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������b�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  SecretCode
        /// <summary>�V�[�N���b�g�敪�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾�@0:�ʏ�@1:�V�[�N���b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�[�N���b�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecretCode
        {
            get { return _secretCode; }
            set { _secretCode = value; }
        }

        /// public propaty name  :  PrimePartsDisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrimePartsDisplayOrder
        {
            get { return _primePartsDisplayOrder; }
            set { _primePartsDisplayOrder = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾�@�Z���N�g�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlName1
        /// <summary>�D�ǐݒ�ڍז��̂P�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName1
        {
            get { return _prmSetDtlName1; }
            set { _prmSetDtlName1 = value; }
        }

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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���i�Ǘ����}�X�^�擾�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  GoodsPriceList
        /// <summary>���i���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<GoodsPrice> GoodsPriceList
        {
            get { return _goodsPriceList; }
            set { _goodsPriceList = value; }
        }

        /// public propaty name  :  StockList
        /// <summary>�݌ɏ��v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Stock> StockList
        {
            get { return _stockList; }
            set { _stockList = value; }
        }

        /// public propaty name  :  OfferKubun
        /// <summary>�񋟋敪�v���p�e�B</summary>
        /// <value>0:���[�U�[�o�^,1:�񋟏����ҏW,2:�񋟗D�ǕҏW,3:�񋟏���,4:�񋟗D��,5:TBO,7:�I���W�i�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferKubun
        {
            get { return _offerKubun; }
            set { _offerKubun = value; }
        }

        /// public propaty name  :  GoodsKind
        /// <summary>���i���(��������)�v���p�e�B</summary>
        /// <value>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���(��������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKind
        {
            get { return _goodsKind; }
            set { _goodsKind = value; }
        }

        /// public propaty name  :  GoodsKindResolved
        /// <summary>���i���(�����Ȃ�)�v���p�e�B</summary>
        /// <value>1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���(�����Ȃ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindResolved
        {
            get { return _goodsKindResolved; }
            set { _goodsKindResolved = value; }
        }

        /// public propaty name  :  JoinDispOrder
        /// <summary>�����\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>����QTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����QTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>�����K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
        }

        /// public propaty name  :  SetDispOrder
        /// <summary>�Z�b�g�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetDispOrder
        {
            get { return _setDispOrder; }
            set { _setDispOrder = value; }
        }

        /// public propaty name  :  SetQty
        /// <summary>�Z�b�gQTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�gQTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SetQty
        {
            get { return _setQty; }
            set { _setQty = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>�Z�b�g�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  PartsQty
        /// <summary>���iQTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���iQTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// public propaty name  :  SelectedWarehouseCode
        /// <summary>�I��q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�t�h�I�����ꂽ�݌ɂ̑q�ɃR�[�h�i���ʁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelectedWarehouseCode
        {
            get { return _selectedWarehouseCode; }
            set { _selectedWarehouseCode = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        //-------------ADD 2009/10/19--------->>>>>
        /// public propaty name  :  SelectedListPrice
        /// <summary>�艿(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SelectedListPrice
        {
            get { return _selectedListPrice; }
            set { _selectedListPrice = value; }
        }

        /// public propaty name  :  SelectedListPriceDiv
        /// <summary>�W�����i�I��L���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I��L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelectedListPriceDiv
        {
            get { return _selectedListPriceDiv; }
            set { _selectedListPriceDiv = value; }
        }

        /// public propaty name  :  PrtGoodsNo
        /// <summary>����p�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtGoodsNo
        {
            get { return _prtGoodsNo; }
            set { _prtGoodsNo = value; }
        }

        /// public propaty name  :  PrtMakerCode
        /// <summary>����p���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtMakerCode
        {
            get { return _prtMakerCode; }
            set { _prtMakerCode = value; }
        }

        /// public propaty name  :  PrtMakerName
        /// <summary>����p���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtMakerName
        {
            get { return _prtMakerName; }
            set { _prtMakerName = value; }
        }

        /// public propaty name  :  SelectedGoodsNoDiv
        /// <summary>����p�i�ԗL���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�i�ԗL���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelectedGoodsNoDiv
        {
            get { return _selectedGoodsNoDiv; }
            set { _selectedGoodsNoDiv = value; }
        }
        //-------------ADD 2009/10/19---------<<<<<

        // 2009/11/24 Add >>>
        /// public propaty name  :  SearchBLCode
        /// <summary>����BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ����BL�R�[�h�v���p�e�B</br>
        /// </remarks>
        public Int32 SearchBLCode
        {
            get { return _searchBLCode; }
            set { _searchBLCode = value; }
        }
        // 2009/11/24 Add <<<

        // 2010/03/02 Add >>>
        /// public propaty name  :  BLGoodsCodeChange
        /// <summary>�ϊ�BL�R�[�h�v���p�e�B</summary>
        /// <value>�ϊ���BL�R�[�h(SCM�Ŏg�p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ�BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeChange
        {
            get { return _bLGoodsCodeChange; }
            set { _bLGoodsCodeChange = value; }
        }
        // 2010/03/02 Add <<<

        // --- ADD m.suzuki 2010/06/10 ---------->>>>>
        /// public propaty name  :  FreSrchPrtPropNo
        /// <summary>���R�������i�ŗL�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�������i�ŗL�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FreSrchPrtPropNo
        {
            get { return _freSrchPrtPropNo; }
            set { _freSrchPrtPropNo = value; }
        }
        // --- ADD m.suzuki 2010/06/10 ----------<<<<<

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>���������i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }
        /// public propaty name  :  JoinSrcPartsNoWithH
        /// <summary>���������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinSrcPartsNoWithH
        {
            get { return _joinSrcPartsNoWithH; }
            set { _joinSrcPartsNoWithH = value; }
        }
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        // -------- ADD START 2014/02/10 ���z -------->>>>>
        /// public propaty name  :  OptKonmanGoodsMstCtl
        /// <summary>���i�}�X�^�\���p�I�v�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�\���p�I�v�V�������p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OptKonmanGoodsMstCtl
        {
            get { return _optKonmanGoodsMstCtl; }
            set { _optKonmanGoodsMstCtl = value; }
        }

        /// public propaty name  :  Standard
        /// <summary>�K�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Standard
        {
            get { return _standard; }
            set { _standard = value; }
        }

        /// public propaty name  :  Packing
        /// <summary>�׎p�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �׎p�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Packing
        {
            get { return _packing; }
            set { _packing = value; }
        }

        /// public propaty name  :  PosNo
        /// <summary>�o�n�rNo.�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�n�rNo.�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PosNo
        {
            get { return _posNo; }
            set { _posNo = value; }
        }

        /// public propaty name  :  MakerGoodsNo
        /// <summary>���[�J�[�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerGoodsNo
        {
            get { return _makerGoodsNo; }
            set { _makerGoodsNo = value; }
        }

        /// public propaty name  :  CreateDateTimeA
        /// <summary>�쐬�����U�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTimeA
        {
            get { return _createDateTimeA; }
            set { _createDateTimeA = value; }
        }

        /// public propaty name  :  UpdateDateTimeA
        /// <summary>�X�V�����U�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTimeA
        {
            get { return _updateDateTimeA; }
            set { _updateDateTimeA = value; }
        }

        /// public propaty name  :  FileHeaderGuidA
        /// <summary>GUID�U�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuidA
        {
            get { return _fileHeaderGuidA; }
            set { _fileHeaderGuidA = value; }
        }
        // -------- ADD END 2014/02/10 ���z --------<<<<<

        // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        //// ADD 2015/01/07 ���[�J�[��]�������i�Ή� --------------------->>>>>
        ///// public propaty name  :  MkrSuggestRtPricList
        ///// <summary>���[�J�[��]�������i���v���p�e�B</summary>
        ///// <value></value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���[�J�[��]�������i���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public List<GoodsPrice> MkrSuggestRtPricList
        //{
        //    get { return _mkrSuggestRtPricList; }
        //    set { _mkrSuggestRtPricList = value; }
        //}
        //// ADD 2015/01/07 ���[�J�[��]�������i�Ή� ---------------------<<<<<
        // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        // ADD 2015/02/25 SCM������ C������ʑΉ� -------------------------->>>>>
        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/25 SCM������ C������ʑΉ� --------------------------<<<<<


        /// <summary>
        /// ���i�A���f�[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsUnitData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsUnitData()
        {
        }

        /// <summary>
        /// ���i�A���f�[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����(���[�J�}�X�^���擾)</param>
        /// <param name="makerShortName">���[�J�[����(���[�J�}�X�^���擾)</param>
        /// <param name="makerKanaName">���[�J�[�J�i����(���[�J�}�X�^���擾)</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsNameKana">���i���̃J�i(�����p�J�i)</param>
        /// <param name="jan">JAN�R�[�h(�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j(BL���i�R�[�h�}�X�^���擾)</param>
        /// <param name="displayOrder">�\������</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h(BL�O���[�v�}�X�^���擾)</param>
        /// <param name="goodsLGroupName">���i�啪�ޖ���(���[�U�[�K�C�h���擾)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h(BL�O���[�v�}�X�^���擾)</param>
        /// <param name="goodsMGroupName">���i�����ޖ���(���i�����ރ}�X�^���擾)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(BL�R�[�h�}�X�^���擾)</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����(BL�O���[�v�}�X�^���擾)</param>
        /// <param name="goodsRateRank">���i�|�������N(�w��)</param>
        /// <param name="taxationDivCd">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="goodsKindCode">���i����</param>
        /// <param name="goodsNote1">���i���l�P</param>
        /// <param name="goodsNote2">���i���l�Q</param>
        /// <param name="goodsSpecialNote">���i�K�i�E���L����</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <param name="enterpriseGanreName">���Е��ޖ���(���[�U�[�K�C�h���擾)</param>
        /// <param name="updateDate">�X�V�N����</param>
        /// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h(BL�R�[�h�}�X�^���擾)</param>
        /// <param name="goodsRateGrpName">���i�|���O���[�v�R�[�h����(���i�����ރ}�X�^���擾)</param>
        /// <param name="salesCode">�̔��敪�R�[�h(BL�O���[�v�}�X�^���擾)</param>
        /// <param name="salesCodeName">�̔��敪����(���[�U�[�K�C�h���擾)</param>
        /// <param name="supplierCd">�d����R�[�h(���i�Ǘ����}�X�^���擾)</param>
        /// <param name="supplierNm1">�d���於1(�d����}�X�^���擾)</param>
        /// <param name="supplierNm2">�d���於2(�d����}�X�^���擾)</param>
        /// <param name="suppHonorificTitle">�d����h��(�d����}�X�^���擾)</param>
        /// <param name="supplierKana">�d����J�i(�d����}�X�^���擾)</param>
        /// <param name="supplierSnm">�d���旪��(�d����}�X�^���擾)</param>
        /// <param name="stockUnPrcFrcProcCd">�d���P���[�������R�[�h(�d����}�X�^���擾)</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h(�d����}�X�^���擾)</param>
        /// <param name="supplierLot">�������b�g(���i�Ǘ����}�X�^���擾)</param>
        /// <param name="secretCode">�V�[�N���b�g�敪(�D�ǐݒ�}�X�^���擾�@0:�ʏ�@1:�V�[�N���b�g)</param>
        /// <param name="primePartsDisplayOrder">�\������(�D�ǐݒ�}�X�^���擾)</param>
        /// <param name="prmSetDtlNo1">�D�ǐݒ�ڍ׃R�[�h�P(�D�ǐݒ�}�X�^���擾�@�Z���N�g�R�[�h)</param>
        /// <param name="prmSetDtlName1">�D�ǐݒ�ڍז��̂P(�D�ǐݒ�}�X�^���擾)</param>
        /// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q(�D�ǐݒ�}�X�^���擾�@��ʃR�[�h)</param>
        /// <param name="prmSetDtlName2">�D�ǐݒ�ڍז��̂Q(�D�ǐݒ�}�X�^���擾)</param>
        /// <param name="sectionCode">���_�R�[�h(���i�Ǘ����}�X�^�擾�Ŏg�p)</param>
        /// <param name="goodsPriceList">���i���(List<GoodsPrice>)</param>
        /// <param name="stockList">�݌ɏ��(List<Stock>)</param>
        /// <param name="offerKubun">�񋟋敪(0:���[�U�[�o�^,1:�񋟏����ҏW,2:�񋟗D�ǕҏW,3:�񋟏���,4:�񋟗D��,5:TBO,7:�I���W�i�����i)</param>
        /// <param name="goodsKind">���i���(��������)(1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0)</param>
        /// <param name="goodsKindResolved">���i���(�����Ȃ�)(1:�e 2:�����q 4:�Z�b�g�q 8:��� 16:��֌݊��@�����i�o�^���͏��0)</param>
        /// <param name="joinDispOrder">�����\������</param>
        /// <param name="joinQty">����QTY</param>
        /// <param name="joinSpecialNote">�����K�i�E���L����</param>
        /// <param name="setDispOrder">�Z�b�g�\������</param>
        /// <param name="setQty">�Z�b�gQTY</param>
        /// <param name="setSpecialNote">�Z�b�g�K�i�E���L����</param>
        /// <param name="partsQty">���iQTY</param>
        /// <param name="offerDataDiv">�񋟃f�[�^�敪(0:���[�U�f�[�^,1:�񋟃f�[�^)</param>
        /// <param name="selectedWarehouseCode">�I��q�ɃR�[�h(�t�h�I�����ꂽ�݌ɂ̑q�ɃR�[�h�i���ʁj)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="selectedListPrice">�艿(�I��)</param>
        /// <param name="selectedListPriceDiv">�W�����i�I��L���敪</param>
        /// <param name="prtGoodsNo">����p�i��</param>
        /// <param name="prtMakerCode">����p���[�J�[�R�[�h</param>
        /// <param name="prtMakerName">����p���[�J�[����</param>
        /// <param name="bLGoodsCodeChange">�ϊ�BL�R�[�h(�ϊ���BL�R�[�h(SCM�Ŏg�p))</param>
        /// <param name="optKonmanGoodsMstCtl">���i�}�X�^�\���p�I�v�V����</param>
        /// <param name="standard">�K�i</param>
        /// <param name="packing">�׎p</param>
        /// <param name="posNo">�o�n�rNo.</param>
        /// <param name="makerGoodsNo">���[�J�[�i��</param>
        /// <param name="createDateTimeA">�쐬�����U</param>
        /// <param name="updateDateTimeA">�X�V�����U</param>
        /// <param name="fileHeaderGuidA">GUID�U</param>
        /// <returns>GoodsUnitData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 ������ �ێ�˗��A��ǉ�</br>
        /// <br>Update Note      :   2009/11/24 21024 ���X�� �� ����BL�R�[�h��ǉ�</br>
        /// <br>Update Note      :   2010/06/10 22018 ��� ���b ���R�������i�ŗL�ԍ���ǉ�</br>
        /// <br>Update Note      :   2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        // UPD 2015/02/25 SCM������ C������ʑΉ� -------------------------->>>>>
        #region ���\�[�X
        // --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        //// --- UPD m.suzuki 2010/06/10 ---------->>>>>
        ////// 2010/03/02 >>>
        //////// 2009/11/24 >>>
        ////////public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv)
        //////public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv,Int32 searchBLCode)
        //////// 2009/11/24 <<<
        ////public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange)
        ////// 2010/03/02 <<<
        //public GoodsUnitData( DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo )
        //// --- UPD m.suzuki 2010/06/10 ----------<<<<<
        // UPD 2015/01/07 ���[�J�[��]�������i�Ή� --------------------->>>>>
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH
        //                    )
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH
        //                    , List<GoodsPrice> mkrSuggestRtPricList 
        //                    )
        // UPD 2015/01/07 ���[�J�[��]�������i�Ή� ---------------------<<<<<
        // -------- DEL START 2014/02/10 ���z -------->>>>>
        ////// --- UPD m.suzuki 2010/06/10 ----------<<<<<
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH
        //                    )
        //// --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        // -------- DEL END 2014/02/10 ���z --------<<<<<
        //// -------- ADD START 2014/02/10 ���z -------->>>>>
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH, Int32 optKonmanGoodsMstCtl, string standard, string packing, string posNo, string makerGoodsNo, DateTime createDateTimeA, DateTime updateDateTimeA, Guid fileHeaderGuidA
        //                    )
        //// -------- ADD END 2014/02/10 ���z --------<<<<<
        #endregion
        public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
                            , Int32 joinSourceMakerCode
                            , string joinSrcPartsNoWithH, Int32 optKonmanGoodsMstCtl, string standard, string packing, string posNo, string makerGoodsNo, DateTime createDateTimeA, DateTime updateDateTimeA, Guid fileHeaderGuidA
                            //, List<GoodsPrice> mkrSuggestRtPricList  // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή�
                            , string prmSetDtlName2ForFac
                            , string prmSetDtlName2ForCOw
                            )
        // UPD 2015/02/25 SCM������ C������ʑΉ� --------------------------<<<<<
        // --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._makerShortName = makerShortName;
            this._makerKanaName = makerKanaName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._jan = jan;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._displayOrder = displayOrder;
            this._goodsLGroup = goodsLGroup;
            this._goodsLGroupName = goodsLGroupName;
            this._goodsMGroup = goodsMGroup;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._goodsRateRank = goodsRateRank;
            this._taxationDivCd = taxationDivCd;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._offerDate = offerDate;
            this._goodsKindCode = goodsKindCode;
            this._goodsNote1 = goodsNote1;
            this._goodsNote2 = goodsNote2;
            this._goodsSpecialNote = goodsSpecialNote;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this.UpdateDate = updateDate;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._goodsRateGrpName = goodsRateGrpName;
            this._salesCode = salesCode;
            this._salesCodeName = salesCodeName;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._suppHonorificTitle = suppHonorificTitle;
            this._supplierKana = supplierKana;
            this._supplierSnm = supplierSnm;
            this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
            this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
            this._supplierLot = supplierLot;
            this._secretCode = secretCode;
            this._primePartsDisplayOrder = primePartsDisplayOrder;
            this._prmSetDtlNo1 = prmSetDtlNo1;
            this._prmSetDtlName1 = prmSetDtlName1;
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._prmSetDtlName2 = prmSetDtlName2;
            this._sectionCode = sectionCode;
            this._goodsPriceList = goodsPriceList;
            this._stockList = stockList;
            this._offerKubun = offerKubun;
            this._goodsKind = goodsKind;
            this._goodsKindResolved = goodsKindResolved;
            this._joinDispOrder = joinDispOrder;
            this._joinQty = joinQty;
            this._joinSpecialNote = joinSpecialNote;
            this._setDispOrder = setDispOrder;
            this._setQty = setQty;
            this._setSpecialNote = setSpecialNote;
            this._partsQty = partsQty;
            this._offerDataDiv = offerDataDiv;
            this._selectedWarehouseCode = selectedWarehouseCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            //----------------ADD 2009/10/19---------------->>>>>
            this._selectedListPrice = selectedListPrice;
            this._selectedListPriceDiv = selectedListPriceDiv;
            this._prtGoodsNo = prtGoodsNo;
            this._prtMakerCode = prtMakerCode;
            this._prtMakerName = prtMakerName;
            this._selectedGoodsNoDiv = selectedGoodsNoDiv;
            //----------------ADD 2009/10/19----------------<<<<<
            // 2009/11/24 Add >>>
            this._searchBLCode = searchBLCode;
            // 2009/11/24 Add <<<
            // 2010/03/02 Add >>>
            this._bLGoodsCodeChange = bLGoodsCodeChange;
            // 2010/03/02 Add <<<
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            this._freSrchPrtPropNo = freSrchPrtPropNo;
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
            this._joinSourceMakerCode = joinSourceMakerCode;
            this._joinSrcPartsNoWithH = joinSrcPartsNoWithH;
            // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            this._optKonmanGoodsMstCtl = optKonmanGoodsMstCtl;
            this._standard = standard;
            this._packing = packing;
            this._posNo = posNo;
            this._makerGoodsNo = makerGoodsNo;
            this._createDateTimeA = createDateTimeA;
            this._updateDateTimeA = updateDateTimeA;
            this._fileHeaderGuidA = fileHeaderGuidA;
            // -------- ADD END 2014/02/10 ���z --------<<<<<
            // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
            //// ADD 2015/01/07 ���[�J�[��]�������i�Ή� --------------------->>>>>
            //this._mkrSuggestRtPricList = mkrSuggestRtPricList;
            //// ADD 2015/01/07 ���[�J�[��]�������i�Ή� ---------------------<<<<<
            // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            // ADD 2015/02/25 SCM������ C������ʑΉ� -------------------------->>>>>
            this._prmSetDtlName2ForFac = prmSetDtlName2ForFac;
            this._prmSetDtlName2ForCOw = prmSetDtlName2ForCOw;
            // ADD 2015/02/25 SCM������ C������ʑΉ� --------------------------<<<<<
        }

        /// <summary>
        /// ���i�A���f�[�^�N���X��������
        /// </summary>
        /// <returns>GoodsUnitData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsUnitData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 ������ �ێ�˗��A��ǉ�</br>
        /// <br>Update Note      :   2009/11/24 21024 ���X�� ���@����BL�R�[�h��ǉ�</br>
        /// <br>Update Note      :   2010/06/10 22018 ��� ���b�@���R�������i�ŗL�ԍ���ǉ�</br>
        /// <br>Update Note      :   2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// <br></br>
        /// </remarks>
        public GoodsUnitData Clone()
        {
            // UPD 2015/02/25 SCM������ C������ʑΉ� -------------------------->>>>>
            #region ���\�[�X
            //// --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
            ////// --- UPD m.suzuki 2010/06/10 ---------->>>>>
            //////// 2010/03/02 >>>
            ////////// 2009/11/24 >>>
            //////////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv);
            ////////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode);
            ////////// 2009/11/24 <<<
            //////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange);
            //////// 2010/03/02 <<<
            ////return new GoodsUnitData( this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo );
            ////// --- UPD m.suzuki 2010/06/10 ----------<<<<<
            //// UPD 2015/01/07 ���[�J�[��]�������i�Ή� --------------------->>>>>
            ////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
            ////                        , this._joinSourceMakerCode
            ////                        , this._joinSrcPartsNoWithH
            ////                        );
            //return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
            //                        , this._joinSourceMakerCode
            //                        , this._joinSrcPartsNoWithH
            //                        , this._mkrSuggestRtPricList
            //                        );
            //// UPD 2015/01/07 ���[�J�[��]�������i�Ή� ---------------------<<<<<
            //// --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
            //// -------- ADD START 2014/02/10 ���z -------->>>>>
            //return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
            //                        , this._joinSourceMakerCode
            //                        , this._joinSrcPartsNoWithH, this._optKonmanGoodsMstCtl, this._standard, this._packing, this._posNo, this._makerGoodsNo, this._createDateTimeA, this._updateDateTimeA, this._fileHeaderGuidA
            //                        );
            //// -------- ADD END 2014/02/10 ���z --------<<<<<
            #endregion
            return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
                        , this._joinSourceMakerCode
                        , this._joinSrcPartsNoWithH, this._optKonmanGoodsMstCtl, this._standard, this._packing, this._posNo, this._makerGoodsNo, this._createDateTimeA, this._updateDateTimeA, this._fileHeaderGuidA
                        // , this._mkrSuggestRtPricList  // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή�
                        , this._prmSetDtlName2ForFac
                        , this._prmSetDtlName2ForCOw
                        );
            // UPD 2015/02/25 SCM������ C������ʑΉ� --------------------------<<<<<
        }

        /// <summary>
        /// ���i�A���f�[�^�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsUnitData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 ������ �ێ�˗��A��ǉ�</br>
        /// <br>Update Note      :   2009/11/24 21024 ���X�� ���@����BL�R�[�h��ǉ�</br>
        /// <br>Update Note      :   2010/06/10 22018 ��� ���b�@���R�������i�ŗL�ԍ���ǉ�</br>
        /// <br>Update Note      :   2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        public bool Equals(GoodsUnitData target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerShortName == target.MakerShortName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.Jan == target.Jan)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsLGroupName == target.GoodsLGroupName)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.OfferDate == target.OfferDate)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsNote1 == target.GoodsNote1)
                 && (this.GoodsNote2 == target.GoodsNote2)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 && (this.GoodsRateGrpName == target.GoodsRateGrpName)
                 && (this.SalesCode == target.SalesCode)
                 && (this.SalesCodeName == target.SalesCodeName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierNm2 == target.SupplierNm2)
                 && (this.SuppHonorificTitle == target.SuppHonorificTitle)
                 && (this.SupplierKana == target.SupplierKana)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
                 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
                 && (this.SupplierLot == target.SupplierLot)
                 && (this.SecretCode == target.SecretCode)
                 && (this.PrimePartsDisplayOrder == target.PrimePartsDisplayOrder)
                 && (this.PrmSetDtlNo1 == target.PrmSetDtlNo1)
                 && (this.PrmSetDtlName1 == target.PrmSetDtlName1)
                 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                 && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
                 && (this.SectionCode == target.SectionCode)
                //&& (this.GoodsPriceList == target.GoodsPriceList)
                 && (EqualsGoodsPriceList(this.GoodsPriceList, target.GoodsPriceList))
                //&& (this.StockList == target.StockList)
                 && (this.OfferKubun == target.OfferKubun)
                 && (this.GoodsKind == target.GoodsKind)
                 && (this.GoodsKindResolved == target.GoodsKindResolved)
                 && (this.JoinDispOrder == target.JoinDispOrder)
                 && (this.JoinQty == target.JoinQty)
                 && (this.JoinSpecialNote == target.JoinSpecialNote)
                 && (this.SetDispOrder == target.SetDispOrder)
                 && (this.SetQty == target.SetQty)
                 && (this.SetSpecialNote == target.SetSpecialNote)
                 && (this.PartsQty == target.PartsQty)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.SelectedWarehouseCode == target.SelectedWarehouseCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                // 2009/11/24 Add >>>
                 && ( this.SearchBLCode == target.SearchBLCode )
                // 2009/11/24 Add <<<
                // 2010/03/02 Add >>>
                 && ( this.BLGoodsCodeChange == target.BLGoodsCodeChange )
                // 2010/03/02 Add <<<
                // --- ADD m.suzuki 2010/06/10 ---------->>>>>
                 && (this.FreSrchPrtPropNo == target.FreSrchPrtPropNo)
                // --- ADD m.suzuki 2010/06/10 ----------<<<<<
                 //----------------ADD 2009/10/19---------------->>>>>
                 && (this.SelectedListPrice == target.SelectedListPrice)
                 && (this.SelectedListPriceDiv == target.SelectedListPriceDiv)
                 && (this.PrtGoodsNo == target.PrtGoodsNo)
                 && (this.PrtMakerCode == target.PrtMakerCode)
                 && (this.PrtMakerName == target.PrtMakerName)
                 && (this.SelectedGoodsNoDiv == target.SelectedGoodsNoDiv)
                 //----------------ADD 2009/10/19----------------<<<<<
                // -------- ADD START 2014/02/10 ���z -------->>>>>
                 && (this.OptKonmanGoodsMstCtl == target.OptKonmanGoodsMstCtl)
                 && (this.Standard == target.Standard)
                 && (this.Packing == target.Packing)
                 && (this.PosNo == target.PosNo)
                 && (this.MakerGoodsNo == target.MakerGoodsNo)
                 && (this.CreateDateTimeA == target.CreateDateTimeA)
                 && (this.UpdateDateTimeA == target.UpdateDateTimeA)
                 && (this.FileHeaderGuidA == target.FileHeaderGuidA));
            // -------- ADD END 2014/02/10 ���z --------<<<<<
        }

        /// <summary>
        /// ���i�A���f�[�^�N���X��r����
        /// </summary>
        /// <param name="goodsUnitData1">
        ///                    ��r����GoodsUnitData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="goodsUnitData2">��r����GoodsUnitData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 ������ �ێ�˗��A��ǉ�</br>
        /// <br>Update Note      :   2009/11/24 21024 ���X�� ���@����BL�R�[�h��ǉ�</br>
        /// <br>Update Note      :   2010/06/10 22018 ��� ���b ���R�������i�ŗL�ԍ���ǉ�</br>
        /// <br>Update Note      :   2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        public static bool Equals(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
        {
            return ((goodsUnitData1.CreateDateTime == goodsUnitData2.CreateDateTime)
                 && (goodsUnitData1.UpdateDateTime == goodsUnitData2.UpdateDateTime)
                 && (goodsUnitData1.EnterpriseCode == goodsUnitData2.EnterpriseCode)
                 && (goodsUnitData1.FileHeaderGuid == goodsUnitData2.FileHeaderGuid)
                 && (goodsUnitData1.UpdEmployeeCode == goodsUnitData2.UpdEmployeeCode)
                 && (goodsUnitData1.UpdAssemblyId1 == goodsUnitData2.UpdAssemblyId1)
                 && (goodsUnitData1.UpdAssemblyId2 == goodsUnitData2.UpdAssemblyId2)
                 && (goodsUnitData1.LogicalDeleteCode == goodsUnitData2.LogicalDeleteCode)
                 && (goodsUnitData1.GoodsMakerCd == goodsUnitData2.GoodsMakerCd)
                 && (goodsUnitData1.MakerName == goodsUnitData2.MakerName)
                 && (goodsUnitData1.MakerShortName == goodsUnitData2.MakerShortName)
                 && (goodsUnitData1.MakerKanaName == goodsUnitData2.MakerKanaName)
                 && (goodsUnitData1.GoodsNo == goodsUnitData2.GoodsNo)
                 && (goodsUnitData1.GoodsName == goodsUnitData2.GoodsName)
                 && (goodsUnitData1.GoodsNameKana == goodsUnitData2.GoodsNameKana)
                 && (goodsUnitData1.Jan == goodsUnitData2.Jan)
                 && (goodsUnitData1.BLGoodsCode == goodsUnitData2.BLGoodsCode)
                 && (goodsUnitData1.BLGoodsFullName == goodsUnitData2.BLGoodsFullName)
                 && (goodsUnitData1.DisplayOrder == goodsUnitData2.DisplayOrder)
                 && (goodsUnitData1.GoodsLGroup == goodsUnitData2.GoodsLGroup)
                 && (goodsUnitData1.GoodsLGroupName == goodsUnitData2.GoodsLGroupName)
                 && (goodsUnitData1.GoodsMGroup == goodsUnitData2.GoodsMGroup)
                 && (goodsUnitData1.GoodsMGroupName == goodsUnitData2.GoodsMGroupName)
                 && (goodsUnitData1.BLGroupCode == goodsUnitData2.BLGroupCode)
                 && (goodsUnitData1.BLGroupName == goodsUnitData2.BLGroupName)
                 && (goodsUnitData1.GoodsRateRank == goodsUnitData2.GoodsRateRank)
                 && (goodsUnitData1.TaxationDivCd == goodsUnitData2.TaxationDivCd)
                 && (goodsUnitData1.GoodsNoNoneHyphen == goodsUnitData2.GoodsNoNoneHyphen)
                 && (goodsUnitData1.OfferDate == goodsUnitData2.OfferDate)
                 && (goodsUnitData1.GoodsKindCode == goodsUnitData2.GoodsKindCode)
                 && (goodsUnitData1.GoodsNote1 == goodsUnitData2.GoodsNote1)
                 && (goodsUnitData1.GoodsNote2 == goodsUnitData2.GoodsNote2)
                 && (goodsUnitData1.GoodsSpecialNote == goodsUnitData2.GoodsSpecialNote)
                 && (goodsUnitData1.EnterpriseGanreCode == goodsUnitData2.EnterpriseGanreCode)
                 && (goodsUnitData1.EnterpriseGanreName == goodsUnitData2.EnterpriseGanreName)
                 && (goodsUnitData1.UpdateDate == goodsUnitData2.UpdateDate)
                 && (goodsUnitData1.GoodsRateGrpCode == goodsUnitData2.GoodsRateGrpCode)
                 && (goodsUnitData1.GoodsRateGrpName == goodsUnitData2.GoodsRateGrpName)
                 && (goodsUnitData1.SalesCode == goodsUnitData2.SalesCode)
                 && (goodsUnitData1.SalesCodeName == goodsUnitData2.SalesCodeName)
                 && (goodsUnitData1.SupplierCd == goodsUnitData2.SupplierCd)
                 && (goodsUnitData1.SupplierNm1 == goodsUnitData2.SupplierNm1)
                 && (goodsUnitData1.SupplierNm2 == goodsUnitData2.SupplierNm2)
                 && (goodsUnitData1.SuppHonorificTitle == goodsUnitData2.SuppHonorificTitle)
                 && (goodsUnitData1.SupplierKana == goodsUnitData2.SupplierKana)
                 && (goodsUnitData1.SupplierSnm == goodsUnitData2.SupplierSnm)
                 && (goodsUnitData1.StockUnPrcFrcProcCd == goodsUnitData2.StockUnPrcFrcProcCd)
                 && (goodsUnitData1.StockCnsTaxFrcProcCd == goodsUnitData2.StockCnsTaxFrcProcCd)
                 && (goodsUnitData1.SupplierLot == goodsUnitData2.SupplierLot)
                 && (goodsUnitData1.SecretCode == goodsUnitData2.SecretCode)
                 && (goodsUnitData1.PrimePartsDisplayOrder == goodsUnitData2.PrimePartsDisplayOrder)
                 && (goodsUnitData1.PrmSetDtlNo1 == goodsUnitData2.PrmSetDtlNo1)
                 && (goodsUnitData1.PrmSetDtlName1 == goodsUnitData2.PrmSetDtlName1)
                 && (goodsUnitData1.PrmSetDtlNo2 == goodsUnitData2.PrmSetDtlNo2)
                 && (goodsUnitData1.PrmSetDtlName2 == goodsUnitData2.PrmSetDtlName2)
                 && (goodsUnitData1.SectionCode == goodsUnitData2.SectionCode)
                //&& (goodsUnitData1.GoodsPriceList == goodsUnitData2.GoodsPriceList)
                 && (EqualsGoodsPriceList(goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList))
                //&& (goodsUnitData1.StockList == goodsUnitData2.StockList)
                 && (goodsUnitData1.OfferKubun == goodsUnitData2.OfferKubun)
                 && (goodsUnitData1.GoodsKind == goodsUnitData2.GoodsKind)
                 && (goodsUnitData1.GoodsKindResolved == goodsUnitData2.GoodsKindResolved)
                 && (goodsUnitData1.JoinDispOrder == goodsUnitData2.JoinDispOrder)
                 && (goodsUnitData1.JoinQty == goodsUnitData2.JoinQty)
                 && (goodsUnitData1.JoinSpecialNote == goodsUnitData2.JoinSpecialNote)
                 && (goodsUnitData1.SetDispOrder == goodsUnitData2.SetDispOrder)
                 && (goodsUnitData1.SetQty == goodsUnitData2.SetQty)
                 && (goodsUnitData1.SetSpecialNote == goodsUnitData2.SetSpecialNote)
                 && (goodsUnitData1.PartsQty == goodsUnitData2.PartsQty)
                 && (goodsUnitData1.OfferDataDiv == goodsUnitData2.OfferDataDiv)
                 && (goodsUnitData1.SelectedWarehouseCode == goodsUnitData2.SelectedWarehouseCode)
                 && (goodsUnitData1.EnterpriseName == goodsUnitData2.EnterpriseName)
                 && (goodsUnitData1.UpdEmployeeName == goodsUnitData2.UpdEmployeeName)
                 && (goodsUnitData1.BLGoodsName == goodsUnitData2.BLGoodsName)
                 // 2009/11/24 Add >>>
                 && ( goodsUnitData1.SearchBLCode == goodsUnitData2.SearchBLCode )
                 // 2009/11/24 Add <<<
                 // 2010/03/02 Add >>>
                 && ( goodsUnitData1.BLGoodsCodeChange == goodsUnitData2.BLGoodsCodeChange )
                 // 2010/03/02 Add <<<
                 // --- ADD m.suzuki 2010/06/10 ---------->>>>>
                 && (goodsUnitData1.FreSrchPrtPropNo == goodsUnitData2.FreSrchPrtPropNo)
                 // --- ADD m.suzuki 2010/06/10 ----------<<<<<
                 //----------------ADD 2009/10/19---------------->>>>>
                 && (goodsUnitData1.SelectedListPrice == goodsUnitData2.SelectedListPrice)
                 && (goodsUnitData1.SelectedListPriceDiv == goodsUnitData2.SelectedListPriceDiv)
                 && (goodsUnitData1.PrtGoodsNo == goodsUnitData2.PrtGoodsNo)
                 && (goodsUnitData1.PrtMakerCode == goodsUnitData2.PrtMakerCode)
                 && (goodsUnitData1.PrtMakerName == goodsUnitData2.PrtMakerName)
                 && (goodsUnitData1.SelectedGoodsNoDiv == goodsUnitData2.SelectedGoodsNoDiv)
                 //----------------ADD 2009/10/19----------------<<<<<
                // -------- ADD START 2014/02/10 ���z -------->>>>>
                 && (goodsUnitData1.OptKonmanGoodsMstCtl == goodsUnitData2.OptKonmanGoodsMstCtl)
                 && (goodsUnitData1.Standard == goodsUnitData2.Standard)
                 && (goodsUnitData1.Packing == goodsUnitData2.Packing)
                 && (goodsUnitData1.PosNo == goodsUnitData2.PosNo)
                 && (goodsUnitData1.MakerGoodsNo == goodsUnitData2.MakerGoodsNo)
                 && (goodsUnitData1.CreateDateTimeA == goodsUnitData2.CreateDateTimeA)
                 && (goodsUnitData1.UpdateDateTimeA == goodsUnitData2.UpdateDateTimeA)
                 && (goodsUnitData1.FileHeaderGuidA == goodsUnitData2.FileHeaderGuidA));
            // -------- ADD END 2014/02/10 ���z --------<<<<<
        }
        /// <summary>
        /// ���i�A���f�[�^�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsUnitData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 ������ �ێ�˗��A��ǉ�</br>
        /// <br>Update Note      :   2009/11/24 21024 ���X�� ���@����BL�R�[�h��ǉ�</br>
        /// <br>Update Note      :   2010/06/10 22018 ��� ���b ���R�������i�ŗL�ԍ���ǉ�</br>
        /// <br>Update Note      :   2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        public ArrayList Compare(GoodsUnitData target)
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
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.MakerShortName != target.MakerShortName) resList.Add("MakerShortName");
            if (this.MakerKanaName != target.MakerKanaName) resList.Add("MakerKanaName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.Jan != target.Jan) resList.Add("Jan");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsLGroupName != target.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsNote1 != target.GoodsNote1) resList.Add("GoodsNote1");
            if (this.GoodsNote2 != target.GoodsNote2) resList.Add("GoodsNote2");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.GoodsRateGrpName != target.GoodsRateGrpName) resList.Add("GoodsRateGrpName");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.SalesCodeName != target.SalesCodeName) resList.Add("SalesCodeName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SuppHonorificTitle != target.SuppHonorificTitle) resList.Add("SuppHonorificTitle");
            if (this.SupplierKana != target.SupplierKana) resList.Add("SupplierKana");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (this.SupplierLot != target.SupplierLot) resList.Add("SupplierLot");
            if (this.SecretCode != target.SecretCode) resList.Add("SecretCode");
            if (this.PrimePartsDisplayOrder != target.PrimePartsDisplayOrder) resList.Add("PrimePartsDisplayOrder");
            if (this.PrmSetDtlNo1 != target.PrmSetDtlNo1) resList.Add("PrmSetDtlNo1");
            if (this.PrmSetDtlName1 != target.PrmSetDtlName1) resList.Add("PrmSetDtlName1");
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.PrmSetDtlName2 != target.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            //if ( this.GoodsPriceList != target.GoodsPriceList ) resList.Add( "GoodsPriceList" );
            if (!EqualsGoodsPriceList(this.GoodsPriceList, target.GoodsPriceList)) resList.Add("GoodsPriceList");
            //if ( this.StockList != target.StockList ) resList.Add( "StockList" );
            if (this.OfferKubun != target.OfferKubun) resList.Add("OfferKubun");
            if (this.GoodsKind != target.GoodsKind) resList.Add("GoodsKind");
            if (this.GoodsKindResolved != target.GoodsKindResolved) resList.Add("GoodsKindResolved");
            if (this.JoinDispOrder != target.JoinDispOrder) resList.Add("JoinDispOrder");
            if (this.JoinQty != target.JoinQty) resList.Add("JoinQty");
            if (this.JoinSpecialNote != target.JoinSpecialNote) resList.Add("JoinSpecialNote");
            if (this.SetDispOrder != target.SetDispOrder) resList.Add("SetDispOrder");
            if (this.SetQty != target.SetQty) resList.Add("SetQty");
            if (this.SetSpecialNote != target.SetSpecialNote) resList.Add("SetSpecialNote");
            if (this.PartsQty != target.PartsQty) resList.Add("PartsQty");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.SelectedWarehouseCode != target.SelectedWarehouseCode) resList.Add("SelectedWarehouseCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            //----------------ADD 2009/10/19---------------->>>>>
            if (this.SelectedListPrice != target.SelectedListPrice) resList.Add("SelectedListPrice");
            if (this.SelectedListPriceDiv != target.SelectedListPriceDiv) resList.Add("SelectedListPriceDiv");
            if (this.PrtGoodsNo != target.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (this.PrtMakerCode != target.PrtMakerCode) resList.Add("PrtMakerCode");
            if (this.PrtMakerName != target.PrtMakerName) resList.Add("PrtMakerName");
            if (this.SelectedGoodsNoDiv != target.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            // 2009/11/24 Add >>>
            if (this.SearchBLCode != target.SearchBLCode) resList.Add("SearchBLCode");
            // 2009/11/24 Add <<<
            //----------------ADD 2009/10/19---------------->>>>>
            // 2010/03/02 Add >>>
            if (this.BLGoodsCodeChange != target.BLGoodsCodeChange) resList.Add("BLGoodsCodeChange");
            // 2010/03/02 Add <<<
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            if ( this.FreSrchPrtPropNo != target.FreSrchPrtPropNo ) resList.Add( "FreSrchPrtPropNo" );
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            if (this.OptKonmanGoodsMstCtl != target.OptKonmanGoodsMstCtl) resList.Add("OptKonmanGoodsMstCtl");
            if (this.Standard != target.Standard) resList.Add("Standard");
            if (this.Packing != target.Packing) resList.Add("Packing");
            if (this.PosNo != target.PosNo) resList.Add("PosNo");
            if (this.MakerGoodsNo != target.MakerGoodsNo) resList.Add("MakerGoodsNo");
            if (this.CreateDateTimeA != target.CreateDateTimeA) resList.Add("CreateDateTimeA");
            if (this.UpdateDateTimeA != target.UpdateDateTimeA) resList.Add("UpdateDateTimeA");
            if (this.FileHeaderGuidA != target.FileHeaderGuidA) resList.Add("FileHeaderGuidA");
            // -------- ADD END 2014/02/10 ���z --------<<<<<
            return resList;
        }

        /// <summary>
        /// ���i�A���f�[�^�N���X��r����
        /// </summary>
        /// <param name="goodsUnitData1">��r����GoodsUnitData�N���X�̃C���X�^���X</param>
        /// <param name="goodsUnitData2">��r����GoodsUnitData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 ������ �ێ�˗��A��ǉ�</br>
        /// <br>Update Note      :   2009/11/24 21024 ���X�� ���@����BL�R�[�h��ǉ�</br>
        /// <br>Update Note      :   2010/06/10 22018 ��� ���b ���R�������i�ŗL�ԍ���ǉ�</br>
        /// <br>Update Note      :   2014/02/10 ���z Redmine#41976 ���i�}�X�^�U�̒ǉ�</br>
        /// </remarks>
        public static ArrayList Compare(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
        {
            ArrayList resList = new ArrayList();
            if (goodsUnitData1.CreateDateTime != goodsUnitData2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsUnitData1.UpdateDateTime != goodsUnitData2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsUnitData1.EnterpriseCode != goodsUnitData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsUnitData1.FileHeaderGuid != goodsUnitData2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsUnitData1.UpdEmployeeCode != goodsUnitData2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsUnitData1.UpdAssemblyId1 != goodsUnitData2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsUnitData1.UpdAssemblyId2 != goodsUnitData2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsUnitData1.LogicalDeleteCode != goodsUnitData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsUnitData1.GoodsMakerCd != goodsUnitData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsUnitData1.MakerName != goodsUnitData2.MakerName) resList.Add("MakerName");
            if (goodsUnitData1.MakerShortName != goodsUnitData2.MakerShortName) resList.Add("MakerShortName");
            if (goodsUnitData1.MakerKanaName != goodsUnitData2.MakerKanaName) resList.Add("MakerKanaName");
            if (goodsUnitData1.GoodsNo != goodsUnitData2.GoodsNo) resList.Add("GoodsNo");
            if (goodsUnitData1.GoodsName != goodsUnitData2.GoodsName) resList.Add("GoodsName");
            if (goodsUnitData1.GoodsNameKana != goodsUnitData2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (goodsUnitData1.Jan != goodsUnitData2.Jan) resList.Add("Jan");
            if (goodsUnitData1.BLGoodsCode != goodsUnitData2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsUnitData1.BLGoodsFullName != goodsUnitData2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (goodsUnitData1.DisplayOrder != goodsUnitData2.DisplayOrder) resList.Add("DisplayOrder");
            if (goodsUnitData1.GoodsLGroup != goodsUnitData2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (goodsUnitData1.GoodsLGroupName != goodsUnitData2.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (goodsUnitData1.GoodsMGroup != goodsUnitData2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (goodsUnitData1.GoodsMGroupName != goodsUnitData2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (goodsUnitData1.BLGroupCode != goodsUnitData2.BLGroupCode) resList.Add("BLGroupCode");
            if (goodsUnitData1.BLGroupName != goodsUnitData2.BLGroupName) resList.Add("BLGroupName");
            if (goodsUnitData1.GoodsRateRank != goodsUnitData2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (goodsUnitData1.TaxationDivCd != goodsUnitData2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (goodsUnitData1.GoodsNoNoneHyphen != goodsUnitData2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (goodsUnitData1.OfferDate != goodsUnitData2.OfferDate) resList.Add("OfferDate");
            if (goodsUnitData1.GoodsKindCode != goodsUnitData2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (goodsUnitData1.GoodsNote1 != goodsUnitData2.GoodsNote1) resList.Add("GoodsNote1");
            if (goodsUnitData1.GoodsNote2 != goodsUnitData2.GoodsNote2) resList.Add("GoodsNote2");
            if (goodsUnitData1.GoodsSpecialNote != goodsUnitData2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (goodsUnitData1.EnterpriseGanreCode != goodsUnitData2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (goodsUnitData1.EnterpriseGanreName != goodsUnitData2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (goodsUnitData1.UpdateDate != goodsUnitData2.UpdateDate) resList.Add("UpdateDate");
            if (goodsUnitData1.GoodsRateGrpCode != goodsUnitData2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (goodsUnitData1.GoodsRateGrpName != goodsUnitData2.GoodsRateGrpName) resList.Add("GoodsRateGrpName");
            if (goodsUnitData1.SalesCode != goodsUnitData2.SalesCode) resList.Add("SalesCode");
            if (goodsUnitData1.SalesCodeName != goodsUnitData2.SalesCodeName) resList.Add("SalesCodeName");
            if (goodsUnitData1.SupplierCd != goodsUnitData2.SupplierCd) resList.Add("SupplierCd");
            if (goodsUnitData1.SupplierNm1 != goodsUnitData2.SupplierNm1) resList.Add("SupplierNm1");
            if (goodsUnitData1.SupplierNm2 != goodsUnitData2.SupplierNm2) resList.Add("SupplierNm2");
            if (goodsUnitData1.SuppHonorificTitle != goodsUnitData2.SuppHonorificTitle) resList.Add("SuppHonorificTitle");
            if (goodsUnitData1.SupplierKana != goodsUnitData2.SupplierKana) resList.Add("SupplierKana");
            if (goodsUnitData1.SupplierSnm != goodsUnitData2.SupplierSnm) resList.Add("SupplierSnm");
            if (goodsUnitData1.StockUnPrcFrcProcCd != goodsUnitData2.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (goodsUnitData1.StockCnsTaxFrcProcCd != goodsUnitData2.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (goodsUnitData1.SupplierLot != goodsUnitData2.SupplierLot) resList.Add("SupplierLot");
            if (goodsUnitData1.SecretCode != goodsUnitData2.SecretCode) resList.Add("SecretCode");
            if (goodsUnitData1.PrimePartsDisplayOrder != goodsUnitData2.PrimePartsDisplayOrder) resList.Add("PrimePartsDisplayOrder");
            if (goodsUnitData1.PrmSetDtlNo1 != goodsUnitData2.PrmSetDtlNo1) resList.Add("PrmSetDtlNo1");
            if (goodsUnitData1.PrmSetDtlName1 != goodsUnitData2.PrmSetDtlName1) resList.Add("PrmSetDtlName1");
            if (goodsUnitData1.PrmSetDtlNo2 != goodsUnitData2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (goodsUnitData1.PrmSetDtlName2 != goodsUnitData2.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (goodsUnitData1.SectionCode != goodsUnitData2.SectionCode) resList.Add("SectionCode");
            //if ( goodsUnitData1.GoodsPriceList != goodsUnitData2.GoodsPriceList ) resList.Add( "GoodsPriceList" );
            if (!EqualsGoodsPriceList(goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList)) resList.Add("GoodsPriceList");
            //if ( goodsUnitData1.StockList != goodsUnitData2.StockList ) resList.Add( "StockList" );
            if (goodsUnitData1.OfferKubun != goodsUnitData2.OfferKubun) resList.Add("OfferKubun");
            if (goodsUnitData1.GoodsKind != goodsUnitData2.GoodsKind) resList.Add("GoodsKind");
            if (goodsUnitData1.GoodsKindResolved != goodsUnitData2.GoodsKindResolved) resList.Add("GoodsKindResolved");
            if (goodsUnitData1.JoinDispOrder != goodsUnitData2.JoinDispOrder) resList.Add("JoinDispOrder");
            if (goodsUnitData1.JoinQty != goodsUnitData2.JoinQty) resList.Add("JoinQty");
            if (goodsUnitData1.JoinSpecialNote != goodsUnitData2.JoinSpecialNote) resList.Add("JoinSpecialNote");
            if (goodsUnitData1.SetDispOrder != goodsUnitData2.SetDispOrder) resList.Add("SetDispOrder");
            if (goodsUnitData1.SetQty != goodsUnitData2.SetQty) resList.Add("SetQty");
            if (goodsUnitData1.SetSpecialNote != goodsUnitData2.SetSpecialNote) resList.Add("SetSpecialNote");
            if (goodsUnitData1.PartsQty != goodsUnitData2.PartsQty) resList.Add("PartsQty");
            if (goodsUnitData1.OfferDataDiv != goodsUnitData2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (goodsUnitData1.SelectedWarehouseCode != goodsUnitData2.SelectedWarehouseCode) resList.Add("SelectedWarehouseCode");
            if (goodsUnitData1.EnterpriseName != goodsUnitData2.EnterpriseName) resList.Add("EnterpriseName");
            if (goodsUnitData1.UpdEmployeeName != goodsUnitData2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (goodsUnitData1.BLGoodsName != goodsUnitData2.BLGoodsName) resList.Add("BLGoodsName");
            //----------------ADD 2009/10/19---------------->>>>>
            if (goodsUnitData1.SelectedListPrice != goodsUnitData2.SelectedListPrice) resList.Add("SelectedListPrice");
            if (goodsUnitData1.SelectedListPriceDiv != goodsUnitData2.SelectedListPriceDiv) resList.Add("SelectedListPriceDiv");
            if (goodsUnitData1.PrtGoodsNo != goodsUnitData2.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (goodsUnitData1.PrtMakerCode != goodsUnitData2.PrtMakerCode) resList.Add("PrtMakerCode");
            if (goodsUnitData1.PrtMakerName != goodsUnitData2.PrtMakerName) resList.Add("PrtMakerName");
            if (goodsUnitData1.SelectedGoodsNoDiv != goodsUnitData2.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            //----------------ADD 2009/10/19----------------<<<<<
            // 2009/11/24 Add >>>
            if (goodsUnitData1.SearchBLCode != goodsUnitData2.SearchBLCode) resList.Add("SearchBLCode");
            // 2009/11/24 Add <<<
            // 2010/03/02 Add >>>
            if (goodsUnitData1.BLGoodsCodeChange != goodsUnitData2.BLGoodsCodeChange) resList.Add("BLGoodsCodeChange");
            // 2010/03/02 Add <<<
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            if ( goodsUnitData1.FreSrchPrtPropNo != goodsUnitData2.FreSrchPrtPropNo ) resList.Add( "FreSrchPrtPropNo" );
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            if (goodsUnitData1.OptKonmanGoodsMstCtl != goodsUnitData2.OptKonmanGoodsMstCtl) resList.Add("OptKonmanGoodsMstCtl");
            if (goodsUnitData1.Standard != goodsUnitData2.Standard) resList.Add("Standard");
            if (goodsUnitData1.Packing != goodsUnitData2.Packing) resList.Add("Packing");
            if (goodsUnitData1.PosNo != goodsUnitData2.PosNo) resList.Add("PosNo");
            if (goodsUnitData1.MakerGoodsNo != goodsUnitData2.MakerGoodsNo) resList.Add("MakerGoodsNo");
            if (goodsUnitData1.CreateDateTimeA != goodsUnitData2.CreateDateTimeA) resList.Add("CreateDateTimeA");
            if (goodsUnitData1.UpdateDateTimeA != goodsUnitData2.UpdateDateTimeA) resList.Add("UpdateDateTimeA");
            if (goodsUnitData1.FileHeaderGuidA != goodsUnitData2.FileHeaderGuidA) resList.Add("FileHeaderGuidA");
            // -------- ADD END 2014/02/10 ���z --------<<<<<

            return resList;
        }
        /// <summary>
        /// ���i����r����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private static bool EqualsGoodsPriceList(List<GoodsPrice> list, List<GoodsPrice> list2)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // ����null�Ȃ�OK
            if (list == null && list2 == null) return true;
            // �Е�null�Ȃ�NG
            if (list != null && list2 == null) return false;
            if (list == null && list2 != null) return false;
            // �v�f���Ⴂ��NG
            if (list.Count != list2.Count) return false;

            // list�x�[�X�ŊY������list2�̃��R�[�h��T��
            foreach (GoodsPrice price in list)
            {
                GoodsPrice price2 = list2.Find(
                    delegate(GoodsPrice target)
                    {
                        return ((price.GoodsNo == target.GoodsNo) &&
                                (price.GoodsMakerCd == target.GoodsMakerCd) &&
                                (price.PriceStartDate == target.PriceStartDate));
                    }
                    );
                if (price2 == null) return false;

                // ���i�N���X��r
                ArrayList priceComparelist = price.Compare(price2);
                int differCount = priceComparelist.Count;
                if (priceComparelist.Contains("CreateDateTime")) differCount--;
                if (priceComparelist.Contains("UpdateDateTime")) differCount--;
                if (priceComparelist.Contains("UpdateDate")) differCount--;
                if (differCount > 0) return false;
            }

            // �v�f���������Ȃ̂�list�x�[�X�őS�ĊY������΋t�̑��������Ȃ��Ă�OK
            return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
        }

    }

}
