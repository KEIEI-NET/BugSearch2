using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMoveListResultWork
    /// <summary>
    ///                      �݌ɁE�q�Ɉړ��m�F�\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɁE�q�Ɉړ��m�F�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMoveListResultWork
    {
        /// <summary>�ړ������_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>�ړ������_�K�C�h����</summary>
        private string _bfSectionGuideSnm = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>�ړ����q�ɖ���</summary>
        private string _bfEnterWarehName = "";

        /// <summary>�ړ����I��</summary>
        private string _bfShelfNo = "";

        /// <summary>�o�ח\���</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentScdlDay;

        /// <summary>�o�׊m���</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentFixDay;

        /// <summary>���ד�</summary>
        /// <remarks>�݌Ɉړ������i���ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>�݌Ɉړ��s�ԍ�</summary>
        private Int32 _stockMoveRowNo;

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>�ړ��拒�_�K�C�h����</summary>
        private string _afSectionGuideSnm = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _afEnterWarehCode = "";

        /// <summary>�ړ���q�ɖ���</summary>
        private string _afEnterWarehName = "";

        /// <summary>�ړ���I��</summary>
        private string _afShelfNo = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�艿�i�����j</summary>
        private Double _listPriceFl;

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�ړ���</summary>
        private Double _moveCount;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�q�ɔ��l1</summary>
        /// <remarks>�݌Ɉړ����̈ړ��`�[�ɏo�͂�����l���Z�b�g</remarks>
        private string _warehouseNote1 = "";

        /// <summary>�q�ɔ��l2</summary>
        /// <remarks>�@�V</remarks>
        private string _warehouseNote2 = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</remarks>
        private string _outline = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�`�[���s�ϋ敪</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>�ړ����z</summary>
        private Int64 _stockMovePrice;

        /// <summary>�݌Ɉړ��`��</summary>
        private Int32 _stockMoveFormal;


        /// public propaty name  :  BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideSnm
        /// <summary>�ړ������_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionGuideSnm
        {
            get { return _bfSectionGuideSnm; }
            set { _bfSectionGuideSnm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  BfShelfNo
        /// <summary>�ړ����I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfShelfNo
        {
            get { return _bfShelfNo; }
            set { _bfShelfNo = value; }
        }

        /// public propaty name  :  ShipmentScdlDay
        /// <summary>�o�ח\����v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentScdlDay
        {
            get { return _shipmentScdlDay; }
            set { _shipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentFixDay
        /// <summary>�o�׊m����v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׊m����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentFixDay
        {
            get { return _shipmentFixDay; }
            set { _shipmentFixDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// <value>�݌Ɉړ������i���ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveRowNo
        /// <summary>�݌Ɉړ��s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveRowNo
        {
            get { return _stockMoveRowNo; }
            set { _stockMoveRowNo = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideSnm
        /// <summary>�ړ��拒�_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionGuideSnm
        {
            get { return _afSectionGuideSnm; }
            set { _afSectionGuideSnm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  AfShelfNo
        /// <summary>�ړ���I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfShelfNo
        {
            get { return _afShelfNo; }
            set { _afShelfNo = value; }
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

        /// public propaty name  :  ListPriceFl
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  MoveCount
        /// <summary>�ړ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveCount
        {
            get { return _moveCount; }
            set { _moveCount = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
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

        /// public propaty name  :  WarehouseNote1
        /// <summary>�q�ɔ��l1�v���p�e�B</summary>
        /// <value>�݌Ɉړ����̈ړ��`�[�ɏo�͂�����l���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote1
        {
            get { return _warehouseNote1; }
            set { _warehouseNote1 = value; }
        }

        /// public propaty name  :  WarehouseNote2
        /// <summary>�q�ɔ��l2�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote2
        {
            get { return _warehouseNote2; }
            set { _warehouseNote2 = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// <value>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
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

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  StockMovePrice
        /// <summary>�ړ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMovePrice
        {
            get { return _stockMovePrice; }
            set { _stockMovePrice = value; }
        }

        /// public propaty name  :  StockMoveFormal
        /// <summary>�݌Ɉړ��`���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveFormal
        {
            get { return _stockMoveFormal; }
            set { _stockMoveFormal = value; }
        }


        /// <summary>
        /// �݌ɁE�q�Ɉړ��m�F�\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMoveListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMoveListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMoveListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMoveListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockMoveListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMoveListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMoveListResultWork || graph is ArrayList || graph is StockMoveListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockMoveListResultWork).FullName));

            if (graph != null && graph is StockMoveListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMoveListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMoveListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMoveListResultWork[])graph).Length;
            }
            else if (graph is StockMoveListResultWork)
            {

                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�ړ������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //�ړ������_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionGuideSnm
            //�ړ����q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //�ړ����q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //�ړ����I��
            serInfo.MemberInfo.Add(typeof(string)); //BfShelfNo
            //�o�ח\���
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlDay
            //�o�׊m���
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�݌Ɉړ��`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //�݌Ɉړ��s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveRowNo
            //�ړ��拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //�ړ��拒�_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionGuideSnm
            //�ړ���q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //�ړ���q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //�ړ���I��
            serInfo.MemberInfo.Add(typeof(string)); //AfShelfNo
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //�d���P���i�Ŕ�,�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�ړ���
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCount
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�q�ɔ��l1
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNote1
            //�q�ɔ��l2
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNote2
            //�`�[�E�v
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //�`�[���s�ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintFinishCd
            //�ړ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePrice
            //�݌Ɉړ��`��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFormal


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMoveListResultWork)
            {
                StockMoveListResultWork temp = (StockMoveListResultWork)graph;

                SetStockMoveListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMoveListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMoveListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMoveListResultWork temp in lst)
                {
                    SetStockMoveListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMoveListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  StockMoveListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockMoveListResultWork(System.IO.BinaryWriter writer, StockMoveListResultWork temp)
        {
            //�ړ������_�R�[�h
            writer.Write(temp.BfSectionCode);
            //�ړ������_�K�C�h����
            writer.Write(temp.BfSectionGuideSnm);
            //�ړ����q�ɃR�[�h
            writer.Write(temp.BfEnterWarehCode);
            //�ړ����q�ɖ���
            writer.Write(temp.BfEnterWarehName);
            //�ړ����I��
            writer.Write(temp.BfShelfNo);
            //�o�ח\���
            writer.Write((Int64)temp.ShipmentScdlDay.Ticks);
            //�o�׊m���
            writer.Write((Int64)temp.ShipmentFixDay.Ticks);
            //���ד�
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //�݌Ɉړ��`�[�ԍ�
            writer.Write(temp.StockMoveSlipNo);
            //�݌Ɉړ��s�ԍ�
            writer.Write(temp.StockMoveRowNo);
            //�ړ��拒�_�R�[�h
            writer.Write(temp.AfSectionCode);
            //�ړ��拒�_�K�C�h����
            writer.Write(temp.AfSectionGuideSnm);
            //�ړ���q�ɃR�[�h
            writer.Write(temp.AfEnterWarehCode);
            //�ړ���q�ɖ���
            writer.Write(temp.AfEnterWarehName);
            //�ړ���I��
            writer.Write(temp.AfShelfNo);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�艿�i�����j
            writer.Write(temp.ListPriceFl);
            //�d���P���i�Ŕ�,�����j
            writer.Write(temp.StockUnitPriceFl);
            //�ړ���
            writer.Write(temp.MoveCount);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�q�ɔ��l1
            writer.Write(temp.WarehouseNote1);
            //�q�ɔ��l2
            writer.Write(temp.WarehouseNote2);
            //�`�[�E�v
            writer.Write(temp.Outline);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //�`�[���s�ϋ敪
            writer.Write(temp.SlipPrintFinishCd);
            //�ړ����z
            writer.Write(temp.StockMovePrice);
            //�݌Ɉړ��`��
            writer.Write(temp.StockMoveFormal);

        }

        /// <summary>
        ///  StockMoveListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMoveListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockMoveListResultWork GetStockMoveListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockMoveListResultWork temp = new StockMoveListResultWork();

            //�ړ������_�R�[�h
            temp.BfSectionCode = reader.ReadString();
            //�ړ������_�K�C�h����
            temp.BfSectionGuideSnm = reader.ReadString();
            //�ړ����q�ɃR�[�h
            temp.BfEnterWarehCode = reader.ReadString();
            //�ړ����q�ɖ���
            temp.BfEnterWarehName = reader.ReadString();
            //�ړ����I��
            temp.BfShelfNo = reader.ReadString();
            //�o�ח\���
            temp.ShipmentScdlDay = new DateTime(reader.ReadInt64());
            //�o�׊m���
            temp.ShipmentFixDay = new DateTime(reader.ReadInt64());
            //���ד�
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //�݌Ɉړ��`�[�ԍ�
            temp.StockMoveSlipNo = reader.ReadInt32();
            //�݌Ɉړ��s�ԍ�
            temp.StockMoveRowNo = reader.ReadInt32();
            //�ړ��拒�_�R�[�h
            temp.AfSectionCode = reader.ReadString();
            //�ړ��拒�_�K�C�h����
            temp.AfSectionGuideSnm = reader.ReadString();
            //�ړ���q�ɃR�[�h
            temp.AfEnterWarehCode = reader.ReadString();
            //�ړ���q�ɖ���
            temp.AfEnterWarehName = reader.ReadString();
            //�ړ���I��
            temp.AfShelfNo = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�艿�i�����j
            temp.ListPriceFl = reader.ReadDouble();
            //�d���P���i�Ŕ�,�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�ړ���
            temp.MoveCount = reader.ReadDouble();
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�q�ɔ��l1
            temp.WarehouseNote1 = reader.ReadString();
            //�q�ɔ��l2
            temp.WarehouseNote2 = reader.ReadString();
            //�`�[�E�v
            temp.Outline = reader.ReadString();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //�`�[���s�ϋ敪
            temp.SlipPrintFinishCd = reader.ReadInt32();
            //�ړ����z
            temp.StockMovePrice = reader.ReadInt64();
            //�݌Ɉړ��`��
            temp.StockMoveFormal = reader.ReadInt32();


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
        /// <returns>StockMoveListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMoveListResultWork temp = GetStockMoveListResultWork(reader, serInfo);
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
                    retValue = (StockMoveListResultWork[])lst.ToArray(typeof(StockMoveListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
