using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AddUpOrgStockDetailWork
    /// <summary>
    /// �v�㌳�d�����׃f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �v�㌳�d�����׃f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �蓮����</br>
    /// <br>Date             :   2007/10/18</br>
    /// <br>Genarated Date   :   2007/10/18  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AddUpOrgStockDetailWork : StockDetailWork
    {
        // StockDetailWork ���p�����č쐬���Ă���̂ŁA�d�����׃f�[�^���C�A�E�g�ɕύX��
        // �L�����ꍇ�ł� StockDetailWork �����C������Ηǂ�
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AddUppOrgStockDetailWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AddUppOrgStockDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AddUpOrgStockDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgStockDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockDetailWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddUpOrgStockDetailWork || graph is ArrayList || graph is AddUpOrgStockDetailWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AddUpOrgStockDetailWork).FullName));

            if (graph != null && graph is AddUpOrgStockDetailWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddUpOrgStockDetailWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddUpOrgStockDetailWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddUpOrgStockDetailWork[])graph).Length;
            }
            else if (graph is AddUpOrgStockDetailWork)
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
            //�󒍔ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�d���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���ʒʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //�d�����גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            //�d���`���i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSrc
            //�d�����גʔԁi���j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSrc
            //�󒍃X�e�[�^�X�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSync
            //���㖾�גʔԁi�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSync
            //�d���`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCdDtl
            //�d�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //�d�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���[�J�[�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
            //���[�J�[�J�i���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //���Е��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�d���݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockOrderDivCd
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�d����|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppRateGrpCode
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //�|���ݒ苒�_�i�d���P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectStckUnPrc
            //�|���ݒ�敪�i�d���P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivStckUnPrc
            //�P���Z�o�敪�i�d���P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdStckUnPrc
            //���i�敪�i�d���P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdStckUnPrc
            //��P���i�d���P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcStckUnPrc
            //�[�������P�ʁi�d���P���j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitStcUnPrc
            //�[�������i�d���P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcStckUnPrc
            //�d���P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�d���P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitTaxPriceFl
            //�d���P���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChngDiv
            //�ύX�O�d���P���i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //�ύX�O�艿
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //BL���i�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL���i�R�[�h���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockCount
            //��������
            serInfo.MemberInfo.Add(typeof(Double)); //OrderCnt
            //����������
            serInfo.MemberInfo.Add(typeof(Double)); //OrderAdjustCnt
            //�����c��
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainCnt
            //�c���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //�d�����z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc
            //�d�����z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxInc
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationCode
            //�d���`�[���ה��l1
            serInfo.MemberInfo.Add(typeof(string)); //StockDtiSlipNote1
            //�̔���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCustomerCode
            //�̔��旪��
            serInfo.MemberInfo.Add(typeof(string)); //SalesCustomerSnm
            //�`�[�����P
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //�`�[�����Q
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //�`�[�����R
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //�Г������P
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //�Г������Q
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //�Г������R
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�[�i��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddresseeCode
            //�[�i�於��
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeName
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�������@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //��]�[��
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectDeliveryDate
            //�����f�[�^�쐬�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDiv
            //�����f�[�^�쐬��
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderDataCreateDate
            //���������s�ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OrderFormIssuedDiv
            //�d��������
            serInfo.MemberInfo.Add(typeof(Double)); //StockCountDifference
            //���׊֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid

            serInfo.Serialize(writer, serInfo);
            if (graph is AddUpOrgStockDetailWork)
            {
                AddUpOrgStockDetailWork temp = (AddUpOrgStockDetailWork)graph;

                SetStockDetailWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddUpOrgStockDetailWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddUpOrgStockDetailWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddUpOrgStockDetailWork temp in lst)
                {
                    SetStockDetailWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddUpOrgStockDetailWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 101;

        /// <summary>
        ///  AddUpOrgStockDetailWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgStockDetailWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockDetailWork(System.IO.BinaryWriter writer, AddUpOrgStockDetailWork temp)
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
            //�󒍔ԍ�
            writer.Write(temp.AcceptAnOrderNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�d���s�ԍ�
            writer.Write(temp.StockRowNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���ʒʔ�
            writer.Write(temp.CommonSeqNo);
            //�d�����גʔ�
            writer.Write(temp.StockSlipDtlNum);
            //�d���`���i���j
            writer.Write(temp.SupplierFormalSrc);
            //�d�����גʔԁi���j
            writer.Write(temp.StockSlipDtlNumSrc);
            //�󒍃X�e�[�^�X�i�����j
            writer.Write(temp.AcptAnOdrStatusSync);
            //���㖾�גʔԁi�����j
            writer.Write(temp.SalesSlipDtlNumSync);
            //�d���`�[�敪�i���ׁj
            writer.Write(temp.StockSlipCdDtl);
            //�d�����͎҃R�[�h
            writer.Write(temp.StockInputCode);
            //�d�����͎Җ���
            writer.Write(temp.StockInputName);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���[�J�[�J�i����
            writer.Write(temp.MakerKanaName);
            //���[�J�[�J�i���́i�ꎮ�j
            writer.Write(temp.CmpltMakerKanaName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ޖ���
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���
            writer.Write(temp.GoodsMGroupName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h����
            writer.Write(temp.BLGroupName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���Е��ޖ���
            writer.Write(temp.EnterpriseGanreName);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���݌Ɏ�񂹋敪
            writer.Write(temp.StockOrderDivCd);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //�d����|���O���[�v�R�[�h
            writer.Write(temp.SuppRateGrpCode);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�艿�i�ō��C�����j
            writer.Write(temp.ListPriceTaxIncFl);
            //�d����
            writer.Write(temp.StockRate);
            //�|���ݒ苒�_�i�d���P���j
            writer.Write(temp.RateSectStckUnPrc);
            //�|���ݒ�敪�i�d���P���j
            writer.Write(temp.RateDivStckUnPrc);
            //�P���Z�o�敪�i�d���P���j
            writer.Write(temp.UnPrcCalcCdStckUnPrc);
            //���i�敪�i�d���P���j
            writer.Write(temp.PriceCdStckUnPrc);
            //��P���i�d���P���j
            writer.Write(temp.StdUnPrcStckUnPrc);
            //�[�������P�ʁi�d���P���j
            writer.Write(temp.FracProcUnitStcUnPrc);
            //�[�������i�d���P���j
            writer.Write(temp.FracProcStckUnPrc);
            //�d���P���i�Ŕ��C�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���P���i�ō��C�����j
            writer.Write(temp.StockUnitTaxPriceFl);
            //�d���P���ύX�敪
            writer.Write(temp.StockUnitChngDiv);
            //�ύX�O�d���P���i�����j
            writer.Write(temp.BfStockUnitPriceFl);
            //�ύX�O�艿
            writer.Write(temp.BfListPrice);
            //BL���i�R�[�h�i�|���j
            writer.Write(temp.RateBLGoodsCode);
            //BL���i�R�[�h���́i�|���j
            writer.Write(temp.RateBLGoodsName);
            //�d����
            writer.Write(temp.StockCount);
            //��������
            writer.Write(temp.OrderCnt);
            //����������
            writer.Write(temp.OrderAdjustCnt);
            //�����c��
            writer.Write(temp.OrderRemainCnt);
            //�c���X�V��
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //�d�����z�i�Ŕ����j
            writer.Write(temp.StockPriceTaxExc);
            //�d�����z�i�ō��݁j
            writer.Write(temp.StockPriceTaxInc);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�ېŋ敪
            writer.Write(temp.TaxationCode);
            //�d���`�[���ה��l1
            writer.Write(temp.StockDtiSlipNote1);
            //�̔���R�[�h
            writer.Write(temp.SalesCustomerCode);
            //�̔��旪��
            writer.Write(temp.SalesCustomerSnm);
            //�`�[�����P
            writer.Write(temp.SlipMemo1);
            //�`�[�����Q
            writer.Write(temp.SlipMemo2);
            //�`�[�����R
            writer.Write(temp.SlipMemo3);
            //�Г������P
            writer.Write(temp.InsideMemo1);
            //�Г������Q
            writer.Write(temp.InsideMemo2);
            //�Г������R
            writer.Write(temp.InsideMemo3);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�[�i��R�[�h
            writer.Write(temp.AddresseeCode);
            //�[�i�於��
            writer.Write(temp.AddresseeName);
            //�����敪
            writer.Write(temp.DirectSendingCd);
            //�����ԍ�
            writer.Write(temp.OrderNumber);
            //�������@
            writer.Write(temp.WayToOrder);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //��]�[��
            writer.Write((Int64)temp.ExpectDeliveryDate.Ticks);
            //�����f�[�^�쐬�敪
            writer.Write(temp.OrderDataCreateDiv);
            //�����f�[�^�쐬��
            writer.Write((Int64)temp.OrderDataCreateDate.Ticks);
            //���������s�ϋ敪
            writer.Write(temp.OrderFormIssuedDiv);
            //�d��������
            writer.Write(temp.StockCountDifference);
            //���׊֘A�t��GUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
        }

        /// <summary>
        ///  AddUpOrgStockDetailWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AddUpOrgStockDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgStockDetailWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private AddUpOrgStockDetailWork GetStockDetailWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AddUpOrgStockDetailWork temp = new AddUpOrgStockDetailWork();

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
            //�󒍔ԍ�
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�d���s�ԍ�
            temp.StockRowNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���ʒʔ�
            temp.CommonSeqNo = reader.ReadInt64();
            //�d�����גʔ�
            temp.StockSlipDtlNum = reader.ReadInt64();
            //�d���`���i���j
            temp.SupplierFormalSrc = reader.ReadInt32();
            //�d�����גʔԁi���j
            temp.StockSlipDtlNumSrc = reader.ReadInt64();
            //�󒍃X�e�[�^�X�i�����j
            temp.AcptAnOdrStatusSync = reader.ReadInt32();
            //���㖾�גʔԁi�����j
            temp.SalesSlipDtlNumSync = reader.ReadInt64();
            //�d���`�[�敪�i���ׁj
            temp.StockSlipCdDtl = reader.ReadInt32();
            //�d�����͎҃R�[�h
            temp.StockInputCode = reader.ReadString();
            //�d�����͎Җ���
            temp.StockInputName = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���[�J�[�J�i����
            temp.MakerKanaName = reader.ReadString();
            //���[�J�[�J�i���́i�ꎮ�j
            temp.CmpltMakerKanaName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h����
            temp.BLGroupName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���Е��ޖ���
            temp.EnterpriseGanreName = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�d���݌Ɏ�񂹋敪
            temp.StockOrderDivCd = reader.ReadInt32();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�d����|���O���[�v�R�[�h
            temp.SuppRateGrpCode = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�艿�i�ō��C�����j
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�d����
            temp.StockRate = reader.ReadDouble();
            //�|���ݒ苒�_�i�d���P���j
            temp.RateSectStckUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�d���P���j
            temp.RateDivStckUnPrc = reader.ReadString();
            //�P���Z�o�敪�i�d���P���j
            temp.UnPrcCalcCdStckUnPrc = reader.ReadInt32();
            //���i�敪�i�d���P���j
            temp.PriceCdStckUnPrc = reader.ReadInt32();
            //��P���i�d���P���j
            temp.StdUnPrcStckUnPrc = reader.ReadDouble();
            //�[�������P�ʁi�d���P���j
            temp.FracProcUnitStcUnPrc = reader.ReadDouble();
            //�[�������i�d���P���j
            temp.FracProcStckUnPrc = reader.ReadInt32();
            //�d���P���i�Ŕ��C�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�d���P���i�ō��C�����j
            temp.StockUnitTaxPriceFl = reader.ReadDouble();
            //�d���P���ύX�敪
            temp.StockUnitChngDiv = reader.ReadInt32();
            //�ύX�O�d���P���i�����j
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //�ύX�O�艿
            temp.BfListPrice = reader.ReadDouble();
            //BL���i�R�[�h�i�|���j
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�|���j
            temp.RateBLGoodsName = reader.ReadString();
            //�d����
            temp.StockCount = reader.ReadDouble();
            //��������
            temp.OrderCnt = reader.ReadDouble();
            //����������
            temp.OrderAdjustCnt = reader.ReadDouble();
            //�����c��
            temp.OrderRemainCnt = reader.ReadDouble();
            //�c���X�V��
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //�d�����z�i�Ŕ����j
            temp.StockPriceTaxExc = reader.ReadInt64();
            //�d�����z�i�ō��݁j
            temp.StockPriceTaxInc = reader.ReadInt64();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�ېŋ敪
            temp.TaxationCode = reader.ReadInt32();
            //�d���`�[���ה��l1
            temp.StockDtiSlipNote1 = reader.ReadString();
            //�̔���R�[�h
            temp.SalesCustomerCode = reader.ReadInt32();
            //�̔��旪��
            temp.SalesCustomerSnm = reader.ReadString();
            //�`�[�����P
            temp.SlipMemo1 = reader.ReadString();
            //�`�[�����Q
            temp.SlipMemo2 = reader.ReadString();
            //�`�[�����R
            temp.SlipMemo3 = reader.ReadString();
            //�Г������P
            temp.InsideMemo1 = reader.ReadString();
            //�Г������Q
            temp.InsideMemo2 = reader.ReadString();
            //�Г������R
            temp.InsideMemo3 = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�[�i��R�[�h
            temp.AddresseeCode = reader.ReadInt32();
            //�[�i�於��
            temp.AddresseeName = reader.ReadString();
            //�����敪
            temp.DirectSendingCd = reader.ReadInt32();
            //�����ԍ�
            temp.OrderNumber = reader.ReadString();
            //�������@
            temp.WayToOrder = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //��]�[��
            temp.ExpectDeliveryDate = new DateTime(reader.ReadInt64());
            //�����f�[�^�쐬�敪
            temp.OrderDataCreateDiv = reader.ReadInt32();
            //�����f�[�^�쐬��
            temp.OrderDataCreateDate = new DateTime(reader.ReadInt64());
            //���������s�ϋ敪
            temp.OrderFormIssuedDiv = reader.ReadInt32();
            //�d��������
            temp.StockCountDifference = reader.ReadDouble();
            //���׊֘A�t��GUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);

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
        /// <returns>AddUpOrgStockDetailWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgStockDetailWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddUpOrgStockDetailWork temp = GetStockDetailWork(reader, serInfo);
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
                    retValue = (AddUpOrgStockDetailWork[])lst.ToArray(typeof(AddUpOrgStockDetailWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
