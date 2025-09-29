using System;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{

    /// public class name:   GoodsCategory_MAIN
    /// <summary>
    /// ���i�J�e�S���[�ݒ�(���C��)�@�V���A���C�Y�p
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class GoodsCategory_MAIN
    {
        public GoodsCategory[] GoodsCategory;
    }

    /// public class name:   goodsCategory
    /// <summary>
    ///                      ���i�J�e�S���[�ݒ�
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�J�e�S���[�ݒ�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/5/24</br>
    /// <br>Genarated Date   :   2016/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsCategory
    {
        /// <summary>UUID</summary>
        public string uuid = "";

        /// <summary>�쐬����</summary>
        public long insDtTime;

        /// <summary>�X�V����</summary>
        public long updDtTime;

        /// <summary>�쐬�A�J�E���gID</summary>
        public int insAccountId;

        /// <summary>�X�V�A�J�E���gID</summary>
        public int updAccountId;

        /// <summary>�_���폜�敪</summary>
        public int logicalDelDiv;

        /// <summary>���i�J�e�S���[ID</summary>
        public long goodsCategoryId;

        /// <summary>���i�J�e�S���[��</summary>
        public string goodsCategoryName = "";


        /// public propaty name  :  uuid
        /// <summary>UUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Uuid
        {
            get { return uuid; }
            set { uuid = value; }
        }

        /// public propaty name  :  insDtTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public long InsDtTime
        {
            get { return insDtTime; }
            set { insDtTime = value; }
        }

        /// public propaty name  :  upd_dt_time
        /// <summary>�X�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public long UpdDtTime
        {
            get { return updDtTime; }
            set { updDtTime = value; }
        }

        /// public propaty name  :  ins_account_id
        /// <summary>�쐬�A�J�E���gID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�A�J�E���gID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int InsAccountId
        {
            get { return insAccountId; }
            set { insAccountId = value; }
        }

        /// public propaty name  :  upd_account_id
        /// <summary>�X�V�A�J�E���gID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�J�E���gID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int UpdAccountId
        {
            get { return updAccountId; }
            set { updAccountId = value; }
        }

        /// public propaty name  :  logical_del_div
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int LogicalDelDiv
        {
            get { return logicalDelDiv; }
            set { logicalDelDiv = value; }
        }

        /// public propaty name  :  goods_category_id
        /// <summary>���i�J�e�S���[ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�e�S���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public long GoodsCategoryId
        {
            get { return goodsCategoryId; }
            set { goodsCategoryId = value; }
        }

        /// public propaty name  :  goods_category_name
        /// <summary>���i�J�e�S���[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�e�S���[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsCategoryName
        {
            get { return goodsCategoryName; }
            set { goodsCategoryName = value; }
        }


        /// <summary>
        /// ���i�J�e�S���[�ݒ�R���X�g���N�^
        /// </summary>
        /// <returns>t_goods_category�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   t_goods_category�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsCategory()
        {
        }

        /// <summary>
        /// ���i�J�e�S���[�ݒ�R���X�g���N�^
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="insDtTime">�쐬����</param>
        /// <param name="upd_dt_time">�X�V����</param>
        /// <param name="ins_account_id">�쐬�A�J�E���gID</param>
        /// <param name="upd_account_id">�X�V�A�J�E���gID</param>
        /// <param name="logical_del_div">�_���폜�敪</param>
        /// <param name="goods_category_id">���i�J�e�S���[ID</param>
        /// <param name="goods_category_name">���i�J�e�S���[��</param>
        /// <returns>t_goods_category�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   t_goods_category�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsCategory(string uuid, long insDtTime, long upd_dt_time, int ins_account_id, int upd_account_id, int logical_del_div, long goods_category_id, string goods_category_name)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = upd_dt_time;
            this.insAccountId = ins_account_id;
            this.updAccountId = upd_account_id;
            this.logicalDelDiv = logical_del_div;
            this.goodsCategoryId = goods_category_id;
            this.goodsCategoryName = goods_category_name;

        }

        /// <summary>
        /// ���i�J�e�S���[�ݒ蕡������
        /// </summary>
        /// <returns>t_goods_category�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����t_goods_category�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsCategory Clone()
        {
            return new GoodsCategory(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.goodsCategoryId, this.goodsCategoryName);
        }

        /// <summary>
        /// ���i�J�e�S���[�ݒ��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�t_goods_category�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   t_goods_category�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(GoodsCategory target)
        {
            return ((this.Uuid == target.Uuid)
                 && (this.InsDtTime == target.InsDtTime)
                 && (this.UpdDtTime == target.UpdDtTime)
                 && (this.InsAccountId == target.InsAccountId)
                 && (this.UpdAccountId == target.UpdAccountId)
                 && (this.LogicalDelDiv == target.LogicalDelDiv)
                 && (this.GoodsCategoryId == target.GoodsCategoryId)
                 && (this.GoodsCategoryName == target.GoodsCategoryName));
        }

        /// <summary>
        /// ���i�J�e�S���[�ݒ��r����
        /// </summary>
        /// <param name="t_goods_category1">
        ///                    ��r����t_goods_category�N���X�̃C���X�^���X
        /// </param>
        /// <param name="t_goods_category2">��r����t_goods_category�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   t_goods_category�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(GoodsCategory goodsCategory1, GoodsCategory goodsCategory2)
        {
            return ((goodsCategory1.Uuid == goodsCategory2.Uuid)
                 && (goodsCategory1.InsDtTime == goodsCategory2.InsDtTime)
                 && (goodsCategory1.UpdDtTime == goodsCategory2.UpdDtTime)
                 && (goodsCategory1.InsAccountId == goodsCategory2.InsAccountId)
                 && (goodsCategory1.UpdAccountId == goodsCategory2.UpdAccountId)
                 && (goodsCategory1.LogicalDelDiv == goodsCategory2.LogicalDelDiv)
                 && (goodsCategory1.GoodsCategoryId == goodsCategory2.GoodsCategoryId)
                 && (goodsCategory1.GoodsCategoryName == goodsCategory2.GoodsCategoryName));
        }
        /// <summary>
        /// ���i�J�e�S���[�ݒ��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�t_goods_category�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   t_goods_category�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(GoodsCategory target)
        {
            ArrayList resList = new ArrayList();
            if (this.Uuid != target.Uuid) resList.Add("Uuid");
            if (this.InsDtTime != target.InsDtTime) resList.Add("InsDtTime");
            if (this.UpdDtTime != target.UpdDtTime) resList.Add("UpdDtTime");
            if (this.InsAccountId != target.InsAccountId) resList.Add("InsAccountId");
            if (this.UpdAccountId != target.UpdAccountId) resList.Add("UpdAccountId");
            if (this.LogicalDelDiv != target.LogicalDelDiv) resList.Add("LogicalDelDiv");
            if (this.GoodsCategoryId != target.GoodsCategoryId) resList.Add("GoodsCategoryId");
            if (this.GoodsCategoryName != target.GoodsCategoryName) resList.Add("GoodsCategoryName");

            return resList;
        }

        /// <summary>
        /// ���i�J�e�S���[�ݒ��r����
        /// </summary>
        /// <param name="t_goods_category1">��r����t_goods_category�N���X�̃C���X�^���X</param>
        /// <param name="t_goods_category2">��r����t_goods_category�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   t_goods_category�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(GoodsCategory goodsCategory1, GoodsCategory goodscategory2)
        {
            ArrayList resList = new ArrayList();
            if (goodsCategory1.Uuid != goodscategory2.Uuid) resList.Add("Uuid");
            if (goodsCategory1.InsDtTime != goodscategory2.InsDtTime) resList.Add("InsDtTime");
            if (goodsCategory1.UpdDtTime != goodscategory2.UpdDtTime) resList.Add("UpdDtTime");
            if (goodsCategory1.InsAccountId != goodscategory2.InsAccountId) resList.Add("InsAccountId");
            if (goodsCategory1.UpdAccountId != goodscategory2.UpdAccountId) resList.Add("UpdAccountId");
            if (goodsCategory1.LogicalDelDiv != goodscategory2.LogicalDelDiv) resList.Add("LogicalDelDiv");
            if (goodsCategory1.GoodsCategoryId != goodscategory2.GoodsCategoryId) resList.Add("GoodsCategoryId");
            if (goodsCategory1.GoodsCategoryName != goodscategory2.GoodsCategoryName) resList.Add("GoodsCategoryName");

            return resList;
        }
    }
}
