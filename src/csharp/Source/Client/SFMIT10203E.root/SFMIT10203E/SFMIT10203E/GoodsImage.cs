using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Broadleaf.Application.UIData
{
     /// <summary>
    /// ���i�摜���C���N���X
    /// </summary>
    public class GoodsImage_MAIN
    {
        public GoodsImage image;
    }

    /// <summary>
    /// ���i�摜�N���X
    /// </summary>
    public class GoodsImage
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

        /// <summary>�摜ID</summary>
        public long imageId;

        /// <summary>�摜�f�[�^Base64</summary>
        public string imageData;

        /// <summary>�摜�f�[�^</summary>
        public Image imageData_Image;

        /// <summary>�摜����</summary>
        public string imageKeyword;

        /// <summary>���i�J�e�S���[ID</summary>
        public long goodsCategoryId;


        /// <summary>
        /// ���i�摜 ��������
        /// </summary>
        /// <returns>GoodsImage�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsImage�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsImage Clone()
        {
            return new GoodsImage(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.imageId, this.imageData,this.imageData_Image, this.imageKeyword, this.goodsCategoryId);
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GoodsImage()
        {

        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GoodsImage(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv,
            string enterpriseCode, long imageId, string imageData, Image imageData_Image, string imageKeyword, long goodsCategoryId)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.imageId = imageId;
            this.imageData = imageData;
            this.imageData_Image = imageData_Image;
            this.imageKeyword = imageKeyword;
            this.goodsCategoryId = goodsCategoryId;
        }
    }
}
