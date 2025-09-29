//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o�� ���o���ʃ��[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : ������
// �� �� �� : 2016/05/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBODataExportResultWork
    /// <summary>
    ///                      �s�a�n���o�͌��ʃN���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �s�a�n���o�͌��ʃN���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/05/20</br>
    /// <br>Genarated Date   :   2016/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBODataExportResultWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCodeRF = "";

        /// <summary>���i�J�e�S��</summary>
        /// <remarks>1:�^�C��,2:�o�b�e���[,3:�I�C��</remarks>
        private Int32 _goodsCategoryRF;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNoRF = "";

        /// <summary>���i����</summary>
        private string _goodsNameRF = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdRF;

        /// <summary>���[�J�[����</summary>
        private string _makerNameRF = "";

        /// <summary>������</summary>
        private Int32 _releaseDateRF;

        /// <summary>�݌ɏ󋵋敪</summary>
        /// <remarks>0:���ב҂�,1:�݌ɕs��,2:�݌Ɏc��,3:�݌ɖL�x</remarks>
        private Int32 _stockStatusDivRF;

        /// <summary>���i����</summary>
        /// <remarks>���s�R�[�h��\n�ɒu��</remarks>
        private string _goodsNoteRF = "";

        /// <summary>���iPR</summary>
        /// <remarks>���s�R�[�h��\n�ɒu��</remarks>
        private string _goodsPRRF = "";

        /// <summary>��]�������i</summary>
        private Double _suggestPriceRF;

        /// <summary>�X�����i</summary>
        private Double _shopPriceRF;

        /// <summary>���l</summary>
        private Double _tradePriceRF;

        /// <summary>�d������</summary>
        private Double _purchaseCostRF;

        /// <summary>PM�X�V����</summary>
        private Int64 _pMUpdateTimeRF;

        /// <summary>�����^�O1</summary>
        private string _searchTag1RF = "";

        /// <summary>�����^�O2</summary>
        private string _searchTag2RF = "";

        /// <summary>�����^�O3</summary>
        private string _searchTag3RF = "";

        /// <summary>�����^�O4</summary>
        private string _searchTag4RF = "";

        /// <summary>�����^�O5</summary>
        private string _searchTag5RF = "";

        /// <summary>�����^�O6</summary>
        private string _searchTag6RF = "";

        /// <summary>�����^�O7</summary>
        private string _searchTag7RF = "";

        /// <summary>�����^�O8</summary>
        private string _searchTag8RF = "";

        /// <summary>�����^�O9</summary>
        private string _searchTag9RF = "";

        /// <summary>�����^�O10</summary>
        private string _searchTag10RF = "";

        /// <summary>�݌ɐ�</summary>
        private Double _shipmentPosCntRF;

        /// <summary>�Œ�݌ɐ�</summary>
        private Double _minimumStockCntRF;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeRF;

        /// <summary>BL���i�R�[�h�}��</summary>
        private Int32 _bLGoodsCodeDivRF;

        /// public propaty name  :  SectionCodeRF
        /// <summary>���_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeRF
        {
            get { return _sectionCodeRF; }
            set { _sectionCodeRF = value; }
        }

        /// public propaty name  :  GoodsCategoryRF
        /// <summary>���i�J�e�S���v���p�e�B</summary>
        /// <value>1:�^�C��,2:�o�b�e���[,3:�I�C��,</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�e�S���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsCategoryRF
        {
            get { return _goodsCategoryRF; }
            set { _goodsCategoryRF = value; }
        }

        /// public propaty name  :  GoodsNoRF
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoRF
        {
            get { return _goodsNoRF; }
            set { _goodsNoRF = value; }
        }

        /// public propaty name  :  GoodsNameRF
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameRF
        {
            get { return _goodsNameRF; }
            set { _goodsNameRF = value; }
        }

        /// public propaty name  :  GoodsMakerCdRF
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdRF
        {
            get { return _goodsMakerCdRF; }
            set { _goodsMakerCdRF = value; }
        }

        /// public propaty name  :  MakerNameRF
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerNameRF
        {
            get { return _makerNameRF; }
            set { _makerNameRF = value; }
        }

        /// public propaty name  :  ReleaseDateRF
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReleaseDateRF
        {
            get { return _releaseDateRF; }
            set { _releaseDateRF = value; }
        }

        /// public propaty name  :  StockStatusDivRF
        /// <summary>�݌ɏ󋵋敪�v���p�e�B</summary>
        /// <value>0:���ב҂�,1:�݌ɕs��,2:�݌Ɏc��,3:�݌ɖL�x</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockStatusDivRF
        {
            get { return _stockStatusDivRF; }
            set { _stockStatusDivRF = value; }
        }

        /// public propaty name  :  GoodsNoteRF
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>���s�R�[�h��\n�ɒu��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoteRF
        {
            get { return _goodsNoteRF; }
            set { _goodsNoteRF = value; }
        }

        /// public propaty name  :  GoodsPRRF
        /// <summary>���iPR�R�[�h�v���p�e�B</summary>
        /// <value>���s�R�[�h��\n�ɒu��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���iPR�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsPRRF
        {
            get { return _goodsPRRF; }
            set { _goodsPRRF = value; }
        }

        /// public propaty name  :  SuggestPriceRF
        /// <summary>��]�������i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�������i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SuggestPriceRF
        {
            get { return _suggestPriceRF; }
            set { _suggestPriceRF = value; }
        }

        /// public propaty name  :  ShopPriceRF
        /// <summary>�X�����i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShopPriceRF
        {
            get { return _shopPriceRF; }
            set { _shopPriceRF = value; }
        }

        /// public propaty name  :  TradePriceRF
        /// <summary>���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TradePriceRF
        {
            get { return _tradePriceRF; }
            set { _tradePriceRF = value; }
        }

        /// public propaty name  :  PurchaseCostRF
        /// <summary>�d�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PurchaseCostRF
        {
            get { return _purchaseCostRF; }
            set { _purchaseCostRF = value; }
        }

        /// public propaty name  :  PMUpdateTimeRF
        /// <summary>PM�X�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PMUpdateTimeRF
        {
            get { return _pMUpdateTimeRF; }
            set { _pMUpdateTimeRF = value; }
        }

        /// public propaty name  :  SearchTag1RF
        /// <summary>�����^�O1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag1RF
        {
            get { return _searchTag1RF; }
            set { _searchTag1RF = value; }
        }

        /// public propaty name  :  SearchTag2RF
        /// <summary>�����^�O2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag2RF
        {
            get { return _searchTag2RF; }
            set { _searchTag2RF = value; }
        }

        /// public propaty name  :  SearchTag3RF
        /// <summary>�����^�O3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag3RF
        {
            get { return _searchTag3RF; }
            set { _searchTag3RF = value; }
        }

        /// public propaty name  :  SearchTag4RF
        /// <summary>�����^�O4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag4RF
        {
            get { return _searchTag4RF; }
            set { _searchTag4RF = value; }
        }

        /// public propaty name  :  SearchTag5RF
        /// <summary>�����^�O5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag5RF
        {
            get { return _searchTag5RF; }
            set { _searchTag5RF = value; }
        }

        /// public propaty name  :  SearchTag6RF
        /// <summary>�����^�O6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag6RF
        {
            get { return _searchTag6RF; }
            set { _searchTag6RF = value; }
        }

        /// public propaty name  :  SearchTag7RF
        /// <summary>�����^�O7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag7RF
        {
            get { return _searchTag7RF; }
            set { _searchTag7RF = value; }
        }

        /// public propaty name  :  SearchTag8RF
        /// <summary>�����^�O8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag8RF
        {
            get { return _searchTag8RF; }
            set { _searchTag8RF = value; }
        }

        /// public propaty name  :  SearchTag9RF
        /// <summary>�����^�O9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag9RF
        {
            get { return _searchTag9RF; }
            set { _searchTag9RF = value; }
        }

        /// public propaty name  :  SearchTag10RF
        /// <summary>�����^�O10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag10RF
        {
            get { return _searchTag10RF; }
            set { _searchTag10RF = value; }
        }

        /// public propaty name  :  ShipmentPosCntRF
        /// <summary>�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCntRF
        {
            get { return _shipmentPosCntRF; }
            set { _shipmentPosCntRF = value; }
        }

        /// public propaty name  :  MinimumStockCntRF
        /// <summary>�Œ�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Œ�݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MinimumStockCntRF
        {
            get { return _minimumStockCntRF; }
            set { _minimumStockCntRF = value; }
        }

        /// public propaty name  :  BLGoodsCodeRF
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeRF
        {
            get { return _bLGoodsCodeRF; }
            set { _bLGoodsCodeRF = value; }
        }

        /// public propaty name  :  BLGoodsCodeDivRF
        /// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeDivRF
        {
            get { return _bLGoodsCodeDivRF; }
            set { _bLGoodsCodeDivRF = value; }
        }


        /// <summary>
        /// �R�[�G�C�� �s�a�n���o�͒��o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TBODataExportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBODataExportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TBODataExportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TBODataExportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TBODataExportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBODataExportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBODataExportResultWork || graph is ArrayList || graph is TBODataExportResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TBODataExportResultWork).FullName));

            if (graph != null && graph is TBODataExportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBODataExportResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBODataExportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBODataExportResultWork[])graph).Length;
            }
            else if (graph is TBODataExportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;   //�J��Ԃ��� 

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCodeRF
            //���i�J�e�S��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsCategoryRF
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoRF
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameRF
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));  //GoodsMakerCdRF
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerNameRF
            //������
            serInfo.MemberInfo.Add(typeof(Int32)); //ReleaseDateRF
            //�݌ɏ󋵋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockStatusDivRF
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoteRF
            //���iPR
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPRRF
            //��]�������i
            serInfo.MemberInfo.Add(typeof(Double)); //SuggestPriceRF
            //�X�����i
            serInfo.MemberInfo.Add(typeof(Double)); //ShopPriceRF
            //���l
            serInfo.MemberInfo.Add(typeof(Double)); //TradePriceRF
            //�d������
            serInfo.MemberInfo.Add(typeof(Double)); //PurchaseCostRF
            //PM�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //PMUpdateTimeRF
            //�����^�O1
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag1RF
            //�����^�O2
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag2RF
            //�����^�O3
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag3RF
            //�����^�O4
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag4RF
            //�����^�O5
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag5RF
            //�����^�O6
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag6RF
            //�����^�O7
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag7RF
            //�����^�O8
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag8RF
            //�����^�O9
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag9RF
            //�����^�O10
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag10RF
            //�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCntRF
            //�Œ�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCntRF
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeRF
            //BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeDivRF

            serInfo.Serialize(writer, serInfo);
            if (graph is TBODataExportResultWork)
            {
                TBODataExportResultWork temp = (TBODataExportResultWork)graph;

                TBODataExportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBODataExportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBODataExportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBODataExportResultWork temp in lst)
                {
                    TBODataExportResultWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// TBODataExportResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 29;

        /// <summary>
        ///  TBODataExportResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void TBODataExportResultWork(System.IO.BinaryWriter writer, TBODataExportResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCodeRF);
            //���i�J�e�S��
            writer.Write(temp.GoodsCategoryRF);
            //���i�ԍ�
            writer.Write(temp.GoodsNoRF);
            //���i����
            writer.Write(temp.GoodsNameRF);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCdRF);
            //���[�J�[����
            writer.Write(temp.MakerNameRF);
            //������
            writer.Write(temp.ReleaseDateRF);
            //�݌ɏ󋵋敪
            writer.Write(temp.StockStatusDivRF);
            //���i����
            writer.Write(temp.GoodsNoteRF);
            //���iPR
            writer.Write(temp.GoodsPRRF);
            //��]�������i
            writer.Write(temp.SuggestPriceRF);
            //�X�����i
            writer.Write(temp.ShopPriceRF);
            //���l
            writer.Write(temp.TradePriceRF);
            //�d������
            writer.Write(temp.PurchaseCostRF);
            //PM�X�V����
            writer.Write(temp.PMUpdateTimeRF);
            //�����^�O1
            writer.Write(temp.SearchTag1RF);
            //�����^�O2
            writer.Write(temp.SearchTag2RF);
            //�����^�O3
            writer.Write(temp.SearchTag3RF);
            //�����^�O4
            writer.Write(temp.SearchTag4RF);
            //�����^�O5
            writer.Write(temp.SearchTag5RF);
            //�����^�O6
            writer.Write(temp.SearchTag6RF);
            //�����^�O7
            writer.Write(temp.SearchTag7RF);
            //�����^�O8
            writer.Write(temp.SearchTag8RF);
            //�����^�O9
            writer.Write(temp.SearchTag9RF);
            //�����^�O10
            writer.Write(temp.SearchTag10RF);
            //�݌ɐ�
            writer.Write(temp.ShipmentPosCntRF);
            //�Œ�݌ɐ�
            writer.Write(temp.MinimumStockCntRF);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCodeRF);
            //BL���i�R�[�h�}��
            writer.Write(temp.BLGoodsCodeDivRF);
        }

        /// <summary>
        ///  TBODataExportResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TBODataExportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private TBODataExportResultWork GetTBODataExportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TBODataExportResultWork temp = new TBODataExportResultWork();


            //���_�R�[�h
            temp.SectionCodeRF = reader.ReadString();
            //���i�J�e�S��
            temp.GoodsCategoryRF = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNoRF = reader.ReadString();
            //���i����
            temp.GoodsNameRF = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCdRF = reader.ReadInt32();
            //���[�J�[����
            temp.MakerNameRF = reader.ReadString();
            //������
            temp.ReleaseDateRF = reader.ReadInt32();
            //�݌ɏ󋵋敪
            temp.StockStatusDivRF = reader.ReadInt32();
            //���i����
            temp.GoodsNoteRF = reader.ReadString();
            //���iPR
            temp.GoodsPRRF = reader.ReadString();
            //��]�������i
            temp.SuggestPriceRF = reader.ReadDouble();
            //�X�����i
            temp.ShopPriceRF = reader.ReadDouble();
            //���l
            temp.TradePriceRF = reader.ReadDouble();
            //�d������
            temp.PurchaseCostRF = reader.ReadDouble();
            //PM�X�V����
            temp.PMUpdateTimeRF = reader.ReadInt64();
            //�����^�O1
            temp.SearchTag1RF = reader.ReadString();
            //�����^�O2
            temp.SearchTag2RF = reader.ReadString();
            //�����^�O3
            temp.SearchTag3RF = reader.ReadString();
            //�����^�O4
            temp.SearchTag4RF = reader.ReadString();
            //�����^�O5
            temp.SearchTag5RF = reader.ReadString();
            //�����^�O6
            temp.SearchTag6RF = reader.ReadString();
            //�����^�O7
            temp.SearchTag7RF = reader.ReadString();
            //�����^�O8
            temp.SearchTag8RF = reader.ReadString();
            //�����^�O9
            temp.SearchTag9RF = reader.ReadString();
            //�����^�O10
            temp.SearchTag10RF = reader.ReadString();
            //�݌ɐ�
            temp.ShipmentPosCntRF = reader.ReadDouble();
            //�Œ�݌ɐ�
            temp.MinimumStockCntRF = reader.ReadDouble();
            //BL���i�R�[�h
            temp.BLGoodsCodeRF = reader.ReadInt32();
            //BL���i�R�[�h�}��
            temp.BLGoodsCodeDivRF = reader.ReadInt32();


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
        /// <returns>TBODataExportResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBODataExportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBODataExportResultWork temp = GetTBODataExportResultWork(reader, serInfo);
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
                    retValue = (TBODataExportResultWork[])lst.ToArray(typeof(TBODataExportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

