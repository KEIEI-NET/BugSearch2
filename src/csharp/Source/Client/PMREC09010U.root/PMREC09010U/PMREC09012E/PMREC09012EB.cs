using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RecGoodsLkSt
    /// <summary>
    ///                      ���R�����h���i�֘A�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R�����h���i�֘A�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2015/01/20</br>
    /// </remarks>
    public class RecGoodsLkSt
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

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������BL���i�R�[�h</summary>
        private Int32 _recSourceBLGoodsCd;

        /// <summary>������BL���i�R�[�h</summary>
        private Int32 _recDestBLGoodsCd;

        /// <summary>������BL���i�R�[�h����</summary>
        private string _recDestBLGoodsNm = "";

        // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
        /// <summary>���i�R�����g</summary>
        private string _goodsComment = "";
        // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  RecSourceBLGoodsCd
        /// <summary>������BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCd
        {
            get { return _recSourceBLGoodsCd; }
            set { _recSourceBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsCd
        /// <summary>������BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecDestBLGoodsCd
        {
            get { return _recDestBLGoodsCd; }
            set { _recDestBLGoodsCd = value; }
        }

        /// public propaty name  :  RecDestBLGoodsNm
        /// <summary>������BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RecDestBLGoodsNm
        {
            get { return _recDestBLGoodsNm; }
            set { _recDestBLGoodsNm = value; }
        }

        // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
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
        // --- ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<

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
        /// ���R�����h���i�֘A�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>RecGoodsLk�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLk�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecGoodsLkSt()
        {
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="InqOriginalEpCdRF">�⍇������ƃR�[�h</param>
        /// <param name="InqOriginalSecCdRF">�⍇�������_�R�[�h</param>
        /// <param name="InqOtherEpCdRF">�⍇�����ƃR�[�h</param>
        /// <param name="InqOtherSecCdRF">�⍇���拒�_�R�[�h</param>
        /// <param name="CustomerCodeRF">���Ӑ�R�[�h</param>
        /// <param name="RecSourceBLGoodsCdRF">������BL���i�R�[�h</param>
        /// <param name="RecDestBLGoodsCdRF">������BL���i�R�[�h</param>
        /// <param name="RecDestBLGoodsNmRF">������BL���i�R�[�h����</param>
        /// <param name="rowIndex">�s��</param>
        /// <param name="isUpdRow">�V�K�s�t���O</param>
        /// <returns>RecGoodsLk�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLk�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
        //public RecGoodsLkSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 customerCode, Int32 recSourceBLGoodsCd, Int32 recDestBLGoodsCd, string recDestBLGoodsNm, Int32 rowIndex, Boolean isUpdRow)
        public RecGoodsLkSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 customerCode, Int32 recSourceBLGoodsCd, Int32 recDestBLGoodsCd, string recDestBLGoodsNm, string goodsComment, Int32 rowIndex, Boolean isUpdRow)
        // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
        {
            this._createDateTime = createDateTime;
            this._updateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._customerCode = customerCode;
            this._recSourceBLGoodsCd = recSourceBLGoodsCd;
            this._recDestBLGoodsCd = recDestBLGoodsCd;
            this._recDestBLGoodsNm = recDestBLGoodsNm;
            this._goodsComment = goodsComment; // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
            this._rowIndex = rowIndex;
            this._isUpdRow = isUpdRow;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��������
        /// </summary>
        /// <returns>RecGoodsLk�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RecGoodsLk�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecGoodsLkSt Clone()
        {
            // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------>>>>>
            //return new RecGoodsLkSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._customerCode, this._recSourceBLGoodsCd, this._recDestBLGoodsCd, this._recDestBLGoodsNm, this._rowIndex, this._isUpdRow);
            return new RecGoodsLkSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._customerCode, this._recSourceBLGoodsCd, this._recDestBLGoodsCd, this._recDestBLGoodsNm, this._goodsComment, this._rowIndex, this._isUpdRow);
            // --- UPD 2015/02/06 T.Miyamoto �R�����g���ڒǉ� ------------------------------<<<<<
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RecGoodsLk�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLk�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(RecGoodsLkSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.RecSourceBLGoodsCd == target.RecSourceBLGoodsCd)
                 && (this.RecDestBLGoodsCd == target.RecDestBLGoodsCd)
                 && (this.RecDestBLGoodsNm == target.RecDestBLGoodsNm)
                 && (this.GoodsComment == target.GoodsComment) // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
                 && (this.RowIndex == target.RowIndex)
                 && (this.IsUpdRow == target.IsUpdRow));
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="RecGoodsLk1">��r����RecGoodsLk�N���X�̃C���X�^���X</param>
        /// <param name="RecGoodsLk2">��r����RecGoodsLk�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLk�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(RecGoodsLkSt RecGoodsLk1, RecGoodsLkSt RecGoodsLk2)
        {
            return ((RecGoodsLk1.CreateDateTime == RecGoodsLk2.CreateDateTime)
                 && (RecGoodsLk1.UpdateDateTime == RecGoodsLk2.UpdateDateTime)
                 && (RecGoodsLk1.LogicalDeleteCode == RecGoodsLk2.LogicalDeleteCode)
                 && (RecGoodsLk1.InqOriginalEpCd == RecGoodsLk2.InqOriginalEpCd)
                 && (RecGoodsLk1.InqOriginalSecCd == RecGoodsLk2.InqOriginalSecCd)
                 && (RecGoodsLk1.InqOtherEpCd == RecGoodsLk2.InqOtherEpCd)
                 && (RecGoodsLk1.InqOtherSecCd == RecGoodsLk2.InqOtherSecCd)
                 && (RecGoodsLk1.CustomerCode == RecGoodsLk2.CustomerCode)
                 && (RecGoodsLk1.RecSourceBLGoodsCd == RecGoodsLk2.RecSourceBLGoodsCd)
                 && (RecGoodsLk1.RecDestBLGoodsCd == RecGoodsLk2.RecDestBLGoodsCd)
                 && (RecGoodsLk1.RecDestBLGoodsNm == RecGoodsLk2.RecDestBLGoodsNm)
                 && (RecGoodsLk1.GoodsComment == RecGoodsLk2.GoodsComment) // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
                 && (RecGoodsLk1.RowIndex == RecGoodsLk2.RowIndex)
                 && (RecGoodsLk1.IsUpdRow == RecGoodsLk2.IsUpdRow));
        }
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RecGoodsLk�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLk�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(RecGoodsLkSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.RecSourceBLGoodsCd != target.RecSourceBLGoodsCd) resList.Add("RecSourceBLGoodsCd");
            if (this.RecDestBLGoodsCd != target.RecDestBLGoodsCd) resList.Add("RecDestBLGoodsCd");
            if (this.RecDestBLGoodsNm != target.RecDestBLGoodsNm) resList.Add("RecDestBLGoodsNm");
            if (this.GoodsComment != target.GoodsComment) resList.Add("GoodsComment"); // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
            if (this.RowIndex != target.RowIndex) resList.Add("RowIndex");
            if (this.IsUpdRow != target.IsUpdRow) resList.Add("IsUpdRow");

            return resList;
        }

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="RecGoodsLk1">��r����RecGoodsLk�N���X�̃C���X�^���X</param>
        /// <param name="RecGoodsLk2">��r����RecGoodsLk�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecGoodsLk�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(RecGoodsLkSt RecGoodsLk1, RecGoodsLkSt RecGoodsLk2)
        {
            ArrayList resList = new ArrayList();
            if (RecGoodsLk1.CreateDateTime != RecGoodsLk2.CreateDateTime) resList.Add("CreateDateTime");
            if (RecGoodsLk1.UpdateDateTime != RecGoodsLk2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (RecGoodsLk1.LogicalDeleteCode != RecGoodsLk2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (RecGoodsLk1.InqOriginalEpCd != RecGoodsLk2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (RecGoodsLk1.InqOriginalSecCd != RecGoodsLk2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (RecGoodsLk1.InqOtherEpCd != RecGoodsLk2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (RecGoodsLk1.InqOtherSecCd != RecGoodsLk2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (RecGoodsLk1.CustomerCode != RecGoodsLk2.CustomerCode) resList.Add("CustomerCode");
            if (RecGoodsLk1.RecSourceBLGoodsCd != RecGoodsLk2.RecSourceBLGoodsCd) resList.Add("RecSourceBLGoodsCd");
            if (RecGoodsLk1.RecDestBLGoodsCd != RecGoodsLk2.RecDestBLGoodsCd) resList.Add("RecDestBLGoodsCd");
            if (RecGoodsLk1.RecDestBLGoodsNm != RecGoodsLk2.RecDestBLGoodsNm) resList.Add("RecDestBLGoodsNm");
            if (RecGoodsLk1.GoodsComment != RecGoodsLk2.GoodsComment) resList.Add("GoodsComment"); // ADD 2015/02/06 T.Miyamoto �R�����g���ڒǉ�
            if (RecGoodsLk1.RowIndex != RecGoodsLk2.RowIndex) resList.Add("RowIndex");
            if (RecGoodsLk1.IsUpdRow != RecGoodsLk2.IsUpdRow) resList.Add("IsUpdRow");

            return resList;
        }
    }
}