using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSalesStockSlipWork4
    /// <summary>
    ///                      ����d�������W�v�f�[�^(�݌Ɉړ��p)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����d�������W�v�f�[�^(�݌Ɉړ��p)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MTtlSalesStockSlipWork4 : System.IComparable
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�݌Ɉړ��f�[�^�̈ړ��拒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v��N��</summary>
        /// <remarks>�o�׊m����܂��͓��׊m�������擾</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>���яW�v�敪</summary>
        /// <remarks>0�F���v 1�F�݌�</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�ړ����</summary>
        /// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
        private Int32 _moveStatus;

        /// <summary>�ړ���</summary>
        private Double _moveCount;

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�o�ח\���</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private Int32 _shipmentScdlDay;

        /// <summary>�o�׊m���</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private Int32 _shipmentFixDay;

        /// <summary>���ד�</summary>
        /// <remarks>�݌Ɉړ������i���ב��j���s�������ɃZ�b�g</remarks>
        private Int32 _arrivalGoodsDay;

        /// <summary>�}�b�`���O���</summary>
        /// <remarks>0:unmatched�A1:matched</remarks>
        private Int32 _matchingStatus;


        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�݌Ɉړ��f�[�^�̈ړ��拒�_�R�[�h</value>
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
        /// <value>�o�׊m����܂��͓��׊m�������擾</value>
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

        /// public propaty name  :  MoveStatus
        /// <summary>�ړ���ԃv���p�e�B</summary>
        /// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  MoveCount
        /// <summary>�ړ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveCount
        {
            get { return _moveCount; }
            set { _moveCount = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  ShipmentScdlDay
        /// <summary>�o�ח\����v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentScdlDay
        {
            get { return _shipmentScdlDay; }
            set { _shipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentFixDay
        /// <summary>�o�׊m����v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׊m����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentFixDay
        {
            get { return _shipmentFixDay; }
            set { _shipmentFixDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// <value>�݌Ɉړ������i���ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
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
        /// ����d�������W�v�f�[�^(�݌Ɉړ��p)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MTtlSalesStockSlip4Work�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesStockSlip4Work�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MTtlSalesStockSlipWork4()
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
            if ((result = this.AddUpSecCode.CompareTo(((MTtlSalesStockSlipWork4)obj).AddUpSecCode)) != 0) return result;
            if ((this.AddUpYearMonth - ((MTtlSalesStockSlipWork4)obj).AddUpYearMonth) != 0) return result;
            if ((this.RsltTtlDivCd - ((MTtlSalesStockSlipWork4)obj).RsltTtlDivCd) != 0) return result;
            return this.SupplierCd - ((MTtlSalesStockSlipWork4)obj).SupplierCd;
        }


    }

}

