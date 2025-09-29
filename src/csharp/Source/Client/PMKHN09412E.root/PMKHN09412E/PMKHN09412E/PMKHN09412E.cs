using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockQuoteData
    /// <summary>
    ///                      �|���}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �|���}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/8  ����</br>
    /// <br>                 :   �o�׉\���̕⑫�C��</br>
    /// </remarks>
    public class StockQuoteData
    {
        /// <summary>���p�拒�_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>���p�拒�_�R�[�h����</summary>
        private string _bfSectionName = "";

        /// <summary>���p�擾�Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _bfCustRateGrpCode;

        /// <summary>���p�擾�Ӑ�|���O���[�v����</summary>
        private string _bfCustRateGrpName = "";

        /// <summary>���p�擾�Ӑ�R�[�h</summary>
        private Int32 _bfCustomerCode;

        /// <summary>���p�擾�Ӑ於��</summary>
        private string _bfCustomerName = "";

        /// <summary>���p�����_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>���p�����_�R�[�h����</summary>
        private string _afSectionName = "";

        /// <summary>���p�����Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _afCustRateGrpCode;

        /// <summary>���p�����Ӑ�|���O���[�v����</summary>
        private string _afCustRateGrpName = "";

        /// <summary>���p�����Ӑ�R�[�h</summary>
        private Int32 _afCustomerCode;

        /// <summary>���p�����Ӑ於��</summary>
        private string _afCustomerName = "";

        /// <summary>�Ώۋ敪</summary>
        private Int32 _updateDistinctionCode;

        /// <summary>�X�V�敪</summary>
        private Int32 _objectDistinctionCode;

        /// <summary>�Ǎ�����</summary>
        private Int32 _readCount;

        /// <summary>��������</summary>
        private Int32 _processCount;


        /// public propaty name  :  BfSectionCode
        /// <summary>���p�拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionName
        /// <summary>���p�拒�_�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�拒�_�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionName
        {
            get { return _bfSectionName; }
            set { _bfSectionName = value; }
        }

        /// public propaty name  :  BfCustRateGrpCode
        /// <summary>���p�擾�Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�擾�Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BfCustRateGrpCode
        {
            get { return _bfCustRateGrpCode; }
            set { _bfCustRateGrpCode = value; }
        }

        /// public propaty name  :  BfCustRateGrpName
        /// <summary>���p�擾�Ӑ�|���O���[�v���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�擾�Ӑ�|���O���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfCustRateGrpName
        {
            get { return _bfCustRateGrpName; }
            set { _bfCustRateGrpName = value; }
        }

        /// public propaty name  :  BfCustomerCode
        /// <summary>���p�擾�Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�擾�Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BfCustomerCode
        {
            get { return _bfCustomerCode; }
            set { _bfCustomerCode = value; }
        }

        /// public propaty name  :  BfCustomerName
        /// <summary>���p�擾�Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�擾�Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfCustomerName
        {
            get { return _bfCustomerName; }
            set { _bfCustomerName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>���p�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionName
        /// <summary>���p�����_�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�����_�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionName
        {
            get { return _afSectionName; }
            set { _afSectionName = value; }
        }

        /// public propaty name  :  AfCustRateGrpCode
        /// <summary>���p�����Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�����Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AfCustRateGrpCode
        {
            get { return _afCustRateGrpCode; }
            set { _afCustRateGrpCode = value; }
        }

        /// public propaty name  :  AfCustRateGrpName
        /// <summary>���p�����Ӑ�|���O���[�v���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�����Ӑ�|���O���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfCustRateGrpName
        {
            get { return _afCustRateGrpName; }
            set { _afCustRateGrpName = value; }
        }

        /// public propaty name  :  AfCustomerCode
        /// <summary>���p�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AfCustomerCode
        {
            get { return _afCustomerCode; }
            set { _afCustomerCode = value; }
        }

        /// public propaty name  :  AfCustomerName
        /// <summary>���p�����Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���p�����Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfCustomerName
        {
            get { return _afCustomerName; }
            set { _afCustomerName = value; }
        }

        /// public propaty name  :  UpdateDistinctionCode
        /// <summary>�Ώۋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDistinctionCode
        {
            get { return _updateDistinctionCode; }
            set { _updateDistinctionCode = value; }
        }

        /// public propaty name  :  ObjectDistinctionCode
        /// <summary>�X�V�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ObjectDistinctionCode
        {
            get { return _objectDistinctionCode; }
            set { _objectDistinctionCode = value; }
        }

        /// public propaty name  :  ReadCount
        /// <summary>�Ǎ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǎ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReadCount
        {
            get { return _readCount; }
            set { _readCount = value; }
        }

        /// public propaty name  :  ProcessCount
        /// <summary>���������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcessCount
        {
            get { return _processCount; }
            set { _processCount = value; }
        }


        /// <summary>
        /// �|���}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockQuoteData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockQuoteData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockQuoteData()
        {
        }

        /// <summary>
        /// �|���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="bfSectionCode">���p�拒�_�R�[�h</param>
        /// <param name="bfSectionName">���p�拒�_�R�[�h����</param>
        /// <param name="bfCustRateGrpCode">���p�擾�Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="bfCustRateGrpName">���p�擾�Ӑ�|���O���[�v����</param>
        /// <param name="bfCustomerCode">���p�擾�Ӑ�R�[�h</param>
        /// <param name="bfCustomerName">���p�擾�Ӑ於��</param>
        /// <param name="afSectionCode">���p�����_�R�[�h</param>
        /// <param name="afSectionName">���p�����_�R�[�h����</param>
        /// <param name="afCustRateGrpCode">���p�����Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="afCustRateGrpName">���p�����Ӑ�|���O���[�v����</param>
        /// <param name="afCustomerCode">���p�����Ӑ�R�[�h</param>
        /// <param name="afCustomerName">���p�����Ӑ於��</param>
        /// <param name="updateDistinctionCode">�Ώۋ敪</param>
        /// <param name="objectDistinctionCode">�X�V�敪</param>
        /// <param name="readCount">�Ǎ�����</param>
        /// <param name="processCount">��������</param>
        /// <returns>StockQuoteData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockQuoteData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockQuoteData(string bfSectionCode, string bfSectionName, Int32 bfCustRateGrpCode, string bfCustRateGrpName, Int32 bfCustomerCode, string bfCustomerName, string afSectionCode, string afSectionName, Int32 afCustRateGrpCode, string afCustRateGrpName, Int32 afCustomerCode, string afCustomerName, Int32 updateDistinctionCode, Int32 objectDistinctionCode, Int32 readCount, Int32 processCount)
        {
            this._bfSectionCode = bfSectionCode;
            this._bfSectionName = bfSectionName;
            this._bfCustRateGrpCode = bfCustRateGrpCode;
            this._bfCustRateGrpName = bfCustRateGrpName;
            this._bfCustomerCode = bfCustomerCode;
            this._bfCustomerName = bfCustomerName;
            this._afSectionCode = afSectionCode;
            this._afSectionName = afSectionName;
            this._afCustRateGrpCode = afCustRateGrpCode;
            this._afCustRateGrpName = afCustRateGrpName;
            this._afCustomerCode = afCustomerCode;
            this._afCustomerName = afCustomerName;
            this._updateDistinctionCode = updateDistinctionCode;
            this._objectDistinctionCode = objectDistinctionCode;
            this._readCount = readCount;
            this._processCount = processCount;

        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <returns>StockQuoteData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockQuoteData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockQuoteData Clone()
        {
            return new StockQuoteData(this._bfSectionCode, this._bfSectionName, this._bfCustRateGrpCode, this._bfCustRateGrpName, this._bfCustomerCode, this._bfCustomerName, this._afSectionCode, this._afSectionName, this._afCustRateGrpCode, this._afCustRateGrpName, this._afCustomerCode, this._afCustomerName, this._updateDistinctionCode, this._objectDistinctionCode, this._readCount, this._processCount);
        }

        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockQuoteData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockQuoteData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockQuoteData target)
        {
            return ((this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionName == target.BfSectionName)
                 && (this.BfCustRateGrpCode == target.BfCustRateGrpCode)
                 && (this.BfCustRateGrpName == target.BfCustRateGrpName)
                 && (this.BfCustomerCode == target.BfCustomerCode)
                 && (this.BfCustomerName == target.BfCustomerName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionName == target.AfSectionName)
                 && (this.AfCustRateGrpCode == target.AfCustRateGrpCode)
                 && (this.AfCustRateGrpName == target.AfCustRateGrpName)
                 && (this.AfCustomerCode == target.AfCustomerCode)
                 && (this.AfCustomerName == target.AfCustomerName)
                 && (this.UpdateDistinctionCode == target.UpdateDistinctionCode)
                 && (this.ObjectDistinctionCode == target.ObjectDistinctionCode)
                 && (this.ReadCount == target.ReadCount)
                 && (this.ProcessCount == target.ProcessCount));
        }

        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="stockQuoteData1">
        ///                    ��r����StockQuoteData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockQuoteData2">��r����StockQuoteData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockQuoteData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockQuoteData stockQuoteData1, StockQuoteData stockQuoteData2)
        {
            return ((stockQuoteData1.BfSectionCode == stockQuoteData2.BfSectionCode)
                 && (stockQuoteData1.BfSectionName == stockQuoteData2.BfSectionName)
                 && (stockQuoteData1.BfCustRateGrpCode == stockQuoteData2.BfCustRateGrpCode)
                 && (stockQuoteData1.BfCustRateGrpName == stockQuoteData2.BfCustRateGrpName)
                 && (stockQuoteData1.BfCustomerCode == stockQuoteData2.BfCustomerCode)
                 && (stockQuoteData1.BfCustomerName == stockQuoteData2.BfCustomerName)
                 && (stockQuoteData1.AfSectionCode == stockQuoteData2.AfSectionCode)
                 && (stockQuoteData1.AfSectionName == stockQuoteData2.AfSectionName)
                 && (stockQuoteData1.AfCustRateGrpCode == stockQuoteData2.AfCustRateGrpCode)
                 && (stockQuoteData1.AfCustRateGrpName == stockQuoteData2.AfCustRateGrpName)
                 && (stockQuoteData1.AfCustomerCode == stockQuoteData2.AfCustomerCode)
                 && (stockQuoteData1.AfCustomerName == stockQuoteData2.AfCustomerName)
                 && (stockQuoteData1.UpdateDistinctionCode == stockQuoteData2.UpdateDistinctionCode)
                 && (stockQuoteData1.ObjectDistinctionCode == stockQuoteData2.ObjectDistinctionCode)
                 && (stockQuoteData1.ReadCount == stockQuoteData2.ReadCount)
                 && (stockQuoteData1.ProcessCount == stockQuoteData2.ProcessCount));
        }
        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockQuoteData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockQuoteData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockQuoteData target)
        {
            ArrayList resList = new ArrayList();
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionName != target.BfSectionName) resList.Add("BfSectionName");
            if (this.BfCustRateGrpCode != target.BfCustRateGrpCode) resList.Add("BfCustRateGrpCode");
            if (this.BfCustRateGrpName != target.BfCustRateGrpName) resList.Add("BfCustRateGrpName");
            if (this.BfCustomerCode != target.BfCustomerCode) resList.Add("BfCustomerCode");
            if (this.BfCustomerName != target.BfCustomerName) resList.Add("BfCustomerName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionName != target.AfSectionName) resList.Add("AfSectionName");
            if (this.AfCustRateGrpCode != target.AfCustRateGrpCode) resList.Add("AfCustRateGrpCode");
            if (this.AfCustRateGrpName != target.AfCustRateGrpName) resList.Add("AfCustRateGrpName");
            if (this.AfCustomerCode != target.AfCustomerCode) resList.Add("AfCustomerCode");
            if (this.AfCustomerName != target.AfCustomerName) resList.Add("AfCustomerName");
            if (this.UpdateDistinctionCode != target.UpdateDistinctionCode) resList.Add("UpdateDistinctionCode");
            if (this.ObjectDistinctionCode != target.ObjectDistinctionCode) resList.Add("ObjectDistinctionCode");
            if (this.ReadCount != target.ReadCount) resList.Add("ReadCount");
            if (this.ProcessCount != target.ProcessCount) resList.Add("ProcessCount");

            return resList;
        }

        /// <summary>
        /// �|���}�X�^��r����
        /// </summary>
        /// <param name="stockQuoteData1">��r����StockQuoteData�N���X�̃C���X�^���X</param>
        /// <param name="stockQuoteData2">��r����StockQuoteData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockQuoteData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockQuoteData stockQuoteData1, StockQuoteData stockQuoteData2)
        {
            ArrayList resList = new ArrayList();
            if (stockQuoteData1.BfSectionCode != stockQuoteData2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockQuoteData1.BfSectionName != stockQuoteData2.BfSectionName) resList.Add("BfSectionName");
            if (stockQuoteData1.BfCustRateGrpCode != stockQuoteData2.BfCustRateGrpCode) resList.Add("BfCustRateGrpCode");
            if (stockQuoteData1.BfCustRateGrpName != stockQuoteData2.BfCustRateGrpName) resList.Add("BfCustRateGrpName");
            if (stockQuoteData1.BfCustomerCode != stockQuoteData2.BfCustomerCode) resList.Add("BfCustomerCode");
            if (stockQuoteData1.BfCustomerName != stockQuoteData2.BfCustomerName) resList.Add("BfCustomerName");
            if (stockQuoteData1.AfSectionCode != stockQuoteData2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockQuoteData1.AfSectionName != stockQuoteData2.AfSectionName) resList.Add("AfSectionName");
            if (stockQuoteData1.AfCustRateGrpCode != stockQuoteData2.AfCustRateGrpCode) resList.Add("AfCustRateGrpCode");
            if (stockQuoteData1.AfCustRateGrpName != stockQuoteData2.AfCustRateGrpName) resList.Add("AfCustRateGrpName");
            if (stockQuoteData1.AfCustomerCode != stockQuoteData2.AfCustomerCode) resList.Add("AfCustomerCode");
            if (stockQuoteData1.AfCustomerName != stockQuoteData2.AfCustomerName) resList.Add("AfCustomerName");
            if (stockQuoteData1.UpdateDistinctionCode != stockQuoteData2.UpdateDistinctionCode) resList.Add("UpdateDistinctionCode");
            if (stockQuoteData1.ObjectDistinctionCode != stockQuoteData2.ObjectDistinctionCode) resList.Add("ObjectDistinctionCode");
            if (stockQuoteData1.ReadCount != stockQuoteData2.ReadCount) resList.Add("ReadCount");
            if (stockQuoteData1.ProcessCount != stockQuoteData2.ProcessCount) resList.Add("ProcessCount");

            return resList;
        }
    }
}
