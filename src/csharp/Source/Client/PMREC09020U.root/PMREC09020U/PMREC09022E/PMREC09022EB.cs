//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���������i�ݒ�}�X�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RecBgnGds
    /// <summary>
    ///                      ���������i�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���������i�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2015/02/20</br>
    /// <br>Genarated Date   :   2015/02/20  (CSharp File Generated Date)</br>
    /// </remarks>
    public class RecBgnGds
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i���[�J�[����</summary>
        private string _goodsMakerNm = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i�R�����g</summary>
        private string _goodsComment = "";

        /// <summary>Ұ����]�������i</summary>
        private Int64 _mkrSuggestRtPric;

        /// <summary>�艿</summary>
        private Int64 _listPrice;

        /// <summary>�P���Z�o�|��</summary>
        private Double _unitCalcRate;

        /// <summary>�P��</summary>
        private Int64 _unitPrice;

        /// <summary>���J�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>���J�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>�K���Ԏ�敪</summary>
        /// <remarks>0�Ȃ��A1�F����</remarks>
        private Int16 _modelFitDiv;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        /// <remarks>(PM�ŗ��p)</remarks>
        private Int32 _custRateGrpCode;

        /// <summary>�\���敪</summary>
        /// <remarks>0:�\���A1:��\��</remarks>
        private Int32 _displayDivCode;

        /// <summary>���������i�O���[�v�R�[�h</summary>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>���i�摜</summary>
        private byte[] _goodsImage = new Byte[0];

        /// <summary>�s��</summary>
        private Int32 _rowIndex;

        /// <summary>�V�K�s�t���O</summary>
        private Boolean _isUpdRow;

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

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
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
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>���i���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsComment
        /// <summary>���i�R�����g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�����g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsComment
        {
            get { return _goodsComment; }
            set { _goodsComment = value; }
        }

        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>Ұ����]�������i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ұ����]�������i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
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
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitCalcRate
        /// <summary>�P���Z�o�|���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double UnitCalcRate
        {
            get { return _unitCalcRate; }
            set { _unitCalcRate = value; }
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
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ModelFitDiv
        /// <summary>�K���Ԏ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K���Ԏ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ModelFitDiv
        {
            get { return _modelFitDiv; }
            set { _modelFitDiv = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  DisplayDivCode
        /// <summary>�\���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>���������i�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }

        /// public propaty name  :  GoodsImage
        /// <summary>���i�摜�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�摜�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public byte[] GoodsImage
        {
            get { return _goodsImage; }
            set { _goodsImage = value; }
        }       

        /// public propaty name  :  RowIndex
        /// <summary>�s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        /// public propaty name  :  IsUpdRow
        /// <summary>�V�K�s�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�K�s�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsUpdRow
        {
            get { return _isUpdRow; }
            set { _isUpdRow = value; }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>RecBgnGds�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGds�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecBgnGds()
        {
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����</param>
        /// <param name="updateDateTime">�X�V����</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsMakerNm">���i���[�J�[����</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsComment">���i�R�����g</param>
        /// <param name="mkrSuggestRtPric">Ұ����]�������i</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="unitCalcRate">�P���Z�o�|��</param>
        /// <param name="unitPrice">�P��</param>
        /// <param name="applyStaDate">�K�p�J�n��</param>
        /// <param name="applyEndDate">�K�p�I����</param>
        /// <param name="modelFitDiv">�K���Ԏ�敪</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="displayDivCode">�\���敪</param>
        /// <param name="brgnGoodsGrpCode">���������i�O���[�v�R�[�h</param>
        /// <param name="soodsImage">���i�摜</param>
        /// <param name="rowIndex">�s��</param>
        /// <param name="isUpdRow">�V�K�s�t���O</param>
        /// <returns>RecBgnGds�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGds�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecBgnGds(
            DateTime createDateTime,
            DateTime updateDateTime,
            Int32 logicalDeleteCode,
            string inqOtherEpCd,
            string inqOtherSecCd,
            string goodsNo,
            Int32 goodsMakerCd,
            string goodsMakerNm,
            string goodsName,
            Int32 bLGroupCode,
            Int32 bLGoodsCode,
            string goodsComment,
            Int64 mkrSuggestRtPric,
            Int64 listPrice,
            Double unitCalcRate,
            Int64 unitPrice,
            Int32 applyStaDate,
            Int32 applyEndDate,
            Int16 modelFitDiv,
            Int32 custRateGrpCode,
            Int32 displayDivCode,
            Int16 brgnGoodsGrpCode,
            byte[] goodsImage,
            Int32 rowIndex,
            Boolean isUpdRow
        )
        {
            this.CreateDateTime = createDateTime;           // �쐬����
            this.UpdateDateTime = updateDateTime;           // �X�V����
            this._logicalDeleteCode = logicalDeleteCode;    // �_���폜�敪
            this._inqOtherEpCd = inqOtherEpCd;              // �⍇�����ƃR�[�h      
            this._inqOtherSecCd = inqOtherSecCd;            // �⍇���拒�_�R�[�h
            this._goodsNo = goodsNo;                        // ���i�ԍ�
            this._goodsMakerCd = goodsMakerCd;              // ���i���[�J�[�R�[�h
            this._goodsMakerNm = goodsMakerNm;              // ���i���[�J�[����
            this._goodsName = goodsName;                    // ���i����
            this._bLGroupCode = bLGroupCode;                // BL�O���[�v�R�[�h
            this._bLGoodsCode = bLGoodsCode;                // BL���i�R�[�h
            this._goodsComment = goodsComment;              // ���i�R�����g
            this._mkrSuggestRtPric = mkrSuggestRtPric;      // Ұ����]�������i
            this._listPrice = listPrice;                    // �艿
            this._unitCalcRate = unitCalcRate;              // �P���Z�o�|��
            this._unitPrice = unitPrice;                    // �P��
            this._applyStaDate = applyStaDate;              // �K�p�J�n��
            this._applyEndDate = applyEndDate;              // �K�p�I����
            this._modelFitDiv = modelFitDiv;                // �K���Ԏ�敪
            this._custRateGrpCode = custRateGrpCode;        // ���Ӑ�|���O���[�v�R�[�h
            this._displayDivCode = displayDivCode;          // �\���敪
            this._brgnGoodsGrpCode = brgnGoodsGrpCode;      // ���������i�O���[�v�R�[�h
            this._goodsImage = goodsImage;                  // ���i�摜
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^��������
        /// </summary>
        /// <returns>RecBgnGds�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RecBgnGds�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecBgnGds Clone()
        {
            return new RecBgnGds(
                this._createDateTime, 
                this._updateDateTime, 
                this._logicalDeleteCode, 
                this._inqOtherEpCd, 
                this._inqOtherSecCd, 
                this._goodsNo,
                this._goodsMakerCd, 
                this._goodsMakerNm,
                this._goodsName, 
                this._bLGroupCode, 
                this._bLGoodsCode, 
                this._goodsComment, 
                this._mkrSuggestRtPric, 
                this._listPrice,
                this._unitCalcRate,
                this._unitPrice, 
                this._applyStaDate, 
                this._applyEndDate, 
                this._modelFitDiv,
                this._custRateGrpCode,
                this._displayDivCode,
                this._brgnGoodsGrpCode,
                this._goodsImage, 
                this._rowIndex, 
                this._isUpdRow
            );
        }
    }
}