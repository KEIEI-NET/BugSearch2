using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccItemSt
    /// <summary>
    ///                      PCC�i�ڐݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC�i�ڐݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccItemSt
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

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�⍇������</summary>
        private string _inqCondition = "";

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>�i�ڃO���[�v�R�[�h</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode;

        /// <summary>�i�ڕ\���ʒu1</summary>
        /// <remarks>��(X)�����̈ʒu 0�`Z</remarks>
        private Int32 _itemDspPos1;

        /// <summary>�i�ڕ\���ʒu2</summary>
        /// <remarks>�c(Y)�����̈ʒu 0�`</remarks>
        private Int32 _itemDspPos2;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i��</summary>
        private string _bLGoodsName = "";

        /// <summary>�i��QTY</summary>
        private Int32 _itemQty;

        /// <summary>�i�ڑI���敪</summary>
        /// <remarks>0:OFF 1:�I����޳�\��</remarks>
        private Int32 _itemSelectDiv;

        /// <summary>�X�V�敪</summary>
        /// <remarks>0:�V�K 1:�X�V 2:�폜</remarks>
        private Int32 _updateFlag;


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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
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
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
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

        /// public propaty name  :  InqCondition
        /// <summary>�⍇�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqCondition
        {
            get { return _inqCondition; }
            set { _inqCondition = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h�v���p�e�B</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  ItemGroupCode
        /// <summary>�i�ڃO���[�v�R�[�h�v���p�e�B</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode
        {
            get { return _itemGroupCode; }
            set { _itemGroupCode = value; }
        }

        /// public propaty name  :  ItemDspPos1
        /// <summary>�i�ڕ\���ʒu1�v���p�e�B</summary>
        /// <value>��(X)�����̈ʒu 0�`Z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڕ\���ʒu1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemDspPos1
        {
            get { return _itemDspPos1; }
            set { _itemDspPos1 = value; }
        }

        /// public propaty name  :  ItemDspPos2
        /// <summary>�i�ڕ\���ʒu2�v���p�e�B</summary>
        /// <value>�c(Y)�����̈ʒu 0�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڕ\���ʒu2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemDspPos2
        {
            get { return _itemDspPos2; }
            set { _itemDspPos2 = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  ItemQty
        /// <summary>�i��QTY�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��QTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemQty
        {
            get { return _itemQty; }
            set { _itemQty = value; }
        }

        /// public propaty name  :  ItemSelectDiv
        /// <summary>�i�ڑI���敪�v���p�e�B</summary>
        /// <value>0:OFF 1:�I����޳�\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڑI���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemSelectDiv
        {
            get { return _itemSelectDiv; }
            set { _itemSelectDiv = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>�X�V�敪�v���p�e�B</summary>
        /// <value>0:�V�K 1:�X�V 2:�폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }


        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemSt()
        {
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="inqCondition">�⍇������</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="itemGroupCode">�i�ڃO���[�v�R�[�h(1�`5�̎g�p��z��)</param>
        /// <param name="itemDspPos1">�i�ڕ\���ʒu1(��(X)�����̈ʒu 0�`Z)</param>
        /// <param name="itemDspPos2">�i�ڕ\���ʒu2(�c(Y)�����̈ʒu 0�`)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsName">BL���i��</param>
        /// <param name="itemQty">�i��QTY</param>
        /// <param name="itemSelectDiv">�i�ڑI���敪(0:OFF 1:�I����޳�\��)</param>
        /// <param name="updateFlag">�X�V�敪(0:�V�K 1:�X�V 2:�폜)</param>
        /// <returns>PccItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, Int32 itemGroupCode, Int32 itemDspPos1, Int32 itemDspPos2, Int32 bLGoodsCode, string bLGoodsName, Int32 itemQty, Int32 itemSelectDiv, Int32 updateFlag)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inqCondition = inqCondition;
            this._pccCompanyCode = pccCompanyCode;
            this._itemGroupCode = itemGroupCode;
            this._itemDspPos1 = itemDspPos1;
            this._itemDspPos2 = itemDspPos2;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsName = bLGoodsName;
            this._itemQty = itemQty;
            this._itemSelectDiv = itemSelectDiv;
            this._updateFlag = updateFlag;

        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^��������
        /// </summary>
        /// <returns>PccItemSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccItemSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemSt Clone()
        {
            return new PccItemSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._itemGroupCode, this._itemDspPos1, this._itemDspPos2, this._bLGoodsCode, this._bLGoodsName, this._itemQty, this._itemSelectDiv, this._updateFlag);//@@@@20230303
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccItemSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccItemSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InqCondition == target.InqCondition)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.ItemGroupCode == target.ItemGroupCode)
                 && (this.ItemDspPos1 == target.ItemDspPos1)
                 && (this.ItemDspPos2 == target.ItemDspPos2)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.ItemQty == target.ItemQty)
                 && (this.ItemSelectDiv == target.ItemSelectDiv)
                 && (this.UpdateFlag == target.UpdateFlag));
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccItemSt1">
        ///                    ��r����PccItemSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccItemSt2">��r����PccItemSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccItemSt pccItemSt1, PccItemSt pccItemSt2)
        {
            return ((pccItemSt1.CreateDateTime == pccItemSt2.CreateDateTime)
                 && (pccItemSt1.UpdateDateTime == pccItemSt2.UpdateDateTime)
                 && (pccItemSt1.LogicalDeleteCode == pccItemSt2.LogicalDeleteCode)
                 && (pccItemSt1.InqOriginalEpCd.Trim() == pccItemSt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccItemSt1.InqOriginalSecCd == pccItemSt2.InqOriginalSecCd)
                 && (pccItemSt1.InqOtherEpCd == pccItemSt2.InqOtherEpCd)
                 && (pccItemSt1.InqOtherSecCd == pccItemSt2.InqOtherSecCd)
                 && (pccItemSt1.InqCondition == pccItemSt2.InqCondition)
                 && (pccItemSt1.PccCompanyCode == pccItemSt2.PccCompanyCode)
                 && (pccItemSt1.ItemGroupCode == pccItemSt2.ItemGroupCode)
                 && (pccItemSt1.ItemDspPos1 == pccItemSt2.ItemDspPos1)
                 && (pccItemSt1.ItemDspPos2 == pccItemSt2.ItemDspPos2)
                 && (pccItemSt1.BLGoodsCode == pccItemSt2.BLGoodsCode)
                 && (pccItemSt1.BLGoodsName == pccItemSt2.BLGoodsName)
                 && (pccItemSt1.ItemQty == pccItemSt2.ItemQty)
                 && (pccItemSt1.ItemSelectDiv == pccItemSt2.ItemSelectDiv)
                 && (pccItemSt1.UpdateFlag == pccItemSt2.UpdateFlag));
        }
        /// <summary>
        /// PCC�i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccItemSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccItemSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InqCondition != target.InqCondition) resList.Add("InqCondition");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.ItemGroupCode != target.ItemGroupCode) resList.Add("ItemGroupCode");
            if (this.ItemDspPos1 != target.ItemDspPos1) resList.Add("ItemDspPos1");
            if (this.ItemDspPos2 != target.ItemDspPos2) resList.Add("ItemDspPos2");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.ItemQty != target.ItemQty) resList.Add("ItemQty");
            if (this.ItemSelectDiv != target.ItemSelectDiv) resList.Add("ItemSelectDiv");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccItemSt1">��r����PccItemSt�N���X�̃C���X�^���X</param>
        /// <param name="pccItemSt2">��r����PccItemSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccItemSt pccItemSt1, PccItemSt pccItemSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccItemSt1.CreateDateTime != pccItemSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccItemSt1.UpdateDateTime != pccItemSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccItemSt1.LogicalDeleteCode != pccItemSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccItemSt1.InqOriginalEpCd.Trim() != pccItemSt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccItemSt1.InqOriginalSecCd != pccItemSt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccItemSt1.InqOtherEpCd != pccItemSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccItemSt1.InqOtherSecCd != pccItemSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccItemSt1.InqCondition != pccItemSt2.InqCondition) resList.Add("InqCondition");
            if (pccItemSt1.PccCompanyCode != pccItemSt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccItemSt1.ItemGroupCode != pccItemSt2.ItemGroupCode) resList.Add("ItemGroupCode");
            if (pccItemSt1.ItemDspPos1 != pccItemSt2.ItemDspPos1) resList.Add("ItemDspPos1");
            if (pccItemSt1.ItemDspPos2 != pccItemSt2.ItemDspPos2) resList.Add("ItemDspPos2");
            if (pccItemSt1.BLGoodsCode != pccItemSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (pccItemSt1.BLGoodsName != pccItemSt2.BLGoodsName) resList.Add("BLGoodsName");
            if (pccItemSt1.ItemQty != pccItemSt2.ItemQty) resList.Add("ItemQty");
            if (pccItemSt1.ItemSelectDiv != pccItemSt2.ItemSelectDiv) resList.Add("ItemSelectDiv");
            if (pccItemSt1.UpdateFlag != pccItemSt2.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }
    }
}
