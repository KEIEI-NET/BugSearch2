using System;
using System.Collections.Generic;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
    public class DictionaryList : Dictionary<int, object>
    {

    };
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD

	/// public class name:   SlipOutputSet
    /// <summary>
	///                      �`�[�o�͐�ݒ�}�X�^
    /// </summary>
    /// <remarks>
	/// <br>note             :   �`�[�o�͐�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �������� / 30167 ���@�O�M</br>
    /// <br>Date             :   2007/12/10</br>
    /// <br>Genarated Date   :   2007/12/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2007/12/19  30167 ���@�O�M</br>
	/// <br>				     �`�[����ݒ�}�X�^�R�Â��Ή�</br>
	/// <br>Update Note      :   2008/03/17  30167 ���@�O�M</br>
	/// <br>				     �`�[�����ʃ��[�N�V�[�g, �{�f�B���@�}�폜</br>
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>             : 2008/11/10       �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>UpdateNote   : 2010/09/27 22018 ��� ���b�@��ʒ��[���ݒ�\�ɕύX�B</br>
    /// </remarks>
    public class SlipOutputSet
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

        //--- DEL 2008/06/20 ---------->>>>>
        ///// <summary>���_�R�[�h</summary>
        //private string _sectionCode = "";
        //--- DEL 2008/06/20 ----------<<<<<

        //--- ADD 2008/06/19 ---------->>>>>
        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɖ�/�v�����^�ʂ̑ݏo�A�[�i���̎��̂ݎg�p</remarks>
        private string _warehouseCode = "";
        //--- ADD 2008/06/19 ----------<<<<<

		/// <summary>���W�ԍ�</summary>
		/// <remarks>�[���ԍ�</remarks>
		private Int32 _cashRegisterNo;

		//----- h.ueno add---------- start 2007.12.19
		/// <summary>�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
		private Int32 _dataInputSystem;
		//----- h.ueno add---------- end   2007.12.19

		/// <summary>�`�[������</summary>
		/// <remarks>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�}</remarks>
		private Int32 _slipPrtKind;

		/// <summary>�`�[����ݒ�p���[ID</summary>
		/// <remarks>�`�[����ݒ�p</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>�v�����^�Ǘ�No</summary>
		private Int32 _printerMngNo;

		/*----------------------------------------------------------------------------------*/
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

        //--- DEL 2008/06/20 ---------->>>>>
        ///// public propaty name  :  SectionCode
        ///// <summary>���_�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string SectionCode
        //{
        //    get{return _sectionCode;}
        //    set{_sectionCode = value;}
        //}
        //--- DEL 2008/06/20 ----------<<<<<

        //--- ADD 2008/06/19 ---------->>>>>
        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q�ɖ�/�v�����^�ʂ̑ݏo�A�[�i���̎��̂ݎg�p</value>
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
        //--- ADD 2008/06/19 ----------<<<<<

		/// public propaty name  :  CashRegisterNo
		/// <summary>���W�ԍ��v���p�e�B</summary>
		/// <value>�[���ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���W�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CashRegisterNo
		{
			get{return _cashRegisterNo;}
			set{_cashRegisterNo = value;}
		}

		//----- h.ueno add---------- start 2007.12.19
		/// public propaty name  :  DataInputSystem
		/// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
		/// <value>0:����,1:����,2:���,3:�Ԕ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get { return _dataInputSystem; }
			set { _dataInputSystem = value; }
		}
		//----- h.ueno add---------- end   2007.12.19

		/// public propaty name  :  SlipPrtKind
		/// <summary>�`�[�����ʃv���p�e�B</summary>
		/// <value>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipPrtKind
		{
			get{return _slipPrtKind;}
			set{_slipPrtKind = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
		/// <value>�`�[����ݒ�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipPrtSetPaperId
		{
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
		}

		/// public propaty name  :  PrinterMngNo
		/// <summary>�v�����^�Ǘ�No�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�����^�Ǘ�No�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrinterMngNo
		{
			get{return _printerMngNo;}
			set{_printerMngNo = value;}
		}

		/// <summary>
		/// �`�[�o�͐�ݒ�R���X�g���N�^
		/// </summary>
		/// <returns>SlipOutputSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipOutputSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SlipOutputSet()
		{
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
		/// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h(�q�ɖ�/�v�����^�ʂ̑ݏo�A�[�i���̎��̂ݎg�p)</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��(0:����,1:����,2:���,3:�Ԕ�)</param>
		/// <param name="slipPrtKind">�`�[������</param>
		/// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID</param>
		/// <param name="printerMngNo">�v�����^�Ǘ�No</param>
        /// <returns>SlipOutputSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipOutputSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipOutputSet(
			DateTime createDateTime,
			DateTime updateDateTime,
			string enterpriseCode,
			Guid fileHeaderGuid,
			string updEmployeeCode,
			string updAssemblyId1,
			string updAssemblyId2,
			Int32 logicalDeleteCode,
            //string sectionCode,        // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            string warehouseCode,
            //--- ADD 2008/06/19 ----------<<<<<
            Int32 cashRegisterNo,
			//----- h.ueno add---------- start 2007.12.19
			Int32 dataInputSystem,
			//----- h.ueno add---------- end   2007.12.19
			Int32 slipPrtKind,
			string slipPrtSetPaperId,
			Int32 printerMngNo)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            //this._sectionCode = sectionCode;              // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            this._warehouseCode = warehouseCode;
            //--- ADD 2008/06/19 ----------<<<<<
            this._cashRegisterNo = cashRegisterNo;
			//----- h.ueno add---------- start 2007.12.19
			this._dataInputSystem = dataInputSystem;
			//----- h.ueno add---------- end   2007.12.19
			this._slipPrtKind = slipPrtKind;
			this._slipPrtSetPaperId = slipPrtSetPaperId;
			this._printerMngNo = printerMngNo;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^��������
        /// </summary>
        /// <returns>SlipOutputSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SlipOutputSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipOutputSet Clone()
        {
            return new SlipOutputSet(
				this._createDateTime,
				this._updateDateTime,
				this._enterpriseCode,
				this._fileHeaderGuid,
				this._updEmployeeCode,
				this._updAssemblyId1,
				this._updAssemblyId2,
				this._logicalDeleteCode,
                //this._sectionCode,         // DEL 2008/06/20
                //--- ADD 2008/06/19 ---------->>>>>
                this._warehouseCode,
                //--- ADD 2008/06/19 ----------<<<<<
                this._cashRegisterNo,
				//----- h.ueno add---------- start 2007.12.19
				this._dataInputSystem,
				//----- h.ueno add---------- end   2007.12.19
				this._slipPrtKind,
				this._slipPrtSetPaperId,
				this._printerMngNo);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SlipOutputSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipOutputSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SlipOutputSet target)
        {
            return ((this.CreateDateTime	== target.CreateDateTime)
                && (this.UpdateDateTime		== target.UpdateDateTime)
                && (this.EnterpriseCode		== target.EnterpriseCode)
                && (this.FileHeaderGuid		== target.FileHeaderGuid)
                && (this.UpdEmployeeCode	== target.UpdEmployeeCode)
                && (this.UpdAssemblyId1		== target.UpdAssemblyId1)
                && (this.UpdAssemblyId2		== target.UpdAssemblyId2)
                && (this.LogicalDeleteCode	== target.LogicalDeleteCode)
                //&& (this.SectionCode		== target.SectionCode)          // DEL 2008/06/20
                //--- ADD 2008/06/19 ---------->>>>>
                && (this.WarehouseCode      == target.WarehouseCode)
                //--- ADD 2008/06/19 ----------<<<<<
                && (this.CashRegisterNo == target.CashRegisterNo)
				//----- h.ueno add---------- start 2007.12.19
				&& (this.DataInputSystem	== target.DataInputSystem)
				//----- h.ueno add---------- end   2007.12.19
				&& (this.SlipPrtKind		== target.SlipPrtKind)
				&& (this.SlipPrtSetPaperId	== target.SlipPrtSetPaperId)
				&& (this.PrinterMngNo		== target.PrinterMngNo));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="slipOutputSet1">
        ///                    ��r����SlipOutputSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="slipOutputSet2">��r����SlipOutputSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipOutputSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SlipOutputSet slipOutputSet1, SlipOutputSet slipOutputSet2)
        {
            return ((slipOutputSet1.CreateDateTime		== slipOutputSet2.CreateDateTime)
				&& (slipOutputSet1.UpdateDateTime		== slipOutputSet2.UpdateDateTime)
				&& (slipOutputSet1.EnterpriseCode		== slipOutputSet2.EnterpriseCode)
				&& (slipOutputSet1.FileHeaderGuid		== slipOutputSet2.FileHeaderGuid)
				&& (slipOutputSet1.UpdEmployeeCode		== slipOutputSet2.UpdEmployeeCode)
				&& (slipOutputSet1.UpdAssemblyId1		== slipOutputSet2.UpdAssemblyId1)
				&& (slipOutputSet1.UpdAssemblyId2		== slipOutputSet2.UpdAssemblyId2)
				&& (slipOutputSet1.LogicalDeleteCode	== slipOutputSet2.LogicalDeleteCode)
                //&& (slipOutputSet1.SectionCode			== slipOutputSet2.SectionCode)      // DEL 2008/06/20
			    //--- ADD 2008/06/19 ---------->>>>>
                && (slipOutputSet1.WarehouseCode        == slipOutputSet2.WarehouseCode)
                //--- ADD 2008/06/19 ----------<<<<<
                && (slipOutputSet1.CashRegisterNo == slipOutputSet2.CashRegisterNo)
				//----- h.ueno add---------- start 2007.12.19
				&& (slipOutputSet1.DataInputSystem		== slipOutputSet2.DataInputSystem)
				//----- h.ueno add---------- end   2007.12.19			
				&& (slipOutputSet1.SlipPrtKind			== slipOutputSet2.SlipPrtKind)
				&& (slipOutputSet1.SlipPrtSetPaperId	== slipOutputSet2.SlipPrtSetPaperId)
				&& (slipOutputSet1.PrinterMngNo			== slipOutputSet2.PrinterMngNo));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SlipOutputSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipOutputSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SlipOutputSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime		!= target.CreateDateTime)		resList.Add("CreateDateTime");
            if (this.UpdateDateTime		!= target.UpdateDateTime)		resList.Add("UpdateDateTime");
            if (this.EnterpriseCode		!= target.EnterpriseCode)		resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid		!= target.FileHeaderGuid)		resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode	!= target.UpdEmployeeCode)		resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1		!= target.UpdAssemblyId1)		resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2		!= target.UpdAssemblyId2)		resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode	!= target.LogicalDeleteCode)	resList.Add("LogicalDeleteCode");
            //if (this.SectionCode		!= target.SectionCode)			resList.Add("SectionCode");         // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            if (this.WarehouseCode      != target.WarehouseCode)        resList.Add("WarehouseCode");
            //--- ADD 2008/06/19 ----------<<<<<
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
			//----- h.ueno add---------- start 2007.12.19
			if (this.DataInputSystem	!= target.DataInputSystem)		resList.Add("DataInputSystem");			
			//----- h.ueno add---------- end   2007.12.19
			if (this.SlipPrtKind		!= target.SlipPrtKind)			resList.Add("SlipPrtKind");
			if (this.SlipPrtSetPaperId	!= target.SlipPrtSetPaperId)	resList.Add("SlipPrtSetPaperId");
			if (this.PrinterMngNo		!= target.PrinterMngNo)			resList.Add("PrinterMngNo");

            return resList;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="slipOutputSet1">��r����SlipOutputSet�N���X�̃C���X�^���X</param>
        /// <param name="slipOutputSet2">��r����SlipOutputSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipOutputSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SlipOutputSet slipOutputSet1, SlipOutputSet slipOutputSet2)
        {
            ArrayList resList = new ArrayList();
            if (slipOutputSet1.CreateDateTime		!= slipOutputSet2.CreateDateTime)		resList.Add("CreateDateTime");
            if (slipOutputSet1.UpdateDateTime		!= slipOutputSet2.UpdateDateTime)		resList.Add("UpdateDateTime");
            if (slipOutputSet1.EnterpriseCode		!= slipOutputSet2.EnterpriseCode)		resList.Add("EnterpriseCode");
            if (slipOutputSet1.FileHeaderGuid		!= slipOutputSet2.FileHeaderGuid)		resList.Add("FileHeaderGuid");
            if (slipOutputSet1.UpdEmployeeCode		!= slipOutputSet2.UpdEmployeeCode)		resList.Add("UpdEmployeeCode");
            if (slipOutputSet1.UpdAssemblyId1		!= slipOutputSet2.UpdAssemblyId1)		resList.Add("UpdAssemblyId1");
            if (slipOutputSet1.UpdAssemblyId2		!= slipOutputSet2.UpdAssemblyId2)		resList.Add("UpdAssemblyId2");
            if (slipOutputSet1.LogicalDeleteCode	!= slipOutputSet2.LogicalDeleteCode)	resList.Add("LogicalDeleteCode");
            //if (slipOutputSet1.SectionCode          != slipOutputSet2.SectionCode)          resList.Add("SectionCode");       // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            if (slipOutputSet1.WarehouseCode != slipOutputSet2.WarehouseCode) resList.Add("WarehouseCode");
            //--- ADD 2008/06/19 ----------<<<<<
            if (slipOutputSet1.CashRegisterNo != slipOutputSet2.CashRegisterNo) resList.Add("CashRegisterNo");
			//----- h.ueno add---------- start 2007.12.19
			if (slipOutputSet1.DataInputSystem		!= slipOutputSet2.DataInputSystem)		resList.Add("DataInputSystem");
			//----- h.ueno add---------- end   2007.12.19
			if (slipOutputSet1.SlipPrtKind			!= slipOutputSet2.SlipPrtKind)			resList.Add("SlipPrtKind");
			if (slipOutputSet1.SlipPrtSetPaperId	!= slipOutputSet2.SlipPrtSetPaperId)	resList.Add("SlipPrtSetPaperId");
			if (slipOutputSet1.PrinterMngNo			!= slipOutputSet2.PrinterMngNo)			resList.Add("PrinterMngNo");

            return resList;
        }

		//----- h.ueno add---------- start 2007.12.19
        /// <summary>�f�[�^���̓V�X�e�����X�g</summary>
        public static SortedList _dataInputSystemList;
        
        /// <summary>�f�[�^���̓V�X�e�����X�g�i�R���{�{�b�N�X�p�j</summary>
        public static SortedList _dataInputSystemComboList;
        //----- h.ueno add---------- end   2007.12.19

		/// <summary>�`�[�����ʃ��X�g</summary>
        //>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu DEL
        //public static SortedList _slipPrtKindList;
        //>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu ADD
        public static DictionaryList _slipPrtKindList;

		/// <summary>���_�R�[�h���X�g</summary>
		public static SortedList _sectionCodeList;

        //--- ADD 2008/06/20 --------->>>>>
        public static SortedList _warehouseCodeList;
        //--- ADD 2008/06/20 --------->>>>>

		/// <summary>�`�[����ݒ�p���[ID���X�g</summary>
		public static SortedList _slipPrtSetPaperIdList;
		
		/// <summary>�v�����^�Ǘ�No���X�g</summary>
		public static SortedList _printerMngNoList;
		
		/// <summary>
		/// �\�[�g���X�g���̎擾����
		/// </summary>
		/// <param name="code">�\�[�g���X�g�R�[�h</param>
		/// <returns>����</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g���X�g�R�[�h����\�[�g���X�g���̂��擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
        public static string GetSortedListNm(object code, DictionaryList sList)
        {
            string retStr = "";

            if (sList.ContainsKey((int)code))
            {
                retStr = sList[(int)code].ToString();
            }

            return retStr;
        }

        /// <summary>
        /// �\�[�g���X�g���̎擾����(string)
        /// </summary>
        /// <param name="code">�\�[�g���X�g�R�[�h</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : string�^�̃\�[�g���X�g�R�[�h����\�[�g���X�g���̂��擾���܂��B</br>
        /// <br>Programmer : 30365 �{�Á@�⎟�Y</br>
        /// <br>Date       : 2008.12.08</br>
        /// </remarks>
        public static string GetSortedListNm(object code, SortedList sList)
        {
            string retStr = "";

            if (sList.ContainsKey(code))
            {
                retStr = sList[code].ToString();
            }
            return retStr;
        }


		//----- h.ueno add---------- start 2007.12.19
		/// <summary>
		/// �f�[�^���̓V�X�e�����`�[�����ʊ֘A�`�F�b�N
		/// </summary>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>
		/// <returns>�`�F�b�N���ʁitrue:�֘A�L��, false:�֘A�����j</returns>
		/// <remarks>
		/// <br>Note	   : �f�[�^���̓V�X�e���Ɠ`�[�����ʂ̊֘A�����`�F�b�N����</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
		public static bool DataInputSystemSlipPrtKindCheck(int dataInputSystem, int slipPrtKind)
		{
			bool retBool = false;

			switch (dataInputSystem)
			{
				case 0:	// ����
					{
						retBool = true;	// �S�Ă̓`�[�����ʐݒ��
						break;
					}
				case 1:	// ����
				case 2:	// ���
					{
						switch (slipPrtKind)
						{
							case 10:	// ���Ϗ�
							case 20:	// �w����
							case 21:	// ���菑
							case 30:	// �[�i��
								{
									retBool = true;		// �ݒ��
									break;
								}
							default:	// ��L�ȊO
								{
									retBool = false;	// �ݒ�s��
									break;
								}
						}
						break;
					}
				case 3:	// �Ԕ�
					{
						switch (slipPrtKind)
						{
							case 10:	// ���Ϗ�
							case 20:	// �w����
								{
									retBool = true;		// �ݒ��
									break;
								}
							default:	// ��L�ȊO
								{
									retBool = false;	// �ݒ�s��
									break;
								}
						}
						break;
					}
			}
			return retBool;
		}
		//----- h.ueno add---------- end   2007.12.19
		
		/// <summary>
		/// �ÓI�R���X�g���N�^
		/// </summary>
		static SlipOutputSet()
		{
			//----- h.ueno add---------- start 2007.12.19
			_dataInputSystemList = MakeDataInputSystemList();
			//----- h.ueno add---------- end   2007.12.19

			_slipPrtKindList = MakeSlipPrtKindList();
		}

		/// <summary>
		/// �`�[�����ʃ��X�g����
		/// </summary>
		/// <returns>�`�[�����ʃ��X�g</returns>
		/// <remarks>
		/// <br>Note	   : �`�[�����ʃ��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
        #region [2008/12/08 G.Miyatsu DEL]
        //private static SortedList MakeSlipPrtKindList()
        //{
        //    SortedList retSortedList = new SortedList();
        #endregion
        private static DictionaryList MakeSlipPrtKindList()
        {
            DictionaryList retSortedList = new DictionaryList();
            retSortedList.Add(10, "���Ϗ�");
            /* --- ADD 2008/11/10 ------------------------------------------------------------>>>>>
            // DEL 2008/10/09 �s��Ή�[6429] ---------->>>>>
            //retSortedList.Add(20,  "�w����");
            //retSortedList.Add(21,  "���菑");
            // DEL 2008/10/09 �s��Ή�[6429] ----------<<<<<
            retSortedList.Add(30,  "�[�i��");
            //retSortedList.Add(40, "�ԕi�`�[");         // DEL 2008/10/09 �s��Ή�[6429]
            //----- h.ueno del ---------- start 2008.03.17
            //retSortedList.Add(100, "���[�N�V�[�g");
            //retSortedList.Add(110, "�{�f�B���@�}");
            //----- h.ueno del ---------- end 2008.03.17
               --- DEL 2008/11/10 ------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/10 ------------------------------------------------------------>>>>>
            retSortedList.Add(30, "����`�[");          // �[�i��������`�[�ɕύX
            retSortedList.Add(120, "�󒍓`�[");
            retSortedList.Add(130, "�ݏo�`�[");
            retSortedList.Add(140, "���ϓ`�[");
            retSortedList.Add(150, "�݌Ɉړ��`�[");
            retSortedList.Add(160, "�t�n�d�`�[");
            // --- ADD 2008/11/10 ------------------------------------------------------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu ADD
            retSortedList.Add(50, "���v������");
            retSortedList.Add(60, "���א�����");
            retSortedList.Add(70, "�`�[���v������");
            retSortedList.Add(80, "�̎���");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<2008/12/08 G.Miyatsu ADD
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            retSortedList.Add( 99, "���[" );
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
            return retSortedList;
		}

		//----- h.ueno add---------- start 2007.12.19
		/// <summary>
		/// �f�[�^���̓V�X�e�����X�g����
		/// </summary>
		/// <returns>�f�[�^���̓V�X�e�����X�g</returns>
		/// <remarks>
		/// <br>Note	   : �f�[�^���̓V�X�e�����X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
        private static SortedList MakeDataInputSystemList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "����");
            retSortedList.Add(1, "����");
            retSortedList.Add(2, "���");
            retSortedList.Add(3, "�Ԕ�");

            return retSortedList;
        }


		//----- h.ueno add---------- end   2007.12.19
    }
}
