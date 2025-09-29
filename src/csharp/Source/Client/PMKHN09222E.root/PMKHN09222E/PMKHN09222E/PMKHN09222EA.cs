using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PriceChgProcSt
	/// <summary>
    ///                      ���i�����ݒ�}�X�^ �f�[�^�N���X
	/// </summary>
	/// <remarks>
    /// <br>note             :   ���i�����ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/04/30</br>
	/// <br>Genarated Date   :   2005/05/02  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2007.08.16 980035 ���� ��`</br>
    /// <br>			         �E�[�������敪���폜���ď���œ]�ŕ�����ǉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2009/12/11 21024�@���X�� ��</br>
    /// <br>			         �EBL�R�[�h�X�V�敪�̒ǉ�</br>
    /// </remarks>
	public class PriceChgSet
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

        /// <summary>���̍X�V�敪</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _nameUpdDiv;

        /// <summary>�w�ʍX�V�敪</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _partsLayerUpdDiv;

        /// <summary>���i�X�V�敪</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _priceUpdDiv;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:���i�����p��,1:0�ōX�V</remarks>
        private Int32 _openPriceDiv;

        /// <summary>���i�Ǘ�����</summary>
        /// <remarks>3,4,5</remarks>
        private Int32 _priceMngCnt;

        /// <summary>���i���������敪</summary>
        /// <remarks>0:�V���N�Ɠ���,1:�蓮����</remarks>
        private Int32 _priceChgProcDiv;

        // 2009/12/11 Add >>>
        /// <summary>BL�R�[�h�X�V�敪</summary>
        /// <remarks>0:����,1:���Ȃ�</remarks>
        private Int32 _bLGoodsCdUpdDiv;
        // 2009/12/11 Add <<<


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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
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

        /// public propaty name  :  NameUpdDiv
        /// <summary>���̍X�V�敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̍X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NameUpdDiv
        {
            get { return _nameUpdDiv; }
            set { _nameUpdDiv = value; }
        }

        /// public propaty name  :  PartsLayerUpdDiv
        /// <summary>�w�ʍX�V�敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʍX�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsLayerUpdDiv
        {
            get { return _partsLayerUpdDiv; }
            set { _partsLayerUpdDiv = value; }
        }

        /// public propaty name  :  PriceUpdDiv
        /// <summary>���i�X�V�敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceUpdDiv
        {
            get { return _priceUpdDiv; }
            set { _priceUpdDiv = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:���i�����p��,1:0�ōX�V</value>
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

        /// public propaty name  :  PriceMngCnt
        /// <summary>���i�Ǘ������v���p�e�B</summary>
        /// <value>3,4,5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceMngCnt
        {
            get { return _priceMngCnt; }
            set { _priceMngCnt = value; }
        }

        /// public propaty name  :  PriceChgProcDiv
        /// <summary>���i���������敪�v���p�e�B</summary>
        /// <value>0:�V���N�Ɠ���,1:�蓮����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceChgProcDiv
        {
            get { return _priceChgProcDiv; }
            set { _priceChgProcDiv = value; }
        }

        // 2009/12/11 Add >>>
        /// public propaty name  :  BLGoodsCdUpdDiv
        /// <summary>BL�R�[�h�X�V�敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        public Int32 BLGoodsCdUpdDiv
        {
            get { return _bLGoodsCdUpdDiv; }
            set { _bLGoodsCdUpdDiv = value; }
        }
        // 2009/12/11 Add <<<

        /// <summary>
        /// ���i�����ݒ�R���X�g���N�^
        /// </summary>
        /// <returns>PriceChgProcSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceChgProcSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceChgSet()
        {
            _priceMngCnt = 3; // �f�t�H���g�l3
        }
        
        /// <summary>
        /// ���i�����ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="nameUpdDiv">���̍X�V�敪</param>
        /// <param name="partsLayerUpdDiv">�w�ʍX�V�敪</param>
        /// <param name="priceUpdDiv">���i�X�V�敪</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪</param>
        /// <param name="priceMngCnt">���i�Ǘ�����</param>
        /// <param name="priceChgProcDiv">���i���������敪</param>        
        /// <param name="bLGoodsCdUpdDiv">BL�R�[�h�X�V�敪</param>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceChgSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        // 2009/12/11 >>>
        //public PriceChgSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, 
        //    string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode,
        //    Int32 nameUpdDiv, Int32 partsLayerUpdDiv, Int32 priceUpdDiv, Int32 openPriceDiv, Int32 priceMngCnt, Int32 priceChgProcDiv)
        public PriceChgSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid,
            string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode,
            Int32 nameUpdDiv, Int32 partsLayerUpdDiv, Int32 priceUpdDiv, Int32 openPriceDiv, Int32 priceMngCnt, Int32 priceChgProcDiv, Int32 bLGoodsCdUpdDiv)
        // 2009/12/11 <<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            this._nameUpdDiv = nameUpdDiv;
            this._partsLayerUpdDiv = partsLayerUpdDiv;
            this._priceUpdDiv = priceUpdDiv;
            this._openPriceDiv = openPriceDiv;
            this._priceMngCnt = priceMngCnt;
            this._priceChgProcDiv = priceChgProcDiv;
            this._bLGoodsCdUpdDiv = bLGoodsCdUpdDiv;    // 2009/12/11 Add
		}

        /// <summary>
        /// ���i�����ݒ�N���X��������
        /// </summary>
        /// <returns>PriceChgSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PriceChgSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceChgSet Clone()
        {
            // 2009/12/11 >>>
            //return new PriceChgSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid,
            //    this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode,
            //    this._nameUpdDiv, this._partsLayerUpdDiv, this._priceUpdDiv, this._openPriceDiv,
            //    this._priceMngCnt, this._priceChgProcDiv);
            return new PriceChgSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid,
                this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode,
                this._nameUpdDiv, this._partsLayerUpdDiv, this._priceUpdDiv, this._openPriceDiv,
                this._priceMngCnt, this._priceChgProcDiv, this._bLGoodsCdUpdDiv);
            // 2009/12/11 <<<
        }


        /// <summary>
        /// ���i�����ݒ�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PriceChgSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceChgSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PriceChgSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                && (this.UpdateDateTime == target.UpdateDateTime)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.FileHeaderGuid == target.FileHeaderGuid)
                && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                && (this._nameUpdDiv == target.NameUpdDiv)
                && (this._partsLayerUpdDiv == target.PartsLayerUpdDiv)
                && (this._priceUpdDiv == target.PriceUpdDiv)
                && (this._openPriceDiv == target.OpenPriceDiv)
                && (this._priceMngCnt == target.PriceMngCnt)
                // 2009/12/11 Add >>>
                && ( this._bLGoodsCdUpdDiv == target.BLGoodsCdUpdDiv )
                // 2009/12/11 Add <<<
                && (this._priceChgProcDiv == target.PriceChgProcDiv));
        }

        /// <summary>
        /// ���i�����ݒ�N���X��r����
        /// </summary>
        /// <param name="taxrateset1">
        ///                    ��r����PriceChgSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="taxrateset2">��r����PriceChgSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceChgSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PriceChgSet priceChgSet1, PriceChgSet priceChgSet2)
        {
            return ((priceChgSet1.CreateDateTime == priceChgSet2.CreateDateTime)
                && (priceChgSet1.UpdateDateTime == priceChgSet2.UpdateDateTime)
                && (priceChgSet1.EnterpriseCode == priceChgSet2.EnterpriseCode)
                && (priceChgSet1.FileHeaderGuid == priceChgSet2.FileHeaderGuid)
                && (priceChgSet1.UpdEmployeeCode == priceChgSet2.UpdEmployeeCode)
                && (priceChgSet1.UpdAssemblyId1 == priceChgSet2.UpdAssemblyId1)
                && (priceChgSet1.UpdAssemblyId2 == priceChgSet2.UpdAssemblyId2)
                && (priceChgSet1.LogicalDeleteCode == priceChgSet2.LogicalDeleteCode)
                && (priceChgSet1.NameUpdDiv == priceChgSet2.NameUpdDiv)
                && (priceChgSet1.PartsLayerUpdDiv == priceChgSet2.PartsLayerUpdDiv)
                && (priceChgSet1.PriceUpdDiv == priceChgSet2.PriceUpdDiv)
                && (priceChgSet1.OpenPriceDiv == priceChgSet2.OpenPriceDiv)
                && (priceChgSet1.PriceMngCnt == priceChgSet2.PriceMngCnt)
                // 2009/12/11 Add >>>
                && ( priceChgSet1.BLGoodsCdUpdDiv == priceChgSet2.BLGoodsCdUpdDiv )
                // 2009/12/11 Add <<<
                && (priceChgSet1.PriceChgProcDiv == priceChgSet2.PriceChgProcDiv));
        }
        /// <summary>
        /// ���i�����ݒ�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PriceChgSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceChgSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PriceChgSet target)
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
            if (this.NameUpdDiv != target.NameUpdDiv) resList.Add("NameUpdDiv");
            if (this.PartsLayerUpdDiv != target.PartsLayerUpdDiv) resList.Add("PartsLayerUpdDiv");
            if (this.PriceUpdDiv != target.PriceUpdDiv) resList.Add("PriceUpdDiv");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.PriceMngCnt != target.PriceMngCnt) resList.Add("PriceMngCnt");
            if (this.PriceChgProcDiv != target.PriceChgProcDiv) resList.Add("PriceChgProcDiv");
            if (this.BLGoodsCdUpdDiv != target.BLGoodsCdUpdDiv) resList.Add("BLGoodsCdUpdDiv");     // 2009/12/11 Add
            
            return resList;
        }
        /// <summary>
        /// ���i�����ݒ�N���X��r����
        /// </summary>
        /// <param name="priceChgSet1">��r����PriceChgSet�N���X�̃C���X�^���X</param>
        /// <param name="priceChgSet2">��r����PriceChgSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceChgSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PriceChgSet priceChgSet1, PriceChgSet priceChgSet2)
        {
            ArrayList resList = new ArrayList();
            if (priceChgSet1.CreateDateTime != priceChgSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (priceChgSet1.UpdateDateTime != priceChgSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (priceChgSet1.EnterpriseCode != priceChgSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (priceChgSet1.FileHeaderGuid != priceChgSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (priceChgSet1.UpdEmployeeCode != priceChgSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (priceChgSet1.UpdAssemblyId1 != priceChgSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (priceChgSet1.UpdAssemblyId2 != priceChgSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (priceChgSet1.LogicalDeleteCode != priceChgSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (priceChgSet1.NameUpdDiv != priceChgSet2.NameUpdDiv) resList.Add("NameUpdDiv");
            if (priceChgSet1.PartsLayerUpdDiv != priceChgSet2.PartsLayerUpdDiv) resList.Add("PartsLayerUpdDiv");
            if (priceChgSet1.PriceUpdDiv != priceChgSet2.PriceUpdDiv) resList.Add("PriceUpdDiv");
            if (priceChgSet1.OpenPriceDiv != priceChgSet2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (priceChgSet1.PriceMngCnt != priceChgSet2.PriceMngCnt) resList.Add("PriceMngCnt");
            if (priceChgSet1.PriceChgProcDiv != priceChgSet2.PriceChgProcDiv) resList.Add("PriceChgProcDiv");
            if (priceChgSet1.BLGoodsCdUpdDiv != priceChgSet2.BLGoodsCdUpdDiv) resList.Add("BLGoodsCdUpdDiv");   // 2009/12/11 Add
            
            return resList;
        }
    }

}
