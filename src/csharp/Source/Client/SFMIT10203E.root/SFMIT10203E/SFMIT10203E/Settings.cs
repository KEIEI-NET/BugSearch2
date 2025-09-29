using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ����ݒ胁�C���N���X
    /// </summary>
    public class Settings_MAIN
    {
        public Settings[] settings;
    }

    /// <summary>
    /// ����ݒ�N���X
    /// </summary>
    public class Settings
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

        /// <summary>��ƃR�[�h</summary>
        public string enterpriseCode;

         /// <summary>���_�R�[�h</summary>
        public string sectionCode;

        /// <summary>����ݒ�ID</summary>
        public long settingId;

        /// <summary>�⍇�����p�t���O</summary>
        public bool inquiryUseFlag;

        /// <summary>�������\���t���O</summary>
        public bool releaseDateDisplayFlag;

        /// <summary>�݌ɒʒm�t���O</summary>
        public bool stockDisplayFlag;


        /// <summary>
        /// ����ݒ�N���X ��������
        /// </summary>
        /// <returns>Settings�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// </remarks>
        public Settings Clone()
        {
            return new Settings(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv,
                this.enterpriseCode, this.sectionCode, this.settingId, this.inquiryUseFlag, this.releaseDateDisplayFlag, this.stockDisplayFlag);
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Settings()
        {

        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Settings(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv,
            string enterpriseCode, string sectionCode, long settingId, bool inquiryUseFlag, bool releaseDateDisplayFlag, bool stockDisplayFlag)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.sectionCode = sectionCode;
            this.settingId = settingId;
            this.inquiryUseFlag = inquiryUseFlag;
            this.releaseDateDisplayFlag = releaseDateDisplayFlag;
            this.stockDisplayFlag = stockDisplayFlag;
        }
    }
}
