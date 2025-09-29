using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌ɉ񓚕\���@�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �݌ɉ񓚕\���Ɋւ���A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/11/10</br>
    /// <br>UpdateNote  : 2008/12/10 �Ɠc �M�u�@�i���ɂ͉񓚕i����\��</br>
    /// <br>              2008/12/18 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>              �@�݌ɕ\��MAX���ύX</br>
    /// <br>              2009/01/20 �Ɠc �M�u�@�s��Ή�[10207]</br>
    /// <br>              2009/02/03 �Ɠc �M�u�@�s��Ή�[10841]</br>
    /// <br>              2010/05/27 �x�c �����@����UOE�Ή�</br>
    /// </remarks>
    public class PMUOE04123AA
    {
        #region ���萔�A�ϐ��A�\����
        // �ʐM�A�Z���u��ID(�ʐM�v���O����ID)
        private const int PROGRAMID_NOTHING = 0;            // �Ȃ�
        private const int PROGRAMID_TOYOTA = 102;           // �g���^
        private const int PROGRAMID_NISSAN = 202;           // �j�b�T��
        private const int PROGRAMID_MITSUBISHI = 301;       // �~�c�r�V
        private const int PROGRAMID_MATSUDA_OLD = 401;      // ���}�c�_
        private const int PROGRAMID_MATSUDA_NEW = 402;      // �V�}�c�_
        private const int PROGRAMID_HONDA = 501;            // �z���_
        private const int PROGRAMID_PRIME = 1001;           // �D��
        private const int PROGRAMID_PRIME_MEIJI = 1004;     // �D��             //ADD 2010/05/27
        // ���_�f�[�^�\������
        private const int SECTIONDISP_TOYOTA = 33;         // �g���^            //ADD 2008/12/18 �@
        private const int SECTIONDISP_NISSAN = 35;         // �j�b�T��          //ADD 2008/12/18 �@
        private const int SECTIONDISP_MITSUBISHI = 32;     // �~�c�r�V          //ADD 2008/12/18 �@
        private const int SECTIONDISP_MATSUDA_OLD = 3;    // ���}�c�_           //ADD 2008/12/18 �@
        private const int SECTIONDISP_MATSUDA_NEW = 8;      // �V�}�c�_
        //private const int SECTIONDISP_HONDA = 8;            // �z���_         //DEL 2008/12/18 �@
        //private const int SECTIONDISP_HONDA = 5;            // �z���_           //ADD 2008/12/18 �@�@�� DEL 2009/02/03�@�s��Ή�[10841]
        private const int SECTIONDISP_HONDA = 6;            // �z���_           //ADD 2009/02/03�@�s��Ή�[10841]
        private const int SECTIONDISP_PRIME = 2;            // �D��(1�F���_�A2�F�Z���^�[)
        private const int SECTIONDISP_DEFAULT = 35;         // ���̑�

        // �K�C�h�敪
        private const int GUIDEDIVCD_SECTION = 3;           // ���_�敪
        // �f�[�^
        private const int STOCKANSINFO_FIRST = 0;           // �݌ɉ񓚏�񏉊��f�[�^�ʒu

        // HashTable
        private Hashtable _stockAnsInfoHTable = null;       // �݌ɉ񓚏��(key�FINDEX)
        private Hashtable _sectionInfoHTable = null;        // ���_���(key�FUOE������R�[�h-UOE�����ԍ�-UOE�����s�ԍ�)
        private Hashtable _uoeOrderDtlHTable = null;        // UOE������}�X�^(key�FUOE������R�[�h)
        private Hashtable _uoeGuideNameHTable = null;       // UOE�K�C�h���̃}�X�^(key�F���_�R�[�h-UOE������R�[�h)

        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h
        private int _stockAnsInfoHTableIndex = 0;           // �݌ɉ񓚏��INDEX

        # region SectionInfo�\����
        /// <summary>
        /// ���_���@�\����
        /// </summary>
        internal struct SectionInfo
        {
            private string _uoeSection;     // ���_���
            //private int _uoeSectionStock;   // �݌ɐ�     //DEL 2009/02/03�@�s��Ή�[10841]
            private string _uoeSectionStock;   // �݌ɐ�    //ADD 2009/02/03�@�s��Ή�[10841]

            /// <summary>
            /// ���_���ǉ�
            /// </summary>
            /// <param name="uoeSection">���_���</param>
            /// <param name="uoeSectionStock">�݌ɐ�</param>
            public void Add(string uoeSection, int uoeSectionStock)
            {
                this._uoeSection = uoeSection;
                //this._uoeSectionStock = uoeSectionStock;                  //DEL 2009/02/03�@�s��Ή�[10841]
                this._uoeSectionStock = uoeSectionStock.ToString("#,###");  //ADD 2009/02/03�@�s��Ή�[10841]
            }
            // ---ADD 2009/02/03�@�s��Ή�[10841] ----------->>>>>
            public void Add(string uoeSection, string uoeSectionStock)
            {
                this._uoeSection = uoeSection;
                this._uoeSectionStock = uoeSectionStock;
            }
            // ---ADD 2009/02/03�@�s��Ή�[10841] -----------<<<<<

            /// <summary>���_���</summary>
            public string UOESection
            {
                get { return _uoeSection; }
            }
            /* ---DEL 2009/02/03�@�s��Ή�[10841] ------------>>>>>
            /// <summary>�݌ɐ�</summary>
            public int UOESectionStock
            {
                get { return _uoeSectionStock; }
            }
               ---DEL 2009/02/03�@�s��Ή�[10841] ------------<<<<< */
            // ---ADD 2009/02/03�@�s��Ή�[10841] ------------>>>>>
            /// <summary>�݌ɐ�</summary>
            public string UOESectionStock
            {
                get { return _uoeSectionStock; }
            }
            // ---ADD 2009/02/03�@�s��Ή�[10841] ------------<<<<<
        }
        # endregion
        #endregion ���萔�A�ϐ��A�\���� - end

        # region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e��HashTable�p�f�[�^�̎擾���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04123AA(List<StockSndRcvJnl> stockSndRcvJnlList, string enterpriseCode, string sectionCode)
        {
            // ��ƃR�[�h
            this._enterpriseCode = enterpriseCode;

            // ���_�R�[�h
            this._sectionCode = sectionCode;

            // UOE�K�C�h���̃}�X�^
            this.CreateUOEGuideNameHTable();

            // UOE������}�X�^
            this.CreateUOEOrderDtlHTable();

            // UOE����M�W���[�i���f�[�^
            this.CreateStockAnsInfoHTable(stockSndRcvJnlList);
        }
        # endregion ��Constructor - end

        #region ��Public���\�b�h
        #region ��SearchFirst(���񌟍�)
        /// <summary>
        /// �����\���f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h�ȊO(�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">���׃f�[�^</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : �����\���p�f�[�^���擾���܂��B ��SearchBefore�ASearchNext�̑O�ɌĂяo���K�v������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchFirst(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // ����ȊO�̌Ăяo����NG
            if (this._stockAnsInfoHTableIndex != -1)
            {
                supplierDataSet = null;
                detailDataSet = null;
                return false;
            }

            bool status = this.GetDispInfoAll(STOCKANSINFO_FIRST, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��SearchBefore(�O�f�[�^����)
        /// <summary>
        /// �O�f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h�ȊO(�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">���׃f�[�^</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1�O�̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchBefore(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1�O�̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._stockAnsInfoHTableIndex - 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��SearchNext(���f�[�^����)
        /// <summary>
        /// ���f�[�^�擾
        /// </summary>
        /// <param name="supplierDataSet">�O���b�h�ȊO(�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">���׃f�[�^</param>
        /// <returns>True�F�����AFalse�F���s</returns>
        /// <remarks>
        /// <br>Note       : ���ݑI������Ă���f�[�^��1��̃f�[�^���擾���܂��B�f�[�^�������ꍇ��false���Ԃ�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public bool SearchNext(out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            // 1��̃f�[�^���擾
            bool status = this.GetDispInfoAll(this._stockAnsInfoHTableIndex + 1, out supplierDataSet, out detailDataSet);
            return status;
        }
        #endregion

        #region ��GetSectionInfoDataSet(���_�O���b�h�p�f�[�^�Z�b�g�擾)
        /// <summary>
        /// ���_�O���b�h�p�f�[�^�Z�b�g�擾
        /// </summary>
        /// <param name="uoeSupplierCd"></param>
        /// <param name="uoeSalesOrderNo"></param>
        /// <param name="uoeSalesOrderNoRow"></param>
        /// <returns>���_�O���b�h�p�f�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : ������R�[�h�A�����ԍ��A�����s�ԍ������ɋ��_�O���b�h�p�̃f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public DataSet GetSectionInfoDataSet(int uoeSupplierCd, int uoeSalesOrderNo, int uoeSalesOrderNoRow)
        {
            string sectionInfoListkKey = uoeSupplierCd + "-" + uoeSalesOrderNo + "-" + uoeSalesOrderNoRow;
            return CopyToDataSetFromSectionInfoList(uoeSupplierCd, sectionInfoListkKey);
        }
        #endregion
        #endregion ��Public���\�b�h - end

        #region ��Private���\�b�h
        #region ��UOE������}�X�^HashTable�֘A
        #region ��CreateUOEOrderDtlHTable(HashTable�쐬)
        /// <summary>
        /// UOE������}�X�^HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateUOEOrderDtlHTable()
        {
            DataSet retDataSet = new DataSet();

            // UOE������}�X�^�f�[�^�擾(PMUOE09022A)
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            int status = uoeSupplierAcs.Search(ref retDataSet, this._enterpriseCode,this._sectionCode);
            // �ُ�
            if (status != 0)
            {
                this._uoeOrderDtlHTable = null;
                return;
            }
            // �f�[�^�Ȃ�
            if (retDataSet == null)
            {
                this._uoeOrderDtlHTable = null;
                return;
            }

            // HashTable�쐬
            this._uoeOrderDtlHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                int key = 0;
                int.TryParse(dataRow["UoeSupplierCd"].ToString(), out key);

                this._uoeOrderDtlHTable[key] = dataRow["CommAssemblyId"].ToString();
            }
        }
        #endregion

        #region ��GetProgramIdFromUOEOrderDtlHTable(�ʐM�A�Z���u��ID(�ʐM�v���O����ID)�擾)
        /// <summary>
        /// �ʐM�A�Z���u��ID(�ʐM�v���O����ID)�擾
        /// </summary>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>�ʐM�A�Z���u��ID(�ʐM�v���O����ID)</returns>
        /// <remarks>
        /// <br>Note       : UOE������R�[�h������UOE������}�X�^HashTable����ʐM�A�Z���u��ID(�ʐM�v���O����ID)���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private int GetProgramIdFromUOEOrderDtlHTable(int uoeSupplierCd)
        {
            int programId = 0;        // �Ȃ�

            // �f�[�^������
            if (this._uoeOrderDtlHTable == null)
            {
                return programId;
            }

            // INDEX�͈͊O
            if (this._uoeOrderDtlHTable.ContainsKey(uoeSupplierCd) == false)
            {
                return programId;
            }

            bool ret = int.TryParse(this._uoeOrderDtlHTable[uoeSupplierCd].ToString(), out programId);
            return programId;
        }
        #endregion
        #endregion ��UOE������}�X�^HashTable�֘A - end

        #region ��UOE�K�C�h���̃}�X�^HashTable�֘A
        #region ��CreateUOEGuideNameHTable(HashTable�쐬)
        /// <summary>
        /// UOE�K�C�h���̃}�X�^HashTable�쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃}�X�^������HashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateUOEGuideNameHTable()
        {
            // ���o����
            UOEGuideName uoeGuideName = new UOEGuideName();
            uoeGuideName.EnterpriseCode = this._enterpriseCode;     // ��ƃR�[�h
            uoeGuideName.SectionCode = this._sectionCode;           // ���_�R�[�h
            uoeGuideName.UOEGuideDivCd = GUIDEDIVCD_SECTION;        // �K�C�h�敪(3:���_ �Œ�)

            // UOE�K�C�h���̃}�X�^�f�[�^�擾(PMUOE09032A)
            UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();
            DataSet retDataSet = new DataSet();
            int status = uoeGuideNameAcs.Search(ref retDataSet, uoeGuideName);
            // �ُ�
            if (status != 0)
            {
                this._uoeGuideNameHTable = null;
                return;
            }
            // �f�[�^�Ȃ�
            if (retDataSet == null)
            {
                this._uoeGuideNameHTable = null;
                return;
            }

            // HashTable�쐬
            this._uoeGuideNameHTable = new Hashtable();
            foreach (DataRow dataRow in retDataSet.Tables[retDataSet.Tables[0].TableName].Rows)
            {
                string key = dataRow["UOEGuideCode"].ToString() + "-" + dataRow["UOESupplierCd"].ToString();    // �L�[�F���_�R�[�h-UOE������R�[�h
                this._uoeGuideNameHTable[key] = dataRow["UOEGuideNm"].ToString();
            }
        }
        #endregion

        #region ��GetUOEGuideNm(UOE�K�C�h���̎擾)
        /// <summary>
        /// UOE�K�C�h���̎擾
        /// </summary>
        /// <param name="uoeSectionCode">���_�R�[�h</param>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>UOE�K�C�h����</returns>
        /// <remarks>
        /// <br>Note       : ���_�AUOE������R�[�h������UOE�K�C�h���̃}�X�^HashTable����UOE�K�C�h���̂��擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private string GetUOEGuideNm(string uoeSectionCode, int uoeSupplierCd)
        {
            if (this._uoeGuideNameHTable == null)
            {
                return string.Empty;
            }

            string key = uoeSectionCode + "-" + uoeSupplierCd.ToString();
            if (this._uoeGuideNameHTable.ContainsKey(key))
            {
                return this._uoeGuideNameHTable[key].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
        #endregion ��UOE�K�C�h���̃}�X�^HashTable�֘A - end

        #region ���݌ɉ񓚏��HashTable�֘A
        #region ��CreateStockAnsInfoHTable(HashTable�쐬)
        /// <summary>
        /// �݌ɉ񓚏��HashTable�쐬
        /// </summary>
        /// <param name="stockSndRcvJnlList">UOE����M�W���[�i��(�݌�)���X�g</param>
        /// <remarks>
        /// <br>Note       : �n���ꂽUOE����M�W���[�i��(�݌�)���X�g��UOE������AUOE�����ԍ��P�ʂɂ܂Ƃ߂�HashTable�Ɋi�[���܂��B</br>
        /// <br>             �����ɋ��_�pHashTable�̍쐬���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateStockAnsInfoHTable(List<StockSndRcvJnl> stockSndRcvJnlList)
        {
            string bfKey = string.Empty;
            int listCnt = 0;
            int hashTableCnt = 0;
            List<StockSndRcvJnl> stockAnsInfoListGroup = new List<StockSndRcvJnl>();

            this._stockAnsInfoHTable = new Hashtable();
            this._sectionInfoHTable = new Hashtable();
            foreach (StockSndRcvJnl stockSndRcvJnl in stockSndRcvJnlList)
            {
                // �L�[�FUOE������-UOE�����ԍ�
                string key = stockSndRcvJnl.UOESupplierCd + "-" + stockSndRcvJnl.UOESalesOrderNo;

                if ((bfKey != key) && (bfKey != string.Empty))
                {
                    // �ŏ��ȊO�ŃL�[���ς������
                    // UOE������,�����ԍ��P�ʂɂ܂Ƃ߂��f�[�^��HashTable�ɒǉ�
                    this._stockAnsInfoHTable[hashTableCnt] = stockAnsInfoListGroup;
                    hashTableCnt++;

                    // ������
                    stockAnsInfoListGroup = new List<StockSndRcvJnl>();
                    listCnt = 0;
                }

                stockAnsInfoListGroup.Add(stockSndRcvJnl);
                listCnt++;

                // ���_�f�[�^��HashTable�ɒǉ�
                this.CreateSectionInfoHTable(stockSndRcvJnl);

                bfKey = key;
            }

            // �Ō�̃f�[�^��HashTable�ɒǉ�
            this._stockAnsInfoHTable[hashTableCnt] = stockAnsInfoListGroup;

            // �����ʒu
            this._stockAnsInfoHTableIndex = -1;
        }
        #endregion

        #region ��GetDispInfoAll(HashTable�f�[�^�擾)
        /// <summary>
        /// �݌ɉ񓚏��HashTable�f�[�^�擾
        /// </summary>
        /// <param name="index">�����ʒu</param>
        /// <param name="supplierDataSet">�O���b�h�ȊO(�w�b�_�[)�̃f�[�^</param>
        /// <param name="detailDataSet">���׃f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽindex�����ɍ݌ɉ񓚏��HashTable����f�[�^���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool GetDispInfoAll(int index, out DataSet supplierDataSet, out DataSet detailDataSet)
        {
            detailDataSet = null;
            supplierDataSet = null;

            // �f�[�^������
            if (this._stockAnsInfoHTable == null)
            {
                return false;
            }

            // INDEX�͈͊O
            if (this._stockAnsInfoHTable.ContainsKey(index) == false)
            {
                return false;
            }

            // �O���b�h�ȊO�pDataTable�쐬
            DataTable supplierDataTable = null;
            PMUOE04122EA.CreateDataTableSupplier(ref supplierDataTable);

            // ���חpDataTable�쐬
            DataTable detailDataTable = null;
            PMUOE04122EA.CreateDataTableDetail(ref detailDataTable);

            // ������pdataRow
            DataRow supplierDataRow = supplierDataTable.NewRow();

            List<StockSndRcvJnl> stockSndRcvJnlList = (List<StockSndRcvJnl>)this._stockAnsInfoHTable[index];
            foreach (StockSndRcvJnl stockSndRcvJnl in stockSndRcvJnlList)
            {
                // �ŏ��̂�
                if (detailDataTable.Rows.Count == 0)
                {
                    // ��ʕ\���p��������擾
                    supplierDataRow[PMUOE04122EA.ct_Col_UOESupplierName] = stockSndRcvJnl.UOESupplierName;  // ������
                    supplierDataRow[PMUOE04122EA.ct_Col_UoeRemark1] = stockSndRcvJnl.UoeRemark1;            // ���}�[�N�P
                    supplierDataRow[PMUOE04122EA.ct_Col_UoeRemark2] = stockSndRcvJnl.UoeRemark2;            // ���}�[�N�Q
                }

                // ���חpdataRow
                DataRow detailDataRow = detailDataTable.NewRow();
                this.CopyToDataRowFromStockSndRcvJnl(stockSndRcvJnl, ref detailDataRow);

                detailDataTable.Rows.Add(detailDataRow);
            }

            supplierDataTable.Rows.Add(supplierDataRow);

            // �O���b�h�ȊO���ڗpDataSet�쐬
            supplierDataSet = new DataSet();
            supplierDataSet.Tables.Add(supplierDataTable);

            // ���חpDataSet�쐬
            detailDataSet = new DataSet();
            detailDataSet.Tables.Add(detailDataTable);

            this._stockAnsInfoHTableIndex = index;      // ���݂̈ʒu
            return true;
        }
        #endregion

        #region ��CopyToDataRowFromStockSndRcvJnl(UOE����M�W���[�i����DataRow�R�s�[)
        /// <summary>
        /// UOE����M�W���[�i��(�݌�)��DataRow�쐬
        /// </summary>
        /// <param name="stockSndRcvJnl">�R�s�[��</param>
        /// <param name="dataRow">�R�s�[��</param>
        /// <remarks>
        /// <br>Note       : UOE����M�W���[�i��(�݌�)�̓��e������DataRow���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CopyToDataRowFromStockSndRcvJnl(StockSndRcvJnl stockSndRcvJnl, ref DataRow dataRow)
        {
            dataRow[PMUOE04122EA.ct_Col_UOESupplierCd] = stockSndRcvJnl.UOESupplierCd;                      // UOE������R�[�h
            dataRow[PMUOE04122EA.ct_Col_UOESalesOrder] = stockSndRcvJnl.UOESalesOrderNo;                    // UOE�����ԍ�
            dataRow[PMUOE04122EA.ct_Col_UOESalesOrderRowNo] = stockSndRcvJnl.UOESalesOrderRowNo;            // UOE�����s�ԍ�
            dataRow[PMUOE04122EA.ct_Col_GoodsNo] = stockSndRcvJnl.GoodsNo;                                  // �i��
            // ���[�J�[
            if (stockSndRcvJnl.GoodsMakerCd == 0)
            {
                dataRow[PMUOE04122EA.ct_Col_GoodsMakerCd] = string.Empty;
            }
            else
            {
                dataRow[PMUOE04122EA.ct_Col_GoodsMakerCd] = stockSndRcvJnl.GoodsMakerCd.ToString("0000");       
            }
            /* ---DEL 2009/01/20 �s��Ή�[10207] ----------------------------------------------------------------------------------->>>>>
            //dataRow[PMUOE04122EA.ct_Col_GoodsName] = stockSndRcvJnl.GoodsName;                              // �i��       //DEL 2008/12/10 �񓚕i����\��
            dataRow[PMUOE04122EA.ct_Col_GoodsName] = stockSndRcvJnl.AnswerPartsName;                        // �񓚕i��     //ADD 2008/12/10
               ---DEL 2009/01/20 �s��Ή�[10207] -----------------------------------------------------------------------------------<<<<< */
            dataRow[PMUOE04122EA.ct_Col_GoodsName] = stockSndRcvJnl.GoodsName;                              // �񓚕i��     //ADD 2009/01/20 �s��Ή�[10207]
            dataRow[PMUOE04122EA.ct_Col_AnswerListPrice] = stockSndRcvJnl.AnswerListPrice;                  // �W�����i
            dataRow[PMUOE04122EA.ct_Col_AnswerSalesUnitCost] = stockSndRcvJnl.AnswerSalesUnitCost;          // ���P��
            dataRow[PMUOE04122EA.ct_Col_UOEDelivDateCd] = stockSndRcvJnl.UOEDelivDateCd;                    // �[��
            dataRow[PMUOE04122EA.ct_Col_UOESubstCode] = stockSndRcvJnl.UOESubstCode;                        // ���

            // �R�����g
            /* ---DEL 2009/01/22 �s��Ή�[10345] --------------------------------------------------------------->>>>>
            if (string.IsNullOrEmpty(stockSndRcvJnl.HeadErrorMassage) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.HeadErrorMassage;             // �w�b�h�G���[���b�Z�[�W
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.LineErrorMassage) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.LineErrorMassage;             // ���C���G���[���b�Z�[�W
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.SubstPartsNo) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.SubstPartsNo;                 // ��֕i��
            }
            else
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = string.Empty;
            }
               ---DEL 2009/01/22 �s��Ή�[10345] ---------------------------------------------------------------<<<<< */
            // ---ADD 2009/01/22 �s��Ή�[10345] --------------------------------------------------------------->>>>>
            if (string.IsNullOrEmpty(stockSndRcvJnl.HeadErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.HeadErrorMassage;             // �w�b�h�G���[���b�Z�[�W
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.LineErrorMassage.Trim()) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.LineErrorMassage;             // ���C���G���[���b�Z�[�W
            }
            else if (string.IsNullOrEmpty(stockSndRcvJnl.SubstPartsNo.Trim()) == false)
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = stockSndRcvJnl.SubstPartsNo;                 // ��֕i��
            }
            else
            {
                dataRow[PMUOE04122EA.ct_Col_Comment] = string.Empty;
            }
            // ---ADD 2009/01/22 �s��Ή�[10345] ---------------------------------------------------------------<<<<<
        }
        #endregion
        #endregion ���݌ɉ񓚏��HashTable�֘A - end

        #region �����_���HashTable�֘A
        #region ��CreateSectionInfoHTable(HashTable�쐬)
        /// <summary>
        /// ���_���HashTable�쐬
        /// </summary>
        /// <param name="stockSndRcvJnl">�����s�ԍ��P�ʂ̃f�[�^</param>
        /// <remarks>
        /// <br>Note       : UOE����M�W���[�i��(�݌�)�̓��e�����ɋ��_�\���pHashTable���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void CreateSectionInfoHTable(StockSndRcvJnl stockSndRcvJnl)
        {
            List<SectionInfo> sectionInfo = CopyToSectionInfoListFromStockSndRcvJnl(stockSndRcvJnl);

            // ���_���HashTable�쐬
            string key = stockSndRcvJnl.UOESupplierCd + "-" + stockSndRcvJnl.UOESalesOrderNo + "-" + stockSndRcvJnl.UOESalesOrderRowNo;
            this._sectionInfoHTable[key] = sectionInfo;
        }
        #endregion

        #region ��CopyToSectionInfoListFromStockSndRcvJnl(HashTable�f�[�^�擾)
        /// <summary>
        /// ���_�pHashTable�f�[�^�擾
        /// </summary>
        /// <param name="stockSndRcvJnl">UOE����M�W���[�i��(�݌�)</param>
        /// <returns>���_�pList</returns>
        /// <remarks>
        /// <br>Note       : UOE����M�W���[�i��(�݌�)�̓��e�����ɋ��_�pList���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private List<SectionInfo> CopyToSectionInfoListFromStockSndRcvJnl(StockSndRcvJnl stockSndRcvJnl)
        {
            List<SectionInfo> sectionInfoList = new List<SectionInfo>();
            SectionInfo[] sectionInfo = new SectionInfo[35];

            // ---ADD 2009/02/03�@�s��Ή�[10841] ---------------------------------------->>>>>
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(stockSndRcvJnl.UOESupplierCd);
            if (programId == PROGRAMID_HONDA)
            {
                sectionInfo[0].Add(stockSndRcvJnl.UOESectionCode1, stockSndRcvJnl.HeadQtrsStock);
                sectionInfo[1].Add(stockSndRcvJnl.UOESectionCode1, stockSndRcvJnl.UOESectionStock1);
                sectionInfo[2].Add(stockSndRcvJnl.UOESectionCode2, stockSndRcvJnl.UOESectionStock2);
                sectionInfo[3].Add(stockSndRcvJnl.UOESectionCode3, stockSndRcvJnl.UOESectionStock3);
                sectionInfo[4].Add(stockSndRcvJnl.UOESectionCode4, stockSndRcvJnl.UOESectionStock4);
                sectionInfo[5].Add(stockSndRcvJnl.UOESectionCode5, stockSndRcvJnl.UOESectionStock5);
                sectionInfo[6].Add(stockSndRcvJnl.UOESectionCode6, stockSndRcvJnl.UOESectionStock6);
                sectionInfo[7].Add(stockSndRcvJnl.UOESectionCode7, stockSndRcvJnl.UOESectionStock7);
                sectionInfo[8].Add(stockSndRcvJnl.UOESectionCode8, stockSndRcvJnl.UOESectionStock8);
                sectionInfo[9].Add(string.Empty, stockSndRcvJnl.UOESectionStock9);
                sectionInfo[10].Add(string.Empty, stockSndRcvJnl.UOESectionStock10);
                sectionInfo[11].Add(string.Empty, stockSndRcvJnl.UOESectionStock11);
                sectionInfo[12].Add(string.Empty, stockSndRcvJnl.UOESectionStock12);
                sectionInfo[13].Add(string.Empty, stockSndRcvJnl.UOESectionStock13);
                sectionInfo[14].Add(string.Empty, stockSndRcvJnl.UOESectionStock14);
                sectionInfo[15].Add(string.Empty, stockSndRcvJnl.UOESectionStock15);
                sectionInfo[16].Add(string.Empty, stockSndRcvJnl.UOESectionStock16);
                sectionInfo[17].Add(string.Empty, stockSndRcvJnl.UOESectionStock17);
                sectionInfo[18].Add(string.Empty, stockSndRcvJnl.UOESectionStock18);
                sectionInfo[19].Add(string.Empty, stockSndRcvJnl.UOESectionStock19);
                sectionInfo[20].Add(string.Empty, stockSndRcvJnl.UOESectionStock20);
                sectionInfo[21].Add(string.Empty, stockSndRcvJnl.UOESectionStock21);
                sectionInfo[22].Add(string.Empty, stockSndRcvJnl.UOESectionStock22);
                sectionInfo[23].Add(string.Empty, stockSndRcvJnl.UOESectionStock23);
                sectionInfo[24].Add(string.Empty, stockSndRcvJnl.UOESectionStock24);
                sectionInfo[25].Add(string.Empty, stockSndRcvJnl.UOESectionStock25);
                sectionInfo[26].Add(string.Empty, stockSndRcvJnl.UOESectionStock26);
                sectionInfo[27].Add(string.Empty, stockSndRcvJnl.UOESectionStock27);
                sectionInfo[28].Add(string.Empty, stockSndRcvJnl.UOESectionStock28);
                sectionInfo[29].Add(string.Empty, stockSndRcvJnl.UOESectionStock29);
                sectionInfo[30].Add(string.Empty, stockSndRcvJnl.UOESectionStock30);
                sectionInfo[31].Add(string.Empty, stockSndRcvJnl.UOESectionStock31);
                sectionInfo[32].Add(string.Empty, stockSndRcvJnl.UOESectionStock32);
                sectionInfo[33].Add(string.Empty, stockSndRcvJnl.UOESectionStock33);
                sectionInfo[34].Add(string.Empty, stockSndRcvJnl.UOESectionStock34);
            }
            else
            {
            // ---ADD 2009/02/03�@�s��Ή�[10841] ----------------------------------------<<<<<
                sectionInfo[0].Add(stockSndRcvJnl.UOESectionCode1, stockSndRcvJnl.UOESectionStock1);
                sectionInfo[1].Add(stockSndRcvJnl.UOESectionCode2, stockSndRcvJnl.UOESectionStock2);
                sectionInfo[2].Add(stockSndRcvJnl.UOESectionCode3, stockSndRcvJnl.UOESectionStock3);
                sectionInfo[3].Add(stockSndRcvJnl.UOESectionCode4, stockSndRcvJnl.UOESectionStock4);
                sectionInfo[4].Add(stockSndRcvJnl.UOESectionCode5, stockSndRcvJnl.UOESectionStock5);
                sectionInfo[5].Add(stockSndRcvJnl.UOESectionCode6, stockSndRcvJnl.UOESectionStock6);
                sectionInfo[6].Add(stockSndRcvJnl.UOESectionCode7, stockSndRcvJnl.UOESectionStock7);
                sectionInfo[7].Add(stockSndRcvJnl.UOESectionCode8, stockSndRcvJnl.UOESectionStock8);
                sectionInfo[8].Add(string.Empty, stockSndRcvJnl.UOESectionStock9);
                sectionInfo[9].Add(string.Empty, stockSndRcvJnl.UOESectionStock10);
                sectionInfo[10].Add(string.Empty, stockSndRcvJnl.UOESectionStock11);
                sectionInfo[11].Add(string.Empty, stockSndRcvJnl.UOESectionStock12);
                sectionInfo[12].Add(string.Empty, stockSndRcvJnl.UOESectionStock13);
                sectionInfo[13].Add(string.Empty, stockSndRcvJnl.UOESectionStock14);
                sectionInfo[14].Add(string.Empty, stockSndRcvJnl.UOESectionStock15);
                sectionInfo[15].Add(string.Empty, stockSndRcvJnl.UOESectionStock16);
                sectionInfo[16].Add(string.Empty, stockSndRcvJnl.UOESectionStock17);
                sectionInfo[17].Add(string.Empty, stockSndRcvJnl.UOESectionStock18);
                sectionInfo[18].Add(string.Empty, stockSndRcvJnl.UOESectionStock19);
                sectionInfo[19].Add(string.Empty, stockSndRcvJnl.UOESectionStock20);
                sectionInfo[20].Add(string.Empty, stockSndRcvJnl.UOESectionStock21);
                sectionInfo[21].Add(string.Empty, stockSndRcvJnl.UOESectionStock22);
                sectionInfo[22].Add(string.Empty, stockSndRcvJnl.UOESectionStock23);
                sectionInfo[23].Add(string.Empty, stockSndRcvJnl.UOESectionStock24);
                sectionInfo[24].Add(string.Empty, stockSndRcvJnl.UOESectionStock25);
                sectionInfo[25].Add(string.Empty, stockSndRcvJnl.UOESectionStock26);
                sectionInfo[26].Add(string.Empty, stockSndRcvJnl.UOESectionStock27);
                sectionInfo[27].Add(string.Empty, stockSndRcvJnl.UOESectionStock28);
                sectionInfo[28].Add(string.Empty, stockSndRcvJnl.UOESectionStock29);
                sectionInfo[29].Add(string.Empty, stockSndRcvJnl.UOESectionStock30);
                sectionInfo[30].Add(string.Empty, stockSndRcvJnl.UOESectionStock31);
                sectionInfo[31].Add(string.Empty, stockSndRcvJnl.UOESectionStock32);
                sectionInfo[32].Add(string.Empty, stockSndRcvJnl.UOESectionStock33);
                sectionInfo[33].Add(string.Empty, stockSndRcvJnl.UOESectionStock34);
                sectionInfo[34].Add(string.Empty, stockSndRcvJnl.UOESectionStock35);
            }       //ADD 2009/02/03�@�s��Ή�[10841]

            // SectionInfo��List<SectionInfo>
            for (int index = 0; index <= 34; index++)
            {
                sectionInfoList.Add(sectionInfo[index]);
            }

            return sectionInfoList;
        }
        #endregion

        #region ��CopyToDataSetFromSectionInfoList(���_�pList��DataSet�R�s�[)
        /// <summary>
        /// ���_�pList����ʕ\���pDataSet�쐬
        /// </summary>
        /// <param name="uoeSupplierCode">������R�[�h</param>
        /// <param name="key">���_�pHashTable�ǂݍ��݃L�[</param>
        /// <returns>��ʕ\���pDataSet</returns>
        /// <remarks>
        /// <br>Note       : ���_�pList�̓��e�����ɉ�ʕ\���p��DataSet���쐬���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// <br>Date       : 2010/05/27  19060 �x�c ���� ����UOEWEB�Ή�</br>
        /// </remarks>
        private DataSet CopyToDataSetFromSectionInfoList(int uoeSupplierCode, string key)
        {
            // �f�[�^�Ȃ�
            if (this._sectionInfoHTable == null)
            {
                return null;
            }
            // Key�ɊY������f�[�^�Ȃ�
            if (this._sectionInfoHTable.ContainsKey(key) == false)
            {
                return null;
            }

            int count = 0;
            int programId = this.GetProgramIdFromUOEOrderDtlHTable(uoeSupplierCode);

            // DataTable�쐬
            DataTable dataTable = null;
            PMUOE04122EA.CreateDataTableSection(ref dataTable);

            List<SectionInfo> sectionInfoList = (List<SectionInfo>)this._sectionInfoHTable[key];

            foreach (SectionInfo sectionInfo in sectionInfoList)
            {
                // �ő�\���s������
                if (this.SectionInfoDispMaxCheck(programId, count + 1) == false)
                {
                    break;
                }

                DataRow dataRow = dataTable.NewRow();
                switch (programId)
                {
                    case PROGRAMID_TOYOTA:
                    case PROGRAMID_NISSAN:
                    case PROGRAMID_MITSUBISHI:
                    case PROGRAMID_MATSUDA_OLD:
                        {
                            dataRow[PMUOE04122EA.ct_Col_SectionCode] = this.GetUOEGuideNm("*" + count.ToString("00"), uoeSupplierCode);
                            dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                            break;
                        }
                    case PROGRAMID_MATSUDA_NEW:
                        {
                            int uoeSectionCode = 0;
                            int.TryParse(sectionInfo.UOESection, out uoeSectionCode);
                            dataRow[PMUOE04122EA.ct_Col_SectionCode] = this.GetUOEGuideNm(uoeSectionCode.ToString("000"), uoeSupplierCode);
                            dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock.ToString();
                            break;
                        }
                    case PROGRAMID_PRIME_MEIJI:  //ADD 2010/05/27
                    case PROGRAMID_PRIME:
                        {
                            if (count == 0)
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = "���_";
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock.ToString();
                            }
                            else
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = "�Z���^�[";
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock.ToString();
                            }
                            break;
                        }
                    // ---ADD 2009/02/03�@�s��Ή�[10841] --------------------------------------------------->>>>>
                    case PROGRAMID_HONDA:
                        {
                            if (count == 0)
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = "�{���݌�";
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                            }
                            else
                            {
                                dataRow[PMUOE04122EA.ct_Col_SectionCode] = sectionInfo.UOESection;
                                dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                            }
                            break;
                        }
                    // ---ADD 2009/02/03�@�s��Ή�[10841] ---------------------------------------------------<<<<<
                    default:
                        dataRow[PMUOE04122EA.ct_Col_SectionCode] = sectionInfo.UOESection;
                        dataRow[PMUOE04122EA.ct_Col_SectionStock] = sectionInfo.UOESectionStock;
                        break;
                }

                dataTable.Rows.Add(dataRow);
                count++;
            }

            // ��ʕ\���pDataSet�쐬
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            return dataSet;
        }
        #endregion

        #region ��SectionInfoDispMaxCheck(���_�\���s���`�F�b�N)
        /// <summary>
        /// �\���`�F�b�N
        /// </summary>
        /// <param name="programId">�A�Z���u��ID(�v���O����ID)</param>
        /// <param name="count">�O���b�h�\������</param>
        /// <returns>True�F�\���AFalse�F��\��</returns>
        /// <remarks>
        /// <br>Note       : �A�Z���u��ID���̕\���s���𔻒肵�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private bool SectionInfoDispMaxCheck(int programId, int count)
        {
            switch (programId)
            {
                case PROGRAMID_TOYOTA:
                    // --- ADD 2008/12/18 �@ ---------------------------------------->>>>>
                    {
                        if (count <= SECTIONDISP_TOYOTA)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 �@ ----------------------------------------<<<<<
                case PROGRAMID_NISSAN:
                    // --- ADD 2008/12/18 �@ ---------------------------------------->>>>>
                    {
                        if (count <= SECTIONDISP_NISSAN)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 �@ ----------------------------------------<<<<<
                case PROGRAMID_MITSUBISHI:
                // --- ADD 2008/12/18 �@ ---------------------------------------->>>>>
                    {
                        if (count <= SECTIONDISP_MITSUBISHI)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 �@ ----------------------------------------<<<<<
                case PROGRAMID_MATSUDA_OLD:
                    {
                        //if (count <= SECTIONDISP_DEFAULT)         //DEL 2008/12/18 �@
                        if (count <= SECTIONDISP_MATSUDA_OLD)       //ADD 2008/12/18 �@
                        {
                            return true;
                        }
                        break;
                    }
                case PROGRAMID_MATSUDA_NEW:
                    {
                        if (count <= SECTIONDISP_MATSUDA_NEW)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 �@ ---------------------------------------->>>>>
                case PROGRAMID_HONDA:
                    {
                        if (count <= SECTIONDISP_HONDA)
                        {
                            return true;
                        }
                        break;
                    }
                // --- ADD 2008/12/18 �@ ----------------------------------------<<<<<
                case PROGRAMID_PRIME_MEIJI:  //ADD 2010/05/27
                case PROGRAMID_PRIME:
                    {
                        if (count <= SECTIONDISP_PRIME)
                        {
                            return true;
                        }
                        break;
                    }
                default:
                    //if (count <= SECTIONDISP_HONDA)               //DEL 2008/12/18 �@
                    if (count <= SECTIONDISP_DEFAULT)               //ADD 2008/12/18 �@
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        #endregion
        #endregion �����_���HashTable�֘A - end
        #endregion ��Private���\�b�h - end
    }
}

