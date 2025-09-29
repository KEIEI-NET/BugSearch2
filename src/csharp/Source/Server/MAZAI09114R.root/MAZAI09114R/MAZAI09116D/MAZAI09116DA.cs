using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockMngTtlStWork
	/// <summary>
	///                      �݌ɊǗ��S�̐ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɊǗ��S�̐ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/17</br>
	/// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2009/12/02 ��r��</br>
    /// <br>                     PM.NS-4</br>
    /// <br>                     �I���^�p�敪�̒ǉ�</br>
    /// <br>Update Note      :   2011/08/29 ���J</br>
    /// <br>                     �A�� 1016 �u���݌ɕ\���敪�v���ɒǉ��@</br>
    /// <br>Update Note      :   2012/06/08 lanl</br>
    /// <br>                     #Redmine30282 �u�I���f�[�^�폜�敪�v���ɒǉ��@</br>
    /// <br>Update Note      :   2012/07/02 �O�ˁ@�L��</br>
    /// <br>                     �u�ړ����݌Ɏ����o�^�敪�v����ʂɒǉ��@</br>
    /// <br>Update Note      :   2014/10/27 wangf </br>
    /// <br>                 :   Redmine#43854��ʂɗ�u�ړ��`�[�o�͐�敪�v�ǉ�</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockMngTtlStWork : IFileHeader
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
		/// <remarks>�I�[���O�͑S��</remarks>
		private string _sectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		private string _sectionGuideNm = "";

		/// <summary>�݌Ɉړ��m��敪</summary>
		/// <remarks>1�F�o�׊m�肠��A�Q�F�o�׊m��Ȃ�</remarks>
		private Int32 _stockMoveFixCode;

		/// <summary>�݌ɕ]�����@</summary>
		/// <remarks>1:�ŏI�d�������@,2:�ړ����ϖ@</remarks>
		private Int32 _stockPointWay;

        /// <summary>�[�������敪</summary>
        /// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
        private Int32 _fractionProcCd;

        // --- ADD 2009/12/02 ---------->>>>>
        /// <summary>�I���^�p�敪</summary>
        /// <remarks>0�F�o�l�D�m�r,2�F�o�l�V</remarks>
        private Int32 _inventoryMngDiv;
        // --- ADD 2009/12/02 ----------<<<<<

        /// <summary>�݌ɐ؂�o�׋敪</summary>
		/// <remarks>0:����,1:�x��,2:�x��+�ē���,3:�ē��� �i�݌ɐ؂�`�F�b�N)</remarks>
		private Int32 _stockTolerncShipmDiv;

		/// <summary>�I������������ݒ�敪</summary>
		/// <remarks>0:�I�ԏ� 1:�d���揇 2:BL���ޏ� 3:Ұ�����ޏ� 4:�d���楒I�ԏ� 5:�d����Ұ���� �i�I���L���\�A���ٕ\�Ŏg�p�j</remarks>
		private Int32 _invntryPrtOdrIniDiv;

		/// <summary>�ō��݌ɐ����������敪</summary>
		/// <remarks>0:���Ȃ�(�ō��݌ɐ��܂�)�@1:����(�ō��݌ɂ𒴂����ŏ�ۯ�)�����_�������ō��݌ɐ��𒴂��Ĕ����f�[�^���쐬���邩�ۂ�</remarks>
		private Int32 _maxStkCntOverOderDiv;

		/// <summary>�I�ԏd���敪</summary>
		/// <remarks>0:�\ 1:�s�@�@���s��1�i��1�I�ŊǗ�</remarks>
		private Int32 _shelfNoDuplDiv;

		/// <summary>���b�g�g�p�敪</summary>
		/// <remarks>0:�������b�g(�݌Ƀ}�X�^)�@1:���ʃ��b�g(���i�}�X�^)�������ꗗ�\</remarks>
		private Int32 _lotUseDivCd;

		/// <summary>���_�\���敪</summary>
		/// <remarks>0:�q��Ͻ��@1:����Ͻ��@2:�\������</remarks>
		private Int32 _sectDspDivCd;

        // -------------- ADD 2011/08/29 ----------------- >>>>>
        /// <summary>���݌ɕ\���敪</summary>
        /// <remarks>0:�󒍕��܂� 1:�󒍕��܂܂Ȃ�</remarks>
        private Int32 _preStckCntDspDiv;
        // -------------- ADD 2011/08/29 ----------------- <<<<<

        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
        /// <summary>�I���f�[�^�폜�敪</summary>
        /// <remarks>0:�\ 1:�\(���_�w��\) 2:�s��</remarks>
        private Int32 _invntryDtDelDiv;
        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<

        // --- ADD �O�� 2012/07/02 ---------->>>>>
        // �ړ����݌Ɏ����o�^�敪
        private Int32 _moveStockAutoInsDiv;
        // --- ADD �O�� 2012/07/02 ----------<<<<<

        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
        // �ړ��`�[�o�͐�敪
        private Int32 _moveSlipOutPutDiv;
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<

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
		/// <value>�I�[���O�͑S��</value>
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

		/// public propaty name  :  SectionGuideNm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  StockMoveFixCode
		/// <summary>�݌Ɉړ��m��敪�v���p�e�B</summary>
		/// <value>1�F�o�׊m�肠��A�Q�F�o�׊m��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌Ɉړ��m��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockMoveFixCode
		{
			get{return _stockMoveFixCode;}
			set{_stockMoveFixCode = value;}
		}
        
  		/// public propaty name  :  StockPointWay
		/// <summary>�݌ɕ]�����@�v���p�e�B</summary>
		/// <value>1:�ŏI�d�������@,2:�ړ����ϖ@</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɕ]�����@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockPointWay
		{
			get{return _stockPointWay;}
			set{_stockPointWay = value;}
		}

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������v���p�e�B</summary>
        /// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        // --- ADD 2009/12/02 ---------->>>>>
        /// public propaty name  :  InventoryMngDiv
        /// <summary>�I���^�p�敪�v���p�e�B</summary>
        /// <value>0�F�o�l�D�m�r,1�F�o�l�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���^�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }
        // --- ADD 2009/12/02 ----------<<<<<

        /// public propaty name  :  StockTolerncShipmDiv
		/// <summary>�݌ɐ؂�o�׋敪�v���p�e�B</summary>
		/// <value>0:����,1:�x��,2:�x��+�ē���,3:�ē��� �i�݌ɐ؂�`�F�b�N)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɐ؂�o�׋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockTolerncShipmDiv
		{
			get{return _stockTolerncShipmDiv;}
			set{_stockTolerncShipmDiv = value;}
		}

		/// public propaty name  :  InvntryPrtOdrIniDiv
		/// <summary>�I������������ݒ�敪�v���p�e�B</summary>
		/// <value>0:�I�ԏ� 1:�d���揇 2:BL���ޏ� 3:Ұ�����ޏ� 4:�d���楒I�ԏ� 5:�d����Ұ���� �i�I���L���\�A���ٕ\�Ŏg�p�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I������������ݒ�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InvntryPrtOdrIniDiv
		{
			get{return _invntryPrtOdrIniDiv;}
			set{_invntryPrtOdrIniDiv = value;}
		}

		/// public propaty name  :  MaxStkCntOverOderDiv
		/// <summary>�ō��݌ɐ����������敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�(�ō��݌ɐ��܂�)�@1:����(�ō��݌ɂ𒴂����ŏ�ۯ�)�����_�������ō��݌ɐ��𒴂��Ĕ����f�[�^���쐬���邩�ۂ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ō��݌ɐ����������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MaxStkCntOverOderDiv
		{
			get{return _maxStkCntOverOderDiv;}
			set{_maxStkCntOverOderDiv = value;}
		}

		/// public propaty name  :  ShelfNoDuplDiv
		/// <summary>�I�ԏd���敪�v���p�e�B</summary>
		/// <value>0:�\ 1:�s�@�@���s��1�i��1�I�ŊǗ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԏd���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShelfNoDuplDiv
		{
			get{return _shelfNoDuplDiv;}
			set{_shelfNoDuplDiv = value;}
		}

		/// public propaty name  :  LotUseDivCd
		/// <summary>���b�g�g�p�敪�v���p�e�B</summary>
		/// <value>0:�������b�g(�݌Ƀ}�X�^)�@1:���ʃ��b�g(���i�}�X�^)�������ꗗ�\</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���b�g�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LotUseDivCd
		{
			get{return _lotUseDivCd;}
			set{_lotUseDivCd = value;}
		}

		/// public propaty name  :  SectDspDivCd
		/// <summary>���_�\���敪�v���p�e�B</summary>
		/// <value>0:�q��Ͻ��@1:����Ͻ��@2:�\������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SectDspDivCd
		{
			get{return _sectDspDivCd;}
			set{_sectDspDivCd = value;}
		}

        // ---------------- ADD 2011/08/29 ------------------ >>>>>
        /// public propaty name  :  PreStckCntDspDiv
        /// <summary>���݌ɕ\���敪�v���p�e�B</summary>
        /// <value>0:�󒍕��܂� 1:�󒍕��܂܂Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PreStckCntDspDiv
        {
            get { return _preStckCntDspDiv; }
            set { _preStckCntDspDiv = value; }
        }
        // ---------------- ADD 2011/08/29 ------------------ <<<<<

        // ---------------- ADD lanl 2012/06/08 Redmine#30282 ------------------ >>>>>
        /// public propaty name  :  InvntryDtDelDiv
        /// <summary>�I���f�[�^�폜�敪�v���p�e�B</summary>
        /// <value>0:�\ 1:�\(���_�w��\) 2:�s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���f�[�^�폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InvntryDtDelDiv
        {
            get { return _invntryDtDelDiv; }
            set { _invntryDtDelDiv = value; }
        }
        // ---------------- ADD lanl 2012/06/08 Redmine#30282 ------------------ <<<<<

        // --- ADD �O�� 2012/07/02 ---------->>>>>
        /// public propaty name  :  MoveStockAutoInsDiv
        /// <summary>�ړ����݌Ɏ����o�^�敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����݌Ɏ����o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveStockAutoInsDiv
        {
            get { return _moveStockAutoInsDiv; }
            set { _moveStockAutoInsDiv = value; }
        }
        // --- ADD �O�� 2012/07/02 ----------<<<<<
        
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
        /// public propaty name  :  MoveSlipOutPutDiv
        /// <summary>�ړ��`�[�o�͐�敪�v���p�e�B</summary>
        /// <value>0:���ɑq�� 1:�o�ɑq��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��`�[�o�͐�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveSlipOutPutDiv
        {
            get { return _moveSlipOutPutDiv; }
            set { _moveSlipOutPutDiv = value; }
        }
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<
        
        /// <summary>
		/// �݌ɊǗ��S�̐ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockMngTtlStWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockMngTtlStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockMngTtlStWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMngTtlStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMngTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockMngTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMngTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMngTtlStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMngTtlStWork || graph is ArrayList || graph is StockMngTtlStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockMngTtlStWork).FullName));

            if (graph != null && graph is StockMngTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMngTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMngTtlStWork[])graph).Length;
            }
            else if (graph is StockMngTtlStWork)
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
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�݌Ɉړ��m��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFixCode
            //�݌ɕ]�����@
            serInfo.MemberInfo.Add(typeof(Int32)); //StockPointWay
            //�[������
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            // --- ADD 2009/12/02 ---------->>>>>
            // �I���^�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryMngDiv
            // --- ADD 2009/12/02 ----------<<<<<
            //�݌ɐ؂�o�׋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockTolerncShipmDiv
            //�I������������ݒ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InvntryPrtOdrIniDiv
            //�ō��݌ɐ����������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MaxStkCntOverOderDiv
            //�I�ԏd���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShelfNoDuplDiv
            //���b�g�g�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LotUseDivCd
            //���_�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SectDspDivCd
            // ----------------- ADD 2011/08/29 -------------------- >>>>>
            //���݌ɕ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PreStckCntDspDiv
            // ----------------- ADD 2011/08/29 -------------------- <<<<<
            // ----------------- ADD lanl 2012/06/08 Redmine#30282 -------------------- >>>>>
            //�I���f�[�^�폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InvntryDtDelDiv
            // ----------------- ADD lanl 2012/06/08 Redmine#30282 -------------------- <<<<<
            // --- ADD �O�� 2012/07/02 ---------->>>>>
            // �ړ����݌Ɏ����o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStockAutoInsDiv
            // --- ADD �O�� 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveSlipOutPutDiv
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is StockMngTtlStWork)
            {
                StockMngTtlStWork temp = (StockMngTtlStWork)graph;

                SetStockMngTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMngTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMngTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMngTtlStWork temp in lst)
                {
                    SetStockMngTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMngTtlStWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 21;//DEL lanl 2012/06/08 Redmine#30282
        //private const int currentMemberCount = 22;//ADD lanl 2012/06/08 Redmine#30282 //DEL �O�� 2012/07/02
        //private const int currentMemberCount = 23;//ADD �O�� 2012/07/02 // DEL wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�
        private const int currentMemberCount = 24; // ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�

        /// <summary>
        ///  StockMngTtlStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMngTtlStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockMngTtlStWork(System.IO.BinaryWriter writer, StockMngTtlStWork temp)
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
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�݌Ɉړ��m��敪
            writer.Write(temp.StockMoveFixCode);
            //�݌ɕ]�����@
            writer.Write(temp.StockPointWay);
            //�[������
            writer.Write(temp.FractionProcCd);
            // --- ADD 2009/12/02 ---------->>>>>
            // �I���^�p�敪
            writer.Write(temp.InventoryMngDiv);
            // --- ADD 2009/12/02 ----------<<<<<
            //�݌ɐ؂�o�׋敪
            writer.Write(temp.StockTolerncShipmDiv);
            //�I������������ݒ�敪
            writer.Write(temp.InvntryPrtOdrIniDiv);
            //�ō��݌ɐ����������敪
            writer.Write(temp.MaxStkCntOverOderDiv);
            //�I�ԏd���敪
            writer.Write(temp.ShelfNoDuplDiv);
            //���b�g�g�p�敪
            writer.Write(temp.LotUseDivCd);
            //���_�\���敪
            writer.Write(temp.SectDspDivCd);
            // ---------------- ADD 2011/08/29 ----------------- >>>>>
            //���݌ɕ\���敪
            writer.Write(temp.PreStckCntDspDiv);
            // ---------------- ADD 2011/08/29 ----------------- <<<<<
            // ---------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
            //�I���f�[�^�폜�敪
            writer.Write(temp.InvntryDtDelDiv);
            // ---------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<
            // --- ADD �O�� 2012/07/02 ---------->>>>>
            // �ړ����݌Ɏ����o�^�敪
            writer.Write(temp.MoveStockAutoInsDiv);
            // --- ADD �O�� 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
            // �ړ��`�[�o�͐�敪
            writer.Write(temp.MoveSlipOutPutDiv);
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<

        }

        /// <summary>
        ///  StockMngTtlStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMngTtlStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMngTtlStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockMngTtlStWork GetStockMngTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockMngTtlStWork temp = new StockMngTtlStWork();

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
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�݌Ɉړ��m��敪
            temp.StockMoveFixCode = reader.ReadInt32();
            //�݌ɕ]�����@
            temp.StockPointWay = reader.ReadInt32();
            //�[������
            temp.FractionProcCd = reader.ReadInt32();
            // --- ADD 2009/12/02 ---------->>>>>
            // �I���^�p�敪
            temp.InventoryMngDiv = reader.ReadInt32();
            // --- ADD 2009/12/02 ----------<<<<<
            //�݌ɐ؂�o�׋敪
            temp.StockTolerncShipmDiv = reader.ReadInt32();
            //�I������������ݒ�敪
            temp.InvntryPrtOdrIniDiv = reader.ReadInt32();
            //�ō��݌ɐ����������敪
            temp.MaxStkCntOverOderDiv = reader.ReadInt32();
            //�I�ԏd���敪
            temp.ShelfNoDuplDiv = reader.ReadInt32();
            //���b�g�g�p�敪
            temp.LotUseDivCd = reader.ReadInt32();
            //���_�\���敪
            temp.SectDspDivCd = reader.ReadInt32();
            // ------------------ ADD 2011/08/29 ------------------ >>>>>
            //���݌ɕ\���敪
            temp.PreStckCntDspDiv = reader.ReadInt32();
            // ------------------ ADD 2011/08/29 ------------------ <<<<<
            // ------------------ ADD lanl 2012/06/08 Redmine#30282 ------------------ >>>>>
            //�I���f�[�^�폜�敪
            temp.InvntryDtDelDiv = reader.ReadInt32();
            // ------------------ ADD lanl 2012/06/08 Redmine#30282 ------------------ <<<<<
            // --- ADD �O�� 2012/07/02 ---------->>>>>
            // �ړ����݌Ɏ����o�^�敪
            temp.MoveStockAutoInsDiv = reader.ReadInt32();
            // --- ADD �O�� 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�--------->>>>
            // �ړ��`�[�o�͐�敪
            temp.MoveSlipOutPutDiv = reader.ReadInt32();
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 ��u�ړ��`�[�o�͐�敪�v�ǉ�---------<<<<

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
        /// <returns>StockMngTtlStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMngTtlStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMngTtlStWork temp = GetStockMngTtlStWork(reader, serInfo);
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
                    retValue = (StockMngTtlStWork[])lst.ToArray(typeof(StockMngTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}