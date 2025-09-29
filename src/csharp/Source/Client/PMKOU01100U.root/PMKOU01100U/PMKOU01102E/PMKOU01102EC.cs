using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockCheckDtl
    /// <summary>
    ///                      �d���`�F�b�N�f�[�^�i���ׁj
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���`�F�b�N�f�[�^�i���ׁj�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/9/19</br>
    /// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockCheckDtl
    {
        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d���@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>�d���`�F�b�N�敪�i�����j</summary>
        /// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
        private Int32 _stockCheckDivCAddUp;

        /// <summary>�d���`�F�b�N�敪�i�����j</summary>
        /// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
        private Int32 _stockCheckDivDaily;

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d���@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  StockCheckDivCAddUp
        /// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
        /// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCheckDivCAddUp
        {
            get { return _stockCheckDivCAddUp; }
            set { _stockCheckDivCAddUp = value; }
        }

        /// public propaty name  :  StockCheckDivDaily
        /// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
        /// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCheckDivDaily
        {
            get { return _stockCheckDivDaily; }
            set { _stockCheckDivDaily = value; }
        }


        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj�R���X�g���N�^
        /// </summary>
        /// <returns>StockCheckDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCheckDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCheckDtl()
        {
        }

        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj�R���X�g���N�^
        /// </summary>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="supplierFormal">�d���`��(0:�d���@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <param name="stockCheckDivCAddUp">�d���`�F�b�N�敪�i�����j(0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j)</param>
        /// <param name="stockCheckDivDaily">�d���`�F�b�N�敪�i�����j(0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j)</param>
        /// <returns>StockCheckDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCheckDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCheckDtl(Int32 logicalDeleteCode, Int32 supplierFormal, Int64 stockSlipDtlNum, Int32 stockCheckDivCAddUp, Int32 stockCheckDivDaily)
        {
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierFormal = supplierFormal;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._stockCheckDivCAddUp = stockCheckDivCAddUp;
            this._stockCheckDivDaily = stockCheckDivDaily;
        }

        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj��������
        /// </summary>
        /// <returns>StockCheckDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockCheckDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCheckDtl Clone()
        {
            return new StockCheckDtl(this._logicalDeleteCode, this._supplierFormal, this._stockSlipDtlNum, this._stockCheckDivCAddUp, this._stockCheckDivDaily);
        }

        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockCheckDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCheckDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockCheckDtl target)
        {
            return ((this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.StockCheckDivCAddUp == target.StockCheckDivCAddUp)
                 && (this.StockCheckDivDaily == target.StockCheckDivDaily));
        }

        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj��r����
        /// </summary>
        /// <param name="stockCheckDtl1">
        ///                    ��r����StockCheckDtl�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockCheckDtl2">��r����StockCheckDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCheckDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockCheckDtl stockCheckDtl1, StockCheckDtl stockCheckDtl2)
        {
            return ((stockCheckDtl1.LogicalDeleteCode == stockCheckDtl2.LogicalDeleteCode)
                 && (stockCheckDtl1.SupplierFormal == stockCheckDtl2.SupplierFormal)
                 && (stockCheckDtl1.StockSlipDtlNum == stockCheckDtl2.StockSlipDtlNum)
                 && (stockCheckDtl1.StockCheckDivCAddUp == stockCheckDtl2.StockCheckDivCAddUp)
                 && (stockCheckDtl1.StockCheckDivDaily == stockCheckDtl2.StockCheckDivDaily));
        }
        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockCheckDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCheckDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockCheckDtl target)
        {
            ArrayList resList = new ArrayList();
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.StockCheckDivCAddUp != target.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (this.StockCheckDivDaily != target.StockCheckDivDaily) resList.Add("StockCheckDivDaily");

            return resList;
        }

        /// <summary>
        /// �d���`�F�b�N�f�[�^�i���ׁj��r����
        /// </summary>
        /// <param name="stockCheckDtl1">��r����StockCheckDtl�N���X�̃C���X�^���X</param>
        /// <param name="stockCheckDtl2">��r����StockCheckDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockCheckDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockCheckDtl stockCheckDtl1, StockCheckDtl stockCheckDtl2)
        {
            ArrayList resList = new ArrayList();
            if (stockCheckDtl1.LogicalDeleteCode != stockCheckDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockCheckDtl1.SupplierFormal != stockCheckDtl2.SupplierFormal) resList.Add("SupplierFormal");
            if (stockCheckDtl1.StockSlipDtlNum != stockCheckDtl2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (stockCheckDtl1.StockCheckDivCAddUp != stockCheckDtl2.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (stockCheckDtl1.StockCheckDivDaily != stockCheckDtl2.StockCheckDivDaily) resList.Add("StockCheckDivDaily");

            return resList;
        }
    }
}
