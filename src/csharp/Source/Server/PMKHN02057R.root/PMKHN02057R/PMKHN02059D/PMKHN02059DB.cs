//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\���o���ʃN���X���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignstRsltListResultWork
    /// <summary>
    ///                      �L�����y�[�����ѕ\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[�����ѕ\���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/05/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignstRsltListResultWork : IFileHeader
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

        /// <summary>�L�����y�[���R�[�h</summary>
        private Int32 _campaignCode;

        /// <summary>�L�����y�[������</summary>
        private string _campaignName = "";

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _manageSectionCode = "";

        /// <summary>�Ǘ����_����</summary>
        private string _manageSectionSnm = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S����</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��ʗp</remarks>
        private Int32 _salesAreaCode;

        /// <summary>���[�U�[�K�C�h����</summary>
        /// <remarks>�n��ʗp</remarks>
        private string _guideName = "";

        /// <summary>�L�����y�[���Ώۋ敪</summary>
        /// <remarks>0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        private string _employeeName = "";

        /// <summary>�Ώۓ��t���ԏo�א�</summary>
        private Double _addUpShipmentCnt;

        /// <summary>�Ώۓ��t���Ԕ�����z�i�Ŕ����j</summary>
        private Int64 _addUpSalesMoneyTaxExc;

        /// <summary>�Ώۓ��t���ԑe�����z</summary>
        private Int64 _addUpSalesProfit;

        /// <summary>�L�����y�[�����ԏo�א�</summary>
        private Double _campaignShipmentCnt;

        /// <summary>�L�����y�[�����Ԕ�����z�i�Ŕ����j</summary>
        private Int64 _campaignSalesMoneyTaxExc;

        /// <summary>�L�����y�[�����ԑe�����z</summary>
        private Int64 _campaignSalesProfit;

        /// <summary>���v������z�i�Ŕ����j�P</summary>
        private Int64 _salesMoneyTaxExc1;

        /// <summary>���v������z�i�Ŕ����j�Q</summary>
        private Int64 _salesMoneyTaxExc2;

        /// <summary>���v������z�i�Ŕ����j�R</summary>
        private Int64 _salesMoneyTaxExc3;

        /// <summary>���v������z�i�Ŕ����j�S</summary>
        private Int64 _salesMoneyTaxExc4;

        /// <summary>���v������z�i�Ŕ����j�T</summary>
        private Int64 _salesMoneyTaxExc5;

        /// <summary>���v������z�i�Ŕ����j�U</summary>
        private Int64 _salesMoneyTaxExc6;

        /// <summary>���v������z�i�Ŕ����j�V</summary>
        private Int64 _salesMoneyTaxExc7;

        /// <summary>���v������z�i�Ŕ����j�W</summary>
        private Int64 _salesMoneyTaxExc8;

        /// <summary>���v������z�i�Ŕ����j�X</summary>
        private Int64 _salesMoneyTaxExc9;

        /// <summary>���v������z�i�Ŕ����j�P�O</summary>
        private Int64 _salesMoneyTaxExc10;

        /// <summary>���v������z�i�Ŕ����j�P�P</summary>
        private Int64 _salesMoneyTaxExc11;

        /// <summary>���v������z�i�Ŕ����j�P�Q</summary>
        private Int64 _salesMoneyTaxExc12;

        /// <summary>���v�o�א��P</summary>
        private Double _totalSalesCount1;

        /// <summary>���v�o�א��Q</summary>
        private Double _totalSalesCount2;

        /// <summary>���v�o�א��R</summary>
        private Double _totalSalesCount3;

        /// <summary>���v�o�א��S</summary>
        private Double _totalSalesCount4;

        /// <summary>���v�o�א��T</summary>
        private Double _totalSalesCount5;

        /// <summary>���v�o�א��U</summary>
        private Double _totalSalesCount6;

        /// <summary>���v�o�א��V</summary>
        private Double _totalSalesCount7;

        /// <summary>���v�o�א��W</summary>
        private Double _totalSalesCount8;

        /// <summary>���v�o�א��X</summary>
        private Double _totalSalesCount9;

        /// <summary>���v�o�א��P�O</summary>
        private Double _totalSalesCount10;

        /// <summary>���v�o�א��P�P</summary>
        private Double _totalSalesCount11;

        /// <summary>���v�o�א��P�Q</summary>
        private Double _totalSalesCount12;

        /// <summary>���v�e���z�P</summary>
        private Int64 _salesProfit1;

        /// <summary>���v�e���z�Q</summary>
        private Int64 _salesProfit2;

        /// <summary>���v�e���z�R</summary>
        private Int64 _salesProfit3;

        /// <summary>���v�e���z�S</summary>
        private Int64 _salesProfit4;

        /// <summary>���v�e���z�T</summary>
        private Int64 _salesProfit5;

        /// <summary>���v�e���z�U</summary>
        private Int64 _salesProfit6;

        /// <summary>���v�e���z�V</summary>
        private Int64 _salesProfit7;

        /// <summary>���v�e���z�W</summary>
        private Int64 _salesProfit8;

        /// <summary>���v�e���z�X</summary>
        private Int64 _salesProfit9;

        /// <summary>���v�e���z�P�O</summary>
        private Int64 _salesProfit10;

        /// <summary>���v�e���z�P�P</summary>
        private Int64 _salesProfit11;

        /// <summary>���v�e���z�P�Q</summary>
        private Int64 _salesProfit12;

        /// <summary>�ڕW�Δ�敪</summary>
        /// <remarks>10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����</remarks>
        private Int32 _targetContrastCd;

        /// <summary>����ڕW���z1</summary>
        /// <remarks>1��</remarks>
        private Int64 _salesTargetMoney1;

        /// <summary>����ڕW���z2</summary>
        /// <remarks>2��</remarks>
        private Int64 _salesTargetMoney2;

        /// <summary>����ڕW���z3</summary>
        /// <remarks>3��</remarks>
        private Int64 _salesTargetMoney3;

        /// <summary>����ڕW���z4</summary>
        /// <remarks>4��</remarks>
        private Int64 _salesTargetMoney4;

        /// <summary>����ڕW���z5</summary>
        /// <remarks>5��</remarks>
        private Int64 _salesTargetMoney5;

        /// <summary>����ڕW���z6</summary>
        /// <remarks>6��</remarks>
        private Int64 _salesTargetMoney6;

        /// <summary>����ڕW���z7</summary>
        /// <remarks>7��</remarks>
        private Int64 _salesTargetMoney7;

        /// <summary>����ڕW���z8</summary>
        /// <remarks>8��</remarks>
        private Int64 _salesTargetMoney8;

        /// <summary>����ڕW���z9</summary>
        /// <remarks>9��</remarks>
        private Int64 _salesTargetMoney9;

        /// <summary>����ڕW���z10</summary>
        /// <remarks>10��</remarks>
        private Int64 _salesTargetMoney10;

        /// <summary>����ڕW���z11</summary>
        /// <remarks>11��</remarks>
        private Int64 _salesTargetMoney11;

        /// <summary>����ڕW���z12</summary>
        /// <remarks>12��</remarks>
        private Int64 _salesTargetMoney12;

        /// <summary>���Ԕ���ڕW���z</summary>
        private Int64 _monthlySalesTarget;

        /// <summary>������ԖڕW���z</summary>
        private Int64 _termSalesTarget;

        /// <summary>����ڕW�e���z1</summary>
        /// <remarks>1��</remarks>
        private Int64 _salesTargetProfit1;

        /// <summary>����ڕW�e���z2</summary>
        /// <remarks>2��</remarks>
        private Int64 _salesTargetProfit2;

        /// <summary>����ڕW�e���z3</summary>
        /// <remarks>3��</remarks>
        private Int64 _salesTargetProfit3;

        /// <summary>����ڕW�e���z4</summary>
        /// <remarks>4��</remarks>
        private Int64 _salesTargetProfit4;

        /// <summary>����ڕW�e���z5</summary>
        /// <remarks>5��</remarks>
        private Int64 _salesTargetProfit5;

        /// <summary>����ڕW�e���z6</summary>
        /// <remarks>6��</remarks>
        private Int64 _salesTargetProfit6;

        /// <summary>����ڕW�e���z7</summary>
        /// <remarks>7��</remarks>
        private Int64 _salesTargetProfit7;

        /// <summary>����ڕW�e���z8</summary>
        /// <remarks>8��</remarks>
        private Int64 _salesTargetProfit8;

        /// <summary>����ڕW�e���z9</summary>
        /// <remarks>9��</remarks>
        private Int64 _salesTargetProfit9;

        /// <summary>����ڕW�e���z10</summary>
        /// <remarks>10��</remarks>
        private Int64 _salesTargetProfit10;

        /// <summary>����ڕW�e���z11</summary>
        /// <remarks>11��</remarks>
        private Int64 _salesTargetProfit11;

        /// <summary>����ڕW�e���z12</summary>
        /// <remarks>12��</remarks>
        private Int64 _salesTargetProfit12;

        /// <summary>���㌎�ԖڕW�e���z</summary>
        private Int64 _monthlySalesTargetProfit;

        /// <summary>������ԖڕW�e���z</summary>
        private Int64 _termSalesTargetProfit;

        /// <summary>����ڕW����1</summary>
        /// <remarks>1��</remarks>
        private Double _salesTargetCount1;

        /// <summary>����ڕW����2</summary>
        /// <remarks>2��</remarks>
        private Double _salesTargetCount2;

        /// <summary>����ڕW����3</summary>
        /// <remarks>3��</remarks>
        private Double _salesTargetCount3;

        /// <summary>����ڕW����4</summary>
        /// <remarks>4��</remarks>
        private Double _salesTargetCount4;

        /// <summary>����ڕW����5</summary>
        /// <remarks>5��</remarks>
        private Double _salesTargetCount5;

        /// <summary>����ڕW����6</summary>
        /// <remarks>6��</remarks>
        private Double _salesTargetCount6;

        /// <summary>����ڕW����7</summary>
        /// <remarks>7��</remarks>
        private Double _salesTargetCount7;

        /// <summary>����ڕW����8</summary>
        /// <remarks>8��</remarks>
        private Double _salesTargetCount8;

        /// <summary>����ڕW����9</summary>
        /// <remarks>9��</remarks>
        private Double _salesTargetCount9;

        /// <summary>����ڕW����10</summary>
        /// <remarks>10��</remarks>
        private Double _salesTargetCount10;

        /// <summary>����ڕW����11</summary>
        /// <remarks>11��</remarks>
        private Double _salesTargetCount11;

        /// <summary>����ڕW����12</summary>
        /// <remarks>12��</remarks>
        private Double _salesTargetCount12;

        /// <summary>���㌎�ԖڕW����</summary>
        private Double _monthlySalesTargetCount;

        /// <summary>������ԖڕW����</summary>
        private Double _termSalesTargetCount;


        /// <summary>���Ԕ���ڕW���z1</summary>
        private Int64 _monthlySalesTarget1;

        /// <summary>������ԖڕW���z1</summary>
        private Int64 _termSalesTarget1;

        /// <summary>���㌎�ԖڕW�e���z1</summary>
        private Int64 _monthlySalesTargetProfit1;

        /// <summary>������ԖڕW�e���z1</summary>
        private Int64 _termSalesTargetProfit1;

        /// <summary>���㌎�ԖڕW����1</summary>
        private Double _monthlySalesTargetCount1;

        /// <summary>�S������ԖڕW����1</summary>
        private Double _termSalesTargetCount1;

        /// <summary>���Ԕ���ڕW���z2</summary>
        private Int64 _monthlySalesTarget2;

        /// <summary>������ԖڕW���z2</summary>
        private Int64 _termSalesTarget2;

        /// <summary>���㌎�ԖڕW�e���z2</summary>
        private Int64 _monthlySalesTargetProfit2;

        /// <summary>������ԖڕW�e���z2</summary>
        private Int64 _termSalesTargetProfit2;

        /// <summary>���㌎�ԖڕW����2</summary>
        private Double _monthlySalesTargetCount2;

        /// <summary>������ԖڕW����2</summary>
        private Double _termSalesTargetCount2;

        /// <summary>���Ԕ���ڕW���z3</summary>
        private Int64 _monthlySalesTarget3;

        /// <summary>������ԖڕW���z3</summary>
        private Int64 _termSalesTarget3;

        /// <summary>���㌎�ԖڕW�e���z3</summary>
        private Int64 _monthlySalesTargetProfit3;

        /// <summary>������ԖڕW�e���z3</summary>
        private Int64 _termSalesTargetProfit3;

        /// <summary>���㌎�ԖڕW����3</summary>
        private Double _monthlySalesTargetCount3;

        /// <summary>�������ԖڕW����3</summary>
        private Double _termSalesTargetCount3;

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�e�����z</summary>
        private Int64 _salesProfit;

        /// <summary>�v���</summary>
        private DateTime _salesDate;

        /// <summary>����`�[�敪�i���ׁj</summary>
        private Int32 _salesSlipCdDtl;

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }


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

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ьv�㋒�_�R�[�h���s����Ɠ��̋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
        }

        /// public propaty name  :  ManageSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ManageSectionCode
        {
            get { return _manageSectionCode; }
            set { _manageSectionCode = value; }
        }

        /// public propaty name  :  ManageSectionSnm
        /// <summary>�Ǘ����_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ManageSectionSnm
        {
            get { return _manageSectionSnm; }
            set { _manageSectionSnm = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��ʗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>���[�U�[�K�C�h���̃v���p�e�B</summary>
        /// <value>�n��ʗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GuideName
        {
            get { return _guideName; }
            set { _guideName = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
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

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  AddUpShipmentCnt
        /// <summary>�Ώۓ��t���ԏo�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��t���ԏo�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AddUpShipmentCnt
        {
            get { return _addUpShipmentCnt; }
            set { _addUpShipmentCnt = value; }
        }

        /// public propaty name  :  AddUpSalesMoneyTaxExc
        /// <summary>�Ώۓ��t���Ԕ�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��t���Ԕ�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AddUpSalesMoneyTaxExc
        {
            get { return _addUpSalesMoneyTaxExc; }
            set { _addUpSalesMoneyTaxExc = value; }
        }

        /// public propaty name  :  AddUpSalesProfit
        /// <summary>�Ώۓ��t���ԑe�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��t���ԑe�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AddUpSalesProfit
        {
            get { return _addUpSalesProfit; }
            set { _addUpSalesProfit = value; }
        }

        /// public propaty name  :  CampaignShipmentCnt
        /// <summary>�L�����y�[�����ԏo�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����ԏo�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CampaignShipmentCnt
        {
            get { return _campaignShipmentCnt; }
            set { _campaignShipmentCnt = value; }
        }

        /// public propaty name  :  CampaignSalesMoneyTaxExc
        /// <summary>�L�����y�[�����Ԕ�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����Ԕ�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CampaignSalesMoneyTaxExc
        {
            get { return _campaignSalesMoneyTaxExc; }
            set { _campaignSalesMoneyTaxExc = value; }
        }

        /// public propaty name  :  CampaignSalesProfit
        /// <summary>�L�����y�[�����ԑe�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����ԑe�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CampaignSalesProfit
        {
            get { return _campaignSalesProfit; }
            set { _campaignSalesProfit = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc1
        /// <summary>���v������z�i�Ŕ����j�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc1
        {
            get { return _salesMoneyTaxExc1; }
            set { _salesMoneyTaxExc1 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc2
        /// <summary>���v������z�i�Ŕ����j�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc2
        {
            get { return _salesMoneyTaxExc2; }
            set { _salesMoneyTaxExc2 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc3
        /// <summary>���v������z�i�Ŕ����j�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc3
        {
            get { return _salesMoneyTaxExc3; }
            set { _salesMoneyTaxExc3 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc4
        /// <summary>���v������z�i�Ŕ����j�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc4
        {
            get { return _salesMoneyTaxExc4; }
            set { _salesMoneyTaxExc4 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc5
        /// <summary>���v������z�i�Ŕ����j�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc5
        {
            get { return _salesMoneyTaxExc5; }
            set { _salesMoneyTaxExc5 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc6
        /// <summary>���v������z�i�Ŕ����j�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc6
        {
            get { return _salesMoneyTaxExc6; }
            set { _salesMoneyTaxExc6 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc7
        /// <summary>���v������z�i�Ŕ����j�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc7
        {
            get { return _salesMoneyTaxExc7; }
            set { _salesMoneyTaxExc7 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc8
        /// <summary>���v������z�i�Ŕ����j�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc8
        {
            get { return _salesMoneyTaxExc8; }
            set { _salesMoneyTaxExc8 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc9
        /// <summary>���v������z�i�Ŕ����j�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc9
        {
            get { return _salesMoneyTaxExc9; }
            set { _salesMoneyTaxExc9 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc10
        /// <summary>���v������z�i�Ŕ����j�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc10
        {
            get { return _salesMoneyTaxExc10; }
            set { _salesMoneyTaxExc10 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc11
        /// <summary>���v������z�i�Ŕ����j�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc11
        {
            get { return _salesMoneyTaxExc11; }
            set { _salesMoneyTaxExc11 = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc12
        /// <summary>���v������z�i�Ŕ����j�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v������z�i�Ŕ����j�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc12
        {
            get { return _salesMoneyTaxExc12; }
            set { _salesMoneyTaxExc12 = value; }
        }

        /// public propaty name  :  TotalSalesCount1
        /// <summary>���v�o�א��P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount1
        {
            get { return _totalSalesCount1; }
            set { _totalSalesCount1 = value; }
        }

        /// public propaty name  :  TotalSalesCount2
        /// <summary>���v�o�א��Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount2
        {
            get { return _totalSalesCount2; }
            set { _totalSalesCount2 = value; }
        }

        /// public propaty name  :  TotalSalesCount3
        /// <summary>���v�o�א��R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount3
        {
            get { return _totalSalesCount3; }
            set { _totalSalesCount3 = value; }
        }

        /// public propaty name  :  TotalSalesCount4
        /// <summary>���v�o�א��S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount4
        {
            get { return _totalSalesCount4; }
            set { _totalSalesCount4 = value; }
        }

        /// public propaty name  :  TotalSalesCount5
        /// <summary>���v�o�א��T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount5
        {
            get { return _totalSalesCount5; }
            set { _totalSalesCount5 = value; }
        }

        /// public propaty name  :  TotalSalesCount6
        /// <summary>���v�o�א��U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount6
        {
            get { return _totalSalesCount6; }
            set { _totalSalesCount6 = value; }
        }

        /// public propaty name  :  TotalSalesCount7
        /// <summary>���v�o�א��V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount7
        {
            get { return _totalSalesCount7; }
            set { _totalSalesCount7 = value; }
        }

        /// public propaty name  :  TotalSalesCount8
        /// <summary>���v�o�א��W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount8
        {
            get { return _totalSalesCount8; }
            set { _totalSalesCount8 = value; }
        }

        /// public propaty name  :  TotalSalesCount9
        /// <summary>���v�o�א��X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount9
        {
            get { return _totalSalesCount9; }
            set { _totalSalesCount9 = value; }
        }

        /// public propaty name  :  TotalSalesCount10
        /// <summary>���v�o�א��P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount10
        {
            get { return _totalSalesCount10; }
            set { _totalSalesCount10 = value; }
        }

        /// public propaty name  :  TotalSalesCount11
        /// <summary>���v�o�א��P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount11
        {
            get { return _totalSalesCount11; }
            set { _totalSalesCount11 = value; }
        }

        /// public propaty name  :  TotalSalesCount12
        /// <summary>���v�o�א��P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�o�א��P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TotalSalesCount12
        {
            get { return _totalSalesCount12; }
            set { _totalSalesCount12 = value; }
        }

        /// public propaty name  :  SalesProfit1
        /// <summary>���v�e���z�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit1
        {
            get { return _salesProfit1; }
            set { _salesProfit1 = value; }
        }

        /// public propaty name  :  SalesProfit2
        /// <summary>���v�e���z�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit2
        {
            get { return _salesProfit2; }
            set { _salesProfit2 = value; }
        }

        /// public propaty name  :  SalesProfit3
        /// <summary>���v�e���z�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit3
        {
            get { return _salesProfit3; }
            set { _salesProfit3 = value; }
        }

        /// public propaty name  :  SalesProfit4
        /// <summary>���v�e���z�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit4
        {
            get { return _salesProfit4; }
            set { _salesProfit4 = value; }
        }

        /// public propaty name  :  SalesProfit5
        /// <summary>���v�e���z�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit5
        {
            get { return _salesProfit5; }
            set { _salesProfit5 = value; }
        }

        /// public propaty name  :  SalesProfit6
        /// <summary>���v�e���z�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit6
        {
            get { return _salesProfit6; }
            set { _salesProfit6 = value; }
        }

        /// public propaty name  :  SalesProfit7
        /// <summary>���v�e���z�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit7
        {
            get { return _salesProfit7; }
            set { _salesProfit7 = value; }
        }

        /// public propaty name  :  SalesProfit8
        /// <summary>���v�e���z�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit8
        {
            get { return _salesProfit8; }
            set { _salesProfit8 = value; }
        }

        /// public propaty name  :  SalesProfit9
        /// <summary>���v�e���z�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit9
        {
            get { return _salesProfit9; }
            set { _salesProfit9 = value; }
        }

        /// public propaty name  :  SalesProfit10
        /// <summary>���v�e���z�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit10
        {
            get { return _salesProfit10; }
            set { _salesProfit10 = value; }
        }

        /// public propaty name  :  SalesProfit11
        /// <summary>���v�e���z�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit11
        {
            get { return _salesProfit11; }
            set { _salesProfit11 = value; }
        }

        /// public propaty name  :  SalesProfit12
        /// <summary>���v�e���z�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�e���z�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit12
        {
            get { return _salesProfit12; }
            set { _salesProfit12 = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// <value>10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  SalesTargetMoney1
        /// <summary>����ڕW���z1�v���p�e�B</summary>
        /// <value>1��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney1
        {
            get { return _salesTargetMoney1; }
            set { _salesTargetMoney1 = value; }
        }

        /// public propaty name  :  SalesTargetMoney2
        /// <summary>����ڕW���z2�v���p�e�B</summary>
        /// <value>2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney2
        {
            get { return _salesTargetMoney2; }
            set { _salesTargetMoney2 = value; }
        }

        /// public propaty name  :  SalesTargetMoney3
        /// <summary>����ڕW���z3�v���p�e�B</summary>
        /// <value>3��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney3
        {
            get { return _salesTargetMoney3; }
            set { _salesTargetMoney3 = value; }
        }

        /// public propaty name  :  SalesTargetMoney4
        /// <summary>����ڕW���z4�v���p�e�B</summary>
        /// <value>4��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney4
        {
            get { return _salesTargetMoney4; }
            set { _salesTargetMoney4 = value; }
        }

        /// public propaty name  :  SalesTargetMoney5
        /// <summary>����ڕW���z5�v���p�e�B</summary>
        /// <value>5��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney5
        {
            get { return _salesTargetMoney5; }
            set { _salesTargetMoney5 = value; }
        }

        /// public propaty name  :  SalesTargetMoney6
        /// <summary>����ڕW���z6�v���p�e�B</summary>
        /// <value>6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney6
        {
            get { return _salesTargetMoney6; }
            set { _salesTargetMoney6 = value; }
        }

        /// public propaty name  :  SalesTargetMoney7
        /// <summary>����ڕW���z7�v���p�e�B</summary>
        /// <value>7��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney7
        {
            get { return _salesTargetMoney7; }
            set { _salesTargetMoney7 = value; }
        }

        /// public propaty name  :  SalesTargetMoney8
        /// <summary>����ڕW���z8�v���p�e�B</summary>
        /// <value>8��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney8
        {
            get { return _salesTargetMoney8; }
            set { _salesTargetMoney8 = value; }
        }

        /// public propaty name  :  SalesTargetMoney9
        /// <summary>����ڕW���z9�v���p�e�B</summary>
        /// <value>9��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney9
        {
            get { return _salesTargetMoney9; }
            set { _salesTargetMoney9 = value; }
        }

        /// public propaty name  :  SalesTargetMoney10
        /// <summary>����ڕW���z10�v���p�e�B</summary>
        /// <value>10��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney10
        {
            get { return _salesTargetMoney10; }
            set { _salesTargetMoney10 = value; }
        }

        /// public propaty name  :  SalesTargetMoney11
        /// <summary>����ڕW���z11�v���p�e�B</summary>
        /// <value>11��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney11
        {
            get { return _salesTargetMoney11; }
            set { _salesTargetMoney11 = value; }
        }

        /// public propaty name  :  SalesTargetMoney12
        /// <summary>����ڕW���z12�v���p�e�B</summary>
        /// <value>12��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney12
        {
            get { return _salesTargetMoney12; }
            set { _salesTargetMoney12 = value; }
        }

        /// public propaty name  :  MonthlySalesTarget
        /// <summary>���Ԕ���ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԕ���ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTarget
        {
            get { return _monthlySalesTarget; }
            set { _monthlySalesTarget = value; }
        }

        /// public propaty name  :  TermSalesTarget
        /// <summary>������ԖڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTarget
        {
            get { return _termSalesTarget; }
            set { _termSalesTarget = value; }
        }

        /// public propaty name  :  SalesTargetProfit1
        /// <summary>����ڕW�e���z1�v���p�e�B</summary>
        /// <value>1��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit1
        {
            get { return _salesTargetProfit1; }
            set { _salesTargetProfit1 = value; }
        }

        /// public propaty name  :  SalesTargetProfit2
        /// <summary>����ڕW�e���z2�v���p�e�B</summary>
        /// <value>2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit2
        {
            get { return _salesTargetProfit2; }
            set { _salesTargetProfit2 = value; }
        }

        /// public propaty name  :  SalesTargetProfit3
        /// <summary>����ڕW�e���z3�v���p�e�B</summary>
        /// <value>3��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit3
        {
            get { return _salesTargetProfit3; }
            set { _salesTargetProfit3 = value; }
        }

        /// public propaty name  :  SalesTargetProfit4
        /// <summary>����ڕW�e���z4�v���p�e�B</summary>
        /// <value>4��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit4
        {
            get { return _salesTargetProfit4; }
            set { _salesTargetProfit4 = value; }
        }

        /// public propaty name  :  SalesTargetProfit5
        /// <summary>����ڕW�e���z5�v���p�e�B</summary>
        /// <value>5��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit5
        {
            get { return _salesTargetProfit5; }
            set { _salesTargetProfit5 = value; }
        }

        /// public propaty name  :  SalesTargetProfit6
        /// <summary>����ڕW�e���z6�v���p�e�B</summary>
        /// <value>6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit6
        {
            get { return _salesTargetProfit6; }
            set { _salesTargetProfit6 = value; }
        }

        /// public propaty name  :  SalesTargetProfit7
        /// <summary>����ڕW�e���z7�v���p�e�B</summary>
        /// <value>7��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit7
        {
            get { return _salesTargetProfit7; }
            set { _salesTargetProfit7 = value; }
        }

        /// public propaty name  :  SalesTargetProfit8
        /// <summary>����ڕW�e���z8�v���p�e�B</summary>
        /// <value>8��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit8
        {
            get { return _salesTargetProfit8; }
            set { _salesTargetProfit8 = value; }
        }

        /// public propaty name  :  SalesTargetProfit9
        /// <summary>����ڕW�e���z9�v���p�e�B</summary>
        /// <value>9��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit9
        {
            get { return _salesTargetProfit9; }
            set { _salesTargetProfit9 = value; }
        }

        /// public propaty name  :  SalesTargetProfit10
        /// <summary>����ڕW�e���z10�v���p�e�B</summary>
        /// <value>10��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit10
        {
            get { return _salesTargetProfit10; }
            set { _salesTargetProfit10 = value; }
        }

        /// public propaty name  :  SalesTargetProfit11
        /// <summary>����ڕW�e���z11�v���p�e�B</summary>
        /// <value>11��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit11
        {
            get { return _salesTargetProfit11; }
            set { _salesTargetProfit11 = value; }
        }

        /// public propaty name  :  SalesTargetProfit12
        /// <summary>����ڕW�e���z12�v���p�e�B</summary>
        /// <value>12��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit12
        {
            get { return _salesTargetProfit12; }
            set { _salesTargetProfit12 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit
        /// <summary>���㌎�ԖڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit
        {
            get { return _monthlySalesTargetProfit; }
            set { _monthlySalesTargetProfit = value; }
        }

        /// public propaty name  :  TermSalesTargetProfit
        /// <summary>������ԖڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit
        {
            get { return _termSalesTargetProfit; }
            set { _termSalesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount1
        /// <summary>����ڕW����1�v���p�e�B</summary>
        /// <value>1��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount1
        {
            get { return _salesTargetCount1; }
            set { _salesTargetCount1 = value; }
        }

        /// public propaty name  :  SalesTargetCount2
        /// <summary>����ڕW����2�v���p�e�B</summary>
        /// <value>2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount2
        {
            get { return _salesTargetCount2; }
            set { _salesTargetCount2 = value; }
        }

        /// public propaty name  :  SalesTargetCount3
        /// <summary>����ڕW����3�v���p�e�B</summary>
        /// <value>3��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount3
        {
            get { return _salesTargetCount3; }
            set { _salesTargetCount3 = value; }
        }

        /// public propaty name  :  SalesTargetCount4
        /// <summary>����ڕW����4�v���p�e�B</summary>
        /// <value>4��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount4
        {
            get { return _salesTargetCount4; }
            set { _salesTargetCount4 = value; }
        }

        /// public propaty name  :  SalesTargetCount5
        /// <summary>����ڕW����5�v���p�e�B</summary>
        /// <value>5��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount5
        {
            get { return _salesTargetCount5; }
            set { _salesTargetCount5 = value; }
        }

        /// public propaty name  :  SalesTargetCount6
        /// <summary>����ڕW����6�v���p�e�B</summary>
        /// <value>6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount6
        {
            get { return _salesTargetCount6; }
            set { _salesTargetCount6 = value; }
        }

        /// public propaty name  :  SalesTargetCount7
        /// <summary>����ڕW����7�v���p�e�B</summary>
        /// <value>7��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount7
        {
            get { return _salesTargetCount7; }
            set { _salesTargetCount7 = value; }
        }

        /// public propaty name  :  SalesTargetCount8
        /// <summary>����ڕW����8�v���p�e�B</summary>
        /// <value>8��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount8
        {
            get { return _salesTargetCount8; }
            set { _salesTargetCount8 = value; }
        }

        /// public propaty name  :  SalesTargetCount9
        /// <summary>����ڕW����9�v���p�e�B</summary>
        /// <value>9��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount9
        {
            get { return _salesTargetCount9; }
            set { _salesTargetCount9 = value; }
        }

        /// public propaty name  :  SalesTargetCount10
        /// <summary>����ڕW����10�v���p�e�B</summary>
        /// <value>10��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount10
        {
            get { return _salesTargetCount10; }
            set { _salesTargetCount10 = value; }
        }

        /// public propaty name  :  SalesTargetCount11
        /// <summary>����ڕW����11�v���p�e�B</summary>
        /// <value>11��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount11
        {
            get { return _salesTargetCount11; }
            set { _salesTargetCount11 = value; }
        }

        /// public propaty name  :  SalesTargetCount12
        /// <summary>����ڕW����12�v���p�e�B</summary>
        /// <value>12��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount12
        {
            get { return _salesTargetCount12; }
            set { _salesTargetCount12 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount
        /// <summary>���㌎�ԖڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthlySalesTargetCount
        {
            get { return _monthlySalesTargetCount; }
            set { _monthlySalesTargetCount = value; }
        }

        /// public propaty name  :  TermSalesTargetCount
        /// <summary>������ԖڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TermSalesTargetCount
        {
            get { return _termSalesTargetCount; }
            set { _termSalesTargetCount = value; }
        }

        //--------------------------------------------------------------------------------------------------

        /// public propaty name  :  MonthlySalesTarget1
        /// <summary>���Ԕ���ڕW���z1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԕ���ڕW���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTarget1
        {
            get { return _monthlySalesTarget1; }
            set { _monthlySalesTarget1 = value; }
        }

        /// public propaty name  :  TermSalesTarget1
        /// <summary>������ԖڕW���z1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTarget1
        {
            get { return _termSalesTarget1; }
            set { _termSalesTarget1 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit1
        /// <summary>���㌎�ԖڕW�e���z1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW�e���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit1
        {
            get { return _monthlySalesTargetProfit1; }
            set { _monthlySalesTargetProfit1 = value; }
        }
        /// public propaty name  :  TermSalesTargetProfit1
        /// <summary>������ԖڕW�e���z1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit1
        {
            get { return _termSalesTargetProfit1; }
            set { _termSalesTargetProfit1 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount1
        /// <summary>���㌎�ԖڕW����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthlySalesTargetCount1
        {
            get { return _monthlySalesTargetCount1; }
            set { _monthlySalesTargetCount1 = value; }
        }
        /// public propaty name  :  TermSalesTargetCount1
        /// <summary>������ԖڕW����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TermSalesTargetCount1
        {
            get { return _termSalesTargetCount1; }
            set { _termSalesTargetCount1 = value; }
        }

        /// public propaty name  :  MonthlySalesTarget2
        /// <summary>���Ԕ���ڕW���z2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԕ���ڕW���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTarget2
        {
            get { return _monthlySalesTarget2; }
            set { _monthlySalesTarget2 = value; }
        }
        /// public propaty name  :  TermSalesTarget2
        /// <summary>������ԖڕW���z2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTarget2
        {
            get { return _termSalesTarget2; }
            set { _termSalesTarget2 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit2
        /// <summary>���㌎�ԖڕW�e���z2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW�e���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit2
        {
            get { return _monthlySalesTargetProfit2; }
            set { _monthlySalesTargetProfit2 = value; }
        }
        /// public propaty name  :  TermSalesTargetProfit2
        /// <summary>������ԖڕW�e���z2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW�e���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit2
        {
            get { return _termSalesTargetProfit2; }
            set { _termSalesTargetProfit2 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount2
        /// <summary>���㌎�ԖڕW����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthlySalesTargetCount2
        {
            get { return _monthlySalesTargetCount2; }
            set { _monthlySalesTargetCount2 = value; }
        }
        /// public propaty name  :  TermSalesTargetCount2
        /// <summary>������ԖڕW����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TermSalesTargetCount2
        {
            get { return _termSalesTargetCount2; }
            set { _termSalesTargetCount2 = value; }
        }
        /// public propaty name  :  MonthlySalesTarget3
        /// <summary>���ԏ��v�ڕW���z3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԏ��v�ڕW���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTarget3
        {
            get { return _monthlySalesTarget3; }
            set { _monthlySalesTarget3 = value; }
        }

        /// public propaty name  :  TermSalesTarget3
        /// <summary>���v���ԖڕW���z3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���ԖڕW���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTarget3
        {
            get { return _termSalesTarget3; }
            set { _termSalesTarget3 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit3
        /// <summary>���v���ԖڕW�e���z3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���ԖڕW�e���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit3
        {
            get { return _monthlySalesTargetProfit3; }
            set { _monthlySalesTargetProfit3 = value; }
        }
        /// public propaty name  :  TermSalesTargetProfit3
        /// <summary>���v���ԖڕW�e���z3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���ԖڕW�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit3
        {
            get { return _termSalesTargetProfit3; }
            set { _termSalesTargetProfit3 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount3
        /// <summary>���v���ԖڕW����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���ԖڕW����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthlySalesTargetCount3
        {
            get { return _monthlySalesTargetCount3; }
            set { _monthlySalesTargetCount3 = value; }
        }
        /// public propaty name  :  TermSalesTargetCount3
        /// <summary>���v���ԖڕW����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v���ԖڕW����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TermSalesTargetCount3
        {
            get { return _termSalesTargetCount3; }
            set { _termSalesTargetCount3 = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesProfit
        {
            get { return _salesProfit; }
            set { _salesProfit = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�v����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// <summary>
        /// �L�����y�[�����ѕ\���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignstRsltListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignstRsltListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignstRsltListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CampaignstRsltListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CampaignstRsltListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CampaignstRsltListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignstRsltListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignstRsltListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignstRsltListResultWork || graph is ArrayList || graph is CampaignstRsltListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CampaignstRsltListResultWork).FullName));

            if (graph != null && graph is CampaignstRsltListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignstRsltListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignstRsltListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignstRsltListResultWork[])graph).Length;
            }
            else if (graph is CampaignstRsltListResultWork)
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
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�L�����y�[������
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ManageSectionCode
            //�Ǘ����_����
            serInfo.MemberInfo.Add(typeof(string)); //ManageSectionSnm
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //���[�U�[�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //GuideName
            //�L�����y�[���Ώۋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignObjDiv
            //�K�p�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //�K�p�I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //�Ώۓ��t���ԏo�א�
            serInfo.MemberInfo.Add(typeof(Double)); //AddUpShipmentCnt
            //�Ώۓ��t���Ԕ�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //AddUpSalesMoneyTaxExc
            //�Ώۓ��t���ԑe�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //AddUpSalesProfit
            //�L�����y�[�����ԏo�א�
            serInfo.MemberInfo.Add(typeof(Double)); //CampaignShipmentCnt
            //�L�����y�[�����Ԕ�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //CampaignSalesMoneyTaxExc
            //�L�����y�[�����ԑe�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //CampaignSalesProfit
            //���v������z�i�Ŕ����j�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc1
            //���v������z�i�Ŕ����j�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc2
            //���v������z�i�Ŕ����j�R
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc3
            //���v������z�i�Ŕ����j�S
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc4
            //���v������z�i�Ŕ����j�T
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc5
            //���v������z�i�Ŕ����j�U
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc6
            //���v������z�i�Ŕ����j�V
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc7
            //���v������z�i�Ŕ����j�W
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc8
            //���v������z�i�Ŕ����j�X
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc9
            //���v������z�i�Ŕ����j�P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc10
            //���v������z�i�Ŕ����j�P�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc11
            //���v������z�i�Ŕ����j�P�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc12
            //���v�o�א��P
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount1
            //���v�o�א��Q
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount2
            //���v�o�א��R
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount3
            //���v�o�א��S
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount4
            //���v�o�א��T
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount5
            //���v�o�א��U
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount6
            //���v�o�א��V
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount7
            //���v�o�א��W
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount8
            //���v�o�א��X
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount9
            //���v�o�א��P�O
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount10
            //���v�o�א��P�P
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount11
            //���v�o�א��P�Q
            serInfo.MemberInfo.Add(typeof(Double)); //TotalSalesCount12
            //���v�e���z�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit1
            //���v�e���z�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit2
            //���v�e���z�R
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit3
            //���v�e���z�S
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit4
            //���v�e���z�T
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit5
            //���v�e���z�U
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit6
            //���v�e���z�V
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit7
            //���v�e���z�W
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit8
            //���v�e���z�X
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit9
            //���v�e���z�P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit10
            //���v�e���z�P�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit11
            //���v�e���z�P�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesProfit12
            //�ڕW�Δ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetContrastCd
            //����ڕW���z1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney1
            //����ڕW���z2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney2
            //����ڕW���z3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney3
            //����ڕW���z4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney4
            //����ڕW���z5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney5
            //����ڕW���z6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney6
            //����ڕW���z7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney7
            //����ڕW���z8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney8
            //����ڕW���z9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney9
            //����ڕW���z10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney10
            //����ڕW���z11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney11
            //����ڕW���z12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney12
            //���Ԕ���ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget
            //������ԖڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget
            //����ڕW�e���z1
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit1
            //����ڕW�e���z2
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit2
            //����ڕW�e���z3
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit3
            //����ڕW�e���z4
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit4
            //����ڕW�e���z5
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit5
            //����ڕW�e���z6
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit6
            //����ڕW�e���z7
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit7
            //����ڕW�e���z8
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit8
            //����ڕW�e���z9
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit9
            //����ڕW�e���z10
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit10
            //����ڕW�e���z11
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit11
            //����ڕW�e���z12
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit12
            //���㌎�ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit
            //������ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit
            //����ڕW����1
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount1
            //����ڕW����2
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount2
            //����ڕW����3
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount3
            //����ڕW����4
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount4
            //����ڕW����5
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount5
            //����ڕW����6
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount6
            //����ڕW����7
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount7
            //����ڕW����8
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount8
            //����ڕW����9
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount9
            //����ڕW����10
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount10
            //����ڕW����11
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount11
            //����ڕW����12
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount12
            //���㌎�ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount
            //������ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount

            //�S���җp���Ԕ���ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget1
            //�S���җp������ԖڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget1
            //�S���җp���㌎�ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit1
            //�S���җp������ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit1
            //�S���җp���㌎�ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount1
            //�S���җp������ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount1
            //���_�p���Ԕ���ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget2
            //���_�p������ԖڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget2
            //���_�p���㌎�ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit2
            //���_�p������ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit2
            //���_�p���㌎�ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount2
            //���_�p������ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount2
            //���v�p���Ԕ���ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTarget3
            //���v�p������ԖڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTarget3
            //���v�p���㌎�ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthlySalesTargetProfit3
            //���v�p������ԖڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit3
            //���v�p���㌎�ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //MonthlySalesTargetCount3 _salesSlipCdDtl
            //���v�p������ԖڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //TermSalesTargetCount3
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignstRsltListResultWork)
            {
                CampaignstRsltListResultWork temp = (CampaignstRsltListResultWork)graph;

                SetCampaignstRsltListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignstRsltListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignstRsltListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignstRsltListResultWork temp in lst)
                {
                    SetCampaignstRsltListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignstRsltListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 140;

        /// <summary>
        ///  CampaignstRsltListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignstRsltListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCampaignstRsltListResultWork(System.IO.BinaryWriter writer, CampaignstRsltListResultWork temp)
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
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�L�����y�[������
            writer.Write(temp.CampaignName);
            //���ьv�㋒�_�R�[�h
            writer.Write(temp.ResultsAddUpSecCd);
            //�Ǘ����_�R�[�h
            writer.Write(temp.ManageSectionCode);
            //�Ǘ����_����
            writer.Write(temp.ManageSectionSnm);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //���[�U�[�K�C�h����
            writer.Write(temp.GuideName);
            //�L�����y�[���Ώۋ敪
            writer.Write(temp.CampaignObjDiv);
            //�K�p�J�n��
            writer.Write(temp.ApplyStaDate);
            //�K�p�I����
            writer.Write(temp.ApplyEndDate);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h�J�i����
            writer.Write(temp.BLGroupKanaName);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�]�ƈ�����
            writer.Write(temp.EmployeeName);
            //�Ώۓ��t���ԏo�א�
            writer.Write(temp.AddUpShipmentCnt);
            //�Ώۓ��t���Ԕ�����z�i�Ŕ����j
            writer.Write(temp.AddUpSalesMoneyTaxExc);
            //�Ώۓ��t���ԑe�����z
            writer.Write(temp.AddUpSalesProfit);
            //�L�����y�[�����ԏo�א�
            writer.Write(temp.CampaignShipmentCnt);
            //�L�����y�[�����Ԕ�����z�i�Ŕ����j
            writer.Write(temp.CampaignSalesMoneyTaxExc);
            //�L�����y�[�����ԑe�����z
            writer.Write(temp.CampaignSalesProfit);
            //���v������z�i�Ŕ����j�P
            writer.Write(temp.SalesMoneyTaxExc1);
            //���v������z�i�Ŕ����j�Q
            writer.Write(temp.SalesMoneyTaxExc2);
            //���v������z�i�Ŕ����j�R
            writer.Write(temp.SalesMoneyTaxExc3);
            //���v������z�i�Ŕ����j�S
            writer.Write(temp.SalesMoneyTaxExc4);
            //���v������z�i�Ŕ����j�T
            writer.Write(temp.SalesMoneyTaxExc5);
            //���v������z�i�Ŕ����j�U
            writer.Write(temp.SalesMoneyTaxExc6);
            //���v������z�i�Ŕ����j�V
            writer.Write(temp.SalesMoneyTaxExc7);
            //���v������z�i�Ŕ����j�W
            writer.Write(temp.SalesMoneyTaxExc8);
            //���v������z�i�Ŕ����j�X
            writer.Write(temp.SalesMoneyTaxExc9);
            //���v������z�i�Ŕ����j�P�O
            writer.Write(temp.SalesMoneyTaxExc10);
            //���v������z�i�Ŕ����j�P�P
            writer.Write(temp.SalesMoneyTaxExc11);
            //���v������z�i�Ŕ����j�P�Q
            writer.Write(temp.SalesMoneyTaxExc12);
            //���v�o�א��P
            writer.Write(temp.TotalSalesCount1);
            //���v�o�א��Q
            writer.Write(temp.TotalSalesCount2);
            //���v�o�א��R
            writer.Write(temp.TotalSalesCount3);
            //���v�o�א��S
            writer.Write(temp.TotalSalesCount4);
            //���v�o�א��T
            writer.Write(temp.TotalSalesCount5);
            //���v�o�א��U
            writer.Write(temp.TotalSalesCount6);
            //���v�o�א��V
            writer.Write(temp.TotalSalesCount7);
            //���v�o�א��W
            writer.Write(temp.TotalSalesCount8);
            //���v�o�א��X
            writer.Write(temp.TotalSalesCount9);
            //���v�o�א��P�O
            writer.Write(temp.TotalSalesCount10);
            //���v�o�א��P�P
            writer.Write(temp.TotalSalesCount11);
            //���v�o�א��P�Q
            writer.Write(temp.TotalSalesCount12);
            //���v�e���z�P
            writer.Write(temp.SalesProfit1);
            //���v�e���z�Q
            writer.Write(temp.SalesProfit2);
            //���v�e���z�R
            writer.Write(temp.SalesProfit3);
            //���v�e���z�S
            writer.Write(temp.SalesProfit4);
            //���v�e���z�T
            writer.Write(temp.SalesProfit5);
            //���v�e���z�U
            writer.Write(temp.SalesProfit6);
            //���v�e���z�V
            writer.Write(temp.SalesProfit7);
            //���v�e���z�W
            writer.Write(temp.SalesProfit8);
            //���v�e���z�X
            writer.Write(temp.SalesProfit9);
            //���v�e���z�P�O
            writer.Write(temp.SalesProfit10);
            //���v�e���z�P�P
            writer.Write(temp.SalesProfit11);
            //���v�e���z�P�Q
            writer.Write(temp.SalesProfit12);
            //�ڕW�Δ�敪
            writer.Write(temp.TargetContrastCd);
            //����ڕW���z1
            writer.Write(temp.SalesTargetMoney1);
            //����ڕW���z2
            writer.Write(temp.SalesTargetMoney2);
            //����ڕW���z3
            writer.Write(temp.SalesTargetMoney3);
            //����ڕW���z4
            writer.Write(temp.SalesTargetMoney4);
            //����ڕW���z5
            writer.Write(temp.SalesTargetMoney5);
            //����ڕW���z6
            writer.Write(temp.SalesTargetMoney6);
            //����ڕW���z7
            writer.Write(temp.SalesTargetMoney7);
            //����ڕW���z8
            writer.Write(temp.SalesTargetMoney8);
            //����ڕW���z9
            writer.Write(temp.SalesTargetMoney9);
            //����ڕW���z10
            writer.Write(temp.SalesTargetMoney10);
            //����ڕW���z11
            writer.Write(temp.SalesTargetMoney11);
            //����ڕW���z12
            writer.Write(temp.SalesTargetMoney12);
            //���Ԕ���ڕW���z
            writer.Write(temp.MonthlySalesTarget);
            //������ԖڕW���z
            writer.Write(temp.TermSalesTarget);
            //����ڕW�e���z1
            writer.Write(temp.SalesTargetProfit1);
            //����ڕW�e���z2
            writer.Write(temp.SalesTargetProfit2);
            //����ڕW�e���z3
            writer.Write(temp.SalesTargetProfit3);
            //����ڕW�e���z4
            writer.Write(temp.SalesTargetProfit4);
            //����ڕW�e���z5
            writer.Write(temp.SalesTargetProfit5);
            //����ڕW�e���z6
            writer.Write(temp.SalesTargetProfit6);
            //����ڕW�e���z7
            writer.Write(temp.SalesTargetProfit7);
            //����ڕW�e���z8
            writer.Write(temp.SalesTargetProfit8);
            //����ڕW�e���z9
            writer.Write(temp.SalesTargetProfit9);
            //����ڕW�e���z10
            writer.Write(temp.SalesTargetProfit10);
            //����ڕW�e���z11
            writer.Write(temp.SalesTargetProfit11);
            //����ڕW�e���z12
            writer.Write(temp.SalesTargetProfit12);
            //���㌎�ԖڕW�e���z
            writer.Write(temp.MonthlySalesTargetProfit);
            //������ԖڕW�e���z
            writer.Write(temp.TermSalesTargetProfit);
            //����ڕW����1
            writer.Write(temp.SalesTargetCount1);
            //����ڕW����2
            writer.Write(temp.SalesTargetCount2);
            //����ڕW����3
            writer.Write(temp.SalesTargetCount3);
            //����ڕW����4
            writer.Write(temp.SalesTargetCount4);
            //����ڕW����5
            writer.Write(temp.SalesTargetCount5);
            //����ڕW����6
            writer.Write(temp.SalesTargetCount6);
            //����ڕW����7
            writer.Write(temp.SalesTargetCount7);
            //����ڕW����8
            writer.Write(temp.SalesTargetCount8);
            //����ڕW����9
            writer.Write(temp.SalesTargetCount9);
            //����ڕW����10
            writer.Write(temp.SalesTargetCount10);
            //����ڕW����11
            writer.Write(temp.SalesTargetCount11);
            //����ڕW����12
            writer.Write(temp.SalesTargetCount12);
            //���㌎�ԖڕW����
            writer.Write(temp.MonthlySalesTargetCount);
            //������ԖڕW����
            writer.Write(temp.TermSalesTargetCount);

            //�S���җp���Ԕ���ڕW���z
            writer.Write(temp.MonthlySalesTarget1);
            //�S���җp������ԖڕW���z
            writer.Write(temp.TermSalesTarget1);
            //�S���җp���㌎�ԖڕW�e���z
            writer.Write(temp.MonthlySalesTargetProfit1);
            //�S���җp������ԖڕW�e���z
            writer.Write(temp.TermSalesTargetProfit1);
            //�S���җp���㌎�ԖڕW����
            writer.Write(temp.MonthlySalesTargetCount1);
            //�S���җp������ԖڕW����
            writer.Write(temp.TermSalesTargetCount1);
            //���_�p���Ԕ���ڕW���z
            writer.Write(temp.MonthlySalesTarget2);
            //���_�p������ԖڕW���z
            writer.Write(temp.TermSalesTarget2);
            //���_�p���㌎�ԖڕW�e���z
            writer.Write(temp.MonthlySalesTargetProfit2);
            //���_�p������ԖڕW�e���z
            writer.Write(temp.TermSalesTargetProfit2);
            //���_�p���㌎�ԖڕW����
            writer.Write(temp.MonthlySalesTargetCount2);
            //���_�p������ԖڕW����
            writer.Write(temp.TermSalesTargetCount2);
            //���v�p���Ԕ���ڕW���z
            writer.Write(temp.MonthlySalesTarget3);
            //���v�p������ԖڕW���z
            writer.Write(temp.TermSalesTarget3);
            //���v�p���㌎�ԖڕW�e���z
            writer.Write(temp.MonthlySalesTargetProfit3);
            //���v�p������ԖڕW�e���z
            writer.Write(temp.TermSalesTargetProfit3);
            //���v�p���㌎�ԖڕW����
            writer.Write(temp.MonthlySalesTargetCount3);
            //���v�p������ԖڕW����
            writer.Write(temp.TermSalesTargetCount3);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�e�����z
            writer.Write(temp.SalesProfit);
            //�v���
            writer.Write((Int64)temp.SalesDate.Ticks);
            //����`�[�敪�i���ׁj
            writer.Write(temp.SalesSlipCdDtl);

        }

        /// <summary>
        ///  CampaignstRsltListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CampaignstRsltListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignstRsltListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CampaignstRsltListResultWork GetCampaignstRsltListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CampaignstRsltListResultWork temp = new CampaignstRsltListResultWork();

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
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�L�����y�[������
            temp.CampaignName = reader.ReadString();
            //���ьv�㋒�_�R�[�h
            temp.ResultsAddUpSecCd = reader.ReadString();
            //�Ǘ����_�R�[�h
            temp.ManageSectionCode = reader.ReadString();
            //�Ǘ����_����
            temp.ManageSectionSnm = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //���[�U�[�K�C�h����
            temp.GuideName = reader.ReadString();
            //�L�����y�[���Ώۋ敪
            temp.CampaignObjDiv = reader.ReadInt32();
            //�K�p�J�n��
            temp.ApplyStaDate = reader.ReadInt32();
            //�K�p�I����
            temp.ApplyEndDate = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h�J�i����
            temp.BLGroupKanaName = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�]�ƈ�����
            temp.EmployeeName = reader.ReadString();
            //�Ώۓ��t���ԏo�א�
            temp.AddUpShipmentCnt = reader.ReadDouble();
            //�Ώۓ��t���Ԕ�����z�i�Ŕ����j
            temp.AddUpSalesMoneyTaxExc = reader.ReadInt64();
            //�Ώۓ��t���ԑe�����z
            temp.AddUpSalesProfit = reader.ReadInt64();
            //�L�����y�[�����ԏo�א�
            temp.CampaignShipmentCnt = reader.ReadDouble();
            //�L�����y�[�����Ԕ�����z�i�Ŕ����j
            temp.CampaignSalesMoneyTaxExc = reader.ReadInt64();
            //�L�����y�[�����ԑe�����z
            temp.CampaignSalesProfit = reader.ReadInt64();
            //���v������z�i�Ŕ����j�P
            temp.SalesMoneyTaxExc1 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�Q
            temp.SalesMoneyTaxExc2 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�R
            temp.SalesMoneyTaxExc3 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�S
            temp.SalesMoneyTaxExc4 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�T
            temp.SalesMoneyTaxExc5 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�U
            temp.SalesMoneyTaxExc6 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�V
            temp.SalesMoneyTaxExc7 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�W
            temp.SalesMoneyTaxExc8 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�X
            temp.SalesMoneyTaxExc9 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�P�O
            temp.SalesMoneyTaxExc10 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�P�P
            temp.SalesMoneyTaxExc11 = reader.ReadInt64();
            //���v������z�i�Ŕ����j�P�Q
            temp.SalesMoneyTaxExc12 = reader.ReadInt64();
            //���v�o�א��P
            temp.TotalSalesCount1 = reader.ReadDouble();
            //���v�o�א��Q
            temp.TotalSalesCount2 = reader.ReadDouble();
            //���v�o�א��R
            temp.TotalSalesCount3 = reader.ReadDouble();
            //���v�o�א��S
            temp.TotalSalesCount4 = reader.ReadDouble();
            //���v�o�א��T
            temp.TotalSalesCount5 = reader.ReadDouble();
            //���v�o�א��U
            temp.TotalSalesCount6 = reader.ReadDouble();
            //���v�o�א��V
            temp.TotalSalesCount7 = reader.ReadDouble();
            //���v�o�א��W
            temp.TotalSalesCount8 = reader.ReadDouble();
            //���v�o�א��X
            temp.TotalSalesCount9 = reader.ReadDouble();
            //���v�o�א��P�O
            temp.TotalSalesCount10 = reader.ReadDouble();
            //���v�o�א��P�P
            temp.TotalSalesCount11 = reader.ReadDouble();
            //���v�o�א��P�Q
            temp.TotalSalesCount12 = reader.ReadDouble();
            //���v�e���z�P
            temp.SalesProfit1 = reader.ReadInt64();
            //���v�e���z�Q
            temp.SalesProfit2 = reader.ReadInt64();
            //���v�e���z�R
            temp.SalesProfit3 = reader.ReadInt64();
            //���v�e���z�S
            temp.SalesProfit4 = reader.ReadInt64();
            //���v�e���z�T
            temp.SalesProfit5 = reader.ReadInt64();
            //���v�e���z�U
            temp.SalesProfit6 = reader.ReadInt64();
            //���v�e���z�V
            temp.SalesProfit7 = reader.ReadInt64();
            //���v�e���z�W
            temp.SalesProfit8 = reader.ReadInt64();
            //���v�e���z�X
            temp.SalesProfit9 = reader.ReadInt64();
            //���v�e���z�P�O
            temp.SalesProfit10 = reader.ReadInt64();
            //���v�e���z�P�P
            temp.SalesProfit11 = reader.ReadInt64();
            //���v�e���z�P�Q
            temp.SalesProfit12 = reader.ReadInt64();
            //�ڕW�Δ�敪
            temp.TargetContrastCd = reader.ReadInt32();
            //����ڕW���z1
            temp.SalesTargetMoney1 = reader.ReadInt64();
            //����ڕW���z2
            temp.SalesTargetMoney2 = reader.ReadInt64();
            //����ڕW���z3
            temp.SalesTargetMoney3 = reader.ReadInt64();
            //����ڕW���z4
            temp.SalesTargetMoney4 = reader.ReadInt64();
            //����ڕW���z5
            temp.SalesTargetMoney5 = reader.ReadInt64();
            //����ڕW���z6
            temp.SalesTargetMoney6 = reader.ReadInt64();
            //����ڕW���z7
            temp.SalesTargetMoney7 = reader.ReadInt64();
            //����ڕW���z8
            temp.SalesTargetMoney8 = reader.ReadInt64();
            //����ڕW���z9
            temp.SalesTargetMoney9 = reader.ReadInt64();
            //����ڕW���z10
            temp.SalesTargetMoney10 = reader.ReadInt64();
            //����ڕW���z11
            temp.SalesTargetMoney11 = reader.ReadInt64();
            //����ڕW���z12
            temp.SalesTargetMoney12 = reader.ReadInt64();
            //���Ԕ���ڕW���z
            temp.MonthlySalesTarget = reader.ReadInt64();
            //������ԖڕW���z
            temp.TermSalesTarget = reader.ReadInt64();
            //����ڕW�e���z1
            temp.SalesTargetProfit1 = reader.ReadInt64();
            //����ڕW�e���z2
            temp.SalesTargetProfit2 = reader.ReadInt64();
            //����ڕW�e���z3
            temp.SalesTargetProfit3 = reader.ReadInt64();
            //����ڕW�e���z4
            temp.SalesTargetProfit4 = reader.ReadInt64();
            //����ڕW�e���z5
            temp.SalesTargetProfit5 = reader.ReadInt64();
            //����ڕW�e���z6
            temp.SalesTargetProfit6 = reader.ReadInt64();
            //����ڕW�e���z7
            temp.SalesTargetProfit7 = reader.ReadInt64();
            //����ڕW�e���z8
            temp.SalesTargetProfit8 = reader.ReadInt64();
            //����ڕW�e���z9
            temp.SalesTargetProfit9 = reader.ReadInt64();
            //����ڕW�e���z10
            temp.SalesTargetProfit10 = reader.ReadInt64();
            //����ڕW�e���z11
            temp.SalesTargetProfit11 = reader.ReadInt64();
            //����ڕW�e���z12
            temp.SalesTargetProfit12 = reader.ReadInt64();
            //���㌎�ԖڕW�e���z
            temp.MonthlySalesTargetProfit = reader.ReadInt64();
            //������ԖڕW�e���z
            temp.TermSalesTargetProfit = reader.ReadInt64();
            //����ڕW����1
            temp.SalesTargetCount1 = reader.ReadDouble();
            //����ڕW����2
            temp.SalesTargetCount2 = reader.ReadDouble();
            //����ڕW����3
            temp.SalesTargetCount3 = reader.ReadDouble();
            //����ڕW����4
            temp.SalesTargetCount4 = reader.ReadDouble();
            //����ڕW����5
            temp.SalesTargetCount5 = reader.ReadDouble();
            //����ڕW����6
            temp.SalesTargetCount6 = reader.ReadDouble();
            //����ڕW����7
            temp.SalesTargetCount7 = reader.ReadDouble();
            //����ڕW����8
            temp.SalesTargetCount8 = reader.ReadDouble();
            //����ڕW����9
            temp.SalesTargetCount9 = reader.ReadDouble();
            //����ڕW����10
            temp.SalesTargetCount10 = reader.ReadDouble();
            //����ڕW����11
            temp.SalesTargetCount11 = reader.ReadDouble();
            //����ڕW����12
            temp.SalesTargetCount12 = reader.ReadDouble();
            //���㌎�ԖڕW����
            temp.MonthlySalesTargetCount = reader.ReadDouble();
            //������ԖڕW����
            temp.TermSalesTargetCount = reader.ReadDouble();

            //�S���җp���Ԕ���ڕW���z
            temp.MonthlySalesTarget1 = reader.ReadInt64();
            //�S���җp������ԖڕW���z
            temp.TermSalesTarget1 = reader.ReadInt64();
            //�S���җp���㌎�ԖڕW�e���z
            temp.MonthlySalesTargetProfit1 = reader.ReadInt64();
            //�S���җp������ԖڕW�e���z
            temp.TermSalesTargetProfit1 = reader.ReadInt64();
            //�S���җp���㌎�ԖڕW����
            temp.MonthlySalesTargetCount1 = reader.ReadDouble();
            //�S���җp������ԖڕW����
            temp.TermSalesTargetCount1 = reader.ReadDouble();
            //���_�p���Ԕ���ڕW���z
            temp.MonthlySalesTarget2 = reader.ReadInt64();
            //���_�p������ԖڕW���z
            temp.TermSalesTarget2 = reader.ReadInt64();
            //���_�p���㌎�ԖڕW�e���z
            temp.MonthlySalesTargetProfit2 = reader.ReadInt64();
            //���_�p������ԖڕW�e���z
            temp.TermSalesTargetProfit2 = reader.ReadInt64();
            //���_�p���㌎�ԖڕW����
            temp.MonthlySalesTargetCount2 = reader.ReadDouble();
            //���_�p������ԖڕW����
            temp.TermSalesTargetCount2 = reader.ReadDouble();
            //���v�p���Ԕ���ڕW���z
            temp.MonthlySalesTarget3 = reader.ReadInt64();
            //���v�p������ԖڕW���z
            temp.TermSalesTarget3 = reader.ReadInt64();
            //���v�p���㌎�ԖڕW�e���z
            temp.MonthlySalesTargetProfit3 = reader.ReadInt64();
            //���v�p������ԖڕW�e���z
            temp.TermSalesTargetProfit3 = reader.ReadInt64();
            //���v�p���㌎�ԖڕW����
            temp.MonthlySalesTargetCount3 = reader.ReadDouble();
            //���v�p������ԖڕW����
            temp.TermSalesTargetCount3 = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�e�����z
            temp.SalesProfit = reader.ReadInt64();
            //�v���
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();


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
        /// <returns>CampaignstRsltListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignstRsltListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignstRsltListResultWork temp = GetCampaignstRsltListResultWork(reader, serInfo);
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
                    retValue = (CampaignstRsltListResultWork[])lst.ToArray(typeof(CampaignstRsltListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
