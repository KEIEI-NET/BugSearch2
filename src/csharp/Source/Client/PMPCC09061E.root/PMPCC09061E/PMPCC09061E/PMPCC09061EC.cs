using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCpItmSt
    /// <summary>
    ///                      PCC�L�����y�[���i�ڐݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC�L�����y�[���i�ڐݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccCpItmSt
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

        /// <summary>�L�����y�[���R�[�h</summary>
        private Int32 _campaignCode;

        /// <summary>�L�����y�[���ݒ�敪</summary>
        /// <remarks>0:BL�R�[�h,1:�i��</remarks>
        private Int32 _campStDiv;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _goodsNameKana = "";

        /// <summary>�i��QTY</summary>
        private Int32 _itemQty;

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

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampStDiv
        /// <summary>�L�����y�[���ݒ�敪�v���p�e�B</summary>
        /// <value>0:BL�R�[�h,1:�i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampStDiv
        {
            get { return _campStDiv; }
            set { _campStDiv = value; }
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

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
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
        /// <value>(���p�S�p����)</value>
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
        /// PCC�L�����y�[���i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccCpItmSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpItmSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCpItmSt()
        {
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <param name="campStDiv">�L�����y�[���ݒ�敪(0:BL�R�[�h,1:�i��)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsName">���i����((���p�S�p����))</param>
        /// <param name="goodsNameKana">���i���̃J�i((���p�S�p����))</param>
        /// <param name="itemQty">�i��QTY</param>
        /// <param name="updateFlag">�X�V�敪(0:�V�K 1:�X�V 2:�폜)</param>
        /// <returns>PccCpItmSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpItmSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCpItmSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOtherEpCd, string inqOtherSecCd, Int32 campaignCode, Int32 campStDiv, Int32 bLGoodsCode, string goodsNo, Int32 goodsMakerCd, string goodsName, string goodsNameKana, Int32 itemQty, Int32 updateFlag)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._campaignCode = campaignCode;
            this._campStDiv = campStDiv;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._itemQty = itemQty;
            this._updateFlag = updateFlag;

        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^��������
        /// </summary>
        /// <returns>PccCpItmSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccCpItmSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCpItmSt Clone()
        {
            return new PccCpItmSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOtherEpCd, this._inqOtherSecCd, this._campaignCode, this._campStDiv, this._bLGoodsCode, this._goodsNo, this._goodsMakerCd, this._goodsName, this._goodsNameKana, this._itemQty, this._updateFlag);
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCpItmSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpItmSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccCpItmSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampStDiv == target.CampStDiv)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.ItemQty == target.ItemQty)
                 && (this.UpdateFlag == target.UpdateFlag));
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCpItmSt1">
        ///                    ��r����PccCpItmSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccCpItmSt2">��r����PccCpItmSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpItmSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccCpItmSt pccCpItmSt1, PccCpItmSt pccCpItmSt2)
        {
            return ((pccCpItmSt1.CreateDateTime == pccCpItmSt2.CreateDateTime)
                 && (pccCpItmSt1.UpdateDateTime == pccCpItmSt2.UpdateDateTime)
                 && (pccCpItmSt1.LogicalDeleteCode == pccCpItmSt2.LogicalDeleteCode)
                 && (pccCpItmSt1.InqOtherEpCd == pccCpItmSt2.InqOtherEpCd)
                 && (pccCpItmSt1.InqOtherSecCd == pccCpItmSt2.InqOtherSecCd)
                 && (pccCpItmSt1.CampaignCode == pccCpItmSt2.CampaignCode)
                 && (pccCpItmSt1.CampStDiv == pccCpItmSt2.CampStDiv)
                 && (pccCpItmSt1.BLGoodsCode == pccCpItmSt2.BLGoodsCode)
                 && (pccCpItmSt1.GoodsNo == pccCpItmSt2.GoodsNo)
                 && (pccCpItmSt1.GoodsMakerCd == pccCpItmSt2.GoodsMakerCd)
                 && (pccCpItmSt1.GoodsName == pccCpItmSt2.GoodsName)
                 && (pccCpItmSt1.GoodsNameKana == pccCpItmSt2.GoodsNameKana)
                 && (pccCpItmSt1.ItemQty == pccCpItmSt2.ItemQty)
                 && (pccCpItmSt1.UpdateFlag == pccCpItmSt2.UpdateFlag));
        }
        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCpItmSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpItmSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccCpItmSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampStDiv != target.CampStDiv) resList.Add("CampStDiv");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.ItemQty != target.ItemQty) resList.Add("ItemQty");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }

        /// <summary>
        /// PCC�L�����y�[���i�ڐݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCpItmSt1">��r����PccCpItmSt�N���X�̃C���X�^���X</param>
        /// <param name="pccCpItmSt2">��r����PccCpItmSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpItmSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccCpItmSt pccCpItmSt1, PccCpItmSt pccCpItmSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCpItmSt1.CreateDateTime != pccCpItmSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCpItmSt1.UpdateDateTime != pccCpItmSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCpItmSt1.LogicalDeleteCode != pccCpItmSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCpItmSt1.InqOtherEpCd != pccCpItmSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCpItmSt1.InqOtherSecCd != pccCpItmSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCpItmSt1.CampaignCode != pccCpItmSt2.CampaignCode) resList.Add("CampaignCode");
            if (pccCpItmSt1.CampStDiv != pccCpItmSt2.CampStDiv) resList.Add("CampStDiv");
            if (pccCpItmSt1.BLGoodsCode != pccCpItmSt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (pccCpItmSt1.GoodsNo != pccCpItmSt2.GoodsNo) resList.Add("GoodsNo");
            if (pccCpItmSt1.GoodsMakerCd != pccCpItmSt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (pccCpItmSt1.GoodsName != pccCpItmSt2.GoodsName) resList.Add("GoodsName");
            if (pccCpItmSt1.GoodsNameKana != pccCpItmSt2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (pccCpItmSt1.ItemQty != pccCpItmSt2.ItemQty) resList.Add("ItemQty");
            if (pccCpItmSt1.UpdateFlag != pccCpItmSt2.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }
    }
}
