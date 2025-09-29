using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccItemGrp
    /// <summary>
    ///                      PCC�i�ڃO���[�v�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC�i�ڃO���[�v�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2013/05/30 30747 �O�� �L��</br>
    /// <br>                 :   2013/99/99�z�M SCM��Q��10541�Ή�</br>
    /// <br>                 :   �i�ڃO���[�v�摜�R�[�h�ǉ�</br>
    /// </remarks>
    public class PccItemGrp
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

        /// <summary>�i�ڃO���[�v����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _itemGroupName = "";

        /// <summary>�i�ڃO���[�v�\������</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int32 _itemGrpDspOdr;

        /// <summary>�X�V�敪</summary>
        /// <remarks>0:�V�K 1:�X�V 2:�폜</remarks>
        private Int32 _updateFlag;

        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�i�ڃO���[�v�摜�R�[�h</summary>
        /// <remarks>1:ItemGrpImg01.png, 2:ItemGrpImg02.png �c</remarks>
        private Int16 _itemGrpImgCode;
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  ItemGroupName
        /// <summary>�i�ڃO���[�v���̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemGroupName
        {
            get { return _itemGroupName; }
            set { _itemGroupName = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr
        /// <summary>�i�ڃO���[�v�\�����ʃv���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr
        {
            get { return _itemGrpDspOdr; }
            set { _itemGrpDspOdr = value; }
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

        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  ItemGrpImgCode
        /// <summary>�i�ڃO���[�v�摜�R�[�h</summary>
        /// <value>1:ItemGrpImg01.png, 2:ItemGrpImg02.png �c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�摜�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ItemGrpImgCode
        {
            get { return _itemGrpImgCode; }
            set { _itemGrpImgCode = value; }
        }
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccItemGrp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemGrp()
        {
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^�R���X�g���N�^
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
        /// <param name="itemGroupName">�i�ڃO���[�v����((���p�S�p����))</param>
        /// <param name="itemGrpDspOdr">�i�ڃO���[�v�\������(�����珇��1�`5)</param>
        /// <param name="itemGrpImgCode">�i�ڃO���[�v�摜�R�[�h</param>
        /// <param name="updateFlag">�X�V�敪(0:�V�K 1:�X�V 2:�폜)</param>
        /// <returns>PccItemGrp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //public PccItemGrp(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, Int32 itemGroupCode, string itemGroupName, Int32 itemGrpDspOdr, Int32 updateFlag)
        public PccItemGrp(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, Int32 itemGroupCode, string itemGroupName, Int32 itemGrpDspOdr, Int32 updateFlag, Int16 itemGrpImgCode)
        // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
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
            this._itemGroupName = itemGroupName;
            this._itemGrpDspOdr = itemGrpDspOdr;
            this._updateFlag = updateFlag;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._itemGrpImgCode = itemGrpImgCode;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^��������
        /// </summary>
        /// <returns>PccItemGrp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccItemGrp�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemGrp Clone()
        {
            // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return new PccItemGrp(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._itemGroupCode, this._itemGroupName, this._itemGrpDspOdr, this._updateFlag);
            return new PccItemGrp(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._itemGroupCode, this._itemGroupName, this._itemGrpDspOdr, this._updateFlag, this._itemGrpImgCode);//@@@@20230303
            // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccItemGrp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccItemGrp target)
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
                 && (this.ItemGroupName == target.ItemGroupName)
                 && (this.ItemGrpDspOdr == target.ItemGrpDspOdr)
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (this.UpdateFlag == target.UpdateFlag));
                 && (this.UpdateFlag == target.UpdateFlag)
                 && (this.ItemGrpImgCode == target.ItemGrpImgCode)
                 );
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^��r����
        /// </summary>
        /// <param name="pccItemGrp1">
        ///                    ��r����PccItemGrp�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccItemGrp2">��r����PccItemGrp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccItemGrp pccItemGrp1, PccItemGrp pccItemGrp2)
        {
            return ((pccItemGrp1.CreateDateTime == pccItemGrp2.CreateDateTime)
                 && (pccItemGrp1.UpdateDateTime == pccItemGrp2.UpdateDateTime)
                 && (pccItemGrp1.LogicalDeleteCode == pccItemGrp2.LogicalDeleteCode)
                 && (pccItemGrp1.InqOriginalEpCd.Trim() == pccItemGrp2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccItemGrp1.InqOriginalSecCd == pccItemGrp2.InqOriginalSecCd)
                 && (pccItemGrp1.InqOtherEpCd == pccItemGrp2.InqOtherEpCd)
                 && (pccItemGrp1.InqOtherSecCd == pccItemGrp2.InqOtherSecCd)
                 && (pccItemGrp1.InqCondition == pccItemGrp2.InqCondition)
                 && (pccItemGrp1.PccCompanyCode == pccItemGrp2.PccCompanyCode)
                 && (pccItemGrp1.ItemGroupCode == pccItemGrp2.ItemGroupCode)
                 && (pccItemGrp1.ItemGroupName == pccItemGrp2.ItemGroupName)
                 && (pccItemGrp1.ItemGrpDspOdr == pccItemGrp2.ItemGrpDspOdr)
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (pccItemGrp1.UpdateFlag == pccItemGrp2.UpdateFlag));
                 && (pccItemGrp1.UpdateFlag == pccItemGrp2.UpdateFlag)
                 && (pccItemGrp1.ItemGrpImgCode == pccItemGrp2.ItemGrpImgCode)
                 );
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccItemGrp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrp�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccItemGrp target)
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
            if (this.ItemGroupName != target.ItemGroupName) resList.Add("ItemGroupName");
            if (this.ItemGrpDspOdr != target.ItemGrpDspOdr) resList.Add("ItemGrpDspOdr");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.ItemGrpImgCode != target.ItemGrpImgCode) resList.Add("ItemGrpImgCode");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// PCC�i�ڃO���[�v�}�X�^��r����
        /// </summary>
        /// <param name="pccItemGrp1">��r����PccItemGrp�N���X�̃C���X�^���X</param>
        /// <param name="pccItemGrp2">��r����PccItemGrp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrp�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccItemGrp pccItemGrp1, PccItemGrp pccItemGrp2)
        {
            ArrayList resList = new ArrayList();
            if (pccItemGrp1.CreateDateTime != pccItemGrp2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccItemGrp1.UpdateDateTime != pccItemGrp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccItemGrp1.LogicalDeleteCode != pccItemGrp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccItemGrp1.InqOriginalEpCd.Trim() != pccItemGrp2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccItemGrp1.InqOriginalSecCd != pccItemGrp2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccItemGrp1.InqOtherEpCd != pccItemGrp2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccItemGrp1.InqOtherSecCd != pccItemGrp2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccItemGrp1.InqCondition != pccItemGrp2.InqCondition) resList.Add("InqCondition");
            if (pccItemGrp1.PccCompanyCode != pccItemGrp2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccItemGrp1.ItemGroupCode != pccItemGrp2.ItemGroupCode) resList.Add("ItemGroupCode");
            if (pccItemGrp1.ItemGroupName != pccItemGrp2.ItemGroupName) resList.Add("ItemGroupName");
            if (pccItemGrp1.ItemGrpDspOdr != pccItemGrp2.ItemGrpDspOdr) resList.Add("ItemGrpDspOdr");
            if (pccItemGrp1.UpdateFlag != pccItemGrp2.UpdateFlag) resList.Add("UpdateFlag");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (pccItemGrp1.ItemGrpImgCode != pccItemGrp2.ItemGrpImgCode) resList.Add("ItemGrpImgCode");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
