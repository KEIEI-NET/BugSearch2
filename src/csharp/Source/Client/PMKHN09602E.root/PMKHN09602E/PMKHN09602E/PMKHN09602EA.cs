//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���Ǘ��}�X�^
// �v���O�����T�v   : �L�����y�[���Ǘ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignMng
    /// <summary>
    ///                      �L�����y�[���Ǘ��}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���Ǘ��}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2009/05/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :    2009/5/11  ����</br>
    /// <br>                 :   �����ڍ폜</br>
    /// <br>                 :   ���Ӑ�R�[�h</br>
    /// <br>                 :   �d����R�[�h</br>
    /// <br>                 :   BL�O���[�v�R�[�h</br>
    /// <br>Update Note      :    2009/5/13  ����</br>
    /// <br>                 :   ���^�ύX</br>
    /// <br>                 :   �L�����y�[���R�[�h</br>
    /// <br>                 :   nvarchar �� Int32</br>
    /// </remarks>
    public class CampaignMng
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
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;
        
        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
        private Int32 _campaignCode;

        /// <summary>���i�i�����j</summary>
        /// <remarks>����P���i�i�ԒP�ʂ̂ݐݒ�j</remarks>
        private Double _priceFl;

        /// <summary>�|��</summary>
        /// <remarks>������</remarks>
        private Double _rateVal;

        /// <summary>���_����</summary>
        private string _sectionNm = "";

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";
        

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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
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

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
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

        /// public propaty name  :  PriceFl
        /// <summary>���i�i�����j�v���p�e�B</summary>
        /// <value>����P���i�i�ԒP�ʂ̂ݐݒ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>�|���v���p�e�B</summary>
        /// <value>������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  SectionNm
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionNm
        {
            get { return _sectionNm; }
            set { _sectionNm = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
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

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignMng()
        {
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h(�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j)</param>
        /// <param name="priceFl">���i�i�����j(����P���i�i�ԒP�ʂ̂ݐݒ�j)</param>
        /// <param name="rateVal">�|��(������)</param>
        /// <param name="sectionNm">���_����</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="goodsMGroupName">���i�����ޖ���</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>CampaignMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignMng(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 goodsMGroup, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 goodsMakerCd, string goodsNo, Int64 salesTargetMoney, Int64 salesTargetProfit, Double salesTargetCount, Int32 campaignCode, Double priceFl, Double rateVal, string sectionNm, string goodsMGroupName, string bLGroupName, string bLGoodsName, string makerName, string goodsName, string enterpriseName, string updEmployeeName)
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
            this._goodsMGroup = goodsMGroup;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
            this._campaignCode = campaignCode;
            this._priceFl = priceFl;
            this._rateVal = rateVal;
            this._sectionNm = sectionNm;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupName = bLGroupName;
            this._bLGoodsName = bLGoodsName;
            this._makerName = makerName;
            this._goodsName = goodsName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��������
        /// </summary>
        /// <returns>CampaignMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignMng�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignMng Clone()
        {
            return new CampaignMng(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._goodsMGroup, this._bLGroupCode, this._bLGoodsCode, this._goodsMakerCd, this._goodsNo, this._salesTargetMoney, this._salesTargetProfit, this._salesTargetCount, this._campaignCode, this._priceFl, this._rateVal, this._sectionNm, this._goodsMGroupName, this._bLGroupName, this._bLGoodsName, this._makerName, this._goodsName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CampaignMng target)
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
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.PriceFl == target.PriceFl)
                 && (this.RateVal == target.RateVal)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsName == target.GoodsName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="campaignMng1">
        ///                    ��r����CampaignMng�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignMng2">��r����CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CampaignMng campaignMng1, CampaignMng campaignMng2)
        {
            return ((campaignMng1.CreateDateTime == campaignMng2.CreateDateTime)
                 && (campaignMng1.UpdateDateTime == campaignMng2.UpdateDateTime)
                 && (campaignMng1.EnterpriseCode == campaignMng2.EnterpriseCode)
                 && (campaignMng1.FileHeaderGuid == campaignMng2.FileHeaderGuid)
                 && (campaignMng1.UpdEmployeeCode == campaignMng2.UpdEmployeeCode)
                 && (campaignMng1.UpdAssemblyId1 == campaignMng2.UpdAssemblyId1)
                 && (campaignMng1.UpdAssemblyId2 == campaignMng2.UpdAssemblyId2)
                 && (campaignMng1.LogicalDeleteCode == campaignMng2.LogicalDeleteCode)
                 && (campaignMng1.SectionCode == campaignMng2.SectionCode)
                 && (campaignMng1.GoodsMGroup == campaignMng2.GoodsMGroup)
                 && (campaignMng1.BLGroupCode == campaignMng2.BLGroupCode)
                 && (campaignMng1.BLGoodsCode == campaignMng2.BLGoodsCode)
                 && (campaignMng1.GoodsMakerCd == campaignMng2.GoodsMakerCd)
                 && (campaignMng1.GoodsNo == campaignMng2.GoodsNo)
                 && (campaignMng1.SalesTargetMoney == campaignMng2.SalesTargetMoney)
                 && (campaignMng1.SalesTargetProfit == campaignMng2.SalesTargetProfit)
                 && (campaignMng1.SalesTargetCount == campaignMng2.SalesTargetCount)
                 && (campaignMng1.CampaignCode == campaignMng2.CampaignCode)
                 && (campaignMng1.PriceFl == campaignMng2.PriceFl)
                 && (campaignMng1.RateVal == campaignMng2.RateVal)
                 && (campaignMng1.SectionNm == campaignMng2.SectionNm)
                 && (campaignMng1.GoodsMGroupName == campaignMng2.GoodsMGroupName)
                 && (campaignMng1.BLGroupName == campaignMng2.BLGroupName)
                 && (campaignMng1.BLGoodsName == campaignMng2.BLGoodsName)
                 && (campaignMng1.MakerName == campaignMng2.MakerName)
                 && (campaignMng1.GoodsName == campaignMng2.GoodsName)
                 && (campaignMng1.EnterpriseName == campaignMng2.EnterpriseName)
                 && (campaignMng1.UpdEmployeeName == campaignMng2.UpdEmployeeName));
        }
        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CampaignMng target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.PriceFl != target.PriceFl) resList.Add("PriceFl");
            if (this.RateVal != target.RateVal) resList.Add("RateVal");
            if (this.SectionNm != target.SectionNm) resList.Add("SectionNm");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            
            return resList;
        }

        /// <summary>
        /// �L�����y�[���Ǘ��}�X�^��r����
        /// </summary>
        /// <param name="campaignMng1">��r����CampaignMng�N���X�̃C���X�^���X</param>
        /// <param name="campaignMng2">��r����CampaignMng�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMng�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CampaignMng campaignMng1, CampaignMng campaignMng2)
        {
            ArrayList resList = new ArrayList();
            if (campaignMng1.CreateDateTime != campaignMng2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignMng1.UpdateDateTime != campaignMng2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignMng1.EnterpriseCode != campaignMng2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignMng1.FileHeaderGuid != campaignMng2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignMng1.UpdEmployeeCode != campaignMng2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignMng1.UpdAssemblyId1 != campaignMng2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignMng1.UpdAssemblyId2 != campaignMng2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignMng1.LogicalDeleteCode != campaignMng2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignMng1.SectionCode != campaignMng2.SectionCode) resList.Add("SectionCode");
            if (campaignMng1.GoodsMGroup != campaignMng2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (campaignMng1.BLGroupCode != campaignMng2.BLGroupCode) resList.Add("BLGroupCode");
            if (campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignMng1.GoodsNo != campaignMng2.GoodsNo) resList.Add("GoodsNo");
            if (campaignMng1.SalesTargetMoney != campaignMng2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (campaignMng1.SalesTargetProfit != campaignMng2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (campaignMng1.SalesTargetCount != campaignMng2.SalesTargetCount) resList.Add("SalesTargetCount");
            if (campaignMng1.CampaignCode != campaignMng2.CampaignCode) resList.Add("CampaignCode");
            if (campaignMng1.PriceFl != campaignMng2.PriceFl) resList.Add("PriceFl");
            if (campaignMng1.RateVal != campaignMng2.RateVal) resList.Add("RateVal");
            if (campaignMng1.SectionNm != campaignMng2.SectionNm) resList.Add("SectionNm");
            if (campaignMng1.GoodsMGroupName != campaignMng2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (campaignMng1.BLGroupName != campaignMng2.BLGroupName) resList.Add("BLGroupName");
            if (campaignMng1.BLGoodsName != campaignMng2.BLGoodsName) resList.Add("BLGoodsName");
            if (campaignMng1.MakerName != campaignMng2.MakerName) resList.Add("MakerName");
            if (campaignMng1.GoodsName != campaignMng2.GoodsName) resList.Add("GoodsName");
            if (campaignMng1.EnterpriseName != campaignMng2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignMng1.UpdEmployeeName != campaignMng2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            
            return resList;
        }
    }
}

