using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesAnnualDataSelectResultWork
    /// <summary>
    ///                      ����N�Ԏ��яƉ�o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����N�Ԏ��яƉ�o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesAnnualDataSelectResultWork
    {
        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aUPYearMonth;

        /// <summary>���яW�v�敪</summary>
        /// <remarks>0:���i���v 1:�݌� 2:���� 3:���</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>������z</summary>
        /// <remarks>�Ŕ����i�l��,�ԕi�܂܂��j</remarks>
        private Int64 _salesMoney;

        /// <summary>�ԕi�z</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>�l�����z</summary>
        private Int64 _discountPrice;

        /// <summary>�e���z</summary>
        private Int64 _grossProfit;

        /// <summary>����ڕW�z</summary>
        /// <remarks>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</remarks>
        private Int64 _salesTargetMoney;

        /// <summary>�e���ڕW�z</summary>
        /// <remarks>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</remarks>
        private Int64 _salesTargetProfit;

        /// <summary>�����</summary>
        /// <remarks>�o�׉�(���㎞�̂݁j</remarks>
        private Int32 _salesTimes;

        /// <summary>���ԓ`�[����</summary>
        /// <remarks>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</remarks>
        private Int32 _termSalesSlipCount;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:��Ɓ@�����Ӑ�ʂ̂ݎg�p</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>����݌Ɏ��敪 </summary>
        /// <remarks>0:���A1:�݌Ɂ@�����Ӑ�ʂ̂ݎg�p</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>���i����</summary>
        /// <remarks>0:�����A1:���̑��@�����Ӑ�ʂ̂ݎg�p</remarks>
        private Int32 _goodsKindCode;

        /// <summary>������z�i�Ŕ����j</summary>
        /// <remarks>������z�i�Ŕ����j</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>����</summary>
        private Int64 _cost;

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        /// <summary>���_����</summary>
        private string _sectionName = string.Empty;

        /// <summary>selectionCode</summary>
        private string _selectionCode = string.Empty;

        /// <summary>selectionName</summary>
        private string _selectionName = string.Empty;
        // --- ADD 2010/08/02 --------------------------------<<<<<

        /// public propaty name  :  AUPYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AUPYearMonth
        {
            get { return _aUPYearMonth; }
            set { _aUPYearMonth = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>���яW�v�敪�v���p�e�B</summary>
        /// <value>0:���i���v 1:�݌� 2:���� 3:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���яW�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  SalesMoney
        /// <summary>������z�v���p�e�B</summary>
        /// <value>�Ŕ����i�l��,�ԕi�܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney
        {
            get { return _salesMoney; }
            set { _salesMoney = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>�ԕi�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>�l�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW�z�v���p�e�B</summary>
        /// <value>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>�e���ڕW�z�v���p�e�B</summary>
        /// <value>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���ڕW�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>����񐔃v���p�e�B</summary>
        /// <value>�o�׉�(���㎞�̂݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  TermSalesSlipCount
        /// <summary>���ԓ`�[�����v���p�e�B</summary>
        /// <value>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԓ`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TermSalesSlipCount
        {
            get { return _termSalesSlipCount; }
            set { _termSalesSlipCount = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:��Ɓ@�����Ӑ�ʂ̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ��敪 �v���p�e�B</summary>
        /// <value>0:���A1:�݌Ɂ@�����Ӑ�ʂ̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ��敪 �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:�����A1:���̑��@�����Ӑ�ʂ̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j</value>
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

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }


        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  _sectionName
        /// <summary>���_�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  SelectionCode
        /// <summary>SelectionCode�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionCode�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelectionCode
        {
            get { return _selectionCode; }
            set { _selectionCode = value; }
        }

        /// public propaty name  :  SelectionName
        /// <summary>SelectionName�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionName�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelectionName
        {
            get { return _selectionName; }
            set { _selectionName = value; }
        }

        // --- ADD 2010/08/02 --------------------------------<<<<<


        /// <summary>
        /// ����N�Ԏ��яƉ�o���ʃN���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesAnnualDataSelectResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesAnnualDataSelectResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesAnnualDataSelectResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesAnnualDataSelectResultWork || graph is ArrayList || graph is SalesAnnualDataSelectResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesAnnualDataSelectResultWork).FullName));

            if (graph != null && graph is SalesAnnualDataSelectResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesAnnualDataSelectResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesAnnualDataSelectResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesAnnualDataSelectResultWork[])graph).Length;
            }
            else if (graph is SalesAnnualDataSelectResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AUPYearMonth
            //���яW�v�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RsltTtlDivCd
            //������z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney
            //�ԕi�z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //�l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //����ڕW�z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //�e���ڕW�z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit
            //�����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //���ԓ`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //TermSalesSlipCount
            //����`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //����݌Ɏ��敪 
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            // --- ADD 2010/08/02 -------------------------------->>>>>
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //SelectionCode
            serInfo.MemberInfo.Add(typeof(string)); //SelectionCode
            //SelectionName
            serInfo.MemberInfo.Add(typeof(string)); //SelectionName
            // --- ADD 2010/08/02 --------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SalesAnnualDataSelectResultWork)
            {
                SalesAnnualDataSelectResultWork temp = (SalesAnnualDataSelectResultWork)graph;

                SetSalesAnnualDataSelectResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesAnnualDataSelectResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesAnnualDataSelectResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesAnnualDataSelectResultWork temp in lst)
                {
                    SetSalesAnnualDataSelectResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesAnnualDataSelectResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 15; // DEL 2010/08/02
        private const int currentMemberCount = 19; // ADD 2010/08/02

        /// <summary>
        ///  SalesAnnualDataSelectResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalesAnnualDataSelectResultWork(System.IO.BinaryWriter writer, SalesAnnualDataSelectResultWork temp)
        {
            //�v��N��
            writer.Write(temp.AUPYearMonth);
            //���яW�v�敪
            writer.Write(temp.RsltTtlDivCd);
            //������z
            writer.Write(temp.SalesMoney);
            //�ԕi�z
            writer.Write(temp.SalesRetGoodsPrice);
            //�l�����z
            writer.Write(temp.DiscountPrice);
            //�e���z
            writer.Write(temp.GrossProfit);
            //����ڕW�z
            writer.Write(temp.SalesTargetMoney);
            //�e���ڕW�z
            writer.Write(temp.SalesTargetProfit);
            //�����
            writer.Write(temp.SalesTimes);
            //���ԓ`�[����
            writer.Write(temp.TermSalesSlipCount);
            //����`�[�敪
            writer.Write(temp.SalesSlipCdDtl);
            //����݌Ɏ��敪 
            writer.Write(temp.SalesOrderDivCd);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //����
            writer.Write(temp.Cost);
            // --- ADD 2010/08/02 -------------------------------->>>>>
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_����
            writer.Write(temp.SectionName);
            //SelectionCode
            writer.Write(temp.SelectionCode);
            //SelectionName
            writer.Write(temp.SelectionName);
            // --- ADD 2010/08/02 --------------------------------<<<<<

        }

        /// <summary>
        ///  SalesAnnualDataSelectResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesAnnualDataSelectResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalesAnnualDataSelectResultWork GetSalesAnnualDataSelectResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesAnnualDataSelectResultWork temp = new SalesAnnualDataSelectResultWork();

            //�v��N��
            temp.AUPYearMonth = reader.ReadInt32();
            //���яW�v�敪
            temp.RsltTtlDivCd = reader.ReadInt32();
            //������z
            temp.SalesMoney = reader.ReadInt64();
            //�ԕi�z
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z
            temp.DiscountPrice = reader.ReadInt64();
            //�e���z
            temp.GrossProfit = reader.ReadInt64();
            //����ڕW�z
            temp.SalesTargetMoney = reader.ReadInt64();
            //�e���ڕW�z
            temp.SalesTargetProfit = reader.ReadInt64();
            //�����
            temp.SalesTimes = reader.ReadInt32();
            //���ԓ`�[����
            temp.TermSalesSlipCount = reader.ReadInt32();
            //����`�[�敪
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //����݌Ɏ��敪 
            temp.SalesOrderDivCd = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //����
            temp.Cost = reader.ReadInt64();
            // --- ADD 2010/08/02 -------------------------------->>>>>
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_����
            temp.SectionName = reader.ReadString();
            //SelectionCode
            temp.SelectionCode = reader.ReadString();
            //SelectionName
            temp.SelectionName = reader.ReadString();
            // --- ADD 2010/08/02 --------------------------------<<<<<


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
        /// <returns>SalesAnnualDataSelectResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesAnnualDataSelectResultWork temp = GetSalesAnnualDataSelectResultWork(reader, serInfo);
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
                    retValue = (SalesAnnualDataSelectResultWork[])lst.ToArray(typeof(SalesAnnualDataSelectResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
