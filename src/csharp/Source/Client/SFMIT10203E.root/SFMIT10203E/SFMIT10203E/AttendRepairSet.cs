using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �t������
    /// </summary>
    public class AttendRepairSetMain
    {
        public AttendRepairSet[] attendrepairs;
    }

    /// <summary>
    /// �t������
    /// </summary>
    public class AttendRepairSet
    {
        /// <summary>UUID</summary>
        public string uuid;

        /// <summary>�쐬��</summary>
        public long insDtTime;

        /// <summary>�X�V��</summary>
        public long updDtTime;

        /// <summary>�A�J�E���gID</summary>
        public int insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public int updAccountId;

        /// <summary>�_���폜�敪</summary>
        public int logicalDelDiv;

        /// <summary>�t������ID(�T���Q�[�g�L�[)</summary>
        public long attendRepairId;
      
        /// <summary>��ƃR�[�h</summary>
        public string enterpriseCode;

        /// <summary>���i�J�e�S��ID</summary>
        public long goodsCategoryId;

        /// <summary>�f�[�^�敪(1:��ƁA2�F���i)</summary>
        public int dataType;

        /// <summary>���z�^�C�v(1�F�P���A2�F���z)</summary>
        public int priceType;

        /// <summary>���я�</summary>
        public int sortNo;

        /// <summary>��������</summary>
        public string repairName;

        /// <summary>��������</summary>
        public long repairPrice;

        /// <summary>�g�p�E���g�p�t���O</summary>
        public bool displayFlag;

        /// <summary>�񋟌��t������ID</summary>
        public long storeAttendRepairId;

        ///// <summary>�񋟌���ƃR�[�h</summary>
        //public string sourceEnterpriseCode;

        ///// <summary>�񋟌���Ɩ���</summary>
        //public string sourceEnterpriseName;

        ///// <summary>BL�R�[�h</summary>
        //public int blCode;

        ///// <summary>BL�R�[�h�}�ԍ�</summary>
        //public int blCodeBranch;

   

        ///// <summary>��ƁE���i�敪</summary>
        //public int divCode;

        ///// <summary>��ƁE���i�敪����</summary>
        //public string divName;

        /// <summary>
        /// �t�������ݒ�R���X�g���N�^
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public AttendRepairSet()
        {

        }

         /// <summary>
        /// ���i�J�e�S���[�ݒ�R���X�g���N�^
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="insDtTime">�쐬��</param>
        /// <param name="updDtTime">�X�V��</param>
        /// <param name="insAccountId">�A�J�E���gID</param>
        /// <param name="updAccountId">�X�V�A�J�E���gID</param>
        /// <param name="logicalDelDiv">�_���폜�敪</param>
        /// <param name="attendRepairId">�t������ID</param>
        /// <param name="dataType">�f�[�^�敪(1:��ƁA2�F���i)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsCategoryId">���i�J�e�S��ID</param>
        /// <param name="priceType">���z�^�C�v(1�F�P���A2�F���z)</param>
        /// <param name="sortNo">���я�</param>
        /// <param name="repairName">��������</param>
        /// <param name="repairPrice">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public AttendRepairSet(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv, long attendRepairId, 
            string enterpriseCode, long goodsCategoryId,int dataType, int priceType, int sortNo, string repairName, long repairPrice)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = updAccountId;
            this.attendRepairId = attendRepairId;
            this.dataType = dataType;
            this.enterpriseCode = enterpriseCode;
            this.goodsCategoryId = goodsCategoryId;
            this.priceType = priceType;
            this.repairName = repairName;
            this.repairPrice = repairPrice;
            this.sortNo = sortNo;
        }

        /// <summary>
        /// ���i�J�e�S���[�ݒ蕡������
        /// </summary>
        /// <remarks>
        /// </remarks>
        public AttendRepairSet Clone()
        {
            return new AttendRepairSet(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.attendRepairId, this.enterpriseCode, this.goodsCategoryId, this.dataType, this.priceType, this.sortNo, this.repairName, this.repairPrice);
        }
    }


   

   

   

}
