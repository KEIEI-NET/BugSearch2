using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceMergeSt
    /// <summary>
    ///                      ���i�����S�̐ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�����S�̐ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/10  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      : 2009/12/11 21024 ���X�� ��</br>
    /// <br>                 :�EBL�R�[�h�X�V�敪�Ή�(MANTIS[0014775])</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceMergeSt
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";
        
        /// <summary>���̍X�V�敪</summary>
        /// <remarks>0�F����@1:���Ȃ�</remarks>
        private Int32 _nameMergeFlg;

        /// <summary>�w�ʍX�V�敪</summary>
        /// <remarks>0�F����@1:���Ȃ�</remarks>
        private Int32 _goodsRankMergeFlg;

        /// <summary>���i�X�V�敪</summary>
        /// <remarks>0�F����@1:���Ȃ�</remarks>
        private Int32 _priceMergeFlg;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0�F���i�����p���@1:�O�ōX�V</remarks>
        private Int32 _openPriceFlg;

        /// <summary>���i�Ǘ�����</summary>
        /// <remarks>3,4,5�@�i�Ǘ��������Z�b�g�j�@</remarks>
        private Int32 _priceManage;

        /// <summary>���i���������敪</summary>
        /// <remarks>0:�V���N�����㒼�����s�@1:�蓮���s</remarks>
        private Int32 _priceRevisionFlg;

        // 2009/12/11 Add >>>
        /// <summary>BL�R�[�h�X�V�敪</summary>
        /// <remarks>0�F����@1:���Ȃ�</remarks>
        private Int32 _blGoodsCdMergeFlg;
        // 2009/12/11 Add <<<


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

        /// public propaty name  :  NameMergeFlg
        /// <summary>���̍X�V�敪�v���p�e�B</summary>
        /// <value>0�F����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̍X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NameMergeFlg
        {
            get { return _nameMergeFlg; }
            set { _nameMergeFlg = value; }
        }

        /// public propaty name  :  GoodsRankMergeFlg
        /// <summary>�w�ʍX�V�敪�v���p�e�B</summary>
        /// <value>0�F����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʍX�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRankMergeFlg
        {
            get { return _goodsRankMergeFlg; }
            set { _goodsRankMergeFlg = value; }
        }

        /// public propaty name  :  PriceMergeFlg
        /// <summary>���i�X�V�敪�v���p�e�B</summary>
        /// <value>0�F����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceMergeFlg
        {
            get { return _priceMergeFlg; }
            set { _priceMergeFlg = value; }
        }

        /// public propaty name  :  OpenPriceFlg
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0�F���i�����p���@1:�O�ōX�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceFlg
        {
            get { return _openPriceFlg; }
            set { _openPriceFlg = value; }
        }

        /// public propaty name  :  PriceManage
        /// <summary>���i�Ǘ������v���p�e�B</summary>
        /// <value>3,4,5�@�i�Ǘ��������Z�b�g�j�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceManage
        {
            get { return _priceManage; }
            set { _priceManage = value; }
        }

        /// public propaty name  :  PriceRevisionFlg
        /// <summary>���i���������敪�v���p�e�B</summary>
        /// <value>0:�V���N�����㒼�����s�@1:�蓮���s</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceRevisionFlg
        {
            get { return _priceRevisionFlg; }
            set { _priceRevisionFlg = value; }
        }

        // 2009/12/11 Add >>>
        /// public propaty name  :  BLGoodeCodeMergeFlg
        /// <summary>BL�R�[�h�X�V�敪�v���p�e�B</summary>
        /// <value>0�F����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodeCdMergeFlg
        {
            get { return _blGoodsCdMergeFlg; }
            set { _blGoodsCdMergeFlg = value; }
        }
        // 2009/12/11 Add <<<


        /// <summary>
        /// ���i�����S�̐ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PriceMergeSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceMergeSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceMergeSt()
        {
        }

    }

}
