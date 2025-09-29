using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AddUpOrgSalesDetailWork
    /// <summary>
    /// �v�㌳���㖾�׃f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �v�㌳���㖾�׃f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �蓮����</br>
    /// <br>Date             :   2007/11/20</br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AddUpOrgSalesDetailWork : SalesDetailWork
    {
        // SalesDetailWork ���p�����č쐬���Ă���̂ŁA���㖾�׃f�[�^���C�A�E�g�ɕύX��
        // �L�����ꍇ�ł� StockDetailWork �����C������Ηǂ�
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AddUpOrgSalesDetailWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AddUpOrgSalesDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AddUpOrgSalesDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgSalesDetailWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AddUpOrgSalesDetailWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddUpOrgSalesDetailWork || graph is ArrayList || graph is AddUpOrgSalesDetailWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AddUpOrgSalesDetailWork).FullName));

            if (graph != null && graph is AddUpOrgSalesDetailWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddUpOrgSalesDetailWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddUpOrgSalesDetailWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddUpOrgSalesDetailWork[])graph).Length;
            }
            else if (graph is AddUpOrgSalesDetailWork)
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
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //����s�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowDerivNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���ʒʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //���㖾�גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //�󒍃X�e�[�^�X�i���j
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSrc
            //���㖾�גʔԁi���j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSrc
            //�d���`���i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSync
            //�d�����גʔԁi�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSync
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //�[�i�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���i�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSearchDivCd
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���[�J�[�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //MakerKanaName
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
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�艿��
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceRate
            //�|���ݒ苒�_�i�艿�j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectPriceUnPrc
            //�|���ݒ�敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivLPrice
            //�P���Z�o�敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdLPrice
            //���i�敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdLPrice
            //��P���i�艿�j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcLPrice
            //�[�������P�ʁi�艿�j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitLPrice
            //�[�������i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcLPrice
            //�艿�i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�艿�ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceChngCd
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //�|���ݒ苒�_�i����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectSalUnPrc
            //�|���ݒ�敪�i����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivSalUnPrc
            //�P���Z�o�敪�i����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdSalUnPrc
            //���i�敪�i����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdSalUnPrc
            //��P���i����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //�[�������P�ʁi����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitSalUnPrc
            //�[�������i����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcSalUnPrc
            //����P���i�ō��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //����P���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcChngCd
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //CostRate
            //�|���ݒ苒�_�i�����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateSectCstUnPrc
            //�|���ݒ�敪�i�����P���j
            serInfo.MemberInfo.Add(typeof(string)); //RateDivUnCst
            //�P���Z�o�敪�i�����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdUnCst
            //���i�敪�i�����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdUnCst
            //��P���i�����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcUnCst
            //�[�������P�ʁi�����P���j
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitUnCst
            //�[�������i�����P���j
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcUnCst
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //�����P���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnitCostChngDiv
            //BL���i�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL���i�R�[�h���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //���i�|���O���[�v�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateGoodsRateGrpCd
            //���i�|���O���[�v���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateGoodsRateGrpNm
            //BL�O���[�v�R�[�h�i�|���j
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGroupCode
            //BL�O���[�v���́i�|���j
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGroupName
            //BL���i�R�[�h�i����j
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCode
            //BL���i�R�[�h���́i����j
            serInfo.MemberInfo.Add(typeof(string)); //PrtBLGoodsName
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�̔��敪����
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //��ƍH��
            serInfo.MemberInfo.Add(typeof(Double)); //WorkManHour
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //�󒍒�����
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrAdjustCnt
            //�󒍎c��
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //�c���X�V��
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //������z�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //�e���`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GrsProfitChkDiv
            //���㏤�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //������z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //�����`�[�ԍ��i���ׁj
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //���ה��l
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //�������@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
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
            //�ύX�O�艿
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //�ύX�O����
            serInfo.MemberInfo.Add(typeof(Double)); //BfSalesUnitPrice
            //�ύX�O����
            serInfo.MemberInfo.Add(typeof(Double)); //BfUnitCost
            //�ꎮ���הԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltSalesRowNo
            //���[�J�[�R�[�h�i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltGoodsMakerCd
            //���[�J�[���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerName
            //���[�J�[�J�i���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerKanaName
            //���i���́i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltGoodsName
            //���ʁi�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltShipmentCnt
            //����P���i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnPrcFl
            //������z�i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltSalesMoney
            //�����P���i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnitCost
            //�������z�i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltCost
            //�����`�[�ԍ��i�ꎮ�j
            serInfo.MemberInfo.Add(typeof(string)); //CmpltPartySalSlNum
            //�ꎮ���l
            serInfo.MemberInfo.Add(typeof(string)); //CmpltNote
            //����p�i��
            serInfo.MemberInfo.Add(typeof(string)); //PrtGoodsNo
            //����p���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtMakerCode
            //����p���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //PrtMakerName
            //�L�����y�[���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //�L�����y�[������
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //���i���
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //�񓚔[��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate
            //���T�C�N���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RecycleDiv
            //���T�C�N���敪����
            serInfo.MemberInfo.Add(typeof(string)); //RecycleDivNm
            //�󒍕��@
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToAcptOdr
            //�o�׍�����
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmCntDifference
            //���׊֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid
            //�݌ɍX�V�敪(�ǎ��p)
            //serInfo.MemberInfo.Add(typeof(Boolean)); //StockUpdateDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is AddUpOrgSalesDetailWork)
            {
                AddUpOrgSalesDetailWork temp = (AddUpOrgSalesDetailWork)graph;

                SetAddUpOrgSalesDetailWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddUpOrgSalesDetailWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddUpOrgSalesDetailWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddUpOrgSalesDetailWork temp in lst)
                {
                    SetAddUpOrgSalesDetailWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddUpOrgSalesDetailWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 143;  // �ǎ��p�v���p�e�B�������Z

        /// <summary>
        ///  AddUpOrgSalesDetailWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgSalesDetailWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetAddUpOrgSalesDetailWork(System.IO.BinaryWriter writer, AddUpOrgSalesDetailWork temp)
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
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����s�ԍ�
            writer.Write(temp.SalesRowNo);
            //����s�ԍ��}��
            writer.Write(temp.SalesRowDerivNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //���ʒʔ�
            writer.Write(temp.CommonSeqNo);
            //���㖾�גʔ�
            writer.Write(temp.SalesSlipDtlNum);
            //�󒍃X�e�[�^�X�i���j
            writer.Write(temp.AcptAnOdrStatusSrc);
            //���㖾�גʔԁi���j
            writer.Write(temp.SalesSlipDtlNumSrc);
            //�d���`���i�����j
            writer.Write(temp.SupplierFormalSync);
            //�d�����גʔԁi�����j
            writer.Write(temp.StockSlipDtlNumSync);
            //����`�[�敪�i���ׁj
            writer.Write(temp.SalesSlipCdDtl);
            //�[�i�����\���
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���i�����敪
            writer.Write(temp.GoodsSearchDivCd);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���[�J�[�J�i����
            writer.Write(temp.MakerKanaName);
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
            //����݌Ɏ�񂹋敪
            writer.Write(temp.SalesOrderDivCd);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write(temp.CustRateGrpCode);
            //�艿��
            writer.Write(temp.ListPriceRate);
            //�|���ݒ苒�_�i�艿�j
            writer.Write(temp.RateSectPriceUnPrc);
            //�|���ݒ�敪�i�艿�j
            writer.Write(temp.RateDivLPrice);
            //�P���Z�o�敪�i�艿�j
            writer.Write(temp.UnPrcCalcCdLPrice);
            //���i�敪�i�艿�j
            writer.Write(temp.PriceCdLPrice);
            //��P���i�艿�j
            writer.Write(temp.StdUnPrcLPrice);
            //�[�������P�ʁi�艿�j
            writer.Write(temp.FracProcUnitLPrice);
            //�[�������i�艿�j
            writer.Write(temp.FracProcLPrice);
            //�艿�i�ō��C�����j
            writer.Write(temp.ListPriceTaxIncFl);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�艿�ύX�敪
            writer.Write(temp.ListPriceChngCd);
            //������
            writer.Write(temp.SalesRate);
            //�|���ݒ苒�_�i����P���j
            writer.Write(temp.RateSectSalUnPrc);
            //�|���ݒ�敪�i����P���j
            writer.Write(temp.RateDivSalUnPrc);
            //�P���Z�o�敪�i����P���j
            writer.Write(temp.UnPrcCalcCdSalUnPrc);
            //���i�敪�i����P���j
            writer.Write(temp.PriceCdSalUnPrc);
            //��P���i����P���j
            writer.Write(temp.StdUnPrcSalUnPrc);
            //�[�������P�ʁi����P���j
            writer.Write(temp.FracProcUnitSalUnPrc);
            //�[�������i����P���j
            writer.Write(temp.FracProcSalUnPrc);
            //����P���i�ō��C�����j
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //����P���ύX�敪
            writer.Write(temp.SalesUnPrcChngCd);
            //������
            writer.Write(temp.CostRate);
            //�|���ݒ苒�_�i�����P���j
            writer.Write(temp.RateSectCstUnPrc);
            //�|���ݒ�敪�i�����P���j
            writer.Write(temp.RateDivUnCst);
            //�P���Z�o�敪�i�����P���j
            writer.Write(temp.UnPrcCalcCdUnCst);
            //���i�敪�i�����P���j
            writer.Write(temp.PriceCdUnCst);
            //��P���i�����P���j
            writer.Write(temp.StdUnPrcUnCst);
            //�[�������P�ʁi�����P���j
            writer.Write(temp.FracProcUnitUnCst);
            //�[�������i�����P���j
            writer.Write(temp.FracProcUnCst);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //�����P���ύX�敪
            writer.Write(temp.SalesUnitCostChngDiv);
            //BL���i�R�[�h�i�|���j
            writer.Write(temp.RateBLGoodsCode);
            //BL���i�R�[�h���́i�|���j
            writer.Write(temp.RateBLGoodsName);
            //���i�|���O���[�v�R�[�h�i�|���j
            writer.Write(temp.RateGoodsRateGrpCd);
            //���i�|���O���[�v���́i�|���j
            writer.Write(temp.RateGoodsRateGrpNm);
            //BL�O���[�v�R�[�h�i�|���j
            writer.Write(temp.RateBLGroupCode);
            //BL�O���[�v���́i�|���j
            writer.Write(temp.RateBLGroupName);
            //BL���i�R�[�h�i����j
            writer.Write(temp.PrtBLGoodsCode);
            //BL���i�R�[�h���́i����j
            writer.Write(temp.PrtBLGoodsName);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //�̔��敪����
            writer.Write(temp.SalesCdNm);
            //��ƍH��
            writer.Write(temp.WorkManHour);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //�󒍒�����
            writer.Write(temp.AcptAnOdrAdjustCnt);
            //�󒍎c��
            writer.Write(temp.AcptAnOdrRemainCnt);
            //�c���X�V��
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //������z�i�ō��݁j
            writer.Write(temp.SalesMoneyTaxInc);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //����
            writer.Write(temp.Cost);
            //�e���`�F�b�N�敪
            writer.Write(temp.GrsProfitChkDiv);
            //���㏤�i�敪
            writer.Write(temp.SalesGoodsCd);
            //������z����Ŋz
            writer.Write(temp.SalesPriceConsTax);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //�����`�[�ԍ��i���ׁj
            writer.Write(temp.PartySlipNumDtl);
            //���ה��l
            writer.Write(temp.DtlNote);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�����ԍ�
            writer.Write(temp.OrderNumber);
            //�������@
            writer.Write(temp.WayToOrder);
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
            //�ύX�O�艿
            writer.Write(temp.BfListPrice);
            //�ύX�O����
            writer.Write(temp.BfSalesUnitPrice);
            //�ύX�O����
            writer.Write(temp.BfUnitCost);
            //�ꎮ���הԍ�
            writer.Write(temp.CmpltSalesRowNo);
            //���[�J�[�R�[�h�i�ꎮ�j
            writer.Write(temp.CmpltGoodsMakerCd);
            //���[�J�[���́i�ꎮ�j
            writer.Write(temp.CmpltMakerName);
            //���[�J�[�J�i���́i�ꎮ�j
            writer.Write(temp.CmpltMakerKanaName);
            //���i���́i�ꎮ�j
            writer.Write(temp.CmpltGoodsName);
            //���ʁi�ꎮ�j
            writer.Write(temp.CmpltShipmentCnt);
            //����P���i�ꎮ�j
            writer.Write(temp.CmpltSalesUnPrcFl);
            //������z�i�ꎮ�j
            writer.Write(temp.CmpltSalesMoney);
            //�����P���i�ꎮ�j
            writer.Write(temp.CmpltSalesUnitCost);
            //�������z�i�ꎮ�j
            writer.Write(temp.CmpltCost);
            //�����`�[�ԍ��i�ꎮ�j
            writer.Write(temp.CmpltPartySalSlNum);
            //�ꎮ���l
            writer.Write(temp.CmpltNote);
            //����p�i��
            writer.Write(temp.PrtGoodsNo);
            //����p���[�J�[�R�[�h
            writer.Write(temp.PrtMakerCode);
            //����p���[�J�[����
            writer.Write(temp.PrtMakerName);
            //�L�����y�[���R�[�h
            writer.Write(temp.CampaignCode);
            //�L�����y�[������
            writer.Write(temp.CampaignName);
            //���i���
            writer.Write(temp.GoodsDivCd);
            //�񓚔[��
            writer.Write(temp.AnswerDelivDate);
            //���T�C�N���敪
            writer.Write(temp.RecycleDiv);
            //���T�C�N���敪����
            writer.Write(temp.RecycleDivNm);
            //�󒍕��@
            writer.Write(temp.WayToAcptOdr);
            //�o�׍�����
            writer.Write(temp.ShipmCntDifference);
            //���׊֘A�t��GUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
            //�݌ɍX�V�敪
            //writer.Write(temp.StockUpdateDiv);

        }

        /// <summary>
        ///  AddUpOrgSalesDetailWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AddUpOrgSalesDetailWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgSalesDetailWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private AddUpOrgSalesDetailWork GetAddUpOrgSalesDetailWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AddUpOrgSalesDetailWork temp = new AddUpOrgSalesDetailWork();

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
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����s�ԍ�
            temp.SalesRowNo = reader.ReadInt32();
            //����s�ԍ��}��
            temp.SalesRowDerivNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //���ʒʔ�
            temp.CommonSeqNo = reader.ReadInt64();
            //���㖾�גʔ�
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //�󒍃X�e�[�^�X�i���j
            temp.AcptAnOdrStatusSrc = reader.ReadInt32();
            //���㖾�גʔԁi���j
            temp.SalesSlipDtlNumSrc = reader.ReadInt64();
            //�d���`���i�����j
            temp.SupplierFormalSync = reader.ReadInt32();
            //�d�����גʔԁi�����j
            temp.StockSlipDtlNumSync = reader.ReadInt64();
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //�[�i�����\���
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i�����敪
            temp.GoodsSearchDivCd = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���[�J�[�J�i����
            temp.MakerKanaName = reader.ReadString();
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
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
            //�I�[�v�����i�敪
            temp.OpenPriceDiv = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�艿��
            temp.ListPriceRate = reader.ReadDouble();
            //�|���ݒ苒�_�i�艿�j
            temp.RateSectPriceUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�艿�j
            temp.RateDivLPrice = reader.ReadString();
            //�P���Z�o�敪�i�艿�j
            temp.UnPrcCalcCdLPrice = reader.ReadInt32();
            //���i�敪�i�艿�j
            temp.PriceCdLPrice = reader.ReadInt32();
            //��P���i�艿�j
            temp.StdUnPrcLPrice = reader.ReadDouble();
            //�[�������P�ʁi�艿�j
            temp.FracProcUnitLPrice = reader.ReadDouble();
            //�[�������i�艿�j
            temp.FracProcLPrice = reader.ReadInt32();
            //�艿�i�ō��C�����j
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�艿�ύX�敪
            temp.ListPriceChngCd = reader.ReadInt32();
            //������
            temp.SalesRate = reader.ReadDouble();
            //�|���ݒ苒�_�i����P���j
            temp.RateSectSalUnPrc = reader.ReadString();
            //�|���ݒ�敪�i����P���j
            temp.RateDivSalUnPrc = reader.ReadString();
            //�P���Z�o�敪�i����P���j
            temp.UnPrcCalcCdSalUnPrc = reader.ReadInt32();
            //���i�敪�i����P���j
            temp.PriceCdSalUnPrc = reader.ReadInt32();
            //��P���i����P���j
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //�[�������P�ʁi����P���j
            temp.FracProcUnitSalUnPrc = reader.ReadDouble();
            //�[�������i����P���j
            temp.FracProcSalUnPrc = reader.ReadInt32();
            //����P���i�ō��C�����j
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //����P���ύX�敪
            temp.SalesUnPrcChngCd = reader.ReadInt32();
            //������
            temp.CostRate = reader.ReadDouble();
            //�|���ݒ苒�_�i�����P���j
            temp.RateSectCstUnPrc = reader.ReadString();
            //�|���ݒ�敪�i�����P���j
            temp.RateDivUnCst = reader.ReadString();
            //�P���Z�o�敪�i�����P���j
            temp.UnPrcCalcCdUnCst = reader.ReadInt32();
            //���i�敪�i�����P���j
            temp.PriceCdUnCst = reader.ReadInt32();
            //��P���i�����P���j
            temp.StdUnPrcUnCst = reader.ReadDouble();
            //�[�������P�ʁi�����P���j
            temp.FracProcUnitUnCst = reader.ReadDouble();
            //�[�������i�����P���j
            temp.FracProcUnCst = reader.ReadInt32();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //�����P���ύX�敪
            temp.SalesUnitCostChngDiv = reader.ReadInt32();
            //BL���i�R�[�h�i�|���j
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�|���j
            temp.RateBLGoodsName = reader.ReadString();
            //���i�|���O���[�v�R�[�h�i�|���j
            temp.RateGoodsRateGrpCd = reader.ReadInt32();
            //���i�|���O���[�v���́i�|���j
            temp.RateGoodsRateGrpNm = reader.ReadString();
            //BL�O���[�v�R�[�h�i�|���j
            temp.RateBLGroupCode = reader.ReadInt32();
            //BL�O���[�v���́i�|���j
            temp.RateBLGroupName = reader.ReadString();
            //BL���i�R�[�h�i����j
            temp.PrtBLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i����j
            temp.PrtBLGoodsName = reader.ReadString();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //�̔��敪����
            temp.SalesCdNm = reader.ReadString();
            //��ƍH��
            temp.WorkManHour = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //�󒍒�����
            temp.AcptAnOdrAdjustCnt = reader.ReadDouble();
            //�󒍎c��
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //�c���X�V��
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //������z�i�ō��݁j
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //����
            temp.Cost = reader.ReadInt64();
            //�e���`�F�b�N�敪
            temp.GrsProfitChkDiv = reader.ReadInt32();
            //���㏤�i�敪
            temp.SalesGoodsCd = reader.ReadInt32();
            //������z����Ŋz
            temp.SalesPriceConsTax = reader.ReadInt64();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //�����`�[�ԍ��i���ׁj
            temp.PartySlipNumDtl = reader.ReadString();
            //���ה��l
            temp.DtlNote = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�����ԍ�
            temp.OrderNumber = reader.ReadString();
            //�������@
            temp.WayToOrder = reader.ReadInt32();
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
            //�ύX�O�艿
            temp.BfListPrice = reader.ReadDouble();
            //�ύX�O����
            temp.BfSalesUnitPrice = reader.ReadDouble();
            //�ύX�O����
            temp.BfUnitCost = reader.ReadDouble();
            //�ꎮ���הԍ�
            temp.CmpltSalesRowNo = reader.ReadInt32();
            //���[�J�[�R�[�h�i�ꎮ�j
            temp.CmpltGoodsMakerCd = reader.ReadInt32();
            //���[�J�[���́i�ꎮ�j
            temp.CmpltMakerName = reader.ReadString();
            //���[�J�[�J�i���́i�ꎮ�j
            temp.CmpltMakerKanaName = reader.ReadString();
            //���i���́i�ꎮ�j
            temp.CmpltGoodsName = reader.ReadString();
            //���ʁi�ꎮ�j
            temp.CmpltShipmentCnt = reader.ReadDouble();
            //����P���i�ꎮ�j
            temp.CmpltSalesUnPrcFl = reader.ReadDouble();
            //������z�i�ꎮ�j
            temp.CmpltSalesMoney = reader.ReadInt64();
            //�����P���i�ꎮ�j
            temp.CmpltSalesUnitCost = reader.ReadDouble();
            //�������z�i�ꎮ�j
            temp.CmpltCost = reader.ReadInt64();
            //�����`�[�ԍ��i�ꎮ�j
            temp.CmpltPartySalSlNum = reader.ReadString();
            //�ꎮ���l
            temp.CmpltNote = reader.ReadString();
            //����p�i��
            temp.PrtGoodsNo = reader.ReadString();
            //����p���[�J�[�R�[�h
            temp.PrtMakerCode = reader.ReadInt32();
            //����p���[�J�[����
            temp.PrtMakerName = reader.ReadString();
            //�L�����y�[���R�[�h
            temp.CampaignCode = reader.ReadInt32();
            //�L�����y�[������
            temp.CampaignName = reader.ReadString();
            //���i���
            temp.GoodsDivCd = reader.ReadInt32();
            //�񓚔[��
            temp.AnswerDelivDate = reader.ReadString();
            //���T�C�N���敪
            temp.RecycleDiv = reader.ReadInt32();
            //���T�C�N���敪����
            temp.RecycleDivNm = reader.ReadString();
            //�󒍕��@
            temp.WayToAcptOdr = reader.ReadInt32();
            //�o�׍�����
            temp.ShipmCntDifference = reader.ReadDouble();
            //���׊֘A�t��GUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);
            //�݌ɍX�V�敪


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
        /// <returns>AddUpOrgSalesDetailWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddUpOrgSalesDetailWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddUpOrgSalesDetailWork temp = GetAddUpOrgSalesDetailWork(reader, serInfo);
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
                    retValue = (AddUpOrgSalesDetailWork[])lst.ToArray(typeof(AddUpOrgSalesDetailWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
