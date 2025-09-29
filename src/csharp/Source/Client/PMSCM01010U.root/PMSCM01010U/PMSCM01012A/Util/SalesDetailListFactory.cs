//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Util
{
    using SalesTtlStServer = SingletonInstance<SalesTtlStAgent>;    // ����S�̐ݒ�}�X�^

    /// <summary>
    /// �\�[�g�ςݔ��㖾�׃f�[�^���X�g�̐����N���X
    /// </summary>
    public static class SortedSalesDetailListFactory
    {
        /// <summary>
        /// �\�[�g�ςݔ��㖾�׃f�[�^���X�g�𐶐����܂��B
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.MakeSalesSlipSort() 14278�s�ڂ��ڐA
        /// </remarks>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="sourceSalesDetailList">���ƂȂ锄�㖾�׃f�[�^�̃��X�g</param>
        /// <returns>�\�[�g�ςݔ��㖾�׃f�[�^���X�g</returns>
        public static IList<SalesDetail> CreateSortedSalesDetailList(
            SalesSlip salesSlip,
            IList<SalesDetail> sourceSalesDetailList
        )
        {
            SalesTtlSt salesTotalSetting = SalesTtlStServer.Singleton.Instance.Find(
                salesSlip.EnterpriseCode,
                salesSlip.SectionCode
            );
            if (salesTotalSetting == null) return sourceSalesDetailList;

            switch (salesTotalSetting.SlipCreateProcess)
            {
                case 0: // ���͏�(�s�ԍ���)
                    return sourceSalesDetailList;

                case 1: // �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)
                    return OrderBySalesOrderDivCd(sourceSalesDetailList);

                case 2: // �q�ɏ�(�q�ɁE�s�ԍ���)
                case 3: // �o�͐��(�q�ɁE�s�ԍ���)
                    return OrderByWarehouseCode(sourceSalesDetailList);
            }

            return sourceSalesDetailList;
        }

        #region <�݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)>

        /// <summary>
        /// �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)�Ń\�[�g���܂��B
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.MakeSalesSlipSort() 14278�s�ڂ��ڐA
        /// </remarks>
        /// <param name="sourceSalesDetailList">���ƂȂ锄�㖾�׃f�[�^�̃��X�g</param>
        /// <returns>
        /// �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)�Ń\�[�g�������㖾�׃f�[�^�̃��X�g
        /// </returns>
        private static IList<SalesDetail> OrderBySalesOrderDivCd(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderBySalesOrderDivCd(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderBySalesOrderDivCdList = ConvertSalesDetailList(sortedList);
            return orderBySalesOrderDivCdList.Count > 0 ? orderBySalesOrderDivCdList : sourceSalesDetailList;
        }

        /// <summary>
        /// �݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)�̃\�[�g�L�[���擾���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <returns></returns>
        private static string GetKeyOfOrderBySalesOrderDivCd(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            //sortString = string.Format("{0} DESC,{1}",
            //    salesDetailDataTable.SalesOrderDivCdColumn.ColumnName,
            //    salesDetailDataTable.SalesRowNoColumn.ColumnName
            //);
            return Math.Abs(salesDetail.SalesOrderDivCd - 1).ToString() + salesRowNo.ToString("0000");
        }

        #endregion // </�݌ɁE���(�݌Ɏ��敪(0:��� 1:�݌�)�E�s�ԍ���)>

        #region <�q�ɏ�(�q�ɁE�s�ԍ���)�^�o�͐��(�q�ɁE�s�ԍ���)>

        /// <summary>
        /// �q�ɏ�(�q�ɁE�s�ԍ���)�Ń\�[�g���܂��B
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.MakeSalesSlipSort() 14278�s�ڂ��ڐA
        /// </remarks>
        /// <param name="sourceSalesDetailList">���ƂȂ锄�㖾�׃f�[�^�̃��X�g</param>
        /// <returns>
        /// �q�ɏ�(�q�ɁE�s�ԍ���)�Ń\�[�g�������㖾�׃f�[�^�̃��X�g
        /// </returns>
        private static IList<SalesDetail> OrderByWarehouseCode(IList<SalesDetail> sourceSalesDetailList)
        {
            SortedList<string, SalesDetail> sortedList = new SortedList<string, SalesDetail>();
            for (int i = 0; i < sourceSalesDetailList.Count; i++)
            {
                string sortKey = GetKeyOfOrderByWarehouseCode(sourceSalesDetailList[i], i);
                sortedList.Add(sortKey, sourceSalesDetailList[i]);
            }

            IList<SalesDetail> orderByWarehouseCodeList = ConvertSalesDetailList(sortedList);
            return orderByWarehouseCodeList.Count > 0 ? orderByWarehouseCodeList : sourceSalesDetailList;
        }

        /// <summary>
        /// �q�ɏ�(�q�ɁE�s�ԍ���)�̃\�[�g�L�[���擾���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <returns></returns>
        private static string GetKeyOfOrderByWarehouseCode(
            SalesDetail salesDetail,
            int salesRowNo
        )
        {
            //sortString = string.Format("{0},{1}",
            //    salesDetailDataTable.WarehouseCodeColumn.ColumnName,
            //    salesDetailDataTable.SalesRowNoColumn.ColumnName
            //);
            return SCMEntityUtil.ConvertNumber(salesDetail.WarehouseCode).ToString("000000") + salesRowNo.ToString("0000");
        }

        #endregion // </�q�ɏ�(�q�ɁE�s�ԍ���)�^�o�͐��(�q�ɁE�s�ԍ���)>

        /// <summary>
        /// ���㖾�׃f�[�^���X�g�ɕϊ����܂��B
        /// </summary>
        /// <param name="sortedList">����\�[�g�L�[�Ń\�[�g���ꂽ���㖾�׃f�[�^���X�g</param>
        /// <returns>���㖾�׃f�[�^���X�g</returns>
        private static IList<SalesDetail> ConvertSalesDetailList(SortedList<string, SalesDetail> sortedList)
        {
            IList<SalesDetail> sortedSalesDetailList = new List<SalesDetail>();
            {
                foreach (KeyValuePair<string, SalesDetail> sortedSalesDetail in sortedList)
                {
                    sortedSalesDetailList.Add(sortedSalesDetail.Value);
                }
            }
            return sortedSalesDetailList;
        }
    }
}
