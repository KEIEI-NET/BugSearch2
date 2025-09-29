using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSalesStockSlipWork3
    /// <summary>
    ///                      ����d�������W�v�f�[�^(�d���p)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����d�������W�v�f�[�^(�d���p)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MTtlSalesStockSlipWork3 : System.IComparable
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�d���f�[�^�̎d�����_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v��N��</summary>
        /// <remarks>������t����擾</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>���яW�v�敪</summary>
        /// <remarks>0�F���v 1�F�݌�</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�d���݌Ɏ�񂹋敪</summary>
        /// <remarks>0:���,1:�݌�</remarks>
        private Int32 _stockOrderDivCd;

        /// <summary>�d���`�[�敪�i���ׁj</summary>
        /// <remarks>0:�d��,1:�ԕi,2:�l��</remarks>
        private Int32 _stockSlipCdDtl;

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stockDate;

        /// <summary>�}�b�`���O���</summary>
        /// <remarks>0:unmatched�A1:matched</remarks>
        private Int32 _matchingStatus;


        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^�̎d�����_�R�[�h</value>
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

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>������t����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>���яW�v�敪�v���p�e�B</summary>
        /// <value>0�F���v 1�F�݌�</value>
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>�d���݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:���,1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }

        /// public propaty name  :  StockSlipCdDtl
        /// <summary>�d���`�[�敪�i���ׁj�v���p�e�B</summary>
        /// <value>0:�d��,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCdDtl
        {
            get { return _stockSlipCdDtl; }
            set { _stockSlipCdDtl = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  MatchingStatus
        /// <summary>�}�b�`���O��ԃv���p�e�B</summary>
        /// <value>0:unmatched�A1:matched</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�b�`���O��ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MatchingStatus
        {
            get { return _matchingStatus; }
            set { _matchingStatus = value; }
        }


        /// <summary>
        /// ����d�������W�v�f�[�^(�d���p)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MTtlSalesStockSlip3Work�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesStockSlip3Work�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MTtlSalesStockSlipWork3()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks>
        /// System.IComparable��CompareTo���\�b�h�̎���
        /// </remarks>
        public int CompareTo(object obj)
        {
            // this > object	:	���̒l��Ԃ��B
            // this == object	:	0��Ԃ��B
            // this < object	:	���̒l��Ԃ�
            int result;
            if ((result = this.AddUpSecCode.CompareTo(((MTtlSalesStockSlipWork3)obj).AddUpSecCode)) != 0) return result;
            if ((this.AddUpYearMonth - ((MTtlSalesStockSlipWork3)obj).AddUpYearMonth) != 0) return result;
            if ((this.RsltTtlDivCd - ((MTtlSalesStockSlipWork3)obj).RsltTtlDivCd) != 0) return result;
            return this.SupplierCd - ((MTtlSalesStockSlipWork3)obj).SupplierCd;
        }


    }

}

