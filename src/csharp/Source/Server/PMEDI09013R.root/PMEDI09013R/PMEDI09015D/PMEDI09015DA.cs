//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : EDI�A�g�ݒ�}�X�^�f�[�^�p�����[�^
// �v���O�����T�v   : EDI�A�g�ݒ�}�X�^�f�[�^�p�����[�^�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/16   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EDICooperatStWork
    /// <summary>
    ///                      EDI�A�g�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   EDI�A�g�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/11/16</br>
    /// <br>Genarated Date   :   2017/11/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EDICooperatStWork : IFileHeader
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
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���i����</summary>
        /// <remarks>0:�����@1:���̑�</remarks>
        private Int32 _goodsKindCode;

        /// <summary>�A�g���Ə��R�[�h</summary>
        private string _cooperatOfficeCode = "";

        /// <summary>�A�g���Ӑ�R�[�h</summary>
        private string _cooperatCustCode = "";

        /// <summary>���i���R�[�h</summary>
        private string _tradCompCd = "";

        /// <summary>���i������</summary>
        private string _tradCompName = "";

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>�l��BL���i�R�[�h</summary>
        private Int32 _increaseBLGoodsCode;

        /// <summary>�l��BL���i�R�[�h</summary>
        private Int32 _discountBLGoodsCode;


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:�����@1:���̑�</value>
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

        /// public propaty name  :  CooperatOfficeCode
        /// <summary>�A�g���Ə��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g���Ə��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CooperatOfficeCode
        {
            get { return _cooperatOfficeCode; }
            set { _cooperatOfficeCode = value; }
        }

        /// public propaty name  :  CooperatCustCode
        /// <summary>�A�g���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CooperatCustCode
        {
            get { return _cooperatCustCode; }
            set { _cooperatCustCode = value; }
        }

        /// public propaty name  :  TradCompCd
        /// <summary>���i���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TradCompCd
        {
            get { return _tradCompCd; }
            set { _tradCompCd = value; }
        }

        /// public propaty name  :  TradCompName
        /// <summary>���i�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TradCompName
        {
            get { return _tradCompName; }
            set { _tradCompName = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  IncreaseBLGoodsCode
        /// <summary>�l��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IncreaseBLGoodsCode
        {
            get { return _increaseBLGoodsCode; }
            set { _increaseBLGoodsCode = value; }
        }

        /// public propaty name  :  DiscountBLGoodsCode
        /// <summary>�l��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DiscountBLGoodsCode
        {
            get { return _discountBLGoodsCode; }
            set { _discountBLGoodsCode = value; }
        }

        /// <summary>
        /// EDI�A�g�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EDICooperatStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EDICooperatStWork()
        {
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsKindCode">���i����(0:�����@1:���̑�)</param>
        /// <param name="cooperatOfficeCode">�A�g���Ə��R�[�h</param>
        /// <param name="cooperatCustCode">�A�g���Ӑ�R�[�h</param>
        /// <param name="tradCompCd">���i���R�[�h</param>
        /// <param name="tradCompName">���i������</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="increaseBLGoodsCode">�l��BL���i�R�[�h</param>
        /// <param name="discountBLGoodsCode">�l��BL���i�R�[�h</param>
        /// <returns>EDICooperatSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EDICooperatStWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 goodsKindCode, string cooperatOfficeCode, string cooperatCustCode, string tradCompCd, string tradCompName, string goodsCode, Int32 increaseBLGoodsCode, Int32 discountBLGoodsCode)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._goodsKindCode = goodsKindCode;
            this._cooperatOfficeCode = cooperatOfficeCode;
            this._cooperatCustCode = cooperatCustCode;
            this._tradCompCd = tradCompCd;
            this._tradCompName = tradCompName;
            this._goodsCode = goodsCode;
            this._increaseBLGoodsCode = increaseBLGoodsCode;
            this._discountBLGoodsCode = discountBLGoodsCode;
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^��������
        /// </summary>
        /// <returns>EDICooperatSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����EDICooperatSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EDICooperatStWork Clone()
        {
            return new EDICooperatStWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._goodsKindCode, this._cooperatOfficeCode, this._cooperatCustCode, this._tradCompCd, this._tradCompName, this._goodsCode, this._increaseBLGoodsCode, this._discountBLGoodsCode);
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�EDICooperatSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(EDICooperatStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.CooperatOfficeCode == target.CooperatOfficeCode)
                 && (this.CooperatCustCode == target.CooperatCustCode)
                 && (this.TradCompCd == target.TradCompCd)
                 && (this.TradCompName == target.TradCompName)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.IncreaseBLGoodsCode == target.IncreaseBLGoodsCode)
                 && (this.DiscountBLGoodsCode == target.DiscountBLGoodsCode));

        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="eDICooperatSt1">
        ///                    ��r����EDICooperatSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="eDICooperatSt2">��r����EDICooperatSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(EDICooperatStWork eDICooperatSt1, EDICooperatStWork eDICooperatSt2)
        {
            return ((eDICooperatSt1.CreateDateTime == eDICooperatSt2.CreateDateTime)
                 && (eDICooperatSt1.UpdateDateTime == eDICooperatSt2.UpdateDateTime)
                 && (eDICooperatSt1.EnterpriseCode == eDICooperatSt2.EnterpriseCode)
                 && (eDICooperatSt1.FileHeaderGuid == eDICooperatSt2.FileHeaderGuid)
                 && (eDICooperatSt1.UpdEmployeeCode == eDICooperatSt2.UpdEmployeeCode)
                 && (eDICooperatSt1.UpdAssemblyId1 == eDICooperatSt2.UpdAssemblyId1)
                 && (eDICooperatSt1.UpdAssemblyId2 == eDICooperatSt2.UpdAssemblyId2)
                 && (eDICooperatSt1.LogicalDeleteCode == eDICooperatSt2.LogicalDeleteCode)
                 && (eDICooperatSt1.SectionCode == eDICooperatSt2.SectionCode)
                 && (eDICooperatSt1.CustomerCode == eDICooperatSt2.CustomerCode)
                 && (eDICooperatSt1.GoodsKindCode == eDICooperatSt2.GoodsKindCode)
                 && (eDICooperatSt1.CooperatOfficeCode == eDICooperatSt2.CooperatOfficeCode)
                 && (eDICooperatSt1.CooperatCustCode == eDICooperatSt2.CooperatCustCode)
                 && (eDICooperatSt1.TradCompCd == eDICooperatSt2.TradCompCd)
                 && (eDICooperatSt1.TradCompName == eDICooperatSt2.TradCompName)
                 && (eDICooperatSt1.GoodsCode == eDICooperatSt2.GoodsCode)
                 && (eDICooperatSt1.IncreaseBLGoodsCode == eDICooperatSt2.IncreaseBLGoodsCode)
                 && (eDICooperatSt1.DiscountBLGoodsCode == eDICooperatSt2.DiscountBLGoodsCode));
        }
        /// <summary>
        /// EDI�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�EDICooperatSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(EDICooperatStWork target)
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
            if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
            if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
            if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
            if(this.CooperatOfficeCode != target.CooperatOfficeCode)resList.Add("CooperatOfficeCode");
            if(this.CooperatCustCode != target.CooperatCustCode)resList.Add("CooperatCustCode");
            if(this.TradCompCd != target.TradCompCd)resList.Add("TradCompCd");
            if(this.TradCompName != target.TradCompName)resList.Add("TradCompName");
            if(this.GoodsCode != target.GoodsCode)resList.Add("GoodsCode");
            if(this.IncreaseBLGoodsCode != target.IncreaseBLGoodsCode)resList.Add("IncreaseBLGoodsCode");
            if(this.DiscountBLGoodsCode != target.DiscountBLGoodsCode)resList.Add("DiscountBLGoodsCode");

            return resList;
        }

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="eDICooperatSt1">��r����EDICooperatSt�N���X�̃C���X�^���X</param>
        /// <param name="eDICooperatSt2">��r����EDICooperatSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(EDICooperatStWork eDICooperatSt1, EDICooperatStWork eDICooperatSt2)
        {
            ArrayList resList = new ArrayList();
            if(eDICooperatSt1.CreateDateTime != eDICooperatSt2.CreateDateTime)resList.Add("CreateDateTime");
            if(eDICooperatSt1.UpdateDateTime != eDICooperatSt2.UpdateDateTime)resList.Add("UpdateDateTime");
            if(eDICooperatSt1.EnterpriseCode != eDICooperatSt2.EnterpriseCode)resList.Add("EnterpriseCode");
            if(eDICooperatSt1.FileHeaderGuid != eDICooperatSt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
            if(eDICooperatSt1.UpdEmployeeCode != eDICooperatSt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
            if(eDICooperatSt1.UpdAssemblyId1 != eDICooperatSt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
            if(eDICooperatSt1.UpdAssemblyId2 != eDICooperatSt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
            if(eDICooperatSt1.LogicalDeleteCode != eDICooperatSt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
            if(eDICooperatSt1.SectionCode != eDICooperatSt2.SectionCode)resList.Add("SectionCode");
            if(eDICooperatSt1.CustomerCode != eDICooperatSt2.CustomerCode)resList.Add("CustomerCode");
            if(eDICooperatSt1.GoodsKindCode != eDICooperatSt2.GoodsKindCode)resList.Add("GoodsKindCode");
            if(eDICooperatSt1.CooperatOfficeCode != eDICooperatSt2.CooperatOfficeCode)resList.Add("CooperatOfficeCode");
            if(eDICooperatSt1.CooperatCustCode != eDICooperatSt2.CooperatCustCode)resList.Add("CooperatCustCode");
            if(eDICooperatSt1.TradCompCd != eDICooperatSt2.TradCompCd)resList.Add("TradCompCd");
            if(eDICooperatSt1.TradCompName != eDICooperatSt2.TradCompName)resList.Add("TradCompName");
            if(eDICooperatSt1.GoodsCode != eDICooperatSt2.GoodsCode)resList.Add("GoodsCode");
            if(eDICooperatSt1.IncreaseBLGoodsCode != eDICooperatSt2.IncreaseBLGoodsCode)resList.Add("IncreaseBLGoodsCode");
            if(eDICooperatSt1.DiscountBLGoodsCode != eDICooperatSt2.DiscountBLGoodsCode)resList.Add("DiscountBLGoodsCode");

            return resList;
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>EDICooperatStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EDICooperatStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class EDICooperatStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EDICooperatStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EDICooperatStWork || graph is ArrayList || graph is EDICooperatStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(EDICooperatStWork).FullName));

            if (graph != null && graph is EDICooperatStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EDICooperatStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EDICooperatStWork[])graph).Length;
            }
            else if (graph is EDICooperatStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;         //�J��Ԃ���    

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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //�A�g���Ə��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CooperatOfficeCode
            //�A�g���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CooperatCustCode
            //���i���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TradCompCd
            //���i������
            serInfo.MemberInfo.Add(typeof(string)); //TradCompName
            //���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsCode
            //�l��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //IncreaseBLGoodsCode
            //�l��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //DiscountBLGoodsCode


            serInfo.Serialize(writer, serInfo);
            if (graph is EDICooperatStWork)
            {
                EDICooperatStWork temp = (EDICooperatStWork)graph;

                SetEDICooperatStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EDICooperatStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EDICooperatStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EDICooperatStWork temp in lst)
                {
                    SetEDICooperatStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EDICooperatStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  EDICooperatStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEDICooperatStWork(System.IO.BinaryWriter writer, EDICooperatStWork temp)
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
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //�A�g���Ə��R�[�h
            writer.Write(temp.CooperatOfficeCode);
            //�A�g���Ӑ�R�[�h
            writer.Write(temp.CooperatCustCode);
            //���i���R�[�h
            writer.Write(temp.TradCompCd);
            //���i������
            writer.Write(temp.TradCompName);
            //���i�R�[�h
            writer.Write(temp.GoodsCode);
            //�l��BL���i�R�[�h
            writer.Write(temp.IncreaseBLGoodsCode);
            //�l��BL���i�R�[�h
            writer.Write(temp.DiscountBLGoodsCode);

        }

        /// <summary>
        ///  EDICooperatStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EDICooperatStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private EDICooperatStWork GetEDICooperatStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EDICooperatStWork temp = new EDICooperatStWork();

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
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //�A�g���Ə��R�[�h
            temp.CooperatOfficeCode = reader.ReadString();
            //�A�g���Ӑ�R�[�h
            temp.CooperatCustCode = reader.ReadString();
            //���i���R�[�h
            temp.TradCompCd = reader.ReadString();
            //���i������
            temp.TradCompName = reader.ReadString();
            //���i�R�[�h
            temp.GoodsCode = reader.ReadString();
            //�l��BL���i�R�[�h
            temp.IncreaseBLGoodsCode = reader.ReadInt32();
            //�l��BL���i�R�[�h
            temp.DiscountBLGoodsCode = reader.ReadInt32();


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
        /// <returns>EDICooperatStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EDICooperatStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EDICooperatStWork temp = GetEDICooperatStWork(reader, serInfo);
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
                    retValue = (EDICooperatStWork[])lst.ToArray(typeof(EDICooperatStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
