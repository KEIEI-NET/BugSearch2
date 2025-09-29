using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipGdsPrimeListResultWork
    /// <summary>
    ///                      �o�׏��i�D�ǑΉ��\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�׏��i�D�ǑΉ��\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipGdsPrimeListResultWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// <summary>�Ή����i�ԍ�</summary>
        private string _oldGoodsNo = "";
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>����񐔁i�݌Ɂj</summary>
        /// <remarks>�o�׉�(���㎞�̂݁j</remarks>
        private Int32 _st_SalesTimes;

        /// <summary>���㐔�v�i�݌Ɂj</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _st_TotalSalesCount;

        /// <summary>������z�i�݌Ɂj</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _st_SalesMoney;

        /// <summary>�ԕi�z�i�݌Ɂj</summary>
        private Int64 _st_SalesRetGoodsPrice;

        /// <summary>�l�����z�i�݌Ɂj</summary>
        private Int64 _st_DiscountPrice;

        /// <summary>�e�����z�i�݌Ɂj</summary>
        private Int64 _st_GrossProfit;

        /// <summary>����񐔁i���j</summary>
        /// <remarks>�o�׉�(���㎞�̂݁j</remarks>
        private Int32 _or_SalesTimes;

        /// <summary>���㐔�v�i���j</summary>
        /// <remarks>�o�א�(�ԕi�͌��Z)</remarks>
        private Double _or_TotalSalesCount;

        /// <summary>������z�i���j</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _or_SalesMoney;

        /// <summary>�ԕi�z�i���j</summary>
        private Int64 _or_SalesRetGoodsPrice;

        /// <summary>�l�����z�i���j</summary>
        private Int64 _or_DiscountPrice;

        /// <summary>�e�����z�i���j</summary>
        private Int64 _or_GrossProfit;


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
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

        //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
        /// public propaty name  :  OldGoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldGoodsNo
        {
            get { return _oldGoodsNo; }
            set { _oldGoodsNo = value; }
        }
        //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

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

        /// public propaty name  :  St_SalesTimes
        /// <summary>����񐔁i�݌Ɂj�v���p�e�B</summary>
        /// <value>�o�׉�(���㎞�̂݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔁i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesTimes
        {
            get { return _st_SalesTimes; }
            set { _st_SalesTimes = value; }
        }

        /// public propaty name  :  St_TotalSalesCount
        /// <summary>���㐔�v�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_TotalSalesCount
        {
            get { return _st_TotalSalesCount; }
            set { _st_TotalSalesCount = value; }
        }

        /// public propaty name  :  St_SalesMoney
        /// <summary>������z�i�݌Ɂj�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_SalesMoney
        {
            get { return _st_SalesMoney; }
            set { _st_SalesMoney = value; }
        }

        /// public propaty name  :  St_SalesRetGoodsPrice
        /// <summary>�ԕi�z�i�݌Ɂj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_SalesRetGoodsPrice
        {
            get { return _st_SalesRetGoodsPrice; }
            set { _st_SalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  St_DiscountPrice
        /// <summary>�l�����z�i�݌Ɂj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_DiscountPrice
        {
            get { return _st_DiscountPrice; }
            set { _st_DiscountPrice = value; }
        }

        /// public propaty name  :  St_GrossProfit
        /// <summary>�e�����z�i�݌Ɂj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�i�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_GrossProfit
        {
            get { return _st_GrossProfit; }
            set { _st_GrossProfit = value; }
        }

        /// public propaty name  :  Or_SalesTimes
        /// <summary>����񐔁i���j�v���p�e�B</summary>
        /// <value>�o�׉�(���㎞�̂݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔁i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Or_SalesTimes
        {
            get { return _or_SalesTimes; }
            set { _or_SalesTimes = value; }
        }

        /// public propaty name  :  Or_TotalSalesCount
        /// <summary>���㐔�v�i���j�v���p�e�B</summary>
        /// <value>�o�א�(�ԕi�͌��Z)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㐔�v�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Or_TotalSalesCount
        {
            get { return _or_TotalSalesCount; }
            set { _or_TotalSalesCount = value; }
        }

        /// public propaty name  :  Or_SalesMoney
        /// <summary>������z�i���j�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_SalesMoney
        {
            get { return _or_SalesMoney; }
            set { _or_SalesMoney = value; }
        }

        /// public propaty name  :  Or_SalesRetGoodsPrice
        /// <summary>�ԕi�z�i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_SalesRetGoodsPrice
        {
            get { return _or_SalesRetGoodsPrice; }
            set { _or_SalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  Or_DiscountPrice
        /// <summary>�l�����z�i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_DiscountPrice
        {
            get { return _or_DiscountPrice; }
            set { _or_DiscountPrice = value; }
        }

        /// public propaty name  :  Or_GrossProfit
        /// <summary>�e�����z�i���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�i���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Or_GrossProfit
        {
            get { return _or_GrossProfit; }
            set { _or_GrossProfit = value; }
        }


        /// <summary>
        /// �o�׏��i�D�ǑΉ��\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ShipGdsPrimeListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ShipGdsPrimeListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ShipGdsPrimeListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ShipGdsPrimeListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ShipGdsPrimeListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ShipGdsPrimeListResultWork || graph is ArrayList || graph is ShipGdsPrimeListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ShipGdsPrimeListResultWork).FullName));

            if (graph != null && graph is ShipGdsPrimeListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ShipGdsPrimeListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ShipGdsPrimeListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ShipGdsPrimeListResultWork[])graph).Length;
            }
            else if (graph is ShipGdsPrimeListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            //�Ή����i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OldGoodsNo
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //����񐔁i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int32)); //St_SalesTimes
            //���㐔�v�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Double)); //St_TotalSalesCount
            //������z�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int64)); //St_SalesMoney
            //�ԕi�z�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int64)); //St_SalesRetGoodsPrice
            //�l�����z�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int64)); //St_DiscountPrice
            //�e�����z�i�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Int64)); //St_GrossProfit
            //����񐔁i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //Or_SalesTimes
            //���㐔�v�i���j
            serInfo.MemberInfo.Add(typeof(Double)); //Or_TotalSalesCount
            //������z�i���j
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_SalesMoney
            //�ԕi�z�i���j
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_SalesRetGoodsPrice
            //�l�����z�i���j
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_DiscountPrice
            //�e�����z�i���j
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is ShipGdsPrimeListResultWork)
            {
                ShipGdsPrimeListResultWork temp = (ShipGdsPrimeListResultWork)graph;

                SetShipGdsPrimeListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ShipGdsPrimeListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ShipGdsPrimeListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ShipGdsPrimeListResultWork temp in lst)
                {
                    SetShipGdsPrimeListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ShipGdsPrimeListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 18; // DEL 2014/12/30 ������ FOR Redmine#44209����
        private const int currentMemberCount = 19; // ADD 2014/12/30 ������ FOR Redmine#44209����

        /// <summary>
        ///  ShipGdsPrimeListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetShipGdsPrimeListResultWork(System.IO.BinaryWriter writer, ShipGdsPrimeListResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            //�Ή����i�ԍ�
            writer.Write(temp.OldGoodsNo);
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //����񐔁i�݌Ɂj
            writer.Write(temp.St_SalesTimes);
            //���㐔�v�i�݌Ɂj
            writer.Write(temp.St_TotalSalesCount);
            //������z�i�݌Ɂj
            writer.Write(temp.St_SalesMoney);
            //�ԕi�z�i�݌Ɂj
            writer.Write(temp.St_SalesRetGoodsPrice);
            //�l�����z�i�݌Ɂj
            writer.Write(temp.St_DiscountPrice);
            //�e�����z�i�݌Ɂj
            writer.Write(temp.St_GrossProfit);
            //����񐔁i���j
            writer.Write(temp.Or_SalesTimes);
            //���㐔�v�i���j
            writer.Write(temp.Or_TotalSalesCount);
            //������z�i���j
            writer.Write(temp.Or_SalesMoney);
            //�ԕi�z�i���j
            writer.Write(temp.Or_SalesRetGoodsPrice);
            //�l�����z�i���j
            writer.Write(temp.Or_DiscountPrice);
            //�e�����z�i���j
            writer.Write(temp.Or_GrossProfit);

        }

        /// <summary>
        ///  ShipGdsPrimeListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ShipGdsPrimeListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ShipGdsPrimeListResultWork GetShipGdsPrimeListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ShipGdsPrimeListResultWork temp = new ShipGdsPrimeListResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            //�Ή����i�ԍ�
            temp.OldGoodsNo = reader.ReadString();
            //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //����񐔁i�݌Ɂj
            temp.St_SalesTimes = reader.ReadInt32();
            //���㐔�v�i�݌Ɂj
            temp.St_TotalSalesCount = reader.ReadDouble();
            //������z�i�݌Ɂj
            temp.St_SalesMoney = reader.ReadInt64();
            //�ԕi�z�i�݌Ɂj
            temp.St_SalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z�i�݌Ɂj
            temp.St_DiscountPrice = reader.ReadInt64();
            //�e�����z�i�݌Ɂj
            temp.St_GrossProfit = reader.ReadInt64();
            //����񐔁i���j
            temp.Or_SalesTimes = reader.ReadInt32();
            //���㐔�v�i���j
            temp.Or_TotalSalesCount = reader.ReadDouble();
            //������z�i���j
            temp.Or_SalesMoney = reader.ReadInt64();
            //�ԕi�z�i���j
            temp.Or_SalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z�i���j
            temp.Or_DiscountPrice = reader.ReadInt64();
            //�e�����z�i���j
            temp.Or_GrossProfit = reader.ReadInt64();


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
        /// <returns>ShipGdsPrimeListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipGdsPrimeListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ShipGdsPrimeListResultWork temp = GetShipGdsPrimeListResultWork(reader, serInfo);
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
                    retValue = (ShipGdsPrimeListResultWork[])lst.ToArray(typeof(ShipGdsPrimeListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
