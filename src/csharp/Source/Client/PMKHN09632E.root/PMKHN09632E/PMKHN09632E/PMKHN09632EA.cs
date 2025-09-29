//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/13  �C�����e : Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignGoodsData
    /// <summary>
    ///                      ���i�}�X�^�i���[�U�[�o�^���j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�}�X�^�i���[�U�[�o�^���j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2011/05/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/5  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �@�񋟋敪</br>
    /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
    /// </remarks>
    public class CampaignGoodsData
    {
        // ----- UPD 2011/07/13 ------- >>>>>>>>>
        /// <summary>�a�k�R�[�h(�J�n)</summary>
        //private Int32 _bLGroupCodeSt;
        private Int32 _bLGoodsCode;
        // ----- UPD 2011/07/13 ------- <<<<<<<<<

        /// <summary>�a�k�R�[�h(�I��)</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>�L�����y�[���R�[�h</summary>
        private Int32 _campaignCode;

        /// <summary>�L�����y�[���ݒ���</summary>
        /// <remarks>1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _campaignSettingKind;

        /// <summary>�L�����y�[������</summary>
        private string _campaignName = "";

        /// <summary>�L�����y�[���Ώۋ敪</summary>
        /// <remarks>0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        // ----- UPD 2011/07/13 ------- >>>>>>>>>
        /// public propaty name  :  BLGroupCodeSt
        /// <summary>�a�k�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public Int32 BLGroupCodeSt
        //{
        //    get { return _bLGroupCodeSt; }
        //    set { _bLGroupCodeSt = value; }
        //}
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }
        // ----- UPD 2011/07/13 ------- <<<<<<<<<

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>�a�k�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
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

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
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

        /// public propaty name  :  CampaignSettingKind
        /// <summary>�L�����y�[���ݒ��ʃv���p�e�B</summary>
        /// <value>1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���ݒ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignSettingKind
        {
            get { return _campaignSettingKind; }
            set { _campaignSettingKind = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>�L�����y�[�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>�L�����y�[���Ώۋ敪�v���p�e�B</summary>
        /// <value>0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
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


        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignGoodsData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public CampaignGoodsData()
        {
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�R���X�g���N�^
        /// </summary>
        /// <param name="bLGoodsCode">�a�k�R�[�h(�J�n)</param>
        /// <param name="bLGroupCodeEd">�a�k�R�[�h(�I��)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <param name="campaignSettingKind">�L�����y�[���ݒ���(1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="campaignName">�L�����y�[������</param>
        /// <param name="campaignObjDiv">�L�����y�[���Ώۋ敪(0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~)</param>
        /// <param name="applyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>CampaignGoodsData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        //public CampaignGoodsData(Int32 bLGroupCodeSt, Int32 bLGroupCodeEd, string enterpriseCode, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNoNoneHyphen, string sectionCode, Int32 campaignCode, Int32 campaignSettingKind, string campaignName, Int32 campaignObjDiv, Int32 applyStaDate, Int32 applyEndDate, string enterpriseName)
        public CampaignGoodsData(Int32 bLGoodsCode, Int32 bLGroupCodeEd, string enterpriseCode, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNoNoneHyphen, string sectionCode, Int32 campaignCode, Int32 campaignSettingKind, string campaignName, Int32 campaignObjDiv, Int32 applyStaDate, Int32 applyEndDate, string enterpriseName)
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //this._bLGroupCodeSt = bLGroupCodeSt;
            this._bLGoodsCode = bLGoodsCode;
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            this._bLGroupCodeEd = bLGroupCodeEd;
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._sectionCode = sectionCode;
            this._campaignCode = campaignCode;
            this._campaignSettingKind = campaignSettingKind;
            this._campaignName = campaignName;
            this._campaignObjDiv = campaignObjDiv;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��������
        /// </summary>
        /// <returns>CampaignGoodsData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignGoodsData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public CampaignGoodsData Clone()
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //return new CampaignGoodsData(this._bLGroupCodeSt, this._bLGroupCodeEd, this._enterpriseCode, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNoNoneHyphen, this._sectionCode, this._campaignCode, this._campaignSettingKind, this._campaignName, this._campaignObjDiv, this._applyStaDate, this._applyEndDate, this._enterpriseName);
            return new CampaignGoodsData(this._bLGoodsCode, this._bLGroupCodeEd, this._enterpriseCode, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNoNoneHyphen, this._sectionCode, this._campaignCode, this._campaignSettingKind, this._campaignName, this._campaignObjDiv, this._applyStaDate, this._applyEndDate, this._enterpriseName);
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public bool Equals(CampaignGoodsData target)
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //return ((this.BLGroupCodeSt == target.BLGroupCodeSt)
            return ((this.BLGoodsCode == target.BLGoodsCode)
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
                 && (this.BLGroupCodeEd == target.BLGroupCodeEd)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampaignSettingKind == target.CampaignSettingKind)
                 && (this.CampaignName == target.CampaignName)
                 && (this.CampaignObjDiv == target.CampaignObjDiv)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="campaignGoodsData1">
        ///                    ��r����CampaignGoodsData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignGoodsData2">��r����CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public static bool Equals(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //return ((campaignGoodsData1.BLGroupCodeSt == campaignGoodsData2.BLGroupCodeSt)
            return ((campaignGoodsData1.BLGoodsCode == campaignGoodsData2.BLGoodsCode)
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
                 && (campaignGoodsData1.BLGroupCodeEd == campaignGoodsData2.BLGroupCodeEd)
                 && (campaignGoodsData1.EnterpriseCode == campaignGoodsData2.EnterpriseCode)
                 && (campaignGoodsData1.LogicalDeleteCode == campaignGoodsData2.LogicalDeleteCode)
                 && (campaignGoodsData1.GoodsMakerCd == campaignGoodsData2.GoodsMakerCd)
                 && (campaignGoodsData1.GoodsNoNoneHyphen == campaignGoodsData2.GoodsNoNoneHyphen)
                 && (campaignGoodsData1.SectionCode == campaignGoodsData2.SectionCode)
                 && (campaignGoodsData1.CampaignCode == campaignGoodsData2.CampaignCode)
                 && (campaignGoodsData1.CampaignSettingKind == campaignGoodsData2.CampaignSettingKind)
                 && (campaignGoodsData1.CampaignName == campaignGoodsData2.CampaignName)
                 && (campaignGoodsData1.CampaignObjDiv == campaignGoodsData2.CampaignObjDiv)
                 && (campaignGoodsData1.ApplyStaDate == campaignGoodsData2.ApplyStaDate)
                 && (campaignGoodsData1.ApplyEndDate == campaignGoodsData2.ApplyEndDate)
                 && (campaignGoodsData1.EnterpriseName == campaignGoodsData2.EnterpriseName));
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public ArrayList Compare(CampaignGoodsData target)
        {
            ArrayList resList = new ArrayList();
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //if (this.BLGroupCodeSt != target.BLGroupCodeSt) resList.Add("BLGroupCodeSt");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            if (this.BLGroupCodeEd != target.BLGroupCodeEd) resList.Add("BLGroupCodeEd");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampaignSettingKind != target.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.CampaignObjDiv != target.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="campaignGoodsData1">��r����CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <param name="campaignGoodsData2">��r����CampaignGoodsData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       : 2011/07/13 杍^ Redmine#22877 BL�R�[�h�i�J�n�j�i�I���j����߂āA�P�Ǝw��ɕύX�̏C��</br>
        /// </remarks>
        public static ArrayList Compare(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            ArrayList resList = new ArrayList();
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //if (campaignGoodsData1.BLGroupCodeSt != campaignGoodsData2.BLGroupCodeSt) resList.Add("BLGroupCodeSt");
            if (campaignGoodsData1.BLGoodsCode != campaignGoodsData2.BLGoodsCode) resList.Add("BLGoodsCode");
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            if (campaignGoodsData1.BLGroupCodeEd != campaignGoodsData2.BLGroupCodeEd) resList.Add("BLGroupCodeEd");
            if (campaignGoodsData1.EnterpriseCode != campaignGoodsData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignGoodsData1.LogicalDeleteCode != campaignGoodsData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignGoodsData1.GoodsMakerCd != campaignGoodsData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignGoodsData1.GoodsNoNoneHyphen != campaignGoodsData2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (campaignGoodsData1.SectionCode != campaignGoodsData2.SectionCode) resList.Add("SectionCode");
            if (campaignGoodsData1.CampaignCode != campaignGoodsData2.CampaignCode) resList.Add("CampaignCode");
            if (campaignGoodsData1.CampaignSettingKind != campaignGoodsData2.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (campaignGoodsData1.CampaignName != campaignGoodsData2.CampaignName) resList.Add("CampaignName");
            if (campaignGoodsData1.CampaignObjDiv != campaignGoodsData2.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (campaignGoodsData1.ApplyStaDate != campaignGoodsData2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (campaignGoodsData1.ApplyEndDate != campaignGoodsData2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (campaignGoodsData1.EnterpriseName != campaignGoodsData2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
